using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.LockboxAddresses;

/// <summary>
/// A list of Lockbox Address objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        LockboxAddressListPageResponse,
        LockboxAddressListPageResponseFromRaw
    >)
)]
public sealed record class LockboxAddressListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<LockboxAddress> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<LockboxAddress>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<LockboxAddress>>(
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

    public LockboxAddressListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LockboxAddressListPageResponse(
        LockboxAddressListPageResponse lockboxAddressListPageResponse
    )
        : base(lockboxAddressListPageResponse) { }
#pragma warning restore CS8618

    public LockboxAddressListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LockboxAddressListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LockboxAddressListPageResponseFromRaw.FromRawUnchecked"/>
    public static LockboxAddressListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LockboxAddressListPageResponseFromRaw : IFromRawJson<LockboxAddressListPageResponse>
{
    /// <inheritdoc/>
    public LockboxAddressListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LockboxAddressListPageResponse.FromRawUnchecked(rawData);
}
