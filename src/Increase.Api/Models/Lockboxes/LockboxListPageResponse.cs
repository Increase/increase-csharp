using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.Lockboxes;

/// <summary>
/// A list of Lockbox objects.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LockboxListPageResponse, LockboxListPageResponseFromRaw>))]
public sealed record class LockboxListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<Lockbox> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Lockbox>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Lockbox>>(
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

    public LockboxListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LockboxListPageResponse(LockboxListPageResponse lockboxListPageResponse)
        : base(lockboxListPageResponse) { }
#pragma warning restore CS8618

    public LockboxListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LockboxListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LockboxListPageResponseFromRaw.FromRawUnchecked"/>
    public static LockboxListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LockboxListPageResponseFromRaw : IFromRawJson<LockboxListPageResponse>
{
    /// <inheritdoc/>
    public LockboxListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LockboxListPageResponse.FromRawUnchecked(rawData);
}
