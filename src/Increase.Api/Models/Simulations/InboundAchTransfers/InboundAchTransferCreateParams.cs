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

namespace Increase.Api.Models.Simulations.InboundAchTransfers;

/// <summary>
/// Simulates an inbound ACH transfer to your account. This imitates initiating a
/// transfer to an Increase account from a different financial institution. The transfer
/// may be either a credit or a debit depending on if the `amount` is positive or
/// negative. The result of calling this API will contain the created transfer. You
/// can pass a `resolve_at` parameter to allow for a window to [action on the Inbound
/// ACH Transfer](https://increase.com/documentation/receiving-ach-transfers). Alternatively,
/// if you don't pass the `resolve_at` parameter the result will contain either a
/// [Transaction](#transactions) or a [Declined Transaction](#declined-transactions)
/// depending on whether or not the transfer is allowed.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InboundAchTransferCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The identifier of the Account Number the inbound ACH Transfer is for.
    /// </summary>
    public required string AccountNumberID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("account_number_id");
        }
        init { this._rawBodyData.Set("account_number_id", value); }
    }

    /// <summary>
    /// The transfer amount in cents. A positive amount originates a credit transfer
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
    /// Additional information to include in the transfer.
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
    /// The description of the date of the transfer.
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
    /// Data associated with the transfer set by the sender.
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
    /// The description of the transfer set by the sender.
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
    /// The sender's company ID.
    /// </summary>
    public string? CompanyID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("company_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("company_id", value);
        }
    }

    /// <summary>
    /// The name of the sender.
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
    /// The ID of the receiver of the transfer.
    /// </summary>
    public string? ReceiverIDNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("receiver_id_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("receiver_id_number", value);
        }
    }

    /// <summary>
    /// The name of the receiver of the transfer.
    /// </summary>
    public string? ReceiverName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("receiver_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("receiver_name", value);
        }
    }

    /// <summary>
    /// The time at which the transfer should be resolved. If not provided will resolve immediately.
    /// </summary>
    public DateTimeOffset? ResolveAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("resolve_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("resolve_at", value);
        }
    }

    /// <summary>
    /// The standard entry class code for the transfer.
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

    public InboundAchTransferCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundAchTransferCreateParams(
        InboundAchTransferCreateParams inboundAchTransferCreateParams
    )
        : base(inboundAchTransferCreateParams)
    {
        this._rawBodyData = new(inboundAchTransferCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InboundAchTransferCreateParams(
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
    InboundAchTransferCreateParams(
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
    public static InboundAchTransferCreateParams FromRawUnchecked(
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

    public virtual bool Equals(InboundAchTransferCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/simulations/inbound_ach_transfers"
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
/// Additional information to include in the transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Addenda, AddendaFromRaw>))]
public sealed record class Addenda : JsonModel
{
    /// <summary>
    /// The type of addenda to simulate being sent with the transfer.
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
/// The type of addenda to simulate being sent with the transfer.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    /// <summary>
    /// Unstructured `payment_related_information` passed through with the transfer.
    /// </summary>
    Freeform,
}

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
/// Unstructured `payment_related_information` passed through with the transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Freeform, FreeformFromRaw>))]
public sealed record class Freeform : JsonModel
{
    /// <summary>
    /// Each entry represents an addendum sent with the transfer.
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
/// The standard entry class code for the transfer.
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
        Type typeToConvert,
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
