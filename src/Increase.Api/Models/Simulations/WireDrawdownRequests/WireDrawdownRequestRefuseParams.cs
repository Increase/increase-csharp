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

namespace Increase.Api.Models.Simulations.WireDrawdownRequests;

/// <summary>
/// Simulates a Wire Drawdown Request being refused by the debtor.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WireDrawdownRequestRefuseParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? WireDrawdownRequestID { get; init; }

    /// <summary>
    /// Additional information about the refusal that the simulated refusal will have.
    /// </summary>
    public string? RefusalReasonAdditionalInformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "refusal_reason_additional_information"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("refusal_reason_additional_information", value);
        }
    }

    /// <summary>
    /// The reason code that the simulated refusal will have.
    ///
    /// <para>Defaults to `other`.</para>
    /// </summary>
    public ApiEnum<string, RefusalReasonCode>? RefusalReasonCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, RefusalReasonCode>>(
                "refusal_reason_code"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("refusal_reason_code", value);
        }
    }

    public WireDrawdownRequestRefuseParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireDrawdownRequestRefuseParams(
        WireDrawdownRequestRefuseParams wireDrawdownRequestRefuseParams
    )
        : base(wireDrawdownRequestRefuseParams)
    {
        this.WireDrawdownRequestID = wireDrawdownRequestRefuseParams.WireDrawdownRequestID;

        this._rawBodyData = new(wireDrawdownRequestRefuseParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WireDrawdownRequestRefuseParams(
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
    WireDrawdownRequestRefuseParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string wireDrawdownRequestID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.WireDrawdownRequestID = wireDrawdownRequestID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WireDrawdownRequestRefuseParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string wireDrawdownRequestID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            wireDrawdownRequestID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["WireDrawdownRequestID"] = JsonSerializer.SerializeToElement(
                        this.WireDrawdownRequestID
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

    public virtual bool Equals(WireDrawdownRequestRefuseParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.WireDrawdownRequestID?.Equals(other.WireDrawdownRequestID)
                ?? other.WireDrawdownRequestID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/simulations/wire_drawdown_requests/{0}/refuse",
                    this.WireDrawdownRequestID
                )
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
/// The reason code that the simulated refusal will have.
/// </summary>
[JsonConverter(typeof(RefusalReasonCodeConverter))]
public enum RefusalReasonCode
{
    /// <summary>
    /// The debtor's account number is invalid or missing. Corresponds to the Fedwire
    /// reason code `AC02`.
    /// </summary>
    InvalidDebtorAccountNumber,

    /// <summary>
    /// The debtor account does not allow drawdown requests. Corresponds to the Fedwire
    /// reason code `AG01`.
    /// </summary>
    TransactionForbidden,

    /// <summary>
    /// The debtor account cannot be debited for a generic reason. Corresponds to
    /// the Fedwire reason code `AG07`.
    /// </summary>
    UnsuccessfulDirectDebit,

    /// <summary>
    /// The debtor's identification is inconsistent with the debtor account number.
    /// Corresponds to the Fedwire reason code `BE01`.
    /// </summary>
    InconsistentWithEndCustomer,

    /// <summary>
    /// The reason is provided as narrative information in the additional information
    /// field. Corresponds to the Fedwire reason code `NARR`.
    /// </summary>
    Narrative,

    /// <summary>
    /// Some other error or issue has occurred.
    /// </summary>
    Other,
}

sealed class RefusalReasonCodeConverter : JsonConverter<RefusalReasonCode>
{
    public override RefusalReasonCode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_debtor_account_number" => RefusalReasonCode.InvalidDebtorAccountNumber,
            "transaction_forbidden" => RefusalReasonCode.TransactionForbidden,
            "unsuccessful_direct_debit" => RefusalReasonCode.UnsuccessfulDirectDebit,
            "inconsistent_with_end_customer" => RefusalReasonCode.InconsistentWithEndCustomer,
            "narrative" => RefusalReasonCode.Narrative,
            "other" => RefusalReasonCode.Other,
            _ => (RefusalReasonCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RefusalReasonCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RefusalReasonCode.InvalidDebtorAccountNumber => "invalid_debtor_account_number",
                RefusalReasonCode.TransactionForbidden => "transaction_forbidden",
                RefusalReasonCode.UnsuccessfulDirectDebit => "unsuccessful_direct_debit",
                RefusalReasonCode.InconsistentWithEndCustomer => "inconsistent_with_end_customer",
                RefusalReasonCode.Narrative => "narrative",
                RefusalReasonCode.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
