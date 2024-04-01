using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.CariForms
{
    public partial class CariListForm : BaseListForm
    {
        public CariListForm()
        {
            InitializeComponent();
            Bll = new CariBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Cari;
            FormShow = new ShowEditForms<CariEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((CariBll)Bll).List(FilterFunctions.Filter<Cari>(AktifKartlariGoster));
        }
    }
}