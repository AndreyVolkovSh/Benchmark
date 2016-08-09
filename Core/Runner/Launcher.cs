using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Benchmark.Internal;

namespace Benchmark.Runner {
    public class Launcher {
        public static List<TestResult> Start(string[] args) {
            try {
                string rootPath = GetRootPath();
                BuildSolutions(rootPath);
                List<TestResult> results = new List<TestResult>();
                foreach(RegistratorEntry entry in Registrator.Current.GetEntries()) {
                    if(!File.Exists(entry.Assembly))
                        continue;
                    List<TestResult> tempResults = StartTests(entry.Assembly);
                    foreach(TestResult result in tempResults) {
                        result.Rival = entry.Rival;
                        result.Product = entry.Product;
                        results.Add(result);
                    }
                }
                return results;
            }
            catch(Exception ee) {
                throw (ee);
            }
        }
        static List<TestResult> StartTests(string assembly) {
            AssemblyData data = AssemblyData.Load(assembly);
            if(data == null)
                throw (new Exception());
            List<TestResult> results = new List<TestResult>();
            using(CodeDomContext context = new CodeDomContext()) {
                context.LoadAssembly(assembly);
                foreach(TemplateData templateData in data.Templates)
                    results.AddRange(StartTests(context, templateData));
            }
            return results;
        }
        static List<TestResult> StartTests(CodeDomContext context, TemplateData templateData) {
            List<TestResult> results = new List<TestResult>();
            foreach(string template in templateData) {
                BenchmarkLog.Clear();
                string currentTest = templateData.CurrentTestName;
                List<BenchmarkLogEntry> logs = context.StartTest(template, currentTest);
                TestResult result = ConvetToResult(logs, currentTest, templateData.Class.Name);
                results.Add(result);
            }
            return results;
        }
        static TestResult ConvetToResult(List<BenchmarkLogEntry> logs, string testName, string category) {
            TestResult result = new TestResult(testName, category);
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
        static void BuildSolutions(string rootPath) {
            string solutionsPath = GetSolutionsPath(rootPath);
            try {
                SolutionBuilder.BuildAll(solutionsPath);
            }
            catch(Exception exception) {
                //log exception  
                throw (exception);
            }
        }
    }
}