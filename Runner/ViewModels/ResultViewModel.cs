using System.Collections.Generic;
using Benchmark.Runner;
using DevExpress.Mvvm.POCO;

namespace Benchmark.ViewModels {
    public class ResultViewModel : DocumentViewModel {
        protected override object GetTitle() {
            return "Results";
        }
        public virtual IEnumerable<TestResult> Source {
            get;
            set;
        }
        public void OnResultsChanged(Common.RequeryResults results) {
            Source = this.GetParentViewModel<MainViewModel>().Results;
        }
    }
}