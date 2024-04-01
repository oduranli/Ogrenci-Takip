using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class MakbuzS : Makbuz
    {
        public string HesapAdi { get; set; }
    }
    [NotMapped]
    public class MakbuzL : BaseEntity
    {
        public DateTime Tarih { get; set; }
        public MakbuzTuru MakbuzTuru { get; set; }
        public MakbuzHesapTuru HesapTuru { get; set; }
        public decimal MakbuzToplami { get; set; }
        public int HareketSayisi { get; set; }
        public string HesapAdi { get; set; }
    }
}