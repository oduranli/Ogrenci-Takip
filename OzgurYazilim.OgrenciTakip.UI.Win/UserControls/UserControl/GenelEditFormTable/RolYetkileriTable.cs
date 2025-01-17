﻿using System.Data;
using System.Linq;
using OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.Base;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.KullaniciForms;
using OzgurYazilim.OgrenciTakip.Bll.Functions;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using System;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using DevExpress.XtraBars;

namespace OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.GenelEditFormTable
{
    public partial class RolYetkileriTable : BaseTablo
    {
        public RolYetkileriTable()
        {
            InitializeComponent();

            Bll = new RolYetkileriBll();
            Tablo = tablo;
            ShowItems = new BarItem[] { btnTumunuSec, btnTumSecimleriKaldir };
            EventsLoad();
        }
        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((RolYetkileriBll)Bll)
                .List(x => x.RolId == OwnerForm.Id)
                .ToBindingList<RolYetkileriL>();
        }
        protected override void HareketEkle()
        {
            byte CheckBoxValue(KartTuru kartTuru)
            {
                if (kartTuru == KartTuru.AylikKayitRaporu ||
                    kartTuru == KartTuru.OdemesiGecikenAlacaklarRaporu ||
                    kartTuru == KartTuru.GelirDagilimRaporu ||
                    kartTuru == KartTuru.GenelAmacliRapor ||
                    kartTuru == KartTuru.HizmetAlimRaporu ||
                    kartTuru == KartTuru.IndirimDagilimRaporu ||
                    kartTuru == KartTuru.MesleklereGoreKayitRaporu ||
                    kartTuru == KartTuru.NetUcretRaporu ||
                    kartTuru == KartTuru.OdemeBelgeleriRaporu ||
                    kartTuru == KartTuru.SinifRaporlari ||
                    kartTuru == KartTuru.TahsilatRaporu ||
                    kartTuru == KartTuru.UcretOrtalamalariRaporu ||
                    kartTuru == KartTuru.UcretVeOdemeRaporu ||
                    kartTuru == KartTuru.BankaOdemePlaniRaporu ||
                    kartTuru == KartTuru.IndirimDilekcesiRaporu ||
                    kartTuru == KartTuru.KayitSozlesmesiRaporu ||
                    kartTuru == KartTuru.KrediKartliOdemeTalimatiRaporu ||
                    kartTuru == KartTuru.KullaniciTanimliRapor ||
                    kartTuru == KartTuru.MebKayitSozlesmesiRaporu ||
                    kartTuru == KartTuru.OdemeSenediRaporu ||
                    kartTuru == KartTuru.OgrenciKartiRaporu ||
                    kartTuru == KartTuru.BelgeSecim ||
                    kartTuru == KartTuru.RaporTasarim ||
                    kartTuru == KartTuru.FaturaOgrenciIcmalRaporu ||
                    kartTuru == KartTuru.FaturaDonemIcmalRaporu ||
                    kartTuru == KartTuru.FaturaRaporu ||
                    kartTuru == KartTuru.BelgeHareketleri)
                    return 2;

                return 0;
            }

            var source = tablo.DataController.ListSource;
            ListeDisiTutulacakKayitlar = source.Cast<RolYetkileriL>().Where(x => !x.Delete).Select(x => (long)x.KartTuru).ToList();

            var entities = ShowListForms<RolYetkiKartlariListForm>.ShowDialogListForm(ListeDisiTutulacakKayitlar, true).EntityListConvert<RolYetki>();
            if (entities == null) return;
            foreach (var entity in entities)
            {
                var row = new RolYetkileriL
                {
                    RolId = OwnerForm.Id,
                    KartTuru = entity.KartTuru,
                    Ekleyebilir = CheckBoxValue(entity.KartTuru),
                    Degistirebilir = CheckBoxValue(entity.KartTuru),
                    Silebilir = CheckBoxValue(entity.KartTuru),
                    Insert = true
                };
                source.Add(row);
            }
            tablo.Focus();
            tablo.RefreshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;

            ButonEnabledDurumu(true);
        }
        protected override void RowCellAllowEdit()
        {
            if (tablo.DataRowCount == 0) return;
            var entity = tablo.GetRow<RolYetkileriL>();
            if (entity == null) return;

            colEkleyebilir.OptionsColumn.AllowEdit = entity.Ekleyebilir != 2;
            colDegistirebilir.OptionsColumn.AllowEdit = entity.Degistirebilir != 2;
            colSilebilir.OptionsColumn.AllowEdit = entity.Silebilir != 2;
        }
        protected override void TumunuSec()
        {
            var source = tablo.DataController.ListSource.Cast<RolYetkileriL>().ToList();

            for (int i = 0; i < source.Count; i++)
            {
                if (tablo.FocusedColumn == colGorebilir && source[i].Gorebilir == 0)
                    source[i].Gorebilir = 1;
                else if (tablo.FocusedColumn == colEkleyebilir && source[i].Ekleyebilir == 0)
                    source[i].Ekleyebilir = 1;
                else if (tablo.FocusedColumn == colDegistirebilir && source[i].Degistirebilir == 0)
                    source[i].Degistirebilir = 1;
                else if (tablo.FocusedColumn == colSilebilir && source[i].Silebilir == 0)
                    source[i].Silebilir = 1;
                else if (tablo.FocusedColumn == colKartTuru)
                {
                    if (source[i].Gorebilir == 0)
                        source[i].Gorebilir = 1;
                    if (source[i].Ekleyebilir == 0)
                        source[i].Ekleyebilir = 1;
                    if (source[i].Degistirebilir == 0)
                        source[i].Degistirebilir = 1;
                    if (source[i].Silebilir == 0)
                        source[i].Silebilir = 1;
                }
                if (!source[i].Insert)
                    source[i].Update = true;
                tablo.RefreshRow(i);
            }

            ButonEnabledDurumu(true);
        }
        protected override void TumSecimleriKaldir()
        {
            var source = tablo.DataController.ListSource.Cast<RolYetkileriL>().ToList();

            for (int i = 0; i < source.Count; i++)
            {
                if (tablo.FocusedColumn == colGorebilir && source[i].Gorebilir == 1)
                    source[i].Gorebilir = 0;
                else if (tablo.FocusedColumn == colEkleyebilir && source[i].Ekleyebilir == 1)
                    source[i].Ekleyebilir = 0;
                else if (tablo.FocusedColumn == colDegistirebilir && source[i].Degistirebilir == 1)
                    source[i].Degistirebilir = 0;
                else if (tablo.FocusedColumn == colSilebilir && source[i].Silebilir == 1)
                    source[i].Silebilir = 0;
                else if (tablo.FocusedColumn == colKartTuru)
                {
                    if (source[i].Gorebilir == 1)
                        source[i].Gorebilir = 0;
                    if (source[i].Ekleyebilir == 1)
                        source[i].Ekleyebilir = 0;
                    if (source[i].Degistirebilir == 1)
                        source[i].Degistirebilir = 0;
                    if (source[i].Silebilir == 1)
                        source[i].Silebilir = 0;
                }
                if (!source[i].Insert)
                    source[i].Update = true;
                tablo.RefreshRow(i);
            }

            ButonEnabledDurumu(true);
        }
        protected override void CheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            insUptNavigator.Navigator.Buttons.DoClick(insUptNavigator.Navigator.Buttons.EndEdit);
        }
    }
}