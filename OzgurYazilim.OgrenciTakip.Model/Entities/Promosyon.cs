using OzgurYazilim.OgrenciTakip.Model.Attributes;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Entities
{
    public class Promosyon : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = false)]
        public override string Kod { get; set; }
        [Required, StringLength(50), ZorunluAlan("Promosyon Adı", "txtPromosyonAdi")]
        public string PromosyonAdi { get; set; }
        [StringLength(500)]
        public string Aciklama { get; set; }
        //[Required]
        public long SubeId { get; set; }
        //[Required]
        public long DonemId { get; set; }

        public Sube Sube { get; set; }
        public Donem Donem { get; set; }
    }
}