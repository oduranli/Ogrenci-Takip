using OzgurYazilim.OgrenciTakip.Bll.Base;
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
    public class IndirimDagilimRaporuBll : BaseBll<Tahakkuk, OgrenciTakipContext>
    {
        public IEnumerable<IndirimDagilimiRaporuL> List(Expression<Func<Tahakkuk, bool>> filter, IEnumerable<long> indirimTurleri)
        {
            return BaseList(filter, x => new
            {
                Tahakkuk = x,

                VeliBilgileri = x.IletisimBilgileri.Where(y => y.Veli).Select(y => new
                {
                    y.Iletisim,
                    y.Yakinlik
                }).FirstOrDefault(),

                IndirimBilgileri = x.IndirimBilgileri.Where(y => indirimTurleri.Contains(y.IndirimId)).GroupBy(y => y.TahakkukId).DefaultIfEmpty().Select(y => new
                {
                    BrutIndirim = y.Select(z => z.BrutIndirim).DefaultIfEmpty(0).Sum(),
                    KistDonemDusulenIndirim = y.Select(z => z.KistDonemDusulenIndirim).DefaultIfEmpty(0).Sum(),
                    NetIndirim = y.Select(z => z.NetIndirim).DefaultIfEmpty(0).Sum()
                }).FirstOrDefault(),

            }).Where(x => x.IndirimBilgileri.BrutIndirim > 0).Select(x => new IndirimDagilimiRaporuL
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

                BrutIndirim = x.IndirimBilgileri.BrutIndirim,
                KistDonemDusulenIndirim = x.IndirimBilgileri.KistDonemDusulenIndirim,
                NetIndirim = x.IndirimBilgileri.NetIndirim,
            }).OrderBy(x => x.OgrenciNo).ToList();
        }
    }
}