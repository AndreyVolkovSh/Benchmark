using System.Windows.Forms;
using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;

namespace Benchmark.Views {
    public partial class DocumentView : UserControl {
        public DocumentView() {
            InitializeComponent();
        }
        protected MVVMContext Context {
            get { return mvvmContext; }
        }
        protected virtual MVVMContextFluentAPI<T> GetFluentAPI<T>() where T : class, IDocumentContent {
            return mvvmContext.OfType<T>();
        }
        protected virtual void InitializeContext<T>() where T : IDocumentContent {
            if(mvvmContext.IsDesignMode) return;
            mvvmContext.ViewModelType = typeof(T);
        }
    }
}