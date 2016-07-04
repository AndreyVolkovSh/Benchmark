/*
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
{0};

namespace ProfilerTest {
    static class Program {
        public static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestForm());
        }
    }
    public class TestForm : Form {
        {1};
        bool isCompleted;
        Timer timer;
        System.Diagnostics.Stopwatch perfomance;
        public TestForm() {
            InitializeComponent();
        }
        private void InitializeComponent() {
            {2};
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "TestForm";
            this.timer = new Timer();
            this.timer.Interval = 1000;
            this.perfomance = new System.Diagnostics.Stopwatch();
        }
        void TimerStart(EventHandler onTick){
            timer.Tick += onTick;
            timer.Start();
        }
        void TimerStop(EventHandler onTick){
            timer.Stop();
            timer.Tick -= onTick;            
        }
        void OnStart(object sender, EventArgs e) {
            TimerStop(OnStart);
            perfomance.Start();
            {3};
            if(!isCompleted){
                perfomance.Stop();
                TimerStart(OnEnd);
            }
        }
        void OnEnd(object sender, EventArgs e) {
            TimerStop(OnEnd);
            ApplicationExit();
        }
        protected override void OnVisibleChanged(EventArgs e) {
            base.OnVisibleChanged(e);
            if(IsHandleCreated)
                TimerStart(OnStart);
        }
        void OnTestCompleted(object sender, EventArgs e){
            isCompleted = true;
            perfomance.Stop();
            TimerStart(OnEnd);
        }
        void ApplicationExit(){
            Profiler.ProfilerResult result = new Profiler.ProfilerResult();
            result.Perfomance = (int)perfomance.ElapsedMilliseconds;
            Profiler.ProfilerContext.Trace("success", EventLogEntryType.Information, result);
            Application.Exit();
        }
        protected override void Dispose(bool disposing) {
            if(disposing) {
                {4};
                timer.Stop();
                timer.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
*/