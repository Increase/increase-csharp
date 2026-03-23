using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.InboundCheckDeposits;

/// <summary>
/// Inbound Check Deposits are records of third-parties attempting to deposit checks
/// against your account.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InboundCheckDeposit, InboundCheckDepositFromRaw>))]
public sealed record class InboundCheckDeposit : JsonModel
{
    /// <summary>
    /// The deposit's identifier.
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
    /// If the Inbound Check Deposit was accepted, the [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601)
    /// date and time at which this took place.
    /// </summary>
    public required System::DateTimeOffset? AcceptedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("accepted_at");
        }
        init { this._rawData.Set("accepted_at", value); }
    }

    /// <summary>
    /// The Account the check is being deposited against.
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
    /// The Account Number the check is being deposited against.
    /// </summary>
    public required string? AccountNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_number_id");
        }
        init { this._rawData.Set("account_number_id", value); }
    }

    /// <summary>
    /// If the deposit or the return was adjusted by the sending institution, this
    /// will contain details of the adjustments.
    /// </summary>
    public required IReadOnlyList<Adjustment> Adjustments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Adjustment>>("adjustments");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Adjustment>>(
                "adjustments",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The deposited amount in USD cents.
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
    /// The ID for the File containing the image of the back of the check.
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
    /// The check number printed on the check being deposited.
    /// </summary>
    public required string? CheckNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("check_number");
        }
        init { this._rawData.Set("check_number", value); }
    }

    /// <summary>
    /// If this deposit is for an existing Check Transfer, the identifier of that
    /// Check Transfer.
    /// </summary>
    public required string? CheckTransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("check_transfer_id");
        }
        init { this._rawData.Set("check_transfer_id", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the deposit was attempted.
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the deposit.
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
    /// If the Inbound Check Deposit was declined, the [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601)
    /// date and time at which this took place.
    /// </summary>
    public required System::DateTimeOffset? DeclinedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("declined_at");
        }
        init { this._rawData.Set("declined_at", value); }
    }

    /// <summary>
    /// If the deposit attempt has been rejected, the identifier of the Declined
    /// Transaction object created as a result of the failed deposit.
    /// </summary>
    public required string? DeclinedTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("declined_transaction_id");
        }
        init { this._rawData.Set("declined_transaction_id", value); }
    }

    /// <summary>
    /// If you requested a return of this deposit, this will contain details of the return.
    /// </summary>
    public required DepositReturn? DepositReturn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DepositReturn>("deposit_return");
        }
        init { this._rawData.Set("deposit_return", value); }
    }

    /// <summary>
    /// The ID for the File containing the image of the front of the check.
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
    /// Whether the details on the check match the recipient name of the check transfer.
    /// This is an optional feature, contact sales to enable.
    /// </summary>
    public required ApiEnum<string, PayeeNameAnalysis> PayeeNameAnalysis
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PayeeNameAnalysis>>(
                "payee_name_analysis"
            );
        }
        init { this._rawData.Set("payee_name_analysis", value); }
    }

    /// <summary>
    /// The status of the Inbound Check Deposit.
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
    /// If the deposit attempt has been accepted, the identifier of the Transaction
    /// object created as a result of the successful deposit.
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
    /// A constant representing the object's type. For this resource it will always
    /// be `inbound_check_deposit`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.InboundCheckDeposits.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.InboundCheckDeposits.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AcceptedAt;
        _ = this.AccountID;
        _ = this.AccountNumberID;
        foreach (var item in this.Adjustments)
        {
            item.Validate();
        }
        _ = this.Amount;
        _ = this.BackImageFileID;
        _ = this.BankOfFirstDepositRoutingNumber;
        _ = this.CheckNumber;
        _ = this.CheckTransferID;
        _ = this.CreatedAt;
        this.Currency.Validate();
        _ = this.DeclinedAt;
        _ = this.DeclinedTransactionID;
        this.DepositReturn?.Validate();
        _ = this.FrontImageFileID;
        this.PayeeNameAnalysis.Validate();
        this.Status.Validate();
        _ = this.TransactionID;
        this.Type.Validate();
    }

    public InboundCheckDeposit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundCheckDeposit(InboundCheckDeposit inboundCheckDeposit)
        : base(inboundCheckDeposit) { }
#pragma warning restore CS8618

    public InboundCheckDeposit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundCheckDeposit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundCheckDepositFromRaw.FromRawUnchecked"/>
    public static InboundCheckDeposit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundCheckDepositFromRaw : IFromRawJson<InboundCheckDeposit>
{
    /// <inheritdoc/>
    public InboundCheckDeposit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InboundCheckDeposit.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Adjustment, AdjustmentFromRaw>))]
public sealed record class Adjustment : JsonModel
{
    /// <summary>
    /// The time at which the return adjustment was received.
    /// </summary>
    public required System::DateTimeOffset AdjustedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("adjusted_at");
        }
        init { this._rawData.Set("adjusted_at", value); }
    }

    /// <summary>
    /// The amount of the adjustment.
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
    public required ApiEnum<string, AdjustmentReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AdjustmentReason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The id of the transaction for the adjustment.
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
        _ = this.AdjustedAt;
        _ = this.Amount;
        this.Reason.Validate();
        _ = this.TransactionID;
    }

    public Adjustment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Adjustment(Adjustment adjustment)
        : base(adjustment) { }
