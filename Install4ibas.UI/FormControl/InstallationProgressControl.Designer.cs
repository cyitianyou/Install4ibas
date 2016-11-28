namespace Install4ibas.UI
{
    partial class InstallationProgressControl
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lab_Msg = new System.Windows.Forms.Label();
            this.lab_Schedule = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(58, 173);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(530, 50);
            this.progressBar.TabIndex = 0;
            // 
            // lab_Msg
            // 
            this.lab_Msg.AutoSize = true;
            this.lab_Msg.Location = new System.Drawing.Point(58, 240);
            this.lab_Msg.MaximumSize = new System.Drawing.Size(530, 0);
            this.lab_Msg.Name = "lab_Msg";
            this.lab_Msg.Size = new System.Drawing.Size(0, 17);
            this.lab_Msg.TabIndex = 1;
            // 
            // lab_Schedule
            // 
            this.lab_Schedule.AutoSize = true;
            this.lab_Schedule.Location = new System.Drawing.Point(58, 141);
            this.lab_Schedule.Name = "lab_Schedule";
            this.lab_Schedule.Size = new System.Drawing.Size(0, 17);
            this.lab_Schedule.TabIndex = 2;
            // 
            // InstallationProgressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lab_Schedule);
            this.Controls.Add(this.lab_Msg);
            this.Controls.Add(this.progressBar);
            this.Name = "InstallationProgressControl";
            this.Size = new System.Drawing.Size(650, 440);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lab_Msg;
        private System.Windows.Forms.Label lab_Schedule;
    }
}
