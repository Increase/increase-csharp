using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Exports;

/// <summary>
/// List Exports
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExportListParams : ParamsBase
{
    /// <summary>
    /// Filter Exports for those with the specified category.
    /// </summary>
    public ApiEnum<string, ExportListParamsCategory>? Category
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, ExportListParamsCategory>>(
                "category"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("category", value);
        }
    }

    public ExportListParamsCreatedAt? CreatedAt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ExportListParamsCreatedAt>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Return the page of entries after this one.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    public Form1099Int? Form1099Int
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Form1099Int>("form_1099_int");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("form_1099_int", value);
        }
    }

    public Form1099Misc? Form1099Misc
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Form1099Misc>("form_1099_misc");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("form_1099_misc", value);
        }
    }

    /// <summary>
    /// Filter records to the one with the specified `idempotency_key` you chose for
    /// that object. This value is unique across Increase and is used to ensure that
    /// a request is only processed once. Learn more about [idempotency](https://increase.com/documentation/idempotency-keys).
    /// </summary>
    public string? IdempotencyKey
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("idempotency_key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("idempotency_key", value);
        }
    }

    /// <summary>
    /// Limit the size of the list that is returned. The default (and maximum) is
    /// 100 objects.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    public Status? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Status>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("status", value);
        }
    }

    public ExportListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportListParams(ExportListParams exportListParams)
        : base(exportListParams) { }
#pragma warning restore CS8618

    public ExportListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExportListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ExportListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/exports")
        {
            Query = this.QueryString(options),
        }.Uri;
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
/// Filter Exports for those with the specified category.
/// </summary>
[JsonConverter(typeof(ExportListParamsCategoryConverter))]
public enum ExportListParamsCategory
{
    /// <summary>
    /// Export an Open Financial Exchange (OFX) file of transactions and balances
    /// for a given time range and Account.
    /// </summary>
    AccountStatementOfx,

    /// <summary>
    /// Export a BAI2 file of transactions and balances for a given date and optional Account.
    /// </summary>
    AccountStatementBai2,

    /// <summary>
    /// Export a CSV of all transactions for a given time range.
    /// </summary>
    TransactionCsv,

    /// <summary>
    /// Export a CSV of account balances for the dates in a given range.
    /// </summary>
    BalanceCsv,

    /// <summary>
    /// Export a CSV of bookkeeping account balances for the dates in a given range.
    /// </summary>
    BookkeepingAccountBalanceCsv,

    /// <summary>
    /// Export a CSV of entities with a given status.
    /// </summary>
    EntityCsv,

    /// <summary>
    /// Export a CSV of vendors added to the third-party risk management dashboard.
    /// </summary>
    VendorCsv,

    /// <summary>
    /// Certain dashboard tables are available as CSV exports. This export cannot
    /// be created via the API.
    /// </summary>
    DashboardTableCsv,

    /// <summary>
    /// A PDF of an account verification letter.
    /// </summary>
    AccountVerificationLetter,

    /// <summary>
    /// A PDF of funding instructions.
    /// </summary>
    FundingInstructions,

    /// <summary>
    /// A PDF of an Internal Revenue Service Form 1099-INT.
    /// </summary>
    Form1099Int,

    /// <summary>
    /// A PDF of an Internal Revenue Service Form 1099-MISC.
    /// </summary>
    Form1099Misc,

    /// <summary>
    /// Export a CSV of fees. The time range must not include any fees that are part
    /// of an open fee statement.
    /// </summary>
    FeeCsv,

    /// <summary>
    /// A PDF of a voided check.
    /// </summary>
    VoidedCheck,

    /// <summary>
    /// Export a CSV of daily account balances with starting and ending balances
    /// for a given date range.
    /// </summary>
    DailyAccountBalanceCsv,
}

