using System.Windows.Forms;

namespace Steup4ibas.i18n
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
