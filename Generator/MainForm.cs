using MSHTML;

namespace Generator
{
    public partial class MainForm : Form
    {
        private readonly List<Control> controls = new();
        private readonly Dictionary<Field, List<IHTMLTxtRange>> ranges = new();
        private string CurrentPreviewFile = string.Empty;
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
        public void ConstructFields()
        {
            Fields.Nodes.Clear();
            foreach (var field in DocumentProcessor.Fields)
            {
                Fields.Nodes.Add(new TreeNode(field.Name));
                Control control;
                if (field is TextField)
                {

                    TextField tfield = field as TextField;
                    TextBox ctrl = new()
                    {
                        AcceptsReturn = true,
                        AcceptsTab = true,
                        AllowDrop = true,
                        BackColor = SystemColors.Control,
                        Dock = DockStyle.Fill,
                        Location = new Point(0, 0),
                        Multiline = tfield.Multiline,
                        Name = "control",
                        Size = new Size(500, 500),
                        TabIndex = 0,
                        Enabled = false,
                        Visible = false,
                        BorderStyle = BorderStyle.Fixed3D,
                    };
                    control = ctrl;

                }
                else if (field is NumericField)
                {
                    NumericField nfield = field as NumericField;
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
                        Minimum = nfield.Range.Item1,
                        Maximum = nfield.Range.Item2,
                        BorderStyle = BorderStyle.Fixed3D,
                    };
                    control = ctrl;
                }
                else if (field is DateTimeField)
                {
                    DateTimeField dtfield = field as DateTimeField;
                    switch (dtfield.Flags)
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
                            TBC.Items.AddRange(System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames);
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
                    control = new Label() { Text = "null" };
                }
                /*else if (field is ChoiceField)
                {
                    ChoiceField cfield = field as ChoiceField
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
                    TBC.Items.AddRange(cfield.Options.ToArray());
                    control = TBC;
                }*/

                controls.Add(control);
                ToolTipSplit.Panel1.Controls.Add(control);
                ToolTipLabel.Text = field.ToolTip;
            }
            CurrentPreviewFile = DocumentProcessor.GetPreviewFile();
            Preview.Navigate(CurrentPreviewFile);
            Fields.SelectedNode = Fields.Nodes[0];
        }


        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int idx = Fields.Nodes.IndexOf(e.Node);
            Field cf = DocumentProcessor.Fields[currentIdx];

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
            if (ranges.ContainsKey(DocumentProcessor.Fields[currentIdx]))
            {
                ranges[DocumentProcessor.Fields[currentIdx]].First().select();
            }

        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DocumentProcessor.Close();
            if (File.Exists(CurrentPreviewFile))
            {
                File.Delete(CurrentPreviewFile);
            }
            CurrentPreviewFile = Path.GetTempFileName();
        }
        private void Preview_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ranges.Clear();
            while (ranges.Count == 0)
            {
                foreach (Field field in DocumentProcessor.Fields)
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
            string prevTemplate = DocumentProcessor.CurrentTemplateFile, prevMetadata = DocumentProcessor.CurrentMetadataFile;
            DocumentProcessor.Clear();
            OpenTemplate ot = new();
            if (ot.ShowDialog() == DialogResult.OK)
            {
                if ((DocumentProcessor.CurrentMetadataFile != prevMetadata) && (DocumentProcessor.CurrentTemplateFile != prevTemplate))
                {
                    DocumentProcessor.ReadDocuments();
                    ConstructFields();
                }
            }

        }
        private void QuitTSMI_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SaveTSMI_Click(object sender, EventArgs e)
        {
            if (DocumentProcessor.CurrentSaveFile == string.Empty)
            {
                if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DocumentProcessor.CurrentSaveFile = SaveFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
            DocumentProcessor.SaveDocuments();
        }
        private void SaveAsTSMI_Click(object sender, EventArgs e)
        {

            DocumentProcessor.CurrentSaveFile = string.Empty;
            SaveTSMI_Click(sender, e);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string templateFile = Directory.GetFiles(DocumentProcessor.FilesDir, "*.dotx").FirstOrDefault(string.Empty);
            string metadataFile = Directory.GetFiles(DocumentProcessor.FilesDir, "*.json").FirstOrDefault(string.Empty);

            if (File.Exists(metadataFile) && File.Exists(templateFile))
            {
                DocumentProcessor.CurrentMetadataFile = metadataFile;
                DocumentProcessor.CurrentTemplateFile = templateFile;
                DocumentProcessor.ReadDocuments();
                ConstructFields();
            }
        }
    }
}