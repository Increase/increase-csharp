using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.CheckTransfers;

/// <summary>
/// Check Transfers move funds from your Increase account by mailing a physical check.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CheckTransfer, CheckTransferFromRaw>))]
public sealed record class CheckTransfer : JsonModel
{
    /// <summary>
    /// The Check transfer's identifier.
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
    /// The identifier of the Account from which funds will be transferred.
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
    /// The account number printed on the check.
    /// </summary>
    public required string AccountNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_number");
        }
        init { this._rawData.Set("account_number", value); }
    }

    /// <summary>
    /// The transfer amount in USD cents.
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
    /// If the Check Transfer was successfully deposited, this will contain the identifier
    /// of the Inbound Check Deposit object with details of the deposit.
    /// </summary>
    public required string? ApprovedInboundCheckDepositID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("approved_inbound_check_deposit_id");
        }
        init { this._rawData.Set("approved_inbound_check_deposit_id", value); }
    }

    /// <summary>
    /// How the account's available balance should be checked.
    /// </summary>
    public required ApiEnum<string, CheckTransferBalanceCheck>? BalanceCheck
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CheckTransferBalanceCheck>>(
                "balance_check"
            );
        }
        init { this._rawData.Set("balance_check", value); }
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
    /// The check number printed on the check.
    /// </summary>
    public required string CheckNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("check_number");
        }
        init { this._rawData.Set("check_number", value); }
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the check's currency.
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
    /// Whether Increase will print and mail the check or if you will do it yourself.
    /// </summary>
    public required ApiEnum<string, CheckTransferFulfillmentMethod> FulfillmentMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CheckTransferFulfillmentMethod>>(
                "fulfillment_method"
            );
        }
        init { this._rawData.Set("fulfillment_method", value); }
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
    /// If the check has been mailed by Increase, this will contain details of the shipment.
    /// </summary>
    public required Mailing? Mailing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Mailing>("mailing");
        }
        init { this._rawData.Set("mailing", value); }
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
    /// Details relating to the physical check that Increase will print and mail.
    /// Will be present if and only if `fulfillment_method` is equal to `physical_check`.
    /// </summary>
    public required CheckTransferPhysicalCheck? PhysicalCheck
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckTransferPhysicalCheck>("physical_check");
        }
        init { this._rawData.Set("physical_check", value); }
    }

    /// <summary>
    /// The routing number printed on the check.
    /// </summary>
    public required string RoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("routing_number");
        }
        init { this._rawData.Set("routing_number", value); }
    }

    /// <summary>
    /// The identifier of the Account Number from which to send the transfer and print
    /// on the check.
    /// </summary>
    public required string? SourceAccountNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source_account_number_id");
        }
        init { this._rawData.Set("source_account_number_id", value); }
    }

    /// <summary>
    /// The lifecycle status of the transfer.
    /// </summary>
    public required ApiEnum<string, CheckTransferStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CheckTransferStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// After a stop-payment is requested on the check, this will contain supplemental details.
    /// </summary>
    public required StopPaymentRequest? StopPaymentRequest
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StopPaymentRequest>("stop_payment_request");
        }
        init { this._rawData.Set("stop_payment_request", value); }
    }

    /// <summary>
    /// After the transfer is submitted, this will contain supplemental details.
    /// </summary>
    public required Submission? Submission
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Submission>("submission");
        }
        init { this._rawData.Set("submission", value); }
    }

    /// <summary>
    /// Details relating to the custom fulfillment you will perform. Will be present
    /// if and only if `fulfillment_method` is equal to `third_party`.
    /// </summary>
    public required CheckTransferThirdParty? ThirdParty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckTransferThirdParty>("third_party");
        }
        init { this._rawData.Set("third_party", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `check_transfer`.
    /// </summary>
    public required ApiEnum<string, CheckTransferType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CheckTransferType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// If set, the check will be valid on or before this date. After this date, the
    /// check transfer will be automatically stopped and deposits will not be accepted.
    /// For checks printed by Increase, this date is included on the check as its expiry.
    /// </summary>
    public required string? ValidUntilDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("valid_until_date");
        }
        init { this._rawData.Set("valid_until_date", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.AccountNumber;
        _ = this.Amount;
        this.Approval?.Validate();
        _ = this.ApprovedInboundCheckDepositID;
        this.BalanceCheck?.Validate();
        this.Cancellation?.Validate();
        _ = this.CheckNumber;
        _ = this.CreatedAt;
        this.CreatedBy?.Validate();
        this.Currency.Validate();
        this.FulfillmentMethod.Validate();
        _ = this.IdempotencyKey;
        this.Mailing?.Validate();
        _ = this.PendingTransactionID;
        this.PhysicalCheck?.Validate();
        _ = this.RoutingNumber;
        _ = this.SourceAccountNumberID;
        this.Status.Validate();
        this.StopPaymentRequest?.Validate();
        this.Submission?.Validate();
        this.ThirdParty?.Validate();
        this.Type.Validate();
        _ = this.ValidUntilDate;
    }

    public CheckTransfer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckTransfer(CheckTransfer checkTransfer)
        : base(checkTransfer) { }
#pragma warning restore CS8618

    public CheckTransfer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckTransfer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckTransferFromRaw.FromRawUnchecked"/>
    public static CheckTransfer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckTransferFromRaw : IFromRawJson<CheckTransfer>
{
    /// <inheritdoc/>
    public CheckTransfer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CheckTransfer.FromRawUnchecked(rawData);
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
/// How the account's available balance should be checked.
/// </summary>
[JsonConverter(typeof(CheckTransferBalanceCheckConverter))]
public enum CheckTransferBalanceCheck
{
    /// <summary>
    /// The available balance of the account must be at least the amount of the check,
    /// and a Pending Transaction will be created for the full amount. This is the
    /// default behavior if `balance_check` is omitted.
    /// </summary>
    Full,

    /// <summary>
    /// No balance check will performed when the check transfer is initiated. A zero-dollar
    /// Pending Transaction will be created. The balance will still be checked when
    /// the Inbound Check Deposit is created.
    /// </summary>
    None,
}

sealed class CheckTransferBalanceCheckConverter : JsonConverter<CheckTransferBalanceCheck>
{
    public override CheckTransferBalanceCheck Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "full" => CheckTransferBalanceCheck.Full,
            "none" => CheckTransferBalanceCheck.None,
            _ => (CheckTransferBalanceCheck)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckTransferBalanceCheck value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckTransferBalanceCheck.Full => "full",
                CheckTransferBalanceCheck.None => "none",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
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
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the check's currency.
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
/// Whether Increase will print and mail the check or if you will do it yourself.
/// </summary>
[JsonConverter(typeof(CheckTransferFulfillmentMethodConverter))]
public enum CheckTransferFulfillmentMethod
{
    /// <summary>
    /// Increase will print and mail a physical check.
    /// </summary>
    PhysicalCheck,

    /// <summary>
    /// Increase will not print a check; you are responsible for printing and mailing
    /// a check with the provided account number, routing number, check number, and amount.
    /// </summary>
    ThirdParty,
}

sealed class CheckTransferFulfillmentMethodConverter : JsonConverter<CheckTransferFulfillmentMethod>
{
    public override CheckTransferFulfillmentMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "physical_check" => CheckTransferFulfillmentMethod.PhysicalCheck,
            "third_party" => CheckTransferFulfillmentMethod.ThirdParty,
            _ => (CheckTransferFulfillmentMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckTransferFulfillmentMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckTransferFulfillmentMethod.PhysicalCheck => "physical_check",
                CheckTransferFulfillmentMethod.ThirdParty => "third_party",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If the check has been mailed by Increase, this will contain details of the shipment.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Mailing, MailingFromRaw>))]
public sealed record class Mailing : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the check was mailed.
    /// </summary>
    public required System::DateTimeOffset MailedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("mailed_at");
        }
        init { this._rawData.Set("mailed_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MailedAt;
    }

    public Mailing() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Mailing(Mailing mailing)
        : base(mailing) { }
#pragma warning restore CS8618

    public Mailing(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Mailing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MailingFromRaw.FromRawUnchecked"/>
    public static Mailing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Mailing(System::DateTimeOffset mailedAt)
        : this()
    {
        this.MailedAt = mailedAt;
    }
}

class MailingFromRaw : IFromRawJson<Mailing>
{
    /// <inheritdoc/>
    public Mailing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Mailing.FromRawUnchecked(rawData);
}

/// <summary>
/// Details relating to the physical check that Increase will print and mail. Will
/// be present if and only if `fulfillment_method` is equal to `physical_check`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CheckTransferPhysicalCheck, CheckTransferPhysicalCheckFromRaw>)
)]
public sealed record class CheckTransferPhysicalCheck : JsonModel
{
    /// <summary>
    /// The ID of the file for the check attachment.
    /// </summary>
    public required string? AttachmentFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("attachment_file_id");
        }
        init { this._rawData.Set("attachment_file_id", value); }
    }

    /// <summary>
    /// The ID of the file for the check voucher image.
    /// </summary>
    public required string? CheckVoucherImageFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("check_voucher_image_file_id");
        }
        init { this._rawData.Set("check_voucher_image_file_id", value); }
    }

    /// <summary>
    /// Details for where Increase will mail the check.
    /// </summary>
    public required CheckTransferPhysicalCheckMailingAddress MailingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CheckTransferPhysicalCheckMailingAddress>(
                "mailing_address"
            );
        }
        init { this._rawData.Set("mailing_address", value); }
    }

    /// <summary>
    /// The descriptor that will be printed on the memo field on the check.
    /// </summary>
    public required string? Memo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("memo");
        }
        init { this._rawData.Set("memo", value); }
    }

    /// <summary>
    /// The descriptor that will be printed on the letter included with the check.
    /// </summary>
    public required string? Note
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("note");
        }
        init { this._rawData.Set("note", value); }
    }

    /// <summary>
    /// The payer of the check. This will be printed on the top-left portion of the
    /// check and defaults to the return address if unspecified.
    /// </summary>
    public required IReadOnlyList<CheckTransferPhysicalCheckPayer> Payer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CheckTransferPhysicalCheckPayer>>(
                "payer"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CheckTransferPhysicalCheckPayer>>(
                "payer",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The name that will be printed on the check.
    /// </summary>
    public required string RecipientName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("recipient_name");
        }
        init { this._rawData.Set("recipient_name", value); }
    }

    /// <summary>
    /// The return address to be printed on the check.
    /// </summary>
    public required CheckTransferPhysicalCheckReturnAddress? ReturnAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckTransferPhysicalCheckReturnAddress>(
                "return_address"
            );
        }
        init { this._rawData.Set("return_address", value); }
    }

    /// <summary>
    /// The shipping method for the check.
    /// </summary>
    public required ApiEnum<string, CheckTransferPhysicalCheckShippingMethod>? ShippingMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CheckTransferPhysicalCheckShippingMethod>
            >("shipping_method");
        }
        init { this._rawData.Set("shipping_method", value); }
    }

    /// <summary>
    /// The signature that will appear on the check.
    /// </summary>
    public required CheckTransferPhysicalCheckSignature Signature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CheckTransferPhysicalCheckSignature>("signature");
        }
        init { this._rawData.Set("signature", value); }
    }

    /// <summary>
    /// Tracking updates relating to the physical check's delivery.
    /// </summary>
    public required IReadOnlyList<TrackingUpdate> TrackingUpdates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TrackingUpdate>>(
                "tracking_updates"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TrackingUpdate>>(
                "tracking_updates",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AttachmentFileID;
        _ = this.CheckVoucherImageFileID;
        this.MailingAddress.Validate();
        _ = this.Memo;
        _ = this.Note;
        foreach (var item in this.Payer)
        {
            item.Validate();
        }
        _ = this.RecipientName;
        this.ReturnAddress?.Validate();
        this.ShippingMethod?.Validate();
        this.Signature.Validate();
        foreach (var item in this.TrackingUpdates)
        {
            item.Validate();
        }
    }

    public CheckTransferPhysicalCheck() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckTransferPhysicalCheck(CheckTransferPhysicalCheck checkTransferPhysicalCheck)
        : base(checkTransferPhysicalCheck) { }
#pragma warning restore CS8618

    public CheckTransferPhysicalCheck(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckTransferPhysicalCheck(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckTransferPhysicalCheckFromRaw.FromRawUnchecked"/>
    public static CheckTransferPhysicalCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckTransferPhysicalCheckFromRaw : IFromRawJson<CheckTransferPhysicalCheck>
{
    /// <inheritdoc/>
    public CheckTransferPhysicalCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckTransferPhysicalCheck.FromRawUnchecked(rawData);
}

/// <summary>
/// Details for where Increase will mail the check.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CheckTransferPhysicalCheckMailingAddress,
        CheckTransferPhysicalCheckMailingAddressFromRaw
    >)
)]
public sealed record class CheckTransferPhysicalCheckMailingAddress : JsonModel
{
    /// <summary>
    /// The city of the check's destination.
    /// </summary>
    public required string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The street address of the check's destination.
    /// </summary>
    public required string? Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line1");
        }
        init { this._rawData.Set("line1", value); }
    }

    /// <summary>
    /// The second line of the address of the check's destination.
    /// </summary>
    public required string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init { this._rawData.Set("line2", value); }
    }

    /// <summary>
    /// The name component of the check's mailing address.
    /// </summary>
    public required string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The phone number to be used in case of delivery issues at the check's mailing
    /// address. Only used for FedEx overnight shipping.
    /// </summary>
    public required string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init { this._rawData.Set("phone", value); }
    }

    /// <summary>
    /// The postal code of the check's destination.
    /// </summary>
    public required string? PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <summary>
    /// The state of the check's destination.
    /// </summary>
    public required string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.Name;
        _ = this.Phone;
        _ = this.PostalCode;
        _ = this.State;
    }

    public CheckTransferPhysicalCheckMailingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckTransferPhysicalCheckMailingAddress(
        CheckTransferPhysicalCheckMailingAddress checkTransferPhysicalCheckMailingAddress
    )
        : base(checkTransferPhysicalCheckMailingAddress) { }
