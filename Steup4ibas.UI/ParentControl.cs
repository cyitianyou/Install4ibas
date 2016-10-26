using Steup4ibas.Tools.i18n;
using System;
using System.Windows.Forms;

namespace Steup4ibas.UI
{
    /// <summary>
    /// 父项控件,设定一些通用操作
    /// </summary>
    public class ParentControl : i18nControl, IUIAction
    {
        public ParentControl()
        {
            this.InitializeEvent();
        }

        protected virtual void InitializeEvent() {
            
        }

        #region UIAction
        

        public event System.EventHandler CancelEvent;
        public virtual void OnCancelEvent(object sender, EventArgs e)
        {
            if (this.CancelEvent != null)
            {
                this.CancelEvent.Invoke(sender, e);
            }
        }

        public event System.EventHandler NextEvent;
        public virtual void OnNextEvent(object sender, EventArgs e)
        {
            if (this.NextEvent != null)
            {
                this.NextEvent.Invoke(sender, e);
            }
        }

        public event System.EventHandler BackEvent;
        public virtual void OnBackEvent(object sender, EventArgs e)
        {
            if (this.BackEvent != null)
            {
                this.BackEvent.Invoke(sender, e);
            }
        }

        public event System.EventHandler FinishEvent;
        public virtual void OnFinishEvent(object sender, EventArgs e)
        {
            if (this.FinishEvent != null)
            {
                this.FinishEvent.Invoke(sender, e);
            }
        }
        #endregion
    }
}
