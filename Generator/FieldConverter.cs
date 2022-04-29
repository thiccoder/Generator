using System.Text.Json;
using System.Text.Json.Serialization;
using Generator;
namespace Serialization
{
    public enum Type
    {
        Field = 0,
        TextField,
        NumericField,
        DateTimeField
    }
    internal class FieldConverter : JsonConverter<Field>
    {

        public override Field Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException();

            if (!reader.Read()
                    || reader.TokenType != JsonTokenType.PropertyName) throw new JsonException();

            if (!reader.Read() || reader.TokenType != JsonTokenType.Number) throw new JsonException();

            Field baseClass;
            Type type = (Type)reader.GetInt32();
            switch (type)
            {
                case Type.TextField:
                    if (!reader.Read() || reader.GetString() != "Parameters") throw new JsonException();
                    if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject) throw new JsonException();
                    baseClass = (TextField)JsonSerializer.Deserialize(ref reader, typeof(TextField), options);
                    break;
                case Type.NumericField:
                    if (!reader.Read() || reader.GetString() != "Parameters") throw new JsonException();
                    if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject) throw new JsonException();
                    baseClass = (NumericField)JsonSerializer.Deserialize(ref reader, typeof(NumericField), options);
                    break;
                case Type.DateTimeField:
                    if (!reader.Read() || reader.GetString() != "Parameters") throw new JsonException();
                    if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject) throw new JsonException();
                    baseClass = (DateTimeField)JsonSerializer.Deserialize(ref reader, typeof(DateTimeField), options);
                    break;
                case Type.Field:
                    if (!reader.Read() || reader.GetString() != "Parameters") throw new JsonException();
                    if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject) throw new JsonException();
                    baseClass = (Field)JsonSerializer.Deserialize(ref reader, typeof(Field));
                    break;
                default:
                    throw new NotSupportedException();
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject) throw new JsonException();

            return baseClass;
        }

        public override void Write(Utf8JsonWriter writer, Field value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            if (value is TextField derivedA)
            {
                writer.WriteNumber("Type", (int)Type.TextField);
                writer.WritePropertyName("Parameters");
                JsonSerializer.Serialize(writer, derivedA, options);
            }
            else if (value is NumericField derivedB)
            {
                writer.WriteNumber("Type", (int)Type.NumericField);
                writer.WritePropertyName("Parameters");
                JsonSerializer.Serialize(writer, derivedB, options);
            }
            else if (value is DateTimeField derivedC)
            {
                writer.WriteNumber("Type", (int)Type.DateTimeField);
                writer.WritePropertyName("Parameters");
                JsonSerializer.Serialize(writer, derivedC, options);
            }
            else if (value is Field baseClass)
            {
                writer.WriteNumber("Type", (int)Type.Field);
                writer.WritePropertyName("Parameters");
                JsonSerializer.Serialize(writer, baseClass);
            }
            else throw new NotSupportedException();

            writer.WriteEndObject();
        }
    }
}
