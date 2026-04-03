using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Accounts;

/// <summary>
/// Accounts are your bank accounts with Increase. They store money, receive transfers,
/// and send payments. They earn interest and have depository insurance.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Account, AccountFromRaw>))]
public sealed record class Account : JsonModel
{
    /// <summary>
    /// The Account identifier.
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
    /// The account revenue rate currently being earned on the account, as a string
    /// containing a decimal number. For example, a 1% account revenue rate would
    /// be represented as "0.01". Account revenue is a type of non-interest income
    /// accrued on the account.
    /// </summary>
    public required string? AccountRevenueRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_revenue_rate");
        }
        init { this._rawData.Set("account_revenue_rate", value); }
    }

    /// <summary>
    /// The bank the Account is with.
    /// </summary>
    public required ApiEnum<string, Bank> Bank
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Bank>>("bank");
        }
        init { this._rawData.Set("bank", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Account
    /// was closed.
    /// </summary>
    public required System::DateTimeOffset? ClosedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("closed_at");
        }
        init { this._rawData.Set("closed_at", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Account
    /// was created.
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the Account currency.
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
    /// The identifier for the Entity the Account belongs to.
    /// </summary>
    public required string EntityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entity_id");
        }
        init { this._rawData.Set("entity_id", value); }
    }

    /// <summary>
    /// Whether the Account is funded by a loan or by deposits.
    /// </summary>
    public required ApiEnum<string, AccountFunding> Funding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountFunding>>("funding");
        }
        init { this._rawData.Set("funding", value); }
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
    /// The identifier of an Entity that, while not owning the Account, is associated
    /// with its activity.
    /// </summary>
    public required string? InformationalEntityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("informational_entity_id");
        }
        init { this._rawData.Set("informational_entity_id", value); }
    }

    /// <summary>
    /// The interest rate currently being earned on the account, as a string containing
    /// a decimal number. For example, a 1% interest rate would be represented as "0.01".
    /// </summary>
    public required string InterestRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("interest_rate");
        }
        init { this._rawData.Set("interest_rate", value); }
    }

    /// <summary>
    /// The Account's loan-related information, if the Account is a loan account.
    /// </summary>
    public required AccountLoan? Loan
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountLoan>("loan");
        }
        init { this._rawData.Set("loan", value); }
    }

    /// <summary>
    /// The name you choose for the Account.
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
    /// The identifier of the Program determining the compliance and commercial terms
    /// of this Account.
    /// </summary>
    public required string ProgramID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("program_id");
        }
        init { this._rawData.Set("program_id", value); }
    }

    /// <summary>
    /// The status of the Account.
    /// </summary>
    public required ApiEnum<string, AccountStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `account`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.Accounts.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.Accounts.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountRevenueRate;
        this.Bank.Validate();
        _ = this.ClosedAt;
        _ = this.CreatedAt;
        this.Currency.Validate();
        _ = this.EntityID;
        this.Funding.Validate();
        _ = this.IdempotencyKey;
        _ = this.InformationalEntityID;
        _ = this.InterestRate;
        this.Loan?.Validate();
        _ = this.Name;
        _ = this.ProgramID;
        this.Status.Validate();
        this.Type.Validate();
    }

    public Account() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Account(Account account)
        : base(account) { }
