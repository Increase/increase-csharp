using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.CardPushTransfers;

/// <summary>
/// Card Push Transfers send funds to a recipient's payment card in real-time.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardPushTransfer, CardPushTransferFromRaw>))]
public sealed record class CardPushTransfer : JsonModel
{
    /// <summary>
    /// The Card Push Transfer's identifier.
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
    /// If the transfer is accepted by the recipient bank, this will contain supplemental details.
    /// </summary>
    public required Acceptance? Acceptance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Acceptance>("acceptance");
        }
        init { this._rawData.Set("acceptance", value); }
    }

    /// <summary>
    /// The Account from which the transfer was sent.
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
    /// If your account requires approvals for transfers and the transfer was approved,
    /// this will contain details of the approval.
    /// </summary>
    public required Approval? Approval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Approval>("approval");
        }
        init { this._rawData.Set("approval", value); }
    }

    /// <summary>
    /// The Business Application Identifier describes the type of transaction being
    /// performed. Your program must be approved for the specified Business Application
    /// Identifier in order to use it.
    /// </summary>
    public required ApiEnum<
        string,
        CardPushTransferBusinessApplicationIdentifier
    > BusinessApplicationIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardPushTransferBusinessApplicationIdentifier>
            >("business_application_identifier");
        }
        init { this._rawData.Set("business_application_identifier", value); }
    }

    /// <summary>
    /// If your account requires approvals for transfers and the transfer was not
    /// approved, this will contain details of the cancellation.
    /// </summary>
    public required Cancellation? Cancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Cancellation>("cancellation");
        }
        init { this._rawData.Set("cancellation", value); }
    }

    /// <summary>
    /// The ID of the Card Token that was used to validate the card.
    /// </summary>
    public required string CardTokenID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("card_token_id");
        }
        init { this._rawData.Set("card_token_id", value); }
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
    /// What object created the transfer, either via the API or the dashboard.
    /// </summary>
    public required CreatedBy? CreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreatedBy>("created_by");
        }
        init { this._rawData.Set("created_by", value); }
    }

    /// <summary>
    /// If the transfer is rejected by the card network or the destination financial
    /// institution, this will contain supplemental details.
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
    /// The merchant category code (MCC) of the merchant (generally your business)
    /// sending the transfer. This is a four-digit code that describes the type of
    /// business or service provided by the merchant. Your program must be approved
    /// for the specified MCC in order to use it.
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
    /// The city name of the merchant (generally your business) sending the transfer.
    /// </summary>
    public required string MerchantCityName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_city_name");
        }
        init { this._rawData.Set("merchant_city_name", value); }
    }

    /// <summary>
    /// The merchant name shows up as the statement descriptor for the transfer.
    /// This is typically the name of your business or organization.
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
    /// For certain Business Application Identifiers, the statement descriptor is
    /// `merchant_name_prefix*sender_name`, where the `merchant_name_prefix` is a
    /// one to four character prefix that identifies the merchant.
    /// </summary>
    public required string MerchantNamePrefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_name_prefix");
        }
        init { this._rawData.Set("merchant_name_prefix", value); }
    }

    /// <summary>
    /// The postal code of the merchant (generally your business) sending the transfer.
    /// </summary>
    public required string MerchantPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_postal_code");
        }
        init { this._rawData.Set("merchant_postal_code", value); }
    }

    /// <summary>
    /// The state of the merchant (generally your business) sending the transfer.
    /// </summary>
    public required string MerchantState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("merchant_state");
        }
        init { this._rawData.Set("merchant_state", value); }
    }

    /// <summary>
    /// The amount that was transferred. The receiving bank will have converted this
    /// to the cardholder's currency. The amount that is applied to your Increase
    /// account matches the currency of your account.
    /// </summary>
    public required CardPushTransferPresentmentAmount PresentmentAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardPushTransferPresentmentAmount>(
                "presentment_amount"
            );
        }
        init { this._rawData.Set("presentment_amount", value); }
    }

    /// <summary>
    /// The name of the funds recipient.
    /// </summary>
    public required string RecipientName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("recipient_name");
        }
        init { this._rawData.Set("recipient_name", value); }
    }

    /// <summary>
    /// The card network route used for the transfer.
    /// </summary>
    public required ApiEnum<string, Route> Route
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Route>>("route");
        }
        init { this._rawData.Set("route", value); }
    }

    /// <summary>
    /// The city of the sender.
    /// </summary>
    public required string SenderAddressCity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sender_address_city");
        }
        init { this._rawData.Set("sender_address_city", value); }
    }

    /// <summary>
    /// The address line 1 of the sender.
    /// </summary>
    public required string SenderAddressLine1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sender_address_line1");
        }
        init { this._rawData.Set("sender_address_line1", value); }
    }

    /// <summary>
    /// The postal code of the sender.
    /// </summary>
    public required string SenderAddressPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sender_address_postal_code");
        }
        init { this._rawData.Set("sender_address_postal_code", value); }
    }

    /// <summary>
    /// The state of the sender.
    /// </summary>
    public required string SenderAddressState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sender_address_state");
        }
        init { this._rawData.Set("sender_address_state", value); }
    }

    /// <summary>
    /// The name of the funds originator.
    /// </summary>
    public required string SenderName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sender_name");
        }
        init { this._rawData.Set("sender_name", value); }
    }

    /// <summary>
    /// The Account Number the recipient will see as having sent the transfer.
    /// </summary>
    public required string SourceAccountNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source_account_number_id");
        }
        init { this._rawData.Set("source_account_number_id", value); }
    }

    /// <summary>
    /// The lifecycle status of the transfer.
    /// </summary>
    public required ApiEnum<string, CardPushTransferStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardPushTransferStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// After the transfer is submitted to the card network, this will contain supplemental details.
    /// </summary>
    public required Submission? Submission
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Submission>("submission");
        }
        init { this._rawData.Set("submission", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `card_push_transfer`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.CardPushTransfers.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.CardPushTransfers.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Acceptance?.Validate();
        _ = this.AccountID;
        this.Approval?.Validate();
        this.BusinessApplicationIdentifier.Validate();
        this.Cancellation?.Validate();
        _ = this.CardTokenID;
        _ = this.CreatedAt;
        this.CreatedBy?.Validate();
        this.Decline?.Validate();
        _ = this.IdempotencyKey;
        _ = this.MerchantCategoryCode;
        _ = this.MerchantCityName;
        _ = this.MerchantName;
        _ = this.MerchantNamePrefix;
        _ = this.MerchantPostalCode;
        _ = this.MerchantState;
        this.PresentmentAmount.Validate();
        _ = this.RecipientName;
        this.Route.Validate();
        _ = this.SenderAddressCity;
        _ = this.SenderAddressLine1;
        _ = this.SenderAddressPostalCode;
        _ = this.SenderAddressState;
        _ = this.SenderName;
        _ = this.SourceAccountNumberID;
        this.Status.Validate();
        this.Submission?.Validate();
        this.Type.Validate();
    }

    public CardPushTransfer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardPushTransfer(CardPushTransfer cardPushTransfer)
        : base(cardPushTransfer) { }
#pragma warning restore CS8618

    public CardPushTransfer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardPushTransfer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardPushTransferFromRaw.FromRawUnchecked"/>
    public static CardPushTransfer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardPushTransferFromRaw : IFromRawJson<CardPushTransfer>
{
    /// <inheritdoc/>
    public CardPushTransfer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardPushTransfer.FromRawUnchecked(rawData);
}

/// <summary>
/// If the transfer is accepted by the recipient bank, this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Acceptance, AcceptanceFromRaw>))]
public sealed record class Acceptance : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the transfer was accepted by the issuing bank.
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
    /// The authorization identification response from the issuing bank.
    /// </summary>
    public required string AuthorizationIdentificationResponse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("authorization_identification_response");
        }
        init { this._rawData.Set("authorization_identification_response", value); }
    }

    /// <summary>
    /// The result of the Card Verification Value 2 match.
    /// </summary>
    public required ApiEnum<string, CardVerificationValue2Result>? CardVerificationValue2Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CardVerificationValue2Result>>(
                "card_verification_value2_result"
            );
        }
        init { this._rawData.Set("card_verification_value2_result", value); }
    }

    /// <summary>
    /// A unique identifier for the transaction on the card network.
    /// </summary>
    public required string? NetworkTransactionIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("network_transaction_identifier");
        }
        init { this._rawData.Set("network_transaction_identifier", value); }
    }

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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcceptedAt;
        _ = this.AuthorizationIdentificationResponse;
        this.CardVerificationValue2Result?.Validate();
        _ = this.NetworkTransactionIdentifier;
        _ = this.SettlementAmount;
    }

    public Acceptance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Acceptance(Acceptance acceptance)
        : base(acceptance) { }
