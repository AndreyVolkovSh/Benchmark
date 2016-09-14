using Benchmark.ViewModels;
using DevExpress.Utils.MVVM.Services;

namespace Benchmark.Views {
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