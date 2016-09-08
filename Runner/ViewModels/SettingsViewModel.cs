using DevExpress.Mvvm;

namespace Benchmark.ViewModels {
    public class SettingsViewModel : DocumentManagerViewModel, IDocumentContent {
        protected override void OnLoadCore() {
            NewTab("TabSettingsView");
            NewTab("TabProductView");
            NewTab("TabScopeView");
        }
      
        #region IDocumentContent Members
        IDocumentOwner IDocumentContent.DocumentOwner {
            get;
            set;
        }
        void IDocumentContent.OnClose(System.ComponentModel.CancelEventArgs e) { }
        void IDocumentContent.OnDestroy() { }
        object IDocumentContent.Title {
            get { return "Settings"; }
        }
        #endregion
    }
}