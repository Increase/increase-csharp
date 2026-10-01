using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;

namespace Increase.Api.Models.Simulations.FednowTransfers;

/// <summary>
/// Simulates submission of a [FedNow Transfer](#fednow-transfers) and handling the
/// response from the destination financial institution. This transfer must first
/// have a `status` of `pending_submitting`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FednowTransferCompleteParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? FednowTransferID { get; init; }

    /// <summary>
    /// If set, the simulation will reject the transfer.
    /// </summary>
    public Rejection? Rejection
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Rejection>("rejection");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("rejection", value);
        }
    }

    public FednowTransferCompleteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FednowTransferCompleteParams(FednowTransferCompleteParams fednowTransferCompleteParams)
        : base(fednowTransferCompleteParams)
    {
        this.FednowTransferID = fednowTransferCompleteParams.FednowTransferID;

        this._rawBodyData = new(fednowTransferCompleteParams._rawBodyData);
    }
#pragma warning restore CS8618

    public FednowTransferCompleteParams(
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
    FednowTransferCompleteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string fednowTransferID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.FednowTransferID = fednowTransferID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FednowTransferCompleteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string fednowTransferID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            fednowTransferID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["FednowTransferID"] = JsonSerializer.SerializeToElement(this.FednowTransferID),
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

    public virtual bool Equals(FednowTransferCompleteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.FednowTransferID?.Equals(other.FednowTransferID)
                ?? other.FednowTransferID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/simulations/fednow_transfers/{0}/complete", this.FednowTransferID)
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
/// If set, the simulation will reject the transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Rejection, RejectionFromRaw>))]
public sealed record class Rejection : JsonModel
{
    /// <summary>
    /// The reason code that the simulated rejection will have.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.RejectReasonCode.Validate();
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

    [SetsRequiredMembers]
    public Rejection(ApiEnum<string, RejectReasonCode> rejectReasonCode)
        : this()
    {
        this.RejectReasonCode = rejectReasonCode;
    }
}

class RejectionFromRaw : IFromRawJson<Rejection>
{
    /// <inheritdoc/>
    public Rejection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Rejection.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason code that the simulated rejection will have.
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
        Type typeToConvert,
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
