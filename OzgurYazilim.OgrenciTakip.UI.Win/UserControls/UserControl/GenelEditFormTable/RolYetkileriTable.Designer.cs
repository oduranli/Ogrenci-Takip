﻿namespace OzgurYazilim.OgrenciTakip.UI.Win.UserControls.UserControl.GenelEditFormTable
{
    partial class RolYetkileriTable
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
            this.myGridControl = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridControl();
            this.tablo = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridView();
            this.colId = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colKartTuru = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colGorebilir = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colEkleyebilir = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colDegistirebilir = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colSilebilir = new OzgurYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // insUptNavigator
            // 
            this.insUptNavigator.Location = new System.Drawing.Point(0, 513);
            this.insUptNavigator.Size = new System.Drawing.Size(832, 24);
            // 
            // myGridControl
            // 
            this.myGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGridControl.Location = new System.Drawing.Point(0, 0);
            this.myGridControl.MainView = this.tablo;
            this.myGridControl.Name = "myGridControl";
            this.myGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryCheck});
            this.myGridControl.Size = new System.Drawing.Size(832, 513);
            this.myGridControl.TabIndex = 5;
            this.myGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.colId,
            this.colKartTuru,
            this.colGorebilir,
            this.colEkleyebilir,
            this.colDegistirebilir,
            this.colSilebilir});
            this.tablo.GridControl = this.myGridControl;
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
            this.tablo.StatusBarAciklama = "Rol yetki kartları";
            this.tablo.StatusBarKisayol = "Shift + Insert : ";
            this.tablo.StatusBarKisayolAciklama = "Yetki kartı ekle";
            this.tablo.ViewCaption = "Rol Yetkileri";
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
            // colKartTuru
            // 
            this.colKartTuru.Caption = "Kart Türü";
            this.colKartTuru.FieldName = "KartTuru";
            this.colKartTuru.Name = "colKartTuru";
            this.colKartTuru.OptionsColumn.AllowEdit = false;
            this.colKartTuru.OptionsFilter.AllowAutoFilter = false;
            this.colKartTuru.OptionsFilter.AllowFilter = false;
            this.colKartTuru.StatusBarAciklama = null;
            this.colKartTuru.StatusBarKisayol = null;
            this.colKartTuru.StatusBarKisayolAciklama = null;
            this.colKartTuru.Visible = true;
            this.colKartTuru.VisibleIndex = 0;
            this.colKartTuru.Width = 359;
            // 
            // colGorebilir
            // 
            this.colGorebilir.Caption = "Görebilir";
            this.colGorebilir.ColumnEdit = this.repositoryCheck;
            this.colGorebilir.FieldName = "Gorebilir";
            this.colGorebilir.Name = "colGorebilir";
            this.colGorebilir.OptionsFilter.AllowAutoFilter = false;
            this.colGorebilir.OptionsFilter.AllowFilter = false;
            this.colGorebilir.StatusBarAciklama = null;
            this.colGorebilir.StatusBarKisayol = null;
            this.colGorebilir.StatusBarKisayolAciklama = null;
            this.colGorebilir.Visible = true;
            this.colGorebilir.VisibleIndex = 1;
            this.colGorebilir.Width = 70;
            // 
            // repositoryCheck
            // 
            this.repositoryCheck.AutoHeight = false;
            this.repositoryCheck.Name = "repositoryCheck";
            this.repositoryCheck.ValueChecked = ((byte)(1));
            this.repositoryCheck.ValueGrayed = ((byte)(2));
            this.repositoryCheck.ValueUnchecked = ((byte)(0));
            // 
            // colEkleyebilir
            // 
            this.colEkleyebilir.Caption = "Ekleyebilir";
            this.colEkleyebilir.ColumnEdit = this.repositoryCheck;
            this.colEkleyebilir.FieldName = "Ekleyebilir";
            this.colEkleyebilir.Name = "colEkleyebilir";
            this.colEkleyebilir.OptionsFilter.AllowAutoFilter = false;
            this.colEkleyebilir.OptionsFilter.AllowFilter = false;
            this.colEkleyebilir.StatusBarAciklama = null;
            this.colEkleyebilir.StatusBarKisayol = null;
            this.colEkleyebilir.StatusBarKisayolAciklama = null;
            this.colEkleyebilir.Visible = true;
            this.colEkleyebilir.VisibleIndex = 2;
            this.colEkleyebilir.Width = 70;
            // 
            // colDegistirebilir
            // 
            this.colDegistirebilir.Caption = "Değiştirebilir";
            this.colDegistirebilir.ColumnEdit = this.repositoryCheck;
            this.colDegistirebilir.FieldName = "Degistirebilir";
            this.colDegistirebilir.Name = "colDegistirebilir";
            this.colDegistirebilir.OptionsFilter.AllowAutoFilter = false;
            this.colDegistirebilir.OptionsFilter.AllowFilter = false;
            this.colDegistirebilir.StatusBarAciklama = null;
            this.colDegistirebilir.StatusBarKisayol = null;
            this.colDegistirebilir.StatusBarKisayolAciklama = null;
            this.colDegistirebilir.Visible = true;
            this.colDegistirebilir.VisibleIndex = 3;
            this.colDegistirebilir.Width = 70;
            // 
            // colSilebilir
            // 
            this.colSilebilir.Caption = "Silebilir";
            this.colSilebilir.ColumnEdit = this.repositoryCheck;
            this.colSilebilir.FieldName = "Silebilir";
            this.colSilebilir.Name = "colSilebilir";
            this.colSilebilir.OptionsFilter.AllowAutoFilter = false;
            this.colSilebilir.OptionsFilter.AllowFilter = false;
            this.colSilebilir.StatusBarAciklama = null;
            this.colSilebilir.StatusBarKisayol = null;
            this.colSilebilir.StatusBarKisayolAciklama = null;
            this.colSilebilir.Visible = true;
            this.colSilebilir.VisibleIndex = 4;
            this.colSilebilir.Width = 70;
            // 
            // RolYetkileriTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myGridControl);
            this.Name = "RolYetkileriTable";
            this.Size = new System.Drawing.Size(832, 537);
            this.Controls.SetChildIndex(this.insUptNavigator, 0);
            this.Controls.SetChildIndex(this.myGridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grid.MyGridControl myGridControl;
        private Grid.MyGridView tablo;
        private Grid.MyGridColumn colId;
        private Grid.MyGridColumn colKartTuru;
        private Grid.MyGridColumn colGorebilir;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryCheck;
        private Grid.MyGridColumn colEkleyebilir;
        private Grid.MyGridColumn colDegistirebilir;
        private Grid.MyGridColumn colSilebilir;
    }
}
