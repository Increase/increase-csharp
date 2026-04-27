using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.LockboxRecipients;

/// <summary>
/// A list of Lockbox Recipient objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        LockboxRecipientListPageResponse,
        LockboxRecipientListPageResponseFromRaw
    >)
)]
public sealed record class LockboxRecipientListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<LockboxRecipient> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<LockboxRecipient>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<LockboxRecipient>>(
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

    public LockboxRecipientListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LockboxRecipientListPageResponse(
        LockboxRecipientListPageResponse lockboxRecipientListPageResponse
    )
        : base(lockboxRecipientListPageResponse) { }
#pragma warning restore CS8618

    public LockboxRecipientListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LockboxRecipientListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LockboxRecipientListPageResponseFromRaw.FromRawUnchecked"/>
    public static LockboxRecipientListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LockboxRecipientListPageResponseFromRaw : IFromRawJson<LockboxRecipientListPageResponse>
{
    /// <inheritdoc/>
    public LockboxRecipientListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LockboxRecipientListPageResponse.FromRawUnchecked(rawData);
}
