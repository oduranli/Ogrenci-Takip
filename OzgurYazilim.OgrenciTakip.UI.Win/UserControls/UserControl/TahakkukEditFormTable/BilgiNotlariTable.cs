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
    public partial class BilgiNotlariTable : BaseTablo
    {
        public BilgiNotlariTable()
        {
            InitializeComponent();
            Bll = new BilgiNotlariBll();
            Tablo = tablo;
            EventsLoad();
        }
        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((BilgiNotlariBll)Bll)
                .List(x => x.TahakkukId == OwnerForm.Id)
                .ToBindingList<BilgiNotlariL>();
        }
        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;

            var row = new BilgiNotlariL
            {
                TahakkukId = OwnerForm.Id,
                Tarih = DateTime.Now,
                Insert = true
            };
            source.Add(row);

            tablo.Focus();
            tablo.RefreshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colBilgiNotu;

            ButonEnabledDurumu(true);
        }
        protected internal override bool HataliGiris()
        {
            if (!TableValueChanged) return false;
            if (tablo.HasColumnErrors) tablo.ClearColumnErrors();
            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                var entity = tablo.GetRow<BilgiNotlariL>(i);
                if (string.IsNullOrEmpty(entity.BilgiNotu))
                {
                    tablo.FocusedRowHandle = i;
                    tablo.FocusedColumn = colBilgiNotu;
                    tablo.SetColumnError(colBilgiNotu, "Bilgi notu alanına geçerli bir değer giriniz!");
                }

                if (!tablo.HasColumnErrors) continue;

                Messages.TabloEksikBilgiMesaji($"{tablo.ViewCaption} tablosu");
                return true;
            }

            return false;
        }
    }
}