using System.Windows.Forms;
using DevExpress.XtraGrid;

namespace Grid.Tests {
    public partial class DevExpressGrid : UserControl {
        public DevExpressGrid() {
            InitializeComponent();
        }
        public GridControl Grid {
            get { return gridControl1; }
        }
    }
}