using System;

namespace Install4ibas.UI
{
    public interface IUIAction
    {
        /// <summary>
        /// 完成
        /// </summary>
        event EventHandler FinishEvent;
        /// <summary>
        /// 上一步
        /// </summary>
        event EventHandler BackEvent;
        /// <summary>
        /// 下一步
        /// </summary>
        event EventHandler NextEvent;
        /// <summary>
        /// 取消
        /// </summary>
        event EventHandler CancelEvent;

    }
}
