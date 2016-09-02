using System;
using System.IO;
using System.Reflection;

namespace Benchmark.Internal {
    class TemplateGenerator {
        static TemplateGenerator defaultCore;
        protected TemplateGenerator() { }
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
                GetCreateMethodTemplate(Constants.TestObject, typeLoader.Class.FullName) +
                (Manual ?
                GetSubscriptionEventTemplate(typeLoader.Completed, Constants.TestObject) +
                GetSubscriptionEventTemplate(typeLoader.Ready, Constants.TestObject) :
                string.Empty);
        }
        string GetDisposeTemplate(TypeLoader typeLoader) {
            return
                (Manual ?
                GetSubscriptionEventTemplate(typeLoader.Completed, Constants.TestObject, true) +
                GetSubscriptionEventTemplate(typeLoader.Ready, Constants.TestObject, true) :
                string.Empty) +
                GetCallMethodTemplate(typeLoader.TearDown, Constants.TestObject) +
                Constants.TestObject + " = null;";
        }
        string GetFieldTemplate(Type classType) {
            return classType.FullName + " " + Constants.TestObject + ";" + Environment.NewLine;
        }
        string ParseString(string line, MethodInfo test, TypeLoader typeLoader) {
            switch(GetFormat(line)) {
                case TemplateFormat.None:
                    return string.Empty;
                case TemplateFormat.Using:
                    return GetUsingTemplate(null);
                case TemplateFormat.Field:
                    return GetFieldTemplate(typeLoader.Class);
                case TemplateFormat.Initialize:
                    return GetInitializeTemplate(typeLoader);
                case TemplateFormat.Start:
                    return GetCallMethodTemplate(test, Constants.TestObject);
                case TemplateFormat.SetUp:
                    return GetCallMethodTemplate(typeLoader.SetUp, Constants.TestObject);
                case TemplateFormat.TearDown:
                    return GetCallMethodTemplate(typeLoader.TearDown, Constants.TestObject);
                case TemplateFormat.Dispose:
                    return GetDisposeTemplate(typeLoader);
                default:
                    return line + Environment.NewLine;
            }
        }
        TemplateFormat GetFormat(string line) {
            if(line == "/*" || line == "*/") return TemplateFormat.None;
            if(line.EndsWith("{0};")) return TemplateFormat.Using;
            if(line.EndsWith("{1};")) return TemplateFormat.Field;
            if(line.EndsWith("{2};")) return TemplateFormat.Initialize;
            if(line.EndsWith("{3};")) return TemplateFormat.Start;
            if(line.EndsWith("{4};")) return TemplateFormat.SetUp;
            if(line.EndsWith("{5};")) return TemplateFormat.TearDown;
            if(line.EndsWith("{6};")) return TemplateFormat.Dispose;
            return TemplateFormat.Default;
        }
        public string CreateTemplate(MethodInfo test, TypeLoader typeLoader, bool manual = false) {
            try {
                Manual = manual;
                return CreateTemplateCore(test, typeLoader);
            }
            finally {
                Manual = false;
            }
        }
        string CreateTemplateCore(MethodInfo test, TypeLoader typeLoader) {
            string buffer = string.Empty;
            string fileName = Manual ? Constants.TemplateManualFile : Constants.TemplateFile;
            using(StreamReader reader = ResourceHelper.CreateStreamReader(fileName)) {
                if(reader == null) return buffer;
                while(!reader.EndOfStream) {
                    string str = ParseString(reader.ReadLine(), test, typeLoader);
                    if(!string.IsNullOrEmpty(str))
                        buffer += str;
                }
            }
            return buffer;
        }
        public static TemplateGenerator Default {
            get {
                if(defaultCore == null)
                    defaultCore = new TemplateGenerator();
                return defaultCore;
            }
        }
    }
    enum TemplateFormat { Default, Using, Field, Initialize, SetUp, Start, TearDown, Dispose, None }
}