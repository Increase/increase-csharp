using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.CheckDeposits;

/// <summary>
/// A list of Check Deposit objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CheckDepositListPageResponse, CheckDepositListPageResponseFromRaw>)
)]
public sealed record class CheckDepositListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<CheckDeposit> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CheckDeposit>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CheckDeposit>>(
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

    public CheckDepositListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckDepositListPageResponse(CheckDepositListPageResponse checkDepositListPageResponse)
        : base(checkDepositListPageResponse) { }
#pragma warning restore CS8618

    public CheckDepositListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckDepositListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckDepositListPageResponseFromRaw.FromRawUnchecked"/>
    public static CheckDepositListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckDepositListPageResponseFromRaw : IFromRawJson<CheckDepositListPageResponse>
{
    /// <inheritdoc/>
    public CheckDepositListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckDepositListPageResponse.FromRawUnchecked(rawData);
}
