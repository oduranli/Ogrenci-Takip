using System;
using System.Reflection;
using DevExpress.XtraSplashScreen;

namespace OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms
{
    public partial class Baslatiliyor : SplashScreen
    {
        public Baslatiliyor()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright Özgür Yazılım © 2020" + DateTime.Now.Year.ToString();
            lblVersion.Text = $"Versiyon : {Assembly.GetExecutingAssembly().GetName().Version}";
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}