#pragma warning restore CS8618

    public CheckTransferPhysicalCheckMailingAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckTransferPhysicalCheckMailingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckTransferPhysicalCheckMailingAddressFromRaw.FromRawUnchecked"/>
    public static CheckTransferPhysicalCheckMailingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckTransferPhysicalCheckMailingAddressFromRaw
    : IFromRawJson<CheckTransferPhysicalCheckMailingAddress>
{
    /// <inheritdoc/>
    public CheckTransferPhysicalCheckMailingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckTransferPhysicalCheckMailingAddress.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CheckTransferPhysicalCheckPayer,
        CheckTransferPhysicalCheckPayerFromRaw
    >)
)]
public sealed record class CheckTransferPhysicalCheckPayer : JsonModel
{
    /// <summary>
    /// The contents of the line.
    /// </summary>
    public required string Contents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("contents");
        }
        init { this._rawData.Set("contents", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Contents;
    }

    public CheckTransferPhysicalCheckPayer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckTransferPhysicalCheckPayer(
        CheckTransferPhysicalCheckPayer checkTransferPhysicalCheckPayer
    )
        : base(checkTransferPhysicalCheckPayer) { }
#pragma warning restore CS8618

    public CheckTransferPhysicalCheckPayer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckTransferPhysicalCheckPayer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckTransferPhysicalCheckPayerFromRaw.FromRawUnchecked"/>
    public static CheckTransferPhysicalCheckPayer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CheckTransferPhysicalCheckPayer(string contents)
        : this()
    {
        this.Contents = contents;
    }
}

