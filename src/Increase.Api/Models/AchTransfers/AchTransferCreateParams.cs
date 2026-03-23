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
using System = System;

namespace Increase.Api.Models.AchTransfers;

/// <summary>
/// Create an ACH Transfer
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AchTransferCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The Increase identifier for the account that will send the transfer.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("account_id");
        }
        init { this._rawBodyData.Set("account_id", value); }
    }

    /// <summary>
    /// The transfer amount in USD cents. A positive amount originates a credit transfer
    /// pushing funds to the receiving account. A negative amount originates a debit
    /// transfer pulling funds from the receiving account.
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
    /// A description you choose to give the transfer. This will be saved with the
    /// transfer details, displayed in the dashboard, and returned by the API. If
    /// `individual_name` and `company_name` are not explicitly set by this API,
    /// the `statement_descriptor` will be sent in those fields to the receiving bank
    /// to help the customer recognize the transfer. You are highly encouraged to
    /// pass `individual_name` and `company_name` instead of relying on this fallback.
    /// </summary>
    public required string StatementDescriptor
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("statement_descriptor");
        }
        init { this._rawBodyData.Set("statement_descriptor", value); }
    }

    /// <summary>
    /// The account number for the destination account.
    /// </summary>
    public string? AccountNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("account_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("account_number", value);
        }
    }

    /// <summary>
    /// Additional information that will be sent to the recipient. This is included
    /// in the transfer data sent to the receiving bank.
    /// </summary>
    public Addenda? Addenda
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Addenda>("addenda");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("addenda", value);
        }
    }

    /// <summary>
    /// The description of the date of the transfer, usually in the format `YYMMDD`.
    /// This is included in the transfer data sent to the receiving bank.
    /// </summary>
    public string? CompanyDescriptiveDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("company_descriptive_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("company_descriptive_date", value);
        }
    }

    /// <summary>
    /// The data you choose to associate with the transfer. This is included in the
    /// transfer data sent to the receiving bank.
    /// </summary>
    public string? CompanyDiscretionaryData
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("company_discretionary_data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("company_discretionary_data", value);
        }
    }

    /// <summary>
    /// A description of the transfer, included in the transfer data sent to the receiving
    /// bank. Standardized formatting may be required, for example `PAYROLL` for
    /// payroll-related Prearranged Payments and Deposits (PPD) credit transfers.
    /// </summary>
    public string? CompanyEntryDescription
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("company_entry_description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("company_entry_description", value);
        }
    }

    /// <summary>
    /// The name by which the recipient knows you. This is included in the transfer
    /// data sent to the receiving bank.
    /// </summary>
    public string? CompanyName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("company_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("company_name", value);
        }
    }

    /// <summary>
    /// The type of entity that owns the account to which the ACH Transfer is being sent.
    /// </summary>
    public ApiEnum<string, DestinationAccountHolder>? DestinationAccountHolder
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, DestinationAccountHolder>>(
                "destination_account_holder"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("destination_account_holder", value);
        }
    }

    /// <summary>
    /// The ID of an External Account to initiate a transfer to. If this parameter
    /// is provided, `account_number`, `routing_number`, and `funding` must be absent.
    /// </summary>
    public string? ExternalAccountID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("external_account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("external_account_id", value);
        }
    }

    /// <summary>
    /// The type of the account to which the transfer will be sent.
    /// </summary>
    public ApiEnum<string, Funding>? Funding
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Funding>>("funding");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("funding", value);
        }
    }

    /// <summary>
    /// Your identifier for the transfer recipient.
    /// </summary>
    public string? IndividualID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("individual_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("individual_id", value);
        }
    }

    /// <summary>
    /// The name of the transfer recipient. This value is informational and not verified
    /// by the recipient's bank.
    /// </summary>
    public string? IndividualName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("individual_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("individual_name", value);
        }
    }

    /// <summary>
    /// Configuration for how the effective date of the transfer will be set. This
    /// determines same-day vs future-dated settlement timing. If not set, defaults
    /// to a `settlement_schedule` of `same_day`. If set, exactly one of the child
    /// attributes must be set.
    /// </summary>
    public PreferredEffectiveDate? PreferredEffectiveDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PreferredEffectiveDate>(
                "preferred_effective_date"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("preferred_effective_date", value);
        }
    }

    /// <summary>
    /// Whether the transfer requires explicit approval via the dashboard or API.
    /// </summary>
    public bool? RequireApproval
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("require_approval");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("require_approval", value);
        }
    }

    /// <summary>
    /// The American Bankers' Association (ABA) Routing Transit Number (RTN) for
    /// the destination account.
    /// </summary>
    public string? RoutingNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("routing_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("routing_number", value);
        }
    }

    /// <summary>
    /// The [Standard Entry Class (SEC) code](/documentation/ach-standard-entry-class-codes)
    /// to use for the transfer.
    /// </summary>
    public ApiEnum<string, StandardEntryClassCode>? StandardEntryClassCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, StandardEntryClassCode>>(
                "standard_entry_class_code"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("standard_entry_class_code", value);
        }
    }

    /// <summary>
    /// The timing of the transaction.
    /// </summary>
    public ApiEnum<string, TransactionTiming>? TransactionTiming
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TransactionTiming>>(
                "transaction_timing"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("transaction_timing", value);
        }
    }

    public AchTransferCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferCreateParams(AchTransferCreateParams achTransferCreateParams)
        : base(achTransferCreateParams)
    {
        this._rawBodyData = new(achTransferCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AchTransferCreateParams(
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
    AchTransferCreateParams(
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
    public static AchTransferCreateParams FromRawUnchecked(
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

    public virtual bool Equals(AchTransferCreateParams? other)
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/ach_transfers")
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
/// Additional information that will be sent to the recipient. This is included in
/// the transfer data sent to the receiving bank.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Addenda, AddendaFromRaw>))]
public sealed record class Addenda : JsonModel
{
    /// <summary>
    /// The type of addenda to pass with the transfer.
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
    /// Unstructured `payment_related_information` passed through with the transfer.
    /// Required if and only if `category` is `freeform`.
    /// </summary>
    public Freeform? Freeform
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Freeform>("freeform");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("freeform", value);
        }
    }

    /// <summary>
    /// Structured ASC X12 820 remittance advice records. Please reach out to [support@increase.com](mailto:support@increase.com)
    /// for more information. Required if and only if `category` is `payment_order_remittance_advice`.
    /// </summary>
    public PaymentOrderRemittanceAdvice? PaymentOrderRemittanceAdvice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaymentOrderRemittanceAdvice>(
                "payment_order_remittance_advice"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("payment_order_remittance_advice", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.Freeform?.Validate();
        this.PaymentOrderRemittanceAdvice?.Validate();
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

    [SetsRequiredMembers]
    public Addenda(ApiEnum<string, Category> category)
        : this()
    {
        this.Category = category;
    }
}

class AddendaFromRaw : IFromRawJson<Addenda>
{
    /// <inheritdoc/>
    public Addenda FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Addenda.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of addenda to pass with the transfer.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
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
            "payment_order_remittance_advice" => Category.PaymentOrderRemittanceAdvice,
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
                Category.PaymentOrderRemittanceAdvice => "payment_order_remittance_advice",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Unstructured `payment_related_information` passed through with the transfer. Required
/// if and only if `category` is `freeform`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Freeform, FreeformFromRaw>))]
public sealed record class Freeform : JsonModel
{
    /// <summary>
    /// Each entry represents an addendum sent with the transfer. In general, you
    /// should send at most one addendum–most ACH recipients cannot access beyond
    /// the first 80 characters sent. Please reach out to [support@increase.com](mailto:support@increase.com)
    /// to send 2 or more addenda to a recipient expecting a specific addendum format.
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
/// Structured ASC X12 820 remittance advice records. Please reach out to [support@increase.com](mailto:support@increase.com)
/// for more information. Required if and only if `category` is `payment_order_remittance_advice`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PaymentOrderRemittanceAdvice, PaymentOrderRemittanceAdviceFromRaw>)
)]
public sealed record class PaymentOrderRemittanceAdvice : JsonModel
{
    /// <summary>
    /// ASC X12 RMR records for this specific transfer.
    /// </summary>
    public required IReadOnlyList<Invoice> Invoices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Invoice>>("invoices");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Invoice>>(
                "invoices",
                ImmutableArray.ToImmutableArray(value)
            );
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

    public PaymentOrderRemittanceAdvice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentOrderRemittanceAdvice(PaymentOrderRemittanceAdvice paymentOrderRemittanceAdvice)
        : base(paymentOrderRemittanceAdvice) { }
#pragma warning restore CS8618

    public PaymentOrderRemittanceAdvice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentOrderRemittanceAdvice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentOrderRemittanceAdviceFromRaw.FromRawUnchecked"/>
    public static PaymentOrderRemittanceAdvice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PaymentOrderRemittanceAdvice(IReadOnlyList<Invoice> invoices)
        : this()
    {
        this.Invoices = invoices;
    }
}

class PaymentOrderRemittanceAdviceFromRaw : IFromRawJson<PaymentOrderRemittanceAdvice>
{
    /// <inheritdoc/>
    public PaymentOrderRemittanceAdvice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentOrderRemittanceAdvice.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Invoice, InvoiceFromRaw>))]
public sealed record class Invoice : JsonModel
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

    public Invoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Invoice(Invoice invoice)
        : base(invoice) { }
#pragma warning restore CS8618

    public Invoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Invoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceFromRaw.FromRawUnchecked"/>
    public static Invoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceFromRaw : IFromRawJson<Invoice>
{
    /// <inheritdoc/>
    public Invoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Invoice.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of entity that owns the account to which the ACH Transfer is being sent.
/// </summary>
[JsonConverter(typeof(DestinationAccountHolderConverter))]
public enum DestinationAccountHolder
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

sealed class DestinationAccountHolderConverter : JsonConverter<DestinationAccountHolder>
{
    public override DestinationAccountHolder Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "business" => DestinationAccountHolder.Business,
            "individual" => DestinationAccountHolder.Individual,
            "unknown" => DestinationAccountHolder.Unknown,
            _ => (DestinationAccountHolder)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DestinationAccountHolder value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DestinationAccountHolder.Business => "business",
                DestinationAccountHolder.Individual => "individual",
                DestinationAccountHolder.Unknown => "unknown",
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
[JsonConverter(typeof(FundingConverter))]
public enum Funding
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

sealed class FundingConverter : JsonConverter<Funding>
{
    public override Funding Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "checking" => Funding.Checking,
            "savings" => Funding.Savings,
            "general_ledger" => Funding.GeneralLedger,
            _ => (Funding)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Funding value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Funding.Checking => "checking",
                Funding.Savings => "savings",
                Funding.GeneralLedger => "general_ledger",
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
[JsonConverter(typeof(JsonModelConverter<PreferredEffectiveDate, PreferredEffectiveDateFromRaw>))]
public sealed record class PreferredEffectiveDate : JsonModel
{
    /// <summary>
    /// A specific date in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format
    /// to use as the effective date when submitting this transfer.
    /// </summary>
    public string? Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("date", value);
        }
    }

    /// <summary>
    /// A schedule by which Increase will choose an effective date for the transfer.
    /// </summary>
    public ApiEnum<string, SettlementSchedule>? SettlementSchedule
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SettlementSchedule>>(
                "settlement_schedule"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("settlement_schedule", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Date;
        this.SettlementSchedule?.Validate();
    }

    public PreferredEffectiveDate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferredEffectiveDate(PreferredEffectiveDate preferredEffectiveDate)
        : base(preferredEffectiveDate) { }
#pragma warning restore CS8618

    public PreferredEffectiveDate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferredEffectiveDate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferredEffectiveDateFromRaw.FromRawUnchecked"/>
    public static PreferredEffectiveDate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreferredEffectiveDateFromRaw : IFromRawJson<PreferredEffectiveDate>
{
    /// <inheritdoc/>
    public PreferredEffectiveDate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferredEffectiveDate.FromRawUnchecked(rawData);
}

/// <summary>
/// A schedule by which Increase will choose an effective date for the transfer.
/// </summary>
[JsonConverter(typeof(SettlementScheduleConverter))]
public enum SettlementSchedule
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
/// The [Standard Entry Class (SEC) code](/documentation/ach-standard-entry-class-codes)
/// to use for the transfer.
/// </summary>
[JsonConverter(typeof(StandardEntryClassCodeConverter))]
public enum StandardEntryClassCode
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
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The timing of the transaction.
/// </summary>
[JsonConverter(typeof(TransactionTimingConverter))]
public enum TransactionTiming
{
    /// <summary>
    /// A Transaction will be created immediately.
    /// </summary>
    Synchronous,

    /// <summary>
    /// A Transaction will be created when the funds settle at the Federal Reserve.
    /// </summary>
    Asynchronous,
}

sealed class TransactionTimingConverter : JsonConverter<TransactionTiming>
{
    public override TransactionTiming Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "synchronous" => TransactionTiming.Synchronous,
            "asynchronous" => TransactionTiming.Asynchronous,
            _ => (TransactionTiming)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransactionTiming value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransactionTiming.Synchronous => "synchronous",
                TransactionTiming.Asynchronous => "asynchronous",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
