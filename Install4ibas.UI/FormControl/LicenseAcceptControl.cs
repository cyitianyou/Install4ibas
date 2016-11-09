using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Install4ibas.UI
{
    public partial class LicenseAcceptControl : ChildControl
    {
        public LicenseAcceptControl()
        {
            InitializeComponent();
        }
        protected override void SetButtonsVisibleStyle()
        {
            this.ButtonsVisibleStyle = ButtonsVisibleStyle.Cancel | ButtonsVisibleStyle.NextEnable;
        }
        protected override void InitializeEvent()
        {
            this.NextEvent += LicenseAcceptControl_NextEvent;
        }

        void LicenseAcceptControl_NextEvent(object sender, EventArgs e)
        {
            this.ShellControl.SetCurrentControl(ControlTypes.InstallationOptions);
        }
    }
}
