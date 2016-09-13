using System.Collections.Generic;
using Benchmark.Internal;

namespace Benchmark.Common {
    public static class ResourceService {
        static Dictionary<string, string> hashResources = new Dictionary<string, string>();
        public static string Solution {
            get { return GetTestsProject(ResourceNames.SolutionFile); }
        }
        public static string Project {
            get { return GetTestsProject(ResourceNames.ProjectFile); }
        }
        public static string ProjectUser {
            get { return GetTestsProject(ResourceNames.ProjectUserFile); }
        }
        public static string AssemblyInfo {
            get { return GetTestsProject(ResourceNames.AssemblyInfoFile); }
        }
        public static string SimpleTests {
            get { return GetTestsProject(ResourceNames.SimpleTestsFile); }
        }
        public static string TestProject {
            get { return GetTestProject(ResourceNames.TestProjectFile); }
        }
        public static string TestProjectUser {
            get { return GetTestProject(ResourceNames.TestProjectUserFile); }
        }
        public static string AppConfig {
            get { return GetResource(ResourceNames.AppConfig); }
        }
        public static string ProjectConfiguration {
            get {
                return
"\t\t{{Guid}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU" + System.Environment.NewLine +
"\t\t{{Guid}}.Debug|Any CPU.Build.0 = Debug|Any CPU" + System.Environment.NewLine +
"\t\t{{Guid}}.Release|Any CPU.ActiveCfg = Release|Any CPU" + System.Environment.NewLine +
"\t\t{{Guid}}.Release|Any CPU.Build.0 = Release|Any CPU" + System.Environment.NewLine + "\t";
            }
        }
        public static string ProjectBlock {
            get { return "Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"{AssemblyName}\", \"" + @"{AssemblyName}\{AssemblyName}.csproj" + "\", \"{{Guid}}\"	" + System.Environment.NewLine + "EndProject"; }
        }
        static string GetTestsProject(string name) {
            return GetResource(ResourceNames.TestsFolder + name);
        }
        static string GetTestProject(string name) {
            return GetResource(ResourceNames.TestFolder + name);
        }
        static string GetResource(string name) {
            string value;
            name = ResourceNames.GetResourceName(name);
            hashResources.TryGetValue(name, out value);
            if(string.IsNullOrEmpty(value))
                value = AddHash(name);
            return value;
        }
        static string AddHash(string name) {
            string value = ResourceHelper.GetString(typeof(ResourceService), name);
            if(!string.IsNullOrEmpty(value))
                hashResources.Add(name, value);
            return value;
        }
    }
}