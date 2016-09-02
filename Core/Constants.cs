
namespace Benchmark {
    public class Constants {
        public const string
            ProjectFile_User = "Benchmark.Templates.TestProject.csproj.user",
            ProjectFile = "Benchmark.Templates.TestProject.csproj",
            TemplateFile = "Benchmark.Templates.TestForm.cs",
            TemplateManualFile = "Benchmark.Templates.ManualTestForm.cs",
            TestObject = "testObject",
            LogKey = @"SYSTEM\CurrentControlSet\services\eventlog\" + LogName,
            LogName = "DX_Benchmark_Log",
            //BaseClass = "System.Object",
            NGenFormat = @"NGen\\{0}\\ngen.exe",
            x64 = "x64",
            x86 = "x86",
            EXE = ".exe",
            NGetInstall = "install",
            NGenUninstall = "uninstall",
            TelerikLicenseCaption = "Evaluation Copy",
            //TelerikLicenseName = "WindowsForms10.Window.8.app.0.141b42a_r12_ad1",
            DXLicenseCaption = "About DevExpress",
            DXLicenseName = "WindowsForms10.Window.8.app.0.182b0e9_r36_ad1",
            TestAssembliesPath = AssembliesFolder + "Tests\\",
            AssembliesFolder = "Assemblies\\",
            TestsPathFormat = "{0}\\" + TestsFolder,
            TestsFolder = "Tests\\",
            TestFullNameFormat = "{0}.{1}.{2}.{3}",
            TempFolder = "Temp\\",
            BuildBat = "BuildSolution.bat",
            FrameworkKey = "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\",
            ToolVersionKey = "SOFTWARE\\Microsoft\\MSBuild\\";
    }
}