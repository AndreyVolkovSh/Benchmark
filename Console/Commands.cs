using System;
using System.Linq;
using Benchmark.Common;

namespace Benchmark.Console {
    class PlatformCommand : Command {
        protected override void CheckElements(string[] elements) {
            if(elements.Count() != 2)
                throw (new Exception());
        }
        protected override void InitializeCore(string[] elements) {
            Platform value;
            Enum.TryParse<Platform>(elements[1], out value);
            Value = value;
        }
        protected override void ApplyCore(Arguments arg) {
            arg.Settings.Platform = (Platform)Value;
        }
    }
    class ToolVersionCommand : Command {
        protected override void CheckElements(string[] elements) {
            if(elements.Count() != 2)
                throw (new Exception());
        }
        protected override void InitializeCore(string[] elements) {
            string value = elements[1];
            if(Settings.ToolVersions.Contains(value))
                Value = value;
        }
        protected override void ApplyCore(Arguments arg) {
            arg.Settings.ToolVersion = Value.ToString();
        }
    }
    class BuildCommand : Command {
        protected override void CheckElements(string[] elements) {
            if(elements.Count() != 1)
                throw (new Exception());
        }
        protected override void InitializeCore(string[] elements) {
            Value = true;
        }
        protected override void ApplyCore(Arguments arg) {
            arg.Build = (bool)Value;
        }
    }
    class EnableNGenCommand : Command {
        protected override void CheckElements(string[] elements) {
            if(elements.Count() != 2)
                throw (new Exception());
        }
        protected override void InitializeCore(string[] elements) {
            Value = Command.ToBool(elements[1]);
        }
        protected override void ApplyCore(Arguments arg) {
            arg.Settings.EnableNGen = (bool)Value;
        }
    }
    class FrameworkCommand : Command {
        protected override void CheckElements(string[] elements) {
            if(elements.Count() != 2)
                throw (new Exception());
        }
        protected override void InitializeCore(string[] elements) {
            Value = Settings.Frameworks[elements[1]];
        }
        protected override void ApplyCore(Arguments arg) {
            arg.Settings.Framework = Value as Framework;
        }
    }
    class ProductsCommand : Command {
        protected override void CheckElements(string[] elements) {
            if(elements.Count() != 1)
                throw (new Exception());
        }
        protected override void InitializeCore(string[] elements) {
            Value = elements[0];
        }
        protected override void ApplyCore(Arguments arg) {
            arg.Assemblies = Value.ToString();
        }
    }
    abstract class Command {
        const string
            Platform = "P",
            Framework = "F",
            ToolVersion = "T",
            EnableNGen = "NGen",
            Build = "B";
        protected void Initialize(string[] elements) {
            CheckElements(elements);
            InitializeCore(elements);
        }
        public object Value {
            get;
            protected set;
        }
        protected abstract void CheckElements(string[] elements);
        protected abstract void InitializeCore(string[] elements);
        protected abstract void ApplyCore(Arguments arg);
        public void Apply(Arguments arg) {
            if(Value == null || arg == null) return;
            ApplyCore(arg);
        }
        public static Command GetCommand(string arg) {
            if(string.IsNullOrEmpty(arg))
                throw (new Exception());
            string[] elements = Parce(arg);
            Command command = CreateCommand(elements[0]);
            command.Initialize(elements);
            return command;
        }
        static Command CreateCommand(string command) {
            if(string.IsNullOrEmpty(command))
                throw (new Exception());
            switch(command) {
                case Platform: return new PlatformCommand();
                case Build: return new BuildCommand();
                case ToolVersion: return new ToolVersionCommand();
                case EnableNGen: return new EnableNGenCommand();
                case Framework: return new FrameworkCommand();
                default: return new ProductsCommand();
            }
        }
        static string[] Parce(string arg) {
            if(string.IsNullOrEmpty(arg))
                throw (new Exception());
            string[] elements = arg.Split(new char[] { '/', ':' });
            int count = elements.Count();
            if(count > 2 || count <= 0)
                throw (new Exception());
            return elements;
        }
        public static bool ToBool(string value) {
            value = value.ToUpper();
            return value.Equals("ON");
        }
    }
}