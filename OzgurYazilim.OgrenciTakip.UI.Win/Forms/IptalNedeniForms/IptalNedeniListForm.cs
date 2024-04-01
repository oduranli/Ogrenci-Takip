using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Model.Entities;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.IptalNedeniForms
{
    public partial class IptalNedeniListForm : BaseListForm
    {
        public IptalNedeniListForm()
        {
            InitializeComponent();
            Bll = new IptalNedeniBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.IptalNedeni;
            FormShow = new ShowEditForms<IptalNedeniEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((IptalNedeniBll)Bll).List(FilterFunctions.Filter<IptalNedeni>(AktifKartlariGoster));
        }
    }
}