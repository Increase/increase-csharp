using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.Accounts;

/// <summary>
/// A list of Account objects.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccountListPageResponse, AccountListPageResponseFromRaw>))]
public sealed record class AccountListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<Account> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Account>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Account>>(
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

    public AccountListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountListPageResponse(AccountListPageResponse accountListPageResponse)
        : base(accountListPageResponse) { }
#pragma warning restore CS8618

    public AccountListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountListPageResponseFromRaw.FromRawUnchecked"/>
    public static AccountListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountListPageResponseFromRaw : IFromRawJson<AccountListPageResponse>
{
    /// <inheritdoc/>
    public AccountListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountListPageResponse.FromRawUnchecked(rawData);
}
