using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Generator
{
    public partial class OpenTemplate : Form
    {
        private bool templateSet, metadataSet;
        public OpenTemplate()
        {
            InitializeComponent();
            AcceptButton = ButtonOk;
            CancelButton = ButtonCancel;
        }
        public void OpenTemplate_Load(object sender, EventArgs e)
        {
            string templateFile, metadataFile;
            if (DocumentProcessor.CurrentTemplateFile == string.Empty)
            {
                templateFile = Directory.GetFiles(DocumentProcessor.FilesDir, "*.odt").FirstOrDefault(string.Empty);
            }
            else
            {
                templateFile = DocumentProcessor.CurrentTemplateFile;
            }
            if (DocumentProcessor.CurrentMetadataFile == string.Empty)
            {
                metadataFile = Directory.GetFiles(DocumentProcessor.FilesDir, "*.json").FirstOrDefault(string.Empty);
            }
            else
            {
                metadataFile = DocumentProcessor.CurrentMetadataFile;
            }
            MetadataPathBox.Text = metadataFile;
            metadataSet = File.Exists(metadataFile);
            TemplatePathBox.Text = templateFile;
            templateSet = File.Exists(templateFile);
            if (metadataSet && templateSet)
            {
                ButtonOk.Enabled = true;
            }
            else
            {
                ButtonOk.Enabled = false;
            }
            ButtonCancel.Select();
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox senderBox = (TextBox)sender;
            if (senderBox == MetadataPathBox)
            {
                if (File.Exists(senderBox.Text))
                {
                    metadataSet = true;
                    DocumentProcessor.CurrentMetadataFile = senderBox.Text;
                }
                else
                {
                    metadataSet = false;
                }
            }
            else if (senderBox == TemplatePathBox)
            {
                if (File.Exists(senderBox.Text))
                {
                    templateSet = true;
                    DocumentProcessor.CurrentTemplateFile = senderBox.Text;
                }
                else
                {
                    templateSet = false;
                }
            }
            if (metadataSet && templateSet)
            {
                ButtonOk.Enabled = true;
            }
            else
            {
                ButtonOk.Enabled = false;
            }
        }

        private void MetadataBrowseButton_Click(object sender, EventArgs e)
        {
            OpenDialog.Filter = "Metadata files (*.json)|*.json|All Files (*.*)|*.*";
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                MetadataPathBox.Text = OpenDialog.FileName;
            }
        }
        private void TemplateBrowseButton_Click(object sender, EventArgs e)
        {
            OpenDialog.Filter = "Template files (*.odt)|*.odt|All Files (*.*)|*.*";
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                TemplatePathBox.Text = OpenDialog.FileName;
            }
        }

        void ButtonOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
