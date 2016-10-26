using System;

namespace Steup4ibas.Tools.IISManager
{
    internal class IISManagerXP : IISManager
    {
        /// <summary>
        /// 设置IIS文件路径
        /// </summary>
        /// <param name="i386PackPath">IIS目标文件包路径</param>
        /// <param name="inOptionalFilePath">IIS配置选项文件路径</param>
        /// <param name="unOptionalFilePath">卸载IIS配置选项文件路径</param>
        public IISManagerXP(string i386PackPath, string inOptionalFilePath, string unOptionalFilePath)
        {
              this.I386PackPath = i386PackPath; this.InOptionalFilePath = inOptionalFilePath; this.UnOptionalFilePath = unOptionalFilePath;
            this.SysocmgrCmd = @"sysocmgr /q /i:%windir%\inf\sysoc.inf /u:";
        }

        #region Methods
        #region Install&UnInstall
        /// <summary>
        /// 开始安装IIS
        /// </summary>
        internal override void InstallIIS()
        {
            try
            {
                AmendRegeditPath();

                ExecuteCmd(SysocmgrCmd + "\"" + InOptionalFilePath + "\"");

                RegIISForAspnet();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ReStoreRegeditPath();
            }
        }
        /// <summary>
        /// 开始卸载IIS
        /// </summary>
        internal override void UnInstallIIS()
        {
            ExecuteCmd(SysocmgrCmd + "\"" + UnOptionalFilePath + "\"");
        }
        #endregion
        #endregion
    }
}
