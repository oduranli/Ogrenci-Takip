using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.UI.Win
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

            BonusSkins.Register();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");

            UserLookAndFeel.Default.SetSkinStyle(ConfigurationManager.AppSettings["Skin"], ConfigurationManager.AppSettings["Palette"]);
            Application.Run(new GirisForm());
        }
    }
}
