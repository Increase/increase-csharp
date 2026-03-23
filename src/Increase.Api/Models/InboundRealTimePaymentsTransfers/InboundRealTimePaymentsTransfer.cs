using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.InboundRealTimePaymentsTransfers;

/// <summary>
/// An Inbound Real-Time Payments Transfer is a Real-Time Payments transfer initiated
/// outside of Increase to your account.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InboundRealTimePaymentsTransfer,
        InboundRealTimePaymentsTransferFromRaw
    >)
)]
public sealed record class InboundRealTimePaymentsTransfer : JsonModel
{
    /// <summary>
    /// The inbound Real-Time Payments transfer's identifier.
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
    /// The Account to which the transfer was sent.
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
    /// If your transfer is confirmed, this will contain details of the confirmation.
    /// </summary>
    public required Confirmation? Confirmation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Confirmation>("confirmation");
        }
        init { this._rawData.Set("confirmation", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the transfer was created.
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
    /// The name the sender of the transfer specified as the recipient of the transfer.
    /// </summary>
    public required string CreditorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creditor_name");
        }
        init { this._rawData.Set("creditor_name", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code of the transfer's
    /// currency. This will always be "USD" for a Real-Time Payments transfer.
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The account number of the account that sent the transfer.
    /// </summary>
    public required string DebtorAccountNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("debtor_account_number");
        }
        init { this._rawData.Set("debtor_account_number", value); }
    }

    /// <summary>
    /// The name provided by the sender of the transfer.
    /// </summary>
    public required string DebtorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("debtor_name");
        }
        init { this._rawData.Set("debtor_name", value); }
    }

    /// <summary>
    /// The routing number of the account that sent the transfer.
    /// </summary>
    public required string DebtorRoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("debtor_routing_number");
        }
        init { this._rawData.Set("debtor_routing_number", value); }
    }

    /// <summary>
    /// If your transfer is declined, this will contain details of the decline.
    /// </summary>
    public required Decline? Decline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Decline>("decline");
        }
        init { this._rawData.Set("decline", value); }
    }

    /// <summary>
    /// The lifecycle status of the transfer.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The Real-Time Payments network identification of the transfer.
    /// </summary>
    public required string TransactionIdentification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transaction_identification");
        }
        init { this._rawData.Set("transaction_identification", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `inbound_real_time_payments_transfer`.
    /// </summary>
    public required ApiEnum<
        string,
        global::Increase.Api.Models.InboundRealTimePaymentsTransfers.Type
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.InboundRealTimePaymentsTransfers.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Additional information included with the transfer.
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
        _ = this.AccountID;
        _ = this.AccountNumberID;
        _ = this.Amount;
        this.Confirmation?.Validate();
        _ = this.CreatedAt;
        _ = this.CreditorName;
        this.Currency.Validate();
        _ = this.DebtorAccountNumber;
        _ = this.DebtorName;
        _ = this.DebtorRoutingNumber;
        this.Decline?.Validate();
        this.Status.Validate();
        _ = this.TransactionIdentification;
        this.Type.Validate();
        _ = this.UnstructuredRemittanceInformation;
    }

    public InboundRealTimePaymentsTransfer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundRealTimePaymentsTransfer(
        InboundRealTimePaymentsTransfer inboundRealTimePaymentsTransfer
    )
        : base(inboundRealTimePaymentsTransfer) { }
#pragma warning restore CS8618

    public InboundRealTimePaymentsTransfer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundRealTimePaymentsTransfer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundRealTimePaymentsTransferFromRaw.FromRawUnchecked"/>
    public static InboundRealTimePaymentsTransfer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundRealTimePaymentsTransferFromRaw : IFromRawJson<InboundRealTimePaymentsTransfer>
{
    /// <inheritdoc/>
    public InboundRealTimePaymentsTransfer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundRealTimePaymentsTransfer.FromRawUnchecked(rawData);
}

/// <summary>
/// If your transfer is confirmed, this will contain details of the confirmation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Confirmation, ConfirmationFromRaw>))]
public sealed record class Confirmation : JsonModel
{
    /// <summary>
    /// The time at which the transfer was confirmed.
    /// </summary>
    public required System::DateTimeOffset ConfirmedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("confirmed_at");
        }
        init { this._rawData.Set("confirmed_at", value); }
    }

    /// <summary>
    /// The id of the transaction for the confirmed transfer.
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
        _ = this.ConfirmedAt;
        _ = this.TransactionID;
    }

    public Confirmation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Confirmation(Confirmation confirmation)
        : base(confirmation) { }
