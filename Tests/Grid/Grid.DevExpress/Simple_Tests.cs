using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using Benchmark;

namespace Grid.Tests {
    [BenchmarkFixture]
    public class Data_Tests : TestBase {
        DevExpressGrid control;
        protected override void SetUpCore(System.Windows.Forms.Form owner) {
            base.SetUpCore(owner);
            control = new DevExpressGrid();
            control.Visible = true;
            control.Dock = System.Windows.Forms.DockStyle.Fill;
            control.Parent = owner;
        }
        protected override void TearDownCore() {
            control.Dispose();
            base.TearDownCore();
        }
        [Benchmark]
        public void LoadData_Test() {
            control.Grid.DataSourceChanged += Grid_DataSourceChanged;
            List<Data> data = new List<Data>();
            for(int i = 0; i < 1000; i++) {
                data.Add(new Data() { A = i.ToString() });
            }
            control.Grid.DataSource = data;
        }

        void Grid_DataSourceChanged(object sender, System.EventArgs e) {
            RaiseCompleted(control);
            control.Grid.DataSourceChanged -= Grid_DataSourceChanged;
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
        [Benchmark]
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

    public class GridGroupingSortingTests : TestBase {
        protected TestGridGroupingSorting control;
        protected override void SetUpCore(Form owner) {
            base.SetUpCore(owner);
            control = new TestGridGroupingSorting();
            control.Visible = true;
            control.Dock = System.Windows.Forms.DockStyle.Fill;
            control.Parent = owner;
            control.Completed += OnCompleted;
        }
        protected void OnCompleted(object sender, System.EventArgs e) {
            RaiseCompleted(sender);
        }
        [Benchmark]
        public void Group_1() {
            control.Group_1();
        }
        [Benchmark]
        public void Group_2() {
            control.Group_2();
        }
        [Benchmark]
        public void Sort_1() {
            control.Sort_1();
        }
        [Benchmark]
        public void Sort_2() {
            control.Sort_2();
        }
        protected override void TearDownCore() {
            control.Completed -= OnCompleted;
            control.Dispose();
            base.TearDownCore();
        }
    }
    [BenchmarkFixture]
    public class InstantFeedbackUITests : GridGroupingSortingTests {
        protected override void SetUpCore(Form owner) {
            base.SetUpCore(owner);
            control.InstantFeedbackUI();
        }
    }
    [BenchmarkFixture]
    public class SQLTableTests : GridGroupingSortingTests {
        protected override void SetUpCore(Form owner) {
            base.SetUpCore(owner);
            control.SQLTable();
        }
    }
    [BenchmarkFixture]
    public class ServerModeTests : GridGroupingSortingTests {
        protected override void SetUpCore(Form owner) {
            base.SetUpCore(owner);
            control.ServerMode();
        }
    }
}