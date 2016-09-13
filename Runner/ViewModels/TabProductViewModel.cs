using System.ComponentModel;
using Benchmark.Runner;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace Benchmark.ViewModels {
    public class TabProductViewModel : TabBaseViewModel {
        public TabProductViewModel() {
            CheckedListLabel = "Scopes:";
            ButtonText = "Add product";
            Messenger.Default.Register<Common.RequeryProducts>(this, (x) => UpdateDataSource());
        }
        public string Product {
            get;
            set;
        }
        protected override void OnAddCore() {
            RegistrationService.Service.RegisterProduct(Product, GetDataChecked());
            Messenger.Default.Send(new Common.RequeryScopes());
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