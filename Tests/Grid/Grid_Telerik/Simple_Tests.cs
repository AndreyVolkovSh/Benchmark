using System.Collections.Generic;
using System.Windows.Forms;
using Profiler;

namespace Grid.Tests {
    [TestFixtureProfiler]
    public class Data_Tests : TestBase {
        RadGridControl control;
        protected override void SetUpCore(System.Windows.Forms.Form owner) {
            base.SetUpCore(owner);
            control = new RadGridControl();
            control.Visible = true;
            control.Dock = System.Windows.Forms.DockStyle.Fill;
            control.Parent = owner;
            control.Grid.DataBindingComplete += Grid_DataBindingComplete;
        }
        protected override void TearDownCore() {
            control.Grid.DataBindingComplete -= Grid_DataBindingComplete;
            control.Dispose();
            base.TearDownCore();
        }
        [TestProfiler]
        public void LoadData_Test() {

            List<Data> data = new List<Data>();
            for(int i = 0; i < 1000; i++) {
                data.Add(new Data() { A = i.ToString() });
            }
            control.Grid.DataSource = data;
        }

        void Grid_DataBindingComplete(object sender, Telerik.WinControls.UI.GridViewBindingCompleteEventArgs e) {
            RaiseCompleted(control);
        }
    }
    public class Filter_Tests : TestBase {
        RadGridControl control;
        protected override void SetUpCore(System.Windows.Forms.Form owner) {
            base.SetUpCore(owner);
            control = new RadGridControl();
            List<Data> data = new List<Data>();
            for(int i = 0; i < 1000; i++) {
                data.Add(new Data() { A = i.ToString() });
            }
            control.Grid.DataSource = data;
            control.Grid.AllowSearchRow = true;
            control.Grid.MasterView.TableSearchRow.SearchProgressChanged += TableSearchRow_SearchProgressChanged;
            control.Visible = true;
            control.Dock = System.Windows.Forms.DockStyle.Fill;
            control.Parent = owner;
        }

        void TableSearchRow_SearchProgressChanged(object sender, Telerik.WinControls.UI.SearchProgressChangedEventArgs e) {
            if(e.SearchFinished)
                RaiseCompleted(control);
        }
        protected override void TearDownCore() {
            control.Grid.MasterView.TableSearchRow.SearchProgressChanged -= TableSearchRow_SearchProgressChanged;
            control.Dispose();
            base.TearDownCore();
        }
        [TestProfiler]
        public void FindFilterText_Test() {
            control.Grid.TableElement.SearchHighlightColor = System.Drawing.Color.LightBlue;
            control.Grid.MasterView.TableSearchRow.Search("5");
        }
    }
    class Data {
        public string A {
            get;
            set;
        }
    }
}