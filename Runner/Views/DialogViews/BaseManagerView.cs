using System.Windows.Forms;
using Benchmark.ViewModels;
using DevExpress.Utils.MVVM;

namespace Benchmark.Views {
    public partial class BaseManagerView : UserControl {
        public BaseManagerView() {
            InitializeComponent();
        }
        protected MVVMContext Context {
            get { return mvvmContext; }
        }
        protected virtual MVVMContextFluentAPI<T> GetFluentAPI<T>() where T : BaseManagerViewModel {
            return mvvmContext.OfType<T>();
        }
        protected virtual void InitializeContext<T>() where T : BaseManagerViewModel {
            if(mvvmContext.IsDesignMode) return;
            mvvmContext.ViewModelType = typeof(T);
        }
        protected virtual MVVMContextFluentAPI<T> OnLoadContext<T>() where T : BaseManagerViewModel {
            var fluentAPI = GetFluentAPI<T>();
            fluentAPI.SetBinding(treeList, x => x.DataSource, y => y.DataSource);
            return fluentAPI;
        }
    }
}