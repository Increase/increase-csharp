using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;

namespace Increase.Api.Models.Simulations.CardTokens;

/// <summary>
/// Simulates tokenizing a card in the sandbox environment.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CardTokenCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The capabilities of the outbound card token.
    /// </summary>
    public IReadOnlyList<Capability>? Capabilities
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Capability>>("capabilities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Capability>?>(
                "capabilities",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The expiration date of the card.
    /// </summary>
    public string? Expiration
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("expiration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("expiration", value);
        }
    }

    /// <summary>
    /// The last 4 digits of the card number.
    /// </summary>
    public string? Last4
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("last4");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("last4", value);
        }
    }

    /// <summary>
    /// The outcome to simulate for card push transfers using this token.
    /// </summary>
    public Outcome? Outcome
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Outcome>("outcome");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("outcome", value);
        }
    }

    /// <summary>
    /// The prefix of the card number, usually the first 8 digits.
    /// </summary>
    public string? Prefix
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("prefix");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("prefix", value);
        }
    }

    /// <summary>
    /// The total length of the card number, including prefix and last4.
    /// </summary>
    public long? PrimaryAccountNumberLength
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("primary_account_number_length");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("primary_account_number_length", value);
        }
    }

    public CardTokenCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardTokenCreateParams(CardTokenCreateParams cardTokenCreateParams)
        : base(cardTokenCreateParams)
    {
        this._rawBodyData = new(cardTokenCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CardTokenCreateParams(
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
    CardTokenCreateParams(
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
    public static CardTokenCreateParams FromRawUnchecked(
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

    public virtual bool Equals(CardTokenCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/simulations/card_tokens")
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

[JsonConverter(typeof(JsonModelConverter<Capability, CapabilityFromRaw>))]
public sealed record class Capability : JsonModel
{
    /// <summary>
    /// The cross-border push transfers capability.
    /// </summary>
    public required ApiEnum<string, CrossBorderPushTransfers> CrossBorderPushTransfers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CrossBorderPushTransfers>>(
                "cross_border_push_transfers"
            );
        }
        init { this._rawData.Set("cross_border_push_transfers", value); }
    }

    /// <summary>
    /// The domestic push transfers capability.
    /// </summary>
    public required ApiEnum<string, DomesticPushTransfers> DomesticPushTransfers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DomesticPushTransfers>>(
                "domestic_push_transfers"
            );
        }
        init { this._rawData.Set("domestic_push_transfers", value); }
    }

    /// <summary>
    /// The route of the capability.
    /// </summary>
    public required ApiEnum<string, Route> Route
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Route>>("route");
        }
        init { this._rawData.Set("route", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CrossBorderPushTransfers.Validate();
        this.DomesticPushTransfers.Validate();
        this.Route.Validate();
    }

    public Capability() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Capability(Capability capability)
        : base(capability) { }
#pragma warning restore CS8618

    public Capability(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Capability(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CapabilityFromRaw.FromRawUnchecked"/>
    public static Capability FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CapabilityFromRaw : IFromRawJson<Capability>
{
    /// <inheritdoc/>
    public Capability FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Capability.FromRawUnchecked(rawData);
}

/// <summary>
/// The cross-border push transfers capability.
/// </summary>
[JsonConverter(typeof(CrossBorderPushTransfersConverter))]
public enum CrossBorderPushTransfers
{
    /// <summary>
    /// The capability is supported.
    /// </summary>
    Supported,

    /// <summary>
    /// The capability is not supported.
    /// </summary>
    NotSupported,
}

sealed class CrossBorderPushTransfersConverter : JsonConverter<CrossBorderPushTransfers>
{
    public override CrossBorderPushTransfers Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "supported" => CrossBorderPushTransfers.Supported,
            "not_supported" => CrossBorderPushTransfers.NotSupported,
            _ => (CrossBorderPushTransfers)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CrossBorderPushTransfers value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CrossBorderPushTransfers.Supported => "supported",
                CrossBorderPushTransfers.NotSupported => "not_supported",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The domestic push transfers capability.
/// </summary>
[JsonConverter(typeof(DomesticPushTransfersConverter))]
public enum DomesticPushTransfers
{
    /// <summary>
    /// The capability is supported.
    /// </summary>
    Supported,

    /// <summary>
    /// The capability is not supported.
    /// </summary>
    NotSupported,
}

sealed class DomesticPushTransfersConverter : JsonConverter<DomesticPushTransfers>
{
    public override DomesticPushTransfers Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "supported" => DomesticPushTransfers.Supported,
            "not_supported" => DomesticPushTransfers.NotSupported,
            _ => (DomesticPushTransfers)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DomesticPushTransfers value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DomesticPushTransfers.Supported => "supported",
                DomesticPushTransfers.NotSupported => "not_supported",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The route of the capability.
/// </summary>
[JsonConverter(typeof(RouteConverter))]
public enum Route
{
    /// <summary>
    /// Visa and Interlink
    /// </summary>
    Visa,

    /// <summary>
    /// Mastercard and Maestro
    /// </summary>
    Mastercard,
}

sealed class RouteConverter : JsonConverter<Route>
{
    public override Route Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => Route.Visa,
            "mastercard" => Route.Mastercard,
            _ => (Route)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Route value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Route.Visa => "visa",
                Route.Mastercard => "mastercard",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The outcome to simulate for card push transfers using this token.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Outcome, OutcomeFromRaw>))]
public sealed record class Outcome : JsonModel
{
    /// <summary>
    /// Whether card push transfers or validations will be approved or declined.
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

    /// <summary>
    /// If the result is declined, the details of the decline.
    /// </summary>
    public Decline? Decline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Decline>("decline");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("decline", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Result.Validate();
        this.Decline?.Validate();
    }

    public Outcome() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Outcome(Outcome outcome)
        : base(outcome) { }
#pragma warning restore CS8618

    public Outcome(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Outcome(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutcomeFromRaw.FromRawUnchecked"/>
    public static Outcome FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Outcome(ApiEnum<string, Result> result)
        : this()
    {
        this.Result = result;
    }
}

class OutcomeFromRaw : IFromRawJson<Outcome>
{
    /// <inheritdoc/>
    public Outcome FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Outcome.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether card push transfers or validations will be approved or declined.
/// </summary>
[JsonConverter(typeof(ResultConverter))]
public enum Result
{
    /// <summary>
    /// Any card push transfers or validations will be approved.
    /// </summary>
    Approve,

    /// <summary>
    /// Any card push transfers or validations will be declined.
    /// </summary>
    Decline,
}

sealed class ResultConverter : JsonConverter<Result>
{
    public override Result Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approve" => Result.Approve,
            "decline" => Result.Decline,
            _ => (Result)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Result value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Result.Approve => "approve",
                Result.Decline => "decline",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If the result is declined, the details of the decline.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Decline, DeclineFromRaw>))]
public sealed record class Decline : JsonModel
{
    /// <summary>
    /// The reason for the decline.
    /// </summary>
    public ApiEnum<string, Reason>? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Reason>>("reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Reason?.Validate();
    }

    public Decline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Decline(Decline decline)
        : base(decline) { }
#pragma warning restore CS8618

    public Decline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Decline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeclineFromRaw.FromRawUnchecked"/>
    public static Decline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeclineFromRaw : IFromRawJson<Decline>
{
    /// <inheritdoc/>
    public Decline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Decline.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason for the decline.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    /// <summary>
    /// The card issuer has declined the transaction without providing a specific reason.
    /// </summary>
    DoNotHonor,

    /// <summary>
    /// The number of transactions for the card has exceeded the limit set by the issuer.
    /// </summary>
    ActivityCountLimitExceeded,

    /// <summary>
    /// The card issuer requires the cardholder to contact them for further information
    /// regarding the transaction.
    /// </summary>
    ReferToCardIssuer,

    /// <summary>
    /// The card issuer requires the cardholder to contact them due to a special condition
    /// related to the transaction.
    /// </summary>
    ReferToCardIssuerSpecialCondition,

    /// <summary>
    /// The merchant is not valid for this transaction.
    /// </summary>
    InvalidMerchant,

    /// <summary>
    /// The card should be retained by the terminal.
    /// </summary>
    PickUpCard,

    /// <summary>
    /// An error occurred during processing of the transaction.
    /// </summary>
    Error,

    /// <summary>
    /// The card should be retained by the terminal due to a special condition.
    /// </summary>
    PickUpCardSpecial,

    /// <summary>
    /// The transaction is invalid and cannot be processed.
    /// </summary>
    InvalidTransaction,

    /// <summary>
    /// The amount of the transaction is invalid.
    /// </summary>
    InvalidAmount,

    /// <summary>
    /// The account number provided is invalid.
    /// </summary>
    InvalidAccountNumber,

    /// <summary>
    /// The issuer of the card could not be found.
    /// </summary>
    NoSuchIssuer,

    /// <summary>
    /// The transaction should be re-entered for processing.
    /// </summary>
    ReEnterTransaction,

    /// <summary>
    /// There is no credit account associated with the card.
    /// </summary>
    NoCreditAccount,

    /// <summary>
    /// The card should be retained by the terminal because it has been reported lost.
    /// </summary>
    PickUpCardLost,

    /// <summary>
    /// The card should be retained by the terminal because it has been reported stolen.
    /// </summary>
    PickUpCardStolen,

    /// <summary>
    /// The account associated with the card has been closed.
    /// </summary>
    ClosedAccount,

    /// <summary>
    /// There are insufficient funds in the account to complete the transaction.
    /// </summary>
    InsufficientFunds,

    /// <summary>
    /// There is no checking account associated with the card.
    /// </summary>
    NoCheckingAccount,

    /// <summary>
    /// There is no savings account associated with the card.
    /// </summary>
    NoSavingsAccount,

    /// <summary>
    /// The card has expired and cannot be used for transactions.
    /// </summary>
    ExpiredCard,

    /// <summary>
    /// The transaction is not permitted for this cardholder.
    /// </summary>
    TransactionNotPermittedToCardholder,

    /// <summary>
    /// The transaction is not allowed at this terminal.
    /// </summary>
    TransactionNotAllowedAtTerminal,

    /// <summary>
    /// The transaction is not supported or has been blocked by the issuer.
    /// </summary>
    TransactionNotSupportedOrBlockedByIssuer,

    /// <summary>
    /// The transaction has been flagged as suspected fraud and cannot be processed.
    /// </summary>
    SuspectedFraud,

    /// <summary>
    /// The amount of activity on the card has exceeded the limit set by the issuer.
    /// </summary>
    ActivityAmountLimitExceeded,

    /// <summary>
    /// The card has restrictions that prevent it from being used for this transaction.
    /// </summary>
    RestrictedCard,

    /// <summary>
    /// A security violation has occurred, preventing the transaction from being processed.
    /// </summary>
    SecurityViolation,

    /// <summary>
    /// The transaction does not meet the anti-money laundering requirements set
    /// by the issuer.
    /// </summary>
    TransactionDoesNotFulfillAntiMoneyLaunderingRequirement,

    /// <summary>
    /// The transaction was blocked by the cardholder.
    /// </summary>
    BlockedByCardholder,

    /// <summary>
    /// The first use of the card has been blocked by the issuer.
    /// </summary>
    BlockedFirstUse,

    /// <summary>
    /// The credit issuer is currently unavailable to process the transaction.
    /// </summary>
    CreditIssuerUnavailable,

    /// <summary>
    /// The card verification value (CVV) results were negative, indicating a potential
    /// issue with the card.
    /// </summary>
    NegativeCardVerificationValueResults,

    /// <summary>
    /// The issuer of the card is currently unavailable to process the transaction.
    /// </summary>
    IssuerUnavailable,

    /// <summary>
    /// The financial institution associated with the card could not be found.
    /// </summary>
    FinancialInstitutionCannotBeFound,

    /// <summary>
    /// The transaction cannot be completed due to an unspecified reason.
    /// </summary>
    TransactionCannotBeCompleted,

    /// <summary>
    /// The transaction is a duplicate of a previous transaction and cannot be processed again.
    /// </summary>
    DuplicateTransaction,

    /// <summary>
    /// A system malfunction occurred, preventing the transaction from being processed.
    /// </summary>
    SystemMalfunction,

    /// <summary>
    /// Additional customer authentication is required to complete the transaction.
    /// </summary>
    AdditionalCustomerAuthenticationRequired,

    /// <summary>
    /// The surcharge amount applied to the transaction is not permitted by the issuer.
    /// </summary>
    SurchargeAmountNotPermitted,

    /// <summary>
    /// The transaction was declined due to a failure in verifying the CVV2 code.
    /// </summary>
    DeclineForCvv2Failure,

    /// <summary>
    /// A stop payment order has been placed on this transaction.
    /// </summary>
    StopPaymentOrder,

    /// <summary>
    /// An order has been placed to revoke authorization for this transaction.
    /// </summary>
    RevocationOfAuthorizationOrder,

    /// <summary>
    /// An order has been placed to revoke all authorizations for this cardholder.
    /// </summary>
    RevocationOfAllAuthorizationsOrder,

    /// <summary>
    /// The record associated with the transaction could not be located.
    /// </summary>
    UnableToLocateRecord,

    /// <summary>
    /// The file needed for the transaction is temporarily unavailable.
    /// </summary>
    FileIsTemporarilyUnavailable,

    /// <summary>
    /// The PIN entered for the transaction is incorrect.
    /// </summary>
    IncorrectPin,

    /// <summary>
    /// The allowable number of PIN entry tries has been exceeded.
    /// </summary>
    AllowableNumberOfPinEntryTriesExceeded,

    /// <summary>
    /// The previous message associated with the transaction could not be located.
    /// </summary>
    UnableToLocatePreviousMessage,

    /// <summary>
    /// An error was found with the PIN associated with the transaction.
    /// </summary>
    PinErrorFound,

    /// <summary>
    /// The PIN associated with the transaction could not be verified.
    /// </summary>
    CannotVerifyPin,

    /// <summary>
    /// The verification data associated with the transaction has failed.
    /// </summary>
    VerificationDataFailed,

    /// <summary>
    /// The surcharge amount is not supported by the debit network issuer.
    /// </summary>
    SurchargeAmountNotSupportedByDebitNetworkIssuer,

    /// <summary>
    /// Cash service is not available for this transaction.
    /// </summary>
    CashServiceNotAvailable,

    /// <summary>
    /// The cashback request exceeds the issuer limit.
    /// </summary>
    CashbackRequestExceedsIssuerLimit,

    /// <summary>
    /// The transaction amount exceeds the pre-authorized approval amount.
    /// </summary>
    TransactionAmountExceedsPreAuthorizedApprovalAmount,

    /// <summary>
    /// The transaction does not qualify for Visa PIN processing.
    /// </summary>
    TransactionDoesNotQualifyForVisaPin,

    /// <summary>
    /// The transaction was declined offline.
    /// </summary>
    OfflineDeclined,

    /// <summary>
    /// The terminal was unable to go online to process the transaction.
    /// </summary>
    UnableToGoOnline,

    /// <summary>
    /// The account is valid but the transaction amount is not supported.
    /// </summary>
    ValidAccountButAmountNotSupported,

    /// <summary>
    /// The merchant category code was used incorrectly; correct it and reattempt
    /// the transaction.
    /// </summary>
    InvalidUseOfMerchantCategoryCodeCorrectAndReattempt,

    /// <summary>
    /// The card authentication process has failed.
    /// </summary>
    CardAuthenticationFailed,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "do_not_honor" => Reason.DoNotHonor,
            "activity_count_limit_exceeded" => Reason.ActivityCountLimitExceeded,
            "refer_to_card_issuer" => Reason.ReferToCardIssuer,
            "refer_to_card_issuer_special_condition" => Reason.ReferToCardIssuerSpecialCondition,
            "invalid_merchant" => Reason.InvalidMerchant,
            "pick_up_card" => Reason.PickUpCard,
            "error" => Reason.Error,
            "pick_up_card_special" => Reason.PickUpCardSpecial,
            "invalid_transaction" => Reason.InvalidTransaction,
            "invalid_amount" => Reason.InvalidAmount,
            "invalid_account_number" => Reason.InvalidAccountNumber,
            "no_such_issuer" => Reason.NoSuchIssuer,
            "re_enter_transaction" => Reason.ReEnterTransaction,
            "no_credit_account" => Reason.NoCreditAccount,
            "pick_up_card_lost" => Reason.PickUpCardLost,
            "pick_up_card_stolen" => Reason.PickUpCardStolen,
            "closed_account" => Reason.ClosedAccount,
            "insufficient_funds" => Reason.InsufficientFunds,
            "no_checking_account" => Reason.NoCheckingAccount,
            "no_savings_account" => Reason.NoSavingsAccount,
            "expired_card" => Reason.ExpiredCard,
            "transaction_not_permitted_to_cardholder" => Reason.TransactionNotPermittedToCardholder,
            "transaction_not_allowed_at_terminal" => Reason.TransactionNotAllowedAtTerminal,
            "transaction_not_supported_or_blocked_by_issuer" =>
                Reason.TransactionNotSupportedOrBlockedByIssuer,
            "suspected_fraud" => Reason.SuspectedFraud,
            "activity_amount_limit_exceeded" => Reason.ActivityAmountLimitExceeded,
            "restricted_card" => Reason.RestrictedCard,
            "security_violation" => Reason.SecurityViolation,
            "transaction_does_not_fulfill_anti_money_laundering_requirement" =>
                Reason.TransactionDoesNotFulfillAntiMoneyLaunderingRequirement,
            "blocked_by_cardholder" => Reason.BlockedByCardholder,
            "blocked_first_use" => Reason.BlockedFirstUse,
            "credit_issuer_unavailable" => Reason.CreditIssuerUnavailable,
            "negative_card_verification_value_results" =>
                Reason.NegativeCardVerificationValueResults,
            "issuer_unavailable" => Reason.IssuerUnavailable,
            "financial_institution_cannot_be_found" => Reason.FinancialInstitutionCannotBeFound,
            "transaction_cannot_be_completed" => Reason.TransactionCannotBeCompleted,
            "duplicate_transaction" => Reason.DuplicateTransaction,
            "system_malfunction" => Reason.SystemMalfunction,
            "additional_customer_authentication_required" =>
                Reason.AdditionalCustomerAuthenticationRequired,
            "surcharge_amount_not_permitted" => Reason.SurchargeAmountNotPermitted,
            "decline_for_cvv2_failure" => Reason.DeclineForCvv2Failure,
            "stop_payment_order" => Reason.StopPaymentOrder,
            "revocation_of_authorization_order" => Reason.RevocationOfAuthorizationOrder,
            "revocation_of_all_authorizations_order" => Reason.RevocationOfAllAuthorizationsOrder,
            "unable_to_locate_record" => Reason.UnableToLocateRecord,
            "file_is_temporarily_unavailable" => Reason.FileIsTemporarilyUnavailable,
            "incorrect_pin" => Reason.IncorrectPin,
            "allowable_number_of_pin_entry_tries_exceeded" =>
                Reason.AllowableNumberOfPinEntryTriesExceeded,
            "unable_to_locate_previous_message" => Reason.UnableToLocatePreviousMessage,
            "pin_error_found" => Reason.PinErrorFound,
            "cannot_verify_pin" => Reason.CannotVerifyPin,
            "verification_data_failed" => Reason.VerificationDataFailed,
            "surcharge_amount_not_supported_by_debit_network_issuer" =>
                Reason.SurchargeAmountNotSupportedByDebitNetworkIssuer,
            "cash_service_not_available" => Reason.CashServiceNotAvailable,
            "cashback_request_exceeds_issuer_limit" => Reason.CashbackRequestExceedsIssuerLimit,
            "transaction_amount_exceeds_pre_authorized_approval_amount" =>
                Reason.TransactionAmountExceedsPreAuthorizedApprovalAmount,
            "transaction_does_not_qualify_for_visa_pin" =>
                Reason.TransactionDoesNotQualifyForVisaPin,
            "offline_declined" => Reason.OfflineDeclined,
            "unable_to_go_online" => Reason.UnableToGoOnline,
            "valid_account_but_amount_not_supported" => Reason.ValidAccountButAmountNotSupported,
            "invalid_use_of_merchant_category_code_correct_and_reattempt" =>
                Reason.InvalidUseOfMerchantCategoryCodeCorrectAndReattempt,
            "card_authentication_failed" => Reason.CardAuthenticationFailed,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.DoNotHonor => "do_not_honor",
                Reason.ActivityCountLimitExceeded => "activity_count_limit_exceeded",
                Reason.ReferToCardIssuer => "refer_to_card_issuer",
                Reason.ReferToCardIssuerSpecialCondition =>
                    "refer_to_card_issuer_special_condition",
                Reason.InvalidMerchant => "invalid_merchant",
                Reason.PickUpCard => "pick_up_card",
                Reason.Error => "error",
                Reason.PickUpCardSpecial => "pick_up_card_special",
                Reason.InvalidTransaction => "invalid_transaction",
                Reason.InvalidAmount => "invalid_amount",
                Reason.InvalidAccountNumber => "invalid_account_number",
                Reason.NoSuchIssuer => "no_such_issuer",
                Reason.ReEnterTransaction => "re_enter_transaction",
                Reason.NoCreditAccount => "no_credit_account",
                Reason.PickUpCardLost => "pick_up_card_lost",
                Reason.PickUpCardStolen => "pick_up_card_stolen",
                Reason.ClosedAccount => "closed_account",
                Reason.InsufficientFunds => "insufficient_funds",
                Reason.NoCheckingAccount => "no_checking_account",
                Reason.NoSavingsAccount => "no_savings_account",
                Reason.ExpiredCard => "expired_card",
                Reason.TransactionNotPermittedToCardholder =>
                    "transaction_not_permitted_to_cardholder",
                Reason.TransactionNotAllowedAtTerminal => "transaction_not_allowed_at_terminal",
                Reason.TransactionNotSupportedOrBlockedByIssuer =>
                    "transaction_not_supported_or_blocked_by_issuer",
                Reason.SuspectedFraud => "suspected_fraud",
                Reason.ActivityAmountLimitExceeded => "activity_amount_limit_exceeded",
                Reason.RestrictedCard => "restricted_card",
                Reason.SecurityViolation => "security_violation",
                Reason.TransactionDoesNotFulfillAntiMoneyLaunderingRequirement =>
                    "transaction_does_not_fulfill_anti_money_laundering_requirement",
                Reason.BlockedByCardholder => "blocked_by_cardholder",
                Reason.BlockedFirstUse => "blocked_first_use",
                Reason.CreditIssuerUnavailable => "credit_issuer_unavailable",
                Reason.NegativeCardVerificationValueResults =>
                    "negative_card_verification_value_results",
                Reason.IssuerUnavailable => "issuer_unavailable",
                Reason.FinancialInstitutionCannotBeFound => "financial_institution_cannot_be_found",
                Reason.TransactionCannotBeCompleted => "transaction_cannot_be_completed",
                Reason.DuplicateTransaction => "duplicate_transaction",
                Reason.SystemMalfunction => "system_malfunction",
                Reason.AdditionalCustomerAuthenticationRequired =>
                    "additional_customer_authentication_required",
                Reason.SurchargeAmountNotPermitted => "surcharge_amount_not_permitted",
                Reason.DeclineForCvv2Failure => "decline_for_cvv2_failure",
                Reason.StopPaymentOrder => "stop_payment_order",
                Reason.RevocationOfAuthorizationOrder => "revocation_of_authorization_order",
                Reason.RevocationOfAllAuthorizationsOrder =>
                    "revocation_of_all_authorizations_order",
                Reason.UnableToLocateRecord => "unable_to_locate_record",
                Reason.FileIsTemporarilyUnavailable => "file_is_temporarily_unavailable",
                Reason.IncorrectPin => "incorrect_pin",
                Reason.AllowableNumberOfPinEntryTriesExceeded =>
                    "allowable_number_of_pin_entry_tries_exceeded",
                Reason.UnableToLocatePreviousMessage => "unable_to_locate_previous_message",
                Reason.PinErrorFound => "pin_error_found",
                Reason.CannotVerifyPin => "cannot_verify_pin",
                Reason.VerificationDataFailed => "verification_data_failed",
                Reason.SurchargeAmountNotSupportedByDebitNetworkIssuer =>
                    "surcharge_amount_not_supported_by_debit_network_issuer",
                Reason.CashServiceNotAvailable => "cash_service_not_available",
                Reason.CashbackRequestExceedsIssuerLimit => "cashback_request_exceeds_issuer_limit",
                Reason.TransactionAmountExceedsPreAuthorizedApprovalAmount =>
                    "transaction_amount_exceeds_pre_authorized_approval_amount",
                Reason.TransactionDoesNotQualifyForVisaPin =>
                    "transaction_does_not_qualify_for_visa_pin",
                Reason.OfflineDeclined => "offline_declined",
                Reason.UnableToGoOnline => "unable_to_go_online",
                Reason.ValidAccountButAmountNotSupported =>
                    "valid_account_but_amount_not_supported",
                Reason.InvalidUseOfMerchantCategoryCodeCorrectAndReattempt =>
                    "invalid_use_of_merchant_category_code_correct_and_reattempt",
                Reason.CardAuthenticationFailed => "card_authentication_failed",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
