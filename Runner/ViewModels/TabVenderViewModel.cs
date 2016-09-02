using System.Collections.Generic;
using System.ComponentModel;

namespace Benchmark.Win.ViewModels {
    public class TabVenderViewModel : TabBaseViewModel {
        public TabVenderViewModel() {
            EditLabel = "Vender:";
            CheckedListLabel = "Products:";
            ButtonText = "Add vender";
        }
        public virtual List<string> Venders {
            get;
            set;
        }
        public override void OnAdd() {
            GenerateVender();
        }
        public override void Update() {
            base.Update();
            Venders = TabBaseData.Venders;
        }
        protected void GenerateVender() {
        }
        protected override BindingList<TabBaseViewModel.Node> GetDataSource() {
            if(TabBaseData.Venders == null) return null;
            BindingList<TabBaseViewModel.Node> nodes = new BindingList<TabBaseViewModel.Node>();
            foreach(string vender in TabBaseData.Products)
                nodes.Add(new TabBaseViewModel.Node(vender));
            return nodes;
        }
        protected override object GetTitle() {
            return "Add vender";
        }
    }
}