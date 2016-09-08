using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
{Using}

namespace BenchmarkTest {
    static class Program {
        public static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestForm());
        }
    }
    public class TestForm : Form {
        {Field}
        double deviation;
        int resultCount, testRunning;
        List<double> results;        
        System.Diagnostics.Stopwatch perfomance;
        bool isDisposing;
        public TestForm() {
            InitializeComponent();
        }
        private void InitializeComponent() {
            {Initialize}
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;            
            this.perfomance = new System.Diagnostics.Stopwatch();
            results = new List<double>();
            resultCount = 10;
            deviation = 0.85;
            testRunning = 0;
        }
        void Test() {
            perfomance.Start();
            {Test}
        }
        void OnCompleted(object sender, EventArgs e) {
            perfomance.Stop();
            TearDown();
        }
        void SetUp() {
            testRunning++;
            using(Benchmark.Common.LicensePatcher task = new Benchmark.Common.LicensePatcher())
                {SetUp}
        }
        void OnReady(object sender, EventArgs e) {
            Test();
        }
        void TearDown() {
            if(isDisposing) return;
            Trace();
            if(Normalize()) {
                TraceNormalized();
                Application.Exit();
            }
            else {
                {TearDown}
                testRunning--;
                Invalidate();
            }
        }
        bool Normalize() {
            if(results.Count < resultCount) return false;
            results.Sort();
            double min = results[0];
            double max = results[resultCount - 1];
            double averadge = GetAveradge();
            if(averadge / max < deviation)
                results.RemoveAt(resultCount - 1);
            if(min / averadge < deviation)
                results.RemoveAt(0);
            return results.Count == resultCount;
        }
        double GetAveradge() {
            int averadgeIndex = resultCount / 2;
            if(resultCount % 2 == 0)
                return (results[averadgeIndex] + results[averadgeIndex - 1]) / 2;
            return results[averadgeIndex];
        }
        void Trace() {
            double result = perfomance.Elapsed.TotalSeconds;
            Trace("completed", result, EventLogEntryType.Information);
            results.Add(result);
            perfomance.Reset();
        }
        void TraceNormalized() {
            double normalize = 0;
            foreach(double result in results)
                normalize += result;
            normalize /= results.Count;
            Trace("normalized", normalize, EventLogEntryType.Warning);
        }
        void Trace(string message, double perfomance, EventLogEntryType type) {
            Benchmark.Common.BenchmarkLogResult result = new Benchmark.Common.BenchmarkLogResult();
            result.Perfomance = perfomance;
            Benchmark.Common.BenchmarkLog.Trace(message, type, result);
        }
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if(testRunning == 0)
                SetUp();
        }
        protected override void Dispose(bool disposing) {
            if(disposing) {
                isDisposing = disposing;
                {Dispose}
            }
            base.Dispose(disposing);
        }
    }
}