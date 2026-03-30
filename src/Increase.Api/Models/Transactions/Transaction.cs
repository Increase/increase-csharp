using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Transactions;

/// <summary>
/// Transactions are the immutable additions and removals of money from your bank
/// account. They're the equivalent of line items on your bank statement. To learn
/// more, see [Transactions and Transfers](/documentation/transactions-transfers).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Transaction, TransactionFromRaw>))]
public sealed record class Transaction : JsonModel
{
    /// <summary>
    /// The Transaction identifier.
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
    /// The identifier for the Account the Transaction belongs to.
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
    /// The Transaction amount in the minor unit of its currency. For dollars, for
    /// example, this is cents.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date on which the Transaction occurred.
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the Transaction's
    /// currency. This will match the currency on the Transaction's Account.
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
    /// An informational message describing this transaction. Use the fields in `source`
    /// to get more detailed information. This field appears as the line-item on the statement.
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
    /// The identifier for the route this Transaction came through. Routes are things
    /// like cards and ACH details.
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
    /// The type of the route this Transaction came through.
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
    /// the Transaction. Note that for backwards compatibility reasons, additional
    /// undocumented keys may appear in this object. These should be treated as deprecated
    /// and will be removed in the future.
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
    /// A constant representing the object's type. For this resource it will always
    /// be `transaction`.
    /// </summary>
    public required ApiEnum<string, TransactionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TransactionType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.Amount;
        _ = this.CreatedAt;
        this.Currency.Validate();
        _ = this.Description;
        _ = this.RouteID;
        this.RouteType?.Validate();
        this.Source.Validate();
        this.Type.Validate();
    }

    public Transaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Transaction(Transaction transaction)
        : base(transaction) { }
#pragma warning restore CS8618

    public Transaction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Transaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransactionFromRaw.FromRawUnchecked"/>
    public static Transaction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransactionFromRaw : IFromRawJson<Transaction>
{
    /// <inheritdoc/>
    public Transaction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Transaction.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the Transaction's
/// currency. This will match the currency on the Transaction's Account.
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
/// The type of the route this Transaction came through.
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
/// Transaction. Note that for backwards compatibility reasons, additional undocumented
/// keys may appear in this object. These should be treated as deprecated and will
/// be removed in the future.
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
    /// An Account Revenue Payment object. This field will be present in the JSON
    /// response if and only if `category` is equal to `account_revenue_payment`.
    /// An Account Revenue Payment represents a payment made to an account from the
    /// bank. Account revenue is a type of non-interest income.
    /// </summary>
    public AccountRevenuePayment? AccountRevenuePayment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountRevenuePayment>("account_revenue_payment");
        }
        init { this._rawData.Set("account_revenue_payment", value); }
    }

    /// <summary>
    /// An Account Transfer Intention object. This field will be present in the JSON
    /// response if and only if `category` is equal to `account_transfer_intention`.
    /// Two Account Transfer Intentions are created from each Account Transfer. One
    /// decrements the source account, and the other increments the destination account.
    /// </summary>
    public AccountTransferIntention? AccountTransferIntention
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountTransferIntention>(
                "account_transfer_intention"
            );
        }
        init { this._rawData.Set("account_transfer_intention", value); }
    }

    /// <summary>
    /// An ACH Transfer Intention object. This field will be present in the JSON response
    /// if and only if `category` is equal to `ach_transfer_intention`. An ACH Transfer
    /// Intention is created from an ACH Transfer. It reflects the intention to move
    /// money into or out of an Increase account via the ACH network.
    /// </summary>
    public AchTransferIntention? AchTransferIntention
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AchTransferIntention>("ach_transfer_intention");
        }
        init { this._rawData.Set("ach_transfer_intention", value); }
    }

    /// <summary>
    /// An ACH Transfer Rejection object. This field will be present in the JSON response
    /// if and only if `category` is equal to `ach_transfer_rejection`. An ACH Transfer
    /// Rejection is created when an ACH Transfer is rejected by Increase. It offsets
    /// the ACH Transfer Intention. These rejections are rare.
    /// </summary>
    public AchTransferRejection? AchTransferRejection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AchTransferRejection>("ach_transfer_rejection");
        }
        init { this._rawData.Set("ach_transfer_rejection", value); }
    }

    /// <summary>
    /// An ACH Transfer Return object. This field will be present in the JSON response
    /// if and only if `category` is equal to `ach_transfer_return`. An ACH Transfer
    /// Return is created when an ACH Transfer is returned by the receiving bank.
    /// It offsets the ACH Transfer Intention. ACH Transfer Returns usually occur
    /// within the first two business days after the transfer is initiated, but can
    /// occur much later.
    /// </summary>
    public AchTransferReturn? AchTransferReturn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AchTransferReturn>("ach_transfer_return");
        }
        init { this._rawData.Set("ach_transfer_return", value); }
    }

    /// <summary>
    /// A Blockchain Off-Ramp Transfer Settlement object. This field will be present
    /// in the JSON response if and only if `category` is equal to `blockchain_offramp_transfer_settlement`.
    /// </summary>
    public BlockchainOfframpTransferSettlement? BlockchainOfframpTransferSettlement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BlockchainOfframpTransferSettlement>(
                "blockchain_offramp_transfer_settlement"
            );
        }
        init { this._rawData.Set("blockchain_offramp_transfer_settlement", value); }
    }

    /// <summary>
    /// A Blockchain On-Ramp Transfer Intention object. This field will be present
    /// in the JSON response if and only if `category` is equal to `blockchain_onramp_transfer_intention`.
    /// </summary>
    public BlockchainOnrampTransferIntention? BlockchainOnrampTransferIntention
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BlockchainOnrampTransferIntention>(
                "blockchain_onramp_transfer_intention"
            );
        }
        init { this._rawData.Set("blockchain_onramp_transfer_intention", value); }
    }

    /// <summary>
    /// A Legacy Card Dispute Acceptance object. This field will be present in the
    /// JSON response if and only if `category` is equal to `card_dispute_acceptance`.
    /// Contains the details of a successful Card Dispute.
    /// </summary>
    public CardDisputeAcceptance? CardDisputeAcceptance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDisputeAcceptance>("card_dispute_acceptance");
        }
        init { this._rawData.Set("card_dispute_acceptance", value); }
    }

    /// <summary>
    /// A Card Dispute Financial object. This field will be present in the JSON response
    /// if and only if `category` is equal to `card_dispute_financial`. Financial
    /// event related to a Card Dispute.
    /// </summary>
    public CardDisputeFinancial? CardDisputeFinancial
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDisputeFinancial>("card_dispute_financial");
        }
        init { this._rawData.Set("card_dispute_financial", value); }
    }

    /// <summary>
    /// A Legacy Card Dispute Loss object. This field will be present in the JSON
    /// response if and only if `category` is equal to `card_dispute_loss`. Contains
    /// the details of a lost Card Dispute.
    /// </summary>
    public CardDisputeLoss? CardDisputeLoss
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDisputeLoss>("card_dispute_loss");
        }
        init { this._rawData.Set("card_dispute_loss", value); }
    }

    /// <summary>
    /// A Card Financial object. This field will be present in the JSON response if
    /// and only if `category` is equal to `card_financial`. Card Financials are temporary
    /// holds placed on a customer's funds with the intent to later clear a transaction.
    /// </summary>
    public CardFinancial? CardFinancial
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardFinancial>("card_financial");
        }
        init { this._rawData.Set("card_financial", value); }
    }

    /// <summary>
    /// A Card Push Transfer Acceptance object. This field will be present in the
    /// JSON response if and only if `category` is equal to `card_push_transfer_acceptance`.
    /// A Card Push Transfer Acceptance is created when an Outbound Card Push Transfer
    /// sent from Increase is accepted by the receiving bank.
    /// </summary>
    public CardPushTransferAcceptance? CardPushTransferAcceptance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardPushTransferAcceptance>(
                "card_push_transfer_acceptance"
            );
        }
        init { this._rawData.Set("card_push_transfer_acceptance", value); }
    }

    /// <summary>
    /// A Card Refund object. This field will be present in the JSON response if
    /// and only if `category` is equal to `card_refund`. Card Refunds move money
    /// back to the cardholder. While they are usually connected to a Card Settlement,
    /// an acquirer can also refund money directly to a card without relation to
    /// a transaction.
    /// </summary>
    public CardRefund? CardRefund
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardRefund>("card_refund");
        }
        init { this._rawData.Set("card_refund", value); }
    }

    /// <summary>
    /// A Card Revenue Payment object. This field will be present in the JSON response
    /// if and only if `category` is equal to `card_revenue_payment`. Card Revenue
    /// Payments reflect earnings from fees on card transactions.
    /// </summary>
    public CardRevenuePayment? CardRevenuePayment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardRevenuePayment>("card_revenue_payment");
        }
        init { this._rawData.Set("card_revenue_payment", value); }
    }

    /// <summary>
    /// A Card Settlement object. This field will be present in the JSON response
    /// if and only if `category` is equal to `card_settlement`. Card Settlements
    /// are card transactions that have cleared and settled. While a settlement is
    /// usually preceded by an authorization, an acquirer can also directly clear
    /// a transaction without first authorizing it.
    /// </summary>
    public CardSettlement? CardSettlement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardSettlement>("card_settlement");
        }
        init { this._rawData.Set("card_settlement", value); }
    }

    /// <summary>
    /// A Cashback Payment object. This field will be present in the JSON response
    /// if and only if `category` is equal to `cashback_payment`. A Cashback Payment
    /// represents the cashback paid to a cardholder for a given period. Cashback
    /// is usually paid monthly for the prior month's transactions.
    /// </summary>
    public CashbackPayment? CashbackPayment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CashbackPayment>("cashback_payment");
        }
        init { this._rawData.Set("cashback_payment", value); }
    }

    /// <summary>
    /// A Check Deposit Acceptance object. This field will be present in the JSON
    /// response if and only if `category` is equal to `check_deposit_acceptance`.
    /// A Check Deposit Acceptance is created when a Check Deposit is processed and
    /// its details confirmed. Check Deposits may be returned by the receiving bank,
    /// which will appear as a Check Deposit Return.
    /// </summary>
    public CheckDepositAcceptance? CheckDepositAcceptance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckDepositAcceptance>(
                "check_deposit_acceptance"
            );
        }
        init { this._rawData.Set("check_deposit_acceptance", value); }
    }

    /// <summary>
    /// A Check Deposit Return object. This field will be present in the JSON response
    /// if and only if `category` is equal to `check_deposit_return`. A Check Deposit
    /// Return is created when a Check Deposit is returned by the bank holding the
    /// account it was drawn against. Check Deposits may be returned for a variety
    /// of reasons, including insufficient funds or a mismatched account number. Usually,
    /// checks are returned within the first 7 days after the deposit is made.
    /// </summary>
    public CheckDepositReturn? CheckDepositReturn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckDepositReturn>("check_deposit_return");
        }
        init { this._rawData.Set("check_deposit_return", value); }
    }

    /// <summary>
    /// A Check Transfer Deposit object. This field will be present in the JSON response
    /// if and only if `category` is equal to `check_transfer_deposit`. An Inbound
    /// Check is a check drawn on an Increase account that has been deposited by an
    /// external bank account. These types of checks are not pre-registered.
    /// </summary>
    public CheckTransferDeposit? CheckTransferDeposit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckTransferDeposit>("check_transfer_deposit");
        }
        init { this._rawData.Set("check_transfer_deposit", value); }
    }

    /// <summary>
    /// A FedNow Transfer Acknowledgement object. This field will be present in the
    /// JSON response if and only if `category` is equal to `fednow_transfer_acknowledgement`.
    /// A FedNow Transfer Acknowledgement is created when a FedNow Transfer sent
    /// from Increase is acknowledged by the receiving bank.
    /// </summary>
    public FednowTransferAcknowledgement? FednowTransferAcknowledgement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FednowTransferAcknowledgement>(
                "fednow_transfer_acknowledgement"
            );
        }
        init { this._rawData.Set("fednow_transfer_acknowledgement", value); }
    }

    /// <summary>
    /// A Fee Payment object. This field will be present in the JSON response if
    /// and only if `category` is equal to `fee_payment`. A Fee Payment represents
    /// a payment made to Increase.
    /// </summary>
    public FeePayment? FeePayment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FeePayment>("fee_payment");
        }
        init { this._rawData.Set("fee_payment", value); }
    }

    /// <summary>
    /// An Inbound ACH Transfer Intention object. This field will be present in the
    /// JSON response if and only if `category` is equal to `inbound_ach_transfer`.
    /// An Inbound ACH Transfer Intention is created when an ACH transfer is initiated
    /// at another bank and received by Increase.
    /// </summary>
    public InboundAchTransfer? InboundAchTransfer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundAchTransfer>("inbound_ach_transfer");
        }
        init { this._rawData.Set("inbound_ach_transfer", value); }
    }

    /// <summary>
    /// An Inbound ACH Transfer Return Intention object. This field will be present
    /// in the JSON response if and only if `category` is equal to `inbound_ach_transfer_return_intention`.
    /// An Inbound ACH Transfer Return Intention is created when an ACH transfer is
    /// initiated at another bank and returned by Increase.
    /// </summary>
    public InboundAchTransferReturnIntention? InboundAchTransferReturnIntention
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundAchTransferReturnIntention>(
                "inbound_ach_transfer_return_intention"
            );
        }
        init { this._rawData.Set("inbound_ach_transfer_return_intention", value); }
    }

    /// <summary>
    /// An Inbound Check Adjustment object. This field will be present in the JSON
    /// response if and only if `category` is equal to `inbound_check_adjustment`.
    /// An Inbound Check Adjustment is created when Increase receives an adjustment
    /// for a check or return deposited through Check21.
    /// </summary>
    public InboundCheckAdjustment? InboundCheckAdjustment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundCheckAdjustment>(
                "inbound_check_adjustment"
            );
        }
        init { this._rawData.Set("inbound_check_adjustment", value); }
    }

    /// <summary>
    /// An Inbound Check Deposit Return Intention object. This field will be present
    /// in the JSON response if and only if `category` is equal to `inbound_check_deposit_return_intention`.
    /// An Inbound Check Deposit Return Intention is created when Increase receives
    /// an Inbound Check and the User requests that it be returned.
    /// </summary>
    public InboundCheckDepositReturnIntention? InboundCheckDepositReturnIntention
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundCheckDepositReturnIntention>(
                "inbound_check_deposit_return_intention"
            );
        }
        init { this._rawData.Set("inbound_check_deposit_return_intention", value); }
    }

    /// <summary>
    /// An Inbound FedNow Transfer Confirmation object. This field will be present
    /// in the JSON response if and only if `category` is equal to `inbound_fednow_transfer_confirmation`.
    /// An Inbound FedNow Transfer Confirmation is created when a FedNow transfer
    /// is initiated at another bank and received by Increase.
    /// </summary>
    public InboundFednowTransferConfirmation? InboundFednowTransferConfirmation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundFednowTransferConfirmation>(
                "inbound_fednow_transfer_confirmation"
            );
        }
        init { this._rawData.Set("inbound_fednow_transfer_confirmation", value); }
    }

    /// <summary>
    /// An Inbound Real-Time Payments Transfer Confirmation object. This field will
    /// be present in the JSON response if and only if `category` is equal to `inbound_real_time_payments_transfer_confirmation`.
    /// An Inbound Real-Time Payments Transfer Confirmation is created when a Real-Time
    /// Payments transfer is initiated at another bank and received by Increase.
    /// </summary>
    public InboundRealTimePaymentsTransferConfirmation? InboundRealTimePaymentsTransferConfirmation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundRealTimePaymentsTransferConfirmation>(
                "inbound_real_time_payments_transfer_confirmation"
            );
        }
        init { this._rawData.Set("inbound_real_time_payments_transfer_confirmation", value); }
    }

    /// <summary>
    /// An Inbound Wire Reversal object. This field will be present in the JSON response
    /// if and only if `category` is equal to `inbound_wire_reversal`. An Inbound
    /// Wire Reversal represents a reversal of a wire transfer that was initiated
    /// via Increase. The other bank is sending the money back. This most often happens
    /// when the original destination account details were incorrect.
    /// </summary>
    public InboundWireReversal? InboundWireReversal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundWireReversal>("inbound_wire_reversal");
        }
        init { this._rawData.Set("inbound_wire_reversal", value); }
    }

    /// <summary>
    /// An Inbound Wire Transfer Intention object. This field will be present in
    /// the JSON response if and only if `category` is equal to `inbound_wire_transfer`.
    /// An Inbound Wire Transfer Intention is created when a wire transfer is initiated
    /// at another bank and received by Increase.
    /// </summary>
    public InboundWireTransfer? InboundWireTransfer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundWireTransfer>("inbound_wire_transfer");
        }
        init { this._rawData.Set("inbound_wire_transfer", value); }
    }

    /// <summary>
    /// An Inbound Wire Transfer Reversal Intention object. This field will be present
    /// in the JSON response if and only if `category` is equal to `inbound_wire_transfer_reversal`.
    /// An Inbound Wire Transfer Reversal Intention is created when Increase has
    /// received a wire and the User requests that it be reversed.
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
    /// An Interest Payment object. This field will be present in the JSON response
    /// if and only if `category` is equal to `interest_payment`. An Interest Payment
    /// represents a payment of interest on an account. Interest is usually paid monthly.
    /// </summary>
    public InterestPayment? InterestPayment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InterestPayment>("interest_payment");
        }
        init { this._rawData.Set("interest_payment", value); }
    }

    /// <summary>
    /// An Internal Source object. This field will be present in the JSON response
    /// if and only if `category` is equal to `internal_source`. A transaction between
    /// the user and Increase. See the `reason` attribute for more information.
    /// </summary>
    public InternalSource? InternalSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InternalSource>("internal_source");
        }
        init { this._rawData.Set("internal_source", value); }
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
    /// A Real-Time Payments Transfer Acknowledgement object. This field will be
    /// present in the JSON response if and only if `category` is equal to `real_time_payments_transfer_acknowledgement`.
    /// A Real-Time Payments Transfer Acknowledgement is created when a Real-Time
    /// Payments Transfer sent from Increase is acknowledged by the receiving bank.
    /// </summary>
    public RealTimePaymentsTransferAcknowledgement? RealTimePaymentsTransferAcknowledgement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RealTimePaymentsTransferAcknowledgement>(
                "real_time_payments_transfer_acknowledgement"
            );
        }
        init { this._rawData.Set("real_time_payments_transfer_acknowledgement", value); }
    }

    /// <summary>
    /// A Sample Funds object. This field will be present in the JSON response if
    /// and only if `category` is equal to `sample_funds`. Sample funds for testing purposes.
    /// </summary>
    public SampleFunds? SampleFunds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SampleFunds>("sample_funds");
        }
        init { this._rawData.Set("sample_funds", value); }
    }

    /// <summary>
    /// A Swift Transfer Intention object. This field will be present in the JSON
    /// response if and only if `category` is equal to `swift_transfer_intention`.
    /// A Swift Transfer initiated via Increase.
    /// </summary>
    public SwiftTransferIntention? SwiftTransferIntention
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SwiftTransferIntention>(
                "swift_transfer_intention"
            );
        }
        init { this._rawData.Set("swift_transfer_intention", value); }
    }

    /// <summary>
    /// A Swift Transfer Return object. This field will be present in the JSON response
    /// if and only if `category` is equal to `swift_transfer_return`. A Swift Transfer
    /// Return is created when a Swift Transfer is returned by the receiving bank.
    /// </summary>
    public SwiftTransferReturn? SwiftTransferReturn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SwiftTransferReturn>("swift_transfer_return");
        }
        init { this._rawData.Set("swift_transfer_return", value); }
    }

    /// <summary>
    /// A Wire Transfer Intention object. This field will be present in the JSON response
    /// if and only if `category` is equal to `wire_transfer_intention`. A Wire Transfer
    /// initiated via Increase and sent to a different bank.
    /// </summary>
    public WireTransferIntention? WireTransferIntention
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WireTransferIntention>("wire_transfer_intention");
        }
        init { this._rawData.Set("wire_transfer_intention", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.AccountRevenuePayment?.Validate();
        this.AccountTransferIntention?.Validate();
        this.AchTransferIntention?.Validate();
        this.AchTransferRejection?.Validate();
        this.AchTransferReturn?.Validate();
        this.BlockchainOfframpTransferSettlement?.Validate();
        this.BlockchainOnrampTransferIntention?.Validate();
        this.CardDisputeAcceptance?.Validate();
        this.CardDisputeFinancial?.Validate();
        this.CardDisputeLoss?.Validate();
        this.CardFinancial?.Validate();
        this.CardPushTransferAcceptance?.Validate();
        this.CardRefund?.Validate();
        this.CardRevenuePayment?.Validate();
        this.CardSettlement?.Validate();
        this.CashbackPayment?.Validate();
        this.CheckDepositAcceptance?.Validate();
        this.CheckDepositReturn?.Validate();
        this.CheckTransferDeposit?.Validate();
        this.FednowTransferAcknowledgement?.Validate();
        this.FeePayment?.Validate();
        this.InboundAchTransfer?.Validate();
        this.InboundAchTransferReturnIntention?.Validate();
        this.InboundCheckAdjustment?.Validate();
        this.InboundCheckDepositReturnIntention?.Validate();
        this.InboundFednowTransferConfirmation?.Validate();
        this.InboundRealTimePaymentsTransferConfirmation?.Validate();
        this.InboundWireReversal?.Validate();
        this.InboundWireTransfer?.Validate();
        this.InboundWireTransferReversal?.Validate();
        this.InterestPayment?.Validate();
        this.InternalSource?.Validate();
        this.Other?.Validate();
        this.RealTimePaymentsTransferAcknowledgement?.Validate();
        this.SampleFunds?.Validate();
        this.SwiftTransferIntention?.Validate();
        this.SwiftTransferReturn?.Validate();
        this.WireTransferIntention?.Validate();
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
    /// Account Transfer Intention: details will be under the `account_transfer_intention` object.
    /// </summary>
    AccountTransferIntention,

    /// <summary>
    /// ACH Transfer Intention: details will be under the `ach_transfer_intention` object.
    /// </summary>
    AchTransferIntention,

    /// <summary>
    /// ACH Transfer Rejection: details will be under the `ach_transfer_rejection` object.
    /// </summary>
    AchTransferRejection,

    /// <summary>
    /// ACH Transfer Return: details will be under the `ach_transfer_return` object.
    /// </summary>
    AchTransferReturn,

    /// <summary>
    /// Cashback Payment: details will be under the `cashback_payment` object.
    /// </summary>
    CashbackPayment,

    /// <summary>
    /// Legacy Card Dispute Acceptance: details will be under the `card_dispute_acceptance` object.
    /// </summary>
    CardDisputeAcceptance,

    /// <summary>
    /// Card Dispute Financial: details will be under the `card_dispute_financial` object.
    /// </summary>
    CardDisputeFinancial,

    /// <summary>
    /// Legacy Card Dispute Loss: details will be under the `card_dispute_loss` object.
    /// </summary>
    CardDisputeLoss,

    /// <summary>
    /// Card Refund: details will be under the `card_refund` object.
    /// </summary>
    CardRefund,

    /// <summary>
    /// Card Settlement: details will be under the `card_settlement` object.
    /// </summary>
    CardSettlement,

    /// <summary>
    /// Card Financial: details will be under the `card_financial` object.
    /// </summary>
    CardFinancial,

    /// <summary>
    /// Card Revenue Payment: details will be under the `card_revenue_payment` object.
    /// </summary>
    CardRevenuePayment,

    /// <summary>
    /// Check Deposit Acceptance: details will be under the `check_deposit_acceptance` object.
    /// </summary>
    CheckDepositAcceptance,

    /// <summary>
    /// Check Deposit Return: details will be under the `check_deposit_return` object.
    /// </summary>
    CheckDepositReturn,

    /// <summary>
    /// FedNow Transfer Acknowledgement: details will be under the `fednow_transfer_acknowledgement` object.
    /// </summary>
    FednowTransferAcknowledgement,

    /// <summary>
    /// Check Transfer Deposit: details will be under the `check_transfer_deposit` object.
    /// </summary>
    CheckTransferDeposit,

    /// <summary>
    /// Fee Payment: details will be under the `fee_payment` object.
    /// </summary>
    FeePayment,

    /// <summary>
    /// Inbound ACH Transfer Intention: details will be under the `inbound_ach_transfer` object.
    /// </summary>
    InboundAchTransfer,

    /// <summary>
    /// Inbound ACH Transfer Return Intention: details will be under the `inbound_ach_transfer_return_intention` object.
    /// </summary>
    InboundAchTransferReturnIntention,

    /// <summary>
    /// Inbound Check Deposit Return Intention: details will be under the `inbound_check_deposit_return_intention` object.
    /// </summary>
    InboundCheckDepositReturnIntention,

    /// <summary>
    /// Inbound Check Adjustment: details will be under the `inbound_check_adjustment` object.
    /// </summary>
    InboundCheckAdjustment,

    /// <summary>
    /// Inbound FedNow Transfer Confirmation: details will be under the `inbound_fednow_transfer_confirmation` object.
    /// </summary>
    InboundFednowTransferConfirmation,

    /// <summary>
    /// Inbound Real-Time Payments Transfer Confirmation: details will be under the
    /// `inbound_real_time_payments_transfer_confirmation` object.
    /// </summary>
    InboundRealTimePaymentsTransferConfirmation,

    /// <summary>
    /// Inbound Wire Reversal: details will be under the `inbound_wire_reversal` object.
    /// </summary>
    InboundWireReversal,

    /// <summary>
    /// Inbound Wire Transfer Intention: details will be under the `inbound_wire_transfer` object.
    /// </summary>
    InboundWireTransfer,

    /// <summary>
    /// Inbound Wire Transfer Reversal Intention: details will be under the `inbound_wire_transfer_reversal` object.
    /// </summary>
    InboundWireTransferReversal,

    /// <summary>
    /// Interest Payment: details will be under the `interest_payment` object.
    /// </summary>
    InterestPayment,

    /// <summary>
    /// Internal Source: details will be under the `internal_source` object.
    /// </summary>
    InternalSource,

    /// <summary>
    /// Real-Time Payments Transfer Acknowledgement: details will be under the `real_time_payments_transfer_acknowledgement` object.
    /// </summary>
    RealTimePaymentsTransferAcknowledgement,

    /// <summary>
    /// Sample Funds: details will be under the `sample_funds` object.
    /// </summary>
    SampleFunds,

    /// <summary>
    /// Wire Transfer Intention: details will be under the `wire_transfer_intention` object.
    /// </summary>
    WireTransferIntention,

    /// <summary>
    /// Swift Transfer Intention: details will be under the `swift_transfer_intention` object.
    /// </summary>
    SwiftTransferIntention,

    /// <summary>
    /// Swift Transfer Return: details will be under the `swift_transfer_return` object.
    /// </summary>
    SwiftTransferReturn,

    /// <summary>
    /// Card Push Transfer Acceptance: details will be under the `card_push_transfer_acceptance` object.
    /// </summary>
    CardPushTransferAcceptance,

    /// <summary>
    /// Account Revenue Payment: details will be under the `account_revenue_payment` object.
    /// </summary>
    AccountRevenuePayment,

    /// <summary>
    /// Blockchain On-Ramp Transfer Intention: details will be under the `blockchain_onramp_transfer_intention` object.
    /// </summary>
    BlockchainOnrampTransferIntention,

    /// <summary>
    /// Blockchain Off-Ramp Transfer Settlement: details will be under the `blockchain_offramp_transfer_settlement` object.
    /// </summary>
    BlockchainOfframpTransferSettlement,

    /// <summary>
    /// The Transaction was made for an undocumented or deprecated reason.
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
            "account_transfer_intention" => SourceCategory.AccountTransferIntention,
            "ach_transfer_intention" => SourceCategory.AchTransferIntention,
            "ach_transfer_rejection" => SourceCategory.AchTransferRejection,
            "ach_transfer_return" => SourceCategory.AchTransferReturn,
            "cashback_payment" => SourceCategory.CashbackPayment,
            "card_dispute_acceptance" => SourceCategory.CardDisputeAcceptance,
            "card_dispute_financial" => SourceCategory.CardDisputeFinancial,
            "card_dispute_loss" => SourceCategory.CardDisputeLoss,
            "card_refund" => SourceCategory.CardRefund,
            "card_settlement" => SourceCategory.CardSettlement,
            "card_financial" => SourceCategory.CardFinancial,
            "card_revenue_payment" => SourceCategory.CardRevenuePayment,
            "check_deposit_acceptance" => SourceCategory.CheckDepositAcceptance,
            "check_deposit_return" => SourceCategory.CheckDepositReturn,
            "fednow_transfer_acknowledgement" => SourceCategory.FednowTransferAcknowledgement,
            "check_transfer_deposit" => SourceCategory.CheckTransferDeposit,
            "fee_payment" => SourceCategory.FeePayment,
            "inbound_ach_transfer" => SourceCategory.InboundAchTransfer,
            "inbound_ach_transfer_return_intention" =>
                SourceCategory.InboundAchTransferReturnIntention,
            "inbound_check_deposit_return_intention" =>
                SourceCategory.InboundCheckDepositReturnIntention,
            "inbound_check_adjustment" => SourceCategory.InboundCheckAdjustment,
            "inbound_fednow_transfer_confirmation" =>
                SourceCategory.InboundFednowTransferConfirmation,
            "inbound_real_time_payments_transfer_confirmation" =>
                SourceCategory.InboundRealTimePaymentsTransferConfirmation,
            "inbound_wire_reversal" => SourceCategory.InboundWireReversal,
            "inbound_wire_transfer" => SourceCategory.InboundWireTransfer,
            "inbound_wire_transfer_reversal" => SourceCategory.InboundWireTransferReversal,
            "interest_payment" => SourceCategory.InterestPayment,
            "internal_source" => SourceCategory.InternalSource,
            "real_time_payments_transfer_acknowledgement" =>
                SourceCategory.RealTimePaymentsTransferAcknowledgement,
            "sample_funds" => SourceCategory.SampleFunds,
            "wire_transfer_intention" => SourceCategory.WireTransferIntention,
            "swift_transfer_intention" => SourceCategory.SwiftTransferIntention,
            "swift_transfer_return" => SourceCategory.SwiftTransferReturn,
            "card_push_transfer_acceptance" => SourceCategory.CardPushTransferAcceptance,
            "account_revenue_payment" => SourceCategory.AccountRevenuePayment,
            "blockchain_onramp_transfer_intention" =>
                SourceCategory.BlockchainOnrampTransferIntention,
            "blockchain_offramp_transfer_settlement" =>
                SourceCategory.BlockchainOfframpTransferSettlement,
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
                SourceCategory.AccountTransferIntention => "account_transfer_intention",
                SourceCategory.AchTransferIntention => "ach_transfer_intention",
                SourceCategory.AchTransferRejection => "ach_transfer_rejection",
                SourceCategory.AchTransferReturn => "ach_transfer_return",
                SourceCategory.CashbackPayment => "cashback_payment",
                SourceCategory.CardDisputeAcceptance => "card_dispute_acceptance",
                SourceCategory.CardDisputeFinancial => "card_dispute_financial",
                SourceCategory.CardDisputeLoss => "card_dispute_loss",
                SourceCategory.CardRefund => "card_refund",
                SourceCategory.CardSettlement => "card_settlement",
                SourceCategory.CardFinancial => "card_financial",
                SourceCategory.CardRevenuePayment => "card_revenue_payment",
                SourceCategory.CheckDepositAcceptance => "check_deposit_acceptance",
                SourceCategory.CheckDepositReturn => "check_deposit_return",
                SourceCategory.FednowTransferAcknowledgement => "fednow_transfer_acknowledgement",
                SourceCategory.CheckTransferDeposit => "check_transfer_deposit",
                SourceCategory.FeePayment => "fee_payment",
                SourceCategory.InboundAchTransfer => "inbound_ach_transfer",
                SourceCategory.InboundAchTransferReturnIntention =>
                    "inbound_ach_transfer_return_intention",
                SourceCategory.InboundCheckDepositReturnIntention =>
                    "inbound_check_deposit_return_intention",
                SourceCategory.InboundCheckAdjustment => "inbound_check_adjustment",
                SourceCategory.InboundFednowTransferConfirmation =>
                    "inbound_fednow_transfer_confirmation",
                SourceCategory.InboundRealTimePaymentsTransferConfirmation =>
                    "inbound_real_time_payments_transfer_confirmation",
                SourceCategory.InboundWireReversal => "inbound_wire_reversal",
                SourceCategory.InboundWireTransfer => "inbound_wire_transfer",
                SourceCategory.InboundWireTransferReversal => "inbound_wire_transfer_reversal",
                SourceCategory.InterestPayment => "interest_payment",
                SourceCategory.InternalSource => "internal_source",
                SourceCategory.RealTimePaymentsTransferAcknowledgement =>
                    "real_time_payments_transfer_acknowledgement",
                SourceCategory.SampleFunds => "sample_funds",
                SourceCategory.WireTransferIntention => "wire_transfer_intention",
                SourceCategory.SwiftTransferIntention => "swift_transfer_intention",
                SourceCategory.SwiftTransferReturn => "swift_transfer_return",
                SourceCategory.CardPushTransferAcceptance => "card_push_transfer_acceptance",
                SourceCategory.AccountRevenuePayment => "account_revenue_payment",
                SourceCategory.BlockchainOnrampTransferIntention =>
                    "blockchain_onramp_transfer_intention",
                SourceCategory.BlockchainOfframpTransferSettlement =>
                    "blockchain_offramp_transfer_settlement",
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
/// An Account Revenue Payment object. This field will be present in the JSON response
/// if and only if `category` is equal to `account_revenue_payment`. An Account Revenue
/// Payment represents a payment made to an account from the bank. Account revenue
/// is a type of non-interest income.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccountRevenuePayment, AccountRevenuePaymentFromRaw>))]
public sealed record class AccountRevenuePayment : JsonModel
{
    /// <summary>
    /// The account on which the account revenue was accrued.
    /// </summary>
    public required string AccruedOnAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("accrued_on_account_id");
        }
        init { this._rawData.Set("accrued_on_account_id", value); }
    }

    /// <summary>
    /// The end of the period for which this transaction paid account revenue.
    /// </summary>
    public required System::DateTimeOffset PeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("period_end");
        }
        init { this._rawData.Set("period_end", value); }
    }

    /// <summary>
    /// The start of the period for which this transaction paid account revenue.
    /// </summary>
    public required System::DateTimeOffset PeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("period_start");
        }
        init { this._rawData.Set("period_start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccruedOnAccountID;
        _ = this.PeriodEnd;
        _ = this.PeriodStart;
    }

    public AccountRevenuePayment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountRevenuePayment(AccountRevenuePayment accountRevenuePayment)
        : base(accountRevenuePayment) { }
#pragma warning restore CS8618

    public AccountRevenuePayment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountRevenuePayment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountRevenuePaymentFromRaw.FromRawUnchecked"/>
    public static AccountRevenuePayment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountRevenuePaymentFromRaw : IFromRawJson<AccountRevenuePayment>
{
    /// <inheritdoc/>
    public AccountRevenuePayment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountRevenuePayment.FromRawUnchecked(rawData);
}

/// <summary>
/// An Account Transfer Intention object. This field will be present in the JSON response
/// if and only if `category` is equal to `account_transfer_intention`. Two Account
/// Transfer Intentions are created from each Account Transfer. One decrements the
/// source account, and the other increments the destination account.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AccountTransferIntention, AccountTransferIntentionFromRaw>)
)]
public sealed record class AccountTransferIntention : JsonModel
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
    public required ApiEnum<string, AccountTransferIntentionCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountTransferIntentionCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The description you chose to give the transfer.
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
    /// The identifier of the Account to where the Account Transfer was sent.
    /// </summary>
    public required string DestinationAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("destination_account_id");
        }
        init { this._rawData.Set("destination_account_id", value); }
    }

    /// <summary>
    /// The identifier of the Account from where the Account Transfer was sent.
    /// </summary>
    public required string SourceAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source_account_id");
        }
        init { this._rawData.Set("source_account_id", value); }
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
        _ = this.Description;
        _ = this.DestinationAccountID;
        _ = this.SourceAccountID;
        _ = this.TransferID;
    }

    public AccountTransferIntention() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountTransferIntention(AccountTransferIntention accountTransferIntention)
        : base(accountTransferIntention) { }
