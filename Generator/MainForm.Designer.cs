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
            this.InputTreeSplit = new System.Windows.Forms.SplitContainer();
            this.TreeBrowserSplit = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.generateButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputTreeSplit)).BeginInit();
            this.InputTreeSplit.Panel2.SuspendLayout();
            this.InputTreeSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeBrowserSplit)).BeginInit();
            this.TreeBrowserSplit.Panel1.SuspendLayout();
            this.TreeBrowserSplit.Panel2.SuspendLayout();
            this.TreeBrowserSplit.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.IsSplitterFixed = true;
            this.mainSplit.Location = new System.Drawing.Point(0, 0);
            this.mainSplit.Name = "mainSplit";
            this.mainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.InputTreeSplit);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.toolStrip);
            this.mainSplit.Size = new System.Drawing.Size(985, 489);
            this.mainSplit.SplitterDistance = 455;
            this.mainSplit.TabIndex = 1;
            // 
            // InputTreeSplit
            // 
            this.InputTreeSplit.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.InputTreeSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputTreeSplit.Location = new System.Drawing.Point(0, 0);
            this.InputTreeSplit.Name = "InputTreeSplit";
            // 
            // InputTreeSplit.Panel2
            // 
            this.InputTreeSplit.Panel2.Controls.Add(this.TreeBrowserSplit);
            this.InputTreeSplit.Size = new System.Drawing.Size(985, 455);
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
            // 
            // TreeBrowserSplit.Panel2
            // 
            this.TreeBrowserSplit.Panel2.Controls.Add(this.webBrowser);
            this.TreeBrowserSplit.Size = new System.Drawing.Size(621, 455);
            this.TreeBrowserSplit.SplitterDistance = 216;
            this.TreeBrowserSplit.TabIndex = 0;
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.SystemColors.Control;
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.HideSelection = false;
            this.treeView.LineColor = System.Drawing.Color.Gray;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(216, 455);
            this.treeView.TabIndex = 1;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(401, 455);
            this.webBrowser.TabIndex = 2;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser_DocumentCompleted);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateButton});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(985, 30);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            // 
            // generateButton
            // 
            this.generateButton.BackColor = System.Drawing.SystemColors.Control;
            this.generateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.generateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.generateButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.generateButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.generateButton.ImageTransparentColor = System.Drawing.SystemColors.ControlText;
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(58, 27);
            this.generateButton.Text = "Generate";
            this.generateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.generateButton.Click += new System.EventHandler(this.Generate);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 489);
            this.Controls.Add(this.mainSplit);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            this.mainSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.InputTreeSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InputTreeSplit)).EndInit();
            this.InputTreeSplit.ResumeLayout(false);
            this.TreeBrowserSplit.Panel1.ResumeLayout(false);
            this.TreeBrowserSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeBrowserSplit)).EndInit();
            this.TreeBrowserSplit.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private SplitContainer mainSplit;
        private SplitContainer InputTreeSplit;
        private ToolStrip toolStrip;
        private ToolStripButton generateButton;
        private SplitContainer TreeBrowserSplit;
        private TreeView treeView;
        private WebBrowser webBrowser;
    }
}

