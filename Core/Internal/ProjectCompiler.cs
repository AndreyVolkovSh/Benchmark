using System;
using System.Collections.Generic;
using System.IO;

namespace Benchmark.Internal {
    class ProjectCompiler : IDisposable {
        static string projectTemlateCore, projectTemlate_UserCore;
        void Compile(IEnumerable<TestInfo> tests) {
            if(tests == null) return;
            foreach(TestInfo test in tests)
                Compile(test);
        }
        DirectoryInfo GetFolder(string path) {
            DirectoryInfo folder = new DirectoryInfo(path);
            if(!folder.Exists)
                folder.Create();
            return folder;
        }
        void Compile(TestInfo test) {
            try {
                DirectoryInfo tempFolder = GetFolder(Constants.TempFolder);
                string testFullName = test.FullName;
                DirectoryInfo projectFolder = GetFolder(Constants.TempFolder + testFullName);
                PatchProject(projectFolder.FullName, test);
            }
            catch {
                //log
            }
        }
        void PatchProject(string path, TestInfo test) {
            string fullName = test.FullName;
            string projectTemplate = ProjectTemlate.Replace("{0}", fullName)
                .Replace("{1}", test.AssemblyName)
                .Replace("{2}", String.Format(Constants.HintPathFormat, test.Vender, test.AssemblyName));
            string projectTemlate_User = ProjectTemlate_User.Replace("{0}", test.Vender);
            File.WriteAllText(path + @"\TestForm.cs", test.Template);
            File.WriteAllText(path + @"\TestProject.csproj", projectTemplate);
            File.WriteAllText(path + @"\TestProject.csproj.user", projectTemlate_User);
        }
        public static ProjectCompiler Compile(IEnumerable<TestInfo> tests, string settings) {
            ProjectCompiler project = new ProjectCompiler();
            project.Compile(tests);
            SolutionBuilder.BuildAll(Constants.TempFolder, settings, true);
            return project;
        }
        static string ProjectTemlate {
            get {
                if(string.IsNullOrEmpty(projectTemlateCore))
                    projectTemlateCore = ResourceHelper.GetString(Constants.ProjectFile);
                return projectTemlateCore;
            }
        }
        static string ProjectTemlate_User {
            get {
                if(string.IsNullOrEmpty(projectTemlate_UserCore))
                    projectTemlate_UserCore = ResourceHelper.GetString(Constants.ProjectFile_User);
                return projectTemlate_UserCore;
            }
        }
        #region IDisposable Members
        bool isDisposing;
        void IDisposable.Dispose() {
            if(isDisposing) return;
            isDisposing = true;
            OnDispose();
        }
        protected virtual void OnDispose() {
            try {
                Directory.Delete(Constants.TempFolder, true);
            }
            catch {
                //writeLog
            }
        }
        #endregion
    }
}