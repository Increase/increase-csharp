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

namespace Increase.Api.Models.WireDrawdownRequests;

/// <summary>
/// Create a Wire Drawdown Request
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WireDrawdownRequestCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The Account Number to which the debtor should send funds.
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
    /// The amount requested from the debtor, in USD cents.
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
    /// The creditor's address.
    /// </summary>
    public required CreditorAddress CreditorAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<CreditorAddress>("creditor_address");
        }
        init { this._rawBodyData.Set("creditor_address", value); }
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
    /// The debtor's address.
    /// </summary>
    public required DebtorAddress DebtorAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<DebtorAddress>("debtor_address");
        }
        init { this._rawBodyData.Set("debtor_address", value); }
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
    /// Remittance information the debtor will see as part of the request.
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
    /// Determines who bears the cost of the drawdown request. Defaults to `shared`
    /// if not specified.
    /// </summary>
    public ApiEnum<string, ChargeBearer>? ChargeBearer
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ChargeBearer>>(
                "charge_bearer"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("charge_bearer", value);
        }
    }

    /// <summary>
    /// The debtor's account number.
    /// </summary>
    public string? DebtorAccountNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("debtor_account_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("debtor_account_number", value);
        }
    }

    /// <summary>
    /// The ID of an External Account to initiate a transfer to. If this parameter
    /// is provided, `debtor_account_number` and `debtor_routing_number` must be absent.
    /// </summary>
    public string? DebtorExternalAccountID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("debtor_external_account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("debtor_external_account_id", value);
        }
    }

    /// <summary>
    /// The debtor's routing number.
    /// </summary>
    public string? DebtorRoutingNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("debtor_routing_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("debtor_routing_number", value);
        }
    }

    /// <summary>
    /// A free-form reference string set by the sender mirrored back in the subsequent
    /// wire transfer.
    /// </summary>
    public string? EndToEndIdentification
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("end_to_end_identification");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("end_to_end_identification", value);
        }
    }

    public WireDrawdownRequestCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireDrawdownRequestCreateParams(
        WireDrawdownRequestCreateParams wireDrawdownRequestCreateParams
    )
        : base(wireDrawdownRequestCreateParams)
    {
        this._rawBodyData = new(wireDrawdownRequestCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WireDrawdownRequestCreateParams(
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
    WireDrawdownRequestCreateParams(
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
    public static WireDrawdownRequestCreateParams FromRawUnchecked(
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

    public virtual bool Equals(WireDrawdownRequestCreateParams? other)
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
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/wire_drawdown_requests"
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
    /// The two-letter [ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
    /// code for the country of the address.
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
    /// The first line of the address. This is usually the street number and street.
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
    /// The second line of the address. This might be the floor or room number.
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
    /// The ZIP code of the address.
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
    /// The address state.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Country;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.PostalCode;
        _ = this.State;
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
    /// The two-letter [ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
    /// code for the country of the address.
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
    /// The first line of the address. This is usually the street number and street.
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
    /// The second line of the address. This might be the floor or room number.
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
    /// The ZIP code of the address.
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
    /// The address state.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Country;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.PostalCode;
        _ = this.State;
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

/// <summary>
/// Determines who bears the cost of the drawdown request. Defaults to `shared` if
/// not specified.
/// </summary>
[JsonConverter(typeof(ChargeBearerConverter))]
public enum ChargeBearer
{
    /// <summary>
    /// Charges are shared between the debtor and creditor.
    /// </summary>
    Shared,

    /// <summary>
    /// Charges are borne by the debtor.
    /// </summary>
    Debtor,

    /// <summary>
    /// Charges are borne by the creditor.
    /// </summary>
    Creditor,

    /// <summary>
    /// Charges are determined by the service level.
    /// </summary>
    ServiceLevel,
}

sealed class ChargeBearerConverter : JsonConverter<ChargeBearer>
{
    public override ChargeBearer Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "shared" => ChargeBearer.Shared,
            "debtor" => ChargeBearer.Debtor,
            "creditor" => ChargeBearer.Creditor,
            "service_level" => ChargeBearer.ServiceLevel,
            _ => (ChargeBearer)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeBearer value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeBearer.Shared => "shared",
                ChargeBearer.Debtor => "debtor",
                ChargeBearer.Creditor => "creditor",
                ChargeBearer.ServiceLevel => "service_level",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
