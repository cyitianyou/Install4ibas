using Install4ibas.Tools.Plugin.i18n;
using System.Windows.Forms;

namespace Install4ibas.UI
{
    public class i18nControl : UserControl
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
