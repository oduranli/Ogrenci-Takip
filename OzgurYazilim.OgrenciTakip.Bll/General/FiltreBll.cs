using OzgurYazilim.OgrenciTakip.Bll.Base;
using OzgurYazilim.OgrenciTakip.Bll.Interfaces;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.Bll.General
{
    public class FiltreBll : BaseGenelBll<Filtre>, IBaseCommonBll
    {
        public FiltreBll() : base(KartTuru.Filtre) { }
        public FiltreBll(Control ctrl) : base(ctrl, KartTuru.Filtre) { }
    }
}