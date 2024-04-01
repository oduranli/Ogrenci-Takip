using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.IlceForms;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.IlForms
{
    public partial class IlListForm : BaseListForm
    {
        public IlListForm()
        {
            InitializeComponent();
            Bll = new IlBll();

            btnBagliKartlar.Caption = "İlçe Kartları";

        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Il;
            FormShow = new ShowEditForms<IlEditForm>();
            Navigator = longNavigator.Navigator;
            if (IsMdiChild)
                ShowItems = new BarItem[] { btnBagliKartlar };
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((IlBll)Bll).List(FilterFunctions.Filter<Il>(AktifKartlariGoster));
        }
        protected override void BagliKartAc()
        {
            var entity = Tablo.GetRow<Il>();
            if (entity == null) return;
            ShowListForms<IlceListForm>.ShowListForm(KartTuru.Ilce, entity.Id, entity.IlAdi);
        }
    }
}