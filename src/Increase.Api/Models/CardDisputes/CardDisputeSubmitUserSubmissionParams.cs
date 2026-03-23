using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.CardDisputes;

/// <summary>
/// Submit a User Submission for a Card Dispute
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CardDisputeSubmitUserSubmissionParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CardDisputeID { get; init; }

    /// <summary>
    /// The network of the Card Dispute. Details specific to the network are required
    /// under the sub-object with the same identifier as the network.
    /// </summary>
    public required ApiEnum<string, CardDisputeSubmitUserSubmissionParamsNetwork> Network
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, CardDisputeSubmitUserSubmissionParamsNetwork>
            >("network");
        }
        init { this._rawBodyData.Set("network", value); }
    }

    /// <summary>
    /// The adjusted monetary amount of the part of the transaction that is being
    /// disputed. This is optional and will default to the most recent amount provided.
    /// If provided, the amount must be less than or equal to the amount of the transaction.
    /// </summary>
    public long? Amount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("amount", value);
        }
    }

    /// <summary>
    /// The files to be attached to the user submission.
    /// </summary>
    public IReadOnlyList<CardDisputeSubmitUserSubmissionParamsAttachmentFile>? AttachmentFiles
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<CardDisputeSubmitUserSubmissionParamsAttachmentFile>
            >("attachment_files");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<CardDisputeSubmitUserSubmissionParamsAttachmentFile>?>(
                "attachment_files",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The free-form explanation provided to Increase to provide more context for
    /// the user submission. This field is not sent directly to the card networks.
    /// </summary>
    public string? Explanation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("explanation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("explanation", value);
        }
    }

    /// <summary>
    /// The Visa-specific parameters for the dispute. Required if and only if `network`
    /// is `visa`.
    /// </summary>
    public CardDisputeSubmitUserSubmissionParamsVisa? Visa
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CardDisputeSubmitUserSubmissionParamsVisa>(
                "visa"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("visa", value);
        }
    }

    public CardDisputeSubmitUserSubmissionParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDisputeSubmitUserSubmissionParams(
        CardDisputeSubmitUserSubmissionParams cardDisputeSubmitUserSubmissionParams
    )
        : base(cardDisputeSubmitUserSubmissionParams)
    {
        this.CardDisputeID = cardDisputeSubmitUserSubmissionParams.CardDisputeID;

        this._rawBodyData = new(cardDisputeSubmitUserSubmissionParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CardDisputeSubmitUserSubmissionParams(
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
    CardDisputeSubmitUserSubmissionParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string cardDisputeID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CardDisputeID = cardDisputeID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CardDisputeSubmitUserSubmissionParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string cardDisputeID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            cardDisputeID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CardDisputeID"] = JsonSerializer.SerializeToElement(this.CardDisputeID),
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

    public virtual bool Equals(CardDisputeSubmitUserSubmissionParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CardDisputeID?.Equals(other.CardDisputeID) ?? other.CardDisputeID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/card_disputes/{0}/submit_user_submission", this.CardDisputeID)
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

/// <summary>
/// The network of the Card Dispute. Details specific to the network are required
/// under the sub-object with the same identifier as the network.
/// </summary>
[JsonConverter(typeof(CardDisputeSubmitUserSubmissionParamsNetworkConverter))]
public enum CardDisputeSubmitUserSubmissionParamsNetwork
{
    /// <summary>
    /// Visa
    /// </summary>
    Visa,
}

sealed class CardDisputeSubmitUserSubmissionParamsNetworkConverter
    : JsonConverter<CardDisputeSubmitUserSubmissionParamsNetwork>
{
    public override CardDisputeSubmitUserSubmissionParamsNetwork Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => CardDisputeSubmitUserSubmissionParamsNetwork.Visa,
            _ => (CardDisputeSubmitUserSubmissionParamsNetwork)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDisputeSubmitUserSubmissionParamsNetwork value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDisputeSubmitUserSubmissionParamsNetwork.Visa => "visa",
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
        CardDisputeSubmitUserSubmissionParamsAttachmentFile,
        CardDisputeSubmitUserSubmissionParamsAttachmentFileFromRaw
    >)
)]
public sealed record class CardDisputeSubmitUserSubmissionParamsAttachmentFile : JsonModel
{
    /// <summary>
    /// The ID of the file to be attached. The file must have a `purpose` of `card_dispute_attachment`.
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

    public CardDisputeSubmitUserSubmissionParamsAttachmentFile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDisputeSubmitUserSubmissionParamsAttachmentFile(
        CardDisputeSubmitUserSubmissionParamsAttachmentFile cardDisputeSubmitUserSubmissionParamsAttachmentFile
    )
        : base(cardDisputeSubmitUserSubmissionParamsAttachmentFile) { }
#pragma warning restore CS8618

    public CardDisputeSubmitUserSubmissionParamsAttachmentFile(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDisputeSubmitUserSubmissionParamsAttachmentFile(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDisputeSubmitUserSubmissionParamsAttachmentFileFromRaw.FromRawUnchecked"/>
    public static CardDisputeSubmitUserSubmissionParamsAttachmentFile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardDisputeSubmitUserSubmissionParamsAttachmentFile(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class CardDisputeSubmitUserSubmissionParamsAttachmentFileFromRaw
    : IFromRawJson<CardDisputeSubmitUserSubmissionParamsAttachmentFile>
{
    /// <inheritdoc/>
    public CardDisputeSubmitUserSubmissionParamsAttachmentFile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDisputeSubmitUserSubmissionParamsAttachmentFile.FromRawUnchecked(rawData);
}

/// <summary>
/// The Visa-specific parameters for the dispute. Required if and only if `network`
/// is `visa`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardDisputeSubmitUserSubmissionParamsVisa,
        CardDisputeSubmitUserSubmissionParamsVisaFromRaw
    >)
)]
public sealed record class CardDisputeSubmitUserSubmissionParamsVisa : JsonModel
{
    /// <summary>
    /// The category of the user submission. Details specific to the category are
    /// required under the sub-object with the same identifier as the category.
    /// </summary>
    public required ApiEnum<string, CardDisputeSubmitUserSubmissionParamsVisaCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardDisputeSubmitUserSubmissionParamsVisaCategory>
            >("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// The chargeback details for the user submission. Required if and only if `category`
    /// is `chargeback`.
    /// </summary>
    public Chargeback? Chargeback
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Chargeback>("chargeback");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chargeback", value);
        }
    }

    /// <summary>
    /// The merchant pre-arbitration decline details for the user submission. Required
    /// if and only if `category` is `merchant_prearbitration_decline`.
    /// </summary>
    public MerchantPrearbitrationDecline? MerchantPrearbitrationDecline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MerchantPrearbitrationDecline>(
                "merchant_prearbitration_decline"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("merchant_prearbitration_decline", value);
        }
    }

    /// <summary>
    /// The user pre-arbitration details for the user submission. Required if and
    /// only if `category` is `user_prearbitration`.
    /// </summary>
    public UserPrearbitration? UserPrearbitration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserPrearbitration>("user_prearbitration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user_prearbitration", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.Chargeback?.Validate();
        this.MerchantPrearbitrationDecline?.Validate();
        this.UserPrearbitration?.Validate();
    }

    public CardDisputeSubmitUserSubmissionParamsVisa() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDisputeSubmitUserSubmissionParamsVisa(
        CardDisputeSubmitUserSubmissionParamsVisa cardDisputeSubmitUserSubmissionParamsVisa
    )
        : base(cardDisputeSubmitUserSubmissionParamsVisa) { }
#pragma warning restore CS8618

    public CardDisputeSubmitUserSubmissionParamsVisa(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDisputeSubmitUserSubmissionParamsVisa(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDisputeSubmitUserSubmissionParamsVisaFromRaw.FromRawUnchecked"/>
    public static CardDisputeSubmitUserSubmissionParamsVisa FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardDisputeSubmitUserSubmissionParamsVisa(
        ApiEnum<string, CardDisputeSubmitUserSubmissionParamsVisaCategory> category
    )
        : this()
    {
        this.Category = category;
    }
}

class CardDisputeSubmitUserSubmissionParamsVisaFromRaw
    : IFromRawJson<CardDisputeSubmitUserSubmissionParamsVisa>
{
    /// <inheritdoc/>
    public CardDisputeSubmitUserSubmissionParamsVisa FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDisputeSubmitUserSubmissionParamsVisa.FromRawUnchecked(rawData);
}

/// <summary>
/// The category of the user submission. Details specific to the category are required
/// under the sub-object with the same identifier as the category.
/// </summary>
[JsonConverter(typeof(CardDisputeSubmitUserSubmissionParamsVisaCategoryConverter))]
public enum CardDisputeSubmitUserSubmissionParamsVisaCategory
{
    /// <summary>
    /// Chargeback.
    /// </summary>
    Chargeback,

    /// <summary>
    /// Merchant pre-arbitration decline.
    /// </summary>
    MerchantPrearbitrationDecline,

    /// <summary>
    /// User pre-arbitration.
    /// </summary>
    UserPrearbitration,
}

sealed class CardDisputeSubmitUserSubmissionParamsVisaCategoryConverter
    : JsonConverter<CardDisputeSubmitUserSubmissionParamsVisaCategory>
{
    public override CardDisputeSubmitUserSubmissionParamsVisaCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "chargeback" => CardDisputeSubmitUserSubmissionParamsVisaCategory.Chargeback,
            "merchant_prearbitration_decline" =>
                CardDisputeSubmitUserSubmissionParamsVisaCategory.MerchantPrearbitrationDecline,
            "user_prearbitration" =>
                CardDisputeSubmitUserSubmissionParamsVisaCategory.UserPrearbitration,
            _ => (CardDisputeSubmitUserSubmissionParamsVisaCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDisputeSubmitUserSubmissionParamsVisaCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDisputeSubmitUserSubmissionParamsVisaCategory.Chargeback => "chargeback",
                CardDisputeSubmitUserSubmissionParamsVisaCategory.MerchantPrearbitrationDecline =>
                    "merchant_prearbitration_decline",
                CardDisputeSubmitUserSubmissionParamsVisaCategory.UserPrearbitration =>
                    "user_prearbitration",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The chargeback details for the user submission. Required if and only if `category`
/// is `chargeback`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Chargeback, ChargebackFromRaw>))]
public sealed record class Chargeback : JsonModel
{
    /// <summary>
    /// Category.
    /// </summary>
    public required ApiEnum<string, ChargebackCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ChargebackCategory>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Authorization. Required if and only if `category` is `authorization`.
    /// </summary>
    public ChargebackAuthorization? Authorization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackAuthorization>("authorization");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("authorization", value);
        }
    }

    /// <summary>
    /// Canceled merchandise. Required if and only if `category` is `consumer_canceled_merchandise`.
    /// </summary>
    public ChargebackConsumerCanceledMerchandise? ConsumerCanceledMerchandise
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerCanceledMerchandise>(
                "consumer_canceled_merchandise"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumer_canceled_merchandise", value);
        }
    }

    /// <summary>
    /// Canceled recurring transaction. Required if and only if `category` is `consumer_canceled_recurring_transaction`.
    /// </summary>
    public ChargebackConsumerCanceledRecurringTransaction? ConsumerCanceledRecurringTransaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerCanceledRecurringTransaction>(
                "consumer_canceled_recurring_transaction"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumer_canceled_recurring_transaction", value);
        }
    }

    /// <summary>
    /// Canceled services. Required if and only if `category` is `consumer_canceled_services`.
    /// </summary>
    public ChargebackConsumerCanceledServices? ConsumerCanceledServices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerCanceledServices>(
                "consumer_canceled_services"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumer_canceled_services", value);
        }
    }

    /// <summary>
    /// Counterfeit merchandise. Required if and only if `category` is `consumer_counterfeit_merchandise`.
    /// </summary>
    public ChargebackConsumerCounterfeitMerchandise? ConsumerCounterfeitMerchandise
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerCounterfeitMerchandise>(
                "consumer_counterfeit_merchandise"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumer_counterfeit_merchandise", value);
        }
    }

    /// <summary>
    /// Credit not processed. Required if and only if `category` is `consumer_credit_not_processed`.
    /// </summary>
    public ChargebackConsumerCreditNotProcessed? ConsumerCreditNotProcessed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerCreditNotProcessed>(
                "consumer_credit_not_processed"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumer_credit_not_processed", value);
        }
    }

    /// <summary>
    /// Damaged or defective merchandise. Required if and only if `category` is `consumer_damaged_or_defective_merchandise`.
    /// </summary>
    public ChargebackConsumerDamagedOrDefectiveMerchandise? ConsumerDamagedOrDefectiveMerchandise
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerDamagedOrDefectiveMerchandise>(
                "consumer_damaged_or_defective_merchandise"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumer_damaged_or_defective_merchandise", value);
        }
    }

    /// <summary>
    /// Merchandise misrepresentation. Required if and only if `category` is `consumer_merchandise_misrepresentation`.
    /// </summary>
    public ChargebackConsumerMerchandiseMisrepresentation? ConsumerMerchandiseMisrepresentation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerMerchandiseMisrepresentation>(
                "consumer_merchandise_misrepresentation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumer_merchandise_misrepresentation", value);
        }
    }

    /// <summary>
    /// Merchandise not as described. Required if and only if `category` is `consumer_merchandise_not_as_described`.
    /// </summary>
    public ChargebackConsumerMerchandiseNotAsDescribed? ConsumerMerchandiseNotAsDescribed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerMerchandiseNotAsDescribed>(
                "consumer_merchandise_not_as_described"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumer_merchandise_not_as_described", value);
        }
    }

    /// <summary>
    /// Merchandise not received. Required if and only if `category` is `consumer_merchandise_not_received`.
    /// </summary>
    public ChargebackConsumerMerchandiseNotReceived? ConsumerMerchandiseNotReceived
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerMerchandiseNotReceived>(
                "consumer_merchandise_not_received"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumer_merchandise_not_received", value);
        }
    }

    /// <summary>
    /// Non-receipt of cash. Required if and only if `category` is `consumer_non_receipt_of_cash`.
    /// </summary>
    public ChargebackConsumerNonReceiptOfCash? ConsumerNonReceiptOfCash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerNonReceiptOfCash>(
                "consumer_non_receipt_of_cash"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumer_non_receipt_of_cash", value);
        }
    }

    /// <summary>
    /// Original Credit Transaction (OCT) not accepted. Required if and only if `category`
    /// is `consumer_original_credit_transaction_not_accepted`.
    /// </summary>
    public ChargebackConsumerOriginalCreditTransactionNotAccepted? ConsumerOriginalCreditTransactionNotAccepted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerOriginalCreditTransactionNotAccepted>(
                "consumer_original_credit_transaction_not_accepted"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumer_original_credit_transaction_not_accepted", value);
        }
    }

    /// <summary>
    /// Merchandise quality issue. Required if and only if `category` is `consumer_quality_merchandise`.
    /// </summary>
    public ChargebackConsumerQualityMerchandise? ConsumerQualityMerchandise
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerQualityMerchandise>(
                "consumer_quality_merchandise"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumer_quality_merchandise", value);
        }
    }

    /// <summary>
    /// Services quality issue. Required if and only if `category` is `consumer_quality_services`.
    /// </summary>
    public ChargebackConsumerQualityServices? ConsumerQualityServices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerQualityServices>(
                "consumer_quality_services"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumer_quality_services", value);
        }
    }

    /// <summary>
    /// Services misrepresentation. Required if and only if `category` is `consumer_services_misrepresentation`.
    /// </summary>
    public ChargebackConsumerServicesMisrepresentation? ConsumerServicesMisrepresentation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerServicesMisrepresentation>(
                "consumer_services_misrepresentation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumer_services_misrepresentation", value);
        }
    }

    /// <summary>
    /// Services not as described. Required if and only if `category` is `consumer_services_not_as_described`.
    /// </summary>
    public ChargebackConsumerServicesNotAsDescribed? ConsumerServicesNotAsDescribed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerServicesNotAsDescribed>(
                "consumer_services_not_as_described"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumer_services_not_as_described", value);
        }
    }

    /// <summary>
    /// Services not received. Required if and only if `category` is `consumer_services_not_received`.
    /// </summary>
    public ChargebackConsumerServicesNotReceived? ConsumerServicesNotReceived
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerServicesNotReceived>(
                "consumer_services_not_received"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumer_services_not_received", value);
        }
    }

    /// <summary>
    /// Fraud. Required if and only if `category` is `fraud`.
    /// </summary>
    public ChargebackFraud? Fraud
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackFraud>("fraud");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fraud", value);
        }
    }

    /// <summary>
    /// Processing error. Required if and only if `category` is `processing_error`.
    /// </summary>
    public ChargebackProcessingError? ProcessingError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackProcessingError>("processing_error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("processing_error", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.Authorization?.Validate();
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

    public Chargeback() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Chargeback(Chargeback chargeback)
        : base(chargeback) { }
#pragma warning restore CS8618

    public Chargeback(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Chargeback(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackFromRaw.FromRawUnchecked"/>
    public static Chargeback FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Chargeback(ApiEnum<string, ChargebackCategory> category)
        : this()
    {
        this.Category = category;
    }
}

class ChargebackFromRaw : IFromRawJson<Chargeback>
{
    /// <inheritdoc/>
    public Chargeback FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Chargeback.FromRawUnchecked(rawData);
}

/// <summary>
/// Category.
/// </summary>
[JsonConverter(typeof(ChargebackCategoryConverter))]
public enum ChargebackCategory
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

sealed class ChargebackCategoryConverter : JsonConverter<ChargebackCategory>
{
    public override ChargebackCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "authorization" => ChargebackCategory.Authorization,
            "consumer_canceled_merchandise" => ChargebackCategory.ConsumerCanceledMerchandise,
            "consumer_canceled_recurring_transaction" =>
                ChargebackCategory.ConsumerCanceledRecurringTransaction,
            "consumer_canceled_services" => ChargebackCategory.ConsumerCanceledServices,
            "consumer_counterfeit_merchandise" => ChargebackCategory.ConsumerCounterfeitMerchandise,
            "consumer_credit_not_processed" => ChargebackCategory.ConsumerCreditNotProcessed,
            "consumer_damaged_or_defective_merchandise" =>
                ChargebackCategory.ConsumerDamagedOrDefectiveMerchandise,
            "consumer_merchandise_misrepresentation" =>
                ChargebackCategory.ConsumerMerchandiseMisrepresentation,
            "consumer_merchandise_not_as_described" =>
                ChargebackCategory.ConsumerMerchandiseNotAsDescribed,
            "consumer_merchandise_not_received" =>
                ChargebackCategory.ConsumerMerchandiseNotReceived,
            "consumer_non_receipt_of_cash" => ChargebackCategory.ConsumerNonReceiptOfCash,
            "consumer_original_credit_transaction_not_accepted" =>
                ChargebackCategory.ConsumerOriginalCreditTransactionNotAccepted,
            "consumer_quality_merchandise" => ChargebackCategory.ConsumerQualityMerchandise,
            "consumer_quality_services" => ChargebackCategory.ConsumerQualityServices,
            "consumer_services_misrepresentation" =>
                ChargebackCategory.ConsumerServicesMisrepresentation,
            "consumer_services_not_as_described" =>
                ChargebackCategory.ConsumerServicesNotAsDescribed,
            "consumer_services_not_received" => ChargebackCategory.ConsumerServicesNotReceived,
            "fraud" => ChargebackCategory.Fraud,
            "processing_error" => ChargebackCategory.ProcessingError,
            _ => (ChargebackCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackCategory.Authorization => "authorization",
                ChargebackCategory.ConsumerCanceledMerchandise => "consumer_canceled_merchandise",
                ChargebackCategory.ConsumerCanceledRecurringTransaction =>
                    "consumer_canceled_recurring_transaction",
                ChargebackCategory.ConsumerCanceledServices => "consumer_canceled_services",
                ChargebackCategory.ConsumerCounterfeitMerchandise =>
                    "consumer_counterfeit_merchandise",
                ChargebackCategory.ConsumerCreditNotProcessed => "consumer_credit_not_processed",
                ChargebackCategory.ConsumerDamagedOrDefectiveMerchandise =>
                    "consumer_damaged_or_defective_merchandise",
                ChargebackCategory.ConsumerMerchandiseMisrepresentation =>
                    "consumer_merchandise_misrepresentation",
                ChargebackCategory.ConsumerMerchandiseNotAsDescribed =>
                    "consumer_merchandise_not_as_described",
                ChargebackCategory.ConsumerMerchandiseNotReceived =>
                    "consumer_merchandise_not_received",
                ChargebackCategory.ConsumerNonReceiptOfCash => "consumer_non_receipt_of_cash",
                ChargebackCategory.ConsumerOriginalCreditTransactionNotAccepted =>
                    "consumer_original_credit_transaction_not_accepted",
                ChargebackCategory.ConsumerQualityMerchandise => "consumer_quality_merchandise",
                ChargebackCategory.ConsumerQualityServices => "consumer_quality_services",
                ChargebackCategory.ConsumerServicesMisrepresentation =>
                    "consumer_services_misrepresentation",
                ChargebackCategory.ConsumerServicesNotAsDescribed =>
                    "consumer_services_not_as_described",
                ChargebackCategory.ConsumerServicesNotReceived => "consumer_services_not_received",
                ChargebackCategory.Fraud => "fraud",
                ChargebackCategory.ProcessingError => "processing_error",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Authorization. Required if and only if `category` is `authorization`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChargebackAuthorization, ChargebackAuthorizationFromRaw>))]
public sealed record class ChargebackAuthorization : JsonModel
{
    /// <summary>
    /// Account status.
    /// </summary>
    public required ApiEnum<string, ChargebackAuthorizationAccountStatus> AccountStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackAuthorizationAccountStatus>
            >("account_status");
        }
        init { this._rawData.Set("account_status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccountStatus.Validate();
    }

    public ChargebackAuthorization() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackAuthorization(ChargebackAuthorization chargebackAuthorization)
        : base(chargebackAuthorization) { }
#pragma warning restore CS8618

    public ChargebackAuthorization(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackAuthorization(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackAuthorizationFromRaw.FromRawUnchecked"/>
    public static ChargebackAuthorization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChargebackAuthorization(
        ApiEnum<string, ChargebackAuthorizationAccountStatus> accountStatus
    )
        : this()
    {
        this.AccountStatus = accountStatus;
    }
}

class ChargebackAuthorizationFromRaw : IFromRawJson<ChargebackAuthorization>
{
    /// <inheritdoc/>
    public ChargebackAuthorization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackAuthorization.FromRawUnchecked(rawData);
}

/// <summary>
/// Account status.
/// </summary>
[JsonConverter(typeof(ChargebackAuthorizationAccountStatusConverter))]
public enum ChargebackAuthorizationAccountStatus
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

sealed class ChargebackAuthorizationAccountStatusConverter
    : JsonConverter<ChargebackAuthorizationAccountStatus>
{
    public override ChargebackAuthorizationAccountStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_closed" => ChargebackAuthorizationAccountStatus.AccountClosed,
            "credit_problem" => ChargebackAuthorizationAccountStatus.CreditProblem,
            "fraud" => ChargebackAuthorizationAccountStatus.Fraud,
            _ => (ChargebackAuthorizationAccountStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackAuthorizationAccountStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackAuthorizationAccountStatus.AccountClosed => "account_closed",
                ChargebackAuthorizationAccountStatus.CreditProblem => "credit_problem",
                ChargebackAuthorizationAccountStatus.Fraud => "fraud",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Canceled merchandise. Required if and only if `category` is `consumer_canceled_merchandise`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerCanceledMerchandise,
        ChargebackConsumerCanceledMerchandiseFromRaw
    >)
)]
public sealed record class ChargebackConsumerCanceledMerchandise : JsonModel
{
    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted>
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
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
    /// Return outcome.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerCanceledMerchandiseReturnOutcome
    > ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnOutcome>
            >("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Cardholder cancellation.
    /// </summary>
    public ChargebackConsumerCanceledMerchandiseCardholderCancellation? CardholderCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerCanceledMerchandiseCardholderCancellation>(
                "cardholder_cancellation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cardholder_cancellation", value);
        }
    }

    /// <summary>
    /// Not returned. Required if and only if `return_outcome` is `not_returned`.
    /// </summary>
    public ChargebackConsumerCanceledMerchandiseNotReturned? NotReturned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerCanceledMerchandiseNotReturned>(
                "not_returned"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("not_returned", value);
        }
    }

    /// <summary>
    /// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
    /// </summary>
    public ChargebackConsumerCanceledMerchandiseReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerCanceledMerchandiseReturnAttempted>(
                "return_attempted"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("return_attempted", value);
        }
    }

    /// <summary>
    /// Returned. Required if and only if `return_outcome` is `returned`.
    /// </summary>
    public ChargebackConsumerCanceledMerchandiseReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerCanceledMerchandiseReturned>(
                "returned"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("returned", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MerchantResolutionAttempted.Validate();
        _ = this.PurchaseExplanation;
        _ = this.ReceivedOrExpectedAt;
        this.ReturnOutcome.Validate();
        this.CardholderCancellation?.Validate();
        this.NotReturned?.Validate();
        this.ReturnAttempted?.Validate();
        this.Returned?.Validate();
    }

    public ChargebackConsumerCanceledMerchandise() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerCanceledMerchandise(
        ChargebackConsumerCanceledMerchandise chargebackConsumerCanceledMerchandise
    )
        : base(chargebackConsumerCanceledMerchandise) { }
#pragma warning restore CS8618

    public ChargebackConsumerCanceledMerchandise(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerCanceledMerchandise(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerCanceledMerchandiseFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerCanceledMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerCanceledMerchandiseFromRaw
    : IFromRawJson<ChargebackConsumerCanceledMerchandise>
{
    /// <inheritdoc/>
    public ChargebackConsumerCanceledMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerCanceledMerchandise.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerCanceledMerchandiseMerchantResolutionAttemptedConverter))]
public enum ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted
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

sealed class ChargebackConsumerCanceledMerchandiseMerchantResolutionAttemptedConverter
    : JsonConverter<ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted>
{
    public override ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted =>
                    "attempted",
                ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
/// Return outcome.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerCanceledMerchandiseReturnOutcomeConverter))]
public enum ChargebackConsumerCanceledMerchandiseReturnOutcome
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

sealed class ChargebackConsumerCanceledMerchandiseReturnOutcomeConverter
    : JsonConverter<ChargebackConsumerCanceledMerchandiseReturnOutcome>
{
    public override ChargebackConsumerCanceledMerchandiseReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_returned" => ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
            "returned" => ChargebackConsumerCanceledMerchandiseReturnOutcome.Returned,
            "return_attempted" =>
                ChargebackConsumerCanceledMerchandiseReturnOutcome.ReturnAttempted,
            _ => (ChargebackConsumerCanceledMerchandiseReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerCanceledMerchandiseReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned => "not_returned",
                ChargebackConsumerCanceledMerchandiseReturnOutcome.Returned => "returned",
                ChargebackConsumerCanceledMerchandiseReturnOutcome.ReturnAttempted =>
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
/// Cardholder cancellation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerCanceledMerchandiseCardholderCancellation,
        ChargebackConsumerCanceledMerchandiseCardholderCancellationFromRaw
    >)
)]
public sealed record class ChargebackConsumerCanceledMerchandiseCardholderCancellation : JsonModel
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
        ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate
    > CanceledPriorToShipDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate
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
        ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided
    > CancellationPolicyProvided
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided
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

    public ChargebackConsumerCanceledMerchandiseCardholderCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerCanceledMerchandiseCardholderCancellation(
        ChargebackConsumerCanceledMerchandiseCardholderCancellation chargebackConsumerCanceledMerchandiseCardholderCancellation
    )
        : base(chargebackConsumerCanceledMerchandiseCardholderCancellation) { }
#pragma warning restore CS8618

    public ChargebackConsumerCanceledMerchandiseCardholderCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerCanceledMerchandiseCardholderCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerCanceledMerchandiseCardholderCancellationFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerCanceledMerchandiseCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerCanceledMerchandiseCardholderCancellationFromRaw
    : IFromRawJson<ChargebackConsumerCanceledMerchandiseCardholderCancellation>
{
    /// <inheritdoc/>
    public ChargebackConsumerCanceledMerchandiseCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerCanceledMerchandiseCardholderCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// Canceled prior to ship date.
/// </summary>
[JsonConverter(
    typeof(ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDateConverter)
)]
public enum ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate
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

sealed class ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDateConverter
    : JsonConverter<ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate>
{
    public override ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "canceled_prior_to_ship_date" =>
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
            "not_canceled_prior_to_ship_date" =>
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.NotCanceledPriorToShipDate,
            _ =>
                (ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate =>
                    "canceled_prior_to_ship_date",
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.NotCanceledPriorToShipDate =>
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
    typeof(ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvidedConverter)
)]
public enum ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided
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

sealed class ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvidedConverter
    : JsonConverter<ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided>
{
    public override ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_provided" =>
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
            "provided" =>
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.Provided,
            _ =>
                (ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided =>
                    "not_provided",
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.Provided =>
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
/// Not returned. Required if and only if `return_outcome` is `not_returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerCanceledMerchandiseNotReturned,
        ChargebackConsumerCanceledMerchandiseNotReturnedFromRaw
    >)
)]
public sealed record class ChargebackConsumerCanceledMerchandiseNotReturned : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ChargebackConsumerCanceledMerchandiseNotReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerCanceledMerchandiseNotReturned(
        ChargebackConsumerCanceledMerchandiseNotReturned chargebackConsumerCanceledMerchandiseNotReturned
    )
        : base(chargebackConsumerCanceledMerchandiseNotReturned) { }
#pragma warning restore CS8618

    public ChargebackConsumerCanceledMerchandiseNotReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerCanceledMerchandiseNotReturned(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerCanceledMerchandiseNotReturnedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerCanceledMerchandiseNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerCanceledMerchandiseNotReturnedFromRaw
    : IFromRawJson<ChargebackConsumerCanceledMerchandiseNotReturned>
{
    /// <inheritdoc/>
    public ChargebackConsumerCanceledMerchandiseNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerCanceledMerchandiseNotReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerCanceledMerchandiseReturnAttempted,
        ChargebackConsumerCanceledMerchandiseReturnAttemptedFromRaw
    >)
)]
public sealed record class ChargebackConsumerCanceledMerchandiseReturnAttempted : JsonModel
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
        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason
    > AttemptReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason>
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

    public ChargebackConsumerCanceledMerchandiseReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerCanceledMerchandiseReturnAttempted(
        ChargebackConsumerCanceledMerchandiseReturnAttempted chargebackConsumerCanceledMerchandiseReturnAttempted
    )
        : base(chargebackConsumerCanceledMerchandiseReturnAttempted) { }
