using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Benchmark.Internal {
    class CodeDomContext : IDisposable {
        CodeDomProvider providerCore;
        CompilerParameters parametersCore;
        public CodeDomContext() {
            BenchmarkLog.Create();
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
            parametersCore.MainClass = Constants.MainClass;
            parametersCore.CompilerOptions = Constants.CompilerOptions;
            parametersCore.GenerateInMemory = false;
            parametersCore.GenerateExecutable = true;
            parametersCore.ReferencedAssemblies.Add(Constants.SystemDll);
            parametersCore.ReferencedAssemblies.Add(Constants.WindowsFormsDll);
            parametersCore.ReferencedAssemblies.Add(Constants.DrawingDll);
            parametersCore.ReferencedAssemblies.Add(Constants.BenchmarkCoreDll);
        }
        public List<BenchmarkLogEntry> StartTest(string template, string test) {
            string exe = test + Constants.EXE;
            string config = exe + Constants.Config;
            parametersCore.OutputAssembly = exe;
            CompilerResults res = providerCore.CompileAssemblyFromSource(parametersCore, template);
            if(res.NativeCompilerReturnValue == 0) {
                File.WriteAllText(config, TemplateData.Settings);
                using(NGenContext nGen = new NGenContext(exe))
                    ProcessStart(exe);
                DeleteFile(config);
            }
            else {
                //log exception 
                throw (new Exception());
            }
            DeleteFile(exe);
            return BenchmarkLog.GetResults();
        }
        void DeleteFile(string fullName) {
            if(File.Exists(fullName))
                File.Delete(fullName);
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
}