#pragma warning restore CS8618

    public Acceptance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Acceptance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AcceptanceFromRaw.FromRawUnchecked"/>
    public static Acceptance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AcceptanceFromRaw : IFromRawJson<Acceptance>
{
    /// <inheritdoc/>
    public Acceptance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Acceptance.FromRawUnchecked(rawData);
}

/// <summary>
/// The result of the Card Verification Value 2 match.
/// </summary>
[JsonConverter(typeof(CardVerificationValue2ResultConverter))]
public enum CardVerificationValue2Result
{
    /// <summary>
    /// The Card Verification Value 2 (CVV2) matches the expected value.
    /// </summary>
    Match,

    /// <summary>
    /// The Card Verification Value 2 (CVV2) does not match the expected value.
    /// </summary>
    NoMatch,
}

sealed class CardVerificationValue2ResultConverter : JsonConverter<CardVerificationValue2Result>
{
    public override CardVerificationValue2Result Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "match" => CardVerificationValue2Result.Match,
            "no_match" => CardVerificationValue2Result.NoMatch,
            _ => (CardVerificationValue2Result)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardVerificationValue2Result value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardVerificationValue2Result.Match => "match",
                CardVerificationValue2Result.NoMatch => "no_match",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If your account requires approvals for transfers and the transfer was approved,
/// this will contain details of the approval.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Approval, ApprovalFromRaw>))]
public sealed record class Approval : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the transfer was approved.
    /// </summary>
    public required System::DateTimeOffset ApprovedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("approved_at");
        }
        init { this._rawData.Set("approved_at", value); }
    }

    /// <summary>
    /// If the Transfer was approved by a user in the dashboard, the email address
    /// of that user.
    /// </summary>
    public required string? ApprovedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("approved_by");
        }
        init { this._rawData.Set("approved_by", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApprovedAt;
        _ = this.ApprovedBy;
    }

    public Approval() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Approval(Approval approval)
        : base(approval) { }
#pragma warning restore CS8618

    public Approval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Approval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApprovalFromRaw.FromRawUnchecked"/>
    public static Approval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApprovalFromRaw : IFromRawJson<Approval>
{
    /// <inheritdoc/>
    public Approval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Approval.FromRawUnchecked(rawData);
}

/// <summary>
/// The Business Application Identifier describes the type of transaction being performed.
/// Your program must be approved for the specified Business Application Identifier
/// in order to use it.
/// </summary>
[JsonConverter(typeof(CardPushTransferBusinessApplicationIdentifierConverter))]
public enum CardPushTransferBusinessApplicationIdentifier
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

sealed class CardPushTransferBusinessApplicationIdentifierConverter
    : JsonConverter<CardPushTransferBusinessApplicationIdentifier>
{
    public override CardPushTransferBusinessApplicationIdentifier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_to_account" => CardPushTransferBusinessApplicationIdentifier.AccountToAccount,
            "business_to_business" =>
                CardPushTransferBusinessApplicationIdentifier.BusinessToBusiness,
            "money_transfer_bank_initiated" =>
                CardPushTransferBusinessApplicationIdentifier.MoneyTransferBankInitiated,
            "non_card_bill_payment" =>
                CardPushTransferBusinessApplicationIdentifier.NonCardBillPayment,
            "consumer_bill_payment" =>
                CardPushTransferBusinessApplicationIdentifier.ConsumerBillPayment,
            "card_bill_payment" => CardPushTransferBusinessApplicationIdentifier.CardBillPayment,
            "funds_disbursement" => CardPushTransferBusinessApplicationIdentifier.FundsDisbursement,
            "funds_transfer" => CardPushTransferBusinessApplicationIdentifier.FundsTransfer,
            "loyalty_and_offers" => CardPushTransferBusinessApplicationIdentifier.LoyaltyAndOffers,
            "merchant_disbursement" =>
                CardPushTransferBusinessApplicationIdentifier.MerchantDisbursement,
            "merchant_payment" => CardPushTransferBusinessApplicationIdentifier.MerchantPayment,
            "person_to_person" => CardPushTransferBusinessApplicationIdentifier.PersonToPerson,
            "top_up" => CardPushTransferBusinessApplicationIdentifier.TopUp,
            "wallet_transfer" => CardPushTransferBusinessApplicationIdentifier.WalletTransfer,
            _ => (CardPushTransferBusinessApplicationIdentifier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardPushTransferBusinessApplicationIdentifier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardPushTransferBusinessApplicationIdentifier.AccountToAccount =>
                    "account_to_account",
                CardPushTransferBusinessApplicationIdentifier.BusinessToBusiness =>
                    "business_to_business",
                CardPushTransferBusinessApplicationIdentifier.MoneyTransferBankInitiated =>
                    "money_transfer_bank_initiated",
                CardPushTransferBusinessApplicationIdentifier.NonCardBillPayment =>
                    "non_card_bill_payment",
                CardPushTransferBusinessApplicationIdentifier.ConsumerBillPayment =>
                    "consumer_bill_payment",
                CardPushTransferBusinessApplicationIdentifier.CardBillPayment =>
                    "card_bill_payment",
                CardPushTransferBusinessApplicationIdentifier.FundsDisbursement =>
                    "funds_disbursement",
                CardPushTransferBusinessApplicationIdentifier.FundsTransfer => "funds_transfer",
                CardPushTransferBusinessApplicationIdentifier.LoyaltyAndOffers =>
                    "loyalty_and_offers",
                CardPushTransferBusinessApplicationIdentifier.MerchantDisbursement =>
                    "merchant_disbursement",
                CardPushTransferBusinessApplicationIdentifier.MerchantPayment => "merchant_payment",
                CardPushTransferBusinessApplicationIdentifier.PersonToPerson => "person_to_person",
                CardPushTransferBusinessApplicationIdentifier.TopUp => "top_up",
                CardPushTransferBusinessApplicationIdentifier.WalletTransfer => "wallet_transfer",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If your account requires approvals for transfers and the transfer was not approved,
/// this will contain details of the cancellation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Cancellation, CancellationFromRaw>))]
public sealed record class Cancellation : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Transfer was canceled.
    /// </summary>
    public required System::DateTimeOffset CanceledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("canceled_at");
        }
        init { this._rawData.Set("canceled_at", value); }
    }

    /// <summary>
    /// If the Transfer was canceled by a user in the dashboard, the email address
    /// of that user.
    /// </summary>
    public required string? CanceledBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("canceled_by");
        }
        init { this._rawData.Set("canceled_by", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanceledAt;
        _ = this.CanceledBy;
    }

    public Cancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cancellation(Cancellation cancellation)
        : base(cancellation) { }
#pragma warning restore CS8618

    public Cancellation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Cancellation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CancellationFromRaw.FromRawUnchecked"/>
    public static Cancellation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CancellationFromRaw : IFromRawJson<Cancellation>
{
    /// <inheritdoc/>
    public Cancellation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Cancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// What object created the transfer, either via the API or the dashboard.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreatedBy, CreatedByFromRaw>))]
public sealed record class CreatedBy : JsonModel
{
    /// <summary>
    /// The type of object that created this transfer.
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
    /// If present, details about the API key that created the transfer.
    /// </summary>
    public ApiKey? ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiKey>("api_key");
        }
        init { this._rawData.Set("api_key", value); }
    }

    /// <summary>
    /// If present, details about the OAuth Application that created the transfer.
    /// </summary>
    public OAuthApplication? OAuthApplication
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OAuthApplication>("oauth_application");
        }
        init { this._rawData.Set("oauth_application", value); }
    }

    /// <summary>
    /// If present, details about the User that created the transfer.
    /// </summary>
    public User? User
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<User>("user");
        }
        init { this._rawData.Set("user", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.ApiKey?.Validate();
        this.OAuthApplication?.Validate();
        this.User?.Validate();
    }

    public CreatedBy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatedBy(CreatedBy createdBy)
        : base(createdBy) { }
#pragma warning restore CS8618

    public CreatedBy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatedBy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatedByFromRaw.FromRawUnchecked"/>
    public static CreatedBy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CreatedBy(ApiEnum<string, Category> category)
        : this()
    {
        this.Category = category;
    }
}

class CreatedByFromRaw : IFromRawJson<CreatedBy>
{
    /// <inheritdoc/>
    public CreatedBy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreatedBy.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of object that created this transfer.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    /// <summary>
    /// An API key. Details will be under the `api_key` object.
    /// </summary>
    ApiKey,

    /// <summary>
    /// An OAuth application you connected to Increase. Details will be under the
    /// `oauth_application` object.
    /// </summary>
    OAuthApplication,

