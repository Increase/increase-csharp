using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.Programs;

/// <summary>
/// A list of Program objects.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProgramListPageResponse, ProgramListPageResponseFromRaw>))]
public sealed record class ProgramListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<Program> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Program>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Program>>(
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

    public ProgramListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProgramListPageResponse(ProgramListPageResponse programListPageResponse)
        : base(programListPageResponse) { }
#pragma warning restore CS8618

    public ProgramListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProgramListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProgramListPageResponseFromRaw.FromRawUnchecked"/>
    public static ProgramListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProgramListPageResponseFromRaw : IFromRawJson<ProgramListPageResponse>
{
    /// <inheritdoc/>
    public ProgramListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProgramListPageResponse.FromRawUnchecked(rawData);
}
