using System;
using System.Collections.Generic;
using System.Reflection;
using Benchmark.Internal;

namespace Benchmark.Common {
    public class TestLoader {
        public bool Enabled {
            get;
            set;
        }
        public MethodInfo Test {
            get;
            internal set;
        }
        public string AssemblyPath {
            get;
            internal set;
        }
        public string AssemblyName {
            get;
            internal set;
        }
        public string Category {
            get;
            internal set;
        }
        public string Name {
            get;
            internal set;
        }
        public string Scope {
            get;
            internal set;
        }
        public string TargetFramework {
            get;
            internal set;
        }
        public string Product {
            get;
            internal set;
        }
        public string Path {
            get { return Folders.Temp + FullName + Resolution.EXE; }
        }
        public string Template {
            get;
            internal set;
        }
        public bool ManualMode {
            get;
            internal set;
        }
        public string FullName {
            get { return String.Format(Formats.TestFullName, Scope, Product, Category, Name); }
        }
    }
    public class TypeLoader {
        public Type Class {
            get;
            internal set;
        }
        public string Category {
            get {
                if(Attribute == null) return string.Empty;
                return string.IsNullOrEmpty(Attribute.Category) ? Class.Name : Attribute.Category;
            }
        }
        public MethodInfo SetUp {
            get;
            internal set;
        }
        public MethodInfo TearDown {
            get;
            internal set;
        }
        public BenchmarkFixtureAttribute Attribute {
            get;
            internal set;
        }
        public MethodInfo[] Tests {
            get;
            internal set;
        }
        public EventInfo Completed {
            get;
            internal set;
        }
        public EventInfo Ready {
            get;
            internal set;
        }
        internal IEnumerable<TestLoader> GetTests() {
            if(Tests == null) yield break;
            foreach(MethodInfo test in Tests) {
                TestLoader testLoader = new TestLoader();
                BenchmarkAttribute attribute = AttributeHelper.GetAttribute<BenchmarkAttribute>(test);
                testLoader.ManualMode = Attribute.ManualMode || attribute.ManualMode;
                testLoader.Category = Category;
                testLoader.Name = GetTestName(attribute, test.Name);
                testLoader.Test = test;
                yield return testLoader;
            }
        }
        string GetTestName(BenchmarkAttribute attribute, string defaultName) {
            if(attribute == null) return string.Empty;
            return string.IsNullOrEmpty(attribute.Name) ? defaultName : attribute.Name;
        }
    }
    public class AssemblyLoader {
        List<TypeLoader> typesCore;
        AssemblyLoader() { }
        public List<TypeLoader> Types {
            get { return typesCore; }
        }
        public string FullPath {
            get;
            private set;
        }
        public string AssemblyName {
            get;
            private set;
        }
        public string Scope {
            get;
            private set;
        }
        public string Product {
            get;
            private set;
        }
        public string TargetFramework {
            get;
            private set;
        }
        public IEnumerable<TestLoader> GetTests() {
            if(Types == null) yield break;
            foreach(TypeLoader typeLoader in Types) {
                foreach(TestLoader testLoader in typeLoader.GetTests()) {
                    testLoader.Product = Product;
                    testLoader.Scope = Scope;
                    testLoader.AssemblyName = AssemblyName;
                    testLoader.AssemblyPath = FullPath;
                    testLoader.TargetFramework = TargetFramework;
                    TestBuilder.Build(testLoader, typeLoader);
                    yield return testLoader;
                }
            }
        }
        public static AssemblyLoader Load(string assemblyPath) {
            try {
                Assembly assembly = Assembly.LoadFrom(assemblyPath);
                AssemblyLoader data = new AssemblyLoader();
                data.FullPath = assemblyPath;
                data.Initialize(assembly);
                return data;
            }
            catch(Exception e) {
                throw (e);
            }
        }
        void Initialize(Assembly assembly) {
            AssemblyName = assembly.GetName().Name;
            BenchmarkAssemblyAttribute benchmarkAttribute = AttributeHelper.GetAssemblyAttribute<BenchmarkAssemblyAttribute>(assembly);
            if(benchmarkAttribute != null) {
                Product = benchmarkAttribute.Product;
                Scope = benchmarkAttribute.Scope;
            }
            TargetFramework = GetTargetFramework(assembly);
            CheckProduct(assembly);
            CheckScope(assembly);
            Type[] types = assembly.GetExportedTypes();
            typesCore = CreateTypeLoaders(types);
        }
        string GetTargetFramework(Assembly assembly) {
            System.Runtime.Versioning.TargetFrameworkAttribute attribute = AttributeHelper.GetAssemblyAttribute<System.Runtime.Versioning.TargetFrameworkAttribute>(assembly);
            if(attribute == null)
                return "v4.0";
            return attribute.FrameworkName.Split('=')[1];
        }
        void CheckProduct(Assembly assembly) {
            if(!string.IsNullOrEmpty(Product)) return;
            AssemblyProductAttribute productAttribute = AttributeHelper.GetAssemblyAttribute<AssemblyProductAttribute>(assembly);
            if(productAttribute != null)
                Product = productAttribute.Product;
        }
        void CheckScope(Assembly assembly) {
            if(!string.IsNullOrEmpty(Scope)) return;
            AssemblyCompanyAttribute companyAttribute = AttributeHelper.GetAssemblyAttribute<AssemblyCompanyAttribute>(assembly);
            if(companyAttribute != null)
                Scope = companyAttribute.Company;
        }
        List<TypeLoader> CreateTypeLoaders(Type[] types) {
            List<TypeLoader> typesInfo = new List<TypeLoader>();
            if(types == null) return typesInfo;
            foreach(Type _type in types)
                AddToCollection<TypeLoader>(typesInfo, CreateTypeLoader(_type));
            return typesInfo;
        }
        TypeLoader CreateTypeLoader(Type _type) {
            if(_type == null) return null;
            BenchmarkFixtureAttribute attribute = AttributeHelper.GetAttribute<BenchmarkFixtureAttribute>(_type);
            if(attribute == null) return null;
            TypeLoader typeLoader = new TypeLoader();
            typeLoader.Class = _type;
            typeLoader.Attribute = attribute;
            if(FindTestMethods(_type, typeLoader))
                return typeLoader;
            return null;
        }
        bool FindTestMethods(Type _type, TypeLoader typeLoader) {
            if(_type == null) return false;
            MemberInfo[] members = _type.GetMembers(BindingFlags.Public | BindingFlags.Instance);
            if(members == null) return false;
            List<MethodInfo> testMethods = new List<MethodInfo>();
            foreach(MemberInfo member in members) {
                if(member.MemberType == MemberTypes.Method) {
                    MethodInfo method = (MethodInfo)member;
                    if(typeLoader.TearDown == null)
                        typeLoader.TearDown = CheckMethodInfo<BenchmarkTearDownAttribute>(method);
                    if(typeLoader.SetUp == null)
                        typeLoader.SetUp = CheckMethodInfo<BenchmarkSetUpAttribute>(method);
                    AddToCollection<MethodInfo>(testMethods, CheckMethodInfo<BenchmarkAttribute>(method));
                }
                CheckEvents(member, typeLoader);
            }
            typeLoader.Tests = testMethods.ToArray();
            return testMethods != null && testMethods.Count > 0;
        }
        void CheckEvents(MemberInfo member, TypeLoader typeLoader) {
            if(member == null || member.MemberType != MemberTypes.Event) return;
            if(typeLoader.Completed == null)
                typeLoader.Completed = CheckEventInfo<BenchmarkCompletedAttribute>((EventInfo)member);
            if(typeLoader.Ready == null)
                typeLoader.Ready = CheckEventInfo<BenchmarkReadyAttribute>((EventInfo)member);
        }
        MethodInfo CheckMethodInfo<U>(MethodInfo method) where U : Attribute {
            return CheckMemberInfo<MethodInfo, U>(method);
        }
        EventInfo CheckEventInfo<U>(EventInfo method) where U : Attribute {
            return CheckMemberInfo<EventInfo, U>(method);
        }
        T CheckMemberInfo<T, U>(T method)
            where T : MemberInfo
            where U : Attribute {
            U attribute = AttributeHelper.GetAttribute<U>(method);
            if(attribute == null) return null;
            return method;
        }
        void AddToCollection<T>(ICollection<T> targetCollection, T source) {
            if(source == null) return;
            targetCollection.Add(source);
        }
    }
}