using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;

namespace Benchmark.Common {
    public class ProductTreeList : TreeList {
        string rootNodeFormat = "{0}/{1}";
        public ProductTreeList() {
            OptionsBehavior.AllowRecursiveNodeChecking = true;
            OptionsView.ShowIndicator = false;
            OptionsView.ShowCheckBoxes = true;
            //OptionsView.ShowColumns = false;
            OptionsBehavior.ReadOnly = true;
            OptionsBehavior.Editable = false;
            OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            OptionsBehavior.EnableFiltering = true;
            OptionsBehavior.ExpandNodesOnFiltering = true;
            GenerateColumns();
        }
        protected void GenerateColumns() {
            if(IsDesignMode) return;
            TreeListColumn nameColumn = new TreeListColumn();
            nameColumn.Caption = "Name";
            nameColumn.Name = "nameColumn";
            nameColumn.Visible = true;
            nameColumn.VisibleIndex = 0;
            Columns.Add(nameColumn);
            TreeListColumn scopeColumn = new TreeListColumn();
            scopeColumn.Caption = "Scope";
            scopeColumn.Name = "scopeColumn";
            scopeColumn.VisibleIndex = 1;
            scopeColumn.Visible = true;
            Columns.Add(scopeColumn);
        }
        public void PopulateNodes(IEnumerable<TestLoader> tests) {
            Nodes.Clear();
            string targetKey = string.Empty;
            TreeListNode currentNode = null;
            foreach(TestLoader test in tests) {
                string sourceKey = string.Format(rootNodeFormat, test.Product, test.Category);
                if(targetKey != sourceKey) {
                    targetKey = sourceKey;
                    currentNode = null;
                }
                if(currentNode == null)
                    currentNode = AddRootNode(targetKey);
                AddNode(test.Name, test.Scope, currentNode, test);
            }
        }
        protected TreeListNode AddRootNode(string value) {
            return AddNode(value, null, null, null);
        }
        protected TreeListNode AddNode(string value, string scope, TreeListNode parent, object tag) {
            return AppendNode(new object[] { value, scope }, parent, tag);
        }
        protected override TreeListNode CreateNode(int nodeID, TreeListNodes owner, object tag) {
            if(tag is TestLoader)
                return new TestNode(nodeID, owner);
            return base.CreateNode(nodeID, owner, tag);
        }
    }
    public class TestNode : TreeListNode {
        public TestNode(int index, TreeListNodes nodes)
            : base(index, nodes) {
        }
        public override CheckState CheckState {
            get { return base.CheckState; }
            set {
                base.CheckState = value;
                Test.Enabled = Checked;
            }
        }
        TestLoader Test {
            get { return Tag as TestLoader; }
        }
        public override bool HasChildren {
            get { return false; }
            set { }
        }
    }
}