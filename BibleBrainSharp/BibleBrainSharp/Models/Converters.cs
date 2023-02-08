using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BibleBrainSharp.Models
{
    public class DictionaryOrEmptyArrayConverter<K, V> : JsonConverter<Dictionary<K, V>?>
    {
        public override Dictionary<K, V>? ReadJson(JsonReader reader, Type objectType, Dictionary<K, V>? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                return JObject.Load(reader).ToObject<Dictionary<K, V>>();
            }
            else if (reader.TokenType == JsonToken.StartArray)
            {
                JArray.Load(reader);
                return null;
            }
            else
            {
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, Dictionary<K, V>? value, JsonSerializer serializer)
        {
            if (value != null)
            {
                JObject.FromObject(value).WriteTo(writer);
            }
        }
    }

    public class VersesResultMetadataPaginationLinksConverter : JsonConverter<VersesResultMetadataPaginationLinks?>
    {
        public override VersesResultMetadataPaginationLinks? ReadJson(JsonReader reader, Type objectType, VersesResultMetadataPaginationLinks? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                return JObject.Load(reader).ToObject< VersesResultMetadataPaginationLinks>();
            }
            else if (reader.TokenType == JsonToken.StartArray)
            {
                JArray.Load(reader);
                return null;
            }
            else
            {
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, VersesResultMetadataPaginationLinks? value, JsonSerializer serializer)
        {
            if (value != null)
            {
                JObject.FromObject(value).WriteTo(writer);
            }
        }
    }

    public class FilesetsConverter : JsonConverter<Filesets?>
    {
        public override Filesets? ReadJson(JsonReader reader, Type objectType, Filesets? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                return JObject.Load(reader).ToObject<Filesets>();
            }
            else if (reader.TokenType == JsonToken.StartArray)
            {
                JArray.Load(reader);
                return null;
            }
            else
            {
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, Filesets? value, JsonSerializer serializer)
        {
            if (value != null)
            {
                JObject.FromObject(value).WriteTo(writer);
            }
        }
    }

    public class BibleInfoPublishersConverter : JsonConverter<Organization[]?>
    {
        public override Organization[]? ReadJson(JsonReader reader, Type objectType, Organization[]? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartArray:
                    return JArray.Load(reader).ToObject<Organization[]>();

                case JsonToken.Null:
                    return null;

                case JsonToken.StartObject:
                    var jobject = JObject.Load(reader);
                    var array2 = new JArray();
                    foreach (var value in jobject.Values())
                    {
                        array2.Add(value);
                    }
                    return array2.ToObject<Organization[]>();

                default:
                    throw new JsonSerializationException("Unexpected token");
            }
        }

        public override void WriteJson(JsonWriter writer, Organization[]? value, JsonSerializer serializer)
        {
            if (value != null)
            {
                JArray.FromObject(value).WriteTo(writer);
            }
        }
    }
}
