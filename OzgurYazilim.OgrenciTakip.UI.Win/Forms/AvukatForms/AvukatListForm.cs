using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.AvukatForms
{
    public partial class AvukatListForm : BaseListForm
    {
        public AvukatListForm()
        {
            InitializeComponent();
            Bll = new AvukatBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Avukat;
            FormShow = new ShowEditForms<AvukatEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((AvukatBll)Bll).List(FilterFunctions.Filter<Avukat>(AktifKartlariGoster));
        }
    }
}