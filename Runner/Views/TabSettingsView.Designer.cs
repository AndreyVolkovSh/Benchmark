namespace Benchmark.Win.Views {
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
            this.toolVersionLabel = new DevExpress.XtraEditors.LabelControl();
            this.frameworkLabel = new DevExpress.XtraEditors.LabelControl();
            this.platformLabel = new DevExpress.XtraEditors.LabelControl();
            this.platformComboBox = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.frameworkLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.toolVersionLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.enableNGen = new DevExpress.XtraEditors.CheckEdit();
            this.buildSolutionsButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.platformComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameworkLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolVersionLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableNGen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolVersionLabel
            // 
            this.toolVersionLabel.Location = new System.Drawing.Point(40, 75);
            this.toolVersionLabel.Name = "toolVersionLabel";
            this.toolVersionLabel.Size = new System.Drawing.Size(62, 13);
            this.toolVersionLabel.TabIndex = 25;
            this.toolVersionLabel.Text = "Tool version:";
            // 
            // frameworkLabel
            // 
            this.frameworkLabel.Location = new System.Drawing.Point(40, 49);
            this.frameworkLabel.Name = "frameworkLabel";
            this.frameworkLabel.Size = new System.Drawing.Size(57, 13);
            this.frameworkLabel.TabIndex = 24;
            this.frameworkLabel.Text = "Framework:";
            // 
            // platformLabel
            // 
            this.platformLabel.Location = new System.Drawing.Point(40, 27);
            this.platformLabel.Name = "platformLabel";
            this.platformLabel.Size = new System.Drawing.Size(44, 13);
            this.platformLabel.TabIndex = 23;
            this.platformLabel.Text = "Platform:";
            // 
            // platformComboBox
            // 
            this.platformComboBox.Location = new System.Drawing.Point(176, 24);
            this.platformComboBox.Name = "platformComboBox";
            this.platformComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.platformComboBox.Size = new System.Drawing.Size(152, 20);
            this.platformComboBox.TabIndex = 18;
            // 
            // frameworkLookUp
            // 
            this.frameworkLookUp.Location = new System.Drawing.Point(176, 50);
            this.frameworkLookUp.Name = "frameworkLookUp";
            this.frameworkLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.frameworkLookUp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.frameworkLookUp.Size = new System.Drawing.Size(152, 20);
            this.frameworkLookUp.TabIndex = 19;
            // 
            // toolVersionLookUp
            // 
            this.toolVersionLookUp.Location = new System.Drawing.Point(176, 76);
            this.toolVersionLookUp.Name = "toolVersionLookUp";
            this.toolVersionLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toolVersionLookUp.Size = new System.Drawing.Size(152, 20);
            this.toolVersionLookUp.TabIndex = 20;
            // 
            // enableNGen
            // 
            this.enableNGen.EditValue = true;
            this.enableNGen.Location = new System.Drawing.Point(176, 102);
            this.enableNGen.Name = "enableNGen";
            this.enableNGen.Properties.Caption = "Enable nGen";
            this.enableNGen.Size = new System.Drawing.Size(103, 19);
            this.enableNGen.TabIndex = 21;
            // 
            // buildSolutionsButton
            // 
            this.buildSolutionsButton.Location = new System.Drawing.Point(40, 357);
            this.buildSolutionsButton.Name = "buildSolutionsButton";
            this.buildSolutionsButton.Size = new System.Drawing.Size(78, 24);
            this.buildSolutionsButton.TabIndex = 22;
            this.buildSolutionsButton.Text = "Build solutions";
            // 
            // TabSettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolVersionLabel);
            this.Controls.Add(this.frameworkLabel);
            this.Controls.Add(this.platformLabel);
            this.Controls.Add(this.platformComboBox);
            this.Controls.Add(this.frameworkLookUp);
            this.Controls.Add(this.toolVersionLookUp);
            this.Controls.Add(this.enableNGen);
            this.Controls.Add(this.buildSolutionsButton);
            this.Name = "TabSettingsView";
            this.Size = new System.Drawing.Size(440, 397);
            ((System.ComponentModel.ISupportInitialize)(this.platformComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameworkLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolVersionLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableNGen.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl toolVersionLabel;
        private DevExpress.XtraEditors.LabelControl frameworkLabel;
        private DevExpress.XtraEditors.LabelControl platformLabel;
        private DevExpress.XtraEditors.ImageComboBoxEdit platformComboBox;
        private DevExpress.XtraEditors.LookUpEdit frameworkLookUp;
        private DevExpress.XtraEditors.LookUpEdit toolVersionLookUp;
        private DevExpress.XtraEditors.CheckEdit enableNGen;
        private DevExpress.XtraEditors.SimpleButton buildSolutionsButton;
    }
}