#pragma warning restore CS8618

    public AccountTransferIntention(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountTransferIntention(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountTransferIntentionFromRaw.FromRawUnchecked"/>
    public static AccountTransferIntention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountTransferIntentionFromRaw : IFromRawJson<AccountTransferIntention>
{
    /// <inheritdoc/>
    public AccountTransferIntention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountTransferIntention.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the destination
/// account currency.
/// </summary>
[JsonConverter(typeof(AccountTransferIntentionCurrencyConverter))]
public enum AccountTransferIntentionCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class AccountTransferIntentionCurrencyConverter
    : JsonConverter<AccountTransferIntentionCurrency>
{
    public override AccountTransferIntentionCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => AccountTransferIntentionCurrency.Usd,
            _ => (AccountTransferIntentionCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountTransferIntentionCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountTransferIntentionCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An ACH Transfer Intention object. This field will be present in the JSON response
/// if and only if `category` is equal to `ach_transfer_intention`. An ACH Transfer
/// Intention is created from an ACH Transfer. It reflects the intention to move money
/// into or out of an Increase account via the ACH network.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AchTransferIntention, AchTransferIntentionFromRaw>))]
public sealed record class AchTransferIntention : JsonModel
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
    /// The amount in the minor unit of the transaction's currency. For dollars,
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
    /// A description set when the ACH Transfer was created.
    /// </summary>
    public required string StatementDescriptor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("statement_descriptor");
        }
        init { this._rawData.Set("statement_descriptor", value); }
    }

    /// <summary>
    /// The identifier of the ACH Transfer that led to this Transaction.
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
        _ = this.RoutingNumber;
        _ = this.StatementDescriptor;
        _ = this.TransferID;
    }

    public AchTransferIntention() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferIntention(AchTransferIntention achTransferIntention)
        : base(achTransferIntention) { }
#pragma warning restore CS8618

    public AchTransferIntention(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AchTransferIntention(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AchTransferIntentionFromRaw.FromRawUnchecked"/>
    public static AchTransferIntention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AchTransferIntentionFromRaw : IFromRawJson<AchTransferIntention>
{
    /// <inheritdoc/>
    public AchTransferIntention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AchTransferIntention.FromRawUnchecked(rawData);
}

/// <summary>
/// An ACH Transfer Rejection object. This field will be present in the JSON response
/// if and only if `category` is equal to `ach_transfer_rejection`. An ACH Transfer
/// Rejection is created when an ACH Transfer is rejected by Increase. It offsets
/// the ACH Transfer Intention. These rejections are rare.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AchTransferRejection, AchTransferRejectionFromRaw>))]
public sealed record class AchTransferRejection : JsonModel
{
    /// <summary>
    /// The identifier of the ACH Transfer that led to this Transaction.
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

    public AchTransferRejection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferRejection(AchTransferRejection achTransferRejection)
        : base(achTransferRejection) { }
#pragma warning restore CS8618

    public AchTransferRejection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AchTransferRejection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AchTransferRejectionFromRaw.FromRawUnchecked"/>
    public static AchTransferRejection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AchTransferRejection(string transferID)
        : this()
    {
        this.TransferID = transferID;
    }
}

class AchTransferRejectionFromRaw : IFromRawJson<AchTransferRejection>
{
    /// <inheritdoc/>
    public AchTransferRejection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AchTransferRejection.FromRawUnchecked(rawData);
}

/// <summary>
/// An ACH Transfer Return object. This field will be present in the JSON response
/// if and only if `category` is equal to `ach_transfer_return`. An ACH Transfer
/// Return is created when an ACH Transfer is returned by the receiving bank. It
/// offsets the ACH Transfer Intention. ACH Transfer Returns usually occur within
/// the first two business days after the transfer is initiated, but can occur much later.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AchTransferReturn, AchTransferReturnFromRaw>))]
public sealed record class AchTransferReturn : JsonModel
{
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
    /// The three character ACH return code, in the range R01 to R85.
    /// </summary>
    public required string RawReturnReasonCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("raw_return_reason_code");
        }
        init { this._rawData.Set("raw_return_reason_code", value); }
    }

    /// <summary>
    /// Why the ACH Transfer was returned. This reason code is sent by the receiving
    /// bank back to Increase.
    /// </summary>
    public required ApiEnum<string, ReturnReasonCode> ReturnReasonCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ReturnReasonCode>>(
                "return_reason_code"
            );
        }
        init { this._rawData.Set("return_reason_code", value); }
    }

    /// <summary>
    /// A 15 digit number that was generated by the bank that initiated the return.
    /// The trace number of the return is different than that of the original transfer.
    /// ACH trace numbers are not unique, but along with the amount and date this
    /// number can be used to identify the ACH return at the bank that initiated it.
    /// </summary>
    public required string TraceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("trace_number");
        }
        init { this._rawData.Set("trace_number", value); }
    }

    /// <summary>
    /// The identifier of the Transaction associated with this return.
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

    /// <summary>
    /// The identifier of the ACH Transfer associated with this return.
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
        _ = this.CreatedAt;
        _ = this.RawReturnReasonCode;
        this.ReturnReasonCode.Validate();
        _ = this.TraceNumber;
        _ = this.TransactionID;
        _ = this.TransferID;
    }

    public AchTransferReturn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferReturn(AchTransferReturn achTransferReturn)
        : base(achTransferReturn) { }
#pragma warning restore CS8618

    public AchTransferReturn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AchTransferReturn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AchTransferReturnFromRaw.FromRawUnchecked"/>
    public static AchTransferReturn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AchTransferReturnFromRaw : IFromRawJson<AchTransferReturn>
{
    /// <inheritdoc/>
    public AchTransferReturn FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AchTransferReturn.FromRawUnchecked(rawData);
}

/// <summary>
/// Why the ACH Transfer was returned. This reason code is sent by the receiving
/// bank back to Increase.
/// </summary>
[JsonConverter(typeof(ReturnReasonCodeConverter))]
public enum ReturnReasonCode
{
    /// <summary>
    /// Code R01. Insufficient funds in the receiving account. Sometimes abbreviated
    /// to "NSF."
    /// </summary>
    InsufficientFund,

    /// <summary>
    /// Code R03. The account does not exist or the receiving bank was unable to
    /// locate it.
    /// </summary>
    NoAccount,

    /// <summary>
    /// Code R02. The account is closed at the receiving bank.
    /// </summary>
    AccountClosed,

    /// <summary>
    /// Code R04. The account number is invalid at the receiving bank.
    /// </summary>
    InvalidAccountNumberStructure,

    /// <summary>
    /// Code R16. This return code has two separate meanings. (1) The receiving bank
    /// froze the account or (2) the Office of Foreign Assets Control (OFAC) instructed
    /// the receiving bank to return the entry.
    /// </summary>
    AccountFrozenEntryReturnedPerOfacInstruction,

    /// <summary>
    /// Code R23. The receiving bank refused the credit transfer.
    /// </summary>
    CreditEntryRefusedByReceiver,

    /// <summary>
    /// Code R05. The receiving bank rejected because of an incorrect Standard Entry
    /// Class code. Consumer accounts cannot be debited as `corporate_credit_or_debit`
    /// or `corporate_trade_exchange`.
    /// </summary>
    UnauthorizedDebitToConsumerAccountUsingCorporateSecCode,

    /// <summary>
    /// Code R29. The corporate customer at the receiving bank reversed the transfer.
    /// </summary>
    CorporateCustomerAdvisedNotAuthorized,

    /// <summary>
    /// Code R08. The receiving bank stopped payment on this transfer.
    /// </summary>
    PaymentStopped,

    /// <summary>
    /// Code R20. The account is not eligible for ACH, such as a savings account
    /// with transaction limits.
    /// </summary>
    NonTransactionAccount,

    /// <summary>
    /// Code R09. The receiving bank account does not have enough available balance
    /// for the transfer.
    /// </summary>
    UncollectedFunds,

    /// <summary>
    /// Code R28. The routing number is incorrect.
    /// </summary>
    RoutingNumberCheckDigitError,

    /// <summary>
    /// Code R10. The customer at the receiving bank reversed the transfer.
    /// </summary>
    CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete,

    /// <summary>
    /// Code R19. The amount field is incorrect or too large.
    /// </summary>
    AmountFieldError,

    /// <summary>
    /// Code R07. The customer revoked their authorization for a previously authorized transfer.
    /// </summary>
    AuthorizationRevokedByCustomer,

    /// <summary>
    /// Code R13. The routing number is invalid.
    /// </summary>
    InvalidAchRoutingNumber,

    /// <summary>
    /// Code R17. The receiving bank is unable to process a field in the transfer.
    /// </summary>
    FileRecordEditCriteria,

    /// <summary>
    /// Code R45. A rare return reason. The individual name field was invalid.
    /// </summary>
    EnrInvalidIndividualName,

    /// <summary>
    /// Code R06. The originating financial institution asked for this transfer to
    /// be returned. The receiving bank is complying with the request.
    /// </summary>
    ReturnedPerOdfiRequest,

    /// <summary>
    /// Code R34. The receiving bank's regulatory supervisor has limited their participation
    /// in the ACH network.
    /// </summary>
    LimitedParticipationDfi,

    /// <summary>
    /// Code R85. The outbound international ACH transfer was incorrect.
    /// </summary>
    IncorrectlyCodedOutboundInternationalPayment,

    /// <summary>
    /// Code R12. A rare return reason. The account was sold to another bank.
    /// </summary>
    AccountSoldToAnotherDfi,

    /// <summary>
    /// Code R25. The addenda record is incorrect or missing.
    /// </summary>
    AddendaError,

    /// <summary>
    /// Code R15. A rare return reason. The account holder is deceased.
    /// </summary>
    BeneficiaryOrAccountHolderDeceased,

    /// <summary>
    /// Code R11. A rare return reason. The customer authorized some payment to the
    /// sender, but this payment was not in error.
    /// </summary>
    CustomerAdvisedNotWithinAuthorizationTerms,

    /// <summary>
    /// Code R74. A rare return reason. Sent in response to a return that was returned
    /// with code `field_error`. The latest return should include the corrected field(s).
    /// </summary>
    CorrectedReturn,

    /// <summary>
    /// Code R24. A rare return reason. The receiving bank received an exact duplicate
    /// entry with the same trace number and amount.
    /// </summary>
    DuplicateEntry,

    /// <summary>
    /// Code R67. A rare return reason. The return this message refers to was a duplicate.
    /// </summary>
    DuplicateReturn,

    /// <summary>
    /// Code R47. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrDuplicateEnrollment,

    /// <summary>
    /// Code R43. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrInvalidDfiAccountNumber,

    /// <summary>
    /// Code R44. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrInvalidIndividualIDNumber,

    /// <summary>
    /// Code R46. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrInvalidRepresentativePayeeIndicator,

    /// <summary>
    /// Code R41. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrInvalidTransactionCode,

    /// <summary>
    /// Code R40. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrReturnOfEnrEntry,

    /// <summary>
    /// Code R42. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrRoutingNumberCheckDigitError,

    /// <summary>
    /// Code R84. A rare return reason. The International ACH Transfer cannot be
    /// processed by the gateway.
    /// </summary>
    EntryNotProcessedByGateway,

    /// <summary>
    /// Code R69. A rare return reason. One or more of the fields in the ACH were malformed.
    /// </summary>
    FieldError,

    /// <summary>
    /// Code R83. A rare return reason. The Foreign receiving bank was unable to settle
    /// this ACH transfer.
    /// </summary>
    ForeignReceivingDfiUnableToSettle,

    /// <summary>
    /// Code R80. A rare return reason. The International ACH Transfer is malformed.
    /// </summary>
    IatEntryCodingError,

    /// <summary>
    /// Code R18. A rare return reason. The ACH has an improper effective entry date field.
    /// </summary>
    ImproperEffectiveEntryDate,

    /// <summary>
    /// Code R39. A rare return reason. The source document related to this ACH, usually
    /// an ACH check conversion, was presented to the bank.
    /// </summary>
    ImproperSourceDocumentSourceDocumentPresented,

    /// <summary>
    /// Code R21. A rare return reason. The Company ID field of the ACH was invalid.
    /// </summary>
    InvalidCompanyID,

    /// <summary>
    /// Code R82. A rare return reason. The foreign receiving bank identifier for
    /// an International ACH Transfer was invalid.
    /// </summary>
    InvalidForeignReceivingDfiIdentification,

    /// <summary>
    /// Code R22. A rare return reason. The Individual ID number field of the ACH
    /// was invalid.
    /// </summary>
    InvalidIndividualIDNumber,

    /// <summary>
    /// Code R53. A rare return reason. Both the Represented Check ("RCK") entry
    /// and the original check were presented to the bank.
    /// </summary>
    ItemAndRckEntryPresentedForPayment,

    /// <summary>
    /// Code R51. A rare return reason. The Represented Check ("RCK") entry is ineligible.
    /// </summary>
    ItemRelatedToRckEntryIsIneligible,

    /// <summary>
    /// Code R26. A rare return reason. The ACH is missing a required field.
    /// </summary>
    MandatoryFieldError,

    /// <summary>
    /// Code R71. A rare return reason. The receiving bank does not recognize the
    /// routing number in a dishonored return entry.
    /// </summary>
    MisroutedDishonoredReturn,

    /// <summary>
    /// Code R61. A rare return reason. The receiving bank does not recognize the
    /// routing number in a return entry.
    /// </summary>
    MisroutedReturn,

    /// <summary>
    /// Code R76. A rare return reason. Sent in response to a return, the bank does
    /// not find the errors alleged by the returning bank.
    /// </summary>
    NoErrorsFound,

    /// <summary>
    /// Code R77. A rare return reason. The receiving bank does not accept the return
    /// of the erroneous debit. The funds are not available at the receiving bank.
    /// </summary>
    NonAcceptanceOfR62DishonoredReturn,

    /// <summary>
    /// Code R81. A rare return reason. The receiving bank does not accept International
    /// ACH Transfers.
    /// </summary>
    NonParticipantInIatProgram,

    /// <summary>
    /// Code R31. A rare return reason. A return that has been agreed to be accepted
    /// by the receiving bank, despite falling outside of the usual return timeframe.
    /// </summary>
    PermissibleReturnEntry,

    /// <summary>
    /// Code R70. A rare return reason. The receiving bank had not approved this return.
    /// </summary>
    PermissibleReturnEntryNotAccepted,

    /// <summary>
    /// Code R32. A rare return reason. The receiving bank could not settle this transaction.
    /// </summary>
    RdfiNonSettlement,

    /// <summary>
    /// Code R30. A rare return reason. The receiving bank does not accept Check Truncation
    /// ACH transfers.
    /// </summary>
    RdfiParticipantInCheckTruncationProgram,

    /// <summary>
    /// Code R14. A rare return reason. The payee is deceased.
    /// </summary>
    RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity,

    /// <summary>
    /// Code R75. A rare return reason. The originating bank disputes that an earlier
    /// `duplicate_entry` return was actually a duplicate.
    /// </summary>
    ReturnNotADuplicate,

    /// <summary>
    /// Code R62. A rare return reason. The originating financial institution made
    /// a mistake and this return corrects it.
    /// </summary>
    ReturnOfErroneousOrReversingDebit,

    /// <summary>
    /// Code R36. A rare return reason. Return of a malformed credit entry.
    /// </summary>
    ReturnOfImproperCreditEntry,

    /// <summary>
    /// Code R35. A rare return reason. Return of a malformed debit entry.
    /// </summary>
    ReturnOfImproperDebitEntry,

    /// <summary>
    /// Code R33. A rare return reason. Return of a destroyed check ("XCK") entry.
    /// </summary>
    ReturnOfXckEntry,

    /// <summary>
    /// Code R37. A rare return reason. The source document related to this ACH, usually
    /// an ACH check conversion, was presented to the bank.
    /// </summary>
    SourceDocumentPresentedForPayment,

    /// <summary>
    /// Code R50. A rare return reason. State law prevents the bank from accepting
    /// the Represented Check ("RCK") entry.
    /// </summary>
    StateLawAffectingRckAcceptance,

    /// <summary>
    /// Code R52. A rare return reason. A stop payment was issued on a Represented
    /// Check ("RCK") entry.
    /// </summary>
    StopPaymentOnItemRelatedToRckEntry,

    /// <summary>
    /// Code R38. A rare return reason. The source attached to the ACH, usually an
    /// ACH check conversion, includes a stop payment.
    /// </summary>
    StopPaymentOnSourceDocument,

    /// <summary>
    /// Code R73. A rare return reason. The bank receiving an `untimely_return` believes
    /// it was on time.
    /// </summary>
    TimelyOriginalReturn,

    /// <summary>
    /// Code R27. A rare return reason. An ACH return's trace number does not match
    /// an originated ACH.
    /// </summary>
    TraceNumberError,

    /// <summary>
    /// Code R72. A rare return reason. The dishonored return was sent too late.
    /// </summary>
    UntimelyDishonoredReturn,

    /// <summary>
    /// Code R68. A rare return reason. The return was sent too late.
    /// </summary>
    UntimelyReturn,
}

sealed class ReturnReasonCodeConverter : JsonConverter<ReturnReasonCode>
{
    public override ReturnReasonCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_fund" => ReturnReasonCode.InsufficientFund,
            "no_account" => ReturnReasonCode.NoAccount,
            "account_closed" => ReturnReasonCode.AccountClosed,
            "invalid_account_number_structure" => ReturnReasonCode.InvalidAccountNumberStructure,
            "account_frozen_entry_returned_per_ofac_instruction" =>
                ReturnReasonCode.AccountFrozenEntryReturnedPerOfacInstruction,
            "credit_entry_refused_by_receiver" => ReturnReasonCode.CreditEntryRefusedByReceiver,
            "unauthorized_debit_to_consumer_account_using_corporate_sec_code" =>
                ReturnReasonCode.UnauthorizedDebitToConsumerAccountUsingCorporateSecCode,
            "corporate_customer_advised_not_authorized" =>
                ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized,
            "payment_stopped" => ReturnReasonCode.PaymentStopped,
            "non_transaction_account" => ReturnReasonCode.NonTransactionAccount,
            "uncollected_funds" => ReturnReasonCode.UncollectedFunds,
            "routing_number_check_digit_error" => ReturnReasonCode.RoutingNumberCheckDigitError,
            "customer_advised_unauthorized_improper_ineligible_or_incomplete" =>
                ReturnReasonCode.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete,
            "amount_field_error" => ReturnReasonCode.AmountFieldError,
            "authorization_revoked_by_customer" => ReturnReasonCode.AuthorizationRevokedByCustomer,
            "invalid_ach_routing_number" => ReturnReasonCode.InvalidAchRoutingNumber,
            "file_record_edit_criteria" => ReturnReasonCode.FileRecordEditCriteria,
            "enr_invalid_individual_name" => ReturnReasonCode.EnrInvalidIndividualName,
            "returned_per_odfi_request" => ReturnReasonCode.ReturnedPerOdfiRequest,
            "limited_participation_dfi" => ReturnReasonCode.LimitedParticipationDfi,
            "incorrectly_coded_outbound_international_payment" =>
                ReturnReasonCode.IncorrectlyCodedOutboundInternationalPayment,
            "account_sold_to_another_dfi" => ReturnReasonCode.AccountSoldToAnotherDfi,
            "addenda_error" => ReturnReasonCode.AddendaError,
            "beneficiary_or_account_holder_deceased" =>
                ReturnReasonCode.BeneficiaryOrAccountHolderDeceased,
            "customer_advised_not_within_authorization_terms" =>
                ReturnReasonCode.CustomerAdvisedNotWithinAuthorizationTerms,
            "corrected_return" => ReturnReasonCode.CorrectedReturn,
            "duplicate_entry" => ReturnReasonCode.DuplicateEntry,
            "duplicate_return" => ReturnReasonCode.DuplicateReturn,
            "enr_duplicate_enrollment" => ReturnReasonCode.EnrDuplicateEnrollment,
            "enr_invalid_dfi_account_number" => ReturnReasonCode.EnrInvalidDfiAccountNumber,
            "enr_invalid_individual_id_number" => ReturnReasonCode.EnrInvalidIndividualIDNumber,
            "enr_invalid_representative_payee_indicator" =>
                ReturnReasonCode.EnrInvalidRepresentativePayeeIndicator,
            "enr_invalid_transaction_code" => ReturnReasonCode.EnrInvalidTransactionCode,
            "enr_return_of_enr_entry" => ReturnReasonCode.EnrReturnOfEnrEntry,
            "enr_routing_number_check_digit_error" =>
                ReturnReasonCode.EnrRoutingNumberCheckDigitError,
            "entry_not_processed_by_gateway" => ReturnReasonCode.EntryNotProcessedByGateway,
            "field_error" => ReturnReasonCode.FieldError,
            "foreign_receiving_dfi_unable_to_settle" =>
                ReturnReasonCode.ForeignReceivingDfiUnableToSettle,
            "iat_entry_coding_error" => ReturnReasonCode.IatEntryCodingError,
            "improper_effective_entry_date" => ReturnReasonCode.ImproperEffectiveEntryDate,
            "improper_source_document_source_document_presented" =>
                ReturnReasonCode.ImproperSourceDocumentSourceDocumentPresented,
            "invalid_company_id" => ReturnReasonCode.InvalidCompanyID,
            "invalid_foreign_receiving_dfi_identification" =>
                ReturnReasonCode.InvalidForeignReceivingDfiIdentification,
            "invalid_individual_id_number" => ReturnReasonCode.InvalidIndividualIDNumber,
            "item_and_rck_entry_presented_for_payment" =>
                ReturnReasonCode.ItemAndRckEntryPresentedForPayment,
            "item_related_to_rck_entry_is_ineligible" =>
                ReturnReasonCode.ItemRelatedToRckEntryIsIneligible,
            "mandatory_field_error" => ReturnReasonCode.MandatoryFieldError,
            "misrouted_dishonored_return" => ReturnReasonCode.MisroutedDishonoredReturn,
            "misrouted_return" => ReturnReasonCode.MisroutedReturn,
            "no_errors_found" => ReturnReasonCode.NoErrorsFound,
            "non_acceptance_of_r62_dishonored_return" =>
                ReturnReasonCode.NonAcceptanceOfR62DishonoredReturn,
            "non_participant_in_iat_program" => ReturnReasonCode.NonParticipantInIatProgram,
            "permissible_return_entry" => ReturnReasonCode.PermissibleReturnEntry,
            "permissible_return_entry_not_accepted" =>
                ReturnReasonCode.PermissibleReturnEntryNotAccepted,
            "rdfi_non_settlement" => ReturnReasonCode.RdfiNonSettlement,
            "rdfi_participant_in_check_truncation_program" =>
                ReturnReasonCode.RdfiParticipantInCheckTruncationProgram,
            "representative_payee_deceased_or_unable_to_continue_in_that_capacity" =>
                ReturnReasonCode.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity,
            "return_not_a_duplicate" => ReturnReasonCode.ReturnNotADuplicate,
            "return_of_erroneous_or_reversing_debit" =>
                ReturnReasonCode.ReturnOfErroneousOrReversingDebit,
            "return_of_improper_credit_entry" => ReturnReasonCode.ReturnOfImproperCreditEntry,
            "return_of_improper_debit_entry" => ReturnReasonCode.ReturnOfImproperDebitEntry,
            "return_of_xck_entry" => ReturnReasonCode.ReturnOfXckEntry,
            "source_document_presented_for_payment" =>
                ReturnReasonCode.SourceDocumentPresentedForPayment,
            "state_law_affecting_rck_acceptance" => ReturnReasonCode.StateLawAffectingRckAcceptance,
            "stop_payment_on_item_related_to_rck_entry" =>
                ReturnReasonCode.StopPaymentOnItemRelatedToRckEntry,
            "stop_payment_on_source_document" => ReturnReasonCode.StopPaymentOnSourceDocument,
            "timely_original_return" => ReturnReasonCode.TimelyOriginalReturn,
            "trace_number_error" => ReturnReasonCode.TraceNumberError,
            "untimely_dishonored_return" => ReturnReasonCode.UntimelyDishonoredReturn,
            "untimely_return" => ReturnReasonCode.UntimelyReturn,
            _ => (ReturnReasonCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReturnReasonCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReturnReasonCode.InsufficientFund => "insufficient_fund",
                ReturnReasonCode.NoAccount => "no_account",
                ReturnReasonCode.AccountClosed => "account_closed",
                ReturnReasonCode.InvalidAccountNumberStructure =>
                    "invalid_account_number_structure",
                ReturnReasonCode.AccountFrozenEntryReturnedPerOfacInstruction =>
                    "account_frozen_entry_returned_per_ofac_instruction",
                ReturnReasonCode.CreditEntryRefusedByReceiver => "credit_entry_refused_by_receiver",
                ReturnReasonCode.UnauthorizedDebitToConsumerAccountUsingCorporateSecCode =>
                    "unauthorized_debit_to_consumer_account_using_corporate_sec_code",
                ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized =>
                    "corporate_customer_advised_not_authorized",
                ReturnReasonCode.PaymentStopped => "payment_stopped",
                ReturnReasonCode.NonTransactionAccount => "non_transaction_account",
                ReturnReasonCode.UncollectedFunds => "uncollected_funds",
                ReturnReasonCode.RoutingNumberCheckDigitError => "routing_number_check_digit_error",
                ReturnReasonCode.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete =>
                    "customer_advised_unauthorized_improper_ineligible_or_incomplete",
                ReturnReasonCode.AmountFieldError => "amount_field_error",
                ReturnReasonCode.AuthorizationRevokedByCustomer =>
                    "authorization_revoked_by_customer",
                ReturnReasonCode.InvalidAchRoutingNumber => "invalid_ach_routing_number",
                ReturnReasonCode.FileRecordEditCriteria => "file_record_edit_criteria",
                ReturnReasonCode.EnrInvalidIndividualName => "enr_invalid_individual_name",
                ReturnReasonCode.ReturnedPerOdfiRequest => "returned_per_odfi_request",
                ReturnReasonCode.LimitedParticipationDfi => "limited_participation_dfi",
                ReturnReasonCode.IncorrectlyCodedOutboundInternationalPayment =>
                    "incorrectly_coded_outbound_international_payment",
                ReturnReasonCode.AccountSoldToAnotherDfi => "account_sold_to_another_dfi",
                ReturnReasonCode.AddendaError => "addenda_error",
                ReturnReasonCode.BeneficiaryOrAccountHolderDeceased =>
                    "beneficiary_or_account_holder_deceased",
                ReturnReasonCode.CustomerAdvisedNotWithinAuthorizationTerms =>
                    "customer_advised_not_within_authorization_terms",
                ReturnReasonCode.CorrectedReturn => "corrected_return",
                ReturnReasonCode.DuplicateEntry => "duplicate_entry",
                ReturnReasonCode.DuplicateReturn => "duplicate_return",
                ReturnReasonCode.EnrDuplicateEnrollment => "enr_duplicate_enrollment",
                ReturnReasonCode.EnrInvalidDfiAccountNumber => "enr_invalid_dfi_account_number",
                ReturnReasonCode.EnrInvalidIndividualIDNumber => "enr_invalid_individual_id_number",
                ReturnReasonCode.EnrInvalidRepresentativePayeeIndicator =>
                    "enr_invalid_representative_payee_indicator",
                ReturnReasonCode.EnrInvalidTransactionCode => "enr_invalid_transaction_code",
                ReturnReasonCode.EnrReturnOfEnrEntry => "enr_return_of_enr_entry",
                ReturnReasonCode.EnrRoutingNumberCheckDigitError =>
                    "enr_routing_number_check_digit_error",
                ReturnReasonCode.EntryNotProcessedByGateway => "entry_not_processed_by_gateway",
                ReturnReasonCode.FieldError => "field_error",
                ReturnReasonCode.ForeignReceivingDfiUnableToSettle =>
                    "foreign_receiving_dfi_unable_to_settle",
                ReturnReasonCode.IatEntryCodingError => "iat_entry_coding_error",
                ReturnReasonCode.ImproperEffectiveEntryDate => "improper_effective_entry_date",
                ReturnReasonCode.ImproperSourceDocumentSourceDocumentPresented =>
                    "improper_source_document_source_document_presented",
                ReturnReasonCode.InvalidCompanyID => "invalid_company_id",
                ReturnReasonCode.InvalidForeignReceivingDfiIdentification =>
                    "invalid_foreign_receiving_dfi_identification",
                ReturnReasonCode.InvalidIndividualIDNumber => "invalid_individual_id_number",
                ReturnReasonCode.ItemAndRckEntryPresentedForPayment =>
                    "item_and_rck_entry_presented_for_payment",
                ReturnReasonCode.ItemRelatedToRckEntryIsIneligible =>
                    "item_related_to_rck_entry_is_ineligible",
                ReturnReasonCode.MandatoryFieldError => "mandatory_field_error",
                ReturnReasonCode.MisroutedDishonoredReturn => "misrouted_dishonored_return",
                ReturnReasonCode.MisroutedReturn => "misrouted_return",
                ReturnReasonCode.NoErrorsFound => "no_errors_found",
                ReturnReasonCode.NonAcceptanceOfR62DishonoredReturn =>
                    "non_acceptance_of_r62_dishonored_return",
                ReturnReasonCode.NonParticipantInIatProgram => "non_participant_in_iat_program",
                ReturnReasonCode.PermissibleReturnEntry => "permissible_return_entry",
                ReturnReasonCode.PermissibleReturnEntryNotAccepted =>
                    "permissible_return_entry_not_accepted",
                ReturnReasonCode.RdfiNonSettlement => "rdfi_non_settlement",
                ReturnReasonCode.RdfiParticipantInCheckTruncationProgram =>
                    "rdfi_participant_in_check_truncation_program",
                ReturnReasonCode.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity =>
                    "representative_payee_deceased_or_unable_to_continue_in_that_capacity",
                ReturnReasonCode.ReturnNotADuplicate => "return_not_a_duplicate",
                ReturnReasonCode.ReturnOfErroneousOrReversingDebit =>
                    "return_of_erroneous_or_reversing_debit",
                ReturnReasonCode.ReturnOfImproperCreditEntry => "return_of_improper_credit_entry",
                ReturnReasonCode.ReturnOfImproperDebitEntry => "return_of_improper_debit_entry",
                ReturnReasonCode.ReturnOfXckEntry => "return_of_xck_entry",
                ReturnReasonCode.SourceDocumentPresentedForPayment =>
                    "source_document_presented_for_payment",
                ReturnReasonCode.StateLawAffectingRckAcceptance =>
                    "state_law_affecting_rck_acceptance",
                ReturnReasonCode.StopPaymentOnItemRelatedToRckEntry =>
                    "stop_payment_on_item_related_to_rck_entry",
                ReturnReasonCode.StopPaymentOnSourceDocument => "stop_payment_on_source_document",
                ReturnReasonCode.TimelyOriginalReturn => "timely_original_return",
                ReturnReasonCode.TraceNumberError => "trace_number_error",
                ReturnReasonCode.UntimelyDishonoredReturn => "untimely_dishonored_return",
                ReturnReasonCode.UntimelyReturn => "untimely_return",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Blockchain Off-Ramp Transfer Settlement object. This field will be present in
/// the JSON response if and only if `category` is equal to `blockchain_offramp_transfer_settlement`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BlockchainOfframpTransferSettlement,
        BlockchainOfframpTransferSettlementFromRaw
    >)
)]
public sealed record class BlockchainOfframpTransferSettlement : JsonModel
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

    public BlockchainOfframpTransferSettlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BlockchainOfframpTransferSettlement(
        BlockchainOfframpTransferSettlement blockchainOfframpTransferSettlement
    )
        : base(blockchainOfframpTransferSettlement) { }
