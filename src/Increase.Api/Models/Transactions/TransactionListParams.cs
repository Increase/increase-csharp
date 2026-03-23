using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Transactions;

/// <summary>
/// List Transactions
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TransactionListParams : ParamsBase
{
    /// <summary>
    /// Filter Transactions for those belonging to the specified Account.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("account_id", value);
        }
    }

    public Category? Category
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Category>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("category", value);
        }
    }

    public CreatedAt? CreatedAt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<CreatedAt>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Return the page of entries after this one.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    /// <summary>
    /// Limit the size of the list that is returned. The default (and maximum) is
    /// 100 objects.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Filter Transactions for those belonging to the specified route. This could
    /// be a Card ID or an Account Number ID.
    /// </summary>
    public string? RouteID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("route_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("route_id", value);
        }
    }

    public TransactionListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransactionListParams(TransactionListParams transactionListParams)
        : base(transactionListParams) { }
#pragma warning restore CS8618

    public TransactionListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TransactionListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TransactionListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TransactionListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/transactions")
        {
            Query = this.QueryString(options),
        }.Uri;
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

[JsonConverter(typeof(JsonModelConverter<Category, CategoryFromRaw>))]
public sealed record class Category : JsonModel
{
    /// <summary>
    /// Return results whose value is in the provided list. For GET requests, this
    /// should be encoded as a comma-delimited string, such as `?in=one,two,three`.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, In>>? In
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, In>>>("in");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, In>>?>(
                "in",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.In ?? [])
        {
            item.Validate();
        }
    }

    public Category() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Category(Category category)
        : base(category) { }
#pragma warning restore CS8618

    public Category(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Category(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CategoryFromRaw.FromRawUnchecked"/>
    public static Category FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CategoryFromRaw : IFromRawJson<Category>
{
    /// <inheritdoc/>
    public Category FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Category.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InConverter))]
public enum In
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

