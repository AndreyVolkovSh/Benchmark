using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using Profiler;

namespace Grid.Tests {
    [TestFixtureProfiler]
    public class Data_Tests : TestBase {
        Timer t;
        DevExpressGrid control;
        protected override void SetUpCore(System.Windows.Forms.Form owner) {
            base.SetUpCore(owner);
            control = new DevExpressGrid();
            control.Visible = true;
            control.Dock = System.Windows.Forms.DockStyle.Fill;
            control.Parent = owner;
            t = new Timer();
            t.Interval = 1000;
            t.Tick += t_Tick;
        }

        void t_Tick(object sender, System.EventArgs e) {
            t.Stop();
            control.BeginInvoke(new System.Action(() => RaiseCompleted(control)));
        }
        protected override void TearDownCore() {
            control.Grid.Paint -= Grid_Paint;
            control.Dispose();
            base.TearDownCore();
        }
        [TestProfiler]
        public void LoadData_Test() {
            List<Data> data = new List<Data>();
            for(int i = 0; i < 1000; i++) {
                data.Add(new Data() { A = i.ToString() });
            }
            control.Grid.Paint += Grid_Paint;
            control.Grid.DataSource = data;
        }

        void Grid_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            t.Start();
        }
    }
    public class Filter_Tests : TestBase {        
        DevExpressGrid control;
        protected override void SetUpCore(System.Windows.Forms.Form owner) {
            base.SetUpCore(owner);
            control = new DevExpressGrid();
            List<Data> data = new List<Data>();
            for(int i = 0; i < 1000; i++) {
                data.Add(new Data() { A = i.ToString() });
            }
            control.Grid.DataSource = data;
            ((ColumnView)control.Grid.MainView).Layout += Filter_Tests_Layout;
            control.Visible = true;
            control.Dock = System.Windows.Forms.DockStyle.Fill;
            control.Parent = owner;
        }
        void Filter_Tests_Layout(object sender, System.EventArgs e) {
            RaiseCompleted(control);
        }
        protected override void TearDownCore() {
            ((DevExpress.XtraGrid.Views.Base.ColumnView)control.Grid.MainView).Layout -= Filter_Tests_Layout;
            control.Dispose();
            base.TearDownCore();
        }
        [TestProfiler]
        public void FindFilterText_Test() {
            ((ColumnView)control.Grid.MainView).FindFilterText = "5";
        }
    }
    class Data {
        public string A {
            get;
            set;
        }
    }
}