using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.DeclinedTransactions;

/// <summary>
/// Declined Transactions are refused additions and removals of money from your bank
/// account. For example, Declined Transactions are caused when your Account has an
/// insufficient balance or your Limits are triggered.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DeclinedTransaction, DeclinedTransactionFromRaw>))]
public sealed record class DeclinedTransaction : JsonModel
{
    /// <summary>
    /// The Declined Transaction identifier.
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
    /// The identifier for the Account the Declined Transaction belongs to.
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
    /// The Declined Transaction amount in the minor unit of its currency. For dollars,
    /// for example, this is cents.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date on which the Transaction occurred.
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the Declined
    /// Transaction's currency. This will match the currency on the Declined Transaction's Account.
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// This is the description the vendor provides.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The identifier for the route this Declined Transaction came through. Routes
    /// are things like cards and ACH details.
    /// </summary>
    public required string? RouteID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("route_id");
        }
        init { this._rawData.Set("route_id", value); }
    }

    /// <summary>
    /// The type of the route this Declined Transaction came through.
    /// </summary>
    public required ApiEnum<string, RouteType>? RouteType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RouteType>>("route_type");
        }
        init { this._rawData.Set("route_type", value); }
    }

    /// <summary>
    /// This is an object giving more details on the network-level event that caused
    /// the Declined Transaction. For example, for a card transaction this lists
    /// the merchant's industry and location. Note that for backwards compatibility
    /// reasons, additional undocumented keys may appear in this object. These should
    /// be treated as deprecated and will be removed in the future.
    /// </summary>
    public required Source Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Source>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `declined_transaction`.
    /// </summary>
    public required ApiEnum<string, DeclinedTransactionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DeclinedTransactionType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.Amount;
        _ = this.CreatedAt;
        this.Currency.Validate();
        _ = this.Description;
        _ = this.RouteID;
        this.RouteType?.Validate();
        this.Source.Validate();
        this.Type.Validate();
    }

    public DeclinedTransaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeclinedTransaction(DeclinedTransaction declinedTransaction)
        : base(declinedTransaction) { }
