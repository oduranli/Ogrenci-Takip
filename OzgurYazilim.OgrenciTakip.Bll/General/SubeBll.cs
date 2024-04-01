using OzgurYazilim.OgrenciTakip.Bll.Base;
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
    public class SubeBll : BaseGenelBll<Sube>, IBaseGenelBll, IBaseCommonBll
    {
        public SubeBll() : base(KartTuru.Sube) { }
        public SubeBll(Control ctrl) : base(ctrl, KartTuru.Sube) { }
        public override BaseEntity Single(Expression<Func<Sube, bool>> filter)
        {
            return BaseSingle(filter, x => new SubeS
            {
                Id = x.Id,
                Kod = x.Kod,
                SubeAdi = x.SubeAdi,
                Adres = x.Adres,
                AdresIlId = x.AdresIl.Id,
                AdresIlAdi = x.AdresIl.IlAdi,
                AdresIlceId = x.AdresIlce.Id,
                AdresIlceAdi = x.AdresIlce.IlceAdi,
                Telefon = x.Telefon,
                Faks = x.Faks,
                IbanNo = x.IbanNo,
                GrupAdi = x.GrupAdi,
                SiraNo = x.SiraNo,
                Logo = x.Logo,
                Durum = x.Durum,                
            });
        }
        public override IEnumerable<BaseEntity> List(Expression<Func<Sube, bool>> filter)
        {
            return BaseList(filter, x => new SubeL
            {
                Id = x.Id,
                Kod = x.Kod,
                SubeAdi=x.SubeAdi,
                Adres=x.Adres,
                AdreslIlAdi=x.AdresIl.IlAdi,
                AdresIlceAdi=x.AdresIlce.IlceAdi,
                Telefon=x.Telefon,
                Faks=x.Faks,
                IbanNo = x.IbanNo,
                GrupAdi = x.GrupAdi,
                SiraNo = x.SiraNo
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}