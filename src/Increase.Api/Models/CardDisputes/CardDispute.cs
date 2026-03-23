using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.CardDisputes;

/// <summary>
/// If unauthorized activity occurs on a card, you can create a Card Dispute and
/// we'll work with the card networks to return the funds if appropriate.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardDispute, CardDisputeFromRaw>))]
public sealed record class CardDispute : JsonModel
{
    /// <summary>
    /// The Card Dispute identifier.
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
    /// The amount of the dispute.
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
    /// The Card that the Card Dispute is associated with.
    /// </summary>
    public required string CardID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("card_id");
        }
        init { this._rawData.Set("card_id", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Card Dispute was created.
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
    /// The identifier of the Transaction that was disputed.
    /// </summary>
    public required string DisputedTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("disputed_transaction_id");
        }
        init { this._rawData.Set("disputed_transaction_id", value); }
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
    /// If the Card Dispute's status is `lost`, this will contain details of the lost dispute.
    /// </summary>
    public required Loss? Loss
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Loss>("loss");
        }
        init { this._rawData.Set("loss", value); }
    }

    /// <summary>
    /// The network that the Card Dispute is associated with.
    /// </summary>
    public required ApiEnum<string, CardDisputeNetwork> Network
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardDisputeNetwork>>("network");
        }
        init { this._rawData.Set("network", value); }
    }

    /// <summary>
    /// The status of the Card Dispute.
    /// </summary>
    public required ApiEnum<string, CardDisputeStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardDisputeStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `card_dispute`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.CardDisputes.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.CardDisputes.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the user submission is required by. Present only if status is `user_submission_required`
    /// and a user submission is required by a certain time. Otherwise, this will
    /// be `nil`.
    /// </summary>
    public required System::DateTimeOffset? UserSubmissionRequiredBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "user_submission_required_by"
            );
        }
        init { this._rawData.Set("user_submission_required_by", value); }
    }

    /// <summary>
    /// Card Dispute information for card payments processed over Visa's network.
    /// This field will be present in the JSON response if and only if `network`
    /// is equal to `visa`.
    /// </summary>
    public required CardDisputeVisa? Visa
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDisputeVisa>("visa");
        }
        init { this._rawData.Set("visa", value); }
    }

    /// <summary>
    /// If the Card Dispute's status is `won`, this will contain details of the won dispute.
    /// </summary>
    public required Win? Win
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Win>("win");
        }
        init { this._rawData.Set("win", value); }
    }

    /// <summary>
    /// If the Card Dispute has been withdrawn, this will contain details of the withdrawal.
    /// </summary>
    public required Withdrawal? Withdrawal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Withdrawal>("withdrawal");
        }
        init { this._rawData.Set("withdrawal", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.CardID;
        _ = this.CreatedAt;
        _ = this.DisputedTransactionID;
        _ = this.IdempotencyKey;
        this.Loss?.Validate();
        this.Network.Validate();
        this.Status.Validate();
        this.Type.Validate();
        _ = this.UserSubmissionRequiredBy;
        this.Visa?.Validate();
        this.Win?.Validate();
        this.Withdrawal?.Validate();
    }

    public CardDispute() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDispute(CardDispute cardDispute)
        : base(cardDispute) { }
#pragma warning restore CS8618

    public CardDispute(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDispute(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDisputeFromRaw.FromRawUnchecked"/>
    public static CardDispute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDisputeFromRaw : IFromRawJson<CardDispute>
{
    /// <inheritdoc/>
    public CardDispute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardDispute.FromRawUnchecked(rawData);
}

/// <summary>
/// If the Card Dispute's status is `lost`, this will contain details of the lost dispute.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Loss, LossFromRaw>))]
public sealed record class Loss : JsonModel
{
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
    /// The reason the Card Dispute was lost.
    /// </summary>
    public required ApiEnum<string, LossReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LossReason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LostAt;
        this.Reason.Validate();
    }

    public Loss() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Loss(Loss loss)
        : base(loss) { }
#pragma warning restore CS8618

    public Loss(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Loss(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LossFromRaw.FromRawUnchecked"/>
    public static Loss FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LossFromRaw : IFromRawJson<Loss>
{
    /// <inheritdoc/>
    public Loss FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Loss.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason the Card Dispute was lost.
/// </summary>
[JsonConverter(typeof(LossReasonConverter))]
public enum LossReason
{
    /// <summary>
    /// The user withdrew the Card Dispute.
    /// </summary>
    UserWithdrawn,

    /// <summary>
    /// The Card Dispute was lost according to network rules.
    /// </summary>
    Loss,
}

sealed class LossReasonConverter : JsonConverter<LossReason>
{
    public override LossReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user_withdrawn" => LossReason.UserWithdrawn,
            "loss" => LossReason.Loss,
            _ => (LossReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LossReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LossReason.UserWithdrawn => "user_withdrawn",
                LossReason.Loss => "loss",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The network that the Card Dispute is associated with.
/// </summary>
[JsonConverter(typeof(CardDisputeNetworkConverter))]
public enum CardDisputeNetwork
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

sealed class CardDisputeNetworkConverter : JsonConverter<CardDisputeNetwork>
{
    public override CardDisputeNetwork Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => CardDisputeNetwork.Visa,
            "pulse" => CardDisputeNetwork.Pulse,
            _ => (CardDisputeNetwork)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDisputeNetwork value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDisputeNetwork.Visa => "visa",
                CardDisputeNetwork.Pulse => "pulse",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the Card Dispute.
/// </summary>
[JsonConverter(typeof(CardDisputeStatusConverter))]
public enum CardDisputeStatus
{
    /// <summary>
    /// A User Submission is required to continue with the Card Dispute.
    /// </summary>
    UserSubmissionRequired,

    /// <summary>
    /// The most recent User Submission is being reviewed.
    /// </summary>
    PendingUserSubmissionReviewing,

    /// <summary>
    /// The most recent User Submission is being submitted to the network.
    /// </summary>
    PendingUserSubmissionSubmitting,

    /// <summary>
    /// The user's withdrawal of the Card Dispute is being submitted to the network.
    /// </summary>
    PendingUserWithdrawalSubmitting,

    /// <summary>
    /// The Card Dispute is pending a response from the network.
    /// </summary>
    PendingResponse,

    /// <summary>
    /// The Card Dispute has been lost and funds previously credited from the acceptance
    /// have been debited.
    /// </summary>
    Lost,

    /// <summary>
    /// The Card Dispute has been won and no further action can be taken.
    /// </summary>
    Won,
}

sealed class CardDisputeStatusConverter : JsonConverter<CardDisputeStatus>
{
    public override CardDisputeStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user_submission_required" => CardDisputeStatus.UserSubmissionRequired,
            "pending_user_submission_reviewing" => CardDisputeStatus.PendingUserSubmissionReviewing,
            "pending_user_submission_submitting" =>
                CardDisputeStatus.PendingUserSubmissionSubmitting,
            "pending_user_withdrawal_submitting" =>
                CardDisputeStatus.PendingUserWithdrawalSubmitting,
            "pending_response" => CardDisputeStatus.PendingResponse,
            "lost" => CardDisputeStatus.Lost,
            "won" => CardDisputeStatus.Won,
            _ => (CardDisputeStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDisputeStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDisputeStatus.UserSubmissionRequired => "user_submission_required",
                CardDisputeStatus.PendingUserSubmissionReviewing =>
                    "pending_user_submission_reviewing",
                CardDisputeStatus.PendingUserSubmissionSubmitting =>
                    "pending_user_submission_submitting",
                CardDisputeStatus.PendingUserWithdrawalSubmitting =>
                    "pending_user_withdrawal_submitting",
                CardDisputeStatus.PendingResponse => "pending_response",
                CardDisputeStatus.Lost => "lost",
                CardDisputeStatus.Won => "won",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_dispute`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    CardDispute,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.CardDisputes.Type>
{
    public override global::Increase.Api.Models.CardDisputes.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_dispute" => global::Increase.Api.Models.CardDisputes.Type.CardDispute,
            _ => (global::Increase.Api.Models.CardDisputes.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.CardDisputes.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.CardDisputes.Type.CardDispute => "card_dispute",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Card Dispute information for card payments processed over Visa's network. This
/// field will be present in the JSON response if and only if `network` is equal
/// to `visa`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardDisputeVisa, CardDisputeVisaFromRaw>))]
public sealed record class CardDisputeVisa : JsonModel
{
    /// <summary>
    /// The network events for the Card Dispute.
    /// </summary>
    public required IReadOnlyList<NetworkEvent> NetworkEvents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<NetworkEvent>>("network_events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<NetworkEvent>>(
                "network_events",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The category of the currently required user submission if the user wishes
    /// to proceed with the dispute. Present if and only if status is `user_submission_required`.
    /// Otherwise, this will be `nil`.
    /// </summary>
    public required ApiEnum<string, RequiredUserSubmissionCategory>? RequiredUserSubmissionCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RequiredUserSubmissionCategory>>(
                "required_user_submission_category"
            );
        }
        init { this._rawData.Set("required_user_submission_category", value); }
    }

    /// <summary>
    /// The user submissions for the Card Dispute.
    /// </summary>
    public required IReadOnlyList<UserSubmission> UserSubmissions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UserSubmission>>(
                "user_submissions"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<UserSubmission>>(
                "user_submissions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.NetworkEvents)
        {
            item.Validate();
        }
        this.RequiredUserSubmissionCategory?.Validate();
        foreach (var item in this.UserSubmissions)
        {
            item.Validate();
        }
    }

    public CardDisputeVisa() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDisputeVisa(CardDisputeVisa cardDisputeVisa)
        : base(cardDisputeVisa) { }
#pragma warning restore CS8618

    public CardDisputeVisa(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDisputeVisa(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDisputeVisaFromRaw.FromRawUnchecked"/>
    public static CardDisputeVisa FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDisputeVisaFromRaw : IFromRawJson<CardDisputeVisa>
{
    /// <inheritdoc/>
    public CardDisputeVisa FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardDisputeVisa.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<NetworkEvent, NetworkEventFromRaw>))]
public sealed record class NetworkEvent : JsonModel
{
    /// <summary>
    /// The files attached to the Visa Card Dispute User Submission.
    /// </summary>
    public required IReadOnlyList<NetworkEventAttachmentFile> AttachmentFiles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<NetworkEventAttachmentFile>>(
                "attachment_files"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<NetworkEventAttachmentFile>>(
                "attachment_files",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The category of the user submission. We may add additional possible values
    /// for this enum over time; your application should be able to handle such additions gracefully.
    /// </summary>
    public required ApiEnum<string, NetworkEventCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NetworkEventCategory>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Visa Card Dispute Network Event was created.
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
    /// The dispute financial transaction that resulted from the network event, if any.
    /// </summary>
    public required string? DisputeFinancialTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dispute_financial_transaction_id");
        }
        init { this._rawData.Set("dispute_financial_transaction_id", value); }
    }

    /// <summary>
    /// A Card Dispute Chargeback Accepted Visa Network Event object. This field will
    /// be present in the JSON response if and only if `category` is equal to `chargeback_accepted`.
    /// Contains the details specific to a chargeback accepted Visa Card Dispute
    /// Network Event, which represents that a chargeback has been accepted by the merchant.
    /// </summary>
    public ChargebackAccepted? ChargebackAccepted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackAccepted>("chargeback_accepted");
        }
        init { this._rawData.Set("chargeback_accepted", value); }
    }

    /// <summary>
    /// A Card Dispute Chargeback Submitted Visa Network Event object. This field
    /// will be present in the JSON response if and only if `category` is equal to
    /// `chargeback_submitted`. Contains the details specific to a chargeback submitted
    /// Visa Card Dispute Network Event, which represents that a chargeback has been
    /// submitted to the network.
    /// </summary>
    public ChargebackSubmitted? ChargebackSubmitted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackSubmitted>("chargeback_submitted");
        }
        init { this._rawData.Set("chargeback_submitted", value); }
    }

    /// <summary>
    /// A Card Dispute Chargeback Timed Out Visa Network Event object. This field
    /// will be present in the JSON response if and only if `category` is equal to
    /// `chargeback_timed_out`. Contains the details specific to a chargeback timed
    /// out Visa Card Dispute Network Event, which represents that the chargeback
    /// has timed out in the user's favor.
    /// </summary>
    public ChargebackTimedOut? ChargebackTimedOut
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackTimedOut>("chargeback_timed_out");
        }
        init { this._rawData.Set("chargeback_timed_out", value); }
    }

    /// <summary>
    /// A Card Dispute Merchant Pre-Arbitration Decline Submitted Visa Network Event
    /// object. This field will be present in the JSON response if and only if `category`
    /// is equal to `merchant_prearbitration_decline_submitted`. Contains the details
    /// specific to a merchant prearbitration decline submitted Visa Card Dispute
    /// Network Event, which represents that the user has declined the merchant's
    /// request for a prearbitration request decision in their favor.
    /// </summary>
    public MerchantPrearbitrationDeclineSubmitted? MerchantPrearbitrationDeclineSubmitted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MerchantPrearbitrationDeclineSubmitted>(
                "merchant_prearbitration_decline_submitted"
            );
        }
        init { this._rawData.Set("merchant_prearbitration_decline_submitted", value); }
    }

    /// <summary>
    /// A Card Dispute Merchant Pre-Arbitration Received Visa Network Event object.
    /// This field will be present in the JSON response if and only if `category`
    /// is equal to `merchant_prearbitration_received`. Contains the details specific
    /// to a merchant prearbitration received Visa Card Dispute Network Event, which
    /// represents that the merchant has issued a prearbitration request in the user's favor.
    /// </summary>
    public MerchantPrearbitrationReceived? MerchantPrearbitrationReceived
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MerchantPrearbitrationReceived>(
                "merchant_prearbitration_received"
            );
        }
        init { this._rawData.Set("merchant_prearbitration_received", value); }
    }

    /// <summary>
    /// A Card Dispute Merchant Pre-Arbitration Timed Out Visa Network Event object.
    /// This field will be present in the JSON response if and only if `category`
    /// is equal to `merchant_prearbitration_timed_out`. Contains the details specific
    /// to a merchant prearbitration timed out Visa Card Dispute Network Event, which
    /// represents that the user has timed out responding to the merchant's prearbitration request.
    /// </summary>
    public MerchantPrearbitrationTimedOut? MerchantPrearbitrationTimedOut
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MerchantPrearbitrationTimedOut>(
                "merchant_prearbitration_timed_out"
            );
        }
        init { this._rawData.Set("merchant_prearbitration_timed_out", value); }
    }

    /// <summary>
    /// A Card Dispute Re-presented Visa Network Event object. This field will be
    /// present in the JSON response if and only if `category` is equal to `represented`.
    /// Contains the details specific to a re-presented Visa Card Dispute Network
    /// Event, which represents that the merchant has declined the user's chargeback
    /// and has re-presented the payment.
    /// </summary>
    public Represented? Represented
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Represented>("represented");
        }
        init { this._rawData.Set("represented", value); }
    }

    /// <summary>
    /// A Card Dispute Re-presentment Timed Out Visa Network Event object. This field
    /// will be present in the JSON response if and only if `category` is equal to
    /// `representment_timed_out`. Contains the details specific to a re-presentment
    /// time-out Visa Card Dispute Network Event, which represents that the user
    /// did not respond to the re-presentment by the merchant within the time limit.
    /// </summary>
    public RepresentmentTimedOut? RepresentmentTimedOut
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RepresentmentTimedOut>("representment_timed_out");
        }
        init { this._rawData.Set("representment_timed_out", value); }
    }

    /// <summary>
    /// A Card Dispute User Pre-Arbitration Accepted Visa Network Event object. This
    /// field will be present in the JSON response if and only if `category` is equal
    /// to `user_prearbitration_accepted`. Contains the details specific to a user
    /// prearbitration accepted Visa Card Dispute Network Event, which represents
    /// that the merchant has accepted the user's prearbitration request in the user's favor.
    /// </summary>
    public UserPrearbitrationAccepted? UserPrearbitrationAccepted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserPrearbitrationAccepted>(
                "user_prearbitration_accepted"
            );
        }
        init { this._rawData.Set("user_prearbitration_accepted", value); }
    }

    /// <summary>
    /// A Card Dispute User Pre-Arbitration Declined Visa Network Event object. This
    /// field will be present in the JSON response if and only if `category` is equal
    /// to `user_prearbitration_declined`. Contains the details specific to a user
    /// prearbitration declined Visa Card Dispute Network Event, which represents
    /// that the merchant has declined the user's prearbitration request.
    /// </summary>
    public UserPrearbitrationDeclined? UserPrearbitrationDeclined
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserPrearbitrationDeclined>(
                "user_prearbitration_declined"
            );
        }
        init { this._rawData.Set("user_prearbitration_declined", value); }
    }

    /// <summary>
    /// A Card Dispute User Pre-Arbitration Submitted Visa Network Event object.
    /// This field will be present in the JSON response if and only if `category`
    /// is equal to `user_prearbitration_submitted`. Contains the details specific
    /// to a user prearbitration submitted Visa Card Dispute Network Event, which
    /// represents that the user's request for prearbitration has been submitted to
    /// the network.
    /// </summary>
    public UserPrearbitrationSubmitted? UserPrearbitrationSubmitted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserPrearbitrationSubmitted>(
                "user_prearbitration_submitted"
            );
        }
        init { this._rawData.Set("user_prearbitration_submitted", value); }
    }

    /// <summary>
    /// A Card Dispute User Pre-Arbitration Timed Out Visa Network Event object. This
    /// field will be present in the JSON response if and only if `category` is equal
    /// to `user_prearbitration_timed_out`. Contains the details specific to a user
    /// prearbitration timed out Visa Card Dispute Network Event, which represents
    /// that the merchant has timed out responding to the user's prearbitration request.
    /// </summary>
    public UserPrearbitrationTimedOut? UserPrearbitrationTimedOut
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserPrearbitrationTimedOut>(
                "user_prearbitration_timed_out"
            );
        }
        init { this._rawData.Set("user_prearbitration_timed_out", value); }
    }

    /// <summary>
    /// A Card Dispute User Withdrawal Submitted Visa Network Event object. This field
    /// will be present in the JSON response if and only if `category` is equal to
    /// `user_withdrawal_submitted`. Contains the details specific to a user withdrawal
    /// submitted Visa Card Dispute Network Event, which represents that the user's
    /// request to withdraw the dispute has been submitted to the network.
    /// </summary>
    public UserWithdrawalSubmitted? UserWithdrawalSubmitted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserWithdrawalSubmitted>(
                "user_withdrawal_submitted"
            );
        }
        init { this._rawData.Set("user_withdrawal_submitted", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AttachmentFiles)
        {
            item.Validate();
        }
        this.Category.Validate();
        _ = this.CreatedAt;
        _ = this.DisputeFinancialTransactionID;
        this.ChargebackAccepted?.Validate();
        this.ChargebackSubmitted?.Validate();
        this.ChargebackTimedOut?.Validate();
        this.MerchantPrearbitrationDeclineSubmitted?.Validate();
        this.MerchantPrearbitrationReceived?.Validate();
        this.MerchantPrearbitrationTimedOut?.Validate();
        this.Represented?.Validate();
        this.RepresentmentTimedOut?.Validate();
        this.UserPrearbitrationAccepted?.Validate();
        this.UserPrearbitrationDeclined?.Validate();
        this.UserPrearbitrationSubmitted?.Validate();
        this.UserPrearbitrationTimedOut?.Validate();
        this.UserWithdrawalSubmitted?.Validate();
    }

    public NetworkEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkEvent(NetworkEvent networkEvent)
        : base(networkEvent) { }
#pragma warning restore CS8618

    public NetworkEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NetworkEventFromRaw.FromRawUnchecked"/>
    public static NetworkEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NetworkEventFromRaw : IFromRawJson<NetworkEvent>
{
    /// <inheritdoc/>
    public NetworkEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NetworkEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<NetworkEventAttachmentFile, NetworkEventAttachmentFileFromRaw>)
)]
public sealed record class NetworkEventAttachmentFile : JsonModel
{
    /// <summary>
    /// The ID of the file attached to the Card Dispute.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
    }

    public NetworkEventAttachmentFile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkEventAttachmentFile(NetworkEventAttachmentFile networkEventAttachmentFile)
        : base(networkEventAttachmentFile) { }
#pragma warning restore CS8618

    public NetworkEventAttachmentFile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkEventAttachmentFile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NetworkEventAttachmentFileFromRaw.FromRawUnchecked"/>
    public static NetworkEventAttachmentFile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NetworkEventAttachmentFile(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class NetworkEventAttachmentFileFromRaw : IFromRawJson<NetworkEventAttachmentFile>
{
    /// <inheritdoc/>
    public NetworkEventAttachmentFile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NetworkEventAttachmentFile.FromRawUnchecked(rawData);
}

/// <summary>
/// The category of the user submission. We may add additional possible values for
/// this enum over time; your application should be able to handle such additions gracefully.
/// </summary>
[JsonConverter(typeof(NetworkEventCategoryConverter))]
public enum NetworkEventCategory
{
    /// <summary>
    /// Card Dispute Chargeback Accepted Visa Network Event: details will be under
    /// the `chargeback_accepted` object.
    /// </summary>
    ChargebackAccepted,

    /// <summary>
    /// Card Dispute Chargeback Submitted Visa Network Event: details will be under
    /// the `chargeback_submitted` object.
    /// </summary>
    ChargebackSubmitted,

    /// <summary>
    /// Card Dispute Chargeback Timed Out Visa Network Event: details will be under
    /// the `chargeback_timed_out` object.
    /// </summary>
    ChargebackTimedOut,

    /// <summary>
    /// Card Dispute Merchant Pre-Arbitration Decline Submitted Visa Network Event:
    /// details will be under the `merchant_prearbitration_decline_submitted` object.
    /// </summary>
    MerchantPrearbitrationDeclineSubmitted,

    /// <summary>
    /// Card Dispute Merchant Pre-Arbitration Received Visa Network Event: details
    /// will be under the `merchant_prearbitration_received` object.
    /// </summary>
    MerchantPrearbitrationReceived,

    /// <summary>
    /// Card Dispute Merchant Pre-Arbitration Timed Out Visa Network Event: details
    /// will be under the `merchant_prearbitration_timed_out` object.
    /// </summary>
    MerchantPrearbitrationTimedOut,

    /// <summary>
    /// Card Dispute Re-presented Visa Network Event: details will be under the `represented` object.
    /// </summary>
    Represented,

    /// <summary>
    /// Card Dispute Re-presentment Timed Out Visa Network Event: details will be
    /// under the `representment_timed_out` object.
    /// </summary>
    RepresentmentTimedOut,

    /// <summary>
    /// Card Dispute User Pre-Arbitration Accepted Visa Network Event: details will
    /// be under the `user_prearbitration_accepted` object.
    /// </summary>
    UserPrearbitrationAccepted,

    /// <summary>
    /// Card Dispute User Pre-Arbitration Declined Visa Network Event: details will
    /// be under the `user_prearbitration_declined` object.
    /// </summary>
    UserPrearbitrationDeclined,

    /// <summary>
    /// Card Dispute User Pre-Arbitration Submitted Visa Network Event: details will
    /// be under the `user_prearbitration_submitted` object.
    /// </summary>
    UserPrearbitrationSubmitted,

    /// <summary>
    /// Card Dispute User Pre-Arbitration Timed Out Visa Network Event: details will
    /// be under the `user_prearbitration_timed_out` object.
    /// </summary>
    UserPrearbitrationTimedOut,

    /// <summary>
    /// Card Dispute User Withdrawal Submitted Visa Network Event: details will be
    /// under the `user_withdrawal_submitted` object.
    /// </summary>
    UserWithdrawalSubmitted,
}

sealed class NetworkEventCategoryConverter : JsonConverter<NetworkEventCategory>
{
    public override NetworkEventCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "chargeback_accepted" => NetworkEventCategory.ChargebackAccepted,
            "chargeback_submitted" => NetworkEventCategory.ChargebackSubmitted,
            "chargeback_timed_out" => NetworkEventCategory.ChargebackTimedOut,
            "merchant_prearbitration_decline_submitted" =>
                NetworkEventCategory.MerchantPrearbitrationDeclineSubmitted,
            "merchant_prearbitration_received" =>
                NetworkEventCategory.MerchantPrearbitrationReceived,
            "merchant_prearbitration_timed_out" =>
                NetworkEventCategory.MerchantPrearbitrationTimedOut,
            "represented" => NetworkEventCategory.Represented,
            "representment_timed_out" => NetworkEventCategory.RepresentmentTimedOut,
            "user_prearbitration_accepted" => NetworkEventCategory.UserPrearbitrationAccepted,
            "user_prearbitration_declined" => NetworkEventCategory.UserPrearbitrationDeclined,
            "user_prearbitration_submitted" => NetworkEventCategory.UserPrearbitrationSubmitted,
            "user_prearbitration_timed_out" => NetworkEventCategory.UserPrearbitrationTimedOut,
            "user_withdrawal_submitted" => NetworkEventCategory.UserWithdrawalSubmitted,
            _ => (NetworkEventCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NetworkEventCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NetworkEventCategory.ChargebackAccepted => "chargeback_accepted",
                NetworkEventCategory.ChargebackSubmitted => "chargeback_submitted",
                NetworkEventCategory.ChargebackTimedOut => "chargeback_timed_out",
                NetworkEventCategory.MerchantPrearbitrationDeclineSubmitted =>
                    "merchant_prearbitration_decline_submitted",
                NetworkEventCategory.MerchantPrearbitrationReceived =>
                    "merchant_prearbitration_received",
                NetworkEventCategory.MerchantPrearbitrationTimedOut =>
                    "merchant_prearbitration_timed_out",
                NetworkEventCategory.Represented => "represented",
                NetworkEventCategory.RepresentmentTimedOut => "representment_timed_out",
                NetworkEventCategory.UserPrearbitrationAccepted => "user_prearbitration_accepted",
                NetworkEventCategory.UserPrearbitrationDeclined => "user_prearbitration_declined",
                NetworkEventCategory.UserPrearbitrationSubmitted => "user_prearbitration_submitted",
                NetworkEventCategory.UserPrearbitrationTimedOut => "user_prearbitration_timed_out",
                NetworkEventCategory.UserWithdrawalSubmitted => "user_withdrawal_submitted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Card Dispute Chargeback Accepted Visa Network Event object. This field will
/// be present in the JSON response if and only if `category` is equal to `chargeback_accepted`.
/// Contains the details specific to a chargeback accepted Visa Card Dispute Network
/// Event, which represents that a chargeback has been accepted by the merchant.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChargebackAccepted, ChargebackAcceptedFromRaw>))]
public sealed record class ChargebackAccepted : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ChargebackAccepted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackAccepted(ChargebackAccepted chargebackAccepted)
        : base(chargebackAccepted) { }
#pragma warning restore CS8618

    public ChargebackAccepted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackAccepted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackAcceptedFromRaw.FromRawUnchecked"/>
    public static ChargebackAccepted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackAcceptedFromRaw : IFromRawJson<ChargebackAccepted>
{
    /// <inheritdoc/>
    public ChargebackAccepted FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChargebackAccepted.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Dispute Chargeback Submitted Visa Network Event object. This field will
/// be present in the JSON response if and only if `category` is equal to `chargeback_submitted`.
/// Contains the details specific to a chargeback submitted Visa Card Dispute Network
/// Event, which represents that a chargeback has been submitted to the network.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChargebackSubmitted, ChargebackSubmittedFromRaw>))]
public sealed record class ChargebackSubmitted : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ChargebackSubmitted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackSubmitted(ChargebackSubmitted chargebackSubmitted)
        : base(chargebackSubmitted) { }
#pragma warning restore CS8618

    public ChargebackSubmitted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackSubmitted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackSubmittedFromRaw.FromRawUnchecked"/>
    public static ChargebackSubmitted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackSubmittedFromRaw : IFromRawJson<ChargebackSubmitted>
{
    /// <inheritdoc/>
    public ChargebackSubmitted FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChargebackSubmitted.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Dispute Chargeback Timed Out Visa Network Event object. This field will
/// be present in the JSON response if and only if `category` is equal to `chargeback_timed_out`.
/// Contains the details specific to a chargeback timed out Visa Card Dispute Network
/// Event, which represents that the chargeback has timed out in the user's favor.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChargebackTimedOut, ChargebackTimedOutFromRaw>))]
public sealed record class ChargebackTimedOut : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ChargebackTimedOut() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackTimedOut(ChargebackTimedOut chargebackTimedOut)
        : base(chargebackTimedOut) { }
#pragma warning restore CS8618

    public ChargebackTimedOut(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackTimedOut(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackTimedOutFromRaw.FromRawUnchecked"/>
    public static ChargebackTimedOut FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackTimedOutFromRaw : IFromRawJson<ChargebackTimedOut>
{
    /// <inheritdoc/>
    public ChargebackTimedOut FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChargebackTimedOut.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Dispute Merchant Pre-Arbitration Decline Submitted Visa Network Event
/// object. This field will be present in the JSON response if and only if `category`
/// is equal to `merchant_prearbitration_decline_submitted`. Contains the details
/// specific to a merchant prearbitration decline submitted Visa Card Dispute Network
/// Event, which represents that the user has declined the merchant's request for
/// a prearbitration request decision in their favor.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MerchantPrearbitrationDeclineSubmitted,
        MerchantPrearbitrationDeclineSubmittedFromRaw
    >)
)]
public sealed record class MerchantPrearbitrationDeclineSubmitted : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public MerchantPrearbitrationDeclineSubmitted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MerchantPrearbitrationDeclineSubmitted(
        MerchantPrearbitrationDeclineSubmitted merchantPrearbitrationDeclineSubmitted
    )
        : base(merchantPrearbitrationDeclineSubmitted) { }
#pragma warning restore CS8618

    public MerchantPrearbitrationDeclineSubmitted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MerchantPrearbitrationDeclineSubmitted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MerchantPrearbitrationDeclineSubmittedFromRaw.FromRawUnchecked"/>
    public static MerchantPrearbitrationDeclineSubmitted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MerchantPrearbitrationDeclineSubmittedFromRaw
    : IFromRawJson<MerchantPrearbitrationDeclineSubmitted>
{
    /// <inheritdoc/>
    public MerchantPrearbitrationDeclineSubmitted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MerchantPrearbitrationDeclineSubmitted.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Dispute Merchant Pre-Arbitration Received Visa Network Event object. This
/// field will be present in the JSON response if and only if `category` is equal
/// to `merchant_prearbitration_received`. Contains the details specific to a merchant
/// prearbitration received Visa Card Dispute Network Event, which represents that
/// the merchant has issued a prearbitration request in the user's favor.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MerchantPrearbitrationReceived,
        MerchantPrearbitrationReceivedFromRaw
    >)
)]
public sealed record class MerchantPrearbitrationReceived : JsonModel
{
    /// <summary>
    /// Cardholder no longer disputes details. Present if and only if `reason` is `cardholder_no_longer_disputes`.
    /// </summary>
    public required CardholderNoLongerDisputes? CardholderNoLongerDisputes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardholderNoLongerDisputes>(
                "cardholder_no_longer_disputes"
            );
        }
        init { this._rawData.Set("cardholder_no_longer_disputes", value); }
    }

    /// <summary>
    /// Compelling evidence details. Present if and only if `reason` is `compelling_evidence`.
    /// </summary>
    public required CompellingEvidence? CompellingEvidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CompellingEvidence>("compelling_evidence");
        }
        init { this._rawData.Set("compelling_evidence", value); }
    }

    /// <summary>
    /// Credit or reversal processed details. Present if and only if `reason` is `credit_or_reversal_processed`.
    /// </summary>
    public required CreditOrReversalProcessed? CreditOrReversalProcessed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreditOrReversalProcessed>(
                "credit_or_reversal_processed"
            );
        }
        init { this._rawData.Set("credit_or_reversal_processed", value); }
    }

    /// <summary>
    /// Delayed charge transaction details. Present if and only if `reason` is `delayed_charge_transaction`.
    /// </summary>
    public required DelayedChargeTransaction? DelayedChargeTransaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DelayedChargeTransaction>(
                "delayed_charge_transaction"
            );
        }
        init { this._rawData.Set("delayed_charge_transaction", value); }
    }

    /// <summary>
    /// Evidence of imprint details. Present if and only if `reason` is `evidence_of_imprint`.
    /// </summary>
    public required EvidenceOfImprint? EvidenceOfImprint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EvidenceOfImprint>("evidence_of_imprint");
        }
        init { this._rawData.Set("evidence_of_imprint", value); }
    }

    /// <summary>
    /// Invalid dispute details. Present if and only if `reason` is `invalid_dispute`.
    /// </summary>
    public required InvalidDispute? InvalidDispute
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InvalidDispute>("invalid_dispute");
        }
        init { this._rawData.Set("invalid_dispute", value); }
    }

    /// <summary>
    /// Non-fiat currency or non-fungible token received details. Present if and
    /// only if `reason` is `non_fiat_currency_or_non_fungible_token_received`.
    /// </summary>
    public required NonFiatCurrencyOrNonFungibleTokenReceived? NonFiatCurrencyOrNonFungibleTokenReceived
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NonFiatCurrencyOrNonFungibleTokenReceived>(
                "non_fiat_currency_or_non_fungible_token_received"
            );
        }
        init { this._rawData.Set("non_fiat_currency_or_non_fungible_token_received", value); }
    }

    /// <summary>
    /// Prior undisputed non-fraud transactions details. Present if and only if `reason`
    /// is `prior_undisputed_non_fraud_transactions`.
    /// </summary>
    public required PriorUndisputedNonFraudTransactions? PriorUndisputedNonFraudTransactions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PriorUndisputedNonFraudTransactions>(
                "prior_undisputed_non_fraud_transactions"
            );
        }
        init { this._rawData.Set("prior_undisputed_non_fraud_transactions", value); }
    }

    /// <summary>
    /// The reason the merchant re-presented the dispute.
    /// </summary>
    public required ApiEnum<string, MerchantPrearbitrationReceivedReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MerchantPrearbitrationReceivedReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CardholderNoLongerDisputes?.Validate();
        this.CompellingEvidence?.Validate();
        this.CreditOrReversalProcessed?.Validate();
        this.DelayedChargeTransaction?.Validate();
        this.EvidenceOfImprint?.Validate();
        this.InvalidDispute?.Validate();
        this.NonFiatCurrencyOrNonFungibleTokenReceived?.Validate();
        this.PriorUndisputedNonFraudTransactions?.Validate();
        this.Reason.Validate();
    }

    public MerchantPrearbitrationReceived() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MerchantPrearbitrationReceived(
        MerchantPrearbitrationReceived merchantPrearbitrationReceived
    )
        : base(merchantPrearbitrationReceived) { }
#pragma warning restore CS8618

    public MerchantPrearbitrationReceived(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MerchantPrearbitrationReceived(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MerchantPrearbitrationReceivedFromRaw.FromRawUnchecked"/>
    public static MerchantPrearbitrationReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MerchantPrearbitrationReceivedFromRaw : IFromRawJson<MerchantPrearbitrationReceived>
{
    /// <inheritdoc/>
    public MerchantPrearbitrationReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MerchantPrearbitrationReceived.FromRawUnchecked(rawData);
}

/// <summary>
/// Cardholder no longer disputes details. Present if and only if `reason` is `cardholder_no_longer_disputes`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CardholderNoLongerDisputes, CardholderNoLongerDisputesFromRaw>)
)]
public sealed record class CardholderNoLongerDisputes : JsonModel
{
    /// <summary>
    /// Explanation for why the merchant believes the cardholder no longer disputes
    /// the transaction.
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Explanation;
    }

    public CardholderNoLongerDisputes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardholderNoLongerDisputes(CardholderNoLongerDisputes cardholderNoLongerDisputes)
        : base(cardholderNoLongerDisputes) { }
#pragma warning restore CS8618

    public CardholderNoLongerDisputes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardholderNoLongerDisputes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardholderNoLongerDisputesFromRaw.FromRawUnchecked"/>
    public static CardholderNoLongerDisputes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardholderNoLongerDisputes(string? explanation)
        : this()
    {
        this.Explanation = explanation;
    }
}

class CardholderNoLongerDisputesFromRaw : IFromRawJson<CardholderNoLongerDisputes>
{
    /// <inheritdoc/>
    public CardholderNoLongerDisputes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardholderNoLongerDisputes.FromRawUnchecked(rawData);
}

/// <summary>
/// Compelling evidence details. Present if and only if `reason` is `compelling_evidence`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CompellingEvidence, CompellingEvidenceFromRaw>))]
public sealed record class CompellingEvidence : JsonModel
{
    /// <summary>
    /// The category of compelling evidence provided by the merchant.
    /// </summary>
    public required ApiEnum<string, CompellingEvidenceCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CompellingEvidenceCategory>>(
                "category"
            );
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Explanation of the compelling evidence provided by the merchant.
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        _ = this.Explanation;
    }

    public CompellingEvidence() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CompellingEvidence(CompellingEvidence compellingEvidence)
        : base(compellingEvidence) { }
#pragma warning restore CS8618

    public CompellingEvidence(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompellingEvidence(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompellingEvidenceFromRaw.FromRawUnchecked"/>
    public static CompellingEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompellingEvidenceFromRaw : IFromRawJson<CompellingEvidence>
{
    /// <inheritdoc/>
    public CompellingEvidence FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CompellingEvidence.FromRawUnchecked(rawData);
}

/// <summary>
/// The category of compelling evidence provided by the merchant.
/// </summary>
[JsonConverter(typeof(CompellingEvidenceCategoryConverter))]
public enum CompellingEvidenceCategory
{
    /// <summary>
    /// Authorized signer known by the cardholder.
    /// </summary>
    AuthorizedSigner,

    /// <summary>
    /// Proof of delivery.
    /// </summary>
    Delivery,

    /// <summary>
    /// Proof of delivery to cardholder at place of employment.
    /// </summary>
    DeliveryAtPlaceOfEmployment,

    /// <summary>
    /// Proof of digital goods download.
    /// </summary>
    DigitalGoodsDownload,

    /// <summary>
    /// Dynamic Currency Conversion actively chosen by cardholder.
    /// </summary>
    DynamicCurrencyConversionActivelyChosen,

    /// <summary>
    /// Flight manifest with corresponding purchase itinerary record.
    /// </summary>
    FlightManifestAndPurchaseItinerary,

    /// <summary>
    /// Signer is member of cardholder's household.
    /// </summary>
    HouseholdMemberSigner,

    /// <summary>
    /// Legitimate spend across multiple payment types for same merchandise.
    /// </summary>
    LegitimateSpendAcrossPaymentTypesForSameMerchandise,

    /// <summary>
    /// Documentation to prove the cardholder is in possession of and/or using the merchandise.
    /// </summary>
    MerchandiseUse,

    /// <summary>
    /// Passenger transport: proof ticket was received, scanned at gate or other transaction
    /// related to original (for example, frequent flyer miles.)
    /// </summary>
    PassengerTransportTicketUse,

    /// <summary>
    /// Recurring transaction with binding contract or previous undisputed recurring
    /// transactions and proof the cardholder is using the merchandise or service.
    /// </summary>
    RecurringTransactionWithBindingContractOrPreviousUndisputedTransaction,

    /// <summary>
    /// Signed delivery form, or copy of/details of identification from cardholder
    /// as proof goods were picked up at merchant location.
    /// </summary>
    SignedDeliveryOrPickupForm,

    /// <summary>
    /// Signed Mail Order/Phone Order form.
    /// </summary>
    SignedMailOrderPhoneOrderForm,

    /// <summary>
    /// Travel &amp; Expense: loyalty transactions related to purchase.
    /// </summary>
    TravelAndExpenseLoyaltyTransaction,

    /// <summary>
    /// Travel &amp; Expense: subsequent purchases made throughout service period.
    /// </summary>
    TravelAndExpenseSubsequentPurchase,
}

sealed class CompellingEvidenceCategoryConverter : JsonConverter<CompellingEvidenceCategory>
{
    public override CompellingEvidenceCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "authorized_signer" => CompellingEvidenceCategory.AuthorizedSigner,
            "delivery" => CompellingEvidenceCategory.Delivery,
            "delivery_at_place_of_employment" =>
                CompellingEvidenceCategory.DeliveryAtPlaceOfEmployment,
            "digital_goods_download" => CompellingEvidenceCategory.DigitalGoodsDownload,
            "dynamic_currency_conversion_actively_chosen" =>
                CompellingEvidenceCategory.DynamicCurrencyConversionActivelyChosen,
            "flight_manifest_and_purchase_itinerary" =>
                CompellingEvidenceCategory.FlightManifestAndPurchaseItinerary,
            "household_member_signer" => CompellingEvidenceCategory.HouseholdMemberSigner,
            "legitimate_spend_across_payment_types_for_same_merchandise" =>
                CompellingEvidenceCategory.LegitimateSpendAcrossPaymentTypesForSameMerchandise,
            "merchandise_use" => CompellingEvidenceCategory.MerchandiseUse,
            "passenger_transport_ticket_use" =>
                CompellingEvidenceCategory.PassengerTransportTicketUse,
            "recurring_transaction_with_binding_contract_or_previous_undisputed_transaction" =>
                CompellingEvidenceCategory.RecurringTransactionWithBindingContractOrPreviousUndisputedTransaction,
            "signed_delivery_or_pickup_form" =>
                CompellingEvidenceCategory.SignedDeliveryOrPickupForm,
            "signed_mail_order_phone_order_form" =>
                CompellingEvidenceCategory.SignedMailOrderPhoneOrderForm,
            "travel_and_expense_loyalty_transaction" =>
                CompellingEvidenceCategory.TravelAndExpenseLoyaltyTransaction,
            "travel_and_expense_subsequent_purchase" =>
                CompellingEvidenceCategory.TravelAndExpenseSubsequentPurchase,
            _ => (CompellingEvidenceCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CompellingEvidenceCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CompellingEvidenceCategory.AuthorizedSigner => "authorized_signer",
                CompellingEvidenceCategory.Delivery => "delivery",
                CompellingEvidenceCategory.DeliveryAtPlaceOfEmployment =>
                    "delivery_at_place_of_employment",
                CompellingEvidenceCategory.DigitalGoodsDownload => "digital_goods_download",
                CompellingEvidenceCategory.DynamicCurrencyConversionActivelyChosen =>
                    "dynamic_currency_conversion_actively_chosen",
                CompellingEvidenceCategory.FlightManifestAndPurchaseItinerary =>
                    "flight_manifest_and_purchase_itinerary",
                CompellingEvidenceCategory.HouseholdMemberSigner => "household_member_signer",
                CompellingEvidenceCategory.LegitimateSpendAcrossPaymentTypesForSameMerchandise =>
                    "legitimate_spend_across_payment_types_for_same_merchandise",
                CompellingEvidenceCategory.MerchandiseUse => "merchandise_use",
                CompellingEvidenceCategory.PassengerTransportTicketUse =>
                    "passenger_transport_ticket_use",
                CompellingEvidenceCategory.RecurringTransactionWithBindingContractOrPreviousUndisputedTransaction =>
                    "recurring_transaction_with_binding_contract_or_previous_undisputed_transaction",
                CompellingEvidenceCategory.SignedDeliveryOrPickupForm =>
                    "signed_delivery_or_pickup_form",
                CompellingEvidenceCategory.SignedMailOrderPhoneOrderForm =>
                    "signed_mail_order_phone_order_form",
                CompellingEvidenceCategory.TravelAndExpenseLoyaltyTransaction =>
                    "travel_and_expense_loyalty_transaction",
                CompellingEvidenceCategory.TravelAndExpenseSubsequentPurchase =>
                    "travel_and_expense_subsequent_purchase",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Credit or reversal processed details. Present if and only if `reason` is `credit_or_reversal_processed`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CreditOrReversalProcessed, CreditOrReversalProcessedFromRaw>)
)]
public sealed record class CreditOrReversalProcessed : JsonModel
{
    /// <summary>
    /// The amount of the credit or reversal in the minor unit of its currency. For
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the credit
    /// or reversal's currency.
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
    /// Explanation for why the merchant believes the credit or reversal was processed.
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <summary>
    /// The date the credit or reversal was processed.
    /// </summary>
    public required string ProcessedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("processed_at");
        }
        init { this._rawData.Set("processed_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
        _ = this.Explanation;
        _ = this.ProcessedAt;
    }

    public CreditOrReversalProcessed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditOrReversalProcessed(CreditOrReversalProcessed creditOrReversalProcessed)
        : base(creditOrReversalProcessed) { }
#pragma warning restore CS8618

    public CreditOrReversalProcessed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditOrReversalProcessed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditOrReversalProcessedFromRaw.FromRawUnchecked"/>
    public static CreditOrReversalProcessed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditOrReversalProcessedFromRaw : IFromRawJson<CreditOrReversalProcessed>
{
    /// <inheritdoc/>
    public CreditOrReversalProcessed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditOrReversalProcessed.FromRawUnchecked(rawData);
}

/// <summary>
/// Delayed charge transaction details. Present if and only if `reason` is `delayed_charge_transaction`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DelayedChargeTransaction, DelayedChargeTransactionFromRaw>)
)]
public sealed record class DelayedChargeTransaction : JsonModel
{
    /// <summary>
    /// Additional details about the delayed charge transaction.
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Explanation;
    }

    public DelayedChargeTransaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DelayedChargeTransaction(DelayedChargeTransaction delayedChargeTransaction)
        : base(delayedChargeTransaction) { }
#pragma warning restore CS8618

    public DelayedChargeTransaction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DelayedChargeTransaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DelayedChargeTransactionFromRaw.FromRawUnchecked"/>
    public static DelayedChargeTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DelayedChargeTransaction(string? explanation)
        : this()
    {
        this.Explanation = explanation;
    }
}

class DelayedChargeTransactionFromRaw : IFromRawJson<DelayedChargeTransaction>
{
    /// <inheritdoc/>
    public DelayedChargeTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DelayedChargeTransaction.FromRawUnchecked(rawData);
}

/// <summary>
/// Evidence of imprint details. Present if and only if `reason` is `evidence_of_imprint`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EvidenceOfImprint, EvidenceOfImprintFromRaw>))]
public sealed record class EvidenceOfImprint : JsonModel
{
    /// <summary>
    /// Explanation of the evidence of imprint.
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Explanation;
    }

    public EvidenceOfImprint() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EvidenceOfImprint(EvidenceOfImprint evidenceOfImprint)
        : base(evidenceOfImprint) { }
#pragma warning restore CS8618

    public EvidenceOfImprint(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EvidenceOfImprint(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EvidenceOfImprintFromRaw.FromRawUnchecked"/>
    public static EvidenceOfImprint FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EvidenceOfImprint(string? explanation)
        : this()
    {
        this.Explanation = explanation;
    }
}

class EvidenceOfImprintFromRaw : IFromRawJson<EvidenceOfImprint>
{
    /// <inheritdoc/>
    public EvidenceOfImprint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EvidenceOfImprint.FromRawUnchecked(rawData);
}

/// <summary>
/// Invalid dispute details. Present if and only if `reason` is `invalid_dispute`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InvalidDispute, InvalidDisputeFromRaw>))]
public sealed record class InvalidDispute : JsonModel
{
    /// <summary>
    /// Explanation for why the dispute is considered invalid by the merchant.
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <summary>
    /// The reason a merchant considers the dispute invalid.
    /// </summary>
    public required ApiEnum<string, InvalidDisputeReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InvalidDisputeReason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Explanation;
        this.Reason.Validate();
    }

    public InvalidDispute() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvalidDispute(InvalidDispute invalidDispute)
        : base(invalidDispute) { }
#pragma warning restore CS8618

    public InvalidDispute(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvalidDispute(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvalidDisputeFromRaw.FromRawUnchecked"/>
    public static InvalidDispute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvalidDisputeFromRaw : IFromRawJson<InvalidDispute>
{
    /// <inheritdoc/>
    public InvalidDispute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InvalidDispute.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason a merchant considers the dispute invalid.
/// </summary>
[JsonConverter(typeof(InvalidDisputeReasonConverter))]
public enum InvalidDisputeReason
{
    /// <summary>
    /// Other.
    /// </summary>
    Other,

    /// <summary>
    /// Special authorization procedures followed.
    /// </summary>
    SpecialAuthorizationProceduresFollowed,
}

sealed class InvalidDisputeReasonConverter : JsonConverter<InvalidDisputeReason>
{
    public override InvalidDisputeReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "other" => InvalidDisputeReason.Other,
            "special_authorization_procedures_followed" =>
                InvalidDisputeReason.SpecialAuthorizationProceduresFollowed,
            _ => (InvalidDisputeReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvalidDisputeReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvalidDisputeReason.Other => "other",
                InvalidDisputeReason.SpecialAuthorizationProceduresFollowed =>
                    "special_authorization_procedures_followed",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Non-fiat currency or non-fungible token received details. Present if and only
/// if `reason` is `non_fiat_currency_or_non_fungible_token_received`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        NonFiatCurrencyOrNonFungibleTokenReceived,
        NonFiatCurrencyOrNonFungibleTokenReceivedFromRaw
    >)
)]
public sealed record class NonFiatCurrencyOrNonFungibleTokenReceived : JsonModel
{
    /// <summary>
    /// Blockchain transaction hash.
    /// </summary>
    public required string BlockchainTransactionHash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("blockchain_transaction_hash");
        }
        init { this._rawData.Set("blockchain_transaction_hash", value); }
    }

    /// <summary>
    /// Destination wallet address.
    /// </summary>
    public required string DestinationWalletAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("destination_wallet_address");
        }
        init { this._rawData.Set("destination_wallet_address", value); }
    }

    /// <summary>
    /// Prior approved transactions.
    /// </summary>
    public required string? PriorApprovedTransactions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prior_approved_transactions");
        }
        init { this._rawData.Set("prior_approved_transactions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BlockchainTransactionHash;
        _ = this.DestinationWalletAddress;
        _ = this.PriorApprovedTransactions;
    }

    public NonFiatCurrencyOrNonFungibleTokenReceived() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NonFiatCurrencyOrNonFungibleTokenReceived(
        NonFiatCurrencyOrNonFungibleTokenReceived nonFiatCurrencyOrNonFungibleTokenReceived
    )
        : base(nonFiatCurrencyOrNonFungibleTokenReceived) { }
#pragma warning restore CS8618

    public NonFiatCurrencyOrNonFungibleTokenReceived(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NonFiatCurrencyOrNonFungibleTokenReceived(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NonFiatCurrencyOrNonFungibleTokenReceivedFromRaw.FromRawUnchecked"/>
    public static NonFiatCurrencyOrNonFungibleTokenReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NonFiatCurrencyOrNonFungibleTokenReceivedFromRaw
    : IFromRawJson<NonFiatCurrencyOrNonFungibleTokenReceived>
{
    /// <inheritdoc/>
    public NonFiatCurrencyOrNonFungibleTokenReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NonFiatCurrencyOrNonFungibleTokenReceived.FromRawUnchecked(rawData);
}

/// <summary>
/// Prior undisputed non-fraud transactions details. Present if and only if `reason`
/// is `prior_undisputed_non_fraud_transactions`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PriorUndisputedNonFraudTransactions,
        PriorUndisputedNonFraudTransactionsFromRaw
    >)
)]
public sealed record class PriorUndisputedNonFraudTransactions : JsonModel
{
    /// <summary>
    /// Explanation of the prior undisputed non-fraud transactions provided by the merchant.
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Explanation;
    }

    public PriorUndisputedNonFraudTransactions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PriorUndisputedNonFraudTransactions(
        PriorUndisputedNonFraudTransactions priorUndisputedNonFraudTransactions
    )
        : base(priorUndisputedNonFraudTransactions) { }
#pragma warning restore CS8618

    public PriorUndisputedNonFraudTransactions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriorUndisputedNonFraudTransactions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriorUndisputedNonFraudTransactionsFromRaw.FromRawUnchecked"/>
    public static PriorUndisputedNonFraudTransactions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PriorUndisputedNonFraudTransactions(string? explanation)
        : this()
    {
        this.Explanation = explanation;
    }
}

class PriorUndisputedNonFraudTransactionsFromRaw : IFromRawJson<PriorUndisputedNonFraudTransactions>
{
    /// <inheritdoc/>
    public PriorUndisputedNonFraudTransactions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriorUndisputedNonFraudTransactions.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason the merchant re-presented the dispute.
/// </summary>
[JsonConverter(typeof(MerchantPrearbitrationReceivedReasonConverter))]
public enum MerchantPrearbitrationReceivedReason
{
    /// <summary>
    /// Cardholder no longer disputes the transaction.
    /// </summary>
    CardholderNoLongerDisputes,

    /// <summary>
    /// Compelling evidence.
    /// </summary>
    CompellingEvidence,

    /// <summary>
    /// Credit or reversal was processed.
    /// </summary>
    CreditOrReversalProcessed,

    /// <summary>
    /// Delayed charge transaction.
    /// </summary>
    DelayedChargeTransaction,

    /// <summary>
    /// Evidence of imprint.
    /// </summary>
    EvidenceOfImprint,

    /// <summary>
    /// Invalid dispute.
    /// </summary>
    InvalidDispute,

    /// <summary>
    /// Non-fiat currency or non-fungible token was received by the cardholder.
    /// </summary>
    NonFiatCurrencyOrNonFungibleTokenReceived,

    /// <summary>
    /// Prior undisputed non-fraud transactions.
    /// </summary>
    PriorUndisputedNonFraudTransactions,
}

sealed class MerchantPrearbitrationReceivedReasonConverter
    : JsonConverter<MerchantPrearbitrationReceivedReason>
{
    public override MerchantPrearbitrationReceivedReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cardholder_no_longer_disputes" =>
                MerchantPrearbitrationReceivedReason.CardholderNoLongerDisputes,
            "compelling_evidence" => MerchantPrearbitrationReceivedReason.CompellingEvidence,
            "credit_or_reversal_processed" =>
                MerchantPrearbitrationReceivedReason.CreditOrReversalProcessed,
            "delayed_charge_transaction" =>
                MerchantPrearbitrationReceivedReason.DelayedChargeTransaction,
            "evidence_of_imprint" => MerchantPrearbitrationReceivedReason.EvidenceOfImprint,
            "invalid_dispute" => MerchantPrearbitrationReceivedReason.InvalidDispute,
            "non_fiat_currency_or_non_fungible_token_received" =>
                MerchantPrearbitrationReceivedReason.NonFiatCurrencyOrNonFungibleTokenReceived,
            "prior_undisputed_non_fraud_transactions" =>
                MerchantPrearbitrationReceivedReason.PriorUndisputedNonFraudTransactions,
            _ => (MerchantPrearbitrationReceivedReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MerchantPrearbitrationReceivedReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MerchantPrearbitrationReceivedReason.CardholderNoLongerDisputes =>
                    "cardholder_no_longer_disputes",
                MerchantPrearbitrationReceivedReason.CompellingEvidence => "compelling_evidence",
                MerchantPrearbitrationReceivedReason.CreditOrReversalProcessed =>
                    "credit_or_reversal_processed",
                MerchantPrearbitrationReceivedReason.DelayedChargeTransaction =>
                    "delayed_charge_transaction",
                MerchantPrearbitrationReceivedReason.EvidenceOfImprint => "evidence_of_imprint",
                MerchantPrearbitrationReceivedReason.InvalidDispute => "invalid_dispute",
                MerchantPrearbitrationReceivedReason.NonFiatCurrencyOrNonFungibleTokenReceived =>
                    "non_fiat_currency_or_non_fungible_token_received",
                MerchantPrearbitrationReceivedReason.PriorUndisputedNonFraudTransactions =>
                    "prior_undisputed_non_fraud_transactions",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Card Dispute Merchant Pre-Arbitration Timed Out Visa Network Event object. This
/// field will be present in the JSON response if and only if `category` is equal
/// to `merchant_prearbitration_timed_out`. Contains the details specific to a merchant
/// prearbitration timed out Visa Card Dispute Network Event, which represents that
/// the user has timed out responding to the merchant's prearbitration request.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MerchantPrearbitrationTimedOut,
        MerchantPrearbitrationTimedOutFromRaw
    >)
)]
public sealed record class MerchantPrearbitrationTimedOut : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public MerchantPrearbitrationTimedOut() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MerchantPrearbitrationTimedOut(
        MerchantPrearbitrationTimedOut merchantPrearbitrationTimedOut
    )
        : base(merchantPrearbitrationTimedOut) { }
#pragma warning restore CS8618

    public MerchantPrearbitrationTimedOut(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MerchantPrearbitrationTimedOut(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MerchantPrearbitrationTimedOutFromRaw.FromRawUnchecked"/>
    public static MerchantPrearbitrationTimedOut FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MerchantPrearbitrationTimedOutFromRaw : IFromRawJson<MerchantPrearbitrationTimedOut>
{
    /// <inheritdoc/>
    public MerchantPrearbitrationTimedOut FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MerchantPrearbitrationTimedOut.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Dispute Re-presented Visa Network Event object. This field will be present
/// in the JSON response if and only if `category` is equal to `represented`. Contains
/// the details specific to a re-presented Visa Card Dispute Network Event, which
/// represents that the merchant has declined the user's chargeback and has re-presented
/// the payment.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Represented, RepresentedFromRaw>))]
public sealed record class Represented : JsonModel
{
    /// <summary>
    /// Cardholder no longer disputes details. Present if and only if `reason` is `cardholder_no_longer_disputes`.
    /// </summary>
    public required RepresentedCardholderNoLongerDisputes? CardholderNoLongerDisputes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RepresentedCardholderNoLongerDisputes>(
                "cardholder_no_longer_disputes"
            );
        }
        init { this._rawData.Set("cardholder_no_longer_disputes", value); }
    }

    /// <summary>
    /// Credit or reversal processed details. Present if and only if `reason` is `credit_or_reversal_processed`.
    /// </summary>
    public required RepresentedCreditOrReversalProcessed? CreditOrReversalProcessed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RepresentedCreditOrReversalProcessed>(
                "credit_or_reversal_processed"
            );
        }
        init { this._rawData.Set("credit_or_reversal_processed", value); }
    }

    /// <summary>
    /// Invalid dispute details. Present if and only if `reason` is `invalid_dispute`.
    /// </summary>
    public required RepresentedInvalidDispute? InvalidDispute
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RepresentedInvalidDispute>("invalid_dispute");
        }
        init { this._rawData.Set("invalid_dispute", value); }
    }

    /// <summary>
    /// Non-fiat currency or non-fungible token as described details. Present if
    /// and only if `reason` is `non_fiat_currency_or_non_fungible_token_as_described`.
    /// </summary>
    public required NonFiatCurrencyOrNonFungibleTokenAsDescribed? NonFiatCurrencyOrNonFungibleTokenAsDescribed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NonFiatCurrencyOrNonFungibleTokenAsDescribed>(
                "non_fiat_currency_or_non_fungible_token_as_described"
            );
        }
        init { this._rawData.Set("non_fiat_currency_or_non_fungible_token_as_described", value); }
    }

    /// <summary>
    /// Non-fiat currency or non-fungible token received details. Present if and
    /// only if `reason` is `non_fiat_currency_or_non_fungible_token_received`.
    /// </summary>
    public required RepresentedNonFiatCurrencyOrNonFungibleTokenReceived? NonFiatCurrencyOrNonFungibleTokenReceived
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RepresentedNonFiatCurrencyOrNonFungibleTokenReceived>(
                "non_fiat_currency_or_non_fungible_token_received"
            );
        }
        init { this._rawData.Set("non_fiat_currency_or_non_fungible_token_received", value); }
    }

    /// <summary>
    /// Proof of cash disbursement details. Present if and only if `reason` is `proof_of_cash_disbursement`.
    /// </summary>
    public required ProofOfCashDisbursement? ProofOfCashDisbursement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProofOfCashDisbursement>(
                "proof_of_cash_disbursement"
            );
        }
        init { this._rawData.Set("proof_of_cash_disbursement", value); }
    }

    /// <summary>
    /// The reason the merchant re-presented the dispute.
    /// </summary>
    public required ApiEnum<string, RepresentedReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RepresentedReason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Reversal issued by merchant details. Present if and only if `reason` is `reversal_issued`.
    /// </summary>
    public required ReversalIssued? ReversalIssued
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReversalIssued>("reversal_issued");
        }
        init { this._rawData.Set("reversal_issued", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CardholderNoLongerDisputes?.Validate();
        this.CreditOrReversalProcessed?.Validate();
        this.InvalidDispute?.Validate();
        this.NonFiatCurrencyOrNonFungibleTokenAsDescribed?.Validate();
        this.NonFiatCurrencyOrNonFungibleTokenReceived?.Validate();
        this.ProofOfCashDisbursement?.Validate();
        this.Reason.Validate();
        this.ReversalIssued?.Validate();
    }

    public Represented() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Represented(Represented represented)
        : base(represented) { }
#pragma warning restore CS8618

    public Represented(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Represented(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RepresentedFromRaw.FromRawUnchecked"/>
    public static Represented FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RepresentedFromRaw : IFromRawJson<Represented>
{
    /// <inheritdoc/>
    public Represented FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Represented.FromRawUnchecked(rawData);
}

/// <summary>
/// Cardholder no longer disputes details. Present if and only if `reason` is `cardholder_no_longer_disputes`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RepresentedCardholderNoLongerDisputes,
        RepresentedCardholderNoLongerDisputesFromRaw
    >)
)]
public sealed record class RepresentedCardholderNoLongerDisputes : JsonModel
{
    /// <summary>
    /// Explanation for why the merchant believes the cardholder no longer disputes
    /// the transaction.
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Explanation;
    }

    public RepresentedCardholderNoLongerDisputes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RepresentedCardholderNoLongerDisputes(
        RepresentedCardholderNoLongerDisputes representedCardholderNoLongerDisputes
    )
        : base(representedCardholderNoLongerDisputes) { }
#pragma warning restore CS8618

    public RepresentedCardholderNoLongerDisputes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RepresentedCardholderNoLongerDisputes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RepresentedCardholderNoLongerDisputesFromRaw.FromRawUnchecked"/>
    public static RepresentedCardholderNoLongerDisputes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RepresentedCardholderNoLongerDisputes(string? explanation)
        : this()
    {
        this.Explanation = explanation;
    }
}

class RepresentedCardholderNoLongerDisputesFromRaw
    : IFromRawJson<RepresentedCardholderNoLongerDisputes>
{
    /// <inheritdoc/>
    public RepresentedCardholderNoLongerDisputes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RepresentedCardholderNoLongerDisputes.FromRawUnchecked(rawData);
}

/// <summary>
/// Credit or reversal processed details. Present if and only if `reason` is `credit_or_reversal_processed`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RepresentedCreditOrReversalProcessed,
        RepresentedCreditOrReversalProcessedFromRaw
    >)
)]
public sealed record class RepresentedCreditOrReversalProcessed : JsonModel
{
    /// <summary>
    /// The amount of the credit or reversal in the minor unit of its currency. For
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the credit
    /// or reversal's currency.
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
    /// Explanation for why the merchant believes the credit or reversal was processed.
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <summary>
    /// The date the credit or reversal was processed.
    /// </summary>
    public required string ProcessedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("processed_at");
        }
        init { this._rawData.Set("processed_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
        _ = this.Explanation;
        _ = this.ProcessedAt;
    }

    public RepresentedCreditOrReversalProcessed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RepresentedCreditOrReversalProcessed(
        RepresentedCreditOrReversalProcessed representedCreditOrReversalProcessed
    )
        : base(representedCreditOrReversalProcessed) { }
#pragma warning restore CS8618

    public RepresentedCreditOrReversalProcessed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RepresentedCreditOrReversalProcessed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RepresentedCreditOrReversalProcessedFromRaw.FromRawUnchecked"/>
    public static RepresentedCreditOrReversalProcessed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RepresentedCreditOrReversalProcessedFromRaw
    : IFromRawJson<RepresentedCreditOrReversalProcessed>
{
    /// <inheritdoc/>
    public RepresentedCreditOrReversalProcessed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RepresentedCreditOrReversalProcessed.FromRawUnchecked(rawData);
}

/// <summary>
/// Invalid dispute details. Present if and only if `reason` is `invalid_dispute`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RepresentedInvalidDispute, RepresentedInvalidDisputeFromRaw>)
)]
public sealed record class RepresentedInvalidDispute : JsonModel
{
    /// <summary>
    /// Explanation for why the dispute is considered invalid by the merchant.
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <summary>
    /// The reason a merchant considers the dispute invalid.
    /// </summary>
    public required ApiEnum<string, RepresentedInvalidDisputeReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RepresentedInvalidDisputeReason>>(
                "reason"
            );
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Explanation;
        this.Reason.Validate();
    }

    public RepresentedInvalidDispute() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RepresentedInvalidDispute(RepresentedInvalidDispute representedInvalidDispute)
        : base(representedInvalidDispute) { }
#pragma warning restore CS8618

    public RepresentedInvalidDispute(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RepresentedInvalidDispute(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RepresentedInvalidDisputeFromRaw.FromRawUnchecked"/>
    public static RepresentedInvalidDispute FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RepresentedInvalidDisputeFromRaw : IFromRawJson<RepresentedInvalidDispute>
{
    /// <inheritdoc/>
    public RepresentedInvalidDispute FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RepresentedInvalidDispute.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason a merchant considers the dispute invalid.
/// </summary>
[JsonConverter(typeof(RepresentedInvalidDisputeReasonConverter))]
public enum RepresentedInvalidDisputeReason
{
    /// <summary>
    /// Automatic Teller Machine (ATM) transaction proof provided.
    /// </summary>
    AutomaticTellerMachineTransactionProofProvided,

    /// <summary>
    /// Balance of partial prepayment not paid.
    /// </summary>
    BalanceOfPartialPrepaymentNotPaid,

    /// <summary>
    /// Cardholder canceled before expected receipt date of the merchandise.
    /// </summary>
    CardholderCanceledBeforeExpectedMerchandiseReceiptDate,

    /// <summary>
    /// Cardholder canceled before expected receipt date of the services.
    /// </summary>
    CardholderCanceledBeforeExpectedServicesReceiptDate,

    /// <summary>
    /// Cardholder canceled on a different date than claimed.
    /// </summary>
    CardholderCanceledDifferentDate,

    /// <summary>
    /// Cardholder received  did not cancel according to policy.
    /// </summary>
    CardholderDidNotCancelAccordingToPolicy,

    /// <summary>
    /// Cardholder received the merchandise.
    /// </summary>
    CardholderReceivedMerchandise,

    /// <summary>
    /// Country code is correct.
    /// </summary>
    CountryCodeCorrect,

    /// <summary>
    /// Credit was processed correctly.
    /// </summary>
    CreditProcessedCorrectly,

    /// <summary>
    /// Currency is correct.
    /// </summary>
    CurrencyCorrect,

    /// <summary>
    /// Dispute is for quality.
    /// </summary>
    DisputeIsForQuality,

    /// <summary>
    /// Dispute is for Visa Cash Back transaction portion.
    /// </summary>
    DisputeIsForVisaCashBackTransactionPortion,

    /// <summary>
    /// Disputed amount is Value Added Tax (VAT).
    /// </summary>
    DisputedAmountIsValueAddedTax,

    /// <summary>
    /// Disputed amount is Value Added Tax (VAT) but no credit receipt was provided
    /// by the cardholder.
    /// </summary>
    DisputedAmountIsValueAddedTaxNoCreditReceiptProvided,

    /// <summary>
    /// Limited return or cancellation policy was properly disclosed.
    /// </summary>
    LimitedReturnOrCancellationPolicyProperlyDisclosed,

    /// <summary>
    /// Merchandise held at cardholder customs agency.
    /// </summary>
    MerchandiseHeldAtCardholderCustomsAgency,

    /// <summary>
    /// Merchandise matches the merchant's description.
    /// </summary>
    MerchandiseMatchesDescription,

    /// <summary>
    /// Merchandise is not counterfeit.
    /// </summary>
    MerchandiseNotCounterfeit,

    /// <summary>
    /// Merchandise is not damaged.
    /// </summary>
    MerchandiseNotDamaged,

    /// <summary>
    /// Merchandise is not defective.
    /// </summary>
    MerchandiseNotDefective,

    /// <summary>
    /// Merchandise was provided prior to the cancellation date.
    /// </summary>
    MerchandiseProvidedPriorToCancellationDate,

    /// <summary>
    /// Merchandise quality matches the merchant's description.
    /// </summary>
    MerchandiseQualityMatchesDescription,

    /// <summary>
    /// Merchandise was not attempted returned to the merchant.
    /// </summary>
    MerchandiseReturnNotAttempted,

    /// <summary>
    /// Merchant was not notified of the closed account.
    /// </summary>
    MerchantNotNotifiedOfClosedAccount,

    /// <summary>
    /// Name on manifest of departed flight matches name on purchased itinerary.
    /// </summary>
    NameOnFlightManifestMatchesPurchase,

    /// <summary>
    /// No credit receipt was provided by the cardholder.
    /// </summary>
    NoCreditReceiptProvided,

    /// <summary>
    /// Other.
    /// </summary>
    Other,

    /// <summary>
    /// The claimed processing error did not occur.
    /// </summary>
    ProcessingErrorIncorrect,

    /// <summary>
    /// Returned merchandise held at customs agency outside the merchant's country.
    /// </summary>
    ReturnedMechandiseHeldAtCustomsAgencyOutsideMerchantCountry,

    /// <summary>
    /// Services match the merchant's description.
    /// </summary>
    ServicesMatchDescription,

    /// <summary>
    /// Services were provided prior to the cancellation date.
    /// </summary>
    ServicesProvidedPriorToCancellationDate,

    /// <summary>
    /// Services were used after the cancellation date and prior to the dispute submission date.
    /// </summary>
    ServicesUsedAfterCancellationDate,

    /// <summary>
    /// Terms of service were not misrepresented.
    /// </summary>
    TermsOfServiceNotMisrepresented,

    /// <summary>
    /// Transaction code is correct.
    /// </summary>
    TransactionCodeCorrect,
}

sealed class RepresentedInvalidDisputeReasonConverter
    : JsonConverter<RepresentedInvalidDisputeReason>
{
    public override RepresentedInvalidDisputeReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "automatic_teller_machine_transaction_proof_provided" =>
                RepresentedInvalidDisputeReason.AutomaticTellerMachineTransactionProofProvided,
            "balance_of_partial_prepayment_not_paid" =>
                RepresentedInvalidDisputeReason.BalanceOfPartialPrepaymentNotPaid,
            "cardholder_canceled_before_expected_merchandise_receipt_date" =>
                RepresentedInvalidDisputeReason.CardholderCanceledBeforeExpectedMerchandiseReceiptDate,
            "cardholder_canceled_before_expected_services_receipt_date" =>
                RepresentedInvalidDisputeReason.CardholderCanceledBeforeExpectedServicesReceiptDate,
            "cardholder_canceled_different_date" =>
                RepresentedInvalidDisputeReason.CardholderCanceledDifferentDate,
            "cardholder_did_not_cancel_according_to_policy" =>
                RepresentedInvalidDisputeReason.CardholderDidNotCancelAccordingToPolicy,
            "cardholder_received_merchandise" =>
                RepresentedInvalidDisputeReason.CardholderReceivedMerchandise,
            "country_code_correct" => RepresentedInvalidDisputeReason.CountryCodeCorrect,
            "credit_processed_correctly" =>
                RepresentedInvalidDisputeReason.CreditProcessedCorrectly,
            "currency_correct" => RepresentedInvalidDisputeReason.CurrencyCorrect,
            "dispute_is_for_quality" => RepresentedInvalidDisputeReason.DisputeIsForQuality,
            "dispute_is_for_visa_cash_back_transaction_portion" =>
                RepresentedInvalidDisputeReason.DisputeIsForVisaCashBackTransactionPortion,
            "disputed_amount_is_value_added_tax" =>
                RepresentedInvalidDisputeReason.DisputedAmountIsValueAddedTax,
            "disputed_amount_is_value_added_tax_no_credit_receipt_provided" =>
                RepresentedInvalidDisputeReason.DisputedAmountIsValueAddedTaxNoCreditReceiptProvided,
            "limited_return_or_cancellation_policy_properly_disclosed" =>
                RepresentedInvalidDisputeReason.LimitedReturnOrCancellationPolicyProperlyDisclosed,
            "merchandise_held_at_cardholder_customs_agency" =>
                RepresentedInvalidDisputeReason.MerchandiseHeldAtCardholderCustomsAgency,
            "merchandise_matches_description" =>
                RepresentedInvalidDisputeReason.MerchandiseMatchesDescription,
            "merchandise_not_counterfeit" =>
                RepresentedInvalidDisputeReason.MerchandiseNotCounterfeit,
            "merchandise_not_damaged" => RepresentedInvalidDisputeReason.MerchandiseNotDamaged,
            "merchandise_not_defective" => RepresentedInvalidDisputeReason.MerchandiseNotDefective,
            "merchandise_provided_prior_to_cancellation_date" =>
                RepresentedInvalidDisputeReason.MerchandiseProvidedPriorToCancellationDate,
            "merchandise_quality_matches_description" =>
                RepresentedInvalidDisputeReason.MerchandiseQualityMatchesDescription,
            "merchandise_return_not_attempted" =>
                RepresentedInvalidDisputeReason.MerchandiseReturnNotAttempted,
            "merchant_not_notified_of_closed_account" =>
                RepresentedInvalidDisputeReason.MerchantNotNotifiedOfClosedAccount,
            "name_on_flight_manifest_matches_purchase" =>
                RepresentedInvalidDisputeReason.NameOnFlightManifestMatchesPurchase,
            "no_credit_receipt_provided" => RepresentedInvalidDisputeReason.NoCreditReceiptProvided,
            "other" => RepresentedInvalidDisputeReason.Other,
            "processing_error_incorrect" =>
                RepresentedInvalidDisputeReason.ProcessingErrorIncorrect,
            "returned_mechandise_held_at_customs_agency_outside_merchant_country" =>
                RepresentedInvalidDisputeReason.ReturnedMechandiseHeldAtCustomsAgencyOutsideMerchantCountry,
            "services_match_description" =>
                RepresentedInvalidDisputeReason.ServicesMatchDescription,
            "services_provided_prior_to_cancellation_date" =>
                RepresentedInvalidDisputeReason.ServicesProvidedPriorToCancellationDate,
            "services_used_after_cancellation_date" =>
                RepresentedInvalidDisputeReason.ServicesUsedAfterCancellationDate,
            "terms_of_service_not_misrepresented" =>
                RepresentedInvalidDisputeReason.TermsOfServiceNotMisrepresented,
            "transaction_code_correct" => RepresentedInvalidDisputeReason.TransactionCodeCorrect,
            _ => (RepresentedInvalidDisputeReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RepresentedInvalidDisputeReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RepresentedInvalidDisputeReason.AutomaticTellerMachineTransactionProofProvided =>
                    "automatic_teller_machine_transaction_proof_provided",
                RepresentedInvalidDisputeReason.BalanceOfPartialPrepaymentNotPaid =>
                    "balance_of_partial_prepayment_not_paid",
                RepresentedInvalidDisputeReason.CardholderCanceledBeforeExpectedMerchandiseReceiptDate =>
                    "cardholder_canceled_before_expected_merchandise_receipt_date",
                RepresentedInvalidDisputeReason.CardholderCanceledBeforeExpectedServicesReceiptDate =>
                    "cardholder_canceled_before_expected_services_receipt_date",
                RepresentedInvalidDisputeReason.CardholderCanceledDifferentDate =>
                    "cardholder_canceled_different_date",
                RepresentedInvalidDisputeReason.CardholderDidNotCancelAccordingToPolicy =>
                    "cardholder_did_not_cancel_according_to_policy",
                RepresentedInvalidDisputeReason.CardholderReceivedMerchandise =>
                    "cardholder_received_merchandise",
                RepresentedInvalidDisputeReason.CountryCodeCorrect => "country_code_correct",
                RepresentedInvalidDisputeReason.CreditProcessedCorrectly =>
                    "credit_processed_correctly",
                RepresentedInvalidDisputeReason.CurrencyCorrect => "currency_correct",
                RepresentedInvalidDisputeReason.DisputeIsForQuality => "dispute_is_for_quality",
                RepresentedInvalidDisputeReason.DisputeIsForVisaCashBackTransactionPortion =>
                    "dispute_is_for_visa_cash_back_transaction_portion",
                RepresentedInvalidDisputeReason.DisputedAmountIsValueAddedTax =>
                    "disputed_amount_is_value_added_tax",
                RepresentedInvalidDisputeReason.DisputedAmountIsValueAddedTaxNoCreditReceiptProvided =>
                    "disputed_amount_is_value_added_tax_no_credit_receipt_provided",
                RepresentedInvalidDisputeReason.LimitedReturnOrCancellationPolicyProperlyDisclosed =>
                    "limited_return_or_cancellation_policy_properly_disclosed",
                RepresentedInvalidDisputeReason.MerchandiseHeldAtCardholderCustomsAgency =>
                    "merchandise_held_at_cardholder_customs_agency",
                RepresentedInvalidDisputeReason.MerchandiseMatchesDescription =>
                    "merchandise_matches_description",
                RepresentedInvalidDisputeReason.MerchandiseNotCounterfeit =>
                    "merchandise_not_counterfeit",
                RepresentedInvalidDisputeReason.MerchandiseNotDamaged => "merchandise_not_damaged",
                RepresentedInvalidDisputeReason.MerchandiseNotDefective =>
                    "merchandise_not_defective",
                RepresentedInvalidDisputeReason.MerchandiseProvidedPriorToCancellationDate =>
                    "merchandise_provided_prior_to_cancellation_date",
                RepresentedInvalidDisputeReason.MerchandiseQualityMatchesDescription =>
                    "merchandise_quality_matches_description",
                RepresentedInvalidDisputeReason.MerchandiseReturnNotAttempted =>
                    "merchandise_return_not_attempted",
                RepresentedInvalidDisputeReason.MerchantNotNotifiedOfClosedAccount =>
                    "merchant_not_notified_of_closed_account",
                RepresentedInvalidDisputeReason.NameOnFlightManifestMatchesPurchase =>
                    "name_on_flight_manifest_matches_purchase",
                RepresentedInvalidDisputeReason.NoCreditReceiptProvided =>
                    "no_credit_receipt_provided",
                RepresentedInvalidDisputeReason.Other => "other",
                RepresentedInvalidDisputeReason.ProcessingErrorIncorrect =>
                    "processing_error_incorrect",
                RepresentedInvalidDisputeReason.ReturnedMechandiseHeldAtCustomsAgencyOutsideMerchantCountry =>
                    "returned_mechandise_held_at_customs_agency_outside_merchant_country",
                RepresentedInvalidDisputeReason.ServicesMatchDescription =>
                    "services_match_description",
                RepresentedInvalidDisputeReason.ServicesProvidedPriorToCancellationDate =>
                    "services_provided_prior_to_cancellation_date",
                RepresentedInvalidDisputeReason.ServicesUsedAfterCancellationDate =>
                    "services_used_after_cancellation_date",
                RepresentedInvalidDisputeReason.TermsOfServiceNotMisrepresented =>
                    "terms_of_service_not_misrepresented",
                RepresentedInvalidDisputeReason.TransactionCodeCorrect =>
                    "transaction_code_correct",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Non-fiat currency or non-fungible token as described details. Present if and only
/// if `reason` is `non_fiat_currency_or_non_fungible_token_as_described`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        NonFiatCurrencyOrNonFungibleTokenAsDescribed,
        NonFiatCurrencyOrNonFungibleTokenAsDescribedFromRaw
    >)
)]
public sealed record class NonFiatCurrencyOrNonFungibleTokenAsDescribed : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public NonFiatCurrencyOrNonFungibleTokenAsDescribed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NonFiatCurrencyOrNonFungibleTokenAsDescribed(
        NonFiatCurrencyOrNonFungibleTokenAsDescribed nonFiatCurrencyOrNonFungibleTokenAsDescribed
    )
        : base(nonFiatCurrencyOrNonFungibleTokenAsDescribed) { }
#pragma warning restore CS8618

    public NonFiatCurrencyOrNonFungibleTokenAsDescribed(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NonFiatCurrencyOrNonFungibleTokenAsDescribed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NonFiatCurrencyOrNonFungibleTokenAsDescribedFromRaw.FromRawUnchecked"/>
    public static NonFiatCurrencyOrNonFungibleTokenAsDescribed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NonFiatCurrencyOrNonFungibleTokenAsDescribedFromRaw
    : IFromRawJson<NonFiatCurrencyOrNonFungibleTokenAsDescribed>
{
    /// <inheritdoc/>
    public NonFiatCurrencyOrNonFungibleTokenAsDescribed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NonFiatCurrencyOrNonFungibleTokenAsDescribed.FromRawUnchecked(rawData);
}

/// <summary>
/// Non-fiat currency or non-fungible token received details. Present if and only
/// if `reason` is `non_fiat_currency_or_non_fungible_token_received`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RepresentedNonFiatCurrencyOrNonFungibleTokenReceived,
        RepresentedNonFiatCurrencyOrNonFungibleTokenReceivedFromRaw
    >)
)]
public sealed record class RepresentedNonFiatCurrencyOrNonFungibleTokenReceived : JsonModel
{
    /// <summary>
    /// Blockchain transaction hash.
    /// </summary>
    public required string BlockchainTransactionHash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("blockchain_transaction_hash");
        }
        init { this._rawData.Set("blockchain_transaction_hash", value); }
    }

    /// <summary>
    /// Destination wallet address.
    /// </summary>
    public required string DestinationWalletAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("destination_wallet_address");
        }
        init { this._rawData.Set("destination_wallet_address", value); }
    }

    /// <summary>
    /// Prior approved transactions.
    /// </summary>
    public required string? PriorApprovedTransactions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prior_approved_transactions");
        }
        init { this._rawData.Set("prior_approved_transactions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BlockchainTransactionHash;
        _ = this.DestinationWalletAddress;
        _ = this.PriorApprovedTransactions;
    }

    public RepresentedNonFiatCurrencyOrNonFungibleTokenReceived() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RepresentedNonFiatCurrencyOrNonFungibleTokenReceived(
        RepresentedNonFiatCurrencyOrNonFungibleTokenReceived representedNonFiatCurrencyOrNonFungibleTokenReceived
    )
        : base(representedNonFiatCurrencyOrNonFungibleTokenReceived) { }
#pragma warning restore CS8618

    public RepresentedNonFiatCurrencyOrNonFungibleTokenReceived(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RepresentedNonFiatCurrencyOrNonFungibleTokenReceived(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RepresentedNonFiatCurrencyOrNonFungibleTokenReceivedFromRaw.FromRawUnchecked"/>
    public static RepresentedNonFiatCurrencyOrNonFungibleTokenReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RepresentedNonFiatCurrencyOrNonFungibleTokenReceivedFromRaw
    : IFromRawJson<RepresentedNonFiatCurrencyOrNonFungibleTokenReceived>
{
    /// <inheritdoc/>
    public RepresentedNonFiatCurrencyOrNonFungibleTokenReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RepresentedNonFiatCurrencyOrNonFungibleTokenReceived.FromRawUnchecked(rawData);
}

/// <summary>
/// Proof of cash disbursement details. Present if and only if `reason` is `proof_of_cash_disbursement`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProofOfCashDisbursement, ProofOfCashDisbursementFromRaw>))]
public sealed record class ProofOfCashDisbursement : JsonModel
{
    /// <summary>
    /// Explanation for why the merchant believes the evidence provides proof of cash disbursement.
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Explanation;
    }

    public ProofOfCashDisbursement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProofOfCashDisbursement(ProofOfCashDisbursement proofOfCashDisbursement)
        : base(proofOfCashDisbursement) { }
#pragma warning restore CS8618

    public ProofOfCashDisbursement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProofOfCashDisbursement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProofOfCashDisbursementFromRaw.FromRawUnchecked"/>
    public static ProofOfCashDisbursement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProofOfCashDisbursement(string? explanation)
        : this()
    {
        this.Explanation = explanation;
    }
}

class ProofOfCashDisbursementFromRaw : IFromRawJson<ProofOfCashDisbursement>
{
    /// <inheritdoc/>
    public ProofOfCashDisbursement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProofOfCashDisbursement.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason the merchant re-presented the dispute.
/// </summary>
[JsonConverter(typeof(RepresentedReasonConverter))]
public enum RepresentedReason
{
    /// <summary>
    /// Cardholder no longer disputes the transaction.
    /// </summary>
    CardholderNoLongerDisputes,

    /// <summary>
    /// Credit or reversal was processed.
    /// </summary>
    CreditOrReversalProcessed,

    /// <summary>
    /// Invalid dispute.
    /// </summary>
    InvalidDispute,

    /// <summary>
    /// Non-fiat currency or non-fungible token is as described by the merchant.
    /// </summary>
    NonFiatCurrencyOrNonFungibleTokenAsDescribed,

    /// <summary>
    /// Non-fiat currency or non-fungible token was received by the cardholder.
    /// </summary>
    NonFiatCurrencyOrNonFungibleTokenReceived,

    /// <summary>
    /// Proof of cash disbursement provided.
    /// </summary>
    ProofOfCashDisbursement,

    /// <summary>
    /// Reversal issued by merchant.
    /// </summary>
    ReversalIssued,
}

sealed class RepresentedReasonConverter : JsonConverter<RepresentedReason>
{
    public override RepresentedReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cardholder_no_longer_disputes" => RepresentedReason.CardholderNoLongerDisputes,
            "credit_or_reversal_processed" => RepresentedReason.CreditOrReversalProcessed,
            "invalid_dispute" => RepresentedReason.InvalidDispute,
            "non_fiat_currency_or_non_fungible_token_as_described" =>
                RepresentedReason.NonFiatCurrencyOrNonFungibleTokenAsDescribed,
            "non_fiat_currency_or_non_fungible_token_received" =>
                RepresentedReason.NonFiatCurrencyOrNonFungibleTokenReceived,
            "proof_of_cash_disbursement" => RepresentedReason.ProofOfCashDisbursement,
            "reversal_issued" => RepresentedReason.ReversalIssued,
            _ => (RepresentedReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RepresentedReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RepresentedReason.CardholderNoLongerDisputes => "cardholder_no_longer_disputes",
                RepresentedReason.CreditOrReversalProcessed => "credit_or_reversal_processed",
                RepresentedReason.InvalidDispute => "invalid_dispute",
                RepresentedReason.NonFiatCurrencyOrNonFungibleTokenAsDescribed =>
                    "non_fiat_currency_or_non_fungible_token_as_described",
                RepresentedReason.NonFiatCurrencyOrNonFungibleTokenReceived =>
                    "non_fiat_currency_or_non_fungible_token_received",
                RepresentedReason.ProofOfCashDisbursement => "proof_of_cash_disbursement",
                RepresentedReason.ReversalIssued => "reversal_issued",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Reversal issued by merchant details. Present if and only if `reason` is `reversal_issued`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReversalIssued, ReversalIssuedFromRaw>))]
public sealed record class ReversalIssued : JsonModel
{
    /// <summary>
    /// Explanation of the reversal issued by the merchant.
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Explanation;
    }

    public ReversalIssued() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReversalIssued(ReversalIssued reversalIssued)
        : base(reversalIssued) { }
#pragma warning restore CS8618

    public ReversalIssued(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReversalIssued(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReversalIssuedFromRaw.FromRawUnchecked"/>
    public static ReversalIssued FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReversalIssued(string? explanation)
        : this()
    {
        this.Explanation = explanation;
    }
}

class ReversalIssuedFromRaw : IFromRawJson<ReversalIssued>
{
    /// <inheritdoc/>
    public ReversalIssued FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReversalIssued.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Dispute Re-presentment Timed Out Visa Network Event object. This field
/// will be present in the JSON response if and only if `category` is equal to `representment_timed_out`.
/// Contains the details specific to a re-presentment time-out Visa Card Dispute Network
/// Event, which represents that the user did not respond to the re-presentment by
/// the merchant within the time limit.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RepresentmentTimedOut, RepresentmentTimedOutFromRaw>))]
public sealed record class RepresentmentTimedOut : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public RepresentmentTimedOut() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RepresentmentTimedOut(RepresentmentTimedOut representmentTimedOut)
        : base(representmentTimedOut) { }
#pragma warning restore CS8618

    public RepresentmentTimedOut(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RepresentmentTimedOut(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RepresentmentTimedOutFromRaw.FromRawUnchecked"/>
    public static RepresentmentTimedOut FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RepresentmentTimedOutFromRaw : IFromRawJson<RepresentmentTimedOut>
{
    /// <inheritdoc/>
    public RepresentmentTimedOut FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RepresentmentTimedOut.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Dispute User Pre-Arbitration Accepted Visa Network Event object. This field
/// will be present in the JSON response if and only if `category` is equal to `user_prearbitration_accepted`.
/// Contains the details specific to a user prearbitration accepted Visa Card Dispute
/// Network Event, which represents that the merchant has accepted the user's prearbitration
/// request in the user's favor.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UserPrearbitrationAccepted, UserPrearbitrationAcceptedFromRaw>)
)]
public sealed record class UserPrearbitrationAccepted : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public UserPrearbitrationAccepted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserPrearbitrationAccepted(UserPrearbitrationAccepted userPrearbitrationAccepted)
        : base(userPrearbitrationAccepted) { }
#pragma warning restore CS8618

    public UserPrearbitrationAccepted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserPrearbitrationAccepted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserPrearbitrationAcceptedFromRaw.FromRawUnchecked"/>
    public static UserPrearbitrationAccepted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserPrearbitrationAcceptedFromRaw : IFromRawJson<UserPrearbitrationAccepted>
{
    /// <inheritdoc/>
    public UserPrearbitrationAccepted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserPrearbitrationAccepted.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Dispute User Pre-Arbitration Declined Visa Network Event object. This field
/// will be present in the JSON response if and only if `category` is equal to `user_prearbitration_declined`.
/// Contains the details specific to a user prearbitration declined Visa Card Dispute
/// Network Event, which represents that the merchant has declined the user's prearbitration request.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UserPrearbitrationDeclined, UserPrearbitrationDeclinedFromRaw>)
)]
public sealed record class UserPrearbitrationDeclined : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public UserPrearbitrationDeclined() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserPrearbitrationDeclined(UserPrearbitrationDeclined userPrearbitrationDeclined)
        : base(userPrearbitrationDeclined) { }
#pragma warning restore CS8618

    public UserPrearbitrationDeclined(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserPrearbitrationDeclined(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserPrearbitrationDeclinedFromRaw.FromRawUnchecked"/>
    public static UserPrearbitrationDeclined FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserPrearbitrationDeclinedFromRaw : IFromRawJson<UserPrearbitrationDeclined>
{
    /// <inheritdoc/>
    public UserPrearbitrationDeclined FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserPrearbitrationDeclined.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Dispute User Pre-Arbitration Submitted Visa Network Event object. This
/// field will be present in the JSON response if and only if `category` is equal
/// to `user_prearbitration_submitted`. Contains the details specific to a user prearbitration
/// submitted Visa Card Dispute Network Event, which represents that the user's request
/// for prearbitration has been submitted to the network.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UserPrearbitrationSubmitted, UserPrearbitrationSubmittedFromRaw>)
)]
public sealed record class UserPrearbitrationSubmitted : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public UserPrearbitrationSubmitted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserPrearbitrationSubmitted(UserPrearbitrationSubmitted userPrearbitrationSubmitted)
        : base(userPrearbitrationSubmitted) { }
#pragma warning restore CS8618

    public UserPrearbitrationSubmitted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserPrearbitrationSubmitted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserPrearbitrationSubmittedFromRaw.FromRawUnchecked"/>
    public static UserPrearbitrationSubmitted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserPrearbitrationSubmittedFromRaw : IFromRawJson<UserPrearbitrationSubmitted>
{
    /// <inheritdoc/>
    public UserPrearbitrationSubmitted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserPrearbitrationSubmitted.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Dispute User Pre-Arbitration Timed Out Visa Network Event object. This
/// field will be present in the JSON response if and only if `category` is equal
/// to `user_prearbitration_timed_out`. Contains the details specific to a user prearbitration
/// timed out Visa Card Dispute Network Event, which represents that the merchant
/// has timed out responding to the user's prearbitration request.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UserPrearbitrationTimedOut, UserPrearbitrationTimedOutFromRaw>)
)]
public sealed record class UserPrearbitrationTimedOut : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public UserPrearbitrationTimedOut() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserPrearbitrationTimedOut(UserPrearbitrationTimedOut userPrearbitrationTimedOut)
        : base(userPrearbitrationTimedOut) { }
#pragma warning restore CS8618

    public UserPrearbitrationTimedOut(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserPrearbitrationTimedOut(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserPrearbitrationTimedOutFromRaw.FromRawUnchecked"/>
    public static UserPrearbitrationTimedOut FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserPrearbitrationTimedOutFromRaw : IFromRawJson<UserPrearbitrationTimedOut>
{
    /// <inheritdoc/>
    public UserPrearbitrationTimedOut FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserPrearbitrationTimedOut.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Dispute User Withdrawal Submitted Visa Network Event object. This field
/// will be present in the JSON response if and only if `category` is equal to `user_withdrawal_submitted`.
/// Contains the details specific to a user withdrawal submitted Visa Card Dispute
/// Network Event, which represents that the user's request to withdraw the dispute
/// has been submitted to the network.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserWithdrawalSubmitted, UserWithdrawalSubmittedFromRaw>))]
public sealed record class UserWithdrawalSubmitted : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public UserWithdrawalSubmitted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserWithdrawalSubmitted(UserWithdrawalSubmitted userWithdrawalSubmitted)
        : base(userWithdrawalSubmitted) { }
#pragma warning restore CS8618

    public UserWithdrawalSubmitted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserWithdrawalSubmitted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserWithdrawalSubmittedFromRaw.FromRawUnchecked"/>
    public static UserWithdrawalSubmitted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserWithdrawalSubmittedFromRaw : IFromRawJson<UserWithdrawalSubmitted>
{
    /// <inheritdoc/>
    public UserWithdrawalSubmitted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserWithdrawalSubmitted.FromRawUnchecked(rawData);
}

/// <summary>
/// The category of the currently required user submission if the user wishes to proceed
/// with the dispute. Present if and only if status is `user_submission_required`.
/// Otherwise, this will be `nil`.
/// </summary>
[JsonConverter(typeof(RequiredUserSubmissionCategoryConverter))]
public enum RequiredUserSubmissionCategory
{
    /// <summary>
    /// A Chargeback User Submission is required.
    /// </summary>
    Chargeback,

    /// <summary>
    /// A Merchant Pre Arbitration Decline User Submission is required.
    /// </summary>
    MerchantPrearbitrationDecline,

    /// <summary>
    /// A User Initiated Pre Arbitration User Submission is required.
    /// </summary>
    UserPrearbitration,
}

sealed class RequiredUserSubmissionCategoryConverter : JsonConverter<RequiredUserSubmissionCategory>
{
    public override RequiredUserSubmissionCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "chargeback" => RequiredUserSubmissionCategory.Chargeback,
            "merchant_prearbitration_decline" =>
                RequiredUserSubmissionCategory.MerchantPrearbitrationDecline,
            "user_prearbitration" => RequiredUserSubmissionCategory.UserPrearbitration,
            _ => (RequiredUserSubmissionCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RequiredUserSubmissionCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RequiredUserSubmissionCategory.Chargeback => "chargeback",
                RequiredUserSubmissionCategory.MerchantPrearbitrationDecline =>
                    "merchant_prearbitration_decline",
                RequiredUserSubmissionCategory.UserPrearbitration => "user_prearbitration",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<UserSubmission, UserSubmissionFromRaw>))]
public sealed record class UserSubmission : JsonModel
{
    /// <summary>
    /// The date and time at which the Visa Card Dispute User Submission was reviewed
    /// and accepted.
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
    /// The amount of the dispute if it is different from the amount of a prior user
    /// submission or the disputed transaction.
    /// </summary>
    public required long? Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The files attached to the Visa Card Dispute User Submission.
    /// </summary>
    public required IReadOnlyList<UserSubmissionAttachmentFile> AttachmentFiles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UserSubmissionAttachmentFile>>(
                "attachment_files"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<UserSubmissionAttachmentFile>>(
                "attachment_files",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The category of the user submission. We may add additional possible values
    /// for this enum over time; your application should be able to handle such additions gracefully.
    /// </summary>
    public required ApiEnum<string, UserSubmissionCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserSubmissionCategory>>(
                "category"
            );
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Visa Card Dispute User Submission was created.
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
    /// The free-form explanation provided to Increase to provide more context for
    /// the user submission. This field is not sent directly to the card networks.
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <summary>
    /// The date and time at which Increase requested further information from the
    /// user for the Visa Card Dispute.
    /// </summary>
    public required System::DateTimeOffset? FurtherInformationRequestedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "further_information_requested_at"
            );
        }
        init { this._rawData.Set("further_information_requested_at", value); }
    }

    /// <summary>
    /// The reason for Increase requesting further information from the user for the
    /// Visa Card Dispute.
    /// </summary>
    public required string? FurtherInformationRequestedReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("further_information_requested_reason");
        }
        init { this._rawData.Set("further_information_requested_reason", value); }
    }

    /// <summary>
    /// The status of the Visa Card Dispute User Submission.
    /// </summary>
    public required ApiEnum<string, UserSubmissionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserSubmissionStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Visa Card Dispute User Submission was updated.
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// A Visa Card Dispute Chargeback User Submission Chargeback Details object.
    /// This field will be present in the JSON response if and only if `category`
    /// is equal to `chargeback`. Contains the details specific to a Visa chargeback
    /// User Submission for a Card Dispute.
    /// </summary>
    public UserSubmissionChargeback? Chargeback
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargeback>("chargeback");
        }
        init { this._rawData.Set("chargeback", value); }
    }

    /// <summary>
    /// A Visa Card Dispute Merchant Pre-Arbitration Decline User Submission object.
    /// This field will be present in the JSON response if and only if `category`
    /// is equal to `merchant_prearbitration_decline`. Contains the details specific
    /// to a merchant prearbitration decline Visa Card Dispute User Submission.
    /// </summary>
    public UserSubmissionMerchantPrearbitrationDecline? MerchantPrearbitrationDecline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionMerchantPrearbitrationDecline>(
                "merchant_prearbitration_decline"
            );
        }
        init { this._rawData.Set("merchant_prearbitration_decline", value); }
    }

    /// <summary>
    /// A Visa Card Dispute User-Initiated Pre-Arbitration User Submission object.
    /// This field will be present in the JSON response if and only if `category`
    /// is equal to `user_prearbitration`. Contains the details specific to a user-initiated
    /// pre-arbitration Visa Card Dispute User Submission.
    /// </summary>
    public UserSubmissionUserPrearbitration? UserPrearbitration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionUserPrearbitration>(
                "user_prearbitration"
            );
        }
        init { this._rawData.Set("user_prearbitration", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcceptedAt;
        _ = this.Amount;
        foreach (var item in this.AttachmentFiles)
        {
            item.Validate();
        }
        this.Category.Validate();
        _ = this.CreatedAt;
        _ = this.Explanation;
        _ = this.FurtherInformationRequestedAt;
        _ = this.FurtherInformationRequestedReason;
        this.Status.Validate();
        _ = this.UpdatedAt;
        this.Chargeback?.Validate();
        this.MerchantPrearbitrationDecline?.Validate();
        this.UserPrearbitration?.Validate();
    }

    public UserSubmission() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmission(UserSubmission userSubmission)
        : base(userSubmission) { }
#pragma warning restore CS8618

    public UserSubmission(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmission(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionFromRaw.FromRawUnchecked"/>
    public static UserSubmission FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionFromRaw : IFromRawJson<UserSubmission>
{
    /// <inheritdoc/>
    public UserSubmission FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserSubmission.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<UserSubmissionAttachmentFile, UserSubmissionAttachmentFileFromRaw>)
)]
public sealed record class UserSubmissionAttachmentFile : JsonModel
{
    /// <summary>
    /// The ID of the file attached to the Card Dispute.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
    }

    public UserSubmissionAttachmentFile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionAttachmentFile(UserSubmissionAttachmentFile userSubmissionAttachmentFile)
        : base(userSubmissionAttachmentFile) { }
#pragma warning restore CS8618

    public UserSubmissionAttachmentFile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionAttachmentFile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionAttachmentFileFromRaw.FromRawUnchecked"/>
    public static UserSubmissionAttachmentFile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserSubmissionAttachmentFile(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class UserSubmissionAttachmentFileFromRaw : IFromRawJson<UserSubmissionAttachmentFile>
{
    /// <inheritdoc/>
    public UserSubmissionAttachmentFile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionAttachmentFile.FromRawUnchecked(rawData);
}

/// <summary>
/// The category of the user submission. We may add additional possible values for
/// this enum over time; your application should be able to handle such additions gracefully.
/// </summary>
[JsonConverter(typeof(UserSubmissionCategoryConverter))]
public enum UserSubmissionCategory
{
    /// <summary>
    /// Visa Card Dispute Chargeback User Submission Chargeback Details: details will
    /// be under the `chargeback` object.
    /// </summary>
    Chargeback,

    /// <summary>
    /// Visa Card Dispute Merchant Pre-Arbitration Decline User Submission: details
    /// will be under the `merchant_prearbitration_decline` object.
    /// </summary>
    MerchantPrearbitrationDecline,

    /// <summary>
    /// Visa Card Dispute User-Initiated Pre-Arbitration User Submission: details
    /// will be under the `user_prearbitration` object.
    /// </summary>
    UserPrearbitration,
}

sealed class UserSubmissionCategoryConverter : JsonConverter<UserSubmissionCategory>
{
    public override UserSubmissionCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "chargeback" => UserSubmissionCategory.Chargeback,
            "merchant_prearbitration_decline" =>
                UserSubmissionCategory.MerchantPrearbitrationDecline,
            "user_prearbitration" => UserSubmissionCategory.UserPrearbitration,
            _ => (UserSubmissionCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionCategory.Chargeback => "chargeback",
                UserSubmissionCategory.MerchantPrearbitrationDecline =>
                    "merchant_prearbitration_decline",
                UserSubmissionCategory.UserPrearbitration => "user_prearbitration",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the Visa Card Dispute User Submission.
/// </summary>
[JsonConverter(typeof(UserSubmissionStatusConverter))]
public enum UserSubmissionStatus
{
    /// <summary>
    /// The User Submission was abandoned.
    /// </summary>
    Abandoned,

    /// <summary>
    /// The User Submission was accepted.
    /// </summary>
    Accepted,

    /// <summary>
    /// Further information is requested, please resubmit with the requested information.
    /// </summary>
    FurtherInformationRequested,

    /// <summary>
    /// The User Submission is pending review.
    /// </summary>
    PendingReviewing,
}

sealed class UserSubmissionStatusConverter : JsonConverter<UserSubmissionStatus>
{
    public override UserSubmissionStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "abandoned" => UserSubmissionStatus.Abandoned,
            "accepted" => UserSubmissionStatus.Accepted,
            "further_information_requested" => UserSubmissionStatus.FurtherInformationRequested,
            "pending_reviewing" => UserSubmissionStatus.PendingReviewing,
            _ => (UserSubmissionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionStatus.Abandoned => "abandoned",
                UserSubmissionStatus.Accepted => "accepted",
                UserSubmissionStatus.FurtherInformationRequested => "further_information_requested",
                UserSubmissionStatus.PendingReviewing => "pending_reviewing",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Visa Card Dispute Chargeback User Submission Chargeback Details object. This
/// field will be present in the JSON response if and only if `category` is equal
/// to `chargeback`. Contains the details specific to a Visa chargeback User Submission
/// for a Card Dispute.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UserSubmissionChargeback, UserSubmissionChargebackFromRaw>)
)]
public sealed record class UserSubmissionChargeback : JsonModel
{
    /// <summary>
    /// Authorization. Present if and only if `category` is `authorization`.
    /// </summary>
    public required UserSubmissionChargebackAuthorization? Authorization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackAuthorization>(
                "authorization"
            );
        }
        init { this._rawData.Set("authorization", value); }
    }

    /// <summary>
    /// Category.
    /// </summary>
    public required ApiEnum<string, UserSubmissionChargebackCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserSubmissionChargebackCategory>>(
                "category"
            );
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Canceled merchandise. Present if and only if `category` is `consumer_canceled_merchandise`.
    /// </summary>
    public required UserSubmissionChargebackConsumerCanceledMerchandise? ConsumerCanceledMerchandise
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerCanceledMerchandise>(
                "consumer_canceled_merchandise"
            );
        }
        init { this._rawData.Set("consumer_canceled_merchandise", value); }
    }

    /// <summary>
    /// Canceled recurring transaction. Present if and only if `category` is `consumer_canceled_recurring_transaction`.
    /// </summary>
    public required UserSubmissionChargebackConsumerCanceledRecurringTransaction? ConsumerCanceledRecurringTransaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerCanceledRecurringTransaction>(
                "consumer_canceled_recurring_transaction"
            );
        }
        init { this._rawData.Set("consumer_canceled_recurring_transaction", value); }
    }

    /// <summary>
    /// Canceled services. Present if and only if `category` is `consumer_canceled_services`.
    /// </summary>
    public required UserSubmissionChargebackConsumerCanceledServices? ConsumerCanceledServices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerCanceledServices>(
                "consumer_canceled_services"
            );
        }
        init { this._rawData.Set("consumer_canceled_services", value); }
    }

    /// <summary>
    /// Counterfeit merchandise. Present if and only if `category` is `consumer_counterfeit_merchandise`.
    /// </summary>
    public required UserSubmissionChargebackConsumerCounterfeitMerchandise? ConsumerCounterfeitMerchandise
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerCounterfeitMerchandise>(
                "consumer_counterfeit_merchandise"
            );
        }
        init { this._rawData.Set("consumer_counterfeit_merchandise", value); }
    }

    /// <summary>
    /// Credit not processed. Present if and only if `category` is `consumer_credit_not_processed`.
    /// </summary>
    public required UserSubmissionChargebackConsumerCreditNotProcessed? ConsumerCreditNotProcessed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerCreditNotProcessed>(
                "consumer_credit_not_processed"
            );
        }
        init { this._rawData.Set("consumer_credit_not_processed", value); }
    }

    /// <summary>
    /// Damaged or defective merchandise. Present if and only if `category` is `consumer_damaged_or_defective_merchandise`.
    /// </summary>
    public required UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandise? ConsumerDamagedOrDefectiveMerchandise
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandise>(
                "consumer_damaged_or_defective_merchandise"
            );
        }
        init { this._rawData.Set("consumer_damaged_or_defective_merchandise", value); }
    }

    /// <summary>
    /// Merchandise misrepresentation. Present if and only if `category` is `consumer_merchandise_misrepresentation`.
    /// </summary>
    public required UserSubmissionChargebackConsumerMerchandiseMisrepresentation? ConsumerMerchandiseMisrepresentation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerMerchandiseMisrepresentation>(
                "consumer_merchandise_misrepresentation"
            );
        }
        init { this._rawData.Set("consumer_merchandise_misrepresentation", value); }
    }

    /// <summary>
    /// Merchandise not as described. Present if and only if `category` is `consumer_merchandise_not_as_described`.
    /// </summary>
    public required UserSubmissionChargebackConsumerMerchandiseNotAsDescribed? ConsumerMerchandiseNotAsDescribed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerMerchandiseNotAsDescribed>(
                "consumer_merchandise_not_as_described"
            );
        }
        init { this._rawData.Set("consumer_merchandise_not_as_described", value); }
    }

    /// <summary>
    /// Merchandise not received. Present if and only if `category` is `consumer_merchandise_not_received`.
    /// </summary>
    public required UserSubmissionChargebackConsumerMerchandiseNotReceived? ConsumerMerchandiseNotReceived
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerMerchandiseNotReceived>(
                "consumer_merchandise_not_received"
            );
        }
        init { this._rawData.Set("consumer_merchandise_not_received", value); }
    }

    /// <summary>
    /// Non-receipt of cash. Present if and only if `category` is `consumer_non_receipt_of_cash`.
    /// </summary>
    public required UserSubmissionChargebackConsumerNonReceiptOfCash? ConsumerNonReceiptOfCash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerNonReceiptOfCash>(
                "consumer_non_receipt_of_cash"
            );
        }
        init { this._rawData.Set("consumer_non_receipt_of_cash", value); }
    }

    /// <summary>
    /// Original Credit Transaction (OCT) not accepted. Present if and only if `category`
    /// is `consumer_original_credit_transaction_not_accepted`.
    /// </summary>
    public required UserSubmissionChargebackConsumerOriginalCreditTransactionNotAccepted? ConsumerOriginalCreditTransactionNotAccepted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerOriginalCreditTransactionNotAccepted>(
                "consumer_original_credit_transaction_not_accepted"
            );
        }
        init { this._rawData.Set("consumer_original_credit_transaction_not_accepted", value); }
    }

    /// <summary>
    /// Merchandise quality issue. Present if and only if `category` is `consumer_quality_merchandise`.
    /// </summary>
    public required UserSubmissionChargebackConsumerQualityMerchandise? ConsumerQualityMerchandise
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerQualityMerchandise>(
                "consumer_quality_merchandise"
            );
        }
        init { this._rawData.Set("consumer_quality_merchandise", value); }
    }

    /// <summary>
    /// Services quality issue. Present if and only if `category` is `consumer_quality_services`.
    /// </summary>
    public required UserSubmissionChargebackConsumerQualityServices? ConsumerQualityServices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerQualityServices>(
                "consumer_quality_services"
            );
        }
        init { this._rawData.Set("consumer_quality_services", value); }
    }

    /// <summary>
    /// Services misrepresentation. Present if and only if `category` is `consumer_services_misrepresentation`.
    /// </summary>
    public required UserSubmissionChargebackConsumerServicesMisrepresentation? ConsumerServicesMisrepresentation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerServicesMisrepresentation>(
                "consumer_services_misrepresentation"
            );
        }
        init { this._rawData.Set("consumer_services_misrepresentation", value); }
    }

    /// <summary>
    /// Services not as described. Present if and only if `category` is `consumer_services_not_as_described`.
    /// </summary>
    public required UserSubmissionChargebackConsumerServicesNotAsDescribed? ConsumerServicesNotAsDescribed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerServicesNotAsDescribed>(
                "consumer_services_not_as_described"
            );
        }
        init { this._rawData.Set("consumer_services_not_as_described", value); }
    }

    /// <summary>
    /// Services not received. Present if and only if `category` is `consumer_services_not_received`.
    /// </summary>
    public required UserSubmissionChargebackConsumerServicesNotReceived? ConsumerServicesNotReceived
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerServicesNotReceived>(
                "consumer_services_not_received"
            );
        }
        init { this._rawData.Set("consumer_services_not_received", value); }
    }

    /// <summary>
    /// Fraud. Present if and only if `category` is `fraud`.
    /// </summary>
    public required UserSubmissionChargebackFraud? Fraud
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackFraud>("fraud");
        }
        init { this._rawData.Set("fraud", value); }
    }

    /// <summary>
    /// Processing error. Present if and only if `category` is `processing_error`.
    /// </summary>
    public required UserSubmissionChargebackProcessingError? ProcessingError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackProcessingError>(
                "processing_error"
            );
        }
        init { this._rawData.Set("processing_error", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Authorization?.Validate();
        this.Category.Validate();
        this.ConsumerCanceledMerchandise?.Validate();
        this.ConsumerCanceledRecurringTransaction?.Validate();
        this.ConsumerCanceledServices?.Validate();
        this.ConsumerCounterfeitMerchandise?.Validate();
        this.ConsumerCreditNotProcessed?.Validate();
        this.ConsumerDamagedOrDefectiveMerchandise?.Validate();
        this.ConsumerMerchandiseMisrepresentation?.Validate();
        this.ConsumerMerchandiseNotAsDescribed?.Validate();
        this.ConsumerMerchandiseNotReceived?.Validate();
        this.ConsumerNonReceiptOfCash?.Validate();
        this.ConsumerOriginalCreditTransactionNotAccepted?.Validate();
        this.ConsumerQualityMerchandise?.Validate();
        this.ConsumerQualityServices?.Validate();
        this.ConsumerServicesMisrepresentation?.Validate();
        this.ConsumerServicesNotAsDescribed?.Validate();
        this.ConsumerServicesNotReceived?.Validate();
        this.Fraud?.Validate();
        this.ProcessingError?.Validate();
    }

    public UserSubmissionChargeback() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargeback(UserSubmissionChargeback userSubmissionChargeback)
        : base(userSubmissionChargeback) { }
#pragma warning restore CS8618

    public UserSubmissionChargeback(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargeback(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargeback FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackFromRaw : IFromRawJson<UserSubmissionChargeback>
{
    /// <inheritdoc/>
    public UserSubmissionChargeback FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargeback.FromRawUnchecked(rawData);
}

/// <summary>
/// Authorization. Present if and only if `category` is `authorization`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackAuthorization,
        UserSubmissionChargebackAuthorizationFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackAuthorization : JsonModel
{
    /// <summary>
    /// Account status.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackAuthorizationAccountStatus
    > AccountStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UserSubmissionChargebackAuthorizationAccountStatus>
            >("account_status");
        }
        init { this._rawData.Set("account_status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccountStatus.Validate();
    }

    public UserSubmissionChargebackAuthorization() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackAuthorization(
        UserSubmissionChargebackAuthorization userSubmissionChargebackAuthorization
    )
        : base(userSubmissionChargebackAuthorization) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackAuthorization(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackAuthorization(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackAuthorizationFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackAuthorization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserSubmissionChargebackAuthorization(
        ApiEnum<string, UserSubmissionChargebackAuthorizationAccountStatus> accountStatus
    )
        : this()
    {
        this.AccountStatus = accountStatus;
    }
}

class UserSubmissionChargebackAuthorizationFromRaw
    : IFromRawJson<UserSubmissionChargebackAuthorization>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackAuthorization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackAuthorization.FromRawUnchecked(rawData);
}

/// <summary>
/// Account status.
/// </summary>
[JsonConverter(typeof(UserSubmissionChargebackAuthorizationAccountStatusConverter))]
public enum UserSubmissionChargebackAuthorizationAccountStatus
{
    /// <summary>
    /// Account closed.
    /// </summary>
    AccountClosed,

    /// <summary>
    /// Credit problem.
    /// </summary>
    CreditProblem,

    /// <summary>
    /// Fraud.
    /// </summary>
    Fraud,
}

sealed class UserSubmissionChargebackAuthorizationAccountStatusConverter
    : JsonConverter<UserSubmissionChargebackAuthorizationAccountStatus>
{
    public override UserSubmissionChargebackAuthorizationAccountStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_closed" => UserSubmissionChargebackAuthorizationAccountStatus.AccountClosed,
            "credit_problem" => UserSubmissionChargebackAuthorizationAccountStatus.CreditProblem,
            "fraud" => UserSubmissionChargebackAuthorizationAccountStatus.Fraud,
            _ => (UserSubmissionChargebackAuthorizationAccountStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackAuthorizationAccountStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackAuthorizationAccountStatus.AccountClosed =>
                    "account_closed",
                UserSubmissionChargebackAuthorizationAccountStatus.CreditProblem =>
                    "credit_problem",
                UserSubmissionChargebackAuthorizationAccountStatus.Fraud => "fraud",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Category.
/// </summary>
[JsonConverter(typeof(UserSubmissionChargebackCategoryConverter))]
public enum UserSubmissionChargebackCategory
{
    /// <summary>
    /// Authorization.
    /// </summary>
    Authorization,

    /// <summary>
    /// Consumer: canceled merchandise.
    /// </summary>
    ConsumerCanceledMerchandise,

    /// <summary>
    /// Consumer: canceled recurring transaction.
    /// </summary>
    ConsumerCanceledRecurringTransaction,

    /// <summary>
    /// Consumer: canceled services.
    /// </summary>
    ConsumerCanceledServices,

    /// <summary>
    /// Consumer: counterfeit merchandise.
    /// </summary>
    ConsumerCounterfeitMerchandise,

    /// <summary>
    /// Consumer: credit not processed.
    /// </summary>
    ConsumerCreditNotProcessed,

    /// <summary>
    /// Consumer: damaged or defective merchandise.
    /// </summary>
    ConsumerDamagedOrDefectiveMerchandise,

    /// <summary>
    /// Consumer: merchandise misrepresentation.
    /// </summary>
    ConsumerMerchandiseMisrepresentation,

    /// <summary>
    /// Consumer: merchandise not as described.
    /// </summary>
    ConsumerMerchandiseNotAsDescribed,

    /// <summary>
    /// Consumer: merchandise not received.
    /// </summary>
    ConsumerMerchandiseNotReceived,

    /// <summary>
    /// Consumer: non-receipt of cash.
    /// </summary>
    ConsumerNonReceiptOfCash,

    /// <summary>
    /// Consumer: Original Credit Transaction (OCT) not accepted.
    /// </summary>
    ConsumerOriginalCreditTransactionNotAccepted,

    /// <summary>
    /// Consumer: merchandise quality issue.
    /// </summary>
    ConsumerQualityMerchandise,

    /// <summary>
    /// Consumer: services quality issue.
    /// </summary>
    ConsumerQualityServices,

    /// <summary>
    /// Consumer: services misrepresentation.
    /// </summary>
    ConsumerServicesMisrepresentation,

    /// <summary>
    /// Consumer: services not as described.
    /// </summary>
    ConsumerServicesNotAsDescribed,

    /// <summary>
    /// Consumer: services not received.
    /// </summary>
    ConsumerServicesNotReceived,

    /// <summary>
    /// Fraud.
    /// </summary>
    Fraud,

    /// <summary>
    /// Processing error.
    /// </summary>
    ProcessingError,
}

sealed class UserSubmissionChargebackCategoryConverter
    : JsonConverter<UserSubmissionChargebackCategory>
{
    public override UserSubmissionChargebackCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "authorization" => UserSubmissionChargebackCategory.Authorization,
            "consumer_canceled_merchandise" =>
                UserSubmissionChargebackCategory.ConsumerCanceledMerchandise,
            "consumer_canceled_recurring_transaction" =>
                UserSubmissionChargebackCategory.ConsumerCanceledRecurringTransaction,
            "consumer_canceled_services" =>
                UserSubmissionChargebackCategory.ConsumerCanceledServices,
            "consumer_counterfeit_merchandise" =>
                UserSubmissionChargebackCategory.ConsumerCounterfeitMerchandise,
            "consumer_credit_not_processed" =>
                UserSubmissionChargebackCategory.ConsumerCreditNotProcessed,
            "consumer_damaged_or_defective_merchandise" =>
                UserSubmissionChargebackCategory.ConsumerDamagedOrDefectiveMerchandise,
            "consumer_merchandise_misrepresentation" =>
                UserSubmissionChargebackCategory.ConsumerMerchandiseMisrepresentation,
            "consumer_merchandise_not_as_described" =>
                UserSubmissionChargebackCategory.ConsumerMerchandiseNotAsDescribed,
            "consumer_merchandise_not_received" =>
                UserSubmissionChargebackCategory.ConsumerMerchandiseNotReceived,
            "consumer_non_receipt_of_cash" =>
                UserSubmissionChargebackCategory.ConsumerNonReceiptOfCash,
            "consumer_original_credit_transaction_not_accepted" =>
                UserSubmissionChargebackCategory.ConsumerOriginalCreditTransactionNotAccepted,
            "consumer_quality_merchandise" =>
                UserSubmissionChargebackCategory.ConsumerQualityMerchandise,
            "consumer_quality_services" => UserSubmissionChargebackCategory.ConsumerQualityServices,
            "consumer_services_misrepresentation" =>
                UserSubmissionChargebackCategory.ConsumerServicesMisrepresentation,
            "consumer_services_not_as_described" =>
                UserSubmissionChargebackCategory.ConsumerServicesNotAsDescribed,
            "consumer_services_not_received" =>
                UserSubmissionChargebackCategory.ConsumerServicesNotReceived,
            "fraud" => UserSubmissionChargebackCategory.Fraud,
            "processing_error" => UserSubmissionChargebackCategory.ProcessingError,
            _ => (UserSubmissionChargebackCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackCategory.Authorization => "authorization",
                UserSubmissionChargebackCategory.ConsumerCanceledMerchandise =>
                    "consumer_canceled_merchandise",
                UserSubmissionChargebackCategory.ConsumerCanceledRecurringTransaction =>
                    "consumer_canceled_recurring_transaction",
                UserSubmissionChargebackCategory.ConsumerCanceledServices =>
                    "consumer_canceled_services",
                UserSubmissionChargebackCategory.ConsumerCounterfeitMerchandise =>
                    "consumer_counterfeit_merchandise",
                UserSubmissionChargebackCategory.ConsumerCreditNotProcessed =>
                    "consumer_credit_not_processed",
                UserSubmissionChargebackCategory.ConsumerDamagedOrDefectiveMerchandise =>
                    "consumer_damaged_or_defective_merchandise",
                UserSubmissionChargebackCategory.ConsumerMerchandiseMisrepresentation =>
                    "consumer_merchandise_misrepresentation",
                UserSubmissionChargebackCategory.ConsumerMerchandiseNotAsDescribed =>
                    "consumer_merchandise_not_as_described",
                UserSubmissionChargebackCategory.ConsumerMerchandiseNotReceived =>
                    "consumer_merchandise_not_received",
                UserSubmissionChargebackCategory.ConsumerNonReceiptOfCash =>
                    "consumer_non_receipt_of_cash",
                UserSubmissionChargebackCategory.ConsumerOriginalCreditTransactionNotAccepted =>
                    "consumer_original_credit_transaction_not_accepted",
                UserSubmissionChargebackCategory.ConsumerQualityMerchandise =>
                    "consumer_quality_merchandise",
                UserSubmissionChargebackCategory.ConsumerQualityServices =>
                    "consumer_quality_services",
                UserSubmissionChargebackCategory.ConsumerServicesMisrepresentation =>
                    "consumer_services_misrepresentation",
                UserSubmissionChargebackCategory.ConsumerServicesNotAsDescribed =>
                    "consumer_services_not_as_described",
                UserSubmissionChargebackCategory.ConsumerServicesNotReceived =>
                    "consumer_services_not_received",
                UserSubmissionChargebackCategory.Fraud => "fraud",
                UserSubmissionChargebackCategory.ProcessingError => "processing_error",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Canceled merchandise. Present if and only if `category` is `consumer_canceled_merchandise`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerCanceledMerchandise,
        UserSubmissionChargebackConsumerCanceledMerchandiseFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerCanceledMerchandise : JsonModel
{
    /// <summary>
    /// Cardholder cancellation.
    /// </summary>
    public required UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellation? CardholderCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellation>(
                "cardholder_cancellation"
            );
        }
        init { this._rawData.Set("cardholder_cancellation", value); }
    }

    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted
                >
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
    }

    /// <summary>
    /// Not returned. Present if and only if `return_outcome` is `not_returned`.
    /// </summary>
    public required UserSubmissionChargebackConsumerCanceledMerchandiseNotReturned? NotReturned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerCanceledMerchandiseNotReturned>(
                "not_returned"
            );
        }
        init { this._rawData.Set("not_returned", value); }
    }

    /// <summary>
    /// Purchase explanation.
    /// </summary>
    public required string PurchaseExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("purchase_explanation");
        }
        init { this._rawData.Set("purchase_explanation", value); }
    }

    /// <summary>
    /// Received or expected at.
    /// </summary>
    public required string ReceivedOrExpectedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("received_or_expected_at");
        }
        init { this._rawData.Set("received_or_expected_at", value); }
    }

    /// <summary>
    /// Return attempted. Present if and only if `return_outcome` is `return_attempted`.
    /// </summary>
    public required UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttempted>(
                "return_attempted"
            );
        }
        init { this._rawData.Set("return_attempted", value); }
    }

    /// <summary>
    /// Return outcome.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome
    > ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome>
            >("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Returned. Present if and only if `return_outcome` is `returned`.
    /// </summary>
    public required UserSubmissionChargebackConsumerCanceledMerchandiseReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerCanceledMerchandiseReturned>(
                "returned"
            );
        }
        init { this._rawData.Set("returned", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CardholderCancellation?.Validate();
        this.MerchantResolutionAttempted.Validate();
        this.NotReturned?.Validate();
        _ = this.PurchaseExplanation;
        _ = this.ReceivedOrExpectedAt;
        this.ReturnAttempted?.Validate();
        this.ReturnOutcome.Validate();
        this.Returned?.Validate();
    }

    public UserSubmissionChargebackConsumerCanceledMerchandise() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerCanceledMerchandise(
        UserSubmissionChargebackConsumerCanceledMerchandise userSubmissionChargebackConsumerCanceledMerchandise
    )
        : base(userSubmissionChargebackConsumerCanceledMerchandise) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerCanceledMerchandise(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerCanceledMerchandise(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerCanceledMerchandiseFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerCanceledMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerCanceledMerchandiseFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerCanceledMerchandise>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerCanceledMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerCanceledMerchandise.FromRawUnchecked(rawData);
}

/// <summary>
/// Cardholder cancellation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellation,
        UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellation
    : JsonModel
{
    /// <summary>
    /// Canceled at.
    /// </summary>
    public required string CanceledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("canceled_at");
        }
        init { this._rawData.Set("canceled_at", value); }
    }

    /// <summary>
    /// Canceled prior to ship date.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate
    > CanceledPriorToShipDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate
                >
            >("canceled_prior_to_ship_date");
        }
        init { this._rawData.Set("canceled_prior_to_ship_date", value); }
    }

    /// <summary>
    /// Cancellation policy provided.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided
    > CancellationPolicyProvided
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided
                >
            >("cancellation_policy_provided");
        }
        init { this._rawData.Set("cancellation_policy_provided", value); }
    }

    /// <summary>
    /// Reason.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanceledAt;
        this.CanceledPriorToShipDate.Validate();
        this.CancellationPolicyProvided.Validate();
        _ = this.Reason;
    }

    public UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellation(
        UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellation userSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellation
    )
        : base(userSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellation) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellation>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Canceled prior to ship date.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDateConverter)
)]
public enum UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate
{
    /// <summary>
    /// Canceled prior to ship date.
    /// </summary>
    CanceledPriorToShipDate,

    /// <summary>
    /// Not canceled prior to ship date.
    /// </summary>
    NotCanceledPriorToShipDate,
}

sealed class UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDateConverter
    : JsonConverter<UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate>
{
    public override UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "canceled_prior_to_ship_date" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
            "not_canceled_prior_to_ship_date" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.NotCanceledPriorToShipDate,
            _ =>
                (UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate =>
                    "canceled_prior_to_ship_date",
                UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.NotCanceledPriorToShipDate =>
                    "not_canceled_prior_to_ship_date",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Cancellation policy provided.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvidedConverter)
)]
public enum UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided
{
    /// <summary>
    /// Not provided.
    /// </summary>
    NotProvided,

    /// <summary>
    /// Provided.
    /// </summary>
    Provided,
}

sealed class UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvidedConverter
    : JsonConverter<UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided>
{
    public override UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_provided" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
            "provided" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.Provided,
            _ =>
                (UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided =>
                    "not_provided",
                UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.Provided =>
                    "provided",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttemptedConverter)
)]
public enum UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted
{
    /// <summary>
    /// Attempted.
    /// </summary>
    Attempted,

    /// <summary>
    /// Prohibited by local law.
    /// </summary>
    ProhibitedByLocalLaw,
}

sealed class UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttemptedConverter
    : JsonConverter<UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted>
{
    public override UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted =>
                    "attempted",
                UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw =>
                    "prohibited_by_local_law",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Not returned. Present if and only if `return_outcome` is `not_returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerCanceledMerchandiseNotReturned,
        UserSubmissionChargebackConsumerCanceledMerchandiseNotReturnedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerCanceledMerchandiseNotReturned
    : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public UserSubmissionChargebackConsumerCanceledMerchandiseNotReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerCanceledMerchandiseNotReturned(
        UserSubmissionChargebackConsumerCanceledMerchandiseNotReturned userSubmissionChargebackConsumerCanceledMerchandiseNotReturned
    )
        : base(userSubmissionChargebackConsumerCanceledMerchandiseNotReturned) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerCanceledMerchandiseNotReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerCanceledMerchandiseNotReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerCanceledMerchandiseNotReturnedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerCanceledMerchandiseNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerCanceledMerchandiseNotReturnedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerCanceledMerchandiseNotReturned>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerCanceledMerchandiseNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerCanceledMerchandiseNotReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return attempted. Present if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttempted,
        UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttempted
    : JsonModel
{
    /// <summary>
    /// Attempt explanation.
    /// </summary>
    public required string AttemptExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("attempt_explanation");
        }
        init { this._rawData.Set("attempt_explanation", value); }
    }

    /// <summary>
    /// Attempt reason.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason
    > AttemptReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason
                >
            >("attempt_reason");
        }
        init { this._rawData.Set("attempt_reason", value); }
    }

    /// <summary>
    /// Attempted at.
    /// </summary>
    public required string AttemptedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("attempted_at");
        }
        init { this._rawData.Set("attempted_at", value); }
    }

    /// <summary>
    /// Merchandise disposition.
    /// </summary>
    public required string MerchandiseDisposition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchandise_disposition");
        }
        init { this._rawData.Set("merchandise_disposition", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AttemptExplanation;
        this.AttemptReason.Validate();
        _ = this.AttemptedAt;
        _ = this.MerchandiseDisposition;
    }

    public UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttempted(
        UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttempted userSubmissionChargebackConsumerCanceledMerchandiseReturnAttempted
    )
        : base(userSubmissionChargebackConsumerCanceledMerchandiseReturnAttempted) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttempted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttempted(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttempted>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttempted.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Attempt reason.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReasonConverter)
)]
public enum UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason
{
    /// <summary>
    /// Merchant not responding.
    /// </summary>
    MerchantNotResponding,

    /// <summary>
    /// No return authorization provided.
    /// </summary>
    NoReturnAuthorizationProvided,

    /// <summary>
    /// No return instructions.
    /// </summary>
    NoReturnInstructions,

    /// <summary>
    /// Requested not to return.
    /// </summary>
    RequestedNotToReturn,

    /// <summary>
    /// Return not accepted.
    /// </summary>
    ReturnNotAccepted,
}

sealed class UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReasonConverter
    : JsonConverter<UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason>
{
    public override UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merchant_not_responding" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            "no_return_authorization_provided" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided,
            "no_return_instructions" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions,
            "requested_not_to_return" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn,
            "return_not_accepted" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted,
            _ => (UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding =>
                    "merchant_not_responding",
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided =>
                    "no_return_authorization_provided",
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions =>
                    "no_return_instructions",
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn =>
                    "requested_not_to_return",
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted =>
                    "return_not_accepted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Return outcome.
/// </summary>
[JsonConverter(typeof(UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcomeConverter))]
public enum UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome
{
    /// <summary>
    /// Not returned.
    /// </summary>
    NotReturned,

    /// <summary>
    /// Returned.
    /// </summary>
    Returned,

    /// <summary>
    /// Return attempted.
    /// </summary>
    ReturnAttempted,
}

sealed class UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcomeConverter
    : JsonConverter<UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome>
{
    public override UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_returned" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
            "returned" => UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome.Returned,
            "return_attempted" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome.ReturnAttempted,
            _ => (UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned =>
                    "not_returned",
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome.Returned =>
                    "returned",
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome.ReturnAttempted =>
                    "return_attempted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Returned. Present if and only if `return_outcome` is `returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerCanceledMerchandiseReturned,
        UserSubmissionChargebackConsumerCanceledMerchandiseReturnedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerCanceledMerchandiseReturned : JsonModel
{
    /// <summary>
    /// Merchant received return at.
    /// </summary>
    public required string? MerchantReceivedReturnAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_received_return_at");
        }
        init { this._rawData.Set("merchant_received_return_at", value); }
    }

    /// <summary>
    /// Other explanation. Required if and only if the return method is `other`.
    /// </summary>
    public required string? OtherExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("other_explanation");
        }
        init { this._rawData.Set("other_explanation", value); }
    }

    /// <summary>
    /// Return method.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod
    > ReturnMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod
                >
            >("return_method");
        }
        init { this._rawData.Set("return_method", value); }
    }

    /// <summary>
    /// Returned at.
    /// </summary>
    public required string ReturnedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("returned_at");
        }
        init { this._rawData.Set("returned_at", value); }
    }

    /// <summary>
    /// Tracking number.
    /// </summary>
    public required string? TrackingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tracking_number");
        }
        init { this._rawData.Set("tracking_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MerchantReceivedReturnAt;
        _ = this.OtherExplanation;
        this.ReturnMethod.Validate();
        _ = this.ReturnedAt;
        _ = this.TrackingNumber;
    }

    public UserSubmissionChargebackConsumerCanceledMerchandiseReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerCanceledMerchandiseReturned(
        UserSubmissionChargebackConsumerCanceledMerchandiseReturned userSubmissionChargebackConsumerCanceledMerchandiseReturned
    )
        : base(userSubmissionChargebackConsumerCanceledMerchandiseReturned) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerCanceledMerchandiseReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerCanceledMerchandiseReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerCanceledMerchandiseReturnedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerCanceledMerchandiseReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerCanceledMerchandiseReturnedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerCanceledMerchandiseReturned>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerCanceledMerchandiseReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerCanceledMerchandiseReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return method.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethodConverter)
)]
public enum UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod
{
    /// <summary>
    /// DHL.
    /// </summary>
    Dhl,

