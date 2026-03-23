using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.CardPayments;

/// <summary>
/// Card Payments group together interactions related to a single card payment, such
/// as an authorization and its corresponding settlement.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardPayment, CardPaymentFromRaw>))]
public sealed record class CardPayment : JsonModel
{
    /// <summary>
    /// The Card Payment identifier.
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
    /// The Card identifier for this payment.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Card
    /// Payment was created.
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
    /// The Digital Wallet Token identifier for this payment.
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
    /// The interactions related to this card payment.
    /// </summary>
    public required IReadOnlyList<Element> Elements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Element>>("elements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Element>>(
                "elements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The Physical Card identifier for this payment.
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
    /// The scheme fees associated with this card payment.
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
    /// The summarized state of this card payment.
    /// </summary>
    public required State State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<State>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `card_payment`.
    /// </summary>
    public required ApiEnum<string, CardPaymentType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardPaymentType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.CardID;
        _ = this.CreatedAt;
        _ = this.DigitalWalletTokenID;
        foreach (var item in this.Elements)
        {
            item.Validate();
        }
        _ = this.PhysicalCardID;
        foreach (var item in this.SchemeFees)
        {
            item.Validate();
        }
        this.State.Validate();
        this.Type.Validate();
    }

    public CardPayment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardPayment(CardPayment cardPayment)
        : base(cardPayment) { }
#pragma warning restore CS8618

    public CardPayment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardPayment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardPaymentFromRaw.FromRawUnchecked"/>
    public static CardPayment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardPaymentFromRaw : IFromRawJson<CardPayment>
{
    /// <inheritdoc/>
    public CardPayment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardPayment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Element, ElementFromRaw>))]
public sealed record class Element : JsonModel
{
    /// <summary>
    /// The type of the resource. We may add additional possible values for this enum
    /// over time; your application should be able to handle such additions gracefully.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the card payment element was created.
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
    /// A Card Authentication object. This field will be present in the JSON response
    /// if and only if `category` is equal to `card_authentication`. Card Authentications
    /// are attempts to authenticate a transaction or a card with 3DS.
    /// </summary>
    public CardAuthentication? CardAuthentication
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardAuthentication>("card_authentication");
        }
        init { this._rawData.Set("card_authentication", value); }
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
    /// A Card Authorization Expiration object. This field will be present in the
    /// JSON response if and only if `category` is equal to `card_authorization_expiration`.
    /// Card Authorization Expirations are cancellations of authorizations that were
    /// never settled by the acquirer.
    /// </summary>
    public CardAuthorizationExpiration? CardAuthorizationExpiration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardAuthorizationExpiration>(
                "card_authorization_expiration"
            );
        }
        init { this._rawData.Set("card_authorization_expiration", value); }
    }

    /// <summary>
    /// A Card Balance Inquiry object. This field will be present in the JSON response
    /// if and only if `category` is equal to `card_balance_inquiry`. Card Balance
    /// Inquiries are transactions that allow merchants to check the available balance
    /// on a card without placing a hold on funds, commonly used when a customer
    /// requests their balance at an ATM.
    /// </summary>
    public CardBalanceInquiry? CardBalanceInquiry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardBalanceInquiry>("card_balance_inquiry");
        }
        init { this._rawData.Set("card_balance_inquiry", value); }
    }

    /// <summary>
    /// A Card Decline object. This field will be present in the JSON response if
    /// and only if `category` is equal to `card_decline`.
    /// </summary>
    public CardDecline? CardDecline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDecline>("card_decline");
        }
        init { this._rawData.Set("card_decline", value); }
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
    /// A Card Fuel Confirmation object. This field will be present in the JSON response
    /// if and only if `category` is equal to `card_fuel_confirmation`. Card Fuel
    /// Confirmations update the amount of a Card Authorization after a fuel pump
    /// transaction is completed.
    /// </summary>
    public CardFuelConfirmation? CardFuelConfirmation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardFuelConfirmation>("card_fuel_confirmation");
        }
        init { this._rawData.Set("card_fuel_confirmation", value); }
    }

    /// <summary>
    /// A Card Increment object. This field will be present in the JSON response if
    /// and only if `category` is equal to `card_increment`. Card Increments increase
    /// the pending amount of an authorized transaction.
    /// </summary>
    public CardIncrement? CardIncrement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardIncrement>("card_increment");
        }
        init { this._rawData.Set("card_increment", value); }
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
    /// A Card Reversal object. This field will be present in the JSON response if
    /// and only if `category` is equal to `card_reversal`. Card Reversals cancel
    /// parts of or the entirety of an existing Card Authorization.
    /// </summary>
    public CardReversal? CardReversal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardReversal>("card_reversal");
        }
        init { this._rawData.Set("card_reversal", value); }
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
    /// An Inbound Card Validation object. This field will be present in the JSON
    /// response if and only if `category` is equal to `card_validation`. Inbound
    /// Card Validations are requests from a merchant to verify that a card number
    /// and optionally its address and/or Card Verification Value are valid.
    /// </summary>
    public CardValidation? CardValidation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardValidation>("card_validation");
        }
        init { this._rawData.Set("card_validation", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        _ = this.CreatedAt;
        this.CardAuthentication?.Validate();
        this.CardAuthorization?.Validate();
        this.CardAuthorizationExpiration?.Validate();
        this.CardBalanceInquiry?.Validate();
        this.CardDecline?.Validate();
        this.CardFinancial?.Validate();
        this.CardFuelConfirmation?.Validate();
        this.CardIncrement?.Validate();
        this.CardRefund?.Validate();
        this.CardReversal?.Validate();
        this.CardSettlement?.Validate();
        this.CardValidation?.Validate();
        this.Other?.Validate();
    }

    public Element() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Element(Element element)
        : base(element) { }
#pragma warning restore CS8618

    public Element(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Element(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementFromRaw.FromRawUnchecked"/>
    public static Element FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementFromRaw : IFromRawJson<Element>
{
    /// <inheritdoc/>
    public Element FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Element.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the resource. We may add additional possible values for this enum
/// over time; your application should be able to handle such additions gracefully.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    /// <summary>
    /// Card Authorization: details will be under the `card_authorization` object.
    /// </summary>
    CardAuthorization,

    /// <summary>
    /// Card Authentication: details will be under the `card_authentication` object.
    /// </summary>
    CardAuthentication,

    /// <summary>
    /// Card Balance Inquiry: details will be under the `card_balance_inquiry` object.
    /// </summary>
    CardBalanceInquiry,

    /// <summary>
    /// Inbound Card Validation: details will be under the `card_validation` object.
    /// </summary>
    CardValidation,

    /// <summary>
    /// Card Decline: details will be under the `card_decline` object.
    /// </summary>
    CardDecline,

    /// <summary>
    /// Card Reversal: details will be under the `card_reversal` object.
    /// </summary>
    CardReversal,

    /// <summary>
    /// Card Authorization Expiration: details will be under the `card_authorization_expiration` object.
    /// </summary>
    CardAuthorizationExpiration,

    /// <summary>
    /// Card Increment: details will be under the `card_increment` object.
    /// </summary>
    CardIncrement,

    /// <summary>
    /// Card Settlement: details will be under the `card_settlement` object.
    /// </summary>
    CardSettlement,

    /// <summary>
    /// Card Refund: details will be under the `card_refund` object.
    /// </summary>
    CardRefund,

    /// <summary>
    /// Card Fuel Confirmation: details will be under the `card_fuel_confirmation` object.
    /// </summary>
    CardFuelConfirmation,

    /// <summary>
    /// Card Financial: details will be under the `card_financial` object.
    /// </summary>
    CardFinancial,

    /// <summary>
    /// Unknown card payment element.
    /// </summary>
    Other,
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
            "card_authorization" => Category.CardAuthorization,
            "card_authentication" => Category.CardAuthentication,
            "card_balance_inquiry" => Category.CardBalanceInquiry,
            "card_validation" => Category.CardValidation,
            "card_decline" => Category.CardDecline,
            "card_reversal" => Category.CardReversal,
            "card_authorization_expiration" => Category.CardAuthorizationExpiration,
            "card_increment" => Category.CardIncrement,
            "card_settlement" => Category.CardSettlement,
            "card_refund" => Category.CardRefund,
            "card_fuel_confirmation" => Category.CardFuelConfirmation,
            "card_financial" => Category.CardFinancial,
            "other" => Category.Other,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.CardAuthorization => "card_authorization",
                Category.CardAuthentication => "card_authentication",
                Category.CardBalanceInquiry => "card_balance_inquiry",
                Category.CardValidation => "card_validation",
                Category.CardDecline => "card_decline",
                Category.CardReversal => "card_reversal",
                Category.CardAuthorizationExpiration => "card_authorization_expiration",
                Category.CardIncrement => "card_increment",
                Category.CardSettlement => "card_settlement",
                Category.CardRefund => "card_refund",
                Category.CardFuelConfirmation => "card_fuel_confirmation",
                Category.CardFinancial => "card_financial",
                Category.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Card Authentication object. This field will be present in the JSON response
/// if and only if `category` is equal to `card_authentication`. Card Authentications
/// are attempts to authenticate a transaction or a card with 3DS.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardAuthentication, CardAuthenticationFromRaw>))]
public sealed record class CardAuthentication : JsonModel
{
    /// <summary>
    /// The Card Authentication identifier.
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
    /// A unique identifier assigned by the Access Control Server (us) for this transaction.
    /// </summary>
    public required string AccessControlServerTransactionIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "access_control_server_transaction_identifier"
            );
        }
        init { this._rawData.Set("access_control_server_transaction_identifier", value); }
    }

    /// <summary>
    /// The city of the cardholder billing address associated with the card used
    /// for this purchase.
    /// </summary>
    public required string? BillingAddressCity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_address_city");
        }
        init { this._rawData.Set("billing_address_city", value); }
    }

    /// <summary>
    /// The country of the cardholder billing address associated with the card used
    /// for this purchase.
    /// </summary>
    public required string? BillingAddressCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_address_country");
        }
        init { this._rawData.Set("billing_address_country", value); }
    }

    /// <summary>
    /// The first line of the cardholder billing address associated with the card
    /// used for this purchase.
    /// </summary>
    public required string? BillingAddressLine1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_address_line1");
        }
        init { this._rawData.Set("billing_address_line1", value); }
    }

    /// <summary>
    /// The second line of the cardholder billing address associated with the card
    /// used for this purchase.
    /// </summary>
    public required string? BillingAddressLine2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_address_line2");
        }
        init { this._rawData.Set("billing_address_line2", value); }
    }

    /// <summary>
    /// The third line of the cardholder billing address associated with the card
    /// used for this purchase.
    /// </summary>
    public required string? BillingAddressLine3
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_address_line3");
        }
        init { this._rawData.Set("billing_address_line3", value); }
    }

    /// <summary>
    /// The postal code of the cardholder billing address associated with the card
    /// used for this purchase.
    /// </summary>
    public required string? BillingAddressPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_address_postal_code");
        }
        init { this._rawData.Set("billing_address_postal_code", value); }
    }

    /// <summary>
    /// The US state of the cardholder billing address associated with the card used
    /// for this purchase.
    /// </summary>
    public required string? BillingAddressState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_address_state");
        }
        init { this._rawData.Set("billing_address_state", value); }
    }

    /// <summary>
    /// The identifier of the Card.
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
    /// The email address of the cardholder.
    /// </summary>
    public required string? CardholderEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cardholder_email");
        }
        init { this._rawData.Set("cardholder_email", value); }
    }

    /// <summary>
    /// The name of the cardholder.
    /// </summary>
    public required string? CardholderName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cardholder_name");
        }
        init { this._rawData.Set("cardholder_name", value); }
    }

    /// <summary>
    /// Details about the challenge, if one was requested.
    /// </summary>
    public required Challenge? Challenge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Challenge>("challenge");
        }
        init { this._rawData.Set("challenge", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Card
    /// Authentication was attempted.
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
    /// The reason why this authentication attempt was denied, if it was.
    /// </summary>
    public required ApiEnum<string, DenyReason>? DenyReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DenyReason>>("deny_reason");
        }
        init { this._rawData.Set("deny_reason", value); }
    }

    /// <summary>
    /// The device channel of the card authentication attempt.
    /// </summary>
    public required DeviceChannel DeviceChannel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DeviceChannel>("device_channel");
        }
        init { this._rawData.Set("device_channel", value); }
    }

    /// <summary>
    /// A unique identifier assigned by the Directory Server (the card network) for
    /// this transaction.
    /// </summary>
    public required string DirectoryServerTransactionIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("directory_server_transaction_identifier");
        }
        init { this._rawData.Set("directory_server_transaction_identifier", value); }
    }

    /// <summary>
    /// The merchant identifier (commonly abbreviated as MID) of the merchant the
    /// card is transacting with.
    /// </summary>
    public required string? MerchantAcceptorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_acceptor_id");
        }
        init { this._rawData.Set("merchant_acceptor_id", value); }
    }

    /// <summary>
    /// The Merchant Category Code (commonly abbreviated as MCC) of the merchant the
    /// card is transacting with.
    /// </summary>
    public required string? MerchantCategoryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_category_code");
        }
        init { this._rawData.Set("merchant_category_code", value); }
    }

    /// <summary>
    /// The country the merchant resides in.
    /// </summary>
    public required string? MerchantCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_country");
        }
        init { this._rawData.Set("merchant_country", value); }
    }

    /// <summary>
    /// The name of the merchant.
    /// </summary>
    public required string? MerchantName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_name");
        }
        init { this._rawData.Set("merchant_name", value); }
    }

    /// <summary>
    /// The message category of the card authentication attempt.
    /// </summary>
    public required MessageCategory MessageCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MessageCategory>("message_category");
        }
        init { this._rawData.Set("message_category", value); }
    }

    /// <summary>
    /// The ID of a prior Card Authentication that the requestor used to authenticate
    /// this cardholder for a previous transaction.
    /// </summary>
    public required string? PriorAuthenticatedCardPaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prior_authenticated_card_payment_id");
        }
        init { this._rawData.Set("prior_authenticated_card_payment_id", value); }
    }

    /// <summary>
    /// The identifier of the Real-Time Decision sent to approve or decline this
    /// authentication attempt.
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
    /// The 3DS requestor authentication indicator describes why the authentication
    /// attempt is performed, such as for a recurring transaction.
    /// </summary>
    public required ApiEnum<
        string,
        RequestorAuthenticationIndicator
    >? RequestorAuthenticationIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, RequestorAuthenticationIndicator>
            >("requestor_authentication_indicator");
        }
        init { this._rawData.Set("requestor_authentication_indicator", value); }
    }

    /// <summary>
    /// Indicates whether a challenge is requested for this transaction.
    /// </summary>
    public required ApiEnum<string, RequestorChallengeIndicator>? RequestorChallengeIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RequestorChallengeIndicator>>(
                "requestor_challenge_indicator"
            );
        }
        init { this._rawData.Set("requestor_challenge_indicator", value); }
    }

    /// <summary>
    /// The name of the 3DS requestor.
    /// </summary>
    public required string RequestorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("requestor_name");
        }
        init { this._rawData.Set("requestor_name", value); }
    }

    /// <summary>
    /// The URL of the 3DS requestor.
    /// </summary>
    public required string RequestorUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("requestor_url");
        }
        init { this._rawData.Set("requestor_url", value); }
    }

    /// <summary>
    /// The city of the shipping address associated with this purchase.
    /// </summary>
    public required string? ShippingAddressCity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_address_city");
        }
        init { this._rawData.Set("shipping_address_city", value); }
    }

    /// <summary>
    /// The country of the shipping address associated with this purchase.
    /// </summary>
    public required string? ShippingAddressCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_address_country");
        }
        init { this._rawData.Set("shipping_address_country", value); }
    }

    /// <summary>
    /// The first line of the shipping address associated with this purchase.
    /// </summary>
    public required string? ShippingAddressLine1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_address_line1");
        }
        init { this._rawData.Set("shipping_address_line1", value); }
    }

    /// <summary>
    /// The second line of the shipping address associated with this purchase.
    /// </summary>
    public required string? ShippingAddressLine2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_address_line2");
        }
        init { this._rawData.Set("shipping_address_line2", value); }
    }

    /// <summary>
    /// The third line of the shipping address associated with this purchase.
    /// </summary>
    public required string? ShippingAddressLine3
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_address_line3");
        }
        init { this._rawData.Set("shipping_address_line3", value); }
    }

    /// <summary>
    /// The postal code of the shipping address associated with this purchase.
    /// </summary>
    public required string? ShippingAddressPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_address_postal_code");
        }
        init { this._rawData.Set("shipping_address_postal_code", value); }
    }

    /// <summary>
    /// The US state of the shipping address associated with this purchase.
    /// </summary>
    public required string? ShippingAddressState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_address_state");
        }
        init { this._rawData.Set("shipping_address_state", value); }
    }

    /// <summary>
    /// The status of the card authentication.
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
    /// A unique identifier assigned by the 3DS Server initiating the authentication
    /// attempt for this transaction.
    /// </summary>
    public required string ThreeDSecureServerTransactionIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "three_d_secure_server_transaction_identifier"
            );
        }
        init { this._rawData.Set("three_d_secure_server_transaction_identifier", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `card_authentication`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.CardPayments.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.CardPayments.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccessControlServerTransactionIdentifier;
        _ = this.BillingAddressCity;
        _ = this.BillingAddressCountry;
        _ = this.BillingAddressLine1;
        _ = this.BillingAddressLine2;
        _ = this.BillingAddressLine3;
        _ = this.BillingAddressPostalCode;
        _ = this.BillingAddressState;
        _ = this.CardID;
        _ = this.CardPaymentID;
        _ = this.CardholderEmail;
        _ = this.CardholderName;
        this.Challenge?.Validate();
        _ = this.CreatedAt;
        this.DenyReason?.Validate();
        this.DeviceChannel.Validate();
        _ = this.DirectoryServerTransactionIdentifier;
        _ = this.MerchantAcceptorID;
        _ = this.MerchantCategoryCode;
        _ = this.MerchantCountry;
        _ = this.MerchantName;
        this.MessageCategory.Validate();
        _ = this.PriorAuthenticatedCardPaymentID;
        _ = this.RealTimeDecisionID;
        this.RequestorAuthenticationIndicator?.Validate();
        this.RequestorChallengeIndicator?.Validate();
        _ = this.RequestorName;
        _ = this.RequestorUrl;
        _ = this.ShippingAddressCity;
        _ = this.ShippingAddressCountry;
        _ = this.ShippingAddressLine1;
        _ = this.ShippingAddressLine2;
        _ = this.ShippingAddressLine3;
        _ = this.ShippingAddressPostalCode;
        _ = this.ShippingAddressState;
        this.Status.Validate();
        _ = this.ThreeDSecureServerTransactionIdentifier;
        this.Type.Validate();
    }

    public CardAuthentication() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthentication(CardAuthentication cardAuthentication)
        : base(cardAuthentication) { }
#pragma warning restore CS8618

    public CardAuthentication(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthentication(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthenticationFromRaw.FromRawUnchecked"/>
    public static CardAuthentication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardAuthenticationFromRaw : IFromRawJson<CardAuthentication>
{
    /// <inheritdoc/>
    public CardAuthentication FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardAuthentication.FromRawUnchecked(rawData);
}

/// <summary>
/// Details about the challenge, if one was requested.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Challenge, ChallengeFromRaw>))]
public sealed record class Challenge : JsonModel
{
    /// <summary>
    /// Details about the challenge verification attempts, if any happened.
    /// </summary>
    public required IReadOnlyList<Attempt> Attempts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Attempt>>("attempts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Attempt>>(
                "attempts",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Card
    /// Authentication Challenge was started.
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
    /// The one-time code used for the Card Authentication Challenge.
    /// </summary>
    public required string OneTimeCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("one_time_code");
        }
        init { this._rawData.Set("one_time_code", value); }
    }

    /// <summary>
    /// The identifier of the Real-Time Decision used to deliver this challenge.
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
    /// The method used to verify the Card Authentication Challenge.
    /// </summary>
    public required ApiEnum<string, VerificationMethod> VerificationMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VerificationMethod>>(
                "verification_method"
            );
        }
        init { this._rawData.Set("verification_method", value); }
    }

    /// <summary>
    /// E.g., the email address or phone number used for the Card Authentication Challenge.
    /// </summary>
    public required string? VerificationValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("verification_value");
        }
        init { this._rawData.Set("verification_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Attempts)
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        _ = this.OneTimeCode;
        _ = this.RealTimeDecisionID;
        this.VerificationMethod.Validate();
        _ = this.VerificationValue;
    }

    public Challenge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Challenge(Challenge challenge)
        : base(challenge) { }
#pragma warning restore CS8618

    public Challenge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Challenge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChallengeFromRaw.FromRawUnchecked"/>
    public static Challenge FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChallengeFromRaw : IFromRawJson<Challenge>
{
    /// <inheritdoc/>
    public Challenge FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Challenge.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Attempt, AttemptFromRaw>))]
public sealed record class Attempt : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time of the Card Authentication
    /// Challenge Attempt.
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
    /// The outcome of the Card Authentication Challenge Attempt.
    /// </summary>
    public required ApiEnum<string, Outcome> Outcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Outcome>>("outcome");
        }
        init { this._rawData.Set("outcome", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        this.Outcome.Validate();
    }

    public Attempt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Attempt(Attempt attempt)
        : base(attempt) { }
#pragma warning restore CS8618

    public Attempt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Attempt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttemptFromRaw.FromRawUnchecked"/>
    public static Attempt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttemptFromRaw : IFromRawJson<Attempt>
{
    /// <inheritdoc/>
    public Attempt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Attempt.FromRawUnchecked(rawData);
}

/// <summary>
/// The outcome of the Card Authentication Challenge Attempt.
/// </summary>
[JsonConverter(typeof(OutcomeConverter))]
public enum Outcome
{
    /// <summary>
    /// The attempt was successful.
    /// </summary>
    Successful,

    /// <summary>
    /// The attempt was unsuccessful.
    /// </summary>
    Failed,
}

sealed class OutcomeConverter : JsonConverter<Outcome>
{
    public override Outcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "successful" => Outcome.Successful,
            "failed" => Outcome.Failed,
            _ => (Outcome)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Outcome value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Outcome.Successful => "successful",
                Outcome.Failed => "failed",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The method used to verify the Card Authentication Challenge.
/// </summary>
[JsonConverter(typeof(VerificationMethodConverter))]
public enum VerificationMethod
{
    /// <summary>
    /// The one-time code was sent via text message.
    /// </summary>
    TextMessage,

    /// <summary>
    /// The one-time code was sent via email.
    /// </summary>
    Email,

    /// <summary>
    /// The one-time code was not successfully delivered.
    /// </summary>
    NoneAvailable,
}

sealed class VerificationMethodConverter : JsonConverter<VerificationMethod>
{
    public override VerificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text_message" => VerificationMethod.TextMessage,
            "email" => VerificationMethod.Email,
            "none_available" => VerificationMethod.NoneAvailable,
            _ => (VerificationMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerificationMethod.TextMessage => "text_message",
                VerificationMethod.Email => "email",
                VerificationMethod.NoneAvailable => "none_available",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The reason why this authentication attempt was denied, if it was.
/// </summary>
[JsonConverter(typeof(DenyReasonConverter))]
public enum DenyReason
{
    /// <summary>
    /// The group was locked.
    /// </summary>
    GroupLocked,

    /// <summary>
    /// The card was not active.
    /// </summary>
    CardNotActive,

    /// <summary>
    /// The entity was not active.
    /// </summary>
    EntityNotActive,

    /// <summary>
    /// The transaction was not allowed.
    /// </summary>
    TransactionNotAllowed,

    /// <summary>
    /// The webhook was denied.
    /// </summary>
    WebhookDenied,

    /// <summary>
    /// The webhook timed out.
    /// </summary>
    WebhookTimedOut,
}

sealed class DenyReasonConverter : JsonConverter<DenyReason>
{
    public override DenyReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "group_locked" => DenyReason.GroupLocked,
            "card_not_active" => DenyReason.CardNotActive,
            "entity_not_active" => DenyReason.EntityNotActive,
            "transaction_not_allowed" => DenyReason.TransactionNotAllowed,
            "webhook_denied" => DenyReason.WebhookDenied,
            "webhook_timed_out" => DenyReason.WebhookTimedOut,
            _ => (DenyReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DenyReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DenyReason.GroupLocked => "group_locked",
                DenyReason.CardNotActive => "card_not_active",
                DenyReason.EntityNotActive => "entity_not_active",
                DenyReason.TransactionNotAllowed => "transaction_not_allowed",
                DenyReason.WebhookDenied => "webhook_denied",
                DenyReason.WebhookTimedOut => "webhook_timed_out",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The device channel of the card authentication attempt.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DeviceChannel, DeviceChannelFromRaw>))]
public sealed record class DeviceChannel : JsonModel
{
    /// <summary>
    /// Fields specific to the browser device channel.
    /// </summary>
    public required Browser? Browser
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Browser>("browser");
        }
        init { this._rawData.Set("browser", value); }
    }

    /// <summary>
    /// The category of the device channel.
    /// </summary>
    public required ApiEnum<string, DeviceChannelCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DeviceChannelCategory>>(
                "category"
            );
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Fields specific to merchant initiated transactions.
    /// </summary>
    public required MerchantInitiated? MerchantInitiated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MerchantInitiated>("merchant_initiated");
        }
        init { this._rawData.Set("merchant_initiated", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Browser?.Validate();
        this.Category.Validate();
        this.MerchantInitiated?.Validate();
    }

    public DeviceChannel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeviceChannel(DeviceChannel deviceChannel)
        : base(deviceChannel) { }
#pragma warning restore CS8618

    public DeviceChannel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeviceChannel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeviceChannelFromRaw.FromRawUnchecked"/>
    public static DeviceChannel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeviceChannelFromRaw : IFromRawJson<DeviceChannel>
{
    /// <inheritdoc/>
    public DeviceChannel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DeviceChannel.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields specific to the browser device channel.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Browser, BrowserFromRaw>))]
