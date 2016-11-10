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
    public partial class FinishControl : ChildControl
    {
        public FinishControl()
        {
            InitializeComponent();
        }
        protected override void InitializeEvent()
        {
            this.FinishEvent += FinishControl_FinishEvent;
        }

        void FinishControl_FinishEvent(object sender, EventArgs e)
        {
            Application.Exit();
        }
        protected override void SetButtonsVisibleStyle()
        {
            this.ButtonsVisibleStyle = UI.ButtonsVisibleStyle.Finish;
        }
    }
}
