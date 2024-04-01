﻿using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Entities
{
    public class GeriOdemeBilgileri:BaseHareketEntity
    {
        public long TahakkukId { get; set; }
        [Column(TypeName ="date")]
        public DateTime Tarih { get; set; }
        public GeriOdemeHesapTuru HesapTuru { get; set; }
        public long? BankaHesapId { get; set; }
        public long? KasaId { get; set; }
        [Column(TypeName ="money")]
        public decimal Tutar { get; set; }
        [StringLength(500)]
        public string Aciklama { get; set; }

        public Tahakkuk Tahakkuk { get; set; }
        public BankaHesap BankaHesap { get; set; }
        public Kasa Kasa { get; set; }
    }
}