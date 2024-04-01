using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.Bll.Functions;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.TahakkukForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.Base;
using System.Linq;

namespace OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.TahakkukEditFormTable
{
    public partial class KardesBilgileriTable : BaseTablo
    {
        public KardesBilgileriTable()
        {
            InitializeComponent();

            Bll = new KardesBilgileriBll();
            Tablo = tablo;
            EventsLoad();
            ShowItems = new BarItem[] { btnKartDuzenle };
        }
        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((KardesBilgileriBll)Bll)
                .List(x => x.TahakkukId == OwnerForm.Id)
                .ToBindingList<KardesBilgileriL>();
        }
        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;
            ListeDisiTutulacakKayitlar = source.Cast<KardesBilgileriL>().Where(x => !x.Delete).Select(x => x.KardesTahakkukId).ToList();
            ListeDisiTutulacakKayitlar.Add(OwnerForm.Id); //üzerinde çalıştığımız öğrenciyi liste dışına eklemiş olduk.

            var entities = ShowListForms<TahakkukListForm>.ShowDialogListForm(KartTuru.Tahakkuk, ListeDisiTutulacakKayitlar, true, false).EntityListConvert<TahakkukL>();
            if (entities == null) return;
            foreach (var entity in entities)
            {
                var row = new KardesBilgileriL
                {
                    TahakkukId = OwnerForm.Id,
                    KardesTahakkukId = entity.Id,
                    Adi = entity.Adi,
                    Soyadi = entity.Soyadi,
                    SinifAdi = entity.SinifAdi,
                    KayitSekli = entity.KayitSekli,
                    KayitDurumu = entity.KayitDurumu,
                    IptalDurumu = entity.Durum ? IptalDurumu.DevamEdiyor : IptalDurumu.IptalEdildi,
                    SubeAdi = entity.SubeAdi,
                    Insert = true
                };
                source.Add(row);
            }
            tablo.Focus();
            tablo.RefreshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colAdi;

            ButonEnabledDurumu(true);
        }

        protected override void OpenEntity()
        {
            var entity = tablo.GetRow<KardesBilgileriL>();
            if (entity == null) return;
            ShowEditForms<TahakkukEditForm>.ShowDialogEditForm(KartTuru.Tahakkuk, entity.KardesTahakkukId, entity.SubeId != AnaForm.SubeId || entity.DonemId != AnaForm.DonemId);
        }
    }
}
