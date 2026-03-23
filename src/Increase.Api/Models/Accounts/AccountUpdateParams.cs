using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.Accounts;

/// <summary>
/// Update an Account
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AccountUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? AccountID { get; init; }

    /// <summary>
    /// The loan details for the account.
    /// </summary>
    public AccountUpdateParamsLoan? Loan
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AccountUpdateParamsLoan>("loan");
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
    /// The new name of the Account.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    public AccountUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountUpdateParams(AccountUpdateParams accountUpdateParams)
        : base(accountUpdateParams)
    {
        this.AccountID = accountUpdateParams.AccountID;

        this._rawBodyData = new(accountUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AccountUpdateParams(
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
    AccountUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string accountID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.AccountID = accountID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AccountUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string accountID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            accountID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["AccountID"] = JsonSerializer.SerializeToElement(this.AccountID),
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

    public virtual bool Equals(AccountUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.AccountID?.Equals(other.AccountID) ?? other.AccountID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/accounts/{0}", this.AccountID)
        )
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
/// The loan details for the account.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccountUpdateParamsLoan, AccountUpdateParamsLoanFromRaw>))]
public sealed record class AccountUpdateParamsLoan : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreditLimit;
    }

    public AccountUpdateParamsLoan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountUpdateParamsLoan(AccountUpdateParamsLoan accountUpdateParamsLoan)
        : base(accountUpdateParamsLoan) { }
#pragma warning restore CS8618

    public AccountUpdateParamsLoan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountUpdateParamsLoan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountUpdateParamsLoanFromRaw.FromRawUnchecked"/>
    public static AccountUpdateParamsLoan FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AccountUpdateParamsLoan(long creditLimit)
        : this()
    {
        this.CreditLimit = creditLimit;
    }
}

class AccountUpdateParamsLoanFromRaw : IFromRawJson<AccountUpdateParamsLoan>
{
    /// <inheritdoc/>
    public AccountUpdateParamsLoan FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountUpdateParamsLoan.FromRawUnchecked(rawData);
}
