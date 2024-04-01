using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class BankaS : Banka
    {
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
    }
    [NotMapped]
    public class BankaL : BaseEntity
    {
        public string BankaAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string Aciklama { get; set; }
    }
}