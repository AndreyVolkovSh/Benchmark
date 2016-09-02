using Benchmark.Win.ViewModels;
using DevExpress.Utils.MVVM.Services;

namespace Benchmark.Win.Views {
    public partial class SettingsView : DocumentManagerView {
        public SettingsView() {
            InitializeComponent();
            InitializeContext<SettingsViewModel>();
        }
        protected override DocumentManagerService GetDocumentService() {
            return DocumentManagerService.Create(tabPane);
        }
    }
}