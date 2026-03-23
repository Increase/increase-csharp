using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.InboundAchTransfers;

/// <summary>
/// An Inbound ACH Transfer is an ACH transfer initiated outside of Increase to your account.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InboundAchTransfer, InboundAchTransferFromRaw>))]
public sealed record class InboundAchTransfer : JsonModel
{
    /// <summary>
    /// The inbound ACH transfer's identifier.
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
    /// If your transfer is accepted, this will contain details of the acceptance.
    /// </summary>
    public required Acceptance? Acceptance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Acceptance>("acceptance");
        }
        init { this._rawData.Set("acceptance", value); }
    }

    /// <summary>
    /// The Account to which the transfer belongs.
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
    /// The identifier of the Account Number to which this transfer was sent.
    /// </summary>
    public required string AccountNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_number_id");
        }
        init { this._rawData.Set("account_number_id", value); }
    }

    /// <summary>
    /// Additional information sent from the originator.
    /// </summary>
    public required Addenda? Addenda
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Addenda>("addenda");
        }
        init { this._rawData.Set("addenda", value); }
    }

    /// <summary>
    /// The transfer amount in USD cents.
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
    /// The time at which the transfer will be automatically resolved.
    /// </summary>
    public required System::DateTimeOffset AutomaticallyResolvesAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "automatically_resolves_at"
            );
        }
        init { this._rawData.Set("automatically_resolves_at", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the inbound ACH transfer was created.
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
    /// If your transfer is declined, this will contain details of the decline.
    /// </summary>
    public required Decline? Decline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Decline>("decline");
        }
        init { this._rawData.Set("decline", value); }
    }

    /// <summary>
    /// The direction of the transfer.
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
    /// The effective date of the transfer. This is sent by the sending bank and
    /// is a factor in determining funds availability.
    /// </summary>
    public required string EffectiveDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("effective_date");
        }
        init { this._rawData.Set("effective_date", value); }
    }

    /// <summary>
    /// If the Inbound ACH Transfer has a Standard Entry Class Code of IAT, this
    /// will contain fields pertaining to the International ACH Transaction.
    /// </summary>
    public required InternationalAddenda? InternationalAddenda
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InternationalAddenda>("international_addenda");
        }
        init { this._rawData.Set("international_addenda", value); }
    }

    /// <summary>
    /// If you initiate a notification of change in response to the transfer, this
    /// will contain its details.
    /// </summary>
    public required NotificationOfChange? NotificationOfChange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NotificationOfChange>("notification_of_change");
        }
        init { this._rawData.Set("notification_of_change", value); }
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
    /// The description of the transfer.
    /// </summary>
    public required string OriginatorCompanyEntryDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("originator_company_entry_description");
        }
        init { this._rawData.Set("originator_company_entry_description", value); }
    }

    /// <summary>
    /// The id of the company that initiated the transfer.
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
    /// The American Banking Association (ABA) routing number of the bank originating
    /// the transfer.
    /// </summary>
    public required string OriginatorRoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("originator_routing_number");
        }
        init { this._rawData.Set("originator_routing_number", value); }
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
    /// A subhash containing information about when and how the transfer settled at
    /// the Federal Reserve.
    /// </summary>
    public required Settlement Settlement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Settlement>("settlement");
        }
        init { this._rawData.Set("settlement", value); }
    }

    /// <summary>
    /// The Standard Entry Class (SEC) code of the transfer.
    /// </summary>
    public required ApiEnum<string, StandardEntryClassCode> StandardEntryClassCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, StandardEntryClassCode>>(
                "standard_entry_class_code"
            );
        }
        init { this._rawData.Set("standard_entry_class_code", value); }
    }

    /// <summary>
    /// The status of the transfer.
    /// </summary>
    public required ApiEnum<string, InboundAchTransferStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InboundAchTransferStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A 15 digit number set by the sending bank and transmitted to the receiving
    /// bank. Along with the amount, date, and originating routing number, this can
    /// be used to identify the ACH transfer. ACH trace numbers are not unique, but
    /// are [used to correlate returns](https://increase.com/documentation/ach-returns#ach-returns).
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
    /// If your transfer is returned, this will contain details of the return.
    /// </summary>
    public required TransferReturn? TransferReturn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TransferReturn>("transfer_return");
        }
        init { this._rawData.Set("transfer_return", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `inbound_ach_transfer`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.InboundAchTransfers.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.InboundAchTransfers.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Acceptance?.Validate();
        _ = this.AccountID;
        _ = this.AccountNumberID;
        this.Addenda?.Validate();
        _ = this.Amount;
        _ = this.AutomaticallyResolvesAt;
        _ = this.CreatedAt;
        this.Decline?.Validate();
        this.Direction.Validate();
        _ = this.EffectiveDate;
        this.InternationalAddenda?.Validate();
        this.NotificationOfChange?.Validate();
        _ = this.OriginatorCompanyDescriptiveDate;
        _ = this.OriginatorCompanyDiscretionaryData;
        _ = this.OriginatorCompanyEntryDescription;
        _ = this.OriginatorCompanyID;
        _ = this.OriginatorCompanyName;
        _ = this.OriginatorRoutingNumber;
        _ = this.ReceiverIDNumber;
        _ = this.ReceiverName;
        this.Settlement.Validate();
        this.StandardEntryClassCode.Validate();
        this.Status.Validate();
        _ = this.TraceNumber;
        this.TransferReturn?.Validate();
        this.Type.Validate();
    }

    public InboundAchTransfer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundAchTransfer(InboundAchTransfer inboundAchTransfer)
        : base(inboundAchTransfer) { }
#pragma warning restore CS8618

    public InboundAchTransfer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundAchTransfer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundAchTransferFromRaw.FromRawUnchecked"/>
    public static InboundAchTransfer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundAchTransferFromRaw : IFromRawJson<InboundAchTransfer>
{
    /// <inheritdoc/>
    public InboundAchTransfer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InboundAchTransfer.FromRawUnchecked(rawData);
}

/// <summary>
/// If your transfer is accepted, this will contain details of the acceptance.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Acceptance, AcceptanceFromRaw>))]
public sealed record class Acceptance : JsonModel
{
    /// <summary>
    /// The time at which the transfer was accepted.
    /// </summary>
    public required System::DateTimeOffset AcceptedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("accepted_at");
        }
        init { this._rawData.Set("accepted_at", value); }
    }

    /// <summary>
    /// The id of the transaction for the accepted transfer.
    /// </summary>
    public required string TransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transaction_id");
        }
        init { this._rawData.Set("transaction_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcceptedAt;
        _ = this.TransactionID;
    }

    public Acceptance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Acceptance(Acceptance acceptance)
        : base(acceptance) { }
#pragma warning restore CS8618

    public Acceptance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Acceptance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AcceptanceFromRaw.FromRawUnchecked"/>
    public static Acceptance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AcceptanceFromRaw : IFromRawJson<Acceptance>
{
    /// <inheritdoc/>
    public Acceptance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Acceptance.FromRawUnchecked(rawData);
}

/// <summary>
/// Additional information sent from the originator.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Addenda, AddendaFromRaw>))]
public sealed record class Addenda : JsonModel
{
    /// <summary>
    /// The type of addendum.
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
    /// Unstructured `payment_related_information` passed through by the originator.
    /// </summary>
    public required Freeform? Freeform
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Freeform>("freeform");
        }
        init { this._rawData.Set("freeform", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.Freeform?.Validate();
    }

    public Addenda() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Addenda(Addenda addenda)
        : base(addenda) { }
#pragma warning restore CS8618

    public Addenda(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Addenda(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddendaFromRaw.FromRawUnchecked"/>
    public static Addenda FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddendaFromRaw : IFromRawJson<Addenda>
{
    /// <inheritdoc/>
    public Addenda FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Addenda.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of addendum.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    /// <summary>
    /// Unstructured addendum.
    /// </summary>
    Freeform,
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
            "freeform" => Category.Freeform,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.Freeform => "freeform",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Unstructured `payment_related_information` passed through by the originator.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Freeform, FreeformFromRaw>))]
public sealed record class Freeform : JsonModel
{
    /// <summary>
    /// Each entry represents an addendum received from the originator.
    /// </summary>
    public required IReadOnlyList<Entry> Entries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Entry>>("entries");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Entry>>(
                "entries",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Entries)
        {
            item.Validate();
        }
    }

    public Freeform() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Freeform(Freeform freeform)
        : base(freeform) { }
#pragma warning restore CS8618

    public Freeform(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Freeform(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FreeformFromRaw.FromRawUnchecked"/>
    public static Freeform FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Freeform(IReadOnlyList<Entry> entries)
        : this()
    {
        this.Entries = entries;
    }
}

class FreeformFromRaw : IFromRawJson<Freeform>
{
    /// <inheritdoc/>
    public Freeform FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Freeform.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Entry, EntryFromRaw>))]
public sealed record class Entry : JsonModel
{
    /// <summary>
    /// The payment related information passed in the addendum.
    /// </summary>
    public required string PaymentRelatedInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("payment_related_information");
        }
        init { this._rawData.Set("payment_related_information", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PaymentRelatedInformation;
    }

    public Entry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Entry(Entry entry)
        : base(entry) { }
#pragma warning restore CS8618

    public Entry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Entry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntryFromRaw.FromRawUnchecked"/>
    public static Entry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Entry(string paymentRelatedInformation)
        : this()
    {
        this.PaymentRelatedInformation = paymentRelatedInformation;
    }
}

class EntryFromRaw : IFromRawJson<Entry>
{
    /// <inheritdoc/>
    public Entry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Entry.FromRawUnchecked(rawData);
}

/// <summary>
/// If your transfer is declined, this will contain details of the decline.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Decline, DeclineFromRaw>))]
public sealed record class Decline : JsonModel
{
    /// <summary>
    /// The time at which the transfer was declined.
    /// </summary>
    public required System::DateTimeOffset DeclinedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("declined_at");
        }
        init { this._rawData.Set("declined_at", value); }
    }

    /// <summary>
    /// The id of the transaction for the declined transfer.
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
    /// The reason for the transfer decline.
    /// </summary>
    public required ApiEnum<string, DeclineReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DeclineReason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DeclinedAt;
        _ = this.DeclinedTransactionID;
        this.Reason.Validate();
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
/// The reason for the transfer decline.
/// </summary>
[JsonConverter(typeof(DeclineReasonConverter))]
public enum DeclineReason
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
            "ach_route_canceled" => DeclineReason.AchRouteCanceled,
            "ach_route_disabled" => DeclineReason.AchRouteDisabled,
            "breaches_limit" => DeclineReason.BreachesLimit,
            "entity_not_active" => DeclineReason.EntityNotActive,
            "group_locked" => DeclineReason.GroupLocked,
            "transaction_not_allowed" => DeclineReason.TransactionNotAllowed,
            "user_initiated" => DeclineReason.UserInitiated,
            "insufficient_funds" => DeclineReason.InsufficientFunds,
            "returned_per_odfi_request" => DeclineReason.ReturnedPerOdfiRequest,
            "authorization_revoked_by_customer" => DeclineReason.AuthorizationRevokedByCustomer,
            "payment_stopped" => DeclineReason.PaymentStopped,
            "customer_advised_unauthorized_improper_ineligible_or_incomplete" =>
                DeclineReason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete,
            "representative_payee_deceased_or_unable_to_continue_in_that_capacity" =>
                DeclineReason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity,
            "beneficiary_or_account_holder_deceased" =>
                DeclineReason.BeneficiaryOrAccountHolderDeceased,
            "credit_entry_refused_by_receiver" => DeclineReason.CreditEntryRefusedByReceiver,
            "duplicate_entry" => DeclineReason.DuplicateEntry,
            "corporate_customer_advised_not_authorized" =>
                DeclineReason.CorporateCustomerAdvisedNotAuthorized,
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
                DeclineReason.AchRouteCanceled => "ach_route_canceled",
                DeclineReason.AchRouteDisabled => "ach_route_disabled",
                DeclineReason.BreachesLimit => "breaches_limit",
                DeclineReason.EntityNotActive => "entity_not_active",
                DeclineReason.GroupLocked => "group_locked",
                DeclineReason.TransactionNotAllowed => "transaction_not_allowed",
                DeclineReason.UserInitiated => "user_initiated",
                DeclineReason.InsufficientFunds => "insufficient_funds",
                DeclineReason.ReturnedPerOdfiRequest => "returned_per_odfi_request",
                DeclineReason.AuthorizationRevokedByCustomer => "authorization_revoked_by_customer",
                DeclineReason.PaymentStopped => "payment_stopped",
                DeclineReason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete =>
                    "customer_advised_unauthorized_improper_ineligible_or_incomplete",
                DeclineReason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity =>
                    "representative_payee_deceased_or_unable_to_continue_in_that_capacity",
                DeclineReason.BeneficiaryOrAccountHolderDeceased =>
                    "beneficiary_or_account_holder_deceased",
                DeclineReason.CreditEntryRefusedByReceiver => "credit_entry_refused_by_receiver",
                DeclineReason.DuplicateEntry => "duplicate_entry",
                DeclineReason.CorporateCustomerAdvisedNotAuthorized =>
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
/// The direction of the transfer.
/// </summary>
[JsonConverter(typeof(DirectionConverter))]
public enum Direction
{
    /// <summary>
    /// Credit
    /// </summary>
    Credit,