public sealed record class Browser : JsonModel
{
    /// <summary>
    /// The accept header from the cardholder's browser.
    /// </summary>
    public required string? AcceptHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("accept_header");
        }
        init { this._rawData.Set("accept_header", value); }
    }

    /// <summary>
    /// The IP address of the cardholder's browser.
    /// </summary>
    public required string? IPAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ip_address");
        }
        init { this._rawData.Set("ip_address", value); }
    }

    /// <summary>
    /// Whether JavaScript is enabled in the cardholder's browser.
    /// </summary>
    public required ApiEnum<string, JavascriptEnabled>? JavascriptEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, JavascriptEnabled>>(
                "javascript_enabled"
            );
        }
        init { this._rawData.Set("javascript_enabled", value); }
    }

    /// <summary>
    /// The language of the cardholder's browser.
    /// </summary>
    public required string? Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("language");
        }
        init { this._rawData.Set("language", value); }
    }

    /// <summary>
    /// The user agent of the cardholder's browser.
    /// </summary>
    public required string? UserAgent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_agent");
        }
        init { this._rawData.Set("user_agent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcceptHeader;
        _ = this.IPAddress;
        this.JavascriptEnabled?.Validate();
        _ = this.Language;
        _ = this.UserAgent;
    }

    public Browser() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Browser(Browser browser)
        : base(browser) { }
#pragma warning restore CS8618

    public Browser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Browser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserFromRaw.FromRawUnchecked"/>
    public static Browser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserFromRaw : IFromRawJson<Browser>
{
    /// <inheritdoc/>
    public Browser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Browser.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether JavaScript is enabled in the cardholder's browser.
/// </summary>
[JsonConverter(typeof(JavascriptEnabledConverter))]
public enum JavascriptEnabled
{
    /// <summary>
    /// JavaScript is enabled in the cardholder's browser.
    /// </summary>
    Enabled,

    /// <summary>
    /// JavaScript is not enabled in the cardholder's browser.
    /// </summary>
    Disabled,
}

sealed class JavascriptEnabledConverter : JsonConverter<JavascriptEnabled>
{
    public override JavascriptEnabled Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enabled" => JavascriptEnabled.Enabled,
            "disabled" => JavascriptEnabled.Disabled,
            _ => (JavascriptEnabled)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JavascriptEnabled value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JavascriptEnabled.Enabled => "enabled",
                JavascriptEnabled.Disabled => "disabled",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The category of the device channel.
/// </summary>
[JsonConverter(typeof(DeviceChannelCategoryConverter))]
public enum DeviceChannelCategory
{
    /// <summary>
    /// The authentication attempt was made from an app.
    /// </summary>
    App,

    /// <summary>
    /// The authentication attempt was made from a browser.
    /// </summary>
    Browser,

    /// <summary>
    /// The authentication attempt was initiated by the 3DS Requestor.
    /// </summary>
    ThreeDSRequestorInitiated,
}

sealed class DeviceChannelCategoryConverter : JsonConverter<DeviceChannelCategory>
{
    public override DeviceChannelCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "app" => DeviceChannelCategory.App,
            "browser" => DeviceChannelCategory.Browser,
            "three_ds_requestor_initiated" => DeviceChannelCategory.ThreeDSRequestorInitiated,
            _ => (DeviceChannelCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeviceChannelCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DeviceChannelCategory.App => "app",
                DeviceChannelCategory.Browser => "browser",
                DeviceChannelCategory.ThreeDSRequestorInitiated => "three_ds_requestor_initiated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to merchant initiated transactions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MerchantInitiated, MerchantInitiatedFromRaw>))]
public sealed record class MerchantInitiated : JsonModel
{
    /// <summary>
    /// The merchant initiated indicator for the transaction.
    /// </summary>
    public required ApiEnum<string, Indicator> Indicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Indicator>>("indicator");
        }
        init { this._rawData.Set("indicator", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Indicator.Validate();
    }

    public MerchantInitiated() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MerchantInitiated(MerchantInitiated merchantInitiated)
        : base(merchantInitiated) { }
#pragma warning restore CS8618

    public MerchantInitiated(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MerchantInitiated(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MerchantInitiatedFromRaw.FromRawUnchecked"/>
    public static MerchantInitiated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MerchantInitiated(ApiEnum<string, Indicator> indicator)
        : this()
    {
        this.Indicator = indicator;
    }
}

class MerchantInitiatedFromRaw : IFromRawJson<MerchantInitiated>
{
    /// <inheritdoc/>
    public MerchantInitiated FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MerchantInitiated.FromRawUnchecked(rawData);
}

/// <summary>
/// The merchant initiated indicator for the transaction.
/// </summary>
[JsonConverter(typeof(IndicatorConverter))]
public enum Indicator
{
    /// <summary>
    /// Recurring transaction.
    /// </summary>
    RecurringTransaction,

    /// <summary>
    /// Installment transaction.
    /// </summary>
    InstallmentTransaction,

    /// <summary>
    /// Add card.
    /// </summary>
    AddCard,

    /// <summary>
    /// Maintain card information.
    /// </summary>
    MaintainCardInformation,

    /// <summary>
    /// Account verification.
    /// </summary>
    AccountVerification,

    /// <summary>
    /// Split or delayed shipment.
    /// </summary>
    SplitDelayedShipment,

    /// <summary>
    /// Top up.
    /// </summary>
    TopUp,

    /// <summary>
    /// Mail order.
    /// </summary>
    MailOrder,

    /// <summary>
    /// Telephone order.
    /// </summary>
    TelephoneOrder,

    /// <summary>
    /// Whitelist status check.
    /// </summary>
    WhitelistStatusCheck,

    /// <summary>
    /// Other payment.
    /// </summary>
    OtherPayment,

    /// <summary>
    /// Billing agreement.
    /// </summary>
    BillingAgreement,

    /// <summary>
    /// Device binding status check.
    /// </summary>
    DeviceBindingStatusCheck,

    /// <summary>
    /// Card security code status check.
    /// </summary>
    CardSecurityCodeStatusCheck,

    /// <summary>
    /// Delayed shipment.
    /// </summary>
    DelayedShipment,

    /// <summary>
    /// Split payment.
    /// </summary>
    SplitPayment,

    /// <summary>
    /// FIDO credential deletion.
    /// </summary>
    FidoCredentialDeletion,

    /// <summary>
    /// FIDO credential registration.
    /// </summary>
    FidoCredentialRegistration,

    /// <summary>
    /// Decoupled authentication fallback.
    /// </summary>
    DecoupledAuthenticationFallback,
}

sealed class IndicatorConverter : JsonConverter<Indicator>
{
    public override Indicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "recurring_transaction" => Indicator.RecurringTransaction,
            "installment_transaction" => Indicator.InstallmentTransaction,
            "add_card" => Indicator.AddCard,
            "maintain_card_information" => Indicator.MaintainCardInformation,
            "account_verification" => Indicator.AccountVerification,
            "split_delayed_shipment" => Indicator.SplitDelayedShipment,
            "top_up" => Indicator.TopUp,
            "mail_order" => Indicator.MailOrder,
            "telephone_order" => Indicator.TelephoneOrder,
            "whitelist_status_check" => Indicator.WhitelistStatusCheck,
            "other_payment" => Indicator.OtherPayment,
            "billing_agreement" => Indicator.BillingAgreement,
            "device_binding_status_check" => Indicator.DeviceBindingStatusCheck,
            "card_security_code_status_check" => Indicator.CardSecurityCodeStatusCheck,
            "delayed_shipment" => Indicator.DelayedShipment,
            "split_payment" => Indicator.SplitPayment,
            "fido_credential_deletion" => Indicator.FidoCredentialDeletion,
            "fido_credential_registration" => Indicator.FidoCredentialRegistration,
            "decoupled_authentication_fallback" => Indicator.DecoupledAuthenticationFallback,
            _ => (Indicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Indicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Indicator.RecurringTransaction => "recurring_transaction",
                Indicator.InstallmentTransaction => "installment_transaction",
                Indicator.AddCard => "add_card",
                Indicator.MaintainCardInformation => "maintain_card_information",
                Indicator.AccountVerification => "account_verification",
                Indicator.SplitDelayedShipment => "split_delayed_shipment",
                Indicator.TopUp => "top_up",
                Indicator.MailOrder => "mail_order",
                Indicator.TelephoneOrder => "telephone_order",
                Indicator.WhitelistStatusCheck => "whitelist_status_check",
                Indicator.OtherPayment => "other_payment",
                Indicator.BillingAgreement => "billing_agreement",
                Indicator.DeviceBindingStatusCheck => "device_binding_status_check",
                Indicator.CardSecurityCodeStatusCheck => "card_security_code_status_check",
                Indicator.DelayedShipment => "delayed_shipment",
                Indicator.SplitPayment => "split_payment",
                Indicator.FidoCredentialDeletion => "fido_credential_deletion",
                Indicator.FidoCredentialRegistration => "fido_credential_registration",
                Indicator.DecoupledAuthenticationFallback => "decoupled_authentication_fallback",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The message category of the card authentication attempt.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageCategory, MessageCategoryFromRaw>))]
public sealed record class MessageCategory : JsonModel
{
    /// <summary>
    /// The category of the card authentication attempt.
    /// </summary>
    public required ApiEnum<string, MessageCategoryCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MessageCategoryCategory>>(
                "category"
            );
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Fields specific to non-payment authentication attempts.
    /// </summary>
    public required NonPayment? NonPayment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NonPayment>("non_payment");
        }
        init { this._rawData.Set("non_payment", value); }
    }

    /// <summary>
    /// Fields specific to payment authentication attempts.
    /// </summary>
    public required Payment? Payment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Payment>("payment");
        }
        init { this._rawData.Set("payment", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.NonPayment?.Validate();
        this.Payment?.Validate();
    }

    public MessageCategory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageCategory(MessageCategory messageCategory)
        : base(messageCategory) { }
#pragma warning restore CS8618

    public MessageCategory(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageCategory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageCategoryFromRaw.FromRawUnchecked"/>
    public static MessageCategory FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageCategoryFromRaw : IFromRawJson<MessageCategory>
{
    /// <inheritdoc/>
    public MessageCategory FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageCategory.FromRawUnchecked(rawData);
}

/// <summary>
/// The category of the card authentication attempt.
/// </summary>
[JsonConverter(typeof(MessageCategoryCategoryConverter))]
public enum MessageCategoryCategory
{
    /// <summary>
    /// The authentication attempt is for a payment.
    /// </summary>
    PaymentAuthentication,

    /// <summary>
    /// The authentication attempt is not for a payment.
    /// </summary>
    NonPaymentAuthentication,
}

sealed class MessageCategoryCategoryConverter : JsonConverter<MessageCategoryCategory>
{
    public override MessageCategoryCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment_authentication" => MessageCategoryCategory.PaymentAuthentication,
            "non_payment_authentication" => MessageCategoryCategory.NonPaymentAuthentication,
            _ => (MessageCategoryCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageCategoryCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MessageCategoryCategory.PaymentAuthentication => "payment_authentication",
                MessageCategoryCategory.NonPaymentAuthentication => "non_payment_authentication",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Fields specific to non-payment authentication attempts.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NonPayment, NonPaymentFromRaw>))]
public sealed record class NonPayment : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public NonPayment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NonPayment(NonPayment nonPayment)
        : base(nonPayment) { }
#pragma warning restore CS8618

    public NonPayment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NonPayment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NonPaymentFromRaw.FromRawUnchecked"/>
    public static NonPayment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NonPaymentFromRaw : IFromRawJson<NonPayment>
{
    /// <inheritdoc/>
    public NonPayment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NonPayment.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields specific to payment authentication attempts.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Payment, PaymentFromRaw>))]
public sealed record class Payment : JsonModel
{
    /// <summary>
    /// The purchase amount in minor units.
    /// </summary>
    public required long PurchaseAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("purchase_amount");
        }
        init { this._rawData.Set("purchase_amount", value); }
    }

    /// <summary>
    /// The purchase amount in the cardholder's currency (i.e., USD) estimated using
    /// daily conversion rates from the card network.
    /// </summary>
    public required long? PurchaseAmountCardholderEstimated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("purchase_amount_cardholder_estimated");
        }
        init { this._rawData.Set("purchase_amount_cardholder_estimated", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the authentication
    /// attempt's purchase currency.
    /// </summary>
    public required string PurchaseCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("purchase_currency");
        }
        init { this._rawData.Set("purchase_currency", value); }
    }

    /// <summary>
    /// The type of transaction being authenticated.
    /// </summary>
    public required ApiEnum<string, TransactionType>? TransactionType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TransactionType>>(
                "transaction_type"
            );
        }
        init { this._rawData.Set("transaction_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PurchaseAmount;
        _ = this.PurchaseAmountCardholderEstimated;
        _ = this.PurchaseCurrency;
        this.TransactionType?.Validate();
    }

    public Payment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Payment(Payment payment)
        : base(payment) { }
#pragma warning restore CS8618

    public Payment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Payment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentFromRaw.FromRawUnchecked"/>
    public static Payment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentFromRaw : IFromRawJson<Payment>
{
    /// <inheritdoc/>
    public Payment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Payment.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of transaction being authenticated.
/// </summary>
[JsonConverter(typeof(TransactionTypeConverter))]
public enum TransactionType
{
    /// <summary>
    /// Purchase of goods or services.
    /// </summary>
    GoodsServicePurchase,

    /// <summary>
    /// Check acceptance.
    /// </summary>
    CheckAcceptance,

    /// <summary>
    /// Account funding.
    /// </summary>
    AccountFunding,

    /// <summary>
    /// Quasi-cash transaction.
    /// </summary>
    QuasiCashTransaction,

    /// <summary>
    /// Prepaid activation and load.
    /// </summary>
    PrepaidActivationAndLoad,
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
            "goods_service_purchase" => TransactionType.GoodsServicePurchase,
            "check_acceptance" => TransactionType.CheckAcceptance,
            "account_funding" => TransactionType.AccountFunding,
            "quasi_cash_transaction" => TransactionType.QuasiCashTransaction,
            "prepaid_activation_and_load" => TransactionType.PrepaidActivationAndLoad,
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
                TransactionType.GoodsServicePurchase => "goods_service_purchase",
                TransactionType.CheckAcceptance => "check_acceptance",
                TransactionType.AccountFunding => "account_funding",
                TransactionType.QuasiCashTransaction => "quasi_cash_transaction",
                TransactionType.PrepaidActivationAndLoad => "prepaid_activation_and_load",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The 3DS requestor authentication indicator describes why the authentication attempt
/// is performed, such as for a recurring transaction.
/// </summary>
[JsonConverter(typeof(RequestorAuthenticationIndicatorConverter))]
public enum RequestorAuthenticationIndicator
{
    /// <summary>
    /// The authentication is for a payment transaction.
    /// </summary>
    PaymentTransaction,

    /// <summary>
    /// The authentication is for a recurring transaction.
    /// </summary>
    RecurringTransaction,

    /// <summary>
    /// The authentication is for an installment transaction.
    /// </summary>
    InstallmentTransaction,

    /// <summary>
    /// The authentication is for adding a card.
    /// </summary>
    AddCard,

    /// <summary>
    /// The authentication is for maintaining a card.
    /// </summary>
    MaintainCard,

    /// <summary>
    /// The authentication is for EMV token cardholder verification.
    /// </summary>
    EmvTokenCardholderVerification,

    /// <summary>
    /// The authentication is for a billing agreement.
    /// </summary>
    BillingAgreement,
}

sealed class RequestorAuthenticationIndicatorConverter
    : JsonConverter<RequestorAuthenticationIndicator>
{
    public override RequestorAuthenticationIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment_transaction" => RequestorAuthenticationIndicator.PaymentTransaction,
            "recurring_transaction" => RequestorAuthenticationIndicator.RecurringTransaction,
            "installment_transaction" => RequestorAuthenticationIndicator.InstallmentTransaction,
            "add_card" => RequestorAuthenticationIndicator.AddCard,
            "maintain_card" => RequestorAuthenticationIndicator.MaintainCard,
            "emv_token_cardholder_verification" =>
                RequestorAuthenticationIndicator.EmvTokenCardholderVerification,
            "billing_agreement" => RequestorAuthenticationIndicator.BillingAgreement,
            _ => (RequestorAuthenticationIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RequestorAuthenticationIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RequestorAuthenticationIndicator.PaymentTransaction => "payment_transaction",
                RequestorAuthenticationIndicator.RecurringTransaction => "recurring_transaction",
                RequestorAuthenticationIndicator.InstallmentTransaction =>
                    "installment_transaction",
                RequestorAuthenticationIndicator.AddCard => "add_card",
                RequestorAuthenticationIndicator.MaintainCard => "maintain_card",
                RequestorAuthenticationIndicator.EmvTokenCardholderVerification =>
                    "emv_token_cardholder_verification",
                RequestorAuthenticationIndicator.BillingAgreement => "billing_agreement",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Indicates whether a challenge is requested for this transaction.
/// </summary>
[JsonConverter(typeof(RequestorChallengeIndicatorConverter))]
public enum RequestorChallengeIndicator
{
    /// <summary>
    /// No preference.
    /// </summary>
    NoPreference,

    /// <summary>
    /// No challenge requested.
    /// </summary>
    NoChallengeRequested,

    /// <summary>
    /// Challenge requested, 3DS Requestor preference.
    /// </summary>
    ChallengeRequested3dsRequestorPreference,

    /// <summary>
    /// Challenge requested, mandate.
    /// </summary>
    ChallengeRequestedMandate,

    /// <summary>
    /// No challenge requested, transactional risk analysis already performed.
    /// </summary>
    NoChallengeRequestedTransactionalRiskAnalysisAlreadyPerformed,

    /// <summary>
    /// No challenge requested, data share only.
    /// </summary>
    NoChallengeRequestedDataShareOnly,

    /// <summary>
    /// No challenge requested, strong consumer authentication already performed.
    /// </summary>
    NoChallengeRequestedStrongConsumerAuthenticationAlreadyPerformed,

    /// <summary>
    /// No challenge requested, utilize whitelist exemption if no challenge required.
    /// </summary>
    NoChallengeRequestedUtilizeWhitelistExemptionIfNoChallengeRequired,

    /// <summary>
    /// Challenge requested, whitelist prompt requested if challenge required.
    /// </summary>
    ChallengeRequestedWhitelistPromptRequestedIfChallengeRequired,
}

sealed class RequestorChallengeIndicatorConverter : JsonConverter<RequestorChallengeIndicator>
{
    public override RequestorChallengeIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no_preference" => RequestorChallengeIndicator.NoPreference,
            "no_challenge_requested" => RequestorChallengeIndicator.NoChallengeRequested,
            "challenge_requested_3ds_requestor_preference" =>
                RequestorChallengeIndicator.ChallengeRequested3dsRequestorPreference,
            "challenge_requested_mandate" => RequestorChallengeIndicator.ChallengeRequestedMandate,
            "no_challenge_requested_transactional_risk_analysis_already_performed" =>
                RequestorChallengeIndicator.NoChallengeRequestedTransactionalRiskAnalysisAlreadyPerformed,
            "no_challenge_requested_data_share_only" =>
                RequestorChallengeIndicator.NoChallengeRequestedDataShareOnly,
            "no_challenge_requested_strong_consumer_authentication_already_performed" =>
                RequestorChallengeIndicator.NoChallengeRequestedStrongConsumerAuthenticationAlreadyPerformed,
            "no_challenge_requested_utilize_whitelist_exemption_if_no_challenge_required" =>
                RequestorChallengeIndicator.NoChallengeRequestedUtilizeWhitelistExemptionIfNoChallengeRequired,
            "challenge_requested_whitelist_prompt_requested_if_challenge_required" =>
                RequestorChallengeIndicator.ChallengeRequestedWhitelistPromptRequestedIfChallengeRequired,
            _ => (RequestorChallengeIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RequestorChallengeIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RequestorChallengeIndicator.NoPreference => "no_preference",
                RequestorChallengeIndicator.NoChallengeRequested => "no_challenge_requested",
                RequestorChallengeIndicator.ChallengeRequested3dsRequestorPreference =>
                    "challenge_requested_3ds_requestor_preference",
                RequestorChallengeIndicator.ChallengeRequestedMandate =>
                    "challenge_requested_mandate",
                RequestorChallengeIndicator.NoChallengeRequestedTransactionalRiskAnalysisAlreadyPerformed =>
                    "no_challenge_requested_transactional_risk_analysis_already_performed",
                RequestorChallengeIndicator.NoChallengeRequestedDataShareOnly =>
                    "no_challenge_requested_data_share_only",
                RequestorChallengeIndicator.NoChallengeRequestedStrongConsumerAuthenticationAlreadyPerformed =>
                    "no_challenge_requested_strong_consumer_authentication_already_performed",
                RequestorChallengeIndicator.NoChallengeRequestedUtilizeWhitelistExemptionIfNoChallengeRequired =>
                    "no_challenge_requested_utilize_whitelist_exemption_if_no_challenge_required",
                RequestorChallengeIndicator.ChallengeRequestedWhitelistPromptRequestedIfChallengeRequired =>
                    "challenge_requested_whitelist_prompt_requested_if_challenge_required",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the card authentication.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// The authentication attempt was denied.
    /// </summary>
    Denied,

    /// <summary>
    /// The authentication attempt was authenticated with a challenge.
    /// </summary>
    AuthenticatedWithChallenge,

    /// <summary>
    /// The authentication attempt was authenticated without a challenge.
    /// </summary>
    AuthenticatedWithoutChallenge,

    /// <summary>
    /// The authentication attempt is awaiting a challenge.
    /// </summary>
    AwaitingChallenge,

    /// <summary>
    /// The authentication attempt is validating a challenge.
    /// </summary>
    ValidatingChallenge,

    /// <summary>
    /// The authentication attempt was canceled.
    /// </summary>
    Canceled,

    /// <summary>
    /// The authentication attempt timed out while awaiting a challenge.
    /// </summary>
    TimedOutAwaitingChallenge,

    /// <summary>
    /// The authentication attempt errored.
    /// </summary>
    Errored,

    /// <summary>
    /// The authentication attempt exceeded the attempt threshold.
    /// </summary>
    ExceededAttemptThreshold,
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
            "denied" => Status.Denied,
            "authenticated_with_challenge" => Status.AuthenticatedWithChallenge,
            "authenticated_without_challenge" => Status.AuthenticatedWithoutChallenge,
            "awaiting_challenge" => Status.AwaitingChallenge,
            "validating_challenge" => Status.ValidatingChallenge,
            "canceled" => Status.Canceled,
            "timed_out_awaiting_challenge" => Status.TimedOutAwaitingChallenge,
            "errored" => Status.Errored,
            "exceeded_attempt_threshold" => Status.ExceededAttemptThreshold,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Denied => "denied",
                Status.AuthenticatedWithChallenge => "authenticated_with_challenge",
                Status.AuthenticatedWithoutChallenge => "authenticated_without_challenge",
                Status.AwaitingChallenge => "awaiting_challenge",
                Status.ValidatingChallenge => "validating_challenge",
                Status.Canceled => "canceled",
                Status.TimedOutAwaitingChallenge => "timed_out_awaiting_challenge",
                Status.Errored => "errored",
                Status.ExceededAttemptThreshold => "exceeded_attempt_threshold",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_authentication`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    CardAuthentication,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.CardPayments.Type>
{
    public override global::Increase.Api.Models.CardPayments.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_authentication" => global::Increase
                .Api
                .Models
                .CardPayments
                .Type
                .CardAuthentication,
            _ => (global::Increase.Api.Models.CardPayments.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.CardPayments.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.CardPayments.Type.CardAuthentication =>
                    "card_authentication",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
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
    public required ApiEnum<string, CardAuthorizationType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardAuthorizationType>>("type");
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

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_authorization`.
/// </summary>
[JsonConverter(typeof(CardAuthorizationTypeConverter))]
public enum CardAuthorizationType
{
    CardAuthorization,
}

sealed class CardAuthorizationTypeConverter : JsonConverter<CardAuthorizationType>
{
    public override CardAuthorizationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_authorization" => CardAuthorizationType.CardAuthorization,
            _ => (CardAuthorizationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardAuthorizationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardAuthorizationType.CardAuthorization => "card_authorization",
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
/// A Card Authorization Expiration object. This field will be present in the JSON
/// response if and only if `category` is equal to `card_authorization_expiration`.
/// Card Authorization Expirations are cancellations of authorizations that were
/// never settled by the acquirer.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CardAuthorizationExpiration, CardAuthorizationExpirationFromRaw>)
)]
public sealed record class CardAuthorizationExpiration : JsonModel
{
    /// <summary>
    /// The Card Authorization Expiration identifier.
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
    /// The identifier for the Card Authorization this reverses.
    /// </summary>
    public required string CardAuthorizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("card_authorization_id");
        }
        init { this._rawData.Set("card_authorization_id", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the reversal's currency.
    /// </summary>
    public required ApiEnum<string, CardAuthorizationExpirationCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardAuthorizationExpirationCurrency>
            >("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The amount of this authorization expiration in the minor unit of the transaction's
    /// currency. For dollars, for example, this is cents.
    /// </summary>
    public required long ExpiredAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("expired_amount");
        }
        init { this._rawData.Set("expired_amount", value); }
    }

    /// <summary>
    /// The card network used to process this card authorization.
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
    /// A constant representing the object's type. For this resource it will always
    /// be `card_authorization_expiration`.
    /// </summary>
    public required ApiEnum<string, CardAuthorizationExpirationType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardAuthorizationExpirationType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CardAuthorizationID;
        this.Currency.Validate();
        _ = this.ExpiredAmount;
        this.Network.Validate();
        this.Type.Validate();
    }

    public CardAuthorizationExpiration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorizationExpiration(CardAuthorizationExpiration cardAuthorizationExpiration)
        : base(cardAuthorizationExpiration) { }
#pragma warning restore CS8618

    public CardAuthorizationExpiration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorizationExpiration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthorizationExpirationFromRaw.FromRawUnchecked"/>
    public static CardAuthorizationExpiration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardAuthorizationExpirationFromRaw : IFromRawJson<CardAuthorizationExpiration>
{
    /// <inheritdoc/>
    public CardAuthorizationExpiration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardAuthorizationExpiration.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the reversal's currency.
/// </summary>
[JsonConverter(typeof(CardAuthorizationExpirationCurrencyConverter))]
public enum CardAuthorizationExpirationCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardAuthorizationExpirationCurrencyConverter
    : JsonConverter<CardAuthorizationExpirationCurrency>
{
    public override CardAuthorizationExpirationCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardAuthorizationExpirationCurrency.Usd,
            _ => (CardAuthorizationExpirationCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardAuthorizationExpirationCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardAuthorizationExpirationCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The card network used to process this card authorization.
/// </summary>
[JsonConverter(typeof(NetworkConverter))]
public enum Network
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
/// A constant representing the object's type. For this resource it will always be `card_authorization_expiration`.
/// </summary>
[JsonConverter(typeof(CardAuthorizationExpirationTypeConverter))]
public enum CardAuthorizationExpirationType
{
    CardAuthorizationExpiration,
}

sealed class CardAuthorizationExpirationTypeConverter
    : JsonConverter<CardAuthorizationExpirationType>
{
    public override CardAuthorizationExpirationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_authorization_expiration" =>
                CardAuthorizationExpirationType.CardAuthorizationExpiration,
            _ => (CardAuthorizationExpirationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardAuthorizationExpirationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardAuthorizationExpirationType.CardAuthorizationExpiration =>
                    "card_authorization_expiration",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Card Balance Inquiry object. This field will be present in the JSON response
/// if and only if `category` is equal to `card_balance_inquiry`. Card Balance Inquiries
/// are transactions that allow merchants to check the available balance on a card
/// without placing a hold on funds, commonly used when a customer requests their
/// balance at an ATM.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardBalanceInquiry, CardBalanceInquiryFromRaw>))]
public sealed record class CardBalanceInquiry : JsonModel
{
    /// <summary>
    /// The Card Balance Inquiry identifier.
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
    /// Additional amounts associated with the card authorization, such as ATM surcharges
    /// fees. These are usually a subset of the `amount` field and are used to provide
    /// more detailed information about the transaction.
    /// </summary>
    public required CardBalanceInquiryAdditionalAmounts AdditionalAmounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardBalanceInquiryAdditionalAmounts>(
                "additional_amounts"
            );
        }
        init { this._rawData.Set("additional_amounts", value); }
    }

    /// <summary>
    /// The balance amount in the minor unit of the account's currency. For dollars,
    /// for example, this is cents.
    /// </summary>
    public required long Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("balance");
        }
        init { this._rawData.Set("balance", value); }
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the account's currency.
    /// </summary>
    public required ApiEnum<string, CardBalanceInquiryCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardBalanceInquiryCurrency>>(
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
    public required CardBalanceInquiryNetworkDetails NetworkDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardBalanceInquiryNetworkDetails>(
                "network_details"
            );
        }
        init { this._rawData.Set("network_details", value); }
    }

    /// <summary>
    /// Network-specific identifiers for a specific request or transaction.
    /// </summary>
    public required CardBalanceInquiryNetworkIdentifiers NetworkIdentifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardBalanceInquiryNetworkIdentifiers>(
                "network_identifiers"
            );
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
    /// be `card_balance_inquiry`.
    /// </summary>
    public required ApiEnum<string, CardBalanceInquiryType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardBalanceInquiryType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Fields related to verification of cardholder-provided values.
    /// </summary>
    public required CardBalanceInquiryVerification Verification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardBalanceInquiryVerification>("verification");
        }
        init { this._rawData.Set("verification", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.AdditionalAmounts.Validate();
        _ = this.Balance;
        _ = this.CardPaymentID;
        this.Currency.Validate();
        _ = this.DigitalWalletTokenID;
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
        _ = this.RealTimeDecisionID;
        _ = this.TerminalID;
        this.Type.Validate();
        this.Verification.Validate();
    }

    public CardBalanceInquiry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiry(CardBalanceInquiry cardBalanceInquiry)
        : base(cardBalanceInquiry) { }
#pragma warning restore CS8618

    public CardBalanceInquiry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryFromRaw : IFromRawJson<CardBalanceInquiry>
{
    /// <inheritdoc/>
    public CardBalanceInquiry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardBalanceInquiry.FromRawUnchecked(rawData);
}

/// <summary>
/// Additional amounts associated with the card authorization, such as ATM surcharges
/// fees. These are usually a subset of the `amount` field and are used to provide
/// more detailed information about the transaction.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryAdditionalAmounts,
        CardBalanceInquiryAdditionalAmountsFromRaw
    >)
)]
public sealed record class CardBalanceInquiryAdditionalAmounts : JsonModel
{
    /// <summary>
    /// The part of this transaction amount that was for clinic-related services.
    /// </summary>
    public required CardBalanceInquiryAdditionalAmountsClinic? Clinic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardBalanceInquiryAdditionalAmountsClinic>(
                "clinic"
            );
        }
        init { this._rawData.Set("clinic", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for dental-related services.
    /// </summary>
    public required CardBalanceInquiryAdditionalAmountsDental? Dental
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardBalanceInquiryAdditionalAmountsDental>(
                "dental"
            );
        }
        init { this._rawData.Set("dental", value); }
    }

    /// <summary>
    /// The original pre-authorized amount.
    /// </summary>
    public required CardBalanceInquiryAdditionalAmountsOriginal? Original
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardBalanceInquiryAdditionalAmountsOriginal>(
                "original"
            );
        }
        init { this._rawData.Set("original", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for healthcare prescriptions.
    /// </summary>
    public required CardBalanceInquiryAdditionalAmountsPrescription? Prescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardBalanceInquiryAdditionalAmountsPrescription>(
                "prescription"
            );
        }
        init { this._rawData.Set("prescription", value); }
    }

    /// <summary>
    /// The surcharge amount charged for this transaction by the merchant.
    /// </summary>
    public required CardBalanceInquiryAdditionalAmountsSurcharge? Surcharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardBalanceInquiryAdditionalAmountsSurcharge>(
                "surcharge"
            );
        }
        init { this._rawData.Set("surcharge", value); }
    }

    /// <summary>
    /// The total amount of a series of incremental authorizations, optionally provided.
    /// </summary>
    public required CardBalanceInquiryAdditionalAmountsTotalCumulative? TotalCumulative
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardBalanceInquiryAdditionalAmountsTotalCumulative>(
                "total_cumulative"
            );
        }
        init { this._rawData.Set("total_cumulative", value); }
    }

    /// <summary>
    /// The total amount of healthcare-related additional amounts.
    /// </summary>
    public required CardBalanceInquiryAdditionalAmountsTotalHealthcare? TotalHealthcare
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardBalanceInquiryAdditionalAmountsTotalHealthcare>(
                "total_healthcare"
            );
        }
        init { this._rawData.Set("total_healthcare", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for transit-related services.
    /// </summary>
    public required CardBalanceInquiryAdditionalAmountsTransit? Transit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardBalanceInquiryAdditionalAmountsTransit>(
                "transit"
            );
        }
        init { this._rawData.Set("transit", value); }
    }

    /// <summary>
    /// An unknown additional amount.
    /// </summary>
    public required CardBalanceInquiryAdditionalAmountsUnknown? Unknown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardBalanceInquiryAdditionalAmountsUnknown>(
                "unknown"
            );
        }
        init { this._rawData.Set("unknown", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for vision-related services.
    /// </summary>
    public required CardBalanceInquiryAdditionalAmountsVision? Vision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardBalanceInquiryAdditionalAmountsVision>(
                "vision"
            );
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

    public CardBalanceInquiryAdditionalAmounts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryAdditionalAmounts(
        CardBalanceInquiryAdditionalAmounts cardBalanceInquiryAdditionalAmounts
    )
        : base(cardBalanceInquiryAdditionalAmounts) { }
#pragma warning restore CS8618

    public CardBalanceInquiryAdditionalAmounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryAdditionalAmounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryAdditionalAmountsFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryAdditionalAmounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryAdditionalAmountsFromRaw : IFromRawJson<CardBalanceInquiryAdditionalAmounts>
{
    /// <inheritdoc/>
    public CardBalanceInquiryAdditionalAmounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryAdditionalAmounts.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for clinic-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryAdditionalAmountsClinic,
        CardBalanceInquiryAdditionalAmountsClinicFromRaw
    >)
)]
public sealed record class CardBalanceInquiryAdditionalAmountsClinic : JsonModel
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

    public CardBalanceInquiryAdditionalAmountsClinic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryAdditionalAmountsClinic(
        CardBalanceInquiryAdditionalAmountsClinic cardBalanceInquiryAdditionalAmountsClinic
    )
        : base(cardBalanceInquiryAdditionalAmountsClinic) { }
#pragma warning restore CS8618

    public CardBalanceInquiryAdditionalAmountsClinic(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryAdditionalAmountsClinic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryAdditionalAmountsClinicFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryAdditionalAmountsClinic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryAdditionalAmountsClinicFromRaw
    : IFromRawJson<CardBalanceInquiryAdditionalAmountsClinic>
{
    /// <inheritdoc/>
    public CardBalanceInquiryAdditionalAmountsClinic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryAdditionalAmountsClinic.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for dental-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryAdditionalAmountsDental,
        CardBalanceInquiryAdditionalAmountsDentalFromRaw
    >)
)]
public sealed record class CardBalanceInquiryAdditionalAmountsDental : JsonModel
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

    public CardBalanceInquiryAdditionalAmountsDental() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryAdditionalAmountsDental(
        CardBalanceInquiryAdditionalAmountsDental cardBalanceInquiryAdditionalAmountsDental
    )
        : base(cardBalanceInquiryAdditionalAmountsDental) { }
#pragma warning restore CS8618

    public CardBalanceInquiryAdditionalAmountsDental(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryAdditionalAmountsDental(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryAdditionalAmountsDentalFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryAdditionalAmountsDental FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryAdditionalAmountsDentalFromRaw
    : IFromRawJson<CardBalanceInquiryAdditionalAmountsDental>
{
    /// <inheritdoc/>
    public CardBalanceInquiryAdditionalAmountsDental FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryAdditionalAmountsDental.FromRawUnchecked(rawData);
}

/// <summary>
/// The original pre-authorized amount.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryAdditionalAmountsOriginal,
        CardBalanceInquiryAdditionalAmountsOriginalFromRaw
    >)
)]
public sealed record class CardBalanceInquiryAdditionalAmountsOriginal : JsonModel
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

    public CardBalanceInquiryAdditionalAmountsOriginal() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryAdditionalAmountsOriginal(
        CardBalanceInquiryAdditionalAmountsOriginal cardBalanceInquiryAdditionalAmountsOriginal
    )
        : base(cardBalanceInquiryAdditionalAmountsOriginal) { }
#pragma warning restore CS8618

    public CardBalanceInquiryAdditionalAmountsOriginal(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryAdditionalAmountsOriginal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryAdditionalAmountsOriginalFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryAdditionalAmountsOriginal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryAdditionalAmountsOriginalFromRaw
    : IFromRawJson<CardBalanceInquiryAdditionalAmountsOriginal>
{
    /// <inheritdoc/>
    public CardBalanceInquiryAdditionalAmountsOriginal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryAdditionalAmountsOriginal.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for healthcare prescriptions.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryAdditionalAmountsPrescription,
        CardBalanceInquiryAdditionalAmountsPrescriptionFromRaw
    >)
)]
public sealed record class CardBalanceInquiryAdditionalAmountsPrescription : JsonModel
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

    public CardBalanceInquiryAdditionalAmountsPrescription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryAdditionalAmountsPrescription(
        CardBalanceInquiryAdditionalAmountsPrescription cardBalanceInquiryAdditionalAmountsPrescription
    )
        : base(cardBalanceInquiryAdditionalAmountsPrescription) { }
#pragma warning restore CS8618

    public CardBalanceInquiryAdditionalAmountsPrescription(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryAdditionalAmountsPrescription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryAdditionalAmountsPrescriptionFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryAdditionalAmountsPrescription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryAdditionalAmountsPrescriptionFromRaw
    : IFromRawJson<CardBalanceInquiryAdditionalAmountsPrescription>
{
    /// <inheritdoc/>
    public CardBalanceInquiryAdditionalAmountsPrescription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryAdditionalAmountsPrescription.FromRawUnchecked(rawData);
}

/// <summary>
/// The surcharge amount charged for this transaction by the merchant.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryAdditionalAmountsSurcharge,
        CardBalanceInquiryAdditionalAmountsSurchargeFromRaw
    >)
)]
public sealed record class CardBalanceInquiryAdditionalAmountsSurcharge : JsonModel
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

    public CardBalanceInquiryAdditionalAmountsSurcharge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryAdditionalAmountsSurcharge(
        CardBalanceInquiryAdditionalAmountsSurcharge cardBalanceInquiryAdditionalAmountsSurcharge
    )
        : base(cardBalanceInquiryAdditionalAmountsSurcharge) { }
#pragma warning restore CS8618

    public CardBalanceInquiryAdditionalAmountsSurcharge(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryAdditionalAmountsSurcharge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryAdditionalAmountsSurchargeFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryAdditionalAmountsSurcharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryAdditionalAmountsSurchargeFromRaw
    : IFromRawJson<CardBalanceInquiryAdditionalAmountsSurcharge>
{
    /// <inheritdoc/>
    public CardBalanceInquiryAdditionalAmountsSurcharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryAdditionalAmountsSurcharge.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of a series of incremental authorizations, optionally provided.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryAdditionalAmountsTotalCumulative,
        CardBalanceInquiryAdditionalAmountsTotalCumulativeFromRaw
    >)
)]
public sealed record class CardBalanceInquiryAdditionalAmountsTotalCumulative : JsonModel
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

    public CardBalanceInquiryAdditionalAmountsTotalCumulative() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryAdditionalAmountsTotalCumulative(
        CardBalanceInquiryAdditionalAmountsTotalCumulative cardBalanceInquiryAdditionalAmountsTotalCumulative
    )
        : base(cardBalanceInquiryAdditionalAmountsTotalCumulative) { }
