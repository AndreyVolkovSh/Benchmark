using Benchmark.Win.ViewModels;

namespace Benchmark.Win.Views {
    public partial class TabProductView : TabBaseView {
        public TabProductView() {
            InitializeComponent();
            InitializeContext<TabProductViewModel>();
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            OnLoadContext<TabProductViewModel>();
        }
    }
}