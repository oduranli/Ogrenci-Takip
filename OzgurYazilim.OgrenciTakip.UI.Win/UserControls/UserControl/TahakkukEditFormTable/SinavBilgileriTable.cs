using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.Base;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Model.Dto;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.Common.Messages;

namespace OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.TahakkukEditFormTable
{
    public partial class SinavBilgileriTable : BaseTablo
    {
        public SinavBilgileriTable()
        {
            InitializeComponent();
            Bll = new SinavBilgileriBll();
            Tablo = tablo;
            EventsLoad();
        }
        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((SinavBilgileriBll)Bll)
                .List(x => x.TahakkukId == OwnerForm.Id)
                .ToBindingList<SinavBilgileriL>();
        }
        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;
            var row = new SinavBilgileriL
            {
                TahakkukId = OwnerForm.Id,
                Tarih = DateTime.Now.Date,
                Insert = true
            };
            source.Add(row);
            tablo.Focus();
            tablo.RefreshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colSinavAdi;

            ButonEnabledDurumu(true);
        }
        protected internal override bool HataliGiris()
        {
            if (!TableValueChanged) return false;
            if (tablo.HasColumnErrors) tablo.ClearColumnErrors();
            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                var entity = tablo.GetRow<SinavBilgileriL>(i);
                if (string.IsNullOrEmpty(entity.SinavAdi))
                {
                    tablo.FocusedRowHandle = i;
                    tablo.FocusedColumn = colSinavAdi;
                    tablo.SetColumnError(colSinavAdi, "Sınav adı alanına geçerli bir değer giriniz!");
                }
                if (string.IsNullOrEmpty(entity.PuanTuru))
                {
                    tablo.FocusedRowHandle = i;
                    tablo.FocusedColumn = colPuanTuru;
                    tablo.SetColumnError(colPuanTuru, "Puan türü alanına geçerli bir değer giriniz!");
                }
                if (!tablo.HasColumnErrors) continue;
                Messages.TabloEksikBilgiMesaji($"{tablo.ViewCaption} tablosu");
                return true;
            }

            return false;
        }
    }
}