class CheckTransferPhysicalCheckPayerFromRaw : IFromRawJson<CheckTransferPhysicalCheckPayer>
{
    /// <inheritdoc/>
    public CheckTransferPhysicalCheckPayer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckTransferPhysicalCheckPayer.FromRawUnchecked(rawData);
}

/// <summary>
/// The return address to be printed on the check.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CheckTransferPhysicalCheckReturnAddress,
        CheckTransferPhysicalCheckReturnAddressFromRaw
    >)
)]
public sealed record class CheckTransferPhysicalCheckReturnAddress : JsonModel
{
    /// <summary>
    /// The city of the check's destination.
    /// </summary>
    public required string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The street address of the check's destination.
    /// </summary>
    public required string? Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line1");
        }
        init { this._rawData.Set("line1", value); }
    }

    /// <summary>
    /// The second line of the address of the check's destination.
    /// </summary>
    public required string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init { this._rawData.Set("line2", value); }
    }

    /// <summary>
    /// The name component of the check's return address.
    /// </summary>
    public required string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The shipper's phone number to be used in case of delivery issues. Only used
    /// for FedEx overnight shipping.
    /// </summary>
    public required string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init { this._rawData.Set("phone", value); }
    }

    /// <summary>
    /// The postal code of the check's destination.
    /// </summary>
    public required string? PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <summary>
    /// The state of the check's destination.
    /// </summary>
    public required string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.Name;
        _ = this.Phone;
        _ = this.PostalCode;
        _ = this.State;
    }

    public CheckTransferPhysicalCheckReturnAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckTransferPhysicalCheckReturnAddress(
        CheckTransferPhysicalCheckReturnAddress checkTransferPhysicalCheckReturnAddress
    )
        : base(checkTransferPhysicalCheckReturnAddress) { }
