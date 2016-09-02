using Benchmark.Win.ViewModels;

namespace Benchmark.Win.Views {
    public partial class TabBaseView : DocumentView {
        public TabBaseView() {
            InitializeComponent();
        }
        protected virtual void OnLoadContext<T>() where T : TabBaseViewModel {
            var fluentAPI = GetFluentAPI<T>();
            fluentAPI.SetBinding(textEditLabel, x => x.Text, y => y.EditLabel);
            fluentAPI.SetBinding(checkedListLabel, x => x.Text, y => y.CheckedListLabel);
            fluentAPI.SetBinding(addButton, x => x.Text, y => y.ButtonText);
            fluentAPI.BindCommand(addButton, x => x.OnAdd());
            fluentAPI.SetBinding(treeList, x => x.DataSource, y => y.DataSource);
        }
    }
}