
namespace Benchmark.Runner {
    public class TestResult {
        public TestResult(string testName) {
            TestName = testName;
        }
        public TestResult(string testName, string category) {
            TestName = testName;
            Category = category;
        }
        public string Category {
            get;
            set;
        }
        public string TestName {
            get;
            private set;
        }
        public int FirstPerfomance {
            get;
            set;
        }
        public int BestPerfomance {
            get;
            set;
        }
        public int BadPerfomance {
            get;
            set;
        }
        public double MedianPerfomance {
            get;
            set;
        }
        public string Product {
            get;
            set;
        }
        public string Rival {
            get;
            set;
        }
        public virtual void Assign(TestResult result) {
            this.Category = result.Category;
            this.TestName = result.TestName;
            this.BadPerfomance = result.BadPerfomance;
            this.BestPerfomance = result.BestPerfomance;
            this.FirstPerfomance = result.FirstPerfomance;
            this.MedianPerfomance = result.MedianPerfomance;
            this.Rival = result.Rival;
            this.Product = result.Product;
        }
    }
}