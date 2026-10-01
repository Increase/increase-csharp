using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.DigitalWalletTokenRequests;

/// <summary>
/// A list of Digital Wallet Token Request objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DigitalWalletTokenRequestListPageResponse,
        DigitalWalletTokenRequestListPageResponseFromRaw
    >)
)]
public sealed record class DigitalWalletTokenRequestListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<DigitalWalletTokenRequest> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DigitalWalletTokenRequest>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<DigitalWalletTokenRequest>>(
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

    public DigitalWalletTokenRequestListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalWalletTokenRequestListPageResponse(
        DigitalWalletTokenRequestListPageResponse digitalWalletTokenRequestListPageResponse
    )
        : base(digitalWalletTokenRequestListPageResponse) { }
#pragma warning restore CS8618

    public DigitalWalletTokenRequestListPageResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalWalletTokenRequestListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalWalletTokenRequestListPageResponseFromRaw.FromRawUnchecked"/>
    public static DigitalWalletTokenRequestListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalWalletTokenRequestListPageResponseFromRaw
    : IFromRawJson<DigitalWalletTokenRequestListPageResponse>
{
    /// <inheritdoc/>
    public DigitalWalletTokenRequestListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigitalWalletTokenRequestListPageResponse.FromRawUnchecked(rawData);
}
