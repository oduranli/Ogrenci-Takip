﻿using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class BelgeHareketleriL : BaseHareketEntity
    {
        public new long Id { get; set; }
        public long SubeId { get; set; }
        public string OgrenciNo { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string SinifAdi { get; set; }
        public string OgrenciSubeAdi { get; set; }
        public int OdemeBilgileriId { get; set; }
        public string OdemeTuruAdi { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime Vade { get; set; }
        public DateTime HesabaGecisTarihi { get; set; }
        public decimal Tutar { get; set; }
        public decimal IslemOncesiTutar { get; set; }
        public decimal IslemTutari { get; set; }
        public string BankaAdi { get; set; }
        public string BankaSubeAdi { get; set; }
        public string BelgeNo { get; set; }
        public string HesapNo { get; set; }
        public string AsilBorclu { get; set; }
        public string Ciranta { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public MakbuzTuru MakbuzTuru { get; set; }
        public MakbuzHesapTuru HesapTuru { get; set; }
        public BelgeDurumu BelgeDurumu { get; set; }
    }
}