    /// <summary>
    /// Debit
    /// </summary>
    Debit,
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
            "credit" => Direction.Credit,
            "debit" => Direction.Debit,
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
                Direction.Credit => "credit",
                Direction.Debit => "debit",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If the Inbound ACH Transfer has a Standard Entry Class Code of IAT, this will
/// contain fields pertaining to the International ACH Transaction.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InternationalAddenda, InternationalAddendaFromRaw>))]
public sealed record class InternationalAddenda : JsonModel
{
    /// <summary>
    /// The [ISO 3166](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2), Alpha-2
    /// country code of the destination country.
    /// </summary>
    public required string DestinationCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("destination_country_code");
        }
        init { this._rawData.Set("destination_country_code", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) currency code for
    /// the destination bank account.
    /// </summary>
    public required string DestinationCurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("destination_currency_code");
        }
        init { this._rawData.Set("destination_currency_code", value); }
    }

    /// <summary>
    /// A description of how the foreign exchange rate was calculated.
    /// </summary>
    public required ApiEnum<string, ForeignExchangeIndicator> ForeignExchangeIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ForeignExchangeIndicator>>(
                "foreign_exchange_indicator"
            );
        }
        init { this._rawData.Set("foreign_exchange_indicator", value); }
    }

    /// <summary>
    /// Depending on the `foreign_exchange_reference_indicator`, an exchange rate
    /// or a reference to a well-known rate.
    /// </summary>
    public required string? ForeignExchangeReference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("foreign_exchange_reference");
        }
        init { this._rawData.Set("foreign_exchange_reference", value); }
    }

    /// <summary>
    /// An instruction of how to interpret the `foreign_exchange_reference` field
    /// for this Transaction.
    /// </summary>
    public required ApiEnum<
        string,
        ForeignExchangeReferenceIndicator
    > ForeignExchangeReferenceIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ForeignExchangeReferenceIndicator>
            >("foreign_exchange_reference_indicator");
        }
        init { this._rawData.Set("foreign_exchange_reference_indicator", value); }
    }

    /// <summary>
    /// The amount in the minor unit of the foreign payment currency. For dollars,
    /// for example, this is cents.
    /// </summary>
    public required long ForeignPaymentAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("foreign_payment_amount");
        }
        init { this._rawData.Set("foreign_payment_amount", value); }
    }

    /// <summary>
    /// A reference number in the foreign banking infrastructure.
    /// </summary>
    public required string? ForeignTraceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("foreign_trace_number");
        }
        init { this._rawData.Set("foreign_trace_number", value); }
    }

    /// <summary>
    /// The type of transfer. Set by the originator.
    /// </summary>
    public required ApiEnum<
        string,
        InternationalTransactionTypeCode
    > InternationalTransactionTypeCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InternationalTransactionTypeCode>>(
                "international_transaction_type_code"
            );
        }
        init { this._rawData.Set("international_transaction_type_code", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) currency code for
    /// the originating bank account.
    /// </summary>
    public required string OriginatingCurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("originating_currency_code");
        }
        init { this._rawData.Set("originating_currency_code", value); }
    }

    /// <summary>
    /// The [ISO 3166](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2), Alpha-2
    /// country code of the originating branch country.
    /// </summary>
    public required string OriginatingDepositoryFinancialInstitutionBranchCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "originating_depository_financial_institution_branch_country"
            );
        }
        init
        {
            this._rawData.Set("originating_depository_financial_institution_branch_country", value);
        }
    }

    /// <summary>
    /// An identifier for the originating bank. One of an International Bank Account
    /// Number (IBAN) bank identifier, SWIFT Bank Identification Code (BIC), or a
    /// domestic identifier like a US Routing Number.
    /// </summary>
    public required string OriginatingDepositoryFinancialInstitutionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "originating_depository_financial_institution_id"
            );
        }
        init { this._rawData.Set("originating_depository_financial_institution_id", value); }
    }

    /// <summary>
    /// An instruction of how to interpret the `originating_depository_financial_institution_id`
    /// field for this Transaction.
    /// </summary>
    public required ApiEnum<
        string,
        OriginatingDepositoryFinancialInstitutionIDQualifier
    > OriginatingDepositoryFinancialInstitutionIDQualifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, OriginatingDepositoryFinancialInstitutionIDQualifier>
            >("originating_depository_financial_institution_id_qualifier");
        }
        init
        {
            this._rawData.Set("originating_depository_financial_institution_id_qualifier", value);
        }
    }

    /// <summary>
    /// The name of the originating bank. Sometimes this will refer to an American
    /// bank and obscure the correspondent foreign bank.
    /// </summary>
    public required string OriginatingDepositoryFinancialInstitutionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "originating_depository_financial_institution_name"
            );
        }
        init { this._rawData.Set("originating_depository_financial_institution_name", value); }
    }

    /// <summary>
    /// A portion of the originator address. This may be incomplete.
    /// </summary>
    public required string OriginatorCity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("originator_city");
        }
        init { this._rawData.Set("originator_city", value); }
    }

    /// <summary>
    /// A portion of the originator address. The [ISO 3166](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2),
    /// Alpha-2 country code of the originator country.
    /// </summary>
    public required string OriginatorCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("originator_country");
        }
        init { this._rawData.Set("originator_country", value); }
    }

    /// <summary>
    /// An identifier for the originating company. This is generally stable across
    /// multiple ACH transfers.
    /// </summary>
    public required string OriginatorIdentification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("originator_identification");
        }
        init { this._rawData.Set("originator_identification", value); }
    }

    /// <summary>
    /// Either the name of the originator or an intermediary money transmitter.
    /// </summary>
    public required string OriginatorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("originator_name");
        }
        init { this._rawData.Set("originator_name", value); }
    }

    /// <summary>
    /// A portion of the originator address. This may be incomplete.
    /// </summary>
    public required string? OriginatorPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("originator_postal_code");
        }
        init { this._rawData.Set("originator_postal_code", value); }
    }

    /// <summary>
    /// A portion of the originator address. This may be incomplete.
    /// </summary>
    public required string? OriginatorStateOrProvince
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("originator_state_or_province");
        }
        init { this._rawData.Set("originator_state_or_province", value); }
    }

    /// <summary>
    /// A portion of the originator address. This may be incomplete.
    /// </summary>
    public required string OriginatorStreetAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("originator_street_address");
        }
        init { this._rawData.Set("originator_street_address", value); }
    }

    /// <summary>
    /// A description field set by the originator.
    /// </summary>
    public required string? PaymentRelatedInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_related_information");
        }
        init { this._rawData.Set("payment_related_information", value); }
    }

    /// <summary>
    /// A description field set by the originator.
    /// </summary>
    public required string? PaymentRelatedInformation2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_related_information2");
        }
        init { this._rawData.Set("payment_related_information2", value); }
    }

    /// <summary>
    /// A portion of the receiver address. This may be incomplete.
    /// </summary>
    public required string ReceiverCity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("receiver_city");
        }
        init { this._rawData.Set("receiver_city", value); }
    }

    /// <summary>
    /// A portion of the receiver address. The [ISO 3166](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2),
    /// Alpha-2 country code of the receiver country.
    /// </summary>
    public required string ReceiverCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("receiver_country");
        }
        init { this._rawData.Set("receiver_country", value); }
    }

    /// <summary>
    /// An identification number the originator uses for the receiver.
    /// </summary>
    public required string? ReceiverIdentificationNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("receiver_identification_number");
        }
        init { this._rawData.Set("receiver_identification_number", value); }
    }

    /// <summary>
    /// A portion of the receiver address. This may be incomplete.
    /// </summary>
    public required string? ReceiverPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("receiver_postal_code");
        }
        init { this._rawData.Set("receiver_postal_code", value); }
    }

    /// <summary>
    /// A portion of the receiver address. This may be incomplete.
    /// </summary>
    public required string? ReceiverStateOrProvince
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("receiver_state_or_province");
        }
        init { this._rawData.Set("receiver_state_or_province", value); }
    }

    /// <summary>
    /// A portion of the receiver address. This may be incomplete.
    /// </summary>
    public required string ReceiverStreetAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("receiver_street_address");
        }
        init { this._rawData.Set("receiver_street_address", value); }
    }

    /// <summary>
    /// The name of the receiver of the transfer. This is not verified by Increase.
    /// </summary>
    public required string ReceivingCompanyOrIndividualName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("receiving_company_or_individual_name");
        }
        init { this._rawData.Set("receiving_company_or_individual_name", value); }
    }

    /// <summary>
    /// The [ISO 3166](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2), Alpha-2
    /// country code of the receiving bank country.
    /// </summary>
    public required string ReceivingDepositoryFinancialInstitutionCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "receiving_depository_financial_institution_country"
            );
        }
        init { this._rawData.Set("receiving_depository_financial_institution_country", value); }
    }

    /// <summary>
    /// An identifier for the receiving bank. One of an International Bank Account
    /// Number (IBAN) bank identifier, SWIFT Bank Identification Code (BIC), or a
    /// domestic identifier like a US Routing Number.
    /// </summary>
    public required string ReceivingDepositoryFinancialInstitutionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "receiving_depository_financial_institution_id"
            );
        }
        init { this._rawData.Set("receiving_depository_financial_institution_id", value); }
    }

    /// <summary>
    /// An instruction of how to interpret the `receiving_depository_financial_institution_id`
    /// field for this Transaction.
    /// </summary>
    public required ApiEnum<
        string,
        ReceivingDepositoryFinancialInstitutionIDQualifier
    > ReceivingDepositoryFinancialInstitutionIDQualifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ReceivingDepositoryFinancialInstitutionIDQualifier>
            >("receiving_depository_financial_institution_id_qualifier");
        }
        init
        {
            this._rawData.Set("receiving_depository_financial_institution_id_qualifier", value);
        }
    }

    /// <summary>
    /// The name of the receiving bank, as set by the sending financial institution.
    /// </summary>
    public required string ReceivingDepositoryFinancialInstitutionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "receiving_depository_financial_institution_name"
            );
        }
        init { this._rawData.Set("receiving_depository_financial_institution_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DestinationCountryCode;
        _ = this.DestinationCurrencyCode;
        this.ForeignExchangeIndicator.Validate();
        _ = this.ForeignExchangeReference;
        this.ForeignExchangeReferenceIndicator.Validate();
        _ = this.ForeignPaymentAmount;
        _ = this.ForeignTraceNumber;
        this.InternationalTransactionTypeCode.Validate();
        _ = this.OriginatingCurrencyCode;
        _ = this.OriginatingDepositoryFinancialInstitutionBranchCountry;
        _ = this.OriginatingDepositoryFinancialInstitutionID;
        this.OriginatingDepositoryFinancialInstitutionIDQualifier.Validate();
        _ = this.OriginatingDepositoryFinancialInstitutionName;
        _ = this.OriginatorCity;
        _ = this.OriginatorCountry;
        _ = this.OriginatorIdentification;
        _ = this.OriginatorName;
        _ = this.OriginatorPostalCode;
        _ = this.OriginatorStateOrProvince;
        _ = this.OriginatorStreetAddress;
        _ = this.PaymentRelatedInformation;
        _ = this.PaymentRelatedInformation2;
        _ = this.ReceiverCity;
        _ = this.ReceiverCountry;
        _ = this.ReceiverIdentificationNumber;
        _ = this.ReceiverPostalCode;
        _ = this.ReceiverStateOrProvince;
        _ = this.ReceiverStreetAddress;
        _ = this.ReceivingCompanyOrIndividualName;
        _ = this.ReceivingDepositoryFinancialInstitutionCountry;
        _ = this.ReceivingDepositoryFinancialInstitutionID;
        this.ReceivingDepositoryFinancialInstitutionIDQualifier.Validate();
        _ = this.ReceivingDepositoryFinancialInstitutionName;
    }

    public InternationalAddenda() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InternationalAddenda(InternationalAddenda internationalAddenda)
        : base(internationalAddenda) { }
#pragma warning restore CS8618

    public InternationalAddenda(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InternationalAddenda(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InternationalAddendaFromRaw.FromRawUnchecked"/>
    public static InternationalAddenda FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InternationalAddendaFromRaw : IFromRawJson<InternationalAddenda>
{
    /// <inheritdoc/>
    public InternationalAddenda FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InternationalAddenda.FromRawUnchecked(rawData);
}

/// <summary>
/// A description of how the foreign exchange rate was calculated.
/// </summary>
[JsonConverter(typeof(ForeignExchangeIndicatorConverter))]
public enum ForeignExchangeIndicator
{
    /// <summary>
    /// The originator chose an amount in their own currency. The settled amount
    /// in USD was converted using the exchange rate.
    /// </summary>
    FixedToVariable,

    /// <summary>
    /// The originator chose an amount to settle in USD. The originator's amount
    /// was variable; known only after the foreign exchange conversion.
    /// </summary>
    VariableToFixed,

    /// <summary>
    /// The amount was originated and settled as a fixed amount in USD. There is
    /// no foreign exchange conversion.
    /// </summary>
    FixedToFixed,
}

sealed class ForeignExchangeIndicatorConverter : JsonConverter<ForeignExchangeIndicator>
{
    public override ForeignExchangeIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fixed_to_variable" => ForeignExchangeIndicator.FixedToVariable,
            "variable_to_fixed" => ForeignExchangeIndicator.VariableToFixed,
            "fixed_to_fixed" => ForeignExchangeIndicator.FixedToFixed,
            _ => (ForeignExchangeIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ForeignExchangeIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ForeignExchangeIndicator.FixedToVariable => "fixed_to_variable",
                ForeignExchangeIndicator.VariableToFixed => "variable_to_fixed",
                ForeignExchangeIndicator.FixedToFixed => "fixed_to_fixed",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An instruction of how to interpret the `foreign_exchange_reference` field for
/// this Transaction.
/// </summary>
[JsonConverter(typeof(ForeignExchangeReferenceIndicatorConverter))]
public enum ForeignExchangeReferenceIndicator
{
    /// <summary>
    /// The ACH file contains a foreign exchange rate.
    /// </summary>
    ForeignExchangeRate,

    /// <summary>
    /// The ACH file contains a reference to a well-known foreign exchange rate.
    /// </summary>
    ForeignExchangeReferenceNumber,

    /// <summary>
    /// There is no foreign exchange for this transfer, so the `foreign_exchange_reference`
    /// field is blank.
    /// </summary>
    Blank,
}

sealed class ForeignExchangeReferenceIndicatorConverter
    : JsonConverter<ForeignExchangeReferenceIndicator>
{
    public override ForeignExchangeReferenceIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "foreign_exchange_rate" => ForeignExchangeReferenceIndicator.ForeignExchangeRate,
            "foreign_exchange_reference_number" =>
                ForeignExchangeReferenceIndicator.ForeignExchangeReferenceNumber,
            "blank" => ForeignExchangeReferenceIndicator.Blank,
            _ => (ForeignExchangeReferenceIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ForeignExchangeReferenceIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ForeignExchangeReferenceIndicator.ForeignExchangeRate => "foreign_exchange_rate",
                ForeignExchangeReferenceIndicator.ForeignExchangeReferenceNumber =>
                    "foreign_exchange_reference_number",
                ForeignExchangeReferenceIndicator.Blank => "blank",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of transfer. Set by the originator.
/// </summary>
[JsonConverter(typeof(InternationalTransactionTypeCodeConverter))]
public enum InternationalTransactionTypeCode
{
    /// <summary>
    /// Sent as `ANN` in the Nacha file.
    /// </summary>
    Annuity,

    /// <summary>
    /// Sent as `BUS` in the Nacha file.
    /// </summary>
    BusinessOrCommercial,

    /// <summary>
    /// Sent as `DEP` in the Nacha file.
    /// </summary>
    Deposit,

    /// <summary>
    /// Sent as `LOA` in the Nacha file.
    /// </summary>
    Loan,

    /// <summary>
    /// Sent as `MIS` in the Nacha file.
    /// </summary>
    Miscellaneous,

    /// <summary>
    /// Sent as `MOR` in the Nacha file.
    /// </summary>
    Mortgage,

    /// <summary>
    /// Sent as `PEN` in the Nacha file.
    /// </summary>
    Pension,

    /// <summary>
    /// Sent as `REM` in the Nacha file.
    /// </summary>
    Remittance,

    /// <summary>
    /// Sent as `RLS` in the Nacha file.
    /// </summary>
    RentOrLease,

    /// <summary>
    /// Sent as `SAL` in the Nacha file.
    /// </summary>
    SalaryOrPayroll,

    /// <summary>
    /// Sent as `TAX` in the Nacha file.
    /// </summary>
    Tax,

    /// <summary>
    /// Sent as `ARC` in the Nacha file.
    /// </summary>
    AccountsReceivable,

    /// <summary>
    /// Sent as `BOC` in the Nacha file.
    /// </summary>
    BackOfficeConversion,

    /// <summary>
    /// Sent as `MTE` in the Nacha file.
    /// </summary>
    MachineTransfer,

    /// <summary>
    /// Sent as `POP` in the Nacha file.
    /// </summary>
    PointOfPurchase,

    /// <summary>
    /// Sent as `POS` in the Nacha file.
    /// </summary>
    PointOfSale,

    /// <summary>
    /// Sent as `RCK` in the Nacha file.
    /// </summary>
    RepresentedCheck,

    /// <summary>
    /// Sent as `SHR` in the Nacha file.
    /// </summary>
    SharedNetworkTransaction,

    /// <summary>
    /// Sent as `TEL` in the Nacha file.
    /// </summary>
    TelphoneInitiated,

    /// <summary>
    /// Sent as `WEB` in the Nacha file.
    /// </summary>
    InternetInitiated,
}

sealed class InternationalTransactionTypeCodeConverter
    : JsonConverter<InternationalTransactionTypeCode>
{
    public override InternationalTransactionTypeCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annuity" => InternationalTransactionTypeCode.Annuity,
            "business_or_commercial" => InternationalTransactionTypeCode.BusinessOrCommercial,
            "deposit" => InternationalTransactionTypeCode.Deposit,
            "loan" => InternationalTransactionTypeCode.Loan,
            "miscellaneous" => InternationalTransactionTypeCode.Miscellaneous,
            "mortgage" => InternationalTransactionTypeCode.Mortgage,
            "pension" => InternationalTransactionTypeCode.Pension,
            "remittance" => InternationalTransactionTypeCode.Remittance,
            "rent_or_lease" => InternationalTransactionTypeCode.RentOrLease,
            "salary_or_payroll" => InternationalTransactionTypeCode.SalaryOrPayroll,
            "tax" => InternationalTransactionTypeCode.Tax,
            "accounts_receivable" => InternationalTransactionTypeCode.AccountsReceivable,
            "back_office_conversion" => InternationalTransactionTypeCode.BackOfficeConversion,
            "machine_transfer" => InternationalTransactionTypeCode.MachineTransfer,
            "point_of_purchase" => InternationalTransactionTypeCode.PointOfPurchase,
            "point_of_sale" => InternationalTransactionTypeCode.PointOfSale,
            "represented_check" => InternationalTransactionTypeCode.RepresentedCheck,
            "shared_network_transaction" =>
                InternationalTransactionTypeCode.SharedNetworkTransaction,
            "telphone_initiated" => InternationalTransactionTypeCode.TelphoneInitiated,
            "internet_initiated" => InternationalTransactionTypeCode.InternetInitiated,
            _ => (InternationalTransactionTypeCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InternationalTransactionTypeCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InternationalTransactionTypeCode.Annuity => "annuity",
                InternationalTransactionTypeCode.BusinessOrCommercial => "business_or_commercial",
                InternationalTransactionTypeCode.Deposit => "deposit",
                InternationalTransactionTypeCode.Loan => "loan",
                InternationalTransactionTypeCode.Miscellaneous => "miscellaneous",
                InternationalTransactionTypeCode.Mortgage => "mortgage",
                InternationalTransactionTypeCode.Pension => "pension",
                InternationalTransactionTypeCode.Remittance => "remittance",
                InternationalTransactionTypeCode.RentOrLease => "rent_or_lease",
                InternationalTransactionTypeCode.SalaryOrPayroll => "salary_or_payroll",
                InternationalTransactionTypeCode.Tax => "tax",
                InternationalTransactionTypeCode.AccountsReceivable => "accounts_receivable",
                InternationalTransactionTypeCode.BackOfficeConversion => "back_office_conversion",
                InternationalTransactionTypeCode.MachineTransfer => "machine_transfer",
                InternationalTransactionTypeCode.PointOfPurchase => "point_of_purchase",
                InternationalTransactionTypeCode.PointOfSale => "point_of_sale",
                InternationalTransactionTypeCode.RepresentedCheck => "represented_check",
                InternationalTransactionTypeCode.SharedNetworkTransaction =>
                    "shared_network_transaction",
                InternationalTransactionTypeCode.TelphoneInitiated => "telphone_initiated",
                InternationalTransactionTypeCode.InternetInitiated => "internet_initiated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An instruction of how to interpret the `originating_depository_financial_institution_id`
/// field for this Transaction.
/// </summary>
[JsonConverter(typeof(OriginatingDepositoryFinancialInstitutionIDQualifierConverter))]
public enum OriginatingDepositoryFinancialInstitutionIDQualifier
{
    /// <summary>
    /// A domestic clearing system number. In the US, for example, this is the American
    /// Banking Association (ABA) routing number.
    /// </summary>
    NationalClearingSystemNumber,

    /// <summary>
    /// The SWIFT Bank Identifier Code (BIC) of the bank.
    /// </summary>
    BicCode,

    /// <summary>
    /// An International Bank Account Number.
    /// </summary>
    Iban,
}

sealed class OriginatingDepositoryFinancialInstitutionIDQualifierConverter
    : JsonConverter<OriginatingDepositoryFinancialInstitutionIDQualifier>
{
    public override OriginatingDepositoryFinancialInstitutionIDQualifier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "national_clearing_system_number" =>
                OriginatingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber,
            "bic_code" => OriginatingDepositoryFinancialInstitutionIDQualifier.BicCode,
            "iban" => OriginatingDepositoryFinancialInstitutionIDQualifier.Iban,
            _ => (OriginatingDepositoryFinancialInstitutionIDQualifier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OriginatingDepositoryFinancialInstitutionIDQualifier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OriginatingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber =>
                    "national_clearing_system_number",
                OriginatingDepositoryFinancialInstitutionIDQualifier.BicCode => "bic_code",
                OriginatingDepositoryFinancialInstitutionIDQualifier.Iban => "iban",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An instruction of how to interpret the `receiving_depository_financial_institution_id`
/// field for this Transaction.
/// </summary>
[JsonConverter(typeof(ReceivingDepositoryFinancialInstitutionIDQualifierConverter))]
public enum ReceivingDepositoryFinancialInstitutionIDQualifier
{
    /// <summary>
    /// A domestic clearing system number. In the US, for example, this is the American
    /// Banking Association (ABA) routing number.
    /// </summary>
    NationalClearingSystemNumber,

    /// <summary>
    /// The SWIFT Bank Identifier Code (BIC) of the bank.
    /// </summary>
    BicCode,

    /// <summary>
    /// An International Bank Account Number.
    /// </summary>
    Iban,
}

sealed class ReceivingDepositoryFinancialInstitutionIDQualifierConverter
    : JsonConverter<ReceivingDepositoryFinancialInstitutionIDQualifier>
{
    public override ReceivingDepositoryFinancialInstitutionIDQualifier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "national_clearing_system_number" =>
                ReceivingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber,
            "bic_code" => ReceivingDepositoryFinancialInstitutionIDQualifier.BicCode,
            "iban" => ReceivingDepositoryFinancialInstitutionIDQualifier.Iban,
            _ => (ReceivingDepositoryFinancialInstitutionIDQualifier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReceivingDepositoryFinancialInstitutionIDQualifier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReceivingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber =>
                    "national_clearing_system_number",
                ReceivingDepositoryFinancialInstitutionIDQualifier.BicCode => "bic_code",
                ReceivingDepositoryFinancialInstitutionIDQualifier.Iban => "iban",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If you initiate a notification of change in response to the transfer, this will
/// contain its details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NotificationOfChange, NotificationOfChangeFromRaw>))]
public sealed record class NotificationOfChange : JsonModel
{
    /// <summary>
    /// The new account number provided in the notification of change.
    /// </summary>
    public required string? UpdatedAccountNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updated_account_number");
        }
        init { this._rawData.Set("updated_account_number", value); }
    }

    /// <summary>
    /// The new routing number provided in the notification of change.
    /// </summary>
    public required string? UpdatedRoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updated_routing_number");
        }
        init { this._rawData.Set("updated_routing_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UpdatedAccountNumber;
        _ = this.UpdatedRoutingNumber;
    }

    public NotificationOfChange() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationOfChange(NotificationOfChange notificationOfChange)
        : base(notificationOfChange) { }
#pragma warning restore CS8618

    public NotificationOfChange(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationOfChange(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationOfChangeFromRaw.FromRawUnchecked"/>
    public static NotificationOfChange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationOfChangeFromRaw : IFromRawJson<NotificationOfChange>
{
    /// <inheritdoc/>
    public NotificationOfChange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationOfChange.FromRawUnchecked(rawData);
}

/// <summary>
/// A subhash containing information about when and how the transfer settled at the
/// Federal Reserve.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Settlement, SettlementFromRaw>))]
public sealed record class Settlement : JsonModel
{
    /// <summary>
    /// When the funds for this transfer settle at the recipient bank at the Federal Reserve.
    /// </summary>
    public required System::DateTimeOffset SettledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("settled_at");
        }
        init { this._rawData.Set("settled_at", value); }
    }

    /// <summary>
    /// The settlement schedule this transfer follows.
    /// </summary>
    public required ApiEnum<string, SettlementSchedule> SettlementSchedule
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SettlementSchedule>>(
                "settlement_schedule"
            );
        }
        init { this._rawData.Set("settlement_schedule", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SettledAt;
        this.SettlementSchedule.Validate();
    }

    public Settlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Settlement(Settlement settlement)
        : base(settlement) { }
#pragma warning restore CS8618

    public Settlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Settlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SettlementFromRaw.FromRawUnchecked"/>
    public static Settlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SettlementFromRaw : IFromRawJson<Settlement>
{
    /// <inheritdoc/>
    public Settlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Settlement.FromRawUnchecked(rawData);
}

/// <summary>
/// The settlement schedule this transfer follows.
/// </summary>
[JsonConverter(typeof(SettlementScheduleConverter))]
public enum SettlementSchedule
{
    /// <summary>
    /// The transfer is expected to settle same-day.
    /// </summary>
    SameDay,

    /// <summary>
    /// The transfer is expected to settle on a future date.
    /// </summary>
    FutureDated,
}

sealed class SettlementScheduleConverter : JsonConverter<SettlementSchedule>
{
    public override SettlementSchedule Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "same_day" => SettlementSchedule.SameDay,
            "future_dated" => SettlementSchedule.FutureDated,
            _ => (SettlementSchedule)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SettlementSchedule value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SettlementSchedule.SameDay => "same_day",
                SettlementSchedule.FutureDated => "future_dated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The Standard Entry Class (SEC) code of the transfer.
/// </summary>
[JsonConverter(typeof(StandardEntryClassCodeConverter))]
public enum StandardEntryClassCode
{
    /// <summary>
    /// Corporate Credit and Debit (CCD).
    /// </summary>
    CorporateCreditOrDebit,

    /// <summary>
    /// Corporate Trade Exchange (CTX).
    /// </summary>
    CorporateTradeExchange,

    /// <summary>
    /// Prearranged Payments and Deposits (PPD).
    /// </summary>
    PrearrangedPaymentsAndDeposit,

    /// <summary>
    /// Internet Initiated (WEB).
    /// </summary>
    InternetInitiated,

    /// <summary>
    /// Point of Sale (POS).
    /// </summary>
    PointOfSale,

    /// <summary>
    /// Telephone Initiated (TEL).
    /// </summary>
    TelephoneInitiated,

    /// <summary>
    /// Customer Initiated (CIE).
    /// </summary>
    CustomerInitiated,

    /// <summary>
    /// Accounts Receivable (ARC).
    /// </summary>
    AccountsReceivable,

    /// <summary>
    /// Machine Transfer (MTE).
    /// </summary>
    MachineTransfer,

    /// <summary>
    /// Shared Network Transaction (SHR).
    /// </summary>
    SharedNetworkTransaction,

    /// <summary>
    /// Represented Check (RCK).
    /// </summary>
    RepresentedCheck,

    /// <summary>
    /// Back Office Conversion (BOC).
    /// </summary>
    BackOfficeConversion,

    /// <summary>
    /// Point of Purchase (POP).
    /// </summary>
    PointOfPurchase,

    /// <summary>
    /// Check Truncation (TRC).
    /// </summary>
    CheckTruncation,

    /// <summary>
    /// Destroyed Check (XCK).
    /// </summary>
    DestroyedCheck,

    /// <summary>
    /// International ACH Transaction (IAT).
    /// </summary>
    InternationalAchTransaction,
}

sealed class StandardEntryClassCodeConverter : JsonConverter<StandardEntryClassCode>
{
    public override StandardEntryClassCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "corporate_credit_or_debit" => StandardEntryClassCode.CorporateCreditOrDebit,
            "corporate_trade_exchange" => StandardEntryClassCode.CorporateTradeExchange,
            "prearranged_payments_and_deposit" =>
                StandardEntryClassCode.PrearrangedPaymentsAndDeposit,
            "internet_initiated" => StandardEntryClassCode.InternetInitiated,
            "point_of_sale" => StandardEntryClassCode.PointOfSale,
            "telephone_initiated" => StandardEntryClassCode.TelephoneInitiated,
            "customer_initiated" => StandardEntryClassCode.CustomerInitiated,
            "accounts_receivable" => StandardEntryClassCode.AccountsReceivable,
            "machine_transfer" => StandardEntryClassCode.MachineTransfer,
            "shared_network_transaction" => StandardEntryClassCode.SharedNetworkTransaction,
            "represented_check" => StandardEntryClassCode.RepresentedCheck,
            "back_office_conversion" => StandardEntryClassCode.BackOfficeConversion,
            "point_of_purchase" => StandardEntryClassCode.PointOfPurchase,
            "check_truncation" => StandardEntryClassCode.CheckTruncation,
            "destroyed_check" => StandardEntryClassCode.DestroyedCheck,
            "international_ach_transaction" => StandardEntryClassCode.InternationalAchTransaction,
            _ => (StandardEntryClassCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StandardEntryClassCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StandardEntryClassCode.CorporateCreditOrDebit => "corporate_credit_or_debit",
                StandardEntryClassCode.CorporateTradeExchange => "corporate_trade_exchange",
                StandardEntryClassCode.PrearrangedPaymentsAndDeposit =>
                    "prearranged_payments_and_deposit",
                StandardEntryClassCode.InternetInitiated => "internet_initiated",
                StandardEntryClassCode.PointOfSale => "point_of_sale",
                StandardEntryClassCode.TelephoneInitiated => "telephone_initiated",
                StandardEntryClassCode.CustomerInitiated => "customer_initiated",
                StandardEntryClassCode.AccountsReceivable => "accounts_receivable",
                StandardEntryClassCode.MachineTransfer => "machine_transfer",
                StandardEntryClassCode.SharedNetworkTransaction => "shared_network_transaction",
                StandardEntryClassCode.RepresentedCheck => "represented_check",
                StandardEntryClassCode.BackOfficeConversion => "back_office_conversion",
                StandardEntryClassCode.PointOfPurchase => "point_of_purchase",
                StandardEntryClassCode.CheckTruncation => "check_truncation",
                StandardEntryClassCode.DestroyedCheck => "destroyed_check",
                StandardEntryClassCode.InternationalAchTransaction =>
                    "international_ach_transaction",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the transfer.
/// </summary>
[JsonConverter(typeof(InboundAchTransferStatusConverter))]
public enum InboundAchTransferStatus
{
    /// <summary>
    /// The Inbound ACH Transfer is awaiting action, will transition automatically
    /// if no action is taken.
    /// </summary>
    Pending,

    /// <summary>
    /// The Inbound ACH Transfer has been declined.
    /// </summary>
    Declined,

    /// <summary>
    /// The Inbound ACH Transfer is accepted.
    /// </summary>
    Accepted,

    /// <summary>
    /// The Inbound ACH Transfer has been returned.
    /// </summary>
    Returned,
}

sealed class InboundAchTransferStatusConverter : JsonConverter<InboundAchTransferStatus>
{
    public override InboundAchTransferStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => InboundAchTransferStatus.Pending,
            "declined" => InboundAchTransferStatus.Declined,
            "accepted" => InboundAchTransferStatus.Accepted,
            "returned" => InboundAchTransferStatus.Returned,
            _ => (InboundAchTransferStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundAchTransferStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InboundAchTransferStatus.Pending => "pending",
                InboundAchTransferStatus.Declined => "declined",
                InboundAchTransferStatus.Accepted => "accepted",
                InboundAchTransferStatus.Returned => "returned",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If your transfer is returned, this will contain details of the return.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TransferReturn, TransferReturnFromRaw>))]
public sealed record class TransferReturn : JsonModel
{
    /// <summary>
    /// The reason for the transfer return.
    /// </summary>
    public required ApiEnum<string, TransferReturnReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TransferReturnReason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The time at which the transfer was returned.
    /// </summary>
    public required System::DateTimeOffset ReturnedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("returned_at");
        }
        init { this._rawData.Set("returned_at", value); }
    }

    /// <summary>
    /// The id of the transaction for the returned transfer.
    /// </summary>
    public required string TransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transaction_id");
        }
        init { this._rawData.Set("transaction_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Reason.Validate();
        _ = this.ReturnedAt;
        _ = this.TransactionID;
    }

    public TransferReturn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransferReturn(TransferReturn transferReturn)
        : base(transferReturn) { }
#pragma warning restore CS8618

    public TransferReturn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TransferReturn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransferReturnFromRaw.FromRawUnchecked"/>
    public static TransferReturn FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransferReturnFromRaw : IFromRawJson<TransferReturn>
{
    /// <inheritdoc/>
    public TransferReturn FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TransferReturn.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason for the transfer return.
/// </summary>
[JsonConverter(typeof(TransferReturnReasonConverter))]
public enum TransferReturnReason
{
    /// <summary>
    /// The customer's account has insufficient funds. This reason is only allowed
    /// for debits. The Nacha return code is R01.
    /// </summary>
    InsufficientFunds,

    /// <summary>
    /// The originating financial institution asked for this transfer to be returned.
    /// The receiving bank is complying with the request. The Nacha return code is R06.
    /// </summary>
    ReturnedPerOdfiRequest,

    /// <summary>
    /// The customer no longer authorizes this transaction. The Nacha return code
    /// is R07.
    /// </summary>
    AuthorizationRevokedByCustomer,

    /// <summary>
    /// The customer asked for the payment to be stopped. This reason is only allowed
    /// for debits. The Nacha return code is R08.
    /// </summary>
    PaymentStopped,

    /// <summary>
    /// The customer advises that the debit was unauthorized. The Nacha return code
    /// is R10.
    /// </summary>
    CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete,

    /// <summary>
    /// The payee is deceased. The Nacha return code is R14.
    /// </summary>
    RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity,

    /// <summary>
    /// The account holder is deceased. The Nacha return code is R15.
    /// </summary>
    BeneficiaryOrAccountHolderDeceased,

    /// <summary>
    /// The customer refused a credit entry. This reason is only allowed for credits.
    /// The Nacha return code is R23.
    /// </summary>
    CreditEntryRefusedByReceiver,

    /// <summary>
    /// The account holder identified this transaction as a duplicate. The Nacha return
    /// code is R24.
    /// </summary>
    DuplicateEntry,

    /// <summary>
    /// The corporate customer no longer authorizes this transaction. The Nacha return
    /// code is R29.
    /// </summary>
    CorporateCustomerAdvisedNotAuthorized,
}

sealed class TransferReturnReasonConverter : JsonConverter<TransferReturnReason>
{
    public override TransferReturnReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" => TransferReturnReason.InsufficientFunds,
            "returned_per_odfi_request" => TransferReturnReason.ReturnedPerOdfiRequest,
            "authorization_revoked_by_customer" =>
                TransferReturnReason.AuthorizationRevokedByCustomer,
            "payment_stopped" => TransferReturnReason.PaymentStopped,
            "customer_advised_unauthorized_improper_ineligible_or_incomplete" =>
                TransferReturnReason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete,
            "representative_payee_deceased_or_unable_to_continue_in_that_capacity" =>
                TransferReturnReason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity,
            "beneficiary_or_account_holder_deceased" =>
                TransferReturnReason.BeneficiaryOrAccountHolderDeceased,
            "credit_entry_refused_by_receiver" => TransferReturnReason.CreditEntryRefusedByReceiver,
            "duplicate_entry" => TransferReturnReason.DuplicateEntry,
            "corporate_customer_advised_not_authorized" =>
                TransferReturnReason.CorporateCustomerAdvisedNotAuthorized,
            _ => (TransferReturnReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransferReturnReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransferReturnReason.InsufficientFunds => "insufficient_funds",
                TransferReturnReason.ReturnedPerOdfiRequest => "returned_per_odfi_request",
                TransferReturnReason.AuthorizationRevokedByCustomer =>
                    "authorization_revoked_by_customer",
                TransferReturnReason.PaymentStopped => "payment_stopped",
                TransferReturnReason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete =>
                    "customer_advised_unauthorized_improper_ineligible_or_incomplete",
                TransferReturnReason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity =>
                    "representative_payee_deceased_or_unable_to_continue_in_that_capacity",
                TransferReturnReason.BeneficiaryOrAccountHolderDeceased =>
                    "beneficiary_or_account_holder_deceased",
                TransferReturnReason.CreditEntryRefusedByReceiver =>
                    "credit_entry_refused_by_receiver",
                TransferReturnReason.DuplicateEntry => "duplicate_entry",
                TransferReturnReason.CorporateCustomerAdvisedNotAuthorized =>
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
/// A constant representing the object's type. For this resource it will always be `inbound_ach_transfer`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    InboundAchTransfer,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.InboundAchTransfers.Type>
{
    public override global::Increase.Api.Models.InboundAchTransfers.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_ach_transfer" => global::Increase
                .Api
                .Models
                .InboundAchTransfers
                .Type
                .InboundAchTransfer,
            _ => (global::Increase.Api.Models.InboundAchTransfers.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.InboundAchTransfers.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.InboundAchTransfers.Type.InboundAchTransfer =>
                    "inbound_ach_transfer",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
