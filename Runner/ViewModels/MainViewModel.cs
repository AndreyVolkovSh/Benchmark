using System.Collections.Generic;
using Benchmark.Common;
using Benchmark.Runner;
using DevExpress.Mvvm;

namespace Benchmark.ViewModels {
    public class MainViewModel : DocumentManagerViewModel {
        Settings settingsCore;
        public MainViewModel() {
            settingsCore = new Settings();
        }
        public virtual List<TestResult> Results {
            get;
            set;
        }
        protected virtual void OnResultsChanged() {
            Messenger.Default.Send(new RequeryResults());
        }
        public Settings Settings {
            get { return settingsCore; }
        }
        protected override void OnLoadCore() {
            NewTab("SettingsView");
            NewTab("BenchmarksView");
            NewTab("ResultView");
        }
    }
}