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
    public partial class InstallationProgressControl : ChildControl
    {
        public InstallationProgressControl()
        {
            InitializeComponent();
        }
        protected override void SetButtonsVisibleStyle()
        {
            this.ButtonsVisibleStyle = UI.ButtonsVisibleStyle.Cancel;
        }

        public override void Initialize()
        {
            int step = 10;
            for (int i = 1; i < step + 1; i++)
            {
                this.lab_Msg.Text = string.Format("正在执行安装步骤[{0}]", i);
                this.progressBar.Value = 100 * i / step;
                Application.DoEvents();
                System.Threading.Thread.Sleep(2500);
            }
            this.progressBar.Value = 100;
            this.lab_Msg.Text = "安装完成，请稍候...";
            Application.DoEvents();
            System.Threading.Thread.Sleep(1500);
            this.ShellControl.SetCurrentControl(ControlTypes.Finish);
        }

    }
}
