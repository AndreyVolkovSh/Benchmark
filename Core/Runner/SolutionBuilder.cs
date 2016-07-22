using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnvDTE;

namespace Profiler.Runner {
    public class SolutionBuilder : IDisposable {
        DTE currentDTE;
        bool isDisposingCore;
        public SolutionBuilder() {
            currentDTE = EnvDTEHelper.CreateDTE();
            MessageFilter.Register();
        }
        public static void BuildAll(string path) {
            string[] solutions = FindSolutions(path);
            if(solutions == null || solutions.Length == 0)
                throw (new Exception());
            using(SolutionBuilder build = new SolutionBuilder()) {
                foreach(string solution in solutions)
                    build.Build(solution);
            }
        }
        public void Build(string solutionPath) {
            if(currentDTE == null) return;
            try {
                if(!File.Exists(solutionPath))
                    throw (new Exception());
                Task task = new Task(PatchLicenses.Task);
                task.Start();
                currentDTE.Solution.Open(solutionPath);
                task.Dispose();
                Solution dteSolution = currentDTE.Solution;
                Build_x86(dteSolution);
                Build_x64(dteSolution);
            }
            catch(Exception e) {
                throw (e);
            }
        }
        protected void Build_x86(Solution dteSolution) {
            //ToDo settings
            SolutionBuild dteBuild = dteSolution.SolutionBuild;            
            dteBuild.Build(true);
            if(dteBuild.BuildState != vsBuildState.vsBuildStateDone)
                throw (new Exception());
        }
        protected void Build_x64(Solution dteSolution) {
            //ToDo settings
            //SolutionBuild dteBuild = dteSolution.SolutionBuild;
            //dteBuild.Build(true);
            //if(dteBuild.BuildState != vsBuildState.vsBuildStateDone)
            //    throw (new Exception());
        }
        public static string[] FindSolutions(string path) {
            if(Directory.Exists(path))
                return Directory.GetFiles(path, "*.sln", SearchOption.AllDirectories);
            return null;
        }
        #region IDisposable Members
        public void Dispose() {
            if(isDisposingCore) return;
            isDisposingCore = true;
            OnDispose();
        }
        protected virtual void OnDispose() {
            if(currentDTE != null) {
                if(currentDTE.Mode == vsIDEMode.vsIDEModeDebug)
                    currentDTE.Debugger.Stop(true);
                if(currentDTE.Solution != null && currentDTE.Solution.IsOpen)
                    currentDTE.Solution.Close();
                currentDTE.Quit();
            }
            MessageFilter.Revoke();
        }
        #endregion
    }
    public static class PatchLicenses {
        public static void Task() {
            Timer timer = new Timer();
            timer.Interval = 200;
            timer.Tick += (sender, e) => Patch();
            timer.Start();
        }
        public static void Patch() {
            IntPtr dialogHandle = WinAPI.FindWindow("#32770", "Telerik UI for WPF Trial");
            if(dialogHandle != IntPtr.Zero) {
                WinAPI.SendMessage(dialogHandle, WinAPI.WM_CLOSE, 0, 0);
            }
            dialogHandle = WinAPI.FindWindow("WindowsForms10.Window.8.app.0.182b0e9_r36_ad1", "About DevExpress");
            if(dialogHandle != IntPtr.Zero) {
                WinAPI.SendMessage(dialogHandle, WinAPI.WM_CLOSE, 0, 0);
            }
        }
    }
    public static class WinAPI {
        [DllImport("USER32.DLL", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string ClassName, string WindowName);
        [DllImport("USER32.DLL", EntryPoint = "SendMessage")]
        public static extern uint SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        public const uint WM_CLOSE = 0x0010;
    }
    public static class EnvDTEHelper {
        public static DTE CreateDTE() {
            try {
                System.Type typeDTE = System.Type.GetTypeFromProgID(Constants.DTE11);
                Object objectDTE = System.Activator.CreateInstance(typeDTE, true);
                if(objectDTE == null) return null;
                return (DTE)objectDTE;
            }
            catch {
                throw new Exception("Visual Studio is not installed");
            }
        }
    }
    class MessageFilter : IOleMessageFilter {
        public static void Register() {
            IOleMessageFilter newFilter = new MessageFilter();
            IOleMessageFilter oldFilter = null;
            CoRegisterMessageFilter(newFilter, out oldFilter);
        }
        public static void Revoke() {
            IOleMessageFilter oldFilter = null;
            CoRegisterMessageFilter(null, out oldFilter);
        }
        int IOleMessageFilter.HandleInComingCall(int dwCallType,
          System.IntPtr hTaskCaller, int dwTickCount, System.IntPtr
          lpInterfaceInfo) {
            return 0;
        }
        int IOleMessageFilter.RetryRejectedCall(System.IntPtr
          hTaskCallee, int dwTickCount, int dwRejectType) {
            if(dwRejectType == 2)
                return 99;
            return -1;
        }
        int IOleMessageFilter.MessagePending(System.IntPtr hTaskCallee,
          int dwTickCount, int dwPendingType) {
            return 2;
        }
        [DllImport("Ole32.dll")]
        private static extern int
          CoRegisterMessageFilter(IOleMessageFilter newFilter, out 
          IOleMessageFilter oldFilter);
    }
    [ComImport(), Guid("00000016-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    interface IOleMessageFilter {
        [PreserveSig]
        int HandleInComingCall(
            int dwCallType,
            IntPtr hTaskCaller,
            int dwTickCount,
            IntPtr lpInterfaceInfo);

        [PreserveSig]
        int RetryRejectedCall(
            IntPtr hTaskCallee,
            int dwTickCount,
            int dwRejectType);

        [PreserveSig]
        int MessagePending(
            IntPtr hTaskCallee,
            int dwTickCount,
            int dwPendingType);
    }
}