using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.PendingTransactions;

/// <summary>
/// Pending Transactions are potential future additions and removals of money from
/// your bank account. They impact your available balance, but not your current balance.
/// To learn more, see [Transactions and Transfers](/documentation/transactions-transfers).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PendingTransaction, PendingTransactionFromRaw>))]
public sealed record class PendingTransaction : JsonModel
{
    /// <summary>
    /// The Pending Transaction identifier.
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
    /// The identifier for the account this Pending Transaction belongs to.
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
    /// The Pending Transaction amount in the minor unit of its currency. For dollars,
    /// for example, this is cents.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date on which the Pending
    /// Transaction was completed.
    /// </summary>
    public required System::DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("completed_at");
        }
        init { this._rawData.Set("completed_at", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date on which the Pending
    /// Transaction occurred.
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the Pending
    /// Transaction's currency. This will match the currency on the Pending Transaction's Account.
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
    /// For a Pending Transaction related to a transfer, this is the description
    /// you provide. For a Pending Transaction related to a payment, this is the description
    /// the vendor provides.
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
    /// The amount that this Pending Transaction decrements the available balance
    /// of its Account. This is usually the same as `amount`, but will differ if
    /// the amount is positive.
    /// </summary>
    public required long HeldAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("held_amount");
        }
        init { this._rawData.Set("held_amount", value); }
    }

    /// <summary>
    /// The identifier for the route this Pending Transaction came through. Routes
    /// are things like cards and ACH details.
    /// </summary>
    public required string? RouteID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("route_id");
        }
        init { this._rawData.Set("route_id", value); }
    }

    /// <summary>
    /// The type of the route this Pending Transaction came through.
    /// </summary>
    public required ApiEnum<string, RouteType>? RouteType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RouteType>>("route_type");
        }
        init { this._rawData.Set("route_type", value); }
    }

    /// <summary>
    /// This is an object giving more details on the network-level event that caused
    /// the Pending Transaction. For example, for a card transaction this lists the
    /// merchant's industry and location.
    /// </summary>
    public required Source Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Source>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// Whether the Pending Transaction has been confirmed and has an associated Transaction.
    /// </summary>
    public required ApiEnum<string, PendingTransactionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PendingTransactionStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `pending_transaction`.
    /// </summary>
    public required ApiEnum<string, PendingTransactionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PendingTransactionType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.Amount;
        _ = this.CompletedAt;
        _ = this.CreatedAt;
        this.Currency.Validate();
        _ = this.Description;
        _ = this.HeldAmount;
        _ = this.RouteID;
        this.RouteType?.Validate();
        this.Source.Validate();
        this.Status.Validate();
        this.Type.Validate();
    }

    public PendingTransaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PendingTransaction(PendingTransaction pendingTransaction)
        : base(pendingTransaction) { }
