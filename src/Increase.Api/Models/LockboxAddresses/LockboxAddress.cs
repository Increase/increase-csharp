using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.LockboxAddresses;

/// <summary>
/// Lockbox Addresses are physical locations that can receive mail containing paper checks.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LockboxAddress, LockboxAddressFromRaw>))]
public sealed record class LockboxAddress : JsonModel
{
    /// <summary>
    /// The Lockbox Address identifier.
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
    /// The mailing address for the Lockbox Address. It will be present after Increase
    /// generates it.
    /// </summary>
    public required Address? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Address>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Lockbox
    /// Address was created.
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
    /// The description you choose for the Lockbox Address.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
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
    /// The status of the Lockbox Address.
    /// </summary>
    public required ApiEnum<string, LockboxAddressStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LockboxAddressStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `lockbox_address`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.LockboxAddresses.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.LockboxAddresses.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Address?.Validate();
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.IdempotencyKey;
        this.Status.Validate();
        this.Type.Validate();
    }

    public LockboxAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LockboxAddress(LockboxAddress lockboxAddress)
        : base(lockboxAddress) { }
#pragma warning restore CS8618

    public LockboxAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LockboxAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LockboxAddressFromRaw.FromRawUnchecked"/>
    public static LockboxAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LockboxAddressFromRaw : IFromRawJson<LockboxAddress>
{
    /// <inheritdoc/>
    public LockboxAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LockboxAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The mailing address for the Lockbox Address. It will be present after Increase
/// generates it.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : JsonModel
{
    /// <summary>
    /// The city of the address.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The first line of the address.
    /// </summary>
    public required string Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("line1");
        }
        init { this._rawData.Set("line1", value); }
    }

    /// <summary>
    /// The second line of the address.
    /// </summary>
    public required string Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("line2");
        }
        init { this._rawData.Set("line2", value); }
    }

    /// <summary>
    /// The postal code of the address.
    /// </summary>
    public required string PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <summary>
    /// The two-letter United States Postal Service (USPS) abbreviation for the state
    /// of the address.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.PostalCode;
        _ = this.State;
    }

    public Address() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Address(Address address)
        : base(address) { }
#pragma warning restore CS8618

    public Address(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Address(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddressFromRaw.FromRawUnchecked"/>
    public static Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddressFromRaw : IFromRawJson<Address>
{
    /// <inheritdoc/>
    public Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Address.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the Lockbox Address.
/// </summary>
[JsonConverter(typeof(LockboxAddressStatusConverter))]
public enum LockboxAddressStatus
{
    /// <summary>
    /// Increase is generating this Lockbox Address.
    /// </summary>
    Pending,

    /// <summary>
    /// This Lockbox Address is active.
    /// </summary>
    Active,

    /// <summary>
    /// This Lockbox Address is disabled.
    /// </summary>
    Disabled,

    /// <summary>
    /// This Lockbox Address is permanently disabled.
    /// </summary>
    Canceled,
}

sealed class LockboxAddressStatusConverter : JsonConverter<LockboxAddressStatus>
{
    public override LockboxAddressStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => LockboxAddressStatus.Pending,
            "active" => LockboxAddressStatus.Active,
            "disabled" => LockboxAddressStatus.Disabled,
            "canceled" => LockboxAddressStatus.Canceled,
            _ => (LockboxAddressStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LockboxAddressStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LockboxAddressStatus.Pending => "pending",
                LockboxAddressStatus.Active => "active",
                LockboxAddressStatus.Disabled => "disabled",
                LockboxAddressStatus.Canceled => "canceled",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `lockbox_address`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    LockboxAddress,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.LockboxAddresses.Type>
{
    public override global::Increase.Api.Models.LockboxAddresses.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "lockbox_address" => global::Increase.Api.Models.LockboxAddresses.Type.LockboxAddress,
            _ => (global::Increase.Api.Models.LockboxAddresses.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.LockboxAddresses.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.LockboxAddresses.Type.LockboxAddress =>
                    "lockbox_address",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
