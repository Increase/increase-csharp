using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Accounts;

/// <summary>
/// Create an Account
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AccountCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The name you choose for the Account.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// The identifier for the Entity that will own the Account.
    /// </summary>
    public string? EntityID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("entity_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("entity_id", value);
        }
    }

    /// <summary>
    /// Whether the Account is funded by a loan or by deposits.
    /// </summary>
    public ApiEnum<string, Funding>? Funding
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Funding>>("funding");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("funding", value);
        }
    }

    /// <summary>
    /// The identifier of an Entity that, while not owning the Account, is associated
    /// with its activity. This is generally the beneficiary of the funds.
    /// </summary>
    public string? InformationalEntityID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("informational_entity_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("informational_entity_id", value);
        }
    }

    /// <summary>
    /// The loan details for the account.
    /// </summary>
    public Loan? Loan
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Loan>("loan");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("loan", value);
        }
    }

    /// <summary>
    /// The identifier for the Program that this Account falls under. Required if
    /// you operate more than one Program.
    /// </summary>
    public string? ProgramID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("program_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("program_id", value);
        }
    }

    public AccountCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountCreateParams(AccountCreateParams accountCreateParams)
        : base(accountCreateParams)
    {
        this._rawBodyData = new(accountCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AccountCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AccountCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(AccountCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/accounts")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Whether the Account is funded by a loan or by deposits.
/// </summary>
[JsonConverter(typeof(FundingConverter))]
public enum Funding
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

sealed class FundingConverter : JsonConverter<Funding>
{
    public override Funding Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "loan" => Funding.Loan,
            "deposits" => Funding.Deposits,
            _ => (Funding)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Funding value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Funding.Loan => "loan",
                Funding.Deposits => "deposits",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The loan details for the account.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Loan, LoanFromRaw>))]
public sealed record class Loan : JsonModel
{
    /// <summary>
    /// The maximum amount of money that can be drawn from the Account.
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
    /// The type of statement payment for the account.
    /// </summary>
    public required ApiEnum<string, StatementPaymentType> StatementPaymentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, StatementPaymentType>>(
                "statement_payment_type"
            );
        }
        init { this._rawData.Set("statement_payment_type", value); }
    }

    /// <summary>
    /// The date on which the loan matures.
    /// </summary>
    public string? MaturityDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("maturity_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maturity_date", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreditLimit;
        _ = this.GracePeriodDays;
        _ = this.StatementDayOfMonth;
        this.StatementPaymentType.Validate();
        _ = this.MaturityDate;
    }

    public Loan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Loan(Loan loan)
        : base(loan) { }
#pragma warning restore CS8618

    public Loan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Loan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LoanFromRaw.FromRawUnchecked"/>
    public static Loan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LoanFromRaw : IFromRawJson<Loan>
{
    /// <inheritdoc/>
    public Loan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Loan.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of statement payment for the account.
/// </summary>
[JsonConverter(typeof(StatementPaymentTypeConverter))]
public enum StatementPaymentType
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

sealed class StatementPaymentTypeConverter : JsonConverter<StatementPaymentType>
{
    public override StatementPaymentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "balance" => StatementPaymentType.Balance,
            "interest_until_maturity" => StatementPaymentType.InterestUntilMaturity,
            _ => (StatementPaymentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StatementPaymentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StatementPaymentType.Balance => "balance",
                StatementPaymentType.InterestUntilMaturity => "interest_until_maturity",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
