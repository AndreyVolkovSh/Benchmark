using Benchmark.Win.ViewModels;
using DevExpress.XtraEditors;

namespace Benchmark.Win.Views {
    public partial class TabVenderView : TabBaseView {
        public TabVenderView() {
            InitializeComponent();
            InitializeContext<TabVenderViewModel>();
            InitializeLookUp(lookUpEdit);
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            OnLoadContext<TabVenderViewModel>();
            var fluentAPI = GetFluentAPI<TabVenderViewModel>();
            fluentAPI.SetBinding(lookUpEdit.Properties, x => x.DataSource, y => y.Venders);
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