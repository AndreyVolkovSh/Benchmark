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
        RivalResults RunTests(string assembly, string rivalName) {
            RivalResults rival = new RivalResults(rivalName);
            AssemblyData data = AssemblyData.Load(assembly);
            if(data == null)
                throw (new Exception());
            using(CodeDomContext context = new CodeDomContext()) {
                context.LoadAssembly(assembly);
                foreach(TemplateData templateData in data.Templates)
                    rival.AddRange(RunTests(context, templateData));
            }
            return rival;
        }
        List<TestResults> RunTests(CodeDomContext context, TemplateData templateData) {
            List<TestResults> results = new List<TestResults>();
            foreach(string template in templateData) {
                ProfilerLog.Clear();
                string currentTest = templateData.CurrentTestName;
                List<ProfilerLogEntry> logs = context.RunTest(template, currentTest);
                TestResults result = ConvetToResult(logs, currentTest);
                results.Add(result);
            }
            return results;
        }        
        TestResults ConvetToResult(List<ProfilerLogEntry> logs, string testName) {
            TestResults result = new TestResults(testName);
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
        bool CheckAssembly(string assembly) {
            string fileName = Path.GetFileName(assembly);
            return fileName == "Grid_Telerik.dll";
        }
        void Run(object sender, EventArgs e) {
            try {
                string rootPath = GetRootPath();
                BuildSolutions(rootPath);
                string assemblyPath = rootPath + "\\Bin\\Assembly_Tests";
                if(!Directory.Exists(assemblyPath))
                    throw (new Exception());
                string[] assemblies = Directory.GetFiles(assemblyPath, "*.dll", SearchOption.AllDirectories);
                if(assemblies == null || assemblies.Length == 0)
                    throw (new Exception());
                ProductResults product = new ProductResults("Grid");
                foreach(string assembly in assemblies) {
                    if(!CheckAssembly(assembly)) continue;
                    if(!File.Exists(assembly))
                        throw (new Exception());
                    product.Add(RunTests(assembly, "Telerik"));
                }
                gridControl1.DataSource = product["Telerik"].Results;
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

    public class BaseResults {
        public BaseResults(string name) {
            Name = name;
        }
        public string Name {
            get;
            private set;
        }
    }
    public class BaseResults<T> : BaseResults where T : BaseResults {
        Dictionary<string, T> resultsCore;
        public BaseResults(string name)
            : base(name) {
            resultsCore = new Dictionary<string, T>();
        }
        public void Add(T result) {
            if(resultsCore.ContainsKey(result.Name))
                resultsCore[result.Name] = result;
            else
                resultsCore.Add(result.Name, result);
        }
        public void AddRange(IEnumerable<T> results) {
            if(results == null) return;
            foreach(T result in results)
                Add(result);
        }
        public T this[string name] {
            get {
                T value;
                resultsCore.TryGetValue(name, out value);
                return value;
            }
        }
        public IEnumerable<T> Results {
            get { return resultsCore.Values; }
        }
    }
    public class ProductResults : BaseResults<RivalResults> {
        public ProductResults(string name) : base(name) { }
    }
    public class TestResults : BaseResults {
        public TestResults(string name) : base(name) { }
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
    }
    public class RivalResults : BaseResults<TestResults> {
        public RivalResults(string name) : base(name) { }
    }
}