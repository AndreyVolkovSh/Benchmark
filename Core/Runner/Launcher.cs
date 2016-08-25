using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Benchmark.Internal;

namespace Benchmark.Runner {
    public class Launcher {
        public static void BuildSolutions(string settings) {
            string rootPath = GetRootPath();
            BuildSolutions(rootPath, settings);
        }
        public static List<TestResult> Start(Settings settings, IEnumerable<TestInfo> tests) {
            try {
                List<TestResult> results = new List<TestResult>();
                using(ProjectCompiler compiler = ProjectCompiler.Compile(tests, settings)) {
                    foreach(TestInfo test in tests) {
                        if(!File.Exists(test.Path)) continue;
                        results.Add(StartTest(test));
                    }
                    return results;
                }
            }
            catch(Exception ee) {
                throw (ee);
            }
        }
        //public static List<TestResult> Start(string[] args) {
        //    // assemblies; categories;
        //    return Start(Settings.Create(args));
        //}
        //static List<TestResult> StartTests(string assembly) {
        //    AssemblyLoader assemblyInfo = AssemblyLoader.Load(assembly);
        //    if(assemblyInfo == null)
        //        throw (new Exception());
        //    List<TestResult> results = new List<TestResult>();
        //    List<TestInfo> tests = ProjectCompiler.Compile(assemblyInfo, null);
        //    using(NGenContext nGen = new NGenContext(true)) {
        //        nGen.PlatformTarget_x64 = false;
        //        nGen.Install(assembly);
        //        foreach(TestInfo test in tests) {
        //            nGen.Install(test.TestEXE);
        //            results.Add(StartTest(test));
        //        }
        //    }
        //    return results;
        //}
        static TestResult StartTest(TestInfo test) {
            BenchmarkLog.Clear();
            ProcessStart(test.Path);
            List<BenchmarkLogEntry> logs = BenchmarkLog.GetResults();
            TestResult result = ConvetToResult(logs);
            result.TestName = test.Name;
            result.Category = test.Category;
            result.Vender = test.Vender;
            result.Product = test.Product;
            return result;
        }
        static void ProcessStart(string fileName) {
            using(Process process = new Process()) {
                process.StartInfo.FileName = fileName;
                process.Start();
                process.WaitForExit();
            }
        }
        static TestResult ConvetToResult(List<BenchmarkLogEntry> logs) {
            TestResult result = new TestResult();
            if(logs == null || logs.Count == 0) return result;
            result.FirstPerfomance = logs[0].Perfomance;
            logs.Sort(new BenchmarkLogEntryComparer());
            result.BestPerfomance = logs[0].Perfomance;
            int median = logs.Count / 2;
            result.MedianPerfomance = CalcMedianPerfomance(logs);
            result.BadPerfomance = logs[logs.Count - 1].Perfomance;
            return result;
        }
        static double CalcMedianPerfomance(IList<BenchmarkLogEntry> logs) {
            int median = logs.Count / 2;
            if(logs.Count % 2 == 0)
                return (logs[median].Perfomance + logs[median + 1].Perfomance) / 2;
            return logs[median].Perfomance;
        }
        static string GetSolutionsPath(string rootPath) {
            return String.Format(Constants.TestsPathFormat, rootPath);
        }
        static string GetRootPath() {
            return Path.GetDirectoryName(Application.StartupPath);
        }
        static void BuildSolutions(string rootPath, string settings) {
            string solutionsPath = GetSolutionsPath(rootPath);
            try {
                Benchmark.Internal.SolutionBuilder.BuildSolutions(solutionsPath, settings);
            }
            catch(Exception exception) {
                //log exception  
                throw (exception);
            }
        }
    }
}