using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.RealTimeDecisions;

/// <summary>
/// Real Time Decisions are created when your application needs to take action in
/// real-time to some event such as a card authorization. For more information, see
/// our [Real-Time Decisions guide](https://increase.com/documentation/real-time-decisions).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RealTimeDecision, RealTimeDecisionFromRaw>))]
public sealed record class RealTimeDecision : JsonModel
{
    /// <summary>
    /// The Real-Time Decision identifier.
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
    /// Fields related to a 3DS authentication attempt.
    /// </summary>
    public required RealTimeDecisionCardAuthentication? CardAuthentication
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardAuthentication>(
                "card_authentication"
            );
        }
        init { this._rawData.Set("card_authentication", value); }
    }

    /// <summary>
    /// Fields related to a 3DS authentication attempt.
    /// </summary>
    public required RealTimeDecisionCardAuthenticationChallenge? CardAuthenticationChallenge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardAuthenticationChallenge>(
                "card_authentication_challenge"
            );
        }
        init { this._rawData.Set("card_authentication_challenge", value); }
    }

    /// <summary>
    /// Fields related to a card authorization.
    /// </summary>
    public required RealTimeDecisionCardAuthorization? CardAuthorization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardAuthorization>(
                "card_authorization"
            );
        }
        init { this._rawData.Set("card_authorization", value); }
    }

    /// <summary>
    /// Fields related to a card balance inquiry.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiry? CardBalanceInquiry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardBalanceInquiry>(
                "card_balance_inquiry"
            );
        }
        init { this._rawData.Set("card_balance_inquiry", value); }
    }

    /// <summary>
    /// The category of the Real-Time Decision.
    /// </summary>
    public required ApiEnum<string, RealTimeDecisionCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RealTimeDecisionCategory>>(
                "category"
            );
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Real-Time Decision was created.
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
    /// Fields related to a digital wallet authentication attempt.
    /// </summary>
    public required RealTimeDecisionDigitalWalletAuthentication? DigitalWalletAuthentication
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionDigitalWalletAuthentication>(
                "digital_wallet_authentication"
            );
        }
        init { this._rawData.Set("digital_wallet_authentication", value); }
    }

    /// <summary>
    /// Fields related to a digital wallet token provisioning attempt.
    /// </summary>
    public required RealTimeDecisionDigitalWalletToken? DigitalWalletToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionDigitalWalletToken>(
                "digital_wallet_token"
            );
        }
        init { this._rawData.Set("digital_wallet_token", value); }
    }

    /// <summary>
    /// The status of the Real-Time Decision.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// your application can no longer respond to the Real-Time Decision.
    /// </summary>
    public required System::DateTimeOffset TimeoutAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("timeout_at");
        }
        init { this._rawData.Set("timeout_at", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `real_time_decision`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.RealTimeDecisions.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.RealTimeDecisions.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.CardAuthentication?.Validate();
        this.CardAuthenticationChallenge?.Validate();
        this.CardAuthorization?.Validate();
        this.CardBalanceInquiry?.Validate();
        this.Category.Validate();
        _ = this.CreatedAt;
        this.DigitalWalletAuthentication?.Validate();
        this.DigitalWalletToken?.Validate();
        this.Status.Validate();
        _ = this.TimeoutAt;
        this.Type.Validate();
    }

    public RealTimeDecision() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecision(RealTimeDecision realTimeDecision)
        : base(realTimeDecision) { }
#pragma warning restore CS8618

    public RealTimeDecision(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecision(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionFromRaw.FromRawUnchecked"/>
    public static RealTimeDecision FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionFromRaw : IFromRawJson<RealTimeDecision>
{
    /// <inheritdoc/>
    public RealTimeDecision FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RealTimeDecision.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields related to a 3DS authentication attempt.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardAuthentication,
        RealTimeDecisionCardAuthenticationFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardAuthentication : JsonModel
{
    /// <summary>
    /// A unique identifier assigned by the Access Control Server (us) for this transaction.
    /// </summary>
    public required string AccessControlServerTransactionIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "access_control_server_transaction_identifier"
            );
        }
        init { this._rawData.Set("access_control_server_transaction_identifier", value); }
    }

    /// <summary>
    /// The identifier of the Account the card belongs to.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// The city of the cardholder billing address associated with the card used
    /// for this purchase.
    /// </summary>
    public required string? BillingAddressCity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_address_city");
        }
        init { this._rawData.Set("billing_address_city", value); }
    }

    /// <summary>
    /// The country of the cardholder billing address associated with the card used
    /// for this purchase.
    /// </summary>
    public required string? BillingAddressCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_address_country");
        }
        init { this._rawData.Set("billing_address_country", value); }
    }

    /// <summary>
    /// The first line of the cardholder billing address associated with the card
    /// used for this purchase.
    /// </summary>
    public required string? BillingAddressLine1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_address_line1");
        }
        init { this._rawData.Set("billing_address_line1", value); }
    }

    /// <summary>
    /// The second line of the cardholder billing address associated with the card
    /// used for this purchase.
    /// </summary>
    public required string? BillingAddressLine2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_address_line2");
        }
        init { this._rawData.Set("billing_address_line2", value); }
    }

    /// <summary>
    /// The third line of the cardholder billing address associated with the card
    /// used for this purchase.
    /// </summary>
    public required string? BillingAddressLine3
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_address_line3");
        }
        init { this._rawData.Set("billing_address_line3", value); }
    }

    /// <summary>
    /// The postal code of the cardholder billing address associated with the card
    /// used for this purchase.
    /// </summary>
    public required string? BillingAddressPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_address_postal_code");
        }
        init { this._rawData.Set("billing_address_postal_code", value); }
    }

    /// <summary>
    /// The US state of the cardholder billing address associated with the card used
    /// for this purchase.
    /// </summary>
    public required string? BillingAddressState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_address_state");
        }
        init { this._rawData.Set("billing_address_state", value); }
    }

    /// <summary>
    /// The identifier of the Card.
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
    /// The email address of the cardholder.
    /// </summary>
    public required string? CardholderEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cardholder_email");
        }
        init { this._rawData.Set("cardholder_email", value); }
    }

    /// <summary>
    /// The name of the cardholder.
    /// </summary>
    public required string? CardholderName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cardholder_name");
        }
        init { this._rawData.Set("cardholder_name", value); }
    }

    /// <summary>
    /// Whether or not the authentication attempt was approved.
    /// </summary>
    public required ApiEnum<string, RealTimeDecisionCardAuthenticationDecision>? Decision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, RealTimeDecisionCardAuthenticationDecision>
            >("decision");
        }
        init { this._rawData.Set("decision", value); }
    }

    /// <summary>
    /// The device channel of the card authentication attempt.
    /// </summary>
    public required DeviceChannel DeviceChannel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DeviceChannel>("device_channel");
        }
        init { this._rawData.Set("device_channel", value); }
    }

    /// <summary>
    /// A unique identifier assigned by the Directory Server (the card network) for
    /// this transaction.
    /// </summary>
    public required string DirectoryServerTransactionIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("directory_server_transaction_identifier");
        }
        init { this._rawData.Set("directory_server_transaction_identifier", value); }
    }

    /// <summary>
    /// The merchant identifier (commonly abbreviated as MID) of the merchant the
    /// card is transacting with.
    /// </summary>
    public required string? MerchantAcceptorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_acceptor_id");
        }
        init { this._rawData.Set("merchant_acceptor_id", value); }
    }

    /// <summary>
    /// The Merchant Category Code (commonly abbreviated as MCC) of the merchant the
    /// card is transacting with.
    /// </summary>
    public required string? MerchantCategoryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_category_code");
        }
        init { this._rawData.Set("merchant_category_code", value); }
    }

    /// <summary>
    /// The country the merchant resides in.
    /// </summary>
    public required string? MerchantCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_country");
        }
        init { this._rawData.Set("merchant_country", value); }
    }

    /// <summary>
    /// The name of the merchant.
    /// </summary>
    public required string? MerchantName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_name");
        }
        init { this._rawData.Set("merchant_name", value); }
    }

    /// <summary>
    /// The message category of the card authentication attempt.
    /// </summary>
    public required MessageCategory MessageCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MessageCategory>("message_category");
        }
        init { this._rawData.Set("message_category", value); }
    }

    /// <summary>
    /// The ID of a prior Card Authentication that the requestor used to authenticate
    /// this cardholder for a previous transaction.
    /// </summary>
    public required string? PriorAuthenticatedCardPaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prior_authenticated_card_payment_id");
        }
        init { this._rawData.Set("prior_authenticated_card_payment_id", value); }
    }

    /// <summary>
    /// The 3DS requestor authentication indicator describes why the authentication
    /// attempt is performed, such as for a recurring transaction.
    /// </summary>
    public required ApiEnum<
        string,
        RequestorAuthenticationIndicator
    >? RequestorAuthenticationIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, RequestorAuthenticationIndicator>
            >("requestor_authentication_indicator");
        }
        init { this._rawData.Set("requestor_authentication_indicator", value); }
    }

    /// <summary>
    /// Indicates whether a challenge is requested for this transaction.
    /// </summary>
    public required ApiEnum<string, RequestorChallengeIndicator>? RequestorChallengeIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RequestorChallengeIndicator>>(
                "requestor_challenge_indicator"
            );
        }
        init { this._rawData.Set("requestor_challenge_indicator", value); }
    }

    /// <summary>
    /// The name of the 3DS requestor.
    /// </summary>
    public required string RequestorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("requestor_name");
        }
        init { this._rawData.Set("requestor_name", value); }
    }

    /// <summary>
    /// The URL of the 3DS requestor.
    /// </summary>
    public required string RequestorUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("requestor_url");
        }
        init { this._rawData.Set("requestor_url", value); }
    }

    /// <summary>
    /// The city of the shipping address associated with this purchase.
    /// </summary>
    public required string? ShippingAddressCity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_address_city");
        }
        init { this._rawData.Set("shipping_address_city", value); }
    }

    /// <summary>
    /// The country of the shipping address associated with this purchase.
    /// </summary>
    public required string? ShippingAddressCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_address_country");
        }
        init { this._rawData.Set("shipping_address_country", value); }
    }

    /// <summary>
    /// The first line of the shipping address associated with this purchase.
    /// </summary>
    public required string? ShippingAddressLine1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_address_line1");
        }
        init { this._rawData.Set("shipping_address_line1", value); }
    }

    /// <summary>
    /// The second line of the shipping address associated with this purchase.
    /// </summary>
    public required string? ShippingAddressLine2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_address_line2");
        }
        init { this._rawData.Set("shipping_address_line2", value); }
    }

    /// <summary>
    /// The third line of the shipping address associated with this purchase.
    /// </summary>
    public required string? ShippingAddressLine3
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_address_line3");
        }
        init { this._rawData.Set("shipping_address_line3", value); }
    }

    /// <summary>
    /// The postal code of the shipping address associated with this purchase.
    /// </summary>
    public required string? ShippingAddressPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_address_postal_code");
        }
        init { this._rawData.Set("shipping_address_postal_code", value); }
    }

    /// <summary>
    /// The US state of the shipping address associated with this purchase.
    /// </summary>
    public required string? ShippingAddressState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_address_state");
        }
        init { this._rawData.Set("shipping_address_state", value); }
    }

    /// <summary>
    /// A unique identifier assigned by the 3DS Server initiating the authentication
    /// attempt for this transaction.
    /// </summary>
    public required string ThreeDSecureServerTransactionIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "three_d_secure_server_transaction_identifier"
            );
        }
        init { this._rawData.Set("three_d_secure_server_transaction_identifier", value); }
    }

    /// <summary>
    /// The identifier of the Card Payment this authentication attempt will belong
    /// to. Available in the API once the card authentication has completed.
    /// </summary>
    public required string UpcomingCardPaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("upcoming_card_payment_id");
        }
        init { this._rawData.Set("upcoming_card_payment_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessControlServerTransactionIdentifier;
        _ = this.AccountID;
        _ = this.BillingAddressCity;
        _ = this.BillingAddressCountry;
        _ = this.BillingAddressLine1;
        _ = this.BillingAddressLine2;
        _ = this.BillingAddressLine3;
        _ = this.BillingAddressPostalCode;
        _ = this.BillingAddressState;
        _ = this.CardID;
        _ = this.CardholderEmail;
        _ = this.CardholderName;
        this.Decision?.Validate();
        this.DeviceChannel.Validate();
        _ = this.DirectoryServerTransactionIdentifier;
        _ = this.MerchantAcceptorID;
        _ = this.MerchantCategoryCode;
        _ = this.MerchantCountry;
        _ = this.MerchantName;
        this.MessageCategory.Validate();
        _ = this.PriorAuthenticatedCardPaymentID;
        this.RequestorAuthenticationIndicator?.Validate();
        this.RequestorChallengeIndicator?.Validate();
        _ = this.RequestorName;
        _ = this.RequestorUrl;
        _ = this.ShippingAddressCity;
        _ = this.ShippingAddressCountry;
        _ = this.ShippingAddressLine1;
        _ = this.ShippingAddressLine2;
        _ = this.ShippingAddressLine3;
        _ = this.ShippingAddressPostalCode;
        _ = this.ShippingAddressState;
        _ = this.ThreeDSecureServerTransactionIdentifier;
        _ = this.UpcomingCardPaymentID;
    }

    public RealTimeDecisionCardAuthentication() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardAuthentication(
        RealTimeDecisionCardAuthentication realTimeDecisionCardAuthentication
    )
        : base(realTimeDecisionCardAuthentication) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardAuthentication(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardAuthentication(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardAuthenticationFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardAuthentication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardAuthenticationFromRaw : IFromRawJson<RealTimeDecisionCardAuthentication>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardAuthentication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardAuthentication.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether or not the authentication attempt was approved.
/// </summary>
[JsonConverter(typeof(RealTimeDecisionCardAuthenticationDecisionConverter))]
public enum RealTimeDecisionCardAuthenticationDecision
{
    /// <summary>
    /// Approve the authentication attempt without triggering a challenge.
    /// </summary>
    Approve,

    /// <summary>
    /// Request further validation before approving the authentication attempt.
    /// </summary>
    Challenge,

    /// <summary>
    /// Deny the authentication attempt.
    /// </summary>
    Deny,
}

sealed class RealTimeDecisionCardAuthenticationDecisionConverter
    : JsonConverter<RealTimeDecisionCardAuthenticationDecision>
{
    public override RealTimeDecisionCardAuthenticationDecision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approve" => RealTimeDecisionCardAuthenticationDecision.Approve,
            "challenge" => RealTimeDecisionCardAuthenticationDecision.Challenge,
            "deny" => RealTimeDecisionCardAuthenticationDecision.Deny,
            _ => (RealTimeDecisionCardAuthenticationDecision)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionCardAuthenticationDecision value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionCardAuthenticationDecision.Approve => "approve",
                RealTimeDecisionCardAuthenticationDecision.Challenge => "challenge",
                RealTimeDecisionCardAuthenticationDecision.Deny => "deny",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The device channel of the card authentication attempt.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DeviceChannel, DeviceChannelFromRaw>))]
public sealed record class DeviceChannel : JsonModel
{
    /// <summary>
    /// Fields specific to the browser device channel.
    /// </summary>
    public required Browser? Browser
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Browser>("browser");
        }
        init { this._rawData.Set("browser", value); }
    }

    /// <summary>
    /// The category of the device channel.
    /// </summary>
    public required ApiEnum<string, Category> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Category>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Fields specific to merchant initiated transactions.
    /// </summary>
    public required MerchantInitiated? MerchantInitiated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MerchantInitiated>("merchant_initiated");
        }
        init { this._rawData.Set("merchant_initiated", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Browser?.Validate();
        this.Category.Validate();
        this.MerchantInitiated?.Validate();
    }

    public DeviceChannel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeviceChannel(DeviceChannel deviceChannel)
        : base(deviceChannel) { }
#pragma warning restore CS8618

    public DeviceChannel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeviceChannel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeviceChannelFromRaw.FromRawUnchecked"/>
    public static DeviceChannel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeviceChannelFromRaw : IFromRawJson<DeviceChannel>
{
    /// <inheritdoc/>
    public DeviceChannel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DeviceChannel.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields specific to the browser device channel.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Browser, BrowserFromRaw>))]
