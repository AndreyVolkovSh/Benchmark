namespace Benchmark.Win {
    partial class AssemblyManager {
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
            this.assemblyList = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cancel = new DevExpress.XtraEditors.SimpleButton();
            this.ok = new DevExpress.XtraEditors.SimpleButton();
            this.refresh = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.assemblyListItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.refreshItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.okItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.cancelItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.assemblyList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assemblyListItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.okItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // assemblyList
            // 
            this.assemblyList.Cursor = System.Windows.Forms.Cursors.Default;
            this.assemblyList.Location = new System.Drawing.Point(12, 12);
            this.assemblyList.Name = "assemblyList";
            this.assemblyList.Size = new System.Drawing.Size(350, 212);
            this.assemblyList.StyleController = this.layoutControl1;
            this.assemblyList.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cancel);
            this.layoutControl1.Controls.Add(this.ok);
            this.layoutControl1.Controls.Add(this.refresh);
            this.layoutControl1.Controls.Add(this.assemblyList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(786, 120, 507, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(374, 262);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(296, 228);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(66, 22);
            this.cancel.StyleController = this.layoutControl1;
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(223, 228);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(69, 22);
            this.ok.StyleController = this.layoutControl1;
            this.ok.TabIndex = 2;
            this.ok.Text = "Ok";
            this.ok.Click += new System.EventHandler(this.OnLoad);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(12, 228);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(63, 22);
            this.refresh.StyleController = this.layoutControl1;
            this.refresh.TabIndex = 1;
            this.refresh.Text = "Refresh";
            this.refresh.Click += new System.EventHandler(this.OnRefresh);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.assemblyListItem,
            this.okItem,
            this.cancelItem,
            this.emptySpaceItem1,
            this.refreshItem});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(374, 262);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // assemblyListItem
            // 
            this.assemblyListItem.Control = this.assemblyList;
            this.assemblyListItem.Location = new System.Drawing.Point(0, 0);
            this.assemblyListItem.Name = "assemblyListItem";
            this.assemblyListItem.Size = new System.Drawing.Size(354, 216);
            this.assemblyListItem.TextSize = new System.Drawing.Size(0, 0);
            this.assemblyListItem.TextVisible = false;
            // 
            // refreshItem
            // 
            this.refreshItem.Control = this.refresh;
            this.refreshItem.Location = new System.Drawing.Point(0, 216);
            this.refreshItem.MaxSize = new System.Drawing.Size(67, 26);
            this.refreshItem.MinSize = new System.Drawing.Size(67, 26);
            this.refreshItem.Name = "refreshItem";
            this.refreshItem.Size = new System.Drawing.Size(67, 26);
            this.refreshItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.refreshItem.TextSize = new System.Drawing.Size(0, 0);
            this.refreshItem.TextVisible = false;
            // 
            // okItem
            // 
            this.okItem.Control = this.ok;
            this.okItem.Location = new System.Drawing.Point(211, 216);
            this.okItem.MaxSize = new System.Drawing.Size(73, 26);
            this.okItem.MinSize = new System.Drawing.Size(73, 26);
            this.okItem.Name = "okItem";
            this.okItem.Size = new System.Drawing.Size(73, 26);
            this.okItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.okItem.TextSize = new System.Drawing.Size(0, 0);
            this.okItem.TextVisible = false;
            // 
            // cancelItem
            // 
            this.cancelItem.Control = this.cancel;
            this.cancelItem.Location = new System.Drawing.Point(284, 216);
            this.cancelItem.MaxSize = new System.Drawing.Size(70, 26);
            this.cancelItem.MinSize = new System.Drawing.Size(70, 26);
            this.cancelItem.Name = "cancelItem";
            this.cancelItem.Size = new System.Drawing.Size(70, 26);
            this.cancelItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.cancelItem.TextSize = new System.Drawing.Size(0, 0);
            this.cancelItem.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(67, 216);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 26);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(144, 26);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // AddAssembly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 262);
            this.Controls.Add(this.layoutControl1);
            this.Name = "AddAssembly";
            this.Text = "Assembly manager";
            ((System.ComponentModel.ISupportInitialize)(this.assemblyList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assemblyListItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.okItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl assemblyList;
        private DevExpress.XtraEditors.SimpleButton refresh;
        private DevExpress.XtraEditors.SimpleButton ok;
        private DevExpress.XtraEditors.SimpleButton cancel;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem assemblyListItem;
        private DevExpress.XtraLayout.LayoutControlItem refreshItem;
        private DevExpress.XtraLayout.LayoutControlItem okItem;
        private DevExpress.XtraLayout.LayoutControlItem cancelItem;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}