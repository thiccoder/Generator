﻿namespace Generator
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainSplit = new System.Windows.Forms.SplitContainer();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.InputTreeSplit = new System.Windows.Forms.SplitContainer();
            this.ToolTipSplit = new System.Windows.Forms.SplitContainer();
            this.ToolTipLabel = new System.Windows.Forms.Label();
            this.TreeBrowserSplit = new System.Windows.Forms.SplitContainer();
            this.Fields = new System.Windows.Forms.TreeView();
            this.Preview = new System.Windows.Forms.WebBrowser();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
            this.MainSplit.Panel1.SuspendLayout();
            this.MainSplit.Panel2.SuspendLayout();
            this.MainSplit.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputTreeSplit)).BeginInit();
            this.InputTreeSplit.Panel1.SuspendLayout();
            this.InputTreeSplit.Panel2.SuspendLayout();
            this.InputTreeSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolTipSplit)).BeginInit();
            this.ToolTipSplit.Panel2.SuspendLayout();
            this.ToolTipSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeBrowserSplit)).BeginInit();
            this.TreeBrowserSplit.Panel1.SuspendLayout();
            this.TreeBrowserSplit.Panel2.SuspendLayout();
            this.TreeBrowserSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainSplit
            // 
            this.MainSplit.BackColor = System.Drawing.SystemColors.Control;
            this.MainSplit.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.MainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MainSplit.IsSplitterFixed = true;
            this.MainSplit.Location = new System.Drawing.Point(0, 0);
            this.MainSplit.Name = "MainSplit";
            this.MainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplit.Panel1
            // 
            this.MainSplit.Panel1.Controls.Add(this.MenuStrip);
            // 
            // MainSplit.Panel2
            // 
            this.MainSplit.Panel2.Controls.Add(this.InputTreeSplit);
            this.MainSplit.Size = new System.Drawing.Size(985, 489);
            this.MainSplit.SplitterDistance = 25;
            this.MainSplit.TabIndex = 1;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileTSMI,
            this.HelpTSMI});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(985, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // FileTSMI
            // 
            this.FileTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenTSMI,
            this.SaveTSMI,
            this.SaveAsTSMI,
            this.QuitTSMI});
            this.FileTSMI.Name = "FileTSMI";
            this.FileTSMI.Size = new System.Drawing.Size(37, 20);
            this.FileTSMI.Text = "File";
            // 
            // OpenTSMI
            // 
            this.OpenTSMI.Name = "OpenTSMI";
            this.OpenTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenTSMI.Size = new System.Drawing.Size(190, 22);
            this.OpenTSMI.Text = "Оpen";
            this.OpenTSMI.Click += new System.EventHandler(this.OpenTSMI_Click);
            // 
            // SaveTSMI
            // 
            this.SaveTSMI.Name = "SaveTSMI";
            this.SaveTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveTSMI.Size = new System.Drawing.Size(190, 22);
            this.SaveTSMI.Text = "Save";
            this.SaveTSMI.Click += new System.EventHandler(this.SaveTSMI_Click);
            // 
            // SaveAsTSMI
            // 
            this.SaveAsTSMI.Name = "SaveAsTSMI";
            this.SaveAsTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAsTSMI.Size = new System.Drawing.Size(190, 22);
            this.SaveAsTSMI.Text = "Save as";
            this.SaveAsTSMI.Click += new System.EventHandler(this.SaveAsTSMI_Click);
            // 
            // QuitTSMI
            // 
            this.QuitTSMI.Name = "QuitTSMI";
            this.QuitTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.QuitTSMI.ShowShortcutKeys = false;
            this.QuitTSMI.Size = new System.Drawing.Size(190, 22);
            this.QuitTSMI.Text = "Quit";
            this.QuitTSMI.Click += new System.EventHandler(this.QuitTSMI_Click);
            // 
            // HelpTSMI
            //
            this.HelpTSMI.Name = "HelpTSMI";
            this.HelpTSMI.Size = new System.Drawing.Size(44, 20);
            this.HelpTSMI.Text = "Help";
            // 
            // InputTreeSplit
            // 
            this.InputTreeSplit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InputTreeSplit.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.InputTreeSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputTreeSplit.Location = new System.Drawing.Point(0, 0);
            this.InputTreeSplit.Name = "InputTreeSplit";
            // 
            // InputTreeSplit.Panel1
            // 
            this.InputTreeSplit.Panel1.Controls.Add(this.ToolTipSplit);
            this.InputTreeSplit.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // InputTreeSplit.Panel2
            // 
            this.InputTreeSplit.Panel2.Controls.Add(this.TreeBrowserSplit);
            this.InputTreeSplit.Size = new System.Drawing.Size(985, 460);
            this.InputTreeSplit.SplitterDistance = 360;
            this.InputTreeSplit.TabIndex = 0;
            // 
            // ToolTipSplit
            // 
            this.ToolTipSplit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ToolTipSplit.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.ToolTipSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolTipSplit.Location = new System.Drawing.Point(0, 0);
            this.ToolTipSplit.Name = "ToolTipSplit";
            this.ToolTipSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ToolTipSplit.Panel1
            // 
            this.ToolTipSplit.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // ToolTipSplit.Panel2
            // 
            this.ToolTipSplit.Panel2.Controls.Add(this.ToolTipLabel);
            this.ToolTipSplit.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.ToolTipSplit.Size = new System.Drawing.Size(360, 460);
            this.ToolTipSplit.SplitterDistance = 315;
            this.ToolTipSplit.TabIndex = 0;
            // 
            // ToolTipLabel
            // 
            this.ToolTipLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolTipLabel.Location = new System.Drawing.Point(0, 0);
            this.ToolTipLabel.Name = "ToolTipLabel";
            this.ToolTipLabel.Size = new System.Drawing.Size(356, 137);
            this.ToolTipLabel.TabIndex = 0;
            this.ToolTipLabel.Text = "ToolTip";
            this.ToolTipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TreeBrowserSplit
            // 
            this.TreeBrowserSplit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TreeBrowserSplit.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.TreeBrowserSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeBrowserSplit.Location = new System.Drawing.Point(0, 0);
            this.TreeBrowserSplit.Name = "TreeBrowserSplit";
            // 
            // TreeBrowserSplit.Panel1
            // 
            this.TreeBrowserSplit.Panel1.Controls.Add(this.Fields);
            this.TreeBrowserSplit.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // TreeBrowserSplit.Panel2
            // 
            this.TreeBrowserSplit.Panel2.Controls.Add(this.Preview);
            this.TreeBrowserSplit.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.TreeBrowserSplit.Size = new System.Drawing.Size(621, 460);
            this.TreeBrowserSplit.SplitterDistance = 216;
            this.TreeBrowserSplit.TabIndex = 0;
            // 
            // Fields
            // 
            this.Fields.BackColor = System.Drawing.SystemColors.Control;
            this.Fields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fields.HideSelection = false;
            this.Fields.Location = new System.Drawing.Point(0, 0);
            this.Fields.Name = "Fields";
            this.Fields.Size = new System.Drawing.Size(212, 456);
            this.Fields.TabIndex = 1;
            this.Fields.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // Preview
            // 
            this.Preview.AllowWebBrowserDrop = false;
            this.Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Preview.IsWebBrowserContextMenuEnabled = false;
            this.Preview.Location = new System.Drawing.Point(0, 0);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(397, 456);
            this.Preview.TabIndex = 2;
            this.Preview.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.Preview_DocumentCompleted);
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.Filter = "OpenDocument Text files (*.odt)|*.odt|All files (*.*)|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 489);
            this.Controls.Add(this.MainSplit);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = global::Generator.Properties.Resources.Icon;
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.Text = "Generator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainSplit.Panel1.ResumeLayout(false);
            this.MainSplit.Panel1.PerformLayout();
            this.MainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).EndInit();
            this.MainSplit.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.InputTreeSplit.Panel1.ResumeLayout(false);
            this.InputTreeSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InputTreeSplit)).EndInit();
            this.InputTreeSplit.ResumeLayout(false);
            this.ToolTipSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ToolTipSplit)).EndInit();
            this.ToolTipSplit.ResumeLayout(false);
            this.TreeBrowserSplit.Panel1.ResumeLayout(false);
            this.TreeBrowserSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeBrowserSplit)).EndInit();
            this.TreeBrowserSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SplitContainer MainSplit;
        private SplitContainer InputTreeSplit;
        private SplitContainer TreeBrowserSplit;
        private TreeView Fields;
        private WebBrowser Preview;
        private MenuStrip MenuStrip;
        private ToolStripMenuItem FileTSMI;
        private ToolStripMenuItem OpenTSMI;
        private ToolStripMenuItem SaveTSMI;
        private ToolStripMenuItem SaveAsTSMI;
        private ToolStripMenuItem QuitTSMI;
        private ToolStripMenuItem HelpTSMI;
        private SaveFileDialog SaveFileDialog;
        private SplitContainer ToolTipSplit;
        private Label ToolTipLabel;
    }
}

