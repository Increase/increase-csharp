using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.Simulations.InboundCheckDeposits;

/// <summary>
/// Simulates the acceptance of an [Inbound Check Deposit](#inbound-check-deposits),
/// creating a Transaction as a result. The Inbound Check Deposit must first have
/// a `status` of `pending`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InboundCheckDepositAcceptParams : ParamsBase
{
    public string? InboundCheckDepositID { get; init; }

    public InboundCheckDepositAcceptParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundCheckDepositAcceptParams(
        InboundCheckDepositAcceptParams inboundCheckDepositAcceptParams
    )
        : base(inboundCheckDepositAcceptParams)
    {
        this.InboundCheckDepositID = inboundCheckDepositAcceptParams.InboundCheckDepositID;
    }
#pragma warning restore CS8618

    public InboundCheckDepositAcceptParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundCheckDepositAcceptParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string inboundCheckDepositID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.InboundCheckDepositID = inboundCheckDepositID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InboundCheckDepositAcceptParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string inboundCheckDepositID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            inboundCheckDepositID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["InboundCheckDepositID"] = JsonSerializer.SerializeToElement(
                        this.InboundCheckDepositID
                    ),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(InboundCheckDepositAcceptParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.InboundCheckDepositID?.Equals(other.InboundCheckDepositID)
                ?? other.InboundCheckDepositID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/simulations/inbound_check_deposits/{0}/accept",
                    this.InboundCheckDepositID
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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
