using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Model.Entities;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.SinifGrupForms
{
    public partial class SinifGrupListForm : BaseListForm
    {
        public SinifGrupListForm()
        {
            InitializeComponent();
            Bll = new SinifGrupBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.SinifGrup;
            FormShow = new ShowEditForms<SinifGrupEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((SinifGrupBll)Bll).List(FilterFunctions.Filter<SinifGrup>(AktifKartlariGoster));
        }
    }
}