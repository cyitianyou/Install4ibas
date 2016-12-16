using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Install4ibas.UI
{
    public partial class LicenseCreateControl : ChildControl
    {
        public LicenseCreateControl()
        {
            InitializeComponent();
        }

        protected override void SetButtonsVisibleStyle()
        {
            this.ButtonsVisibleStyle = ButtonsVisibleStyle.Finish;
        }

        private void btn_ChooseFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "txt文件|license.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_Path.Text = fileDialog.FileName;
            }
            txt_LicenseInfo.Text = readtxt(txt_Path.Text);

        }
        private string readtxt(string path)
        {
            var tmp = new StringBuilder();

            System.IO.StreamReader fileReader;
            using (fileReader = System.IO.File.OpenText(path))
            {
                while (!fileReader.EndOfStream)
                {
                    tmp.AppendLine(fileReader.ReadLine());
                }
            }
            return tmp.ToString();
        }
        private void btn_Import_Click(object sender, EventArgs e)
        {
            string InstallDiraddress = this.MyAppSetting.InstallDiraddress;
            DirectoryInfo TheFolder = new DirectoryInfo(InstallDiraddress);
            //遍历文件夹
            foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
            {
                if (File.Exists(txt_Path.Text))
                {
                    string copypath = Path.Combine(NextFolder.FullName, Path.GetFileName(txt_Path.Text));
                    File.Copy(txt_Path.Text, copypath, true);
                }
            }
        }

    }
}
