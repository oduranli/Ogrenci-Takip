using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class SubeS : Sube
    {
        public string AdresIlAdi { get; set; }
        public string AdresIlceAdi { get; set; }
    }
    [NotMapped]
    public class SubeL : BaseEntity
    {
        public string SubeAdi { get; set; }
        public string Adres { get; set; }
        public string AdreslIlAdi { get; set; }
        public string AdresIlceAdi { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }
        public string IbanNo { get; set; }
        public string GrupAdi { get; set; }
        public int? SiraNo { get; set; }
        public string KurumAdi { get; set; }
    }
}