#pragma warning restore CS8618

    public ChargebackConsumerCanceledMerchandiseReturnAttempted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerCanceledMerchandiseReturnAttempted(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerCanceledMerchandiseReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerCanceledMerchandiseReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerCanceledMerchandiseReturnAttemptedFromRaw
    : IFromRawJson<ChargebackConsumerCanceledMerchandiseReturnAttempted>
{
    /// <inheritdoc/>
    public ChargebackConsumerCanceledMerchandiseReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerCanceledMerchandiseReturnAttempted.FromRawUnchecked(rawData);
}

/// <summary>
/// Attempt reason.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReasonConverter))]
public enum ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason
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

sealed class ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReasonConverter
    : JsonConverter<ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason>
{
    public override ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merchant_not_responding" =>
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            "no_return_authorization_provided" =>
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided,
            "no_return_instructions" =>
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions,
            "requested_not_to_return" =>
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn,
            "return_not_accepted" =>
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted,
            _ => (ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding =>
                    "merchant_not_responding",
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided =>
                    "no_return_authorization_provided",
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions =>
                    "no_return_instructions",
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn =>
                    "requested_not_to_return",
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted =>
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
/// Returned. Required if and only if `return_outcome` is `returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerCanceledMerchandiseReturned,
        ChargebackConsumerCanceledMerchandiseReturnedFromRaw
    >)
)]
public sealed record class ChargebackConsumerCanceledMerchandiseReturned : JsonModel
{
    /// <summary>
    /// Return method.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerCanceledMerchandiseReturnedReturnMethod
    > ReturnMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnedReturnMethod>
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
    /// Merchant received return at.
    /// </summary>
    public string? MerchantReceivedReturnAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_received_return_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("merchant_received_return_at", value);
        }
    }

    /// <summary>
    /// Other explanation. Required if and only if the return method is `other`.
    /// </summary>
    public string? OtherExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("other_explanation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("other_explanation", value);
        }
    }

    /// <summary>
    /// Tracking number.
    /// </summary>
    public string? TrackingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tracking_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tracking_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ReturnMethod.Validate();
        _ = this.ReturnedAt;
        _ = this.MerchantReceivedReturnAt;
        _ = this.OtherExplanation;
        _ = this.TrackingNumber;
    }

    public ChargebackConsumerCanceledMerchandiseReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerCanceledMerchandiseReturned(
        ChargebackConsumerCanceledMerchandiseReturned chargebackConsumerCanceledMerchandiseReturned
    )
        : base(chargebackConsumerCanceledMerchandiseReturned) { }
#pragma warning restore CS8618

    public ChargebackConsumerCanceledMerchandiseReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerCanceledMerchandiseReturned(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerCanceledMerchandiseReturnedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerCanceledMerchandiseReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerCanceledMerchandiseReturnedFromRaw
    : IFromRawJson<ChargebackConsumerCanceledMerchandiseReturned>
{
    /// <inheritdoc/>
    public ChargebackConsumerCanceledMerchandiseReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerCanceledMerchandiseReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return method.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerCanceledMerchandiseReturnedReturnMethodConverter))]
public enum ChargebackConsumerCanceledMerchandiseReturnedReturnMethod
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

sealed class ChargebackConsumerCanceledMerchandiseReturnedReturnMethodConverter
    : JsonConverter<ChargebackConsumerCanceledMerchandiseReturnedReturnMethod>
{
    public override ChargebackConsumerCanceledMerchandiseReturnedReturnMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dhl" => ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
            "face_to_face" => ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.FaceToFace,
            "fedex" => ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Fedex,
            "other" => ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Other,
            "postal_service" =>
                ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.PostalService,
            "ups" => ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Ups,
            _ => (ChargebackConsumerCanceledMerchandiseReturnedReturnMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerCanceledMerchandiseReturnedReturnMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl => "dhl",
                ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.FaceToFace =>
                    "face_to_face",
                ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Fedex => "fedex",
                ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Other => "other",
                ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.PostalService =>
                    "postal_service",
                ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Ups => "ups",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Canceled recurring transaction. Required if and only if `category` is `consumer_canceled_recurring_transaction`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerCanceledRecurringTransaction,
        ChargebackConsumerCanceledRecurringTransactionFromRaw
    >)
)]
public sealed record class ChargebackConsumerCanceledRecurringTransaction : JsonModel
{
    /// <summary>
    /// Cancellation target.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerCanceledRecurringTransactionCancellationTarget
    > CancellationTarget
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerCanceledRecurringTransactionCancellationTarget>
            >("cancellation_target");
        }
        init { this._rawData.Set("cancellation_target", value); }
    }

    /// <summary>
    /// Merchant contact methods.
    /// </summary>
    public required ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods MerchantContactMethods
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods>(
                "merchant_contact_methods"
            );
        }
        init { this._rawData.Set("merchant_contact_methods", value); }
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

    /// <summary>
    /// Other form of payment explanation.
    /// </summary>
    public string? OtherFormOfPaymentExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("other_form_of_payment_explanation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("other_form_of_payment_explanation", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CancellationTarget.Validate();
        this.MerchantContactMethods.Validate();
        _ = this.TransactionOrAccountCanceledAt;
        _ = this.OtherFormOfPaymentExplanation;
    }

    public ChargebackConsumerCanceledRecurringTransaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerCanceledRecurringTransaction(
        ChargebackConsumerCanceledRecurringTransaction chargebackConsumerCanceledRecurringTransaction
    )
        : base(chargebackConsumerCanceledRecurringTransaction) { }
