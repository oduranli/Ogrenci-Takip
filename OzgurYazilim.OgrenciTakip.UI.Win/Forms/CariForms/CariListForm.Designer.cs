﻿namespace OzgurYazilim.OgrenciTakip.UI.Win.Forms.CariForms
{
    partial class CariListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CariListForm));
            this.longNavigator = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Navigators.LongNavigator();
            this.grid = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridControl();
            this.tablo = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colKod = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colTcKimlikNo = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colCariAdi = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colTelefon1 = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colTelefon2 = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colTelefon3 = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colTelefon4 = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colFaks = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colWeb = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colEmail = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colAdres = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colVergiDairesi = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colVergiNo = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colOzelKod1Adi = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colOzelKod2Adi = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colAciklama = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colId = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyBandedGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            // 
            // 
            // 
            this.ribbonControl.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl.SearchEditItem.EditWidth = 150;
            this.ribbonControl.SearchEditItem.Id = -5000;
            this.ribbonControl.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // btnGonder
            // 
            this.btnGonder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGonder.ImageOptions.Image")));
            this.btnGonder.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGonder.ImageOptions.LargeImage")));
            // 
            // longNavigator
            // 
            this.longNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.longNavigator.Location = new System.Drawing.Point(0, 362);
            this.longNavigator.Name = "longNavigator";
            this.longNavigator.Size = new System.Drawing.Size(1108, 24);
            this.longNavigator.TabIndex = 2;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 109);
            this.grid.MainView = this.tablo;
            this.grid.MenuManager = this.ribbonControl;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1108, 253);
            this.grid.TabIndex = 3;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo});
            // 
            // tablo
            // 
            this.tablo.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.BandPanel.ForeColor = System.Drawing.Color.DarkBlue;
            this.tablo.Appearance.BandPanel.Options.UseFont = true;
            this.tablo.Appearance.BandPanel.Options.UseForeColor = true;
            this.tablo.Appearance.BandPanel.Options.UseTextOptions = true;
            this.tablo.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.FooterPanel.Options.UseFont = true;
            this.tablo.Appearance.FooterPanel.Options.UseForeColor = true;
            this.tablo.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tablo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tablo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.ViewCaption.Options.UseForeColor = true;
            this.tablo.BandPanelRowHeight = 40;
            this.tablo.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3});
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colId,
            this.colKod,
            this.colCariAdi,
            this.colTcKimlikNo,
            this.colTelefon1,
            this.colTelefon2,
            this.colTelefon3,
            this.colTelefon4,
            this.colFaks,
            this.colWeb,
            this.colEmail,
            this.colVergiDairesi,
            this.colVergiNo,
            this.colAdres,
            this.colOzelKod1Adi,
            this.colOzelKod2Adi,
            this.colAciklama});
            this.tablo.GridControl = this.grid;
            this.tablo.Name = "tablo";
            this.tablo.OptionsMenu.EnableColumnMenu = false;
            this.tablo.OptionsMenu.EnableFooterMenu = false;
            this.tablo.OptionsMenu.EnableGroupPanelMenu = false;
            this.tablo.OptionsNavigation.EnterMoveNextColumn = true;
            this.tablo.OptionsPrint.AutoWidth = false;
            this.tablo.OptionsPrint.PrintFooter = false;
            this.tablo.OptionsPrint.PrintGroupFooter = false;
            this.tablo.OptionsView.ColumnAutoWidth = false;
            this.tablo.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.tablo.OptionsView.RowAutoHeight = true;
            this.tablo.OptionsView.ShowAutoFilterRow = true;
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.StatusBarAciklama = null;
            this.tablo.StatusBarKisayol = null;
            this.tablo.StatusBarKisayolAciklama = null;
            this.tablo.ViewCaption = "Cari Kartları";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Cari Bilgiler";
            this.gridBand1.Columns.Add(this.colKod);
            this.gridBand1.Columns.Add(this.colTcKimlikNo);
            this.gridBand1.Columns.Add(this.colCariAdi);
            this.gridBand1.Columns.Add(this.colTelefon1);
            this.gridBand1.Columns.Add(this.colTelefon2);
            this.gridBand1.Columns.Add(this.colTelefon3);
            this.gridBand1.Columns.Add(this.colTelefon4);
            this.gridBand1.Columns.Add(this.colFaks);
            this.gridBand1.Columns.Add(this.colWeb);
            this.gridBand1.Columns.Add(this.colEmail);
            this.gridBand1.Columns.Add(this.colAdres);
            this.gridBand1.Columns.Add(this.colVergiDairesi);
            this.gridBand1.Columns.Add(this.colVergiNo);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 700;
            // 
            // colKod
            // 
            this.colKod.AppearanceCell.Options.UseTextOptions = true;
            this.colKod.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKod.Caption = "Kod";
            this.colKod.FieldName = "Kod";
            this.colKod.Name = "colKod";
            this.colKod.OptionsColumn.AllowEdit = false;
            this.colKod.StatusBarAciklama = null;
            this.colKod.StatusBarKisayol = null;
            this.colKod.StatusBarKisayolAciklama = null;
            this.colKod.Visible = true;
            this.colKod.Width = 150;
            // 
            // colTcKimlikNo
            // 
            this.colTcKimlikNo.AppearanceCell.Options.UseTextOptions = true;
            this.colTcKimlikNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTcKimlikNo.Caption = "TC Kimlik No";
            this.colTcKimlikNo.FieldName = "TcKimlikNo";
            this.colTcKimlikNo.Name = "colTcKimlikNo";
            this.colTcKimlikNo.OptionsColumn.AllowEdit = false;
            this.colTcKimlikNo.StatusBarAciklama = null;
            this.colTcKimlikNo.StatusBarKisayol = null;
            this.colTcKimlikNo.StatusBarKisayolAciklama = null;
            this.colTcKimlikNo.Visible = true;
            this.colTcKimlikNo.Width = 100;
            // 
            // colCariAdi
            // 
            this.colCariAdi.Caption = "Cari Adı";
            this.colCariAdi.FieldName = "CariAdi";
            this.colCariAdi.Name = "colCariAdi";
            this.colCariAdi.OptionsColumn.AllowEdit = false;
            this.colCariAdi.StatusBarAciklama = null;
            this.colCariAdi.StatusBarKisayol = null;
            this.colCariAdi.StatusBarKisayolAciklama = null;
            this.colCariAdi.Visible = true;
            this.colCariAdi.Width = 250;
            // 
            // colTelefon1
            // 
            this.colTelefon1.AppearanceCell.Options.UseTextOptions = true;
            this.colTelefon1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTelefon1.Caption = "Telefon 1";
            this.colTelefon1.FieldName = "Telefon1";
            this.colTelefon1.Name = "colTelefon1";
            this.colTelefon1.OptionsColumn.AllowEdit = false;
            this.colTelefon1.StatusBarAciklama = null;
            this.colTelefon1.StatusBarKisayol = null;
            this.colTelefon1.StatusBarKisayolAciklama = null;
            this.colTelefon1.Visible = true;
            this.colTelefon1.Width = 100;
            // 
            // colTelefon2
            // 
            this.colTelefon2.AppearanceCell.Options.UseTextOptions = true;
            this.colTelefon2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTelefon2.Caption = "Telefon 2";
            this.colTelefon2.FieldName = "Telefon2";
            this.colTelefon2.Name = "colTelefon2";
            this.colTelefon2.OptionsColumn.AllowEdit = false;
            this.colTelefon2.StatusBarAciklama = null;
            this.colTelefon2.StatusBarKisayol = null;
            this.colTelefon2.StatusBarKisayolAciklama = null;
            this.colTelefon2.Visible = true;
            this.colTelefon2.Width = 100;
            // 
            // colTelefon3
            // 
            this.colTelefon3.AppearanceCell.Options.UseTextOptions = true;
            this.colTelefon3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTelefon3.Caption = "Telefon 3";
            this.colTelefon3.FieldName = "Telefon3";
            this.colTelefon3.Name = "colTelefon3";
            this.colTelefon3.OptionsColumn.AllowEdit = false;
            this.colTelefon3.StatusBarAciklama = null;
            this.colTelefon3.StatusBarKisayol = null;
            this.colTelefon3.StatusBarKisayolAciklama = null;
            this.colTelefon3.Width = 100;
            // 
            // colTelefon4
            // 
            this.colTelefon4.AppearanceCell.Options.UseTextOptions = true;
            this.colTelefon4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTelefon4.Caption = "Telefon 4";
            this.colTelefon4.FieldName = "Telefon4";
            this.colTelefon4.Name = "colTelefon4";
            this.colTelefon4.OptionsColumn.AllowEdit = false;
            this.colTelefon4.StatusBarAciklama = null;
            this.colTelefon4.StatusBarKisayol = null;
            this.colTelefon4.StatusBarKisayolAciklama = null;
            this.colTelefon4.Width = 100;
            // 
            // colFaks
            // 
            this.colFaks.AppearanceCell.Options.UseTextOptions = true;
            this.colFaks.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFaks.Caption = "Faks";
            this.colFaks.FieldName = "Faks";
            this.colFaks.Name = "colFaks";
            this.colFaks.OptionsColumn.AllowEdit = false;
            this.colFaks.StatusBarAciklama = null;
            this.colFaks.StatusBarKisayol = null;
            this.colFaks.StatusBarKisayolAciklama = null;
            this.colFaks.Width = 100;
            // 
            // colWeb
            // 
            this.colWeb.Caption = "Web";
            this.colWeb.FieldName = "Web";
            this.colWeb.Name = "colWeb";
            this.colWeb.OptionsColumn.AllowEdit = false;
            this.colWeb.StatusBarAciklama = null;
            this.colWeb.StatusBarKisayol = null;
            this.colWeb.StatusBarKisayolAciklama = null;
            this.colWeb.Width = 130;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "E-mail";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.OptionsColumn.AllowEdit = false;
            this.colEmail.StatusBarAciklama = null;
            this.colEmail.StatusBarKisayol = null;
            this.colEmail.StatusBarKisayolAciklama = null;
            this.colEmail.Width = 130;
            // 
            // colAdres
            // 
            this.colAdres.Caption = "Adres";
            this.colAdres.FieldName = "Adres";
            this.colAdres.Name = "colAdres";
            this.colAdres.OptionsColumn.AllowEdit = false;
            this.colAdres.StatusBarAciklama = null;
            this.colAdres.StatusBarKisayol = null;
            this.colAdres.StatusBarKisayolAciklama = null;
            this.colAdres.Width = 300;
            // 
            // colVergiDairesi
            // 
            this.colVergiDairesi.Caption = "Vergi Dairesi";
            this.colVergiDairesi.FieldName = "Vergi Dairesi";
            this.colVergiDairesi.Name = "colVergiDairesi";
            this.colVergiDairesi.OptionsColumn.AllowEdit = false;
            this.colVergiDairesi.StatusBarAciklama = null;
            this.colVergiDairesi.StatusBarKisayol = null;
            this.colVergiDairesi.StatusBarKisayolAciklama = null;
            this.colVergiDairesi.Width = 120;
            // 
            // colVergiNo
            // 
            this.colVergiNo.Caption = "Vergi No";
            this.colVergiNo.FieldName = "VergiNo";
            this.colVergiNo.Name = "colVergiNo";
            this.colVergiNo.OptionsColumn.AllowEdit = false;
            this.colVergiNo.StatusBarAciklama = null;
            this.colVergiNo.StatusBarKisayol = null;
            this.colVergiNo.StatusBarKisayolAciklama = null;
            this.colVergiNo.Width = 120;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Özel Kod";
            this.gridBand2.Columns.Add(this.colOzelKod1Adi);
            this.gridBand2.Columns.Add(this.colOzelKod2Adi);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 200;
            // 
            // colOzelKod1Adi
            // 
            this.colOzelKod1Adi.Caption = "Özel Kod 1";
            this.colOzelKod1Adi.FieldName = "OzelKod1Adi";
            this.colOzelKod1Adi.Name = "colOzelKod1Adi";
            this.colOzelKod1Adi.OptionsColumn.AllowEdit = false;
            this.colOzelKod1Adi.StatusBarAciklama = null;
            this.colOzelKod1Adi.StatusBarKisayol = null;
            this.colOzelKod1Adi.StatusBarKisayolAciklama = null;
            this.colOzelKod1Adi.Visible = true;
            this.colOzelKod1Adi.Width = 100;
            // 
            // colOzelKod2Adi
            // 
            this.colOzelKod2Adi.Caption = "Özel Kod 2";
            this.colOzelKod2Adi.FieldName = "OzelKod2Adi";
            this.colOzelKod2Adi.Name = "colOzelKod2Adi";
            this.colOzelKod2Adi.OptionsColumn.AllowEdit = false;
            this.colOzelKod2Adi.StatusBarAciklama = null;
            this.colOzelKod2Adi.StatusBarKisayol = null;
            this.colOzelKod2Adi.StatusBarKisayolAciklama = null;
            this.colOzelKod2Adi.Visible = true;
            this.colOzelKod2Adi.Width = 100;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Ek Bilgiler";
            this.gridBand3.Columns.Add(this.colAciklama);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 300;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowEdit = false;
            this.colAciklama.StatusBarAciklama = null;
            this.colAciklama.StatusBarKisayol = null;
            this.colAciklama.StatusBarKisayolAciklama = null;
            this.colAciklama.Visible = true;
            this.colAciklama.Width = 300;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            this.colId.StatusBarAciklama = null;
            this.colId.StatusBarKisayol = null;
            this.colId.StatusBarKisayolAciklama = null;
            // 
            // CariListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 410);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.longNavigator);
            this.IconOptions.ShowIcon = false;
            this.Name = "CariListForm";
            this.Text = "Cari Kartları";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.longNavigator, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Navigators.LongNavigator longNavigator;
        private UserControls.Grid.MyBandedGridControl grid;
        private UserControls.Grid.MyBandedGridView tablo;
        private UserControls.Grid.MyBandedGridColumn colId;
        private UserControls.Grid.MyBandedGridColumn colKod;
        private UserControls.Grid.MyBandedGridColumn colCariAdi;
        private UserControls.Grid.MyBandedGridColumn colTcKimlikNo;
        private UserControls.Grid.MyBandedGridColumn colTelefon1;
        private UserControls.Grid.MyBandedGridColumn colTelefon2;
        private UserControls.Grid.MyBandedGridColumn colTelefon3;
        private UserControls.Grid.MyBandedGridColumn colTelefon4;
        private UserControls.Grid.MyBandedGridColumn colFaks;
        private UserControls.Grid.MyBandedGridColumn colWeb;
        private UserControls.Grid.MyBandedGridColumn colEmail;
        private UserControls.Grid.MyBandedGridColumn colVergiDairesi;
        private UserControls.Grid.MyBandedGridColumn colVergiNo;
        private UserControls.Grid.MyBandedGridColumn colAdres;
        private UserControls.Grid.MyBandedGridColumn colOzelKod1Adi;
        private UserControls.Grid.MyBandedGridColumn colOzelKod2Adi;
        private UserControls.Grid.MyBandedGridColumn colAciklama;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
    }
}