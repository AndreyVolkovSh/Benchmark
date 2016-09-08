using DevExpress.Mvvm;

namespace Benchmark.ViewModels {
    public abstract class DocumentViewModel : IDocumentContent {
        #region IDocumentContent Members
        IDocumentOwner IDocumentContent.DocumentOwner {
            get;
            set;
        }
        void IDocumentContent.OnClose(System.ComponentModel.CancelEventArgs e) {
            OnClose(e);
        }
        protected virtual void OnClose(System.ComponentModel.CancelEventArgs e) {
            OnDestroy();
        }
        void IDocumentContent.OnDestroy() { }
        protected virtual void OnDestroy() { }
        object IDocumentContent.Title {
            get { return GetTitle(); }
        }
        protected abstract object GetTitle();
        #endregion
    }
}