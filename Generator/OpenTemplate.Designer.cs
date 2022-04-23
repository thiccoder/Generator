namespace Generator
{
    partial class OpenTemplate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MetadataPathBox = new System.Windows.Forms.TextBox();
            this.TemplatePathBox = new System.Windows.Forms.TextBox();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.TemplateBrowseButton = new System.Windows.Forms.Button();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.MetadataBrowseButton = new System.Windows.Forms.Button();
            this.MetadataGroupBox = new System.Windows.Forms.GroupBox();
            this.TemplateGroupBox = new System.Windows.Forms.GroupBox();
            this.MetadataGroupBox.SuspendLayout();
            this.TemplateGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MetadataSelectBox
            // 
            this.MetadataPathBox.Location = new System.Drawing.Point(6, 22);
            this.MetadataPathBox.Name = "MetadataSelectBox";
            this.MetadataPathBox.Size = new System.Drawing.Size(320, 23);
            this.MetadataPathBox.TabIndex = 0;
            this.MetadataPathBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // TemplateSelectBox
            // 
            this.TemplatePathBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TemplatePathBox.Location = new System.Drawing.Point(6, 22);
            this.TemplatePathBox.Name = "TemplateSelectBox";
            this.TemplatePathBox.Size = new System.Drawing.Size(320, 23);
            this.TemplatePathBox.TabIndex = 2;
            this.TemplatePathBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // ButtonOk
            // 
            this.ButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOk.Enabled = false;
            this.ButtonOk.Location = new System.Drawing.Point(140, 140);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 4;
            this.ButtonOk.Text = "OK";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(221, 140);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // TemplateBrowseButton
            // 
            this.TemplateBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TemplateBrowseButton.Location = new System.Drawing.Point(332, 21);
            this.TemplateBrowseButton.Name = "TemplateBrowseButton";
            this.TemplateBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.TemplateBrowseButton.TabIndex = 3;
            this.TemplateBrowseButton.Text = "Browse";
            this.TemplateBrowseButton.UseVisualStyleBackColor = true;
            this.TemplateBrowseButton.Click += new System.EventHandler(this.TemplateBrowseButton_Click);
            // 
            // OpenDialog
            // 
            this.OpenDialog.DefaultExt = "json";
            this.OpenDialog.FileName = "openFileDialog";
            this.OpenDialog.Filter = "Metadata files (*.json)|*.json|All files (*.*)|*.*";
            // 
            // MetadataBrowseButton
            // 
            this.MetadataBrowseButton.Location = new System.Drawing.Point(332, 21);
            this.MetadataBrowseButton.Name = "MetadataBrowseButton";
            this.MetadataBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.MetadataBrowseButton.TabIndex = 1;
            this.MetadataBrowseButton.Text = "Browse";
            this.MetadataBrowseButton.UseVisualStyleBackColor = true;
            this.MetadataBrowseButton.Click += new System.EventHandler(this.MetadataBrowseButton_Click);
            // 
            // MetadataGroupBox
            // 
            this.MetadataGroupBox.Controls.Add(this.MetadataPathBox);
            this.MetadataGroupBox.Controls.Add(this.MetadataBrowseButton);
            this.MetadataGroupBox.Location = new System.Drawing.Point(12, 12);
            this.MetadataGroupBox.Name = "MetadataGroupBox";
            this.MetadataGroupBox.Size = new System.Drawing.Size(413, 57);
            this.MetadataGroupBox.TabIndex = 6;
            this.MetadataGroupBox.TabStop = false;
            this.MetadataGroupBox.Text = "hot *.json files in your area";
            // 
            // TemplateGroupBox
            // 
            this.TemplateGroupBox.Controls.Add(this.TemplatePathBox);
            this.TemplateGroupBox.Controls.Add(this.TemplateBrowseButton);
            this.TemplateGroupBox.Location = new System.Drawing.Point(12, 75);
            this.TemplateGroupBox.Name = "TemplateGroupBox";
            this.TemplateGroupBox.Size = new System.Drawing.Size(413, 52);
            this.TemplateGroupBox.TabIndex = 7;
            this.TemplateGroupBox.TabStop = false;
            this.TemplateGroupBox.Text = "hot *.dotx files in your area";
            // 
            // OpenTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 175);
            this.Icon = global::Generator.Properties.Resources.Icon;
            this.Controls.Add(this.TemplateGroupBox);
            this.Controls.Add(this.MetadataGroupBox);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenTemplate";
            this.Text = "Open";
            this.Load += new System.EventHandler(this.OpenTemplate_Load);
            this.MetadataGroupBox.ResumeLayout(false);
            this.TemplateGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox MetadataPathBox;
        private TextBox TemplatePathBox;
        private Button ButtonOk;
        private Button ButtonCancel;
        private Button TemplateBrowseButton;
        private Button MetadataBrowseButton;
        private OpenFileDialog OpenDialog;
        private GroupBox MetadataGroupBox;
        private GroupBox TemplateGroupBox;
    }
}