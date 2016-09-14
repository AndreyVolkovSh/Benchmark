using Benchmark.ViewModels;
using DevExpress.XtraEditors;

namespace Benchmark.Views {
    public partial class TabProductView : TabBaseView {
        public TabProductView() {
            InitializeComponent();
            InitializeContext<TabProductViewModel>();
            InitializeTextEdit(textEdit);
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            var fluentAPI = OnLoadContext<TabProductViewModel>();
            fluentAPI.SetBinding(textEdit, x => x.Text, y => y.Product);
        }
        void InitializeTextEdit(TextEdit textEdit) {
            textEdit.Properties.NullValuePrompt = "New product";
            textEdit.Properties.ShowNullValuePromptWhenFocused = true;
        }
    }
}