using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.EntityOnboardingSessions;

/// <summary>
/// A list of Entity Onboarding Session objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityOnboardingSessionListPageResponse,
        EntityOnboardingSessionListPageResponseFromRaw
    >)
)]
public sealed record class EntityOnboardingSessionListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<EntityOnboardingSession> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EntityOnboardingSession>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<EntityOnboardingSession>>(
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

    public EntityOnboardingSessionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityOnboardingSessionListPageResponse(
        EntityOnboardingSessionListPageResponse entityOnboardingSessionListPageResponse
    )
        : base(entityOnboardingSessionListPageResponse) { }
#pragma warning restore CS8618

    public EntityOnboardingSessionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityOnboardingSessionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityOnboardingSessionListPageResponseFromRaw.FromRawUnchecked"/>
    public static EntityOnboardingSessionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityOnboardingSessionListPageResponseFromRaw
    : IFromRawJson<EntityOnboardingSessionListPageResponse>
{
    /// <inheritdoc/>
    public EntityOnboardingSessionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityOnboardingSessionListPageResponse.FromRawUnchecked(rawData);
}