public sealed record class Browser : JsonModel
{
    /// <summary>
    /// The accept header from the cardholder's browser.
    /// </summary>
    public required string? AcceptHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("accept_header");
        }
        init { this._rawData.Set("accept_header", value); }
    }

    /// <summary>
    /// The IP address of the cardholder's browser.
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
    /// Whether JavaScript is enabled in the cardholder's browser.
    /// </summary>
    public required ApiEnum<string, JavascriptEnabled>? JavascriptEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, JavascriptEnabled>>(
                "javascript_enabled"
            );
        }
        init { this._rawData.Set("javascript_enabled", value); }
    }

    /// <summary>
    /// The language of the cardholder's browser.
    /// </summary>
    public required string? Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("language");
        }
        init { this._rawData.Set("language", value); }
    }

    /// <summary>
    /// The user agent of the cardholder's browser.
    /// </summary>
    public required string? UserAgent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_agent");
        }
        init { this._rawData.Set("user_agent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcceptHeader;
        _ = this.IPAddress;
        this.JavascriptEnabled?.Validate();
        _ = this.Language;
        _ = this.UserAgent;
    }

    public Browser() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Browser(Browser browser)
        : base(browser) { }
#pragma warning restore CS8618

    public Browser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Browser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserFromRaw.FromRawUnchecked"/>
    public static Browser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserFromRaw : IFromRawJson<Browser>
{
    /// <inheritdoc/>
    public Browser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Browser.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether JavaScript is enabled in the cardholder's browser.
/// </summary>
[JsonConverter(typeof(JavascriptEnabledConverter))]
public enum JavascriptEnabled
{
    /// <summary>
    /// JavaScript is enabled in the cardholder's browser.
    /// </summary>
    Enabled,

    /// <summary>
    /// JavaScript is not enabled in the cardholder's browser.
    /// </summary>
    Disabled,
}

sealed class JavascriptEnabledConverter : JsonConverter<JavascriptEnabled>
{
    public override JavascriptEnabled Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enabled" => JavascriptEnabled.Enabled,
            "disabled" => JavascriptEnabled.Disabled,
            _ => (JavascriptEnabled)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JavascriptEnabled value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JavascriptEnabled.Enabled => "enabled",
                JavascriptEnabled.Disabled => "disabled",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The category of the device channel.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    /// <summary>
    /// The authentication attempt was made from an app.
    /// </summary>
    App,

    /// <summary>
    /// The authentication attempt was made from a browser.
    /// </summary>
    Browser,

    /// <summary>
    /// The authentication attempt was initiated by the 3DS Requestor.
    /// </summary>
    ThreeDSRequestorInitiated,
}

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "app" => Category.App,
            "browser" => Category.Browser,
            "three_ds_requestor_initiated" => Category.ThreeDSRequestorInitiated,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.App => "app",
                Category.Browser => "browser",
                Category.ThreeDSRequestorInitiated => "three_ds_requestor_initiated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to merchant initiated transactions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MerchantInitiated, MerchantInitiatedFromRaw>))]
public sealed record class MerchantInitiated : JsonModel
{
    /// <summary>
    /// The merchant initiated indicator for the transaction.
    /// </summary>
    public required ApiEnum<string, Indicator> Indicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Indicator>>("indicator");
        }
        init { this._rawData.Set("indicator", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Indicator.Validate();
    }

    public MerchantInitiated() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MerchantInitiated(MerchantInitiated merchantInitiated)
        : base(merchantInitiated) { }
#pragma warning restore CS8618

    public MerchantInitiated(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MerchantInitiated(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MerchantInitiatedFromRaw.FromRawUnchecked"/>
    public static MerchantInitiated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MerchantInitiated(ApiEnum<string, Indicator> indicator)
        : this()
    {
        this.Indicator = indicator;
    }
}

class MerchantInitiatedFromRaw : IFromRawJson<MerchantInitiated>
{
    /// <inheritdoc/>
    public MerchantInitiated FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MerchantInitiated.FromRawUnchecked(rawData);
}

/// <summary>
/// The merchant initiated indicator for the transaction.
/// </summary>
[JsonConverter(typeof(IndicatorConverter))]
public enum Indicator
{
    /// <summary>
    /// Recurring transaction.
    /// </summary>
    RecurringTransaction,

    /// <summary>
    /// Installment transaction.
    /// </summary>
    InstallmentTransaction,

    /// <summary>
    /// Add card.
    /// </summary>
    AddCard,

    /// <summary>
    /// Maintain card information.
    /// </summary>
    MaintainCardInformation,

    /// <summary>
    /// Account verification.
    /// </summary>
    AccountVerification,

    /// <summary>
    /// Split or delayed shipment.
    /// </summary>
    SplitDelayedShipment,

    /// <summary>
    /// Top up.
    /// </summary>
    TopUp,

    /// <summary>
    /// Mail order.
    /// </summary>
    MailOrder,

    /// <summary>
    /// Telephone order.
    /// </summary>
    TelephoneOrder,

    /// <summary>
    /// Whitelist status check.
    /// </summary>
    WhitelistStatusCheck,

    /// <summary>
    /// Other payment.
    /// </summary>
    OtherPayment,

    /// <summary>
    /// Billing agreement.
    /// </summary>
    BillingAgreement,

    /// <summary>
    /// Device binding status check.
    /// </summary>
    DeviceBindingStatusCheck,

    /// <summary>
    /// Card security code status check.
    /// </summary>
    CardSecurityCodeStatusCheck,

    /// <summary>
    /// Delayed shipment.
    /// </summary>
    DelayedShipment,

    /// <summary>
    /// Split payment.
    /// </summary>
    SplitPayment,

    /// <summary>
    /// FIDO credential deletion.
    /// </summary>
    FidoCredentialDeletion,

    /// <summary>
    /// FIDO credential registration.
    /// </summary>
    FidoCredentialRegistration,

    /// <summary>
    /// Decoupled authentication fallback.
    /// </summary>
    DecoupledAuthenticationFallback,
}

sealed class IndicatorConverter : JsonConverter<Indicator>
{
    public override Indicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "recurring_transaction" => Indicator.RecurringTransaction,
            "installment_transaction" => Indicator.InstallmentTransaction,
            "add_card" => Indicator.AddCard,
            "maintain_card_information" => Indicator.MaintainCardInformation,
            "account_verification" => Indicator.AccountVerification,
            "split_delayed_shipment" => Indicator.SplitDelayedShipment,
            "top_up" => Indicator.TopUp,
            "mail_order" => Indicator.MailOrder,
            "telephone_order" => Indicator.TelephoneOrder,
            "whitelist_status_check" => Indicator.WhitelistStatusCheck,
            "other_payment" => Indicator.OtherPayment,
            "billing_agreement" => Indicator.BillingAgreement,
            "device_binding_status_check" => Indicator.DeviceBindingStatusCheck,
            "card_security_code_status_check" => Indicator.CardSecurityCodeStatusCheck,
            "delayed_shipment" => Indicator.DelayedShipment,
            "split_payment" => Indicator.SplitPayment,
            "fido_credential_deletion" => Indicator.FidoCredentialDeletion,
            "fido_credential_registration" => Indicator.FidoCredentialRegistration,
            "decoupled_authentication_fallback" => Indicator.DecoupledAuthenticationFallback,
            _ => (Indicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Indicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Indicator.RecurringTransaction => "recurring_transaction",
                Indicator.InstallmentTransaction => "installment_transaction",
                Indicator.AddCard => "add_card",
                Indicator.MaintainCardInformation => "maintain_card_information",
                Indicator.AccountVerification => "account_verification",
                Indicator.SplitDelayedShipment => "split_delayed_shipment",
                Indicator.TopUp => "top_up",
                Indicator.MailOrder => "mail_order",
                Indicator.TelephoneOrder => "telephone_order",
                Indicator.WhitelistStatusCheck => "whitelist_status_check",
                Indicator.OtherPayment => "other_payment",
                Indicator.BillingAgreement => "billing_agreement",
                Indicator.DeviceBindingStatusCheck => "device_binding_status_check",
                Indicator.CardSecurityCodeStatusCheck => "card_security_code_status_check",
                Indicator.DelayedShipment => "delayed_shipment",
                Indicator.SplitPayment => "split_payment",
                Indicator.FidoCredentialDeletion => "fido_credential_deletion",
                Indicator.FidoCredentialRegistration => "fido_credential_registration",
                Indicator.DecoupledAuthenticationFallback => "decoupled_authentication_fallback",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The message category of the card authentication attempt.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageCategory, MessageCategoryFromRaw>))]
public sealed record class MessageCategory : JsonModel
{
    /// <summary>
    /// The category of the card authentication attempt.
    /// </summary>
    public required ApiEnum<string, MessageCategoryCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MessageCategoryCategory>>(
                "category"
            );
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Fields specific to non-payment authentication attempts.
    /// </summary>
    public required NonPayment? NonPayment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NonPayment>("non_payment");
        }
        init { this._rawData.Set("non_payment", value); }
    }

    /// <summary>
    /// Fields specific to payment authentication attempts.
    /// </summary>
    public required Payment? Payment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Payment>("payment");
        }
        init { this._rawData.Set("payment", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.NonPayment?.Validate();
        this.Payment?.Validate();
    }

    public MessageCategory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageCategory(MessageCategory messageCategory)
        : base(messageCategory) { }
#pragma warning restore CS8618

    public MessageCategory(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageCategory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageCategoryFromRaw.FromRawUnchecked"/>
    public static MessageCategory FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageCategoryFromRaw : IFromRawJson<MessageCategory>
{
    /// <inheritdoc/>
    public MessageCategory FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageCategory.FromRawUnchecked(rawData);
}

/// <summary>
/// The category of the card authentication attempt.
/// </summary>
[JsonConverter(typeof(MessageCategoryCategoryConverter))]
public enum MessageCategoryCategory
{
    /// <summary>
    /// The authentication attempt is for a payment.
    /// </summary>
    PaymentAuthentication,

    /// <summary>
    /// The authentication attempt is not for a payment.
    /// </summary>
    NonPaymentAuthentication,
}

sealed class MessageCategoryCategoryConverter : JsonConverter<MessageCategoryCategory>
{
    public override MessageCategoryCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment_authentication" => MessageCategoryCategory.PaymentAuthentication,
            "non_payment_authentication" => MessageCategoryCategory.NonPaymentAuthentication,
            _ => (MessageCategoryCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageCategoryCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MessageCategoryCategory.PaymentAuthentication => "payment_authentication",
                MessageCategoryCategory.NonPaymentAuthentication => "non_payment_authentication",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to non-payment authentication attempts.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NonPayment, NonPaymentFromRaw>))]
public sealed record class NonPayment : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public NonPayment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NonPayment(NonPayment nonPayment)
        : base(nonPayment) { }
#pragma warning restore CS8618

    public NonPayment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NonPayment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NonPaymentFromRaw.FromRawUnchecked"/>
    public static NonPayment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NonPaymentFromRaw : IFromRawJson<NonPayment>
{
    /// <inheritdoc/>
    public NonPayment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NonPayment.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields specific to payment authentication attempts.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Payment, PaymentFromRaw>))]
