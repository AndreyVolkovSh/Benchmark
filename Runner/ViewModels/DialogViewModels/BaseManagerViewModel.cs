using System.Collections.Generic;
using Benchmark.Common;
using System.Linq;

namespace Benchmark.ViewModels {
    public abstract class BaseManagerViewModel {
        public BaseManagerViewModel() { }
        public virtual object DataSource {
            get;
            set;
        }
        protected virtual IEnumerable<CheckedItem> GetCheckedItems() {
            return ((IEnumerable<CheckedItem>)DataSource).Where(item => item.Checked);
        }
    }
}