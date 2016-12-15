namespace Install4ibas.UI
{
    partial class InstallationOptionsControl
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
            this.radio_New = new System.Windows.Forms.RadioButton();
            this.radio_Append = new System.Windows.Forms.RadioButton();
            this.radio_License = new System.Windows.Forms.RadioButton();
            this.label_Sites = new System.Windows.Forms.Label();
            this.cmb_Sites = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio_EditPort = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radio_New
            // 
            this.radio_New.AutoSize = true;
            this.radio_New.Location = new System.Drawing.Point(30, 120);
            this.radio_New.Name = "radio_New";
            this.radio_New.Size = new System.Drawing.Size(160, 21);
            this.radio_New.TabIndex = 0;
            this.radio_New.TabStop = true;
            this.radio_New.Text = "全新部署ibas   ";
            this.radio_New.UseVisualStyleBackColor = true;
            this.radio_New.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radio_Append
            // 
            this.radio_Append.AutoSize = true;
            this.radio_Append.Location = new System.Drawing.Point(30, 180);
            this.radio_Append.Name = "radio_Append";
            this.radio_Append.Size = new System.Drawing.Size(184, 21);
            this.radio_Append.TabIndex = 1;
            this.radio_Append.TabStop = true;
            this.radio_Append.Text = "现有ibas上追加模块";
            this.radio_Append.UseVisualStyleBackColor = true;
            this.radio_Append.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radio_License
            // 
            this.radio_License.AutoSize = true;
            this.radio_License.Location = new System.Drawing.Point(30, 240);
            this.radio_License.Name = "radio_License";
            this.radio_License.Size = new System.Drawing.Size(179, 21);
            this.radio_License.TabIndex = 2;
            this.radio_License.TabStop = true;
            this.radio_License.Text = "ibas的License管理";
            this.radio_License.UseVisualStyleBackColor = true;
            this.radio_License.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // label_Sites
            // 
            this.label_Sites.AutoSize = true;
            this.label_Sites.Location = new System.Drawing.Point(282, 180);
            this.label_Sites.Name = "label_Sites";
            this.label_Sites.Size = new System.Drawing.Size(129, 17);
            this.label_Sites.TabIndex = 3;
            this.label_Sites.Text = "请选择ibas网站";
            this.label_Sites.Visible = false;
            // 
            // cmb_Sites
            // 
            this.cmb_Sites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Sites.FormattingEnabled = true;
            this.cmb_Sites.Location = new System.Drawing.Point(418, 176);
            this.cmb_Sites.MaxDropDownItems = 16;
            this.cmb_Sites.Name = "cmb_Sites";
            this.cmb_Sites.Size = new System.Drawing.Size(164, 25);
            this.cmb_Sites.TabIndex = 4;
            this.cmb_Sites.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radio_EditPort);
            this.groupBox1.Controls.Add(this.radio_Append);
            this.groupBox1.Controls.Add(this.cmb_Sites);
            this.groupBox1.Controls.Add(this.radio_New);
            this.groupBox1.Controls.Add(this.label_Sites);
            this.groupBox1.Controls.Add(this.radio_License);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 440);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择要执行的操作";
            // 
            // radio_EditPort
            // 
            this.radio_EditPort.AutoSize = true;
            this.radio_EditPort.Location = new System.Drawing.Point(32, 300);
            this.radio_EditPort.Name = "radio_EditPort";
            this.radio_EditPort.Size = new System.Drawing.Size(177, 21);
            this.radio_EditPort.TabIndex = 5;
            this.radio_EditPort.TabStop = true;
            this.radio_EditPort.Text = "修改ibas的IP/端口";
            this.radio_EditPort.UseVisualStyleBackColor = true;
            this.radio_EditPort.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // InstallationOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "InstallationOptionsControl";
            this.Size = new System.Drawing.Size(650, 440);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radio_New;
        private System.Windows.Forms.RadioButton radio_Append;
        private System.Windows.Forms.RadioButton radio_License;
        private System.Windows.Forms.Label label_Sites;
        private System.Windows.Forms.ComboBox cmb_Sites;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radio_EditPort;
    }
}
