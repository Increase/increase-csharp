using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.RealTimePaymentsTransfers;

/// <summary>
/// Real-Time Payments transfers move funds, within seconds, between your Increase
/// account and any other account on the Real-Time Payments network.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RealTimePaymentsTransfer, RealTimePaymentsTransferFromRaw>)
)]
public sealed record class RealTimePaymentsTransfer : JsonModel
{
    /// <summary>
    /// The Real-Time Payments Transfer's identifier.
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
    /// The Account from which the transfer was sent.
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
    /// If the transfer is acknowledged by the recipient bank, this will contain
    /// supplemental details.
    /// </summary>
    public required Acknowledgement? Acknowledgement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Acknowledgement>("acknowledgement");
        }
        init { this._rawData.Set("acknowledgement", value); }
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
    /// The name of the transfer's recipient. This is set by the sender when creating
    /// the transfer.
    /// </summary>
    public required string CreditorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creditor_name");
        }
        init { this._rawData.Set("creditor_name", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transfer's
    /// currency. For real-time payments transfers this is always equal to `USD`.
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
    /// The name of the transfer's sender. If not provided, defaults to the name of
    /// the account's entity.
    /// </summary>
    public required string? DebtorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("debtor_name");
        }
        init { this._rawData.Set("debtor_name", value); }
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
    /// If the transfer is rejected by Real-Time Payments or the destination financial
    /// institution, this will contain supplemental details.
    /// </summary>
    public required Rejection? Rejection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Rejection>("rejection");
        }
        init { this._rawData.Set("rejection", value); }
    }

    /// <summary>
    /// The destination American Bankers' Association (ABA) Routing Transit Number (RTN).
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
    /// The Account Number the recipient will see as having sent the transfer.
    /// </summary>
    public required string SourceAccountNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source_account_number_id");
        }
        init { this._rawData.Set("source_account_number_id", value); }
    }

    /// <summary>
    /// The lifecycle status of the transfer.
    /// </summary>
    public required ApiEnum<string, RealTimePaymentsTransferStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RealTimePaymentsTransferStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// After the transfer is submitted to Real-Time Payments, this will contain supplemental details.
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
    /// The Transaction funding the transfer once it is complete.
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
    /// be `real_time_payments_transfer`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.RealTimePaymentsTransfers.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.RealTimePaymentsTransfers.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The name of the ultimate recipient of the transfer. Set this if the creditor
    /// is an intermediary receiving the payment for someone else.
    /// </summary>
    public required string? UltimateCreditorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ultimate_creditor_name");
        }
        init { this._rawData.Set("ultimate_creditor_name", value); }
    }

    /// <summary>
    /// The name of the ultimate sender of the transfer. Set this if the funds are
    /// being sent on behalf of someone who is not the account holder at Increase.
    /// </summary>
    public required string? UltimateDebtorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ultimate_debtor_name");
        }
        init { this._rawData.Set("ultimate_debtor_name", value); }
    }

    /// <summary>
    /// Unstructured information that will show on the recipient's bank statement.
    /// </summary>
    public required string UnstructuredRemittanceInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unstructured_remittance_information");
        }
        init { this._rawData.Set("unstructured_remittance_information", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.AccountNumber;
        this.Acknowledgement?.Validate();
        _ = this.Amount;
        this.Approval?.Validate();
        this.Cancellation?.Validate();
        _ = this.CreatedAt;
        this.CreatedBy?.Validate();
        _ = this.CreditorName;
        this.Currency.Validate();
        _ = this.DebtorName;
        _ = this.ExternalAccountID;
        _ = this.IdempotencyKey;
        _ = this.PendingTransactionID;
        this.Rejection?.Validate();
        _ = this.RoutingNumber;
        _ = this.SourceAccountNumberID;
        this.Status.Validate();
        this.Submission?.Validate();
        _ = this.TransactionID;
        this.Type.Validate();
        _ = this.UltimateCreditorName;
        _ = this.UltimateDebtorName;
        _ = this.UnstructuredRemittanceInformation;
    }

    public RealTimePaymentsTransfer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimePaymentsTransfer(RealTimePaymentsTransfer realTimePaymentsTransfer)
        : base(realTimePaymentsTransfer) { }
#pragma warning restore CS8618

    public RealTimePaymentsTransfer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimePaymentsTransfer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimePaymentsTransferFromRaw.FromRawUnchecked"/>
    public static RealTimePaymentsTransfer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimePaymentsTransferFromRaw : IFromRawJson<RealTimePaymentsTransfer>
{
    /// <inheritdoc/>
    public RealTimePaymentsTransfer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimePaymentsTransfer.FromRawUnchecked(rawData);
}

/// <summary>
/// If the transfer is acknowledged by the recipient bank, this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Acknowledgement, AcknowledgementFromRaw>))]
public sealed record class Acknowledgement : JsonModel
{
    /// <summary>
    /// When the transfer was acknowledged.
    /// </summary>
    public required System::DateTimeOffset AcknowledgedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("acknowledged_at");
        }
        init { this._rawData.Set("acknowledged_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcknowledgedAt;
    }

    public Acknowledgement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Acknowledgement(Acknowledgement acknowledgement)
        : base(acknowledgement) { }
#pragma warning restore CS8618

    public Acknowledgement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Acknowledgement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AcknowledgementFromRaw.FromRawUnchecked"/>
    public static Acknowledgement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Acknowledgement(System::DateTimeOffset acknowledgedAt)
        : this()
    {
        this.AcknowledgedAt = acknowledgedAt;
    }
}

class AcknowledgementFromRaw : IFromRawJson<Acknowledgement>
{
    /// <inheritdoc/>
    public Acknowledgement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Acknowledgement.FromRawUnchecked(rawData);
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
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transfer's
/// currency. For real-time payments transfers this is always equal to `USD`.
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
/// If the transfer is rejected by Real-Time Payments or the destination financial
/// institution, this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Rejection, RejectionFromRaw>))]
public sealed record class Rejection : JsonModel
{
    /// <summary>
    /// Additional information about the rejection provided by the recipient bank
    /// when the `reject_reason_code` is `NARRATIVE`.
    /// </summary>
    public required string? RejectReasonAdditionalInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reject_reason_additional_information");
        }
        init { this._rawData.Set("reject_reason_additional_information", value); }
    }

    /// <summary>
    /// The reason the transfer was rejected as provided by the recipient bank or
    /// the Real-Time Payments network.
    /// </summary>
    public required ApiEnum<string, RejectReasonCode> RejectReasonCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RejectReasonCode>>(
                "reject_reason_code"
            );
        }
        init { this._rawData.Set("reject_reason_code", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the transfer was rejected.
    /// </summary>
    public required System::DateTimeOffset? RejectedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("rejected_at");
        }
        init { this._rawData.Set("rejected_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RejectReasonAdditionalInformation;
        this.RejectReasonCode.Validate();
        _ = this.RejectedAt;
    }

    public Rejection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Rejection(Rejection rejection)
        : base(rejection) { }
#pragma warning restore CS8618

    public Rejection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Rejection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RejectionFromRaw.FromRawUnchecked"/>
    public static Rejection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RejectionFromRaw : IFromRawJson<Rejection>
{
    /// <inheritdoc/>
    public Rejection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Rejection.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason the transfer was rejected as provided by the recipient bank or the
/// Real-Time Payments network.
/// </summary>
[JsonConverter(typeof(RejectReasonCodeConverter))]
public enum RejectReasonCode
{
    /// <summary>
    /// The destination account is closed. Corresponds to the Real-Time Payments
    /// reason code `AC04`.
    /// </summary>
    AccountClosed,

    /// <summary>
    /// The destination account is currently blocked from receiving transactions.
    /// Corresponds to the Real-Time Payments reason code `AC06`.
    /// </summary>
    AccountBlocked,

    /// <summary>
    /// The destination account is ineligible to receive Real-Time Payments transfers.
    /// Corresponds to the Real-Time Payments reason code `AC14`.
    /// </summary>
    InvalidCreditorAccountType,

    /// <summary>
    /// The destination account does not exist. Corresponds to the Real-Time Payments
    /// reason code `AC03`.
    /// </summary>
    InvalidCreditorAccountNumber,

    /// <summary>
    /// The destination routing number is invalid. Corresponds to the Real-Time Payments
    /// reason code `RC04`.
    /// </summary>
    InvalidCreditorFinancialInstitutionIdentifier,

    /// <summary>
    /// The destination account holder is deceased. Corresponds to the Real-Time
    /// Payments reason code `MD07`.
    /// </summary>
    EndCustomerDeceased,

    /// <summary>
    /// The reason is provided as narrative information in the additional information field.
    /// </summary>
    Narrative,

    /// <summary>
    /// Real-Time Payments transfers are not allowed to the destination account.
    /// Corresponds to the Real-Time Payments reason code `AG01`.
    /// </summary>
    TransactionForbidden,

    /// <summary>
    /// Real-Time Payments transfers are not enabled for the destination account.
    /// Corresponds to the Real-Time Payments reason code `AG03`.
    /// </summary>
    TransactionTypeNotSupported,

    /// <summary>
    /// The amount of the transfer is different than expected by the recipient. Corresponds
    /// to the Real-Time Payments reason code `AM09`.
    /// </summary>
    UnexpectedAmount,

    /// <summary>
    /// The amount is higher than the recipient is authorized to send or receive.
    /// Corresponds to the Real-Time Payments reason code `AM14`.
    /// </summary>
    AmountExceedsBankLimits,

    /// <summary>
    /// The creditor's address is required, but missing or invalid. Corresponds to
    /// the Real-Time Payments reason code `BE04`.
    /// </summary>
    InvalidCreditorAddress,

    /// <summary>
    /// The specified creditor is unknown. Corresponds to the Real-Time Payments
    /// reason code `BE06`.
    /// </summary>
    UnknownEndCustomer,

    /// <summary>
    /// The debtor's address is required, but missing or invalid. Corresponds to the
    /// Real-Time Payments reason code `BE07`.
    /// </summary>
    InvalidDebtorAddress,

    /// <summary>
    /// There was a timeout processing the transfer. Corresponds to the Real-Time
    /// Payments reason code `DS24`.
    /// </summary>
    Timeout,

    /// <summary>
    /// Real-Time Payments transfers are not enabled for the destination account.
    /// Corresponds to the Real-Time Payments reason code `NOAT`.
    /// </summary>
    UnsupportedMessageForRecipient,

    /// <summary>
    /// The destination financial institution is currently not connected to Real-Time
    /// Payments. Corresponds to the Real-Time Payments reason code `9912`.
    /// </summary>
    RecipientConnectionNotAvailable,

    /// <summary>
    /// Real-Time Payments is currently unavailable. Corresponds to the Real-Time
    /// Payments reason code `9948`.
    /// </summary>
    RealTimePaymentsSuspended,

    /// <summary>
    /// The destination financial institution is currently signed off of Real-Time
    /// Payments. Corresponds to the Real-Time Payments reason code `9910`.
    /// </summary>
    InstructedAgentSignedOff,

    /// <summary>
    /// The transfer was rejected due to an internal Increase issue. We have been notified.
    /// </summary>
    ProcessingError,

    /// <summary>
    /// Some other error or issue has occurred.
    /// </summary>
    Other,
}

sealed class RejectReasonCodeConverter : JsonConverter<RejectReasonCode>
{
    public override RejectReasonCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_closed" => RejectReasonCode.AccountClosed,
            "account_blocked" => RejectReasonCode.AccountBlocked,
            "invalid_creditor_account_type" => RejectReasonCode.InvalidCreditorAccountType,
            "invalid_creditor_account_number" => RejectReasonCode.InvalidCreditorAccountNumber,
            "invalid_creditor_financial_institution_identifier" =>
                RejectReasonCode.InvalidCreditorFinancialInstitutionIdentifier,
            "end_customer_deceased" => RejectReasonCode.EndCustomerDeceased,
            "narrative" => RejectReasonCode.Narrative,
            "transaction_forbidden" => RejectReasonCode.TransactionForbidden,
            "transaction_type_not_supported" => RejectReasonCode.TransactionTypeNotSupported,
            "unexpected_amount" => RejectReasonCode.UnexpectedAmount,
            "amount_exceeds_bank_limits" => RejectReasonCode.AmountExceedsBankLimits,
            "invalid_creditor_address" => RejectReasonCode.InvalidCreditorAddress,
            "unknown_end_customer" => RejectReasonCode.UnknownEndCustomer,
            "invalid_debtor_address" => RejectReasonCode.InvalidDebtorAddress,
            "timeout" => RejectReasonCode.Timeout,
            "unsupported_message_for_recipient" => RejectReasonCode.UnsupportedMessageForRecipient,
            "recipient_connection_not_available" =>
                RejectReasonCode.RecipientConnectionNotAvailable,
            "real_time_payments_suspended" => RejectReasonCode.RealTimePaymentsSuspended,
            "instructed_agent_signed_off" => RejectReasonCode.InstructedAgentSignedOff,
            "processing_error" => RejectReasonCode.ProcessingError,
            "other" => RejectReasonCode.Other,
            _ => (RejectReasonCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RejectReasonCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RejectReasonCode.AccountClosed => "account_closed",
                RejectReasonCode.AccountBlocked => "account_blocked",
                RejectReasonCode.InvalidCreditorAccountType => "invalid_creditor_account_type",
                RejectReasonCode.InvalidCreditorAccountNumber => "invalid_creditor_account_number",
                RejectReasonCode.InvalidCreditorFinancialInstitutionIdentifier =>
                    "invalid_creditor_financial_institution_identifier",
                RejectReasonCode.EndCustomerDeceased => "end_customer_deceased",
                RejectReasonCode.Narrative => "narrative",
                RejectReasonCode.TransactionForbidden => "transaction_forbidden",
                RejectReasonCode.TransactionTypeNotSupported => "transaction_type_not_supported",
                RejectReasonCode.UnexpectedAmount => "unexpected_amount",
                RejectReasonCode.AmountExceedsBankLimits => "amount_exceeds_bank_limits",
                RejectReasonCode.InvalidCreditorAddress => "invalid_creditor_address",
                RejectReasonCode.UnknownEndCustomer => "unknown_end_customer",
                RejectReasonCode.InvalidDebtorAddress => "invalid_debtor_address",
                RejectReasonCode.Timeout => "timeout",
                RejectReasonCode.UnsupportedMessageForRecipient =>
                    "unsupported_message_for_recipient",
                RejectReasonCode.RecipientConnectionNotAvailable =>
                    "recipient_connection_not_available",
                RejectReasonCode.RealTimePaymentsSuspended => "real_time_payments_suspended",
                RejectReasonCode.InstructedAgentSignedOff => "instructed_agent_signed_off",
                RejectReasonCode.ProcessingError => "processing_error",
                RejectReasonCode.Other => "other",
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
[JsonConverter(typeof(RealTimePaymentsTransferStatusConverter))]
public enum RealTimePaymentsTransferStatus
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
    /// The transfer requires attention from an Increase operator.
    /// </summary>
    RequiresAttention,

    /// <summary>
    /// The transfer was rejected by the network or the recipient's bank.
    /// </summary>
    Rejected,

    /// <summary>
    /// The transfer is queued to be submitted to Real-Time Payments.
    /// </summary>
    PendingSubmission,

    /// <summary>
    /// The transfer has been submitted and is pending a response from Real-Time Payments.
    /// </summary>
    Submitted,

    /// <summary>
    /// The transfer has been sent successfully and is complete.
    /// </summary>
    Complete,
}

sealed class RealTimePaymentsTransferStatusConverter : JsonConverter<RealTimePaymentsTransferStatus>
{
    public override RealTimePaymentsTransferStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_approval" => RealTimePaymentsTransferStatus.PendingApproval,
            "canceled" => RealTimePaymentsTransferStatus.Canceled,
            "pending_reviewing" => RealTimePaymentsTransferStatus.PendingReviewing,
            "requires_attention" => RealTimePaymentsTransferStatus.RequiresAttention,
            "rejected" => RealTimePaymentsTransferStatus.Rejected,
            "pending_submission" => RealTimePaymentsTransferStatus.PendingSubmission,
            "submitted" => RealTimePaymentsTransferStatus.Submitted,
            "complete" => RealTimePaymentsTransferStatus.Complete,
            _ => (RealTimePaymentsTransferStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RealTimePaymentsTransferStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RealTimePaymentsTransferStatus.PendingApproval => "pending_approval",
                RealTimePaymentsTransferStatus.Canceled => "canceled",
                RealTimePaymentsTransferStatus.PendingReviewing => "pending_reviewing",
                RealTimePaymentsTransferStatus.RequiresAttention => "requires_attention",
                RealTimePaymentsTransferStatus.Rejected => "rejected",
                RealTimePaymentsTransferStatus.PendingSubmission => "pending_submission",
                RealTimePaymentsTransferStatus.Submitted => "submitted",
                RealTimePaymentsTransferStatus.Complete => "complete",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// After the transfer is submitted to Real-Time Payments, this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Submission, SubmissionFromRaw>))]
public sealed record class Submission : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the transfer was submitted to The Clearing House.
    /// </summary>
    public required System::DateTimeOffset? SubmittedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("submitted_at");
        }
        init { this._rawData.Set("submitted_at", value); }
    }

    /// <summary>
    /// The Real-Time Payments network identification of the transfer.
    /// </summary>
    public required string TransactionIdentification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transaction_identification");
        }
        init { this._rawData.Set("transaction_identification", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SubmittedAt;
        _ = this.TransactionIdentification;
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
/// A constant representing the object's type. For this resource it will always be `real_time_payments_transfer`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    RealTimePaymentsTransfer,
}

sealed class TypeConverter
    : JsonConverter<global::Increase.Api.Models.RealTimePaymentsTransfers.Type>
{
    public override global::Increase.Api.Models.RealTimePaymentsTransfers.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "real_time_payments_transfer" => global::Increase
                .Api
                .Models
                .RealTimePaymentsTransfers
                .Type
                .RealTimePaymentsTransfer,
            _ => (global::Increase.Api.Models.RealTimePaymentsTransfers.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.RealTimePaymentsTransfers.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase
                    .Api
                    .Models
                    .RealTimePaymentsTransfers
                    .Type
                    .RealTimePaymentsTransfer => "real_time_payments_transfer",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