    /// <summary>
    /// Face-to-face.
    /// </summary>
    FaceToFace,

    /// <summary>
    /// FedEx.
    /// </summary>
    Fedex,

    /// <summary>
    /// Other.
    /// </summary>
    Other,

    /// <summary>
    /// Postal service.
    /// </summary>
    PostalService,

    /// <summary>
    /// UPS.
    /// </summary>
    Ups,
}

sealed class UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethodConverter
    : JsonConverter<UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod>
{
    public override UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dhl" => UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
            "face_to_face" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.FaceToFace,
            "fedex" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Fedex,
            "other" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Other,
            "postal_service" =>
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.PostalService,
            "ups" => UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Ups,
            _ => (UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl =>
                    "dhl",
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.FaceToFace =>
                    "face_to_face",
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Fedex =>
                    "fedex",
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Other =>
                    "other",
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.PostalService =>
                    "postal_service",
                UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Ups =>
                    "ups",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Canceled recurring transaction. Present if and only if `category` is `consumer_canceled_recurring_transaction`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerCanceledRecurringTransaction,
        UserSubmissionChargebackConsumerCanceledRecurringTransactionFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerCanceledRecurringTransaction : JsonModel
{
    /// <summary>
    /// Cancellation target.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget
    > CancellationTarget
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget
                >
            >("cancellation_target");
        }
        init { this._rawData.Set("cancellation_target", value); }
    }

    /// <summary>
    /// Merchant contact methods.
    /// </summary>
    public required UserSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethods MerchantContactMethods
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UserSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethods>(
                "merchant_contact_methods"
            );
        }
        init { this._rawData.Set("merchant_contact_methods", value); }
    }

    /// <summary>
    /// Other form of payment explanation.
    /// </summary>
    public required string? OtherFormOfPaymentExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("other_form_of_payment_explanation");
        }
        init { this._rawData.Set("other_form_of_payment_explanation", value); }
    }

    /// <summary>
    /// Transaction or account canceled at.
    /// </summary>
    public required string TransactionOrAccountCanceledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transaction_or_account_canceled_at");
        }
        init { this._rawData.Set("transaction_or_account_canceled_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CancellationTarget.Validate();
        this.MerchantContactMethods.Validate();
        _ = this.OtherFormOfPaymentExplanation;
        _ = this.TransactionOrAccountCanceledAt;
    }

    public UserSubmissionChargebackConsumerCanceledRecurringTransaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerCanceledRecurringTransaction(
        UserSubmissionChargebackConsumerCanceledRecurringTransaction userSubmissionChargebackConsumerCanceledRecurringTransaction
    )
        : base(userSubmissionChargebackConsumerCanceledRecurringTransaction) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerCanceledRecurringTransaction(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerCanceledRecurringTransaction(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerCanceledRecurringTransactionFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerCanceledRecurringTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerCanceledRecurringTransactionFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerCanceledRecurringTransaction>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerCanceledRecurringTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerCanceledRecurringTransaction.FromRawUnchecked(rawData);
}

/// <summary>
/// Cancellation target.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTargetConverter)
)]
public enum UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget
{
    /// <summary>
    /// Account.
    /// </summary>
    Account,

