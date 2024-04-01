using OzgurYazilim.OgrenciTakip.Model.Entities.Base;

namespace OzgurYazilim.OgrenciTakip.Model.Entities
{
    public class KardesBilgileri:BaseHareketEntity
    {
        public long TahakkukId { get; set; }
        public long KardesTahakkukId { get; set; }

        public Tahakkuk KardesTahakkuk { get; set; }
    }
}