#pragma warning restore CS8618

    public Confirmation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Confirmation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConfirmationFromRaw.FromRawUnchecked"/>
    public static Confirmation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConfirmationFromRaw : IFromRawJson<Confirmation>
{
    /// <inheritdoc/>
    public Confirmation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Confirmation.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code of the transfer's
/// currency. This will always be "USD" for a Real-Time Payments transfer.
/// </summary>
[JsonConverter(typeof(CurrencyConverter))]
public enum Currency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CurrencyConverter : JsonConverter<Currency>
{
    public override Currency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => Currency.Usd,
            _ => (Currency)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Currency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If your transfer is declined, this will contain details of the decline.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Decline, DeclineFromRaw>))]
public sealed record class Decline : JsonModel
{
    /// <summary>
    /// The time at which the transfer was declined.
    /// </summary>
    public required System::DateTimeOffset DeclinedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("declined_at");
        }
        init { this._rawData.Set("declined_at", value); }
    }

    /// <summary>
    /// The id of the transaction for the declined transfer.
    /// </summary>
    public required string DeclinedTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("declined_transaction_id");
        }
        init { this._rawData.Set("declined_transaction_id", value); }
    }

    /// <summary>
    /// The reason for the transfer decline.
    /// </summary>
    public required ApiEnum<string, Reason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Reason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DeclinedAt;
        _ = this.DeclinedTransactionID;
        this.Reason.Validate();
    }

    public Decline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Decline(Decline decline)
        : base(decline) { }
#pragma warning restore CS8618

    public Decline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Decline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeclineFromRaw.FromRawUnchecked"/>
    public static Decline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeclineFromRaw : IFromRawJson<Decline>
{
    /// <inheritdoc/>
    public Decline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Decline.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason for the transfer decline.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    /// <summary>
    /// The account number is canceled.
    /// </summary>
    AccountNumberCanceled,

    /// <summary>
    /// The account number is disabled.
    /// </summary>
    AccountNumberDisabled,

    /// <summary>
    /// Your account is restricted.
    /// </summary>
    AccountRestricted,

    /// <summary>
    /// Your account is inactive.
    /// </summary>
    GroupLocked,

    /// <summary>
    /// The account's entity is not active.
    /// </summary>
    EntityNotActive,

    /// <summary>
    /// Your account is not enabled to receive Real-Time Payments transfers.
    /// </summary>
    RealTimePaymentsNotEnabled,
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
            "account_number_canceled" => Reason.AccountNumberCanceled,
            "account_number_disabled" => Reason.AccountNumberDisabled,
            "account_restricted" => Reason.AccountRestricted,
            "group_locked" => Reason.GroupLocked,
            "entity_not_active" => Reason.EntityNotActive,
            "real_time_payments_not_enabled" => Reason.RealTimePaymentsNotEnabled,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.AccountNumberCanceled => "account_number_canceled",
                Reason.AccountNumberDisabled => "account_number_disabled",
                Reason.AccountRestricted => "account_restricted",
                Reason.GroupLocked => "group_locked",
                Reason.EntityNotActive => "entity_not_active",
                Reason.RealTimePaymentsNotEnabled => "real_time_payments_not_enabled",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The lifecycle status of the transfer.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// The transfer is pending confirmation.
    /// </summary>
    PendingConfirming,

    /// <summary>
    /// The transfer was not responded to in time.
    /// </summary>
    TimedOut,

    /// <summary>
    /// The transfer has been received successfully and is confirmed.
    /// </summary>
    Confirmed,

    /// <summary>
    /// The transfer has been declined.
    /// </summary>
    Declined,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_confirming" => Status.PendingConfirming,
            "timed_out" => Status.TimedOut,
            "confirmed" => Status.Confirmed,
            "declined" => Status.Declined,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.PendingConfirming => "pending_confirming",
                Status.TimedOut => "timed_out",
                Status.Confirmed => "confirmed",
                Status.Declined => "declined",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `inbound_real_time_payments_transfer`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    InboundRealTimePaymentsTransfer,
}

sealed class TypeConverter
    : JsonConverter<global::Increase.Api.Models.InboundRealTimePaymentsTransfers.Type>
{
    public override global::Increase.Api.Models.InboundRealTimePaymentsTransfers.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_real_time_payments_transfer" => global::Increase
                .Api
                .Models
                .InboundRealTimePaymentsTransfers
                .Type
                .InboundRealTimePaymentsTransfer,
            _ => (global::Increase.Api.Models.InboundRealTimePaymentsTransfers.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.InboundRealTimePaymentsTransfers.Type value,
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
                    .InboundRealTimePaymentsTransfers
                    .Type
                    .InboundRealTimePaymentsTransfer => "inbound_real_time_payments_transfer",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
