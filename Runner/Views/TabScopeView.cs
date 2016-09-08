using Benchmark.ViewModels;
using DevExpress.XtraEditors;

namespace Benchmark.Views {
    public partial class TabScopeView : TabBaseView {
        public TabScopeView() {
            InitializeComponent();
            InitializeContext<TabScopeViewModel>();
            InitializeLookUp(lookUpEdit);
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            OnLoadContext<TabScopeViewModel>();
            var fluentAPI = GetFluentAPI<TabScopeViewModel>();
            fluentAPI.SetBinding(lookUpEdit.Properties, x => x.DataSource, y => y.Scopes);
            fluentAPI.SetBinding(lookUpEdit, x => x.Text, y => y.Scope);
        }
        void InitializeLookUp(LookUpEdit lookUp) {
            lookUpEdit.Text = string.Empty;
            lookUp.Properties.PopupSizeable = false;
            lookUp.Properties.ShowFooter = false;
            lookUp.Properties.ShowHeader = false;
            lookUp.Properties.UseDropDownRowsAsMaxCount = true;
        }
    }
}