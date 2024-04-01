using OzgurYazilim.OgrenciTakip.Bll.Base;
using OzgurYazilim.OgrenciTakip.Bll.Interfaces;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.Bll.General
{
    public class IsyeriBll : BaseGenelBll<Isyeri>, IBaseGenelBll, IBaseCommonBll
    {
        public IsyeriBll() : base(KartTuru.Isyeri) { }
        public IsyeriBll(Control ctrl) : base(ctrl, KartTuru.Isyeri) { }
    }
}
