using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace BibleBrainSharp.Models;

public class DefaultEnumConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
{
    public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null ||
            (reader.TokenType == JsonTokenType.String && string.IsNullOrWhiteSpace(reader.GetString())))
        {
            return default;
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            var enumText = reader.GetString();

            foreach (TEnum enumValue in Enum.GetValues(typeof(TEnum)))
            {
                var memberInfo = typeof(TEnum).GetMember(enumValue.ToString())[0];
                var attribute = memberInfo.GetCustomAttribute<JsonStringEnumMemberNameAttribute>();

                if (attribute != null && attribute.Name.Equals(enumText, StringComparison.OrdinalIgnoreCase))
                {
                    return enumValue;
                }
            }

            if (Enum.TryParse(enumText, ignoreCase: true, out TEnum result))
            {
                return result;
            }
        }

        return default;
    }

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
    {
        var memberInfo = typeof(TEnum).GetMember(value.ToString())[0];
        var attribute = memberInfo.GetCustomAttribute<JsonStringEnumMemberNameAttribute>();

        if (attribute != null)
        {
            writer.WriteStringValue(attribute.Name);
        }
        else
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}


public class DictionaryOrEmptyArrayConverter<K, V> : JsonConverter<Dictionary<K, V>?>
{
    public override Dictionary<K, V>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            return JsonSerializer.Deserialize<Dictionary<K, V>>(JsonNode.Parse(ref reader)?.AsObject(), options);
        }
        else if (reader.TokenType == JsonTokenType.StartArray)
        {
            JsonNode.Parse(ref reader);
            return null;
        }
        else
        {
            return null;
        }
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<K, V>? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            var json = JsonSerializer.Serialize(value, options);
            writer.WriteRawValue(json);
        }
    }

}

public class VersesResultMetadataPaginationLinksConverter : JsonConverter<VersesResultMetadataPaginationLinks?>
{
    public override VersesResultMetadataPaginationLinks? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            return JsonSerializer.Deserialize<VersesResultMetadataPaginationLinks>(JsonNode.Parse(ref reader)?.AsObject(), options);
        }
        else if (reader.TokenType == JsonTokenType.StartArray)
        {
            JsonNode.Parse(ref reader);
            return null;
        }
        else
        {
            return null;
        }
    }

    public override void Write(Utf8JsonWriter writer, VersesResultMetadataPaginationLinks? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            var json = JsonSerializer.Serialize(value, options);
            writer.WriteRawValue(json);
        }
    }

}

public class FilesetsConverter : JsonConverter<Filesets?>
{
    public override Filesets? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            return JsonSerializer.Deserialize<Filesets>(JsonNode.Parse(ref reader)?.AsObject(), options);
        }
        else if (reader.TokenType == JsonTokenType.StartArray)
        {
            JsonNode.Parse(ref reader);
            return null;
        }
        else
        {
            return null;
        }
    }

    public override void Write(Utf8JsonWriter writer, Filesets? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            var json = JsonSerializer.Serialize(value, options);
            writer.WriteRawValue(json);
        }
    }

}

public class BibleInfoPublishersConverter : JsonConverter<Organization[]?>
{
    public override Organization[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.StartArray:
                return JsonSerializer.Deserialize<Organization[]>(JsonNode.Parse(ref reader)?.AsArray(), options);

            case JsonTokenType.Null:
                return null;

            case JsonTokenType.StartObject:
                return JsonSerializer.Deserialize<Dictionary<string, Organization>>(JsonNode.Parse(ref reader)?.AsObject(), options)?.Values?.Select(v => v)?.ToArray();

            default:
                throw new Exception("Unexpected token");
        }
    }

    public override void Write(Utf8JsonWriter writer, Organization[]? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            var json = JsonSerializer.Serialize(value, options);
            writer.WriteRawValue(json);
        }
    }

}
