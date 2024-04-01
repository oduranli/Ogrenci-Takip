using OzgurYazilim.OgrenciTakip.Model.Attributes;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Entities
{
    public class Il : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }
        [Required, StringLength(50), ZorunluAlan("İl Adı", "txtIlAdi")]
        public string IlAdi { get; set; }
        [StringLength(500)]
        public string Aciklama { get; set; }
        [InverseProperty("Il")] 
        // bu attribute ilçedeki Ilid ile Il deki Id çakışmaması için eklendi. Çünkü hem ilşeden ile hem ilden ilçeye ilişki olunca çakışma oluşur. Ayni relation birden fazla kullanılmış olur.
        //"Il" ise ilçe entitysindeki il ile bağlantı kuran propertynin adı girilmeli. public Il Il olduğundan myproperty ismi Il girilmeli.
        public ICollection<Ilce> Ilce { get; set; } //İlçelere ulaşabilmek için eklendi. 
    }
}