#pragma warning restore CS8618

    public ChargebackConsumerCanceledRecurringTransaction(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerCanceledRecurringTransaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerCanceledRecurringTransactionFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerCanceledRecurringTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerCanceledRecurringTransactionFromRaw
    : IFromRawJson<ChargebackConsumerCanceledRecurringTransaction>
{
    /// <inheritdoc/>
    public ChargebackConsumerCanceledRecurringTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerCanceledRecurringTransaction.FromRawUnchecked(rawData);
}

/// <summary>
/// Cancellation target.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerCanceledRecurringTransactionCancellationTargetConverter))]
public enum ChargebackConsumerCanceledRecurringTransactionCancellationTarget
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

sealed class ChargebackConsumerCanceledRecurringTransactionCancellationTargetConverter
    : JsonConverter<ChargebackConsumerCanceledRecurringTransactionCancellationTarget>
{
    public override ChargebackConsumerCanceledRecurringTransactionCancellationTarget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account" => ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
            "transaction" =>
                ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Transaction,
            _ => (ChargebackConsumerCanceledRecurringTransactionCancellationTarget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerCanceledRecurringTransactionCancellationTarget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account =>
                    "account",
                ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Transaction =>
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
        ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods,
        ChargebackConsumerCanceledRecurringTransactionMerchantContactMethodsFromRaw
    >)
)]
public sealed record class ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods
    : JsonModel
{
    /// <summary>
    /// Application name.
    /// </summary>
    public string? ApplicationName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("application_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("application_name", value);
        }
    }

    /// <summary>
    /// Call center phone number.
    /// </summary>
    public string? CallCenterPhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("call_center_phone_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("call_center_phone_number", value);
        }
    }

    /// <summary>
    /// Email address.
    /// </summary>
    public string? EmailAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email_address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email_address", value);
        }
    }

    /// <summary>
    /// In person address.
    /// </summary>
    public string? InPersonAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("in_person_address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("in_person_address", value);
        }
    }

    /// <summary>
    /// Mailing address.
    /// </summary>
    public string? MailingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mailing_address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mailing_address", value);
        }
    }

    /// <summary>
    /// Text phone number.
    /// </summary>
    public string? TextPhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_phone_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text_phone_number", value);
        }
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

    public ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods(
        ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods chargebackConsumerCanceledRecurringTransactionMerchantContactMethods
    )
        : base(chargebackConsumerCanceledRecurringTransactionMerchantContactMethods) { }
#pragma warning restore CS8618

    public ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerCanceledRecurringTransactionMerchantContactMethodsFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerCanceledRecurringTransactionMerchantContactMethodsFromRaw
    : IFromRawJson<ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods>
{
    /// <inheritdoc/>
    public ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Canceled services. Required if and only if `category` is `consumer_canceled_services`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerCanceledServices,
        ChargebackConsumerCanceledServicesFromRaw
    >)
)]
public sealed record class ChargebackConsumerCanceledServices : JsonModel
{
    /// <summary>
    /// Cardholder cancellation.
    /// </summary>
    public required ChargebackConsumerCanceledServicesCardholderCancellation CardholderCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ChargebackConsumerCanceledServicesCardholderCancellation>(
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
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerCanceledServicesMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerCanceledServicesMerchantResolutionAttempted>
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
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
    public required ApiEnum<string, ChargebackConsumerCanceledServicesServiceType> ServiceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerCanceledServicesServiceType>
            >("service_type");
        }
        init { this._rawData.Set("service_type", value); }
    }

    /// <summary>
    /// Guaranteed reservation explanation. Required if and only if `service_type`
    /// is `guaranteed_reservation`.
    /// </summary>
    public ChargebackConsumerCanceledServicesGuaranteedReservation? GuaranteedReservation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerCanceledServicesGuaranteedReservation>(
                "guaranteed_reservation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("guaranteed_reservation", value);
        }
    }

    /// <summary>
    /// Other service type explanation. Required if and only if `service_type` is `other`.
    /// </summary>
    public ChargebackConsumerCanceledServicesOther? Other
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerCanceledServicesOther>("other");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("other", value);
        }
    }

    /// <summary>
    /// Timeshare explanation. Required if and only if `service_type` is `timeshare`.
    /// </summary>
    public ChargebackConsumerCanceledServicesTimeshare? Timeshare
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerCanceledServicesTimeshare>(
                "timeshare"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timeshare", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CardholderCancellation.Validate();
        _ = this.ContractedAt;
        this.MerchantResolutionAttempted.Validate();
        _ = this.PurchaseExplanation;
        this.ServiceType.Validate();
        this.GuaranteedReservation?.Validate();
        this.Other?.Validate();
        this.Timeshare?.Validate();
    }

    public ChargebackConsumerCanceledServices() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerCanceledServices(
        ChargebackConsumerCanceledServices chargebackConsumerCanceledServices
    )
        : base(chargebackConsumerCanceledServices) { }
#pragma warning restore CS8618

    public ChargebackConsumerCanceledServices(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerCanceledServices(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerCanceledServicesFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerCanceledServices FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerCanceledServicesFromRaw : IFromRawJson<ChargebackConsumerCanceledServices>
{
    /// <inheritdoc/>
    public ChargebackConsumerCanceledServices FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerCanceledServices.FromRawUnchecked(rawData);
}

/// <summary>
/// Cardholder cancellation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerCanceledServicesCardholderCancellation,
        ChargebackConsumerCanceledServicesCardholderCancellationFromRaw
    >)
)]
public sealed record class ChargebackConsumerCanceledServicesCardholderCancellation : JsonModel
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
        ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
    > CancellationPolicyProvided
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
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

    public ChargebackConsumerCanceledServicesCardholderCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerCanceledServicesCardholderCancellation(
        ChargebackConsumerCanceledServicesCardholderCancellation chargebackConsumerCanceledServicesCardholderCancellation
    )
        : base(chargebackConsumerCanceledServicesCardholderCancellation) { }
#pragma warning restore CS8618

    public ChargebackConsumerCanceledServicesCardholderCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerCanceledServicesCardholderCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerCanceledServicesCardholderCancellationFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerCanceledServicesCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerCanceledServicesCardholderCancellationFromRaw
    : IFromRawJson<ChargebackConsumerCanceledServicesCardholderCancellation>
{
    /// <inheritdoc/>
    public ChargebackConsumerCanceledServicesCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerCanceledServicesCardholderCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// Cancellation policy provided.
/// </summary>
[JsonConverter(
    typeof(ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvidedConverter)
)]
public enum ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
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

sealed class ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvidedConverter
    : JsonConverter<ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided>
{
    public override ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_provided" =>
                ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
            "provided" =>
                ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.Provided,
            _ =>
                (ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided =>
                    "not_provided",
                ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.Provided =>
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
[JsonConverter(typeof(ChargebackConsumerCanceledServicesMerchantResolutionAttemptedConverter))]
public enum ChargebackConsumerCanceledServicesMerchantResolutionAttempted
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

sealed class ChargebackConsumerCanceledServicesMerchantResolutionAttemptedConverter
    : JsonConverter<ChargebackConsumerCanceledServicesMerchantResolutionAttempted>
{
    public override ChargebackConsumerCanceledServicesMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" => ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ChargebackConsumerCanceledServicesMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ChargebackConsumerCanceledServicesMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerCanceledServicesMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted =>
                    "attempted",
                ChargebackConsumerCanceledServicesMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
/// Service type.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerCanceledServicesServiceTypeConverter))]
public enum ChargebackConsumerCanceledServicesServiceType
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

sealed class ChargebackConsumerCanceledServicesServiceTypeConverter
    : JsonConverter<ChargebackConsumerCanceledServicesServiceType>
{
    public override ChargebackConsumerCanceledServicesServiceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "guaranteed_reservation" =>
                ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
            "other" => ChargebackConsumerCanceledServicesServiceType.Other,
            "timeshare" => ChargebackConsumerCanceledServicesServiceType.Timeshare,
            _ => (ChargebackConsumerCanceledServicesServiceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerCanceledServicesServiceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation =>
                    "guaranteed_reservation",
                ChargebackConsumerCanceledServicesServiceType.Other => "other",
                ChargebackConsumerCanceledServicesServiceType.Timeshare => "timeshare",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Guaranteed reservation explanation. Required if and only if `service_type` is `guaranteed_reservation`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerCanceledServicesGuaranteedReservation,
        ChargebackConsumerCanceledServicesGuaranteedReservationFromRaw
    >)
)]
public sealed record class ChargebackConsumerCanceledServicesGuaranteedReservation : JsonModel
{
    /// <summary>
    /// Explanation.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerCanceledServicesGuaranteedReservationExplanation
    > Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerCanceledServicesGuaranteedReservationExplanation>
            >("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Explanation.Validate();
    }

    public ChargebackConsumerCanceledServicesGuaranteedReservation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerCanceledServicesGuaranteedReservation(
        ChargebackConsumerCanceledServicesGuaranteedReservation chargebackConsumerCanceledServicesGuaranteedReservation
    )
        : base(chargebackConsumerCanceledServicesGuaranteedReservation) { }
#pragma warning restore CS8618

    public ChargebackConsumerCanceledServicesGuaranteedReservation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerCanceledServicesGuaranteedReservation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerCanceledServicesGuaranteedReservationFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerCanceledServicesGuaranteedReservation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChargebackConsumerCanceledServicesGuaranteedReservation(
        ApiEnum<
            string,
            ChargebackConsumerCanceledServicesGuaranteedReservationExplanation
        > explanation
    )
        : this()
    {
        this.Explanation = explanation;
    }
}

class ChargebackConsumerCanceledServicesGuaranteedReservationFromRaw
    : IFromRawJson<ChargebackConsumerCanceledServicesGuaranteedReservation>
{
    /// <inheritdoc/>
    public ChargebackConsumerCanceledServicesGuaranteedReservation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerCanceledServicesGuaranteedReservation.FromRawUnchecked(rawData);
}

/// <summary>
/// Explanation.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerCanceledServicesGuaranteedReservationExplanationConverter))]
public enum ChargebackConsumerCanceledServicesGuaranteedReservationExplanation
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

sealed class ChargebackConsumerCanceledServicesGuaranteedReservationExplanationConverter
    : JsonConverter<ChargebackConsumerCanceledServicesGuaranteedReservationExplanation>
{
    public override ChargebackConsumerCanceledServicesGuaranteedReservationExplanation Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cardholder_canceled_prior_to_service" =>
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService,
            "cardholder_cancellation_attempt_within_24_hours_of_confirmation" =>
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCancellationAttemptWithin24HoursOfConfirmation,
            "merchant_billed_no_show" =>
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.MerchantBilledNoShow,
            _ => (ChargebackConsumerCanceledServicesGuaranteedReservationExplanation)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerCanceledServicesGuaranteedReservationExplanation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService =>
                    "cardholder_canceled_prior_to_service",
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCancellationAttemptWithin24HoursOfConfirmation =>
                    "cardholder_cancellation_attempt_within_24_hours_of_confirmation",
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.MerchantBilledNoShow =>
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
/// Other service type explanation. Required if and only if `service_type` is `other`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerCanceledServicesOther,
        ChargebackConsumerCanceledServicesOtherFromRaw
    >)
)]
public sealed record class ChargebackConsumerCanceledServicesOther : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ChargebackConsumerCanceledServicesOther() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerCanceledServicesOther(
        ChargebackConsumerCanceledServicesOther chargebackConsumerCanceledServicesOther
    )
        : base(chargebackConsumerCanceledServicesOther) { }
#pragma warning restore CS8618

    public ChargebackConsumerCanceledServicesOther(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerCanceledServicesOther(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerCanceledServicesOtherFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerCanceledServicesOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerCanceledServicesOtherFromRaw
    : IFromRawJson<ChargebackConsumerCanceledServicesOther>
{
    /// <inheritdoc/>
    public ChargebackConsumerCanceledServicesOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerCanceledServicesOther.FromRawUnchecked(rawData);
}

/// <summary>
/// Timeshare explanation. Required if and only if `service_type` is `timeshare`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerCanceledServicesTimeshare,
        ChargebackConsumerCanceledServicesTimeshareFromRaw
    >)
)]
public sealed record class ChargebackConsumerCanceledServicesTimeshare : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ChargebackConsumerCanceledServicesTimeshare() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerCanceledServicesTimeshare(
        ChargebackConsumerCanceledServicesTimeshare chargebackConsumerCanceledServicesTimeshare
    )
        : base(chargebackConsumerCanceledServicesTimeshare) { }
#pragma warning restore CS8618

    public ChargebackConsumerCanceledServicesTimeshare(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerCanceledServicesTimeshare(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerCanceledServicesTimeshareFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerCanceledServicesTimeshare FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerCanceledServicesTimeshareFromRaw
    : IFromRawJson<ChargebackConsumerCanceledServicesTimeshare>
{
    /// <inheritdoc/>
    public ChargebackConsumerCanceledServicesTimeshare FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerCanceledServicesTimeshare.FromRawUnchecked(rawData);
}

/// <summary>
/// Counterfeit merchandise. Required if and only if `category` is `consumer_counterfeit_merchandise`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerCounterfeitMerchandise,
        ChargebackConsumerCounterfeitMerchandiseFromRaw
    >)
)]
public sealed record class ChargebackConsumerCounterfeitMerchandise : JsonModel
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

    public ChargebackConsumerCounterfeitMerchandise() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerCounterfeitMerchandise(
        ChargebackConsumerCounterfeitMerchandise chargebackConsumerCounterfeitMerchandise
    )
        : base(chargebackConsumerCounterfeitMerchandise) { }
#pragma warning restore CS8618

    public ChargebackConsumerCounterfeitMerchandise(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerCounterfeitMerchandise(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerCounterfeitMerchandiseFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerCounterfeitMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerCounterfeitMerchandiseFromRaw
    : IFromRawJson<ChargebackConsumerCounterfeitMerchandise>
{
    /// <inheritdoc/>
    public ChargebackConsumerCounterfeitMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerCounterfeitMerchandise.FromRawUnchecked(rawData);
}

/// <summary>
/// Credit not processed. Required if and only if `category` is `consumer_credit_not_processed`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerCreditNotProcessed,
        ChargebackConsumerCreditNotProcessedFromRaw
    >)
)]
public sealed record class ChargebackConsumerCreditNotProcessed : JsonModel
{
    /// <summary>
    /// Canceled or returned at.
    /// </summary>
    public string? CanceledOrReturnedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("canceled_or_returned_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("canceled_or_returned_at", value);
        }
    }

    /// <summary>
    /// Credit expected at.
    /// </summary>
    public string? CreditExpectedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("credit_expected_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("credit_expected_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanceledOrReturnedAt;
        _ = this.CreditExpectedAt;
    }

    public ChargebackConsumerCreditNotProcessed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerCreditNotProcessed(
        ChargebackConsumerCreditNotProcessed chargebackConsumerCreditNotProcessed
    )
        : base(chargebackConsumerCreditNotProcessed) { }
#pragma warning restore CS8618

    public ChargebackConsumerCreditNotProcessed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerCreditNotProcessed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerCreditNotProcessedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerCreditNotProcessed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerCreditNotProcessedFromRaw
    : IFromRawJson<ChargebackConsumerCreditNotProcessed>
{
    /// <inheritdoc/>
    public ChargebackConsumerCreditNotProcessed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerCreditNotProcessed.FromRawUnchecked(rawData);
}

/// <summary>
/// Damaged or defective merchandise. Required if and only if `category` is `consumer_damaged_or_defective_merchandise`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerDamagedOrDefectiveMerchandise,
        ChargebackConsumerDamagedOrDefectiveMerchandiseFromRaw
    >)
)]
public sealed record class ChargebackConsumerDamagedOrDefectiveMerchandise : JsonModel
{
    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
                >
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
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
    /// Return outcome.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome
    > ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome>
            >("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Not returned. Required if and only if `return_outcome` is `not_returned`.
    /// </summary>
    public ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned? NotReturned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned>(
                "not_returned"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("not_returned", value);
        }
    }

