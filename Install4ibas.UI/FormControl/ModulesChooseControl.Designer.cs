﻿namespace Install4ibas.UI
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
            this.gp_Choose = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chk_UseLocal = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gp_Modules = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
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
            this.gp_Choose.Controls.Add(this.button1);
            this.gp_Choose.Controls.Add(this.chk_UseLocal);
            this.gp_Choose.Controls.Add(this.textBox1);
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.button1.Location = new System.Drawing.Point(459, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(138, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(316, 27);
            this.textBox1.TabIndex = 1;
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
            this.dataGridView.Location = new System.Drawing.Point(3, 54);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(638, 309);
            this.dataGridView.TabIndex = 3;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chk_UseLocal;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gp_Modules;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.CheckBox chk_Other;
        private System.Windows.Forms.CheckBox chk_Standard;
        private System.Windows.Forms.CheckBox chk_Basis;

    }
}
