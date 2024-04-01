using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Model.Entities;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.YabanciDilForms
{
    public partial class YabanciDilEditForm : BaseEditForm
    {
        public YabanciDilEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new YabanciDilBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.YabanciDil;

            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new YabanciDil() : ((YabanciDilBll)Bll).Single(FilterFunctions.Filter<YabanciDil>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((YabanciDilBll)Bll).YeniKodVer();
            txtDilAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (YabanciDil)OldEntity;
            txtKod.Text = entity.Kod;
            txtDilAdi.Text = entity.DilAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new YabanciDil
            {
                Id = Id,
                Kod = txtKod.Text,
                DilAdi = txtDilAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
    }
}