    /// <summary>
    /// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
    /// </summary>
    public ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted>(
                "return_attempted"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("return_attempted", value);
        }
    }

    /// <summary>
    /// Returned. Required if and only if `return_outcome` is `returned`.
    /// </summary>
    public ChargebackConsumerDamagedOrDefectiveMerchandiseReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerDamagedOrDefectiveMerchandiseReturned>(
                "returned"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("returned", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MerchantResolutionAttempted.Validate();
        _ = this.OrderAndIssueExplanation;
        _ = this.ReceivedAt;
        this.ReturnOutcome.Validate();
        this.NotReturned?.Validate();
        this.ReturnAttempted?.Validate();
        this.Returned?.Validate();
    }

    public ChargebackConsumerDamagedOrDefectiveMerchandise() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerDamagedOrDefectiveMerchandise(
        ChargebackConsumerDamagedOrDefectiveMerchandise chargebackConsumerDamagedOrDefectiveMerchandise
    )
        : base(chargebackConsumerDamagedOrDefectiveMerchandise) { }
#pragma warning restore CS8618

    public ChargebackConsumerDamagedOrDefectiveMerchandise(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerDamagedOrDefectiveMerchandise(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerDamagedOrDefectiveMerchandiseFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerDamagedOrDefectiveMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerDamagedOrDefectiveMerchandiseFromRaw
    : IFromRawJson<ChargebackConsumerDamagedOrDefectiveMerchandise>
{
    /// <inheritdoc/>
    public ChargebackConsumerDamagedOrDefectiveMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerDamagedOrDefectiveMerchandise.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(
    typeof(ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttemptedConverter)
)]
public enum ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
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

sealed class ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttemptedConverter
    : JsonConverter<ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted>
{
    public override ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted =>
                    "attempted",
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
/// Return outcome.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcomeConverter))]
public enum ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome
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

sealed class ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcomeConverter
    : JsonConverter<ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome>
{
    public override ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_returned" =>
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
            "returned" => ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.Returned,
            "return_attempted" =>
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.ReturnAttempted,
            _ => (ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned =>
                    "not_returned",
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.Returned => "returned",
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.ReturnAttempted =>
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
/// Not returned. Required if and only if `return_outcome` is `not_returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned,
        ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturnedFromRaw
    >)
)]
public sealed record class ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned(
        ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned chargebackConsumerDamagedOrDefectiveMerchandiseNotReturned
    )
        : base(chargebackConsumerDamagedOrDefectiveMerchandiseNotReturned) { }
#pragma warning restore CS8618

    public ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturnedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturnedFromRaw
    : IFromRawJson<ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned>
{
    /// <inheritdoc/>
    public ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted,
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedFromRaw
    >)
)]
public sealed record class ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted
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
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
    > AttemptReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
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

    public ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted chargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted
    )
        : base(chargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted) { }
#pragma warning restore CS8618

    public ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedFromRaw
    : IFromRawJson<ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted>
{
    /// <inheritdoc/>
    public ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted.FromRawUnchecked(rawData);
}

/// <summary>
/// Attempt reason.
/// </summary>
[JsonConverter(
    typeof(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReasonConverter)
)]
public enum ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
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

sealed class ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReasonConverter
    : JsonConverter<ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason>
{
    public override ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merchant_not_responding" =>
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            "no_return_authorization_provided" =>
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided,
            "no_return_instructions" =>
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions,
            "requested_not_to_return" =>
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn,
            "return_not_accepted" =>
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted,
            _ => (ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding =>
                    "merchant_not_responding",
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided =>
                    "no_return_authorization_provided",
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions =>
                    "no_return_instructions",
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn =>
                    "requested_not_to_return",
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted =>
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
/// Returned. Required if and only if `return_outcome` is `returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturned,
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedFromRaw
    >)
)]
public sealed record class ChargebackConsumerDamagedOrDefectiveMerchandiseReturned : JsonModel
{
    /// <summary>
    /// Return method.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod
    > ReturnMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod>
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
    /// Merchant received return at.
    /// </summary>
    public string? MerchantReceivedReturnAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_received_return_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("merchant_received_return_at", value);
        }
    }

    /// <summary>
    /// Other explanation. Required if and only if the return method is `other`.
    /// </summary>
    public string? OtherExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("other_explanation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("other_explanation", value);
        }
    }

    /// <summary>
    /// Tracking number.
    /// </summary>
    public string? TrackingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tracking_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tracking_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ReturnMethod.Validate();
        _ = this.ReturnedAt;
        _ = this.MerchantReceivedReturnAt;
        _ = this.OtherExplanation;
        _ = this.TrackingNumber;
    }

    public ChargebackConsumerDamagedOrDefectiveMerchandiseReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerDamagedOrDefectiveMerchandiseReturned(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturned chargebackConsumerDamagedOrDefectiveMerchandiseReturned
    )
        : base(chargebackConsumerDamagedOrDefectiveMerchandiseReturned) { }
#pragma warning restore CS8618

    public ChargebackConsumerDamagedOrDefectiveMerchandiseReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerDamagedOrDefectiveMerchandiseReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerDamagedOrDefectiveMerchandiseReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedFromRaw
    : IFromRawJson<ChargebackConsumerDamagedOrDefectiveMerchandiseReturned>
{
    /// <inheritdoc/>
    public ChargebackConsumerDamagedOrDefectiveMerchandiseReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerDamagedOrDefectiveMerchandiseReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return method.
/// </summary>
[JsonConverter(
    typeof(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethodConverter)
)]
public enum ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod
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

sealed class ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethodConverter
    : JsonConverter<ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod>
{
    public override ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dhl" => ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            "face_to_face" =>
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.FaceToFace,
            "fedex" => ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Fedex,
            "other" => ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Other,
            "postal_service" =>
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.PostalService,
            "ups" => ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Ups,
            _ => (ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl => "dhl",
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.FaceToFace =>
                    "face_to_face",
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Fedex =>
                    "fedex",
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Other =>
                    "other",
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.PostalService =>
                    "postal_service",
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Ups => "ups",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Merchandise misrepresentation. Required if and only if `category` is `consumer_merchandise_misrepresentation`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerMerchandiseMisrepresentation,
        ChargebackConsumerMerchandiseMisrepresentationFromRaw
    >)
)]
public sealed record class ChargebackConsumerMerchandiseMisrepresentation : JsonModel
{
    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
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

    /// <summary>
    /// Return outcome.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerMerchandiseMisrepresentationReturnOutcome
    > ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerMerchandiseMisrepresentationReturnOutcome>
            >("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Not returned. Required if and only if `return_outcome` is `not_returned`.
    /// </summary>
    public ChargebackConsumerMerchandiseMisrepresentationNotReturned? NotReturned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerMerchandiseMisrepresentationNotReturned>(
                "not_returned"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("not_returned", value);
        }
    }

    /// <summary>
    /// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
    /// </summary>
    public ChargebackConsumerMerchandiseMisrepresentationReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerMerchandiseMisrepresentationReturnAttempted>(
                "return_attempted"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("return_attempted", value);
        }
    }

    /// <summary>
    /// Returned. Required if and only if `return_outcome` is `returned`.
    /// </summary>
    public ChargebackConsumerMerchandiseMisrepresentationReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerMerchandiseMisrepresentationReturned>(
                "returned"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("returned", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MerchantResolutionAttempted.Validate();
        _ = this.MisrepresentationExplanation;
        _ = this.PurchaseExplanation;
        _ = this.ReceivedAt;
        this.ReturnOutcome.Validate();
        this.NotReturned?.Validate();
        this.ReturnAttempted?.Validate();
        this.Returned?.Validate();
    }

    public ChargebackConsumerMerchandiseMisrepresentation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseMisrepresentation(
        ChargebackConsumerMerchandiseMisrepresentation chargebackConsumerMerchandiseMisrepresentation
    )
        : base(chargebackConsumerMerchandiseMisrepresentation) { }
#pragma warning restore CS8618

    public ChargebackConsumerMerchandiseMisrepresentation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerMerchandiseMisrepresentation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerMerchandiseMisrepresentationFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerMerchandiseMisrepresentation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerMerchandiseMisrepresentationFromRaw
    : IFromRawJson<ChargebackConsumerMerchandiseMisrepresentation>
{
    /// <inheritdoc/>
    public ChargebackConsumerMerchandiseMisrepresentation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerMerchandiseMisrepresentation.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(
    typeof(ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttemptedConverter)
)]
public enum ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
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

sealed class ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttemptedConverter
    : JsonConverter<ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted>
{
    public override ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted =>
                    "attempted",
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
/// Return outcome.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerMerchandiseMisrepresentationReturnOutcomeConverter))]
public enum ChargebackConsumerMerchandiseMisrepresentationReturnOutcome
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

sealed class ChargebackConsumerMerchandiseMisrepresentationReturnOutcomeConverter
    : JsonConverter<ChargebackConsumerMerchandiseMisrepresentationReturnOutcome>
{
    public override ChargebackConsumerMerchandiseMisrepresentationReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_returned" =>
                ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
            "returned" => ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.Returned,
            "return_attempted" =>
                ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.ReturnAttempted,
            _ => (ChargebackConsumerMerchandiseMisrepresentationReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerMerchandiseMisrepresentationReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned =>
                    "not_returned",
                ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.Returned => "returned",
                ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.ReturnAttempted =>
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
/// Not returned. Required if and only if `return_outcome` is `not_returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerMerchandiseMisrepresentationNotReturned,
        ChargebackConsumerMerchandiseMisrepresentationNotReturnedFromRaw
    >)
)]
public sealed record class ChargebackConsumerMerchandiseMisrepresentationNotReturned : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ChargebackConsumerMerchandiseMisrepresentationNotReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseMisrepresentationNotReturned(
        ChargebackConsumerMerchandiseMisrepresentationNotReturned chargebackConsumerMerchandiseMisrepresentationNotReturned
    )
        : base(chargebackConsumerMerchandiseMisrepresentationNotReturned) { }
#pragma warning restore CS8618

    public ChargebackConsumerMerchandiseMisrepresentationNotReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerMerchandiseMisrepresentationNotReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerMerchandiseMisrepresentationNotReturnedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerMerchandiseMisrepresentationNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerMerchandiseMisrepresentationNotReturnedFromRaw
    : IFromRawJson<ChargebackConsumerMerchandiseMisrepresentationNotReturned>
{
    /// <inheritdoc/>
    public ChargebackConsumerMerchandiseMisrepresentationNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerMerchandiseMisrepresentationNotReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerMerchandiseMisrepresentationReturnAttempted,
        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedFromRaw
    >)
)]
public sealed record class ChargebackConsumerMerchandiseMisrepresentationReturnAttempted : JsonModel
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
        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
    > AttemptReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
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

    public ChargebackConsumerMerchandiseMisrepresentationReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseMisrepresentationReturnAttempted(
        ChargebackConsumerMerchandiseMisrepresentationReturnAttempted chargebackConsumerMerchandiseMisrepresentationReturnAttempted
    )
        : base(chargebackConsumerMerchandiseMisrepresentationReturnAttempted) { }
#pragma warning restore CS8618

    public ChargebackConsumerMerchandiseMisrepresentationReturnAttempted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerMerchandiseMisrepresentationReturnAttempted(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerMerchandiseMisrepresentationReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedFromRaw
    : IFromRawJson<ChargebackConsumerMerchandiseMisrepresentationReturnAttempted>
{
    /// <inheritdoc/>
    public ChargebackConsumerMerchandiseMisrepresentationReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerMerchandiseMisrepresentationReturnAttempted.FromRawUnchecked(rawData);
}

/// <summary>
/// Attempt reason.
/// </summary>
[JsonConverter(
    typeof(ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReasonConverter)
)]
public enum ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
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

sealed class ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReasonConverter
    : JsonConverter<ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason>
{
    public override ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merchant_not_responding" =>
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
            "no_return_authorization_provided" =>
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnAuthorizationProvided,
            "no_return_instructions" =>
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnInstructions,
            "requested_not_to_return" =>
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.RequestedNotToReturn,
            "return_not_accepted" =>
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.ReturnNotAccepted,
            _ => (ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding =>
                    "merchant_not_responding",
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnAuthorizationProvided =>
                    "no_return_authorization_provided",
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnInstructions =>
                    "no_return_instructions",
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.RequestedNotToReturn =>
                    "requested_not_to_return",
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.ReturnNotAccepted =>
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
/// Returned. Required if and only if `return_outcome` is `returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerMerchandiseMisrepresentationReturned,
        ChargebackConsumerMerchandiseMisrepresentationReturnedFromRaw
    >)
)]
public sealed record class ChargebackConsumerMerchandiseMisrepresentationReturned : JsonModel
{
    /// <summary>
    /// Return method.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod
    > ReturnMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod>
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
    /// Merchant received return at.
    /// </summary>
    public string? MerchantReceivedReturnAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_received_return_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("merchant_received_return_at", value);
        }
    }

    /// <summary>
    /// Other explanation. Required if and only if the return method is `other`.
    /// </summary>
    public string? OtherExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("other_explanation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("other_explanation", value);
        }
    }

    /// <summary>
    /// Tracking number.
    /// </summary>
    public string? TrackingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tracking_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tracking_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ReturnMethod.Validate();
        _ = this.ReturnedAt;
        _ = this.MerchantReceivedReturnAt;
        _ = this.OtherExplanation;
        _ = this.TrackingNumber;
    }

    public ChargebackConsumerMerchandiseMisrepresentationReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseMisrepresentationReturned(
        ChargebackConsumerMerchandiseMisrepresentationReturned chargebackConsumerMerchandiseMisrepresentationReturned
    )
        : base(chargebackConsumerMerchandiseMisrepresentationReturned) { }
#pragma warning restore CS8618

    public ChargebackConsumerMerchandiseMisrepresentationReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerMerchandiseMisrepresentationReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerMerchandiseMisrepresentationReturnedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerMerchandiseMisrepresentationReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerMerchandiseMisrepresentationReturnedFromRaw
    : IFromRawJson<ChargebackConsumerMerchandiseMisrepresentationReturned>
{
    /// <inheritdoc/>
    public ChargebackConsumerMerchandiseMisrepresentationReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerMerchandiseMisrepresentationReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return method.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethodConverter))]
public enum ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod
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

sealed class ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethodConverter
    : JsonConverter<ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod>
{
    public override ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dhl" => ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            "face_to_face" =>
                ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.FaceToFace,
            "fedex" => ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Fedex,
            "other" => ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Other,
            "postal_service" =>
                ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.PostalService,
            "ups" => ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Ups,
            _ => (ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl => "dhl",
                ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.FaceToFace =>
                    "face_to_face",
                ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Fedex => "fedex",
                ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Other => "other",
                ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.PostalService =>
                    "postal_service",
                ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Ups => "ups",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Merchandise not as described. Required if and only if `category` is `consumer_merchandise_not_as_described`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerMerchandiseNotAsDescribed,
        ChargebackConsumerMerchandiseNotAsDescribedFromRaw
    >)
)]
public sealed record class ChargebackConsumerMerchandiseNotAsDescribed : JsonModel
{
    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
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
    /// Return outcome.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome
    > ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome>
            >("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
    /// </summary>
    public ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted>(
                "return_attempted"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("return_attempted", value);
        }
    }

    /// <summary>
    /// Returned. Required if and only if `return_outcome` is `returned`.
    /// </summary>
    public ChargebackConsumerMerchandiseNotAsDescribedReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerMerchandiseNotAsDescribedReturned>(
                "returned"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("returned", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MerchantResolutionAttempted.Validate();
        _ = this.ReceivedAt;
        this.ReturnOutcome.Validate();
        this.ReturnAttempted?.Validate();
        this.Returned?.Validate();
    }

    public ChargebackConsumerMerchandiseNotAsDescribed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseNotAsDescribed(
        ChargebackConsumerMerchandiseNotAsDescribed chargebackConsumerMerchandiseNotAsDescribed
    )
        : base(chargebackConsumerMerchandiseNotAsDescribed) { }
#pragma warning restore CS8618

    public ChargebackConsumerMerchandiseNotAsDescribed(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerMerchandiseNotAsDescribed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerMerchandiseNotAsDescribedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerMerchandiseNotAsDescribed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerMerchandiseNotAsDescribedFromRaw
    : IFromRawJson<ChargebackConsumerMerchandiseNotAsDescribed>
{
    /// <inheritdoc/>
    public ChargebackConsumerMerchandiseNotAsDescribed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerMerchandiseNotAsDescribed.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(
    typeof(ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttemptedConverter)
)]
public enum ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
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

sealed class ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttemptedConverter
    : JsonConverter<ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted>
{
    public override ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted =>
                    "attempted",
                ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
/// Return outcome.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerMerchandiseNotAsDescribedReturnOutcomeConverter))]
public enum ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome
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

sealed class ChargebackConsumerMerchandiseNotAsDescribedReturnOutcomeConverter
    : JsonConverter<ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome>
{
    public override ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "returned" => ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
            "return_attempted" =>
                ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.ReturnAttempted,
            _ => (ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned => "returned",
                ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.ReturnAttempted =>
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
/// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted,
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedFromRaw
    >)
)]
public sealed record class ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted : JsonModel
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
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
    > AttemptReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
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

    public ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted(
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted chargebackConsumerMerchandiseNotAsDescribedReturnAttempted
    )
        : base(chargebackConsumerMerchandiseNotAsDescribedReturnAttempted) { }
#pragma warning restore CS8618

    public ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedFromRaw
    : IFromRawJson<ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted>
{
    /// <inheritdoc/>
    public ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted.FromRawUnchecked(rawData);
}

/// <summary>
/// Attempt reason.
/// </summary>
[JsonConverter(
    typeof(ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReasonConverter)
)]
public enum ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
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

sealed class ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReasonConverter
    : JsonConverter<ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason>
{
    public override ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merchant_not_responding" =>
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            "no_return_authorization_provided" =>
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnAuthorizationProvided,
            "no_return_instructions" =>
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnInstructions,
            "requested_not_to_return" =>
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.RequestedNotToReturn,
            "return_not_accepted" =>
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.ReturnNotAccepted,
            _ => (ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding =>
                    "merchant_not_responding",
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnAuthorizationProvided =>
                    "no_return_authorization_provided",
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnInstructions =>
                    "no_return_instructions",
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.RequestedNotToReturn =>
                    "requested_not_to_return",
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.ReturnNotAccepted =>
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
/// Returned. Required if and only if `return_outcome` is `returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerMerchandiseNotAsDescribedReturned,
        ChargebackConsumerMerchandiseNotAsDescribedReturnedFromRaw
    >)
)]
public sealed record class ChargebackConsumerMerchandiseNotAsDescribedReturned : JsonModel
{
    /// <summary>
    /// Return method.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod
    > ReturnMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod>
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
    /// Merchant received return at.
    /// </summary>
    public string? MerchantReceivedReturnAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_received_return_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("merchant_received_return_at", value);
        }
    }

