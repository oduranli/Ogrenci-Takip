using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using System;
using DevExpress.XtraEditors;

namespace OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms
{
    public partial class KurumBilgileriEditForm : BaseEditForm
    {

        #region Variables

        private readonly string _kod;
        private readonly string _kurumAdi;

        #endregion

        public KurumBilgileriEditForm(params object[] prm)
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new KurumBilgileriBll(myDataLayoutControl);
            HideItems = new BarItem[] { btnYeni, btnSil };

            EventsLoad();

            _kod = prm[0].ToString();
            _kurumAdi = prm[1].ToString();
        }
        public override void Yukle()
        {
            OldEntity = ((KurumBilgileriBll)Bll).Single(null) ?? new KurumBilgileriS();
            BaseIslemTuru = OldEntity.Id == 0 ? IslemTuru.EntityInsert : IslemTuru.EntityUpdate;

            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = _kod;
            txtKurumAdi.Text = _kurumAdi;
            txtKurumAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (KurumBilgileriS)OldEntity;

            Id = entity.Id;
            txtKod.Text = entity.Kod;
            txtKurumAdi.Text = entity.KurumAdi;
            txtVergiDairesi.Text = entity.VergiDairesi;
            txtVergiNo.Text = entity.VergiNo;
            txtIl.Id = entity.IlId;
            txtIl.Text = entity.IlAdi;
            txtIlce.Id = entity.IlceId;
            txtIlce.Text = entity.IlceAdi;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new KurumBilgileri
            {
                Id = Id,
                Kod = txtKod.Text,
                KurumAdi = txtKurumAdi.Text,
                VergiDairesi = txtVergiDairesi.Text,
                VergiNo = txtVergiNo.Text,
                IlId = Convert.ToInt64(txtIl.Id),
                IlceId = Convert.ToInt64(txtIlce.Id)
            };
            ButonEnabledDurumu();
        }
        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
            {
                if (sender == txtIl)
                    sec.Sec(txtIl);
                else if (sender == txtIlce)
                    sec.Sec(txtIlce, txtIl);
            }
        }
        protected override void Control_EnabledChange(object sender, EventArgs e)
        {
            if (sender != txtIl) return;
            txtIl.ControlEnabledChange(txtIlce);
        }
    }
}