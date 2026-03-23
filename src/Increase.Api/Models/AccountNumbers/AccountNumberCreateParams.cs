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
    /// Options related to how this Account Number should handle inbound ACH transfers.
    /// </summary>
    public InboundAch? InboundAch
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InboundAch>("inbound_ach");
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
    public InboundChecks? InboundChecks
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InboundChecks>("inbound_checks");
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
/// Options related to how this Account Number should handle inbound ACH transfers.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InboundAch, InboundAchFromRaw>))]
public sealed record class InboundAch : JsonModel
{
    /// <summary>
    /// Whether ACH debits are allowed against this Account Number. Note that ACH
    /// debits will be declined if this is `allowed` but the Account Number is not
    /// active. If you do not specify this field, the default is `allowed`.
    /// </summary>
    public required ApiEnum<string, DebitStatus> DebitStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DebitStatus>>("debit_status");
        }
        init { this._rawData.Set("debit_status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DebitStatus.Validate();
    }

    public InboundAch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundAch(InboundAch inboundAch)
        : base(inboundAch) { }
#pragma warning restore CS8618

    public InboundAch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundAch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundAchFromRaw.FromRawUnchecked"/>
    public static InboundAch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InboundAch(ApiEnum<string, DebitStatus> debitStatus)
        : this()
    {
        this.DebitStatus = debitStatus;
    }
}

class InboundAchFromRaw : IFromRawJson<InboundAch>
{
    /// <inheritdoc/>
    public InboundAch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InboundAch.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether ACH debits are allowed against this Account Number. Note that ACH debits
/// will be declined if this is `allowed` but the Account Number is not active. If
/// you do not specify this field, the default is `allowed`.
/// </summary>
[JsonConverter(typeof(DebitStatusConverter))]
public enum DebitStatus
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

sealed class DebitStatusConverter : JsonConverter<DebitStatus>
{
    public override DebitStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allowed" => DebitStatus.Allowed,
            "blocked" => DebitStatus.Blocked,
            _ => (DebitStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DebitStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DebitStatus.Allowed => "allowed",
                DebitStatus.Blocked => "blocked",
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
[JsonConverter(typeof(JsonModelConverter<InboundChecks, InboundChecksFromRaw>))]
public sealed record class InboundChecks : JsonModel
{
    /// <summary>
    /// How Increase should process checks with this account number printed on them.
    /// If you do not specify this field, the default is `check_transfers_only`.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
    }

    public InboundChecks() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundChecks(InboundChecks inboundChecks)
        : base(inboundChecks) { }
#pragma warning restore CS8618

    public InboundChecks(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundChecks(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundChecksFromRaw.FromRawUnchecked"/>
    public static InboundChecks FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InboundChecks(ApiEnum<string, Status> status)
        : this()
    {
        this.Status = status;
    }
}

class InboundChecksFromRaw : IFromRawJson<InboundChecks>
{
    /// <inheritdoc/>
    public InboundChecks FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InboundChecks.FromRawUnchecked(rawData);
}

/// <summary>
/// How Increase should process checks with this account number printed on them.
/// If you do not specify this field, the default is `check_transfers_only`.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
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
            "allowed" => Status.Allowed,
            "check_transfers_only" => Status.CheckTransfersOnly,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Allowed => "allowed",
                Status.CheckTransfersOnly => "check_transfers_only",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
