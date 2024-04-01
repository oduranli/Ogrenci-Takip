using System.Linq;
using OzgurYazilim.OgrenciTakip.UI.Win.Reports.FormReports.Base;
using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.TahakkukForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.MakbuzForms;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Reports.FormReports
{
    public partial class OdemeBelgeleriRaporu : BaseRapor
    {
        public OdemeBelgeleriRaporu()
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

            SubeKartlariYukle();
            KayitSekliYukle();
            KayitDurumuYukle();
            IptalDurumuYukle();
            OdemeTurleriYukle();
            BelgeDurumuYukle();
            RaporTuru = KartTuru.OdemeBelgeleriRaporu;
        }
        protected override void Listele()
        {
            var subeler = txtSubeler.CheckedComboboxList<long>();
            var odemeler = txtOdemeler.CheckedComboboxList<OdemeTipi>();
            var kayitSekli = txtKayitSekli.CheckedComboboxList<KayitSekli>();
            var kayitDurumu = txtKayitDurumu.CheckedComboboxList<KayitDurumu>();
            var iptalDurumu = txtIptalDurumu.CheckedComboboxList<IptalDurumu>();
            var belgeDurumlari = txtBelgeDurumlari.CheckedComboboxList<BelgeDurumu>();

            using (var bll = new OdemeBelgeleriRaporuBll())
            {
                tablo.GridControl.DataSource = bll.List(x =>
                    subeler.Contains(x.Tahakkuk.SubeId) &&
                    odemeler.Contains(x.OdemeTipi) &&
                    kayitSekli.Contains(x.Tahakkuk.KayitSekli) &&
                    kayitDurumu.Contains(x.Tahakkuk.KayitDurumu) &&
                    iptalDurumu.Contains(x.Tahakkuk.Durum ? IptalDurumu.DevamEdiyor : IptalDurumu.IptalEdildi) &&
                    x.Tahakkuk.DonemId == AnaForm.DonemId, belgeDurumlari
                    );

                base.Listele();
            }
        }
        protected override void ShowEditForm()
        {
            var entity = tablo.GetRow<OdemeBelgeleriRaporuL>();
            if (entity == null) return;
            ShowEditForms<TahakkukEditForm>.ShowDialogEditForm(KartTuru.Tahakkuk, entity.TahakkukId, entity.SubeId != AnaForm.SubeId || entity.DonemId != AnaForm.DonemId);
        }
        protected override void BelgeHareketleri()
        {
            var entity = tablo.GetRow<OdemeBelgeleriRaporuL>();
            if (entity == null) return;

            ShowListForms<BelgeHareketleriListForm>.ShowDialogListForm(KartTuru.BelgeHareketleri, null, entity.PortfoyNo);
        }
    }
}