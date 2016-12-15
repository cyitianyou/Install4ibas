using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Install4ibas.UI
{
    public partial class LicenseCreateControl : ChildControl
    {
        public LicenseCreateControl()
        {
            InitializeComponent();
        }

        protected override void SetButtonsVisibleStyle()
        {
            this.ButtonsVisibleStyle = ButtonsVisibleStyle.Finish;
        }

        private void btn_ChooseFolder_Click(object sender, EventArgs e)
        {

        }

        private void btn_Import_Click(object sender, EventArgs e)
        {

        }

    }
}
