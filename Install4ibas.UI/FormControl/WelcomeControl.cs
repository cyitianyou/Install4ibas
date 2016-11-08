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
        protected override void InitializeEvent()
        {
            this.NextEvent += WelcomeControl_NextEvent;
        }

        void WelcomeControl_NextEvent(object sender, EventArgs e)
        {
            var IISManager = IISManagerFactory.New().CreateIISManager();
            if (IISManager.IsFullyInstalled())
            {
                MessageBox.Show("IIS已完全安装!");
            }
            else
            {

                MessageBox.Show(IISManager.ShowLastMessage(), "IIS未完全安装!");
            }
        }




    }
}
