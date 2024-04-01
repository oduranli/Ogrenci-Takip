using System;

namespace OzgurYazilim.OgrenciTakip.Model.Attributes
{
    public class Kod:Attribute
    {
        public string Description { get; }
        public string ControlName { get; }

        /// <summary>
        /// Validation işlemleri sırasında zorunlu olan alanları işaretlemek için kullanılacaktır.
        /// </summary>
        /// <param name="description">Uyarı mesajında gösterilecek olan açıklama</param>
        /// <param name="controlName">Uyarı mesajı sonrası focuslanılacak control adı</param>
        public Kod(string description, string controlName)
        {
            Description = description;
            ControlName = controlName;
        }
    }
}