    /// <summary>
    /// Other explanation. Required if and only if the return method is `other`.
    /// </summary>
    public string? OtherExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("other_explanation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("other_explanation", value);
        }
    }

    /// <summary>
    /// Tracking number.
    /// </summary>
    public string? TrackingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tracking_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tracking_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ReturnMethod.Validate();
        _ = this.ReturnedAt;
        _ = this.MerchantReceivedReturnAt;
        _ = this.OtherExplanation;
        _ = this.TrackingNumber;
    }

    public ChargebackConsumerMerchandiseNotAsDescribedReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseNotAsDescribedReturned(
        ChargebackConsumerMerchandiseNotAsDescribedReturned chargebackConsumerMerchandiseNotAsDescribedReturned
    )
        : base(chargebackConsumerMerchandiseNotAsDescribedReturned) { }
#pragma warning restore CS8618

    public ChargebackConsumerMerchandiseNotAsDescribedReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerMerchandiseNotAsDescribedReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerMerchandiseNotAsDescribedReturnedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerMerchandiseNotAsDescribedReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerMerchandiseNotAsDescribedReturnedFromRaw
    : IFromRawJson<ChargebackConsumerMerchandiseNotAsDescribedReturned>
{
    /// <inheritdoc/>
    public ChargebackConsumerMerchandiseNotAsDescribedReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerMerchandiseNotAsDescribedReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return method.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethodConverter))]
public enum ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod
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

sealed class ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethodConverter
    : JsonConverter<ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod>
{
    public override ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dhl" => ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            "face_to_face" =>
                ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.FaceToFace,
            "fedex" => ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Fedex,
            "other" => ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Other,
            "postal_service" =>
                ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.PostalService,
            "ups" => ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Ups,
            _ => (ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl => "dhl",
                ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.FaceToFace =>
                    "face_to_face",
                ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Fedex => "fedex",
                ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Other => "other",
                ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.PostalService =>
                    "postal_service",
                ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Ups => "ups",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Merchandise not received. Required if and only if `category` is `consumer_merchandise_not_received`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerMerchandiseNotReceived,
        ChargebackConsumerMerchandiseNotReceivedFromRaw
    >)
)]
public sealed record class ChargebackConsumerMerchandiseNotReceived : JsonModel
{
    /// <summary>
    /// Cancellation outcome.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerMerchandiseNotReceivedCancellationOutcome
    > CancellationOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedCancellationOutcome>
            >("cancellation_outcome");
        }
        init { this._rawData.Set("cancellation_outcome", value); }
    }

    /// <summary>
    /// Delivery issue.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerMerchandiseNotReceivedDeliveryIssue
    > DeliveryIssue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedDeliveryIssue>
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
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted>
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
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

    /// <summary>
    /// Cardholder cancellation prior to expected receipt. Required if and only if
    /// `cancellation_outcome` is `cardholder_cancellation_prior_to_expected_receipt`.
    /// </summary>
    public ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt? CardholderCancellationPriorToExpectedReceipt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt>(
                "cardholder_cancellation_prior_to_expected_receipt"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cardholder_cancellation_prior_to_expected_receipt", value);
        }
    }

    /// <summary>
    /// Delayed. Required if and only if `delivery_issue` is `delayed`.
    /// </summary>
    public ChargebackConsumerMerchandiseNotReceivedDelayed? Delayed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerMerchandiseNotReceivedDelayed>(
                "delayed"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("delayed", value);
        }
    }

    /// <summary>
    /// Delivered to wrong location. Required if and only if `delivery_issue` is `delivered_to_wrong_location`.
    /// </summary>
    public ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation? DeliveredToWrongLocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation>(
                "delivered_to_wrong_location"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("delivered_to_wrong_location", value);
        }
    }

    /// <summary>
    /// Merchant cancellation. Required if and only if `cancellation_outcome` is `merchant_cancellation`.
    /// </summary>
    public ChargebackConsumerMerchandiseNotReceivedMerchantCancellation? MerchantCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerMerchandiseNotReceivedMerchantCancellation>(
                "merchant_cancellation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("merchant_cancellation", value);
        }
    }

    /// <summary>
    /// No cancellation. Required if and only if `cancellation_outcome` is `no_cancellation`.
    /// </summary>
    public ChargebackConsumerMerchandiseNotReceivedNoCancellation? NoCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerMerchandiseNotReceivedNoCancellation>(
                "no_cancellation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("no_cancellation", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CancellationOutcome.Validate();
        this.DeliveryIssue.Validate();
        _ = this.LastExpectedReceiptAt;
        this.MerchantResolutionAttempted.Validate();
        _ = this.PurchaseInfoAndExplanation;
        this.CardholderCancellationPriorToExpectedReceipt?.Validate();
        this.Delayed?.Validate();
        this.DeliveredToWrongLocation?.Validate();
        this.MerchantCancellation?.Validate();
        this.NoCancellation?.Validate();
    }

    public ChargebackConsumerMerchandiseNotReceived() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseNotReceived(
        ChargebackConsumerMerchandiseNotReceived chargebackConsumerMerchandiseNotReceived
    )
        : base(chargebackConsumerMerchandiseNotReceived) { }
#pragma warning restore CS8618

    public ChargebackConsumerMerchandiseNotReceived(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerMerchandiseNotReceived(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerMerchandiseNotReceivedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerMerchandiseNotReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerMerchandiseNotReceivedFromRaw
    : IFromRawJson<ChargebackConsumerMerchandiseNotReceived>
{
    /// <inheritdoc/>
    public ChargebackConsumerMerchandiseNotReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerMerchandiseNotReceived.FromRawUnchecked(rawData);
}

/// <summary>
/// Cancellation outcome.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerMerchandiseNotReceivedCancellationOutcomeConverter))]
public enum ChargebackConsumerMerchandiseNotReceivedCancellationOutcome
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

sealed class ChargebackConsumerMerchandiseNotReceivedCancellationOutcomeConverter
    : JsonConverter<ChargebackConsumerMerchandiseNotReceivedCancellationOutcome>
{
    public override ChargebackConsumerMerchandiseNotReceivedCancellationOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cardholder_cancellation_prior_to_expected_receipt" =>
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            "merchant_cancellation" =>
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.MerchantCancellation,
            "no_cancellation" =>
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.NoCancellation,
            _ => (ChargebackConsumerMerchandiseNotReceivedCancellationOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerMerchandiseNotReceivedCancellationOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt =>
                    "cardholder_cancellation_prior_to_expected_receipt",
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.MerchantCancellation =>
                    "merchant_cancellation",
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.NoCancellation =>
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
/// Delivery issue.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerMerchandiseNotReceivedDeliveryIssueConverter))]
public enum ChargebackConsumerMerchandiseNotReceivedDeliveryIssue
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

sealed class ChargebackConsumerMerchandiseNotReceivedDeliveryIssueConverter
    : JsonConverter<ChargebackConsumerMerchandiseNotReceivedDeliveryIssue>
{
    public override ChargebackConsumerMerchandiseNotReceivedDeliveryIssue Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "delayed" => ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
            "delivered_to_wrong_location" =>
                ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.DeliveredToWrongLocation,
            _ => (ChargebackConsumerMerchandiseNotReceivedDeliveryIssue)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerMerchandiseNotReceivedDeliveryIssue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed => "delayed",
                ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.DeliveredToWrongLocation =>
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
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(
    typeof(ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttemptedConverter)
)]
public enum ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted
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

sealed class ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttemptedConverter
    : JsonConverter<ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted>
{
    public override ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted =>
                    "attempted",
                ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
/// Cardholder cancellation prior to expected receipt. Required if and only if `cancellation_outcome`
/// is `cardholder_cancellation_prior_to_expected_receipt`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt,
        ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceiptFromRaw
    >)
)]
public sealed record class ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt
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
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanceledAt;
        _ = this.Reason;
    }

    public ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt()
    { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt(
        ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt chargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt
    )
        : base(chargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt)
    { }
#pragma warning restore CS8618

    public ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceiptFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt(
        string canceledAt
    )
        : this()
    {
        this.CanceledAt = canceledAt;
    }
}

class ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceiptFromRaw
    : IFromRawJson<ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt>
{
    /// <inheritdoc/>
    public ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Delayed. Required if and only if `delivery_issue` is `delayed`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerMerchandiseNotReceivedDelayed,
        ChargebackConsumerMerchandiseNotReceivedDelayedFromRaw
    >)
)]
public sealed record class ChargebackConsumerMerchandiseNotReceivedDelayed : JsonModel
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
    /// Return outcome.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome
    > ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome>
            >("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Not returned. Required if and only if `return_outcome` is `not_returned`.
    /// </summary>
    public ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned? NotReturned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned>(
                "not_returned"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("not_returned", value);
        }
    }

    /// <summary>
    /// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
    /// </summary>
    public ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted>(
                "return_attempted"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("return_attempted", value);
        }
    }

    /// <summary>
    /// Returned. Required if and only if `return_outcome` is `returned`.
    /// </summary>
    public ChargebackConsumerMerchandiseNotReceivedDelayedReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerMerchandiseNotReceivedDelayedReturned>(
                "returned"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("returned", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Explanation;
        this.ReturnOutcome.Validate();
        this.NotReturned?.Validate();
        this.ReturnAttempted?.Validate();
        this.Returned?.Validate();
    }

    public ChargebackConsumerMerchandiseNotReceivedDelayed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseNotReceivedDelayed(
        ChargebackConsumerMerchandiseNotReceivedDelayed chargebackConsumerMerchandiseNotReceivedDelayed
    )
        : base(chargebackConsumerMerchandiseNotReceivedDelayed) { }
#pragma warning restore CS8618

    public ChargebackConsumerMerchandiseNotReceivedDelayed(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerMerchandiseNotReceivedDelayed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerMerchandiseNotReceivedDelayedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerMerchandiseNotReceivedDelayed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerMerchandiseNotReceivedDelayedFromRaw
    : IFromRawJson<ChargebackConsumerMerchandiseNotReceivedDelayed>
{
    /// <inheritdoc/>
    public ChargebackConsumerMerchandiseNotReceivedDelayed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerMerchandiseNotReceivedDelayed.FromRawUnchecked(rawData);
}

/// <summary>
/// Return outcome.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcomeConverter))]
public enum ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome
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

sealed class ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcomeConverter
    : JsonConverter<ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome>
{
    public override ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_returned" =>
                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
            "returned" => ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.Returned,
            "return_attempted" =>
                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.ReturnAttempted,
            _ => (ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned =>
                    "not_returned",
                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.Returned => "returned",
                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.ReturnAttempted =>
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
/// Not returned. Required if and only if `return_outcome` is `not_returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned,
        ChargebackConsumerMerchandiseNotReceivedDelayedNotReturnedFromRaw
    >)
)]
public sealed record class ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned(
        ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned chargebackConsumerMerchandiseNotReceivedDelayedNotReturned
    )
        : base(chargebackConsumerMerchandiseNotReceivedDelayedNotReturned) { }
#pragma warning restore CS8618

    public ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerMerchandiseNotReceivedDelayedNotReturnedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerMerchandiseNotReceivedDelayedNotReturnedFromRaw
    : IFromRawJson<ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned>
{
    /// <inheritdoc/>
    public ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted,
        ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttemptedFromRaw
    >)
)]
public sealed record class ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted
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

    public ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted(
        ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted chargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted
    )
        : base(chargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted) { }
#pragma warning restore CS8618

    public ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted(string attemptedAt)
        : this()
    {
        this.AttemptedAt = attemptedAt;
    }
}

class ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttemptedFromRaw
    : IFromRawJson<ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted>
{
    /// <inheritdoc/>
    public ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted.FromRawUnchecked(rawData);
}

/// <summary>
/// Returned. Required if and only if `return_outcome` is `returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerMerchandiseNotReceivedDelayedReturned,
        ChargebackConsumerMerchandiseNotReceivedDelayedReturnedFromRaw
    >)
)]
public sealed record class ChargebackConsumerMerchandiseNotReceivedDelayedReturned : JsonModel
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

    public ChargebackConsumerMerchandiseNotReceivedDelayedReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseNotReceivedDelayedReturned(
        ChargebackConsumerMerchandiseNotReceivedDelayedReturned chargebackConsumerMerchandiseNotReceivedDelayedReturned
    )
        : base(chargebackConsumerMerchandiseNotReceivedDelayedReturned) { }
#pragma warning restore CS8618

    public ChargebackConsumerMerchandiseNotReceivedDelayedReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerMerchandiseNotReceivedDelayedReturned(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerMerchandiseNotReceivedDelayedReturnedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerMerchandiseNotReceivedDelayedReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerMerchandiseNotReceivedDelayedReturnedFromRaw
    : IFromRawJson<ChargebackConsumerMerchandiseNotReceivedDelayedReturned>
{
    /// <inheritdoc/>
    public ChargebackConsumerMerchandiseNotReceivedDelayedReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerMerchandiseNotReceivedDelayedReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Delivered to wrong location. Required if and only if `delivery_issue` is `delivered_to_wrong_location`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation,
        ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocationFromRaw
    >)
)]
public sealed record class ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation
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

    public ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation(
        ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation chargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation
    )
        : base(chargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation) { }
#pragma warning restore CS8618

    public ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocationFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation(string agreedLocation)
        : this()
    {
        this.AgreedLocation = agreedLocation;
    }
}

class ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocationFromRaw
    : IFromRawJson<ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation>
{
    /// <inheritdoc/>
    public ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant cancellation. Required if and only if `cancellation_outcome` is `merchant_cancellation`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerMerchandiseNotReceivedMerchantCancellation,
        ChargebackConsumerMerchandiseNotReceivedMerchantCancellationFromRaw
    >)
)]
public sealed record class ChargebackConsumerMerchandiseNotReceivedMerchantCancellation : JsonModel
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

    public ChargebackConsumerMerchandiseNotReceivedMerchantCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseNotReceivedMerchantCancellation(
        ChargebackConsumerMerchandiseNotReceivedMerchantCancellation chargebackConsumerMerchandiseNotReceivedMerchantCancellation
    )
        : base(chargebackConsumerMerchandiseNotReceivedMerchantCancellation) { }
#pragma warning restore CS8618

    public ChargebackConsumerMerchandiseNotReceivedMerchantCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerMerchandiseNotReceivedMerchantCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerMerchandiseNotReceivedMerchantCancellationFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerMerchandiseNotReceivedMerchantCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseNotReceivedMerchantCancellation(string canceledAt)
        : this()
    {
        this.CanceledAt = canceledAt;
    }
}

class ChargebackConsumerMerchandiseNotReceivedMerchantCancellationFromRaw
    : IFromRawJson<ChargebackConsumerMerchandiseNotReceivedMerchantCancellation>
{
    /// <inheritdoc/>
    public ChargebackConsumerMerchandiseNotReceivedMerchantCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerMerchandiseNotReceivedMerchantCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// No cancellation. Required if and only if `cancellation_outcome` is `no_cancellation`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerMerchandiseNotReceivedNoCancellation,
        ChargebackConsumerMerchandiseNotReceivedNoCancellationFromRaw
    >)
)]
public sealed record class ChargebackConsumerMerchandiseNotReceivedNoCancellation : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ChargebackConsumerMerchandiseNotReceivedNoCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerMerchandiseNotReceivedNoCancellation(
        ChargebackConsumerMerchandiseNotReceivedNoCancellation chargebackConsumerMerchandiseNotReceivedNoCancellation
    )
        : base(chargebackConsumerMerchandiseNotReceivedNoCancellation) { }
#pragma warning restore CS8618

    public ChargebackConsumerMerchandiseNotReceivedNoCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerMerchandiseNotReceivedNoCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerMerchandiseNotReceivedNoCancellationFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerMerchandiseNotReceivedNoCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerMerchandiseNotReceivedNoCancellationFromRaw
    : IFromRawJson<ChargebackConsumerMerchandiseNotReceivedNoCancellation>
{
    /// <inheritdoc/>
    public ChargebackConsumerMerchandiseNotReceivedNoCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerMerchandiseNotReceivedNoCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// Non-receipt of cash. Required if and only if `category` is `consumer_non_receipt_of_cash`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerNonReceiptOfCash,
        ChargebackConsumerNonReceiptOfCashFromRaw
    >)
)]
public sealed record class ChargebackConsumerNonReceiptOfCash : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ChargebackConsumerNonReceiptOfCash() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerNonReceiptOfCash(
        ChargebackConsumerNonReceiptOfCash chargebackConsumerNonReceiptOfCash
    )
        : base(chargebackConsumerNonReceiptOfCash) { }
#pragma warning restore CS8618

    public ChargebackConsumerNonReceiptOfCash(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerNonReceiptOfCash(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerNonReceiptOfCashFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerNonReceiptOfCash FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerNonReceiptOfCashFromRaw : IFromRawJson<ChargebackConsumerNonReceiptOfCash>
{
    /// <inheritdoc/>
    public ChargebackConsumerNonReceiptOfCash FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerNonReceiptOfCash.FromRawUnchecked(rawData);
}

/// <summary>
/// Original Credit Transaction (OCT) not accepted. Required if and only if `category`
/// is `consumer_original_credit_transaction_not_accepted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerOriginalCreditTransactionNotAccepted,
        ChargebackConsumerOriginalCreditTransactionNotAcceptedFromRaw
    >)
)]
public sealed record class ChargebackConsumerOriginalCreditTransactionNotAccepted : JsonModel
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
        ChargebackConsumerOriginalCreditTransactionNotAcceptedReason
    > Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerOriginalCreditTransactionNotAcceptedReason>
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

    public ChargebackConsumerOriginalCreditTransactionNotAccepted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerOriginalCreditTransactionNotAccepted(
        ChargebackConsumerOriginalCreditTransactionNotAccepted chargebackConsumerOriginalCreditTransactionNotAccepted
    )
        : base(chargebackConsumerOriginalCreditTransactionNotAccepted) { }
