
namespace Benchmark.Runner {
    public class TestResult {
        public TestResult() { }
        public string Category {
            get;
            set;
        }
        public string TestName {
            get;
            set;
        }
        public double FirstPerfomance {
            get;
            set;
        }
        public double BestPerfomance {
            get;
            set;
        }
        public double BadPerfomance {
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
        public string Vender {
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
            this.Vender = result.Vender;
            this.Product = result.Product;
        }
    }
}