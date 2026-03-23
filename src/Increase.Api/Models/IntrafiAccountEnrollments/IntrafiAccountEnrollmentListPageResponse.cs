using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.IntrafiAccountEnrollments;

/// <summary>
/// A list of IntraFi Account Enrollment objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        IntrafiAccountEnrollmentListPageResponse,
        IntrafiAccountEnrollmentListPageResponseFromRaw
    >)
)]
public sealed record class IntrafiAccountEnrollmentListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<IntrafiAccountEnrollment> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<IntrafiAccountEnrollment>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<IntrafiAccountEnrollment>>(
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

    public IntrafiAccountEnrollmentListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntrafiAccountEnrollmentListPageResponse(
        IntrafiAccountEnrollmentListPageResponse intrafiAccountEnrollmentListPageResponse
    )
        : base(intrafiAccountEnrollmentListPageResponse) { }
#pragma warning restore CS8618

    public IntrafiAccountEnrollmentListPageResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntrafiAccountEnrollmentListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntrafiAccountEnrollmentListPageResponseFromRaw.FromRawUnchecked"/>
    public static IntrafiAccountEnrollmentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntrafiAccountEnrollmentListPageResponseFromRaw
    : IFromRawJson<IntrafiAccountEnrollmentListPageResponse>
{
    /// <inheritdoc/>
    public IntrafiAccountEnrollmentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntrafiAccountEnrollmentListPageResponse.FromRawUnchecked(rawData);
}
