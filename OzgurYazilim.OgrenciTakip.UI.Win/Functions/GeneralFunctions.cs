﻿using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports.UI;
using DevExpress.XtraVerticalGrid;
using OzgurYazilim.OgrenciTakip.Bll.Functions;
using OzgurYazilim.OgrenciTakip.Bll.General;
using OzgurYazilim.OgrenciTakip.Common.Enums;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using OzgurYazilim.OgrenciTakip.Model.Entities.Base.Interfaces;
using OzgurYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using OzgurYazilim.OgrenciTakip.UI.Win.GeneralForms;
using OzgurYazilim.OgrenciTakip.UI.Win.Properties;
using OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Controls;
using OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.UI.Win.Functions
{
    public static class GeneralFunctions
    {
        public static long GetRowId(this GridView tablo)
        {
            if (tablo.FocusedRowHandle > -1) return (long)tablo.GetFocusedRowCellValue("Id");
            Messages.KartSecmemeUyariMesaji();
            return -1;
        }
        public static long GetRowCellId(this GridView tablo, GridColumn idColumn)
        {
            var value = tablo.GetRowCellValue(tablo.FocusedRowHandle, idColumn);
            //if (value == null) return -1;
            //else
            //    return (long)value;
            return (long?)value ?? -1; // yukardaki işlem ile aynıdır.
        }
        public static T GetRow<T>(this GridView tablo, bool mesajVer = true)
        {
            if (tablo.FocusedRowHandle > -1) return (T)tablo.GetRow(tablo.FocusedRowHandle);

            if (mesajVer)
                Messages.KartSecmemeUyariMesaji();
            return default(T);
        }
        public static T GetRow<T>(this GridView tablo, int rowHandle)
        {
            if (tablo.FocusedRowHandle > -1) return (T)tablo.GetRow(rowHandle);
            Messages.KartSecmemeUyariMesaji();
            return default(T);
        }
        private static VeriDegisimYeri VeriDegisimYeriGetir<T>(T oldEntity, T currentEntity)
        {
            foreach (var prop in currentEntity.GetType().GetProperties())
            {
                if (prop.PropertyType.Namespace == "System.Collections.Generic") continue;
                var oldValue = prop.GetValue(oldEntity) ?? string.Empty;
                var currentValue = prop.GetValue(currentEntity) ?? string.Empty;
                if (prop.PropertyType == typeof(byte[]))
                {
                    if (string.IsNullOrEmpty(oldValue.ToString()))
                        oldValue = new byte[] { 0 };
                    if (string.IsNullOrEmpty(currentValue.ToString()))
                        currentValue = new byte[] { 0 };
                    if (((byte[])oldValue).Length != ((byte[])currentValue).Length)
                        return VeriDegisimYeri.Alan;
                }
                else if (prop.PropertyType == typeof(SecureString))
                {
                    var oldStr = ((SecureString)oldValue).ConvertToUnSecureString();
                    var curStr = ((SecureString)currentValue).ConvertToUnSecureString();
                    if (!oldStr.Equals(curStr))
                        return VeriDegisimYeri.Alan;
                }
                else if (!currentValue.Equals(oldValue))
                    return VeriDegisimYeri.Alan;
            }
            return VeriDegisimYeri.VeriDegisimiYok;
        }

        public static void ButonEnabledDurumu<T>(BarButtonItem btnYeni, BarButtonItem btnKaydet, BarButtonItem btnGeriAl, BarButtonItem btnSil, T oldEntity, T currentEntity)
        {
            var veriDegisimYeri = VeriDegisimYeriGetir(oldEntity, currentEntity);
            var butonEnabledDurumu = veriDegisimYeri == VeriDegisimYeri.Alan;

            btnKaydet.Enabled = butonEnabledDurumu;
            btnGeriAl.Enabled = butonEnabledDurumu;
            btnYeni.Enabled = !butonEnabledDurumu;
            btnSil.Enabled = !butonEnabledDurumu;
        }
        public static void ButonEnabledDurumu(BarButtonItem btnYeni, BarButtonItem btnKaydet, BarButtonItem btnGeriAl, BarButtonItem btnSil)
        {
            btnKaydet.Enabled = false;
            btnGeriAl.Enabled = false;
            btnYeni.Enabled = false;
            btnSil.Enabled = false;
        }
        public static void ButonEnabledDurumu<T>(BarButtonItem btnYeni, BarButtonItem btnKaydet, BarButtonItem btnGeriAl, BarButtonItem btnSil, T oldEntity, T currentEntity, bool tableValueChanged)
        {
            var veriDegisimYeri = tableValueChanged ? VeriDegisimYeri.Tablo : VeriDegisimYeriGetir(oldEntity, currentEntity);
            var butonEnabledDurumu = veriDegisimYeri == VeriDegisimYeri.Alan || veriDegisimYeri == VeriDegisimYeri.Tablo;

            btnKaydet.Enabled = butonEnabledDurumu;
            btnGeriAl.Enabled = butonEnabledDurumu;
            btnYeni.Enabled = !butonEnabledDurumu;
            btnSil.Enabled = !butonEnabledDurumu;
        }
        public static void ButonEnabledDurumu<T>(BarButtonItem btnKaydet, BarButtonItem btnFarkliKaydet, BarButtonItem btnSil, IslemTuru islemTuru, T oldEntity, T currentEntity)
        {
            var veriDegisimYeri = VeriDegisimYeriGetir(oldEntity, currentEntity);
            var butonEnabledDurumu = veriDegisimYeri == VeriDegisimYeri.Alan;

            btnKaydet.Enabled = butonEnabledDurumu;
            btnFarkliKaydet.Enabled = islemTuru != IslemTuru.EntityInsert;
            btnSil.Enabled = !butonEnabledDurumu;
        }
        public static void ButonEnabledDurumu(BarButtonItem btnKaydet, BarButtonItem btnGeriAl, bool tableValueChanged)
        {
            var butonEnabledDurumu = tableValueChanged;

            btnKaydet.Enabled = butonEnabledDurumu;
            btnGeriAl.Enabled = butonEnabledDurumu;
        }
        public static long IdOlustur(this IslemTuru islemTuru, BaseEntity selectedEntity)
        {
            string SifirEkle(string deger)
            {
                if (deger.Length == 1)
                    return "0" + deger;
                return deger;
            }
            string UcBasamakYap(string deger)
            {
                switch (deger.Length)
                {
                    case 1:
                        return "00" + deger;
                    case 2:
                        return "0" + deger;
                }
                return deger;
            }
            string Id()
            {
                var yil = DateTime.Now.Date.Year.ToString();
                var ay = SifirEkle(DateTime.Now.Date.Month.ToString());
                var gun = SifirEkle(DateTime.Now.Date.Day.ToString());
                var saat = SifirEkle(DateTime.Now.Hour.ToString());
                var dakika = SifirEkle(DateTime.Now.Minute.ToString());
                var saniye = SifirEkle(DateTime.Now.Second.ToString());
                var milisaniye = UcBasamakYap(DateTime.Now.Millisecond.ToString());
                var random = SifirEkle(new Random().Next(0, 99).ToString());
                return yil + ay + gun + saat + dakika + saniye + milisaniye + random;
            }
            return islemTuru == IslemTuru.EntityUpdate ? selectedEntity.Id : long.Parse(Id());
        }

        public static void ControlEnabledChange(this MyButtonEdit baseEdit, Control prmEdit)
        {
            switch (prmEdit)
            {
                case MyButtonEdit edt:
                    edt.Enabled = baseEdit.Id.HasValue && baseEdit.Id > 0;
                    edt.Id = null;
                    edt.EditValue = null;
                    break;
                case PropertyGridControl pGrd:
                    pGrd.Enabled = baseEdit.Id.HasValue && baseEdit.Id > 0;
                    if (!pGrd.Enabled)
                        pGrd.SelectedObject = null;
                    break;
            }
        }
        public static void RowFocus(this GridView tablo, string aranacakKolon, object aranacakDeger)
        {
            var rowHandle = 0;
            for (int i = 0; i < tablo.RowCount; i++)
            {
                var bulunanDeger = tablo.GetRowCellValue(i, aranacakKolon);
                if (aranacakDeger.Equals(bulunanDeger))
                    rowHandle = i;
            }

            tablo.Focus();
            tablo.FocusedRowHandle = rowHandle;
        }
        public static void RowFocus(this GridView tablo, int rowHandle)
        {
            if (rowHandle <= 0) return;

            if (rowHandle == tablo.RowCount - 1)
                tablo.FocusedRowHandle = rowHandle;
            else
                tablo.FocusedRowHandle = rowHandle - 1;
        }
        public static void SagMenuGoster(this MouseEventArgs e, PopupMenu sagMenu)
        {
            if (e.Button != MouseButtons.Right) return;
            sagMenu.ShowPopup(Control.MousePosition);
        }
        public static List<string> YazicilariListele()
        {
            return PrinterSettings.InstalledPrinters.Cast<string>().ToList();
        }
        public static string DefaultYazici()
        {
            var settings = new PrinterSettings();
            return settings.PrinterName;
        }
        public static void ShowPopupMenu(this MouseEventArgs e, PopupMenu popupMenu)
        {
            if (e.Button != MouseButtons.Right) return;
            popupMenu.ShowPopup(Control.MousePosition);
        }
        public static byte[] ResimYukle()
        {
            var dialog = new OpenFileDialog
            {
                Title = "Resim Seç",
                Filter = "Resim dosyaları (*.bmp,*.gif, *.jpg, *.png)|*.bmp; *.gif; *.jpg; *.png|Bmp dosyaları|*.bmp|Gif dosyaları|*.gif|Jpg dosyaları|*.jpg|Png dosyaları|*.png",
                InitialDirectory = @"C:\"
            };
            byte[] Resim()
            {
                using (var stream = new MemoryStream())
                {
                    Image.FromFile(dialog.FileName).Save(stream, ImageFormat.Png);
                    return stream.ToArray();
                }
            }
            return dialog.ShowDialog() != DialogResult.OK ? null : Resim();
        }
        public static void RefreshDataSource(this GridView tablo)
        {
            var source = tablo.DataController.ListSource.Cast<IBaseHareketEntity>().ToList();
            if (!source.Any(x => x.Delete)) return;
            var rowHandle = tablo.FocusedRowHandle;

            tablo.CustomRowFilter += Tablo_CustomRowFilter;
            tablo.RefreshData();
            tablo.CustomRowFilter -= Tablo_CustomRowFilter;
            tablo.RowFocus(rowHandle);

            void Tablo_CustomRowFilter(object sender, RowFilterEventArgs e)
            {
                var entity = source[e.ListSourceRow];
                if (entity == null) return;

                if (!entity.Delete) return;
                e.Visible = false;
                e.Handled = true;
            }
        }
        public static BindingList<T> ToBindingList<T>(this IEnumerable<BaseHareketEntity> list)
        {
            return new BindingList<T>((IList<T>)list);
        }
        public static BaseTablo AddTable(this BaseTablo tablo, BaseEditForm frm)
        {
            tablo.Dock = DockStyle.Fill;
            tablo.OwnerForm = frm;
            return tablo;
        }
        public static void LayoutControlInsert(this LayoutGroup grup, Control control, int columnIndex, int rowIndex, int columnSpan, int rowSpan)
        {
            var item = new LayoutControlItem
            {
                Control = control,
                Parent = grup,
            };
            item.OptionsTableLayoutItem.ColumnIndex = columnIndex;
            item.OptionsTableLayoutItem.RowIndex = rowIndex;
            item.OptionsTableLayoutItem.ColumnSpan = columnSpan;
            item.OptionsTableLayoutItem.RowSpan = rowSpan;
        }
        public static void RowCellEnabled(this GridView tablo)
        {
            var rowHandle = tablo.FocusedRowHandle;

            tablo.FocusedRowHandle = 0;
            tablo.ClearSelection();

            tablo.FocusedRowHandle = rowHandle;
        }
        public static void CreateDropDownMenu(this BarButtonItem baseButton, BarItem[] buttonItems)
        {
            baseButton.ButtonStyle = BarButtonStyle.CheckDropDown;
            var popupMenu = new PopupMenu();
            buttonItems.ForEach(x => x.Visibility = BarItemVisibility.Always);
            popupMenu.ItemLinks.AddRange(buttonItems);
            baseButton.DropDownControl = popupMenu;
        }
        public static MyXtraReport StreamToReport(this MemoryStream stream)
        {
            return (MyXtraReport)XtraReport.FromStream(stream, true);
        }
        public static MemoryStream ByteToStream(this byte[] report)
        {
            return new MemoryStream(report);
        }
        public static MemoryStream ReportToStream(this XtraReport rapor)
        {
            var stream = new MemoryStream();
            rapor.SaveLayout(stream);
            return stream;
        }
        public static IEnumerable<T> CheckedComboboxList<T>(this MyCheckedComboBoxEdit comboBox)
        {
            return comboBox.Properties.Items.Where(x => x.CheckState == CheckState.Checked).Select(x => (T)x.Value);
        }
        public static void AppSettingsWrite(string key, string value)
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        public static void CreateConnectionString(string initialCatalog, string server, SecureString kullaniciAdi, SecureString sifre, YetkilendirmeTuru yetkilendirmeTuru)
        {
            SqlConnectionStringBuilder builder = null;

            switch (yetkilendirmeTuru)
            {
                case YetkilendirmeTuru.SqlServer:
                    builder = new SqlConnectionStringBuilder
                    {
                        DataSource = server,
                        UserID = kullaniciAdi.ConvertToUnSecureString(),
                        Password = sifre.ConvertToUnSecureString(),
                        InitialCatalog = initialCatalog,
                        MultipleActiveResultSets = true
                    };
                    break;
                case YetkilendirmeTuru.Windows:
                    builder = new SqlConnectionStringBuilder
                    {
                        DataSource = server,
                        InitialCatalog = initialCatalog,
                        IntegratedSecurity = true,
                        MultipleActiveResultSets = true
                    };
                    break;
            }

            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.ConnectionStrings.ConnectionStrings["OgrenciTakipContext"].ConnectionString = builder?.ConnectionString;
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Settings.Default.Reset();
            Settings.Default.Save();
        }


        public static bool BaglantiKontrolu(string server, SecureString kullaniciAdi, SecureString sifre, YetkilendirmeTuru yetkilendirmeTuru, bool genelMesajVer = false)
        {
            CreateConnectionString("", server, kullaniciAdi, sifre, yetkilendirmeTuru);
            using (var con = new SqlConnection(Bll.Functions.GeneralFunctions.GetConnectionString()))
            {
                try
                {
                    if (con.ConnectionString == "") return false;
                    con.Open();
                    return true;
                }
                catch (SqlException ex)
                {
                    if (genelMesajVer)
                    {
                        Messages.HataMesaji("Server bağlantı ayarlarınız hatalıdır. Lütfen kontrol ediniz.");
                        return false;
                    }

                    switch (ex.Number)
                    {
                        case 18456:
                            Messages.HataMesaji("Server kullanıcı adı veya şifresi hatalıdır.");
                            break;
                        default:
                            Messages.HataMesaji(ex.Message);
                            break;
                    }
                }

                return false;
            }
        }
        public static string MD5Sifrele(this string value)
        {
            var Md5 = new MD5CryptoServiceProvider();
            var ba = Encoding.UTF8.GetBytes(value);
            ba = Md5.ComputeHash(ba);

            var md5Sifre = BitConverter.ToString(ba).Replace("-", "");
            return md5Sifre;
        }
        public static (SecureString secureSifre, SecureString secureGizliKelime, string sifre, string gizliKelime) SifreUret()
        {
            string RandomDegerUret(int minValue, int count)
            {
                var random = new Random();
                const string karakterTablosu = "0123456789ABCDEFGHIJKLMNOPQRSTUVXWYZabcdefghijklmnopqrstuvwxyz"; //asla değişmeyecek değişkenlere atanır.
                string sonuc = null;
                for (int i = 0; i < count; i++)
                    sonuc += karakterTablosu[random.Next(minValue, karakterTablosu.Length - 1)].ToString();

                return sonuc;
            }

            var secureSifre = RandomDegerUret(0, 8).ConvertToSecureString();
            var secureGizliKelime = RandomDegerUret(9, 10).ConvertToSecureString(); // karakter tablosunun 9. karakteri yani A dan başlar içinde rakam olmaması için.
            var sifre = secureSifre.ConvertToUnSecureString().MD5Sifrele();
            var gizliKelime = secureGizliKelime.ConvertToUnSecureString().MD5Sifrele();

            return (secureSifre, secureGizliKelime, sifre, gizliKelime);
        }
        public static bool SifreMailiGonder(this string kullaniciAdi, string rol, string email, SecureString secureSifre, SecureString secureGizliKelime)
        {
            using (var bll = new MailParametreBll())
            {
                var entity = (MailParametre)bll.Single(null);
                if (entity == null)
                {
                    Messages.HataMesaji("Email gönderilemedi. Kurumun email paramatreleri girilmemiş. Lütfen kontrol edip tekrar deneyiniz.");
                    return false;
                }

                var client = new SmtpClient()
                {
                    Port = entity.PortNo,
                    Host = entity.Host,
                    EnableSsl = entity.SslKullan == EvetHayir.Evet,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential(entity.Email, entity.Sifre.Decrypt(entity.Id + entity.Kod).ConvertToSecureString()),
                };
                var message = new MailMessage
                {
                    From = new MailAddress(entity.Email, "Özgür Yazılım Öğrenci Takip Programı"),
                    To = { email },
                    Subject = "Özgür Yazılım Öğrenci Takip Programı Kullanıcı Bilgileri",
                    IsBodyHtml = true,
                    Body = "Özgür Yazılım Öğrenci Takip Programına giriş için gereken kullanıcı adı, şifre ve gizli kelime bilgileri aşağıdadır. <br/>" +
                           "Lütfen programa giriş yaptıktan sonra bu bilgileri değiştiriniz.<br/><br/><br/>" +
                           $"<b>Kullanıcı Adı :</b> {kullaniciAdi} <br/>" +
                           $"<b>Yetki Türü : </b> {rol}<br/>" +
                           $"<b>Şifre : </b> {secureSifre.ConvertToUnSecureString()}<br/>" +
                           $"<b>Gizli Kelime : </b> {secureGizliKelime.ConvertToUnSecureString()}<br/>",
                };

                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    client.Send(message);
                    Cursor.Current = Cursors.Default;
                    return true;
                }
                catch (Exception ex)
                {
                    Messages.HataMesaji(ex.Message);
                    return false;
                }
            }
        }
        public static bool YetkiKontrolu(this KartTuru kartTuru, YetkiTuru yetkiTuru)
        {
            if (AnaForm.KullaniciId == 0) return true;

            RolYetkileri yetkiler;
            using (var bll = new RolYetkileriBll())
                yetkiler = AnaForm.DonemParemetreleri.YetkiKontroluAnlikYapilacak ?
                    bll.Single(x => x.RolId == AnaForm.KullaniciRolId && x.KartTuru == kartTuru).EntityConvert<RolYetkileri>() :
                    AnaForm.RolYetkileri.FirstOrDefault(x => x.KartTuru == kartTuru);

            var result = false;

            switch (yetkiTuru)
            {
                case YetkiTuru.Gorebilir:
                    result = yetkiler?.Gorebilir == 1;
                    break;
                case YetkiTuru.Ekleyebilir:
                    result = yetkiler?.Ekleyebilir == 1;
                    break;
                case YetkiTuru.Degistirebilir:
                    result = yetkiler?.Degistirebilir == 1;
                    break;
                case YetkiTuru.Silebilir:
                    result = yetkiler?.Silebilir == 1;
                    break;
            }

            if (!result)
                Messages.UyariMesaji("Bu işlem için yetkiniz yoktur.");

            return result;
        }
        public static bool EditFormYetkiKontrolu(long id, KartTuru kartTuru)
        {
            var islemTuru = id > 0 ? IslemTuru.EntityUpdate : IslemTuru.EntityInsert;
            switch (islemTuru)
            {
                case IslemTuru.EntityInsert when !kartTuru.YetkiKontrolu(YetkiTuru.Ekleyebilir):
                    return false;
                case IslemTuru.EntityUpdate when !kartTuru.YetkiKontrolu(YetkiTuru.Degistirebilir):
                    return false;
            }

            return true;
        }
        public static void EncryptConfigFile(string configFileName, params string[] sectionName)
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(configFileName);

            foreach (var x in sectionName)
            {
                var section = configuration.GetSection(x);

                if (section.SectionInformation.IsProtected) return;
                else
                    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");

                section.SectionInformation.ForceSave = true;
                configuration.Save();
            }
        }
    }
}