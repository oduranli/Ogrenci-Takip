﻿using OzgurYazilim.OgrenciTakip.Bll.Base;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Data.Contexts;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OzgurYazilim.OgrenciTakip.Bll.General
{
    public class UcretVeOdemeRaporuBll : BaseBll<Tahakkuk, OgrenciTakipContext>
    {
        public IEnumerable<UcretVeOdemeRaporuL> List(Expression<Func<Tahakkuk, bool>> filter)
        {
            return BaseList(filter, x => new
            {
                Tahakkuk = x,

                VeliBilgileri = x.IletisimBilgileri.Where(y => y.Veli).Select(y => new
                {
                    y.Iletisim,
                    y.Yakinlik
                }).FirstOrDefault(),

                HizmetBilgileri = x.HizmetBilgileri.GroupBy(y => y.TahakkukId).DefaultIfEmpty().Select(y => new
                {
                    BrutHizmet = y.Select(z => z.BrutUcret).DefaultIfEmpty(0).Sum(),
                    KistDonemDusulenHizmet = y.Select(z => z.KistDonemDusulenUcret).DefaultIfEmpty(0).Sum(),
                    NetHizmet = y.Select(z => z.NetUcret).DefaultIfEmpty(0).Sum()
                }).FirstOrDefault(),

                IndirimBilgileri = x.IndirimBilgileri.GroupBy(y => y.TahakkukId).DefaultIfEmpty().Select(y => new
                {
                    BrutIndirim = y.Select(z => z.BrutIndirim).DefaultIfEmpty(0).Sum(),
                    KistDonemDusulenIndirim = y.Select(z => z.KistDonemDusulenIndirim).DefaultIfEmpty(0).Sum(),
                    NetIndirim = y.Select(z => z.NetIndirim).DefaultIfEmpty(0).Sum()
                }).FirstOrDefault(),

                OdemeBilgileri = x.OdemeBilgileri.GroupBy(y => y.TahakkukId).DefaultIfEmpty().Select(y => new
                {
                    Acik = y.Where(z => z.OdemeTipi == OdemeTipi.Acik).Select(z => z.Tutar).DefaultIfEmpty(0).Sum(),
                    Cek = y.Where(z => z.OdemeTipi == OdemeTipi.Cek).Select(z => z.Tutar).DefaultIfEmpty(0).Sum(),
                    Elden = y.Where(z => z.OdemeTipi == OdemeTipi.Elden).Select(z => z.Tutar).DefaultIfEmpty(0).Sum(),
                    Epos = y.Where(z => z.OdemeTipi == OdemeTipi.Epos).Select(z => z.Tutar).DefaultIfEmpty(0).Sum(),
                    Ots = y.Where(z => z.OdemeTipi == OdemeTipi.Ots).Select(z => z.Tutar).DefaultIfEmpty(0).Sum(),
                    Pos = y.Where(z => z.OdemeTipi == OdemeTipi.Pos).Select(z => z.Tutar).DefaultIfEmpty(0).Sum(),
                    Senet = y.Where(z => z.OdemeTipi == OdemeTipi.Senet).Select(z => z.Tutar).DefaultIfEmpty(0).Sum(),
                    ToplamOdeme = y.Select(z => z.Tutar).DefaultIfEmpty(0).Sum(),
                    Tahsil = y.Select(z => z.MakbuzHareketleri.Where(c => c.BelgeDurumu == BelgeDurumu.AvukatYoluylaTahsilEtme
                        || c.BelgeDurumu == BelgeDurumu.BankaYoluylaTahsilEtme || c.BelgeDurumu == BelgeDurumu.BlokeCozumu
                        || c.BelgeDurumu == BelgeDurumu.KismiAvukatYoluylaTahsilEtme || c.BelgeDurumu == BelgeDurumu.KismiTahsilEdildi
                        || c.BelgeDurumu == BelgeDurumu.MahsupEtme || c.BelgeDurumu == BelgeDurumu.OdenmisOlarakIsaretleme
                        || c.BelgeDurumu == BelgeDurumu.TahsilEtmeKasa || c.BelgeDurumu == BelgeDurumu.TahsilEtmeBanka)
                        .Select(c => c.IslemTutari).DefaultIfEmpty(0).Sum()).DefaultIfEmpty(0).Sum(),
                    Iade = y.Select(z => z.MakbuzHareketleri.Where(c => c.BelgeDurumu == BelgeDurumu.MusteriyeGeriIade).Select(c => c.IslemTutari).DefaultIfEmpty(0).Sum()).DefaultIfEmpty(0).Sum(),
                    Tahsilde = (y.Select(z => z.MakbuzHareketleri.Where(c => c.BelgeDurumu == BelgeDurumu.AvukataGonderme
                            || c.BelgeDurumu == BelgeDurumu.BankayaTahsileGonderme || c.BelgeDurumu == BelgeDurumu.CiroEtme
                            || c.BelgeDurumu == BelgeDurumu.BlokeyeAlma).Select(c => c.IslemTutari).DefaultIfEmpty(0).Sum()).DefaultIfEmpty(0).Sum())
                            -
                            (y.Select(z => z.MakbuzHareketleri.Where(c => c.BelgeDurumu == BelgeDurumu.KismiAvukatYoluylaTahsilEtme
                            || c.BelgeDurumu == BelgeDurumu.AvukatYoluylaTahsilEtme || c.BelgeDurumu == BelgeDurumu.BankaYoluylaTahsilEtme
                            || c.BelgeDurumu == BelgeDurumu.BlokeCozumu || c.BelgeDurumu == BelgeDurumu.OdenmisOlarakIsaretleme
                            || c.BelgeDurumu == BelgeDurumu.PortfoyeGeriIade || c.BelgeDurumu == BelgeDurumu.PortfoyeKarsiliksizIade)
                            .Select(c => c.IslemTutari).DefaultIfEmpty(0).Sum()).DefaultIfEmpty(0).Sum()),
                }).FirstOrDefault(),

                GeriOdemeBilgileri = x.GeriOdemeBilgileri.GroupBy(y => y.TahakkukId).DefaultIfEmpty().Select(y => new
                {
                    GeriOdenen = y.Select(z => z.Tutar).DefaultIfEmpty(0).Sum(),
                }).FirstOrDefault(),

            }).Select(x => new UcretVeOdemeRaporuL
            {
                OgrenciId = x.Tahakkuk.OgrenciId,
                TahakkukId = x.Tahakkuk.Id,
                OgrenciNo = x.Tahakkuk.Kod,
                OkulNo = x.Tahakkuk.OkulNo,
                TcKimlikNo = x.Tahakkuk.Ogrenci.TcKimlikNo,
                Adi = x.Tahakkuk.Ogrenci.Adi,
                Soyadi = x.Tahakkuk.Ogrenci.Soyadi,
                Cinsiyet = x.Tahakkuk.Ogrenci.Cinsiyet,
                Telefon = x.Tahakkuk.Ogrenci.Telefon,
                KayitTarihi = x.Tahakkuk.KayitTarihi,
                KayitSekli = x.Tahakkuk.KayitSekli,
                KayitDurumu = x.Tahakkuk.KayitDurumu,
                IptalDurumu = x.Tahakkuk.Durum ? IptalDurumu.DevamEdiyor : IptalDurumu.IptalEdildi,
                SinifAdi = x.Tahakkuk.Sinif.SinifAdi,
                GeldigiOkulAdi = x.Tahakkuk.GeldigiOkul.OkulAdi,
                KontenjanAdi = x.Tahakkuk.Kontenjan.KontenjanAdi,
                YabanciDilAdi = x.Tahakkuk.YabanciDil.DilAdi,
                RehberAdi = x.Tahakkuk.Rehber.AdiSoyadi,
                TesvikAdi = x.Tahakkuk.Tesvik.TesvikAdi,
                SubeId = x.Tahakkuk.SubeId,
                DonemId = x.Tahakkuk.DonemId,
                SubeAdi = x.Tahakkuk.Sube.SubeAdi,
                OzelKod1 = x.Tahakkuk.OzelKod1.OzelKodAdi,
                OzelKod2 = x.Tahakkuk.OzelKod2.OzelKodAdi,
                OzelKod3 = x.Tahakkuk.OzelKod3.OzelKodAdi,
                OzelKod4 = x.Tahakkuk.OzelKod4.OzelKodAdi,
                OzelKod5 = x.Tahakkuk.OzelKod5.OzelKodAdi,
                VeliAdi = x.VeliBilgileri.Iletisim.Adi,
                VeliSoyadi = x.VeliBilgileri.Iletisim.Soyadi,
                VeliYakinlikAdi = x.VeliBilgileri.Yakinlik.YakinlikAdi,
                VeliGorevAdi = x.VeliBilgileri.Iletisim.Gorev.GorevAdi,
                VeliMeslekAdi = x.VeliBilgileri.Iletisim.Meslek.MeslekAdi,
                VeliIsyeriAdi = x.VeliBilgileri.Iletisim.Isyeri.IsyeriAdi,

                BrutHizmet = x.HizmetBilgileri.BrutHizmet,
                KistDonemDusulenHizmet = x.HizmetBilgileri.KistDonemDusulenHizmet,
                NetHizmet = x.HizmetBilgileri.NetHizmet,
                BrutIndirim = x.IndirimBilgileri.BrutIndirim,
                KistDonemDusulenIndirim = x.IndirimBilgileri.KistDonemDusulenIndirim,
                NetIndirim = x.IndirimBilgileri.NetIndirim,
                NetUcret = x.HizmetBilgileri.NetHizmet - x.IndirimBilgileri.NetIndirim,
                IndirimOrani = x.HizmetBilgileri.NetHizmet == 0 ? 0 : x.IndirimBilgileri.NetIndirim / x.HizmetBilgileri.NetHizmet * 100,
                Acik = x.OdemeBilgileri.Acik,
                Cek = x.OdemeBilgileri.Cek,
                Elden = x.OdemeBilgileri.Elden,
                Epos = x.OdemeBilgileri.Epos,
                Ots = x.OdemeBilgileri.Ots,
                Pos = x.OdemeBilgileri.Pos,
                Senet = x.OdemeBilgileri.Senet,
                ToplamOdeme = x.OdemeBilgileri.ToplamOdeme,
                Tahsil = x.OdemeBilgileri.Tahsil,
                Iade = x.OdemeBilgileri.Iade,
                Tahsilde = x.OdemeBilgileri.Tahsilde,
                GeriOdenen = x.GeriOdemeBilgileri.GeriOdenen,
                Kalan = x.OdemeBilgileri.ToplamOdeme - (x.OdemeBilgileri.Iade + x.OdemeBilgileri.Tahsil),
                NetOdeme = x.OdemeBilgileri.ToplamOdeme - (x.OdemeBilgileri.Iade + x.GeriOdemeBilgileri.GeriOdenen),
            }).OrderBy(x => x.OgrenciNo).ToList();
        }
    }
}