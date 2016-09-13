namespace Benchmark.Views {
    partial class TabSettingsView {
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
            this.enableNGen = new DevExpress.XtraEditors.CheckEdit();
            this.toolVersionLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.buildSolutionsButton = new DevExpress.XtraEditors.SimpleButton();
            this.frameworkLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.platformComboBox = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.platformItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.frameworkItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.toolVersionItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.buildSolutionsItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.enableNGenItem = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enableNGen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolVersionLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameworkLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platformComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platformItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameworkItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolVersionItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildSolutionsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableNGenItem)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.enableNGen);
            this.layoutControl.Controls.Add(this.toolVersionLookUp);
            this.layoutControl.Controls.Add(this.buildSolutionsButton);
            this.layoutControl.Controls.Add(this.frameworkLookUp);
            this.layoutControl.Controls.Add(this.platformComboBox);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(438, 441);
            this.layoutControl.TabIndex = 26;
            this.layoutControl.Text = "layoutControl1";
            // 
            // enableNGen
            // 
            this.enableNGen.EditValue = true;
            this.enableNGen.Location = new System.Drawing.Point(28, 136);
            this.enableNGen.Name = "enableNGen";
            this.enableNGen.Properties.Caption = "Enable nGen";
            this.enableNGen.Size = new System.Drawing.Size(260, 19);
            this.enableNGen.StyleController = this.layoutControl;
            this.enableNGen.TabIndex = 21;
            // 
            // toolVersionLookUp
            // 
            this.toolVersionLookUp.Location = new System.Drawing.Point(98, 100);
            this.toolVersionLookUp.Name = "toolVersionLookUp";
            this.toolVersionLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toolVersionLookUp.Size = new System.Drawing.Size(190, 20);
            this.toolVersionLookUp.StyleController = this.layoutControl;
            this.toolVersionLookUp.TabIndex = 20;
            // 
            // buildSolutionsButton
            // 
            this.buildSolutionsButton.Location = new System.Drawing.Point(28, 362);
            this.buildSolutionsButton.Name = "buildSolutionsButton";
            this.buildSolutionsButton.Size = new System.Drawing.Size(76, 22);
            this.buildSolutionsButton.StyleController = this.layoutControl;
            this.buildSolutionsButton.TabIndex = 22;
            this.buildSolutionsButton.Text = "Build solutions";
            // 
            // frameworkLookUp
            // 
            this.frameworkLookUp.Location = new System.Drawing.Point(98, 64);
            this.frameworkLookUp.Name = "frameworkLookUp";
            this.frameworkLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.frameworkLookUp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.frameworkLookUp.Size = new System.Drawing.Size(190, 20);
            this.frameworkLookUp.StyleController = this.layoutControl;
            this.frameworkLookUp.TabIndex = 19;
            // 
            // platformComboBox
            // 
            this.platformComboBox.Location = new System.Drawing.Point(98, 28);
            this.platformComboBox.Name = "platformComboBox";
            this.platformComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.platformComboBox.Size = new System.Drawing.Size(190, 20);
            this.platformComboBox.StyleController = this.layoutControl;
            this.platformComboBox.TabIndex = 18;
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.platformItem,
            this.frameworkItem,
            this.toolVersionItem,
            this.buildSolutionsItem,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem4,
            this.emptySpaceItem3,
            this.enableNGenItem});
            this.layoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20);
            this.layoutControlGroup.Size = new System.Drawing.Size(438, 441);
            this.layoutControlGroup.TextVisible = false;
            // 
            // platformItem
            // 
            this.platformItem.Control = this.platformComboBox;
            this.platformItem.Location = new System.Drawing.Point(0, 0);
            this.platformItem.MaxSize = new System.Drawing.Size(276, 36);
            this.platformItem.MinSize = new System.Drawing.Size(276, 36);
            this.platformItem.Name = "platformItem";
            this.platformItem.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.platformItem.Size = new System.Drawing.Size(276, 36);
            this.platformItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.platformItem.Text = "Platform:";
            this.platformItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.platformItem.TextSize = new System.Drawing.Size(65, 13);
            this.platformItem.TextToControlDistance = 5;
            // 
            // frameworkItem
            // 
            this.frameworkItem.Control = this.frameworkLookUp;
            this.frameworkItem.Location = new System.Drawing.Point(0, 36);
            this.frameworkItem.MaxSize = new System.Drawing.Size(276, 36);
            this.frameworkItem.MinSize = new System.Drawing.Size(276, 36);
            this.frameworkItem.Name = "frameworkItem";
            this.frameworkItem.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.frameworkItem.Size = new System.Drawing.Size(276, 36);
            this.frameworkItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.frameworkItem.Text = "Framework:";
            this.frameworkItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.frameworkItem.TextSize = new System.Drawing.Size(65, 13);
            this.frameworkItem.TextToControlDistance = 5;
            // 
            // toolVersionItem
            // 
            this.toolVersionItem.Control = this.toolVersionLookUp;
            this.toolVersionItem.Location = new System.Drawing.Point(0, 72);
            this.toolVersionItem.MaxSize = new System.Drawing.Size(276, 36);
            this.toolVersionItem.MinSize = new System.Drawing.Size(276, 36);
            this.toolVersionItem.Name = "toolVersionItem";
            this.toolVersionItem.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.toolVersionItem.Size = new System.Drawing.Size(276, 36);
            this.toolVersionItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.toolVersionItem.Text = "Tool version:";
            this.toolVersionItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.toolVersionItem.TextSize = new System.Drawing.Size(65, 13);
            this.toolVersionItem.TextToControlDistance = 5;
            // 
            // buildSolutionsItem
            // 
            this.buildSolutionsItem.Control = this.buildSolutionsButton;
            this.buildSolutionsItem.Location = new System.Drawing.Point(0, 334);
            this.buildSolutionsItem.MaxSize = new System.Drawing.Size(92, 38);
            this.buildSolutionsItem.MinSize = new System.Drawing.Size(92, 38);
            this.buildSolutionsItem.Name = "buildSolutionsItem";
            this.buildSolutionsItem.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.buildSolutionsItem.Size = new System.Drawing.Size(92, 38);
            this.buildSolutionsItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.buildSolutionsItem.TextSize = new System.Drawing.Size(0, 0);
            this.buildSolutionsItem.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 143);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(276, 191);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(92, 334);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(0, 38);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(104, 38);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(184, 38);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 372);
            this.emptySpaceItem4.MaxSize = new System.Drawing.Size(276, 29);
            this.emptySpaceItem4.MinSize = new System.Drawing.Size(276, 29);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(276, 29);
            this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(276, 0);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(122, 401);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // enableNGenItem
            // 
            this.enableNGenItem.Control = this.enableNGen;
            this.enableNGenItem.Location = new System.Drawing.Point(0, 108);
            this.enableNGenItem.MaxSize = new System.Drawing.Size(276, 35);
            this.enableNGenItem.MinSize = new System.Drawing.Size(276, 35);
            this.enableNGenItem.Name = "enableNGenItem";
            this.enableNGenItem.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.enableNGenItem.Size = new System.Drawing.Size(276, 35);
            this.enableNGenItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.enableNGenItem.TextSize = new System.Drawing.Size(0, 0);
            this.enableNGenItem.TextVisible = false;
            // 
            // TabSettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Name = "TabSettingsView";
            this.Size = new System.Drawing.Size(438, 441);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.enableNGen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolVersionLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameworkLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platformComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platformItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameworkItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolVersionItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildSolutionsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableNGenItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ImageComboBoxEdit platformComboBox;
        private DevExpress.XtraEditors.LookUpEdit frameworkLookUp;
        private DevExpress.XtraEditors.LookUpEdit toolVersionLookUp;
        private DevExpress.XtraEditors.CheckEdit enableNGen;
        private DevExpress.XtraEditors.SimpleButton buildSolutionsButton;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem platformItem;
        private DevExpress.XtraLayout.LayoutControlItem frameworkItem;
        private DevExpress.XtraLayout.LayoutControlItem toolVersionItem;
        private DevExpress.XtraLayout.LayoutControlItem buildSolutionsItem;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem enableNGenItem;
    }
}
