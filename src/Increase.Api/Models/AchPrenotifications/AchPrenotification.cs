using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.AchPrenotifications;

/// <summary>
/// ACH Prenotifications are one way you can verify account and routing numbers by
/// Automated Clearing House (ACH).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AchPrenotification, AchPrenotificationFromRaw>))]
public sealed record class AchPrenotification : JsonModel
{
    /// <summary>
    /// The ACH Prenotification's identifier.
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
    /// The account that sent the ACH Prenotification.
    /// </summary>
    public required string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
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
    /// Additional information for the recipient.
    /// </summary>
    public required string? Addendum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("addendum");
        }
        init { this._rawData.Set("addendum", value); }
    }

    /// <summary>
    /// The description of the date of the notification.
    /// </summary>
    public required string? CompanyDescriptiveDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_descriptive_date");
        }
        init { this._rawData.Set("company_descriptive_date", value); }
    }

    /// <summary>
    /// Optional data associated with the notification.
    /// </summary>
    public required string? CompanyDiscretionaryData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_discretionary_data");
        }
        init { this._rawData.Set("company_discretionary_data", value); }
    }

    /// <summary>
    /// The description of the notification.
    /// </summary>
    public required string? CompanyEntryDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_entry_description");
        }
        init { this._rawData.Set("company_entry_description", value); }
    }

    /// <summary>
    /// The name by which you know the company.
    /// </summary>
    public required string? CompanyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_name");
        }
        init { this._rawData.Set("company_name", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the prenotification was created.
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
    /// If the notification is for a future credit or debit.
    /// </summary>
    public required ApiEnum<string, AchPrenotificationCreditDebitIndicator>? CreditDebitIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, AchPrenotificationCreditDebitIndicator>
            >("credit_debit_indicator");
        }
        init { this._rawData.Set("credit_debit_indicator", value); }
    }

    /// <summary>
    /// The effective date in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format.
    /// </summary>
    public required System::DateTimeOffset? EffectiveDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("effective_date");
        }
        init { this._rawData.Set("effective_date", value); }
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
    /// Your identifier for the recipient.
    /// </summary>
    public required string? IndividualID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("individual_id");
        }
        init { this._rawData.Set("individual_id", value); }
    }

    /// <summary>
    /// The name of the recipient. This value is informational and not verified by
    /// the recipient's bank.
    /// </summary>
    public required string? IndividualName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("individual_name");
        }
        init { this._rawData.Set("individual_name", value); }
    }

    /// <summary>
    /// If the receiving bank notifies that future transfers should use different
    /// details, this will contain those details.
    /// </summary>
    public required IReadOnlyList<NotificationsOfChange> NotificationsOfChange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<NotificationsOfChange>>(
                "notifications_of_change"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<NotificationsOfChange>>(
                "notifications_of_change",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// If your prenotification is returned, this will contain details of the return.
    /// </summary>
    public required PrenotificationReturn? PrenotificationReturn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PrenotificationReturn>("prenotification_return");
        }
        init { this._rawData.Set("prenotification_return", value); }
    }

    /// <summary>
    /// The American Bankers' Association (ABA) Routing Transit Number (RTN).
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
    /// The [Standard Entry Class (SEC) code](/documentation/ach-standard-entry-class-codes)
    /// to use for the ACH Prenotification.
    /// </summary>
    public required ApiEnum<
        string,
        AchPrenotificationStandardEntryClassCode
    >? StandardEntryClassCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, AchPrenotificationStandardEntryClassCode>
            >("standard_entry_class_code");
        }
        init { this._rawData.Set("standard_entry_class_code", value); }
    }

    /// <summary>
    /// The lifecycle status of the ACH Prenotification.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `ach_prenotification`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.AchPrenotifications.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.AchPrenotifications.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.AccountNumber;
        _ = this.Addendum;
        _ = this.CompanyDescriptiveDate;
        _ = this.CompanyDiscretionaryData;
        _ = this.CompanyEntryDescription;
        _ = this.CompanyName;
        _ = this.CreatedAt;
        this.CreditDebitIndicator?.Validate();
        _ = this.EffectiveDate;
        _ = this.IdempotencyKey;
        _ = this.IndividualID;
        _ = this.IndividualName;
        foreach (var item in this.NotificationsOfChange)
        {
            item.Validate();
        }
        this.PrenotificationReturn?.Validate();
        _ = this.RoutingNumber;
        this.StandardEntryClassCode?.Validate();
        this.Status.Validate();
        this.Type.Validate();
    }

    public AchPrenotification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchPrenotification(AchPrenotification achPrenotification)
        : base(achPrenotification) { }
