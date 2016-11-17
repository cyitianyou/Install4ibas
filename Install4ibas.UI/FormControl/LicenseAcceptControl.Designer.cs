namespace Install4ibas.UI
{
    partial class LicenseAcceptControl
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_Accept = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(23, 40);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(606, 355);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "\n一切解释权归本公司所有!\n\n一切解释权归本公司所有!!\n\n一切解释权归本公司所有!!!\n\n一切解释权归本公司所有!!!!\n\n一切解释权归本公司所有!!!\n\n一切" +
    "解释权归本公司所有!!\n\n一切解释权归本公司所有!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户许可协议";
            // 
            // chk_Accept
            // 
            this.chk_Accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chk_Accept.AutoSize = true;
            this.chk_Accept.Location = new System.Drawing.Point(25, 402);
            this.chk_Accept.Name = "chk_Accept";
            this.chk_Accept.Size = new System.Drawing.Size(132, 21);
            this.chk_Accept.TabIndex = 2;
            this.chk_Accept.Text = "我接受此协议";
            this.chk_Accept.UseVisualStyleBackColor = true;
            this.chk_Accept.CheckedChanged += new System.EventHandler(this.chk_Accept_CheckedChanged);
            // 
            // LicenseAcceptControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chk_Accept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "LicenseAcceptControl";
            this.Size = new System.Drawing.Size(650, 440);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_Accept;

    }
}
