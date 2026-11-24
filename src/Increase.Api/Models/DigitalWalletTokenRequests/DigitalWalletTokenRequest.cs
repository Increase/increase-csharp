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
    /// The cardholder adding the card to the digital wallet.
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
    /// The card network the token is being provisioned on.
    /// </summary>
    public required ApiEnum<string, Network> Network
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Network>>("network");
        }
        init { this._rawData.Set("network", value); }
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
    /// How the card number was provided to the digital wallet.
    /// </summary>
    public required ApiEnum<string, PrimaryAccountNumberSource>? PrimaryAccountNumberSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PrimaryAccountNumberSource>>(
                "primary_account_number_source"
            );
        }
        init { this._rawData.Set("primary_account_number_source", value); }
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
    /// The digital wallet or merchant that requested the token.
    /// </summary>
    public required TokenRequestorDetails TokenRequestorDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TokenRequestorDetails>("token_requestor_details");
        }
        init { this._rawData.Set("token_requestor_details", value); }
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

    /// <summary>
    /// Fields related to verification of cardholder-provided values.
    /// </summary>
    public required Verification Verification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Verification>("verification");
        }
        init { this._rawData.Set("verification", value); }
    }

    /// <summary>
    /// Risk scores provided by Visa for the provisioning request. This field will
    /// be present in the JSON response if and only if `network` is equal to `visa`.
    /// </summary>
    public required Visa? Visa
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Visa>("visa");
        }
        init { this._rawData.Set("visa", value); }
    }

    /// <summary>
    /// Details about the digital wallet.
    /// </summary>
    public required Wallet Wallet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Wallet>("wallet");
        }
        init { this._rawData.Set("wallet", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CardID;
        this.Cardholder.Validate();
        _ = this.CreatedAt;
        this.Declined?.Validate();
        this.Device.Validate();
        this.Network.Validate();
        this.Outcome.Validate();
        this.PrimaryAccountNumberSource?.Validate();
        this.Provisioned?.Validate();
        _ = this.TokenReferenceIdentifier;
        this.TokenRequestor.Validate();
        this.TokenRequestorDetails.Validate();
        this.Type.Validate();
        this.Verification.Validate();
        this.Visa?.Validate();
        this.Wallet.Validate();
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
/// The cardholder adding the card to the digital wallet.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Cardholder, CardholderFromRaw>))]
public sealed record class Cardholder : JsonModel
{
    /// <summary>
    /// The cardholder's name, as entered in the digital wallet.
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

    /// <summary>
    /// The given expiration date did not match the card's value.
    /// </summary>
    CardExpirationMismatch,
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
            "card_expiration_mismatch" => Reason.CardExpirationMismatch,
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
                Reason.CardExpirationMismatch => "card_expiration_mismatch",
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
/// The card network the token is being provisioned on.
/// </summary>
[JsonConverter(typeof(NetworkConverter))]
public enum Network
{
    /// <summary>
    /// Visa
    /// </summary>
    Visa,
}

sealed class NetworkConverter : JsonConverter<Network>
{
    public override Network Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => Network.Visa,
            _ => (Network)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Network value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Network.Visa => "visa",
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
/// How the card number was provided to the digital wallet.
/// </summary>
[JsonConverter(typeof(PrimaryAccountNumberSourceConverter))]
public enum PrimaryAccountNumberSource
{
    /// <summary>
    /// The cardholder entered the card number manually.
    /// </summary>
    KeyEntered,

    /// <summary>
    /// The card number was already on file with the token requestor.
    /// </summary>
    OnFile,

    /// <summary>
    /// The card was added from your mobile app using push provisioning.
    /// </summary>
    MobileApp,

    /// <summary>
    /// The card number was sourced from an existing token.
    /// </summary>
    Token,

    /// <summary>
    /// The card number was read from the chip of the physical card.
    /// </summary>
    ChipDip,

    /// <summary>
    /// The card number was read by tapping the physical card on the device.
    /// </summary>
    ContactlessTap,
}

sealed class PrimaryAccountNumberSourceConverter : JsonConverter<PrimaryAccountNumberSource>
{
    public override PrimaryAccountNumberSource Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "key_entered" => PrimaryAccountNumberSource.KeyEntered,
            "on_file" => PrimaryAccountNumberSource.OnFile,
            "mobile_app" => PrimaryAccountNumberSource.MobileApp,
            "token" => PrimaryAccountNumberSource.Token,
            "chip_dip" => PrimaryAccountNumberSource.ChipDip,
            "contactless_tap" => PrimaryAccountNumberSource.ContactlessTap,
            _ => (PrimaryAccountNumberSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PrimaryAccountNumberSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PrimaryAccountNumberSource.KeyEntered => "key_entered",
                PrimaryAccountNumberSource.OnFile => "on_file",
                PrimaryAccountNumberSource.MobileApp => "mobile_app",
                PrimaryAccountNumberSource.Token => "token",
                PrimaryAccountNumberSource.ChipDip => "chip_dip",
                PrimaryAccountNumberSource.ContactlessTap => "contactless_tap",
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
/// The digital wallet or merchant that requested the token.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TokenRequestorDetails, TokenRequestorDetailsFromRaw>))]
public sealed record class TokenRequestorDetails : JsonModel
{
    /// <summary>
    /// The identifier assigned to the token requestor by the card network.
    /// </summary>
    public required string Identifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("identifier");
        }
        init { this._rawData.Set("identifier", value); }
    }

    /// <summary>
    /// The name of the token requestor, for example "Apple Inc.".
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
        _ = this.Identifier;
        _ = this.Name;
    }

    public TokenRequestorDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TokenRequestorDetails(TokenRequestorDetails tokenRequestorDetails)
        : base(tokenRequestorDetails) { }
#pragma warning restore CS8618

    public TokenRequestorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TokenRequestorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TokenRequestorDetailsFromRaw.FromRawUnchecked"/>
    public static TokenRequestorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TokenRequestorDetailsFromRaw : IFromRawJson<TokenRequestorDetails>
{
    /// <inheritdoc/>
    public TokenRequestorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TokenRequestorDetails.FromRawUnchecked(rawData);
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

/// <summary>
/// Fields related to verification of cardholder-provided values.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Verification, VerificationFromRaw>))]
public sealed record class Verification : JsonModel
{
    /// <summary>
    /// Cardholder address provided in the provisioning request and the address on
    /// file we verified it against.
    /// </summary>
    public required CardholderAddress CardholderAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardholderAddress>("cardholder_address");
        }
        init { this._rawData.Set("cardholder_address", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CardholderAddress.Validate();
    }

    public Verification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Verification(Verification verification)
        : base(verification) { }
#pragma warning restore CS8618

    public Verification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Verification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerificationFromRaw.FromRawUnchecked"/>
    public static Verification FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Verification(CardholderAddress cardholderAddress)
        : this()
    {
        this.CardholderAddress = cardholderAddress;
    }
}

class VerificationFromRaw : IFromRawJson<Verification>
{
    /// <inheritdoc/>
    public Verification FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Verification.FromRawUnchecked(rawData);
}

/// <summary>
/// Cardholder address provided in the provisioning request and the address on file
/// we verified it against.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardholderAddress, CardholderAddressFromRaw>))]
public sealed record class CardholderAddress : JsonModel
{
    /// <summary>
    /// Line 1 of the address on file for the cardholder.
    /// </summary>
    public required string? ActualLine1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("actual_line1");
        }
        init { this._rawData.Set("actual_line1", value); }
    }

    /// <summary>
    /// The postal code of the address on file for the cardholder.
    /// </summary>
    public required string? ActualPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("actual_postal_code");
        }
        init { this._rawData.Set("actual_postal_code", value); }
    }

    /// <summary>
    /// The cardholder address line 1 provided for verification in the provisioning request.
    /// </summary>
    public required string? ProvidedLine1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("provided_line1");
        }
        init { this._rawData.Set("provided_line1", value); }
    }

    /// <summary>
    /// The postal code provided for verification in the provisioning request.
    /// </summary>
    public required string? ProvidedPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("provided_postal_code");
        }
        init { this._rawData.Set("provided_postal_code", value); }
    }

    /// <summary>
    /// The address verification result.
    /// </summary>
    public required ApiEnum<string, Result> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Result>>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActualLine1;
        _ = this.ActualPostalCode;
        _ = this.ProvidedLine1;
        _ = this.ProvidedPostalCode;
        this.Result.Validate();
    }

    public CardholderAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardholderAddress(CardholderAddress cardholderAddress)
        : base(cardholderAddress) { }
