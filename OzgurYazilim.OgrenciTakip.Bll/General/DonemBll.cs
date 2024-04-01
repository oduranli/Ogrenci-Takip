using OzgurYazilim.OgrenciTakip.Bll.Base;
using OzgurYazilim.OgrenciTakip.Bll.Interfaces;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.Bll.General
{
    public class DonemBll : BaseGenelBll<Donem>, IBaseGenelBll, IBaseCommonBll
    {
        public DonemBll() : base(KartTuru.Donem) { }

        public DonemBll(Control ctrl) : base(ctrl, KartTuru.Donem) { }
    }
}