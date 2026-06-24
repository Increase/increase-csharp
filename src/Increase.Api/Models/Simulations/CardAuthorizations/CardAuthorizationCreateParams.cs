using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Simulations.CardAuthorizations;

/// <summary>
/// Simulates a purchase authorization on a [Card](#cards). Depending on the balance
/// available to the card and the `amount` submitted, the authorization activity
/// will result in a [Pending Transaction](#pending-transactions) of type `card_authorization`
/// or a [Declined Transaction](#declined-transactions) of type `card_decline`. You
/// can pass either a Card id or a [Digital Wallet Token](#digital-wallet-tokens)
/// id to simulate the two different ways purchases can be made. The response will
/// contain either a `pending_transaction` or a `declined_transaction`; the other
/// attribute will be null. If the authorization is declined, the reason is available
/// on the Declined Transaction at `source.card_decline.reason`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CardAuthorizationCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The authorization amount in cents.
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>("amount");
        }
        init { this._rawBodyData.Set("amount", value); }
    }

    /// <summary>
    /// The identifier of a Card Payment with a `card_authentication` if you want
    /// to simulate an authenticated authorization.
    /// </summary>
    public string? AuthenticatedCardPaymentID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("authenticated_card_payment_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("authenticated_card_payment_id", value);
        }
    }

    /// <summary>
    /// The identifier of the Card to be authorized.
    /// </summary>
    public string? CardID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("card_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("card_id", value);
        }
    }

    /// <summary>
    /// Forces a card decline with a specific reason. No real time decision will be sent.
    /// </summary>
    public ApiEnum<string, DeclineReason>? DeclineReason
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, DeclineReason>>(
                "decline_reason"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("decline_reason", value);
        }
    }

    /// <summary>
    /// The identifier of the Digital Wallet Token to be authorized.
    /// </summary>
    public string? DigitalWalletTokenID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("digital_wallet_token_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("digital_wallet_token_id", value);
        }
    }

    /// <summary>
    /// The identifier of the Event Subscription to use. If provided, will override
    /// the default real time event subscription. Because you can only create one
    /// real time decision event subscription, you can use this field to route events
    /// to any specified event subscription for testing purposes.
    /// </summary>
    public string? EventSubscriptionID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("event_subscription_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("event_subscription_id", value);
        }
    }

    /// <summary>
    /// The merchant identifier (commonly abbreviated as MID) of the merchant the
    /// card is transacting with.
    /// </summary>
    public string? MerchantAcceptorID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("merchant_acceptor_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("merchant_acceptor_id", value);
        }
    }

    /// <summary>
    /// The Merchant Category Code (commonly abbreviated as MCC) of the merchant the
    /// card is transacting with.
    /// </summary>
    public string? MerchantCategoryCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("merchant_category_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("merchant_category_code", value);
        }
    }

    /// <summary>
    /// The city the merchant resides in.
    /// </summary>
    public string? MerchantCity
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("merchant_city");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("merchant_city", value);
        }
    }

    /// <summary>
    /// The country the merchant resides in.
    /// </summary>
    public string? MerchantCountry
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("merchant_country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("merchant_country", value);
        }
    }

    /// <summary>
    /// The merchant descriptor of the merchant the card is transacting with.
    /// </summary>
    public string? MerchantDescriptor
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("merchant_descriptor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("merchant_descriptor", value);
        }
    }

    /// <summary>
    /// The state the merchant resides in.
    /// </summary>
    public string? MerchantState
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("merchant_state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("merchant_state", value);
        }
    }

    /// <summary>
    /// Fields specific to a given card network.
    /// </summary>
    public NetworkDetails? NetworkDetails
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<NetworkDetails>("network_details");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("network_details", value);
        }
    }

    /// <summary>
    /// The risk score generated by the card network. For Visa this is the Visa Advanced
    /// Authorization risk score, from 0 to 99, where 99 is the riskiest.
    /// </summary>
    public long? NetworkRiskScore
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("network_risk_score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("network_risk_score", value);
        }
    }

    /// <summary>
    /// The identifier of the Physical Card to be authorized.
    /// </summary>
    public string? PhysicalCardID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("physical_card_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("physical_card_id", value);
        }
    }

    /// <summary>
    /// Fields specific to a specific type of authorization, such as Automatic Fuel
    /// Dispensers, Refund Authorizations, or Cash Disbursements.
    /// </summary>
    public ProcessingCategory? ProcessingCategory
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ProcessingCategory>("processing_category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("processing_category", value);
        }
    }

    /// <summary>
    /// The terminal identifier (commonly abbreviated as TID) of the terminal the
    /// card is transacting with.
    /// </summary>
    public string? TerminalID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("terminal_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("terminal_id", value);
        }
    }

    public CardAuthorizationCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorizationCreateParams(
        CardAuthorizationCreateParams cardAuthorizationCreateParams
    )
        : base(cardAuthorizationCreateParams)
    {
        this._rawBodyData = new(cardAuthorizationCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CardAuthorizationCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorizationCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CardAuthorizationCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CardAuthorizationCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/simulations/card_authorizations"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Forces a card decline with a specific reason. No real time decision will be sent.
/// </summary>
[JsonConverter(typeof(DeclineReasonConverter))]
public enum DeclineReason
{
    /// <summary>
    /// The account has been closed.
    /// </summary>
    AccountClosed,

    /// <summary>
    /// The Card was not active.
    /// </summary>
    CardNotActive,

    /// <summary>
    /// The Card has been canceled.
    /// </summary>
    CardCanceled,

    /// <summary>
    /// The Physical Card was not active.
    /// </summary>
    PhysicalCardNotActive,

    /// <summary>
    /// The account's entity was not active.
    /// </summary>
    EntityNotActive,

    /// <summary>
    /// The account was inactive.
    /// </summary>
    GroupLocked,

    /// <summary>
    /// The Card's Account did not have a sufficient available balance.
    /// </summary>
    InsufficientFunds,

    /// <summary>
    /// The given CVV2 did not match the card's value.
    /// </summary>
    Cvv2Mismatch,

    /// <summary>
    /// The given PIN did not match the card's value.
    /// </summary>
    PinMismatch,

    /// <summary>
    /// The given expiration date did not match the card's value. Only applies when
    /// a CVV2 is present.
    /// </summary>
    CardExpirationMismatch,

    /// <summary>
    /// The attempted card transaction is not allowed per Increase's terms.
    /// </summary>
    TransactionNotAllowed,

    /// <summary>
    /// The transaction was blocked by a limit or an authorization control.
    /// </summary>
    BreachesLimit,

    /// <summary>
    /// Your application declined the transaction via webhook.
    /// </summary>
    WebhookDeclined,

    /// <summary>
    /// Your application webhook did not respond without the required timeout.
    /// </summary>
    WebhookTimedOut,

    /// <summary>
    /// Declined by stand-in processing.
    /// </summary>
    DeclinedByStandInProcessing,

    /// <summary>
    /// The card read had an invalid CVV or dCVV.
    /// </summary>
    InvalidPhysicalCard,

    /// <summary>
    /// The original card authorization for this incremental authorization does not exist.
    /// </summary>
    MissingOriginalAuthorization,

    /// <summary>
    /// The card's authorization request cryptogram was invalid. The cryptogram can
    /// be from a physical card or a Digital Wallet Token purchase.
    /// </summary>
    InvalidCryptogram,

    /// <summary>
    /// The transaction was declined because the 3DS authentication failed.
    /// </summary>
    Failed3dsAuthentication,

    /// <summary>
    /// The transaction was suspected to be used by a card tester to test for valid
    /// card numbers.
    /// </summary>
    SuspectedCardTesting,

    /// <summary>
    /// The transaction was suspected to be fraudulent. Please reach out to support@increase.com
    /// for more information.
    /// </summary>
    SuspectedFraud,
}

sealed class DeclineReasonConverter : JsonConverter<DeclineReason>
{
    public override DeclineReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_closed" => DeclineReason.AccountClosed,
            "card_not_active" => DeclineReason.CardNotActive,
            "card_canceled" => DeclineReason.CardCanceled,
            "physical_card_not_active" => DeclineReason.PhysicalCardNotActive,
            "entity_not_active" => DeclineReason.EntityNotActive,
            "group_locked" => DeclineReason.GroupLocked,
            "insufficient_funds" => DeclineReason.InsufficientFunds,
            "cvv2_mismatch" => DeclineReason.Cvv2Mismatch,
            "pin_mismatch" => DeclineReason.PinMismatch,
            "card_expiration_mismatch" => DeclineReason.CardExpirationMismatch,
            "transaction_not_allowed" => DeclineReason.TransactionNotAllowed,
            "breaches_limit" => DeclineReason.BreachesLimit,
            "webhook_declined" => DeclineReason.WebhookDeclined,
            "webhook_timed_out" => DeclineReason.WebhookTimedOut,
            "declined_by_stand_in_processing" => DeclineReason.DeclinedByStandInProcessing,
            "invalid_physical_card" => DeclineReason.InvalidPhysicalCard,
            "missing_original_authorization" => DeclineReason.MissingOriginalAuthorization,
            "invalid_cryptogram" => DeclineReason.InvalidCryptogram,
            "failed_3ds_authentication" => DeclineReason.Failed3dsAuthentication,
            "suspected_card_testing" => DeclineReason.SuspectedCardTesting,
            "suspected_fraud" => DeclineReason.SuspectedFraud,
            _ => (DeclineReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeclineReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DeclineReason.AccountClosed => "account_closed",
                DeclineReason.CardNotActive => "card_not_active",
                DeclineReason.CardCanceled => "card_canceled",
                DeclineReason.PhysicalCardNotActive => "physical_card_not_active",
                DeclineReason.EntityNotActive => "entity_not_active",
                DeclineReason.GroupLocked => "group_locked",
                DeclineReason.InsufficientFunds => "insufficient_funds",
                DeclineReason.Cvv2Mismatch => "cvv2_mismatch",
                DeclineReason.PinMismatch => "pin_mismatch",
                DeclineReason.CardExpirationMismatch => "card_expiration_mismatch",
                DeclineReason.TransactionNotAllowed => "transaction_not_allowed",
                DeclineReason.BreachesLimit => "breaches_limit",
                DeclineReason.WebhookDeclined => "webhook_declined",
                DeclineReason.WebhookTimedOut => "webhook_timed_out",
                DeclineReason.DeclinedByStandInProcessing => "declined_by_stand_in_processing",
                DeclineReason.InvalidPhysicalCard => "invalid_physical_card",
                DeclineReason.MissingOriginalAuthorization => "missing_original_authorization",
                DeclineReason.InvalidCryptogram => "invalid_cryptogram",
                DeclineReason.Failed3dsAuthentication => "failed_3ds_authentication",
                DeclineReason.SuspectedCardTesting => "suspected_card_testing",
                DeclineReason.SuspectedFraud => "suspected_fraud",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to a given card network.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NetworkDetails, NetworkDetailsFromRaw>))]
public sealed record class NetworkDetails : JsonModel
{
    /// <summary>
    /// Fields specific to the Visa network.
    /// </summary>
    public required Visa Visa
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Visa>("visa");
        }
        init { this._rawData.Set("visa", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Visa.Validate();
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

    [SetsRequiredMembers]
    public NetworkDetails(Visa visa)
        : this()
    {
        this.Visa = visa;
    }
}

class NetworkDetailsFromRaw : IFromRawJson<NetworkDetails>
{
    /// <inheritdoc/>
    public NetworkDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NetworkDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields specific to the Visa network.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Visa, VisaFromRaw>))]