#pragma warning restore CS8618

    public PendingTransaction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PendingTransaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PendingTransactionFromRaw.FromRawUnchecked"/>
    public static PendingTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PendingTransactionFromRaw : IFromRawJson<PendingTransaction>
{
    /// <inheritdoc/>
    public PendingTransaction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PendingTransaction.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the Pending Transaction's
/// currency. This will match the currency on the Pending Transaction's Account.
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
/// The type of the route this Pending Transaction came through.
/// </summary>
[JsonConverter(typeof(RouteTypeConverter))]
public enum RouteType
{
    /// <summary>
    /// An Account Number.
    /// </summary>
    AccountNumber,

    /// <summary>
    /// A Card.
    /// </summary>
    Card,

    /// <summary>
    /// A Lockbox.
    /// </summary>
    Lockbox,
}

sealed class RouteTypeConverter : JsonConverter<RouteType>
{
    public override RouteType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_number" => RouteType.AccountNumber,
            "card" => RouteType.Card,
            "lockbox" => RouteType.Lockbox,
            _ => (RouteType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RouteType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RouteType.AccountNumber => "account_number",
                RouteType.Card => "card",
                RouteType.Lockbox => "lockbox",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// This is an object giving more details on the network-level event that caused the
/// Pending Transaction. For example, for a card transaction this lists the merchant's
/// industry and location.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Source, SourceFromRaw>))]
public sealed record class Source : JsonModel
{
    /// <summary>
    /// The type of the resource. We may add additional possible values for this enum
    /// over time; your application should be able to handle such additions gracefully.
    /// </summary>
    public required ApiEnum<string, SourceCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SourceCategory>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// An Account Transfer Instruction object. This field will be present in the
    /// JSON response if and only if `category` is equal to `account_transfer_instruction`.
    /// </summary>
    public AccountTransferInstruction? AccountTransferInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountTransferInstruction>(
                "account_transfer_instruction"
            );
        }
        init { this._rawData.Set("account_transfer_instruction", value); }
    }

    /// <summary>
    /// An ACH Transfer Instruction object. This field will be present in the JSON
    /// response if and only if `category` is equal to `ach_transfer_instruction`.
    /// </summary>
    public AchTransferInstruction? AchTransferInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AchTransferInstruction>(
                "ach_transfer_instruction"
            );
        }
        init { this._rawData.Set("ach_transfer_instruction", value); }
    }

    /// <summary>
    /// A Blockchain Off-Ramp Transfer Instruction object. This field will be present
    /// in the JSON response if and only if `category` is equal to `blockchain_offramp_transfer_instruction`.
    /// </summary>
    public BlockchainOfframpTransferInstruction? BlockchainOfframpTransferInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BlockchainOfframpTransferInstruction>(
                "blockchain_offramp_transfer_instruction"
            );
        }
        init { this._rawData.Set("blockchain_offramp_transfer_instruction", value); }
    }

    /// <summary>
    /// A Blockchain On-Ramp Transfer Instruction object. This field will be present
    /// in the JSON response if and only if `category` is equal to `blockchain_onramp_transfer_instruction`.
    /// </summary>
    public BlockchainOnrampTransferInstruction? BlockchainOnrampTransferInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BlockchainOnrampTransferInstruction>(
                "blockchain_onramp_transfer_instruction"
            );
        }
        init { this._rawData.Set("blockchain_onramp_transfer_instruction", value); }
    }

    /// <summary>
    /// A Card Authorization object. This field will be present in the JSON response
    /// if and only if `category` is equal to `card_authorization`. Card Authorizations
    /// are temporary holds placed on a customer's funds with the intent to later
    /// clear a transaction.
    /// </summary>
    public CardAuthorization? CardAuthorization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardAuthorization>("card_authorization");
        }
        init { this._rawData.Set("card_authorization", value); }
    }

    /// <summary>
    /// A Card Push Transfer Instruction object. This field will be present in the
    /// JSON response if and only if `category` is equal to `card_push_transfer_instruction`.
    /// </summary>
    public CardPushTransferInstruction? CardPushTransferInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardPushTransferInstruction>(
                "card_push_transfer_instruction"
            );
        }
        init { this._rawData.Set("card_push_transfer_instruction", value); }
    }

    /// <summary>
    /// A Check Deposit Instruction object. This field will be present in the JSON
    /// response if and only if `category` is equal to `check_deposit_instruction`.
    /// </summary>
    public CheckDepositInstruction? CheckDepositInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckDepositInstruction>(
                "check_deposit_instruction"
            );
        }
        init { this._rawData.Set("check_deposit_instruction", value); }
    }

    /// <summary>
    /// A Check Transfer Instruction object. This field will be present in the JSON
    /// response if and only if `category` is equal to `check_transfer_instruction`.
    /// </summary>
    public CheckTransferInstruction? CheckTransferInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckTransferInstruction>(
                "check_transfer_instruction"
            );
        }
        init { this._rawData.Set("check_transfer_instruction", value); }
    }

    /// <summary>
    /// A FedNow Transfer Instruction object. This field will be present in the JSON
    /// response if and only if `category` is equal to `fednow_transfer_instruction`.
    /// </summary>
    public FednowTransferInstruction? FednowTransferInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FednowTransferInstruction>(
                "fednow_transfer_instruction"
            );
        }
        init { this._rawData.Set("fednow_transfer_instruction", value); }
    }

    /// <summary>
    /// An Inbound Funds Hold object. This field will be present in the JSON response
    /// if and only if `category` is equal to `inbound_funds_hold`. We hold funds
    /// for certain transaction types to account for return windows where funds might
    /// still be clawed back by the sending institution.
    /// </summary>
    public InboundFundsHold? InboundFundsHold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundFundsHold>("inbound_funds_hold");
        }
        init { this._rawData.Set("inbound_funds_hold", value); }
    }

    /// <summary>
    /// An Inbound Wire Transfer Reversal object. This field will be present in the
    /// JSON response if and only if `category` is equal to `inbound_wire_transfer_reversal`.
    /// An Inbound Wire Transfer Reversal is created when Increase has received a
    /// wire and the User requests that it be reversed.
    /// </summary>
    public InboundWireTransferReversal? InboundWireTransferReversal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundWireTransferReversal>(
                "inbound_wire_transfer_reversal"
            );
        }
        init { this._rawData.Set("inbound_wire_transfer_reversal", value); }
    }

    /// <summary>
    /// If the category of this Transaction source is equal to `other`, this field
    /// will contain an empty object, otherwise it will contain null.
    /// </summary>
    public Other? Other
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Other>("other");
        }
        init { this._rawData.Set("other", value); }
    }

    /// <summary>
    /// A Real-Time Payments Transfer Instruction object. This field will be present
    /// in the JSON response if and only if `category` is equal to `real_time_payments_transfer_instruction`.
    /// </summary>
    public RealTimePaymentsTransferInstruction? RealTimePaymentsTransferInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimePaymentsTransferInstruction>(
                "real_time_payments_transfer_instruction"
            );
        }
        init { this._rawData.Set("real_time_payments_transfer_instruction", value); }
    }

    /// <summary>
    /// A Swift Transfer Instruction object. This field will be present in the JSON
    /// response if and only if `category` is equal to `swift_transfer_instruction`.
    /// </summary>
    public SwiftTransferInstruction? SwiftTransferInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SwiftTransferInstruction>(
                "swift_transfer_instruction"
            );
        }
        init { this._rawData.Set("swift_transfer_instruction", value); }
    }

    /// <summary>
    /// An User Initiated Hold object. This field will be present in the JSON response
    /// if and only if `category` is equal to `user_initiated_hold`. Created when
    /// a user initiates a hold on funds in their account.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? UserInitiatedHold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "user_initiated_hold"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "user_initiated_hold",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A Wire Transfer Instruction object. This field will be present in the JSON
    /// response if and only if `category` is equal to `wire_transfer_instruction`.
    /// </summary>
    public WireTransferInstruction? WireTransferInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WireTransferInstruction>(
                "wire_transfer_instruction"
            );
        }
        init { this._rawData.Set("wire_transfer_instruction", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.AccountTransferInstruction?.Validate();
        this.AchTransferInstruction?.Validate();
        this.BlockchainOfframpTransferInstruction?.Validate();
        this.BlockchainOnrampTransferInstruction?.Validate();
        this.CardAuthorization?.Validate();
        this.CardPushTransferInstruction?.Validate();
        this.CheckDepositInstruction?.Validate();
        this.CheckTransferInstruction?.Validate();
        this.FednowTransferInstruction?.Validate();
        this.InboundFundsHold?.Validate();
        this.InboundWireTransferReversal?.Validate();
        this.Other?.Validate();
        this.RealTimePaymentsTransferInstruction?.Validate();
        this.SwiftTransferInstruction?.Validate();
        _ = this.UserInitiatedHold;
        this.WireTransferInstruction?.Validate();
    }

    public Source() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Source(Source source)
        : base(source) { }
#pragma warning restore CS8618

    public Source(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Source(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SourceFromRaw.FromRawUnchecked"/>
    public static Source FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Source(ApiEnum<string, SourceCategory> category)
        : this()
    {
        this.Category = category;
    }
}

class SourceFromRaw : IFromRawJson<Source>
{
    /// <inheritdoc/>
    public Source FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Source.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the resource. We may add additional possible values for this enum
/// over time; your application should be able to handle such additions gracefully.
/// </summary>
[JsonConverter(typeof(SourceCategoryConverter))]
public enum SourceCategory
{
    /// <summary>
    /// Account Transfer Instruction: details will be under the `account_transfer_instruction` object.
    /// </summary>
    AccountTransferInstruction,

    /// <summary>
    /// ACH Transfer Instruction: details will be under the `ach_transfer_instruction` object.
    /// </summary>
    AchTransferInstruction,

    /// <summary>
    /// Card Authorization: details will be under the `card_authorization` object.
    /// </summary>
    CardAuthorization,

    /// <summary>
    /// Check Deposit Instruction: details will be under the `check_deposit_instruction` object.
    /// </summary>
    CheckDepositInstruction,

    /// <summary>
    /// Check Transfer Instruction: details will be under the `check_transfer_instruction` object.
    /// </summary>
    CheckTransferInstruction,

    /// <summary>
    /// FedNow Transfer Instruction: details will be under the `fednow_transfer_instruction` object.
    /// </summary>
    FednowTransferInstruction,

    /// <summary>
    /// Inbound Funds Hold: details will be under the `inbound_funds_hold` object.
    /// </summary>
    InboundFundsHold,

    /// <summary>
    /// User Initiated Hold: details will be under the `user_initiated_hold` object.
    /// </summary>
    UserInitiatedHold,

    /// <summary>
    /// Real-Time Payments Transfer Instruction: details will be under the `real_time_payments_transfer_instruction` object.
    /// </summary>
    RealTimePaymentsTransferInstruction,

    /// <summary>
    /// Wire Transfer Instruction: details will be under the `wire_transfer_instruction` object.
    /// </summary>
    WireTransferInstruction,

    /// <summary>
    /// Inbound Wire Transfer Reversal: details will be under the `inbound_wire_transfer_reversal` object.
    /// </summary>
    InboundWireTransferReversal,

    /// <summary>
    /// Swift Transfer Instruction: details will be under the `swift_transfer_instruction` object.
    /// </summary>
    SwiftTransferInstruction,

    /// <summary>
    /// Card Push Transfer Instruction: details will be under the `card_push_transfer_instruction` object.
    /// </summary>
    CardPushTransferInstruction,

    /// <summary>
    /// Blockchain On-Ramp Transfer Instruction: details will be under the `blockchain_onramp_transfer_instruction` object.
    /// </summary>
    BlockchainOnrampTransferInstruction,

    /// <summary>
    /// Blockchain Off-Ramp Transfer Instruction: details will be under the `blockchain_offramp_transfer_instruction` object.
    /// </summary>
    BlockchainOfframpTransferInstruction,

    /// <summary>
    /// The Pending Transaction was made for an undocumented or deprecated reason.
    /// </summary>
    Other,
}

sealed class SourceCategoryConverter : JsonConverter<SourceCategory>
{
    public override SourceCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_transfer_instruction" => SourceCategory.AccountTransferInstruction,
            "ach_transfer_instruction" => SourceCategory.AchTransferInstruction,
            "card_authorization" => SourceCategory.CardAuthorization,
            "check_deposit_instruction" => SourceCategory.CheckDepositInstruction,
            "check_transfer_instruction" => SourceCategory.CheckTransferInstruction,
            "fednow_transfer_instruction" => SourceCategory.FednowTransferInstruction,
            "inbound_funds_hold" => SourceCategory.InboundFundsHold,
            "user_initiated_hold" => SourceCategory.UserInitiatedHold,
            "real_time_payments_transfer_instruction" =>
                SourceCategory.RealTimePaymentsTransferInstruction,
            "wire_transfer_instruction" => SourceCategory.WireTransferInstruction,
            "inbound_wire_transfer_reversal" => SourceCategory.InboundWireTransferReversal,
            "swift_transfer_instruction" => SourceCategory.SwiftTransferInstruction,
            "card_push_transfer_instruction" => SourceCategory.CardPushTransferInstruction,
            "blockchain_onramp_transfer_instruction" =>
                SourceCategory.BlockchainOnrampTransferInstruction,
            "blockchain_offramp_transfer_instruction" =>
                SourceCategory.BlockchainOfframpTransferInstruction,
            "other" => SourceCategory.Other,
            _ => (SourceCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SourceCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SourceCategory.AccountTransferInstruction => "account_transfer_instruction",
                SourceCategory.AchTransferInstruction => "ach_transfer_instruction",
                SourceCategory.CardAuthorization => "card_authorization",
                SourceCategory.CheckDepositInstruction => "check_deposit_instruction",
                SourceCategory.CheckTransferInstruction => "check_transfer_instruction",
                SourceCategory.FednowTransferInstruction => "fednow_transfer_instruction",
                SourceCategory.InboundFundsHold => "inbound_funds_hold",
                SourceCategory.UserInitiatedHold => "user_initiated_hold",
                SourceCategory.RealTimePaymentsTransferInstruction =>
                    "real_time_payments_transfer_instruction",
                SourceCategory.WireTransferInstruction => "wire_transfer_instruction",
                SourceCategory.InboundWireTransferReversal => "inbound_wire_transfer_reversal",
                SourceCategory.SwiftTransferInstruction => "swift_transfer_instruction",
                SourceCategory.CardPushTransferInstruction => "card_push_transfer_instruction",
                SourceCategory.BlockchainOnrampTransferInstruction =>
                    "blockchain_onramp_transfer_instruction",
                SourceCategory.BlockchainOfframpTransferInstruction =>
                    "blockchain_offramp_transfer_instruction",
                SourceCategory.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An Account Transfer Instruction object. This field will be present in the JSON
/// response if and only if `category` is equal to `account_transfer_instruction`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AccountTransferInstruction, AccountTransferInstructionFromRaw>)
)]
public sealed record class AccountTransferInstruction : JsonModel
{
    /// <summary>
    /// The pending amount in the minor unit of the transaction's currency. For dollars,
    /// for example, this is cents.
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the destination
    /// account currency.
    /// </summary>
    public required ApiEnum<string, AccountTransferInstructionCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountTransferInstructionCurrency>
            >("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The identifier of the Account Transfer that led to this Pending Transaction.
    /// </summary>
    public required string TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transfer_id");
        }
        init { this._rawData.Set("transfer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
        _ = this.TransferID;
    }

    public AccountTransferInstruction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountTransferInstruction(AccountTransferInstruction accountTransferInstruction)
        : base(accountTransferInstruction) { }
#pragma warning restore CS8618

    public AccountTransferInstruction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountTransferInstruction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountTransferInstructionFromRaw.FromRawUnchecked"/>
    public static AccountTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountTransferInstructionFromRaw : IFromRawJson<AccountTransferInstruction>
{
    /// <inheritdoc/>
    public AccountTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountTransferInstruction.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the destination
/// account currency.
/// </summary>
[JsonConverter(typeof(AccountTransferInstructionCurrencyConverter))]
public enum AccountTransferInstructionCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class AccountTransferInstructionCurrencyConverter
    : JsonConverter<AccountTransferInstructionCurrency>
{
    public override AccountTransferInstructionCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => AccountTransferInstructionCurrency.Usd,
            _ => (AccountTransferInstructionCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountTransferInstructionCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountTransferInstructionCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An ACH Transfer Instruction object. This field will be present in the JSON response
/// if and only if `category` is equal to `ach_transfer_instruction`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AchTransferInstruction, AchTransferInstructionFromRaw>))]
public sealed record class AchTransferInstruction : JsonModel
{
    /// <summary>
    /// The pending amount in USD cents.
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
    /// The identifier of the ACH Transfer that led to this Pending Transaction.
    /// </summary>
    public required string TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transfer_id");
        }
        init { this._rawData.Set("transfer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.TransferID;
    }

    public AchTransferInstruction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferInstruction(AchTransferInstruction achTransferInstruction)
        : base(achTransferInstruction) { }
#pragma warning restore CS8618

    public AchTransferInstruction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AchTransferInstruction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AchTransferInstructionFromRaw.FromRawUnchecked"/>
    public static AchTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AchTransferInstructionFromRaw : IFromRawJson<AchTransferInstruction>
{
    /// <inheritdoc/>
    public AchTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AchTransferInstruction.FromRawUnchecked(rawData);
}

/// <summary>
/// A Blockchain Off-Ramp Transfer Instruction object. This field will be present
/// in the JSON response if and only if `category` is equal to `blockchain_offramp_transfer_instruction`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BlockchainOfframpTransferInstruction,
        BlockchainOfframpTransferInstructionFromRaw
    >)
)]
public sealed record class BlockchainOfframpTransferInstruction : JsonModel
{
    /// <summary>
    /// The identifier of the Blockchain Address the funds were received at.
    /// </summary>
    public required string SourceBlockchainAddressID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source_blockchain_address_id");
        }
        init { this._rawData.Set("source_blockchain_address_id", value); }
    }

    /// <summary>
    /// The identifier of the Blockchain Off-Ramp Transfer that led to this Transaction.
    /// </summary>
    public required string TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transfer_id");
        }
        init { this._rawData.Set("transfer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SourceBlockchainAddressID;
        _ = this.TransferID;
    }

    public BlockchainOfframpTransferInstruction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BlockchainOfframpTransferInstruction(
        BlockchainOfframpTransferInstruction blockchainOfframpTransferInstruction
    )
        : base(blockchainOfframpTransferInstruction) { }
#pragma warning restore CS8618

    public BlockchainOfframpTransferInstruction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BlockchainOfframpTransferInstruction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlockchainOfframpTransferInstructionFromRaw.FromRawUnchecked"/>
    public static BlockchainOfframpTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BlockchainOfframpTransferInstructionFromRaw
    : IFromRawJson<BlockchainOfframpTransferInstruction>
{
    /// <inheritdoc/>
    public BlockchainOfframpTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BlockchainOfframpTransferInstruction.FromRawUnchecked(rawData);
}

/// <summary>
/// A Blockchain On-Ramp Transfer Instruction object. This field will be present in
/// the JSON response if and only if `category` is equal to `blockchain_onramp_transfer_instruction`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BlockchainOnrampTransferInstruction,
        BlockchainOnrampTransferInstructionFromRaw
    >)
)]
public sealed record class BlockchainOnrampTransferInstruction : JsonModel
{
    /// <summary>
    /// The transfer amount in USD cents.
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
    /// The blockchain address the funds are being sent to.
    /// </summary>
    public required string DestinationBlockchainAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("destination_blockchain_address");
        }
        init { this._rawData.Set("destination_blockchain_address", value); }
    }

    /// <summary>
    /// The identifier of the Blockchain On-Ramp Transfer that led to this Pending Transaction.
    /// </summary>
    public required string TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transfer_id");
        }
        init { this._rawData.Set("transfer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.DestinationBlockchainAddress;
        _ = this.TransferID;
    }

    public BlockchainOnrampTransferInstruction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BlockchainOnrampTransferInstruction(
        BlockchainOnrampTransferInstruction blockchainOnrampTransferInstruction
    )
        : base(blockchainOnrampTransferInstruction) { }
#pragma warning restore CS8618

    public BlockchainOnrampTransferInstruction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BlockchainOnrampTransferInstruction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlockchainOnrampTransferInstructionFromRaw.FromRawUnchecked"/>
    public static BlockchainOnrampTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BlockchainOnrampTransferInstructionFromRaw : IFromRawJson<BlockchainOnrampTransferInstruction>
{
    /// <inheritdoc/>
    public BlockchainOnrampTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BlockchainOnrampTransferInstruction.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Authorization object. This field will be present in the JSON response if
/// and only if `category` is equal to `card_authorization`. Card Authorizations
/// are temporary holds placed on a customer's funds with the intent to later clear
/// a transaction.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardAuthorization, CardAuthorizationFromRaw>))]
public sealed record class CardAuthorization : JsonModel
{
    /// <summary>
    /// The Card Authorization identifier.
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
    /// Whether this authorization was approved by Increase, the card network through
    /// stand-in processing, or the user through a real-time decision.
    /// </summary>
    public required ApiEnum<string, Actioner> Actioner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Actioner>>("actioner");
        }
        init { this._rawData.Set("actioner", value); }
    }

    /// <summary>
    /// Additional amounts associated with the card authorization, such as ATM surcharges
    /// fees. These are usually a subset of the `amount` field and are used to provide
    /// more detailed information about the transaction.
    /// </summary>
    public required AdditionalAmounts AdditionalAmounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AdditionalAmounts>("additional_amounts");
        }
        init { this._rawData.Set("additional_amounts", value); }
    }

    /// <summary>
    /// The pending amount in the minor unit of the transaction's currency. For dollars,
    /// for example, this is cents.
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
    /// The ID of the Card Payment this transaction belongs to.
    /// </summary>
    public required string CardPaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("card_payment_id");
        }
        init { this._rawData.Set("card_payment_id", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's currency.
    /// </summary>
    public required ApiEnum<string, CardAuthorizationCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardAuthorizationCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// If the authorization was made via a Digital Wallet Token (such as an Apple
    /// Pay purchase), the identifier of the token that was used.
    /// </summary>
    public required string? DigitalWalletTokenID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("digital_wallet_token_id");
        }
        init { this._rawData.Set("digital_wallet_token_id", value); }
    }

    /// <summary>
    /// The direction describes the direction the funds will move, either from the
    /// cardholder to the merchant or from the merchant to the cardholder.
    /// </summary>
    public required ApiEnum<string, Direction> Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Direction>>("direction");
        }
        init { this._rawData.Set("direction", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) when this authorization
    /// will expire and the pending transaction will be released.
    /// </summary>
    public required System::DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// The merchant identifier (commonly abbreviated as MID) of the merchant the
    /// card is transacting with.
    /// </summary>
    public required string MerchantAcceptorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_acceptor_id");
        }
        init { this._rawData.Set("merchant_acceptor_id", value); }
    }

    /// <summary>
    /// The Merchant Category Code (commonly abbreviated as MCC) of the merchant the
    /// card is transacting with.
    /// </summary>
    public required string MerchantCategoryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_category_code");
        }
        init { this._rawData.Set("merchant_category_code", value); }
    }

    /// <summary>
    /// The city the merchant resides in.
    /// </summary>
    public required string? MerchantCity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_city");
        }
        init { this._rawData.Set("merchant_city", value); }
    }

    /// <summary>
    /// The country the merchant resides in.
    /// </summary>
    public required string MerchantCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_country");
        }
        init { this._rawData.Set("merchant_country", value); }
    }

    /// <summary>
    /// The merchant descriptor of the merchant the card is transacting with.
    /// </summary>
    public required string MerchantDescriptor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_descriptor");
        }
        init { this._rawData.Set("merchant_descriptor", value); }
    }

    /// <summary>
    /// The merchant's postal code. For US merchants this is either a 5-digit or 9-digit
    /// ZIP code, where the first 5 and last 4 are separated by a dash.
    /// </summary>
    public required string? MerchantPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_postal_code");
        }
        init { this._rawData.Set("merchant_postal_code", value); }
    }

    /// <summary>
    /// The state the merchant resides in.
    /// </summary>
    public required string? MerchantState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_state");
        }
        init { this._rawData.Set("merchant_state", value); }
    }

    /// <summary>
    /// Fields specific to the `network`.
    /// </summary>
    public required NetworkDetails NetworkDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NetworkDetails>("network_details");
        }
        init { this._rawData.Set("network_details", value); }
    }

    /// <summary>
    /// Network-specific identifiers for a specific request or transaction.
    /// </summary>
    public required NetworkIdentifiers NetworkIdentifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NetworkIdentifiers>("network_identifiers");
        }
        init { this._rawData.Set("network_identifiers", value); }
    }

    /// <summary>
    /// The risk score generated by the card network. For Visa this is the Visa Advanced
    /// Authorization risk score, from 0 to 99, where 99 is the riskiest. For Pulse
    /// the score is from 0 to 999, where 999 is the riskiest.
    /// </summary>
    public required long? NetworkRiskScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("network_risk_score");
        }
        init { this._rawData.Set("network_risk_score", value); }
    }

    /// <summary>
    /// The identifier of the Pending Transaction associated with this Transaction.
    /// </summary>
    public required string? PendingTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pending_transaction_id");
        }
        init { this._rawData.Set("pending_transaction_id", value); }
    }

    /// <summary>
    /// If the authorization was made in-person with a physical card, the Physical
    /// Card that was used.
    /// </summary>
    public required string? PhysicalCardID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("physical_card_id");
        }
        init { this._rawData.Set("physical_card_id", value); }
    }

    /// <summary>
    /// The pending amount in the minor unit of the transaction's presentment currency.
    /// </summary>
    public required long PresentmentAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("presentment_amount");
        }
        init { this._rawData.Set("presentment_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's
    /// presentment currency.
    /// </summary>
    public required string PresentmentCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("presentment_currency");
        }
        init { this._rawData.Set("presentment_currency", value); }
    }

    /// <summary>
    /// The processing category describes the intent behind the authorization, such
    /// as whether it was used for bill payments or an automatic fuel dispenser.
    /// </summary>
    public required ApiEnum<string, ProcessingCategory> ProcessingCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ProcessingCategory>>(
                "processing_category"
            );
        }
        init { this._rawData.Set("processing_category", value); }
    }

    /// <summary>
    /// The identifier of the Real-Time Decision sent to approve or decline this transaction.
    /// </summary>
    public required string? RealTimeDecisionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("real_time_decision_id");
        }
        init { this._rawData.Set("real_time_decision_id", value); }
    }

    /// <summary>
    /// The scheme fees associated with this card authorization.
    /// </summary>
    public required IReadOnlyList<SchemeFee> SchemeFees
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SchemeFee>>("scheme_fees");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SchemeFee>>(
                "scheme_fees",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The terminal identifier (commonly abbreviated as TID) of the terminal the
    /// card is transacting with.
    /// </summary>
    public required string? TerminalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("terminal_id");
        }
        init { this._rawData.Set("terminal_id", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `card_authorization`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.PendingTransactions.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.PendingTransactions.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Fields related to verification of cardholder-provided values.
    /// </summary>
    public required Verification Verification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Verification>("verification");
        }
        init { this._rawData.Set("verification", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Actioner.Validate();
        this.AdditionalAmounts.Validate();
        _ = this.Amount;
        _ = this.CardPaymentID;
        this.Currency.Validate();
        _ = this.DigitalWalletTokenID;
        this.Direction.Validate();
        _ = this.ExpiresAt;
        _ = this.MerchantAcceptorID;
        _ = this.MerchantCategoryCode;
        _ = this.MerchantCity;
        _ = this.MerchantCountry;
        _ = this.MerchantDescriptor;
        _ = this.MerchantPostalCode;
        _ = this.MerchantState;
        this.NetworkDetails.Validate();
        this.NetworkIdentifiers.Validate();
        _ = this.NetworkRiskScore;
        _ = this.PendingTransactionID;
        _ = this.PhysicalCardID;
        _ = this.PresentmentAmount;
        _ = this.PresentmentCurrency;
        this.ProcessingCategory.Validate();
        _ = this.RealTimeDecisionID;
        foreach (var item in this.SchemeFees)
        {
            item.Validate();
        }
        _ = this.TerminalID;
        this.Type.Validate();
        this.Verification.Validate();
    }

    public CardAuthorization() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorization(CardAuthorization cardAuthorization)
        : base(cardAuthorization) { }
#pragma warning restore CS8618

    public CardAuthorization(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorization(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthorizationFromRaw.FromRawUnchecked"/>
    public static CardAuthorization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardAuthorizationFromRaw : IFromRawJson<CardAuthorization>
{
    /// <inheritdoc/>
    public CardAuthorization FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardAuthorization.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether this authorization was approved by Increase, the card network through
/// stand-in processing, or the user through a real-time decision.
/// </summary>
[JsonConverter(typeof(ActionerConverter))]
public enum Actioner
{
    /// <summary>
    /// This object was actioned by the user through a real-time decision.
    /// </summary>
    User,

    /// <summary>
    /// This object was actioned by Increase without user intervention.
    /// </summary>
    Increase,

    /// <summary>
    /// This object was actioned by the network, through stand-in processing.
    /// </summary>
    Network,
}

sealed class ActionerConverter : JsonConverter<Actioner>
{
    public override Actioner Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => Actioner.User,
            "increase" => Actioner.Increase,
            "network" => Actioner.Network,
            _ => (Actioner)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Actioner value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Actioner.User => "user",
                Actioner.Increase => "increase",
                Actioner.Network => "network",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Additional amounts associated with the card authorization, such as ATM surcharges
/// fees. These are usually a subset of the `amount` field and are used to provide
/// more detailed information about the transaction.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AdditionalAmounts, AdditionalAmountsFromRaw>))]
public sealed record class AdditionalAmounts : JsonModel
{
    /// <summary>
    /// The part of this transaction amount that was for clinic-related services.
    /// </summary>
    public required Clinic? Clinic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Clinic>("clinic");
        }
        init { this._rawData.Set("clinic", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for dental-related services.
    /// </summary>
    public required Dental? Dental
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Dental>("dental");
        }
        init { this._rawData.Set("dental", value); }
    }

    /// <summary>
    /// The original pre-authorized amount.
    /// </summary>
    public required Original? Original
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Original>("original");
        }
        init { this._rawData.Set("original", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for healthcare prescriptions.
    /// </summary>
    public required Prescription? Prescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Prescription>("prescription");
        }
        init { this._rawData.Set("prescription", value); }
    }

    /// <summary>
    /// The surcharge amount charged for this transaction by the merchant.
    /// </summary>
    public required Surcharge? Surcharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Surcharge>("surcharge");
        }
        init { this._rawData.Set("surcharge", value); }
    }

    /// <summary>
    /// The total amount of a series of incremental authorizations, optionally provided.
    /// </summary>
    public required TotalCumulative? TotalCumulative
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TotalCumulative>("total_cumulative");
        }
        init { this._rawData.Set("total_cumulative", value); }
    }

    /// <summary>
    /// The total amount of healthcare-related additional amounts.
    /// </summary>
    public required TotalHealthcare? TotalHealthcare
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TotalHealthcare>("total_healthcare");
        }
        init { this._rawData.Set("total_healthcare", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for transit-related services.
    /// </summary>
    public required Transit? Transit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Transit>("transit");
        }
        init { this._rawData.Set("transit", value); }
    }

    /// <summary>
    /// An unknown additional amount.
    /// </summary>
    public required Unknown? Unknown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Unknown>("unknown");
        }
        init { this._rawData.Set("unknown", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for vision-related services.
    /// </summary>
    public required Vision? Vision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Vision>("vision");
        }
        init { this._rawData.Set("vision", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Clinic?.Validate();
        this.Dental?.Validate();
        this.Original?.Validate();
        this.Prescription?.Validate();
        this.Surcharge?.Validate();
        this.TotalCumulative?.Validate();
        this.TotalHealthcare?.Validate();
        this.Transit?.Validate();
        this.Unknown?.Validate();
        this.Vision?.Validate();
    }

    public AdditionalAmounts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AdditionalAmounts(AdditionalAmounts additionalAmounts)
        : base(additionalAmounts) { }
#pragma warning restore CS8618

    public AdditionalAmounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AdditionalAmounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AdditionalAmountsFromRaw.FromRawUnchecked"/>
    public static AdditionalAmounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AdditionalAmountsFromRaw : IFromRawJson<AdditionalAmounts>
{
    /// <inheritdoc/>
    public AdditionalAmounts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AdditionalAmounts.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for clinic-related services.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Clinic, ClinicFromRaw>))]
