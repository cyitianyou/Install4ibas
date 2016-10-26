using Steup4ibas.Tools.i18n;
using System.Windows.Forms;

namespace Steup4ibas.UI
{
    /// <summary>
    /// 父项控件,设定一些通用操作
    /// </summary>
    public class ParentControl : UserControl, IUIAction
    {
        public ParentControl()
        {
            this.InitializeEvent();
        }
        protected override void OnLoad(System.EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                item.Text = i18n.prop(item.Text, item.Text);
            }
        }


        public event System.EventHandler FinishEvent;

        public event System.EventHandler BackEvent;

        public event System.EventHandler NextEvent;

        public event System.EventHandler CancelEvent;

        protected virtual void InitializeEvent() { }

    }
}
