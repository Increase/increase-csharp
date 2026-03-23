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

namespace Increase.Api.Models.WireTransfers;

/// <summary>
/// Create a Wire Transfer
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WireTransferCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The identifier for the account that will send the transfer.
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
    /// The transfer amount in USD cents.
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
    /// The person or business that is receiving the funds from the transfer.
    /// </summary>
    public required Creditor Creditor
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Creditor>("creditor");
        }
        init { this._rawBodyData.Set("creditor", value); }
    }

    /// <summary>
    /// Additional remittance information related to the wire transfer.
    /// </summary>
    public required Remittance Remittance
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Remittance>("remittance");
        }
        init { this._rawBodyData.Set("remittance", value); }
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
    /// The person or business whose funds are being transferred. This is only necessary
    /// if you're transferring from a commingled account. Otherwise, we'll use the
    /// associated entity's details.
    /// </summary>
    public Debtor? Debtor
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Debtor>("debtor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("debtor", value);
        }
    }

    /// <summary>
    /// The ID of an External Account to initiate a transfer to. If this parameter
    /// is provided, `account_number` and `routing_number` must be absent.
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
    /// The ID of an Inbound Wire Drawdown Request in response to which this transfer
    /// is being sent.
    /// </summary>
    public string? InboundWireDrawdownRequestID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("inbound_wire_drawdown_request_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("inbound_wire_drawdown_request_id", value);
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
    /// The ID of an Account Number that will be passed to the wire's recipient
    /// </summary>
    public string? SourceAccountNumberID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("source_account_number_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("source_account_number_id", value);
        }
    }

    public WireTransferCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireTransferCreateParams(WireTransferCreateParams wireTransferCreateParams)
        : base(wireTransferCreateParams)
    {
        this._rawBodyData = new(wireTransferCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WireTransferCreateParams(
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
    WireTransferCreateParams(
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
    public static WireTransferCreateParams FromRawUnchecked(
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

    public virtual bool Equals(WireTransferCreateParams? other)
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/wire_transfers")
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
/// The person or business that is receiving the funds from the transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Creditor, CreditorFromRaw>))]
public sealed record class Creditor : JsonModel
{
    /// <summary>
    /// The person or business's name.
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

    /// <summary>
    /// The person or business's address.
    /// </summary>
    public Address? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Address>("address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        this.Address?.Validate();
    }

    public Creditor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Creditor(Creditor creditor)
        : base(creditor) { }
#pragma warning restore CS8618

    public Creditor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Creditor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditorFromRaw.FromRawUnchecked"/>
    public static Creditor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Creditor(string name)
        : this()
    {
        this.Name = name;
    }
}

class CreditorFromRaw : IFromRawJson<Creditor>
{
    /// <inheritdoc/>
    public Creditor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Creditor.FromRawUnchecked(rawData);
}

/// <summary>
/// The person or business's address.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : JsonModel
{
    /// <summary>
    /// Unstructured address lines.
    /// </summary>
    public required Unstructured Unstructured
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Unstructured>("unstructured");
        }
        init { this._rawData.Set("unstructured", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Unstructured.Validate();
    }

    public Address() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Address(Address address)
        : base(address) { }
#pragma warning restore CS8618

    public Address(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Address(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddressFromRaw.FromRawUnchecked"/>
    public static Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Address(Unstructured unstructured)
        : this()
    {
        this.Unstructured = unstructured;
    }
}

class AddressFromRaw : IFromRawJson<Address>
{
    /// <inheritdoc/>
    public Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Address.FromRawUnchecked(rawData);
}

/// <summary>
/// Unstructured address lines.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Unstructured, UnstructuredFromRaw>))]
public sealed record class Unstructured : JsonModel
{
    /// <summary>
    /// The address line 1.
    /// </summary>
    public required string Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("line1");
        }
        init { this._rawData.Set("line1", value); }
    }

    /// <summary>
    /// The address line 2.
    /// </summary>
    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line2", value);
        }
    }

    /// <summary>
    /// The address line 3.
    /// </summary>
    public string? Line3
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line3");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line3", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Line1;
        _ = this.Line2;
        _ = this.Line3;
    }

    public Unstructured() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Unstructured(Unstructured unstructured)
        : base(unstructured) { }
#pragma warning restore CS8618

    public Unstructured(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Unstructured(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnstructuredFromRaw.FromRawUnchecked"/>
    public static Unstructured FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Unstructured(string line1)
        : this()
    {
        this.Line1 = line1;
    }
}

class UnstructuredFromRaw : IFromRawJson<Unstructured>
{
    /// <inheritdoc/>
    public Unstructured FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Unstructured.FromRawUnchecked(rawData);
}

/// <summary>
/// Additional remittance information related to the wire transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Remittance, RemittanceFromRaw>))]
public sealed record class Remittance : JsonModel
{
    /// <summary>
    /// The type of remittance information being passed.
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
    /// Internal Revenue Service (IRS) tax repayment information. Required if `category`
    /// is equal to `tax`.
    /// </summary>
    public Tax? Tax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Tax>("tax");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tax", value);
        }
    }

    /// <summary>
    /// Unstructured remittance information. Required if `category` is equal to `unstructured`.
    /// </summary>
    public RemittanceUnstructured? Unstructured
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RemittanceUnstructured>("unstructured");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unstructured", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.Tax?.Validate();
        this.Unstructured?.Validate();
    }

    public Remittance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Remittance(Remittance remittance)
        : base(remittance) { }
#pragma warning restore CS8618

    public Remittance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Remittance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RemittanceFromRaw.FromRawUnchecked"/>
    public static Remittance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Remittance(ApiEnum<string, Category> category)
        : this()
    {
        this.Category = category;
    }
}

class RemittanceFromRaw : IFromRawJson<Remittance>
{
    /// <inheritdoc/>
    public Remittance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Remittance.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of remittance information being passed.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    /// <summary>
    /// The wire transfer contains unstructured remittance information.
    /// </summary>
    Unstructured,

    /// <summary>
    /// The wire transfer is for tax payment purposes to the Internal Revenue Service (IRS).
    /// </summary>
    Tax,
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
            "unstructured" => Category.Unstructured,
            "tax" => Category.Tax,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.Unstructured => "unstructured",
                Category.Tax => "tax",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Internal Revenue Service (IRS) tax repayment information. Required if `category`
/// is equal to `tax`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Tax, TaxFromRaw>))]
public sealed record class Tax : JsonModel
{
    /// <summary>
    /// The month and year the tax payment is for, in YYYY-MM-DD format. The day
    /// is ignored.
    /// </summary>
    public required string Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("date");
        }
        init { this._rawData.Set("date", value); }
    }

    /// <summary>
    /// The 9-digit Tax Identification Number (TIN) or Employer Identification Number (EIN).
    /// </summary>
    public required string IdentificationNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("identification_number");
        }
        init { this._rawData.Set("identification_number", value); }
    }

    /// <summary>
    /// The 5-character tax type code.
    /// </summary>
    public required string TypeCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type_code");
        }
        init { this._rawData.Set("type_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Date;
        _ = this.IdentificationNumber;
        _ = this.TypeCode;
    }

    public Tax() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Tax(Tax tax)
        : base(tax) { }
#pragma warning restore CS8618

    public Tax(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tax(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TaxFromRaw.FromRawUnchecked"/>
    public static Tax FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TaxFromRaw : IFromRawJson<Tax>
{
    /// <inheritdoc/>
    public Tax FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tax.FromRawUnchecked(rawData);
}

/// <summary>
/// Unstructured remittance information. Required if `category` is equal to `unstructured`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RemittanceUnstructured, RemittanceUnstructuredFromRaw>))]
public sealed record class RemittanceUnstructured : JsonModel
{
    /// <summary>
    /// The information.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
    }

    public RemittanceUnstructured() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RemittanceUnstructured(RemittanceUnstructured remittanceUnstructured)
        : base(remittanceUnstructured) { }
#pragma warning restore CS8618

    public RemittanceUnstructured(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemittanceUnstructured(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RemittanceUnstructuredFromRaw.FromRawUnchecked"/>
    public static RemittanceUnstructured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RemittanceUnstructured(string message)
        : this()
    {
        this.Message = message;
    }
}

class RemittanceUnstructuredFromRaw : IFromRawJson<RemittanceUnstructured>
{
    /// <inheritdoc/>
    public RemittanceUnstructured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RemittanceUnstructured.FromRawUnchecked(rawData);
}

/// <summary>
/// The person or business whose funds are being transferred. This is only necessary
/// if you're transferring from a commingled account. Otherwise, we'll use the associated
/// entity's details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Debtor, DebtorFromRaw>))]
public sealed record class Debtor : JsonModel
{
    /// <summary>
    /// The person or business's name.
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

    /// <summary>
    /// The person or business's address.
    /// </summary>
    public DebtorAddress? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DebtorAddress>("address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        this.Address?.Validate();
    }

    public Debtor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Debtor(Debtor debtor)
        : base(debtor) { }
#pragma warning restore CS8618

    public Debtor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Debtor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DebtorFromRaw.FromRawUnchecked"/>
    public static Debtor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Debtor(string name)
        : this()
    {
        this.Name = name;
    }
}

class DebtorFromRaw : IFromRawJson<Debtor>
{
    /// <inheritdoc/>
    public Debtor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Debtor.FromRawUnchecked(rawData);
}

/// <summary>
/// The person or business's address.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DebtorAddress, DebtorAddressFromRaw>))]
public sealed record class DebtorAddress : JsonModel
{
    /// <summary>
    /// Unstructured address lines.
    /// </summary>
    public required DebtorAddressUnstructured Unstructured
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DebtorAddressUnstructured>("unstructured");
        }
        init { this._rawData.Set("unstructured", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Unstructured.Validate();
    }

    public DebtorAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DebtorAddress(DebtorAddress debtorAddress)
        : base(debtorAddress) { }
#pragma warning restore CS8618

    public DebtorAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DebtorAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DebtorAddressFromRaw.FromRawUnchecked"/>
    public static DebtorAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DebtorAddress(DebtorAddressUnstructured unstructured)
        : this()
    {
        this.Unstructured = unstructured;
    }
}

class DebtorAddressFromRaw : IFromRawJson<DebtorAddress>
{
    /// <inheritdoc/>
    public DebtorAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DebtorAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Unstructured address lines.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DebtorAddressUnstructured, DebtorAddressUnstructuredFromRaw>)
)]
public sealed record class DebtorAddressUnstructured : JsonModel
{
    /// <summary>
    /// The address line 1.
    /// </summary>
    public required string Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("line1");
        }
        init { this._rawData.Set("line1", value); }
    }

    /// <summary>
    /// The address line 2.
    /// </summary>
    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line2", value);
        }
    }

    /// <summary>
    /// The address line 3.
    /// </summary>
    public string? Line3
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line3");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line3", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Line1;
        _ = this.Line2;
        _ = this.Line3;
    }

    public DebtorAddressUnstructured() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DebtorAddressUnstructured(DebtorAddressUnstructured debtorAddressUnstructured)
        : base(debtorAddressUnstructured) { }
#pragma warning restore CS8618

    public DebtorAddressUnstructured(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DebtorAddressUnstructured(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DebtorAddressUnstructuredFromRaw.FromRawUnchecked"/>
    public static DebtorAddressUnstructured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DebtorAddressUnstructured(string line1)
        : this()
    {
        this.Line1 = line1;
    }
}

class DebtorAddressUnstructuredFromRaw : IFromRawJson<DebtorAddressUnstructured>
{
    /// <inheritdoc/>
    public DebtorAddressUnstructured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DebtorAddressUnstructured.FromRawUnchecked(rawData);
}
