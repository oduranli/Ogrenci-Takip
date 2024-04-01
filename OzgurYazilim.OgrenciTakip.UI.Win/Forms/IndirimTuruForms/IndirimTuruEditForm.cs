using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.IndirimTuruForms
{
    public partial class IndirimTuruEditForm : BaseEditForm
    {
        public IndirimTuruEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new IndirimTuruBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.IndirimTuru;

            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new IndirimTuru() : ((IndirimTuruBll)Bll).Single(FilterFunctions.Filter<IndirimTuru>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((IndirimTuruBll)Bll).YeniKodVer();
            txtIndirimTuruAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (IndirimTuru)OldEntity;
            txtKod.Text = entity.Kod;
            txtIndirimTuruAdi.Text = entity.IndirimTuruAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new IndirimTuru
            {
                Id = Id,
                Kod = txtKod.Text,
                IndirimTuruAdi = txtIndirimTuruAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
    }
}