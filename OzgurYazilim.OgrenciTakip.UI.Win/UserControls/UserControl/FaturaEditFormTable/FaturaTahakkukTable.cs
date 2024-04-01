﻿using System;
using OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.Base;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.FaturaForms;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using System.Windows.Forms;
using OzgurYazilim.OgrenciTakip.Common.Functions;
using OzgurYazilim.OgrenciTakip.Common.Enums;

namespace OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.FaturaEditFormTable
{
    public partial class FaturaTahakkukTable : BaseTablo
    {
        public FaturaTahakkukTable()
        {
            InitializeComponent();

            Bll = new FaturaBll();
            Tablo = tablo;
            EventsLoad();

            btnHareketEkle.Caption = "Tahakkuk Yap";
            btnHareketSil.Caption = "Tahakkuk İptal Et";
            insUptNavigator.Navigator.Buttons.Append.Hint = "TahakkukYap";
            insUptNavigator.Navigator.Buttons.Remove.Hint = "Tahakkuk İptal Et";
        }
        protected internal override void Listele()
        {
            var selectedItem = ((FaturaTahakkukEditForm)OwnerForm).txtFaturaDonemi.SelectedItem;
            if (selectedItem == null) return;

            var tarih = DateTime.Parse(selectedItem.ToString());
            tablo.GridControl.DataSource = ((FaturaBll)Bll)
                .FaturaTahakkukList(x => x.Tahakkuk.SubeId == AnaForm.SubeId && x.Tahakkuk.DonemId == AnaForm.DonemId && x.PlanTarih == tarih)
                .ToBindingList<FaturaPlaniL>();
        }
        protected override void HareketEkle()
        {
            if (tablo.DataRowCount == 0)
            {
                Messages.HataMesaji("Fatura tahakkuku yapılacak öğrenci bulunamadı. Fatura dönemi seçmemiş olabilirsiniz.");
                return;
            }
            if (Messages.HayirSeciliEvetHayir("Seçilen öğrencilere yukarıda girmiş olduğunuz parametrelere göre fatura tahakkuku yapılacaktır. Onaylıyor musunuz?", "Tahakkuk Onayı!") != DialogResult.Yes) return;

            var faturaNo = (int)((FaturaTahakkukEditForm)OwnerForm).txtFaturaNo.Value;
            var kdvSekli = ((FaturaTahakkukEditForm)OwnerForm).txtKdvSekli.Text.GetEnum<KdvSekli>();
            var kdvOrani = (byte)((FaturaTahakkukEditForm)OwnerForm).txtKdvOrani.Value;
            var adresTuru = ((FaturaTahakkukEditForm)OwnerForm).txtFaturaAdresi.Text.GetEnum<AdresTuru>();

            decimal KdvHesapla(decimal tutar)
            {
                return kdvSekli == KdvSekli.Dahil ? Math.Round(tutar * kdvOrani / (100 + kdvOrani), 2) : Math.Round(tutar * kdvOrani / 100, 2);
            }

            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                var entity = tablo.GetRow<FaturaPlaniL>(i);
                if (entity == null) return;

                entity.FaturaNo = faturaNo + i;
                entity.TahakkukTarih = entity.PlanTarih;
                entity.TahakkukTutar = entity.PlanTutar;
                entity.TahakkukIndirimTutar = entity.PlanIndirimTutar;
                entity.TahakkukNetTutar = entity.PlanNetTutar;
                entity.KdvOrani = kdvOrani;
                entity.KdvTutar = KdvHesapla(entity.TahakkukNetTutar.Value);
                entity.KdvHaricTutar = kdvSekli == KdvSekli.Haric ? entity.TahakkukNetTutar : entity.TahakkukNetTutar - entity.KdvTutar;
                entity.ToplamTutar = entity.KdvHaricTutar + entity.KdvTutar;
                entity.TutarYazi = entity.TahakkukNetTutar.Value.YaziIleTutar();
                entity.KdvSekli = kdvSekli;
                entity.FaturaAdres = adresTuru == AdresTuru.EvAdresi ? entity.EvAdres : entity.IsAdres;

                entity.FaturaAdresIlId = adresTuru == AdresTuru.EvAdresi ? entity.EvAdresIlId : entity.IsAdresIlId;
                entity.FaturaAdresIlAdi = adresTuru == AdresTuru.EvAdresi ? entity.EvAdresIlAdi : entity.IsAdresIlAdi;

                entity.FaturaAdresIlceId = adresTuru == AdresTuru.EvAdresi ? entity.EvAdresIlceId : entity.IsAdresIlceId;
                entity.FaturaAdresIlceAdi = adresTuru == AdresTuru.EvAdresi ? entity.EvAdresIlceAdi : entity.IsAdresIlceAdi;

                entity.Update = true;
            }

            tablo.RefreshData();
            ButonEnabledDurumu(true);
        }

        protected override void HareketSil()
        {
            if (Messages.HayirSeciliEvetHayir("Seçilen öğrencilere yapılan fatura tahakkukları iptal edilecektir. Onaylıyor musunuz?", "İptal Onayı!") != DialogResult.Yes) return;

            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                var entity = tablo.GetRow<FaturaPlaniL>(i);
                if (entity == null) return;

                entity.FaturaNo = null;
                entity.TahakkukTarih = null;
                entity.TahakkukTutar = null;
                entity.TahakkukIndirimTutar = null;
                entity.TahakkukNetTutar = null;
                entity.KdvOrani = null;
                entity.KdvTutar = null;
                entity.KdvHaricTutar = null;
                entity.ToplamTutar = null;
                entity.TutarYazi = null;
                entity.KdvSekli = null;
                entity.FaturaAdres = null;
                entity.FaturaAdresIlId = null;
                entity.FaturaAdresIlAdi = null;
                entity.FaturaAdresIlceId = null;
                entity.FaturaAdresIlceAdi = null;
                entity.Update = true;
            }

            tablo.RefreshData();
            ButonEnabledDurumu(true);
        }
    }
}