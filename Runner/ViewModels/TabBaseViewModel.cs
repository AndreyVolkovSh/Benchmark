using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Benchmark.Common;

namespace Benchmark.ViewModels {
    public abstract class TabBaseViewModel : DocumentViewModel {
        public TabBaseViewModel() {
            UpdateDataSource();
        }
        public virtual string CheckedListLabel {
            get;
            set;
        }
        public virtual string ButtonText {
            get;
            set;
        }
        public virtual object DataSource {
            get;
            set;
        }
        protected virtual void UpdateDataSource() {
            DataSource = GetDataSource();
        }
        protected virtual BindingList<CheckedItem> GetDataSource() {
            return null;
        }
        public void OnAdd() {
            OnAddCore();
            UpdateDataSource();
        }
        protected abstract void OnAddCore();
        protected IEnumerable<string> GetDataChecked() {
            IEnumerable<CheckedItem> dataSource = DataSource as IEnumerable<CheckedItem>;
            if(dataSource == null) return null;
            return dataSource.Where(x => x.Checked).Select(x => x.Name);
        }
    }
}