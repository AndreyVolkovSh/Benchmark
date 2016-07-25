using System;

namespace Benchmark {
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class BenchmarkFixtureAttribute : Attribute {
        public BenchmarkFixtureAttribute() { }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class BenchmarkAttribute : Attribute {
        public BenchmarkAttribute() { }
    }
    [AttributeUsage(AttributeTargets.Event, AllowMultiple = false)]
    public class BenchmarkCompletedAttribute : Attribute {
        public BenchmarkCompletedAttribute() { }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TearDownAttribute : Attribute {
        public TearDownAttribute() { }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SetUpAttribute : Attribute {
        public SetUpAttribute() { }
    }
}