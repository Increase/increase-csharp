using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.CardValidations;

/// <summary>
/// Create a Card Validation
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CardValidationCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The identifier of the Account from which to send the validation.
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
    /// The Increase identifier for the Card Token that represents the card number
    /// you're validating.
    /// </summary>
    public required string CardTokenID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("card_token_id");
        }
        init { this._rawBodyData.Set("card_token_id", value); }
    }

    /// <summary>
    /// A four-digit code (MCC) identifying the type of business or service provided
    /// by the merchant.
    /// </summary>
    public required string MerchantCategoryCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("merchant_category_code");
        }
        init { this._rawBodyData.Set("merchant_category_code", value); }
    }

    /// <summary>
    /// The city where the merchant (typically your business) is located.
    /// </summary>
    public required string MerchantCityName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("merchant_city_name");
        }
        init { this._rawBodyData.Set("merchant_city_name", value); }
    }

    /// <summary>
    /// The merchant name that will appear in the cardholder’s statement descriptor.
    /// Typically your business name.
    /// </summary>
    public required string MerchantName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("merchant_name");
        }
        init { this._rawBodyData.Set("merchant_name", value); }
    }

    /// <summary>
    /// The postal code for the merchant’s (typically your business’s) location.
    /// </summary>
    public required string MerchantPostalCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("merchant_postal_code");
        }
        init { this._rawBodyData.Set("merchant_postal_code", value); }
    }

    /// <summary>
    /// The U.S. state where the merchant (typically your business) is located.
    /// </summary>
    public required string MerchantState
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("merchant_state");
        }
        init { this._rawBodyData.Set("merchant_state", value); }
    }

    /// <summary>
    /// The cardholder's first name.
    /// </summary>
    public string? CardholderFirstName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("cardholder_first_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("cardholder_first_name", value);
        }
    }

    /// <summary>
    /// The cardholder's last name.
    /// </summary>
    public string? CardholderLastName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("cardholder_last_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("cardholder_last_name", value);
        }
    }

    /// <summary>
    /// The cardholder's middle name.
    /// </summary>
    public string? CardholderMiddleName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("cardholder_middle_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("cardholder_middle_name", value);
        }
    }

    /// <summary>
    /// The postal code of the cardholder's address.
    /// </summary>
    public string? CardholderPostalCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("cardholder_postal_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("cardholder_postal_code", value);
        }
    }

    /// <summary>
    /// The cardholder's street address.
    /// </summary>
    public string? CardholderStreetAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("cardholder_street_address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("cardholder_street_address", value);
        }
    }

    public CardValidationCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationCreateParams(CardValidationCreateParams cardValidationCreateParams)
        : base(cardValidationCreateParams)
    {
        this._rawBodyData = new(cardValidationCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CardValidationCreateParams(
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
    CardValidationCreateParams(
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
    public static CardValidationCreateParams FromRawUnchecked(
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

    public virtual bool Equals(CardValidationCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/card_validations")
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
