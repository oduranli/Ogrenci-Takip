using System.Linq;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using System.Linq.Expressions;
using System;
using OzgurYazilim.OgrenciTakip.Model.Entities;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.SubeForms
{
    public partial class SubeListForm : BaseListForm
    {
        #region Variables

        private readonly Expression<Func<Sube, bool>> _filter;

        #endregion

        public SubeListForm()
        {
            InitializeComponent();
            Bll = new SubeBll();
            _filter = x => x.Durum == AktifKartlariGoster;
        }
        public SubeListForm(params object[] prm) : this()
        {
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.Durum == AktifKartlariGoster;
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Sube;
            FormShow = new ShowEditForms<SubeEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            //Tablo.GridControl.DataSource = ((SubeBll)Bll).List(FilterFunctions.Filter<Sube>(AktifKartlariGoster));
            var list = ((SubeBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("kart");
        }
    }
}