sealed class InConverter : JsonConverter<In>
{
    public override In Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_transfer_intention" => In.AccountTransferIntention,
            "ach_transfer_intention" => In.AchTransferIntention,
            "ach_transfer_rejection" => In.AchTransferRejection,
            "ach_transfer_return" => In.AchTransferReturn,
            "cashback_payment" => In.CashbackPayment,
            "card_dispute_acceptance" => In.CardDisputeAcceptance,
            "card_dispute_financial" => In.CardDisputeFinancial,
            "card_dispute_loss" => In.CardDisputeLoss,
            "card_refund" => In.CardRefund,
            "card_settlement" => In.CardSettlement,
            "card_financial" => In.CardFinancial,
            "card_revenue_payment" => In.CardRevenuePayment,
            "check_deposit_acceptance" => In.CheckDepositAcceptance,
            "check_deposit_return" => In.CheckDepositReturn,
            "fednow_transfer_acknowledgement" => In.FednowTransferAcknowledgement,
            "check_transfer_deposit" => In.CheckTransferDeposit,
            "fee_payment" => In.FeePayment,
            "inbound_ach_transfer" => In.InboundAchTransfer,
            "inbound_ach_transfer_return_intention" => In.InboundAchTransferReturnIntention,
            "inbound_check_deposit_return_intention" => In.InboundCheckDepositReturnIntention,
            "inbound_check_adjustment" => In.InboundCheckAdjustment,
            "inbound_fednow_transfer_confirmation" => In.InboundFednowTransferConfirmation,
            "inbound_real_time_payments_transfer_confirmation" =>
                In.InboundRealTimePaymentsTransferConfirmation,
            "inbound_wire_reversal" => In.InboundWireReversal,
            "inbound_wire_transfer" => In.InboundWireTransfer,
            "inbound_wire_transfer_reversal" => In.InboundWireTransferReversal,
            "interest_payment" => In.InterestPayment,
            "internal_source" => In.InternalSource,
            "real_time_payments_transfer_acknowledgement" =>
                In.RealTimePaymentsTransferAcknowledgement,
            "sample_funds" => In.SampleFunds,
            "wire_transfer_intention" => In.WireTransferIntention,
            "swift_transfer_intention" => In.SwiftTransferIntention,
            "swift_transfer_return" => In.SwiftTransferReturn,
            "card_push_transfer_acceptance" => In.CardPushTransferAcceptance,
            "account_revenue_payment" => In.AccountRevenuePayment,
            "blockchain_onramp_transfer_intention" => In.BlockchainOnrampTransferIntention,
            "blockchain_offramp_transfer_settlement" => In.BlockchainOfframpTransferSettlement,
            "other" => In.Other,
            _ => (In)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, In value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                In.AccountTransferIntention => "account_transfer_intention",
                In.AchTransferIntention => "ach_transfer_intention",
                In.AchTransferRejection => "ach_transfer_rejection",
                In.AchTransferReturn => "ach_transfer_return",
                In.CashbackPayment => "cashback_payment",
                In.CardDisputeAcceptance => "card_dispute_acceptance",
                In.CardDisputeFinancial => "card_dispute_financial",
                In.CardDisputeLoss => "card_dispute_loss",
                In.CardRefund => "card_refund",
                In.CardSettlement => "card_settlement",
                In.CardFinancial => "card_financial",
                In.CardRevenuePayment => "card_revenue_payment",
                In.CheckDepositAcceptance => "check_deposit_acceptance",
                In.CheckDepositReturn => "check_deposit_return",
                In.FednowTransferAcknowledgement => "fednow_transfer_acknowledgement",
                In.CheckTransferDeposit => "check_transfer_deposit",
                In.FeePayment => "fee_payment",
                In.InboundAchTransfer => "inbound_ach_transfer",
                In.InboundAchTransferReturnIntention => "inbound_ach_transfer_return_intention",
                In.InboundCheckDepositReturnIntention => "inbound_check_deposit_return_intention",
                In.InboundCheckAdjustment => "inbound_check_adjustment",
                In.InboundFednowTransferConfirmation => "inbound_fednow_transfer_confirmation",
                In.InboundRealTimePaymentsTransferConfirmation =>
                    "inbound_real_time_payments_transfer_confirmation",
                In.InboundWireReversal => "inbound_wire_reversal",
                In.InboundWireTransfer => "inbound_wire_transfer",
                In.InboundWireTransferReversal => "inbound_wire_transfer_reversal",
                In.InterestPayment => "interest_payment",
                In.InternalSource => "internal_source",
                In.RealTimePaymentsTransferAcknowledgement =>
                    "real_time_payments_transfer_acknowledgement",
                In.SampleFunds => "sample_funds",
                In.WireTransferIntention => "wire_transfer_intention",
                In.SwiftTransferIntention => "swift_transfer_intention",
                In.SwiftTransferReturn => "swift_transfer_return",
                In.CardPushTransferAcceptance => "card_push_transfer_acceptance",
                In.AccountRevenuePayment => "account_revenue_payment",
                In.BlockchainOnrampTransferIntention => "blockchain_onramp_transfer_intention",
                In.BlockchainOfframpTransferSettlement => "blockchain_offramp_transfer_settlement",
                In.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<CreatedAt, CreatedAtFromRaw>))]
public sealed record class CreatedAt : JsonModel
{
    /// <summary>
    /// Return results after this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? After
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("after", value);
        }
    }

    /// <summary>
    /// Return results before this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? Before
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("before", value);
        }
    }

    /// <summary>
    /// Return results on or after this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? OnOrAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("on_or_after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_after", value);
        }
    }

    /// <summary>
    /// Return results on or before this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? OnOrBefore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("on_or_before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_before", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
        _ = this.OnOrAfter;
        _ = this.OnOrBefore;
    }

    public CreatedAt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatedAt(CreatedAt createdAt)
        : base(createdAt) { }
#pragma warning restore CS8618

    public CreatedAt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatedAt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatedAtFromRaw.FromRawUnchecked"/>
    public static CreatedAt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreatedAtFromRaw : IFromRawJson<CreatedAt>
{
    /// <inheritdoc/>
    public CreatedAt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreatedAt.FromRawUnchecked(rawData);
}
