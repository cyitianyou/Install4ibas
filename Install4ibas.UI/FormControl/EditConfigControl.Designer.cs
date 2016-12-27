namespace Install4ibas.UI
{
    partial class EditConfigControl
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
            this.gp_Config = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ChooseFolder = new System.Windows.Forms.Button();
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.txtInputfolder = new System.Windows.Forms.TextBox();
            this.labSiteName = new System.Windows.Forms.Label();
            this.labInputFolder = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.labPort = new System.Windows.Forms.Label();
            this.txtIIS = new System.Windows.Forms.TextBox();
            this.labIIS = new System.Windows.Forms.Label();
            this.gpDB = new System.Windows.Forms.GroupBox();
            this.butDITest = new System.Windows.Forms.Button();
            this.butCOList = new System.Windows.Forms.Button();
            this.cmbDBName = new System.Windows.Forms.ComboBox();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.labLanguage = new System.Windows.Forms.Label();
            this.cmbB1Type = new System.Windows.Forms.ComboBox();
            this.labB1Type = new System.Windows.Forms.Label();
            this.txtB1Server = new System.Windows.Forms.TextBox();
            this.labB1Server = new System.Windows.Forms.Label();
            this.labB1User = new System.Windows.Forms.Label();
            this.labDBUser = new System.Windows.Forms.Label();
            this.labDBName = new System.Windows.Forms.Label();
            this.labDBServer = new System.Windows.Forms.Label();
            this.labDBType = new System.Windows.Forms.Label();
            this.txtB1Password = new System.Windows.Forms.TextBox();
            this.cmbDBType = new System.Windows.Forms.ComboBox();
            this.txtB1User = new System.Windows.Forms.TextBox();
            this.txtDBPassword = new System.Windows.Forms.TextBox();
            this.txtDBUser = new System.Windows.Forms.TextBox();
            this.txtDBServer = new System.Windows.Forms.TextBox();
            this.gp_Config.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpDB.SuspendLayout();
            this.SuspendLayout();
            // 
            // gp_Config
            // 
            this.gp_Config.Controls.Add(this.groupBox1);
            this.gp_Config.Controls.Add(this.gpDB);
            this.gp_Config.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_Config.Location = new System.Drawing.Point(0, 0);
            this.gp_Config.Name = "gp_Config";
            this.gp_Config.Size = new System.Drawing.Size(650, 441);
            this.gp_Config.TabIndex = 0;
            this.gp_Config.TabStop = false;
            this.gp_Config.Text = "编辑配置信息";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_ChooseFolder);
            this.groupBox1.Controls.Add(this.txtSiteName);
            this.groupBox1.Controls.Add(this.txtInputfolder);
            this.groupBox1.Controls.Add(this.labSiteName);
            this.groupBox1.Controls.Add(this.labInputFolder);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.labPort);
            this.groupBox1.Controls.Add(this.txtIIS);
            this.groupBox1.Controls.Add(this.labIIS);
            this.groupBox1.Location = new System.Drawing.Point(8, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 123);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网站信息";
            // 
            // btn_ChooseFolder
            // 
            this.btn_ChooseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ChooseFolder.Location = new System.Drawing.Point(567, 71);
            this.btn_ChooseFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ChooseFolder.Name = "btn_ChooseFolder";
            this.btn_ChooseFolder.Size = new System.Drawing.Size(32, 30);
            this.btn_ChooseFolder.TabIndex = 69;
            this.btn_ChooseFolder.Text = "……";
            this.btn_ChooseFolder.UseVisualStyleBackColor = true;
            this.btn_ChooseFolder.Click += new System.EventHandler(this.btn_ChooseFolder_Click);
            // 
            // txtSiteName
            // 
            this.txtSiteName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSiteName.Location = new System.Drawing.Point(442, 35);
            this.txtSiteName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.Size = new System.Drawing.Size(154, 27);
            this.txtSiteName.TabIndex = 68;
            this.txtSiteName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSiteName.WordWrap = false;
            // 
            // txtInputfolder
            // 
            this.txtInputfolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputfolder.Location = new System.Drawing.Point(104, 71);
            this.txtInputfolder.Margin = new System.Windows.Forms.Padding(4);
            this.txtInputfolder.Name = "txtInputfolder";
            this.txtInputfolder.Size = new System.Drawing.Size(452, 27);
            this.txtInputfolder.TabIndex = 44;
            // 
            // labSiteName
            // 
            this.labSiteName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labSiteName.AutoSize = true;
            this.labSiteName.Location = new System.Drawing.Point(392, 42);
            this.labSiteName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labSiteName.Name = "labSiteName";
            this.labSiteName.Size = new System.Drawing.Size(42, 17);
            this.labSiteName.TabIndex = 67;
            this.labSiteName.Text = "名称";
            this.labSiteName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labInputFolder
            // 
            this.labInputFolder.AutoSize = true;
            this.labInputFolder.Location = new System.Drawing.Point(15, 74);
            this.labInputFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labInputFolder.Name = "labInputFolder";
            this.labInputFolder.Size = new System.Drawing.Size(93, 17);
            this.labInputFolder.TabIndex = 45;
            this.labInputFolder.Text = "文件路径：";
            // 
            // txtPort
            // 
            this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPort.Location = new System.Drawing.Point(308, 35);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(53, 27);
            this.txtPort.TabIndex = 66;
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPort.WordWrap = false;
            // 
            // labPort
            // 
            this.labPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labPort.AutoSize = true;
            this.labPort.Location = new System.Drawing.Point(263, 42);
            this.labPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(42, 17);
            this.labPort.TabIndex = 65;
            this.labPort.Text = "端口";
            this.labPort.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtIIS
            // 
            this.txtIIS.Location = new System.Drawing.Point(104, 35);
            this.txtIIS.Margin = new System.Windows.Forms.Padding(4);
            this.txtIIS.Name = "txtIIS";
            this.txtIIS.Size = new System.Drawing.Size(156, 27);
            this.txtIIS.TabIndex = 62;
            this.txtIIS.WordWrap = false;
            // 
            // labIIS
            // 
            this.labIIS.AutoSize = true;
            this.labIIS.Location = new System.Drawing.Point(15, 42);
            this.labIIS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labIIS.Name = "labIIS";
            this.labIIS.Size = new System.Drawing.Size(76, 17);
            this.labIIS.TabIndex = 61;
            this.labIIS.Text = "网站地址";
            this.labIIS.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gpDB
            // 
            this.gpDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpDB.Controls.Add(this.butDITest);
            this.gpDB.Controls.Add(this.butCOList);
            this.gpDB.Controls.Add(this.cmbDBName);
            this.gpDB.Controls.Add(this.cmbLanguage);
            this.gpDB.Controls.Add(this.labLanguage);
            this.gpDB.Controls.Add(this.cmbB1Type);
            this.gpDB.Controls.Add(this.labB1Type);
            this.gpDB.Controls.Add(this.txtB1Server);
            this.gpDB.Controls.Add(this.labB1Server);
            this.gpDB.Controls.Add(this.labB1User);
            this.gpDB.Controls.Add(this.labDBUser);
            this.gpDB.Controls.Add(this.labDBName);
            this.gpDB.Controls.Add(this.labDBServer);
            this.gpDB.Controls.Add(this.labDBType);
            this.gpDB.Controls.Add(this.txtB1Password);
            this.gpDB.Controls.Add(this.cmbDBType);
            this.gpDB.Controls.Add(this.txtB1User);
            this.gpDB.Controls.Add(this.txtDBPassword);
            this.gpDB.Controls.Add(this.txtDBUser);
            this.gpDB.Controls.Add(this.txtDBServer);
            this.gpDB.Location = new System.Drawing.Point(8, 167);
            this.gpDB.Margin = new System.Windows.Forms.Padding(4);
            this.gpDB.Name = "gpDB";
            this.gpDB.Padding = new System.Windows.Forms.Padding(4);
            this.gpDB.Size = new System.Drawing.Size(627, 246);
            this.gpDB.TabIndex = 48;
            this.gpDB.TabStop = false;
            this.gpDB.Text = "数据库信息";
            // 
            // butDITest
            // 
            this.butDITest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDITest.Location = new System.Drawing.Point(330, 195);
            this.butDITest.Margin = new System.Windows.Forms.Padding(4);
            this.butDITest.Name = "butDITest";
            this.butDITest.Size = new System.Drawing.Size(272, 33);
            this.butDITest.TabIndex = 62;
            this.butDITest.Text = "测试DI连接";
            this.butDITest.UseVisualStyleBackColor = true;
            this.butDITest.Click += new System.EventHandler(this.butDITest_Click);
            // 
            // butCOList
            // 
            this.butCOList.Location = new System.Drawing.Point(18, 195);
            this.butCOList.Margin = new System.Windows.Forms.Padding(4);
            this.butCOList.Name = "butCOList";
            this.butCOList.Size = new System.Drawing.Size(286, 33);
            this.butCOList.TabIndex = 61;
            this.butCOList.Text = "获取公司列表";
            this.butCOList.UseVisualStyleBackColor = true;
            this.butCOList.Click += new System.EventHandler(this.butCOList_Click);
            // 
            // cmbDBName
            // 
            this.cmbDBName.FormattingEnabled = true;
            this.cmbDBName.Location = new System.Drawing.Point(134, 147);
            this.cmbDBName.Name = "cmbDBName";
            this.cmbDBName.Size = new System.Drawing.Size(170, 25);
            this.cmbDBName.TabIndex = 60;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(428, 76);
            this.cmbLanguage.Margin = new System.Windows.Forms.Padding(4);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(174, 25);
            this.cmbLanguage.TabIndex = 59;
            // 
            // labLanguage
            // 
            this.labLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labLanguage.AutoSize = true;
            this.labLanguage.Location = new System.Drawing.Point(327, 81);
            this.labLanguage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labLanguage.Name = "labLanguage";
            this.labLanguage.Size = new System.Drawing.Size(77, 17);
            this.labLanguage.TabIndex = 58;
            this.labLanguage.Text = "B1语言：";
            // 
            // cmbB1Type
            // 
            this.cmbB1Type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbB1Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbB1Type.FormattingEnabled = true;
            this.cmbB1Type.Location = new System.Drawing.Point(428, 40);
            this.cmbB1Type.Margin = new System.Windows.Forms.Padding(4);
            this.cmbB1Type.Name = "cmbB1Type";
            this.cmbB1Type.Size = new System.Drawing.Size(174, 25);
            this.cmbB1Type.TabIndex = 57;
            // 
            // labB1Type
            // 
            this.labB1Type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labB1Type.AutoSize = true;
            this.labB1Type.Location = new System.Drawing.Point(327, 45);
            this.labB1Type.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labB1Type.Name = "labB1Type";
            this.labB1Type.Size = new System.Drawing.Size(77, 17);
            this.labB1Type.TabIndex = 56;
            this.labB1Type.Text = "B1类型：";
            // 
            // txtB1Server
            // 
            this.txtB1Server.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtB1Server.Location = new System.Drawing.Point(428, 110);
            this.txtB1Server.Margin = new System.Windows.Forms.Padding(4);
            this.txtB1Server.Name = "txtB1Server";
            this.txtB1Server.Size = new System.Drawing.Size(174, 27);
            this.txtB1Server.TabIndex = 55;
            this.txtB1Server.WordWrap = false;
            // 
            // labB1Server
            // 
            this.labB1Server.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labB1Server.AutoSize = true;
            this.labB1Server.Location = new System.Drawing.Point(327, 118);
            this.labB1Server.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labB1Server.Name = "labB1Server";
            this.labB1Server.Size = new System.Drawing.Size(94, 17);
            this.labB1Server.TabIndex = 54;
            this.labB1Server.Text = "B1许可证：";
            // 
            // labB1User
            // 
            this.labB1User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labB1User.AutoSize = true;
            this.labB1User.Location = new System.Drawing.Point(327, 154);
            this.labB1User.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labB1User.Name = "labB1User";
            this.labB1User.Size = new System.Drawing.Size(77, 17);
            this.labB1User.TabIndex = 53;
            this.labB1User.Text = "B1用户：";
            // 
            // labDBUser
            // 
            this.labDBUser.AutoSize = true;
            this.labDBUser.Location = new System.Drawing.Point(15, 118);
            this.labDBUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDBUser.Name = "labDBUser";
            this.labDBUser.Size = new System.Drawing.Size(110, 17);
            this.labDBUser.TabIndex = 51;
            this.labDBUser.Text = "数据库用户：";
            // 
            // labDBName
            // 
            this.labDBName.AutoSize = true;
            this.labDBName.Location = new System.Drawing.Point(15, 154);
            this.labDBName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDBName.Name = "labDBName";
            this.labDBName.Size = new System.Drawing.Size(110, 17);
            this.labDBName.TabIndex = 50;
            this.labDBName.Text = "数据库名称：";
            // 
            // labDBServer
            // 
            this.labDBServer.AutoSize = true;
            this.labDBServer.Location = new System.Drawing.Point(15, 81);
            this.labDBServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDBServer.Name = "labDBServer";
            this.labDBServer.Size = new System.Drawing.Size(110, 17);
            this.labDBServer.TabIndex = 49;
            this.labDBServer.Text = "数据库地址：";
            // 
            // labDBType
            // 
            this.labDBType.AutoSize = true;
            this.labDBType.Location = new System.Drawing.Point(15, 45);
            this.labDBType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDBType.Name = "labDBType";
            this.labDBType.Size = new System.Drawing.Size(110, 17);
            this.labDBType.TabIndex = 48;
            this.labDBType.Text = "数据库类型：";
            // 
            // txtB1Password
            // 
            this.txtB1Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtB1Password.Location = new System.Drawing.Point(534, 147);
            this.txtB1Password.Margin = new System.Windows.Forms.Padding(4);
            this.txtB1Password.Name = "txtB1Password";
            this.txtB1Password.PasswordChar = '*';
            this.txtB1Password.Size = new System.Drawing.Size(68, 27);
            this.txtB1Password.TabIndex = 47;
            this.txtB1Password.WordWrap = false;
            // 
            // cmbDBType
            // 
            this.cmbDBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDBType.FormattingEnabled = true;
            this.cmbDBType.Location = new System.Drawing.Point(134, 40);
            this.cmbDBType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDBType.Name = "cmbDBType";
            this.cmbDBType.Size = new System.Drawing.Size(170, 25);
            this.cmbDBType.TabIndex = 41;
            this.cmbDBType.SelectedIndexChanged += new System.EventHandler(this.cmbDBType_SelectedIndexChanged);
            // 
            // txtB1User
            // 
            this.txtB1User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtB1User.Location = new System.Drawing.Point(428, 147);
            this.txtB1User.Margin = new System.Windows.Forms.Padding(4);
            this.txtB1User.Name = "txtB1User";
            this.txtB1User.Size = new System.Drawing.Size(94, 27);
            this.txtB1User.TabIndex = 46;
            this.txtB1User.WordWrap = false;
            // 
            // txtDBPassword
            // 
            this.txtDBPassword.Location = new System.Drawing.Point(236, 110);
            this.txtDBPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtDBPassword.Name = "txtDBPassword";
            this.txtDBPassword.PasswordChar = '*';
            this.txtDBPassword.Size = new System.Drawing.Size(68, 27);
            this.txtDBPassword.TabIndex = 45;
            this.txtDBPassword.WordWrap = false;
            // 
            // txtDBUser
            // 
            this.txtDBUser.Location = new System.Drawing.Point(134, 110);
            this.txtDBUser.Margin = new System.Windows.Forms.Padding(4);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(91, 27);
            this.txtDBUser.TabIndex = 44;
            this.txtDBUser.WordWrap = false;
            // 
            // txtDBServer
            // 
            this.txtDBServer.Location = new System.Drawing.Point(134, 74);
            this.txtDBServer.Margin = new System.Windows.Forms.Padding(4);
            this.txtDBServer.Name = "txtDBServer";
            this.txtDBServer.Size = new System.Drawing.Size(170, 27);
            this.txtDBServer.TabIndex = 42;
            this.txtDBServer.WordWrap = false;
            // 
            // EditConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gp_Config);
            this.Name = "EditConfigControl";
            this.Size = new System.Drawing.Size(650, 441);
            this.gp_Config.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpDB.ResumeLayout(false);
            this.gpDB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gp_Config;
        private System.Windows.Forms.GroupBox gpDB;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.Label labSiteName;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label labPort;
        private System.Windows.Forms.TextBox txtIIS;
        private System.Windows.Forms.Label labIIS;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label labLanguage;
        private System.Windows.Forms.ComboBox cmbB1Type;
        private System.Windows.Forms.Label labB1Type;
        private System.Windows.Forms.TextBox txtB1Server;
        private System.Windows.Forms.Label labB1Server;
        private System.Windows.Forms.Label labB1User;
        private System.Windows.Forms.Label labDBUser;
        private System.Windows.Forms.Label labDBName;
        private System.Windows.Forms.Label labDBServer;
        private System.Windows.Forms.Label labDBType;
        private System.Windows.Forms.TextBox txtB1Password;
        private System.Windows.Forms.ComboBox cmbDBType;
        private System.Windows.Forms.TextBox txtB1User;
        private System.Windows.Forms.TextBox txtDBPassword;
        private System.Windows.Forms.TextBox txtDBUser;
        private System.Windows.Forms.TextBox txtDBServer;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox txtInputfolder;
        private System.Windows.Forms.Label labInputFolder;
        private System.Windows.Forms.ComboBox cmbDBName;
        internal System.Windows.Forms.Button butDITest;
        internal System.Windows.Forms.Button butCOList;
        private System.Windows.Forms.Button btn_ChooseFolder;
    }
}
