using System;

namespace Benchmark {
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class BenchmarkFixtureAttribute : Attribute {
        public BenchmarkFixtureAttribute() { }
        public string Category {
            get;
            set;
        }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class BenchmarkAttribute : Attribute {
        public BenchmarkAttribute() { }
        public string Name {
            get;
            set;
        }
        public bool ManualMode {
            get;
            set;
        }
    }
    [AttributeUsage(AttributeTargets.Event, AllowMultiple = false)]
    public class BenchmarkCompletedAttribute : Attribute {
        public BenchmarkCompletedAttribute() { }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class BenchmarkTearDownAttribute : Attribute {
        public BenchmarkTearDownAttribute() { }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class BenchmarkSetUpAttribute : Attribute {
        public BenchmarkSetUpAttribute() { }
    }
    [AttributeUsage(AttributeTargets.Assembly)]
    public class AssemblyBenchmark : Attribute {
        public string Product {
            get;
            set;
        }
        public string Vender {
            get;
            set;
        }
    }
}