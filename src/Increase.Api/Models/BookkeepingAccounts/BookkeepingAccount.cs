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
/// Accounts are T-accounts. They can store accounting entries. Your compliance setup
/// might require annotating money movements using this API. Learn more in our [guide
/// to Bookkeeping](https://increase.com/documentation/bookkeeping#bookkeeping).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BookkeepingAccount, BookkeepingAccountFromRaw>))]
public sealed record class BookkeepingAccount : JsonModel
{
    /// <summary>
    /// The account identifier.
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
    /// The API Account associated with this bookkeeping account.
    /// </summary>
    public required string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// The compliance category of the account.
    /// </summary>
    public required ApiEnum<string, BookkeepingAccountComplianceCategory>? ComplianceCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BookkeepingAccountComplianceCategory>
            >("compliance_category");
        }
        init { this._rawData.Set("compliance_category", value); }
    }

    /// <summary>
    /// The Entity associated with this bookkeeping account.
    /// </summary>
    public required string? EntityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("entity_id");
        }
        init { this._rawData.Set("entity_id", value); }
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
    /// The name you choose for the account.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `bookkeeping_account`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.BookkeepingAccounts.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.BookkeepingAccounts.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        this.ComplianceCategory?.Validate();
        _ = this.EntityID;
        _ = this.IdempotencyKey;
        _ = this.Name;
        this.Type.Validate();
    }

    public BookkeepingAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BookkeepingAccount(BookkeepingAccount bookkeepingAccount)
        : base(bookkeepingAccount) { }
#pragma warning restore CS8618

    public BookkeepingAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BookkeepingAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BookkeepingAccountFromRaw.FromRawUnchecked"/>
    public static BookkeepingAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BookkeepingAccountFromRaw : IFromRawJson<BookkeepingAccount>
{
    /// <inheritdoc/>
    public BookkeepingAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BookkeepingAccount.FromRawUnchecked(rawData);
}

/// <summary>
/// The compliance category of the account.
/// </summary>
[JsonConverter(typeof(BookkeepingAccountComplianceCategoryConverter))]
public enum BookkeepingAccountComplianceCategory
{
    /// <summary>
    /// A cash in an commingled Increase Account.
    /// </summary>
    CommingledCash,

    /// <summary>
    /// A customer balance.
    /// </summary>
    CustomerBalance,
}

sealed class BookkeepingAccountComplianceCategoryConverter
    : JsonConverter<BookkeepingAccountComplianceCategory>
{
    public override BookkeepingAccountComplianceCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "commingled_cash" => BookkeepingAccountComplianceCategory.CommingledCash,
            "customer_balance" => BookkeepingAccountComplianceCategory.CustomerBalance,
            _ => (BookkeepingAccountComplianceCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BookkeepingAccountComplianceCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BookkeepingAccountComplianceCategory.CommingledCash => "commingled_cash",
                BookkeepingAccountComplianceCategory.CustomerBalance => "customer_balance",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `bookkeeping_account`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    BookkeepingAccount,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.BookkeepingAccounts.Type>
{
    public override global::Increase.Api.Models.BookkeepingAccounts.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "bookkeeping_account" => global::Increase
                .Api
                .Models
                .BookkeepingAccounts
                .Type
                .BookkeepingAccount,
            _ => (global::Increase.Api.Models.BookkeepingAccounts.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.BookkeepingAccounts.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.BookkeepingAccounts.Type.BookkeepingAccount =>
                    "bookkeeping_account",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
