﻿using OzgurYazilim.OgrenciTakip.Bll.Base;
using OzgurYazilim.OgrenciTakip.Bll.Interfaces;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.Bll.General
{
    public class OgrenciBll : BaseGenelBll<Ogrenci>, IBaseGenelBll, IBaseCommonBll
    {
        public OgrenciBll() : base(KartTuru.Ogrenci) { }
        public OgrenciBll(Control ctrl) : base(ctrl, KartTuru.Ogrenci) { }
        public override BaseEntity Single(Expression<Func<Ogrenci, bool>> filter)
        {
            return BaseSingle(filter, x => new OgrenciS
            {
                Id = x.Id,
                Kod = x.Kod,
                TcKimlikNo = x.TcKimlikNo,
                Adi = x.Adi,
                Soyadi = x.Soyadi,
                BabaAdi = x.BabaAdi,
                AnaAdi = x.AnaAdi,
                DogumYeri = x.DogumYeri,
                DogumTarihi = x.DogumTarihi,
                KanGrubu = x.KanGrubu,
                KimlikSeri = x.KimlikSeri,
                KimlikSiraNo = x.KimlikSiraNo,
                KimlikIlId = x.KimlikIlId,
                KimlikIlAdi = x.KimlikIl.IlAdi,
                KimlikIlceId = x.KimlikIlceId,
                KimlikIlceAdi = x.KimlikIlce.IlceAdi,
                KimlikMahalleKoy = x.KimlikMahalleKoy,
                KimlikCiltNo = x.KimlikCiltNo,
                KimlikAileSiraNo = x.KimlikAileSiraNo,
                KimlikBireySiraNo = x.KimlikBireySiraNo,
                KimlikVerildigiYer = x.KimlikVerildigiYer,
                KimlikVerilisNedeni = x.KimlikVerilisNedeni,
                KimlikVerilisTarihi = x.KimlikVerilisTarihi,
                KimlikKayitNo = x.KimlikKayitNo,
                Telefon = x.Telefon,
                Cinsiyet = x.Cinsiyet,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                OzelKod3Id = x.OzelKod3Id,
                OzelKod3Adi = x.OzelKod3.OzelKodAdi,
                OzelKod4Id = x.OzelKod4Id,
                OzelKod4Adi = x.OzelKod4.OzelKodAdi,
                OzelKod5Id = x.OzelKod5Id,
                OzelKod5Adi = x.OzelKod5.OzelKodAdi,
                Resim = x.Resim,
                Durum = x.Durum,
            });
        }
        public override IEnumerable<BaseEntity> List(Expression<Func<Ogrenci, bool>> filter)
        {
            return BaseList(filter, x => new OgrenciL
            {
                Id = x.Id,
                Kod = x.Kod,
                TcKimlikNo = x.TcKimlikNo,
                Adi = x.Adi,
                Soyadi = x.Soyadi,
                BabaAdi = x.BabaAdi,
                AnaAdi = x.AnaAdi,
                DogumYeri = x.DogumYeri,
                DogumTarihi = x.DogumTarihi,
                KanGrubu = x.KanGrubu,
                KimlikSeri = x.KimlikSeri,
                KimlikSiraNo = x.KimlikSiraNo,
                KimlikIlAdi = x.KimlikIl.IlAdi,
                KimlikIlceAdi = x.KimlikIlce.IlceAdi,
                KimlikMahalleKoy = x.KimlikMahalleKoy,
                KimlikCiltNo = x.KimlikCiltNo,
                KimlikAileSiraNo = x.KimlikAileSiraNo,
                KimlikBireySiraNo = x.KimlikBireySiraNo,
                KimlikVerildigiYer = x.KimlikVerildigiYer,
                KimlikVerilisNedeni = x.KimlikVerilisNedeni,
                KimlikVerilisTarihi = x.KimlikVerilisTarihi,
                KimlikKayitNo = x.KimlikKayitNo,
                Telefon = x.Telefon,
                Cinsiyet = x.Cinsiyet,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                OzelKod3Adi = x.OzelKod3.OzelKodAdi,
                OzelKod4Adi = x.OzelKod4.OzelKodAdi,
                OzelKod5Adi = x.OzelKod5.OzelKodAdi,
                
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