#pragma warning restore CS8618

    public ChargebackConsumerOriginalCreditTransactionNotAccepted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerOriginalCreditTransactionNotAccepted(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerOriginalCreditTransactionNotAcceptedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerOriginalCreditTransactionNotAccepted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerOriginalCreditTransactionNotAcceptedFromRaw
    : IFromRawJson<ChargebackConsumerOriginalCreditTransactionNotAccepted>
{
    /// <inheritdoc/>
    public ChargebackConsumerOriginalCreditTransactionNotAccepted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerOriginalCreditTransactionNotAccepted.FromRawUnchecked(rawData);
}

/// <summary>
/// Reason.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerOriginalCreditTransactionNotAcceptedReasonConverter))]
public enum ChargebackConsumerOriginalCreditTransactionNotAcceptedReason
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

sealed class ChargebackConsumerOriginalCreditTransactionNotAcceptedReasonConverter
    : JsonConverter<ChargebackConsumerOriginalCreditTransactionNotAcceptedReason>
{
    public override ChargebackConsumerOriginalCreditTransactionNotAcceptedReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prohibited_by_local_laws_or_regulation" =>
                ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
            "recipient_refused" =>
                ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.RecipientRefused,
            _ => (ChargebackConsumerOriginalCreditTransactionNotAcceptedReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerOriginalCreditTransactionNotAcceptedReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation =>
                    "prohibited_by_local_laws_or_regulation",
                ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.RecipientRefused =>
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
/// Merchandise quality issue. Required if and only if `category` is `consumer_quality_merchandise`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerQualityMerchandise,
        ChargebackConsumerQualityMerchandiseFromRaw
    >)
)]
public sealed record class ChargebackConsumerQualityMerchandise : JsonModel
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
        ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted>
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
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
    /// Return outcome.
    /// </summary>
    public required ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnOutcome> ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnOutcome>
            >("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Not returned. Required if and only if `return_outcome` is `not_returned`.
    /// </summary>
    public ChargebackConsumerQualityMerchandiseNotReturned? NotReturned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerQualityMerchandiseNotReturned>(
                "not_returned"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("not_returned", value);
        }
    }

    /// <summary>
    /// Ongoing negotiations. Exclude if there is no evidence of ongoing negotiations.
    /// </summary>
    public ChargebackConsumerQualityMerchandiseOngoingNegotiations? OngoingNegotiations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerQualityMerchandiseOngoingNegotiations>(
                "ongoing_negotiations"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ongoing_negotiations", value);
        }
    }

    /// <summary>
    /// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
    /// </summary>
    public ChargebackConsumerQualityMerchandiseReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerQualityMerchandiseReturnAttempted>(
                "return_attempted"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("return_attempted", value);
        }
    }

    /// <summary>
    /// Returned. Required if and only if `return_outcome` is `returned`.
    /// </summary>
    public ChargebackConsumerQualityMerchandiseReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerQualityMerchandiseReturned>(
                "returned"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("returned", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpectedAt;
        this.MerchantResolutionAttempted.Validate();
        _ = this.PurchaseInfoAndQualityIssue;
        _ = this.ReceivedAt;
        this.ReturnOutcome.Validate();
        this.NotReturned?.Validate();
        this.OngoingNegotiations?.Validate();
        this.ReturnAttempted?.Validate();
        this.Returned?.Validate();
    }

    public ChargebackConsumerQualityMerchandise() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerQualityMerchandise(
        ChargebackConsumerQualityMerchandise chargebackConsumerQualityMerchandise
    )
        : base(chargebackConsumerQualityMerchandise) { }
#pragma warning restore CS8618

    public ChargebackConsumerQualityMerchandise(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerQualityMerchandise(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerQualityMerchandiseFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerQualityMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerQualityMerchandiseFromRaw
    : IFromRawJson<ChargebackConsumerQualityMerchandise>
{
    /// <inheritdoc/>
    public ChargebackConsumerQualityMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerQualityMerchandise.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerQualityMerchandiseMerchantResolutionAttemptedConverter))]
public enum ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted
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

sealed class ChargebackConsumerQualityMerchandiseMerchantResolutionAttemptedConverter
    : JsonConverter<ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted>
{
    public override ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted =>
                    "attempted",
                ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
/// Return outcome.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerQualityMerchandiseReturnOutcomeConverter))]
public enum ChargebackConsumerQualityMerchandiseReturnOutcome
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

sealed class ChargebackConsumerQualityMerchandiseReturnOutcomeConverter
    : JsonConverter<ChargebackConsumerQualityMerchandiseReturnOutcome>
{
    public override ChargebackConsumerQualityMerchandiseReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_returned" => ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
            "returned" => ChargebackConsumerQualityMerchandiseReturnOutcome.Returned,
            "return_attempted" => ChargebackConsumerQualityMerchandiseReturnOutcome.ReturnAttempted,
            _ => (ChargebackConsumerQualityMerchandiseReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerQualityMerchandiseReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned => "not_returned",
                ChargebackConsumerQualityMerchandiseReturnOutcome.Returned => "returned",
                ChargebackConsumerQualityMerchandiseReturnOutcome.ReturnAttempted =>
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
/// Not returned. Required if and only if `return_outcome` is `not_returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerQualityMerchandiseNotReturned,
        ChargebackConsumerQualityMerchandiseNotReturnedFromRaw
    >)
)]
public sealed record class ChargebackConsumerQualityMerchandiseNotReturned : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ChargebackConsumerQualityMerchandiseNotReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerQualityMerchandiseNotReturned(
        ChargebackConsumerQualityMerchandiseNotReturned chargebackConsumerQualityMerchandiseNotReturned
    )
        : base(chargebackConsumerQualityMerchandiseNotReturned) { }
#pragma warning restore CS8618

    public ChargebackConsumerQualityMerchandiseNotReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerQualityMerchandiseNotReturned(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerQualityMerchandiseNotReturnedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerQualityMerchandiseNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerQualityMerchandiseNotReturnedFromRaw
    : IFromRawJson<ChargebackConsumerQualityMerchandiseNotReturned>
{
    /// <inheritdoc/>
    public ChargebackConsumerQualityMerchandiseNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerQualityMerchandiseNotReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Ongoing negotiations. Exclude if there is no evidence of ongoing negotiations.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerQualityMerchandiseOngoingNegotiations,
        ChargebackConsumerQualityMerchandiseOngoingNegotiationsFromRaw
    >)
)]
public sealed record class ChargebackConsumerQualityMerchandiseOngoingNegotiations : JsonModel
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

    public ChargebackConsumerQualityMerchandiseOngoingNegotiations() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerQualityMerchandiseOngoingNegotiations(
        ChargebackConsumerQualityMerchandiseOngoingNegotiations chargebackConsumerQualityMerchandiseOngoingNegotiations
    )
        : base(chargebackConsumerQualityMerchandiseOngoingNegotiations) { }
#pragma warning restore CS8618

    public ChargebackConsumerQualityMerchandiseOngoingNegotiations(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerQualityMerchandiseOngoingNegotiations(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerQualityMerchandiseOngoingNegotiationsFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerQualityMerchandiseOngoingNegotiations FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerQualityMerchandiseOngoingNegotiationsFromRaw
    : IFromRawJson<ChargebackConsumerQualityMerchandiseOngoingNegotiations>
{
    /// <inheritdoc/>
    public ChargebackConsumerQualityMerchandiseOngoingNegotiations FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerQualityMerchandiseOngoingNegotiations.FromRawUnchecked(rawData);
}

/// <summary>
/// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerQualityMerchandiseReturnAttempted,
        ChargebackConsumerQualityMerchandiseReturnAttemptedFromRaw
    >)
)]
public sealed record class ChargebackConsumerQualityMerchandiseReturnAttempted : JsonModel
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
        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason
    > AttemptReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason>
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

    public ChargebackConsumerQualityMerchandiseReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerQualityMerchandiseReturnAttempted(
        ChargebackConsumerQualityMerchandiseReturnAttempted chargebackConsumerQualityMerchandiseReturnAttempted
    )
        : base(chargebackConsumerQualityMerchandiseReturnAttempted) { }
#pragma warning restore CS8618

    public ChargebackConsumerQualityMerchandiseReturnAttempted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerQualityMerchandiseReturnAttempted(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerQualityMerchandiseReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerQualityMerchandiseReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerQualityMerchandiseReturnAttemptedFromRaw
    : IFromRawJson<ChargebackConsumerQualityMerchandiseReturnAttempted>
{
    /// <inheritdoc/>
    public ChargebackConsumerQualityMerchandiseReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerQualityMerchandiseReturnAttempted.FromRawUnchecked(rawData);
}

/// <summary>
/// Attempt reason.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReasonConverter))]
public enum ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason
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

sealed class ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReasonConverter
    : JsonConverter<ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason>
{
    public override ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merchant_not_responding" =>
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            "no_return_authorization_provided" =>
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided,
            "no_return_instructions" =>
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions,
            "requested_not_to_return" =>
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn,
            "return_not_accepted" =>
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted,
            _ => (ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding =>
                    "merchant_not_responding",
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided =>
                    "no_return_authorization_provided",
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions =>
                    "no_return_instructions",
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn =>
                    "requested_not_to_return",
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted =>
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
/// Returned. Required if and only if `return_outcome` is `returned`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerQualityMerchandiseReturned,
        ChargebackConsumerQualityMerchandiseReturnedFromRaw
    >)
)]
public sealed record class ChargebackConsumerQualityMerchandiseReturned : JsonModel
{
    /// <summary>
    /// Return method.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerQualityMerchandiseReturnedReturnMethod
    > ReturnMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnedReturnMethod>
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
    /// Merchant received return at.
    /// </summary>
    public string? MerchantReceivedReturnAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_received_return_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("merchant_received_return_at", value);
        }
    }

    /// <summary>
    /// Other explanation. Required if and only if the return method is `other`.
    /// </summary>
    public string? OtherExplanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("other_explanation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("other_explanation", value);
        }
    }

    /// <summary>
    /// Tracking number.
    /// </summary>
    public string? TrackingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tracking_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tracking_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ReturnMethod.Validate();
        _ = this.ReturnedAt;
        _ = this.MerchantReceivedReturnAt;
        _ = this.OtherExplanation;
        _ = this.TrackingNumber;
    }

    public ChargebackConsumerQualityMerchandiseReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerQualityMerchandiseReturned(
        ChargebackConsumerQualityMerchandiseReturned chargebackConsumerQualityMerchandiseReturned
    )
        : base(chargebackConsumerQualityMerchandiseReturned) { }
#pragma warning restore CS8618

    public ChargebackConsumerQualityMerchandiseReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerQualityMerchandiseReturned(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerQualityMerchandiseReturnedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerQualityMerchandiseReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerQualityMerchandiseReturnedFromRaw
    : IFromRawJson<ChargebackConsumerQualityMerchandiseReturned>
{
    /// <inheritdoc/>
    public ChargebackConsumerQualityMerchandiseReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerQualityMerchandiseReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return method.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerQualityMerchandiseReturnedReturnMethodConverter))]
public enum ChargebackConsumerQualityMerchandiseReturnedReturnMethod
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

sealed class ChargebackConsumerQualityMerchandiseReturnedReturnMethodConverter
    : JsonConverter<ChargebackConsumerQualityMerchandiseReturnedReturnMethod>
{
    public override ChargebackConsumerQualityMerchandiseReturnedReturnMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dhl" => ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            "face_to_face" => ChargebackConsumerQualityMerchandiseReturnedReturnMethod.FaceToFace,
            "fedex" => ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Fedex,
            "other" => ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Other,
            "postal_service" =>
                ChargebackConsumerQualityMerchandiseReturnedReturnMethod.PostalService,
            "ups" => ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Ups,
            _ => (ChargebackConsumerQualityMerchandiseReturnedReturnMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerQualityMerchandiseReturnedReturnMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl => "dhl",
                ChargebackConsumerQualityMerchandiseReturnedReturnMethod.FaceToFace =>
                    "face_to_face",
                ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Fedex => "fedex",
                ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Other => "other",
                ChargebackConsumerQualityMerchandiseReturnedReturnMethod.PostalService =>
                    "postal_service",
                ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Ups => "ups",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Services quality issue. Required if and only if `category` is `consumer_quality_services`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerQualityServices,
        ChargebackConsumerQualityServicesFromRaw
    >)
)]
public sealed record class ChargebackConsumerQualityServices : JsonModel
{
    /// <summary>
    /// Cardholder cancellation.
    /// </summary>
    public required ChargebackConsumerQualityServicesCardholderCancellation CardholderCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ChargebackConsumerQualityServicesCardholderCancellation>(
                "cardholder_cancellation"
            );
        }
        init { this._rawData.Set("cardholder_cancellation", value); }
    }

    /// <summary>
    /// Non-fiat currency or non-fungible token related and not matching description.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
    > NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
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

    /// <summary>
    /// Cardholder paid to have work redone.
    /// </summary>
    public ApiEnum<
        string,
        ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone
    >? CardholderPaidToHaveWorkRedone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone>
            >("cardholder_paid_to_have_work_redone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cardholder_paid_to_have_work_redone", value);
        }
    }

    /// <summary>
    /// Ongoing negotiations. Exclude if there is no evidence of ongoing negotiations.
    /// </summary>
    public ChargebackConsumerQualityServicesOngoingNegotiations? OngoingNegotiations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerQualityServicesOngoingNegotiations>(
                "ongoing_negotiations"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ongoing_negotiations", value);
        }
    }

    /// <summary>
    /// Whether the dispute is related to the quality of food from an eating place
    /// or restaurant. Must be provided when Merchant Category Code (MCC) is 5812,
    /// 5813 or 5814.
    /// </summary>
    public ApiEnum<
        string,
        ChargebackConsumerQualityServicesRestaurantFoodRelated
    >? RestaurantFoodRelated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ChargebackConsumerQualityServicesRestaurantFoodRelated>
            >("restaurant_food_related");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("restaurant_food_related", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CardholderCancellation.Validate();
        this.NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.Validate();
        _ = this.PurchaseInfoAndQualityIssue;
        _ = this.ServicesReceivedAt;
        this.CardholderPaidToHaveWorkRedone?.Validate();
        this.OngoingNegotiations?.Validate();
        this.RestaurantFoodRelated?.Validate();
    }

    public ChargebackConsumerQualityServices() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerQualityServices(
        ChargebackConsumerQualityServices chargebackConsumerQualityServices
    )
        : base(chargebackConsumerQualityServices) { }
#pragma warning restore CS8618

    public ChargebackConsumerQualityServices(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerQualityServices(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerQualityServicesFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerQualityServices FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerQualityServicesFromRaw : IFromRawJson<ChargebackConsumerQualityServices>
{
    /// <inheritdoc/>
    public ChargebackConsumerQualityServices FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerQualityServices.FromRawUnchecked(rawData);
}

/// <summary>
/// Cardholder cancellation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerQualityServicesCardholderCancellation,
        ChargebackConsumerQualityServicesCardholderCancellationFromRaw
    >)
)]
public sealed record class ChargebackConsumerQualityServicesCardholderCancellation : JsonModel
{
    /// <summary>
    /// Accepted by merchant.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant
    > AcceptedByMerchant
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant
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

    public ChargebackConsumerQualityServicesCardholderCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerQualityServicesCardholderCancellation(
        ChargebackConsumerQualityServicesCardholderCancellation chargebackConsumerQualityServicesCardholderCancellation
    )
        : base(chargebackConsumerQualityServicesCardholderCancellation) { }
#pragma warning restore CS8618

