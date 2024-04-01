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
    public class IndirimBilgileriBll : BaseHareketBll<IndirimBilgileri, OgrenciTakipContext>,
         IBaseHareketSelectBll<IndirimBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<IndirimBilgileri, bool>> filter)
        {
            return List(filter, x => new IndirimBilgileriL
            {
                Id = x.Id,
                TahakkukId = x.TahakkukId,
                IndirimId = x.IndirimId,
                IndirimAdi = x.IptalEdildi ? x.Indirim.IndirimAdi + " - ( *** İptal Edildi *** )" : x.Indirim.IndirimAdi,
                HizmetId = x.HizmetId,
                HizmetAdi = x.Hizmet.HizmetAdi,

                IslemTarihi = x.IslemTarihi,
                BrutIndirim = x.BrutIndirim,
                KistDonemDusulenIndirim = x.KistDonemDusulenIndirim,
                NetIndirim = x.NetIndirim,
                IptalEdildi = x.IptalEdildi,
                IptalTarihi = x.IptalTarihi,
                OranliIndirim = x.OranliIndirim,
                ManuelGirilenTutar = x.ManuelGirilenTutar,
                HizmetHareketId = x.HizmetHareketId,
                IptalNedeniId = x.IptalNedeniId,
                IptalNedeniAdi = x.IptalNedeni.IptalNedeniAdi,
                IptalAciklama = x.IptalAciklama,

            }).OrderByDescending(x => x.IptalEdildi).ThenBy(x => x.IptalTarihi).ThenBy(x => x.Id).ToList();
        }
    }
}