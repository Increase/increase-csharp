using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.FileLinks;

/// <summary>
/// File Links let you generate a URL that can be used to download a File.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileLink, FileLinkFromRaw>))]
public sealed record class FileLink : JsonModel
{
    /// <summary>
    /// The File Link identifier.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the File
    /// Link was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the File
    /// Link will expire.
    /// </summary>
    public required System::DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// The identifier of the File the File Link points to.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// The idempotency key you chose for this object. This value is unique across
    /// Increase and is used to ensure that a request is only processed once. Learn
    /// more about [idempotency](https://increase.com/documentation/idempotency-keys).
    /// </summary>
    public required string? IdempotencyKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("idempotency_key");
        }
        init { this._rawData.Set("idempotency_key", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `file_link`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.FileLinks.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.FileLinks.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// A URL where the File can be downloaded. The URL will expire after the `expires_at`
    /// time. This URL is unauthenticated and can be used to download the File without
    /// an Increase API key.
    /// </summary>
    public required string UnauthenticatedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unauthenticated_url");
        }
        init { this._rawData.Set("unauthenticated_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.ExpiresAt;
        _ = this.FileID;
        _ = this.IdempotencyKey;
        this.Type.Validate();
        _ = this.UnauthenticatedUrl;
    }

    public FileLink() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileLink(FileLink fileLink)
        : base(fileLink) { }
#pragma warning restore CS8618

    public FileLink(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileLink(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileLinkFromRaw.FromRawUnchecked"/>
    public static FileLink FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileLinkFromRaw : IFromRawJson<FileLink>
{
    /// <inheritdoc/>
    public FileLink FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileLink.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `file_link`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    FileLink,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.FileLinks.Type>
{
    public override global::Increase.Api.Models.FileLinks.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file_link" => global::Increase.Api.Models.FileLinks.Type.FileLink,
            _ => (global::Increase.Api.Models.FileLinks.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.FileLinks.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.FileLinks.Type.FileLink => "file_link",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
