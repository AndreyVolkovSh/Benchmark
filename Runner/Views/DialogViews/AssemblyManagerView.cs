using System;
using System.Windows.Forms;
using Benchmark.ViewModels;

namespace Benchmark.Views {
    public partial class AssemblyManagerView : BaseManagerView {
        public AssemblyManagerView() {
            InitializeComponent();
            InitializeContext<AssemblyManagerViewModel>();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            OnLoadContext<AssemblyManagerViewModel>();
        }
    }
}