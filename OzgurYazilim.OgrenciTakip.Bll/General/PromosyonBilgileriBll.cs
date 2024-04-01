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
    public  class PromosyonBilgileriBll : BaseHareketBll<PromosyonBilgileri, OgrenciTakipContext>,
        IBaseHareketSelectBll<PromosyonBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<PromosyonBilgileri, bool>> filter)
        {
            return List(filter, x => new PromosyonBilgileriL
            {
                Id = x.Id,
                Kod = x.Promosyon.Kod,
                TahakkukId = x.TahakkukId,
                PromosyonId=x.PromosyonId,
                PromosyonAdi=x.Promosyon.PromosyonAdi,
            }).ToList();
        }
    }
}