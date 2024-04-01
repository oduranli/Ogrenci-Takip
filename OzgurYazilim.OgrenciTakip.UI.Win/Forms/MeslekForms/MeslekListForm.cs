using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Model.Entities;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.MeslekForms
{
    public partial class MeslekListForm :BaseListForm
    {
        public MeslekListForm()
        {
            InitializeComponent();
            Bll = new MeslekBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Meslek;
            FormShow = new ShowEditForms<MeslekEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((MeslekBll)Bll).List(FilterFunctions.Filter<Meslek>(AktifKartlariGoster));
        }
    }
}