#pragma warning restore CS8618

    public BlockchainOfframpTransferSettlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BlockchainOfframpTransferSettlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlockchainOfframpTransferSettlementFromRaw.FromRawUnchecked"/>
    public static BlockchainOfframpTransferSettlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BlockchainOfframpTransferSettlementFromRaw : IFromRawJson<BlockchainOfframpTransferSettlement>
{
    /// <inheritdoc/>
    public BlockchainOfframpTransferSettlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BlockchainOfframpTransferSettlement.FromRawUnchecked(rawData);
}

/// <summary>
/// A Blockchain On-Ramp Transfer Intention object. This field will be present in
/// the JSON response if and only if `category` is equal to `blockchain_onramp_transfer_intention`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BlockchainOnrampTransferIntention,
        BlockchainOnrampTransferIntentionFromRaw
    >)
)]
public sealed record class BlockchainOnrampTransferIntention : JsonModel
{
    /// <summary>
    /// The blockchain address the funds were sent to.
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
    /// The identifier of the Blockchain On-Ramp Transfer that led to this Transaction.
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
        _ = this.DestinationBlockchainAddress;
        _ = this.TransferID;
    }

    public BlockchainOnrampTransferIntention() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BlockchainOnrampTransferIntention(
        BlockchainOnrampTransferIntention blockchainOnrampTransferIntention
    )
        : base(blockchainOnrampTransferIntention) { }
#pragma warning restore CS8618

    public BlockchainOnrampTransferIntention(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BlockchainOnrampTransferIntention(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlockchainOnrampTransferIntentionFromRaw.FromRawUnchecked"/>
    public static BlockchainOnrampTransferIntention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BlockchainOnrampTransferIntentionFromRaw : IFromRawJson<BlockchainOnrampTransferIntention>
{
    /// <inheritdoc/>
    public BlockchainOnrampTransferIntention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BlockchainOnrampTransferIntention.FromRawUnchecked(rawData);
}

/// <summary>
/// A Legacy Card Dispute Acceptance object. This field will be present in the JSON
/// response if and only if `category` is equal to `card_dispute_acceptance`. Contains
/// the details of a successful Card Dispute.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardDisputeAcceptance, CardDisputeAcceptanceFromRaw>))]
public sealed record class CardDisputeAcceptance : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Card Dispute was accepted.
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
    /// The identifier of the Transaction that was created to return the disputed
    /// funds to your account.
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

    public CardDisputeAcceptance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDisputeAcceptance(CardDisputeAcceptance cardDisputeAcceptance)
        : base(cardDisputeAcceptance) { }
#pragma warning restore CS8618

    public CardDisputeAcceptance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDisputeAcceptance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDisputeAcceptanceFromRaw.FromRawUnchecked"/>
    public static CardDisputeAcceptance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDisputeAcceptanceFromRaw : IFromRawJson<CardDisputeAcceptance>
{
    /// <inheritdoc/>
    public CardDisputeAcceptance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDisputeAcceptance.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Dispute Financial object. This field will be present in the JSON response
/// if and only if `category` is equal to `card_dispute_financial`. Financial event
/// related to a Card Dispute.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardDisputeFinancial, CardDisputeFinancialFromRaw>))]
public sealed record class CardDisputeFinancial : JsonModel
{
    /// <summary>
    /// The amount of the financial event.
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
    /// The network that the Card Dispute is associated with.
    /// </summary>
    public required ApiEnum<string, Network> Network
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Network>>("network");
        }
        init { this._rawData.Set("network", value); }
    }

    /// <summary>
    /// The identifier of the Transaction that was created to credit or debit the
    /// disputed funds to or from your account.
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

    /// <summary>
    /// Information for events related to card dispute for card payments processed
    /// over Visa's network. This field will be present in the JSON response if and
    /// only if `network` is equal to `visa`.
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
        _ = this.Amount;
        this.Network.Validate();
        _ = this.TransactionID;
        this.Visa?.Validate();
    }

    public CardDisputeFinancial() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDisputeFinancial(CardDisputeFinancial cardDisputeFinancial)
        : base(cardDisputeFinancial) { }
#pragma warning restore CS8618

    public CardDisputeFinancial(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDisputeFinancial(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDisputeFinancialFromRaw.FromRawUnchecked"/>
    public static CardDisputeFinancial FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDisputeFinancialFromRaw : IFromRawJson<CardDisputeFinancial>
{
    /// <inheritdoc/>
    public CardDisputeFinancial FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDisputeFinancial.FromRawUnchecked(rawData);
}

/// <summary>
/// The network that the Card Dispute is associated with.
/// </summary>
[JsonConverter(typeof(NetworkConverter))]
public enum Network
{
    /// <summary>
    /// Visa: details will be under the `visa` object.
    /// </summary>
    Visa,

    /// <summary>
    /// Pulse: details will be under the `pulse` object.
    /// </summary>
    Pulse,
}

sealed class NetworkConverter : JsonConverter<Network>
{
    public override Network Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => Network.Visa,
            "pulse" => Network.Pulse,
            _ => (Network)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Network value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Network.Visa => "visa",
                Network.Pulse => "pulse",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Information for events related to card dispute for card payments processed over
/// Visa's network. This field will be present in the JSON response if and only if
/// `network` is equal to `visa`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Visa, VisaFromRaw>))]
public sealed record class Visa : JsonModel
{
    /// <summary>
    /// The type of card dispute financial event.
    /// </summary>
    public required ApiEnum<string, EventType> EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventType>>("event_type");
        }
        init { this._rawData.Set("event_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.EventType.Validate();
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

    [SetsRequiredMembers]
    public Visa(ApiEnum<string, EventType> eventType)
        : this()
    {
        this.EventType = eventType;
    }
}

class VisaFromRaw : IFromRawJson<Visa>
{
    /// <inheritdoc/>
    public Visa FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Visa.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of card dispute financial event.
/// </summary>
[JsonConverter(typeof(EventTypeConverter))]
public enum EventType
{
    /// <summary>
    /// The user's chargeback was submitted.
    /// </summary>
    ChargebackSubmitted,

    /// <summary>
    /// The user declined the merchant's pre-arbitration submission.
    /// </summary>
    MerchantPrearbitrationDeclineSubmitted,

    /// <summary>
    /// The merchant's pre-arbitration submission was received.
    /// </summary>
    MerchantPrearbitrationReceived,

    /// <summary>
    /// The transaction was re-presented by the merchant.
    /// </summary>
    Represented,

    /// <summary>
    /// The user's pre-arbitration was declined by the merchant.
    /// </summary>
    UserPrearbitrationDeclineReceived,

    /// <summary>
    /// The user's pre-arbitration was submitted.
    /// </summary>
    UserPrearbitrationSubmitted,

    /// <summary>
    /// The user withdrew from the dispute.
    /// </summary>
    UserWithdrawalSubmitted,
}

sealed class EventTypeConverter : JsonConverter<EventType>
{
    public override EventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "chargeback_submitted" => EventType.ChargebackSubmitted,
            "merchant_prearbitration_decline_submitted" =>
                EventType.MerchantPrearbitrationDeclineSubmitted,
            "merchant_prearbitration_received" => EventType.MerchantPrearbitrationReceived,
            "represented" => EventType.Represented,
            "user_prearbitration_decline_received" => EventType.UserPrearbitrationDeclineReceived,
            "user_prearbitration_submitted" => EventType.UserPrearbitrationSubmitted,
            "user_withdrawal_submitted" => EventType.UserWithdrawalSubmitted,
            _ => (EventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventType.ChargebackSubmitted => "chargeback_submitted",
                EventType.MerchantPrearbitrationDeclineSubmitted =>
                    "merchant_prearbitration_decline_submitted",
                EventType.MerchantPrearbitrationReceived => "merchant_prearbitration_received",
                EventType.Represented => "represented",
                EventType.UserPrearbitrationDeclineReceived =>
                    "user_prearbitration_decline_received",
                EventType.UserPrearbitrationSubmitted => "user_prearbitration_submitted",
                EventType.UserWithdrawalSubmitted => "user_withdrawal_submitted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Legacy Card Dispute Loss object. This field will be present in the JSON response
/// if and only if `category` is equal to `card_dispute_loss`. Contains the details
/// of a lost Card Dispute.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardDisputeLoss, CardDisputeLossFromRaw>))]
public sealed record class CardDisputeLoss : JsonModel
{
    /// <summary>
    /// Why the Card Dispute was lost.
    /// </summary>
    public required string Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Card Dispute was lost.
    /// </summary>
    public required System::DateTimeOffset LostAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("lost_at");
        }
        init { this._rawData.Set("lost_at", value); }
    }

    /// <summary>
    /// The identifier of the Transaction that was created to debit the disputed
    /// funds from your account.
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
        _ = this.Explanation;
        _ = this.LostAt;
        _ = this.TransactionID;
    }

    public CardDisputeLoss() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDisputeLoss(CardDisputeLoss cardDisputeLoss)
        : base(cardDisputeLoss) { }
#pragma warning restore CS8618

    public CardDisputeLoss(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDisputeLoss(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDisputeLossFromRaw.FromRawUnchecked"/>
    public static CardDisputeLoss FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDisputeLossFromRaw : IFromRawJson<CardDisputeLoss>
{
    /// <inheritdoc/>
    public CardDisputeLoss FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardDisputeLoss.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Financial object. This field will be present in the JSON response if and
/// only if `category` is equal to `card_financial`. Card Financials are temporary
/// holds placed on a customer's funds with the intent to later clear a transaction.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardFinancial, CardFinancialFromRaw>))]
public sealed record class CardFinancial : JsonModel
{
    /// <summary>
    /// The Card Financial identifier.
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
    /// Whether this financial was approved by Increase, the card network through
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
    public required ApiEnum<string, CardFinancialCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardFinancialCurrency>>(
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
    /// The processing category describes the intent behind the financial, such as
    /// whether it was used for bill payments or an automatic fuel dispenser.
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
    /// The scheme fees associated with this card financial.
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
    /// The identifier of the Transaction associated with this Transaction.
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

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `card_financial`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.Transactions.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.Transactions.Type>
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
        _ = this.TransactionID;
        this.Type.Validate();
        this.Verification.Validate();
    }

    public CardFinancial() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancial(CardFinancial cardFinancial)
        : base(cardFinancial) { }
#pragma warning restore CS8618

    public CardFinancial(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancial(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialFromRaw.FromRawUnchecked"/>
    public static CardFinancial FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialFromRaw : IFromRawJson<CardFinancial>
{
    /// <inheritdoc/>
    public CardFinancial FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardFinancial.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether this financial was approved by Increase, the card network through stand-in
/// processing, or the user through a real-time decision.
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
[JsonConverter(typeof(CardFinancialCurrencyConverter))]
public enum CardFinancialCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardFinancialCurrencyConverter : JsonConverter<CardFinancialCurrency>
{
    public override CardFinancialCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardFinancialCurrency.Usd,
            _ => (CardFinancialCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardFinancialCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardFinancialCurrency.Usd => "USD",
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
    public required NetworkDetailsVisa? Visa
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NetworkDetailsVisa>("visa");
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
[JsonConverter(typeof(JsonModelConverter<NetworkDetailsVisa, NetworkDetailsVisaFromRaw>))]
public sealed record class NetworkDetailsVisa : JsonModel
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

    public NetworkDetailsVisa() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkDetailsVisa(NetworkDetailsVisa networkDetailsVisa)
        : base(networkDetailsVisa) { }
#pragma warning restore CS8618

    public NetworkDetailsVisa(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkDetailsVisa(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NetworkDetailsVisaFromRaw.FromRawUnchecked"/>
    public static NetworkDetailsVisa FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NetworkDetailsVisaFromRaw : IFromRawJson<NetworkDetailsVisa>
{
    /// <inheritdoc/>
    public NetworkDetailsVisa FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NetworkDetailsVisa.FromRawUnchecked(rawData);
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
/// The processing category describes the intent behind the financial, such as whether
/// it was used for bill payments or an automatic fuel dispenser.
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
/// A constant representing the object's type. For this resource it will always be `card_financial`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    CardFinancial,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.Transactions.Type>
{
    public override global::Increase.Api.Models.Transactions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_financial" => global::Increase.Api.Models.Transactions.Type.CardFinancial,
            _ => (global::Increase.Api.Models.Transactions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.Transactions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.Transactions.Type.CardFinancial => "card_financial",
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
/// A Card Push Transfer Acceptance object. This field will be present in the JSON
/// response if and only if `category` is equal to `card_push_transfer_acceptance`.
/// A Card Push Transfer Acceptance is created when an Outbound Card Push Transfer
/// sent from Increase is accepted by the receiving bank.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CardPushTransferAcceptance, CardPushTransferAcceptanceFromRaw>)
)]
public sealed record class CardPushTransferAcceptance : JsonModel
{
    /// <summary>
    /// The transfer amount in USD cents.
    /// </summary>
    public required long SettlementAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("settlement_amount");
        }
        init { this._rawData.Set("settlement_amount", value); }
    }

    /// <summary>
    /// The identifier of the Card Push Transfer that led to this Transaction.
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
        _ = this.SettlementAmount;
        _ = this.TransferID;
    }

    public CardPushTransferAcceptance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardPushTransferAcceptance(CardPushTransferAcceptance cardPushTransferAcceptance)
        : base(cardPushTransferAcceptance) { }
#pragma warning restore CS8618

    public CardPushTransferAcceptance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardPushTransferAcceptance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardPushTransferAcceptanceFromRaw.FromRawUnchecked"/>
    public static CardPushTransferAcceptance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardPushTransferAcceptanceFromRaw : IFromRawJson<CardPushTransferAcceptance>
{
    /// <inheritdoc/>
    public CardPushTransferAcceptance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardPushTransferAcceptance.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Refund object. This field will be present in the JSON response if and only
/// if `category` is equal to `card_refund`. Card Refunds move money back to the cardholder.
/// While they are usually connected to a Card Settlement, an acquirer can also refund
/// money directly to a card without relation to a transaction.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardRefund, CardRefundFromRaw>))]
public sealed record class CardRefund : JsonModel
{
    /// <summary>
    /// The Card Refund identifier.
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
    /// The amount in the minor unit of the transaction's settlement currency. For
    /// dollars, for example, this is cents.
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
    /// Cashback debited for this transaction, if eligible. Cashback is paid out in
    /// aggregate, monthly.
    /// </summary>
    public required Cashback? Cashback
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Cashback>("cashback");
        }
        init { this._rawData.Set("cashback", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's
    /// settlement currency.
    /// </summary>
    public required ApiEnum<string, CardRefundCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardRefundCurrency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Interchange assessed as a part of this transaction.
    /// </summary>
    public required Interchange? Interchange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Interchange>("interchange");
        }
        init { this._rawData.Set("interchange", value); }
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
    /// The 4-digit MCC describing the merchant's business.
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
    public required string MerchantCity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_city");
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
    /// The name of the merchant.
    /// </summary>
    public required string MerchantName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_name");
        }
        init { this._rawData.Set("merchant_name", value); }
    }

    /// <summary>
    /// The merchant's postal code. For US merchants this is always a 5-digit ZIP code.
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
    /// Network-specific identifiers for this refund.
    /// </summary>
    public required CardRefundNetworkIdentifiers NetworkIdentifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardRefundNetworkIdentifiers>(
                "network_identifiers"
            );
        }
        init { this._rawData.Set("network_identifiers", value); }
    }

    /// <summary>
    /// The amount in the minor unit of the transaction's presentment currency.
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
    /// Additional details about the card purchase, such as tax and industry-specific fields.
    /// </summary>
    public required PurchaseDetails? PurchaseDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PurchaseDetails>("purchase_details");
        }
        init { this._rawData.Set("purchase_details", value); }
    }

    /// <summary>
    /// The scheme fees associated with this card refund.
    /// </summary>
    public required IReadOnlyList<CardRefundSchemeFee> SchemeFees
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CardRefundSchemeFee>>(
                "scheme_fees"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardRefundSchemeFee>>(
                "scheme_fees",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The identifier of the Transaction associated with this Transaction.
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

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `card_refund`.
    /// </summary>
    public required ApiEnum<string, CardRefundType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardRefundType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.CardPaymentID;
        this.Cashback?.Validate();
        this.Currency.Validate();
        this.Interchange?.Validate();
        _ = this.MerchantAcceptorID;
        _ = this.MerchantCategoryCode;
        _ = this.MerchantCity;
        _ = this.MerchantCountry;
        _ = this.MerchantName;
        _ = this.MerchantPostalCode;
        _ = this.MerchantState;
        this.NetworkIdentifiers.Validate();
        _ = this.PresentmentAmount;
        _ = this.PresentmentCurrency;
        this.PurchaseDetails?.Validate();
        foreach (var item in this.SchemeFees)
        {
            item.Validate();
        }
        _ = this.TransactionID;
        this.Type.Validate();
    }

    public CardRefund() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardRefund(CardRefund cardRefund)
        : base(cardRefund) { }
#pragma warning restore CS8618

    public CardRefund(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardRefund(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardRefundFromRaw.FromRawUnchecked"/>
    public static CardRefund FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardRefundFromRaw : IFromRawJson<CardRefund>
{
    /// <inheritdoc/>
    public CardRefund FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardRefund.FromRawUnchecked(rawData);
}

/// <summary>
/// Cashback debited for this transaction, if eligible. Cashback is paid out in aggregate, monthly.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Cashback, CashbackFromRaw>))]
public sealed record class Cashback : JsonModel
{
    /// <summary>
    /// The cashback amount given as a string containing a decimal number. The amount
    /// is a positive number if it will be credited to you (e.g., settlements) and
    /// a negative number if it will be debited (e.g., refunds).
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the cashback.
    /// </summary>
    public required ApiEnum<string, CashbackCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CashbackCurrency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
    }

    public Cashback() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cashback(Cashback cashback)
        : base(cashback) { }
#pragma warning restore CS8618

    public Cashback(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Cashback(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CashbackFromRaw.FromRawUnchecked"/>
    public static Cashback FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CashbackFromRaw : IFromRawJson<Cashback>
{
    /// <inheritdoc/>
    public Cashback FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Cashback.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the cashback.
/// </summary>
[JsonConverter(typeof(CashbackCurrencyConverter))]
public enum CashbackCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CashbackCurrencyConverter : JsonConverter<CashbackCurrency>
{
    public override CashbackCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CashbackCurrency.Usd,
            _ => (CashbackCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CashbackCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CashbackCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's
/// settlement currency.
/// </summary>
[JsonConverter(typeof(CardRefundCurrencyConverter))]
public enum CardRefundCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardRefundCurrencyConverter : JsonConverter<CardRefundCurrency>
{
    public override CardRefundCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardRefundCurrency.Usd,
            _ => (CardRefundCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardRefundCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardRefundCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Interchange assessed as a part of this transaction.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Interchange, InterchangeFromRaw>))]
public sealed record class Interchange : JsonModel
{
    /// <summary>
    /// The interchange amount given as a string containing a decimal number in major
    /// units (so e.g., "3.14" for $3.14). The amount is a positive number if it is
    /// credited to Increase (e.g., settlements) and a negative number if it is debited
    /// (e.g., refunds).
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
    /// The card network specific interchange code.
    /// </summary>
    public required string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the interchange reimbursement.
    /// </summary>
    public required ApiEnum<string, InterchangeCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InterchangeCurrency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Code;
        this.Currency.Validate();
    }

    public Interchange() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Interchange(Interchange interchange)
        : base(interchange) { }
#pragma warning restore CS8618

    public Interchange(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Interchange(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InterchangeFromRaw.FromRawUnchecked"/>
    public static Interchange FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InterchangeFromRaw : IFromRawJson<Interchange>
{
    /// <inheritdoc/>
    public Interchange FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Interchange.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the interchange reimbursement.
/// </summary>
[JsonConverter(typeof(InterchangeCurrencyConverter))]
public enum InterchangeCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class InterchangeCurrencyConverter : JsonConverter<InterchangeCurrency>
{
    public override InterchangeCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => InterchangeCurrency.Usd,
            _ => (InterchangeCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InterchangeCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InterchangeCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Network-specific identifiers for this refund.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CardRefundNetworkIdentifiers, CardRefundNetworkIdentifiersFromRaw>)
)]
public sealed record class CardRefundNetworkIdentifiers : JsonModel
{
    /// <summary>
    /// A network assigned business ID that identifies the acquirer that processed
    /// this transaction.
    /// </summary>
    public required string AcquirerBusinessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("acquirer_business_id");
        }
        init { this._rawData.Set("acquirer_business_id", value); }
    }

    /// <summary>
    /// A globally unique identifier for this settlement.
    /// </summary>
    public required string AcquirerReferenceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("acquirer_reference_number");
        }
        init { this._rawData.Set("acquirer_reference_number", value); }
    }

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
        _ = this.AcquirerBusinessID;
        _ = this.AcquirerReferenceNumber;
        _ = this.AuthorizationIdentificationResponse;
        _ = this.TransactionID;
    }

    public CardRefundNetworkIdentifiers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardRefundNetworkIdentifiers(CardRefundNetworkIdentifiers cardRefundNetworkIdentifiers)
        : base(cardRefundNetworkIdentifiers) { }
#pragma warning restore CS8618

    public CardRefundNetworkIdentifiers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardRefundNetworkIdentifiers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardRefundNetworkIdentifiersFromRaw.FromRawUnchecked"/>
    public static CardRefundNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardRefundNetworkIdentifiersFromRaw : IFromRawJson<CardRefundNetworkIdentifiers>
{
    /// <inheritdoc/>
    public CardRefundNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardRefundNetworkIdentifiers.FromRawUnchecked(rawData);
}

/// <summary>
/// Additional details about the card purchase, such as tax and industry-specific fields.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PurchaseDetails, PurchaseDetailsFromRaw>))]
public sealed record class PurchaseDetails : JsonModel
{
    /// <summary>
    /// Fields specific to car rentals.
    /// </summary>
    public required CarRental? CarRental
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CarRental>("car_rental");
        }
        init { this._rawData.Set("car_rental", value); }
    }

    /// <summary>
    /// An identifier from the merchant for the customer or consumer.
    /// </summary>
    public required string? CustomerReferenceIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customer_reference_identifier");
        }
        init { this._rawData.Set("customer_reference_identifier", value); }
    }

    /// <summary>
    /// The state or provincial tax amount in minor units.
    /// </summary>
    public required long? LocalTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("local_tax_amount");
        }
        init { this._rawData.Set("local_tax_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the local
    /// tax assessed.
    /// </summary>
    public required string? LocalTaxCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("local_tax_currency");
        }
        init { this._rawData.Set("local_tax_currency", value); }
    }

    /// <summary>
    /// Fields specific to lodging.
    /// </summary>
    public required Lodging? Lodging
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Lodging>("lodging");
        }
        init { this._rawData.Set("lodging", value); }
    }

    /// <summary>
    /// The national tax amount in minor units.
    /// </summary>
    public required long? NationalTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("national_tax_amount");
        }
        init { this._rawData.Set("national_tax_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the local
    /// tax assessed.
    /// </summary>
    public required string? NationalTaxCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("national_tax_currency");
        }
        init { this._rawData.Set("national_tax_currency", value); }
    }

    /// <summary>
    /// An identifier from the merchant for the purchase to the issuer and cardholder.
    /// </summary>
    public required string? PurchaseIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("purchase_identifier");
        }
        init { this._rawData.Set("purchase_identifier", value); }
    }

    /// <summary>
    /// The format of the purchase identifier.
    /// </summary>
    public required ApiEnum<string, PurchaseIdentifierFormat>? PurchaseIdentifierFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PurchaseIdentifierFormat>>(
                "purchase_identifier_format"
            );
        }
        init { this._rawData.Set("purchase_identifier_format", value); }
    }

    /// <summary>
    /// Fields specific to travel.
    /// </summary>
    public required Travel? Travel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Travel>("travel");
        }
        init { this._rawData.Set("travel", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CarRental?.Validate();
        _ = this.CustomerReferenceIdentifier;
        _ = this.LocalTaxAmount;
        _ = this.LocalTaxCurrency;
        this.Lodging?.Validate();
        _ = this.NationalTaxAmount;
        _ = this.NationalTaxCurrency;
        _ = this.PurchaseIdentifier;
        this.PurchaseIdentifierFormat?.Validate();
        this.Travel?.Validate();
    }

    public PurchaseDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PurchaseDetails(PurchaseDetails purchaseDetails)
        : base(purchaseDetails) { }
#pragma warning restore CS8618

    public PurchaseDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PurchaseDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PurchaseDetailsFromRaw.FromRawUnchecked"/>
    public static PurchaseDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PurchaseDetailsFromRaw : IFromRawJson<PurchaseDetails>
{
    /// <inheritdoc/>
    public PurchaseDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PurchaseDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields specific to car rentals.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CarRental, CarRentalFromRaw>))]
public sealed record class CarRental : JsonModel
{
    /// <summary>
    /// Code indicating the vehicle's class.
    /// </summary>
    public required string? CarClassCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("car_class_code");
        }
        init { this._rawData.Set("car_class_code", value); }
    }

    /// <summary>
    /// Date the customer picked up the car or, in the case of a no-show or pre-pay
    /// transaction, the scheduled pick up date.
    /// </summary>
    public required string? CheckoutDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("checkout_date");
        }
        init { this._rawData.Set("checkout_date", value); }
    }

    /// <summary>
    /// Daily rate being charged for the vehicle.
    /// </summary>
    public required long? DailyRentalRateAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("daily_rental_rate_amount");
        }
        init { this._rawData.Set("daily_rental_rate_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the daily
    /// rental rate.
    /// </summary>
    public required string? DailyRentalRateCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("daily_rental_rate_currency");
        }
        init { this._rawData.Set("daily_rental_rate_currency", value); }
    }

    /// <summary>
    /// Number of days the vehicle was rented.
    /// </summary>
    public required long? DaysRented
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("days_rented");
        }
        init { this._rawData.Set("days_rented", value); }
    }

    /// <summary>
    /// Additional charges (gas, late fee, etc.) being billed.
    /// </summary>
    public required ApiEnum<string, ExtraCharges>? ExtraCharges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ExtraCharges>>("extra_charges");
        }
        init { this._rawData.Set("extra_charges", value); }
    }

    /// <summary>
    /// Fuel charges for the vehicle.
    /// </summary>
    public required long? FuelChargesAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("fuel_charges_amount");
        }
        init { this._rawData.Set("fuel_charges_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the fuel charges assessed.
    /// </summary>
    public required string? FuelChargesCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fuel_charges_currency");
        }
        init { this._rawData.Set("fuel_charges_currency", value); }
    }

    /// <summary>
    /// Any insurance being charged for the vehicle.
    /// </summary>
    public required long? InsuranceChargesAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("insurance_charges_amount");
        }
        init { this._rawData.Set("insurance_charges_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the insurance
    /// charges assessed.
    /// </summary>
    public required string? InsuranceChargesCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("insurance_charges_currency");
        }
        init { this._rawData.Set("insurance_charges_currency", value); }
    }

    /// <summary>
    /// An indicator that the cardholder is being billed for a reserved vehicle that
    /// was not actually rented (that is, a "no-show" charge).
    /// </summary>
    public required ApiEnum<string, NoShowIndicator>? NoShowIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, NoShowIndicator>>(
                "no_show_indicator"
            );
        }
        init { this._rawData.Set("no_show_indicator", value); }
    }

    /// <summary>
    /// Charges for returning the vehicle at a different location than where it was
    /// picked up.
    /// </summary>
    public required long? OneWayDropOffChargesAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("one_way_drop_off_charges_amount");
        }
        init { this._rawData.Set("one_way_drop_off_charges_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the one-way
    /// drop-off charges assessed.
    /// </summary>
    public required string? OneWayDropOffChargesCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("one_way_drop_off_charges_currency");
        }
        init { this._rawData.Set("one_way_drop_off_charges_currency", value); }
    }

    /// <summary>
    /// Name of the person renting the vehicle.
    /// </summary>
    public required string? RenterName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("renter_name");
        }
        init { this._rawData.Set("renter_name", value); }
    }

    /// <summary>
    /// Weekly rate being charged for the vehicle.
    /// </summary>
    public required long? WeeklyRentalRateAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("weekly_rental_rate_amount");
        }
        init { this._rawData.Set("weekly_rental_rate_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the weekly
    /// rental rate.
    /// </summary>
    public required string? WeeklyRentalRateCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("weekly_rental_rate_currency");
        }
        init { this._rawData.Set("weekly_rental_rate_currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CarClassCode;
        _ = this.CheckoutDate;
        _ = this.DailyRentalRateAmount;
        _ = this.DailyRentalRateCurrency;
        _ = this.DaysRented;
        this.ExtraCharges?.Validate();
        _ = this.FuelChargesAmount;
        _ = this.FuelChargesCurrency;
        _ = this.InsuranceChargesAmount;
        _ = this.InsuranceChargesCurrency;
        this.NoShowIndicator?.Validate();
        _ = this.OneWayDropOffChargesAmount;
        _ = this.OneWayDropOffChargesCurrency;
        _ = this.RenterName;
        _ = this.WeeklyRentalRateAmount;
        _ = this.WeeklyRentalRateCurrency;
    }

    public CarRental() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CarRental(CarRental carRental)
        : base(carRental) { }
#pragma warning restore CS8618

    public CarRental(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CarRental(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CarRentalFromRaw.FromRawUnchecked"/>
    public static CarRental FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CarRentalFromRaw : IFromRawJson<CarRental>
{
    /// <inheritdoc/>
    public CarRental FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CarRental.FromRawUnchecked(rawData);
}

/// <summary>
/// Additional charges (gas, late fee, etc.) being billed.
/// </summary>
[JsonConverter(typeof(ExtraChargesConverter))]
public enum ExtraCharges
{
    /// <summary>
    /// No extra charge
    /// </summary>
    NoExtraCharge,

    /// <summary>
    /// Gas
    /// </summary>
    Gas,

    /// <summary>
    /// Extra mileage
    /// </summary>
    ExtraMileage,

    /// <summary>
    /// Late return
    /// </summary>
    LateReturn,

    /// <summary>
    /// One way service fee
    /// </summary>
    OneWayServiceFee,

    /// <summary>
    /// Parking violation
    /// </summary>
    ParkingViolation,
}

sealed class ExtraChargesConverter : JsonConverter<ExtraCharges>
{
    public override ExtraCharges Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no_extra_charge" => ExtraCharges.NoExtraCharge,
            "gas" => ExtraCharges.Gas,
            "extra_mileage" => ExtraCharges.ExtraMileage,
            "late_return" => ExtraCharges.LateReturn,
            "one_way_service_fee" => ExtraCharges.OneWayServiceFee,
            "parking_violation" => ExtraCharges.ParkingViolation,
            _ => (ExtraCharges)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtraCharges value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtraCharges.NoExtraCharge => "no_extra_charge",
                ExtraCharges.Gas => "gas",
                ExtraCharges.ExtraMileage => "extra_mileage",
                ExtraCharges.LateReturn => "late_return",
                ExtraCharges.OneWayServiceFee => "one_way_service_fee",
                ExtraCharges.ParkingViolation => "parking_violation",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An indicator that the cardholder is being billed for a reserved vehicle that was
/// not actually rented (that is, a "no-show" charge).
/// </summary>
[JsonConverter(typeof(NoShowIndicatorConverter))]
public enum NoShowIndicator
{
    /// <summary>
    /// Not applicable
    /// </summary>
    NotApplicable,

    /// <summary>
    /// No show for specialized vehicle
    /// </summary>
    NoShowForSpecializedVehicle,
}

sealed class NoShowIndicatorConverter : JsonConverter<NoShowIndicator>
{
    public override NoShowIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_applicable" => NoShowIndicator.NotApplicable,
            "no_show_for_specialized_vehicle" => NoShowIndicator.NoShowForSpecializedVehicle,
            _ => (NoShowIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NoShowIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NoShowIndicator.NotApplicable => "not_applicable",
                NoShowIndicator.NoShowForSpecializedVehicle => "no_show_for_specialized_vehicle",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to lodging.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Lodging, LodgingFromRaw>))]
public sealed record class Lodging : JsonModel
{
    /// <summary>
    /// Date the customer checked in.
    /// </summary>
    public required string? CheckInDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("check_in_date");
        }
        init { this._rawData.Set("check_in_date", value); }
    }

    /// <summary>
    /// Daily rate being charged for the room.
    /// </summary>
    public required long? DailyRoomRateAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("daily_room_rate_amount");
        }
        init { this._rawData.Set("daily_room_rate_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the daily
    /// room rate.
    /// </summary>
    public required string? DailyRoomRateCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("daily_room_rate_currency");
        }
        init { this._rawData.Set("daily_room_rate_currency", value); }
    }

    /// <summary>
    /// Additional charges (phone, late check-out, etc.) being billed.
    /// </summary>
    public required ApiEnum<string, LodgingExtraCharges>? ExtraCharges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LodgingExtraCharges>>(
                "extra_charges"
            );
        }
        init { this._rawData.Set("extra_charges", value); }
    }

    /// <summary>
    /// Folio cash advances for the room.
    /// </summary>
    public required long? FolioCashAdvancesAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("folio_cash_advances_amount");
        }
        init { this._rawData.Set("folio_cash_advances_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the folio
    /// cash advances.
    /// </summary>
    public required string? FolioCashAdvancesCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("folio_cash_advances_currency");
        }
        init { this._rawData.Set("folio_cash_advances_currency", value); }
    }

    /// <summary>
    /// Food and beverage charges for the room.
    /// </summary>
    public required long? FoodBeverageChargesAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("food_beverage_charges_amount");
        }
        init { this._rawData.Set("food_beverage_charges_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the food and
    /// beverage charges.
    /// </summary>
    public required string? FoodBeverageChargesCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("food_beverage_charges_currency");
        }
        init { this._rawData.Set("food_beverage_charges_currency", value); }
    }

    /// <summary>
    /// Indicator that the cardholder is being billed for a reserved room that was
    /// not actually used.
    /// </summary>
    public required ApiEnum<string, LodgingNoShowIndicator>? NoShowIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LodgingNoShowIndicator>>(
                "no_show_indicator"
            );
        }
        init { this._rawData.Set("no_show_indicator", value); }
    }

    /// <summary>
    /// Prepaid expenses being charged for the room.
    /// </summary>
    public required long? PrepaidExpensesAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("prepaid_expenses_amount");
        }
        init { this._rawData.Set("prepaid_expenses_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the prepaid expenses.
    /// </summary>
    public required string? PrepaidExpensesCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prepaid_expenses_currency");
        }
        init { this._rawData.Set("prepaid_expenses_currency", value); }
    }

    /// <summary>
    /// Number of nights the room was rented.
    /// </summary>
    public required long? RoomNights
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("room_nights");
        }
        init { this._rawData.Set("room_nights", value); }
    }

    /// <summary>
    /// Total room tax being charged.
    /// </summary>
    public required long? TotalRoomTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_room_tax_amount");
        }
        init { this._rawData.Set("total_room_tax_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the total
    /// room tax.
    /// </summary>
    public required string? TotalRoomTaxCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("total_room_tax_currency");
        }
        init { this._rawData.Set("total_room_tax_currency", value); }
    }

    /// <summary>
    /// Total tax being charged for the room.
    /// </summary>
    public required long? TotalTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_tax_amount");
        }
        init { this._rawData.Set("total_tax_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the total
    /// tax assessed.
    /// </summary>
    public required string? TotalTaxCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("total_tax_currency");
        }
        init { this._rawData.Set("total_tax_currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CheckInDate;
        _ = this.DailyRoomRateAmount;
        _ = this.DailyRoomRateCurrency;
        this.ExtraCharges?.Validate();
        _ = this.FolioCashAdvancesAmount;
        _ = this.FolioCashAdvancesCurrency;
        _ = this.FoodBeverageChargesAmount;
        _ = this.FoodBeverageChargesCurrency;
        this.NoShowIndicator?.Validate();
        _ = this.PrepaidExpensesAmount;
        _ = this.PrepaidExpensesCurrency;
        _ = this.RoomNights;
        _ = this.TotalRoomTaxAmount;
        _ = this.TotalRoomTaxCurrency;
        _ = this.TotalTaxAmount;
        _ = this.TotalTaxCurrency;
    }

    public Lodging() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Lodging(Lodging lodging)
        : base(lodging) { }
#pragma warning restore CS8618

    public Lodging(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Lodging(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LodgingFromRaw.FromRawUnchecked"/>
    public static Lodging FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LodgingFromRaw : IFromRawJson<Lodging>
{
    /// <inheritdoc/>
    public Lodging FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Lodging.FromRawUnchecked(rawData);
}

/// <summary>
/// Additional charges (phone, late check-out, etc.) being billed.
/// </summary>
[JsonConverter(typeof(LodgingExtraChargesConverter))]
public enum LodgingExtraCharges
{
    /// <summary>
    /// No extra charge
    /// </summary>
    NoExtraCharge,

    /// <summary>
    /// Restaurant
    /// </summary>
    Restaurant,

    /// <summary>
    /// Gift shop
    /// </summary>
    GiftShop,

    /// <summary>
    /// Mini bar
    /// </summary>
    MiniBar,

    /// <summary>
    /// Telephone
    /// </summary>
    Telephone,

    /// <summary>
    /// Other
    /// </summary>
    Other,

    /// <summary>
    /// Laundry
    /// </summary>
    Laundry,
}

sealed class LodgingExtraChargesConverter : JsonConverter<LodgingExtraCharges>
{
    public override LodgingExtraCharges Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no_extra_charge" => LodgingExtraCharges.NoExtraCharge,
            "restaurant" => LodgingExtraCharges.Restaurant,
            "gift_shop" => LodgingExtraCharges.GiftShop,
            "mini_bar" => LodgingExtraCharges.MiniBar,
            "telephone" => LodgingExtraCharges.Telephone,
            "other" => LodgingExtraCharges.Other,
            "laundry" => LodgingExtraCharges.Laundry,
            _ => (LodgingExtraCharges)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LodgingExtraCharges value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LodgingExtraCharges.NoExtraCharge => "no_extra_charge",
                LodgingExtraCharges.Restaurant => "restaurant",
                LodgingExtraCharges.GiftShop => "gift_shop",
                LodgingExtraCharges.MiniBar => "mini_bar",
                LodgingExtraCharges.Telephone => "telephone",
                LodgingExtraCharges.Other => "other",
                LodgingExtraCharges.Laundry => "laundry",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Indicator that the cardholder is being billed for a reserved room that was not
/// actually used.
/// </summary>
[JsonConverter(typeof(LodgingNoShowIndicatorConverter))]
public enum LodgingNoShowIndicator
{
    /// <summary>
    /// Not applicable
    /// </summary>
    NotApplicable,

    /// <summary>
    /// No show
    /// </summary>
    NoShow,
}

sealed class LodgingNoShowIndicatorConverter : JsonConverter<LodgingNoShowIndicator>
{
    public override LodgingNoShowIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_applicable" => LodgingNoShowIndicator.NotApplicable,
            "no_show" => LodgingNoShowIndicator.NoShow,
            _ => (LodgingNoShowIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LodgingNoShowIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LodgingNoShowIndicator.NotApplicable => "not_applicable",
                LodgingNoShowIndicator.NoShow => "no_show",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The format of the purchase identifier.
/// </summary>
[JsonConverter(typeof(PurchaseIdentifierFormatConverter))]
public enum PurchaseIdentifierFormat
{
    /// <summary>
    /// Free text
    /// </summary>
    FreeText,

    /// <summary>
    /// Order number
    /// </summary>
    OrderNumber,

    /// <summary>
    /// Rental agreement number
    /// </summary>
    RentalAgreementNumber,

    /// <summary>
    /// Hotel folio number
    /// </summary>
    HotelFolioNumber,

    /// <summary>
    /// Invoice number
    /// </summary>
    InvoiceNumber,
}

sealed class PurchaseIdentifierFormatConverter : JsonConverter<PurchaseIdentifierFormat>
{
    public override PurchaseIdentifierFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "free_text" => PurchaseIdentifierFormat.FreeText,
            "order_number" => PurchaseIdentifierFormat.OrderNumber,
            "rental_agreement_number" => PurchaseIdentifierFormat.RentalAgreementNumber,
            "hotel_folio_number" => PurchaseIdentifierFormat.HotelFolioNumber,
            "invoice_number" => PurchaseIdentifierFormat.InvoiceNumber,
            _ => (PurchaseIdentifierFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PurchaseIdentifierFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PurchaseIdentifierFormat.FreeText => "free_text",
                PurchaseIdentifierFormat.OrderNumber => "order_number",
                PurchaseIdentifierFormat.RentalAgreementNumber => "rental_agreement_number",
                PurchaseIdentifierFormat.HotelFolioNumber => "hotel_folio_number",
                PurchaseIdentifierFormat.InvoiceNumber => "invoice_number",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to travel.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Travel, TravelFromRaw>))]
public sealed record class Travel : JsonModel
{
    /// <summary>
    /// Ancillary purchases in addition to the airfare.
    /// </summary>
    public required Ancillary? Ancillary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Ancillary>("ancillary");
        }
        init { this._rawData.Set("ancillary", value); }
    }

    /// <summary>
    /// Indicates the computerized reservation system used to book the ticket.
    /// </summary>
    public required string? ComputerizedReservationSystem
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("computerized_reservation_system");
        }
        init { this._rawData.Set("computerized_reservation_system", value); }
    }

    /// <summary>
    /// Indicates the reason for a credit to the cardholder.
    /// </summary>
    public required ApiEnum<string, TravelCreditReasonIndicator>? CreditReasonIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TravelCreditReasonIndicator>>(
                "credit_reason_indicator"
            );
        }
        init { this._rawData.Set("credit_reason_indicator", value); }
    }

    /// <summary>
    /// Date of departure.
    /// </summary>
    public required string? DepartureDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("departure_date");
        }
        init { this._rawData.Set("departure_date", value); }
    }

    /// <summary>
    /// Code for the originating city or airport.
    /// </summary>
    public required string? OriginationCityAirportCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("origination_city_airport_code");
        }
        init { this._rawData.Set("origination_city_airport_code", value); }
    }

    /// <summary>
    /// Name of the passenger.
    /// </summary>
    public required string? PassengerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("passenger_name");
        }
        init { this._rawData.Set("passenger_name", value); }
    }

    /// <summary>
    /// Indicates whether this ticket is non-refundable.
    /// </summary>
    public required ApiEnum<string, RestrictedTicketIndicator>? RestrictedTicketIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RestrictedTicketIndicator>>(
                "restricted_ticket_indicator"
            );
        }
        init { this._rawData.Set("restricted_ticket_indicator", value); }
    }

    /// <summary>
    /// Indicates why a ticket was changed.
    /// </summary>
    public required ApiEnum<string, TicketChangeIndicator>? TicketChangeIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TicketChangeIndicator>>(
                "ticket_change_indicator"
            );
        }
        init { this._rawData.Set("ticket_change_indicator", value); }
    }

    /// <summary>
    /// Ticket number.
    /// </summary>
    public required string? TicketNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ticket_number");
        }
        init { this._rawData.Set("ticket_number", value); }
    }

    /// <summary>
    /// Code for the travel agency if the ticket was issued by a travel agency.
    /// </summary>
    public required string? TravelAgencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("travel_agency_code");
        }
        init { this._rawData.Set("travel_agency_code", value); }
    }

    /// <summary>
    /// Name of the travel agency if the ticket was issued by a travel agency.
    /// </summary>
    public required string? TravelAgencyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("travel_agency_name");
        }
        init { this._rawData.Set("travel_agency_name", value); }
    }

    /// <summary>
    /// Fields specific to each leg of the journey.
    /// </summary>
    public required IReadOnlyList<TripLeg>? TripLegs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TripLeg>>("trip_legs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TripLeg>?>(
                "trip_legs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Ancillary?.Validate();
        _ = this.ComputerizedReservationSystem;
        this.CreditReasonIndicator?.Validate();
        _ = this.DepartureDate;
        _ = this.OriginationCityAirportCode;
        _ = this.PassengerName;
        this.RestrictedTicketIndicator?.Validate();
        this.TicketChangeIndicator?.Validate();
        _ = this.TicketNumber;
        _ = this.TravelAgencyCode;
        _ = this.TravelAgencyName;
        foreach (var item in this.TripLegs ?? [])
        {
            item.Validate();
        }
    }

    public Travel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Travel(Travel travel)
        : base(travel) { }