    /// <summary>
    /// Transaction.
    /// </summary>
    Transaction,
}

sealed class UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTargetConverter
    : JsonConverter<UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget>
{
    public override UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account" =>
                UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
            "transaction" =>
                UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget.Transaction,
            _ => (UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account =>
                    "account",
                UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget.Transaction =>
                    "transaction",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Merchant contact methods.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethods,
        UserSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethodsFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethods
    : JsonModel
{
    /// <summary>
    /// Application name.
    /// </summary>
    public required string? ApplicationName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("application_name");
        }
        init { this._rawData.Set("application_name", value); }
    }

    /// <summary>
    /// Call center phone number.
    /// </summary>
    public required string? CallCenterPhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("call_center_phone_number");
        }
        init { this._rawData.Set("call_center_phone_number", value); }
    }

    /// <summary>
    /// Email address.
    /// </summary>
    public required string? EmailAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email_address");
        }
        init { this._rawData.Set("email_address", value); }
    }

    /// <summary>
    /// In person address.
    /// </summary>
    public required string? InPersonAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("in_person_address");
        }
        init { this._rawData.Set("in_person_address", value); }
    }

    /// <summary>
    /// Mailing address.
    /// </summary>
    public required string? MailingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mailing_address");
        }
        init { this._rawData.Set("mailing_address", value); }
    }

    /// <summary>
    /// Text phone number.
    /// </summary>
    public required string? TextPhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_phone_number");
        }
        init { this._rawData.Set("text_phone_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApplicationName;
        _ = this.CallCenterPhoneNumber;
        _ = this.EmailAddress;
        _ = this.InPersonAddress;
        _ = this.MailingAddress;
        _ = this.TextPhoneNumber;
    }

    public UserSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethods() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethods(
        UserSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethods userSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethods
    )
        : base(userSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethods)
    { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethods(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethods(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethodsFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethods FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethodsFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethods>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethods FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerCanceledRecurringTransactionMerchantContactMethods.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Canceled services. Present if and only if `category` is `consumer_canceled_services`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerCanceledServices,
        UserSubmissionChargebackConsumerCanceledServicesFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerCanceledServices : JsonModel
{
    /// <summary>
    /// Cardholder cancellation.
    /// </summary>
    public required UserSubmissionChargebackConsumerCanceledServicesCardholderCancellation CardholderCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UserSubmissionChargebackConsumerCanceledServicesCardholderCancellation>(
                "cardholder_cancellation"
            );
        }
        init { this._rawData.Set("cardholder_cancellation", value); }
    }

    /// <summary>
    /// Contracted at.
    /// </summary>
    public required string ContractedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("contracted_at");
        }
        init { this._rawData.Set("contracted_at", value); }
    }

    /// <summary>
    /// Guaranteed reservation explanation. Present if and only if `service_type`
    /// is `guaranteed_reservation`.
    /// </summary>
    public required UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservation? GuaranteedReservation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservation>(
                "guaranteed_reservation"
            );
        }
        init { this._rawData.Set("guaranteed_reservation", value); }
    }

    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted
                >
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
    }

    /// <summary>
    /// Other service type explanation. Present if and only if `service_type` is `other`.
    /// </summary>
    public required UserSubmissionChargebackConsumerCanceledServicesOther? Other
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerCanceledServicesOther>(
                "other"
            );
        }
        init { this._rawData.Set("other", value); }
    }

    /// <summary>
    /// Purchase explanation.
    /// </summary>
    public required string PurchaseExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("purchase_explanation");
        }
        init { this._rawData.Set("purchase_explanation", value); }
    }

    /// <summary>
    /// Service type.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerCanceledServicesServiceType
    > ServiceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UserSubmissionChargebackConsumerCanceledServicesServiceType>
            >("service_type");
        }
        init { this._rawData.Set("service_type", value); }
    }

    /// <summary>
    /// Timeshare explanation. Present if and only if `service_type` is `timeshare`.
    /// </summary>
    public required UserSubmissionChargebackConsumerCanceledServicesTimeshare? Timeshare
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerCanceledServicesTimeshare>(
                "timeshare"
            );
        }
        init { this._rawData.Set("timeshare", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CardholderCancellation.Validate();
        _ = this.ContractedAt;
        this.GuaranteedReservation?.Validate();
        this.MerchantResolutionAttempted.Validate();
        this.Other?.Validate();
        _ = this.PurchaseExplanation;
        this.ServiceType.Validate();
        this.Timeshare?.Validate();
    }

    public UserSubmissionChargebackConsumerCanceledServices() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerCanceledServices(
        UserSubmissionChargebackConsumerCanceledServices userSubmissionChargebackConsumerCanceledServices
    )
        : base(userSubmissionChargebackConsumerCanceledServices) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerCanceledServices(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerCanceledServices(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerCanceledServicesFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerCanceledServices FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerCanceledServicesFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerCanceledServices>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerCanceledServices FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerCanceledServices.FromRawUnchecked(rawData);
}

/// <summary>
/// Cardholder cancellation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerCanceledServicesCardholderCancellation,
        UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerCanceledServicesCardholderCancellation
    : JsonModel
{
    /// <summary>
    /// Canceled at.
    /// </summary>
    public required string CanceledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("canceled_at");
        }
        init { this._rawData.Set("canceled_at", value); }
    }

    /// <summary>
    /// Cancellation policy provided.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
    > CancellationPolicyProvided
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
                >
            >("cancellation_policy_provided");
        }
        init { this._rawData.Set("cancellation_policy_provided", value); }
    }

    /// <summary>
    /// Reason.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanceledAt;
        this.CancellationPolicyProvided.Validate();
        _ = this.Reason;
    }

    public UserSubmissionChargebackConsumerCanceledServicesCardholderCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerCanceledServicesCardholderCancellation(
        UserSubmissionChargebackConsumerCanceledServicesCardholderCancellation userSubmissionChargebackConsumerCanceledServicesCardholderCancellation
    )
        : base(userSubmissionChargebackConsumerCanceledServicesCardholderCancellation) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerCanceledServicesCardholderCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerCanceledServicesCardholderCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerCanceledServicesCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerCanceledServicesCardholderCancellation>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerCanceledServicesCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerCanceledServicesCardholderCancellation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Cancellation policy provided.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvidedConverter)
)]
public enum UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
{
    /// <summary>
    /// Not provided.
    /// </summary>
    NotProvided,

