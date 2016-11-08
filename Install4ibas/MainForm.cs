using Install4ibas.UI;
using System;
using System.Windows.Forms;

namespace Install4ibas
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.shellControl1.SetCurrentControl(ControlTypes.Welcome);
        }

    }
}