#pragma warning restore CS8618

    public Travel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Travel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TravelFromRaw.FromRawUnchecked"/>
    public static Travel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TravelFromRaw : IFromRawJson<Travel>
{
    /// <inheritdoc/>
    public Travel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Travel.FromRawUnchecked(rawData);
}

/// <summary>
/// Ancillary purchases in addition to the airfare.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Ancillary, AncillaryFromRaw>))]
public sealed record class Ancillary : JsonModel
{
    /// <summary>
    /// If this purchase has a connection or relationship to another purchase, such
    /// as a baggage fee for a passenger transport ticket, this field should contain
    /// the ticket document number for the other purchase.
    /// </summary>
    public required string? ConnectedTicketDocumentNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("connected_ticket_document_number");
        }
        init { this._rawData.Set("connected_ticket_document_number", value); }
    }

    /// <summary>
    /// Indicates the reason for a credit to the cardholder.
    /// </summary>
    public required ApiEnum<string, CreditReasonIndicator>? CreditReasonIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CreditReasonIndicator>>(
                "credit_reason_indicator"
            );
        }
        init { this._rawData.Set("credit_reason_indicator", value); }
    }

    /// <summary>
    /// Name of the passenger or description of the ancillary purchase.
    /// </summary>
    public required string? PassengerNameOrDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("passenger_name_or_description");
        }
        init { this._rawData.Set("passenger_name_or_description", value); }
    }

    /// <summary>
    /// Additional travel charges, such as baggage fees.
    /// </summary>
    public required IReadOnlyList<Service> Services
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Service>>("services");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Service>>(
                "services",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Ticket document number.
    /// </summary>
    public required string? TicketDocumentNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ticket_document_number");
        }
        init { this._rawData.Set("ticket_document_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConnectedTicketDocumentNumber;
        this.CreditReasonIndicator?.Validate();
        _ = this.PassengerNameOrDescription;
        foreach (var item in this.Services)
        {
            item.Validate();
        }
        _ = this.TicketDocumentNumber;
    }

    public Ancillary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Ancillary(Ancillary ancillary)
        : base(ancillary) { }
#pragma warning restore CS8618

    public Ancillary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Ancillary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AncillaryFromRaw.FromRawUnchecked"/>
    public static Ancillary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AncillaryFromRaw : IFromRawJson<Ancillary>
{
    /// <inheritdoc/>
    public Ancillary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Ancillary.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates the reason for a credit to the cardholder.
/// </summary>
[JsonConverter(typeof(CreditReasonIndicatorConverter))]
public enum CreditReasonIndicator
{
    /// <summary>
    /// No credit
    /// </summary>
    NoCredit,

    /// <summary>
    /// Passenger transport ancillary purchase cancellation
    /// </summary>
    PassengerTransportAncillaryPurchaseCancellation,

    /// <summary>
    /// Airline ticket and passenger transport ancillary purchase cancellation
    /// </summary>
    AirlineTicketAndPassengerTransportAncillaryPurchaseCancellation,

    /// <summary>
    /// Other
    /// </summary>
    Other,
}

sealed class CreditReasonIndicatorConverter : JsonConverter<CreditReasonIndicator>
{
    public override CreditReasonIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no_credit" => CreditReasonIndicator.NoCredit,
            "passenger_transport_ancillary_purchase_cancellation" =>
                CreditReasonIndicator.PassengerTransportAncillaryPurchaseCancellation,
            "airline_ticket_and_passenger_transport_ancillary_purchase_cancellation" =>
                CreditReasonIndicator.AirlineTicketAndPassengerTransportAncillaryPurchaseCancellation,
            "other" => CreditReasonIndicator.Other,
            _ => (CreditReasonIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditReasonIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditReasonIndicator.NoCredit => "no_credit",
                CreditReasonIndicator.PassengerTransportAncillaryPurchaseCancellation =>
                    "passenger_transport_ancillary_purchase_cancellation",
                CreditReasonIndicator.AirlineTicketAndPassengerTransportAncillaryPurchaseCancellation =>
                    "airline_ticket_and_passenger_transport_ancillary_purchase_cancellation",
                CreditReasonIndicator.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Service, ServiceFromRaw>))]
public sealed record class Service : JsonModel
{
    /// <summary>
    /// Category of the ancillary service.
    /// </summary>
    public required ApiEnum<string, ServiceCategory>? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ServiceCategory>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Sub-category of the ancillary service, free-form.
    /// </summary>
    public required string? SubCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sub_category");
        }
        init { this._rawData.Set("sub_category", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category?.Validate();
        _ = this.SubCategory;
    }

    public Service() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Service(Service service)
        : base(service) { }
#pragma warning restore CS8618

    public Service(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Service(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ServiceFromRaw.FromRawUnchecked"/>
    public static Service FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ServiceFromRaw : IFromRawJson<Service>
{
    /// <inheritdoc/>
    public Service FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Service.FromRawUnchecked(rawData);
}

/// <summary>
/// Category of the ancillary service.
/// </summary>
[JsonConverter(typeof(ServiceCategoryConverter))]
public enum ServiceCategory
{
    /// <summary>
    /// None
    /// </summary>
    None,

    /// <summary>
    /// Bundled service
    /// </summary>
    BundledService,

    /// <summary>
    /// Baggage fee
    /// </summary>
    BaggageFee,

    /// <summary>
    /// Change fee
    /// </summary>
    ChangeFee,

    /// <summary>
    /// Cargo
    /// </summary>
    Cargo,

    /// <summary>
    /// Carbon offset
    /// </summary>
    CarbonOffset,

    /// <summary>
    /// Frequent flyer
    /// </summary>
    FrequentFlyer,

    /// <summary>
    /// Gift card
    /// </summary>
    GiftCard,

    /// <summary>
    /// Ground transport
    /// </summary>
    GroundTransport,

    /// <summary>
    /// In-flight entertainment
    /// </summary>
    InFlightEntertainment,

    /// <summary>
    /// Lounge
    /// </summary>
    Lounge,

    /// <summary>
    /// Medical
    /// </summary>
    Medical,

    /// <summary>
    /// Meal beverage
    /// </summary>
    MealBeverage,

    /// <summary>
    /// Other
    /// </summary>
    Other,

    /// <summary>
    /// Passenger assist fee
    /// </summary>
    PassengerAssistFee,

    /// <summary>
    /// Pets
    /// </summary>
    Pets,

    /// <summary>
    /// Seat fees
    /// </summary>
    SeatFees,

    /// <summary>
    /// Standby
    /// </summary>
    Standby,

    /// <summary>
    /// Service fee
    /// </summary>
    ServiceFee,

    /// <summary>
    /// Store
    /// </summary>
    Store,

    /// <summary>
    /// Travel service
    /// </summary>
    TravelService,

    /// <summary>
    /// Unaccompanied travel
    /// </summary>
    UnaccompaniedTravel,

    /// <summary>
    /// Upgrades
    /// </summary>
    Upgrades,

    /// <summary>
    /// Wi-fi
    /// </summary>
    Wifi,
}

sealed class ServiceCategoryConverter : JsonConverter<ServiceCategory>
{
    public override ServiceCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => ServiceCategory.None,
            "bundled_service" => ServiceCategory.BundledService,
            "baggage_fee" => ServiceCategory.BaggageFee,
            "change_fee" => ServiceCategory.ChangeFee,
            "cargo" => ServiceCategory.Cargo,
            "carbon_offset" => ServiceCategory.CarbonOffset,
            "frequent_flyer" => ServiceCategory.FrequentFlyer,
            "gift_card" => ServiceCategory.GiftCard,
            "ground_transport" => ServiceCategory.GroundTransport,
            "in_flight_entertainment" => ServiceCategory.InFlightEntertainment,
            "lounge" => ServiceCategory.Lounge,
            "medical" => ServiceCategory.Medical,
            "meal_beverage" => ServiceCategory.MealBeverage,
            "other" => ServiceCategory.Other,
            "passenger_assist_fee" => ServiceCategory.PassengerAssistFee,
            "pets" => ServiceCategory.Pets,
            "seat_fees" => ServiceCategory.SeatFees,
            "standby" => ServiceCategory.Standby,
            "service_fee" => ServiceCategory.ServiceFee,
            "store" => ServiceCategory.Store,
            "travel_service" => ServiceCategory.TravelService,
            "unaccompanied_travel" => ServiceCategory.UnaccompaniedTravel,
            "upgrades" => ServiceCategory.Upgrades,
            "wifi" => ServiceCategory.Wifi,
            _ => (ServiceCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ServiceCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ServiceCategory.None => "none",
                ServiceCategory.BundledService => "bundled_service",
                ServiceCategory.BaggageFee => "baggage_fee",
                ServiceCategory.ChangeFee => "change_fee",
                ServiceCategory.Cargo => "cargo",
                ServiceCategory.CarbonOffset => "carbon_offset",
                ServiceCategory.FrequentFlyer => "frequent_flyer",
                ServiceCategory.GiftCard => "gift_card",
                ServiceCategory.GroundTransport => "ground_transport",
                ServiceCategory.InFlightEntertainment => "in_flight_entertainment",
                ServiceCategory.Lounge => "lounge",
                ServiceCategory.Medical => "medical",
                ServiceCategory.MealBeverage => "meal_beverage",
                ServiceCategory.Other => "other",
                ServiceCategory.PassengerAssistFee => "passenger_assist_fee",
                ServiceCategory.Pets => "pets",
                ServiceCategory.SeatFees => "seat_fees",
                ServiceCategory.Standby => "standby",
                ServiceCategory.ServiceFee => "service_fee",
                ServiceCategory.Store => "store",
                ServiceCategory.TravelService => "travel_service",
                ServiceCategory.UnaccompaniedTravel => "unaccompanied_travel",
                ServiceCategory.Upgrades => "upgrades",
                ServiceCategory.Wifi => "wifi",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Indicates the reason for a credit to the cardholder.
/// </summary>
[JsonConverter(typeof(TravelCreditReasonIndicatorConverter))]
public enum TravelCreditReasonIndicator
{
    /// <summary>
    /// No credit
    /// </summary>
    NoCredit,

    /// <summary>
    /// Passenger transport ancillary purchase cancellation
    /// </summary>
    PassengerTransportAncillaryPurchaseCancellation,

    /// <summary>
    /// Airline ticket and passenger transport ancillary purchase cancellation
    /// </summary>
    AirlineTicketAndPassengerTransportAncillaryPurchaseCancellation,

    /// <summary>
    /// Airline ticket cancellation
    /// </summary>
    AirlineTicketCancellation,

    /// <summary>
    /// Other
    /// </summary>
    Other,

    /// <summary>
    /// Partial refund of airline ticket
    /// </summary>
    PartialRefundOfAirlineTicket,
}

sealed class TravelCreditReasonIndicatorConverter : JsonConverter<TravelCreditReasonIndicator>
{
    public override TravelCreditReasonIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no_credit" => TravelCreditReasonIndicator.NoCredit,
            "passenger_transport_ancillary_purchase_cancellation" =>
                TravelCreditReasonIndicator.PassengerTransportAncillaryPurchaseCancellation,
            "airline_ticket_and_passenger_transport_ancillary_purchase_cancellation" =>
                TravelCreditReasonIndicator.AirlineTicketAndPassengerTransportAncillaryPurchaseCancellation,
            "airline_ticket_cancellation" => TravelCreditReasonIndicator.AirlineTicketCancellation,
            "other" => TravelCreditReasonIndicator.Other,
            "partial_refund_of_airline_ticket" =>
                TravelCreditReasonIndicator.PartialRefundOfAirlineTicket,
            _ => (TravelCreditReasonIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TravelCreditReasonIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TravelCreditReasonIndicator.NoCredit => "no_credit",
                TravelCreditReasonIndicator.PassengerTransportAncillaryPurchaseCancellation =>
                    "passenger_transport_ancillary_purchase_cancellation",
                TravelCreditReasonIndicator.AirlineTicketAndPassengerTransportAncillaryPurchaseCancellation =>
                    "airline_ticket_and_passenger_transport_ancillary_purchase_cancellation",
                TravelCreditReasonIndicator.AirlineTicketCancellation =>
                    "airline_ticket_cancellation",
                TravelCreditReasonIndicator.Other => "other",
                TravelCreditReasonIndicator.PartialRefundOfAirlineTicket =>
                    "partial_refund_of_airline_ticket",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Indicates whether this ticket is non-refundable.
/// </summary>
[JsonConverter(typeof(RestrictedTicketIndicatorConverter))]
public enum RestrictedTicketIndicator
{
    /// <summary>
    /// No restrictions
    /// </summary>
    NoRestrictions,

    /// <summary>
    /// Restricted non-refundable ticket
    /// </summary>
    RestrictedNonRefundableTicket,
}

sealed class RestrictedTicketIndicatorConverter : JsonConverter<RestrictedTicketIndicator>
{
    public override RestrictedTicketIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no_restrictions" => RestrictedTicketIndicator.NoRestrictions,
            "restricted_non_refundable_ticket" =>
                RestrictedTicketIndicator.RestrictedNonRefundableTicket,
            _ => (RestrictedTicketIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RestrictedTicketIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RestrictedTicketIndicator.NoRestrictions => "no_restrictions",
                RestrictedTicketIndicator.RestrictedNonRefundableTicket =>
                    "restricted_non_refundable_ticket",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Indicates why a ticket was changed.
/// </summary>
[JsonConverter(typeof(TicketChangeIndicatorConverter))]
public enum TicketChangeIndicator
{
    /// <summary>
    /// None
    /// </summary>
    None,

    /// <summary>
    /// Change to existing ticket
    /// </summary>
    ChangeToExistingTicket,

    /// <summary>
    /// New ticket
    /// </summary>
    NewTicket,
}

sealed class TicketChangeIndicatorConverter : JsonConverter<TicketChangeIndicator>
{
    public override TicketChangeIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => TicketChangeIndicator.None,
            "change_to_existing_ticket" => TicketChangeIndicator.ChangeToExistingTicket,
            "new_ticket" => TicketChangeIndicator.NewTicket,
            _ => (TicketChangeIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TicketChangeIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TicketChangeIndicator.None => "none",
                TicketChangeIndicator.ChangeToExistingTicket => "change_to_existing_ticket",
                TicketChangeIndicator.NewTicket => "new_ticket",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<TripLeg, TripLegFromRaw>))]
public sealed record class TripLeg : JsonModel
{
    /// <summary>
    /// Carrier code (e.g., United Airlines, Jet Blue, etc.).
    /// </summary>
    public required string? CarrierCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("carrier_code");
        }
        init { this._rawData.Set("carrier_code", value); }
    }

    /// <summary>
    /// Code for the destination city or airport.
    /// </summary>
    public required string? DestinationCityAirportCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("destination_city_airport_code");
        }
        init { this._rawData.Set("destination_city_airport_code", value); }
    }

    /// <summary>
    /// Fare basis code.
    /// </summary>
    public required string? FareBasisCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fare_basis_code");
        }
        init { this._rawData.Set("fare_basis_code", value); }
    }

    /// <summary>
    /// Flight number.
    /// </summary>
    public required string? FlightNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("flight_number");
        }
        init { this._rawData.Set("flight_number", value); }
    }

    /// <summary>
    /// Service class (e.g., first class, business class, etc.).
    /// </summary>
    public required string? ServiceClass
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("service_class");
        }
        init { this._rawData.Set("service_class", value); }
    }

    /// <summary>
    /// Indicates whether a stopover is allowed on this ticket.
    /// </summary>
    public required ApiEnum<string, StopOverCode>? StopOverCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, StopOverCode>>("stop_over_code");
        }
        init { this._rawData.Set("stop_over_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CarrierCode;
        _ = this.DestinationCityAirportCode;
        _ = this.FareBasisCode;
        _ = this.FlightNumber;
        _ = this.ServiceClass;
        this.StopOverCode?.Validate();
    }

    public TripLeg() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TripLeg(TripLeg tripLeg)
        : base(tripLeg) { }
#pragma warning restore CS8618

    public TripLeg(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TripLeg(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TripLegFromRaw.FromRawUnchecked"/>
    public static TripLeg FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TripLegFromRaw : IFromRawJson<TripLeg>
{
    /// <inheritdoc/>
    public TripLeg FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TripLeg.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates whether a stopover is allowed on this ticket.
/// </summary>
[JsonConverter(typeof(StopOverCodeConverter))]
public enum StopOverCode
{
    /// <summary>
    /// None
    /// </summary>
    None,

    /// <summary>
    /// Stop over allowed
    /// </summary>
    StopOverAllowed,

    /// <summary>
    /// Stop over not allowed
    /// </summary>
    StopOverNotAllowed,
}

sealed class StopOverCodeConverter : JsonConverter<StopOverCode>
{
    public override StopOverCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => StopOverCode.None,
            "stop_over_allowed" => StopOverCode.StopOverAllowed,
            "stop_over_not_allowed" => StopOverCode.StopOverNotAllowed,
            _ => (StopOverCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StopOverCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StopOverCode.None => "none",
                StopOverCode.StopOverAllowed => "stop_over_allowed",
                StopOverCode.StopOverNotAllowed => "stop_over_not_allowed",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<CardRefundSchemeFee, CardRefundSchemeFeeFromRaw>))]
public sealed record class CardRefundSchemeFee : JsonModel
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
    public required ApiEnum<string, CardRefundSchemeFeeCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardRefundSchemeFeeCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The type of fee being assessed.
    /// </summary>
    public required ApiEnum<string, CardRefundSchemeFeeFeeType> FeeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardRefundSchemeFeeFeeType>>(
                "fee_type"
            );
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

    public CardRefundSchemeFee() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardRefundSchemeFee(CardRefundSchemeFee cardRefundSchemeFee)
        : base(cardRefundSchemeFee) { }
#pragma warning restore CS8618

    public CardRefundSchemeFee(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardRefundSchemeFee(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardRefundSchemeFeeFromRaw.FromRawUnchecked"/>
    public static CardRefundSchemeFee FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardRefundSchemeFeeFromRaw : IFromRawJson<CardRefundSchemeFee>
{
    /// <inheritdoc/>
    public CardRefundSchemeFee FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardRefundSchemeFee.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the fee reimbursement.
/// </summary>
[JsonConverter(typeof(CardRefundSchemeFeeCurrencyConverter))]
public enum CardRefundSchemeFeeCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardRefundSchemeFeeCurrencyConverter : JsonConverter<CardRefundSchemeFeeCurrency>
{
    public override CardRefundSchemeFeeCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardRefundSchemeFeeCurrency.Usd,
            _ => (CardRefundSchemeFeeCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardRefundSchemeFeeCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardRefundSchemeFeeCurrency.Usd => "USD",
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
[JsonConverter(typeof(CardRefundSchemeFeeFeeTypeConverter))]
public enum CardRefundSchemeFeeFeeType
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

sealed class CardRefundSchemeFeeFeeTypeConverter : JsonConverter<CardRefundSchemeFeeFeeType>
{
    public override CardRefundSchemeFeeFeeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa_international_service_assessment_single_currency" =>
                CardRefundSchemeFeeFeeType.VisaInternationalServiceAssessmentSingleCurrency,
            "visa_international_service_assessment_cross_currency" =>
                CardRefundSchemeFeeFeeType.VisaInternationalServiceAssessmentCrossCurrency,
            "visa_authorization_domestic_point_of_sale" =>
                CardRefundSchemeFeeFeeType.VisaAuthorizationDomesticPointOfSale,
            "visa_authorization_international_point_of_sale" =>
                CardRefundSchemeFeeFeeType.VisaAuthorizationInternationalPointOfSale,
            "visa_authorization_canada_point_of_sale" =>
                CardRefundSchemeFeeFeeType.VisaAuthorizationCanadaPointOfSale,
            "visa_authorization_reversal_point_of_sale" =>
                CardRefundSchemeFeeFeeType.VisaAuthorizationReversalPointOfSale,
            "visa_authorization_reversal_international_point_of_sale" =>
                CardRefundSchemeFeeFeeType.VisaAuthorizationReversalInternationalPointOfSale,
            "visa_authorization_address_verification_service" =>
                CardRefundSchemeFeeFeeType.VisaAuthorizationAddressVerificationService,
            "visa_advanced_authorization" => CardRefundSchemeFeeFeeType.VisaAdvancedAuthorization,
            "visa_message_transmission" => CardRefundSchemeFeeFeeType.VisaMessageTransmission,
            "visa_account_verification_domestic" =>
                CardRefundSchemeFeeFeeType.VisaAccountVerificationDomestic,
            "visa_account_verification_international" =>
                CardRefundSchemeFeeFeeType.VisaAccountVerificationInternational,
            "visa_account_verification_canada" =>
                CardRefundSchemeFeeFeeType.VisaAccountVerificationCanada,
            "visa_corporate_acceptance_fee" =>
                CardRefundSchemeFeeFeeType.VisaCorporateAcceptanceFee,
            "visa_consumer_debit_acceptance_fee" =>
                CardRefundSchemeFeeFeeType.VisaConsumerDebitAcceptanceFee,
            "visa_business_debit_acceptance_fee" =>
                CardRefundSchemeFeeFeeType.VisaBusinessDebitAcceptanceFee,
            "visa_purchasing_acceptance_fee" =>
                CardRefundSchemeFeeFeeType.VisaPurchasingAcceptanceFee,
            "visa_purchase_domestic" => CardRefundSchemeFeeFeeType.VisaPurchaseDomestic,
            "visa_purchase_international" => CardRefundSchemeFeeFeeType.VisaPurchaseInternational,
            "visa_credit_purchase_token" => CardRefundSchemeFeeFeeType.VisaCreditPurchaseToken,
            "visa_debit_purchase_token" => CardRefundSchemeFeeFeeType.VisaDebitPurchaseToken,
            "visa_clearing_transmission" => CardRefundSchemeFeeFeeType.VisaClearingTransmission,
            "visa_direct_authorization" => CardRefundSchemeFeeFeeType.VisaDirectAuthorization,
            "visa_direct_transaction_domestic" =>
                CardRefundSchemeFeeFeeType.VisaDirectTransactionDomestic,
            "visa_service_commercial_credit" =>
                CardRefundSchemeFeeFeeType.VisaServiceCommercialCredit,
            "visa_advertising_service_commercial_credit" =>
                CardRefundSchemeFeeFeeType.VisaAdvertisingServiceCommercialCredit,
            "visa_community_growth_acceleration_program" =>
                CardRefundSchemeFeeFeeType.VisaCommunityGrowthAccelerationProgram,
            "visa_processing_guarantee_commercial_credit" =>
                CardRefundSchemeFeeFeeType.VisaProcessingGuaranteeCommercialCredit,
            "pulse_switch_fee" => CardRefundSchemeFeeFeeType.PulseSwitchFee,
            _ => (CardRefundSchemeFeeFeeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardRefundSchemeFeeFeeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardRefundSchemeFeeFeeType.VisaInternationalServiceAssessmentSingleCurrency =>
                    "visa_international_service_assessment_single_currency",
                CardRefundSchemeFeeFeeType.VisaInternationalServiceAssessmentCrossCurrency =>
                    "visa_international_service_assessment_cross_currency",
                CardRefundSchemeFeeFeeType.VisaAuthorizationDomesticPointOfSale =>
                    "visa_authorization_domestic_point_of_sale",
                CardRefundSchemeFeeFeeType.VisaAuthorizationInternationalPointOfSale =>
                    "visa_authorization_international_point_of_sale",
                CardRefundSchemeFeeFeeType.VisaAuthorizationCanadaPointOfSale =>
                    "visa_authorization_canada_point_of_sale",
                CardRefundSchemeFeeFeeType.VisaAuthorizationReversalPointOfSale =>
                    "visa_authorization_reversal_point_of_sale",
                CardRefundSchemeFeeFeeType.VisaAuthorizationReversalInternationalPointOfSale =>
                    "visa_authorization_reversal_international_point_of_sale",
                CardRefundSchemeFeeFeeType.VisaAuthorizationAddressVerificationService =>
                    "visa_authorization_address_verification_service",
                CardRefundSchemeFeeFeeType.VisaAdvancedAuthorization =>
                    "visa_advanced_authorization",
                CardRefundSchemeFeeFeeType.VisaMessageTransmission => "visa_message_transmission",
                CardRefundSchemeFeeFeeType.VisaAccountVerificationDomestic =>
                    "visa_account_verification_domestic",
                CardRefundSchemeFeeFeeType.VisaAccountVerificationInternational =>
                    "visa_account_verification_international",
                CardRefundSchemeFeeFeeType.VisaAccountVerificationCanada =>
                    "visa_account_verification_canada",
                CardRefundSchemeFeeFeeType.VisaCorporateAcceptanceFee =>
                    "visa_corporate_acceptance_fee",
                CardRefundSchemeFeeFeeType.VisaConsumerDebitAcceptanceFee =>
                    "visa_consumer_debit_acceptance_fee",
                CardRefundSchemeFeeFeeType.VisaBusinessDebitAcceptanceFee =>
                    "visa_business_debit_acceptance_fee",
                CardRefundSchemeFeeFeeType.VisaPurchasingAcceptanceFee =>
                    "visa_purchasing_acceptance_fee",
                CardRefundSchemeFeeFeeType.VisaPurchaseDomestic => "visa_purchase_domestic",
                CardRefundSchemeFeeFeeType.VisaPurchaseInternational =>
                    "visa_purchase_international",
                CardRefundSchemeFeeFeeType.VisaCreditPurchaseToken => "visa_credit_purchase_token",
                CardRefundSchemeFeeFeeType.VisaDebitPurchaseToken => "visa_debit_purchase_token",
                CardRefundSchemeFeeFeeType.VisaClearingTransmission => "visa_clearing_transmission",
                CardRefundSchemeFeeFeeType.VisaDirectAuthorization => "visa_direct_authorization",
                CardRefundSchemeFeeFeeType.VisaDirectTransactionDomestic =>
                    "visa_direct_transaction_domestic",
                CardRefundSchemeFeeFeeType.VisaServiceCommercialCredit =>
                    "visa_service_commercial_credit",
                CardRefundSchemeFeeFeeType.VisaAdvertisingServiceCommercialCredit =>
                    "visa_advertising_service_commercial_credit",
                CardRefundSchemeFeeFeeType.VisaCommunityGrowthAccelerationProgram =>
                    "visa_community_growth_acceleration_program",
                CardRefundSchemeFeeFeeType.VisaProcessingGuaranteeCommercialCredit =>
                    "visa_processing_guarantee_commercial_credit",
                CardRefundSchemeFeeFeeType.PulseSwitchFee => "pulse_switch_fee",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_refund`.
/// </summary>
[JsonConverter(typeof(CardRefundTypeConverter))]
public enum CardRefundType
{
    CardRefund,
}

sealed class CardRefundTypeConverter : JsonConverter<CardRefundType>
{
    public override CardRefundType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_refund" => CardRefundType.CardRefund,
            _ => (CardRefundType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardRefundType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardRefundType.CardRefund => "card_refund",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Card Revenue Payment object. This field will be present in the JSON response
/// if and only if `category` is equal to `card_revenue_payment`. Card Revenue Payments
/// reflect earnings from fees on card transactions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardRevenuePayment, CardRevenuePaymentFromRaw>))]
public sealed record class CardRevenuePayment : JsonModel
{
    /// <summary>
    /// The amount in the minor unit of the transaction's currency. For dollars,
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction currency.
    /// </summary>
    public required ApiEnum<string, CardRevenuePaymentCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardRevenuePaymentCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The end of the period for which this transaction paid interest.
    /// </summary>
    public required System::DateTimeOffset PeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("period_end");
        }
        init { this._rawData.Set("period_end", value); }
    }

    /// <summary>
    /// The start of the period for which this transaction paid interest.
    /// </summary>
    public required System::DateTimeOffset PeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("period_start");
        }
        init { this._rawData.Set("period_start", value); }
    }

    /// <summary>
    /// The account the card belonged to.
    /// </summary>
    public required string? TransactedOnAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transacted_on_account_id");
        }
        init { this._rawData.Set("transacted_on_account_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
        _ = this.PeriodEnd;
        _ = this.PeriodStart;
        _ = this.TransactedOnAccountID;
    }

    public CardRevenuePayment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardRevenuePayment(CardRevenuePayment cardRevenuePayment)
        : base(cardRevenuePayment) { }
#pragma warning restore CS8618

    public CardRevenuePayment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardRevenuePayment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardRevenuePaymentFromRaw.FromRawUnchecked"/>
    public static CardRevenuePayment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardRevenuePaymentFromRaw : IFromRawJson<CardRevenuePayment>
{
    /// <inheritdoc/>
    public CardRevenuePayment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardRevenuePayment.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction currency.
/// </summary>
[JsonConverter(typeof(CardRevenuePaymentCurrencyConverter))]
public enum CardRevenuePaymentCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardRevenuePaymentCurrencyConverter : JsonConverter<CardRevenuePaymentCurrency>
{
    public override CardRevenuePaymentCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardRevenuePaymentCurrency.Usd,
            _ => (CardRevenuePaymentCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardRevenuePaymentCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardRevenuePaymentCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Card Settlement object. This field will be present in the JSON response if
/// and only if `category` is equal to `card_settlement`. Card Settlements are card
/// transactions that have cleared and settled. While a settlement is usually preceded
/// by an authorization, an acquirer can also directly clear a transaction without
/// first authorizing it.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardSettlement, CardSettlementFromRaw>))]
public sealed record class CardSettlement : JsonModel
{
    /// <summary>
    /// The Card Settlement identifier.
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
    /// The amount in the minor unit of the transaction's settlement currency. For
    /// dollars, for example, this is cents.
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
    /// The Card Authorization that was created prior to this Card Settlement, if
    /// one exists.
    /// </summary>
    public required string? CardAuthorization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("card_authorization");
        }
        init { this._rawData.Set("card_authorization", value); }
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
    /// Cashback earned on this transaction, if eligible. Cashback is paid out in
    /// aggregate, monthly.
    /// </summary>
    public required CardSettlementCashback? Cashback
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardSettlementCashback>("cashback");
        }
        init { this._rawData.Set("cashback", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's
    /// settlement currency.
    /// </summary>
    public required ApiEnum<string, CardSettlementCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardSettlementCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Interchange assessed as a part of this transaction.
    /// </summary>
    public required CardSettlementInterchange? Interchange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardSettlementInterchange>("interchange");
        }
        init { this._rawData.Set("interchange", value); }
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
    /// The 4-digit MCC describing the merchant's business.
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
    public required string MerchantCity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_city");
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
    /// The name of the merchant.
    /// </summary>
    public required string MerchantName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_name");
        }
        init { this._rawData.Set("merchant_name", value); }
    }

    /// <summary>
    /// The merchant's postal code. For US merchants this is always a 5-digit ZIP code.
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
    /// The card network on which this transaction was processed.
    /// </summary>
    public required ApiEnum<string, CardSettlementNetwork> Network
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardSettlementNetwork>>("network");
        }
        init { this._rawData.Set("network", value); }
    }

    /// <summary>
    /// Network-specific identifiers for this refund.
    /// </summary>
    public required CardSettlementNetworkIdentifiers NetworkIdentifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardSettlementNetworkIdentifiers>(
                "network_identifiers"
            );
        }
        init { this._rawData.Set("network_identifiers", value); }
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
    /// The amount in the minor unit of the transaction's presentment currency.
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
    /// Additional details about the card purchase, such as tax and industry-specific fields.
    /// </summary>
    public required CardSettlementPurchaseDetails? PurchaseDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardSettlementPurchaseDetails>(
                "purchase_details"
            );
        }
        init { this._rawData.Set("purchase_details", value); }
    }

    /// <summary>
    /// The scheme fees associated with this card settlement.
    /// </summary>
    public required IReadOnlyList<CardSettlementSchemeFee> SchemeFees
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CardSettlementSchemeFee>>(
                "scheme_fees"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardSettlementSchemeFee>>(
                "scheme_fees",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Surcharge amount details, if applicable. The amount is positive if the surcharge
    /// is added to the overall transaction amount (surcharge), and negative if the
    /// surcharge is deducted from the overall transaction amount (discount).
    /// </summary>
    public required CardSettlementSurcharge? Surcharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardSettlementSurcharge>("surcharge");
        }
        init { this._rawData.Set("surcharge", value); }
    }

    /// <summary>
    /// The identifier of the Transaction associated with this Transaction.
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

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `card_settlement`.
    /// </summary>
    public required ApiEnum<string, CardSettlementType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardSettlementType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.CardAuthorization;
        _ = this.CardPaymentID;
        this.Cashback?.Validate();
        this.Currency.Validate();
        this.Interchange?.Validate();
        _ = this.MerchantAcceptorID;
        _ = this.MerchantCategoryCode;
        _ = this.MerchantCity;
        _ = this.MerchantCountry;
        _ = this.MerchantName;
        _ = this.MerchantPostalCode;
        _ = this.MerchantState;
        this.Network.Validate();
        this.NetworkIdentifiers.Validate();
        _ = this.PendingTransactionID;
        _ = this.PresentmentAmount;
        _ = this.PresentmentCurrency;
        this.PurchaseDetails?.Validate();
        foreach (var item in this.SchemeFees)
        {
            item.Validate();
        }
        this.Surcharge?.Validate();
        _ = this.TransactionID;
        this.Type.Validate();
    }

    public CardSettlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardSettlement(CardSettlement cardSettlement)
        : base(cardSettlement) { }
#pragma warning restore CS8618

    public CardSettlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardSettlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardSettlementFromRaw.FromRawUnchecked"/>
    public static CardSettlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardSettlementFromRaw : IFromRawJson<CardSettlement>
{
    /// <inheritdoc/>
    public CardSettlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardSettlement.FromRawUnchecked(rawData);
}

/// <summary>
/// Cashback earned on this transaction, if eligible. Cashback is paid out in aggregate, monthly.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardSettlementCashback, CardSettlementCashbackFromRaw>))]
public sealed record class CardSettlementCashback : JsonModel
{
    /// <summary>
    /// The cashback amount given as a string containing a decimal number. The amount
    /// is a positive number if it will be credited to you (e.g., settlements) and
    /// a negative number if it will be debited (e.g., refunds).
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the cashback.
    /// </summary>
    public required ApiEnum<string, CardSettlementCashbackCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardSettlementCashbackCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
    }

    public CardSettlementCashback() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardSettlementCashback(CardSettlementCashback cardSettlementCashback)
        : base(cardSettlementCashback) { }
#pragma warning restore CS8618

    public CardSettlementCashback(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardSettlementCashback(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardSettlementCashbackFromRaw.FromRawUnchecked"/>
    public static CardSettlementCashback FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardSettlementCashbackFromRaw : IFromRawJson<CardSettlementCashback>
{
    /// <inheritdoc/>
    public CardSettlementCashback FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardSettlementCashback.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the cashback.
/// </summary>
[JsonConverter(typeof(CardSettlementCashbackCurrencyConverter))]
public enum CardSettlementCashbackCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardSettlementCashbackCurrencyConverter : JsonConverter<CardSettlementCashbackCurrency>
{
    public override CardSettlementCashbackCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardSettlementCashbackCurrency.Usd,
            _ => (CardSettlementCashbackCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementCashbackCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementCashbackCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's
/// settlement currency.
/// </summary>
[JsonConverter(typeof(CardSettlementCurrencyConverter))]
public enum CardSettlementCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardSettlementCurrencyConverter : JsonConverter<CardSettlementCurrency>
{
    public override CardSettlementCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardSettlementCurrency.Usd,
            _ => (CardSettlementCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Interchange assessed as a part of this transaction.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CardSettlementInterchange, CardSettlementInterchangeFromRaw>)
)]
public sealed record class CardSettlementInterchange : JsonModel
{
    /// <summary>
    /// The interchange amount given as a string containing a decimal number in major
    /// units (so e.g., "3.14" for $3.14). The amount is a positive number if it is
    /// credited to Increase (e.g., settlements) and a negative number if it is debited
    /// (e.g., refunds).
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
    /// The card network specific interchange code.
    /// </summary>
    public required string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the interchange reimbursement.
    /// </summary>
    public required ApiEnum<string, CardSettlementInterchangeCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardSettlementInterchangeCurrency>
            >("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Code;
        this.Currency.Validate();
    }

    public CardSettlementInterchange() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardSettlementInterchange(CardSettlementInterchange cardSettlementInterchange)
        : base(cardSettlementInterchange) { }
#pragma warning restore CS8618

    public CardSettlementInterchange(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardSettlementInterchange(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardSettlementInterchangeFromRaw.FromRawUnchecked"/>
    public static CardSettlementInterchange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardSettlementInterchangeFromRaw : IFromRawJson<CardSettlementInterchange>
{
    /// <inheritdoc/>
    public CardSettlementInterchange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardSettlementInterchange.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the interchange reimbursement.
/// </summary>
[JsonConverter(typeof(CardSettlementInterchangeCurrencyConverter))]
public enum CardSettlementInterchangeCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardSettlementInterchangeCurrencyConverter
    : JsonConverter<CardSettlementInterchangeCurrency>
{
    public override CardSettlementInterchangeCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardSettlementInterchangeCurrency.Usd,
            _ => (CardSettlementInterchangeCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementInterchangeCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementInterchangeCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The card network on which this transaction was processed.
/// </summary>
[JsonConverter(typeof(CardSettlementNetworkConverter))]
public enum CardSettlementNetwork
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

sealed class CardSettlementNetworkConverter : JsonConverter<CardSettlementNetwork>
{
    public override CardSettlementNetwork Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => CardSettlementNetwork.Visa,
            "pulse" => CardSettlementNetwork.Pulse,
            _ => (CardSettlementNetwork)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementNetwork value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementNetwork.Visa => "visa",
                CardSettlementNetwork.Pulse => "pulse",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Network-specific identifiers for this refund.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardSettlementNetworkIdentifiers,
        CardSettlementNetworkIdentifiersFromRaw
    >)
)]
public sealed record class CardSettlementNetworkIdentifiers : JsonModel
{
    /// <summary>
    /// A network assigned business ID that identifies the acquirer that processed
    /// this transaction.
    /// </summary>
    public required string AcquirerBusinessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("acquirer_business_id");
        }
        init { this._rawData.Set("acquirer_business_id", value); }
    }

    /// <summary>
    /// A globally unique identifier for this settlement.
    /// </summary>
    public required string AcquirerReferenceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("acquirer_reference_number");
        }
        init { this._rawData.Set("acquirer_reference_number", value); }
    }

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
        _ = this.AcquirerBusinessID;
        _ = this.AcquirerReferenceNumber;
        _ = this.AuthorizationIdentificationResponse;
        _ = this.TransactionID;
    }

    public CardSettlementNetworkIdentifiers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardSettlementNetworkIdentifiers(
        CardSettlementNetworkIdentifiers cardSettlementNetworkIdentifiers
    )
        : base(cardSettlementNetworkIdentifiers) { }
#pragma warning restore CS8618

    public CardSettlementNetworkIdentifiers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardSettlementNetworkIdentifiers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardSettlementNetworkIdentifiersFromRaw.FromRawUnchecked"/>
    public static CardSettlementNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardSettlementNetworkIdentifiersFromRaw : IFromRawJson<CardSettlementNetworkIdentifiers>
{
    /// <inheritdoc/>
    public CardSettlementNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardSettlementNetworkIdentifiers.FromRawUnchecked(rawData);
}

/// <summary>
/// Additional details about the card purchase, such as tax and industry-specific fields.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CardSettlementPurchaseDetails, CardSettlementPurchaseDetailsFromRaw>)
)]
public sealed record class CardSettlementPurchaseDetails : JsonModel
{
    /// <summary>
    /// Fields specific to car rentals.
    /// </summary>
    public required CardSettlementPurchaseDetailsCarRental? CarRental
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardSettlementPurchaseDetailsCarRental>(
                "car_rental"
            );
        }
        init { this._rawData.Set("car_rental", value); }
    }

    /// <summary>
    /// An identifier from the merchant for the customer or consumer.
    /// </summary>
    public required string? CustomerReferenceIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customer_reference_identifier");
        }
        init { this._rawData.Set("customer_reference_identifier", value); }
    }

    /// <summary>
    /// The state or provincial tax amount in minor units.
    /// </summary>
    public required long? LocalTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("local_tax_amount");
        }
        init { this._rawData.Set("local_tax_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the local
    /// tax assessed.
    /// </summary>
    public required string? LocalTaxCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("local_tax_currency");
        }
        init { this._rawData.Set("local_tax_currency", value); }
    }

    /// <summary>
    /// Fields specific to lodging.
    /// </summary>
    public required CardSettlementPurchaseDetailsLodging? Lodging
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardSettlementPurchaseDetailsLodging>("lodging");
        }
        init { this._rawData.Set("lodging", value); }
    }

    /// <summary>
    /// The national tax amount in minor units.
    /// </summary>
    public required long? NationalTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("national_tax_amount");
        }
        init { this._rawData.Set("national_tax_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the local
    /// tax assessed.
    /// </summary>
    public required string? NationalTaxCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("national_tax_currency");
        }
        init { this._rawData.Set("national_tax_currency", value); }
    }

    /// <summary>
    /// An identifier from the merchant for the purchase to the issuer and cardholder.
    /// </summary>
    public required string? PurchaseIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("purchase_identifier");
        }
        init { this._rawData.Set("purchase_identifier", value); }
    }

    /// <summary>
    /// The format of the purchase identifier.
    /// </summary>
    public required ApiEnum<
        string,
        CardSettlementPurchaseDetailsPurchaseIdentifierFormat
    >? PurchaseIdentifierFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardSettlementPurchaseDetailsPurchaseIdentifierFormat>
            >("purchase_identifier_format");
        }
        init { this._rawData.Set("purchase_identifier_format", value); }
    }

    /// <summary>
    /// Fields specific to travel.
    /// </summary>
    public required CardSettlementPurchaseDetailsTravel? Travel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardSettlementPurchaseDetailsTravel>("travel");
        }
        init { this._rawData.Set("travel", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CarRental?.Validate();
        _ = this.CustomerReferenceIdentifier;
        _ = this.LocalTaxAmount;
        _ = this.LocalTaxCurrency;
        this.Lodging?.Validate();
        _ = this.NationalTaxAmount;
        _ = this.NationalTaxCurrency;
        _ = this.PurchaseIdentifier;
        this.PurchaseIdentifierFormat?.Validate();
        this.Travel?.Validate();
    }

    public CardSettlementPurchaseDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardSettlementPurchaseDetails(
        CardSettlementPurchaseDetails cardSettlementPurchaseDetails
    )
        : base(cardSettlementPurchaseDetails) { }
#pragma warning restore CS8618

    public CardSettlementPurchaseDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardSettlementPurchaseDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardSettlementPurchaseDetailsFromRaw.FromRawUnchecked"/>
    public static CardSettlementPurchaseDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardSettlementPurchaseDetailsFromRaw : IFromRawJson<CardSettlementPurchaseDetails>
{
    /// <inheritdoc/>
    public CardSettlementPurchaseDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardSettlementPurchaseDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields specific to car rentals.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardSettlementPurchaseDetailsCarRental,
        CardSettlementPurchaseDetailsCarRentalFromRaw
    >)
)]
public sealed record class CardSettlementPurchaseDetailsCarRental : JsonModel
{
    /// <summary>
    /// Code indicating the vehicle's class.
    /// </summary>
    public required string? CarClassCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("car_class_code");
        }
        init { this._rawData.Set("car_class_code", value); }
    }

    /// <summary>
    /// Date the customer picked up the car or, in the case of a no-show or pre-pay
    /// transaction, the scheduled pick up date.
    /// </summary>
    public required string? CheckoutDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("checkout_date");
        }
        init { this._rawData.Set("checkout_date", value); }
    }

    /// <summary>
    /// Daily rate being charged for the vehicle.
    /// </summary>
    public required long? DailyRentalRateAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("daily_rental_rate_amount");
        }
        init { this._rawData.Set("daily_rental_rate_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the daily
    /// rental rate.
    /// </summary>
    public required string? DailyRentalRateCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("daily_rental_rate_currency");
        }
        init { this._rawData.Set("daily_rental_rate_currency", value); }
    }

    /// <summary>
    /// Number of days the vehicle was rented.
    /// </summary>
    public required long? DaysRented
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("days_rented");
        }
        init { this._rawData.Set("days_rented", value); }
    }

    /// <summary>
    /// Additional charges (gas, late fee, etc.) being billed.
    /// </summary>
    public required ApiEnum<
        string,
        CardSettlementPurchaseDetailsCarRentalExtraCharges
    >? ExtraCharges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardSettlementPurchaseDetailsCarRentalExtraCharges>
            >("extra_charges");
        }
        init { this._rawData.Set("extra_charges", value); }
    }

    /// <summary>
    /// Fuel charges for the vehicle.
    /// </summary>
    public required long? FuelChargesAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("fuel_charges_amount");
        }
        init { this._rawData.Set("fuel_charges_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the fuel charges assessed.
    /// </summary>
    public required string? FuelChargesCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fuel_charges_currency");
        }
        init { this._rawData.Set("fuel_charges_currency", value); }
    }

    /// <summary>
    /// Any insurance being charged for the vehicle.
    /// </summary>
    public required long? InsuranceChargesAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("insurance_charges_amount");
        }
        init { this._rawData.Set("insurance_charges_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the insurance
    /// charges assessed.
    /// </summary>
    public required string? InsuranceChargesCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("insurance_charges_currency");
        }
        init { this._rawData.Set("insurance_charges_currency", value); }
    }

    /// <summary>
    /// An indicator that the cardholder is being billed for a reserved vehicle that
    /// was not actually rented (that is, a "no-show" charge).
    /// </summary>
    public required ApiEnum<
        string,
        CardSettlementPurchaseDetailsCarRentalNoShowIndicator
    >? NoShowIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardSettlementPurchaseDetailsCarRentalNoShowIndicator>
            >("no_show_indicator");
        }
        init { this._rawData.Set("no_show_indicator", value); }
    }

    /// <summary>
    /// Charges for returning the vehicle at a different location than where it was
    /// picked up.
    /// </summary>
    public required long? OneWayDropOffChargesAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("one_way_drop_off_charges_amount");
        }
        init { this._rawData.Set("one_way_drop_off_charges_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the one-way
    /// drop-off charges assessed.
    /// </summary>
    public required string? OneWayDropOffChargesCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("one_way_drop_off_charges_currency");
        }
        init { this._rawData.Set("one_way_drop_off_charges_currency", value); }
    }

    /// <summary>
    /// Name of the person renting the vehicle.
    /// </summary>
    public required string? RenterName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("renter_name");
        }
        init { this._rawData.Set("renter_name", value); }
    }

    /// <summary>
    /// Weekly rate being charged for the vehicle.
    /// </summary>
    public required long? WeeklyRentalRateAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("weekly_rental_rate_amount");
        }
        init { this._rawData.Set("weekly_rental_rate_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the weekly
    /// rental rate.
    /// </summary>
    public required string? WeeklyRentalRateCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("weekly_rental_rate_currency");
        }
        init { this._rawData.Set("weekly_rental_rate_currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CarClassCode;
        _ = this.CheckoutDate;
        _ = this.DailyRentalRateAmount;
        _ = this.DailyRentalRateCurrency;
        _ = this.DaysRented;
        this.ExtraCharges?.Validate();
        _ = this.FuelChargesAmount;
        _ = this.FuelChargesCurrency;
        _ = this.InsuranceChargesAmount;
        _ = this.InsuranceChargesCurrency;
        this.NoShowIndicator?.Validate();
        _ = this.OneWayDropOffChargesAmount;
        _ = this.OneWayDropOffChargesCurrency;
        _ = this.RenterName;
        _ = this.WeeklyRentalRateAmount;
        _ = this.WeeklyRentalRateCurrency;
    }

    public CardSettlementPurchaseDetailsCarRental() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardSettlementPurchaseDetailsCarRental(
        CardSettlementPurchaseDetailsCarRental cardSettlementPurchaseDetailsCarRental
    )
        : base(cardSettlementPurchaseDetailsCarRental) { }
#pragma warning restore CS8618

    public CardSettlementPurchaseDetailsCarRental(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardSettlementPurchaseDetailsCarRental(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardSettlementPurchaseDetailsCarRentalFromRaw.FromRawUnchecked"/>
    public static CardSettlementPurchaseDetailsCarRental FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardSettlementPurchaseDetailsCarRentalFromRaw
    : IFromRawJson<CardSettlementPurchaseDetailsCarRental>
{
    /// <inheritdoc/>
    public CardSettlementPurchaseDetailsCarRental FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardSettlementPurchaseDetailsCarRental.FromRawUnchecked(rawData);
}

/// <summary>
/// Additional charges (gas, late fee, etc.) being billed.
/// </summary>
[JsonConverter(typeof(CardSettlementPurchaseDetailsCarRentalExtraChargesConverter))]
public enum CardSettlementPurchaseDetailsCarRentalExtraCharges
{
    /// <summary>
    /// No extra charge
    /// </summary>
    NoExtraCharge,

    /// <summary>
    /// Gas
    /// </summary>
    Gas,

    /// <summary>
    /// Extra mileage
    /// </summary>
    ExtraMileage,

    /// <summary>
    /// Late return
    /// </summary>
    LateReturn,

    /// <summary>
    /// One way service fee
    /// </summary>
    OneWayServiceFee,

    /// <summary>
    /// Parking violation
    /// </summary>
    ParkingViolation,
}

sealed class CardSettlementPurchaseDetailsCarRentalExtraChargesConverter
    : JsonConverter<CardSettlementPurchaseDetailsCarRentalExtraCharges>
{
    public override CardSettlementPurchaseDetailsCarRentalExtraCharges Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no_extra_charge" => CardSettlementPurchaseDetailsCarRentalExtraCharges.NoExtraCharge,
            "gas" => CardSettlementPurchaseDetailsCarRentalExtraCharges.Gas,
            "extra_mileage" => CardSettlementPurchaseDetailsCarRentalExtraCharges.ExtraMileage,
            "late_return" => CardSettlementPurchaseDetailsCarRentalExtraCharges.LateReturn,
            "one_way_service_fee" =>
                CardSettlementPurchaseDetailsCarRentalExtraCharges.OneWayServiceFee,
            "parking_violation" =>
                CardSettlementPurchaseDetailsCarRentalExtraCharges.ParkingViolation,
            _ => (CardSettlementPurchaseDetailsCarRentalExtraCharges)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementPurchaseDetailsCarRentalExtraCharges value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementPurchaseDetailsCarRentalExtraCharges.NoExtraCharge =>
                    "no_extra_charge",
                CardSettlementPurchaseDetailsCarRentalExtraCharges.Gas => "gas",
                CardSettlementPurchaseDetailsCarRentalExtraCharges.ExtraMileage => "extra_mileage",
                CardSettlementPurchaseDetailsCarRentalExtraCharges.LateReturn => "late_return",
                CardSettlementPurchaseDetailsCarRentalExtraCharges.OneWayServiceFee =>
                    "one_way_service_fee",
                CardSettlementPurchaseDetailsCarRentalExtraCharges.ParkingViolation =>
                    "parking_violation",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An indicator that the cardholder is being billed for a reserved vehicle that was
/// not actually rented (that is, a "no-show" charge).
/// </summary>
[JsonConverter(typeof(CardSettlementPurchaseDetailsCarRentalNoShowIndicatorConverter))]
public enum CardSettlementPurchaseDetailsCarRentalNoShowIndicator
{
    /// <summary>
    /// Not applicable
    /// </summary>
    NotApplicable,

    /// <summary>
    /// No show for specialized vehicle
    /// </summary>
    NoShowForSpecializedVehicle,
}

sealed class CardSettlementPurchaseDetailsCarRentalNoShowIndicatorConverter
    : JsonConverter<CardSettlementPurchaseDetailsCarRentalNoShowIndicator>
{
    public override CardSettlementPurchaseDetailsCarRentalNoShowIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_applicable" => CardSettlementPurchaseDetailsCarRentalNoShowIndicator.NotApplicable,
            "no_show_for_specialized_vehicle" =>
                CardSettlementPurchaseDetailsCarRentalNoShowIndicator.NoShowForSpecializedVehicle,
            _ => (CardSettlementPurchaseDetailsCarRentalNoShowIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementPurchaseDetailsCarRentalNoShowIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementPurchaseDetailsCarRentalNoShowIndicator.NotApplicable =>
                    "not_applicable",
                CardSettlementPurchaseDetailsCarRentalNoShowIndicator.NoShowForSpecializedVehicle =>
                    "no_show_for_specialized_vehicle",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to lodging.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardSettlementPurchaseDetailsLodging,
        CardSettlementPurchaseDetailsLodgingFromRaw
    >)
)]
public sealed record class CardSettlementPurchaseDetailsLodging : JsonModel
{
    /// <summary>
    /// Date the customer checked in.
    /// </summary>
    public required string? CheckInDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("check_in_date");
        }
        init { this._rawData.Set("check_in_date", value); }
    }

    /// <summary>
    /// Daily rate being charged for the room.
    /// </summary>
    public required long? DailyRoomRateAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("daily_room_rate_amount");
        }
        init { this._rawData.Set("daily_room_rate_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the daily
    /// room rate.
    /// </summary>
    public required string? DailyRoomRateCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("daily_room_rate_currency");
        }
        init { this._rawData.Set("daily_room_rate_currency", value); }
    }

    /// <summary>
    /// Additional charges (phone, late check-out, etc.) being billed.
    /// </summary>
    public required ApiEnum<string, CardSettlementPurchaseDetailsLodgingExtraCharges>? ExtraCharges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardSettlementPurchaseDetailsLodgingExtraCharges>
            >("extra_charges");
        }
        init { this._rawData.Set("extra_charges", value); }
    }

    /// <summary>
    /// Folio cash advances for the room.
    /// </summary>
    public required long? FolioCashAdvancesAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("folio_cash_advances_amount");
        }
        init { this._rawData.Set("folio_cash_advances_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the folio
    /// cash advances.
    /// </summary>
    public required string? FolioCashAdvancesCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("folio_cash_advances_currency");
        }
        init { this._rawData.Set("folio_cash_advances_currency", value); }
    }

    /// <summary>
    /// Food and beverage charges for the room.
    /// </summary>
    public required long? FoodBeverageChargesAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("food_beverage_charges_amount");
        }
        init { this._rawData.Set("food_beverage_charges_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the food and
    /// beverage charges.
    /// </summary>
    public required string? FoodBeverageChargesCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("food_beverage_charges_currency");
        }
        init { this._rawData.Set("food_beverage_charges_currency", value); }
    }

    /// <summary>
    /// Indicator that the cardholder is being billed for a reserved room that was
    /// not actually used.
    /// </summary>
    public required ApiEnum<
        string,
        CardSettlementPurchaseDetailsLodgingNoShowIndicator
    >? NoShowIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardSettlementPurchaseDetailsLodgingNoShowIndicator>
            >("no_show_indicator");
        }
        init { this._rawData.Set("no_show_indicator", value); }
    }

    /// <summary>
    /// Prepaid expenses being charged for the room.
    /// </summary>
    public required long? PrepaidExpensesAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("prepaid_expenses_amount");
        }
        init { this._rawData.Set("prepaid_expenses_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the prepaid expenses.
    /// </summary>
    public required string? PrepaidExpensesCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prepaid_expenses_currency");
        }
        init { this._rawData.Set("prepaid_expenses_currency", value); }
    }

    /// <summary>
    /// Number of nights the room was rented.
    /// </summary>
    public required long? RoomNights
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("room_nights");
        }
        init { this._rawData.Set("room_nights", value); }
    }

    /// <summary>
    /// Total room tax being charged.
    /// </summary>
    public required long? TotalRoomTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_room_tax_amount");
        }
        init { this._rawData.Set("total_room_tax_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the total
    /// room tax.
    /// </summary>
    public required string? TotalRoomTaxCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("total_room_tax_currency");
        }
        init { this._rawData.Set("total_room_tax_currency", value); }
    }

    /// <summary>
    /// Total tax being charged for the room.
    /// </summary>
    public required long? TotalTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_tax_amount");
        }
        init { this._rawData.Set("total_tax_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the total
    /// tax assessed.
    /// </summary>
    public required string? TotalTaxCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("total_tax_currency");
        }
        init { this._rawData.Set("total_tax_currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CheckInDate;
        _ = this.DailyRoomRateAmount;
        _ = this.DailyRoomRateCurrency;
        this.ExtraCharges?.Validate();
        _ = this.FolioCashAdvancesAmount;
        _ = this.FolioCashAdvancesCurrency;
        _ = this.FoodBeverageChargesAmount;
        _ = this.FoodBeverageChargesCurrency;
        this.NoShowIndicator?.Validate();
        _ = this.PrepaidExpensesAmount;
        _ = this.PrepaidExpensesCurrency;
        _ = this.RoomNights;
        _ = this.TotalRoomTaxAmount;
        _ = this.TotalRoomTaxCurrency;
        _ = this.TotalTaxAmount;
        _ = this.TotalTaxCurrency;
    }

    public CardSettlementPurchaseDetailsLodging() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardSettlementPurchaseDetailsLodging(
        CardSettlementPurchaseDetailsLodging cardSettlementPurchaseDetailsLodging
    )
        : base(cardSettlementPurchaseDetailsLodging) { }
#pragma warning restore CS8618

    public CardSettlementPurchaseDetailsLodging(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardSettlementPurchaseDetailsLodging(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardSettlementPurchaseDetailsLodgingFromRaw.FromRawUnchecked"/>
    public static CardSettlementPurchaseDetailsLodging FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardSettlementPurchaseDetailsLodgingFromRaw
    : IFromRawJson<CardSettlementPurchaseDetailsLodging>
{
    /// <inheritdoc/>
    public CardSettlementPurchaseDetailsLodging FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardSettlementPurchaseDetailsLodging.FromRawUnchecked(rawData);
}

/// <summary>
/// Additional charges (phone, late check-out, etc.) being billed.
/// </summary>
[JsonConverter(typeof(CardSettlementPurchaseDetailsLodgingExtraChargesConverter))]
public enum CardSettlementPurchaseDetailsLodgingExtraCharges
{
    /// <summary>
    /// No extra charge
    /// </summary>
    NoExtraCharge,

    /// <summary>
    /// Restaurant
    /// </summary>
    Restaurant,

    /// <summary>
    /// Gift shop
    /// </summary>
    GiftShop,

    /// <summary>
    /// Mini bar
    /// </summary>
    MiniBar,

    /// <summary>
    /// Telephone
    /// </summary>
    Telephone,

    /// <summary>
    /// Other
    /// </summary>
    Other,

    /// <summary>
    /// Laundry
    /// </summary>
    Laundry,
}

sealed class CardSettlementPurchaseDetailsLodgingExtraChargesConverter
    : JsonConverter<CardSettlementPurchaseDetailsLodgingExtraCharges>
{
    public override CardSettlementPurchaseDetailsLodgingExtraCharges Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no_extra_charge" => CardSettlementPurchaseDetailsLodgingExtraCharges.NoExtraCharge,
            "restaurant" => CardSettlementPurchaseDetailsLodgingExtraCharges.Restaurant,
            "gift_shop" => CardSettlementPurchaseDetailsLodgingExtraCharges.GiftShop,
            "mini_bar" => CardSettlementPurchaseDetailsLodgingExtraCharges.MiniBar,
            "telephone" => CardSettlementPurchaseDetailsLodgingExtraCharges.Telephone,
            "other" => CardSettlementPurchaseDetailsLodgingExtraCharges.Other,
            "laundry" => CardSettlementPurchaseDetailsLodgingExtraCharges.Laundry,
            _ => (CardSettlementPurchaseDetailsLodgingExtraCharges)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementPurchaseDetailsLodgingExtraCharges value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementPurchaseDetailsLodgingExtraCharges.NoExtraCharge => "no_extra_charge",
                CardSettlementPurchaseDetailsLodgingExtraCharges.Restaurant => "restaurant",
                CardSettlementPurchaseDetailsLodgingExtraCharges.GiftShop => "gift_shop",
                CardSettlementPurchaseDetailsLodgingExtraCharges.MiniBar => "mini_bar",
                CardSettlementPurchaseDetailsLodgingExtraCharges.Telephone => "telephone",
                CardSettlementPurchaseDetailsLodgingExtraCharges.Other => "other",
                CardSettlementPurchaseDetailsLodgingExtraCharges.Laundry => "laundry",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Indicator that the cardholder is being billed for a reserved room that was not
/// actually used.
/// </summary>
[JsonConverter(typeof(CardSettlementPurchaseDetailsLodgingNoShowIndicatorConverter))]
public enum CardSettlementPurchaseDetailsLodgingNoShowIndicator
{
    /// <summary>
    /// Not applicable
    /// </summary>
    NotApplicable,

    /// <summary>
    /// No show
    /// </summary>
    NoShow,
}

sealed class CardSettlementPurchaseDetailsLodgingNoShowIndicatorConverter
    : JsonConverter<CardSettlementPurchaseDetailsLodgingNoShowIndicator>
{
    public override CardSettlementPurchaseDetailsLodgingNoShowIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_applicable" => CardSettlementPurchaseDetailsLodgingNoShowIndicator.NotApplicable,
            "no_show" => CardSettlementPurchaseDetailsLodgingNoShowIndicator.NoShow,
            _ => (CardSettlementPurchaseDetailsLodgingNoShowIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementPurchaseDetailsLodgingNoShowIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementPurchaseDetailsLodgingNoShowIndicator.NotApplicable =>
                    "not_applicable",
                CardSettlementPurchaseDetailsLodgingNoShowIndicator.NoShow => "no_show",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The format of the purchase identifier.
/// </summary>
[JsonConverter(typeof(CardSettlementPurchaseDetailsPurchaseIdentifierFormatConverter))]
public enum CardSettlementPurchaseDetailsPurchaseIdentifierFormat
{
    /// <summary>
    /// Free text
    /// </summary>
    FreeText,

    /// <summary>
    /// Order number
    /// </summary>
    OrderNumber,

    /// <summary>
    /// Rental agreement number
    /// </summary>
    RentalAgreementNumber,

    /// <summary>
    /// Hotel folio number
    /// </summary>
    HotelFolioNumber,

    /// <summary>
    /// Invoice number
    /// </summary>
    InvoiceNumber,
}

sealed class CardSettlementPurchaseDetailsPurchaseIdentifierFormatConverter
    : JsonConverter<CardSettlementPurchaseDetailsPurchaseIdentifierFormat>
{
    public override CardSettlementPurchaseDetailsPurchaseIdentifierFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "free_text" => CardSettlementPurchaseDetailsPurchaseIdentifierFormat.FreeText,
            "order_number" => CardSettlementPurchaseDetailsPurchaseIdentifierFormat.OrderNumber,
            "rental_agreement_number" =>
                CardSettlementPurchaseDetailsPurchaseIdentifierFormat.RentalAgreementNumber,
            "hotel_folio_number" =>
                CardSettlementPurchaseDetailsPurchaseIdentifierFormat.HotelFolioNumber,
            "invoice_number" => CardSettlementPurchaseDetailsPurchaseIdentifierFormat.InvoiceNumber,
            _ => (CardSettlementPurchaseDetailsPurchaseIdentifierFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementPurchaseDetailsPurchaseIdentifierFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementPurchaseDetailsPurchaseIdentifierFormat.FreeText => "free_text",
                CardSettlementPurchaseDetailsPurchaseIdentifierFormat.OrderNumber => "order_number",
                CardSettlementPurchaseDetailsPurchaseIdentifierFormat.RentalAgreementNumber =>
                    "rental_agreement_number",
                CardSettlementPurchaseDetailsPurchaseIdentifierFormat.HotelFolioNumber =>
                    "hotel_folio_number",
                CardSettlementPurchaseDetailsPurchaseIdentifierFormat.InvoiceNumber =>
                    "invoice_number",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to travel.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardSettlementPurchaseDetailsTravel,
        CardSettlementPurchaseDetailsTravelFromRaw
    >)
)]
public sealed record class CardSettlementPurchaseDetailsTravel : JsonModel
{
    /// <summary>
    /// Ancillary purchases in addition to the airfare.
    /// </summary>
    public required CardSettlementPurchaseDetailsTravelAncillary? Ancillary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardSettlementPurchaseDetailsTravelAncillary>(
                "ancillary"
            );
        }
        init { this._rawData.Set("ancillary", value); }
    }

    /// <summary>
    /// Indicates the computerized reservation system used to book the ticket.
    /// </summary>
    public required string? ComputerizedReservationSystem
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("computerized_reservation_system");
        }
        init { this._rawData.Set("computerized_reservation_system", value); }
    }

    /// <summary>
    /// Indicates the reason for a credit to the cardholder.
    /// </summary>
    public required ApiEnum<
        string,
        CardSettlementPurchaseDetailsTravelCreditReasonIndicator
    >? CreditReasonIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardSettlementPurchaseDetailsTravelCreditReasonIndicator>
            >("credit_reason_indicator");
        }
        init { this._rawData.Set("credit_reason_indicator", value); }
    }

    /// <summary>
    /// Date of departure.
    /// </summary>
    public required string? DepartureDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("departure_date");
        }
        init { this._rawData.Set("departure_date", value); }
    }

    /// <summary>
    /// Code for the originating city or airport.
    /// </summary>
    public required string? OriginationCityAirportCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("origination_city_airport_code");
        }
        init { this._rawData.Set("origination_city_airport_code", value); }
    }

    /// <summary>
    /// Name of the passenger.
    /// </summary>
    public required string? PassengerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("passenger_name");
        }
        init { this._rawData.Set("passenger_name", value); }
    }

    /// <summary>
    /// Indicates whether this ticket is non-refundable.
    /// </summary>
    public required ApiEnum<
        string,
        CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator
    >? RestrictedTicketIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator>
            >("restricted_ticket_indicator");
        }
        init { this._rawData.Set("restricted_ticket_indicator", value); }
    }

    /// <summary>
    /// Indicates why a ticket was changed.
    /// </summary>
    public required ApiEnum<
        string,
        CardSettlementPurchaseDetailsTravelTicketChangeIndicator
    >? TicketChangeIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardSettlementPurchaseDetailsTravelTicketChangeIndicator>
            >("ticket_change_indicator");
        }
        init { this._rawData.Set("ticket_change_indicator", value); }
    }

    /// <summary>
    /// Ticket number.
    /// </summary>
    public required string? TicketNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ticket_number");
        }
        init { this._rawData.Set("ticket_number", value); }
    }

    /// <summary>
    /// Code for the travel agency if the ticket was issued by a travel agency.
    /// </summary>
    public required string? TravelAgencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("travel_agency_code");
        }
        init { this._rawData.Set("travel_agency_code", value); }
    }

    /// <summary>
    /// Name of the travel agency if the ticket was issued by a travel agency.
    /// </summary>
    public required string? TravelAgencyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("travel_agency_name");
        }
        init { this._rawData.Set("travel_agency_name", value); }
    }

    /// <summary>
    /// Fields specific to each leg of the journey.
    /// </summary>
    public required IReadOnlyList<CardSettlementPurchaseDetailsTravelTripLeg>? TripLegs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardSettlementPurchaseDetailsTravelTripLeg>
            >("trip_legs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardSettlementPurchaseDetailsTravelTripLeg>?>(
                "trip_legs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Ancillary?.Validate();
        _ = this.ComputerizedReservationSystem;
        this.CreditReasonIndicator?.Validate();
        _ = this.DepartureDate;
        _ = this.OriginationCityAirportCode;
        _ = this.PassengerName;
        this.RestrictedTicketIndicator?.Validate();
        this.TicketChangeIndicator?.Validate();
        _ = this.TicketNumber;
        _ = this.TravelAgencyCode;
        _ = this.TravelAgencyName;
        foreach (var item in this.TripLegs ?? [])
        {
            item.Validate();
        }
    }

    public CardSettlementPurchaseDetailsTravel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardSettlementPurchaseDetailsTravel(
        CardSettlementPurchaseDetailsTravel cardSettlementPurchaseDetailsTravel
    )
        : base(cardSettlementPurchaseDetailsTravel) { }
#pragma warning restore CS8618

    public CardSettlementPurchaseDetailsTravel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardSettlementPurchaseDetailsTravel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardSettlementPurchaseDetailsTravelFromRaw.FromRawUnchecked"/>
    public static CardSettlementPurchaseDetailsTravel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardSettlementPurchaseDetailsTravelFromRaw : IFromRawJson<CardSettlementPurchaseDetailsTravel>
{
    /// <inheritdoc/>
    public CardSettlementPurchaseDetailsTravel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardSettlementPurchaseDetailsTravel.FromRawUnchecked(rawData);
}

/// <summary>
/// Ancillary purchases in addition to the airfare.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardSettlementPurchaseDetailsTravelAncillary,
        CardSettlementPurchaseDetailsTravelAncillaryFromRaw
    >)
)]
public sealed record class CardSettlementPurchaseDetailsTravelAncillary : JsonModel
{
    /// <summary>
    /// If this purchase has a connection or relationship to another purchase, such
    /// as a baggage fee for a passenger transport ticket, this field should contain
    /// the ticket document number for the other purchase.
    /// </summary>
    public required string? ConnectedTicketDocumentNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("connected_ticket_document_number");
        }
        init { this._rawData.Set("connected_ticket_document_number", value); }
    }

    /// <summary>
    /// Indicates the reason for a credit to the cardholder.
    /// </summary>
    public required ApiEnum<
        string,
        CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator
    >? CreditReasonIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator>
            >("credit_reason_indicator");
        }
        init { this._rawData.Set("credit_reason_indicator", value); }
    }

    /// <summary>
    /// Name of the passenger or description of the ancillary purchase.
    /// </summary>
    public required string? PassengerNameOrDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("passenger_name_or_description");
        }
        init { this._rawData.Set("passenger_name_or_description", value); }
    }

    /// <summary>
    /// Additional travel charges, such as baggage fees.
    /// </summary>
    public required IReadOnlyList<CardSettlementPurchaseDetailsTravelAncillaryService> Services
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<CardSettlementPurchaseDetailsTravelAncillaryService>
            >("services");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardSettlementPurchaseDetailsTravelAncillaryService>>(
                "services",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Ticket document number.
    /// </summary>
    public required string? TicketDocumentNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ticket_document_number");
        }
        init { this._rawData.Set("ticket_document_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConnectedTicketDocumentNumber;
        this.CreditReasonIndicator?.Validate();
        _ = this.PassengerNameOrDescription;
        foreach (var item in this.Services)
        {
            item.Validate();
        }
        _ = this.TicketDocumentNumber;
    }

    public CardSettlementPurchaseDetailsTravelAncillary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardSettlementPurchaseDetailsTravelAncillary(
        CardSettlementPurchaseDetailsTravelAncillary cardSettlementPurchaseDetailsTravelAncillary
    )
        : base(cardSettlementPurchaseDetailsTravelAncillary) { }
#pragma warning restore CS8618

    public CardSettlementPurchaseDetailsTravelAncillary(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardSettlementPurchaseDetailsTravelAncillary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardSettlementPurchaseDetailsTravelAncillaryFromRaw.FromRawUnchecked"/>
    public static CardSettlementPurchaseDetailsTravelAncillary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardSettlementPurchaseDetailsTravelAncillaryFromRaw
    : IFromRawJson<CardSettlementPurchaseDetailsTravelAncillary>
{
    /// <inheritdoc/>
    public CardSettlementPurchaseDetailsTravelAncillary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardSettlementPurchaseDetailsTravelAncillary.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates the reason for a credit to the cardholder.
/// </summary>
[JsonConverter(typeof(CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicatorConverter))]
public enum CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator
{
    /// <summary>
    /// No credit
    /// </summary>
    NoCredit,

    /// <summary>
    /// Passenger transport ancillary purchase cancellation
    /// </summary>
    PassengerTransportAncillaryPurchaseCancellation,

    /// <summary>
    /// Airline ticket and passenger transport ancillary purchase cancellation
    /// </summary>
    AirlineTicketAndPassengerTransportAncillaryPurchaseCancellation,

    /// <summary>
    /// Other
    /// </summary>
    Other,
}

sealed class CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicatorConverter
    : JsonConverter<CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator>
{
    public override CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no_credit" =>
                CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator.NoCredit,
            "passenger_transport_ancillary_purchase_cancellation" =>
                CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator.PassengerTransportAncillaryPurchaseCancellation,
            "airline_ticket_and_passenger_transport_ancillary_purchase_cancellation" =>
                CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator.AirlineTicketAndPassengerTransportAncillaryPurchaseCancellation,
            "other" => CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator.Other,
            _ => (CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator.NoCredit =>
                    "no_credit",
                CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator.PassengerTransportAncillaryPurchaseCancellation =>
                    "passenger_transport_ancillary_purchase_cancellation",
                CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator.AirlineTicketAndPassengerTransportAncillaryPurchaseCancellation =>
                    "airline_ticket_and_passenger_transport_ancillary_purchase_cancellation",
                CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardSettlementPurchaseDetailsTravelAncillaryService,
        CardSettlementPurchaseDetailsTravelAncillaryServiceFromRaw
    >)
)]
public sealed record class CardSettlementPurchaseDetailsTravelAncillaryService : JsonModel
{
    /// <summary>
    /// Category of the ancillary service.
    /// </summary>
    public required ApiEnum<
        string,
        CardSettlementPurchaseDetailsTravelAncillaryServiceCategory
    >? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardSettlementPurchaseDetailsTravelAncillaryServiceCategory>
            >("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Sub-category of the ancillary service, free-form.
    /// </summary>
    public required string? SubCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sub_category");
        }
        init { this._rawData.Set("sub_category", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category?.Validate();
        _ = this.SubCategory;
    }

    public CardSettlementPurchaseDetailsTravelAncillaryService() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardSettlementPurchaseDetailsTravelAncillaryService(
        CardSettlementPurchaseDetailsTravelAncillaryService cardSettlementPurchaseDetailsTravelAncillaryService
    )
        : base(cardSettlementPurchaseDetailsTravelAncillaryService) { }
#pragma warning restore CS8618

    public CardSettlementPurchaseDetailsTravelAncillaryService(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardSettlementPurchaseDetailsTravelAncillaryService(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardSettlementPurchaseDetailsTravelAncillaryServiceFromRaw.FromRawUnchecked"/>
    public static CardSettlementPurchaseDetailsTravelAncillaryService FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardSettlementPurchaseDetailsTravelAncillaryServiceFromRaw
    : IFromRawJson<CardSettlementPurchaseDetailsTravelAncillaryService>
{
    /// <inheritdoc/>
    public CardSettlementPurchaseDetailsTravelAncillaryService FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardSettlementPurchaseDetailsTravelAncillaryService.FromRawUnchecked(rawData);
}

/// <summary>
/// Category of the ancillary service.
/// </summary>
[JsonConverter(typeof(CardSettlementPurchaseDetailsTravelAncillaryServiceCategoryConverter))]
public enum CardSettlementPurchaseDetailsTravelAncillaryServiceCategory
{
    /// <summary>
    /// None
    /// </summary>
    None,

    /// <summary>
    /// Bundled service
    /// </summary>
    BundledService,

    /// <summary>
    /// Baggage fee
    /// </summary>
    BaggageFee,

    /// <summary>
    /// Change fee
    /// </summary>
    ChangeFee,

    /// <summary>
    /// Cargo
    /// </summary>
    Cargo,

    /// <summary>
    /// Carbon offset
    /// </summary>
    CarbonOffset,

    /// <summary>
    /// Frequent flyer
    /// </summary>
    FrequentFlyer,

    /// <summary>
    /// Gift card
    /// </summary>
    GiftCard,

    /// <summary>
    /// Ground transport
    /// </summary>
    GroundTransport,

    /// <summary>
    /// In-flight entertainment
    /// </summary>
    InFlightEntertainment,

    /// <summary>
    /// Lounge
    /// </summary>
    Lounge,

    /// <summary>
    /// Medical
    /// </summary>
    Medical,

    /// <summary>
    /// Meal beverage
    /// </summary>
    MealBeverage,

    /// <summary>
    /// Other
    /// </summary>
    Other,

    /// <summary>
    /// Passenger assist fee
    /// </summary>
    PassengerAssistFee,

    /// <summary>
    /// Pets
    /// </summary>
    Pets,

    /// <summary>
    /// Seat fees
    /// </summary>
    SeatFees,

    /// <summary>
    /// Standby
    /// </summary>
    Standby,

    /// <summary>
    /// Service fee
    /// </summary>
    ServiceFee,

    /// <summary>
    /// Store
    /// </summary>
    Store,

    /// <summary>
    /// Travel service
    /// </summary>
    TravelService,

    /// <summary>
    /// Unaccompanied travel
    /// </summary>
    UnaccompaniedTravel,

    /// <summary>
    /// Upgrades
    /// </summary>
    Upgrades,

    /// <summary>
    /// Wi-fi
    /// </summary>
    Wifi,
}

sealed class CardSettlementPurchaseDetailsTravelAncillaryServiceCategoryConverter
    : JsonConverter<CardSettlementPurchaseDetailsTravelAncillaryServiceCategory>
{
    public override CardSettlementPurchaseDetailsTravelAncillaryServiceCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.None,
            "bundled_service" =>
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.BundledService,
            "baggage_fee" => CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.BaggageFee,
            "change_fee" => CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.ChangeFee,
            "cargo" => CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Cargo,
            "carbon_offset" =>
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.CarbonOffset,
            "frequent_flyer" =>
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.FrequentFlyer,
            "gift_card" => CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.GiftCard,
            "ground_transport" =>
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.GroundTransport,
            "in_flight_entertainment" =>
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.InFlightEntertainment,
            "lounge" => CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Lounge,
            "medical" => CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Medical,
            "meal_beverage" =>
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.MealBeverage,
            "other" => CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Other,
            "passenger_assist_fee" =>
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.PassengerAssistFee,
            "pets" => CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Pets,
            "seat_fees" => CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.SeatFees,
            "standby" => CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Standby,
            "service_fee" => CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.ServiceFee,
            "store" => CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Store,
            "travel_service" =>
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.TravelService,
            "unaccompanied_travel" =>
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.UnaccompaniedTravel,
            "upgrades" => CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Upgrades,
            "wifi" => CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Wifi,
            _ => (CardSettlementPurchaseDetailsTravelAncillaryServiceCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementPurchaseDetailsTravelAncillaryServiceCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.None => "none",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.BundledService =>
                    "bundled_service",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.BaggageFee =>
                    "baggage_fee",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.ChangeFee =>
                    "change_fee",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Cargo => "cargo",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.CarbonOffset =>
                    "carbon_offset",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.FrequentFlyer =>
                    "frequent_flyer",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.GiftCard => "gift_card",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.GroundTransport =>
                    "ground_transport",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.InFlightEntertainment =>
                    "in_flight_entertainment",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Lounge => "lounge",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Medical => "medical",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.MealBeverage =>
                    "meal_beverage",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Other => "other",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.PassengerAssistFee =>
                    "passenger_assist_fee",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Pets => "pets",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.SeatFees => "seat_fees",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Standby => "standby",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.ServiceFee =>
                    "service_fee",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Store => "store",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.TravelService =>
                    "travel_service",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.UnaccompaniedTravel =>
                    "unaccompanied_travel",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Upgrades => "upgrades",
                CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.Wifi => "wifi",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Indicates the reason for a credit to the cardholder.
/// </summary>
[JsonConverter(typeof(CardSettlementPurchaseDetailsTravelCreditReasonIndicatorConverter))]
public enum CardSettlementPurchaseDetailsTravelCreditReasonIndicator
{
    /// <summary>
    /// No credit
    /// </summary>
    NoCredit,

    /// <summary>
    /// Passenger transport ancillary purchase cancellation
    /// </summary>
    PassengerTransportAncillaryPurchaseCancellation,

    /// <summary>
    /// Airline ticket and passenger transport ancillary purchase cancellation
    /// </summary>
    AirlineTicketAndPassengerTransportAncillaryPurchaseCancellation,

    /// <summary>
    /// Airline ticket cancellation
    /// </summary>
    AirlineTicketCancellation,

    /// <summary>
    /// Other
    /// </summary>
    Other,

    /// <summary>
    /// Partial refund of airline ticket
    /// </summary>
    PartialRefundOfAirlineTicket,
}

sealed class CardSettlementPurchaseDetailsTravelCreditReasonIndicatorConverter
    : JsonConverter<CardSettlementPurchaseDetailsTravelCreditReasonIndicator>
{
    public override CardSettlementPurchaseDetailsTravelCreditReasonIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no_credit" => CardSettlementPurchaseDetailsTravelCreditReasonIndicator.NoCredit,
            "passenger_transport_ancillary_purchase_cancellation" =>
                CardSettlementPurchaseDetailsTravelCreditReasonIndicator.PassengerTransportAncillaryPurchaseCancellation,
            "airline_ticket_and_passenger_transport_ancillary_purchase_cancellation" =>
                CardSettlementPurchaseDetailsTravelCreditReasonIndicator.AirlineTicketAndPassengerTransportAncillaryPurchaseCancellation,
            "airline_ticket_cancellation" =>
                CardSettlementPurchaseDetailsTravelCreditReasonIndicator.AirlineTicketCancellation,
            "other" => CardSettlementPurchaseDetailsTravelCreditReasonIndicator.Other,
            "partial_refund_of_airline_ticket" =>
                CardSettlementPurchaseDetailsTravelCreditReasonIndicator.PartialRefundOfAirlineTicket,
            _ => (CardSettlementPurchaseDetailsTravelCreditReasonIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementPurchaseDetailsTravelCreditReasonIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementPurchaseDetailsTravelCreditReasonIndicator.NoCredit => "no_credit",
                CardSettlementPurchaseDetailsTravelCreditReasonIndicator.PassengerTransportAncillaryPurchaseCancellation =>
                    "passenger_transport_ancillary_purchase_cancellation",
                CardSettlementPurchaseDetailsTravelCreditReasonIndicator.AirlineTicketAndPassengerTransportAncillaryPurchaseCancellation =>
                    "airline_ticket_and_passenger_transport_ancillary_purchase_cancellation",
                CardSettlementPurchaseDetailsTravelCreditReasonIndicator.AirlineTicketCancellation =>
                    "airline_ticket_cancellation",
                CardSettlementPurchaseDetailsTravelCreditReasonIndicator.Other => "other",
                CardSettlementPurchaseDetailsTravelCreditReasonIndicator.PartialRefundOfAirlineTicket =>
                    "partial_refund_of_airline_ticket",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Indicates whether this ticket is non-refundable.
/// </summary>
[JsonConverter(typeof(CardSettlementPurchaseDetailsTravelRestrictedTicketIndicatorConverter))]
public enum CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator
{
    /// <summary>
    /// No restrictions
    /// </summary>
    NoRestrictions,

    /// <summary>
    /// Restricted non-refundable ticket
    /// </summary>
    RestrictedNonRefundableTicket,
}

sealed class CardSettlementPurchaseDetailsTravelRestrictedTicketIndicatorConverter
    : JsonConverter<CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator>
{
    public override CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no_restrictions" =>
                CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator.NoRestrictions,
            "restricted_non_refundable_ticket" =>
                CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator.RestrictedNonRefundableTicket,
            _ => (CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator.NoRestrictions =>
                    "no_restrictions",
                CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator.RestrictedNonRefundableTicket =>
                    "restricted_non_refundable_ticket",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Indicates why a ticket was changed.
/// </summary>
[JsonConverter(typeof(CardSettlementPurchaseDetailsTravelTicketChangeIndicatorConverter))]
public enum CardSettlementPurchaseDetailsTravelTicketChangeIndicator
{
    /// <summary>
    /// None
    /// </summary>
    None,

    /// <summary>
    /// Change to existing ticket
    /// </summary>
    ChangeToExistingTicket,

    /// <summary>
    /// New ticket
    /// </summary>
    NewTicket,
}

sealed class CardSettlementPurchaseDetailsTravelTicketChangeIndicatorConverter
    : JsonConverter<CardSettlementPurchaseDetailsTravelTicketChangeIndicator>
{
    public override CardSettlementPurchaseDetailsTravelTicketChangeIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => CardSettlementPurchaseDetailsTravelTicketChangeIndicator.None,
            "change_to_existing_ticket" =>
                CardSettlementPurchaseDetailsTravelTicketChangeIndicator.ChangeToExistingTicket,
            "new_ticket" => CardSettlementPurchaseDetailsTravelTicketChangeIndicator.NewTicket,
            _ => (CardSettlementPurchaseDetailsTravelTicketChangeIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementPurchaseDetailsTravelTicketChangeIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementPurchaseDetailsTravelTicketChangeIndicator.None => "none",
                CardSettlementPurchaseDetailsTravelTicketChangeIndicator.ChangeToExistingTicket =>
                    "change_to_existing_ticket",
                CardSettlementPurchaseDetailsTravelTicketChangeIndicator.NewTicket => "new_ticket",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardSettlementPurchaseDetailsTravelTripLeg,
        CardSettlementPurchaseDetailsTravelTripLegFromRaw
    >)
)]
public sealed record class CardSettlementPurchaseDetailsTravelTripLeg : JsonModel
{
    /// <summary>
    /// Carrier code (e.g., United Airlines, Jet Blue, etc.).
    /// </summary>
    public required string? CarrierCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("carrier_code");
        }
        init { this._rawData.Set("carrier_code", value); }
    }

    /// <summary>
    /// Code for the destination city or airport.
    /// </summary>
    public required string? DestinationCityAirportCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("destination_city_airport_code");
        }
        init { this._rawData.Set("destination_city_airport_code", value); }
    }

    /// <summary>
    /// Fare basis code.
    /// </summary>
    public required string? FareBasisCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fare_basis_code");
        }
        init { this._rawData.Set("fare_basis_code", value); }
    }

    /// <summary>
    /// Flight number.
    /// </summary>
    public required string? FlightNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("flight_number");
        }
        init { this._rawData.Set("flight_number", value); }
    }

    /// <summary>
    /// Service class (e.g., first class, business class, etc.).
    /// </summary>
    public required string? ServiceClass
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("service_class");
        }
        init { this._rawData.Set("service_class", value); }
    }

    /// <summary>
    /// Indicates whether a stopover is allowed on this ticket.
    /// </summary>
    public required ApiEnum<
        string,
        CardSettlementPurchaseDetailsTravelTripLegStopOverCode
    >? StopOverCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardSettlementPurchaseDetailsTravelTripLegStopOverCode>
            >("stop_over_code");
        }
        init { this._rawData.Set("stop_over_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CarrierCode;
        _ = this.DestinationCityAirportCode;
        _ = this.FareBasisCode;
        _ = this.FlightNumber;
        _ = this.ServiceClass;
        this.StopOverCode?.Validate();
    }

    public CardSettlementPurchaseDetailsTravelTripLeg() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardSettlementPurchaseDetailsTravelTripLeg(
        CardSettlementPurchaseDetailsTravelTripLeg cardSettlementPurchaseDetailsTravelTripLeg
    )
        : base(cardSettlementPurchaseDetailsTravelTripLeg) { }
#pragma warning restore CS8618

    public CardSettlementPurchaseDetailsTravelTripLeg(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardSettlementPurchaseDetailsTravelTripLeg(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardSettlementPurchaseDetailsTravelTripLegFromRaw.FromRawUnchecked"/>
    public static CardSettlementPurchaseDetailsTravelTripLeg FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardSettlementPurchaseDetailsTravelTripLegFromRaw
    : IFromRawJson<CardSettlementPurchaseDetailsTravelTripLeg>
{
    /// <inheritdoc/>
    public CardSettlementPurchaseDetailsTravelTripLeg FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardSettlementPurchaseDetailsTravelTripLeg.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates whether a stopover is allowed on this ticket.
/// </summary>
[JsonConverter(typeof(CardSettlementPurchaseDetailsTravelTripLegStopOverCodeConverter))]
public enum CardSettlementPurchaseDetailsTravelTripLegStopOverCode
{
    /// <summary>
    /// None
    /// </summary>
    None,

    /// <summary>
    /// Stop over allowed
    /// </summary>
    StopOverAllowed,

    /// <summary>
    /// Stop over not allowed
    /// </summary>
    StopOverNotAllowed,
}

sealed class CardSettlementPurchaseDetailsTravelTripLegStopOverCodeConverter
    : JsonConverter<CardSettlementPurchaseDetailsTravelTripLegStopOverCode>
{
    public override CardSettlementPurchaseDetailsTravelTripLegStopOverCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => CardSettlementPurchaseDetailsTravelTripLegStopOverCode.None,
            "stop_over_allowed" =>
                CardSettlementPurchaseDetailsTravelTripLegStopOverCode.StopOverAllowed,
            "stop_over_not_allowed" =>
                CardSettlementPurchaseDetailsTravelTripLegStopOverCode.StopOverNotAllowed,
            _ => (CardSettlementPurchaseDetailsTravelTripLegStopOverCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementPurchaseDetailsTravelTripLegStopOverCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementPurchaseDetailsTravelTripLegStopOverCode.None => "none",
                CardSettlementPurchaseDetailsTravelTripLegStopOverCode.StopOverAllowed =>
                    "stop_over_allowed",
                CardSettlementPurchaseDetailsTravelTripLegStopOverCode.StopOverNotAllowed =>
                    "stop_over_not_allowed",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<CardSettlementSchemeFee, CardSettlementSchemeFeeFromRaw>))]
public sealed record class CardSettlementSchemeFee : JsonModel
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
    public required ApiEnum<string, CardSettlementSchemeFeeCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardSettlementSchemeFeeCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The type of fee being assessed.
    /// </summary>
    public required ApiEnum<string, CardSettlementSchemeFeeFeeType> FeeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardSettlementSchemeFeeFeeType>>(
                "fee_type"
            );
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

    public CardSettlementSchemeFee() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardSettlementSchemeFee(CardSettlementSchemeFee cardSettlementSchemeFee)
        : base(cardSettlementSchemeFee) { }
#pragma warning restore CS8618

    public CardSettlementSchemeFee(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardSettlementSchemeFee(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardSettlementSchemeFeeFromRaw.FromRawUnchecked"/>
    public static CardSettlementSchemeFee FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardSettlementSchemeFeeFromRaw : IFromRawJson<CardSettlementSchemeFee>
{
    /// <inheritdoc/>
    public CardSettlementSchemeFee FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardSettlementSchemeFee.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the fee reimbursement.
/// </summary>
[JsonConverter(typeof(CardSettlementSchemeFeeCurrencyConverter))]
public enum CardSettlementSchemeFeeCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardSettlementSchemeFeeCurrencyConverter
    : JsonConverter<CardSettlementSchemeFeeCurrency>
{
    public override CardSettlementSchemeFeeCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardSettlementSchemeFeeCurrency.Usd,
            _ => (CardSettlementSchemeFeeCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementSchemeFeeCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementSchemeFeeCurrency.Usd => "USD",
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
[JsonConverter(typeof(CardSettlementSchemeFeeFeeTypeConverter))]
public enum CardSettlementSchemeFeeFeeType
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

sealed class CardSettlementSchemeFeeFeeTypeConverter : JsonConverter<CardSettlementSchemeFeeFeeType>
{
    public override CardSettlementSchemeFeeFeeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa_international_service_assessment_single_currency" =>
                CardSettlementSchemeFeeFeeType.VisaInternationalServiceAssessmentSingleCurrency,
            "visa_international_service_assessment_cross_currency" =>
                CardSettlementSchemeFeeFeeType.VisaInternationalServiceAssessmentCrossCurrency,
            "visa_authorization_domestic_point_of_sale" =>
                CardSettlementSchemeFeeFeeType.VisaAuthorizationDomesticPointOfSale,
            "visa_authorization_international_point_of_sale" =>
                CardSettlementSchemeFeeFeeType.VisaAuthorizationInternationalPointOfSale,
            "visa_authorization_canada_point_of_sale" =>
                CardSettlementSchemeFeeFeeType.VisaAuthorizationCanadaPointOfSale,
            "visa_authorization_reversal_point_of_sale" =>
                CardSettlementSchemeFeeFeeType.VisaAuthorizationReversalPointOfSale,
            "visa_authorization_reversal_international_point_of_sale" =>
                CardSettlementSchemeFeeFeeType.VisaAuthorizationReversalInternationalPointOfSale,
            "visa_authorization_address_verification_service" =>
                CardSettlementSchemeFeeFeeType.VisaAuthorizationAddressVerificationService,
            "visa_advanced_authorization" =>
                CardSettlementSchemeFeeFeeType.VisaAdvancedAuthorization,
            "visa_message_transmission" => CardSettlementSchemeFeeFeeType.VisaMessageTransmission,
            "visa_account_verification_domestic" =>
                CardSettlementSchemeFeeFeeType.VisaAccountVerificationDomestic,
            "visa_account_verification_international" =>
                CardSettlementSchemeFeeFeeType.VisaAccountVerificationInternational,
            "visa_account_verification_canada" =>
                CardSettlementSchemeFeeFeeType.VisaAccountVerificationCanada,
            "visa_corporate_acceptance_fee" =>
                CardSettlementSchemeFeeFeeType.VisaCorporateAcceptanceFee,
            "visa_consumer_debit_acceptance_fee" =>
                CardSettlementSchemeFeeFeeType.VisaConsumerDebitAcceptanceFee,
            "visa_business_debit_acceptance_fee" =>
                CardSettlementSchemeFeeFeeType.VisaBusinessDebitAcceptanceFee,
            "visa_purchasing_acceptance_fee" =>
                CardSettlementSchemeFeeFeeType.VisaPurchasingAcceptanceFee,
            "visa_purchase_domestic" => CardSettlementSchemeFeeFeeType.VisaPurchaseDomestic,
            "visa_purchase_international" =>
                CardSettlementSchemeFeeFeeType.VisaPurchaseInternational,
            "visa_credit_purchase_token" => CardSettlementSchemeFeeFeeType.VisaCreditPurchaseToken,
            "visa_debit_purchase_token" => CardSettlementSchemeFeeFeeType.VisaDebitPurchaseToken,
            "visa_clearing_transmission" => CardSettlementSchemeFeeFeeType.VisaClearingTransmission,
            "visa_direct_authorization" => CardSettlementSchemeFeeFeeType.VisaDirectAuthorization,
            "visa_direct_transaction_domestic" =>
                CardSettlementSchemeFeeFeeType.VisaDirectTransactionDomestic,
            "visa_service_commercial_credit" =>
                CardSettlementSchemeFeeFeeType.VisaServiceCommercialCredit,
            "visa_advertising_service_commercial_credit" =>
                CardSettlementSchemeFeeFeeType.VisaAdvertisingServiceCommercialCredit,
            "visa_community_growth_acceleration_program" =>
                CardSettlementSchemeFeeFeeType.VisaCommunityGrowthAccelerationProgram,
            "visa_processing_guarantee_commercial_credit" =>
                CardSettlementSchemeFeeFeeType.VisaProcessingGuaranteeCommercialCredit,
            "pulse_switch_fee" => CardSettlementSchemeFeeFeeType.PulseSwitchFee,
            _ => (CardSettlementSchemeFeeFeeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementSchemeFeeFeeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementSchemeFeeFeeType.VisaInternationalServiceAssessmentSingleCurrency =>
                    "visa_international_service_assessment_single_currency",
                CardSettlementSchemeFeeFeeType.VisaInternationalServiceAssessmentCrossCurrency =>
                    "visa_international_service_assessment_cross_currency",
                CardSettlementSchemeFeeFeeType.VisaAuthorizationDomesticPointOfSale =>
                    "visa_authorization_domestic_point_of_sale",
                CardSettlementSchemeFeeFeeType.VisaAuthorizationInternationalPointOfSale =>
                    "visa_authorization_international_point_of_sale",
                CardSettlementSchemeFeeFeeType.VisaAuthorizationCanadaPointOfSale =>
                    "visa_authorization_canada_point_of_sale",
                CardSettlementSchemeFeeFeeType.VisaAuthorizationReversalPointOfSale =>
                    "visa_authorization_reversal_point_of_sale",
                CardSettlementSchemeFeeFeeType.VisaAuthorizationReversalInternationalPointOfSale =>
                    "visa_authorization_reversal_international_point_of_sale",
                CardSettlementSchemeFeeFeeType.VisaAuthorizationAddressVerificationService =>
                    "visa_authorization_address_verification_service",
                CardSettlementSchemeFeeFeeType.VisaAdvancedAuthorization =>
                    "visa_advanced_authorization",
                CardSettlementSchemeFeeFeeType.VisaMessageTransmission =>
                    "visa_message_transmission",
                CardSettlementSchemeFeeFeeType.VisaAccountVerificationDomestic =>
                    "visa_account_verification_domestic",
                CardSettlementSchemeFeeFeeType.VisaAccountVerificationInternational =>
                    "visa_account_verification_international",
                CardSettlementSchemeFeeFeeType.VisaAccountVerificationCanada =>
                    "visa_account_verification_canada",
                CardSettlementSchemeFeeFeeType.VisaCorporateAcceptanceFee =>
                    "visa_corporate_acceptance_fee",
                CardSettlementSchemeFeeFeeType.VisaConsumerDebitAcceptanceFee =>
                    "visa_consumer_debit_acceptance_fee",
                CardSettlementSchemeFeeFeeType.VisaBusinessDebitAcceptanceFee =>
                    "visa_business_debit_acceptance_fee",
                CardSettlementSchemeFeeFeeType.VisaPurchasingAcceptanceFee =>
                    "visa_purchasing_acceptance_fee",
                CardSettlementSchemeFeeFeeType.VisaPurchaseDomestic => "visa_purchase_domestic",
                CardSettlementSchemeFeeFeeType.VisaPurchaseInternational =>
                    "visa_purchase_international",
                CardSettlementSchemeFeeFeeType.VisaCreditPurchaseToken =>
                    "visa_credit_purchase_token",
                CardSettlementSchemeFeeFeeType.VisaDebitPurchaseToken =>
                    "visa_debit_purchase_token",
                CardSettlementSchemeFeeFeeType.VisaClearingTransmission =>
                    "visa_clearing_transmission",
                CardSettlementSchemeFeeFeeType.VisaDirectAuthorization =>
                    "visa_direct_authorization",
                CardSettlementSchemeFeeFeeType.VisaDirectTransactionDomestic =>
                    "visa_direct_transaction_domestic",
                CardSettlementSchemeFeeFeeType.VisaServiceCommercialCredit =>
                    "visa_service_commercial_credit",
                CardSettlementSchemeFeeFeeType.VisaAdvertisingServiceCommercialCredit =>
                    "visa_advertising_service_commercial_credit",
                CardSettlementSchemeFeeFeeType.VisaCommunityGrowthAccelerationProgram =>
                    "visa_community_growth_acceleration_program",
                CardSettlementSchemeFeeFeeType.VisaProcessingGuaranteeCommercialCredit =>
                    "visa_processing_guarantee_commercial_credit",
                CardSettlementSchemeFeeFeeType.PulseSwitchFee => "pulse_switch_fee",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Surcharge amount details, if applicable. The amount is positive if the surcharge
/// is added to the overall transaction amount (surcharge), and negative if the surcharge
/// is deducted from the overall transaction amount (discount).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardSettlementSurcharge, CardSettlementSurchargeFromRaw>))]
public sealed record class CardSettlementSurcharge : JsonModel
{
    /// <summary>
    /// The surcharge amount in the minor unit of the transaction's settlement currency.
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
    /// The surcharge amount in the minor unit of the transaction's presentment currency.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.PresentmentAmount;
    }

    public CardSettlementSurcharge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardSettlementSurcharge(CardSettlementSurcharge cardSettlementSurcharge)
        : base(cardSettlementSurcharge) { }
#pragma warning restore CS8618

    public CardSettlementSurcharge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardSettlementSurcharge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardSettlementSurchargeFromRaw.FromRawUnchecked"/>
    public static CardSettlementSurcharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardSettlementSurchargeFromRaw : IFromRawJson<CardSettlementSurcharge>
{
    /// <inheritdoc/>
    public CardSettlementSurcharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardSettlementSurcharge.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_settlement`.
/// </summary>
[JsonConverter(typeof(CardSettlementTypeConverter))]
public enum CardSettlementType
{
    CardSettlement,
}

sealed class CardSettlementTypeConverter : JsonConverter<CardSettlementType>
{
    public override CardSettlementType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_settlement" => CardSettlementType.CardSettlement,
            _ => (CardSettlementType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardSettlementType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardSettlementType.CardSettlement => "card_settlement",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Cashback Payment object. This field will be present in the JSON response if
/// and only if `category` is equal to `cashback_payment`. A Cashback Payment represents
/// the cashback paid to a cardholder for a given period. Cashback is usually paid
/// monthly for the prior month's transactions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CashbackPayment, CashbackPaymentFromRaw>))]
public sealed record class CashbackPayment : JsonModel
{
    /// <summary>
    /// The card on which the cashback was accrued.
    /// </summary>
    public required string? AccruedOnCardID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("accrued_on_card_id");
        }
        init { this._rawData.Set("accrued_on_card_id", value); }
    }

    /// <summary>
    /// The amount in the minor unit of the transaction's currency. For dollars,
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction currency.
    /// </summary>
    public required ApiEnum<string, CashbackPaymentCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CashbackPaymentCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The end of the period for which this transaction paid cashback.
    /// </summary>
    public required System::DateTimeOffset PeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("period_end");
        }
        init { this._rawData.Set("period_end", value); }
    }

    /// <summary>
    /// The start of the period for which this transaction paid cashback.
    /// </summary>
    public required System::DateTimeOffset PeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("period_start");
        }
        init { this._rawData.Set("period_start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccruedOnCardID;
        _ = this.Amount;
        this.Currency.Validate();
        _ = this.PeriodEnd;
        _ = this.PeriodStart;
    }

    public CashbackPayment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CashbackPayment(CashbackPayment cashbackPayment)
        : base(cashbackPayment) { }
#pragma warning restore CS8618

    public CashbackPayment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CashbackPayment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CashbackPaymentFromRaw.FromRawUnchecked"/>
    public static CashbackPayment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CashbackPaymentFromRaw : IFromRawJson<CashbackPayment>
{
    /// <inheritdoc/>
    public CashbackPayment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CashbackPayment.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction currency.
/// </summary>
[JsonConverter(typeof(CashbackPaymentCurrencyConverter))]
public enum CashbackPaymentCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CashbackPaymentCurrencyConverter : JsonConverter<CashbackPaymentCurrency>
{
    public override CashbackPaymentCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CashbackPaymentCurrency.Usd,
            _ => (CashbackPaymentCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CashbackPaymentCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CashbackPaymentCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Check Deposit Acceptance object. This field will be present in the JSON response
/// if and only if `category` is equal to `check_deposit_acceptance`. A Check Deposit
/// Acceptance is created when a Check Deposit is processed and its details confirmed.
/// Check Deposits may be returned by the receiving bank, which will appear as a Check
/// Deposit Return.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CheckDepositAcceptance, CheckDepositAcceptanceFromRaw>))]
public sealed record class CheckDepositAcceptance : JsonModel
{
    /// <summary>
    /// The account number printed on the check. This is an account at the bank that
    /// issued the check.
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
    /// The amount to be deposited in the minor unit of the transaction's currency.
    /// For dollars, for example, this is cents.
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
    /// An additional line of metadata printed on the check. This typically includes
    /// the check number for business checks.
    /// </summary>
    public required string? AuxiliaryOnUs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("auxiliary_on_us");
        }
        init { this._rawData.Set("auxiliary_on_us", value); }
    }

    /// <summary>
    /// The ID of the Check Deposit that was accepted.
    /// </summary>
    public required string CheckDepositID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("check_deposit_id");
        }
        init { this._rawData.Set("check_deposit_id", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's currency.
    /// </summary>
    public required ApiEnum<string, CheckDepositAcceptanceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CheckDepositAcceptanceCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The routing number printed on the check. This is a routing number for the
    /// bank that issued the check.
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
    /// The check serial number, if present, for consumer checks. For business checks,
    /// the serial number is usually in the `auxiliary_on_us` field.
    /// </summary>
    public required string? SerialNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("serial_number");
        }
        init { this._rawData.Set("serial_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountNumber;
        _ = this.Amount;
        _ = this.AuxiliaryOnUs;
        _ = this.CheckDepositID;
        this.Currency.Validate();
        _ = this.RoutingNumber;
        _ = this.SerialNumber;
    }

    public CheckDepositAcceptance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckDepositAcceptance(CheckDepositAcceptance checkDepositAcceptance)
        : base(checkDepositAcceptance) { }
#pragma warning restore CS8618

    public CheckDepositAcceptance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckDepositAcceptance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckDepositAcceptanceFromRaw.FromRawUnchecked"/>
    public static CheckDepositAcceptance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckDepositAcceptanceFromRaw : IFromRawJson<CheckDepositAcceptance>
{
    /// <inheritdoc/>
    public CheckDepositAcceptance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckDepositAcceptance.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's currency.
/// </summary>
[JsonConverter(typeof(CheckDepositAcceptanceCurrencyConverter))]
public enum CheckDepositAcceptanceCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CheckDepositAcceptanceCurrencyConverter : JsonConverter<CheckDepositAcceptanceCurrency>
{
    public override CheckDepositAcceptanceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CheckDepositAcceptanceCurrency.Usd,
            _ => (CheckDepositAcceptanceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckDepositAcceptanceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckDepositAcceptanceCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Check Deposit Return object. This field will be present in the JSON response
/// if and only if `category` is equal to `check_deposit_return`. A Check Deposit
/// Return is created when a Check Deposit is returned by the bank holding the account
/// it was drawn against. Check Deposits may be returned for a variety of reasons,
/// including insufficient funds or a mismatched account number. Usually, checks are
/// returned within the first 7 days after the deposit is made.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CheckDepositReturn, CheckDepositReturnFromRaw>))]
public sealed record class CheckDepositReturn : JsonModel
{
    /// <summary>
    /// The returned amount in USD cents.
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
    /// The identifier of the Check Deposit that was returned.
    /// </summary>
    public required string CheckDepositID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("check_deposit_id");
        }
        init { this._rawData.Set("check_deposit_id", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's currency.
    /// </summary>
    public required ApiEnum<string, CheckDepositReturnCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CheckDepositReturnCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Why this check was returned by the bank holding the account it was drawn against.
    /// </summary>
    public required ApiEnum<string, ReturnReason> ReturnReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ReturnReason>>("return_reason");
        }
        init { this._rawData.Set("return_reason", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the check deposit was returned.
    /// </summary>
    public required System::DateTimeOffset ReturnedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("returned_at");
        }
        init { this._rawData.Set("returned_at", value); }
    }

    /// <summary>
    /// The identifier of the transaction that reversed the original check deposit transaction.
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
        _ = this.Amount;
        _ = this.CheckDepositID;
        this.Currency.Validate();
        this.ReturnReason.Validate();
        _ = this.ReturnedAt;
        _ = this.TransactionID;
    }

    public CheckDepositReturn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckDepositReturn(CheckDepositReturn checkDepositReturn)
        : base(checkDepositReturn) { }
#pragma warning restore CS8618

    public CheckDepositReturn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckDepositReturn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckDepositReturnFromRaw.FromRawUnchecked"/>
    public static CheckDepositReturn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckDepositReturnFromRaw : IFromRawJson<CheckDepositReturn>
{
    /// <inheritdoc/>
    public CheckDepositReturn FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CheckDepositReturn.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's currency.
/// </summary>
[JsonConverter(typeof(CheckDepositReturnCurrencyConverter))]
public enum CheckDepositReturnCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CheckDepositReturnCurrencyConverter : JsonConverter<CheckDepositReturnCurrency>
{
    public override CheckDepositReturnCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CheckDepositReturnCurrency.Usd,
            _ => (CheckDepositReturnCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckDepositReturnCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckDepositReturnCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Why this check was returned by the bank holding the account it was drawn against.
/// </summary>
[JsonConverter(typeof(ReturnReasonConverter))]
public enum ReturnReason
{
    /// <summary>
    /// The check doesn't allow ACH conversion.
    /// </summary>
    AchConversionNotSupported,

    /// <summary>
    /// The account is closed. (Check21 return code `D`)
    /// </summary>
    ClosedAccount,

    /// <summary>
    /// The check has already been deposited. (Check21 return code `Y`)
    /// </summary>
    DuplicateSubmission,

    /// <summary>
    /// Insufficient funds (Check21 return code `A`)
    /// </summary>
    InsufficientFunds,

    /// <summary>
    /// No account was found matching the check details. (Check21 return code `E`)
    /// </summary>
    NoAccount,

    /// <summary>
    /// The check was not authorized. (Check21 return code `Q`)
    /// </summary>
    NotAuthorized,

    /// <summary>
    /// The check is too old. (Check21 return code `G`)
    /// </summary>
    StaleDated,

    /// <summary>
    /// The payment has been stopped by the account holder. (Check21 return code `C`)
    /// </summary>
    StopPayment,

    /// <summary>
    /// The reason for the return is unknown.
    /// </summary>
    UnknownReason,

    /// <summary>
    /// The image doesn't match the details submitted.
    /// </summary>
    UnmatchedDetails,

    /// <summary>
    /// The image could not be read. (Check21 return code `U`)
    /// </summary>
    UnreadableImage,

    /// <summary>
    /// The check endorsement was irregular. (Check21 return code `J`)
    /// </summary>
    EndorsementIrregular,

    /// <summary>
    /// The check present was either altered or fake. (Check21 return code `N`)
    /// </summary>
    AlteredOrFictitiousItem,

    /// <summary>
    /// The account this check is drawn on is frozen. (Check21 return code `F`)
    /// </summary>
    FrozenOrBlockedAccount,

    /// <summary>
    /// The check is post dated. (Check21 return code `H`)
    /// </summary>
    PostDated,

    /// <summary>
    /// The endorsement was missing. (Check21 return code `I`)
    /// </summary>
    EndorsementMissing,

    /// <summary>
    /// The check signature was missing. (Check21 return code `K`)
    /// </summary>
    SignatureMissing,

    /// <summary>
    /// The bank suspects a stop payment will be placed. (Check21 return code `T`)
    /// </summary>
    StopPaymentSuspect,

    /// <summary>
    /// The bank cannot read the image. (Check21 return code `U`)
    /// </summary>
    UnusableImage,

    /// <summary>
    /// The check image fails the bank's security check. (Check21 return code `V`)
    /// </summary>
    ImageFailsSecurityCheck,

    /// <summary>
    /// The bank cannot determine the amount. (Check21 return code `W`)
    /// </summary>
    CannotDetermineAmount,

    /// <summary>
    /// The signature is inconsistent with prior signatures. (Check21 return code `L`)
    /// </summary>
    SignatureIrregular,

    /// <summary>
    /// The check is a non-cash item and cannot be drawn against the account. (Check21
    /// return code `M`)
    /// </summary>
    NonCashItem,

    /// <summary>
    /// The bank is unable to process this check. (Check21 return code `O`)
    /// </summary>
    UnableToProcess,

    /// <summary>
    /// The check exceeds the bank or customer's limit. (Check21 return code `P`)
    /// </summary>
    ItemExceedsDollarLimit,

    /// <summary>
    /// The bank sold this account and no longer services this customer. (Check21
    /// return code `R`)
    /// </summary>
    BranchOrAccountSold,
}

sealed class ReturnReasonConverter : JsonConverter<ReturnReason>
{
    public override ReturnReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ach_conversion_not_supported" => ReturnReason.AchConversionNotSupported,
            "closed_account" => ReturnReason.ClosedAccount,
            "duplicate_submission" => ReturnReason.DuplicateSubmission,
            "insufficient_funds" => ReturnReason.InsufficientFunds,
            "no_account" => ReturnReason.NoAccount,
            "not_authorized" => ReturnReason.NotAuthorized,
            "stale_dated" => ReturnReason.StaleDated,
            "stop_payment" => ReturnReason.StopPayment,
            "unknown_reason" => ReturnReason.UnknownReason,
            "unmatched_details" => ReturnReason.UnmatchedDetails,
            "unreadable_image" => ReturnReason.UnreadableImage,
            "endorsement_irregular" => ReturnReason.EndorsementIrregular,
            "altered_or_fictitious_item" => ReturnReason.AlteredOrFictitiousItem,
            "frozen_or_blocked_account" => ReturnReason.FrozenOrBlockedAccount,
            "post_dated" => ReturnReason.PostDated,
            "endorsement_missing" => ReturnReason.EndorsementMissing,
            "signature_missing" => ReturnReason.SignatureMissing,
            "stop_payment_suspect" => ReturnReason.StopPaymentSuspect,
            "unusable_image" => ReturnReason.UnusableImage,
            "image_fails_security_check" => ReturnReason.ImageFailsSecurityCheck,
            "cannot_determine_amount" => ReturnReason.CannotDetermineAmount,
            "signature_irregular" => ReturnReason.SignatureIrregular,
            "non_cash_item" => ReturnReason.NonCashItem,
            "unable_to_process" => ReturnReason.UnableToProcess,
            "item_exceeds_dollar_limit" => ReturnReason.ItemExceedsDollarLimit,
            "branch_or_account_sold" => ReturnReason.BranchOrAccountSold,
            _ => (ReturnReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReturnReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReturnReason.AchConversionNotSupported => "ach_conversion_not_supported",
                ReturnReason.ClosedAccount => "closed_account",
                ReturnReason.DuplicateSubmission => "duplicate_submission",
                ReturnReason.InsufficientFunds => "insufficient_funds",
                ReturnReason.NoAccount => "no_account",
                ReturnReason.NotAuthorized => "not_authorized",
                ReturnReason.StaleDated => "stale_dated",
                ReturnReason.StopPayment => "stop_payment",
                ReturnReason.UnknownReason => "unknown_reason",
                ReturnReason.UnmatchedDetails => "unmatched_details",
                ReturnReason.UnreadableImage => "unreadable_image",
                ReturnReason.EndorsementIrregular => "endorsement_irregular",
                ReturnReason.AlteredOrFictitiousItem => "altered_or_fictitious_item",
                ReturnReason.FrozenOrBlockedAccount => "frozen_or_blocked_account",
                ReturnReason.PostDated => "post_dated",
                ReturnReason.EndorsementMissing => "endorsement_missing",
                ReturnReason.SignatureMissing => "signature_missing",
                ReturnReason.StopPaymentSuspect => "stop_payment_suspect",
                ReturnReason.UnusableImage => "unusable_image",
                ReturnReason.ImageFailsSecurityCheck => "image_fails_security_check",
                ReturnReason.CannotDetermineAmount => "cannot_determine_amount",
                ReturnReason.SignatureIrregular => "signature_irregular",
                ReturnReason.NonCashItem => "non_cash_item",
                ReturnReason.UnableToProcess => "unable_to_process",
                ReturnReason.ItemExceedsDollarLimit => "item_exceeds_dollar_limit",
                ReturnReason.BranchOrAccountSold => "branch_or_account_sold",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Check Transfer Deposit object. This field will be present in the JSON response
/// if and only if `category` is equal to `check_transfer_deposit`. An Inbound Check
/// is a check drawn on an Increase account that has been deposited by an external
/// bank account. These types of checks are not pre-registered.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CheckTransferDeposit, CheckTransferDepositFromRaw>))]
public sealed record class CheckTransferDeposit : JsonModel
{
    /// <summary>
    /// The identifier of the API File object containing an image of the back of
    /// the deposited check.
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
    /// The American Bankers' Association (ABA) Routing Transit Number (RTN) for
    /// the bank depositing this check. In some rare cases, this is not transmitted
    /// via Check21 and the value will be null.
    /// </summary>
    public required string? BankOfFirstDepositRoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bank_of_first_deposit_routing_number");
        }
        init { this._rawData.Set("bank_of_first_deposit_routing_number", value); }
    }

    /// <summary>
    /// When the check was deposited.
    /// </summary>
    public required System::DateTimeOffset DepositedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("deposited_at");
        }
        init { this._rawData.Set("deposited_at", value); }
    }

    /// <summary>
    /// The identifier of the API File object containing an image of the front of
    /// the deposited check.
    /// </summary>
    public required string? FrontImageFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("front_image_file_id");
        }
        init { this._rawData.Set("front_image_file_id", value); }
    }

    /// <summary>
    /// The identifier of the Inbound Check Deposit object associated with this transaction.
    /// </summary>
    public required string? InboundCheckDepositID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inbound_check_deposit_id");
        }
        init { this._rawData.Set("inbound_check_deposit_id", value); }
    }

    /// <summary>
    /// The identifier of the Transaction object created when the check was deposited.
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

    /// <summary>
    /// The identifier of the Check Transfer object that was deposited.
    /// </summary>
    public required string? TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transfer_id");
        }
        init { this._rawData.Set("transfer_id", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `check_transfer_deposit`.
    /// </summary>
    public required ApiEnum<string, CheckTransferDepositType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CheckTransferDepositType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BackImageFileID;
        _ = this.BankOfFirstDepositRoutingNumber;
        _ = this.DepositedAt;
        _ = this.FrontImageFileID;
        _ = this.InboundCheckDepositID;
        _ = this.TransactionID;
        _ = this.TransferID;
        this.Type.Validate();
    }

    public CheckTransferDeposit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckTransferDeposit(CheckTransferDeposit checkTransferDeposit)
        : base(checkTransferDeposit) { }
#pragma warning restore CS8618

    public CheckTransferDeposit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckTransferDeposit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckTransferDepositFromRaw.FromRawUnchecked"/>
    public static CheckTransferDeposit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckTransferDepositFromRaw : IFromRawJson<CheckTransferDeposit>
{
    /// <inheritdoc/>
    public CheckTransferDeposit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckTransferDeposit.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `check_transfer_deposit`.
/// </summary>
[JsonConverter(typeof(CheckTransferDepositTypeConverter))]
public enum CheckTransferDepositType
{
    CheckTransferDeposit,
}

sealed class CheckTransferDepositTypeConverter : JsonConverter<CheckTransferDepositType>
{
    public override CheckTransferDepositType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "check_transfer_deposit" => CheckTransferDepositType.CheckTransferDeposit,
            _ => (CheckTransferDepositType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckTransferDepositType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckTransferDepositType.CheckTransferDeposit => "check_transfer_deposit",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A FedNow Transfer Acknowledgement object. This field will be present in the JSON
/// response if and only if `category` is equal to `fednow_transfer_acknowledgement`.
/// A FedNow Transfer Acknowledgement is created when a FedNow Transfer sent from
/// Increase is acknowledged by the receiving bank.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FednowTransferAcknowledgement, FednowTransferAcknowledgementFromRaw>)
)]
public sealed record class FednowTransferAcknowledgement : JsonModel
{
    /// <summary>
    /// The identifier of the FedNow Transfer that led to this Transaction.
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

    public FednowTransferAcknowledgement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FednowTransferAcknowledgement(
        FednowTransferAcknowledgement fednowTransferAcknowledgement
    )
        : base(fednowTransferAcknowledgement) { }
#pragma warning restore CS8618

    public FednowTransferAcknowledgement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FednowTransferAcknowledgement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FednowTransferAcknowledgementFromRaw.FromRawUnchecked"/>
    public static FednowTransferAcknowledgement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FednowTransferAcknowledgement(string transferID)
        : this()
    {
        this.TransferID = transferID;
    }
}

class FednowTransferAcknowledgementFromRaw : IFromRawJson<FednowTransferAcknowledgement>
{
    /// <inheritdoc/>
    public FednowTransferAcknowledgement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FednowTransferAcknowledgement.FromRawUnchecked(rawData);
}

/// <summary>
/// A Fee Payment object. This field will be present in the JSON response if and only
/// if `category` is equal to `fee_payment`. A Fee Payment represents a payment made
/// to Increase.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FeePayment, FeePaymentFromRaw>))]
public sealed record class FeePayment : JsonModel
{
    /// <summary>
    /// The amount in the minor unit of the transaction's currency. For dollars,
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction currency.
    /// </summary>
    public required ApiEnum<string, FeePaymentCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FeePaymentCurrency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The start of this payment's fee period, usually the first day of a month.
    /// </summary>
    public required string FeePeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("fee_period_start");
        }
        init { this._rawData.Set("fee_period_start", value); }
    }

    /// <summary>
    /// The Program for which this fee was incurred.
    /// </summary>
    public required string? ProgramID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("program_id");
        }
        init { this._rawData.Set("program_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
        _ = this.FeePeriodStart;
        _ = this.ProgramID;
    }

    public FeePayment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeePayment(FeePayment feePayment)
        : base(feePayment) { }
#pragma warning restore CS8618

    public FeePayment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeePayment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeePaymentFromRaw.FromRawUnchecked"/>
    public static FeePayment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeePaymentFromRaw : IFromRawJson<FeePayment>
{
    /// <inheritdoc/>
    public FeePayment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FeePayment.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction currency.
/// </summary>
[JsonConverter(typeof(FeePaymentCurrencyConverter))]
public enum FeePaymentCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class FeePaymentCurrencyConverter : JsonConverter<FeePaymentCurrency>
{
    public override FeePaymentCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => FeePaymentCurrency.Usd,
            _ => (FeePaymentCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeePaymentCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeePaymentCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An Inbound ACH Transfer Intention object. This field will be present in the JSON
/// response if and only if `category` is equal to `inbound_ach_transfer`. An Inbound
/// ACH Transfer Intention is created when an ACH transfer is initiated at another
/// bank and received by Increase.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InboundAchTransfer, InboundAchTransferFromRaw>))]
public sealed record class InboundAchTransfer : JsonModel
{
    /// <summary>
    /// Additional information sent from the originator.
    /// </summary>
    public required Addenda? Addenda
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Addenda>("addenda");
        }
        init { this._rawData.Set("addenda", value); }
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
    /// The description of the date of the transfer, usually in the format `YYMMDD`.
    /// </summary>
    public required string? OriginatorCompanyDescriptiveDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("originator_company_descriptive_date");
        }
        init { this._rawData.Set("originator_company_descriptive_date", value); }
    }

    /// <summary>
    /// Data set by the originator.
    /// </summary>
    public required string? OriginatorCompanyDiscretionaryData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("originator_company_discretionary_data");
        }
        init { this._rawData.Set("originator_company_discretionary_data", value); }
    }

    /// <summary>
    /// An informational description of the transfer.
    /// </summary>
    public required string OriginatorCompanyEntryDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("originator_company_entry_description");
        }
        init { this._rawData.Set("originator_company_entry_description", value); }
    }

    /// <summary>
    /// An identifier for the originating company. This is generally, but not always,
    /// a stable identifier across multiple transfers.
    /// </summary>
    public required string OriginatorCompanyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("originator_company_id");
        }
        init { this._rawData.Set("originator_company_id", value); }
    }

    /// <summary>
    /// A name set by the originator to identify themselves.
    /// </summary>
    public required string OriginatorCompanyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("originator_company_name");
        }
        init { this._rawData.Set("originator_company_name", value); }
    }

    /// <summary>
    /// The originator's identifier for the transfer recipient.
    /// </summary>
    public required string? ReceiverIDNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("receiver_id_number");
        }
        init { this._rawData.Set("receiver_id_number", value); }
    }

    /// <summary>
    /// The name of the transfer recipient. This value is informational and not verified
    /// by Increase.
    /// </summary>
    public required string? ReceiverName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("receiver_name");
        }
        init { this._rawData.Set("receiver_name", value); }
    }

    /// <summary>
    /// A 15 digit number recorded in the Nacha file and available to both the originating
    /// and receiving bank. Along with the amount, date, and originating routing
    /// number, this can be used to identify the ACH transfer at either bank. ACH
    /// trace numbers are not unique, but are [used to correlate returns](https://increase.com/documentation/ach-returns#ach-returns).
    /// </summary>
    public required string TraceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("trace_number");
        }
        init { this._rawData.Set("trace_number", value); }
    }

    /// <summary>
    /// The Inbound ACH Transfer's identifier.
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
        this.Addenda?.Validate();
        _ = this.Amount;
        _ = this.OriginatorCompanyDescriptiveDate;
        _ = this.OriginatorCompanyDiscretionaryData;
        _ = this.OriginatorCompanyEntryDescription;
        _ = this.OriginatorCompanyID;
        _ = this.OriginatorCompanyName;
        _ = this.ReceiverIDNumber;
        _ = this.ReceiverName;
        _ = this.TraceNumber;
        _ = this.TransferID;
    }

    public InboundAchTransfer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundAchTransfer(InboundAchTransfer inboundAchTransfer)
        : base(inboundAchTransfer) { }
