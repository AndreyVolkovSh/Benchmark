﻿using System;
using System.Threading.Tasks;
using Benchmark.Internal;

namespace Benchmark {
    public class LicencePatcher : IDisposable {
        Task taskCore;
        System.Threading.CancellationTokenSource sourceCore;
        public LicencePatcher() {
            sourceCore = new System.Threading.CancellationTokenSource();
            taskCore = new Task(() => Action(sourceCore.Token));
            taskCore.Start();
        }
        void Action(System.Threading.CancellationToken cancellationToken) {
            while(!cancellationToken.IsCancellationRequested)
                Patch();
        }
        void Patch() {
            IntPtr dialogHandle = NativeMethods.FindWindow(Constants.TelerikLicenseName, Constants.TelerikLicenseCaption);
            if(dialogHandle != IntPtr.Zero) {
                NativeMethods.SendMessage(dialogHandle, NativeMethods.WM_CLOSE, 0, 0);
            }
            dialogHandle = NativeMethods.FindWindow(Constants.DXLicenseName, Constants.DXLicenseCaption);
            if(dialogHandle != IntPtr.Zero) {
                NativeMethods.SendMessage(dialogHandle, NativeMethods.WM_CLOSE, 0, 0);
            }
        }
        #region IDisposable Members
        bool isDiposing;
        public void Dispose() {
            if(isDiposing) return;
            isDiposing = true;
            sourceCore.Cancel();
            taskCore.Wait();
            taskCore.Dispose();
            taskCore = null;
            sourceCore = null;
        }
        #endregion
    }
}