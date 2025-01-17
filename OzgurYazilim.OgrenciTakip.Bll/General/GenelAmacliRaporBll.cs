﻿using OzgurYazilim.OgrenciTakip.Bll.Base;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Data.Contexts;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OzgurYazilim.OgrenciTakip.Bll.General
{
    public class GenelAmacliRaporBll : BaseBll<Tahakkuk, OgrenciTakipContext>
    {
        public IEnumerable<GenelAmacliRaporL> List(Expression<Func<Tahakkuk, bool>> filter)
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

            }).Select(x => new GenelAmacliRaporL
            {
                OgrenciId = x.Tahakkuk.OgrenciId,
                TahakkukId = x.Tahakkuk.Id,
                OgrenciNo = x.Tahakkuk.Kod,
                OkulNo = x.Tahakkuk.OkulNo,
                TcKimlikNo = x.Tahakkuk.Ogrenci.TcKimlikNo,
                Adi = x.Tahakkuk.Ogrenci.Adi,
                Soyadi = x.Tahakkuk.Ogrenci.Soyadi,
                Cinsiyet = x.Tahakkuk.Ogrenci.Cinsiyet,
                Kiz = x.Tahakkuk.Ogrenci.Cinsiyet == Cinsiyet.Kiz ? 1 : 0,
                Erkek = x.Tahakkuk.Ogrenci.Cinsiyet == Cinsiyet.Erkek ? 1 : 0,
                Telefon = x.Tahakkuk.Ogrenci.Telefon,
                BabaAdi = x.Tahakkuk.Ogrenci.BabaAdi,
                AnaAdi = x.Tahakkuk.Ogrenci.AnaAdi,
                DogumYeri = x.Tahakkuk.Ogrenci.DogumYeri,
                KanGrubu = x.Tahakkuk.Ogrenci.KanGrubu,
                DogumTarihi = x.Tahakkuk.Ogrenci.DogumTarihi,
                KimlikSeri = x.Tahakkuk.Ogrenci.KimlikSeri,
                KimlikSiraNo = x.Tahakkuk.Ogrenci.KimlikSiraNo,
                KimlikIlAdi = x.Tahakkuk.Ogrenci.KimlikIl.IlAdi,
                KimlikIlceAdi = x.Tahakkuk.Ogrenci.KimlikIlce.IlceAdi,
                KimlikMahalleKoy = x.Tahakkuk.Ogrenci.KimlikMahalleKoy,
                KimlikCiltNo = x.Tahakkuk.Ogrenci.KimlikCiltNo,
                KimlikAileSiraNo = x.Tahakkuk.Ogrenci.KimlikAileSiraNo,
                KimlikBireySiraNo = x.Tahakkuk.Ogrenci.KimlikBireySiraNo,
                KimlikVerildigiYer = x.Tahakkuk.Ogrenci.KimlikVerildigiYer,
                KimlikVerilisTarihi = x.Tahakkuk.Ogrenci.KimlikVerilisTarihi,
                KimlikVerilisNedeni = x.Tahakkuk.Ogrenci.KimlikVerilisNedeni,
                KimlikKayitNo = x.Tahakkuk.Ogrenci.KimlikKayitNo,
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
                VeliTcKimlikNo = x.VeliBilgileri.Iletisim.TcKimlikNo,
                VeliAdi = x.VeliBilgileri.Iletisim.Adi,
                VeliSoyadi = x.VeliBilgileri.Iletisim.Soyadi,
                VeliAnaAdi = x.VeliBilgileri.Iletisim.AnaAdi,
                VeliBabaAdi = x.VeliBilgileri.Iletisim.BabaAdi,
                VeliYakinlikAdi = x.VeliBilgileri.Yakinlik.YakinlikAdi,
                VeliCepTelefonu1 = x.VeliBilgileri.Iletisim.CepTelefonu1,
                VeliCepTelefonu2 = x.VeliBilgileri.Iletisim.CepTelefonu2,
                VeliEvTelefonu = x.VeliBilgileri.Iletisim.EvTelefonu,
                VeliIsTelefonu1 = x.VeliBilgileri.Iletisim.IsTelefonu1,
                VeliIsTelefonu2 = x.VeliBilgileri.Iletisim.IsTelefonu2,
                VeliDogumTarihi = x.VeliBilgileri.Iletisim.DogumTarihi,
                VeliDogumYeri = x.VeliBilgileri.Iletisim.DogumYeri,
                VeliEmail = x.VeliBilgileri.Iletisim.Email,
                VeliEvAdres = x.VeliBilgileri.Iletisim.EvAdres,
                VeliEvAdresIlAdi = x.VeliBilgileri.Iletisim.EvAdresIl.IlAdi,
                VeliEvAdresIlceAdi = x.VeliBilgileri.Iletisim.EvAdresIlce.IlceAdi,
                VeliGorevAdi = x.VeliBilgileri.Iletisim.Gorev.GorevAdi,
                VeliMeslekAdi = x.VeliBilgileri.Iletisim.Meslek.MeslekAdi,
                VeliIbanNo = x.VeliBilgileri.Iletisim.IbanNo,
                VeliIsyeriAdi = x.VeliBilgileri.Iletisim.Isyeri.IsyeriAdi,
                VeliKanGrubu = x.VeliBilgileri.Iletisim.KanGrubu,
                VeliKartNo = x.VeliBilgileri.Iletisim.KartNo,
                VeliWeb = x.VeliBilgileri.Iletisim.Web,

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