using System;
using System.Windows.Forms;

namespace Install4ibas.UI
{
    /// <summary>
    /// 父项控件,设定一些通用操作
    /// </summary>
    public class ChildControl : UserControl, IUIAction
    {
        
        ButtonsVisibleStyle _ButtonsVisibleStyle;
        public ButtonsVisibleStyle ButtonsVisibleStyle {
            get
            {
                return this._ButtonsVisibleStyle;
            }
            set
            {
                this._ButtonsVisibleStyle = value;
                if (ShellControl != null)
                    ShellControl.setButtonsVisible(this.ButtonsVisibleStyle);
            }
        }
        public ShellControl ShellControl;
        public ChildControl()
        {
            this.SetButtonsVisibleStyle();
            this.InitializeComponent();
        }
        protected virtual void SetButtonsVisibleStyle()
        {
            this.ButtonsVisibleStyle = ButtonsVisibleStyle.Cancel | ButtonsVisibleStyle.Back
                                        | ButtonsVisibleStyle.NextEnable | ButtonsVisibleStyle.Finish;
        }

        public virtual void Initialize() {
            
        }
        public virtual void LoadAppSetting()
        {

        }

        public virtual void SaveAppSetting()
        {

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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildControl));
            this.SuspendLayout();
            // 
            // ChildControl
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Name = "ChildControl";
            this.ResumeLayout(false);

        }
    }
}
