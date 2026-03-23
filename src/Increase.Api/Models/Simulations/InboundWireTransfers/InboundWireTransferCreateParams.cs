using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.Simulations.InboundWireTransfers;

/// <summary>
/// Simulates an [Inbound Wire Transfer](#inbound-wire-transfers) to your account.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InboundWireTransferCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The identifier of the Account Number the inbound Wire Transfer is for.
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
    /// The transfer amount in cents. Must be positive.
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
    /// The sending bank will set creditor_address_line1 in production. You can simulate
    /// any value here.
    /// </summary>
    public string? CreditorAddressLine1
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("creditor_address_line1");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("creditor_address_line1", value);
        }
    }

    /// <summary>
    /// The sending bank will set creditor_address_line2 in production. You can simulate
    /// any value here.
    /// </summary>
    public string? CreditorAddressLine2
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("creditor_address_line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("creditor_address_line2", value);
        }
    }

    /// <summary>
    /// The sending bank will set creditor_address_line3 in production. You can simulate
    /// any value here.
    /// </summary>
    public string? CreditorAddressLine3
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("creditor_address_line3");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("creditor_address_line3", value);
        }
    }

    /// <summary>
    /// The sending bank will set creditor_name in production. You can simulate any
    /// value here.
    /// </summary>
    public string? CreditorName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("creditor_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("creditor_name", value);
        }
    }

    /// <summary>
    /// The sending bank will set debtor_address_line1 in production. You can simulate
    /// any value here.
    /// </summary>
    public string? DebtorAddressLine1
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("debtor_address_line1");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("debtor_address_line1", value);
        }
    }

    /// <summary>
    /// The sending bank will set debtor_address_line2 in production. You can simulate
    /// any value here.
    /// </summary>
    public string? DebtorAddressLine2
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("debtor_address_line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("debtor_address_line2", value);
        }
    }

    /// <summary>
    /// The sending bank will set debtor_address_line3 in production. You can simulate
    /// any value here.
    /// </summary>
    public string? DebtorAddressLine3
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("debtor_address_line3");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("debtor_address_line3", value);
        }
    }

    /// <summary>
    /// The sending bank will set debtor_name in production. You can simulate any
    /// value here.
    /// </summary>
    public string? DebtorName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("debtor_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("debtor_name", value);
        }
    }

    /// <summary>
    /// The sending bank will set end_to_end_identification in production. You can
    /// simulate any value here.
    /// </summary>
    public string? EndToEndIdentification
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("end_to_end_identification");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("end_to_end_identification", value);
        }
    }

    /// <summary>
    /// The sending bank will set instructing_agent_routing_number in production.
    /// You can simulate any value here.
    /// </summary>
    public string? InstructingAgentRoutingNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("instructing_agent_routing_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("instructing_agent_routing_number", value);
        }
    }

    /// <summary>
    /// The sending bank will set instruction_identification in production. You can
    /// simulate any value here.
    /// </summary>
    public string? InstructionIdentification
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("instruction_identification");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("instruction_identification", value);
        }
    }

    /// <summary>
    /// The sending bank will set unique_end_to_end_transaction_reference in production.
    /// You can simulate any value here.
    /// </summary>
    public string? UniqueEndToEndTransactionReference
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "unique_end_to_end_transaction_reference"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("unique_end_to_end_transaction_reference", value);
        }
    }

    /// <summary>
    /// The sending bank will set unstructured_remittance_information in production.
    /// You can simulate any value here.
    /// </summary>
    public string? UnstructuredRemittanceInformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "unstructured_remittance_information"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("unstructured_remittance_information", value);
        }
    }

    /// <summary>
    /// The identifier of a Wire Drawdown Request the inbound Wire Transfer is fulfilling.
    /// </summary>
    public string? WireDrawdownRequestID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("wire_drawdown_request_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("wire_drawdown_request_id", value);
        }
    }

    public InboundWireTransferCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundWireTransferCreateParams(
        InboundWireTransferCreateParams inboundWireTransferCreateParams
    )
        : base(inboundWireTransferCreateParams)
    {
        this._rawBodyData = new(inboundWireTransferCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InboundWireTransferCreateParams(
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
    InboundWireTransferCreateParams(
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
    public static InboundWireTransferCreateParams FromRawUnchecked(
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

    public virtual bool Equals(InboundWireTransferCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/simulations/inbound_wire_transfers"
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
