using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.CheckbookChecks;

/// <summary>
/// A Checkbook Check is a single check within a Checkbook.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CheckbookCheck, CheckbookCheckFromRaw>))]
public sealed record class CheckbookCheck : JsonModel
{
    /// <summary>
    /// The Checkbook Check's identifier.
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
    /// The check number printed on the check.
    /// </summary>
    public required long CheckNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("check_number");
        }
        init { this._rawData.Set("check_number", value); }
    }

    /// <summary>
    /// The identifier of the Checkbook the check belongs to.
    /// </summary>
    public required string CheckbookID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("checkbook_id");
        }
        init { this._rawData.Set("checkbook_id", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Checkbook Check was created.
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
    /// The status of the Checkbook Check.
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
    /// A constant representing the object's type. For this resource it will always
    /// be `checkbook_check`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.CheckbookChecks.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.CheckbookChecks.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CheckNumber;
        _ = this.CheckbookID;
        _ = this.CreatedAt;
        this.Status.Validate();
        this.Type.Validate();
    }

    public CheckbookCheck() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckbookCheck(CheckbookCheck checkbookCheck)
        : base(checkbookCheck) { }
#pragma warning restore CS8618

    public CheckbookCheck(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckbookCheck(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckbookCheckFromRaw.FromRawUnchecked"/>
    public static CheckbookCheck FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckbookCheckFromRaw : IFromRawJson<CheckbookCheck>
{
    /// <inheritdoc/>
    public CheckbookCheck FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CheckbookCheck.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the Checkbook Check.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// The check has not yet been deposited.
    /// </summary>
    PendingDeposit,

    /// <summary>
    /// The check has been deposited.
    /// </summary>
    Deposited,

    /// <summary>
    /// The check has been stopped and can no longer be deposited.
    /// </summary>
    Stopped,

    /// <summary>
    /// The check requires attention from an Increase operator.
    /// </summary>
    RequiresAttention,
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
            "pending_deposit" => Status.PendingDeposit,
            "deposited" => Status.Deposited,
            "stopped" => Status.Stopped,
            "requires_attention" => Status.RequiresAttention,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.PendingDeposit => "pending_deposit",
                Status.Deposited => "deposited",
                Status.Stopped => "stopped",
                Status.RequiresAttention => "requires_attention",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `checkbook_check`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    CheckbookCheck,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.CheckbookChecks.Type>
{
    public override global::Increase.Api.Models.CheckbookChecks.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "checkbook_check" => global::Increase.Api.Models.CheckbookChecks.Type.CheckbookCheck,
            _ => (global::Increase.Api.Models.CheckbookChecks.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.CheckbookChecks.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.CheckbookChecks.Type.CheckbookCheck =>
                    "checkbook_check",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
