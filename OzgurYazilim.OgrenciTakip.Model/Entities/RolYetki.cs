using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;

namespace OzgurYazilim.OgrenciTakip.Model.Entities
{
    public class RolYetki:BaseEntity
    {
        public KartTuru KartTuru { get; set; }
    }
}