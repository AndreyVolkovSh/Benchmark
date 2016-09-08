using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Benchmark.Common;

namespace Benchmark.ViewModels {
    public abstract class TabBaseViewModel : DocumentViewModel {
        public TabBaseViewModel() {
            Update();
        }
        public virtual string EditLabel {
            get;
            set;
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
        public virtual void Update() {
            DataSource = GetDataSource();
        }
        protected abstract BindingList<CheckedItem> GetDataSource();
        public abstract void OnAdd();
        protected IEnumerable<string> GetDataChecked() {
            IEnumerable<CheckedItem> dataSource = DataSource as IEnumerable<CheckedItem>;
            if(dataSource == null) return null;
            return dataSource.Where(x => x.Checked).Select(x => x.Name);
        }
    }
}