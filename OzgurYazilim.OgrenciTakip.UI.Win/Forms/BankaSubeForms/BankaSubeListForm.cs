using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.BankaSubeForms
{
    public partial class BankaSubeListForm : BaseListForm
    {

        #region Variables

        private readonly long _bankaId;
        private readonly string _bankaAdi;

        #endregion

        public BankaSubeListForm(params object[] prm)
        {
            InitializeComponent();

            Bll = new BankaSubeBll();

            _bankaId = (long)prm[0];
            _bankaAdi = prm[1].ToString();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.BankaSube;
            Navigator = longNavigator.Navigator;
            Text = Text + $" - ( {_bankaAdi} )";

        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((BankaSubeBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.BankaId == _bankaId);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<BankaSubeEditForm>.ShowDialogEditForm(KartTuru.BankaSube, id, _bankaId, _bankaAdi);
            ShowEditFormDefault(result);
        }
    }
}