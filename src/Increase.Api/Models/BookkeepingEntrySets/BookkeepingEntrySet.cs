using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.BookkeepingEntrySets;

/// <summary>
/// Entry Sets are accounting entries that are transactionally applied. Your compliance
/// setup might require annotating money movements using this API. Learn more in our
/// [guide to Bookkeeping](https://increase.com/documentation/bookkeeping#bookkeeping).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BookkeepingEntrySet, BookkeepingEntrySetFromRaw>))]
public sealed record class BookkeepingEntrySet : JsonModel
{
    /// <summary>
    /// The entry set identifier.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// When the entry set was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The timestamp of the entry set.
    /// </summary>
    public required System::DateTimeOffset Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("date");
        }
        init { this._rawData.Set("date", value); }
    }

    /// <summary>
    /// The entries.
    /// </summary>
    public required IReadOnlyList<BookkeepingEntrySetEntry> Entries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BookkeepingEntrySetEntry>>(
                "entries"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BookkeepingEntrySetEntry>>(
                "entries",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The idempotency key you chose for this object. This value is unique across
    /// Increase and is used to ensure that a request is only processed once. Learn
    /// more about [idempotency](https://increase.com/documentation/idempotency-keys).
    /// </summary>
    public required string? IdempotencyKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("idempotency_key");
        }
        init { this._rawData.Set("idempotency_key", value); }
    }

    /// <summary>
    /// The transaction identifier, if any.
    /// </summary>
    public required string? TransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transaction_id");
        }
        init { this._rawData.Set("transaction_id", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `bookkeeping_entry_set`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.BookkeepingEntrySets.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.BookkeepingEntrySets.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Date;
        foreach (var item in this.Entries)
        {
            item.Validate();
        }
        _ = this.IdempotencyKey;
        _ = this.TransactionID;
        this.Type.Validate();
    }

    public BookkeepingEntrySet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BookkeepingEntrySet(BookkeepingEntrySet bookkeepingEntrySet)
        : base(bookkeepingEntrySet) { }
#pragma warning restore CS8618

    public BookkeepingEntrySet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BookkeepingEntrySet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BookkeepingEntrySetFromRaw.FromRawUnchecked"/>
    public static BookkeepingEntrySet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BookkeepingEntrySetFromRaw : IFromRawJson<BookkeepingEntrySet>
{
    /// <inheritdoc/>
    public BookkeepingEntrySet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BookkeepingEntrySet.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<BookkeepingEntrySetEntry, BookkeepingEntrySetEntryFromRaw>)
)]
public sealed record class BookkeepingEntrySetEntry : JsonModel
{
    /// <summary>
    /// The entry identifier.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The bookkeeping account impacted by the entry.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// The amount of the entry in minor units.
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.Amount;
    }

    public BookkeepingEntrySetEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BookkeepingEntrySetEntry(BookkeepingEntrySetEntry bookkeepingEntrySetEntry)
        : base(bookkeepingEntrySetEntry) { }
#pragma warning restore CS8618

    public BookkeepingEntrySetEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BookkeepingEntrySetEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BookkeepingEntrySetEntryFromRaw.FromRawUnchecked"/>
    public static BookkeepingEntrySetEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BookkeepingEntrySetEntryFromRaw : IFromRawJson<BookkeepingEntrySetEntry>
{
    /// <inheritdoc/>
    public BookkeepingEntrySetEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BookkeepingEntrySetEntry.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `bookkeeping_entry_set`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    BookkeepingEntrySet,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.BookkeepingEntrySets.Type>
{
    public override global::Increase.Api.Models.BookkeepingEntrySets.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "bookkeeping_entry_set" => global::Increase
                .Api
                .Models
                .BookkeepingEntrySets
                .Type
                .BookkeepingEntrySet,
            _ => (global::Increase.Api.Models.BookkeepingEntrySets.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.BookkeepingEntrySets.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.BookkeepingEntrySets.Type.BookkeepingEntrySet =>
                    "bookkeeping_entry_set",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
