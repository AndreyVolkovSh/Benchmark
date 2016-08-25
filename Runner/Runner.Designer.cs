namespace Benchmark.Win {
    partial class Runner {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.settingsTab = new DevExpress.XtraTab.XtraTabPage();
            this.tabPane = new DevExpress.XtraBars.Navigation.TabPane();
            this.settingsTabPage = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.toolVersionLabel = new DevExpress.XtraEditors.LabelControl();
            this.frameworkLabel = new DevExpress.XtraEditors.LabelControl();
            this.platformLabel = new DevExpress.XtraEditors.LabelControl();
            this.platformComboBox = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.frameworkLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.toolVersionLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.enableNGen = new DevExpress.XtraEditors.CheckEdit();
            this.buildSolutions = new DevExpress.XtraEditors.SimpleButton();
            this.addProductTabPage = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.addVenderTabPage = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.testsTab = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.reset = new DevExpress.XtraEditors.SimpleButton();
            this.addAssembly = new DevExpress.XtraEditors.SimpleButton();
            this.startButton = new DevExpress.XtraEditors.SimpleButton();
            this.productsTreeList = new Benchmark.Win.ProductTreeList();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.productsItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.startItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.addAssemblyItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.resetItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.resultsTab = new DevExpress.XtraTab.XtraTabPage();
            this.pivotGridControl = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.venderField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.productField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.badField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.categoryField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.testField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.medianField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.bestField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.firstField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
            this.xtraTabControl.SuspendLayout();
            this.settingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane)).BeginInit();
            this.tabPane.SuspendLayout();
            this.settingsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.platformComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameworkLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolVersionLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableNGen.Properties)).BeginInit();
            this.testsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productsTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addAssemblyItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resetItem)).BeginInit();
            this.resultsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl
            // 
            this.xtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.xtraTabControl.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.xtraTabControl.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl.Name = "xtraTabControl";
            this.xtraTabControl.SelectedTabPage = this.settingsTab;
            this.xtraTabControl.Size = new System.Drawing.Size(768, 459);
            this.xtraTabControl.TabIndex = 9;
            this.xtraTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.settingsTab,
            this.testsTab,
            this.resultsTab});
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.tabPane);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Size = new System.Drawing.Size(709, 453);
            this.settingsTab.Text = "Settings";
            // 
            // tabPane
            // 
            this.tabPane.Controls.Add(this.settingsTabPage);
            this.tabPane.Controls.Add(this.addProductTabPage);
            this.tabPane.Controls.Add(this.addVenderTabPage);
            this.tabPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane.Location = new System.Drawing.Point(0, 0);
            this.tabPane.Name = "tabPane";
            this.tabPane.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.settingsTabPage,
            this.addProductTabPage,
            this.addVenderTabPage});
            this.tabPane.RegularSize = new System.Drawing.Size(709, 453);
            this.tabPane.SelectedPage = this.settingsTabPage;
            this.tabPane.Size = new System.Drawing.Size(709, 453);
            this.tabPane.TabIndex = 11;
            this.tabPane.Text = "tabPane";
            // 
            // settingsTabPage
            // 
            this.settingsTabPage.Caption = "Settings";
            this.settingsTabPage.Controls.Add(this.toolVersionLabel);
            this.settingsTabPage.Controls.Add(this.frameworkLabel);
            this.settingsTabPage.Controls.Add(this.platformLabel);
            this.settingsTabPage.Controls.Add(this.platformComboBox);
            this.settingsTabPage.Controls.Add(this.frameworkLookUp);
            this.settingsTabPage.Controls.Add(this.toolVersionLookUp);
            this.settingsTabPage.Controls.Add(this.enableNGen);
            this.settingsTabPage.Controls.Add(this.buildSolutions);
            this.settingsTabPage.Name = "settingsTabPage";
            this.settingsTabPage.Size = new System.Drawing.Size(691, 408);
            // 
            // toolVersionLabel
            // 
            this.toolVersionLabel.Location = new System.Drawing.Point(40, 79);
            this.toolVersionLabel.Name = "toolVersionLabel";
            this.toolVersionLabel.Size = new System.Drawing.Size(62, 13);
            this.toolVersionLabel.TabIndex = 17;
            this.toolVersionLabel.Text = "Tool version:";
            // 
            // frameworkLabel
            // 
            this.frameworkLabel.Location = new System.Drawing.Point(40, 53);
            this.frameworkLabel.Name = "frameworkLabel";
            this.frameworkLabel.Size = new System.Drawing.Size(57, 13);
            this.frameworkLabel.TabIndex = 16;
            this.frameworkLabel.Text = "Framework:";
            // 
            // platformLabel
            // 
            this.platformLabel.Location = new System.Drawing.Point(40, 27);
            this.platformLabel.Name = "platformLabel";
            this.platformLabel.Size = new System.Drawing.Size(44, 13);
            this.platformLabel.TabIndex = 15;
            this.platformLabel.Text = "Platform:";
            // 
            // platformComboBox
            // 
            this.platformComboBox.Location = new System.Drawing.Point(176, 24);
            this.platformComboBox.Name = "platformComboBox";
            this.platformComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.platformComboBox.Size = new System.Drawing.Size(152, 20);
            this.platformComboBox.TabIndex = 10;
            // 
            // frameworkLookUp
            // 
            this.frameworkLookUp.Location = new System.Drawing.Point(176, 50);
            this.frameworkLookUp.Name = "frameworkLookUp";
            this.frameworkLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.frameworkLookUp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.frameworkLookUp.Size = new System.Drawing.Size(152, 20);
            this.frameworkLookUp.TabIndex = 11;
            // 
            // toolVersionLookUp
            // 
            this.toolVersionLookUp.Location = new System.Drawing.Point(176, 76);
            this.toolVersionLookUp.Name = "toolVersionLookUp";
            this.toolVersionLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toolVersionLookUp.Size = new System.Drawing.Size(152, 20);
            this.toolVersionLookUp.TabIndex = 12;
            // 
            // enableNGen
            // 
            this.enableNGen.EditValue = true;
            this.enableNGen.Location = new System.Drawing.Point(176, 102);
            this.enableNGen.Name = "enableNGen";
            this.enableNGen.Properties.Caption = "Enable nGen";
            this.enableNGen.Size = new System.Drawing.Size(103, 19);
            this.enableNGen.TabIndex = 13;
            // 
            // buildSolutions
            // 
            this.buildSolutions.Location = new System.Drawing.Point(40, 357);
            this.buildSolutions.Name = "buildSolutions";
            this.buildSolutions.Size = new System.Drawing.Size(78, 24);
            this.buildSolutions.TabIndex = 14;
            this.buildSolutions.Text = "Build solutions";
            this.buildSolutions.Click += new System.EventHandler(this.OnBuild);
            // 
            // addProductTabPage
            // 
            this.addProductTabPage.Caption = "Add product";
            this.addProductTabPage.Name = "addProductTabPage";
            this.addProductTabPage.Size = new System.Drawing.Size(691, 408);
            // 
            // addVenderTabPage
            // 
            this.addVenderTabPage.Caption = "Add vender";
            this.addVenderTabPage.Name = "addVenderTabPage";
            this.addVenderTabPage.Size = new System.Drawing.Size(691, 408);
            // 
            // testsTab
            // 
            this.testsTab.Controls.Add(this.layoutControl2);
            this.testsTab.Name = "testsTab";
            this.testsTab.Size = new System.Drawing.Size(709, 453);
            this.testsTab.Text = "Tests";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.reset);
            this.layoutControl2.Controls.Add(this.addAssembly);
            this.layoutControl2.Controls.Add(this.startButton);
            this.layoutControl2.Controls.Add(this.productsTreeList);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1059, 254, 450, 350);
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(709, 453);
            this.layoutControl2.TabIndex = 1;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(539, 415);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(79, 26);
            this.reset.StyleController = this.layoutControl2;
            this.reset.TabIndex = 10;
            this.reset.Text = "Reset";
            // 
            // addAssembly
            // 
            this.addAssembly.Location = new System.Drawing.Point(622, 415);
            this.addAssembly.Name = "addAssembly";
            this.addAssembly.Size = new System.Drawing.Size(75, 26);
            this.addAssembly.StyleController = this.layoutControl2;
            this.addAssembly.TabIndex = 9;
            this.addAssembly.Text = "Add assembly";
            this.addAssembly.Click += new System.EventHandler(this.OnUpdateAssemblies);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 415);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(73, 26);
            this.startButton.StyleController = this.layoutControl2;
            this.startButton.TabIndex = 8;
            this.startButton.Text = "Start";
            this.startButton.Click += new System.EventHandler(this.OnStart);
            // 
            // productsTreeList
            // 
            this.productsTreeList.CheckBoxFieldName = "Enabled";
            this.productsTreeList.Location = new System.Drawing.Point(12, 28);
            this.productsTreeList.Name = "productsTreeList";
            this.productsTreeList.Size = new System.Drawing.Size(685, 383);
            this.productsTreeList.TabIndex = 4;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.productsItem,
            this.startItem,
            this.addAssemblyItem,
            this.emptySpaceItem6,
            this.resetItem});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "Root";
            this.layoutControlGroup2.Size = new System.Drawing.Size(709, 453);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // productsItem
            // 
            this.productsItem.AppearanceItemCaption.Options.UseTextOptions = true;
            this.productsItem.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.productsItem.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.productsItem.Control = this.productsTreeList;
            this.productsItem.Location = new System.Drawing.Point(0, 0);
            this.productsItem.MinSize = new System.Drawing.Size(104, 40);
            this.productsItem.Name = "productsItem";
            this.productsItem.Size = new System.Drawing.Size(689, 403);
            this.productsItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.productsItem.Text = "Products";
            this.productsItem.TextLocation = DevExpress.Utils.Locations.Top;
            this.productsItem.TextSize = new System.Drawing.Size(42, 13);
            // 
            // startItem
            // 
            this.startItem.Control = this.startButton;
            this.startItem.Location = new System.Drawing.Point(0, 403);
            this.startItem.MaxSize = new System.Drawing.Size(77, 30);
            this.startItem.MinSize = new System.Drawing.Size(77, 30);
            this.startItem.Name = "startItem";
            this.startItem.Size = new System.Drawing.Size(77, 30);
            this.startItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.startItem.TextSize = new System.Drawing.Size(0, 0);
            this.startItem.TextVisible = false;
            // 
            // addAssemblyItem
            // 
            this.addAssemblyItem.Control = this.addAssembly;
            this.addAssemblyItem.Location = new System.Drawing.Point(610, 403);
            this.addAssemblyItem.MaxSize = new System.Drawing.Size(79, 30);
            this.addAssemblyItem.MinSize = new System.Drawing.Size(79, 30);
            this.addAssemblyItem.Name = "addAssemblyItem";
            this.addAssemblyItem.Size = new System.Drawing.Size(79, 30);
            this.addAssemblyItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.addAssemblyItem.TextSize = new System.Drawing.Size(0, 0);
            this.addAssemblyItem.TextVisible = false;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(77, 403);
            this.emptySpaceItem6.MaxSize = new System.Drawing.Size(0, 30);
            this.emptySpaceItem6.MinSize = new System.Drawing.Size(104, 30);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(450, 30);
            this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // resetItem
            // 
            this.resetItem.Control = this.reset;
            this.resetItem.Location = new System.Drawing.Point(527, 403);
            this.resetItem.MaxSize = new System.Drawing.Size(83, 30);
            this.resetItem.MinSize = new System.Drawing.Size(83, 30);
            this.resetItem.Name = "resetItem";
            this.resetItem.Size = new System.Drawing.Size(83, 30);
            this.resetItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.resetItem.TextSize = new System.Drawing.Size(0, 0);
            this.resetItem.TextVisible = false;
            // 
            // resultsTab
            // 
            this.resultsTab.Controls.Add(this.pivotGridControl);
            this.resultsTab.Name = "resultsTab";
            this.resultsTab.Size = new System.Drawing.Size(709, 453);
            this.resultsTab.Text = "Results";
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
            this.pivotGridControl.Size = new System.Drawing.Size(709, 453);
            this.pivotGridControl.TabIndex = 0;
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
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            // 
            // Runner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 459);
            this.Controls.Add(this.xtraTabControl);
            this.Name = "Runner";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
            this.xtraTabControl.ResumeLayout(false);
            this.settingsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane)).EndInit();
            this.tabPane.ResumeLayout(false);
            this.settingsTabPage.ResumeLayout(false);
            this.settingsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.platformComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameworkLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolVersionLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableNGen.Properties)).EndInit();
            this.testsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productsTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addAssemblyItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resetItem)).EndInit();
            this.resultsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl;
        private DevExpress.XtraTab.XtraTabPage settingsTab;
        private DevExpress.XtraTab.XtraTabPage testsTab;
        private DevExpress.XtraTab.XtraTabPage resultsTab;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.SimpleButton startButton;
        private Benchmark.Win.ProductTreeList productsTreeList;
        private DevExpress.XtraLayout.LayoutControlItem productsItem;
        private DevExpress.XtraLayout.LayoutControlItem startItem;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraEditors.SimpleButton addAssembly;
        private DevExpress.XtraLayout.LayoutControlItem addAssemblyItem;
        private DevExpress.XtraEditors.SimpleButton reset;
        private DevExpress.XtraLayout.LayoutControlItem resetItem;
        private DevExpress.XtraBars.Navigation.TabPane tabPane;
        private DevExpress.XtraBars.Navigation.TabNavigationPage settingsTabPage;
        private DevExpress.XtraEditors.LabelControl frameworkLabel;
        private DevExpress.XtraEditors.LabelControl platformLabel;
        private DevExpress.XtraEditors.ImageComboBoxEdit platformComboBox;
        private DevExpress.XtraEditors.LookUpEdit frameworkLookUp;
        private DevExpress.XtraEditors.LookUpEdit toolVersionLookUp;
        private DevExpress.XtraEditors.CheckEdit enableNGen;
        private DevExpress.XtraEditors.SimpleButton buildSolutions;
        private DevExpress.XtraBars.Navigation.TabNavigationPage addProductTabPage;
        private DevExpress.XtraEditors.LabelControl toolVersionLabel;
        private DevExpress.XtraBars.Navigation.TabNavigationPage addVenderTabPage;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl;
        private DevExpress.XtraPivotGrid.PivotGridField venderField;
        private DevExpress.XtraPivotGrid.PivotGridField productField;
        private DevExpress.XtraPivotGrid.PivotGridField badField;
        private DevExpress.XtraPivotGrid.PivotGridField categoryField;
        private DevExpress.XtraPivotGrid.PivotGridField testField;
        private DevExpress.XtraPivotGrid.PivotGridField medianField;
        private DevExpress.XtraPivotGrid.PivotGridField bestField;
        private DevExpress.XtraPivotGrid.PivotGridField firstField;

    }
}

