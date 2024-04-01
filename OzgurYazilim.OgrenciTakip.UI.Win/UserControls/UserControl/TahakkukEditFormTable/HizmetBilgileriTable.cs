using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.Base;
using OzgurYazilim.OgrenciTakip.Bll.General;
using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.HizmetForms;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Bll.Functions;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.ServisForms;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using DevExpress.XtraGrid.Views.Base;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.TahakkukForms;
using DevExpress.Utils.Extensions;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.IptalNedeniForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.OkulForms;

namespace OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.TahakkukEditFormTable
{
    public partial class HizmetBilgileriTable : BaseTablo
    {
        public HizmetBilgileriTable()
        {
            InitializeComponent();
            Bll = new HizmetBilgileriBll();
            Tablo = tablo;
            EventsLoad();

            ShowItems = new BarItem[] { btnIptalEt, btnIptalGeriAl };
        }
        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((HizmetBilgileriBll)Bll)
                .List(x => x.TahakkukId == OwnerForm.Id)
                .ToBindingList<HizmetBilgileriL>();
        }
        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;
            ListeDisiTutulacakKayitlar = source.Cast<HizmetBilgileriL>().Where(x => !x.IptalEdildi && !x.Delete).Select(x => x.HizmetId).ToList();

            var entities = ShowListForms<HizmetListForm>.ShowDialogListForm(KartTuru.Hizmet, ListeDisiTutulacakKayitlar, true, true).EntityListConvert<HizmetL>();
            if (entities == null) return;
            foreach (var entity in entities)
            {
                Servis servis = null;

                if (entity.HizmetTipi == HizmetTipi.Servis)
                {
                    servis = (Servis)ShowListForms<ServisListForm>.ShowDialogListForm(KartTuru.Servis, -1);
                    if (servis == null) continue;
                }

                var row = new HizmetBilgileriL
                {
                    TahakkukId = OwnerForm.Id,
                    HizmetId = entity.Id,
                    HizmetAdi = entity.HizmetAdi,
                    HizmetTuruId = entity.HizmetTuruId,
                    HizmetTipi = entity.HizmetTipi,
                    IslemTarihi = DateTime.Now.Date,
                    BaslamaTarihi = entity.BaslamaTarihi,
                    BrutUcret = entity.Ucret,
                    KistDonemDusulenUcret = 0,
                    IptalEdildi = false,
                    Insert = true
                };

                if (servis != null)
                {
                    row.ServisId = servis.Id;
                    row.ServisYeriAdi = servis.ServisYeri;
                    row.BrutUcret = servis.Ucret;
                }

                UcretHesapla(row);

                source.Add(row);
            }
            tablo.Focus();
            tablo.RefreshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            insUptNavigator.Navigator.Buttons.DoClick(insUptNavigator.Navigator.Buttons.EndEdit);
            tablo.FocusedColumn = colHizmetAdi;