#pragma warning restore CS8618

    public CheckTransferPhysicalCheckReturnAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckTransferPhysicalCheckReturnAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckTransferPhysicalCheckReturnAddressFromRaw.FromRawUnchecked"/>
    public static CheckTransferPhysicalCheckReturnAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckTransferPhysicalCheckReturnAddressFromRaw
    : IFromRawJson<CheckTransferPhysicalCheckReturnAddress>
{
    /// <inheritdoc/>
    public CheckTransferPhysicalCheckReturnAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckTransferPhysicalCheckReturnAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The shipping method for the check.
/// </summary>
[JsonConverter(typeof(CheckTransferPhysicalCheckShippingMethodConverter))]
public enum CheckTransferPhysicalCheckShippingMethod
{
    /// <summary>
    /// USPS First Class
    /// </summary>
    UspsFirstClass,

    /// <summary>
    /// FedEx Overnight
    /// </summary>
    FedexOvernight,
}

sealed class CheckTransferPhysicalCheckShippingMethodConverter
    : JsonConverter<CheckTransferPhysicalCheckShippingMethod>
{
    public override CheckTransferPhysicalCheckShippingMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usps_first_class" => CheckTransferPhysicalCheckShippingMethod.UspsFirstClass,
            "fedex_overnight" => CheckTransferPhysicalCheckShippingMethod.FedexOvernight,
            _ => (CheckTransferPhysicalCheckShippingMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckTransferPhysicalCheckShippingMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckTransferPhysicalCheckShippingMethod.UspsFirstClass => "usps_first_class",
                CheckTransferPhysicalCheckShippingMethod.FedexOvernight => "fedex_overnight",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The signature that will appear on the check.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CheckTransferPhysicalCheckSignature,
        CheckTransferPhysicalCheckSignatureFromRaw
    >)
)]
public sealed record class CheckTransferPhysicalCheckSignature : JsonModel
{
    /// <summary>
    /// The ID of a File containing a PNG of the signature.
    /// </summary>
    public required string? ImageFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("image_file_id");
        }
        init { this._rawData.Set("image_file_id", value); }
    }

    /// <summary>
    /// The text that will appear as the signature on the check in cursive font.
    /// </summary>
    public required string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ImageFileID;
        _ = this.Text;
    }

    public CheckTransferPhysicalCheckSignature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckTransferPhysicalCheckSignature(
        CheckTransferPhysicalCheckSignature checkTransferPhysicalCheckSignature
    )
        : base(checkTransferPhysicalCheckSignature) { }
