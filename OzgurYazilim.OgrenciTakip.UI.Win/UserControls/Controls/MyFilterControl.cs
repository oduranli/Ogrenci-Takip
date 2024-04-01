using DevExpress.XtraEditors;
using OzgurYazilim.OgrenciTakip.UI.Win.Interfaces;
using System.ComponentModel;

namespace OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyFilterControl : FilterControl, IStatusBarAciklama
    {
        public MyFilterControl()
        {
            ShowGroupCommandsIcon = true;
        }

        public string StatusBarAciklama { get; set; } = "Filtre metni giriniz.";
    }
}