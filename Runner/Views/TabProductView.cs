using Benchmark.ViewModels;

namespace Benchmark.Views {
    public partial class TabProductView : TabBaseView {
        public TabProductView() {
            InitializeComponent();
            InitializeContext<TabProductViewModel>();
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            OnLoadContext<TabProductViewModel>();
            var fluentAPI = GetFluentAPI<TabProductViewModel>();
            fluentAPI.SetBinding(textEdit, x => x.Text, y => y.Product);
        }
    }
}