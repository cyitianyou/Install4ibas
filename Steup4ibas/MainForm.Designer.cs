using Steup4ibas.UI;
namespace Steup4ibas
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.shellControl1 = new Steup4ibas.UI.ShellControl();
            this.SuspendLayout();
            // 
            // shellControl1
            // 
            this.shellControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shellControl1.Location = new System.Drawing.Point(0, 0);
            this.shellControl1.Name = "shellControl1";
            this.shellControl1.Size = new System.Drawing.Size(659, 505);
            this.shellControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 505);
            this.Controls.Add(this.shellControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "$.MainForm.FormTitle";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ShellControl shellControl1;
    }
}