public sealed record class Clinic : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Clinic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Clinic(Clinic clinic)
        : base(clinic) { }
#pragma warning restore CS8618

    public Clinic(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Clinic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClinicFromRaw.FromRawUnchecked"/>
    public static Clinic FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClinicFromRaw : IFromRawJson<Clinic>
{
    /// <inheritdoc/>
    public Clinic FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Clinic.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for dental-related services.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Dental, DentalFromRaw>))]
public sealed record class Dental : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Dental() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Dental(Dental dental)
        : base(dental) { }
#pragma warning restore CS8618

    public Dental(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Dental(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DentalFromRaw.FromRawUnchecked"/>
    public static Dental FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DentalFromRaw : IFromRawJson<Dental>
{
    /// <inheritdoc/>
    public Dental FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Dental.FromRawUnchecked(rawData);
}

/// <summary>
/// The original pre-authorized amount.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Original, OriginalFromRaw>))]
public sealed record class Original : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Original() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Original(Original original)
        : base(original) { }
#pragma warning restore CS8618

    public Original(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Original(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginalFromRaw.FromRawUnchecked"/>
    public static Original FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginalFromRaw : IFromRawJson<Original>
{
    /// <inheritdoc/>
    public Original FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Original.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for healthcare prescriptions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Prescription, PrescriptionFromRaw>))]
public sealed record class Prescription : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Prescription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Prescription(Prescription prescription)
        : base(prescription) { }
#pragma warning restore CS8618

    public Prescription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Prescription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PrescriptionFromRaw.FromRawUnchecked"/>
    public static Prescription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PrescriptionFromRaw : IFromRawJson<Prescription>
{
    /// <inheritdoc/>
    public Prescription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Prescription.FromRawUnchecked(rawData);
}

/// <summary>
/// The surcharge amount charged for this transaction by the merchant.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Surcharge, SurchargeFromRaw>))]
public sealed record class Surcharge : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Surcharge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Surcharge(Surcharge surcharge)
        : base(surcharge) { }
#pragma warning restore CS8618

    public Surcharge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Surcharge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SurchargeFromRaw.FromRawUnchecked"/>
    public static Surcharge FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SurchargeFromRaw : IFromRawJson<Surcharge>
{
    /// <inheritdoc/>
    public Surcharge FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Surcharge.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of a series of incremental authorizations, optionally provided.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TotalCumulative, TotalCumulativeFromRaw>))]
public sealed record class TotalCumulative : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public TotalCumulative() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TotalCumulative(TotalCumulative totalCumulative)
        : base(totalCumulative) { }
#pragma warning restore CS8618

    public TotalCumulative(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TotalCumulative(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TotalCumulativeFromRaw.FromRawUnchecked"/>
    public static TotalCumulative FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TotalCumulativeFromRaw : IFromRawJson<TotalCumulative>
{
    /// <inheritdoc/>
    public TotalCumulative FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TotalCumulative.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of healthcare-related additional amounts.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TotalHealthcare, TotalHealthcareFromRaw>))]
public sealed record class TotalHealthcare : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public TotalHealthcare() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TotalHealthcare(TotalHealthcare totalHealthcare)
        : base(totalHealthcare) { }
#pragma warning restore CS8618

    public TotalHealthcare(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TotalHealthcare(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TotalHealthcareFromRaw.FromRawUnchecked"/>
    public static TotalHealthcare FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TotalHealthcareFromRaw : IFromRawJson<TotalHealthcare>
{
    /// <inheritdoc/>
    public TotalHealthcare FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TotalHealthcare.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for transit-related services.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Transit, TransitFromRaw>))]
public sealed record class Transit : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Transit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Transit(Transit transit)
        : base(transit) { }
#pragma warning restore CS8618

    public Transit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Transit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransitFromRaw.FromRawUnchecked"/>
    public static Transit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransitFromRaw : IFromRawJson<Transit>
{
    /// <inheritdoc/>
    public Transit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Transit.FromRawUnchecked(rawData);
}

/// <summary>
/// An unknown additional amount.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Unknown, UnknownFromRaw>))]
public sealed record class Unknown : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Unknown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Unknown(Unknown unknown)
        : base(unknown) { }
