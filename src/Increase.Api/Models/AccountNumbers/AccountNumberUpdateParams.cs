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
    /// Options related to how this Account Number handles inbound ACH transfers.
    /// </summary>
    public AccountNumberUpdateParamsInboundAch? InboundAch
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AccountNumberUpdateParamsInboundAch>(
                "inbound_ach"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("inbound_ach", value);
        }
    }

    /// <summary>
    /// Options related to how this Account Number should handle inbound check withdrawals.
    /// </summary>
    public AccountNumberUpdateParamsInboundChecks? InboundChecks
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AccountNumberUpdateParamsInboundChecks>(
                "inbound_checks"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("inbound_checks", value);
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
    public ApiEnum<string, AccountNumberUpdateParamsStatus>? Status
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, AccountNumberUpdateParamsStatus>
            >("status");
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
/// Options related to how this Account Number handles inbound ACH transfers.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AccountNumberUpdateParamsInboundAch,
        AccountNumberUpdateParamsInboundAchFromRaw
    >)
)]
public sealed record class AccountNumberUpdateParamsInboundAch : JsonModel
{
    /// <summary>
    /// Whether ACH debits are allowed against this Account Number. Note that ACH
    /// debits will be declined if this is `allowed` but the Account Number is not active.
    /// </summary>
    public ApiEnum<string, AccountNumberUpdateParamsInboundAchDebitStatus>? DebitStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, AccountNumberUpdateParamsInboundAchDebitStatus>
            >("debit_status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("debit_status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DebitStatus?.Validate();
    }

    public AccountNumberUpdateParamsInboundAch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountNumberUpdateParamsInboundAch(
        AccountNumberUpdateParamsInboundAch accountNumberUpdateParamsInboundAch
    )
        : base(accountNumberUpdateParamsInboundAch) { }
#pragma warning restore CS8618

    public AccountNumberUpdateParamsInboundAch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountNumberUpdateParamsInboundAch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountNumberUpdateParamsInboundAchFromRaw.FromRawUnchecked"/>
    public static AccountNumberUpdateParamsInboundAch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountNumberUpdateParamsInboundAchFromRaw : IFromRawJson<AccountNumberUpdateParamsInboundAch>
{
    /// <inheritdoc/>
    public AccountNumberUpdateParamsInboundAch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountNumberUpdateParamsInboundAch.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether ACH debits are allowed against this Account Number. Note that ACH debits
/// will be declined if this is `allowed` but the Account Number is not active.
/// </summary>
[JsonConverter(typeof(AccountNumberUpdateParamsInboundAchDebitStatusConverter))]
public enum AccountNumberUpdateParamsInboundAchDebitStatus
{
    /// <summary>
    /// ACH Debits are allowed.
    /// </summary>
    Allowed,

    /// <summary>
    /// ACH Debits are blocked.
    /// </summary>
    Blocked,
}

sealed class AccountNumberUpdateParamsInboundAchDebitStatusConverter
    : JsonConverter<AccountNumberUpdateParamsInboundAchDebitStatus>
{
    public override AccountNumberUpdateParamsInboundAchDebitStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allowed" => AccountNumberUpdateParamsInboundAchDebitStatus.Allowed,
            "blocked" => AccountNumberUpdateParamsInboundAchDebitStatus.Blocked,
            _ => (AccountNumberUpdateParamsInboundAchDebitStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountNumberUpdateParamsInboundAchDebitStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountNumberUpdateParamsInboundAchDebitStatus.Allowed => "allowed",
                AccountNumberUpdateParamsInboundAchDebitStatus.Blocked => "blocked",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Options related to how this Account Number should handle inbound check withdrawals.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AccountNumberUpdateParamsInboundChecks,
        AccountNumberUpdateParamsInboundChecksFromRaw
    >)
)]
public sealed record class AccountNumberUpdateParamsInboundChecks : JsonModel
{
    /// <summary>
    /// How Increase should process checks with this account number printed on them.
    /// </summary>
    public required ApiEnum<string, AccountNumberUpdateParamsInboundChecksStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountNumberUpdateParamsInboundChecksStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
    }

    public AccountNumberUpdateParamsInboundChecks() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountNumberUpdateParamsInboundChecks(
        AccountNumberUpdateParamsInboundChecks accountNumberUpdateParamsInboundChecks
    )
        : base(accountNumberUpdateParamsInboundChecks) { }
#pragma warning restore CS8618

    public AccountNumberUpdateParamsInboundChecks(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountNumberUpdateParamsInboundChecks(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountNumberUpdateParamsInboundChecksFromRaw.FromRawUnchecked"/>
    public static AccountNumberUpdateParamsInboundChecks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AccountNumberUpdateParamsInboundChecks(
        ApiEnum<string, AccountNumberUpdateParamsInboundChecksStatus> status
    )
        : this()
    {
        this.Status = status;
    }
}

class AccountNumberUpdateParamsInboundChecksFromRaw
    : IFromRawJson<AccountNumberUpdateParamsInboundChecks>
{
    /// <inheritdoc/>
    public AccountNumberUpdateParamsInboundChecks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountNumberUpdateParamsInboundChecks.FromRawUnchecked(rawData);
}

/// <summary>
/// How Increase should process checks with this account number printed on them.
/// </summary>
[JsonConverter(typeof(AccountNumberUpdateParamsInboundChecksStatusConverter))]
public enum AccountNumberUpdateParamsInboundChecksStatus
{
    /// <summary>
    /// Checks with this Account Number will be processed even if they are not associated
    /// with a Check Transfer.
    /// </summary>
    Allowed,

    /// <summary>
    /// Checks with this Account Number will be processed only if they can be matched
    /// to an existing Check Transfer.
    /// </summary>
    CheckTransfersOnly,
}

sealed class AccountNumberUpdateParamsInboundChecksStatusConverter
    : JsonConverter<AccountNumberUpdateParamsInboundChecksStatus>
{
    public override AccountNumberUpdateParamsInboundChecksStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allowed" => AccountNumberUpdateParamsInboundChecksStatus.Allowed,
            "check_transfers_only" =>
                AccountNumberUpdateParamsInboundChecksStatus.CheckTransfersOnly,
            _ => (AccountNumberUpdateParamsInboundChecksStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountNumberUpdateParamsInboundChecksStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountNumberUpdateParamsInboundChecksStatus.Allowed => "allowed",
                AccountNumberUpdateParamsInboundChecksStatus.CheckTransfersOnly =>
                    "check_transfers_only",
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
[JsonConverter(typeof(AccountNumberUpdateParamsStatusConverter))]
public enum AccountNumberUpdateParamsStatus
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

sealed class AccountNumberUpdateParamsStatusConverter
    : JsonConverter<AccountNumberUpdateParamsStatus>
{
    public override AccountNumberUpdateParamsStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => AccountNumberUpdateParamsStatus.Active,
            "disabled" => AccountNumberUpdateParamsStatus.Disabled,
            "canceled" => AccountNumberUpdateParamsStatus.Canceled,
            _ => (AccountNumberUpdateParamsStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountNumberUpdateParamsStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountNumberUpdateParamsStatus.Active => "active",
                AccountNumberUpdateParamsStatus.Disabled => "disabled",
                AccountNumberUpdateParamsStatus.Canceled => "canceled",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
