using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.SupplementalDocuments;

/// <summary>
/// Supplemental Documents are uploaded files connected to an Entity during onboarding.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntitySupplementalDocument, EntitySupplementalDocumentFromRaw>)
)]
public sealed record class EntitySupplementalDocument : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Supplemental
    /// Document was created.
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
    /// The Entity the supplemental document is attached to.
    /// </summary>
    public required string EntityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entity_id");
        }
        init { this._rawData.Set("entity_id", value); }
    }

    /// <summary>
    /// The File containing the document.
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
    /// be `entity_supplemental_document`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.SupplementalDocuments.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.SupplementalDocuments.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.EntityID;
        _ = this.FileID;
        _ = this.IdempotencyKey;
        this.Type.Validate();
    }

    public EntitySupplementalDocument() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitySupplementalDocument(EntitySupplementalDocument entitySupplementalDocument)
        : base(entitySupplementalDocument) { }
#pragma warning restore CS8618

    public EntitySupplementalDocument(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitySupplementalDocument(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitySupplementalDocumentFromRaw.FromRawUnchecked"/>
    public static EntitySupplementalDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitySupplementalDocumentFromRaw : IFromRawJson<EntitySupplementalDocument>
{
    /// <inheritdoc/>
    public EntitySupplementalDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitySupplementalDocument.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `entity_supplemental_document`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    EntitySupplementalDocument,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.SupplementalDocuments.Type>
{
    public override global::Increase.Api.Models.SupplementalDocuments.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "entity_supplemental_document" => global::Increase
                .Api
                .Models
                .SupplementalDocuments
                .Type
                .EntitySupplementalDocument,
            _ => (global::Increase.Api.Models.SupplementalDocuments.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.SupplementalDocuments.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.SupplementalDocuments.Type.EntitySupplementalDocument =>
                    "entity_supplemental_document",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
