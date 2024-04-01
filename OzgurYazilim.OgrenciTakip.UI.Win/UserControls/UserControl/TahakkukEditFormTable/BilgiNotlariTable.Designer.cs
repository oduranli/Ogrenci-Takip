﻿namespace OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.TahakkukEditFormTable
{
    partial class BilgiNotlariTable
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
            this.colTarih = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colBilgiNotu = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryNot = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryNot)).BeginInit();
            this.SuspendLayout();
            // 
            // insUptNavigator
            // 
            this.insUptNavigator.Location = new System.Drawing.Point(0, 345);
            this.insUptNavigator.Size = new System.Drawing.Size(645, 24);
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.tablo;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryDate,
            this.repositoryNot});
            this.grid.Size = new System.Drawing.Size(645, 345);
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
            this.colTarih,
            this.colBilgiNotu});
            this.tablo.GridControl = this.grid;
            this.tablo.Name = "tablo";
            this.tablo.OptionsMenu.EnableColumnMenu = false;
            this.tablo.OptionsMenu.EnableFooterMenu = false;
            this.tablo.OptionsMenu.EnableGroupPanelMenu = false;
            this.tablo.OptionsNavigation.EnterMoveNextColumn = true;
            this.tablo.OptionsPrint.AutoWidth = false;
            this.tablo.OptionsPrint.PrintFooter = false;
            this.tablo.OptionsPrint.PrintGroupFooter = false;
            this.tablo.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.tablo.OptionsView.RowAutoHeight = true;
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.StatusBarAciklama = "Bilgi notu giriniz.";
            this.tablo.StatusBarKisayol = "Shift + Insert : ";
            this.tablo.StatusBarKisayolAciklama = "Bilgi notu ekle";
            this.tablo.ViewCaption = "Bilgi Notları";
            // 
            // colTarih
            // 
            this.colTarih.AppearanceCell.Options.UseTextOptions = true;
            this.colTarih.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarih.Caption = "Tarih";
            this.colTarih.ColumnEdit = this.repositoryDate;
            this.colTarih.FieldName = "Tarih";
            this.colTarih.Name = "colTarih";
            this.colTarih.OptionsColumn.FixedWidth = true;
            this.colTarih.OptionsFilter.AllowAutoFilter = false;
            this.colTarih.OptionsFilter.AllowFilter = false;
            this.colTarih.StatusBarAciklama = "Tarih giriniz.";
            this.colTarih.StatusBarKisayol = "F4 : ";
            this.colTarih.StatusBarKisayolAciklama = "Tarih seç";
            this.colTarih.Visible = true;
            this.colTarih.VisibleIndex = 0;
            this.colTarih.Width = 150;
            // 
            // repositoryDate
            // 
            this.repositoryDate.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.repositoryDate.AutoHeight = false;
            this.repositoryDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryDate.DisplayFormat.FormatString = "G";
            this.repositoryDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryDate.EditFormat.FormatString = "G";
            this.repositoryDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryDate.Mask.EditMask = "G";
            this.repositoryDate.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.repositoryDate.Name = "repositoryDate";
            // 
            // colBilgiNotu
            // 
            this.colBilgiNotu.Caption = "Not";
            this.colBilgiNotu.ColumnEdit = this.repositoryNot;
            this.colBilgiNotu.FieldName = "BilgiNotu";
            this.colBilgiNotu.Name = "colBilgiNotu";
            this.colBilgiNotu.OptionsFilter.AllowAutoFilter = false;
            this.colBilgiNotu.OptionsFilter.AllowFilter = false;
            this.colBilgiNotu.StatusBarAciklama = "Not giriniz.";
            this.colBilgiNotu.StatusBarKisayol = null;
            this.colBilgiNotu.StatusBarKisayolAciklama = null;
            this.colBilgiNotu.Visible = true;
            this.colBilgiNotu.VisibleIndex = 1;
            this.colBilgiNotu.Width = 470;
            // 
            // repositoryNot
            // 
            this.repositoryNot.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.repositoryNot.Name = "repositoryNot";
            this.repositoryNot.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            // 
            // BilgiNotlariTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Name = "BilgiNotlariTable";
            this.Size = new System.Drawing.Size(645, 369);
            this.Controls.SetChildIndex(this.insUptNavigator, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryNot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grid.MyGridControl grid;
        private Grid.MyGridView tablo;
        private Grid.MyGridColumn colTarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryDate;
        private Grid.MyGridColumn colBilgiNotu;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryNot;
    }
}