public sealed record class Payment : JsonModel
{
    /// <summary>
    /// The purchase amount in minor units.
    /// </summary>
    public required long PurchaseAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("purchase_amount");
        }
        init { this._rawData.Set("purchase_amount", value); }
    }

    /// <summary>
    /// The purchase amount in the cardholder's currency (i.e., USD) estimated using
    /// daily conversion rates from the card network.
    /// </summary>
    public required long? PurchaseAmountCardholderEstimated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("purchase_amount_cardholder_estimated");
        }
        init { this._rawData.Set("purchase_amount_cardholder_estimated", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the authentication
    /// attempt's purchase currency.
    /// </summary>
    public required string PurchaseCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("purchase_currency");
        }
        init { this._rawData.Set("purchase_currency", value); }
    }

    /// <summary>
    /// The type of transaction being authenticated.
    /// </summary>
    public required ApiEnum<string, TransactionType>? TransactionType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TransactionType>>(
                "transaction_type"
            );
        }
        init { this._rawData.Set("transaction_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PurchaseAmount;
        _ = this.PurchaseAmountCardholderEstimated;
        _ = this.PurchaseCurrency;
        this.TransactionType?.Validate();
    }

    public Payment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Payment(Payment payment)
        : base(payment) { }
#pragma warning restore CS8618

    public Payment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Payment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentFromRaw.FromRawUnchecked"/>
    public static Payment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentFromRaw : IFromRawJson<Payment>
{
    /// <inheritdoc/>
    public Payment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Payment.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of transaction being authenticated.
/// </summary>
[JsonConverter(typeof(TransactionTypeConverter))]
public enum TransactionType
{
    /// <summary>
    /// Purchase of goods or services.
    /// </summary>
    GoodsServicePurchase,

    /// <summary>
    /// Check acceptance.
    /// </summary>
    CheckAcceptance,

    /// <summary>
    /// Account funding.
    /// </summary>
    AccountFunding,

    /// <summary>
    /// Quasi-cash transaction.
    /// </summary>
    QuasiCashTransaction,

    /// <summary>
    /// Prepaid activation and load.
    /// </summary>
    PrepaidActivationAndLoad,
}

sealed class TransactionTypeConverter : JsonConverter<TransactionType>
{
    public override TransactionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "goods_service_purchase" => TransactionType.GoodsServicePurchase,
            "check_acceptance" => TransactionType.CheckAcceptance,
            "account_funding" => TransactionType.AccountFunding,
            "quasi_cash_transaction" => TransactionType.QuasiCashTransaction,
            "prepaid_activation_and_load" => TransactionType.PrepaidActivationAndLoad,
            _ => (TransactionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransactionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransactionType.GoodsServicePurchase => "goods_service_purchase",
                TransactionType.CheckAcceptance => "check_acceptance",
                TransactionType.AccountFunding => "account_funding",
                TransactionType.QuasiCashTransaction => "quasi_cash_transaction",
                TransactionType.PrepaidActivationAndLoad => "prepaid_activation_and_load",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The 3DS requestor authentication indicator describes why the authentication attempt
/// is performed, such as for a recurring transaction.
/// </summary>
[JsonConverter(typeof(RequestorAuthenticationIndicatorConverter))]
public enum RequestorAuthenticationIndicator
{
    /// <summary>
    /// The authentication is for a payment transaction.
    /// </summary>
    PaymentTransaction,

    /// <summary>
    /// The authentication is for a recurring transaction.
    /// </summary>
    RecurringTransaction,

    /// <summary>
    /// The authentication is for an installment transaction.
    /// </summary>
    InstallmentTransaction,

    /// <summary>
    /// The authentication is for adding a card.
    /// </summary>
    AddCard,

    /// <summary>
    /// The authentication is for maintaining a card.
    /// </summary>
    MaintainCard,

    /// <summary>
    /// The authentication is for EMV token cardholder verification.
    /// </summary>
    EmvTokenCardholderVerification,

    /// <summary>
    /// The authentication is for a billing agreement.
    /// </summary>
    BillingAgreement,
}

sealed class RequestorAuthenticationIndicatorConverter
    : JsonConverter<RequestorAuthenticationIndicator>
{
    public override RequestorAuthenticationIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment_transaction" => RequestorAuthenticationIndicator.PaymentTransaction,
            "recurring_transaction" => RequestorAuthenticationIndicator.RecurringTransaction,
            "installment_transaction" => RequestorAuthenticationIndicator.InstallmentTransaction,
            "add_card" => RequestorAuthenticationIndicator.AddCard,
            "maintain_card" => RequestorAuthenticationIndicator.MaintainCard,
            "emv_token_cardholder_verification" =>
                RequestorAuthenticationIndicator.EmvTokenCardholderVerification,
            "billing_agreement" => RequestorAuthenticationIndicator.BillingAgreement,
            _ => (RequestorAuthenticationIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RequestorAuthenticationIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RequestorAuthenticationIndicator.PaymentTransaction => "payment_transaction",
                RequestorAuthenticationIndicator.RecurringTransaction => "recurring_transaction",
                RequestorAuthenticationIndicator.InstallmentTransaction =>
                    "installment_transaction",
                RequestorAuthenticationIndicator.AddCard => "add_card",
                RequestorAuthenticationIndicator.MaintainCard => "maintain_card",
                RequestorAuthenticationIndicator.EmvTokenCardholderVerification =>
                    "emv_token_cardholder_verification",
                RequestorAuthenticationIndicator.BillingAgreement => "billing_agreement",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Indicates whether a challenge is requested for this transaction.
/// </summary>
[JsonConverter(typeof(RequestorChallengeIndicatorConverter))]
public enum RequestorChallengeIndicator
{
    /// <summary>
    /// No preference.
    /// </summary>
    NoPreference,

    /// <summary>
    /// No challenge requested.
    /// </summary>
    NoChallengeRequested,

    /// <summary>
    /// Challenge requested, 3DS Requestor preference.
    /// </summary>
    ChallengeRequested3dsRequestorPreference,

    /// <summary>
    /// Challenge requested, mandate.
    /// </summary>
    ChallengeRequestedMandate,

    /// <summary>
    /// No challenge requested, transactional risk analysis already performed.
    /// </summary>
    NoChallengeRequestedTransactionalRiskAnalysisAlreadyPerformed,

    /// <summary>
    /// No challenge requested, data share only.
    /// </summary>
    NoChallengeRequestedDataShareOnly,

    /// <summary>
    /// No challenge requested, strong consumer authentication already performed.
    /// </summary>
    NoChallengeRequestedStrongConsumerAuthenticationAlreadyPerformed,

    /// <summary>
    /// No challenge requested, utilize whitelist exemption if no challenge required.
    /// </summary>
    NoChallengeRequestedUtilizeWhitelistExemptionIfNoChallengeRequired,

    /// <summary>
    /// Challenge requested, whitelist prompt requested if challenge required.
    /// </summary>
    ChallengeRequestedWhitelistPromptRequestedIfChallengeRequired,
}

sealed class RequestorChallengeIndicatorConverter : JsonConverter<RequestorChallengeIndicator>
{
    public override RequestorChallengeIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no_preference" => RequestorChallengeIndicator.NoPreference,
            "no_challenge_requested" => RequestorChallengeIndicator.NoChallengeRequested,
            "challenge_requested_3ds_requestor_preference" =>
                RequestorChallengeIndicator.ChallengeRequested3dsRequestorPreference,
            "challenge_requested_mandate" => RequestorChallengeIndicator.ChallengeRequestedMandate,
            "no_challenge_requested_transactional_risk_analysis_already_performed" =>
                RequestorChallengeIndicator.NoChallengeRequestedTransactionalRiskAnalysisAlreadyPerformed,
            "no_challenge_requested_data_share_only" =>
                RequestorChallengeIndicator.NoChallengeRequestedDataShareOnly,
            "no_challenge_requested_strong_consumer_authentication_already_performed" =>
                RequestorChallengeIndicator.NoChallengeRequestedStrongConsumerAuthenticationAlreadyPerformed,
            "no_challenge_requested_utilize_whitelist_exemption_if_no_challenge_required" =>
                RequestorChallengeIndicator.NoChallengeRequestedUtilizeWhitelistExemptionIfNoChallengeRequired,
            "challenge_requested_whitelist_prompt_requested_if_challenge_required" =>
                RequestorChallengeIndicator.ChallengeRequestedWhitelistPromptRequestedIfChallengeRequired,
            _ => (RequestorChallengeIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RequestorChallengeIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RequestorChallengeIndicator.NoPreference => "no_preference",
                RequestorChallengeIndicator.NoChallengeRequested => "no_challenge_requested",
                RequestorChallengeIndicator.ChallengeRequested3dsRequestorPreference =>
                    "challenge_requested_3ds_requestor_preference",
                RequestorChallengeIndicator.ChallengeRequestedMandate =>
                    "challenge_requested_mandate",
                RequestorChallengeIndicator.NoChallengeRequestedTransactionalRiskAnalysisAlreadyPerformed =>
                    "no_challenge_requested_transactional_risk_analysis_already_performed",
                RequestorChallengeIndicator.NoChallengeRequestedDataShareOnly =>
                    "no_challenge_requested_data_share_only",
                RequestorChallengeIndicator.NoChallengeRequestedStrongConsumerAuthenticationAlreadyPerformed =>
                    "no_challenge_requested_strong_consumer_authentication_already_performed",
                RequestorChallengeIndicator.NoChallengeRequestedUtilizeWhitelistExemptionIfNoChallengeRequired =>
                    "no_challenge_requested_utilize_whitelist_exemption_if_no_challenge_required",
                RequestorChallengeIndicator.ChallengeRequestedWhitelistPromptRequestedIfChallengeRequired =>
                    "challenge_requested_whitelist_prompt_requested_if_challenge_required",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields related to a 3DS authentication attempt.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardAuthenticationChallenge,
        RealTimeDecisionCardAuthenticationChallengeFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardAuthenticationChallenge : JsonModel
{
    /// <summary>
    /// The identifier of the Account the card belongs to.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// The identifier of the Card that is being tokenized.
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
    /// The identifier of the Card Payment this authentication challenge attempt
    /// belongs to.
    /// </summary>
    public required string CardPaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("card_payment_id");
        }
        init { this._rawData.Set("card_payment_id", value); }
    }

    /// <summary>
    /// The one-time code delivered to the cardholder.
    /// </summary>
    public required string OneTimeCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("one_time_code");
        }
        init { this._rawData.Set("one_time_code", value); }
    }

    /// <summary>
    /// Whether or not the challenge was delivered to the cardholder.
    /// </summary>
    public required ApiEnum<string, RealTimeDecisionCardAuthenticationChallengeResult>? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, RealTimeDecisionCardAuthenticationChallengeResult>
            >("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        _ = this.CardID;
        _ = this.CardPaymentID;
        _ = this.OneTimeCode;
        this.Result?.Validate();
    }

    public RealTimeDecisionCardAuthenticationChallenge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardAuthenticationChallenge(
        RealTimeDecisionCardAuthenticationChallenge realTimeDecisionCardAuthenticationChallenge
    )
        : base(realTimeDecisionCardAuthenticationChallenge) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardAuthenticationChallenge(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardAuthenticationChallenge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardAuthenticationChallengeFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardAuthenticationChallenge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardAuthenticationChallengeFromRaw
    : IFromRawJson<RealTimeDecisionCardAuthenticationChallenge>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardAuthenticationChallenge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardAuthenticationChallenge.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether or not the challenge was delivered to the cardholder.
/// </summary>
[JsonConverter(typeof(RealTimeDecisionCardAuthenticationChallengeResultConverter))]
public enum RealTimeDecisionCardAuthenticationChallengeResult
{
    /// <summary>
    /// Your application successfully delivered the one-time code to the cardholder.
    /// </summary>
    Success,

    /// <summary>
    /// Your application was unable to deliver the one-time code to the cardholder.
    /// </summary>
    Failure,
}

sealed class RealTimeDecisionCardAuthenticationChallengeResultConverter
    : JsonConverter<RealTimeDecisionCardAuthenticationChallengeResult>
{
    public override RealTimeDecisionCardAuthenticationChallengeResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => RealTimeDecisionCardAuthenticationChallengeResult.Success,
            "failure" => RealTimeDecisionCardAuthenticationChallengeResult.Failure,
            _ => (RealTimeDecisionCardAuthenticationChallengeResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionCardAuthenticationChallengeResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionCardAuthenticationChallengeResult.Success => "success",
                RealTimeDecisionCardAuthenticationChallengeResult.Failure => "failure",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields related to a card authorization.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardAuthorization,
        RealTimeDecisionCardAuthorizationFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardAuthorization : JsonModel
{
    /// <summary>
    /// The identifier of the Account the authorization will debit.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// Additional amounts associated with the card authorization, such as ATM surcharges
    /// fees. These are usually a subset of the `amount` field and are used to provide
    /// more detailed information about the transaction.
    /// </summary>
    public required AdditionalAmounts AdditionalAmounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AdditionalAmounts>("additional_amounts");
        }
        init { this._rawData.Set("additional_amounts", value); }
    }

    /// <summary>
    /// Present if and only if `decision` is `approve`. Contains information related
    /// to the approval of the authorization.
    /// </summary>
    public required RealTimeDecisionCardAuthorizationApproval? Approval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardAuthorizationApproval>(
                "approval"
            );
        }
        init { this._rawData.Set("approval", value); }
    }

    /// <summary>
    /// The identifier of the Card that is being authorized.
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
    /// Whether or not the authorization was approved.
    /// </summary>
    public required ApiEnum<string, RealTimeDecisionCardAuthorizationDecision>? Decision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, RealTimeDecisionCardAuthorizationDecision>
            >("decision");
        }
        init { this._rawData.Set("decision", value); }
    }

    /// <summary>
    /// Present if and only if `decision` is `decline`. Contains information related
    /// to the reason the authorization was declined.
    /// </summary>
    public required RealTimeDecisionCardAuthorizationDecline? Decline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardAuthorizationDecline>(
                "decline"
            );
        }
        init { this._rawData.Set("decline", value); }
    }

    /// <summary>
    /// If the authorization was made via a Digital Wallet Token (such as an Apple
    /// Pay purchase), the identifier of the token that was used.
    /// </summary>
    public required string? DigitalWalletTokenID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("digital_wallet_token_id");
        }
        init { this._rawData.Set("digital_wallet_token_id", value); }
    }

    /// <summary>
    /// The direction describes the direction the funds will move, either from the
    /// cardholder to the merchant or from the merchant to the cardholder.
    /// </summary>
    public required ApiEnum<string, Direction> Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Direction>>("direction");
        }
        init { this._rawData.Set("direction", value); }
    }

    /// <summary>
    /// The merchant identifier (commonly abbreviated as MID) of the merchant the
    /// card is transacting with.
    /// </summary>
    public required string MerchantAcceptorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_acceptor_id");
        }
        init { this._rawData.Set("merchant_acceptor_id", value); }
    }

    /// <summary>
    /// The Merchant Category Code (commonly abbreviated as MCC) of the merchant the
    /// card is transacting with.
    /// </summary>
    public required string MerchantCategoryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_category_code");
        }
        init { this._rawData.Set("merchant_category_code", value); }
    }

    /// <summary>
    /// The city the merchant resides in.
    /// </summary>
    public required string? MerchantCity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_city");
        }
        init { this._rawData.Set("merchant_city", value); }
    }

    /// <summary>
    /// The country the merchant resides in.
    /// </summary>
    public required string MerchantCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_country");
        }
        init { this._rawData.Set("merchant_country", value); }
    }

    /// <summary>
    /// The merchant descriptor of the merchant the card is transacting with.
    /// </summary>
    public required string MerchantDescriptor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_descriptor");
        }
        init { this._rawData.Set("merchant_descriptor", value); }
    }

    /// <summary>
    /// The merchant's postal code. For US merchants this is either a 5-digit or 9-digit
    /// ZIP code, where the first 5 and last 4 are separated by a dash.
    /// </summary>
    public required string? MerchantPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_postal_code");
        }
        init { this._rawData.Set("merchant_postal_code", value); }
    }

    /// <summary>
    /// The state the merchant resides in.
    /// </summary>
    public required string? MerchantState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_state");
        }
        init { this._rawData.Set("merchant_state", value); }
    }

    /// <summary>
    /// Fields specific to the `network`.
    /// </summary>
    public required NetworkDetails NetworkDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NetworkDetails>("network_details");
        }
        init { this._rawData.Set("network_details", value); }
    }

    /// <summary>
    /// Network-specific identifiers for a specific request or transaction.
    /// </summary>
    public required NetworkIdentifiers NetworkIdentifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NetworkIdentifiers>("network_identifiers");
        }
        init { this._rawData.Set("network_identifiers", value); }
    }

    /// <summary>
    /// The risk score generated by the card network. For Visa this is the Visa Advanced
    /// Authorization risk score, from 0 to 99, where 99 is the riskiest. For Pulse
    /// the score is from 0 to 999, where 999 is the riskiest.
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
    /// Whether or not the authorization supports partial approvals.
    /// </summary>
    public required ApiEnum<string, PartialApprovalCapability> PartialApprovalCapability
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PartialApprovalCapability>>(
                "partial_approval_capability"
            );
        }
        init { this._rawData.Set("partial_approval_capability", value); }
    }

    /// <summary>
    /// If the authorization was made in-person with a physical card, the Physical
    /// Card that was used.
    /// </summary>
    public required string? PhysicalCardID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("physical_card_id");
        }
        init { this._rawData.Set("physical_card_id", value); }
    }

    /// <summary>
    /// The amount of the attempted authorization in the currency the card user sees
    /// at the time of purchase, in the minor unit of that currency. For dollars,
    /// for example, this is cents.
    /// </summary>
    public required long PresentmentAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("presentment_amount");
        }
        init { this._rawData.Set("presentment_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the currency
    /// the user sees at the time of purchase.
    /// </summary>
    public required string PresentmentCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("presentment_currency");
        }
        init { this._rawData.Set("presentment_currency", value); }
    }

    /// <summary>
    /// The processing category describes the intent behind the authorization, such
    /// as whether it was used for bill payments or an automatic fuel dispenser.
    /// </summary>
    public required ApiEnum<string, ProcessingCategory> ProcessingCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ProcessingCategory>>(
                "processing_category"
            );
        }
        init { this._rawData.Set("processing_category", value); }
    }

    /// <summary>
    /// Fields specific to the type of request, such as an incremental authorization.
    /// </summary>
    public required RequestDetails RequestDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RequestDetails>("request_details");
        }
        init { this._rawData.Set("request_details", value); }
    }

    /// <summary>
    /// The amount of the attempted authorization in the currency it will be settled
    /// in. This currency is the same as that of the Account the card belongs to.
    /// </summary>
    public required long SettlementAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("settlement_amount");
        }
        init { this._rawData.Set("settlement_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the currency
    /// the transaction will be settled in.
    /// </summary>
    public required string SettlementCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("settlement_currency");
        }
        init { this._rawData.Set("settlement_currency", value); }
    }

    /// <summary>
    /// The terminal identifier (commonly abbreviated as TID) of the terminal the
    /// card is transacting with.
    /// </summary>
    public required string? TerminalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("terminal_id");
        }
        init { this._rawData.Set("terminal_id", value); }
    }

    /// <summary>
    /// The identifier of the Card Payment this authorization will belong to. Available
    /// in the API once the card authorization has completed.
    /// </summary>
    public required string UpcomingCardPaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("upcoming_card_payment_id");
        }
        init { this._rawData.Set("upcoming_card_payment_id", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        this.AdditionalAmounts.Validate();
        this.Approval?.Validate();
        _ = this.CardID;
        this.Decision?.Validate();
        this.Decline?.Validate();
        _ = this.DigitalWalletTokenID;
        this.Direction.Validate();
        _ = this.MerchantAcceptorID;
        _ = this.MerchantCategoryCode;
        _ = this.MerchantCity;
        _ = this.MerchantCountry;
        _ = this.MerchantDescriptor;
        _ = this.MerchantPostalCode;
        _ = this.MerchantState;
        this.NetworkDetails.Validate();
        this.NetworkIdentifiers.Validate();
        _ = this.NetworkRiskScore;
        this.PartialApprovalCapability.Validate();
        _ = this.PhysicalCardID;
        _ = this.PresentmentAmount;
        _ = this.PresentmentCurrency;
        this.ProcessingCategory.Validate();
        this.RequestDetails.Validate();
        _ = this.SettlementAmount;
        _ = this.SettlementCurrency;
        _ = this.TerminalID;
        _ = this.UpcomingCardPaymentID;
        this.Verification.Validate();
    }

    public RealTimeDecisionCardAuthorization() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardAuthorization(
        RealTimeDecisionCardAuthorization realTimeDecisionCardAuthorization
    )
        : base(realTimeDecisionCardAuthorization) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardAuthorization(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardAuthorization(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardAuthorizationFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardAuthorization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardAuthorizationFromRaw : IFromRawJson<RealTimeDecisionCardAuthorization>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardAuthorization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardAuthorization.FromRawUnchecked(rawData);
}

/// <summary>
/// Additional amounts associated with the card authorization, such as ATM surcharges
/// fees. These are usually a subset of the `amount` field and are used to provide
/// more detailed information about the transaction.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AdditionalAmounts, AdditionalAmountsFromRaw>))]
public sealed record class AdditionalAmounts : JsonModel
{
    /// <summary>
    /// The part of this transaction amount that was for clinic-related services.
    /// </summary>
    public required Clinic? Clinic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Clinic>("clinic");
        }
        init { this._rawData.Set("clinic", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for dental-related services.
    /// </summary>
    public required Dental? Dental
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Dental>("dental");
        }
        init { this._rawData.Set("dental", value); }
    }

    /// <summary>
    /// The original pre-authorized amount.
    /// </summary>
    public required Original? Original
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Original>("original");
        }
        init { this._rawData.Set("original", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for healthcare prescriptions.
    /// </summary>
    public required Prescription? Prescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Prescription>("prescription");
        }
        init { this._rawData.Set("prescription", value); }
    }

    /// <summary>
    /// The surcharge amount charged for this transaction by the merchant.
    /// </summary>
    public required Surcharge? Surcharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Surcharge>("surcharge");
        }
        init { this._rawData.Set("surcharge", value); }
    }

    /// <summary>
    /// The total amount of a series of incremental authorizations, optionally provided.
    /// </summary>
    public required TotalCumulative? TotalCumulative
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TotalCumulative>("total_cumulative");
        }
        init { this._rawData.Set("total_cumulative", value); }
    }

    /// <summary>
    /// The total amount of healthcare-related additional amounts.
    /// </summary>
    public required TotalHealthcare? TotalHealthcare
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TotalHealthcare>("total_healthcare");
        }
        init { this._rawData.Set("total_healthcare", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for transit-related services.
    /// </summary>
    public required Transit? Transit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Transit>("transit");
        }
        init { this._rawData.Set("transit", value); }
    }

    /// <summary>
    /// An unknown additional amount.
    /// </summary>
    public required Unknown? Unknown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Unknown>("unknown");
        }
        init { this._rawData.Set("unknown", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for vision-related services.
    /// </summary>
    public required Vision? Vision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Vision>("vision");
        }
        init { this._rawData.Set("vision", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Clinic?.Validate();
        this.Dental?.Validate();
        this.Original?.Validate();
        this.Prescription?.Validate();
        this.Surcharge?.Validate();
        this.TotalCumulative?.Validate();
        this.TotalHealthcare?.Validate();
        this.Transit?.Validate();
        this.Unknown?.Validate();
        this.Vision?.Validate();
    }

    public AdditionalAmounts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AdditionalAmounts(AdditionalAmounts additionalAmounts)
        : base(additionalAmounts) { }
#pragma warning restore CS8618

    public AdditionalAmounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AdditionalAmounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AdditionalAmountsFromRaw.FromRawUnchecked"/>
    public static AdditionalAmounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AdditionalAmountsFromRaw : IFromRawJson<AdditionalAmounts>
{
    /// <inheritdoc/>
    public AdditionalAmounts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AdditionalAmounts.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for clinic-related services.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Clinic, ClinicFromRaw>))]
public sealed record class Clinic : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Clinic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Clinic(Clinic clinic)
        : base(clinic) { }
#pragma warning restore CS8618

    public Clinic(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Clinic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClinicFromRaw.FromRawUnchecked"/>
    public static Clinic FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClinicFromRaw : IFromRawJson<Clinic>
{
    /// <inheritdoc/>
    public Clinic FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Clinic.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for dental-related services.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Dental, DentalFromRaw>))]
public sealed record class Dental : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Dental() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Dental(Dental dental)
        : base(dental) { }
#pragma warning restore CS8618

    public Dental(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Dental(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DentalFromRaw.FromRawUnchecked"/>
    public static Dental FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DentalFromRaw : IFromRawJson<Dental>
{
    /// <inheritdoc/>
    public Dental FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Dental.FromRawUnchecked(rawData);
}

/// <summary>
/// The original pre-authorized amount.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Original, OriginalFromRaw>))]
public sealed record class Original : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Original() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Original(Original original)
        : base(original) { }
#pragma warning restore CS8618

    public Original(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Original(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginalFromRaw.FromRawUnchecked"/>
    public static Original FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginalFromRaw : IFromRawJson<Original>
{
    /// <inheritdoc/>
    public Original FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Original.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for healthcare prescriptions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Prescription, PrescriptionFromRaw>))]
public sealed record class Prescription : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Prescription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Prescription(Prescription prescription)
        : base(prescription) { }
#pragma warning restore CS8618

    public Prescription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Prescription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PrescriptionFromRaw.FromRawUnchecked"/>
    public static Prescription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PrescriptionFromRaw : IFromRawJson<Prescription>
{
    /// <inheritdoc/>
    public Prescription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Prescription.FromRawUnchecked(rawData);
}

/// <summary>
/// The surcharge amount charged for this transaction by the merchant.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Surcharge, SurchargeFromRaw>))]
public sealed record class Surcharge : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Surcharge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Surcharge(Surcharge surcharge)
        : base(surcharge) { }
#pragma warning restore CS8618

    public Surcharge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Surcharge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SurchargeFromRaw.FromRawUnchecked"/>
    public static Surcharge FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SurchargeFromRaw : IFromRawJson<Surcharge>
{
    /// <inheritdoc/>
    public Surcharge FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Surcharge.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of a series of incremental authorizations, optionally provided.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TotalCumulative, TotalCumulativeFromRaw>))]
public sealed record class TotalCumulative : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public TotalCumulative() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TotalCumulative(TotalCumulative totalCumulative)
        : base(totalCumulative) { }
#pragma warning restore CS8618

    public TotalCumulative(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TotalCumulative(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TotalCumulativeFromRaw.FromRawUnchecked"/>
    public static TotalCumulative FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TotalCumulativeFromRaw : IFromRawJson<TotalCumulative>
{
    /// <inheritdoc/>
    public TotalCumulative FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TotalCumulative.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of healthcare-related additional amounts.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TotalHealthcare, TotalHealthcareFromRaw>))]
public sealed record class TotalHealthcare : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public TotalHealthcare() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TotalHealthcare(TotalHealthcare totalHealthcare)
        : base(totalHealthcare) { }
#pragma warning restore CS8618

    public TotalHealthcare(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TotalHealthcare(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TotalHealthcareFromRaw.FromRawUnchecked"/>
    public static TotalHealthcare FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TotalHealthcareFromRaw : IFromRawJson<TotalHealthcare>
{
    /// <inheritdoc/>
    public TotalHealthcare FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TotalHealthcare.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for transit-related services.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Transit, TransitFromRaw>))]
