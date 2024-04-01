using System.Linq;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Common.Functions;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using System.Configuration;
using OzgurYazilim.OgrenciTakip.Bll.Functions;
using DevExpress.Utils.Extensions;
using System;
using DevExpress.XtraEditors;

namespace OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms
{
    public partial class BaglantiAyarlariEditForm : BaseEditForm
    {
        public BaglantiAyarlariEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            HideItems = new BarItem[] { btnYeni, btnSil };
            txtYetkilendirmeTuru.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<YetkilendirmeTuru>());

            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = new BaglantiAyarlari
            {
                Server = ConfigurationManager.AppSettings["Server"],
                YetkilendirmeTuru = ConfigurationManager.AppSettings["YetkilendirmeTuru"].GetEnum<YetkilendirmeTuru>(),
                KullaniciAdi = ConfigurationManager.AppSettings["KullaniciAdi"].ConvertToSecureString(),
                Sifre = ConfigurationManager.AppSettings["YetkilendirmeTuru"].GetEnum<YetkilendirmeTuru>() == YetkilendirmeTuru.SqlServer ? "Burası şifre alanıdır".ConvertToSecureString() : "".ConvertToSecureString(),
            };

            NesneyiKontrollereBagla();
        }
        protected override void NesneyiKontrollereBagla()
        {
            txtServer.Text = ConfigurationManager.AppSettings["Server"];
            txtYetkilendirmeTuru.SelectedItem = ConfigurationManager.AppSettings["YetkilendirmeTuru"];
            txtKullaniciAdi.Text = ConfigurationManager.AppSettings["KullaniciAdi"];
            txtSifre.Text = ConfigurationManager.AppSettings["YetkilendirmeTuru"].GetEnum<YetkilendirmeTuru>() == YetkilendirmeTuru.SqlServer ? "Burası şifre alanıdır" : "";
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new BaglantiAyarlari
            {
                Server = txtServer.Text,
                YetkilendirmeTuru = txtYetkilendirmeTuru.Text.GetEnum<YetkilendirmeTuru>(),
                KullaniciAdi = txtKullaniciAdi.Text.ConvertToSecureString(),
                Sifre = txtSifre.Text.ConvertToSecureString(),
            };

            ButonEnabledDurumu();
        }
        protected override bool EntityUpdate()
        {
            var list = GeneralFunctions.DegisenAlanlariGetir(OldEntity, CurrentEntity).ToList();
            list.ForEach(x =>
            {
                switch (x)
                {
                    case "Server":
                        Functions.GeneralFunctions.AppSettingsWrite(x, txtServer.Text);
                        break;
                    case "YetkilendirmeTuru":
                        Functions.GeneralFunctions.AppSettingsWrite(x, txtYetkilendirmeTuru.Text);
                        break;
                    case "KullaniciAdi":
                        Functions.GeneralFunctions.AppSettingsWrite(x, txtKullaniciAdi.Text);
                        break;
                    case "Sifre":
                        Functions.GeneralFunctions.AppSettingsWrite(x, txtSifre.Text);
                        break;
                }
            });

            return true;
        }
        protected override void Control_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!(sender is ComboBoxEdit edit)) return;

            var yetkilendirmeTuru = edit.Text.GetEnum<YetkilendirmeTuru>();
            txtKullaniciAdi.Enabled = yetkilendirmeTuru == YetkilendirmeTuru.SqlServer;
            txtSifre.Enabled = yetkilendirmeTuru == YetkilendirmeTuru.SqlServer;
            txtKullaniciAdi.Focus();

            if (yetkilendirmeTuru != YetkilendirmeTuru.Windows) return;
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
        }
    }
}