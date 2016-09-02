using Benchmark.Win.ViewModels;
using DevExpress.Utils.MVVM.Services;

namespace Benchmark.Win.Views {
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