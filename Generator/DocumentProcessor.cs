using AODL.Document.Content.Tables;
using AODL.Document.Content.Text;
using AODL.Document.Content;
using AODL.Document.TextDocuments;
using DDDN.OdtToHtml;
using System;
using System.Text.Json;
using System.Reflection.Metadata;
using System.Xml;

namespace Generator
{
    internal static class DocumentProcessor
    {
#if DEBUG
        private static readonly string offset = "\\..\\..\\..\\files";
#else
        private static readonly string offset = string.Empty;
#endif
        public static List<Field> Fields = new();
        public static readonly string FilesDir = Environment.CurrentDirectory + offset;
        public static string CurrentTemplateFile = string.Empty;
        public static string CurrentMetadataFile = string.Empty;
        public static string CurrentSaveFile = string.Empty;
        public static string GetPreviewFile()
        {
            
            string output = Path.GetTempFileName().Replace(".tmp", ".html");
            string cssfile = output.Replace(".html", ".css");
            /*
            TextDocument doc = new();
            Console.WriteLine(output);
            doc.Load(CurrentTemplateFile);
            FileStream htmlfile = File.OpenWrite(output);
            doc.XmlDoc.Save(htmlfile);
            htmlfile.Close();
            doc.Dispose();
            */

            ///*
            OdtConvertedData convertedData = null;
            var odtConvertSettings = new OdtConvertSettings
            {
                RootElementTagName = "body",
                LinkUrlPrefix = "//output//",
                DefaultTabSize = "2rem"
            };
            if (File.Exists(CurrentTemplateFile))
            {
                using (IOdtFile odtFile = new OdtFile(CurrentTemplateFile))
                {
                    convertedData = new OdtConvert().Convert(odtFile, odtConvertSettings);
                }
                File.WriteAllText(output, $"<html><head><meta charset=\"UTF-8\" /><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" /><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" /><link rel=\"stylesheet\" type=\"text/css\" href=\"{cssfile}\"></head>{convertedData.Html}</html>");
                File.WriteAllText(cssfile, convertedData.Css);
            }
            //*/
            return output;
        }
        public static void ReadDocuments()
        {
            Fields.Clear();
            string metadataString = File.ReadAllText(CurrentMetadataFile);
            JsonSerializerOptions options = new();
            options.Converters.Add(new Serialization.FieldConverter());
            Fields = JsonSerializer.Deserialize<List<Field>>(metadataString, options);
        }
        public static void SaveDocuments()
        {
            TextDocument doc = new();
            doc.Load(CurrentTemplateFile);
            foreach (Field field in Fields)
            {
                var content = doc.Content;
                FindReplace(field.Mask, field.Value.ToString(), content);
            }
            doc.SaveTo(CurrentSaveFile);
            doc.Dispose();
        }
        public static void Clear()
        {
            CurrentTemplateFile = string.Empty;
            CurrentMetadataFile = string.Empty;
            CurrentSaveFile = string.Empty;
        }
        public static void Close()
        {
            Clear();
        }

        private static void FindReplace(string findText, string replaceText, IContentCollection content)
        {
            foreach (var item in content)
            {
                if (item is Paragraph paragraph)
                {
                    foreach (IText text in paragraph.TextContent)
                    {
                        if (text.Text is not null)
                        {
                            text.Text = text.Text.Replace(findText, replaceText);
                        }
                    }
                }
                else if (item is Table table)
                {
                    foreach (Row row in table.RowCollection)
                    {
                        foreach (Cell cell in row.CellCollection)
                        {
                            var cellContent = cell.Content;
                            FindReplace(findText, replaceText, cellContent);
                        }
                    }
                }
            }
        }
    }
}