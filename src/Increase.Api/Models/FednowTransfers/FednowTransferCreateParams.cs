using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.FednowTransfers;

/// <summary>
/// Create a FedNow Transfer
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FednowTransferCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The amount, in minor units, to send to the creditor.
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
    /// The creditor's name.
    /// </summary>
    public required string CreditorName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("creditor_name");
        }
        init { this._rawBodyData.Set("creditor_name", value); }
    }

    /// <summary>
    /// The debtor's name.
    /// </summary>
    public required string DebtorName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("debtor_name");
        }
        init { this._rawBodyData.Set("debtor_name", value); }
    }

    /// <summary>
    /// The Account Number to include in the transfer as the debtor's account number.
    /// </summary>
    public required string SourceAccountNumberID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("source_account_number_id");
        }
        init { this._rawBodyData.Set("source_account_number_id", value); }
    }

    /// <summary>
    /// Unstructured remittance information to include in the transfer.
    /// </summary>
    public required string UnstructuredRemittanceInformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("unstructured_remittance_information");
        }
        init { this._rawBodyData.Set("unstructured_remittance_information", value); }
    }

    /// <summary>
    /// The creditor's account number.
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
    /// The creditor's address.
    /// </summary>
    public CreditorAddress? CreditorAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CreditorAddress>("creditor_address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("creditor_address", value);
        }
    }

    /// <summary>
    /// The debtor's address.
    /// </summary>
    public DebtorAddress? DebtorAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<DebtorAddress>("debtor_address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("debtor_address", value);
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
    /// The creditor's bank account routing number.
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

    public FednowTransferCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FednowTransferCreateParams(FednowTransferCreateParams fednowTransferCreateParams)
        : base(fednowTransferCreateParams)
    {
        this._rawBodyData = new(fednowTransferCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public FednowTransferCreateParams(
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
    FednowTransferCreateParams(
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
    public static FednowTransferCreateParams FromRawUnchecked(
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

    public virtual bool Equals(FednowTransferCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/fednow_transfers")
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
/// The creditor's address.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreditorAddress, CreditorAddressFromRaw>))]
public sealed record class CreditorAddress : JsonModel
{
    /// <summary>
    /// The city, district, town, or village of the address.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The postal code component of the address.
    /// </summary>
    public required string PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <summary>
    /// The US state component of the address.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The first line of the address. This is usually the street number and street.
    /// </summary>
    public string? Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line1");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line1", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.PostalCode;
        _ = this.State;
        _ = this.Line1;
    }

    public CreditorAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditorAddress(CreditorAddress creditorAddress)
        : base(creditorAddress) { }
#pragma warning restore CS8618

    public CreditorAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditorAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditorAddressFromRaw.FromRawUnchecked"/>
    public static CreditorAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditorAddressFromRaw : IFromRawJson<CreditorAddress>
{
    /// <inheritdoc/>
    public CreditorAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreditorAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The debtor's address.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DebtorAddress, DebtorAddressFromRaw>))]
public sealed record class DebtorAddress : JsonModel
{
    /// <summary>
    /// The city, district, town, or village of the address.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The postal code component of the address.
    /// </summary>
    public required string PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <summary>
    /// The US state component of the address.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The first line of the address. This is usually the street number and street.
    /// </summary>
    public string? Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line1");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line1", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.PostalCode;
        _ = this.State;
        _ = this.Line1;
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
}

class DebtorAddressFromRaw : IFromRawJson<DebtorAddress>
{
    /// <inheritdoc/>
    public DebtorAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DebtorAddress.FromRawUnchecked(rawData);
}
