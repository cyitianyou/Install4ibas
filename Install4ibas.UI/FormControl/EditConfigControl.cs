using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Install4ibas.Tools.Plugin.DbManager;

namespace Install4ibas.UI
{
    public partial class EditConfigControl :  ChildControl
    {
        public EditConfigControl()
        {
            InitializeComponent();
            this.txtInputfolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            this.txtIIS.Text = string.Format("http://{0}", System.Net.Dns.GetHostName());
            this.txtPort.Text = "8000";
            this.LoadComboxValuesDBType();
            this.LoadComboxValuesB1Type();
            this.LoadComboxValuesLanguageType();
        }

        private void butCOList_Click(object sender, EventArgs e)
        {
            try
            {
                cmbDBName.Items.Clear();
                SAPbobsCOM.Recordset oRs;
                SAPbobsCOM.Company Company;
                Company = GetNewCompany();
                oRs = Company.GetCompanyList();
                while (!oRs.EoF)
                {
                    this.cmbDBName.Items.Add(oRs.Fields.Item(0).Value);
                    oRs.MoveNext();
                }
                if (cmbDBName.Items.Count > 0)
                {
                    cmbDBName.SelectedIndex = 0;
                }
                if (Company.Connected)
                {
                    Company.Disconnect();
                }
                //System.Runtime.InteropServices.Marshal.FinalReleaseComObject(Company);
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private SAPbobsCOM.Company GetNewCompany()
        {
            try
            {
                SAPbobsCOM.Company Company = new SAPbobsCOM.Company();
                Company.DbServerType = (SAPbobsCOM.BoDataServerTypes)System.Enum.Parse(typeof(SAPbobsCOM.BoDataServerTypes), cmbB1Type.Text);
                Company.Server = txtDBServer.Text;
                Company.DbUserName = txtDBUser.Text;
                Company.DbPassword = txtDBPassword.Text;
                Company.CompanyDB = cmbDBName.Text;
                Company.UserName = txtB1User.Text;
                Company.Password = txtB1Password.Text;
                Company.LicenseServer = txtB1Server.Text;
                return Company;
            }
            catch (Exception ex)
            {
                string message = string.Format("[DI API]初始化失败");
                if ((ex) is System.IO.FileNotFoundException & ex.Message.IndexOf("632F4591-AA62-4219-8FB6-22BCF5F60090") > 0)
                {
                    string msg_no_di = string.Format("{0}，{1}", message, "可能是此计算机没有安装匹配的{0}位版本DI。");
                    if ((System.Environment.Is64BitProcess))
                        //'64位客户端
                        message = string.Format(msg_no_di, "64");
                    else
                        //'32位客户端
                        message = string.Format(msg_no_di, "32");
                }
                else
                    message = string.Format("{0}，{1}", message, ex.Message);
                throw new Exception(message, ex);
            }
        }

        void LoadComboxValuesLanguageType()
        {
            Type lantype = typeof(SAPbobsCOM.BoSuppLangs);
            int count = -1;
            int defalut = -1;
            foreach (var item in Enum.GetNames(lantype))
            {
                this.cmbLanguage.Items.Add(item.ToString());
                count += 1;
                if (item.ToString() == SAPbobsCOM.BoSuppLangs.ln_Chinese.ToString())
                {
                    defalut = count;
                }
            }
            if (this.cmbLanguage.Items.Count > 0)
            {
                this.cmbLanguage.SelectedIndex = defalut;
            }
        }

        void LoadComboxValuesDBType()
        {
            foreach (var item in SQLMapFactory.GetMaps())
            {
                this.cmbDBType.Items.Add(item.MyMapSign);
            }
            if (this.cmbDBType.Items.Count > 0)
                this.cmbDBType.SelectedIndex = this.cmbDBType.Items.Count - 1;

        }

        void LoadComboxValuesB1Type()
        {
            Type dbtype = typeof(SAPbobsCOM.BoDataServerTypes);
            var msIndex = 0;
            var index = 0;
            foreach (var item in Enum.GetNames(dbtype))
            {
                this.cmbB1Type.Items.Add(item.ToString());
                if (item.ToString().StartsWith("dst_MSSQL", StringComparison.InvariantCultureIgnoreCase))
                    msIndex = index;
                index++;
            }
            if (this.cmbB1Type.Items.Count > 0)
            {
                this.cmbB1Type.SelectedIndex = this.cmbB1Type.Items.Count - 1;
            }
            if (msIndex > 0)
            {
                this.cmbB1Type.SelectedIndex = msIndex;
            }
        }

        private void cmbDBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtB1Server.Text = string.Empty;
            var myGroup = this.gpDB;
            if (myGroup == null) return;
            var mapFactory = BTulz.ModelsTransformer.Transformer.SQLs.SQLMapFactory.New();
            var map = mapFactory.GetMap(this.cmbDBType.Text);
            if (map != null)
            {
                foreach (var dbItem in map.DbConnectionItems)
                {
                    var sTxtName = string.Format("txt{0}", dbItem.ItemName);
                    var txtItem = myGroup.Controls.OfType<TextBox>().FirstOrDefault(c => c.Name == sTxtName);
                    if (txtItem == null) continue;
                    //if (!string.IsNullOrEmpty(txtItem.Text)) continue;
                    txtItem.Text = dbItem.ItemValue;
                }
            }
            foreach (var item in this.cmbB1Type.Items)
            {
                if (item.ToString().IndexOf(this.cmbDBType.Text) >= 0)
                {
                    this.cmbB1Type.SelectedItem = item;
                }
            }
        }
    }
}
