using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.IISManager
{
    public interface IIISManager
    {
        /// <summary>
        /// 检测是否已完全安装
        /// </summary>
        /// <returns></returns>
        bool IsFullyInstalled();
        /// <summary>
        /// 安装IIS
        /// </summary>
        void InstallIIS();
        /// <summary>
        /// 在ASP.NET中注册IIS
        /// </summary>
        void RegIISForAspnet();
        /// <summary>
        /// 卸载IIS
        /// </summary>
        void UninstallIIS();

        string ShowLastMessage();
    }
}
