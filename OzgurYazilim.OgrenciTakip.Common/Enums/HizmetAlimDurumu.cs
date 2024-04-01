using System.ComponentModel;

namespace OzgurYazilim.OgrenciTakip.Common.Enums
{
    public enum HizmetAlimDurumu:byte
    {
        [Description("Hizmeti Alanlar")]
        HizmetiAlanlar=1,
        [Description("Hizmeti Almayanlar")]
        HizmetiAlmayanlar=2
    }
}