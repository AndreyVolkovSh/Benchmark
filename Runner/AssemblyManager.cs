using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace Benchmark.Win {
    public partial class AssemblyManager : Form {
        Assemblies historyCore;
        public AssemblyManager(Assemblies history) {
            InitializeComponent();
            historyCore = history;
            LoadAssemblies();
        }
        public Assemblies Assemblies {
            get {
                Assemblies assemblies = new Assemblies();
                if(assemblyList.CheckedIndices.Count > 0) {
                    foreach(ListBoxItem item in assemblyList.CheckedItems)
                        assemblies.Add(item.Value as FileInfo);
                }
                return assemblies;
            }
        }
        public override string Text {
            get { return "Assembly manager"; }
            set { }
        }
        protected void Close(DialogResult result) {
            DialogResult = result;
            Close();
        }
        void LoadAssemblies() {
            assemblyList.BeginUpdate();
            assemblyList.Items.Clear();
            DirectoryInfo directory = Directory.CreateDirectory(Constants.TestAssembliesPath);
            if(directory == null) return;
            FileInfo[] assemblies = directory.GetFiles("*.dll", SearchOption.AllDirectories);
            if(assemblies == null) return;
            foreach(FileInfo assembly in assemblies)
                assemblyList.Items.Add(assembly, historyCore.Contains(assembly));
            assemblyList.EndUpdate();
        }
        void OnCancel(object sender, EventArgs e) {
            Close(DialogResult.Cancel);
        }
        void OnLoad(object sender, EventArgs e) {
            Close(DialogResult.OK);
        }
        void OnRefresh(object sender, EventArgs e) {
            LoadAssemblies();
        }
    }
}