#pragma warning restore CS8618

    public DeclinedTransaction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeclinedTransaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeclinedTransactionFromRaw.FromRawUnchecked"/>
    public static DeclinedTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeclinedTransactionFromRaw : IFromRawJson<DeclinedTransaction>
{
    /// <inheritdoc/>
    public DeclinedTransaction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DeclinedTransaction.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the Declined Transaction's
/// currency. This will match the currency on the Declined Transaction's Account.
/// </summary>
[JsonConverter(typeof(CurrencyConverter))]
public enum Currency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CurrencyConverter : JsonConverter<Currency>
{
    public override Currency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => Currency.Usd,
            _ => (Currency)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Currency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of the route this Declined Transaction came through.
/// </summary>
[JsonConverter(typeof(RouteTypeConverter))]
public enum RouteType
{
    /// <summary>
    /// An Account Number.
    /// </summary>
    AccountNumber,

    /// <summary>
    /// A Card.
    /// </summary>
    Card,

    /// <summary>
    /// A Lockbox.
    /// </summary>
    Lockbox,
}

sealed class RouteTypeConverter : JsonConverter<RouteType>
{
    public override RouteType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_number" => RouteType.AccountNumber,
            "card" => RouteType.Card,
            "lockbox" => RouteType.Lockbox,
            _ => (RouteType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RouteType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RouteType.AccountNumber => "account_number",
                RouteType.Card => "card",
                RouteType.Lockbox => "lockbox",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// This is an object giving more details on the network-level event that caused the
/// Declined Transaction. For example, for a card transaction this lists the merchant's
/// industry and location. Note that for backwards compatibility reasons, additional
/// undocumented keys may appear in this object. These should be treated as deprecated
/// and will be removed in the future.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Source, SourceFromRaw>))]
public sealed record class Source : JsonModel
{
    /// <summary>
    /// The type of the resource. We may add additional possible values for this enum
    /// over time; your application should be able to handle such additions gracefully.
    /// </summary>
    public required ApiEnum<string, SourceCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SourceCategory>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// An ACH Decline object. This field will be present in the JSON response if
    /// and only if `category` is equal to `ach_decline`.
    /// </summary>
    public AchDecline? AchDecline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AchDecline>("ach_decline");
        }
        init { this._rawData.Set("ach_decline", value); }
    }

    /// <summary>
    /// A Card Decline object. This field will be present in the JSON response if
    /// and only if `category` is equal to `card_decline`.
    /// </summary>
    public CardDecline? CardDecline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDecline>("card_decline");
        }
        init { this._rawData.Set("card_decline", value); }
    }

    /// <summary>
    /// A Check Decline object. This field will be present in the JSON response if
    /// and only if `category` is equal to `check_decline`.
    /// </summary>
    public CheckDecline? CheckDecline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckDecline>("check_decline");
        }
        init { this._rawData.Set("check_decline", value); }
    }

    /// <summary>
    /// A Check Deposit Rejection object. This field will be present in the JSON response
    /// if and only if `category` is equal to `check_deposit_rejection`.
    /// </summary>
    public CheckDepositRejection? CheckDepositRejection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckDepositRejection>("check_deposit_rejection");
        }
        init { this._rawData.Set("check_deposit_rejection", value); }
    }

    /// <summary>
    /// An Inbound FedNow Transfer Decline object. This field will be present in
    /// the JSON response if and only if `category` is equal to `inbound_fednow_transfer_decline`.
    /// </summary>
    public InboundFednowTransferDecline? InboundFednowTransferDecline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundFednowTransferDecline>(
                "inbound_fednow_transfer_decline"
            );
        }
        init { this._rawData.Set("inbound_fednow_transfer_decline", value); }
    }

    /// <summary>
    /// An Inbound Real-Time Payments Transfer Decline object. This field will be
    /// present in the JSON response if and only if `category` is equal to `inbound_real_time_payments_transfer_decline`.
    /// </summary>
    public InboundRealTimePaymentsTransferDecline? InboundRealTimePaymentsTransferDecline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundRealTimePaymentsTransferDecline>(
                "inbound_real_time_payments_transfer_decline"
            );
        }
        init { this._rawData.Set("inbound_real_time_payments_transfer_decline", value); }
    }

    /// <summary>
    /// If the category of this Transaction source is equal to `other`, this field
    /// will contain an empty object, otherwise it will contain null.
    /// </summary>
    public Other? Other
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Other>("other");
        }
        init { this._rawData.Set("other", value); }
    }

    /// <summary>
    /// A Wire Decline object. This field will be present in the JSON response if
    /// and only if `category` is equal to `wire_decline`.
    /// </summary>
    public WireDecline? WireDecline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WireDecline>("wire_decline");
        }
        init { this._rawData.Set("wire_decline", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.AchDecline?.Validate();
        this.CardDecline?.Validate();
        this.CheckDecline?.Validate();
        this.CheckDepositRejection?.Validate();
        this.InboundFednowTransferDecline?.Validate();
        this.InboundRealTimePaymentsTransferDecline?.Validate();
        this.Other?.Validate();
        this.WireDecline?.Validate();
    }

    public Source() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Source(Source source)
        : base(source) { }
#pragma warning restore CS8618

    public Source(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Source(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SourceFromRaw.FromRawUnchecked"/>
    public static Source FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Source(ApiEnum<string, SourceCategory> category)
        : this()
    {
        this.Category = category;
    }
}

class SourceFromRaw : IFromRawJson<Source>
{
    /// <inheritdoc/>
    public Source FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Source.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the resource. We may add additional possible values for this enum
/// over time; your application should be able to handle such additions gracefully.
/// </summary>
[JsonConverter(typeof(SourceCategoryConverter))]
public enum SourceCategory
{
    /// <summary>
    /// ACH Decline: details will be under the `ach_decline` object.
    /// </summary>
    AchDecline,

    /// <summary>
    /// Card Decline: details will be under the `card_decline` object.
    /// </summary>
    CardDecline,

    /// <summary>
    /// Check Decline: details will be under the `check_decline` object.
    /// </summary>
    CheckDecline,

    /// <summary>
    /// Inbound Real-Time Payments Transfer Decline: details will be under the `inbound_real_time_payments_transfer_decline` object.
    /// </summary>
    InboundRealTimePaymentsTransferDecline,

    /// <summary>
    /// Inbound FedNow Transfer Decline: details will be under the `inbound_fednow_transfer_decline` object.
    /// </summary>
    InboundFednowTransferDecline,

    /// <summary>
    /// Wire Decline: details will be under the `wire_decline` object.
    /// </summary>
    WireDecline,

    /// <summary>
    /// Check Deposit Rejection: details will be under the `check_deposit_rejection` object.
    /// </summary>
    CheckDepositRejection,

    /// <summary>
    /// The Declined Transaction was made for an undocumented or deprecated reason.
    /// </summary>
    Other,
}

sealed class SourceCategoryConverter : JsonConverter<SourceCategory>
{
    public override SourceCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ach_decline" => SourceCategory.AchDecline,
            "card_decline" => SourceCategory.CardDecline,
            "check_decline" => SourceCategory.CheckDecline,
            "inbound_real_time_payments_transfer_decline" =>
                SourceCategory.InboundRealTimePaymentsTransferDecline,
            "inbound_fednow_transfer_decline" => SourceCategory.InboundFednowTransferDecline,
            "wire_decline" => SourceCategory.WireDecline,
            "check_deposit_rejection" => SourceCategory.CheckDepositRejection,
            "other" => SourceCategory.Other,
            _ => (SourceCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SourceCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SourceCategory.AchDecline => "ach_decline",
                SourceCategory.CardDecline => "card_decline",
                SourceCategory.CheckDecline => "check_decline",
                SourceCategory.InboundRealTimePaymentsTransferDecline =>
                    "inbound_real_time_payments_transfer_decline",
                SourceCategory.InboundFednowTransferDecline => "inbound_fednow_transfer_decline",
                SourceCategory.WireDecline => "wire_decline",
                SourceCategory.CheckDepositRejection => "check_deposit_rejection",
                SourceCategory.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An ACH Decline object. This field will be present in the JSON response if and
/// only if `category` is equal to `ach_decline`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AchDecline, AchDeclineFromRaw>))]
public sealed record class AchDecline : JsonModel
{
    /// <summary>
    /// The ACH Decline's identifier.
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
    /// The declined amount in USD cents.
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
    /// The identifier of the Inbound ACH Transfer object associated with this decline.
    /// </summary>
    public required string InboundAchTransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("inbound_ach_transfer_id");
        }
        init { this._rawData.Set("inbound_ach_transfer_id", value); }
    }

    /// <summary>
    /// The descriptive date of the transfer.
    /// </summary>
    public required string? OriginatorCompanyDescriptiveDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("originator_company_descriptive_date");
        }
        init { this._rawData.Set("originator_company_descriptive_date", value); }
    }

    /// <summary>
    /// The additional information included with the transfer.
    /// </summary>
    public required string? OriginatorCompanyDiscretionaryData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("originator_company_discretionary_data");
        }
        init { this._rawData.Set("originator_company_discretionary_data", value); }
    }

    /// <summary>
    /// The identifier of the company that initiated the transfer.
    /// </summary>
    public required string OriginatorCompanyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("originator_company_id");
        }
        init { this._rawData.Set("originator_company_id", value); }
    }

    /// <summary>
    /// The name of the company that initiated the transfer.
    /// </summary>
    public required string OriginatorCompanyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("originator_company_name");
        }
        init { this._rawData.Set("originator_company_name", value); }
    }

    /// <summary>
    /// Why the ACH transfer was declined.
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

    /// <summary>
    /// The id of the receiver of the transfer.
    /// </summary>
    public required string? ReceiverIDNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("receiver_id_number");
        }
        init { this._rawData.Set("receiver_id_number", value); }
    }

    /// <summary>
    /// The name of the receiver of the transfer.
    /// </summary>
    public required string? ReceiverName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("receiver_name");
        }
        init { this._rawData.Set("receiver_name", value); }
    }

    /// <summary>
    /// The trace number of the transfer.
    /// </summary>
    public required string TraceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("trace_number");
        }
        init { this._rawData.Set("trace_number", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `ach_decline`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.DeclinedTransactions.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.DeclinedTransactions.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.InboundAchTransferID;
        _ = this.OriginatorCompanyDescriptiveDate;
        _ = this.OriginatorCompanyDiscretionaryData;
        _ = this.OriginatorCompanyID;
        _ = this.OriginatorCompanyName;
        this.Reason.Validate();
        _ = this.ReceiverIDNumber;
        _ = this.ReceiverName;
        _ = this.TraceNumber;
        this.Type.Validate();
    }

    public AchDecline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchDecline(AchDecline achDecline)
        : base(achDecline) { }
#pragma warning restore CS8618

    public AchDecline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AchDecline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AchDeclineFromRaw.FromRawUnchecked"/>
    public static AchDecline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AchDeclineFromRaw : IFromRawJson<AchDecline>
{
    /// <inheritdoc/>
    public AchDecline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AchDecline.FromRawUnchecked(rawData);
}

/// <summary>
/// Why the ACH transfer was declined.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    /// <summary>
    /// The account number is canceled.
    /// </summary>
    AchRouteCanceled,

    /// <summary>
    /// The account number is disabled.
    /// </summary>
    AchRouteDisabled,

    /// <summary>
    /// The transaction would cause an Increase limit to be exceeded.
    /// </summary>
    BreachesLimit,

    /// <summary>
    /// The account's entity is not active.
    /// </summary>
    EntityNotActive,

    /// <summary>
    /// Your account is inactive.
    /// </summary>
    GroupLocked,

    /// <summary>
    /// The transaction is not allowed per Increase's terms.
    /// </summary>
    TransactionNotAllowed,

    /// <summary>
    /// Your integration declined this transfer via the API.
    /// </summary>
    UserInitiated,

    /// <summary>
    /// Your account contains insufficient funds.
    /// </summary>
    InsufficientFunds,

    /// <summary>
    /// The originating financial institution asked for this transfer to be returned.
    /// The receiving bank is complying with the request.
    /// </summary>
    ReturnedPerOdfiRequest,

    /// <summary>
    /// The customer no longer authorizes this transaction.
    /// </summary>
    AuthorizationRevokedByCustomer,

    /// <summary>
    /// The customer asked for the payment to be stopped.
    /// </summary>
    PaymentStopped,

    /// <summary>
    /// The customer advises that the debit was unauthorized.
    /// </summary>
    CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete,

    /// <summary>
    /// The payee is deceased.
    /// </summary>
    RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity,

    /// <summary>
    /// The account holder is deceased.
    /// </summary>
    BeneficiaryOrAccountHolderDeceased,

    /// <summary>
    /// The customer refused a credit entry.
    /// </summary>
    CreditEntryRefusedByReceiver,

    /// <summary>
    /// The account holder identified this transaction as a duplicate.
    /// </summary>
    DuplicateEntry,

    /// <summary>
    /// The corporate customer no longer authorizes this transaction.
    /// </summary>
    CorporateCustomerAdvisedNotAuthorized,
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
            "ach_route_canceled" => Reason.AchRouteCanceled,
            "ach_route_disabled" => Reason.AchRouteDisabled,
            "breaches_limit" => Reason.BreachesLimit,
            "entity_not_active" => Reason.EntityNotActive,
            "group_locked" => Reason.GroupLocked,
            "transaction_not_allowed" => Reason.TransactionNotAllowed,
            "user_initiated" => Reason.UserInitiated,
            "insufficient_funds" => Reason.InsufficientFunds,
            "returned_per_odfi_request" => Reason.ReturnedPerOdfiRequest,
            "authorization_revoked_by_customer" => Reason.AuthorizationRevokedByCustomer,
            "payment_stopped" => Reason.PaymentStopped,
            "customer_advised_unauthorized_improper_ineligible_or_incomplete" =>
                Reason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete,
            "representative_payee_deceased_or_unable_to_continue_in_that_capacity" =>
                Reason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity,
            "beneficiary_or_account_holder_deceased" => Reason.BeneficiaryOrAccountHolderDeceased,
            "credit_entry_refused_by_receiver" => Reason.CreditEntryRefusedByReceiver,
            "duplicate_entry" => Reason.DuplicateEntry,
            "corporate_customer_advised_not_authorized" =>
                Reason.CorporateCustomerAdvisedNotAuthorized,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.AchRouteCanceled => "ach_route_canceled",
                Reason.AchRouteDisabled => "ach_route_disabled",
                Reason.BreachesLimit => "breaches_limit",
                Reason.EntityNotActive => "entity_not_active",
                Reason.GroupLocked => "group_locked",
                Reason.TransactionNotAllowed => "transaction_not_allowed",
                Reason.UserInitiated => "user_initiated",
                Reason.InsufficientFunds => "insufficient_funds",
                Reason.ReturnedPerOdfiRequest => "returned_per_odfi_request",
                Reason.AuthorizationRevokedByCustomer => "authorization_revoked_by_customer",
                Reason.PaymentStopped => "payment_stopped",
                Reason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete =>
                    "customer_advised_unauthorized_improper_ineligible_or_incomplete",
                Reason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity =>
                    "representative_payee_deceased_or_unable_to_continue_in_that_capacity",
                Reason.BeneficiaryOrAccountHolderDeceased =>
                    "beneficiary_or_account_holder_deceased",
                Reason.CreditEntryRefusedByReceiver => "credit_entry_refused_by_receiver",
                Reason.DuplicateEntry => "duplicate_entry",
                Reason.CorporateCustomerAdvisedNotAuthorized =>
                    "corporate_customer_advised_not_authorized",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `ach_decline`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    AchDecline,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.DeclinedTransactions.Type>
{
    public override global::Increase.Api.Models.DeclinedTransactions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ach_decline" => global::Increase.Api.Models.DeclinedTransactions.Type.AchDecline,
            _ => (global::Increase.Api.Models.DeclinedTransactions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.DeclinedTransactions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.DeclinedTransactions.Type.AchDecline => "ach_decline",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Card Decline object. This field will be present in the JSON response if and
/// only if `category` is equal to `card_decline`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardDecline, CardDeclineFromRaw>))]
public sealed record class CardDecline : JsonModel
{
    /// <summary>
    /// The Card Decline identifier.
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
    /// Whether this authorization was approved by Increase, the card network through
    /// stand-in processing, or the user through a real-time decision.
    /// </summary>
    public required ApiEnum<string, Actioner> Actioner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Actioner>>("actioner");
        }
        init { this._rawData.Set("actioner", value); }
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
    /// The declined amount in the minor unit of the destination account currency.
    /// For dollars, for example, this is cents.
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
    /// The ID of the Card Payment this transaction belongs to.
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the destination
    /// account currency.
    /// </summary>
    public required ApiEnum<string, CardDeclineCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardDeclineCurrency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The identifier of the declined transaction created for this Card Decline.
    /// </summary>
    public required string DeclinedTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("declined_transaction_id");
        }
        init { this._rawData.Set("declined_transaction_id", value); }
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
    /// The identifier of the card authorization this request attempted to incrementally authorize.
    /// </summary>
    public required string? IncrementedCardAuthorizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("incremented_card_authorization_id");
        }
        init { this._rawData.Set("incremented_card_authorization_id", value); }
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
    /// The declined amount in the minor unit of the transaction's presentment currency.
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's
    /// presentment currency.
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
    /// The identifier of the Real-Time Decision sent to approve or decline this transaction.
    /// </summary>
    public required string? RealTimeDecisionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("real_time_decision_id");
        }
        init { this._rawData.Set("real_time_decision_id", value); }
    }

    /// <summary>
    /// This is present if a specific decline reason was given in the real-time decision.
    /// </summary>
    public required ApiEnum<string, RealTimeDecisionReason>? RealTimeDecisionReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RealTimeDecisionReason>>(
                "real_time_decision_reason"
            );
        }
        init { this._rawData.Set("real_time_decision_reason", value); }
    }

    /// <summary>
    /// Why the transaction was declined.
    /// </summary>
    public required ApiEnum<string, CardDeclineReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardDeclineReason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
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
        _ = this.ID;
        this.Actioner.Validate();
        this.AdditionalAmounts.Validate();
        _ = this.Amount;
        _ = this.CardPaymentID;
        this.Currency.Validate();
        _ = this.DeclinedTransactionID;
        _ = this.DigitalWalletTokenID;
        this.Direction.Validate();
        _ = this.IncrementedCardAuthorizationID;
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
        _ = this.PresentmentAmount;
        _ = this.PresentmentCurrency;
        this.ProcessingCategory.Validate();
        _ = this.RealTimeDecisionID;
        this.RealTimeDecisionReason?.Validate();
        this.Reason.Validate();
        _ = this.TerminalID;
        this.Verification.Validate();
    }

    public CardDecline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDecline(CardDecline cardDecline)
        : base(cardDecline) { }
