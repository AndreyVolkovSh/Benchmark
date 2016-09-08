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
            Update();
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
        public void Update() {
            UpdateScopes();
            UpdateProducts();
        }
        DirectoryInfo[] GetDirectories(string path) {
            DirectoryInfo info = new DirectoryInfo(path);
            if(!info.Exists) return null;
            return info.GetDirectories();
        }
        void UpdateScopes() {
            scopesCore = new HashSet<string>();
            DirectoryInfo[] directories = GetDirectories(Folders.Assemblies);
            if(directories == null) return;
            foreach(var direstory in directories) {
                if(Folders.Tests.Contains(direstory.Name)) continue;
                scopesCore.Add(direstory.Name);
            }
        }
        void UpdateProducts() {
            productsCore = new HashSet<string>();
            DirectoryInfo[] directories = GetDirectories(Launcher.GetTestsPath());
            if(directories == null) return;
            foreach(var direstory in directories)
                productsCore.Add(direstory.Name);
        }
        public void RegisterScope(string scope, IEnumerable<string> products) {
            if(string.IsNullOrEmpty(scope)) return;
            try {
                if(!scopesCore.Contains(scope)) return;
                AddScope(scope, products);
                UpdateScopes();
            }
            catch {
                //log
            }
        }
        void AddScope(string scope, IEnumerable<string> products) {
            AddProjects(scope, products);
        }
        public void RegisterProduct(string product, IEnumerable<string> scopes) {
            if(productsCore.Contains(product) || string.IsNullOrEmpty(product)) return;
            try {
                Create(product, scopes);
                UpdateProducts();
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