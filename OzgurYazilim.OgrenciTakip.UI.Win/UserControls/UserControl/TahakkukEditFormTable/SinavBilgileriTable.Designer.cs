﻿namespace OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.TahakkukEditFormTable
{
    partial class SinavBilgileriTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grid = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridControl();
            this.tablo = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridView();
            this.colSinavAdi = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colTarih = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colPuanTuru = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colPuan = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryPuan = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colSira = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositorySira = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colYuzde = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryYuzde = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryPuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorySira)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryYuzde)).BeginInit();
            this.SuspendLayout();
            // 
            // insUptNavigator
            // 
            this.insUptNavigator.Location = new System.Drawing.Point(0, 397);
            this.insUptNavigator.Size = new System.Drawing.Size(720, 24);
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.tablo;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryDate,
            this.repositorySira,
            this.repositoryPuan,
            this.repositoryYuzde});
            this.grid.Size = new System.Drawing.Size(720, 397);
            this.grid.TabIndex = 5;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo});
            // 
            // tablo
            // 
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
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSinavAdi,
            this.colTarih,
            this.colPuanTuru,
            this.colPuan,
            this.colSira,
            this.colYuzde});
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
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.StatusBarAciklama = "Sınav bilgisi ekleyiniz.";
            this.tablo.StatusBarKisayol = "Shift + Insert : ";
            this.tablo.StatusBarKisayolAciklama = "Sınav bilgisi ekle";
            this.tablo.ViewCaption = "Sınav Bilgileri";
            // 
            // colSinavAdi
            // 
            this.colSinavAdi.Caption = "Sınav Adı";
            this.colSinavAdi.FieldName = "SinavAdi";
            this.colSinavAdi.Name = "colSinavAdi";
            this.colSinavAdi.StatusBarAciklama = "Sınav adı giriniz.";
            this.colSinavAdi.StatusBarKisayol = null;
            this.colSinavAdi.StatusBarKisayolAciklama = null;
            this.colSinavAdi.Visible = true;
            this.colSinavAdi.VisibleIndex = 0;
            this.colSinavAdi.Width = 148;
            // 
            // colTarih
            // 
            this.colTarih.AppearanceCell.Options.UseTextOptions = true;
            this.colTarih.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarih.Caption = "Tarih";
            this.colTarih.ColumnEdit = this.repositoryDate;
            this.colTarih.FieldName = "Tarih";
            this.colTarih.Name = "colTarih";
            this.colTarih.StatusBarAciklama = "Tarih giriniz.";
            this.colTarih.StatusBarKisayol = "F4 : ";
            this.colTarih.StatusBarKisayolAciklama = "Tarih seç";
            this.colTarih.Visible = true;
            this.colTarih.VisibleIndex = 1;
            this.colTarih.Width = 100;
            // 
            // repositoryDate
            // 
            this.repositoryDate.AutoHeight = false;
            this.repositoryDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryDate.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.repositoryDate.Name = "repositoryDate";
            // 
            // colPuanTuru
            // 
            this.colPuanTuru.Caption = "Puan Türü";
            this.colPuanTuru.FieldName = "PuanTuru";
            this.colPuanTuru.Name = "colPuanTuru";
            this.colPuanTuru.StatusBarAciklama = "Puan türü giriniz.";
            this.colPuanTuru.StatusBarKisayol = null;
            this.colPuanTuru.StatusBarKisayolAciklama = null;
            this.colPuanTuru.Visible = true;
            this.colPuanTuru.VisibleIndex = 2;
            this.colPuanTuru.Width = 100;
            // 
            // colPuan
            // 
            this.colPuan.Caption = "Puan";
            this.colPuan.ColumnEdit = this.repositoryPuan;
            this.colPuan.FieldName = "Puan";
            this.colPuan.Name = "colPuan";
            this.colPuan.StatusBarAciklama = "Puan giriniz.";
            this.colPuan.StatusBarKisayol = null;
            this.colPuan.StatusBarKisayolAciklama = null;
            this.colPuan.Visible = true;
            this.colPuan.VisibleIndex = 3;
            this.colPuan.Width = 100;
            // 
            // repositoryPuan
            // 
            this.repositoryPuan.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.repositoryPuan.AutoHeight = false;
            this.repositoryPuan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryPuan.DisplayFormat.FormatString = "n5";
            this.repositoryPuan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryPuan.EditFormat.FormatString = "n5";
            this.repositoryPuan.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryPuan.Mask.EditMask = "n5";
            this.repositoryPuan.MaxValue = new decimal(new int[] {
            99999999,
            0,
            0,
            327680});
            this.repositoryPuan.Name = "repositoryPuan";
            // 
            // colSira
            // 
            this.colSira.Caption = "Sıra";
            this.colSira.ColumnEdit = this.repositorySira;
            this.colSira.FieldName = "Sira";
            this.colSira.Name = "colSira";
            this.colSira.StatusBarAciklama = "Sınav sırasını giriniz.";
            this.colSira.StatusBarKisayol = null;
            this.colSira.StatusBarKisayolAciklama = null;
            this.colSira.Visible = true;
            this.colSira.VisibleIndex = 4;
            this.colSira.Width = 100;
            // 
            // repositorySira
            // 
            this.repositorySira.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.repositorySira.AutoHeight = false;
            this.repositorySira.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositorySira.DisplayFormat.FormatString = "n0";
            this.repositorySira.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositorySira.EditFormat.FormatString = "n0";
            this.repositorySira.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositorySira.Mask.EditMask = "n0";
            this.repositorySira.Name = "repositorySira";
            // 
            // colYuzde
            // 
            this.colYuzde.Caption = "Derece ( % )";
            this.colYuzde.ColumnEdit = this.repositoryYuzde;
            this.colYuzde.FieldName = "Yuzde";
            this.colYuzde.Name = "colYuzde";
            this.colYuzde.StatusBarAciklama = "Sınav yüzde dilimini giriniz.";
            this.colYuzde.StatusBarKisayol = null;
            this.colYuzde.StatusBarKisayolAciklama = null;
            this.colYuzde.Visible = true;
            this.colYuzde.VisibleIndex = 5;
            this.colYuzde.Width = 100;
            // 
            // repositoryYuzde
            // 
            this.repositoryYuzde.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.repositoryYuzde.AutoHeight = false;
            this.repositoryYuzde.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryYuzde.DisplayFormat.FormatString = "n4";
            this.repositoryYuzde.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryYuzde.EditFormat.FormatString = "n4";
            this.repositoryYuzde.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryYuzde.Mask.EditMask = "n4";
            this.repositoryYuzde.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.repositoryYuzde.Name = "repositoryYuzde";
            // 
            // SinavBilgileriTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Name = "SinavBilgileriTable";
            this.Size = new System.Drawing.Size(720, 421);
            this.Controls.SetChildIndex(this.insUptNavigator, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryPuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorySira)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryYuzde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grid.MyGridControl grid;
        private Grid.MyGridView tablo;
        private Grid.MyGridColumn colSinavAdi;
        private Grid.MyGridColumn colTarih;
        private Grid.MyGridColumn colPuanTuru;
        private Grid.MyGridColumn colPuan;
        private Grid.MyGridColumn colSira;
        private Grid.MyGridColumn colYuzde;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryPuan;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositorySira;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryYuzde;
    }
}
