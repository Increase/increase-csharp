using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.AccountNumbers;

/// <summary>
/// A list of Account Number objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AccountNumberListPageResponse, AccountNumberListPageResponseFromRaw>)
)]
public sealed record class AccountNumberListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<AccountNumber> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AccountNumber>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AccountNumber>>(
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

    public AccountNumberListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountNumberListPageResponse(
        AccountNumberListPageResponse accountNumberListPageResponse
    )
        : base(accountNumberListPageResponse) { }
#pragma warning restore CS8618

    public AccountNumberListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountNumberListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountNumberListPageResponseFromRaw.FromRawUnchecked"/>
    public static AccountNumberListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountNumberListPageResponseFromRaw : IFromRawJson<AccountNumberListPageResponse>
{
    /// <inheritdoc/>
    public AccountNumberListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountNumberListPageResponse.FromRawUnchecked(rawData);
}
