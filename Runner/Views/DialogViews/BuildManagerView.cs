using System;
using Benchmark.ViewModels;

namespace Benchmark.Views {
    public partial class BuildManagerView : BaseManagerView {
        public BuildManagerView() {
            InitializeComponent();
            InitializeContext<BuildManagerViewModel>();
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            var fluentAPI = OnLoadContext<BuildManagerViewModel>();
            fluentAPI.WithEvent(checkEdit, "CheckedChanged")
                .EventToCommand((x) => x.LoadDataSource(true), new Func<EventArgs, object>(GetChecked));
        }
        object GetChecked(EventArgs e) {
            return checkEdit.Checked;
        }
    }
}