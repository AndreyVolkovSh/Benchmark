using System;
using System.Diagnostics;

namespace Profiler.Runner {
    public class NGenContext : IDisposable {
        string fileNameCore;
        public NGenContext(string fileName) {
            fileNameCore = fileName;
            StartNGen(Constants.NGetInstall);
        }
        void StartNGen(string command) {
            using(Process process = new Process()) {
                string file = GetFullPath();
                if(System.IO.File.Exists(file)) {
                    process.StartInfo.FileName = file;
                    process.StartInfo.Arguments = command + " " + fileNameCore;
                    process.Start();
                    process.WaitForExit();
                }
            }
        }
        protected string GetFullPath() {
            string platform = PlatformTarget_x64 ? Constants.x64 : Constants.x86;
            return string.IsNullOrEmpty(FullPath) ?
                    string.Format(Constants.NGenFormat, platform) :
                    FullPath;
        }
        public string FullPath {
            get;
            set;
        }
        public bool PlatformTarget_x64 {
            get;
            set;
        }
        #region IDisposable Members
        void IDisposable.Dispose() {
            StartNGen(Constants.NGenUninstall);
        }
        #endregion
    }
}