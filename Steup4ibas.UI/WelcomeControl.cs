using Steup4ibas.Tools.IISManager;
using System;
using System.Windows.Forms;

namespace Steup4ibas.UI
{
    public partial class WelcomeControl : ParentControl
    {
        public WelcomeControl()
        {
            InitializeComponent();
        }
        protected override void SetButtonsVisibleStyle()
        {
            this.ButtonsVisibleStyle = ButtonsVisibleStyle.Cancel | ButtonsVisibleStyle.Next;
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