public sealed record class Visa : JsonModel
{
    /// <summary>
    /// For electronic commerce transactions, this identifies the level of security
    /// used in obtaining the customer's payment credential. For mail or telephone
    /// order transactions, identifies the type of mail or telephone order.
    /// </summary>
    public ApiEnum<string, ElectronicCommerceIndicator>? ElectronicCommerceIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ElectronicCommerceIndicator>>(
                "electronic_commerce_indicator"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("electronic_commerce_indicator", value);
        }
    }

    /// <summary>
    /// The method used to enter the cardholder's primary account number and card
    /// expiration date.
    /// </summary>
    public ApiEnum<string, PointOfServiceEntryMode>? PointOfServiceEntryMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PointOfServiceEntryMode>>(
                "point_of_service_entry_mode"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("point_of_service_entry_mode", value);
        }
    }

    /// <summary>
    /// The reason code for the stand-in processing.
    /// </summary>
    public ApiEnum<string, StandInProcessingReason>? StandInProcessingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, StandInProcessingReason>>(
                "stand_in_processing_reason"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stand_in_processing_reason", value);
        }
    }

    /// <summary>
    /// The capability of the terminal being used to read the card. Shows whether
    /// a terminal can e.g., accept chip cards or if it only supports magnetic stripe
    /// reads. This reflects the highest capability of the terminal — for example,
    /// a terminal that supports both chip and magnetic stripe will be identified
    /// as chip-capable.
    /// </summary>
    public ApiEnum<string, TerminalEntryCapability>? TerminalEntryCapability
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TerminalEntryCapability>>(
                "terminal_entry_capability"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("terminal_entry_capability", value);
        }
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
/// The reason code for the stand-in processing.
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
/// Fields specific to a specific type of authorization, such as Automatic Fuel Dispensers,
/// Refund Authorizations, or Cash Disbursements.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProcessingCategory, ProcessingCategoryFromRaw>))]
public sealed record class ProcessingCategory : JsonModel
{
    /// <summary>
    /// The processing category describes the intent behind the authorization, such
    /// as whether it was used for bill payments or an automatic fuel dispenser.
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
    /// Details related to refund authorizations.
    /// </summary>
    public Refund? Refund
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Refund>("refund");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("refund", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.Refund?.Validate();
    }