#pragma warning restore CS8618

    public Unknown(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Unknown(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnknownFromRaw.FromRawUnchecked"/>
    public static Unknown FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnknownFromRaw : IFromRawJson<Unknown>
{
    /// <inheritdoc/>
    public Unknown FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Unknown.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for vision-related services.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Vision, VisionFromRaw>))]
public sealed record class Vision : JsonModel
{
    /// <summary>
    /// The amount in minor units of the `currency` field. The amount is positive
    /// if it is added to the amount (such as an ATM surcharge fee) and negative
    /// if it is subtracted from the amount (such as a discount).
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the additional
    /// amount's currency.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Vision() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Vision(Vision vision)
        : base(vision) { }
#pragma warning restore CS8618

    public Vision(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Vision(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VisionFromRaw.FromRawUnchecked"/>
    public static Vision FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VisionFromRaw : IFromRawJson<Vision>
{
    /// <inheritdoc/>
    public Vision FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Vision.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's currency.
/// </summary>
[JsonConverter(typeof(CardAuthorizationCurrencyConverter))]
public enum CardAuthorizationCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardAuthorizationCurrencyConverter : JsonConverter<CardAuthorizationCurrency>
{
    public override CardAuthorizationCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardAuthorizationCurrency.Usd,
            _ => (CardAuthorizationCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardAuthorizationCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardAuthorizationCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The direction describes the direction the funds will move, either from the cardholder
/// to the merchant or from the merchant to the cardholder.
/// </summary>
[JsonConverter(typeof(DirectionConverter))]
public enum Direction
{
    /// <summary>
    /// A regular card authorization where funds are debited from the cardholder.
    /// </summary>
    Settlement,

    /// <summary>
    /// A refund card authorization, sometimes referred to as a credit voucher authorization,
    /// where funds are credited to the cardholder.
    /// </summary>
    Refund,
}

sealed class DirectionConverter : JsonConverter<Direction>
{
    public override Direction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "settlement" => Direction.Settlement,
            "refund" => Direction.Refund,
            _ => (Direction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Direction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Direction.Settlement => "settlement",
                Direction.Refund => "refund",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to the `network`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NetworkDetails, NetworkDetailsFromRaw>))]
public sealed record class NetworkDetails : JsonModel
{
    /// <summary>
    /// The payment network used to process this card authorization.
    /// </summary>
    public required ApiEnum<string, NetworkDetailsCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NetworkDetailsCategory>>(
                "category"
            );
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Fields specific to the `pulse` network.
    /// </summary>
    public required Pulse? Pulse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Pulse>("pulse");
        }
        init { this._rawData.Set("pulse", value); }
    }

    /// <summary>
    /// Fields specific to the `visa` network.
    /// </summary>
    public required Visa? Visa
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Visa>("visa");
        }
        init { this._rawData.Set("visa", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.Pulse?.Validate();
        this.Visa?.Validate();
    }

    public NetworkDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkDetails(NetworkDetails networkDetails)
        : base(networkDetails) { }
#pragma warning restore CS8618

    public NetworkDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NetworkDetailsFromRaw.FromRawUnchecked"/>
    public static NetworkDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NetworkDetailsFromRaw : IFromRawJson<NetworkDetails>
{
    /// <inheritdoc/>
    public NetworkDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NetworkDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// The payment network used to process this card authorization.
/// </summary>
[JsonConverter(typeof(NetworkDetailsCategoryConverter))]
public enum NetworkDetailsCategory
{
    /// <summary>
    /// Visa
    /// </summary>
    Visa,

    /// <summary>
    /// Pulse
    /// </summary>
    Pulse,
}

sealed class NetworkDetailsCategoryConverter : JsonConverter<NetworkDetailsCategory>
{
    public override NetworkDetailsCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => NetworkDetailsCategory.Visa,
            "pulse" => NetworkDetailsCategory.Pulse,
            _ => (NetworkDetailsCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NetworkDetailsCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NetworkDetailsCategory.Visa => "visa",
                NetworkDetailsCategory.Pulse => "pulse",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to the `pulse` network.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pulse, PulseFromRaw>))]
public sealed record class Pulse : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public Pulse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pulse(Pulse pulse)
        : base(pulse) { }
#pragma warning restore CS8618

    public Pulse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pulse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PulseFromRaw.FromRawUnchecked"/>
    public static Pulse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PulseFromRaw : IFromRawJson<Pulse>
{
    /// <inheritdoc/>
    public Pulse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pulse.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields specific to the `visa` network.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Visa, VisaFromRaw>))]
public sealed record class Visa : JsonModel
{
    /// <summary>
    /// For electronic commerce transactions, this identifies the level of security
    /// used in obtaining the customer's payment credential. For mail or telephone
    /// order transactions, identifies the type of mail or telephone order.
    /// </summary>
    public required ApiEnum<string, ElectronicCommerceIndicator>? ElectronicCommerceIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ElectronicCommerceIndicator>>(
                "electronic_commerce_indicator"
            );
        }
        init { this._rawData.Set("electronic_commerce_indicator", value); }
    }

