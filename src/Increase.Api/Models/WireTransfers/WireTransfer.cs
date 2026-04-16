using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.WireTransfers;

/// <summary>
/// Wire transfers move funds between your Increase account and any other account
/// accessible by Fedwire.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WireTransfer, WireTransferFromRaw>))]
public sealed record class WireTransfer : JsonModel
{
    /// <summary>
    /// The wire transfer's identifier.
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
    /// The Account to which the transfer belongs.
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
    /// The destination account number.
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
    /// The person or business that is receiving the funds from the transfer.
    /// </summary>
    public required WireTransferCreditor? Creditor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WireTransferCreditor>("creditor");
        }
        init { this._rawData.Set("creditor", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transfer's
    /// currency. For wire transfers this is always equal to `usd`.
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
    /// The person or business whose funds are being transferred.
    /// </summary>
    public required WireTransferDebtor? Debtor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WireTransferDebtor>("debtor");
        }
        init { this._rawData.Set("debtor", value); }
    }

    /// <summary>
    /// The identifier of the External Account the transfer was made to, if any.
    /// </summary>
    public required string? ExternalAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_account_id");
        }
        init { this._rawData.Set("external_account_id", value); }
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
    /// The ID of an Inbound Wire Drawdown Request in response to which this transfer
    /// was sent.
    /// </summary>
    public required string? InboundWireDrawdownRequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inbound_wire_drawdown_request_id");
        }
        init { this._rawData.Set("inbound_wire_drawdown_request_id", value); }
    }

    /// <summary>
    /// The transfer's network.
    /// </summary>
    public required ApiEnum<string, Network> Network
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Network>>("network");
        }
        init { this._rawData.Set("network", value); }
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
    /// Remittance information sent with the wire transfer.
    /// </summary>
    public required WireTransferRemittance? Remittance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WireTransferRemittance>("remittance");
        }
        init { this._rawData.Set("remittance", value); }
    }

    /// <summary>
    /// If your transfer is reversed, this will contain details of the reversal.
    /// </summary>
    public required Reversal? Reversal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Reversal>("reversal");
        }
        init { this._rawData.Set("reversal", value); }
    }

    /// <summary>
    /// The American Bankers' Association (ABA) Routing Transit Number (RTN).
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
    /// The Account Number that was passed to the wire's recipient.
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
    public required ApiEnum<string, WireTransferStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WireTransferStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// After the transfer is submitted to Fedwire, this will contain supplemental details.
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
    /// The ID for the transaction funding the transfer.
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
    /// be `wire_transfer`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.WireTransfers.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.WireTransfers.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The unique end-to-end transaction reference ([UETR](https://www.swift.com/payments/what-unique-end-end-transaction-reference-uetr))
    /// of the transfer.
    /// </summary>
    public required string? UniqueEndToEndTransactionReference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "unique_end_to_end_transaction_reference"
            );
        }
        init { this._rawData.Set("unique_end_to_end_transaction_reference", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.AccountNumber;
        _ = this.Amount;
        this.Approval?.Validate();
        this.Cancellation?.Validate();
        _ = this.CreatedAt;
        this.CreatedBy?.Validate();
        this.Creditor?.Validate();
        this.Currency.Validate();
        this.Debtor?.Validate();
        _ = this.ExternalAccountID;
        _ = this.IdempotencyKey;
        _ = this.InboundWireDrawdownRequestID;
        this.Network.Validate();
        _ = this.PendingTransactionID;
        this.Remittance?.Validate();
        this.Reversal?.Validate();
        _ = this.RoutingNumber;
        _ = this.SourceAccountNumberID;
        this.Status.Validate();
        this.Submission?.Validate();
        _ = this.TransactionID;
        this.Type.Validate();
        _ = this.UniqueEndToEndTransactionReference;
    }

    public WireTransfer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireTransfer(WireTransfer wireTransfer)
        : base(wireTransfer) { }
#pragma warning restore CS8618

    public WireTransfer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireTransfer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireTransferFromRaw.FromRawUnchecked"/>
    public static WireTransfer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WireTransferFromRaw : IFromRawJson<WireTransfer>
{
    /// <inheritdoc/>
    public WireTransfer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WireTransfer.FromRawUnchecked(rawData);
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
    public required ApiEnum<string, CreatedByCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CreatedByCategory>>("category");
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
    public CreatedBy(ApiEnum<string, CreatedByCategory> category)
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
[JsonConverter(typeof(CreatedByCategoryConverter))]
public enum CreatedByCategory
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

sealed class CreatedByCategoryConverter : JsonConverter<CreatedByCategory>
{
    public override CreatedByCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "api_key" => CreatedByCategory.ApiKey,
            "oauth_application" => CreatedByCategory.OAuthApplication,
            "user" => CreatedByCategory.User,
            _ => (CreatedByCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreatedByCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreatedByCategory.ApiKey => "api_key",
                CreatedByCategory.OAuthApplication => "oauth_application",
                CreatedByCategory.User => "user",
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
/// The person or business that is receiving the funds from the transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WireTransferCreditor, WireTransferCreditorFromRaw>))]
public sealed record class WireTransferCreditor : JsonModel
{
    /// <summary>
    /// The person or business's address.
    /// </summary>
    public required WireTransferCreditorAddress? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WireTransferCreditorAddress>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// The person or business's name.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address?.Validate();
        _ = this.Name;
    }

    public WireTransferCreditor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireTransferCreditor(WireTransferCreditor wireTransferCreditor)
        : base(wireTransferCreditor) { }
#pragma warning restore CS8618

    public WireTransferCreditor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireTransferCreditor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireTransferCreditorFromRaw.FromRawUnchecked"/>
    public static WireTransferCreditor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WireTransferCreditorFromRaw : IFromRawJson<WireTransferCreditor>
{
    /// <inheritdoc/>
    public WireTransferCreditor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WireTransferCreditor.FromRawUnchecked(rawData);
}

/// <summary>
/// The person or business's address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WireTransferCreditorAddress, WireTransferCreditorAddressFromRaw>)
)]
public sealed record class WireTransferCreditorAddress : JsonModel
{
    /// <summary>
    /// Unstructured address lines.
    /// </summary>
    public required WireTransferCreditorAddressUnstructured? Unstructured
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WireTransferCreditorAddressUnstructured>(
                "unstructured"
            );
        }
        init { this._rawData.Set("unstructured", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Unstructured?.Validate();
    }

    public WireTransferCreditorAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireTransferCreditorAddress(WireTransferCreditorAddress wireTransferCreditorAddress)
        : base(wireTransferCreditorAddress) { }
#pragma warning restore CS8618

    public WireTransferCreditorAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireTransferCreditorAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireTransferCreditorAddressFromRaw.FromRawUnchecked"/>
    public static WireTransferCreditorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WireTransferCreditorAddress(WireTransferCreditorAddressUnstructured? unstructured)
        : this()
    {
        this.Unstructured = unstructured;
    }
}

class WireTransferCreditorAddressFromRaw : IFromRawJson<WireTransferCreditorAddress>
{
    /// <inheritdoc/>
    public WireTransferCreditorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WireTransferCreditorAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Unstructured address lines.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WireTransferCreditorAddressUnstructured,
        WireTransferCreditorAddressUnstructuredFromRaw
    >)
)]
public sealed record class WireTransferCreditorAddressUnstructured : JsonModel
{
    /// <summary>
    /// The first line.
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
    /// The second line.
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
    /// The third line.
    /// </summary>
    public required string? Line3
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line3");
        }
        init { this._rawData.Set("line3", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Line1;
        _ = this.Line2;
        _ = this.Line3;
    }

    public WireTransferCreditorAddressUnstructured() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireTransferCreditorAddressUnstructured(
        WireTransferCreditorAddressUnstructured wireTransferCreditorAddressUnstructured
    )
        : base(wireTransferCreditorAddressUnstructured) { }
#pragma warning restore CS8618

    public WireTransferCreditorAddressUnstructured(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireTransferCreditorAddressUnstructured(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireTransferCreditorAddressUnstructuredFromRaw.FromRawUnchecked"/>
    public static WireTransferCreditorAddressUnstructured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WireTransferCreditorAddressUnstructuredFromRaw
    : IFromRawJson<WireTransferCreditorAddressUnstructured>
{
    /// <inheritdoc/>
    public WireTransferCreditorAddressUnstructured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WireTransferCreditorAddressUnstructured.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transfer's
/// currency. For wire transfers this is always equal to `usd`.
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
/// The person or business whose funds are being transferred.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WireTransferDebtor, WireTransferDebtorFromRaw>))]
public sealed record class WireTransferDebtor : JsonModel
{
    /// <summary>
    /// The person or business's address.
    /// </summary>
    public required WireTransferDebtorAddress? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WireTransferDebtorAddress>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// The person or business's name.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address?.Validate();
        _ = this.Name;
    }

    public WireTransferDebtor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireTransferDebtor(WireTransferDebtor wireTransferDebtor)
        : base(wireTransferDebtor) { }
#pragma warning restore CS8618

    public WireTransferDebtor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireTransferDebtor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireTransferDebtorFromRaw.FromRawUnchecked"/>
    public static WireTransferDebtor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WireTransferDebtorFromRaw : IFromRawJson<WireTransferDebtor>
{
    /// <inheritdoc/>
    public WireTransferDebtor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WireTransferDebtor.FromRawUnchecked(rawData);
}

/// <summary>
/// The person or business's address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WireTransferDebtorAddress, WireTransferDebtorAddressFromRaw>)
)]
public sealed record class WireTransferDebtorAddress : JsonModel
{
    /// <summary>
    /// Unstructured address lines.
    /// </summary>
    public required WireTransferDebtorAddressUnstructured? Unstructured
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WireTransferDebtorAddressUnstructured>(
                "unstructured"
            );
        }
        init { this._rawData.Set("unstructured", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Unstructured?.Validate();
    }

    public WireTransferDebtorAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireTransferDebtorAddress(WireTransferDebtorAddress wireTransferDebtorAddress)
        : base(wireTransferDebtorAddress) { }
#pragma warning restore CS8618

    public WireTransferDebtorAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireTransferDebtorAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireTransferDebtorAddressFromRaw.FromRawUnchecked"/>
    public static WireTransferDebtorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WireTransferDebtorAddress(WireTransferDebtorAddressUnstructured? unstructured)
        : this()
    {
        this.Unstructured = unstructured;
    }
}

class WireTransferDebtorAddressFromRaw : IFromRawJson<WireTransferDebtorAddress>
{
    /// <inheritdoc/>
    public WireTransferDebtorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WireTransferDebtorAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Unstructured address lines.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WireTransferDebtorAddressUnstructured,
        WireTransferDebtorAddressUnstructuredFromRaw
    >)
)]
public sealed record class WireTransferDebtorAddressUnstructured : JsonModel
{
    /// <summary>
    /// The first line.
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
    /// The second line.
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
    /// The third line.
    /// </summary>
    public required string? Line3
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line3");
        }
        init { this._rawData.Set("line3", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Line1;
        _ = this.Line2;
        _ = this.Line3;
    }

    public WireTransferDebtorAddressUnstructured() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireTransferDebtorAddressUnstructured(
        WireTransferDebtorAddressUnstructured wireTransferDebtorAddressUnstructured
    )
        : base(wireTransferDebtorAddressUnstructured) { }
#pragma warning restore CS8618

    public WireTransferDebtorAddressUnstructured(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireTransferDebtorAddressUnstructured(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireTransferDebtorAddressUnstructuredFromRaw.FromRawUnchecked"/>
    public static WireTransferDebtorAddressUnstructured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WireTransferDebtorAddressUnstructuredFromRaw
    : IFromRawJson<WireTransferDebtorAddressUnstructured>
{
    /// <inheritdoc/>
    public WireTransferDebtorAddressUnstructured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WireTransferDebtorAddressUnstructured.FromRawUnchecked(rawData);
}

/// <summary>
/// The transfer's network.
/// </summary>
[JsonConverter(typeof(NetworkConverter))]
public enum Network
{
    Wire,
}

sealed class NetworkConverter : JsonConverter<Network>
{
    public override Network Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "wire" => Network.Wire,
            _ => (Network)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Network value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Network.Wire => "wire",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Remittance information sent with the wire transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WireTransferRemittance, WireTransferRemittanceFromRaw>))]
public sealed record class WireTransferRemittance : JsonModel
{
    /// <summary>
    /// The type of remittance information being passed.
    /// </summary>
    public required ApiEnum<string, WireTransferRemittanceCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WireTransferRemittanceCategory>>(
                "category"
            );
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Internal Revenue Service (IRS) tax repayment information. Required if `category`
    /// is equal to `tax`.
    /// </summary>
    public WireTransferRemittanceTax? Tax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WireTransferRemittanceTax>("tax");
        }
        init { this._rawData.Set("tax", value); }
    }

    /// <summary>
    /// Unstructured remittance information. Required if `category` is equal to `unstructured`.
    /// </summary>
    public WireTransferRemittanceUnstructured? Unstructured
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WireTransferRemittanceUnstructured>(
                "unstructured"
            );
        }
        init { this._rawData.Set("unstructured", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.Tax?.Validate();
        this.Unstructured?.Validate();
    }

    public WireTransferRemittance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireTransferRemittance(WireTransferRemittance wireTransferRemittance)
        : base(wireTransferRemittance) { }
#pragma warning restore CS8618

    public WireTransferRemittance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireTransferRemittance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireTransferRemittanceFromRaw.FromRawUnchecked"/>
    public static WireTransferRemittance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WireTransferRemittance(ApiEnum<string, WireTransferRemittanceCategory> category)
        : this()
    {
        this.Category = category;
    }
}

