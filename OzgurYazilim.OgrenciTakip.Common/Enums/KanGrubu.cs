using System.ComponentModel;

namespace OzgurYazilim.OgrenciTakip.Common.Enums
{
    public enum KanGrubu : byte
    {
        [Description("---")]
        Bos = 0,
        [Description("0 Rh+")]
        SifirPozitif = 1,
        [Description("0 Rh-")]
        SifirNegatif = 2,
        [Description("A Rh+")]
        APozitif = 3,
        [Description("A Rh-")]
        ANegatif = 4,
        [Description("B Rh+")]
        BPozitif = 5,
        [Description("B Rh-")]
        BNegatif = 6,
        [Description("AB Rh+")]
        AbPozitif = 7,
        [Description("AB Rh-")]
        AbNegatif = 8
    }
}