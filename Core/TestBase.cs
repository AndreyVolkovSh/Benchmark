using System;
using System.Windows.Forms;

namespace Profiler {
    [TestFixtureProfiler]
    public class TestBase {
        [TearDownProfiler]
        public void TearDown() {
            TearDownCore();
        }
        [SetUpProfiler]
        public void SetUp(Form owner) {
            SetUpCore(owner);
        }
        [TestCompletedProfiler]
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