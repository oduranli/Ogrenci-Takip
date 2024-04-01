using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.Bll.Functions;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.KullaniciForms
{
    public partial class SifreDegistirEditForm : BaseEditForm
    {
        public SifreDegistirEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new KullaniciBll(myDataLayoutControl);
            HideItems = new BarItem[] { btnYeni, btnGeriAl, btnSil };
            EventsLoad();
        }

        private void SifreDegistir()
        {
            if (Messages.KayitMesaj() != DialogResult.Yes) return;

            var entity = ((KullaniciBll)Bll).SingleDetail(x => x.Id == AnaForm.KullaniciId).EntityConvert<Kullanici>();
            if (entity == null) return;

            if (HataliGiris()) return;

            if (entity.Sifre == txtEskiSifre.Text.MD5Sifrele())
            {
                var currentEntity = new Kullanici
                {
                    Id = entity.Id,
                    Kod = entity.Kod,
                    Adi = entity.Adi,
                    Soyadi = entity.Soyadi,
                    RolId = entity.RolId,
                    Sifre = txtYeniSifre.Text.MD5Sifrele(),
                    GizliKelime = string.IsNullOrEmpty(txtGizliKelime.Text) ? entity.GizliKelime : txtGizliKelime.Text.MD5Sifrele(),
                    Aciklama = entity.Aciklama,
                    Durum = entity.Durum,
                    Email = entity.Email,
                };

                if (!((KullaniciBll)Bll).Update(entity, currentEntity)) return;
                Messages.BilgiMesaji("Şifreniz başarıyla değiştirildi.");
                Close();
            }
            else
            {
                Messages.HataMesaji("Girilen eski şifre yanlıştır. Lütfen kontrol ediniz.");
                txtEskiSifre.Focus();
            }
        }

        private bool HataliGiris()
        {
            if (txtYeniSifre.Text != txtYeniSifreTekrar.Text)
            {
                Messages.HataMesaji("Yeni şifre ile yeni şifre tekrarı uyuşmuyor. Lütfen kontrol ediniz.");
                txtYeniSifre.Focus();
                return true;
            }
            if (txtYeniSifre.Text.Length < 8)
            {
                Messages.HataMesaji("Girilen yeni şifre 8 karakterden az olamaz. Lütfen kontrol ediniz.");
                txtYeniSifre.Focus();
                return true;
            }
            if (!string.IsNullOrEmpty(txtGizliKelime.Text) && txtGizliKelime.Text.Length < 10)
            {
                Messages.HataMesaji("Girilen gizli kelime 10 karakterden az olamaz. Lütfen kontrol ediniz.");
                txtGizliKelime.Focus();
                return true;
            }

            return false;
        }

        protected override void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item == btnKaydet)
                SifreDegistir();
            else if (e.Item == btnCikis)
                Close();
        }
        protected override void BaseEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SablonKaydet();
        }
    }
}