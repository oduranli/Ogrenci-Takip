using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.Bll.Functions;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.KullaniciForms
{
    public partial class SifremiUnuttumEditForm : BaseEditForm
    {

        #region Variables

        private readonly string _kullaniciAdi;

        #endregion

        public SifremiUnuttumEditForm(params object[] prm)
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new KullaniciBll(myDataLayoutControl);
            HideItems = new BarItem[] { btnYeni, btnKaydet, btnGeriAl, btnSil };
            ShowItems = new BarItem[] { btnSifreSifirla };
            EventsLoad();

            _kullaniciAdi = prm[0].ToString();
        }
        public override void Yukle()
        {
            txtKullaniciAdi.Text = _kullaniciAdi;
        }
        protected override void SifreSifirla()
        {
            if (Messages.EmailGonderimOnayi() != DialogResult.Yes) return;

            var entity = ((KullaniciBll)Bll).SingleDetail(x => x.Kod == txtKullaniciAdi.Text).EntityConvert<KullaniciS>();
            if (entity == null)
            {
                Messages.HataMesaji("Veritabanında kayıtlı böyle bir kullanıcı bulunmamaktadır.");
                return;
            }

            if (txtAdi.Text == entity.Adi && txtSoyadi.Text == entity.Soyadi && txtEmail.Text == entity.Email && txtGizliKelime.Text.MD5Sifrele() == entity.GizliKelime)
            {
                var result = Functions.GeneralFunctions.SifreUret();

                var currentEntity = new Kullanici
                {
                    Id = entity.Id,
                    Kod = entity.Kod,
                    Adi = entity.Adi,
                    Soyadi = entity.Soyadi,
                    Email = entity.Email,
                    RolId = entity.RolId,
                    Aciklama = entity.Aciklama,
                    Durum = entity.Durum,
                    Sifre = result.sifre,
                    GizliKelime = result.gizliKelime
                };

                if (!((KullaniciBll)Bll).Update(entity, currentEntity)) return;
                var sonuc = txtKullaniciAdi.Text.SifreMailiGonder(entity.RolAdi, entity.Email, result.secureSifre, result.secureGizliKelime);

                if (sonuc)
                {
                    Messages.BilgiMesaji("Şifre sıfırlama işlemi başarılı bir şekilde gerçekleşti. Mail adresinizi kontrol ediniz...");
                    Close();
                }
                else
                    Messages.HataMesaji("Şifre sıfırlama işlemi başarılı bir şekilde gerçekleşti. Ancak email gönderilemedi. Lütfen tekrar deneyiniz...");
            }
            else
            {
                Messages.HataMesaji("Girilen bilgiler mevcut bilgiler ile uyuşmuyor. Lütfen kontrol edip tekrar deneyiniz...");
            }
        }
    }
}