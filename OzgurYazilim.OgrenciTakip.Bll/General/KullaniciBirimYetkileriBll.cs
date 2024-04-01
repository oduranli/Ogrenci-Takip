using OzgurYazilim.OgrenciTakip.Bll.Base;
using OzgurYazilim.OgrenciTakip.Bll.Interfaces;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Data.Contexts;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OzgurYazilim.OgrenciTakip.Bll.General
{
    public class KullaniciBirimYetkileriBll : BaseHareketBll<KullaniciBirimYetkileri, OgrenciTakipContext>,
        IBaseHareketSelectBll<KullaniciBirimYetkileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<KullaniciBirimYetkileri, bool>> filter)
        {
            return List(filter, x => new KullaniciBirimYetkileriL
            {
                Id = x.Id,
                Kod = x.KartTuru == KartTuru.Sube ? x.Sube.Kod : x.Donem.Kod,
                KartTuru=x.KartTuru,
                SubeId=x.SubeId,
                SubeAdi=x.Sube.SubeAdi,
                DonemId=x.DonemId,
                DonemAdi=x.Donem.DonemAdi,
                KullaniciId=x.KullaniciId,
            }).ToList();
        }
    }
}