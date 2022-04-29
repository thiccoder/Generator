using Word = Microsoft.Office.Interop.Word;
using System.Text.Json;
using MSHTML;
using System.IO;
using System.Globalization;

namespace Generator
{
    public partial class MainForm : Form
    {

        private readonly Word.Application wordApp = new() { Visible = false };
        private List<Field> fields = new();
        private readonly List<TreeNode> treeNodes = new();
        private readonly List<Control> controls = new();
        private readonly Dictionary<Field, List<IHTMLTxtRange>> ranges = new();
        private int currentIdx = 0;
        private IHTMLTxtRange range;
        public MainForm()
        {
            InitializeComponent();
        }
        private bool FindString(HtmlElement elem, string str)
        {
            bool strFound = false;
            try
            {
                if (range != null)
                {
                    range.collapse(false);
                    strFound = range.findText(str, 1000000000, 0);
                }
                if (range == null)
                {
                    IHTMLDocument2 doc = elem.Document.DomDocument as IHTMLDocument2;

                    IHTMLBodyElement body = doc.body as IHTMLBodyElement;

                    range = body.createTextRange();
                    range.moveToElementText(elem.DomElement as IHTMLElement);
                    strFound = range.findText(str, 1000000000, 0);
                }
            }
            catch
            {

            }
            return strFound;
        }
        private void ReadCurrentMetadata()
        {
            fields.Clear();
            controls.Clear();
            treeNodes.Clear();
            currentIdx = 0;
            string metadataString = File.ReadAllText(Globals.CurrentMetadataFile);
            JsonSerializerOptions options = new();
            options.Converters.Add(new Serialization.FieldConverter());
            fields = JsonSerializer.Deserialize<List<Field>>(metadataString, options);
            foreach (var field in fields)
            {
                if (field is null)
                {
                    MessageBox.Show("null");
                }
                //else
                //{
                //    MessageBox.Show(field.Name + "\n" + field.GetType());
                //}
            }
            Fields.Nodes.Clear();
            TreeNode[] nodes = new TreeNode[fields.Count];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new TreeNode(fields[i].Name);
                treeNodes.Add(nodes[i]);
                Control control;
                if (fields[i] is TextField)
                {

                    TextField field = fields[i] as TextField;
                    TextBox ctrl = new()
                    {
                        AcceptsReturn = true,
                        AcceptsTab = true,
                        AllowDrop = true,
                        BackColor = SystemColors.Control,
                        Dock = DockStyle.Fill,
                        Location = new Point(0, 0),
                        Multiline = field.Multiline,
                        Name = "control",
                        Size = new Size(500, 500),
                        TabIndex = 0,
                        Enabled = false,
                        Visible = false,
                        BorderStyle = BorderStyle.Fixed3D,
                    };
                    control = ctrl;

                }
                else if (fields[i] is NumericField)
                {
                    NumericField field = fields[i] as NumericField;
                    NumericUpDown ctrl = new()
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
                        Minimum = field.Range.Item1,
                        Maximum = field.Range.Item2,
                        BorderStyle = BorderStyle.Fixed3D,
                    };
                    control = ctrl;
                }
                else if (fields[i] is DateTimeField)
                {
                    DateTimeField field = fields[i] as DateTimeField;
                    switch (field.Flags)
                    {
                        case DateTimeFieldFlags.ShowMonth:
                            ComboBox TBC = new()
                            {
                                Dock = DockStyle.Fill,
                                FormattingEnabled = true,
                                Location = new Point(0, 0),
                                Name = "control",
                                Size = new Size(500, 25),
                                TabIndex = 0,
                                Enabled = false,
                                Visible = false,
                            };
                            TBC.Items.AddRange(DateTimeFormatInfo.CurrentInfo.MonthNames);
                            control = TBC;
                            break;
                        case DateTimeFieldFlags.ShowYear:
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
                                Minimum = DateTime.UnixEpoch.Year,
                                Maximum = DateTime.UnixEpoch.Year + 100,
                                BorderStyle = BorderStyle.Fixed3D,
                            };
                            control = TBN;
                            break;
                        default:
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
                                BackColor = SystemColors.Control,
                            };
                            control = TBD;
                            break;
                    }
                }
                else
                {
                    control = new Label() { Text="null"} ;
                }
                /*case Fieldfields[i].Choice:
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
                            break;*/
                controls.Add(control);
                ToolTipSplit.Panel1.Controls.Add(control);
                ToolTipLabel.Text = fields[i].ToolTip;
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

            if (cf is TextField)
            {
                (cf as TextField).Value = controls[currentIdx].Text;
            }
            if (cf is NumericField)
            {
                (cf as NumericField).Value = (controls[currentIdx] as NumericUpDown).Value;
            }
            if (cf is DateTimeField)
            {
                (cf as DateTimeField).Value = (controls[currentIdx] as MonthCalendar).SelectionStart;
            }
            if (ranges.ContainsKey(cf))
            {
                string val = cf.ToString();
                foreach (IHTMLTxtRange r in ranges[cf])
                {
                    r.pasteHTML(val);
                    r.collapse();
                    r.moveStart("character", -val.Length);
                }
            }

            controls[currentIdx].Enabled = false;
            controls[currentIdx].Visible = false;
            currentIdx = idx;
            controls[currentIdx].Enabled = true;
            controls[currentIdx].Visible = true;
            if (ranges.ContainsKey(fields[currentIdx])) 
            {
                ranges[fields[currentIdx]][0].select();
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
            ranges.Clear();
            while (ranges.Count == 0)
            {
                foreach (Field field in fields)
                {
                    range = null;
                    ranges[field] = new();
                    while (FindString(Preview.Document.Body, field.Mask))
                    {
                        var r = range.duplicate();
                        ranges[field].Add(r);
                        r.pasteHTML(field.Mask.ToUpper());
                        r.collapse();
                        r.moveStart("character", -field.Mask.Length);
                    }
                }
            }
        }

        private void OpenTSMI_Click(object sender, EventArgs e)
        {
            string prevTemplate =Globals.CurrentTemplateFile, prevMetadata = Globals.CurrentMetadataFile;
            OpenTemplate ot = new();
            if (ot.ShowDialog() == DialogResult.OK)
            {
                if (Globals.CurrentMetadataFile != prevMetadata)
                {
                    ReadCurrentMetadata();
                }
                if (Globals.CurrentTemplateFile != prevTemplate)
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
                find.Replacement.Text = field.ToString();
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
            doc.SaveAs(FileName: Globals.CurrentSaveFile, FileFormat: Word.WdSaveFormat.wdFormatDocumentDefault);
            doc.Close();
        }
        private void SaveAsTSMI_Click(object sender, EventArgs e)
        {

            Globals.CurrentSaveFile = string.Empty;
            SaveTSMI_Click(sender, e);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string templateFile = Directory.GetFiles(Globals.FilesDir, "*.dotx").FirstOrDefault(string.Empty);
            string metadataFile = Directory.GetFiles(Globals.FilesDir, "*.json").FirstOrDefault(string.Empty);
            
            if (File.Exists(metadataFile) && File.Exists(templateFile)) 
            {
                Globals.CurrentMetadataFile = metadataFile;
                Globals.CurrentTemplateFile = templateFile;
                ReadCurrentMetadata();
                ReadCurrentTemplate();
            }
        }
    }
}