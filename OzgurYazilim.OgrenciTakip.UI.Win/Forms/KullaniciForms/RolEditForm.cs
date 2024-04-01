using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using System;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.KullaniciForms
{
    public partial class RolEditForm : BaseEditForm
    {
        public RolEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new RolBll(myDataLayoutControl);

            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Rol() : ((RolBll)Bll).Single(FilterFunctions.Filter<Rol>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((RolBll)Bll).YeniKodVer();
            txtRolAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Rol)OldEntity;
            txtKod.Text = entity.Kod;
            txtRolAdi.Text = entity.RolAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Rol
            {
                Id = Id,
                Kod = txtKod.Text,
                RolAdi = txtRolAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
        protected override void TabloYukle()
        {
            rolYetkileriTable.OwnerForm = this;
            rolYetkileriTable.Yukle();
        }
        protected internal override void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;
            GeneralFunctions.ButonEnabledDurumu(btnYeni, btnKaydet, btnGeriAl, btnSil, OldEntity, CurrentEntity, rolYetkileriTable.TableValueChanged);
        }
        protected override bool EntityInsert()
        {
            return ((RolBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod) && rolYetkileriTable.Kaydet();
        }
        protected override bool EntityUpdate()
        {
            return ((RolBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod) && rolYetkileriTable.Kaydet();
        }
        protected override void BaseEditForm_Shown(object sender, EventArgs e)
        {
            if (BaseIslemTuru == IslemTuru.EntityUpdate)
                rolYetkileriTable.Tablo.Focus();
        }
    }
}