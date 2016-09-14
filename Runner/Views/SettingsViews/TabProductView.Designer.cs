namespace Benchmark.Views {
    partial class TabProductView {
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
            this.textEdit = new DevExpress.XtraEditors.TextEdit();
            this.newProductItem = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newProductItem)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(28, 362);
            // 
            // searchControl
            // 
            this.searchControl.Location = new System.Drawing.Point(98, 245);
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.textEdit);
            this.layoutControl.Size = new System.Drawing.Size(438, 441);
            this.layoutControl.Controls.SetChildIndex(this.searchControl, 0);
            this.layoutControl.Controls.SetChildIndex(this.addButton, 0);
            this.layoutControl.Controls.SetChildIndex(this.textEdit, 0);
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.newProductItem});
            this.layoutControlGroup.Size = new System.Drawing.Size(438, 441);
            // 
            // checkedListItem
            // 
            this.checkedListItem.AppearanceItemCaption.Options.UseTextOptions = true;
            this.checkedListItem.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.checkedListItem.Location = new System.Drawing.Point(0, 36);
            this.checkedListItem.Size = new System.Drawing.Size(281, 181);
            // 
            // searchItem
            // 
            this.searchItem.Location = new System.Drawing.Point(70, 217);
            // 
            // addItem
            // 
            this.addItem.Location = new System.Drawing.Point(0, 334);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.Size = new System.Drawing.Size(117, 401);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 253);
            this.emptySpaceItem2.Size = new System.Drawing.Size(281, 81);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 217);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.Location = new System.Drawing.Point(92, 334);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 372);
            // 
            // textEdit
            // 
            this.textEdit.Location = new System.Drawing.Point(97, 28);
            this.textEdit.Name = "textEdit";
            this.textEdit.Size = new System.Drawing.Size(196, 20);
            this.textEdit.StyleController = this.layoutControl;
            this.textEdit.TabIndex = 12;
            // 
            // newProductItem
            // 
            this.newProductItem.Control = this.textEdit;
            this.newProductItem.Location = new System.Drawing.Point(0, 0);
            this.newProductItem.MaxSize = new System.Drawing.Size(281, 36);
            this.newProductItem.MinSize = new System.Drawing.Size(281, 36);
            this.newProductItem.Name = "newProductItem";
            this.newProductItem.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.newProductItem.Size = new System.Drawing.Size(281, 36);
            this.newProductItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.newProductItem.Text = "New product:";
            this.newProductItem.TextSize = new System.Drawing.Size(65, 13);
            // 
            // TabProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TabProductView";
            this.Size = new System.Drawing.Size(438, 441);
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
            ((System.ComponentModel.ISupportInitialize)(this.textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newProductItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit;
        private DevExpress.XtraLayout.LayoutControlItem newProductItem;
    }
}