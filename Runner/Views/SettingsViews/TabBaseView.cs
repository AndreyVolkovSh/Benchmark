﻿using Benchmark.ViewModels;

namespace Benchmark.Views {
    public partial class TabBaseView : DocumentView {
        public TabBaseView() {
            InitializeComponent();
        }
        protected virtual DevExpress.Utils.MVVM.MVVMContextFluentAPI<T> OnLoadContext<T>() where T : TabBaseViewModel {
            var fluentAPI = GetFluentAPI<T>();
            fluentAPI.SetBinding(checkedListItem, x => x.Text, y => y.CheckedListLabel);
            fluentAPI.SetBinding(addButton, x => x.Text, y => y.ButtonText);
            fluentAPI.BindCommand(addButton, x => x.OnAdd());
            fluentAPI.SetBinding(treeList, x => x.DataSource, y => y.DataSource);
            return fluentAPI;
        }
    }
}