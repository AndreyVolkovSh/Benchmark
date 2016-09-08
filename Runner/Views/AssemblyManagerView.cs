using System;
using System.Windows.Forms;
using Benchmark.ViewModels;

namespace Benchmark.Views {
    public partial class AssemblyManagerView : UserControl {
        public AssemblyManagerView() {
            InitializeComponent();
            mvvmContext.ViewModelType = typeof(AssemblyManagerViewModel);
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            var fluentAPI = mvvmContext.OfType<AssemblyManagerViewModel>();
            fluentAPI.SetBinding(treeList, x => x.DataSource, y => y.DataSource);
        }
    }
}
