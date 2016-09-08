using Benchmark.Runner;
using Benchmark.ViewModels;
using DevExpress.Utils.MVVM.Services;

namespace Benchmark.Views {
    public partial class MainView : DocumentManagerView {
        public MainView() {
            InitializeComponent();
            InitializeContext<MainViewModel>();
        }
        protected override DocumentManagerService GetDocumentService() {
            return DocumentManagerService.Create(xtraTabControl);
        }
    }
}