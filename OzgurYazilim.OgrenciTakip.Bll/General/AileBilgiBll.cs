using OzgurYazilim.OgrenciTakip.Bll.Base;
using OzgurYazilim.OgrenciTakip.Bll.Interfaces;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.Bll.General
{
    public class AileBilgiBll : BaseGenelBll<AileBilgi>, IBaseGenelBll, IBaseCommonBll
    {
        public AileBilgiBll() : base(KartTuru.AileBilgi) { }

        public AileBilgiBll(Control ctrl) : base(ctrl, KartTuru.AileBilgi) { }
    }
}