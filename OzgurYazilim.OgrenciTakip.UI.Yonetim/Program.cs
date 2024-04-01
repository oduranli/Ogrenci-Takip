using System;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using OzgurYazilim.OgrenciTakip.UI.Yonetim.Forms.GeneralForms;
using System.Configuration;
using System.Globalization;
using System.Threading;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;

namespace OzgurYazilim.OgrenciTakip.UI.Yonetim
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GeneralFunctions.EncryptConfigFile(AppDomain.CurrentDomain.SetupInformation.ApplicationName, "connectionStrings", "appSettings");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle(ConfigurationManager.AppSettings["Skin"], ConfigurationManager.AppSettings["Palette"]);
            Application.Run(new GirisForm());
        }
    }
}