#pragma warning restore CS8618

    public CardBalanceInquiryAdditionalAmountsTotalCumulative(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryAdditionalAmountsTotalCumulative(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryAdditionalAmountsTotalCumulativeFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryAdditionalAmountsTotalCumulative FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryAdditionalAmountsTotalCumulativeFromRaw
    : IFromRawJson<CardBalanceInquiryAdditionalAmountsTotalCumulative>
{
    /// <inheritdoc/>
    public CardBalanceInquiryAdditionalAmountsTotalCumulative FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryAdditionalAmountsTotalCumulative.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of healthcare-related additional amounts.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryAdditionalAmountsTotalHealthcare,
        CardBalanceInquiryAdditionalAmountsTotalHealthcareFromRaw
    >)
)]
public sealed record class CardBalanceInquiryAdditionalAmountsTotalHealthcare : JsonModel
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

    public CardBalanceInquiryAdditionalAmountsTotalHealthcare() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryAdditionalAmountsTotalHealthcare(
        CardBalanceInquiryAdditionalAmountsTotalHealthcare cardBalanceInquiryAdditionalAmountsTotalHealthcare
    )
        : base(cardBalanceInquiryAdditionalAmountsTotalHealthcare) { }
#pragma warning restore CS8618

    public CardBalanceInquiryAdditionalAmountsTotalHealthcare(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryAdditionalAmountsTotalHealthcare(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryAdditionalAmountsTotalHealthcareFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryAdditionalAmountsTotalHealthcare FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryAdditionalAmountsTotalHealthcareFromRaw
    : IFromRawJson<CardBalanceInquiryAdditionalAmountsTotalHealthcare>
{
    /// <inheritdoc/>
    public CardBalanceInquiryAdditionalAmountsTotalHealthcare FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryAdditionalAmountsTotalHealthcare.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for transit-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryAdditionalAmountsTransit,
        CardBalanceInquiryAdditionalAmountsTransitFromRaw
    >)
)]
public sealed record class CardBalanceInquiryAdditionalAmountsTransit : JsonModel
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

    public CardBalanceInquiryAdditionalAmountsTransit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryAdditionalAmountsTransit(
        CardBalanceInquiryAdditionalAmountsTransit cardBalanceInquiryAdditionalAmountsTransit
    )
        : base(cardBalanceInquiryAdditionalAmountsTransit) { }
#pragma warning restore CS8618

    public CardBalanceInquiryAdditionalAmountsTransit(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryAdditionalAmountsTransit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryAdditionalAmountsTransitFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryAdditionalAmountsTransit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryAdditionalAmountsTransitFromRaw
    : IFromRawJson<CardBalanceInquiryAdditionalAmountsTransit>
{
    /// <inheritdoc/>
    public CardBalanceInquiryAdditionalAmountsTransit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryAdditionalAmountsTransit.FromRawUnchecked(rawData);
}

/// <summary>
/// An unknown additional amount.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryAdditionalAmountsUnknown,
        CardBalanceInquiryAdditionalAmountsUnknownFromRaw
    >)
)]
public sealed record class CardBalanceInquiryAdditionalAmountsUnknown : JsonModel
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

    public CardBalanceInquiryAdditionalAmountsUnknown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryAdditionalAmountsUnknown(
        CardBalanceInquiryAdditionalAmountsUnknown cardBalanceInquiryAdditionalAmountsUnknown
    )
        : base(cardBalanceInquiryAdditionalAmountsUnknown) { }
#pragma warning restore CS8618

    public CardBalanceInquiryAdditionalAmountsUnknown(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryAdditionalAmountsUnknown(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryAdditionalAmountsUnknownFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryAdditionalAmountsUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryAdditionalAmountsUnknownFromRaw
    : IFromRawJson<CardBalanceInquiryAdditionalAmountsUnknown>
{
    /// <inheritdoc/>
    public CardBalanceInquiryAdditionalAmountsUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryAdditionalAmountsUnknown.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for vision-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryAdditionalAmountsVision,
        CardBalanceInquiryAdditionalAmountsVisionFromRaw
    >)
)]
public sealed record class CardBalanceInquiryAdditionalAmountsVision : JsonModel
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

    public CardBalanceInquiryAdditionalAmountsVision() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryAdditionalAmountsVision(
        CardBalanceInquiryAdditionalAmountsVision cardBalanceInquiryAdditionalAmountsVision
    )
        : base(cardBalanceInquiryAdditionalAmountsVision) { }
#pragma warning restore CS8618

    public CardBalanceInquiryAdditionalAmountsVision(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryAdditionalAmountsVision(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryAdditionalAmountsVisionFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryAdditionalAmountsVision FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryAdditionalAmountsVisionFromRaw
    : IFromRawJson<CardBalanceInquiryAdditionalAmountsVision>
{
    /// <inheritdoc/>
    public CardBalanceInquiryAdditionalAmountsVision FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryAdditionalAmountsVision.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the account's currency.
/// </summary>
[JsonConverter(typeof(CardBalanceInquiryCurrencyConverter))]
public enum CardBalanceInquiryCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardBalanceInquiryCurrencyConverter : JsonConverter<CardBalanceInquiryCurrency>
{
    public override CardBalanceInquiryCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardBalanceInquiryCurrency.Usd,
            _ => (CardBalanceInquiryCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardBalanceInquiryCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardBalanceInquiryCurrency.Usd => "USD",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryNetworkDetails,
        CardBalanceInquiryNetworkDetailsFromRaw
    >)
)]
public sealed record class CardBalanceInquiryNetworkDetails : JsonModel
{
    /// <summary>
    /// The payment network used to process this card authorization.
    /// </summary>
    public required ApiEnum<string, CardBalanceInquiryNetworkDetailsCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardBalanceInquiryNetworkDetailsCategory>
            >("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Fields specific to the `pulse` network.
    /// </summary>
    public required CardBalanceInquiryNetworkDetailsPulse? Pulse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardBalanceInquiryNetworkDetailsPulse>("pulse");
        }
        init { this._rawData.Set("pulse", value); }
    }

    /// <summary>
    /// Fields specific to the `visa` network.
    /// </summary>
    public required CardBalanceInquiryNetworkDetailsVisa? Visa
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardBalanceInquiryNetworkDetailsVisa>("visa");
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

    public CardBalanceInquiryNetworkDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryNetworkDetails(
        CardBalanceInquiryNetworkDetails cardBalanceInquiryNetworkDetails
    )
        : base(cardBalanceInquiryNetworkDetails) { }
#pragma warning restore CS8618

    public CardBalanceInquiryNetworkDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryNetworkDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryNetworkDetailsFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryNetworkDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryNetworkDetailsFromRaw : IFromRawJson<CardBalanceInquiryNetworkDetails>
{
    /// <inheritdoc/>
    public CardBalanceInquiryNetworkDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryNetworkDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// The payment network used to process this card authorization.
/// </summary>
[JsonConverter(typeof(CardBalanceInquiryNetworkDetailsCategoryConverter))]
public enum CardBalanceInquiryNetworkDetailsCategory
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

sealed class CardBalanceInquiryNetworkDetailsCategoryConverter
    : JsonConverter<CardBalanceInquiryNetworkDetailsCategory>
{
    public override CardBalanceInquiryNetworkDetailsCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => CardBalanceInquiryNetworkDetailsCategory.Visa,
            "pulse" => CardBalanceInquiryNetworkDetailsCategory.Pulse,
            _ => (CardBalanceInquiryNetworkDetailsCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardBalanceInquiryNetworkDetailsCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardBalanceInquiryNetworkDetailsCategory.Visa => "visa",
                CardBalanceInquiryNetworkDetailsCategory.Pulse => "pulse",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryNetworkDetailsPulse,
        CardBalanceInquiryNetworkDetailsPulseFromRaw
    >)
)]
public sealed record class CardBalanceInquiryNetworkDetailsPulse : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public CardBalanceInquiryNetworkDetailsPulse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryNetworkDetailsPulse(
        CardBalanceInquiryNetworkDetailsPulse cardBalanceInquiryNetworkDetailsPulse
    )
        : base(cardBalanceInquiryNetworkDetailsPulse) { }
#pragma warning restore CS8618

    public CardBalanceInquiryNetworkDetailsPulse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryNetworkDetailsPulse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryNetworkDetailsPulseFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryNetworkDetailsPulse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryNetworkDetailsPulseFromRaw
    : IFromRawJson<CardBalanceInquiryNetworkDetailsPulse>
{
    /// <inheritdoc/>
    public CardBalanceInquiryNetworkDetailsPulse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryNetworkDetailsPulse.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields specific to the `visa` network.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryNetworkDetailsVisa,
        CardBalanceInquiryNetworkDetailsVisaFromRaw
    >)
)]
public sealed record class CardBalanceInquiryNetworkDetailsVisa : JsonModel
{
    /// <summary>
    /// For electronic commerce transactions, this identifies the level of security
    /// used in obtaining the customer's payment credential. For mail or telephone
    /// order transactions, identifies the type of mail or telephone order.
    /// </summary>
    public required ApiEnum<
        string,
        CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator
    >? ElectronicCommerceIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator>
            >("electronic_commerce_indicator");
        }
        init { this._rawData.Set("electronic_commerce_indicator", value); }
    }

    /// <summary>
    /// The method used to enter the cardholder's primary account number and card
    /// expiration date.
    /// </summary>
    public required ApiEnum<
        string,
        CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode
    >? PointOfServiceEntryMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode>
            >("point_of_service_entry_mode");
        }
        init { this._rawData.Set("point_of_service_entry_mode", value); }
    }

    /// <summary>
    /// Only present when `actioner: network`. Describes why a card authorization
    /// was approved or declined by Visa through stand-in processing.
    /// </summary>
    public required ApiEnum<
        string,
        CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason
    >? StandInProcessingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason>
            >("stand_in_processing_reason");
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
    public required ApiEnum<
        string,
        CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability
    >? TerminalEntryCapability
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability>
            >("terminal_entry_capability");
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

    public CardBalanceInquiryNetworkDetailsVisa() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryNetworkDetailsVisa(
        CardBalanceInquiryNetworkDetailsVisa cardBalanceInquiryNetworkDetailsVisa
    )
        : base(cardBalanceInquiryNetworkDetailsVisa) { }