#pragma warning restore CS8618

    public Adjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Adjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AdjustmentFromRaw.FromRawUnchecked"/>
    public static Adjustment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AdjustmentFromRaw : IFromRawJson<Adjustment>
{
    /// <inheritdoc/>
    public Adjustment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Adjustment.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason for the adjustment.
/// </summary>
[JsonConverter(typeof(AdjustmentReasonConverter))]
public enum AdjustmentReason
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

sealed class AdjustmentReasonConverter : JsonConverter<AdjustmentReason>
{
    public override AdjustmentReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "late_return" => AdjustmentReason.LateReturn,
            "wrong_payee_credit" => AdjustmentReason.WrongPayeeCredit,
            "adjusted_amount" => AdjustmentReason.AdjustedAmount,
            "non_conforming_item" => AdjustmentReason.NonConformingItem,
            "paid" => AdjustmentReason.Paid,
            _ => (AdjustmentReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdjustmentReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AdjustmentReason.LateReturn => "late_return",
                AdjustmentReason.WrongPayeeCredit => "wrong_payee_credit",
                AdjustmentReason.AdjustedAmount => "adjusted_amount",
                AdjustmentReason.NonConformingItem => "non_conforming_item",
                AdjustmentReason.Paid => "paid",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the deposit.
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
/// If you requested a return of this deposit, this will contain details of the return.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DepositReturn, DepositReturnFromRaw>))]
public sealed record class DepositReturn : JsonModel
{
    /// <summary>
    /// The reason the deposit was returned.
    /// </summary>
    public required ApiEnum<string, DepositReturnReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DepositReturnReason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The time at which the deposit was returned.
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
    /// The id of the transaction for the returned deposit.
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
        this.Reason.Validate();
        _ = this.ReturnedAt;
        _ = this.TransactionID;
    }

    public DepositReturn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DepositReturn(DepositReturn depositReturn)
        : base(depositReturn) { }
#pragma warning restore CS8618

    public DepositReturn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DepositReturn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DepositReturnFromRaw.FromRawUnchecked"/>
    public static DepositReturn FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DepositReturnFromRaw : IFromRawJson<DepositReturn>
{
    /// <inheritdoc/>
    public DepositReturn FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DepositReturn.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason the deposit was returned.
/// </summary>
[JsonConverter(typeof(DepositReturnReasonConverter))]
public enum DepositReturnReason
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

sealed class DepositReturnReasonConverter : JsonConverter<DepositReturnReason>
{
    public override DepositReturnReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "altered_or_fictitious" => DepositReturnReason.AlteredOrFictitious,
            "not_authorized" => DepositReturnReason.NotAuthorized,
            "duplicate_presentment" => DepositReturnReason.DuplicatePresentment,
            "endorsement_missing" => DepositReturnReason.EndorsementMissing,
            "endorsement_irregular" => DepositReturnReason.EndorsementIrregular,
            "refer_to_maker" => DepositReturnReason.ReferToMaker,
            _ => (DepositReturnReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DepositReturnReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DepositReturnReason.AlteredOrFictitious => "altered_or_fictitious",
                DepositReturnReason.NotAuthorized => "not_authorized",
                DepositReturnReason.DuplicatePresentment => "duplicate_presentment",
                DepositReturnReason.EndorsementMissing => "endorsement_missing",
                DepositReturnReason.EndorsementIrregular => "endorsement_irregular",
                DepositReturnReason.ReferToMaker => "refer_to_maker",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the details on the check match the recipient name of the check transfer.
/// This is an optional feature, contact sales to enable.
/// </summary>
[JsonConverter(typeof(PayeeNameAnalysisConverter))]
public enum PayeeNameAnalysis
{
    /// <summary>
    /// The details on the check match the recipient name of the check transfer.
    /// </summary>
    NameMatches,

    /// <summary>
    /// The details on the check do not match the recipient name of the check transfer.
    /// </summary>
    DoesNotMatch,

    /// <summary>
    /// The payee name analysis was not evaluated.
    /// </summary>
    NotEvaluated,
}

sealed class PayeeNameAnalysisConverter : JsonConverter<PayeeNameAnalysis>
{
    public override PayeeNameAnalysis Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "name_matches" => PayeeNameAnalysis.NameMatches,
            "does_not_match" => PayeeNameAnalysis.DoesNotMatch,
            "not_evaluated" => PayeeNameAnalysis.NotEvaluated,
            _ => (PayeeNameAnalysis)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayeeNameAnalysis value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayeeNameAnalysis.NameMatches => "name_matches",
                PayeeNameAnalysis.DoesNotMatch => "does_not_match",
                PayeeNameAnalysis.NotEvaluated => "not_evaluated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the Inbound Check Deposit.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// The Inbound Check Deposit is pending.
    /// </summary>
    Pending,

    /// <summary>
    /// The Inbound Check Deposit was accepted.
    /// </summary>
    Accepted,

    /// <summary>
    /// The Inbound Check Deposit was rejected.
    /// </summary>
    Declined,

    /// <summary>
    /// The Inbound Check Deposit was returned.
    /// </summary>
    Returned,

    /// <summary>
    /// The Inbound Check Deposit requires attention from an Increase operator.
    /// </summary>
    RequiresAttention,
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
            "pending" => Status.Pending,
            "accepted" => Status.Accepted,
            "declined" => Status.Declined,
            "returned" => Status.Returned,
            "requires_attention" => Status.RequiresAttention,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "pending",
                Status.Accepted => "accepted",
                Status.Declined => "declined",
                Status.Returned => "returned",
                Status.RequiresAttention => "requires_attention",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `inbound_check_deposit`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    InboundCheckDeposit,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.InboundCheckDeposits.Type>
{
    public override global::Increase.Api.Models.InboundCheckDeposits.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_check_deposit" => global::Increase
                .Api
                .Models
                .InboundCheckDeposits
                .Type
                .InboundCheckDeposit,
            _ => (global::Increase.Api.Models.InboundCheckDeposits.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.InboundCheckDeposits.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.InboundCheckDeposits.Type.InboundCheckDeposit =>
                    "inbound_check_deposit",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
