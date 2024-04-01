using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.PromosyonForms
{
    public partial class PromosyonListForm : BaseListForm
    {

        #region Variables

        private readonly Expression<Func<Promosyon, bool>> _filter;

        #endregion

        public PromosyonListForm()
        {
            InitializeComponent();

            Bll = new PromosyonBll();
            _filter = x => x.Durum == AktifKartlariGoster && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId;
        }
        public PromosyonListForm(params object[] prm) : this()
        {
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.Durum == AktifKartlariGoster
            && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Promosyon;
            FormShow = new ShowEditForms<PromosyonEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            var list = ((PromosyonBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("kart");
        }
    }
}