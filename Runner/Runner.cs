using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Profiler;
using Profiler.Runner;

namespace PerformanceComparison_Win {
    public partial class Runner : Form {
        public Runner() {
            InitializeComponent();
        }
        string GetSolutionsPath(string rootPath) {
            return String.Format("{0}\\Tests\\", rootPath);
        }
        string GetRootPath() {
            string startupPath = Application.StartupPath;
            string nameSolution = this.GetType().Assembly.GetName().Name;
            int index = startupPath.IndexOf(nameSolution);
            if(index <= 0) return null;
            return startupPath.Substring(0, index + nameSolution.Length);
        }


        void BuildSolutions(string rootPath) {
            string solutionsPath = GetSolutionsPath(rootPath);
            try {
                SolutionBuilder.BuildAll(solutionsPath);
            }
            catch(Exception exception) {
                //log exception  
                throw (exception);
            }
        }
        List<TestResult> RunTests(string assembly) {
            AssemblyData data = AssemblyData.Load(assembly);
            if(data == null)
                throw (new Exception());
            List<TestResult> results = new List<TestResult>();
            using(CodeDomContext context = new CodeDomContext()) {
                context.LoadAssembly(assembly);
                foreach(TemplateData templateData in data.Templates)
                    results.AddRange(RunTests(context, templateData));
            }
            return results;
        }
        List<TestResult> RunTests(CodeDomContext context, TemplateData templateData) {
            List<TestResult> results = new List<TestResult>();
            foreach(string template in templateData) {
                ProfilerLog.Clear();
                string currentTest = templateData.CurrentTestName;
                List<ProfilerLogEntry> logs = context.RunTest(template, currentTest);
                TestResult result = ConvetToResult(logs, currentTest);
                results.Add(result);
            }
            return results;
        }
        TestResult ConvetToResult(List<ProfilerLogEntry> logs, string testName) {
            TestResult result = new TestResult(testName);
            if(logs == null || logs.Count == 0) return result;
            result.FirstPerfomance = logs[0].Perfomance;
            logs.Sort(new ProfilerLogEntryComparer());
            result.BestPerfomance = logs[0].Perfomance;
            int median = logs.Count / 2;
            if(logs.Count % 2 == 0) {
                result.MedianPerfomance = (logs[median].Perfomance + logs[median + 1].Perfomance) / 2;
            }
            else
                result.MedianPerfomance = logs[median].Perfomance;
            result.BadPerfomance = logs[logs.Count - 1].Perfomance;
            return result;
        }
        void Run(object sender, EventArgs e) {
            try {
                string rootPath = GetRootPath();
                BuildSolutions(rootPath);
                List<ResultEntry> entries = new List<ResultEntry>();
                foreach(DllInfo dllInfo in Registration.Current.Dlls()) {
                    if(!File.Exists(dllInfo.Dll))
                        continue;
                    List<TestResult> results = RunTests(dllInfo.Dll);
                    foreach(TestResult result in results) {
                        ResultEntry entry = new ResultEntry(dllInfo.Product, dllInfo.Rival);
                        entry.Assign(result);
                        entries.Add(entry);
                    }
                }
                gridControl1.DataSource = entries;
            }
            catch(Exception ee) {
                throw (ee);
            }
        }
    }
    public class CodeDomContext : IDisposable {
        CodeDomProvider providerCore;
        CompilerParameters parametersCore;
        public CodeDomContext() {
            ProfilerLog.Create();
            providerCore = CreateCodeDomProvider();
            CreateCompilerParameters();
        }
        CodeDomProvider CreateCodeDomProvider() {
            return new Microsoft.CSharp.CSharpCodeProvider();
        }
        public void LoadAssembly(string assembly) {
            parametersCore.ReferencedAssemblies.Add(assembly);
        }
        void CreateCompilerParameters() {
            parametersCore = new CompilerParameters();
            parametersCore.MainClass = "ProfilerTest.Program";
            parametersCore.CompilerOptions = " /target:winexe";
            parametersCore.GenerateInMemory = false;
            parametersCore.GenerateExecutable = true;
            parametersCore.ReferencedAssemblies.Add("System.dll");
            parametersCore.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            parametersCore.ReferencedAssemblies.Add("System.Drawing.dll");
            parametersCore.ReferencedAssemblies.Add("ProfilerCore.dll");
        }
        public List<ProfilerLogEntry> RunTest(string template, string test) {
            string exe = test + ".exe";
            parametersCore.OutputAssembly = exe;
            CompilerResults res = providerCore.CompileAssemblyFromSource(parametersCore, template);
            if(res.NativeCompilerReturnValue == 0) {
                File.WriteAllText(exe + ".config", TemplateData.Settings);
                using(NGenContext nGen = new NGenContext(exe))
                    ProcessStart(exe);
                File.Delete(exe + ".config");
            }
            else {
                //log exception
                throw (new Exception());
            }
            //File.Delete(exe);
            return ProfilerLog.GetResults();
        }
        Process CreateProcess() {
            Process process = new Process();
            return process;
        }
        void ProcessStart(string fileName) {
            using(Process process = new Process()) {
                process.StartInfo.FileName = fileName;
                process.Start();
                process.WaitForExit();
            }
        }
        #region IDisposable Members
        void IDisposable.Dispose() {
            if(providerCore != null) {
                providerCore.Dispose();
                providerCore = null;
            }
        }
        #endregion
    }

    public class TestResult {
        public TestResult(string testName) {
            TestName = testName;
        }
        public string TestName {
            get;
            private set;
        }
        public int FirstPerfomance {
            get;
            set;
        }
        public int BestPerfomance {
            get;
            set;
        }
        public int BadPerfomance {
            get;
            set;
        }
        public double MedianPerfomance {
            get;
            set;
        }
        public virtual void Assign(TestResult result) {
            this.TestName = result.TestName;
            this.BadPerfomance = result.BadPerfomance;
            this.BestPerfomance = result.BestPerfomance;
            this.FirstPerfomance = result.FirstPerfomance;
            this.MedianPerfomance = result.MedianPerfomance;
        }
    }
    public class ResultEntry : TestResult {
        public ResultEntry(string product, string rival)
            : base(string.Empty) {
            Product = product;
            Rival = rival;
        }
        public string Product {
            get;
            private set;
        }
        public string Rival {
            get;
            private set;
        }
    }
}