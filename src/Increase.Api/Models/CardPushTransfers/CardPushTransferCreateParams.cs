using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.CardPushTransfers;

/// <summary>
/// Create a Card Push Transfer
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CardPushTransferCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The Business Application Identifier describes the type of transaction being
    /// performed. Your program must be approved for the specified Business Application
    /// Identifier in order to use it.
    /// </summary>
    public required ApiEnum<string, BusinessApplicationIdentifier> BusinessApplicationIdentifier
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, BusinessApplicationIdentifier>
            >("business_application_identifier");
        }
        init { this._rawBodyData.Set("business_application_identifier", value); }
    }

    /// <summary>
    /// The Increase identifier for the Card Token that represents the card number
    /// you're pushing funds to.
    /// </summary>
    public required string CardTokenID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("card_token_id");
        }
        init { this._rawBodyData.Set("card_token_id", value); }
    }

    /// <summary>
    /// The merchant category code (MCC) of the merchant (generally your business)
    /// sending the transfer. This is a four-digit code that describes the type of
    /// business or service provided by the merchant. Your program must be approved
    /// for the specified MCC in order to use it.
    /// </summary>
    public required string MerchantCategoryCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("merchant_category_code");
        }
        init { this._rawBodyData.Set("merchant_category_code", value); }
    }

    /// <summary>
    /// The city name of the merchant (generally your business) sending the transfer.
    /// </summary>
    public required string MerchantCityName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("merchant_city_name");
        }
        init { this._rawBodyData.Set("merchant_city_name", value); }
    }

    /// <summary>
    /// The merchant name shows up as the statement descriptor for the transfer.
    /// This is typically the name of your business or organization.
    /// </summary>
    public required string MerchantName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("merchant_name");
        }
        init { this._rawBodyData.Set("merchant_name", value); }
    }

    /// <summary>
    /// For certain Business Application Identifiers, the statement descriptor is
    /// `merchant_name_prefix*sender_name`, where the `merchant_name_prefix` is a
    /// one to four character prefix that identifies the merchant.
    /// </summary>
    public required string MerchantNamePrefix
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("merchant_name_prefix");
        }
        init { this._rawBodyData.Set("merchant_name_prefix", value); }
    }

    /// <summary>
    /// The postal code of the merchant (generally your business) sending the transfer.
    /// </summary>
    public required string MerchantPostalCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("merchant_postal_code");
        }
        init { this._rawBodyData.Set("merchant_postal_code", value); }
    }

    /// <summary>
    /// The state of the merchant (generally your business) sending the transfer.
    /// </summary>
    public required string MerchantState
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("merchant_state");
        }
        init { this._rawBodyData.Set("merchant_state", value); }
    }

    /// <summary>
    /// The amount to transfer. The receiving bank will convert this to the cardholder's
    /// currency. The amount that is applied to your Increase account matches the
    /// currency of your account.
    /// </summary>
    public required PresentmentAmount PresentmentAmount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<PresentmentAmount>("presentment_amount");
        }
        init { this._rawBodyData.Set("presentment_amount", value); }
    }

    /// <summary>
    /// The name of the funds recipient.
    /// </summary>
    public required string RecipientName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("recipient_name");
        }
        init { this._rawBodyData.Set("recipient_name", value); }
    }

    /// <summary>
    /// The city of the sender.
    /// </summary>
    public required string SenderAddressCity
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("sender_address_city");
        }
        init { this._rawBodyData.Set("sender_address_city", value); }
    }

    /// <summary>
    /// The address line 1 of the sender.
    /// </summary>
    public required string SenderAddressLine1
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("sender_address_line1");
        }
        init { this._rawBodyData.Set("sender_address_line1", value); }
    }

    /// <summary>
    /// The postal code of the sender.
    /// </summary>
    public required string SenderAddressPostalCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("sender_address_postal_code");
        }
        init { this._rawBodyData.Set("sender_address_postal_code", value); }
    }

    /// <summary>
    /// The state of the sender.
    /// </summary>
    public required string SenderAddressState
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("sender_address_state");
        }
        init { this._rawBodyData.Set("sender_address_state", value); }
    }

    /// <summary>
    /// The name of the funds originator.
    /// </summary>
    public required string SenderName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("sender_name");
        }
        init { this._rawBodyData.Set("sender_name", value); }
    }

    /// <summary>
    /// The identifier of the Account Number from which to send the transfer.
    /// </summary>
    public required string SourceAccountNumberID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("source_account_number_id");
        }
        init { this._rawBodyData.Set("source_account_number_id", value); }
    }

    /// <summary>
    /// The legal business name of the merchant (generally your business) sending
    /// the transfer. Required if the card is issued in Canada.
    /// </summary>
    public string? MerchantLegalBusinessName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("merchant_legal_business_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("merchant_legal_business_name", value);
        }
    }

    /// <summary>
    /// The street address of the merchant (generally your business) sending the transfer.
    /// Required if the card is issued in Canada.
    /// </summary>
    public string? MerchantStreetAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("merchant_street_address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("merchant_street_address", value);
        }
    }

    /// <summary>
    /// The city of the recipient. Required if the card is issued in Canada.
    /// </summary>
    public string? RecipientAddressCity
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("recipient_address_city");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("recipient_address_city", value);
        }
    }

    /// <summary>
    /// The first line of the recipient's address. Required if the card is issued
    /// in Canada.
    /// </summary>
    public string? RecipientAddressLine1
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("recipient_address_line1");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("recipient_address_line1", value);
        }
    }

    /// <summary>
    /// The postal code of the recipient. Required if the card is issued in Canada.
    /// </summary>
    public string? RecipientAddressPostalCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("recipient_address_postal_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("recipient_address_postal_code", value);
        }
    }

    /// <summary>
    /// The state or province of the recipient. Required if the card is issued in Canada.
    /// </summary>
    public string? RecipientAddressState
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("recipient_address_state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("recipient_address_state", value);
        }
    }

    /// <summary>
    /// Whether the transfer requires explicit approval via the dashboard or API.
    /// </summary>
    public bool? RequireApproval
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("require_approval");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("require_approval", value);
        }
    }

    public CardPushTransferCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardPushTransferCreateParams(CardPushTransferCreateParams cardPushTransferCreateParams)
        : base(cardPushTransferCreateParams)
    {
        this._rawBodyData = new(cardPushTransferCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CardPushTransferCreateParams(
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
    CardPushTransferCreateParams(
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
    public static CardPushTransferCreateParams FromRawUnchecked(
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

    public virtual bool Equals(CardPushTransferCreateParams? other)
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
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/card_push_transfers"
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
/// The Business Application Identifier describes the type of transaction being performed.
/// Your program must be approved for the specified Business Application Identifier
/// in order to use it.
/// </summary>
[JsonConverter(typeof(BusinessApplicationIdentifierConverter))]
public enum BusinessApplicationIdentifier
{
    /// <summary>
    /// Account to Account
    /// </summary>
    AccountToAccount,

    /// <summary>
    /// Business to Business
    /// </summary>
    BusinessToBusiness,

    /// <summary>
    /// Money Transfer Bank Initiated
    /// </summary>
    MoneyTransferBankInitiated,

    /// <summary>
    /// Non-Card Bill Payment
    /// </summary>
    NonCardBillPayment,

    /// <summary>
    /// Consumer Bill Payment
    /// </summary>
    ConsumerBillPayment,

    /// <summary>
    /// Card Bill Payment
    /// </summary>
    CardBillPayment,

    /// <summary>
    /// Funds Disbursement
    /// </summary>
    FundsDisbursement,

    /// <summary>
    /// Funds Transfer
    /// </summary>
    FundsTransfer,

    /// <summary>
    /// Loyalty and Offers
    /// </summary>
    LoyaltyAndOffers,

    /// <summary>
    /// Merchant Disbursement
    /// </summary>
    MerchantDisbursement,

    /// <summary>
    /// Merchant Payment
    /// </summary>
    MerchantPayment,

    /// <summary>
    /// Person to Person
    /// </summary>
    PersonToPerson,

    /// <summary>
    /// Top Up
    /// </summary>
    TopUp,

    /// <summary>
    /// Wallet Transfer
    /// </summary>
    WalletTransfer,
}

sealed class BusinessApplicationIdentifierConverter : JsonConverter<BusinessApplicationIdentifier>
{
    public override BusinessApplicationIdentifier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_to_account" => BusinessApplicationIdentifier.AccountToAccount,
            "business_to_business" => BusinessApplicationIdentifier.BusinessToBusiness,
            "money_transfer_bank_initiated" =>
                BusinessApplicationIdentifier.MoneyTransferBankInitiated,
            "non_card_bill_payment" => BusinessApplicationIdentifier.NonCardBillPayment,
            "consumer_bill_payment" => BusinessApplicationIdentifier.ConsumerBillPayment,
            "card_bill_payment" => BusinessApplicationIdentifier.CardBillPayment,
            "funds_disbursement" => BusinessApplicationIdentifier.FundsDisbursement,
            "funds_transfer" => BusinessApplicationIdentifier.FundsTransfer,
            "loyalty_and_offers" => BusinessApplicationIdentifier.LoyaltyAndOffers,
            "merchant_disbursement" => BusinessApplicationIdentifier.MerchantDisbursement,
            "merchant_payment" => BusinessApplicationIdentifier.MerchantPayment,
            "person_to_person" => BusinessApplicationIdentifier.PersonToPerson,
            "top_up" => BusinessApplicationIdentifier.TopUp,
            "wallet_transfer" => BusinessApplicationIdentifier.WalletTransfer,
            _ => (BusinessApplicationIdentifier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BusinessApplicationIdentifier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BusinessApplicationIdentifier.AccountToAccount => "account_to_account",
                BusinessApplicationIdentifier.BusinessToBusiness => "business_to_business",
                BusinessApplicationIdentifier.MoneyTransferBankInitiated =>
                    "money_transfer_bank_initiated",
                BusinessApplicationIdentifier.NonCardBillPayment => "non_card_bill_payment",
                BusinessApplicationIdentifier.ConsumerBillPayment => "consumer_bill_payment",
                BusinessApplicationIdentifier.CardBillPayment => "card_bill_payment",
                BusinessApplicationIdentifier.FundsDisbursement => "funds_disbursement",
                BusinessApplicationIdentifier.FundsTransfer => "funds_transfer",
                BusinessApplicationIdentifier.LoyaltyAndOffers => "loyalty_and_offers",
                BusinessApplicationIdentifier.MerchantDisbursement => "merchant_disbursement",
                BusinessApplicationIdentifier.MerchantPayment => "merchant_payment",
                BusinessApplicationIdentifier.PersonToPerson => "person_to_person",
                BusinessApplicationIdentifier.TopUp => "top_up",
                BusinessApplicationIdentifier.WalletTransfer => "wallet_transfer",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The amount to transfer. The receiving bank will convert this to the cardholder's
/// currency. The amount that is applied to your Increase account matches the currency
/// of your account.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PresentmentAmount, PresentmentAmountFromRaw>))]
public sealed record class PresentmentAmount : JsonModel
{
    /// <summary>
    /// The ISO 4217 currency code representing the currency of the amount.
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
    /// The amount value as a decimal string in the currency's major unit. For example,
    /// for USD, '1234.56' represents 1234 dollars and 56 cents. For JPY, '1234'
    /// represents 1234 yen. A currency with minor units requires at least one decimal
    /// place and supports up to the number of decimal places defined by the currency's
    /// minor units. A currency without minor units does not support any decimal places.
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Currency.Validate();
        _ = this.Value;
    }

    public PresentmentAmount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PresentmentAmount(PresentmentAmount presentmentAmount)
        : base(presentmentAmount) { }
#pragma warning restore CS8618

    public PresentmentAmount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PresentmentAmount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PresentmentAmountFromRaw.FromRawUnchecked"/>
    public static PresentmentAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PresentmentAmountFromRaw : IFromRawJson<PresentmentAmount>
{
    /// <inheritdoc/>
    public PresentmentAmount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PresentmentAmount.FromRawUnchecked(rawData);
}

/// <summary>
/// The ISO 4217 currency code representing the currency of the amount.
/// </summary>
[JsonConverter(typeof(CurrencyConverter))]
public enum Currency
{
    /// <summary>
    /// AFN
    /// </summary>
    Afn,

    /// <summary>
    /// EUR
    /// </summary>
    Eur,

    /// <summary>
    /// ALL
    /// </summary>
    All,

    /// <summary>
    /// DZD
    /// </summary>
    Dzd,

    /// <summary>
    /// USD
    /// </summary>
    Usd,

    /// <summary>
    /// AOA
    /// </summary>
    Aoa,

    /// <summary>
    /// ARS
    /// </summary>
    Ars,

    /// <summary>
    /// AMD
    /// </summary>
    Amd,

    /// <summary>
    /// AWG
    /// </summary>
    Awg,

    /// <summary>
    /// AUD
    /// </summary>
    Aud,

    /// <summary>
    /// AZN
    /// </summary>
    Azn,

    /// <summary>
    /// BSD
    /// </summary>
    Bsd,

    /// <summary>
    /// BHD
    /// </summary>
    Bhd,

    /// <summary>
    /// BDT
    /// </summary>
    Bdt,

    /// <summary>
    /// BBD
    /// </summary>
    Bbd,

    /// <summary>
    /// BYN
    /// </summary>
    Byn,

    /// <summary>
    /// BZD
    /// </summary>
    Bzd,

    /// <summary>
    /// BMD
    /// </summary>
    Bmd,

    /// <summary>
    /// INR
    /// </summary>
    Inr,

    /// <summary>
    /// BTN
    /// </summary>
    Btn,

    /// <summary>
    /// BOB
    /// </summary>
    Bob,

    /// <summary>
    /// BOV
    /// </summary>
    Bov,

    /// <summary>
    /// BAM
    /// </summary>
    Bam,

    /// <summary>
    /// BWP
    /// </summary>
    Bwp,

    /// <summary>
    /// NOK
    /// </summary>
    Nok,

    /// <summary>
    /// BRL
    /// </summary>
    Brl,

    /// <summary>
    /// BND
    /// </summary>
    Bnd,

    /// <summary>
    /// BGN
    /// </summary>
    Bgn,

    /// <summary>
    /// BIF
    /// </summary>
    Bif,

    /// <summary>
    /// CVE
    /// </summary>
    Cve,

    /// <summary>
    /// KHR
    /// </summary>
    Khr,

    /// <summary>
    /// CAD
    /// </summary>
    Cad,

    /// <summary>
    /// KYD
    /// </summary>
    Kyd,

    /// <summary>
    /// CLP
    /// </summary>
    Clp,

    /// <summary>
    /// CLF
    /// </summary>
    Clf,

    /// <summary>
    /// CNY
    /// </summary>
    Cny,

    /// <summary>
    /// COP
    /// </summary>
    Cop,

    /// <summary>
    /// COU
    /// </summary>
    Cou,

    /// <summary>
    /// KMF
    /// </summary>
    Kmf,

    /// <summary>
    /// CDF
    /// </summary>
    Cdf,

    /// <summary>
    /// NZD
    /// </summary>
    Nzd,

    /// <summary>
    /// CRC
    /// </summary>
    Crc,

    /// <summary>
    /// CUP
    /// </summary>
    Cup,

    /// <summary>
    /// CZK
    /// </summary>
    Czk,

    /// <summary>
    /// DKK
    /// </summary>
    Dkk,

    /// <summary>
    /// DJF
    /// </summary>
    Djf,

    /// <summary>
    /// DOP
    /// </summary>
    Dop,

    /// <summary>
    /// EGP
    /// </summary>
    Egp,

    /// <summary>
    /// SVC
    /// </summary>
    Svc,

    /// <summary>
    /// ERN
    /// </summary>
    Ern,

    /// <summary>
    /// SZL
    /// </summary>
    Szl,

    /// <summary>
    /// ETB
    /// </summary>
    Etb,

    /// <summary>
    /// FKP
    /// </summary>
    Fkp,

    /// <summary>
    /// FJD
    /// </summary>
    Fjd,

    /// <summary>
    /// GMD
    /// </summary>
    Gmd,

    /// <summary>
    /// GEL
    /// </summary>
    Gel,

    /// <summary>
    /// GHS
    /// </summary>
    Ghs,

    /// <summary>
    /// GIP
    /// </summary>
    Gip,

    /// <summary>
    /// GTQ
    /// </summary>
    Gtq,

    /// <summary>
    /// GBP
    /// </summary>
    Gbp,

    /// <summary>
    /// GNF
    /// </summary>
    Gnf,

    /// <summary>
    /// GYD
    /// </summary>
    Gyd,

    /// <summary>
    /// HTG
    /// </summary>
    Htg,

    /// <summary>
    /// HNL
    /// </summary>
    Hnl,

    /// <summary>
    /// HKD
    /// </summary>
    Hkd,

    /// <summary>
    /// HUF
    /// </summary>
    Huf,

    /// <summary>
    /// ISK
    /// </summary>
    Isk,

    /// <summary>
    /// IDR
    /// </summary>
    Idr,

    /// <summary>
    /// IRR
    /// </summary>
    Irr,

    /// <summary>
    /// IQD
    /// </summary>
    Iqd,

    /// <summary>
    /// ILS
    /// </summary>
    Ils,

    /// <summary>
    /// JMD
    /// </summary>
    Jmd,

    /// <summary>
    /// JPY
    /// </summary>
    Jpy,

    /// <summary>
    /// JOD
    /// </summary>
    Jod,

    /// <summary>
    /// KZT
    /// </summary>
    Kzt,

    /// <summary>
    /// KES
    /// </summary>
    Kes,

    /// <summary>
    /// KPW
    /// </summary>
    Kpw,

    /// <summary>
    /// KRW
    /// </summary>
    Krw,

    /// <summary>
    /// KWD
    /// </summary>
    Kwd,

    /// <summary>
    /// KGS
    /// </summary>
    Kgs,

    /// <summary>
    /// LAK
    /// </summary>
    Lak,

    /// <summary>
    /// LBP
    /// </summary>
    Lbp,

    /// <summary>
    /// LSL
    /// </summary>
    Lsl,

    /// <summary>
    /// ZAR
    /// </summary>
    Zar,

    /// <summary>
    /// LRD
    /// </summary>
    Lrd,

    /// <summary>
    /// LYD
    /// </summary>
    Lyd,

    /// <summary>
    /// CHF
    /// </summary>
    Chf,

    /// <summary>
    /// MOP
    /// </summary>
    Mop,

    /// <summary>
    /// MKD
    /// </summary>
    Mkd,

    /// <summary>
    /// MGA
    /// </summary>
    Mga,

    /// <summary>
    /// MWK
    /// </summary>
    Mwk,

    /// <summary>
    /// MYR
    /// </summary>
    Myr,

    /// <summary>
    /// MVR
    /// </summary>
    Mvr,

    /// <summary>
    /// MRU
    /// </summary>
    Mru,

    /// <summary>
    /// MUR
    /// </summary>
    Mur,

    /// <summary>
    /// MXN
    /// </summary>
    Mxn,

    /// <summary>
    /// MXV
    /// </summary>
    Mxv,

    /// <summary>
    /// MDL
    /// </summary>
    Mdl,

    /// <summary>
    /// MNT
    /// </summary>
    Mnt,

    /// <summary>
    /// MAD
    /// </summary>
    Mad,

    /// <summary>
    /// MZN
    /// </summary>
    Mzn,

    /// <summary>
    /// MMK
    /// </summary>
    Mmk,

    /// <summary>
    /// NAD
    /// </summary>
    Nad,

    /// <summary>
    /// NPR
    /// </summary>
    Npr,

    /// <summary>
    /// NIO
    /// </summary>
    Nio,

    /// <summary>
    /// NGN
    /// </summary>
    Ngn,

    /// <summary>
    /// OMR
    /// </summary>
    Omr,

    /// <summary>
    /// PKR
    /// </summary>
    Pkr,

    /// <summary>
    /// PAB
    /// </summary>
    Pab,

    /// <summary>
    /// PGK
    /// </summary>
    Pgk,

    /// <summary>
    /// PYG
    /// </summary>
    Pyg,

    /// <summary>
    /// PEN
    /// </summary>
    Pen,

    /// <summary>
    /// PHP
    /// </summary>
    Php,

    /// <summary>
    /// PLN
    /// </summary>
    Pln,

    /// <summary>
    /// QAR
    /// </summary>
    Qar,

    /// <summary>
    /// RON
    /// </summary>
    Ron,

    /// <summary>
    /// RUB
    /// </summary>
    Rub,

    /// <summary>
    /// RWF
    /// </summary>
    Rwf,

    /// <summary>
    /// SHP
    /// </summary>
    Shp,

    /// <summary>
    /// WST
    /// </summary>
    Wst,

    /// <summary>
    /// STN
    /// </summary>
    Stn,

    /// <summary>
    /// SAR
    /// </summary>
    Sar,

    /// <summary>
    /// RSD
    /// </summary>
    Rsd,

    /// <summary>
    /// SCR
    /// </summary>
    Scr,

    /// <summary>
    /// SLE
    /// </summary>
    Sle,

    /// <summary>
    /// SGD
    /// </summary>
    Sgd,

    /// <summary>
    /// SBD
    /// </summary>
    Sbd,

    /// <summary>
    /// SOS
    /// </summary>
    Sos,

    /// <summary>
    /// SSP
    /// </summary>
    Ssp,

    /// <summary>
    /// LKR
    /// </summary>
    Lkr,

    /// <summary>
    /// SDG
    /// </summary>
    Sdg,

    /// <summary>
    /// SRD
    /// </summary>
    Srd,

    /// <summary>
    /// SEK
    /// </summary>
    Sek,

    /// <summary>
    /// CHE
    /// </summary>
    Che,

    /// <summary>
    /// CHW
    /// </summary>
    Chw,

    /// <summary>
    /// SYP
    /// </summary>
    Syp,

    /// <summary>
    /// TWD
    /// </summary>
    Twd,

    /// <summary>
    /// TJS
    /// </summary>
    Tjs,

    /// <summary>
    /// TZS
    /// </summary>
    Tzs,

    /// <summary>
    /// THB
    /// </summary>
    Thb,

    /// <summary>
    /// TOP
    /// </summary>
    Top,

    /// <summary>
    /// TTD
    /// </summary>
    Ttd,

    /// <summary>
    /// TND
    /// </summary>
    Tnd,

    /// <summary>
    /// TRY
    /// </summary>
    Try,

    /// <summary>
    /// TMT
    /// </summary>
    Tmt,

    /// <summary>
    /// UGX
    /// </summary>
    Ugx,

    /// <summary>
    /// UAH
    /// </summary>
    Uah,

    /// <summary>
    /// AED
    /// </summary>
    Aed,

    /// <summary>
    /// USN
    /// </summary>
    Usn,

    /// <summary>
    /// UYU
    /// </summary>
    Uyu,

    /// <summary>
    /// UYI
    /// </summary>
    Uyi,

    /// <summary>
    /// UYW
    /// </summary>
    Uyw,

    /// <summary>
    /// UZS
    /// </summary>
    Uzs,

    /// <summary>
    /// VUV
    /// </summary>
    Vuv,

    /// <summary>
    /// VES
    /// </summary>
    Ves,

    /// <summary>
    /// VED
    /// </summary>
    Ved,

    /// <summary>
    /// VND
    /// </summary>
    Vnd,

    /// <summary>
    /// YER
    /// </summary>
    Yer,

    /// <summary>
    /// ZMW
    /// </summary>
    Zmw,

    /// <summary>
    /// ZWG
    /// </summary>
    Zwg,
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
            "AFN" => Currency.Afn,
            "EUR" => Currency.Eur,
            "ALL" => Currency.All,
            "DZD" => Currency.Dzd,
            "USD" => Currency.Usd,
            "AOA" => Currency.Aoa,
            "ARS" => Currency.Ars,
            "AMD" => Currency.Amd,
            "AWG" => Currency.Awg,
            "AUD" => Currency.Aud,
            "AZN" => Currency.Azn,
            "BSD" => Currency.Bsd,
            "BHD" => Currency.Bhd,
            "BDT" => Currency.Bdt,
            "BBD" => Currency.Bbd,
            "BYN" => Currency.Byn,
            "BZD" => Currency.Bzd,
            "BMD" => Currency.Bmd,
            "INR" => Currency.Inr,
            "BTN" => Currency.Btn,
            "BOB" => Currency.Bob,
            "BOV" => Currency.Bov,
            "BAM" => Currency.Bam,
            "BWP" => Currency.Bwp,
            "NOK" => Currency.Nok,
            "BRL" => Currency.Brl,
            "BND" => Currency.Bnd,
            "BGN" => Currency.Bgn,
            "BIF" => Currency.Bif,
            "CVE" => Currency.Cve,
            "KHR" => Currency.Khr,
            "CAD" => Currency.Cad,
            "KYD" => Currency.Kyd,
            "CLP" => Currency.Clp,
            "CLF" => Currency.Clf,
            "CNY" => Currency.Cny,
            "COP" => Currency.Cop,
            "COU" => Currency.Cou,
            "KMF" => Currency.Kmf,
            "CDF" => Currency.Cdf,
            "NZD" => Currency.Nzd,
            "CRC" => Currency.Crc,
            "CUP" => Currency.Cup,
            "CZK" => Currency.Czk,
            "DKK" => Currency.Dkk,
            "DJF" => Currency.Djf,
            "DOP" => Currency.Dop,
            "EGP" => Currency.Egp,
            "SVC" => Currency.Svc,
            "ERN" => Currency.Ern,
            "SZL" => Currency.Szl,
            "ETB" => Currency.Etb,
            "FKP" => Currency.Fkp,
            "FJD" => Currency.Fjd,
            "GMD" => Currency.Gmd,
            "GEL" => Currency.Gel,
            "GHS" => Currency.Ghs,
            "GIP" => Currency.Gip,
            "GTQ" => Currency.Gtq,
            "GBP" => Currency.Gbp,
            "GNF" => Currency.Gnf,
            "GYD" => Currency.Gyd,
            "HTG" => Currency.Htg,
            "HNL" => Currency.Hnl,
            "HKD" => Currency.Hkd,
            "HUF" => Currency.Huf,
            "ISK" => Currency.Isk,
            "IDR" => Currency.Idr,
            "IRR" => Currency.Irr,
            "IQD" => Currency.Iqd,
            "ILS" => Currency.Ils,
            "JMD" => Currency.Jmd,
            "JPY" => Currency.Jpy,
            "JOD" => Currency.Jod,
            "KZT" => Currency.Kzt,
            "KES" => Currency.Kes,
            "KPW" => Currency.Kpw,
            "KRW" => Currency.Krw,
            "KWD" => Currency.Kwd,
            "KGS" => Currency.Kgs,
            "LAK" => Currency.Lak,
            "LBP" => Currency.Lbp,
            "LSL" => Currency.Lsl,
            "ZAR" => Currency.Zar,
            "LRD" => Currency.Lrd,
            "LYD" => Currency.Lyd,
            "CHF" => Currency.Chf,
            "MOP" => Currency.Mop,
            "MKD" => Currency.Mkd,
            "MGA" => Currency.Mga,
            "MWK" => Currency.Mwk,
            "MYR" => Currency.Myr,
            "MVR" => Currency.Mvr,
            "MRU" => Currency.Mru,
            "MUR" => Currency.Mur,
            "MXN" => Currency.Mxn,
            "MXV" => Currency.Mxv,
            "MDL" => Currency.Mdl,
            "MNT" => Currency.Mnt,
            "MAD" => Currency.Mad,
            "MZN" => Currency.Mzn,
            "MMK" => Currency.Mmk,
            "NAD" => Currency.Nad,
            "NPR" => Currency.Npr,
            "NIO" => Currency.Nio,
            "NGN" => Currency.Ngn,
            "OMR" => Currency.Omr,
            "PKR" => Currency.Pkr,
            "PAB" => Currency.Pab,
            "PGK" => Currency.Pgk,
            "PYG" => Currency.Pyg,
            "PEN" => Currency.Pen,
            "PHP" => Currency.Php,
            "PLN" => Currency.Pln,
            "QAR" => Currency.Qar,
            "RON" => Currency.Ron,
            "RUB" => Currency.Rub,
            "RWF" => Currency.Rwf,
            "SHP" => Currency.Shp,
            "WST" => Currency.Wst,
            "STN" => Currency.Stn,
            "SAR" => Currency.Sar,
            "RSD" => Currency.Rsd,
            "SCR" => Currency.Scr,
            "SLE" => Currency.Sle,
            "SGD" => Currency.Sgd,
            "SBD" => Currency.Sbd,
            "SOS" => Currency.Sos,
            "SSP" => Currency.Ssp,
            "LKR" => Currency.Lkr,
            "SDG" => Currency.Sdg,
            "SRD" => Currency.Srd,
            "SEK" => Currency.Sek,
            "CHE" => Currency.Che,
            "CHW" => Currency.Chw,
            "SYP" => Currency.Syp,
            "TWD" => Currency.Twd,
            "TJS" => Currency.Tjs,
            "TZS" => Currency.Tzs,
            "THB" => Currency.Thb,
            "TOP" => Currency.Top,
            "TTD" => Currency.Ttd,
            "TND" => Currency.Tnd,
            "TRY" => Currency.Try,
            "TMT" => Currency.Tmt,
            "UGX" => Currency.Ugx,
            "UAH" => Currency.Uah,
            "AED" => Currency.Aed,
            "USN" => Currency.Usn,
            "UYU" => Currency.Uyu,
            "UYI" => Currency.Uyi,
            "UYW" => Currency.Uyw,
            "UZS" => Currency.Uzs,
            "VUV" => Currency.Vuv,
            "VES" => Currency.Ves,
            "VED" => Currency.Ved,
            "VND" => Currency.Vnd,
            "YER" => Currency.Yer,
            "ZMW" => Currency.Zmw,
            "ZWG" => Currency.Zwg,
            _ => (Currency)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Currency.Afn => "AFN",
                Currency.Eur => "EUR",
                Currency.All => "ALL",
                Currency.Dzd => "DZD",
                Currency.Usd => "USD",
                Currency.Aoa => "AOA",
                Currency.Ars => "ARS",
                Currency.Amd => "AMD",
                Currency.Awg => "AWG",
                Currency.Aud => "AUD",
                Currency.Azn => "AZN",
                Currency.Bsd => "BSD",
                Currency.Bhd => "BHD",
                Currency.Bdt => "BDT",
                Currency.Bbd => "BBD",
                Currency.Byn => "BYN",
                Currency.Bzd => "BZD",
                Currency.Bmd => "BMD",
                Currency.Inr => "INR",
                Currency.Btn => "BTN",
                Currency.Bob => "BOB",
                Currency.Bov => "BOV",
                Currency.Bam => "BAM",
                Currency.Bwp => "BWP",
                Currency.Nok => "NOK",
                Currency.Brl => "BRL",
                Currency.Bnd => "BND",
                Currency.Bgn => "BGN",
                Currency.Bif => "BIF",
                Currency.Cve => "CVE",
                Currency.Khr => "KHR",
                Currency.Cad => "CAD",
                Currency.Kyd => "KYD",
                Currency.Clp => "CLP",
                Currency.Clf => "CLF",
                Currency.Cny => "CNY",
                Currency.Cop => "COP",
                Currency.Cou => "COU",
                Currency.Kmf => "KMF",
                Currency.Cdf => "CDF",
                Currency.Nzd => "NZD",
                Currency.Crc => "CRC",
                Currency.Cup => "CUP",
                Currency.Czk => "CZK",
                Currency.Dkk => "DKK",
                Currency.Djf => "DJF",
                Currency.Dop => "DOP",
                Currency.Egp => "EGP",
                Currency.Svc => "SVC",
                Currency.Ern => "ERN",
                Currency.Szl => "SZL",
                Currency.Etb => "ETB",
                Currency.Fkp => "FKP",
                Currency.Fjd => "FJD",
                Currency.Gmd => "GMD",
                Currency.Gel => "GEL",
                Currency.Ghs => "GHS",
                Currency.Gip => "GIP",
                Currency.Gtq => "GTQ",
                Currency.Gbp => "GBP",
                Currency.Gnf => "GNF",
                Currency.Gyd => "GYD",
                Currency.Htg => "HTG",
                Currency.Hnl => "HNL",
                Currency.Hkd => "HKD",
                Currency.Huf => "HUF",
                Currency.Isk => "ISK",
                Currency.Idr => "IDR",
                Currency.Irr => "IRR",
                Currency.Iqd => "IQD",
                Currency.Ils => "ILS",
                Currency.Jmd => "JMD",
                Currency.Jpy => "JPY",
                Currency.Jod => "JOD",
                Currency.Kzt => "KZT",
                Currency.Kes => "KES",
                Currency.Kpw => "KPW",
                Currency.Krw => "KRW",
                Currency.Kwd => "KWD",
                Currency.Kgs => "KGS",
                Currency.Lak => "LAK",
                Currency.Lbp => "LBP",
                Currency.Lsl => "LSL",
                Currency.Zar => "ZAR",
                Currency.Lrd => "LRD",
                Currency.Lyd => "LYD",
                Currency.Chf => "CHF",
                Currency.Mop => "MOP",
                Currency.Mkd => "MKD",
                Currency.Mga => "MGA",
                Currency.Mwk => "MWK",
                Currency.Myr => "MYR",
                Currency.Mvr => "MVR",
                Currency.Mru => "MRU",
                Currency.Mur => "MUR",
                Currency.Mxn => "MXN",
                Currency.Mxv => "MXV",
                Currency.Mdl => "MDL",
                Currency.Mnt => "MNT",
                Currency.Mad => "MAD",
                Currency.Mzn => "MZN",
                Currency.Mmk => "MMK",
                Currency.Nad => "NAD",
                Currency.Npr => "NPR",
                Currency.Nio => "NIO",
                Currency.Ngn => "NGN",
                Currency.Omr => "OMR",
                Currency.Pkr => "PKR",
                Currency.Pab => "PAB",
                Currency.Pgk => "PGK",
                Currency.Pyg => "PYG",
                Currency.Pen => "PEN",
                Currency.Php => "PHP",
                Currency.Pln => "PLN",
                Currency.Qar => "QAR",
                Currency.Ron => "RON",
                Currency.Rub => "RUB",
                Currency.Rwf => "RWF",
                Currency.Shp => "SHP",
                Currency.Wst => "WST",
                Currency.Stn => "STN",
                Currency.Sar => "SAR",
                Currency.Rsd => "RSD",
                Currency.Scr => "SCR",
                Currency.Sle => "SLE",
                Currency.Sgd => "SGD",
                Currency.Sbd => "SBD",
                Currency.Sos => "SOS",
                Currency.Ssp => "SSP",
                Currency.Lkr => "LKR",
                Currency.Sdg => "SDG",
                Currency.Srd => "SRD",
                Currency.Sek => "SEK",
                Currency.Che => "CHE",
                Currency.Chw => "CHW",
                Currency.Syp => "SYP",
                Currency.Twd => "TWD",
                Currency.Tjs => "TJS",
                Currency.Tzs => "TZS",
                Currency.Thb => "THB",
                Currency.Top => "TOP",
                Currency.Ttd => "TTD",
                Currency.Tnd => "TND",
                Currency.Try => "TRY",
                Currency.Tmt => "TMT",
                Currency.Ugx => "UGX",
                Currency.Uah => "UAH",
                Currency.Aed => "AED",
                Currency.Usn => "USN",
                Currency.Uyu => "UYU",
                Currency.Uyi => "UYI",
                Currency.Uyw => "UYW",
                Currency.Uzs => "UZS",
                Currency.Vuv => "VUV",
                Currency.Ves => "VES",
                Currency.Ved => "VED",
                Currency.Vnd => "VND",
                Currency.Yer => "YER",
                Currency.Zmw => "ZMW",
                Currency.Zwg => "ZWG",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
