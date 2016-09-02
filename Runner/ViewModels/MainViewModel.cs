﻿using System.Collections.Generic;
using Benchmark.Runner;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace Benchmark.Win.ViewModels {
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
            NewTab("TestsView");
            NewTab("ResultView");
        }
    }
}