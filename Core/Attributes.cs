using System;

namespace Profiler {
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class TestFixtureProfilerAttribute : Attribute {
        public TestFixtureProfilerAttribute() { }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestProfilerAttribute : Attribute {
        public TestProfilerAttribute() { }
    }
    [AttributeUsage(AttributeTargets.Event, AllowMultiple = false)]
    public class TestCompletedProfilerAttribute : Attribute {
        public TestCompletedProfilerAttribute() { }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TearDownProfilerAttribute : Attribute {
        public TearDownProfilerAttribute() { }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SetUpProfilerAttribute : Attribute {
        public SetUpProfilerAttribute() { }
    }
}