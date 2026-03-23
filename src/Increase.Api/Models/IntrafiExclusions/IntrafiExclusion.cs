using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.IntrafiExclusions;

/// <summary>
/// Certain institutions may be excluded per Entity when sweeping funds into the
/// IntraFi network. This is useful when an Entity already has deposits at a particular
/// bank, and does not want to sweep additional funds to it. It may take 5 business
/// days for an exclusion to be processed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<IntrafiExclusion, IntrafiExclusionFromRaw>))]
public sealed record class IntrafiExclusion : JsonModel
{
    /// <summary>
    /// The identifier of this exclusion request.
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
    /// The name of the excluded institution.
    /// </summary>
    public required string? BankName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bank_name");
        }
        init { this._rawData.Set("bank_name", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the exclusion was created.
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
    /// The entity for which this institution is excluded.
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
    /// When this was exclusion was confirmed by IntraFi.
    /// </summary>
    public required System::DateTimeOffset? ExcludedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("excluded_at");
        }
        init { this._rawData.Set("excluded_at", value); }
    }

    /// <summary>
    /// The Federal Deposit Insurance Corporation's certificate number for the institution.
    /// </summary>
    public required string? FdicCertificateNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fdic_certificate_number");
        }
        init { this._rawData.Set("fdic_certificate_number", value); }
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
    /// The status of the exclusion request.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// When this was exclusion was submitted to IntraFi by Increase.
    /// </summary>
    public required System::DateTimeOffset? SubmittedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("submitted_at");
        }
        init { this._rawData.Set("submitted_at", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `intrafi_exclusion`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.IntrafiExclusions.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.IntrafiExclusions.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BankName;
        _ = this.CreatedAt;
        _ = this.EntityID;
        _ = this.ExcludedAt;
        _ = this.FdicCertificateNumber;
        _ = this.IdempotencyKey;
        this.Status.Validate();
        _ = this.SubmittedAt;
        this.Type.Validate();
    }

    public IntrafiExclusion() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntrafiExclusion(IntrafiExclusion intrafiExclusion)
        : base(intrafiExclusion) { }
#pragma warning restore CS8618

    public IntrafiExclusion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntrafiExclusion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntrafiExclusionFromRaw.FromRawUnchecked"/>
    public static IntrafiExclusion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntrafiExclusionFromRaw : IFromRawJson<IntrafiExclusion>
{
    /// <inheritdoc/>
    public IntrafiExclusion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IntrafiExclusion.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the exclusion request.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// The exclusion is being added to the IntraFi network.
    /// </summary>
    Pending,

    /// <summary>
    /// The exclusion has been added to the IntraFi network.
    /// </summary>
    Completed,

    /// <summary>
    /// The exclusion has been removed from the IntraFi network.
    /// </summary>
    Archived,

    /// <summary>
    /// The exclusion wasn't eligible to be added to the IntraFi network.
    /// </summary>
    Ineligible,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => Status.Pending,
            "completed" => Status.Completed,
            "archived" => Status.Archived,
            "ineligible" => Status.Ineligible,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "pending",
                Status.Completed => "completed",
                Status.Archived => "archived",
                Status.Ineligible => "ineligible",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `intrafi_exclusion`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    IntrafiExclusion,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.IntrafiExclusions.Type>
{
    public override global::Increase.Api.Models.IntrafiExclusions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "intrafi_exclusion" => global::Increase
                .Api
                .Models
                .IntrafiExclusions
                .Type
                .IntrafiExclusion,
            _ => (global::Increase.Api.Models.IntrafiExclusions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.IntrafiExclusions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.IntrafiExclusions.Type.IntrafiExclusion =>
                    "intrafi_exclusion",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
