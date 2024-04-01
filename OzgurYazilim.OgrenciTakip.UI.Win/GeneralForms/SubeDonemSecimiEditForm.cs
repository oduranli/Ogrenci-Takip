using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms
{
    public partial class SubeDonemSecimiEditForm : BaseEditForm
    {

        #region Variables

        private readonly long _kullaniciId;
        private readonly bool _subeSecimButonunaBasildi;
        private readonly long _seciliGelecekSubeId;
        private readonly long _seciliGelecekDonemId;
        private bool _girisButonunaBasildi;
        private List<long> _yetkiliOlunanSubeler;

        #endregion

        public SubeDonemSecimiEditForm(params object[] prm)
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            HideItems = new BarItem[] { btnYeni, btnSil, btnKaydet, btnGeriAl };
            ShowItems = new BarItem[] { btnGiris };
            subeNavigator.Navigator.NavigatableControl = subeGrid;
            donemNavigator.Navigator.NavigatableControl = donemGrid;

            EventsLoad();

            _kullaniciId = (long)prm[0];
            _subeSecimButonunaBasildi = (bool)prm[1];
            _seciliGelecekSubeId = (long)prm[2];
            _seciliGelecekDonemId = (long)prm[3];
        }
        public override void Yukle()
        {
            using (var bll = new KullaniciBirimYetkileriBll())
            {
                var yetkiler = bll.List(x => x.KullaniciId == _kullaniciId).Cast<KullaniciBirimYetkileriL>().ToList();
                _yetkiliOlunanSubeler = yetkiler.Where(x => x.SubeId > 0).Select(x => x.SubeId.Value).ToList();
                var subeSource = yetkiler.Where(x => x.SubeId > 0).ToList();
                var donemSource = yetkiler.Where(x => x.DonemId > 0).ToList();

                if (subeSource.Count == 0)
                {
                    Messages.HataMesaji("Kullanıcı hiçbir şubede yetkilendirilmediği için giriş yapamazsınız.");
                    Application.ExitThread();
                }
                if (donemSource.Count == 0)
                {
                    Messages.HataMesaji("Kullanıcı hiçbir dönemde yetkilendirilmediği için giriş yapamazsınız.");
                    Application.ExitThread();
                }

                subeGrid.DataSource = subeSource;
                donemGrid.DataSource = donemSource;

                if (!_subeSecimButonunaBasildi) return;
                subeTablo.RowFocus("SubeId", _seciliGelecekSubeId);
                donemTablo.RowFocus("DonemId", _seciliGelecekDonemId);
            }
        }
        public override void Giris()
        {
            var sube = subeTablo.GetRow<KullaniciBirimYetkileriL>();
            var donem = donemTablo.GetRow<KullaniciBirimYetkileriL>();

            using (var bll = new DonemParametreBll())
            {
                var entity = (DonemParemetre)bll.Single(x => x.SubeId == sube.SubeId && x.DonemId == donem.DonemId);
                if (entity == null)
                {
                    Messages.HataMesaji("Seçtiğiniz şubenin ilgili dönemine ait parametreler girilmemiş. Lütfen sistem yöneticinize başvurunuz.");
                    return;
                }

                AnaForm.DonemParemetreleri = entity;
                AnaForm.YetkiliOlunanSubeler = _yetkiliOlunanSubeler;
                AnaForm.SubeId = sube.SubeId.Value;
                AnaForm.SubeAdi = sube.SubeAdi;
                AnaForm.DonemId = donem.DonemId.Value;
                AnaForm.DonemAdi = donem.DonemAdi;
            }

            _girisButonunaBasildi = true;
            Close();
        }
        protected override void Control_KeyDown(object sender, KeyEventArgs e)
        {
            base.Control_KeyDown(sender, e);

            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Tab && e.KeyCode != Keys.Right && e.KeyCode != Keys.Left) return;

            if (sender == subeGrid)
                donemGrid.Focus();
            else
                subeGrid.Focus();
        }
        protected override void BaseEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.BaseEditForm_FormClosing(sender, e);

            if (_girisButonunaBasildi || _subeSecimButonunaBasildi) return;

            if (Messages.HayirSeciliEvetHayir("Programdan çıkmak istiyor musunuz?", "Çıkış Onayı!") == DialogResult.Yes)
                Application.ExitThread();
            else
                e.Cancel = true;
        }
    }
}