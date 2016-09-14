using System.Collections.Generic;
using System.IO;
using System.Linq;
using Benchmark.Common;

namespace Benchmark.ViewModels {
    public class AssemblyManagerViewModel : BaseManagerViewModel {
        AssemblyCache historyCore;
        public AssemblyManagerViewModel(AssemblyCache history) {
            historyCore = history;
            DataSource = LoadDataSource();
        }
        public AssemblyCache Assemblies {
            get {
                AssemblyCache assemblies = new AssemblyCache();
                if(DataSource == null) return assemblies;
                foreach(FileInfo file in GetAssemblies())
                    assemblies.Add(file as FileInfo);
                return assemblies;
            }
        }
        IEnumerable<FileInfo> GetAssemblies() {
            return GetCheckedItems().Select((x) => x.Tag as FileInfo);
        }
        protected IEnumerable<CheckedItem> LoadDataSource() {
            List<CheckedItem> source = new List<CheckedItem>();
            DirectoryInfo directory = Directory.CreateDirectory(Folders.TestAssemblies);
            if(!directory.Exists) return source;
            FileInfo[] assemblies = directory.GetFiles(SearchResolution.DLL, SearchOption.AllDirectories);
            if(assemblies == null) return source;
            foreach(FileInfo assembly in assemblies) {
                CheckedItem item = new CheckedItem(assembly.Name)
                {
                    Checked = historyCore.Contains(assembly),
                    Tag = assembly
                };
                source.Add(item);
            }
            return source;
        }
    }
}