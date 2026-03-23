using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.AchTransfers;

/// <summary>
/// ACH transfers move funds between your Increase account and any other account
/// accessible by the Automated Clearing House (ACH).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AchTransfer, AchTransferFromRaw>))]
public sealed record class AchTransfer : JsonModel
{
    /// <summary>
    /// The ACH transfer's identifier.
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
    /// The destination account number.
    /// </summary>
    public required string AccountNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_number");
        }
        init { this._rawData.Set("account_number", value); }
    }

    /// <summary>
    /// After the transfer is acknowledged by FedACH, this will contain supplemental
    /// details. The Federal Reserve sends an acknowledgement message for each file
    /// that Increase submits.
    /// </summary>
    public required Acknowledgement? Acknowledgement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Acknowledgement>("acknowledgement");
        }
        init { this._rawData.Set("acknowledgement", value); }
    }

    /// <summary>
    /// Additional information that will be sent to the recipient.
    /// </summary>
    public required AchTransferAddenda? Addenda
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AchTransferAddenda>("addenda");
        }
        init { this._rawData.Set("addenda", value); }
    }

    /// <summary>
    /// The transfer amount in USD cents. A positive amount indicates a credit transfer
    /// pushing funds to the receiving account. A negative amount indicates a debit
    /// transfer pulling funds from the receiving account.
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
    /// If your account requires approvals for transfers and the transfer was approved,
    /// this will contain details of the approval.
    /// </summary>
    public required Approval? Approval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Approval>("approval");
        }
        init { this._rawData.Set("approval", value); }
    }

    /// <summary>
    /// If your account requires approvals for transfers and the transfer was not
    /// approved, this will contain details of the cancellation.
    /// </summary>
    public required Cancellation? Cancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Cancellation>("cancellation");
        }
        init { this._rawData.Set("cancellation", value); }
    }

    /// <summary>
    /// The description of the date of the transfer.
    /// </summary>
    public required string? CompanyDescriptiveDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_descriptive_date");
        }
        init { this._rawData.Set("company_descriptive_date", value); }
    }

    /// <summary>
    /// The data you chose to associate with the transfer.
    /// </summary>
    public required string? CompanyDiscretionaryData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_discretionary_data");
        }
        init { this._rawData.Set("company_discretionary_data", value); }
    }

    /// <summary>
    /// The description of the transfer you set to be shown to the recipient.
    /// </summary>
    public required string? CompanyEntryDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_entry_description");
        }
        init { this._rawData.Set("company_entry_description", value); }
    }

    /// <summary>
    /// The company ID associated with the transfer.
    /// </summary>
    public required string CompanyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("company_id");
        }
        init { this._rawData.Set("company_id", value); }
    }

    /// <summary>
    /// The name by which the recipient knows you.
    /// </summary>
    public required string? CompanyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_name");
        }
        init { this._rawData.Set("company_name", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the transfer was created.
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
    /// What object created the transfer, either via the API or the dashboard.
    /// </summary>
    public required CreatedBy? CreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreatedBy>("created_by");
        }
        init { this._rawData.Set("created_by", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transfer's
    /// currency. For ACH transfers this is always equal to `usd`.
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
    /// The type of entity that owns the account to which the ACH Transfer is being sent.
    /// </summary>
    public required ApiEnum<string, AchTransferDestinationAccountHolder> DestinationAccountHolder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AchTransferDestinationAccountHolder>
            >("destination_account_holder");
        }
        init { this._rawData.Set("destination_account_holder", value); }
    }

    /// <summary>
    /// The identifier of the External Account the transfer was made to, if any.
    /// </summary>
    public required string? ExternalAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_account_id");
        }
        init { this._rawData.Set("external_account_id", value); }
    }

    /// <summary>
    /// The type of the account to which the transfer will be sent.
    /// </summary>
    public required ApiEnum<string, AchTransferFunding> Funding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AchTransferFunding>>("funding");
        }
        init { this._rawData.Set("funding", value); }
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
    /// Increase will sometimes hold the funds for ACH debit transfers. If funds
    /// are held, this sub-object will contain details of the hold.
    /// </summary>
    public required InboundFundsHold? InboundFundsHold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundFundsHold>("inbound_funds_hold");
        }
        init { this._rawData.Set("inbound_funds_hold", value); }
    }

    /// <summary>
    /// Your identifier for the transfer recipient.
    /// </summary>
    public required string? IndividualID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("individual_id");
        }
        init { this._rawData.Set("individual_id", value); }
    }

    /// <summary>
    /// The name of the transfer recipient. This value is informational and not verified
    /// by the recipient's bank.
    /// </summary>
    public required string? IndividualName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("individual_name");
        }
        init { this._rawData.Set("individual_name", value); }
    }

    /// <summary>
    /// The transfer's network.
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
    /// If the receiving bank accepts the transfer but notifies that future transfers
    /// should use different details, this will contain those details.
    /// </summary>
    public required IReadOnlyList<NotificationsOfChange> NotificationsOfChange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<NotificationsOfChange>>(
                "notifications_of_change"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<NotificationsOfChange>>(
                "notifications_of_change",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The ID for the pending transaction representing the transfer. A pending transaction
    /// is created when the transfer [requires approval](https://increase.com/documentation/transfer-approvals#transfer-approvals)
    /// by someone else in your organization.
    /// </summary>
    public required string? PendingTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pending_transaction_id");
        }
        init { this._rawData.Set("pending_transaction_id", value); }
    }

    /// <summary>
    /// Configuration for how the effective date of the transfer will be set. This
    /// determines same-day vs future-dated settlement timing. If not set, defaults
    /// to a `settlement_schedule` of `same_day`. If set, exactly one of the child
    /// attributes must be set.
    /// </summary>
    public required AchTransferPreferredEffectiveDate PreferredEffectiveDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AchTransferPreferredEffectiveDate>(
                "preferred_effective_date"
            );
        }
        init { this._rawData.Set("preferred_effective_date", value); }
    }

    /// <summary>
    /// If your transfer is returned, this will contain details of the return.
    /// </summary>
    public required Return? Return
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Return>("return");
        }
        init { this._rawData.Set("return", value); }
    }

    /// <summary>
    /// The American Bankers' Association (ABA) Routing Transit Number (RTN).
    /// </summary>
    public required string RoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("routing_number");
        }
        init { this._rawData.Set("routing_number", value); }
    }

    /// <summary>
    /// A subhash containing information about when and how the transfer settled at
    /// the Federal Reserve.
    /// </summary>
    public required Settlement? Settlement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Settlement>("settlement");
        }
        init { this._rawData.Set("settlement", value); }
    }

    /// <summary>
    /// The [Standard Entry Class (SEC) code](/documentation/ach-standard-entry-class-codes)
    /// to use for the transfer.
    /// </summary>
    public required ApiEnum<string, AchTransferStandardEntryClassCode> StandardEntryClassCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AchTransferStandardEntryClassCode>
            >("standard_entry_class_code");
        }
        init { this._rawData.Set("standard_entry_class_code", value); }
    }

    /// <summary>
    /// The descriptor that will show on the recipient's bank statement.
    /// </summary>
    public required string StatementDescriptor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("statement_descriptor");
        }
        init { this._rawData.Set("statement_descriptor", value); }
    }

    /// <summary>
    /// The lifecycle status of the transfer.
    /// </summary>
    public required ApiEnum<string, AchTransferStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AchTransferStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// After the transfer is submitted to FedACH, this will contain supplemental
    /// details. Increase batches transfers and submits a file to the Federal Reserve
    /// roughly every 30 minutes. The Federal Reserve processes ACH transfers during
    /// weekdays according to their [posted schedule](https://www.frbservices.org/resources/resource-centers/same-day-ach/fedach-processing-schedule.html).
    /// </summary>
    public required Submission? Submission
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Submission>("submission");
        }
        init { this._rawData.Set("submission", value); }
    }

    /// <summary>
    /// The ID for the transaction funding the transfer.
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

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `ach_transfer`.
    /// </summary>
    public required ApiEnum<string, AchTransferType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AchTransferType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.AccountNumber;
        this.Acknowledgement?.Validate();
        this.Addenda?.Validate();
        _ = this.Amount;
        this.Approval?.Validate();
        this.Cancellation?.Validate();
        _ = this.CompanyDescriptiveDate;
        _ = this.CompanyDiscretionaryData;
        _ = this.CompanyEntryDescription;
        _ = this.CompanyID;
        _ = this.CompanyName;
        _ = this.CreatedAt;
        this.CreatedBy?.Validate();
        this.Currency.Validate();
        this.DestinationAccountHolder.Validate();
        _ = this.ExternalAccountID;
        this.Funding.Validate();
        _ = this.IdempotencyKey;
        this.InboundFundsHold?.Validate();
        _ = this.IndividualID;
        _ = this.IndividualName;
        this.Network.Validate();
        foreach (var item in this.NotificationsOfChange)
        {
            item.Validate();
        }
        _ = this.PendingTransactionID;
        this.PreferredEffectiveDate.Validate();
        this.Return?.Validate();
        _ = this.RoutingNumber;
        this.Settlement?.Validate();
        this.StandardEntryClassCode.Validate();
        _ = this.StatementDescriptor;
        this.Status.Validate();
        this.Submission?.Validate();
        _ = this.TransactionID;
        this.Type.Validate();
    }

    public AchTransfer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransfer(AchTransfer achTransfer)
        : base(achTransfer) { }
#pragma warning restore CS8618

    public AchTransfer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AchTransfer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AchTransferFromRaw.FromRawUnchecked"/>
    public static AchTransfer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AchTransferFromRaw : IFromRawJson<AchTransfer>
{
    /// <inheritdoc/>
    public AchTransfer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AchTransfer.FromRawUnchecked(rawData);
}

/// <summary>
/// After the transfer is acknowledged by FedACH, this will contain supplemental details.
/// The Federal Reserve sends an acknowledgement message for each file that Increase submits.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Acknowledgement, AcknowledgementFromRaw>))]
public sealed record class Acknowledgement : JsonModel
{
    /// <summary>
    /// When the Federal Reserve acknowledged the submitted file containing this transfer.
    /// </summary>
    public required string AcknowledgedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("acknowledged_at");
        }
        init { this._rawData.Set("acknowledged_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcknowledgedAt;
    }

    public Acknowledgement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Acknowledgement(Acknowledgement acknowledgement)
        : base(acknowledgement) { }
#pragma warning restore CS8618

    public Acknowledgement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Acknowledgement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AcknowledgementFromRaw.FromRawUnchecked"/>
    public static Acknowledgement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Acknowledgement(string acknowledgedAt)
        : this()
    {
        this.AcknowledgedAt = acknowledgedAt;
    }
}

