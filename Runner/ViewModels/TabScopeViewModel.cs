using System.Collections.Generic;
using System.ComponentModel;
using Benchmark.Runner;

namespace Benchmark.ViewModels {
    public class TabScopeViewModel : TabBaseViewModel {
        public TabScopeViewModel() {
            EditLabel = "Scope:";
            CheckedListLabel = "Products:";
            ButtonText = "Add scope";
        }
        public virtual IEnumerable<string> Scopes {
            get;
            set;
        }
        public string Scope {
            get;
            set;
        }
        public override void OnAdd() {
            RegistrationService.Service.RegisterScope(Scope, GetDataChecked());
        }
        public override void Update() {
            base.Update();
            Scopes = RegistrationService.Service.Scopes;
        }
        protected override BindingList<Common.CheckedItem> GetDataSource() {
            if(RegistrationService.Service.Products == null) return null;
            BindingList<Common.CheckedItem> nodes = new BindingList<Common.CheckedItem>();
            foreach(string product in RegistrationService.Service.Products)
                nodes.Add(new Common.CheckedItem(product));
            return nodes;
        }
        protected override object GetTitle() {
            return "Add scope";
        }
    }
}