#pragma warning restore CS8618

    public CardBalanceInquiryNetworkDetailsVisa(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryNetworkDetailsVisa(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryNetworkDetailsVisaFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryNetworkDetailsVisa FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryNetworkDetailsVisaFromRaw
    : IFromRawJson<CardBalanceInquiryNetworkDetailsVisa>
{
    /// <inheritdoc/>
    public CardBalanceInquiryNetworkDetailsVisa FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryNetworkDetailsVisa.FromRawUnchecked(rawData);
}

/// <summary>
/// For electronic commerce transactions, this identifies the level of security used
/// in obtaining the customer's payment credential. For mail or telephone order transactions,
/// identifies the type of mail or telephone order.
/// </summary>
[JsonConverter(typeof(CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicatorConverter))]
public enum CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator
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

sealed class CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicatorConverter
    : JsonConverter<CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator>
{
    public override CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mail_phone_order" =>
                CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
            "recurring" =>
                CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.Recurring,
            "installment" =>
                CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.Installment,
            "unknown_mail_phone_order" =>
                CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.UnknownMailPhoneOrder,
            "secure_electronic_commerce" =>
                CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.SecureElectronicCommerce,
            "non_authenticated_security_transaction_at_3ds_capable_merchant" =>
                CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant,
            "non_authenticated_security_transaction" =>
                CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction,
            "non_secure_transaction" =>
                CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonSecureTransaction,
            _ => (CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder =>
                    "mail_phone_order",
                CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.Recurring =>
                    "recurring",
                CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.Installment =>
                    "installment",
                CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.UnknownMailPhoneOrder =>
                    "unknown_mail_phone_order",
                CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.SecureElectronicCommerce =>
                    "secure_electronic_commerce",
                CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant =>
                    "non_authenticated_security_transaction_at_3ds_capable_merchant",
                CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction =>
                    "non_authenticated_security_transaction",
                CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonSecureTransaction =>
                    "non_secure_transaction",
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
[JsonConverter(typeof(CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryModeConverter))]
public enum CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode
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

sealed class CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryModeConverter
    : JsonConverter<CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode>
{
    public override CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" => CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
            "manual" => CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Manual,
            "magnetic_stripe_no_cvv" =>
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripeNoCvv,
            "optical_code" =>
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.OpticalCode,
            "integrated_circuit_card" =>
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCard,
            "contactless" =>
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Contactless,
            "credential_on_file" =>
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.CredentialOnFile,
            "magnetic_stripe" =>
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripe,
            "contactless_magnetic_stripe" =>
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.ContactlessMagneticStripe,
            "integrated_circuit_card_no_cvv" =>
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCardNoCvv,
            _ => (CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown => "unknown",
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Manual => "manual",
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripeNoCvv =>
                    "magnetic_stripe_no_cvv",
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.OpticalCode =>
                    "optical_code",
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCard =>
                    "integrated_circuit_card",
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Contactless =>
                    "contactless",
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.CredentialOnFile =>
                    "credential_on_file",
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripe =>
                    "magnetic_stripe",
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.ContactlessMagneticStripe =>
                    "contactless_magnetic_stripe",
                CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCardNoCvv =>
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
[JsonConverter(typeof(CardBalanceInquiryNetworkDetailsVisaStandInProcessingReasonConverter))]
public enum CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason
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

sealed class CardBalanceInquiryNetworkDetailsVisaStandInProcessingReasonConverter
    : JsonConverter<CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason>
{
    public override CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "issuer_error" =>
                CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
            "invalid_physical_card" =>
                CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidPhysicalCard,
            "invalid_cryptogram" =>
                CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidCryptogram,
            "invalid_cardholder_authentication_verification_value" =>
                CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidCardholderAuthenticationVerificationValue,
            "internal_visa_error" =>
                CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InternalVisaError,
            "merchant_transaction_advisory_service_authentication_required" =>
                CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired,
            "payment_fraud_disruption_acquirer_block" =>
                CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.PaymentFraudDisruptionAcquirerBlock,
            "other" => CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.Other,
            _ => (CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError =>
                    "issuer_error",
                CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidPhysicalCard =>
                    "invalid_physical_card",
                CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidCryptogram =>
                    "invalid_cryptogram",
                CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidCardholderAuthenticationVerificationValue =>
                    "invalid_cardholder_authentication_verification_value",
                CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InternalVisaError =>
                    "internal_visa_error",
                CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired =>
                    "merchant_transaction_advisory_service_authentication_required",
                CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.PaymentFraudDisruptionAcquirerBlock =>
                    "payment_fraud_disruption_acquirer_block",
                CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.Other => "other",
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
[JsonConverter(typeof(CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapabilityConverter))]
public enum CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability
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

sealed class CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapabilityConverter
    : JsonConverter<CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability>
{
    public override CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" => CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
            "terminal_not_used" =>
                CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.TerminalNotUsed,
            "magnetic_stripe" =>
                CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.MagneticStripe,
            "barcode" => CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Barcode,
            "optical_character_recognition" =>
                CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.OpticalCharacterRecognition,
            "chip_or_contactless" =>
                CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.ChipOrContactless,
            "contactless_only" =>
                CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.ContactlessOnly,
            "no_capability" =>
                CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.NoCapability,
            _ => (CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown => "unknown",
                CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.TerminalNotUsed =>
                    "terminal_not_used",
                CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.MagneticStripe =>
                    "magnetic_stripe",
                CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Barcode => "barcode",
                CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.OpticalCharacterRecognition =>
                    "optical_character_recognition",
                CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.ChipOrContactless =>
                    "chip_or_contactless",
                CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.ContactlessOnly =>
                    "contactless_only",
                CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.NoCapability =>
                    "no_capability",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryNetworkIdentifiers,
        CardBalanceInquiryNetworkIdentifiersFromRaw
    >)
)]
public sealed record class CardBalanceInquiryNetworkIdentifiers : JsonModel
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

    public CardBalanceInquiryNetworkIdentifiers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryNetworkIdentifiers(
        CardBalanceInquiryNetworkIdentifiers cardBalanceInquiryNetworkIdentifiers
    )
        : base(cardBalanceInquiryNetworkIdentifiers) { }
#pragma warning restore CS8618

    public CardBalanceInquiryNetworkIdentifiers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryNetworkIdentifiers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryNetworkIdentifiersFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryNetworkIdentifiersFromRaw
    : IFromRawJson<CardBalanceInquiryNetworkIdentifiers>
{
    /// <inheritdoc/>
    public CardBalanceInquiryNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryNetworkIdentifiers.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_balance_inquiry`.
/// </summary>
[JsonConverter(typeof(CardBalanceInquiryTypeConverter))]
public enum CardBalanceInquiryType
{
    CardBalanceInquiry,
}

sealed class CardBalanceInquiryTypeConverter : JsonConverter<CardBalanceInquiryType>
{
    public override CardBalanceInquiryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_balance_inquiry" => CardBalanceInquiryType.CardBalanceInquiry,
            _ => (CardBalanceInquiryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardBalanceInquiryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardBalanceInquiryType.CardBalanceInquiry => "card_balance_inquiry",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryVerification,
        CardBalanceInquiryVerificationFromRaw
    >)
)]
public sealed record class CardBalanceInquiryVerification : JsonModel
{
    /// <summary>
    /// Fields related to verification of the Card Verification Code, a 3-digit code
    /// on the back of the card.
    /// </summary>
    public required CardBalanceInquiryVerificationCardVerificationCode CardVerificationCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardBalanceInquiryVerificationCardVerificationCode>(
                "card_verification_code"
            );
        }
        init { this._rawData.Set("card_verification_code", value); }
    }

    /// <summary>
    /// Cardholder address provided in the authorization request and the address
    /// on file we verified it against.
    /// </summary>
    public required CardBalanceInquiryVerificationCardholderAddress CardholderAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardBalanceInquiryVerificationCardholderAddress>(
                "cardholder_address"
            );
        }
        init { this._rawData.Set("cardholder_address", value); }
    }

    /// <summary>
    /// Cardholder name provided in the authorization request.
    /// </summary>
    public required CardBalanceInquiryVerificationCardholderName? CardholderName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardBalanceInquiryVerificationCardholderName>(
                "cardholder_name"
            );
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

    public CardBalanceInquiryVerification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryVerification(
        CardBalanceInquiryVerification cardBalanceInquiryVerification
    )
        : base(cardBalanceInquiryVerification) { }
#pragma warning restore CS8618

    public CardBalanceInquiryVerification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryVerification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryVerificationFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryVerificationFromRaw : IFromRawJson<CardBalanceInquiryVerification>
{
    /// <inheritdoc/>
    public CardBalanceInquiryVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryVerification.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields related to verification of the Card Verification Code, a 3-digit code
/// on the back of the card.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryVerificationCardVerificationCode,
        CardBalanceInquiryVerificationCardVerificationCodeFromRaw
    >)
)]
public sealed record class CardBalanceInquiryVerificationCardVerificationCode : JsonModel
{
    /// <summary>
    /// The result of verifying the Card Verification Code.
    /// </summary>
    public required ApiEnum<string, CardBalanceInquiryVerificationCardVerificationCodeResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardBalanceInquiryVerificationCardVerificationCodeResult>
            >("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Result.Validate();
    }

    public CardBalanceInquiryVerificationCardVerificationCode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryVerificationCardVerificationCode(
        CardBalanceInquiryVerificationCardVerificationCode cardBalanceInquiryVerificationCardVerificationCode
    )
        : base(cardBalanceInquiryVerificationCardVerificationCode) { }
#pragma warning restore CS8618

    public CardBalanceInquiryVerificationCardVerificationCode(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryVerificationCardVerificationCode(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryVerificationCardVerificationCodeFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryVerificationCardVerificationCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardBalanceInquiryVerificationCardVerificationCode(
        ApiEnum<string, CardBalanceInquiryVerificationCardVerificationCodeResult> result
    )
        : this()
    {
        this.Result = result;
    }
}

class CardBalanceInquiryVerificationCardVerificationCodeFromRaw
    : IFromRawJson<CardBalanceInquiryVerificationCardVerificationCode>
{
    /// <inheritdoc/>
    public CardBalanceInquiryVerificationCardVerificationCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryVerificationCardVerificationCode.FromRawUnchecked(rawData);
}

/// <summary>
/// The result of verifying the Card Verification Code.
/// </summary>
[JsonConverter(typeof(CardBalanceInquiryVerificationCardVerificationCodeResultConverter))]
public enum CardBalanceInquiryVerificationCardVerificationCodeResult
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

sealed class CardBalanceInquiryVerificationCardVerificationCodeResultConverter
    : JsonConverter<CardBalanceInquiryVerificationCardVerificationCodeResult>
{
    public override CardBalanceInquiryVerificationCardVerificationCodeResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_checked" => CardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked,
            "match" => CardBalanceInquiryVerificationCardVerificationCodeResult.Match,
            "no_match" => CardBalanceInquiryVerificationCardVerificationCodeResult.NoMatch,
            _ => (CardBalanceInquiryVerificationCardVerificationCodeResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardBalanceInquiryVerificationCardVerificationCodeResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked =>
                    "not_checked",
                CardBalanceInquiryVerificationCardVerificationCodeResult.Match => "match",
                CardBalanceInquiryVerificationCardVerificationCodeResult.NoMatch => "no_match",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryVerificationCardholderAddress,
        CardBalanceInquiryVerificationCardholderAddressFromRaw
    >)
)]
public sealed record class CardBalanceInquiryVerificationCardholderAddress : JsonModel
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
    public required ApiEnum<string, CardBalanceInquiryVerificationCardholderAddressResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardBalanceInquiryVerificationCardholderAddressResult>
            >("result");
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

    public CardBalanceInquiryVerificationCardholderAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryVerificationCardholderAddress(
        CardBalanceInquiryVerificationCardholderAddress cardBalanceInquiryVerificationCardholderAddress
    )
        : base(cardBalanceInquiryVerificationCardholderAddress) { }
#pragma warning restore CS8618

    public CardBalanceInquiryVerificationCardholderAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryVerificationCardholderAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryVerificationCardholderAddressFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryVerificationCardholderAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryVerificationCardholderAddressFromRaw
    : IFromRawJson<CardBalanceInquiryVerificationCardholderAddress>
{
    /// <inheritdoc/>
    public CardBalanceInquiryVerificationCardholderAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryVerificationCardholderAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The address verification result returned to the card network.
/// </summary>
[JsonConverter(typeof(CardBalanceInquiryVerificationCardholderAddressResultConverter))]
public enum CardBalanceInquiryVerificationCardholderAddressResult
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

sealed class CardBalanceInquiryVerificationCardholderAddressResultConverter
    : JsonConverter<CardBalanceInquiryVerificationCardholderAddressResult>
{
    public override CardBalanceInquiryVerificationCardholderAddressResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_checked" => CardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
            "postal_code_match_address_no_match" =>
                CardBalanceInquiryVerificationCardholderAddressResult.PostalCodeMatchAddressNoMatch,
            "postal_code_no_match_address_match" =>
                CardBalanceInquiryVerificationCardholderAddressResult.PostalCodeNoMatchAddressMatch,
            "match" => CardBalanceInquiryVerificationCardholderAddressResult.Match,
            "no_match" => CardBalanceInquiryVerificationCardholderAddressResult.NoMatch,
            "postal_code_match_address_not_checked" =>
                CardBalanceInquiryVerificationCardholderAddressResult.PostalCodeMatchAddressNotChecked,
            _ => (CardBalanceInquiryVerificationCardholderAddressResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardBalanceInquiryVerificationCardholderAddressResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardBalanceInquiryVerificationCardholderAddressResult.NotChecked => "not_checked",
                CardBalanceInquiryVerificationCardholderAddressResult.PostalCodeMatchAddressNoMatch =>
                    "postal_code_match_address_no_match",
                CardBalanceInquiryVerificationCardholderAddressResult.PostalCodeNoMatchAddressMatch =>
                    "postal_code_no_match_address_match",
                CardBalanceInquiryVerificationCardholderAddressResult.Match => "match",
                CardBalanceInquiryVerificationCardholderAddressResult.NoMatch => "no_match",
                CardBalanceInquiryVerificationCardholderAddressResult.PostalCodeMatchAddressNotChecked =>
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardBalanceInquiryVerificationCardholderName,
        CardBalanceInquiryVerificationCardholderNameFromRaw
    >)
)]
public sealed record class CardBalanceInquiryVerificationCardholderName : JsonModel
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

    public CardBalanceInquiryVerificationCardholderName() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryVerificationCardholderName(
        CardBalanceInquiryVerificationCardholderName cardBalanceInquiryVerificationCardholderName
    )
        : base(cardBalanceInquiryVerificationCardholderName) { }
#pragma warning restore CS8618

    public CardBalanceInquiryVerificationCardholderName(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryVerificationCardholderName(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryVerificationCardholderNameFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryVerificationCardholderName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBalanceInquiryVerificationCardholderNameFromRaw
    : IFromRawJson<CardBalanceInquiryVerificationCardholderName>
{
    /// <inheritdoc/>
    public CardBalanceInquiryVerificationCardholderName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryVerificationCardholderName.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Decline object. This field will be present in the JSON response if and
/// only if `category` is equal to `card_decline`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardDecline, CardDeclineFromRaw>))]
public sealed record class CardDecline : JsonModel
{
    /// <summary>
    /// The Card Decline identifier.
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
    public required ApiEnum<string, CardDeclineActioner> Actioner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardDeclineActioner>>("actioner");
        }
        init { this._rawData.Set("actioner", value); }
    }

    /// <summary>
    /// Additional amounts associated with the card authorization, such as ATM surcharges
    /// fees. These are usually a subset of the `amount` field and are used to provide
    /// more detailed information about the transaction.
    /// </summary>
    public required CardDeclineAdditionalAmounts AdditionalAmounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardDeclineAdditionalAmounts>(
                "additional_amounts"
            );
        }
        init { this._rawData.Set("additional_amounts", value); }
    }

    /// <summary>
    /// The declined amount in the minor unit of the destination account currency.
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the destination
    /// account currency.
    /// </summary>
    public required ApiEnum<string, CardDeclineCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardDeclineCurrency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The identifier of the declined transaction created for this Card Decline.
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
    public required ApiEnum<string, CardDeclineDirection> Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardDeclineDirection>>(
                "direction"
            );
        }
        init { this._rawData.Set("direction", value); }
    }

    /// <summary>
    /// The identifier of the card authorization this request attempted to incrementally authorize.
    /// </summary>
    public required string? IncrementedCardAuthorizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("incremented_card_authorization_id");
        }
        init { this._rawData.Set("incremented_card_authorization_id", value); }
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
    public required CardDeclineNetworkDetails NetworkDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardDeclineNetworkDetails>("network_details");
        }
        init { this._rawData.Set("network_details", value); }
    }

    /// <summary>
    /// Network-specific identifiers for a specific request or transaction.
    /// </summary>
    public required CardDeclineNetworkIdentifiers NetworkIdentifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardDeclineNetworkIdentifiers>(
                "network_identifiers"
            );
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
    /// The declined amount in the minor unit of the transaction's presentment currency.
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
    public required ApiEnum<string, CardDeclineProcessingCategory> ProcessingCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardDeclineProcessingCategory>>(
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
    /// This is present if a specific decline reason was given in the real-time decision.
    /// </summary>
    public required ApiEnum<string, RealTimeDecisionReason>? RealTimeDecisionReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RealTimeDecisionReason>>(
                "real_time_decision_reason"
            );
        }
        init { this._rawData.Set("real_time_decision_reason", value); }
    }

    /// <summary>
    /// Why the transaction was declined.
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
    /// Fields related to verification of cardholder-provided values.
    /// </summary>
    public required CardDeclineVerification Verification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardDeclineVerification>("verification");
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
        _ = this.DeclinedTransactionID;
        _ = this.DigitalWalletTokenID;
        this.Direction.Validate();
        _ = this.IncrementedCardAuthorizationID;
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
        this.RealTimeDecisionReason?.Validate();
        this.Reason.Validate();
        _ = this.TerminalID;
        this.Verification.Validate();
    }

    public CardDecline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDecline(CardDecline cardDecline)
        : base(cardDecline) { }
#pragma warning restore CS8618

    public CardDecline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDecline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineFromRaw.FromRawUnchecked"/>
    public static CardDecline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineFromRaw : IFromRawJson<CardDecline>
{
    /// <inheritdoc/>
    public CardDecline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardDecline.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether this authorization was approved by Increase, the card network through
/// stand-in processing, or the user through a real-time decision.
/// </summary>
[JsonConverter(typeof(CardDeclineActionerConverter))]
public enum CardDeclineActioner
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

sealed class CardDeclineActionerConverter : JsonConverter<CardDeclineActioner>
{
    public override CardDeclineActioner Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => CardDeclineActioner.User,
            "increase" => CardDeclineActioner.Increase,
            "network" => CardDeclineActioner.Network,
            _ => (CardDeclineActioner)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDeclineActioner value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDeclineActioner.User => "user",
                CardDeclineActioner.Increase => "increase",
                CardDeclineActioner.Network => "network",
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
[JsonConverter(
    typeof(JsonModelConverter<CardDeclineAdditionalAmounts, CardDeclineAdditionalAmountsFromRaw>)
)]
public sealed record class CardDeclineAdditionalAmounts : JsonModel
{
    /// <summary>
    /// The part of this transaction amount that was for clinic-related services.
    /// </summary>
    public required CardDeclineAdditionalAmountsClinic? Clinic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDeclineAdditionalAmountsClinic>("clinic");
        }
        init { this._rawData.Set("clinic", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for dental-related services.
    /// </summary>
    public required CardDeclineAdditionalAmountsDental? Dental
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDeclineAdditionalAmountsDental>("dental");
        }
        init { this._rawData.Set("dental", value); }
    }

    /// <summary>
    /// The original pre-authorized amount.
    /// </summary>
    public required CardDeclineAdditionalAmountsOriginal? Original
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDeclineAdditionalAmountsOriginal>("original");
        }
        init { this._rawData.Set("original", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for healthcare prescriptions.
    /// </summary>
    public required CardDeclineAdditionalAmountsPrescription? Prescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDeclineAdditionalAmountsPrescription>(
                "prescription"
            );
        }
        init { this._rawData.Set("prescription", value); }
    }

    /// <summary>
    /// The surcharge amount charged for this transaction by the merchant.
    /// </summary>
    public required CardDeclineAdditionalAmountsSurcharge? Surcharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDeclineAdditionalAmountsSurcharge>(
                "surcharge"
            );
        }
        init { this._rawData.Set("surcharge", value); }
    }

    /// <summary>
    /// The total amount of a series of incremental authorizations, optionally provided.
    /// </summary>
    public required CardDeclineAdditionalAmountsTotalCumulative? TotalCumulative
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDeclineAdditionalAmountsTotalCumulative>(
                "total_cumulative"
            );
        }
        init { this._rawData.Set("total_cumulative", value); }
    }

    /// <summary>
    /// The total amount of healthcare-related additional amounts.
    /// </summary>
    public required CardDeclineAdditionalAmountsTotalHealthcare? TotalHealthcare
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDeclineAdditionalAmountsTotalHealthcare>(
                "total_healthcare"
            );
        }
        init { this._rawData.Set("total_healthcare", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for transit-related services.
    /// </summary>
    public required CardDeclineAdditionalAmountsTransit? Transit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDeclineAdditionalAmountsTransit>("transit");
        }
        init { this._rawData.Set("transit", value); }
    }

    /// <summary>
    /// An unknown additional amount.
    /// </summary>
    public required CardDeclineAdditionalAmountsUnknown? Unknown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDeclineAdditionalAmountsUnknown>("unknown");
        }
        init { this._rawData.Set("unknown", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for vision-related services.
    /// </summary>
    public required CardDeclineAdditionalAmountsVision? Vision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDeclineAdditionalAmountsVision>("vision");
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

    public CardDeclineAdditionalAmounts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineAdditionalAmounts(CardDeclineAdditionalAmounts cardDeclineAdditionalAmounts)
        : base(cardDeclineAdditionalAmounts) { }
#pragma warning restore CS8618

    public CardDeclineAdditionalAmounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineAdditionalAmounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineAdditionalAmountsFromRaw.FromRawUnchecked"/>
    public static CardDeclineAdditionalAmounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineAdditionalAmountsFromRaw : IFromRawJson<CardDeclineAdditionalAmounts>
{
    /// <inheritdoc/>
    public CardDeclineAdditionalAmounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineAdditionalAmounts.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for clinic-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardDeclineAdditionalAmountsClinic,
        CardDeclineAdditionalAmountsClinicFromRaw
    >)
)]
public sealed record class CardDeclineAdditionalAmountsClinic : JsonModel
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

    public CardDeclineAdditionalAmountsClinic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineAdditionalAmountsClinic(
        CardDeclineAdditionalAmountsClinic cardDeclineAdditionalAmountsClinic
    )
        : base(cardDeclineAdditionalAmountsClinic) { }
#pragma warning restore CS8618

    public CardDeclineAdditionalAmountsClinic(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineAdditionalAmountsClinic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineAdditionalAmountsClinicFromRaw.FromRawUnchecked"/>
    public static CardDeclineAdditionalAmountsClinic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineAdditionalAmountsClinicFromRaw : IFromRawJson<CardDeclineAdditionalAmountsClinic>
{
    /// <inheritdoc/>
    public CardDeclineAdditionalAmountsClinic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineAdditionalAmountsClinic.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for dental-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardDeclineAdditionalAmountsDental,
        CardDeclineAdditionalAmountsDentalFromRaw
    >)
)]
public sealed record class CardDeclineAdditionalAmountsDental : JsonModel
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

    public CardDeclineAdditionalAmountsDental() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineAdditionalAmountsDental(
        CardDeclineAdditionalAmountsDental cardDeclineAdditionalAmountsDental
    )
        : base(cardDeclineAdditionalAmountsDental) { }
#pragma warning restore CS8618

    public CardDeclineAdditionalAmountsDental(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineAdditionalAmountsDental(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineAdditionalAmountsDentalFromRaw.FromRawUnchecked"/>
    public static CardDeclineAdditionalAmountsDental FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineAdditionalAmountsDentalFromRaw : IFromRawJson<CardDeclineAdditionalAmountsDental>
{
    /// <inheritdoc/>
    public CardDeclineAdditionalAmountsDental FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineAdditionalAmountsDental.FromRawUnchecked(rawData);
}

/// <summary>
/// The original pre-authorized amount.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardDeclineAdditionalAmountsOriginal,
        CardDeclineAdditionalAmountsOriginalFromRaw
    >)
)]
public sealed record class CardDeclineAdditionalAmountsOriginal : JsonModel
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

    public CardDeclineAdditionalAmountsOriginal() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineAdditionalAmountsOriginal(
        CardDeclineAdditionalAmountsOriginal cardDeclineAdditionalAmountsOriginal
    )
        : base(cardDeclineAdditionalAmountsOriginal) { }
#pragma warning restore CS8618

    public CardDeclineAdditionalAmountsOriginal(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineAdditionalAmountsOriginal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineAdditionalAmountsOriginalFromRaw.FromRawUnchecked"/>
    public static CardDeclineAdditionalAmountsOriginal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineAdditionalAmountsOriginalFromRaw
    : IFromRawJson<CardDeclineAdditionalAmountsOriginal>
{
    /// <inheritdoc/>
    public CardDeclineAdditionalAmountsOriginal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineAdditionalAmountsOriginal.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for healthcare prescriptions.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardDeclineAdditionalAmountsPrescription,
        CardDeclineAdditionalAmountsPrescriptionFromRaw
    >)
)]
public sealed record class CardDeclineAdditionalAmountsPrescription : JsonModel
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

    public CardDeclineAdditionalAmountsPrescription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineAdditionalAmountsPrescription(
        CardDeclineAdditionalAmountsPrescription cardDeclineAdditionalAmountsPrescription
    )
        : base(cardDeclineAdditionalAmountsPrescription) { }
#pragma warning restore CS8618

    public CardDeclineAdditionalAmountsPrescription(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineAdditionalAmountsPrescription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineAdditionalAmountsPrescriptionFromRaw.FromRawUnchecked"/>
    public static CardDeclineAdditionalAmountsPrescription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineAdditionalAmountsPrescriptionFromRaw
    : IFromRawJson<CardDeclineAdditionalAmountsPrescription>
{
    /// <inheritdoc/>
    public CardDeclineAdditionalAmountsPrescription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineAdditionalAmountsPrescription.FromRawUnchecked(rawData);
}

/// <summary>
/// The surcharge amount charged for this transaction by the merchant.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardDeclineAdditionalAmountsSurcharge,
        CardDeclineAdditionalAmountsSurchargeFromRaw
    >)
)]
public sealed record class CardDeclineAdditionalAmountsSurcharge : JsonModel
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

    public CardDeclineAdditionalAmountsSurcharge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineAdditionalAmountsSurcharge(
        CardDeclineAdditionalAmountsSurcharge cardDeclineAdditionalAmountsSurcharge
    )
        : base(cardDeclineAdditionalAmountsSurcharge) { }
#pragma warning restore CS8618

    public CardDeclineAdditionalAmountsSurcharge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineAdditionalAmountsSurcharge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineAdditionalAmountsSurchargeFromRaw.FromRawUnchecked"/>
    public static CardDeclineAdditionalAmountsSurcharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineAdditionalAmountsSurchargeFromRaw
    : IFromRawJson<CardDeclineAdditionalAmountsSurcharge>
{
    /// <inheritdoc/>
    public CardDeclineAdditionalAmountsSurcharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineAdditionalAmountsSurcharge.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of a series of incremental authorizations, optionally provided.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardDeclineAdditionalAmountsTotalCumulative,
        CardDeclineAdditionalAmountsTotalCumulativeFromRaw
    >)
)]
public sealed record class CardDeclineAdditionalAmountsTotalCumulative : JsonModel
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

    public CardDeclineAdditionalAmountsTotalCumulative() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineAdditionalAmountsTotalCumulative(
        CardDeclineAdditionalAmountsTotalCumulative cardDeclineAdditionalAmountsTotalCumulative
    )
        : base(cardDeclineAdditionalAmountsTotalCumulative) { }
#pragma warning restore CS8618

    public CardDeclineAdditionalAmountsTotalCumulative(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineAdditionalAmountsTotalCumulative(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineAdditionalAmountsTotalCumulativeFromRaw.FromRawUnchecked"/>
    public static CardDeclineAdditionalAmountsTotalCumulative FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineAdditionalAmountsTotalCumulativeFromRaw
    : IFromRawJson<CardDeclineAdditionalAmountsTotalCumulative>
{
    /// <inheritdoc/>
    public CardDeclineAdditionalAmountsTotalCumulative FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineAdditionalAmountsTotalCumulative.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of healthcare-related additional amounts.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardDeclineAdditionalAmountsTotalHealthcare,
        CardDeclineAdditionalAmountsTotalHealthcareFromRaw
    >)
)]
public sealed record class CardDeclineAdditionalAmountsTotalHealthcare : JsonModel
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

    public CardDeclineAdditionalAmountsTotalHealthcare() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineAdditionalAmountsTotalHealthcare(
        CardDeclineAdditionalAmountsTotalHealthcare cardDeclineAdditionalAmountsTotalHealthcare
    )
        : base(cardDeclineAdditionalAmountsTotalHealthcare) { }
#pragma warning restore CS8618

    public CardDeclineAdditionalAmountsTotalHealthcare(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineAdditionalAmountsTotalHealthcare(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineAdditionalAmountsTotalHealthcareFromRaw.FromRawUnchecked"/>
    public static CardDeclineAdditionalAmountsTotalHealthcare FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineAdditionalAmountsTotalHealthcareFromRaw
    : IFromRawJson<CardDeclineAdditionalAmountsTotalHealthcare>
{
    /// <inheritdoc/>
    public CardDeclineAdditionalAmountsTotalHealthcare FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineAdditionalAmountsTotalHealthcare.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for transit-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardDeclineAdditionalAmountsTransit,
        CardDeclineAdditionalAmountsTransitFromRaw
    >)
)]
public sealed record class CardDeclineAdditionalAmountsTransit : JsonModel
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

    public CardDeclineAdditionalAmountsTransit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineAdditionalAmountsTransit(
        CardDeclineAdditionalAmountsTransit cardDeclineAdditionalAmountsTransit
    )
        : base(cardDeclineAdditionalAmountsTransit) { }
#pragma warning restore CS8618

    public CardDeclineAdditionalAmountsTransit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineAdditionalAmountsTransit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineAdditionalAmountsTransitFromRaw.FromRawUnchecked"/>
    public static CardDeclineAdditionalAmountsTransit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineAdditionalAmountsTransitFromRaw : IFromRawJson<CardDeclineAdditionalAmountsTransit>
{
    /// <inheritdoc/>
    public CardDeclineAdditionalAmountsTransit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineAdditionalAmountsTransit.FromRawUnchecked(rawData);
}

/// <summary>
/// An unknown additional amount.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardDeclineAdditionalAmountsUnknown,
        CardDeclineAdditionalAmountsUnknownFromRaw
    >)
)]
public sealed record class CardDeclineAdditionalAmountsUnknown : JsonModel
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

    public CardDeclineAdditionalAmountsUnknown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineAdditionalAmountsUnknown(
        CardDeclineAdditionalAmountsUnknown cardDeclineAdditionalAmountsUnknown
    )
        : base(cardDeclineAdditionalAmountsUnknown) { }
#pragma warning restore CS8618

    public CardDeclineAdditionalAmountsUnknown(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineAdditionalAmountsUnknown(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineAdditionalAmountsUnknownFromRaw.FromRawUnchecked"/>
    public static CardDeclineAdditionalAmountsUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineAdditionalAmountsUnknownFromRaw : IFromRawJson<CardDeclineAdditionalAmountsUnknown>
{
    /// <inheritdoc/>
    public CardDeclineAdditionalAmountsUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineAdditionalAmountsUnknown.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for vision-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardDeclineAdditionalAmountsVision,
        CardDeclineAdditionalAmountsVisionFromRaw
    >)
)]
public sealed record class CardDeclineAdditionalAmountsVision : JsonModel
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

    public CardDeclineAdditionalAmountsVision() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineAdditionalAmountsVision(
        CardDeclineAdditionalAmountsVision cardDeclineAdditionalAmountsVision
    )
        : base(cardDeclineAdditionalAmountsVision) { }
#pragma warning restore CS8618

    public CardDeclineAdditionalAmountsVision(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineAdditionalAmountsVision(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineAdditionalAmountsVisionFromRaw.FromRawUnchecked"/>
    public static CardDeclineAdditionalAmountsVision FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineAdditionalAmountsVisionFromRaw : IFromRawJson<CardDeclineAdditionalAmountsVision>
{
    /// <inheritdoc/>
    public CardDeclineAdditionalAmountsVision FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineAdditionalAmountsVision.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the destination
/// account currency.
/// </summary>
[JsonConverter(typeof(CardDeclineCurrencyConverter))]
public enum CardDeclineCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardDeclineCurrencyConverter : JsonConverter<CardDeclineCurrency>
{
    public override CardDeclineCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardDeclineCurrency.Usd,
            _ => (CardDeclineCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDeclineCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDeclineCurrency.Usd => "USD",
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
[JsonConverter(typeof(CardDeclineDirectionConverter))]
public enum CardDeclineDirection
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

sealed class CardDeclineDirectionConverter : JsonConverter<CardDeclineDirection>
{
    public override CardDeclineDirection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "settlement" => CardDeclineDirection.Settlement,
            "refund" => CardDeclineDirection.Refund,
            _ => (CardDeclineDirection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDeclineDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDeclineDirection.Settlement => "settlement",
                CardDeclineDirection.Refund => "refund",
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
[JsonConverter(
    typeof(JsonModelConverter<CardDeclineNetworkDetails, CardDeclineNetworkDetailsFromRaw>)
)]
public sealed record class CardDeclineNetworkDetails : JsonModel
{
    /// <summary>
    /// The payment network used to process this card authorization.
    /// </summary>
    public required ApiEnum<string, CardDeclineNetworkDetailsCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardDeclineNetworkDetailsCategory>
            >("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Fields specific to the `pulse` network.
    /// </summary>
    public required CardDeclineNetworkDetailsPulse? Pulse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDeclineNetworkDetailsPulse>("pulse");
        }
        init { this._rawData.Set("pulse", value); }
    }

    /// <summary>
    /// Fields specific to the `visa` network.
    /// </summary>
    public required CardDeclineNetworkDetailsVisa? Visa
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDeclineNetworkDetailsVisa>("visa");
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

    public CardDeclineNetworkDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineNetworkDetails(CardDeclineNetworkDetails cardDeclineNetworkDetails)
        : base(cardDeclineNetworkDetails) { }
#pragma warning restore CS8618

    public CardDeclineNetworkDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineNetworkDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineNetworkDetailsFromRaw.FromRawUnchecked"/>
    public static CardDeclineNetworkDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineNetworkDetailsFromRaw : IFromRawJson<CardDeclineNetworkDetails>
{
    /// <inheritdoc/>
    public CardDeclineNetworkDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineNetworkDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// The payment network used to process this card authorization.
/// </summary>
[JsonConverter(typeof(CardDeclineNetworkDetailsCategoryConverter))]
public enum CardDeclineNetworkDetailsCategory
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

sealed class CardDeclineNetworkDetailsCategoryConverter
    : JsonConverter<CardDeclineNetworkDetailsCategory>
{
    public override CardDeclineNetworkDetailsCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => CardDeclineNetworkDetailsCategory.Visa,
            "pulse" => CardDeclineNetworkDetailsCategory.Pulse,
            _ => (CardDeclineNetworkDetailsCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDeclineNetworkDetailsCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDeclineNetworkDetailsCategory.Visa => "visa",
                CardDeclineNetworkDetailsCategory.Pulse => "pulse",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardDeclineNetworkDetailsPulse,
        CardDeclineNetworkDetailsPulseFromRaw
    >)
)]
public sealed record class CardDeclineNetworkDetailsPulse : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public CardDeclineNetworkDetailsPulse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineNetworkDetailsPulse(
        CardDeclineNetworkDetailsPulse cardDeclineNetworkDetailsPulse
    )
        : base(cardDeclineNetworkDetailsPulse) { }
#pragma warning restore CS8618

    public CardDeclineNetworkDetailsPulse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineNetworkDetailsPulse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineNetworkDetailsPulseFromRaw.FromRawUnchecked"/>
    public static CardDeclineNetworkDetailsPulse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineNetworkDetailsPulseFromRaw : IFromRawJson<CardDeclineNetworkDetailsPulse>
{
    /// <inheritdoc/>
    public CardDeclineNetworkDetailsPulse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineNetworkDetailsPulse.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields specific to the `visa` network.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CardDeclineNetworkDetailsVisa, CardDeclineNetworkDetailsVisaFromRaw>)
)]
public sealed record class CardDeclineNetworkDetailsVisa : JsonModel
{
    /// <summary>
    /// For electronic commerce transactions, this identifies the level of security
    /// used in obtaining the customer's payment credential. For mail or telephone
    /// order transactions, identifies the type of mail or telephone order.
    /// </summary>
    public required ApiEnum<
        string,
        CardDeclineNetworkDetailsVisaElectronicCommerceIndicator
    >? ElectronicCommerceIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardDeclineNetworkDetailsVisaElectronicCommerceIndicator>
            >("electronic_commerce_indicator");
        }
        init { this._rawData.Set("electronic_commerce_indicator", value); }
    }

    /// <summary>
    /// The method used to enter the cardholder's primary account number and card
    /// expiration date.
    /// </summary>
    public required ApiEnum<
        string,
        CardDeclineNetworkDetailsVisaPointOfServiceEntryMode
    >? PointOfServiceEntryMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardDeclineNetworkDetailsVisaPointOfServiceEntryMode>
            >("point_of_service_entry_mode");
        }
        init { this._rawData.Set("point_of_service_entry_mode", value); }
    }

    /// <summary>
    /// Only present when `actioner: network`. Describes why a card authorization
    /// was approved or declined by Visa through stand-in processing.
    /// </summary>
    public required ApiEnum<
        string,
        CardDeclineNetworkDetailsVisaStandInProcessingReason
    >? StandInProcessingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardDeclineNetworkDetailsVisaStandInProcessingReason>
            >("stand_in_processing_reason");
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
    public required ApiEnum<
        string,
        CardDeclineNetworkDetailsVisaTerminalEntryCapability
    >? TerminalEntryCapability
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardDeclineNetworkDetailsVisaTerminalEntryCapability>
            >("terminal_entry_capability");
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

    public CardDeclineNetworkDetailsVisa() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineNetworkDetailsVisa(
        CardDeclineNetworkDetailsVisa cardDeclineNetworkDetailsVisa
    )
        : base(cardDeclineNetworkDetailsVisa) { }
#pragma warning restore CS8618

    public CardDeclineNetworkDetailsVisa(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineNetworkDetailsVisa(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineNetworkDetailsVisaFromRaw.FromRawUnchecked"/>
    public static CardDeclineNetworkDetailsVisa FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineNetworkDetailsVisaFromRaw : IFromRawJson<CardDeclineNetworkDetailsVisa>
{
    /// <inheritdoc/>
    public CardDeclineNetworkDetailsVisa FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineNetworkDetailsVisa.FromRawUnchecked(rawData);
}

/// <summary>
/// For electronic commerce transactions, this identifies the level of security used
/// in obtaining the customer's payment credential. For mail or telephone order transactions,
/// identifies the type of mail or telephone order.
/// </summary>
[JsonConverter(typeof(CardDeclineNetworkDetailsVisaElectronicCommerceIndicatorConverter))]
public enum CardDeclineNetworkDetailsVisaElectronicCommerceIndicator
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

sealed class CardDeclineNetworkDetailsVisaElectronicCommerceIndicatorConverter
    : JsonConverter<CardDeclineNetworkDetailsVisaElectronicCommerceIndicator>
{
    public override CardDeclineNetworkDetailsVisaElectronicCommerceIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mail_phone_order" =>
                CardDeclineNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
            "recurring" => CardDeclineNetworkDetailsVisaElectronicCommerceIndicator.Recurring,
            "installment" => CardDeclineNetworkDetailsVisaElectronicCommerceIndicator.Installment,
            "unknown_mail_phone_order" =>
                CardDeclineNetworkDetailsVisaElectronicCommerceIndicator.UnknownMailPhoneOrder,
            "secure_electronic_commerce" =>
                CardDeclineNetworkDetailsVisaElectronicCommerceIndicator.SecureElectronicCommerce,
            "non_authenticated_security_transaction_at_3ds_capable_merchant" =>
                CardDeclineNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant,
            "non_authenticated_security_transaction" =>
                CardDeclineNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction,
            "non_secure_transaction" =>
                CardDeclineNetworkDetailsVisaElectronicCommerceIndicator.NonSecureTransaction,
            _ => (CardDeclineNetworkDetailsVisaElectronicCommerceIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDeclineNetworkDetailsVisaElectronicCommerceIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDeclineNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder =>
                    "mail_phone_order",
                CardDeclineNetworkDetailsVisaElectronicCommerceIndicator.Recurring => "recurring",
                CardDeclineNetworkDetailsVisaElectronicCommerceIndicator.Installment =>
                    "installment",
                CardDeclineNetworkDetailsVisaElectronicCommerceIndicator.UnknownMailPhoneOrder =>
                    "unknown_mail_phone_order",
                CardDeclineNetworkDetailsVisaElectronicCommerceIndicator.SecureElectronicCommerce =>
                    "secure_electronic_commerce",
                CardDeclineNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant =>
                    "non_authenticated_security_transaction_at_3ds_capable_merchant",
                CardDeclineNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction =>
                    "non_authenticated_security_transaction",
                CardDeclineNetworkDetailsVisaElectronicCommerceIndicator.NonSecureTransaction =>
                    "non_secure_transaction",
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
[JsonConverter(typeof(CardDeclineNetworkDetailsVisaPointOfServiceEntryModeConverter))]
public enum CardDeclineNetworkDetailsVisaPointOfServiceEntryMode
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

sealed class CardDeclineNetworkDetailsVisaPointOfServiceEntryModeConverter
    : JsonConverter<CardDeclineNetworkDetailsVisaPointOfServiceEntryMode>
{
    public override CardDeclineNetworkDetailsVisaPointOfServiceEntryMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" => CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
            "manual" => CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.Manual,
            "magnetic_stripe_no_cvv" =>
                CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripeNoCvv,
            "optical_code" => CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.OpticalCode,
            "integrated_circuit_card" =>
                CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCard,
            "contactless" => CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.Contactless,
            "credential_on_file" =>
                CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.CredentialOnFile,
            "magnetic_stripe" =>
                CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripe,
            "contactless_magnetic_stripe" =>
                CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.ContactlessMagneticStripe,
            "integrated_circuit_card_no_cvv" =>
                CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCardNoCvv,
            _ => (CardDeclineNetworkDetailsVisaPointOfServiceEntryMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDeclineNetworkDetailsVisaPointOfServiceEntryMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.Unknown => "unknown",
                CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.Manual => "manual",
                CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripeNoCvv =>
                    "magnetic_stripe_no_cvv",
                CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.OpticalCode => "optical_code",
                CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCard =>
                    "integrated_circuit_card",
                CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.Contactless => "contactless",
                CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.CredentialOnFile =>
                    "credential_on_file",
                CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripe =>
                    "magnetic_stripe",
                CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.ContactlessMagneticStripe =>
                    "contactless_magnetic_stripe",
                CardDeclineNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCardNoCvv =>
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
[JsonConverter(typeof(CardDeclineNetworkDetailsVisaStandInProcessingReasonConverter))]
public enum CardDeclineNetworkDetailsVisaStandInProcessingReason
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

sealed class CardDeclineNetworkDetailsVisaStandInProcessingReasonConverter
    : JsonConverter<CardDeclineNetworkDetailsVisaStandInProcessingReason>
{
    public override CardDeclineNetworkDetailsVisaStandInProcessingReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "issuer_error" => CardDeclineNetworkDetailsVisaStandInProcessingReason.IssuerError,
            "invalid_physical_card" =>
                CardDeclineNetworkDetailsVisaStandInProcessingReason.InvalidPhysicalCard,
            "invalid_cryptogram" =>
                CardDeclineNetworkDetailsVisaStandInProcessingReason.InvalidCryptogram,
            "invalid_cardholder_authentication_verification_value" =>
                CardDeclineNetworkDetailsVisaStandInProcessingReason.InvalidCardholderAuthenticationVerificationValue,
            "internal_visa_error" =>
                CardDeclineNetworkDetailsVisaStandInProcessingReason.InternalVisaError,
            "merchant_transaction_advisory_service_authentication_required" =>
                CardDeclineNetworkDetailsVisaStandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired,
            "payment_fraud_disruption_acquirer_block" =>
                CardDeclineNetworkDetailsVisaStandInProcessingReason.PaymentFraudDisruptionAcquirerBlock,
            "other" => CardDeclineNetworkDetailsVisaStandInProcessingReason.Other,
            _ => (CardDeclineNetworkDetailsVisaStandInProcessingReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDeclineNetworkDetailsVisaStandInProcessingReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDeclineNetworkDetailsVisaStandInProcessingReason.IssuerError => "issuer_error",
                CardDeclineNetworkDetailsVisaStandInProcessingReason.InvalidPhysicalCard =>
                    "invalid_physical_card",
                CardDeclineNetworkDetailsVisaStandInProcessingReason.InvalidCryptogram =>
                    "invalid_cryptogram",
                CardDeclineNetworkDetailsVisaStandInProcessingReason.InvalidCardholderAuthenticationVerificationValue =>
                    "invalid_cardholder_authentication_verification_value",
                CardDeclineNetworkDetailsVisaStandInProcessingReason.InternalVisaError =>
                    "internal_visa_error",
                CardDeclineNetworkDetailsVisaStandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired =>
                    "merchant_transaction_advisory_service_authentication_required",
                CardDeclineNetworkDetailsVisaStandInProcessingReason.PaymentFraudDisruptionAcquirerBlock =>
                    "payment_fraud_disruption_acquirer_block",
                CardDeclineNetworkDetailsVisaStandInProcessingReason.Other => "other",
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
[JsonConverter(typeof(CardDeclineNetworkDetailsVisaTerminalEntryCapabilityConverter))]
public enum CardDeclineNetworkDetailsVisaTerminalEntryCapability
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

sealed class CardDeclineNetworkDetailsVisaTerminalEntryCapabilityConverter
    : JsonConverter<CardDeclineNetworkDetailsVisaTerminalEntryCapability>
{
    public override CardDeclineNetworkDetailsVisaTerminalEntryCapability Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" => CardDeclineNetworkDetailsVisaTerminalEntryCapability.Unknown,
            "terminal_not_used" =>
                CardDeclineNetworkDetailsVisaTerminalEntryCapability.TerminalNotUsed,
            "magnetic_stripe" =>
                CardDeclineNetworkDetailsVisaTerminalEntryCapability.MagneticStripe,
            "barcode" => CardDeclineNetworkDetailsVisaTerminalEntryCapability.Barcode,
            "optical_character_recognition" =>
                CardDeclineNetworkDetailsVisaTerminalEntryCapability.OpticalCharacterRecognition,
            "chip_or_contactless" =>
                CardDeclineNetworkDetailsVisaTerminalEntryCapability.ChipOrContactless,
            "contactless_only" =>
                CardDeclineNetworkDetailsVisaTerminalEntryCapability.ContactlessOnly,
            "no_capability" => CardDeclineNetworkDetailsVisaTerminalEntryCapability.NoCapability,
            _ => (CardDeclineNetworkDetailsVisaTerminalEntryCapability)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDeclineNetworkDetailsVisaTerminalEntryCapability value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDeclineNetworkDetailsVisaTerminalEntryCapability.Unknown => "unknown",
                CardDeclineNetworkDetailsVisaTerminalEntryCapability.TerminalNotUsed =>
                    "terminal_not_used",
                CardDeclineNetworkDetailsVisaTerminalEntryCapability.MagneticStripe =>
                    "magnetic_stripe",
                CardDeclineNetworkDetailsVisaTerminalEntryCapability.Barcode => "barcode",
                CardDeclineNetworkDetailsVisaTerminalEntryCapability.OpticalCharacterRecognition =>
                    "optical_character_recognition",
                CardDeclineNetworkDetailsVisaTerminalEntryCapability.ChipOrContactless =>
                    "chip_or_contactless",
                CardDeclineNetworkDetailsVisaTerminalEntryCapability.ContactlessOnly =>
                    "contactless_only",
                CardDeclineNetworkDetailsVisaTerminalEntryCapability.NoCapability =>
                    "no_capability",
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
[JsonConverter(
    typeof(JsonModelConverter<CardDeclineNetworkIdentifiers, CardDeclineNetworkIdentifiersFromRaw>)
)]
public sealed record class CardDeclineNetworkIdentifiers : JsonModel
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

    public CardDeclineNetworkIdentifiers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineNetworkIdentifiers(
        CardDeclineNetworkIdentifiers cardDeclineNetworkIdentifiers
    )
        : base(cardDeclineNetworkIdentifiers) { }
#pragma warning restore CS8618

    public CardDeclineNetworkIdentifiers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineNetworkIdentifiers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineNetworkIdentifiersFromRaw.FromRawUnchecked"/>
    public static CardDeclineNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineNetworkIdentifiersFromRaw : IFromRawJson<CardDeclineNetworkIdentifiers>
{
    /// <inheritdoc/>
    public CardDeclineNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineNetworkIdentifiers.FromRawUnchecked(rawData);
}

/// <summary>
/// The processing category describes the intent behind the authorization, such as
/// whether it was used for bill payments or an automatic fuel dispenser.
/// </summary>
[JsonConverter(typeof(CardDeclineProcessingCategoryConverter))]
public enum CardDeclineProcessingCategory
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

sealed class CardDeclineProcessingCategoryConverter : JsonConverter<CardDeclineProcessingCategory>
{
    public override CardDeclineProcessingCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_funding" => CardDeclineProcessingCategory.AccountFunding,
            "automatic_fuel_dispenser" => CardDeclineProcessingCategory.AutomaticFuelDispenser,
            "bill_payment" => CardDeclineProcessingCategory.BillPayment,
            "original_credit" => CardDeclineProcessingCategory.OriginalCredit,
            "purchase" => CardDeclineProcessingCategory.Purchase,
            "quasi_cash" => CardDeclineProcessingCategory.QuasiCash,
            "refund" => CardDeclineProcessingCategory.Refund,
            "cash_disbursement" => CardDeclineProcessingCategory.CashDisbursement,
            "balance_inquiry" => CardDeclineProcessingCategory.BalanceInquiry,
            "unknown" => CardDeclineProcessingCategory.Unknown,
            _ => (CardDeclineProcessingCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDeclineProcessingCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDeclineProcessingCategory.AccountFunding => "account_funding",
                CardDeclineProcessingCategory.AutomaticFuelDispenser => "automatic_fuel_dispenser",
                CardDeclineProcessingCategory.BillPayment => "bill_payment",
                CardDeclineProcessingCategory.OriginalCredit => "original_credit",
                CardDeclineProcessingCategory.Purchase => "purchase",
                CardDeclineProcessingCategory.QuasiCash => "quasi_cash",
                CardDeclineProcessingCategory.Refund => "refund",
                CardDeclineProcessingCategory.CashDisbursement => "cash_disbursement",
                CardDeclineProcessingCategory.BalanceInquiry => "balance_inquiry",
                CardDeclineProcessingCategory.Unknown => "unknown",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// This is present if a specific decline reason was given in the real-time decision.
/// </summary>
[JsonConverter(typeof(RealTimeDecisionReasonConverter))]
public enum RealTimeDecisionReason
{
    /// <summary>
    /// The cardholder does not have sufficient funds to cover the transaction. The
    /// merchant may attempt to process the transaction again.
    /// </summary>
    InsufficientFunds,

    /// <summary>
    /// This type of transaction is not allowed for this card. This transaction should
    /// not be retried.
    /// </summary>
    TransactionNeverAllowed,

    /// <summary>
    /// The transaction amount exceeds the cardholder's approval limit. The merchant
    /// may attempt to process the transaction again.
    /// </summary>
    ExceedsApprovalLimit,

    /// <summary>
    /// The card has been temporarily disabled or not yet activated. The merchant
    /// may attempt to process the transaction again.
    /// </summary>
    CardTemporarilyDisabled,

    /// <summary>
    /// The transaction is suspected to be fraudulent. The merchant may attempt to
    /// process the transaction again.
    /// </summary>
    SuspectedFraud,

    /// <summary>
    /// The transaction was declined for another reason. The merchant may attempt
    /// to process the transaction again. This should be used sparingly.
    /// </summary>
    Other,
}

sealed class RealTimeDecisionReasonConverter : JsonConverter<RealTimeDecisionReason>
{
    public override RealTimeDecisionReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" => RealTimeDecisionReason.InsufficientFunds,
            "transaction_never_allowed" => RealTimeDecisionReason.TransactionNeverAllowed,
            "exceeds_approval_limit" => RealTimeDecisionReason.ExceedsApprovalLimit,
            "card_temporarily_disabled" => RealTimeDecisionReason.CardTemporarilyDisabled,
            "suspected_fraud" => RealTimeDecisionReason.SuspectedFraud,
            "other" => RealTimeDecisionReason.Other,
            _ => (RealTimeDecisionReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimeDecisionReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimeDecisionReason.InsufficientFunds => "insufficient_funds",
                RealTimeDecisionReason.TransactionNeverAllowed => "transaction_never_allowed",
                RealTimeDecisionReason.ExceedsApprovalLimit => "exceeds_approval_limit",
                RealTimeDecisionReason.CardTemporarilyDisabled => "card_temporarily_disabled",
                RealTimeDecisionReason.SuspectedFraud => "suspected_fraud",
                RealTimeDecisionReason.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Why the transaction was declined.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    /// <summary>
    /// The account has been closed.
    /// </summary>
    AccountClosed,

    /// <summary>
    /// The Card was not active.
    /// </summary>
    CardNotActive,

    /// <summary>
    /// The Card has been canceled.
    /// </summary>
    CardCanceled,

    /// <summary>
    /// The Physical Card was not active.
    /// </summary>
    PhysicalCardNotActive,

    /// <summary>
    /// The account's entity was not active.
    /// </summary>
    EntityNotActive,

    /// <summary>
    /// The account was inactive.
    /// </summary>
    GroupLocked,

    /// <summary>
    /// The Card's Account did not have a sufficient available balance.
    /// </summary>
    InsufficientFunds,

    /// <summary>
    /// The given CVV2 did not match the card's value.
    /// </summary>
    Cvv2Mismatch,

    /// <summary>
    /// The given PIN did not match the card's value.
    /// </summary>
    PinMismatch,

    /// <summary>
    /// The given expiration date did not match the card's value. Only applies when
    /// a CVV2 is present.
    /// </summary>
    CardExpirationMismatch,

    /// <summary>
    /// The attempted card transaction is not allowed per Increase's terms.
    /// </summary>
    TransactionNotAllowed,

    /// <summary>
    /// The transaction was blocked by a Limit.
    /// </summary>
    BreachesLimit,

    /// <summary>
    /// Your application declined the transaction via webhook.
    /// </summary>
    WebhookDeclined,

    /// <summary>
    /// Your application webhook did not respond without the required timeout.
    /// </summary>
    WebhookTimedOut,

    /// <summary>
    /// Declined by stand-in processing.
    /// </summary>
    DeclinedByStandInProcessing,

    /// <summary>
    /// The card read had an invalid CVV or dCVV.
    /// </summary>
    InvalidPhysicalCard,

    /// <summary>
    /// The original card authorization for this incremental authorization does not exist.
    /// </summary>
    MissingOriginalAuthorization,

    /// <summary>
    /// The card's authorization request cryptogram was invalid. The cryptogram can
    /// be from a physical card or a Digital Wallet Token purchase.
    /// </summary>
    InvalidCryptogram,

    /// <summary>
    /// The transaction was declined because the 3DS authentication failed.
    /// </summary>
    Failed3dsAuthentication,

    /// <summary>
    /// The transaction was suspected to be used by a card tester to test for valid
    /// card numbers.
    /// </summary>
    SuspectedCardTesting,

    /// <summary>
    /// The transaction was suspected to be fraudulent. Please reach out to support@increase.com
    /// for more information.
    /// </summary>
    SuspectedFraud,
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
            "account_closed" => Reason.AccountClosed,
            "card_not_active" => Reason.CardNotActive,
            "card_canceled" => Reason.CardCanceled,
            "physical_card_not_active" => Reason.PhysicalCardNotActive,
            "entity_not_active" => Reason.EntityNotActive,
            "group_locked" => Reason.GroupLocked,
            "insufficient_funds" => Reason.InsufficientFunds,
            "cvv2_mismatch" => Reason.Cvv2Mismatch,
            "pin_mismatch" => Reason.PinMismatch,
            "card_expiration_mismatch" => Reason.CardExpirationMismatch,
            "transaction_not_allowed" => Reason.TransactionNotAllowed,
            "breaches_limit" => Reason.BreachesLimit,
            "webhook_declined" => Reason.WebhookDeclined,
            "webhook_timed_out" => Reason.WebhookTimedOut,
            "declined_by_stand_in_processing" => Reason.DeclinedByStandInProcessing,
            "invalid_physical_card" => Reason.InvalidPhysicalCard,
            "missing_original_authorization" => Reason.MissingOriginalAuthorization,
            "invalid_cryptogram" => Reason.InvalidCryptogram,
            "failed_3ds_authentication" => Reason.Failed3dsAuthentication,
            "suspected_card_testing" => Reason.SuspectedCardTesting,
            "suspected_fraud" => Reason.SuspectedFraud,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.AccountClosed => "account_closed",
                Reason.CardNotActive => "card_not_active",
                Reason.CardCanceled => "card_canceled",
                Reason.PhysicalCardNotActive => "physical_card_not_active",
                Reason.EntityNotActive => "entity_not_active",
                Reason.GroupLocked => "group_locked",
                Reason.InsufficientFunds => "insufficient_funds",
                Reason.Cvv2Mismatch => "cvv2_mismatch",
                Reason.PinMismatch => "pin_mismatch",
                Reason.CardExpirationMismatch => "card_expiration_mismatch",
                Reason.TransactionNotAllowed => "transaction_not_allowed",
                Reason.BreachesLimit => "breaches_limit",
                Reason.WebhookDeclined => "webhook_declined",
                Reason.WebhookTimedOut => "webhook_timed_out",
                Reason.DeclinedByStandInProcessing => "declined_by_stand_in_processing",
                Reason.InvalidPhysicalCard => "invalid_physical_card",
                Reason.MissingOriginalAuthorization => "missing_original_authorization",
                Reason.InvalidCryptogram => "invalid_cryptogram",
                Reason.Failed3dsAuthentication => "failed_3ds_authentication",
                Reason.SuspectedCardTesting => "suspected_card_testing",
                Reason.SuspectedFraud => "suspected_fraud",
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
[JsonConverter(typeof(JsonModelConverter<CardDeclineVerification, CardDeclineVerificationFromRaw>))]
public sealed record class CardDeclineVerification : JsonModel
{
    /// <summary>
    /// Fields related to verification of the Card Verification Code, a 3-digit code
    /// on the back of the card.
    /// </summary>
    public required CardDeclineVerificationCardVerificationCode CardVerificationCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardDeclineVerificationCardVerificationCode>(
                "card_verification_code"
            );
        }
        init { this._rawData.Set("card_verification_code", value); }
    }

    /// <summary>
    /// Cardholder address provided in the authorization request and the address
    /// on file we verified it against.
    /// </summary>
    public required CardDeclineVerificationCardholderAddress CardholderAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardDeclineVerificationCardholderAddress>(
                "cardholder_address"
            );
        }
        init { this._rawData.Set("cardholder_address", value); }
    }

    /// <summary>
    /// Cardholder name provided in the authorization request.
    /// </summary>
    public required CardDeclineVerificationCardholderName? CardholderName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDeclineVerificationCardholderName>(
                "cardholder_name"
            );
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

    public CardDeclineVerification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineVerification(CardDeclineVerification cardDeclineVerification)
        : base(cardDeclineVerification) { }
#pragma warning restore CS8618

    public CardDeclineVerification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineVerification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineVerificationFromRaw.FromRawUnchecked"/>
    public static CardDeclineVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineVerificationFromRaw : IFromRawJson<CardDeclineVerification>
{
    /// <inheritdoc/>
    public CardDeclineVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineVerification.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields related to verification of the Card Verification Code, a 3-digit code
/// on the back of the card.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardDeclineVerificationCardVerificationCode,
        CardDeclineVerificationCardVerificationCodeFromRaw
    >)
)]
public sealed record class CardDeclineVerificationCardVerificationCode : JsonModel
{
    /// <summary>
    /// The result of verifying the Card Verification Code.
    /// </summary>
    public required ApiEnum<string, CardDeclineVerificationCardVerificationCodeResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardDeclineVerificationCardVerificationCodeResult>
            >("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Result.Validate();
    }

    public CardDeclineVerificationCardVerificationCode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineVerificationCardVerificationCode(
        CardDeclineVerificationCardVerificationCode cardDeclineVerificationCardVerificationCode
    )
        : base(cardDeclineVerificationCardVerificationCode) { }
#pragma warning restore CS8618

    public CardDeclineVerificationCardVerificationCode(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineVerificationCardVerificationCode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineVerificationCardVerificationCodeFromRaw.FromRawUnchecked"/>
    public static CardDeclineVerificationCardVerificationCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardDeclineVerificationCardVerificationCode(
        ApiEnum<string, CardDeclineVerificationCardVerificationCodeResult> result
    )
        : this()
    {
        this.Result = result;
    }
}

class CardDeclineVerificationCardVerificationCodeFromRaw
    : IFromRawJson<CardDeclineVerificationCardVerificationCode>
{
    /// <inheritdoc/>
    public CardDeclineVerificationCardVerificationCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineVerificationCardVerificationCode.FromRawUnchecked(rawData);
}

/// <summary>
/// The result of verifying the Card Verification Code.
/// </summary>
[JsonConverter(typeof(CardDeclineVerificationCardVerificationCodeResultConverter))]
public enum CardDeclineVerificationCardVerificationCodeResult
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

sealed class CardDeclineVerificationCardVerificationCodeResultConverter
    : JsonConverter<CardDeclineVerificationCardVerificationCodeResult>
{
    public override CardDeclineVerificationCardVerificationCodeResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_checked" => CardDeclineVerificationCardVerificationCodeResult.NotChecked,
            "match" => CardDeclineVerificationCardVerificationCodeResult.Match,
            "no_match" => CardDeclineVerificationCardVerificationCodeResult.NoMatch,
            _ => (CardDeclineVerificationCardVerificationCodeResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDeclineVerificationCardVerificationCodeResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDeclineVerificationCardVerificationCodeResult.NotChecked => "not_checked",
                CardDeclineVerificationCardVerificationCodeResult.Match => "match",
                CardDeclineVerificationCardVerificationCodeResult.NoMatch => "no_match",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardDeclineVerificationCardholderAddress,
        CardDeclineVerificationCardholderAddressFromRaw
    >)
)]
public sealed record class CardDeclineVerificationCardholderAddress : JsonModel
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
    public required ApiEnum<string, CardDeclineVerificationCardholderAddressResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardDeclineVerificationCardholderAddressResult>
            >("result");
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

    public CardDeclineVerificationCardholderAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineVerificationCardholderAddress(
        CardDeclineVerificationCardholderAddress cardDeclineVerificationCardholderAddress
    )
        : base(cardDeclineVerificationCardholderAddress) { }
#pragma warning restore CS8618

    public CardDeclineVerificationCardholderAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineVerificationCardholderAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineVerificationCardholderAddressFromRaw.FromRawUnchecked"/>
    public static CardDeclineVerificationCardholderAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineVerificationCardholderAddressFromRaw
    : IFromRawJson<CardDeclineVerificationCardholderAddress>
{
    /// <inheritdoc/>
    public CardDeclineVerificationCardholderAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineVerificationCardholderAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The address verification result returned to the card network.
/// </summary>
[JsonConverter(typeof(CardDeclineVerificationCardholderAddressResultConverter))]
public enum CardDeclineVerificationCardholderAddressResult
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

sealed class CardDeclineVerificationCardholderAddressResultConverter
    : JsonConverter<CardDeclineVerificationCardholderAddressResult>
{
    public override CardDeclineVerificationCardholderAddressResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_checked" => CardDeclineVerificationCardholderAddressResult.NotChecked,
            "postal_code_match_address_no_match" =>
                CardDeclineVerificationCardholderAddressResult.PostalCodeMatchAddressNoMatch,
            "postal_code_no_match_address_match" =>
                CardDeclineVerificationCardholderAddressResult.PostalCodeNoMatchAddressMatch,
            "match" => CardDeclineVerificationCardholderAddressResult.Match,
            "no_match" => CardDeclineVerificationCardholderAddressResult.NoMatch,
            "postal_code_match_address_not_checked" =>
                CardDeclineVerificationCardholderAddressResult.PostalCodeMatchAddressNotChecked,
            _ => (CardDeclineVerificationCardholderAddressResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDeclineVerificationCardholderAddressResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDeclineVerificationCardholderAddressResult.NotChecked => "not_checked",
                CardDeclineVerificationCardholderAddressResult.PostalCodeMatchAddressNoMatch =>
                    "postal_code_match_address_no_match",
                CardDeclineVerificationCardholderAddressResult.PostalCodeNoMatchAddressMatch =>
                    "postal_code_no_match_address_match",
                CardDeclineVerificationCardholderAddressResult.Match => "match",
                CardDeclineVerificationCardholderAddressResult.NoMatch => "no_match",
                CardDeclineVerificationCardholderAddressResult.PostalCodeMatchAddressNotChecked =>
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardDeclineVerificationCardholderName,
        CardDeclineVerificationCardholderNameFromRaw
    >)
)]
public sealed record class CardDeclineVerificationCardholderName : JsonModel
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

    public CardDeclineVerificationCardholderName() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDeclineVerificationCardholderName(
        CardDeclineVerificationCardholderName cardDeclineVerificationCardholderName
    )
        : base(cardDeclineVerificationCardholderName) { }
#pragma warning restore CS8618

    public CardDeclineVerificationCardholderName(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDeclineVerificationCardholderName(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDeclineVerificationCardholderNameFromRaw.FromRawUnchecked"/>
    public static CardDeclineVerificationCardholderName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDeclineVerificationCardholderNameFromRaw
    : IFromRawJson<CardDeclineVerificationCardholderName>
{
    /// <inheritdoc/>
    public CardDeclineVerificationCardholderName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDeclineVerificationCardholderName.FromRawUnchecked(rawData);
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
    public required ApiEnum<string, CardFinancialActioner> Actioner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardFinancialActioner>>(
                "actioner"
            );
        }
        init { this._rawData.Set("actioner", value); }
    }

    /// <summary>
    /// Additional amounts associated with the card authorization, such as ATM surcharges
    /// fees. These are usually a subset of the `amount` field and are used to provide
    /// more detailed information about the transaction.
    /// </summary>
    public required CardFinancialAdditionalAmounts AdditionalAmounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardFinancialAdditionalAmounts>(
                "additional_amounts"
            );
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
    public required ApiEnum<string, CardFinancialDirection> Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardFinancialDirection>>(
                "direction"
            );
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
    public required CardFinancialNetworkDetails NetworkDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardFinancialNetworkDetails>("network_details");
        }
        init { this._rawData.Set("network_details", value); }
    }

    /// <summary>
    /// Network-specific identifiers for a specific request or transaction.
    /// </summary>
    public required CardFinancialNetworkIdentifiers NetworkIdentifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardFinancialNetworkIdentifiers>(
                "network_identifiers"
            );
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
    public required ApiEnum<string, CardFinancialProcessingCategory> ProcessingCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardFinancialProcessingCategory>>(
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
    public required ApiEnum<string, CardFinancialType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardFinancialType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Fields related to verification of cardholder-provided values.
    /// </summary>
    public required CardFinancialVerification Verification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardFinancialVerification>("verification");
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
[JsonConverter(typeof(CardFinancialActionerConverter))]
public enum CardFinancialActioner
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

sealed class CardFinancialActionerConverter : JsonConverter<CardFinancialActioner>
{
    public override CardFinancialActioner Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => CardFinancialActioner.User,
            "increase" => CardFinancialActioner.Increase,
            "network" => CardFinancialActioner.Network,
            _ => (CardFinancialActioner)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardFinancialActioner value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardFinancialActioner.User => "user",
                CardFinancialActioner.Increase => "increase",
                CardFinancialActioner.Network => "network",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialAdditionalAmounts,
        CardFinancialAdditionalAmountsFromRaw
    >)
)]
public sealed record class CardFinancialAdditionalAmounts : JsonModel
{
    /// <summary>
    /// The part of this transaction amount that was for clinic-related services.
    /// </summary>
    public required CardFinancialAdditionalAmountsClinic? Clinic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardFinancialAdditionalAmountsClinic>("clinic");
        }
        init { this._rawData.Set("clinic", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for dental-related services.
    /// </summary>
    public required CardFinancialAdditionalAmountsDental? Dental
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardFinancialAdditionalAmountsDental>("dental");
        }
        init { this._rawData.Set("dental", value); }
    }

    /// <summary>
    /// The original pre-authorized amount.
    /// </summary>
    public required CardFinancialAdditionalAmountsOriginal? Original
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardFinancialAdditionalAmountsOriginal>(
                "original"
            );
        }
        init { this._rawData.Set("original", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for healthcare prescriptions.
    /// </summary>
    public required CardFinancialAdditionalAmountsPrescription? Prescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardFinancialAdditionalAmountsPrescription>(
                "prescription"
            );
        }
        init { this._rawData.Set("prescription", value); }
    }

    /// <summary>
    /// The surcharge amount charged for this transaction by the merchant.
    /// </summary>
    public required CardFinancialAdditionalAmountsSurcharge? Surcharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardFinancialAdditionalAmountsSurcharge>(
                "surcharge"
            );
        }
        init { this._rawData.Set("surcharge", value); }
    }

    /// <summary>
    /// The total amount of a series of incremental authorizations, optionally provided.
    /// </summary>
    public required CardFinancialAdditionalAmountsTotalCumulative? TotalCumulative
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardFinancialAdditionalAmountsTotalCumulative>(
                "total_cumulative"
            );
        }
        init { this._rawData.Set("total_cumulative", value); }
    }

    /// <summary>
    /// The total amount of healthcare-related additional amounts.
    /// </summary>
    public required CardFinancialAdditionalAmountsTotalHealthcare? TotalHealthcare
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardFinancialAdditionalAmountsTotalHealthcare>(
                "total_healthcare"
            );
        }
        init { this._rawData.Set("total_healthcare", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for transit-related services.
    /// </summary>
    public required CardFinancialAdditionalAmountsTransit? Transit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardFinancialAdditionalAmountsTransit>("transit");
        }
        init { this._rawData.Set("transit", value); }
    }

    /// <summary>
    /// An unknown additional amount.
    /// </summary>
    public required CardFinancialAdditionalAmountsUnknown? Unknown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardFinancialAdditionalAmountsUnknown>("unknown");
        }
        init { this._rawData.Set("unknown", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for vision-related services.
    /// </summary>
    public required CardFinancialAdditionalAmountsVision? Vision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardFinancialAdditionalAmountsVision>("vision");
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

    public CardFinancialAdditionalAmounts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialAdditionalAmounts(
        CardFinancialAdditionalAmounts cardFinancialAdditionalAmounts
    )
        : base(cardFinancialAdditionalAmounts) { }
#pragma warning restore CS8618

    public CardFinancialAdditionalAmounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialAdditionalAmounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialAdditionalAmountsFromRaw.FromRawUnchecked"/>
    public static CardFinancialAdditionalAmounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialAdditionalAmountsFromRaw : IFromRawJson<CardFinancialAdditionalAmounts>
{
    /// <inheritdoc/>
    public CardFinancialAdditionalAmounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialAdditionalAmounts.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for clinic-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialAdditionalAmountsClinic,
        CardFinancialAdditionalAmountsClinicFromRaw
    >)
)]
public sealed record class CardFinancialAdditionalAmountsClinic : JsonModel
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

    public CardFinancialAdditionalAmountsClinic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialAdditionalAmountsClinic(
        CardFinancialAdditionalAmountsClinic cardFinancialAdditionalAmountsClinic
    )
        : base(cardFinancialAdditionalAmountsClinic) { }
#pragma warning restore CS8618

    public CardFinancialAdditionalAmountsClinic(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialAdditionalAmountsClinic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialAdditionalAmountsClinicFromRaw.FromRawUnchecked"/>
    public static CardFinancialAdditionalAmountsClinic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialAdditionalAmountsClinicFromRaw
    : IFromRawJson<CardFinancialAdditionalAmountsClinic>
{
    /// <inheritdoc/>
    public CardFinancialAdditionalAmountsClinic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialAdditionalAmountsClinic.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for dental-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialAdditionalAmountsDental,
        CardFinancialAdditionalAmountsDentalFromRaw
    >)
)]
public sealed record class CardFinancialAdditionalAmountsDental : JsonModel
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

    public CardFinancialAdditionalAmountsDental() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialAdditionalAmountsDental(
        CardFinancialAdditionalAmountsDental cardFinancialAdditionalAmountsDental
    )
        : base(cardFinancialAdditionalAmountsDental) { }
#pragma warning restore CS8618

    public CardFinancialAdditionalAmountsDental(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialAdditionalAmountsDental(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialAdditionalAmountsDentalFromRaw.FromRawUnchecked"/>
    public static CardFinancialAdditionalAmountsDental FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialAdditionalAmountsDentalFromRaw
    : IFromRawJson<CardFinancialAdditionalAmountsDental>
{
    /// <inheritdoc/>
    public CardFinancialAdditionalAmountsDental FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialAdditionalAmountsDental.FromRawUnchecked(rawData);
}

/// <summary>
/// The original pre-authorized amount.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialAdditionalAmountsOriginal,
        CardFinancialAdditionalAmountsOriginalFromRaw
    >)
)]
public sealed record class CardFinancialAdditionalAmountsOriginal : JsonModel
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

    public CardFinancialAdditionalAmountsOriginal() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialAdditionalAmountsOriginal(
        CardFinancialAdditionalAmountsOriginal cardFinancialAdditionalAmountsOriginal
    )
        : base(cardFinancialAdditionalAmountsOriginal) { }
#pragma warning restore CS8618

    public CardFinancialAdditionalAmountsOriginal(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialAdditionalAmountsOriginal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialAdditionalAmountsOriginalFromRaw.FromRawUnchecked"/>
    public static CardFinancialAdditionalAmountsOriginal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialAdditionalAmountsOriginalFromRaw
    : IFromRawJson<CardFinancialAdditionalAmountsOriginal>
{
    /// <inheritdoc/>
    public CardFinancialAdditionalAmountsOriginal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialAdditionalAmountsOriginal.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for healthcare prescriptions.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialAdditionalAmountsPrescription,
        CardFinancialAdditionalAmountsPrescriptionFromRaw
    >)
)]
public sealed record class CardFinancialAdditionalAmountsPrescription : JsonModel
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

    public CardFinancialAdditionalAmountsPrescription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialAdditionalAmountsPrescription(
        CardFinancialAdditionalAmountsPrescription cardFinancialAdditionalAmountsPrescription
    )
        : base(cardFinancialAdditionalAmountsPrescription) { }
#pragma warning restore CS8618

    public CardFinancialAdditionalAmountsPrescription(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialAdditionalAmountsPrescription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialAdditionalAmountsPrescriptionFromRaw.FromRawUnchecked"/>
    public static CardFinancialAdditionalAmountsPrescription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialAdditionalAmountsPrescriptionFromRaw
    : IFromRawJson<CardFinancialAdditionalAmountsPrescription>
{
    /// <inheritdoc/>
    public CardFinancialAdditionalAmountsPrescription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialAdditionalAmountsPrescription.FromRawUnchecked(rawData);
}

/// <summary>
/// The surcharge amount charged for this transaction by the merchant.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialAdditionalAmountsSurcharge,
        CardFinancialAdditionalAmountsSurchargeFromRaw
    >)
)]
public sealed record class CardFinancialAdditionalAmountsSurcharge : JsonModel
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

    public CardFinancialAdditionalAmountsSurcharge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialAdditionalAmountsSurcharge(
        CardFinancialAdditionalAmountsSurcharge cardFinancialAdditionalAmountsSurcharge
    )
        : base(cardFinancialAdditionalAmountsSurcharge) { }
#pragma warning restore CS8618

    public CardFinancialAdditionalAmountsSurcharge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialAdditionalAmountsSurcharge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialAdditionalAmountsSurchargeFromRaw.FromRawUnchecked"/>
    public static CardFinancialAdditionalAmountsSurcharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialAdditionalAmountsSurchargeFromRaw
    : IFromRawJson<CardFinancialAdditionalAmountsSurcharge>
{
    /// <inheritdoc/>
    public CardFinancialAdditionalAmountsSurcharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialAdditionalAmountsSurcharge.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of a series of incremental authorizations, optionally provided.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialAdditionalAmountsTotalCumulative,
        CardFinancialAdditionalAmountsTotalCumulativeFromRaw
    >)
)]
public sealed record class CardFinancialAdditionalAmountsTotalCumulative : JsonModel
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

    public CardFinancialAdditionalAmountsTotalCumulative() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialAdditionalAmountsTotalCumulative(
        CardFinancialAdditionalAmountsTotalCumulative cardFinancialAdditionalAmountsTotalCumulative
    )
        : base(cardFinancialAdditionalAmountsTotalCumulative) { }
#pragma warning restore CS8618

    public CardFinancialAdditionalAmountsTotalCumulative(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialAdditionalAmountsTotalCumulative(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialAdditionalAmountsTotalCumulativeFromRaw.FromRawUnchecked"/>
    public static CardFinancialAdditionalAmountsTotalCumulative FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialAdditionalAmountsTotalCumulativeFromRaw
    : IFromRawJson<CardFinancialAdditionalAmountsTotalCumulative>
{
    /// <inheritdoc/>
    public CardFinancialAdditionalAmountsTotalCumulative FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialAdditionalAmountsTotalCumulative.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of healthcare-related additional amounts.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialAdditionalAmountsTotalHealthcare,
        CardFinancialAdditionalAmountsTotalHealthcareFromRaw
    >)
)]
public sealed record class CardFinancialAdditionalAmountsTotalHealthcare : JsonModel
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

    public CardFinancialAdditionalAmountsTotalHealthcare() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialAdditionalAmountsTotalHealthcare(
        CardFinancialAdditionalAmountsTotalHealthcare cardFinancialAdditionalAmountsTotalHealthcare
    )
        : base(cardFinancialAdditionalAmountsTotalHealthcare) { }
#pragma warning restore CS8618

    public CardFinancialAdditionalAmountsTotalHealthcare(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialAdditionalAmountsTotalHealthcare(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialAdditionalAmountsTotalHealthcareFromRaw.FromRawUnchecked"/>
    public static CardFinancialAdditionalAmountsTotalHealthcare FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialAdditionalAmountsTotalHealthcareFromRaw
    : IFromRawJson<CardFinancialAdditionalAmountsTotalHealthcare>
{
    /// <inheritdoc/>
    public CardFinancialAdditionalAmountsTotalHealthcare FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialAdditionalAmountsTotalHealthcare.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for transit-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialAdditionalAmountsTransit,
        CardFinancialAdditionalAmountsTransitFromRaw
    >)
)]
public sealed record class CardFinancialAdditionalAmountsTransit : JsonModel
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

    public CardFinancialAdditionalAmountsTransit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialAdditionalAmountsTransit(
        CardFinancialAdditionalAmountsTransit cardFinancialAdditionalAmountsTransit
    )
        : base(cardFinancialAdditionalAmountsTransit) { }
#pragma warning restore CS8618

    public CardFinancialAdditionalAmountsTransit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialAdditionalAmountsTransit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialAdditionalAmountsTransitFromRaw.FromRawUnchecked"/>
    public static CardFinancialAdditionalAmountsTransit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialAdditionalAmountsTransitFromRaw
    : IFromRawJson<CardFinancialAdditionalAmountsTransit>
{
    /// <inheritdoc/>
    public CardFinancialAdditionalAmountsTransit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialAdditionalAmountsTransit.FromRawUnchecked(rawData);
}

/// <summary>
/// An unknown additional amount.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialAdditionalAmountsUnknown,
        CardFinancialAdditionalAmountsUnknownFromRaw
    >)
)]
public sealed record class CardFinancialAdditionalAmountsUnknown : JsonModel
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

    public CardFinancialAdditionalAmountsUnknown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialAdditionalAmountsUnknown(
        CardFinancialAdditionalAmountsUnknown cardFinancialAdditionalAmountsUnknown
    )
        : base(cardFinancialAdditionalAmountsUnknown) { }
#pragma warning restore CS8618

    public CardFinancialAdditionalAmountsUnknown(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialAdditionalAmountsUnknown(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialAdditionalAmountsUnknownFromRaw.FromRawUnchecked"/>
    public static CardFinancialAdditionalAmountsUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialAdditionalAmountsUnknownFromRaw
    : IFromRawJson<CardFinancialAdditionalAmountsUnknown>
{
    /// <inheritdoc/>
    public CardFinancialAdditionalAmountsUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialAdditionalAmountsUnknown.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for vision-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialAdditionalAmountsVision,
        CardFinancialAdditionalAmountsVisionFromRaw
    >)
)]
public sealed record class CardFinancialAdditionalAmountsVision : JsonModel
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

    public CardFinancialAdditionalAmountsVision() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialAdditionalAmountsVision(
        CardFinancialAdditionalAmountsVision cardFinancialAdditionalAmountsVision
    )
        : base(cardFinancialAdditionalAmountsVision) { }
#pragma warning restore CS8618

    public CardFinancialAdditionalAmountsVision(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialAdditionalAmountsVision(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialAdditionalAmountsVisionFromRaw.FromRawUnchecked"/>
    public static CardFinancialAdditionalAmountsVision FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialAdditionalAmountsVisionFromRaw
    : IFromRawJson<CardFinancialAdditionalAmountsVision>
{
    /// <inheritdoc/>
    public CardFinancialAdditionalAmountsVision FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialAdditionalAmountsVision.FromRawUnchecked(rawData);
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
[JsonConverter(typeof(CardFinancialDirectionConverter))]
public enum CardFinancialDirection
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

sealed class CardFinancialDirectionConverter : JsonConverter<CardFinancialDirection>
{
    public override CardFinancialDirection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "settlement" => CardFinancialDirection.Settlement,
            "refund" => CardFinancialDirection.Refund,
            _ => (CardFinancialDirection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardFinancialDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardFinancialDirection.Settlement => "settlement",
                CardFinancialDirection.Refund => "refund",
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
[JsonConverter(
    typeof(JsonModelConverter<CardFinancialNetworkDetails, CardFinancialNetworkDetailsFromRaw>)
)]
public sealed record class CardFinancialNetworkDetails : JsonModel
{
    /// <summary>
    /// The payment network used to process this card authorization.
    /// </summary>
    public required ApiEnum<string, CardFinancialNetworkDetailsCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardFinancialNetworkDetailsCategory>
            >("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Fields specific to the `pulse` network.
    /// </summary>
    public required CardFinancialNetworkDetailsPulse? Pulse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardFinancialNetworkDetailsPulse>("pulse");
        }
        init { this._rawData.Set("pulse", value); }
    }

    /// <summary>
    /// Fields specific to the `visa` network.
    /// </summary>
    public required CardFinancialNetworkDetailsVisa? Visa
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardFinancialNetworkDetailsVisa>("visa");
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

    public CardFinancialNetworkDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialNetworkDetails(CardFinancialNetworkDetails cardFinancialNetworkDetails)
        : base(cardFinancialNetworkDetails) { }
#pragma warning restore CS8618

    public CardFinancialNetworkDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialNetworkDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialNetworkDetailsFromRaw.FromRawUnchecked"/>
    public static CardFinancialNetworkDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialNetworkDetailsFromRaw : IFromRawJson<CardFinancialNetworkDetails>
{
    /// <inheritdoc/>
    public CardFinancialNetworkDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialNetworkDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// The payment network used to process this card authorization.
/// </summary>
[JsonConverter(typeof(CardFinancialNetworkDetailsCategoryConverter))]
public enum CardFinancialNetworkDetailsCategory
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

sealed class CardFinancialNetworkDetailsCategoryConverter
    : JsonConverter<CardFinancialNetworkDetailsCategory>
{
    public override CardFinancialNetworkDetailsCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => CardFinancialNetworkDetailsCategory.Visa,
            "pulse" => CardFinancialNetworkDetailsCategory.Pulse,
            _ => (CardFinancialNetworkDetailsCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardFinancialNetworkDetailsCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardFinancialNetworkDetailsCategory.Visa => "visa",
                CardFinancialNetworkDetailsCategory.Pulse => "pulse",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialNetworkDetailsPulse,
        CardFinancialNetworkDetailsPulseFromRaw
    >)
)]
public sealed record class CardFinancialNetworkDetailsPulse : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public CardFinancialNetworkDetailsPulse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialNetworkDetailsPulse(
        CardFinancialNetworkDetailsPulse cardFinancialNetworkDetailsPulse
    )
        : base(cardFinancialNetworkDetailsPulse) { }
#pragma warning restore CS8618

    public CardFinancialNetworkDetailsPulse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialNetworkDetailsPulse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialNetworkDetailsPulseFromRaw.FromRawUnchecked"/>
    public static CardFinancialNetworkDetailsPulse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialNetworkDetailsPulseFromRaw : IFromRawJson<CardFinancialNetworkDetailsPulse>
{
    /// <inheritdoc/>
    public CardFinancialNetworkDetailsPulse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialNetworkDetailsPulse.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields specific to the `visa` network.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialNetworkDetailsVisa,
        CardFinancialNetworkDetailsVisaFromRaw
    >)
)]
public sealed record class CardFinancialNetworkDetailsVisa : JsonModel
{
    /// <summary>
    /// For electronic commerce transactions, this identifies the level of security
    /// used in obtaining the customer's payment credential. For mail or telephone
    /// order transactions, identifies the type of mail or telephone order.
    /// </summary>
    public required ApiEnum<
        string,
        CardFinancialNetworkDetailsVisaElectronicCommerceIndicator
    >? ElectronicCommerceIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardFinancialNetworkDetailsVisaElectronicCommerceIndicator>
            >("electronic_commerce_indicator");
        }
        init { this._rawData.Set("electronic_commerce_indicator", value); }
    }

    /// <summary>
    /// The method used to enter the cardholder's primary account number and card
    /// expiration date.
    /// </summary>
    public required ApiEnum<
        string,
        CardFinancialNetworkDetailsVisaPointOfServiceEntryMode
    >? PointOfServiceEntryMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardFinancialNetworkDetailsVisaPointOfServiceEntryMode>
            >("point_of_service_entry_mode");
        }
        init { this._rawData.Set("point_of_service_entry_mode", value); }
    }

    /// <summary>
    /// Only present when `actioner: network`. Describes why a card authorization
    /// was approved or declined by Visa through stand-in processing.
    /// </summary>
    public required ApiEnum<
        string,
        CardFinancialNetworkDetailsVisaStandInProcessingReason
    >? StandInProcessingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardFinancialNetworkDetailsVisaStandInProcessingReason>
            >("stand_in_processing_reason");
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
    public required ApiEnum<
        string,
        CardFinancialNetworkDetailsVisaTerminalEntryCapability
    >? TerminalEntryCapability
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardFinancialNetworkDetailsVisaTerminalEntryCapability>
            >("terminal_entry_capability");
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

    public CardFinancialNetworkDetailsVisa() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialNetworkDetailsVisa(
        CardFinancialNetworkDetailsVisa cardFinancialNetworkDetailsVisa
    )
        : base(cardFinancialNetworkDetailsVisa) { }
#pragma warning restore CS8618

    public CardFinancialNetworkDetailsVisa(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialNetworkDetailsVisa(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialNetworkDetailsVisaFromRaw.FromRawUnchecked"/>
    public static CardFinancialNetworkDetailsVisa FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialNetworkDetailsVisaFromRaw : IFromRawJson<CardFinancialNetworkDetailsVisa>
{
    /// <inheritdoc/>
    public CardFinancialNetworkDetailsVisa FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialNetworkDetailsVisa.FromRawUnchecked(rawData);
}

/// <summary>
/// For electronic commerce transactions, this identifies the level of security used
/// in obtaining the customer's payment credential. For mail or telephone order transactions,
/// identifies the type of mail or telephone order.
/// </summary>
[JsonConverter(typeof(CardFinancialNetworkDetailsVisaElectronicCommerceIndicatorConverter))]
public enum CardFinancialNetworkDetailsVisaElectronicCommerceIndicator
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

sealed class CardFinancialNetworkDetailsVisaElectronicCommerceIndicatorConverter
    : JsonConverter<CardFinancialNetworkDetailsVisaElectronicCommerceIndicator>
{
    public override CardFinancialNetworkDetailsVisaElectronicCommerceIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mail_phone_order" =>
                CardFinancialNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
            "recurring" => CardFinancialNetworkDetailsVisaElectronicCommerceIndicator.Recurring,
            "installment" => CardFinancialNetworkDetailsVisaElectronicCommerceIndicator.Installment,
            "unknown_mail_phone_order" =>
                CardFinancialNetworkDetailsVisaElectronicCommerceIndicator.UnknownMailPhoneOrder,
            "secure_electronic_commerce" =>
                CardFinancialNetworkDetailsVisaElectronicCommerceIndicator.SecureElectronicCommerce,
            "non_authenticated_security_transaction_at_3ds_capable_merchant" =>
                CardFinancialNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant,
            "non_authenticated_security_transaction" =>
                CardFinancialNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction,
            "non_secure_transaction" =>
                CardFinancialNetworkDetailsVisaElectronicCommerceIndicator.NonSecureTransaction,
            _ => (CardFinancialNetworkDetailsVisaElectronicCommerceIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardFinancialNetworkDetailsVisaElectronicCommerceIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardFinancialNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder =>
                    "mail_phone_order",
                CardFinancialNetworkDetailsVisaElectronicCommerceIndicator.Recurring => "recurring",
                CardFinancialNetworkDetailsVisaElectronicCommerceIndicator.Installment =>
                    "installment",
                CardFinancialNetworkDetailsVisaElectronicCommerceIndicator.UnknownMailPhoneOrder =>
                    "unknown_mail_phone_order",
                CardFinancialNetworkDetailsVisaElectronicCommerceIndicator.SecureElectronicCommerce =>
                    "secure_electronic_commerce",
                CardFinancialNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant =>
                    "non_authenticated_security_transaction_at_3ds_capable_merchant",
                CardFinancialNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction =>
                    "non_authenticated_security_transaction",
                CardFinancialNetworkDetailsVisaElectronicCommerceIndicator.NonSecureTransaction =>
                    "non_secure_transaction",
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
[JsonConverter(typeof(CardFinancialNetworkDetailsVisaPointOfServiceEntryModeConverter))]
public enum CardFinancialNetworkDetailsVisaPointOfServiceEntryMode
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

sealed class CardFinancialNetworkDetailsVisaPointOfServiceEntryModeConverter
    : JsonConverter<CardFinancialNetworkDetailsVisaPointOfServiceEntryMode>
{
    public override CardFinancialNetworkDetailsVisaPointOfServiceEntryMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" => CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
            "manual" => CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.Manual,
            "magnetic_stripe_no_cvv" =>
                CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripeNoCvv,
            "optical_code" => CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.OpticalCode,
            "integrated_circuit_card" =>
                CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCard,
            "contactless" => CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.Contactless,
            "credential_on_file" =>
                CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.CredentialOnFile,
            "magnetic_stripe" =>
                CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripe,
            "contactless_magnetic_stripe" =>
                CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.ContactlessMagneticStripe,
            "integrated_circuit_card_no_cvv" =>
                CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCardNoCvv,
            _ => (CardFinancialNetworkDetailsVisaPointOfServiceEntryMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardFinancialNetworkDetailsVisaPointOfServiceEntryMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.Unknown => "unknown",
                CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.Manual => "manual",
                CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripeNoCvv =>
                    "magnetic_stripe_no_cvv",
                CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.OpticalCode =>
                    "optical_code",
                CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCard =>
                    "integrated_circuit_card",
                CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.Contactless => "contactless",
                CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.CredentialOnFile =>
                    "credential_on_file",
                CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripe =>
                    "magnetic_stripe",
                CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.ContactlessMagneticStripe =>
                    "contactless_magnetic_stripe",
                CardFinancialNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCardNoCvv =>
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
[JsonConverter(typeof(CardFinancialNetworkDetailsVisaStandInProcessingReasonConverter))]
public enum CardFinancialNetworkDetailsVisaStandInProcessingReason
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

sealed class CardFinancialNetworkDetailsVisaStandInProcessingReasonConverter
    : JsonConverter<CardFinancialNetworkDetailsVisaStandInProcessingReason>
{
    public override CardFinancialNetworkDetailsVisaStandInProcessingReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "issuer_error" => CardFinancialNetworkDetailsVisaStandInProcessingReason.IssuerError,
            "invalid_physical_card" =>
                CardFinancialNetworkDetailsVisaStandInProcessingReason.InvalidPhysicalCard,
            "invalid_cryptogram" =>
                CardFinancialNetworkDetailsVisaStandInProcessingReason.InvalidCryptogram,
            "invalid_cardholder_authentication_verification_value" =>
                CardFinancialNetworkDetailsVisaStandInProcessingReason.InvalidCardholderAuthenticationVerificationValue,
            "internal_visa_error" =>
                CardFinancialNetworkDetailsVisaStandInProcessingReason.InternalVisaError,
            "merchant_transaction_advisory_service_authentication_required" =>
                CardFinancialNetworkDetailsVisaStandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired,
            "payment_fraud_disruption_acquirer_block" =>
                CardFinancialNetworkDetailsVisaStandInProcessingReason.PaymentFraudDisruptionAcquirerBlock,
            "other" => CardFinancialNetworkDetailsVisaStandInProcessingReason.Other,
            _ => (CardFinancialNetworkDetailsVisaStandInProcessingReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardFinancialNetworkDetailsVisaStandInProcessingReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardFinancialNetworkDetailsVisaStandInProcessingReason.IssuerError =>
                    "issuer_error",
                CardFinancialNetworkDetailsVisaStandInProcessingReason.InvalidPhysicalCard =>
                    "invalid_physical_card",
                CardFinancialNetworkDetailsVisaStandInProcessingReason.InvalidCryptogram =>
                    "invalid_cryptogram",
                CardFinancialNetworkDetailsVisaStandInProcessingReason.InvalidCardholderAuthenticationVerificationValue =>
                    "invalid_cardholder_authentication_verification_value",
                CardFinancialNetworkDetailsVisaStandInProcessingReason.InternalVisaError =>
                    "internal_visa_error",
                CardFinancialNetworkDetailsVisaStandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired =>
                    "merchant_transaction_advisory_service_authentication_required",
                CardFinancialNetworkDetailsVisaStandInProcessingReason.PaymentFraudDisruptionAcquirerBlock =>
                    "payment_fraud_disruption_acquirer_block",
                CardFinancialNetworkDetailsVisaStandInProcessingReason.Other => "other",
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
[JsonConverter(typeof(CardFinancialNetworkDetailsVisaTerminalEntryCapabilityConverter))]
public enum CardFinancialNetworkDetailsVisaTerminalEntryCapability
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

sealed class CardFinancialNetworkDetailsVisaTerminalEntryCapabilityConverter
    : JsonConverter<CardFinancialNetworkDetailsVisaTerminalEntryCapability>
{
    public override CardFinancialNetworkDetailsVisaTerminalEntryCapability Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" => CardFinancialNetworkDetailsVisaTerminalEntryCapability.Unknown,
            "terminal_not_used" =>
                CardFinancialNetworkDetailsVisaTerminalEntryCapability.TerminalNotUsed,
            "magnetic_stripe" =>
                CardFinancialNetworkDetailsVisaTerminalEntryCapability.MagneticStripe,
            "barcode" => CardFinancialNetworkDetailsVisaTerminalEntryCapability.Barcode,
            "optical_character_recognition" =>
                CardFinancialNetworkDetailsVisaTerminalEntryCapability.OpticalCharacterRecognition,
            "chip_or_contactless" =>
                CardFinancialNetworkDetailsVisaTerminalEntryCapability.ChipOrContactless,
            "contactless_only" =>
                CardFinancialNetworkDetailsVisaTerminalEntryCapability.ContactlessOnly,
            "no_capability" => CardFinancialNetworkDetailsVisaTerminalEntryCapability.NoCapability,
            _ => (CardFinancialNetworkDetailsVisaTerminalEntryCapability)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardFinancialNetworkDetailsVisaTerminalEntryCapability value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardFinancialNetworkDetailsVisaTerminalEntryCapability.Unknown => "unknown",
                CardFinancialNetworkDetailsVisaTerminalEntryCapability.TerminalNotUsed =>
                    "terminal_not_used",
                CardFinancialNetworkDetailsVisaTerminalEntryCapability.MagneticStripe =>
                    "magnetic_stripe",
                CardFinancialNetworkDetailsVisaTerminalEntryCapability.Barcode => "barcode",
                CardFinancialNetworkDetailsVisaTerminalEntryCapability.OpticalCharacterRecognition =>
                    "optical_character_recognition",
                CardFinancialNetworkDetailsVisaTerminalEntryCapability.ChipOrContactless =>
                    "chip_or_contactless",
                CardFinancialNetworkDetailsVisaTerminalEntryCapability.ContactlessOnly =>
                    "contactless_only",
                CardFinancialNetworkDetailsVisaTerminalEntryCapability.NoCapability =>
                    "no_capability",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialNetworkIdentifiers,
        CardFinancialNetworkIdentifiersFromRaw
    >)
)]
public sealed record class CardFinancialNetworkIdentifiers : JsonModel
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

    public CardFinancialNetworkIdentifiers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialNetworkIdentifiers(
        CardFinancialNetworkIdentifiers cardFinancialNetworkIdentifiers
    )
        : base(cardFinancialNetworkIdentifiers) { }
#pragma warning restore CS8618

    public CardFinancialNetworkIdentifiers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialNetworkIdentifiers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialNetworkIdentifiersFromRaw.FromRawUnchecked"/>
    public static CardFinancialNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialNetworkIdentifiersFromRaw : IFromRawJson<CardFinancialNetworkIdentifiers>
{
    /// <inheritdoc/>
    public CardFinancialNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialNetworkIdentifiers.FromRawUnchecked(rawData);
}

/// <summary>
/// The processing category describes the intent behind the financial, such as whether
/// it was used for bill payments or an automatic fuel dispenser.
/// </summary>
[JsonConverter(typeof(CardFinancialProcessingCategoryConverter))]
public enum CardFinancialProcessingCategory
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

sealed class CardFinancialProcessingCategoryConverter
    : JsonConverter<CardFinancialProcessingCategory>
{
    public override CardFinancialProcessingCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_funding" => CardFinancialProcessingCategory.AccountFunding,
            "automatic_fuel_dispenser" => CardFinancialProcessingCategory.AutomaticFuelDispenser,
            "bill_payment" => CardFinancialProcessingCategory.BillPayment,
            "original_credit" => CardFinancialProcessingCategory.OriginalCredit,
            "purchase" => CardFinancialProcessingCategory.Purchase,
            "quasi_cash" => CardFinancialProcessingCategory.QuasiCash,
            "refund" => CardFinancialProcessingCategory.Refund,
            "cash_disbursement" => CardFinancialProcessingCategory.CashDisbursement,
            "balance_inquiry" => CardFinancialProcessingCategory.BalanceInquiry,
            "unknown" => CardFinancialProcessingCategory.Unknown,
            _ => (CardFinancialProcessingCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardFinancialProcessingCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardFinancialProcessingCategory.AccountFunding => "account_funding",
                CardFinancialProcessingCategory.AutomaticFuelDispenser =>
                    "automatic_fuel_dispenser",
                CardFinancialProcessingCategory.BillPayment => "bill_payment",
                CardFinancialProcessingCategory.OriginalCredit => "original_credit",
                CardFinancialProcessingCategory.Purchase => "purchase",
                CardFinancialProcessingCategory.QuasiCash => "quasi_cash",
                CardFinancialProcessingCategory.Refund => "refund",
                CardFinancialProcessingCategory.CashDisbursement => "cash_disbursement",
                CardFinancialProcessingCategory.BalanceInquiry => "balance_inquiry",
                CardFinancialProcessingCategory.Unknown => "unknown",
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
[JsonConverter(typeof(CardFinancialTypeConverter))]
public enum CardFinancialType
{
    CardFinancial,
}

sealed class CardFinancialTypeConverter : JsonConverter<CardFinancialType>
{
    public override CardFinancialType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_financial" => CardFinancialType.CardFinancial,
            _ => (CardFinancialType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardFinancialType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardFinancialType.CardFinancial => "card_financial",
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
[JsonConverter(
    typeof(JsonModelConverter<CardFinancialVerification, CardFinancialVerificationFromRaw>)
)]
public sealed record class CardFinancialVerification : JsonModel
{
    /// <summary>
    /// Fields related to verification of the Card Verification Code, a 3-digit code
    /// on the back of the card.
    /// </summary>
    public required CardFinancialVerificationCardVerificationCode CardVerificationCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardFinancialVerificationCardVerificationCode>(
                "card_verification_code"
            );
        }
        init { this._rawData.Set("card_verification_code", value); }
    }

    /// <summary>
    /// Cardholder address provided in the authorization request and the address
    /// on file we verified it against.
    /// </summary>
    public required CardFinancialVerificationCardholderAddress CardholderAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardFinancialVerificationCardholderAddress>(
                "cardholder_address"
            );
        }
        init { this._rawData.Set("cardholder_address", value); }
    }

    /// <summary>
    /// Cardholder name provided in the authorization request.
    /// </summary>
    public required CardFinancialVerificationCardholderName? CardholderName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardFinancialVerificationCardholderName>(
                "cardholder_name"
            );
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

    public CardFinancialVerification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialVerification(CardFinancialVerification cardFinancialVerification)
        : base(cardFinancialVerification) { }
#pragma warning restore CS8618

    public CardFinancialVerification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialVerification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialVerificationFromRaw.FromRawUnchecked"/>
    public static CardFinancialVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialVerificationFromRaw : IFromRawJson<CardFinancialVerification>
{
    /// <inheritdoc/>
    public CardFinancialVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialVerification.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields related to verification of the Card Verification Code, a 3-digit code
/// on the back of the card.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialVerificationCardVerificationCode,
        CardFinancialVerificationCardVerificationCodeFromRaw
    >)
)]
public sealed record class CardFinancialVerificationCardVerificationCode : JsonModel
{
    /// <summary>
    /// The result of verifying the Card Verification Code.
    /// </summary>
    public required ApiEnum<string, CardFinancialVerificationCardVerificationCodeResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardFinancialVerificationCardVerificationCodeResult>
            >("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Result.Validate();
    }

    public CardFinancialVerificationCardVerificationCode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialVerificationCardVerificationCode(
        CardFinancialVerificationCardVerificationCode cardFinancialVerificationCardVerificationCode
    )
        : base(cardFinancialVerificationCardVerificationCode) { }
#pragma warning restore CS8618

    public CardFinancialVerificationCardVerificationCode(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialVerificationCardVerificationCode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialVerificationCardVerificationCodeFromRaw.FromRawUnchecked"/>
    public static CardFinancialVerificationCardVerificationCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardFinancialVerificationCardVerificationCode(
        ApiEnum<string, CardFinancialVerificationCardVerificationCodeResult> result
    )
        : this()
    {
        this.Result = result;
    }
}

class CardFinancialVerificationCardVerificationCodeFromRaw
    : IFromRawJson<CardFinancialVerificationCardVerificationCode>
{
    /// <inheritdoc/>
    public CardFinancialVerificationCardVerificationCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialVerificationCardVerificationCode.FromRawUnchecked(rawData);
}

/// <summary>
/// The result of verifying the Card Verification Code.
/// </summary>
[JsonConverter(typeof(CardFinancialVerificationCardVerificationCodeResultConverter))]
public enum CardFinancialVerificationCardVerificationCodeResult
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

sealed class CardFinancialVerificationCardVerificationCodeResultConverter
    : JsonConverter<CardFinancialVerificationCardVerificationCodeResult>
{
    public override CardFinancialVerificationCardVerificationCodeResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_checked" => CardFinancialVerificationCardVerificationCodeResult.NotChecked,
            "match" => CardFinancialVerificationCardVerificationCodeResult.Match,
            "no_match" => CardFinancialVerificationCardVerificationCodeResult.NoMatch,
            _ => (CardFinancialVerificationCardVerificationCodeResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardFinancialVerificationCardVerificationCodeResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardFinancialVerificationCardVerificationCodeResult.NotChecked => "not_checked",
                CardFinancialVerificationCardVerificationCodeResult.Match => "match",
                CardFinancialVerificationCardVerificationCodeResult.NoMatch => "no_match",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialVerificationCardholderAddress,
        CardFinancialVerificationCardholderAddressFromRaw
    >)
)]
public sealed record class CardFinancialVerificationCardholderAddress : JsonModel
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
    public required ApiEnum<string, CardFinancialVerificationCardholderAddressResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardFinancialVerificationCardholderAddressResult>
            >("result");
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

    public CardFinancialVerificationCardholderAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialVerificationCardholderAddress(
        CardFinancialVerificationCardholderAddress cardFinancialVerificationCardholderAddress
    )
        : base(cardFinancialVerificationCardholderAddress) { }
#pragma warning restore CS8618

    public CardFinancialVerificationCardholderAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialVerificationCardholderAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialVerificationCardholderAddressFromRaw.FromRawUnchecked"/>
    public static CardFinancialVerificationCardholderAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialVerificationCardholderAddressFromRaw
    : IFromRawJson<CardFinancialVerificationCardholderAddress>
{
    /// <inheritdoc/>
    public CardFinancialVerificationCardholderAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialVerificationCardholderAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The address verification result returned to the card network.
/// </summary>
[JsonConverter(typeof(CardFinancialVerificationCardholderAddressResultConverter))]
public enum CardFinancialVerificationCardholderAddressResult
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

sealed class CardFinancialVerificationCardholderAddressResultConverter
    : JsonConverter<CardFinancialVerificationCardholderAddressResult>
{
    public override CardFinancialVerificationCardholderAddressResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_checked" => CardFinancialVerificationCardholderAddressResult.NotChecked,
            "postal_code_match_address_no_match" =>
                CardFinancialVerificationCardholderAddressResult.PostalCodeMatchAddressNoMatch,
            "postal_code_no_match_address_match" =>
                CardFinancialVerificationCardholderAddressResult.PostalCodeNoMatchAddressMatch,
            "match" => CardFinancialVerificationCardholderAddressResult.Match,
            "no_match" => CardFinancialVerificationCardholderAddressResult.NoMatch,
            "postal_code_match_address_not_checked" =>
                CardFinancialVerificationCardholderAddressResult.PostalCodeMatchAddressNotChecked,
            _ => (CardFinancialVerificationCardholderAddressResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardFinancialVerificationCardholderAddressResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardFinancialVerificationCardholderAddressResult.NotChecked => "not_checked",
                CardFinancialVerificationCardholderAddressResult.PostalCodeMatchAddressNoMatch =>
                    "postal_code_match_address_no_match",
                CardFinancialVerificationCardholderAddressResult.PostalCodeNoMatchAddressMatch =>
                    "postal_code_no_match_address_match",
                CardFinancialVerificationCardholderAddressResult.Match => "match",
                CardFinancialVerificationCardholderAddressResult.NoMatch => "no_match",
                CardFinancialVerificationCardholderAddressResult.PostalCodeMatchAddressNotChecked =>
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardFinancialVerificationCardholderName,
        CardFinancialVerificationCardholderNameFromRaw
    >)
)]
public sealed record class CardFinancialVerificationCardholderName : JsonModel
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

    public CardFinancialVerificationCardholderName() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFinancialVerificationCardholderName(
        CardFinancialVerificationCardholderName cardFinancialVerificationCardholderName
    )
        : base(cardFinancialVerificationCardholderName) { }
#pragma warning restore CS8618

    public CardFinancialVerificationCardholderName(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFinancialVerificationCardholderName(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFinancialVerificationCardholderNameFromRaw.FromRawUnchecked"/>
    public static CardFinancialVerificationCardholderName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFinancialVerificationCardholderNameFromRaw
    : IFromRawJson<CardFinancialVerificationCardholderName>
{
    /// <inheritdoc/>
    public CardFinancialVerificationCardholderName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFinancialVerificationCardholderName.FromRawUnchecked(rawData);
}

/// <summary>
/// A Card Fuel Confirmation object. This field will be present in the JSON response
/// if and only if `category` is equal to `card_fuel_confirmation`. Card Fuel Confirmations
/// update the amount of a Card Authorization after a fuel pump transaction is completed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardFuelConfirmation, CardFuelConfirmationFromRaw>))]
public sealed record class CardFuelConfirmation : JsonModel
{
    /// <summary>
    /// The Card Fuel Confirmation identifier.
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
    /// The identifier for the Card Authorization this updates.
    /// </summary>
    public required string CardAuthorizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("card_authorization_id");
        }
        init { this._rawData.Set("card_authorization_id", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the increment's currency.
    /// </summary>
    public required ApiEnum<string, CardFuelConfirmationCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardFuelConfirmationCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The card network used to process this card authorization.
    /// </summary>
    public required ApiEnum<string, CardFuelConfirmationNetwork> Network
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardFuelConfirmationNetwork>>(
                "network"
            );
        }
        init { this._rawData.Set("network", value); }
    }

    /// <summary>
    /// Network-specific identifiers for a specific request or transaction.
    /// </summary>
    public required CardFuelConfirmationNetworkIdentifiers NetworkIdentifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardFuelConfirmationNetworkIdentifiers>(
                "network_identifiers"
            );
        }
        init { this._rawData.Set("network_identifiers", value); }
    }

    /// <summary>
    /// The identifier of the Pending Transaction associated with this Card Fuel Confirmation.
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
    /// A constant representing the object's type. For this resource it will always
    /// be `card_fuel_confirmation`.
    /// </summary>
    public required ApiEnum<string, CardFuelConfirmationType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardFuelConfirmationType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The updated authorization amount after this fuel confirmation, in the minor
    /// unit of the transaction's currency. For dollars, for example, this is cents.
    /// </summary>
    public required long UpdatedAuthorizationAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("updated_authorization_amount");
        }
        init { this._rawData.Set("updated_authorization_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CardAuthorizationID;
        this.Currency.Validate();
        this.Network.Validate();
        this.NetworkIdentifiers.Validate();
        _ = this.PendingTransactionID;
        this.Type.Validate();
        _ = this.UpdatedAuthorizationAmount;
    }

    public CardFuelConfirmation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFuelConfirmation(CardFuelConfirmation cardFuelConfirmation)
        : base(cardFuelConfirmation) { }
#pragma warning restore CS8618

    public CardFuelConfirmation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFuelConfirmation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFuelConfirmationFromRaw.FromRawUnchecked"/>
    public static CardFuelConfirmation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFuelConfirmationFromRaw : IFromRawJson<CardFuelConfirmation>
{
    /// <inheritdoc/>
    public CardFuelConfirmation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFuelConfirmation.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the increment's currency.
/// </summary>
[JsonConverter(typeof(CardFuelConfirmationCurrencyConverter))]
public enum CardFuelConfirmationCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardFuelConfirmationCurrencyConverter : JsonConverter<CardFuelConfirmationCurrency>
{
    public override CardFuelConfirmationCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardFuelConfirmationCurrency.Usd,
            _ => (CardFuelConfirmationCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardFuelConfirmationCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardFuelConfirmationCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The card network used to process this card authorization.
/// </summary>
[JsonConverter(typeof(CardFuelConfirmationNetworkConverter))]
public enum CardFuelConfirmationNetwork
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

sealed class CardFuelConfirmationNetworkConverter : JsonConverter<CardFuelConfirmationNetwork>
{
    public override CardFuelConfirmationNetwork Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => CardFuelConfirmationNetwork.Visa,
            "pulse" => CardFuelConfirmationNetwork.Pulse,
            _ => (CardFuelConfirmationNetwork)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardFuelConfirmationNetwork value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardFuelConfirmationNetwork.Visa => "visa",
                CardFuelConfirmationNetwork.Pulse => "pulse",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardFuelConfirmationNetworkIdentifiers,
        CardFuelConfirmationNetworkIdentifiersFromRaw
    >)
)]
public sealed record class CardFuelConfirmationNetworkIdentifiers : JsonModel
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

    public CardFuelConfirmationNetworkIdentifiers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardFuelConfirmationNetworkIdentifiers(
        CardFuelConfirmationNetworkIdentifiers cardFuelConfirmationNetworkIdentifiers
    )
        : base(cardFuelConfirmationNetworkIdentifiers) { }
#pragma warning restore CS8618

    public CardFuelConfirmationNetworkIdentifiers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardFuelConfirmationNetworkIdentifiers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFuelConfirmationNetworkIdentifiersFromRaw.FromRawUnchecked"/>
    public static CardFuelConfirmationNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFuelConfirmationNetworkIdentifiersFromRaw
    : IFromRawJson<CardFuelConfirmationNetworkIdentifiers>
{
    /// <inheritdoc/>
    public CardFuelConfirmationNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardFuelConfirmationNetworkIdentifiers.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_fuel_confirmation`.
/// </summary>
[JsonConverter(typeof(CardFuelConfirmationTypeConverter))]
public enum CardFuelConfirmationType
{
    CardFuelConfirmation,
}

sealed class CardFuelConfirmationTypeConverter : JsonConverter<CardFuelConfirmationType>
{
    public override CardFuelConfirmationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_fuel_confirmation" => CardFuelConfirmationType.CardFuelConfirmation,
            _ => (CardFuelConfirmationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardFuelConfirmationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardFuelConfirmationType.CardFuelConfirmation => "card_fuel_confirmation",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A Card Increment object. This field will be present in the JSON response if and
/// only if `category` is equal to `card_increment`. Card Increments increase the
/// pending amount of an authorized transaction.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardIncrement, CardIncrementFromRaw>))]
public sealed record class CardIncrement : JsonModel
{
    /// <summary>
    /// The Card Increment identifier.
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
    public required ApiEnum<string, CardIncrementActioner> Actioner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardIncrementActioner>>(
                "actioner"
            );
        }
        init { this._rawData.Set("actioner", value); }
    }

    /// <summary>
    /// Additional amounts associated with the card authorization, such as ATM surcharges
    /// fees. These are usually a subset of the `amount` field and are used to provide
    /// more detailed information about the transaction.
    /// </summary>
    public required CardIncrementAdditionalAmounts AdditionalAmounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardIncrementAdditionalAmounts>(
                "additional_amounts"
            );
        }
        init { this._rawData.Set("additional_amounts", value); }
    }

    /// <summary>
    /// The amount of this increment in the minor unit of the transaction's currency.
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
    /// The identifier for the Card Authorization this increments.
    /// </summary>
    public required string CardAuthorizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("card_authorization_id");
        }
        init { this._rawData.Set("card_authorization_id", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the increment's currency.
    /// </summary>
    public required ApiEnum<string, CardIncrementCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardIncrementCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The card network used to process this card authorization.
    /// </summary>
    public required ApiEnum<string, CardIncrementNetwork> Network
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardIncrementNetwork>>("network");
        }
        init { this._rawData.Set("network", value); }
    }

    /// <summary>
    /// Network-specific identifiers for a specific request or transaction.
    /// </summary>
    public required CardIncrementNetworkIdentifiers NetworkIdentifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardIncrementNetworkIdentifiers>(
                "network_identifiers"
            );
        }
        init { this._rawData.Set("network_identifiers", value); }
    }

    /// <summary>
    /// The risk score generated by the card network. For Visa this is the Visa Advanced
    /// Authorization risk score, from 0 to 99, where 99 is the riskiest.
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
    /// The identifier of the Pending Transaction associated with this Card Increment.
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
    /// The amount of this increment in the minor unit of the transaction's presentment currency.
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
    /// The identifier of the Real-Time Decision sent to approve or decline this
    /// incremental authorization.
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
    /// A constant representing the object's type. For this resource it will always
    /// be `card_increment`.
    /// </summary>
    public required ApiEnum<string, CardIncrementType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardIncrementType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The updated authorization amount after this increment, in the minor unit of
    /// the transaction's currency. For dollars, for example, this is cents.
    /// </summary>
    public required long UpdatedAuthorizationAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("updated_authorization_amount");
        }
        init { this._rawData.Set("updated_authorization_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Actioner.Validate();
        this.AdditionalAmounts.Validate();
        _ = this.Amount;
        _ = this.CardAuthorizationID;
        this.Currency.Validate();
        this.Network.Validate();
        this.NetworkIdentifiers.Validate();
        _ = this.NetworkRiskScore;
        _ = this.PendingTransactionID;
        _ = this.PresentmentAmount;
        _ = this.PresentmentCurrency;
        _ = this.RealTimeDecisionID;
        this.Type.Validate();
        _ = this.UpdatedAuthorizationAmount;
    }

    public CardIncrement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardIncrement(CardIncrement cardIncrement)
        : base(cardIncrement) { }
#pragma warning restore CS8618

    public CardIncrement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardIncrement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardIncrementFromRaw.FromRawUnchecked"/>
    public static CardIncrement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardIncrementFromRaw : IFromRawJson<CardIncrement>
{
    /// <inheritdoc/>
    public CardIncrement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardIncrement.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether this authorization was approved by Increase, the card network through
/// stand-in processing, or the user through a real-time decision.
/// </summary>
[JsonConverter(typeof(CardIncrementActionerConverter))]
public enum CardIncrementActioner
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

sealed class CardIncrementActionerConverter : JsonConverter<CardIncrementActioner>
{
    public override CardIncrementActioner Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => CardIncrementActioner.User,
            "increase" => CardIncrementActioner.Increase,
            "network" => CardIncrementActioner.Network,
            _ => (CardIncrementActioner)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardIncrementActioner value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardIncrementActioner.User => "user",
                CardIncrementActioner.Increase => "increase",
                CardIncrementActioner.Network => "network",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardIncrementAdditionalAmounts,
        CardIncrementAdditionalAmountsFromRaw
    >)
)]
public sealed record class CardIncrementAdditionalAmounts : JsonModel
{
    /// <summary>
    /// The part of this transaction amount that was for clinic-related services.
    /// </summary>
    public required CardIncrementAdditionalAmountsClinic? Clinic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardIncrementAdditionalAmountsClinic>("clinic");
        }
        init { this._rawData.Set("clinic", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for dental-related services.
    /// </summary>
    public required CardIncrementAdditionalAmountsDental? Dental
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardIncrementAdditionalAmountsDental>("dental");
        }
        init { this._rawData.Set("dental", value); }
    }

    /// <summary>
    /// The original pre-authorized amount.
    /// </summary>
    public required CardIncrementAdditionalAmountsOriginal? Original
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardIncrementAdditionalAmountsOriginal>(
                "original"
            );
        }
        init { this._rawData.Set("original", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for healthcare prescriptions.
    /// </summary>
    public required CardIncrementAdditionalAmountsPrescription? Prescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardIncrementAdditionalAmountsPrescription>(
                "prescription"
            );
        }
        init { this._rawData.Set("prescription", value); }
    }

    /// <summary>
    /// The surcharge amount charged for this transaction by the merchant.
    /// </summary>
    public required CardIncrementAdditionalAmountsSurcharge? Surcharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardIncrementAdditionalAmountsSurcharge>(
                "surcharge"
            );
        }
        init { this._rawData.Set("surcharge", value); }
    }

    /// <summary>
    /// The total amount of a series of incremental authorizations, optionally provided.
    /// </summary>
    public required CardIncrementAdditionalAmountsTotalCumulative? TotalCumulative
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardIncrementAdditionalAmountsTotalCumulative>(
                "total_cumulative"
            );
        }
        init { this._rawData.Set("total_cumulative", value); }
    }

    /// <summary>
    /// The total amount of healthcare-related additional amounts.
    /// </summary>
    public required CardIncrementAdditionalAmountsTotalHealthcare? TotalHealthcare
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardIncrementAdditionalAmountsTotalHealthcare>(
                "total_healthcare"
            );
        }
        init { this._rawData.Set("total_healthcare", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for transit-related services.
    /// </summary>
    public required CardIncrementAdditionalAmountsTransit? Transit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardIncrementAdditionalAmountsTransit>("transit");
        }
        init { this._rawData.Set("transit", value); }
    }

    /// <summary>
    /// An unknown additional amount.
    /// </summary>
    public required CardIncrementAdditionalAmountsUnknown? Unknown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardIncrementAdditionalAmountsUnknown>("unknown");
        }
        init { this._rawData.Set("unknown", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for vision-related services.
    /// </summary>
    public required CardIncrementAdditionalAmountsVision? Vision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardIncrementAdditionalAmountsVision>("vision");
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

    public CardIncrementAdditionalAmounts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardIncrementAdditionalAmounts(
        CardIncrementAdditionalAmounts cardIncrementAdditionalAmounts
    )
        : base(cardIncrementAdditionalAmounts) { }
#pragma warning restore CS8618

    public CardIncrementAdditionalAmounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardIncrementAdditionalAmounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardIncrementAdditionalAmountsFromRaw.FromRawUnchecked"/>
    public static CardIncrementAdditionalAmounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardIncrementAdditionalAmountsFromRaw : IFromRawJson<CardIncrementAdditionalAmounts>
{
    /// <inheritdoc/>
    public CardIncrementAdditionalAmounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardIncrementAdditionalAmounts.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for clinic-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardIncrementAdditionalAmountsClinic,
        CardIncrementAdditionalAmountsClinicFromRaw
    >)
)]
public sealed record class CardIncrementAdditionalAmountsClinic : JsonModel
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

    public CardIncrementAdditionalAmountsClinic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardIncrementAdditionalAmountsClinic(
        CardIncrementAdditionalAmountsClinic cardIncrementAdditionalAmountsClinic
    )
        : base(cardIncrementAdditionalAmountsClinic) { }
