using System;
using System.Collections.Generic;
using System.IO;
using Benchmark.Common;

namespace Benchmark.Internal {
    class ProjectCompiler : IDisposable {
        NGenContext nGen;
        Settings settingsCore;
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
        void Compile(TestLoader test) {
            try {
                DirectoryInfo tempFolder = GetFolder(Folders.Temp);
                string testFullName = test.FullName;
                DirectoryInfo projectFolder = GetFolder(Folders.Temp + testFullName);
                string path = CreateProject(projectFolder.FullName + "\\", test);
                SolutionBuilder.Build(path, settingsCore.ToBuildSettings());
                if(settingsCore.EnableNGen)
                    nGen.Install(test.Path);
            }
            catch {
                //log
            }
        }
        string CreateProject(string path, TestLoader test) {
            lock(TaskManager.Locker) {
                string fullName = test.FullName;
                string projectTemplate = ResourceService.TestProject.Replace(ReplaceParams.AssemblyName, fullName)
                    .Replace(ReplaceParams.Reference, test.AssemblyName)
                    .Replace(ReplaceParams.HintPath, test.AssemblyPath);
                string projectUserTemlate = ResourceService.TestProjectUser.Replace(ReplaceParams.Vender, test.Vender);
                string projPath = path + ResourceNames.TestProjectFile;
                File.WriteAllText(path + ResourceNames.TestFile, test.Template);
                File.WriteAllText(projPath, projectTemplate);
                File.WriteAllText(path + ResourceNames.TestProjectUserFile, projectUserTemlate);
                return projPath;
            }
        }
        public static ProjectCompiler Compile(IEnumerable<TestLoader> tests, Settings settings) {
            ProjectCompiler project = new ProjectCompiler(settings);
            TaskManager.Current.RunTasks<TestLoader>(tests, project.Compile);
            return project;
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
                Directory.Delete(Folders.Temp, true);
            }
            catch {
                //writeLog
            }
        }
        #endregion
    }
}