    /// <summary>
    /// Provided.
    /// </summary>
    Provided,
}

sealed class UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvidedConverter
    : JsonConverter<UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided>
{
    public override UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_provided" =>
                UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
            "provided" =>
                UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.Provided,
            _ =>
                (UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided =>
                    "not_provided",
                UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.Provided =>
                    "provided",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Guaranteed reservation explanation. Present if and only if `service_type` is `guaranteed_reservation`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservation,
        UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservation
    : JsonModel
{
    /// <summary>
    /// Explanation.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation
    > Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation
                >
            >("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Explanation.Validate();
    }

    public UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservation(
        UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservation userSubmissionChargebackConsumerCanceledServicesGuaranteedReservation
    )
        : base(userSubmissionChargebackConsumerCanceledServicesGuaranteedReservation) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservation(
        ApiEnum<
            string,
            UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation
        > explanation
    )
        : this()
    {
        this.Explanation = explanation;
    }
}

class UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservation>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Explanation.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanationConverter)
)]
public enum UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation
{
    /// <summary>
    /// Cardholder canceled prior to service.
    /// </summary>
    CardholderCanceledPriorToService,

    /// <summary>
    /// Cardholder cancellation attempt within 24 hours of confirmation.
    /// </summary>
    CardholderCancellationAttemptWithin24HoursOfConfirmation,

