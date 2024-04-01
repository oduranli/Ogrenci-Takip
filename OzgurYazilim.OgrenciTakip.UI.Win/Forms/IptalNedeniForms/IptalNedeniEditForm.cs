using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.IptalNedeniForms
{
    public partial class IptalNedeniEditForm : BaseEditForm
    {
        public IptalNedeniEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new IptalNedeniBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.IptalNedeni;

            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new IptalNedeni() : ((IptalNedeniBll)Bll).Single(FilterFunctions.Filter<IptalNedeni>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((IptalNedeniBll)Bll).YeniKodVer();
            txtNedenAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (IptalNedeni)OldEntity;
            txtKod.Text = entity.Kod;
            txtNedenAdi.Text = entity.IptalNedeniAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new IptalNedeni
            {
                Id = Id,
                Kod = txtKod.Text,
                IptalNedeniAdi = txtNedenAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
    }
}