    public ProcessingCategory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProcessingCategory(ProcessingCategory processingCategory)
        : base(processingCategory) { }
#pragma warning restore CS8618

    public ProcessingCategory(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProcessingCategory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProcessingCategoryFromRaw.FromRawUnchecked"/>
    public static ProcessingCategory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProcessingCategory(ApiEnum<string, Category> category)
        : this()
    {
        this.Category = category;
    }
}

class ProcessingCategoryFromRaw : IFromRawJson<ProcessingCategory>
{
    /// <inheritdoc/>
    public ProcessingCategory FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProcessingCategory.FromRawUnchecked(rawData);
}

/// <summary>
/// The processing category describes the intent behind the authorization, such as
/// whether it was used for bill payments or an automatic fuel dispenser.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
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
    /// Cash deposit transactions are used to deposit cash at an ATM or a point of sale.
    /// </summary>
    CashDeposit,

    /// <summary>
    /// A balance inquiry transaction is used to check the balance of an account associated
    /// with a card.
    /// </summary>
    BalanceInquiry,
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
            "account_funding" => Category.AccountFunding,
            "automatic_fuel_dispenser" => Category.AutomaticFuelDispenser,
            "bill_payment" => Category.BillPayment,
            "original_credit" => Category.OriginalCredit,
            "purchase" => Category.Purchase,
            "quasi_cash" => Category.QuasiCash,
            "refund" => Category.Refund,
            "cash_disbursement" => Category.CashDisbursement,
            "cash_deposit" => Category.CashDeposit,
            "balance_inquiry" => Category.BalanceInquiry,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.AccountFunding => "account_funding",
                Category.AutomaticFuelDispenser => "automatic_fuel_dispenser",
                Category.BillPayment => "bill_payment",
                Category.OriginalCredit => "original_credit",
                Category.Purchase => "purchase",
                Category.QuasiCash => "quasi_cash",
                Category.Refund => "refund",
                Category.CashDisbursement => "cash_disbursement",
                Category.CashDeposit => "cash_deposit",
                Category.BalanceInquiry => "balance_inquiry",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details related to refund authorizations.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Refund, RefundFromRaw>))]
public sealed record class Refund : JsonModel
{
    /// <summary>
    /// The card payment to link this refund to.
    /// </summary>
    public string? OriginalCardPaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("original_card_payment_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("original_card_payment_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OriginalCardPaymentID;
    }

    public Refund() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Refund(Refund refund)
        : base(refund) { }
#pragma warning restore CS8618

    public Refund(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Refund(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RefundFromRaw.FromRawUnchecked"/>
    public static Refund FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RefundFromRaw : IFromRawJson<Refund>
{
    /// <inheritdoc/>
    public Refund FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Refund.FromRawUnchecked(rawData);
}
