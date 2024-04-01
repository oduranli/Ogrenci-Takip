using System.Data;
using System.Linq;
using System.Windows.Forms;
using OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.Base;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.SubeForms;
using OzgurYazilim.OgrenciTakip.Bll.Functions;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base.Interfaces;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.KullaniciForms;

namespace OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.KullaniciBirimYetkileriEditFormTable
{
    public partial class SubeTable : BaseTablo
    {
        public SubeTable()
        {
            InitializeComponent();

            Bll = new KullaniciBirimYetkileriBll();
            Tablo = tablo;
            EventsLoad();
        }
        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((KullaniciBirimYetkileriBll)Bll)
                .List(x => x.KullaniciId == OwnerForm.Id && x.KartTuru == KartTuru.Sube)
                .ToBindingList<KullaniciBirimYetkileriL>();
        }
        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;
            ListeDisiTutulacakKayitlar = source.Cast<KullaniciBirimYetkileriL>().Select(x => x.SubeId.Value).ToList();

            var entities = ShowListForms<SubeListForm>.ShowDialogListForm(ListeDisiTutulacakKayitlar, true, false).EntityListConvert<SubeL>();
            if (entities == null) return;

            foreach (var entity in entities)
            {
                var row = new KullaniciBirimYetkileriL
                {
                    Kod = entity.Kod,
                    SubeAdi = entity.SubeAdi,
                    KartTuru = KartTuru.Sube,
                    KullaniciId = OwnerForm.Id,
                    SubeId = entity.Id,
                    Insert = true
                };
                source.Add(row);
            }

            if (!Kaydet()) return;
            Listele();
            tablo.Focus();

            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
        }
        protected override void HareketSil()
        {
            if (tablo.DataRowCount == 0) return;

            if (Messages.SilMesaj("Şube kartı") != DialogResult.Yes) return;

            tablo.GetRow<IBaseHareketEntity>().Delete = true;
            tablo.RefreshDataSource();

            var rowHandle = tablo.FocusedRowHandle;
            if (!Kaydet()) return;
            Listele();
            tablo.FocusedRowHandle = rowHandle;
        }
        protected override void Tablo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            btnHareketSil.Enabled = tablo.DataRowCount > 0;
            btnHareketEkle.Enabled = ((KullaniciBirimYetkileriEditForm)OwnerForm).kullaniciTable.Tablo.DataRowCount > 0;
            e.SagMenuGoster(popupMenu);
        }
    }
}