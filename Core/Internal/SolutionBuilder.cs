using System;
using System.Diagnostics;
using System.IO;
using Benchmark.Common;

namespace Benchmark.Internal {
    class SolutionBuilder {
        public SolutionBuilder() { }
        public static void BuildSolutions(string path, string buildSettings) {
            BuildAll(GetAllFiles(path, "*" + Resolution.SLN), buildSettings);
        }
        public static void BuildProjects(string path, string buildSettings) {
            BuildAll(GetAllFiles(path, Resolution.ALLProj), buildSettings);
        }
        static void BuildAll(string[] all, string buildSettings) {
            if(all == null || all.Length == 0)
                throw (new Exception());
            TaskManager.Current.RunTasks(all, (x) => Build(x, buildSettings));
        }
        public static void Build(string solutionPath, string buildSettings) {
            using(Process build = new Process()) {
                build.EnableRaisingEvents = true;
                build.StartInfo.Arguments = solutionPath + " " + buildSettings;
                build.StartInfo.FileName = CommonConstants.BuildBat;
                build.Start();
                build.WaitForExit();
            }
        }
        public static string[] GetAllFiles(string path, string filter) {
            if(Directory.Exists(path))
                return Directory.GetFiles(path, filter, SearchOption.AllDirectories);
            return null;
        }
    }
}