    /// <summary>
    /// Merchant billed for no-show.
    /// </summary>
    MerchantBilledNoShow,
}

sealed class UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanationConverter
    : JsonConverter<UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation>
{
    public override UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cardholder_canceled_prior_to_service" =>
                UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService,
            "cardholder_cancellation_attempt_within_24_hours_of_confirmation" =>
                UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCancellationAttemptWithin24HoursOfConfirmation,
            "merchant_billed_no_show" =>
                UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation.MerchantBilledNoShow,
            _ => (UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService =>
                    "cardholder_canceled_prior_to_service",
                UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCancellationAttemptWithin24HoursOfConfirmation =>
                    "cardholder_cancellation_attempt_within_24_hours_of_confirmation",
                UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation.MerchantBilledNoShow =>
                    "merchant_billed_no_show",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttemptedConverter)
)]
public enum UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted
{
    /// <summary>
    /// Attempted.
    /// </summary>
    Attempted,

    /// <summary>
    /// Prohibited by local law.
    /// </summary>
    ProhibitedByLocalLaw,
}

sealed class UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttemptedConverter
    : JsonConverter<UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted>
{
    public override UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted =>
                    "attempted",
                UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted.ProhibitedByLocalLaw =>
                    "prohibited_by_local_law",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Other service type explanation. Present if and only if `service_type` is `other`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerCanceledServicesOther,
        UserSubmissionChargebackConsumerCanceledServicesOtherFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerCanceledServicesOther : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public UserSubmissionChargebackConsumerCanceledServicesOther() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerCanceledServicesOther(
        UserSubmissionChargebackConsumerCanceledServicesOther userSubmissionChargebackConsumerCanceledServicesOther
    )
        : base(userSubmissionChargebackConsumerCanceledServicesOther) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerCanceledServicesOther(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerCanceledServicesOther(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerCanceledServicesOtherFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerCanceledServicesOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerCanceledServicesOtherFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerCanceledServicesOther>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerCanceledServicesOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerCanceledServicesOther.FromRawUnchecked(rawData);
}

/// <summary>
/// Service type.
/// </summary>
[JsonConverter(typeof(UserSubmissionChargebackConsumerCanceledServicesServiceTypeConverter))]
public enum UserSubmissionChargebackConsumerCanceledServicesServiceType
{
    /// <summary>
    /// Guaranteed reservation.
    /// </summary>
    GuaranteedReservation,

    /// <summary>
    /// Other.
    /// </summary>
    Other,

    /// <summary>
    /// Timeshare.
    /// </summary>
    Timeshare,
}

sealed class UserSubmissionChargebackConsumerCanceledServicesServiceTypeConverter
    : JsonConverter<UserSubmissionChargebackConsumerCanceledServicesServiceType>
{
    public override UserSubmissionChargebackConsumerCanceledServicesServiceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "guaranteed_reservation" =>
                UserSubmissionChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
            "other" => UserSubmissionChargebackConsumerCanceledServicesServiceType.Other,
            "timeshare" => UserSubmissionChargebackConsumerCanceledServicesServiceType.Timeshare,
            _ => (UserSubmissionChargebackConsumerCanceledServicesServiceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerCanceledServicesServiceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerCanceledServicesServiceType.GuaranteedReservation =>
                    "guaranteed_reservation",
                UserSubmissionChargebackConsumerCanceledServicesServiceType.Other => "other",
                UserSubmissionChargebackConsumerCanceledServicesServiceType.Timeshare =>
                    "timeshare",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Timeshare explanation. Present if and only if `service_type` is `timeshare`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerCanceledServicesTimeshare,
        UserSubmissionChargebackConsumerCanceledServicesTimeshareFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerCanceledServicesTimeshare : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public UserSubmissionChargebackConsumerCanceledServicesTimeshare() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerCanceledServicesTimeshare(
        UserSubmissionChargebackConsumerCanceledServicesTimeshare userSubmissionChargebackConsumerCanceledServicesTimeshare
    )
        : base(userSubmissionChargebackConsumerCanceledServicesTimeshare) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerCanceledServicesTimeshare(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerCanceledServicesTimeshare(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerCanceledServicesTimeshareFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerCanceledServicesTimeshare FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerCanceledServicesTimeshareFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerCanceledServicesTimeshare>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerCanceledServicesTimeshare FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerCanceledServicesTimeshare.FromRawUnchecked(rawData);
}

/// <summary>
/// Counterfeit merchandise. Present if and only if `category` is `consumer_counterfeit_merchandise`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerCounterfeitMerchandise,
        UserSubmissionChargebackConsumerCounterfeitMerchandiseFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerCounterfeitMerchandise : JsonModel
{
    /// <summary>
    /// Counterfeit explanation.
    /// </summary>
    public required string CounterfeitExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("counterfeit_explanation");
        }
        init { this._rawData.Set("counterfeit_explanation", value); }
    }

    /// <summary>
    /// Disposition explanation.
    /// </summary>
    public required string DispositionExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("disposition_explanation");
        }
        init { this._rawData.Set("disposition_explanation", value); }
    }

    /// <summary>
    /// Order explanation.
    /// </summary>
    public required string OrderExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("order_explanation");
        }
        init { this._rawData.Set("order_explanation", value); }
    }

    /// <summary>
    /// Received at.
    /// </summary>
    public required string ReceivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("received_at");
        }
        init { this._rawData.Set("received_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CounterfeitExplanation;
        _ = this.DispositionExplanation;
        _ = this.OrderExplanation;
        _ = this.ReceivedAt;
    }

    public UserSubmissionChargebackConsumerCounterfeitMerchandise() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerCounterfeitMerchandise(
        UserSubmissionChargebackConsumerCounterfeitMerchandise userSubmissionChargebackConsumerCounterfeitMerchandise
    )
        : base(userSubmissionChargebackConsumerCounterfeitMerchandise) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerCounterfeitMerchandise(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerCounterfeitMerchandise(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerCounterfeitMerchandiseFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerCounterfeitMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerCounterfeitMerchandiseFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerCounterfeitMerchandise>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerCounterfeitMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerCounterfeitMerchandise.FromRawUnchecked(rawData);
}

/// <summary>
/// Credit not processed. Present if and only if `category` is `consumer_credit_not_processed`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerCreditNotProcessed,
        UserSubmissionChargebackConsumerCreditNotProcessedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerCreditNotProcessed : JsonModel
{
    /// <summary>
    /// Canceled or returned at.
    /// </summary>
    public required string? CanceledOrReturnedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("canceled_or_returned_at");
        }
        init { this._rawData.Set("canceled_or_returned_at", value); }
    }

    /// <summary>
    /// Credit expected at.
    /// </summary>
    public required string? CreditExpectedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("credit_expected_at");
        }
        init { this._rawData.Set("credit_expected_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanceledOrReturnedAt;
        _ = this.CreditExpectedAt;
    }

    public UserSubmissionChargebackConsumerCreditNotProcessed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerCreditNotProcessed(
        UserSubmissionChargebackConsumerCreditNotProcessed userSubmissionChargebackConsumerCreditNotProcessed
    )
        : base(userSubmissionChargebackConsumerCreditNotProcessed) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerCreditNotProcessed(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerCreditNotProcessed(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerCreditNotProcessedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerCreditNotProcessed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerCreditNotProcessedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerCreditNotProcessed>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerCreditNotProcessed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerCreditNotProcessed.FromRawUnchecked(rawData);
}

/// <summary>
/// Damaged or defective merchandise. Present if and only if `category` is `consumer_damaged_or_defective_merchandise`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandise,
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandise : JsonModel
{
    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
                >
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
    }

    /// <summary>
    /// Not returned. Present if and only if `return_outcome` is `not_returned`.
    /// </summary>
    public required UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned? NotReturned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned>(
                "not_returned"
            );
        }
        init { this._rawData.Set("not_returned", value); }
    }

    /// <summary>
    /// Order and issue explanation.
    /// </summary>
    public required string OrderAndIssueExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("order_and_issue_explanation");
        }
        init { this._rawData.Set("order_and_issue_explanation", value); }
    }

    /// <summary>
    /// Received at.
    /// </summary>
    public required string ReceivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("received_at");
        }
        init { this._rawData.Set("received_at", value); }
    }

    /// <summary>
    /// Return attempted. Present if and only if `return_outcome` is `return_attempted`.
    /// </summary>
    public required UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted>(
                "return_attempted"
            );
        }
        init { this._rawData.Set("return_attempted", value); }
    }

    /// <summary>
    /// Return outcome.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome
    > ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome
                >
            >("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Returned. Present if and only if `return_outcome` is `returned`.
    /// </summary>
    public required UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturned>(
                "returned"
            );
        }
        init { this._rawData.Set("returned", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MerchantResolutionAttempted.Validate();
        this.NotReturned?.Validate();
        _ = this.OrderAndIssueExplanation;
        _ = this.ReceivedAt;
        this.ReturnAttempted?.Validate();
        this.ReturnOutcome.Validate();
        this.Returned?.Validate();
    }

    public UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandise() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandise(
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandise userSubmissionChargebackConsumerDamagedOrDefectiveMerchandise
    )
        : base(userSubmissionChargebackConsumerDamagedOrDefectiveMerchandise) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandise(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandise(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandise>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandise.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttemptedConverter)
)]
public enum UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
{
    /// <summary>
    /// Attempted.
    /// </summary>
    Attempted,

    /// <summary>
    /// Prohibited by local law.
    /// </summary>
    ProhibitedByLocalLaw,
}

sealed class UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttemptedConverter
    : JsonConverter<UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted>
{
    public override UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ =>
                (UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted =>
                    "attempted",
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw =>
                    "prohibited_by_local_law",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Not returned. Present if and only if `return_outcome` is `not_returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned,
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturnedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned
    : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned(
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned userSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned
    )
        : base(userSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturnedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturnedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Return attempted. Present if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted,
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted
    : JsonModel
{
    /// <summary>
    /// Attempt explanation.
    /// </summary>
    public required string AttemptExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("attempt_explanation");
        }
        init { this._rawData.Set("attempt_explanation", value); }
    }

    /// <summary>
    /// Attempt reason.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
    > AttemptReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
                >
            >("attempt_reason");
        }
        init { this._rawData.Set("attempt_reason", value); }
    }

    /// <summary>
    /// Attempted at.
    /// </summary>
    public required string AttemptedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("attempted_at");
        }
        init { this._rawData.Set("attempted_at", value); }
    }

    /// <summary>
    /// Merchandise disposition.
    /// </summary>
    public required string MerchandiseDisposition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchandise_disposition");
        }
        init { this._rawData.Set("merchandise_disposition", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AttemptExplanation;
        this.AttemptReason.Validate();
        _ = this.AttemptedAt;
        _ = this.MerchandiseDisposition;
    }

    public UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted(
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted userSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted
    )
        : base(userSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Attempt reason.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReasonConverter)
)]
public enum UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
{
    /// <summary>
    /// Merchant not responding.
    /// </summary>
    MerchantNotResponding,

    /// <summary>
    /// No return authorization provided.
    /// </summary>
    NoReturnAuthorizationProvided,

    /// <summary>
    /// No return instructions.
    /// </summary>
    NoReturnInstructions,

    /// <summary>
    /// Requested not to return.
    /// </summary>
    RequestedNotToReturn,

    /// <summary>
    /// Return not accepted.
    /// </summary>
    ReturnNotAccepted,
}

sealed class UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReasonConverter
    : JsonConverter<UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason>
{
    public override UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merchant_not_responding" =>
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            "no_return_authorization_provided" =>
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided,
            "no_return_instructions" =>
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions,
            "requested_not_to_return" =>
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn,
            "return_not_accepted" =>
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted,
            _ =>
                (UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding =>
                    "merchant_not_responding",
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided =>
                    "no_return_authorization_provided",
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions =>
                    "no_return_instructions",
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn =>
                    "requested_not_to_return",
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted =>
                    "return_not_accepted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Return outcome.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcomeConverter)
)]
public enum UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome
{
    /// <summary>
    /// Not returned.
    /// </summary>
    NotReturned,

    /// <summary>
    /// Returned.
    /// </summary>
    Returned,

    /// <summary>
    /// Return attempted.
    /// </summary>
    ReturnAttempted,
}

sealed class UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcomeConverter
    : JsonConverter<UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome>
{
    public override UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_returned" =>
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
            "returned" =>
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.Returned,
            "return_attempted" =>
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.ReturnAttempted,
            _ => (UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned =>
                    "not_returned",
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.Returned =>
                    "returned",
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.ReturnAttempted =>
                    "return_attempted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Returned. Present if and only if `return_outcome` is `returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturned,
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturned
    : JsonModel
{
    /// <summary>
    /// Merchant received return at.
    /// </summary>
    public required string? MerchantReceivedReturnAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_received_return_at");
        }
        init { this._rawData.Set("merchant_received_return_at", value); }
    }

    /// <summary>
    /// Other explanation. Required if and only if the return method is `other`.
    /// </summary>
    public required string? OtherExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("other_explanation");
        }
        init { this._rawData.Set("other_explanation", value); }
    }

    /// <summary>
    /// Return method.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod
    > ReturnMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod
                >
            >("return_method");
        }
        init { this._rawData.Set("return_method", value); }
    }

    /// <summary>
    /// Returned at.
    /// </summary>
    public required string ReturnedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("returned_at");
        }
        init { this._rawData.Set("returned_at", value); }
    }

    /// <summary>
    /// Tracking number.
    /// </summary>
    public required string? TrackingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tracking_number");
        }
        init { this._rawData.Set("tracking_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MerchantReceivedReturnAt;
        _ = this.OtherExplanation;
        this.ReturnMethod.Validate();
        _ = this.ReturnedAt;
        _ = this.TrackingNumber;
    }

    public UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturned(
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturned userSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturned
    )
        : base(userSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturned) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturned>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturned.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Return method.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethodConverter)
)]
public enum UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod
{
    /// <summary>
    /// DHL.
    /// </summary>
    Dhl,

