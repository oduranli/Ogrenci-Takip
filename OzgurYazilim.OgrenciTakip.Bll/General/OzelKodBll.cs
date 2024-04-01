using OzgurYazilim.OgrenciTakip.Bll.Base;
using OzgurYazilim.OgrenciTakip.Bll.Interfaces;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.Bll.General
{
    public class OzelKodBll : BaseGenelBll<OzelKod>, IBaseCommonBll
    {
        public OzelKodBll() : base(KartTuru.OzelKod) { }
        public OzelKodBll(Control ctrl) : base(ctrl, KartTuru.OzelKod) { }
    }
}
