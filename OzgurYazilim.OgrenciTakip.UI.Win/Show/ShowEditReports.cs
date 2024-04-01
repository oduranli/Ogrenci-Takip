using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.Reports.FormReports.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Show
{
    public class ShowEditReports<TForm>  where TForm : BaseRapor
    {
        public static void ShowEditReport(KartTuru kartTuru)
        {
            if (!kartTuru.YetkiKontrolu(YetkiTuru.Gorebilir)) return;

            var frm = (TForm)Activator.CreateInstance(typeof(TForm));
            frm.MdiParent = Form.ActiveForm;

            frm.Yukle();
            frm.Show();
        }
    }
}