using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraSplashScreen;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using OzgurYazilim.OgrenciTakip.UI.Yonetim.Forms.GeneralForms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.UI.Yonetim.Functions
{
    class GeneralFunctions
    {
        protected internal static bool CreateDatabase<TContext>(string splashCaption, string splashDescription, string onayMesaj, string bilgiMesaj) where TContext : DbContext, new()
        {
            using (var con = new TContext())
            {
                con.Database.Connection.ConnectionString = Bll.Functions.GeneralFunctions.GetConnectionString();
                if (con.Database.Exists()) return true;

                if (Messages.EvetSeciliEvetHayir(onayMesaj, "Onay!") != DialogResult.Yes) return false;

                var splashForm = new SplashScreenManager(Form.ActiveForm, typeof(BekleForm), true, true);
                SplashBaslat(splashForm);

                splashForm.SetWaitFormCaption(splashCaption);
                splashForm.SetWaitFormDescription(splashDescription);

                try
                {
                    if (con.Database.CreateIfNotExists())
                    {
                        SplashDurdur(splashForm);
                        Messages.BilgiMesaji(bilgiMesaj);
                        return true;
                    }
                }
                catch (SqlException ex)
                {
                    SplashDurdur(splashForm);

                    switch (ex.Number)
                    {
                        case 5170:
                            Messages.HataMesaji("Veritabanı dosyalarının yükleneceği klasörde aynı isimde zaten 1 dosya var. Lütfen kontrol ediniz...\n\n" + ex.Message);
                            break;
                        default:
                            Messages.HataMesaji(ex.Message);
                            break;
                    }
                }

                return false;
            }
        }
        private static void SplashBaslat(SplashScreenManager manager)
        {
            if (manager.IsSplashFormVisible)
            {
                manager.CloseWaitForm();
                manager.ShowWaitForm();
            }
            else
                manager.ShowWaitForm();
        }
        private static void SplashDurdur(SplashScreenManager manager)
        {
            if (manager.IsSplashFormVisible)
                manager.CloseWaitForm();
        }
        protected internal static bool DeleteDatabase<TContext>() where TContext : DbContext, new()
        {
            using (var con = new TContext())
            {
                con.Database.Connection.ConnectionString = Bll.Functions.GeneralFunctions.GetConnectionString();
                if (Messages.HayirSeciliEvetHayir("Seçtiğiniz kurum ve kurum işlemlerinin tamamını içeren kurum veritabanı (veritabanı dosyaları dahil) silinecektir. Onaylıyor musunuz?", "Silme Onayı!") != DialogResult.Yes) return false;
                if (Messages.HayirSeciliEvetHayir("Seçtiğiniz kurum ve kurum işlemlerinin tamamını içeren kurum veritabanı (veritabanı dosyaları dahil) silinecektir.Emin misiniz?", "Silme Onayı 2!") != DialogResult.Yes) return false;

                try
                {
                    if (con.Database.Delete())
                    {
                        Messages.BilgiMesaji("Kurum silme işlemi başarılı bir şekilde tamamlanmıştır.");
                        return true;
                    }
                }
                catch (SqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 3702:
                            Messages.HataMesaji("Veritabanı halen kullanılmakta olduğundan silinemedi. Lütfen veritabanına yapılan tüm bağlantıları kapatıp tekrar deneyiniz.");
                            break;
                        default:
                            Messages.HataMesaji(ex.Message);
                            break;
                    }
                }

                return false;
            }
        }
    }
}
