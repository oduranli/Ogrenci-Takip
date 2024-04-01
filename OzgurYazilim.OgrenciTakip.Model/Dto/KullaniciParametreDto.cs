using OzgurYazilim.OgrenciTakip.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class KullaniciParametreS : KullaniciParametre
    {
        public string DefaultAvukatHesapAdi { get; set; }
        public string DefaultBankaHesapAdi { get; set; }
        public string DefaultKasaHesapAdi { get; set; }

    }
}