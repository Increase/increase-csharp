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

namespace Increase.Api.Models.InboundCheckDeposits;

/// <summary>
/// Return an Inbound Check Deposit
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InboundCheckDepositReturnParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? InboundCheckDepositID { get; init; }

    /// <summary>
    /// The reason to return the Inbound Check Deposit.
    /// </summary>
    public required ApiEnum<string, Reason> Reason
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Reason>>("reason");
        }
        init { this._rawBodyData.Set("reason", value); }
    }

    public InboundCheckDepositReturnParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundCheckDepositReturnParams(
        InboundCheckDepositReturnParams inboundCheckDepositReturnParams
    )
        : base(inboundCheckDepositReturnParams)
    {
        this.InboundCheckDepositID = inboundCheckDepositReturnParams.InboundCheckDepositID;

        this._rawBodyData = new(inboundCheckDepositReturnParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InboundCheckDepositReturnParams(
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
    InboundCheckDepositReturnParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string inboundCheckDepositID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.InboundCheckDepositID = inboundCheckDepositID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InboundCheckDepositReturnParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string inboundCheckDepositID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(InboundCheckDepositReturnParams? other)
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
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/inbound_check_deposits/{0}/return", this.InboundCheckDepositID)
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
/// The reason to return the Inbound Check Deposit.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    /// <summary>
    /// The check was altered or fictitious.
    /// </summary>
    AlteredOrFictitious,

    /// <summary>
    /// The check was not authorized.
    /// </summary>
    NotAuthorized,

    /// <summary>
    /// The check was a duplicate presentment.
    /// </summary>
    DuplicatePresentment,

    /// <summary>
    /// The check was not endorsed.
    /// </summary>
    EndorsementMissing,

    /// <summary>
    /// The check was not endorsed by the payee.
    /// </summary>
    EndorsementIrregular,

    /// <summary>
    /// The maker of the check requested its return.
    /// </summary>
    ReferToMaker,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "altered_or_fictitious" => Reason.AlteredOrFictitious,
            "not_authorized" => Reason.NotAuthorized,
            "duplicate_presentment" => Reason.DuplicatePresentment,
            "endorsement_missing" => Reason.EndorsementMissing,
            "endorsement_irregular" => Reason.EndorsementIrregular,
            "refer_to_maker" => Reason.ReferToMaker,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.AlteredOrFictitious => "altered_or_fictitious",
                Reason.NotAuthorized => "not_authorized",
                Reason.DuplicatePresentment => "duplicate_presentment",
                Reason.EndorsementMissing => "endorsement_missing",
                Reason.EndorsementIrregular => "endorsement_irregular",
                Reason.ReferToMaker => "refer_to_maker",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