            ButonEnabledDurumu(true);
        }
        protected internal override bool HataliGiris()
        {
            bool IndirimToplamiHizmetToplamindanBuyuk(long hizmetId)
            {
                var hizmetToplami = tablo.DataController.ListSource.Cast<HizmetBilgileriL>()
                    .Where(x => x.HizmetId == hizmetId && !x.Delete).Sum(x => x.BrutUcret - x.KistDonemDusulenUcret);
                var indirimToplami = ((TahakkukEditForm)OwnerForm).indirimBilgileriTable.Tablo.DataController.ListSource.Cast<IndirimBilgileriL>()
                    .Where(x => x.HizmetId == hizmetId && !x.Delete).Sum(x => x.BrutIndirim - x.KistDonemDusulenIndirim);
                return indirimToplami > hizmetToplami;
            }
            if (!TableValueChanged) return false;
            if (tablo.HasColumnErrors) tablo.ClearColumnErrors();
            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                var entity = tablo.GetRow<HizmetBilgileriL>(i);
                if (entity.IptalEdildi && entity.HizmetTipi == HizmetTipi.Egitim && AnaForm.DonemParemetreleri.GittigiOkulZorunlu && entity.GittigiOkulId == null)
                {
                    tablo.FocusedRowHandle = i;
                    tablo.FocusedColumn = colGittigiOkulAdi;
                    tablo.SetColumnError(colGittigiOkulAdi, "Gittiği okul adı alanına geçerli bir değer giriniz!");
                }
                if (entity.IptalEdildi && entity.IptalNedeniId == null)
                {
                    tablo.FocusedRowHandle = i;
                    tablo.FocusedColumn = colIptalNedeniAdi;
                    tablo.SetColumnError(colIptalNedeniAdi, "İptal nedeni alanına geçerli bir değer giriniz!");
                }

                if (tablo.HasColumnErrors)
                {
                    Messages.TabloEksikBilgiMesaji($"{tablo.ViewCaption} tablosu");
                    return true;
                }

                if (IndirimToplamiHizmetToplamindanBuyuk(entity.HizmetId))
                {
                    tablo.FocusedRowHandle = i;
                    Messages.HataMesaji($"{entity.HizmetAdi} kartina uygulanan indirimlerin toplamı kartın toplam tutarını aşmaktadır.");
                    return true;
                }
            }

            return false;
        }
        protected override void HareketSil()
        {
            bool HizmetKartinaAitIptalEdilmisHareketVarmi(long hizmetId)
            {
                var count = tablo.DataController.ListSource.Cast<HizmetBilgileriL>().Count(x => x.HizmetId == hizmetId);
                return count < 2 && ((TahakkukEditForm)OwnerForm).indirimBilgileriTable.Tablo.DataController.ListSource.Cast<IndirimBilgileriL>().Any(x => x.HizmetId == hizmetId && x.IptalEdildi);
            }

            if (tablo.DataRowCount == 0) return;
            if (Messages.SilMesaj("Hizmet bilgisi") != DialogResult.Yes) return;

            var entity = tablo.GetRow<HizmetBilgileriL>();
            if (entity.IptalEdildi)
            {
                Messages.IptalHareketSilinemezMesaji();
                return;
            }

            if (HizmetKartinaAitIptalEdilmisHareketVarmi(entity.HizmetId))
            {
                Messages.HataMesaji("Bu hizmet kartına ait iptal edilmiş indirim hareketleri bulunmaktadır. Hizmet kartı silinemez.");
                return;
            }

            ((TahakkukEditForm)OwnerForm).indirimBilgileriTable.TopluHareketSil(entity.HizmetId);
            entity.Delete = true;
            tablo.RefreshDataSource();
            ButonEnabledDurumu(true);
        }

        private void UcretHesapla(HizmetBilgileriL entity)
        {
            var egitimBaslamaTarihi = AnaForm.DonemParemetreleri.EgitimBaslamaTarihi;
            var egitimBitisTarihi = AnaForm.DonemParemetreleri.DonemBitisTarihi;

            var toplamGunSayisi = (int)(egitimBitisTarihi - egitimBaslamaTarihi).TotalDays + 1;
            var gunlukUcret = entity.BrutUcret / toplamGunSayisi;
            var alinanHizmetGunSayisi = entity.IptalTarihi == null ? (int)(egitimBitisTarihi - entity.BaslamaTarihi).TotalDays + 1
                : (int)(entity.IptalTarihi - entity.BaslamaTarihi).Value.TotalDays + 1;
            var odenecekUcret = alinanHizmetGunSayisi > 0 ? gunlukUcret * alinanHizmetGunSayisi : 0;
            var kistDonemDusulenUcret = entity.BrutUcret - odenecekUcret;
            kistDonemDusulenUcret = Math.Round(kistDonemDusulenUcret, AnaForm.DonemParemetreleri.HizmetTahakkukKurusKullan ? 2 : 0);

            if (entity.BaslamaTarihi > egitimBaslamaTarihi || entity.IptalEdildi)
                entity.KistDonemDusulenUcret = kistDonemDusulenUcret;
            else
                entity.KistDonemDusulenUcret = 0;

            entity.NetUcret = entity.BrutUcret - entity.KistDonemDusulenUcret;
            entity.EgitimDonemiGunSayisi = toplamGunSayisi;
            entity.AlinanHizmetGunSayisi = alinanHizmetGunSayisi;
            entity.GunlukUcret = gunlukUcret;
        }
        protected override void IptalEt()
        {
            var entity = tablo.GetRow<HizmetBilgileriL>();
            if (entity == null || entity.IptalEdildi || entity.Insert) return;
            if (Messages.IptalMesaj("Hizmet bilgisi") != DialogResult.Yes) return;

            var iptalNedeni = (IptalNedeni)ShowListForms<IptalNedeniListForm>.ShowDialogListForm(KartTuru.IptalNedeni, -1);
            if (iptalNedeni != null)
            {
                entity.IptalNedeniId = iptalNedeni.Id;
                entity.IptalNedeniAdi = iptalNedeni.IptalNedeniAdi;
            }
            if (entity.HizmetTipi == HizmetTipi.Egitim)
            {
                var gittigiOkul = (OkulL)ShowListForms<OkulListForm>.ShowDialogListForm(KartTuru.Okul, -1);
                if (gittigiOkul != null)
                {
                    entity.GittigiOkulId = gittigiOkul.Id;
                    entity.GittigiOkulAdi = gittigiOkul.OkulAdi;
                }
            }

            entity.IptalTarihi = DateTime.Now.Date;
            entity.HizmetAdi = $"{entity.HizmetAdi} - ( *** İptal edildi *** )";
            entity.IptalEdildi = true;
            entity.Update = true;
            UcretHesapla(entity);

            ((TahakkukEditForm)OwnerForm).indirimBilgileriTable.TopluIptalEt(entity);
            tablo.UpdateSummary();
            tablo.RowCellEnabled();
            tablo.FocusedColumn = colIptalAciklama;
            ButonEnabledDurumu(true);
        }
        protected override void IptalGeriAl()
        {
            bool AyniHizmetAlindi(long hizmetId)
            {
                return tablo.DataController.ListSource.Cast<HizmetBilgileriL>().Any(x => x.HizmetId == hizmetId && !x.IptalEdildi && !x.Delete);
            }

            var entity = tablo.GetRow<HizmetBilgileriL>();
            if (entity == null || !entity.IptalEdildi) return;

            if (Messages.IptalGerialMesaj(entity.HizmetAdi) != DialogResult.Yes) return;

            if (AyniHizmetAlindi(entity.HizmetId))
            {
                Messages.HataMesaji("İptal işleminin geri alınması durumunda aynı hizmetten birden fazla alım durumu oluşuyor.");
                return;
            }
            entity.HizmetAdi = entity.HizmetAdi.Remove(entity.HizmetAdi.Length - 27, 27); //( iptal edildi yazısı 27 karakterden oluşuyor)
            entity.IptalEdildi = false;
            entity.IptalTarihi = null;
            entity.IptalNedeniId = null;
            entity.IptalNedeniAdi = null;
            entity.GittigiOkulId = null;
            entity.GittigiOkulAdi = null;
            entity.IptalAciklama = null;
            entity.Update = true;

            ((TahakkukEditForm)OwnerForm).indirimBilgileriTable.TopluIptalGeriAl(entity.Id);
            UcretHesapla(entity);
            tablo.UpdateSummary();
            tablo.RowCellEnabled();
            ButonEnabledDurumu(true);
        }
        protected override void SutunGizleGoster()
        {
            if (tablo.DataRowCount == 0) return;
            var entity = tablo.GetRow<HizmetBilgileriL>();

            if (entity.HizmetTipi == HizmetTipi.Servis)
            {
                colServisYeriAdi.Visible = true;
                colServisYeriAdi.VisibleIndex = 1;
            }
            else
                colServisYeriAdi.Visible = false;
        }
        protected override void RowCellAllowEdit()
        {
            if (tablo.DataRowCount == 0) return;
            var entity = tablo.GetRow<HizmetBilgileriL>();

            colIptalTarihi.OptionsColumn.AllowEdit = entity.IptalEdildi;
            colIptalNedeniId.OptionsColumn.AllowEdit = entity.IptalEdildi;
            colGittigiOkulAdi.OptionsColumn.AllowEdit = entity.IptalEdildi;
            colIptalAciklama.OptionsColumn.AllowEdit = entity.IptalEdildi;

            if (entity.HizmetTipi != HizmetTipi.Egitim)
                colGittigiOkulAdi.OptionsColumn.AllowEdit = false;
        }
        protected override void Tablo_MouseUp(object sender, MouseEventArgs e)
        {
            base.Tablo_MouseUp(sender, e);

            var entity = (HizmetBilgileriL)tablo.GetRow(Tablo.FocusedRowHandle);
            if (entity == null) return;

            btnHareketSil.Enabled = !entity.IptalEdildi;
            btnIptalEt.Enabled = !entity.IptalEdildi && !entity.Insert;
            btnIptalGeriAl.Enabled = entity.IptalEdildi;
        }
        protected override void Tablo_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            base.Tablo_FocusedColumnChanged(sender, e);

            if (e.FocusedColumn == colIptalNedeniAdi)
                e.FocusedColumn.Sec(tablo, insUptNavigator.Navigator, repositoryIptalNedeni, colIptalNedeniId);
            else if (e.FocusedColumn == colGittigiOkulAdi)
                e.FocusedColumn.Sec(tablo, insUptNavigator.Navigator, repositoryGittigiOkul, colGittigiOkulId);
            else if (e.FocusedColumn == colIptalTarihi)
            {
                var entity = tablo.GetRow<HizmetBilgileriL>();

                if (entity.IptalTarihi == null) return;

                repositoryIptalTarihi.MinValue = AnaForm.DonemParemetreleri.GunTarihininOncesineIptalTarihiGirilebilir ? entity.BaslamaTarihi : DateTime.Now.Date;
                repositoryIptalTarihi.MaxValue = AnaForm.DonemParemetreleri.GunTarihininSonrasinaIptalTarihiGirilebilir ? AnaForm.DonemParemetreleri.DonemBitisTarihi.AddDays(-1) : DateTime.Now.Date;
            }
        }
        protected override void Tablo_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            base.Tablo_CellValueChanged(sender, e);

            var entity = tablo.GetRow<HizmetBilgileriL>();

            if (e.Column == colIptalNedeniAdi)
            {
                ((TahakkukEditForm)OwnerForm).indirimBilgileriTable.Tablo.DataController.ListSource.Cast<IndirimBilgileriL>()
                    .Where(x => x.IptalEdildi && x.HizmetHareketId == entity.Id).ForEach(x => x.IptalNedeniId = entity.IptalNedeniId);
                ((TahakkukEditForm)OwnerForm).indirimBilgileriTable.Tablo.DataController.ListSource.Cast<IndirimBilgileriL>()
                    .Where(x => x.IptalEdildi && x.HizmetHareketId == entity.Id).ForEach(x => x.IptalNedeniAdi = entity.IptalNedeniAdi);
            }
            else if (e.Column == colIptalAciklama)
                ((TahakkukEditForm)OwnerForm).indirimBilgileriTable.Tablo.DataController.ListSource.Cast<IndirimBilgileriL>()
                    .Where(x => x.IptalEdildi && x.HizmetHareketId == entity.Id).ForEach(x => x.IptalAciklama = entity.IptalAciklama);

            else if (e.Column == colIptalTarihi)
            {
                UcretHesapla(entity);
                ((TahakkukEditForm)OwnerForm).indirimBilgileriTable.Tablo.DataController.ListSource.Cast<IndirimBilgileriL>()
                    .Where(x => x.IptalEdildi && x.HizmetHareketId == entity.Id).ForEach(x => x.IptalTarihi = entity.IptalTarihi);
                ((TahakkukEditForm)OwnerForm).indirimBilgileriTable.TopluIndirimHesapla();
            }
        }
    }
}