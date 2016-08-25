using System;
using System.Collections.Generic;
using System.IO;

namespace Benchmark.Internal {
    class ProjectCompiler : IDisposable {
        NGenContext nGen;
        Settings settingsCore;
        static string projectTemlateCore, projectTemlate_UserCore;
        public ProjectCompiler(Settings settings) {
            settingsCore = settings;
            nGen = new NGenContext(settingsCore.Platform);
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
                string path = PatchProject(projectFolder.FullName, test);
                SolutionBuilder.Build(path, settingsCore.ToBuildSettings());
                if(settingsCore.EnableNGen)
                    nGen.Install(test.Path);
            }
            catch {
                //log
            }
        }
        string PatchProject(string path, TestInfo test) {
            string fullName = test.FullName;
            string projectTemplate = ProjectTemlate.Replace("{0}", fullName)
                .Replace("{1}", test.AssemblyName)
                .Replace("{2}", test.AssemblyPath);
            string projectTemlate_User = ProjectTemlate_User.Replace("{0}", test.Vender);
            string projPath = path + @"\TestProject.csproj";
            File.WriteAllText(path + @"\TestForm.cs", test.Template);
            File.WriteAllText(projPath, projectTemplate);
            File.WriteAllText(path + @"\TestProject.csproj.user", projectTemlate_User);
            return projPath;
        }
        public static ProjectCompiler Compile(IEnumerable<TestInfo> tests, Settings settings) {
            ProjectCompiler project = new ProjectCompiler(settings);
            TaskManager.Current.RunTasks<TestInfo>(tests, project.Compile);
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
                nGen.Dispose();
                Directory.Delete(Constants.TempFolder, true);
            }
            catch {
                //writeLog
            }
        }
        #endregion
    }
}