using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Benchmark.Runner;
using DevExpress.Mvvm.POCO;
using Benchmark.Common;
using DevExpress.Mvvm;

namespace Benchmark.ViewModels {
    public class BenchmarksViewModel : DocumentViewModel {
        AssemblyCache historyCore;
        TestSource testSourceCore;
        public BenchmarksViewModel() {
            historyCore = new AssemblyCache();
            testSourceCore = new TestSource();
        }
        public virtual bool IsSourceChanged {
            get;
            set;
        }
        public List<TestLoader> Tests {
            get { return testSourceCore.Tests; }
        }
        public virtual void OnStart() {
            IEnumerable<TestLoader> tests = testSourceCore.Tests.Where((x) => x.Enabled);
            ParentModel.Results = Launcher.Start(ParentModel.Settings, tests);
        }
        public virtual void OnAddAssemblies() {
            IDialogService service = this.GetRequiredService<IDialogService>();
            if(service == null) return;
            AssemblyManagerViewModel model = new AssemblyManagerViewModel(historyCore);
            MessageResult result = service.ShowDialog(MessageButton.OKCancel, "Assembly manager", "AssemblyManagerView", model);
            if(result == MessageResult.OK || result == MessageResult.Yes)
                UpdateAssemblies(model.Assemblies);
        }
        public virtual void OnRefresh() {
            UpdateAssemblies(historyCore);
        }
        void UpdateAssemblies(AssemblyCache hashSet) {
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
            return "Benchmarks";
        }
        MainViewModel ParentModel {
            get { return this.GetParentViewModel<MainViewModel>(); }
        }
    }
    class TestSource {
        Dictionary<string, IEnumerable<TestLoader>> cacheCore = new Dictionary<string, IEnumerable<TestLoader>>();
        List<TestLoader> sourceCore;

        public void AddTests(string key, IEnumerable<TestLoader> tests) {
            IEnumerable<TestLoader> value;
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
        public List<TestLoader> Tests {
            get {
                if(sourceCore == null || sourceCore.Count == 0)
                    sourceCore = GenerateSource();
                return sourceCore;
            }
        }
        public void RemoveTests(string key) {
            IEnumerable<TestLoader> value;
            if(cacheCore.TryGetValue(key, out value)) {
                cacheCore.Remove(key);
                ResetSource();
            }
        }
        List<TestLoader> GenerateSource() {
            List<TestLoader> source = new List<TestLoader>();
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