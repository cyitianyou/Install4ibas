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
    public partial class ModulesChooseControl : ChildControl
    {
        public ModulesChooseControl()
        {
            InitializeComponent();
        }
        private void ModulesChooseControl_SizeChanged(object sender, EventArgs e)
        {
            this.chk_Standard.Left = (this.gp_Modules.Width - this.chk_Standard.Width) / 2;
        }
        public  override void Initialize()
        {
            this.NextEvent += ModulesChooseControl_NextEvent;
        }

        void ModulesChooseControl_NextEvent(object sender, EventArgs e)
        {
            this.ShellControl.SetCurrentControl(ControlTypes.EditConfig);
        }
        public override void LoadAppSetting()
        {
            base.LoadAppSetting();
        }
        public override void SaveAppSetting()
        {
            base.SaveAppSetting();
        }


    }
}
