using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace Benchmark.Win.ViewModels {
    public abstract class DocumentManagerViewModel {
        protected bool isLoading;
        public void OnLoad() {
            if(isLoading) return;
            isLoading = true;
            OnLoadCore();
        }
        protected abstract void OnLoadCore();
        protected void NewTab(string documentType) {
            IDocument document = DocumentManagerService.CreateDocument(documentType, null, this);
            document.Show();
        }
        protected IDocumentManagerService DocumentManagerService {
            get { return this.GetRequiredService<IDocumentManagerService>(); }
        }
    }
}