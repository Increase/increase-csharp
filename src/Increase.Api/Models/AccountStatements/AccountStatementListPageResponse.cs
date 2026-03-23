using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.AccountStatements;

/// <summary>
/// A list of Account Statement objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AccountStatementListPageResponse,
        AccountStatementListPageResponseFromRaw
    >)
)]
public sealed record class AccountStatementListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<AccountStatement> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AccountStatement>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AccountStatement>>(
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

    public AccountStatementListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountStatementListPageResponse(
        AccountStatementListPageResponse accountStatementListPageResponse
    )
        : base(accountStatementListPageResponse) { }
#pragma warning restore CS8618

    public AccountStatementListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountStatementListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountStatementListPageResponseFromRaw.FromRawUnchecked"/>
    public static AccountStatementListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountStatementListPageResponseFromRaw : IFromRawJson<AccountStatementListPageResponse>
{
    /// <inheritdoc/>
    public AccountStatementListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountStatementListPageResponse.FromRawUnchecked(rawData);
}