    /// <summary>
    /// A User in the Increase dashboard. Details will be under the `user` object.
    /// </summary>
    User,
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
            "api_key" => Category.ApiKey,
            "oauth_application" => Category.OAuthApplication,
            "user" => Category.User,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.ApiKey => "api_key",
                Category.OAuthApplication => "oauth_application",
                Category.User => "user",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If present, details about the API key that created the transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ApiKey, ApiKeyFromRaw>))]
public sealed record class ApiKey : JsonModel
{
    /// <summary>
    /// The description set for the API key when it was created.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
    }

    public ApiKey() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKey(ApiKey apiKey)
        : base(apiKey) { }
#pragma warning restore CS8618

    public ApiKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyFromRaw.FromRawUnchecked"/>
    public static ApiKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ApiKey(string? description)
        : this()
    {
        this.Description = description;
    }
}

class ApiKeyFromRaw : IFromRawJson<ApiKey>
{
    /// <inheritdoc/>
    public ApiKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ApiKey.FromRawUnchecked(rawData);
}

/// <summary>
/// If present, details about the OAuth Application that created the transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OAuthApplication, OAuthApplicationFromRaw>))]
public sealed record class OAuthApplication : JsonModel
{
    /// <summary>
    /// The name of the OAuth Application.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public OAuthApplication() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthApplication(OAuthApplication oauthApplication)
        : base(oauthApplication) { }
#pragma warning restore CS8618

    public OAuthApplication(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthApplication(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OAuthApplicationFromRaw.FromRawUnchecked"/>
    public static OAuthApplication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OAuthApplication(string name)
        : this()
    {
        this.Name = name;
    }
}

class OAuthApplicationFromRaw : IFromRawJson<OAuthApplication>
{
    /// <inheritdoc/>
    public OAuthApplication FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OAuthApplication.FromRawUnchecked(rawData);
}

/// <summary>
/// If present, details about the User that created the transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<User, UserFromRaw>))]
public sealed record class User : JsonModel
{
    /// <summary>
    /// The email address of the User.
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
    }

    public User() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public User(User user)
        : base(user) { }
#pragma warning restore CS8618

    public User(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    User(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserFromRaw.FromRawUnchecked"/>
    public static User FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public User(string email)
        : this()
    {
        this.Email = email;
    }
}

class UserFromRaw : IFromRawJson<User>
{
    /// <inheritdoc/>
    public User FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        User.FromRawUnchecked(rawData);
}

/// <summary>
/// If the transfer is rejected by the card network or the destination financial institution,
/// this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Decline, DeclineFromRaw>))]
public sealed record class Decline : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the transfer declined.
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
    /// A unique identifier for the transaction on the card network.
    /// </summary>
    public required string? NetworkTransactionIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("network_transaction_identifier");
        }
        init { this._rawData.Set("network_transaction_identifier", value); }
    }

    /// <summary>
    /// The reason why the transfer was declined.
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
        _ = this.NetworkTransactionIdentifier;
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
/// The reason why the transfer was declined.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    /// <summary>
    /// The card issuer has declined the transaction without providing a specific reason.
    /// </summary>
    DoNotHonor,

    /// <summary>
    /// The number of transactions for the card has exceeded the limit set by the issuer.
    /// </summary>
    ActivityCountLimitExceeded,

    /// <summary>
    /// The card issuer requires the cardholder to contact them for further information
    /// regarding the transaction.
    /// </summary>
    ReferToCardIssuer,

    /// <summary>
    /// The card issuer requires the cardholder to contact them due to a special condition
    /// related to the transaction.
    /// </summary>
    ReferToCardIssuerSpecialCondition,

    /// <summary>
    /// The merchant is not valid for this transaction.
    /// </summary>
    InvalidMerchant,

    /// <summary>
    /// The card should be retained by the terminal.
    /// </summary>
    PickUpCard,

    /// <summary>
    /// An error occurred during processing of the transaction.
    /// </summary>
    Error,

    /// <summary>
    /// The card should be retained by the terminal due to a special condition.
    /// </summary>
    PickUpCardSpecial,

    /// <summary>
    /// The transaction is invalid and cannot be processed.
    /// </summary>
    InvalidTransaction,

    /// <summary>
    /// The amount of the transaction is invalid.
    /// </summary>
    InvalidAmount,

    /// <summary>
    /// The account number provided is invalid.
    /// </summary>
    InvalidAccountNumber,

    /// <summary>
    /// The issuer of the card could not be found.
    /// </summary>
    NoSuchIssuer,

    /// <summary>
    /// The transaction should be re-entered for processing.
    /// </summary>
    ReEnterTransaction,

    /// <summary>
    /// There is no credit account associated with the card.
    /// </summary>
    NoCreditAccount,

    /// <summary>
    /// The card should be retained by the terminal because it has been reported lost.
    /// </summary>
    PickUpCardLost,

    /// <summary>
    /// The card should be retained by the terminal because it has been reported stolen.
    /// </summary>
    PickUpCardStolen,

    /// <summary>
    /// The account associated with the card has been closed.
    /// </summary>
    ClosedAccount,

    /// <summary>
    /// There are insufficient funds in the account to complete the transaction.
    /// </summary>
    InsufficientFunds,

    /// <summary>
    /// There is no checking account associated with the card.
    /// </summary>
    NoCheckingAccount,

    /// <summary>
    /// There is no savings account associated with the card.
    /// </summary>
    NoSavingsAccount,

    /// <summary>
    /// The card has expired and cannot be used for transactions.
    /// </summary>
    ExpiredCard,

    /// <summary>
    /// The transaction is not permitted for this cardholder.
    /// </summary>
    TransactionNotPermittedToCardholder,

    /// <summary>
    /// The transaction is not allowed at this terminal.
    /// </summary>
    TransactionNotAllowedAtTerminal,

    /// <summary>
    /// The transaction is not supported or has been blocked by the issuer.
    /// </summary>
    TransactionNotSupportedOrBlockedByIssuer,

    /// <summary>
    /// The transaction has been flagged as suspected fraud and cannot be processed.
    /// </summary>
    SuspectedFraud,

    /// <summary>
    /// The amount of activity on the card has exceeded the limit set by the issuer.
    /// </summary>
    ActivityAmountLimitExceeded,

    /// <summary>
    /// The card has restrictions that prevent it from being used for this transaction.
    /// </summary>
    RestrictedCard,

    /// <summary>
    /// A security violation has occurred, preventing the transaction from being processed.
    /// </summary>
    SecurityViolation,

    /// <summary>
    /// The transaction does not meet the anti-money laundering requirements set
    /// by the issuer.
    /// </summary>
    TransactionDoesNotFulfillAntiMoneyLaunderingRequirement,

    /// <summary>
    /// The transaction was blocked by the cardholder.
    /// </summary>
    BlockedByCardholder,

    /// <summary>
    /// The first use of the card has been blocked by the issuer.
    /// </summary>
    BlockedFirstUse,

    /// <summary>
    /// The credit issuer is currently unavailable to process the transaction.
    /// </summary>
    CreditIssuerUnavailable,

    /// <summary>
    /// The card verification value (CVV) results were negative, indicating a potential
    /// issue with the card.
    /// </summary>
    NegativeCardVerificationValueResults,

    /// <summary>
    /// The issuer of the card is currently unavailable to process the transaction.
    /// </summary>
    IssuerUnavailable,

    /// <summary>
    /// The financial institution associated with the card could not be found.
    /// </summary>
    FinancialInstitutionCannotBeFound,

    /// <summary>
    /// The transaction cannot be completed due to an unspecified reason.
    /// </summary>
    TransactionCannotBeCompleted,

    /// <summary>
    /// The transaction is a duplicate of a previous transaction and cannot be processed again.
    /// </summary>
    DuplicateTransaction,

    /// <summary>
    /// A system malfunction occurred, preventing the transaction from being processed.
    /// </summary>
    SystemMalfunction,

    /// <summary>
    /// Additional customer authentication is required to complete the transaction.
    /// </summary>
    AdditionalCustomerAuthenticationRequired,

    /// <summary>
    /// The surcharge amount applied to the transaction is not permitted by the issuer.
    /// </summary>
    SurchargeAmountNotPermitted,

    /// <summary>
    /// The transaction was declined due to a failure in verifying the CVV2 code.
    /// </summary>
    DeclineForCvv2Failure,

    /// <summary>
    /// A stop payment order has been placed on this transaction.
    /// </summary>
    StopPaymentOrder,

    /// <summary>
    /// An order has been placed to revoke authorization for this transaction.
    /// </summary>
    RevocationOfAuthorizationOrder,

    /// <summary>
    /// An order has been placed to revoke all authorizations for this cardholder.
    /// </summary>
    RevocationOfAllAuthorizationsOrder,

    /// <summary>
    /// The record associated with the transaction could not be located.
    /// </summary>
    UnableToLocateRecord,

    /// <summary>
    /// The file needed for the transaction is temporarily unavailable.
    /// </summary>
    FileIsTemporarilyUnavailable,

