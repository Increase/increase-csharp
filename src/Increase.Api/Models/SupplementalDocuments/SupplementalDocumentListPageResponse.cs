using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.SupplementalDocuments;

/// <summary>
/// A list of Supplemental Document objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SupplementalDocumentListPageResponse,
        SupplementalDocumentListPageResponseFromRaw
    >)
)]
public sealed record class SupplementalDocumentListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<EntitySupplementalDocument> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EntitySupplementalDocument>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<EntitySupplementalDocument>>(
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

    public SupplementalDocumentListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SupplementalDocumentListPageResponse(
        SupplementalDocumentListPageResponse supplementalDocumentListPageResponse
    )
        : base(supplementalDocumentListPageResponse) { }
#pragma warning restore CS8618

    public SupplementalDocumentListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SupplementalDocumentListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SupplementalDocumentListPageResponseFromRaw.FromRawUnchecked"/>
    public static SupplementalDocumentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SupplementalDocumentListPageResponseFromRaw
    : IFromRawJson<SupplementalDocumentListPageResponse>
{
    /// <inheritdoc/>
    public SupplementalDocumentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SupplementalDocumentListPageResponse.FromRawUnchecked(rawData);
}