public sealed record class Transit : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Transit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Transit(Transit transit)
        : base(transit) { }
#pragma warning restore CS8618

    public Transit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Transit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransitFromRaw.FromRawUnchecked"/>
    public static Transit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransitFromRaw : IFromRawJson<Transit>
{
    /// <inheritdoc/>
    public Transit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Transit.FromRawUnchecked(rawData);
}

/// <summary>
/// An unknown additional amount.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Unknown, UnknownFromRaw>))]
public sealed record class Unknown : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Unknown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Unknown(Unknown unknown)
        : base(unknown) { }
#pragma warning restore CS8618

    public Unknown(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Unknown(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnknownFromRaw.FromRawUnchecked"/>
    public static Unknown FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnknownFromRaw : IFromRawJson<Unknown>
{
    /// <inheritdoc/>
    public Unknown FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Unknown.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for vision-related services.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Vision, VisionFromRaw>))]
public sealed record class Vision : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Vision() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Vision(Vision vision)
        : base(vision) { }
#pragma warning restore CS8618

    public Vision(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Vision(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VisionFromRaw.FromRawUnchecked"/>
    public static Vision FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VisionFromRaw : IFromRawJson<Vision>
{
    /// <inheritdoc/>
    public Vision FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Vision.FromRawUnchecked(rawData);
}

/// <summary>
/// Present if and only if `decision` is `approve`. Contains information related to
/// the approval of the authorization.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardAuthorizationApproval,
        RealTimeDecisionCardAuthorizationApprovalFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardAuthorizationApproval : JsonModel
{
    /// <summary>
    /// If the authorization was partially approved, this field contains the approved
    /// amount in the minor unit of the settlement currency.
    /// </summary>
    public required long? PartialAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("partial_amount");
        }
        init { this._rawData.Set("partial_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PartialAmount;
    }

    public RealTimeDecisionCardAuthorizationApproval() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardAuthorizationApproval(
        RealTimeDecisionCardAuthorizationApproval realTimeDecisionCardAuthorizationApproval
    )
        : base(realTimeDecisionCardAuthorizationApproval) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardAuthorizationApproval(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardAuthorizationApproval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardAuthorizationApprovalFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardAuthorizationApproval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RealTimeDecisionCardAuthorizationApproval(long? partialAmount)
        : this()
    {
        this.PartialAmount = partialAmount;
    }
}

class RealTimeDecisionCardAuthorizationApprovalFromRaw
    : IFromRawJson<RealTimeDecisionCardAuthorizationApproval>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardAuthorizationApproval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardAuthorizationApproval.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether or not the authorization was approved.
/// </summary>
[JsonConverter(typeof(RealTimeDecisionCardAuthorizationDecisionConverter))]
public enum RealTimeDecisionCardAuthorizationDecision
{
    /// <summary>
    /// Approve the authorization.
    /// </summary>
    Approve,

    /// <summary>
    /// Decline the authorization.
    /// </summary>
    Decline,
}

sealed class RealTimeDecisionCardAuthorizationDecisionConverter
    : JsonConverter<RealTimeDecisionCardAuthorizationDecision>
{
    public override RealTimeDecisionCardAuthorizationDecision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approve" => RealTimeDecisionCardAuthorizationDecision.Approve,
            "decline" => RealTimeDecisionCardAuthorizationDecision.Decline,
            _ => (RealTimeDecisionCardAuthorizationDecision)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionCardAuthorizationDecision value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionCardAuthorizationDecision.Approve => "approve",
                RealTimeDecisionCardAuthorizationDecision.Decline => "decline",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Present if and only if `decision` is `decline`. Contains information related to
/// the reason the authorization was declined.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardAuthorizationDecline,
        RealTimeDecisionCardAuthorizationDeclineFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardAuthorizationDecline : JsonModel
{
    /// <summary>
    /// The reason the authorization was declined.
    /// </summary>
    public required ApiEnum<string, RealTimeDecisionCardAuthorizationDeclineReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, RealTimeDecisionCardAuthorizationDeclineReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Reason.Validate();
    }

    public RealTimeDecisionCardAuthorizationDecline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardAuthorizationDecline(
        RealTimeDecisionCardAuthorizationDecline realTimeDecisionCardAuthorizationDecline
    )
        : base(realTimeDecisionCardAuthorizationDecline) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardAuthorizationDecline(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardAuthorizationDecline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardAuthorizationDeclineFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardAuthorizationDecline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RealTimeDecisionCardAuthorizationDecline(
        ApiEnum<string, RealTimeDecisionCardAuthorizationDeclineReason> reason
    )
        : this()
    {
        this.Reason = reason;
    }
}

class RealTimeDecisionCardAuthorizationDeclineFromRaw
    : IFromRawJson<RealTimeDecisionCardAuthorizationDecline>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardAuthorizationDecline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardAuthorizationDecline.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason the authorization was declined.
/// </summary>
[JsonConverter(typeof(RealTimeDecisionCardAuthorizationDeclineReasonConverter))]
public enum RealTimeDecisionCardAuthorizationDeclineReason
{
    /// <summary>
    /// The cardholder does not have sufficient funds to cover the transaction. The
    /// merchant may attempt to process the transaction again.
    /// </summary>
    InsufficientFunds,

    /// <summary>
    /// This type of transaction is not allowed for this card. This transaction should
    /// not be retried.
    /// </summary>
    TransactionNeverAllowed,

    /// <summary>
    /// The transaction amount exceeds the cardholder's approval limit. The merchant
    /// may attempt to process the transaction again.
    /// </summary>
    ExceedsApprovalLimit,

    /// <summary>
    /// The card has been temporarily disabled or not yet activated. The merchant
    /// may attempt to process the transaction again.
    /// </summary>
    CardTemporarilyDisabled,

    /// <summary>
    /// The transaction is suspected to be fraudulent. The merchant may attempt to
    /// process the transaction again.
    /// </summary>
    SuspectedFraud,

    /// <summary>
    /// The transaction was declined for another reason. The merchant may attempt
    /// to process the transaction again. This should be used sparingly.
    /// </summary>
    Other,
}

sealed class RealTimeDecisionCardAuthorizationDeclineReasonConverter
    : JsonConverter<RealTimeDecisionCardAuthorizationDeclineReason>
{
    public override RealTimeDecisionCardAuthorizationDeclineReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" =>
                RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds,
            "transaction_never_allowed" =>
                RealTimeDecisionCardAuthorizationDeclineReason.TransactionNeverAllowed,
            "exceeds_approval_limit" =>
                RealTimeDecisionCardAuthorizationDeclineReason.ExceedsApprovalLimit,
            "card_temporarily_disabled" =>
                RealTimeDecisionCardAuthorizationDeclineReason.CardTemporarilyDisabled,
            "suspected_fraud" => RealTimeDecisionCardAuthorizationDeclineReason.SuspectedFraud,
            "other" => RealTimeDecisionCardAuthorizationDeclineReason.Other,
            _ => (RealTimeDecisionCardAuthorizationDeclineReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionCardAuthorizationDeclineReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds =>
                    "insufficient_funds",
                RealTimeDecisionCardAuthorizationDeclineReason.TransactionNeverAllowed =>
                    "transaction_never_allowed",
                RealTimeDecisionCardAuthorizationDeclineReason.ExceedsApprovalLimit =>
                    "exceeds_approval_limit",
                RealTimeDecisionCardAuthorizationDeclineReason.CardTemporarilyDisabled =>
                    "card_temporarily_disabled",
                RealTimeDecisionCardAuthorizationDeclineReason.SuspectedFraud => "suspected_fraud",
                RealTimeDecisionCardAuthorizationDeclineReason.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The direction describes the direction the funds will move, either from the cardholder
/// to the merchant or from the merchant to the cardholder.
/// </summary>
[JsonConverter(typeof(DirectionConverter))]
public enum Direction
{
    /// <summary>
    /// A regular card authorization where funds are debited from the cardholder.
    /// </summary>
    Settlement,

    /// <summary>
    /// A refund card authorization, sometimes referred to as a credit voucher authorization,
    /// where funds are credited to the cardholder.
    /// </summary>
    Refund,
}

sealed class DirectionConverter : JsonConverter<Direction>
{
    public override Direction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "settlement" => Direction.Settlement,
            "refund" => Direction.Refund,
            _ => (Direction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Direction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Direction.Settlement => "settlement",
                Direction.Refund => "refund",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to the `network`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NetworkDetails, NetworkDetailsFromRaw>))]
public sealed record class NetworkDetails : JsonModel
{
    /// <summary>
    /// The payment network used to process this card authorization.
    /// </summary>
    public required ApiEnum<string, NetworkDetailsCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NetworkDetailsCategory>>(
                "category"
            );
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Fields specific to the `pulse` network.
    /// </summary>
    public required Pulse? Pulse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Pulse>("pulse");
        }
        init { this._rawData.Set("pulse", value); }
    }

    /// <summary>
    /// Fields specific to the `visa` network.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.Pulse?.Validate();
        this.Visa?.Validate();
    }

    public NetworkDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkDetails(NetworkDetails networkDetails)
        : base(networkDetails) { }
#pragma warning restore CS8618

    public NetworkDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NetworkDetailsFromRaw.FromRawUnchecked"/>
    public static NetworkDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NetworkDetailsFromRaw : IFromRawJson<NetworkDetails>
{
    /// <inheritdoc/>
    public NetworkDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NetworkDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// The payment network used to process this card authorization.
/// </summary>
[JsonConverter(typeof(NetworkDetailsCategoryConverter))]
public enum NetworkDetailsCategory
{
    /// <summary>
    /// Visa
    /// </summary>
    Visa,

    /// <summary>
    /// Pulse
    /// </summary>
    Pulse,
}

sealed class NetworkDetailsCategoryConverter : JsonConverter<NetworkDetailsCategory>
{
    public override NetworkDetailsCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => NetworkDetailsCategory.Visa,
            "pulse" => NetworkDetailsCategory.Pulse,
            _ => (NetworkDetailsCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NetworkDetailsCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NetworkDetailsCategory.Visa => "visa",
                NetworkDetailsCategory.Pulse => "pulse",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to the `pulse` network.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pulse, PulseFromRaw>))]
public sealed record class Pulse : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public Pulse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pulse(Pulse pulse)
        : base(pulse) { }
#pragma warning restore CS8618

    public Pulse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pulse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PulseFromRaw.FromRawUnchecked"/>
    public static Pulse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PulseFromRaw : IFromRawJson<Pulse>
{
    /// <inheritdoc/>
    public Pulse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pulse.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields specific to the `visa` network.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Visa, VisaFromRaw>))]
public sealed record class Visa : JsonModel
{
    /// <summary>
    /// For electronic commerce transactions, this identifies the level of security
    /// used in obtaining the customer's payment credential. For mail or telephone
    /// order transactions, identifies the type of mail or telephone order.
    /// </summary>
    public required ApiEnum<string, ElectronicCommerceIndicator>? ElectronicCommerceIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ElectronicCommerceIndicator>>(
                "electronic_commerce_indicator"
            );
        }
        init { this._rawData.Set("electronic_commerce_indicator", value); }
    }

    /// <summary>
    /// The method used to enter the cardholder's primary account number and card
    /// expiration date.
    /// </summary>
    public required ApiEnum<string, PointOfServiceEntryMode>? PointOfServiceEntryMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PointOfServiceEntryMode>>(
                "point_of_service_entry_mode"
            );
        }
        init { this._rawData.Set("point_of_service_entry_mode", value); }
    }

    /// <summary>
    /// Only present when `actioner: network`. Describes why a card authorization
    /// was approved or declined by Visa through stand-in processing.
    /// </summary>
    public required ApiEnum<string, StandInProcessingReason>? StandInProcessingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, StandInProcessingReason>>(
                "stand_in_processing_reason"
            );
        }
        init { this._rawData.Set("stand_in_processing_reason", value); }
    }

    /// <summary>
    /// The capability of the terminal being used to read the card. Shows whether
    /// a terminal can e.g., accept chip cards or if it only supports magnetic stripe
    /// reads. This reflects the highest capability of the terminal — for example,
    /// a terminal that supports both chip and magnetic stripe will be identified
    /// as chip-capable.
    /// </summary>
    public required ApiEnum<string, TerminalEntryCapability>? TerminalEntryCapability
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TerminalEntryCapability>>(
                "terminal_entry_capability"
            );
        }
        init { this._rawData.Set("terminal_entry_capability", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ElectronicCommerceIndicator?.Validate();
        this.PointOfServiceEntryMode?.Validate();
        this.StandInProcessingReason?.Validate();
        this.TerminalEntryCapability?.Validate();
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
/// For electronic commerce transactions, this identifies the level of security used
/// in obtaining the customer's payment credential. For mail or telephone order transactions,
/// identifies the type of mail or telephone order.
/// </summary>
[JsonConverter(typeof(ElectronicCommerceIndicatorConverter))]
public enum ElectronicCommerceIndicator
{
    /// <summary>
    /// Single transaction of a mail/phone order: Use to indicate that the transaction
    /// is a mail/phone order purchase, not a recurring transaction or installment
    /// payment. For domestic transactions in the US region, this value may also indicate
    /// one bill payment transaction in the card-present or card-absent environments.
    /// </summary>
    MailPhoneOrder,

    /// <summary>
    /// Recurring transaction: Payment indicator used to indicate a recurring transaction
    /// that originates from an acquirer in the US region.
    /// </summary>
    Recurring,

    /// <summary>
    /// Installment payment: Payment indicator used to indicate one purchase of goods
    /// or services that is billed to the account in multiple charges over a period
    /// of time agreed upon by the cardholder and merchant from transactions that
    /// originate from an acquirer in the US region.
    /// </summary>
    Installment,

    /// <summary>
    /// Unknown classification: other mail order: Use to indicate that the type of
    /// mail/telephone order is unknown.
    /// </summary>
    UnknownMailPhoneOrder,

    /// <summary>
    /// Secure electronic commerce transaction: Use to indicate that the electronic
    /// commerce transaction has been authenticated using e.g., 3-D Secure
    /// </summary>
    SecureElectronicCommerce,

    /// <summary>
    /// Non-authenticated security transaction at a 3-D Secure-capable merchant,
    /// and merchant attempted to authenticate the cardholder using 3-D Secure: Use
    /// to identify an electronic commerce transaction where the merchant attempted
    /// to authenticate the cardholder using 3-D Secure, but was unable to complete
    /// the authentication because the issuer or cardholder does not participate in
    /// the 3-D Secure program.
    /// </summary>
    NonAuthenticatedSecurityTransactionAt3dsCapableMerchant,

    /// <summary>
    /// Non-authenticated security transaction: Use to identify an electronic commerce
    /// transaction that uses data encryption for security however, cardholder authentication
    /// is not performed using 3-D Secure.
    /// </summary>
    NonAuthenticatedSecurityTransaction,

    /// <summary>
    /// Non-secure transaction: Use to identify an electronic commerce transaction
    /// that has no data protection.
    /// </summary>
    NonSecureTransaction,
}

sealed class ElectronicCommerceIndicatorConverter : JsonConverter<ElectronicCommerceIndicator>
{
    public override ElectronicCommerceIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mail_phone_order" => ElectronicCommerceIndicator.MailPhoneOrder,
            "recurring" => ElectronicCommerceIndicator.Recurring,
            "installment" => ElectronicCommerceIndicator.Installment,
            "unknown_mail_phone_order" => ElectronicCommerceIndicator.UnknownMailPhoneOrder,
            "secure_electronic_commerce" => ElectronicCommerceIndicator.SecureElectronicCommerce,
            "non_authenticated_security_transaction_at_3ds_capable_merchant" =>
                ElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant,
            "non_authenticated_security_transaction" =>
                ElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction,
            "non_secure_transaction" => ElectronicCommerceIndicator.NonSecureTransaction,
            _ => (ElectronicCommerceIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ElectronicCommerceIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ElectronicCommerceIndicator.MailPhoneOrder => "mail_phone_order",
                ElectronicCommerceIndicator.Recurring => "recurring",
                ElectronicCommerceIndicator.Installment => "installment",
                ElectronicCommerceIndicator.UnknownMailPhoneOrder => "unknown_mail_phone_order",
                ElectronicCommerceIndicator.SecureElectronicCommerce =>
                    "secure_electronic_commerce",
                ElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant =>
                    "non_authenticated_security_transaction_at_3ds_capable_merchant",
                ElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction =>
                    "non_authenticated_security_transaction",
                ElectronicCommerceIndicator.NonSecureTransaction => "non_secure_transaction",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The method used to enter the cardholder's primary account number and card expiration date.
/// </summary>
[JsonConverter(typeof(PointOfServiceEntryModeConverter))]
public enum PointOfServiceEntryMode
{
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown,

    /// <summary>
    /// Manual key entry
    /// </summary>
    Manual,

    /// <summary>
    /// Magnetic stripe read, without card verification value
    /// </summary>
    MagneticStripeNoCvv,

    /// <summary>
    /// Optical code
    /// </summary>
    OpticalCode,

    /// <summary>
    /// Contact chip card
    /// </summary>
    IntegratedCircuitCard,

    /// <summary>
    /// Contactless read of chip card
    /// </summary>
    Contactless,

    /// <summary>
    /// Transaction initiated using a credential that has previously been stored
    /// on file
    /// </summary>
    CredentialOnFile,

    /// <summary>
    /// Magnetic stripe read
    /// </summary>
    MagneticStripe,

    /// <summary>
    /// Contactless read of magnetic stripe data
    /// </summary>
    ContactlessMagneticStripe,

    /// <summary>
    /// Contact chip card, without card verification value
    /// </summary>
    IntegratedCircuitCardNoCvv,
}

sealed class PointOfServiceEntryModeConverter : JsonConverter<PointOfServiceEntryMode>
{
    public override PointOfServiceEntryMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" => PointOfServiceEntryMode.Unknown,
            "manual" => PointOfServiceEntryMode.Manual,
            "magnetic_stripe_no_cvv" => PointOfServiceEntryMode.MagneticStripeNoCvv,
            "optical_code" => PointOfServiceEntryMode.OpticalCode,
            "integrated_circuit_card" => PointOfServiceEntryMode.IntegratedCircuitCard,
            "contactless" => PointOfServiceEntryMode.Contactless,
            "credential_on_file" => PointOfServiceEntryMode.CredentialOnFile,
            "magnetic_stripe" => PointOfServiceEntryMode.MagneticStripe,
            "contactless_magnetic_stripe" => PointOfServiceEntryMode.ContactlessMagneticStripe,
            "integrated_circuit_card_no_cvv" => PointOfServiceEntryMode.IntegratedCircuitCardNoCvv,
            _ => (PointOfServiceEntryMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PointOfServiceEntryMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PointOfServiceEntryMode.Unknown => "unknown",
                PointOfServiceEntryMode.Manual => "manual",
                PointOfServiceEntryMode.MagneticStripeNoCvv => "magnetic_stripe_no_cvv",
                PointOfServiceEntryMode.OpticalCode => "optical_code",
                PointOfServiceEntryMode.IntegratedCircuitCard => "integrated_circuit_card",
                PointOfServiceEntryMode.Contactless => "contactless",
                PointOfServiceEntryMode.CredentialOnFile => "credential_on_file",
                PointOfServiceEntryMode.MagneticStripe => "magnetic_stripe",
                PointOfServiceEntryMode.ContactlessMagneticStripe => "contactless_magnetic_stripe",
                PointOfServiceEntryMode.IntegratedCircuitCardNoCvv =>
                    "integrated_circuit_card_no_cvv",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Only present when `actioner: network`. Describes why a card authorization was
/// approved or declined by Visa through stand-in processing.
/// </summary>
[JsonConverter(typeof(StandInProcessingReasonConverter))]
public enum StandInProcessingReason
{
    /// <summary>
    /// Increase failed to process the authorization in a timely manner.
    /// </summary>
    IssuerError,

    /// <summary>
    /// The physical card read had an invalid CVV or dCVV.
    /// </summary>
    InvalidPhysicalCard,

    /// <summary>
    /// The card's authorization request cryptogram was invalid. The cryptogram can
    /// be from a physical card or a Digital Wallet Token purchase.
    /// </summary>
    InvalidCryptogram,

    /// <summary>
    /// The 3DS cardholder authentication verification value was invalid.
    /// </summary>
    InvalidCardholderAuthenticationVerificationValue,

    /// <summary>
    /// An internal Visa error occurred. Visa uses this reason code for certain expected
    /// occurrences as well, such as Application Transaction Counter (ATC) replays.
    /// </summary>
    InternalVisaError,

    /// <summary>
    /// The merchant has enabled Visa's Transaction Advisory Service and requires
    /// further authentication to perform the transaction. In practice this is often
    /// utilized at fuel pumps to tell the cardholder to see the cashier.
    /// </summary>
    MerchantTransactionAdvisoryServiceAuthenticationRequired,

    /// <summary>
    /// The transaction was blocked by Visa's Payment Fraud Disruption service due
    /// to fraudulent Acquirer behavior, such as card testing.
    /// </summary>
    PaymentFraudDisruptionAcquirerBlock,

    /// <summary>
    /// An unspecific reason for stand-in processing.
    /// </summary>
    Other,
}

sealed class StandInProcessingReasonConverter : JsonConverter<StandInProcessingReason>
{
    public override StandInProcessingReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "issuer_error" => StandInProcessingReason.IssuerError,
            "invalid_physical_card" => StandInProcessingReason.InvalidPhysicalCard,
            "invalid_cryptogram" => StandInProcessingReason.InvalidCryptogram,
            "invalid_cardholder_authentication_verification_value" =>
                StandInProcessingReason.InvalidCardholderAuthenticationVerificationValue,
            "internal_visa_error" => StandInProcessingReason.InternalVisaError,
            "merchant_transaction_advisory_service_authentication_required" =>
                StandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired,
            "payment_fraud_disruption_acquirer_block" =>
                StandInProcessingReason.PaymentFraudDisruptionAcquirerBlock,
            "other" => StandInProcessingReason.Other,
            _ => (StandInProcessingReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StandInProcessingReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StandInProcessingReason.IssuerError => "issuer_error",
                StandInProcessingReason.InvalidPhysicalCard => "invalid_physical_card",
                StandInProcessingReason.InvalidCryptogram => "invalid_cryptogram",
                StandInProcessingReason.InvalidCardholderAuthenticationVerificationValue =>
                    "invalid_cardholder_authentication_verification_value",
                StandInProcessingReason.InternalVisaError => "internal_visa_error",
                StandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired =>
                    "merchant_transaction_advisory_service_authentication_required",
                StandInProcessingReason.PaymentFraudDisruptionAcquirerBlock =>
                    "payment_fraud_disruption_acquirer_block",
                StandInProcessingReason.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The capability of the terminal being used to read the card. Shows whether a terminal
/// can e.g., accept chip cards or if it only supports magnetic stripe reads. This
/// reflects the highest capability of the terminal — for example, a terminal that
/// supports both chip and magnetic stripe will be identified as chip-capable.
/// </summary>
[JsonConverter(typeof(TerminalEntryCapabilityConverter))]
public enum TerminalEntryCapability
{
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown,

    /// <summary>
    /// No terminal was used for this transaction.
    /// </summary>
    TerminalNotUsed,

    /// <summary>
    /// The terminal can only read magnetic stripes and does not have chip or contactless
    /// reading capability.
    /// </summary>
    MagneticStripe,

    /// <summary>
    /// The terminal can only read barcodes.
    /// </summary>
    Barcode,

    /// <summary>
    /// The terminal can only read cards via Optical Character Recognition.
    /// </summary>
    OpticalCharacterRecognition,

    /// <summary>
    /// The terminal supports contact chip cards and can also read the magnetic stripe.
    /// If contact chip is supported, this value is used regardless of whether contactless
    /// is also supported.
    /// </summary>
    ChipOrContactless,

    /// <summary>
    /// The terminal supports contactless reads but does not support contact chip.
    /// Only used when the terminal lacks contact chip capability.
    /// </summary>
    ContactlessOnly,

    /// <summary>
    /// The terminal has no card reading capability.
    /// </summary>
    NoCapability,
}

sealed class TerminalEntryCapabilityConverter : JsonConverter<TerminalEntryCapability>
{
    public override TerminalEntryCapability Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" => TerminalEntryCapability.Unknown,
            "terminal_not_used" => TerminalEntryCapability.TerminalNotUsed,
            "magnetic_stripe" => TerminalEntryCapability.MagneticStripe,
            "barcode" => TerminalEntryCapability.Barcode,
            "optical_character_recognition" => TerminalEntryCapability.OpticalCharacterRecognition,
            "chip_or_contactless" => TerminalEntryCapability.ChipOrContactless,
            "contactless_only" => TerminalEntryCapability.ContactlessOnly,
            "no_capability" => TerminalEntryCapability.NoCapability,
            _ => (TerminalEntryCapability)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TerminalEntryCapability value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TerminalEntryCapability.Unknown => "unknown",
                TerminalEntryCapability.TerminalNotUsed => "terminal_not_used",
                TerminalEntryCapability.MagneticStripe => "magnetic_stripe",
                TerminalEntryCapability.Barcode => "barcode",
                TerminalEntryCapability.OpticalCharacterRecognition =>
                    "optical_character_recognition",
                TerminalEntryCapability.ChipOrContactless => "chip_or_contactless",
                TerminalEntryCapability.ContactlessOnly => "contactless_only",
                TerminalEntryCapability.NoCapability => "no_capability",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Network-specific identifiers for a specific request or transaction.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NetworkIdentifiers, NetworkIdentifiersFromRaw>))]
public sealed record class NetworkIdentifiers : JsonModel
{
    /// <summary>
    /// The randomly generated 6-character Authorization Identification Response code
    /// sent back to the acquirer in an approved response.
    /// </summary>
    public required string? AuthorizationIdentificationResponse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("authorization_identification_response");
        }
        init { this._rawData.Set("authorization_identification_response", value); }
    }

    /// <summary>
    /// A life-cycle identifier used across e.g., an authorization and a reversal.
    /// Expected to be unique per acquirer within a window of time. For some card
    /// networks the retrieval reference number includes the trace counter.
    /// </summary>
    public required string? RetrievalReferenceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("retrieval_reference_number");
        }
        init { this._rawData.Set("retrieval_reference_number", value); }
    }

    /// <summary>
    /// A counter used to verify an individual authorization. Expected to be unique
    /// per acquirer within a window of time.
    /// </summary>
    public required string? TraceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("trace_number");
        }
        init { this._rawData.Set("trace_number", value); }
    }

    /// <summary>
    /// A globally unique transaction identifier provided by the card network, used
    /// across multiple life-cycle requests.
    /// </summary>
    public required string? TransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transaction_id");
        }
        init { this._rawData.Set("transaction_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AuthorizationIdentificationResponse;
        _ = this.RetrievalReferenceNumber;
        _ = this.TraceNumber;
        _ = this.TransactionID;
    }

    public NetworkIdentifiers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkIdentifiers(NetworkIdentifiers networkIdentifiers)
        : base(networkIdentifiers) { }
#pragma warning restore CS8618

    public NetworkIdentifiers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkIdentifiers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NetworkIdentifiersFromRaw.FromRawUnchecked"/>
    public static NetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NetworkIdentifiersFromRaw : IFromRawJson<NetworkIdentifiers>
{
    /// <inheritdoc/>
    public NetworkIdentifiers FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NetworkIdentifiers.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether or not the authorization supports partial approvals.
/// </summary>
[JsonConverter(typeof(PartialApprovalCapabilityConverter))]
public enum PartialApprovalCapability
{
    /// <summary>
    /// This transaction supports partial approvals.
    /// </summary>
    Supported,

    /// <summary>
    /// This transaction does not support partial approvals.
    /// </summary>
    NotSupported,
}

sealed class PartialApprovalCapabilityConverter : JsonConverter<PartialApprovalCapability>
{
    public override PartialApprovalCapability Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "supported" => PartialApprovalCapability.Supported,
            "not_supported" => PartialApprovalCapability.NotSupported,
            _ => (PartialApprovalCapability)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PartialApprovalCapability value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PartialApprovalCapability.Supported => "supported",
                PartialApprovalCapability.NotSupported => "not_supported",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The processing category describes the intent behind the authorization, such as
/// whether it was used for bill payments or an automatic fuel dispenser.
/// </summary>
[JsonConverter(typeof(ProcessingCategoryConverter))]
public enum ProcessingCategory
{
    /// <summary>
    /// Account funding transactions are transactions used to e.g., fund an account
    /// or transfer funds between accounts.
    /// </summary>
    AccountFunding,

    /// <summary>
    /// Automatic fuel dispenser authorizations occur when a card is used at a gas
    /// pump, prior to the actual transaction amount being known. They are followed
    /// by an advice message that updates the amount of the pending transaction.
    /// </summary>
    AutomaticFuelDispenser,

    /// <summary>
    /// A transaction used to pay a bill.
    /// </summary>
    BillPayment,

    /// <summary>
    /// Original credit transactions are used to send money to a cardholder.
    /// </summary>
    OriginalCredit,

    /// <summary>
    /// A regular purchase.
    /// </summary>
    Purchase,

    /// <summary>
    /// Quasi-cash transactions represent purchases of items which may be convertible
    /// to cash.
    /// </summary>
    QuasiCash,

    /// <summary>
    /// A refund card authorization, sometimes referred to as a credit voucher authorization,
    /// where funds are credited to the cardholder.
    /// </summary>
    Refund,

    /// <summary>
    /// Cash disbursement transactions are used to withdraw cash from an ATM or a
    /// point of sale.
    /// </summary>
    CashDisbursement,

    /// <summary>
    /// A balance inquiry transaction is used to check the balance of an account associated
    /// with a card.
    /// </summary>
    BalanceInquiry,

    /// <summary>
    /// The processing category is unknown.
    /// </summary>
    Unknown,
}

sealed class ProcessingCategoryConverter : JsonConverter<ProcessingCategory>
{
    public override ProcessingCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_funding" => ProcessingCategory.AccountFunding,
            "automatic_fuel_dispenser" => ProcessingCategory.AutomaticFuelDispenser,
            "bill_payment" => ProcessingCategory.BillPayment,
            "original_credit" => ProcessingCategory.OriginalCredit,
            "purchase" => ProcessingCategory.Purchase,
            "quasi_cash" => ProcessingCategory.QuasiCash,
            "refund" => ProcessingCategory.Refund,
            "cash_disbursement" => ProcessingCategory.CashDisbursement,
            "balance_inquiry" => ProcessingCategory.BalanceInquiry,
            "unknown" => ProcessingCategory.Unknown,
            _ => (ProcessingCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProcessingCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProcessingCategory.AccountFunding => "account_funding",
                ProcessingCategory.AutomaticFuelDispenser => "automatic_fuel_dispenser",
                ProcessingCategory.BillPayment => "bill_payment",
                ProcessingCategory.OriginalCredit => "original_credit",
                ProcessingCategory.Purchase => "purchase",
                ProcessingCategory.QuasiCash => "quasi_cash",
                ProcessingCategory.Refund => "refund",
                ProcessingCategory.CashDisbursement => "cash_disbursement",
                ProcessingCategory.BalanceInquiry => "balance_inquiry",
                ProcessingCategory.Unknown => "unknown",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to the type of request, such as an incremental authorization.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RequestDetails, RequestDetailsFromRaw>))]
public sealed record class RequestDetails : JsonModel
{
    /// <summary>
    /// The type of this request (e.g., an initial authorization or an incremental authorization).
    /// </summary>
    public required ApiEnum<string, RequestDetailsCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RequestDetailsCategory>>(
                "category"
            );
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Fields specific to the category `incremental_authorization`.
    /// </summary>
    public required IncrementalAuthorization? IncrementalAuthorization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IncrementalAuthorization>(
                "incremental_authorization"
            );
        }
        init { this._rawData.Set("incremental_authorization", value); }
    }

    /// <summary>
    /// Fields specific to the category `initial_authorization`.
    /// </summary>
    public required InitialAuthorization? InitialAuthorization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InitialAuthorization>("initial_authorization");
        }
        init { this._rawData.Set("initial_authorization", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.IncrementalAuthorization?.Validate();
        this.InitialAuthorization?.Validate();
    }

    public RequestDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequestDetails(RequestDetails requestDetails)
        : base(requestDetails) { }
#pragma warning restore CS8618

    public RequestDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RequestDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequestDetailsFromRaw.FromRawUnchecked"/>
    public static RequestDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RequestDetailsFromRaw : IFromRawJson<RequestDetails>
{
    /// <inheritdoc/>
    public RequestDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RequestDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of this request (e.g., an initial authorization or an incremental authorization).
/// </summary>
[JsonConverter(typeof(RequestDetailsCategoryConverter))]
public enum RequestDetailsCategory
{
    /// <summary>
    /// A regular, standalone authorization.
    /// </summary>
    InitialAuthorization,

    /// <summary>
    /// An incremental request to increase the amount of an existing authorization.
    /// </summary>
    IncrementalAuthorization,
}

sealed class RequestDetailsCategoryConverter : JsonConverter<RequestDetailsCategory>
{
    public override RequestDetailsCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "initial_authorization" => RequestDetailsCategory.InitialAuthorization,
            "incremental_authorization" => RequestDetailsCategory.IncrementalAuthorization,
            _ => (RequestDetailsCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RequestDetailsCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RequestDetailsCategory.InitialAuthorization => "initial_authorization",
                RequestDetailsCategory.IncrementalAuthorization => "incremental_authorization",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to the category `incremental_authorization`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<IncrementalAuthorization, IncrementalAuthorizationFromRaw>)
)]
public sealed record class IncrementalAuthorization : JsonModel
{
    /// <summary>
    /// The card payment for this authorization and increment.
    /// </summary>
    public required string CardPaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("card_payment_id");
        }
        init { this._rawData.Set("card_payment_id", value); }
    }

    /// <summary>
    /// The identifier of the card authorization this request is attempting to increment.
    /// </summary>
    public required string OriginalCardAuthorizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("original_card_authorization_id");
        }
        init { this._rawData.Set("original_card_authorization_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CardPaymentID;
        _ = this.OriginalCardAuthorizationID;
    }

    public IncrementalAuthorization() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IncrementalAuthorization(IncrementalAuthorization incrementalAuthorization)
        : base(incrementalAuthorization) { }
#pragma warning restore CS8618

    public IncrementalAuthorization(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IncrementalAuthorization(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IncrementalAuthorizationFromRaw.FromRawUnchecked"/>
    public static IncrementalAuthorization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IncrementalAuthorizationFromRaw : IFromRawJson<IncrementalAuthorization>
{
    /// <inheritdoc/>
    public IncrementalAuthorization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IncrementalAuthorization.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields specific to the category `initial_authorization`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InitialAuthorization, InitialAuthorizationFromRaw>))]
public sealed record class InitialAuthorization : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public InitialAuthorization() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InitialAuthorization(InitialAuthorization initialAuthorization)
        : base(initialAuthorization) { }
#pragma warning restore CS8618

    public InitialAuthorization(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InitialAuthorization(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InitialAuthorizationFromRaw.FromRawUnchecked"/>
    public static InitialAuthorization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InitialAuthorizationFromRaw : IFromRawJson<InitialAuthorization>
{
    /// <inheritdoc/>
    public InitialAuthorization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InitialAuthorization.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields related to verification of cardholder-provided values.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Verification, VerificationFromRaw>))]
public sealed record class Verification : JsonModel
{
    /// <summary>
    /// Fields related to verification of the Card Verification Code, a 3-digit code
    /// on the back of the card.
    /// </summary>
    public required CardVerificationCode CardVerificationCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardVerificationCode>("card_verification_code");
        }
        init { this._rawData.Set("card_verification_code", value); }
    }

    /// <summary>
    /// Cardholder address provided in the authorization request and the address
    /// on file we verified it against.
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

    /// <summary>
    /// Cardholder name provided in the authorization request.
    /// </summary>
    public required CardholderName? CardholderName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardholderName>("cardholder_name");
        }
        init { this._rawData.Set("cardholder_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CardVerificationCode.Validate();
        this.CardholderAddress.Validate();
        this.CardholderName?.Validate();
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
}

class VerificationFromRaw : IFromRawJson<Verification>
{
    /// <inheritdoc/>
    public Verification FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Verification.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields related to verification of the Card Verification Code, a 3-digit code
/// on the back of the card.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardVerificationCode, CardVerificationCodeFromRaw>))]
public sealed record class CardVerificationCode : JsonModel
{
    /// <summary>
    /// The result of verifying the Card Verification Code.
    /// </summary>
    public required ApiEnum<string, CardVerificationCodeResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardVerificationCodeResult>>(
                "result"
            );
        }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Result.Validate();
    }

    public CardVerificationCode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardVerificationCode(CardVerificationCode cardVerificationCode)
        : base(cardVerificationCode) { }
#pragma warning restore CS8618

    public CardVerificationCode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardVerificationCode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardVerificationCodeFromRaw.FromRawUnchecked"/>
    public static CardVerificationCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardVerificationCode(ApiEnum<string, CardVerificationCodeResult> result)
        : this()
    {
        this.Result = result;
    }
}

