﻿using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Attributes;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Entities
{
    public class OzelKod : BaseEntity
    {
        [Index("IX_Kod", IsUnique = false)]
        public override string Kod { get; set; }
        [Required, StringLength(50), ZorunluAlan("Özel Kod Adı", "txtOzelKodAdi")]
        public string OzelKodAdi { get; set; }
        [Required]
        public OzelKodTuru KodTuru { get; set; }
        [Required]
        public KartTuru KartTuru { get; set; }
        [StringLength(500)]
        public string Aciklama { get; set; }
    }
}