using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.CheckDeposits;

/// <summary>
/// Check Deposits allow you to deposit images of paper checks into your account.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CheckDeposit, CheckDepositFromRaw>))]
public sealed record class CheckDeposit : JsonModel
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
    /// The Account the check was deposited into.
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
    /// Once your deposit is successfully parsed and accepted by Increase, this will
    /// contain details of the parsed check.
    /// </summary>
    public required DepositAcceptance? DepositAcceptance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DepositAcceptance>("deposit_acceptance");
        }
        init { this._rawData.Set("deposit_acceptance", value); }
    }

    /// <summary>
    /// If the deposit or the return was adjusted by the receiving institution, this
    /// will contain details of the adjustments.
    /// </summary>
    public required IReadOnlyList<DepositAdjustment> DepositAdjustments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DepositAdjustment>>(
                "deposit_adjustments"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<DepositAdjustment>>(
                "deposit_adjustments",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// If your deposit is rejected by Increase, this will contain details as to why
    /// it was rejected.
    /// </summary>
    public required DepositRejection? DepositRejection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DepositRejection>("deposit_rejection");
        }
        init { this._rawData.Set("deposit_rejection", value); }
    }

    /// <summary>
    /// If your deposit is returned, this will contain details as to why it was returned.
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
    /// After the check is parsed, it is submitted to the Check21 network for processing.
    /// This will contain details of the submission.
    /// </summary>
    public required DepositSubmission? DepositSubmission
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DepositSubmission>("deposit_submission");
        }
        init { this._rawData.Set("deposit_submission", value); }
    }

    /// <summary>
    /// The description of the Check Deposit, for display purposes only.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The ID for the File containing the image of the front of the check.
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

    /// <summary>
    /// The idempotency key you chose for this object. This value is unique across
    /// Increase and is used to ensure that a request is only processed once. Learn
    /// more about [idempotency](https://increase.com/documentation/idempotency-keys).
    /// </summary>
    public required string? IdempotencyKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("idempotency_key");
        }
        init { this._rawData.Set("idempotency_key", value); }
    }

    /// <summary>
    /// Increase will sometimes hold the funds for Check Deposits. If funds are held,
    /// this sub-object will contain details of the hold.
    /// </summary>
    public required InboundFundsHold? InboundFundsHold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundFundsHold>("inbound_funds_hold");
        }
        init { this._rawData.Set("inbound_funds_hold", value); }
    }

    /// <summary>
    /// If the Check Deposit was the result of an Inbound Mail Item, this will contain
    /// the identifier of the Inbound Mail Item.
    /// </summary>
    public required string? InboundMailItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inbound_mail_item_id");
        }
        init { this._rawData.Set("inbound_mail_item_id", value); }
    }

    /// <summary>
    /// If the Check Deposit was the result of an Inbound Mail Item, this will contain
    /// the identifier of the Lockbox that received it.
    /// </summary>
    public required string? LockboxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lockbox_id");
        }
        init { this._rawData.Set("lockbox_id", value); }
    }

    /// <summary>
    /// The status of the Check Deposit.
    /// </summary>
    public required ApiEnum<string, CheckDepositStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CheckDepositStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The ID for the Transaction created by the deposit.
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
    /// be `check_deposit`.
    /// </summary>
    public required ApiEnum<string, CheckDepositType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CheckDepositType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.Amount;
        _ = this.BackImageFileID;
        _ = this.CreatedAt;
        this.DepositAcceptance?.Validate();
        foreach (var item in this.DepositAdjustments)
        {
            item.Validate();
        }
        this.DepositRejection?.Validate();
        this.DepositReturn?.Validate();
        this.DepositSubmission?.Validate();
        _ = this.Description;
        _ = this.FrontImageFileID;
        _ = this.IdempotencyKey;
        this.InboundFundsHold?.Validate();
        _ = this.InboundMailItemID;
        _ = this.LockboxID;
        this.Status.Validate();
        _ = this.TransactionID;
        this.Type.Validate();
    }

    public CheckDeposit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckDeposit(CheckDeposit checkDeposit)
        : base(checkDeposit) { }