#pragma warning restore CS8618

    public InboundAchTransfer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundAchTransfer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundAchTransferFromRaw.FromRawUnchecked"/>
    public static InboundAchTransfer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundAchTransferFromRaw : IFromRawJson<InboundAchTransfer>
{
    /// <inheritdoc/>
    public InboundAchTransfer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InboundAchTransfer.FromRawUnchecked(rawData);
}

/// <summary>
/// Additional information sent from the originator.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Addenda, AddendaFromRaw>))]
public sealed record class Addenda : JsonModel
{
    /// <summary>
    /// The type of addendum.
    /// </summary>
    public required ApiEnum<string, AddendaCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AddendaCategory>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Unstructured `payment_related_information` passed through by the originator.
    /// </summary>
    public required Freeform? Freeform
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Freeform>("freeform");
        }
        init { this._rawData.Set("freeform", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.Freeform?.Validate();
    }

    public Addenda() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Addenda(Addenda addenda)
        : base(addenda) { }
#pragma warning restore CS8618

    public Addenda(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Addenda(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddendaFromRaw.FromRawUnchecked"/>
    public static Addenda FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddendaFromRaw : IFromRawJson<Addenda>
{
    /// <inheritdoc/>
    public Addenda FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Addenda.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of addendum.
/// </summary>
[JsonConverter(typeof(AddendaCategoryConverter))]
public enum AddendaCategory
{
    /// <summary>
    /// Unstructured addendum.
    /// </summary>
    Freeform,
}

sealed class AddendaCategoryConverter : JsonConverter<AddendaCategory>
{
    public override AddendaCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "freeform" => AddendaCategory.Freeform,
            _ => (AddendaCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddendaCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddendaCategory.Freeform => "freeform",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Unstructured `payment_related_information` passed through by the originator.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Freeform, FreeformFromRaw>))]
public sealed record class Freeform : JsonModel
{
    /// <summary>
    /// Each entry represents an addendum received from the originator.
    /// </summary>
    public required IReadOnlyList<Entry> Entries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Entry>>("entries");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Entry>>(
                "entries",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Entries)
        {
            item.Validate();
        }
    }

    public Freeform() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Freeform(Freeform freeform)
        : base(freeform) { }
#pragma warning restore CS8618

    public Freeform(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Freeform(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FreeformFromRaw.FromRawUnchecked"/>
    public static Freeform FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Freeform(IReadOnlyList<Entry> entries)
        : this()
    {
        this.Entries = entries;
    }
}

class FreeformFromRaw : IFromRawJson<Freeform>
{
    /// <inheritdoc/>
    public Freeform FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Freeform.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Entry, EntryFromRaw>))]
public sealed record class Entry : JsonModel
{
    /// <summary>
    /// The payment related information passed in the addendum.
    /// </summary>
    public required string PaymentRelatedInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("payment_related_information");
        }
        init { this._rawData.Set("payment_related_information", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PaymentRelatedInformation;
    }

    public Entry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Entry(Entry entry)
        : base(entry) { }
#pragma warning restore CS8618

    public Entry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Entry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntryFromRaw.FromRawUnchecked"/>
    public static Entry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Entry(string paymentRelatedInformation)
        : this()
    {
        this.PaymentRelatedInformation = paymentRelatedInformation;
    }
}

class EntryFromRaw : IFromRawJson<Entry>
{
    /// <inheritdoc/>
    public Entry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Entry.FromRawUnchecked(rawData);
}

/// <summary>
/// An Inbound ACH Transfer Return Intention object. This field will be present in
/// the JSON response if and only if `category` is equal to `inbound_ach_transfer_return_intention`.
/// An Inbound ACH Transfer Return Intention is created when an ACH transfer is initiated
/// at another bank and returned by Increase.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InboundAchTransferReturnIntention,
        InboundAchTransferReturnIntentionFromRaw
    >)
)]
public sealed record class InboundAchTransferReturnIntention : JsonModel
{
    /// <summary>
    /// The ID of the Inbound ACH Transfer that is being returned.
    /// </summary>
    public required string InboundAchTransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("inbound_ach_transfer_id");
        }
        init { this._rawData.Set("inbound_ach_transfer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InboundAchTransferID;
    }

    public InboundAchTransferReturnIntention() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundAchTransferReturnIntention(
        InboundAchTransferReturnIntention inboundAchTransferReturnIntention
    )
        : base(inboundAchTransferReturnIntention) { }
#pragma warning restore CS8618

    public InboundAchTransferReturnIntention(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundAchTransferReturnIntention(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundAchTransferReturnIntentionFromRaw.FromRawUnchecked"/>
    public static InboundAchTransferReturnIntention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InboundAchTransferReturnIntention(string inboundAchTransferID)
        : this()
    {
        this.InboundAchTransferID = inboundAchTransferID;
    }
}

class InboundAchTransferReturnIntentionFromRaw : IFromRawJson<InboundAchTransferReturnIntention>
{
    /// <inheritdoc/>
    public InboundAchTransferReturnIntention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundAchTransferReturnIntention.FromRawUnchecked(rawData);
}

/// <summary>
/// An Inbound Check Adjustment object. This field will be present in the JSON response
/// if and only if `category` is equal to `inbound_check_adjustment`. An Inbound Check
/// Adjustment is created when Increase receives an adjustment for a check or return
/// deposited through Check21.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InboundCheckAdjustment, InboundCheckAdjustmentFromRaw>))]
public sealed record class InboundCheckAdjustment : JsonModel
{
    /// <summary>
    /// The ID of the transaction that was adjusted.
    /// </summary>
    public required string AdjustedTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("adjusted_transaction_id");
        }
        init { this._rawData.Set("adjusted_transaction_id", value); }
    }

    /// <summary>
    /// The amount of the check adjustment.
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
    /// The reason for the adjustment.
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
        _ = this.AdjustedTransactionID;
        _ = this.Amount;
        this.Reason.Validate();
    }

    public InboundCheckAdjustment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundCheckAdjustment(InboundCheckAdjustment inboundCheckAdjustment)
        : base(inboundCheckAdjustment) { }
