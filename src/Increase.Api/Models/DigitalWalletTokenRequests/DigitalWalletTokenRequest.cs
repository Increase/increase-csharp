using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.DigitalWalletTokenRequests;

/// <summary>
/// A Digital Wallet Token Request is created each time a digital wallet app, such
/// as Apple Pay or Google Pay, requests to tokenize a Card.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DigitalWalletTokenRequest, DigitalWalletTokenRequestFromRaw>)
)]
public sealed record class DigitalWalletTokenRequest : JsonModel
{
    /// <summary>
    /// The Digital Wallet Token Request identifier.
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
    /// The identifier of the Card the tokenization was requested for.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Digital Wallet Token Request was created.
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
    /// Details of the decline. Present if and only if `outcome` is `declined`.
    /// </summary>
    public required Declined? Declined
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Declined>("declined");
        }
        init { this._rawData.Set("declined", value); }
    }

    /// <summary>
    /// The device that requested the tokenization.
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
    /// The outcome of the tokenization request.
    /// </summary>
    public required ApiEnum<string, Outcome> Outcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Outcome>>("outcome");
        }
        init { this._rawData.Set("outcome", value); }
    }

    /// <summary>
    /// Details of the provisioned Digital Wallet Token. Present if and only if `outcome`
    /// is `provisioned`.
    /// </summary>
    public required Provisioned? Provisioned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Provisioned>("provisioned");
        }
        init { this._rawData.Set("provisioned", value); }
    }

    /// <summary>
    /// The reference identifier assigned by the card network to the token.
    /// </summary>
    public required string TokenReferenceIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token_reference_identifier");
        }
        init { this._rawData.Set("token_reference_identifier", value); }
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
    /// be `digital_wallet_token_request`.
    /// </summary>
    public required ApiEnum<
        string,
        global::Increase.Api.Models.DigitalWalletTokenRequests.Type
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.DigitalWalletTokenRequests.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CardID;
        _ = this.CreatedAt;
        this.Declined?.Validate();
        this.Device.Validate();
        this.Outcome.Validate();
        this.Provisioned?.Validate();
        _ = this.TokenReferenceIdentifier;
        this.TokenRequestor.Validate();
        this.Type.Validate();
    }

    public DigitalWalletTokenRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalWalletTokenRequest(DigitalWalletTokenRequest digitalWalletTokenRequest)
        : base(digitalWalletTokenRequest) { }
#pragma warning restore CS8618

    public DigitalWalletTokenRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalWalletTokenRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalWalletTokenRequestFromRaw.FromRawUnchecked"/>
    public static DigitalWalletTokenRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalWalletTokenRequestFromRaw : IFromRawJson<DigitalWalletTokenRequest>
{
    /// <inheritdoc/>
    public DigitalWalletTokenRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigitalWalletTokenRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the decline. Present if and only if `outcome` is `declined`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Declined, DeclinedFromRaw>))]
public sealed record class Declined : JsonModel
{
    /// <summary>
    /// The reason the tokenization was declined.
    /// </summary>
    public required ApiEnum<string, Reason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Reason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Reason.Validate();
    }

    public Declined() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Declined(Declined declined)
        : base(declined) { }
