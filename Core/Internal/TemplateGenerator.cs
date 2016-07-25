using System;
using System.IO;
using System.Reflection;

namespace Benchmark.Internal {
    class TemplateGenerator {
        static TemplateGenerator defaultCore;
        string settingsTemplateCore;
        protected TemplateGenerator() {
            settingsTemplateCore = CreateSettingsTemplate();
        }
        string CreateSettingsTemplate() {
            using(StreamReader reader = CreateStreamReader(Constants.SettingsFile))
                return reader.ReadToEnd();
        }
        StreamReader CreateStreamReader(string resourcePath) {
            Stream stream = ResourceStreamHelper.GetStream(resourcePath, typeof(TemplateGenerator).Assembly);
            if(stream == null) return null;
            return new StreamReader(stream);
        }
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
        string GetInitializeTemplate(Type classTest, EventInfo completed) {
            return
                GetCreateMethodTemplate(Constants.TestObject, classTest.FullName) +
                GetSubscriptionEventTemplate(completed, Constants.TestObject);
        }
        string GetDisposeTemplate(MethodInfo tearDown, EventInfo completed) {
            return
                GetSubscriptionEventTemplate(completed, Constants.TestObject, true) +
                GetCallMethodTemplate(tearDown, Constants.TestObject) +
                Constants.TestObject + " = null;";
        }
        string GetFieldTemplate(Type classType) {
            return classType.FullName + " " + Constants.TestObject + ";" + Environment.NewLine;
        }
        string ParseString(string line, Type classType, MethodInfo test, MethodInfo setUp, MethodInfo tearDown, EventInfo completed) {
            switch(GetFormat(line)) {
                case TemplateFormat.None:
                    return string.Empty;
                case TemplateFormat.Using:
                    return GetUsingTemplate(null);
                case TemplateFormat.Field:
                    return GetFieldTemplate(classType);
                case TemplateFormat.Initialize:
                    return GetInitializeTemplate(classType, completed);
                case TemplateFormat.Start:
                    return GetCallMethodTemplate(test, Constants.TestObject);
                case TemplateFormat.SetUp:
                    return GetCallMethodTemplate(setUp, Constants.TestObject);
                case TemplateFormat.TearDown:
                    return GetCallMethodTemplate(tearDown, Constants.TestObject);
                case TemplateFormat.Dispose:
                    return GetDisposeTemplate(tearDown, completed);
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
        public string CreateTemplate(Type classType, MethodInfo test, MethodInfo setUp, MethodInfo tearDown, EventInfo completed) {
            string buffer = string.Empty;
            using(StreamReader reader = CreateStreamReader(Constants.TemplateFile)) {
                if(reader == null) return buffer;
                while(!reader.EndOfStream) {
                    string str = ParseString(reader.ReadLine(), classType, test, setUp, tearDown, completed);
                    if(!string.IsNullOrEmpty(str))
                        buffer += str;
                }
            }
            return buffer;
        }
        public string SettingsTemplate {
            get { return settingsTemplateCore; }
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