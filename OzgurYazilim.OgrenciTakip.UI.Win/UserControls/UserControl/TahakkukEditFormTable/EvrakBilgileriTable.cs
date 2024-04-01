using System.Data;
using System.Linq;
using OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.Base;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.EvrakForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Bll.Functions;

namespace OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.TahakkukEditFormTable
{
    public partial class EvrakBilgileriTable : BaseTablo
    {
        public EvrakBilgileriTable()
        {
            InitializeComponent();
            Bll = new EvrakBilgileriBll();
            Tablo = tablo;
            EventsLoad();
        }
        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((EvrakBilgileriBll)Bll)
                .List(x => x.TahakkukId == OwnerForm.Id)
                .ToBindingList<EvrakBilgileriL>();
        }
        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;
            ListeDisiTutulacakKayitlar = source.Cast<EvrakBilgileriL>().Where(x => !x.Delete).Select(x => x.EvrakId).ToList();

            var entities = ShowListForms<EvrakListForm>.ShowDialogListForm(KartTuru.Evrak, ListeDisiTutulacakKayitlar, true, false).EntityListConvert<Evrak>();
            if (entities == null) return;
            foreach (var entity in entities)
            {
                var row = new EvrakBilgileriL
                {
                    TahakkukId = OwnerForm.Id,
                    Kod=entity.Kod,
                    EvrakId=entity.Id,
                    EvrakAdi=entity.EvrakAdi,
                    Insert = true
                };
                source.Add(row);
            }
            tablo.Focus();
            tablo.RefreshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colKod;

            ButonEnabledDurumu(true);
        }
    }
}