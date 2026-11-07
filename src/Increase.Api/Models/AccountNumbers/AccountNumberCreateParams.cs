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

namespace Increase.Api.Models.AccountNumbers;

/// <summary>
/// Create an Account Number
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AccountNumberCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The Account the Account Number should belong to.
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
    /// The name you choose for the Account Number.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Whether inbound ACH debits are allowed against this Account Number. Note that
    /// ACH debits will be declined if this is `allowed` but the Account Number is
    /// not active. If you do not specify this field, the default is `allowed`.
    /// </summary>
    public ApiEnum<string, InboundAchDebits>? InboundAchDebits
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, InboundAchDebits>>(
                "inbound_ach_debits"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("inbound_ach_debits", value);
        }
    }

    /// <summary>
    /// Whether unregistered inbound checks for this Account Number can be deposited.
    /// If you do not specify this field, the default is `blocked`.
    /// </summary>
    public ApiEnum<string, UnregisteredInboundChecks>? UnregisteredInboundChecks
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, UnregisteredInboundChecks>>(
                "unregistered_inbound_checks"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("unregistered_inbound_checks", value);
        }
    }

    public AccountNumberCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountNumberCreateParams(AccountNumberCreateParams accountNumberCreateParams)
        : base(accountNumberCreateParams)
    {
        this._rawBodyData = new(accountNumberCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AccountNumberCreateParams(
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
    AccountNumberCreateParams(
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
    public static AccountNumberCreateParams FromRawUnchecked(
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

    public virtual bool Equals(AccountNumberCreateParams? other)
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/account_numbers")
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
/// Whether inbound ACH debits are allowed against this Account Number. Note that
/// ACH debits will be declined if this is `allowed` but the Account Number is not
/// active. If you do not specify this field, the default is `allowed`.
/// </summary>
[JsonConverter(typeof(InboundAchDebitsConverter))]
public enum InboundAchDebits
{
    /// <summary>
    /// ACH Debits are allowed.
    /// </summary>
    Allowed,

    /// <summary>
    /// ACH Debits are blocked. Received debits will be declined and returned with
    /// code `R20` (non-transaction account).
    /// </summary>
    Blocked,
}

sealed class InboundAchDebitsConverter : JsonConverter<InboundAchDebits>
{
    public override InboundAchDebits Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allowed" => InboundAchDebits.Allowed,
            "blocked" => InboundAchDebits.Blocked,
            _ => (InboundAchDebits)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundAchDebits value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InboundAchDebits.Allowed => "allowed",
                InboundAchDebits.Blocked => "blocked",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether unregistered inbound checks for this Account Number can be deposited.
/// If you do not specify this field, the default is `blocked`.
/// </summary>
[JsonConverter(typeof(UnregisteredInboundChecksConverter))]
public enum UnregisteredInboundChecks
{
    /// <summary>
    /// Accept all Inbound Check Deposits, even if they are not associated with a
    /// Check Transfer or Checkbook Check.
    /// </summary>
    Allowed,

    /// <summary>
    /// Only accept Inbound Check Deposits if they can be matched to a Check Transfer
    /// or Checkbook Check.
    /// </summary>
    Blocked,
}

sealed class UnregisteredInboundChecksConverter : JsonConverter<UnregisteredInboundChecks>
{
    public override UnregisteredInboundChecks Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allowed" => UnregisteredInboundChecks.Allowed,
            "blocked" => UnregisteredInboundChecks.Blocked,
            _ => (UnregisteredInboundChecks)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnregisteredInboundChecks value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnregisteredInboundChecks.Allowed => "allowed",
                UnregisteredInboundChecks.Blocked => "blocked",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
