using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.OAuthConnections;

/// <summary>
/// A list of OAuth Connection objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        OAuthConnectionListPageResponse,
        OAuthConnectionListPageResponseFromRaw
    >)
)]
public sealed record class OAuthConnectionListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<OAuthConnection> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<OAuthConnection>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<OAuthConnection>>(
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

    public OAuthConnectionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthConnectionListPageResponse(
        OAuthConnectionListPageResponse oauthConnectionListPageResponse
    )
        : base(oauthConnectionListPageResponse) { }
#pragma warning restore CS8618

    public OAuthConnectionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthConnectionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OAuthConnectionListPageResponseFromRaw.FromRawUnchecked"/>
    public static OAuthConnectionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OAuthConnectionListPageResponseFromRaw : IFromRawJson<OAuthConnectionListPageResponse>
{
    /// <inheritdoc/>
    public OAuthConnectionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OAuthConnectionListPageResponse.FromRawUnchecked(rawData);
}