#pragma warning restore CS8618

    public CardDecline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDecline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineFromRaw.FromRawUnchecked"/>
    public static CardDecline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineFromRaw : IFromRawJson<CardDecline>
{
    /// <inheritdoc/>
    public CardDecline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardDecline.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether this authorization was approved by Increase, the card network through
/// stand-in processing, or the user through a real-time decision.
/// </summary>
[JsonConverter(typeof(ActionerConverter))]
public enum Actioner
{
    /// <summary>
    /// This object was actioned by the user through a real-time decision.
    /// </summary>
    User,

    /// <summary>
    /// This object was actioned by Increase without user intervention.
    /// </summary>
    Increase,

    /// <summary>
    /// This object was actioned by the network, through stand-in processing.
    /// </summary>
    Network,
}

sealed class ActionerConverter : JsonConverter<Actioner>
{
    public override Actioner Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => Actioner.User,
            "increase" => Actioner.Increase,
            "network" => Actioner.Network,
            _ => (Actioner)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Actioner value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Actioner.User => "user",
                Actioner.Increase => "increase",
                Actioner.Network => "network",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
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
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the destination
/// account currency.
/// </summary>
[JsonConverter(typeof(CardDeclineCurrencyConverter))]
public enum CardDeclineCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardDeclineCurrencyConverter : JsonConverter<CardDeclineCurrency>
{
    public override CardDeclineCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardDeclineCurrency.Usd,
            _ => (CardDeclineCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDeclineCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDeclineCurrency.Usd => "USD",
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
/// This is present if a specific decline reason was given in the real-time decision.
/// </summary>
[JsonConverter(typeof(RealTimeDecisionReasonConverter))]
public enum RealTimeDecisionReason
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

sealed class RealTimeDecisionReasonConverter : JsonConverter<RealTimeDecisionReason>
{
    public override RealTimeDecisionReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" => RealTimeDecisionReason.InsufficientFunds,
            "transaction_never_allowed" => RealTimeDecisionReason.TransactionNeverAllowed,
            "exceeds_approval_limit" => RealTimeDecisionReason.ExceedsApprovalLimit,
            "card_temporarily_disabled" => RealTimeDecisionReason.CardTemporarilyDisabled,
            "suspected_fraud" => RealTimeDecisionReason.SuspectedFraud,
            "other" => RealTimeDecisionReason.Other,
            _ => (RealTimeDecisionReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionReason.InsufficientFunds => "insufficient_funds",
                RealTimeDecisionReason.TransactionNeverAllowed => "transaction_never_allowed",
                RealTimeDecisionReason.ExceedsApprovalLimit => "exceeds_approval_limit",
                RealTimeDecisionReason.CardTemporarilyDisabled => "card_temporarily_disabled",
                RealTimeDecisionReason.SuspectedFraud => "suspected_fraud",
                RealTimeDecisionReason.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Why the transaction was declined.
/// </summary>
[JsonConverter(typeof(CardDeclineReasonConverter))]
public enum CardDeclineReason
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

sealed class CardDeclineReasonConverter : JsonConverter<CardDeclineReason>
{
    public override CardDeclineReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_closed" => CardDeclineReason.AccountClosed,
            "card_not_active" => CardDeclineReason.CardNotActive,
            "card_canceled" => CardDeclineReason.CardCanceled,
            "physical_card_not_active" => CardDeclineReason.PhysicalCardNotActive,
            "entity_not_active" => CardDeclineReason.EntityNotActive,
            "group_locked" => CardDeclineReason.GroupLocked,
            "insufficient_funds" => CardDeclineReason.InsufficientFunds,
            "cvv2_mismatch" => CardDeclineReason.Cvv2Mismatch,
            "pin_mismatch" => CardDeclineReason.PinMismatch,
            "card_expiration_mismatch" => CardDeclineReason.CardExpirationMismatch,
            "transaction_not_allowed" => CardDeclineReason.TransactionNotAllowed,
            "breaches_limit" => CardDeclineReason.BreachesLimit,
            "webhook_declined" => CardDeclineReason.WebhookDeclined,
            "webhook_timed_out" => CardDeclineReason.WebhookTimedOut,
            "declined_by_stand_in_processing" => CardDeclineReason.DeclinedByStandInProcessing,
            "invalid_physical_card" => CardDeclineReason.InvalidPhysicalCard,
            "missing_original_authorization" => CardDeclineReason.MissingOriginalAuthorization,
            "invalid_cryptogram" => CardDeclineReason.InvalidCryptogram,
            "failed_3ds_authentication" => CardDeclineReason.Failed3dsAuthentication,
            "suspected_card_testing" => CardDeclineReason.SuspectedCardTesting,
            "suspected_fraud" => CardDeclineReason.SuspectedFraud,
            _ => (CardDeclineReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDeclineReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDeclineReason.AccountClosed => "account_closed",
                CardDeclineReason.CardNotActive => "card_not_active",
                CardDeclineReason.CardCanceled => "card_canceled",
                CardDeclineReason.PhysicalCardNotActive => "physical_card_not_active",
                CardDeclineReason.EntityNotActive => "entity_not_active",
                CardDeclineReason.GroupLocked => "group_locked",
                CardDeclineReason.InsufficientFunds => "insufficient_funds",
                CardDeclineReason.Cvv2Mismatch => "cvv2_mismatch",
                CardDeclineReason.PinMismatch => "pin_mismatch",
                CardDeclineReason.CardExpirationMismatch => "card_expiration_mismatch",
                CardDeclineReason.TransactionNotAllowed => "transaction_not_allowed",
                CardDeclineReason.BreachesLimit => "breaches_limit",
                CardDeclineReason.WebhookDeclined => "webhook_declined",
                CardDeclineReason.WebhookTimedOut => "webhook_timed_out",
                CardDeclineReason.DeclinedByStandInProcessing => "declined_by_stand_in_processing",
                CardDeclineReason.InvalidPhysicalCard => "invalid_physical_card",
                CardDeclineReason.MissingOriginalAuthorization => "missing_original_authorization",
                CardDeclineReason.InvalidCryptogram => "invalid_cryptogram",
                CardDeclineReason.Failed3dsAuthentication => "failed_3ds_authentication",
                CardDeclineReason.SuspectedCardTesting => "suspected_card_testing",
                CardDeclineReason.SuspectedFraud => "suspected_fraud",
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
    public CardVerificationCode(ApiEnum<string, Result> result)
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
[JsonConverter(typeof(ResultConverter))]
public enum Result
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
            "match" => Result.Match,
            "no_match" => Result.NoMatch,
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
                Result.Match => "match",
                Result.NoMatch => "no_match",
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
/// A Check Decline object. This field will be present in the JSON response if and
/// only if `category` is equal to `check_decline`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CheckDecline, CheckDeclineFromRaw>))]
public sealed record class CheckDecline : JsonModel
{
    /// <summary>
    /// The declined amount in USD cents.
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
    /// A computer-readable number printed on the MICR line of business checks, usually
    /// the check number. This is useful for positive pay checks, but can be unreliably
    /// transmitted by the bank of first deposit.
    /// </summary>
    public required string? AuxiliaryOnUs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("auxiliary_on_us");
        }
        init { this._rawData.Set("auxiliary_on_us", value); }
    }

    /// <summary>
    /// The identifier of the API File object containing an image of the back of
    /// the declined check.
    /// </summary>
    public required string? BackImageFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("back_image_file_id");
        }
        init { this._rawData.Set("back_image_file_id", value); }
    }

    /// <summary>
    /// The identifier of the Check Transfer object associated with this decline.
    /// </summary>
    public required string? CheckTransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("check_transfer_id");
        }
        init { this._rawData.Set("check_transfer_id", value); }
    }

    /// <summary>
    /// The identifier of the API File object containing an image of the front of
    /// the declined check.
    /// </summary>
    public required string? FrontImageFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("front_image_file_id");
        }
        init { this._rawData.Set("front_image_file_id", value); }
    }

    /// <summary>
    /// The identifier of the Inbound Check Deposit object associated with this decline.
    /// </summary>
    public required string? InboundCheckDepositID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inbound_check_deposit_id");
        }
        init { this._rawData.Set("inbound_check_deposit_id", value); }
    }

    /// <summary>
    /// Why the check was declined.
    /// </summary>
    public required ApiEnum<string, CheckDeclineReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CheckDeclineReason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.AuxiliaryOnUs;
        _ = this.BackImageFileID;
        _ = this.CheckTransferID;
        _ = this.FrontImageFileID;
        _ = this.InboundCheckDepositID;
        this.Reason.Validate();
    }

    public CheckDecline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckDecline(CheckDecline checkDecline)
        : base(checkDecline) { }
