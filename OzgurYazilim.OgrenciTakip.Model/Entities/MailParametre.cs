using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Attributes;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace OzgurYazilim.OgrenciTakip.Model.Entities
{
    public class MailParametre : BaseEntity
    {
        [Required, StringLength(50), ZorunluAlan("Email", "txtEmail")]
        public string Email { get; set; }
        [Required, StringLength(50), ZorunluAlan("Email Sifre", "txtSifre")]
        public string Sifre { get; set; }
        [ZorunluAlan("Port No", "txtPortNo")]
        public int PortNo { get; set; }
        [Required, StringLength(50), ZorunluAlan("Host", "txtHost")]
        public string Host { get; set; }
        public EvetHayir SslKullan { get; set; } = EvetHayir.Evet;
    }
}