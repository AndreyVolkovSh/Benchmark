namespace Benchmark.Views {
    partial class TabBaseView {
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
            this.addButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.searchControl = new DevExpress.XtraEditors.SearchControl();
            this.treeList = new Benchmark.Common.CustomTreeList();
            this.nameColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.checkedListItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.addItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(28, 390);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(76, 22);
            this.addButton.StyleController = this.layoutControl;
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Add";
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.addButton);
            this.layoutControl.Controls.Add(this.searchControl);
            this.layoutControl.Controls.Add(this.treeList);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(389, 469);
            this.layoutControl.TabIndex = 13;
            this.layoutControl.Text = "layoutControl1";
            // 
            // searchControl
            // 
            this.searchControl.Client = this.treeList;
            this.searchControl.Location = new System.Drawing.Point(98, 255);
            this.searchControl.Name = "searchControl";
            this.searchControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl.Properties.Client = this.treeList;
            this.searchControl.Size = new System.Drawing.Size(195, 20);
            this.searchControl.StyleController = this.layoutControl;
            this.searchControl.TabIndex = 11;
            // 
            // treeList
            // 
            this.treeList.CheckBoxFieldName = "Checked";
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.nameColumn});
            this.treeList.Location = new System.Drawing.Point(98, 28);
            this.treeList.Name = "treeList";            
            this.treeList.Size = new System.Drawing.Size(195, 211);
            this.treeList.TabIndex = 10;
            // 
            // nameColumn
            // 
            this.nameColumn.Caption = "Name";
            this.nameColumn.FieldName = "Name";
            this.nameColumn.MinWidth = 34;
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.Visible = true;
            this.nameColumn.VisibleIndex = 0;
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.checkedListItem,
            this.searchItem,
            this.addItem,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem5});
            this.layoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20);
            this.layoutControlGroup.Size = new System.Drawing.Size(389, 469);
            this.layoutControlGroup.TextVisible = false;
            // 
            // checkedListItem
            // 
            this.checkedListItem.AppearanceItemCaption.Options.UseTextOptions = true;
            this.checkedListItem.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.checkedListItem.Control = this.treeList;
            this.checkedListItem.Location = new System.Drawing.Point(0, 0);
            this.checkedListItem.MaxSize = new System.Drawing.Size(281, 500);
            this.checkedListItem.MinSize = new System.Drawing.Size(281, 200);
            this.checkedListItem.Name = "checkedListItem";
            this.checkedListItem.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.checkedListItem.Size = new System.Drawing.Size(281, 227);
            this.checkedListItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.checkedListItem.Text = "Label:";
            this.checkedListItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.checkedListItem.TextSize = new System.Drawing.Size(65, 13);
            this.checkedListItem.TextToControlDistance = 5;
            // 
            // searchItem
            // 
            this.searchItem.Control = this.searchControl;
            this.searchItem.Location = new System.Drawing.Point(70, 227);
            this.searchItem.MaxSize = new System.Drawing.Size(211, 36);
            this.searchItem.MinSize = new System.Drawing.Size(211, 36);
            this.searchItem.Name = "searchItem";
            this.searchItem.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.searchItem.Size = new System.Drawing.Size(211, 36);
            this.searchItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.searchItem.TextSize = new System.Drawing.Size(0, 0);
            this.searchItem.TextVisible = false;
            // 
            // addItem
            // 
            this.addItem.Control = this.addButton;
            this.addItem.Location = new System.Drawing.Point(0, 362);
            this.addItem.MaxSize = new System.Drawing.Size(92, 38);
            this.addItem.MinSize = new System.Drawing.Size(92, 38);
            this.addItem.Name = "addItem";
            this.addItem.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.addItem.Size = new System.Drawing.Size(92, 38);
            this.addItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.addItem.TextSize = new System.Drawing.Size(0, 0);
            this.addItem.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(281, 0);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(1, 1);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(68, 429);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 263);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(1, 1);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(281, 99);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(92, 362);
            this.emptySpaceItem3.MaxSize = new System.Drawing.Size(0, 38);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(100, 38);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(189, 38);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 227);
            this.emptySpaceItem4.MaxSize = new System.Drawing.Size(0, 36);
            this.emptySpaceItem4.MinSize = new System.Drawing.Size(1, 36);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(70, 36);
            this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 400);
            this.emptySpaceItem5.MaxSize = new System.Drawing.Size(0, 29);
            this.emptySpaceItem5.MinSize = new System.Drawing.Size(104, 29);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(281, 29);
            this.emptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // TabBaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Name = "TabBaseView";
            this.Size = new System.Drawing.Size(389, 469);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.SimpleButton addButton;
        protected Benchmark.Common.CustomTreeList treeList;
        protected DevExpress.XtraTreeList.Columns.TreeListColumn nameColumn;
        protected DevExpress.XtraEditors.SearchControl searchControl;
        protected DevExpress.XtraLayout.LayoutControl layoutControl;
        protected DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        protected DevExpress.XtraLayout.LayoutControlItem checkedListItem;
        protected DevExpress.XtraLayout.LayoutControlItem searchItem;
        protected DevExpress.XtraLayout.LayoutControlItem addItem;
        protected DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        protected DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        protected DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        protected DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        protected DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;




    }
}
