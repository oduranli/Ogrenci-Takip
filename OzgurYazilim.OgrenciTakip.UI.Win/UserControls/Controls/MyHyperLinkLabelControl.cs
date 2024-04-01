using DevExpress.XtraEditors;
using OzgurYazilim.OgrenciTakip.UI.Win.Interfaces;
using System.ComponentModel;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Controls
{
    public class MyHyperLinkLabelControl : HyperlinkLabelControl, IStatusBarAciklama
    {
        [ToolboxItem(true)]
        public MyHyperLinkLabelControl()
        {
            Cursor = Cursors.Arrow;
            LinkBehavior = LinkBehavior.NeverUnderline;
        }
        public string StatusBarAciklama { get; set; }
    }
}