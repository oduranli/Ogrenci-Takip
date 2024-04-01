﻿using DevExpress.DataAccess.ObjectBinding;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class HizmetBilgileriL : HizmetBilgileri, IBaseHareketEntity
    {
        public string HizmetAdi { get; set; }
        public HizmetTipi HizmetTipi { get; set; }
        public string ServisYeriAdi { get; set; }
        public string IptalNedeniAdi { get; set; }
        public string GittigiOkulAdi { get; set; }

        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }
    [HighlightedClass, NotMapped]
    public class HizmetBilgileriR
    {
        public string HizmetAdi { get; set; }
        public string ServisYeriAdi { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public DateTime IslemTarihi { get; set; }
        public decimal BrutUcret { get; set; }
        public decimal KistDonemDusulenUcret { get; set; }
        public decimal NetUcret { get; set; }
        public int EgitimGunSayisi { get; set; }
        public int AlinanHizmetGunSayisi { get; set; }
        public decimal GunlukUcret { get; set; }
        public DateTime? IptalTarihi { get; set; }
        public string IptalNedeniAdi { get; set; }
        public string IptalNedeniAciklama { get; set; }
        public string GittigiOkulAdi { get; set; }
    }
}