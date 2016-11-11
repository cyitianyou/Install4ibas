using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Install4ibas.Tools.Common.InstallInformation;

namespace Install4ibas.UI
{
    public partial class ModulesChooseControl : ChildControl
    {
        public ModulesChooseControl()
        {
            InitializeComponent();
            this.EditDataGridView();
        }

        private void EditDataGridView()
        {
            this.dr_Status.DataSource = Enum.GetValues(typeof(emInstallStatus));
            this.dr_Type.DataSource = Enum.GetValues(typeof(emModuleType));
            this.dr_PackageFilePath.DropDownWidth = 200;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.RowTemplate.Height = 21;
            this.dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader);
        }
        private void ModulesChooseControl_SizeChanged(object sender, EventArgs e)
        {
            this.chk_Standard.Left = (this.gp_Modules.Width - this.chk_Standard.Width) / 2;
        }
        public override void Initialize()
        {
            this.NextEvent += ModulesChooseControl_NextEvent;
        }

        void ModulesChooseControl_NextEvent(object sender, EventArgs e)
        {
            this.ShellControl.SetCurrentControl(ControlTypes.EditConfig);
        }
        public override void LoadAppSetting()
        {
            this.BindDataGridViewData();
        }
        private void BindDataGridViewData()
        {
            var modules = this.ShellControl.installService.AppSetting.InstallModules;
            if (modules != null)
            {
                this.dataGridView.DataSource = modules;
                for (int i = 0; i < modules.Count; i++)
                {
                    var cell = this.dataGridView.Rows[i].Cells["dr_PackageFilePath"] as DataGridViewComboBoxCell;
                    if (cell == null) continue;
                    cell.Items.Clear();
                    cell.Items.AddRange(modules[i].PackageFileList.ToArray());
                }
                this.dataGridView.DataSource = modules;
            }
        }
        public override void SaveAppSetting()
        {
            base.SaveAppSetting();
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //this.dataGridView.DataBindings.
        }



    }
}