class AcknowledgementFromRaw : IFromRawJson<Acknowledgement>
{
    /// <inheritdoc/>
    public Acknowledgement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Acknowledgement.FromRawUnchecked(rawData);
}

/// <summary>
/// Additional information that will be sent to the recipient.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AchTransferAddenda, AchTransferAddendaFromRaw>))]
public sealed record class AchTransferAddenda : JsonModel
{
    /// <summary>
    /// The type of the resource. We may add additional possible values for this enum
    /// over time; your application should be able to handle such additions gracefully.
    /// </summary>
    public required ApiEnum<string, AchTransferAddendaCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AchTransferAddendaCategory>>(
                "category"
            );
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Unstructured `payment_related_information` passed through with the transfer.
    /// </summary>
    public AchTransferAddendaFreeform? Freeform
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AchTransferAddendaFreeform>("freeform");
        }
        init { this._rawData.Set("freeform", value); }
    }

    /// <summary>
    /// Structured ASC X12 820 remittance advice records. Please reach out to [support@increase.com](mailto:support@increase.com)
    /// for more information.
    /// </summary>
    public AchTransferAddendaPaymentOrderRemittanceAdvice? PaymentOrderRemittanceAdvice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AchTransferAddendaPaymentOrderRemittanceAdvice>(
                "payment_order_remittance_advice"
            );
        }
        init { this._rawData.Set("payment_order_remittance_advice", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.Freeform?.Validate();
        this.PaymentOrderRemittanceAdvice?.Validate();
    }

    public AchTransferAddenda() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferAddenda(AchTransferAddenda achTransferAddenda)
        : base(achTransferAddenda) { }
#pragma warning restore CS8618

    public AchTransferAddenda(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AchTransferAddenda(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AchTransferAddendaFromRaw.FromRawUnchecked"/>
    public static AchTransferAddenda FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AchTransferAddenda(ApiEnum<string, AchTransferAddendaCategory> category)
        : this()
    {
        this.Category = category;
    }
}

class AchTransferAddendaFromRaw : IFromRawJson<AchTransferAddenda>
{
    /// <inheritdoc/>
    public AchTransferAddenda FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AchTransferAddenda.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the resource. We may add additional possible values for this enum
/// over time; your application should be able to handle such additions gracefully.
/// </summary>
[JsonConverter(typeof(AchTransferAddendaCategoryConverter))]
public enum AchTransferAddendaCategory
{
    /// <summary>
    /// Unstructured `payment_related_information` passed through with the transfer.
    /// </summary>
    Freeform,

    /// <summary>
    /// Structured ASC X12 820 remittance advice records. Please reach out to [support@increase.com](mailto:support@increase.com)
    /// for more information.
    /// </summary>
    PaymentOrderRemittanceAdvice,

    /// <summary>
    /// Unknown addenda type.
    /// </summary>
    Other,
}

sealed class AchTransferAddendaCategoryConverter : JsonConverter<AchTransferAddendaCategory>
{
    public override AchTransferAddendaCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "freeform" => AchTransferAddendaCategory.Freeform,
            "payment_order_remittance_advice" =>
                AchTransferAddendaCategory.PaymentOrderRemittanceAdvice,
            "other" => AchTransferAddendaCategory.Other,
            _ => (AchTransferAddendaCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AchTransferAddendaCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AchTransferAddendaCategory.Freeform => "freeform",
                AchTransferAddendaCategory.PaymentOrderRemittanceAdvice =>
                    "payment_order_remittance_advice",
                AchTransferAddendaCategory.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Unstructured `payment_related_information` passed through with the transfer.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AchTransferAddendaFreeform, AchTransferAddendaFreeformFromRaw>)
)]
public sealed record class AchTransferAddendaFreeform : JsonModel
{
    /// <summary>
    /// Each entry represents an addendum sent with the transfer.
    /// </summary>
    public required IReadOnlyList<AchTransferAddendaFreeformEntry> Entries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AchTransferAddendaFreeformEntry>>(
                "entries"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<AchTransferAddendaFreeformEntry>>(
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

    public AchTransferAddendaFreeform() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferAddendaFreeform(AchTransferAddendaFreeform achTransferAddendaFreeform)
        : base(achTransferAddendaFreeform) { }
#pragma warning restore CS8618

    public AchTransferAddendaFreeform(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AchTransferAddendaFreeform(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AchTransferAddendaFreeformFromRaw.FromRawUnchecked"/>
    public static AchTransferAddendaFreeform FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AchTransferAddendaFreeform(IReadOnlyList<AchTransferAddendaFreeformEntry> entries)
        : this()
    {
        this.Entries = entries;
    }
}

class AchTransferAddendaFreeformFromRaw : IFromRawJson<AchTransferAddendaFreeform>
{
    /// <inheritdoc/>
    public AchTransferAddendaFreeform FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AchTransferAddendaFreeform.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        AchTransferAddendaFreeformEntry,
        AchTransferAddendaFreeformEntryFromRaw
    >)
)]
public sealed record class AchTransferAddendaFreeformEntry : JsonModel
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

    public AchTransferAddendaFreeformEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferAddendaFreeformEntry(
        AchTransferAddendaFreeformEntry achTransferAddendaFreeformEntry
    )
        : base(achTransferAddendaFreeformEntry) { }
#pragma warning restore CS8618

    public AchTransferAddendaFreeformEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AchTransferAddendaFreeformEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AchTransferAddendaFreeformEntryFromRaw.FromRawUnchecked"/>
    public static AchTransferAddendaFreeformEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AchTransferAddendaFreeformEntry(string paymentRelatedInformation)
        : this()
    {
        this.PaymentRelatedInformation = paymentRelatedInformation;
    }
}

class AchTransferAddendaFreeformEntryFromRaw : IFromRawJson<AchTransferAddendaFreeformEntry>
{
    /// <inheritdoc/>
    public AchTransferAddendaFreeformEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AchTransferAddendaFreeformEntry.FromRawUnchecked(rawData);
}

/// <summary>
/// Structured ASC X12 820 remittance advice records. Please reach out to [support@increase.com](mailto:support@increase.com)
/// for more information.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AchTransferAddendaPaymentOrderRemittanceAdvice,
        AchTransferAddendaPaymentOrderRemittanceAdviceFromRaw
    >)
)]
public sealed record class AchTransferAddendaPaymentOrderRemittanceAdvice : JsonModel
{
    /// <summary>
    /// ASC X12 RMR records for this specific transfer.
    /// </summary>
    public required IReadOnlyList<AchTransferAddendaPaymentOrderRemittanceAdviceInvoice> Invoices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<AchTransferAddendaPaymentOrderRemittanceAdviceInvoice>
            >("invoices");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<AchTransferAddendaPaymentOrderRemittanceAdviceInvoice>
            >("invoices", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Invoices)
        {
            item.Validate();
        }
    }

    public AchTransferAddendaPaymentOrderRemittanceAdvice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferAddendaPaymentOrderRemittanceAdvice(
        AchTransferAddendaPaymentOrderRemittanceAdvice achTransferAddendaPaymentOrderRemittanceAdvice
    )
        : base(achTransferAddendaPaymentOrderRemittanceAdvice) { }
#pragma warning restore CS8618

    public AchTransferAddendaPaymentOrderRemittanceAdvice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AchTransferAddendaPaymentOrderRemittanceAdvice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AchTransferAddendaPaymentOrderRemittanceAdviceFromRaw.FromRawUnchecked"/>
    public static AchTransferAddendaPaymentOrderRemittanceAdvice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AchTransferAddendaPaymentOrderRemittanceAdvice(
        IReadOnlyList<AchTransferAddendaPaymentOrderRemittanceAdviceInvoice> invoices
    )
        : this()
    {
        this.Invoices = invoices;
    }
}