#pragma warning restore CS8618

    public InboundCheckAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundCheckAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundCheckAdjustmentFromRaw.FromRawUnchecked"/>
    public static InboundCheckAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundCheckAdjustmentFromRaw : IFromRawJson<InboundCheckAdjustment>
{
    /// <inheritdoc/>
    public InboundCheckAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundCheckAdjustment.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason for the adjustment.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    /// <summary>
    /// The return was initiated too late and the receiving institution has responded
    /// with a Late Return Claim.
    /// </summary>
    LateReturn,

    /// <summary>
    /// The check was deposited to the wrong payee and the depositing institution
    /// has reimbursed the funds with a Wrong Payee Credit.
    /// </summary>
    WrongPayeeCredit,

    /// <summary>
    /// The check was deposited with a different amount than what was written on the check.
    /// </summary>
    AdjustedAmount,

    /// <summary>
    /// The recipient was not able to process the check. This usually happens for
    /// e.g., low quality images.
    /// </summary>
    NonConformingItem,

    /// <summary>
    /// The check has already been deposited elsewhere and so this is a duplicate.
    /// </summary>
    Paid,
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
            "late_return" => Reason.LateReturn,
            "wrong_payee_credit" => Reason.WrongPayeeCredit,
            "adjusted_amount" => Reason.AdjustedAmount,
            "non_conforming_item" => Reason.NonConformingItem,
            "paid" => Reason.Paid,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.LateReturn => "late_return",
                Reason.WrongPayeeCredit => "wrong_payee_credit",
                Reason.AdjustedAmount => "adjusted_amount",
                Reason.NonConformingItem => "non_conforming_item",
                Reason.Paid => "paid",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An Inbound Check Deposit Return Intention object. This field will be present
/// in the JSON response if and only if `category` is equal to `inbound_check_deposit_return_intention`.
/// An Inbound Check Deposit Return Intention is created when Increase receives an
/// Inbound Check and the User requests that it be returned.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InboundCheckDepositReturnIntention,
        InboundCheckDepositReturnIntentionFromRaw
    >)
)]
public sealed record class InboundCheckDepositReturnIntention : JsonModel
{
    /// <summary>
    /// The ID of the Inbound Check Deposit that is being returned.
    /// </summary>
    public required string InboundCheckDepositID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("inbound_check_deposit_id");
        }
        init { this._rawData.Set("inbound_check_deposit_id", value); }
    }

    /// <summary>
    /// The identifier of the Check Transfer object that was deposited.
    /// </summary>
    public required string? TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transfer_id");
        }
        init { this._rawData.Set("transfer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InboundCheckDepositID;
        _ = this.TransferID;
    }

    public InboundCheckDepositReturnIntention() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundCheckDepositReturnIntention(
        InboundCheckDepositReturnIntention inboundCheckDepositReturnIntention
    )
        : base(inboundCheckDepositReturnIntention) { }
#pragma warning restore CS8618

    public InboundCheckDepositReturnIntention(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundCheckDepositReturnIntention(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundCheckDepositReturnIntentionFromRaw.FromRawUnchecked"/>
    public static InboundCheckDepositReturnIntention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundCheckDepositReturnIntentionFromRaw : IFromRawJson<InboundCheckDepositReturnIntention>
{
    /// <inheritdoc/>
    public InboundCheckDepositReturnIntention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundCheckDepositReturnIntention.FromRawUnchecked(rawData);
}

/// <summary>
/// An Inbound FedNow Transfer Confirmation object. This field will be present in
/// the JSON response if and only if `category` is equal to `inbound_fednow_transfer_confirmation`.
/// An Inbound FedNow Transfer Confirmation is created when a FedNow transfer is
/// initiated at another bank and received by Increase.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InboundFednowTransferConfirmation,
        InboundFednowTransferConfirmationFromRaw
    >)
)]
public sealed record class InboundFednowTransferConfirmation : JsonModel
{
    /// <summary>
    /// The identifier of the FedNow Transfer that led to this Transaction.
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

