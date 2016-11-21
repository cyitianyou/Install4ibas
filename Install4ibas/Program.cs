using System;
using System.Windows.Forms;

namespace Install4ibas
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(params string[] Args)
        {
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                try
                {
                    string BitProcess = "";
                    if (System.Environment.Is64BitProcess)
                    {
                        BitProcess = "x64";
                    }
                    else
                    {
                        BitProcess = "x86";
                    }
                    System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"Interop.SAPbobsCOM.{0}.dll", BitProcess)));
                }
                catch (Exception)
                {
                    MessageBox.Show("引用DI失败,部分功能可能无法使用");
                }

                Application.Run(new MainForm());
            }
            else
            {
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.FileName = System.Windows.Forms.Application.ExecutablePath; // 获取当前可执行文件的路径及文件名    
                //以下 Args 为启动本程序的对应的参数   
                startInfo.Arguments = String.Join(" ", Args);
                startInfo.Verb = "runas";
                System.Diagnostics.Process.Start(startInfo);
            }
        }
    }
}
