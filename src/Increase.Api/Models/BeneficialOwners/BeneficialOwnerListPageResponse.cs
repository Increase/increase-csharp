using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.BeneficialOwners;

/// <summary>
/// A list of Beneficial Owner objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BeneficialOwnerListPageResponse,
        BeneficialOwnerListPageResponseFromRaw
    >)
)]
public sealed record class BeneficialOwnerListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<EntityBeneficialOwner> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EntityBeneficialOwner>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<EntityBeneficialOwner>>(
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

    public BeneficialOwnerListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BeneficialOwnerListPageResponse(
        BeneficialOwnerListPageResponse beneficialOwnerListPageResponse
    )
        : base(beneficialOwnerListPageResponse) { }
#pragma warning restore CS8618

    public BeneficialOwnerListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BeneficialOwnerListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BeneficialOwnerListPageResponseFromRaw.FromRawUnchecked"/>
    public static BeneficialOwnerListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BeneficialOwnerListPageResponseFromRaw : IFromRawJson<BeneficialOwnerListPageResponse>
{
    /// <inheritdoc/>
    public BeneficialOwnerListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BeneficialOwnerListPageResponse.FromRawUnchecked(rawData);
}
