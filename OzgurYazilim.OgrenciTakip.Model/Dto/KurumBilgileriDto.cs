using OzgurYazilim.OgrenciTakip.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzgurYazilim.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class KurumBilgileriS : KurumBilgileri
    {
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
    }
}