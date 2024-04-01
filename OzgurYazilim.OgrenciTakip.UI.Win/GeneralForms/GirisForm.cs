using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Controls;
using System.Reflection;
using System.Configuration;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Common.Functions;
using OzgurYazilim.OgrenciTakip.Bll.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.Bll.General;
using System.Collections.Generic;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using System.Linq;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.KullaniciForms;
using DevExpress.XtraSplashScreen;

namespace OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms
{
    public partial class GirisForm : XtraForm
    {

        #region Variable

        private Point _mouseLocation;
        private List<Kurum> _source;

        #endregion

        public GirisForm()
        {
            InitializeComponent();

            EventsLoad();
        }
        private void EventsLoad()
        {
            //Control Events
            foreach (Control control in Controls)
            {
                if (!(control is MyDataLayoutControl)) continue;
                control.MouseDown += Control_MouseDown;
                control.MouseMove += Control_MouseMove;

                foreach (Control ctrl in control.Controls)
                {
                    ctrl.KeyDown += Control_KeyDown;

                    switch (ctrl)
                    {
                        case MySimpleButton btn:
                            btn.Click += Control_Click;
                            break;
                        case MyHyperLinkLabelControl hyp:
                            hyp.Click += Control_Click;
                            break;
                    }
                }
            }
            // Form Events
            Shown += GirisForm_Shown;
            Load += GirisForm_Load;
        }
        private void Yukle()
        {
            txtVersion.Text = $"Versiyon : {Assembly.GetExecutingAssembly().GetName().Version}";

            var server = ConfigurationManager.AppSettings["Server"];
            var yetkilendirmeTuru = ConfigurationManager.AppSettings["YetkilendirmeTuru"].GetEnum<YetkilendirmeTuru>();
            var kullaniciAdi = ConfigurationManager.AppSettings["KullaniciAdi"].ConvertToSecureString();
            var sifre = ConfigurationManager.AppSettings["Sifre"].ConvertToSecureString();

            if (!Functions.GeneralFunctions.BaglantiKontrolu(server, kullaniciAdi, sifre, yetkilendirmeTuru, true))
            {
                txtKurum.Properties.DataSource = null;
                if (ShowEditForms<BaglantiAyarlariEditForm>.ShowDialogEditForm(IslemTuru.EntityUpdate))
                    Yukle();
                return;
            }

            Functions.GeneralFunctions.CreateConnectionString("OzgurYazilim_OgrenciTakip_Yonetim", server, kullaniciAdi, sifre, yetkilendirmeTuru);

            using (var bll = new KurumBll())
            {
                _source = bll.List(null).Cast<Kurum>().ToList();

                txtKurum.Properties.DataSource = _source;
                txtKurum.Properties.ValueMember = "Kod";
                txtKurum.Properties.DisplayMember = "KurumAdi";
                txtKurum.ItemIndex = 0;
            }
        }
        private void CreateConnection()
        {
            if (txtKurum.Text == "")
            {
                Messages.HataMesaji("Kurum seçimi yapmalısınız...");
                txtKurum.Focus();
                return;
            }

            var kurum = _source[txtKurum.ItemIndex];
            var kod = kurum.Kod;
            var server = kurum.Server;
            var yetkilendirmeTuru = kurum.YetkilendirmeTuru;
            var kullaniciAdi = kurum.KullaniciAdi.Decrypt(kurum.Id + kurum.Kod).ConvertToSecureString();
            var sifre = kurum.Sifre.Decrypt(kurum.Id + kurum.Kod).ConvertToSecureString();

            if (!Functions.GeneralFunctions.BaglantiKontrolu(server, kullaniciAdi, sifre, yetkilendirmeTuru)) return;

            Functions.GeneralFunctions.CreateConnectionString(kod, server, kullaniciAdi, sifre, yetkilendirmeTuru);
        }
        private void Giris()
        {
            CreateConnection();

            using (var kullaniciBll = new KullaniciBll())
            {
                var kullanici = (KullaniciS)kullaniciBll.SingleDetail(x => x.Kod == txtKullaniciAdi.Text);

                if (kullanici == null || txtSifre.Text.MD5Sifrele() != kullanici.Sifre)
                {
                    Messages.HataMesaji("Kullanıcı adı veya şifre hatalıdır. Lütfen kontrol ederek tekrar deneyiniz...");
                    txtKullaniciAdi.Focus();
                    return;
                }

                if (!kullanici.Durum)
                {
                    Messages.HataMesaji("Pasif durumdaki kullanıcı ile giriş yapamazsınız...");
                    txtKullaniciAdi.Focus();
                    return;
                }

                using (var parametreBll = new KullaniciParametreBll())
                {
                    var entity = (KullaniciParametreS)parametreBll.Single(x => x.KullaniciId == kullanici.Id);
                    AnaForm.KullaniciParametreleri = entity ?? new KullaniciParametreS();

                    AnaForm.KurumAdi = txtKurum.Text;
                    AnaForm.KullaniciId = kullanici.Id;
                    AnaForm.KullaniciAdi = kullanici.Adi;
                    AnaForm.KullaniciRolId = kullanici.RolId;
                    AnaForm.KullaniciRolAdi = kullanici.RolAdi;

                    Hide();
                    ShowRibbonForms<AnaForm>.ShowForm(false);
                }
            }
        }
        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLocation = new Point(-e.X, -e.Y);
        }
        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            var position = MousePosition;
            position.Offset(_mouseLocation.X, _mouseLocation.Y);
            Location = position;
        }
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        private void Control_Click(object sender, System.EventArgs e)
        {
            switch (sender)
            {
                case MySimpleButton btn:
                    if (btn == btnGiris)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        Giris();
                        Cursor.Current = Cursors.Default;
                    }
                    else if (btn == btnVazgec)
                        Close();
                    break;
                case MyHyperLinkLabelControl hyp:
                    if (hyp == btnBaglantiAyarlari)
                    {
                        if (ShowEditForms<BaglantiAyarlariEditForm>.ShowDialogEditForm(IslemTuru.EntityUpdate))
                            Yukle();
                    }
                    else if (hyp == btnSifremiUnuttum)
                    {
                        CreateConnection();
                        ShowEditForms<SifremiUnuttumEditForm>.ShowDialogEditForm(IslemTuru.EntityUpdate, txtKullaniciAdi.Text);
                    }
                    break;
            }
        }
        private void GirisForm_Shown(object sender, System.EventArgs e)
        {
            txtKullaniciAdi.Focus();
        }
        private void GirisForm_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Baslatiliyor));
            Yukle();
            SplashScreenManager.CloseForm();
        }
    }
}