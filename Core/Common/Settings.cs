using System.Collections.Generic;
using Microsoft.Win32;
using System.Linq;

namespace Benchmark.Common {
    public enum Platform { AnyCPU, x86, x64 }
    public class Settings {
        static Frameworks frameworksCore;
        static ToolVersions toolVersions;
        public Settings() {
            Thread = 2;
            Platform = Platform.AnyCPU;
            EnableNGen = true;
            Framework = Frameworks[0];
            ToolVersion = ToolVersions[0];
        }
        public virtual int Thread {
            get;
            set;
        }
        public virtual Platform Platform {
            get;
            set;
        }
        public virtual Framework Framework {
            get;
            set;
        }
        public virtual string ToolVersion {
            get;
            set;
        }
        public virtual bool EnableNGen {
            get;
            set;
        }
        public string ToBuild() {
            return string.Format(Formats.Args, Thread, Framework.Version, ToolVersion);
        }
        public static ToolVersions ToolVersions {
            get {
                if(toolVersions == null)
                    toolVersions = new ToolVersions();
                return toolVersions;
            }
        }
        public static Frameworks Frameworks {
            get {
                if(frameworksCore == null)
                    frameworksCore = new Frameworks();
                return frameworksCore;
            }
        }
    }
    public class ToolVersions : IEnumerable<string> {
        List<string> toolVersions;
        public ToolVersions() {
            InitializeToolVersions();
        }
        void InitializeToolVersions() {
            string keyName = RegisterKeys.ToolVersion;
            toolVersions = new List<string>();
            string[] tools = new string[] { "4.0", "12.0", "14.0" };
            using(RegistryKey MSBuild = Registry.LocalMachine.OpenSubKey(keyName)) {
                if(MSBuild == null) return;
                foreach(string tool in tools) {
                    using(RegistryKey toolKey = MSBuild.OpenSubKey(tool))
                        if(toolKey != null)
                            toolVersions.Add(tool);
                }
            }
        }
        public string this[int index] {
            get {
                if(toolVersions.Count > 0)
                    return toolVersions[0];
                return null;
            }
        }
        public bool Contains(string value) {
            return toolVersions.Contains(value);
        }
        #region IEnumerable<string> Members
        public IEnumerator<string> GetEnumerator() {
            return toolVersions.GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
        #endregion
    }
    public class Frameworks : IEnumerable<Framework> {
        List<Framework> frameworksCore;
        public Frameworks() {
            frameworksCore = new List<Framework>();
            frameworksCore.Add(new Framework() { Version = "v4.0", Release = 0 });
            frameworksCore.Add(new Framework() { Version = "v4.5", Release = 378389 });
            frameworksCore.Add(new Framework() { Version = "v4.5.1", Release = 378675 });
            frameworksCore.Add(new Framework() { Version = "v4.5.2", Release = 379893 });
            frameworksCore.Add(new Framework() { Version = "v4.6", Release = 393295 });
            frameworksCore.Add(new Framework() { Version = "v4.6.1", Release = 394254 });
            FilterVersion();
        }
        int GetLastVersion() {
            string keyName = RegisterKeys.Framework;
            using(RegistryKey ndpKey = Registry.LocalMachine.OpenSubKey(keyName)) {
                if(ndpKey == null) return -1;
                using(RegistryKey full = ndpKey.OpenSubKey("Full\\")) {
                    if(full != null) {
                        object release = full.GetValue("Release");
                        if(release != null) return (int)release;
                    }
                }
                return 0;
            }
        }
        void FilterVersion() {
            int lastVersion = GetLastVersion();
            frameworksCore.RemoveAll((x) => x.Release > lastVersion);
        }
        public Framework this[string version] {
            get {
                IEnumerable<Framework> frameworks = frameworksCore.Where((x) => x.Version == version);
                if(frameworks == null || frameworks.Count() == 0)
                    return null;
                return frameworks.First();
            }
        }
        public Framework this[int index] {
            get {
                if(frameworksCore.Count > 0)
                    return frameworksCore[0];
                return null;
            }
        }
        #region IEnumerable<Framework> Members
        public IEnumerator<Framework> GetEnumerator() {
            return frameworksCore.GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
        #endregion
    }
    public class Framework {
        public string Version {
            get;
            set;
        }
        public int Release {
            get;
            set;
        }
        public string Name {
            get { return "Framework " + Version; }
        }
        public override string ToString() {
            return Name;
        }
    }
}