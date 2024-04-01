using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraVerticalGrid;
using OzgurYazilim.OgrenciTakip.Bll.Interfaces;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base.Interfaces;
using OzgurYazilim.OgrenciTakip.UI.Win.Functions;
using OzgurYazilim.OgrenciTakip.UI.Win.Interfaces;
using OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Controls;
using OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid;
using System;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms
{
    public partial class BaseEditForm : RibbonForm
    {

        #region Variables

        private bool _formSablonKayitEdilecek;

        protected MyDataLayoutControl DataLayoutControl;
        protected MyDataLayoutControl[] DataLayoutControls;
        protected IBaseBll Bll;
        protected KartTuru BaseKartTuru;
        protected BaseEntity OldEntity;
        protected BaseEntity CurrentEntity;
        protected bool IsLoaded;
        protected bool KayitSonrasiFormuKapat = true;
        protected BarItem[] ShowItems;
        protected BarItem[] HideItems;

        protected internal IslemTuru BaseIslemTuru;
        protected internal long Id;
        protected internal bool RefreshYapilacak;
        protected bool FarkliSubeIslemi;

        #endregion


        public BaseEditForm()
        {
            InitializeComponent();
        }

        protected void EventsLoad()
        {
            //Button Events
            foreach (BarItem button in ribbonControl.Items)
                button.ItemClick += Button_ItemClick;


            //Form Events
            LocationChanged += BaseEditForm_LocationChanged;
            SizeChanged += BaseEditForm_SizeChanged;
            Load += BaseEditForm_Load;
            FormClosing += BaseEditForm_FormClosing;
            Shown += BaseEditForm_Shown;

            void ControlEvents(Control control)
            {
                control.KeyDown += Control_KeyDown;
                control.GotFocus += Control_GotFocus;
                control.Leave += Control_Leave;
                control.Enter += Control_Enter;

                switch (control)
                {
                    case FilterControl edt:
                        edt.FilterChanged += Control_EditValueChanged;
                        break;
                    case ComboBoxEdit edt:
                        edt.SelectedValueChanged += Control_SelectedValueChanged;
                        edt.EditValueChanged += Control_EditValueChanged;
                        break;
                    case MyButtonEdit edt:
                        edt.IdChanged += Control_IdChanged;
                        edt.EnabledChange += Control_EnabledChange;
                        edt.ButtonClick += Control_ButtonClick;
                        edt.DoubleClick += Control_DoubleClick;
                        break;
                    case BaseEdit edt:
                        edt.EditValueChanged += Control_EditValueChanged; //sıralaması önemli eğer bunu önce yazsaydık mybuttoneditler de baseeditten implemente olduğundan herşeyi etkilerdi. 
                        break;
                    case TabPane tab:
                        tab.SelectedPageChanged += Control_SelectedPageChanged;
                        break;
                    case PropertyGridControl pGrd:
                        pGrd.CellValueChanged += Control_CellValueChanged;
                        pGrd.FocusedRowChanged += Control_FocusedRowChanged;
                        break;
                    case MyGridControl grd:
                        grd.MainView.GotFocus += Control_GotFocus;
                        break;
                }
            }
            if (DataLayoutControls == null)
            {
                if (DataLayoutControl == null) return;
                foreach (Control ctrl in DataLayoutControl.Controls)
                    ControlEvents(ctrl);
            }
            else
                foreach (var layout in DataLayoutControls)
                    foreach (Control ctrl in layout.Controls)
                        ControlEvents(ctrl);
        }

        #region Button Events


        private void ButonGizleGoster()
        {
            ShowItems?.ForEach(x => x.Visibility = BarItemVisibility.Always);
            HideItems?.ForEach(x => x.Visibility = BarItemVisibility.Never);
        }
        private void GeriAl()
        {
            if (Messages.HayirSeciliEvetHayir("Yapılan değişiklikler geri alınacaktır. Onaylıyor musunuz?", "Gerial Onayı!") != DialogResult.Yes) return;
            if (BaseIslemTuru == IslemTuru.EntityUpdate)
                Yukle();
            else
                Close();
        }
        private bool Kaydet(bool kapanis)
        {
            bool KayitIslemi()
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (BaseIslemTuru)
                {
                    case IslemTuru.EntityInsert:
                        if (EntityInsert())
                            return KayitSonrasiIslemler();
                        break;
                    case IslemTuru.EntityUpdate:
                        if (EntityUpdate())
                            return KayitSonrasiIslemler();
                        break;
                }

                bool KayitSonrasiIslemler()
                {
                    OldEntity = CurrentEntity;
                    RefreshYapilacak = true;
                    ButonEnabledDurumu();

                    if (KayitSonrasiFormuKapat)
                        Close();
                    else
                        BaseIslemTuru = BaseIslemTuru == IslemTuru.EntityInsert ? IslemTuru.EntityUpdate : BaseIslemTuru;

                    return true;
                }

                return false;
            }

            var result = kapanis ? Messages.KapanisMesaj() : Messages.KayitMesaj();
            switch (result)
            {
                case DialogResult.Yes:
                    return KayitIslemi();
                case DialogResult.No:
                    if (kapanis)
                        btnKaydet.Enabled = false;
                    return true;

                case DialogResult.Cancel:
                    return false;
            }

            return false;
        }
        private void SablonYukle()
        {
            Name.FormSablonYukle(this);
        }
        private void FarkliKaydet()
        {
            if (Messages.EvetSeciliEvetHayir("Bu filtre referans alınarak yeni bir kayıt oluşturulacaktır. Onaylıyor musunuz?", "Kayıt Onay!") != DialogResult.Yes) return;

            BaseIslemTuru = IslemTuru.EntityInsert;
            Yukle();
            if (Kaydet(true))
                Close();
        }
        protected void SablonKaydet()
        {
            if (_formSablonKayitEdilecek)
                Name.FormSablonKaydet(Left, Top, Width, Height, WindowState);
        }

        protected virtual void FiltreUygula() { }
        protected virtual void TaksitOlustur() { }
        protected virtual void BaskiOnizleme() { }
        protected virtual void Yazdir() { }
        protected virtual void SecimYap(object sender) { }
        protected virtual bool EntityInsert()
        {
            return ((IBaseGenelBll)Bll).Insert(CurrentEntity);
        }
        protected virtual bool EntityUpdate()
        {
            return ((IBaseGenelBll)Bll).Update(OldEntity, CurrentEntity);
        }
        protected virtual void EntityDelete()
        {
            if (!((IBaseCommonBll)Bll).Delete(OldEntity)) return;
            RefreshYapilacak = true;
            Close();
        }
        protected virtual void NesneyiKontrollereBagla() { }
        protected virtual void GuncelNesneOlustur() { }
        protected virtual void TabloYukle() { }
        protected virtual void SifreSifirla() { }
        public virtual void Yukle() { }
        public virtual void Giris() { }
        protected internal virtual IBaseEntity ReturnEntity() { return null; }
        protected internal virtual void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;
            GeneralFunctions.ButonEnabledDurumu(btnYeni, btnKaydet, btnGeriAl, btnSil, OldEntity, CurrentEntity);
        }
        protected virtual void BagliTabloYukle() { }
        protected virtual bool BagliTabloKaydet() { return false; }
        protected virtual bool BagliTabloHataliGirisKontrol() { return false; }

        #endregion

        #region Form Events

        protected virtual void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Item == btnYeni)
            {
                if (!BaseKartTuru.YetkiKontrolu(YetkiTuru.Ekleyebilir)) return;

                BaseIslemTuru = IslemTuru.EntityInsert;
                Yukle();
            }
            else if (e.Item == btnKaydet)
                Kaydet(false);
            else if (e.Item == btnFarkliKaydet)
            {
                if (!BaseKartTuru.YetkiKontrolu(YetkiTuru.Ekleyebilir)) return;

                FarkliKaydet();
            }
            else if (e.Item == btnGeriAl)
                GeriAl();
            else if (e.Item == btnSil)
            {
                if (!BaseKartTuru.YetkiKontrolu(YetkiTuru.Silebilir)) return;

                EntityDelete();
            }
            else if (e.Item == btnUygula)
                FiltreUygula();
            else if (e.Item == btnTaksitOlustur)
                TaksitOlustur();
            else if (e.Item == btnYazdir)
                Yazdir();
            else if (e.Item == btnBaskiOnizleme)
                BaskiOnizleme();
            else if (e.Item == btnSifreSifirla)
                SifreSifirla();
            else if (e.Item == btnGiris)
                Giris();
            else if (e.Item == btnCikis)
                Close();

            Cursor.Current = DefaultCursor;
        }


        private void BaseEditForm_LocationChanged(object sender, EventArgs e)
        {
            _formSablonKayitEdilecek = true;
        }
        private void BaseEditForm_SizeChanged(object sender, EventArgs e)
        {
            _formSablonKayitEdilecek = true;
        }
        private void BaseEditForm_Load(object sender, EventArgs e)
        {
            IsLoaded = true;
            GuncelNesneOlustur();
            SablonYukle();
            ButonGizleGoster();

            if (FarkliSubeIslemi)
                Messages.UyariMesaji("İşlem yapılan kart çalışılan şube veya dönemde olmadığı için yapılan değişiklikler kayıt edilemez.");
        }
        protected virtual void BaseEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SablonKaydet();

            if (btnKaydet.Visibility == BarItemVisibility.Never || !btnKaydet.Enabled) return;

            if (!Kaydet(true))
                e.Cancel = true;
        }
        protected virtual void BaseEditForm_Shown(object sender, EventArgs e) { }
        protected virtual void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            if (sender is MyButtonEdit edt)
                switch (e.KeyCode)
                {
                    case Keys.Delete when e.Control && e.Shift:
                        edt.Id = null;
                        edt.EditValue = null;
                        break;
                    case Keys.F4:
                    case Keys.Down when e.Modifiers == Keys.Alt:
                        SecimYap(edt);
                        break;
                }
        }
        private void Control_GotFocus(object sender, EventArgs e)
        {
            var type = sender.GetType();
            if (type == typeof(MyButtonEdit) || type == typeof(MyGridView) || type == typeof(MyPictureEdit)
                || type == typeof(MyComboBoxEdit) || type == typeof(MyDateEdit) || type == typeof(MyCalcEdit) || type == typeof(MyColorPickEdit))
            {
                StatusBarKisayol.Visibility = BarItemVisibility.Always;
                StatusBarKisayolAciklama.Visibility = BarItemVisibility.Always;

                statusBarAciklama.Caption = ((IStatusBarAciklama)sender).StatusBarAciklama;
                StatusBarKisayol.Caption = ((IStatusBarKisayol)sender).StatusBarKisayol;
                StatusBarKisayolAciklama.Caption = ((IStatusBarKisayol)sender).StatusBarKisayolAciklama;
            }
            else if (sender is IStatusBarAciklama ctrl)
                statusBarAciklama.Caption = ctrl.StatusBarAciklama;
        }
        private void Control_Leave(object sender, EventArgs e)
        {
            StatusBarKisayol.Visibility = BarItemVisibility.Never;
            StatusBarKisayolAciklama.Visibility = BarItemVisibility.Never;
        }
        protected virtual void Control_Enter(object sender, EventArgs e) { }
        protected virtual void Control_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsLoaded) return;
            GuncelNesneOlustur();
        }
        protected virtual void Control_SelectedValueChanged(object sender, EventArgs e) { }
        protected virtual void Control_IdChanged(object sender, IdChangedEventArgs e)
        {
            if (!IsLoaded) return;
            GuncelNesneOlustur();
        }
        protected virtual void Control_EnabledChange(object sender, EventArgs e) { }
        private void Control_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SecimYap(sender);
        }
        private void Control_DoubleClick(object sender, EventArgs e)
        {
            SecimYap(sender);
        }

        #endregion

        protected virtual void Control_SelectedPageChanged(object sender, SelectedPageChangedEventArgs e) { }
        protected virtual void Control_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e) { }
        protected virtual void Control_FocusedRowChanged(object sender, DevExpress.XtraVerticalGrid.Events.FocusedRowChangedEventArgs e) { }
    }
}