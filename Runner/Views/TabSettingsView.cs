using Benchmark.Win.ViewModels;
using DevExpress.XtraEditors;

namespace Benchmark.Win.Views {
    public partial class TabSettingsView : DocumentView {
        public TabSettingsView() {
            InitializeComponent();
            InitializeContext<TabSettingsViewModel>();
            InitializeComboBox<Platform>(platformComboBox);
            InitializeLookUp(frameworkLookUp);
            InitializeLookUp(toolVersionLookUp);
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            var fluentAPI = GetFluentAPI<TabSettingsViewModel>();
            fluentAPI.SetBinding(frameworkLookUp.Properties, x => x.DataSource, y => y.Frameworks);
            fluentAPI.SetBinding(toolVersionLookUp.Properties, x => x.DataSource, y => y.ToolVersions);
            fluentAPI.SetBinding(platformComboBox, x => x.EditValue, y => y.Platform);
            fluentAPI.SetBinding(frameworkLookUp, x => x.EditValue, y => y.Framework);
            fluentAPI.SetBinding(toolVersionLookUp, x => x.EditValue, y => y.ToolVersion);
            fluentAPI.SetBinding(enableNGen, x => x.EditValue, y => y.EnableNGen);
            fluentAPI.BindCommand(buildSolutionsButton, x => x.OnBuild());
        }
        void InitializeComboBox<T>(ImageComboBoxEdit comboBox) {
            comboBox.Properties.AddEnum<T>();
        }
        void InitializeLookUp(LookUpEdit lookUp) {
            lookUp.Properties.PopupSizeable = false;
            lookUp.Properties.ShowFooter = false;
            lookUp.Properties.ShowHeader = false;
            lookUp.Properties.UseDropDownRowsAsMaxCount = true;
        }
    }
}