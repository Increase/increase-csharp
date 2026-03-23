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

namespace Increase.Api.Models.Simulations.AchTransfers;

/// <summary>
/// Simulates the settlement of an [ACH Transfer](#ach-transfers) by the Federal
/// Reserve. This transfer must first have a `status` of `pending_submission` or `submitted`.
/// For convenience, if the transfer is in `status`: `pending_submission`, the simulation
/// will also submit the transfer. Without this simulation the transfer will eventually
/// settle on its own following the same Federal Reserve timeline as in production.
/// Additionally, you can specify the behavior of the inbound funds hold that is created
/// when the ACH Transfer is settled. If no behavior is specified, the inbound funds
/// hold will be released immediately in order for the funds to be available for use.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AchTransferSettleParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? AchTransferID { get; init; }

    /// <summary>
    /// The behavior of the inbound funds hold that is created when the ACH Transfer
    /// is settled. If no behavior is specified, the inbound funds hold will be released
    /// immediately in order for the funds to be available for use.
    /// </summary>
    public ApiEnum<string, InboundFundsHoldBehavior>? InboundFundsHoldBehavior
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, InboundFundsHoldBehavior>>(
                "inbound_funds_hold_behavior"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("inbound_funds_hold_behavior", value);
        }
    }

    public AchTransferSettleParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferSettleParams(AchTransferSettleParams achTransferSettleParams)
        : base(achTransferSettleParams)
    {
        this.AchTransferID = achTransferSettleParams.AchTransferID;

        this._rawBodyData = new(achTransferSettleParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AchTransferSettleParams(
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
    AchTransferSettleParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string achTransferID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.AchTransferID = achTransferID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AchTransferSettleParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string achTransferID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            achTransferID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["AchTransferID"] = JsonSerializer.SerializeToElement(this.AchTransferID),
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

    public virtual bool Equals(AchTransferSettleParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.AchTransferID?.Equals(other.AchTransferID) ?? other.AchTransferID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/simulations/ach_transfers/{0}/settle", this.AchTransferID)
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
/// The behavior of the inbound funds hold that is created when the ACH Transfer
/// is settled. If no behavior is specified, the inbound funds hold will be released
/// immediately in order for the funds to be available for use.
/// </summary>
[JsonConverter(typeof(InboundFundsHoldBehaviorConverter))]
public enum InboundFundsHoldBehavior
{
    /// <summary>
    /// Release the inbound funds hold immediately.
    /// </summary>
    ReleaseImmediately,

    /// <summary>
    /// Release the inbound funds hold on the default schedule.
    /// </summary>
    ReleaseOnDefaultSchedule,
}

sealed class InboundFundsHoldBehaviorConverter : JsonConverter<InboundFundsHoldBehavior>
{
    public override InboundFundsHoldBehavior Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "release_immediately" => InboundFundsHoldBehavior.ReleaseImmediately,
            "release_on_default_schedule" => InboundFundsHoldBehavior.ReleaseOnDefaultSchedule,
            _ => (InboundFundsHoldBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundFundsHoldBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InboundFundsHoldBehavior.ReleaseImmediately => "release_immediately",
                InboundFundsHoldBehavior.ReleaseOnDefaultSchedule => "release_on_default_schedule",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
