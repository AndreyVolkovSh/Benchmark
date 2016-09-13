using System.Collections.Generic;
using System.ComponentModel;
using Benchmark.Runner;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace Benchmark.ViewModels {
    public class TabScopeViewModel : TabBaseViewModel {
        public TabScopeViewModel() {            
            CheckedListLabel = "Products:";
            ButtonText = "Add scope";
            Messenger.Default.Register<Common.RequeryScopes>(this, (x) => UpdateDataSource());
        }
        public virtual IEnumerable<string> Scopes {
            get;
            set;
        }
        public string Scope {
            get;
            set;
        }
        protected override void OnAddCore() {
            RegistrationService.Service.RegisterScope(Scope, GetDataChecked());
            Messenger.Default.Send(new Common.RequeryProducts());
        }
        protected override void UpdateDataSource() {
            base.UpdateDataSource();
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