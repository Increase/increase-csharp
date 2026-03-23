using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.Simulations.InboundWireDrawdownRequests;

/// <summary>
/// Simulates receiving an [Inbound Wire Drawdown Request](#inbound-wire-drawdown-requests).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InboundWireDrawdownRequestCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The amount being requested in cents.
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
    /// The creditor's account number.
    /// </summary>
    public required string CreditorAccountNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("creditor_account_number");
        }
        init { this._rawBodyData.Set("creditor_account_number", value); }
    }

    /// <summary>
    /// The creditor's routing number.
    /// </summary>
    public required string CreditorRoutingNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("creditor_routing_number");
        }
        init { this._rawBodyData.Set("creditor_routing_number", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the amount
    /// being requested. Will always be "USD".
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("currency");
        }
        init { this._rawBodyData.Set("currency", value); }
    }

    /// <summary>
    /// The Account Number to which the recipient of this request is being requested
    /// to send funds from.
    /// </summary>
    public required string RecipientAccountNumberID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("recipient_account_number_id");
        }
        init { this._rawBodyData.Set("recipient_account_number_id", value); }
    }

    /// <summary>
    /// A free-form address field set by the sender representing the first line of
    /// the creditor's address.
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
    /// A free-form address field set by the sender representing the second line
    /// of the creditor's address.
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
    /// A free-form address field set by the sender representing the third line of
    /// the creditor's address.
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
    /// A free-form name field set by the sender representing the creditor's name.
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
    /// The debtor's account number.
    /// </summary>
    public string? DebtorAccountNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("debtor_account_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("debtor_account_number", value);
        }
    }

    /// <summary>
    /// A free-form address field set by the sender representing the first line of
    /// the debtor's address.
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
    /// A free-form address field set by the sender representing the second line
    /// of the debtor's address.
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
    /// A free-form address field set by the sender.
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
    /// A free-form name field set by the sender representing the debtor's name.
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
    /// The debtor's routing number.
    /// </summary>
    public string? DebtorRoutingNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("debtor_routing_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("debtor_routing_number", value);
        }
    }

    /// <summary>
    /// A free-form reference string set by the sender, to help identify the transfer.
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
    /// The sending bank's identifier for the wire transfer.
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
    /// The Unique End-to-end Transaction Reference ([UETR](https://www.swift.com/payments/what-unique-end-end-transaction-reference-uetr))
    /// of the transfer.
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
    /// A free-form message set by the sender.
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

    public InboundWireDrawdownRequestCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundWireDrawdownRequestCreateParams(
        InboundWireDrawdownRequestCreateParams inboundWireDrawdownRequestCreateParams
    )
        : base(inboundWireDrawdownRequestCreateParams)
    {
        this._rawBodyData = new(inboundWireDrawdownRequestCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InboundWireDrawdownRequestCreateParams(
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
    InboundWireDrawdownRequestCreateParams(
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
    public static InboundWireDrawdownRequestCreateParams FromRawUnchecked(
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

    public virtual bool Equals(InboundWireDrawdownRequestCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/simulations/inbound_wire_drawdown_requests"
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
