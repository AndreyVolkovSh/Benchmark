using System.ComponentModel;
using System.Linq;
using Benchmark;
using DevExpress.XtraTreeList;

namespace TreeList.Tests {
    [BenchmarkFixture]
    public class SimpleTests : TestBase {
        DevExpress.XtraTreeList.TreeList treeList;
        DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;        
        DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private BindingList<Item> _Items;
        [Benchmark(ManualMode = true)]
        public void Test() {
            foreach(var item in _Items)
                item.Description += "!";
            RaiseCompleted(this);

        }
        [Benchmark(ManualMode=true)]
        public void Test1() {
            treeList.BeginUpdate();
            foreach(var item in _Items)
                item.Description += "!";
            treeList.EndUpdate();
            RaiseCompleted(this);
        }
        protected override void SetUpCore(System.Windows.Forms.Form owner) {
            base.SetUpCore(owner);
            treeList = new DevExpress.XtraTreeList.TreeList();
            treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            _Items = new BindingList<Item>();
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
            this.treeListColumn1.FieldName = "IsSelected";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.treeListColumn2.Caption = "treeListColumn2";
            this.treeListColumn2.FieldName = "Description";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            foreach(var item in Enumerable.Range(1, 200).Select(index => new Item { Description = index.ToString() }))
                _Items.Add(item);
            treeList.DataSource = _Items;
            treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            treeList.Parent = owner;
            treeList.Paint += treeList_Paint;
        }

        void treeList_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            treeList.BeginInvoke(new System.Action(() => RaiseReady(this)));
        }
        protected override void TearDownCore() {
            base.TearDownCore();
            treeList.Paint -= treeList_Paint;
            treeList.Dispose();
            _Items.Clear();
        }
    }
    public class Item : INotifyPropertyChanged {
        private bool _IsSelected;
        private string _Description;
        private bool _IrrelevantProperty;

        public bool IsSelected {
            get {
                return _IsSelected;
            }
            set {
                _IsSelected = value;
                OnPropertyChanged();
            }
        }

        public string Description {
            get {
                return _Description;
            }
            set {
                _Description = value;
                OnPropertyChanged();
            }
        }

        public bool IrrelevantProperty {
            get {
                return _IrrelevantProperty;
            }
            set {
                _IrrelevantProperty = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null) {
            if(PropertyChanged == null) return;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}