class WireTransferRemittanceFromRaw : IFromRawJson<WireTransferRemittance>
{
    /// <inheritdoc/>
    public WireTransferRemittance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WireTransferRemittance.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of remittance information being passed.
/// </summary>
[JsonConverter(typeof(WireTransferRemittanceCategoryConverter))]
public enum WireTransferRemittanceCategory
{
    /// <summary>
    /// The wire transfer contains unstructured remittance information.
    /// </summary>
    Unstructured,

    /// <summary>
    /// The wire transfer is for tax payment purposes to the Internal Revenue Service (IRS).
    /// </summary>
    Tax,
}

sealed class WireTransferRemittanceCategoryConverter : JsonConverter<WireTransferRemittanceCategory>
{
    public override WireTransferRemittanceCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unstructured" => WireTransferRemittanceCategory.Unstructured,
            "tax" => WireTransferRemittanceCategory.Tax,
            _ => (WireTransferRemittanceCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WireTransferRemittanceCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WireTransferRemittanceCategory.Unstructured => "unstructured",
                WireTransferRemittanceCategory.Tax => "tax",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Internal Revenue Service (IRS) tax repayment information. Required if `category`
/// is equal to `tax`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WireTransferRemittanceTax, WireTransferRemittanceTaxFromRaw>)
)]
public sealed record class WireTransferRemittanceTax : JsonModel
{
    /// <summary>
    /// The month and year the tax payment is for, in YYYY-MM-DD format. The day
    /// is ignored.
    /// </summary>
    public required string Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("date");
        }
        init { this._rawData.Set("date", value); }
    }

    /// <summary>
    /// The 9-digit Tax Identification Number (TIN) or Employer Identification Number (EIN).
    /// </summary>
    public required string IdentificationNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("identification_number");
        }
        init { this._rawData.Set("identification_number", value); }
    }

    /// <summary>
    /// The 5-character tax type code.
    /// </summary>
    public required string TypeCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type_code");
        }
        init { this._rawData.Set("type_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Date;
        _ = this.IdentificationNumber;
        _ = this.TypeCode;
    }

    public WireTransferRemittanceTax() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireTransferRemittanceTax(WireTransferRemittanceTax wireTransferRemittanceTax)
        : base(wireTransferRemittanceTax) { }
#pragma warning restore CS8618

    public WireTransferRemittanceTax(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireTransferRemittanceTax(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireTransferRemittanceTaxFromRaw.FromRawUnchecked"/>
    public static WireTransferRemittanceTax FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WireTransferRemittanceTaxFromRaw : IFromRawJson<WireTransferRemittanceTax>
{
    /// <inheritdoc/>
    public WireTransferRemittanceTax FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WireTransferRemittanceTax.FromRawUnchecked(rawData);
}

/// <summary>
/// Unstructured remittance information. Required if `category` is equal to `unstructured`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WireTransferRemittanceUnstructured,
        WireTransferRemittanceUnstructuredFromRaw
    >)
)]
public sealed record class WireTransferRemittanceUnstructured : JsonModel
{
    /// <summary>
    /// The message to the beneficiary.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
    }

    public WireTransferRemittanceUnstructured() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireTransferRemittanceUnstructured(
        WireTransferRemittanceUnstructured wireTransferRemittanceUnstructured
    )
        : base(wireTransferRemittanceUnstructured) { }
