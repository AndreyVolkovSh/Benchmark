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
            var fluentAPI = OnLoadContext<TabScopeViewModel>();
            fluentAPI.SetBinding(lookUpEdit.Properties, x => x.DataSource, y => y.Scopes);
            fluentAPI.SetBinding(lookUpEdit, x => x.Text, y => y.Scope);
        }
        void InitializeLookUp(LookUpEdit lookUp) {
            lookUp.Properties.PopupSizeable = false;
            lookUp.Properties.ShowFooter = false;
            lookUp.Properties.ShowHeader = false;
            lookUp.Properties.UseDropDownRowsAsMaxCount = true;
            lookUp.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lookUp.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            lookUp.Properties.ImmediatePopup = false;
            lookUp.Properties.NullValuePrompt = "New scope";
            lookUp.Properties.NullValuePromptShowForEmptyValue = true;
            lookUp.Properties.ShowNullValuePromptWhenFocused = true;
        }
    }
}