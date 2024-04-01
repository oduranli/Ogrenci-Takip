using System;
using System.Linq;
using System.Windows.Forms;
using OzgurYazilim.OgrenciTakip.UI.Win.Reports.FormReports.Base;
using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.GecikmeAciklamalariForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.MakbuzForms;
using DevExpress.XtraEditors.Controls;
using OzgurYazilim.OgrenciTakip.Common.Functions;
using DevExpress.XtraGrid.Views.Grid;
using OzgurYazilim.OgrenciTakip.Bll.Functions;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Reports.FormReports
{
    public partial class OdemesiGecikenAlacaklarRaporu : BaseRapor
    {
        public OdemesiGecikenAlacaklarRaporu()
        {
            InitializeComponent();
            ShowItems = new BarItem[] { btnBelgeHareketleri, btnTumDetaylariDaralt, btnTumDetaylariGenislet };
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
            txtIlkTarih.DateTime = AnaForm.DonemParemetreleri.DonemBaslamaTarihi;
            txtSonTarih.DateTime = DateTime.Now.Date;
            RaporTuru = KartTuru.OdemesiGecikenAlacaklarRaporu;
        }
        protected override void Listele()
        {
            var subeler = txtSubeler.CheckedComboboxList<long>();
            var odemeler = txtOdemeler.CheckedComboboxList<OdemeTipi>();
            var kayitSekli = txtKayitSekli.CheckedComboboxList<KayitSekli>();
            var kayitDurumu = txtKayitDurumu.CheckedComboboxList<KayitDurumu>();
            var iptalDurumu = txtIptalDurumu.CheckedComboboxList<IptalDurumu>();
            var belgeDurumlari = txtBelgeDurumlari.CheckedComboboxList<BelgeDurumu>();

            using (var bll = new OdemesiGecikenAlacaklarRaporuBll())
            {
                tablo.GridControl.DataSource = bll.List(x =>
                    subeler.Contains(x.Tahakkuk.SubeId) &&
                    odemeler.Contains(x.OdemeTipi) &&
                    kayitSekli.Contains(x.Tahakkuk.KayitSekli) &&
                    kayitDurumu.Contains(x.Tahakkuk.KayitDurumu) &&
                    iptalDurumu.Contains(x.Tahakkuk.Durum ? IptalDurumu.DevamEdiyor : IptalDurumu.IptalEdildi) &&
                    x.Vade >= txtIlkTarih.DateTime.Date &&
                    x.Vade <= txtSonTarih.DateTime.Date &&
                    x.Tahakkuk.DonemId == AnaForm.DonemId, belgeDurumlari
                    );

                base.Listele();
            }
        }
        protected override void ShowEditForm()
        {
            var entity = tablo.GetRow<OdemesiGecikenAlacaklarRaporuL>();
            if (entity == null) return;

            ShowListForms<GecikmeAciklamalariListForm>.ShowDialogListForm(KartTuru.Aciklama, null, entity.PortfoyNo);
        }
        protected override void BelgeHareketleri()
        {
            var entity = tablo.GetRow<OdemesiGecikenAlacaklarRaporuL>();
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
                if (entity == BelgeDurumu.Portfoyde ||
                    entity == BelgeDurumu.KismiAvukatYoluylaTahsilEtme ||
                    entity == BelgeDurumu.KismiTahsilEdildi ||
                    entity == BelgeDurumu.BankayaTahsileGonderme ||
                    entity == BelgeDurumu.AvukataGonderme ||
                    entity == BelgeDurumu.CiroEtme ||
                    entity == BelgeDurumu.BlokeyeAlma ||
                    entity == BelgeDurumu.OnayBekliyor ||
                    entity == BelgeDurumu.PortfoyeGeriIade ||
                    entity == BelgeDurumu.PortfoyeKarsiliksizIade ||
                    entity == BelgeDurumu.TahsiliImkansizHaleGelme
                    )

                    BelgeDurumlari.Properties.Items.Add(item);
            }
        }
        protected override void Tablo_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }
        protected override void Tablo_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "altGrid";
        }
        protected override void Tablo_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            var entity = tablo.GetRow<OdemesiGecikenAlacaklarRaporuL>(e.RowHandle);
            if (entity == null) return;

            using (var bll = new GecikmeAciklamalariBll())
            {
                var list = bll.List(x => x.OdemeBilgileriId == entity.PortfoyNo).EntityListConvert<GecikmeAciklamalariL>().ToList();
                if (list.Any())
                    e.ChildList = list;
            }
        }
    }
}