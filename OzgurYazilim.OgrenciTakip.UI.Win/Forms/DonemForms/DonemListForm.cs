using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using System;
using System.Linq;
using System.Linq.Expressions;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.DonemForms
{
    public partial class DonemListForm : BaseListForm
    {

        #region Variables

        private readonly Expression<Func<Donem, bool>> _filter;

        #endregion

        public DonemListForm()
        {
            InitializeComponent();
            Bll = new DonemBll();
            _filter = x => x.Durum == AktifKartlariGoster;
            ShowItems = new BarItem[] { btnParametreler, barF4, barF4Aciklama };

        }
        public DonemListForm(params object[] prm) : this()
        {
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.Durum == AktifKartlariGoster;
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Donem;
            FormShow = new ShowEditForms<DonemEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            var list = ((DonemBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("kart");
        }
        protected override void BagliKartAc()
        {
            var entity = Tablo.GetRow<Donem>();
            if (entity == null) return;
            ShowEditForms<DonemParametreEditForm>.ShowDialogEditForm(null, entity.Id);
        }
    }
}