    public ChargebackConsumerQualityServicesCardholderCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerQualityServicesCardholderCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerQualityServicesCardholderCancellationFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerQualityServicesCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerQualityServicesCardholderCancellationFromRaw
    : IFromRawJson<ChargebackConsumerQualityServicesCardholderCancellation>
{
    /// <inheritdoc/>
    public ChargebackConsumerQualityServicesCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerQualityServicesCardholderCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// Accepted by merchant.
/// </summary>
[JsonConverter(
    typeof(ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchantConverter)
)]
public enum ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant
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

sealed class ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchantConverter
    : JsonConverter<ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant>
{
    public override ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" =>
                ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
            "not_accepted" =>
                ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.NotAccepted,
            _ => (ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted =>
                    "accepted",
                ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.NotAccepted =>
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
/// Non-fiat currency or non-fungible token related and not matching description.
/// </summary>
[JsonConverter(
    typeof(ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescriptionConverter)
)]
public enum ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
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

sealed class ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescriptionConverter
    : JsonConverter<ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription>
{
    public override ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_related" =>
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            "related" =>
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.Related,
            _ =>
                (ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated =>
                    "not_related",
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.Related =>
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
/// Cardholder paid to have work redone.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedoneConverter))]
public enum ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone
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

sealed class ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedoneConverter
    : JsonConverter<ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone>
{
    public override ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "did_not_pay_to_have_work_redone" =>
                ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            "paid_to_have_work_redone" =>
                ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.PaidToHaveWorkRedone,
            _ => (ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone =>
                    "did_not_pay_to_have_work_redone",
                ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.PaidToHaveWorkRedone =>
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
/// Ongoing negotiations. Exclude if there is no evidence of ongoing negotiations.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerQualityServicesOngoingNegotiations,
        ChargebackConsumerQualityServicesOngoingNegotiationsFromRaw
    >)
)]
public sealed record class ChargebackConsumerQualityServicesOngoingNegotiations : JsonModel
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

    public ChargebackConsumerQualityServicesOngoingNegotiations() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerQualityServicesOngoingNegotiations(
        ChargebackConsumerQualityServicesOngoingNegotiations chargebackConsumerQualityServicesOngoingNegotiations
    )
        : base(chargebackConsumerQualityServicesOngoingNegotiations) { }
#pragma warning restore CS8618

    public ChargebackConsumerQualityServicesOngoingNegotiations(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerQualityServicesOngoingNegotiations(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerQualityServicesOngoingNegotiationsFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerQualityServicesOngoingNegotiations FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerQualityServicesOngoingNegotiationsFromRaw
    : IFromRawJson<ChargebackConsumerQualityServicesOngoingNegotiations>
{
    /// <inheritdoc/>
    public ChargebackConsumerQualityServicesOngoingNegotiations FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerQualityServicesOngoingNegotiations.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the dispute is related to the quality of food from an eating place or
/// restaurant. Must be provided when Merchant Category Code (MCC) is 5812, 5813 or 5814.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerQualityServicesRestaurantFoodRelatedConverter))]
public enum ChargebackConsumerQualityServicesRestaurantFoodRelated
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

sealed class ChargebackConsumerQualityServicesRestaurantFoodRelatedConverter
    : JsonConverter<ChargebackConsumerQualityServicesRestaurantFoodRelated>
{
    public override ChargebackConsumerQualityServicesRestaurantFoodRelated Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_related" => ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
            "related" => ChargebackConsumerQualityServicesRestaurantFoodRelated.Related,
            _ => (ChargebackConsumerQualityServicesRestaurantFoodRelated)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerQualityServicesRestaurantFoodRelated value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated => "not_related",
                ChargebackConsumerQualityServicesRestaurantFoodRelated.Related => "related",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Services misrepresentation. Required if and only if `category` is `consumer_services_misrepresentation`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerServicesMisrepresentation,
        ChargebackConsumerServicesMisrepresentationFromRaw
    >)
)]
public sealed record class ChargebackConsumerServicesMisrepresentation : JsonModel
{
    /// <summary>
    /// Cardholder cancellation.
    /// </summary>
    public required ChargebackConsumerServicesMisrepresentationCardholderCancellation CardholderCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ChargebackConsumerServicesMisrepresentationCardholderCancellation>(
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
        ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted
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

    public ChargebackConsumerServicesMisrepresentation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerServicesMisrepresentation(
        ChargebackConsumerServicesMisrepresentation chargebackConsumerServicesMisrepresentation
    )
        : base(chargebackConsumerServicesMisrepresentation) { }
#pragma warning restore CS8618

    public ChargebackConsumerServicesMisrepresentation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerServicesMisrepresentation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerServicesMisrepresentationFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerServicesMisrepresentation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerServicesMisrepresentationFromRaw
    : IFromRawJson<ChargebackConsumerServicesMisrepresentation>
{
    /// <inheritdoc/>
    public ChargebackConsumerServicesMisrepresentation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerServicesMisrepresentation.FromRawUnchecked(rawData);
}

/// <summary>
/// Cardholder cancellation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerServicesMisrepresentationCardholderCancellation,
        ChargebackConsumerServicesMisrepresentationCardholderCancellationFromRaw
    >)
)]
public sealed record class ChargebackConsumerServicesMisrepresentationCardholderCancellation
    : JsonModel
{
    /// <summary>
    /// Accepted by merchant.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
    > AcceptedByMerchant
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
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

    public ChargebackConsumerServicesMisrepresentationCardholderCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerServicesMisrepresentationCardholderCancellation(
        ChargebackConsumerServicesMisrepresentationCardholderCancellation chargebackConsumerServicesMisrepresentationCardholderCancellation
    )
        : base(chargebackConsumerServicesMisrepresentationCardholderCancellation) { }
#pragma warning restore CS8618

    public ChargebackConsumerServicesMisrepresentationCardholderCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerServicesMisrepresentationCardholderCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerServicesMisrepresentationCardholderCancellationFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerServicesMisrepresentationCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerServicesMisrepresentationCardholderCancellationFromRaw
    : IFromRawJson<ChargebackConsumerServicesMisrepresentationCardholderCancellation>
{
    /// <inheritdoc/>
    public ChargebackConsumerServicesMisrepresentationCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ChargebackConsumerServicesMisrepresentationCardholderCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// Accepted by merchant.
/// </summary>
[JsonConverter(
    typeof(ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchantConverter)
)]
public enum ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
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

sealed class ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchantConverter
    : JsonConverter<ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant>
{
    public override ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" =>
                ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
            "not_accepted" =>
                ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.NotAccepted,
            _ =>
                (ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted =>
                    "accepted",
                ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.NotAccepted =>
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
    typeof(ChargebackConsumerServicesMisrepresentationMerchantResolutionAttemptedConverter)
)]
public enum ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted
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

sealed class ChargebackConsumerServicesMisrepresentationMerchantResolutionAttemptedConverter
    : JsonConverter<ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted>
{
    public override ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted =>
                    "attempted",
                ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
/// Services not as described. Required if and only if `category` is `consumer_services_not_as_described`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerServicesNotAsDescribed,
        ChargebackConsumerServicesNotAsDescribedFromRaw
    >)
)]
public sealed record class ChargebackConsumerServicesNotAsDescribed : JsonModel
{
    /// <summary>
    /// Cardholder cancellation.
    /// </summary>
    public required ChargebackConsumerServicesNotAsDescribedCardholderCancellation CardholderCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ChargebackConsumerServicesNotAsDescribedCardholderCancellation>(
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
        ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted>
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

    public ChargebackConsumerServicesNotAsDescribed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerServicesNotAsDescribed(
        ChargebackConsumerServicesNotAsDescribed chargebackConsumerServicesNotAsDescribed
    )
        : base(chargebackConsumerServicesNotAsDescribed) { }
#pragma warning restore CS8618

    public ChargebackConsumerServicesNotAsDescribed(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerServicesNotAsDescribed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerServicesNotAsDescribedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerServicesNotAsDescribed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerServicesNotAsDescribedFromRaw
    : IFromRawJson<ChargebackConsumerServicesNotAsDescribed>
{
    /// <inheritdoc/>
    public ChargebackConsumerServicesNotAsDescribed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerServicesNotAsDescribed.FromRawUnchecked(rawData);
}

/// <summary>
/// Cardholder cancellation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerServicesNotAsDescribedCardholderCancellation,
        ChargebackConsumerServicesNotAsDescribedCardholderCancellationFromRaw
    >)
)]
public sealed record class ChargebackConsumerServicesNotAsDescribedCardholderCancellation
    : JsonModel
{
    /// <summary>
    /// Accepted by merchant.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
    > AcceptedByMerchant
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
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

    public ChargebackConsumerServicesNotAsDescribedCardholderCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerServicesNotAsDescribedCardholderCancellation(
        ChargebackConsumerServicesNotAsDescribedCardholderCancellation chargebackConsumerServicesNotAsDescribedCardholderCancellation
    )
        : base(chargebackConsumerServicesNotAsDescribedCardholderCancellation) { }
#pragma warning restore CS8618

    public ChargebackConsumerServicesNotAsDescribedCardholderCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerServicesNotAsDescribedCardholderCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerServicesNotAsDescribedCardholderCancellationFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerServicesNotAsDescribedCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerServicesNotAsDescribedCardholderCancellationFromRaw
    : IFromRawJson<ChargebackConsumerServicesNotAsDescribedCardholderCancellation>
{
    /// <inheritdoc/>
    public ChargebackConsumerServicesNotAsDescribedCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerServicesNotAsDescribedCardholderCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// Accepted by merchant.
/// </summary>
[JsonConverter(
    typeof(ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchantConverter)
)]
public enum ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
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

sealed class ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchantConverter
    : JsonConverter<ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant>
{
    public override ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" =>
                ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
            "not_accepted" =>
                ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.NotAccepted,
            _ => (ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted =>
                    "accepted",
                ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.NotAccepted =>
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
    typeof(ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttemptedConverter)
)]
public enum ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted
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

sealed class ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttemptedConverter
    : JsonConverter<ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted>
{
    public override ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted =>
                    "attempted",
                ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
/// Services not received. Required if and only if `category` is `consumer_services_not_received`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerServicesNotReceived,
        ChargebackConsumerServicesNotReceivedFromRaw
    >)
)]
public sealed record class ChargebackConsumerServicesNotReceived : JsonModel
{
    /// <summary>
    /// Cancellation outcome.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerServicesNotReceivedCancellationOutcome
    > CancellationOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerServicesNotReceivedCancellationOutcome>
            >("cancellation_outcome");
        }
        init { this._rawData.Set("cancellation_outcome", value); }
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
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted>
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
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

    /// <summary>
    /// Cardholder cancellation prior to expected receipt. Required if and only if
    /// `cancellation_outcome` is `cardholder_cancellation_prior_to_expected_receipt`.
    /// </summary>
    public ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt? CardholderCancellationPriorToExpectedReceipt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt>(
                "cardholder_cancellation_prior_to_expected_receipt"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cardholder_cancellation_prior_to_expected_receipt", value);
        }
    }

    /// <summary>
    /// Merchant cancellation. Required if and only if `cancellation_outcome` is `merchant_cancellation`.
    /// </summary>
    public ChargebackConsumerServicesNotReceivedMerchantCancellation? MerchantCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerServicesNotReceivedMerchantCancellation>(
                "merchant_cancellation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("merchant_cancellation", value);
        }
    }

    /// <summary>
    /// No cancellation. Required if and only if `cancellation_outcome` is `no_cancellation`.
    /// </summary>
    public ChargebackConsumerServicesNotReceivedNoCancellation? NoCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackConsumerServicesNotReceivedNoCancellation>(
                "no_cancellation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("no_cancellation", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CancellationOutcome.Validate();
        _ = this.LastExpectedReceiptAt;
        this.MerchantResolutionAttempted.Validate();
        _ = this.PurchaseInfoAndExplanation;
        this.CardholderCancellationPriorToExpectedReceipt?.Validate();
        this.MerchantCancellation?.Validate();
        this.NoCancellation?.Validate();
    }

    public ChargebackConsumerServicesNotReceived() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerServicesNotReceived(
        ChargebackConsumerServicesNotReceived chargebackConsumerServicesNotReceived
    )
        : base(chargebackConsumerServicesNotReceived) { }
#pragma warning restore CS8618

    public ChargebackConsumerServicesNotReceived(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerServicesNotReceived(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerServicesNotReceivedFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerServicesNotReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerServicesNotReceivedFromRaw
    : IFromRawJson<ChargebackConsumerServicesNotReceived>
{
    /// <inheritdoc/>
    public ChargebackConsumerServicesNotReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerServicesNotReceived.FromRawUnchecked(rawData);
}

/// <summary>
/// Cancellation outcome.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerServicesNotReceivedCancellationOutcomeConverter))]
public enum ChargebackConsumerServicesNotReceivedCancellationOutcome
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

sealed class ChargebackConsumerServicesNotReceivedCancellationOutcomeConverter
    : JsonConverter<ChargebackConsumerServicesNotReceivedCancellationOutcome>
{
    public override ChargebackConsumerServicesNotReceivedCancellationOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cardholder_cancellation_prior_to_expected_receipt" =>
                ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            "merchant_cancellation" =>
                ChargebackConsumerServicesNotReceivedCancellationOutcome.MerchantCancellation,
            "no_cancellation" =>
                ChargebackConsumerServicesNotReceivedCancellationOutcome.NoCancellation,
            _ => (ChargebackConsumerServicesNotReceivedCancellationOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerServicesNotReceivedCancellationOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt =>
                    "cardholder_cancellation_prior_to_expected_receipt",
                ChargebackConsumerServicesNotReceivedCancellationOutcome.MerchantCancellation =>
                    "merchant_cancellation",
                ChargebackConsumerServicesNotReceivedCancellationOutcome.NoCancellation =>
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
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(typeof(ChargebackConsumerServicesNotReceivedMerchantResolutionAttemptedConverter))]
public enum ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted
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

sealed class ChargebackConsumerServicesNotReceivedMerchantResolutionAttemptedConverter
    : JsonConverter<ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted>
{
    public override ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted =>
                    "attempted",
                ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
/// Cardholder cancellation prior to expected receipt. Required if and only if `cancellation_outcome`
/// is `cardholder_cancellation_prior_to_expected_receipt`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt,
        ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceiptFromRaw
    >)
)]
public sealed record class ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
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
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanceledAt;
        _ = this.Reason;
    }

    public ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt(
        ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt chargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
    )
        : base(chargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt)
    { }
#pragma warning restore CS8618

    public ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceiptFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt(
        string canceledAt
    )
        : this()
    {
        this.CanceledAt = canceledAt;
    }
}

class ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceiptFromRaw
    : IFromRawJson<ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt>
{
    /// <inheritdoc/>
    public ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Merchant cancellation. Required if and only if `cancellation_outcome` is `merchant_cancellation`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerServicesNotReceivedMerchantCancellation,
        ChargebackConsumerServicesNotReceivedMerchantCancellationFromRaw
    >)
)]
public sealed record class ChargebackConsumerServicesNotReceivedMerchantCancellation : JsonModel
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

    public ChargebackConsumerServicesNotReceivedMerchantCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerServicesNotReceivedMerchantCancellation(
        ChargebackConsumerServicesNotReceivedMerchantCancellation chargebackConsumerServicesNotReceivedMerchantCancellation
    )
        : base(chargebackConsumerServicesNotReceivedMerchantCancellation) { }
#pragma warning restore CS8618

    public ChargebackConsumerServicesNotReceivedMerchantCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerServicesNotReceivedMerchantCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerServicesNotReceivedMerchantCancellationFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerServicesNotReceivedMerchantCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChargebackConsumerServicesNotReceivedMerchantCancellation(string canceledAt)
        : this()
    {
        this.CanceledAt = canceledAt;
    }
}

class ChargebackConsumerServicesNotReceivedMerchantCancellationFromRaw
    : IFromRawJson<ChargebackConsumerServicesNotReceivedMerchantCancellation>
{
    /// <inheritdoc/>
    public ChargebackConsumerServicesNotReceivedMerchantCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerServicesNotReceivedMerchantCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// No cancellation. Required if and only if `cancellation_outcome` is `no_cancellation`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackConsumerServicesNotReceivedNoCancellation,
        ChargebackConsumerServicesNotReceivedNoCancellationFromRaw
    >)
)]
public sealed record class ChargebackConsumerServicesNotReceivedNoCancellation : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ChargebackConsumerServicesNotReceivedNoCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackConsumerServicesNotReceivedNoCancellation(
        ChargebackConsumerServicesNotReceivedNoCancellation chargebackConsumerServicesNotReceivedNoCancellation
    )
        : base(chargebackConsumerServicesNotReceivedNoCancellation) { }
