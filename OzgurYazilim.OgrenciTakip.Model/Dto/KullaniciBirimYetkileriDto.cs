﻿using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class KullaniciBirimYetkileriL : KullaniciBirimYetkileri, IBaseHareketEntity
    {
        public string Kod { get; set; }
        public string SubeAdi { get; set; }
        public string DonemAdi { get; set; }

        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }
}