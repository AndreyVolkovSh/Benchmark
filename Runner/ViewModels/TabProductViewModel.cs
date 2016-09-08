using System.ComponentModel;
using Benchmark.Runner;

namespace Benchmark.ViewModels {
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
            RegistrationService.Service.RegisterProduct(Product, GetDataChecked());
        }
        protected override BindingList<Common.CheckedItem> GetDataSource() {
            if(RegistrationService.Service.Venders == null) return null;
            BindingList<Common.CheckedItem> nodes = new BindingList<Common.CheckedItem>();
            foreach(string vender in RegistrationService.Service.Venders)
                nodes.Add(new Common.CheckedItem(vender));
            return nodes;
        }
        protected override object GetTitle() {
            return "Add product";
        }
    }
}