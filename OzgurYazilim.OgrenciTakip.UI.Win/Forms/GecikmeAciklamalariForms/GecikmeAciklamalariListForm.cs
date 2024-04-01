using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.GecikmeAciklamalariForms
{
    public partial class GecikmeAciklamalariListForm : BaseListForm
    {
        #region Variables

        private readonly int _portfoyNo;

        #endregion

        public GecikmeAciklamalariListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new GecikmeAciklamalariBll();
            HideItems = new BarItem[] { btnSec };

            _portfoyNo = (int)prm[0];
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Aciklama;
            Navigator = longNavigator.Navigator;

        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((GecikmeAciklamalariBll)Bll).List(x => x.OdemeBilgileriId == _portfoyNo);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<GecikmeAciklamalariEditForm>.ShowDialogEditForm(KartTuru.Aciklama, id, _portfoyNo);
            ShowEditFormDefault(result);
        }
    }
}