sealed class ExportListParamsCategoryConverter : JsonConverter<ExportListParamsCategory>
{
    public override ExportListParamsCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_statement_ofx" => ExportListParamsCategory.AccountStatementOfx,
            "account_statement_bai2" => ExportListParamsCategory.AccountStatementBai2,
            "transaction_csv" => ExportListParamsCategory.TransactionCsv,
            "balance_csv" => ExportListParamsCategory.BalanceCsv,
            "bookkeeping_account_balance_csv" =>
                ExportListParamsCategory.BookkeepingAccountBalanceCsv,
            "entity_csv" => ExportListParamsCategory.EntityCsv,
            "vendor_csv" => ExportListParamsCategory.VendorCsv,
            "dashboard_table_csv" => ExportListParamsCategory.DashboardTableCsv,
            "account_verification_letter" => ExportListParamsCategory.AccountVerificationLetter,
            "funding_instructions" => ExportListParamsCategory.FundingInstructions,
            "form_1099_int" => ExportListParamsCategory.Form1099Int,
            "form_1099_misc" => ExportListParamsCategory.Form1099Misc,
            "fee_csv" => ExportListParamsCategory.FeeCsv,
            "voided_check" => ExportListParamsCategory.VoidedCheck,
            "daily_account_balance_csv" => ExportListParamsCategory.DailyAccountBalanceCsv,
            _ => (ExportListParamsCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExportListParamsCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExportListParamsCategory.AccountStatementOfx => "account_statement_ofx",
                ExportListParamsCategory.AccountStatementBai2 => "account_statement_bai2",
                ExportListParamsCategory.TransactionCsv => "transaction_csv",
                ExportListParamsCategory.BalanceCsv => "balance_csv",
                ExportListParamsCategory.BookkeepingAccountBalanceCsv =>
                    "bookkeeping_account_balance_csv",
                ExportListParamsCategory.EntityCsv => "entity_csv",
                ExportListParamsCategory.VendorCsv => "vendor_csv",
                ExportListParamsCategory.DashboardTableCsv => "dashboard_table_csv",
                ExportListParamsCategory.AccountVerificationLetter => "account_verification_letter",
                ExportListParamsCategory.FundingInstructions => "funding_instructions",
                ExportListParamsCategory.Form1099Int => "form_1099_int",
                ExportListParamsCategory.Form1099Misc => "form_1099_misc",
                ExportListParamsCategory.FeeCsv => "fee_csv",
                ExportListParamsCategory.VoidedCheck => "voided_check",
                ExportListParamsCategory.DailyAccountBalanceCsv => "daily_account_balance_csv",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ExportListParamsCreatedAt, ExportListParamsCreatedAtFromRaw>)
)]
public sealed record class ExportListParamsCreatedAt : JsonModel
{
    /// <summary>
    /// Return results after this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? After
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("after", value);
        }
    }

    /// <summary>
    /// Return results before this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? Before
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("before", value);
        }
    }

    /// <summary>
    /// Return results on or after this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? OnOrAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("on_or_after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_after", value);
        }
    }

    /// <summary>
    /// Return results on or before this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? OnOrBefore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("on_or_before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_before", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
        _ = this.OnOrAfter;
        _ = this.OnOrBefore;
    }

    public ExportListParamsCreatedAt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportListParamsCreatedAt(ExportListParamsCreatedAt exportListParamsCreatedAt)
        : base(exportListParamsCreatedAt) { }
#pragma warning restore CS8618

    public ExportListParamsCreatedAt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportListParamsCreatedAt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportListParamsCreatedAtFromRaw.FromRawUnchecked"/>
    public static ExportListParamsCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportListParamsCreatedAtFromRaw : IFromRawJson<ExportListParamsCreatedAt>
{
    /// <inheritdoc/>
    public ExportListParamsCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExportListParamsCreatedAt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Form1099Int, Form1099IntFromRaw>))]
public sealed record class Form1099Int : JsonModel
{
    /// <summary>
    /// Filter Form 1099-INT Exports to those for the specified Account.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
    }

    public Form1099Int() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Form1099Int(Form1099Int form1099Int)
        : base(form1099Int) { }
#pragma warning restore CS8618

    public Form1099Int(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Form1099Int(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Form1099IntFromRaw.FromRawUnchecked"/>
    public static Form1099Int FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Form1099IntFromRaw : IFromRawJson<Form1099Int>
{
    /// <inheritdoc/>
    public Form1099Int FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Form1099Int.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Form1099Misc, Form1099MiscFromRaw>))]
public sealed record class Form1099Misc : JsonModel
{
    /// <summary>
    /// Filter Form 1099-MISC Exports to those for the specified Account.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
    }

    public Form1099Misc() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Form1099Misc(Form1099Misc form1099Misc)
        : base(form1099Misc) { }
#pragma warning restore CS8618

    public Form1099Misc(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Form1099Misc(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Form1099MiscFromRaw.FromRawUnchecked"/>
    public static Form1099Misc FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Form1099MiscFromRaw : IFromRawJson<Form1099Misc>
{
    /// <inheritdoc/>
    public Form1099Misc FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Form1099Misc.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Status, StatusFromRaw>))]
public sealed record class Status : JsonModel
{
    /// <summary>
    /// Filter Exports for those with the specified status or statuses. For GET requests,
    /// this should be encoded as a comma-delimited string, such as `?in=one,two,three`.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, In>>? In
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, In>>>("in");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, In>>?>(
                "in",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.In ?? [])
        {
            item.Validate();
        }
    }

    public Status() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Status(Status status)
        : base(status) { }
#pragma warning restore CS8618

    public Status(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Status(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StatusFromRaw.FromRawUnchecked"/>
    public static Status FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StatusFromRaw : IFromRawJson<Status>
{
    /// <inheritdoc/>
    public Status FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Status.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InConverter))]
public enum In
{
    /// <summary>
    /// Increase is generating the export.
    /// </summary>
    Pending,

    /// <summary>
    /// The export has been successfully generated.
    /// </summary>
    Complete,

    /// <summary>
    /// The export failed to generate. Increase will reach out to you to resolve the issue.
    /// </summary>
    Failed,
}

sealed class InConverter : JsonConverter<In>
{
    public override In Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => In.Pending,
            "complete" => In.Complete,
            "failed" => In.Failed,
            _ => (In)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, In value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                In.Pending => "pending",
                In.Complete => "complete",
                In.Failed => "failed",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
