using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32;

namespace Benchmark {
    public enum Platform { AnyCPU, x86, x64 }
    public class Settings {
        Frameworks frameworksCore;
        List<string> toolVersions;
        public Settings(string[] args)
            : base() {
        }
        public Settings() {
            frameworksCore = CreateFrameworks();
            toolVersions = CreateToolVersions();
            Thread = 2;
            Platform = Platform.AnyCPU;
            EnableNGen = true;
            Framework = frameworksCore.First;
            Rebuild = false;
            if(toolVersions.Count > 0)
                ToolVersion = toolVersions[0];
        }
        public virtual bool Rebuild {
            get;
            set;
        }
        public string[] Products {
            get;
            set;
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
        public string ToBuildSettings() {
            return string.Format("{0} {1} {2}", Thread, Framework.Version, ToolVersion);
        }
        public List<string> GetToolVersions() {
            return toolVersions;
        }
        public IEnumerable<Framework> GetFrameworks() {
            return frameworksCore.Items;
        }
        Frameworks CreateFrameworks() {
            return new Frameworks();
        }
        List<string> CreateToolVersions() {
            string keyName = Constants.ToolVersionKey;
            List<string> versions = new List<string>();
            string[] tools = new string[] { "4.0", "12.0", "14.0" };
            using(RegistryKey MSBuild = Registry.LocalMachine.OpenSubKey(keyName)) {
                if(MSBuild == null) return versions;
                foreach(string tool in tools) {
                    using(RegistryKey toolKey = MSBuild.OpenSubKey(tool))
                        if(toolKey != null)
                            versions.Add(tool);
                }
            }
            return versions;
        }
        public static Settings Create(string[] args) {
            return new Settings();
        }
    }
    class Frameworks {
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
            string keyName = Constants.FrameworkKey;
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
        public Framework First {
            get {
                if(frameworksCore.Count > 0) return frameworksCore[0];
                return null;
            }
        }
        public IEnumerable<Framework> Items {
            get { return frameworksCore; }
        }
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