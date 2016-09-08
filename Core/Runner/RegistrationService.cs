using System.Collections.Generic;
using System.IO;
using Benchmark.Common;

namespace Benchmark.Runner {
    public class RegistrationService {
        HashSet<string> vendersCore, productsCore;
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
        public IEnumerable<string> Venders {
            get { return vendersCore; }
        }
        public void Update() {
            UpdateVenders();
            UpdateProducts();
        }
        DirectoryInfo[] GetDirectories(string path) {
            DirectoryInfo info = new DirectoryInfo(path);
            if(!info.Exists) return null;
            return info.GetDirectories();
        }
        void UpdateVenders() {
            vendersCore = new HashSet<string>();
            DirectoryInfo[] directories = GetDirectories(Folders.Assemblies);
            if(directories == null) return;
            foreach(var direstory in directories) {
                if(Folders.Tests.Contains(direstory.Name)) continue;
                vendersCore.Add(direstory.Name);
            }
        }
        void UpdateProducts() {
            productsCore = new HashSet<string>();
            DirectoryInfo[] directories = GetDirectories(Launcher.GetTestsPath());
            if(directories == null) return;
            foreach(var direstory in directories)
                productsCore.Add(direstory.Name);
        }
        public void RegisterVender(string vender, IEnumerable<string> products) {
            if(string.IsNullOrEmpty(vender)) return;
            try {
                if(!vendersCore.Contains(vender)) return;
                AddVender(vender, products);
                UpdateVenders();
            }
            catch {
                //log
            }
        }
        void AddVender(string vender, IEnumerable<string> products) {
            AddProjects(vender, products);
        }
        public void RegisterProduct(string product, IEnumerable<string> venders) {
            if(productsCore.Contains(product) || string.IsNullOrEmpty(product)) return;
            try {
                Create(product, venders);
                UpdateProducts();
            }
            catch {
                //log
                //RemoveFolder;
            }
        }
        void AddProjects(string vender, IEnumerable<string> products) {
            foreach(string product in products) {
                new SolutionInfo(product).AddProject(CreateProjectInfo(product, vender));
            }
        }
        void Create(string product, IEnumerable<string> venders) {
            new SolutionInfo(product, CreateProjects(product, venders)).Save();
        }
        IEnumerable<ProjectInfo> CreateProjects(string product, IEnumerable<string> venders) {
            List<ProjectInfo> projects = new List<ProjectInfo>();
            foreach(string vender in venders)
                projects.Add(CreateProjectInfo(product, vender));
            return projects;
        }
        ProjectInfo CreateProjectInfo(string product, string vender) {
            return new ProjectInfo(product, vender);
        }
    }
}