using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Benchmark.Runner;

namespace Benchmark.Win.ViewModels {
    public abstract class TabBaseViewModel : DocumentViewModel {
        public class Node {
            public Node(string name) {
                Name = name;
            }
            public bool Checked {
                get;
                set;
            }
            public string Name {
                get;
                set;
            }
        }
        public TabBaseViewModel() {
            Update();
        }
        public virtual string EditLabel {
            get;
            set;
        }
        public virtual string CheckedListLabel {
            get;
            set;
        }
        public virtual string ButtonText {
            get;
            set;
        }
        public virtual object DataSource {
            get;
            set;
        }
        public virtual void Update() {
            DataSource = GetDataSource();
        }
        protected abstract BindingList<Node> GetDataSource();
        public abstract void OnAdd();

    }
    public static class TabBaseData {
        static List<string> vendersCore, productsCore;
        public static List<string> Products {
            get {
                if(productsCore == null)
                    productsCore = GetProducts();
                return productsCore;
            }
        }
        public static List<string> Venders {
            get {
                if(vendersCore == null)
                    vendersCore = GetVenders();
                return vendersCore;
            }
        }
        public static void Update() {
            vendersCore = productsCore = null;
        }
        static List<string> GetVenders() {
            DirectoryInfo info = new DirectoryInfo(Constants.AssembliesFolder);
            if(!info.Exists) return null;
            List<string> products = new List<string>();
            DirectoryInfo[] directories = info.GetDirectories();
            foreach(var direstory in directories) {
                if(Constants.TestsFolder.Contains(direstory.Name)) continue;
                products.Add(direstory.Name);
            }
            return products;
        }
        static List<string> GetProducts() {
            string path = Launcher.GetTestsPath();
            DirectoryInfo info = new DirectoryInfo(path);
            if(!info.Exists) return null;
            List<string> products = new List<string>();
            DirectoryInfo[] directories = info.GetDirectories();
            foreach(var direstory in directories)
                products.Add(direstory.Name);
            return products;
        }
    }
}