using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.AccountTransfers;

/// <summary>
/// Account transfers move funds between your own accounts at Increase (accounting
/// systems often refer to these as Book Transfers). Account Transfers are free and
/// synchronous. Upon creation they create two Transactions, one negative on the originating
/// account and one positive on the destination account (unless the transfer requires
/// approval, in which case the Transactions will be created when the transfer is approved).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccountTransfer, AccountTransferFromRaw>))]
public sealed record class AccountTransfer : JsonModel
{
    /// <summary>
    /// The Account Transfer's identifier.
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
    /// The Account from which the transfer originated.
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
    /// The transfer amount in cents. This will always be positive and indicates
    /// the amount of money leaving the originating account.
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
    /// If your account requires approvals for transfers and the transfer was approved,
    /// this will contain details of the approval.
    /// </summary>
    public required Approval? Approval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Approval>("approval");
        }
        init { this._rawData.Set("approval", value); }
    }

    /// <summary>
    /// If your account requires approvals for transfers and the transfer was not
    /// approved, this will contain details of the cancellation.
    /// </summary>
    public required Cancellation? Cancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Cancellation>("cancellation");
        }
        init { this._rawData.Set("cancellation", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the transfer was created.
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
    /// What object created the transfer, either via the API or the dashboard.
    /// </summary>
    public required CreatedBy? CreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreatedBy>("created_by");
        }
        init { this._rawData.Set("created_by", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transfer's currency.
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// An internal-facing description for the transfer for display in the API and
    /// dashboard. This will also show in the description of the created Transactions.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The destination Account's identifier.
    /// </summary>
    public required string DestinationAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("destination_account_id");
        }
        init { this._rawData.Set("destination_account_id", value); }
    }

    /// <summary>
    /// The identifier of the Transaction on the destination Account representing
    /// the received funds.
    /// </summary>
    public required string? DestinationTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("destination_transaction_id");
        }
        init { this._rawData.Set("destination_transaction_id", value); }
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
    /// The ID for the pending transaction representing the transfer. A pending transaction
    /// is created when the transfer [requires approval](https://increase.com/documentation/transfer-approvals#transfer-approvals)
    /// by someone else in your organization.
    /// </summary>
    public required string? PendingTransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pending_transaction_id");
        }
        init { this._rawData.Set("pending_transaction_id", value); }
    }

    /// <summary>
    /// The lifecycle status of the transfer.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The identifier of the Transaction on the originating account representing
    /// the transferred funds.
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
    /// be `account_transfer`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.AccountTransfers.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.AccountTransfers.Type>
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
        this.Approval?.Validate();
        this.Cancellation?.Validate();
        _ = this.CreatedAt;
        this.CreatedBy?.Validate();
        this.Currency.Validate();
        _ = this.Description;
        _ = this.DestinationAccountID;
        _ = this.DestinationTransactionID;
        _ = this.IdempotencyKey;
        _ = this.PendingTransactionID;
        this.Status.Validate();
        _ = this.TransactionID;
        this.Type.Validate();
    }

    public AccountTransfer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountTransfer(AccountTransfer accountTransfer)
        : base(accountTransfer) { }
#pragma warning restore CS8618

    public AccountTransfer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountTransfer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountTransferFromRaw.FromRawUnchecked"/>
    public static AccountTransfer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountTransferFromRaw : IFromRawJson<AccountTransfer>
{
    /// <inheritdoc/>
    public AccountTransfer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountTransfer.FromRawUnchecked(rawData);
}

/// <summary>
/// If your account requires approvals for transfers and the transfer was approved,
/// this will contain details of the approval.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Approval, ApprovalFromRaw>))]
public sealed record class Approval : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the transfer was approved.
    /// </summary>
    public required System::DateTimeOffset ApprovedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("approved_at");
        }
        init { this._rawData.Set("approved_at", value); }
    }

    /// <summary>
    /// If the Transfer was approved by a user in the dashboard, the email address
    /// of that user.
    /// </summary>
    public required string? ApprovedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("approved_by");
        }
        init { this._rawData.Set("approved_by", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApprovedAt;
        _ = this.ApprovedBy;
    }

    public Approval() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Approval(Approval approval)
        : base(approval) { }
#pragma warning restore CS8618

    public Approval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Approval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApprovalFromRaw.FromRawUnchecked"/>
    public static Approval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApprovalFromRaw : IFromRawJson<Approval>
{
    /// <inheritdoc/>
    public Approval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Approval.FromRawUnchecked(rawData);
}

/// <summary>
/// If your account requires approvals for transfers and the transfer was not approved,
/// this will contain details of the cancellation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Cancellation, CancellationFromRaw>))]
public sealed record class Cancellation : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Transfer was canceled.
    /// </summary>
    public required System::DateTimeOffset CanceledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("canceled_at");
        }
        init { this._rawData.Set("canceled_at", value); }
    }

    /// <summary>
    /// If the Transfer was canceled by a user in the dashboard, the email address
    /// of that user.
    /// </summary>
    public required string? CanceledBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("canceled_by");
        }
        init { this._rawData.Set("canceled_by", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanceledAt;
        _ = this.CanceledBy;
    }

    public Cancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cancellation(Cancellation cancellation)
        : base(cancellation) { }
#pragma warning restore CS8618

    public Cancellation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Cancellation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CancellationFromRaw.FromRawUnchecked"/>
    public static Cancellation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CancellationFromRaw : IFromRawJson<Cancellation>
{
    /// <inheritdoc/>
    public Cancellation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Cancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// What object created the transfer, either via the API or the dashboard.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreatedBy, CreatedByFromRaw>))]
public sealed record class CreatedBy : JsonModel
{
    /// <summary>
    /// The type of object that created this transfer.
    /// </summary>
    public required ApiEnum<string, Category> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Category>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// If present, details about the API key that created the transfer.
    /// </summary>
    public ApiKey? ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiKey>("api_key");
        }
        init { this._rawData.Set("api_key", value); }
    }

    /// <summary>
    /// If present, details about the OAuth Application that created the transfer.
    /// </summary>
    public OAuthApplication? OAuthApplication
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OAuthApplication>("oauth_application");
        }
        init { this._rawData.Set("oauth_application", value); }
    }

    /// <summary>
    /// If present, details about the User that created the transfer.
    /// </summary>
    public User? User
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<User>("user");
        }
        init { this._rawData.Set("user", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.ApiKey?.Validate();
        this.OAuthApplication?.Validate();
        this.User?.Validate();
    }

    public CreatedBy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatedBy(CreatedBy createdBy)
        : base(createdBy) { }
#pragma warning restore CS8618

    public CreatedBy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatedBy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatedByFromRaw.FromRawUnchecked"/>
    public static CreatedBy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CreatedBy(ApiEnum<string, Category> category)
        : this()
    {
        this.Category = category;
    }
}

