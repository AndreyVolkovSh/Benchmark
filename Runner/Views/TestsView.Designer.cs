namespace Benchmark.Win.Views {
    partial class TestsView {
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
            this.resetButton = new DevExpress.XtraEditors.SimpleButton();
            this.addAssemblyButton = new DevExpress.XtraEditors.SimpleButton();
            this.startButton = new DevExpress.XtraEditors.SimpleButton();
            this.productsTreeList = new Benchmark.Win.ProductTreeList();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.productsItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.startItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.addAssemblyItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.resetItem = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productsTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addAssemblyItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resetItem)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.resetButton);
            this.layoutControl.Controls.Add(this.addAssemblyButton);
            this.layoutControl.Controls.Add(this.startButton);
            this.layoutControl.Controls.Add(this.productsTreeList);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1059, 254, 450, 350);
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(661, 417);
            this.layoutControl.TabIndex = 2;
            this.layoutControl.Text = "layoutControl";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(491, 379);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(79, 26);
            this.resetButton.StyleController = this.layoutControl;
            this.resetButton.TabIndex = 10;
            this.resetButton.Text = "Reset";
            // 
            // addAssemblyButton
            // 
            this.addAssemblyButton.Location = new System.Drawing.Point(574, 379);
            this.addAssemblyButton.Name = "addAssemblyButton";
            this.addAssemblyButton.Size = new System.Drawing.Size(75, 26);
            this.addAssemblyButton.StyleController = this.layoutControl;
            this.addAssemblyButton.TabIndex = 9;
            this.addAssemblyButton.Text = "Add assembly";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 379);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(73, 26);
            this.startButton.StyleController = this.layoutControl;
            this.startButton.TabIndex = 8;
            this.startButton.Text = "Start";
            // 
            // productsTreeList
            // 
            this.productsTreeList.CheckBoxFieldName = "Enabled";
            this.productsTreeList.Cursor = System.Windows.Forms.Cursors.Default;
            this.productsTreeList.Location = new System.Drawing.Point(12, 12);
            this.productsTreeList.Name = "productsTreeList";
            this.productsTreeList.Size = new System.Drawing.Size(637, 363);
            this.productsTreeList.TabIndex = 4;
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.productsItem,
            this.startItem,
            this.addAssemblyItem,
            this.emptySpaceItem6,
            this.resetItem});
            this.layoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Size = new System.Drawing.Size(661, 417);
            this.layoutControlGroup.TextVisible = false;
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
            this.productsItem.Size = new System.Drawing.Size(641, 367);
            this.productsItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.productsItem.Text = "Products";
            this.productsItem.TextLocation = DevExpress.Utils.Locations.Top;
            this.productsItem.TextSize = new System.Drawing.Size(0, 0);
            this.productsItem.TextVisible = false;
            // 
            // startItem
            // 
            this.startItem.Control = this.startButton;
            this.startItem.Location = new System.Drawing.Point(0, 367);
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
            this.addAssemblyItem.Control = this.addAssemblyButton;
            this.addAssemblyItem.Location = new System.Drawing.Point(562, 367);
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
            this.emptySpaceItem6.Location = new System.Drawing.Point(77, 367);
            this.emptySpaceItem6.MaxSize = new System.Drawing.Size(0, 30);
            this.emptySpaceItem6.MinSize = new System.Drawing.Size(104, 30);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(402, 30);
            this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // resetItem
            // 
            this.resetItem.Control = this.resetButton;
            this.resetItem.Location = new System.Drawing.Point(479, 367);
            this.resetItem.MaxSize = new System.Drawing.Size(83, 30);
            this.resetItem.MinSize = new System.Drawing.Size(83, 30);
            this.resetItem.Name = "resetItem";
            this.resetItem.Size = new System.Drawing.Size(83, 30);
            this.resetItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.resetItem.TextSize = new System.Drawing.Size(0, 0);
            this.resetItem.TextVisible = false;
            // 
            // TestsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Name = "TestsView";
            this.Size = new System.Drawing.Size(661, 417);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productsTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addAssemblyItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resetItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.SimpleButton resetButton;
        private DevExpress.XtraEditors.SimpleButton addAssemblyButton;
        private DevExpress.XtraEditors.SimpleButton startButton;
        private ProductTreeList productsTreeList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem productsItem;
        private DevExpress.XtraLayout.LayoutControlItem startItem;
        private DevExpress.XtraLayout.LayoutControlItem addAssemblyItem;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.LayoutControlItem resetItem;
    }
}
