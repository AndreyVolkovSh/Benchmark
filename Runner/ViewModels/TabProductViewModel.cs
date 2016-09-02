using System.ComponentModel;

namespace Benchmark.Win.ViewModels {
    public class TabProductViewModel : TabBaseViewModel {
        public TabProductViewModel() {
            EditLabel = "New product:";
            CheckedListLabel = "Venders:";
            ButtonText = "Add product";
        }
        public string Product {
            get;
            set;
        }
        public override void OnAdd() {
            if(TabBaseData.Products.Contains(Product)) return;
            GenerateProduct();
        }
        protected void GenerateProduct() { }
        protected override BindingList<TabBaseViewModel.Node> GetDataSource() {
            if(TabBaseData.Venders == null) return null;
            BindingList<TabBaseViewModel.Node> nodes = new BindingList<TabBaseViewModel.Node>();
            foreach(string vender in TabBaseData.Venders)
                nodes.Add(new TabBaseViewModel.Node(vender));
            return nodes;
        }
        protected override object GetTitle() {
            return "Add product";
        }
    }
}