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
/// Update an External Account
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExternalAccountUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ExternalAccountID { get; init; }

    /// <summary>
    /// The type of entity that owns the External Account.
    /// </summary>
    public ApiEnum<string, ExternalAccountUpdateParamsAccountHolder>? AccountHolder
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ExternalAccountUpdateParamsAccountHolder>
            >("account_holder");
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
    /// The description you choose to give the external account.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    /// <summary>
    /// The funding type of the External Account.
    /// </summary>
    public ApiEnum<string, ExternalAccountUpdateParamsFunding>? Funding
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ExternalAccountUpdateParamsFunding>
            >("funding");
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
    /// The status of the External Account.
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("status", value);
        }
    }

    public ExternalAccountUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalAccountUpdateParams(ExternalAccountUpdateParams externalAccountUpdateParams)
        : base(externalAccountUpdateParams)
    {
        this.ExternalAccountID = externalAccountUpdateParams.ExternalAccountID;

        this._rawBodyData = new(externalAccountUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ExternalAccountUpdateParams(
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
    ExternalAccountUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string externalAccountID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ExternalAccountID = externalAccountID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExternalAccountUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string externalAccountID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            externalAccountID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ExternalAccountID"] = JsonSerializer.SerializeToElement(
                        this.ExternalAccountID
                    ),
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

    public virtual bool Equals(ExternalAccountUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.ExternalAccountID?.Equals(other.ExternalAccountID)
                ?? other.ExternalAccountID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/external_accounts/{0}", this.ExternalAccountID)
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
[JsonConverter(typeof(ExternalAccountUpdateParamsAccountHolderConverter))]
public enum ExternalAccountUpdateParamsAccountHolder
{
    /// <summary>
    /// The External Account is owned by a business.
    /// </summary>
    Business,

    /// <summary>
    /// The External Account is owned by an individual.
    /// </summary>
    Individual,
}

sealed class ExternalAccountUpdateParamsAccountHolderConverter
    : JsonConverter<ExternalAccountUpdateParamsAccountHolder>
{
    public override ExternalAccountUpdateParamsAccountHolder Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "business" => ExternalAccountUpdateParamsAccountHolder.Business,
            "individual" => ExternalAccountUpdateParamsAccountHolder.Individual,
            _ => (ExternalAccountUpdateParamsAccountHolder)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExternalAccountUpdateParamsAccountHolder value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExternalAccountUpdateParamsAccountHolder.Business => "business",
                ExternalAccountUpdateParamsAccountHolder.Individual => "individual",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The funding type of the External Account.
/// </summary>
[JsonConverter(typeof(ExternalAccountUpdateParamsFundingConverter))]
public enum ExternalAccountUpdateParamsFunding
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

sealed class ExternalAccountUpdateParamsFundingConverter
    : JsonConverter<ExternalAccountUpdateParamsFunding>
{
    public override ExternalAccountUpdateParamsFunding Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "checking" => ExternalAccountUpdateParamsFunding.Checking,
            "savings" => ExternalAccountUpdateParamsFunding.Savings,
            "general_ledger" => ExternalAccountUpdateParamsFunding.GeneralLedger,
            "other" => ExternalAccountUpdateParamsFunding.Other,
            _ => (ExternalAccountUpdateParamsFunding)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExternalAccountUpdateParamsFunding value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExternalAccountUpdateParamsFunding.Checking => "checking",
                ExternalAccountUpdateParamsFunding.Savings => "savings",
                ExternalAccountUpdateParamsFunding.GeneralLedger => "general_ledger",
                ExternalAccountUpdateParamsFunding.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the External Account.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// The External Account is active.
    /// </summary>
    Active,

    /// <summary>
    /// The External Account is archived and won't appear in the dashboard.
    /// </summary>
    Archived,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => Status.Active,
            "archived" => Status.Archived,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "active",
                Status.Archived => "archived",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
