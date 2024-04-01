using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.SinifGrupForms
{
    public partial class SinifGrupEditForm : BaseEditForm
    {
        public SinifGrupEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new SinifGrupBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.SinifGrup;

            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new SinifGrup() : ((SinifGrupBll)Bll).Single(FilterFunctions.Filter<SinifGrup>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((SinifGrupBll)Bll).YeniKodVer();
            txtGrupAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (SinifGrup)OldEntity;
            txtKod.Text = entity.Kod;
            txtGrupAdi.Text = entity.GrupAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new SinifGrup
            {
                Id = Id,
                Kod = txtKod.Text,
                GrupAdi = txtGrupAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
    }
}