using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.FednowTransfers;

/// <summary>
/// FedNow transfers move funds, within seconds, between your Increase account and
/// any other account supporting FedNow.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FednowTransfer, FednowTransferFromRaw>))]
public sealed record class FednowTransfer : JsonModel
{
    /// <summary>
    /// The FedNow Transfer's identifier.
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
    /// The creditor's address.
    /// </summary>
    public required FednowTransferCreditorAddress? CreditorAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FednowTransferCreditorAddress>(
                "creditor_address"
            );
        }
        init { this._rawData.Set("creditor_address", value); }
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
    /// currency. For FedNow transfers this is always equal to `USD`.
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
    public required string DebtorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("debtor_name");
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
    /// The ID for the pending transaction representing the transfer.
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
    /// If the transfer is rejected by FedNow or the destination financial institution,
    /// this will contain supplemental details.
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
    public required ApiEnum<string, FednowTransferStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FednowTransferStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// After the transfer is submitted to FedNow, this will contain supplemental details.
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
    /// be `fednow_transfer`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.FednowTransfers.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.FednowTransfers.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The Unique End-to-end Transaction Reference ([UETR](https://www.swift.com/payments/what-unique-end-end-transaction-reference-uetr))
    /// of the transfer.
    /// </summary>
    public required string UniqueEndToEndTransactionReference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unique_end_to_end_transaction_reference");
        }
        init { this._rawData.Set("unique_end_to_end_transaction_reference", value); }
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
        _ = this.CreatedAt;
        this.CreatedBy?.Validate();
        this.CreditorAddress?.Validate();
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
        _ = this.UniqueEndToEndTransactionReference;
        _ = this.UnstructuredRemittanceInformation;
    }

    public FednowTransfer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FednowTransfer(FednowTransfer fednowTransfer)
        : base(fednowTransfer) { }
#pragma warning restore CS8618

    public FednowTransfer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FednowTransfer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FednowTransferFromRaw.FromRawUnchecked"/>
    public static FednowTransfer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FednowTransferFromRaw : IFromRawJson<FednowTransfer>
{
    /// <inheritdoc/>
    public FednowTransfer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FednowTransfer.FromRawUnchecked(rawData);
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
/// The creditor's address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FednowTransferCreditorAddress, FednowTransferCreditorAddressFromRaw>)
)]
public sealed record class FednowTransferCreditorAddress : JsonModel
{
    /// <summary>
    /// The city, district, town, or village of the address.
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
    /// The first line of the address.
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
    /// The ZIP code of the address.
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
    /// The address state.
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
        _ = this.PostalCode;
        _ = this.State;
    }

    public FednowTransferCreditorAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FednowTransferCreditorAddress(
        FednowTransferCreditorAddress fednowTransferCreditorAddress
    )
        : base(fednowTransferCreditorAddress) { }