    /// <summary>
    /// Face-to-face.
    /// </summary>
    FaceToFace,

    /// <summary>
    /// FedEx.
    /// </summary>
    Fedex,

    /// <summary>
    /// Other.
    /// </summary>
    Other,

    /// <summary>
    /// Postal service.
    /// </summary>
    PostalService,

    /// <summary>
    /// UPS.
    /// </summary>
    Ups,
}

sealed class UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethodConverter
    : JsonConverter<UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod>
{
    public override UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dhl" =>
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            "face_to_face" =>
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.FaceToFace,
            "fedex" =>
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Fedex,
            "other" =>
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Other,
            "postal_service" =>
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.PostalService,
            "ups" =>
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Ups,
            _ =>
                (UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl =>
                    "dhl",
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.FaceToFace =>
                    "face_to_face",
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Fedex =>
                    "fedex",
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Other =>
                    "other",
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.PostalService =>
                    "postal_service",
                UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Ups =>
                    "ups",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Merchandise misrepresentation. Present if and only if `category` is `consumer_merchandise_misrepresentation`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerMerchandiseMisrepresentation,
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerMerchandiseMisrepresentation : JsonModel
{
    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
                >
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
    }

    /// <summary>
    /// Misrepresentation explanation.
    /// </summary>
    public required string MisrepresentationExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("misrepresentation_explanation");
        }
        init { this._rawData.Set("misrepresentation_explanation", value); }
    }

    /// <summary>
    /// Not returned. Present if and only if `return_outcome` is `not_returned`.
    /// </summary>
    public required UserSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturned? NotReturned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturned>(
                "not_returned"
            );
        }
        init { this._rawData.Set("not_returned", value); }
    }

    /// <summary>
    /// Purchase explanation.
    /// </summary>
    public required string PurchaseExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("purchase_explanation");
        }
        init { this._rawData.Set("purchase_explanation", value); }
    }

    /// <summary>
    /// Received at.
    /// </summary>
    public required string ReceivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("received_at");
        }
        init { this._rawData.Set("received_at", value); }
    }

    /// <summary>
    /// Return attempted. Present if and only if `return_outcome` is `return_attempted`.
    /// </summary>
    public required UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttempted>(
                "return_attempted"
            );
        }
        init { this._rawData.Set("return_attempted", value); }
    }

    /// <summary>
    /// Return outcome.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome
    > ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome
                >
            >("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Returned. Present if and only if `return_outcome` is `returned`.
    /// </summary>
    public required UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturned>(
                "returned"
            );
        }
        init { this._rawData.Set("returned", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MerchantResolutionAttempted.Validate();
        _ = this.MisrepresentationExplanation;
        this.NotReturned?.Validate();
        _ = this.PurchaseExplanation;
        _ = this.ReceivedAt;
        this.ReturnAttempted?.Validate();
        this.ReturnOutcome.Validate();
        this.Returned?.Validate();
    }

    public UserSubmissionChargebackConsumerMerchandiseMisrepresentation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseMisrepresentation(
        UserSubmissionChargebackConsumerMerchandiseMisrepresentation userSubmissionChargebackConsumerMerchandiseMisrepresentation
    )
        : base(userSubmissionChargebackConsumerMerchandiseMisrepresentation) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerMerchandiseMisrepresentation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerMerchandiseMisrepresentation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerMerchandiseMisrepresentationFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerMerchandiseMisrepresentation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerMerchandiseMisrepresentationFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerMerchandiseMisrepresentation>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerMerchandiseMisrepresentation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerMerchandiseMisrepresentation.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttemptedConverter)
)]
public enum UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
{
    /// <summary>
    /// Attempted.
    /// </summary>
    Attempted,

    /// <summary>
    /// Prohibited by local law.
    /// </summary>
    ProhibitedByLocalLaw,
}

sealed class UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttemptedConverter
    : JsonConverter<UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted>
{
    public override UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ =>
                (UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted =>
                    "attempted",
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw =>
                    "prohibited_by_local_law",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Not returned. Present if and only if `return_outcome` is `not_returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturned,
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturnedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturned
    : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public UserSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturned(
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturned userSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturned
    )
        : base(userSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturned) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturnedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturnedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturned>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationNotReturned.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Return attempted. Present if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttempted,
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttempted
    : JsonModel
{
    /// <summary>
    /// Attempt explanation.
    /// </summary>
    public required string AttemptExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("attempt_explanation");
        }
        init { this._rawData.Set("attempt_explanation", value); }
    }

    /// <summary>
    /// Attempt reason.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
    > AttemptReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
                >
            >("attempt_reason");
        }
        init { this._rawData.Set("attempt_reason", value); }
    }

    /// <summary>
    /// Attempted at.
    /// </summary>
    public required string AttemptedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("attempted_at");
        }
        init { this._rawData.Set("attempted_at", value); }
    }

    /// <summary>
    /// Merchandise disposition.
    /// </summary>
    public required string MerchandiseDisposition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchandise_disposition");
        }
        init { this._rawData.Set("merchandise_disposition", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AttemptExplanation;
        this.AttemptReason.Validate();
        _ = this.AttemptedAt;
        _ = this.MerchandiseDisposition;
    }

    public UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttempted(
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttempted userSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttempted
    )
        : base(userSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttempted) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttempted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttempted(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttempted>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttempted.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Attempt reason.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReasonConverter)
)]
public enum UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
{
    /// <summary>
    /// Merchant not responding.
    /// </summary>
    MerchantNotResponding,

    /// <summary>
    /// No return authorization provided.
    /// </summary>
    NoReturnAuthorizationProvided,

    /// <summary>
    /// No return instructions.
    /// </summary>
    NoReturnInstructions,

    /// <summary>
    /// Requested not to return.
    /// </summary>
    RequestedNotToReturn,

    /// <summary>
    /// Return not accepted.
    /// </summary>
    ReturnNotAccepted,
}

sealed class UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReasonConverter
    : JsonConverter<UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason>
{
    public override UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merchant_not_responding" =>
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
            "no_return_authorization_provided" =>
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnAuthorizationProvided,
            "no_return_instructions" =>
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnInstructions,
            "requested_not_to_return" =>
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.RequestedNotToReturn,
            "return_not_accepted" =>
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.ReturnNotAccepted,
            _ =>
                (UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding =>
                    "merchant_not_responding",
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnAuthorizationProvided =>
                    "no_return_authorization_provided",
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnInstructions =>
                    "no_return_instructions",
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.RequestedNotToReturn =>
                    "requested_not_to_return",
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.ReturnNotAccepted =>
                    "return_not_accepted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Return outcome.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcomeConverter)
)]
public enum UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome
{
    /// <summary>
    /// Not returned.
    /// </summary>
    NotReturned,

    /// <summary>
    /// Returned.
    /// </summary>
    Returned,

    /// <summary>
    /// Return attempted.
    /// </summary>
    ReturnAttempted,
}

sealed class UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcomeConverter
    : JsonConverter<UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome>
{
    public override UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_returned" =>
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
            "returned" =>
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome.Returned,
            "return_attempted" =>
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome.ReturnAttempted,
            _ => (UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned =>
                    "not_returned",
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome.Returned =>
                    "returned",
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome.ReturnAttempted =>
                    "return_attempted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Returned. Present if and only if `return_outcome` is `returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturned,
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturned
    : JsonModel
{
    /// <summary>
    /// Merchant received return at.
    /// </summary>
    public required string? MerchantReceivedReturnAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_received_return_at");
        }
        init { this._rawData.Set("merchant_received_return_at", value); }
    }

    /// <summary>
    /// Other explanation. Required if and only if the return method is `other`.
    /// </summary>
    public required string? OtherExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("other_explanation");
        }
        init { this._rawData.Set("other_explanation", value); }
    }

    /// <summary>
    /// Return method.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod
    > ReturnMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod
                >
            >("return_method");
        }
        init { this._rawData.Set("return_method", value); }
    }

    /// <summary>
    /// Returned at.
    /// </summary>
    public required string ReturnedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("returned_at");
        }
        init { this._rawData.Set("returned_at", value); }
    }

    /// <summary>
    /// Tracking number.
    /// </summary>
    public required string? TrackingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tracking_number");
        }
        init { this._rawData.Set("tracking_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MerchantReceivedReturnAt;
        _ = this.OtherExplanation;
        this.ReturnMethod.Validate();
        _ = this.ReturnedAt;
        _ = this.TrackingNumber;
    }

    public UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturned(
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturned userSubmissionChargebackConsumerMerchandiseMisrepresentationReturned
    )
        : base(userSubmissionChargebackConsumerMerchandiseMisrepresentationReturned) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturned>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturned.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Return method.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethodConverter)
)]
public enum UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod
{
    /// <summary>
    /// DHL.
    /// </summary>
    Dhl,

    /// <summary>
    /// Face-to-face.
    /// </summary>
    FaceToFace,

    /// <summary>
    /// FedEx.
    /// </summary>
    Fedex,

    /// <summary>
    /// Other.
    /// </summary>
    Other,

    /// <summary>
    /// Postal service.
    /// </summary>
    PostalService,

    /// <summary>
    /// UPS.
    /// </summary>
    Ups,
}

sealed class UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethodConverter
    : JsonConverter<UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod>
{
    public override UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dhl" =>
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            "face_to_face" =>
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.FaceToFace,
            "fedex" =>
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Fedex,
            "other" =>
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Other,
            "postal_service" =>
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.PostalService,
            "ups" =>
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Ups,
            _ => (UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl =>
                    "dhl",
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.FaceToFace =>
                    "face_to_face",
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Fedex =>
                    "fedex",
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Other =>
                    "other",
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.PostalService =>
                    "postal_service",
                UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Ups =>
                    "ups",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Merchandise not as described. Present if and only if `category` is `consumer_merchandise_not_as_described`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribed,
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerMerchandiseNotAsDescribed : JsonModel
{
    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
                >
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
    }

    /// <summary>
    /// Received at.
    /// </summary>
    public required string ReceivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("received_at");
        }
        init { this._rawData.Set("received_at", value); }
    }

    /// <summary>
    /// Return attempted. Present if and only if `return_outcome` is `return_attempted`.
    /// </summary>
    public required UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttempted>(
                "return_attempted"
            );
        }
        init { this._rawData.Set("return_attempted", value); }
    }

    /// <summary>
    /// Return outcome.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome
    > ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome
                >
            >("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Returned. Present if and only if `return_outcome` is `returned`.
    /// </summary>
    public required UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturned>(
                "returned"
            );
        }
        init { this._rawData.Set("returned", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MerchantResolutionAttempted.Validate();
        _ = this.ReceivedAt;
        this.ReturnAttempted?.Validate();
        this.ReturnOutcome.Validate();
        this.Returned?.Validate();
    }

    public UserSubmissionChargebackConsumerMerchandiseNotAsDescribed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseNotAsDescribed(
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribed userSubmissionChargebackConsumerMerchandiseNotAsDescribed
    )
        : base(userSubmissionChargebackConsumerMerchandiseNotAsDescribed) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerMerchandiseNotAsDescribed(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerMerchandiseNotAsDescribed(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerMerchandiseNotAsDescribedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerMerchandiseNotAsDescribed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerMerchandiseNotAsDescribedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerMerchandiseNotAsDescribed>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerMerchandiseNotAsDescribed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerMerchandiseNotAsDescribed.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttemptedConverter)
)]
public enum UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
{
    /// <summary>
    /// Attempted.
    /// </summary>
    Attempted,

    /// <summary>
    /// Prohibited by local law.
    /// </summary>
    ProhibitedByLocalLaw,
}

sealed class UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttemptedConverter
    : JsonConverter<UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted>
{
    public override UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ =>
                (UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted =>
                    "attempted",
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw =>
                    "prohibited_by_local_law",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Return attempted. Present if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttempted,
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttempted
    : JsonModel
{
    /// <summary>
    /// Attempt explanation.
    /// </summary>
    public required string AttemptExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("attempt_explanation");
        }
        init { this._rawData.Set("attempt_explanation", value); }
    }

    /// <summary>
    /// Attempt reason.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
    > AttemptReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
                >
            >("attempt_reason");
        }
        init { this._rawData.Set("attempt_reason", value); }
    }

    /// <summary>
    /// Attempted at.
    /// </summary>
    public required string AttemptedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("attempted_at");
        }
        init { this._rawData.Set("attempted_at", value); }
    }

    /// <summary>
    /// Merchandise disposition.
    /// </summary>
    public required string MerchandiseDisposition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchandise_disposition");
        }
        init { this._rawData.Set("merchandise_disposition", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AttemptExplanation;
        this.AttemptReason.Validate();
        _ = this.AttemptedAt;
        _ = this.MerchandiseDisposition;
    }

    public UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttempted(
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttempted userSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttempted
    )
        : base(userSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttempted) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttempted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttempted(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttempted>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttempted.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Attempt reason.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReasonConverter)
)]
public enum UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
{
    /// <summary>
    /// Merchant not responding.
    /// </summary>
    MerchantNotResponding,

    /// <summary>
    /// No return authorization provided.
    /// </summary>
    NoReturnAuthorizationProvided,

    /// <summary>
    /// No return instructions.
    /// </summary>
    NoReturnInstructions,

    /// <summary>
    /// Requested not to return.
    /// </summary>
    RequestedNotToReturn,

    /// <summary>
    /// Return not accepted.
    /// </summary>
    ReturnNotAccepted,
}

sealed class UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReasonConverter
    : JsonConverter<UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason>
{
    public override UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merchant_not_responding" =>
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            "no_return_authorization_provided" =>
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnAuthorizationProvided,
            "no_return_instructions" =>
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnInstructions,
            "requested_not_to_return" =>
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.RequestedNotToReturn,
            "return_not_accepted" =>
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.ReturnNotAccepted,
            _ =>
                (UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding =>
                    "merchant_not_responding",
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnAuthorizationProvided =>
                    "no_return_authorization_provided",
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnInstructions =>
                    "no_return_instructions",
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.RequestedNotToReturn =>
                    "requested_not_to_return",
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.ReturnNotAccepted =>
                    "return_not_accepted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Return outcome.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcomeConverter)
)]
public enum UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome
{
    /// <summary>
    /// Returned.
    /// </summary>
    Returned,

    /// <summary>
    /// Return attempted.
    /// </summary>
    ReturnAttempted,
}

sealed class UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcomeConverter
    : JsonConverter<UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome>
{
    public override UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "returned" =>
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
            "return_attempted" =>
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.ReturnAttempted,
            _ => (UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned =>
                    "returned",
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.ReturnAttempted =>
                    "return_attempted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Returned. Present if and only if `return_outcome` is `returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturned,
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturned
    : JsonModel
{
    /// <summary>
    /// Merchant received return at.
    /// </summary>
    public required string? MerchantReceivedReturnAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_received_return_at");
        }
        init { this._rawData.Set("merchant_received_return_at", value); }
    }

    /// <summary>
    /// Other explanation. Required if and only if the return method is `other`.
    /// </summary>
    public required string? OtherExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("other_explanation");
        }
        init { this._rawData.Set("other_explanation", value); }
    }

    /// <summary>
    /// Return method.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod
    > ReturnMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod
                >
            >("return_method");
        }
        init { this._rawData.Set("return_method", value); }
    }

    /// <summary>
    /// Returned at.
    /// </summary>
    public required string ReturnedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("returned_at");
        }
        init { this._rawData.Set("returned_at", value); }
    }

    /// <summary>
    /// Tracking number.
    /// </summary>
    public required string? TrackingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tracking_number");
        }
        init { this._rawData.Set("tracking_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MerchantReceivedReturnAt;
        _ = this.OtherExplanation;
        this.ReturnMethod.Validate();
        _ = this.ReturnedAt;
        _ = this.TrackingNumber;
    }

    public UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturned(
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturned userSubmissionChargebackConsumerMerchandiseNotAsDescribedReturned
    )
        : base(userSubmissionChargebackConsumerMerchandiseNotAsDescribedReturned) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturned>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return method.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethodConverter)
)]
public enum UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod
{
    /// <summary>
    /// DHL.
    /// </summary>
    Dhl,

    /// <summary>
    /// Face-to-face.
    /// </summary>
    FaceToFace,

    /// <summary>
    /// FedEx.
    /// </summary>
    Fedex,

    /// <summary>
    /// Other.
    /// </summary>
    Other,

    /// <summary>
    /// Postal service.
    /// </summary>
    PostalService,

    /// <summary>
    /// UPS.
    /// </summary>
    Ups,
}

sealed class UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethodConverter
    : JsonConverter<UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod>
{
    public override UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dhl" =>
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            "face_to_face" =>
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.FaceToFace,
            "fedex" =>
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Fedex,
            "other" =>
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Other,
            "postal_service" =>
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.PostalService,
            "ups" =>
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Ups,
            _ => (UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl =>
                    "dhl",
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.FaceToFace =>
                    "face_to_face",
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Fedex =>
                    "fedex",
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Other =>
                    "other",
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.PostalService =>
                    "postal_service",
                UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Ups =>
                    "ups",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Merchandise not received. Present if and only if `category` is `consumer_merchandise_not_received`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerMerchandiseNotReceived,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerMerchandiseNotReceived : JsonModel
{
    /// <summary>
    /// Cancellation outcome.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome
    > CancellationOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome
                >
            >("cancellation_outcome");
        }
        init { this._rawData.Set("cancellation_outcome", value); }
    }

    /// <summary>
    /// Cardholder cancellation prior to expected receipt. Present if and only if
    /// `cancellation_outcome` is `cardholder_cancellation_prior_to_expected_receipt`.
    /// </summary>
    public required UserSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt? CardholderCancellationPriorToExpectedReceipt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt>(
                "cardholder_cancellation_prior_to_expected_receipt"
            );
        }
        init { this._rawData.Set("cardholder_cancellation_prior_to_expected_receipt", value); }
    }

    /// <summary>
    /// Delayed. Present if and only if `delivery_issue` is `delayed`.
    /// </summary>
    public required UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayed? Delayed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayed>(
                "delayed"
            );
        }
        init { this._rawData.Set("delayed", value); }
    }

    /// <summary>
    /// Delivered to wrong location. Present if and only if `delivery_issue` is `delivered_to_wrong_location`.
    /// </summary>
    public required UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation? DeliveredToWrongLocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation>(
                "delivered_to_wrong_location"
            );
        }
        init { this._rawData.Set("delivered_to_wrong_location", value); }
    }

    /// <summary>
    /// Delivery issue.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue
    > DeliveryIssue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue>
            >("delivery_issue");
        }
        init { this._rawData.Set("delivery_issue", value); }
    }

    /// <summary>
    /// Last expected receipt at.
    /// </summary>
    public required string LastExpectedReceiptAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("last_expected_receipt_at");
        }
        init { this._rawData.Set("last_expected_receipt_at", value); }
    }

    /// <summary>
    /// Merchant cancellation. Present if and only if `cancellation_outcome` is `merchant_cancellation`.
    /// </summary>
    public required UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellation? MerchantCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellation>(
                "merchant_cancellation"
            );
        }
        init { this._rawData.Set("merchant_cancellation", value); }
    }

    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted
                >
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
    }

    /// <summary>
    /// No cancellation. Present if and only if `cancellation_outcome` is `no_cancellation`.
    /// </summary>
    public required UserSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellation? NoCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellation>(
                "no_cancellation"
            );
        }
        init { this._rawData.Set("no_cancellation", value); }
    }

    /// <summary>
    /// Purchase information and explanation.
    /// </summary>
    public required string PurchaseInfoAndExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("purchase_info_and_explanation");
        }
        init { this._rawData.Set("purchase_info_and_explanation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CancellationOutcome.Validate();
        this.CardholderCancellationPriorToExpectedReceipt?.Validate();
        this.Delayed?.Validate();
        this.DeliveredToWrongLocation?.Validate();
        this.DeliveryIssue.Validate();
        _ = this.LastExpectedReceiptAt;
        this.MerchantCancellation?.Validate();
        this.MerchantResolutionAttempted.Validate();
        this.NoCancellation?.Validate();
        _ = this.PurchaseInfoAndExplanation;
    }

    public UserSubmissionChargebackConsumerMerchandiseNotReceived() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseNotReceived(
        UserSubmissionChargebackConsumerMerchandiseNotReceived userSubmissionChargebackConsumerMerchandiseNotReceived
    )
        : base(userSubmissionChargebackConsumerMerchandiseNotReceived) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerMerchandiseNotReceived(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerMerchandiseNotReceived(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerMerchandiseNotReceivedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerMerchandiseNotReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerMerchandiseNotReceivedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerMerchandiseNotReceived>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerMerchandiseNotReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerMerchandiseNotReceived.FromRawUnchecked(rawData);
}

/// <summary>
/// Cancellation outcome.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcomeConverter)
)]
public enum UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome
{
    /// <summary>
    /// Cardholder cancellation prior to expected receipt.
    /// </summary>
    CardholderCancellationPriorToExpectedReceipt,

    /// <summary>
    /// Merchant cancellation.
    /// </summary>
    MerchantCancellation,

    /// <summary>
    /// No cancellation.
    /// </summary>
    NoCancellation,
}

sealed class UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcomeConverter
    : JsonConverter<UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome>
{
    public override UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cardholder_cancellation_prior_to_expected_receipt" =>
                UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            "merchant_cancellation" =>
                UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome.MerchantCancellation,
            "no_cancellation" =>
                UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome.NoCancellation,
            _ => (UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt =>
                    "cardholder_cancellation_prior_to_expected_receipt",
                UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome.MerchantCancellation =>
                    "merchant_cancellation",
                UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome.NoCancellation =>
                    "no_cancellation",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Cardholder cancellation prior to expected receipt. Present if and only if `cancellation_outcome`
/// is `cardholder_cancellation_prior_to_expected_receipt`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceiptFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt
    : JsonModel
{
    /// <summary>
    /// Canceled at.
    /// </summary>
    public required string CanceledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("canceled_at");
        }
        init { this._rawData.Set("canceled_at", value); }
    }

    /// <summary>
    /// Reason.
    /// </summary>
    public required string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanceledAt;
        _ = this.Reason;
    }

    public UserSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt()
    { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt(
        UserSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt userSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt
    )
        : base(
            userSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt
        ) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceiptFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceiptFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Delayed. Present if and only if `delivery_issue` is `delayed`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayed,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayed : JsonModel
{
    /// <summary>
    /// Explanation.
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
    /// Not returned. Present if and only if `return_outcome` is `not_returned`.
    /// </summary>
    public required UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturned? NotReturned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturned>(
                "not_returned"
            );
        }
        init { this._rawData.Set("not_returned", value); }
    }

    /// <summary>
    /// Return attempted. Present if and only if `return_outcome` is `return_attempted`.
    /// </summary>
    public required UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted>(
                "return_attempted"
            );
        }
        init { this._rawData.Set("return_attempted", value); }
    }

    /// <summary>
    /// Return outcome.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome
    > ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome
                >
            >("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Returned. Present if and only if `return_outcome` is `returned`.
    /// </summary>
    public required UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturned>(
                "returned"
            );
        }
        init { this._rawData.Set("returned", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Explanation;
        this.NotReturned?.Validate();
        this.ReturnAttempted?.Validate();
        this.ReturnOutcome.Validate();
        this.Returned?.Validate();
    }

    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayed(
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayed userSubmissionChargebackConsumerMerchandiseNotReceivedDelayed
    )
        : base(userSubmissionChargebackConsumerMerchandiseNotReceivedDelayed) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayed(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayed(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayed>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayed.FromRawUnchecked(rawData);
}

/// <summary>
/// Not returned. Present if and only if `return_outcome` is `not_returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturned,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturnedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturned
    : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturned(
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturned userSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturned
    )
        : base(userSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturned) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturnedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturnedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturned>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedNotReturned.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Return attempted. Present if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttemptedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted
    : JsonModel
{
    /// <summary>
    /// Attempted at.
    /// </summary>
    public required string AttemptedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("attempted_at");
        }
        init { this._rawData.Set("attempted_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AttemptedAt;
    }

    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted(
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted userSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted
    )
        : base(userSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted(
        string attemptedAt
    )
        : this()
    {
        this.AttemptedAt = attemptedAt;
    }
}

class UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttemptedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Return outcome.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcomeConverter)
)]
public enum UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome
{
    /// <summary>
    /// Not returned.
    /// </summary>
    NotReturned,

    /// <summary>
    /// Returned.
    /// </summary>
    Returned,

    /// <summary>
    /// Return attempted.
    /// </summary>
    ReturnAttempted,
}

sealed class UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcomeConverter
    : JsonConverter<UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome>
{
    public override UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_returned" =>
                UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
            "returned" =>
                UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.Returned,
            "return_attempted" =>
                UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.ReturnAttempted,
            _ => (UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned =>
                    "not_returned",
                UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.Returned =>
                    "returned",
                UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.ReturnAttempted =>
                    "return_attempted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Returned. Present if and only if `return_outcome` is `returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturned,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturned
    : JsonModel
{
    /// <summary>
    /// Merchant received return at.
    /// </summary>
    public required string MerchantReceivedReturnAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_received_return_at");
        }
        init { this._rawData.Set("merchant_received_return_at", value); }
    }

    /// <summary>
    /// Returned at.
    /// </summary>
    public required string ReturnedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("returned_at");
        }
        init { this._rawData.Set("returned_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MerchantReceivedReturnAt;
        _ = this.ReturnedAt;
    }

    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturned(
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturned userSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturned
    )
        : base(userSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturned) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturned>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturned.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Delivered to wrong location. Present if and only if `delivery_issue` is `delivered_to_wrong_location`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocationFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation
    : JsonModel
{
    /// <summary>
    /// Agreed location.
    /// </summary>
    public required string AgreedLocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("agreed_location");
        }
        init { this._rawData.Set("agreed_location", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AgreedLocation;
    }

    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation(
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation userSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation
    )
        : base(userSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocationFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation(
        string agreedLocation
    )
        : this()
    {
        this.AgreedLocation = agreedLocation;
    }
}

class UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocationFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Delivery issue.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssueConverter)
)]
public enum UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue
{
    /// <summary>
    /// Delayed.
    /// </summary>
    Delayed,

    /// <summary>
    /// Delivered to wrong location.
    /// </summary>
    DeliveredToWrongLocation,
}

sealed class UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssueConverter
    : JsonConverter<UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue>
{
    public override UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "delayed" =>
                UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
            "delivered_to_wrong_location" =>
                UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue.DeliveredToWrongLocation,
            _ => (UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed =>
                    "delayed",
                UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue.DeliveredToWrongLocation =>
                    "delivered_to_wrong_location",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Merchant cancellation. Present if and only if `cancellation_outcome` is `merchant_cancellation`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellation,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellationFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellation
    : JsonModel
{
    /// <summary>
    /// Canceled at.
    /// </summary>
    public required string CanceledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("canceled_at");
        }
        init { this._rawData.Set("canceled_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanceledAt;
    }

    public UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellation(
        UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellation userSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellation
    )
        : base(userSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellation) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellationFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellation(
        string canceledAt
    )
        : this()
    {
        this.CanceledAt = canceledAt;
    }
}

class UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellationFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellation>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantCancellation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttemptedConverter)
)]
public enum UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted
{
    /// <summary>
    /// Attempted.
    /// </summary>
    Attempted,

    /// <summary>
    /// Prohibited by local law.
    /// </summary>
    ProhibitedByLocalLaw,
}

