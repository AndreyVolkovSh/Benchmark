using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace Benchmark.ViewModels {
    public abstract class DocumentManagerViewModel {
        protected bool isLoading;
        public void OnLoad() {
            if(isLoading) return;
            isLoading = true;
            OnLoadCore();
        }
        protected abstract void OnLoadCore();
        protected IDocument NewTab(string documentType) {
            IDocument document = DocumentManagerService.CreateDocument(documentType, null, this);
            document.Show();
            return document;
        }
        protected IDocumentManagerService DocumentManagerService {
            get { return this.GetRequiredService<IDocumentManagerService>(); }
        }
    }
}