    /// <summary>
    /// The method used to enter the cardholder's primary account number and card
    /// expiration date.
    /// </summary>
    public required ApiEnum<string, PointOfServiceEntryMode>? PointOfServiceEntryMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PointOfServiceEntryMode>>(
                "point_of_service_entry_mode"
            );
        }
        init { this._rawData.Set("point_of_service_entry_mode", value); }
    }

    /// <summary>
    /// Only present when `actioner: network`. Describes why a card authorization
    /// was approved or declined by Visa through stand-in processing.
    /// </summary>
    public required ApiEnum<string, StandInProcessingReason>? StandInProcessingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, StandInProcessingReason>>(
                "stand_in_processing_reason"
            );
        }
        init { this._rawData.Set("stand_in_processing_reason", value); }
    }

    /// <summary>
    /// The capability of the terminal being used to read the card. Shows whether
    /// a terminal can e.g., accept chip cards or if it only supports magnetic stripe
    /// reads. This reflects the highest capability of the terminal — for example,
    /// a terminal that supports both chip and magnetic stripe will be identified
    /// as chip-capable.
    /// </summary>
    public required ApiEnum<string, TerminalEntryCapability>? TerminalEntryCapability
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TerminalEntryCapability>>(
                "terminal_entry_capability"
            );
        }
        init { this._rawData.Set("terminal_entry_capability", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ElectronicCommerceIndicator?.Validate();
        this.PointOfServiceEntryMode?.Validate();
        this.StandInProcessingReason?.Validate();
        this.TerminalEntryCapability?.Validate();
    }

    public Visa() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Visa(Visa visa)
        : base(visa) { }
#pragma warning restore CS8618

    public Visa(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Visa(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VisaFromRaw.FromRawUnchecked"/>
    public static Visa FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VisaFromRaw : IFromRawJson<Visa>
{
    /// <inheritdoc/>
    public Visa FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Visa.FromRawUnchecked(rawData);
}

/// <summary>
/// For electronic commerce transactions, this identifies the level of security used
/// in obtaining the customer's payment credential. For mail or telephone order transactions,
/// identifies the type of mail or telephone order.
/// </summary>
[JsonConverter(typeof(ElectronicCommerceIndicatorConverter))]
public enum ElectronicCommerceIndicator
{
    /// <summary>
    /// Single transaction of a mail/phone order: Use to indicate that the transaction
    /// is a mail/phone order purchase, not a recurring transaction or installment
    /// payment. For domestic transactions in the US region, this value may also indicate
    /// one bill payment transaction in the card-present or card-absent environments.
    /// </summary>
    MailPhoneOrder,

    /// <summary>
    /// Recurring transaction: Payment indicator used to indicate a recurring transaction
    /// that originates from an acquirer in the US region.
    /// </summary>
    Recurring,

    /// <summary>
    /// Installment payment: Payment indicator used to indicate one purchase of goods
    /// or services that is billed to the account in multiple charges over a period
    /// of time agreed upon by the cardholder and merchant from transactions that
    /// originate from an acquirer in the US region.
    /// </summary>
    Installment,

    /// <summary>
    /// Unknown classification: other mail order: Use to indicate that the type of
    /// mail/telephone order is unknown.
    /// </summary>
    UnknownMailPhoneOrder,

    /// <summary>
    /// Secure electronic commerce transaction: Use to indicate that the electronic
    /// commerce transaction has been authenticated using e.g., 3-D Secure
    /// </summary>
    SecureElectronicCommerce,

    /// <summary>
    /// Non-authenticated security transaction at a 3-D Secure-capable merchant,
    /// and merchant attempted to authenticate the cardholder using 3-D Secure: Use
    /// to identify an electronic commerce transaction where the merchant attempted
    /// to authenticate the cardholder using 3-D Secure, but was unable to complete
    /// the authentication because the issuer or cardholder does not participate in
    /// the 3-D Secure program.
    /// </summary>
    NonAuthenticatedSecurityTransactionAt3dsCapableMerchant,

    /// <summary>
    /// Non-authenticated security transaction: Use to identify an electronic commerce
    /// transaction that uses data encryption for security however, cardholder authentication
    /// is not performed using 3-D Secure.
    /// </summary>
    NonAuthenticatedSecurityTransaction,

    /// <summary>
    /// Non-secure transaction: Use to identify an electronic commerce transaction
    /// that has no data protection.
    /// </summary>
    NonSecureTransaction,
}

sealed class ElectronicCommerceIndicatorConverter : JsonConverter<ElectronicCommerceIndicator>
{
    public override ElectronicCommerceIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mail_phone_order" => ElectronicCommerceIndicator.MailPhoneOrder,
            "recurring" => ElectronicCommerceIndicator.Recurring,
            "installment" => ElectronicCommerceIndicator.Installment,
            "unknown_mail_phone_order" => ElectronicCommerceIndicator.UnknownMailPhoneOrder,
            "secure_electronic_commerce" => ElectronicCommerceIndicator.SecureElectronicCommerce,
            "non_authenticated_security_transaction_at_3ds_capable_merchant" =>
                ElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant,
            "non_authenticated_security_transaction" =>
                ElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction,
            "non_secure_transaction" => ElectronicCommerceIndicator.NonSecureTransaction,
            _ => (ElectronicCommerceIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ElectronicCommerceIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ElectronicCommerceIndicator.MailPhoneOrder => "mail_phone_order",
                ElectronicCommerceIndicator.Recurring => "recurring",
                ElectronicCommerceIndicator.Installment => "installment",
                ElectronicCommerceIndicator.UnknownMailPhoneOrder => "unknown_mail_phone_order",
                ElectronicCommerceIndicator.SecureElectronicCommerce =>
                    "secure_electronic_commerce",
                ElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant =>
                    "non_authenticated_security_transaction_at_3ds_capable_merchant",
                ElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction =>
                    "non_authenticated_security_transaction",
                ElectronicCommerceIndicator.NonSecureTransaction => "non_secure_transaction",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The method used to enter the cardholder's primary account number and card expiration date.
/// </summary>
[JsonConverter(typeof(PointOfServiceEntryModeConverter))]
public enum PointOfServiceEntryMode
{
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown,

    /// <summary>
    /// Manual key entry
    /// </summary>
    Manual,

    /// <summary>
    /// Magnetic stripe read, without card verification value
    /// </summary>
    MagneticStripeNoCvv,

    /// <summary>
    /// Optical code
    /// </summary>
    OpticalCode,

    /// <summary>
    /// Contact chip card
    /// </summary>
    IntegratedCircuitCard,

    /// <summary>
    /// Contactless read of chip card
    /// </summary>
    Contactless,

    /// <summary>
    /// Transaction initiated using a credential that has previously been stored
    /// on file
    /// </summary>
    CredentialOnFile,

    /// <summary>
    /// Magnetic stripe read
    /// </summary>
    MagneticStripe,

    /// <summary>
    /// Contactless read of magnetic stripe data
    /// </summary>
    ContactlessMagneticStripe,

    /// <summary>
    /// Contact chip card, without card verification value
    /// </summary>
    IntegratedCircuitCardNoCvv,
}

sealed class PointOfServiceEntryModeConverter : JsonConverter<PointOfServiceEntryMode>
{
    public override PointOfServiceEntryMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" => PointOfServiceEntryMode.Unknown,
            "manual" => PointOfServiceEntryMode.Manual,
            "magnetic_stripe_no_cvv" => PointOfServiceEntryMode.MagneticStripeNoCvv,
            "optical_code" => PointOfServiceEntryMode.OpticalCode,
            "integrated_circuit_card" => PointOfServiceEntryMode.IntegratedCircuitCard,
            "contactless" => PointOfServiceEntryMode.Contactless,
            "credential_on_file" => PointOfServiceEntryMode.CredentialOnFile,
            "magnetic_stripe" => PointOfServiceEntryMode.MagneticStripe,
            "contactless_magnetic_stripe" => PointOfServiceEntryMode.ContactlessMagneticStripe,
            "integrated_circuit_card_no_cvv" => PointOfServiceEntryMode.IntegratedCircuitCardNoCvv,
            _ => (PointOfServiceEntryMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PointOfServiceEntryMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PointOfServiceEntryMode.Unknown => "unknown",
                PointOfServiceEntryMode.Manual => "manual",
                PointOfServiceEntryMode.MagneticStripeNoCvv => "magnetic_stripe_no_cvv",
                PointOfServiceEntryMode.OpticalCode => "optical_code",
                PointOfServiceEntryMode.IntegratedCircuitCard => "integrated_circuit_card",
                PointOfServiceEntryMode.Contactless => "contactless",
                PointOfServiceEntryMode.CredentialOnFile => "credential_on_file",
                PointOfServiceEntryMode.MagneticStripe => "magnetic_stripe",
                PointOfServiceEntryMode.ContactlessMagneticStripe => "contactless_magnetic_stripe",
                PointOfServiceEntryMode.IntegratedCircuitCardNoCvv =>
                    "integrated_circuit_card_no_cvv",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Only present when `actioner: network`. Describes why a card authorization was
/// approved or declined by Visa through stand-in processing.
/// </summary>
[JsonConverter(typeof(StandInProcessingReasonConverter))]
public enum StandInProcessingReason
{
    /// <summary>
    /// Increase failed to process the authorization in a timely manner.
    /// </summary>
    IssuerError,

    /// <summary>
    /// The physical card read had an invalid CVV or dCVV.
    /// </summary>
    InvalidPhysicalCard,

    /// <summary>
    /// The card's authorization request cryptogram was invalid. The cryptogram can
    /// be from a physical card or a Digital Wallet Token purchase.
    /// </summary>
    InvalidCryptogram,

    /// <summary>
    /// The 3DS cardholder authentication verification value was invalid.
    /// </summary>
    InvalidCardholderAuthenticationVerificationValue,

    /// <summary>
    /// An internal Visa error occurred. Visa uses this reason code for certain expected
    /// occurrences as well, such as Application Transaction Counter (ATC) replays.
    /// </summary>
    InternalVisaError,

    /// <summary>
    /// The merchant has enabled Visa's Transaction Advisory Service and requires
    /// further authentication to perform the transaction. In practice this is often
    /// utilized at fuel pumps to tell the cardholder to see the cashier.
    /// </summary>
    MerchantTransactionAdvisoryServiceAuthenticationRequired,

    /// <summary>
    /// The transaction was blocked by Visa's Payment Fraud Disruption service due
    /// to fraudulent Acquirer behavior, such as card testing.
    /// </summary>
    PaymentFraudDisruptionAcquirerBlock,

    /// <summary>
    /// An unspecific reason for stand-in processing.
    /// </summary>
    Other,
}

sealed class StandInProcessingReasonConverter : JsonConverter<StandInProcessingReason>
{
    public override StandInProcessingReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "issuer_error" => StandInProcessingReason.IssuerError,
            "invalid_physical_card" => StandInProcessingReason.InvalidPhysicalCard,
            "invalid_cryptogram" => StandInProcessingReason.InvalidCryptogram,
            "invalid_cardholder_authentication_verification_value" =>
                StandInProcessingReason.InvalidCardholderAuthenticationVerificationValue,
            "internal_visa_error" => StandInProcessingReason.InternalVisaError,
            "merchant_transaction_advisory_service_authentication_required" =>
                StandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired,
            "payment_fraud_disruption_acquirer_block" =>
                StandInProcessingReason.PaymentFraudDisruptionAcquirerBlock,
            "other" => StandInProcessingReason.Other,
            _ => (StandInProcessingReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StandInProcessingReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StandInProcessingReason.IssuerError => "issuer_error",
                StandInProcessingReason.InvalidPhysicalCard => "invalid_physical_card",
                StandInProcessingReason.InvalidCryptogram => "invalid_cryptogram",
                StandInProcessingReason.InvalidCardholderAuthenticationVerificationValue =>
                    "invalid_cardholder_authentication_verification_value",
                StandInProcessingReason.InternalVisaError => "internal_visa_error",
                StandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired =>
                    "merchant_transaction_advisory_service_authentication_required",
                StandInProcessingReason.PaymentFraudDisruptionAcquirerBlock =>
                    "payment_fraud_disruption_acquirer_block",
                StandInProcessingReason.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The capability of the terminal being used to read the card. Shows whether a terminal
/// can e.g., accept chip cards or if it only supports magnetic stripe reads. This
/// reflects the highest capability of the terminal — for example, a terminal that
/// supports both chip and magnetic stripe will be identified as chip-capable.
/// </summary>
[JsonConverter(typeof(TerminalEntryCapabilityConverter))]
public enum TerminalEntryCapability
{
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown,

    /// <summary>
    /// No terminal was used for this transaction.
    /// </summary>
    TerminalNotUsed,

    /// <summary>
    /// The terminal can only read magnetic stripes and does not have chip or contactless
    /// reading capability.
    /// </summary>
    MagneticStripe,

    /// <summary>
    /// The terminal can only read barcodes.
    /// </summary>
    Barcode,

    /// <summary>
    /// The terminal can only read cards via Optical Character Recognition.
    /// </summary>
    OpticalCharacterRecognition,

    /// <summary>
    /// The terminal supports contact chip cards and can also read the magnetic stripe.
    /// If contact chip is supported, this value is used regardless of whether contactless
    /// is also supported.
    /// </summary>
    ChipOrContactless,

    /// <summary>
    /// The terminal supports contactless reads but does not support contact chip.
    /// Only used when the terminal lacks contact chip capability.
    /// </summary>
    ContactlessOnly,

    /// <summary>
    /// The terminal has no card reading capability.
    /// </summary>
    NoCapability,
}

sealed class TerminalEntryCapabilityConverter : JsonConverter<TerminalEntryCapability>
{
    public override TerminalEntryCapability Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" => TerminalEntryCapability.Unknown,
            "terminal_not_used" => TerminalEntryCapability.TerminalNotUsed,
            "magnetic_stripe" => TerminalEntryCapability.MagneticStripe,
            "barcode" => TerminalEntryCapability.Barcode,
            "optical_character_recognition" => TerminalEntryCapability.OpticalCharacterRecognition,
            "chip_or_contactless" => TerminalEntryCapability.ChipOrContactless,
            "contactless_only" => TerminalEntryCapability.ContactlessOnly,
            "no_capability" => TerminalEntryCapability.NoCapability,
            _ => (TerminalEntryCapability)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TerminalEntryCapability value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TerminalEntryCapability.Unknown => "unknown",
                TerminalEntryCapability.TerminalNotUsed => "terminal_not_used",
                TerminalEntryCapability.MagneticStripe => "magnetic_stripe",
                TerminalEntryCapability.Barcode => "barcode",
                TerminalEntryCapability.OpticalCharacterRecognition =>
                    "optical_character_recognition",
                TerminalEntryCapability.ChipOrContactless => "chip_or_contactless",
                TerminalEntryCapability.ContactlessOnly => "contactless_only",
                TerminalEntryCapability.NoCapability => "no_capability",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Network-specific identifiers for a specific request or transaction.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NetworkIdentifiers, NetworkIdentifiersFromRaw>))]
public sealed record class NetworkIdentifiers : JsonModel
{
    /// <summary>
    /// The randomly generated 6-character Authorization Identification Response code
    /// sent back to the acquirer in an approved response.
    /// </summary>
    public required string? AuthorizationIdentificationResponse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("authorization_identification_response");
        }
        init { this._rawData.Set("authorization_identification_response", value); }
    }

    /// <summary>
    /// A life-cycle identifier used across e.g., an authorization and a reversal.
    /// Expected to be unique per acquirer within a window of time. For some card
    /// networks the retrieval reference number includes the trace counter.
    /// </summary>
    public required string? RetrievalReferenceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("retrieval_reference_number");
        }
        init { this._rawData.Set("retrieval_reference_number", value); }
    }

    /// <summary>
    /// A counter used to verify an individual authorization. Expected to be unique
    /// per acquirer within a window of time.
    /// </summary>
    public required string? TraceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("trace_number");
        }
        init { this._rawData.Set("trace_number", value); }
    }

    /// <summary>
    /// A globally unique transaction identifier provided by the card network, used
    /// across multiple life-cycle requests.
    /// </summary>
    public required string? TransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transaction_id");
        }
        init { this._rawData.Set("transaction_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AuthorizationIdentificationResponse;
        _ = this.RetrievalReferenceNumber;
        _ = this.TraceNumber;
        _ = this.TransactionID;
    }

    public NetworkIdentifiers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkIdentifiers(NetworkIdentifiers networkIdentifiers)
        : base(networkIdentifiers) { }
#pragma warning restore CS8618

    public NetworkIdentifiers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkIdentifiers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NetworkIdentifiersFromRaw.FromRawUnchecked"/>
    public static NetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NetworkIdentifiersFromRaw : IFromRawJson<NetworkIdentifiers>
{
    /// <inheritdoc/>
    public NetworkIdentifiers FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NetworkIdentifiers.FromRawUnchecked(rawData);
}

/// <summary>
/// The processing category describes the intent behind the authorization, such as
/// whether it was used for bill payments or an automatic fuel dispenser.
/// </summary>
[JsonConverter(typeof(ProcessingCategoryConverter))]
public enum ProcessingCategory
{
    /// <summary>
    /// Account funding transactions are transactions used to e.g., fund an account
    /// or transfer funds between accounts.
    /// </summary>
    AccountFunding,

    /// <summary>
    /// Automatic fuel dispenser authorizations occur when a card is used at a gas
    /// pump, prior to the actual transaction amount being known. They are followed
    /// by an advice message that updates the amount of the pending transaction.
    /// </summary>
    AutomaticFuelDispenser,

    /// <summary>
    /// A transaction used to pay a bill.
    /// </summary>
    BillPayment,

    /// <summary>
    /// Original credit transactions are used to send money to a cardholder.
    /// </summary>
    OriginalCredit,

    /// <summary>
    /// A regular purchase.
    /// </summary>
    Purchase,

    /// <summary>
    /// Quasi-cash transactions represent purchases of items which may be convertible
    /// to cash.
    /// </summary>
    QuasiCash,

    /// <summary>
    /// A refund card authorization, sometimes referred to as a credit voucher authorization,
    /// where funds are credited to the cardholder.
    /// </summary>
    Refund,

    /// <summary>
    /// Cash disbursement transactions are used to withdraw cash from an ATM or a
    /// point of sale.
    /// </summary>
    CashDisbursement,

    /// <summary>
    /// A balance inquiry transaction is used to check the balance of an account associated
    /// with a card.
    /// </summary>
    BalanceInquiry,

    /// <summary>
    /// The processing category is unknown.
    /// </summary>
    Unknown,
}

sealed class ProcessingCategoryConverter : JsonConverter<ProcessingCategory>
{
    public override ProcessingCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_funding" => ProcessingCategory.AccountFunding,
            "automatic_fuel_dispenser" => ProcessingCategory.AutomaticFuelDispenser,
            "bill_payment" => ProcessingCategory.BillPayment,
            "original_credit" => ProcessingCategory.OriginalCredit,
            "purchase" => ProcessingCategory.Purchase,
            "quasi_cash" => ProcessingCategory.QuasiCash,
            "refund" => ProcessingCategory.Refund,
            "cash_disbursement" => ProcessingCategory.CashDisbursement,
            "balance_inquiry" => ProcessingCategory.BalanceInquiry,
            "unknown" => ProcessingCategory.Unknown,
            _ => (ProcessingCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProcessingCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProcessingCategory.AccountFunding => "account_funding",
                ProcessingCategory.AutomaticFuelDispenser => "automatic_fuel_dispenser",
                ProcessingCategory.BillPayment => "bill_payment",
                ProcessingCategory.OriginalCredit => "original_credit",
                ProcessingCategory.Purchase => "purchase",
                ProcessingCategory.QuasiCash => "quasi_cash",
                ProcessingCategory.Refund => "refund",
                ProcessingCategory.CashDisbursement => "cash_disbursement",
                ProcessingCategory.BalanceInquiry => "balance_inquiry",
                ProcessingCategory.Unknown => "unknown",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<SchemeFee, SchemeFeeFromRaw>))]
public sealed record class SchemeFee : JsonModel
{
    /// <summary>
    /// The fee amount given as a string containing a decimal number.
    /// </summary>
    public required string Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the fee
    /// was created.
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the fee reimbursement.
    /// </summary>
    public required ApiEnum<string, SchemeFeeCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SchemeFeeCurrency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The type of fee being assessed.
    /// </summary>
    public required ApiEnum<string, FeeType> FeeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FeeType>>("fee_type");
        }
        init { this._rawData.Set("fee_type", value); }
    }

    /// <summary>
    /// The fixed component of the fee, if applicable, given in major units of the
    /// fee amount.
    /// </summary>
    public required string? FixedComponent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fixed_component");
        }
        init { this._rawData.Set("fixed_component", value); }
    }

    /// <summary>
    /// The variable rate component of the fee, if applicable, given as a decimal
    /// (e.g., 0.015 for 1.5%).
    /// </summary>
    public required string? VariableRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("variable_rate");
        }
        init { this._rawData.Set("variable_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.CreatedAt;
        this.Currency.Validate();
        this.FeeType.Validate();
        _ = this.FixedComponent;
        _ = this.VariableRate;
    }

    public SchemeFee() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SchemeFee(SchemeFee schemeFee)
        : base(schemeFee) { }
#pragma warning restore CS8618

    public SchemeFee(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SchemeFee(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SchemeFeeFromRaw.FromRawUnchecked"/>
    public static SchemeFee FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SchemeFeeFromRaw : IFromRawJson<SchemeFee>
{
    /// <inheritdoc/>
    public SchemeFee FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SchemeFee.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the fee reimbursement.
/// </summary>
[JsonConverter(typeof(SchemeFeeCurrencyConverter))]
public enum SchemeFeeCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class SchemeFeeCurrencyConverter : JsonConverter<SchemeFeeCurrency>
{
    public override SchemeFeeCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => SchemeFeeCurrency.Usd,
            _ => (SchemeFeeCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SchemeFeeCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SchemeFeeCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of fee being assessed.
/// </summary>
[JsonConverter(typeof(FeeTypeConverter))]
public enum FeeType
{
    /// <summary>
    /// International Service Assessment (ISA) single-currency is a fee assessed by
    /// the card network for cross-border transactions presented and settled in the
    /// same currency.
    /// </summary>
    VisaInternationalServiceAssessmentSingleCurrency,

    /// <summary>
    /// International Service Assessment (ISA) cross-currency is a fee assessed by
    /// the card network for cross-border transactions presented and settled in different currencies.
    /// </summary>
    VisaInternationalServiceAssessmentCrossCurrency,

    /// <summary>
    /// Activity and charges for Visa Settlement System processing for POS (Point-Of-Sale)
    /// authorization transactions. Authorization is the process of approving or
    /// declining the transaction amount specified. The fee is assessed to the Issuer.
    /// </summary>
    VisaAuthorizationDomesticPointOfSale,

    /// <summary>
    /// Activity and charges for Visa Settlement System processing for POS (Point-Of-Sale)
    /// International authorization transactions. Authorization is the process of
    /// approving or declining the transaction amount specified. The fee is assessed
    /// to the Issuer.
    /// </summary>
    VisaAuthorizationInternationalPointOfSale,

    /// <summary>
    /// Activity and charges for Visa Settlement System processing for Canada Region
    /// POS (Point-of-Sale) authorization transactions. Authorization is the process
    /// of approving or declining the transaction amount specified.
    /// </summary>
    VisaAuthorizationCanadaPointOfSale,

    /// <summary>
    /// Activity only for Visa Settlement System authorization processing of POS
    /// (Point-Of-Sale) reversal transactions. Authorization reversal represents
    /// a VSS message that undoes the complete or partial actions of a previous authorization request.
    /// </summary>
    VisaAuthorizationReversalPointOfSale,

    /// <summary>
    /// Activity only for Visa Settlement System authorization processing of POS
    /// (Point-Of-Sale) International reversal transactions. Authorization reversal
    /// represents a VSS message that undoes the complete or partial actions of a
    /// previous authorization request.
    /// </summary>
    VisaAuthorizationReversalInternationalPointOfSale,

    /// <summary>
    /// A per Address Verification Service (AVS) result fee. Applies to all usable
    /// AVS result codes.
    /// </summary>
    VisaAuthorizationAddressVerificationService,

    /// <summary>
    /// Advanced Authorization is a fraud detection tool that monitors and risk evaluates
    /// 100 percent of US VisaNet authorizations in real-time. Activity related to
    /// Purchase (includes Signature Authenticated Visa and PIN Authenticated Visa
    /// Debit (PAVD) transactions).
    /// </summary>
    VisaAdvancedAuthorization,

    /// <summary>
    /// Issuer Transactions Visa represents a charge based on total actual monthly
    /// processing (Visa transactions only) through a VisaNet Access Point (VAP).
    /// Charges are assessed to the processor for each VisaNet Access Point.
    /// </summary>
    VisaMessageTransmission,

    /// <summary>
    /// Activity, per inquiry, related to the domestic Issuer for Account Number Verification.
    /// </summary>
    VisaAccountVerificationDomestic,

    /// <summary>
    /// Activity, per inquiry, related to the international Issuer for Account Number Verification.
    /// </summary>
    VisaAccountVerificationInternational,

    /// <summary>
    /// Activity, per inquiry, related to the US-Canada Issuer for Account Number Verification.
    /// </summary>
    VisaAccountVerificationCanada,

    /// <summary>
    /// The Corporate Acceptance Fee is charged to issuers and is based on the monthly
    /// sales volume on Commercial and Government Debit, Prepaid, Credit, Charge,
    /// or Deferred Debit card transactions.
    /// </summary>
    VisaCorporateAcceptanceFee,

    /// <summary>
    /// The Consumer Debit Acceptance Fee is charged to issuers and is based on the
    /// monthly sales volume of Consumer Debit or Prepaid card transactions. The cashback
    /// portion of a Debit and Prepaid card transaction is excluded from the sales
    /// volume calculation.
    /// </summary>
    VisaConsumerDebitAcceptanceFee,

    /// <summary>
    /// The Business Acceptance Fee is charged to issuers and is based on the monthly
    /// sales volume on Business Debit, Prepaid, Credit, Charge, or Deferred Debit
    /// card transactions. The cashback portion is included in the sales volume calculation
    /// with the exception of a Debit and Prepaid card transactions.
    /// </summary>
    VisaBusinessDebitAcceptanceFee,

    /// <summary>
    /// The Purchasing Card Acceptance Fee is charged to issuers and is based on the
    /// monthly sales volume on Commercial and Government Debit, Prepaid, Credit,
    /// Charge, or Deferred Debit card transactions.
    /// </summary>
    VisaPurchasingAcceptanceFee,

    /// <summary>
    /// Activity and fees for the processing of a sales draft original for a purchase transaction.
    /// </summary>
    VisaPurchaseDomestic,

    /// <summary>
    /// Activity and fees for the processing of an international sales draft original
    /// for a purchase transaction.
    /// </summary>
    VisaPurchaseInternational,

    /// <summary>
    /// Apple Pay Credit Product Token Purchase Original Transactions. This fee is
    /// billed by Visa on behalf of Apple Inc. for Apple Pay transactions.
    /// </summary>
    VisaCreditPurchaseToken,

    /// <summary>
    /// Apple Pay Debit Product Token Purchase Original Transactions. This fee is
    /// billed by Visa on behalf of Apple Inc. for Apple Pay transactions.
    /// </summary>
    VisaDebitPurchaseToken,

    /// <summary>
    /// A per transaction fee assessed for Base II financial draft - Issuer.
    /// </summary>
    VisaClearingTransmission,

    /// <summary>
    /// Issuer charge for Non-Financial OCT/AFT Authorization 0100 and Declined Financial
    /// OCT/AFT 0200 transactions.
    /// </summary>
    VisaDirectAuthorization,

    /// <summary>
    /// Data processing charge for Visa Direct OCTs for all business application identifiers
    /// (BAIs) other than money transfer-bank initiated (BI). BASE II transactions.
    /// </summary>
    VisaDirectTransactionDomestic,

    /// <summary>
    /// Issuer card service fee for Commercial Credit cards.
    /// </summary>
    VisaServiceCommercialCredit,

    /// <summary>
    /// Issuer Advertising Service Fee for Commercial Credit cards.
    /// </summary>
    VisaAdvertisingServiceCommercialCredit,

    /// <summary>
    /// Issuer Community Growth Acceleration Program Fee.
    /// </summary>
    VisaCommunityGrowthAccelerationProgram,

    /// <summary>
    /// Issuer Processing Guarantee for Commercial Credit cards.
    /// </summary>
    VisaProcessingGuaranteeCommercialCredit,

    /// <summary>
    /// Pulse Switch Fee is a fee charged by the Pulse network for processing transactions
    /// on its network.
    /// </summary>
    PulseSwitchFee,
}

sealed class FeeTypeConverter : JsonConverter<FeeType>
{
    public override FeeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa_international_service_assessment_single_currency" =>
                FeeType.VisaInternationalServiceAssessmentSingleCurrency,
            "visa_international_service_assessment_cross_currency" =>
                FeeType.VisaInternationalServiceAssessmentCrossCurrency,
            "visa_authorization_domestic_point_of_sale" =>
                FeeType.VisaAuthorizationDomesticPointOfSale,
            "visa_authorization_international_point_of_sale" =>
                FeeType.VisaAuthorizationInternationalPointOfSale,
            "visa_authorization_canada_point_of_sale" => FeeType.VisaAuthorizationCanadaPointOfSale,
            "visa_authorization_reversal_point_of_sale" =>
                FeeType.VisaAuthorizationReversalPointOfSale,
            "visa_authorization_reversal_international_point_of_sale" =>
                FeeType.VisaAuthorizationReversalInternationalPointOfSale,
            "visa_authorization_address_verification_service" =>
                FeeType.VisaAuthorizationAddressVerificationService,
            "visa_advanced_authorization" => FeeType.VisaAdvancedAuthorization,
            "visa_message_transmission" => FeeType.VisaMessageTransmission,
            "visa_account_verification_domestic" => FeeType.VisaAccountVerificationDomestic,
            "visa_account_verification_international" =>
                FeeType.VisaAccountVerificationInternational,
            "visa_account_verification_canada" => FeeType.VisaAccountVerificationCanada,
            "visa_corporate_acceptance_fee" => FeeType.VisaCorporateAcceptanceFee,
            "visa_consumer_debit_acceptance_fee" => FeeType.VisaConsumerDebitAcceptanceFee,
            "visa_business_debit_acceptance_fee" => FeeType.VisaBusinessDebitAcceptanceFee,
            "visa_purchasing_acceptance_fee" => FeeType.VisaPurchasingAcceptanceFee,
            "visa_purchase_domestic" => FeeType.VisaPurchaseDomestic,
            "visa_purchase_international" => FeeType.VisaPurchaseInternational,
            "visa_credit_purchase_token" => FeeType.VisaCreditPurchaseToken,
            "visa_debit_purchase_token" => FeeType.VisaDebitPurchaseToken,
            "visa_clearing_transmission" => FeeType.VisaClearingTransmission,
            "visa_direct_authorization" => FeeType.VisaDirectAuthorization,
            "visa_direct_transaction_domestic" => FeeType.VisaDirectTransactionDomestic,
            "visa_service_commercial_credit" => FeeType.VisaServiceCommercialCredit,
            "visa_advertising_service_commercial_credit" =>
                FeeType.VisaAdvertisingServiceCommercialCredit,
            "visa_community_growth_acceleration_program" =>
                FeeType.VisaCommunityGrowthAccelerationProgram,
            "visa_processing_guarantee_commercial_credit" =>
                FeeType.VisaProcessingGuaranteeCommercialCredit,
            "pulse_switch_fee" => FeeType.PulseSwitchFee,
            _ => (FeeType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, FeeType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeeType.VisaInternationalServiceAssessmentSingleCurrency =>
                    "visa_international_service_assessment_single_currency",
                FeeType.VisaInternationalServiceAssessmentCrossCurrency =>
                    "visa_international_service_assessment_cross_currency",
                FeeType.VisaAuthorizationDomesticPointOfSale =>
                    "visa_authorization_domestic_point_of_sale",
                FeeType.VisaAuthorizationInternationalPointOfSale =>
                    "visa_authorization_international_point_of_sale",
                FeeType.VisaAuthorizationCanadaPointOfSale =>
                    "visa_authorization_canada_point_of_sale",
                FeeType.VisaAuthorizationReversalPointOfSale =>
                    "visa_authorization_reversal_point_of_sale",
                FeeType.VisaAuthorizationReversalInternationalPointOfSale =>
                    "visa_authorization_reversal_international_point_of_sale",
                FeeType.VisaAuthorizationAddressVerificationService =>
                    "visa_authorization_address_verification_service",
                FeeType.VisaAdvancedAuthorization => "visa_advanced_authorization",
                FeeType.VisaMessageTransmission => "visa_message_transmission",
                FeeType.VisaAccountVerificationDomestic => "visa_account_verification_domestic",
                FeeType.VisaAccountVerificationInternational =>
                    "visa_account_verification_international",
                FeeType.VisaAccountVerificationCanada => "visa_account_verification_canada",
                FeeType.VisaCorporateAcceptanceFee => "visa_corporate_acceptance_fee",
                FeeType.VisaConsumerDebitAcceptanceFee => "visa_consumer_debit_acceptance_fee",
                FeeType.VisaBusinessDebitAcceptanceFee => "visa_business_debit_acceptance_fee",
                FeeType.VisaPurchasingAcceptanceFee => "visa_purchasing_acceptance_fee",
                FeeType.VisaPurchaseDomestic => "visa_purchase_domestic",
                FeeType.VisaPurchaseInternational => "visa_purchase_international",
                FeeType.VisaCreditPurchaseToken => "visa_credit_purchase_token",
                FeeType.VisaDebitPurchaseToken => "visa_debit_purchase_token",
                FeeType.VisaClearingTransmission => "visa_clearing_transmission",
                FeeType.VisaDirectAuthorization => "visa_direct_authorization",
                FeeType.VisaDirectTransactionDomestic => "visa_direct_transaction_domestic",
                FeeType.VisaServiceCommercialCredit => "visa_service_commercial_credit",
                FeeType.VisaAdvertisingServiceCommercialCredit =>
                    "visa_advertising_service_commercial_credit",
                FeeType.VisaCommunityGrowthAccelerationProgram =>
                    "visa_community_growth_acceleration_program",
                FeeType.VisaProcessingGuaranteeCommercialCredit =>
                    "visa_processing_guarantee_commercial_credit",
                FeeType.PulseSwitchFee => "pulse_switch_fee",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_authorization`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    CardAuthorization,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.PendingTransactions.Type>
{
    public override global::Increase.Api.Models.PendingTransactions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_authorization" => global::Increase
                .Api
                .Models
                .PendingTransactions
                .Type
                .CardAuthorization,
            _ => (global::Increase.Api.Models.PendingTransactions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.PendingTransactions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.PendingTransactions.Type.CardAuthorization =>
                    "card_authorization",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields related to verification of cardholder-provided values.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Verification, VerificationFromRaw>))]
public sealed record class Verification : JsonModel
{
    /// <summary>
    /// Fields related to verification of the Card Verification Code, a 3-digit code
    /// on the back of the card.
    /// </summary>
    public required CardVerificationCode CardVerificationCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardVerificationCode>("card_verification_code");
        }
        init { this._rawData.Set("card_verification_code", value); }
    }

    /// <summary>
    /// Cardholder address provided in the authorization request and the address
    /// on file we verified it against.
    /// </summary>
    public required CardholderAddress CardholderAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardholderAddress>("cardholder_address");
        }
        init { this._rawData.Set("cardholder_address", value); }
    }

    /// <summary>
    /// Cardholder name provided in the authorization request.
    /// </summary>
    public required CardholderName? CardholderName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardholderName>("cardholder_name");
        }
        init { this._rawData.Set("cardholder_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CardVerificationCode.Validate();
        this.CardholderAddress.Validate();
        this.CardholderName?.Validate();
    }

    public Verification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Verification(Verification verification)
        : base(verification) { }
#pragma warning restore CS8618

    public Verification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Verification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerificationFromRaw.FromRawUnchecked"/>
    public static Verification FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerificationFromRaw : IFromRawJson<Verification>
{
    /// <inheritdoc/>
    public Verification FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Verification.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields related to verification of the Card Verification Code, a 3-digit code
/// on the back of the card.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardVerificationCode, CardVerificationCodeFromRaw>))]
public sealed record class CardVerificationCode : JsonModel
{
    /// <summary>
    /// The result of verifying the Card Verification Code.
    /// </summary>
    public required ApiEnum<string, Result> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Result>>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Result.Validate();
    }

    public CardVerificationCode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardVerificationCode(CardVerificationCode cardVerificationCode)
        : base(cardVerificationCode) { }
#pragma warning restore CS8618

    public CardVerificationCode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardVerificationCode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardVerificationCodeFromRaw.FromRawUnchecked"/>
    public static CardVerificationCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardVerificationCode(ApiEnum<string, Result> result)
        : this()
    {
        this.Result = result;
    }
}

class CardVerificationCodeFromRaw : IFromRawJson<CardVerificationCode>
{
    /// <inheritdoc/>
    public CardVerificationCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardVerificationCode.FromRawUnchecked(rawData);
}

/// <summary>
/// The result of verifying the Card Verification Code.
/// </summary>
[JsonConverter(typeof(ResultConverter))]
public enum Result
{
    /// <summary>
    /// No card verification code was provided in the authorization request.
    /// </summary>
    NotChecked,

    /// <summary>
    /// The card verification code matched the one on file.
    /// </summary>
    Match,

    /// <summary>
    /// The card verification code did not match the one on file.
    /// </summary>
    NoMatch,
}

sealed class ResultConverter : JsonConverter<Result>
{
    public override Result Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_checked" => Result.NotChecked,
            "match" => Result.Match,
            "no_match" => Result.NoMatch,
            _ => (Result)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Result value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Result.NotChecked => "not_checked",
                Result.Match => "match",
                Result.NoMatch => "no_match",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Cardholder address provided in the authorization request and the address on file
/// we verified it against.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardholderAddress, CardholderAddressFromRaw>))]
public sealed record class CardholderAddress : JsonModel
{
    /// <summary>
    /// Line 1 of the address on file for the cardholder.
    /// </summary>
    public required string? ActualLine1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("actual_line1");
        }
        init { this._rawData.Set("actual_line1", value); }
    }

    /// <summary>
    /// The postal code of the address on file for the cardholder.
    /// </summary>
    public required string? ActualPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("actual_postal_code");
        }
        init { this._rawData.Set("actual_postal_code", value); }
    }

    /// <summary>
    /// The cardholder address line 1 provided for verification in the authorization request.
    /// </summary>
    public required string? ProvidedLine1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("provided_line1");
        }
        init { this._rawData.Set("provided_line1", value); }
    }

    /// <summary>
    /// The postal code provided for verification in the authorization request.
    /// </summary>
    public required string? ProvidedPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("provided_postal_code");
        }
        init { this._rawData.Set("provided_postal_code", value); }
    }

    /// <summary>
    /// The address verification result returned to the card network.
    /// </summary>
    public required ApiEnum<string, CardholderAddressResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardholderAddressResult>>(
                "result"
            );
        }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActualLine1;
        _ = this.ActualPostalCode;
        _ = this.ProvidedLine1;
        _ = this.ProvidedPostalCode;
        this.Result.Validate();
    }

    public CardholderAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardholderAddress(CardholderAddress cardholderAddress)
        : base(cardholderAddress) { }
#pragma warning restore CS8618

    public CardholderAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardholderAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardholderAddressFromRaw.FromRawUnchecked"/>
    public static CardholderAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardholderAddressFromRaw : IFromRawJson<CardholderAddress>
{
    /// <inheritdoc/>
    public CardholderAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardholderAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The address verification result returned to the card network.
/// </summary>
[JsonConverter(typeof(CardholderAddressResultConverter))]
public enum CardholderAddressResult
{
    /// <summary>
    /// No address information was provided in the authorization request.
    /// </summary>
    NotChecked,

    /// <summary>
    /// Postal code matches, but the street address does not match or was not provided.
    /// </summary>
    PostalCodeMatchAddressNoMatch,

    /// <summary>
    /// Postal code does not match, but the street address matches or was not provided.
    /// </summary>
    PostalCodeNoMatchAddressMatch,

    /// <summary>
    /// Postal code and street address match.
    /// </summary>
    Match,

    /// <summary>
    /// Postal code and street address do not match.
    /// </summary>
    NoMatch,

    /// <summary>
    /// Postal code matches, but the street address was not verified. (deprecated)
    /// </summary>
    PostalCodeMatchAddressNotChecked,
}

sealed class CardholderAddressResultConverter : JsonConverter<CardholderAddressResult>
{
    public override CardholderAddressResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_checked" => CardholderAddressResult.NotChecked,
            "postal_code_match_address_no_match" =>
                CardholderAddressResult.PostalCodeMatchAddressNoMatch,
            "postal_code_no_match_address_match" =>
                CardholderAddressResult.PostalCodeNoMatchAddressMatch,
            "match" => CardholderAddressResult.Match,
            "no_match" => CardholderAddressResult.NoMatch,
            "postal_code_match_address_not_checked" =>
                CardholderAddressResult.PostalCodeMatchAddressNotChecked,
            _ => (CardholderAddressResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardholderAddressResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardholderAddressResult.NotChecked => "not_checked",
                CardholderAddressResult.PostalCodeMatchAddressNoMatch =>
                    "postal_code_match_address_no_match",
                CardholderAddressResult.PostalCodeNoMatchAddressMatch =>
                    "postal_code_no_match_address_match",
                CardholderAddressResult.Match => "match",
                CardholderAddressResult.NoMatch => "no_match",
                CardholderAddressResult.PostalCodeMatchAddressNotChecked =>
                    "postal_code_match_address_not_checked",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Cardholder name provided in the authorization request.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardholderName, CardholderNameFromRaw>))]
public sealed record class CardholderName : JsonModel
{
    /// <summary>
    /// The first name provided for verification in the authorization request.
    /// </summary>
    public required string? ProvidedFirstName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("provided_first_name");
        }
        init { this._rawData.Set("provided_first_name", value); }
    }

    /// <summary>
    /// The last name provided for verification in the authorization request.
    /// </summary>
    public required string? ProvidedLastName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("provided_last_name");
        }
        init { this._rawData.Set("provided_last_name", value); }
    }

    /// <summary>
    /// The middle name provided for verification in the authorization request.
    /// </summary>
    public required string? ProvidedMiddleName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("provided_middle_name");
        }
        init { this._rawData.Set("provided_middle_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProvidedFirstName;
        _ = this.ProvidedLastName;
        _ = this.ProvidedMiddleName;
    }

    public CardholderName() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardholderName(CardholderName cardholderName)
        : base(cardholderName) { }
#pragma warning restore CS8618

    public CardholderName(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardholderName(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardholderNameFromRaw.FromRawUnchecked"/>
    public static CardholderName FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardholderNameFromRaw : IFromRawJson<CardholderName>
{
    /// <inheritdoc/>
    public CardholderName FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardholderName.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Push Transfer Instruction object. This field will be present in the JSON
/// response if and only if `category` is equal to `card_push_transfer_instruction`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CardPushTransferInstruction, CardPushTransferInstructionFromRaw>)
)]
public sealed record class CardPushTransferInstruction : JsonModel
{
    /// <summary>
    /// The transfer amount in USD cents.
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
    /// The identifier of the Card Push Transfer that led to this Pending Transaction.
    /// </summary>
    public required string TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transfer_id");
        }
        init { this._rawData.Set("transfer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.TransferID;
    }

    public CardPushTransferInstruction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardPushTransferInstruction(CardPushTransferInstruction cardPushTransferInstruction)
        : base(cardPushTransferInstruction) { }
#pragma warning restore CS8618

    public CardPushTransferInstruction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardPushTransferInstruction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardPushTransferInstructionFromRaw.FromRawUnchecked"/>
    public static CardPushTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardPushTransferInstructionFromRaw : IFromRawJson<CardPushTransferInstruction>
{
    /// <inheritdoc/>
    public CardPushTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardPushTransferInstruction.FromRawUnchecked(rawData);
}

/// <summary>
/// A Check Deposit Instruction object. This field will be present in the JSON response
/// if and only if `category` is equal to `check_deposit_instruction`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CheckDepositInstruction, CheckDepositInstructionFromRaw>))]
public sealed record class CheckDepositInstruction : JsonModel
{
    /// <summary>
    /// The pending amount in USD cents.
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
    /// The identifier of the File containing the image of the back of the check
    /// that was deposited.
    /// </summary>
    public required string? BackImageFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("back_image_file_id");
        }
        init { this._rawData.Set("back_image_file_id", value); }
    }

    /// <summary>
    /// The identifier of the Check Deposit.
    /// </summary>
    public required string? CheckDepositID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("check_deposit_id");
        }
        init { this._rawData.Set("check_deposit_id", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's currency.
    /// </summary>
    public required ApiEnum<string, CheckDepositInstructionCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CheckDepositInstructionCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The identifier of the File containing the image of the front of the check
    /// that was deposited.
    /// </summary>
    public required string FrontImageFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("front_image_file_id");
        }
        init { this._rawData.Set("front_image_file_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BackImageFileID;
        _ = this.CheckDepositID;
        this.Currency.Validate();
        _ = this.FrontImageFileID;
    }

    public CheckDepositInstruction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckDepositInstruction(CheckDepositInstruction checkDepositInstruction)
        : base(checkDepositInstruction) { }
#pragma warning restore CS8618

    public CheckDepositInstruction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckDepositInstruction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckDepositInstructionFromRaw.FromRawUnchecked"/>
    public static CheckDepositInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckDepositInstructionFromRaw : IFromRawJson<CheckDepositInstruction>
{
    /// <inheritdoc/>
    public CheckDepositInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckDepositInstruction.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's currency.
/// </summary>
[JsonConverter(typeof(CheckDepositInstructionCurrencyConverter))]
public enum CheckDepositInstructionCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CheckDepositInstructionCurrencyConverter
    : JsonConverter<CheckDepositInstructionCurrency>
{
    public override CheckDepositInstructionCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CheckDepositInstructionCurrency.Usd,
            _ => (CheckDepositInstructionCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckDepositInstructionCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckDepositInstructionCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Check Transfer Instruction object. This field will be present in the JSON response
/// if and only if `category` is equal to `check_transfer_instruction`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CheckTransferInstruction, CheckTransferInstructionFromRaw>)
)]
public sealed record class CheckTransferInstruction : JsonModel
{
    /// <summary>
    /// The transfer amount in USD cents.
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the check's currency.
    /// </summary>
    public required ApiEnum<string, CheckTransferInstructionCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CheckTransferInstructionCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The identifier of the Check Transfer that led to this Pending Transaction.
    /// </summary>
    public required string TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transfer_id");
        }
        init { this._rawData.Set("transfer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
        _ = this.TransferID;
    }

    public CheckTransferInstruction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckTransferInstruction(CheckTransferInstruction checkTransferInstruction)
        : base(checkTransferInstruction) { }
#pragma warning restore CS8618

    public CheckTransferInstruction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckTransferInstruction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckTransferInstructionFromRaw.FromRawUnchecked"/>
    public static CheckTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckTransferInstructionFromRaw : IFromRawJson<CheckTransferInstruction>
{
    /// <inheritdoc/>
    public CheckTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckTransferInstruction.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the check's currency.
/// </summary>
[JsonConverter(typeof(CheckTransferInstructionCurrencyConverter))]
public enum CheckTransferInstructionCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CheckTransferInstructionCurrencyConverter
    : JsonConverter<CheckTransferInstructionCurrency>
{
    public override CheckTransferInstructionCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CheckTransferInstructionCurrency.Usd,
            _ => (CheckTransferInstructionCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckTransferInstructionCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckTransferInstructionCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A FedNow Transfer Instruction object. This field will be present in the JSON response
/// if and only if `category` is equal to `fednow_transfer_instruction`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FednowTransferInstruction, FednowTransferInstructionFromRaw>)
)]
public sealed record class FednowTransferInstruction : JsonModel
{
    /// <summary>
    /// The identifier of the FedNow Transfer that led to this Pending Transaction.
    /// </summary>
    public required string TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transfer_id");
        }
        init { this._rawData.Set("transfer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TransferID;
    }

    public FednowTransferInstruction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FednowTransferInstruction(FednowTransferInstruction fednowTransferInstruction)
        : base(fednowTransferInstruction) { }
#pragma warning restore CS8618

    public FednowTransferInstruction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FednowTransferInstruction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FednowTransferInstructionFromRaw.FromRawUnchecked"/>
    public static FednowTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FednowTransferInstruction(string transferID)
        : this()
    {
        this.TransferID = transferID;
    }
}

class FednowTransferInstructionFromRaw : IFromRawJson<FednowTransferInstruction>
{
    /// <inheritdoc/>
    public FednowTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FednowTransferInstruction.FromRawUnchecked(rawData);
}

/// <summary>
/// An Inbound Funds Hold object. This field will be present in the JSON response
/// if and only if `category` is equal to `inbound_funds_hold`. We hold funds for
/// certain transaction types to account for return windows where funds might still
/// be clawed back by the sending institution.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InboundFundsHold, InboundFundsHoldFromRaw>))]
public sealed record class InboundFundsHold : JsonModel
{
    /// <summary>
    /// The held amount in the minor unit of the account's currency. For dollars,
    /// for example, this is cents.
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
    /// When the hold will be released automatically. Certain conditions may cause
    /// it to be released before this time.
    /// </summary>
    public required System::DateTimeOffset AutomaticallyReleasesAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "automatically_releases_at"
            );
        }
        init { this._rawData.Set("automatically_releases_at", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the hold
    /// was created.
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the hold's currency.
    /// </summary>
    public required ApiEnum<string, InboundFundsHoldCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InboundFundsHoldCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The ID of the Transaction for which funds were held.
    /// </summary>
    public required string? HeldTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("held_transaction_id");
        }
        init { this._rawData.Set("held_transaction_id", value); }
    }

    /// <summary>
    /// The ID of the Pending Transaction representing the held funds.
    /// </summary>
    public required string? PendingTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pending_transaction_id");
        }
        init { this._rawData.Set("pending_transaction_id", value); }
    }

    /// <summary>
    /// When the hold was released (if it has been released).
    /// </summary>
    public required System::DateTimeOffset? ReleasedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("released_at");
        }
        init { this._rawData.Set("released_at", value); }
    }

    /// <summary>
    /// The status of the hold.
    /// </summary>
    public required ApiEnum<string, InboundFundsHoldStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InboundFundsHoldStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `inbound_funds_hold`.
    /// </summary>
    public required ApiEnum<string, InboundFundsHoldType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InboundFundsHoldType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.AutomaticallyReleasesAt;
        _ = this.CreatedAt;
        this.Currency.Validate();
        _ = this.HeldTransactionID;
        _ = this.PendingTransactionID;
        _ = this.ReleasedAt;
        this.Status.Validate();
        this.Type.Validate();
    }

    public InboundFundsHold() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundFundsHold(InboundFundsHold inboundFundsHold)
        : base(inboundFundsHold) { }
#pragma warning restore CS8618

    public InboundFundsHold(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundFundsHold(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundFundsHoldFromRaw.FromRawUnchecked"/>
    public static InboundFundsHold FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundFundsHoldFromRaw : IFromRawJson<InboundFundsHold>
{
    /// <inheritdoc/>
    public InboundFundsHold FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InboundFundsHold.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the hold's currency.
/// </summary>
[JsonConverter(typeof(InboundFundsHoldCurrencyConverter))]
public enum InboundFundsHoldCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class InboundFundsHoldCurrencyConverter : JsonConverter<InboundFundsHoldCurrency>
{
    public override InboundFundsHoldCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => InboundFundsHoldCurrency.Usd,
            _ => (InboundFundsHoldCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundFundsHoldCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InboundFundsHoldCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the hold.
/// </summary>
[JsonConverter(typeof(InboundFundsHoldStatusConverter))]
public enum InboundFundsHoldStatus
{
    /// <summary>
    /// Funds are still being held.
    /// </summary>
    Held,

    /// <summary>
    /// Funds have been released.
    /// </summary>
    Complete,
}

sealed class InboundFundsHoldStatusConverter : JsonConverter<InboundFundsHoldStatus>
{
    public override InboundFundsHoldStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "held" => InboundFundsHoldStatus.Held,
            "complete" => InboundFundsHoldStatus.Complete,
            _ => (InboundFundsHoldStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundFundsHoldStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InboundFundsHoldStatus.Held => "held",
                InboundFundsHoldStatus.Complete => "complete",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `inbound_funds_hold`.
/// </summary>
[JsonConverter(typeof(InboundFundsHoldTypeConverter))]
public enum InboundFundsHoldType
{
    InboundFundsHold,
}

sealed class InboundFundsHoldTypeConverter : JsonConverter<InboundFundsHoldType>
{
    public override InboundFundsHoldType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_funds_hold" => InboundFundsHoldType.InboundFundsHold,
            _ => (InboundFundsHoldType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundFundsHoldType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InboundFundsHoldType.InboundFundsHold => "inbound_funds_hold",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An Inbound Wire Transfer Reversal object. This field will be present in the JSON
/// response if and only if `category` is equal to `inbound_wire_transfer_reversal`.
/// An Inbound Wire Transfer Reversal is created when Increase has received a wire
/// and the User requests that it be reversed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<InboundWireTransferReversal, InboundWireTransferReversalFromRaw>)
)]
public sealed record class InboundWireTransferReversal : JsonModel
{
    /// <summary>
    /// The ID of the Inbound Wire Transfer that is being reversed.
    /// </summary>
    public required string InboundWireTransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("inbound_wire_transfer_id");
        }
        init { this._rawData.Set("inbound_wire_transfer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InboundWireTransferID;
    }

    public InboundWireTransferReversal() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundWireTransferReversal(InboundWireTransferReversal inboundWireTransferReversal)
        : base(inboundWireTransferReversal) { }
#pragma warning restore CS8618

    public InboundWireTransferReversal(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundWireTransferReversal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundWireTransferReversalFromRaw.FromRawUnchecked"/>
    public static InboundWireTransferReversal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InboundWireTransferReversal(string inboundWireTransferID)
        : this()
    {
        this.InboundWireTransferID = inboundWireTransferID;
    }
}

class InboundWireTransferReversalFromRaw : IFromRawJson<InboundWireTransferReversal>
{
    /// <inheritdoc/>
    public InboundWireTransferReversal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundWireTransferReversal.FromRawUnchecked(rawData);
}

/// <summary>
/// If the category of this Transaction source is equal to `other`, this field will
/// contain an empty object, otherwise it will contain null.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Other, OtherFromRaw>))]
public sealed record class Other : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public Other() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Other(Other other)
        : base(other) { }
#pragma warning restore CS8618

    public Other(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Other(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OtherFromRaw.FromRawUnchecked"/>
    public static Other FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OtherFromRaw : IFromRawJson<Other>
{
    /// <inheritdoc/>
    public Other FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Other.FromRawUnchecked(rawData);
}

/// <summary>
/// A Real-Time Payments Transfer Instruction object. This field will be present in
/// the JSON response if and only if `category` is equal to `real_time_payments_transfer_instruction`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimePaymentsTransferInstruction,
        RealTimePaymentsTransferInstructionFromRaw
    >)
)]
public sealed record class RealTimePaymentsTransferInstruction : JsonModel
{
    /// <summary>
    /// The transfer amount in USD cents.
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
    /// The identifier of the Real-Time Payments Transfer that led to this Pending Transaction.
    /// </summary>
    public required string TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transfer_id");
        }
        init { this._rawData.Set("transfer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.TransferID;
    }

    public RealTimePaymentsTransferInstruction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimePaymentsTransferInstruction(
        RealTimePaymentsTransferInstruction realTimePaymentsTransferInstruction
    )
        : base(realTimePaymentsTransferInstruction) { }
#pragma warning restore CS8618

    public RealTimePaymentsTransferInstruction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimePaymentsTransferInstruction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimePaymentsTransferInstructionFromRaw.FromRawUnchecked"/>
    public static RealTimePaymentsTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimePaymentsTransferInstructionFromRaw : IFromRawJson<RealTimePaymentsTransferInstruction>
{
    /// <inheritdoc/>
    public RealTimePaymentsTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimePaymentsTransferInstruction.FromRawUnchecked(rawData);
}

/// <summary>
/// A Swift Transfer Instruction object. This field will be present in the JSON response
/// if and only if `category` is equal to `swift_transfer_instruction`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SwiftTransferInstruction, SwiftTransferInstructionFromRaw>)
)]
public sealed record class SwiftTransferInstruction : JsonModel
{
    /// <summary>
    /// The identifier of the Swift Transfer that led to this Pending Transaction.
    /// </summary>
    public required string TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transfer_id");
        }
        init { this._rawData.Set("transfer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TransferID;
    }

    public SwiftTransferInstruction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SwiftTransferInstruction(SwiftTransferInstruction swiftTransferInstruction)
        : base(swiftTransferInstruction) { }
#pragma warning restore CS8618

    public SwiftTransferInstruction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwiftTransferInstruction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SwiftTransferInstructionFromRaw.FromRawUnchecked"/>
    public static SwiftTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SwiftTransferInstruction(string transferID)
        : this()
    {
        this.TransferID = transferID;
    }
}

class SwiftTransferInstructionFromRaw : IFromRawJson<SwiftTransferInstruction>
{
    /// <inheritdoc/>
    public SwiftTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SwiftTransferInstruction.FromRawUnchecked(rawData);
}

/// <summary>
/// A Wire Transfer Instruction object. This field will be present in the JSON response
/// if and only if `category` is equal to `wire_transfer_instruction`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WireTransferInstruction, WireTransferInstructionFromRaw>))]
public sealed record class WireTransferInstruction : JsonModel
{
    /// <summary>
    /// The account number for the destination account.
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
    /// The transfer amount in USD cents.
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
    /// The message that will show on the recipient's bank statement.
    /// </summary>
    public required string MessageToRecipient
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message_to_recipient");
        }
        init { this._rawData.Set("message_to_recipient", value); }
    }

    /// <summary>
    /// The American Bankers' Association (ABA) Routing Transit Number (RTN) for
    /// the destination account.
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
    /// The identifier of the Wire Transfer that led to this Pending Transaction.
    /// </summary>
    public required string TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transfer_id");
        }
        init { this._rawData.Set("transfer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountNumber;
        _ = this.Amount;
        _ = this.MessageToRecipient;
        _ = this.RoutingNumber;
        _ = this.TransferID;
    }

    public WireTransferInstruction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireTransferInstruction(WireTransferInstruction wireTransferInstruction)
        : base(wireTransferInstruction) { }
#pragma warning restore CS8618

    public WireTransferInstruction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireTransferInstruction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireTransferInstructionFromRaw.FromRawUnchecked"/>
    public static WireTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WireTransferInstructionFromRaw : IFromRawJson<WireTransferInstruction>
{
    /// <inheritdoc/>
    public WireTransferInstruction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WireTransferInstruction.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the Pending Transaction has been confirmed and has an associated Transaction.
/// </summary>
[JsonConverter(typeof(PendingTransactionStatusConverter))]
public enum PendingTransactionStatus
{
    /// <summary>
    /// The Pending Transaction is still awaiting confirmation.
    /// </summary>
    Pending,

    /// <summary>
    /// The Pending Transaction is confirmed. An associated Transaction exists for
    /// this object. The Pending Transaction will no longer count against your balance
    /// and can generally be hidden from UIs, etc.
    /// </summary>
    Complete,
}

sealed class PendingTransactionStatusConverter : JsonConverter<PendingTransactionStatus>
{
    public override PendingTransactionStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => PendingTransactionStatus.Pending,
            "complete" => PendingTransactionStatus.Complete,
            _ => (PendingTransactionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PendingTransactionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PendingTransactionStatus.Pending => "pending",
                PendingTransactionStatus.Complete => "complete",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `pending_transaction`.
/// </summary>
[JsonConverter(typeof(PendingTransactionTypeConverter))]
public enum PendingTransactionType
{
    PendingTransaction,
}

sealed class PendingTransactionTypeConverter : JsonConverter<PendingTransactionType>
{
    public override PendingTransactionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_transaction" => PendingTransactionType.PendingTransaction,
            _ => (PendingTransactionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PendingTransactionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PendingTransactionType.PendingTransaction => "pending_transaction",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
