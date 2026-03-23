using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.SwiftTransfers;

/// <summary>
/// Swift Transfers send funds internationally.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SwiftTransfer, SwiftTransferFromRaw>))]
public sealed record class SwiftTransfer : JsonModel
{
    /// <summary>
    /// The Swift transfer's identifier.
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
    /// The creditor's account number.
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
    /// The bank identification code (BIC) of the creditor.
    /// </summary>
    public required string BankIdentificationCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("bank_identification_code");
        }
        init { this._rawData.Set("bank_identification_code", value); }
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
    public required CreatedBy CreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CreatedBy>("created_by");
        }
        init { this._rawData.Set("created_by", value); }
    }

    /// <summary>
    /// The creditor's address.
    /// </summary>
    public required SwiftTransferCreditorAddress CreditorAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SwiftTransferCreditorAddress>("creditor_address");
        }
        init { this._rawData.Set("creditor_address", value); }
    }

    /// <summary>
    /// The creditor's name.
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
    /// The debtor's address.
    /// </summary>
    public required SwiftTransferDebtorAddress DebtorAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SwiftTransferDebtorAddress>("debtor_address");
        }
        init { this._rawData.Set("debtor_address", value); }
    }

    /// <summary>
    /// The debtor's name.
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
    /// The amount that was instructed to be transferred in minor units of the `instructed_currency`.
    /// </summary>
    public required long InstructedAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("instructed_amount");
        }
        init { this._rawData.Set("instructed_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) currency code of the
    /// instructed amount.
    /// </summary>
    public required ApiEnum<string, SwiftTransferInstructedCurrency> InstructedCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SwiftTransferInstructedCurrency>>(
                "instructed_currency"
            );
        }
        init { this._rawData.Set("instructed_currency", value); }
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
    /// The creditor's bank account routing or transit number. Required in certain countries.
    /// </summary>
    public required string? RoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("routing_number");
        }
        init { this._rawData.Set("routing_number", value); }
    }

    /// <summary>
    /// The Account Number included in the transfer as the debtor's account number.
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
    public required ApiEnum<string, SwiftTransferStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SwiftTransferStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The ID for the transaction funding the transfer. This will be populated after
    /// the transfer is initiated.
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
    /// be `swift_transfer`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.SwiftTransfers.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.SwiftTransfers.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The Unique End-to-end Transaction Reference ([UETR](https://www.swift.com/payments/what-unique-end-end-transaction-reference-uetr))
    /// for the transfer.
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
    /// The unstructured remittance information that was included with the transfer.
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
        _ = this.Amount;
        _ = this.BankIdentificationCode;
        _ = this.CreatedAt;
        this.CreatedBy.Validate();
        this.CreditorAddress.Validate();
        _ = this.CreditorName;
        this.DebtorAddress.Validate();
        _ = this.DebtorName;
        _ = this.IdempotencyKey;
        _ = this.InstructedAmount;
        this.InstructedCurrency.Validate();
        _ = this.PendingTransactionID;
        _ = this.RoutingNumber;
        _ = this.SourceAccountNumberID;
        this.Status.Validate();
        _ = this.TransactionID;
        this.Type.Validate();
        _ = this.UniqueEndToEndTransactionReference;
        _ = this.UnstructuredRemittanceInformation;
    }

    public SwiftTransfer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SwiftTransfer(SwiftTransfer swiftTransfer)
        : base(swiftTransfer) { }
#pragma warning restore CS8618

    public SwiftTransfer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwiftTransfer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SwiftTransferFromRaw.FromRawUnchecked"/>
    public static SwiftTransfer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SwiftTransferFromRaw : IFromRawJson<SwiftTransfer>
{
    /// <inheritdoc/>
    public SwiftTransfer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SwiftTransfer.FromRawUnchecked(rawData);
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
    typeof(JsonModelConverter<SwiftTransferCreditorAddress, SwiftTransferCreditorAddressFromRaw>)
)]
public sealed record class SwiftTransferCreditorAddress : JsonModel
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
    /// The two-letter [ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
    /// code for the country of the address.
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
    /// The first line of the address.
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
    /// The second line of the address.
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
    /// The ZIP or postal code of the address.
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
    /// The state, province, or region of the address. Required in certain countries.
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
        _ = this.Country;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.PostalCode;
        _ = this.State;
    }

    public SwiftTransferCreditorAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SwiftTransferCreditorAddress(SwiftTransferCreditorAddress swiftTransferCreditorAddress)
        : base(swiftTransferCreditorAddress) { }
