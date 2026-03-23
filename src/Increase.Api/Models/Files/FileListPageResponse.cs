using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.Files;

/// <summary>
/// A list of File objects.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileListPageResponse, FileListPageResponseFromRaw>))]
public sealed record class FileListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<File> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<File>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<File>>("data", ImmutableArray.ToImmutableArray(value));
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

    public FileListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileListPageResponse(FileListPageResponse fileListPageResponse)
        : base(fileListPageResponse) { }
#pragma warning restore CS8618

    public FileListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileListPageResponseFromRaw.FromRawUnchecked"/>
    public static FileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileListPageResponseFromRaw : IFromRawJson<FileListPageResponse>
{
    /// <inheritdoc/>
    public FileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileListPageResponse.FromRawUnchecked(rawData);
}