#pragma warning restore CS8618

    public CheckTransferPhysicalCheckSignature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckTransferPhysicalCheckSignature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckTransferPhysicalCheckSignatureFromRaw.FromRawUnchecked"/>
    public static CheckTransferPhysicalCheckSignature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckTransferPhysicalCheckSignatureFromRaw : IFromRawJson<CheckTransferPhysicalCheckSignature>
{
    /// <inheritdoc/>
    public CheckTransferPhysicalCheckSignature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckTransferPhysicalCheckSignature.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TrackingUpdate, TrackingUpdateFromRaw>))]
public sealed record class TrackingUpdate : JsonModel
{
    /// <summary>
    /// The type of tracking event.
    /// </summary>
    public required ApiEnum<string, TrackingUpdateCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TrackingUpdateCategory>>(
                "category"
            );
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// The ISO 3166-1 alpha-2 country code for the country where the event took place.
    /// </summary>
    public required string Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the tracking event took place.
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
    /// The postal code where the event took place.
    /// </summary>
    public required string PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        _ = this.Country;
        _ = this.CreatedAt;
        _ = this.PostalCode;
    }

    public TrackingUpdate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrackingUpdate(TrackingUpdate trackingUpdate)
        : base(trackingUpdate) { }
#pragma warning restore CS8618

    public TrackingUpdate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrackingUpdate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrackingUpdateFromRaw.FromRawUnchecked"/>
    public static TrackingUpdate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrackingUpdateFromRaw : IFromRawJson<TrackingUpdate>
{
    /// <inheritdoc/>
    public TrackingUpdate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TrackingUpdate.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of tracking event.
/// </summary>
[JsonConverter(typeof(TrackingUpdateCategoryConverter))]
public enum TrackingUpdateCategory
{
    /// <summary>
    /// The check is in transit.
    /// </summary>
    InTransit,

    /// <summary>
    /// The check has been processed for delivery.
    /// </summary>
    ProcessedForDelivery,

    /// <summary>
    /// The check has been delivered.
    /// </summary>
    Delivered,

    /// <summary>
    /// There is an issue preventing delivery. The delivery will be attempted again
    /// if possible. If the issue cannot be resolved, the check will be returned to sender.
    /// </summary>
    DeliveryIssue,

    /// <summary>
    /// Delivery failed and the check was returned to sender.
    /// </summary>
    ReturnedToSender,
}

sealed class TrackingUpdateCategoryConverter : JsonConverter<TrackingUpdateCategory>
{
    public override TrackingUpdateCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in_transit" => TrackingUpdateCategory.InTransit,
            "processed_for_delivery" => TrackingUpdateCategory.ProcessedForDelivery,
            "delivered" => TrackingUpdateCategory.Delivered,
            "delivery_issue" => TrackingUpdateCategory.DeliveryIssue,
            "returned_to_sender" => TrackingUpdateCategory.ReturnedToSender,
            _ => (TrackingUpdateCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrackingUpdateCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TrackingUpdateCategory.InTransit => "in_transit",
                TrackingUpdateCategory.ProcessedForDelivery => "processed_for_delivery",
                TrackingUpdateCategory.Delivered => "delivered",
                TrackingUpdateCategory.DeliveryIssue => "delivery_issue",
                TrackingUpdateCategory.ReturnedToSender => "returned_to_sender",
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
[JsonConverter(typeof(CheckTransferStatusConverter))]
public enum CheckTransferStatus
{
    /// <summary>
    /// The transfer is awaiting approval.
    /// </summary>
    PendingApproval,

    /// <summary>
    /// The transfer has been canceled.
    /// </summary>
    Canceled,

    /// <summary>
    /// The transfer is pending submission.
    /// </summary>
    PendingSubmission,

    /// <summary>
    /// The transfer requires attention from an Increase operator.
    /// </summary>
    RequiresAttention,

    /// <summary>
    /// The transfer has been rejected.
    /// </summary>
    Rejected,

    /// <summary>
    /// The check is queued for mailing.
    /// </summary>
    PendingMailing,

    /// <summary>
    /// The check has been mailed.
    /// </summary>
    Mailed,

    /// <summary>
    /// The check has been deposited.
    /// </summary>
    Deposited,

    /// <summary>
    /// A stop-payment was requested for this check.
    /// </summary>
    Stopped,

    /// <summary>
    /// The transfer has been returned.
    /// </summary>
    Returned,
}

sealed class CheckTransferStatusConverter : JsonConverter<CheckTransferStatus>
{
    public override CheckTransferStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_approval" => CheckTransferStatus.PendingApproval,
            "canceled" => CheckTransferStatus.Canceled,
            "pending_submission" => CheckTransferStatus.PendingSubmission,
            "requires_attention" => CheckTransferStatus.RequiresAttention,
            "rejected" => CheckTransferStatus.Rejected,
            "pending_mailing" => CheckTransferStatus.PendingMailing,
            "mailed" => CheckTransferStatus.Mailed,
            "deposited" => CheckTransferStatus.Deposited,
            "stopped" => CheckTransferStatus.Stopped,
            "returned" => CheckTransferStatus.Returned,
            _ => (CheckTransferStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckTransferStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckTransferStatus.PendingApproval => "pending_approval",
                CheckTransferStatus.Canceled => "canceled",
                CheckTransferStatus.PendingSubmission => "pending_submission",
                CheckTransferStatus.RequiresAttention => "requires_attention",
                CheckTransferStatus.Rejected => "rejected",
                CheckTransferStatus.PendingMailing => "pending_mailing",
                CheckTransferStatus.Mailed => "mailed",
                CheckTransferStatus.Deposited => "deposited",
                CheckTransferStatus.Stopped => "stopped",
                CheckTransferStatus.Returned => "returned",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// After a stop-payment is requested on the check, this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StopPaymentRequest, StopPaymentRequestFromRaw>))]
public sealed record class StopPaymentRequest : JsonModel
{
    /// <summary>
    /// The reason why this transfer was stopped.
    /// </summary>
    public required ApiEnum<string, StopPaymentRequestReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, StopPaymentRequestReason>>(
                "reason"
            );
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The time the stop-payment was requested.
    /// </summary>
    public required System::DateTimeOffset RequestedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("requested_at");
        }
        init { this._rawData.Set("requested_at", value); }
    }

    /// <summary>
    /// The ID of the check transfer that was stopped.
    /// </summary>
    public required string TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transfer_id");
        }
        init { this._rawData.Set("transfer_id", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `check_transfer_stop_payment_request`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.CheckTransfers.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.CheckTransfers.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Reason.Validate();
        _ = this.RequestedAt;
        _ = this.TransferID;
        this.Type.Validate();
    }

    public StopPaymentRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StopPaymentRequest(StopPaymentRequest stopPaymentRequest)
        : base(stopPaymentRequest) { }
#pragma warning restore CS8618

    public StopPaymentRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StopPaymentRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StopPaymentRequestFromRaw.FromRawUnchecked"/>
    public static StopPaymentRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StopPaymentRequestFromRaw : IFromRawJson<StopPaymentRequest>
{
    /// <inheritdoc/>
    public StopPaymentRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StopPaymentRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason why this transfer was stopped.
/// </summary>
[JsonConverter(typeof(StopPaymentRequestReasonConverter))]
public enum StopPaymentRequestReason
{
    /// <summary>
    /// The check could not be delivered.
    /// </summary>
    MailDeliveryFailed,

    /// <summary>
    /// The check was canceled by an Increase operator who will provide details out-of-band.
    /// </summary>
    RejectedByIncrease,

    /// <summary>
    /// The check was not authorized.
    /// </summary>
    NotAuthorized,

    /// <summary>
    /// The check was stopped for `valid_until_date` being in the past.
    /// </summary>
    ValidUntilDatePassed,

    /// <summary>
    /// The check was stopped for another reason.
    /// </summary>
    Unknown,
}

sealed class StopPaymentRequestReasonConverter : JsonConverter<StopPaymentRequestReason>
{
    public override StopPaymentRequestReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mail_delivery_failed" => StopPaymentRequestReason.MailDeliveryFailed,
            "rejected_by_increase" => StopPaymentRequestReason.RejectedByIncrease,
            "not_authorized" => StopPaymentRequestReason.NotAuthorized,
            "valid_until_date_passed" => StopPaymentRequestReason.ValidUntilDatePassed,
            "unknown" => StopPaymentRequestReason.Unknown,
            _ => (StopPaymentRequestReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StopPaymentRequestReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StopPaymentRequestReason.MailDeliveryFailed => "mail_delivery_failed",
                StopPaymentRequestReason.RejectedByIncrease => "rejected_by_increase",
                StopPaymentRequestReason.NotAuthorized => "not_authorized",
                StopPaymentRequestReason.ValidUntilDatePassed => "valid_until_date_passed",
                StopPaymentRequestReason.Unknown => "unknown",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `check_transfer_stop_payment_request`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    CheckTransferStopPaymentRequest,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.CheckTransfers.Type>
{
    public override global::Increase.Api.Models.CheckTransfers.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "check_transfer_stop_payment_request" => global::Increase
                .Api
                .Models
                .CheckTransfers
                .Type
                .CheckTransferStopPaymentRequest,
            _ => (global::Increase.Api.Models.CheckTransfers.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.CheckTransfers.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.CheckTransfers.Type.CheckTransferStopPaymentRequest =>
                    "check_transfer_stop_payment_request",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// After the transfer is submitted, this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Submission, SubmissionFromRaw>))]
public sealed record class Submission : JsonModel
{
    /// <summary>
    /// The ID of the file corresponding to an image of the check that was mailed,
    /// if available.
    /// </summary>
    public required string? PreviewFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("preview_file_id");
        }
        init { this._rawData.Set("preview_file_id", value); }
    }

    /// <summary>
    /// The address we submitted to the printer. This is what is physically printed
    /// on the check.
    /// </summary>
    public required SubmittedAddress SubmittedAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SubmittedAddress>("submitted_address");
        }
        init { this._rawData.Set("submitted_address", value); }
    }

    /// <summary>
    /// When this check was submitted to our check printer.
    /// </summary>
    public required System::DateTimeOffset SubmittedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("submitted_at");
        }
        init { this._rawData.Set("submitted_at", value); }
    }

    /// <summary>
    /// The tracking number for the check shipment.
    /// </summary>
    public required string? TrackingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tracking_number");
        }
        init { this._rawData.Set("tracking_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PreviewFileID;
        this.SubmittedAddress.Validate();
        _ = this.SubmittedAt;
        _ = this.TrackingNumber;
    }

    public Submission() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Submission(Submission submission)
        : base(submission) { }
#pragma warning restore CS8618

    public Submission(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Submission(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubmissionFromRaw.FromRawUnchecked"/>
    public static Submission FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubmissionFromRaw : IFromRawJson<Submission>
{
    /// <inheritdoc/>
    public Submission FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Submission.FromRawUnchecked(rawData);
}

/// <summary>
/// The address we submitted to the printer. This is what is physically printed on
/// the check.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SubmittedAddress, SubmittedAddressFromRaw>))]
public sealed record class SubmittedAddress : JsonModel
{
    /// <summary>
    /// The submitted address city.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The submitted address line 1.
    /// </summary>
    public required string Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("line1");
        }
        init { this._rawData.Set("line1", value); }
    }

    /// <summary>
    /// The submitted address line 2.
    /// </summary>
    public required string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init { this._rawData.Set("line2", value); }
    }

    /// <summary>
    /// The submitted recipient name.
    /// </summary>
    public required string RecipientName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("recipient_name");
        }
        init { this._rawData.Set("recipient_name", value); }
    }

    /// <summary>
    /// The submitted address state.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The submitted address zip.
    /// </summary>
    public required string Zip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("zip");
        }
        init { this._rawData.Set("zip", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.RecipientName;
        _ = this.State;
        _ = this.Zip;
    }

    public SubmittedAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubmittedAddress(SubmittedAddress submittedAddress)
        : base(submittedAddress) { }
#pragma warning restore CS8618

    public SubmittedAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubmittedAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubmittedAddressFromRaw.FromRawUnchecked"/>
    public static SubmittedAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubmittedAddressFromRaw : IFromRawJson<SubmittedAddress>
{
    /// <inheritdoc/>
    public SubmittedAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SubmittedAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Details relating to the custom fulfillment you will perform. Will be present
/// if and only if `fulfillment_method` is equal to `third_party`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CheckTransferThirdParty, CheckTransferThirdPartyFromRaw>))]
public sealed record class CheckTransferThirdParty : JsonModel
{
    /// <summary>
    /// The name that you will print on the check.
    /// </summary>
    public required string? RecipientName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recipient_name");
        }
        init { this._rawData.Set("recipient_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecipientName;
    }

    public CheckTransferThirdParty() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckTransferThirdParty(CheckTransferThirdParty checkTransferThirdParty)
        : base(checkTransferThirdParty) { }
#pragma warning restore CS8618

    public CheckTransferThirdParty(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckTransferThirdParty(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckTransferThirdPartyFromRaw.FromRawUnchecked"/>
    public static CheckTransferThirdParty FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CheckTransferThirdParty(string? recipientName)
        : this()
    {
        this.RecipientName = recipientName;
    }
}

class CheckTransferThirdPartyFromRaw : IFromRawJson<CheckTransferThirdParty>
{
    /// <inheritdoc/>
    public CheckTransferThirdParty FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckTransferThirdParty.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `check_transfer`.
/// </summary>
[JsonConverter(typeof(CheckTransferTypeConverter))]
public enum CheckTransferType
{
    CheckTransfer,
}

sealed class CheckTransferTypeConverter : JsonConverter<CheckTransferType>
{
    public override CheckTransferType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "check_transfer" => CheckTransferType.CheckTransfer,
            _ => (CheckTransferType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckTransferType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckTransferType.CheckTransfer => "check_transfer",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
