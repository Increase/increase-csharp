using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.DigitalWalletTokens;

/// <summary>
/// A Digital Wallet Token is created when a user adds a Card to their Apple Pay
/// or Google Pay app. The Digital Wallet Token can be used for purchases just like
/// a Card.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DigitalWalletToken, DigitalWalletTokenFromRaw>))]
public sealed record class DigitalWalletToken : JsonModel
{
    /// <summary>
    /// The Digital Wallet Token identifier.
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
    /// The identifier for the Card this Digital Wallet Token belongs to.
    /// </summary>
    public required string CardID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("card_id");
        }
        init { this._rawData.Set("card_id", value); }
    }

    /// <summary>
    /// The cardholder information given when the Digital Wallet Token was created.
    /// </summary>
    public required Cardholder Cardholder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Cardholder>("cardholder");
        }
        init { this._rawData.Set("cardholder", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Digital Wallet Token was created.
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
    /// The device that was used to create the Digital Wallet Token.
    /// </summary>
    public required Device Device
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Device>("device");
        }
        init { this._rawData.Set("device", value); }
    }

    /// <summary>
    /// The redacted Dynamic Primary Account Number.
    /// </summary>
    public required DynamicPrimaryAccountNumber? DynamicPrimaryAccountNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DynamicPrimaryAccountNumber>(
                "dynamic_primary_account_number"
            );
        }
        init { this._rawData.Set("dynamic_primary_account_number", value); }
    }

    /// <summary>
    /// This indicates if payments can be made with the Digital Wallet Token.
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
    /// The digital wallet app being used.
    /// </summary>
    public required ApiEnum<string, TokenRequestor> TokenRequestor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TokenRequestor>>(
                "token_requestor"
            );
        }
        init { this._rawData.Set("token_requestor", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `digital_wallet_token`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.DigitalWalletTokens.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.DigitalWalletTokens.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Updates to the Digital Wallet Token.
    /// </summary>
    public required IReadOnlyList<Update> Updates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Update>>("updates");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Update>>(
                "updates",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CardID;
        this.Cardholder.Validate();
        _ = this.CreatedAt;
        this.Device.Validate();
        this.DynamicPrimaryAccountNumber?.Validate();
        this.Status.Validate();
        this.TokenRequestor.Validate();
        this.Type.Validate();
        foreach (var item in this.Updates)
        {
            item.Validate();
        }
    }

    public DigitalWalletToken() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalWalletToken(DigitalWalletToken digitalWalletToken)
        : base(digitalWalletToken) { }
#pragma warning restore CS8618

    public DigitalWalletToken(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalWalletToken(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalWalletTokenFromRaw.FromRawUnchecked"/>
    public static DigitalWalletToken FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalWalletTokenFromRaw : IFromRawJson<DigitalWalletToken>
{
    /// <inheritdoc/>
    public DigitalWalletToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DigitalWalletToken.FromRawUnchecked(rawData);
}

/// <summary>
/// The cardholder information given when the Digital Wallet Token was created.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Cardholder, CardholderFromRaw>))]
public sealed record class Cardholder : JsonModel
{
    /// <summary>
    /// Name of the cardholder, for example "John Smith".
    /// </summary>
    public required string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public Cardholder() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cardholder(Cardholder cardholder)
        : base(cardholder) { }
#pragma warning restore CS8618

    public Cardholder(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Cardholder(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardholderFromRaw.FromRawUnchecked"/>
    public static Cardholder FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Cardholder(string? name)
        : this()
    {
        this.Name = name;
    }
}

class CardholderFromRaw : IFromRawJson<Cardholder>
{
    /// <inheritdoc/>
    public Cardholder FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Cardholder.FromRawUnchecked(rawData);
}

/// <summary>
/// The device that was used to create the Digital Wallet Token.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Device, DeviceFromRaw>))]
public sealed record class Device : JsonModel
{
    /// <summary>
    /// Device type.
    /// </summary>
    public required ApiEnum<string, DeviceType>? DeviceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DeviceType>>("device_type");
        }
        init { this._rawData.Set("device_type", value); }
    }

    /// <summary>
    /// ID assigned to the device by the digital wallet provider.
    /// </summary>
    public required string? Identifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("identifier");
        }
        init { this._rawData.Set("identifier", value); }
    }

    /// <summary>
    /// IP address of the device.
    /// </summary>
    public required string? IPAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ip_address");
        }
        init { this._rawData.Set("ip_address", value); }
    }

    /// <summary>
    /// Name of the device, for example "My Work Phone".
    /// </summary>
    public required string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DeviceType?.Validate();
        _ = this.Identifier;
        _ = this.IPAddress;
        _ = this.Name;
    }

    public Device() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Device(Device device)
        : base(device) { }
