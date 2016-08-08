using System;
using System.Windows.Forms;

namespace Benchmark {
    public class TestBase {
        [TearDown]
        public void TearDown() {
            TearDownCore();
        }
        [SetUp]
        public void SetUp(Form owner) {
            SetUpCore(owner);
        }
        [BenchmarkCompleted]
        public event EventHandler TestCompleted;
        protected virtual void RaiseCompleted(object sender) {
            if(TestCompleted == null)
                return;            
            TestCompleted(sender, EventArgs.Empty);
        }
        protected virtual void TearDownCore() { }
        protected virtual void SetUpCore(Form owner) { }
    }
}