class CardVerificationCodeFromRaw : IFromRawJson<CardVerificationCode>
{
    /// <inheritdoc/>
    public CardVerificationCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardVerificationCode.FromRawUnchecked(rawData);
}

/// <summary>
/// The result of verifying the Card Verification Code.
/// </summary>
[JsonConverter(typeof(CardVerificationCodeResultConverter))]
public enum CardVerificationCodeResult
{
    /// <summary>
    /// No card verification code was provided in the authorization request.
    /// </summary>
    NotChecked,

    /// <summary>
    /// The card verification code matched the one on file.
    /// </summary>
    Match,

    /// <summary>
    /// The card verification code did not match the one on file.
    /// </summary>
    NoMatch,
}

sealed class CardVerificationCodeResultConverter : JsonConverter<CardVerificationCodeResult>
{
    public override CardVerificationCodeResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_checked" => CardVerificationCodeResult.NotChecked,
            "match" => CardVerificationCodeResult.Match,
            "no_match" => CardVerificationCodeResult.NoMatch,
            _ => (CardVerificationCodeResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardVerificationCodeResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardVerificationCodeResult.NotChecked => "not_checked",
                CardVerificationCodeResult.Match => "match",
                CardVerificationCodeResult.NoMatch => "no_match",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Cardholder address provided in the authorization request and the address on file
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
    /// The cardholder address line 1 provided for verification in the authorization request.
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
    /// The postal code provided for verification in the authorization request.
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
    /// The address verification result returned to the card network.
    /// </summary>
    public required ApiEnum<string, CardholderAddressResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardholderAddressResult>>(
                "result"
            );
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
/// The address verification result returned to the card network.
/// </summary>
[JsonConverter(typeof(CardholderAddressResultConverter))]
public enum CardholderAddressResult
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

sealed class CardholderAddressResultConverter : JsonConverter<CardholderAddressResult>
{
    public override CardholderAddressResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_checked" => CardholderAddressResult.NotChecked,
            "postal_code_match_address_no_match" =>
                CardholderAddressResult.PostalCodeMatchAddressNoMatch,
            "postal_code_no_match_address_match" =>
                CardholderAddressResult.PostalCodeNoMatchAddressMatch,
            "match" => CardholderAddressResult.Match,
            "no_match" => CardholderAddressResult.NoMatch,
            "postal_code_match_address_not_checked" =>
                CardholderAddressResult.PostalCodeMatchAddressNotChecked,
            _ => (CardholderAddressResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardholderAddressResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardholderAddressResult.NotChecked => "not_checked",
                CardholderAddressResult.PostalCodeMatchAddressNoMatch =>
                    "postal_code_match_address_no_match",
                CardholderAddressResult.PostalCodeNoMatchAddressMatch =>
                    "postal_code_no_match_address_match",
                CardholderAddressResult.Match => "match",
                CardholderAddressResult.NoMatch => "no_match",
                CardholderAddressResult.PostalCodeMatchAddressNotChecked =>
                    "postal_code_match_address_not_checked",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Cardholder name provided in the authorization request.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardholderName, CardholderNameFromRaw>))]
public sealed record class CardholderName : JsonModel
{
    /// <summary>
    /// The first name provided for verification in the authorization request.
    /// </summary>
    public required string? ProvidedFirstName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("provided_first_name");
        }
        init { this._rawData.Set("provided_first_name", value); }
    }

    /// <summary>
    /// The last name provided for verification in the authorization request.
    /// </summary>
    public required string? ProvidedLastName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("provided_last_name");
        }
        init { this._rawData.Set("provided_last_name", value); }
    }

    /// <summary>
    /// The middle name provided for verification in the authorization request.
    /// </summary>
    public required string? ProvidedMiddleName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("provided_middle_name");
        }
        init { this._rawData.Set("provided_middle_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProvidedFirstName;
        _ = this.ProvidedLastName;
        _ = this.ProvidedMiddleName;
    }

    public CardholderName() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardholderName(CardholderName cardholderName)
        : base(cardholderName) { }
#pragma warning restore CS8618

    public CardholderName(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardholderName(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardholderNameFromRaw.FromRawUnchecked"/>
    public static CardholderName FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardholderNameFromRaw : IFromRawJson<CardholderName>
{
    /// <inheritdoc/>
    public CardholderName FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardholderName.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields related to a card balance inquiry.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiry,
        RealTimeDecisionCardBalanceInquiryFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiry : JsonModel
{
    /// <summary>
    /// The identifier of the Account the authorization will debit.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// Additional amounts associated with the card authorization, such as ATM surcharges
    /// fees. These are usually a subset of the `amount` field and are used to provide
    /// more detailed information about the transaction.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryAdditionalAmounts AdditionalAmounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RealTimeDecisionCardBalanceInquiryAdditionalAmounts>(
                "additional_amounts"
            );
        }
        init { this._rawData.Set("additional_amounts", value); }
    }

    /// <summary>
    /// Present if and only if `decision` is `approve`. Contains information related
    /// to the approval of the balance inquiry.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryApproval? Approval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardBalanceInquiryApproval>(
                "approval"
            );
        }
        init { this._rawData.Set("approval", value); }
    }

    /// <summary>
    /// The identifier of the Card that is being authorized.
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
    /// Whether or not the authorization was approved.
    /// </summary>
    public required ApiEnum<string, RealTimeDecisionCardBalanceInquiryDecision>? Decision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, RealTimeDecisionCardBalanceInquiryDecision>
            >("decision");
        }
        init { this._rawData.Set("decision", value); }
    }

    /// <summary>
    /// If the authorization was made via a Digital Wallet Token (such as an Apple
    /// Pay purchase), the identifier of the token that was used.
    /// </summary>
    public required string? DigitalWalletTokenID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("digital_wallet_token_id");
        }
        init { this._rawData.Set("digital_wallet_token_id", value); }
    }

    /// <summary>
    /// The merchant identifier (commonly abbreviated as MID) of the merchant the
    /// card is transacting with.
    /// </summary>
    public required string MerchantAcceptorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_acceptor_id");
        }
        init { this._rawData.Set("merchant_acceptor_id", value); }
    }

    /// <summary>
    /// The Merchant Category Code (commonly abbreviated as MCC) of the merchant the
    /// card is transacting with.
    /// </summary>
    public required string MerchantCategoryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_category_code");
        }
        init { this._rawData.Set("merchant_category_code", value); }
    }

    /// <summary>
    /// The city the merchant resides in.
    /// </summary>
    public required string? MerchantCity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_city");
        }
        init { this._rawData.Set("merchant_city", value); }
    }

    /// <summary>
    /// The country the merchant resides in.
    /// </summary>
    public required string MerchantCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_country");
        }
        init { this._rawData.Set("merchant_country", value); }
    }

    /// <summary>
    /// The merchant descriptor of the merchant the card is transacting with.
    /// </summary>
    public required string MerchantDescriptor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_descriptor");
        }
        init { this._rawData.Set("merchant_descriptor", value); }
    }

    /// <summary>
    /// The merchant's postal code. For US merchants this is either a 5-digit or 9-digit
    /// ZIP code, where the first 5 and last 4 are separated by a dash.
    /// </summary>
    public required string? MerchantPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_postal_code");
        }
        init { this._rawData.Set("merchant_postal_code", value); }
    }

    /// <summary>
    /// The state the merchant resides in.
    /// </summary>
    public required string? MerchantState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_state");
        }
        init { this._rawData.Set("merchant_state", value); }
    }

    /// <summary>
    /// Fields specific to the `network`.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryNetworkDetails NetworkDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RealTimeDecisionCardBalanceInquiryNetworkDetails>(
                "network_details"
            );
        }
        init { this._rawData.Set("network_details", value); }
    }

    /// <summary>
    /// Network-specific identifiers for a specific request or transaction.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryNetworkIdentifiers NetworkIdentifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RealTimeDecisionCardBalanceInquiryNetworkIdentifiers>(
                "network_identifiers"
            );
        }
        init { this._rawData.Set("network_identifiers", value); }
    }

    /// <summary>
    /// The risk score generated by the card network. For Visa this is the Visa Advanced
    /// Authorization risk score, from 0 to 99, where 99 is the riskiest. For Pulse
    /// the score is from 0 to 999, where 999 is the riskiest.
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
    /// If the authorization was made in-person with a physical card, the Physical
    /// Card that was used.
    /// </summary>
    public required string? PhysicalCardID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("physical_card_id");
        }
        init { this._rawData.Set("physical_card_id", value); }
    }

    /// <summary>
    /// The terminal identifier (commonly abbreviated as TID) of the terminal the
    /// card is transacting with.
    /// </summary>
    public required string? TerminalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("terminal_id");
        }
        init { this._rawData.Set("terminal_id", value); }
    }

    /// <summary>
    /// The identifier of the Card Payment this authorization will belong to. Available
    /// in the API once the card authorization has completed.
    /// </summary>
    public required string UpcomingCardPaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("upcoming_card_payment_id");
        }
        init { this._rawData.Set("upcoming_card_payment_id", value); }
    }

    /// <summary>
    /// Fields related to verification of cardholder-provided values.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryVerification Verification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RealTimeDecisionCardBalanceInquiryVerification>(
                "verification"
            );
        }
        init { this._rawData.Set("verification", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        this.AdditionalAmounts.Validate();
        this.Approval?.Validate();
        _ = this.CardID;
        this.Decision?.Validate();
        _ = this.DigitalWalletTokenID;
        _ = this.MerchantAcceptorID;
        _ = this.MerchantCategoryCode;
        _ = this.MerchantCity;
        _ = this.MerchantCountry;
        _ = this.MerchantDescriptor;
        _ = this.MerchantPostalCode;
        _ = this.MerchantState;
        this.NetworkDetails.Validate();
        this.NetworkIdentifiers.Validate();
        _ = this.NetworkRiskScore;
        _ = this.PhysicalCardID;
        _ = this.TerminalID;
        _ = this.UpcomingCardPaymentID;
        this.Verification.Validate();
    }

    public RealTimeDecisionCardBalanceInquiry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiry(
        RealTimeDecisionCardBalanceInquiry realTimeDecisionCardBalanceInquiry
    )
        : base(realTimeDecisionCardBalanceInquiry) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryFromRaw : IFromRawJson<RealTimeDecisionCardBalanceInquiry>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiry.FromRawUnchecked(rawData);
}

