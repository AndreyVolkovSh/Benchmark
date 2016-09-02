namespace Benchmark.Win.Views {
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
            this.checkedListLabel = new DevExpress.XtraEditors.LabelControl();
            this.textEditLabel = new DevExpress.XtraEditors.LabelControl();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.nameColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(40, 357);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(76, 23);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Add";
            // 
            // checkedListLabel
            // 
            this.checkedListLabel.Location = new System.Drawing.Point(19, 62);
            this.checkedListLabel.Name = "checkedListLabel";
            this.checkedListLabel.Size = new System.Drawing.Size(29, 13);
            this.checkedListLabel.TabIndex = 8;
            this.checkedListLabel.Text = "Label:";
            // 
            // textEditLabel
            // 
            this.textEditLabel.Location = new System.Drawing.Point(19, 28);
            this.textEditLabel.Name = "textEditLabel";
            this.textEditLabel.Size = new System.Drawing.Size(29, 13);
            this.textEditLabel.TabIndex = 7;
            this.textEditLabel.Text = "Label:";
            // 
            // treeList
            // 
            this.treeList.CheckBoxFieldName = "Checked";
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.nameColumn});
            this.treeList.Location = new System.Drawing.Point(97, 62);
            this.treeList.Name = "treeList";
            this.treeList.OptionsView.ShowCheckBoxes = true;
            this.treeList.OptionsView.ShowColumns = false;
            this.treeList.OptionsView.ShowHorzLines = false;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.OptionsView.ShowRoot = false;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.Size = new System.Drawing.Size(233, 260);
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
            // TabBaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.checkedListLabel);
            this.Controls.Add(this.textEditLabel);
            this.Name = "TabBaseView";
            this.Size = new System.Drawing.Size(366, 407);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton addButton;
        private DevExpress.XtraEditors.LabelControl checkedListLabel;
        private DevExpress.XtraEditors.LabelControl textEditLabel;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn nameColumn;
    }
}
