using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.Bll.Functions;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.TahakkukForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.OgrenciForms
{
    public partial class OgrenciListForm : BaseListForm
    {
        public OgrenciListForm()
        {
            InitializeComponent();
            Bll = new OgrenciBll();
            ShowItems = new BarItem[] { btnTahakkukYap };
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Ogrenci;
            FormShow = new ShowEditForms<OgrenciEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((OgrenciBll)Bll).List(FilterFunctions.Filter<Ogrenci>(AktifKartlariGoster));
        }
        protected override void TahakkukYap()
        {
            var entity = tablo.GetRow<OgrenciL>().EntityConvert<Ogrenci>();
            using (var bll = new TahakkukBll())
            {
                var tahakkuk = bll.SingleSummary(x => x.OgrenciId == entity.Id && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);

                if (tahakkuk != null)
                    ShowEditForms<TahakkukEditForm>.ShowDialogEditForm(KartTuru.Tahakkuk, tahakkuk.Id, null);
                else
                    ShowEditForms<TahakkukEditForm>.ShowDialogEditForm(KartTuru.Tahakkuk, -1, entity);
            }
        }
    }
}