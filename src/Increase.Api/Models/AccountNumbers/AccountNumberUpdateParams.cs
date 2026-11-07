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
/// Update an Account Number
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AccountNumberUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? AccountNumberID { get; init; }

    /// <summary>
    /// Whether inbound ACH debits are allowed against this Account Number. Note that
    /// ACH debits will be declined if this is `allowed` but the Account Number is
    /// not active.
    /// </summary>
    public ApiEnum<string, AccountNumberUpdateParamsInboundAchDebits>? InboundAchDebits
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, AccountNumberUpdateParamsInboundAchDebits>
            >("inbound_ach_debits");
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
    /// The name you choose for the Account Number.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    /// <summary>
    /// This indicates if transfers can be made to the Account Number.
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

    /// <summary>
    /// Whether unregistered inbound checks for this Account Number can be deposited.
    /// </summary>
    public ApiEnum<
        string,
        AccountNumberUpdateParamsUnregisteredInboundChecks
    >? UnregisteredInboundChecks
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, AccountNumberUpdateParamsUnregisteredInboundChecks>
            >("unregistered_inbound_checks");
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

    public AccountNumberUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountNumberUpdateParams(AccountNumberUpdateParams accountNumberUpdateParams)
        : base(accountNumberUpdateParams)
    {
        this.AccountNumberID = accountNumberUpdateParams.AccountNumberID;

        this._rawBodyData = new(accountNumberUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AccountNumberUpdateParams(
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
    AccountNumberUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string accountNumberID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.AccountNumberID = accountNumberID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AccountNumberUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string accountNumberID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            accountNumberID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["AccountNumberID"] = JsonSerializer.SerializeToElement(this.AccountNumberID),
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

    public virtual bool Equals(AccountNumberUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.AccountNumberID?.Equals(other.AccountNumberID) ?? other.AccountNumberID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/account_numbers/{0}", this.AccountNumberID)
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
/// Whether inbound ACH debits are allowed against this Account Number. Note that
/// ACH debits will be declined if this is `allowed` but the Account Number is not active.
/// </summary>
[JsonConverter(typeof(AccountNumberUpdateParamsInboundAchDebitsConverter))]
public enum AccountNumberUpdateParamsInboundAchDebits
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

sealed class AccountNumberUpdateParamsInboundAchDebitsConverter
    : JsonConverter<AccountNumberUpdateParamsInboundAchDebits>
{
    public override AccountNumberUpdateParamsInboundAchDebits Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allowed" => AccountNumberUpdateParamsInboundAchDebits.Allowed,
            "blocked" => AccountNumberUpdateParamsInboundAchDebits.Blocked,
            _ => (AccountNumberUpdateParamsInboundAchDebits)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountNumberUpdateParamsInboundAchDebits value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountNumberUpdateParamsInboundAchDebits.Allowed => "allowed",
                AccountNumberUpdateParamsInboundAchDebits.Blocked => "blocked",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// This indicates if transfers can be made to the Account Number.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// The account number is active.
    /// </summary>
    Active,

    /// <summary>
    /// The account number is temporarily disabled.
    /// </summary>
    Disabled,

    /// <summary>
    /// The account number is permanently disabled.
    /// </summary>
    Canceled,
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
            "disabled" => Status.Disabled,
            "canceled" => Status.Canceled,
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
                Status.Disabled => "disabled",
                Status.Canceled => "canceled",
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
/// </summary>
[JsonConverter(typeof(AccountNumberUpdateParamsUnregisteredInboundChecksConverter))]
public enum AccountNumberUpdateParamsUnregisteredInboundChecks
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

sealed class AccountNumberUpdateParamsUnregisteredInboundChecksConverter
    : JsonConverter<AccountNumberUpdateParamsUnregisteredInboundChecks>
{
    public override AccountNumberUpdateParamsUnregisteredInboundChecks Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allowed" => AccountNumberUpdateParamsUnregisteredInboundChecks.Allowed,
            "blocked" => AccountNumberUpdateParamsUnregisteredInboundChecks.Blocked,
            _ => (AccountNumberUpdateParamsUnregisteredInboundChecks)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountNumberUpdateParamsUnregisteredInboundChecks value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountNumberUpdateParamsUnregisteredInboundChecks.Allowed => "allowed",
                AccountNumberUpdateParamsUnregisteredInboundChecks.Blocked => "blocked",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
