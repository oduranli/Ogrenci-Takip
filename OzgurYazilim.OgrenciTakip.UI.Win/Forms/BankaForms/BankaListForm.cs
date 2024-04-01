using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BankaSubeForms;
using OzgurYazilim.OgrenciTakip.Model.Dto;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.BankaForms
{
    public partial class BankaListForm : BaseListForm
    {
        public BankaListForm()
        {
            InitializeComponent();
            Bll = new BankaBll();

            btnBagliKartlar.Caption = "Şube Kartları";
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Banka;
            FormShow = new ShowEditForms<BankaEditForm>();
            Navigator = longNavigator.Navigator;
            if (IsMdiChild)
                ShowItems = new BarItem[] { btnBagliKartlar };
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((BankaBll)Bll).List(FilterFunctions.Filter<Banka>(AktifKartlariGoster));
        }
        protected override void BagliKartAc()
        {
            var entity = Tablo.GetRow<BankaL>();
            if (entity == null) return;
            ShowListForms<BankaSubeListForm>.ShowListForm(KartTuru.BankaSube, entity.Id, entity.BankaAdi);
        }
    }
}