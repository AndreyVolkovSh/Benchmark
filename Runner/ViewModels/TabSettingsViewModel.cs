using System.Collections.Generic;
using Benchmark.Common;
using Benchmark.Runner;
using DevExpress.Mvvm.POCO;

namespace Benchmark.ViewModels {
    public class TabSettingsViewModel : DocumentViewModel {
        public TabSettingsViewModel() { }
        Settings Settings {
            get {
                SettingsViewModel model = this.GetParentViewModel<SettingsViewModel>();
                return model.GetParentViewModel<MainViewModel>().Settings;
            }
        }
        public bool EnableNGen {
            get { return Settings.EnableNGen; }
            set { Settings.EnableNGen = value; }
        }
        public Framework Framework {
            get { return Settings.Framework; }
            set { Settings.Framework = value; }
        }
        public Platform Platform {
            get { return Settings.Platform; }
            set { Settings.Platform = value; }
        }
        public string ToolVersion {
            get { return Settings.ToolVersion; }
            set { Settings.ToolVersion = value; }
        }
        public virtual IEnumerable<Framework> Frameworks {
            get { return Settings.Frameworks; }
        }
        public virtual IEnumerable<string> ToolVersions {
            get { return Settings.ToolVersions; }
        }
        public virtual void OnBuild() {
            Launcher.BuildSolutions(Settings);
        }
        protected override object GetTitle() {
            return "Settings";
        }
    }
}