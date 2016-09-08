using System;
using System.IO;
using System.Reflection;
using Benchmark.Common;

namespace Benchmark.Internal {
    class TestBuilder {
        protected TestBuilder(bool manual) {
            Manual = manual;
        }
        bool Manual { get; set; }
        bool ParameterIsValid(string parameter) {
            return !string.IsNullOrEmpty(parameter);
        }
        string GetUsing(string customUsing) {
            return
                ParameterIsValid(customUsing) ?
                "using " + customUsing + ";" + Environment.NewLine :
                string.Empty;
        }
        string GetUsingTemplate(string[] usings) {
            if(usings == null) return string.Empty;
            string usingsTemplate = string.Empty;
            foreach(string line in usings) {
                usingsTemplate += GetUsing(line);
            }
            return usingsTemplate;
        }
        string GetCallMethodTemplate(MethodInfo method, string objectName) {
            if(method == null) return string.Empty;
            ParameterInfo[] parameters = method.GetParameters();
            if(parameters == null || parameters.Length == 0)
                return objectName + "." + method.Name + "();" + Environment.NewLine;
            if(parameters.Length == 1)
                return objectName + "." + method.Name + "(this);" + Environment.NewLine;
            return string.Empty;
        }
        string GetCreateMethodTemplate(string name, string classType) {
            if(!ParameterIsValid(name)) return string.Empty;
            return name + " = new " + classType + "();" + Environment.NewLine;
        }
        string GetSubscriptionEventTemplate(EventInfo completed, string name, bool unsubscribe = false) {
            if(!ParameterIsValid(name)) return string.Empty;
            if(completed == null) return string.Empty;
            return name + "." + completed.Name + (unsubscribe ? "-" : "+") + "= OnTestCompleted;" + Environment.NewLine;
        }
        string GetInitializeTemplate(TypeLoader typeLoader) {
            return
                GetCreateMethodTemplate(CommonConstants.TestObject, typeLoader.Class.FullName) +
                (Manual ?
                GetSubscriptionEventTemplate(typeLoader.Completed, CommonConstants.TestObject) +
                GetSubscriptionEventTemplate(typeLoader.Ready, CommonConstants.TestObject) :
                string.Empty);
        }
        string GetTextForm(TestLoader testLoader) {
            return "this.Text = \"" + testLoader.FullName + "\";" + Environment.NewLine;
        }
        string GetDisposeTemplate(TypeLoader typeLoader) {
            return
                (Manual ?
                GetSubscriptionEventTemplate(typeLoader.Completed, CommonConstants.TestObject, true) +
                GetSubscriptionEventTemplate(typeLoader.Ready, CommonConstants.TestObject, true) :
                string.Empty) +
                GetCallMethodTemplate(typeLoader.TearDown, CommonConstants.TestObject) +
                CommonConstants.TestObject + " = null;";
        }
        string GetFieldTemplate(Type classType) {
            return classType.FullName + " " + CommonConstants.TestObject + ";" + Environment.NewLine;
        }
        string ParseString(string line, TestLoader testLoader, TypeLoader typeLoader) {
            switch(GetFormat(line)) {
                case TemplateFormat.None:
                    return string.Empty;
                case TemplateFormat.Using:
                    return GetUsingTemplate(null);
                case TemplateFormat.Field:
                    return GetFieldTemplate(typeLoader.Class);
                case TemplateFormat.Initialize:
                    return GetInitializeTemplate(typeLoader) +
                        GetTextForm(testLoader);
                case TemplateFormat.Test:
                    return GetCallMethodTemplate(testLoader.Test, CommonConstants.TestObject);
                case TemplateFormat.SetUp:
                    return GetCallMethodTemplate(typeLoader.SetUp, CommonConstants.TestObject);
                case TemplateFormat.TearDown:
                    return GetCallMethodTemplate(typeLoader.TearDown, CommonConstants.TestObject);
                case TemplateFormat.Dispose:
                    return GetDisposeTemplate(typeLoader);
                default:
                    return line + Environment.NewLine;
            }
        }
        TemplateFormat GetFormat(string line) {
            if(line.EndsWith(ReplaceParams.Using)) return TemplateFormat.Using;
            if(line.EndsWith(ReplaceParams.Field)) return TemplateFormat.Field;
            if(line.EndsWith(ReplaceParams.Initialize)) return TemplateFormat.Initialize;
            if(line.EndsWith(ReplaceParams.Test)) return TemplateFormat.Test;
            if(line.EndsWith(ReplaceParams.SetUp)) return TemplateFormat.SetUp;
            if(line.EndsWith(ReplaceParams.TearDown)) return TemplateFormat.TearDown;
            if(line.EndsWith(ReplaceParams.Dispose)) return TemplateFormat.Dispose;
            return TemplateFormat.Default;
        }
        public static void Build(TestLoader testLoader, TypeLoader typeLoader) {
            new TestBuilder(testLoader.ManualMode).BuildCore(testLoader, typeLoader);
        }
        void BuildCore(TestLoader testLoader, TypeLoader typeLoader) {
            string buffer = string.Empty;
            string fileName = Manual ? ResourceNames.ManualTestFile : ResourceNames.TestFile;
            fileName = ResourceNames.GetResourceName(ResourceNames.TestFolder + fileName);
            using(StreamReader reader = ResourceHelper.CreateStreamReader(typeof(TestBuilder), fileName)) {
                if(reader == null) return;
                while(!reader.EndOfStream) {
                    string str = ParseString(reader.ReadLine(), testLoader, typeLoader);
                    if(!string.IsNullOrEmpty(str))
                        buffer += str;
                }
            }
            testLoader.Template = buffer;
        }
    }
    enum TemplateFormat { Default, Using, Field, Initialize, SetUp, Test, TearDown, Dispose, None }
}