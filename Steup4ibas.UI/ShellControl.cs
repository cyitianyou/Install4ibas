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
    public partial class ShellControl : ParentControl
    {
        protected ParentControl CurrentControl;
        public ShellControl()
        {
            InitializeComponent();
        }

        protected override void InitializeEvent()
        {
            this.FinishEvent += ShellControl_FinishEvent;
            this.BackEvent += ShellControl_BackEvent;
            this.NextEvent += ShellControl_NextEvent;
            this.CancelEvent += ShellControl_CancelEvent;
        }

        void ShellControl_CancelEvent(object sender, EventArgs e)
        {
        }

        void ShellControl_NextEvent(object sender, EventArgs e)
        {
        }

        void ShellControl_BackEvent(object sender, EventArgs e)
        {
        }

        void ShellControl_FinishEvent(object sender, EventArgs e)
        {
        }
    }
}
