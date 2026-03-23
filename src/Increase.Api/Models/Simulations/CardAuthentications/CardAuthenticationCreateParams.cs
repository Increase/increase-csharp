using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;

namespace Increase.Api.Models.Simulations.CardAuthentications;

/// <summary>
/// Simulates a Card Authentication attempt on a [Card](#cards). The attempt always
/// results in a [Card Payment](#card_payments) being created, either with a status
/// that allows further action or a terminal failed status.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CardAuthenticationCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The identifier of the Card to be authorized.
    /// </summary>
    public required string CardID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("card_id");
        }
        init { this._rawBodyData.Set("card_id", value); }
    }

    /// <summary>
    /// The category of the card authentication attempt.
    /// </summary>
    public ApiEnum<string, Category>? Category
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Category>>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("category", value);
        }
    }

    /// <summary>
    /// The device channel of the card authentication attempt.
    /// </summary>
    public ApiEnum<string, DeviceChannel>? DeviceChannel
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, DeviceChannel>>(
                "device_channel"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("device_channel", value);
        }
    }

    /// <summary>
    /// The merchant identifier (commonly abbreviated as MID) of the merchant the
    /// card is transacting with.
    /// </summary>
    public string? MerchantAcceptorID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("merchant_acceptor_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("merchant_acceptor_id", value);
        }
    }

    /// <summary>
    /// The Merchant Category Code (commonly abbreviated as MCC) of the merchant the
    /// card is transacting with.
    /// </summary>
    public string? MerchantCategoryCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("merchant_category_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("merchant_category_code", value);
        }
    }

    /// <summary>
    /// The country the merchant resides in.
    /// </summary>
    public string? MerchantCountry
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("merchant_country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("merchant_country", value);
        }
    }

    /// <summary>
    /// The name of the merchant
    /// </summary>
    public string? MerchantName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("merchant_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("merchant_name", value);
        }
    }

    /// <summary>
    /// The purchase amount in cents.
    /// </summary>
    public long? PurchaseAmount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("purchase_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("purchase_amount", value);
        }
    }

    public CardAuthenticationCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthenticationCreateParams(
        CardAuthenticationCreateParams cardAuthenticationCreateParams
    )
        : base(cardAuthenticationCreateParams)
    {
        this._rawBodyData = new(cardAuthenticationCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CardAuthenticationCreateParams(
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
    CardAuthenticationCreateParams(
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
    public static CardAuthenticationCreateParams FromRawUnchecked(
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

    public virtual bool Equals(CardAuthenticationCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/simulations/card_authentications"
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
/// The category of the card authentication attempt.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    /// <summary>
    /// The authentication attempt is for a payment.
    /// </summary>
    PaymentAuthentication,

    /// <summary>
    /// The authentication attempt is not for a payment.
    /// </summary>
    NonPaymentAuthentication,
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
            "payment_authentication" => Category.PaymentAuthentication,
            "non_payment_authentication" => Category.NonPaymentAuthentication,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.PaymentAuthentication => "payment_authentication",
                Category.NonPaymentAuthentication => "non_payment_authentication",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The device channel of the card authentication attempt.
/// </summary>
[JsonConverter(typeof(DeviceChannelConverter))]
public enum DeviceChannel
{
    /// <summary>
    /// The authentication attempt was made from an app.
    /// </summary>
    App,

    /// <summary>
    /// The authentication attempt was made from a browser.
    /// </summary>
    Browser,

    /// <summary>
    /// The authentication attempt was initiated by the 3DS Requestor.
    /// </summary>
    ThreeDSRequestorInitiated,
}

sealed class DeviceChannelConverter : JsonConverter<DeviceChannel>
{
    public override DeviceChannel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "app" => DeviceChannel.App,
            "browser" => DeviceChannel.Browser,
            "three_ds_requestor_initiated" => DeviceChannel.ThreeDSRequestorInitiated,
            _ => (DeviceChannel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeviceChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DeviceChannel.App => "app",
                DeviceChannel.Browser => "browser",
                DeviceChannel.ThreeDSRequestorInitiated => "three_ds_requestor_initiated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
