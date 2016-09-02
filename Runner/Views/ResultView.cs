using System.Collections.Generic;
using Benchmark.Runner;
using Benchmark.Win.ViewModels;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace Benchmark.Win.Views {
    public class ResultView : DocumentView {
        public ResultView() {
            InitializeComponent();
            InitializeContext<ResultViewModel>();
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            var fluentAPI = GetFluentAPI<ResultViewModel>();
            fluentAPI.SetBinding(pivotGridControl, x => x.DataSource, y => y.Source);
            Messenger.Default.Register<RequeryResults>(this, Context.GetViewModel<ResultViewModel>().OnResultsChanged);
        }
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            Messenger.Default.Unregister<RequeryResults>(this, Context.GetViewModel<ResultViewModel>().OnResultsChanged);
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        System.ComponentModel.IContainer components = null;
        void InitializeComponent() {
            this.pivotGridControl = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.venderField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.productField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.badField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.categoryField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.testField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.medianField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.bestField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.firstField = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGridControl
            // 
            this.pivotGridControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pivotGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.venderField,
            this.productField,
            this.badField,
            this.categoryField,
            this.testField,
            this.medianField,
            this.bestField,
            this.firstField});
            this.pivotGridControl.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl.Name = "pivotGridControl";
            this.pivotGridControl.OptionsView.ShowColumnGrandTotalHeader = false;
            this.pivotGridControl.OptionsView.ShowColumnGrandTotals = false;
            this.pivotGridControl.OptionsView.ShowColumnTotals = false;
            this.pivotGridControl.OptionsView.ShowRowGrandTotalHeader = false;
            this.pivotGridControl.OptionsView.ShowRowGrandTotals = false;
            this.pivotGridControl.OptionsView.ShowRowTotals = false;
            this.pivotGridControl.Size = new System.Drawing.Size(647, 419);
            this.pivotGridControl.TabIndex = 1;
            // 
            // venderField
            // 
            this.venderField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.venderField.AreaIndex = 0;
            this.venderField.FieldName = "Vender";
            this.venderField.Name = "venderField";
            // 
            // productField
            // 
            this.productField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.productField.AreaIndex = 0;
            this.productField.FieldName = "Product";
            this.productField.Name = "productField";
            // 
            // badField
            // 
            this.badField.AreaIndex = 0;
            this.badField.FieldName = "BadPerfomance";
            this.badField.Name = "badField";
            // 
            // categoryField
            // 
            this.categoryField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.categoryField.AreaIndex = 1;
            this.categoryField.FieldName = "Category";
            this.categoryField.Name = "categoryField";
            // 
            // testField
            // 
            this.testField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.testField.AreaIndex = 2;
            this.testField.FieldName = "TestName";
            this.testField.Name = "testField";
            // 
            // medianField
            // 
            this.medianField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.medianField.AreaIndex = 0;
            this.medianField.FieldName = "MedianPerfomance";
            this.medianField.Name = "medianField";
            // 
            // bestField
            // 
            this.bestField.AreaIndex = 1;
            this.bestField.FieldName = "BestPerfomance";
            this.bestField.Name = "bestField";
            // 
            // firstField
            // 
            this.firstField.AreaIndex = 2;
            this.firstField.FieldName = "FirstPerfomance";
            this.firstField.Name = "firstField";
            // 
            // ResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pivotGridControl);
            this.Name = "ResultView";
            this.Size = new System.Drawing.Size(647, 419);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).EndInit();
            this.ResumeLayout(false);

        }
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl;
        private DevExpress.XtraPivotGrid.PivotGridField venderField;
        private DevExpress.XtraPivotGrid.PivotGridField productField;
        private DevExpress.XtraPivotGrid.PivotGridField badField;
        private DevExpress.XtraPivotGrid.PivotGridField categoryField;
        private DevExpress.XtraPivotGrid.PivotGridField testField;
        private DevExpress.XtraPivotGrid.PivotGridField medianField;
        private DevExpress.XtraPivotGrid.PivotGridField bestField;
        private DevExpress.XtraPivotGrid.PivotGridField firstField;
        #endregion
    }
}