using System;
using System.Collections.Generic;
using System.Reflection;
using Benchmark.Internal;

namespace Benchmark {
    public class TestInfo {
        public bool Enabled {
            get;
            set;
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
        public string Vender {
            get;
            internal set;
        }
        public string Product {
            get;
            internal set;
        }
        public string Path {
            get { return Constants.TempFolder + FullName + Constants.EXE; }
        }
        public string Template {
            get;
            internal set;
        }
        public string FullName {
            get { return String.Format(Constants.TestFullNameFormat, Vender, Product, Category, Name); }
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
        internal IEnumerable<TestInfo> GetTests() {
            if(Tests == null) yield break;
            foreach(MethodInfo test in Tests) {
                TestInfo info = new TestInfo();
                info.Template = TemplateGenerator.Default.CreateTemplate(Class, test, SetUp, TearDown, Completed);
                info.Category = Category;
                info.Name = GetTestName(test);
                yield return info;
            }
        }
        string GetTestName(MethodInfo test) {
            if(test == null) return string.Empty;
            BenchmarkAttribute attribute = AttributeHelper.GetAttribute<BenchmarkAttribute>(test);
            if(attribute == null) return string.Empty;
            return string.IsNullOrEmpty(attribute.Name) ? test.Name : attribute.Name;
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
        public string Vender {
            get;
            private set;
        }
        public string Product {
            get;
            private set;
        }
        public IEnumerable<TestInfo> GetTests() {
            if(Types == null) yield break;
            foreach(TypeLoader typeInfo in Types) {
                foreach(TestInfo testInfo in typeInfo.GetTests()) {
                    testInfo.Product = Product;
                    testInfo.Vender = Vender;
                    testInfo.AssemblyName = AssemblyName;
                    testInfo.AssemblyPath = FullPath;
                    yield return testInfo;
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
            AssemblyBenchmark benchmarkAttribute = AttributeHelper.GetAssemblyAttribute<AssemblyBenchmark>(assembly);
            if(benchmarkAttribute != null) {
                Product = benchmarkAttribute.Product;
                Vender = benchmarkAttribute.Vender;
            }
            CheckProduct(assembly);
            CheckVender(assembly);
            Type[] types = assembly.GetExportedTypes();
            typesCore = CreateTypeInfo(types);
        }
        void CheckProduct(Assembly assembly) {
            if(!string.IsNullOrEmpty(Product)) return;
            AssemblyProductAttribute productAttribute = AttributeHelper.GetAssemblyAttribute<AssemblyProductAttribute>(assembly);
            if(productAttribute != null)
                Product = productAttribute.Product;
        }
        void CheckVender(Assembly assembly) {
            if(!string.IsNullOrEmpty(Vender)) return;
            AssemblyCompanyAttribute companyAttribute = AttributeHelper.GetAssemblyAttribute<AssemblyCompanyAttribute>(assembly);
            if(companyAttribute != null)
                Vender = companyAttribute.Company;
        }
        List<TypeLoader> CreateTypeInfo(Type[] types) {
            List<TypeLoader> typesInfo = new List<TypeLoader>();
            if(types == null) return typesInfo;
            foreach(Type _type in types)
                AddToCollection<TypeLoader>(typesInfo, CreateTypeInfo(_type));
            return typesInfo;
        }
        TypeLoader CreateTypeInfo(Type _type) {
            if(_type == null) return null;
            BenchmarkFixtureAttribute attribute = AttributeHelper.GetAttribute<BenchmarkFixtureAttribute>(_type);
            if(attribute == null) return null;
            MethodInfo setUp = null, tearDown = null;
            EventInfo completed = null;
            MethodInfo[] testMethods = FindTestMethods(_type, ref setUp, ref tearDown, ref completed);
            return CreateTypeInfo(_type, setUp, tearDown, completed, attribute, testMethods);
        }
        MethodInfo[] FindTestMethods(Type _type, ref MethodInfo setUp, ref MethodInfo tearDown, ref EventInfo completed) {
            if(_type == null || _type.FullName == Constants.BaseClass) return null;
            MemberInfo[] members = _type.GetMembers(BindingFlags.Public | BindingFlags.Instance);
            if(members == null) return null;
            List<MethodInfo> testMethods = new List<MethodInfo>();
            foreach(MemberInfo member in members) {
                if(member.MemberType == MemberTypes.Method) {
                    MethodInfo method = (MethodInfo)member;
                    if(tearDown == null)
                        tearDown = CheckMethodInfo<BenchmarkTearDownAttribute>(method);
                    if(setUp == null)
                        setUp = CheckMethodInfo<BenchmarkSetUpAttribute>(method);
                    AddToCollection<MethodInfo>(testMethods, CheckMethodInfo<BenchmarkAttribute>(method));
                }
                else if(completed == null)
                    completed = CheckEventInfo<BenchmarkCompletedAttribute>(member as EventInfo);
            }
            //MethodInfo[] baseMethods = FindTestMethods(_type.BaseType, ref setUp, ref tearDown, ref completed);
            //if(baseMethods != null)
            //    testMethods.AddRange(baseMethods);
            return testMethods.ToArray();
        }
        TypeLoader CreateTypeInfo(Type _type, MethodInfo setUp, MethodInfo tearDown, EventInfo completed, BenchmarkFixtureAttribute attribute, MethodInfo[] testMethods) {
            if(_type == null || testMethods == null || testMethods.Length == 0) return null;
            TypeLoader template = new TypeLoader();
            template.Class = _type;
            template.SetUp = setUp;
            template.TearDown = tearDown;
            template.Completed = completed;
            template.Attribute = attribute;
            template.Tests = testMethods;
            return template;
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