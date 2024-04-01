using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.SinifForms
{
    public partial class SinifListForm : BaseListForm
    {
        public SinifListForm()
        {
            InitializeComponent();
            Bll = new SinifBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Sinif;
            FormShow = new ShowEditForms<SinifEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((SinifBll)Bll)
                .List(x => x.Durum == AktifKartlariGoster && x.SubeId == AnaForm.SubeId);
        }
    }
}