#pragma warning restore CS8618

    public ChargebackConsumerServicesNotReceivedNoCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackConsumerServicesNotReceivedNoCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackConsumerServicesNotReceivedNoCancellationFromRaw.FromRawUnchecked"/>
    public static ChargebackConsumerServicesNotReceivedNoCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackConsumerServicesNotReceivedNoCancellationFromRaw
    : IFromRawJson<ChargebackConsumerServicesNotReceivedNoCancellation>
{
    /// <inheritdoc/>
    public ChargebackConsumerServicesNotReceivedNoCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackConsumerServicesNotReceivedNoCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// Fraud. Required if and only if `category` is `fraud`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChargebackFraud, ChargebackFraudFromRaw>))]
public sealed record class ChargebackFraud : JsonModel
{
    /// <summary>
    /// Fraud type.
    /// </summary>
    public required ApiEnum<string, ChargebackFraudFraudType> FraudType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ChargebackFraudFraudType>>(
                "fraud_type"
            );
        }
        init { this._rawData.Set("fraud_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FraudType.Validate();
    }

    public ChargebackFraud() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackFraud(ChargebackFraud chargebackFraud)
        : base(chargebackFraud) { }
#pragma warning restore CS8618

    public ChargebackFraud(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackFraud(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackFraudFromRaw.FromRawUnchecked"/>
    public static ChargebackFraud FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChargebackFraud(ApiEnum<string, ChargebackFraudFraudType> fraudType)
        : this()
    {
        this.FraudType = fraudType;
    }
}

class ChargebackFraudFromRaw : IFromRawJson<ChargebackFraud>
{
    /// <inheritdoc/>
    public ChargebackFraud FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChargebackFraud.FromRawUnchecked(rawData);
}

/// <summary>
/// Fraud type.
/// </summary>
[JsonConverter(typeof(ChargebackFraudFraudTypeConverter))]
public enum ChargebackFraudFraudType
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

sealed class ChargebackFraudFraudTypeConverter : JsonConverter<ChargebackFraudFraudType>
{
    public override ChargebackFraudFraudType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_or_credentials_takeover" =>
                ChargebackFraudFraudType.AccountOrCredentialsTakeover,
            "card_not_received_as_issued" => ChargebackFraudFraudType.CardNotReceivedAsIssued,
            "fraudulent_application" => ChargebackFraudFraudType.FraudulentApplication,
            "fraudulent_use_of_account_number" =>
                ChargebackFraudFraudType.FraudulentUseOfAccountNumber,
            "incorrect_processing" => ChargebackFraudFraudType.IncorrectProcessing,
            "issuer_reported_counterfeit" => ChargebackFraudFraudType.IssuerReportedCounterfeit,
            "lost" => ChargebackFraudFraudType.Lost,
            "manipulation_of_account_holder" =>
                ChargebackFraudFraudType.ManipulationOfAccountHolder,
            "merchant_misrepresentation" => ChargebackFraudFraudType.MerchantMisrepresentation,
            "miscellaneous" => ChargebackFraudFraudType.Miscellaneous,
            "stolen" => ChargebackFraudFraudType.Stolen,
            _ => (ChargebackFraudFraudType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackFraudFraudType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackFraudFraudType.AccountOrCredentialsTakeover =>
                    "account_or_credentials_takeover",
                ChargebackFraudFraudType.CardNotReceivedAsIssued => "card_not_received_as_issued",
                ChargebackFraudFraudType.FraudulentApplication => "fraudulent_application",
                ChargebackFraudFraudType.FraudulentUseOfAccountNumber =>
                    "fraudulent_use_of_account_number",
                ChargebackFraudFraudType.IncorrectProcessing => "incorrect_processing",
                ChargebackFraudFraudType.IssuerReportedCounterfeit => "issuer_reported_counterfeit",
                ChargebackFraudFraudType.Lost => "lost",
                ChargebackFraudFraudType.ManipulationOfAccountHolder =>
                    "manipulation_of_account_holder",
                ChargebackFraudFraudType.MerchantMisrepresentation => "merchant_misrepresentation",
                ChargebackFraudFraudType.Miscellaneous => "miscellaneous",
                ChargebackFraudFraudType.Stolen => "stolen",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Processing error. Required if and only if `category` is `processing_error`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ChargebackProcessingError, ChargebackProcessingErrorFromRaw>)
)]
public sealed record class ChargebackProcessingError : JsonModel
{
    /// <summary>
    /// Error reason.
    /// </summary>
    public required ApiEnum<string, ChargebackProcessingErrorErrorReason> ErrorReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackProcessingErrorErrorReason>
            >("error_reason");
        }
        init { this._rawData.Set("error_reason", value); }
    }

    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackProcessingErrorMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackProcessingErrorMerchantResolutionAttempted>
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
    }

    /// <summary>
    /// Duplicate transaction. Required if and only if `error_reason` is `duplicate_transaction`.
    /// </summary>
    public ChargebackProcessingErrorDuplicateTransaction? DuplicateTransaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackProcessingErrorDuplicateTransaction>(
                "duplicate_transaction"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("duplicate_transaction", value);
        }
    }

    /// <summary>
    /// Incorrect amount. Required if and only if `error_reason` is `incorrect_amount`.
    /// </summary>
    public ChargebackProcessingErrorIncorrectAmount? IncorrectAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackProcessingErrorIncorrectAmount>(
                "incorrect_amount"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("incorrect_amount", value);
        }
    }

    /// <summary>
    /// Paid by other means. Required if and only if `error_reason` is `paid_by_other_means`.
    /// </summary>
    public ChargebackProcessingErrorPaidByOtherMeans? PaidByOtherMeans
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargebackProcessingErrorPaidByOtherMeans>(
                "paid_by_other_means"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("paid_by_other_means", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ErrorReason.Validate();
        this.MerchantResolutionAttempted.Validate();
        this.DuplicateTransaction?.Validate();
        this.IncorrectAmount?.Validate();
        this.PaidByOtherMeans?.Validate();
    }

    public ChargebackProcessingError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackProcessingError(ChargebackProcessingError chargebackProcessingError)
        : base(chargebackProcessingError) { }
#pragma warning restore CS8618

    public ChargebackProcessingError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackProcessingError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackProcessingErrorFromRaw.FromRawUnchecked"/>
    public static ChargebackProcessingError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargebackProcessingErrorFromRaw : IFromRawJson<ChargebackProcessingError>
{
    /// <inheritdoc/>
    public ChargebackProcessingError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackProcessingError.FromRawUnchecked(rawData);
}

/// <summary>
/// Error reason.
/// </summary>
[JsonConverter(typeof(ChargebackProcessingErrorErrorReasonConverter))]
public enum ChargebackProcessingErrorErrorReason
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

sealed class ChargebackProcessingErrorErrorReasonConverter
    : JsonConverter<ChargebackProcessingErrorErrorReason>
{
    public override ChargebackProcessingErrorErrorReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "duplicate_transaction" => ChargebackProcessingErrorErrorReason.DuplicateTransaction,
            "incorrect_amount" => ChargebackProcessingErrorErrorReason.IncorrectAmount,
            "paid_by_other_means" => ChargebackProcessingErrorErrorReason.PaidByOtherMeans,
            _ => (ChargebackProcessingErrorErrorReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackProcessingErrorErrorReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackProcessingErrorErrorReason.DuplicateTransaction =>
                    "duplicate_transaction",
                ChargebackProcessingErrorErrorReason.IncorrectAmount => "incorrect_amount",
                ChargebackProcessingErrorErrorReason.PaidByOtherMeans => "paid_by_other_means",
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
[JsonConverter(typeof(ChargebackProcessingErrorMerchantResolutionAttemptedConverter))]
public enum ChargebackProcessingErrorMerchantResolutionAttempted
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

sealed class ChargebackProcessingErrorMerchantResolutionAttemptedConverter
    : JsonConverter<ChargebackProcessingErrorMerchantResolutionAttempted>
{
    public override ChargebackProcessingErrorMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" => ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ChargebackProcessingErrorMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ChargebackProcessingErrorMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackProcessingErrorMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackProcessingErrorMerchantResolutionAttempted.Attempted => "attempted",
                ChargebackProcessingErrorMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
/// Duplicate transaction. Required if and only if `error_reason` is `duplicate_transaction`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackProcessingErrorDuplicateTransaction,
        ChargebackProcessingErrorDuplicateTransactionFromRaw
    >)
)]
public sealed record class ChargebackProcessingErrorDuplicateTransaction : JsonModel
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

    public ChargebackProcessingErrorDuplicateTransaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackProcessingErrorDuplicateTransaction(
        ChargebackProcessingErrorDuplicateTransaction chargebackProcessingErrorDuplicateTransaction
    )
        : base(chargebackProcessingErrorDuplicateTransaction) { }
#pragma warning restore CS8618

    public ChargebackProcessingErrorDuplicateTransaction(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackProcessingErrorDuplicateTransaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackProcessingErrorDuplicateTransactionFromRaw.FromRawUnchecked"/>
    public static ChargebackProcessingErrorDuplicateTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChargebackProcessingErrorDuplicateTransaction(string otherTransactionID)
        : this()
    {
        this.OtherTransactionID = otherTransactionID;
    }
}

class ChargebackProcessingErrorDuplicateTransactionFromRaw
    : IFromRawJson<ChargebackProcessingErrorDuplicateTransaction>
{
    /// <inheritdoc/>
    public ChargebackProcessingErrorDuplicateTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackProcessingErrorDuplicateTransaction.FromRawUnchecked(rawData);
}

/// <summary>
/// Incorrect amount. Required if and only if `error_reason` is `incorrect_amount`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackProcessingErrorIncorrectAmount,
        ChargebackProcessingErrorIncorrectAmountFromRaw
    >)
)]
public sealed record class ChargebackProcessingErrorIncorrectAmount : JsonModel
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

    public ChargebackProcessingErrorIncorrectAmount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackProcessingErrorIncorrectAmount(
        ChargebackProcessingErrorIncorrectAmount chargebackProcessingErrorIncorrectAmount
    )
        : base(chargebackProcessingErrorIncorrectAmount) { }
#pragma warning restore CS8618

    public ChargebackProcessingErrorIncorrectAmount(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackProcessingErrorIncorrectAmount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackProcessingErrorIncorrectAmountFromRaw.FromRawUnchecked"/>
    public static ChargebackProcessingErrorIncorrectAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChargebackProcessingErrorIncorrectAmount(long expectedAmount)
        : this()
    {
        this.ExpectedAmount = expectedAmount;
    }
}

class ChargebackProcessingErrorIncorrectAmountFromRaw
    : IFromRawJson<ChargebackProcessingErrorIncorrectAmount>
{
    /// <inheritdoc/>
    public ChargebackProcessingErrorIncorrectAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackProcessingErrorIncorrectAmount.FromRawUnchecked(rawData);
}

/// <summary>
/// Paid by other means. Required if and only if `error_reason` is `paid_by_other_means`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChargebackProcessingErrorPaidByOtherMeans,
        ChargebackProcessingErrorPaidByOtherMeansFromRaw
    >)
)]
public sealed record class ChargebackProcessingErrorPaidByOtherMeans : JsonModel
{
    /// <summary>
    /// Other form of payment evidence.
    /// </summary>
    public required ApiEnum<
        string,
        ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence
    > OtherFormOfPaymentEvidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence>
            >("other_form_of_payment_evidence");
        }
        init { this._rawData.Set("other_form_of_payment_evidence", value); }
    }

    /// <summary>
    /// Other transaction ID.
    /// </summary>
    public string? OtherTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("other_transaction_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("other_transaction_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.OtherFormOfPaymentEvidence.Validate();
        _ = this.OtherTransactionID;
    }

    public ChargebackProcessingErrorPaidByOtherMeans() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargebackProcessingErrorPaidByOtherMeans(
        ChargebackProcessingErrorPaidByOtherMeans chargebackProcessingErrorPaidByOtherMeans
    )
        : base(chargebackProcessingErrorPaidByOtherMeans) { }
#pragma warning restore CS8618

    public ChargebackProcessingErrorPaidByOtherMeans(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargebackProcessingErrorPaidByOtherMeans(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargebackProcessingErrorPaidByOtherMeansFromRaw.FromRawUnchecked"/>
    public static ChargebackProcessingErrorPaidByOtherMeans FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChargebackProcessingErrorPaidByOtherMeans(
        ApiEnum<
            string,
            ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence
        > otherFormOfPaymentEvidence
    )
        : this()
    {
        this.OtherFormOfPaymentEvidence = otherFormOfPaymentEvidence;
    }
}

class ChargebackProcessingErrorPaidByOtherMeansFromRaw
    : IFromRawJson<ChargebackProcessingErrorPaidByOtherMeans>
{
    /// <inheritdoc/>
    public ChargebackProcessingErrorPaidByOtherMeans FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargebackProcessingErrorPaidByOtherMeans.FromRawUnchecked(rawData);
}

/// <summary>
/// Other form of payment evidence.
/// </summary>
[JsonConverter(
    typeof(ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidenceConverter)
)]
public enum ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence
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

sealed class ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidenceConverter
    : JsonConverter<ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence>
{
    public override ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "canceled_check" =>
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
            "card_transaction" =>
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CardTransaction,
            "cash_receipt" =>
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CashReceipt,
            "other" => ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Other,
            "statement" =>
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Statement,
            "voucher" =>
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Voucher,
            _ => (ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck =>
                    "canceled_check",
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CardTransaction =>
                    "card_transaction",
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CashReceipt =>
                    "cash_receipt",
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Other =>
                    "other",
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Statement =>
                    "statement",
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Voucher =>
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
/// The merchant pre-arbitration decline details for the user submission. Required
/// if and only if `category` is `merchant_prearbitration_decline`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<MerchantPrearbitrationDecline, MerchantPrearbitrationDeclineFromRaw>)
)]
public sealed record class MerchantPrearbitrationDecline : JsonModel
{
    /// <summary>
    /// The reason for declining the merchant's pre-arbitration request.
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

    public MerchantPrearbitrationDecline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MerchantPrearbitrationDecline(
        MerchantPrearbitrationDecline merchantPrearbitrationDecline
    )
        : base(merchantPrearbitrationDecline) { }
#pragma warning restore CS8618

    public MerchantPrearbitrationDecline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MerchantPrearbitrationDecline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MerchantPrearbitrationDeclineFromRaw.FromRawUnchecked"/>
    public static MerchantPrearbitrationDecline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MerchantPrearbitrationDecline(string reason)
        : this()
    {
        this.Reason = reason;
    }
}

class MerchantPrearbitrationDeclineFromRaw : IFromRawJson<MerchantPrearbitrationDecline>
{
    /// <inheritdoc/>
    public MerchantPrearbitrationDecline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MerchantPrearbitrationDecline.FromRawUnchecked(rawData);
}

/// <summary>
/// The user pre-arbitration details for the user submission. Required if and only
/// if `category` is `user_prearbitration`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserPrearbitration, UserPrearbitrationFromRaw>))]
public sealed record class UserPrearbitration : JsonModel
{
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

    /// <summary>
    /// Category change details for the pre-arbitration request. Should only be populated
    /// if the category of the dispute is being changed as part of the pre-arbitration request.
    /// </summary>
    public CategoryChange? CategoryChange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CategoryChange>("category_change");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("category_change", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reason;
        this.CategoryChange?.Validate();
    }

    public UserPrearbitration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserPrearbitration(UserPrearbitration userPrearbitration)
        : base(userPrearbitration) { }
#pragma warning restore CS8618

    public UserPrearbitration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserPrearbitration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserPrearbitrationFromRaw.FromRawUnchecked"/>
    public static UserPrearbitration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserPrearbitration(string reason)
        : this()
    {
        this.Reason = reason;
    }
}

class UserPrearbitrationFromRaw : IFromRawJson<UserPrearbitration>
{
    /// <inheritdoc/>
    public UserPrearbitration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserPrearbitration.FromRawUnchecked(rawData);
}

/// <summary>
/// Category change details for the pre-arbitration request. Should only be populated
/// if the category of the dispute is being changed as part of the pre-arbitration request.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CategoryChange, CategoryChangeFromRaw>))]
public sealed record class CategoryChange : JsonModel
{
    public required ApiEnum<string, CategoryChangeCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CategoryChangeCategory>>(
                "category"
            );
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// The reason for the category change.
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

    public CategoryChange() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CategoryChange(CategoryChange categoryChange)
        : base(categoryChange) { }
#pragma warning restore CS8618

    public CategoryChange(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CategoryChange(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CategoryChangeFromRaw.FromRawUnchecked"/>
    public static CategoryChange FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CategoryChangeFromRaw : IFromRawJson<CategoryChange>
{
    /// <inheritdoc/>
    public CategoryChange FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CategoryChange.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CategoryChangeCategoryConverter))]
public enum CategoryChangeCategory
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

sealed class CategoryChangeCategoryConverter : JsonConverter<CategoryChangeCategory>
{
    public override CategoryChangeCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "authorization" => CategoryChangeCategory.Authorization,
            "consumer_canceled_merchandise" => CategoryChangeCategory.ConsumerCanceledMerchandise,
            "consumer_canceled_recurring_transaction" =>
                CategoryChangeCategory.ConsumerCanceledRecurringTransaction,
            "consumer_canceled_services" => CategoryChangeCategory.ConsumerCanceledServices,
            "consumer_counterfeit_merchandise" =>
                CategoryChangeCategory.ConsumerCounterfeitMerchandise,
            "consumer_credit_not_processed" => CategoryChangeCategory.ConsumerCreditNotProcessed,
            "consumer_damaged_or_defective_merchandise" =>
                CategoryChangeCategory.ConsumerDamagedOrDefectiveMerchandise,
            "consumer_merchandise_misrepresentation" =>
                CategoryChangeCategory.ConsumerMerchandiseMisrepresentation,
            "consumer_merchandise_not_as_described" =>
                CategoryChangeCategory.ConsumerMerchandiseNotAsDescribed,
            "consumer_merchandise_not_received" =>
                CategoryChangeCategory.ConsumerMerchandiseNotReceived,
            "consumer_non_receipt_of_cash" => CategoryChangeCategory.ConsumerNonReceiptOfCash,
            "consumer_original_credit_transaction_not_accepted" =>
                CategoryChangeCategory.ConsumerOriginalCreditTransactionNotAccepted,
            "consumer_quality_merchandise" => CategoryChangeCategory.ConsumerQualityMerchandise,
            "consumer_quality_services" => CategoryChangeCategory.ConsumerQualityServices,
            "consumer_services_misrepresentation" =>
                CategoryChangeCategory.ConsumerServicesMisrepresentation,
            "consumer_services_not_as_described" =>
                CategoryChangeCategory.ConsumerServicesNotAsDescribed,
            "consumer_services_not_received" => CategoryChangeCategory.ConsumerServicesNotReceived,
            "fraud" => CategoryChangeCategory.Fraud,
            "processing_error" => CategoryChangeCategory.ProcessingError,
            _ => (CategoryChangeCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CategoryChangeCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CategoryChangeCategory.Authorization => "authorization",
                CategoryChangeCategory.ConsumerCanceledMerchandise =>
                    "consumer_canceled_merchandise",
                CategoryChangeCategory.ConsumerCanceledRecurringTransaction =>
                    "consumer_canceled_recurring_transaction",
                CategoryChangeCategory.ConsumerCanceledServices => "consumer_canceled_services",
                CategoryChangeCategory.ConsumerCounterfeitMerchandise =>
                    "consumer_counterfeit_merchandise",
                CategoryChangeCategory.ConsumerCreditNotProcessed =>
                    "consumer_credit_not_processed",
                CategoryChangeCategory.ConsumerDamagedOrDefectiveMerchandise =>
                    "consumer_damaged_or_defective_merchandise",
                CategoryChangeCategory.ConsumerMerchandiseMisrepresentation =>
                    "consumer_merchandise_misrepresentation",
                CategoryChangeCategory.ConsumerMerchandiseNotAsDescribed =>
                    "consumer_merchandise_not_as_described",
                CategoryChangeCategory.ConsumerMerchandiseNotReceived =>
                    "consumer_merchandise_not_received",
                CategoryChangeCategory.ConsumerNonReceiptOfCash => "consumer_non_receipt_of_cash",
                CategoryChangeCategory.ConsumerOriginalCreditTransactionNotAccepted =>
                    "consumer_original_credit_transaction_not_accepted",
                CategoryChangeCategory.ConsumerQualityMerchandise => "consumer_quality_merchandise",
                CategoryChangeCategory.ConsumerQualityServices => "consumer_quality_services",
                CategoryChangeCategory.ConsumerServicesMisrepresentation =>
                    "consumer_services_misrepresentation",
                CategoryChangeCategory.ConsumerServicesNotAsDescribed =>
                    "consumer_services_not_as_described",
                CategoryChangeCategory.ConsumerServicesNotReceived =>
                    "consumer_services_not_received",
                CategoryChangeCategory.Fraud => "fraud",
                CategoryChangeCategory.ProcessingError => "processing_error",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
