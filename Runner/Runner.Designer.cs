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
            this.navigationPane1 = new DevExpress.XtraBars.Navigation.NavigationPane();
            this.settingsPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.buildSolutions = new DevExpress.XtraEditors.SimpleButton();
            this.enableNGen = new DevExpress.XtraEditors.CheckEdit();
            this.toolVersionLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.frameworkLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.platformComboBox = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.platformItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.frameworkItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.toolVersionItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.enableNGenItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.buildSolutionsItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.testsPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.addAssembly = new DevExpress.XtraEditors.SimpleButton();
            this.startButton = new DevExpress.XtraEditors.SimpleButton();
            this.productsTreeList = new Benchmark.Win.ProductTreeList();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.productsItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.startItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.addAssemblyItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.resultsPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.navigationPane1)).BeginInit();
            this.navigationPane1.SuspendLayout();
            this.settingsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enableNGen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolVersionLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameworkLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platformComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platformItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameworkItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolVersionItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableNGenItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildSolutionsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            this.testsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productsTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addAssemblyItem)).BeginInit();
            this.resultsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // navigationPane1
            // 
            this.navigationPane1.Controls.Add(this.settingsPage);
            this.navigationPane1.Controls.Add(this.testsPage);
            this.navigationPane1.Controls.Add(this.resultsPage);
            this.navigationPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPane1.Location = new System.Drawing.Point(0, 0);
            this.navigationPane1.Name = "navigationPane1";
            this.navigationPane1.PageProperties.ShowCollapseButton = false;
            this.navigationPane1.PageProperties.ShowExpandButton = false;
            this.navigationPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.settingsPage,
            this.testsPage,
            this.resultsPage});
            this.navigationPane1.RegularSize = new System.Drawing.Size(768, 459);
            this.navigationPane1.SelectedPage = this.settingsPage;
            this.navigationPane1.Size = new System.Drawing.Size(768, 459);
            this.navigationPane1.TabIndex = 0;
            this.navigationPane1.Text = "Tests";
            // 
            // settingsPage
            // 
            this.settingsPage.Caption = "Settings";
            this.settingsPage.Controls.Add(this.layoutControl1);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Size = new System.Drawing.Size(695, 413);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.buildSolutions);
            this.layoutControl1.Controls.Add(this.enableNGen);
            this.layoutControl1.Controls.Add(this.toolVersionLookUp);
            this.layoutControl1.Controls.Add(this.frameworkLookUp);
            this.layoutControl1.Controls.Add(this.platformComboBox);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(922, 195, 615, 416);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(695, 413);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // buildSolutions
            // 
            this.buildSolutions.Location = new System.Drawing.Point(277, 365);
            this.buildSolutions.Name = "buildSolutions";
            this.buildSolutions.Size = new System.Drawing.Size(103, 36);
            this.buildSolutions.StyleController = this.layoutControl1;
            this.buildSolutions.TabIndex = 9;
            this.buildSolutions.Text = "Build solutions";
            this.buildSolutions.Click += new System.EventHandler(this.OnBuild);
            // 
            // enableNGen
            // 
            this.enableNGen.EditValue = true;
            this.enableNGen.Location = new System.Drawing.Point(204, 84);
            this.enableNGen.Name = "enableNGen";
            this.enableNGen.Properties.Caption = "Enable nGen";
            this.enableNGen.Size = new System.Drawing.Size(248, 19);
            this.enableNGen.StyleController = this.layoutControl1;
            this.enableNGen.TabIndex = 8;
            // 
            // toolVersionLookUp
            // 
            this.toolVersionLookUp.Location = new System.Drawing.Point(269, 60);
            this.toolVersionLookUp.Name = "toolVersionLookUp";
            this.toolVersionLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toolVersionLookUp.Size = new System.Drawing.Size(183, 20);
            this.toolVersionLookUp.StyleController = this.layoutControl1;
            this.toolVersionLookUp.TabIndex = 7;
            // 
            // frameworkLookUp
            // 
            this.frameworkLookUp.Location = new System.Drawing.Point(269, 36);
            this.frameworkLookUp.Name = "frameworkLookUp";
            this.frameworkLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.frameworkLookUp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Version", "Version")});
            this.frameworkLookUp.Size = new System.Drawing.Size(183, 20);
            this.frameworkLookUp.StyleController = this.layoutControl1;
            this.frameworkLookUp.TabIndex = 6;
            // 
            // platformComboBox
            // 
            this.platformComboBox.Location = new System.Drawing.Point(269, 12);
            this.platformComboBox.Name = "platformComboBox";
            this.platformComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.platformComboBox.Size = new System.Drawing.Size(183, 20);
            this.platformComboBox.StyleController = this.layoutControl1;
            this.platformComboBox.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.platformItem,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.frameworkItem,
            this.toolVersionItem,
            this.enableNGenItem,
            this.buildSolutionsItem,
            this.emptySpaceItem4,
            this.emptySpaceItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(695, 413);
            // 
            // platformItem
            // 
            this.platformItem.Control = this.platformComboBox;
            this.platformItem.Location = new System.Drawing.Point(192, 0);
            this.platformItem.MaxSize = new System.Drawing.Size(252, 24);
            this.platformItem.MinSize = new System.Drawing.Size(252, 24);
            this.platformItem.Name = "platformItem";
            this.platformItem.Size = new System.Drawing.Size(252, 24);
            this.platformItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.platformItem.Text = "Platform:";
            this.platformItem.TextSize = new System.Drawing.Size(62, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(192, 393);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(444, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(231, 393);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(192, 95);
            this.emptySpaceItem3.MaxSize = new System.Drawing.Size(252, 0);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(252, 10);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(252, 258);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frameworkItem
            // 
            this.frameworkItem.Control = this.frameworkLookUp;
            this.frameworkItem.Location = new System.Drawing.Point(192, 24);
            this.frameworkItem.MaxSize = new System.Drawing.Size(252, 24);
            this.frameworkItem.MinSize = new System.Drawing.Size(252, 24);
            this.frameworkItem.Name = "frameworkItem";
            this.frameworkItem.Size = new System.Drawing.Size(252, 24);
            this.frameworkItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.frameworkItem.Text = "Framework:";
            this.frameworkItem.TextSize = new System.Drawing.Size(62, 13);
            // 
            // toolVersionItem
            // 
            this.toolVersionItem.Control = this.toolVersionLookUp;
            this.toolVersionItem.Location = new System.Drawing.Point(192, 48);
            this.toolVersionItem.MaxSize = new System.Drawing.Size(252, 24);
            this.toolVersionItem.MinSize = new System.Drawing.Size(252, 24);
            this.toolVersionItem.Name = "toolVersionItem";
            this.toolVersionItem.Size = new System.Drawing.Size(252, 24);
            this.toolVersionItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.toolVersionItem.Text = "Tool version:";
            this.toolVersionItem.TextSize = new System.Drawing.Size(62, 13);
            // 
            // enableNGenItem
            // 
            this.enableNGenItem.Control = this.enableNGen;
            this.enableNGenItem.Location = new System.Drawing.Point(192, 72);
            this.enableNGenItem.MaxSize = new System.Drawing.Size(252, 23);
            this.enableNGenItem.MinSize = new System.Drawing.Size(252, 23);
            this.enableNGenItem.Name = "enableNGenItem";
            this.enableNGenItem.Size = new System.Drawing.Size(252, 23);
            this.enableNGenItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.enableNGenItem.TextSize = new System.Drawing.Size(0, 0);
            this.enableNGenItem.TextVisible = false;
            // 
            // buildSolutionsItem
            // 
            this.buildSolutionsItem.Control = this.buildSolutions;
            this.buildSolutionsItem.Location = new System.Drawing.Point(265, 353);
            this.buildSolutionsItem.MaxSize = new System.Drawing.Size(107, 40);
            this.buildSolutionsItem.MinSize = new System.Drawing.Size(107, 40);
            this.buildSolutionsItem.Name = "buildSolutionsItem";
            this.buildSolutionsItem.Size = new System.Drawing.Size(107, 40);
            this.buildSolutionsItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.buildSolutionsItem.TextSize = new System.Drawing.Size(0, 0);
            this.buildSolutionsItem.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(192, 353);
            this.emptySpaceItem4.MaxSize = new System.Drawing.Size(73, 40);
            this.emptySpaceItem4.MinSize = new System.Drawing.Size(73, 40);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(73, 40);
            this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(372, 353);
            this.emptySpaceItem5.MaxSize = new System.Drawing.Size(72, 40);
            this.emptySpaceItem5.MinSize = new System.Drawing.Size(72, 40);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(72, 40);
            this.emptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // testsPage
            // 
            this.testsPage.Caption = "Tests";
            this.testsPage.Controls.Add(this.layoutControl2);
            this.testsPage.Name = "testsPage";
            this.testsPage.Size = new System.Drawing.Size(695, 413);
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.addAssembly);
            this.layoutControl2.Controls.Add(this.startButton);
            this.layoutControl2.Controls.Add(this.productsTreeList);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1059, 254, 450, 350);
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(695, 413);
            this.layoutControl2.TabIndex = 1;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // addAssembly
            // 
            this.addAssembly.Location = new System.Drawing.Point(575, 357);
            this.addAssembly.Name = "addAssembly";
            this.addAssembly.Size = new System.Drawing.Size(108, 44);
            this.addAssembly.StyleController = this.layoutControl2;
            this.addAssembly.TabIndex = 9;
            this.addAssembly.Text = "Add assembly";
            this.addAssembly.Click += new System.EventHandler(this.OnUpdateAssemblies);
            // 
            // startButton
            // 
            this.startButton.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.startButton.Appearance.Options.UseFont = true;
            this.startButton.Location = new System.Drawing.Point(240, 357);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(137, 44);
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
            this.productsTreeList.Size = new System.Drawing.Size(671, 325);
            this.productsTreeList.TabIndex = 4;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.productsItem,
            this.startItem,
            this.emptySpaceItem6,
            this.emptySpaceItem7,
            this.addAssemblyItem});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "Root";
            this.layoutControlGroup2.Size = new System.Drawing.Size(695, 413);
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
            this.productsItem.Size = new System.Drawing.Size(675, 345);
            this.productsItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.productsItem.Text = "Products";
            this.productsItem.TextLocation = DevExpress.Utils.Locations.Top;
            this.productsItem.TextSize = new System.Drawing.Size(42, 13);
            // 
            // startItem
            // 
            this.startItem.Control = this.startButton;
            this.startItem.Location = new System.Drawing.Point(228, 345);
            this.startItem.MaxSize = new System.Drawing.Size(141, 48);
            this.startItem.MinSize = new System.Drawing.Size(141, 48);
            this.startItem.Name = "startItem";
            this.startItem.Size = new System.Drawing.Size(141, 48);
            this.startItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.startItem.TextSize = new System.Drawing.Size(0, 0);
            this.startItem.TextVisible = false;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(0, 345);
            this.emptySpaceItem6.MaxSize = new System.Drawing.Size(0, 48);
            this.emptySpaceItem6.MinSize = new System.Drawing.Size(104, 48);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(228, 48);
            this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.Location = new System.Drawing.Point(369, 345);
            this.emptySpaceItem7.MaxSize = new System.Drawing.Size(0, 48);
            this.emptySpaceItem7.MinSize = new System.Drawing.Size(104, 48);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(194, 48);
            this.emptySpaceItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // addAssemblyItem
            // 
            this.addAssemblyItem.Control = this.addAssembly;
            this.addAssemblyItem.Location = new System.Drawing.Point(563, 345);
            this.addAssemblyItem.MaxSize = new System.Drawing.Size(112, 48);
            this.addAssemblyItem.MinSize = new System.Drawing.Size(112, 48);
            this.addAssemblyItem.Name = "addAssemblyItem";
            this.addAssemblyItem.Size = new System.Drawing.Size(112, 48);
            this.addAssemblyItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.addAssemblyItem.TextSize = new System.Drawing.Size(0, 0);
            this.addAssemblyItem.TextVisible = false;
            // 
            // resultsPage
            // 
            this.resultsPage.Caption = "Results";
            this.resultsPage.Controls.Add(this.gridControl);
            this.resultsPage.Name = "resultsPage";
            this.resultsPage.Size = new System.Drawing.Size(695, 413);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(695, 413);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.Name = "gridView1";
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
            this.Controls.Add(this.navigationPane1);
            this.Name = "Runner";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.navigationPane1)).EndInit();
            this.navigationPane1.ResumeLayout(false);
            this.settingsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.enableNGen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolVersionLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameworkLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platformComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platformItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameworkItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolVersionItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableNGenItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildSolutionsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            this.testsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productsTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addAssemblyItem)).EndInit();
            this.resultsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraBars.Navigation.NavigationPane navigationPane1;
        private DevExpress.XtraBars.Navigation.NavigationPage settingsPage;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Navigation.NavigationPage testsPage;
        private DevExpress.XtraBars.Navigation.NavigationPage resultsPage;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.ImageComboBoxEdit platformComboBox;
        private DevExpress.XtraLayout.LayoutControlItem platformItem;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.SimpleButton startButton;
        private Benchmark.Win.ProductTreeList productsTreeList;
        private DevExpress.XtraLayout.LayoutControlItem productsItem;
        private DevExpress.XtraLayout.LayoutControlItem startItem;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraEditors.CheckEdit enableNGen;
        private DevExpress.XtraEditors.LookUpEdit toolVersionLookUp;
        private DevExpress.XtraEditors.LookUpEdit frameworkLookUp;
        private DevExpress.XtraLayout.LayoutControlItem frameworkItem;
        private DevExpress.XtraLayout.LayoutControlItem toolVersionItem;
        private DevExpress.XtraLayout.LayoutControlItem enableNGenItem;
        private DevExpress.XtraEditors.SimpleButton buildSolutions;
        private DevExpress.XtraLayout.LayoutControlItem buildSolutionsItem;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraEditors.SimpleButton addAssembly;
        private DevExpress.XtraLayout.LayoutControlItem addAssemblyItem;

    }
}

