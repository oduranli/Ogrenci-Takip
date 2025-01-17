﻿using OzgurYazilim.OgrenciTakip.Bll.Base;
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
    public class FaturaBll : BaseHareketBll<Fatura, OgrenciTakipContext>,
        IBaseHareketSelectBll<Fatura>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<Fatura, bool>> filter)
        {
            return List(filter, x => new FaturaPlaniL
            {
                Id = x.Id,
                TahakkukId = x.TahakkukId,
                Aciklama = x.Aciklama,
                PlanTarih = x.PlanTarih,
                PlanTutar = x.PlanTutar,
                PlanIndirimTutar = x.PlanIndirimTutar,
                PlanNetTutar = x.PlanNetTutar,
                FaturaNo = x.FaturaNo,
                TahakkukTarih = x.TahakkukTarih,
                TahakkukTutar = x.TahakkukTutar,
                TahakkukIndirimTutar = x.TahakkukIndirimTutar,
                TahakkukNetTutar = x.TahakkukNetTutar,
            }).OrderBy(x => x.PlanTarih).ToList();
        }
        public IEnumerable<BaseHareketEntity> FaturaTahakkukList(Expression<Func<Fatura, bool>> filter)
        {
            return List(filter, x => new
            {
                Fatura = x,
                VeliBilgileri = x.Tahakkuk.IletisimBilgileri.Where(y => y.Veli).Select(z => new
                {
                    z.Iletisim,
                    z.Yakinlik
                }).FirstOrDefault()

            }).Select(x => new FaturaPlaniL
            {
                Id = x.Fatura.Id,
                TahakkukId = x.Fatura.TahakkukId,
                OkulNo = x.Fatura.Tahakkuk.Kod,
                TcKimlikNo = x.Fatura.Tahakkuk.Ogrenci.TcKimlikNo,
                Adi = x.Fatura.Tahakkuk.Ogrenci.Adi,
                Soyadi = x.Fatura.Tahakkuk.Ogrenci.Soyadi,
                SinifAdi = x.Fatura.Tahakkuk.Sinif.SinifAdi,
                KayitTarihi = x.Fatura.Tahakkuk.KayitTarihi,
                KayitSekli = x.Fatura.Tahakkuk.KayitSekli,
                KayitDurumu = x.Fatura.Tahakkuk.KayitDurumu,
                IptalDurumu = x.Fatura.Tahakkuk.Durum ? IptalDurumu.DevamEdiyor : IptalDurumu.IptalEdildi,
                VeliTcKimlikNo = x.VeliBilgileri.Iletisim.TcKimlikNo,
                VeliAdi = x.VeliBilgileri.Iletisim.Adi,
                VeliSoyadi = x.VeliBilgileri.Iletisim.Soyadi,
                VeliYakinlikAdi = x.VeliBilgileri.Yakinlik.YakinlikAdi,
                VeliMeslekAdi = x.VeliBilgileri.Iletisim.Meslek.MeslekAdi,
                EvAdres = x.VeliBilgileri.Iletisim.EvAdres,
                EvAdresIlId = x.VeliBilgileri.Iletisim.EvAdresIlId,
                EvAdresIlAdi = x.VeliBilgileri.Iletisim.EvAdresIl.IlAdi,
                EvAdresIlceId = x.VeliBilgileri.Iletisim.EvAdresIlceId,
                EvAdresIlceAdi = x.VeliBilgileri.Iletisim.EvAdresIlce.IlceAdi,
                IsAdres = x.VeliBilgileri.Iletisim.IsAdres,
                IsAdresIlId = x.VeliBilgileri.Iletisim.IsAdresIlId,
                IsAdresIlAdi = x.VeliBilgileri.Iletisim.IsAdresIl.IlAdi,
                IsAdresIlceId = x.VeliBilgileri.Iletisim.IsAdresIlceId,
                IsAdresIlceAdi = x.VeliBilgileri.Iletisim.IsAdresIlce.IlceAdi,
                OzelKod1 = x.Fatura.Tahakkuk.OzelKod1.OzelKodAdi,
                OzelKod2 = x.Fatura.Tahakkuk.OzelKod2.OzelKodAdi,
                OzelKod3 = x.Fatura.Tahakkuk.OzelKod3.OzelKodAdi,
                OzelKod4 = x.Fatura.Tahakkuk.OzelKod4.OzelKodAdi,
                OzelKod5 = x.Fatura.Tahakkuk.OzelKod5.OzelKodAdi,
                Aciklama = x.Fatura.Aciklama,
                PlanTarih = x.Fatura.PlanTarih,
                PlanTutar = x.Fatura.PlanTutar,
                PlanIndirimTutar = x.Fatura.PlanIndirimTutar,
                PlanNetTutar = x.Fatura.PlanNetTutar,
                FaturaNo = x.Fatura.FaturaNo,
                TahakkukTarih = x.Fatura.TahakkukTarih,
                TahakkukTutar = x.Fatura.TahakkukTutar,
                TahakkukIndirimTutar = x.Fatura.TahakkukIndirimTutar,
                TahakkukNetTutar = x.Fatura.TahakkukNetTutar,
                KdvOrani = x.Fatura.KdvOrani,
                KdvHaricTutar = x.Fatura.KdvHaricTutar,
                KdvTutar = x.Fatura.KdvTutar,
                ToplamTutar = x.Fatura.ToplamTutar,
                TutarYazi = x.Fatura.TutarYazi,
                KdvSekli = x.Fatura.KdvSekli,
                FaturaAdres = x.Fatura.FaturaAdres,
                FaturaAdresIlAdi = x.Fatura.FaturaAdresIl.IlAdi,
                FaturaAdresIlceAdi = x.Fatura.FaturaAdresIlce.IlceAdi,
                Sube = x.Fatura.Tahakkuk.Sube.SubeAdi,
                Donem = x.Fatura.Tahakkuk.Donem.DonemAdi,
            }).OrderBy(x => x.PlanTarih).ToList();
        }
        public IEnumerable<DateTime> FaturaDonemList(Expression<Func<Fatura, bool>> filter)
        {
            return List(filter, x => new
            {
                x.PlanTarih
            }).GroupBy(x => x.PlanTarih).Select(X => X.Key).ToList();
        }
        public int MaxFaturaNo(Expression<Func<Fatura, bool>> filter)
        {
            return List(filter, x => new
            {
                x.FaturaNo
            }).DefaultIfEmpty().Max(x => x.FaturaNo ?? 0);
        }
    }
}