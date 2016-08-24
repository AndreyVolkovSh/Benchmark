using System;
using System.Diagnostics;
using System.IO;

namespace Benchmark.Internal {
    class SolutionBuilder : IDisposable {
        bool isDisposingCore;
        public SolutionBuilder() { }
        public static void BuildAll(string path, string buildSettings, bool proj = false) {
            string[] solutions = GetAllFiles(path, proj);
            if(solutions == null || solutions.Length == 0)
                throw (new Exception());
            using(SolutionBuilder build = new SolutionBuilder()) {
                foreach(string solution in solutions)
                    build.Build(solution, buildSettings);
            }
        }
        public void Build(string solutionPath, string buildSettings) {
            using(Process build = new Process()) {
                build.EnableRaisingEvents = true;
                build.StartInfo.Arguments = solutionPath + " " + buildSettings;
                build.StartInfo.FileName = Constants.BuildBat;
                build.Start();
                build.WaitForExit();
            }
        }
        public static string[] GetAllFiles(string path, bool proj) {
            string filter = proj ? "*.*proj" : "*sln";
            if(Directory.Exists(path))
                return Directory.GetFiles(path, filter, SearchOption.AllDirectories);
            return null;
        }
        #region IDisposable Members
        public void Dispose() {
            if(isDisposingCore) return;
            isDisposingCore = true;
            OnDispose();
        }
        protected virtual void OnDispose() {

        }
        #endregion
    }
}