#pragma warning restore CS8618

    public FednowTransferCreditorAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FednowTransferCreditorAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FednowTransferCreditorAddressFromRaw.FromRawUnchecked"/>
    public static FednowTransferCreditorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FednowTransferCreditorAddressFromRaw : IFromRawJson<FednowTransferCreditorAddress>
{
    /// <inheritdoc/>
    public FednowTransferCreditorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FednowTransferCreditorAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transfer's
/// currency. For FedNow transfers this is always equal to `USD`.
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
/// If the transfer is rejected by FedNow or the destination financial institution,
/// this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Rejection, RejectionFromRaw>))]
public sealed record class Rejection : JsonModel
{
    /// <summary>
    /// Additional information about the rejection provided by the recipient bank.
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
    /// the FedNow network.
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
/// FedNow network.
/// </summary>
[JsonConverter(typeof(RejectReasonCodeConverter))]
public enum RejectReasonCode
{
    /// <summary>
    /// The destination account is closed. Corresponds to the FedNow reason code `AC04`.
    /// </summary>
    AccountClosed,

    /// <summary>
    /// The destination account is currently blocked from receiving transactions.
    /// Corresponds to the FedNow reason code `AC06`.
    /// </summary>
    AccountBlocked,

    /// <summary>
    /// The destination account is ineligible to receive FedNow transfers. Corresponds
    /// to the FedNow reason code `AC14`.
    /// </summary>
    InvalidCreditorAccountType,

    /// <summary>
    /// The destination account does not exist. Corresponds to the FedNow reason code `AC03`.
    /// </summary>
    InvalidCreditorAccountNumber,

    /// <summary>
    /// The destination routing number is invalid. Corresponds to the FedNow reason
    /// code `RC04`.
    /// </summary>
    InvalidCreditorFinancialInstitutionIdentifier,

    /// <summary>
    /// The destination account holder is deceased. Corresponds to the FedNow reason
    /// code `MD07`.
    /// </summary>
    EndCustomerDeceased,

    /// <summary>
    /// The reason is provided as narrative information in the additional information
    /// field. Corresponds to the FedNow reason code `NARR`.
    /// </summary>
    Narrative,

    /// <summary>
    /// FedNow transfers are not allowed to the destination account. Corresponds
    /// to the FedNow reason code `AG01`.
    /// </summary>
    TransactionForbidden,

    /// <summary>
    /// FedNow transfers are not enabled for the destination account. Corresponds
    /// to the FedNow reason code `AG03`.
    /// </summary>
    TransactionTypeNotSupported,

    /// <summary>
    /// The amount is higher than the recipient is authorized to send or receive.
    /// Corresponds to the FedNow reason code `E990`.
    /// </summary>
    AmountExceedsBankLimits,

    /// <summary>
    /// The creditor's address is required, but missing or invalid. Corresponds to
    /// the FedNow reason code `BE04`.
    /// </summary>
    InvalidCreditorAddress,

    /// <summary>
    /// The debtor's address is required, but missing or invalid. Corresponds to the
    /// FedNow reason code `BE07`.
    /// </summary>
    InvalidDebtorAddress,

    /// <summary>
    /// There was a timeout processing the transfer. Corresponds to the FedNow reason
    /// code `E997`.
    /// </summary>
    Timeout,

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
            "amount_exceeds_bank_limits" => RejectReasonCode.AmountExceedsBankLimits,
            "invalid_creditor_address" => RejectReasonCode.InvalidCreditorAddress,
            "invalid_debtor_address" => RejectReasonCode.InvalidDebtorAddress,
            "timeout" => RejectReasonCode.Timeout,
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
                RejectReasonCode.AmountExceedsBankLimits => "amount_exceeds_bank_limits",
                RejectReasonCode.InvalidCreditorAddress => "invalid_creditor_address",
                RejectReasonCode.InvalidDebtorAddress => "invalid_debtor_address",
                RejectReasonCode.Timeout => "timeout",
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
[JsonConverter(typeof(FednowTransferStatusConverter))]
public enum FednowTransferStatus
{
    /// <summary>
    /// The transfer is pending review by Increase.
    /// </summary>
    PendingReviewing,

    /// <summary>
    /// The transfer has been canceled.
    /// </summary>
    Canceled,

    /// <summary>
    /// The transfer has been rejected by Increase.
    /// </summary>
    ReviewingRejected,

    /// <summary>
    /// The transfer requires attention from an Increase operator.
    /// </summary>
    RequiresAttention,

    /// <summary>
    /// The transfer is pending approval.
    /// </summary>
    PendingApproval,

    /// <summary>
    /// The transfer is queued to be submitted to FedNow.
    /// </summary>
    PendingSubmitting,

    /// <summary>
    /// The transfer has been submitted and is pending a response from FedNow.
    /// </summary>
    PendingResponse,

    /// <summary>
    /// The transfer has been sent successfully and is complete.
    /// </summary>
    Complete,

    /// <summary>
    /// The transfer was rejected by the network or the recipient's bank.
    /// </summary>
    Rejected,
}

sealed class FednowTransferStatusConverter : JsonConverter<FednowTransferStatus>
{
    public override FednowTransferStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_reviewing" => FednowTransferStatus.PendingReviewing,
            "canceled" => FednowTransferStatus.Canceled,
            "reviewing_rejected" => FednowTransferStatus.ReviewingRejected,
            "requires_attention" => FednowTransferStatus.RequiresAttention,
            "pending_approval" => FednowTransferStatus.PendingApproval,
            "pending_submitting" => FednowTransferStatus.PendingSubmitting,
            "pending_response" => FednowTransferStatus.PendingResponse,
            "complete" => FednowTransferStatus.Complete,
            "rejected" => FednowTransferStatus.Rejected,
            _ => (FednowTransferStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FednowTransferStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FednowTransferStatus.PendingReviewing => "pending_reviewing",
                FednowTransferStatus.Canceled => "canceled",
                FednowTransferStatus.ReviewingRejected => "reviewing_rejected",
                FednowTransferStatus.RequiresAttention => "requires_attention",
                FednowTransferStatus.PendingApproval => "pending_approval",
                FednowTransferStatus.PendingSubmitting => "pending_submitting",
                FednowTransferStatus.PendingResponse => "pending_response",
                FednowTransferStatus.Complete => "complete",
                FednowTransferStatus.Rejected => "rejected",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// After the transfer is submitted to FedNow, this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Submission, SubmissionFromRaw>))]
public sealed record class Submission : JsonModel
{
    /// <summary>
    /// The FedNow network identification of the message submitted.
    /// </summary>
    public required string MessageIdentification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message_identification");
        }
        init { this._rawData.Set("message_identification", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the transfer was submitted to FedNow.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MessageIdentification;
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
/// A constant representing the object's type. For this resource it will always be `fednow_transfer`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    FednowTransfer,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.FednowTransfers.Type>
{
    public override global::Increase.Api.Models.FednowTransfers.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fednow_transfer" => global::Increase.Api.Models.FednowTransfers.Type.FednowTransfer,
            _ => (global::Increase.Api.Models.FednowTransfers.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.FednowTransfers.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.FednowTransfers.Type.FednowTransfer =>
                    "fednow_transfer",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
