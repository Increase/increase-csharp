using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.RealTimePaymentsRequestsForPayment;

/// <summary>
/// Create a Real-Time Payments Request for Payment
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RealTimePaymentsRequestsForPaymentCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The identifier of the Account Number where the funds will land.
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
    /// The requested amount in USD cents. Must be positive.
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
    /// Details of the person being requested to pay.
    /// </summary>
    public required Debtor Debtor
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Debtor>("debtor");
        }
        init { this._rawBodyData.Set("debtor", value); }
    }

    /// <summary>
    /// The debtor's account number, which the funds will be requested from.
    /// </summary>
    public required string DebtorAccountNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("debtor_account_number");
        }
        init { this._rawBodyData.Set("debtor_account_number", value); }
    }

    /// <summary>
    /// The debtor's American Bankers' Association (ABA) Routing Transit Number (RTN).
    /// </summary>
    public required string DebtorRoutingNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("debtor_routing_number");
        }
        init { this._rawBodyData.Set("debtor_routing_number", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time after
    /// which the request for payment is no longer valid. After this time the debtor's
    /// bank should no longer allow the debtor to pay it. Must not be before `requested_execution_at`.
    /// </summary>
    public required DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawBodyData.Set("expires_at", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time by which
    /// you are requesting the payment to be made.
    /// </summary>
    public required DateTimeOffset RequestedExecutionAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<DateTimeOffset>("requested_execution_at");
        }
        init { this._rawBodyData.Set("requested_execution_at", value); }
    }

    /// <summary>
    /// Unstructured information that will show on the recipient's bank statement.
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
    /// The name of the creditor requesting the payment. If not provided, defaults
    /// to the name of the account's entity.
    /// </summary>
    public string? CreditorName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("creditor_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("creditor_name", value);
        }
    }

    public RealTimePaymentsRequestsForPaymentCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimePaymentsRequestsForPaymentCreateParams(
        RealTimePaymentsRequestsForPaymentCreateParams realTimePaymentsRequestsForPaymentCreateParams
    )
        : base(realTimePaymentsRequestsForPaymentCreateParams)
    {
        this._rawBodyData = new(realTimePaymentsRequestsForPaymentCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RealTimePaymentsRequestsForPaymentCreateParams(
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
    RealTimePaymentsRequestsForPaymentCreateParams(
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
    public static RealTimePaymentsRequestsForPaymentCreateParams FromRawUnchecked(
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

    public virtual bool Equals(RealTimePaymentsRequestsForPaymentCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/real_time_payments_requests_for_payment"
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
/// Details of the person being requested to pay.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Debtor, DebtorFromRaw>))]
public sealed record class Debtor : JsonModel
{
    /// <summary>
    /// Address of the debtor.
    /// </summary>
    public required Address Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Address>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// The name of the debtor.
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
        this.Address.Validate();
        _ = this.Name;
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
}

class DebtorFromRaw : IFromRawJson<Debtor>
{
    /// <inheritdoc/>
    public Debtor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Debtor.FromRawUnchecked(rawData);
}

/// <summary>
/// Address of the debtor.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : JsonModel
{
    /// <summary>
    /// The ISO 3166, Alpha-2 country code.
    ///
    /// <para>Defaults to `US`.</para>
    /// </summary>
    public required string Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// A second address line, such as an apartment or suite number. The first address
    /// line is separated into `building_number` and `street_name`.
    /// </summary>
    public string? AddressLine2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("address_line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address_line2", value);
        }
    }

    /// <summary>
    /// The number identifying the position of the building on the street.
    /// </summary>
    public string? BuildingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("building_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("building_number", value);
        }
    }

    /// <summary>
    /// The town or city.
    /// </summary>
    public string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("city", value);
        }
    }

    /// <summary>
    /// The postal code or zip.
    /// </summary>
    public string? PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postal_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("postal_code", value);
        }
    }

    /// <summary>
    /// The US state component of the address.
    /// </summary>
    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <summary>
    /// The street name without the street number.
    /// </summary>
    public string? StreetName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("street_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("street_name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.AddressLine2;
        _ = this.BuildingNumber;
        _ = this.City;
        _ = this.PostalCode;
        _ = this.State;
        _ = this.StreetName;
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
    public Address(string country)
        : this()
    {
        this.Country = country;
    }
}

class AddressFromRaw : IFromRawJson<Address>
{
    /// <inheritdoc/>
    public Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Address.FromRawUnchecked(rawData);
}
