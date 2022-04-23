using System.Xml;
using System.Collections.Generic;
namespace Generator
{
    public class Field
    {
        public string Value = string.Empty;
        public string Name { get; set; }
        public string Mask { get; set; }
        public FieldType Type { get; set; }
        public string Default { get; set; }
        public int MinVal = int.MinValue;
        public int MaxVal = int.MaxValue;
        public List<string>? Options { get; set; }
    }
    public enum FieldType 
    {
        Text = 0,
        Number,
        Date,
        Choice 
    }
}
