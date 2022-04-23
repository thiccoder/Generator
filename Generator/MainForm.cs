using Word = Microsoft.Office.Interop.Word;
using System.Text.Json;
using MSHTML;
using System.IO;

namespace Generator
{
    public partial class MainForm : Form
    {

        private readonly Word.Application wordApp = new() { Visible = false };
        private List<Field> fields;
        private readonly List<TreeNode> treeNodes = new();
        private readonly List<Control> controls = new();
        private readonly Dictionary<Field, IHTMLTxtRange> ranges = new();
        private int currentIdx = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ReadCurrentMetadata()
        {
            string metadataString = File.ReadAllText(Globals.CurrentMetadataFile);
            fields = JsonSerializer.Deserialize<List<Field>>(metadataString);
            Fields.Nodes.Clear();
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
                            Visible = false,
                            Minimum = fields[i].MinVal,
                            Maximum = fields[i].MaxVal,
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
                        TBC.Items.AddRange(fields[i].Options.ToArray());
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
            Fields.Nodes.AddRange(nodes);
            currentIdx = 0;
            Fields.SelectedNode = nodes[0];
        }
        private void ReadCurrentTemplate()
        {
            Word.Document doc = wordApp.Documents.Open(Globals.CurrentTemplateFile);
            doc.Activate();
            Convert(doc, Globals.CurrentHtmlFile, Word.WdSaveFormat.wdFormatHTML);
            doc.Close();
            Preview.Navigate(Globals.CurrentHtmlFile);
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
            else cf.Value = (controls[currentIdx] as MonthCalendar).SelectionStart.Date.ToLongDateString().Trim('.');
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
            if (File.Exists(Globals.CurrentHtmlFile))
            {
                File.Delete(Globals.CurrentHtmlFile);
            }
        }
        private void Preview_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            while (ranges.Count == 0)
            {
                if (Preview.Document != null)
                {
                    if (Preview.Document.DomDocument is IHTMLDocument2 doc)
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
            OpenTemplate ot = new();
            if (ot.ShowDialog() == DialogResult.OK)
            {
                if (Globals.CurrentMetadataFile != string.Empty)
                {
                    ReadCurrentMetadata();
                }
                if (Globals.CurrentTemplateFile != string.Empty)
                {
                    ReadCurrentTemplate();
                }
            }

        }
        private void QuitTSMI_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SaveTSMI_Click(object sender, EventArgs e)
        {
            if (Globals.CurrentSaveFile == string.Empty)
            {
                if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Globals.CurrentSaveFile = SaveFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
            object oMissing = Type.Missing;
            object wrap = Word.WdFindWrap.wdFindContinue;
            object replace = Word.WdReplace.wdReplaceAll;
            object oInput = Globals.CurrentTemplateFile;
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
            doc.SaveAs(FileName: Globals.CurrentSaveFile);
            doc.Close();
        }
        private void SaveAsTSMI_Click(object sender, EventArgs e)
        {

            Globals.CurrentSaveFile = string.Empty;
            SaveTSMI_Click(sender, e);

        }
    }
}