#pragma warning restore CS8618

    public CardIncrementAdditionalAmountsClinic(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardIncrementAdditionalAmountsClinic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardIncrementAdditionalAmountsClinicFromRaw.FromRawUnchecked"/>
    public static CardIncrementAdditionalAmountsClinic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardIncrementAdditionalAmountsClinicFromRaw
    : IFromRawJson<CardIncrementAdditionalAmountsClinic>
{
    /// <inheritdoc/>
    public CardIncrementAdditionalAmountsClinic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardIncrementAdditionalAmountsClinic.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for dental-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardIncrementAdditionalAmountsDental,
        CardIncrementAdditionalAmountsDentalFromRaw
    >)
)]
public sealed record class CardIncrementAdditionalAmountsDental : JsonModel
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

    public CardIncrementAdditionalAmountsDental() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardIncrementAdditionalAmountsDental(
        CardIncrementAdditionalAmountsDental cardIncrementAdditionalAmountsDental
    )
        : base(cardIncrementAdditionalAmountsDental) { }
#pragma warning restore CS8618

    public CardIncrementAdditionalAmountsDental(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardIncrementAdditionalAmountsDental(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardIncrementAdditionalAmountsDentalFromRaw.FromRawUnchecked"/>
    public static CardIncrementAdditionalAmountsDental FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardIncrementAdditionalAmountsDentalFromRaw
    : IFromRawJson<CardIncrementAdditionalAmountsDental>
{
    /// <inheritdoc/>
    public CardIncrementAdditionalAmountsDental FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardIncrementAdditionalAmountsDental.FromRawUnchecked(rawData);
}

/// <summary>
/// The original pre-authorized amount.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardIncrementAdditionalAmountsOriginal,
        CardIncrementAdditionalAmountsOriginalFromRaw
    >)
)]
public sealed record class CardIncrementAdditionalAmountsOriginal : JsonModel
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

    public CardIncrementAdditionalAmountsOriginal() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardIncrementAdditionalAmountsOriginal(
        CardIncrementAdditionalAmountsOriginal cardIncrementAdditionalAmountsOriginal
    )
        : base(cardIncrementAdditionalAmountsOriginal) { }
