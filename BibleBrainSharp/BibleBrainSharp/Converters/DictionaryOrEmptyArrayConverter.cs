// MIT License

// Copyright(c) 2021 Mark Ivan Basto

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

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
