using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Steup4ibas.UI
{
    [System.Flags]
    public enum ButtonsVisibleStyle
    {
        /// <summary>
        /// 取消按钮
        /// </summary>
        Cancel = 1,
        /// <summary>
        /// 上一步按钮
        /// </summary>
        Back = 2,
        /// <summary>
        /// 下一步按钮
        /// </summary>
        Next = 4,
        /// <summary>
        /// 完成按钮
        /// </summary>
        Finish = 8
    }
}
