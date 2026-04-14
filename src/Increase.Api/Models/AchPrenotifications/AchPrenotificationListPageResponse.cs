using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.AchPrenotifications;

/// <summary>
/// A list of ACH Prenotification objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AchPrenotificationListPageResponse,
        AchPrenotificationListPageResponseFromRaw
    >)
)]
public sealed record class AchPrenotificationListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<AchPrenotification> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AchPrenotification>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AchPrenotification>>(
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

    public AchPrenotificationListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchPrenotificationListPageResponse(
        AchPrenotificationListPageResponse achPrenotificationListPageResponse
    )
        : base(achPrenotificationListPageResponse) { }
#pragma warning restore CS8618

    public AchPrenotificationListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AchPrenotificationListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AchPrenotificationListPageResponseFromRaw.FromRawUnchecked"/>
    public static AchPrenotificationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AchPrenotificationListPageResponseFromRaw : IFromRawJson<AchPrenotificationListPageResponse>
{
    /// <inheritdoc/>
    public AchPrenotificationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AchPrenotificationListPageResponse.FromRawUnchecked(rawData);
}
