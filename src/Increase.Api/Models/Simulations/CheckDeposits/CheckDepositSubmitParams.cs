using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.Simulations.CheckDeposits;

/// <summary>
/// Simulates the submission of a [Check Deposit](#check-deposits) to the Federal
/// Reserve. This Check Deposit must first have a `status` of `pending`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CheckDepositSubmitParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CheckDepositID { get; init; }

    /// <summary>
    /// If set, the simulation will use these values for the check's scanned MICR data.
    /// </summary>
    public Scan? Scan
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Scan>("scan");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("scan", value);
        }
    }

    public CheckDepositSubmitParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckDepositSubmitParams(CheckDepositSubmitParams checkDepositSubmitParams)
        : base(checkDepositSubmitParams)
    {
        this.CheckDepositID = checkDepositSubmitParams.CheckDepositID;

        this._rawBodyData = new(checkDepositSubmitParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CheckDepositSubmitParams(
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
    CheckDepositSubmitParams(
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
    public static CheckDepositSubmitParams FromRawUnchecked(
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

    public virtual bool Equals(CheckDepositSubmitParams? other)
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
                + string.Format("/simulations/check_deposits/{0}/submit", this.CheckDepositID)
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
/// If set, the simulation will use these values for the check's scanned MICR data.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Scan, ScanFromRaw>))]
public sealed record class Scan : JsonModel
{
    /// <summary>
    /// The account number to be returned in the check deposit's scan data.
    /// </summary>
    public required string AccountNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_number");
        }
        init { this._rawData.Set("account_number", value); }
    }

    /// <summary>
    /// The routing number to be returned in the check deposit's scan data.
    /// </summary>
    public required string RoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("routing_number");
        }
        init { this._rawData.Set("routing_number", value); }
    }

    /// <summary>
    /// The auxiliary on-us data to be returned in the check deposit's scan data.
    /// </summary>
    public string? AuxiliaryOnUs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("auxiliary_on_us");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("auxiliary_on_us", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountNumber;
        _ = this.RoutingNumber;
        _ = this.AuxiliaryOnUs;
    }

    public Scan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Scan(Scan scan)
        : base(scan) { }
#pragma warning restore CS8618

    public Scan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Scan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScanFromRaw.FromRawUnchecked"/>
    public static Scan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScanFromRaw : IFromRawJson<Scan>
{
    /// <inheritdoc/>
    public Scan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Scan.FromRawUnchecked(rawData);
}