/// <summary>
/// Additional amounts associated with the card authorization, such as ATM surcharges
/// fees. These are usually a subset of the `amount` field and are used to provide
/// more detailed information about the transaction.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryAdditionalAmounts,
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryAdditionalAmounts : JsonModel
{
    /// <summary>
    /// The part of this transaction amount that was for clinic-related services.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic? Clinic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic>(
                "clinic"
            );
        }
        init { this._rawData.Set("clinic", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for dental-related services.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental? Dental
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental>(
                "dental"
            );
        }
        init { this._rawData.Set("dental", value); }
    }

    /// <summary>
    /// The original pre-authorized amount.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal? Original
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal>(
                "original"
            );
        }
        init { this._rawData.Set("original", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for healthcare prescriptions.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription? Prescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription>(
                "prescription"
            );
        }
        init { this._rawData.Set("prescription", value); }
    }

    /// <summary>
    /// The surcharge amount charged for this transaction by the merchant.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge? Surcharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge>(
                "surcharge"
            );
        }
        init { this._rawData.Set("surcharge", value); }
    }

    /// <summary>
    /// The total amount of a series of incremental authorizations, optionally provided.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative? TotalCumulative
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative>(
                "total_cumulative"
            );
        }
        init { this._rawData.Set("total_cumulative", value); }
    }

    /// <summary>
    /// The total amount of healthcare-related additional amounts.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare? TotalHealthcare
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare>(
                "total_healthcare"
            );
        }
        init { this._rawData.Set("total_healthcare", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for transit-related services.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit? Transit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit>(
                "transit"
            );
        }
        init { this._rawData.Set("transit", value); }
    }

    /// <summary>
    /// An unknown additional amount.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown? Unknown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown>(
                "unknown"
            );
        }
        init { this._rawData.Set("unknown", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for vision-related services.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision? Vision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision>(
                "vision"
            );
        }
        init { this._rawData.Set("vision", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Clinic?.Validate();
        this.Dental?.Validate();
        this.Original?.Validate();
        this.Prescription?.Validate();
        this.Surcharge?.Validate();
        this.TotalCumulative?.Validate();
        this.TotalHealthcare?.Validate();
        this.Transit?.Validate();
        this.Unknown?.Validate();
        this.Vision?.Validate();
    }

    public RealTimeDecisionCardBalanceInquiryAdditionalAmounts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryAdditionalAmounts(
        RealTimeDecisionCardBalanceInquiryAdditionalAmounts realTimeDecisionCardBalanceInquiryAdditionalAmounts
    )
        : base(realTimeDecisionCardBalanceInquiryAdditionalAmounts) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryAdditionalAmounts(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryAdditionalAmounts(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryAdditionalAmountsFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryAdditionalAmounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryAdditionalAmountsFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryAdditionalAmounts>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryAdditionalAmounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryAdditionalAmounts.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for clinic-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic,
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinicFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic(
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic realTimeDecisionCardBalanceInquiryAdditionalAmountsClinic
    )
        : base(realTimeDecisionCardBalanceInquiryAdditionalAmountsClinic) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinicFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinicFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for dental-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental,
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsDentalFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental(
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental realTimeDecisionCardBalanceInquiryAdditionalAmountsDental
    )
        : base(realTimeDecisionCardBalanceInquiryAdditionalAmountsDental) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryAdditionalAmountsDentalFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryAdditionalAmountsDentalFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental.FromRawUnchecked(rawData);
}

/// <summary>
/// The original pre-authorized amount.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal,
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginalFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal(
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal realTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal
    )
        : base(realTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginalFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginalFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for healthcare prescriptions.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription,
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescriptionFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription
    : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription(
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription realTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription
    )
        : base(realTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescriptionFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescriptionFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription.FromRawUnchecked(rawData);
}

/// <summary>
/// The surcharge amount charged for this transaction by the merchant.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge,
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurchargeFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge(
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge realTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge
    )
        : base(realTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurchargeFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurchargeFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of a series of incremental authorizations, optionally provided.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative,
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulativeFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative
    : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative(
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative realTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative
    )
        : base(realTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulativeFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulativeFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The total amount of healthcare-related additional amounts.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare,
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcareFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare
    : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare(
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare realTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare
    )
        : base(realTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcareFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcareFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The part of this transaction amount that was for transit-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit,
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransitFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit(
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit realTimeDecisionCardBalanceInquiryAdditionalAmountsTransit
    )
        : base(realTimeDecisionCardBalanceInquiryAdditionalAmountsTransit) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransitFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransitFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit.FromRawUnchecked(rawData);
}

/// <summary>
/// An unknown additional amount.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown,
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknownFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown(
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown realTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown
    )
        : base(realTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknownFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknownFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for vision-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision,
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsVisionFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision(
        RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision realTimeDecisionCardBalanceInquiryAdditionalAmountsVision
    )
        : base(realTimeDecisionCardBalanceInquiryAdditionalAmountsVision) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryAdditionalAmountsVisionFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryAdditionalAmountsVisionFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision.FromRawUnchecked(rawData);
}

/// <summary>
/// Present if and only if `decision` is `approve`. Contains information related to
/// the approval of the balance inquiry.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryApproval,
        RealTimeDecisionCardBalanceInquiryApprovalFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryApproval : JsonModel
{
    /// <summary>
    /// If the balance inquiry was approved, this field contains the balance in the
    /// minor unit of the settlement currency.
    /// </summary>
    public required long Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("balance");
        }
        init { this._rawData.Set("balance", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Balance;
    }

    public RealTimeDecisionCardBalanceInquiryApproval() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryApproval(
        RealTimeDecisionCardBalanceInquiryApproval realTimeDecisionCardBalanceInquiryApproval
    )
        : base(realTimeDecisionCardBalanceInquiryApproval) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryApproval(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryApproval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryApprovalFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryApproval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryApproval(long balance)
        : this()
    {
        this.Balance = balance;
    }
}

class RealTimeDecisionCardBalanceInquiryApprovalFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryApproval>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryApproval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryApproval.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether or not the authorization was approved.
/// </summary>
[JsonConverter(typeof(RealTimeDecisionCardBalanceInquiryDecisionConverter))]
public enum RealTimeDecisionCardBalanceInquiryDecision
{
    /// <summary>
    /// Approve the authorization.
    /// </summary>
    Approve,

    /// <summary>
    /// Decline the authorization.
    /// </summary>
    Decline,
}

sealed class RealTimeDecisionCardBalanceInquiryDecisionConverter
    : JsonConverter<RealTimeDecisionCardBalanceInquiryDecision>
{
    public override RealTimeDecisionCardBalanceInquiryDecision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approve" => RealTimeDecisionCardBalanceInquiryDecision.Approve,
            "decline" => RealTimeDecisionCardBalanceInquiryDecision.Decline,
            _ => (RealTimeDecisionCardBalanceInquiryDecision)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionCardBalanceInquiryDecision value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionCardBalanceInquiryDecision.Approve => "approve",
                RealTimeDecisionCardBalanceInquiryDecision.Decline => "decline",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to the `network`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryNetworkDetails,
        RealTimeDecisionCardBalanceInquiryNetworkDetailsFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryNetworkDetails : JsonModel
{
    /// <summary>
    /// The payment network used to process this card authorization.
    /// </summary>
    public required ApiEnum<
        string,
        RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory
    > Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory>
            >("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Fields specific to the `pulse` network.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse? Pulse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse>(
                "pulse"
            );
        }
        init { this._rawData.Set("pulse", value); }
    }

    /// <summary>
    /// Fields specific to the `visa` network.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa? Visa
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa>(
                "visa"
            );
        }
        init { this._rawData.Set("visa", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.Pulse?.Validate();
        this.Visa?.Validate();
    }

    public RealTimeDecisionCardBalanceInquiryNetworkDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryNetworkDetails(
        RealTimeDecisionCardBalanceInquiryNetworkDetails realTimeDecisionCardBalanceInquiryNetworkDetails
    )
        : base(realTimeDecisionCardBalanceInquiryNetworkDetails) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryNetworkDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryNetworkDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryNetworkDetailsFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryNetworkDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryNetworkDetailsFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryNetworkDetails>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryNetworkDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryNetworkDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// The payment network used to process this card authorization.
/// </summary>
[JsonConverter(typeof(RealTimeDecisionCardBalanceInquiryNetworkDetailsCategoryConverter))]
public enum RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory
{
    /// <summary>
    /// Visa
    /// </summary>
    Visa,

    /// <summary>
    /// Pulse
    /// </summary>
    Pulse,
}

sealed class RealTimeDecisionCardBalanceInquiryNetworkDetailsCategoryConverter
    : JsonConverter<RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory>
{
    public override RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
            "pulse" => RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Pulse,
            _ => (RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa => "visa",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Pulse => "pulse",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to the `pulse` network.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse,
        RealTimeDecisionCardBalanceInquiryNetworkDetailsPulseFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse(
        RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse realTimeDecisionCardBalanceInquiryNetworkDetailsPulse
    )
        : base(realTimeDecisionCardBalanceInquiryNetworkDetailsPulse) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryNetworkDetailsPulseFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryNetworkDetailsPulseFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields specific to the `visa` network.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa,
        RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa : JsonModel
{
    /// <summary>
    /// For electronic commerce transactions, this identifies the level of security
    /// used in obtaining the customer's payment credential. For mail or telephone
    /// order transactions, identifies the type of mail or telephone order.
    /// </summary>
    public required ApiEnum<
        string,
        RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator
    >? ElectronicCommerceIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator
                >
            >("electronic_commerce_indicator");
        }
        init { this._rawData.Set("electronic_commerce_indicator", value); }
    }

    /// <summary>
    /// The method used to enter the cardholder's primary account number and card
    /// expiration date.
    /// </summary>
    public required ApiEnum<
        string,
        RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode
    >? PointOfServiceEntryMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode
                >
            >("point_of_service_entry_mode");
        }
        init { this._rawData.Set("point_of_service_entry_mode", value); }
    }

    /// <summary>
    /// Only present when `actioner: network`. Describes why a card authorization
    /// was approved or declined by Visa through stand-in processing.
    /// </summary>
    public required ApiEnum<
        string,
        RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason
    >? StandInProcessingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason
                >
            >("stand_in_processing_reason");
        }
        init { this._rawData.Set("stand_in_processing_reason", value); }
    }

    /// <summary>
    /// The capability of the terminal being used to read the card. Shows whether
    /// a terminal can e.g., accept chip cards or if it only supports magnetic stripe
    /// reads. This reflects the highest capability of the terminal — for example,
    /// a terminal that supports both chip and magnetic stripe will be identified
    /// as chip-capable.
    /// </summary>
    public required ApiEnum<
        string,
        RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability
    >? TerminalEntryCapability
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability
                >
            >("terminal_entry_capability");
        }
        init { this._rawData.Set("terminal_entry_capability", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ElectronicCommerceIndicator?.Validate();
        this.PointOfServiceEntryMode?.Validate();
        this.StandInProcessingReason?.Validate();
        this.TerminalEntryCapability?.Validate();
    }

    public RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa(
        RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa realTimeDecisionCardBalanceInquiryNetworkDetailsVisa
    )
        : base(realTimeDecisionCardBalanceInquiryNetworkDetailsVisa) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa.FromRawUnchecked(rawData);
}

/// <summary>
/// For electronic commerce transactions, this identifies the level of security used
/// in obtaining the customer's payment credential. For mail or telephone order transactions,
/// identifies the type of mail or telephone order.
/// </summary>
[JsonConverter(
    typeof(RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicatorConverter)
)]
public enum RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator
{
    /// <summary>
    /// Single transaction of a mail/phone order: Use to indicate that the transaction
    /// is a mail/phone order purchase, not a recurring transaction or installment
    /// payment. For domestic transactions in the US region, this value may also indicate
    /// one bill payment transaction in the card-present or card-absent environments.
    /// </summary>
    MailPhoneOrder,

    /// <summary>
    /// Recurring transaction: Payment indicator used to indicate a recurring transaction
    /// that originates from an acquirer in the US region.
    /// </summary>
    Recurring,

    /// <summary>
    /// Installment payment: Payment indicator used to indicate one purchase of goods
    /// or services that is billed to the account in multiple charges over a period
    /// of time agreed upon by the cardholder and merchant from transactions that
    /// originate from an acquirer in the US region.
    /// </summary>
    Installment,

    /// <summary>
    /// Unknown classification: other mail order: Use to indicate that the type of
    /// mail/telephone order is unknown.
    /// </summary>
    UnknownMailPhoneOrder,

    /// <summary>
    /// Secure electronic commerce transaction: Use to indicate that the electronic
    /// commerce transaction has been authenticated using e.g., 3-D Secure
    /// </summary>
    SecureElectronicCommerce,

    /// <summary>
    /// Non-authenticated security transaction at a 3-D Secure-capable merchant,
    /// and merchant attempted to authenticate the cardholder using 3-D Secure: Use
    /// to identify an electronic commerce transaction where the merchant attempted
    /// to authenticate the cardholder using 3-D Secure, but was unable to complete
    /// the authentication because the issuer or cardholder does not participate in
    /// the 3-D Secure program.
    /// </summary>
    NonAuthenticatedSecurityTransactionAt3dsCapableMerchant,

    /// <summary>
    /// Non-authenticated security transaction: Use to identify an electronic commerce
    /// transaction that uses data encryption for security however, cardholder authentication
    /// is not performed using 3-D Secure.
    /// </summary>
    NonAuthenticatedSecurityTransaction,

    /// <summary>
    /// Non-secure transaction: Use to identify an electronic commerce transaction
    /// that has no data protection.
    /// </summary>
    NonSecureTransaction,
}

sealed class RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicatorConverter
    : JsonConverter<RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator>
{
    public override RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mail_phone_order" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
            "recurring" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.Recurring,
            "installment" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.Installment,
            "unknown_mail_phone_order" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.UnknownMailPhoneOrder,
            "secure_electronic_commerce" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.SecureElectronicCommerce,
            "non_authenticated_security_transaction_at_3ds_capable_merchant" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant,
            "non_authenticated_security_transaction" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction,
            "non_secure_transaction" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonSecureTransaction,
            _ => (RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder =>
                    "mail_phone_order",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.Recurring =>
                    "recurring",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.Installment =>
                    "installment",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.UnknownMailPhoneOrder =>
                    "unknown_mail_phone_order",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.SecureElectronicCommerce =>
                    "secure_electronic_commerce",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant =>
                    "non_authenticated_security_transaction_at_3ds_capable_merchant",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction =>
                    "non_authenticated_security_transaction",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonSecureTransaction =>
                    "non_secure_transaction",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The method used to enter the cardholder's primary account number and card expiration date.
/// </summary>
[JsonConverter(
    typeof(RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryModeConverter)
)]
public enum RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode
{
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown,

    /// <summary>
    /// Manual key entry
    /// </summary>
    Manual,

    /// <summary>
    /// Magnetic stripe read, without card verification value
    /// </summary>
    MagneticStripeNoCvv,

    /// <summary>
    /// Optical code
    /// </summary>
    OpticalCode,

    /// <summary>
    /// Contact chip card
    /// </summary>
    IntegratedCircuitCard,

    /// <summary>
    /// Contactless read of chip card
    /// </summary>
    Contactless,

    /// <summary>
    /// Transaction initiated using a credential that has previously been stored
    /// on file
    /// </summary>
    CredentialOnFile,

    /// <summary>
    /// Magnetic stripe read
    /// </summary>
    MagneticStripe,

    /// <summary>
    /// Contactless read of magnetic stripe data
    /// </summary>
    ContactlessMagneticStripe,

    /// <summary>
    /// Contact chip card, without card verification value
    /// </summary>
    IntegratedCircuitCardNoCvv,
}

sealed class RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryModeConverter
    : JsonConverter<RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode>
{
    public override RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
            "manual" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Manual,
            "magnetic_stripe_no_cvv" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripeNoCvv,
            "optical_code" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.OpticalCode,
            "integrated_circuit_card" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCard,
            "contactless" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Contactless,
            "credential_on_file" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.CredentialOnFile,
            "magnetic_stripe" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripe,
            "contactless_magnetic_stripe" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.ContactlessMagneticStripe,
            "integrated_circuit_card_no_cvv" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCardNoCvv,
            _ => (RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown =>
                    "unknown",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Manual =>
                    "manual",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripeNoCvv =>
                    "magnetic_stripe_no_cvv",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.OpticalCode =>
                    "optical_code",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCard =>
                    "integrated_circuit_card",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Contactless =>
                    "contactless",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.CredentialOnFile =>
                    "credential_on_file",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripe =>
                    "magnetic_stripe",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.ContactlessMagneticStripe =>
                    "contactless_magnetic_stripe",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCardNoCvv =>
                    "integrated_circuit_card_no_cvv",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Only present when `actioner: network`. Describes why a card authorization was
/// approved or declined by Visa through stand-in processing.
/// </summary>
[JsonConverter(
    typeof(RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReasonConverter)
)]
public enum RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason
{
    /// <summary>
    /// Increase failed to process the authorization in a timely manner.
    /// </summary>
    IssuerError,

    /// <summary>
    /// The physical card read had an invalid CVV or dCVV.
    /// </summary>
    InvalidPhysicalCard,

    /// <summary>
    /// The card's authorization request cryptogram was invalid. The cryptogram can
    /// be from a physical card or a Digital Wallet Token purchase.
    /// </summary>
    InvalidCryptogram,

    /// <summary>
    /// The 3DS cardholder authentication verification value was invalid.
    /// </summary>
    InvalidCardholderAuthenticationVerificationValue,

    /// <summary>
    /// An internal Visa error occurred. Visa uses this reason code for certain expected
    /// occurrences as well, such as Application Transaction Counter (ATC) replays.
    /// </summary>
    InternalVisaError,

    /// <summary>
    /// The merchant has enabled Visa's Transaction Advisory Service and requires
    /// further authentication to perform the transaction. In practice this is often
    /// utilized at fuel pumps to tell the cardholder to see the cashier.
    /// </summary>
    MerchantTransactionAdvisoryServiceAuthenticationRequired,

    /// <summary>
    /// The transaction was blocked by Visa's Payment Fraud Disruption service due
    /// to fraudulent Acquirer behavior, such as card testing.
    /// </summary>
    PaymentFraudDisruptionAcquirerBlock,

    /// <summary>
    /// An unspecific reason for stand-in processing.
    /// </summary>
    Other,
}

sealed class RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReasonConverter
    : JsonConverter<RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason>
{
    public override RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "issuer_error" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
            "invalid_physical_card" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidPhysicalCard,
            "invalid_cryptogram" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidCryptogram,
            "invalid_cardholder_authentication_verification_value" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidCardholderAuthenticationVerificationValue,
            "internal_visa_error" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InternalVisaError,
            "merchant_transaction_advisory_service_authentication_required" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired,
            "payment_fraud_disruption_acquirer_block" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.PaymentFraudDisruptionAcquirerBlock,
            "other" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.Other,
            _ => (RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError =>
                    "issuer_error",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidPhysicalCard =>
                    "invalid_physical_card",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidCryptogram =>
                    "invalid_cryptogram",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidCardholderAuthenticationVerificationValue =>
                    "invalid_cardholder_authentication_verification_value",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InternalVisaError =>
                    "internal_visa_error",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired =>
                    "merchant_transaction_advisory_service_authentication_required",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.PaymentFraudDisruptionAcquirerBlock =>
                    "payment_fraud_disruption_acquirer_block",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.Other =>
                    "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The capability of the terminal being used to read the card. Shows whether a terminal
/// can e.g., accept chip cards or if it only supports magnetic stripe reads. This
/// reflects the highest capability of the terminal — for example, a terminal that
/// supports both chip and magnetic stripe will be identified as chip-capable.
/// </summary>
[JsonConverter(
    typeof(RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapabilityConverter)
)]
public enum RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability
{
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown,

    /// <summary>
    /// No terminal was used for this transaction.
    /// </summary>
    TerminalNotUsed,

    /// <summary>
    /// The terminal can only read magnetic stripes and does not have chip or contactless
    /// reading capability.
    /// </summary>
    MagneticStripe,

    /// <summary>
    /// The terminal can only read barcodes.
    /// </summary>
    Barcode,

    /// <summary>
    /// The terminal can only read cards via Optical Character Recognition.
    /// </summary>
    OpticalCharacterRecognition,

    /// <summary>
    /// The terminal supports contact chip cards and can also read the magnetic stripe.
    /// If contact chip is supported, this value is used regardless of whether contactless
    /// is also supported.
    /// </summary>
    ChipOrContactless,

    /// <summary>
    /// The terminal supports contactless reads but does not support contact chip.
    /// Only used when the terminal lacks contact chip capability.
    /// </summary>
    ContactlessOnly,

    /// <summary>
    /// The terminal has no card reading capability.
    /// </summary>
    NoCapability,
}

sealed class RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapabilityConverter
    : JsonConverter<RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability>
{
    public override RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
            "terminal_not_used" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.TerminalNotUsed,
            "magnetic_stripe" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.MagneticStripe,
            "barcode" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Barcode,
            "optical_character_recognition" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.OpticalCharacterRecognition,
            "chip_or_contactless" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.ChipOrContactless,
            "contactless_only" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.ContactlessOnly,
            "no_capability" =>
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.NoCapability,
            _ => (RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown =>
                    "unknown",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.TerminalNotUsed =>
                    "terminal_not_used",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.MagneticStripe =>
                    "magnetic_stripe",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Barcode =>
                    "barcode",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.OpticalCharacterRecognition =>
                    "optical_character_recognition",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.ChipOrContactless =>
                    "chip_or_contactless",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.ContactlessOnly =>
                    "contactless_only",
                RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.NoCapability =>
                    "no_capability",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Network-specific identifiers for a specific request or transaction.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryNetworkIdentifiers,
        RealTimeDecisionCardBalanceInquiryNetworkIdentifiersFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryNetworkIdentifiers : JsonModel
{
    /// <summary>
    /// The randomly generated 6-character Authorization Identification Response code
    /// sent back to the acquirer in an approved response.
    /// </summary>
    public required string? AuthorizationIdentificationResponse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("authorization_identification_response");
        }
        init { this._rawData.Set("authorization_identification_response", value); }
    }

    /// <summary>
    /// A life-cycle identifier used across e.g., an authorization and a reversal.
    /// Expected to be unique per acquirer within a window of time. For some card
    /// networks the retrieval reference number includes the trace counter.
    /// </summary>
    public required string? RetrievalReferenceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("retrieval_reference_number");
        }
        init { this._rawData.Set("retrieval_reference_number", value); }
    }

    /// <summary>
    /// A counter used to verify an individual authorization. Expected to be unique
    /// per acquirer within a window of time.
    /// </summary>
    public required string? TraceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("trace_number");
        }
        init { this._rawData.Set("trace_number", value); }
    }

    /// <summary>
    /// A globally unique transaction identifier provided by the card network, used
    /// across multiple life-cycle requests.
    /// </summary>
    public required string? TransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transaction_id");
        }
        init { this._rawData.Set("transaction_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AuthorizationIdentificationResponse;
        _ = this.RetrievalReferenceNumber;
        _ = this.TraceNumber;
        _ = this.TransactionID;
    }

    public RealTimeDecisionCardBalanceInquiryNetworkIdentifiers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryNetworkIdentifiers(
        RealTimeDecisionCardBalanceInquiryNetworkIdentifiers realTimeDecisionCardBalanceInquiryNetworkIdentifiers
    )
        : base(realTimeDecisionCardBalanceInquiryNetworkIdentifiers) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryNetworkIdentifiers(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryNetworkIdentifiers(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryNetworkIdentifiersFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryNetworkIdentifiersFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryNetworkIdentifiers>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryNetworkIdentifiers.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields related to verification of cardholder-provided values.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryVerification,
        RealTimeDecisionCardBalanceInquiryVerificationFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryVerification : JsonModel
{
    /// <summary>
    /// Fields related to verification of the Card Verification Code, a 3-digit code
    /// on the back of the card.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode CardVerificationCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode>(
                "card_verification_code"
            );
        }
        init { this._rawData.Set("card_verification_code", value); }
    }

    /// <summary>
    /// Cardholder address provided in the authorization request and the address
    /// on file we verified it against.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress CardholderAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress>(
                "cardholder_address"
            );
        }
        init { this._rawData.Set("cardholder_address", value); }
    }

    /// <summary>
    /// Cardholder name provided in the authorization request.
    /// </summary>
    public required RealTimeDecisionCardBalanceInquiryVerificationCardholderName? CardholderName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimeDecisionCardBalanceInquiryVerificationCardholderName>(
                "cardholder_name"
            );
        }
        init { this._rawData.Set("cardholder_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CardVerificationCode.Validate();
        this.CardholderAddress.Validate();
        this.CardholderName?.Validate();
    }

    public RealTimeDecisionCardBalanceInquiryVerification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryVerification(
        RealTimeDecisionCardBalanceInquiryVerification realTimeDecisionCardBalanceInquiryVerification
    )
        : base(realTimeDecisionCardBalanceInquiryVerification) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryVerification(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryVerification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryVerificationFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryVerificationFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryVerification>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryVerification.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields related to verification of the Card Verification Code, a 3-digit code
/// on the back of the card.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode,
        RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode
    : JsonModel
{
    /// <summary>
    /// The result of verifying the Card Verification Code.
    /// </summary>
    public required ApiEnum<
        string,
        RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult
    > Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult
                >
            >("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Result.Validate();
    }

    public RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode(
        RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode realTimeDecisionCardBalanceInquiryVerificationCardVerificationCode
    )
        : base(realTimeDecisionCardBalanceInquiryVerificationCardVerificationCode) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode(
        ApiEnum<
            string,
            RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult
        > result
    )
        : this()
    {
        this.Result = result;
    }
}

class RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The result of verifying the Card Verification Code.
/// </summary>
[JsonConverter(
    typeof(RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResultConverter)
)]
public enum RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult
{
    /// <summary>
    /// No card verification code was provided in the authorization request.
    /// </summary>
    NotChecked,

    /// <summary>
    /// The card verification code matched the one on file.
    /// </summary>
    Match,

    /// <summary>
    /// The card verification code did not match the one on file.
    /// </summary>
    NoMatch,
}

sealed class RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResultConverter
    : JsonConverter<RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult>
{
    public override RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_checked" =>
                RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked,
            "match" =>
                RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.Match,
            "no_match" =>
                RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NoMatch,
            _ => (RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked =>
                    "not_checked",
                RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.Match =>
                    "match",
                RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NoMatch =>
                    "no_match",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Cardholder address provided in the authorization request and the address on file
/// we verified it against.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress,
        RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress
    : JsonModel
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
    /// The cardholder address line 1 provided for verification in the authorization request.
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
    /// The postal code provided for verification in the authorization request.
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
    /// The address verification result returned to the card network.
    /// </summary>
    public required ApiEnum<
        string,
        RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult
    > Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult
                >
            >("result");
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

    public RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress(
        RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress realTimeDecisionCardBalanceInquiryVerificationCardholderAddress
    )
        : base(realTimeDecisionCardBalanceInquiryVerificationCardholderAddress) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The address verification result returned to the card network.
/// </summary>
[JsonConverter(
    typeof(RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResultConverter)
)]
public enum RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult
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

sealed class RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResultConverter
    : JsonConverter<RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult>
{
    public override RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_checked" =>
                RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
            "postal_code_match_address_no_match" =>
                RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.PostalCodeMatchAddressNoMatch,
            "postal_code_no_match_address_match" =>
                RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.PostalCodeNoMatchAddressMatch,
            "match" => RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.Match,
            "no_match" =>
                RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NoMatch,
            "postal_code_match_address_not_checked" =>
                RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.PostalCodeMatchAddressNotChecked,
            _ => (RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked =>
                    "not_checked",
                RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.PostalCodeMatchAddressNoMatch =>
                    "postal_code_match_address_no_match",
                RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.PostalCodeNoMatchAddressMatch =>
                    "postal_code_no_match_address_match",
                RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.Match =>
                    "match",
                RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NoMatch =>
                    "no_match",
                RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.PostalCodeMatchAddressNotChecked =>
                    "postal_code_match_address_not_checked",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Cardholder name provided in the authorization request.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionCardBalanceInquiryVerificationCardholderName,
        RealTimeDecisionCardBalanceInquiryVerificationCardholderNameFromRaw
    >)
)]
public sealed record class RealTimeDecisionCardBalanceInquiryVerificationCardholderName : JsonModel
{
    /// <summary>
    /// The first name provided for verification in the authorization request.
    /// </summary>
    public required string? ProvidedFirstName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("provided_first_name");
        }
        init { this._rawData.Set("provided_first_name", value); }
    }

    /// <summary>
    /// The last name provided for verification in the authorization request.
    /// </summary>
    public required string? ProvidedLastName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("provided_last_name");
        }
        init { this._rawData.Set("provided_last_name", value); }
    }

    /// <summary>
    /// The middle name provided for verification in the authorization request.
    /// </summary>
    public required string? ProvidedMiddleName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("provided_middle_name");
        }
        init { this._rawData.Set("provided_middle_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProvidedFirstName;
        _ = this.ProvidedLastName;
        _ = this.ProvidedMiddleName;
    }

    public RealTimeDecisionCardBalanceInquiryVerificationCardholderName() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionCardBalanceInquiryVerificationCardholderName(
        RealTimeDecisionCardBalanceInquiryVerificationCardholderName realTimeDecisionCardBalanceInquiryVerificationCardholderName
    )
        : base(realTimeDecisionCardBalanceInquiryVerificationCardholderName) { }
#pragma warning restore CS8618

    public RealTimeDecisionCardBalanceInquiryVerificationCardholderName(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionCardBalanceInquiryVerificationCardholderName(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionCardBalanceInquiryVerificationCardholderNameFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionCardBalanceInquiryVerificationCardholderName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionCardBalanceInquiryVerificationCardholderNameFromRaw
    : IFromRawJson<RealTimeDecisionCardBalanceInquiryVerificationCardholderName>
{
    /// <inheritdoc/>
    public RealTimeDecisionCardBalanceInquiryVerificationCardholderName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionCardBalanceInquiryVerificationCardholderName.FromRawUnchecked(rawData);
}

/// <summary>
/// The category of the Real-Time Decision.
/// </summary>
[JsonConverter(typeof(RealTimeDecisionCategoryConverter))]
public enum RealTimeDecisionCategory
{
    /// <summary>
    /// A card is being authorized.
    /// </summary>
    CardAuthorizationRequested,

    /// <summary>
    /// A balance inquiry is being made on a card.
    /// </summary>
    CardBalanceInquiryRequested,

    /// <summary>
    /// 3DS authentication is requested.
    /// </summary>
    CardAuthenticationRequested,

    /// <summary>
    /// 3DS authentication challenge requires cardholder involvement.
    /// </summary>
    CardAuthenticationChallengeRequested,

    /// <summary>
    /// A card is being loaded into a digital wallet.
    /// </summary>
    DigitalWalletTokenRequested,

    /// <summary>
    /// A card is being loaded into a digital wallet and requires cardholder authentication.
    /// </summary>
    DigitalWalletAuthenticationRequested,
}

sealed class RealTimeDecisionCategoryConverter : JsonConverter<RealTimeDecisionCategory>
{
    public override RealTimeDecisionCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_authorization_requested" => RealTimeDecisionCategory.CardAuthorizationRequested,
            "card_balance_inquiry_requested" =>
                RealTimeDecisionCategory.CardBalanceInquiryRequested,
            "card_authentication_requested" => RealTimeDecisionCategory.CardAuthenticationRequested,
            "card_authentication_challenge_requested" =>
                RealTimeDecisionCategory.CardAuthenticationChallengeRequested,
            "digital_wallet_token_requested" =>
                RealTimeDecisionCategory.DigitalWalletTokenRequested,
            "digital_wallet_authentication_requested" =>
                RealTimeDecisionCategory.DigitalWalletAuthenticationRequested,
            _ => (RealTimeDecisionCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionCategory.CardAuthorizationRequested =>
                    "card_authorization_requested",
                RealTimeDecisionCategory.CardBalanceInquiryRequested =>
                    "card_balance_inquiry_requested",
                RealTimeDecisionCategory.CardAuthenticationRequested =>
                    "card_authentication_requested",
                RealTimeDecisionCategory.CardAuthenticationChallengeRequested =>
                    "card_authentication_challenge_requested",
                RealTimeDecisionCategory.DigitalWalletTokenRequested =>
                    "digital_wallet_token_requested",
                RealTimeDecisionCategory.DigitalWalletAuthenticationRequested =>
                    "digital_wallet_authentication_requested",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields related to a digital wallet authentication attempt.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionDigitalWalletAuthentication,
        RealTimeDecisionDigitalWalletAuthenticationFromRaw
    >)
)]
public sealed record class RealTimeDecisionDigitalWalletAuthentication : JsonModel
{
    /// <summary>
    /// The identifier of the Card that is being tokenized.
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
    /// The channel to send the card user their one-time passcode.
    /// </summary>
    public required ApiEnum<string, Channel> Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Channel>>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <summary>
    /// The digital wallet app being used.
    /// </summary>
    public required ApiEnum<string, DigitalWallet> DigitalWallet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DigitalWallet>>("digital_wallet");
        }
        init { this._rawData.Set("digital_wallet", value); }
    }

    /// <summary>
    /// The email to send the one-time passcode to if `channel` is equal to `email`.
    /// </summary>
    public required string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// The one-time passcode to send the card user.
    /// </summary>
    public required string OneTimePasscode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("one_time_passcode");
        }
        init { this._rawData.Set("one_time_passcode", value); }
    }

    /// <summary>
    /// The phone number to send the one-time passcode to if `channel` is equal to `sms`.
    /// </summary>
    public required string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init { this._rawData.Set("phone", value); }
    }

    /// <summary>
    /// Whether your application successfully delivered the one-time passcode.
    /// </summary>
    public required ApiEnum<string, RealTimeDecisionDigitalWalletAuthenticationResult>? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, RealTimeDecisionDigitalWalletAuthenticationResult>
            >("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CardID;
        this.Channel.Validate();
        this.DigitalWallet.Validate();
        _ = this.Email;
        _ = this.OneTimePasscode;
        _ = this.Phone;
        this.Result?.Validate();
    }

    public RealTimeDecisionDigitalWalletAuthentication() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionDigitalWalletAuthentication(
        RealTimeDecisionDigitalWalletAuthentication realTimeDecisionDigitalWalletAuthentication
    )
        : base(realTimeDecisionDigitalWalletAuthentication) { }