sealed class UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttemptedConverter
    : JsonConverter<UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted>
{
    public override UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ =>
                (UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted =>
                    "attempted",
                UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw =>
                    "prohibited_by_local_law",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// No cancellation. Present if and only if `cancellation_outcome` is `no_cancellation`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellation,
        UserSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellationFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellation
    : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public UserSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellation(
        UserSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellation userSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellation
    )
        : base(userSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellation) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellationFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellationFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellation>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerMerchandiseNotReceivedNoCancellation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Non-receipt of cash. Present if and only if `category` is `consumer_non_receipt_of_cash`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerNonReceiptOfCash,
        UserSubmissionChargebackConsumerNonReceiptOfCashFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerNonReceiptOfCash : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public UserSubmissionChargebackConsumerNonReceiptOfCash() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerNonReceiptOfCash(
        UserSubmissionChargebackConsumerNonReceiptOfCash userSubmissionChargebackConsumerNonReceiptOfCash
    )
        : base(userSubmissionChargebackConsumerNonReceiptOfCash) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerNonReceiptOfCash(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerNonReceiptOfCash(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerNonReceiptOfCashFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerNonReceiptOfCash FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerNonReceiptOfCashFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerNonReceiptOfCash>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerNonReceiptOfCash FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerNonReceiptOfCash.FromRawUnchecked(rawData);
}

/// <summary>
/// Original Credit Transaction (OCT) not accepted. Present if and only if `category`
/// is `consumer_original_credit_transaction_not_accepted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerOriginalCreditTransactionNotAccepted,
        UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerOriginalCreditTransactionNotAccepted
    : JsonModel
{
    /// <summary>
    /// Explanation.
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
    /// Reason.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason
    > Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason
                >
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Explanation;
        this.Reason.Validate();
    }

    public UserSubmissionChargebackConsumerOriginalCreditTransactionNotAccepted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerOriginalCreditTransactionNotAccepted(
        UserSubmissionChargebackConsumerOriginalCreditTransactionNotAccepted userSubmissionChargebackConsumerOriginalCreditTransactionNotAccepted
    )
        : base(userSubmissionChargebackConsumerOriginalCreditTransactionNotAccepted) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerOriginalCreditTransactionNotAccepted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerOriginalCreditTransactionNotAccepted(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerOriginalCreditTransactionNotAccepted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerOriginalCreditTransactionNotAccepted>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerOriginalCreditTransactionNotAccepted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerOriginalCreditTransactionNotAccepted.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reason.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReasonConverter)
)]
public enum UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason
{
    /// <summary>
    /// Prohibited by local laws or regulation.
    /// </summary>
    ProhibitedByLocalLawsOrRegulation,

    /// <summary>
    /// Recipient refused.
    /// </summary>
    RecipientRefused,
}

sealed class UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReasonConverter
    : JsonConverter<UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason>
{
    public override UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prohibited_by_local_laws_or_regulation" =>
                UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
            "recipient_refused" =>
                UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason.RecipientRefused,
            _ => (UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation =>
                    "prohibited_by_local_laws_or_regulation",
                UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason.RecipientRefused =>
                    "recipient_refused",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Merchandise quality issue. Present if and only if `category` is `consumer_quality_merchandise`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerQualityMerchandise,
        UserSubmissionChargebackConsumerQualityMerchandiseFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerQualityMerchandise : JsonModel
{
    /// <summary>
    /// Expected at.
    /// </summary>
    public required string ExpectedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expected_at");
        }
        init { this._rawData.Set("expected_at", value); }
    }

    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted
                >
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
    }

    /// <summary>
    /// Not returned. Present if and only if `return_outcome` is `not_returned`.
    /// </summary>
    public required UserSubmissionChargebackConsumerQualityMerchandiseNotReturned? NotReturned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerQualityMerchandiseNotReturned>(
                "not_returned"
            );
        }
        init { this._rawData.Set("not_returned", value); }
    }

    /// <summary>
    /// Ongoing negotiations. Exclude if there is no evidence of ongoing negotiations.
    /// </summary>
    public required UserSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiations? OngoingNegotiations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiations>(
                "ongoing_negotiations"
            );
        }
        init { this._rawData.Set("ongoing_negotiations", value); }
    }

    /// <summary>
    /// Purchase information and quality issue.
    /// </summary>
    public required string PurchaseInfoAndQualityIssue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("purchase_info_and_quality_issue");
        }
        init { this._rawData.Set("purchase_info_and_quality_issue", value); }
    }

    /// <summary>
    /// Received at.
    /// </summary>
    public required string ReceivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("received_at");
        }
        init { this._rawData.Set("received_at", value); }
    }

    /// <summary>
    /// Return attempted. Present if and only if `return_outcome` is `return_attempted`.
    /// </summary>
    public required UserSubmissionChargebackConsumerQualityMerchandiseReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerQualityMerchandiseReturnAttempted>(
                "return_attempted"
            );
        }
        init { this._rawData.Set("return_attempted", value); }
    }

    /// <summary>
    /// Return outcome.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome
    > ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome>
            >("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Returned. Present if and only if `return_outcome` is `returned`.
    /// </summary>
    public required UserSubmissionChargebackConsumerQualityMerchandiseReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerQualityMerchandiseReturned>(
                "returned"
            );
        }
        init { this._rawData.Set("returned", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpectedAt;
        this.MerchantResolutionAttempted.Validate();
        this.NotReturned?.Validate();
        this.OngoingNegotiations?.Validate();
        _ = this.PurchaseInfoAndQualityIssue;
        _ = this.ReceivedAt;
        this.ReturnAttempted?.Validate();
        this.ReturnOutcome.Validate();
        this.Returned?.Validate();
    }

    public UserSubmissionChargebackConsumerQualityMerchandise() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerQualityMerchandise(
        UserSubmissionChargebackConsumerQualityMerchandise userSubmissionChargebackConsumerQualityMerchandise
    )
        : base(userSubmissionChargebackConsumerQualityMerchandise) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerQualityMerchandise(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerQualityMerchandise(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerQualityMerchandiseFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerQualityMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerQualityMerchandiseFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerQualityMerchandise>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerQualityMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerQualityMerchandise.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttemptedConverter)
)]
public enum UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted
{
    /// <summary>
    /// Attempted.
    /// </summary>
    Attempted,

    /// <summary>
    /// Prohibited by local law.
    /// </summary>
    ProhibitedByLocalLaw,
}

sealed class UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttemptedConverter
    : JsonConverter<UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted>
{
    public override UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted =>
                    "attempted",
                UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw =>
                    "prohibited_by_local_law",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Not returned. Present if and only if `return_outcome` is `not_returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerQualityMerchandiseNotReturned,
        UserSubmissionChargebackConsumerQualityMerchandiseNotReturnedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerQualityMerchandiseNotReturned : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public UserSubmissionChargebackConsumerQualityMerchandiseNotReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerQualityMerchandiseNotReturned(
        UserSubmissionChargebackConsumerQualityMerchandiseNotReturned userSubmissionChargebackConsumerQualityMerchandiseNotReturned
    )
        : base(userSubmissionChargebackConsumerQualityMerchandiseNotReturned) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerQualityMerchandiseNotReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerQualityMerchandiseNotReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerQualityMerchandiseNotReturnedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerQualityMerchandiseNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerQualityMerchandiseNotReturnedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerQualityMerchandiseNotReturned>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerQualityMerchandiseNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerQualityMerchandiseNotReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Ongoing negotiations. Exclude if there is no evidence of ongoing negotiations.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiations,
        UserSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiationsFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiations
    : JsonModel
{
    /// <summary>
    /// Explanation of the previous ongoing negotiations between the cardholder and merchant.
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
    /// Date the cardholder first notified the issuer of the dispute.
    /// </summary>
    public required string IssuerFirstNotifiedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("issuer_first_notified_at");
        }
        init { this._rawData.Set("issuer_first_notified_at", value); }
    }

    /// <summary>
    /// Started at.
    /// </summary>
    public required string StartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("started_at");
        }
        init { this._rawData.Set("started_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Explanation;
        _ = this.IssuerFirstNotifiedAt;
        _ = this.StartedAt;
    }

    public UserSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiations() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiations(
        UserSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiations userSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiations
    )
        : base(userSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiations) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiations(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiations(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiationsFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiations FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiationsFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiations>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiations FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerQualityMerchandiseOngoingNegotiations.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Return attempted. Present if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerQualityMerchandiseReturnAttempted,
        UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerQualityMerchandiseReturnAttempted
    : JsonModel
{
    /// <summary>
    /// Attempt explanation.
    /// </summary>
    public required string AttemptExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("attempt_explanation");
        }
        init { this._rawData.Set("attempt_explanation", value); }
    }

    /// <summary>
    /// Attempt reason.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason
    > AttemptReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason
                >
            >("attempt_reason");
        }
        init { this._rawData.Set("attempt_reason", value); }
    }

    /// <summary>
    /// Attempted at.
    /// </summary>
    public required string AttemptedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("attempted_at");
        }
        init { this._rawData.Set("attempted_at", value); }
    }

    /// <summary>
    /// Merchandise disposition.
    /// </summary>
    public required string MerchandiseDisposition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchandise_disposition");
        }
        init { this._rawData.Set("merchandise_disposition", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AttemptExplanation;
        this.AttemptReason.Validate();
        _ = this.AttemptedAt;
        _ = this.MerchandiseDisposition;
    }

    public UserSubmissionChargebackConsumerQualityMerchandiseReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerQualityMerchandiseReturnAttempted(
        UserSubmissionChargebackConsumerQualityMerchandiseReturnAttempted userSubmissionChargebackConsumerQualityMerchandiseReturnAttempted
    )
        : base(userSubmissionChargebackConsumerQualityMerchandiseReturnAttempted) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerQualityMerchandiseReturnAttempted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerQualityMerchandiseReturnAttempted(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerQualityMerchandiseReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerQualityMerchandiseReturnAttempted>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerQualityMerchandiseReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerQualityMerchandiseReturnAttempted.FromRawUnchecked(rawData);
}

/// <summary>
/// Attempt reason.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReasonConverter)
)]
public enum UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason
{
    /// <summary>
    /// Merchant not responding.
    /// </summary>
    MerchantNotResponding,

    /// <summary>
    /// No return authorization provided.
    /// </summary>
    NoReturnAuthorizationProvided,

    /// <summary>
    /// No return instructions.
    /// </summary>
    NoReturnInstructions,

    /// <summary>
    /// Requested not to return.
    /// </summary>
    RequestedNotToReturn,

    /// <summary>
    /// Return not accepted.
    /// </summary>
    ReturnNotAccepted,
}

sealed class UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReasonConverter
    : JsonConverter<UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason>
{
    public override UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merchant_not_responding" =>
                UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            "no_return_authorization_provided" =>
                UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided,
            "no_return_instructions" =>
                UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions,
            "requested_not_to_return" =>
                UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn,
            "return_not_accepted" =>
                UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted,
            _ => (UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding =>
                    "merchant_not_responding",
                UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided =>
                    "no_return_authorization_provided",
                UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions =>
                    "no_return_instructions",
                UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn =>
                    "requested_not_to_return",
                UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted =>
                    "return_not_accepted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Return outcome.
/// </summary>
[JsonConverter(typeof(UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcomeConverter))]
public enum UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome
{
    /// <summary>
    /// Not returned.
    /// </summary>
    NotReturned,

    /// <summary>
    /// Returned.
    /// </summary>
    Returned,

    /// <summary>
    /// Return attempted.
    /// </summary>
    ReturnAttempted,
}

sealed class UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcomeConverter
    : JsonConverter<UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome>
{
    public override UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_returned" =>
                UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
            "returned" => UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome.Returned,
            "return_attempted" =>
                UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome.ReturnAttempted,
            _ => (UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned =>
                    "not_returned",
                UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome.Returned =>
                    "returned",
                UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome.ReturnAttempted =>
                    "return_attempted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Returned. Present if and only if `return_outcome` is `returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerQualityMerchandiseReturned,
        UserSubmissionChargebackConsumerQualityMerchandiseReturnedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerQualityMerchandiseReturned : JsonModel
{
    /// <summary>
    /// Merchant received return at.
    /// </summary>
    public required string? MerchantReceivedReturnAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_received_return_at");
        }
        init { this._rawData.Set("merchant_received_return_at", value); }
    }

    /// <summary>
    /// Other explanation. Required if and only if the return method is `other`.
    /// </summary>
    public required string? OtherExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("other_explanation");
        }
        init { this._rawData.Set("other_explanation", value); }
    }

    /// <summary>
    /// Return method.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod
    > ReturnMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod
                >
            >("return_method");
        }
        init { this._rawData.Set("return_method", value); }
    }

    /// <summary>
    /// Returned at.
    /// </summary>
    public required string ReturnedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("returned_at");
        }
        init { this._rawData.Set("returned_at", value); }
    }

    /// <summary>
    /// Tracking number.
    /// </summary>
    public required string? TrackingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tracking_number");
        }
        init { this._rawData.Set("tracking_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MerchantReceivedReturnAt;
        _ = this.OtherExplanation;
        this.ReturnMethod.Validate();
        _ = this.ReturnedAt;
        _ = this.TrackingNumber;
    }

    public UserSubmissionChargebackConsumerQualityMerchandiseReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerQualityMerchandiseReturned(
        UserSubmissionChargebackConsumerQualityMerchandiseReturned userSubmissionChargebackConsumerQualityMerchandiseReturned
    )
        : base(userSubmissionChargebackConsumerQualityMerchandiseReturned) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerQualityMerchandiseReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerQualityMerchandiseReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerQualityMerchandiseReturnedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerQualityMerchandiseReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerQualityMerchandiseReturnedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerQualityMerchandiseReturned>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerQualityMerchandiseReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerQualityMerchandiseReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return method.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethodConverter)
)]
public enum UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod
{
    /// <summary>
    /// DHL.
    /// </summary>
    Dhl,

    /// <summary>
    /// Face-to-face.
    /// </summary>
    FaceToFace,

    /// <summary>
    /// FedEx.
    /// </summary>
    Fedex,

    /// <summary>
    /// Other.
    /// </summary>
    Other,

    /// <summary>
    /// Postal service.
    /// </summary>
    PostalService,

    /// <summary>
    /// UPS.
    /// </summary>
    Ups,
}

sealed class UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethodConverter
    : JsonConverter<UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod>
{
    public override UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dhl" => UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            "face_to_face" =>
                UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.FaceToFace,
            "fedex" => UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.Fedex,
            "other" => UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.Other,
            "postal_service" =>
                UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.PostalService,
            "ups" => UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.Ups,
            _ => (UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl => "dhl",
                UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.FaceToFace =>
                    "face_to_face",
                UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.Fedex =>
                    "fedex",
                UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.Other =>
                    "other",
                UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.PostalService =>
                    "postal_service",
                UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.Ups => "ups",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Services quality issue. Present if and only if `category` is `consumer_quality_services`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerQualityServices,
        UserSubmissionChargebackConsumerQualityServicesFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerQualityServices : JsonModel
{
    /// <summary>
    /// Cardholder cancellation.
    /// </summary>
    public required UserSubmissionChargebackConsumerQualityServicesCardholderCancellation CardholderCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UserSubmissionChargebackConsumerQualityServicesCardholderCancellation>(
                "cardholder_cancellation"
            );
        }
        init { this._rawData.Set("cardholder_cancellation", value); }
    }

    /// <summary>
    /// Cardholder paid to have work redone.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone
    >? CardholderPaidToHaveWorkRedone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone
                >
            >("cardholder_paid_to_have_work_redone");
        }
        init { this._rawData.Set("cardholder_paid_to_have_work_redone", value); }
    }

    /// <summary>
    /// Non-fiat currency or non-fungible token related and not matching description.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
    > NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
                >
            >("non_fiat_currency_or_non_fungible_token_related_and_not_matching_description");
        }
        init
        {
            this._rawData.Set(
                "non_fiat_currency_or_non_fungible_token_related_and_not_matching_description",
                value
            );
        }
    }

    /// <summary>
    /// Ongoing negotiations. Exclude if there is no evidence of ongoing negotiations.
    /// </summary>
    public required UserSubmissionChargebackConsumerQualityServicesOngoingNegotiations? OngoingNegotiations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerQualityServicesOngoingNegotiations>(
                "ongoing_negotiations"
            );
        }
        init { this._rawData.Set("ongoing_negotiations", value); }
    }

    /// <summary>
    /// Purchase information and quality issue.
    /// </summary>
    public required string PurchaseInfoAndQualityIssue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("purchase_info_and_quality_issue");
        }
        init { this._rawData.Set("purchase_info_and_quality_issue", value); }
    }

    /// <summary>
    /// Whether the dispute is related to the quality of food from an eating place
    /// or restaurant. Must be provided when Merchant Category Code (MCC) is 5812,
    /// 5813 or 5814.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated
    >? RestaurantFoodRelated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated
                >
            >("restaurant_food_related");
        }
        init { this._rawData.Set("restaurant_food_related", value); }
    }

    /// <summary>
    /// Services received at.
    /// </summary>
    public required string ServicesReceivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("services_received_at");
        }
        init { this._rawData.Set("services_received_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CardholderCancellation.Validate();
        this.CardholderPaidToHaveWorkRedone?.Validate();
        this.NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.Validate();
        this.OngoingNegotiations?.Validate();
        _ = this.PurchaseInfoAndQualityIssue;
        this.RestaurantFoodRelated?.Validate();
        _ = this.ServicesReceivedAt;
    }

    public UserSubmissionChargebackConsumerQualityServices() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerQualityServices(
        UserSubmissionChargebackConsumerQualityServices userSubmissionChargebackConsumerQualityServices
    )
        : base(userSubmissionChargebackConsumerQualityServices) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerQualityServices(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerQualityServices(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerQualityServicesFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerQualityServices FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerQualityServicesFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerQualityServices>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerQualityServices FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerQualityServices.FromRawUnchecked(rawData);
}

/// <summary>
/// Cardholder cancellation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerQualityServicesCardholderCancellation,
        UserSubmissionChargebackConsumerQualityServicesCardholderCancellationFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerQualityServicesCardholderCancellation
    : JsonModel
{
    /// <summary>
    /// Accepted by merchant.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant
    > AcceptedByMerchant
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant
                >
            >("accepted_by_merchant");
        }
        init { this._rawData.Set("accepted_by_merchant", value); }
    }

    /// <summary>
    /// Canceled at.
    /// </summary>
    public required string CanceledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("canceled_at");
        }
        init { this._rawData.Set("canceled_at", value); }
    }

    /// <summary>
    /// Reason.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AcceptedByMerchant.Validate();
        _ = this.CanceledAt;
        _ = this.Reason;
    }

    public UserSubmissionChargebackConsumerQualityServicesCardholderCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerQualityServicesCardholderCancellation(
        UserSubmissionChargebackConsumerQualityServicesCardholderCancellation userSubmissionChargebackConsumerQualityServicesCardholderCancellation
    )
        : base(userSubmissionChargebackConsumerQualityServicesCardholderCancellation) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerQualityServicesCardholderCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerQualityServicesCardholderCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerQualityServicesCardholderCancellationFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerQualityServicesCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerQualityServicesCardholderCancellationFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerQualityServicesCardholderCancellation>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerQualityServicesCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerQualityServicesCardholderCancellation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Accepted by merchant.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchantConverter)
)]
public enum UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant
{
    /// <summary>
    /// Accepted.
    /// </summary>
    Accepted,

    /// <summary>
    /// Not accepted.
    /// </summary>
    NotAccepted,
}

sealed class UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchantConverter
    : JsonConverter<UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant>
{
    public override UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" =>
                UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
            "not_accepted" =>
                UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.NotAccepted,
            _ =>
                (UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted =>
                    "accepted",
                UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.NotAccepted =>
                    "not_accepted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Cardholder paid to have work redone.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedoneConverter)
)]
public enum UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone
{
    /// <summary>
    /// Cardholder did not pay to have work redone.
    /// </summary>
    DidNotPayToHaveWorkRedone,

    /// <summary>
    /// Cardholder paid to have work redone.
    /// </summary>
    PaidToHaveWorkRedone,
}

sealed class UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedoneConverter
    : JsonConverter<UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone>
{
    public override UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "did_not_pay_to_have_work_redone" =>
                UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            "paid_to_have_work_redone" =>
                UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.PaidToHaveWorkRedone,
            _ => (UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone =>
                    "did_not_pay_to_have_work_redone",
                UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.PaidToHaveWorkRedone =>
                    "paid_to_have_work_redone",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Non-fiat currency or non-fungible token related and not matching description.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescriptionConverter)
)]
public enum UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
{
    /// <summary>
    /// Not related.
    /// </summary>
    NotRelated,

    /// <summary>
    /// Related.
    /// </summary>
    Related,
}

sealed class UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescriptionConverter
    : JsonConverter<UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription>
{
    public override UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_related" =>
                UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            "related" =>
                UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.Related,
            _ =>
                (UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated =>
                    "not_related",
                UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.Related =>
                    "related",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Ongoing negotiations. Exclude if there is no evidence of ongoing negotiations.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerQualityServicesOngoingNegotiations,
        UserSubmissionChargebackConsumerQualityServicesOngoingNegotiationsFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerQualityServicesOngoingNegotiations
    : JsonModel
{
    /// <summary>
    /// Explanation of the previous ongoing negotiations between the cardholder and merchant.
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
    /// Date the cardholder first notified the issuer of the dispute.
    /// </summary>
    public required string IssuerFirstNotifiedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("issuer_first_notified_at");
        }
        init { this._rawData.Set("issuer_first_notified_at", value); }
    }

    /// <summary>
    /// Started at.
    /// </summary>
    public required string StartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("started_at");
        }
        init { this._rawData.Set("started_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Explanation;
        _ = this.IssuerFirstNotifiedAt;
        _ = this.StartedAt;
    }

    public UserSubmissionChargebackConsumerQualityServicesOngoingNegotiations() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerQualityServicesOngoingNegotiations(
        UserSubmissionChargebackConsumerQualityServicesOngoingNegotiations userSubmissionChargebackConsumerQualityServicesOngoingNegotiations
    )
        : base(userSubmissionChargebackConsumerQualityServicesOngoingNegotiations) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerQualityServicesOngoingNegotiations(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerQualityServicesOngoingNegotiations(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerQualityServicesOngoingNegotiationsFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerQualityServicesOngoingNegotiations FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerQualityServicesOngoingNegotiationsFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerQualityServicesOngoingNegotiations>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerQualityServicesOngoingNegotiations FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerQualityServicesOngoingNegotiations.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Whether the dispute is related to the quality of food from an eating place or
/// restaurant. Must be provided when Merchant Category Code (MCC) is 5812, 5813 or 5814.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelatedConverter)
)]
public enum UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated
{
    /// <summary>
    /// Not related.
    /// </summary>
    NotRelated,

    /// <summary>
    /// Related.
    /// </summary>
    Related,
}

sealed class UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelatedConverter
    : JsonConverter<UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated>
{
    public override UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_related" =>
                UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
            "related" =>
                UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated.Related,
            _ => (UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated =>
                    "not_related",
                UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated.Related =>
                    "related",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Services misrepresentation. Present if and only if `category` is `consumer_services_misrepresentation`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerServicesMisrepresentation,
        UserSubmissionChargebackConsumerServicesMisrepresentationFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerServicesMisrepresentation : JsonModel
{
    /// <summary>
    /// Cardholder cancellation.
    /// </summary>
    public required UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellation CardholderCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellation>(
                "cardholder_cancellation"
            );
        }
        init { this._rawData.Set("cardholder_cancellation", value); }
    }

    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted
                >
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
    }

    /// <summary>
    /// Misrepresentation explanation.
    /// </summary>
    public required string MisrepresentationExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("misrepresentation_explanation");
        }
        init { this._rawData.Set("misrepresentation_explanation", value); }
    }

    /// <summary>
    /// Purchase explanation.
    /// </summary>
    public required string PurchaseExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("purchase_explanation");
        }
        init { this._rawData.Set("purchase_explanation", value); }
    }

    /// <summary>
    /// Received at.
    /// </summary>
    public required string ReceivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("received_at");
        }
        init { this._rawData.Set("received_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CardholderCancellation.Validate();
        this.MerchantResolutionAttempted.Validate();
        _ = this.MisrepresentationExplanation;
        _ = this.PurchaseExplanation;
        _ = this.ReceivedAt;
    }

    public UserSubmissionChargebackConsumerServicesMisrepresentation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerServicesMisrepresentation(
        UserSubmissionChargebackConsumerServicesMisrepresentation userSubmissionChargebackConsumerServicesMisrepresentation
    )
        : base(userSubmissionChargebackConsumerServicesMisrepresentation) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerServicesMisrepresentation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerServicesMisrepresentation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerServicesMisrepresentationFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerServicesMisrepresentation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerServicesMisrepresentationFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerServicesMisrepresentation>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerServicesMisrepresentation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerServicesMisrepresentation.FromRawUnchecked(rawData);
}

/// <summary>
/// Cardholder cancellation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellation,
        UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellation
    : JsonModel
{
    /// <summary>
    /// Accepted by merchant.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
    > AcceptedByMerchant
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
                >
            >("accepted_by_merchant");
        }
        init { this._rawData.Set("accepted_by_merchant", value); }
    }

    /// <summary>
    /// Canceled at.
    /// </summary>
    public required string CanceledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("canceled_at");
        }
        init { this._rawData.Set("canceled_at", value); }
    }

    /// <summary>
    /// Reason.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AcceptedByMerchant.Validate();
        _ = this.CanceledAt;
        _ = this.Reason;
    }

    public UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellation(
        UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellation userSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellation
    )
        : base(userSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellation) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellation>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Accepted by merchant.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchantConverter)
)]
public enum UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
{
    /// <summary>
    /// Accepted.
    /// </summary>
    Accepted,

    /// <summary>
    /// Not accepted.
    /// </summary>
    NotAccepted,
}

sealed class UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchantConverter
    : JsonConverter<UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant>
{
    public override UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" =>
                UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
            "not_accepted" =>
                UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.NotAccepted,
            _ =>
                (UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted =>
                    "accepted",
                UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.NotAccepted =>
                    "not_accepted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttemptedConverter)
)]
public enum UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted
{
    /// <summary>
    /// Attempted.
    /// </summary>
    Attempted,

    /// <summary>
    /// Prohibited by local law.
    /// </summary>
    ProhibitedByLocalLaw,
}

sealed class UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttemptedConverter
    : JsonConverter<UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted>
{
    public override UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ =>
                (UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted =>
                    "attempted",
                UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw =>
                    "prohibited_by_local_law",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Services not as described. Present if and only if `category` is `consumer_services_not_as_described`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerServicesNotAsDescribed,
        UserSubmissionChargebackConsumerServicesNotAsDescribedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerServicesNotAsDescribed : JsonModel
{
    /// <summary>
    /// Cardholder cancellation.
    /// </summary>
    public required UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellation CardholderCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellation>(
                "cardholder_cancellation"
            );
        }
        init { this._rawData.Set("cardholder_cancellation", value); }
    }

    /// <summary>
    /// Explanation of what was ordered and was not as described.
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
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted
                >
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
    }

    /// <summary>
    /// Received at.
    /// </summary>
    public required string ReceivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("received_at");
        }
        init { this._rawData.Set("received_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CardholderCancellation.Validate();
        _ = this.Explanation;
        this.MerchantResolutionAttempted.Validate();
        _ = this.ReceivedAt;
    }

    public UserSubmissionChargebackConsumerServicesNotAsDescribed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerServicesNotAsDescribed(
        UserSubmissionChargebackConsumerServicesNotAsDescribed userSubmissionChargebackConsumerServicesNotAsDescribed
    )
        : base(userSubmissionChargebackConsumerServicesNotAsDescribed) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerServicesNotAsDescribed(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerServicesNotAsDescribed(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerServicesNotAsDescribedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerServicesNotAsDescribed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerServicesNotAsDescribedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerServicesNotAsDescribed>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerServicesNotAsDescribed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerServicesNotAsDescribed.FromRawUnchecked(rawData);
}

/// <summary>
/// Cardholder cancellation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellation,
        UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellation
    : JsonModel
{
    /// <summary>
    /// Accepted by merchant.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
    > AcceptedByMerchant
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
                >
            >("accepted_by_merchant");
        }
        init { this._rawData.Set("accepted_by_merchant", value); }
    }

    /// <summary>
    /// Canceled at.
    /// </summary>
    public required string CanceledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("canceled_at");
        }
        init { this._rawData.Set("canceled_at", value); }
    }

    /// <summary>
    /// Reason.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AcceptedByMerchant.Validate();
        _ = this.CanceledAt;
        _ = this.Reason;
    }

    public UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellation(
        UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellation userSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellation
    )
        : base(userSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellation) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellation>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Accepted by merchant.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchantConverter)
)]
public enum UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
{
    /// <summary>
    /// Accepted.
    /// </summary>
    Accepted,

    /// <summary>
    /// Not accepted.
    /// </summary>
    NotAccepted,
}

sealed class UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchantConverter
    : JsonConverter<UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant>
{
    public override UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" =>
                UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
            "not_accepted" =>
                UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.NotAccepted,
            _ =>
                (UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted =>
                    "accepted",
                UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.NotAccepted =>
                    "not_accepted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttemptedConverter)
)]
public enum UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted
{
    /// <summary>
    /// Attempted.
    /// </summary>
    Attempted,

    /// <summary>
    /// Prohibited by local law.
    /// </summary>
    ProhibitedByLocalLaw,
}

sealed class UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttemptedConverter
    : JsonConverter<UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted>
{
    public override UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ =>
                (UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted =>
                    "attempted",
                UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw =>
                    "prohibited_by_local_law",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Services not received. Present if and only if `category` is `consumer_services_not_received`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerServicesNotReceived,
        UserSubmissionChargebackConsumerServicesNotReceivedFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerServicesNotReceived : JsonModel
{
    /// <summary>
    /// Cancellation outcome.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome
    > CancellationOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome
                >
            >("cancellation_outcome");
        }
        init { this._rawData.Set("cancellation_outcome", value); }
    }

    /// <summary>
    /// Cardholder cancellation prior to expected receipt. Present if and only if
    /// `cancellation_outcome` is `cardholder_cancellation_prior_to_expected_receipt`.
    /// </summary>
    public required UserSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt? CardholderCancellationPriorToExpectedReceipt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt>(
                "cardholder_cancellation_prior_to_expected_receipt"
            );
        }
        init { this._rawData.Set("cardholder_cancellation_prior_to_expected_receipt", value); }
    }

    /// <summary>
    /// Last expected receipt at.
    /// </summary>
    public required string LastExpectedReceiptAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("last_expected_receipt_at");
        }
        init { this._rawData.Set("last_expected_receipt_at", value); }
    }

    /// <summary>
    /// Merchant cancellation. Present if and only if `cancellation_outcome` is `merchant_cancellation`.
    /// </summary>
    public required UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellation? MerchantCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellation>(
                "merchant_cancellation"
            );
        }
        init { this._rawData.Set("merchant_cancellation", value); }
    }

    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted
                >
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
    }

    /// <summary>
    /// No cancellation. Present if and only if `cancellation_outcome` is `no_cancellation`.
    /// </summary>
    public required UserSubmissionChargebackConsumerServicesNotReceivedNoCancellation? NoCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackConsumerServicesNotReceivedNoCancellation>(
                "no_cancellation"
            );
        }
        init { this._rawData.Set("no_cancellation", value); }
    }

    /// <summary>
    /// Purchase information and explanation.
    /// </summary>
    public required string PurchaseInfoAndExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("purchase_info_and_explanation");
        }
        init { this._rawData.Set("purchase_info_and_explanation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CancellationOutcome.Validate();
        this.CardholderCancellationPriorToExpectedReceipt?.Validate();
        _ = this.LastExpectedReceiptAt;
        this.MerchantCancellation?.Validate();
        this.MerchantResolutionAttempted.Validate();
        this.NoCancellation?.Validate();
        _ = this.PurchaseInfoAndExplanation;
    }

    public UserSubmissionChargebackConsumerServicesNotReceived() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerServicesNotReceived(
        UserSubmissionChargebackConsumerServicesNotReceived userSubmissionChargebackConsumerServicesNotReceived
    )
        : base(userSubmissionChargebackConsumerServicesNotReceived) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerServicesNotReceived(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerServicesNotReceived(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerServicesNotReceivedFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerServicesNotReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerServicesNotReceivedFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerServicesNotReceived>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerServicesNotReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackConsumerServicesNotReceived.FromRawUnchecked(rawData);
}

/// <summary>
/// Cancellation outcome.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcomeConverter)
)]
public enum UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome
{
    /// <summary>
    /// Cardholder cancellation prior to expected receipt.
    /// </summary>
    CardholderCancellationPriorToExpectedReceipt,

    /// <summary>
    /// Merchant cancellation.
    /// </summary>
    MerchantCancellation,

    /// <summary>
    /// No cancellation.
    /// </summary>
    NoCancellation,
}

