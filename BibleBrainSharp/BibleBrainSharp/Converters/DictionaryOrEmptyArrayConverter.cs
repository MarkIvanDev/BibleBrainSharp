using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BibleBrainSharp.Converters
{
    public class DictionaryOrEmptyArrayConverter<K, V> : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Dictionary<K, V>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartArray:
                    reader.Read();
                    return reader.TokenType == JsonToken.EndArray ?
                        new Dictionary<K, V>() :
                        throw new JsonSerializationException("Non-empty JSON array does not make a valid Dictionary");

                case JsonToken.Null:
                    return null;

                case JsonToken.StartObject:
                    using (var tw = new System.IO.StringWriter())
                    using (var writer = new JsonTextWriter(tw))
                    {
                        writer.WriteStartObject();
                        int initialDepth = reader.Depth;
                        while (reader.Read() && reader.Depth > initialDepth)
                        {
                            writer.WriteToken(reader);
                        }
                        writer.WriteEndObject();
                        writer.Flush();
                        return JsonConvert.DeserializeObject<Dictionary<K, V>>(tw.ToString());
                    }

                default:
                    throw new JsonSerializationException("Unexpected token");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
