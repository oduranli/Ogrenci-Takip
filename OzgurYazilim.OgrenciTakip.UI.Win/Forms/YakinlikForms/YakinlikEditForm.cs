﻿using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.YakinlikForms
{
    public partial class YakinlikEditForm : BaseEditForm
    {
        public YakinlikEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new YakinlikBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Yakinlik;

            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Yakinlik() : ((YakinlikBll)Bll).Single(FilterFunctions.Filter<Yakinlik>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((YakinlikBll)Bll).YeniKodVer();
            txtYakinlikAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Yakinlik)OldEntity;
            txtKod.Text = entity.Kod;
            txtYakinlikAdi.Text = entity.YakinlikAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Yakinlik
            {
                Id = Id,
                Kod = txtKod.Text,
                YakinlikAdi = txtYakinlikAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
    }
}