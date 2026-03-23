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

namespace Increase.Api.Models.RealTimeDecisions;

/// <summary>
/// Action a Real-Time Decision
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RealTimeDecisionActionParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? RealTimeDecisionID { get; init; }

    /// <summary>
    /// If the Real-Time Decision relates to a 3DS card authentication attempt, this
    /// object contains your response to the authentication.
    /// </summary>
    public CardAuthentication? CardAuthentication
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CardAuthentication>("card_authentication");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("card_authentication", value);
        }
    }

    /// <summary>
    /// If the Real-Time Decision relates to 3DS card authentication challenge delivery,
    /// this object contains your response.
    /// </summary>
    public CardAuthenticationChallenge? CardAuthenticationChallenge
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CardAuthenticationChallenge>(
                "card_authentication_challenge"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("card_authentication_challenge", value);
        }
    }

    /// <summary>
    /// If the Real-Time Decision relates to a card authorization attempt, this object
    /// contains your response to the authorization.
    /// </summary>
    public CardAuthorization? CardAuthorization
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CardAuthorization>("card_authorization");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("card_authorization", value);
        }
    }

    /// <summary>
    /// If the Real-Time Decision relates to a card balance inquiry attempt, this
    /// object contains your response to the inquiry.
    /// </summary>
    public CardBalanceInquiry? CardBalanceInquiry
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CardBalanceInquiry>("card_balance_inquiry");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("card_balance_inquiry", value);
        }
    }

    /// <summary>
    /// If the Real-Time Decision relates to a digital wallet authentication attempt,
    /// this object contains your response to the authentication.
    /// </summary>
    public DigitalWalletAuthentication? DigitalWalletAuthentication
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<DigitalWalletAuthentication>(
                "digital_wallet_authentication"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("digital_wallet_authentication", value);
        }
    }

    /// <summary>
    /// If the Real-Time Decision relates to a digital wallet token provisioning attempt,
    /// this object contains your response to the attempt.
    /// </summary>
    public DigitalWalletToken? DigitalWalletToken
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<DigitalWalletToken>("digital_wallet_token");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("digital_wallet_token", value);
        }
    }

    public RealTimeDecisionActionParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimeDecisionActionParams(RealTimeDecisionActionParams realTimeDecisionActionParams)
        : base(realTimeDecisionActionParams)
    {
        this.RealTimeDecisionID = realTimeDecisionActionParams.RealTimeDecisionID;

        this._rawBodyData = new(realTimeDecisionActionParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RealTimeDecisionActionParams(
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
    RealTimeDecisionActionParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string realTimeDecisionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.RealTimeDecisionID = realTimeDecisionID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RealTimeDecisionActionParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string realTimeDecisionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            realTimeDecisionID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["RealTimeDecisionID"] = JsonSerializer.SerializeToElement(
                        this.RealTimeDecisionID
                    ),
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

    public virtual bool Equals(RealTimeDecisionActionParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.RealTimeDecisionID?.Equals(other.RealTimeDecisionID)
                ?? other.RealTimeDecisionID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/real_time_decisions/{0}/action", this.RealTimeDecisionID)
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
/// If the Real-Time Decision relates to a 3DS card authentication attempt, this
/// object contains your response to the authentication.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardAuthentication, CardAuthenticationFromRaw>))]
public sealed record class CardAuthentication : JsonModel
{
    /// <summary>
    /// Whether the card authentication attempt should be approved or declined.
    /// </summary>
    public required ApiEnum<string, Decision> Decision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Decision>>("decision");
        }
        init { this._rawData.Set("decision", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Decision.Validate();
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

    [SetsRequiredMembers]
    public CardAuthentication(ApiEnum<string, Decision> decision)
        : this()
    {
        this.Decision = decision;
    }
}

class CardAuthenticationFromRaw : IFromRawJson<CardAuthentication>
{
    /// <inheritdoc/>
    public CardAuthentication FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardAuthentication.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the card authentication attempt should be approved or declined.
/// </summary>
[JsonConverter(typeof(DecisionConverter))]
public enum Decision
{
    /// <summary>
    /// Approve the authentication attempt without triggering a challenge.
    /// </summary>
    Approve,

    /// <summary>
    /// Request further validation before approving the authentication attempt.
    /// </summary>
    Challenge,

    /// <summary>
    /// Deny the authentication attempt.
    /// </summary>
    Deny,
}

sealed class DecisionConverter : JsonConverter<Decision>
{
    public override Decision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approve" => Decision.Approve,
            "challenge" => Decision.Challenge,
            "deny" => Decision.Deny,
            _ => (Decision)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Decision value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Decision.Approve => "approve",
                Decision.Challenge => "challenge",
                Decision.Deny => "deny",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If the Real-Time Decision relates to 3DS card authentication challenge delivery,
/// this object contains your response.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CardAuthenticationChallenge, CardAuthenticationChallengeFromRaw>)
)]
public sealed record class CardAuthenticationChallenge : JsonModel
{
    /// <summary>
    /// Whether the card authentication challenge was successfully delivered to the cardholder.
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

    /// <summary>
    /// If your application was able to deliver the one-time code, this contains
    /// metadata about the delivery.
    /// </summary>
    public Success? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Success>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Result.Validate();
        this.Success?.Validate();
    }

    public CardAuthenticationChallenge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthenticationChallenge(CardAuthenticationChallenge cardAuthenticationChallenge)
        : base(cardAuthenticationChallenge) { }
#pragma warning restore CS8618

    public CardAuthenticationChallenge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthenticationChallenge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthenticationChallengeFromRaw.FromRawUnchecked"/>
    public static CardAuthenticationChallenge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardAuthenticationChallenge(ApiEnum<string, Result> result)
        : this()
    {
        this.Result = result;
    }
}

class CardAuthenticationChallengeFromRaw : IFromRawJson<CardAuthenticationChallenge>
{
    /// <inheritdoc/>
    public CardAuthenticationChallenge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardAuthenticationChallenge.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the card authentication challenge was successfully delivered to the cardholder.
/// </summary>
[JsonConverter(typeof(ResultConverter))]
public enum Result
{
    /// <summary>
    /// Your application successfully delivered the one-time code to the cardholder.
    /// </summary>
    Success,

    /// <summary>
    /// Your application was unable to deliver the one-time code to the cardholder.
    /// </summary>
    Failure,
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
            "success" => Result.Success,
            "failure" => Result.Failure,
            _ => (Result)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Result value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Result.Success => "success",
                Result.Failure => "failure",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If your application was able to deliver the one-time code, this contains metadata
/// about the delivery.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Success, SuccessFromRaw>))]
public sealed record class Success : JsonModel
{
    /// <summary>
    /// The email address that was used to deliver the one-time code to the cardholder.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// The phone number that was used to deliver the one-time code to the cardholder
    /// via SMS.
    /// </summary>
    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.Phone;
    }

    public Success() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Success(Success success)
        : base(success) { }
#pragma warning restore CS8618

    public Success(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Success(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SuccessFromRaw.FromRawUnchecked"/>
    public static Success FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SuccessFromRaw : IFromRawJson<Success>
{
    /// <inheritdoc/>
    public Success FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Success.FromRawUnchecked(rawData);
}

/// <summary>
/// If the Real-Time Decision relates to a card authorization attempt, this object
/// contains your response to the authorization.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardAuthorization, CardAuthorizationFromRaw>))]
public sealed record class CardAuthorization : JsonModel
{
    /// <summary>
    /// Whether the card authorization should be approved or declined.
    /// </summary>
    public required ApiEnum<string, CardAuthorizationDecision> Decision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardAuthorizationDecision>>(
                "decision"
            );
        }
        init { this._rawData.Set("decision", value); }
    }

    /// <summary>
    /// If your application approves the authorization, this contains metadata about
    /// your decision to approve. Your response here is advisory to the acquiring
    /// bank. The bank may choose to reverse the authorization if you approve the
    /// transaction but indicate the address does not match.
    /// </summary>
    public Approval? Approval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Approval>("approval");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("approval", value);
        }
    }

    /// <summary>
    /// If your application declines the authorization, this contains details about
    /// the decline.
    /// </summary>
    public Decline? Decline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Decline>("decline");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("decline", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Decision.Validate();
        this.Approval?.Validate();
        this.Decline?.Validate();
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

    [SetsRequiredMembers]
    public CardAuthorization(ApiEnum<string, CardAuthorizationDecision> decision)
        : this()
    {
        this.Decision = decision;
    }
}

class CardAuthorizationFromRaw : IFromRawJson<CardAuthorization>
{
    /// <inheritdoc/>
    public CardAuthorization FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardAuthorization.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the card authorization should be approved or declined.
/// </summary>
[JsonConverter(typeof(CardAuthorizationDecisionConverter))]
public enum CardAuthorizationDecision
{
    /// <summary>
    /// Approve the authorization.
    /// </summary>
    Approve,

    /// <summary>
    /// Decline the authorization.
    /// </summary>
    Decline,
}

sealed class CardAuthorizationDecisionConverter : JsonConverter<CardAuthorizationDecision>
{
    public override CardAuthorizationDecision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approve" => CardAuthorizationDecision.Approve,
            "decline" => CardAuthorizationDecision.Decline,
            _ => (CardAuthorizationDecision)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardAuthorizationDecision value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardAuthorizationDecision.Approve => "approve",
                CardAuthorizationDecision.Decline => "decline",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If your application approves the authorization, this contains metadata about
/// your decision to approve. Your response here is advisory to the acquiring bank.
/// The bank may choose to reverse the authorization if you approve the transaction
/// but indicate the address does not match.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Approval, ApprovalFromRaw>))]
public sealed record class Approval : JsonModel
{
    /// <summary>
    /// Your decisions on whether or not each provided address component is a match.
    /// Your response here is evaluated against the customer's provided `postal_code`
    /// and `line1`, and an appropriate network response is generated. For more information,
    /// see our [Address Verification System Codes and Overrides](https://increase.com/documentation/address-verification-system-codes-and-overrides) guide.
    /// </summary>
    public CardholderAddressVerificationResult? CardholderAddressVerificationResult
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardholderAddressVerificationResult>(
                "cardholder_address_verification_result"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cardholder_address_verification_result", value);
        }
    }

    /// <summary>
    /// If the transaction supports partial approvals (`partial_approval_capability:
    /// supported`) the `partial_amount` can be provided in the transaction's settlement
    /// currency to approve a lower amount than was requested.
    /// </summary>
    public long? PartialAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("partial_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("partial_amount", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CardholderAddressVerificationResult?.Validate();
        _ = this.PartialAmount;
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
/// Your decisions on whether or not each provided address component is a match. Your
/// response here is evaluated against the customer's provided `postal_code` and
/// `line1`, and an appropriate network response is generated. For more information,
/// see our [Address Verification System Codes and Overrides](https://increase.com/documentation/address-verification-system-codes-and-overrides) guide.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardholderAddressVerificationResult,
        CardholderAddressVerificationResultFromRaw
    >)
)]
public sealed record class CardholderAddressVerificationResult : JsonModel
{
    /// <summary>
    /// Your decision on the address line of the provided address.
    /// </summary>
    public required ApiEnum<string, Line1> Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Line1>>("line1");
        }
        init { this._rawData.Set("line1", value); }
    }

    /// <summary>
    /// Your decision on the postal code of the provided address.
    /// </summary>
    public required ApiEnum<string, PostalCode> PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PostalCode>>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Line1.Validate();
        this.PostalCode.Validate();
    }

    public CardholderAddressVerificationResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardholderAddressVerificationResult(
        CardholderAddressVerificationResult cardholderAddressVerificationResult
    )
        : base(cardholderAddressVerificationResult) { }
#pragma warning restore CS8618

    public CardholderAddressVerificationResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardholderAddressVerificationResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardholderAddressVerificationResultFromRaw.FromRawUnchecked"/>
    public static CardholderAddressVerificationResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardholderAddressVerificationResultFromRaw : IFromRawJson<CardholderAddressVerificationResult>
{
    /// <inheritdoc/>
    public CardholderAddressVerificationResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardholderAddressVerificationResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Your decision on the address line of the provided address.
/// </summary>
[JsonConverter(typeof(Line1Converter))]
public enum Line1
{
    /// <summary>
    /// The cardholder address verification result matches the address provided by
    /// the merchant.
    /// </summary>
    Match,

    /// <summary>
    /// The cardholder address verification result does not match the address provided
    /// by the merchant.
    /// </summary>
    NoMatch,
}

sealed class Line1Converter : JsonConverter<Line1>
{
    public override Line1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "match" => Line1.Match,
            "no_match" => Line1.NoMatch,
            _ => (Line1)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Line1 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Line1.Match => "match",
                Line1.NoMatch => "no_match",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Your decision on the postal code of the provided address.
/// </summary>
[JsonConverter(typeof(PostalCodeConverter))]
public enum PostalCode
{
    /// <summary>
    /// The cardholder address verification result matches the address provided by
    /// the merchant.
    /// </summary>
    Match,

    /// <summary>
    /// The cardholder address verification result does not match the address provided
    /// by the merchant.
    /// </summary>
    NoMatch,
}

sealed class PostalCodeConverter : JsonConverter<PostalCode>
{
    public override PostalCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "match" => PostalCode.Match,
            "no_match" => PostalCode.NoMatch,
            _ => (PostalCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PostalCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PostalCode.Match => "match",
                PostalCode.NoMatch => "no_match",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If your application declines the authorization, this contains details about the decline.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Decline, DeclineFromRaw>))]
public sealed record class Decline : JsonModel
{
    /// <summary>
    /// The reason the card authorization was declined. This translates to a specific
    /// decline code that is sent to the card network.
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

    [SetsRequiredMembers]
    public Decline(ApiEnum<string, Reason> reason)
        : this()
    {
        this.Reason = reason;
    }
}

class DeclineFromRaw : IFromRawJson<Decline>
{
    /// <inheritdoc/>
    public Decline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Decline.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason the card authorization was declined. This translates to a specific
/// decline code that is sent to the card network.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
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
            "insufficient_funds" => Reason.InsufficientFunds,
            "transaction_never_allowed" => Reason.TransactionNeverAllowed,
            "exceeds_approval_limit" => Reason.ExceedsApprovalLimit,
            "card_temporarily_disabled" => Reason.CardTemporarilyDisabled,
            "suspected_fraud" => Reason.SuspectedFraud,
            "other" => Reason.Other,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.InsufficientFunds => "insufficient_funds",
                Reason.TransactionNeverAllowed => "transaction_never_allowed",
                Reason.ExceedsApprovalLimit => "exceeds_approval_limit",
                Reason.CardTemporarilyDisabled => "card_temporarily_disabled",
                Reason.SuspectedFraud => "suspected_fraud",
                Reason.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If the Real-Time Decision relates to a card balance inquiry attempt, this object
/// contains your response to the inquiry.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardBalanceInquiry, CardBalanceInquiryFromRaw>))]
public sealed record class CardBalanceInquiry : JsonModel
{
    /// <summary>
    /// Whether the card balance inquiry should be approved or declined.
    /// </summary>
    public required ApiEnum<string, CardBalanceInquiryDecision> Decision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardBalanceInquiryDecision>>(
                "decision"
            );
        }
        init { this._rawData.Set("decision", value); }
    }

    /// <summary>
    /// If your application approves the balance inquiry, this contains metadata
    /// about your decision to approve.
    /// </summary>
    public CardBalanceInquiryApproval? Approval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardBalanceInquiryApproval>("approval");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("approval", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Decision.Validate();
        this.Approval?.Validate();
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

    [SetsRequiredMembers]
    public CardBalanceInquiry(ApiEnum<string, CardBalanceInquiryDecision> decision)
        : this()
    {
        this.Decision = decision;
    }
}

class CardBalanceInquiryFromRaw : IFromRawJson<CardBalanceInquiry>
{
    /// <inheritdoc/>
    public CardBalanceInquiry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardBalanceInquiry.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the card balance inquiry should be approved or declined.
/// </summary>
[JsonConverter(typeof(CardBalanceInquiryDecisionConverter))]
public enum CardBalanceInquiryDecision
{
    /// <summary>
    /// Approve the authorization.
    /// </summary>
    Approve,

    /// <summary>
    /// Decline the authorization.
    /// </summary>
    Decline,
}

sealed class CardBalanceInquiryDecisionConverter : JsonConverter<CardBalanceInquiryDecision>
{
    public override CardBalanceInquiryDecision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approve" => CardBalanceInquiryDecision.Approve,
            "decline" => CardBalanceInquiryDecision.Decline,
            _ => (CardBalanceInquiryDecision)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardBalanceInquiryDecision value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardBalanceInquiryDecision.Approve => "approve",
                CardBalanceInquiryDecision.Decline => "decline",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If your application approves the balance inquiry, this contains metadata about
/// your decision to approve.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CardBalanceInquiryApproval, CardBalanceInquiryApprovalFromRaw>)
)]
public sealed record class CardBalanceInquiryApproval : JsonModel
{
    /// <summary>
    /// The balance on the card in the settlement currency of the transaction.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Balance;
    }

    public CardBalanceInquiryApproval() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBalanceInquiryApproval(CardBalanceInquiryApproval cardBalanceInquiryApproval)
        : base(cardBalanceInquiryApproval) { }
#pragma warning restore CS8618

    public CardBalanceInquiryApproval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBalanceInquiryApproval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBalanceInquiryApprovalFromRaw.FromRawUnchecked"/>
    public static CardBalanceInquiryApproval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardBalanceInquiryApproval(long balance)
        : this()
    {
        this.Balance = balance;
    }
}

class CardBalanceInquiryApprovalFromRaw : IFromRawJson<CardBalanceInquiryApproval>
{
    /// <inheritdoc/>
    public CardBalanceInquiryApproval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardBalanceInquiryApproval.FromRawUnchecked(rawData);
}

/// <summary>
/// If the Real-Time Decision relates to a digital wallet authentication attempt,
/// this object contains your response to the authentication.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DigitalWalletAuthentication, DigitalWalletAuthenticationFromRaw>)
)]
public sealed record class DigitalWalletAuthentication : JsonModel
{
    /// <summary>
    /// Whether your application was able to deliver the one-time passcode.
    /// </summary>
    public required ApiEnum<string, DigitalWalletAuthenticationResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, DigitalWalletAuthenticationResult>
            >("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <summary>
    /// If your application was able to deliver the one-time passcode, this contains
    /// metadata about the delivery. Exactly one of `phone` or `email` must be provided.
    /// </summary>
    public DigitalWalletAuthenticationSuccess? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DigitalWalletAuthenticationSuccess>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Result.Validate();
        this.Success?.Validate();
    }

    public DigitalWalletAuthentication() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalWalletAuthentication(DigitalWalletAuthentication digitalWalletAuthentication)
        : base(digitalWalletAuthentication) { }
#pragma warning restore CS8618

    public DigitalWalletAuthentication(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalWalletAuthentication(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalWalletAuthenticationFromRaw.FromRawUnchecked"/>
    public static DigitalWalletAuthentication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DigitalWalletAuthentication(ApiEnum<string, DigitalWalletAuthenticationResult> result)
        : this()
    {
        this.Result = result;
    }
}

class DigitalWalletAuthenticationFromRaw : IFromRawJson<DigitalWalletAuthentication>
{
    /// <inheritdoc/>
    public DigitalWalletAuthentication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigitalWalletAuthentication.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether your application was able to deliver the one-time passcode.
/// </summary>
[JsonConverter(typeof(DigitalWalletAuthenticationResultConverter))]
public enum DigitalWalletAuthenticationResult
{
    /// <summary>
    /// Your application successfully delivered the one-time passcode to the cardholder.
    /// </summary>
    Success,

    /// <summary>
    /// Your application failed to deliver the one-time passcode to the cardholder.
    /// </summary>
    Failure,
}

sealed class DigitalWalletAuthenticationResultConverter
    : JsonConverter<DigitalWalletAuthenticationResult>
{
    public override DigitalWalletAuthenticationResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => DigitalWalletAuthenticationResult.Success,
            "failure" => DigitalWalletAuthenticationResult.Failure,
            _ => (DigitalWalletAuthenticationResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DigitalWalletAuthenticationResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DigitalWalletAuthenticationResult.Success => "success",
                DigitalWalletAuthenticationResult.Failure => "failure",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If your application was able to deliver the one-time passcode, this contains
/// metadata about the delivery. Exactly one of `phone` or `email` must be provided.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DigitalWalletAuthenticationSuccess,
        DigitalWalletAuthenticationSuccessFromRaw
    >)
)]
public sealed record class DigitalWalletAuthenticationSuccess : JsonModel
{
    /// <summary>
    /// The email address that was used to verify the cardholder via one-time passcode.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// The phone number that was used to verify the cardholder via one-time passcode
    /// over SMS.
    /// </summary>
    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.Phone;
    }

    public DigitalWalletAuthenticationSuccess() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalWalletAuthenticationSuccess(
        DigitalWalletAuthenticationSuccess digitalWalletAuthenticationSuccess
    )
        : base(digitalWalletAuthenticationSuccess) { }
#pragma warning restore CS8618

    public DigitalWalletAuthenticationSuccess(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalWalletAuthenticationSuccess(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalWalletAuthenticationSuccessFromRaw.FromRawUnchecked"/>
    public static DigitalWalletAuthenticationSuccess FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalWalletAuthenticationSuccessFromRaw : IFromRawJson<DigitalWalletAuthenticationSuccess>
{
    /// <inheritdoc/>
    public DigitalWalletAuthenticationSuccess FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigitalWalletAuthenticationSuccess.FromRawUnchecked(rawData);
}

/// <summary>
/// If the Real-Time Decision relates to a digital wallet token provisioning attempt,
/// this object contains your response to the attempt.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DigitalWalletToken, DigitalWalletTokenFromRaw>))]
public sealed record class DigitalWalletToken : JsonModel
{
    /// <summary>
    /// If your application approves the provisioning attempt, this contains metadata
    /// about the digital wallet token that will be generated.
    /// </summary>
    public DigitalWalletTokenApproval? Approval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DigitalWalletTokenApproval>("approval");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("approval", value);
        }
    }

    /// <summary>
    /// If your application declines the provisioning attempt, this contains details
    /// about the decline.
    /// </summary>
    public DigitalWalletTokenDecline? Decline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DigitalWalletTokenDecline>("decline");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("decline", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Approval?.Validate();
        this.Decline?.Validate();
    }

    public DigitalWalletToken() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalWalletToken(DigitalWalletToken digitalWalletToken)
        : base(digitalWalletToken) { }
#pragma warning restore CS8618

    public DigitalWalletToken(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalWalletToken(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalWalletTokenFromRaw.FromRawUnchecked"/>
    public static DigitalWalletToken FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalWalletTokenFromRaw : IFromRawJson<DigitalWalletToken>
{
    /// <inheritdoc/>
    public DigitalWalletToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DigitalWalletToken.FromRawUnchecked(rawData);
}

/// <summary>
/// If your application approves the provisioning attempt, this contains metadata
/// about the digital wallet token that will be generated.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DigitalWalletTokenApproval, DigitalWalletTokenApprovalFromRaw>)
)]
public sealed record class DigitalWalletTokenApproval : JsonModel
{
    /// <summary>
    /// An email address that can be used to verify the cardholder via one-time passcode.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// A phone number that can be used to verify the cardholder via one-time passcode
    /// over SMS.
    /// </summary>
    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.Phone;
    }

    public DigitalWalletTokenApproval() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalWalletTokenApproval(DigitalWalletTokenApproval digitalWalletTokenApproval)
        : base(digitalWalletTokenApproval) { }
#pragma warning restore CS8618

    public DigitalWalletTokenApproval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalWalletTokenApproval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalWalletTokenApprovalFromRaw.FromRawUnchecked"/>
    public static DigitalWalletTokenApproval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalWalletTokenApprovalFromRaw : IFromRawJson<DigitalWalletTokenApproval>
{
    /// <inheritdoc/>
    public DigitalWalletTokenApproval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigitalWalletTokenApproval.FromRawUnchecked(rawData);
}

/// <summary>
/// If your application declines the provisioning attempt, this contains details
/// about the decline.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DigitalWalletTokenDecline, DigitalWalletTokenDeclineFromRaw>)
)]
public sealed record class DigitalWalletTokenDecline : JsonModel
{
    /// <summary>
    /// Why the tokenization attempt was declined. This is for logging purposes only
    /// and is not displayed to the end-user.
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
        _ = this.Reason;
    }

    public DigitalWalletTokenDecline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalWalletTokenDecline(DigitalWalletTokenDecline digitalWalletTokenDecline)
        : base(digitalWalletTokenDecline) { }
#pragma warning restore CS8618

    public DigitalWalletTokenDecline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalWalletTokenDecline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalWalletTokenDeclineFromRaw.FromRawUnchecked"/>
    public static DigitalWalletTokenDecline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalWalletTokenDeclineFromRaw : IFromRawJson<DigitalWalletTokenDecline>
{
    /// <inheritdoc/>
    public DigitalWalletTokenDecline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigitalWalletTokenDecline.FromRawUnchecked(rawData);
}
