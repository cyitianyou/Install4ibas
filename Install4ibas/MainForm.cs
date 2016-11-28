using Install4ibas.UI;
using System;
using System.Windows.Forms;
using System.Linq;

namespace Install4ibas
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadAssemblys();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.shellControl1.SetCurrentControl(ControlTypes.Welcome);
        }

        private void LoadAssemblys()
        {
            try
            {
                string BitProcess = "";
                if (System.Environment.Is64BitProcess)
                {
                    BitProcess = ".x64";
                }
                else
                {
                    BitProcess = ".x86";
                }
                System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"Interop.SAPbobsCOM{0}.dll", BitProcess)));
                System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"Interop.SAPbouiCOM{0}.dll", BitProcess)));
                AppDomain.CurrentDomain.AssemblyResolve += CurrentAppDomain_AssemblyResolve;
            }
            catch (Exception)
            {
                MessageBox.Show("引用DI失败,部分功能可能无法使用");
            }
        }

        System.Reflection.Assembly CurrentAppDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            System.Reflection.Assembly retAssembly = null;
            foreach (var item in System.AppDomain.CurrentDomain.GetAssemblies())
            {
                if (args.Name.IndexOf("SAPbouiCOM") > 0
                    || args.Name.IndexOf("SAPbobsCOM") > 0)
                {
                    if (string.Equals(args.Name.Split(',').FirstOrDefault(), item.FullName.Split(',').FirstOrDefault()))
                        retAssembly = item;
                }
                else
                    if (item.FullName == args.Name)
                        retAssembly = item;
                if (retAssembly != null) break;
            }
            return retAssembly;
        }

    }
}
