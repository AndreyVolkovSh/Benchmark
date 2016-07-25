using System.Collections;
using System.Collections.Generic;

namespace Benchmark {
    public class TestApplicationSettings {
        Hashtable settings;
        public TestApplicationSettings() {
            settings = new Hashtable();
        }
        public static TestApplicationSettings GetSettings(string[] args) {
            TestApplicationSettings arguments = new TestApplicationSettings();
            if(args != null) {
                arguments.Initialize(args);
            }
            return arguments;
        }
        protected void Initialize(string[] args) {
            if(args == null) return;
            foreach(string arg in args) {
                string[] _params = arg.Split(';');
                if(_params == null || _params.Length <= 1) continue;
                settings.Add(_params[0], _params[1]);
            }
        }
        protected void SetValue<T>(string setting, T value) {
            if(settings.ContainsKey(setting))
                settings[setting] = value;
            else
                settings.Add(setting, value);
        }
        protected T GetValue<T>(string setting) {
            if(!settings.ContainsKey(setting)) return default(T);
            return (T)settings[setting];
        }
        public string[] ToArgs() {
            if(settings == null) return null;
            List<string> args = new List<string>();
            foreach(IDictionaryEnumerator setting in settings) {
                string arg = setting.Key + ":" + setting.Value;
                args.Add(arg);
            }
            return args.ToArray();
        }
    }
}