#pragma warning restore CS8618

    public CardIncrementAdditionalAmountsOriginal(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardIncrementAdditionalAmountsOriginal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardIncrementAdditionalAmountsOriginalFromRaw.FromRawUnchecked"/>
    public static CardIncrementAdditionalAmountsOriginal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardIncrementAdditionalAmountsOriginalFromRaw
    : IFromRawJson<CardIncrementAdditionalAmountsOriginal>
{
    /// <inheritdoc/>
    public CardIncrementAdditionalAmountsOriginal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardIncrementAdditionalAmountsOriginal.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for healthcare prescriptions.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardIncrementAdditionalAmountsPrescription,
        CardIncrementAdditionalAmountsPrescriptionFromRaw
    >)
)]
public sealed record class CardIncrementAdditionalAmountsPrescription : JsonModel
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

    public CardIncrementAdditionalAmountsPrescription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardIncrementAdditionalAmountsPrescription(
        CardIncrementAdditionalAmountsPrescription cardIncrementAdditionalAmountsPrescription
    )
        : base(cardIncrementAdditionalAmountsPrescription) { }
#pragma warning restore CS8618

    public CardIncrementAdditionalAmountsPrescription(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardIncrementAdditionalAmountsPrescription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardIncrementAdditionalAmountsPrescriptionFromRaw.FromRawUnchecked"/>
    public static CardIncrementAdditionalAmountsPrescription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardIncrementAdditionalAmountsPrescriptionFromRaw
    : IFromRawJson<CardIncrementAdditionalAmountsPrescription>
{
    /// <inheritdoc/>
    public CardIncrementAdditionalAmountsPrescription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardIncrementAdditionalAmountsPrescription.FromRawUnchecked(rawData);
}

/// <summary>
/// The surcharge amount charged for this transaction by the merchant.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardIncrementAdditionalAmountsSurcharge,
        CardIncrementAdditionalAmountsSurchargeFromRaw
    >)
)]
public sealed record class CardIncrementAdditionalAmountsSurcharge : JsonModel
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

    public CardIncrementAdditionalAmountsSurcharge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardIncrementAdditionalAmountsSurcharge(
        CardIncrementAdditionalAmountsSurcharge cardIncrementAdditionalAmountsSurcharge
    )
        : base(cardIncrementAdditionalAmountsSurcharge) { }