#pragma warning restore CS8618

    public RealTimeDecisionDigitalWalletAuthentication(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionDigitalWalletAuthentication(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionDigitalWalletAuthenticationFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionDigitalWalletAuthentication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionDigitalWalletAuthenticationFromRaw
    : IFromRawJson<RealTimeDecisionDigitalWalletAuthentication>
{
    /// <inheritdoc/>
    public RealTimeDecisionDigitalWalletAuthentication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionDigitalWalletAuthentication.FromRawUnchecked(rawData);
}

/// <summary>
/// The channel to send the card user their one-time passcode.
/// </summary>
[JsonConverter(typeof(ChannelConverter))]
public enum Channel
{
    /// <summary>
    /// Send one-time passcodes over SMS.
    /// </summary>
    Sms,

    /// <summary>
    /// Send one-time passcodes over email.
    /// </summary>
    Email,
}

sealed class ChannelConverter : JsonConverter<Channel>
{
    public override Channel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms" => Channel.Sms,
            "email" => Channel.Email,
            _ => (Channel)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Channel value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Channel.Sms => "sms",
                Channel.Email => "email",
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
[JsonConverter(typeof(DigitalWalletConverter))]
public enum DigitalWallet
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

sealed class DigitalWalletConverter : JsonConverter<DigitalWallet>
{
    public override DigitalWallet Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "apple_pay" => DigitalWallet.ApplePay,
            "google_pay" => DigitalWallet.GooglePay,
            "samsung_pay" => DigitalWallet.SamsungPay,
            "unknown" => DigitalWallet.Unknown,
            _ => (DigitalWallet)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DigitalWallet value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DigitalWallet.ApplePay => "apple_pay",
                DigitalWallet.GooglePay => "google_pay",
                DigitalWallet.SamsungPay => "samsung_pay",
                DigitalWallet.Unknown => "unknown",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether your application successfully delivered the one-time passcode.
/// </summary>
[JsonConverter(typeof(RealTimeDecisionDigitalWalletAuthenticationResultConverter))]
public enum RealTimeDecisionDigitalWalletAuthenticationResult
{
    /// <summary>
    /// Your application successfully delivered the one-time passcode to the cardholder.
    /// </summary>
    Success,

    /// <summary>
    /// Your application failed to deliver the one-time passcode to the cardholder.
    /// </summary>
    Failure,
}

sealed class RealTimeDecisionDigitalWalletAuthenticationResultConverter
    : JsonConverter<RealTimeDecisionDigitalWalletAuthenticationResult>
{
    public override RealTimeDecisionDigitalWalletAuthenticationResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => RealTimeDecisionDigitalWalletAuthenticationResult.Success,
            "failure" => RealTimeDecisionDigitalWalletAuthenticationResult.Failure,
            _ => (RealTimeDecisionDigitalWalletAuthenticationResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionDigitalWalletAuthenticationResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionDigitalWalletAuthenticationResult.Success => "success",
                RealTimeDecisionDigitalWalletAuthenticationResult.Failure => "failure",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields related to a digital wallet token provisioning attempt.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimeDecisionDigitalWalletToken,
        RealTimeDecisionDigitalWalletTokenFromRaw
    >)
)]
public sealed record class RealTimeDecisionDigitalWalletToken : JsonModel
{
    /// <summary>
    /// The identifier of the Card that is being tokenized.
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
    /// Whether or not the provisioning request was approved. This will be null until
    /// the real time decision is responded to.
    /// </summary>
    public required ApiEnum<string, RealTimeDecisionDigitalWalletTokenDecision>? Decision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, RealTimeDecisionDigitalWalletTokenDecision>
            >("decision");
        }
        init { this._rawData.Set("decision", value); }
    }

    /// <summary>
    /// Device that is being used to provision the digital wallet token.
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
    /// The digital wallet app being used.
    /// </summary>
    public required ApiEnum<string, RealTimeDecisionDigitalWalletTokenDigitalWallet> DigitalWallet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, RealTimeDecisionDigitalWalletTokenDigitalWallet>
            >("digital_wallet");
        }
        init { this._rawData.Set("digital_wallet", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CardID;
        this.Decision?.Validate();
        this.Device.Validate();
        this.DigitalWallet.Validate();
    }

    public RealTimeDecisionDigitalWalletToken() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionDigitalWalletToken(
        RealTimeDecisionDigitalWalletToken realTimeDecisionDigitalWalletToken
    )
        : base(realTimeDecisionDigitalWalletToken) { }
#pragma warning restore CS8618

    public RealTimeDecisionDigitalWalletToken(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimeDecisionDigitalWalletToken(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimeDecisionDigitalWalletTokenFromRaw.FromRawUnchecked"/>
    public static RealTimeDecisionDigitalWalletToken FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimeDecisionDigitalWalletTokenFromRaw : IFromRawJson<RealTimeDecisionDigitalWalletToken>
{
    /// <inheritdoc/>
    public RealTimeDecisionDigitalWalletToken FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimeDecisionDigitalWalletToken.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether or not the provisioning request was approved. This will be null until
/// the real time decision is responded to.
/// </summary>
[JsonConverter(typeof(RealTimeDecisionDigitalWalletTokenDecisionConverter))]
public enum RealTimeDecisionDigitalWalletTokenDecision
{
    /// <summary>
    /// Approve the provisioning request.
    /// </summary>
    Approve,

    /// <summary>
    /// Decline the provisioning request.
    /// </summary>
    Decline,
}

sealed class RealTimeDecisionDigitalWalletTokenDecisionConverter
    : JsonConverter<RealTimeDecisionDigitalWalletTokenDecision>
{
    public override RealTimeDecisionDigitalWalletTokenDecision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approve" => RealTimeDecisionDigitalWalletTokenDecision.Approve,
            "decline" => RealTimeDecisionDigitalWalletTokenDecision.Decline,
            _ => (RealTimeDecisionDigitalWalletTokenDecision)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionDigitalWalletTokenDecision value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionDigitalWalletTokenDecision.Approve => "approve",
                RealTimeDecisionDigitalWalletTokenDecision.Decline => "decline",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Device that is being used to provision the digital wallet token.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Device, DeviceFromRaw>))]
public sealed record class Device : JsonModel
{
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Identifier;
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

    [SetsRequiredMembers]
    public Device(string? identifier)
        : this()
    {
        this.Identifier = identifier;
    }
}

class DeviceFromRaw : IFromRawJson<Device>
{
    /// <inheritdoc/>
    public Device FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Device.FromRawUnchecked(rawData);
}

/// <summary>
/// The digital wallet app being used.
/// </summary>
[JsonConverter(typeof(RealTimeDecisionDigitalWalletTokenDigitalWalletConverter))]
public enum RealTimeDecisionDigitalWalletTokenDigitalWallet
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

sealed class RealTimeDecisionDigitalWalletTokenDigitalWalletConverter
    : JsonConverter<RealTimeDecisionDigitalWalletTokenDigitalWallet>
{
    public override RealTimeDecisionDigitalWalletTokenDigitalWallet Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "apple_pay" => RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay,
            "google_pay" => RealTimeDecisionDigitalWalletTokenDigitalWallet.GooglePay,
            "samsung_pay" => RealTimeDecisionDigitalWalletTokenDigitalWallet.SamsungPay,
            "unknown" => RealTimeDecisionDigitalWalletTokenDigitalWallet.Unknown,
            _ => (RealTimeDecisionDigitalWalletTokenDigitalWallet)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionDigitalWalletTokenDigitalWallet value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay => "apple_pay",
                RealTimeDecisionDigitalWalletTokenDigitalWallet.GooglePay => "google_pay",
                RealTimeDecisionDigitalWalletTokenDigitalWallet.SamsungPay => "samsung_pay",
                RealTimeDecisionDigitalWalletTokenDigitalWallet.Unknown => "unknown",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the Real-Time Decision.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// The decision is pending action via real-time webhook.
    /// </summary>
    Pending,

    /// <summary>
    /// Your webhook actioned the real-time decision.
    /// </summary>
    Responded,

    /// <summary>
    /// Your webhook failed to respond to the authorization in time.
    /// </summary>
    TimedOut,
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
            "responded" => Status.Responded,
            "timed_out" => Status.TimedOut,
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
                Status.Responded => "responded",
                Status.TimedOut => "timed_out",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `real_time_decision`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    RealTimeDecision,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.RealTimeDecisions.Type>
{
    public override global::Increase.Api.Models.RealTimeDecisions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "real_time_decision" => global::Increase
                .Api
                .Models
                .RealTimeDecisions
                .Type
                .RealTimeDecision,
            _ => (global::Increase.Api.Models.RealTimeDecisions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.RealTimeDecisions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.RealTimeDecisions.Type.RealTimeDecision =>
                    "real_time_decision",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
