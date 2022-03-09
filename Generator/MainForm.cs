﻿using Word = Microsoft.Office.Interop.Word;
using System.Xml;

namespace Generator
{
    public partial class MainForm : Form
    {
        public List<Field> fields = new();
        public List<TreeNode> treeNodes = new();
        public List<Control> controls = new();
        public int currentIdx;
        public Word.Application WordApp = new() {Visible=false};
        public Dictionary<Field, Tuple<int, int>> Places = new();
        public MainForm()
        {
            InitializeComponent();
        }
        public void ParseNodes(XmlNode xmlNode)
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
        public void ReadXML()
        {
            XmlDocument doc = new();
            string fileName = Environment.CurrentDirectory + "\\Template.xml";
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
                            Size = new Size(603, 483),
                            TabIndex = 0,
                            Enabled = false,
                            Visible = false
                        };
                        control = TBN;
                        break;
                    case FieldType.Date:
                        MonthCalendar TBD = new()
                        {
                            CalendarDimensions = new Size(3, 3),
                            Dock = DockStyle.Fill,
                            Location = new Point(0, 0),
                            MaxSelectionCount = 1,
                            Name = "control",
                            TabIndex = 0,
                            Enabled = false,
                            Visible = false
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
                            Size = new Size(500, 23),
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
                            Size = new Size(603, 483),
                            TabIndex = 0,
                            Enabled = false,
                            Visible = false
                        };
                        control = TBT;
                        break;
                }
                controls.Add(control);
                splitContainer.Panel1.Controls.Add(control);
                //nodes[i].Nodes.Add(new TreeNode("Mask: " + fields[i].Mask));
                //nodes[i].Nodes.Add(new TreeNode("Value: " + fields[i].Value));
                //nodes[i].Nodes.Add(new TreeNode("Options: " + fields[i].options.ToArray().ToString()));
                //nodes[i].Nodes.Add(new TreeNode("Type: " + fields[i].Type.ToString()));
            }
            treeView.Nodes.AddRange(nodes);
            currentIdx = 0;
            treeView.SelectedNode = nodes[0];
        }
        public void Convert(Word.Document doc, string outFile, Word.WdSaveFormat format)
        {
            object oMissing = Type.Missing;
            object oOutput = outFile;
            object oFormat = format;
            doc.SaveAs(ref oOutput, ref oFormat, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing
                );
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            ReadXML();
            string inDoc = Environment.CurrentDirectory + "\\Template.dotx";
            string pdf = Environment.CurrentDirectory + "\\tmp.pdf";
            Word.Document doc = WordApp.Documents.Open(inDoc);
            doc.Activate();
            Convert(doc, pdf, Word.WdSaveFormat.wdFormatPDF);
            webBrowser.Navigate(pdf);
            Word.Find find = WordApp.Selection.Find;
            object oMissing = Type.Missing;
            object wrap = Word.WdFindWrap.wdFindContinue;
            foreach (Field field in fields)
            {
                find.Text = field.Mask;
                find.Execute(FindText: oMissing,
                    MatchCase: true,
                    MatchWholeWord: true,
                    MatchWildcards: false,
                    MatchSoundsLike: oMissing,
                    MatchAllWordForms: false,
                    Forward: true,
                    Wrap: wrap,
                    Format: false,
                    ReplaceWith: oMissing, Replace: oMissing);
                Places[field] = new Tuple<int, int>(WordApp.Selection.Start,WordApp.Selection.End);
            }
            doc.Close();
        }

        private void Generate(object sender, EventArgs e)
        {
            
            object oMissing = Type.Missing;
            object wrap = Word.WdFindWrap.wdFindContinue;
            object replace = Word.WdReplace.wdReplaceAll;
            object oInput = Environment.CurrentDirectory + "\\Template.dotx";
            Word.Document doc = WordApp.Documents.Open(ref oInput);
            Word.Find find = WordApp.Selection.Find;
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
            Text = WordApp.Selection.Start.ToString() + ' ' + WordApp.Selection.End.ToString();
            doc.SaveAs(FileName: Environment.CurrentDirectory + "\\Result.docx");
            doc.Close();
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

        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            WordApp.Quit();
        }

    }
}