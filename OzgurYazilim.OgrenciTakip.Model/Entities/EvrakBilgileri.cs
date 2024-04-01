using OzgurYazilim.OgrenciTakip.Model.Entities.Base;

namespace OzgurYazilim.OgrenciTakip.Model.Entities
{
    public class EvrakBilgileri : BaseHareketEntity
    {
        public long TahakkukId { get; set; }
        public long EvrakId { get; set; }
        public Evrak Evrak { get; set; }
    }
}