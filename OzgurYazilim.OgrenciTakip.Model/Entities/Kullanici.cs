﻿using OzgurYazilim.OgrenciTakip.Model.Attributes;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Entities
{
    public class Kullanici : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true), Kod("Kullanıcı Adı", "txtKullaniciAdi"), ZorunluAlan("Kullanıcı Adı", "txtKullaniciAdi")]
        public override string Kod { get; set; }
        [Required, StringLength(50), ZorunluAlan("Adı", "txtAdi")]
        public string Adi { get; set; }
        [Required, StringLength(50), ZorunluAlan("Soyadi", "txtSoyadi")]
        public string Soyadi { get; set; }
        [Required, StringLength(50), ZorunluAlan("Email", "txtEmail")]
        public string Email { get; set; }
        [StringLength(32)]
        public string Sifre { get; set; }
        [StringLength(32)]
        public string GizliKelime { get; set; }
        [ZorunluAlan("Rol", "txtRol")]
        public long RolId { get; set; }
        [StringLength(500)]
        public string Aciklama { get; set; }

        public Rol Rol { get; set; }
    }
}