#pragma warning restore CS8618

    public Declined(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Declined(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeclinedFromRaw.FromRawUnchecked"/>
    public static Declined FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Declined(ApiEnum<string, Reason> reason)
        : this()
    {
        this.Reason = reason;
    }
}

class DeclinedFromRaw : IFromRawJson<Declined>
{
    /// <inheritdoc/>
    public Declined FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Declined.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason the tokenization was declined.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    /// <summary>
    /// The card is not active.
    /// </summary>
    CardNotActive,

    /// <summary>
    /// The card does not have a two-factor authentication method.
    /// </summary>
    NoVerificationMethod,

    /// <summary>
    /// Your webhook timed out when evaluating the token provisioning attempt.
    /// </summary>
    WebhookTimedOut,

    /// <summary>
    /// Your webhook declined the token provisioning attempt.
    /// </summary>
    WebhookDeclined,

    /// <summary>
    /// The tokenization attempt failed because the Card Verification Code (CVC)
    /// was incorrect.
    /// </summary>
    IncorrectCardVerificationCode,

    /// <summary>
    /// The tokenization attempt was declined by the token requestor.
    /// </summary>
    DeclinedByTokenRequestor,

    /// <summary>
    /// The group was locked.
    /// </summary>
    GroupLocked,

    /// <summary>
    /// The account has been closed.
    /// </summary>
    AccountClosed,

    /// <summary>
    /// The account's entity was not active.
    /// </summary>
    EntityNotActive,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_not_active" => Reason.CardNotActive,
            "no_verification_method" => Reason.NoVerificationMethod,
            "webhook_timed_out" => Reason.WebhookTimedOut,
            "webhook_declined" => Reason.WebhookDeclined,
            "incorrect_card_verification_code" => Reason.IncorrectCardVerificationCode,
            "declined_by_token_requestor" => Reason.DeclinedByTokenRequestor,
            "group_locked" => Reason.GroupLocked,
            "account_closed" => Reason.AccountClosed,
            "entity_not_active" => Reason.EntityNotActive,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.CardNotActive => "card_not_active",
                Reason.NoVerificationMethod => "no_verification_method",
                Reason.WebhookTimedOut => "webhook_timed_out",
                Reason.WebhookDeclined => "webhook_declined",
                Reason.IncorrectCardVerificationCode => "incorrect_card_verification_code",
                Reason.DeclinedByTokenRequestor => "declined_by_token_requestor",
                Reason.GroupLocked => "group_locked",
                Reason.AccountClosed => "account_closed",
                Reason.EntityNotActive => "entity_not_active",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The device that requested the tokenization.
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
/// The outcome of the tokenization request.
/// </summary>
[JsonConverter(typeof(OutcomeConverter))]
public enum Outcome
{
    /// <summary>
    /// The tokenization request was approved and a Digital Wallet Token was provisioned.
    /// </summary>
    Provisioned,

    /// <summary>
    /// The tokenization request was declined.
    /// </summary>
    Declined,
}

sealed class OutcomeConverter : JsonConverter<Outcome>
{
    public override Outcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "provisioned" => Outcome.Provisioned,
            "declined" => Outcome.Declined,
            _ => (Outcome)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Outcome value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Outcome.Provisioned => "provisioned",
                Outcome.Declined => "declined",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the provisioned Digital Wallet Token. Present if and only if `outcome`
/// is `provisioned`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Provisioned, ProvisionedFromRaw>))]
public sealed record class Provisioned : JsonModel
{
    /// <summary>
    /// The identifier of the Digital Wallet Token that was provisioned.
    /// </summary>
    public required string DigitalWalletTokenID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("digital_wallet_token_id");
        }
        init { this._rawData.Set("digital_wallet_token_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DigitalWalletTokenID;
    }

    public Provisioned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Provisioned(Provisioned provisioned)
        : base(provisioned) { }
#pragma warning restore CS8618

    public Provisioned(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Provisioned(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProvisionedFromRaw.FromRawUnchecked"/>
    public static Provisioned FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Provisioned(string digitalWalletTokenID)
        : this()
    {
        this.DigitalWalletTokenID = digitalWalletTokenID;
    }
}

class ProvisionedFromRaw : IFromRawJson<Provisioned>
{
    /// <inheritdoc/>
    public Provisioned FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Provisioned.FromRawUnchecked(rawData);
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
    /// Garmin Pay
    /// </summary>
    GarminPay,

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
            "garmin_pay" => TokenRequestor.GarminPay,
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
                TokenRequestor.GarminPay => "garmin_pay",
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
/// A constant representing the object's type. For this resource it will always be `digital_wallet_token_request`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    DigitalWalletTokenRequest,
}

sealed class TypeConverter
    : JsonConverter<global::Increase.Api.Models.DigitalWalletTokenRequests.Type>
{
    public override global::Increase.Api.Models.DigitalWalletTokenRequests.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "digital_wallet_token_request" => global::Increase
                .Api
                .Models
                .DigitalWalletTokenRequests
                .Type
                .DigitalWalletTokenRequest,
            _ => (global::Increase.Api.Models.DigitalWalletTokenRequests.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.DigitalWalletTokenRequests.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase
                    .Api
                    .Models
                    .DigitalWalletTokenRequests
                    .Type
                    .DigitalWalletTokenRequest => "digital_wallet_token_request",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
