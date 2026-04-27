using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.CardValidations;

/// <summary>
/// Card Validations are used to validate a card and its cardholder before sending
/// funds to or pulling funds from a card.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardValidation, CardValidationFromRaw>))]
public sealed record class CardValidation : JsonModel
{
    /// <summary>
    /// The Card Validation's identifier.
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
    /// If the validation is accepted by the recipient bank, this will contain supplemental details.
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
    /// The identifier of the Account from which to send the validation.
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
    /// The cardholder's first name.
    /// </summary>
    public required string? CardholderFirstName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cardholder_first_name");
        }
        init { this._rawData.Set("cardholder_first_name", value); }
    }

    /// <summary>
    /// The cardholder's last name.
    /// </summary>
    public required string? CardholderLastName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cardholder_last_name");
        }
        init { this._rawData.Set("cardholder_last_name", value); }
    }

    /// <summary>
    /// The cardholder's middle name.
    /// </summary>
    public required string? CardholderMiddleName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cardholder_middle_name");
        }
        init { this._rawData.Set("cardholder_middle_name", value); }
    }

    /// <summary>
    /// The postal code of the cardholder's address.
    /// </summary>
    public required string? CardholderPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cardholder_postal_code");
        }
        init { this._rawData.Set("cardholder_postal_code", value); }
    }

    /// <summary>
    /// The cardholder's street address.
    /// </summary>
    public required string? CardholderStreetAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cardholder_street_address");
        }
        init { this._rawData.Set("cardholder_street_address", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the validation was created.
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
    /// What object created the validation, either via the API or the dashboard.
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
    /// If the validation is rejected by the card network or the destination financial
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
    /// A four-digit code (MCC) identifying the type of business or service provided
    /// by the merchant.
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
    /// The city where the merchant (typically your business) is located.
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
    /// The merchant name that will appear in the cardholder’s statement descriptor.
    /// Typically your business name.
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
    /// The postal code for the merchant’s (typically your business’s) location.
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
    /// The U.S. state where the merchant (typically your business) is located.
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
    /// The card network route used for the validation.
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
    /// The lifecycle status of the validation.
    /// </summary>
    public required ApiEnum<string, CardValidationStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardValidationStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// After the validation is submitted to the card network, this will contain
    /// supplemental details.
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
    /// be `card_validation`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.CardValidations.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.CardValidations.Type>
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
        _ = this.CardTokenID;
        _ = this.CardholderFirstName;
        _ = this.CardholderLastName;
        _ = this.CardholderMiddleName;
        _ = this.CardholderPostalCode;
        _ = this.CardholderStreetAddress;
        _ = this.CreatedAt;
        this.CreatedBy?.Validate();
        this.Decline?.Validate();
        _ = this.IdempotencyKey;
        _ = this.MerchantCategoryCode;
        _ = this.MerchantCityName;
        _ = this.MerchantName;
        _ = this.MerchantPostalCode;
        _ = this.MerchantState;
        this.Route.Validate();
        this.Status.Validate();
        this.Submission?.Validate();
        this.Type.Validate();
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
/// If the validation is accepted by the recipient bank, this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Acceptance, AcceptanceFromRaw>))]
public sealed record class Acceptance : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the validation was accepted by the issuing bank.
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
    /// The result of the cardholder first name match.
    /// </summary>
    public required ApiEnum<string, CardholderFirstNameResult>? CardholderFirstNameResult
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CardholderFirstNameResult>>(
                "cardholder_first_name_result"
            );
        }
        init { this._rawData.Set("cardholder_first_name_result", value); }
    }

    /// <summary>
    /// The result of the cardholder full name match.
    /// </summary>
    public required ApiEnum<string, CardholderFullNameResult>? CardholderFullNameResult
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CardholderFullNameResult>>(
                "cardholder_full_name_result"
            );
        }
        init { this._rawData.Set("cardholder_full_name_result", value); }
    }

    /// <summary>
    /// The result of the cardholder last name match.
    /// </summary>
    public required ApiEnum<string, CardholderLastNameResult>? CardholderLastNameResult
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CardholderLastNameResult>>(
                "cardholder_last_name_result"
            );
        }
        init { this._rawData.Set("cardholder_last_name_result", value); }
    }

    /// <summary>
    /// The result of the cardholder middle name match.
    /// </summary>
    public required ApiEnum<string, CardholderMiddleNameResult>? CardholderMiddleNameResult
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CardholderMiddleNameResult>>(
                "cardholder_middle_name_result"
            );
        }
        init { this._rawData.Set("cardholder_middle_name_result", value); }
    }

    /// <summary>
    /// The result of the cardholder postal code match.
    /// </summary>
    public required ApiEnum<string, CardholderPostalCodeResult>? CardholderPostalCodeResult
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CardholderPostalCodeResult>>(
                "cardholder_postal_code_result"
            );
        }
        init { this._rawData.Set("cardholder_postal_code_result", value); }
    }

    /// <summary>
    /// The result of the cardholder street address match.
    /// </summary>
    public required ApiEnum<string, CardholderStreetAddressResult>? CardholderStreetAddressResult
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CardholderStreetAddressResult>>(
                "cardholder_street_address_result"
            );
        }
        init { this._rawData.Set("cardholder_street_address_result", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcceptedAt;
        _ = this.AuthorizationIdentificationResponse;
        this.CardVerificationValue2Result?.Validate();
        this.CardholderFirstNameResult?.Validate();
        this.CardholderFullNameResult?.Validate();
        this.CardholderLastNameResult?.Validate();
        this.CardholderMiddleNameResult?.Validate();
        this.CardholderPostalCodeResult?.Validate();
        this.CardholderStreetAddressResult?.Validate();
        _ = this.NetworkTransactionIdentifier;
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
/// The result of the cardholder first name match.
/// </summary>
[JsonConverter(typeof(CardholderFirstNameResultConverter))]
public enum CardholderFirstNameResult
{
    /// <summary>
    /// The cardholder name component matches the expected value.
    /// </summary>
    Match,

    /// <summary>
    /// The cardholder name component does not match the expected value.
    /// </summary>
    NoMatch,

    /// <summary>
    /// The cardholder name component partially matches the expected value.
    /// </summary>
    PartialMatch,
}

sealed class CardholderFirstNameResultConverter : JsonConverter<CardholderFirstNameResult>
{
    public override CardholderFirstNameResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "match" => CardholderFirstNameResult.Match,
            "no_match" => CardholderFirstNameResult.NoMatch,
            "partial_match" => CardholderFirstNameResult.PartialMatch,
            _ => (CardholderFirstNameResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardholderFirstNameResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardholderFirstNameResult.Match => "match",
                CardholderFirstNameResult.NoMatch => "no_match",
                CardholderFirstNameResult.PartialMatch => "partial_match",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The result of the cardholder full name match.
/// </summary>
[JsonConverter(typeof(CardholderFullNameResultConverter))]
public enum CardholderFullNameResult
{
    /// <summary>
    /// The cardholder name component matches the expected value.
    /// </summary>
    Match,

    /// <summary>
    /// The cardholder name component does not match the expected value.
    /// </summary>
    NoMatch,

    /// <summary>
    /// The cardholder name component partially matches the expected value.
    /// </summary>
    PartialMatch,
}

sealed class CardholderFullNameResultConverter : JsonConverter<CardholderFullNameResult>
{
    public override CardholderFullNameResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "match" => CardholderFullNameResult.Match,
            "no_match" => CardholderFullNameResult.NoMatch,
            "partial_match" => CardholderFullNameResult.PartialMatch,
            _ => (CardholderFullNameResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardholderFullNameResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardholderFullNameResult.Match => "match",
                CardholderFullNameResult.NoMatch => "no_match",
                CardholderFullNameResult.PartialMatch => "partial_match",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The result of the cardholder last name match.
/// </summary>
[JsonConverter(typeof(CardholderLastNameResultConverter))]
public enum CardholderLastNameResult
{
    /// <summary>
    /// The cardholder name component matches the expected value.
    /// </summary>
    Match,

    /// <summary>
    /// The cardholder name component does not match the expected value.
    /// </summary>
    NoMatch,

    /// <summary>
    /// The cardholder name component partially matches the expected value.
    /// </summary>
    PartialMatch,
}

sealed class CardholderLastNameResultConverter : JsonConverter<CardholderLastNameResult>
{
    public override CardholderLastNameResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "match" => CardholderLastNameResult.Match,
            "no_match" => CardholderLastNameResult.NoMatch,
            "partial_match" => CardholderLastNameResult.PartialMatch,
            _ => (CardholderLastNameResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardholderLastNameResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardholderLastNameResult.Match => "match",
                CardholderLastNameResult.NoMatch => "no_match",
                CardholderLastNameResult.PartialMatch => "partial_match",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The result of the cardholder middle name match.
/// </summary>
[JsonConverter(typeof(CardholderMiddleNameResultConverter))]
public enum CardholderMiddleNameResult
{
    /// <summary>
    /// The cardholder name component matches the expected value.
    /// </summary>
    Match,

    /// <summary>
    /// The cardholder name component does not match the expected value.
    /// </summary>
    NoMatch,

    /// <summary>
    /// The cardholder name component partially matches the expected value.
    /// </summary>
    PartialMatch,
}

sealed class CardholderMiddleNameResultConverter : JsonConverter<CardholderMiddleNameResult>
{
    public override CardholderMiddleNameResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "match" => CardholderMiddleNameResult.Match,
            "no_match" => CardholderMiddleNameResult.NoMatch,
            "partial_match" => CardholderMiddleNameResult.PartialMatch,
            _ => (CardholderMiddleNameResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardholderMiddleNameResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardholderMiddleNameResult.Match => "match",
                CardholderMiddleNameResult.NoMatch => "no_match",
                CardholderMiddleNameResult.PartialMatch => "partial_match",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The result of the cardholder postal code match.
/// </summary>
[JsonConverter(typeof(CardholderPostalCodeResultConverter))]
public enum CardholderPostalCodeResult
{
    /// <summary>
    /// The cardholder address component matches the expected value.
    /// </summary>
    Match,

    /// <summary>
    /// The cardholder address component does not match the expected value.
    /// </summary>
    NoMatch,
}

sealed class CardholderPostalCodeResultConverter : JsonConverter<CardholderPostalCodeResult>
{
    public override CardholderPostalCodeResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "match" => CardholderPostalCodeResult.Match,
            "no_match" => CardholderPostalCodeResult.NoMatch,
            _ => (CardholderPostalCodeResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardholderPostalCodeResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardholderPostalCodeResult.Match => "match",
                CardholderPostalCodeResult.NoMatch => "no_match",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The result of the cardholder street address match.
/// </summary>
[JsonConverter(typeof(CardholderStreetAddressResultConverter))]
public enum CardholderStreetAddressResult
{
    /// <summary>
    /// The cardholder address component matches the expected value.
    /// </summary>
    Match,

    /// <summary>
    /// The cardholder address component does not match the expected value.
    /// </summary>
    NoMatch,
}

sealed class CardholderStreetAddressResultConverter : JsonConverter<CardholderStreetAddressResult>
{
    public override CardholderStreetAddressResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "match" => CardholderStreetAddressResult.Match,
            "no_match" => CardholderStreetAddressResult.NoMatch,
            _ => (CardholderStreetAddressResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardholderStreetAddressResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardholderStreetAddressResult.Match => "match",
                CardholderStreetAddressResult.NoMatch => "no_match",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// What object created the validation, either via the API or the dashboard.
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
/// If the validation is rejected by the card network or the destination financial
/// institution, this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Decline, DeclineFromRaw>))]
public sealed record class Decline : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the validation was declined.
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
    /// The reason why the validation was declined.
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
/// The reason why the validation was declined.
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
/// The card network route used for the validation.
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
/// The lifecycle status of the validation.
/// </summary>
[JsonConverter(typeof(CardValidationStatusConverter))]
public enum CardValidationStatus
{
    /// <summary>
    /// The validation requires attention from an Increase operator.
    /// </summary>
    RequiresAttention,

    /// <summary>
    /// The validation is queued to be submitted to the card network.
    /// </summary>
    PendingSubmission,

    /// <summary>
    /// The validation has been submitted and is pending a response from the card network.
    /// </summary>
    Submitted,

    /// <summary>
    /// The validation has been sent successfully and is complete.
    /// </summary>
    Complete,

    /// <summary>
    /// The validation was declined by the network or the recipient's bank.
    /// </summary>
    Declined,
}

sealed class CardValidationStatusConverter : JsonConverter<CardValidationStatus>
{
    public override CardValidationStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "requires_attention" => CardValidationStatus.RequiresAttention,
            "pending_submission" => CardValidationStatus.PendingSubmission,
            "submitted" => CardValidationStatus.Submitted,
            "complete" => CardValidationStatus.Complete,
            "declined" => CardValidationStatus.Declined,
            _ => (CardValidationStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardValidationStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardValidationStatus.RequiresAttention => "requires_attention",
                CardValidationStatus.PendingSubmission => "pending_submission",
                CardValidationStatus.Submitted => "submitted",
                CardValidationStatus.Complete => "complete",
                CardValidationStatus.Declined => "declined",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// After the validation is submitted to the card network, this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Submission, SubmissionFromRaw>))]
public sealed record class Submission : JsonModel
{
    /// <summary>
    /// A 12-digit retrieval reference number that identifies the validation. Usually
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the validation was submitted to the card network.
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
    /// A 6-digit trace number that identifies the validation within a short time window.
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
/// A constant representing the object's type. For this resource it will always be `card_validation`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    CardValidation,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.CardValidations.Type>
{
    public override global::Increase.Api.Models.CardValidations.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_validation" => global::Increase.Api.Models.CardValidations.Type.CardValidation,
            _ => (global::Increase.Api.Models.CardValidations.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.CardValidations.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.CardValidations.Type.CardValidation =>
                    "card_validation",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
