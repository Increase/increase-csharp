using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.EventSubscriptions;

/// <summary>
/// A list of Event Subscription objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EventSubscriptionListPageResponse,
        EventSubscriptionListPageResponseFromRaw
    >)
)]
public sealed record class EventSubscriptionListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<EventSubscription> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EventSubscription>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<EventSubscription>>(
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

    public EventSubscriptionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventSubscriptionListPageResponse(
        EventSubscriptionListPageResponse eventSubscriptionListPageResponse
    )
        : base(eventSubscriptionListPageResponse) { }
#pragma warning restore CS8618

    public EventSubscriptionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventSubscriptionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventSubscriptionListPageResponseFromRaw.FromRawUnchecked"/>
    public static EventSubscriptionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventSubscriptionListPageResponseFromRaw : IFromRawJson<EventSubscriptionListPageResponse>
{
    /// <inheritdoc/>
    public EventSubscriptionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventSubscriptionListPageResponse.FromRawUnchecked(rawData);
}
