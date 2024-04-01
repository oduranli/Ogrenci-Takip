using OzgurYazilim.OgrenciTakip.Model.Attributes;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Entities
{
    public class IptalNedeni : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }
        [Required, StringLength(50), ZorunluAlan("İptal Nedeni Adı", "txtNedenAdi")]
        public string IptalNedeniAdi { get; set; }
        [StringLength(500)]
        public string Aciklama { get; set; }
    }
}