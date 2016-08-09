using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Benchmark;
using Benchmark.Runner;

namespace PerformanceComparison_Win {
    public partial class Runner : Form {
        public Runner() {
            InitializeComponent();
        }
        void Run(object sender, EventArgs e) {
            gridControl1.DataSource = Launcher.Start(null);
        }
    }
}