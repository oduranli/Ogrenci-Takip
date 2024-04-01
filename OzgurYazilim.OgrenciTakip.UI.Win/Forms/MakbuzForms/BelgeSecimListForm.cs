﻿using System;
using System.Linq;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using System.Linq.Expressions;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Functions;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using DevExpress.XtraBars;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.MakbuzForms
{
    public partial class BelgeSecimListForm : BaseListForm
    {

        #region Variables

        private readonly Expression<Func<OdemeBilgileri, bool>> _filter;
        private readonly MakbuzTuru _makbuzTuru;
        private readonly MakbuzHesapTuru _hesapTuru;
        private readonly long _hesapId;

        #endregion

        public BelgeSecimListForm(params object[] prm)
        {
            InitializeComponent();
            HideItems = new BarItem[] { btnYeni, btnSil, btnDuzelt, barInsert, barInsertAciklama, barDelete, barDeleteAciklama, barDuzelt, barDuzeltAciklama };
            ShowItems = new BarItem[] { btnBelgeHareketleri };

            _makbuzTuru = (MakbuzTuru)prm[0];
            _hesapTuru = (MakbuzHesapTuru)prm[1];
            _hesapId = prm[2] != null ? (long)prm[2] : 0;
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.Tahakkuk.DonemId == AnaForm.DonemId;

        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Makbuz;
            Navigator = longNavigator.Navigator;

            Text = $"{Text} - {_makbuzTuru.ToName()} - ( {_hesapTuru.ToName()} )";
        }
        protected override void Listele()
        {
            using (var bll = new BelgeSecimBll())
            {
                var list = bll.List(_filter, _makbuzTuru, _hesapTuru, _hesapTuru.ToName().GetEnum<OdemeTipi>(), _hesapId, AnaForm.SubeId);
                Tablo.GridControl.DataSource = list;

                if (!MultiSelect) return;
                if (list.Any())
                    EklenebilecekEntityVar = true;
                else
                    Messages.KartBulunamadiMesaji("Belge");
            }

        }

        protected override void SutunGizleGoster()
        {
            if (tablo.DataRowCount == 0) return;
            var entity = tablo.GetRow<BelgeSecimL>(false); //false parametresini lutfen bir kart seçiniz mesajı çalışmaması için kullandık.
            if (entity == null) return;

            bndBelgeDetayBilgileri.Visible = entity.OdemeTipi == OdemeTipi.Cek || entity.OdemeTipi == OdemeTipi.Senet;
            colTakipNo.Visible = entity.OdemeTipi == OdemeTipi.Pos;
            colBankaHesapAdi.Visible = entity.OdemeTipi == OdemeTipi.Epos || entity.OdemeTipi == OdemeTipi.Pos || entity.OdemeTipi == OdemeTipi.Ots;
            colBankaAdi.Visible = entity.OdemeTipi == OdemeTipi.Cek;
            colBankaSubeAdi.Visible = entity.OdemeTipi == OdemeTipi.Cek;
            colHesapNo.Visible = entity.OdemeTipi == OdemeTipi.Cek;
            colBelgeNo.Visible = entity.OdemeTipi == OdemeTipi.Cek;
            colAsilBorclu.Visible = entity.OdemeTipi == OdemeTipi.Cek || entity.OdemeTipi == OdemeTipi.Senet;
            colCiranta.Visible = entity.OdemeTipi == OdemeTipi.Cek || entity.OdemeTipi == OdemeTipi.Senet;
        }
        protected override void BelgeHareketleri()
        {
            var entity = tablo.GetRow<BelgeSecimL>();
            if (entity == null) return;

            ShowListForms<BelgeHareketleriListForm>.ShowDialogListForm(KartTuru.BelgeHareketleri, null, entity.OdemeBilgileriId);
        }
    }
}