using System.Data;
using System.Linq;
using OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.Base;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.HizmetForms;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Bll.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using DevExpress.ClipboardSource.SpreadsheetML;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Common.Messages;

namespace OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.IndirimEditFormTable
{
    public partial class IndiriminUygulanacagiHizmetlerTable : BaseTablo
    {
        public IndiriminUygulanacagiHizmetlerTable()
        {
            InitializeComponent();

            Bll = new IndiriminUygulanacagiHizmetBilgileriBll();
            Tablo = tablo;
            EventsLoad();
        }
        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((IndiriminUygulanacagiHizmetBilgileriBll)Bll)
                .List(x => x.IndirimId == OwnerForm.Id)
                .ToBindingList<IndiriminUygulanacagiHizmetBilgileriL>();
        }
        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;
            ListeDisiTutulacakKayitlar = source.Cast<IndiriminUygulanacagiHizmetBilgileriL>().Where(x => !x.Delete).Select(x => x.HizmetId).ToList();

            var entities = ShowListForms<HizmetListForm>.ShowDialogListForm(KartTuru.Hizmet, ListeDisiTutulacakKayitlar, true, false).EntityListConvert<HizmetL>();
            if (entities == null) return;
            foreach (var entity in entities)
            {
                var row = new IndiriminUygulanacagiHizmetBilgileriL
                {
                    IndirimId = OwnerForm.Id,
                    HizmetId = entity.Id,
                    HizmetAdi = entity.HizmetAdi,
                    IndirimTutari = 0,
                    IndirimOrani = 0,
                    SubeId = AnaForm.SubeId,
                    DonemId = AnaForm.DonemId,
                    Insert = true
                };
                source.Add(row);
            }
            tablo.Focus();
            tablo.RefreshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colIndirimTutari;

            ButonEnabledDurumu(true);
        }
        protected internal override bool HataliGiris()
        {
            if (!TableValueChanged) return false;
            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                var entity = tablo.GetRow<IndiriminUygulanacagiHizmetBilgileriL>(i);
                if (entity.IndirimTutari == 0 || entity.IndirimOrani == 0) continue;
                tablo.Focus();
                tablo.FocusedRowHandle = i;
                Messages.HataMesaji("İndirim tutarı veya indirim oranı alanlarından sadece birinin değeri sıfırdan büyük olmalıdır.");
                return true;
            }
            return false;
        }
    }
}