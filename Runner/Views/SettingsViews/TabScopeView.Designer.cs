namespace Benchmark.Views {
    partial class TabScopeView {
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
            this.lookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.newScopeItem = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newScopeItem)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(28, 380);
            // 
            // searchControl
            // 
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.lookUpEdit);
            this.layoutControl.Size = new System.Drawing.Size(404, 459);
            this.layoutControl.Controls.SetChildIndex(this.searchControl, 0);
            this.layoutControl.Controls.SetChildIndex(this.addButton, 0);
            this.layoutControl.Controls.SetChildIndex(this.lookUpEdit, 0);
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.newScopeItem});
            this.layoutControlGroup.Size = new System.Drawing.Size(404, 459);
            // 
            // checkedListItem
            // 
            this.checkedListItem.AppearanceItemCaption.Options.UseTextOptions = true;
            this.checkedListItem.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.checkedListItem.Location = new System.Drawing.Point(0, 36);
            this.checkedListItem.Size = new System.Drawing.Size(281, 191);
            // 
            // addItem
            // 
            this.addItem.Location = new System.Drawing.Point(0, 352);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.Size = new System.Drawing.Size(83, 419);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.Size = new System.Drawing.Size(281, 89);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.Location = new System.Drawing.Point(92, 352);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 390);
            // 
            // lookUpEdit
            // 
            this.lookUpEdit.Location = new System.Drawing.Point(98, 28);
            this.lookUpEdit.Name = "lookUpEdit";
            this.lookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit.Size = new System.Drawing.Size(195, 20);
            this.lookUpEdit.StyleController = this.layoutControl;
            this.lookUpEdit.TabIndex = 12;
            // 
            // newScopeItem
            // 
            this.newScopeItem.Control = this.lookUpEdit;
            this.newScopeItem.Location = new System.Drawing.Point(0, 0);
            this.newScopeItem.Name = "newScopeItem";
            this.newScopeItem.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.newScopeItem.Size = new System.Drawing.Size(281, 36);
            this.newScopeItem.Text = "New scope:";
            this.newScopeItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.newScopeItem.TextSize = new System.Drawing.Size(65, 20);
            this.newScopeItem.TextToControlDistance = 5;
            // 
            // TabScopeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TabScopeView";
            this.Size = new System.Drawing.Size(404, 459);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newScopeItem)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem newScopeItem;
    }
}
