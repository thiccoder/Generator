using System.Xml;
using System.Collections.Generic;
namespace Generator
{
    public class Field
    {
        public string Mask = "";
        public FieldType Type = FieldType.Text;
        public string Value = "";
        public string Name = "";
        public List<string> options = new();
        public Field(XmlNode start) 
        {
            foreach (XmlNode node in start.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Text)
                {
                    Name = node.Value;
                }
                else if (node.Name == "mask")
                {
                    Mask = node.InnerText;
                }
                else if (node.Name == "type")
                {
                    switch (node.InnerText)
                    {
                        case "number":
                            Type = FieldType.Number;
                            break;
                        case "date":
                            Type = FieldType.Date;
                            break;
                        case "choice":
                            Type = FieldType.Choice;
                            break;
                    }
                }
                else if (node.Name == "options") 
                {
                    Type = FieldType.Choice;
                    foreach (XmlNode node1 in node.ChildNodes)
                    {
                        if (node1.Name == "option") 
                        {
                            options.Add(node1.InnerText);
                        }
                    }
                }
            }
        }
    }
    public enum FieldType 
    {
        Text = 0,
        Number,
        Date,
        Choice 
    }
}