    /// <summary>
    /// The PIN entered for the transaction is incorrect.
    /// </summary>
    IncorrectPin,

    /// <summary>
    /// The allowable number of PIN entry tries has been exceeded.
    /// </summary>
    AllowableNumberOfPinEntryTriesExceeded,

    /// <summary>
    /// The previous message associated with the transaction could not be located.
    /// </summary>
    UnableToLocatePreviousMessage,

    /// <summary>
    /// An error was found with the PIN associated with the transaction.
    /// </summary>
    PinErrorFound,

    /// <summary>
    /// The PIN associated with the transaction could not be verified.
    /// </summary>
    CannotVerifyPin,

    /// <summary>
    /// The verification data associated with the transaction has failed.
    /// </summary>
    VerificationDataFailed,

    /// <summary>
    /// The surcharge amount is not supported by the debit network issuer.
    /// </summary>
    SurchargeAmountNotSupportedByDebitNetworkIssuer,

    /// <summary>
    /// Cash service is not available for this transaction.
    /// </summary>
    CashServiceNotAvailable,

    /// <summary>
    /// The cashback request exceeds the issuer limit.
    /// </summary>
    CashbackRequestExceedsIssuerLimit,

    /// <summary>
    /// The transaction amount exceeds the pre-authorized approval amount.
    /// </summary>
    TransactionAmountExceedsPreAuthorizedApprovalAmount,

    /// <summary>
    /// The transaction does not qualify for Visa PIN processing.
    /// </summary>
    TransactionDoesNotQualifyForVisaPin,

    /// <summary>
    /// The transaction was declined offline.
    /// </summary>
    OfflineDeclined,

    /// <summary>
    /// The terminal was unable to go online to process the transaction.
    /// </summary>
    UnableToGoOnline,

    /// <summary>
    /// The account is valid but the transaction amount is not supported.
    /// </summary>
    ValidAccountButAmountNotSupported,

    /// <summary>
    /// The merchant category code was used incorrectly; correct it and reattempt
    /// the transaction.
    /// </summary>
    InvalidUseOfMerchantCategoryCodeCorrectAndReattempt,