    public InboundFednowTransferConfirmation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundFednowTransferConfirmation(
        InboundFednowTransferConfirmation inboundFednowTransferConfirmation
    )
        : base(inboundFednowTransferConfirmation) { }
#pragma warning restore CS8618

    public InboundFednowTransferConfirmation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundFednowTransferConfirmation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundFednowTransferConfirmationFromRaw.FromRawUnchecked"/>
    public static InboundFednowTransferConfirmation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InboundFednowTransferConfirmation(string transferID)
        : this()
    {
        this.TransferID = transferID;
    }
}

class InboundFednowTransferConfirmationFromRaw : IFromRawJson<InboundFednowTransferConfirmation>
{
    /// <inheritdoc/>
    public InboundFednowTransferConfirmation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundFednowTransferConfirmation.FromRawUnchecked(rawData);
}

/// <summary>
/// An Inbound Real-Time Payments Transfer Confirmation object. This field will be
/// present in the JSON response if and only if `category` is equal to `inbound_real_time_payments_transfer_confirmation`.
/// An Inbound Real-Time Payments Transfer Confirmation is created when a Real-Time
/// Payments transfer is initiated at another bank and received by Increase.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InboundRealTimePaymentsTransferConfirmation,
        InboundRealTimePaymentsTransferConfirmationFromRaw
    >)
)]
public sealed record class InboundRealTimePaymentsTransferConfirmation : JsonModel
{
    /// <summary>
    /// The amount in the minor unit of the transfer's currency. For dollars, for
    /// example, this is cents.
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
    public required ApiEnum<string, InboundRealTimePaymentsTransferConfirmationCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, InboundRealTimePaymentsTransferConfirmationCurrency>
            >("currency");
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
    /// The identifier of the Real-Time Payments Transfer that led to this Transaction.
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
        _ = this.Amount;
        _ = this.CreditorName;
        this.Currency.Validate();
        _ = this.DebtorAccountNumber;
        _ = this.DebtorName;
        _ = this.DebtorRoutingNumber;
        _ = this.TransactionIdentification;
        _ = this.TransferID;
        _ = this.UnstructuredRemittanceInformation;
    }

    public InboundRealTimePaymentsTransferConfirmation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundRealTimePaymentsTransferConfirmation(
        InboundRealTimePaymentsTransferConfirmation inboundRealTimePaymentsTransferConfirmation
    )
        : base(inboundRealTimePaymentsTransferConfirmation) { }
