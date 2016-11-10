using Install4ibas.Tools.Plugin.IISManager;
using System;
using System.Windows.Forms;

namespace Install4ibas.UI
{
    public partial class WelcomeControl : ChildControl
    {
        public WelcomeControl()
        {
            InitializeComponent();
        }
        protected override void SetButtonsVisibleStyle()
        {
            this.ButtonsVisibleStyle = ButtonsVisibleStyle.Cancel | ButtonsVisibleStyle.NextEnable;
        }
        public override void Initialize()
        {
            this.NextEvent += WelcomeControl_NextEvent;
        }

        void WelcomeControl_NextEvent(object sender, EventArgs e)
        {
            this.ShellControl.SetCurrentControl(ControlTypes.LicenseAccept);
        }




    }
}
