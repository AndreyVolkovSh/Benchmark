namespace Benchmark.Views {
    partial class BenchmarksView {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.searchControl = new DevExpress.XtraEditors.SearchControl();
            this.productsTreeList = new Benchmark.Common.ProductTreeList();
            this.refreshButton = new DevExpress.XtraEditors.SimpleButton();
            this.addAssemblyButton = new DevExpress.XtraEditors.SimpleButton();
            this.startButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.productsItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem = new DevExpress.XtraLayout.EmptySpaceItem();
            this.startItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.addAssemblyItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.refreshItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchItem = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addAssemblyItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchItem)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.searchControl);
            this.layoutControl.Controls.Add(this.refreshButton);
            this.layoutControl.Controls.Add(this.addAssemblyButton);
            this.layoutControl.Controls.Add(this.startButton);
            this.layoutControl.Controls.Add(this.productsTreeList);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1059, 254, 530, 350);
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(705, 418);
            this.layoutControl.TabIndex = 2;
            this.layoutControl.Text = "layoutControl";
            // 
            // searchControl
            // 
            this.searchControl.Client = this.productsTreeList;
            this.searchControl.Location = new System.Drawing.Point(446, 384);
            this.searchControl.Name = "searchControl";
            this.searchControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl.Properties.Client = this.productsTreeList;
            this.searchControl.Size = new System.Drawing.Size(247, 20);
            this.searchControl.StyleController = this.layoutControl;
            this.searchControl.TabIndex = 11;
            // 
            // productsTreeList
            // 
            this.productsTreeList.CheckBoxFieldName = "Enabled";
            this.productsTreeList.Cursor = System.Windows.Forms.Cursors.Default;
            this.productsTreeList.Location = new System.Drawing.Point(12, 12);
            this.productsTreeList.Name = "productsTreeList";
            this.productsTreeList.Size = new System.Drawing.Size(681, 367);
            this.productsTreeList.TabIndex = 4;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(168, 383);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(79, 23);
            this.refreshButton.StyleController = this.layoutControl;
            this.refreshButton.TabIndex = 10;
            this.refreshButton.Text = "Refresh";
            // 
            // addAssemblyButton
            // 
            this.addAssemblyButton.Location = new System.Drawing.Point(89, 383);
            this.addAssemblyButton.Name = "addAssemblyButton";
            this.addAssemblyButton.Size = new System.Drawing.Size(75, 23);
            this.addAssemblyButton.StyleController = this.layoutControl;
            this.addAssemblyButton.TabIndex = 9;
            this.addAssemblyButton.Text = "Add assembly";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 383);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(73, 23);
            this.startButton.StyleController = this.layoutControl;
            this.startButton.TabIndex = 8;
            this.startButton.Text = "Start";
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.productsItem,
            this.emptySpaceItem,
            this.startItem,
            this.addAssemblyItem,
            this.refreshItem,
            this.searchItem});
            this.layoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup.Name = "Root";
            this.layoutControlGroup.Size = new System.Drawing.Size(705, 418);
            this.layoutControlGroup.TextVisible = false;
            // 
            // productsItem
            // 
            this.productsItem.AppearanceItemCaption.Options.UseTextOptions = true;
            this.productsItem.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.productsItem.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.productsItem.Control = this.productsTreeList;
            this.productsItem.Location = new System.Drawing.Point(0, 0);
            this.productsItem.MinSize = new System.Drawing.Size(104, 24);
            this.productsItem.Name = "productsItem";
            this.productsItem.Size = new System.Drawing.Size(685, 371);
            this.productsItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.productsItem.Text = "Products";
            this.productsItem.TextLocation = DevExpress.Utils.Locations.Top;
            this.productsItem.TextSize = new System.Drawing.Size(0, 0);
            this.productsItem.TextVisible = false;
            // 
            // emptySpaceItem
            // 
            this.emptySpaceItem.AllowHotTrack = false;
            this.emptySpaceItem.Location = new System.Drawing.Point(239, 371);
            this.emptySpaceItem.MaxSize = new System.Drawing.Size(0, 27);
            this.emptySpaceItem.MinSize = new System.Drawing.Size(104, 27);
            this.emptySpaceItem.Name = "emptySpaceItem";
            this.emptySpaceItem.Size = new System.Drawing.Size(195, 27);
            this.emptySpaceItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem.TextSize = new System.Drawing.Size(0, 0);
            // 
            // startItem
            // 
            this.startItem.Control = this.startButton;
            this.startItem.Location = new System.Drawing.Point(0, 371);
            this.startItem.MaxSize = new System.Drawing.Size(77, 27);
            this.startItem.MinSize = new System.Drawing.Size(77, 27);
            this.startItem.Name = "startItem";
            this.startItem.Size = new System.Drawing.Size(77, 27);
            this.startItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.startItem.TextSize = new System.Drawing.Size(0, 0);
            this.startItem.TextVisible = false;
            // 
            // addAssemblyItem
            // 
            this.addAssemblyItem.Control = this.addAssemblyButton;
            this.addAssemblyItem.Location = new System.Drawing.Point(77, 371);
            this.addAssemblyItem.MaxSize = new System.Drawing.Size(79, 27);
            this.addAssemblyItem.MinSize = new System.Drawing.Size(79, 27);
            this.addAssemblyItem.Name = "addAssemblyItem";
            this.addAssemblyItem.Size = new System.Drawing.Size(79, 27);
            this.addAssemblyItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.addAssemblyItem.TextSize = new System.Drawing.Size(0, 0);
            this.addAssemblyItem.TextVisible = false;
            // 
            // refreshItem
            // 
            this.refreshItem.Control = this.refreshButton;
            this.refreshItem.Location = new System.Drawing.Point(156, 371);
            this.refreshItem.MaxSize = new System.Drawing.Size(83, 27);
            this.refreshItem.MinSize = new System.Drawing.Size(83, 27);
            this.refreshItem.Name = "refreshItem";
            this.refreshItem.Size = new System.Drawing.Size(83, 27);
            this.refreshItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.refreshItem.TextSize = new System.Drawing.Size(0, 0);
            this.refreshItem.TextVisible = false;
            // 
            // searchItem
            // 
            this.searchItem.Control = this.searchControl;
            this.searchItem.Location = new System.Drawing.Point(434, 371);
            this.searchItem.MaxSize = new System.Drawing.Size(251, 27);
            this.searchItem.MinSize = new System.Drawing.Size(251, 27);
            this.searchItem.Name = "searchItem";
            this.searchItem.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 2);
            this.searchItem.Size = new System.Drawing.Size(251, 27);
            this.searchItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.searchItem.Text = "Search:";
            this.searchItem.TextSize = new System.Drawing.Size(0, 0);
            this.searchItem.TextVisible = false;
            // 
            // TestsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Name = "TestsView";
            this.Size = new System.Drawing.Size(705, 418);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addAssemblyItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.SimpleButton refreshButton;
        private DevExpress.XtraEditors.SimpleButton addAssemblyButton;
        private DevExpress.XtraEditors.SimpleButton startButton;
        private Common.ProductTreeList productsTreeList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem productsItem;
        private DevExpress.XtraLayout.LayoutControlItem startItem;
        private DevExpress.XtraLayout.LayoutControlItem addAssemblyItem;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem;
        private DevExpress.XtraLayout.LayoutControlItem refreshItem;
        private DevExpress.XtraEditors.SearchControl searchControl;
        private DevExpress.XtraLayout.LayoutControlItem searchItem;
    }
}
