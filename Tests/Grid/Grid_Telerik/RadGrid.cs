using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Grid.Tests
{
    public partial class RadGridControl: UserControl
    {
        public RadGridControl()
        {
            InitializeComponent();
        }
        public RadGridView Grid {
            get { return radGridView1; }
        }
    }
}
