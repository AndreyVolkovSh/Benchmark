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
            ((System.ComponentModel.ISupportInitialize)(this.textEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit
            // 
            this.textEdit.Location = new System.Drawing.Point(97, 25);
            this.textEdit.Name = "textEdit";
            this.textEdit.Size = new System.Drawing.Size(233, 20);
            this.textEdit.TabIndex = 10;
            // 
            // TabProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textEdit);
            this.Name = "TabProductView";
            this.Size = new System.Drawing.Size(447, 457);
            this.Controls.SetChildIndex(this.textEdit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit;
    }
}
