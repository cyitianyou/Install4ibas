using Steup4ibas.Tools.i18n;
using System.Windows.Forms;

namespace Steup4ibas.UI
{
    public class i18nUserControl : UserControl
    {
        protected override void OnLoad(System.EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                item.Text = i18n.prop(item.Text, item.Text);
            }
        }
    }
}
