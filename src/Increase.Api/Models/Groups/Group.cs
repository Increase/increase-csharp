using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Groups;

/// <summary>
/// Groups represent organizations using Increase. You can retrieve information about
/// your own organization via the API. More commonly, OAuth platforms can retrieve
/// information about the organizations that have granted them access. Learn more
/// about OAuth [here](https://increase.com/documentation/oauth).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Group, GroupFromRaw>))]
public sealed record class Group : JsonModel
{
    /// <summary>
    /// The Group identifier.
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
    /// If the Group is allowed to create ACH debits.
    /// </summary>
    public required ApiEnum<string, AchDebitStatus> AchDebitStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AchDebitStatus>>(
                "ach_debit_status"
            );
        }
        init { this._rawData.Set("ach_debit_status", value); }
    }

    /// <summary>
    /// If the Group is activated or not.
    /// </summary>
    public required ApiEnum<string, ActivationStatus> ActivationStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ActivationStatus>>(
                "activation_status"
            );
        }
        init { this._rawData.Set("activation_status", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Group
    /// was created.
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
    /// A constant representing the object's type. For this resource it will always
    /// be `group`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.Groups.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.Groups.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.AchDebitStatus.Validate();
        this.ActivationStatus.Validate();
        _ = this.CreatedAt;
        this.Type.Validate();
    }

    public Group() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Group(Group group)
        : base(group) { }
#pragma warning restore CS8618

    public Group(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Group(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroupFromRaw.FromRawUnchecked"/>
    public static Group FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupFromRaw : IFromRawJson<Group>
{
    /// <inheritdoc/>
    public Group FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Group.FromRawUnchecked(rawData);
}

/// <summary>
/// If the Group is allowed to create ACH debits.
/// </summary>
[JsonConverter(typeof(AchDebitStatusConverter))]
public enum AchDebitStatus
{
    /// <summary>
    /// The Group cannot make ACH debits.
    /// </summary>
    Disabled,

    /// <summary>
    /// The Group can make ACH debits.
    /// </summary>
    Enabled,
}

sealed class AchDebitStatusConverter : JsonConverter<AchDebitStatus>
{
    public override AchDebitStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled" => AchDebitStatus.Disabled,
            "enabled" => AchDebitStatus.Enabled,
            _ => (AchDebitStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AchDebitStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AchDebitStatus.Disabled => "disabled",
                AchDebitStatus.Enabled => "enabled",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If the Group is activated or not.
/// </summary>
[JsonConverter(typeof(ActivationStatusConverter))]
public enum ActivationStatus
{
    /// <summary>
    /// The Group is not activated.
    /// </summary>
    Unactivated,

    /// <summary>
    /// The Group is activated.
    /// </summary>
    Activated,
}

sealed class ActivationStatusConverter : JsonConverter<ActivationStatus>
{
    public override ActivationStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unactivated" => ActivationStatus.Unactivated,
            "activated" => ActivationStatus.Activated,
            _ => (ActivationStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActivationStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ActivationStatus.Unactivated => "unactivated",
                ActivationStatus.Activated => "activated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `group`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Group,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.Groups.Type>
{
    public override global::Increase.Api.Models.Groups.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "group" => global::Increase.Api.Models.Groups.Type.Group,
            _ => (global::Increase.Api.Models.Groups.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.Groups.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.Groups.Type.Group => "group",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
