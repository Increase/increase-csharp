using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Simulations.DigitalWalletTokenRequests;

/// <summary>
/// The results of a Digital Wallet Token simulation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DigitalWalletTokenRequestCreateResponse,
        DigitalWalletTokenRequestCreateResponseFromRaw
    >)
)]
public sealed record class DigitalWalletTokenRequestCreateResponse : JsonModel
{
    /// <summary>
    /// If the simulated tokenization attempt was declined, this field contains details
    /// as to why.
    /// </summary>
    public required ApiEnum<string, DeclineReason>? DeclineReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DeclineReason>>("decline_reason");
        }
        init { this._rawData.Set("decline_reason", value); }
    }

    /// <summary>
    /// If the simulated tokenization attempt was accepted, this field contains the
    /// id of the Digital Wallet Token that was created.
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
    /// A constant representing the object's type. For this resource it will always
    /// be `inbound_digital_wallet_token_request_simulation_result`.
    /// </summary>
    public required ApiEnum<
        string,
        global::Increase.Api.Models.Simulations.DigitalWalletTokenRequests.Type
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    global::Increase.Api.Models.Simulations.DigitalWalletTokenRequests.Type
                >
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DeclineReason?.Validate();
        _ = this.DigitalWalletTokenID;
        this.Type.Validate();
    }

    public DigitalWalletTokenRequestCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalWalletTokenRequestCreateResponse(
        DigitalWalletTokenRequestCreateResponse digitalWalletTokenRequestCreateResponse
    )
        : base(digitalWalletTokenRequestCreateResponse) { }
#pragma warning restore CS8618

    public DigitalWalletTokenRequestCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalWalletTokenRequestCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalWalletTokenRequestCreateResponseFromRaw.FromRawUnchecked"/>
    public static DigitalWalletTokenRequestCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalWalletTokenRequestCreateResponseFromRaw
    : IFromRawJson<DigitalWalletTokenRequestCreateResponse>
{
    /// <inheritdoc/>
    public DigitalWalletTokenRequestCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigitalWalletTokenRequestCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// If the simulated tokenization attempt was declined, this field contains details
/// as to why.
/// </summary>
[JsonConverter(typeof(DeclineReasonConverter))]
public enum DeclineReason
{
    /// <summary>
    /// The card is not active.
    /// </summary>
    CardNotActive,

    /// <summary>
    /// The card does not have a two-factor authentication method.
    /// </summary>
    NoVerificationMethod,

    /// <summary>
    /// Your webhook timed out when evaluating the token provisioning attempt.
    /// </summary>
    WebhookTimedOut,

    /// <summary>
    /// Your webhook declined the token provisioning attempt.
    /// </summary>
    WebhookDeclined,
}

sealed class DeclineReasonConverter : JsonConverter<DeclineReason>
{
    public override DeclineReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_not_active" => DeclineReason.CardNotActive,
            "no_verification_method" => DeclineReason.NoVerificationMethod,
            "webhook_timed_out" => DeclineReason.WebhookTimedOut,
            "webhook_declined" => DeclineReason.WebhookDeclined,
            _ => (DeclineReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeclineReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DeclineReason.CardNotActive => "card_not_active",
                DeclineReason.NoVerificationMethod => "no_verification_method",
                DeclineReason.WebhookTimedOut => "webhook_timed_out",
                DeclineReason.WebhookDeclined => "webhook_declined",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `inbound_digital_wallet_token_request_simulation_result`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    InboundDigitalWalletTokenRequestSimulationResult,
}

sealed class TypeConverter
    : JsonConverter<global::Increase.Api.Models.Simulations.DigitalWalletTokenRequests.Type>
{
    public override global::Increase.Api.Models.Simulations.DigitalWalletTokenRequests.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_digital_wallet_token_request_simulation_result" => global::Increase
                .Api
                .Models
                .Simulations
                .DigitalWalletTokenRequests
                .Type
                .InboundDigitalWalletTokenRequestSimulationResult,
            _ => (global::Increase.Api.Models.Simulations.DigitalWalletTokenRequests.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.Simulations.DigitalWalletTokenRequests.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase
                    .Api
                    .Models
                    .Simulations
                    .DigitalWalletTokenRequests
                    .Type
                    .InboundDigitalWalletTokenRequestSimulationResult =>
                    "inbound_digital_wallet_token_request_simulation_result",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
