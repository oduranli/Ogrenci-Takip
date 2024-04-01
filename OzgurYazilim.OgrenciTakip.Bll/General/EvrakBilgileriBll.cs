using OzgurYazilim.OgrenciTakip.Bll.Base;
using OzgurYazilim.OgrenciTakip.Bll.Interfaces;
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
    public class EvrakBilgileriBll: BaseHareketBll<EvrakBilgileri, OgrenciTakipContext>,
        IBaseHareketSelectBll<EvrakBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<EvrakBilgileri, bool>> filter)
        {
            return List(filter, x => new EvrakBilgileriL
            {
                Id = x.Id,
                Kod=x.Evrak.Kod,
                TahakkukId = x.TahakkukId,
                EvrakId= x.EvrakId,
                EvrakAdi=x.Evrak.EvrakAdi,
            }).ToList();
        }
    }
}