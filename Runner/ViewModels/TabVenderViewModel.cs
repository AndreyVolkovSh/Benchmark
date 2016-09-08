using System.Collections.Generic;
using System.ComponentModel;
using Benchmark.Runner;

namespace Benchmark.ViewModels {
    public class TabVenderViewModel : TabBaseViewModel {
        public TabVenderViewModel() {
            EditLabel = "Vender:";
            CheckedListLabel = "Products:";
            ButtonText = "Add vender";
        }
        public virtual IEnumerable<string> Venders {
            get;
            set;
        }
        public string Vender {
            get;
            set;
        }
        public override void OnAdd() {
            RegistrationService.Service.RegisterVender(Vender, GetDataChecked());
        }
        public override void Update() {
            base.Update();
            Venders = RegistrationService.Service.Venders;
        }
        protected override BindingList<Common.CheckedItem> GetDataSource() {
            if(RegistrationService.Service.Venders == null) return null;
            BindingList<Common.CheckedItem> nodes = new BindingList<Common.CheckedItem>();
            foreach(string vender in RegistrationService.Service.Products)
                nodes.Add(new Common.CheckedItem(vender));
            return nodes;
        }
        protected override object GetTitle() {
            return "Add vender";
        }
    }
}