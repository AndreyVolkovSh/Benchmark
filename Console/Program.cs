using System;
using System.Collections.Generic;
using System.IO;
using Benchmark.Common;
using Benchmark.Runner;

namespace Benchmark.Console {
    class Program {
        static void Main(string[] args) {
            Arguments arguments = Arguments.Parse(args);
            if(arguments.Build)
                Launcher.BuildSolutions(arguments.Settings);
            if(string.IsNullOrEmpty(arguments.Assemblies))
                throw (new Exception());
            IEnumerable<TestLoader> tests = AssemblyLoad(arguments.Assemblies.Split(';'));
            Launcher.Start(arguments.Settings, tests);
        }
        static IEnumerable<TestLoader> AssemblyLoad(string[] assemblies) {
            if(assemblies == null) return null;
            List<TestLoader> tests = new List<TestLoader>();
            foreach(string assembly in assemblies) {
                if(!File.Exists(assembly)) continue;
                AssemblyLoader loader = AssemblyLoader.Load(assembly);
                if(loader != null)
                    tests.AddRange(loader.GetTests());
            }
            return tests;
        }
    }
    class Arguments {
        string assembliesCore;
        Arguments() {
            Settings = new Settings();
            Build = false;
            assembliesCore = string.Empty;
        }
        public Settings Settings {
            get;
            internal set;
        }
        public bool Build {
            get;
            internal set;
        }
        public string Assemblies {
            get { return assembliesCore; }
            internal set {
                if(!string.IsNullOrEmpty(Assemblies))
                    throw (new Exception());
                assembliesCore = value;
            }
        }
        public static Arguments Parse(string[] args) {
            Arguments arguments = new Arguments();
            foreach(string arg in args)
                Command.GetCommand(arg).Apply(arguments);
            return arguments;
        }
    }
}