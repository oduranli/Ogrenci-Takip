using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzgurYazilim.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class SinavBilgileriL : SinavBilgileri, IBaseHareketEntity
    {
        public bool Insert { get ; set ; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }
}
