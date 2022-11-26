
using System.Globalization;
using System.Text.Json.Serialization;

namespace Generator
{
    [Flags]
    public enum DateTimeFieldFlags
    {
        None = 0,
        ShowYear = 1,
        ShowMonth = 2,
        ShowDay = 4,
        ShowHour = 8,
        ShowMinute = 16,
        ShowSecond = 32,
        Date = ShowYear | ShowMonth | ShowDay,
        Time = ShowHour | ShowMinute | ShowSecond,
        All = Date | Time,
        Default = Date,
    }

    public class Field
    {
        [JsonIgnore]
        public object Value = string.Empty;
        [JsonInclude]
        public object Default = string.Empty;
        [JsonInclude]
        public string Name = string.Empty;
        [JsonInclude]
        public string Mask = string.Empty;
        [JsonInclude]
        public string ToolTip = string.Empty;
        public override string ToString()
        {
            return Value.ToString();
        }
        [JsonConstructor]
        public Field()
        {

        }
        public Field(string name, string mask, string toolTip)
        {
            Name = name;
            Mask = mask;
            ToolTip = toolTip;
        }
    }
    public class TextField : Field
    {
        [JsonIgnore]
        public new string Value = string.Empty;
        [JsonInclude]
        public new string Default = string.Empty;
        [JsonInclude]
        public bool Multiline = false;
        public override string ToString()
        {
            return Value;
        }
        [JsonConstructor]
        public TextField() : base()
        {
        }
        public TextField(string name, string mask, string toolTip, bool multiline) : base(name, mask, toolTip)
        {
            Multiline = multiline;
        }
    }
    public class NumericField : Field
    {
        [JsonIgnore]
        public new decimal Value = 0;
        [JsonInclude]
        public new decimal Default = 0;
        [JsonInclude]
        public Tuple<decimal, decimal> Range = new(decimal.MinValue, decimal.MaxValue);
        public override string ToString()
        {
            return Value.ToString();
        }
        [JsonConstructor]
        public NumericField() : base()
        {
        }
        public NumericField(string name, string mask, string toolTip, Tuple<decimal, decimal> range) : base(name, mask, toolTip)
        {
            Range = range;
        }
    }
    public class DateTimeField : Field
    {
        [JsonIgnore]
        public new DateTime Value = DateTime.Now;
        [JsonInclude]
        public new DateTime Default = DateTime.UnixEpoch;
        [JsonInclude]
        public DateTimeFieldFlags Flags;
        public override string ToString()
        {
            string s = Flags switch
            {
                DateTimeFieldFlags.Date => Value.ToLongDateString(),
                DateTimeFieldFlags.Time => Value.ToLongTimeString(),
                DateTimeFieldFlags.ShowYear => Value.Year.ToString(),
                DateTimeFieldFlags.ShowMonth => DateTimeFormatInfo.CurrentInfo.GetMonthName(Value.Month),
                DateTimeFieldFlags.ShowDay => Value.Day.ToString(),
                DateTimeFieldFlags.ShowHour => Value.Hour.ToString(),
                DateTimeFieldFlags.ShowMinute => Value.Minute.ToString(),
                DateTimeFieldFlags.ShowSecond => Value.Second.ToString(),
                _ => string.Empty,
            };
            return s;
        }
        [JsonConstructor]
        public DateTimeField() : base()
        {
        }
        public DateTimeField(string pname, string pmask, string ptooltip, DateTimeFieldFlags flags) : base(pname, pmask, ptooltip)
        {
            Flags = flags;
        }
    }
}
