using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Benchmark.Runner;
using DevExpress.Mvvm.POCO;

namespace Benchmark.Win.ViewModels {
    public class TestsViewModel : DocumentViewModel {
        Assemblies historyCore;
        TestSource testSourceCore;
        public TestsViewModel() {
            historyCore = new Assemblies();
            testSourceCore = new TestSource();
        }
        public virtual bool IsSourceChanged {
            get;
            set;
        }
        public List<TestInfo> Tests {
            get { return testSourceCore.Tests; }
        }
        public virtual void OnStart() {
            IEnumerable<TestInfo> tests = testSourceCore.Tests.Where((x) => x.Enabled);
            ParentModel.Results = Launcher.Start(ParentModel.Settings, tests);
        }
        public virtual void OnAddAssemblies() {
            using(AssemblyManager window = new AssemblyManager(historyCore)) {
                DialogResult result = window.ShowDialog();
                if(result == DialogResult.OK || result == DialogResult.Yes)
                    UpdateAssemblies(window.Assemblies);
            }
        }
        public virtual void OnReset() { }
        public virtual void OnUpdate() { }
        void UpdateAssemblies(Assemblies hashSet) {
            List<FileInfo> unLoad = new List<FileInfo>();
            FileInfo[] files = new FileInfo[historyCore.Count];
            historyCore.CopyTo(files, 0);
            foreach(FileInfo info in files) {
                if(!hashSet.Contains(info)) {
                    unLoad.Add(info);
                    historyCore.Remove(info);
                }
                else
                    hashSet.Remove(info);
            }
            foreach(FileInfo info in hashSet)
                historyCore.Add(info);
            UnloadAssemblies(unLoad);
            LoadAssemblies(hashSet);
            IsSourceChanged = !IsSourceChanged;
        }
        void LoadAssemblies(IEnumerable<FileInfo> files) {
            TaskManager.Current.RunTasks(files, LoadAssemblies);
        }
        void LoadAssemblies(FileInfo file) {
            AssemblyLoader loader = AssemblyLoader.Load(file.FullName);
            testSourceCore.AddTests(loader.FullPath, loader.GetTests());
        }
        void UnloadAssemblies(IEnumerable<FileInfo> files) {
            foreach(FileInfo file in files)
                testSourceCore.RemoveTests(file.FullName);
        }
        protected override void OnDestroy() {
            base.OnDestroy();
            historyCore.Clear();
            testSourceCore.Clear();
        }
        protected override object GetTitle() {
            return "Tests";
        }
        MainViewModel ParentModel {
            get { return this.GetParentViewModel<MainViewModel>(); }
        }
    }
    class TestSource {
        Dictionary<string, IEnumerable<TestInfo>> cacheCore = new Dictionary<string, IEnumerable<TestInfo>>();
        List<TestInfo> sourceCore;

        public void AddTests(string key, IEnumerable<TestInfo> tests) {
            IEnumerable<TestInfo> value;
            if(cacheCore.TryGetValue(key, out value))
                cacheCore[key] = tests;
            else
                cacheCore.Add(key, tests);
            ResetSource();
        }
        public void Clear() {
            cacheCore.Clear();
            ResetSource();
        }
        public List<TestInfo> Tests {
            get {
                if(sourceCore == null || sourceCore.Count == 0)
                    sourceCore = GenerateSource();
                return sourceCore;
            }
        }
        public void RemoveTests(string key) {
            IEnumerable<TestInfo> value;
            if(cacheCore.TryGetValue(key, out value)) {
                cacheCore.Remove(key);
                ResetSource();
            }
        }
        List<TestInfo> GenerateSource() {
            List<TestInfo> source = new List<TestInfo>();
            foreach(var item in cacheCore)
                source.AddRange(item.Value);
            source.Sort((x, y)
                =>
            {
                int result = Comparer.Default.Compare(x.Product, y.Product);
                if(result == 0) {
                    result = Comparer.Default.Compare(x.Category, y.Category);
                    if(result == 0)
                        return Comparer.Default.Compare(x.Name, y.Name);
                }
                return result;
            });
            return source;
        }
        void ResetSource() {
            if(sourceCore == null) return;
            sourceCore.Clear();
            sourceCore = null;
        }
    }
}