#pragma warning restore CS8618

    public InboundRealTimePaymentsTransferConfirmation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundRealTimePaymentsTransferConfirmation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundRealTimePaymentsTransferConfirmationFromRaw.FromRawUnchecked"/>
    public static InboundRealTimePaymentsTransferConfirmation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundRealTimePaymentsTransferConfirmationFromRaw
    : IFromRawJson<InboundRealTimePaymentsTransferConfirmation>
{
    /// <inheritdoc/>
    public InboundRealTimePaymentsTransferConfirmation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundRealTimePaymentsTransferConfirmation.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code of the transfer's
/// currency. This will always be "USD" for a Real-Time Payments transfer.
/// </summary>
[JsonConverter(typeof(InboundRealTimePaymentsTransferConfirmationCurrencyConverter))]
public enum InboundRealTimePaymentsTransferConfirmationCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class InboundRealTimePaymentsTransferConfirmationCurrencyConverter
    : JsonConverter<InboundRealTimePaymentsTransferConfirmationCurrency>
{
    public override InboundRealTimePaymentsTransferConfirmationCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => InboundRealTimePaymentsTransferConfirmationCurrency.Usd,
            _ => (InboundRealTimePaymentsTransferConfirmationCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundRealTimePaymentsTransferConfirmationCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InboundRealTimePaymentsTransferConfirmationCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An Inbound Wire Reversal object. This field will be present in the JSON response
/// if and only if `category` is equal to `inbound_wire_reversal`. An Inbound Wire
/// Reversal represents a reversal of a wire transfer that was initiated via Increase.
/// The other bank is sending the money back. This most often happens when the original
/// destination account details were incorrect.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InboundWireReversal, InboundWireReversalFromRaw>))]
public sealed record class InboundWireReversal : JsonModel
{
    /// <summary>
    /// The amount that was reversed in USD cents.
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
    /// the reversal was created.
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
    /// The debtor's routing number.
    /// </summary>
    public required string? DebtorRoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("debtor_routing_number");
        }
        init { this._rawData.Set("debtor_routing_number", value); }
    }

    /// <summary>
    /// The description on the reversal message from Fedwire, set by the reversing bank.
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
    /// The Fedwire cycle date for the wire reversal. The "Fedwire day" begins at
    /// 9:00 PM Eastern Time on the evening before the `cycle date`.
    /// </summary>
    public required string InputCycleDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("input_cycle_date");
        }
        init { this._rawData.Set("input_cycle_date", value); }
    }

    /// <summary>
    /// The Fedwire transaction identifier.
    /// </summary>
    public required string InputMessageAccountabilityData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("input_message_accountability_data");
        }
        init { this._rawData.Set("input_message_accountability_data", value); }
    }

    /// <summary>
    /// The Fedwire sequence number.
    /// </summary>
    public required string InputSequenceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("input_sequence_number");
        }
        init { this._rawData.Set("input_sequence_number", value); }
    }

    /// <summary>
    /// The Fedwire input source identifier.
    /// </summary>
    public required string InputSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("input_source");
        }
        init { this._rawData.Set("input_source", value); }
    }

    /// <summary>
    /// The sending bank's identifier for the reversal.
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
    /// Additional information about the reason for the reversal.
    /// </summary>
    public required string? ReturnReasonAdditionalInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("return_reason_additional_information");
        }
        init { this._rawData.Set("return_reason_additional_information", value); }
    }

    /// <summary>
    /// A code provided by the sending bank giving a reason for the reversal. The
    /// common return reason codes are [documented here](/documentation/wire-reversals#reversal-reason-codes).
    /// </summary>
    public required string? ReturnReasonCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("return_reason_code");
        }
        init { this._rawData.Set("return_reason_code", value); }
    }

    /// <summary>
    /// An Increase-generated description of the `return_reason_code`.
    /// </summary>
    public required string? ReturnReasonCodeDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("return_reason_code_description");
        }
        init { this._rawData.Set("return_reason_code_description", value); }
    }

    /// <summary>
    /// The ID for the Transaction associated with the transfer reversal.
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

    /// <summary>
    /// The ID for the Wire Transfer that is being reversed.
    /// </summary>
    public required string WireTransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("wire_transfer_id");
        }
        init { this._rawData.Set("wire_transfer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.CreatedAt;
        _ = this.DebtorRoutingNumber;
        _ = this.Description;
        _ = this.InputCycleDate;
        _ = this.InputMessageAccountabilityData;
        _ = this.InputSequenceNumber;
        _ = this.InputSource;
        _ = this.InstructionIdentification;
        _ = this.ReturnReasonAdditionalInformation;
        _ = this.ReturnReasonCode;
        _ = this.ReturnReasonCodeDescription;
        _ = this.TransactionID;
        _ = this.WireTransferID;
    }

    public InboundWireReversal() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundWireReversal(InboundWireReversal inboundWireReversal)
        : base(inboundWireReversal) { }
#pragma warning restore CS8618

    public InboundWireReversal(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundWireReversal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundWireReversalFromRaw.FromRawUnchecked"/>
    public static InboundWireReversal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundWireReversalFromRaw : IFromRawJson<InboundWireReversal>
{
    /// <inheritdoc/>
    public InboundWireReversal FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InboundWireReversal.FromRawUnchecked(rawData);
}

/// <summary>
/// An Inbound Wire Transfer Intention object. This field will be present in the JSON
/// response if and only if `category` is equal to `inbound_wire_transfer`. An Inbound
/// Wire Transfer Intention is created when a wire transfer is initiated at another
/// bank and received by Increase.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InboundWireTransfer, InboundWireTransferFromRaw>))]
public sealed record class InboundWireTransfer : JsonModel
{
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
    /// The ID of the Inbound Wire Transfer object that resulted in this Transaction.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
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
        _ = this.TransferID;
        _ = this.UniqueEndToEndTransactionReference;
        _ = this.UnstructuredRemittanceInformation;
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
/// An Inbound Wire Transfer Reversal Intention object. This field will be present
/// in the JSON response if and only if `category` is equal to `inbound_wire_transfer_reversal`.
/// An Inbound Wire Transfer Reversal Intention is created when Increase has received
/// a wire and the User requests that it be reversed.
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
/// An Interest Payment object. This field will be present in the JSON response if
/// and only if `category` is equal to `interest_payment`. An Interest Payment represents
/// a payment of interest on an account. Interest is usually paid monthly.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InterestPayment, InterestPaymentFromRaw>))]
public sealed record class InterestPayment : JsonModel
{
    /// <summary>
    /// The account on which the interest was accrued.
    /// </summary>
    public required string AccruedOnAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("accrued_on_account_id");
        }
        init { this._rawData.Set("accrued_on_account_id", value); }
    }

    /// <summary>
    /// The amount in the minor unit of the transaction's currency. For dollars,
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction currency.
    /// </summary>
    public required ApiEnum<string, InterestPaymentCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InterestPaymentCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The end of the period for which this transaction paid interest.
    /// </summary>
    public required System::DateTimeOffset PeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("period_end");
        }
        init { this._rawData.Set("period_end", value); }
    }

    /// <summary>
    /// The start of the period for which this transaction paid interest.
    /// </summary>
    public required System::DateTimeOffset PeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("period_start");
        }
        init { this._rawData.Set("period_start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccruedOnAccountID;
        _ = this.Amount;
        this.Currency.Validate();
        _ = this.PeriodEnd;
        _ = this.PeriodStart;
    }

    public InterestPayment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InterestPayment(InterestPayment interestPayment)
        : base(interestPayment) { }
#pragma warning restore CS8618

    public InterestPayment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InterestPayment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InterestPaymentFromRaw.FromRawUnchecked"/>
    public static InterestPayment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InterestPaymentFromRaw : IFromRawJson<InterestPayment>
{
    /// <inheritdoc/>
    public InterestPayment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InterestPayment.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction currency.
/// </summary>
[JsonConverter(typeof(InterestPaymentCurrencyConverter))]
public enum InterestPaymentCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class InterestPaymentCurrencyConverter : JsonConverter<InterestPaymentCurrency>
{
    public override InterestPaymentCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => InterestPaymentCurrency.Usd,
            _ => (InterestPaymentCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InterestPaymentCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InterestPaymentCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An Internal Source object. This field will be present in the JSON response if
/// and only if `category` is equal to `internal_source`. A transaction between the
/// user and Increase. See the `reason` attribute for more information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InternalSource, InternalSourceFromRaw>))]
public sealed record class InternalSource : JsonModel
{
    /// <summary>
    /// The amount in the minor unit of the transaction's currency. For dollars,
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction currency.
    /// </summary>
    public required ApiEnum<string, InternalSourceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InternalSourceCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// An Internal Source is a transaction between you and Increase. This describes
    /// the reason for the transaction.
    /// </summary>
    public required ApiEnum<string, InternalSourceReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InternalSourceReason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
        this.Reason.Validate();
    }

    public InternalSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InternalSource(InternalSource internalSource)
        : base(internalSource) { }
#pragma warning restore CS8618

    public InternalSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InternalSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InternalSourceFromRaw.FromRawUnchecked"/>
    public static InternalSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InternalSourceFromRaw : IFromRawJson<InternalSource>
{
    /// <inheritdoc/>
    public InternalSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InternalSource.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction currency.
/// </summary>
[JsonConverter(typeof(InternalSourceCurrencyConverter))]
public enum InternalSourceCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class InternalSourceCurrencyConverter : JsonConverter<InternalSourceCurrency>
{
    public override InternalSourceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => InternalSourceCurrency.Usd,
            _ => (InternalSourceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InternalSourceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InternalSourceCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An Internal Source is a transaction between you and Increase. This describes
/// the reason for the transaction.
/// </summary>
[JsonConverter(typeof(InternalSourceReasonConverter))]
public enum InternalSourceReason
{
    /// <summary>
    /// Account closure
    /// </summary>
    AccountClosure,

    /// <summary>
    /// Account revenue payment distribution
    /// </summary>
    AccountRevenuePaymentDistribution,

    /// <summary>
    /// Bank-drawn check
    /// </summary>
    BankDrawnCheck,

    /// <summary>
    /// Bank-drawn check credit
    /// </summary>
    BankDrawnCheckCredit,

    /// <summary>
    /// Bank migration
    /// </summary>
    BankMigration,

    /// <summary>
    /// Check adjustment
    /// </summary>
    CheckAdjustment,

    /// <summary>
    /// Collection payment
    /// </summary>
    CollectionPayment,

    /// <summary>
    /// Collection receivable
    /// </summary>
    CollectionReceivable,

    /// <summary>
    /// Dishonored ACH return
    /// </summary>
    DishonoredAchReturn,

    /// <summary>
    /// Empyreal adjustment
    /// </summary>
    EmpyrealAdjustment,

    /// <summary>
    /// Error
    /// </summary>
    Error,

    /// <summary>
    /// Error correction
    /// </summary>
    ErrorCorrection,

    /// <summary>
    /// Fees
    /// </summary>
    Fees,

    /// <summary>
    /// General ledger transfer
    /// </summary>
    GeneralLedgerTransfer,

    /// <summary>
    /// Interest
    /// </summary>
    Interest,

    /// <summary>
    /// Negative balance forgiveness
    /// </summary>
    NegativeBalanceForgiveness,

    /// <summary>
    /// Sample funds
    /// </summary>
    SampleFunds,

    /// <summary>
    /// Sample funds return
    /// </summary>
    SampleFundsReturn,
}

sealed class InternalSourceReasonConverter : JsonConverter<InternalSourceReason>
{
    public override InternalSourceReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_closure" => InternalSourceReason.AccountClosure,
            "account_revenue_payment_distribution" =>
                InternalSourceReason.AccountRevenuePaymentDistribution,
            "bank_drawn_check" => InternalSourceReason.BankDrawnCheck,
            "bank_drawn_check_credit" => InternalSourceReason.BankDrawnCheckCredit,
            "bank_migration" => InternalSourceReason.BankMigration,
            "check_adjustment" => InternalSourceReason.CheckAdjustment,
            "collection_payment" => InternalSourceReason.CollectionPayment,
            "collection_receivable" => InternalSourceReason.CollectionReceivable,
            "dishonored_ach_return" => InternalSourceReason.DishonoredAchReturn,
            "empyreal_adjustment" => InternalSourceReason.EmpyrealAdjustment,
            "error" => InternalSourceReason.Error,
            "error_correction" => InternalSourceReason.ErrorCorrection,
            "fees" => InternalSourceReason.Fees,
            "general_ledger_transfer" => InternalSourceReason.GeneralLedgerTransfer,
            "interest" => InternalSourceReason.Interest,
            "negative_balance_forgiveness" => InternalSourceReason.NegativeBalanceForgiveness,
            "sample_funds" => InternalSourceReason.SampleFunds,
            "sample_funds_return" => InternalSourceReason.SampleFundsReturn,
            _ => (InternalSourceReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InternalSourceReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InternalSourceReason.AccountClosure => "account_closure",
                InternalSourceReason.AccountRevenuePaymentDistribution =>
                    "account_revenue_payment_distribution",
                InternalSourceReason.BankDrawnCheck => "bank_drawn_check",
                InternalSourceReason.BankDrawnCheckCredit => "bank_drawn_check_credit",
                InternalSourceReason.BankMigration => "bank_migration",
                InternalSourceReason.CheckAdjustment => "check_adjustment",
                InternalSourceReason.CollectionPayment => "collection_payment",
                InternalSourceReason.CollectionReceivable => "collection_receivable",
                InternalSourceReason.DishonoredAchReturn => "dishonored_ach_return",
                InternalSourceReason.EmpyrealAdjustment => "empyreal_adjustment",
                InternalSourceReason.Error => "error",
                InternalSourceReason.ErrorCorrection => "error_correction",
                InternalSourceReason.Fees => "fees",
                InternalSourceReason.GeneralLedgerTransfer => "general_ledger_transfer",
                InternalSourceReason.Interest => "interest",
                InternalSourceReason.NegativeBalanceForgiveness => "negative_balance_forgiveness",
                InternalSourceReason.SampleFunds => "sample_funds",
                InternalSourceReason.SampleFundsReturn => "sample_funds_return",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
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
/// A Real-Time Payments Transfer Acknowledgement object. This field will be present
/// in the JSON response if and only if `category` is equal to `real_time_payments_transfer_acknowledgement`.
/// A Real-Time Payments Transfer Acknowledgement is created when a Real-Time Payments
/// Transfer sent from Increase is acknowledged by the receiving bank.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimePaymentsTransferAcknowledgement,
        RealTimePaymentsTransferAcknowledgementFromRaw
    >)
)]
public sealed record class RealTimePaymentsTransferAcknowledgement : JsonModel
{
    /// <summary>
    /// The destination account number.
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
    /// The American Bankers' Association (ABA) Routing Transit Number (RTN).
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
    /// The identifier of the Real-Time Payments Transfer that led to this Transaction.
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

    /// <summary>
    /// Unstructured information that will show on the recipient's bank statement.
    /// </summary>
    public required string UnstructuredRemittanceInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unstructured_remittance_information");
        }
        init { this._rawData.Set("unstructured_remittance_information", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountNumber;
        _ = this.Amount;
        _ = this.RoutingNumber;
        _ = this.TransferID;
        _ = this.UnstructuredRemittanceInformation;
    }

    public RealTimePaymentsTransferAcknowledgement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimePaymentsTransferAcknowledgement(
        RealTimePaymentsTransferAcknowledgement realTimePaymentsTransferAcknowledgement
    )
        : base(realTimePaymentsTransferAcknowledgement) { }
#pragma warning restore CS8618

    public RealTimePaymentsTransferAcknowledgement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimePaymentsTransferAcknowledgement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimePaymentsTransferAcknowledgementFromRaw.FromRawUnchecked"/>
    public static RealTimePaymentsTransferAcknowledgement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimePaymentsTransferAcknowledgementFromRaw
    : IFromRawJson<RealTimePaymentsTransferAcknowledgement>
{
    /// <inheritdoc/>
    public RealTimePaymentsTransferAcknowledgement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimePaymentsTransferAcknowledgement.FromRawUnchecked(rawData);
}

/// <summary>
/// A Sample Funds object. This field will be present in the JSON response if and
/// only if `category` is equal to `sample_funds`. Sample funds for testing purposes.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SampleFunds, SampleFundsFromRaw>))]
public sealed record class SampleFunds : JsonModel
{
    /// <summary>
    /// Where the sample funds came from.
    /// </summary>
    public required string Originator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("originator");
        }
        init { this._rawData.Set("originator", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Originator;
    }

    public SampleFunds() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SampleFunds(SampleFunds sampleFunds)
        : base(sampleFunds) { }
#pragma warning restore CS8618

    public SampleFunds(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SampleFunds(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SampleFundsFromRaw.FromRawUnchecked"/>
    public static SampleFunds FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SampleFunds(string originator)
        : this()
    {
        this.Originator = originator;
    }
}

class SampleFundsFromRaw : IFromRawJson<SampleFunds>
{
    /// <inheritdoc/>
    public SampleFunds FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SampleFunds.FromRawUnchecked(rawData);
}

/// <summary>
/// A Swift Transfer Intention object. This field will be present in the JSON response
/// if and only if `category` is equal to `swift_transfer_intention`. A Swift Transfer
/// initiated via Increase.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SwiftTransferIntention, SwiftTransferIntentionFromRaw>))]
public sealed record class SwiftTransferIntention : JsonModel
{
    /// <summary>
    /// The identifier of the Swift Transfer that led to this Transaction.
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

    public SwiftTransferIntention() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SwiftTransferIntention(SwiftTransferIntention swiftTransferIntention)
        : base(swiftTransferIntention) { }
#pragma warning restore CS8618

    public SwiftTransferIntention(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwiftTransferIntention(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SwiftTransferIntentionFromRaw.FromRawUnchecked"/>
    public static SwiftTransferIntention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SwiftTransferIntention(string transferID)
        : this()
    {
        this.TransferID = transferID;
    }
}

class SwiftTransferIntentionFromRaw : IFromRawJson<SwiftTransferIntention>
{
    /// <inheritdoc/>
    public SwiftTransferIntention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SwiftTransferIntention.FromRawUnchecked(rawData);
}

/// <summary>
/// A Swift Transfer Return object. This field will be present in the JSON response
/// if and only if `category` is equal to `swift_transfer_return`. A Swift Transfer
/// Return is created when a Swift Transfer is returned by the receiving bank.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SwiftTransferReturn, SwiftTransferReturnFromRaw>))]
public sealed record class SwiftTransferReturn : JsonModel
{
    /// <summary>
    /// The identifier of the Swift Transfer that led to this Transaction.
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

    public SwiftTransferReturn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SwiftTransferReturn(SwiftTransferReturn swiftTransferReturn)
        : base(swiftTransferReturn) { }
#pragma warning restore CS8618

    public SwiftTransferReturn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwiftTransferReturn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SwiftTransferReturnFromRaw.FromRawUnchecked"/>
    public static SwiftTransferReturn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SwiftTransferReturn(string transferID)
        : this()
    {
        this.TransferID = transferID;
    }
}

class SwiftTransferReturnFromRaw : IFromRawJson<SwiftTransferReturn>
{
    /// <inheritdoc/>
    public SwiftTransferReturn FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SwiftTransferReturn.FromRawUnchecked(rawData);
}

/// <summary>
/// A Wire Transfer Intention object. This field will be present in the JSON response
/// if and only if `category` is equal to `wire_transfer_intention`. A Wire Transfer
/// initiated via Increase and sent to a different bank.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WireTransferIntention, WireTransferIntentionFromRaw>))]
public sealed record class WireTransferIntention : JsonModel
{
    /// <summary>
    /// The destination account number.
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
    /// The American Bankers' Association (ABA) Routing Transit Number (RTN).
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
    /// The identifier of the Wire Transfer that led to this Transaction.
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

    public WireTransferIntention() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireTransferIntention(WireTransferIntention wireTransferIntention)
        : base(wireTransferIntention) { }
#pragma warning restore CS8618

    public WireTransferIntention(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireTransferIntention(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireTransferIntentionFromRaw.FromRawUnchecked"/>
    public static WireTransferIntention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WireTransferIntentionFromRaw : IFromRawJson<WireTransferIntention>
{
    /// <inheritdoc/>
    public WireTransferIntention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WireTransferIntention.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `transaction`.
/// </summary>
[JsonConverter(typeof(TransactionTypeConverter))]
public enum TransactionType
{
    Transaction,
}

sealed class TransactionTypeConverter : JsonConverter<TransactionType>
{
    public override TransactionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "transaction" => TransactionType.Transaction,
            _ => (TransactionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransactionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransactionType.Transaction => "transaction",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
