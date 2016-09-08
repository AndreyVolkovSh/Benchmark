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
            List<Data> data = new List<Data>();
            for(int i = 0; i < 1000; i++) {
                data.Add(new Data() { A = i.ToString() });
            }
            control.Grid.DataSource = data;
        }
    }
    [BenchmarkFixture]
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
            control.Visible = true;
            control.Dock = System.Windows.Forms.DockStyle.Fill;
            control.Parent = owner;
        }
        protected override void TearDownCore() {
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
            control.Dispose();
            base.TearDownCore();
        }
    }
    [BenchmarkFixture(Category = "InstantFeedback", ManualMode = true)]
    public class InstantFeedbackUITests : GridGroupingSortingTests {
        protected override void SetUpCore(Form owner) {
            base.SetUpCore(owner);
            control.Ready += OnReady;
            control.Completed += OnCompleted;
            control.InstantFeedbackUI();
        }
        void OnReady(object sender, System.EventArgs e) {
            RaiseReady(sender);
        }
        protected void OnCompleted(object sender, System.EventArgs e) {
            RaiseCompleted(sender);
        }
        protected override void TearDownCore() {
            control.Completed -= OnCompleted;
            control.Ready -= OnReady;
            base.TearDownCore();
        }
    }
    [BenchmarkFixture(Category = "Sql")]
    public class SQLTableTests : GridGroupingSortingTests {
        protected override void SetUpCore(Form owner) {
            base.SetUpCore(owner);
            control.SQLTable();
        }

    }
    [BenchmarkFixture(Category = "ServerMode", ManualMode = true)]
    public class ServerModeTests : GridGroupingSortingTests {
        protected override void SetUpCore(Form owner) {
            base.SetUpCore(owner);
            control.Ready += OnReady;
            control.Completed += OnCompleted;
            control.ServerMode();
        }
        void OnReady(object sender, System.EventArgs e) {
            RaiseReady(sender);
        }
        protected void OnCompleted(object sender, System.EventArgs e) {
            RaiseCompleted(sender);
        }
        protected override void TearDownCore() {
            control.Completed -= OnCompleted;
            control.Ready -= OnReady;
            base.TearDownCore();
        }
    }
}