    /// <summary>
    /// The card authentication process has failed.
    /// </summary>
    CardAuthenticationFailed,
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
            "do_not_honor" => Reason.DoNotHonor,
            "activity_count_limit_exceeded" => Reason.ActivityCountLimitExceeded,
            "refer_to_card_issuer" => Reason.ReferToCardIssuer,
            "refer_to_card_issuer_special_condition" => Reason.ReferToCardIssuerSpecialCondition,
            "invalid_merchant" => Reason.InvalidMerchant,
            "pick_up_card" => Reason.PickUpCard,
            "error" => Reason.Error,
            "pick_up_card_special" => Reason.PickUpCardSpecial,
            "invalid_transaction" => Reason.InvalidTransaction,
            "invalid_amount" => Reason.InvalidAmount,
            "invalid_account_number" => Reason.InvalidAccountNumber,
            "no_such_issuer" => Reason.NoSuchIssuer,
            "re_enter_transaction" => Reason.ReEnterTransaction,
            "no_credit_account" => Reason.NoCreditAccount,
            "pick_up_card_lost" => Reason.PickUpCardLost,
            "pick_up_card_stolen" => Reason.PickUpCardStolen,
            "closed_account" => Reason.ClosedAccount,
            "insufficient_funds" => Reason.InsufficientFunds,
            "no_checking_account" => Reason.NoCheckingAccount,
            "no_savings_account" => Reason.NoSavingsAccount,
            "expired_card" => Reason.ExpiredCard,
            "transaction_not_permitted_to_cardholder" => Reason.TransactionNotPermittedToCardholder,
            "transaction_not_allowed_at_terminal" => Reason.TransactionNotAllowedAtTerminal,
            "transaction_not_supported_or_blocked_by_issuer" =>
                Reason.TransactionNotSupportedOrBlockedByIssuer,
            "suspected_fraud" => Reason.SuspectedFraud,
            "activity_amount_limit_exceeded" => Reason.ActivityAmountLimitExceeded,
            "restricted_card" => Reason.RestrictedCard,
            "security_violation" => Reason.SecurityViolation,
            "transaction_does_not_fulfill_anti_money_laundering_requirement" =>
                Reason.TransactionDoesNotFulfillAntiMoneyLaunderingRequirement,
            "blocked_by_cardholder" => Reason.BlockedByCardholder,
            "blocked_first_use" => Reason.BlockedFirstUse,
            "credit_issuer_unavailable" => Reason.CreditIssuerUnavailable,
            "negative_card_verification_value_results" =>
                Reason.NegativeCardVerificationValueResults,
            "issuer_unavailable" => Reason.IssuerUnavailable,
            "financial_institution_cannot_be_found" => Reason.FinancialInstitutionCannotBeFound,
            "transaction_cannot_be_completed" => Reason.TransactionCannotBeCompleted,
            "duplicate_transaction" => Reason.DuplicateTransaction,
            "system_malfunction" => Reason.SystemMalfunction,
            "additional_customer_authentication_required" =>
                Reason.AdditionalCustomerAuthenticationRequired,
            "surcharge_amount_not_permitted" => Reason.SurchargeAmountNotPermitted,
            "decline_for_cvv2_failure" => Reason.DeclineForCvv2Failure,
            "stop_payment_order" => Reason.StopPaymentOrder,
            "revocation_of_authorization_order" => Reason.RevocationOfAuthorizationOrder,
            "revocation_of_all_authorizations_order" => Reason.RevocationOfAllAuthorizationsOrder,
            "unable_to_locate_record" => Reason.UnableToLocateRecord,
            "file_is_temporarily_unavailable" => Reason.FileIsTemporarilyUnavailable,
            "incorrect_pin" => Reason.IncorrectPin,
            "allowable_number_of_pin_entry_tries_exceeded" =>
                Reason.AllowableNumberOfPinEntryTriesExceeded,
            "unable_to_locate_previous_message" => Reason.UnableToLocatePreviousMessage,
            "pin_error_found" => Reason.PinErrorFound,
            "cannot_verify_pin" => Reason.CannotVerifyPin,
            "verification_data_failed" => Reason.VerificationDataFailed,
            "surcharge_amount_not_supported_by_debit_network_issuer" =>
                Reason.SurchargeAmountNotSupportedByDebitNetworkIssuer,
            "cash_service_not_available" => Reason.CashServiceNotAvailable,
            "cashback_request_exceeds_issuer_limit" => Reason.CashbackRequestExceedsIssuerLimit,
            "transaction_amount_exceeds_pre_authorized_approval_amount" =>
                Reason.TransactionAmountExceedsPreAuthorizedApprovalAmount,
            "transaction_does_not_qualify_for_visa_pin" =>
                Reason.TransactionDoesNotQualifyForVisaPin,
            "offline_declined" => Reason.OfflineDeclined,
            "unable_to_go_online" => Reason.UnableToGoOnline,
            "valid_account_but_amount_not_supported" => Reason.ValidAccountButAmountNotSupported,
            "invalid_use_of_merchant_category_code_correct_and_reattempt" =>
                Reason.InvalidUseOfMerchantCategoryCodeCorrectAndReattempt,
            "card_authentication_failed" => Reason.CardAuthenticationFailed,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.DoNotHonor => "do_not_honor",
                Reason.ActivityCountLimitExceeded => "activity_count_limit_exceeded",
                Reason.ReferToCardIssuer => "refer_to_card_issuer",
                Reason.ReferToCardIssuerSpecialCondition =>
                    "refer_to_card_issuer_special_condition",
                Reason.InvalidMerchant => "invalid_merchant",
                Reason.PickUpCard => "pick_up_card",
                Reason.Error => "error",
                Reason.PickUpCardSpecial => "pick_up_card_special",
                Reason.InvalidTransaction => "invalid_transaction",
                Reason.InvalidAmount => "invalid_amount",
                Reason.InvalidAccountNumber => "invalid_account_number",
                Reason.NoSuchIssuer => "no_such_issuer",
                Reason.ReEnterTransaction => "re_enter_transaction",
                Reason.NoCreditAccount => "no_credit_account",
                Reason.PickUpCardLost => "pick_up_card_lost",
                Reason.PickUpCardStolen => "pick_up_card_stolen",
                Reason.ClosedAccount => "closed_account",
                Reason.InsufficientFunds => "insufficient_funds",
                Reason.NoCheckingAccount => "no_checking_account",
                Reason.NoSavingsAccount => "no_savings_account",
                Reason.ExpiredCard => "expired_card",
                Reason.TransactionNotPermittedToCardholder =>
                    "transaction_not_permitted_to_cardholder",
                Reason.TransactionNotAllowedAtTerminal => "transaction_not_allowed_at_terminal",
                Reason.TransactionNotSupportedOrBlockedByIssuer =>
                    "transaction_not_supported_or_blocked_by_issuer",
                Reason.SuspectedFraud => "suspected_fraud",
                Reason.ActivityAmountLimitExceeded => "activity_amount_limit_exceeded",
                Reason.RestrictedCard => "restricted_card",
                Reason.SecurityViolation => "security_violation",
                Reason.TransactionDoesNotFulfillAntiMoneyLaunderingRequirement =>
                    "transaction_does_not_fulfill_anti_money_laundering_requirement",
                Reason.BlockedByCardholder => "blocked_by_cardholder",
                Reason.BlockedFirstUse => "blocked_first_use",
                Reason.CreditIssuerUnavailable => "credit_issuer_unavailable",
                Reason.NegativeCardVerificationValueResults =>
                    "negative_card_verification_value_results",
                Reason.IssuerUnavailable => "issuer_unavailable",
                Reason.FinancialInstitutionCannotBeFound => "financial_institution_cannot_be_found",
                Reason.TransactionCannotBeCompleted => "transaction_cannot_be_completed",
                Reason.DuplicateTransaction => "duplicate_transaction",
                Reason.SystemMalfunction => "system_malfunction",
                Reason.AdditionalCustomerAuthenticationRequired =>
                    "additional_customer_authentication_required",
                Reason.SurchargeAmountNotPermitted => "surcharge_amount_not_permitted",
                Reason.DeclineForCvv2Failure => "decline_for_cvv2_failure",
                Reason.StopPaymentOrder => "stop_payment_order",
                Reason.RevocationOfAuthorizationOrder => "revocation_of_authorization_order",
                Reason.RevocationOfAllAuthorizationsOrder =>
                    "revocation_of_all_authorizations_order",
                Reason.UnableToLocateRecord => "unable_to_locate_record",
                Reason.FileIsTemporarilyUnavailable => "file_is_temporarily_unavailable",
                Reason.IncorrectPin => "incorrect_pin",
                Reason.AllowableNumberOfPinEntryTriesExceeded =>
                    "allowable_number_of_pin_entry_tries_exceeded",
                Reason.UnableToLocatePreviousMessage => "unable_to_locate_previous_message",
                Reason.PinErrorFound => "pin_error_found",
                Reason.CannotVerifyPin => "cannot_verify_pin",
                Reason.VerificationDataFailed => "verification_data_failed",
                Reason.SurchargeAmountNotSupportedByDebitNetworkIssuer =>
                    "surcharge_amount_not_supported_by_debit_network_issuer",
                Reason.CashServiceNotAvailable => "cash_service_not_available",
                Reason.CashbackRequestExceedsIssuerLimit => "cashback_request_exceeds_issuer_limit",
                Reason.TransactionAmountExceedsPreAuthorizedApprovalAmount =>
                    "transaction_amount_exceeds_pre_authorized_approval_amount",
                Reason.TransactionDoesNotQualifyForVisaPin =>
                    "transaction_does_not_qualify_for_visa_pin",
                Reason.OfflineDeclined => "offline_declined",
                Reason.UnableToGoOnline => "unable_to_go_online",
                Reason.ValidAccountButAmountNotSupported =>
                    "valid_account_but_amount_not_supported",
                Reason.InvalidUseOfMerchantCategoryCodeCorrectAndReattempt =>
                    "invalid_use_of_merchant_category_code_correct_and_reattempt",
                Reason.CardAuthenticationFailed => "card_authentication_failed",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The amount that was transferred. The receiving bank will have converted this
/// to the cardholder's currency. The amount that is applied to your Increase account
/// matches the currency of your account.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardPushTransferPresentmentAmount,
        CardPushTransferPresentmentAmountFromRaw
    >)
)]
public sealed record class CardPushTransferPresentmentAmount : JsonModel
{
    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) currency code.
    /// </summary>
    public required ApiEnum<string, CardPushTransferPresentmentAmountCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardPushTransferPresentmentAmountCurrency>
            >("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The amount value represented as a string containing a decimal number in major
    /// units (so e.g., "12.34" for $12.34).
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

    public CardPushTransferPresentmentAmount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardPushTransferPresentmentAmount(
        CardPushTransferPresentmentAmount cardPushTransferPresentmentAmount
    )
        : base(cardPushTransferPresentmentAmount) { }
#pragma warning restore CS8618

    public CardPushTransferPresentmentAmount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardPushTransferPresentmentAmount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardPushTransferPresentmentAmountFromRaw.FromRawUnchecked"/>
    public static CardPushTransferPresentmentAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardPushTransferPresentmentAmountFromRaw : IFromRawJson<CardPushTransferPresentmentAmount>
{
    /// <inheritdoc/>
    public CardPushTransferPresentmentAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardPushTransferPresentmentAmount.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) currency code.
/// </summary>
[JsonConverter(typeof(CardPushTransferPresentmentAmountCurrencyConverter))]
public enum CardPushTransferPresentmentAmountCurrency
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

sealed class CardPushTransferPresentmentAmountCurrencyConverter
    : JsonConverter<CardPushTransferPresentmentAmountCurrency>
{
    public override CardPushTransferPresentmentAmountCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AFN" => CardPushTransferPresentmentAmountCurrency.Afn,
            "EUR" => CardPushTransferPresentmentAmountCurrency.Eur,
            "ALL" => CardPushTransferPresentmentAmountCurrency.All,
            "DZD" => CardPushTransferPresentmentAmountCurrency.Dzd,
            "USD" => CardPushTransferPresentmentAmountCurrency.Usd,
            "AOA" => CardPushTransferPresentmentAmountCurrency.Aoa,
            "ARS" => CardPushTransferPresentmentAmountCurrency.Ars,
            "AMD" => CardPushTransferPresentmentAmountCurrency.Amd,
            "AWG" => CardPushTransferPresentmentAmountCurrency.Awg,
            "AUD" => CardPushTransferPresentmentAmountCurrency.Aud,
            "AZN" => CardPushTransferPresentmentAmountCurrency.Azn,
            "BSD" => CardPushTransferPresentmentAmountCurrency.Bsd,
            "BHD" => CardPushTransferPresentmentAmountCurrency.Bhd,
            "BDT" => CardPushTransferPresentmentAmountCurrency.Bdt,
            "BBD" => CardPushTransferPresentmentAmountCurrency.Bbd,
            "BYN" => CardPushTransferPresentmentAmountCurrency.Byn,
            "BZD" => CardPushTransferPresentmentAmountCurrency.Bzd,
            "BMD" => CardPushTransferPresentmentAmountCurrency.Bmd,
            "INR" => CardPushTransferPresentmentAmountCurrency.Inr,
            "BTN" => CardPushTransferPresentmentAmountCurrency.Btn,
            "BOB" => CardPushTransferPresentmentAmountCurrency.Bob,
            "BOV" => CardPushTransferPresentmentAmountCurrency.Bov,
            "BAM" => CardPushTransferPresentmentAmountCurrency.Bam,
            "BWP" => CardPushTransferPresentmentAmountCurrency.Bwp,
            "NOK" => CardPushTransferPresentmentAmountCurrency.Nok,
            "BRL" => CardPushTransferPresentmentAmountCurrency.Brl,
            "BND" => CardPushTransferPresentmentAmountCurrency.Bnd,
            "BGN" => CardPushTransferPresentmentAmountCurrency.Bgn,
            "BIF" => CardPushTransferPresentmentAmountCurrency.Bif,
            "CVE" => CardPushTransferPresentmentAmountCurrency.Cve,
            "KHR" => CardPushTransferPresentmentAmountCurrency.Khr,
            "CAD" => CardPushTransferPresentmentAmountCurrency.Cad,
            "KYD" => CardPushTransferPresentmentAmountCurrency.Kyd,
            "CLP" => CardPushTransferPresentmentAmountCurrency.Clp,
            "CLF" => CardPushTransferPresentmentAmountCurrency.Clf,
            "CNY" => CardPushTransferPresentmentAmountCurrency.Cny,
            "COP" => CardPushTransferPresentmentAmountCurrency.Cop,
            "COU" => CardPushTransferPresentmentAmountCurrency.Cou,
            "KMF" => CardPushTransferPresentmentAmountCurrency.Kmf,
            "CDF" => CardPushTransferPresentmentAmountCurrency.Cdf,
            "NZD" => CardPushTransferPresentmentAmountCurrency.Nzd,
            "CRC" => CardPushTransferPresentmentAmountCurrency.Crc,
            "CUP" => CardPushTransferPresentmentAmountCurrency.Cup,
            "CZK" => CardPushTransferPresentmentAmountCurrency.Czk,
            "DKK" => CardPushTransferPresentmentAmountCurrency.Dkk,
            "DJF" => CardPushTransferPresentmentAmountCurrency.Djf,
            "DOP" => CardPushTransferPresentmentAmountCurrency.Dop,
            "EGP" => CardPushTransferPresentmentAmountCurrency.Egp,
            "SVC" => CardPushTransferPresentmentAmountCurrency.Svc,
            "ERN" => CardPushTransferPresentmentAmountCurrency.Ern,
            "SZL" => CardPushTransferPresentmentAmountCurrency.Szl,
            "ETB" => CardPushTransferPresentmentAmountCurrency.Etb,
            "FKP" => CardPushTransferPresentmentAmountCurrency.Fkp,
            "FJD" => CardPushTransferPresentmentAmountCurrency.Fjd,
            "GMD" => CardPushTransferPresentmentAmountCurrency.Gmd,
            "GEL" => CardPushTransferPresentmentAmountCurrency.Gel,
            "GHS" => CardPushTransferPresentmentAmountCurrency.Ghs,
            "GIP" => CardPushTransferPresentmentAmountCurrency.Gip,
            "GTQ" => CardPushTransferPresentmentAmountCurrency.Gtq,
            "GBP" => CardPushTransferPresentmentAmountCurrency.Gbp,
            "GNF" => CardPushTransferPresentmentAmountCurrency.Gnf,
            "GYD" => CardPushTransferPresentmentAmountCurrency.Gyd,
            "HTG" => CardPushTransferPresentmentAmountCurrency.Htg,
            "HNL" => CardPushTransferPresentmentAmountCurrency.Hnl,
            "HKD" => CardPushTransferPresentmentAmountCurrency.Hkd,
            "HUF" => CardPushTransferPresentmentAmountCurrency.Huf,
            "ISK" => CardPushTransferPresentmentAmountCurrency.Isk,
            "IDR" => CardPushTransferPresentmentAmountCurrency.Idr,
            "IRR" => CardPushTransferPresentmentAmountCurrency.Irr,
            "IQD" => CardPushTransferPresentmentAmountCurrency.Iqd,
            "ILS" => CardPushTransferPresentmentAmountCurrency.Ils,
            "JMD" => CardPushTransferPresentmentAmountCurrency.Jmd,
            "JPY" => CardPushTransferPresentmentAmountCurrency.Jpy,
            "JOD" => CardPushTransferPresentmentAmountCurrency.Jod,
            "KZT" => CardPushTransferPresentmentAmountCurrency.Kzt,
            "KES" => CardPushTransferPresentmentAmountCurrency.Kes,
            "KPW" => CardPushTransferPresentmentAmountCurrency.Kpw,
            "KRW" => CardPushTransferPresentmentAmountCurrency.Krw,
            "KWD" => CardPushTransferPresentmentAmountCurrency.Kwd,
            "KGS" => CardPushTransferPresentmentAmountCurrency.Kgs,
            "LAK" => CardPushTransferPresentmentAmountCurrency.Lak,
            "LBP" => CardPushTransferPresentmentAmountCurrency.Lbp,
            "LSL" => CardPushTransferPresentmentAmountCurrency.Lsl,
            "ZAR" => CardPushTransferPresentmentAmountCurrency.Zar,
            "LRD" => CardPushTransferPresentmentAmountCurrency.Lrd,
            "LYD" => CardPushTransferPresentmentAmountCurrency.Lyd,
            "CHF" => CardPushTransferPresentmentAmountCurrency.Chf,
            "MOP" => CardPushTransferPresentmentAmountCurrency.Mop,
            "MKD" => CardPushTransferPresentmentAmountCurrency.Mkd,
            "MGA" => CardPushTransferPresentmentAmountCurrency.Mga,
            "MWK" => CardPushTransferPresentmentAmountCurrency.Mwk,
            "MYR" => CardPushTransferPresentmentAmountCurrency.Myr,
            "MVR" => CardPushTransferPresentmentAmountCurrency.Mvr,
            "MRU" => CardPushTransferPresentmentAmountCurrency.Mru,
            "MUR" => CardPushTransferPresentmentAmountCurrency.Mur,
            "MXN" => CardPushTransferPresentmentAmountCurrency.Mxn,
            "MXV" => CardPushTransferPresentmentAmountCurrency.Mxv,
            "MDL" => CardPushTransferPresentmentAmountCurrency.Mdl,
            "MNT" => CardPushTransferPresentmentAmountCurrency.Mnt,
            "MAD" => CardPushTransferPresentmentAmountCurrency.Mad,
            "MZN" => CardPushTransferPresentmentAmountCurrency.Mzn,
            "MMK" => CardPushTransferPresentmentAmountCurrency.Mmk,
            "NAD" => CardPushTransferPresentmentAmountCurrency.Nad,
            "NPR" => CardPushTransferPresentmentAmountCurrency.Npr,
            "NIO" => CardPushTransferPresentmentAmountCurrency.Nio,
            "NGN" => CardPushTransferPresentmentAmountCurrency.Ngn,
            "OMR" => CardPushTransferPresentmentAmountCurrency.Omr,
            "PKR" => CardPushTransferPresentmentAmountCurrency.Pkr,
            "PAB" => CardPushTransferPresentmentAmountCurrency.Pab,
            "PGK" => CardPushTransferPresentmentAmountCurrency.Pgk,
            "PYG" => CardPushTransferPresentmentAmountCurrency.Pyg,
            "PEN" => CardPushTransferPresentmentAmountCurrency.Pen,
            "PHP" => CardPushTransferPresentmentAmountCurrency.Php,
            "PLN" => CardPushTransferPresentmentAmountCurrency.Pln,
            "QAR" => CardPushTransferPresentmentAmountCurrency.Qar,
            "RON" => CardPushTransferPresentmentAmountCurrency.Ron,
            "RUB" => CardPushTransferPresentmentAmountCurrency.Rub,
            "RWF" => CardPushTransferPresentmentAmountCurrency.Rwf,
            "SHP" => CardPushTransferPresentmentAmountCurrency.Shp,
            "WST" => CardPushTransferPresentmentAmountCurrency.Wst,
            "STN" => CardPushTransferPresentmentAmountCurrency.Stn,
            "SAR" => CardPushTransferPresentmentAmountCurrency.Sar,
            "RSD" => CardPushTransferPresentmentAmountCurrency.Rsd,
            "SCR" => CardPushTransferPresentmentAmountCurrency.Scr,
            "SLE" => CardPushTransferPresentmentAmountCurrency.Sle,
            "SGD" => CardPushTransferPresentmentAmountCurrency.Sgd,
            "SBD" => CardPushTransferPresentmentAmountCurrency.Sbd,
            "SOS" => CardPushTransferPresentmentAmountCurrency.Sos,
            "SSP" => CardPushTransferPresentmentAmountCurrency.Ssp,
            "LKR" => CardPushTransferPresentmentAmountCurrency.Lkr,
            "SDG" => CardPushTransferPresentmentAmountCurrency.Sdg,
            "SRD" => CardPushTransferPresentmentAmountCurrency.Srd,
            "SEK" => CardPushTransferPresentmentAmountCurrency.Sek,
            "CHE" => CardPushTransferPresentmentAmountCurrency.Che,
            "CHW" => CardPushTransferPresentmentAmountCurrency.Chw,
            "SYP" => CardPushTransferPresentmentAmountCurrency.Syp,
            "TWD" => CardPushTransferPresentmentAmountCurrency.Twd,
            "TJS" => CardPushTransferPresentmentAmountCurrency.Tjs,
            "TZS" => CardPushTransferPresentmentAmountCurrency.Tzs,
            "THB" => CardPushTransferPresentmentAmountCurrency.Thb,
            "TOP" => CardPushTransferPresentmentAmountCurrency.Top,
            "TTD" => CardPushTransferPresentmentAmountCurrency.Ttd,
            "TND" => CardPushTransferPresentmentAmountCurrency.Tnd,
            "TRY" => CardPushTransferPresentmentAmountCurrency.Try,
            "TMT" => CardPushTransferPresentmentAmountCurrency.Tmt,
            "UGX" => CardPushTransferPresentmentAmountCurrency.Ugx,
            "UAH" => CardPushTransferPresentmentAmountCurrency.Uah,
            "AED" => CardPushTransferPresentmentAmountCurrency.Aed,
            "USN" => CardPushTransferPresentmentAmountCurrency.Usn,
            "UYU" => CardPushTransferPresentmentAmountCurrency.Uyu,
            "UYI" => CardPushTransferPresentmentAmountCurrency.Uyi,
            "UYW" => CardPushTransferPresentmentAmountCurrency.Uyw,
            "UZS" => CardPushTransferPresentmentAmountCurrency.Uzs,
            "VUV" => CardPushTransferPresentmentAmountCurrency.Vuv,
            "VES" => CardPushTransferPresentmentAmountCurrency.Ves,
            "VED" => CardPushTransferPresentmentAmountCurrency.Ved,
            "VND" => CardPushTransferPresentmentAmountCurrency.Vnd,
            "YER" => CardPushTransferPresentmentAmountCurrency.Yer,
            "ZMW" => CardPushTransferPresentmentAmountCurrency.Zmw,
            "ZWG" => CardPushTransferPresentmentAmountCurrency.Zwg,
            _ => (CardPushTransferPresentmentAmountCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardPushTransferPresentmentAmountCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardPushTransferPresentmentAmountCurrency.Afn => "AFN",
                CardPushTransferPresentmentAmountCurrency.Eur => "EUR",
                CardPushTransferPresentmentAmountCurrency.All => "ALL",
                CardPushTransferPresentmentAmountCurrency.Dzd => "DZD",
                CardPushTransferPresentmentAmountCurrency.Usd => "USD",
                CardPushTransferPresentmentAmountCurrency.Aoa => "AOA",
                CardPushTransferPresentmentAmountCurrency.Ars => "ARS",
                CardPushTransferPresentmentAmountCurrency.Amd => "AMD",
                CardPushTransferPresentmentAmountCurrency.Awg => "AWG",
                CardPushTransferPresentmentAmountCurrency.Aud => "AUD",
                CardPushTransferPresentmentAmountCurrency.Azn => "AZN",
                CardPushTransferPresentmentAmountCurrency.Bsd => "BSD",
                CardPushTransferPresentmentAmountCurrency.Bhd => "BHD",
                CardPushTransferPresentmentAmountCurrency.Bdt => "BDT",
                CardPushTransferPresentmentAmountCurrency.Bbd => "BBD",
                CardPushTransferPresentmentAmountCurrency.Byn => "BYN",
                CardPushTransferPresentmentAmountCurrency.Bzd => "BZD",
                CardPushTransferPresentmentAmountCurrency.Bmd => "BMD",
                CardPushTransferPresentmentAmountCurrency.Inr => "INR",
                CardPushTransferPresentmentAmountCurrency.Btn => "BTN",
                CardPushTransferPresentmentAmountCurrency.Bob => "BOB",
                CardPushTransferPresentmentAmountCurrency.Bov => "BOV",
                CardPushTransferPresentmentAmountCurrency.Bam => "BAM",
                CardPushTransferPresentmentAmountCurrency.Bwp => "BWP",
                CardPushTransferPresentmentAmountCurrency.Nok => "NOK",
                CardPushTransferPresentmentAmountCurrency.Brl => "BRL",
                CardPushTransferPresentmentAmountCurrency.Bnd => "BND",
                CardPushTransferPresentmentAmountCurrency.Bgn => "BGN",
                CardPushTransferPresentmentAmountCurrency.Bif => "BIF",
                CardPushTransferPresentmentAmountCurrency.Cve => "CVE",
                CardPushTransferPresentmentAmountCurrency.Khr => "KHR",
                CardPushTransferPresentmentAmountCurrency.Cad => "CAD",
                CardPushTransferPresentmentAmountCurrency.Kyd => "KYD",
                CardPushTransferPresentmentAmountCurrency.Clp => "CLP",
                CardPushTransferPresentmentAmountCurrency.Clf => "CLF",
                CardPushTransferPresentmentAmountCurrency.Cny => "CNY",
                CardPushTransferPresentmentAmountCurrency.Cop => "COP",
                CardPushTransferPresentmentAmountCurrency.Cou => "COU",
                CardPushTransferPresentmentAmountCurrency.Kmf => "KMF",
                CardPushTransferPresentmentAmountCurrency.Cdf => "CDF",
                CardPushTransferPresentmentAmountCurrency.Nzd => "NZD",
                CardPushTransferPresentmentAmountCurrency.Crc => "CRC",
                CardPushTransferPresentmentAmountCurrency.Cup => "CUP",
                CardPushTransferPresentmentAmountCurrency.Czk => "CZK",
                CardPushTransferPresentmentAmountCurrency.Dkk => "DKK",
                CardPushTransferPresentmentAmountCurrency.Djf => "DJF",
                CardPushTransferPresentmentAmountCurrency.Dop => "DOP",
                CardPushTransferPresentmentAmountCurrency.Egp => "EGP",
                CardPushTransferPresentmentAmountCurrency.Svc => "SVC",
                CardPushTransferPresentmentAmountCurrency.Ern => "ERN",
                CardPushTransferPresentmentAmountCurrency.Szl => "SZL",
                CardPushTransferPresentmentAmountCurrency.Etb => "ETB",
                CardPushTransferPresentmentAmountCurrency.Fkp => "FKP",
                CardPushTransferPresentmentAmountCurrency.Fjd => "FJD",
                CardPushTransferPresentmentAmountCurrency.Gmd => "GMD",
                CardPushTransferPresentmentAmountCurrency.Gel => "GEL",
                CardPushTransferPresentmentAmountCurrency.Ghs => "GHS",
                CardPushTransferPresentmentAmountCurrency.Gip => "GIP",
                CardPushTransferPresentmentAmountCurrency.Gtq => "GTQ",
                CardPushTransferPresentmentAmountCurrency.Gbp => "GBP",
                CardPushTransferPresentmentAmountCurrency.Gnf => "GNF",
                CardPushTransferPresentmentAmountCurrency.Gyd => "GYD",
                CardPushTransferPresentmentAmountCurrency.Htg => "HTG",
                CardPushTransferPresentmentAmountCurrency.Hnl => "HNL",
                CardPushTransferPresentmentAmountCurrency.Hkd => "HKD",
                CardPushTransferPresentmentAmountCurrency.Huf => "HUF",
                CardPushTransferPresentmentAmountCurrency.Isk => "ISK",
                CardPushTransferPresentmentAmountCurrency.Idr => "IDR",
                CardPushTransferPresentmentAmountCurrency.Irr => "IRR",
                CardPushTransferPresentmentAmountCurrency.Iqd => "IQD",
                CardPushTransferPresentmentAmountCurrency.Ils => "ILS",
                CardPushTransferPresentmentAmountCurrency.Jmd => "JMD",
                CardPushTransferPresentmentAmountCurrency.Jpy => "JPY",
                CardPushTransferPresentmentAmountCurrency.Jod => "JOD",
                CardPushTransferPresentmentAmountCurrency.Kzt => "KZT",
                CardPushTransferPresentmentAmountCurrency.Kes => "KES",
                CardPushTransferPresentmentAmountCurrency.Kpw => "KPW",
                CardPushTransferPresentmentAmountCurrency.Krw => "KRW",
                CardPushTransferPresentmentAmountCurrency.Kwd => "KWD",
                CardPushTransferPresentmentAmountCurrency.Kgs => "KGS",
                CardPushTransferPresentmentAmountCurrency.Lak => "LAK",
                CardPushTransferPresentmentAmountCurrency.Lbp => "LBP",
                CardPushTransferPresentmentAmountCurrency.Lsl => "LSL",
                CardPushTransferPresentmentAmountCurrency.Zar => "ZAR",
                CardPushTransferPresentmentAmountCurrency.Lrd => "LRD",
                CardPushTransferPresentmentAmountCurrency.Lyd => "LYD",
                CardPushTransferPresentmentAmountCurrency.Chf => "CHF",
                CardPushTransferPresentmentAmountCurrency.Mop => "MOP",
                CardPushTransferPresentmentAmountCurrency.Mkd => "MKD",
                CardPushTransferPresentmentAmountCurrency.Mga => "MGA",
                CardPushTransferPresentmentAmountCurrency.Mwk => "MWK",
                CardPushTransferPresentmentAmountCurrency.Myr => "MYR",
                CardPushTransferPresentmentAmountCurrency.Mvr => "MVR",
                CardPushTransferPresentmentAmountCurrency.Mru => "MRU",
                CardPushTransferPresentmentAmountCurrency.Mur => "MUR",
                CardPushTransferPresentmentAmountCurrency.Mxn => "MXN",
                CardPushTransferPresentmentAmountCurrency.Mxv => "MXV",
                CardPushTransferPresentmentAmountCurrency.Mdl => "MDL",
                CardPushTransferPresentmentAmountCurrency.Mnt => "MNT",
                CardPushTransferPresentmentAmountCurrency.Mad => "MAD",
                CardPushTransferPresentmentAmountCurrency.Mzn => "MZN",
                CardPushTransferPresentmentAmountCurrency.Mmk => "MMK",
                CardPushTransferPresentmentAmountCurrency.Nad => "NAD",
                CardPushTransferPresentmentAmountCurrency.Npr => "NPR",
                CardPushTransferPresentmentAmountCurrency.Nio => "NIO",
                CardPushTransferPresentmentAmountCurrency.Ngn => "NGN",
                CardPushTransferPresentmentAmountCurrency.Omr => "OMR",
                CardPushTransferPresentmentAmountCurrency.Pkr => "PKR",
                CardPushTransferPresentmentAmountCurrency.Pab => "PAB",
                CardPushTransferPresentmentAmountCurrency.Pgk => "PGK",
                CardPushTransferPresentmentAmountCurrency.Pyg => "PYG",
                CardPushTransferPresentmentAmountCurrency.Pen => "PEN",
                CardPushTransferPresentmentAmountCurrency.Php => "PHP",
                CardPushTransferPresentmentAmountCurrency.Pln => "PLN",
                CardPushTransferPresentmentAmountCurrency.Qar => "QAR",
                CardPushTransferPresentmentAmountCurrency.Ron => "RON",
                CardPushTransferPresentmentAmountCurrency.Rub => "RUB",
                CardPushTransferPresentmentAmountCurrency.Rwf => "RWF",
                CardPushTransferPresentmentAmountCurrency.Shp => "SHP",
                CardPushTransferPresentmentAmountCurrency.Wst => "WST",
                CardPushTransferPresentmentAmountCurrency.Stn => "STN",
                CardPushTransferPresentmentAmountCurrency.Sar => "SAR",
                CardPushTransferPresentmentAmountCurrency.Rsd => "RSD",
                CardPushTransferPresentmentAmountCurrency.Scr => "SCR",
                CardPushTransferPresentmentAmountCurrency.Sle => "SLE",
                CardPushTransferPresentmentAmountCurrency.Sgd => "SGD",
                CardPushTransferPresentmentAmountCurrency.Sbd => "SBD",
                CardPushTransferPresentmentAmountCurrency.Sos => "SOS",
                CardPushTransferPresentmentAmountCurrency.Ssp => "SSP",
                CardPushTransferPresentmentAmountCurrency.Lkr => "LKR",
                CardPushTransferPresentmentAmountCurrency.Sdg => "SDG",
                CardPushTransferPresentmentAmountCurrency.Srd => "SRD",
                CardPushTransferPresentmentAmountCurrency.Sek => "SEK",
                CardPushTransferPresentmentAmountCurrency.Che => "CHE",
                CardPushTransferPresentmentAmountCurrency.Chw => "CHW",
                CardPushTransferPresentmentAmountCurrency.Syp => "SYP",
                CardPushTransferPresentmentAmountCurrency.Twd => "TWD",
                CardPushTransferPresentmentAmountCurrency.Tjs => "TJS",
                CardPushTransferPresentmentAmountCurrency.Tzs => "TZS",
                CardPushTransferPresentmentAmountCurrency.Thb => "THB",
                CardPushTransferPresentmentAmountCurrency.Top => "TOP",
                CardPushTransferPresentmentAmountCurrency.Ttd => "TTD",
                CardPushTransferPresentmentAmountCurrency.Tnd => "TND",
                CardPushTransferPresentmentAmountCurrency.Try => "TRY",
                CardPushTransferPresentmentAmountCurrency.Tmt => "TMT",
                CardPushTransferPresentmentAmountCurrency.Ugx => "UGX",
                CardPushTransferPresentmentAmountCurrency.Uah => "UAH",
                CardPushTransferPresentmentAmountCurrency.Aed => "AED",
                CardPushTransferPresentmentAmountCurrency.Usn => "USN",
                CardPushTransferPresentmentAmountCurrency.Uyu => "UYU",
                CardPushTransferPresentmentAmountCurrency.Uyi => "UYI",
                CardPushTransferPresentmentAmountCurrency.Uyw => "UYW",
                CardPushTransferPresentmentAmountCurrency.Uzs => "UZS",
                CardPushTransferPresentmentAmountCurrency.Vuv => "VUV",
                CardPushTransferPresentmentAmountCurrency.Ves => "VES",
                CardPushTransferPresentmentAmountCurrency.Ved => "VED",
                CardPushTransferPresentmentAmountCurrency.Vnd => "VND",
                CardPushTransferPresentmentAmountCurrency.Yer => "YER",
                CardPushTransferPresentmentAmountCurrency.Zmw => "ZMW",
                CardPushTransferPresentmentAmountCurrency.Zwg => "ZWG",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The card network route used for the transfer.
/// </summary>
[JsonConverter(typeof(RouteConverter))]
public enum Route
{
    /// <summary>
    /// Visa and Interlink
    /// </summary>
    Visa,

    /// <summary>
    /// Mastercard and Maestro
    /// </summary>
    Mastercard,

    /// <summary>
    /// Pulse
    /// </summary>
    Pulse,
}

sealed class RouteConverter : JsonConverter<Route>
{
    public override Route Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => Route.Visa,
            "mastercard" => Route.Mastercard,
            "pulse" => Route.Pulse,
            _ => (Route)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Route value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Route.Visa => "visa",
                Route.Mastercard => "mastercard",
                Route.Pulse => "pulse",
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
[JsonConverter(typeof(CardPushTransferStatusConverter))]
public enum CardPushTransferStatus
{
    /// <summary>
    /// The transfer is pending approval.
    /// </summary>
    PendingApproval,

    /// <summary>
    /// The transfer has been canceled.
    /// </summary>
    Canceled,

    /// <summary>
    /// The transfer is pending review by Increase.
    /// </summary>
    PendingReviewing,

    /// <summary>
    /// The transfer requires attention from an Increase operator.
    /// </summary>
    RequiresAttention,

    /// <summary>
    /// The transfer is queued to be submitted to the card network.
    /// </summary>
    PendingSubmission,

    /// <summary>
    /// The transfer has been submitted and is pending a response from the card network.
    /// </summary>
    Submitted,

    /// <summary>
    /// The transfer has been sent successfully and is complete.
    /// </summary>
    Complete,

    /// <summary>
    /// The transfer was declined by the network or the recipient's bank.
    /// </summary>
    Declined,
}

sealed class CardPushTransferStatusConverter : JsonConverter<CardPushTransferStatus>
{
    public override CardPushTransferStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_approval" => CardPushTransferStatus.PendingApproval,
            "canceled" => CardPushTransferStatus.Canceled,
            "pending_reviewing" => CardPushTransferStatus.PendingReviewing,
            "requires_attention" => CardPushTransferStatus.RequiresAttention,
            "pending_submission" => CardPushTransferStatus.PendingSubmission,
            "submitted" => CardPushTransferStatus.Submitted,
            "complete" => CardPushTransferStatus.Complete,
            "declined" => CardPushTransferStatus.Declined,
            _ => (CardPushTransferStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardPushTransferStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardPushTransferStatus.PendingApproval => "pending_approval",
                CardPushTransferStatus.Canceled => "canceled",
                CardPushTransferStatus.PendingReviewing => "pending_reviewing",
                CardPushTransferStatus.RequiresAttention => "requires_attention",
                CardPushTransferStatus.PendingSubmission => "pending_submission",
                CardPushTransferStatus.Submitted => "submitted",
                CardPushTransferStatus.Complete => "complete",
                CardPushTransferStatus.Declined => "declined",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// After the transfer is submitted to the card network, this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Submission, SubmissionFromRaw>))]
public sealed record class Submission : JsonModel
{
    /// <summary>
    /// A 12-digit retrieval reference number that identifies the transfer. Usually
    /// a combination of a timestamp and the trace number.
    /// </summary>
    public required string RetrievalReferenceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("retrieval_reference_number");
        }
        init { this._rawData.Set("retrieval_reference_number", value); }
    }

    /// <summary>
    /// A unique reference for the transfer.
    /// </summary>
    public required string SenderReference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sender_reference");
        }
        init { this._rawData.Set("sender_reference", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the transfer was submitted to the card network.
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

    /// <summary>
    /// A 6-digit trace number that identifies the transfer within a small window
    /// of time.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RetrievalReferenceNumber;
        _ = this.SenderReference;
        _ = this.SubmittedAt;
        _ = this.TraceNumber;
    }

    public Submission() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Submission(Submission submission)
        : base(submission) { }
#pragma warning restore CS8618

    public Submission(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Submission(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubmissionFromRaw.FromRawUnchecked"/>
    public static Submission FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubmissionFromRaw : IFromRawJson<Submission>
{
    /// <inheritdoc/>
    public Submission FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Submission.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_push_transfer`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    CardPushTransfer,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.CardPushTransfers.Type>
{
    public override global::Increase.Api.Models.CardPushTransfers.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_push_transfer" => global::Increase
                .Api
                .Models
                .CardPushTransfers
                .Type
                .CardPushTransfer,
            _ => (global::Increase.Api.Models.CardPushTransfers.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.CardPushTransfers.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.CardPushTransfers.Type.CardPushTransfer =>
                    "card_push_transfer",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