class AchTransferAddendaPaymentOrderRemittanceAdviceFromRaw
    : IFromRawJson<AchTransferAddendaPaymentOrderRemittanceAdvice>
{
    /// <inheritdoc/>
    public AchTransferAddendaPaymentOrderRemittanceAdvice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AchTransferAddendaPaymentOrderRemittanceAdvice.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        AchTransferAddendaPaymentOrderRemittanceAdviceInvoice,
        AchTransferAddendaPaymentOrderRemittanceAdviceInvoiceFromRaw
    >)
)]
public sealed record class AchTransferAddendaPaymentOrderRemittanceAdviceInvoice : JsonModel
{
    /// <summary>
    /// The invoice number for this reference, determined in advance with the receiver.
    /// </summary>
    public required string InvoiceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("invoice_number");
        }
        init { this._rawData.Set("invoice_number", value); }
    }

    /// <summary>
    /// The amount that was paid for this invoice in the minor unit of its currency.
    /// For dollars, for example, this is cents.
    /// </summary>
    public required long PaidAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("paid_amount");
        }
        init { this._rawData.Set("paid_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InvoiceNumber;
        _ = this.PaidAmount;
    }

    public AchTransferAddendaPaymentOrderRemittanceAdviceInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferAddendaPaymentOrderRemittanceAdviceInvoice(
        AchTransferAddendaPaymentOrderRemittanceAdviceInvoice achTransferAddendaPaymentOrderRemittanceAdviceInvoice
    )
        : base(achTransferAddendaPaymentOrderRemittanceAdviceInvoice) { }
#pragma warning restore CS8618

    public AchTransferAddendaPaymentOrderRemittanceAdviceInvoice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AchTransferAddendaPaymentOrderRemittanceAdviceInvoice(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AchTransferAddendaPaymentOrderRemittanceAdviceInvoiceFromRaw.FromRawUnchecked"/>
    public static AchTransferAddendaPaymentOrderRemittanceAdviceInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AchTransferAddendaPaymentOrderRemittanceAdviceInvoiceFromRaw
    : IFromRawJson<AchTransferAddendaPaymentOrderRemittanceAdviceInvoice>
{
    /// <inheritdoc/>
    public AchTransferAddendaPaymentOrderRemittanceAdviceInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AchTransferAddendaPaymentOrderRemittanceAdviceInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// If your account requires approvals for transfers and the transfer was approved,
/// this will contain details of the approval.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Approval, ApprovalFromRaw>))]
public sealed record class Approval : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the transfer was approved.
    /// </summary>
    public required System::DateTimeOffset ApprovedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("approved_at");
        }
        init { this._rawData.Set("approved_at", value); }
    }

    /// <summary>
    /// If the Transfer was approved by a user in the dashboard, the email address
    /// of that user.
    /// </summary>
    public required string? ApprovedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("approved_by");
        }
        init { this._rawData.Set("approved_by", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApprovedAt;
        _ = this.ApprovedBy;
    }

    public Approval() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Approval(Approval approval)
        : base(approval) { }
#pragma warning restore CS8618

    public Approval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Approval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApprovalFromRaw.FromRawUnchecked"/>
    public static Approval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApprovalFromRaw : IFromRawJson<Approval>
{
    /// <inheritdoc/>
    public Approval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Approval.FromRawUnchecked(rawData);
}

/// <summary>
/// If your account requires approvals for transfers and the transfer was not approved,
/// this will contain details of the cancellation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Cancellation, CancellationFromRaw>))]
public sealed record class Cancellation : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Transfer was canceled.
    /// </summary>
    public required System::DateTimeOffset CanceledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("canceled_at");
        }
        init { this._rawData.Set("canceled_at", value); }
    }

    /// <summary>
    /// If the Transfer was canceled by a user in the dashboard, the email address
    /// of that user.
    /// </summary>
    public required string? CanceledBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("canceled_by");
        }
        init { this._rawData.Set("canceled_by", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanceledAt;
        _ = this.CanceledBy;
    }

    public Cancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cancellation(Cancellation cancellation)
        : base(cancellation) { }
#pragma warning restore CS8618

    public Cancellation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Cancellation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CancellationFromRaw.FromRawUnchecked"/>
    public static Cancellation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CancellationFromRaw : IFromRawJson<Cancellation>
{
    /// <inheritdoc/>
    public Cancellation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Cancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// What object created the transfer, either via the API or the dashboard.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreatedBy, CreatedByFromRaw>))]
public sealed record class CreatedBy : JsonModel
{
    /// <summary>
    /// The type of object that created this transfer.
    /// </summary>
    public required ApiEnum<string, CreatedByCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CreatedByCategory>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// If present, details about the API key that created the transfer.
    /// </summary>
    public ApiKey? ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiKey>("api_key");
        }
        init { this._rawData.Set("api_key", value); }
    }

    /// <summary>
    /// If present, details about the OAuth Application that created the transfer.
    /// </summary>
    public OAuthApplication? OAuthApplication
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OAuthApplication>("oauth_application");
        }
        init { this._rawData.Set("oauth_application", value); }
    }

    /// <summary>
    /// If present, details about the User that created the transfer.
    /// </summary>
    public User? User
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<User>("user");
        }
        init { this._rawData.Set("user", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.ApiKey?.Validate();
        this.OAuthApplication?.Validate();
        this.User?.Validate();
    }

    public CreatedBy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatedBy(CreatedBy createdBy)
        : base(createdBy) { }
#pragma warning restore CS8618

    public CreatedBy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatedBy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatedByFromRaw.FromRawUnchecked"/>
    public static CreatedBy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CreatedBy(ApiEnum<string, CreatedByCategory> category)
        : this()
    {
        this.Category = category;
    }
}

class CreatedByFromRaw : IFromRawJson<CreatedBy>
{
    /// <inheritdoc/>
    public CreatedBy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreatedBy.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of object that created this transfer.
/// </summary>
[JsonConverter(typeof(CreatedByCategoryConverter))]
public enum CreatedByCategory
{
    /// <summary>
    /// An API key. Details will be under the `api_key` object.
    /// </summary>
    ApiKey,

    /// <summary>
    /// An OAuth application you connected to Increase. Details will be under the
    /// `oauth_application` object.
    /// </summary>
    OAuthApplication,

    /// <summary>
    /// A User in the Increase dashboard. Details will be under the `user` object.
    /// </summary>
    User,
}

sealed class CreatedByCategoryConverter : JsonConverter<CreatedByCategory>
{
    public override CreatedByCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "api_key" => CreatedByCategory.ApiKey,
            "oauth_application" => CreatedByCategory.OAuthApplication,
            "user" => CreatedByCategory.User,
            _ => (CreatedByCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreatedByCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreatedByCategory.ApiKey => "api_key",
                CreatedByCategory.OAuthApplication => "oauth_application",
                CreatedByCategory.User => "user",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If present, details about the API key that created the transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ApiKey, ApiKeyFromRaw>))]
public sealed record class ApiKey : JsonModel
{
    /// <summary>
    /// The description set for the API key when it was created.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
    }

    public ApiKey() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKey(ApiKey apiKey)
        : base(apiKey) { }
#pragma warning restore CS8618

    public ApiKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyFromRaw.FromRawUnchecked"/>
    public static ApiKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ApiKey(string? description)
        : this()
    {
        this.Description = description;
    }
}

class ApiKeyFromRaw : IFromRawJson<ApiKey>
{
    /// <inheritdoc/>
    public ApiKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ApiKey.FromRawUnchecked(rawData);
}

/// <summary>
/// If present, details about the OAuth Application that created the transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OAuthApplication, OAuthApplicationFromRaw>))]
public sealed record class OAuthApplication : JsonModel
{
    /// <summary>
    /// The name of the OAuth Application.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public OAuthApplication() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthApplication(OAuthApplication oauthApplication)
        : base(oauthApplication) { }
#pragma warning restore CS8618

    public OAuthApplication(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthApplication(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OAuthApplicationFromRaw.FromRawUnchecked"/>
    public static OAuthApplication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OAuthApplication(string name)
        : this()
    {
        this.Name = name;
    }
}

class OAuthApplicationFromRaw : IFromRawJson<OAuthApplication>
{
    /// <inheritdoc/>
    public OAuthApplication FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OAuthApplication.FromRawUnchecked(rawData);
}

/// <summary>
/// If present, details about the User that created the transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<User, UserFromRaw>))]
public sealed record class User : JsonModel
{
    /// <summary>
    /// The email address of the User.
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
    }

    public User() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public User(User user)
        : base(user) { }
#pragma warning restore CS8618

    public User(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    User(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserFromRaw.FromRawUnchecked"/>
    public static User FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public User(string email)
        : this()
    {
        this.Email = email;
    }
}

class UserFromRaw : IFromRawJson<User>
{
    /// <inheritdoc/>
    public User FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        User.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transfer's
/// currency. For ACH transfers this is always equal to `usd`.
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
/// The type of entity that owns the account to which the ACH Transfer is being sent.
/// </summary>
[JsonConverter(typeof(AchTransferDestinationAccountHolderConverter))]
public enum AchTransferDestinationAccountHolder
{
    /// <summary>
    /// The External Account is owned by a business.
    /// </summary>
    Business,

    /// <summary>
    /// The External Account is owned by an individual.
    /// </summary>
    Individual,

    /// <summary>
    /// It's unknown what kind of entity owns the External Account.
    /// </summary>
    Unknown,
}

sealed class AchTransferDestinationAccountHolderConverter
    : JsonConverter<AchTransferDestinationAccountHolder>
{
    public override AchTransferDestinationAccountHolder Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "business" => AchTransferDestinationAccountHolder.Business,
            "individual" => AchTransferDestinationAccountHolder.Individual,
            "unknown" => AchTransferDestinationAccountHolder.Unknown,
            _ => (AchTransferDestinationAccountHolder)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AchTransferDestinationAccountHolder value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AchTransferDestinationAccountHolder.Business => "business",
                AchTransferDestinationAccountHolder.Individual => "individual",
                AchTransferDestinationAccountHolder.Unknown => "unknown",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of the account to which the transfer will be sent.
/// </summary>
[JsonConverter(typeof(AchTransferFundingConverter))]
public enum AchTransferFunding
{
    /// <summary>
    /// A checking account.
    /// </summary>
    Checking,

    /// <summary>
    /// A savings account.
    /// </summary>
    Savings,

    /// <summary>
    /// A bank's general ledger. Uncommon.
    /// </summary>
    GeneralLedger,
}

sealed class AchTransferFundingConverter : JsonConverter<AchTransferFunding>
{
    public override AchTransferFunding Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "checking" => AchTransferFunding.Checking,
            "savings" => AchTransferFunding.Savings,
            "general_ledger" => AchTransferFunding.GeneralLedger,
            _ => (AchTransferFunding)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AchTransferFunding value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AchTransferFunding.Checking => "checking",
                AchTransferFunding.Savings => "savings",
                AchTransferFunding.GeneralLedger => "general_ledger",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Increase will sometimes hold the funds for ACH debit transfers. If funds are held,
/// this sub-object will contain details of the hold.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InboundFundsHold, InboundFundsHoldFromRaw>))]
public sealed record class InboundFundsHold : JsonModel
{
    /// <summary>
    /// The held amount in the minor unit of the account's currency. For dollars,
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
    /// When the hold will be released automatically. Certain conditions may cause
    /// it to be released before this time.
    /// </summary>
    public required System::DateTimeOffset AutomaticallyReleasesAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "automatically_releases_at"
            );
        }
        init { this._rawData.Set("automatically_releases_at", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the hold
    /// was created.
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the hold's currency.
    /// </summary>
    public required ApiEnum<string, InboundFundsHoldCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InboundFundsHoldCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The ID of the Transaction for which funds were held.
    /// </summary>
    public required string? HeldTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("held_transaction_id");
        }
        init { this._rawData.Set("held_transaction_id", value); }
    }

    /// <summary>
    /// The ID of the Pending Transaction representing the held funds.
    /// </summary>
    public required string? PendingTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pending_transaction_id");
        }
        init { this._rawData.Set("pending_transaction_id", value); }
    }

    /// <summary>
    /// When the hold was released (if it has been released).
    /// </summary>
    public required System::DateTimeOffset? ReleasedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("released_at");
        }
        init { this._rawData.Set("released_at", value); }
    }

    /// <summary>
    /// The status of the hold.
    /// </summary>
    public required ApiEnum<string, InboundFundsHoldStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InboundFundsHoldStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `inbound_funds_hold`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.AchTransfers.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.AchTransfers.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.AutomaticallyReleasesAt;
        _ = this.CreatedAt;
        this.Currency.Validate();
        _ = this.HeldTransactionID;
        _ = this.PendingTransactionID;
        _ = this.ReleasedAt;
        this.Status.Validate();
        this.Type.Validate();
    }

    public InboundFundsHold() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundFundsHold(InboundFundsHold inboundFundsHold)
        : base(inboundFundsHold) { }
