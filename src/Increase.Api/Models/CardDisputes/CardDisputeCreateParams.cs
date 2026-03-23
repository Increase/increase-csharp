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
/// Create a Card Dispute
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CardDisputeCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The Transaction you wish to dispute. This Transaction must have a `source_type`
    /// of `card_settlement`.
    /// </summary>
    public required string DisputedTransactionID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("disputed_transaction_id");
        }
        init { this._rawBodyData.Set("disputed_transaction_id", value); }
    }

    /// <summary>
    /// The network of the disputed transaction. Details specific to the network are
    /// required under the sub-object with the same identifier as the network.
    /// </summary>
    public required ApiEnum<string, Network> Network
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Network>>("network");
        }
        init { this._rawBodyData.Set("network", value); }
    }

    /// <summary>
    /// The monetary amount of the part of the transaction that is being disputed.
    /// This is optional and will default to the full amount of the transaction if
    /// not provided. If provided, the amount must be less than or equal to the amount
    /// of the transaction.
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
    /// The files to be attached to the initial dispute submission.
    /// </summary>
    public IReadOnlyList<AttachmentFile>? AttachmentFiles
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AttachmentFile>>(
                "attachment_files"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<AttachmentFile>?>(
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
    public Visa? Visa
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Visa>("visa");
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

    public CardDisputeCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDisputeCreateParams(CardDisputeCreateParams cardDisputeCreateParams)
        : base(cardDisputeCreateParams)
    {
        this._rawBodyData = new(cardDisputeCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CardDisputeCreateParams(
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
    CardDisputeCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CardDisputeCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CardDisputeCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/card_disputes")
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
/// The network of the disputed transaction. Details specific to the network are
/// required under the sub-object with the same identifier as the network.
/// </summary>
[JsonConverter(typeof(NetworkConverter))]
public enum Network
{
    /// <summary>
    /// Visa
    /// </summary>
    Visa,
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
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<AttachmentFile, AttachmentFileFromRaw>))]
public sealed record class AttachmentFile : JsonModel
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

    public AttachmentFile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttachmentFile(AttachmentFile attachmentFile)
        : base(attachmentFile) { }
#pragma warning restore CS8618

    public AttachmentFile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttachmentFile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttachmentFileFromRaw.FromRawUnchecked"/>
    public static AttachmentFile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AttachmentFile(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class AttachmentFileFromRaw : IFromRawJson<AttachmentFile>
{
    /// <inheritdoc/>
    public AttachmentFile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AttachmentFile.FromRawUnchecked(rawData);
}

/// <summary>
/// The Visa-specific parameters for the dispute. Required if and only if `network`
/// is `visa`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Visa, VisaFromRaw>))]
public sealed record class Visa : JsonModel
{
    /// <summary>
    /// Category.
    /// </summary>
    public required ApiEnum<string, Category> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Category>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Authorization. Required if and only if `category` is `authorization`.
    /// </summary>
    public Authorization? Authorization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Authorization>("authorization");
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
    public ConsumerCanceledMerchandise? ConsumerCanceledMerchandise
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerCanceledMerchandise>(
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
    public ConsumerCanceledRecurringTransaction? ConsumerCanceledRecurringTransaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerCanceledRecurringTransaction>(
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
    public ConsumerCanceledServices? ConsumerCanceledServices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerCanceledServices>(
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
    public ConsumerCounterfeitMerchandise? ConsumerCounterfeitMerchandise
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerCounterfeitMerchandise>(
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
    public ConsumerCreditNotProcessed? ConsumerCreditNotProcessed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerCreditNotProcessed>(
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
    public ConsumerDamagedOrDefectiveMerchandise? ConsumerDamagedOrDefectiveMerchandise
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerDamagedOrDefectiveMerchandise>(
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
    public ConsumerMerchandiseMisrepresentation? ConsumerMerchandiseMisrepresentation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerMerchandiseMisrepresentation>(
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
    public ConsumerMerchandiseNotAsDescribed? ConsumerMerchandiseNotAsDescribed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerMerchandiseNotAsDescribed>(
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
    public ConsumerMerchandiseNotReceived? ConsumerMerchandiseNotReceived
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerMerchandiseNotReceived>(
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
    public ConsumerNonReceiptOfCash? ConsumerNonReceiptOfCash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerNonReceiptOfCash>(
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
    public ConsumerOriginalCreditTransactionNotAccepted? ConsumerOriginalCreditTransactionNotAccepted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerOriginalCreditTransactionNotAccepted>(
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
    public ConsumerQualityMerchandise? ConsumerQualityMerchandise
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerQualityMerchandise>(
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
    public ConsumerQualityServices? ConsumerQualityServices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerQualityServices>(
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
    public ConsumerServicesMisrepresentation? ConsumerServicesMisrepresentation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerServicesMisrepresentation>(
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
    public ConsumerServicesNotAsDescribed? ConsumerServicesNotAsDescribed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerServicesNotAsDescribed>(
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
    public ConsumerServicesNotReceived? ConsumerServicesNotReceived
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerServicesNotReceived>(
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
    public Fraud? Fraud
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Fraud>("fraud");
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
    public ProcessingError? ProcessingError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProcessingError>("processing_error");
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
    public Visa(ApiEnum<string, Category> category)
        : this()
    {
        this.Category = category;
    }
}

class VisaFromRaw : IFromRawJson<Visa>
{
    /// <inheritdoc/>
    public Visa FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Visa.FromRawUnchecked(rawData);
}

/// <summary>
/// Category.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
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

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "authorization" => Category.Authorization,
            "consumer_canceled_merchandise" => Category.ConsumerCanceledMerchandise,
            "consumer_canceled_recurring_transaction" =>
                Category.ConsumerCanceledRecurringTransaction,
            "consumer_canceled_services" => Category.ConsumerCanceledServices,
            "consumer_counterfeit_merchandise" => Category.ConsumerCounterfeitMerchandise,
            "consumer_credit_not_processed" => Category.ConsumerCreditNotProcessed,
            "consumer_damaged_or_defective_merchandise" =>
                Category.ConsumerDamagedOrDefectiveMerchandise,
            "consumer_merchandise_misrepresentation" =>
                Category.ConsumerMerchandiseMisrepresentation,
            "consumer_merchandise_not_as_described" => Category.ConsumerMerchandiseNotAsDescribed,
            "consumer_merchandise_not_received" => Category.ConsumerMerchandiseNotReceived,
            "consumer_non_receipt_of_cash" => Category.ConsumerNonReceiptOfCash,
            "consumer_original_credit_transaction_not_accepted" =>
                Category.ConsumerOriginalCreditTransactionNotAccepted,
            "consumer_quality_merchandise" => Category.ConsumerQualityMerchandise,
            "consumer_quality_services" => Category.ConsumerQualityServices,
            "consumer_services_misrepresentation" => Category.ConsumerServicesMisrepresentation,
            "consumer_services_not_as_described" => Category.ConsumerServicesNotAsDescribed,
            "consumer_services_not_received" => Category.ConsumerServicesNotReceived,
            "fraud" => Category.Fraud,
            "processing_error" => Category.ProcessingError,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.Authorization => "authorization",
                Category.ConsumerCanceledMerchandise => "consumer_canceled_merchandise",
                Category.ConsumerCanceledRecurringTransaction =>
                    "consumer_canceled_recurring_transaction",
                Category.ConsumerCanceledServices => "consumer_canceled_services",
                Category.ConsumerCounterfeitMerchandise => "consumer_counterfeit_merchandise",
                Category.ConsumerCreditNotProcessed => "consumer_credit_not_processed",
                Category.ConsumerDamagedOrDefectiveMerchandise =>
                    "consumer_damaged_or_defective_merchandise",
                Category.ConsumerMerchandiseMisrepresentation =>
                    "consumer_merchandise_misrepresentation",
                Category.ConsumerMerchandiseNotAsDescribed =>
                    "consumer_merchandise_not_as_described",
                Category.ConsumerMerchandiseNotReceived => "consumer_merchandise_not_received",
                Category.ConsumerNonReceiptOfCash => "consumer_non_receipt_of_cash",
                Category.ConsumerOriginalCreditTransactionNotAccepted =>
                    "consumer_original_credit_transaction_not_accepted",
                Category.ConsumerQualityMerchandise => "consumer_quality_merchandise",
                Category.ConsumerQualityServices => "consumer_quality_services",
                Category.ConsumerServicesMisrepresentation => "consumer_services_misrepresentation",
                Category.ConsumerServicesNotAsDescribed => "consumer_services_not_as_described",
                Category.ConsumerServicesNotReceived => "consumer_services_not_received",
                Category.Fraud => "fraud",
                Category.ProcessingError => "processing_error",
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
[JsonConverter(typeof(JsonModelConverter<Authorization, AuthorizationFromRaw>))]
public sealed record class Authorization : JsonModel
{
    /// <summary>
    /// Account status.
    /// </summary>
    public required ApiEnum<string, AccountStatus> AccountStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountStatus>>("account_status");
        }
        init { this._rawData.Set("account_status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccountStatus.Validate();
    }

    public Authorization() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Authorization(Authorization authorization)
        : base(authorization) { }
#pragma warning restore CS8618

    public Authorization(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Authorization(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AuthorizationFromRaw.FromRawUnchecked"/>
    public static Authorization FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Authorization(ApiEnum<string, AccountStatus> accountStatus)
        : this()
    {
        this.AccountStatus = accountStatus;
    }
}

class AuthorizationFromRaw : IFromRawJson<Authorization>
{
    /// <inheritdoc/>
    public Authorization FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Authorization.FromRawUnchecked(rawData);
}

/// <summary>
/// Account status.
/// </summary>
[JsonConverter(typeof(AccountStatusConverter))]
public enum AccountStatus
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

sealed class AccountStatusConverter : JsonConverter<AccountStatus>
{
    public override AccountStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_closed" => AccountStatus.AccountClosed,
            "credit_problem" => AccountStatus.CreditProblem,
            "fraud" => AccountStatus.Fraud,
            _ => (AccountStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountStatus.AccountClosed => "account_closed",
                AccountStatus.CreditProblem => "credit_problem",
                AccountStatus.Fraud => "fraud",
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
    typeof(JsonModelConverter<ConsumerCanceledMerchandise, ConsumerCanceledMerchandiseFromRaw>)
)]
public sealed record class ConsumerCanceledMerchandise : JsonModel
{
    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<string, MerchantResolutionAttempted> MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MerchantResolutionAttempted>>(
                "merchant_resolution_attempted"
            );
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
    public required ApiEnum<string, ReturnOutcome> ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ReturnOutcome>>("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Cardholder cancellation.
    /// </summary>
    public CardholderCancellation? CardholderCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardholderCancellation>(
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
    public NotReturned? NotReturned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NotReturned>("not_returned");
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
    public ReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReturnAttempted>("return_attempted");
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
    public Returned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Returned>("returned");
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

    public ConsumerCanceledMerchandise() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerCanceledMerchandise(ConsumerCanceledMerchandise consumerCanceledMerchandise)
        : base(consumerCanceledMerchandise) { }
#pragma warning restore CS8618

    public ConsumerCanceledMerchandise(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerCanceledMerchandise(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerCanceledMerchandiseFromRaw.FromRawUnchecked"/>
    public static ConsumerCanceledMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerCanceledMerchandiseFromRaw : IFromRawJson<ConsumerCanceledMerchandise>
{
    /// <inheritdoc/>
    public ConsumerCanceledMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerCanceledMerchandise.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(typeof(MerchantResolutionAttemptedConverter))]
public enum MerchantResolutionAttempted
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

sealed class MerchantResolutionAttemptedConverter : JsonConverter<MerchantResolutionAttempted>
{
    public override MerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" => MerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" => MerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (MerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MerchantResolutionAttempted.Attempted => "attempted",
                MerchantResolutionAttempted.ProhibitedByLocalLaw => "prohibited_by_local_law",
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
[JsonConverter(typeof(ReturnOutcomeConverter))]
public enum ReturnOutcome
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

sealed class ReturnOutcomeConverter : JsonConverter<ReturnOutcome>
{
    public override ReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_returned" => ReturnOutcome.NotReturned,
            "returned" => ReturnOutcome.Returned,
            "return_attempted" => ReturnOutcome.ReturnAttempted,
            _ => (ReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReturnOutcome.NotReturned => "not_returned",
                ReturnOutcome.Returned => "returned",
                ReturnOutcome.ReturnAttempted => "return_attempted",
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
[JsonConverter(typeof(JsonModelConverter<CardholderCancellation, CardholderCancellationFromRaw>))]
public sealed record class CardholderCancellation : JsonModel
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
    public required ApiEnum<string, CanceledPriorToShipDate> CanceledPriorToShipDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CanceledPriorToShipDate>>(
                "canceled_prior_to_ship_date"
            );
        }
        init { this._rawData.Set("canceled_prior_to_ship_date", value); }
    }

    /// <summary>
    /// Cancellation policy provided.
    /// </summary>
    public required ApiEnum<string, CancellationPolicyProvided> CancellationPolicyProvided
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CancellationPolicyProvided>>(
                "cancellation_policy_provided"
            );
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

    public CardholderCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardholderCancellation(CardholderCancellation cardholderCancellation)
        : base(cardholderCancellation) { }
#pragma warning restore CS8618

    public CardholderCancellation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardholderCancellation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardholderCancellationFromRaw.FromRawUnchecked"/>
    public static CardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardholderCancellationFromRaw : IFromRawJson<CardholderCancellation>
{
    /// <inheritdoc/>
    public CardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardholderCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// Canceled prior to ship date.
/// </summary>
[JsonConverter(typeof(CanceledPriorToShipDateConverter))]
public enum CanceledPriorToShipDate
{
    /// <summary>
    /// Canceled prior to ship date.
    /// </summary>
    CanceledPriorToShipDate1,

    /// <summary>
    /// Not canceled prior to ship date.
    /// </summary>
    NotCanceledPriorToShipDate,
}

sealed class CanceledPriorToShipDateConverter : JsonConverter<CanceledPriorToShipDate>
{
    public override CanceledPriorToShipDate Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "canceled_prior_to_ship_date" => CanceledPriorToShipDate.CanceledPriorToShipDate1,
            "not_canceled_prior_to_ship_date" => CanceledPriorToShipDate.NotCanceledPriorToShipDate,
            _ => (CanceledPriorToShipDate)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CanceledPriorToShipDate value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CanceledPriorToShipDate.CanceledPriorToShipDate1 => "canceled_prior_to_ship_date",
                CanceledPriorToShipDate.NotCanceledPriorToShipDate =>
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
[JsonConverter(typeof(CancellationPolicyProvidedConverter))]
public enum CancellationPolicyProvided
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

sealed class CancellationPolicyProvidedConverter : JsonConverter<CancellationPolicyProvided>
{
    public override CancellationPolicyProvided Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_provided" => CancellationPolicyProvided.NotProvided,
            "provided" => CancellationPolicyProvided.Provided,
            _ => (CancellationPolicyProvided)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CancellationPolicyProvided value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CancellationPolicyProvided.NotProvided => "not_provided",
                CancellationPolicyProvided.Provided => "provided",
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
[JsonConverter(typeof(JsonModelConverter<NotReturned, NotReturnedFromRaw>))]
public sealed record class NotReturned : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public NotReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotReturned(NotReturned notReturned)
        : base(notReturned) { }
#pragma warning restore CS8618

    public NotReturned(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotReturned(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotReturnedFromRaw.FromRawUnchecked"/>
    public static NotReturned FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotReturnedFromRaw : IFromRawJson<NotReturned>
{
    /// <inheritdoc/>
    public NotReturned FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NotReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReturnAttempted, ReturnAttemptedFromRaw>))]
public sealed record class ReturnAttempted : JsonModel
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
    public required ApiEnum<string, AttemptReason> AttemptReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AttemptReason>>("attempt_reason");
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

    public ReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReturnAttempted(ReturnAttempted returnAttempted)
        : base(returnAttempted) { }
#pragma warning restore CS8618

    public ReturnAttempted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReturnAttempted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static ReturnAttempted FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReturnAttemptedFromRaw : IFromRawJson<ReturnAttempted>
{
    /// <inheritdoc/>
    public ReturnAttempted FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReturnAttempted.FromRawUnchecked(rawData);
}

/// <summary>
/// Attempt reason.
/// </summary>
[JsonConverter(typeof(AttemptReasonConverter))]
public enum AttemptReason
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

sealed class AttemptReasonConverter : JsonConverter<AttemptReason>
{
    public override AttemptReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merchant_not_responding" => AttemptReason.MerchantNotResponding,
            "no_return_authorization_provided" => AttemptReason.NoReturnAuthorizationProvided,
            "no_return_instructions" => AttemptReason.NoReturnInstructions,
            "requested_not_to_return" => AttemptReason.RequestedNotToReturn,
            "return_not_accepted" => AttemptReason.ReturnNotAccepted,
            _ => (AttemptReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AttemptReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AttemptReason.MerchantNotResponding => "merchant_not_responding",
                AttemptReason.NoReturnAuthorizationProvided => "no_return_authorization_provided",
                AttemptReason.NoReturnInstructions => "no_return_instructions",
                AttemptReason.RequestedNotToReturn => "requested_not_to_return",
                AttemptReason.ReturnNotAccepted => "return_not_accepted",
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
[JsonConverter(typeof(JsonModelConverter<Returned, ReturnedFromRaw>))]
public sealed record class Returned : JsonModel
{
    /// <summary>
    /// Return method.
    /// </summary>
    public required ApiEnum<string, ReturnMethod> ReturnMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ReturnMethod>>("return_method");
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

    public Returned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Returned(Returned returned)
        : base(returned) { }
#pragma warning restore CS8618

    public Returned(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Returned(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReturnedFromRaw.FromRawUnchecked"/>
    public static Returned FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReturnedFromRaw : IFromRawJson<Returned>
{
    /// <inheritdoc/>
    public Returned FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Returned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return method.
/// </summary>
[JsonConverter(typeof(ReturnMethodConverter))]
public enum ReturnMethod
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

sealed class ReturnMethodConverter : JsonConverter<ReturnMethod>
{
    public override ReturnMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dhl" => ReturnMethod.Dhl,
            "face_to_face" => ReturnMethod.FaceToFace,
            "fedex" => ReturnMethod.Fedex,
            "other" => ReturnMethod.Other,
            "postal_service" => ReturnMethod.PostalService,
            "ups" => ReturnMethod.Ups,
            _ => (ReturnMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReturnMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReturnMethod.Dhl => "dhl",
                ReturnMethod.FaceToFace => "face_to_face",
                ReturnMethod.Fedex => "fedex",
                ReturnMethod.Other => "other",
                ReturnMethod.PostalService => "postal_service",
                ReturnMethod.Ups => "ups",
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
        ConsumerCanceledRecurringTransaction,
        ConsumerCanceledRecurringTransactionFromRaw
    >)
)]
public sealed record class ConsumerCanceledRecurringTransaction : JsonModel
{
    /// <summary>
    /// Cancellation target.
    /// </summary>
    public required ApiEnum<string, CancellationTarget> CancellationTarget
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CancellationTarget>>(
                "cancellation_target"
            );
        }
        init { this._rawData.Set("cancellation_target", value); }
    }

    /// <summary>
    /// Merchant contact methods.
    /// </summary>
    public required MerchantContactMethods MerchantContactMethods
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MerchantContactMethods>(
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

    public ConsumerCanceledRecurringTransaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerCanceledRecurringTransaction(
        ConsumerCanceledRecurringTransaction consumerCanceledRecurringTransaction
    )
        : base(consumerCanceledRecurringTransaction) { }
#pragma warning restore CS8618

    public ConsumerCanceledRecurringTransaction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerCanceledRecurringTransaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerCanceledRecurringTransactionFromRaw.FromRawUnchecked"/>
    public static ConsumerCanceledRecurringTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerCanceledRecurringTransactionFromRaw
    : IFromRawJson<ConsumerCanceledRecurringTransaction>
{
    /// <inheritdoc/>
    public ConsumerCanceledRecurringTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerCanceledRecurringTransaction.FromRawUnchecked(rawData);
}

/// <summary>
/// Cancellation target.
/// </summary>
[JsonConverter(typeof(CancellationTargetConverter))]
public enum CancellationTarget
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

sealed class CancellationTargetConverter : JsonConverter<CancellationTarget>
{
    public override CancellationTarget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account" => CancellationTarget.Account,
            "transaction" => CancellationTarget.Transaction,
            _ => (CancellationTarget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CancellationTarget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CancellationTarget.Account => "account",
                CancellationTarget.Transaction => "transaction",
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
[JsonConverter(typeof(JsonModelConverter<MerchantContactMethods, MerchantContactMethodsFromRaw>))]
public sealed record class MerchantContactMethods : JsonModel
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

    public MerchantContactMethods() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MerchantContactMethods(MerchantContactMethods merchantContactMethods)
        : base(merchantContactMethods) { }
#pragma warning restore CS8618

    public MerchantContactMethods(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MerchantContactMethods(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MerchantContactMethodsFromRaw.FromRawUnchecked"/>
    public static MerchantContactMethods FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MerchantContactMethodsFromRaw : IFromRawJson<MerchantContactMethods>
{
    /// <inheritdoc/>
    public MerchantContactMethods FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MerchantContactMethods.FromRawUnchecked(rawData);
}

/// <summary>
/// Canceled services. Required if and only if `category` is `consumer_canceled_services`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ConsumerCanceledServices, ConsumerCanceledServicesFromRaw>)
)]
public sealed record class ConsumerCanceledServices : JsonModel
{
    /// <summary>
    /// Cardholder cancellation.
    /// </summary>
    public required ConsumerCanceledServicesCardholderCancellation CardholderCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ConsumerCanceledServicesCardholderCancellation>(
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
        ConsumerCanceledServicesMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerCanceledServicesMerchantResolutionAttempted>
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
    public required ApiEnum<string, ServiceType> ServiceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ServiceType>>("service_type");
        }
        init { this._rawData.Set("service_type", value); }
    }

    /// <summary>
    /// Guaranteed reservation explanation. Required if and only if `service_type`
    /// is `guaranteed_reservation`.
    /// </summary>
    public GuaranteedReservation? GuaranteedReservation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GuaranteedReservation>("guaranteed_reservation");
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
    public Other? Other
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Other>("other");
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
    public Timeshare? Timeshare
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Timeshare>("timeshare");
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

    public ConsumerCanceledServices() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerCanceledServices(ConsumerCanceledServices consumerCanceledServices)
        : base(consumerCanceledServices) { }
#pragma warning restore CS8618

    public ConsumerCanceledServices(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerCanceledServices(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerCanceledServicesFromRaw.FromRawUnchecked"/>
    public static ConsumerCanceledServices FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerCanceledServicesFromRaw : IFromRawJson<ConsumerCanceledServices>
{
    /// <inheritdoc/>
    public ConsumerCanceledServices FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerCanceledServices.FromRawUnchecked(rawData);
}

/// <summary>
/// Cardholder cancellation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConsumerCanceledServicesCardholderCancellation,
        ConsumerCanceledServicesCardholderCancellationFromRaw
    >)
)]
public sealed record class ConsumerCanceledServicesCardholderCancellation : JsonModel
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
        ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
    > CancellationPolicyProvided
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
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

    public ConsumerCanceledServicesCardholderCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerCanceledServicesCardholderCancellation(
        ConsumerCanceledServicesCardholderCancellation consumerCanceledServicesCardholderCancellation
    )
        : base(consumerCanceledServicesCardholderCancellation) { }
#pragma warning restore CS8618

    public ConsumerCanceledServicesCardholderCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerCanceledServicesCardholderCancellation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerCanceledServicesCardholderCancellationFromRaw.FromRawUnchecked"/>
    public static ConsumerCanceledServicesCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerCanceledServicesCardholderCancellationFromRaw
    : IFromRawJson<ConsumerCanceledServicesCardholderCancellation>
{
    /// <inheritdoc/>
    public ConsumerCanceledServicesCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerCanceledServicesCardholderCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// Cancellation policy provided.
/// </summary>
[JsonConverter(
    typeof(ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvidedConverter)
)]
public enum ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
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

sealed class ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvidedConverter
    : JsonConverter<ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided>
{
    public override ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_provided" =>
                ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
            "provided" =>
                ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.Provided,
            _ => (ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided =>
                    "not_provided",
                ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.Provided =>
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
[JsonConverter(typeof(ConsumerCanceledServicesMerchantResolutionAttemptedConverter))]
public enum ConsumerCanceledServicesMerchantResolutionAttempted
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

sealed class ConsumerCanceledServicesMerchantResolutionAttemptedConverter
    : JsonConverter<ConsumerCanceledServicesMerchantResolutionAttempted>
{
    public override ConsumerCanceledServicesMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" => ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ConsumerCanceledServicesMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ConsumerCanceledServicesMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerCanceledServicesMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerCanceledServicesMerchantResolutionAttempted.Attempted => "attempted",
                ConsumerCanceledServicesMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
[JsonConverter(typeof(ServiceTypeConverter))]
public enum ServiceType
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

sealed class ServiceTypeConverter : JsonConverter<ServiceType>
{
    public override ServiceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "guaranteed_reservation" => ServiceType.GuaranteedReservation,
            "other" => ServiceType.Other,
            "timeshare" => ServiceType.Timeshare,
            _ => (ServiceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ServiceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ServiceType.GuaranteedReservation => "guaranteed_reservation",
                ServiceType.Other => "other",
                ServiceType.Timeshare => "timeshare",
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
[JsonConverter(typeof(JsonModelConverter<GuaranteedReservation, GuaranteedReservationFromRaw>))]
public sealed record class GuaranteedReservation : JsonModel
{
    /// <summary>
    /// Explanation.
    /// </summary>
    public required ApiEnum<string, Explanation> Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Explanation>>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Explanation.Validate();
    }

    public GuaranteedReservation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GuaranteedReservation(GuaranteedReservation guaranteedReservation)
        : base(guaranteedReservation) { }
#pragma warning restore CS8618

    public GuaranteedReservation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GuaranteedReservation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GuaranteedReservationFromRaw.FromRawUnchecked"/>
    public static GuaranteedReservation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GuaranteedReservation(ApiEnum<string, Explanation> explanation)
        : this()
    {
        this.Explanation = explanation;
    }
}

class GuaranteedReservationFromRaw : IFromRawJson<GuaranteedReservation>
{
    /// <inheritdoc/>
    public GuaranteedReservation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GuaranteedReservation.FromRawUnchecked(rawData);
}

/// <summary>
/// Explanation.
/// </summary>
[JsonConverter(typeof(ExplanationConverter))]
public enum Explanation
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

sealed class ExplanationConverter : JsonConverter<Explanation>
{
    public override Explanation Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cardholder_canceled_prior_to_service" => Explanation.CardholderCanceledPriorToService,
            "cardholder_cancellation_attempt_within_24_hours_of_confirmation" =>
                Explanation.CardholderCancellationAttemptWithin24HoursOfConfirmation,
            "merchant_billed_no_show" => Explanation.MerchantBilledNoShow,
            _ => (Explanation)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Explanation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Explanation.CardholderCanceledPriorToService =>
                    "cardholder_canceled_prior_to_service",
                Explanation.CardholderCancellationAttemptWithin24HoursOfConfirmation =>
                    "cardholder_cancellation_attempt_within_24_hours_of_confirmation",
                Explanation.MerchantBilledNoShow => "merchant_billed_no_show",
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
/// Timeshare explanation. Required if and only if `service_type` is `timeshare`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Timeshare, TimeshareFromRaw>))]
public sealed record class Timeshare : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public Timeshare() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Timeshare(Timeshare timeshare)
        : base(timeshare) { }
#pragma warning restore CS8618

    public Timeshare(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Timeshare(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimeshareFromRaw.FromRawUnchecked"/>
    public static Timeshare FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimeshareFromRaw : IFromRawJson<Timeshare>
{
    /// <inheritdoc/>
    public Timeshare FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Timeshare.FromRawUnchecked(rawData);
}

/// <summary>
/// Counterfeit merchandise. Required if and only if `category` is `consumer_counterfeit_merchandise`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConsumerCounterfeitMerchandise,
        ConsumerCounterfeitMerchandiseFromRaw
    >)
)]
public sealed record class ConsumerCounterfeitMerchandise : JsonModel
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

    public ConsumerCounterfeitMerchandise() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerCounterfeitMerchandise(
        ConsumerCounterfeitMerchandise consumerCounterfeitMerchandise
    )
        : base(consumerCounterfeitMerchandise) { }
#pragma warning restore CS8618

    public ConsumerCounterfeitMerchandise(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerCounterfeitMerchandise(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerCounterfeitMerchandiseFromRaw.FromRawUnchecked"/>
    public static ConsumerCounterfeitMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerCounterfeitMerchandiseFromRaw : IFromRawJson<ConsumerCounterfeitMerchandise>
{
    /// <inheritdoc/>
    public ConsumerCounterfeitMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerCounterfeitMerchandise.FromRawUnchecked(rawData);
}

/// <summary>
/// Credit not processed. Required if and only if `category` is `consumer_credit_not_processed`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ConsumerCreditNotProcessed, ConsumerCreditNotProcessedFromRaw>)
)]
public sealed record class ConsumerCreditNotProcessed : JsonModel
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

    public ConsumerCreditNotProcessed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerCreditNotProcessed(ConsumerCreditNotProcessed consumerCreditNotProcessed)
        : base(consumerCreditNotProcessed) { }
#pragma warning restore CS8618

    public ConsumerCreditNotProcessed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerCreditNotProcessed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerCreditNotProcessedFromRaw.FromRawUnchecked"/>
    public static ConsumerCreditNotProcessed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerCreditNotProcessedFromRaw : IFromRawJson<ConsumerCreditNotProcessed>
{
    /// <inheritdoc/>
    public ConsumerCreditNotProcessed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerCreditNotProcessed.FromRawUnchecked(rawData);
}

/// <summary>
/// Damaged or defective merchandise. Required if and only if `category` is `consumer_damaged_or_defective_merchandise`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConsumerDamagedOrDefectiveMerchandise,
        ConsumerDamagedOrDefectiveMerchandiseFromRaw
    >)
)]
public sealed record class ConsumerDamagedOrDefectiveMerchandise : JsonModel
{
    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted>
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
        ConsumerDamagedOrDefectiveMerchandiseReturnOutcome
    > ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnOutcome>
            >("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Not returned. Required if and only if `return_outcome` is `not_returned`.
    /// </summary>
    public ConsumerDamagedOrDefectiveMerchandiseNotReturned? NotReturned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerDamagedOrDefectiveMerchandiseNotReturned>(
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
    public ConsumerDamagedOrDefectiveMerchandiseReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerDamagedOrDefectiveMerchandiseReturnAttempted>(
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
    public ConsumerDamagedOrDefectiveMerchandiseReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerDamagedOrDefectiveMerchandiseReturned>(
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

    public ConsumerDamagedOrDefectiveMerchandise() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerDamagedOrDefectiveMerchandise(
        ConsumerDamagedOrDefectiveMerchandise consumerDamagedOrDefectiveMerchandise
    )
        : base(consumerDamagedOrDefectiveMerchandise) { }
#pragma warning restore CS8618

    public ConsumerDamagedOrDefectiveMerchandise(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerDamagedOrDefectiveMerchandise(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerDamagedOrDefectiveMerchandiseFromRaw.FromRawUnchecked"/>
    public static ConsumerDamagedOrDefectiveMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerDamagedOrDefectiveMerchandiseFromRaw
    : IFromRawJson<ConsumerDamagedOrDefectiveMerchandise>
{
    /// <inheritdoc/>
    public ConsumerDamagedOrDefectiveMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerDamagedOrDefectiveMerchandise.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(typeof(ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttemptedConverter))]
public enum ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
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

sealed class ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttemptedConverter
    : JsonConverter<ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted>
{
    public override ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted =>
                    "attempted",
                ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
[JsonConverter(typeof(ConsumerDamagedOrDefectiveMerchandiseReturnOutcomeConverter))]
public enum ConsumerDamagedOrDefectiveMerchandiseReturnOutcome
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

sealed class ConsumerDamagedOrDefectiveMerchandiseReturnOutcomeConverter
    : JsonConverter<ConsumerDamagedOrDefectiveMerchandiseReturnOutcome>
{
    public override ConsumerDamagedOrDefectiveMerchandiseReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_returned" => ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
            "returned" => ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.Returned,
            "return_attempted" =>
                ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.ReturnAttempted,
            _ => (ConsumerDamagedOrDefectiveMerchandiseReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerDamagedOrDefectiveMerchandiseReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned => "not_returned",
                ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.Returned => "returned",
                ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.ReturnAttempted =>
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
        ConsumerDamagedOrDefectiveMerchandiseNotReturned,
        ConsumerDamagedOrDefectiveMerchandiseNotReturnedFromRaw
    >)
)]
public sealed record class ConsumerDamagedOrDefectiveMerchandiseNotReturned : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ConsumerDamagedOrDefectiveMerchandiseNotReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerDamagedOrDefectiveMerchandiseNotReturned(
        ConsumerDamagedOrDefectiveMerchandiseNotReturned consumerDamagedOrDefectiveMerchandiseNotReturned
    )
        : base(consumerDamagedOrDefectiveMerchandiseNotReturned) { }
#pragma warning restore CS8618

    public ConsumerDamagedOrDefectiveMerchandiseNotReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerDamagedOrDefectiveMerchandiseNotReturned(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerDamagedOrDefectiveMerchandiseNotReturnedFromRaw.FromRawUnchecked"/>
    public static ConsumerDamagedOrDefectiveMerchandiseNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerDamagedOrDefectiveMerchandiseNotReturnedFromRaw
    : IFromRawJson<ConsumerDamagedOrDefectiveMerchandiseNotReturned>
{
    /// <inheritdoc/>
    public ConsumerDamagedOrDefectiveMerchandiseNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerDamagedOrDefectiveMerchandiseNotReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConsumerDamagedOrDefectiveMerchandiseReturnAttempted,
        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedFromRaw
    >)
)]
public sealed record class ConsumerDamagedOrDefectiveMerchandiseReturnAttempted : JsonModel
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
        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
    > AttemptReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason>
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

    public ConsumerDamagedOrDefectiveMerchandiseReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerDamagedOrDefectiveMerchandiseReturnAttempted(
        ConsumerDamagedOrDefectiveMerchandiseReturnAttempted consumerDamagedOrDefectiveMerchandiseReturnAttempted
    )
        : base(consumerDamagedOrDefectiveMerchandiseReturnAttempted) { }
#pragma warning restore CS8618

    public ConsumerDamagedOrDefectiveMerchandiseReturnAttempted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerDamagedOrDefectiveMerchandiseReturnAttempted(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static ConsumerDamagedOrDefectiveMerchandiseReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedFromRaw
    : IFromRawJson<ConsumerDamagedOrDefectiveMerchandiseReturnAttempted>
{
    /// <inheritdoc/>
    public ConsumerDamagedOrDefectiveMerchandiseReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerDamagedOrDefectiveMerchandiseReturnAttempted.FromRawUnchecked(rawData);
}

/// <summary>
/// Attempt reason.
/// </summary>
[JsonConverter(typeof(ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReasonConverter))]
public enum ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
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

sealed class ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReasonConverter
    : JsonConverter<ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason>
{
    public override ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merchant_not_responding" =>
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            "no_return_authorization_provided" =>
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided,
            "no_return_instructions" =>
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions,
            "requested_not_to_return" =>
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn,
            "return_not_accepted" =>
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted,
            _ => (ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding =>
                    "merchant_not_responding",
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided =>
                    "no_return_authorization_provided",
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions =>
                    "no_return_instructions",
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn =>
                    "requested_not_to_return",
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted =>
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
        ConsumerDamagedOrDefectiveMerchandiseReturned,
        ConsumerDamagedOrDefectiveMerchandiseReturnedFromRaw
    >)
)]
public sealed record class ConsumerDamagedOrDefectiveMerchandiseReturned : JsonModel
{
    /// <summary>
    /// Return method.
    /// </summary>
    public required ApiEnum<
        string,
        ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod
    > ReturnMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod>
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

    public ConsumerDamagedOrDefectiveMerchandiseReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerDamagedOrDefectiveMerchandiseReturned(
        ConsumerDamagedOrDefectiveMerchandiseReturned consumerDamagedOrDefectiveMerchandiseReturned
    )
        : base(consumerDamagedOrDefectiveMerchandiseReturned) { }
#pragma warning restore CS8618

    public ConsumerDamagedOrDefectiveMerchandiseReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerDamagedOrDefectiveMerchandiseReturned(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerDamagedOrDefectiveMerchandiseReturnedFromRaw.FromRawUnchecked"/>
    public static ConsumerDamagedOrDefectiveMerchandiseReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerDamagedOrDefectiveMerchandiseReturnedFromRaw
    : IFromRawJson<ConsumerDamagedOrDefectiveMerchandiseReturned>
{
    /// <inheritdoc/>
    public ConsumerDamagedOrDefectiveMerchandiseReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerDamagedOrDefectiveMerchandiseReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return method.
/// </summary>
[JsonConverter(typeof(ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethodConverter))]
public enum ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod
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

sealed class ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethodConverter
    : JsonConverter<ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod>
{
    public override ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dhl" => ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            "face_to_face" => ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.FaceToFace,
            "fedex" => ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Fedex,
            "other" => ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Other,
            "postal_service" =>
                ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.PostalService,
            "ups" => ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Ups,
            _ => (ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl => "dhl",
                ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.FaceToFace =>
                    "face_to_face",
                ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Fedex => "fedex",
                ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Other => "other",
                ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.PostalService =>
                    "postal_service",
                ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Ups => "ups",
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
        ConsumerMerchandiseMisrepresentation,
        ConsumerMerchandiseMisrepresentationFromRaw
    >)
)]
public sealed record class ConsumerMerchandiseMisrepresentation : JsonModel
{
    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted>
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
    public required ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnOutcome> ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnOutcome>
            >("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Not returned. Required if and only if `return_outcome` is `not_returned`.
    /// </summary>
    public ConsumerMerchandiseMisrepresentationNotReturned? NotReturned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerMerchandiseMisrepresentationNotReturned>(
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
    public ConsumerMerchandiseMisrepresentationReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerMerchandiseMisrepresentationReturnAttempted>(
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
    public ConsumerMerchandiseMisrepresentationReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerMerchandiseMisrepresentationReturned>(
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

    public ConsumerMerchandiseMisrepresentation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerMerchandiseMisrepresentation(
        ConsumerMerchandiseMisrepresentation consumerMerchandiseMisrepresentation
    )
        : base(consumerMerchandiseMisrepresentation) { }
#pragma warning restore CS8618

    public ConsumerMerchandiseMisrepresentation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerMerchandiseMisrepresentation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerMerchandiseMisrepresentationFromRaw.FromRawUnchecked"/>
    public static ConsumerMerchandiseMisrepresentation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerMerchandiseMisrepresentationFromRaw
    : IFromRawJson<ConsumerMerchandiseMisrepresentation>
{
    /// <inheritdoc/>
    public ConsumerMerchandiseMisrepresentation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerMerchandiseMisrepresentation.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(typeof(ConsumerMerchandiseMisrepresentationMerchantResolutionAttemptedConverter))]
public enum ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
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

sealed class ConsumerMerchandiseMisrepresentationMerchantResolutionAttemptedConverter
    : JsonConverter<ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted>
{
    public override ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" =>
                ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted =>
                    "attempted",
                ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
[JsonConverter(typeof(ConsumerMerchandiseMisrepresentationReturnOutcomeConverter))]
public enum ConsumerMerchandiseMisrepresentationReturnOutcome
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

sealed class ConsumerMerchandiseMisrepresentationReturnOutcomeConverter
    : JsonConverter<ConsumerMerchandiseMisrepresentationReturnOutcome>
{
    public override ConsumerMerchandiseMisrepresentationReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_returned" => ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
            "returned" => ConsumerMerchandiseMisrepresentationReturnOutcome.Returned,
            "return_attempted" => ConsumerMerchandiseMisrepresentationReturnOutcome.ReturnAttempted,
            _ => (ConsumerMerchandiseMisrepresentationReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerMerchandiseMisrepresentationReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned => "not_returned",
                ConsumerMerchandiseMisrepresentationReturnOutcome.Returned => "returned",
                ConsumerMerchandiseMisrepresentationReturnOutcome.ReturnAttempted =>
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
        ConsumerMerchandiseMisrepresentationNotReturned,
        ConsumerMerchandiseMisrepresentationNotReturnedFromRaw
    >)
)]
public sealed record class ConsumerMerchandiseMisrepresentationNotReturned : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ConsumerMerchandiseMisrepresentationNotReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerMerchandiseMisrepresentationNotReturned(
        ConsumerMerchandiseMisrepresentationNotReturned consumerMerchandiseMisrepresentationNotReturned
    )
        : base(consumerMerchandiseMisrepresentationNotReturned) { }
#pragma warning restore CS8618

    public ConsumerMerchandiseMisrepresentationNotReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerMerchandiseMisrepresentationNotReturned(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerMerchandiseMisrepresentationNotReturnedFromRaw.FromRawUnchecked"/>
    public static ConsumerMerchandiseMisrepresentationNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerMerchandiseMisrepresentationNotReturnedFromRaw
    : IFromRawJson<ConsumerMerchandiseMisrepresentationNotReturned>
{
    /// <inheritdoc/>
    public ConsumerMerchandiseMisrepresentationNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerMerchandiseMisrepresentationNotReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConsumerMerchandiseMisrepresentationReturnAttempted,
        ConsumerMerchandiseMisrepresentationReturnAttemptedFromRaw
    >)
)]
public sealed record class ConsumerMerchandiseMisrepresentationReturnAttempted : JsonModel
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
        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
    > AttemptReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason>
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

    public ConsumerMerchandiseMisrepresentationReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerMerchandiseMisrepresentationReturnAttempted(
        ConsumerMerchandiseMisrepresentationReturnAttempted consumerMerchandiseMisrepresentationReturnAttempted
    )
        : base(consumerMerchandiseMisrepresentationReturnAttempted) { }
#pragma warning restore CS8618

    public ConsumerMerchandiseMisrepresentationReturnAttempted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerMerchandiseMisrepresentationReturnAttempted(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerMerchandiseMisrepresentationReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static ConsumerMerchandiseMisrepresentationReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerMerchandiseMisrepresentationReturnAttemptedFromRaw
    : IFromRawJson<ConsumerMerchandiseMisrepresentationReturnAttempted>
{
    /// <inheritdoc/>
    public ConsumerMerchandiseMisrepresentationReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerMerchandiseMisrepresentationReturnAttempted.FromRawUnchecked(rawData);
}

/// <summary>
/// Attempt reason.
/// </summary>
[JsonConverter(typeof(ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReasonConverter))]
public enum ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
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

sealed class ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReasonConverter
    : JsonConverter<ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason>
{
    public override ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merchant_not_responding" =>
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
            "no_return_authorization_provided" =>
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnAuthorizationProvided,
            "no_return_instructions" =>
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnInstructions,
            "requested_not_to_return" =>
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.RequestedNotToReturn,
            "return_not_accepted" =>
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.ReturnNotAccepted,
            _ => (ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding =>
                    "merchant_not_responding",
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnAuthorizationProvided =>
                    "no_return_authorization_provided",
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnInstructions =>
                    "no_return_instructions",
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.RequestedNotToReturn =>
                    "requested_not_to_return",
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.ReturnNotAccepted =>
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
        ConsumerMerchandiseMisrepresentationReturned,
        ConsumerMerchandiseMisrepresentationReturnedFromRaw
    >)
)]
public sealed record class ConsumerMerchandiseMisrepresentationReturned : JsonModel
{
    /// <summary>
    /// Return method.
    /// </summary>
    public required ApiEnum<
        string,
        ConsumerMerchandiseMisrepresentationReturnedReturnMethod
    > ReturnMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnedReturnMethod>
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

    public ConsumerMerchandiseMisrepresentationReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerMerchandiseMisrepresentationReturned(
        ConsumerMerchandiseMisrepresentationReturned consumerMerchandiseMisrepresentationReturned
    )
        : base(consumerMerchandiseMisrepresentationReturned) { }
#pragma warning restore CS8618

    public ConsumerMerchandiseMisrepresentationReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerMerchandiseMisrepresentationReturned(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerMerchandiseMisrepresentationReturnedFromRaw.FromRawUnchecked"/>
    public static ConsumerMerchandiseMisrepresentationReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerMerchandiseMisrepresentationReturnedFromRaw
    : IFromRawJson<ConsumerMerchandiseMisrepresentationReturned>
{
    /// <inheritdoc/>
    public ConsumerMerchandiseMisrepresentationReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerMerchandiseMisrepresentationReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return method.
/// </summary>
[JsonConverter(typeof(ConsumerMerchandiseMisrepresentationReturnedReturnMethodConverter))]
public enum ConsumerMerchandiseMisrepresentationReturnedReturnMethod
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

sealed class ConsumerMerchandiseMisrepresentationReturnedReturnMethodConverter
    : JsonConverter<ConsumerMerchandiseMisrepresentationReturnedReturnMethod>
{
    public override ConsumerMerchandiseMisrepresentationReturnedReturnMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dhl" => ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            "face_to_face" => ConsumerMerchandiseMisrepresentationReturnedReturnMethod.FaceToFace,
            "fedex" => ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Fedex,
            "other" => ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Other,
            "postal_service" =>
                ConsumerMerchandiseMisrepresentationReturnedReturnMethod.PostalService,
            "ups" => ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Ups,
            _ => (ConsumerMerchandiseMisrepresentationReturnedReturnMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerMerchandiseMisrepresentationReturnedReturnMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl => "dhl",
                ConsumerMerchandiseMisrepresentationReturnedReturnMethod.FaceToFace =>
                    "face_to_face",
                ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Fedex => "fedex",
                ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Other => "other",
                ConsumerMerchandiseMisrepresentationReturnedReturnMethod.PostalService =>
                    "postal_service",
                ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Ups => "ups",
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
        ConsumerMerchandiseNotAsDescribed,
        ConsumerMerchandiseNotAsDescribedFromRaw
    >)
)]
public sealed record class ConsumerMerchandiseNotAsDescribed : JsonModel
{
    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted>
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
    public required ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnOutcome> ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnOutcome>
            >("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
    /// </summary>
    public ConsumerMerchandiseNotAsDescribedReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerMerchandiseNotAsDescribedReturnAttempted>(
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
    public ConsumerMerchandiseNotAsDescribedReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerMerchandiseNotAsDescribedReturned>(
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

    public ConsumerMerchandiseNotAsDescribed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerMerchandiseNotAsDescribed(
        ConsumerMerchandiseNotAsDescribed consumerMerchandiseNotAsDescribed
    )
        : base(consumerMerchandiseNotAsDescribed) { }
#pragma warning restore CS8618

    public ConsumerMerchandiseNotAsDescribed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerMerchandiseNotAsDescribed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerMerchandiseNotAsDescribedFromRaw.FromRawUnchecked"/>
    public static ConsumerMerchandiseNotAsDescribed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerMerchandiseNotAsDescribedFromRaw : IFromRawJson<ConsumerMerchandiseNotAsDescribed>
{
    /// <inheritdoc/>
    public ConsumerMerchandiseNotAsDescribed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerMerchandiseNotAsDescribed.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(typeof(ConsumerMerchandiseNotAsDescribedMerchantResolutionAttemptedConverter))]
public enum ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
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

sealed class ConsumerMerchandiseNotAsDescribedMerchantResolutionAttemptedConverter
    : JsonConverter<ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted>
{
    public override ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" => ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted =>
                    "attempted",
                ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
[JsonConverter(typeof(ConsumerMerchandiseNotAsDescribedReturnOutcomeConverter))]
public enum ConsumerMerchandiseNotAsDescribedReturnOutcome
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

sealed class ConsumerMerchandiseNotAsDescribedReturnOutcomeConverter
    : JsonConverter<ConsumerMerchandiseNotAsDescribedReturnOutcome>
{
    public override ConsumerMerchandiseNotAsDescribedReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "returned" => ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
            "return_attempted" => ConsumerMerchandiseNotAsDescribedReturnOutcome.ReturnAttempted,
            _ => (ConsumerMerchandiseNotAsDescribedReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerMerchandiseNotAsDescribedReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned => "returned",
                ConsumerMerchandiseNotAsDescribedReturnOutcome.ReturnAttempted =>
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
        ConsumerMerchandiseNotAsDescribedReturnAttempted,
        ConsumerMerchandiseNotAsDescribedReturnAttemptedFromRaw
    >)
)]
public sealed record class ConsumerMerchandiseNotAsDescribedReturnAttempted : JsonModel
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
        ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
    > AttemptReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason>
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

    public ConsumerMerchandiseNotAsDescribedReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerMerchandiseNotAsDescribedReturnAttempted(
        ConsumerMerchandiseNotAsDescribedReturnAttempted consumerMerchandiseNotAsDescribedReturnAttempted
    )
        : base(consumerMerchandiseNotAsDescribedReturnAttempted) { }
#pragma warning restore CS8618

    public ConsumerMerchandiseNotAsDescribedReturnAttempted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerMerchandiseNotAsDescribedReturnAttempted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerMerchandiseNotAsDescribedReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static ConsumerMerchandiseNotAsDescribedReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerMerchandiseNotAsDescribedReturnAttemptedFromRaw
    : IFromRawJson<ConsumerMerchandiseNotAsDescribedReturnAttempted>
{
    /// <inheritdoc/>
    public ConsumerMerchandiseNotAsDescribedReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerMerchandiseNotAsDescribedReturnAttempted.FromRawUnchecked(rawData);
}

/// <summary>
/// Attempt reason.
/// </summary>
[JsonConverter(typeof(ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReasonConverter))]
public enum ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
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

sealed class ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReasonConverter
    : JsonConverter<ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason>
{
    public override ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merchant_not_responding" =>
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            "no_return_authorization_provided" =>
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnAuthorizationProvided,
            "no_return_instructions" =>
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnInstructions,
            "requested_not_to_return" =>
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.RequestedNotToReturn,
            "return_not_accepted" =>
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.ReturnNotAccepted,
            _ => (ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding =>
                    "merchant_not_responding",
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnAuthorizationProvided =>
                    "no_return_authorization_provided",
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnInstructions =>
                    "no_return_instructions",
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.RequestedNotToReturn =>
                    "requested_not_to_return",
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.ReturnNotAccepted =>
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
        ConsumerMerchandiseNotAsDescribedReturned,
        ConsumerMerchandiseNotAsDescribedReturnedFromRaw
    >)
)]
public sealed record class ConsumerMerchandiseNotAsDescribedReturned : JsonModel
{
    /// <summary>
    /// Return method.
    /// </summary>
    public required ApiEnum<
        string,
        ConsumerMerchandiseNotAsDescribedReturnedReturnMethod
    > ReturnMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnedReturnMethod>
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

    public ConsumerMerchandiseNotAsDescribedReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerMerchandiseNotAsDescribedReturned(
        ConsumerMerchandiseNotAsDescribedReturned consumerMerchandiseNotAsDescribedReturned
    )
        : base(consumerMerchandiseNotAsDescribedReturned) { }
#pragma warning restore CS8618

    public ConsumerMerchandiseNotAsDescribedReturned(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerMerchandiseNotAsDescribedReturned(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerMerchandiseNotAsDescribedReturnedFromRaw.FromRawUnchecked"/>
    public static ConsumerMerchandiseNotAsDescribedReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerMerchandiseNotAsDescribedReturnedFromRaw
    : IFromRawJson<ConsumerMerchandiseNotAsDescribedReturned>
{
    /// <inheritdoc/>
    public ConsumerMerchandiseNotAsDescribedReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerMerchandiseNotAsDescribedReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return method.
/// </summary>
[JsonConverter(typeof(ConsumerMerchandiseNotAsDescribedReturnedReturnMethodConverter))]
public enum ConsumerMerchandiseNotAsDescribedReturnedReturnMethod
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

sealed class ConsumerMerchandiseNotAsDescribedReturnedReturnMethodConverter
    : JsonConverter<ConsumerMerchandiseNotAsDescribedReturnedReturnMethod>
{
    public override ConsumerMerchandiseNotAsDescribedReturnedReturnMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dhl" => ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            "face_to_face" => ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.FaceToFace,
            "fedex" => ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Fedex,
            "other" => ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Other,
            "postal_service" => ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.PostalService,
            "ups" => ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Ups,
            _ => (ConsumerMerchandiseNotAsDescribedReturnedReturnMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerMerchandiseNotAsDescribedReturnedReturnMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl => "dhl",
                ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.FaceToFace => "face_to_face",
                ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Fedex => "fedex",
                ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Other => "other",
                ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.PostalService =>
                    "postal_service",
                ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Ups => "ups",
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
        ConsumerMerchandiseNotReceived,
        ConsumerMerchandiseNotReceivedFromRaw
    >)
)]
public sealed record class ConsumerMerchandiseNotReceived : JsonModel
{
    /// <summary>
    /// Cancellation outcome.
    /// </summary>
    public required ApiEnum<string, CancellationOutcome> CancellationOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CancellationOutcome>>(
                "cancellation_outcome"
            );
        }
        init { this._rawData.Set("cancellation_outcome", value); }
    }

    /// <summary>
    /// Delivery issue.
    /// </summary>
    public required ApiEnum<string, DeliveryIssue> DeliveryIssue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DeliveryIssue>>("delivery_issue");
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
        ConsumerMerchandiseNotReceivedMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerMerchandiseNotReceivedMerchantResolutionAttempted>
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
    public CardholderCancellationPriorToExpectedReceipt? CardholderCancellationPriorToExpectedReceipt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardholderCancellationPriorToExpectedReceipt>(
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
    public Delayed? Delayed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Delayed>("delayed");
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
    public DeliveredToWrongLocation? DeliveredToWrongLocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DeliveredToWrongLocation>(
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
    public MerchantCancellation? MerchantCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MerchantCancellation>("merchant_cancellation");
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
    public NoCancellation? NoCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NoCancellation>("no_cancellation");
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

    public ConsumerMerchandiseNotReceived() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerMerchandiseNotReceived(
        ConsumerMerchandiseNotReceived consumerMerchandiseNotReceived
    )
        : base(consumerMerchandiseNotReceived) { }
#pragma warning restore CS8618

    public ConsumerMerchandiseNotReceived(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerMerchandiseNotReceived(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerMerchandiseNotReceivedFromRaw.FromRawUnchecked"/>
    public static ConsumerMerchandiseNotReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerMerchandiseNotReceivedFromRaw : IFromRawJson<ConsumerMerchandiseNotReceived>
{
    /// <inheritdoc/>
    public ConsumerMerchandiseNotReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerMerchandiseNotReceived.FromRawUnchecked(rawData);
}

/// <summary>
/// Cancellation outcome.
/// </summary>
[JsonConverter(typeof(CancellationOutcomeConverter))]
public enum CancellationOutcome
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

sealed class CancellationOutcomeConverter : JsonConverter<CancellationOutcome>
{
    public override CancellationOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cardholder_cancellation_prior_to_expected_receipt" =>
                CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            "merchant_cancellation" => CancellationOutcome.MerchantCancellation,
            "no_cancellation" => CancellationOutcome.NoCancellation,
            _ => (CancellationOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CancellationOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CancellationOutcome.CardholderCancellationPriorToExpectedReceipt =>
                    "cardholder_cancellation_prior_to_expected_receipt",
                CancellationOutcome.MerchantCancellation => "merchant_cancellation",
                CancellationOutcome.NoCancellation => "no_cancellation",
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
[JsonConverter(typeof(DeliveryIssueConverter))]
public enum DeliveryIssue
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

sealed class DeliveryIssueConverter : JsonConverter<DeliveryIssue>
{
    public override DeliveryIssue Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "delayed" => DeliveryIssue.Delayed,
            "delivered_to_wrong_location" => DeliveryIssue.DeliveredToWrongLocation,
            _ => (DeliveryIssue)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeliveryIssue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DeliveryIssue.Delayed => "delayed",
                DeliveryIssue.DeliveredToWrongLocation => "delivered_to_wrong_location",
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
[JsonConverter(typeof(ConsumerMerchandiseNotReceivedMerchantResolutionAttemptedConverter))]
public enum ConsumerMerchandiseNotReceivedMerchantResolutionAttempted
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

sealed class ConsumerMerchandiseNotReceivedMerchantResolutionAttemptedConverter
    : JsonConverter<ConsumerMerchandiseNotReceivedMerchantResolutionAttempted>
{
    public override ConsumerMerchandiseNotReceivedMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" => ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ConsumerMerchandiseNotReceivedMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerMerchandiseNotReceivedMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted => "attempted",
                ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
        CardholderCancellationPriorToExpectedReceipt,
        CardholderCancellationPriorToExpectedReceiptFromRaw
    >)
)]
public sealed record class CardholderCancellationPriorToExpectedReceipt : JsonModel
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

    public CardholderCancellationPriorToExpectedReceipt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardholderCancellationPriorToExpectedReceipt(
        CardholderCancellationPriorToExpectedReceipt cardholderCancellationPriorToExpectedReceipt
    )
        : base(cardholderCancellationPriorToExpectedReceipt) { }
#pragma warning restore CS8618

    public CardholderCancellationPriorToExpectedReceipt(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardholderCancellationPriorToExpectedReceipt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardholderCancellationPriorToExpectedReceiptFromRaw.FromRawUnchecked"/>
    public static CardholderCancellationPriorToExpectedReceipt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardholderCancellationPriorToExpectedReceipt(string canceledAt)
        : this()
    {
        this.CanceledAt = canceledAt;
    }
}

class CardholderCancellationPriorToExpectedReceiptFromRaw
    : IFromRawJson<CardholderCancellationPriorToExpectedReceipt>
{
    /// <inheritdoc/>
    public CardholderCancellationPriorToExpectedReceipt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardholderCancellationPriorToExpectedReceipt.FromRawUnchecked(rawData);
}

/// <summary>
/// Delayed. Required if and only if `delivery_issue` is `delayed`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Delayed, DelayedFromRaw>))]
public sealed record class Delayed : JsonModel
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
    public required ApiEnum<string, DelayedReturnOutcome> ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DelayedReturnOutcome>>(
                "return_outcome"
            );
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Not returned. Required if and only if `return_outcome` is `not_returned`.
    /// </summary>
    public DelayedNotReturned? NotReturned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DelayedNotReturned>("not_returned");
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
    public DelayedReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DelayedReturnAttempted>("return_attempted");
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
    public DelayedReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DelayedReturned>("returned");
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

    public Delayed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Delayed(Delayed delayed)
        : base(delayed) { }
#pragma warning restore CS8618

    public Delayed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Delayed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DelayedFromRaw.FromRawUnchecked"/>
    public static Delayed FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DelayedFromRaw : IFromRawJson<Delayed>
{
    /// <inheritdoc/>
    public Delayed FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Delayed.FromRawUnchecked(rawData);
}

/// <summary>
/// Return outcome.
/// </summary>
[JsonConverter(typeof(DelayedReturnOutcomeConverter))]
public enum DelayedReturnOutcome
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

sealed class DelayedReturnOutcomeConverter : JsonConverter<DelayedReturnOutcome>
{
    public override DelayedReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_returned" => DelayedReturnOutcome.NotReturned,
            "returned" => DelayedReturnOutcome.Returned,
            "return_attempted" => DelayedReturnOutcome.ReturnAttempted,
            _ => (DelayedReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DelayedReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DelayedReturnOutcome.NotReturned => "not_returned",
                DelayedReturnOutcome.Returned => "returned",
                DelayedReturnOutcome.ReturnAttempted => "return_attempted",
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
[JsonConverter(typeof(JsonModelConverter<DelayedNotReturned, DelayedNotReturnedFromRaw>))]
public sealed record class DelayedNotReturned : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public DelayedNotReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DelayedNotReturned(DelayedNotReturned delayedNotReturned)
        : base(delayedNotReturned) { }
#pragma warning restore CS8618

    public DelayedNotReturned(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DelayedNotReturned(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DelayedNotReturnedFromRaw.FromRawUnchecked"/>
    public static DelayedNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DelayedNotReturnedFromRaw : IFromRawJson<DelayedNotReturned>
{
    /// <inheritdoc/>
    public DelayedNotReturned FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DelayedNotReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DelayedReturnAttempted, DelayedReturnAttemptedFromRaw>))]
public sealed record class DelayedReturnAttempted : JsonModel
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

    public DelayedReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DelayedReturnAttempted(DelayedReturnAttempted delayedReturnAttempted)
        : base(delayedReturnAttempted) { }
#pragma warning restore CS8618

    public DelayedReturnAttempted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DelayedReturnAttempted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DelayedReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static DelayedReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DelayedReturnAttempted(string attemptedAt)
        : this()
    {
        this.AttemptedAt = attemptedAt;
    }
}

class DelayedReturnAttemptedFromRaw : IFromRawJson<DelayedReturnAttempted>
{
    /// <inheritdoc/>
    public DelayedReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DelayedReturnAttempted.FromRawUnchecked(rawData);
}

/// <summary>
/// Returned. Required if and only if `return_outcome` is `returned`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DelayedReturned, DelayedReturnedFromRaw>))]
public sealed record class DelayedReturned : JsonModel
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

    public DelayedReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DelayedReturned(DelayedReturned delayedReturned)
        : base(delayedReturned) { }
#pragma warning restore CS8618

    public DelayedReturned(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DelayedReturned(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DelayedReturnedFromRaw.FromRawUnchecked"/>
    public static DelayedReturned FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DelayedReturnedFromRaw : IFromRawJson<DelayedReturned>
{
    /// <inheritdoc/>
    public DelayedReturned FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DelayedReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Delivered to wrong location. Required if and only if `delivery_issue` is `delivered_to_wrong_location`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DeliveredToWrongLocation, DeliveredToWrongLocationFromRaw>)
)]
public sealed record class DeliveredToWrongLocation : JsonModel
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

    public DeliveredToWrongLocation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeliveredToWrongLocation(DeliveredToWrongLocation deliveredToWrongLocation)
        : base(deliveredToWrongLocation) { }
#pragma warning restore CS8618

    public DeliveredToWrongLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeliveredToWrongLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeliveredToWrongLocationFromRaw.FromRawUnchecked"/>
    public static DeliveredToWrongLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DeliveredToWrongLocation(string agreedLocation)
        : this()
    {
        this.AgreedLocation = agreedLocation;
    }
}

class DeliveredToWrongLocationFromRaw : IFromRawJson<DeliveredToWrongLocation>
{
    /// <inheritdoc/>
    public DeliveredToWrongLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DeliveredToWrongLocation.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant cancellation. Required if and only if `cancellation_outcome` is `merchant_cancellation`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MerchantCancellation, MerchantCancellationFromRaw>))]
public sealed record class MerchantCancellation : JsonModel
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

    public MerchantCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MerchantCancellation(MerchantCancellation merchantCancellation)
        : base(merchantCancellation) { }
#pragma warning restore CS8618

    public MerchantCancellation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MerchantCancellation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MerchantCancellationFromRaw.FromRawUnchecked"/>
    public static MerchantCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MerchantCancellation(string canceledAt)
        : this()
    {
        this.CanceledAt = canceledAt;
    }
}

class MerchantCancellationFromRaw : IFromRawJson<MerchantCancellation>
{
    /// <inheritdoc/>
    public MerchantCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MerchantCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// No cancellation. Required if and only if `cancellation_outcome` is `no_cancellation`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NoCancellation, NoCancellationFromRaw>))]
public sealed record class NoCancellation : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public NoCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NoCancellation(NoCancellation noCancellation)
        : base(noCancellation) { }
#pragma warning restore CS8618

    public NoCancellation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NoCancellation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NoCancellationFromRaw.FromRawUnchecked"/>
    public static NoCancellation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NoCancellationFromRaw : IFromRawJson<NoCancellation>
{
    /// <inheritdoc/>
    public NoCancellation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NoCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// Non-receipt of cash. Required if and only if `category` is `consumer_non_receipt_of_cash`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ConsumerNonReceiptOfCash, ConsumerNonReceiptOfCashFromRaw>)
)]
public sealed record class ConsumerNonReceiptOfCash : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ConsumerNonReceiptOfCash() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerNonReceiptOfCash(ConsumerNonReceiptOfCash consumerNonReceiptOfCash)
        : base(consumerNonReceiptOfCash) { }
#pragma warning restore CS8618

    public ConsumerNonReceiptOfCash(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerNonReceiptOfCash(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerNonReceiptOfCashFromRaw.FromRawUnchecked"/>
    public static ConsumerNonReceiptOfCash FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerNonReceiptOfCashFromRaw : IFromRawJson<ConsumerNonReceiptOfCash>
{
    /// <inheritdoc/>
    public ConsumerNonReceiptOfCash FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerNonReceiptOfCash.FromRawUnchecked(rawData);
}

/// <summary>
/// Original Credit Transaction (OCT) not accepted. Required if and only if `category`
/// is `consumer_original_credit_transaction_not_accepted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConsumerOriginalCreditTransactionNotAccepted,
        ConsumerOriginalCreditTransactionNotAcceptedFromRaw
    >)
)]
public sealed record class ConsumerOriginalCreditTransactionNotAccepted : JsonModel
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
        _ = this.Explanation;
        this.Reason.Validate();
    }

    public ConsumerOriginalCreditTransactionNotAccepted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerOriginalCreditTransactionNotAccepted(
        ConsumerOriginalCreditTransactionNotAccepted consumerOriginalCreditTransactionNotAccepted
    )
        : base(consumerOriginalCreditTransactionNotAccepted) { }
#pragma warning restore CS8618

    public ConsumerOriginalCreditTransactionNotAccepted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerOriginalCreditTransactionNotAccepted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerOriginalCreditTransactionNotAcceptedFromRaw.FromRawUnchecked"/>
    public static ConsumerOriginalCreditTransactionNotAccepted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerOriginalCreditTransactionNotAcceptedFromRaw
    : IFromRawJson<ConsumerOriginalCreditTransactionNotAccepted>
{
    /// <inheritdoc/>
    public ConsumerOriginalCreditTransactionNotAccepted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerOriginalCreditTransactionNotAccepted.FromRawUnchecked(rawData);
}

/// <summary>
/// Reason.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
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
            "prohibited_by_local_laws_or_regulation" => Reason.ProhibitedByLocalLawsOrRegulation,
            "recipient_refused" => Reason.RecipientRefused,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.ProhibitedByLocalLawsOrRegulation =>
                    "prohibited_by_local_laws_or_regulation",
                Reason.RecipientRefused => "recipient_refused",
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
    typeof(JsonModelConverter<ConsumerQualityMerchandise, ConsumerQualityMerchandiseFromRaw>)
)]
public sealed record class ConsumerQualityMerchandise : JsonModel
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
        ConsumerQualityMerchandiseMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerQualityMerchandiseMerchantResolutionAttempted>
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
    public required ApiEnum<string, ConsumerQualityMerchandiseReturnOutcome> ReturnOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerQualityMerchandiseReturnOutcome>
            >("return_outcome");
        }
        init { this._rawData.Set("return_outcome", value); }
    }

    /// <summary>
    /// Not returned. Required if and only if `return_outcome` is `not_returned`.
    /// </summary>
    public ConsumerQualityMerchandiseNotReturned? NotReturned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerQualityMerchandiseNotReturned>(
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
    public OngoingNegotiations? OngoingNegotiations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OngoingNegotiations>("ongoing_negotiations");
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
    public ConsumerQualityMerchandiseReturnAttempted? ReturnAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerQualityMerchandiseReturnAttempted>(
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
    public ConsumerQualityMerchandiseReturned? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerQualityMerchandiseReturned>("returned");
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

    public ConsumerQualityMerchandise() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerQualityMerchandise(ConsumerQualityMerchandise consumerQualityMerchandise)
        : base(consumerQualityMerchandise) { }
#pragma warning restore CS8618

    public ConsumerQualityMerchandise(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerQualityMerchandise(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerQualityMerchandiseFromRaw.FromRawUnchecked"/>
    public static ConsumerQualityMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerQualityMerchandiseFromRaw : IFromRawJson<ConsumerQualityMerchandise>
{
    /// <inheritdoc/>
    public ConsumerQualityMerchandise FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerQualityMerchandise.FromRawUnchecked(rawData);
}

/// <summary>
/// Merchant resolution attempted.
/// </summary>
[JsonConverter(typeof(ConsumerQualityMerchandiseMerchantResolutionAttemptedConverter))]
public enum ConsumerQualityMerchandiseMerchantResolutionAttempted
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

sealed class ConsumerQualityMerchandiseMerchantResolutionAttemptedConverter
    : JsonConverter<ConsumerQualityMerchandiseMerchantResolutionAttempted>
{
    public override ConsumerQualityMerchandiseMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" => ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ConsumerQualityMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ConsumerQualityMerchandiseMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerQualityMerchandiseMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted => "attempted",
                ConsumerQualityMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
[JsonConverter(typeof(ConsumerQualityMerchandiseReturnOutcomeConverter))]
public enum ConsumerQualityMerchandiseReturnOutcome
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

sealed class ConsumerQualityMerchandiseReturnOutcomeConverter
    : JsonConverter<ConsumerQualityMerchandiseReturnOutcome>
{
    public override ConsumerQualityMerchandiseReturnOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_returned" => ConsumerQualityMerchandiseReturnOutcome.NotReturned,
            "returned" => ConsumerQualityMerchandiseReturnOutcome.Returned,
            "return_attempted" => ConsumerQualityMerchandiseReturnOutcome.ReturnAttempted,
            _ => (ConsumerQualityMerchandiseReturnOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerQualityMerchandiseReturnOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerQualityMerchandiseReturnOutcome.NotReturned => "not_returned",
                ConsumerQualityMerchandiseReturnOutcome.Returned => "returned",
                ConsumerQualityMerchandiseReturnOutcome.ReturnAttempted => "return_attempted",
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
        ConsumerQualityMerchandiseNotReturned,
        ConsumerQualityMerchandiseNotReturnedFromRaw
    >)
)]
public sealed record class ConsumerQualityMerchandiseNotReturned : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ConsumerQualityMerchandiseNotReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerQualityMerchandiseNotReturned(
        ConsumerQualityMerchandiseNotReturned consumerQualityMerchandiseNotReturned
    )
        : base(consumerQualityMerchandiseNotReturned) { }
#pragma warning restore CS8618

    public ConsumerQualityMerchandiseNotReturned(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerQualityMerchandiseNotReturned(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerQualityMerchandiseNotReturnedFromRaw.FromRawUnchecked"/>
    public static ConsumerQualityMerchandiseNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerQualityMerchandiseNotReturnedFromRaw
    : IFromRawJson<ConsumerQualityMerchandiseNotReturned>
{
    /// <inheritdoc/>
    public ConsumerQualityMerchandiseNotReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerQualityMerchandiseNotReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Ongoing negotiations. Exclude if there is no evidence of ongoing negotiations.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OngoingNegotiations, OngoingNegotiationsFromRaw>))]
public sealed record class OngoingNegotiations : JsonModel
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

    public OngoingNegotiations() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OngoingNegotiations(OngoingNegotiations ongoingNegotiations)
        : base(ongoingNegotiations) { }
#pragma warning restore CS8618

    public OngoingNegotiations(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OngoingNegotiations(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OngoingNegotiationsFromRaw.FromRawUnchecked"/>
    public static OngoingNegotiations FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OngoingNegotiationsFromRaw : IFromRawJson<OngoingNegotiations>
{
    /// <inheritdoc/>
    public OngoingNegotiations FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OngoingNegotiations.FromRawUnchecked(rawData);
}

/// <summary>
/// Return attempted. Required if and only if `return_outcome` is `return_attempted`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConsumerQualityMerchandiseReturnAttempted,
        ConsumerQualityMerchandiseReturnAttemptedFromRaw
    >)
)]
public sealed record class ConsumerQualityMerchandiseReturnAttempted : JsonModel
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
        ConsumerQualityMerchandiseReturnAttemptedAttemptReason
    > AttemptReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerQualityMerchandiseReturnAttemptedAttemptReason>
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

    public ConsumerQualityMerchandiseReturnAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerQualityMerchandiseReturnAttempted(
        ConsumerQualityMerchandiseReturnAttempted consumerQualityMerchandiseReturnAttempted
    )
        : base(consumerQualityMerchandiseReturnAttempted) { }
#pragma warning restore CS8618

    public ConsumerQualityMerchandiseReturnAttempted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerQualityMerchandiseReturnAttempted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerQualityMerchandiseReturnAttemptedFromRaw.FromRawUnchecked"/>
    public static ConsumerQualityMerchandiseReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerQualityMerchandiseReturnAttemptedFromRaw
    : IFromRawJson<ConsumerQualityMerchandiseReturnAttempted>
{
    /// <inheritdoc/>
    public ConsumerQualityMerchandiseReturnAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerQualityMerchandiseReturnAttempted.FromRawUnchecked(rawData);
}

/// <summary>
/// Attempt reason.
/// </summary>
[JsonConverter(typeof(ConsumerQualityMerchandiseReturnAttemptedAttemptReasonConverter))]
public enum ConsumerQualityMerchandiseReturnAttemptedAttemptReason
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

sealed class ConsumerQualityMerchandiseReturnAttemptedAttemptReasonConverter
    : JsonConverter<ConsumerQualityMerchandiseReturnAttemptedAttemptReason>
{
    public override ConsumerQualityMerchandiseReturnAttemptedAttemptReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merchant_not_responding" =>
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            "no_return_authorization_provided" =>
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided,
            "no_return_instructions" =>
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions,
            "requested_not_to_return" =>
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn,
            "return_not_accepted" =>
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted,
            _ => (ConsumerQualityMerchandiseReturnAttemptedAttemptReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerQualityMerchandiseReturnAttemptedAttemptReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding =>
                    "merchant_not_responding",
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided =>
                    "no_return_authorization_provided",
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions =>
                    "no_return_instructions",
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn =>
                    "requested_not_to_return",
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted =>
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
        ConsumerQualityMerchandiseReturned,
        ConsumerQualityMerchandiseReturnedFromRaw
    >)
)]
public sealed record class ConsumerQualityMerchandiseReturned : JsonModel
{
    /// <summary>
    /// Return method.
    /// </summary>
    public required ApiEnum<string, ConsumerQualityMerchandiseReturnedReturnMethod> ReturnMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerQualityMerchandiseReturnedReturnMethod>
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

    public ConsumerQualityMerchandiseReturned() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerQualityMerchandiseReturned(
        ConsumerQualityMerchandiseReturned consumerQualityMerchandiseReturned
    )
        : base(consumerQualityMerchandiseReturned) { }
#pragma warning restore CS8618

    public ConsumerQualityMerchandiseReturned(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerQualityMerchandiseReturned(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerQualityMerchandiseReturnedFromRaw.FromRawUnchecked"/>
    public static ConsumerQualityMerchandiseReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerQualityMerchandiseReturnedFromRaw : IFromRawJson<ConsumerQualityMerchandiseReturned>
{
    /// <inheritdoc/>
    public ConsumerQualityMerchandiseReturned FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerQualityMerchandiseReturned.FromRawUnchecked(rawData);
}

/// <summary>
/// Return method.
/// </summary>
[JsonConverter(typeof(ConsumerQualityMerchandiseReturnedReturnMethodConverter))]
public enum ConsumerQualityMerchandiseReturnedReturnMethod
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

sealed class ConsumerQualityMerchandiseReturnedReturnMethodConverter
    : JsonConverter<ConsumerQualityMerchandiseReturnedReturnMethod>
{
    public override ConsumerQualityMerchandiseReturnedReturnMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dhl" => ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            "face_to_face" => ConsumerQualityMerchandiseReturnedReturnMethod.FaceToFace,
            "fedex" => ConsumerQualityMerchandiseReturnedReturnMethod.Fedex,
            "other" => ConsumerQualityMerchandiseReturnedReturnMethod.Other,
            "postal_service" => ConsumerQualityMerchandiseReturnedReturnMethod.PostalService,
            "ups" => ConsumerQualityMerchandiseReturnedReturnMethod.Ups,
            _ => (ConsumerQualityMerchandiseReturnedReturnMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerQualityMerchandiseReturnedReturnMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerQualityMerchandiseReturnedReturnMethod.Dhl => "dhl",
                ConsumerQualityMerchandiseReturnedReturnMethod.FaceToFace => "face_to_face",
                ConsumerQualityMerchandiseReturnedReturnMethod.Fedex => "fedex",
                ConsumerQualityMerchandiseReturnedReturnMethod.Other => "other",
                ConsumerQualityMerchandiseReturnedReturnMethod.PostalService => "postal_service",
                ConsumerQualityMerchandiseReturnedReturnMethod.Ups => "ups",
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
[JsonConverter(typeof(JsonModelConverter<ConsumerQualityServices, ConsumerQualityServicesFromRaw>))]
public sealed record class ConsumerQualityServices : JsonModel
{
    /// <summary>
    /// Cardholder cancellation.
    /// </summary>
    public required ConsumerQualityServicesCardholderCancellation CardholderCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ConsumerQualityServicesCardholderCancellation>(
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
        NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
    > NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription>
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
    public ApiEnum<string, CardholderPaidToHaveWorkRedone>? CardholderPaidToHaveWorkRedone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CardholderPaidToHaveWorkRedone>>(
                "cardholder_paid_to_have_work_redone"
            );
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
    public ConsumerQualityServicesOngoingNegotiations? OngoingNegotiations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerQualityServicesOngoingNegotiations>(
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
    public ApiEnum<string, RestaurantFoodRelated>? RestaurantFoodRelated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RestaurantFoodRelated>>(
                "restaurant_food_related"
            );
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

    public ConsumerQualityServices() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerQualityServices(ConsumerQualityServices consumerQualityServices)
        : base(consumerQualityServices) { }
#pragma warning restore CS8618

    public ConsumerQualityServices(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerQualityServices(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerQualityServicesFromRaw.FromRawUnchecked"/>
    public static ConsumerQualityServices FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerQualityServicesFromRaw : IFromRawJson<ConsumerQualityServices>
{
    /// <inheritdoc/>
    public ConsumerQualityServices FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerQualityServices.FromRawUnchecked(rawData);
}

/// <summary>
/// Cardholder cancellation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConsumerQualityServicesCardholderCancellation,
        ConsumerQualityServicesCardholderCancellationFromRaw
    >)
)]
public sealed record class ConsumerQualityServicesCardholderCancellation : JsonModel
{
    /// <summary>
    /// Accepted by merchant.
    /// </summary>
    public required ApiEnum<string, AcceptedByMerchant> AcceptedByMerchant
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AcceptedByMerchant>>(
                "accepted_by_merchant"
            );
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

    public ConsumerQualityServicesCardholderCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerQualityServicesCardholderCancellation(
        ConsumerQualityServicesCardholderCancellation consumerQualityServicesCardholderCancellation
    )
        : base(consumerQualityServicesCardholderCancellation) { }
#pragma warning restore CS8618

    public ConsumerQualityServicesCardholderCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerQualityServicesCardholderCancellation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerQualityServicesCardholderCancellationFromRaw.FromRawUnchecked"/>
    public static ConsumerQualityServicesCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerQualityServicesCardholderCancellationFromRaw
    : IFromRawJson<ConsumerQualityServicesCardholderCancellation>
{
    /// <inheritdoc/>
    public ConsumerQualityServicesCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerQualityServicesCardholderCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// Accepted by merchant.
/// </summary>
[JsonConverter(typeof(AcceptedByMerchantConverter))]
public enum AcceptedByMerchant
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

sealed class AcceptedByMerchantConverter : JsonConverter<AcceptedByMerchant>
{
    public override AcceptedByMerchant Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" => AcceptedByMerchant.Accepted,
            "not_accepted" => AcceptedByMerchant.NotAccepted,
            _ => (AcceptedByMerchant)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AcceptedByMerchant value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AcceptedByMerchant.Accepted => "accepted",
                AcceptedByMerchant.NotAccepted => "not_accepted",
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
[JsonConverter(typeof(NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescriptionConverter))]
public enum NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
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

sealed class NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescriptionConverter
    : JsonConverter<NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription>
{
    public override NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_related" =>
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            "related" => NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.Related,
            _ => (NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated =>
                    "not_related",
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.Related =>
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
[JsonConverter(typeof(CardholderPaidToHaveWorkRedoneConverter))]
public enum CardholderPaidToHaveWorkRedone
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

sealed class CardholderPaidToHaveWorkRedoneConverter : JsonConverter<CardholderPaidToHaveWorkRedone>
{
    public override CardholderPaidToHaveWorkRedone Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "did_not_pay_to_have_work_redone" =>
                CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            "paid_to_have_work_redone" => CardholderPaidToHaveWorkRedone.PaidToHaveWorkRedone,
            _ => (CardholderPaidToHaveWorkRedone)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardholderPaidToHaveWorkRedone value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone =>
                    "did_not_pay_to_have_work_redone",
                CardholderPaidToHaveWorkRedone.PaidToHaveWorkRedone => "paid_to_have_work_redone",
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
        ConsumerQualityServicesOngoingNegotiations,
        ConsumerQualityServicesOngoingNegotiationsFromRaw
    >)
)]
public sealed record class ConsumerQualityServicesOngoingNegotiations : JsonModel
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

    public ConsumerQualityServicesOngoingNegotiations() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerQualityServicesOngoingNegotiations(
        ConsumerQualityServicesOngoingNegotiations consumerQualityServicesOngoingNegotiations
    )
        : base(consumerQualityServicesOngoingNegotiations) { }
#pragma warning restore CS8618

    public ConsumerQualityServicesOngoingNegotiations(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerQualityServicesOngoingNegotiations(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerQualityServicesOngoingNegotiationsFromRaw.FromRawUnchecked"/>
    public static ConsumerQualityServicesOngoingNegotiations FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerQualityServicesOngoingNegotiationsFromRaw
    : IFromRawJson<ConsumerQualityServicesOngoingNegotiations>
{
    /// <inheritdoc/>
    public ConsumerQualityServicesOngoingNegotiations FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerQualityServicesOngoingNegotiations.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the dispute is related to the quality of food from an eating place or
/// restaurant. Must be provided when Merchant Category Code (MCC) is 5812, 5813 or 5814.
/// </summary>
[JsonConverter(typeof(RestaurantFoodRelatedConverter))]
public enum RestaurantFoodRelated
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

sealed class RestaurantFoodRelatedConverter : JsonConverter<RestaurantFoodRelated>
{
    public override RestaurantFoodRelated Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_related" => RestaurantFoodRelated.NotRelated,
            "related" => RestaurantFoodRelated.Related,
            _ => (RestaurantFoodRelated)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RestaurantFoodRelated value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RestaurantFoodRelated.NotRelated => "not_related",
                RestaurantFoodRelated.Related => "related",
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
        ConsumerServicesMisrepresentation,
        ConsumerServicesMisrepresentationFromRaw
    >)
)]
public sealed record class ConsumerServicesMisrepresentation : JsonModel
{
    /// <summary>
    /// Cardholder cancellation.
    /// </summary>
    public required ConsumerServicesMisrepresentationCardholderCancellation CardholderCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ConsumerServicesMisrepresentationCardholderCancellation>(
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
        ConsumerServicesMisrepresentationMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerServicesMisrepresentationMerchantResolutionAttempted>
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

    public ConsumerServicesMisrepresentation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerServicesMisrepresentation(
        ConsumerServicesMisrepresentation consumerServicesMisrepresentation
    )
        : base(consumerServicesMisrepresentation) { }
#pragma warning restore CS8618

    public ConsumerServicesMisrepresentation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerServicesMisrepresentation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerServicesMisrepresentationFromRaw.FromRawUnchecked"/>
    public static ConsumerServicesMisrepresentation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerServicesMisrepresentationFromRaw : IFromRawJson<ConsumerServicesMisrepresentation>
{
    /// <inheritdoc/>
    public ConsumerServicesMisrepresentation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerServicesMisrepresentation.FromRawUnchecked(rawData);
}

/// <summary>
/// Cardholder cancellation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConsumerServicesMisrepresentationCardholderCancellation,
        ConsumerServicesMisrepresentationCardholderCancellationFromRaw
    >)
)]
public sealed record class ConsumerServicesMisrepresentationCardholderCancellation : JsonModel
{
    /// <summary>
    /// Accepted by merchant.
    /// </summary>
    public required ApiEnum<
        string,
        ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
    > AcceptedByMerchant
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
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

    public ConsumerServicesMisrepresentationCardholderCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerServicesMisrepresentationCardholderCancellation(
        ConsumerServicesMisrepresentationCardholderCancellation consumerServicesMisrepresentationCardholderCancellation
    )
        : base(consumerServicesMisrepresentationCardholderCancellation) { }
#pragma warning restore CS8618

    public ConsumerServicesMisrepresentationCardholderCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerServicesMisrepresentationCardholderCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerServicesMisrepresentationCardholderCancellationFromRaw.FromRawUnchecked"/>
    public static ConsumerServicesMisrepresentationCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerServicesMisrepresentationCardholderCancellationFromRaw
    : IFromRawJson<ConsumerServicesMisrepresentationCardholderCancellation>
{
    /// <inheritdoc/>
    public ConsumerServicesMisrepresentationCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerServicesMisrepresentationCardholderCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// Accepted by merchant.
/// </summary>
[JsonConverter(
    typeof(ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchantConverter)
)]
public enum ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
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

sealed class ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchantConverter
    : JsonConverter<ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant>
{
    public override ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" =>
                ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
            "not_accepted" =>
                ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.NotAccepted,
            _ => (ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted =>
                    "accepted",
                ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.NotAccepted =>
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
[JsonConverter(typeof(ConsumerServicesMisrepresentationMerchantResolutionAttemptedConverter))]
public enum ConsumerServicesMisrepresentationMerchantResolutionAttempted
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

sealed class ConsumerServicesMisrepresentationMerchantResolutionAttemptedConverter
    : JsonConverter<ConsumerServicesMisrepresentationMerchantResolutionAttempted>
{
    public override ConsumerServicesMisrepresentationMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" => ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ConsumerServicesMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ConsumerServicesMisrepresentationMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerServicesMisrepresentationMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted =>
                    "attempted",
                ConsumerServicesMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
        ConsumerServicesNotAsDescribed,
        ConsumerServicesNotAsDescribedFromRaw
    >)
)]
public sealed record class ConsumerServicesNotAsDescribed : JsonModel
{
    /// <summary>
    /// Cardholder cancellation.
    /// </summary>
    public required ConsumerServicesNotAsDescribedCardholderCancellation CardholderCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ConsumerServicesNotAsDescribedCardholderCancellation>(
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
        ConsumerServicesNotAsDescribedMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerServicesNotAsDescribedMerchantResolutionAttempted>
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

    public ConsumerServicesNotAsDescribed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerServicesNotAsDescribed(
        ConsumerServicesNotAsDescribed consumerServicesNotAsDescribed
    )
        : base(consumerServicesNotAsDescribed) { }
#pragma warning restore CS8618

    public ConsumerServicesNotAsDescribed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerServicesNotAsDescribed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerServicesNotAsDescribedFromRaw.FromRawUnchecked"/>
    public static ConsumerServicesNotAsDescribed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerServicesNotAsDescribedFromRaw : IFromRawJson<ConsumerServicesNotAsDescribed>
{
    /// <inheritdoc/>
    public ConsumerServicesNotAsDescribed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerServicesNotAsDescribed.FromRawUnchecked(rawData);
}

/// <summary>
/// Cardholder cancellation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConsumerServicesNotAsDescribedCardholderCancellation,
        ConsumerServicesNotAsDescribedCardholderCancellationFromRaw
    >)
)]
public sealed record class ConsumerServicesNotAsDescribedCardholderCancellation : JsonModel
{
    /// <summary>
    /// Accepted by merchant.
    /// </summary>
    public required ApiEnum<
        string,
        ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
    > AcceptedByMerchant
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
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

    public ConsumerServicesNotAsDescribedCardholderCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerServicesNotAsDescribedCardholderCancellation(
        ConsumerServicesNotAsDescribedCardholderCancellation consumerServicesNotAsDescribedCardholderCancellation
    )
        : base(consumerServicesNotAsDescribedCardholderCancellation) { }
#pragma warning restore CS8618

    public ConsumerServicesNotAsDescribedCardholderCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerServicesNotAsDescribedCardholderCancellation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerServicesNotAsDescribedCardholderCancellationFromRaw.FromRawUnchecked"/>
    public static ConsumerServicesNotAsDescribedCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerServicesNotAsDescribedCardholderCancellationFromRaw
    : IFromRawJson<ConsumerServicesNotAsDescribedCardholderCancellation>
{
    /// <inheritdoc/>
    public ConsumerServicesNotAsDescribedCardholderCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerServicesNotAsDescribedCardholderCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// Accepted by merchant.
/// </summary>
[JsonConverter(
    typeof(ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchantConverter)
)]
public enum ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
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

sealed class ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchantConverter
    : JsonConverter<ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant>
{
    public override ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" =>
                ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
            "not_accepted" =>
                ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.NotAccepted,
            _ => (ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted =>
                    "accepted",
                ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.NotAccepted =>
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
[JsonConverter(typeof(ConsumerServicesNotAsDescribedMerchantResolutionAttemptedConverter))]
public enum ConsumerServicesNotAsDescribedMerchantResolutionAttempted
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

sealed class ConsumerServicesNotAsDescribedMerchantResolutionAttemptedConverter
    : JsonConverter<ConsumerServicesNotAsDescribedMerchantResolutionAttempted>
{
    public override ConsumerServicesNotAsDescribedMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" => ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ConsumerServicesNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ConsumerServicesNotAsDescribedMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerServicesNotAsDescribedMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted => "attempted",
                ConsumerServicesNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
    typeof(JsonModelConverter<ConsumerServicesNotReceived, ConsumerServicesNotReceivedFromRaw>)
)]
public sealed record class ConsumerServicesNotReceived : JsonModel
{
    /// <summary>
    /// Cancellation outcome.
    /// </summary>
    public required ApiEnum<
        string,
        ConsumerServicesNotReceivedCancellationOutcome
    > CancellationOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerServicesNotReceivedCancellationOutcome>
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
        ConsumerServicesNotReceivedMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConsumerServicesNotReceivedMerchantResolutionAttempted>
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
    public ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt? CardholderCancellationPriorToExpectedReceipt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt>(
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
    public ConsumerServicesNotReceivedMerchantCancellation? MerchantCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerServicesNotReceivedMerchantCancellation>(
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
    public ConsumerServicesNotReceivedNoCancellation? NoCancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumerServicesNotReceivedNoCancellation>(
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

    public ConsumerServicesNotReceived() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerServicesNotReceived(ConsumerServicesNotReceived consumerServicesNotReceived)
        : base(consumerServicesNotReceived) { }
#pragma warning restore CS8618

    public ConsumerServicesNotReceived(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerServicesNotReceived(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerServicesNotReceivedFromRaw.FromRawUnchecked"/>
    public static ConsumerServicesNotReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerServicesNotReceivedFromRaw : IFromRawJson<ConsumerServicesNotReceived>
{
    /// <inheritdoc/>
    public ConsumerServicesNotReceived FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerServicesNotReceived.FromRawUnchecked(rawData);
}

/// <summary>
/// Cancellation outcome.
/// </summary>
[JsonConverter(typeof(ConsumerServicesNotReceivedCancellationOutcomeConverter))]
public enum ConsumerServicesNotReceivedCancellationOutcome
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

sealed class ConsumerServicesNotReceivedCancellationOutcomeConverter
    : JsonConverter<ConsumerServicesNotReceivedCancellationOutcome>
{
    public override ConsumerServicesNotReceivedCancellationOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cardholder_cancellation_prior_to_expected_receipt" =>
                ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            "merchant_cancellation" =>
                ConsumerServicesNotReceivedCancellationOutcome.MerchantCancellation,
            "no_cancellation" => ConsumerServicesNotReceivedCancellationOutcome.NoCancellation,
            _ => (ConsumerServicesNotReceivedCancellationOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerServicesNotReceivedCancellationOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt =>
                    "cardholder_cancellation_prior_to_expected_receipt",
                ConsumerServicesNotReceivedCancellationOutcome.MerchantCancellation =>
                    "merchant_cancellation",
                ConsumerServicesNotReceivedCancellationOutcome.NoCancellation => "no_cancellation",
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
[JsonConverter(typeof(ConsumerServicesNotReceivedMerchantResolutionAttemptedConverter))]
public enum ConsumerServicesNotReceivedMerchantResolutionAttempted
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

sealed class ConsumerServicesNotReceivedMerchantResolutionAttemptedConverter
    : JsonConverter<ConsumerServicesNotReceivedMerchantResolutionAttempted>
{
    public override ConsumerServicesNotReceivedMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" => ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ConsumerServicesNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ConsumerServicesNotReceivedMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsumerServicesNotReceivedMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted => "attempted",
                ConsumerServicesNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
        ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt,
        ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceiptFromRaw
    >)
)]
public sealed record class ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
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

    public ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt(
        ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt consumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
    )
        : base(consumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt) { }
#pragma warning restore CS8618

    public ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceiptFromRaw.FromRawUnchecked"/>
    public static ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt(
        string canceledAt
    )
        : this()
    {
        this.CanceledAt = canceledAt;
    }
}

class ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceiptFromRaw
    : IFromRawJson<ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt>
{
    /// <inheritdoc/>
    public ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Merchant cancellation. Required if and only if `cancellation_outcome` is `merchant_cancellation`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConsumerServicesNotReceivedMerchantCancellation,
        ConsumerServicesNotReceivedMerchantCancellationFromRaw
    >)
)]
public sealed record class ConsumerServicesNotReceivedMerchantCancellation : JsonModel
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

    public ConsumerServicesNotReceivedMerchantCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerServicesNotReceivedMerchantCancellation(
        ConsumerServicesNotReceivedMerchantCancellation consumerServicesNotReceivedMerchantCancellation
    )
        : base(consumerServicesNotReceivedMerchantCancellation) { }
#pragma warning restore CS8618

    public ConsumerServicesNotReceivedMerchantCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerServicesNotReceivedMerchantCancellation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerServicesNotReceivedMerchantCancellationFromRaw.FromRawUnchecked"/>
    public static ConsumerServicesNotReceivedMerchantCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ConsumerServicesNotReceivedMerchantCancellation(string canceledAt)
        : this()
    {
        this.CanceledAt = canceledAt;
    }
}

class ConsumerServicesNotReceivedMerchantCancellationFromRaw
    : IFromRawJson<ConsumerServicesNotReceivedMerchantCancellation>
{
    /// <inheritdoc/>
    public ConsumerServicesNotReceivedMerchantCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerServicesNotReceivedMerchantCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// No cancellation. Required if and only if `cancellation_outcome` is `no_cancellation`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConsumerServicesNotReceivedNoCancellation,
        ConsumerServicesNotReceivedNoCancellationFromRaw
    >)
)]
public sealed record class ConsumerServicesNotReceivedNoCancellation : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ConsumerServicesNotReceivedNoCancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumerServicesNotReceivedNoCancellation(
        ConsumerServicesNotReceivedNoCancellation consumerServicesNotReceivedNoCancellation
    )
        : base(consumerServicesNotReceivedNoCancellation) { }
#pragma warning restore CS8618

    public ConsumerServicesNotReceivedNoCancellation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumerServicesNotReceivedNoCancellation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumerServicesNotReceivedNoCancellationFromRaw.FromRawUnchecked"/>
    public static ConsumerServicesNotReceivedNoCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumerServicesNotReceivedNoCancellationFromRaw
    : IFromRawJson<ConsumerServicesNotReceivedNoCancellation>
{
    /// <inheritdoc/>
    public ConsumerServicesNotReceivedNoCancellation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumerServicesNotReceivedNoCancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// Fraud. Required if and only if `category` is `fraud`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Fraud, FraudFromRaw>))]
public sealed record class Fraud : JsonModel
{
    /// <summary>
    /// Fraud type.
    /// </summary>
    public required ApiEnum<string, FraudType> FraudType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FraudType>>("fraud_type");
        }
        init { this._rawData.Set("fraud_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FraudType.Validate();
    }

    public Fraud() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Fraud(Fraud fraud)
        : base(fraud) { }
#pragma warning restore CS8618

    public Fraud(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Fraud(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FraudFromRaw.FromRawUnchecked"/>
    public static Fraud FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Fraud(ApiEnum<string, FraudType> fraudType)
        : this()
    {
        this.FraudType = fraudType;
    }
}

class FraudFromRaw : IFromRawJson<Fraud>
{
    /// <inheritdoc/>
    public Fraud FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Fraud.FromRawUnchecked(rawData);
}

/// <summary>
/// Fraud type.
/// </summary>
[JsonConverter(typeof(FraudTypeConverter))]
public enum FraudType
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

sealed class FraudTypeConverter : JsonConverter<FraudType>
{
    public override FraudType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_or_credentials_takeover" => FraudType.AccountOrCredentialsTakeover,
            "card_not_received_as_issued" => FraudType.CardNotReceivedAsIssued,
            "fraudulent_application" => FraudType.FraudulentApplication,
            "fraudulent_use_of_account_number" => FraudType.FraudulentUseOfAccountNumber,
            "incorrect_processing" => FraudType.IncorrectProcessing,
            "issuer_reported_counterfeit" => FraudType.IssuerReportedCounterfeit,
            "lost" => FraudType.Lost,
            "manipulation_of_account_holder" => FraudType.ManipulationOfAccountHolder,
            "merchant_misrepresentation" => FraudType.MerchantMisrepresentation,
            "miscellaneous" => FraudType.Miscellaneous,
            "stolen" => FraudType.Stolen,
            _ => (FraudType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FraudType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FraudType.AccountOrCredentialsTakeover => "account_or_credentials_takeover",
                FraudType.CardNotReceivedAsIssued => "card_not_received_as_issued",
                FraudType.FraudulentApplication => "fraudulent_application",
                FraudType.FraudulentUseOfAccountNumber => "fraudulent_use_of_account_number",
                FraudType.IncorrectProcessing => "incorrect_processing",
                FraudType.IssuerReportedCounterfeit => "issuer_reported_counterfeit",
                FraudType.Lost => "lost",
                FraudType.ManipulationOfAccountHolder => "manipulation_of_account_holder",
                FraudType.MerchantMisrepresentation => "merchant_misrepresentation",
                FraudType.Miscellaneous => "miscellaneous",
                FraudType.Stolen => "stolen",
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
[JsonConverter(typeof(JsonModelConverter<ProcessingError, ProcessingErrorFromRaw>))]
public sealed record class ProcessingError : JsonModel
{
    /// <summary>
    /// Error reason.
    /// </summary>
    public required ApiEnum<string, ErrorReason> ErrorReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ErrorReason>>("error_reason");
        }
        init { this._rawData.Set("error_reason", value); }
    }

    /// <summary>
    /// Merchant resolution attempted.
    /// </summary>
    public required ApiEnum<
        string,
        ProcessingErrorMerchantResolutionAttempted
    > MerchantResolutionAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProcessingErrorMerchantResolutionAttempted>
            >("merchant_resolution_attempted");
        }
        init { this._rawData.Set("merchant_resolution_attempted", value); }
    }

    /// <summary>
    /// Duplicate transaction. Required if and only if `error_reason` is `duplicate_transaction`.
    /// </summary>
    public DuplicateTransaction? DuplicateTransaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DuplicateTransaction>("duplicate_transaction");
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
    public IncorrectAmount? IncorrectAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IncorrectAmount>("incorrect_amount");
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
    public PaidByOtherMeans? PaidByOtherMeans
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaidByOtherMeans>("paid_by_other_means");
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

    public ProcessingError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProcessingError(ProcessingError processingError)
        : base(processingError) { }
#pragma warning restore CS8618

    public ProcessingError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProcessingError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProcessingErrorFromRaw.FromRawUnchecked"/>
    public static ProcessingError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProcessingErrorFromRaw : IFromRawJson<ProcessingError>
{
    /// <inheritdoc/>
    public ProcessingError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProcessingError.FromRawUnchecked(rawData);
}

/// <summary>
/// Error reason.
/// </summary>
[JsonConverter(typeof(ErrorReasonConverter))]
public enum ErrorReason
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

sealed class ErrorReasonConverter : JsonConverter<ErrorReason>
{
    public override ErrorReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "duplicate_transaction" => ErrorReason.DuplicateTransaction,
            "incorrect_amount" => ErrorReason.IncorrectAmount,
            "paid_by_other_means" => ErrorReason.PaidByOtherMeans,
            _ => (ErrorReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ErrorReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ErrorReason.DuplicateTransaction => "duplicate_transaction",
                ErrorReason.IncorrectAmount => "incorrect_amount",
                ErrorReason.PaidByOtherMeans => "paid_by_other_means",
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
[JsonConverter(typeof(ProcessingErrorMerchantResolutionAttemptedConverter))]
public enum ProcessingErrorMerchantResolutionAttempted
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

sealed class ProcessingErrorMerchantResolutionAttemptedConverter
    : JsonConverter<ProcessingErrorMerchantResolutionAttempted>
{
    public override ProcessingErrorMerchantResolutionAttempted Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attempted" => ProcessingErrorMerchantResolutionAttempted.Attempted,
            "prohibited_by_local_law" =>
                ProcessingErrorMerchantResolutionAttempted.ProhibitedByLocalLaw,
            _ => (ProcessingErrorMerchantResolutionAttempted)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProcessingErrorMerchantResolutionAttempted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProcessingErrorMerchantResolutionAttempted.Attempted => "attempted",
                ProcessingErrorMerchantResolutionAttempted.ProhibitedByLocalLaw =>
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
[JsonConverter(typeof(JsonModelConverter<DuplicateTransaction, DuplicateTransactionFromRaw>))]
public sealed record class DuplicateTransaction : JsonModel
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

    public DuplicateTransaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DuplicateTransaction(DuplicateTransaction duplicateTransaction)
        : base(duplicateTransaction) { }
#pragma warning restore CS8618

    public DuplicateTransaction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DuplicateTransaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DuplicateTransactionFromRaw.FromRawUnchecked"/>
    public static DuplicateTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DuplicateTransaction(string otherTransactionID)
        : this()
    {
        this.OtherTransactionID = otherTransactionID;
    }
}

class DuplicateTransactionFromRaw : IFromRawJson<DuplicateTransaction>
{
    /// <inheritdoc/>
    public DuplicateTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DuplicateTransaction.FromRawUnchecked(rawData);
}

/// <summary>
/// Incorrect amount. Required if and only if `error_reason` is `incorrect_amount`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<IncorrectAmount, IncorrectAmountFromRaw>))]
public sealed record class IncorrectAmount : JsonModel
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

    public IncorrectAmount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IncorrectAmount(IncorrectAmount incorrectAmount)
        : base(incorrectAmount) { }
#pragma warning restore CS8618

    public IncorrectAmount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IncorrectAmount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IncorrectAmountFromRaw.FromRawUnchecked"/>
    public static IncorrectAmount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IncorrectAmount(long expectedAmount)
        : this()
    {
        this.ExpectedAmount = expectedAmount;
    }
}

class IncorrectAmountFromRaw : IFromRawJson<IncorrectAmount>
{
    /// <inheritdoc/>
    public IncorrectAmount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IncorrectAmount.FromRawUnchecked(rawData);
}

/// <summary>
/// Paid by other means. Required if and only if `error_reason` is `paid_by_other_means`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PaidByOtherMeans, PaidByOtherMeansFromRaw>))]
public sealed record class PaidByOtherMeans : JsonModel
{
    /// <summary>
    /// Other form of payment evidence.
    /// </summary>
    public required ApiEnum<string, OtherFormOfPaymentEvidence> OtherFormOfPaymentEvidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, OtherFormOfPaymentEvidence>>(
                "other_form_of_payment_evidence"
            );
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

    public PaidByOtherMeans() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaidByOtherMeans(PaidByOtherMeans paidByOtherMeans)
        : base(paidByOtherMeans) { }
#pragma warning restore CS8618

    public PaidByOtherMeans(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaidByOtherMeans(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaidByOtherMeansFromRaw.FromRawUnchecked"/>
    public static PaidByOtherMeans FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PaidByOtherMeans(ApiEnum<string, OtherFormOfPaymentEvidence> otherFormOfPaymentEvidence)
        : this()
    {
        this.OtherFormOfPaymentEvidence = otherFormOfPaymentEvidence;
    }
}

class PaidByOtherMeansFromRaw : IFromRawJson<PaidByOtherMeans>
{
    /// <inheritdoc/>
    public PaidByOtherMeans FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaidByOtherMeans.FromRawUnchecked(rawData);
}

/// <summary>
/// Other form of payment evidence.
/// </summary>
[JsonConverter(typeof(OtherFormOfPaymentEvidenceConverter))]
public enum OtherFormOfPaymentEvidence
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

sealed class OtherFormOfPaymentEvidenceConverter : JsonConverter<OtherFormOfPaymentEvidence>
{
    public override OtherFormOfPaymentEvidence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "canceled_check" => OtherFormOfPaymentEvidence.CanceledCheck,
            "card_transaction" => OtherFormOfPaymentEvidence.CardTransaction,
            "cash_receipt" => OtherFormOfPaymentEvidence.CashReceipt,
            "other" => OtherFormOfPaymentEvidence.Other,
            "statement" => OtherFormOfPaymentEvidence.Statement,
            "voucher" => OtherFormOfPaymentEvidence.Voucher,
            _ => (OtherFormOfPaymentEvidence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OtherFormOfPaymentEvidence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OtherFormOfPaymentEvidence.CanceledCheck => "canceled_check",
                OtherFormOfPaymentEvidence.CardTransaction => "card_transaction",
                OtherFormOfPaymentEvidence.CashReceipt => "cash_receipt",
                OtherFormOfPaymentEvidence.Other => "other",
                OtherFormOfPaymentEvidence.Statement => "statement",
                OtherFormOfPaymentEvidence.Voucher => "voucher",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
