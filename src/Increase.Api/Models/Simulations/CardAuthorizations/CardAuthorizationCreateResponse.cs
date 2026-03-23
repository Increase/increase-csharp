using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.DeclinedTransactions;
using Increase.Api.Models.PendingTransactions;
using System = System;

namespace Increase.Api.Models.Simulations.CardAuthorizations;

/// <summary>
/// The results of a Card Authorization simulation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardAuthorizationCreateResponse,
        CardAuthorizationCreateResponseFromRaw
    >)
)]
public sealed record class CardAuthorizationCreateResponse : JsonModel
{
    /// <summary>
    /// If the authorization attempt fails, this will contain the resulting [Declined
    /// Transaction](#declined-transactions) object. The Declined Transaction's `source`
    /// will be of `category: card_decline`.
    /// </summary>
    public required DeclinedTransaction? DeclinedTransaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DeclinedTransaction>("declined_transaction");
        }
        init { this._rawData.Set("declined_transaction", value); }
    }

    /// <summary>
    /// If the authorization attempt succeeds, this will contain the resulting Pending
    /// Transaction object. The Pending Transaction's `source` will be of `category: card_authorization`.
    /// </summary>
    public required PendingTransaction? PendingTransaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PendingTransaction>("pending_transaction");
        }
        init { this._rawData.Set("pending_transaction", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `inbound_card_authorization_simulation_result`.
    /// </summary>
    public required ApiEnum<
        string,
        global::Increase.Api.Models.Simulations.CardAuthorizations.Type
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.Simulations.CardAuthorizations.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DeclinedTransaction?.Validate();
        this.PendingTransaction?.Validate();
        this.Type.Validate();
    }

    public CardAuthorizationCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorizationCreateResponse(
        CardAuthorizationCreateResponse cardAuthorizationCreateResponse
    )
        : base(cardAuthorizationCreateResponse) { }
#pragma warning restore CS8618

    public CardAuthorizationCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorizationCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthorizationCreateResponseFromRaw.FromRawUnchecked"/>
    public static CardAuthorizationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardAuthorizationCreateResponseFromRaw : IFromRawJson<CardAuthorizationCreateResponse>
{
    /// <inheritdoc/>
    public CardAuthorizationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardAuthorizationCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `inbound_card_authorization_simulation_result`.
/// </summary>
[JsonConverter(typeof(global::Increase.Api.Models.Simulations.CardAuthorizations.TypeConverter))]
public enum Type
{
    InboundCardAuthorizationSimulationResult,
}

sealed class TypeConverter
    : JsonConverter<global::Increase.Api.Models.Simulations.CardAuthorizations.Type>
{
    public override global::Increase.Api.Models.Simulations.CardAuthorizations.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_card_authorization_simulation_result" => global::Increase
                .Api
                .Models
                .Simulations
                .CardAuthorizations
                .Type
                .InboundCardAuthorizationSimulationResult,
            _ => (global::Increase.Api.Models.Simulations.CardAuthorizations.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.Simulations.CardAuthorizations.Type value,
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
                    .CardAuthorizations
                    .Type
                    .InboundCardAuthorizationSimulationResult =>
                    "inbound_card_authorization_simulation_result",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
