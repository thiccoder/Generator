namespace Generator
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
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.openTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.quitTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.editTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.helpTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.InputTreeSplit = new System.Windows.Forms.SplitContainer();
            this.TreeBrowserSplit = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.menuSplit = new System.Windows.Forms.SplitContainer();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputTreeSplit)).BeginInit();
            this.InputTreeSplit.Panel2.SuspendLayout();
            this.InputTreeSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeBrowserSplit)).BeginInit();
            this.TreeBrowserSplit.Panel1.SuspendLayout();
            this.TreeBrowserSplit.Panel2.SuspendLayout();
            this.TreeBrowserSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuSplit)).BeginInit();
            this.menuSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplit
            // 
            this.mainSplit.BackColor = System.Drawing.SystemColors.Window;
            this.mainSplit.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainSplit.IsSplitterFixed = true;
            this.mainSplit.Location = new System.Drawing.Point(0, 0);
            this.mainSplit.Name = "mainSplit";
            this.mainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.menuStrip);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.InputTreeSplit);
            this.mainSplit.Size = new System.Drawing.Size(985, 489);
            this.mainSplit.SplitterDistance = 25;
            this.mainSplit.TabIndex = 1;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileTSMI,
            this.editTSMI,
            this.helpTSMI});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(985, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileTSMI
            // 
            this.fileTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTSMI,
            this.saveTSMI,
            this.saveAsTSMI,
            this.quitTSMI});
            this.fileTSMI.Name = "fileTSMI";
            this.fileTSMI.Size = new System.Drawing.Size(37, 20);
            this.fileTSMI.Text = "File";
            // 
            // openTSMI
            // 
            this.openTSMI.Name = "openTSMI";
            this.openTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openTSMI.Size = new System.Drawing.Size(190, 22);
            this.openTSMI.Text = "Оpen";
            this.openTSMI.Click += new System.EventHandler(this.OpenTSMI_Click);
            // 
            // saveTSMI
            // 
            this.saveTSMI.Name = "saveTSMI";
            this.saveTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveTSMI.Size = new System.Drawing.Size(190, 22);
            this.saveTSMI.Text = "Save";
            this.saveTSMI.Click += new System.EventHandler(this.SaveTSMI_Click);
            // 
            // saveAsTSMI
            // 
            this.saveAsTSMI.Name = "saveAsTSMI";
            this.saveAsTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsTSMI.Size = new System.Drawing.Size(190, 22);
            this.saveAsTSMI.Text = "Save as";
            this.saveAsTSMI.Click += new System.EventHandler(this.SaveAsTSMI_Click);
            // 
            // quitTSMI
            // 
            this.quitTSMI.Name = "quitTSMI";
            this.quitTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitTSMI.ShowShortcutKeys = false;
            this.quitTSMI.Size = new System.Drawing.Size(190, 22);
            this.quitTSMI.Text = "Quit";
            this.quitTSMI.Click += new System.EventHandler(this.QuitTSMI_Click);
            // 
            // editTSMI
            // 
            this.editTSMI.Name = "editTSMI";
            this.editTSMI.Size = new System.Drawing.Size(39, 20);
            this.editTSMI.Text = "Edit";
            // 
            // helpTSMI
            // 
            this.helpTSMI.Name = "helpTSMI";
            this.helpTSMI.Size = new System.Drawing.Size(44, 20);
            this.helpTSMI.Text = "Help";
            // 
            // InputTreeSplit
            // 
            this.InputTreeSplit.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.InputTreeSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputTreeSplit.Location = new System.Drawing.Point(0, 0);
            this.InputTreeSplit.Name = "InputTreeSplit";
            // 
            // InputTreeSplit.Panel1
            // 
            this.InputTreeSplit.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.InputTreeSplit.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // InputTreeSplit.Panel2
            // 
            this.InputTreeSplit.Panel2.Controls.Add(this.TreeBrowserSplit);
            this.InputTreeSplit.Size = new System.Drawing.Size(985, 460);
            this.InputTreeSplit.SplitterDistance = 360;
            this.InputTreeSplit.TabIndex = 0;
            // 
            // TreeBrowserSplit
            // 
            this.TreeBrowserSplit.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.TreeBrowserSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeBrowserSplit.Location = new System.Drawing.Point(0, 0);
            this.TreeBrowserSplit.Name = "TreeBrowserSplit";
            // 
            // TreeBrowserSplit.Panel1
            // 
            this.TreeBrowserSplit.Panel1.Controls.Add(this.treeView);
            this.TreeBrowserSplit.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // TreeBrowserSplit.Panel2
            // 
            this.TreeBrowserSplit.Panel2.Controls.Add(this.webBrowser);
            this.TreeBrowserSplit.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.TreeBrowserSplit.Size = new System.Drawing.Size(621, 460);
            this.TreeBrowserSplit.SplitterDistance = 216;
            this.TreeBrowserSplit.TabIndex = 0;
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.SystemColors.Window;
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.HideSelection = false;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(216, 460);
            this.treeView.TabIndex = 1;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(401, 460);
            this.webBrowser.TabIndex = 2;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser_DocumentCompleted);
            // 
            // menuSplit
            // 
            this.menuSplit.Location = new System.Drawing.Point(0, 0);
            this.menuSplit.Name = "menuSplit";
            this.menuSplit.Size = new System.Drawing.Size(150, 100);
            this.menuSplit.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "dotx";
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "XML document files (*.xml)|*.xml|All files (*.*)|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Word document files (*.docx)|*.docx|All files (*.*)|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 489);
            this.Controls.Add(this.mainSplit);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = global::Generator.Properties.Resources.Icon;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Generator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel1.PerformLayout();
            this.mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.InputTreeSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InputTreeSplit)).EndInit();
            this.InputTreeSplit.ResumeLayout(false);
            this.TreeBrowserSplit.Panel1.ResumeLayout(false);
            this.TreeBrowserSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeBrowserSplit)).EndInit();
            this.TreeBrowserSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuSplit)).EndInit();
            this.menuSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SplitContainer mainSplit;
        private SplitContainer InputTreeSplit;
        private SplitContainer TreeBrowserSplit;
        private TreeView treeView;
        private WebBrowser webBrowser;
        private SplitContainer menuSplit;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileTSMI;
        private ToolStripMenuItem openTSMI;
        private ToolStripMenuItem saveTSMI;
        private ToolStripMenuItem saveAsTSMI;
        private ToolStripMenuItem quitTSMI;
        private ToolStripMenuItem editTSMI;
        private ToolStripMenuItem helpTSMI;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
    }
}

