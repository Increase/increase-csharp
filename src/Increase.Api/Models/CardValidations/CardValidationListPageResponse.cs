using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.CardValidations;

/// <summary>
/// A list of Card Validation objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardValidationListPageResponse,
        CardValidationListPageResponseFromRaw
    >)
)]
public sealed record class CardValidationListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<CardValidation> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CardValidation>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardValidation>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A pointer to a place in the list.
    /// </summary>
    public required string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public CardValidationListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardValidationListPageResponse(
        CardValidationListPageResponse cardValidationListPageResponse
    )
        : base(cardValidationListPageResponse) { }
#pragma warning restore CS8618

    public CardValidationListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardValidationListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardValidationListPageResponseFromRaw.FromRawUnchecked"/>
    public static CardValidationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardValidationListPageResponseFromRaw : IFromRawJson<CardValidationListPageResponse>
{
    /// <inheritdoc/>
    public CardValidationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardValidationListPageResponse.FromRawUnchecked(rawData);
}
