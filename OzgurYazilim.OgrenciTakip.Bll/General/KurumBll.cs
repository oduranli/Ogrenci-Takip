using OzgurYazilim.OgrenciTakip.Bll.Base;
using OzgurYazilim.OgrenciTakip.Bll.Interfaces;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.Bll.General
{
    public class KurumBll : BaseGenelYonetimBll<Kurum>, IBaseGenelBll, IBaseCommonBll
    {
        public KurumBll() : base(KartTuru.Kurum) { }

        public KurumBll(Control ctrl) : base(ctrl, KartTuru.Kurum) { }
    }
}