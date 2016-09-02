using Benchmark.Win.ViewModels;

namespace Benchmark.Win.Views {
    public partial class TestsView : DocumentView {
        public TestsView() {
            InitializeComponent();
            InitializeContext<TestsViewModel>();
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            var fluentAPI = GetFluentAPI<TestsViewModel>();
            fluentAPI.BindCommand(addAssemblyButton, x => x.OnAddAssemblies());
            fluentAPI.BindCommand(startButton, x => x.OnStart());
            fluentAPI.BindCommand(resetButton, x => x.OnReset());
            fluentAPI.SetTrigger(x => x.IsSourceChanged, UpdateTreeList);
        }
        void UpdateTreeList(bool value) {
            productsTreeList.BeginUpdate();
            TestsViewModel model = Context.GetViewModel<TestsViewModel>();
            productsTreeList.PopulateNodes(model.Tests);
            productsTreeList.EndUpdate();
        }
    }
}