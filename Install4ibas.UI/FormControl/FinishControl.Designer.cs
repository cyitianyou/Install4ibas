namespace Install4ibas.UI
{
    partial class FinishControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.link_License = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 21.86667F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(199, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "安装完成!";
            // 
            // link_License
            // 
            this.link_License.AutoSize = true;
            this.link_License.Location = new System.Drawing.Point(222, 320);
            this.link_License.Name = "link_License";
            this.link_License.Size = new System.Drawing.Size(156, 17);
            this.link_License.TabIndex = 1;
            this.link_License.TabStop = true;
            this.link_License.Text = "立即去申请License";
            this.link_License.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_License_LinkClicked);
            // 
            // FinishControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.link_License);
            this.Controls.Add(this.label1);
            this.Name = "FinishControl";
            this.Size = new System.Drawing.Size(650, 440);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel link_License;
    }
}
