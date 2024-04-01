using DevExpress.XtraEditors;
using OzgurYazilim.OgrenciTakip.UI.Win.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyColorPickEdit : ColorPickEdit, IStatusBarKisayol
    {
        public MyColorPickEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; }
        public string StatusBarKisayol { get; set; } = "F4 : ";
        public string StatusBarKisayolAciklama { get; set; }
    }
}