#pragma warning restore CS8618

    public SwiftTransferCreditorAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwiftTransferCreditorAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SwiftTransferCreditorAddressFromRaw.FromRawUnchecked"/>
    public static SwiftTransferCreditorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SwiftTransferCreditorAddressFromRaw : IFromRawJson<SwiftTransferCreditorAddress>
{
    /// <inheritdoc/>
    public SwiftTransferCreditorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SwiftTransferCreditorAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The debtor's address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SwiftTransferDebtorAddress, SwiftTransferDebtorAddressFromRaw>)
)]
public sealed record class SwiftTransferDebtorAddress : JsonModel
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
    /// The two-letter [ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
    /// code for the country of the address.
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
    /// The first line of the address.
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
    /// The second line of the address.
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
    /// The ZIP or postal code of the address.
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
    /// The state, province, or region of the address. Required in certain countries.
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
        _ = this.Country;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.PostalCode;
        _ = this.State;
    }

    public SwiftTransferDebtorAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SwiftTransferDebtorAddress(SwiftTransferDebtorAddress swiftTransferDebtorAddress)
        : base(swiftTransferDebtorAddress) { }
#pragma warning restore CS8618

    public SwiftTransferDebtorAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwiftTransferDebtorAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SwiftTransferDebtorAddressFromRaw.FromRawUnchecked"/>
    public static SwiftTransferDebtorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SwiftTransferDebtorAddressFromRaw : IFromRawJson<SwiftTransferDebtorAddress>
{
    /// <inheritdoc/>
    public SwiftTransferDebtorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SwiftTransferDebtorAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) currency code of the instructed amount.
/// </summary>
[JsonConverter(typeof(SwiftTransferInstructedCurrencyConverter))]
public enum SwiftTransferInstructedCurrency
{
    /// <summary>
    /// United States Dollar
    /// </summary>
    Usd,
}

sealed class SwiftTransferInstructedCurrencyConverter
    : JsonConverter<SwiftTransferInstructedCurrency>
{
    public override SwiftTransferInstructedCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => SwiftTransferInstructedCurrency.Usd,
            _ => (SwiftTransferInstructedCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SwiftTransferInstructedCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SwiftTransferInstructedCurrency.Usd => "USD",
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
[JsonConverter(typeof(SwiftTransferStatusConverter))]
public enum SwiftTransferStatus
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
    /// The transfer is pending initiation.
    /// </summary>
    PendingInitiating,

    /// <summary>
    /// The transfer has been initiated.
    /// </summary>
    Initiated,

    /// <summary>
    /// The transfer has been rejected by Increase.
    /// </summary>
    Rejected,

    /// <summary>
    /// The transfer has been returned.
    /// </summary>
    Returned,
}

sealed class SwiftTransferStatusConverter : JsonConverter<SwiftTransferStatus>
{
    public override SwiftTransferStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_approval" => SwiftTransferStatus.PendingApproval,
            "canceled" => SwiftTransferStatus.Canceled,
            "pending_reviewing" => SwiftTransferStatus.PendingReviewing,
            "requires_attention" => SwiftTransferStatus.RequiresAttention,
            "pending_initiating" => SwiftTransferStatus.PendingInitiating,
            "initiated" => SwiftTransferStatus.Initiated,
            "rejected" => SwiftTransferStatus.Rejected,
            "returned" => SwiftTransferStatus.Returned,
            _ => (SwiftTransferStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SwiftTransferStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SwiftTransferStatus.PendingApproval => "pending_approval",
                SwiftTransferStatus.Canceled => "canceled",
                SwiftTransferStatus.PendingReviewing => "pending_reviewing",
                SwiftTransferStatus.RequiresAttention => "requires_attention",
                SwiftTransferStatus.PendingInitiating => "pending_initiating",
                SwiftTransferStatus.Initiated => "initiated",
                SwiftTransferStatus.Rejected => "rejected",
                SwiftTransferStatus.Returned => "returned",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `swift_transfer`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    SwiftTransfer,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.SwiftTransfers.Type>
{
    public override global::Increase.Api.Models.SwiftTransfers.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "swift_transfer" => global::Increase.Api.Models.SwiftTransfers.Type.SwiftTransfer,
            _ => (global::Increase.Api.Models.SwiftTransfers.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.SwiftTransfers.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.SwiftTransfers.Type.SwiftTransfer => "swift_transfer",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
