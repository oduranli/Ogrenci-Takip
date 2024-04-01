using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Reports.FormReports.Base;
using System;
using System.Linq;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Reports.FormReports
{
    public partial class UcretOrtalamalariRaporu : BaseRapor
    {
        public UcretOrtalamalariRaporu()
        {
            InitializeComponent();
            HideItems = new BarItem[] { btnKartAc };
        }
        protected override void DegiskenleriDoldur()
        {
            DataLayoutControl = myDataLayoutControl;
            Tablo = tablo;
            Navigator = longNavigator.Navigator;
            Subeler = txtSubeler;
            KayitSekilleri = txtKayitSekli;
            KayitDurumlari = txtKayitDurumu;
            IptalDurumlari = txtIptalDurumu;

            SubeKartlariYukle();
            KayitSekliYukle();
            KayitDurumuYukle();
            IptalDurumuYukle();
            RaporTuru = KartTuru.UcretOrtalamalariRaporu;
        }
        protected override void Listele()
        {
            var subeler = txtSubeler.CheckedComboboxList<long>();
            var kayitSekli = txtKayitSekli.CheckedComboboxList<KayitSekli>();
            var kayitDurumu = txtKayitDurumu.CheckedComboboxList<KayitDurumu>();
            var iptalDurumu = txtIptalDurumu.CheckedComboboxList<IptalDurumu>();

            using (var bll = new UcretOrtalamalariRaporuBll())
            {
                tablo.GridControl.DataSource = bll.List(x =>
                    subeler.Contains(x.SubeId) &&
                    kayitSekli.Contains(x.KayitSekli) &&
                    kayitDurumu.Contains(x.KayitDurumu) &&
                    iptalDurumu.Contains(x.Durum ? IptalDurumu.DevamEdiyor : IptalDurumu.IptalEdildi) &&
                    x.DonemId == AnaForm.DonemId
                    );

                base.Listele();
            }
        }

        protected override void Tablo_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess != CustomSummaryProcess.Finalize) return;

            var item = (GridSummaryItem)e.Item;

            switch (item.FieldName)
            {
                case "colUcretliOrtalama":

                    if (e.IsGroupSummary)
                    {
                        var ucretliOgrenci = Convert.ToDecimal(Tablo.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)Tablo.GroupSummary["UcretliOgrenci"]));
                        var netUcret = Convert.ToDecimal(Tablo.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)Tablo.GroupSummary["NetUcret"]));

                        e.TotalValue = ucretliOgrenci == 0 ? 0 : netUcret / ucretliOgrenci;
                    }
                    else if (e.IsTotalSummary)
                    {
                        var ucretliOgrenci = Convert.ToDecimal(colUcretliOgrenci.SummaryItem.SummaryValue);
                        var netUcret = Convert.ToDecimal(colNetUcret.SummaryItem.SummaryValue);

                        e.TotalValue = ucretliOgrenci == 0 ? 0 : netUcret / ucretliOgrenci;
                    }
                    break;
                case "colUcretsizDahilOrtalama":

                    if (e.IsGroupSummary)
                    {
                        var ogrenciSayisi = Convert.ToDecimal(Tablo.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)Tablo.GroupSummary["ToplamOgrenci"]));
                        var netUcret = Convert.ToDecimal(Tablo.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)Tablo.GroupSummary["NetUcret"]));

                        e.TotalValue = ogrenciSayisi == 0 ? 0 : netUcret / ogrenciSayisi;
                    }
                    else if (e.IsTotalSummary)
                    {
                        var ogrenciSayisi = Convert.ToDecimal(colToplamOgrenci.SummaryItem.SummaryValue);
                        var netUcret = Convert.ToDecimal(colNetUcret.SummaryItem.SummaryValue);

                        e.TotalValue = ogrenciSayisi == 0 ? 0 : netUcret / ogrenciSayisi;
                    }
                    break;
                case "colSinifOrtalama":

                    if (e.IsGroupSummary)
                    {
                        var ogrenciSayisi = Convert.ToDecimal(Tablo.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)Tablo.GroupSummary["ToplamOgrenci"]));
                        var sinifSayisi = Convert.ToDecimal(Tablo.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)Tablo.GroupSummary["SinifSayisi"]));

                        e.TotalValue = ogrenciSayisi == 0 ? 0 : sinifSayisi / ogrenciSayisi;
                    }
                    else if (e.IsTotalSummary)
                    {
                        var ogrenciSayisi = Convert.ToDecimal(colToplamOgrenci.SummaryItem.SummaryValue);
                        var sinifSayisi = Convert.ToDecimal(colSinifSayisi.SummaryItem.SummaryValue);

                        e.TotalValue = ogrenciSayisi == 0 ? 0 : sinifSayisi / ogrenciSayisi;
                    }
                    break;
            }

        }
    }
}