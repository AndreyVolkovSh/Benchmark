using System;
using System.Runtime.InteropServices;

namespace Profiler.Internal {
    [System.Security.SecuritySafeCritical]
    public static class NativeMethods {
        public const int WM_CLOSE = 0x0010;
        public static IntPtr FindWindow(string ClassName, string WindowName) {
            return NativeMethodsInternal.FindWindow(ClassName, WindowName);
        }
        public static int SendMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam) {
            return NativeMethodsInternal.SendMessage(hWnd, Msg, wParam, lParam);
        }
        static class NativeMethodsInternal {
            [DllImport("USER32.DLL", EntryPoint = "FindWindow")]
            public static extern IntPtr FindWindow(string ClassName, string WindowName);
            [DllImport("USER32.DLL", EntryPoint = "SendMessage")]
            public static extern int SendMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);
        }
    }
}