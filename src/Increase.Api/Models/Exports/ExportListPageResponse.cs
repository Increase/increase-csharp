using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.Exports;

/// <summary>
/// A list of Export objects.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExportListPageResponse, ExportListPageResponseFromRaw>))]
public sealed record class ExportListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<Export> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Export>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Export>>(
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

    public ExportListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportListPageResponse(ExportListPageResponse exportListPageResponse)
        : base(exportListPageResponse) { }
#pragma warning restore CS8618

    public ExportListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportListPageResponseFromRaw.FromRawUnchecked"/>
    public static ExportListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportListPageResponseFromRaw : IFromRawJson<ExportListPageResponse>
{
    /// <inheritdoc/>
    public ExportListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExportListPageResponse.FromRawUnchecked(rawData);
}