#pragma warning restore CS8618

    public CardholderAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardholderAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardholderAddressFromRaw.FromRawUnchecked"/>
    public static CardholderAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardholderAddressFromRaw : IFromRawJson<CardholderAddress>
{
    /// <inheritdoc/>
    public CardholderAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardholderAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The address verification result.
/// </summary>
[JsonConverter(typeof(ResultConverter))]
public enum Result
{
    /// <summary>
    /// No address information was provided in the authorization request.
    /// </summary>
    NotChecked,

    /// <summary>
    /// Postal code matches, but the street address does not match or was not provided.
    /// </summary>
    PostalCodeMatchAddressNoMatch,

    /// <summary>
    /// Postal code does not match, but the street address matches or was not provided.
    /// </summary>
    PostalCodeNoMatchAddressMatch,

    /// <summary>
    /// Postal code and street address match.
    /// </summary>
    Match,

    /// <summary>
    /// Postal code and street address do not match.
    /// </summary>
    NoMatch,

    /// <summary>
    /// Postal code matches, but the street address was not verified. (deprecated)
    /// </summary>
    PostalCodeMatchAddressNotChecked,
}

sealed class ResultConverter : JsonConverter<Result>
{
    public override Result Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_checked" => Result.NotChecked,
            "postal_code_match_address_no_match" => Result.PostalCodeMatchAddressNoMatch,
            "postal_code_no_match_address_match" => Result.PostalCodeNoMatchAddressMatch,
            "match" => Result.Match,
            "no_match" => Result.NoMatch,
            "postal_code_match_address_not_checked" => Result.PostalCodeMatchAddressNotChecked,
            _ => (Result)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Result value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Result.NotChecked => "not_checked",
                Result.PostalCodeMatchAddressNoMatch => "postal_code_match_address_no_match",
                Result.PostalCodeNoMatchAddressMatch => "postal_code_no_match_address_match",
                Result.Match => "match",
                Result.NoMatch => "no_match",
                Result.PostalCodeMatchAddressNotChecked => "postal_code_match_address_not_checked",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Risk scores provided by Visa for the provisioning request. This field will be
/// present in the JSON response if and only if `network` is equal to `visa`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Visa, VisaFromRaw>))]
public sealed record class Visa : JsonModel
{
    /// <summary>
    /// Visa's risk score for the card, based on its transaction history, from 0 to
    /// 99. A higher score indicates a higher risk.
    /// </summary>
    public required long? NetworkRiskScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("network_risk_score");
        }
        init { this._rawData.Set("network_risk_score", value); }
    }

    /// <summary>
    /// Visa's risk score for the provisioning request, from 1 to 99. A higher score
    /// indicates a higher risk.
    /// </summary>
    public required long? ProvisioningRiskScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("provisioning_risk_score");
        }
        init { this._rawData.Set("provisioning_risk_score", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NetworkRiskScore;
        _ = this.ProvisioningRiskScore;
    }

    public Visa() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Visa(Visa visa)
        : base(visa) { }
#pragma warning restore CS8618

    public Visa(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Visa(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VisaFromRaw.FromRawUnchecked"/>
    public static Visa FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VisaFromRaw : IFromRawJson<Visa>
{
    /// <inheritdoc/>
    public Visa FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Visa.FromRawUnchecked(rawData);
}

/// <summary>
/// Details about the digital wallet.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Wallet, WalletFromRaw>))]
public sealed record class Wallet : JsonModel
{
    /// <summary>
    /// The number of days since the email address was added to the cardholder's digital
    /// wallet account, up to 999.
    /// </summary>
    public required long? AccountEmailAgeDays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("account_email_age_days");
        }
        init { this._rawData.Set("account_email_age_days", value); }
    }

    /// <summary>
    /// An identifier for the cardholder's account with the digital wallet.
    /// </summary>
    public required string? AccountIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_identifier");
        }
        init { this._rawData.Set("account_identifier", value); }
    }

    /// <summary>
    /// How much the digital wallet trusts the cardholder's account, from 1 to 5.
    /// A higher score indicates more trust.
    /// </summary>
    public required long? AccountScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("account_score");
        }
        init { this._rawData.Set("account_score", value); }
    }

    /// <summary>
    /// How much the digital wallet trusts the device the card is being added to,
    /// from 1 to 5. A higher score indicates more trust.
    /// </summary>
    public required long? DeviceScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("device_score");
        }
        init { this._rawData.Set("device_score", value); }
    }

    /// <summary>
    /// A hash of the email address on the cardholder's digital wallet account.
    /// </summary>
    public required string? EmailHash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email_hash");
        }
        init { this._rawData.Set("email_hash", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountEmailAgeDays;
        _ = this.AccountIdentifier;
        _ = this.AccountScore;
        _ = this.DeviceScore;
        _ = this.EmailHash;
    }

    public Wallet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Wallet(Wallet wallet)
        : base(wallet) { }
#pragma warning restore CS8618

    public Wallet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Wallet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WalletFromRaw.FromRawUnchecked"/>
    public static Wallet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WalletFromRaw : IFromRawJson<Wallet>
{
    /// <inheritdoc/>
    public Wallet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Wallet.FromRawUnchecked(rawData);
}
