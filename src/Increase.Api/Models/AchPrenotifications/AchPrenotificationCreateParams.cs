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

namespace Increase.Api.Models.AchPrenotifications;

/// <summary>
/// Create an ACH Prenotification
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AchPrenotificationCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The Increase identifier for the account that will send the ACH Prenotification.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("account_id");
        }
        init { this._rawBodyData.Set("account_id", value); }
    }

    /// <summary>
    /// The account number for the destination account.
    /// </summary>
    public required string AccountNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("account_number");
        }
        init { this._rawBodyData.Set("account_number", value); }
    }

    /// <summary>
    /// The American Bankers' Association (ABA) Routing Transit Number (RTN) for
    /// the destination account.
    /// </summary>
    public required string RoutingNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("routing_number");
        }
        init { this._rawBodyData.Set("routing_number", value); }
    }

    /// <summary>
    /// Additional information that will be sent to the recipient.
    /// </summary>
    public string? Addendum
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("addendum");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("addendum", value);
        }
    }

    /// <summary>
    /// The description of the date of the ACH Prenotification.
    /// </summary>
    public string? CompanyDescriptiveDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("company_descriptive_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("company_descriptive_date", value);
        }
    }

    /// <summary>
    /// The data you choose to associate with the ACH Prenotification.
    /// </summary>
    public string? CompanyDiscretionaryData
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("company_discretionary_data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("company_discretionary_data", value);
        }
    }

    /// <summary>
    /// The description you wish to be shown to the recipient.
    /// </summary>
    public string? CompanyEntryDescription
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("company_entry_description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("company_entry_description", value);
        }
    }

    /// <summary>
    /// The name by which the recipient knows you.
    /// </summary>
    public string? CompanyName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("company_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("company_name", value);
        }
    }

    /// <summary>
    /// Whether the Prenotification is for a future debit or credit.
    /// </summary>
    public ApiEnum<string, CreditDebitIndicator>? CreditDebitIndicator
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, CreditDebitIndicator>>(
                "credit_debit_indicator"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("credit_debit_indicator", value);
        }
    }

    /// <summary>
    /// The ACH Prenotification effective date in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format.
    /// </summary>
    public string? EffectiveDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("effective_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("effective_date", value);
        }
    }

    /// <summary>
    /// Your identifier for the recipient.
    /// </summary>
    public string? IndividualID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("individual_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("individual_id", value);
        }
    }

    /// <summary>
    /// The name of therecipient. This value is informational and not verified by
    /// the recipient's bank.
    /// </summary>
    public string? IndividualName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("individual_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("individual_name", value);
        }
    }

    /// <summary>
    /// The [Standard Entry Class (SEC) code](/documentation/ach-standard-entry-class-codes)
    /// to use for the ACH Prenotification.
    /// </summary>
    public ApiEnum<string, StandardEntryClassCode>? StandardEntryClassCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, StandardEntryClassCode>>(
                "standard_entry_class_code"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("standard_entry_class_code", value);
        }
    }

    public AchPrenotificationCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchPrenotificationCreateParams(
        AchPrenotificationCreateParams achPrenotificationCreateParams
    )
        : base(achPrenotificationCreateParams)
    {
        this._rawBodyData = new(achPrenotificationCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AchPrenotificationCreateParams(
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
    AchPrenotificationCreateParams(
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
    public static AchPrenotificationCreateParams FromRawUnchecked(
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

    public virtual bool Equals(AchPrenotificationCreateParams? other)
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
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/ach_prenotifications"
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
/// Whether the Prenotification is for a future debit or credit.
/// </summary>
[JsonConverter(typeof(CreditDebitIndicatorConverter))]
public enum CreditDebitIndicator
{
    /// <summary>
    /// The Prenotification is for an anticipated credit.
    /// </summary>
    Credit,

    /// <summary>
    /// The Prenotification is for an anticipated debit.
    /// </summary>
    Debit,
}

sealed class CreditDebitIndicatorConverter : JsonConverter<CreditDebitIndicator>
{
    public override CreditDebitIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit" => CreditDebitIndicator.Credit,
            "debit" => CreditDebitIndicator.Debit,
            _ => (CreditDebitIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditDebitIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditDebitIndicator.Credit => "credit",
                CreditDebitIndicator.Debit => "debit",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The [Standard Entry Class (SEC) code](/documentation/ach-standard-entry-class-codes)
/// to use for the ACH Prenotification.
/// </summary>
[JsonConverter(typeof(StandardEntryClassCodeConverter))]
public enum StandardEntryClassCode
{
    /// <summary>
    /// Corporate Credit and Debit (CCD) is used for business-to-business payments.
    /// </summary>
    CorporateCreditOrDebit,

    /// <summary>
    /// Corporate Trade Exchange (CTX) allows for including extensive remittance information
    /// with business-to-business payments.
    /// </summary>
    CorporateTradeExchange,

    /// <summary>
    /// Prearranged Payments and Deposits (PPD) is used for credits or debits originated
    /// by an organization to a consumer, such as payroll direct deposits.
    /// </summary>
    PrearrangedPaymentsAndDeposit,

    /// <summary>
    /// Internet Initiated (WEB) is used for consumer payments initiated or authorized
    /// via the Internet. Debits can only be initiated by non-consumers to debit a
    /// consumer’s account. Credits can only be used for consumer to consumer transactions.
    /// </summary>
    InternetInitiated,
}

sealed class StandardEntryClassCodeConverter : JsonConverter<StandardEntryClassCode>
{
    public override StandardEntryClassCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "corporate_credit_or_debit" => StandardEntryClassCode.CorporateCreditOrDebit,
            "corporate_trade_exchange" => StandardEntryClassCode.CorporateTradeExchange,
            "prearranged_payments_and_deposit" =>
                StandardEntryClassCode.PrearrangedPaymentsAndDeposit,
            "internet_initiated" => StandardEntryClassCode.InternetInitiated,
            _ => (StandardEntryClassCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StandardEntryClassCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StandardEntryClassCode.CorporateCreditOrDebit => "corporate_credit_or_debit",
                StandardEntryClassCode.CorporateTradeExchange => "corporate_trade_exchange",
                StandardEntryClassCode.PrearrangedPaymentsAndDeposit =>
                    "prearranged_payments_and_deposit",
                StandardEntryClassCode.InternetInitiated => "internet_initiated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
