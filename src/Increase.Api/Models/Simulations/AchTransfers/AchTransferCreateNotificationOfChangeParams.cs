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

namespace Increase.Api.Models.Simulations.AchTransfers;

/// <summary>
/// Simulates receiving a Notification of Change for an [ACH Transfer](#ach-transfers).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AchTransferCreateNotificationOfChangeParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? AchTransferID { get; init; }

    /// <summary>
    /// The reason for the notification of change.
    /// </summary>
    public required ApiEnum<string, ChangeCode> ChangeCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, ChangeCode>>("change_code");
        }
        init { this._rawBodyData.Set("change_code", value); }
    }

    /// <summary>
    /// The corrected data for the notification of change (e.g., a new routing number).
    /// </summary>
    public required string CorrectedData
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("corrected_data");
        }
        init { this._rawBodyData.Set("corrected_data", value); }
    }

    public AchTransferCreateNotificationOfChangeParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferCreateNotificationOfChangeParams(
        AchTransferCreateNotificationOfChangeParams achTransferCreateNotificationOfChangeParams
    )
        : base(achTransferCreateNotificationOfChangeParams)
    {
        this.AchTransferID = achTransferCreateNotificationOfChangeParams.AchTransferID;

        this._rawBodyData = new(achTransferCreateNotificationOfChangeParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AchTransferCreateNotificationOfChangeParams(
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
    AchTransferCreateNotificationOfChangeParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string achTransferID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.AchTransferID = achTransferID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AchTransferCreateNotificationOfChangeParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string achTransferID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            achTransferID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["AchTransferID"] = JsonSerializer.SerializeToElement(this.AchTransferID),
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

    public virtual bool Equals(AchTransferCreateNotificationOfChangeParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.AchTransferID?.Equals(other.AchTransferID) ?? other.AchTransferID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/simulations/ach_transfers/{0}/create_notification_of_change",
                    this.AchTransferID
                )
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
/// The reason for the notification of change.
/// </summary>
[JsonConverter(typeof(ChangeCodeConverter))]
public enum ChangeCode
{
    /// <summary>
    /// The account number was incorrect.
    /// </summary>
    IncorrectAccountNumber,

    /// <summary>
    /// The routing number was incorrect.
    /// </summary>
    IncorrectRoutingNumber,

    /// <summary>
    /// Both the routing number and the account number were incorrect.
    /// </summary>
    IncorrectRoutingNumberAndAccountNumber,

    /// <summary>
    /// The transaction code was incorrect. Try changing the `funding` parameter
    /// from checking to savings or vice-versa.
    /// </summary>
    IncorrectTransactionCode,

    /// <summary>
    /// The account number and the transaction code were incorrect.
    /// </summary>
    IncorrectAccountNumberAndTransactionCode,

    /// <summary>
    /// The routing number, account number, and transaction code were incorrect.
    /// </summary>
    IncorrectRoutingNumberAccountNumberAndTransactionCode,

    /// <summary>
    /// The receiving depository financial institution identification was incorrect.
    /// </summary>
    IncorrectReceivingDepositoryFinancialInstitutionIdentification,

    /// <summary>
    /// The individual identification number was incorrect.
    /// </summary>
    IncorrectIndividualIdentificationNumber,

    /// <summary>
    /// The addenda had an incorrect format.
    /// </summary>
    AddendaFormatError,

    /// <summary>
    /// The standard entry class code was incorrect for an outbound international payment.
    /// </summary>
    IncorrectStandardEntryClassCodeForOutboundInternationalPayment,

    /// <summary>
    /// The notification of change was misrouted.
    /// </summary>
    MisroutedNotificationOfChange,

    /// <summary>
    /// The trace number was incorrect.
    /// </summary>
    IncorrectTraceNumber,

    /// <summary>
    /// The company identification number was incorrect.
    /// </summary>
    IncorrectCompanyIdentificationNumber,

    /// <summary>
    /// The individual identification number or identification number was incorrect.
    /// </summary>
    IncorrectIdentificationNumber,

    /// <summary>
    /// The corrected data was incorrectly formatted.
    /// </summary>
    IncorrectlyFormattedCorrectedData,

    /// <summary>
    /// The discretionary data was incorrect.
    /// </summary>
    IncorrectDiscretionaryData,

    /// <summary>
    /// The routing number was not from the original entry detail record.
    /// </summary>
    RoutingNumberNotFromOriginalEntryDetailRecord,

    /// <summary>
    /// The depository financial institution account number was not from the original
    /// entry detail record.
    /// </summary>
    DepositoryFinancialInstitutionAccountNumberNotFromOriginalEntryDetailRecord,

    /// <summary>
    /// The transaction code was incorrect, initiated by the originating depository
    /// financial institution.
    /// </summary>
    IncorrectTransactionCodeByOriginatingDepositoryFinancialInstitution,
}

sealed class ChangeCodeConverter : JsonConverter<ChangeCode>
{
    public override ChangeCode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "incorrect_account_number" => ChangeCode.IncorrectAccountNumber,
            "incorrect_routing_number" => ChangeCode.IncorrectRoutingNumber,
            "incorrect_routing_number_and_account_number" =>
                ChangeCode.IncorrectRoutingNumberAndAccountNumber,
            "incorrect_transaction_code" => ChangeCode.IncorrectTransactionCode,
            "incorrect_account_number_and_transaction_code" =>
                ChangeCode.IncorrectAccountNumberAndTransactionCode,
            "incorrect_routing_number_account_number_and_transaction_code" =>
                ChangeCode.IncorrectRoutingNumberAccountNumberAndTransactionCode,
            "incorrect_receiving_depository_financial_institution_identification" =>
                ChangeCode.IncorrectReceivingDepositoryFinancialInstitutionIdentification,
            "incorrect_individual_identification_number" =>
                ChangeCode.IncorrectIndividualIdentificationNumber,
            "addenda_format_error" => ChangeCode.AddendaFormatError,
            "incorrect_standard_entry_class_code_for_outbound_international_payment" =>
                ChangeCode.IncorrectStandardEntryClassCodeForOutboundInternationalPayment,
            "misrouted_notification_of_change" => ChangeCode.MisroutedNotificationOfChange,
            "incorrect_trace_number" => ChangeCode.IncorrectTraceNumber,
            "incorrect_company_identification_number" =>
                ChangeCode.IncorrectCompanyIdentificationNumber,
            "incorrect_identification_number" => ChangeCode.IncorrectIdentificationNumber,
            "incorrectly_formatted_corrected_data" => ChangeCode.IncorrectlyFormattedCorrectedData,
            "incorrect_discretionary_data" => ChangeCode.IncorrectDiscretionaryData,
            "routing_number_not_from_original_entry_detail_record" =>
                ChangeCode.RoutingNumberNotFromOriginalEntryDetailRecord,
            "depository_financial_institution_account_number_not_from_original_entry_detail_record" =>
                ChangeCode.DepositoryFinancialInstitutionAccountNumberNotFromOriginalEntryDetailRecord,
            "incorrect_transaction_code_by_originating_depository_financial_institution" =>
                ChangeCode.IncorrectTransactionCodeByOriginatingDepositoryFinancialInstitution,
            _ => (ChangeCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChangeCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChangeCode.IncorrectAccountNumber => "incorrect_account_number",
                ChangeCode.IncorrectRoutingNumber => "incorrect_routing_number",
                ChangeCode.IncorrectRoutingNumberAndAccountNumber =>
                    "incorrect_routing_number_and_account_number",
                ChangeCode.IncorrectTransactionCode => "incorrect_transaction_code",
                ChangeCode.IncorrectAccountNumberAndTransactionCode =>
                    "incorrect_account_number_and_transaction_code",
                ChangeCode.IncorrectRoutingNumberAccountNumberAndTransactionCode =>
                    "incorrect_routing_number_account_number_and_transaction_code",
                ChangeCode.IncorrectReceivingDepositoryFinancialInstitutionIdentification =>
                    "incorrect_receiving_depository_financial_institution_identification",
                ChangeCode.IncorrectIndividualIdentificationNumber =>
                    "incorrect_individual_identification_number",
                ChangeCode.AddendaFormatError => "addenda_format_error",
                ChangeCode.IncorrectStandardEntryClassCodeForOutboundInternationalPayment =>
                    "incorrect_standard_entry_class_code_for_outbound_international_payment",
                ChangeCode.MisroutedNotificationOfChange => "misrouted_notification_of_change",
                ChangeCode.IncorrectTraceNumber => "incorrect_trace_number",
                ChangeCode.IncorrectCompanyIdentificationNumber =>
                    "incorrect_company_identification_number",
                ChangeCode.IncorrectIdentificationNumber => "incorrect_identification_number",
                ChangeCode.IncorrectlyFormattedCorrectedData =>
                    "incorrectly_formatted_corrected_data",
                ChangeCode.IncorrectDiscretionaryData => "incorrect_discretionary_data",
                ChangeCode.RoutingNumberNotFromOriginalEntryDetailRecord =>
                    "routing_number_not_from_original_entry_detail_record",
                ChangeCode.DepositoryFinancialInstitutionAccountNumberNotFromOriginalEntryDetailRecord =>
                    "depository_financial_institution_account_number_not_from_original_entry_detail_record",
                ChangeCode.IncorrectTransactionCodeByOriginatingDepositoryFinancialInstitution =>
                    "incorrect_transaction_code_by_originating_depository_financial_institution",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
