namespace Install4ibas.UI
{
    partial class ModulesChooseControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gp_Choose = new System.Windows.Forms.GroupBox();
            this.btn_ChooseFolder = new System.Windows.Forms.Button();
            this.chk_UseLocal = new System.Windows.Forms.CheckBox();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gp_Modules = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dr_Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dr_ModuleDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dr_Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dr_Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dr_PackageFilePath = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chk_Other = new System.Windows.Forms.CheckBox();
            this.chk_Standard = new System.Windows.Forms.CheckBox();
            this.chk_Basis = new System.Windows.Forms.CheckBox();
            this.gp_Choose.SuspendLayout();
            this.gp_Modules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gp_Choose
            // 
            this.gp_Choose.Controls.Add(this.btn_ChooseFolder);
            this.gp_Choose.Controls.Add(this.chk_UseLocal);
            this.gp_Choose.Controls.Add(this.txtFolder);
            this.gp_Choose.Controls.Add(this.label1);
            this.gp_Choose.Controls.Add(this.gp_Modules);
            this.gp_Choose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_Choose.Location = new System.Drawing.Point(0, 0);
            this.gp_Choose.Name = "gp_Choose";
            this.gp_Choose.Size = new System.Drawing.Size(650, 440);
            this.gp_Choose.TabIndex = 0;
            this.gp_Choose.TabStop = false;
            this.gp_Choose.Text = "模块选择";
            // 
            // btn_ChooseFolder
            // 
            this.btn_ChooseFolder.Font = new System.Drawing.Font("宋体", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_ChooseFolder.Location = new System.Drawing.Point(459, 38);
            this.btn_ChooseFolder.Name = "btn_ChooseFolder";
            this.btn_ChooseFolder.Size = new System.Drawing.Size(25, 27);
            this.btn_ChooseFolder.TabIndex = 4;
            this.btn_ChooseFolder.Text = "...";
            this.btn_ChooseFolder.UseVisualStyleBackColor = true;
            this.btn_ChooseFolder.Click += new System.EventHandler(this.btn_ChooseFolder_Click);
            // 
            // chk_UseLocal
            // 
            this.chk_UseLocal.AutoSize = true;
            this.chk_UseLocal.Checked = true;
            this.chk_UseLocal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_UseLocal.Location = new System.Drawing.Point(495, 40);
            this.chk_UseLocal.Name = "chk_UseLocal";
            this.chk_UseLocal.Size = new System.Drawing.Size(149, 21);
            this.chk_UseLocal.TabIndex = 2;
            this.chk_UseLocal.Text = "优先使用本地包";
            this.chk_UseLocal.UseVisualStyleBackColor = true;
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(138, 38);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(316, 27);
            this.txtFolder.TabIndex = 1;
            this.txtFolder.TextChanged += new System.EventHandler(this.txtFolder_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "本地模块包目录";
            // 
            // gp_Modules
            // 
            this.gp_Modules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gp_Modules.Controls.Add(this.dataGridView);
            this.gp_Modules.Controls.Add(this.chk_Other);
            this.gp_Modules.Controls.Add(this.chk_Standard);
            this.gp_Modules.Controls.Add(this.chk_Basis);
            this.gp_Modules.Location = new System.Drawing.Point(3, 71);
            this.gp_Modules.Name = "gp_Modules";
            this.gp_Modules.Size = new System.Drawing.Size(644, 366);
            this.gp_Modules.TabIndex = 3;
            this.gp_Modules.TabStop = false;
            this.gp_Modules.Text = "模块列表";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dr_Checked,
            this.dr_ModuleDescription,
            this.dr_Type,
            this.dr_Status,
            this.dr_PackageFilePath});
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView.Location = new System.Drawing.Point(3, 54);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(638, 309);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_DataError);
            // 
            // dr_Checked
            // 
            this.dr_Checked.DataPropertyName = "Checked";
            this.dr_Checked.Frozen = true;
            this.dr_Checked.HeaderText = "";
            this.dr_Checked.Name = "dr_Checked";
            this.dr_Checked.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dr_Checked.Width = 40;
            // 
            // dr_ModuleDescription
            // 
            this.dr_ModuleDescription.DataPropertyName = "ModuleDescription";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dr_ModuleDescription.DefaultCellStyle = dataGridViewCellStyle1;
            this.dr_ModuleDescription.HeaderText = "描述";
            this.dr_ModuleDescription.Name = "dr_ModuleDescription";
            this.dr_ModuleDescription.ReadOnly = true;
            // 
            // dr_Type
            // 
            this.dr_Type.DataPropertyName = "Type";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            this.dr_Type.DefaultCellStyle = dataGridViewCellStyle2;
            this.dr_Type.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dr_Type.HeaderText = "类型";
            this.dr_Type.Name = "dr_Type";
            this.dr_Type.ReadOnly = true;
            this.dr_Type.Width = 60;
            // 
            // dr_Status
            // 
            this.dr_Status.DataPropertyName = "Status";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.dr_Status.DefaultCellStyle = dataGridViewCellStyle3;
            this.dr_Status.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dr_Status.HeaderText = "状态";
            this.dr_Status.Name = "dr_Status";
            this.dr_Status.ReadOnly = true;
            this.dr_Status.Width = 50;
            // 
            // dr_PackageFilePath
            // 
            this.dr_PackageFilePath.DataPropertyName = "PackageFilePath";
            this.dr_PackageFilePath.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dr_PackageFilePath.DropDownWidth = 400;
            this.dr_PackageFilePath.HeaderText = "包名";
            this.dr_PackageFilePath.MaxDropDownItems = 10;
            this.dr_PackageFilePath.Name = "dr_PackageFilePath";
            this.dr_PackageFilePath.Width = 190;
            // 
            // chk_Other
            // 
            this.chk_Other.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_Other.AutoSize = true;
            this.chk_Other.Checked = true;
            this.chk_Other.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Other.Location = new System.Drawing.Point(535, 27);
            this.chk_Other.Name = "chk_Other";
            this.chk_Other.Size = new System.Drawing.Size(98, 21);
            this.chk_Other.TabIndex = 2;
            this.chk_Other.Text = "其他模块";
            this.chk_Other.UseVisualStyleBackColor = true;
            this.chk_Other.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // chk_Standard
            // 
            this.chk_Standard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_Standard.AutoSize = true;
            this.chk_Standard.Checked = true;
            this.chk_Standard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Standard.Location = new System.Drawing.Point(257, 27);
            this.chk_Standard.Name = "chk_Standard";
            this.chk_Standard.Size = new System.Drawing.Size(98, 21);
            this.chk_Standard.TabIndex = 1;
            this.chk_Standard.Text = "标准模块";
            this.chk_Standard.UseVisualStyleBackColor = true;
            this.chk_Standard.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // chk_Basis
            // 
            this.chk_Basis.AutoSize = true;
            this.chk_Basis.Checked = true;
            this.chk_Basis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Basis.Location = new System.Drawing.Point(16, 27);
            this.chk_Basis.Name = "chk_Basis";
            this.chk_Basis.Size = new System.Drawing.Size(98, 21);
            this.chk_Basis.TabIndex = 0;
            this.chk_Basis.Text = "基础模块";
            this.chk_Basis.UseVisualStyleBackColor = true;
            this.chk_Basis.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // ModulesChooseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gp_Choose);
            this.Name = "ModulesChooseControl";
            this.Size = new System.Drawing.Size(650, 440);
            this.SizeChanged += new System.EventHandler(this.ModulesChooseControl_SizeChanged);
            this.gp_Choose.ResumeLayout(false);
            this.gp_Choose.PerformLayout();
            this.gp_Modules.ResumeLayout(false);
            this.gp_Modules.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gp_Choose;
        private System.Windows.Forms.Button btn_ChooseFolder;
        private System.Windows.Forms.CheckBox chk_UseLocal;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gp_Modules;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.CheckBox chk_Other;
        private System.Windows.Forms.CheckBox chk_Standard;
        private System.Windows.Forms.CheckBox chk_Basis;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dr_Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn dr_ModuleDescription;
        private System.Windows.Forms.DataGridViewComboBoxColumn dr_Type;
        private System.Windows.Forms.DataGridViewComboBoxColumn dr_Status;
        private System.Windows.Forms.DataGridViewComboBoxColumn dr_PackageFilePath;

    }
}
