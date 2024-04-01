using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Common.Functions;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.MakbuzForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Reports.FormReports.Base;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Reports.FormReports
{
    public partial class TahsilatRaporu : BaseRapor
    {
        public TahsilatRaporu()
        {
            InitializeComponent();
            ShowItems = new BarItem[] { btnBelgeHareketleri };
        }
        protected override void DegiskenleriDoldur()
        {
            DataLayoutControl = myDataLayoutControl;
            Tablo = tablo;
            Navigator = longNavigator.Navigator;
            Subeler = txtSubeler;
            Odemeler = txtOdemeler;
            BelgeDurumlari = txtBelgeDurumlari;
            KayitSekilleri = txtKayitSekli;
            KayitDurumlari = txtKayitDurumu;
            IptalDurumlari = txtIptalDurumu;
            IlkTarih = txtIlkTarih;
            SonTarih = txtSonTarih;

            SubeKartlariYukle();
            KayitSekliYukle();
            KayitDurumuYukle();
            IptalDurumuYukle();
            OdemeTurleriYukle();
            BelgeDurumuYukle();
            txtIlkTarih.DateTime = DateTime.Now.Date;
            txtSonTarih.DateTime = DateTime.Now.Date;

            RaporTuru = KartTuru.TahsilatRaporu;
        }
        protected override void Listele()
        {
            var subeler = txtSubeler.CheckedComboboxList<long>();
            var odemeler = txtOdemeler.CheckedComboboxList<OdemeTipi>();
            var kayitSekli = txtKayitSekli.CheckedComboboxList<KayitSekli>();
            var kayitDurumu = txtKayitDurumu.CheckedComboboxList<KayitDurumu>();
            var iptalDurumu = txtIptalDurumu.CheckedComboboxList<IptalDurumu>();
            var belgeDurumlari = txtBelgeDurumlari.CheckedComboboxList<BelgeDurumu>();


            using (var bll = new TahsilatRaporuBll())
            {
                tablo.GridControl.DataSource = bll.List(x =>
                    subeler.Contains(x.OdemeBilgileri.Tahakkuk.SubeId) &&
                    odemeler.Contains(x.OdemeBilgileri.OdemeTipi) &&
                    kayitSekli.Contains(x.OdemeBilgileri.Tahakkuk.KayitSekli) &&
                    kayitDurumu.Contains(x.OdemeBilgileri.Tahakkuk.KayitDurumu) &&
                    iptalDurumu.Contains(x.OdemeBilgileri.Tahakkuk.Durum ? IptalDurumu.DevamEdiyor : IptalDurumu.IptalEdildi) &&
                    belgeDurumlari.Contains(x.BelgeDurumu) &&
                    x.Makbuz.Tarih >= txtIlkTarih.DateTime.Date &&
                    x.Makbuz.Tarih <= txtSonTarih.DateTime.Date &&
                    x.OdemeBilgileri.Tahakkuk.DonemId == AnaForm.DonemId
                    );

                base.Listele();
            }
        }
        protected override void ShowEditForm()
        {
            var entity = tablo.GetRow<TahsilatRaporuL>();
            if (entity == null) return;
            ShowEditForms<MakbuzEditForm>.ShowDialogEditForm(KartTuru.Tahakkuk, entity.MakbuzId, entity.MakbuzTuru, entity.MakbuzHesapTuru, entity.SubeId != AnaForm.SubeId || entity.DonemId != AnaForm.DonemId);
        }
        protected override void BelgeHareketleri()
        {
            var entity = tablo.GetRow<TahsilatRaporuL>();
            if (entity == null) return;

            ShowListForms<BelgeHareketleriListForm>.ShowDialogListForm(KartTuru.BelgeHareketleri, null, entity.PortfoyNo);
        }
        protected override void BelgeDurumuYukle()
        {
            var enums = Enum.GetValues(typeof(BelgeDurumu));
            foreach (BelgeDurumu entity in enums)
            {
                var item = new CheckedListBoxItem
                {
                    CheckState = CheckState.Checked,
                    Description = entity.ToName(),
                    Value = entity,
                };
                if (entity == BelgeDurumu.AvukatYoluylaTahsilEtme ||
                    entity == BelgeDurumu.KismiAvukatYoluylaTahsilEtme ||
                    entity == BelgeDurumu.BlokeCozumu ||
                    entity == BelgeDurumu.MahsupEtme ||
                    entity == BelgeDurumu.OdenmisOlarakIsaretleme ||
                    entity == BelgeDurumu.TahsilEtmeBanka ||
                    entity == BelgeDurumu.TahsilEtmeKasa ||
                    entity == BelgeDurumu.BankaYoluylaTahsilEtme ||
                    entity == BelgeDurumu.KismiTahsilEdildi)

                    BelgeDurumlari.Properties.Items.Add(item);
            }
        }
    }
}