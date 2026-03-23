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

namespace Increase.Api.Models.Simulations.InboundCheckDeposits;

/// <summary>
/// Simulates an Inbound Check Deposit against your account. This imitates someone
/// depositing a check at their bank that was issued from your account. It may or
/// may not be associated with a Check Transfer. Increase will evaluate the Inbound
/// Check Deposit as we would in production and either create a Transaction or a Declined
/// Transaction as a result. You can inspect the resulting Inbound Check Deposit
/// object to see the result.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InboundCheckDepositCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The identifier of the Account Number the Inbound Check Deposit will be against.
    /// </summary>
    public required string AccountNumberID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("account_number_id");
        }
        init { this._rawBodyData.Set("account_number_id", value); }
    }

    /// <summary>
    /// The check amount in cents.
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>("amount");
        }
        init { this._rawBodyData.Set("amount", value); }
    }

    /// <summary>
    /// The check number on the check to be deposited.
    /// </summary>
    public required string CheckNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("check_number");
        }
        init { this._rawBodyData.Set("check_number", value); }
    }

    /// <summary>
    /// Simulate the outcome of [payee name checking](https://increase.com/documentation/positive-pay#payee-name-mismatches).
    /// Defaults to `not_evaluated`.
    /// </summary>
    public ApiEnum<string, PayeeNameAnalysis>? PayeeNameAnalysis
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, PayeeNameAnalysis>>(
                "payee_name_analysis"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("payee_name_analysis", value);
        }
    }

    public InboundCheckDepositCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundCheckDepositCreateParams(
        InboundCheckDepositCreateParams inboundCheckDepositCreateParams
    )
        : base(inboundCheckDepositCreateParams)
    {
        this._rawBodyData = new(inboundCheckDepositCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InboundCheckDepositCreateParams(
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
    InboundCheckDepositCreateParams(
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
    public static InboundCheckDepositCreateParams FromRawUnchecked(
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

    public virtual bool Equals(InboundCheckDepositCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/simulations/inbound_check_deposits"
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
/// Simulate the outcome of [payee name checking](https://increase.com/documentation/positive-pay#payee-name-mismatches).
/// Defaults to `not_evaluated`.
/// </summary>
[JsonConverter(typeof(PayeeNameAnalysisConverter))]
public enum PayeeNameAnalysis
{
    /// <summary>
    /// The details on the check match the recipient name of the check transfer.
    /// </summary>
    NameMatches,

    /// <summary>
    /// The details on the check do not match the recipient name of the check transfer.
    /// </summary>
    DoesNotMatch,

    /// <summary>
    /// The payee name analysis was not evaluated.
    /// </summary>
    NotEvaluated,
}

sealed class PayeeNameAnalysisConverter : JsonConverter<PayeeNameAnalysis>
{
    public override PayeeNameAnalysis Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "name_matches" => PayeeNameAnalysis.NameMatches,
            "does_not_match" => PayeeNameAnalysis.DoesNotMatch,
            "not_evaluated" => PayeeNameAnalysis.NotEvaluated,
            _ => (PayeeNameAnalysis)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayeeNameAnalysis value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayeeNameAnalysis.NameMatches => "name_matches",
                PayeeNameAnalysis.DoesNotMatch => "does_not_match",
                PayeeNameAnalysis.NotEvaluated => "not_evaluated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
