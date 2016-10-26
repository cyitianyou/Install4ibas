using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace Steup4ibas.Tools.IISManager
{
    internal abstract class IISManager
    {
        #region Properties
        private string osVersion;
        internal string OSVersion
        {
            get
            {
                if (osVersion == null)
                {
                    var ver = new System.Management.ManagementObjectSearcher("select Version from SoftwareLicensingService");
                    var items = ver.Get();
                    foreach (var item in items)
                    {
                        object version = item.GetPropertyValue("Version");
                        osVersion = version.ToString();
                    }
                }
                return osVersion;
            }
        }
        protected string I386PackPath { get; set; }
        public string InOptionalFilePath { get; set; }
        public string UnOptionalFilePath { get; set; }
        /// <summary>
        /// 注册表安装查找路径
        /// </summary>
        protected string regServicePackSourcePath;
        /// <summary>
        /// 注册表安装查找路径
        /// </summary>
        protected string regSourcePath;
        /// <summary>
        /// 安装IIS执行命令（后面应补充上配置文件TXT的文件路径）
        /// </summary>
        protected string SysocmgrCmd { get; set; }
        #endregion

        #region Methods
        internal virtual void InstallIIS() { }
        internal virtual void UnInstallIIS() { }
        /// <summary>
        /// 修改安装查找路径
        /// </summary>
        protected void AmendRegeditPath()
        {
            RegistryKey pRegKey = Registry.LocalMachine;
            pRegKey = pRegKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Setup", true);
            regServicePackSourcePath = pRegKey.GetValue("ServicePackSourcePath").ToString();
            regSourcePath = pRegKey.GetValue("SourcePath").ToString();
            pRegKey.SetValue("ServicePackSourcePath", I386PackPath);
            pRegKey.SetValue("SourcePath", I386PackPath);
        }
        /// <summary>
        /// 恢复安装查找路径
        /// </summary>
        protected void ReStoreRegeditPath()
        {
            RegistryKey pRegKey = Registry.LocalMachine;
            pRegKey = pRegKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Setup", true);
            pRegKey.SetValue("ServicePackSourcePath", regServicePackSourcePath);
            pRegKey.SetValue("SourcePath", regSourcePath);
        }
        /// <summary>
        /// 在ASP.NET中注册IIS
        /// </summary>
        protected void RegIISForAspnet()
        {
            if (CheckOSBitness.Is64BitOperatingSystem())
                ExecuteCmd(Path.Combine(System.Environment.GetEnvironmentVariable("windir"), @"Microsoft.Net\Framework64\v2.0.50727\aspnet_regiis -i"));
            else
                ExecuteCmd(Path.Combine(System.Environment.GetEnvironmentVariable("windir"), @"Microsoft.Net\Framework\v2.0.50727\aspnet_regiis -i"));
        }
        /// <summary>
        /// 执行命令行
        /// </summary>
        /// <param name="optionalFilePaths">命令</param>
        /// <returns>返回结果</returns>
        protected virtual string ExecuteCmd(string[] optionalFilePaths)
        {
            //运行命令行
            Process p = new Process();
            // 设定程序名
            p.StartInfo.FileName = "cmd.exe";
            // 关闭Shell的使用
            p.StartInfo.UseShellExecute = false;
            // 重定向标准输入
            p.StartInfo.RedirectStandardInput = true;
            // 重定向标准输出
            p.StartInfo.RedirectStandardOutput = true;
            //重定向错误输出
            p.StartInfo.RedirectStandardError = true;
            // 设置不显示窗口
            p.StartInfo.CreateNoWindow = true;
            // 启动进程
            p.Start();
            for (int i = 0; i < optionalFilePaths.Length; i++)
            {
                p.StandardInput.WriteLine(optionalFilePaths[i]);
            }
            p.StandardInput.WriteLine("exit");
            // 从输出流获取命令执行结果
            string strRst = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
            return strRst;
        }
        /// <summary>
        /// 执行命令行
        /// </summary>
        /// <param name="optionalFilePath">命令</param>
        /// <returns>optionalFilePaths</returns>
        protected virtual string ExecuteCmd(string optionalFilePath)
        {
            string[] optionalFilePaths = new string[] { optionalFilePath };
            return ExecuteCmd(optionalFilePaths);
        }


        #endregion
    }
}
