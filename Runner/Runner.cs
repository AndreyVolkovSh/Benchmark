using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Benchmark.Runner;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System.Linq;
using System.Collections;

namespace Benchmark.Win {
    public partial class Runner : Form {
        Assemblies history;
        DataSource dataSourceCore;
        public Runner() {
            InitializeComponent();
            history = new Assemblies();
            dataSourceCore = new DataSource();
            mvvmContext.ViewModelType = typeof(Settings);
            var fluentAPI = mvvmContext.OfType<Settings>();
            Settings settings = mvvmContext.GetViewModel<Settings>();
            InitializeComboBox<Platform>(platformComboBox);
            InitializeLookUp(frameworkLookUp, settings.GetFrameworks());
            InitializeLookUp(toolVersionLookUp, settings.GetToolVersions());
            fluentAPI.SetBinding(platformComboBox, x => x.EditValue, y => y.Platform);
            fluentAPI.SetBinding(frameworkLookUp, x => x.EditValue, y => y.Framework);
            fluentAPI.SetBinding(toolVersionLookUp, x => x.EditValue, y => y.ToolVersion);
            fluentAPI.SetBinding(enableNGen, x => x.EditValue, y => y.EnableNGen);
        }
        void InitializeComboBox<T>(ImageComboBoxEdit comboBox) {
            comboBox.Properties.AddEnum<T>();
        }
        void InitializeLookUp(LookUpEdit lookUp, object source) {
            lookUp.Properties.DataSource = source;
            lookUp.Properties.PopupSizeable = false;
            lookUp.Properties.ShowFooter = false;
            lookUp.Properties.ShowHeader = false;
            lookUp.Properties.UseDropDownRowsAsMaxCount = true;
        }
        void OnStart(object sender, EventArgs e) {
            IEnumerable<TestInfo> tests = dataSourceCore.Source.Where((x) => x.Enabled);
            gridControl.DataSource = Launcher.Start(Settings, tests);
        }
        Settings Settings {
            get { return mvvmContext.GetViewModel<Settings>(); }
        }
        void OnBuild(object sender, EventArgs e) {
            Launcher.BuildSolutions(Settings.ToBuildSettings());
        }
        void OnUpdateAssemblies(object sender, EventArgs e) {
            using(AssemblyManager window = new AssemblyManager(history)) {
                DialogResult result = window.ShowDialog();
                if(result == DialogResult.OK || result == DialogResult.Yes)
                    UpdateAssemblies(window.Assemblies);
            }
        }
        void UpdateAssemblies(Assemblies hashSet) {
            List<FileInfo> unLoad = new List<FileInfo>();
            FileInfo[] files = new FileInfo[history.Count];
            history.CopyTo(files, 0);
            foreach(FileInfo info in files) {
                if(!hashSet.Contains(info)) {
                    unLoad.Add(info);
                    history.Remove(info);
                }
                else
                    hashSet.Remove(info);
            }
            foreach(FileInfo info in hashSet)
                history.Add(info);
            UnloadAssemblies(unLoad);
            LoadAssemblies(hashSet);
            UpdateTreeList();
        }
        void UpdateTreeList() {
            productsTreeList.BeginUpdate();
            productsTreeList.PopulateNodes(dataSourceCore.Source);
            productsTreeList.EndUpdate();
        }
        void LoadAssemblies(IEnumerable<FileInfo> files) {
            foreach(FileInfo file in files) {
                string fullName = file.FullName;
                AssemblyLoader loader = AssemblyLoader.Load(fullName);
                dataSourceCore.AddTests(fullName, loader.GetTests());
            }
        }
        void UnloadAssemblies(IEnumerable<FileInfo> files) {
            foreach(FileInfo file in files)
                dataSourceCore.RemoveTests(file.FullName);
        }
    }
    class DataSource {
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
        public List<TestInfo> Source {
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