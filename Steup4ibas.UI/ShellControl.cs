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
        
        }
    }
}
