using System.Collections.Generic;
using System.IO;
using Benchmark.Common;
using Benchmark.Runner;
using System.Linq;

namespace Benchmark.ViewModels {
    public class BuildManagerViewModel : BaseManagerViewModel {
        public static BuildManagerViewModel Create() {
            return DevExpress.Mvvm.POCO.ViewModelSource.Create<BuildManagerViewModel>();
        }
        public BuildManagerViewModel() {
            LoadDataSource(false);
        }
        public string[] BuildObjects {
            get { return GetBuildObjects(); }
        }
        string[] GetBuildObjects() {
            return GetCheckedItems().Select((x) => (x.Tag as FileInfo).FullName).ToArray();
        }
        public void LoadDataSource(bool showProject) {
            DataSource = LoadDataSource(showProject ? SearchResolution.ALLProj : SearchResolution.SLN);
        }
        protected IEnumerable<CheckedItem> LoadDataSource(string filter) {
            List<CheckedItem> source = new List<CheckedItem>();
            DirectoryInfo directory = Directory.CreateDirectory(Launcher.TestsPath);
            if(!directory.Exists) return source;
            FileInfo[] solutions = directory.GetFiles(filter, SearchOption.AllDirectories);
            if(solutions == null) return source;
            foreach(FileInfo solution in solutions) {
                CheckedItem item = new CheckedItem(solution.Name)
                {
                    Tag = solution
                };
                source.Add(item);
            }
            return source;
        }
    }
}