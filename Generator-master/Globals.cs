using System;
using MSHTML;
namespace Generator
{
    internal static class Globals
    {
#if DEBUG
        private static readonly string offset = "\\..\\..\\..\\files";
#else
        private static readonly string offset = string.Empty;
#endif

        public static readonly string FilesDir = Environment.CurrentDirectory + offset;
        public static string CurrentTemplateFile = FilesDir + "/Template.dotx";
        public static string CurrentMetadataFile = FilesDir + "/Template.json";
        public static string CurrentHtmlFile = Path.GetTempFileName();
        public static string CurrentSaveFile = string.Empty;
        
    }
}
