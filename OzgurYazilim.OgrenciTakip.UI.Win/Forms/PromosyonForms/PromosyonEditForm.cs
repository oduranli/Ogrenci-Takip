﻿using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.PromosyonForms
{
    public partial class PromosyonEditForm : BaseEditForm
    {
        public PromosyonEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new PromosyonBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Promosyon;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Promosyon() : ((PromosyonBll)Bll).Single(FilterFunctions.Filter<Promosyon>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((PromosyonBll)Bll).YeniKodVer(x => x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
            txtPromosyonAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Promosyon)OldEntity;

            txtKod.Text = entity.Kod;
            txtPromosyonAdi.Text = entity.PromosyonAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Promosyon
            {
                Id = Id,
                Kod = txtKod.Text,
                PromosyonAdi = txtPromosyonAdi.Text,
                Aciklama = txtAciklama.Text,
                SubeId = AnaForm.SubeId,
                DonemId = AnaForm.DonemId,
                Durum = tglDurum.IsOn

            };
            ButonEnabledDurumu();
        }
        protected override bool EntityInsert()
        {
            return ((PromosyonBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }
        protected override bool EntityUpdate()
        {
            return ((PromosyonBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }
    }
}