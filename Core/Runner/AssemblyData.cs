using System;
using System.Collections.Generic;
using System.Reflection;
using Profiler.Internal;

namespace Profiler.Runner {
    public class TemplateData : IEnumerable<string> {
        int curentIndex;
        public TemplateData() {
            curentIndex = 0;
        }
        public MethodInfo CurrentTest {
            get {
                if(Methods == null || Methods.Length == 0) return null;
                return Methods[curentIndex];
            }
        }
        public string CurrentTestName {
            get {
                MethodInfo currentTest = CurrentTest;
                return currentTest == null ? string.Empty : currentTest.Name;
            }
        }
        public static string Settings {
            get { return TemplateGenerator.Default.SettingsTemplate; }
        }
        public Type Class {
            get;
            set;
        }
        public MethodInfo SetUp {
            get;
            set;
        }
        public MethodInfo TearDown {
            get;
            set;
        }
        public BenchmarkFixtureAttribute Attribute {
            get;
            set;
        }
        public MethodInfo[] Methods {
            get;
            set;
        }
        public EventInfo Completed {
            get;
            set;
        }
        #region IEnumerable<string> Members
        public IEnumerator<string> GetEnumerator() {
            if(Methods == null) yield break;
            foreach(MethodInfo method in Methods) {
                yield return TemplateGenerator.Default.CreateTemplate(Class, method, SetUp, TearDown, Completed);
                curentIndex++;
            }
            curentIndex = 0;
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
        #endregion
    }
    public class AssemblyData {
        List<TemplateData> templatesCore;
        string assemblyNameCore;
        AssemblyData() { }
        public List<TemplateData> Templates {
            get { return templatesCore; }
        }
        public string AssemblyName {
            get { return assemblyNameCore; }
        }
        public static AssemblyData Load(string assemblyPath) {
            try {
                Assembly assembly = Assembly.LoadFrom(assemblyPath);
                AssemblyData data = new AssemblyData();
                data.Initialize(assembly);
                return data;
            }
            catch(Exception e) {
                throw (e);
            }
        }
        void Initialize(Assembly assembly) {
            assemblyNameCore = assembly.FullName;
            Type[] types = assembly.GetExportedTypes();
            templatesCore = CreateTemplates(types);
        }
        List<TemplateData> CreateTemplates(Type[] types) {
            List<TemplateData> templates = new List<TemplateData>();
            if(types == null) return templates;
            foreach(Type _type in types)
                AddToCollection<TemplateData>(templates, CreateTemplate(_type));
            return templates;
        }
        TemplateData CreateTemplate(Type _type) {
            if(_type == null) return null;
            BenchmarkFixtureAttribute attribute = GetAttribute<BenchmarkFixtureAttribute>(_type);
            if(attribute == null) return null;
            MethodInfo tearDown = null, setUp = null;
            EventInfo completed = null;
            MethodInfo[] testMethods = FindTestMethods(_type, ref setUp, ref tearDown, ref completed);
            return CreateTemplate(_type, setUp, tearDown, completed, attribute, testMethods);
        }
        MethodInfo[] FindTestMethods(Type _type, ref MethodInfo setUp, ref MethodInfo tearDown, ref EventInfo completed) {
            if(_type == null || _type.FullName == Constants.BaseClass) return null;
            MemberInfo[] members = _type.GetMembers(BindingFlags.Public | BindingFlags.Instance);
            if(members == null) return null;
            List<MethodInfo> testMethods = new List<MethodInfo>();
            foreach(MemberInfo member in members) {
                if(member.MemberType == MemberTypes.Method) {
                    MethodInfo method = (MethodInfo)member;
                    if(tearDown == null && IsTearDown(method))
                        tearDown = method;
                    else if(setUp == null && IsSetUp(method))
                        setUp = method;
                    else if(IsTest(method))
                        AddToCollection<MethodInfo>(testMethods, method);
                }
                if(completed == null && IsCompletedEvent(member))
                    completed = (EventInfo)member;
            }
            //MethodInfo[] baseMethods = FindTestMethods(_type.BaseType, ref setUp, ref tearDown, ref completed);
            //if(baseMethods != null)
            //    testMethods.AddRange(baseMethods);
            return testMethods.ToArray();
        }
        TemplateData CreateTemplate(Type _type, MethodInfo setUp, MethodInfo tearDown, EventInfo completed, BenchmarkFixtureAttribute attribute, MethodInfo[] testMethods) {
            if(_type == null || testMethods == null || testMethods.Length == 0) return null;
            TemplateData template = new TemplateData();
            template.Class = _type;
            template.SetUp = setUp;
            template.TearDown = tearDown;
            template.Completed = completed;
            template.Attribute = attribute;
            template.Methods = testMethods;
            return template;
        }
        bool IsTest(MemberInfo type) {
            return GetAttribute<BenchmarkAttribute>(type) != null;
        }
        bool IsTearDown(MemberInfo type) {
            return GetAttribute<TearDownProfilerAttribute>(type) != null;
        }
        bool IsSetUp(MemberInfo type) {
            return GetAttribute<SetUpProfilerAttribute>(type) != null;
        }
        bool IsCompletedEvent(MemberInfo type) {
            if(type.MemberType != MemberTypes.Event) return false;
            return GetAttribute<BenchmarkCompletedAttribute>(type) != null;
        }
        T GetAttribute<T>(MemberInfo type) where T : Attribute {
            Attribute attribute = null;
            try {
                if(type != null)
                    attribute = Attribute.GetCustomAttribute(type, typeof(T));
            }
            catch { }
            return attribute == null ? null : (T)attribute;
        }
        void AddToCollection<T>(ICollection<T> targetCollection, T source) {
            if(source == null) return;
            targetCollection.Add(source);
        }
    }
}