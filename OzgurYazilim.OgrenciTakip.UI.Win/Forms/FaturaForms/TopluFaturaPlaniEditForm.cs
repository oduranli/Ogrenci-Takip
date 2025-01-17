﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.Common.Functions;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using System.Collections;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using System.Drawing;
using DevExpress.XtraLayout.Utils;
using OzgurYazilim.OgrenciTakip.Bll.General;
using DevExpress.Utils.Extensions;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.FaturaForms
{
    public partial class TopluFaturaPlaniEditForm : BaseEditForm
    {

        private readonly IList<FaturaAlinanHizmetlerL> _alinanHizmetlerSource;
        private readonly IList _faturaPlaniSource;
        private readonly IList<FaturaL> _faturaPlaniKartlari;

        public TopluFaturaPlaniEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            EventsLoad();

            HideItems = new BarItem[] { btnYeni, btnKaydet, btnFarkliKaydet, btnGeriAl, btnSil, btnUygula };
            ShowItems = new BarItem[] { btnTaksitOlustur };

            txtOzetTahakkuk.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<EvetHayir>());
            txtAyBilgisi.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<EvetHayir>());
        }
        public TopluFaturaPlaniEditForm(params object[] prm) : this()
        {
            if (prm.Length == 1)
                _faturaPlaniKartlari = (IList<FaturaL>)prm[0];
            else
            {
                _alinanHizmetlerSource = (IList<FaturaAlinanHizmetlerL>)prm[0];
                _faturaPlaniSource = (IList)prm[1];
            }
        }
        public override void Yukle()
        {
            btnTaksitOlustur.Caption = "Plan Oluştur";
            txtIlkFaturaTarih.DateTime = DateTime.Now.Date;
            txtSabitTutar.Value = 0;
            txtOzetTahakkuk.SelectedItem = EvetHayir.Hayir.ToName();
            txtAyBilgisi.SelectedItem = EvetHayir.Hayir.ToName();

            if (_faturaPlaniKartlari != null)
                MinimumSize = new Size(517, 280);
            else
            {
                layoutControlProgress.Visibility = LayoutVisibility.Never;
                Root.OptionsTableLayoutGroup.RowDefinitions.RemoveAt(4);
                Root.Update();
                MaximumSize = new Size(517, 250);
            }
        }
        private static string AlinanHizmetler(IList<string> hizmetlerSource)
        {
            var alinanHizmetler = "";

            for (int i = 0; i < hizmetlerSource.Count; i++)
            {
                alinanHizmetler += hizmetlerSource[i];
                if (i + 1 < hizmetlerSource.Count)
                    alinanHizmetler += ", ";
            }

            return alinanHizmetler;
        }
        protected override void TaksitOlustur()
        {
            if (_faturaPlaniKartlari != null)
            {
                TopluFaturaPlani();
                return;
            }

            var tahakkukId = _alinanHizmetlerSource.Select(x => x.TahakkukId).First();
            var alinanHizmetler = _alinanHizmetlerSource.Select(x => x.HizmetAdi).ToList();
            var hizmetlerToplami = _alinanHizmetlerSource.Sum(x => x.BrutUcret);
            var indirimlerToplami = _alinanHizmetlerSource.Sum(x => x.Indirim);

            var ilkFaturaTarih = txtIlkFaturaTarih.DateTime.Date;
            var faturaAdet = (int)txtAdet.Value;
            var sabitTutar = txtSabitTutar.Value;
            var ozetTahakkuk = txtOzetTahakkuk.Text.GetEnum<EvetHayir>();
            var ozetAciklama = txtOzetTahakkukAciklama.Text;

            var girilenBrutTutarToplami = _faturaPlaniSource.Cast<FaturaPlaniL>().Where(x => !x.Delete).Sum(x => x.PlanTutar);
            var girilenIndirimTutarToplami = _faturaPlaniSource.Cast<FaturaPlaniL>().Where(x => !x.Delete).Sum(x => x.PlanIndirimTutar);

            var girilecekBrutTutar = sabitTutar > 0 ? sabitTutar : Math.Round((hizmetlerToplami - girilenBrutTutarToplami) / faturaAdet, AnaForm.DonemParemetreleri.FaturaTahakkukKurusKullan ? 2 : 0);
            var girilecekIndirimTutar = sabitTutar > 0 ? 0 : Math.Round((indirimlerToplami - girilenIndirimTutarToplami) / faturaAdet, AnaForm.DonemParemetreleri.FaturaTahakkukKurusKullan ? 2 : 0);
            var girilecekNetTutar = girilecekBrutTutar - girilecekIndirimTutar;

            if (girilecekBrutTutar <= 0)
            {
                Messages.UyariMesaji("Verilen hizmetler toplamı kadar fatura planı zaten oluşturulmuş");
                return;
            }
            for (int i = 0; i < faturaAdet; i++)
            {
                var row = new FaturaPlaniL
                {
                    TahakkukId = tahakkukId,
                    Aciklama = ozetTahakkuk == EvetHayir.Evet ? ozetAciklama : AlinanHizmetler(alinanHizmetler) + " Bedeli",
                    PlanTarih = ilkFaturaTarih.AddMonths(i),
                    PlanTutar = girilecekBrutTutar,
                    PlanIndirimTutar = girilecekIndirimTutar,
                    PlanNetTutar = girilecekNetTutar,
                    Insert = true,
                };
                if (txtOzetTahakkuk.Text.GetEnum<EvetHayir>() == EvetHayir.Evet)
                    row.Aciklama = ozetAciklama;
                if (txtAyBilgisi.Text.GetEnum<EvetHayir>() == EvetHayir.Evet)
                {
                    var ay = (Aylar)row.PlanTarih.Month;
                    row.Aciklama = ay.ToName() + " - " + row.PlanTarih.Year + " Ayı " + row.Aciklama;
                }

                if (i + 1 == faturaAdet && sabitTutar == 0)
                {
                    row.PlanTutar = hizmetlerToplami - _faturaPlaniSource.Cast<FaturaPlaniL>().Where(x => !x.Delete).Sum(x => x.PlanTutar);
                    row.PlanIndirimTutar = indirimlerToplami - _faturaPlaniSource.Cast<FaturaPlaniL>().Where(x => !x.Delete).Sum(x => x.PlanIndirimTutar);
                    row.PlanNetTutar = row.PlanTutar - row.PlanIndirimTutar;
                }

                _faturaPlaniSource.Add(row);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        private void TopluFaturaPlani()
        {
            if (Messages.HayirSeciliEvetHayir("Toplu fatura planı oluşturulacaktır. Onaylıyor musunuz?", "Onay!") != DialogResult.Yes) return;

            var ilkFaturaTarih = txtIlkFaturaTarih.DateTime.Date;
            var faturaAdet = (int)txtAdet.Value;
            var sabitTutar = txtSabitTutar.Value;
            var ozetTahakkuk = txtOzetTahakkuk.Text.GetEnum<EvetHayir>();
            var ozetAciklama = txtOzetTahakkukAciklama.Text;
            var position = 0.0;

            using (var faturaBll = new FaturaBll())
            {
                using (var hizmetBilgileriBll = new HizmetBilgileriBll())
                {
                    _faturaPlaniKartlari.ForEach(x =>
                    {
                        var yuzde = 100.0 / _faturaPlaniKartlari.Count();
                        position += yuzde;
                        var hizmetTutar = x.HizmetTutar;
                        var hizmetIndirim = x.HizmetIndirim;
                        var planIndirim = x.PlanIndirim;
                        var planTutar = x.PlanTutar;
                        var alinanHizmetler = AlinanHizmetler(hizmetBilgileriBll.FaturaPlaniList(y => y.TahakkukId == x.Id)
                            .Select(y => y.HizmetAdi).ToList());

                        var girilecekBrutTutar = sabitTutar > 0 ? sabitTutar : Math.Round((hizmetTutar - planTutar) / faturaAdet, AnaForm.DonemParemetreleri.FaturaTahakkukKurusKullan ? 2 : 0);
                        var girilecekIndirimTutar = sabitTutar > 0 ? 0 : Math.Round((hizmetIndirim - planIndirim) / faturaAdet, AnaForm.DonemParemetreleri.FaturaTahakkukKurusKullan ? 2 : 0);
                        var girilecekNetTutar = girilecekBrutTutar - girilecekIndirimTutar;

                        if (hizmetTutar == 0 || hizmetTutar == planTutar && hizmetIndirim == planIndirim)
                        {
                            progressBarControl.Position = 100;
                            return;
                        }

                        for (int i = 0; i < faturaAdet; i++)
                        {
                            var row = new FaturaPlaniL
                            {
                                TahakkukId = x.Id,
                                Aciklama = ozetTahakkuk == EvetHayir.Evet ? ozetAciklama : alinanHizmetler + " Bedeli",
                                PlanTarih = ilkFaturaTarih.AddMonths(i),
                                PlanTutar = girilecekBrutTutar,
                                PlanIndirimTutar = girilecekIndirimTutar,
                                PlanNetTutar = girilecekNetTutar,
                                Insert = true,
                            };
                            if (txtOzetTahakkuk.Text.GetEnum<EvetHayir>() == EvetHayir.Evet)
                                row.Aciklama = ozetAciklama;
                            if (txtAyBilgisi.Text.GetEnum<EvetHayir>() == EvetHayir.Evet)
                            {
                                var ay = (Aylar)row.PlanTarih.Month;
                                row.Aciklama = ay.ToName() + " - " + row.PlanTarih.Year + " Ayı " + row.Aciklama;
                            }

                            if (i + 1 == faturaAdet && sabitTutar == 0)
                            {
                                row.PlanTutar = (hizmetTutar - planTutar) - (girilecekBrutTutar * i);
                                row.PlanIndirimTutar = (hizmetIndirim - planIndirim) - (girilecekIndirimTutar * i);
                                row.PlanNetTutar = row.PlanTutar - row.PlanIndirimTutar;
                            }
                            if (!faturaBll.InsertSingle(row)) return;
                            progressBarControl.Position = (int)position;
                            progressBarControl.Update();
                        }
                    });
                }
            }
            Messages.BilgiMesaji("Fatura planı oluşturma işlemi başarılı bir şekilde tamamlandı!");
            DialogResult = DialogResult.OK;
            Close();
        }
        protected override void Control_SelectedValueChanged(object sender, EventArgs e)
        {
            if (sender != txtOzetTahakkuk) return;
            txtOzetTahakkukAciklama.Enabled = txtOzetTahakkuk.Text.GetEnum<EvetHayir>() == EvetHayir.Evet;
            txtOzetTahakkukAciklama.Focus();
        }
    }
}