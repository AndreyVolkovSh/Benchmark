using System;
using System.Collections.Generic;
using System.Diagnostics;
using Benchmark.Common;

namespace Benchmark.Internal {
    class NGenContext : IDisposable {
        HashSet<string> cache;
        public NGenContext() : this(Platform.AnyCPU) { }
        public NGenContext(Platform platform) {
            cache = new HashSet<string>();
            PlatformTarget_x64 = platform == Platform.x64;
        }
        void StartNGen(string command, string filePath) {
            using(Process process = new Process()) {
                string file = GetFullPath();
                if(System.IO.File.Exists(file)) {
                    process.StartInfo.FileName = file;
                    process.StartInfo.Arguments = command + " " + filePath;
                    process.Start();
                    process.WaitForExit();
                }
            }
        }
        public void Install(string filePath) {
            if(cache.Contains(filePath)) return;
            cache.Add(filePath);
            StartNGen(Commands.NGetInstall, filePath);
        }
        public void Unstall(string filePath) {
            if(!cache.Contains(filePath)) return;
            cache.Remove(filePath);
            StartNGen(Commands.NGenUninstall, filePath);
        }
        protected string GetFullPath() {
            string platform = PlatformTarget_x64 ? "x64" : "x86";
            return string.Format(Formats.NGenPath, platform);
        }
        bool PlatformTarget_x64 {
            get;
            set;
        }
        #region IDisposable Members
        bool isDisposing;
        public void Dispose() {
            if(isDisposing) return;
            isDisposing = true;
            foreach(string value in cache)
                StartNGen(Commands.NGenUninstall, value);
            cache.Clear();
        }
        #endregion
    }
}