#pragma warning restore CS8618

    public CheckDecline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckDecline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckDeclineFromRaw.FromRawUnchecked"/>
    public static CheckDecline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckDeclineFromRaw : IFromRawJson<CheckDecline>
{
    /// <inheritdoc/>
    public CheckDecline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CheckDecline.FromRawUnchecked(rawData);
}

/// <summary>
/// Why the check was declined.
/// </summary>
[JsonConverter(typeof(CheckDeclineReasonConverter))]
public enum CheckDeclineReason
{
    /// <summary>
    /// The account number is disabled.
    /// </summary>
    AchRouteDisabled,

    /// <summary>
    /// The account number is canceled.
    /// </summary>
    AchRouteCanceled,

    /// <summary>
    /// The deposited check was altered or fictitious.
    /// </summary>
    AlteredOrFictitious,

    /// <summary>
    /// The transaction would cause a limit to be exceeded.
    /// </summary>
    BreachesLimit,

    /// <summary>
    /// The check was not endorsed by the payee.
    /// </summary>
    EndorsementIrregular,

    /// <summary>
    /// The account's entity is not active.
    /// </summary>
    EntityNotActive,

    /// <summary>
    /// Your account is inactive.
    /// </summary>
    GroupLocked,

    /// <summary>
    /// Your account contains insufficient funds.
    /// </summary>
    InsufficientFunds,

