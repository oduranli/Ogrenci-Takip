﻿using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.RaporForms
{
    public partial class RaporEditForm : BaseEditForm
    {

        #region Variables

        private readonly KartTuru _raporTuru;
        private readonly RaporBolumTuru _raporBolumTuru;
        private readonly byte[] _dosya;

        #endregion

        public RaporEditForm(params object[] prm)
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new RaporBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Rapor;

            EventsLoad();

            _raporTuru = (KartTuru)prm[0];
            _raporBolumTuru = (RaporBolumTuru)prm[1];
            _dosya = (byte[])prm[2];
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Rapor() : ((RaporBll)Bll).Single(FilterFunctions.Filter<Rapor>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((RaporBll)Bll).YeniKodVer(x => x.RaporBolumTuru == _raporBolumTuru && x.RaporTuru == _raporTuru);
            txtRaporAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Rapor)OldEntity;
            txtKod.Text = entity.Kod;
            txtRaporAdi.Text = entity.RaporAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Rapor
            {
                Id = Id,
                Kod = txtKod.Text,
                RaporAdi = txtRaporAdi.Text,
                Aciklama = txtAciklama.Text,
                RaporTuru = _raporTuru,
                RaporBolumTuru = _raporBolumTuru,
                Dosya = _dosya,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
        protected override bool EntityInsert()
        {
            return ((RaporBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.RaporBolumTuru == _raporBolumTuru && x.RaporTuru == _raporTuru);
        }
        protected override bool EntityUpdate()
        {
            return ((RaporBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.RaporBolumTuru == _raporBolumTuru && x.RaporTuru == _raporTuru);
        }
    }
}