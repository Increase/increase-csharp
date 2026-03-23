using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.InboundWireTransfers;

/// <summary>
/// An Inbound Wire Transfer is a wire transfer initiated outside of Increase to your account.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InboundWireTransfer, InboundWireTransferFromRaw>))]
public sealed record class InboundWireTransfer : JsonModel
{
    /// <summary>
    /// The inbound wire transfer's identifier.
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
    /// If the transfer is accepted, this will contain details of the acceptance.
    /// </summary>
    public required Acceptance? Acceptance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Acceptance>("acceptance");
        }
        init { this._rawData.Set("acceptance", value); }
    }

    /// <summary>
    /// The Account to which the transfer belongs.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// The identifier of the Account Number to which this transfer was sent.
    /// </summary>
    public required string AccountNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_number_id");
        }
        init { this._rawData.Set("account_number_id", value); }
    }

    /// <summary>
    /// The amount in USD cents.
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
    /// the inbound wire transfer was created.
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
    /// An Increase-constructed description of the transfer.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// A free-form reference string set by the sender, to help identify the transfer.
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
    /// The American Banking Association (ABA) routing number of the bank that sent
    /// the wire.
    /// </summary>
    public required string? InstructingAgentRoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instructing_agent_routing_number");
        }
        init { this._rawData.Set("instructing_agent_routing_number", value); }
    }

    /// <summary>
    /// The sending bank's identifier for the wire transfer.
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
    /// If the transfer is reversed, this will contain details of the reversal.
    /// </summary>
    public required Reversal? Reversal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Reversal>("reversal");
        }
        init { this._rawData.Set("reversal", value); }
    }

    /// <summary>
    /// The status of the transfer.
    /// </summary>
    public required ApiEnum<string, InboundWireTransferStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InboundWireTransferStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `inbound_wire_transfer`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.InboundWireTransfers.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.InboundWireTransfers.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The Unique End-to-end Transaction Reference ([UETR](https://www.swift.com/payments/what-unique-end-end-transaction-reference-uetr))
    /// of the transfer.
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

    /// <summary>
    /// The wire drawdown request the inbound wire transfer is fulfilling.
    /// </summary>
    public required string? WireDrawdownRequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("wire_drawdown_request_id");
        }
        init { this._rawData.Set("wire_drawdown_request_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Acceptance?.Validate();
        _ = this.AccountID;
        _ = this.AccountNumberID;
        _ = this.Amount;
        _ = this.CreatedAt;
        _ = this.CreditorAddressLine1;
        _ = this.CreditorAddressLine2;
        _ = this.CreditorAddressLine3;
        _ = this.CreditorName;
        _ = this.DebtorAddressLine1;
        _ = this.DebtorAddressLine2;
        _ = this.DebtorAddressLine3;
        _ = this.DebtorName;
        _ = this.Description;
        _ = this.EndToEndIdentification;
        _ = this.InputMessageAccountabilityData;
        _ = this.InstructingAgentRoutingNumber;
        _ = this.InstructionIdentification;
        this.Reversal?.Validate();
        this.Status.Validate();
        this.Type.Validate();
        _ = this.UniqueEndToEndTransactionReference;
        _ = this.UnstructuredRemittanceInformation;
        _ = this.WireDrawdownRequestID;
    }

    public InboundWireTransfer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundWireTransfer(InboundWireTransfer inboundWireTransfer)
        : base(inboundWireTransfer) { }
#pragma warning restore CS8618

    public InboundWireTransfer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundWireTransfer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundWireTransferFromRaw.FromRawUnchecked"/>
    public static InboundWireTransfer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundWireTransferFromRaw : IFromRawJson<InboundWireTransfer>
{
    /// <inheritdoc/>
    public InboundWireTransfer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InboundWireTransfer.FromRawUnchecked(rawData);
}

/// <summary>
/// If the transfer is accepted, this will contain details of the acceptance.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Acceptance, AcceptanceFromRaw>))]
public sealed record class Acceptance : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the transfer was accepted.
    /// </summary>
    public required System::DateTimeOffset AcceptedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("accepted_at");
        }
        init { this._rawData.Set("accepted_at", value); }
    }

    /// <summary>
    /// The identifier of the transaction for the accepted transfer.
    /// </summary>
    public required string TransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transaction_id");
        }
        init { this._rawData.Set("transaction_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcceptedAt;
        _ = this.TransactionID;
    }

    public Acceptance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Acceptance(Acceptance acceptance)
        : base(acceptance) { }
#pragma warning restore CS8618

    public Acceptance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Acceptance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AcceptanceFromRaw.FromRawUnchecked"/>
    public static Acceptance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AcceptanceFromRaw : IFromRawJson<Acceptance>
{
    /// <inheritdoc/>
    public Acceptance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Acceptance.FromRawUnchecked(rawData);
}

/// <summary>
/// If the transfer is reversed, this will contain details of the reversal.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Reversal, ReversalFromRaw>))]
public sealed record class Reversal : JsonModel
{
    /// <summary>
    /// The reason for the reversal.
    /// </summary>
    public required ApiEnum<string, ReversalReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ReversalReason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the transfer was reversed.
    /// </summary>
    public required System::DateTimeOffset ReversedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("reversed_at");
        }
        init { this._rawData.Set("reversed_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Reason.Validate();
        _ = this.ReversedAt;
    }

    public Reversal() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Reversal(Reversal reversal)
        : base(reversal) { }
#pragma warning restore CS8618

    public Reversal(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Reversal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReversalFromRaw.FromRawUnchecked"/>
    public static Reversal FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReversalFromRaw : IFromRawJson<Reversal>
{
    /// <inheritdoc/>
    public Reversal FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Reversal.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason for the reversal.
/// </summary>
[JsonConverter(typeof(ReversalReasonConverter))]
public enum ReversalReason
{
    /// <summary>
    /// The inbound wire transfer was a duplicate.
    /// </summary>
    Duplicate,

    /// <summary>
    /// The recipient of the wire transfer requested the funds be returned to the sender.
    /// </summary>
    CreditorRequest,

    /// <summary>
    /// The account cannot currently receive inbound wires.
    /// </summary>
    TransactionForbidden,
}

sealed class ReversalReasonConverter : JsonConverter<ReversalReason>
{
    public override ReversalReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "duplicate" => ReversalReason.Duplicate,
            "creditor_request" => ReversalReason.CreditorRequest,
            "transaction_forbidden" => ReversalReason.TransactionForbidden,
            _ => (ReversalReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReversalReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReversalReason.Duplicate => "duplicate",
                ReversalReason.CreditorRequest => "creditor_request",
                ReversalReason.TransactionForbidden => "transaction_forbidden",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the transfer.
/// </summary>
[JsonConverter(typeof(InboundWireTransferStatusConverter))]
public enum InboundWireTransferStatus
{
    /// <summary>
    /// The Inbound Wire Transfer is awaiting action, will transition automatically
    /// if no action is taken.
    /// </summary>
    Pending,

    /// <summary>
    /// The Inbound Wire Transfer is accepted.
    /// </summary>
    Accepted,

    /// <summary>
    /// The Inbound Wire Transfer was declined.
    /// </summary>
    Declined,

    /// <summary>
    /// The Inbound Wire Transfer was reversed.
    /// </summary>
    Reversed,
}

sealed class InboundWireTransferStatusConverter : JsonConverter<InboundWireTransferStatus>
{
    public override InboundWireTransferStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => InboundWireTransferStatus.Pending,
            "accepted" => InboundWireTransferStatus.Accepted,
            "declined" => InboundWireTransferStatus.Declined,
            "reversed" => InboundWireTransferStatus.Reversed,
            _ => (InboundWireTransferStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundWireTransferStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InboundWireTransferStatus.Pending => "pending",
                InboundWireTransferStatus.Accepted => "accepted",
                InboundWireTransferStatus.Declined => "declined",
                InboundWireTransferStatus.Reversed => "reversed",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `inbound_wire_transfer`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    InboundWireTransfer,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.InboundWireTransfers.Type>
{
    public override global::Increase.Api.Models.InboundWireTransfers.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_wire_transfer" => global::Increase
                .Api
                .Models
                .InboundWireTransfers
                .Type
                .InboundWireTransfer,
            _ => (global::Increase.Api.Models.InboundWireTransfers.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.InboundWireTransfers.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.InboundWireTransfers.Type.InboundWireTransfer =>
                    "inbound_wire_transfer",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