#pragma warning restore CS8618

    public CheckDeposit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckDeposit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckDepositFromRaw.FromRawUnchecked"/>
    public static CheckDeposit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckDepositFromRaw : IFromRawJson<CheckDeposit>
{
    /// <inheritdoc/>
    public CheckDeposit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CheckDeposit.FromRawUnchecked(rawData);
}

/// <summary>
/// Once your deposit is successfully parsed and accepted by Increase, this will
/// contain details of the parsed check.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DepositAcceptance, DepositAcceptanceFromRaw>))]
public sealed record class DepositAcceptance : JsonModel
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

    public DepositAcceptance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DepositAcceptance(DepositAcceptance depositAcceptance)
        : base(depositAcceptance) { }
#pragma warning restore CS8618

    public DepositAcceptance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DepositAcceptance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DepositAcceptanceFromRaw.FromRawUnchecked"/>
    public static DepositAcceptance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DepositAcceptanceFromRaw : IFromRawJson<DepositAcceptance>
{
    /// <inheritdoc/>
    public DepositAcceptance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DepositAcceptance.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's currency.
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

[JsonConverter(typeof(JsonModelConverter<DepositAdjustment, DepositAdjustmentFromRaw>))]
public sealed record class DepositAdjustment : JsonModel
{
    /// <summary>
    /// The time at which the adjustment was received.
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
    public required ApiEnum<string, Reason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Reason>>("reason");
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

    public DepositAdjustment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DepositAdjustment(DepositAdjustment depositAdjustment)
        : base(depositAdjustment) { }
#pragma warning restore CS8618

    public DepositAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DepositAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DepositAdjustmentFromRaw.FromRawUnchecked"/>
    public static DepositAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DepositAdjustmentFromRaw : IFromRawJson<DepositAdjustment>
{
    /// <inheritdoc/>
    public DepositAdjustment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DepositAdjustment.FromRawUnchecked(rawData);
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
/// If your deposit is rejected by Increase, this will contain details as to why
/// it was rejected.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DepositRejection, DepositRejectionFromRaw>))]
public sealed record class DepositRejection : JsonModel
{
    /// <summary>
    /// The rejected amount in the minor unit of check's currency. For dollars, for
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
    /// The identifier of the Check Deposit that was rejected.
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the check's currency.
    /// </summary>
    public required ApiEnum<string, DepositRejectionCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DepositRejectionCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The identifier of the associated declined transaction.
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
    /// Why the check deposit was rejected.
    /// </summary>
    public required ApiEnum<string, DepositRejectionReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DepositRejectionReason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the check deposit was rejected.
    /// </summary>
    public required System::DateTimeOffset RejectedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("rejected_at");
        }
        init { this._rawData.Set("rejected_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.CheckDepositID;
        this.Currency.Validate();
        _ = this.DeclinedTransactionID;
        this.Reason.Validate();
        _ = this.RejectedAt;
    }

    public DepositRejection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DepositRejection(DepositRejection depositRejection)
        : base(depositRejection) { }
#pragma warning restore CS8618

    public DepositRejection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DepositRejection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DepositRejectionFromRaw.FromRawUnchecked"/>
    public static DepositRejection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DepositRejectionFromRaw : IFromRawJson<DepositRejection>
{
    /// <inheritdoc/>
    public DepositRejection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DepositRejection.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the check's currency.
/// </summary>
[JsonConverter(typeof(DepositRejectionCurrencyConverter))]
public enum DepositRejectionCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class DepositRejectionCurrencyConverter : JsonConverter<DepositRejectionCurrency>
{
    public override DepositRejectionCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => DepositRejectionCurrency.Usd,
            _ => (DepositRejectionCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DepositRejectionCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DepositRejectionCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Why the check deposit was rejected.
/// </summary>
[JsonConverter(typeof(DepositRejectionReasonConverter))]
public enum DepositRejectionReason
{
    /// <summary>
    /// The check's image is incomplete.
    /// </summary>
    IncompleteImage,

    /// <summary>
    /// This is a duplicate check submission.
    /// </summary>
    Duplicate,

    /// <summary>
    /// This check has poor image quality.
    /// </summary>
    PoorImageQuality,

    /// <summary>
    /// The check was deposited with the incorrect amount.
    /// </summary>
    IncorrectAmount,

    /// <summary>
    /// The check is made out to someone other than the account holder.
    /// </summary>
    IncorrectRecipient,

    /// <summary>
    /// This check was not eligible for mobile deposit.
    /// </summary>
    NotEligibleForMobileDeposit,

    /// <summary>
    /// This check is missing at least one required field.
    /// </summary>
    MissingRequiredDataElements,

    /// <summary>
    /// This check is suspected to be fraudulent.
    /// </summary>
    SuspectedFraud,

    /// <summary>
    /// This check's deposit window has expired.
    /// </summary>
    DepositWindowExpired,

    /// <summary>
    /// The check was rejected at the user's request.
    /// </summary>
    RequestedByUser,

    /// <summary>
    /// The check is not a U.S. domestic check and cannot be processed.
    /// </summary>
    International,

    /// <summary>
    /// The check was rejected for an unknown reason.
    /// </summary>
    Unknown,
}

sealed class DepositRejectionReasonConverter : JsonConverter<DepositRejectionReason>
{
    public override DepositRejectionReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "incomplete_image" => DepositRejectionReason.IncompleteImage,
            "duplicate" => DepositRejectionReason.Duplicate,
            "poor_image_quality" => DepositRejectionReason.PoorImageQuality,
            "incorrect_amount" => DepositRejectionReason.IncorrectAmount,
            "incorrect_recipient" => DepositRejectionReason.IncorrectRecipient,
            "not_eligible_for_mobile_deposit" => DepositRejectionReason.NotEligibleForMobileDeposit,
            "missing_required_data_elements" => DepositRejectionReason.MissingRequiredDataElements,
            "suspected_fraud" => DepositRejectionReason.SuspectedFraud,
            "deposit_window_expired" => DepositRejectionReason.DepositWindowExpired,
            "requested_by_user" => DepositRejectionReason.RequestedByUser,
            "international" => DepositRejectionReason.International,
            "unknown" => DepositRejectionReason.Unknown,
            _ => (DepositRejectionReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DepositRejectionReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DepositRejectionReason.IncompleteImage => "incomplete_image",
                DepositRejectionReason.Duplicate => "duplicate",
                DepositRejectionReason.PoorImageQuality => "poor_image_quality",
                DepositRejectionReason.IncorrectAmount => "incorrect_amount",
                DepositRejectionReason.IncorrectRecipient => "incorrect_recipient",
                DepositRejectionReason.NotEligibleForMobileDeposit =>
                    "not_eligible_for_mobile_deposit",
                DepositRejectionReason.MissingRequiredDataElements =>
                    "missing_required_data_elements",
                DepositRejectionReason.SuspectedFraud => "suspected_fraud",
                DepositRejectionReason.DepositWindowExpired => "deposit_window_expired",
                DepositRejectionReason.RequestedByUser => "requested_by_user",
                DepositRejectionReason.International => "international",
                DepositRejectionReason.Unknown => "unknown",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If your deposit is returned, this will contain details as to why it was returned.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DepositReturn, DepositReturnFromRaw>))]
public sealed record class DepositReturn : JsonModel
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
    public required ApiEnum<string, DepositReturnCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DepositReturnCurrency>>(
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
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's currency.
/// </summary>
[JsonConverter(typeof(DepositReturnCurrencyConverter))]
public enum DepositReturnCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class DepositReturnCurrencyConverter : JsonConverter<DepositReturnCurrency>
{
    public override DepositReturnCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => DepositReturnCurrency.Usd,
            _ => (DepositReturnCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DepositReturnCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DepositReturnCurrency.Usd => "USD",
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
/// After the check is parsed, it is submitted to the Check21 network for processing.
/// This will contain details of the submission.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DepositSubmission, DepositSubmissionFromRaw>))]
public sealed record class DepositSubmission : JsonModel
{
    /// <summary>
    /// The ID for the File containing the check back image that was submitted to
    /// the Check21 network.
    /// </summary>
    public required string BackFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("back_file_id");
        }
        init { this._rawData.Set("back_file_id", value); }
    }

    /// <summary>
    /// The ID for the File containing the check front image that was submitted to
    /// the Check21 network.
    /// </summary>
    public required string FrontFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("front_file_id");
        }
        init { this._rawData.Set("front_file_id", value); }
    }

    /// <summary>
    /// When the check deposit was submitted to the Check21 network for processing.
    /// During business days, this happens within a few hours of the check being accepted
    /// by Increase.
    /// </summary>
    public required System::DateTimeOffset SubmittedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("submitted_at");
        }
        init { this._rawData.Set("submitted_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BackFileID;
        _ = this.FrontFileID;
        _ = this.SubmittedAt;
    }

    public DepositSubmission() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DepositSubmission(DepositSubmission depositSubmission)
        : base(depositSubmission) { }
#pragma warning restore CS8618

    public DepositSubmission(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DepositSubmission(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DepositSubmissionFromRaw.FromRawUnchecked"/>
    public static DepositSubmission FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DepositSubmissionFromRaw : IFromRawJson<DepositSubmission>
{
    /// <inheritdoc/>
    public DepositSubmission FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DepositSubmission.FromRawUnchecked(rawData);
}

/// <summary>
/// Increase will sometimes hold the funds for Check Deposits. If funds are held,
/// this sub-object will contain details of the hold.
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
    /// A constant representing the object's type. For this resource it will always
    /// be `inbound_funds_hold`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.CheckDeposits.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.CheckDeposits.Type>
            >("type");
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
[JsonConverter(typeof(StatusConverter))]
public enum Status
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
            "held" => Status.Held,
            "complete" => Status.Complete,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Held => "held",
                Status.Complete => "complete",
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
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    InboundFundsHold,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.CheckDeposits.Type>
{
    public override global::Increase.Api.Models.CheckDeposits.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_funds_hold" => global::Increase.Api.Models.CheckDeposits.Type.InboundFundsHold,
            _ => (global::Increase.Api.Models.CheckDeposits.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.CheckDeposits.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.CheckDeposits.Type.InboundFundsHold =>
                    "inbound_funds_hold",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the Check Deposit.
/// </summary>
[JsonConverter(typeof(CheckDepositStatusConverter))]
public enum CheckDepositStatus
{
    /// <summary>
    /// The Check Deposit is pending review.
    /// </summary>
    Pending,

    /// <summary>
    /// The Check Deposit has been deposited.
    /// </summary>
    Submitted,

    /// <summary>
    /// The Check Deposit has been rejected.
    /// </summary>
    Rejected,

    /// <summary>
    /// The Check Deposit has been returned.
    /// </summary>
    Returned,
}

sealed class CheckDepositStatusConverter : JsonConverter<CheckDepositStatus>
{
    public override CheckDepositStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => CheckDepositStatus.Pending,
            "submitted" => CheckDepositStatus.Submitted,
            "rejected" => CheckDepositStatus.Rejected,
            "returned" => CheckDepositStatus.Returned,
            _ => (CheckDepositStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckDepositStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckDepositStatus.Pending => "pending",
                CheckDepositStatus.Submitted => "submitted",
                CheckDepositStatus.Rejected => "rejected",
                CheckDepositStatus.Returned => "returned",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `check_deposit`.
/// </summary>
[JsonConverter(typeof(CheckDepositTypeConverter))]
public enum CheckDepositType
{
    CheckDeposit,
}

sealed class CheckDepositTypeConverter : JsonConverter<CheckDepositType>
{
    public override CheckDepositType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "check_deposit" => CheckDepositType.CheckDeposit,
            _ => (CheckDepositType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckDepositType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckDepositType.CheckDeposit => "check_deposit",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
