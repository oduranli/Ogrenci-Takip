using DevExpress.XtraEditors;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Common.Functions;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using System;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.IletisimForms
{
    public partial class IletisimEditForm : BaseEditForm
    {
        public IletisimEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new IletisimBll(myDataLayoutControl);
            txtKanGrubu.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<KanGrubu>());
            BaseKartTuru = KartTuru.Iletisim;

            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new IletisimS() : ((IletisimBll)Bll).Single(FilterFunctions.Filter<Iletisim>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((IletisimBll)Bll).YeniKodVer();
            txtTcKimlikNo.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (IletisimS)OldEntity;
            txtKod.Text = entity.Kod;
            txtTcKimlikNo.Text = entity.TcKimlikNo;
            txtAdi.Text = entity.Adi;
            txtSoyadi.Text = entity.Soyadi;
            txtEvTelefonu.Text = entity.EvTelefonu;
            txtIsTelefonu1.Text = entity.IsTelefonu1;
            txtIsTelefonu2.Text = entity.IsTelefonu2;
            txtDahili1.Text = entity.Dahili1;
            txtDahili2.Text = entity.Dahili2;
            txtCepTelefonu1.Text = entity.CepTelefonu1;
            txtCepTelefonu2.Text = entity.CepTelefonu2;
            txtWeb.Text = entity.Web;
            txtEmail.Text = entity.Email;
            txtIbanNo.Text = entity.IbanNo;
            txtKartNo.Text = entity.KartNo;
            txtEvAdres.Text = entity.EvAdres;
            txtEvAdresIl.Id = entity.EvAdresIlId;
            txtEvAdresIl.Text = entity.EvAdresIlAdi;
            txtEvAdresIlce.Id = entity.EvAdresIlceId;
            txtEvAdresIlce.Text = entity.EvAdresIlceAdi;
            txtIsAdres.Text = entity.IsAdres;
            txtIsAdresIl.Id = entity.IsAdresIlId;
            txtIsAdresIl.Text = entity.IsAdresIlAdi;
            txtIsAdresIlce.Id = entity.IsAdresIlceId;
            txtIsAdresIlce.Text = entity.IsAdresIlceAdi;
            txtIsyeri.Id = entity.IsyeriId;
            txtIsyeri.Text = entity.IsyeriAdi;
            txtMeslek.Id = entity.MeslekId;
            txtMeslek.Text = entity.MeslekAdi;
            txtGorev.Id = entity.GorevId;
            txtGorev.Text = entity.GorevAdi;
            txtAnaAdi.Text = entity.AnaAdi;
            txtBabaAdi.Text = entity.BabaAdi;
            txtDogumYeri.Text = entity.DogumYeri;
            txtDogumTarihi.EditValue = entity.DogumTarihi;
            txtKanGrubu.SelectedItem = entity.KanGrubu.ToName();
            txtKimlikSeri.Text = entity.KimlikSeri;
            txtKimlikSiraNo.Text = entity.KimlikSiraNo;
            txtKimlikIl.Id = entity.KimlikIlId;
            txtKimlikIl.Text = entity.KimlikIlAdi;
            txtKimlikIlce.Id = entity.KimlikIlceId;
            txtKimlikIlce.Text = entity.KimlikIlceAdi;
            txtKimlikMahalleKoy.Text = entity.KimlikMahalleKoy;
            txtKimlikCiltNo.Text = entity.KimlikCiltNo;
            txtKimlikAileSiraNo.Text = entity.KimlikAileSiraNo;
            txtKimlikBireySiraNo.Text = entity.KimlikBireySiraNo;
            txtKimlikVerildigiYer.Text = entity.KimlikVerildigiYer;
            txtKimlikVerilisNedeni.Text = entity.KimlikVerilisNedeni;
            txtKimlikKayitNo.Text = entity.KimlikKayitNo;
            txtKimlikVerilisTarihi.EditValue = entity.KimlikVerilisTarihi;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Iletisim
            {
                Id = Id,
                Kod = txtKod.Text,
                TcKimlikNo = txtTcKimlikNo.Text,
                Adi = txtAdi.Text,
                Soyadi = txtSoyadi.Text,
                EvTelefonu = txtEvTelefonu.Text,
                IsTelefonu1 = txtIsTelefonu1.Text,
                IsTelefonu2 = txtIsTelefonu2.Text,
                Dahili1 = txtDahili1.Text,
                Dahili2 = txtDahili2.Text,
                CepTelefonu1 = txtCepTelefonu1.Text,
                CepTelefonu2 = txtCepTelefonu2.Text,
                Web = txtWeb.Text,
                Email = txtEmail.Text,
                IbanNo = txtIbanNo.Text,
                KartNo = txtKartNo.Text,
                EvAdres = txtEvAdres.Text,
                EvAdresIlId = txtEvAdresIl.Id,
                EvAdresIlceId = txtEvAdresIlce.Id,
                IsAdres = txtIsAdres.Text,
                IsAdresIlId = txtIsAdresIl.Id,
                IsAdresIlceId = txtIsAdresIlce.Id,
                MeslekId = txtMeslek.Id,
                IsyeriId = txtIsyeri.Id,
                GorevId = txtGorev.Id,
                AnaAdi = txtAnaAdi.Text,
                BabaAdi = txtBabaAdi.Text,
                DogumYeri = txtDogumYeri.Text,
                DogumTarihi = (DateTime?)txtDogumTarihi.EditValue,
                KanGrubu = txtKanGrubu.Text.GetEnum<KanGrubu>(),
                KimlikSeri = txtKimlikSeri.Text,
                KimlikSiraNo = txtKimlikSiraNo.Text,
                KimlikIlId = txtKimlikIl.Id,
                KimlikIlceId = txtKimlikIlce.Id,
                KimlikMahalleKoy = txtKimlikMahalleKoy.Text,
                KimlikCiltNo = txtKimlikCiltNo.Text,
                KimlikAileSiraNo = txtKimlikAileSiraNo.Text,
                KimlikBireySiraNo = txtKimlikBireySiraNo.Text,
                KimlikVerildigiYer = txtKimlikVerildigiYer.Text,
                KimlikVerilisNedeni = txtKimlikVerilisNedeni.Text,
                KimlikKayitNo = txtKimlikKayitNo.Text,
                KimlikVerilisTarihi = (DateTime?)txtKimlikVerilisTarihi.EditValue,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
                if (sender == txtEvAdresIl)
                    sec.Sec(txtEvAdresIl);
                else if (sender == txtEvAdresIlce)
                    sec.Sec(txtEvAdresIlce, txtEvAdresIl);
                else if (sender == txtIsAdresIl)
                    sec.Sec(txtIsAdresIl);
                else if (sender == txtIsAdresIlce)
                    sec.Sec(txtIsAdresIlce, txtIsAdresIl);
                else if (sender == txtMeslek)
                    sec.Sec(txtMeslek);
                else if (sender == txtGorev)
                    sec.Sec(txtGorev);
                else if (sender == txtIsyeri)
                    sec.Sec(txtIsyeri);
                else if (sender == txtKimlikIl)
                    sec.Sec(txtKimlikIl);
                else if (sender == txtKimlikIlce)
                    sec.Sec(txtKimlikIlce, txtKimlikIl);
                else if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.Iletisim);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.Iletisim);
        }
        protected override void Control_EnabledChange(object sender, EventArgs e)
        {
            if (sender != txtEvAdresIl && sender != txtIsAdresIl && sender != txtKimlikIl) return;
            if (sender == txtEvAdresIl)
                txtEvAdresIl.ControlEnabledChange(txtEvAdresIlce);
            else if (sender == txtIsAdresIl)
                txtIsAdresIl.ControlEnabledChange(txtIsAdresIlce);
            else if (sender == txtKimlikIl)
                txtKimlikIl.ControlEnabledChange(txtKimlikIlce);
        }
    }
}