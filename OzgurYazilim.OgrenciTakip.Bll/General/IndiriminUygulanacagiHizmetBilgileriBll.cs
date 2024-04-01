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
    public class IndiriminUygulanacagiHizmetBilgileriBll : BaseHareketBll<IndiriminUygulanacagiHizmetBilgileri, OgrenciTakipContext>,
        IBaseHareketSelectBll<IndiriminUygulanacagiHizmetBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<IndiriminUygulanacagiHizmetBilgileri, bool>> filter)
        {
            return List(filter, x => new IndiriminUygulanacagiHizmetBilgileriL
            {
                Id = x.Id,
                IndirimId = x.IndirimId,
                HizmetId = x.HizmetId,
                HizmetAdi = x.Hizmet.HizmetAdi,
                IndirimTutari = x.IndirimTutari,
                IndirimOrani = x.IndirimOrani,
                DonemId = x.DonemId,
                SubeId = x.SubeId
            }).ToList();
        }
    }
}