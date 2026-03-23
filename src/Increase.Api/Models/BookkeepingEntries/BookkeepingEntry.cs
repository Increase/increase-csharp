using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.BookkeepingEntries;

/// <summary>
/// Entries are T-account entries recording debits and credits. Your compliance setup
/// might require annotating money movements using this API. Learn more in our [guide
/// to Bookkeeping](https://increase.com/documentation/bookkeeping#bookkeeping).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BookkeepingEntry, BookkeepingEntryFromRaw>))]
public sealed record class BookkeepingEntry : JsonModel
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
    /// The identifier for the Account the Entry belongs to.
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
    /// The Entry amount in the minor unit of its currency. For dollars, for example,
    /// this is cents.
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
    /// The identifier for the Entry Set the Entry belongs to.
    /// </summary>
    public required string EntrySetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entry_set_id");
        }
        init { this._rawData.Set("entry_set_id", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `bookkeeping_entry`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.BookkeepingEntries.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.BookkeepingEntries.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.Amount;
        _ = this.CreatedAt;
        _ = this.EntrySetID;
        this.Type.Validate();
    }

    public BookkeepingEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BookkeepingEntry(BookkeepingEntry bookkeepingEntry)
        : base(bookkeepingEntry) { }
#pragma warning restore CS8618

    public BookkeepingEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BookkeepingEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BookkeepingEntryFromRaw.FromRawUnchecked"/>
    public static BookkeepingEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BookkeepingEntryFromRaw : IFromRawJson<BookkeepingEntry>
{
    /// <inheritdoc/>
    public BookkeepingEntry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BookkeepingEntry.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `bookkeeping_entry`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    BookkeepingEntry,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.BookkeepingEntries.Type>
{
    public override global::Increase.Api.Models.BookkeepingEntries.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "bookkeeping_entry" => global::Increase
                .Api
                .Models
                .BookkeepingEntries
                .Type
                .BookkeepingEntry,
            _ => (global::Increase.Api.Models.BookkeepingEntries.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.BookkeepingEntries.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.BookkeepingEntries.Type.BookkeepingEntry =>
                    "bookkeeping_entry",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
