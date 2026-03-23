using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.OAuthApplications;

/// <summary>
/// A list of OAuth Application objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        OAuthApplicationListPageResponse,
        OAuthApplicationListPageResponseFromRaw
    >)
)]
public sealed record class OAuthApplicationListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<OAuthApplication> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<OAuthApplication>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<OAuthApplication>>(
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

    public OAuthApplicationListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthApplicationListPageResponse(
        OAuthApplicationListPageResponse oauthApplicationListPageResponse
    )
        : base(oauthApplicationListPageResponse) { }
#pragma warning restore CS8618

    public OAuthApplicationListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthApplicationListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OAuthApplicationListPageResponseFromRaw.FromRawUnchecked"/>
    public static OAuthApplicationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OAuthApplicationListPageResponseFromRaw : IFromRawJson<OAuthApplicationListPageResponse>
{
    /// <inheritdoc/>
    public OAuthApplicationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OAuthApplicationListPageResponse.FromRawUnchecked(rawData);
}
