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
            //对枚举数据下拉列表赋值,展示描述
            this.dr_Status.DataSource = Enumerator.GetValueAndDescriptions(typeof(emInstallStatus));
            this.dr_Status.DisplayMember = "Key";
            this.dr_Status.ValueMember = "Value";
            this.dr_Type.DataSource = Enumerator.GetValueAndDescriptions(typeof(emModuleType));
            this.dr_Type.DisplayMember = "Key";
            this.dr_Type.ValueMember = "Value";

            //文件名下拉框加长以显示长名称
            this.dr_PackageFilePath.DropDownWidth = 200;
            //dataGridView不根据数据源自动添加行
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
            //记录前端模块筛选情况
            bool standard = this.chk_Standard.Checked;
            bool basic = this.chk_Basis.Checked;
            bool other = this.chk_Other.Checked;
            //根据模块类型筛选要展示的模块
            var modules = this.ShellControl.installService.AppSetting.InstallModules
                                                    .Where(c =>
                                                        (c.Type == emModuleType.all && other)
                                                        || (c.Type == emModuleType.basic && basic)
                                                        || (c.Type == emModuleType.other && other)
                                                        || (c.Type == emModuleType.shell && basic)
                                                        || (c.Type == emModuleType.standard && standard)
                                                    ).ToList();
            if (modules != null)
            {
                this.dataGridView.DataSource = modules;
                //对每个模块的路径列表单独赋值
                for (int i = 0; i < modules.Count(); i++)
                {
                    var cell = this.dataGridView.Rows[i].Cells["dr_PackageFilePath"] as DataGridViewComboBoxCell;
                    if (cell == null) continue;
                    cell.Items.Clear();
                    cell.Items.AddRange(modules.ElementAt(i).PackageFileList.ToArray());
                }
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
            //刷新数据
            this.BindDataGridViewData();
        }



    }
}
