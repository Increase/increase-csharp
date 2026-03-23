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
/// Simulates the return of an [ACH Transfer](#ach-transfers) by the Federal Reserve
/// due to an error condition. This will also create a Transaction to account for
/// the returned funds. This transfer must first have a `status` of `submitted`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AchTransferReturnParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? AchTransferID { get; init; }

    /// <summary>
    /// The reason why the Federal Reserve or destination bank returned this transfer.
    /// Defaults to `no_account`.
    /// </summary>
    public ApiEnum<string, Reason>? Reason
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Reason>>("reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("reason", value);
        }
    }

    public AchTransferReturnParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferReturnParams(AchTransferReturnParams achTransferReturnParams)
        : base(achTransferReturnParams)
    {
        this.AchTransferID = achTransferReturnParams.AchTransferID;

        this._rawBodyData = new(achTransferReturnParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AchTransferReturnParams(
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
    AchTransferReturnParams(
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
    public static AchTransferReturnParams FromRawUnchecked(
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

    public virtual bool Equals(AchTransferReturnParams? other)
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
                + string.Format("/simulations/ach_transfers/{0}/return", this.AchTransferID)
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
/// The reason why the Federal Reserve or destination bank returned this transfer.
/// Defaults to `no_account`.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
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

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_fund" => Reason.InsufficientFund,
            "no_account" => Reason.NoAccount,
            "account_closed" => Reason.AccountClosed,
            "invalid_account_number_structure" => Reason.InvalidAccountNumberStructure,
            "account_frozen_entry_returned_per_ofac_instruction" =>
                Reason.AccountFrozenEntryReturnedPerOfacInstruction,
            "credit_entry_refused_by_receiver" => Reason.CreditEntryRefusedByReceiver,
            "unauthorized_debit_to_consumer_account_using_corporate_sec_code" =>
                Reason.UnauthorizedDebitToConsumerAccountUsingCorporateSecCode,
            "corporate_customer_advised_not_authorized" =>
                Reason.CorporateCustomerAdvisedNotAuthorized,
            "payment_stopped" => Reason.PaymentStopped,
            "non_transaction_account" => Reason.NonTransactionAccount,
            "uncollected_funds" => Reason.UncollectedFunds,
            "routing_number_check_digit_error" => Reason.RoutingNumberCheckDigitError,
            "customer_advised_unauthorized_improper_ineligible_or_incomplete" =>
                Reason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete,
            "amount_field_error" => Reason.AmountFieldError,
            "authorization_revoked_by_customer" => Reason.AuthorizationRevokedByCustomer,
            "invalid_ach_routing_number" => Reason.InvalidAchRoutingNumber,
            "file_record_edit_criteria" => Reason.FileRecordEditCriteria,
            "enr_invalid_individual_name" => Reason.EnrInvalidIndividualName,
            "returned_per_odfi_request" => Reason.ReturnedPerOdfiRequest,
            "limited_participation_dfi" => Reason.LimitedParticipationDfi,
            "incorrectly_coded_outbound_international_payment" =>
                Reason.IncorrectlyCodedOutboundInternationalPayment,
            "account_sold_to_another_dfi" => Reason.AccountSoldToAnotherDfi,
            "addenda_error" => Reason.AddendaError,
            "beneficiary_or_account_holder_deceased" => Reason.BeneficiaryOrAccountHolderDeceased,
            "customer_advised_not_within_authorization_terms" =>
                Reason.CustomerAdvisedNotWithinAuthorizationTerms,
            "corrected_return" => Reason.CorrectedReturn,
            "duplicate_entry" => Reason.DuplicateEntry,
            "duplicate_return" => Reason.DuplicateReturn,
            "enr_duplicate_enrollment" => Reason.EnrDuplicateEnrollment,
            "enr_invalid_dfi_account_number" => Reason.EnrInvalidDfiAccountNumber,
            "enr_invalid_individual_id_number" => Reason.EnrInvalidIndividualIDNumber,
            "enr_invalid_representative_payee_indicator" =>
                Reason.EnrInvalidRepresentativePayeeIndicator,
            "enr_invalid_transaction_code" => Reason.EnrInvalidTransactionCode,
            "enr_return_of_enr_entry" => Reason.EnrReturnOfEnrEntry,
            "enr_routing_number_check_digit_error" => Reason.EnrRoutingNumberCheckDigitError,
            "entry_not_processed_by_gateway" => Reason.EntryNotProcessedByGateway,
            "field_error" => Reason.FieldError,
            "foreign_receiving_dfi_unable_to_settle" => Reason.ForeignReceivingDfiUnableToSettle,
            "iat_entry_coding_error" => Reason.IatEntryCodingError,
            "improper_effective_entry_date" => Reason.ImproperEffectiveEntryDate,
            "improper_source_document_source_document_presented" =>
                Reason.ImproperSourceDocumentSourceDocumentPresented,
            "invalid_company_id" => Reason.InvalidCompanyID,
            "invalid_foreign_receiving_dfi_identification" =>
                Reason.InvalidForeignReceivingDfiIdentification,
            "invalid_individual_id_number" => Reason.InvalidIndividualIDNumber,
            "item_and_rck_entry_presented_for_payment" => Reason.ItemAndRckEntryPresentedForPayment,
            "item_related_to_rck_entry_is_ineligible" => Reason.ItemRelatedToRckEntryIsIneligible,
            "mandatory_field_error" => Reason.MandatoryFieldError,
            "misrouted_dishonored_return" => Reason.MisroutedDishonoredReturn,
            "misrouted_return" => Reason.MisroutedReturn,
            "no_errors_found" => Reason.NoErrorsFound,
            "non_acceptance_of_r62_dishonored_return" => Reason.NonAcceptanceOfR62DishonoredReturn,
            "non_participant_in_iat_program" => Reason.NonParticipantInIatProgram,
            "permissible_return_entry" => Reason.PermissibleReturnEntry,
            "permissible_return_entry_not_accepted" => Reason.PermissibleReturnEntryNotAccepted,
            "rdfi_non_settlement" => Reason.RdfiNonSettlement,
            "rdfi_participant_in_check_truncation_program" =>
                Reason.RdfiParticipantInCheckTruncationProgram,
            "representative_payee_deceased_or_unable_to_continue_in_that_capacity" =>
                Reason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity,
            "return_not_a_duplicate" => Reason.ReturnNotADuplicate,
            "return_of_erroneous_or_reversing_debit" => Reason.ReturnOfErroneousOrReversingDebit,
            "return_of_improper_credit_entry" => Reason.ReturnOfImproperCreditEntry,
            "return_of_improper_debit_entry" => Reason.ReturnOfImproperDebitEntry,
            "return_of_xck_entry" => Reason.ReturnOfXckEntry,
            "source_document_presented_for_payment" => Reason.SourceDocumentPresentedForPayment,
            "state_law_affecting_rck_acceptance" => Reason.StateLawAffectingRckAcceptance,
            "stop_payment_on_item_related_to_rck_entry" =>
                Reason.StopPaymentOnItemRelatedToRckEntry,
            "stop_payment_on_source_document" => Reason.StopPaymentOnSourceDocument,
            "timely_original_return" => Reason.TimelyOriginalReturn,
            "trace_number_error" => Reason.TraceNumberError,
            "untimely_dishonored_return" => Reason.UntimelyDishonoredReturn,
            "untimely_return" => Reason.UntimelyReturn,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.InsufficientFund => "insufficient_fund",
                Reason.NoAccount => "no_account",
                Reason.AccountClosed => "account_closed",
                Reason.InvalidAccountNumberStructure => "invalid_account_number_structure",
                Reason.AccountFrozenEntryReturnedPerOfacInstruction =>
                    "account_frozen_entry_returned_per_ofac_instruction",
                Reason.CreditEntryRefusedByReceiver => "credit_entry_refused_by_receiver",
                Reason.UnauthorizedDebitToConsumerAccountUsingCorporateSecCode =>
                    "unauthorized_debit_to_consumer_account_using_corporate_sec_code",
                Reason.CorporateCustomerAdvisedNotAuthorized =>
                    "corporate_customer_advised_not_authorized",
                Reason.PaymentStopped => "payment_stopped",
                Reason.NonTransactionAccount => "non_transaction_account",
                Reason.UncollectedFunds => "uncollected_funds",
                Reason.RoutingNumberCheckDigitError => "routing_number_check_digit_error",
                Reason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete =>
                    "customer_advised_unauthorized_improper_ineligible_or_incomplete",
                Reason.AmountFieldError => "amount_field_error",
                Reason.AuthorizationRevokedByCustomer => "authorization_revoked_by_customer",
                Reason.InvalidAchRoutingNumber => "invalid_ach_routing_number",
                Reason.FileRecordEditCriteria => "file_record_edit_criteria",
                Reason.EnrInvalidIndividualName => "enr_invalid_individual_name",
                Reason.ReturnedPerOdfiRequest => "returned_per_odfi_request",
                Reason.LimitedParticipationDfi => "limited_participation_dfi",
                Reason.IncorrectlyCodedOutboundInternationalPayment =>
                    "incorrectly_coded_outbound_international_payment",
                Reason.AccountSoldToAnotherDfi => "account_sold_to_another_dfi",
                Reason.AddendaError => "addenda_error",
                Reason.BeneficiaryOrAccountHolderDeceased =>
                    "beneficiary_or_account_holder_deceased",
                Reason.CustomerAdvisedNotWithinAuthorizationTerms =>
                    "customer_advised_not_within_authorization_terms",
                Reason.CorrectedReturn => "corrected_return",
                Reason.DuplicateEntry => "duplicate_entry",
                Reason.DuplicateReturn => "duplicate_return",
                Reason.EnrDuplicateEnrollment => "enr_duplicate_enrollment",
                Reason.EnrInvalidDfiAccountNumber => "enr_invalid_dfi_account_number",
                Reason.EnrInvalidIndividualIDNumber => "enr_invalid_individual_id_number",
                Reason.EnrInvalidRepresentativePayeeIndicator =>
                    "enr_invalid_representative_payee_indicator",
                Reason.EnrInvalidTransactionCode => "enr_invalid_transaction_code",
                Reason.EnrReturnOfEnrEntry => "enr_return_of_enr_entry",
                Reason.EnrRoutingNumberCheckDigitError => "enr_routing_number_check_digit_error",
                Reason.EntryNotProcessedByGateway => "entry_not_processed_by_gateway",
                Reason.FieldError => "field_error",
                Reason.ForeignReceivingDfiUnableToSettle =>
                    "foreign_receiving_dfi_unable_to_settle",
                Reason.IatEntryCodingError => "iat_entry_coding_error",
                Reason.ImproperEffectiveEntryDate => "improper_effective_entry_date",
                Reason.ImproperSourceDocumentSourceDocumentPresented =>
                    "improper_source_document_source_document_presented",
                Reason.InvalidCompanyID => "invalid_company_id",
                Reason.InvalidForeignReceivingDfiIdentification =>
                    "invalid_foreign_receiving_dfi_identification",
                Reason.InvalidIndividualIDNumber => "invalid_individual_id_number",
                Reason.ItemAndRckEntryPresentedForPayment =>
                    "item_and_rck_entry_presented_for_payment",
                Reason.ItemRelatedToRckEntryIsIneligible =>
                    "item_related_to_rck_entry_is_ineligible",
                Reason.MandatoryFieldError => "mandatory_field_error",
                Reason.MisroutedDishonoredReturn => "misrouted_dishonored_return",
                Reason.MisroutedReturn => "misrouted_return",
                Reason.NoErrorsFound => "no_errors_found",
                Reason.NonAcceptanceOfR62DishonoredReturn =>
                    "non_acceptance_of_r62_dishonored_return",
                Reason.NonParticipantInIatProgram => "non_participant_in_iat_program",
                Reason.PermissibleReturnEntry => "permissible_return_entry",
                Reason.PermissibleReturnEntryNotAccepted => "permissible_return_entry_not_accepted",
                Reason.RdfiNonSettlement => "rdfi_non_settlement",
                Reason.RdfiParticipantInCheckTruncationProgram =>
                    "rdfi_participant_in_check_truncation_program",
                Reason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity =>
                    "representative_payee_deceased_or_unable_to_continue_in_that_capacity",
                Reason.ReturnNotADuplicate => "return_not_a_duplicate",
                Reason.ReturnOfErroneousOrReversingDebit =>
                    "return_of_erroneous_or_reversing_debit",
                Reason.ReturnOfImproperCreditEntry => "return_of_improper_credit_entry",
                Reason.ReturnOfImproperDebitEntry => "return_of_improper_debit_entry",
                Reason.ReturnOfXckEntry => "return_of_xck_entry",
                Reason.SourceDocumentPresentedForPayment => "source_document_presented_for_payment",
                Reason.StateLawAffectingRckAcceptance => "state_law_affecting_rck_acceptance",
                Reason.StopPaymentOnItemRelatedToRckEntry =>
                    "stop_payment_on_item_related_to_rck_entry",
                Reason.StopPaymentOnSourceDocument => "stop_payment_on_source_document",
                Reason.TimelyOriginalReturn => "timely_original_return",
                Reason.TraceNumberError => "trace_number_error",
                Reason.UntimelyDishonoredReturn => "untimely_dishonored_return",
                Reason.UntimelyReturn => "untimely_return",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
