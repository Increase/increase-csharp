using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.AccountTransfers;

/// <summary>
/// A list of Account Transfer objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AccountTransferListPageResponse,
        AccountTransferListPageResponseFromRaw
    >)
)]
public sealed record class AccountTransferListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<AccountTransfer> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AccountTransfer>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AccountTransfer>>(
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

    public AccountTransferListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountTransferListPageResponse(
        AccountTransferListPageResponse accountTransferListPageResponse
    )
        : base(accountTransferListPageResponse) { }
#pragma warning restore CS8618

    public AccountTransferListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountTransferListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountTransferListPageResponseFromRaw.FromRawUnchecked"/>
    public static AccountTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountTransferListPageResponseFromRaw : IFromRawJson<AccountTransferListPageResponse>
{
    /// <inheritdoc/>
    public AccountTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountTransferListPageResponse.FromRawUnchecked(rawData);
}
