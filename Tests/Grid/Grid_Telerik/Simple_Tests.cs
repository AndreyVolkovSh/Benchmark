//using System.Collections.Generic;
//using System.Windows.Forms;
//using Profiler;

//namespace Grid.Tests {
//    [TestFixtureProfiler]
//    public class Data_Tests : TestBase {
//        Timer t;
//        Runner grid;
//        protected override void SetUpCore(System.Windows.Forms.Form owner) {
//            base.SetUpCore(owner);
//            grid = new Runner();
//            grid.Visible = true;
//            grid.Dock = System.Windows.Forms.DockStyle.Fill;
//            grid.Parent = owner;
//            t = new Timer();
//            t.Interval = 1000;
//            t.Tick += t_Tick;
//        }

//        void t_Tick(object sender, System.EventArgs e) {
//            t.Stop();
//            grid.BeginInvoke(new System.Action(() => RaiseCompleted(grid)));
//        }
//        protected override void TearDownCore() {
//            grid.Grid.Paint -= Grid_Paint;
//            grid.Dispose();
//            base.TearDownCore();
//        }
//        [TestProfiler]
//        public void LoadData_Test() {
//            List<Data> data = new List<Data>();
//            for(int i = 0; i < 1000; i++) {
//                data.Add(new Data() { A = i.ToString() });
//            }
//            grid.Grid.Paint += Grid_Paint;
//            grid.Grid.DataSource = data;            
//        }

//        void Grid_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
//            t.Start();
//        }
//    }
//    public class Filter_Tests : TestBase {
//        Timer t;
//        Runner grid;
//        protected override void SetUpCore(System.Windows.Forms.Form owner) {
//            base.SetUpCore(owner);
//            grid = new Runner();
//            List<Data> data = new List<Data>();
//            for(int i = 0; i < 1000; i++) {
//                data.Add(new Data() { A = i.ToString() });
//            }            
//            grid.Grid.DataSource = data;
//            ((DevExpress.XtraGrid.Views.Base.ColumnView)grid.Grid.MainView).Layout += Filter_Tests_Layout;
//            grid.Visible = true;
//            grid.Dock = System.Windows.Forms.DockStyle.Fill;
//            grid.Parent = owner;
//            t = new Timer();
//            t.Interval = 1000;
//            t.Tick += t_Tick;
//        }
//        void t_Tick(object sender, System.EventArgs e) {
//            t.Stop();
//            grid.BeginInvoke(new System.Action(() => RaiseCompleted(grid)));
//        }

//        void Filter_Tests_Layout(object sender, System.EventArgs e) {
//            t.Start();
//        }
//        protected override void TearDownCore() {
//            ((DevExpress.XtraGrid.Views.Base.ColumnView)grid.Grid.MainView).Layout -= Filter_Tests_Layout;
//            grid.Dispose();
//            base.TearDownCore();
//        }
//        [TestProfiler]
//        public void FindFilterText_Test() {
//            ((DevExpress.XtraGrid.Views.Base.ColumnView)grid.Grid.MainView).FindFilterText = "5";
//        }
//    }
//    class Data {
//        public string A {
//            get;
//            set;
//        }
//    }
//}