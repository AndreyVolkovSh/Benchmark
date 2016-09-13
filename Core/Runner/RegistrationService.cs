using System.Collections.Generic;
using System.IO;
using Benchmark.Common;

namespace Benchmark.Runner {
    public class RegistrationService {
        HashSet<string> scopesCore, productsCore;
        static RegistrationService serviceCore;
        public static RegistrationService Service {
            get {
                if(serviceCore == null)
                    serviceCore = new RegistrationService();
                return serviceCore;
            }
        }
        RegistrationService() {
            Load();
        }
        public bool ProductContains(string product) {
            return productsCore.Contains(product);
        }
        public IEnumerable<string> Products {
            get { return productsCore; }
        }
        public IEnumerable<string> Scopes {
            get { return scopesCore; }
        }
        public void Load() {
            LoadScopes();
            LoadProducts();
        }
        DirectoryInfo[] GetDirectories(string path) {
            DirectoryInfo info = new DirectoryInfo(path);
            if(!info.Exists) return null;
            return info.GetDirectories();
        }
        void LoadScopes() {
            scopesCore = new HashSet<string>();
            DirectoryInfo[] directories = GetDirectories(Folders.Assemblies);
            if(directories == null) return;
            foreach(var direstory in directories) {
                if(Folders.Tests.Contains(direstory.Name)) continue;
                scopesCore.Add(direstory.Name);
            }
        }
        void LoadProducts() {
            productsCore = new HashSet<string>();
            DirectoryInfo[] directories = GetDirectories(Launcher.TestsPath);
            if(directories == null) return;
            foreach(var direstory in directories)
                productsCore.Add(direstory.Name);
        }
        public void RegisterScope(string scope, IEnumerable<string> products) {
            if(string.IsNullOrEmpty(scope)) return;
            try {
                if(!scopesCore.Contains(scope))
                    CreateScope(scope);
                AddScope(scope, products);
                LoadScopes();
            }
            catch {
                //log
            }
        }
        void CreateScope(string scope) {
            string scopeFolder = Folders.Assemblies + scope + "\\";
            if(Directory.Exists(scopeFolder)) return;
            Directory.CreateDirectory(scopeFolder);
            PatchConfig(scopeFolder);
        }
        void PatchConfig(string scopeFolder) {
            string privatePath = @"Dlls\;Assemblies\;";
            if(Scopes != null) {
                foreach(string scope in Scopes)
                    privatePath += string.Format(Formats.PrivatePath, scope);
            }
            privatePath += scopeFolder + ";";
            string appConfig = ResourceService.AppConfig.Replace(ReplaceParams.PrivatePath, privatePath);
            foreach(string config in GetAllConfig())
                File.WriteAllText(config, appConfig);
        }
        IEnumerable<string> GetAllConfig() {
            List<string> files = new List<string>();
            files.AddRange(Directory.GetFiles(System.Windows.Forms.Application.StartupPath, "*.exe.config", SearchOption.TopDirectoryOnly));
            files.AddRange(Directory.GetFiles(Launcher.RunnerPath, "*.config", SearchOption.TopDirectoryOnly));
            files.AddRange(Directory.GetFiles(Launcher.ConsolePath, "*.config", SearchOption.TopDirectoryOnly));
            return files;
        }
        void AddScope(string scope, IEnumerable<string> products) {
            AddProjects(scope, products);
        }
        public void RegisterProduct(string product, IEnumerable<string> scopes) {
            if(productsCore.Contains(product) || string.IsNullOrEmpty(product)) return;
            try {
                Create(product, scopes);
                LoadProducts();
            }
            catch {
                //log
                //RemoveFolder;
            }
        }
        void AddProjects(string scope, IEnumerable<string> products) {
            foreach(string product in products) {
                new SolutionInfo(product).AddProject(CreateProjectInfo(product, scope));
            }
        }
        void Create(string product, IEnumerable<string> scopes) {
            new SolutionInfo(product, CreateProjects(product, scopes)).Save();
        }
        IEnumerable<ProjectInfo> CreateProjects(string product, IEnumerable<string> scopes) {
            List<ProjectInfo> projects = new List<ProjectInfo>();
            foreach(string scope in scopes)
                projects.Add(CreateProjectInfo(product, scope));
            return projects;
        }
        ProjectInfo CreateProjectInfo(string product, string scope) {
            return new ProjectInfo(product, scope);
        }
    }
}