using System;
using System.IO;

namespace Steup4ibas.Tools.IISManager
{
    public class IISRuntime
    {
        internal delegate void InstallIIS();
        internal delegate void UnInstallIIS();
        private string operatingSystemName;
        /// <summary>
        /// 操作系统名称
        /// </summary>
        protected string OperatingSystemName
        {
            get
            {
                if (operatingSystemName == null)
                {
                    operatingSystemName = CheckOSInfo.GetOSName();
                }
                return operatingSystemName;
            }
        }

        InstallIIS installIIS;
        UnInstallIIS unInstallIIS;
        IISManager iisManager;

        public IISRuntime()
        {
            bool is64Bit = CheckOSBitness.Is64BitOperatingSystem();
            string setupPackPath = is64Bit ?
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Source\" + OperatingSystemName + @" x64") :
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Source\" + OperatingSystemName);
            string inOptionalFilePath = is64Bit ?
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Source\" + OperatingSystemName + @" x64\Config\Install.txt") :
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Source\" + OperatingSystemName + @"\Config\Install.txt");
            string unOptionalFilePath = is64Bit ?
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Source\" + OperatingSystemName + @" x64\Config\UnInstall.txt") :
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Source\" + OperatingSystemName + @"\Config\UnInstall.txt");

            switch (OperatingSystemName)
            {
                case "Microsoft Windows XP":
                case "Microsoft Windows Server 2003":
                case "Microsoft Windows Server 2003 R2":
                    iisManager = new IISManagerXP(setupPackPath, inOptionalFilePath, unOptionalFilePath);
                    break;
                case "Microsoft Windows 7":
                case "Microsoft Windows Server 2008":
                case "Microsoft Windows Server 2008 R2":
                case "Microsoft Windows Vista":
                    iisManager = new IISManager7();
                    break;
            }
            installIIS = new InstallIIS(iisManager.InstallIIS);
            unInstallIIS = new UnInstallIIS(iisManager.UnInstallIIS);
        }

        public void InstallIISRun()
        {
            Console.WriteLine(DateTime.Now + "IIS Manager {0} Begin!", OperatingSystemName);
            installIIS();
            Console.WriteLine(DateTime.Now + "IIS Installer {0} Success!", OperatingSystemName);
        }
        public void UnInstallIISRun()
        {
            Console.WriteLine(DateTime.Now + "IIS Manager {0} Begin!", OperatingSystemName);
            unInstallIIS();
            Console.WriteLine(DateTime.Now + "IIS UnInstall {0} Success!", OperatingSystemName);
        }
    }
}
