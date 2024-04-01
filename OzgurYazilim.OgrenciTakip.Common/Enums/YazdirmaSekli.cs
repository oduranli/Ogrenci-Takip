using System.ComponentModel;

namespace OzgurYazilim.OgrenciTakip.Common.Enums
{
    public enum YazdirmaSekli : byte
    {
        [Description("Tek Tek Yazdır")]
        TekTekYazdir = 1,
        [Description("Toplu Yazdır")]
        TopluYazdir = 2,
    }
}