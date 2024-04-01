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
using OzgurYazilim.OgrenciTakip.UI.Win.Reports.FormReports.Base;
using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using DevExpress.Data;
using DevExpress.XtraGrid;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Reports.FormReports
{
    public partial class MesleklereGoreKayitRaporu : BaseRapor
    {
        public MesleklereGoreKayitRaporu()
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
            RaporTuru = KartTuru.MesleklereGoreKayitRaporu;
        }
        protected override void Listele()
        {
            var subeler = txtSubeler.CheckedComboboxList<long>();
            var kayitSekli = txtKayitSekli.CheckedComboboxList<KayitSekli>();
            var kayitDurumu = txtKayitDurumu.CheckedComboboxList<KayitDurumu>();
            var iptalDurumu = txtIptalDurumu.CheckedComboboxList<IptalDurumu>();

            using (var bll = new MesleklereGoreKayitRaporuBll())
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
            if (item.FieldName == "colIndirimOrani")
            {
                if (e.IsGroupSummary)
                {
                    var hizmetlerToplami = Convert.ToDecimal(Tablo.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)Tablo.GroupSummary["NetHizmet"]));
                    var indirimlerToplami = Convert.ToDecimal(Tablo.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)Tablo.GroupSummary["NetIndirim"]));

                    e.TotalValue = hizmetlerToplami == 0 ? 0 : indirimlerToplami / hizmetlerToplami * 100;
                }
                else if (e.IsTotalSummary)
                {
                    var hizmetlerToplami = Convert.ToDecimal(colNetHizmet.SummaryItem.SummaryValue);
                    var indirimlerToplami = Convert.ToDecimal(colNetIndirim.SummaryItem.SummaryValue);

                    e.TotalValue = hizmetlerToplami == 0 ? 0 : indirimlerToplami / hizmetlerToplami * 100;
                }
            }
            if (item.FieldName != "colOrtalama") return;
            if (e.IsGroupSummary)
            {
                var toplamKayit = Convert.ToDecimal(Tablo.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)Tablo.GroupSummary["ToplamKayit"]));
                var netUcret = Convert.ToDecimal(Tablo.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)Tablo.GroupSummary["NetUcret"]));

                e.TotalValue = toplamKayit == 0 ? 0 : netUcret / toplamKayit;
            }
            else if (e.IsTotalSummary)
            {
                var toplamKayit = Convert.ToDecimal(colToplamKayit.SummaryItem.SummaryValue);
                var netUcret = Convert.ToDecimal(colNetUcret.SummaryItem.SummaryValue);

                e.TotalValue = toplamKayit == 0 ? 0 : netUcret / toplamKayit;
            }
        }
    }
}