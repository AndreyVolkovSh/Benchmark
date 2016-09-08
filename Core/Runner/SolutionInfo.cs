using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Benchmark.Common;

namespace Benchmark.Runner {
    class SolutionInfo {
        public SolutionInfo(string product) {
            Product = product;
        }
        public SolutionInfo(string product, IEnumerable<ProjectInfo> projects)
            : this(product) {
            Projects = projects;
        }
        public string Name {
            get { return Product + Resolution.SLN; }
        }
        public string Product {
            get;
            private set;
        }
        public IEnumerable<ProjectInfo> Projects {
            get;
            private set;
        }
        protected string GetFullPath(string path) {
            if(string.IsNullOrEmpty(path))
                path = Launcher.GetTestsPath();
            return path + Product + "\\";
        }
        public void AddProject(ProjectInfo project) {
            string path = GetFullPath(Launcher.GetTestsPath());
            if(PatchSolution(path, project))
                project.Save(path);
        }
        bool CheckProject(string path, ProjectInfo project) {
            IEnumerable<string> directories = Directory.GetDirectories(path, project.AssemblyName);
            return directories != null && directories.Count() != 0;
        }
        bool PatchSolution(string path, ProjectInfo project) {
            string fullName = path + Name;
            if(!File.Exists(fullName)) return false;
            if(CheckProject(path, project)) return false;
            string projectText = File.ReadAllText(fullName);
            projectText = PatchProjectBlock(projectText, project.ToString());
            projectText = PatchProjectConfiguration(projectText, project.Guid);
            File.WriteAllText(fullName, projectText);
            return true;
        }
        string PatchProjectBlock(string projectText, string project) {
            int index = projectText.IndexOf(ReplaceParams.Global, 0);
            if(index < 0) return projectText;
            return projectText.Insert(index, project);
        }
        string PatchProjectConfiguration(string projectText, string guid) {
            int index = projectText.IndexOf(ReplaceParams.EndGlobal, 0);
            if(index < 0) return projectText;
            return projectText.Insert(index,
                ResourceService.ProjectConfiguration.Replace(ReplaceParams.Guid, guid));
        }
        public void Save(string path = null) {
            string fullPath = GetFullPath(path);
            DirectoryInfo solutionInfo = new DirectoryInfo(fullPath);
            if(!solutionInfo.Exists)
                solutionInfo.Create();
            SaveCore(fullPath);
        }
        void SaveCore(string path) {
            if(!Directory.Exists(path) || Projects == null || Projects.Count() == 0) return;
            string projectsConfiguration = string.Empty;
            string projectBlock = string.Empty;
            foreach(ProjectInfo project in Projects) {
                projectBlock += project.ToString();
                projectsConfiguration += ResourceService.ProjectConfiguration.Replace(ReplaceParams.Guid, project.Guid);
                project.Save(path);
            }
            string solution = ResourceService.Solution.Replace(ReplaceParams.Project, projectBlock);
            solution = solution.Replace(ReplaceParams.ProjectsConfiguration, projectsConfiguration);
            File.WriteAllText(path + Name, solution);
        }
    }
    class ProjectInfo {
        public ProjectInfo(string product, string scope) {
            Scope = scope;
            Product = product;
            Guid = System.Guid.NewGuid().ToString();
            Properties = new PropertiesInfo(this);
        }
        public string Name {
            get { return AssemblyName + Resolution.PROJ; }
        }
        public string AssemblyName {
            get { return string.Format(Formats.AssemblyName, Product, Scope); }
        }
        public string Product {
            get;
            private set;
        }
        public string Scope {
            get;
            private set;
        }
        public string Guid {
            get;
            private set;
        }
        public PropertiesInfo Properties {
            get;
            private set;
        }
        public override string ToString() {
            string str = ResourceService.ProjectBlock.Replace(ReplaceParams.AssemblyName, AssemblyName);
            str = str.Replace(ReplaceParams.Guid, Guid);
            return str + Environment.NewLine;
        }
        protected string GetFullPath(string path) {
            return path + AssemblyName + "\\";
        }
        public void Save(string path) {
            string fullPath = GetFullPath(path);
            DirectoryInfo projectInfo = new DirectoryInfo(fullPath);
            if(!projectInfo.Exists)
                projectInfo.Create();
            SaveCore(fullPath);
        }
        void SaveCore(string path) {
            if(!Directory.Exists(path)) return;
            string project = ResourceService.Project.Replace(ReplaceParams.Guid, Guid);
            string rootNamespace = string.Format(Formats.RootNamespace, Product);
            project = project.Replace(ReplaceParams.RootNamespace, rootNamespace);
            project = project.Replace(ReplaceParams.AssemblyName, AssemblyName);
            project = project.Replace(ReplaceParams.Scope, Scope);
            File.WriteAllText(path + Name, project);
            File.WriteAllText(path + ResourceNames.SimpleTestsFile, ResourceService.SimpleTests.Replace(ReplaceParams.RootNamespace, rootNamespace));
            File.WriteAllText(path + Name + Resolution.USER, ResourceService.ProjectUser.Replace(ReplaceParams.Scope, Scope));
            Properties.Save(path);
        }
    }
    class PropertiesInfo {
        public PropertiesInfo(ProjectInfo project) {
            AssemblyProduct = project.Product;
            AssemblyTitle = project.AssemblyName;
            AssemblyCompany = project.Scope;
            Guid = project.Guid;
        }
        public string AssemblyProduct {
            get;
            private set;
        }
        public string Guid {
            get;
            private set;
        }
        public string AssemblyTitle {
            get;
            private set;
        }
        public string AssemblyCompany {
            get;
            private set;
        }
        protected string GetFullPath(string path) {
            return path + Folders.Properties;
        }
        public void Save(string path) {
            string fullPath = GetFullPath(path);
            DirectoryInfo propertiesInfo = new DirectoryInfo(fullPath);
            if(!propertiesInfo.Exists)
                propertiesInfo.Create();
            SaveCore(fullPath);
        }
        void SaveCore(string path) {
            if(!Directory.Exists(path)) return;
            string assemblyInfo = ResourceService.AssemblyInfo.Replace(ReplaceParams.AssemblyName, AssemblyTitle);
            assemblyInfo = assemblyInfo.Replace(ReplaceParams.Scope, AssemblyCompany);
            assemblyInfo = assemblyInfo.Replace(ReplaceParams.Product, AssemblyProduct);
            assemblyInfo = assemblyInfo.Replace(ReplaceParams.Guid, Guid);
            File.WriteAllText(path + ResourceNames.AssemblyInfoFile, assemblyInfo);
        }
    }
}