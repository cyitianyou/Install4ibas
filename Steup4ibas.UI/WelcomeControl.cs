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
            MessageBox.Show("触发了点击下一步的事件");
        }
       

    }
}
