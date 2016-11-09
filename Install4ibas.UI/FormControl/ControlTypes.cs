using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.UI
{
    public enum ControlTypes
    {
        /// <summary>
        /// 欢迎界面
        /// </summary>
        Welcome = 1,
        /// <summary>
        /// 许可协议界面
        /// </summary>
        LicenseAccept = 2,
        /// <summary>
        /// 功能选择界面
        /// </summary>
        InstallationOptions = 3,
        /// <summary>
        /// 模块选择界面
        /// </summary>
        ModulesChoose = 4,
        /// <summary>
        /// 编辑配置界面
        /// </summary>
        EditConfig = 5,
        /// <summary>
        /// 安装进度界面
        /// </summary>
        InstallationProgress = 6,
        /// <summary>
        /// 完成界面
        /// </summary>
        Finish = 7,
    }
}
