using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.YabanciDilForms
{
    public partial class YabanciDilListForm : BaseListForm
    {
        public YabanciDilListForm()
        {
            InitializeComponent();
            Bll = new YabanciDilBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.YabanciDil;
            FormShow = new ShowEditForms<YabanciDilEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((YabanciDilBll)Bll).List(FilterFunctions.Filter<YabanciDil>(AktifKartlariGoster));
        }
    }
}