#pragma warning restore CS8618

    public Account(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Account(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountFromRaw.FromRawUnchecked"/>
    public static Account FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountFromRaw : IFromRawJson<Account>
{
    /// <inheritdoc/>
    public Account FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Account.FromRawUnchecked(rawData);
}

/// <summary>
/// The bank the Account is with.
/// </summary>
[JsonConverter(typeof(BankConverter))]
public enum Bank
{
    /// <summary>
    /// Core Bank
    /// </summary>
    CoreBank,

    /// <summary>
    /// First Internet Bank of Indiana
    /// </summary>
    FirstInternetBank,

    /// <summary>
    /// Grasshopper Bank
    /// </summary>
    GrasshopperBank,
}

sealed class BankConverter : JsonConverter<Bank>
{
    public override Bank Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "core_bank" => Bank.CoreBank,
            "first_internet_bank" => Bank.FirstInternetBank,
            "grasshopper_bank" => Bank.GrasshopperBank,
            _ => (Bank)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Bank value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Bank.CoreBank => "core_bank",
                Bank.FirstInternetBank => "first_internet_bank",
                Bank.GrasshopperBank => "grasshopper_bank",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the Account currency.
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
/// Whether the Account is funded by a loan or by deposits.
/// </summary>
[JsonConverter(typeof(AccountFundingConverter))]
public enum AccountFunding
{
    /// <summary>
    /// An account funded by a loan. Before opening a loan account, contact support@increase.com
    /// to set up a loan program.
    /// </summary>
    Loan,

    /// <summary>
    /// An account funded by deposits.
    /// </summary>
    Deposits,
}

sealed class AccountFundingConverter : JsonConverter<AccountFunding>
{
    public override AccountFunding Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "loan" => AccountFunding.Loan,
            "deposits" => AccountFunding.Deposits,
            _ => (AccountFunding)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountFunding value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountFunding.Loan => "loan",
                AccountFunding.Deposits => "deposits",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The Account's loan-related information, if the Account is a loan account.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccountLoan, AccountLoanFromRaw>))]
public sealed record class AccountLoan : JsonModel
{
    /// <summary>
    /// The maximum amount of money that can be borrowed on the Account.
    /// </summary>
    public required long CreditLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("credit_limit");
        }
        init { this._rawData.Set("credit_limit", value); }
    }

    /// <summary>
    /// The number of days after the statement date that the Account can be past
    /// due before being considered delinquent.
    /// </summary>
    public required long GracePeriodDays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("grace_period_days");
        }
        init { this._rawData.Set("grace_period_days", value); }
    }

    /// <summary>
    /// The date on which the loan matures.
    /// </summary>
    public required string? MaturityDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("maturity_date");
        }
        init { this._rawData.Set("maturity_date", value); }
    }

    /// <summary>
    /// The day of the month on which the loan statement is generated.
    /// </summary>
    public required long StatementDayOfMonth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("statement_day_of_month");
        }
        init { this._rawData.Set("statement_day_of_month", value); }
    }

    /// <summary>
    /// The type of payment for the loan.
    /// </summary>
    public required ApiEnum<string, AccountLoanStatementPaymentType> StatementPaymentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountLoanStatementPaymentType>>(
                "statement_payment_type"
            );
        }
        init { this._rawData.Set("statement_payment_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreditLimit;
        _ = this.GracePeriodDays;
        _ = this.MaturityDate;
        _ = this.StatementDayOfMonth;
        this.StatementPaymentType.Validate();
    }

    public AccountLoan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountLoan(AccountLoan accountLoan)
        : base(accountLoan) { }
#pragma warning restore CS8618

    public AccountLoan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountLoan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountLoanFromRaw.FromRawUnchecked"/>
    public static AccountLoan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountLoanFromRaw : IFromRawJson<AccountLoan>
{
    /// <inheritdoc/>
    public AccountLoan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountLoan.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payment for the loan.
/// </summary>
[JsonConverter(typeof(AccountLoanStatementPaymentTypeConverter))]
public enum AccountLoanStatementPaymentType
{
    /// <summary>
    /// The borrower must pay the full balance of the loan at the end of the statement period.
    /// </summary>
    Balance,

    /// <summary>
    /// The borrower must pay the accrued interest at the end of the statement period.
    /// </summary>
    InterestUntilMaturity,
}

sealed class AccountLoanStatementPaymentTypeConverter
    : JsonConverter<AccountLoanStatementPaymentType>
{
    public override AccountLoanStatementPaymentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "balance" => AccountLoanStatementPaymentType.Balance,
            "interest_until_maturity" => AccountLoanStatementPaymentType.InterestUntilMaturity,
            _ => (AccountLoanStatementPaymentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountLoanStatementPaymentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountLoanStatementPaymentType.Balance => "balance",
                AccountLoanStatementPaymentType.InterestUntilMaturity => "interest_until_maturity",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the Account.
/// </summary>
[JsonConverter(typeof(AccountStatusConverter))]
public enum AccountStatus
{
    /// <summary>
    /// Closed Accounts on which no new activity can occur.
    /// </summary>
    Closed,

    /// <summary>
    /// Open Accounts that are ready to use.
    /// </summary>
    Open,
}

sealed class AccountStatusConverter : JsonConverter<AccountStatus>
{
    public override AccountStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "closed" => AccountStatus.Closed,
            "open" => AccountStatus.Open,
            _ => (AccountStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountStatus.Closed => "closed",
                AccountStatus.Open => "open",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `account`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Account,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.Accounts.Type>
{
    public override global::Increase.Api.Models.Accounts.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account" => global::Increase.Api.Models.Accounts.Type.Account,
            _ => (global::Increase.Api.Models.Accounts.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.Accounts.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.Accounts.Type.Account => "account",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