#pragma warning restore CS8618

    public WireTransferRemittanceUnstructured(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireTransferRemittanceUnstructured(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireTransferRemittanceUnstructuredFromRaw.FromRawUnchecked"/>
    public static WireTransferRemittanceUnstructured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WireTransferRemittanceUnstructured(string message)
        : this()
    {
        this.Message = message;
    }
}

class WireTransferRemittanceUnstructuredFromRaw : IFromRawJson<WireTransferRemittanceUnstructured>
{
    /// <inheritdoc/>
    public WireTransferRemittanceUnstructured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WireTransferRemittanceUnstructured.FromRawUnchecked(rawData);
}

/// <summary>
/// If your transfer is reversed, this will contain details of the reversal.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Reversal, ReversalFromRaw>))]
public sealed record class Reversal : JsonModel
{
    /// <summary>
    /// The amount that was reversed in USD cents.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the reversal was created.
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
    /// The debtor's routing number.
    /// </summary>
    public required string? DebtorRoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("debtor_routing_number");
        }
        init { this._rawData.Set("debtor_routing_number", value); }
    }

    /// <summary>
    /// The description on the reversal message from Fedwire, set by the reversing bank.
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
    /// The Fedwire cycle date for the wire reversal. The "Fedwire day" begins at
    /// 9:00 PM Eastern Time on the evening before the `cycle date`.
    /// </summary>
    public required string InputCycleDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("input_cycle_date");
        }
        init { this._rawData.Set("input_cycle_date", value); }
    }

    /// <summary>
    /// The Fedwire transaction identifier.
    /// </summary>
    public required string InputMessageAccountabilityData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("input_message_accountability_data");
        }
        init { this._rawData.Set("input_message_accountability_data", value); }
    }

    /// <summary>
    /// The Fedwire sequence number.
    /// </summary>
    public required string InputSequenceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("input_sequence_number");
        }
        init { this._rawData.Set("input_sequence_number", value); }
    }

    /// <summary>
    /// The Fedwire input source identifier.
    /// </summary>
    public required string InputSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("input_source");
        }
        init { this._rawData.Set("input_source", value); }
    }

    /// <summary>
    /// The sending bank's identifier for the reversal.
    /// </summary>
    public required string? InstructionIdentification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instruction_identification");
        }
        init { this._rawData.Set("instruction_identification", value); }
    }

    /// <summary>
    /// Additional information about the reason for the reversal.
    /// </summary>
    public required string? ReturnReasonAdditionalInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("return_reason_additional_information");
        }
        init { this._rawData.Set("return_reason_additional_information", value); }
    }

    /// <summary>
    /// A code provided by the sending bank giving a reason for the reversal. The
    /// common return reason codes are [documented here](/documentation/wire-reversals#reversal-reason-codes).
    /// </summary>
    public required string? ReturnReasonCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("return_reason_code");
        }
        init { this._rawData.Set("return_reason_code", value); }
    }

    /// <summary>
    /// An Increase-generated description of the `return_reason_code`.
    /// </summary>
    public required string? ReturnReasonCodeDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("return_reason_code_description");
        }
        init { this._rawData.Set("return_reason_code_description", value); }
    }

    /// <summary>
    /// The ID for the Transaction associated with the transfer reversal.
    /// </summary>
    public required string TransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transaction_id");
        }
        init { this._rawData.Set("transaction_id", value); }
    }

    /// <summary>
    /// The ID for the Wire Transfer that is being reversed.
    /// </summary>
    public required string WireTransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("wire_transfer_id");
        }
        init { this._rawData.Set("wire_transfer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.CreatedAt;
        _ = this.DebtorRoutingNumber;
        _ = this.Description;
        _ = this.InputCycleDate;
        _ = this.InputMessageAccountabilityData;
        _ = this.InputSequenceNumber;
        _ = this.InputSource;
        _ = this.InstructionIdentification;
        _ = this.ReturnReasonAdditionalInformation;
        _ = this.ReturnReasonCode;
        _ = this.ReturnReasonCodeDescription;
        _ = this.TransactionID;
        _ = this.WireTransferID;
    }

    public Reversal() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Reversal(Reversal reversal)
        : base(reversal) { }
#pragma warning restore CS8618

    public Reversal(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Reversal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReversalFromRaw.FromRawUnchecked"/>
    public static Reversal FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReversalFromRaw : IFromRawJson<Reversal>
{
    /// <inheritdoc/>
    public Reversal FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Reversal.FromRawUnchecked(rawData);
}

/// <summary>
/// The lifecycle status of the transfer.
/// </summary>
[JsonConverter(typeof(WireTransferStatusConverter))]
public enum WireTransferStatus
{
    /// <summary>
    /// The transfer is pending approval.
    /// </summary>
    PendingApproval,

    /// <summary>
    /// The transfer has been canceled.
    /// </summary>
    Canceled,

    /// <summary>
    /// The transfer is pending review by Increase.
    /// </summary>
    PendingReviewing,

    /// <summary>
    /// The transfer has been rejected by Increase.
    /// </summary>
    Rejected,

    /// <summary>
    /// The transfer requires attention from an Increase operator.
    /// </summary>
    RequiresAttention,

    /// <summary>
    /// The transfer is pending creation.
    /// </summary>
    PendingCreating,

    /// <summary>
    /// The transfer has been reversed.
    /// </summary>
    Reversed,

    /// <summary>
    /// The transfer has been submitted to Fedwire.
    /// </summary>
    Submitted,

    /// <summary>
    /// The transfer has been acknowledged by Fedwire and can be considered complete.
    /// </summary>
    Complete,
}

sealed class WireTransferStatusConverter : JsonConverter<WireTransferStatus>
{
    public override WireTransferStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_approval" => WireTransferStatus.PendingApproval,
            "canceled" => WireTransferStatus.Canceled,
            "pending_reviewing" => WireTransferStatus.PendingReviewing,
            "rejected" => WireTransferStatus.Rejected,
            "requires_attention" => WireTransferStatus.RequiresAttention,
            "pending_creating" => WireTransferStatus.PendingCreating,
            "reversed" => WireTransferStatus.Reversed,
            "submitted" => WireTransferStatus.Submitted,
            "complete" => WireTransferStatus.Complete,
            _ => (WireTransferStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WireTransferStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WireTransferStatus.PendingApproval => "pending_approval",
                WireTransferStatus.Canceled => "canceled",
                WireTransferStatus.PendingReviewing => "pending_reviewing",
                WireTransferStatus.Rejected => "rejected",
                WireTransferStatus.RequiresAttention => "requires_attention",
                WireTransferStatus.PendingCreating => "pending_creating",
                WireTransferStatus.Reversed => "reversed",
                WireTransferStatus.Submitted => "submitted",
                WireTransferStatus.Complete => "complete",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// After the transfer is submitted to Fedwire, this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Submission, SubmissionFromRaw>))]
public sealed record class Submission : JsonModel
{
    /// <summary>
    /// The accountability data for the submission.
    /// </summary>
    public required string InputMessageAccountabilityData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("input_message_accountability_data");
        }
        init { this._rawData.Set("input_message_accountability_data", value); }
    }

    /// <summary>
    /// When this wire transfer was submitted to Fedwire.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InputMessageAccountabilityData;
        _ = this.SubmittedAt;
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
/// A constant representing the object's type. For this resource it will always be `wire_transfer`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    WireTransfer,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.WireTransfers.Type>
{
    public override global::Increase.Api.Models.WireTransfers.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "wire_transfer" => global::Increase.Api.Models.WireTransfers.Type.WireTransfer,
            _ => (global::Increase.Api.Models.WireTransfers.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.WireTransfers.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.WireTransfers.Type.WireTransfer => "wire_transfer",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
