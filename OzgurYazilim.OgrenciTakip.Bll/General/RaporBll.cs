using OzgurYazilim.OgrenciTakip.Bll.Base;
using OzgurYazilim.OgrenciTakip.Bll.Interfaces;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.Bll.General
{
    public class RaporBll : BaseGenelBll<Rapor>, IBaseGenelBll, IBaseCommonBll
    {
        public RaporBll() : base(KartTuru.Rapor) { }

        public RaporBll(Control ctrl) : base(ctrl, KartTuru.Rapor) { }

        public override IEnumerable<BaseEntity> List(Expression<Func<Rapor, bool>> filter)
        {
            return BaseList(filter, x => new RaporL
            {
                Id = x.Id,
                Kod = x.Kod,
                RaporAdi = x.RaporAdi,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}