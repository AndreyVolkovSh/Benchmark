﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Benchmark.Common;
using Benchmark.Internal;

namespace Benchmark.Runner {
    public class Launcher {
        public static List<TestResult> Start(Settings settings, IEnumerable<TestLoader> tests) {
            try {
                List<TestResult> results = new List<TestResult>();
                BenchmarkLog.Create();
                using(ProjectCompiler compiler = ProjectCompiler.Compile(tests, settings)) {
                    foreach(TestLoader test in tests) {
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
        static TestResult StartTest(TestLoader test) {
            BenchmarkLog.Clear();
            ProcessStart(test.Path);
            List<BenchmarkLogEntry> logs = BenchmarkLog.GetResults();
            TestResult result = ConvetToResult(logs);
            result.TestName = test.Name;
            result.Category = test.Category;
            result.Scope = test.Scope;
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
            result.MedianPerfomance = logs[logs.Count - 1].Perfomance;
            result.BadPerfomance = logs[logs.Count - 2].Perfomance;
            return result;
        }
        static string GetTestsPath(string rootPath) {
            return String.Format(Formats.TestsPath, rootPath);
        }
        static string GetRootPath() {
            return Path.GetDirectoryName(Application.StartupPath);
        }
        public static string GetTestsPath() {
            string rootPath = GetRootPath();
            return GetTestsPath(rootPath);
        }
        public static void BuildSolutions(Settings settings) {
            string solutionsPath = GetTestsPath();
            try {
                Benchmark.Internal.SolutionBuilder.BuildSolutions(solutionsPath, settings.ToBuild());
            }
            catch(Exception exception) {
                //log exception  
                throw (exception);
            }
        }
    }
}