using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.DigitalWalletTokens;

/// <summary>
/// A list of Digital Wallet Token objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DigitalWalletTokenListPageResponse,
        DigitalWalletTokenListPageResponseFromRaw
    >)
)]
public sealed record class DigitalWalletTokenListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<DigitalWalletToken> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DigitalWalletToken>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DigitalWalletToken>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A pointer to a place in the list. Pass this as the `cursor` parameter to retrieve
    /// the next page of results. If there are no more results, the value will be `null`.
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

    public DigitalWalletTokenListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalWalletTokenListPageResponse(
        DigitalWalletTokenListPageResponse digitalWalletTokenListPageResponse
    )
        : base(digitalWalletTokenListPageResponse) { }
#pragma warning restore CS8618

    public DigitalWalletTokenListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalWalletTokenListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalWalletTokenListPageResponseFromRaw.FromRawUnchecked"/>
    public static DigitalWalletTokenListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalWalletTokenListPageResponseFromRaw : IFromRawJson<DigitalWalletTokenListPageResponse>
{
    /// <inheritdoc/>
    public DigitalWalletTokenListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigitalWalletTokenListPageResponse.FromRawUnchecked(rawData);
}
