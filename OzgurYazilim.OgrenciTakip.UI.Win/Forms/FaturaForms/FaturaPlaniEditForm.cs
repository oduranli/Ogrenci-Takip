using System.Linq;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using DevExpress.XtraBars;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using System.Windows.Forms;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using System;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.FaturaForms
{
    public partial class FaturaPlaniEditForm : BaseEditForm
    {
        public FaturaPlaniEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            BaseKartTuru = KartTuru.Fatura;

            EventsLoad();
            HideItems = new BarItem[] { btnYeni };
            btnSil.Caption = "İptal Et";
        }
        public override void Yukle()
        {
            TabloYukle();

            using (var bll = new HizmetBilgileriBll())
            {
                var list = bll.FaturaPlaniList(x => x.TahakkukId == Id).ToList();
                txtOgrenciNo.Text = list[0].OkulNo;
                txtAdi.Text = list[0].Adi;
                txtSoyadi.Text = list[0].Soyadi;
                txtSinif.Text = list[0].SinifAdi;
                txtVeliAdi.Text = list[0].VeliAdi;
                txtVeliSoyadi.Text = list[0].VeliSoyadi;
                txtYakinlik.Text = list[0].VeliYakinlikAdi;
                txtMeslek.Text = list[0].VeliMeslekAdi;

                tablo.GridControl.DataSource = list;
                // Id = list[0].TahakkukId;
            }
        }

        protected internal override void ButonEnabledDurumu()
        {
            GeneralFunctions.ButonEnabledDurumu(btnKaydet, btnGeriAl, faturaPlaniTable.TableValueChanged);
        }
        protected override void TabloYukle()
        {
            faturaPlaniTable.OwnerForm = this;
            faturaPlaniTable.Yukle();
        }

        protected override bool EntityInsert()
        {
            return faturaPlaniTable.Kaydet();
        }
        protected override bool EntityUpdate()
        {
            return faturaPlaniTable.Kaydet();
        }
        protected override void EntityDelete()
        {
            if (Messages.HayirSeciliEvetHayir("Fatura planı iptal edilecektir. Onaylıyor musunuz?", "İptal Onay!") != DialogResult.Yes) return;

            var source = faturaPlaniTable.Tablo.DataController.ListSource.Cast<FaturaPlaniL>()
                .Where(x => x.TahakkukTarih == null).ToList();
            if (source.Count == 0) return;

            source.ForEach(x => x.Delete = true);
            faturaPlaniTable.Tablo.RefreshDataSource();
            faturaPlaniTable.TableValueChanged = true;
            ButonEnabledDurumu();
        }

        protected override void BaseEditForm_Shown(object sender, EventArgs e)
        {
            faturaPlaniTable.Tablo.Focus();
        }
    }
}