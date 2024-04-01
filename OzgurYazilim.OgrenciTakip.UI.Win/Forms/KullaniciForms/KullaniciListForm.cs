using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.KullaniciForms
{
    public partial class KullaniciListForm : BaseListForm
    {
        public KullaniciListForm()
        {
            InitializeComponent();
            Bll = new KullaniciBll();
            HideItems = new BarItem[] { btnSec };
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Kullanici;
            FormShow = new ShowEditForms<KullaniciEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((KullaniciBll)Bll).List(FilterFunctions.Filter<Kullanici>(AktifKartlariGoster));
        }
    }
}