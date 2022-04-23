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
            string templateFile = Directory.GetFiles(Globals.FilesDir, "*.dotx").FirstOrDefault(string.Empty), metadataFile = Directory.GetFiles(Globals.FilesDir, "*.json").FirstOrDefault(string.Empty);
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
                    Globals.CurrentMetadataFile = senderBox.Text;
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
                    Globals.CurrentTemplateFile = senderBox.Text;
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
            OpenDialog.Filter = OpenDialog.Filter.Replace("Template files (*.dotx)|*.dotx", "Metadata files (*.json)|*.json");
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                MetadataPathBox.Text = OpenDialog.FileName;
            }
        }
        private void TemplateBrowseButton_Click(object sender, EventArgs e)
        {
            OpenDialog.Filter = OpenDialog.Filter.Replace("Metadata files (*.json) | *.json", "Template files (*.dotx)|*.dotx");
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
