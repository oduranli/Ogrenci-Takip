using System.ComponentModel;

namespace OzgurYazilim.OgrenciTakip.Common.Enums
{
    public enum EvetHayir : byte
    {
        [Description("Evet")]
        Evet = 1,
        [Description("Hayır")]
        Hayir = 2
    }
}