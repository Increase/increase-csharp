using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.InboundCheckDeposits;

/// <summary>
/// A list of Inbound Check Deposit objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InboundCheckDepositListPageResponse,
        InboundCheckDepositListPageResponseFromRaw
    >)
)]
public sealed record class InboundCheckDepositListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<InboundCheckDeposit> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InboundCheckDeposit>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<InboundCheckDeposit>>(
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

    public InboundCheckDepositListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundCheckDepositListPageResponse(
        InboundCheckDepositListPageResponse inboundCheckDepositListPageResponse
    )
        : base(inboundCheckDepositListPageResponse) { }
#pragma warning restore CS8618

    public InboundCheckDepositListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundCheckDepositListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundCheckDepositListPageResponseFromRaw.FromRawUnchecked"/>
    public static InboundCheckDepositListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundCheckDepositListPageResponseFromRaw : IFromRawJson<InboundCheckDepositListPageResponse>
{
    /// <inheritdoc/>
    public InboundCheckDepositListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundCheckDepositListPageResponse.FromRawUnchecked(rawData);
}
