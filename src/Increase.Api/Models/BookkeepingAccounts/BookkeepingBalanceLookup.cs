using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.BookkeepingAccounts;

/// <summary>
/// Represents a request to lookup the balance of a Bookkeeping Account at a given
/// point in time.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BookkeepingBalanceLookup, BookkeepingBalanceLookupFromRaw>)
)]
public sealed record class BookkeepingBalanceLookup : JsonModel
{
    /// <summary>
    /// The Bookkeeping Account's current balance, representing the sum of all Bookkeeping
    /// Entries on the Bookkeeping Account.
    /// </summary>
    public required long Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("balance");
        }
        init { this._rawData.Set("balance", value); }
    }

    /// <summary>
    /// The identifier for the account for which the balance was queried.
    /// </summary>
    public required string BookkeepingAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("bookkeeping_account_id");
        }
        init { this._rawData.Set("bookkeeping_account_id", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `bookkeeping_balance_lookup`.
    /// </summary>
    public required ApiEnum<string, BookkeepingBalanceLookupType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BookkeepingBalanceLookupType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Balance;
        _ = this.BookkeepingAccountID;
        this.Type.Validate();
    }

    public BookkeepingBalanceLookup() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BookkeepingBalanceLookup(BookkeepingBalanceLookup bookkeepingBalanceLookup)
        : base(bookkeepingBalanceLookup) { }
#pragma warning restore CS8618

    public BookkeepingBalanceLookup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BookkeepingBalanceLookup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BookkeepingBalanceLookupFromRaw.FromRawUnchecked"/>
    public static BookkeepingBalanceLookup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BookkeepingBalanceLookupFromRaw : IFromRawJson<BookkeepingBalanceLookup>
{
    /// <inheritdoc/>
    public BookkeepingBalanceLookup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BookkeepingBalanceLookup.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `bookkeeping_balance_lookup`.
/// </summary>
[JsonConverter(typeof(BookkeepingBalanceLookupTypeConverter))]
public enum BookkeepingBalanceLookupType
{
    BookkeepingBalanceLookup,
}

sealed class BookkeepingBalanceLookupTypeConverter : JsonConverter<BookkeepingBalanceLookupType>
{
    public override BookkeepingBalanceLookupType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "bookkeeping_balance_lookup" => BookkeepingBalanceLookupType.BookkeepingBalanceLookup,
            _ => (BookkeepingBalanceLookupType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BookkeepingBalanceLookupType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BookkeepingBalanceLookupType.BookkeepingBalanceLookup =>
                    "bookkeeping_balance_lookup",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
