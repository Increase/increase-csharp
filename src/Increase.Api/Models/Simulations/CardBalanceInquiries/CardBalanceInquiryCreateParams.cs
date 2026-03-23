using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;

namespace Increase.Api.Models.Simulations.CardBalanceInquiries;

/// <summary>
/// Simulates a balance inquiry on a [Card](#cards).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CardBalanceInquiryCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The balance amount in cents. The account balance will be used if not provided.
    /// </summary>
    public long? Balance
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("balance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("balance", value);
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

    public CardBalanceInquiryCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryCreateParams(
        CardBalanceInquiryCreateParams cardBalanceInquiryCreateParams
    )
        : base(cardBalanceInquiryCreateParams)
    {
        this._rawBodyData = new(cardBalanceInquiryCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CardBalanceInquiryCreateParams(
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
    CardBalanceInquiryCreateParams(
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
    public static CardBalanceInquiryCreateParams FromRawUnchecked(
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

    public virtual bool Equals(CardBalanceInquiryCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/simulations/card_balance_inquiries"
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
    /// The transaction was blocked by a Limit.
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
        Type typeToConvert,
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.StandInProcessingReason?.Validate();
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
        Type typeToConvert,
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
