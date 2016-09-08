
namespace Benchmark.Common {
    public class CheckedItem {
        public CheckedItem(string name) {
            Name = name;
        }
        public bool Checked {
            get;
            set;
        }
        public string Name {
            get;
            set;
        }
        public object Tag {
            get;
            set;
        }
    }
}