#pragma warning restore CS8618

    public CardIncrementAdditionalAmountsSurcharge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardIncrementAdditionalAmountsSurcharge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardIncrementAdditionalAmountsSurchargeFromRaw.FromRawUnchecked"/>
    public static CardIncrementAdditionalAmountsSurcharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardIncrementAdditionalAmountsSurchargeFromRaw
    : IFromRawJson<CardIncrementAdditionalAmountsSurcharge>
{
    /// <inheritdoc/>
    public CardIncrementAdditionalAmountsSurcharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardIncrementAdditionalAmountsSurcharge.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of a series of incremental authorizations, optionally provided.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardIncrementAdditionalAmountsTotalCumulative,
        CardIncrementAdditionalAmountsTotalCumulativeFromRaw
    >)
)]
public sealed record class CardIncrementAdditionalAmountsTotalCumulative : JsonModel
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

    public CardIncrementAdditionalAmountsTotalCumulative() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardIncrementAdditionalAmountsTotalCumulative(
        CardIncrementAdditionalAmountsTotalCumulative cardIncrementAdditionalAmountsTotalCumulative
    )
        : base(cardIncrementAdditionalAmountsTotalCumulative) { }
#pragma warning restore CS8618

    public CardIncrementAdditionalAmountsTotalCumulative(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardIncrementAdditionalAmountsTotalCumulative(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardIncrementAdditionalAmountsTotalCumulativeFromRaw.FromRawUnchecked"/>
    public static CardIncrementAdditionalAmountsTotalCumulative FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardIncrementAdditionalAmountsTotalCumulativeFromRaw
    : IFromRawJson<CardIncrementAdditionalAmountsTotalCumulative>
{
    /// <inheritdoc/>
    public CardIncrementAdditionalAmountsTotalCumulative FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardIncrementAdditionalAmountsTotalCumulative.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of healthcare-related additional amounts.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardIncrementAdditionalAmountsTotalHealthcare,
        CardIncrementAdditionalAmountsTotalHealthcareFromRaw
    >)
)]
public sealed record class CardIncrementAdditionalAmountsTotalHealthcare : JsonModel
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

    public CardIncrementAdditionalAmountsTotalHealthcare() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardIncrementAdditionalAmountsTotalHealthcare(
        CardIncrementAdditionalAmountsTotalHealthcare cardIncrementAdditionalAmountsTotalHealthcare
    )
        : base(cardIncrementAdditionalAmountsTotalHealthcare) { }
#pragma warning restore CS8618

    public CardIncrementAdditionalAmountsTotalHealthcare(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardIncrementAdditionalAmountsTotalHealthcare(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardIncrementAdditionalAmountsTotalHealthcareFromRaw.FromRawUnchecked"/>
    public static CardIncrementAdditionalAmountsTotalHealthcare FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardIncrementAdditionalAmountsTotalHealthcareFromRaw
    : IFromRawJson<CardIncrementAdditionalAmountsTotalHealthcare>
{
    /// <inheritdoc/>
    public CardIncrementAdditionalAmountsTotalHealthcare FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardIncrementAdditionalAmountsTotalHealthcare.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for transit-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardIncrementAdditionalAmountsTransit,
        CardIncrementAdditionalAmountsTransitFromRaw
    >)
)]
public sealed record class CardIncrementAdditionalAmountsTransit : JsonModel
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

    public CardIncrementAdditionalAmountsTransit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardIncrementAdditionalAmountsTransit(
        CardIncrementAdditionalAmountsTransit cardIncrementAdditionalAmountsTransit
    )
        : base(cardIncrementAdditionalAmountsTransit) { }
#pragma warning restore CS8618

    public CardIncrementAdditionalAmountsTransit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardIncrementAdditionalAmountsTransit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardIncrementAdditionalAmountsTransitFromRaw.FromRawUnchecked"/>
    public static CardIncrementAdditionalAmountsTransit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardIncrementAdditionalAmountsTransitFromRaw
    : IFromRawJson<CardIncrementAdditionalAmountsTransit>
{
    /// <inheritdoc/>
    public CardIncrementAdditionalAmountsTransit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardIncrementAdditionalAmountsTransit.FromRawUnchecked(rawData);
}

/// <summary>
/// An unknown additional amount.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardIncrementAdditionalAmountsUnknown,
        CardIncrementAdditionalAmountsUnknownFromRaw
    >)
)]
public sealed record class CardIncrementAdditionalAmountsUnknown : JsonModel
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

    public CardIncrementAdditionalAmountsUnknown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardIncrementAdditionalAmountsUnknown(
        CardIncrementAdditionalAmountsUnknown cardIncrementAdditionalAmountsUnknown
    )
        : base(cardIncrementAdditionalAmountsUnknown) { }
#pragma warning restore CS8618

    public CardIncrementAdditionalAmountsUnknown(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardIncrementAdditionalAmountsUnknown(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardIncrementAdditionalAmountsUnknownFromRaw.FromRawUnchecked"/>
    public static CardIncrementAdditionalAmountsUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardIncrementAdditionalAmountsUnknownFromRaw
    : IFromRawJson<CardIncrementAdditionalAmountsUnknown>
{
    /// <inheritdoc/>
    public CardIncrementAdditionalAmountsUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardIncrementAdditionalAmountsUnknown.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for vision-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardIncrementAdditionalAmountsVision,
        CardIncrementAdditionalAmountsVisionFromRaw
    >)
)]
public sealed record class CardIncrementAdditionalAmountsVision : JsonModel
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

    public CardIncrementAdditionalAmountsVision() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardIncrementAdditionalAmountsVision(
        CardIncrementAdditionalAmountsVision cardIncrementAdditionalAmountsVision
    )
        : base(cardIncrementAdditionalAmountsVision) { }
#pragma warning restore CS8618

    public CardIncrementAdditionalAmountsVision(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardIncrementAdditionalAmountsVision(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardIncrementAdditionalAmountsVisionFromRaw.FromRawUnchecked"/>
    public static CardIncrementAdditionalAmountsVision FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardIncrementAdditionalAmountsVisionFromRaw
    : IFromRawJson<CardIncrementAdditionalAmountsVision>
{
    /// <inheritdoc/>
    public CardIncrementAdditionalAmountsVision FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardIncrementAdditionalAmountsVision.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the increment's currency.
/// </summary>
[JsonConverter(typeof(CardIncrementCurrencyConverter))]
public enum CardIncrementCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardIncrementCurrencyConverter : JsonConverter<CardIncrementCurrency>
{
    public override CardIncrementCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardIncrementCurrency.Usd,
            _ => (CardIncrementCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardIncrementCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardIncrementCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The card network used to process this card authorization.
/// </summary>
[JsonConverter(typeof(CardIncrementNetworkConverter))]
public enum CardIncrementNetwork
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

sealed class CardIncrementNetworkConverter : JsonConverter<CardIncrementNetwork>
{
    public override CardIncrementNetwork Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => CardIncrementNetwork.Visa,
            "pulse" => CardIncrementNetwork.Pulse,
            _ => (CardIncrementNetwork)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardIncrementNetwork value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardIncrementNetwork.Visa => "visa",
                CardIncrementNetwork.Pulse => "pulse",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardIncrementNetworkIdentifiers,
        CardIncrementNetworkIdentifiersFromRaw
    >)
)]
public sealed record class CardIncrementNetworkIdentifiers : JsonModel
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

    public CardIncrementNetworkIdentifiers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardIncrementNetworkIdentifiers(
        CardIncrementNetworkIdentifiers cardIncrementNetworkIdentifiers
    )
        : base(cardIncrementNetworkIdentifiers) { }
#pragma warning restore CS8618

    public CardIncrementNetworkIdentifiers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardIncrementNetworkIdentifiers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardIncrementNetworkIdentifiersFromRaw.FromRawUnchecked"/>
    public static CardIncrementNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardIncrementNetworkIdentifiersFromRaw : IFromRawJson<CardIncrementNetworkIdentifiers>
{
    /// <inheritdoc/>
    public CardIncrementNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardIncrementNetworkIdentifiers.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_increment`.
/// </summary>
[JsonConverter(typeof(CardIncrementTypeConverter))]
public enum CardIncrementType
{
    CardIncrement,
}

sealed class CardIncrementTypeConverter : JsonConverter<CardIncrementType>
{
    public override CardIncrementType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_increment" => CardIncrementType.CardIncrement,
            _ => (CardIncrementType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardIncrementType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardIncrementType.CardIncrement => "card_increment",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
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
/// A Card Reversal object. This field will be present in the JSON response if and
/// only if `category` is equal to `card_reversal`. Card Reversals cancel parts of
/// or the entirety of an existing Card Authorization.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardReversal, CardReversalFromRaw>))]
public sealed record class CardReversal : JsonModel
{
    /// <summary>
    /// The Card Reversal identifier.
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
    /// The identifier for the Card Authorization this reverses.
    /// </summary>
    public required string CardAuthorizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("card_authorization_id");
        }
        init { this._rawData.Set("card_authorization_id", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the reversal's currency.
    /// </summary>
    public required ApiEnum<string, CardReversalCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardReversalCurrency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
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
    public required string? MerchantCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("merchant_country");
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
    /// The card network used to process this card authorization.
    /// </summary>
    public required ApiEnum<string, CardReversalNetwork> Network
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardReversalNetwork>>("network");
        }
        init { this._rawData.Set("network", value); }
    }

    /// <summary>
    /// Network-specific identifiers for a specific request or transaction.
    /// </summary>
    public required CardReversalNetworkIdentifiers NetworkIdentifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardReversalNetworkIdentifiers>(
                "network_identifiers"
            );
        }
        init { this._rawData.Set("network_identifiers", value); }
    }

    /// <summary>
    /// The identifier of the Pending Transaction associated with this Card Reversal.
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the reversal's
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
    /// The amount of this reversal in the minor unit of the transaction's currency.
    /// For dollars, for example, this is cents.
    /// </summary>
    public required long ReversalAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("reversal_amount");
        }
        init { this._rawData.Set("reversal_amount", value); }
    }

    /// <summary>
    /// The amount of this reversal in the minor unit of the transaction's presentment
    /// currency. For dollars, for example, this is cents.
    /// </summary>
    public required long ReversalPresentmentAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("reversal_presentment_amount");
        }
        init { this._rawData.Set("reversal_presentment_amount", value); }
    }

    /// <summary>
    /// Why this reversal was initiated.
    /// </summary>
    public required ApiEnum<string, ReversalReason>? ReversalReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ReversalReason>>(
                "reversal_reason"
            );
        }
        init { this._rawData.Set("reversal_reason", value); }
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
    /// be `card_reversal`.
    /// </summary>
    public required ApiEnum<string, CardReversalType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardReversalType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The amount left pending on the Card Authorization in the minor unit of the
    /// transaction's currency. For dollars, for example, this is cents.
    /// </summary>
    public required long UpdatedAuthorizationAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("updated_authorization_amount");
        }
        init { this._rawData.Set("updated_authorization_amount", value); }
    }

    /// <summary>
    /// The amount left pending on the Card Authorization in the minor unit of the
    /// transaction's presentment currency. For dollars, for example, this is cents.
    /// </summary>
    public required long UpdatedAuthorizationPresentmentAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("updated_authorization_presentment_amount");
        }
        init { this._rawData.Set("updated_authorization_presentment_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CardAuthorizationID;
        this.Currency.Validate();
        _ = this.MerchantAcceptorID;
        _ = this.MerchantCategoryCode;
        _ = this.MerchantCity;
        _ = this.MerchantCountry;
        _ = this.MerchantDescriptor;
        _ = this.MerchantPostalCode;
        _ = this.MerchantState;
        this.Network.Validate();
        this.NetworkIdentifiers.Validate();
        _ = this.PendingTransactionID;
        _ = this.PresentmentCurrency;
        _ = this.ReversalAmount;
        _ = this.ReversalPresentmentAmount;
        this.ReversalReason?.Validate();
        _ = this.TerminalID;
        this.Type.Validate();
        _ = this.UpdatedAuthorizationAmount;
        _ = this.UpdatedAuthorizationPresentmentAmount;
    }

    public CardReversal() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardReversal(CardReversal cardReversal)
        : base(cardReversal) { }
#pragma warning restore CS8618

    public CardReversal(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardReversal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardReversalFromRaw.FromRawUnchecked"/>
    public static CardReversal FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardReversalFromRaw : IFromRawJson<CardReversal>
{
    /// <inheritdoc/>
    public CardReversal FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardReversal.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the reversal's currency.
/// </summary>
[JsonConverter(typeof(CardReversalCurrencyConverter))]
public enum CardReversalCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardReversalCurrencyConverter : JsonConverter<CardReversalCurrency>
{
    public override CardReversalCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardReversalCurrency.Usd,
            _ => (CardReversalCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardReversalCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardReversalCurrency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The card network used to process this card authorization.
/// </summary>
[JsonConverter(typeof(CardReversalNetworkConverter))]
public enum CardReversalNetwork
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

sealed class CardReversalNetworkConverter : JsonConverter<CardReversalNetwork>
{
    public override CardReversalNetwork Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => CardReversalNetwork.Visa,
            "pulse" => CardReversalNetwork.Pulse,
            _ => (CardReversalNetwork)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardReversalNetwork value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardReversalNetwork.Visa => "visa",
                CardReversalNetwork.Pulse => "pulse",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardReversalNetworkIdentifiers,
        CardReversalNetworkIdentifiersFromRaw
    >)
)]
public sealed record class CardReversalNetworkIdentifiers : JsonModel
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

    public CardReversalNetworkIdentifiers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardReversalNetworkIdentifiers(
        CardReversalNetworkIdentifiers cardReversalNetworkIdentifiers
    )
        : base(cardReversalNetworkIdentifiers) { }
#pragma warning restore CS8618

    public CardReversalNetworkIdentifiers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardReversalNetworkIdentifiers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardReversalNetworkIdentifiersFromRaw.FromRawUnchecked"/>
    public static CardReversalNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardReversalNetworkIdentifiersFromRaw : IFromRawJson<CardReversalNetworkIdentifiers>
{
    /// <inheritdoc/>
    public CardReversalNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardReversalNetworkIdentifiers.FromRawUnchecked(rawData);
}

/// <summary>
/// Why this reversal was initiated.
/// </summary>
[JsonConverter(typeof(ReversalReasonConverter))]
public enum ReversalReason
{
    /// <summary>
    /// The Card Reversal was initiated at the customer's request.
    /// </summary>
    ReversedByCustomer,

    /// <summary>
    /// The Card Reversal was initiated by the network or acquirer.
    /// </summary>
    ReversedByNetworkOrAcquirer,

    /// <summary>
    /// The Card Reversal was initiated by the point of sale device.
    /// </summary>
    ReversedByPointOfSale,

    /// <summary>
    /// The Card Reversal was a partial reversal, for any reason.
    /// </summary>
    PartialReversal,
}

sealed class ReversalReasonConverter : JsonConverter<ReversalReason>
{
    public override ReversalReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "reversed_by_customer" => ReversalReason.ReversedByCustomer,
            "reversed_by_network_or_acquirer" => ReversalReason.ReversedByNetworkOrAcquirer,
            "reversed_by_point_of_sale" => ReversalReason.ReversedByPointOfSale,
            "partial_reversal" => ReversalReason.PartialReversal,
            _ => (ReversalReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReversalReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReversalReason.ReversedByCustomer => "reversed_by_customer",
                ReversalReason.ReversedByNetworkOrAcquirer => "reversed_by_network_or_acquirer",
                ReversalReason.ReversedByPointOfSale => "reversed_by_point_of_sale",
                ReversalReason.PartialReversal => "partial_reversal",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_reversal`.
/// </summary>
[JsonConverter(typeof(CardReversalTypeConverter))]
public enum CardReversalType
{
    CardReversal,
}

sealed class CardReversalTypeConverter : JsonConverter<CardReversalType>
{
    public override CardReversalType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_reversal" => CardReversalType.CardReversal,
            _ => (CardReversalType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardReversalType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardReversalType.CardReversal => "card_reversal",
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
/// An Inbound Card Validation object. This field will be present in the JSON response
/// if and only if `category` is equal to `card_validation`. Inbound Card Validations
/// are requests from a merchant to verify that a card number and optionally its
/// address and/or Card Verification Value are valid.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardValidation, CardValidationFromRaw>))]
public sealed record class CardValidation : JsonModel
{
    /// <summary>
    /// The Card Validation identifier.
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
    public required ApiEnum<string, CardValidationActioner> Actioner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardValidationActioner>>(
                "actioner"
            );
        }
        init { this._rawData.Set("actioner", value); }
    }

    /// <summary>
    /// Additional amounts associated with the card authorization, such as ATM surcharges
    /// fees. These are usually a subset of the `amount` field and are used to provide
    /// more detailed information about the transaction.
    /// </summary>
    public required CardValidationAdditionalAmounts AdditionalAmounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardValidationAdditionalAmounts>(
                "additional_amounts"
            );
        }
        init { this._rawData.Set("additional_amounts", value); }
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
    public required ApiEnum<string, CardValidationCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardValidationCurrency>>(
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
    public required CardValidationNetworkDetails NetworkDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardValidationNetworkDetails>("network_details");
        }
        init { this._rawData.Set("network_details", value); }
    }

    /// <summary>
    /// Network-specific identifiers for a specific request or transaction.
    /// </summary>
    public required CardValidationNetworkIdentifiers NetworkIdentifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardValidationNetworkIdentifiers>(
                "network_identifiers"
            );
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
    /// be `inbound_card_validation`.
    /// </summary>
    public required ApiEnum<string, CardValidationType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardValidationType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Fields related to verification of cardholder-provided values.
    /// </summary>
    public required CardValidationVerification Verification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardValidationVerification>("verification");
        }
        init { this._rawData.Set("verification", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Actioner.Validate();
        this.AdditionalAmounts.Validate();
        _ = this.CardPaymentID;
        this.Currency.Validate();
        _ = this.DigitalWalletTokenID;
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
        _ = this.RealTimeDecisionID;
        _ = this.TerminalID;
        this.Type.Validate();
        this.Verification.Validate();
    }

    public CardValidation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidation(CardValidation cardValidation)
        : base(cardValidation) { }
#pragma warning restore CS8618

    public CardValidation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationFromRaw.FromRawUnchecked"/>
    public static CardValidation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationFromRaw : IFromRawJson<CardValidation>
{
    /// <inheritdoc/>
    public CardValidation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardValidation.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether this authorization was approved by Increase, the card network through
/// stand-in processing, or the user through a real-time decision.
/// </summary>
[JsonConverter(typeof(CardValidationActionerConverter))]
public enum CardValidationActioner
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

sealed class CardValidationActionerConverter : JsonConverter<CardValidationActioner>
{
    public override CardValidationActioner Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => CardValidationActioner.User,
            "increase" => CardValidationActioner.Increase,
            "network" => CardValidationActioner.Network,
            _ => (CardValidationActioner)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardValidationActioner value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardValidationActioner.User => "user",
                CardValidationActioner.Increase => "increase",
                CardValidationActioner.Network => "network",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationAdditionalAmounts,
        CardValidationAdditionalAmountsFromRaw
    >)
)]
public sealed record class CardValidationAdditionalAmounts : JsonModel
{
    /// <summary>
    /// The part of this transaction amount that was for clinic-related services.
    /// </summary>
    public required CardValidationAdditionalAmountsClinic? Clinic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardValidationAdditionalAmountsClinic>("clinic");
        }
        init { this._rawData.Set("clinic", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for dental-related services.
    /// </summary>
    public required CardValidationAdditionalAmountsDental? Dental
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardValidationAdditionalAmountsDental>("dental");
        }
        init { this._rawData.Set("dental", value); }
    }

    /// <summary>
    /// The original pre-authorized amount.
    /// </summary>
    public required CardValidationAdditionalAmountsOriginal? Original
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardValidationAdditionalAmountsOriginal>(
                "original"
            );
        }
        init { this._rawData.Set("original", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for healthcare prescriptions.
    /// </summary>
    public required CardValidationAdditionalAmountsPrescription? Prescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardValidationAdditionalAmountsPrescription>(
                "prescription"
            );
        }
        init { this._rawData.Set("prescription", value); }
    }

    /// <summary>
    /// The surcharge amount charged for this transaction by the merchant.
    /// </summary>
    public required CardValidationAdditionalAmountsSurcharge? Surcharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardValidationAdditionalAmountsSurcharge>(
                "surcharge"
            );
        }
        init { this._rawData.Set("surcharge", value); }
    }

    /// <summary>
    /// The total amount of a series of incremental authorizations, optionally provided.
    /// </summary>
    public required CardValidationAdditionalAmountsTotalCumulative? TotalCumulative
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardValidationAdditionalAmountsTotalCumulative>(
                "total_cumulative"
            );
        }
        init { this._rawData.Set("total_cumulative", value); }
    }

    /// <summary>
    /// The total amount of healthcare-related additional amounts.
    /// </summary>
    public required CardValidationAdditionalAmountsTotalHealthcare? TotalHealthcare
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardValidationAdditionalAmountsTotalHealthcare>(
                "total_healthcare"
            );
        }
        init { this._rawData.Set("total_healthcare", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for transit-related services.
    /// </summary>
    public required CardValidationAdditionalAmountsTransit? Transit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardValidationAdditionalAmountsTransit>(
                "transit"
            );
        }
        init { this._rawData.Set("transit", value); }
    }

    /// <summary>
    /// An unknown additional amount.
    /// </summary>
    public required CardValidationAdditionalAmountsUnknown? Unknown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardValidationAdditionalAmountsUnknown>(
                "unknown"
            );
        }
        init { this._rawData.Set("unknown", value); }
    }

    /// <summary>
    /// The part of this transaction amount that was for vision-related services.
    /// </summary>
    public required CardValidationAdditionalAmountsVision? Vision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardValidationAdditionalAmountsVision>("vision");
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

    public CardValidationAdditionalAmounts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationAdditionalAmounts(
        CardValidationAdditionalAmounts cardValidationAdditionalAmounts
    )
        : base(cardValidationAdditionalAmounts) { }
#pragma warning restore CS8618

    public CardValidationAdditionalAmounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationAdditionalAmounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationAdditionalAmountsFromRaw.FromRawUnchecked"/>
    public static CardValidationAdditionalAmounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationAdditionalAmountsFromRaw : IFromRawJson<CardValidationAdditionalAmounts>
{
    /// <inheritdoc/>
    public CardValidationAdditionalAmounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationAdditionalAmounts.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for clinic-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationAdditionalAmountsClinic,
        CardValidationAdditionalAmountsClinicFromRaw
    >)
)]
public sealed record class CardValidationAdditionalAmountsClinic : JsonModel
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

    public CardValidationAdditionalAmountsClinic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationAdditionalAmountsClinic(
        CardValidationAdditionalAmountsClinic cardValidationAdditionalAmountsClinic
    )
        : base(cardValidationAdditionalAmountsClinic) { }
#pragma warning restore CS8618

    public CardValidationAdditionalAmountsClinic(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationAdditionalAmountsClinic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationAdditionalAmountsClinicFromRaw.FromRawUnchecked"/>
    public static CardValidationAdditionalAmountsClinic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationAdditionalAmountsClinicFromRaw
    : IFromRawJson<CardValidationAdditionalAmountsClinic>
{
    /// <inheritdoc/>
    public CardValidationAdditionalAmountsClinic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationAdditionalAmountsClinic.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for dental-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationAdditionalAmountsDental,
        CardValidationAdditionalAmountsDentalFromRaw
    >)
)]
public sealed record class CardValidationAdditionalAmountsDental : JsonModel
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

    public CardValidationAdditionalAmountsDental() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationAdditionalAmountsDental(
        CardValidationAdditionalAmountsDental cardValidationAdditionalAmountsDental
    )
        : base(cardValidationAdditionalAmountsDental) { }
#pragma warning restore CS8618

    public CardValidationAdditionalAmountsDental(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationAdditionalAmountsDental(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationAdditionalAmountsDentalFromRaw.FromRawUnchecked"/>
    public static CardValidationAdditionalAmountsDental FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationAdditionalAmountsDentalFromRaw
    : IFromRawJson<CardValidationAdditionalAmountsDental>
{
    /// <inheritdoc/>
    public CardValidationAdditionalAmountsDental FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationAdditionalAmountsDental.FromRawUnchecked(rawData);
}

/// <summary>
/// The original pre-authorized amount.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationAdditionalAmountsOriginal,
        CardValidationAdditionalAmountsOriginalFromRaw
    >)
)]
public sealed record class CardValidationAdditionalAmountsOriginal : JsonModel
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

    public CardValidationAdditionalAmountsOriginal() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationAdditionalAmountsOriginal(
        CardValidationAdditionalAmountsOriginal cardValidationAdditionalAmountsOriginal
    )
        : base(cardValidationAdditionalAmountsOriginal) { }
#pragma warning restore CS8618

    public CardValidationAdditionalAmountsOriginal(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationAdditionalAmountsOriginal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationAdditionalAmountsOriginalFromRaw.FromRawUnchecked"/>
    public static CardValidationAdditionalAmountsOriginal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationAdditionalAmountsOriginalFromRaw
    : IFromRawJson<CardValidationAdditionalAmountsOriginal>
{
    /// <inheritdoc/>
    public CardValidationAdditionalAmountsOriginal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationAdditionalAmountsOriginal.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for healthcare prescriptions.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationAdditionalAmountsPrescription,
        CardValidationAdditionalAmountsPrescriptionFromRaw
    >)
)]
public sealed record class CardValidationAdditionalAmountsPrescription : JsonModel
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

    public CardValidationAdditionalAmountsPrescription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationAdditionalAmountsPrescription(
        CardValidationAdditionalAmountsPrescription cardValidationAdditionalAmountsPrescription
    )
        : base(cardValidationAdditionalAmountsPrescription) { }
#pragma warning restore CS8618

    public CardValidationAdditionalAmountsPrescription(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationAdditionalAmountsPrescription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationAdditionalAmountsPrescriptionFromRaw.FromRawUnchecked"/>
    public static CardValidationAdditionalAmountsPrescription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationAdditionalAmountsPrescriptionFromRaw
    : IFromRawJson<CardValidationAdditionalAmountsPrescription>
{
    /// <inheritdoc/>
    public CardValidationAdditionalAmountsPrescription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationAdditionalAmountsPrescription.FromRawUnchecked(rawData);
}

/// <summary>
/// The surcharge amount charged for this transaction by the merchant.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationAdditionalAmountsSurcharge,
        CardValidationAdditionalAmountsSurchargeFromRaw
    >)
)]
public sealed record class CardValidationAdditionalAmountsSurcharge : JsonModel
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

    public CardValidationAdditionalAmountsSurcharge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationAdditionalAmountsSurcharge(
        CardValidationAdditionalAmountsSurcharge cardValidationAdditionalAmountsSurcharge
    )
        : base(cardValidationAdditionalAmountsSurcharge) { }
