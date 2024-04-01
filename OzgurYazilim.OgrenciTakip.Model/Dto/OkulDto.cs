using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class OkulS : Okul
    {
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
    }
    [NotMapped]
    public class OkulL : BaseEntity
    {
        public string OkulAdi { get; set; }
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
        public string Aciklama { get; set; }
    }
}