    /// <summary>
    /// Stop payment requested for this check.
    /// </summary>
    StopPaymentRequested,

    /// <summary>
    /// The check was a duplicate deposit.
    /// </summary>
    DuplicatePresentment,

    /// <summary>
    /// The check was not authorized.
    /// </summary>
    NotAuthorized,

    /// <summary>
    /// The amount the receiving bank is attempting to deposit does not match the
    /// amount on the check.
    /// </summary>
    AmountMismatch,

    /// <summary>
    /// The check attempting to be deposited does not belong to Increase.
    /// </summary>
    NotOurItem,

    /// <summary>
    /// The account number on the check does not exist at Increase.
    /// </summary>
    NoAccountNumberFound,

    /// <summary>
    /// The check is not readable. Please refer to the image.
    /// </summary>
    ReferToImage,

    /// <summary>
    /// The check cannot be processed. This is rare: please contact support.
    /// </summary>
    UnableToProcess,

    /// <summary>
    /// The check image is unusable.
    /// </summary>
    UnusableImage,

    /// <summary>
    /// Your integration declined this check via the API.
    /// </summary>
    UserInitiated,
}

sealed class CheckDeclineReasonConverter : JsonConverter<CheckDeclineReason>
{
    public override CheckDeclineReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ach_route_disabled" => CheckDeclineReason.AchRouteDisabled,
            "ach_route_canceled" => CheckDeclineReason.AchRouteCanceled,
            "altered_or_fictitious" => CheckDeclineReason.AlteredOrFictitious,
            "breaches_limit" => CheckDeclineReason.BreachesLimit,
            "endorsement_irregular" => CheckDeclineReason.EndorsementIrregular,
            "entity_not_active" => CheckDeclineReason.EntityNotActive,
            "group_locked" => CheckDeclineReason.GroupLocked,
            "insufficient_funds" => CheckDeclineReason.InsufficientFunds,
            "stop_payment_requested" => CheckDeclineReason.StopPaymentRequested,
            "duplicate_presentment" => CheckDeclineReason.DuplicatePresentment,
            "not_authorized" => CheckDeclineReason.NotAuthorized,
            "amount_mismatch" => CheckDeclineReason.AmountMismatch,
            "not_our_item" => CheckDeclineReason.NotOurItem,
            "no_account_number_found" => CheckDeclineReason.NoAccountNumberFound,
            "refer_to_image" => CheckDeclineReason.ReferToImage,
            "unable_to_process" => CheckDeclineReason.UnableToProcess,
            "unusable_image" => CheckDeclineReason.UnusableImage,
            "user_initiated" => CheckDeclineReason.UserInitiated,
            _ => (CheckDeclineReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckDeclineReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckDeclineReason.AchRouteDisabled => "ach_route_disabled",
                CheckDeclineReason.AchRouteCanceled => "ach_route_canceled",
                CheckDeclineReason.AlteredOrFictitious => "altered_or_fictitious",
                CheckDeclineReason.BreachesLimit => "breaches_limit",
                CheckDeclineReason.EndorsementIrregular => "endorsement_irregular",
                CheckDeclineReason.EntityNotActive => "entity_not_active",
                CheckDeclineReason.GroupLocked => "group_locked",
                CheckDeclineReason.InsufficientFunds => "insufficient_funds",
                CheckDeclineReason.StopPaymentRequested => "stop_payment_requested",
                CheckDeclineReason.DuplicatePresentment => "duplicate_presentment",
                CheckDeclineReason.NotAuthorized => "not_authorized",
                CheckDeclineReason.AmountMismatch => "amount_mismatch",
                CheckDeclineReason.NotOurItem => "not_our_item",
                CheckDeclineReason.NoAccountNumberFound => "no_account_number_found",
                CheckDeclineReason.ReferToImage => "refer_to_image",
                CheckDeclineReason.UnableToProcess => "unable_to_process",
                CheckDeclineReason.UnusableImage => "unusable_image",
                CheckDeclineReason.UserInitiated => "user_initiated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Check Deposit Rejection object. This field will be present in the JSON response
/// if and only if `category` is equal to `check_deposit_rejection`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CheckDepositRejection, CheckDepositRejectionFromRaw>))]
public sealed record class CheckDepositRejection : JsonModel
{
    /// <summary>
    /// The rejected amount in the minor unit of check's currency. For dollars, for
    /// example, this is cents.
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
    /// The identifier of the Check Deposit that was rejected.
    /// </summary>
    public required string CheckDepositID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("check_deposit_id");
        }
        init { this._rawData.Set("check_deposit_id", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the check's currency.
    /// </summary>
    public required ApiEnum<string, CheckDepositRejectionCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CheckDepositRejectionCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The identifier of the associated declined transaction.
    /// </summary>
    public required string DeclinedTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("declined_transaction_id");
        }
        init { this._rawData.Set("declined_transaction_id", value); }
    }

    /// <summary>
    /// Why the check deposit was rejected.
    /// </summary>
    public required ApiEnum<string, CheckDepositRejectionReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CheckDepositRejectionReason>>(
                "reason"
            );
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the check deposit was rejected.
    /// </summary>
    public required System::DateTimeOffset RejectedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("rejected_at");
        }
        init { this._rawData.Set("rejected_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.CheckDepositID;
        this.Currency.Validate();
        _ = this.DeclinedTransactionID;
        this.Reason.Validate();
        _ = this.RejectedAt;
    }

    public CheckDepositRejection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckDepositRejection(CheckDepositRejection checkDepositRejection)
        : base(checkDepositRejection) { }
#pragma warning restore CS8618

    public CheckDepositRejection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckDepositRejection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckDepositRejectionFromRaw.FromRawUnchecked"/>
    public static CheckDepositRejection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckDepositRejectionFromRaw : IFromRawJson<CheckDepositRejection>
{
    /// <inheritdoc/>
    public CheckDepositRejection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckDepositRejection.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the check's currency.
/// </summary>
[JsonConverter(typeof(CheckDepositRejectionCurrencyConverter))]
public enum CheckDepositRejectionCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CheckDepositRejectionCurrencyConverter : JsonConverter<CheckDepositRejectionCurrency>
{
    public override CheckDepositRejectionCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CheckDepositRejectionCurrency.Usd,
            _ => (CheckDepositRejectionCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckDepositRejectionCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckDepositRejectionCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Why the check deposit was rejected.
/// </summary>
[JsonConverter(typeof(CheckDepositRejectionReasonConverter))]
public enum CheckDepositRejectionReason
{
    /// <summary>
    /// The check's image is incomplete.
    /// </summary>
    IncompleteImage,

    /// <summary>
    /// This is a duplicate check submission.
    /// </summary>
    Duplicate,

    /// <summary>
    /// This check has poor image quality.
    /// </summary>
    PoorImageQuality,

    /// <summary>
    /// The check was deposited with the incorrect amount.
    /// </summary>
    IncorrectAmount,

    /// <summary>
    /// The check is made out to someone other than the account holder.
    /// </summary>
    IncorrectRecipient,

    /// <summary>
    /// This check was not eligible for mobile deposit.
    /// </summary>
    NotEligibleForMobileDeposit,

    /// <summary>
    /// This check is missing at least one required field.
    /// </summary>
    MissingRequiredDataElements,

    /// <summary>
    /// This check is suspected to be fraudulent.
    /// </summary>
    SuspectedFraud,

    /// <summary>
    /// This check's deposit window has expired.
    /// </summary>
    DepositWindowExpired,

    /// <summary>
    /// The check was rejected at the user's request.
    /// </summary>
    RequestedByUser,

    /// <summary>
    /// The check is not a U.S. domestic check and cannot be processed.
    /// </summary>
    International,

    /// <summary>
    /// The check was rejected for an unknown reason.
    /// </summary>
    Unknown,
}

sealed class CheckDepositRejectionReasonConverter : JsonConverter<CheckDepositRejectionReason>
{
    public override CheckDepositRejectionReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "incomplete_image" => CheckDepositRejectionReason.IncompleteImage,
            "duplicate" => CheckDepositRejectionReason.Duplicate,
            "poor_image_quality" => CheckDepositRejectionReason.PoorImageQuality,
            "incorrect_amount" => CheckDepositRejectionReason.IncorrectAmount,
            "incorrect_recipient" => CheckDepositRejectionReason.IncorrectRecipient,
            "not_eligible_for_mobile_deposit" =>
                CheckDepositRejectionReason.NotEligibleForMobileDeposit,
            "missing_required_data_elements" =>
                CheckDepositRejectionReason.MissingRequiredDataElements,
            "suspected_fraud" => CheckDepositRejectionReason.SuspectedFraud,
            "deposit_window_expired" => CheckDepositRejectionReason.DepositWindowExpired,
            "requested_by_user" => CheckDepositRejectionReason.RequestedByUser,
            "international" => CheckDepositRejectionReason.International,
            "unknown" => CheckDepositRejectionReason.Unknown,
            _ => (CheckDepositRejectionReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckDepositRejectionReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckDepositRejectionReason.IncompleteImage => "incomplete_image",
                CheckDepositRejectionReason.Duplicate => "duplicate",
                CheckDepositRejectionReason.PoorImageQuality => "poor_image_quality",
                CheckDepositRejectionReason.IncorrectAmount => "incorrect_amount",
                CheckDepositRejectionReason.IncorrectRecipient => "incorrect_recipient",
                CheckDepositRejectionReason.NotEligibleForMobileDeposit =>
                    "not_eligible_for_mobile_deposit",
                CheckDepositRejectionReason.MissingRequiredDataElements =>
                    "missing_required_data_elements",
                CheckDepositRejectionReason.SuspectedFraud => "suspected_fraud",
                CheckDepositRejectionReason.DepositWindowExpired => "deposit_window_expired",
                CheckDepositRejectionReason.RequestedByUser => "requested_by_user",
                CheckDepositRejectionReason.International => "international",
                CheckDepositRejectionReason.Unknown => "unknown",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An Inbound FedNow Transfer Decline object. This field will be present in the JSON
/// response if and only if `category` is equal to `inbound_fednow_transfer_decline`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<InboundFednowTransferDecline, InboundFednowTransferDeclineFromRaw>)
)]
public sealed record class InboundFednowTransferDecline : JsonModel
{
    /// <summary>
    /// Why the transfer was declined.
    /// </summary>
    public required ApiEnum<string, InboundFednowTransferDeclineReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, InboundFednowTransferDeclineReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The identifier of the FedNow Transfer that led to this declined transaction.
    /// </summary>
    public required string TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transfer_id");
        }
        init { this._rawData.Set("transfer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Reason.Validate();
        _ = this.TransferID;
    }

    public InboundFednowTransferDecline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundFednowTransferDecline(InboundFednowTransferDecline inboundFednowTransferDecline)
        : base(inboundFednowTransferDecline) { }
#pragma warning restore CS8618

    public InboundFednowTransferDecline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundFednowTransferDecline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundFednowTransferDeclineFromRaw.FromRawUnchecked"/>
    public static InboundFednowTransferDecline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundFednowTransferDeclineFromRaw : IFromRawJson<InboundFednowTransferDecline>
{
    /// <inheritdoc/>
    public InboundFednowTransferDecline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundFednowTransferDecline.FromRawUnchecked(rawData);
}

/// <summary>
/// Why the transfer was declined.
/// </summary>
[JsonConverter(typeof(InboundFednowTransferDeclineReasonConverter))]
public enum InboundFednowTransferDeclineReason
{
    /// <summary>
    /// The account number is canceled.
    /// </summary>
    AccountNumberCanceled,

    /// <summary>
    /// The account number is disabled.
    /// </summary>
    AccountNumberDisabled,

    /// <summary>
    /// Your account is restricted.
    /// </summary>
    AccountRestricted,

    /// <summary>
    /// Your account is inactive.
    /// </summary>
    GroupLocked,

    /// <summary>
    /// The account's entity is not active.
    /// </summary>
    EntityNotActive,

    /// <summary>
    /// Your account is not enabled to receive FedNow transfers.
    /// </summary>
    FednowNotEnabled,
}

sealed class InboundFednowTransferDeclineReasonConverter
    : JsonConverter<InboundFednowTransferDeclineReason>
{
    public override InboundFednowTransferDeclineReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_number_canceled" => InboundFednowTransferDeclineReason.AccountNumberCanceled,
            "account_number_disabled" => InboundFednowTransferDeclineReason.AccountNumberDisabled,
            "account_restricted" => InboundFednowTransferDeclineReason.AccountRestricted,
            "group_locked" => InboundFednowTransferDeclineReason.GroupLocked,
            "entity_not_active" => InboundFednowTransferDeclineReason.EntityNotActive,
            "fednow_not_enabled" => InboundFednowTransferDeclineReason.FednowNotEnabled,
            _ => (InboundFednowTransferDeclineReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundFednowTransferDeclineReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InboundFednowTransferDeclineReason.AccountNumberCanceled =>
                    "account_number_canceled",
                InboundFednowTransferDeclineReason.AccountNumberDisabled =>
                    "account_number_disabled",
                InboundFednowTransferDeclineReason.AccountRestricted => "account_restricted",
                InboundFednowTransferDeclineReason.GroupLocked => "group_locked",
                InboundFednowTransferDeclineReason.EntityNotActive => "entity_not_active",
                InboundFednowTransferDeclineReason.FednowNotEnabled => "fednow_not_enabled",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An Inbound Real-Time Payments Transfer Decline object. This field will be present
/// in the JSON response if and only if `category` is equal to `inbound_real_time_payments_transfer_decline`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InboundRealTimePaymentsTransferDecline,
        InboundRealTimePaymentsTransferDeclineFromRaw
    >)
)]
public sealed record class InboundRealTimePaymentsTransferDecline : JsonModel
{
    /// <summary>
    /// The declined amount in the minor unit of the destination account currency.
    /// For dollars, for example, this is cents.
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
    /// The name the sender of the transfer specified as the recipient of the transfer.
    /// </summary>
    public required string CreditorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creditor_name");
        }
        init { this._rawData.Set("creditor_name", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code of the declined
    /// transfer's currency. This will always be "USD" for a Real-Time Payments transfer.
    /// </summary>
    public required ApiEnum<string, InboundRealTimePaymentsTransferDeclineCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, InboundRealTimePaymentsTransferDeclineCurrency>
            >("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The account number of the account that sent the transfer.
    /// </summary>
    public required string DebtorAccountNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("debtor_account_number");
        }
        init { this._rawData.Set("debtor_account_number", value); }
    }

    /// <summary>
    /// The name provided by the sender of the transfer.
    /// </summary>
    public required string DebtorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("debtor_name");
        }
        init { this._rawData.Set("debtor_name", value); }
    }

    /// <summary>
    /// The routing number of the account that sent the transfer.
    /// </summary>
    public required string DebtorRoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("debtor_routing_number");
        }
        init { this._rawData.Set("debtor_routing_number", value); }
    }

    /// <summary>
    /// Why the transfer was declined.
    /// </summary>
    public required ApiEnum<string, InboundRealTimePaymentsTransferDeclineReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, InboundRealTimePaymentsTransferDeclineReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The Real-Time Payments network identification of the declined transfer.
    /// </summary>
    public required string TransactionIdentification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transaction_identification");
        }
        init { this._rawData.Set("transaction_identification", value); }
    }

    /// <summary>
    /// The identifier of the Real-Time Payments Transfer that led to this Transaction.
    /// </summary>
    public required string TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transfer_id");
        }
        init { this._rawData.Set("transfer_id", value); }
    }

    /// <summary>
    /// Additional information included with the transfer.
    /// </summary>
    public required string? UnstructuredRemittanceInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("unstructured_remittance_information");
        }
        init { this._rawData.Set("unstructured_remittance_information", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.CreditorName;
        this.Currency.Validate();
        _ = this.DebtorAccountNumber;
        _ = this.DebtorName;
        _ = this.DebtorRoutingNumber;
        this.Reason.Validate();
        _ = this.TransactionIdentification;
        _ = this.TransferID;
        _ = this.UnstructuredRemittanceInformation;
    }

    public InboundRealTimePaymentsTransferDecline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundRealTimePaymentsTransferDecline(
        InboundRealTimePaymentsTransferDecline inboundRealTimePaymentsTransferDecline
    )
        : base(inboundRealTimePaymentsTransferDecline) { }
#pragma warning restore CS8618

    public InboundRealTimePaymentsTransferDecline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundRealTimePaymentsTransferDecline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundRealTimePaymentsTransferDeclineFromRaw.FromRawUnchecked"/>
    public static InboundRealTimePaymentsTransferDecline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundRealTimePaymentsTransferDeclineFromRaw
    : IFromRawJson<InboundRealTimePaymentsTransferDecline>
{
    /// <inheritdoc/>
    public InboundRealTimePaymentsTransferDecline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundRealTimePaymentsTransferDecline.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code of the declined transfer's
/// currency. This will always be "USD" for a Real-Time Payments transfer.
/// </summary>
[JsonConverter(typeof(InboundRealTimePaymentsTransferDeclineCurrencyConverter))]
public enum InboundRealTimePaymentsTransferDeclineCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class InboundRealTimePaymentsTransferDeclineCurrencyConverter
    : JsonConverter<InboundRealTimePaymentsTransferDeclineCurrency>
{
    public override InboundRealTimePaymentsTransferDeclineCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => InboundRealTimePaymentsTransferDeclineCurrency.Usd,
            _ => (InboundRealTimePaymentsTransferDeclineCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundRealTimePaymentsTransferDeclineCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InboundRealTimePaymentsTransferDeclineCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Why the transfer was declined.
/// </summary>
[JsonConverter(typeof(InboundRealTimePaymentsTransferDeclineReasonConverter))]
public enum InboundRealTimePaymentsTransferDeclineReason
{
    /// <summary>
    /// The account number is canceled.
    /// </summary>
    AccountNumberCanceled,

    /// <summary>
    /// The account number is disabled.
    /// </summary>
    AccountNumberDisabled,

    /// <summary>
    /// Your account is restricted.
    /// </summary>
    AccountRestricted,

    /// <summary>
    /// Your account is inactive.
    /// </summary>
    GroupLocked,

    /// <summary>
    /// The account's entity is not active.
    /// </summary>
    EntityNotActive,

    /// <summary>
    /// Your account is not enabled to receive Real-Time Payments transfers.
    /// </summary>
    RealTimePaymentsNotEnabled,
}

sealed class InboundRealTimePaymentsTransferDeclineReasonConverter
    : JsonConverter<InboundRealTimePaymentsTransferDeclineReason>
{
    public override InboundRealTimePaymentsTransferDeclineReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_number_canceled" =>
                InboundRealTimePaymentsTransferDeclineReason.AccountNumberCanceled,
            "account_number_disabled" =>
                InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled,
            "account_restricted" => InboundRealTimePaymentsTransferDeclineReason.AccountRestricted,
            "group_locked" => InboundRealTimePaymentsTransferDeclineReason.GroupLocked,
            "entity_not_active" => InboundRealTimePaymentsTransferDeclineReason.EntityNotActive,
            "real_time_payments_not_enabled" =>
                InboundRealTimePaymentsTransferDeclineReason.RealTimePaymentsNotEnabled,
            _ => (InboundRealTimePaymentsTransferDeclineReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundRealTimePaymentsTransferDeclineReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InboundRealTimePaymentsTransferDeclineReason.AccountNumberCanceled =>
                    "account_number_canceled",
                InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled =>
                    "account_number_disabled",
                InboundRealTimePaymentsTransferDeclineReason.AccountRestricted =>
                    "account_restricted",
                InboundRealTimePaymentsTransferDeclineReason.GroupLocked => "group_locked",
                InboundRealTimePaymentsTransferDeclineReason.EntityNotActive => "entity_not_active",
                InboundRealTimePaymentsTransferDeclineReason.RealTimePaymentsNotEnabled =>
                    "real_time_payments_not_enabled",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If the category of this Transaction source is equal to `other`, this field will
/// contain an empty object, otherwise it will contain null.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Other, OtherFromRaw>))]
public sealed record class Other : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public Other() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Other(Other other)
        : base(other) { }
#pragma warning restore CS8618

    public Other(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Other(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OtherFromRaw.FromRawUnchecked"/>
    public static Other FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OtherFromRaw : IFromRawJson<Other>
{
    /// <inheritdoc/>
    public Other FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Other.FromRawUnchecked(rawData);
}

/// <summary>
/// A Wire Decline object. This field will be present in the JSON response if and
/// only if `category` is equal to `wire_decline`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WireDecline, WireDeclineFromRaw>))]
public sealed record class WireDecline : JsonModel
{
    /// <summary>
    /// The identifier of the Inbound Wire Transfer that was declined.
    /// </summary>
    public required string InboundWireTransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("inbound_wire_transfer_id");
        }
        init { this._rawData.Set("inbound_wire_transfer_id", value); }
    }

    /// <summary>
    /// Why the wire transfer was declined.
    /// </summary>
    public required ApiEnum<string, WireDeclineReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WireDeclineReason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InboundWireTransferID;
        this.Reason.Validate();
    }

    public WireDecline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireDecline(WireDecline wireDecline)
        : base(wireDecline) { }
#pragma warning restore CS8618

    public WireDecline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireDecline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireDeclineFromRaw.FromRawUnchecked"/>
    public static WireDecline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WireDeclineFromRaw : IFromRawJson<WireDecline>
{
    /// <inheritdoc/>
    public WireDecline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WireDecline.FromRawUnchecked(rawData);
}

/// <summary>
/// Why the wire transfer was declined.
/// </summary>
[JsonConverter(typeof(WireDeclineReasonConverter))]
public enum WireDeclineReason
{
    /// <summary>
    /// The account number is canceled.
    /// </summary>
    AccountNumberCanceled,

    /// <summary>
    /// The account number is disabled.
    /// </summary>
    AccountNumberDisabled,

    /// <summary>
    /// The account's entity is not active.
    /// </summary>
    EntityNotActive,

    /// <summary>
    /// Your account is inactive.
    /// </summary>
    GroupLocked,

    /// <summary>
    /// The beneficiary account number does not exist.
    /// </summary>
    NoAccountNumber,

    /// <summary>
    /// The transaction is not allowed per Increase's terms.
    /// </summary>
    TransactionNotAllowed,
}

sealed class WireDeclineReasonConverter : JsonConverter<WireDeclineReason>
{
    public override WireDeclineReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_number_canceled" => WireDeclineReason.AccountNumberCanceled,
            "account_number_disabled" => WireDeclineReason.AccountNumberDisabled,
            "entity_not_active" => WireDeclineReason.EntityNotActive,
            "group_locked" => WireDeclineReason.GroupLocked,
            "no_account_number" => WireDeclineReason.NoAccountNumber,
            "transaction_not_allowed" => WireDeclineReason.TransactionNotAllowed,
            _ => (WireDeclineReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WireDeclineReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WireDeclineReason.AccountNumberCanceled => "account_number_canceled",
                WireDeclineReason.AccountNumberDisabled => "account_number_disabled",
                WireDeclineReason.EntityNotActive => "entity_not_active",
                WireDeclineReason.GroupLocked => "group_locked",
                WireDeclineReason.NoAccountNumber => "no_account_number",
                WireDeclineReason.TransactionNotAllowed => "transaction_not_allowed",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `declined_transaction`.
/// </summary>
[JsonConverter(typeof(DeclinedTransactionTypeConverter))]
public enum DeclinedTransactionType
{
    DeclinedTransaction,
}

sealed class DeclinedTransactionTypeConverter : JsonConverter<DeclinedTransactionType>
{
    public override DeclinedTransactionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "declined_transaction" => DeclinedTransactionType.DeclinedTransaction,
            _ => (DeclinedTransactionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeclinedTransactionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DeclinedTransactionType.DeclinedTransaction => "declined_transaction",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
