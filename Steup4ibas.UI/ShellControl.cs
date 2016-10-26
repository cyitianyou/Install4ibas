using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
                
        }
        


        
    }
}
