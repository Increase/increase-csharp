using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.InboundWireDrawdownRequests;

/// <summary>
/// Inbound wire drawdown requests are requests from someone else to send them a wire.
/// For more information, see our [Wire Drawdown Requests documentation](/documentation/wire-drawdown-requests).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<InboundWireDrawdownRequest, InboundWireDrawdownRequestFromRaw>)
)]
public sealed record class InboundWireDrawdownRequest : JsonModel
{
    /// <summary>
    /// The Wire drawdown request identifier.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The amount being requested in cents.
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the inbound wire drawdown request was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The creditor's account number.
    /// </summary>
    public required string CreditorAccountNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creditor_account_number");
        }
        init { this._rawData.Set("creditor_account_number", value); }
    }

    /// <summary>
    /// A free-form address field set by the sender.
    /// </summary>
    public required string? CreditorAddressLine1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("creditor_address_line1");
        }
        init { this._rawData.Set("creditor_address_line1", value); }
    }

    /// <summary>
    /// A free-form address field set by the sender.
    /// </summary>
    public required string? CreditorAddressLine2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("creditor_address_line2");
        }
        init { this._rawData.Set("creditor_address_line2", value); }
    }

    /// <summary>
    /// A free-form address field set by the sender.
    /// </summary>
    public required string? CreditorAddressLine3
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("creditor_address_line3");
        }
        init { this._rawData.Set("creditor_address_line3", value); }
    }

    /// <summary>
    /// A name set by the sender.
    /// </summary>
    public required string? CreditorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("creditor_name");
        }
        init { this._rawData.Set("creditor_name", value); }
    }

    /// <summary>
    /// The creditor's routing number.
    /// </summary>
    public required string CreditorRoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creditor_routing_number");
        }
        init { this._rawData.Set("creditor_routing_number", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the amount
    /// being requested. Will always be "USD".
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// A free-form address field set by the sender.
    /// </summary>
    public required string? DebtorAddressLine1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("debtor_address_line1");
        }
        init { this._rawData.Set("debtor_address_line1", value); }
    }

    /// <summary>
    /// A free-form address field set by the sender.
    /// </summary>
    public required string? DebtorAddressLine2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("debtor_address_line2");
        }
        init { this._rawData.Set("debtor_address_line2", value); }
    }

    /// <summary>
    /// A free-form address field set by the sender.
    /// </summary>
    public required string? DebtorAddressLine3
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("debtor_address_line3");
        }
        init { this._rawData.Set("debtor_address_line3", value); }
    }

    /// <summary>
    /// A name set by the sender.
    /// </summary>
    public required string? DebtorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("debtor_name");
        }
        init { this._rawData.Set("debtor_name", value); }
    }

    /// <summary>
    /// A free-form reference string set by the sender, to help identify the drawdown request.
    /// </summary>
    public required string? EndToEndIdentification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("end_to_end_identification");
        }
        init { this._rawData.Set("end_to_end_identification", value); }
    }

    /// <summary>
    /// A unique identifier available to the originating and receiving banks, commonly
    /// abbreviated as IMAD. It is created when the wire is submitted to the Fedwire
    /// service and is helpful when debugging wires with the originating bank.
    /// </summary>
    public required string? InputMessageAccountabilityData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("input_message_accountability_data");
        }
        init { this._rawData.Set("input_message_accountability_data", value); }
    }

    /// <summary>
    /// The sending bank's identifier for the drawdown request.
    /// </summary>
    public required string? InstructionIdentification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instruction_identification");
        }
        init { this._rawData.Set("instruction_identification", value); }
    }

    /// <summary>
    /// The Account Number from which the recipient of this request is being requested
    /// to send funds.
    /// </summary>
    public required string RecipientAccountNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("recipient_account_number_id");
        }
        init { this._rawData.Set("recipient_account_number_id", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `inbound_wire_drawdown_request`.
    /// </summary>
    public required ApiEnum<
        string,
        global::Increase.Api.Models.InboundWireDrawdownRequests.Type
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.InboundWireDrawdownRequests.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The Unique End-to-end Transaction Reference ([UETR](https://www.swift.com/payments/what-unique-end-end-transaction-reference-uetr))
    /// of the drawdown request.
    /// </summary>
    public required string? UniqueEndToEndTransactionReference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "unique_end_to_end_transaction_reference"
            );
        }
        init { this._rawData.Set("unique_end_to_end_transaction_reference", value); }
    }

    /// <summary>
    /// A free-form message set by the sender.
    /// </summary>
    public required string? UnstructuredRemittanceInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("unstructured_remittance_information");
        }
        init { this._rawData.Set("unstructured_remittance_information", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.CreatedAt;
        _ = this.CreditorAccountNumber;
        _ = this.CreditorAddressLine1;
        _ = this.CreditorAddressLine2;
        _ = this.CreditorAddressLine3;
        _ = this.CreditorName;
        _ = this.CreditorRoutingNumber;
        _ = this.Currency;
        _ = this.DebtorAddressLine1;
        _ = this.DebtorAddressLine2;
        _ = this.DebtorAddressLine3;
        _ = this.DebtorName;
        _ = this.EndToEndIdentification;
        _ = this.InputMessageAccountabilityData;
        _ = this.InstructionIdentification;
        _ = this.RecipientAccountNumberID;
        this.Type.Validate();
        _ = this.UniqueEndToEndTransactionReference;
        _ = this.UnstructuredRemittanceInformation;
    }

    public InboundWireDrawdownRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundWireDrawdownRequest(InboundWireDrawdownRequest inboundWireDrawdownRequest)
        : base(inboundWireDrawdownRequest) { }
#pragma warning restore CS8618

    public InboundWireDrawdownRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundWireDrawdownRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundWireDrawdownRequestFromRaw.FromRawUnchecked"/>
    public static InboundWireDrawdownRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundWireDrawdownRequestFromRaw : IFromRawJson<InboundWireDrawdownRequest>
{
    /// <inheritdoc/>
    public InboundWireDrawdownRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundWireDrawdownRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `inbound_wire_drawdown_request`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    InboundWireDrawdownRequest,
}

sealed class TypeConverter
    : JsonConverter<global::Increase.Api.Models.InboundWireDrawdownRequests.Type>
{
    public override global::Increase.Api.Models.InboundWireDrawdownRequests.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_wire_drawdown_request" => global::Increase
                .Api
                .Models
                .InboundWireDrawdownRequests
                .Type
                .InboundWireDrawdownRequest,
            _ => (global::Increase.Api.Models.InboundWireDrawdownRequests.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.InboundWireDrawdownRequests.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase
                    .Api
                    .Models
                    .InboundWireDrawdownRequests
                    .Type
                    .InboundWireDrawdownRequest => "inbound_wire_drawdown_request",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
