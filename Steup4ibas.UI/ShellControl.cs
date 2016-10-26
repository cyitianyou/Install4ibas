using System;
using System.Windows.Forms;
using Steup4ibas.Tools.i18n;

namespace Steup4ibas.UI
{
    public partial class ShellControl : i18nControl
    {
        public ShellControl()
        {
            InitializeComponent();
        }
        private void setButtonsVisible(ButtonsVisibleStyle style)
        {
            this.btn_Cancel.Visible = style.HasFlag(ButtonsVisibleStyle.Cancel);
            this.btn_Back.Visible = style.HasFlag(ButtonsVisibleStyle.Back);
            this.btn_Next.Visible = style.HasFlag(ButtonsVisibleStyle.Next);
            this.btn_Finish.Visible = style.HasFlag(ButtonsVisibleStyle.Finish);
        }
        protected ParentControl CurrentControl;
        public bool SetCurrentControl(ParentControl control)
        {
            try
            {
                this.splitContainer.Panel1.Controls.Clear();
                this.splitContainer.Panel1.Controls.Add(control);
                control.Dock = DockStyle.Fill;
                this.CurrentControl = control;
                this.setButtonsVisible(control.ButtonsVisibleStyle);
                control.ShellControl = this;
                return true;
            }
            catch (Exception error)
            {
                return false;
            }

        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            var flag = false;//子项控件事件是否执行
            if (this.CurrentControl != null)
                flag = this.CurrentControl.OnNextEvent(sender, e);
            if (flag) return;//子项控件事件成功执行,返回
            //子项控件事件未执行,可执行默认操作
            //以下添加默认操作
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            var flag = false;//子项控件事件是否执行
            if (this.CurrentControl != null)
               flag= this.CurrentControl.OnCancelEvent(sender, e);
            if (flag) return;//子项控件事件成功执行,返回
            //子项控件事件未执行,可执行默认操作
            //以下添加默认操作
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            var flag = false;//子项控件事件是否执行
            if (this.CurrentControl != null)
                flag = this.CurrentControl.OnBackEvent(sender, e);
            if (flag) return;//子项控件事件成功执行,返回
            //子项控件事件未执行,可执行默认操作
            //以下添加默认操作
            if (MessageBox.Show(
            i18n.prop("$.Msg.ConfirmCancelInstallation", "是否确认取消安装"),
            i18n.prop("$.Msg.Prompt","提示"),
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btn_Finish_Click(object sender, EventArgs e)
        {
            var flag = false;//子项控件事件是否执行
            if (this.CurrentControl != null)
                flag = this.CurrentControl.OnNextEvent(sender, e);
            if (flag) return;//子项控件事件成功执行,返回
            //子项控件事件未执行,可执行默认操作
            //以下添加默认操作
            Application.Exit();
        }




    }
}
