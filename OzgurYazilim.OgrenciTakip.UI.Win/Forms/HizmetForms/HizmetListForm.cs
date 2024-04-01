using DevExpress.Utils.Extensions;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.HizmetForms
{
    public partial class HizmetListForm : BaseListForm
    {

        #region Variables

        private readonly Expression<Func<Hizmet, bool>> _filter;

        #endregion

        public HizmetListForm()
        {
            InitializeComponent();
            Bll = new HizmetBll();
            _filter = x => x.Durum == AktifKartlariGoster && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId;
        }
        public HizmetListForm(params object[] prm) : this()
        {
            if (prm != null)
            {
                var panelGoster = (bool)prm[0];
                ustPanel.Visible = DateTime.Now.Date > AnaForm.DonemParemetreleri.EgitimBaslamaTarihi && panelGoster;
            }

            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId && x.Durum == AktifKartlariGoster;
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Hizmet;
            FormShow = new ShowEditForms<HizmetEditForm>();
            Navigator = longNavigator.Navigator;
            TarihAyarla();
        }
        protected override void Listele()
        {
            var list = ((HizmetBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("kart");
        }
        private void TarihAyarla()
        {
            txtHizmetBaslamaTarihi.Properties.MinValue = AnaForm.DonemParemetreleri.GunTarihininOncesineHizmetBaslamaTarihiGirilebilir
                ? AnaForm.DonemParemetreleri.EgitimBaslamaTarihi : DateTime.Now.Date < AnaForm.DonemParemetreleri.EgitimBaslamaTarihi
                ? AnaForm.DonemParemetreleri.EgitimBaslamaTarihi : DateTime.Now.Date;
            txtHizmetBaslamaTarihi.Properties.MaxValue = AnaForm.DonemParemetreleri.GunTarihininSonrasinaHizmetBaslamaTarihiGirilebilir
                ? AnaForm.DonemParemetreleri.DonemBitisTarihi : DateTime.Now.Date < AnaForm.DonemParemetreleri.EgitimBaslamaTarihi
                ? AnaForm.DonemParemetreleri.EgitimBaslamaTarihi : DateTime.Now.Date > AnaForm.DonemParemetreleri.DonemBitisTarihi
                ? AnaForm.DonemParemetreleri.DonemBitisTarihi : DateTime.Now.Date;
            txtHizmetBaslamaTarihi.DateTime = DateTime.Now.Date <= AnaForm.DonemParemetreleri.EgitimBaslamaTarihi
                ? AnaForm.DonemParemetreleri.EgitimBaslamaTarihi : DateTime.Now.Date > AnaForm.DonemParemetreleri.EgitimBaslamaTarihi && DateTime.Now.Date <= AnaForm.DonemParemetreleri.DonemBitisTarihi
                ? DateTime.Now.Date : DateTime.Now.Date > AnaForm.DonemParemetreleri.DonemBitisTarihi
                ? AnaForm.DonemParemetreleri.DonemBitisTarihi : DateTime.Now.Date;
        }
        protected override void SelectEntity()
        {
            base.SelectEntity();

            if (MultiSelect)
                SelectedEntities.ForEach(x => ((HizmetL)x).BaslamaTarihi = txtHizmetBaslamaTarihi.DateTime.Date);
        }
    }
}