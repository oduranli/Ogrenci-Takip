using OzgurYazilim.OgrenciTakip.Bll.Base;
using OzgurYazilim.OgrenciTakip.Bll.Interfaces;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.Bll.General
{
    public class HizmetTuruBll : BaseGenelBll<HizmetTuru>, IBaseGenelBll, IBaseCommonBll
    {
        public HizmetTuruBll() : base(KartTuru.HizmetTuru) { }

        public HizmetTuruBll(Control ctrl) : base(ctrl, KartTuru.HizmetTuru) { }
    }
}