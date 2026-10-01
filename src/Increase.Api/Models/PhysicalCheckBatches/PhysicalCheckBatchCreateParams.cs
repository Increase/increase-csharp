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

namespace Increase.Api.Models.PhysicalCheckBatches;

/// <summary>
/// Create a Physical Check Batch
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhysicalCheckBatchCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Details for where the parcel will be mailed.
    /// </summary>
    public required MailingAddress MailingAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<MailingAddress>("mailing_address");
        }
        init { this._rawBodyData.Set("mailing_address", value); }
    }

    /// <summary>
    /// Details for where the parcel should return if it is unable to be delivered.
    /// </summary>
    public required ReturnAddress ReturnAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ReturnAddress>("return_address");
        }
        init { this._rawBodyData.Set("return_address", value); }
    }

    /// <summary>
    /// How to ship the batch.
    ///
    /// <para>Defaults to `usps_first_class`.</para>
    /// </summary>
    public ApiEnum<string, ShippingMethod>? ShippingMethod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ShippingMethod>>(
                "shipping_method"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("shipping_method", value);
        }
    }

    public PhysicalCheckBatchCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCheckBatchCreateParams(
        PhysicalCheckBatchCreateParams physicalCheckBatchCreateParams
    )
        : base(physicalCheckBatchCreateParams)
    {
        this._rawBodyData = new(physicalCheckBatchCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PhysicalCheckBatchCreateParams(
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
    PhysicalCheckBatchCreateParams(
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
    public static PhysicalCheckBatchCreateParams FromRawUnchecked(
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

    public virtual bool Equals(PhysicalCheckBatchCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/physical_check_batches"
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
/// Details for where the parcel will be mailed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MailingAddress, MailingAddressFromRaw>))]
public sealed record class MailingAddress : JsonModel
{
    /// <summary>
    /// The city of the destination address.
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
    /// The first line of the destination address.
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
    /// The recipient at the destination address.
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
    /// The postal code of the destination address.
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
    /// The US state of the destination address.
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
    /// The second line of the destination address.
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
    /// The phone number used for delivery issues at the destination address. Only
    /// used when `shipping_method` is `fedex_overnight`.
    /// </summary>
    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.Name;
        _ = this.PostalCode;
        _ = this.State;
        _ = this.Line2;
        _ = this.Phone;
    }

    public MailingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MailingAddress(MailingAddress mailingAddress)
        : base(mailingAddress) { }
#pragma warning restore CS8618

    public MailingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MailingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MailingAddressFromRaw.FromRawUnchecked"/>
    public static MailingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MailingAddressFromRaw : IFromRawJson<MailingAddress>
{
    /// <inheritdoc/>
    public MailingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MailingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Details for where the parcel should return if it is unable to be delivered.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReturnAddress, ReturnAddressFromRaw>))]
public sealed record class ReturnAddress : JsonModel
{
    /// <summary>
    /// The city of the return address.
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
    /// The first line of the return address.
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
    /// The recipient at the return address.
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
    /// The postal code of the return address.
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
    /// The US state of the return address.
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
    /// The second line of the return address.
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
    /// The phone number used for delivery issues at the return address. Only used
    /// when `shipping_method` is `fedex_overnight`.
    /// </summary>
    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.Name;
        _ = this.PostalCode;
        _ = this.State;
        _ = this.Line2;
        _ = this.Phone;
    }

    public ReturnAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReturnAddress(ReturnAddress returnAddress)
        : base(returnAddress) { }
#pragma warning restore CS8618

    public ReturnAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReturnAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReturnAddressFromRaw.FromRawUnchecked"/>
    public static ReturnAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReturnAddressFromRaw : IFromRawJson<ReturnAddress>
{
    /// <inheritdoc/>
    public ReturnAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReturnAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// How to ship the batch.
/// </summary>
[JsonConverter(typeof(ShippingMethodConverter))]
public enum ShippingMethod
{
    /// <summary>
    /// USPS First Class
    /// </summary>
    UspsFirstClass,

    /// <summary>
    /// FedEx Overnight
    /// </summary>
    FedexOvernight,
}

sealed class ShippingMethodConverter : JsonConverter<ShippingMethod>
{
    public override ShippingMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usps_first_class" => ShippingMethod.UspsFirstClass,
            "fedex_overnight" => ShippingMethod.FedexOvernight,
            _ => (ShippingMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShippingMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShippingMethod.UspsFirstClass => "usps_first_class",
                ShippingMethod.FedexOvernight => "fedex_overnight",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
