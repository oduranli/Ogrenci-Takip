using OzgurYazilim.OgrenciTakip.Bll.Base;
using OzgurYazilim.OgrenciTakip.Bll.Interfaces;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.Bll.General
{
    public class KullaniciParametreBll : BaseGenelBll<KullaniciParametre>, IBaseGenelBll, IBaseCommonBll
    {
        public KullaniciParametreBll() : base(KartTuru.KullaniciParametre) { }
        public KullaniciParametreBll(Control ctrl) : base(ctrl, KartTuru.KullaniciParametre) { }
        public override BaseEntity Single(Expression<Func<KullaniciParametre, bool>> filter)
        {
            return BaseSingle(filter, x => new KullaniciParametreS
            {
                Id = x.Id,
                Kod = x.Kod,
                KullaniciId = x.KullaniciId,

                DefaultAvukatHesapId = x.DefaultAvukatHesapId,
                DefaultAvukatHesapAdi = x.DefaultAvukatHesap.AdiSoyadi,
                DefaultBankaHesapId = x.DefaultBankaHesapId,
                DefaultBankaHesapAdi = x.DefaultBankaHesap.HesapAdi,
                DefaultKasaHesapId = x.DefaultKasaHesapId,
                DefaultKasaHesapAdi = x.DefaultKasaHesap.KasaAdi,
                RaporlariOnayAlmadanKapat=x.RaporlariOnayAlmadanKapat,
                ArkaPlanResim=x.ArkaPlanResim,
                TableBandPanelForeColor=x.TableBandPanelForeColor,
                TableColumnHeaderForeColor=x.TableColumnHeaderForeColor,
                TableViewCaptionForeColor=x.TableViewCaptionForeColor,
            });
        }
    }
}