#pragma warning restore CS8618

    public CardValidationAdditionalAmountsSurcharge(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationAdditionalAmountsSurcharge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationAdditionalAmountsSurchargeFromRaw.FromRawUnchecked"/>
    public static CardValidationAdditionalAmountsSurcharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationAdditionalAmountsSurchargeFromRaw
    : IFromRawJson<CardValidationAdditionalAmountsSurcharge>
{
    /// <inheritdoc/>
    public CardValidationAdditionalAmountsSurcharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationAdditionalAmountsSurcharge.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of a series of incremental authorizations, optionally provided.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationAdditionalAmountsTotalCumulative,
        CardValidationAdditionalAmountsTotalCumulativeFromRaw
    >)
)]
public sealed record class CardValidationAdditionalAmountsTotalCumulative : JsonModel
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

    public CardValidationAdditionalAmountsTotalCumulative() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationAdditionalAmountsTotalCumulative(
        CardValidationAdditionalAmountsTotalCumulative cardValidationAdditionalAmountsTotalCumulative
    )
        : base(cardValidationAdditionalAmountsTotalCumulative) { }
#pragma warning restore CS8618

    public CardValidationAdditionalAmountsTotalCumulative(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationAdditionalAmountsTotalCumulative(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationAdditionalAmountsTotalCumulativeFromRaw.FromRawUnchecked"/>
    public static CardValidationAdditionalAmountsTotalCumulative FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationAdditionalAmountsTotalCumulativeFromRaw
    : IFromRawJson<CardValidationAdditionalAmountsTotalCumulative>
{
    /// <inheritdoc/>
    public CardValidationAdditionalAmountsTotalCumulative FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationAdditionalAmountsTotalCumulative.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of healthcare-related additional amounts.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationAdditionalAmountsTotalHealthcare,
        CardValidationAdditionalAmountsTotalHealthcareFromRaw
    >)
)]
public sealed record class CardValidationAdditionalAmountsTotalHealthcare : JsonModel
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

    public CardValidationAdditionalAmountsTotalHealthcare() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationAdditionalAmountsTotalHealthcare(
        CardValidationAdditionalAmountsTotalHealthcare cardValidationAdditionalAmountsTotalHealthcare
    )
        : base(cardValidationAdditionalAmountsTotalHealthcare) { }
#pragma warning restore CS8618

    public CardValidationAdditionalAmountsTotalHealthcare(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationAdditionalAmountsTotalHealthcare(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationAdditionalAmountsTotalHealthcareFromRaw.FromRawUnchecked"/>
    public static CardValidationAdditionalAmountsTotalHealthcare FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationAdditionalAmountsTotalHealthcareFromRaw
    : IFromRawJson<CardValidationAdditionalAmountsTotalHealthcare>
{
    /// <inheritdoc/>
    public CardValidationAdditionalAmountsTotalHealthcare FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationAdditionalAmountsTotalHealthcare.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for transit-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationAdditionalAmountsTransit,
        CardValidationAdditionalAmountsTransitFromRaw
    >)
)]
public sealed record class CardValidationAdditionalAmountsTransit : JsonModel
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

    public CardValidationAdditionalAmountsTransit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationAdditionalAmountsTransit(
        CardValidationAdditionalAmountsTransit cardValidationAdditionalAmountsTransit
    )
        : base(cardValidationAdditionalAmountsTransit) { }
#pragma warning restore CS8618

    public CardValidationAdditionalAmountsTransit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationAdditionalAmountsTransit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationAdditionalAmountsTransitFromRaw.FromRawUnchecked"/>
    public static CardValidationAdditionalAmountsTransit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationAdditionalAmountsTransitFromRaw
    : IFromRawJson<CardValidationAdditionalAmountsTransit>
{
    /// <inheritdoc/>
    public CardValidationAdditionalAmountsTransit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationAdditionalAmountsTransit.FromRawUnchecked(rawData);
}

/// <summary>
/// An unknown additional amount.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationAdditionalAmountsUnknown,
        CardValidationAdditionalAmountsUnknownFromRaw
    >)
)]
public sealed record class CardValidationAdditionalAmountsUnknown : JsonModel
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

    public CardValidationAdditionalAmountsUnknown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationAdditionalAmountsUnknown(
        CardValidationAdditionalAmountsUnknown cardValidationAdditionalAmountsUnknown
    )
        : base(cardValidationAdditionalAmountsUnknown) { }
#pragma warning restore CS8618

    public CardValidationAdditionalAmountsUnknown(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationAdditionalAmountsUnknown(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationAdditionalAmountsUnknownFromRaw.FromRawUnchecked"/>
    public static CardValidationAdditionalAmountsUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationAdditionalAmountsUnknownFromRaw
    : IFromRawJson<CardValidationAdditionalAmountsUnknown>
{
    /// <inheritdoc/>
    public CardValidationAdditionalAmountsUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationAdditionalAmountsUnknown.FromRawUnchecked(rawData);
}

/// <summary>
/// The part of this transaction amount that was for vision-related services.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationAdditionalAmountsVision,
        CardValidationAdditionalAmountsVisionFromRaw
    >)
)]
public sealed record class CardValidationAdditionalAmountsVision : JsonModel
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

    public CardValidationAdditionalAmountsVision() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationAdditionalAmountsVision(
        CardValidationAdditionalAmountsVision cardValidationAdditionalAmountsVision
    )
        : base(cardValidationAdditionalAmountsVision) { }
#pragma warning restore CS8618

    public CardValidationAdditionalAmountsVision(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationAdditionalAmountsVision(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationAdditionalAmountsVisionFromRaw.FromRawUnchecked"/>
    public static CardValidationAdditionalAmountsVision FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationAdditionalAmountsVisionFromRaw
    : IFromRawJson<CardValidationAdditionalAmountsVision>
{
    /// <inheritdoc/>
    public CardValidationAdditionalAmountsVision FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationAdditionalAmountsVision.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transaction's currency.
/// </summary>
[JsonConverter(typeof(CardValidationCurrencyConverter))]
public enum CardValidationCurrency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CardValidationCurrencyConverter : JsonConverter<CardValidationCurrency>
{
    public override CardValidationCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => CardValidationCurrency.Usd,
            _ => (CardValidationCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardValidationCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardValidationCurrency.Usd => "USD",
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
[JsonConverter(
    typeof(JsonModelConverter<CardValidationNetworkDetails, CardValidationNetworkDetailsFromRaw>)
)]
public sealed record class CardValidationNetworkDetails : JsonModel
{
    /// <summary>
    /// The payment network used to process this card authorization.
    /// </summary>
    public required ApiEnum<string, CardValidationNetworkDetailsCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardValidationNetworkDetailsCategory>
            >("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Fields specific to the `pulse` network.
    /// </summary>
    public required CardValidationNetworkDetailsPulse? Pulse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardValidationNetworkDetailsPulse>("pulse");
        }
        init { this._rawData.Set("pulse", value); }
    }

    /// <summary>
    /// Fields specific to the `visa` network.
    /// </summary>
    public required CardValidationNetworkDetailsVisa? Visa
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardValidationNetworkDetailsVisa>("visa");
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

    public CardValidationNetworkDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationNetworkDetails(CardValidationNetworkDetails cardValidationNetworkDetails)
        : base(cardValidationNetworkDetails) { }
#pragma warning restore CS8618

    public CardValidationNetworkDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationNetworkDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationNetworkDetailsFromRaw.FromRawUnchecked"/>
    public static CardValidationNetworkDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationNetworkDetailsFromRaw : IFromRawJson<CardValidationNetworkDetails>
{
    /// <inheritdoc/>
    public CardValidationNetworkDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationNetworkDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// The payment network used to process this card authorization.
/// </summary>
[JsonConverter(typeof(CardValidationNetworkDetailsCategoryConverter))]
public enum CardValidationNetworkDetailsCategory
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

sealed class CardValidationNetworkDetailsCategoryConverter
    : JsonConverter<CardValidationNetworkDetailsCategory>
{
    public override CardValidationNetworkDetailsCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => CardValidationNetworkDetailsCategory.Visa,
            "pulse" => CardValidationNetworkDetailsCategory.Pulse,
            _ => (CardValidationNetworkDetailsCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardValidationNetworkDetailsCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardValidationNetworkDetailsCategory.Visa => "visa",
                CardValidationNetworkDetailsCategory.Pulse => "pulse",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationNetworkDetailsPulse,
        CardValidationNetworkDetailsPulseFromRaw
    >)
)]
public sealed record class CardValidationNetworkDetailsPulse : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public CardValidationNetworkDetailsPulse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationNetworkDetailsPulse(
        CardValidationNetworkDetailsPulse cardValidationNetworkDetailsPulse
    )
        : base(cardValidationNetworkDetailsPulse) { }
#pragma warning restore CS8618

    public CardValidationNetworkDetailsPulse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationNetworkDetailsPulse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationNetworkDetailsPulseFromRaw.FromRawUnchecked"/>
    public static CardValidationNetworkDetailsPulse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationNetworkDetailsPulseFromRaw : IFromRawJson<CardValidationNetworkDetailsPulse>
{
    /// <inheritdoc/>
    public CardValidationNetworkDetailsPulse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationNetworkDetailsPulse.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields specific to the `visa` network.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationNetworkDetailsVisa,
        CardValidationNetworkDetailsVisaFromRaw
    >)
)]
public sealed record class CardValidationNetworkDetailsVisa : JsonModel
{
    /// <summary>
    /// For electronic commerce transactions, this identifies the level of security
    /// used in obtaining the customer's payment credential. For mail or telephone
    /// order transactions, identifies the type of mail or telephone order.
    /// </summary>
    public required ApiEnum<
        string,
        CardValidationNetworkDetailsVisaElectronicCommerceIndicator
    >? ElectronicCommerceIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardValidationNetworkDetailsVisaElectronicCommerceIndicator>
            >("electronic_commerce_indicator");
        }
        init { this._rawData.Set("electronic_commerce_indicator", value); }
    }

    /// <summary>
    /// The method used to enter the cardholder's primary account number and card
    /// expiration date.
    /// </summary>
    public required ApiEnum<
        string,
        CardValidationNetworkDetailsVisaPointOfServiceEntryMode
    >? PointOfServiceEntryMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardValidationNetworkDetailsVisaPointOfServiceEntryMode>
            >("point_of_service_entry_mode");
        }
        init { this._rawData.Set("point_of_service_entry_mode", value); }
    }

    /// <summary>
    /// Only present when `actioner: network`. Describes why a card authorization
    /// was approved or declined by Visa through stand-in processing.
    /// </summary>
    public required ApiEnum<
        string,
        CardValidationNetworkDetailsVisaStandInProcessingReason
    >? StandInProcessingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardValidationNetworkDetailsVisaStandInProcessingReason>
            >("stand_in_processing_reason");
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
    public required ApiEnum<
        string,
        CardValidationNetworkDetailsVisaTerminalEntryCapability
    >? TerminalEntryCapability
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CardValidationNetworkDetailsVisaTerminalEntryCapability>
            >("terminal_entry_capability");
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

    public CardValidationNetworkDetailsVisa() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationNetworkDetailsVisa(
        CardValidationNetworkDetailsVisa cardValidationNetworkDetailsVisa
    )
        : base(cardValidationNetworkDetailsVisa) { }
#pragma warning restore CS8618

    public CardValidationNetworkDetailsVisa(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationNetworkDetailsVisa(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationNetworkDetailsVisaFromRaw.FromRawUnchecked"/>
    public static CardValidationNetworkDetailsVisa FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationNetworkDetailsVisaFromRaw : IFromRawJson<CardValidationNetworkDetailsVisa>
{
    /// <inheritdoc/>
    public CardValidationNetworkDetailsVisa FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationNetworkDetailsVisa.FromRawUnchecked(rawData);
}

/// <summary>
/// For electronic commerce transactions, this identifies the level of security used
/// in obtaining the customer's payment credential. For mail or telephone order transactions,
/// identifies the type of mail or telephone order.
/// </summary>
[JsonConverter(typeof(CardValidationNetworkDetailsVisaElectronicCommerceIndicatorConverter))]
public enum CardValidationNetworkDetailsVisaElectronicCommerceIndicator
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

sealed class CardValidationNetworkDetailsVisaElectronicCommerceIndicatorConverter
    : JsonConverter<CardValidationNetworkDetailsVisaElectronicCommerceIndicator>
{
    public override CardValidationNetworkDetailsVisaElectronicCommerceIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mail_phone_order" =>
                CardValidationNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
            "recurring" => CardValidationNetworkDetailsVisaElectronicCommerceIndicator.Recurring,
            "installment" =>
                CardValidationNetworkDetailsVisaElectronicCommerceIndicator.Installment,
            "unknown_mail_phone_order" =>
                CardValidationNetworkDetailsVisaElectronicCommerceIndicator.UnknownMailPhoneOrder,
            "secure_electronic_commerce" =>
                CardValidationNetworkDetailsVisaElectronicCommerceIndicator.SecureElectronicCommerce,
            "non_authenticated_security_transaction_at_3ds_capable_merchant" =>
                CardValidationNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant,
            "non_authenticated_security_transaction" =>
                CardValidationNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction,
            "non_secure_transaction" =>
                CardValidationNetworkDetailsVisaElectronicCommerceIndicator.NonSecureTransaction,
            _ => (CardValidationNetworkDetailsVisaElectronicCommerceIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardValidationNetworkDetailsVisaElectronicCommerceIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardValidationNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder =>
                    "mail_phone_order",
                CardValidationNetworkDetailsVisaElectronicCommerceIndicator.Recurring =>
                    "recurring",
                CardValidationNetworkDetailsVisaElectronicCommerceIndicator.Installment =>
                    "installment",
                CardValidationNetworkDetailsVisaElectronicCommerceIndicator.UnknownMailPhoneOrder =>
                    "unknown_mail_phone_order",
                CardValidationNetworkDetailsVisaElectronicCommerceIndicator.SecureElectronicCommerce =>
                    "secure_electronic_commerce",
                CardValidationNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant =>
                    "non_authenticated_security_transaction_at_3ds_capable_merchant",
                CardValidationNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction =>
                    "non_authenticated_security_transaction",
                CardValidationNetworkDetailsVisaElectronicCommerceIndicator.NonSecureTransaction =>
                    "non_secure_transaction",
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
[JsonConverter(typeof(CardValidationNetworkDetailsVisaPointOfServiceEntryModeConverter))]
public enum CardValidationNetworkDetailsVisaPointOfServiceEntryMode
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

sealed class CardValidationNetworkDetailsVisaPointOfServiceEntryModeConverter
    : JsonConverter<CardValidationNetworkDetailsVisaPointOfServiceEntryMode>
{
    public override CardValidationNetworkDetailsVisaPointOfServiceEntryMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" => CardValidationNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
            "manual" => CardValidationNetworkDetailsVisaPointOfServiceEntryMode.Manual,
            "magnetic_stripe_no_cvv" =>
                CardValidationNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripeNoCvv,
            "optical_code" => CardValidationNetworkDetailsVisaPointOfServiceEntryMode.OpticalCode,
            "integrated_circuit_card" =>
                CardValidationNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCard,
            "contactless" => CardValidationNetworkDetailsVisaPointOfServiceEntryMode.Contactless,
            "credential_on_file" =>
                CardValidationNetworkDetailsVisaPointOfServiceEntryMode.CredentialOnFile,
            "magnetic_stripe" =>
                CardValidationNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripe,
            "contactless_magnetic_stripe" =>
                CardValidationNetworkDetailsVisaPointOfServiceEntryMode.ContactlessMagneticStripe,
            "integrated_circuit_card_no_cvv" =>
                CardValidationNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCardNoCvv,
            _ => (CardValidationNetworkDetailsVisaPointOfServiceEntryMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardValidationNetworkDetailsVisaPointOfServiceEntryMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardValidationNetworkDetailsVisaPointOfServiceEntryMode.Unknown => "unknown",
                CardValidationNetworkDetailsVisaPointOfServiceEntryMode.Manual => "manual",
                CardValidationNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripeNoCvv =>
                    "magnetic_stripe_no_cvv",
                CardValidationNetworkDetailsVisaPointOfServiceEntryMode.OpticalCode =>
                    "optical_code",
                CardValidationNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCard =>
                    "integrated_circuit_card",
                CardValidationNetworkDetailsVisaPointOfServiceEntryMode.Contactless =>
                    "contactless",
                CardValidationNetworkDetailsVisaPointOfServiceEntryMode.CredentialOnFile =>
                    "credential_on_file",
                CardValidationNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripe =>
                    "magnetic_stripe",
                CardValidationNetworkDetailsVisaPointOfServiceEntryMode.ContactlessMagneticStripe =>
                    "contactless_magnetic_stripe",
                CardValidationNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCardNoCvv =>
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
[JsonConverter(typeof(CardValidationNetworkDetailsVisaStandInProcessingReasonConverter))]
public enum CardValidationNetworkDetailsVisaStandInProcessingReason
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

sealed class CardValidationNetworkDetailsVisaStandInProcessingReasonConverter
    : JsonConverter<CardValidationNetworkDetailsVisaStandInProcessingReason>
{
    public override CardValidationNetworkDetailsVisaStandInProcessingReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "issuer_error" => CardValidationNetworkDetailsVisaStandInProcessingReason.IssuerError,
            "invalid_physical_card" =>
                CardValidationNetworkDetailsVisaStandInProcessingReason.InvalidPhysicalCard,
            "invalid_cryptogram" =>
                CardValidationNetworkDetailsVisaStandInProcessingReason.InvalidCryptogram,
            "invalid_cardholder_authentication_verification_value" =>
                CardValidationNetworkDetailsVisaStandInProcessingReason.InvalidCardholderAuthenticationVerificationValue,
            "internal_visa_error" =>
                CardValidationNetworkDetailsVisaStandInProcessingReason.InternalVisaError,
            "merchant_transaction_advisory_service_authentication_required" =>
                CardValidationNetworkDetailsVisaStandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired,
            "payment_fraud_disruption_acquirer_block" =>
                CardValidationNetworkDetailsVisaStandInProcessingReason.PaymentFraudDisruptionAcquirerBlock,
            "other" => CardValidationNetworkDetailsVisaStandInProcessingReason.Other,
            _ => (CardValidationNetworkDetailsVisaStandInProcessingReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardValidationNetworkDetailsVisaStandInProcessingReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardValidationNetworkDetailsVisaStandInProcessingReason.IssuerError =>
                    "issuer_error",
                CardValidationNetworkDetailsVisaStandInProcessingReason.InvalidPhysicalCard =>
                    "invalid_physical_card",
                CardValidationNetworkDetailsVisaStandInProcessingReason.InvalidCryptogram =>
                    "invalid_cryptogram",
                CardValidationNetworkDetailsVisaStandInProcessingReason.InvalidCardholderAuthenticationVerificationValue =>
                    "invalid_cardholder_authentication_verification_value",
                CardValidationNetworkDetailsVisaStandInProcessingReason.InternalVisaError =>
                    "internal_visa_error",
                CardValidationNetworkDetailsVisaStandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired =>
                    "merchant_transaction_advisory_service_authentication_required",
                CardValidationNetworkDetailsVisaStandInProcessingReason.PaymentFraudDisruptionAcquirerBlock =>
                    "payment_fraud_disruption_acquirer_block",
                CardValidationNetworkDetailsVisaStandInProcessingReason.Other => "other",
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
[JsonConverter(typeof(CardValidationNetworkDetailsVisaTerminalEntryCapabilityConverter))]
public enum CardValidationNetworkDetailsVisaTerminalEntryCapability
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

sealed class CardValidationNetworkDetailsVisaTerminalEntryCapabilityConverter
    : JsonConverter<CardValidationNetworkDetailsVisaTerminalEntryCapability>
{
    public override CardValidationNetworkDetailsVisaTerminalEntryCapability Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" => CardValidationNetworkDetailsVisaTerminalEntryCapability.Unknown,
            "terminal_not_used" =>
                CardValidationNetworkDetailsVisaTerminalEntryCapability.TerminalNotUsed,
            "magnetic_stripe" =>
                CardValidationNetworkDetailsVisaTerminalEntryCapability.MagneticStripe,
            "barcode" => CardValidationNetworkDetailsVisaTerminalEntryCapability.Barcode,
            "optical_character_recognition" =>
                CardValidationNetworkDetailsVisaTerminalEntryCapability.OpticalCharacterRecognition,
            "chip_or_contactless" =>
                CardValidationNetworkDetailsVisaTerminalEntryCapability.ChipOrContactless,
            "contactless_only" =>
                CardValidationNetworkDetailsVisaTerminalEntryCapability.ContactlessOnly,
            "no_capability" => CardValidationNetworkDetailsVisaTerminalEntryCapability.NoCapability,
            _ => (CardValidationNetworkDetailsVisaTerminalEntryCapability)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardValidationNetworkDetailsVisaTerminalEntryCapability value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardValidationNetworkDetailsVisaTerminalEntryCapability.Unknown => "unknown",
                CardValidationNetworkDetailsVisaTerminalEntryCapability.TerminalNotUsed =>
                    "terminal_not_used",
                CardValidationNetworkDetailsVisaTerminalEntryCapability.MagneticStripe =>
                    "magnetic_stripe",
                CardValidationNetworkDetailsVisaTerminalEntryCapability.Barcode => "barcode",
                CardValidationNetworkDetailsVisaTerminalEntryCapability.OpticalCharacterRecognition =>
                    "optical_character_recognition",
                CardValidationNetworkDetailsVisaTerminalEntryCapability.ChipOrContactless =>
                    "chip_or_contactless",
                CardValidationNetworkDetailsVisaTerminalEntryCapability.ContactlessOnly =>
                    "contactless_only",
                CardValidationNetworkDetailsVisaTerminalEntryCapability.NoCapability =>
                    "no_capability",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationNetworkIdentifiers,
        CardValidationNetworkIdentifiersFromRaw
    >)
)]
public sealed record class CardValidationNetworkIdentifiers : JsonModel
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

    public CardValidationNetworkIdentifiers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationNetworkIdentifiers(
        CardValidationNetworkIdentifiers cardValidationNetworkIdentifiers
    )
        : base(cardValidationNetworkIdentifiers) { }
#pragma warning restore CS8618

    public CardValidationNetworkIdentifiers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationNetworkIdentifiers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationNetworkIdentifiersFromRaw.FromRawUnchecked"/>
    public static CardValidationNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationNetworkIdentifiersFromRaw : IFromRawJson<CardValidationNetworkIdentifiers>
{
    /// <inheritdoc/>
    public CardValidationNetworkIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationNetworkIdentifiers.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `inbound_card_validation`.
/// </summary>
[JsonConverter(typeof(CardValidationTypeConverter))]
public enum CardValidationType
{
    InboundCardValidation,
}

sealed class CardValidationTypeConverter : JsonConverter<CardValidationType>
{
    public override CardValidationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_card_validation" => CardValidationType.InboundCardValidation,
            _ => (CardValidationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardValidationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardValidationType.InboundCardValidation => "inbound_card_validation",
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
[JsonConverter(
    typeof(JsonModelConverter<CardValidationVerification, CardValidationVerificationFromRaw>)
)]
public sealed record class CardValidationVerification : JsonModel
{
    /// <summary>
    /// Fields related to verification of the Card Verification Code, a 3-digit code
    /// on the back of the card.
    /// </summary>
    public required CardValidationVerificationCardVerificationCode CardVerificationCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardValidationVerificationCardVerificationCode>(
                "card_verification_code"
            );
        }
        init { this._rawData.Set("card_verification_code", value); }
    }

    /// <summary>
    /// Cardholder address provided in the authorization request and the address
    /// on file we verified it against.
    /// </summary>
    public required CardValidationVerificationCardholderAddress CardholderAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardValidationVerificationCardholderAddress>(
                "cardholder_address"
            );
        }
        init { this._rawData.Set("cardholder_address", value); }
    }

    /// <summary>
    /// Cardholder name provided in the authorization request.
    /// </summary>
    public required CardValidationVerificationCardholderName? CardholderName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardValidationVerificationCardholderName>(
                "cardholder_name"
            );
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

    public CardValidationVerification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationVerification(CardValidationVerification cardValidationVerification)
        : base(cardValidationVerification) { }
#pragma warning restore CS8618

    public CardValidationVerification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationVerification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationVerificationFromRaw.FromRawUnchecked"/>
    public static CardValidationVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationVerificationFromRaw : IFromRawJson<CardValidationVerification>
{
    /// <inheritdoc/>
    public CardValidationVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationVerification.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields related to verification of the Card Verification Code, a 3-digit code
/// on the back of the card.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationVerificationCardVerificationCode,
        CardValidationVerificationCardVerificationCodeFromRaw
    >)
)]
public sealed record class CardValidationVerificationCardVerificationCode : JsonModel
{
    /// <summary>
    /// The result of verifying the Card Verification Code.
    /// </summary>
    public required ApiEnum<string, CardValidationVerificationCardVerificationCodeResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardValidationVerificationCardVerificationCodeResult>
            >("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Result.Validate();
    }

    public CardValidationVerificationCardVerificationCode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationVerificationCardVerificationCode(
        CardValidationVerificationCardVerificationCode cardValidationVerificationCardVerificationCode
    )
        : base(cardValidationVerificationCardVerificationCode) { }
#pragma warning restore CS8618

    public CardValidationVerificationCardVerificationCode(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationVerificationCardVerificationCode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationVerificationCardVerificationCodeFromRaw.FromRawUnchecked"/>
    public static CardValidationVerificationCardVerificationCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardValidationVerificationCardVerificationCode(
        ApiEnum<string, CardValidationVerificationCardVerificationCodeResult> result
    )
        : this()
    {
        this.Result = result;
    }
}

class CardValidationVerificationCardVerificationCodeFromRaw
    : IFromRawJson<CardValidationVerificationCardVerificationCode>
{
    /// <inheritdoc/>
    public CardValidationVerificationCardVerificationCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationVerificationCardVerificationCode.FromRawUnchecked(rawData);
}

/// <summary>
/// The result of verifying the Card Verification Code.
/// </summary>
[JsonConverter(typeof(CardValidationVerificationCardVerificationCodeResultConverter))]
public enum CardValidationVerificationCardVerificationCodeResult
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

sealed class CardValidationVerificationCardVerificationCodeResultConverter
    : JsonConverter<CardValidationVerificationCardVerificationCodeResult>
{
    public override CardValidationVerificationCardVerificationCodeResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_checked" => CardValidationVerificationCardVerificationCodeResult.NotChecked,
            "match" => CardValidationVerificationCardVerificationCodeResult.Match,
            "no_match" => CardValidationVerificationCardVerificationCodeResult.NoMatch,
            _ => (CardValidationVerificationCardVerificationCodeResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardValidationVerificationCardVerificationCodeResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardValidationVerificationCardVerificationCodeResult.NotChecked => "not_checked",
                CardValidationVerificationCardVerificationCodeResult.Match => "match",
                CardValidationVerificationCardVerificationCodeResult.NoMatch => "no_match",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationVerificationCardholderAddress,
        CardValidationVerificationCardholderAddressFromRaw
    >)
)]
public sealed record class CardValidationVerificationCardholderAddress : JsonModel
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
    public required ApiEnum<string, CardValidationVerificationCardholderAddressResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardValidationVerificationCardholderAddressResult>
            >("result");
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

    public CardValidationVerificationCardholderAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationVerificationCardholderAddress(
        CardValidationVerificationCardholderAddress cardValidationVerificationCardholderAddress
    )
        : base(cardValidationVerificationCardholderAddress) { }
#pragma warning restore CS8618

    public CardValidationVerificationCardholderAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationVerificationCardholderAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationVerificationCardholderAddressFromRaw.FromRawUnchecked"/>
    public static CardValidationVerificationCardholderAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationVerificationCardholderAddressFromRaw
    : IFromRawJson<CardValidationVerificationCardholderAddress>
{
    /// <inheritdoc/>
    public CardValidationVerificationCardholderAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationVerificationCardholderAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The address verification result returned to the card network.
/// </summary>
[JsonConverter(typeof(CardValidationVerificationCardholderAddressResultConverter))]
public enum CardValidationVerificationCardholderAddressResult
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

sealed class CardValidationVerificationCardholderAddressResultConverter
    : JsonConverter<CardValidationVerificationCardholderAddressResult>
{
    public override CardValidationVerificationCardholderAddressResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_checked" => CardValidationVerificationCardholderAddressResult.NotChecked,
            "postal_code_match_address_no_match" =>
                CardValidationVerificationCardholderAddressResult.PostalCodeMatchAddressNoMatch,
            "postal_code_no_match_address_match" =>
                CardValidationVerificationCardholderAddressResult.PostalCodeNoMatchAddressMatch,
            "match" => CardValidationVerificationCardholderAddressResult.Match,
            "no_match" => CardValidationVerificationCardholderAddressResult.NoMatch,
            "postal_code_match_address_not_checked" =>
                CardValidationVerificationCardholderAddressResult.PostalCodeMatchAddressNotChecked,
            _ => (CardValidationVerificationCardholderAddressResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardValidationVerificationCardholderAddressResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardValidationVerificationCardholderAddressResult.NotChecked => "not_checked",
                CardValidationVerificationCardholderAddressResult.PostalCodeMatchAddressNoMatch =>
                    "postal_code_match_address_no_match",
                CardValidationVerificationCardholderAddressResult.PostalCodeNoMatchAddressMatch =>
                    "postal_code_no_match_address_match",
                CardValidationVerificationCardholderAddressResult.Match => "match",
                CardValidationVerificationCardholderAddressResult.NoMatch => "no_match",
                CardValidationVerificationCardholderAddressResult.PostalCodeMatchAddressNotChecked =>
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
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationVerificationCardholderName,
        CardValidationVerificationCardholderNameFromRaw
    >)
)]
public sealed record class CardValidationVerificationCardholderName : JsonModel
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

    public CardValidationVerificationCardholderName() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationVerificationCardholderName(
        CardValidationVerificationCardholderName cardValidationVerificationCardholderName
    )
        : base(cardValidationVerificationCardholderName) { }
#pragma warning restore CS8618

    public CardValidationVerificationCardholderName(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationVerificationCardholderName(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationVerificationCardholderNameFromRaw.FromRawUnchecked"/>
    public static CardValidationVerificationCardholderName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationVerificationCardholderNameFromRaw
    : IFromRawJson<CardValidationVerificationCardholderName>
{
    /// <inheritdoc/>
    public CardValidationVerificationCardholderName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationVerificationCardholderName.FromRawUnchecked(rawData);
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
/// The summarized state of this card payment.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<State, StateFromRaw>))]
public sealed record class State : JsonModel
{
    /// <summary>
    /// The total authorized amount in the minor unit of the transaction's currency.
    /// For dollars, for example, this is cents.
    /// </summary>
    public required long AuthorizedAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("authorized_amount");
        }
        init { this._rawData.Set("authorized_amount", value); }
    }

    /// <summary>
    /// The total amount from fuel confirmations in the minor unit of the transaction's
    /// currency. For dollars, for example, this is cents.
    /// </summary>
    public required long FuelConfirmedAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("fuel_confirmed_amount");
        }
        init { this._rawData.Set("fuel_confirmed_amount", value); }
    }

    /// <summary>
    /// The total incrementally updated authorized amount in the minor unit of the
    /// transaction's currency. For dollars, for example, this is cents.
    /// </summary>
    public required long IncrementedAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("incremented_amount");
        }
        init { this._rawData.Set("incremented_amount", value); }
    }

    /// <summary>
    /// The total refund authorized amount in the minor unit of the transaction's
    /// currency. For dollars, for example, this is cents.
    /// </summary>
    public required long RefundAuthorizedAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("refund_authorized_amount");
        }
        init { this._rawData.Set("refund_authorized_amount", value); }
    }

    /// <summary>
    /// The total refunded amount in the minor unit of the transaction's currency.
    /// For dollars, for example, this is cents.
    /// </summary>
    public required long RefundedAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("refunded_amount");
        }
        init { this._rawData.Set("refunded_amount", value); }
    }

    /// <summary>
    /// The total reversed amount in the minor unit of the transaction's currency.
    /// For dollars, for example, this is cents.
    /// </summary>
    public required long ReversedAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("reversed_amount");
        }
        init { this._rawData.Set("reversed_amount", value); }
    }

    /// <summary>
    /// The total settled amount in the minor unit of the transaction's currency.
    /// For dollars, for example, this is cents.
    /// </summary>
    public required long SettledAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("settled_amount");
        }
        init { this._rawData.Set("settled_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AuthorizedAmount;
        _ = this.FuelConfirmedAmount;
        _ = this.IncrementedAmount;
        _ = this.RefundAuthorizedAmount;
        _ = this.RefundedAmount;
        _ = this.ReversedAmount;
        _ = this.SettledAmount;
    }

    public State() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public State(State state)
        : base(state) { }
#pragma warning restore CS8618

    public State(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    State(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StateFromRaw.FromRawUnchecked"/>
    public static State FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StateFromRaw : IFromRawJson<State>
{
    /// <inheritdoc/>
    public State FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        State.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_payment`.
/// </summary>
[JsonConverter(typeof(CardPaymentTypeConverter))]
public enum CardPaymentType
{
    CardPayment,
}

sealed class CardPaymentTypeConverter : JsonConverter<CardPaymentType>
{
    public override CardPaymentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_payment" => CardPaymentType.CardPayment,
            _ => (CardPaymentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardPaymentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardPaymentType.CardPayment => "card_payment",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
