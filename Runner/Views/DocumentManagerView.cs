using System.Windows.Forms;
using Benchmark.ViewModels;
using DevExpress.Utils.MVVM;
using DevExpress.Utils.MVVM.Services;

namespace Benchmark.Views {
    public partial class DocumentManagerView : UserControl {
        public DocumentManagerView() {
            InitializeComponent();
        }
        protected MVVMContext Context {
            get { return mvvmContext; }
        }
        protected virtual void InitializeContext<T>() where T : DocumentManagerViewModel {
            if(mvvmContext.IsDesignMode) return;
            mvvmContext.ViewModelType = typeof(T);
            mvvmContext.RegisterService(GetDocumentService());
            var fluentAPI = mvvmContext.OfType<T>();
            T mainModel = mvvmContext.GetViewModel<T>();
            fluentAPI.WithEvent(this, "Load").EventToCommand(x => x.OnLoad());
        }
        protected virtual DocumentManagerService GetDocumentService() {
            return null;
        }
    }
}