using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class HizmetS : Hizmet
    {
        public string HizmetTuruAdi { get; set; }
    }
    [NotMapped]
    public class HizmetL : BaseEntity
    {
        public string HizmetAdi { get; set; }
        public long HizmetTuruId { get; set; }
        public string HizmetTuruAdi { get; set; }
        public HizmetTipi HizmetTipi { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public decimal Ucret { get; set; }
        public string Aciklama { get; set; }
    }
}