#pragma warning restore CS8618

    public InboundFundsHold(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundFundsHold(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundFundsHoldFromRaw.FromRawUnchecked"/>
    public static InboundFundsHold FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundFundsHoldFromRaw : IFromRawJson<InboundFundsHold>
{
    /// <inheritdoc/>
    public InboundFundsHold FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InboundFundsHold.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the hold's currency.
/// </summary>
[JsonConverter(typeof(InboundFundsHoldCurrencyConverter))]
public enum InboundFundsHoldCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class InboundFundsHoldCurrencyConverter : JsonConverter<InboundFundsHoldCurrency>
{
    public override InboundFundsHoldCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => InboundFundsHoldCurrency.Usd,
            _ => (InboundFundsHoldCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundFundsHoldCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InboundFundsHoldCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the hold.
/// </summary>
[JsonConverter(typeof(InboundFundsHoldStatusConverter))]
public enum InboundFundsHoldStatus
{
    /// <summary>
    /// Funds are still being held.
    /// </summary>
    Held,

    /// <summary>
    /// Funds have been released.
    /// </summary>
    Complete,
}

sealed class InboundFundsHoldStatusConverter : JsonConverter<InboundFundsHoldStatus>
{
    public override InboundFundsHoldStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "held" => InboundFundsHoldStatus.Held,
            "complete" => InboundFundsHoldStatus.Complete,
            _ => (InboundFundsHoldStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundFundsHoldStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InboundFundsHoldStatus.Held => "held",
                InboundFundsHoldStatus.Complete => "complete",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `inbound_funds_hold`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    InboundFundsHold,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.AchTransfers.Type>
{
    public override global::Increase.Api.Models.AchTransfers.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_funds_hold" => global::Increase.Api.Models.AchTransfers.Type.InboundFundsHold,
            _ => (global::Increase.Api.Models.AchTransfers.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.AchTransfers.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.AchTransfers.Type.InboundFundsHold =>
                    "inbound_funds_hold",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The transfer's network.
/// </summary>
[JsonConverter(typeof(NetworkConverter))]
public enum Network
{
    Ach,
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
            "ach" => Network.Ach,
            _ => (Network)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Network value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Network.Ach => "ach",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<NotificationsOfChange, NotificationsOfChangeFromRaw>))]
public sealed record class NotificationsOfChange : JsonModel
{
    /// <summary>
    /// The required type of change that is being signaled by the receiving financial institution.
    /// </summary>
    public required ApiEnum<string, ChangeCode> ChangeCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ChangeCode>>("change_code");
        }
        init { this._rawData.Set("change_code", value); }
    }

    /// <summary>
    /// The corrected data that should be used in future ACHs to this account. This
    /// may contain the suggested new account number or routing number. When the
    /// `change_code` is `incorrect_transaction_code`, this field contains an integer.
    /// Numbers starting with a 2 encourage changing the `funding` parameter to checking;
    /// numbers starting with a 3 encourage changing to savings.
    /// </summary>
    public required string CorrectedData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("corrected_data");
        }
        init { this._rawData.Set("corrected_data", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the notification occurred.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ChangeCode.Validate();
        _ = this.CorrectedData;
        _ = this.CreatedAt;
    }

    public NotificationsOfChange() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationsOfChange(NotificationsOfChange notificationsOfChange)
        : base(notificationsOfChange) { }
#pragma warning restore CS8618

    public NotificationsOfChange(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationsOfChange(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationsOfChangeFromRaw.FromRawUnchecked"/>
    public static NotificationsOfChange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationsOfChangeFromRaw : IFromRawJson<NotificationsOfChange>
{
    /// <inheritdoc/>
    public NotificationsOfChange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationsOfChange.FromRawUnchecked(rawData);
}

/// <summary>
/// The required type of change that is being signaled by the receiving financial institution.
/// </summary>
[JsonConverter(typeof(ChangeCodeConverter))]
public enum ChangeCode
{
    /// <summary>
    /// The account number was incorrect.
    /// </summary>
    IncorrectAccountNumber,

    /// <summary>
    /// The routing number was incorrect.
    /// </summary>
    IncorrectRoutingNumber,

    /// <summary>
    /// Both the routing number and the account number were incorrect.
    /// </summary>
    IncorrectRoutingNumberAndAccountNumber,

    /// <summary>
    /// The transaction code was incorrect. Try changing the `funding` parameter
    /// from checking to savings or vice-versa.
    /// </summary>
    IncorrectTransactionCode,

    /// <summary>
    /// The account number and the transaction code were incorrect.
    /// </summary>
    IncorrectAccountNumberAndTransactionCode,

    /// <summary>
    /// The routing number, account number, and transaction code were incorrect.
    /// </summary>
    IncorrectRoutingNumberAccountNumberAndTransactionCode,

    /// <summary>
    /// The receiving depository financial institution identification was incorrect.
    /// </summary>
    IncorrectReceivingDepositoryFinancialInstitutionIdentification,

    /// <summary>
    /// The individual identification number was incorrect.
    /// </summary>
    IncorrectIndividualIdentificationNumber,

    /// <summary>
    /// The addenda had an incorrect format.
    /// </summary>
    AddendaFormatError,

    /// <summary>
    /// The standard entry class code was incorrect for an outbound international payment.
    /// </summary>
    IncorrectStandardEntryClassCodeForOutboundInternationalPayment,

    /// <summary>
    /// The notification of change was misrouted.
    /// </summary>
    MisroutedNotificationOfChange,

    /// <summary>
    /// The trace number was incorrect.
    /// </summary>
    IncorrectTraceNumber,

    /// <summary>
    /// The company identification number was incorrect.
    /// </summary>
    IncorrectCompanyIdentificationNumber,

    /// <summary>
    /// The individual identification number or identification number was incorrect.
    /// </summary>
    IncorrectIdentificationNumber,

    /// <summary>
    /// The corrected data was incorrectly formatted.
    /// </summary>
    IncorrectlyFormattedCorrectedData,

    /// <summary>
    /// The discretionary data was incorrect.
    /// </summary>
    IncorrectDiscretionaryData,

    /// <summary>
    /// The routing number was not from the original entry detail record.
    /// </summary>
    RoutingNumberNotFromOriginalEntryDetailRecord,

    /// <summary>
    /// The depository financial institution account number was not from the original
    /// entry detail record.
    /// </summary>
    DepositoryFinancialInstitutionAccountNumberNotFromOriginalEntryDetailRecord,

    /// <summary>
    /// The transaction code was incorrect, initiated by the originating depository
    /// financial institution.
    /// </summary>
    IncorrectTransactionCodeByOriginatingDepositoryFinancialInstitution,
}

sealed class ChangeCodeConverter : JsonConverter<ChangeCode>
{
    public override ChangeCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "incorrect_account_number" => ChangeCode.IncorrectAccountNumber,
            "incorrect_routing_number" => ChangeCode.IncorrectRoutingNumber,
            "incorrect_routing_number_and_account_number" =>
                ChangeCode.IncorrectRoutingNumberAndAccountNumber,
            "incorrect_transaction_code" => ChangeCode.IncorrectTransactionCode,
            "incorrect_account_number_and_transaction_code" =>
                ChangeCode.IncorrectAccountNumberAndTransactionCode,
            "incorrect_routing_number_account_number_and_transaction_code" =>
                ChangeCode.IncorrectRoutingNumberAccountNumberAndTransactionCode,
            "incorrect_receiving_depository_financial_institution_identification" =>
                ChangeCode.IncorrectReceivingDepositoryFinancialInstitutionIdentification,
            "incorrect_individual_identification_number" =>
                ChangeCode.IncorrectIndividualIdentificationNumber,
            "addenda_format_error" => ChangeCode.AddendaFormatError,
            "incorrect_standard_entry_class_code_for_outbound_international_payment" =>
                ChangeCode.IncorrectStandardEntryClassCodeForOutboundInternationalPayment,
            "misrouted_notification_of_change" => ChangeCode.MisroutedNotificationOfChange,
            "incorrect_trace_number" => ChangeCode.IncorrectTraceNumber,
            "incorrect_company_identification_number" =>
                ChangeCode.IncorrectCompanyIdentificationNumber,
            "incorrect_identification_number" => ChangeCode.IncorrectIdentificationNumber,
            "incorrectly_formatted_corrected_data" => ChangeCode.IncorrectlyFormattedCorrectedData,
            "incorrect_discretionary_data" => ChangeCode.IncorrectDiscretionaryData,
            "routing_number_not_from_original_entry_detail_record" =>
                ChangeCode.RoutingNumberNotFromOriginalEntryDetailRecord,
            "depository_financial_institution_account_number_not_from_original_entry_detail_record" =>
                ChangeCode.DepositoryFinancialInstitutionAccountNumberNotFromOriginalEntryDetailRecord,
            "incorrect_transaction_code_by_originating_depository_financial_institution" =>
                ChangeCode.IncorrectTransactionCodeByOriginatingDepositoryFinancialInstitution,
            _ => (ChangeCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChangeCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChangeCode.IncorrectAccountNumber => "incorrect_account_number",
                ChangeCode.IncorrectRoutingNumber => "incorrect_routing_number",
                ChangeCode.IncorrectRoutingNumberAndAccountNumber =>
                    "incorrect_routing_number_and_account_number",
                ChangeCode.IncorrectTransactionCode => "incorrect_transaction_code",
                ChangeCode.IncorrectAccountNumberAndTransactionCode =>
                    "incorrect_account_number_and_transaction_code",
                ChangeCode.IncorrectRoutingNumberAccountNumberAndTransactionCode =>
                    "incorrect_routing_number_account_number_and_transaction_code",
                ChangeCode.IncorrectReceivingDepositoryFinancialInstitutionIdentification =>
                    "incorrect_receiving_depository_financial_institution_identification",
                ChangeCode.IncorrectIndividualIdentificationNumber =>
                    "incorrect_individual_identification_number",
                ChangeCode.AddendaFormatError => "addenda_format_error",
                ChangeCode.IncorrectStandardEntryClassCodeForOutboundInternationalPayment =>
                    "incorrect_standard_entry_class_code_for_outbound_international_payment",
                ChangeCode.MisroutedNotificationOfChange => "misrouted_notification_of_change",
                ChangeCode.IncorrectTraceNumber => "incorrect_trace_number",
                ChangeCode.IncorrectCompanyIdentificationNumber =>
                    "incorrect_company_identification_number",
                ChangeCode.IncorrectIdentificationNumber => "incorrect_identification_number",
                ChangeCode.IncorrectlyFormattedCorrectedData =>
                    "incorrectly_formatted_corrected_data",
                ChangeCode.IncorrectDiscretionaryData => "incorrect_discretionary_data",
                ChangeCode.RoutingNumberNotFromOriginalEntryDetailRecord =>
                    "routing_number_not_from_original_entry_detail_record",
                ChangeCode.DepositoryFinancialInstitutionAccountNumberNotFromOriginalEntryDetailRecord =>
                    "depository_financial_institution_account_number_not_from_original_entry_detail_record",
                ChangeCode.IncorrectTransactionCodeByOriginatingDepositoryFinancialInstitution =>
                    "incorrect_transaction_code_by_originating_depository_financial_institution",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for how the effective date of the transfer will be set. This determines
/// same-day vs future-dated settlement timing. If not set, defaults to a `settlement_schedule`
/// of `same_day`. If set, exactly one of the child attributes must be set.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AchTransferPreferredEffectiveDate,
        AchTransferPreferredEffectiveDateFromRaw
    >)
)]
public sealed record class AchTransferPreferredEffectiveDate : JsonModel
{
    /// <summary>
    /// A specific date in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format
    /// to use as the effective date when submitting this transfer.
    /// </summary>
    public required string? Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("date");
        }
        init { this._rawData.Set("date", value); }
    }

    /// <summary>
    /// A schedule by which Increase will choose an effective date for the transfer.
    /// </summary>
    public required ApiEnum<
        string,
        AchTransferPreferredEffectiveDateSettlementSchedule
    >? SettlementSchedule
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, AchTransferPreferredEffectiveDateSettlementSchedule>
            >("settlement_schedule");
        }
        init { this._rawData.Set("settlement_schedule", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Date;
        this.SettlementSchedule?.Validate();
    }

    public AchTransferPreferredEffectiveDate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferPreferredEffectiveDate(
        AchTransferPreferredEffectiveDate achTransferPreferredEffectiveDate
    )
        : base(achTransferPreferredEffectiveDate) { }
#pragma warning restore CS8618

    public AchTransferPreferredEffectiveDate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AchTransferPreferredEffectiveDate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AchTransferPreferredEffectiveDateFromRaw.FromRawUnchecked"/>
    public static AchTransferPreferredEffectiveDate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AchTransferPreferredEffectiveDateFromRaw : IFromRawJson<AchTransferPreferredEffectiveDate>
{
    /// <inheritdoc/>
    public AchTransferPreferredEffectiveDate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AchTransferPreferredEffectiveDate.FromRawUnchecked(rawData);
}

/// <summary>
/// A schedule by which Increase will choose an effective date for the transfer.
/// </summary>
[JsonConverter(typeof(AchTransferPreferredEffectiveDateSettlementScheduleConverter))]
public enum AchTransferPreferredEffectiveDateSettlementSchedule
{
    /// <summary>
    /// The chosen effective date will be the same as the ACH processing date on
    /// which the transfer is submitted. This is necessary, but not sufficient for
    /// the transfer to be settled same-day: it must also be submitted before the
    /// last same-day cutoff and be less than or equal to $1,000.000.00.
    /// </summary>
    SameDay,

    /// <summary>
    /// The chosen effective date will be the business day following the ACH processing
    /// date on which the transfer is submitted. The transfer will be settled on
    /// that future day.
    /// </summary>
    FutureDated,
}

sealed class AchTransferPreferredEffectiveDateSettlementScheduleConverter
    : JsonConverter<AchTransferPreferredEffectiveDateSettlementSchedule>
{
    public override AchTransferPreferredEffectiveDateSettlementSchedule Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "same_day" => AchTransferPreferredEffectiveDateSettlementSchedule.SameDay,
            "future_dated" => AchTransferPreferredEffectiveDateSettlementSchedule.FutureDated,
            _ => (AchTransferPreferredEffectiveDateSettlementSchedule)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AchTransferPreferredEffectiveDateSettlementSchedule value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AchTransferPreferredEffectiveDateSettlementSchedule.SameDay => "same_day",
                AchTransferPreferredEffectiveDateSettlementSchedule.FutureDated => "future_dated",
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
[JsonConverter(typeof(JsonModelConverter<Return, ReturnFromRaw>))]
public sealed record class Return : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the transfer was created.
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
    /// The three character ACH return code, in the range R01 to R85.
    /// </summary>
    public required string RawReturnReasonCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("raw_return_reason_code");
        }
        init { this._rawData.Set("raw_return_reason_code", value); }
    }

    /// <summary>
    /// Why the ACH Transfer was returned. This reason code is sent by the receiving
    /// bank back to Increase.
    /// </summary>
    public required ApiEnum<string, ReturnReasonCode> ReturnReasonCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ReturnReasonCode>>(
                "return_reason_code"
            );
        }
        init { this._rawData.Set("return_reason_code", value); }
    }

    /// <summary>
    /// A 15 digit number that was generated by the bank that initiated the return.
    /// The trace number of the return is different than that of the original transfer.
    /// ACH trace numbers are not unique, but along with the amount and date this
    /// number can be used to identify the ACH return at the bank that initiated it.
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
    /// The identifier of the Transaction associated with this return.
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

    /// <summary>
    /// The identifier of the ACH Transfer associated with this return.
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
        _ = this.CreatedAt;
        _ = this.RawReturnReasonCode;
        this.ReturnReasonCode.Validate();
        _ = this.TraceNumber;
        _ = this.TransactionID;
        _ = this.TransferID;
    }

    public Return() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Return(Return return_)
        : base(return_) { }
#pragma warning restore CS8618

    public Return(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Return(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReturnFromRaw.FromRawUnchecked"/>
    public static Return FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReturnFromRaw : IFromRawJson<Return>
{
    /// <inheritdoc/>
    public Return FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Return.FromRawUnchecked(rawData);
}

/// <summary>
/// Why the ACH Transfer was returned. This reason code is sent by the receiving
/// bank back to Increase.
/// </summary>
[JsonConverter(typeof(ReturnReasonCodeConverter))]
public enum ReturnReasonCode
{
    /// <summary>
    /// Code R01. Insufficient funds in the receiving account. Sometimes abbreviated
    /// to "NSF."
    /// </summary>
    InsufficientFund,

    /// <summary>
    /// Code R03. The account does not exist or the receiving bank was unable to
    /// locate it.
    /// </summary>
    NoAccount,

    /// <summary>
    /// Code R02. The account is closed at the receiving bank.
    /// </summary>
    AccountClosed,

    /// <summary>
    /// Code R04. The account number is invalid at the receiving bank.
    /// </summary>
    InvalidAccountNumberStructure,

    /// <summary>
    /// Code R16. This return code has two separate meanings. (1) The receiving bank
    /// froze the account or (2) the Office of Foreign Assets Control (OFAC) instructed
    /// the receiving bank to return the entry.
    /// </summary>
    AccountFrozenEntryReturnedPerOfacInstruction,

    /// <summary>
    /// Code R23. The receiving bank refused the credit transfer.
    /// </summary>
    CreditEntryRefusedByReceiver,

    /// <summary>
    /// Code R05. The receiving bank rejected because of an incorrect Standard Entry
    /// Class code. Consumer accounts cannot be debited as `corporate_credit_or_debit`
    /// or `corporate_trade_exchange`.
    /// </summary>
    UnauthorizedDebitToConsumerAccountUsingCorporateSecCode,

    /// <summary>
    /// Code R29. The corporate customer at the receiving bank reversed the transfer.
    /// </summary>
    CorporateCustomerAdvisedNotAuthorized,

    /// <summary>
    /// Code R08. The receiving bank stopped payment on this transfer.
    /// </summary>
    PaymentStopped,

    /// <summary>
    /// Code R20. The account is not eligible for ACH, such as a savings account
    /// with transaction limits.
    /// </summary>
    NonTransactionAccount,

    /// <summary>
    /// Code R09. The receiving bank account does not have enough available balance
    /// for the transfer.
    /// </summary>
    UncollectedFunds,

    /// <summary>
    /// Code R28. The routing number is incorrect.
    /// </summary>
    RoutingNumberCheckDigitError,

    /// <summary>
    /// Code R10. The customer at the receiving bank reversed the transfer.
    /// </summary>
    CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete,

    /// <summary>
    /// Code R19. The amount field is incorrect or too large.
    /// </summary>
    AmountFieldError,

    /// <summary>
    /// Code R07. The customer revoked their authorization for a previously authorized transfer.
    /// </summary>
    AuthorizationRevokedByCustomer,

    /// <summary>
    /// Code R13. The routing number is invalid.
    /// </summary>
    InvalidAchRoutingNumber,

    /// <summary>
    /// Code R17. The receiving bank is unable to process a field in the transfer.
    /// </summary>
    FileRecordEditCriteria,

    /// <summary>
    /// Code R45. A rare return reason. The individual name field was invalid.
    /// </summary>
    EnrInvalidIndividualName,

    /// <summary>
    /// Code R06. The originating financial institution asked for this transfer to
    /// be returned. The receiving bank is complying with the request.
    /// </summary>
    ReturnedPerOdfiRequest,

    /// <summary>
    /// Code R34. The receiving bank's regulatory supervisor has limited their participation
    /// in the ACH network.
    /// </summary>
    LimitedParticipationDfi,

    /// <summary>
    /// Code R85. The outbound international ACH transfer was incorrect.
    /// </summary>
    IncorrectlyCodedOutboundInternationalPayment,

    /// <summary>
    /// Code R12. A rare return reason. The account was sold to another bank.
    /// </summary>
    AccountSoldToAnotherDfi,

    /// <summary>
    /// Code R25. The addenda record is incorrect or missing.
    /// </summary>
    AddendaError,

    /// <summary>
    /// Code R15. A rare return reason. The account holder is deceased.
    /// </summary>
    BeneficiaryOrAccountHolderDeceased,

    /// <summary>
    /// Code R11. A rare return reason. The customer authorized some payment to the
    /// sender, but this payment was not in error.
    /// </summary>
    CustomerAdvisedNotWithinAuthorizationTerms,

    /// <summary>
    /// Code R74. A rare return reason. Sent in response to a return that was returned
    /// with code `field_error`. The latest return should include the corrected field(s).
    /// </summary>
    CorrectedReturn,

    /// <summary>
    /// Code R24. A rare return reason. The receiving bank received an exact duplicate
    /// entry with the same trace number and amount.
    /// </summary>
    DuplicateEntry,

    /// <summary>
    /// Code R67. A rare return reason. The return this message refers to was a duplicate.
    /// </summary>
    DuplicateReturn,

    /// <summary>
    /// Code R47. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrDuplicateEnrollment,

    /// <summary>
    /// Code R43. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrInvalidDfiAccountNumber,

    /// <summary>
    /// Code R44. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrInvalidIndividualIDNumber,

    /// <summary>
    /// Code R46. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrInvalidRepresentativePayeeIndicator,

    /// <summary>
    /// Code R41. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrInvalidTransactionCode,

    /// <summary>
    /// Code R40. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrReturnOfEnrEntry,

    /// <summary>
    /// Code R42. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrRoutingNumberCheckDigitError,

    /// <summary>
    /// Code R84. A rare return reason. The International ACH Transfer cannot be
    /// processed by the gateway.
    /// </summary>
    EntryNotProcessedByGateway,

    /// <summary>
    /// Code R69. A rare return reason. One or more of the fields in the ACH were malformed.
    /// </summary>
    FieldError,

    /// <summary>
    /// Code R83. A rare return reason. The Foreign receiving bank was unable to settle
    /// this ACH transfer.
    /// </summary>
    ForeignReceivingDfiUnableToSettle,

    /// <summary>
    /// Code R80. A rare return reason. The International ACH Transfer is malformed.
    /// </summary>
    IatEntryCodingError,

    /// <summary>
    /// Code R18. A rare return reason. The ACH has an improper effective entry date field.
    /// </summary>
    ImproperEffectiveEntryDate,

    /// <summary>
    /// Code R39. A rare return reason. The source document related to this ACH, usually
    /// an ACH check conversion, was presented to the bank.
    /// </summary>
    ImproperSourceDocumentSourceDocumentPresented,

    /// <summary>
    /// Code R21. A rare return reason. The Company ID field of the ACH was invalid.
    /// </summary>
    InvalidCompanyID,

    /// <summary>
    /// Code R82. A rare return reason. The foreign receiving bank identifier for
    /// an International ACH Transfer was invalid.
    /// </summary>
    InvalidForeignReceivingDfiIdentification,

    /// <summary>
    /// Code R22. A rare return reason. The Individual ID number field of the ACH
    /// was invalid.
    /// </summary>
    InvalidIndividualIDNumber,

    /// <summary>
    /// Code R53. A rare return reason. Both the Represented Check ("RCK") entry
    /// and the original check were presented to the bank.
    /// </summary>
    ItemAndRckEntryPresentedForPayment,

    /// <summary>
    /// Code R51. A rare return reason. The Represented Check ("RCK") entry is ineligible.
    /// </summary>
    ItemRelatedToRckEntryIsIneligible,

    /// <summary>
    /// Code R26. A rare return reason. The ACH is missing a required field.
    /// </summary>
    MandatoryFieldError,

    /// <summary>
    /// Code R71. A rare return reason. The receiving bank does not recognize the
    /// routing number in a dishonored return entry.
    /// </summary>
    MisroutedDishonoredReturn,

    /// <summary>
    /// Code R61. A rare return reason. The receiving bank does not recognize the
    /// routing number in a return entry.
    /// </summary>
    MisroutedReturn,

    /// <summary>
    /// Code R76. A rare return reason. Sent in response to a return, the bank does
    /// not find the errors alleged by the returning bank.
    /// </summary>
    NoErrorsFound,

    /// <summary>
    /// Code R77. A rare return reason. The receiving bank does not accept the return
    /// of the erroneous debit. The funds are not available at the receiving bank.
    /// </summary>
    NonAcceptanceOfR62DishonoredReturn,

    /// <summary>
    /// Code R81. A rare return reason. The receiving bank does not accept International
    /// ACH Transfers.
    /// </summary>
    NonParticipantInIatProgram,

    /// <summary>
    /// Code R31. A rare return reason. A return that has been agreed to be accepted
    /// by the receiving bank, despite falling outside of the usual return timeframe.
    /// </summary>
    PermissibleReturnEntry,

    /// <summary>
    /// Code R70. A rare return reason. The receiving bank had not approved this return.
    /// </summary>
    PermissibleReturnEntryNotAccepted,

    /// <summary>
    /// Code R32. A rare return reason. The receiving bank could not settle this transaction.
    /// </summary>
    RdfiNonSettlement,

    /// <summary>
    /// Code R30. A rare return reason. The receiving bank does not accept Check Truncation
    /// ACH transfers.
    /// </summary>
    RdfiParticipantInCheckTruncationProgram,

    /// <summary>
    /// Code R14. A rare return reason. The payee is deceased.
    /// </summary>
    RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity,

    /// <summary>
    /// Code R75. A rare return reason. The originating bank disputes that an earlier
    /// `duplicate_entry` return was actually a duplicate.
    /// </summary>
    ReturnNotADuplicate,

    /// <summary>
    /// Code R62. A rare return reason. The originating financial institution made
    /// a mistake and this return corrects it.
    /// </summary>
    ReturnOfErroneousOrReversingDebit,

    /// <summary>
    /// Code R36. A rare return reason. Return of a malformed credit entry.
    /// </summary>
    ReturnOfImproperCreditEntry,

    /// <summary>
    /// Code R35. A rare return reason. Return of a malformed debit entry.
    /// </summary>
    ReturnOfImproperDebitEntry,

    /// <summary>
    /// Code R33. A rare return reason. Return of a destroyed check ("XCK") entry.
    /// </summary>
    ReturnOfXckEntry,

    /// <summary>
    /// Code R37. A rare return reason. The source document related to this ACH, usually
    /// an ACH check conversion, was presented to the bank.
    /// </summary>
    SourceDocumentPresentedForPayment,

    /// <summary>
    /// Code R50. A rare return reason. State law prevents the bank from accepting
    /// the Represented Check ("RCK") entry.
    /// </summary>
    StateLawAffectingRckAcceptance,

    /// <summary>
    /// Code R52. A rare return reason. A stop payment was issued on a Represented
    /// Check ("RCK") entry.
    /// </summary>
    StopPaymentOnItemRelatedToRckEntry,

    /// <summary>
    /// Code R38. A rare return reason. The source attached to the ACH, usually an
    /// ACH check conversion, includes a stop payment.
    /// </summary>
    StopPaymentOnSourceDocument,

    /// <summary>
    /// Code R73. A rare return reason. The bank receiving an `untimely_return` believes
    /// it was on time.
    /// </summary>
    TimelyOriginalReturn,

    /// <summary>
    /// Code R27. A rare return reason. An ACH return's trace number does not match
    /// an originated ACH.
    /// </summary>
    TraceNumberError,

    /// <summary>
    /// Code R72. A rare return reason. The dishonored return was sent too late.
    /// </summary>
    UntimelyDishonoredReturn,

    /// <summary>
    /// Code R68. A rare return reason. The return was sent too late.
    /// </summary>
    UntimelyReturn,
}

sealed class ReturnReasonCodeConverter : JsonConverter<ReturnReasonCode>
{
    public override ReturnReasonCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_fund" => ReturnReasonCode.InsufficientFund,
            "no_account" => ReturnReasonCode.NoAccount,
            "account_closed" => ReturnReasonCode.AccountClosed,
            "invalid_account_number_structure" => ReturnReasonCode.InvalidAccountNumberStructure,
            "account_frozen_entry_returned_per_ofac_instruction" =>
                ReturnReasonCode.AccountFrozenEntryReturnedPerOfacInstruction,
            "credit_entry_refused_by_receiver" => ReturnReasonCode.CreditEntryRefusedByReceiver,
            "unauthorized_debit_to_consumer_account_using_corporate_sec_code" =>
                ReturnReasonCode.UnauthorizedDebitToConsumerAccountUsingCorporateSecCode,
            "corporate_customer_advised_not_authorized" =>
                ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized,
            "payment_stopped" => ReturnReasonCode.PaymentStopped,
            "non_transaction_account" => ReturnReasonCode.NonTransactionAccount,
            "uncollected_funds" => ReturnReasonCode.UncollectedFunds,
            "routing_number_check_digit_error" => ReturnReasonCode.RoutingNumberCheckDigitError,
            "customer_advised_unauthorized_improper_ineligible_or_incomplete" =>
                ReturnReasonCode.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete,
            "amount_field_error" => ReturnReasonCode.AmountFieldError,
            "authorization_revoked_by_customer" => ReturnReasonCode.AuthorizationRevokedByCustomer,
            "invalid_ach_routing_number" => ReturnReasonCode.InvalidAchRoutingNumber,
            "file_record_edit_criteria" => ReturnReasonCode.FileRecordEditCriteria,
            "enr_invalid_individual_name" => ReturnReasonCode.EnrInvalidIndividualName,
            "returned_per_odfi_request" => ReturnReasonCode.ReturnedPerOdfiRequest,
            "limited_participation_dfi" => ReturnReasonCode.LimitedParticipationDfi,
            "incorrectly_coded_outbound_international_payment" =>
                ReturnReasonCode.IncorrectlyCodedOutboundInternationalPayment,
            "account_sold_to_another_dfi" => ReturnReasonCode.AccountSoldToAnotherDfi,
            "addenda_error" => ReturnReasonCode.AddendaError,
            "beneficiary_or_account_holder_deceased" =>
                ReturnReasonCode.BeneficiaryOrAccountHolderDeceased,
            "customer_advised_not_within_authorization_terms" =>
                ReturnReasonCode.CustomerAdvisedNotWithinAuthorizationTerms,
            "corrected_return" => ReturnReasonCode.CorrectedReturn,
            "duplicate_entry" => ReturnReasonCode.DuplicateEntry,
            "duplicate_return" => ReturnReasonCode.DuplicateReturn,
            "enr_duplicate_enrollment" => ReturnReasonCode.EnrDuplicateEnrollment,
            "enr_invalid_dfi_account_number" => ReturnReasonCode.EnrInvalidDfiAccountNumber,
            "enr_invalid_individual_id_number" => ReturnReasonCode.EnrInvalidIndividualIDNumber,
            "enr_invalid_representative_payee_indicator" =>
                ReturnReasonCode.EnrInvalidRepresentativePayeeIndicator,
            "enr_invalid_transaction_code" => ReturnReasonCode.EnrInvalidTransactionCode,
            "enr_return_of_enr_entry" => ReturnReasonCode.EnrReturnOfEnrEntry,
            "enr_routing_number_check_digit_error" =>
                ReturnReasonCode.EnrRoutingNumberCheckDigitError,
            "entry_not_processed_by_gateway" => ReturnReasonCode.EntryNotProcessedByGateway,
            "field_error" => ReturnReasonCode.FieldError,
            "foreign_receiving_dfi_unable_to_settle" =>
                ReturnReasonCode.ForeignReceivingDfiUnableToSettle,
            "iat_entry_coding_error" => ReturnReasonCode.IatEntryCodingError,
            "improper_effective_entry_date" => ReturnReasonCode.ImproperEffectiveEntryDate,
            "improper_source_document_source_document_presented" =>
                ReturnReasonCode.ImproperSourceDocumentSourceDocumentPresented,
            "invalid_company_id" => ReturnReasonCode.InvalidCompanyID,
            "invalid_foreign_receiving_dfi_identification" =>
                ReturnReasonCode.InvalidForeignReceivingDfiIdentification,
            "invalid_individual_id_number" => ReturnReasonCode.InvalidIndividualIDNumber,
            "item_and_rck_entry_presented_for_payment" =>
                ReturnReasonCode.ItemAndRckEntryPresentedForPayment,
            "item_related_to_rck_entry_is_ineligible" =>
                ReturnReasonCode.ItemRelatedToRckEntryIsIneligible,
            "mandatory_field_error" => ReturnReasonCode.MandatoryFieldError,
            "misrouted_dishonored_return" => ReturnReasonCode.MisroutedDishonoredReturn,
            "misrouted_return" => ReturnReasonCode.MisroutedReturn,
            "no_errors_found" => ReturnReasonCode.NoErrorsFound,
            "non_acceptance_of_r62_dishonored_return" =>
                ReturnReasonCode.NonAcceptanceOfR62DishonoredReturn,
            "non_participant_in_iat_program" => ReturnReasonCode.NonParticipantInIatProgram,
            "permissible_return_entry" => ReturnReasonCode.PermissibleReturnEntry,
            "permissible_return_entry_not_accepted" =>
                ReturnReasonCode.PermissibleReturnEntryNotAccepted,
            "rdfi_non_settlement" => ReturnReasonCode.RdfiNonSettlement,
            "rdfi_participant_in_check_truncation_program" =>
                ReturnReasonCode.RdfiParticipantInCheckTruncationProgram,
            "representative_payee_deceased_or_unable_to_continue_in_that_capacity" =>
                ReturnReasonCode.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity,
            "return_not_a_duplicate" => ReturnReasonCode.ReturnNotADuplicate,
            "return_of_erroneous_or_reversing_debit" =>
                ReturnReasonCode.ReturnOfErroneousOrReversingDebit,
            "return_of_improper_credit_entry" => ReturnReasonCode.ReturnOfImproperCreditEntry,
            "return_of_improper_debit_entry" => ReturnReasonCode.ReturnOfImproperDebitEntry,
            "return_of_xck_entry" => ReturnReasonCode.ReturnOfXckEntry,
            "source_document_presented_for_payment" =>
                ReturnReasonCode.SourceDocumentPresentedForPayment,
            "state_law_affecting_rck_acceptance" => ReturnReasonCode.StateLawAffectingRckAcceptance,
            "stop_payment_on_item_related_to_rck_entry" =>
                ReturnReasonCode.StopPaymentOnItemRelatedToRckEntry,
            "stop_payment_on_source_document" => ReturnReasonCode.StopPaymentOnSourceDocument,
            "timely_original_return" => ReturnReasonCode.TimelyOriginalReturn,
            "trace_number_error" => ReturnReasonCode.TraceNumberError,
            "untimely_dishonored_return" => ReturnReasonCode.UntimelyDishonoredReturn,
            "untimely_return" => ReturnReasonCode.UntimelyReturn,
            _ => (ReturnReasonCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReturnReasonCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReturnReasonCode.InsufficientFund => "insufficient_fund",
                ReturnReasonCode.NoAccount => "no_account",
                ReturnReasonCode.AccountClosed => "account_closed",
                ReturnReasonCode.InvalidAccountNumberStructure =>
                    "invalid_account_number_structure",
                ReturnReasonCode.AccountFrozenEntryReturnedPerOfacInstruction =>
                    "account_frozen_entry_returned_per_ofac_instruction",
                ReturnReasonCode.CreditEntryRefusedByReceiver => "credit_entry_refused_by_receiver",
                ReturnReasonCode.UnauthorizedDebitToConsumerAccountUsingCorporateSecCode =>
                    "unauthorized_debit_to_consumer_account_using_corporate_sec_code",
                ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized =>
                    "corporate_customer_advised_not_authorized",
                ReturnReasonCode.PaymentStopped => "payment_stopped",
                ReturnReasonCode.NonTransactionAccount => "non_transaction_account",
                ReturnReasonCode.UncollectedFunds => "uncollected_funds",
                ReturnReasonCode.RoutingNumberCheckDigitError => "routing_number_check_digit_error",
                ReturnReasonCode.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete =>
                    "customer_advised_unauthorized_improper_ineligible_or_incomplete",
                ReturnReasonCode.AmountFieldError => "amount_field_error",
                ReturnReasonCode.AuthorizationRevokedByCustomer =>
                    "authorization_revoked_by_customer",
                ReturnReasonCode.InvalidAchRoutingNumber => "invalid_ach_routing_number",
                ReturnReasonCode.FileRecordEditCriteria => "file_record_edit_criteria",
                ReturnReasonCode.EnrInvalidIndividualName => "enr_invalid_individual_name",
                ReturnReasonCode.ReturnedPerOdfiRequest => "returned_per_odfi_request",
                ReturnReasonCode.LimitedParticipationDfi => "limited_participation_dfi",
                ReturnReasonCode.IncorrectlyCodedOutboundInternationalPayment =>
                    "incorrectly_coded_outbound_international_payment",
                ReturnReasonCode.AccountSoldToAnotherDfi => "account_sold_to_another_dfi",
                ReturnReasonCode.AddendaError => "addenda_error",
                ReturnReasonCode.BeneficiaryOrAccountHolderDeceased =>
                    "beneficiary_or_account_holder_deceased",
                ReturnReasonCode.CustomerAdvisedNotWithinAuthorizationTerms =>
                    "customer_advised_not_within_authorization_terms",
                ReturnReasonCode.CorrectedReturn => "corrected_return",
                ReturnReasonCode.DuplicateEntry => "duplicate_entry",
                ReturnReasonCode.DuplicateReturn => "duplicate_return",
                ReturnReasonCode.EnrDuplicateEnrollment => "enr_duplicate_enrollment",
                ReturnReasonCode.EnrInvalidDfiAccountNumber => "enr_invalid_dfi_account_number",
                ReturnReasonCode.EnrInvalidIndividualIDNumber => "enr_invalid_individual_id_number",
                ReturnReasonCode.EnrInvalidRepresentativePayeeIndicator =>
                    "enr_invalid_representative_payee_indicator",
                ReturnReasonCode.EnrInvalidTransactionCode => "enr_invalid_transaction_code",
                ReturnReasonCode.EnrReturnOfEnrEntry => "enr_return_of_enr_entry",
                ReturnReasonCode.EnrRoutingNumberCheckDigitError =>
                    "enr_routing_number_check_digit_error",
                ReturnReasonCode.EntryNotProcessedByGateway => "entry_not_processed_by_gateway",
                ReturnReasonCode.FieldError => "field_error",
                ReturnReasonCode.ForeignReceivingDfiUnableToSettle =>
                    "foreign_receiving_dfi_unable_to_settle",
                ReturnReasonCode.IatEntryCodingError => "iat_entry_coding_error",
                ReturnReasonCode.ImproperEffectiveEntryDate => "improper_effective_entry_date",
                ReturnReasonCode.ImproperSourceDocumentSourceDocumentPresented =>
                    "improper_source_document_source_document_presented",
                ReturnReasonCode.InvalidCompanyID => "invalid_company_id",
                ReturnReasonCode.InvalidForeignReceivingDfiIdentification =>
                    "invalid_foreign_receiving_dfi_identification",
                ReturnReasonCode.InvalidIndividualIDNumber => "invalid_individual_id_number",
                ReturnReasonCode.ItemAndRckEntryPresentedForPayment =>
                    "item_and_rck_entry_presented_for_payment",
                ReturnReasonCode.ItemRelatedToRckEntryIsIneligible =>
                    "item_related_to_rck_entry_is_ineligible",
                ReturnReasonCode.MandatoryFieldError => "mandatory_field_error",
                ReturnReasonCode.MisroutedDishonoredReturn => "misrouted_dishonored_return",
                ReturnReasonCode.MisroutedReturn => "misrouted_return",
                ReturnReasonCode.NoErrorsFound => "no_errors_found",
                ReturnReasonCode.NonAcceptanceOfR62DishonoredReturn =>
                    "non_acceptance_of_r62_dishonored_return",
                ReturnReasonCode.NonParticipantInIatProgram => "non_participant_in_iat_program",
                ReturnReasonCode.PermissibleReturnEntry => "permissible_return_entry",
                ReturnReasonCode.PermissibleReturnEntryNotAccepted =>
                    "permissible_return_entry_not_accepted",
                ReturnReasonCode.RdfiNonSettlement => "rdfi_non_settlement",
                ReturnReasonCode.RdfiParticipantInCheckTruncationProgram =>
                    "rdfi_participant_in_check_truncation_program",
                ReturnReasonCode.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity =>
                    "representative_payee_deceased_or_unable_to_continue_in_that_capacity",
                ReturnReasonCode.ReturnNotADuplicate => "return_not_a_duplicate",
                ReturnReasonCode.ReturnOfErroneousOrReversingDebit =>
                    "return_of_erroneous_or_reversing_debit",
                ReturnReasonCode.ReturnOfImproperCreditEntry => "return_of_improper_credit_entry",
                ReturnReasonCode.ReturnOfImproperDebitEntry => "return_of_improper_debit_entry",
                ReturnReasonCode.ReturnOfXckEntry => "return_of_xck_entry",
                ReturnReasonCode.SourceDocumentPresentedForPayment =>
                    "source_document_presented_for_payment",
                ReturnReasonCode.StateLawAffectingRckAcceptance =>
                    "state_law_affecting_rck_acceptance",
                ReturnReasonCode.StopPaymentOnItemRelatedToRckEntry =>
                    "stop_payment_on_item_related_to_rck_entry",
                ReturnReasonCode.StopPaymentOnSourceDocument => "stop_payment_on_source_document",
                ReturnReasonCode.TimelyOriginalReturn => "timely_original_return",
                ReturnReasonCode.TraceNumberError => "trace_number_error",
                ReturnReasonCode.UntimelyDishonoredReturn => "untimely_dishonored_return",
                ReturnReasonCode.UntimelyReturn => "untimely_return",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A subhash containing information about when and how the transfer settled at the
/// Federal Reserve.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Settlement, SettlementFromRaw>))]
public sealed record class Settlement : JsonModel
{
    /// <summary>
    /// When the funds for this transfer have settled at the destination bank at the
    /// Federal Reserve.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SettledAt;
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

    [SetsRequiredMembers]
    public Settlement(System::DateTimeOffset settledAt)
        : this()
    {
        this.SettledAt = settledAt;
    }
}

class SettlementFromRaw : IFromRawJson<Settlement>
{
    /// <inheritdoc/>
    public Settlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Settlement.FromRawUnchecked(rawData);
}

/// <summary>
/// The [Standard Entry Class (SEC) code](/documentation/ach-standard-entry-class-codes)
/// to use for the transfer.
/// </summary>
[JsonConverter(typeof(AchTransferStandardEntryClassCodeConverter))]
public enum AchTransferStandardEntryClassCode
{
    /// <summary>
    /// Corporate Credit and Debit (CCD) is used for business-to-business payments.
    /// </summary>
    CorporateCreditOrDebit,

    /// <summary>
    /// Corporate Trade Exchange (CTX) allows for including extensive remittance information
    /// with business-to-business payments.
    /// </summary>
    CorporateTradeExchange,

    /// <summary>
    /// Prearranged Payments and Deposits (PPD) is used for credits or debits originated
    /// by an organization to a consumer, such as payroll direct deposits.
    /// </summary>
    PrearrangedPaymentsAndDeposit,

    /// <summary>
    /// Internet Initiated (WEB) is used for consumer payments initiated or authorized
    /// via the Internet. Debits can only be initiated by non-consumers to debit a
    /// consumer’s account. Credits can only be used for consumer to consumer transactions.
    /// </summary>
    InternetInitiated,
}

sealed class AchTransferStandardEntryClassCodeConverter
    : JsonConverter<AchTransferStandardEntryClassCode>
{
    public override AchTransferStandardEntryClassCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "corporate_credit_or_debit" => AchTransferStandardEntryClassCode.CorporateCreditOrDebit,
            "corporate_trade_exchange" => AchTransferStandardEntryClassCode.CorporateTradeExchange,
            "prearranged_payments_and_deposit" =>
                AchTransferStandardEntryClassCode.PrearrangedPaymentsAndDeposit,
            "internet_initiated" => AchTransferStandardEntryClassCode.InternetInitiated,
            _ => (AchTransferStandardEntryClassCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AchTransferStandardEntryClassCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AchTransferStandardEntryClassCode.CorporateCreditOrDebit =>
                    "corporate_credit_or_debit",
                AchTransferStandardEntryClassCode.CorporateTradeExchange =>
                    "corporate_trade_exchange",
                AchTransferStandardEntryClassCode.PrearrangedPaymentsAndDeposit =>
                    "prearranged_payments_and_deposit",
                AchTransferStandardEntryClassCode.InternetInitiated => "internet_initiated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The lifecycle status of the transfer.
/// </summary>
[JsonConverter(typeof(AchTransferStatusConverter))]
public enum AchTransferStatus
{
    /// <summary>
    /// The transfer is pending approval.
    /// </summary>
    PendingApproval,

    /// <summary>
    /// The transfer belongs to a Transfer Session that is pending confirmation.
    /// </summary>
    PendingTransferSessionConfirmation,

    /// <summary>
    /// The transfer has been canceled.
    /// </summary>
    Canceled,

    /// <summary>
    /// The transfer is pending submission to the Federal Reserve.
    /// </summary>
    PendingSubmission,

    /// <summary>
    /// The transfer is pending review by Increase.
    /// </summary>
    PendingReviewing,

    /// <summary>
    /// The transfer requires attention from an Increase operator.
    /// </summary>
    RequiresAttention,

    /// <summary>
    /// The transfer has been rejected.
    /// </summary>
    Rejected,

    /// <summary>
    /// The transfer is complete.
    /// </summary>
    Submitted,

    /// <summary>
    /// The transfer has been returned.
    /// </summary>
    Returned,
}

sealed class AchTransferStatusConverter : JsonConverter<AchTransferStatus>
{
    public override AchTransferStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_approval" => AchTransferStatus.PendingApproval,
            "pending_transfer_session_confirmation" =>
                AchTransferStatus.PendingTransferSessionConfirmation,
            "canceled" => AchTransferStatus.Canceled,
            "pending_submission" => AchTransferStatus.PendingSubmission,
            "pending_reviewing" => AchTransferStatus.PendingReviewing,
            "requires_attention" => AchTransferStatus.RequiresAttention,
            "rejected" => AchTransferStatus.Rejected,
            "submitted" => AchTransferStatus.Submitted,
            "returned" => AchTransferStatus.Returned,
            _ => (AchTransferStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AchTransferStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AchTransferStatus.PendingApproval => "pending_approval",
                AchTransferStatus.PendingTransferSessionConfirmation =>
                    "pending_transfer_session_confirmation",
                AchTransferStatus.Canceled => "canceled",
                AchTransferStatus.PendingSubmission => "pending_submission",
                AchTransferStatus.PendingReviewing => "pending_reviewing",
                AchTransferStatus.RequiresAttention => "requires_attention",
                AchTransferStatus.Rejected => "rejected",
                AchTransferStatus.Submitted => "submitted",
                AchTransferStatus.Returned => "returned",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// After the transfer is submitted to FedACH, this will contain supplemental details.
/// Increase batches transfers and submits a file to the Federal Reserve roughly
/// every 30 minutes. The Federal Reserve processes ACH transfers during weekdays
/// according to their [posted schedule](https://www.frbservices.org/resources/resource-centers/same-day-ach/fedach-processing-schedule.html).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Submission, SubmissionFromRaw>))]
public sealed record class Submission : JsonModel
{
    /// <summary>
    /// The timestamp by which any administrative returns are expected to be received
    /// by. This follows the NACHA guidelines for return windows, which are: "In
    /// general, return entries must be received by the RDFI’s ACH Operator by its
    /// deposit deadline for the return entry to be made available to the ODFI no
    /// later than the opening of business on the second banking day following the
    /// Settlement Date of the original entry.".
    /// </summary>
    public required System::DateTimeOffset AdministrativeReturnsExpectedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "administrative_returns_expected_by"
            );
        }
        init { this._rawData.Set("administrative_returns_expected_by", value); }
    }

    /// <summary>
    /// The ACH transfer's effective date as sent to the Federal Reserve. If a specific
    /// date was configured using `preferred_effective_date`, this will match that
    /// value. Otherwise, it will be the date selected (following the specified settlement
    /// schedule) at the time the transfer was submitted.
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
    /// When the transfer is expected to settle in the recipient's account. Credits
    /// may be available sooner, at the receiving bank's discretion. The FedACH schedule
    /// is published [here](https://www.frbservices.org/resources/resource-centers/same-day-ach/fedach-processing-schedule.html).
    /// </summary>
    public required System::DateTimeOffset ExpectedFundsSettlementAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "expected_funds_settlement_at"
            );
        }
        init { this._rawData.Set("expected_funds_settlement_at", value); }
    }

    /// <summary>
    /// The settlement schedule the transfer is expected to follow. This expectation
    /// takes into account the `effective_date`, `submitted_at`, and the amount of
    /// the transfer.
    /// </summary>
    public required ApiEnum<string, ExpectedSettlementSchedule> ExpectedSettlementSchedule
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ExpectedSettlementSchedule>>(
                "expected_settlement_schedule"
            );
        }
        init { this._rawData.Set("expected_settlement_schedule", value); }
    }

    /// <summary>
    /// When the ACH transfer was sent to FedACH.
    /// </summary>
    public required System::DateTimeOffset SubmittedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("submitted_at");
        }
        init { this._rawData.Set("submitted_at", value); }
    }

    /// <summary>
    /// A 15 digit number recorded in the Nacha file and transmitted to the receiving
    /// bank. Along with the amount, date, and originating routing number, this can
    /// be used to identify the ACH transfer at the receiving bank. ACH trace numbers
    /// are not unique, but are [used to correlate returns](https://increase.com/documentation/ach-returns#ach-returns).
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdministrativeReturnsExpectedBy;
        _ = this.EffectiveDate;
        _ = this.ExpectedFundsSettlementAt;
        this.ExpectedSettlementSchedule.Validate();
        _ = this.SubmittedAt;
        _ = this.TraceNumber;
    }

    public Submission() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Submission(Submission submission)
        : base(submission) { }
