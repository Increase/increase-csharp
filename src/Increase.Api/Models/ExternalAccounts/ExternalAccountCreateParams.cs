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

namespace Increase.Api.Models.ExternalAccounts;

/// <summary>
/// Create an External Account
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExternalAccountCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The account number for the destination account.
    /// </summary>
    public required string AccountNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("account_number");
        }
        init { this._rawBodyData.Set("account_number", value); }
    }

    /// <summary>
    /// The name you choose for the Account.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// The American Bankers' Association (ABA) Routing Transit Number (RTN) for
    /// the destination account.
    /// </summary>
    public required string RoutingNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("routing_number");
        }
        init { this._rawBodyData.Set("routing_number", value); }
    }

    /// <summary>
    /// The type of entity that owns the External Account.
    /// </summary>
    public ApiEnum<string, AccountHolder>? AccountHolder
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, AccountHolder>>(
                "account_holder"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("account_holder", value);
        }
    }

    /// <summary>
    /// The type of the destination account. Defaults to `checking`.
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

    public ExternalAccountCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalAccountCreateParams(ExternalAccountCreateParams externalAccountCreateParams)
        : base(externalAccountCreateParams)
    {
        this._rawBodyData = new(externalAccountCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ExternalAccountCreateParams(
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
    ExternalAccountCreateParams(
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
    public static ExternalAccountCreateParams FromRawUnchecked(
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

    public virtual bool Equals(ExternalAccountCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/external_accounts"
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
/// The type of entity that owns the External Account.
/// </summary>
[JsonConverter(typeof(AccountHolderConverter))]
public enum AccountHolder
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

sealed class AccountHolderConverter : JsonConverter<AccountHolder>
{
    public override AccountHolder Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "business" => AccountHolder.Business,
            "individual" => AccountHolder.Individual,
            "unknown" => AccountHolder.Unknown,
            _ => (AccountHolder)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountHolder value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountHolder.Business => "business",
                AccountHolder.Individual => "individual",
                AccountHolder.Unknown => "unknown",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of the destination account. Defaults to `checking`.
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
    /// A general ledger account.
    /// </summary>
    GeneralLedger,

    /// <summary>
    /// A different type of account.
    /// </summary>
    Other,
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
            "other" => Funding.Other,
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
                Funding.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
