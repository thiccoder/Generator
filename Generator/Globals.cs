using System;

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
        public static string CurrentTemplateFile = string.Empty;
        public static string CurrentMetadataFile = string.Empty;
        public static string CurrentHtmlFile = Path.GetTempFileName();
        public static string CurrentSaveFile = string.Empty;
    }
}
