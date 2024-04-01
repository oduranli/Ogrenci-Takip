using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using OzgurYazilim.OgrenciTakip.UI.Win.Show;
using DevExpress.XtraBars;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Native;
using System.Linq;
using DevExpress.DataProcessing;
using DevExpress.Utils.Extensions;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.FaturaForms
{
    public partial class FaturaPlaniListForm : BaseListForm
    {
        public FaturaPlaniListForm()
        {
            InitializeComponent();
            Bll = new TahakkukBll();
            HideItems = new BarItem[] { btnYeni, barInsert, barInsertAciklama, barDelete, barDeleteAciklama, btnAktifPasifKartlar };
            ShowItems = new BarItem[] { btnTahakkukYap };
            btnSil.Caption = "Fatura Planı İptal Et";
            btnTahakkukYap.Caption = "Toplu Fatura Planı";
            btnYazdir.CreateDropDownMenu(new BarItem[] { btnTabloYazdir });
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Fatura;
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((TahakkukBll)Bll).FaturaTahakkukList(x => x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }
        protected override void ShowEditForm(long id)
        {
            var entity = tablo.GetRow<FaturaL>();
            if (entity == null) return;

            if (entity.HizmetNetTutar == 0)
            {
                Messages.HataMesaji("Öğrencinin net ücreti sıfır (0) olduğu için fatura planı oluşturamazsınız.");
                return;
            }
            var result = ShowEditForms<FaturaPlaniEditForm>.ShowDialogEditForm(KartTuru.Fatura, id, null);
            ShowEditFormDefault(result);
        }
        protected override void TahakkukYap()
        {
            var source = new List<FaturaL>();
            for (int i = 0; i < tablo.DataRowCount; i++)
                source.Add(tablo.GetRow<FaturaL>(i));

            if (source.Count == 0) return;

            if (ShowEditForms<TopluFaturaPlaniEditForm>.ShowDialogEditForm(KartTuru.Fatura, source))
                Listele();
        }
        protected override void EntityDelete()
        {
            if (Messages.HayirSeciliEvetHayir("Seçilen öğrencilere ait hareket görmeyen tüm fatura planları iptal edilecektir. Onaylıyor musunuz?", "İptal Onayı!") != DialogResult.Yes) return;

            var source = new List<FaturaL>();
            for (int i = 0; i < tablo.DataRowCount; i++)
                source.Add(tablo.GetRow<FaturaL>(i));

            if (source.Count == 0) return;

            using (var bll = new FaturaBll())
            {
                var position = 0.0;
                progressBarControl.Visible = true;
                progressBarControl.Left = (ClientSize.Width - progressBarControl.Width) / 2;
                progressBarControl.Top = (ClientSize.Height - progressBarControl.Height) / 2;
                source.ForEach(x =>
                {
                    var yuzde = 100.0 / source.Count;
                    position += yuzde;

                    var planSource = bll.List(y => y.TahakkukId == x.Id).Where(y => ((FaturaPlaniL)y).TahakkukTarih == null).ToList();
                    bll.Delete(planSource);

                    progressBarControl.Position = (int)position;
                    progressBarControl.Update();
                });
            }
            progressBarControl.Visible = false;
            Messages.BilgiMesaji("Seçilen öğrencilere ait fatura planları başarılı bir şekilde iptal edilmiştir!");
            Listele();
        }
        protected override void Yazdir()
        {

            var source = new List<FaturaR>();
            using (var bll = new FaturaBll())
            {

                for (int i = 0; i < tablo.DataRowCount; i++)
                {
                    var entity = tablo.GetRow<FaturaL>(i);
                    if (entity == null) return;

                    var list = bll.FaturaTahakkukList(x => x.TahakkukId == entity.Id).Cast<FaturaPlaniL>();
                    list.ForEach(x =>
                    {
                        var row = new FaturaR
                        {
                            TahakkukId=x.TahakkukId,
                            OkulNo = x.OkulNo,
                            TcKimlikNo = x.TcKimlikNo,
                            Adi = x.Adi,
                            Soyadi = x.Soyadi,
                            SinifAdi = x.SinifAdi,
                            VeliTcKimlikNo = x.VeliTcKimlikNo,
                            VeliAdi = x.VeliAdi,
                            VeliSoyadi = x.VeliSoyadi,
                            VeliYakinlikAdi = x.VeliYakinlikAdi,
                            VeliMeslekAdi = x.VeliMeslekAdi,
                            FaturaAdres = x.FaturaAdres,
                            FaturaAdresIlAdi = x.FaturaAdresIlAdi,
                            FaturaAdresIlceAdi = x.FaturaAdresIlceAdi,
                            Aciklama = x.Aciklama,
                            Tarih = x.TahakkukTarih,
                            FaturaNo = x.FaturaNo,
                            Tutar = x.TahakkukTutar,
                            Indirim = x.TahakkukIndirimTutar,
                            NetTutar = x.TahakkukNetTutar,
                            KdvSekli = x.KdvSekli,
                            KdvOrani = x.KdvOrani,
                            KdvHaricTutar = x.KdvHaricTutar,
                            KdvTutari = x.KdvTutar,
                            ToplamTutar = x.ToplamTutar,
                            TutarYazi = x.TutarYazi,
                            PlanTutar=entity.PlanTutar,
                            PlanIndirim=entity.PlanIndirim,
                            PlanNetTutar=entity.PlanNetTutar,
                            Sube = x.Sube,
                            Donem = x.Donem,
                        };

                        source.Add(row);
                    });
                }
            }
            ShowListForms<RaporSecim>.ShowDialogListForm(KartTuru.Rapor, false, RaporBolumTuru.FaturaGenelRaporlar, source);
        }
    }
}