#pragma warning restore CS8618

    public Submission(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Submission(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubmissionFromRaw.FromRawUnchecked"/>
    public static Submission FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubmissionFromRaw : IFromRawJson<Submission>
{
    /// <inheritdoc/>
    public Submission FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Submission.FromRawUnchecked(rawData);
}

/// <summary>
/// The settlement schedule the transfer is expected to follow. This expectation takes
/// into account the `effective_date`, `submitted_at`, and the amount of the transfer.
/// </summary>
[JsonConverter(typeof(ExpectedSettlementScheduleConverter))]
public enum ExpectedSettlementSchedule
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

sealed class ExpectedSettlementScheduleConverter : JsonConverter<ExpectedSettlementSchedule>
{
    public override ExpectedSettlementSchedule Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "same_day" => ExpectedSettlementSchedule.SameDay,
            "future_dated" => ExpectedSettlementSchedule.FutureDated,
            _ => (ExpectedSettlementSchedule)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExpectedSettlementSchedule value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExpectedSettlementSchedule.SameDay => "same_day",
                ExpectedSettlementSchedule.FutureDated => "future_dated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `ach_transfer`.
/// </summary>
[JsonConverter(typeof(AchTransferTypeConverter))]
public enum AchTransferType
{
    AchTransfer,
}

sealed class AchTransferTypeConverter : JsonConverter<AchTransferType>
{
    public override AchTransferType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ach_transfer" => AchTransferType.AchTransfer,
            _ => (AchTransferType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AchTransferType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AchTransferType.AchTransfer => "ach_transfer",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
