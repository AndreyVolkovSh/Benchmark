using System.ComponentModel;
using Benchmark.Runner;

namespace Benchmark.ViewModels {
    public class TabProductViewModel : TabBaseViewModel {
        public TabProductViewModel() {
            EditLabel = "New product:";
            CheckedListLabel = "Scopes:";
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
            if(RegistrationService.Service.Scopes == null) return null;
            BindingList<Common.CheckedItem> nodes = new BindingList<Common.CheckedItem>();
            foreach(string scope in RegistrationService.Service.Scopes)
                nodes.Add(new Common.CheckedItem(scope));
            return nodes;
        }
        protected override object GetTitle() {
            return "Add product";
        }
    }
}