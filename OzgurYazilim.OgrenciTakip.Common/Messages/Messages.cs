using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.Common.Messages
{
    public class Messages
    {
        public static void HataMesaji(string hataMesaji)
        {
            XtraMessageBox.Show(hataMesaji, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void UyariMesaji(string uyariMesaji)
        {
            XtraMessageBox.Show(uyariMesaji, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void BilgiMesaji(string bilgiMesaji)
        {
            XtraMessageBox.Show(bilgiMesaji, "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult EvetSeciliEvetHayir(string mesaj, string baslik)
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult HayirSeciliEvetHayir(string mesaj, string baslik)
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
        public static DialogResult EvetSeciliEvetHayirIptal(string mesaj, string baslik)
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult SilMesaj(string kartAdi)
        {
            return HayirSeciliEvetHayir($"Seçtiğiniz {kartAdi} silinecektir. Onaylıyor musunuz?", "Silme Onayı!");
        }
        public static DialogResult KapanisMesaj()
        {
            return EvetSeciliEvetHayirIptal("Yapılan değişiklikler kaydedilsin mi?", "Çıkış Onayı!");
        }
        public static DialogResult KayitMesaj()
        {
            return EvetSeciliEvetHayir("Yapılan değişiklikler kaydedilsin mi?", "Kayıt Onayı!");
        }
        public static void KartSecmemeUyariMesaji()
        {
            UyariMesaji("Lütfen bir kart seçiniz!");
        }
        public static void MukerrerKayitHataMesaji(string alanAdi)
        {
            HataMesaji($"Girmiş olduğunuz {alanAdi} daha önce kullanılmıştır!");
        }
        public static void HataliVeriMesaji(string alanAdi)
        {
            HataMesaji($"{alanAdi} alanına geçerli bir değer giriniz!");
        }
        public static DialogResult TabloExportMesaj(string dosyaFormati)
        {
            return EvetSeciliEvetHayir($"İlgili tablo, {dosyaFormati} dosyası olarak dışarı aktarılacaktır. Onaylıyor musunuz? ", "Aktarma Onayı!");
        }
        public static void KartBulunamadiMesaji(string kartTuru)
        {
            UyariMesaji($"İşlem yapılabilecek {kartTuru} bulunamadı!");
        }
        public static void TabloEksikBilgiMesaji(string tabloadi)
        {
            UyariMesaji($"{tabloadi}nda eksik bilgi girişi var. Lütfen kontrol ediniz!");
        }
        public static void IptalHareketSilinemezMesaji()
        {
            HataMesaji("İptal edilen hareketler silinemez!");
        }
        public static DialogResult IptalMesaj(string kartAdi)
        {
            return HayirSeciliEvetHayir($"Seçtiğiniz {kartAdi} iptal edilecektir. Onaylıyor musunuz?", "İptal Onayı!");
        }
        public static DialogResult IptalGerialMesaj(string kartAdi)
        {
            return HayirSeciliEvetHayir($"Seçtiğiniz {kartAdi} kartına uygulanan iptal işlemi geri alınacaktır. Onaylıyor musunuz?", "İptal Gerial Onayı!");
        }
        public static void SecimHataMesaji(string alanAdi)
        {
            HataMesaji($"{alanAdi} seçimi yapmalısınız!");
        }
        public static void OdemeBelgesiSilinemezMesaj(bool dahaSonra)
        {
            UyariMesaji(dahaSonra
                ? "Ödeme belgesinin daha sonra işlem görmüş hareketleri var. Ödeme belgesi silinemez!"
                : "Ödeme belgesinin işlem görmüş hareketleri var. Ödeme belgesi silinemez!");
        }
        public static DialogResult RaporuTasarimaGonderMesaj()
        {
            return HayirSeciliEvetHayir("Rapor tasarım görünümün de açılacaktır. Onaylıyor musunuz?", "Onay!");
        }
        public static DialogResult RaporKapatmaMesaj()
        {
            return HayirSeciliEvetHayir("Rapor kapatılacaktır. Onaylıyor musunuz?", "Onay!");
        }
        public static DialogResult EmailGonderimOnayi()
        {
            return HayirSeciliEvetHayir("Kullanıcı şifresi sıfırlanarak, kullanıcı bilgilerini içeren yeni bir email gönderilecektir. Emin misiniz?", "Onay!");
        }
    }
}