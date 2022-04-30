using System;
using Word = Microsoft.Office.Interop.Word;
using System.Text.Json;

namespace Generator
{
    internal static class DocumentProcessor
    {
#if DEBUG
        private static readonly string offset = "\\..\\..\\..\\files";
#else
        private static readonly string offset = string.Empty;
#endif
        private static readonly Word.Application wordApp = new() { Visible = false };
        public static List<Field> Fields = new();
        public static readonly string FilesDir = Environment.CurrentDirectory + offset;
        public static string CurrentTemplateFile = string.Empty;
        public static string CurrentMetadataFile = string.Empty;
        public static string CurrentSaveFile = string.Empty;
        public static string GetPreviewFile()
        {
            object oMissing = Type.Missing;
            object oOutput = Path.GetTempFileName();
            object oFormat = Word.WdSaveFormat.wdFormatHTML;
            var doc = wordApp.Documents.Open(CurrentTemplateFile);
            doc.SaveAs(ref oOutput, ref oFormat, ref oMissing, ref oMissing,
              ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
              ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing
              );
            doc.Close();
            return oOutput.ToString();
        }
        public static void ReadDocuments()
        {
            Word.Document doc = wordApp.Documents.Open(CurrentTemplateFile);
            doc.Activate();
            doc.Close();
            Fields.Clear();
            string metadataString = File.ReadAllText(CurrentMetadataFile);
            JsonSerializerOptions options = new();
            options.Converters.Add(new Serialization.FieldConverter());
            Fields = JsonSerializer.Deserialize<List<Field>>(metadataString, options);
        }
        public static void SaveDocuments()
        {
            object oMissing = Type.Missing;
            object wrap = Word.WdFindWrap.wdFindContinue;
            object replace = Word.WdReplace.wdReplaceAll;
            object oInput = CurrentTemplateFile;
            Word.Document doc = wordApp.Documents.Open(ref oInput);
            Word.Find find = wordApp.Selection.Find;
            foreach (Field field in Fields)
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
            doc.SaveAs(FileName: CurrentSaveFile, FileFormat: Word.WdSaveFormat.wdFormatDocumentDefault);
            doc.Close();
        }
        public static void Clear()
        {
            if (wordApp.Documents.Count != 0)
            {
                wordApp.Documents.Close();
            }
            CurrentTemplateFile = string.Empty;
            CurrentMetadataFile = string.Empty;
            CurrentSaveFile = string.Empty;
        }
        public static void Close()
        {
            Clear();
            wordApp.Quit();
        }
    }
}
