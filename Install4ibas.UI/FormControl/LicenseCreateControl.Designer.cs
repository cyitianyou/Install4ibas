namespace Install4ibas.UI
{
    partial class LicenseCreateControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_ChooseFolder = new System.Windows.Forms.Button();
            this.btn_Import = new System.Windows.Forms.Button();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_SiteName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_WebInfo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_LicenseInfo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_ChooseFolder);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Import);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Path);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txt_SiteName);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(650, 441);
            this.splitContainer1.TabIndex = 2;
            // 
            // btn_ChooseFolder
            // 
            this.btn_ChooseFolder.Font = new System.Drawing.Font("宋体", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_ChooseFolder.Location = new System.Drawing.Point(500, 13);
            this.btn_ChooseFolder.Name = "btn_ChooseFolder";
            this.btn_ChooseFolder.Size = new System.Drawing.Size(26, 28);
            this.btn_ChooseFolder.TabIndex = 8;
            this.btn_ChooseFolder.Text = "...";
            this.btn_ChooseFolder.UseVisualStyleBackColor = true;
            this.btn_ChooseFolder.Click += new System.EventHandler(this.btn_ChooseFolder_Click);
            // 
            // btn_Import
            // 
            this.btn_Import.Location = new System.Drawing.Point(542, 13);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(75, 28);
            this.btn_Import.TabIndex = 7;
            this.btn_Import.Text = "导入";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // txt_Path
            // 
            this.txt_Path.Location = new System.Drawing.Point(356, 13);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.ReadOnly = true;
            this.txt_Path.Size = new System.Drawing.Size(138, 27);
            this.txt_Path.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "路径:";
            // 
            // txt_SiteName
            // 
            this.txt_SiteName.Location = new System.Drawing.Point(69, 14);
            this.txt_SiteName.Name = "txt_SiteName";
            this.txt_SiteName.ReadOnly = true;
            this.txt_SiteName.Size = new System.Drawing.Size(180, 27);
            this.txt_SiteName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "网站";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel2Collapsed = true;
            this.splitContainer2.Size = new System.Drawing.Size(650, 387);
            this.splitContainer2.SplitterDistance = 607;
            this.splitContainer2.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_WebInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 387);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "账套信息";
            // 
            // txt_WebInfo
            // 
            this.txt_WebInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_WebInfo.Location = new System.Drawing.Point(3, 23);
            this.txt_WebInfo.Multiline = true;
            this.txt_WebInfo.Name = "txt_WebInfo";
            this.txt_WebInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_WebInfo.Size = new System.Drawing.Size(644, 361);
            this.txt_WebInfo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_LicenseInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(96, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "许可信息";
            // 
            // txt_LicenseInfo
            // 
            this.txt_LicenseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_LicenseInfo.Font = new System.Drawing.Font("宋体", 9.066667F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_LicenseInfo.Location = new System.Drawing.Point(3, 23);
            this.txt_LicenseInfo.Multiline = true;
            this.txt_LicenseInfo.Name = "txt_LicenseInfo";
            this.txt_LicenseInfo.ReadOnly = true;
            this.txt_LicenseInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_LicenseInfo.Size = new System.Drawing.Size(90, 74);
            this.txt_LicenseInfo.TabIndex = 1;
            // 
            // LicenseCreateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "LicenseCreateControl";
            this.Size = new System.Drawing.Size(650, 441);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_SiteName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_WebInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_LicenseInfo;
        private System.Windows.Forms.Button btn_ChooseFolder;


    }
}
