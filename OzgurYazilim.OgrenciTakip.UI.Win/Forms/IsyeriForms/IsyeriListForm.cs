using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Model.Entities;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.IsyeriForms
{
    public partial class IsyeriListForm : BaseListForm
    {
        public IsyeriListForm()
        {
            InitializeComponent();
            Bll = new IsyeriBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Isyeri;
            FormShow = new ShowEditForms<IsyeriEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((IsyeriBll)Bll).List(FilterFunctions.Filter<Isyeri>(AktifKartlariGoster));
        }
    }
}