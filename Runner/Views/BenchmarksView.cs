using Benchmark.ViewModels;

namespace Benchmark.Views {
    public partial class BenchmarksView : DocumentView {
        public BenchmarksView() {
            InitializeComponent();
            InitializeContext<BenchmarksViewModel>();
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            var fluentAPI = GetFluentAPI<BenchmarksViewModel>();
            fluentAPI.BindCommand(addAssemblyButton, x => x.OnAddAssemblies());
            fluentAPI.BindCommand(startButton, x => x.OnStart());
            fluentAPI.BindCommand(refreshButton, x => x.OnRefresh());
            fluentAPI.SetTrigger(x => x.IsSourceChanged, UpdateTreeList);
        }
        void UpdateTreeList(bool value) {
            productsTreeList.BeginUpdate();
            BenchmarksViewModel model = Context.GetViewModel<BenchmarksViewModel>();
            productsTreeList.PopulateNodes(model.Tests);
            productsTreeList.EndUpdate();
        }
    }
}