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
/// Simulates receiving a Notification of Change for an [ACH Transfer](#ach-transfers).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AchTransferCreateNotificationOfChangeParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? AchTransferID { get; init; }

    /// <summary>
    /// The corrected account funding type.
    /// </summary>
    public ApiEnum<string, CorrectedAccountFunding>? CorrectedAccountFunding
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, CorrectedAccountFunding>>(
                "corrected_account_funding"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("corrected_account_funding", value);
        }
    }

    /// <summary>
    /// The corrected account number.
    /// </summary>
    public string? CorrectedAccountNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("corrected_account_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("corrected_account_number", value);
        }
    }

    /// <summary>
    /// The corrected individual identifier.
    /// </summary>
    public string? CorrectedIndividualID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("corrected_individual_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("corrected_individual_id", value);
        }
    }

    /// <summary>
    /// The corrected routing number.
    /// </summary>
    public string? CorrectedRoutingNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("corrected_routing_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("corrected_routing_number", value);
        }
    }

    public AchTransferCreateNotificationOfChangeParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferCreateNotificationOfChangeParams(
        AchTransferCreateNotificationOfChangeParams achTransferCreateNotificationOfChangeParams
    )
        : base(achTransferCreateNotificationOfChangeParams)
    {
        this.AchTransferID = achTransferCreateNotificationOfChangeParams.AchTransferID;

        this._rawBodyData = new(achTransferCreateNotificationOfChangeParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AchTransferCreateNotificationOfChangeParams(
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
    AchTransferCreateNotificationOfChangeParams(
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
    public static AchTransferCreateNotificationOfChangeParams FromRawUnchecked(
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

    public virtual bool Equals(AchTransferCreateNotificationOfChangeParams? other)
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
                + string.Format(
                    "/simulations/ach_transfers/{0}/create_notification_of_change",
                    this.AchTransferID
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
/// The corrected account funding type.
/// </summary>
[JsonConverter(typeof(CorrectedAccountFundingConverter))]
public enum CorrectedAccountFunding
{
    /// <summary>
    /// A checking account.
    /// </summary>
    Checking,

    /// <summary>
    /// A savings account.
    /// </summary>
    Savings,

    /// <summary>
    /// A bank's general ledger. Uncommon.
    /// </summary>
    GeneralLedger,
}

sealed class CorrectedAccountFundingConverter : JsonConverter<CorrectedAccountFunding>
{
    public override CorrectedAccountFunding Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "checking" => CorrectedAccountFunding.Checking,
            "savings" => CorrectedAccountFunding.Savings,
            "general_ledger" => CorrectedAccountFunding.GeneralLedger,
            _ => (CorrectedAccountFunding)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CorrectedAccountFunding value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CorrectedAccountFunding.Checking => "checking",
                CorrectedAccountFunding.Savings => "savings",
                CorrectedAccountFunding.GeneralLedger => "general_ledger",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
