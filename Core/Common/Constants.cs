
namespace Benchmark.Common {
    public class Resolution {
        public const string
            EXE = ".exe",
            PROJ = ".csproj",
            SLN = ".sln",
            ALLProj = "*.*proj",
            USER = ".user",
            CONFIG = ".config",
            DLL = "*.dll";
    }
    public class Commands {
        public const string
            NGetInstall = "install",
            NGenUninstall = "uninstall";
    }
    public class ResourceNames {
        public const string
            TestProjectUserFile = "TestProject.csproj.user",
            TestProjectFile = "TestProject.csproj",
            TestFile = "TestForm.cs",
            ManualTestFile = "ManualTestForm.cs",
            SolutionFile = "Solution.sln",
            ProjectFile = "Project.csproj",
            ProjectUserFile = "Project.csproj.user",
            AssemblyInfoFile = "AssemblyInfo.cs",
            SimpleTestsFile = "SimpleTests.cs",
            TestsFolder = "TestsProject.",
            TestFolder = "TestProject.";
        public static string GetResourceName(string name) {
            return "Benchmark.Resources." + name;
        }
    }
    public class RegisterKeys {
        public const string
            Framework = "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\",
            ToolVersion = "SOFTWARE\\Microsoft\\MSBuild\\",
            LogKey = @"SYSTEM\\CurrentControlSet\\services\\eventlog\\DXBenchmarkLog";
    }
    public class LicenseConstants {
        public const string
            TelerikLicenseCaption = "Evaluation Copy",
            //TelerikLicenseName = "WindowsForms10.Window.8.app.0.141b42a_r12_ad1",
            DXLicenseCaption = "About DevExpress",
            DXLicenseName = "WindowsForms10.Window.8.app.0.182b0e9_r36_ad1";
    }
    public class CommonConstants {
        public const string
            TestObject = "testObject",
            BuildBat = "BuildSolution.bat",
            LogName = "DXBenchmarkLog";
    }
    public class Folders {
        public const string
            TestAssemblies = Assemblies + Tests,
            Assemblies = "Assemblies\\",
            Tests = "Tests\\",
            Temp = "Temp\\",
            Properties = "Properties\\";
    }
    public class Formats {
        public const string
            RootNamespace = "{0}.Tests",
            TestsPath = "{0}\\Tests\\",
            TestFullName = "{0}.{1}.{2}.{3}",
            NGenPath = @"NGen\\{0}\\ngen.exe",
            AssemblyName = "{0}.{1}",
            Args = "{0} {1} {2}";
    }
    public class ReplaceParams {
        public const string
            ProjectsConfiguration = "{ProjectConfigurationPlatforms}",
            Project = "{Project}",
            AssemblyName = "{AssemblyName}",
            Guid = "{Guid}",
            Reference = "{Reference}",
            HintPath = "{HintPath}",
            RootNamespace = "{RootNamespace}",
            Scope = "{Scope}",
            Using = "{Using}",
            Field = "{Field}",
            Initialize = "{Initialize}",
            Test = "{Test}",
            SetUp = "{SetUp}",
            TearDown = "{TearDown}",
            Product = "{Product}",
            Dispose = "{Dispose}",
            Platform = "{Platform}",
            TargetFramework = "{TargetFramework}",
            Global = "Global",
            EndGlobal = "EndGlobalSection";
    }
}