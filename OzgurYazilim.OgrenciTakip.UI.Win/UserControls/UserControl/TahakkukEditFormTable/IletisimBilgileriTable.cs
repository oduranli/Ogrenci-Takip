using System.Data;
using System.Linq;
using OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.Base;
using OzgurYazilim.OgrenciTakip.Bll.General;
using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.IletisimForms;
using OzgurYazilim.OgrenciTakip.Bll.Functions;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.YakinlikForms;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using System;
using DevExpress.XtraGrid.Views.Base;

namespace OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.TahakkukEditFormTable
{
    public partial class IletisimBilgileriTable : BaseTablo
    {
        public IletisimBilgileriTable()
        {
            InitializeComponent();
            Bll = new IletisimBilgileriBll();
            Tablo = tablo;
            EventsLoad();
            ShowItems = new BarItem[] { btnKartDuzenle };
            repositoryAdres.Items.AddEnum<AdresTuru>();
        }
        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((IletisimBilgileriBll)Bll)
                .List(x => x.TahakkukId == OwnerForm.Id)
                .ToBindingList<IletisimBilgileriL>();
        }
        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;
            ListeDisiTutulacakKayitlar = source.Cast<IletisimBilgileriL>().Where(x => !x.Delete).Select(x => x.IletisimId).ToList();

            var entities = ShowListForms<IletisimListForm>.ShowDialogListForm(KartTuru.Iletisim, ListeDisiTutulacakKayitlar, true, false).EntityListConvert<IletisimL>();
            if (entities == null) return;
            foreach (var entity in entities)
            {
                var row = new IletisimBilgileriL
                {
                    TahakkukId = OwnerForm.Id,
                    IletisimId = entity.Id,
                    TcKimlikNo = entity.TcKimlikNo,
                    Adi = entity.Adi,
                    Soyadi = entity.Soyadi,
                    EvTelefonu = entity.EvTelefonu,
                    IsTelefonu1 = entity.IsTelefonu1,
                    IsTelefonu2 = entity.IsTelefonu2,
                    CepTelefonu1 = entity.CepTelefonu1,
                    CepTelefonu2 = entity.CepTelefonu2,
                    EvAdres = entity.EvAdres,
                    EvAdresIlAdi = entity.EvAdresIlAdi,
                    EvAdresIlceAdi = entity.EvAdresIlceAdi,
                    IsAdres = entity.IsAdres,
                    IsAdresIlAdi = entity.IsAdresIlAdi,
                    IsAdresIlceAdi = entity.IsAdresIlceAdi,
                    GorevAdi = entity.GorevAdi,
                    IsYeriAdi = entity.IsyeriAdi,
                    MeslekAdi = entity.MeslekAdi,

                    Insert = true
                };
                if (source.Count == 0)
                {
                    row.Veli = true;
                    row.FaturaAdresi = AdresTuru.EvAdresi;
                }

                var yakinlik = (Yakinlik)ShowListForms<YakinlikListForm>.ShowDialogListForm(KartTuru.Yakinlik, -1);
                if (yakinlik == null) return;

                row.YakinlikId = yakinlik.Id;
                row.YakinlikAdi = yakinlik.YakinlikAdi;

                source.Add(row);
            }
            tablo.Focus();
            tablo.RefreshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colVeli;

            ButonEnabledDurumu(true);
        }
        protected internal override bool HataliGiris()
        {
            if (!TableValueChanged) return false;
            if (tablo.HasColumnErrors) tablo.ClearColumnErrors();
            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                var entity = tablo.GetRow<IletisimBilgileriL>(i);
                if (entity.YakinlikAdi == null)
                {
                    tablo.FocusedRowHandle = i;
                    tablo.FocusedColumn = colYakinlikAdi;
                    tablo.SetColumnError(colYakinlikAdi, "Yakınlık adı alanına geçerli bir değer giriniz!");
                }

                if (!tablo.HasColumnErrors) continue;
                Messages.TabloEksikBilgiMesaji($"{tablo.ViewCaption} tablosu");
                return true;
            }

            return false;
        }
        protected override void OpenEntity()
        {
            var entity = tablo.GetRow<IletisimBilgileriL>();
            if (entity == null) return;
            ShowEditForms<IletisimEditForm>.ShowDialogEditForm(KartTuru.Iletisim, entity.IletisimId, null);
        }
        protected override void ImageComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var source = tablo.DataController.ListSource.Cast<IletisimBilgileriL>().ToList();
            if (source.Count == 0) return;

            var rowHandle = tablo.FocusedRowHandle;

            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                if (i == rowHandle) continue;

                if (source[i].FaturaAdresi == null) continue;
                source[i].FaturaAdresi = null;

                if (!source[i].Insert)
                    source[i].Update = true;
            }
            insUptNavigator.Navigator.Buttons.DoClick(insUptNavigator.Navigator.Buttons.EndEdit);
        }
        protected override void CheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            var source = tablo.DataController.ListSource.Cast<IletisimBilgileriL>().ToList();
            if (source.Count == 0) return;

            var rowHandle = tablo.FocusedRowHandle;
            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                if (i == rowHandle) continue;

                if (!source[i].Veli) continue;
                source[i].Veli = false;

                if (!source[i].Insert)
                    source[i].Update = true;
            }
            insUptNavigator.Navigator.Buttons.DoClick(insUptNavigator.Navigator.Buttons.EndEdit);
        }
        protected override void Tablo_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            base.Tablo_FocusedColumnChanged(sender, e);

            if (e.FocusedColumn == colYakinlikAdi)
                e.FocusedColumn.Sec(tablo, insUptNavigator.Navigator, repositoryYakinlik, colYakinlikId);
        }
    }
}