class CreatedByFromRaw : IFromRawJson<CreatedBy>
{
    /// <inheritdoc/>
    public CreatedBy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreatedBy.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of object that created this transfer.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    /// <summary>
    /// An API key. Details will be under the `api_key` object.
    /// </summary>
    ApiKey,

    /// <summary>
    /// An OAuth application you connected to Increase. Details will be under the
    /// `oauth_application` object.
    /// </summary>
    OAuthApplication,

    /// <summary>
    /// A User in the Increase dashboard. Details will be under the `user` object.
    /// </summary>
    User,
}

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "api_key" => Category.ApiKey,
            "oauth_application" => Category.OAuthApplication,
            "user" => Category.User,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.ApiKey => "api_key",
                Category.OAuthApplication => "oauth_application",
                Category.User => "user",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If present, details about the API key that created the transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ApiKey, ApiKeyFromRaw>))]
public sealed record class ApiKey : JsonModel
{
    /// <summary>
    /// The description set for the API key when it was created.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
    }

    public ApiKey() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKey(ApiKey apiKey)
        : base(apiKey) { }
#pragma warning restore CS8618

    public ApiKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyFromRaw.FromRawUnchecked"/>
    public static ApiKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ApiKey(string? description)
        : this()
    {
        this.Description = description;
    }
}

class ApiKeyFromRaw : IFromRawJson<ApiKey>
{
    /// <inheritdoc/>
    public ApiKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ApiKey.FromRawUnchecked(rawData);
}

/// <summary>
/// If present, details about the OAuth Application that created the transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OAuthApplication, OAuthApplicationFromRaw>))]
public sealed record class OAuthApplication : JsonModel
{
    /// <summary>
    /// The name of the OAuth Application.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public OAuthApplication() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthApplication(OAuthApplication oauthApplication)
        : base(oauthApplication) { }
#pragma warning restore CS8618

    public OAuthApplication(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthApplication(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OAuthApplicationFromRaw.FromRawUnchecked"/>
    public static OAuthApplication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OAuthApplication(string name)
        : this()
    {
        this.Name = name;
    }
}

class OAuthApplicationFromRaw : IFromRawJson<OAuthApplication>
{
    /// <inheritdoc/>
    public OAuthApplication FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OAuthApplication.FromRawUnchecked(rawData);
}

/// <summary>
/// If present, details about the User that created the transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<User, UserFromRaw>))]
public sealed record class User : JsonModel
{
    /// <summary>
    /// The email address of the User.
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
    }

    public User() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public User(User user)
        : base(user) { }
#pragma warning restore CS8618

    public User(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    User(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserFromRaw.FromRawUnchecked"/>
    public static User FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public User(string email)
        : this()
    {
        this.Email = email;
    }
}

class UserFromRaw : IFromRawJson<User>
{
    /// <inheritdoc/>
    public User FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        User.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transfer's currency.
/// </summary>
[JsonConverter(typeof(CurrencyConverter))]
public enum Currency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CurrencyConverter : JsonConverter<Currency>
{
    public override Currency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => Currency.Usd,
            _ => (Currency)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Currency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The lifecycle status of the transfer.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// The transfer is pending approval from your team.
    /// </summary>
    PendingApproval,

    /// <summary>
    /// The transfer was pending approval from your team and has been canceled.
    /// </summary>
    Canceled,

    /// <summary>
    /// The transfer has been completed.
    /// </summary>
    Complete,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_approval" => Status.PendingApproval,
            "canceled" => Status.Canceled,
            "complete" => Status.Complete,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.PendingApproval => "pending_approval",
                Status.Canceled => "canceled",
                Status.Complete => "complete",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `account_transfer`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    AccountTransfer,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.AccountTransfers.Type>
{
    public override global::Increase.Api.Models.AccountTransfers.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_transfer" => global::Increase.Api.Models.AccountTransfers.Type.AccountTransfer,
            _ => (global::Increase.Api.Models.AccountTransfers.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.AccountTransfers.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.AccountTransfers.Type.AccountTransfer =>
                    "account_transfer",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