sealed class UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcomeConverter
    : JsonConverter<UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome>
{
    public override UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cardholder_cancellation_prior_to_expected_receipt" =>
                UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            "merchant_cancellation" =>
                UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome.MerchantCancellation,
            "no_cancellation" =>
                UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome.NoCancellation,
            _ => (UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt =>
                    "cardholder_cancellation_prior_to_expected_receipt",
                UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome.MerchantCancellation =>
                    "merchant_cancellation",
                UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome.NoCancellation =>
                    "no_cancellation",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Cardholder cancellation prior to expected receipt. Present if and only if `cancellation_outcome`
/// is `cardholder_cancellation_prior_to_expected_receipt`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt,
        UserSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceiptFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
    : JsonModel
{
    /// <summary>
    /// Canceled at.
    /// </summary>
    public required string CanceledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("canceled_at");
        }
        init { this._rawData.Set("canceled_at", value); }
    }

    /// <summary>
    /// Reason.
    /// </summary>
    public required string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanceledAt;
        _ = this.Reason;
    }

    public UserSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt()
    { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt(
        UserSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt userSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
    )
        : base(
            userSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
        ) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceiptFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceiptFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Merchant cancellation. Present if and only if `cancellation_outcome` is `merchant_cancellation`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellation,
        UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellationFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellation
    : JsonModel
{
    /// <summary>
    /// Canceled at.
    /// </summary>
    public required string CanceledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("canceled_at");
        }
        init { this._rawData.Set("canceled_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanceledAt;
    }

    public UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellation(
        UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellation userSubmissionChargebackConsumerServicesNotReceivedMerchantCancellation
    )
        : base(userSubmissionChargebackConsumerServicesNotReceivedMerchantCancellation) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellationFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellation(
        string canceledAt
    )
        : this()
    {
        this.CanceledAt = canceledAt;
    }
}

class UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellationFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellation>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerServicesNotReceivedMerchantCancellation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttemptedConverter)
)]
public enum UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted
{
    /// <summary>
    /// Attempted.
    /// </summary>
    Attempted,

    /// <summary>
    /// Prohibited by local law.
    /// </summary>
    ProhibitedByLocalLaw,
}

sealed class UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttemptedConverter
    : JsonConverter<UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted>
{
    public override UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted =>
                    "attempted",
                UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw =>
                    "prohibited_by_local_law",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// No cancellation. Present if and only if `cancellation_outcome` is `no_cancellation`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackConsumerServicesNotReceivedNoCancellation,
        UserSubmissionChargebackConsumerServicesNotReceivedNoCancellationFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackConsumerServicesNotReceivedNoCancellation
    : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public UserSubmissionChargebackConsumerServicesNotReceivedNoCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackConsumerServicesNotReceivedNoCancellation(
        UserSubmissionChargebackConsumerServicesNotReceivedNoCancellation userSubmissionChargebackConsumerServicesNotReceivedNoCancellation
    )
        : base(userSubmissionChargebackConsumerServicesNotReceivedNoCancellation) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackConsumerServicesNotReceivedNoCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackConsumerServicesNotReceivedNoCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackConsumerServicesNotReceivedNoCancellationFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackConsumerServicesNotReceivedNoCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackConsumerServicesNotReceivedNoCancellationFromRaw
    : IFromRawJson<UserSubmissionChargebackConsumerServicesNotReceivedNoCancellation>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackConsumerServicesNotReceivedNoCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UserSubmissionChargebackConsumerServicesNotReceivedNoCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// Fraud. Present if and only if `category` is `fraud`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UserSubmissionChargebackFraud, UserSubmissionChargebackFraudFromRaw>)
)]
public sealed record class UserSubmissionChargebackFraud : JsonModel
{
    /// <summary>
    /// Fraud type.
    /// </summary>
    public required ApiEnum<string, UserSubmissionChargebackFraudFraudType> FraudType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UserSubmissionChargebackFraudFraudType>
            >("fraud_type");
        }
        init { this._rawData.Set("fraud_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FraudType.Validate();
    }

    public UserSubmissionChargebackFraud() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackFraud(
        UserSubmissionChargebackFraud userSubmissionChargebackFraud
    )
        : base(userSubmissionChargebackFraud) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackFraud(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackFraud(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackFraudFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackFraud FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserSubmissionChargebackFraud(
        ApiEnum<string, UserSubmissionChargebackFraudFraudType> fraudType
    )
        : this()
    {
        this.FraudType = fraudType;
    }
}

class UserSubmissionChargebackFraudFromRaw : IFromRawJson<UserSubmissionChargebackFraud>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackFraud FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackFraud.FromRawUnchecked(rawData);
}

/// <summary>
/// Fraud type.
/// </summary>
[JsonConverter(typeof(UserSubmissionChargebackFraudFraudTypeConverter))]
public enum UserSubmissionChargebackFraudFraudType
{
    /// <summary>
    /// Account or credentials takeover.
    /// </summary>
    AccountOrCredentialsTakeover,

    /// <summary>
    /// Card not received as issued.
    /// </summary>
    CardNotReceivedAsIssued,

    /// <summary>
    /// Fraudulent application.
    /// </summary>
    FraudulentApplication,

    /// <summary>
    /// Fraudulent use of account number.
    /// </summary>
    FraudulentUseOfAccountNumber,

    /// <summary>
    /// Incorrect processing.
    /// </summary>
    IncorrectProcessing,

    /// <summary>
    /// Issuer reported counterfeit.
    /// </summary>
    IssuerReportedCounterfeit,

    /// <summary>
    /// Lost.
    /// </summary>
    Lost,

    /// <summary>
    /// Manipulation of account holder.
    /// </summary>
    ManipulationOfAccountHolder,

    /// <summary>
    /// Merchant misrepresentation.
    /// </summary>
    MerchantMisrepresentation,

    /// <summary>
    /// Miscellaneous.
    /// </summary>
    Miscellaneous,

    /// <summary>
    /// Stolen.
    /// </summary>
    Stolen,
}

sealed class UserSubmissionChargebackFraudFraudTypeConverter
    : JsonConverter<UserSubmissionChargebackFraudFraudType>
{
    public override UserSubmissionChargebackFraudFraudType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_or_credentials_takeover" =>
                UserSubmissionChargebackFraudFraudType.AccountOrCredentialsTakeover,
            "card_not_received_as_issued" =>
                UserSubmissionChargebackFraudFraudType.CardNotReceivedAsIssued,
            "fraudulent_application" =>
                UserSubmissionChargebackFraudFraudType.FraudulentApplication,
            "fraudulent_use_of_account_number" =>
                UserSubmissionChargebackFraudFraudType.FraudulentUseOfAccountNumber,
            "incorrect_processing" => UserSubmissionChargebackFraudFraudType.IncorrectProcessing,
            "issuer_reported_counterfeit" =>
                UserSubmissionChargebackFraudFraudType.IssuerReportedCounterfeit,
            "lost" => UserSubmissionChargebackFraudFraudType.Lost,
            "manipulation_of_account_holder" =>
                UserSubmissionChargebackFraudFraudType.ManipulationOfAccountHolder,
            "merchant_misrepresentation" =>
                UserSubmissionChargebackFraudFraudType.MerchantMisrepresentation,
            "miscellaneous" => UserSubmissionChargebackFraudFraudType.Miscellaneous,
            "stolen" => UserSubmissionChargebackFraudFraudType.Stolen,
            _ => (UserSubmissionChargebackFraudFraudType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackFraudFraudType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackFraudFraudType.AccountOrCredentialsTakeover =>
                    "account_or_credentials_takeover",
                UserSubmissionChargebackFraudFraudType.CardNotReceivedAsIssued =>
                    "card_not_received_as_issued",
                UserSubmissionChargebackFraudFraudType.FraudulentApplication =>
                    "fraudulent_application",
                UserSubmissionChargebackFraudFraudType.FraudulentUseOfAccountNumber =>
                    "fraudulent_use_of_account_number",
                UserSubmissionChargebackFraudFraudType.IncorrectProcessing =>
                    "incorrect_processing",
                UserSubmissionChargebackFraudFraudType.IssuerReportedCounterfeit =>
                    "issuer_reported_counterfeit",
                UserSubmissionChargebackFraudFraudType.Lost => "lost",
                UserSubmissionChargebackFraudFraudType.ManipulationOfAccountHolder =>
                    "manipulation_of_account_holder",
                UserSubmissionChargebackFraudFraudType.MerchantMisrepresentation =>
                    "merchant_misrepresentation",
                UserSubmissionChargebackFraudFraudType.Miscellaneous => "miscellaneous",
                UserSubmissionChargebackFraudFraudType.Stolen => "stolen",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Processing error. Present if and only if `category` is `processing_error`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackProcessingError,
        UserSubmissionChargebackProcessingErrorFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackProcessingError : JsonModel
{
    /// <summary>
    /// Duplicate transaction. Present if and only if `error_reason` is `duplicate_transaction`.
    /// </summary>
    public required UserSubmissionChargebackProcessingErrorDuplicateTransaction? DuplicateTransaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackProcessingErrorDuplicateTransaction>(
                "duplicate_transaction"
            );
        }
        init { this._rawData.Set("duplicate_transaction", value); }
    }

    /// <summary>
    /// Error reason.
    /// </summary>
    public required ApiEnum<string, UserSubmissionChargebackProcessingErrorErrorReason> ErrorReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UserSubmissionChargebackProcessingErrorErrorReason>
            >("error_reason");
        }
        init { this._rawData.Set("error_reason", value); }
    }

    /// <summary>
    /// Incorrect amount. Present if and only if `error_reason` is `incorrect_amount`.
    /// </summary>
    public required UserSubmissionChargebackProcessingErrorIncorrectAmount? IncorrectAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackProcessingErrorIncorrectAmount>(
                "incorrect_amount"
            );
        }
        init { this._rawData.Set("incorrect_amount", value); }
    }

    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted>
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
    }

    /// <summary>
    /// Paid by other means. Present if and only if `error_reason` is `paid_by_other_means`.
    /// </summary>
    public required UserSubmissionChargebackProcessingErrorPaidByOtherMeans? PaidByOtherMeans
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionChargebackProcessingErrorPaidByOtherMeans>(
                "paid_by_other_means"
            );
        }
        init { this._rawData.Set("paid_by_other_means", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DuplicateTransaction?.Validate();
        this.ErrorReason.Validate();
        this.IncorrectAmount?.Validate();
        this.MerchantResolutionAttempted.Validate();
        this.PaidByOtherMeans?.Validate();
    }

    public UserSubmissionChargebackProcessingError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackProcessingError(
        UserSubmissionChargebackProcessingError userSubmissionChargebackProcessingError
    )
        : base(userSubmissionChargebackProcessingError) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackProcessingError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackProcessingError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackProcessingErrorFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackProcessingError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackProcessingErrorFromRaw
    : IFromRawJson<UserSubmissionChargebackProcessingError>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackProcessingError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackProcessingError.FromRawUnchecked(rawData);
}

/// <summary>
/// Duplicate transaction. Present if and only if `error_reason` is `duplicate_transaction`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackProcessingErrorDuplicateTransaction,
        UserSubmissionChargebackProcessingErrorDuplicateTransactionFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackProcessingErrorDuplicateTransaction : JsonModel
{
    /// <summary>
    /// Other transaction ID.
    /// </summary>
    public required string OtherTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("other_transaction_id");
        }
        init { this._rawData.Set("other_transaction_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OtherTransactionID;
    }

    public UserSubmissionChargebackProcessingErrorDuplicateTransaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackProcessingErrorDuplicateTransaction(
        UserSubmissionChargebackProcessingErrorDuplicateTransaction userSubmissionChargebackProcessingErrorDuplicateTransaction
    )
        : base(userSubmissionChargebackProcessingErrorDuplicateTransaction) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackProcessingErrorDuplicateTransaction(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackProcessingErrorDuplicateTransaction(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackProcessingErrorDuplicateTransactionFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackProcessingErrorDuplicateTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserSubmissionChargebackProcessingErrorDuplicateTransaction(string otherTransactionID)
        : this()
    {
        this.OtherTransactionID = otherTransactionID;
    }
}

class UserSubmissionChargebackProcessingErrorDuplicateTransactionFromRaw
    : IFromRawJson<UserSubmissionChargebackProcessingErrorDuplicateTransaction>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackProcessingErrorDuplicateTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackProcessingErrorDuplicateTransaction.FromRawUnchecked(rawData);
}

/// <summary>
/// Error reason.
/// </summary>
[JsonConverter(typeof(UserSubmissionChargebackProcessingErrorErrorReasonConverter))]
public enum UserSubmissionChargebackProcessingErrorErrorReason
{
    /// <summary>
    /// Duplicate transaction.
    /// </summary>
    DuplicateTransaction,

    /// <summary>
    /// Incorrect amount.
    /// </summary>
    IncorrectAmount,

    /// <summary>
    /// Paid by other means.
    /// </summary>
    PaidByOtherMeans,
}

sealed class UserSubmissionChargebackProcessingErrorErrorReasonConverter
    : JsonConverter<UserSubmissionChargebackProcessingErrorErrorReason>
{
    public override UserSubmissionChargebackProcessingErrorErrorReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "duplicate_transaction" =>
                UserSubmissionChargebackProcessingErrorErrorReason.DuplicateTransaction,
            "incorrect_amount" =>
                UserSubmissionChargebackProcessingErrorErrorReason.IncorrectAmount,
            "paid_by_other_means" =>
                UserSubmissionChargebackProcessingErrorErrorReason.PaidByOtherMeans,
            _ => (UserSubmissionChargebackProcessingErrorErrorReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackProcessingErrorErrorReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackProcessingErrorErrorReason.DuplicateTransaction =>
                    "duplicate_transaction",
                UserSubmissionChargebackProcessingErrorErrorReason.IncorrectAmount =>
                    "incorrect_amount",
                UserSubmissionChargebackProcessingErrorErrorReason.PaidByOtherMeans =>
                    "paid_by_other_means",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Incorrect amount. Present if and only if `error_reason` is `incorrect_amount`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackProcessingErrorIncorrectAmount,
        UserSubmissionChargebackProcessingErrorIncorrectAmountFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackProcessingErrorIncorrectAmount : JsonModel
{
    /// <summary>
    /// Expected amount.
    /// </summary>
    public required long ExpectedAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("expected_amount");
        }
        init { this._rawData.Set("expected_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpectedAmount;
    }

    public UserSubmissionChargebackProcessingErrorIncorrectAmount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackProcessingErrorIncorrectAmount(
        UserSubmissionChargebackProcessingErrorIncorrectAmount userSubmissionChargebackProcessingErrorIncorrectAmount
    )
        : base(userSubmissionChargebackProcessingErrorIncorrectAmount) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackProcessingErrorIncorrectAmount(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackProcessingErrorIncorrectAmount(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackProcessingErrorIncorrectAmountFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackProcessingErrorIncorrectAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserSubmissionChargebackProcessingErrorIncorrectAmount(long expectedAmount)
        : this()
    {
        this.ExpectedAmount = expectedAmount;
    }
}

class UserSubmissionChargebackProcessingErrorIncorrectAmountFromRaw
    : IFromRawJson<UserSubmissionChargebackProcessingErrorIncorrectAmount>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackProcessingErrorIncorrectAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackProcessingErrorIncorrectAmount.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(typeof(UserSubmissionChargebackProcessingErrorMerchantResolutionAttemptedConverter))]
public enum UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted
{
    /// <summary>
    /// Attempted.
    /// </summary>
    Attempted,

    /// <summary>
    /// Prohibited by local law.
    /// </summary>
    ProhibitedByLocalLaw,
}

sealed class UserSubmissionChargebackProcessingErrorMerchantResolutionAttemptedConverter
    : JsonConverter<UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted>
{
    public override UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted.Attempted =>
                    "attempted",
                UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted.ProhibitedByLocalLaw =>
                    "prohibited_by_local_law",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Paid by other means. Present if and only if `error_reason` is `paid_by_other_means`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionChargebackProcessingErrorPaidByOtherMeans,
        UserSubmissionChargebackProcessingErrorPaidByOtherMeansFromRaw
    >)
)]
public sealed record class UserSubmissionChargebackProcessingErrorPaidByOtherMeans : JsonModel
{
    /// <summary>
    /// Other form of payment evidence.
    /// </summary>
    public required ApiEnum<
        string,
        UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence
    > OtherFormOfPaymentEvidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence
                >
            >("other_form_of_payment_evidence");
        }
        init { this._rawData.Set("other_form_of_payment_evidence", value); }
    }

    /// <summary>
    /// Other transaction ID.
    /// </summary>
    public required string? OtherTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("other_transaction_id");
        }
        init { this._rawData.Set("other_transaction_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.OtherFormOfPaymentEvidence.Validate();
        _ = this.OtherTransactionID;
    }

    public UserSubmissionChargebackProcessingErrorPaidByOtherMeans() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionChargebackProcessingErrorPaidByOtherMeans(
        UserSubmissionChargebackProcessingErrorPaidByOtherMeans userSubmissionChargebackProcessingErrorPaidByOtherMeans
    )
        : base(userSubmissionChargebackProcessingErrorPaidByOtherMeans) { }
#pragma warning restore CS8618

    public UserSubmissionChargebackProcessingErrorPaidByOtherMeans(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionChargebackProcessingErrorPaidByOtherMeans(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionChargebackProcessingErrorPaidByOtherMeansFromRaw.FromRawUnchecked"/>
    public static UserSubmissionChargebackProcessingErrorPaidByOtherMeans FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionChargebackProcessingErrorPaidByOtherMeansFromRaw
    : IFromRawJson<UserSubmissionChargebackProcessingErrorPaidByOtherMeans>
{
    /// <inheritdoc/>
    public UserSubmissionChargebackProcessingErrorPaidByOtherMeans FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionChargebackProcessingErrorPaidByOtherMeans.FromRawUnchecked(rawData);
}

/// <summary>
/// Other form of payment evidence.
/// </summary>
[JsonConverter(
    typeof(UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidenceConverter)
)]
public enum UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence
{
    /// <summary>
    /// Canceled check.
    /// </summary>
    CanceledCheck,

    /// <summary>
    /// Card transaction.
    /// </summary>
    CardTransaction,

    /// <summary>
    /// Cash receipt.
    /// </summary>
    CashReceipt,

    /// <summary>
    /// Other.
    /// </summary>
    Other,

    /// <summary>
    /// Statement.
    /// </summary>
    Statement,

    /// <summary>
    /// Voucher.
    /// </summary>
    Voucher,
}

sealed class UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidenceConverter
    : JsonConverter<UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence>
{
    public override UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "canceled_check" =>
                UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
            "card_transaction" =>
                UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CardTransaction,
            "cash_receipt" =>
                UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CashReceipt,
            "other" =>
                UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Other,
            "statement" =>
                UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Statement,
            "voucher" =>
                UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Voucher,
            _ =>
                (UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck =>
                    "canceled_check",
                UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CardTransaction =>
                    "card_transaction",
                UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CashReceipt =>
                    "cash_receipt",
                UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Other =>
                    "other",
                UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Statement =>
                    "statement",
                UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Voucher =>
                    "voucher",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Visa Card Dispute Merchant Pre-Arbitration Decline User Submission object.
/// This field will be present in the JSON response if and only if `category` is equal
/// to `merchant_prearbitration_decline`. Contains the details specific to a merchant
/// prearbitration decline Visa Card Dispute User Submission.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionMerchantPrearbitrationDecline,
        UserSubmissionMerchantPrearbitrationDeclineFromRaw
    >)
)]
public sealed record class UserSubmissionMerchantPrearbitrationDecline : JsonModel
{
    /// <summary>
    /// The reason the user declined the merchant's request for pre-arbitration in
    /// their favor.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reason;
    }

    public UserSubmissionMerchantPrearbitrationDecline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionMerchantPrearbitrationDecline(
        UserSubmissionMerchantPrearbitrationDecline userSubmissionMerchantPrearbitrationDecline
    )
        : base(userSubmissionMerchantPrearbitrationDecline) { }
#pragma warning restore CS8618

    public UserSubmissionMerchantPrearbitrationDecline(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionMerchantPrearbitrationDecline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionMerchantPrearbitrationDeclineFromRaw.FromRawUnchecked"/>
    public static UserSubmissionMerchantPrearbitrationDecline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserSubmissionMerchantPrearbitrationDecline(string reason)
        : this()
    {
        this.Reason = reason;
    }
}

class UserSubmissionMerchantPrearbitrationDeclineFromRaw
    : IFromRawJson<UserSubmissionMerchantPrearbitrationDecline>
{
    /// <inheritdoc/>
    public UserSubmissionMerchantPrearbitrationDecline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionMerchantPrearbitrationDecline.FromRawUnchecked(rawData);
}

/// <summary>
/// A Visa Card Dispute User-Initiated Pre-Arbitration User Submission object. This
/// field will be present in the JSON response if and only if `category` is equal
/// to `user_prearbitration`. Contains the details specific to a user-initiated pre-arbitration
/// Visa Card Dispute User Submission.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionUserPrearbitration,
        UserSubmissionUserPrearbitrationFromRaw
    >)
)]
public sealed record class UserSubmissionUserPrearbitration : JsonModel
{
    /// <summary>
    /// Category change details for the pre-arbitration request, if requested.
    /// </summary>
    public required UserSubmissionUserPrearbitrationCategoryChange? CategoryChange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserSubmissionUserPrearbitrationCategoryChange>(
                "category_change"
            );
        }
        init { this._rawData.Set("category_change", value); }
    }

    /// <summary>
    /// The reason for the pre-arbitration request.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CategoryChange?.Validate();
        _ = this.Reason;
    }

    public UserSubmissionUserPrearbitration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionUserPrearbitration(
        UserSubmissionUserPrearbitration userSubmissionUserPrearbitration
    )
        : base(userSubmissionUserPrearbitration) { }
#pragma warning restore CS8618

    public UserSubmissionUserPrearbitration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionUserPrearbitration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionUserPrearbitrationFromRaw.FromRawUnchecked"/>
    public static UserSubmissionUserPrearbitration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionUserPrearbitrationFromRaw : IFromRawJson<UserSubmissionUserPrearbitration>
{
    /// <inheritdoc/>
    public UserSubmissionUserPrearbitration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionUserPrearbitration.FromRawUnchecked(rawData);
}

/// <summary>
/// Category change details for the pre-arbitration request, if requested.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserSubmissionUserPrearbitrationCategoryChange,
        UserSubmissionUserPrearbitrationCategoryChangeFromRaw
    >)
)]
public sealed record class UserSubmissionUserPrearbitrationCategoryChange : JsonModel
{
    /// <summary>
    /// The category the dispute is being changed to.
    /// </summary>
    public required ApiEnum<string, UserSubmissionUserPrearbitrationCategoryChangeCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UserSubmissionUserPrearbitrationCategoryChangeCategory>
            >("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// The reason for the pre-arbitration request.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        _ = this.Reason;
    }

    public UserSubmissionUserPrearbitrationCategoryChange() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSubmissionUserPrearbitrationCategoryChange(
        UserSubmissionUserPrearbitrationCategoryChange userSubmissionUserPrearbitrationCategoryChange
    )
        : base(userSubmissionUserPrearbitrationCategoryChange) { }
#pragma warning restore CS8618

    public UserSubmissionUserPrearbitrationCategoryChange(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSubmissionUserPrearbitrationCategoryChange(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSubmissionUserPrearbitrationCategoryChangeFromRaw.FromRawUnchecked"/>
    public static UserSubmissionUserPrearbitrationCategoryChange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserSubmissionUserPrearbitrationCategoryChangeFromRaw
    : IFromRawJson<UserSubmissionUserPrearbitrationCategoryChange>
{
    /// <inheritdoc/>
    public UserSubmissionUserPrearbitrationCategoryChange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserSubmissionUserPrearbitrationCategoryChange.FromRawUnchecked(rawData);
}

/// <summary>
/// The category the dispute is being changed to.
/// </summary>
[JsonConverter(typeof(UserSubmissionUserPrearbitrationCategoryChangeCategoryConverter))]
public enum UserSubmissionUserPrearbitrationCategoryChangeCategory
{
    /// <summary>
    /// Authorization.
    /// </summary>
    Authorization,

    /// <summary>
    /// Consumer: canceled merchandise.
    /// </summary>
    ConsumerCanceledMerchandise,

    /// <summary>
    /// Consumer: canceled recurring transaction.
    /// </summary>
    ConsumerCanceledRecurringTransaction,

    /// <summary>
    /// Consumer: canceled services.
    /// </summary>
    ConsumerCanceledServices,

    /// <summary>
    /// Consumer: counterfeit merchandise.
    /// </summary>
    ConsumerCounterfeitMerchandise,

    /// <summary>
    /// Consumer: credit not processed.
    /// </summary>
    ConsumerCreditNotProcessed,

    /// <summary>
    /// Consumer: damaged or defective merchandise.
    /// </summary>
    ConsumerDamagedOrDefectiveMerchandise,

    /// <summary>
    /// Consumer: merchandise misrepresentation.
    /// </summary>
    ConsumerMerchandiseMisrepresentation,

    /// <summary>
    /// Consumer: merchandise not as described.
    /// </summary>
    ConsumerMerchandiseNotAsDescribed,

    /// <summary>
    /// Consumer: merchandise not received.
    /// </summary>
    ConsumerMerchandiseNotReceived,

    /// <summary>
    /// Consumer: non-receipt of cash.
    /// </summary>
    ConsumerNonReceiptOfCash,

    /// <summary>
    /// Consumer: Original Credit Transaction (OCT) not accepted.
    /// </summary>
    ConsumerOriginalCreditTransactionNotAccepted,

    /// <summary>
    /// Consumer: merchandise quality issue.
    /// </summary>
    ConsumerQualityMerchandise,

    /// <summary>
    /// Consumer: services quality issue.
    /// </summary>
    ConsumerQualityServices,

    /// <summary>
    /// Consumer: services misrepresentation.
    /// </summary>
    ConsumerServicesMisrepresentation,

    /// <summary>
    /// Consumer: services not as described.
    /// </summary>
    ConsumerServicesNotAsDescribed,

    /// <summary>
    /// Consumer: services not received.
    /// </summary>
    ConsumerServicesNotReceived,

    /// <summary>
    /// Fraud.
    /// </summary>
    Fraud,

    /// <summary>
    /// Processing error.
    /// </summary>
    ProcessingError,
}

sealed class UserSubmissionUserPrearbitrationCategoryChangeCategoryConverter
    : JsonConverter<UserSubmissionUserPrearbitrationCategoryChangeCategory>
{
    public override UserSubmissionUserPrearbitrationCategoryChangeCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "authorization" => UserSubmissionUserPrearbitrationCategoryChangeCategory.Authorization,
            "consumer_canceled_merchandise" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerCanceledMerchandise,
            "consumer_canceled_recurring_transaction" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerCanceledRecurringTransaction,
            "consumer_canceled_services" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerCanceledServices,
            "consumer_counterfeit_merchandise" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerCounterfeitMerchandise,
            "consumer_credit_not_processed" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerCreditNotProcessed,
            "consumer_damaged_or_defective_merchandise" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerDamagedOrDefectiveMerchandise,
            "consumer_merchandise_misrepresentation" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerMerchandiseMisrepresentation,
            "consumer_merchandise_not_as_described" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerMerchandiseNotAsDescribed,
            "consumer_merchandise_not_received" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerMerchandiseNotReceived,
            "consumer_non_receipt_of_cash" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerNonReceiptOfCash,
            "consumer_original_credit_transaction_not_accepted" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerOriginalCreditTransactionNotAccepted,
            "consumer_quality_merchandise" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerQualityMerchandise,
            "consumer_quality_services" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerQualityServices,
            "consumer_services_misrepresentation" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerServicesMisrepresentation,
            "consumer_services_not_as_described" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerServicesNotAsDescribed,
            "consumer_services_not_received" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerServicesNotReceived,
            "fraud" => UserSubmissionUserPrearbitrationCategoryChangeCategory.Fraud,
            "processing_error" =>
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ProcessingError,
            _ => (UserSubmissionUserPrearbitrationCategoryChangeCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserSubmissionUserPrearbitrationCategoryChangeCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserSubmissionUserPrearbitrationCategoryChangeCategory.Authorization =>
                    "authorization",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerCanceledMerchandise =>
                    "consumer_canceled_merchandise",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerCanceledRecurringTransaction =>
                    "consumer_canceled_recurring_transaction",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerCanceledServices =>
                    "consumer_canceled_services",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerCounterfeitMerchandise =>
                    "consumer_counterfeit_merchandise",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerCreditNotProcessed =>
                    "consumer_credit_not_processed",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerDamagedOrDefectiveMerchandise =>
                    "consumer_damaged_or_defective_merchandise",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerMerchandiseMisrepresentation =>
                    "consumer_merchandise_misrepresentation",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerMerchandiseNotAsDescribed =>
                    "consumer_merchandise_not_as_described",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerMerchandiseNotReceived =>
                    "consumer_merchandise_not_received",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerNonReceiptOfCash =>
                    "consumer_non_receipt_of_cash",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerOriginalCreditTransactionNotAccepted =>
                    "consumer_original_credit_transaction_not_accepted",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerQualityMerchandise =>
                    "consumer_quality_merchandise",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerQualityServices =>
                    "consumer_quality_services",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerServicesMisrepresentation =>
                    "consumer_services_misrepresentation",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerServicesNotAsDescribed =>
                    "consumer_services_not_as_described",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ConsumerServicesNotReceived =>
                    "consumer_services_not_received",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.Fraud => "fraud",
                UserSubmissionUserPrearbitrationCategoryChangeCategory.ProcessingError =>
                    "processing_error",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If the Card Dispute's status is `won`, this will contain details of the won dispute.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Win, WinFromRaw>))]
public sealed record class Win : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Card Dispute was won.
    /// </summary>
    public required System::DateTimeOffset WonAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("won_at");
        }
        init { this._rawData.Set("won_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.WonAt;
    }

    public Win() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Win(Win win)
        : base(win) { }
#pragma warning restore CS8618

    public Win(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Win(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WinFromRaw.FromRawUnchecked"/>
    public static Win FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Win(System::DateTimeOffset wonAt)
        : this()
    {
        this.WonAt = wonAt;
    }
}

class WinFromRaw : IFromRawJson<Win>
{
    /// <inheritdoc/>
    public Win FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Win.FromRawUnchecked(rawData);
}

/// <summary>
/// If the Card Dispute has been withdrawn, this will contain details of the withdrawal.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Withdrawal, WithdrawalFromRaw>))]
public sealed record class Withdrawal : JsonModel
{
    /// <summary>
    /// The explanation for the withdrawal of the Card Dispute.
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Explanation;
    }

    public Withdrawal() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Withdrawal(Withdrawal withdrawal)
        : base(withdrawal) { }
#pragma warning restore CS8618

    public Withdrawal(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Withdrawal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WithdrawalFromRaw.FromRawUnchecked"/>
    public static Withdrawal FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Withdrawal(string? explanation)
        : this()
    {
        this.Explanation = explanation;
    }
}

class WithdrawalFromRaw : IFromRawJson<Withdrawal>
{
    /// <inheritdoc/>
    public Withdrawal FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Withdrawal.FromRawUnchecked(rawData);
}
