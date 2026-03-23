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

namespace Increase.Api.Models.Simulations.CheckDeposits;

/// <summary>
/// Simulates the creation of a [Check Deposit Adjustment](#check-deposit-adjustments)
/// on a [Check Deposit](#check-deposits). This Check Deposit must first have a `status`
/// of `submitted`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CheckDepositAdjustmentParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CheckDepositID { get; init; }

    /// <summary>
    /// The adjustment amount in the minor unit of the Check Deposit's currency (e.g.,
    /// cents). A negative amount means that the funds are being clawed back by the
    /// other bank and is a debit to your account. Defaults to the negative of the
    /// Check Deposit amount.
    /// </summary>
    public long? Amount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("amount", value);
        }
    }

    /// <summary>
    /// The reason for the adjustment. Defaults to `non_conforming_item`, which is
    /// often used for a low quality image that the recipient wasn't able to handle.
    /// </summary>
    public ApiEnum<string, Reason>? Reason
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Reason>>("reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("reason", value);
        }
    }

    public CheckDepositAdjustmentParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckDepositAdjustmentParams(CheckDepositAdjustmentParams checkDepositAdjustmentParams)
        : base(checkDepositAdjustmentParams)
    {
        this.CheckDepositID = checkDepositAdjustmentParams.CheckDepositID;

        this._rawBodyData = new(checkDepositAdjustmentParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CheckDepositAdjustmentParams(
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
    CheckDepositAdjustmentParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string checkDepositID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CheckDepositID = checkDepositID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CheckDepositAdjustmentParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string checkDepositID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            checkDepositID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CheckDepositID"] = JsonSerializer.SerializeToElement(this.CheckDepositID),
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

    public virtual bool Equals(CheckDepositAdjustmentParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CheckDepositID?.Equals(other.CheckDepositID) ?? other.CheckDepositID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/simulations/check_deposits/{0}/adjustment", this.CheckDepositID)
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
/// The reason for the adjustment. Defaults to `non_conforming_item`, which is often
/// used for a low quality image that the recipient wasn't able to handle.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    /// <summary>
    /// The return was initiated too late and the receiving institution has responded
    /// with a Late Return Claim.
    /// </summary>
    LateReturn,

    /// <summary>
    /// The check was deposited to the wrong payee and the depositing institution
    /// has reimbursed the funds with a Wrong Payee Credit.
    /// </summary>
    WrongPayeeCredit,

    /// <summary>
    /// The check was deposited with a different amount than what was written on the check.
    /// </summary>
    AdjustedAmount,

    /// <summary>
    /// The recipient was not able to process the check. This usually happens for
    /// e.g., low quality images.
    /// </summary>
    NonConformingItem,

    /// <summary>
    /// The check has already been deposited elsewhere and so this is a duplicate.
    /// </summary>
    Paid,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "late_return" => Reason.LateReturn,
            "wrong_payee_credit" => Reason.WrongPayeeCredit,
            "adjusted_amount" => Reason.AdjustedAmount,
            "non_conforming_item" => Reason.NonConformingItem,
            "paid" => Reason.Paid,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.LateReturn => "late_return",
                Reason.WrongPayeeCredit => "wrong_payee_credit",
                Reason.AdjustedAmount => "adjusted_amount",
                Reason.NonConformingItem => "non_conforming_item",
                Reason.Paid => "paid",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
