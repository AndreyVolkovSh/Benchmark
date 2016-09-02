using System.Collections.Generic;
using Benchmark.Runner;
using DevExpress.Mvvm.POCO;

namespace Benchmark.Win.ViewModels {
    public class ResultViewModel : DocumentViewModel {
        protected override object GetTitle() {
            return "Results";
        }
        public virtual IEnumerable<TestResult> Source {
            get;
            set;
        }
        public void OnResultsChanged(RequeryResults results) {
            Source = this.GetParentViewModel<MainViewModel>().Results;
        }
    }
}