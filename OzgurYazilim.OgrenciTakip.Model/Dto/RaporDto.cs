using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public  class RaporL:BaseEntity
    {
        public string RaporAdi { get; set; }
        public string Aciklama { get; set; }
    }
}