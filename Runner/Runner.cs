using System;
using System.IO;
using System.Windows.Forms;
using Benchmark.Views;

namespace Benchmark.Win {
    public partial class Runner : Form {
        public Runner() {
            InitializeComponent();
            MainView view = new MainView();
            view.Dock = DockStyle.Fill;
            view.Parent = this;
        }
    }
}