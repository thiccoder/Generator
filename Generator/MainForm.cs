using Word = Microsoft.Office.Interop.Word;
using System.Xml;
using MSHTML;
using System.IO;

namespace Generator
{
    public partial class MainForm : Form
    {

        private readonly Word.Application wordApp = new() { Visible = false };
        private readonly List<Field> fields = new();
        private readonly List<TreeNode> treeNodes = new();
        private readonly List<Control> controls = new();
        private readonly Dictionary<Field, IHTMLTxtRange> ranges = new();
        private int currentIdx = 0;
        private readonly string files = Environment.CurrentDirectory + "\\..\\..\\..\\files";
        private string CurrentTemplate = "";
        private string CurrentXmlFile = "";
        private string CurrentSaveFile = "";
        public MainForm()
        {
            InitializeComponent();
        }
        private void ParseNodes(XmlNode xmlNode)
        {
            if (xmlNode.Name == "field")
            {
                fields.Add(new Field(xmlNode));
            }
            else foreach (XmlNode node in xmlNode.ChildNodes)
                {
                    if (node.HasChildNodes)
                        ParseNodes(node);
                }
        }
        private void ReadXML(string fileName)
        {
            XmlDocument doc = new();
            doc.Load(fileName);
            treeView.Nodes.Clear();
            ParseNodes(doc.DocumentElement);
            TreeNode[] nodes = new TreeNode[fields.Count];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new TreeNode(fields[i].Name);
                treeNodes.Add(nodes[i]);
                Control control;
                switch (fields[i].Type)
                {
                    case FieldType.Number:
                        NumericUpDown TBN = new()
                        {
                            AllowDrop = true,
                            BackColor = SystemColors.Control,
                            Dock = DockStyle.Fill,
                            Location = new Point(0, 0),
                            Name = "control",
                            Size = new Size(500, 500),
                            TabIndex = 0,
                            Enabled = false,
                            Visible = false
                        };
                        control = TBN;
                        break;
                    case FieldType.Date:
                        MonthCalendar TBD = new()
                        {
                            CalendarDimensions = new Size(3, 4),
                            Dock = DockStyle.Fill,
                            Location = new Point(0, 0),
                            MaxSelectionCount = 1,
                            Name = "control",
                            TabIndex = 0,
                            Enabled = false,
                            Visible = false,
                            BackColor = SystemColors.Control
                        };
                        control = TBD;
                        break;
                    case FieldType.Choice:
                        ComboBox TBC = new()
                        {
                            Dock = DockStyle.Fill,
                            FormattingEnabled = true,
                            Location = new Point(0, 0),
                            Name = "control",
                            Size = new Size(500, 25),
                            TabIndex = 0,
                            Enabled = false,
                            Visible = false
                        };
                        TBC.Items.AddRange(fields[i].options.ToArray());
                        control = TBC;
                        break;
                    default:
                        TextBox TBT = new()
                        {
                            AcceptsReturn = true,
                            AcceptsTab = true,
                            AllowDrop = true,
                            BackColor = SystemColors.Control,
                            Dock = DockStyle.Fill,
                            Location = new Point(0, 0),
                            Multiline = true,
                            Name = "control",
                            Size = new Size(500, 500),
                            TabIndex = 0,
                            Enabled = false,
                            Visible = false
                        };
                        control = TBT;
                        break;
                }
                controls.Add(control);
                InputTreeSplit.Panel1.Controls.Add(control);
            }
            treeView.Nodes.AddRange(nodes);
            currentIdx = 0;
            treeView.SelectedNode = nodes[0];
        }
        private static void Convert(Word.Document doc, string outFile, Word.WdSaveFormat format)
        {
            object oMissing = Type.Missing;
            object oOutput = outFile;
            object oFormat = format;
            doc.SaveAs(ref oOutput, ref oFormat, ref oMissing, ref oMissing,
              ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
              ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing
              );
        }
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int idx = treeNodes.IndexOf(e.Node);
            Field cf = fields[currentIdx];
            if (cf.Type != FieldType.Date)
                cf.Value = controls[currentIdx].Text;
            else cf.Value = (controls[currentIdx] as MonthCalendar).SelectionStart.ToLongDateString().Trim('.');
            controls[currentIdx].Enabled = false;
            controls[currentIdx].Visible = false;
            controls[idx].Enabled = true;
            controls[idx].Visible = true;
            currentIdx = idx;
            cf = fields[currentIdx];
            if (ranges.ContainsKey(cf))
            {
                IHTMLTxtRange range = ranges[cf];
                range.pasteHTML(cf.Value);
                range.collapse();
                range.moveStart("character", -cf.Value.Length);
                range.select();
            }

        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            wordApp.Quit();
        }
        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            while (ranges.Count == 0)
            {
                if (webBrowser.Document != null)
                {
                    if (webBrowser.Document.DomDocument is IHTMLDocument2 doc)
                    {
                        if (doc.body is IHTMLBodyElement bodyElement)
                        {
                            foreach (Field field in fields)
                            {
                                IHTMLTxtRange range = bodyElement.createTextRange();
                                if (range != null)
                                {
                                    string search = field.Mask;
                                    if (range.findText(search, search.Length, 2))
                                    {
                                        ranges[field] = range;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void OpenTSMI_Click(object sender, EventArgs e)
        {
            bool xmlRead = false;
            bool dotxRead = false;
            while (!(xmlRead && dotxRead))
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    if (!xmlRead)
                    {
                        CurrentXmlFile = fileName;
                        ReadXML(fileName);
                        xmlRead = true;
                        openFileDialog.Filter = openFileDialog.Filter.Replace("XML document files (*.xml)|*.xml", "Word Template files (*.dotx)|*.dotx");
                    }
                    else if (!dotxRead)
                    {
                        string html = files + "\\tmp.html";
                        Word.Document doc = wordApp.Documents.Open(fileName);
                        doc.Activate();
                        Convert(doc, html, Word.WdSaveFormat.wdFormatHTML);
                        doc.Close();
                        webBrowser.Navigate(files + "\\tmp.html");
                        dotxRead = true;
                        openFileDialog.Filter = openFileDialog.Filter.Replace("Word Template files (*.dotx)|*.dotx|", "");
                        CurrentTemplate = fileName;
                    }
                }
            }
        }
        private void QuitTSMI_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SaveTSMI_Click(object sender, EventArgs e)
        {
            if (CurrentSaveFile == "" && saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                CurrentSaveFile = saveFileDialog.FileName;
            }
            else if (CurrentSaveFile == "") 
            {
                return;
            }
            object oMissing = Type.Missing;
            object wrap = Word.WdFindWrap.wdFindContinue;
            object replace = Word.WdReplace.wdReplaceAll;
            object oInput = CurrentTemplate;
            Word.Document doc = wordApp.Documents.Open(ref oInput);
            Word.Find find = wordApp.Selection.Find;
            foreach (Field field in fields)
            {
                find.Text = field.Mask;
                find.Replacement.Text = field.Value;
                find.Execute(FindText: oMissing,
                  MatchCase: true,
                  MatchWholeWord: true,
                  MatchWildcards: false,
                  MatchSoundsLike: oMissing,
                  MatchAllWordForms: false,
                  Forward: true,
                  Wrap: wrap,
                  Format: false,
                  ReplaceWith: oMissing, Replace: replace);
            }
            doc.SaveAs(FileName: CurrentSaveFile);
            doc.Close();
        }
        private void SaveAsTSMI_Click(object sender, EventArgs e)
        {

            CurrentSaveFile = "";
            SaveTSMI_Click(sender, e);

        }
    }
}