using System;

namespace Steup4ibas.UI
{
    /// <summary>
    /// 父项控件,设定一些通用操作
    /// </summary>
    public class ParentControl : i18nControl, IUIAction
    {
        public ButtonsVisibleStyle ButtonsVisibleStyle;
        public ShellControl ShellControl;
        public ParentControl()
        {
            this.InitializeEvent();
            this.SetButtonsVisibleStyle();
        }
        protected virtual void SetButtonsVisibleStyle()
        {
            this.ButtonsVisibleStyle = ButtonsVisibleStyle.Cancel | ButtonsVisibleStyle.Back
                                        | ButtonsVisibleStyle.Next | ButtonsVisibleStyle.Finish;
        }

        protected virtual void InitializeEvent() {
            
        }

        #region UIAction
        

        public event System.EventHandler CancelEvent;
        public virtual bool OnCancelEvent(object sender, EventArgs e)
        {
            if (this.CancelEvent != null)
            {
                this.CancelEvent.Invoke(sender, e);
                return true;
            }
            else
            {
                return false;
            }
        }

        public event System.EventHandler NextEvent;
        public virtual bool OnNextEvent(object sender, EventArgs e)
        {
            if (this.NextEvent != null)
            {
                this.NextEvent.Invoke(sender, e);
                return true;
            }
            else
            {
                return false;
            }
        }

        public event System.EventHandler BackEvent;
        public virtual bool OnBackEvent(object sender, EventArgs e)
        {
            if (this.BackEvent != null)
            {
                this.BackEvent.Invoke(sender, e);
                return true;
            }
            else
            {
                return false;
            }
        }

        public event System.EventHandler FinishEvent;
        public virtual bool OnFinishEvent(object sender, EventArgs e)
        {
            if (this.FinishEvent != null)
            {
                this.FinishEvent.Invoke(sender, e);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