#pragma warning restore CS8618

    public AchPrenotification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AchPrenotification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AchPrenotificationFromRaw.FromRawUnchecked"/>
    public static AchPrenotification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AchPrenotificationFromRaw : IFromRawJson<AchPrenotification>
{
    /// <inheritdoc/>
    public AchPrenotification FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AchPrenotification.FromRawUnchecked(rawData);
}

/// <summary>
/// If the notification is for a future credit or debit.
/// </summary>
[JsonConverter(typeof(AchPrenotificationCreditDebitIndicatorConverter))]
public enum AchPrenotificationCreditDebitIndicator
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

sealed class AchPrenotificationCreditDebitIndicatorConverter
    : JsonConverter<AchPrenotificationCreditDebitIndicator>
{
    public override AchPrenotificationCreditDebitIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit" => AchPrenotificationCreditDebitIndicator.Credit,
            "debit" => AchPrenotificationCreditDebitIndicator.Debit,
            _ => (AchPrenotificationCreditDebitIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AchPrenotificationCreditDebitIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AchPrenotificationCreditDebitIndicator.Credit => "credit",
                AchPrenotificationCreditDebitIndicator.Debit => "debit",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<NotificationsOfChange, NotificationsOfChangeFromRaw>))]
public sealed record class NotificationsOfChange : JsonModel
{
    /// <summary>
    /// The required type of change that is being signaled by the receiving financial institution.
    /// </summary>
    public required ApiEnum<string, ChangeCode> ChangeCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ChangeCode>>("change_code");
        }
        init { this._rawData.Set("change_code", value); }
    }

    /// <summary>
    /// The corrected data that should be used in future ACHs to this account. This
    /// may contain the suggested new account number or routing number. When the
    /// `change_code` is `incorrect_transaction_code`, this field contains an integer.
    /// Numbers starting with a 2 encourage changing the `funding` parameter to checking;
    /// numbers starting with a 3 encourage changing to savings.
    /// </summary>
    public required string CorrectedData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("corrected_data");
        }
        init { this._rawData.Set("corrected_data", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the notification occurred.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ChangeCode.Validate();
        _ = this.CorrectedData;
        _ = this.CreatedAt;
    }

    public NotificationsOfChange() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationsOfChange(NotificationsOfChange notificationsOfChange)
        : base(notificationsOfChange) { }
#pragma warning restore CS8618

    public NotificationsOfChange(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationsOfChange(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationsOfChangeFromRaw.FromRawUnchecked"/>
    public static NotificationsOfChange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationsOfChangeFromRaw : IFromRawJson<NotificationsOfChange>
{
    /// <inheritdoc/>
    public NotificationsOfChange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationsOfChange.FromRawUnchecked(rawData);
}

/// <summary>
/// The required type of change that is being signaled by the receiving financial institution.
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
        System::Type typeToConvert,
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

/// <summary>
/// If your prenotification is returned, this will contain details of the return.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PrenotificationReturn, PrenotificationReturnFromRaw>))]
public sealed record class PrenotificationReturn : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Prenotification was returned.
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
    /// Why the Prenotification was returned.
    /// </summary>
    public required ApiEnum<string, ReturnReasonCode> ReturnReasonCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ReturnReasonCode>>(
                "return_reason_code"
            );
        }
        init { this._rawData.Set("return_reason_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        this.ReturnReasonCode.Validate();
    }

    public PrenotificationReturn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PrenotificationReturn(PrenotificationReturn prenotificationReturn)
        : base(prenotificationReturn) { }
#pragma warning restore CS8618

    public PrenotificationReturn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PrenotificationReturn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PrenotificationReturnFromRaw.FromRawUnchecked"/>
    public static PrenotificationReturn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PrenotificationReturnFromRaw : IFromRawJson<PrenotificationReturn>
{
    /// <inheritdoc/>
    public PrenotificationReturn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PrenotificationReturn.FromRawUnchecked(rawData);
}

/// <summary>
/// Why the Prenotification was returned.
/// </summary>
[JsonConverter(typeof(ReturnReasonCodeConverter))]
public enum ReturnReasonCode
{
    /// <summary>
    /// Code R01. Insufficient funds in the receiving account. Sometimes abbreviated
    /// to "NSF."
    /// </summary>
    InsufficientFund,

    /// <summary>
    /// Code R03. The account does not exist or the receiving bank was unable to
    /// locate it.
    /// </summary>
    NoAccount,

    /// <summary>
    /// Code R02. The account is closed at the receiving bank.
    /// </summary>
    AccountClosed,

    /// <summary>
    /// Code R04. The account number is invalid at the receiving bank.
    /// </summary>
    InvalidAccountNumberStructure,

    /// <summary>
    /// Code R16. This return code has two separate meanings. (1) The receiving bank
    /// froze the account or (2) the Office of Foreign Assets Control (OFAC) instructed
    /// the receiving bank to return the entry.
    /// </summary>
    AccountFrozenEntryReturnedPerOfacInstruction,

    /// <summary>
    /// Code R23. The receiving bank refused the credit transfer.
    /// </summary>
    CreditEntryRefusedByReceiver,

    /// <summary>
    /// Code R05. The receiving bank rejected because of an incorrect Standard Entry
    /// Class code. Consumer accounts cannot be debited as `corporate_credit_or_debit`
    /// or `corporate_trade_exchange`.
    /// </summary>
    UnauthorizedDebitToConsumerAccountUsingCorporateSecCode,

    /// <summary>
    /// Code R29. The corporate customer at the receiving bank reversed the transfer.
    /// </summary>
    CorporateCustomerAdvisedNotAuthorized,

    /// <summary>
    /// Code R08. The receiving bank stopped payment on this transfer.
    /// </summary>
    PaymentStopped,

    /// <summary>
    /// Code R20. The account is not eligible for ACH, such as a savings account
    /// with transaction limits.
    /// </summary>
    NonTransactionAccount,

    /// <summary>
    /// Code R09. The receiving bank account does not have enough available balance
    /// for the transfer.
    /// </summary>
    UncollectedFunds,

    /// <summary>
    /// Code R28. The routing number is incorrect.
    /// </summary>
    RoutingNumberCheckDigitError,

    /// <summary>
    /// Code R10. The customer at the receiving bank reversed the transfer.
    /// </summary>
    CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete,

    /// <summary>
    /// Code R19. The amount field is incorrect or too large.
    /// </summary>
    AmountFieldError,

    /// <summary>
    /// Code R07. The customer revoked their authorization for a previously authorized transfer.
    /// </summary>
    AuthorizationRevokedByCustomer,

    /// <summary>
    /// Code R13. The routing number is invalid.
    /// </summary>
    InvalidAchRoutingNumber,

    /// <summary>
    /// Code R17. The receiving bank is unable to process a field in the transfer.
    /// </summary>
    FileRecordEditCriteria,

    /// <summary>
    /// Code R45. A rare return reason. The individual name field was invalid.
    /// </summary>
    EnrInvalidIndividualName,

    /// <summary>
    /// Code R06. The originating financial institution asked for this transfer to
    /// be returned. The receiving bank is complying with the request.
    /// </summary>
    ReturnedPerOdfiRequest,

    /// <summary>
    /// Code R34. The receiving bank's regulatory supervisor has limited their participation
    /// in the ACH network.
    /// </summary>
    LimitedParticipationDfi,

    /// <summary>
    /// Code R85. The outbound international ACH transfer was incorrect.
    /// </summary>
    IncorrectlyCodedOutboundInternationalPayment,

    /// <summary>
    /// Code R12. A rare return reason. The account was sold to another bank.
    /// </summary>
    AccountSoldToAnotherDfi,

    /// <summary>
    /// Code R25. The addenda record is incorrect or missing.
    /// </summary>
    AddendaError,

    /// <summary>
    /// Code R15. A rare return reason. The account holder is deceased.
    /// </summary>
    BeneficiaryOrAccountHolderDeceased,

    /// <summary>
    /// Code R11. A rare return reason. The customer authorized some payment to the
    /// sender, but this payment was not in error.
    /// </summary>
    CustomerAdvisedNotWithinAuthorizationTerms,

    /// <summary>
    /// Code R74. A rare return reason. Sent in response to a return that was returned
    /// with code `field_error`. The latest return should include the corrected field(s).
    /// </summary>
    CorrectedReturn,

    /// <summary>
    /// Code R24. A rare return reason. The receiving bank received an exact duplicate
    /// entry with the same trace number and amount.
    /// </summary>
    DuplicateEntry,

    /// <summary>
    /// Code R67. A rare return reason. The return this message refers to was a duplicate.
    /// </summary>
    DuplicateReturn,

    /// <summary>
    /// Code R47. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrDuplicateEnrollment,

    /// <summary>
    /// Code R43. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrInvalidDfiAccountNumber,

    /// <summary>
    /// Code R44. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrInvalidIndividualIDNumber,

    /// <summary>
    /// Code R46. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrInvalidRepresentativePayeeIndicator,

    /// <summary>
    /// Code R41. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrInvalidTransactionCode,

    /// <summary>
    /// Code R40. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrReturnOfEnrEntry,

    /// <summary>
    /// Code R42. A rare return reason. Only used for US Government agency non-monetary
    /// automatic enrollment messages.
    /// </summary>
    EnrRoutingNumberCheckDigitError,

    /// <summary>
    /// Code R84. A rare return reason. The International ACH Transfer cannot be
    /// processed by the gateway.
    /// </summary>
    EntryNotProcessedByGateway,

    /// <summary>
    /// Code R69. A rare return reason. One or more of the fields in the ACH were malformed.
    /// </summary>
    FieldError,

    /// <summary>
    /// Code R83. A rare return reason. The Foreign receiving bank was unable to settle
    /// this ACH transfer.
    /// </summary>
    ForeignReceivingDfiUnableToSettle,

    /// <summary>
    /// Code R80. A rare return reason. The International ACH Transfer is malformed.
    /// </summary>
    IatEntryCodingError,

    /// <summary>
    /// Code R18. A rare return reason. The ACH has an improper effective entry date field.
    /// </summary>
    ImproperEffectiveEntryDate,

    /// <summary>
    /// Code R39. A rare return reason. The source document related to this ACH, usually
    /// an ACH check conversion, was presented to the bank.
    /// </summary>
    ImproperSourceDocumentSourceDocumentPresented,

    /// <summary>
    /// Code R21. A rare return reason. The Company ID field of the ACH was invalid.
    /// </summary>
    InvalidCompanyID,

    /// <summary>
    /// Code R82. A rare return reason. The foreign receiving bank identifier for
    /// an International ACH Transfer was invalid.
    /// </summary>
    InvalidForeignReceivingDfiIdentification,

    /// <summary>
    /// Code R22. A rare return reason. The Individual ID number field of the ACH
    /// was invalid.
    /// </summary>
    InvalidIndividualIDNumber,

    /// <summary>
    /// Code R53. A rare return reason. Both the Represented Check ("RCK") entry
    /// and the original check were presented to the bank.
    /// </summary>
    ItemAndRckEntryPresentedForPayment,

    /// <summary>
    /// Code R51. A rare return reason. The Represented Check ("RCK") entry is ineligible.
    /// </summary>
    ItemRelatedToRckEntryIsIneligible,

    /// <summary>
    /// Code R26. A rare return reason. The ACH is missing a required field.
    /// </summary>
    MandatoryFieldError,

    /// <summary>
    /// Code R71. A rare return reason. The receiving bank does not recognize the
    /// routing number in a dishonored return entry.
    /// </summary>
    MisroutedDishonoredReturn,

    /// <summary>
    /// Code R61. A rare return reason. The receiving bank does not recognize the
    /// routing number in a return entry.
    /// </summary>
    MisroutedReturn,

    /// <summary>
    /// Code R76. A rare return reason. Sent in response to a return, the bank does
    /// not find the errors alleged by the returning bank.
    /// </summary>
    NoErrorsFound,

    /// <summary>
    /// Code R77. A rare return reason. The receiving bank does not accept the return
    /// of the erroneous debit. The funds are not available at the receiving bank.
    /// </summary>
    NonAcceptanceOfR62DishonoredReturn,

    /// <summary>
    /// Code R81. A rare return reason. The receiving bank does not accept International
    /// ACH Transfers.
    /// </summary>
    NonParticipantInIatProgram,

    /// <summary>
    /// Code R31. A rare return reason. A return that has been agreed to be accepted
    /// by the receiving bank, despite falling outside of the usual return timeframe.
    /// </summary>
    PermissibleReturnEntry,

    /// <summary>
    /// Code R70. A rare return reason. The receiving bank had not approved this return.
    /// </summary>
    PermissibleReturnEntryNotAccepted,

    /// <summary>
    /// Code R32. A rare return reason. The receiving bank could not settle this transaction.
    /// </summary>
    RdfiNonSettlement,

    /// <summary>
    /// Code R30. A rare return reason. The receiving bank does not accept Check Truncation
    /// ACH transfers.
    /// </summary>
    RdfiParticipantInCheckTruncationProgram,

    /// <summary>
    /// Code R14. A rare return reason. The payee is deceased.
    /// </summary>
    RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity,

    /// <summary>
    /// Code R75. A rare return reason. The originating bank disputes that an earlier
    /// `duplicate_entry` return was actually a duplicate.
    /// </summary>
    ReturnNotADuplicate,

    /// <summary>
    /// Code R62. A rare return reason. The originating financial institution made
    /// a mistake and this return corrects it.
    /// </summary>
    ReturnOfErroneousOrReversingDebit,

    /// <summary>
    /// Code R36. A rare return reason. Return of a malformed credit entry.
    /// </summary>
    ReturnOfImproperCreditEntry,

    /// <summary>
    /// Code R35. A rare return reason. Return of a malformed debit entry.
    /// </summary>
    ReturnOfImproperDebitEntry,

    /// <summary>
    /// Code R33. A rare return reason. Return of a destroyed check ("XCK") entry.
    /// </summary>
    ReturnOfXckEntry,

    /// <summary>
    /// Code R37. A rare return reason. The source document related to this ACH, usually
    /// an ACH check conversion, was presented to the bank.
    /// </summary>
    SourceDocumentPresentedForPayment,

    /// <summary>
    /// Code R50. A rare return reason. State law prevents the bank from accepting
    /// the Represented Check ("RCK") entry.
    /// </summary>
    StateLawAffectingRckAcceptance,

    /// <summary>
    /// Code R52. A rare return reason. A stop payment was issued on a Represented
    /// Check ("RCK") entry.
    /// </summary>
    StopPaymentOnItemRelatedToRckEntry,

    /// <summary>
    /// Code R38. A rare return reason. The source attached to the ACH, usually an
    /// ACH check conversion, includes a stop payment.
    /// </summary>
    StopPaymentOnSourceDocument,

    /// <summary>
    /// Code R73. A rare return reason. The bank receiving an `untimely_return` believes
    /// it was on time.
    /// </summary>
    TimelyOriginalReturn,

    /// <summary>
    /// Code R27. A rare return reason. An ACH return's trace number does not match
    /// an originated ACH.
    /// </summary>
    TraceNumberError,

    /// <summary>
    /// Code R72. A rare return reason. The dishonored return was sent too late.
    /// </summary>
    UntimelyDishonoredReturn,

    /// <summary>
    /// Code R68. A rare return reason. The return was sent too late.
    /// </summary>
    UntimelyReturn,
}

sealed class ReturnReasonCodeConverter : JsonConverter<ReturnReasonCode>
{
    public override ReturnReasonCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_fund" => ReturnReasonCode.InsufficientFund,
            "no_account" => ReturnReasonCode.NoAccount,
            "account_closed" => ReturnReasonCode.AccountClosed,
            "invalid_account_number_structure" => ReturnReasonCode.InvalidAccountNumberStructure,
            "account_frozen_entry_returned_per_ofac_instruction" =>
                ReturnReasonCode.AccountFrozenEntryReturnedPerOfacInstruction,
            "credit_entry_refused_by_receiver" => ReturnReasonCode.CreditEntryRefusedByReceiver,
            "unauthorized_debit_to_consumer_account_using_corporate_sec_code" =>
                ReturnReasonCode.UnauthorizedDebitToConsumerAccountUsingCorporateSecCode,
            "corporate_customer_advised_not_authorized" =>
                ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized,
            "payment_stopped" => ReturnReasonCode.PaymentStopped,
            "non_transaction_account" => ReturnReasonCode.NonTransactionAccount,
            "uncollected_funds" => ReturnReasonCode.UncollectedFunds,
            "routing_number_check_digit_error" => ReturnReasonCode.RoutingNumberCheckDigitError,
            "customer_advised_unauthorized_improper_ineligible_or_incomplete" =>
                ReturnReasonCode.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete,
            "amount_field_error" => ReturnReasonCode.AmountFieldError,
            "authorization_revoked_by_customer" => ReturnReasonCode.AuthorizationRevokedByCustomer,
            "invalid_ach_routing_number" => ReturnReasonCode.InvalidAchRoutingNumber,
            "file_record_edit_criteria" => ReturnReasonCode.FileRecordEditCriteria,
            "enr_invalid_individual_name" => ReturnReasonCode.EnrInvalidIndividualName,
            "returned_per_odfi_request" => ReturnReasonCode.ReturnedPerOdfiRequest,
            "limited_participation_dfi" => ReturnReasonCode.LimitedParticipationDfi,
            "incorrectly_coded_outbound_international_payment" =>
                ReturnReasonCode.IncorrectlyCodedOutboundInternationalPayment,
            "account_sold_to_another_dfi" => ReturnReasonCode.AccountSoldToAnotherDfi,
            "addenda_error" => ReturnReasonCode.AddendaError,
            "beneficiary_or_account_holder_deceased" =>
                ReturnReasonCode.BeneficiaryOrAccountHolderDeceased,
            "customer_advised_not_within_authorization_terms" =>
                ReturnReasonCode.CustomerAdvisedNotWithinAuthorizationTerms,
            "corrected_return" => ReturnReasonCode.CorrectedReturn,
            "duplicate_entry" => ReturnReasonCode.DuplicateEntry,
            "duplicate_return" => ReturnReasonCode.DuplicateReturn,
            "enr_duplicate_enrollment" => ReturnReasonCode.EnrDuplicateEnrollment,
            "enr_invalid_dfi_account_number" => ReturnReasonCode.EnrInvalidDfiAccountNumber,
            "enr_invalid_individual_id_number" => ReturnReasonCode.EnrInvalidIndividualIDNumber,
            "enr_invalid_representative_payee_indicator" =>
                ReturnReasonCode.EnrInvalidRepresentativePayeeIndicator,
            "enr_invalid_transaction_code" => ReturnReasonCode.EnrInvalidTransactionCode,
            "enr_return_of_enr_entry" => ReturnReasonCode.EnrReturnOfEnrEntry,
            "enr_routing_number_check_digit_error" =>
                ReturnReasonCode.EnrRoutingNumberCheckDigitError,
            "entry_not_processed_by_gateway" => ReturnReasonCode.EntryNotProcessedByGateway,
            "field_error" => ReturnReasonCode.FieldError,
            "foreign_receiving_dfi_unable_to_settle" =>
                ReturnReasonCode.ForeignReceivingDfiUnableToSettle,
            "iat_entry_coding_error" => ReturnReasonCode.IatEntryCodingError,
            "improper_effective_entry_date" => ReturnReasonCode.ImproperEffectiveEntryDate,
            "improper_source_document_source_document_presented" =>
                ReturnReasonCode.ImproperSourceDocumentSourceDocumentPresented,
            "invalid_company_id" => ReturnReasonCode.InvalidCompanyID,
            "invalid_foreign_receiving_dfi_identification" =>
                ReturnReasonCode.InvalidForeignReceivingDfiIdentification,
            "invalid_individual_id_number" => ReturnReasonCode.InvalidIndividualIDNumber,
            "item_and_rck_entry_presented_for_payment" =>
                ReturnReasonCode.ItemAndRckEntryPresentedForPayment,
            "item_related_to_rck_entry_is_ineligible" =>
                ReturnReasonCode.ItemRelatedToRckEntryIsIneligible,
            "mandatory_field_error" => ReturnReasonCode.MandatoryFieldError,
            "misrouted_dishonored_return" => ReturnReasonCode.MisroutedDishonoredReturn,
            "misrouted_return" => ReturnReasonCode.MisroutedReturn,
            "no_errors_found" => ReturnReasonCode.NoErrorsFound,
            "non_acceptance_of_r62_dishonored_return" =>
                ReturnReasonCode.NonAcceptanceOfR62DishonoredReturn,
            "non_participant_in_iat_program" => ReturnReasonCode.NonParticipantInIatProgram,
            "permissible_return_entry" => ReturnReasonCode.PermissibleReturnEntry,
            "permissible_return_entry_not_accepted" =>
                ReturnReasonCode.PermissibleReturnEntryNotAccepted,
            "rdfi_non_settlement" => ReturnReasonCode.RdfiNonSettlement,
            "rdfi_participant_in_check_truncation_program" =>
                ReturnReasonCode.RdfiParticipantInCheckTruncationProgram,
            "representative_payee_deceased_or_unable_to_continue_in_that_capacity" =>
                ReturnReasonCode.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity,
            "return_not_a_duplicate" => ReturnReasonCode.ReturnNotADuplicate,
            "return_of_erroneous_or_reversing_debit" =>
                ReturnReasonCode.ReturnOfErroneousOrReversingDebit,
            "return_of_improper_credit_entry" => ReturnReasonCode.ReturnOfImproperCreditEntry,
            "return_of_improper_debit_entry" => ReturnReasonCode.ReturnOfImproperDebitEntry,
            "return_of_xck_entry" => ReturnReasonCode.ReturnOfXckEntry,
            "source_document_presented_for_payment" =>
                ReturnReasonCode.SourceDocumentPresentedForPayment,
            "state_law_affecting_rck_acceptance" => ReturnReasonCode.StateLawAffectingRckAcceptance,
            "stop_payment_on_item_related_to_rck_entry" =>
                ReturnReasonCode.StopPaymentOnItemRelatedToRckEntry,
            "stop_payment_on_source_document" => ReturnReasonCode.StopPaymentOnSourceDocument,
            "timely_original_return" => ReturnReasonCode.TimelyOriginalReturn,
            "trace_number_error" => ReturnReasonCode.TraceNumberError,
            "untimely_dishonored_return" => ReturnReasonCode.UntimelyDishonoredReturn,
            "untimely_return" => ReturnReasonCode.UntimelyReturn,
            _ => (ReturnReasonCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReturnReasonCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReturnReasonCode.InsufficientFund => "insufficient_fund",
                ReturnReasonCode.NoAccount => "no_account",
                ReturnReasonCode.AccountClosed => "account_closed",
                ReturnReasonCode.InvalidAccountNumberStructure =>
                    "invalid_account_number_structure",
                ReturnReasonCode.AccountFrozenEntryReturnedPerOfacInstruction =>
                    "account_frozen_entry_returned_per_ofac_instruction",
                ReturnReasonCode.CreditEntryRefusedByReceiver => "credit_entry_refused_by_receiver",
                ReturnReasonCode.UnauthorizedDebitToConsumerAccountUsingCorporateSecCode =>
                    "unauthorized_debit_to_consumer_account_using_corporate_sec_code",
                ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized =>
                    "corporate_customer_advised_not_authorized",
                ReturnReasonCode.PaymentStopped => "payment_stopped",
                ReturnReasonCode.NonTransactionAccount => "non_transaction_account",
                ReturnReasonCode.UncollectedFunds => "uncollected_funds",
                ReturnReasonCode.RoutingNumberCheckDigitError => "routing_number_check_digit_error",
                ReturnReasonCode.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete =>
                    "customer_advised_unauthorized_improper_ineligible_or_incomplete",
                ReturnReasonCode.AmountFieldError => "amount_field_error",
                ReturnReasonCode.AuthorizationRevokedByCustomer =>
                    "authorization_revoked_by_customer",
                ReturnReasonCode.InvalidAchRoutingNumber => "invalid_ach_routing_number",
                ReturnReasonCode.FileRecordEditCriteria => "file_record_edit_criteria",
                ReturnReasonCode.EnrInvalidIndividualName => "enr_invalid_individual_name",
                ReturnReasonCode.ReturnedPerOdfiRequest => "returned_per_odfi_request",
                ReturnReasonCode.LimitedParticipationDfi => "limited_participation_dfi",
                ReturnReasonCode.IncorrectlyCodedOutboundInternationalPayment =>
                    "incorrectly_coded_outbound_international_payment",
                ReturnReasonCode.AccountSoldToAnotherDfi => "account_sold_to_another_dfi",
                ReturnReasonCode.AddendaError => "addenda_error",
                ReturnReasonCode.BeneficiaryOrAccountHolderDeceased =>
                    "beneficiary_or_account_holder_deceased",
                ReturnReasonCode.CustomerAdvisedNotWithinAuthorizationTerms =>
                    "customer_advised_not_within_authorization_terms",
                ReturnReasonCode.CorrectedReturn => "corrected_return",
                ReturnReasonCode.DuplicateEntry => "duplicate_entry",
                ReturnReasonCode.DuplicateReturn => "duplicate_return",
                ReturnReasonCode.EnrDuplicateEnrollment => "enr_duplicate_enrollment",
                ReturnReasonCode.EnrInvalidDfiAccountNumber => "enr_invalid_dfi_account_number",
                ReturnReasonCode.EnrInvalidIndividualIDNumber => "enr_invalid_individual_id_number",
                ReturnReasonCode.EnrInvalidRepresentativePayeeIndicator =>
                    "enr_invalid_representative_payee_indicator",
                ReturnReasonCode.EnrInvalidTransactionCode => "enr_invalid_transaction_code",
                ReturnReasonCode.EnrReturnOfEnrEntry => "enr_return_of_enr_entry",
                ReturnReasonCode.EnrRoutingNumberCheckDigitError =>
                    "enr_routing_number_check_digit_error",
                ReturnReasonCode.EntryNotProcessedByGateway => "entry_not_processed_by_gateway",
                ReturnReasonCode.FieldError => "field_error",
                ReturnReasonCode.ForeignReceivingDfiUnableToSettle =>
                    "foreign_receiving_dfi_unable_to_settle",
                ReturnReasonCode.IatEntryCodingError => "iat_entry_coding_error",
                ReturnReasonCode.ImproperEffectiveEntryDate => "improper_effective_entry_date",
                ReturnReasonCode.ImproperSourceDocumentSourceDocumentPresented =>
                    "improper_source_document_source_document_presented",
                ReturnReasonCode.InvalidCompanyID => "invalid_company_id",
                ReturnReasonCode.InvalidForeignReceivingDfiIdentification =>
                    "invalid_foreign_receiving_dfi_identification",
                ReturnReasonCode.InvalidIndividualIDNumber => "invalid_individual_id_number",
                ReturnReasonCode.ItemAndRckEntryPresentedForPayment =>
                    "item_and_rck_entry_presented_for_payment",
                ReturnReasonCode.ItemRelatedToRckEntryIsIneligible =>
                    "item_related_to_rck_entry_is_ineligible",
                ReturnReasonCode.MandatoryFieldError => "mandatory_field_error",
                ReturnReasonCode.MisroutedDishonoredReturn => "misrouted_dishonored_return",
                ReturnReasonCode.MisroutedReturn => "misrouted_return",
                ReturnReasonCode.NoErrorsFound => "no_errors_found",
                ReturnReasonCode.NonAcceptanceOfR62DishonoredReturn =>
                    "non_acceptance_of_r62_dishonored_return",
                ReturnReasonCode.NonParticipantInIatProgram => "non_participant_in_iat_program",
                ReturnReasonCode.PermissibleReturnEntry => "permissible_return_entry",
                ReturnReasonCode.PermissibleReturnEntryNotAccepted =>
                    "permissible_return_entry_not_accepted",
                ReturnReasonCode.RdfiNonSettlement => "rdfi_non_settlement",
                ReturnReasonCode.RdfiParticipantInCheckTruncationProgram =>
                    "rdfi_participant_in_check_truncation_program",
                ReturnReasonCode.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity =>
                    "representative_payee_deceased_or_unable_to_continue_in_that_capacity",
                ReturnReasonCode.ReturnNotADuplicate => "return_not_a_duplicate",
                ReturnReasonCode.ReturnOfErroneousOrReversingDebit =>
                    "return_of_erroneous_or_reversing_debit",
                ReturnReasonCode.ReturnOfImproperCreditEntry => "return_of_improper_credit_entry",
                ReturnReasonCode.ReturnOfImproperDebitEntry => "return_of_improper_debit_entry",
                ReturnReasonCode.ReturnOfXckEntry => "return_of_xck_entry",
                ReturnReasonCode.SourceDocumentPresentedForPayment =>
                    "source_document_presented_for_payment",
                ReturnReasonCode.StateLawAffectingRckAcceptance =>
                    "state_law_affecting_rck_acceptance",
                ReturnReasonCode.StopPaymentOnItemRelatedToRckEntry =>
                    "stop_payment_on_item_related_to_rck_entry",
                ReturnReasonCode.StopPaymentOnSourceDocument => "stop_payment_on_source_document",
                ReturnReasonCode.TimelyOriginalReturn => "timely_original_return",
                ReturnReasonCode.TraceNumberError => "trace_number_error",
                ReturnReasonCode.UntimelyDishonoredReturn => "untimely_dishonored_return",
                ReturnReasonCode.UntimelyReturn => "untimely_return",
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
[JsonConverter(typeof(AchPrenotificationStandardEntryClassCodeConverter))]
public enum AchPrenotificationStandardEntryClassCode
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

sealed class AchPrenotificationStandardEntryClassCodeConverter
    : JsonConverter<AchPrenotificationStandardEntryClassCode>
{
    public override AchPrenotificationStandardEntryClassCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "corporate_credit_or_debit" =>
                AchPrenotificationStandardEntryClassCode.CorporateCreditOrDebit,
            "corporate_trade_exchange" =>
                AchPrenotificationStandardEntryClassCode.CorporateTradeExchange,
            "prearranged_payments_and_deposit" =>
                AchPrenotificationStandardEntryClassCode.PrearrangedPaymentsAndDeposit,
            "internet_initiated" => AchPrenotificationStandardEntryClassCode.InternetInitiated,
            _ => (AchPrenotificationStandardEntryClassCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AchPrenotificationStandardEntryClassCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AchPrenotificationStandardEntryClassCode.CorporateCreditOrDebit =>
                    "corporate_credit_or_debit",
                AchPrenotificationStandardEntryClassCode.CorporateTradeExchange =>
                    "corporate_trade_exchange",
                AchPrenotificationStandardEntryClassCode.PrearrangedPaymentsAndDeposit =>
                    "prearranged_payments_and_deposit",
                AchPrenotificationStandardEntryClassCode.InternetInitiated => "internet_initiated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The lifecycle status of the ACH Prenotification.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// The Prenotification is pending submission.
    /// </summary>
    PendingSubmitting,

    /// <summary>
    /// The Prenotification requires attention.
    /// </summary>
    RequiresAttention,

    /// <summary>
    /// The Prenotification has been returned.
    /// </summary>
    Returned,

    /// <summary>
    /// The Prenotification is complete.
    /// </summary>
    Submitted,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_submitting" => Status.PendingSubmitting,
            "requires_attention" => Status.RequiresAttention,
            "returned" => Status.Returned,
            "submitted" => Status.Submitted,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.PendingSubmitting => "pending_submitting",
                Status.RequiresAttention => "requires_attention",
                Status.Returned => "returned",
                Status.Submitted => "submitted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `ach_prenotification`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    AchPrenotification,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.AchPrenotifications.Type>
{
    public override global::Increase.Api.Models.AchPrenotifications.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ach_prenotification" => global::Increase
                .Api
                .Models
                .AchPrenotifications
                .Type
                .AchPrenotification,
            _ => (global::Increase.Api.Models.AchPrenotifications.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.AchPrenotifications.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.AchPrenotifications.Type.AchPrenotification =>
                    "ach_prenotification",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