#pragma warning restore CS8618

    public Device(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Device(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeviceFromRaw.FromRawUnchecked"/>
    public static Device FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeviceFromRaw : IFromRawJson<Device>
{
    /// <inheritdoc/>
    public Device FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Device.FromRawUnchecked(rawData);
}

/// <summary>
/// Device type.
/// </summary>
[JsonConverter(typeof(DeviceTypeConverter))]
public enum DeviceType
{
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown,

    /// <summary>
    /// Mobile Phone
    /// </summary>
    MobilePhone,

    /// <summary>
    /// Tablet
    /// </summary>
    Tablet,

    /// <summary>
    /// Watch
    /// </summary>
    Watch,

    /// <summary>
    /// Mobile Phone or Tablet
    /// </summary>
    MobilephoneOrTablet,

    /// <summary>
    /// PC
    /// </summary>
    Pc,

    /// <summary>
    /// Household Device
    /// </summary>
    HouseholdDevice,

    /// <summary>
    /// Wearable Device
    /// </summary>
    WearableDevice,

    /// <summary>
    /// Automobile Device
    /// </summary>
    AutomobileDevice,
}

sealed class DeviceTypeConverter : JsonConverter<DeviceType>
{
    public override DeviceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" => DeviceType.Unknown,
            "mobile_phone" => DeviceType.MobilePhone,
            "tablet" => DeviceType.Tablet,
            "watch" => DeviceType.Watch,
            "mobilephone_or_tablet" => DeviceType.MobilephoneOrTablet,
            "pc" => DeviceType.Pc,
            "household_device" => DeviceType.HouseholdDevice,
            "wearable_device" => DeviceType.WearableDevice,
            "automobile_device" => DeviceType.AutomobileDevice,
            _ => (DeviceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeviceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DeviceType.Unknown => "unknown",
                DeviceType.MobilePhone => "mobile_phone",
                DeviceType.Tablet => "tablet",
                DeviceType.Watch => "watch",
                DeviceType.MobilephoneOrTablet => "mobilephone_or_tablet",
                DeviceType.Pc => "pc",
                DeviceType.HouseholdDevice => "household_device",
                DeviceType.WearableDevice => "wearable_device",
                DeviceType.AutomobileDevice => "automobile_device",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The redacted Dynamic Primary Account Number.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DynamicPrimaryAccountNumber, DynamicPrimaryAccountNumberFromRaw>)
)]
public sealed record class DynamicPrimaryAccountNumber : JsonModel
{
    /// <summary>
    /// The first 6 digits of the token's Dynamic Primary Account Number.
    /// </summary>
    public required string First6
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("first6");
        }
        init { this._rawData.Set("first6", value); }
    }

    /// <summary>
    /// The last 4 digits of the token's Dynamic Primary Account Number.
    /// </summary>
    public required string Last4
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("last4");
        }
        init { this._rawData.Set("last4", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.First6;
        _ = this.Last4;
    }

    public DynamicPrimaryAccountNumber() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DynamicPrimaryAccountNumber(DynamicPrimaryAccountNumber dynamicPrimaryAccountNumber)
        : base(dynamicPrimaryAccountNumber) { }
#pragma warning restore CS8618

    public DynamicPrimaryAccountNumber(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DynamicPrimaryAccountNumber(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DynamicPrimaryAccountNumberFromRaw.FromRawUnchecked"/>
    public static DynamicPrimaryAccountNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DynamicPrimaryAccountNumberFromRaw : IFromRawJson<DynamicPrimaryAccountNumber>
{
    /// <inheritdoc/>
    public DynamicPrimaryAccountNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DynamicPrimaryAccountNumber.FromRawUnchecked(rawData);
}

/// <summary>
/// This indicates if payments can be made with the Digital Wallet Token.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// The digital wallet token is active.
    /// </summary>
    Active,

    /// <summary>
    /// The digital wallet token has been created but not successfully activated via
    /// two-factor authentication yet.
    /// </summary>
    Inactive,

    /// <summary>
    /// The digital wallet token has been temporarily paused.
    /// </summary>
    Suspended,

    /// <summary>
    /// The digital wallet token has been permanently canceled.
    /// </summary>
    Deactivated,
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
            "active" => Status.Active,
            "inactive" => Status.Inactive,
            "suspended" => Status.Suspended,
            "deactivated" => Status.Deactivated,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "active",
                Status.Inactive => "inactive",
                Status.Suspended => "suspended",
                Status.Deactivated => "deactivated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The digital wallet app being used.
/// </summary>
[JsonConverter(typeof(TokenRequestorConverter))]
public enum TokenRequestor
{
    /// <summary>
    /// Apple Pay
    /// </summary>
    ApplePay,

    /// <summary>
    /// Google Pay
    /// </summary>
    GooglePay,

    /// <summary>
    /// Samsung Pay
    /// </summary>
    SamsungPay,

    /// <summary>
    /// Unknown
    /// </summary>
    Unknown,
}

sealed class TokenRequestorConverter : JsonConverter<TokenRequestor>
{
    public override TokenRequestor Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "apple_pay" => TokenRequestor.ApplePay,
            "google_pay" => TokenRequestor.GooglePay,
            "samsung_pay" => TokenRequestor.SamsungPay,
            "unknown" => TokenRequestor.Unknown,
            _ => (TokenRequestor)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TokenRequestor value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TokenRequestor.ApplePay => "apple_pay",
                TokenRequestor.GooglePay => "google_pay",
                TokenRequestor.SamsungPay => "samsung_pay",
                TokenRequestor.Unknown => "unknown",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `digital_wallet_token`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    DigitalWalletToken,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.DigitalWalletTokens.Type>
{
    public override global::Increase.Api.Models.DigitalWalletTokens.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "digital_wallet_token" => global::Increase
                .Api
                .Models
                .DigitalWalletTokens
                .Type
                .DigitalWalletToken,
            _ => (global::Increase.Api.Models.DigitalWalletTokens.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.DigitalWalletTokens.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.DigitalWalletTokens.Type.DigitalWalletToken =>
                    "digital_wallet_token",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Update, UpdateFromRaw>))]
public sealed record class Update : JsonModel
{
    /// <summary>
    /// The status the update changed this Digital Wallet Token to.
    /// </summary>
    public required ApiEnum<string, UpdateStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UpdateStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the update happened.
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        _ = this.Timestamp;
    }

    public Update() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Update(Update update)
        : base(update) { }
#pragma warning restore CS8618

    public Update(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Update(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateFromRaw.FromRawUnchecked"/>
    public static Update FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateFromRaw : IFromRawJson<Update>
{
    /// <inheritdoc/>
    public Update FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Update.FromRawUnchecked(rawData);
}

/// <summary>
/// The status the update changed this Digital Wallet Token to.
/// </summary>
[JsonConverter(typeof(UpdateStatusConverter))]
public enum UpdateStatus
{
    /// <summary>
    /// The digital wallet token is active.
    /// </summary>
    Active,

    /// <summary>
    /// The digital wallet token has been created but not successfully activated via
    /// two-factor authentication yet.
    /// </summary>
    Inactive,

    /// <summary>
    /// The digital wallet token has been temporarily paused.
    /// </summary>
    Suspended,

    /// <summary>
    /// The digital wallet token has been permanently canceled.
    /// </summary>
    Deactivated,
}

sealed class UpdateStatusConverter : JsonConverter<UpdateStatus>
{
    public override UpdateStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => UpdateStatus.Active,
            "inactive" => UpdateStatus.Inactive,
            "suspended" => UpdateStatus.Suspended,
            "deactivated" => UpdateStatus.Deactivated,
            _ => (UpdateStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UpdateStatus.Active => "active",
                UpdateStatus.Inactive => "inactive",
                UpdateStatus.Suspended => "suspended",
                UpdateStatus.Deactivated => "deactivated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
