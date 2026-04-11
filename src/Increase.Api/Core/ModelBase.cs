using System.Text.Json;
using Increase.Api.Exceptions;
using Increase.Api.Models.Accounts;
using Increase.Api.Models.Simulations.AchTransfers;
using Increase.Api.Models.Simulations.CardAuthentications;
using Increase.Api.Models.Simulations.CardBalanceInquiries;
using Increase.Api.Models.Simulations.CardDisputes;
using Increase.Api.Models.Simulations.RealTimePaymentsTransfers;
using AccountNumbers = Increase.Api.Models.AccountNumbers;
using AccountStatements = Increase.Api.Models.AccountStatements;
using AccountTransfers = Increase.Api.Models.AccountTransfers;
using AchPrenotifications = Increase.Api.Models.AchPrenotifications;
using AchTransfers = Increase.Api.Models.AchTransfers;
using BeneficialOwners = Increase.Api.Models.BeneficialOwners;
using BookkeepingAccounts = Increase.Api.Models.BookkeepingAccounts;
using BookkeepingEntries = Increase.Api.Models.BookkeepingEntries;
using BookkeepingEntrySets = Increase.Api.Models.BookkeepingEntrySets;
using CardAuthorizations = Increase.Api.Models.Simulations.CardAuthorizations;
using CardDisputes = Increase.Api.Models.CardDisputes;
using CardPayments = Increase.Api.Models.CardPayments;
using CardPurchaseSupplements = Increase.Api.Models.CardPurchaseSupplements;
using CardPushTransfers = Increase.Api.Models.CardPushTransfers;
using Cards = Increase.Api.Models.Cards;
using CardTokens = Increase.Api.Models.CardTokens;
using CardValidations = Increase.Api.Models.CardValidations;
using CheckDeposits = Increase.Api.Models.CheckDeposits;
using CheckTransfers = Increase.Api.Models.CheckTransfers;
using DeclinedTransactions = Increase.Api.Models.DeclinedTransactions;
using DigitalCardProfiles = Increase.Api.Models.DigitalCardProfiles;
using DigitalWalletTokenRequests = Increase.Api.Models.Simulations.DigitalWalletTokenRequests;
using DigitalWalletTokens = Increase.Api.Models.DigitalWalletTokens;
using Entities = Increase.Api.Models.Entities;
using EntityOnboardingSessions = Increase.Api.Models.EntityOnboardingSessions;
using Events = Increase.Api.Models.Events;
using EventSubscriptions = Increase.Api.Models.EventSubscriptions;
using Exports = Increase.Api.Models.Exports;
using ExternalAccounts = Increase.Api.Models.ExternalAccounts;
using FednowTransfers = Increase.Api.Models.FednowTransfers;
using FileLinks = Increase.Api.Models.FileLinks;
using Files = Increase.Api.Models.Files;
using Groups = Increase.Api.Models.Groups;
using InboundAchTransfers = Increase.Api.Models.InboundAchTransfers;
using InboundCheckDeposits = Increase.Api.Models.InboundCheckDeposits;
using InboundFednowTransfers = Increase.Api.Models.InboundFednowTransfers;
using InboundMailItems = Increase.Api.Models.InboundMailItems;
using InboundRealTimePaymentsTransfers = Increase.Api.Models.InboundRealTimePaymentsTransfers;
using InboundWireDrawdownRequests = Increase.Api.Models.InboundWireDrawdownRequests;
using InboundWireTransfers = Increase.Api.Models.InboundWireTransfers;
using IntrafiAccountEnrollments = Increase.Api.Models.IntrafiAccountEnrollments;
using IntrafiBalances = Increase.Api.Models.IntrafiBalances;
using IntrafiExclusions = Increase.Api.Models.IntrafiExclusions;
using Lockboxes = Increase.Api.Models.Lockboxes;
using OAuthApplications = Increase.Api.Models.OAuthApplications;
using OAuthConnections = Increase.Api.Models.OAuthConnections;
using OAuthTokens = Increase.Api.Models.OAuthTokens;
using PendingTransactions = Increase.Api.Models.PendingTransactions;
using PhysicalCardProfiles = Increase.Api.Models.PhysicalCardProfiles;
using PhysicalCards = Increase.Api.Models.PhysicalCards;
using Programs = Increase.Api.Models.Programs;
using RealTimeDecisions = Increase.Api.Models.RealTimeDecisions;
using RealTimePaymentsTransfers = Increase.Api.Models.RealTimePaymentsTransfers;
using RoutingNumbers = Increase.Api.Models.RoutingNumbers;
using SimulationsCardTokens = Increase.Api.Models.Simulations.CardTokens;
using SimulationsCheckDeposits = Increase.Api.Models.Simulations.CheckDeposits;
using SimulationsExports = Increase.Api.Models.Simulations.Exports;
using SimulationsInboundAchTransfers = Increase.Api.Models.Simulations.InboundAchTransfers;
using SimulationsInboundCheckDeposits = Increase.Api.Models.Simulations.InboundCheckDeposits;
using SimulationsPhysicalCards = Increase.Api.Models.Simulations.PhysicalCards;
using SimulationsPrograms = Increase.Api.Models.Simulations.Programs;
using SupplementalDocuments = Increase.Api.Models.SupplementalDocuments;
using SwiftTransfers = Increase.Api.Models.SwiftTransfers;
using Transactions = Increase.Api.Models.Transactions;
using WireDrawdownRequests = Increase.Api.Models.WireDrawdownRequests;
using WireTransfers = Increase.Api.Models.WireTransfers;

namespace Increase.Api.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, Bank>(),
            new ApiEnumConverter<string, Currency>(),
            new ApiEnumConverter<string, AccountFunding>(),
            new ApiEnumConverter<string, AccountLoanStatementPaymentType>(),
            new ApiEnumConverter<string, AccountStatus>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, BalanceLookupType>(),
            new ApiEnumConverter<string, Funding>(),
            new ApiEnumConverter<string, StatementPaymentType>(),
            new ApiEnumConverter<string, In>(),
            new ApiEnumConverter<string, AccountNumbers::AccountNumberInboundAchDebitStatus>(),
            new ApiEnumConverter<string, AccountNumbers::AccountNumberInboundChecksStatus>(),
            new ApiEnumConverter<string, AccountNumbers::AccountNumberStatus>(),
            new ApiEnumConverter<string, AccountNumbers::Type>(),
            new ApiEnumConverter<string, AccountNumbers::DebitStatus>(),
            new ApiEnumConverter<string, AccountNumbers::Status>(),
            new ApiEnumConverter<
                string,
                AccountNumbers::AccountNumberUpdateParamsInboundAchDebitStatus
            >(),
            new ApiEnumConverter<
                string,
                AccountNumbers::AccountNumberUpdateParamsInboundChecksStatus
            >(),
            new ApiEnumConverter<string, AccountNumbers::AccountNumberUpdateParamsStatus>(),
            new ApiEnumConverter<string, AccountNumbers::In>(),
            new ApiEnumConverter<string, AccountNumbers::AccountNumberListParamsStatusIn>(),
            new ApiEnumConverter<string, AccountTransfers::Category>(),
            new ApiEnumConverter<string, AccountTransfers::Currency>(),
            new ApiEnumConverter<string, AccountTransfers::Status>(),
            new ApiEnumConverter<string, AccountTransfers::Type>(),
            new ApiEnumConverter<string, Cards::CardAuthorizationControlsUsageCategory>(),
            new ApiEnumConverter<
                string,
                Cards::CardAuthorizationControlsUsageMultiUseSpendingLimitInterval
            >(),
            new ApiEnumConverter<
                string,
                Cards::CardAuthorizationControlsUsageSingleUseSettlementAmountComparison
            >(),
            new ApiEnumConverter<string, Cards::CardStatus>(),
            new ApiEnumConverter<string, Cards::Type>(),
            new ApiEnumConverter<string, Cards::CardDetailsType>(),
            new ApiEnumConverter<string, Cards::CardIframeUrlType>(),
            new ApiEnumConverter<string, Cards::Category>(),
            new ApiEnumConverter<string, Cards::Interval>(),
            new ApiEnumConverter<string, Cards::Comparison>(),
            new ApiEnumConverter<
                string,
                Cards::CardUpdateParamsAuthorizationControlsUsageCategory
            >(),
            new ApiEnumConverter<
                string,
                Cards::CardUpdateParamsAuthorizationControlsUsageMultiUseSpendingLimitInterval
            >(),
            new ApiEnumConverter<
                string,
                Cards::CardUpdateParamsAuthorizationControlsUsageSingleUseSettlementAmountComparison
            >(),
            new ApiEnumConverter<string, Cards::Status>(),
            new ApiEnumConverter<string, Cards::In>(),
            new ApiEnumConverter<string, CardPayments::Category>(),
            new ApiEnumConverter<string, CardPayments::Outcome>(),
            new ApiEnumConverter<string, CardPayments::VerificationMethod>(),
            new ApiEnumConverter<string, CardPayments::DenyReason>(),
            new ApiEnumConverter<string, CardPayments::JavascriptEnabled>(),
            new ApiEnumConverter<string, CardPayments::DeviceChannelCategory>(),
            new ApiEnumConverter<string, CardPayments::Indicator>(),
            new ApiEnumConverter<string, CardPayments::MessageCategoryCategory>(),
            new ApiEnumConverter<string, CardPayments::TransactionType>(),
            new ApiEnumConverter<string, CardPayments::RequestorAuthenticationIndicator>(),
            new ApiEnumConverter<string, CardPayments::RequestorChallengeIndicator>(),
            new ApiEnumConverter<string, CardPayments::Status>(),
            new ApiEnumConverter<string, CardPayments::Type>(),
            new ApiEnumConverter<string, CardPayments::Actioner>(),
            new ApiEnumConverter<string, CardPayments::Currency>(),
            new ApiEnumConverter<string, CardPayments::Direction>(),
            new ApiEnumConverter<string, CardPayments::NetworkDetailsCategory>(),
            new ApiEnumConverter<string, CardPayments::ElectronicCommerceIndicator>(),
            new ApiEnumConverter<string, CardPayments::PointOfServiceEntryMode>(),
            new ApiEnumConverter<string, CardPayments::StandInProcessingReason>(),
            new ApiEnumConverter<string, CardPayments::TerminalEntryCapability>(),
            new ApiEnumConverter<string, CardPayments::ProcessingCategory>(),
            new ApiEnumConverter<string, CardPayments::SchemeFeeCurrency>(),
            new ApiEnumConverter<string, CardPayments::FeeType>(),
            new ApiEnumConverter<string, CardPayments::CardAuthorizationType>(),
            new ApiEnumConverter<string, CardPayments::Result>(),
            new ApiEnumConverter<string, CardPayments::CardholderAddressResult>(),
            new ApiEnumConverter<string, CardPayments::CardAuthorizationExpirationCurrency>(),
            new ApiEnumConverter<string, CardPayments::Network>(),
            new ApiEnumConverter<string, CardPayments::CardAuthorizationExpirationType>(),
            new ApiEnumConverter<string, CardPayments::CardBalanceInquiryCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardBalanceInquiryNetworkDetailsCategory>(),
            new ApiEnumConverter<
                string,
                CardPayments::CardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardBalanceInquiryNetworkDetailsVisaStandInProcessingReason
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability
            >(),
            new ApiEnumConverter<string, CardPayments::CardBalanceInquirySchemeFeeCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardBalanceInquirySchemeFeeFeeType>(),
            new ApiEnumConverter<string, CardPayments::CardBalanceInquiryType>(),
            new ApiEnumConverter<
                string,
                CardPayments::CardBalanceInquiryVerificationCardVerificationCodeResult
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardBalanceInquiryVerificationCardholderAddressResult
            >(),
            new ApiEnumConverter<string, CardPayments::CardDeclineActioner>(),
            new ApiEnumConverter<string, CardPayments::CardDeclineCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardDeclineDirection>(),
            new ApiEnumConverter<string, CardPayments::CardDeclineNetworkDetailsCategory>(),
            new ApiEnumConverter<
                string,
                CardPayments::CardDeclineNetworkDetailsVisaElectronicCommerceIndicator
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardDeclineNetworkDetailsVisaPointOfServiceEntryMode
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardDeclineNetworkDetailsVisaStandInProcessingReason
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardDeclineNetworkDetailsVisaTerminalEntryCapability
            >(),
            new ApiEnumConverter<string, CardPayments::CardDeclineProcessingCategory>(),
            new ApiEnumConverter<string, CardPayments::RealTimeDecisionReason>(),
            new ApiEnumConverter<string, CardPayments::Reason>(),
            new ApiEnumConverter<string, CardPayments::CardDeclineSchemeFeeCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardDeclineSchemeFeeFeeType>(),
            new ApiEnumConverter<
                string,
                CardPayments::CardDeclineVerificationCardVerificationCodeResult
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardDeclineVerificationCardholderAddressResult
            >(),
            new ApiEnumConverter<string, CardPayments::CardFinancialActioner>(),
            new ApiEnumConverter<string, CardPayments::CardFinancialCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardFinancialDirection>(),
            new ApiEnumConverter<string, CardPayments::CardFinancialNetworkDetailsCategory>(),
            new ApiEnumConverter<
                string,
                CardPayments::CardFinancialNetworkDetailsVisaElectronicCommerceIndicator
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardFinancialNetworkDetailsVisaPointOfServiceEntryMode
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardFinancialNetworkDetailsVisaStandInProcessingReason
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardFinancialNetworkDetailsVisaTerminalEntryCapability
            >(),
            new ApiEnumConverter<string, CardPayments::CardFinancialProcessingCategory>(),
            new ApiEnumConverter<string, CardPayments::CardFinancialSchemeFeeCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardFinancialSchemeFeeFeeType>(),
            new ApiEnumConverter<string, CardPayments::CardFinancialType>(),
            new ApiEnumConverter<
                string,
                CardPayments::CardFinancialVerificationCardVerificationCodeResult
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardFinancialVerificationCardholderAddressResult
            >(),
            new ApiEnumConverter<string, CardPayments::CardFuelConfirmationCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardFuelConfirmationNetwork>(),
            new ApiEnumConverter<string, CardPayments::CardFuelConfirmationSchemeFeeCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardFuelConfirmationSchemeFeeFeeType>(),
            new ApiEnumConverter<string, CardPayments::CardFuelConfirmationType>(),
            new ApiEnumConverter<string, CardPayments::CardIncrementActioner>(),
            new ApiEnumConverter<string, CardPayments::CardIncrementCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardIncrementNetwork>(),
            new ApiEnumConverter<string, CardPayments::CardIncrementSchemeFeeCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardIncrementSchemeFeeFeeType>(),
            new ApiEnumConverter<string, CardPayments::CardIncrementType>(),
            new ApiEnumConverter<string, CardPayments::CashbackCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardRefundCurrency>(),
            new ApiEnumConverter<string, CardPayments::InterchangeCurrency>(),
            new ApiEnumConverter<string, CardPayments::ExtraCharges>(),
            new ApiEnumConverter<string, CardPayments::NoShowIndicator>(),
            new ApiEnumConverter<string, CardPayments::LodgingExtraCharges>(),
            new ApiEnumConverter<string, CardPayments::LodgingNoShowIndicator>(),
            new ApiEnumConverter<string, CardPayments::PurchaseIdentifierFormat>(),
            new ApiEnumConverter<string, CardPayments::CreditReasonIndicator>(),
            new ApiEnumConverter<string, CardPayments::ServiceCategory>(),
            new ApiEnumConverter<string, CardPayments::TravelCreditReasonIndicator>(),
            new ApiEnumConverter<string, CardPayments::RestrictedTicketIndicator>(),
            new ApiEnumConverter<string, CardPayments::TicketChangeIndicator>(),
            new ApiEnumConverter<string, CardPayments::StopOverCode>(),
            new ApiEnumConverter<string, CardPayments::CardRefundSchemeFeeCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardRefundSchemeFeeFeeType>(),
            new ApiEnumConverter<string, CardPayments::CardRefundType>(),
            new ApiEnumConverter<string, CardPayments::CardReversalCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardReversalNetwork>(),
            new ApiEnumConverter<string, CardPayments::ReversalReason>(),
            new ApiEnumConverter<string, CardPayments::CardReversalSchemeFeeCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardReversalSchemeFeeFeeType>(),
            new ApiEnumConverter<string, CardPayments::CardReversalType>(),
            new ApiEnumConverter<string, CardPayments::CardSettlementCashbackCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardSettlementCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardSettlementInterchangeCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardSettlementNetwork>(),
            new ApiEnumConverter<
                string,
                CardPayments::CardSettlementPurchaseDetailsCarRentalExtraCharges
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardSettlementPurchaseDetailsCarRentalNoShowIndicator
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardSettlementPurchaseDetailsLodgingExtraCharges
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardSettlementPurchaseDetailsLodgingNoShowIndicator
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardSettlementPurchaseDetailsPurchaseIdentifierFormat
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardSettlementPurchaseDetailsTravelAncillaryServiceCategory
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardSettlementPurchaseDetailsTravelCreditReasonIndicator
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardSettlementPurchaseDetailsTravelTicketChangeIndicator
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardSettlementPurchaseDetailsTravelTripLegStopOverCode
            >(),
            new ApiEnumConverter<string, CardPayments::CardSettlementSchemeFeeCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardSettlementSchemeFeeFeeType>(),
            new ApiEnumConverter<string, CardPayments::CardSettlementType>(),
            new ApiEnumConverter<string, CardPayments::CardValidationActioner>(),
            new ApiEnumConverter<string, CardPayments::CardValidationCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardValidationNetworkDetailsCategory>(),
            new ApiEnumConverter<
                string,
                CardPayments::CardValidationNetworkDetailsVisaElectronicCommerceIndicator
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardValidationNetworkDetailsVisaPointOfServiceEntryMode
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardValidationNetworkDetailsVisaStandInProcessingReason
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardValidationNetworkDetailsVisaTerminalEntryCapability
            >(),
            new ApiEnumConverter<string, CardPayments::CardValidationSchemeFeeCurrency>(),
            new ApiEnumConverter<string, CardPayments::CardValidationSchemeFeeFeeType>(),
            new ApiEnumConverter<string, CardPayments::CardValidationType>(),
            new ApiEnumConverter<
                string,
                CardPayments::CardValidationVerificationCardVerificationCodeResult
            >(),
            new ApiEnumConverter<
                string,
                CardPayments::CardValidationVerificationCardholderAddressResult
            >(),
            new ApiEnumConverter<string, CardPayments::CardPaymentType>(),
            new ApiEnumConverter<string, CardPurchaseSupplements::DiscountTreatmentCode>(),
            new ApiEnumConverter<string, CardPurchaseSupplements::TaxTreatments>(),
            new ApiEnumConverter<string, CardPurchaseSupplements::DetailIndicator>(),
            new ApiEnumConverter<string, CardPurchaseSupplements::LineItemDiscountTreatmentCode>(),
            new ApiEnumConverter<string, CardPurchaseSupplements::Type>(),
            new ApiEnumConverter<string, CardDisputes::LossReason>(),
            new ApiEnumConverter<string, CardDisputes::CardDisputeNetwork>(),
            new ApiEnumConverter<string, CardDisputes::CardDisputeStatus>(),
            new ApiEnumConverter<string, CardDisputes::Type>(),
            new ApiEnumConverter<string, CardDisputes::NetworkEventCategory>(),
            new ApiEnumConverter<string, CardDisputes::CompellingEvidenceCategory>(),
            new ApiEnumConverter<string, CardDisputes::InvalidDisputeReason>(),
            new ApiEnumConverter<string, CardDisputes::MerchantPrearbitrationReceivedReason>(),
            new ApiEnumConverter<string, CardDisputes::RepresentedInvalidDisputeReason>(),
            new ApiEnumConverter<string, CardDisputes::RepresentedReason>(),
            new ApiEnumConverter<string, CardDisputes::RequiredUserSubmissionCategory>(),
            new ApiEnumConverter<string, CardDisputes::UserSubmissionCategory>(),
            new ApiEnumConverter<string, CardDisputes::UserSubmissionStatus>(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackAuthorizationAccountStatus
            >(),
            new ApiEnumConverter<string, CardDisputes::UserSubmissionChargebackCategory>(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerCanceledServicesServiceType
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<string, CardDisputes::UserSubmissionChargebackFraudFraudType>(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackProcessingErrorErrorReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::UserSubmissionUserPrearbitrationCategoryChangeCategory
            >(),
            new ApiEnumConverter<string, CardDisputes::Network>(),
            new ApiEnumConverter<string, CardDisputes::Category>(),
            new ApiEnumConverter<string, CardDisputes::AccountStatus>(),
            new ApiEnumConverter<string, CardDisputes::MerchantResolutionAttempted>(),
            new ApiEnumConverter<string, CardDisputes::ReturnOutcome>(),
            new ApiEnumConverter<string, CardDisputes::CanceledPriorToShipDate>(),
            new ApiEnumConverter<string, CardDisputes::CancellationPolicyProvided>(),
            new ApiEnumConverter<string, CardDisputes::AttemptReason>(),
            new ApiEnumConverter<string, CardDisputes::ReturnMethod>(),
            new ApiEnumConverter<string, CardDisputes::CancellationTarget>(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerCanceledServicesMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<string, CardDisputes::ServiceType>(),
            new ApiEnumConverter<string, CardDisputes::Explanation>(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerDamagedOrDefectiveMerchandiseReturnOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerMerchandiseMisrepresentationReturnOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerMerchandiseMisrepresentationReturnedReturnMethod
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerMerchandiseNotAsDescribedReturnOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerMerchandiseNotAsDescribedReturnedReturnMethod
            >(),
            new ApiEnumConverter<string, CardDisputes::CancellationOutcome>(),
            new ApiEnumConverter<string, CardDisputes::DeliveryIssue>(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerMerchandiseNotReceivedMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<string, CardDisputes::DelayedReturnOutcome>(),
            new ApiEnumConverter<string, CardDisputes::Reason>(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerQualityMerchandiseMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<string, CardDisputes::ConsumerQualityMerchandiseReturnOutcome>(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerQualityMerchandiseReturnAttemptedAttemptReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerQualityMerchandiseReturnedReturnMethod
            >(),
            new ApiEnumConverter<string, CardDisputes::AcceptedByMerchant>(),
            new ApiEnumConverter<
                string,
                CardDisputes::NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
            >(),
            new ApiEnumConverter<string, CardDisputes::CardholderPaidToHaveWorkRedone>(),
            new ApiEnumConverter<string, CardDisputes::RestaurantFoodRelated>(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerServicesMisrepresentationMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerServicesNotAsDescribedMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerServicesNotReceivedCancellationOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ConsumerServicesNotReceivedMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<string, CardDisputes::FraudType>(),
            new ApiEnumConverter<string, CardDisputes::ErrorReason>(),
            new ApiEnumConverter<
                string,
                CardDisputes::ProcessingErrorMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<string, CardDisputes::OtherFormOfPaymentEvidence>(),
            new ApiEnumConverter<string, CardDisputes::In>(),
            new ApiEnumConverter<
                string,
                CardDisputes::CardDisputeSubmitUserSubmissionParamsNetwork
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::CardDisputeSubmitUserSubmissionParamsVisaCategory
            >(),
            new ApiEnumConverter<string, CardDisputes::ChargebackCategory>(),
            new ApiEnumConverter<string, CardDisputes::ChargebackAuthorizationAccountStatus>(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerCanceledMerchandiseReturnOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerCanceledMerchandiseReturnedReturnMethod
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerCanceledRecurringTransactionCancellationTarget
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerCanceledServicesMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerCanceledServicesServiceType
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerCanceledServicesGuaranteedReservationExplanation
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerMerchandiseMisrepresentationReturnOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerMerchandiseNotReceivedCancellationOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerMerchandiseNotReceivedDeliveryIssue
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerOriginalCreditTransactionNotAcceptedReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerQualityMerchandiseReturnOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerQualityMerchandiseReturnedReturnMethod
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerQualityServicesRestaurantFoodRelated
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerServicesNotReceivedCancellationOutcome
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<string, CardDisputes::ChargebackFraudFraudType>(),
            new ApiEnumConverter<string, CardDisputes::ChargebackProcessingErrorErrorReason>(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackProcessingErrorMerchantResolutionAttempted
            >(),
            new ApiEnumConverter<
                string,
                CardDisputes::ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence
            >(),
            new ApiEnumConverter<string, CardDisputes::CategoryChangeCategory>(),
            new ApiEnumConverter<string, PhysicalCards::PhysicalCardShipmentMethod>(),
            new ApiEnumConverter<string, PhysicalCards::PhysicalCardShipmentSchedule>(),
            new ApiEnumConverter<string, PhysicalCards::PhysicalCardShipmentStatus>(),
            new ApiEnumConverter<string, PhysicalCards::Category>(),
            new ApiEnumConverter<string, PhysicalCards::PhysicalCardStatus>(),
            new ApiEnumConverter<string, PhysicalCards::Type>(),
            new ApiEnumConverter<string, PhysicalCards::Method>(),
            new ApiEnumConverter<string, PhysicalCards::Schedule>(),
            new ApiEnumConverter<string, PhysicalCards::Status>(),
            new ApiEnumConverter<string, DigitalCardProfiles::DigitalCardProfileStatus>(),
            new ApiEnumConverter<string, DigitalCardProfiles::Type>(),
            new ApiEnumConverter<string, DigitalCardProfiles::In>(),
            new ApiEnumConverter<string, PhysicalCardProfiles::Creator>(),
            new ApiEnumConverter<string, PhysicalCardProfiles::PhysicalCardProfileStatus>(),
            new ApiEnumConverter<string, PhysicalCardProfiles::Type>(),
            new ApiEnumConverter<string, PhysicalCardProfiles::In>(),
            new ApiEnumConverter<string, DigitalWalletTokens::DeviceType>(),
            new ApiEnumConverter<string, DigitalWalletTokens::Status>(),
            new ApiEnumConverter<string, DigitalWalletTokens::TokenRequestor>(),
            new ApiEnumConverter<string, DigitalWalletTokens::Type>(),
            new ApiEnumConverter<string, DigitalWalletTokens::UpdateStatus>(),
            new ApiEnumConverter<string, Transactions::Currency>(),
            new ApiEnumConverter<string, Transactions::RouteType>(),
            new ApiEnumConverter<string, Transactions::SourceCategory>(),
            new ApiEnumConverter<string, Transactions::AccountTransferIntentionCurrency>(),
            new ApiEnumConverter<string, Transactions::ReturnReasonCode>(),
            new ApiEnumConverter<string, Transactions::Network>(),
            new ApiEnumConverter<string, Transactions::EventType>(),
            new ApiEnumConverter<string, Transactions::Actioner>(),
            new ApiEnumConverter<string, Transactions::CardFinancialCurrency>(),
            new ApiEnumConverter<string, Transactions::Direction>(),
            new ApiEnumConverter<string, Transactions::NetworkDetailsCategory>(),
            new ApiEnumConverter<string, Transactions::ElectronicCommerceIndicator>(),
            new ApiEnumConverter<string, Transactions::PointOfServiceEntryMode>(),
            new ApiEnumConverter<string, Transactions::StandInProcessingReason>(),
            new ApiEnumConverter<string, Transactions::TerminalEntryCapability>(),
            new ApiEnumConverter<string, Transactions::ProcessingCategory>(),
            new ApiEnumConverter<string, Transactions::SchemeFeeCurrency>(),
            new ApiEnumConverter<string, Transactions::FeeType>(),
            new ApiEnumConverter<string, Transactions::Type>(),
            new ApiEnumConverter<string, Transactions::Result>(),
            new ApiEnumConverter<string, Transactions::CardholderAddressResult>(),
            new ApiEnumConverter<string, Transactions::CashbackCurrency>(),
            new ApiEnumConverter<string, Transactions::CardRefundCurrency>(),
            new ApiEnumConverter<string, Transactions::InterchangeCurrency>(),
            new ApiEnumConverter<string, Transactions::ExtraCharges>(),
            new ApiEnumConverter<string, Transactions::NoShowIndicator>(),
            new ApiEnumConverter<string, Transactions::LodgingExtraCharges>(),
            new ApiEnumConverter<string, Transactions::LodgingNoShowIndicator>(),
            new ApiEnumConverter<string, Transactions::PurchaseIdentifierFormat>(),
            new ApiEnumConverter<string, Transactions::CreditReasonIndicator>(),
            new ApiEnumConverter<string, Transactions::ServiceCategory>(),
            new ApiEnumConverter<string, Transactions::TravelCreditReasonIndicator>(),
            new ApiEnumConverter<string, Transactions::RestrictedTicketIndicator>(),
            new ApiEnumConverter<string, Transactions::TicketChangeIndicator>(),
            new ApiEnumConverter<string, Transactions::StopOverCode>(),
            new ApiEnumConverter<string, Transactions::CardRefundSchemeFeeCurrency>(),
            new ApiEnumConverter<string, Transactions::CardRefundSchemeFeeFeeType>(),
            new ApiEnumConverter<string, Transactions::CardRefundType>(),
            new ApiEnumConverter<string, Transactions::CardRevenuePaymentCurrency>(),
            new ApiEnumConverter<string, Transactions::CardSettlementCashbackCurrency>(),
            new ApiEnumConverter<string, Transactions::CardSettlementCurrency>(),
            new ApiEnumConverter<string, Transactions::CardSettlementInterchangeCurrency>(),
            new ApiEnumConverter<string, Transactions::CardSettlementNetwork>(),
            new ApiEnumConverter<
                string,
                Transactions::CardSettlementPurchaseDetailsCarRentalExtraCharges
            >(),
            new ApiEnumConverter<
                string,
                Transactions::CardSettlementPurchaseDetailsCarRentalNoShowIndicator
            >(),
            new ApiEnumConverter<
                string,
                Transactions::CardSettlementPurchaseDetailsLodgingExtraCharges
            >(),
            new ApiEnumConverter<
                string,
                Transactions::CardSettlementPurchaseDetailsLodgingNoShowIndicator
            >(),
            new ApiEnumConverter<
                string,
                Transactions::CardSettlementPurchaseDetailsPurchaseIdentifierFormat
            >(),
            new ApiEnumConverter<
                string,
                Transactions::CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator
            >(),
            new ApiEnumConverter<
                string,
                Transactions::CardSettlementPurchaseDetailsTravelAncillaryServiceCategory
            >(),
            new ApiEnumConverter<
                string,
                Transactions::CardSettlementPurchaseDetailsTravelCreditReasonIndicator
            >(),
            new ApiEnumConverter<
                string,
                Transactions::CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator
            >(),
            new ApiEnumConverter<
                string,
                Transactions::CardSettlementPurchaseDetailsTravelTicketChangeIndicator
            >(),
            new ApiEnumConverter<
                string,
                Transactions::CardSettlementPurchaseDetailsTravelTripLegStopOverCode
            >(),
            new ApiEnumConverter<string, Transactions::CardSettlementSchemeFeeCurrency>(),
            new ApiEnumConverter<string, Transactions::CardSettlementSchemeFeeFeeType>(),
            new ApiEnumConverter<string, Transactions::CardSettlementType>(),
            new ApiEnumConverter<string, Transactions::CashbackPaymentCurrency>(),
            new ApiEnumConverter<string, Transactions::CheckDepositAcceptanceCurrency>(),
            new ApiEnumConverter<string, Transactions::CheckDepositReturnCurrency>(),
            new ApiEnumConverter<string, Transactions::ReturnReason>(),
            new ApiEnumConverter<string, Transactions::CheckTransferDepositType>(),
            new ApiEnumConverter<string, Transactions::FeePaymentCurrency>(),
            new ApiEnumConverter<string, Transactions::AddendaCategory>(),
            new ApiEnumConverter<string, Transactions::Reason>(),
            new ApiEnumConverter<
                string,
                Transactions::InboundRealTimePaymentsTransferConfirmationCurrency
            >(),
            new ApiEnumConverter<string, Transactions::InterestPaymentCurrency>(),
            new ApiEnumConverter<string, Transactions::InternalSourceCurrency>(),
            new ApiEnumConverter<string, Transactions::InternalSourceReason>(),
            new ApiEnumConverter<string, Transactions::TransactionType>(),
            new ApiEnumConverter<string, Transactions::In>(),
            new ApiEnumConverter<string, PendingTransactions::Currency>(),
            new ApiEnumConverter<string, PendingTransactions::RouteType>(),
            new ApiEnumConverter<string, PendingTransactions::SourceCategory>(),
            new ApiEnumConverter<string, PendingTransactions::AccountTransferInstructionCurrency>(),
            new ApiEnumConverter<string, PendingTransactions::Actioner>(),
            new ApiEnumConverter<string, PendingTransactions::CardAuthorizationCurrency>(),
            new ApiEnumConverter<string, PendingTransactions::Direction>(),
            new ApiEnumConverter<string, PendingTransactions::NetworkDetailsCategory>(),
            new ApiEnumConverter<string, PendingTransactions::ElectronicCommerceIndicator>(),
            new ApiEnumConverter<string, PendingTransactions::PointOfServiceEntryMode>(),
            new ApiEnumConverter<string, PendingTransactions::StandInProcessingReason>(),
            new ApiEnumConverter<string, PendingTransactions::TerminalEntryCapability>(),
            new ApiEnumConverter<string, PendingTransactions::ProcessingCategory>(),
            new ApiEnumConverter<string, PendingTransactions::SchemeFeeCurrency>(),
            new ApiEnumConverter<string, PendingTransactions::FeeType>(),
            new ApiEnumConverter<string, PendingTransactions::Type>(),
            new ApiEnumConverter<string, PendingTransactions::Result>(),
            new ApiEnumConverter<string, PendingTransactions::CardholderAddressResult>(),
            new ApiEnumConverter<string, PendingTransactions::CheckDepositInstructionCurrency>(),
            new ApiEnumConverter<string, PendingTransactions::CheckTransferInstructionCurrency>(),
            new ApiEnumConverter<string, PendingTransactions::InboundFundsHoldCurrency>(),
            new ApiEnumConverter<string, PendingTransactions::InboundFundsHoldStatus>(),
            new ApiEnumConverter<string, PendingTransactions::InboundFundsHoldType>(),
            new ApiEnumConverter<string, PendingTransactions::PendingTransactionStatus>(),
            new ApiEnumConverter<string, PendingTransactions::PendingTransactionType>(),
            new ApiEnumConverter<string, PendingTransactions::In>(),
            new ApiEnumConverter<string, PendingTransactions::StatusIn>(),
            new ApiEnumConverter<string, DeclinedTransactions::Currency>(),
            new ApiEnumConverter<string, DeclinedTransactions::RouteType>(),
            new ApiEnumConverter<string, DeclinedTransactions::SourceCategory>(),
            new ApiEnumConverter<string, DeclinedTransactions::Reason>(),
            new ApiEnumConverter<string, DeclinedTransactions::Type>(),
            new ApiEnumConverter<string, DeclinedTransactions::Actioner>(),
            new ApiEnumConverter<string, DeclinedTransactions::CardDeclineCurrency>(),
            new ApiEnumConverter<string, DeclinedTransactions::Direction>(),
            new ApiEnumConverter<string, DeclinedTransactions::NetworkDetailsCategory>(),
            new ApiEnumConverter<string, DeclinedTransactions::ElectronicCommerceIndicator>(),
            new ApiEnumConverter<string, DeclinedTransactions::PointOfServiceEntryMode>(),
            new ApiEnumConverter<string, DeclinedTransactions::StandInProcessingReason>(),
            new ApiEnumConverter<string, DeclinedTransactions::TerminalEntryCapability>(),
            new ApiEnumConverter<string, DeclinedTransactions::ProcessingCategory>(),
            new ApiEnumConverter<string, DeclinedTransactions::RealTimeDecisionReason>(),
            new ApiEnumConverter<string, DeclinedTransactions::CardDeclineReason>(),
            new ApiEnumConverter<string, DeclinedTransactions::SchemeFeeCurrency>(),
            new ApiEnumConverter<string, DeclinedTransactions::FeeType>(),
            new ApiEnumConverter<string, DeclinedTransactions::Result>(),
            new ApiEnumConverter<string, DeclinedTransactions::CardholderAddressResult>(),
            new ApiEnumConverter<string, DeclinedTransactions::CheckDeclineReason>(),
            new ApiEnumConverter<string, DeclinedTransactions::CheckDepositRejectionCurrency>(),
            new ApiEnumConverter<string, DeclinedTransactions::CheckDepositRejectionReason>(),
            new ApiEnumConverter<
                string,
                DeclinedTransactions::InboundFednowTransferDeclineReason
            >(),
            new ApiEnumConverter<
                string,
                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency
            >(),
            new ApiEnumConverter<
                string,
                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason
            >(),
            new ApiEnumConverter<string, DeclinedTransactions::WireDeclineReason>(),
            new ApiEnumConverter<string, DeclinedTransactions::DeclinedTransactionType>(),
            new ApiEnumConverter<string, DeclinedTransactions::In>(),
            new ApiEnumConverter<string, AchTransfers::AchTransferAddendaCategory>(),
            new ApiEnumConverter<string, AchTransfers::CreatedByCategory>(),
            new ApiEnumConverter<string, AchTransfers::Currency>(),
            new ApiEnumConverter<string, AchTransfers::AchTransferDestinationAccountHolder>(),
            new ApiEnumConverter<string, AchTransfers::AchTransferFunding>(),
            new ApiEnumConverter<string, AchTransfers::InboundFundsHoldCurrency>(),
            new ApiEnumConverter<string, AchTransfers::InboundFundsHoldStatus>(),
            new ApiEnumConverter<string, AchTransfers::Type>(),
            new ApiEnumConverter<string, AchTransfers::Network>(),
            new ApiEnumConverter<string, AchTransfers::ChangeCode>(),
            new ApiEnumConverter<
                string,
                AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule
            >(),
            new ApiEnumConverter<string, AchTransfers::ReturnReasonCode>(),
            new ApiEnumConverter<string, AchTransfers::AchTransferStandardEntryClassCode>(),
            new ApiEnumConverter<string, AchTransfers::AchTransferStatus>(),
            new ApiEnumConverter<string, AchTransfers::ExpectedSettlementSchedule>(),
            new ApiEnumConverter<string, AchTransfers::AchTransferType>(),
            new ApiEnumConverter<string, AchTransfers::Category>(),
            new ApiEnumConverter<string, AchTransfers::DestinationAccountHolder>(),
            new ApiEnumConverter<string, AchTransfers::Funding>(),
            new ApiEnumConverter<string, AchTransfers::SettlementSchedule>(),
            new ApiEnumConverter<string, AchTransfers::StandardEntryClassCode>(),
            new ApiEnumConverter<string, AchTransfers::TransactionTiming>(),
            new ApiEnumConverter<string, AchTransfers::In>(),
            new ApiEnumConverter<
                string,
                AchPrenotifications::AchPrenotificationCreditDebitIndicator
            >(),
            new ApiEnumConverter<string, AchPrenotifications::ChangeCode>(),
            new ApiEnumConverter<string, AchPrenotifications::ReturnReasonCode>(),
            new ApiEnumConverter<
                string,
                AchPrenotifications::AchPrenotificationStandardEntryClassCode
            >(),
            new ApiEnumConverter<string, AchPrenotifications::Status>(),
            new ApiEnumConverter<string, AchPrenotifications::Type>(),
            new ApiEnumConverter<string, AchPrenotifications::CreditDebitIndicator>(),
            new ApiEnumConverter<string, AchPrenotifications::StandardEntryClassCode>(),
            new ApiEnumConverter<string, InboundAchTransfers::Category>(),
            new ApiEnumConverter<string, InboundAchTransfers::DeclineReason>(),
            new ApiEnumConverter<string, InboundAchTransfers::Direction>(),
            new ApiEnumConverter<string, InboundAchTransfers::ForeignExchangeIndicator>(),
            new ApiEnumConverter<string, InboundAchTransfers::ForeignExchangeReferenceIndicator>(),
            new ApiEnumConverter<string, InboundAchTransfers::InternationalTransactionTypeCode>(),
            new ApiEnumConverter<
                string,
                InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier
            >(),
            new ApiEnumConverter<
                string,
                InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier
            >(),
            new ApiEnumConverter<string, InboundAchTransfers::SettlementSchedule>(),
            new ApiEnumConverter<string, InboundAchTransfers::StandardEntryClassCode>(),
            new ApiEnumConverter<string, InboundAchTransfers::InboundAchTransferStatus>(),
            new ApiEnumConverter<string, InboundAchTransfers::TransferReturnReason>(),
            new ApiEnumConverter<string, InboundAchTransfers::Type>(),
            new ApiEnumConverter<string, InboundAchTransfers::In>(),
            new ApiEnumConverter<string, InboundAchTransfers::Reason>(),
            new ApiEnumConverter<
                string,
                InboundAchTransfers::InboundAchTransferTransferReturnParamsReason
            >(),
            new ApiEnumConverter<string, WireTransfers::CreatedByCategory>(),
            new ApiEnumConverter<string, WireTransfers::Currency>(),
            new ApiEnumConverter<string, WireTransfers::Network>(),
            new ApiEnumConverter<string, WireTransfers::WireTransferRemittanceCategory>(),
            new ApiEnumConverter<string, WireTransfers::WireTransferStatus>(),
            new ApiEnumConverter<string, WireTransfers::Type>(),
            new ApiEnumConverter<string, WireTransfers::Category>(),
            new ApiEnumConverter<string, WireTransfers::In>(),
            new ApiEnumConverter<string, InboundWireTransfers::ReversalReason>(),
            new ApiEnumConverter<string, InboundWireTransfers::InboundWireTransferStatus>(),
            new ApiEnumConverter<string, InboundWireTransfers::Type>(),
            new ApiEnumConverter<string, InboundWireTransfers::In>(),
            new ApiEnumConverter<string, InboundWireTransfers::Reason>(),
            new ApiEnumConverter<string, WireDrawdownRequests::WireDrawdownRequestStatus>(),
            new ApiEnumConverter<string, WireDrawdownRequests::Type>(),
            new ApiEnumConverter<string, WireDrawdownRequests::ChargeBearer>(),
            new ApiEnumConverter<string, WireDrawdownRequests::In>(),
            new ApiEnumConverter<string, InboundWireDrawdownRequests::Type>(),
            new ApiEnumConverter<string, CheckTransfers::CheckTransferBalanceCheck>(),
            new ApiEnumConverter<string, CheckTransfers::Category>(),
            new ApiEnumConverter<string, CheckTransfers::Currency>(),
            new ApiEnumConverter<string, CheckTransfers::CheckTransferFulfillmentMethod>(),
            new ApiEnumConverter<
                string,
                CheckTransfers::CheckTransferPhysicalCheckShippingMethod
            >(),
            new ApiEnumConverter<string, CheckTransfers::TrackingUpdateCategory>(),
            new ApiEnumConverter<string, CheckTransfers::CheckTransferStatus>(),
            new ApiEnumConverter<string, CheckTransfers::StopPaymentRequestReason>(),
            new ApiEnumConverter<string, CheckTransfers::Type>(),
            new ApiEnumConverter<string, CheckTransfers::CheckTransferType>(),
            new ApiEnumConverter<string, CheckTransfers::FulfillmentMethod>(),
            new ApiEnumConverter<string, CheckTransfers::BalanceCheck>(),
            new ApiEnumConverter<string, CheckTransfers::ShippingMethod>(),
            new ApiEnumConverter<string, CheckTransfers::In>(),
            new ApiEnumConverter<string, CheckTransfers::Reason>(),
            new ApiEnumConverter<string, InboundCheckDeposits::AdjustmentReason>(),
            new ApiEnumConverter<string, InboundCheckDeposits::Currency>(),
            new ApiEnumConverter<string, InboundCheckDeposits::DepositReturnReason>(),
            new ApiEnumConverter<string, InboundCheckDeposits::PayeeNameAnalysis>(),
            new ApiEnumConverter<string, InboundCheckDeposits::Status>(),
            new ApiEnumConverter<string, InboundCheckDeposits::Type>(),
            new ApiEnumConverter<string, InboundCheckDeposits::Reason>(),
            new ApiEnumConverter<string, RealTimePaymentsTransfers::Category>(),
            new ApiEnumConverter<string, RealTimePaymentsTransfers::Currency>(),
            new ApiEnumConverter<string, RealTimePaymentsTransfers::RejectReasonCode>(),
            new ApiEnumConverter<
                string,
                RealTimePaymentsTransfers::RealTimePaymentsTransferStatus
            >(),
            new ApiEnumConverter<string, RealTimePaymentsTransfers::Type>(),
            new ApiEnumConverter<string, RealTimePaymentsTransfers::In>(),
            new ApiEnumConverter<string, InboundRealTimePaymentsTransfers::Currency>(),
            new ApiEnumConverter<string, InboundRealTimePaymentsTransfers::Reason>(),
            new ApiEnumConverter<string, InboundRealTimePaymentsTransfers::Status>(),
            new ApiEnumConverter<string, InboundRealTimePaymentsTransfers::Type>(),
            new ApiEnumConverter<string, FednowTransfers::Category>(),
            new ApiEnumConverter<string, FednowTransfers::Currency>(),
            new ApiEnumConverter<string, FednowTransfers::RejectReasonCode>(),
            new ApiEnumConverter<string, FednowTransfers::FednowTransferStatus>(),
            new ApiEnumConverter<string, FednowTransfers::Type>(),
            new ApiEnumConverter<string, FednowTransfers::In>(),
            new ApiEnumConverter<string, InboundFednowTransfers::Currency>(),
            new ApiEnumConverter<string, InboundFednowTransfers::Reason>(),
            new ApiEnumConverter<string, InboundFednowTransfers::Status>(),
            new ApiEnumConverter<string, InboundFednowTransfers::Type>(),
            new ApiEnumConverter<string, SwiftTransfers::Category>(),
            new ApiEnumConverter<string, SwiftTransfers::SwiftTransferInstructedCurrency>(),
            new ApiEnumConverter<string, SwiftTransfers::SwiftTransferStatus>(),
            new ApiEnumConverter<string, SwiftTransfers::Type>(),
            new ApiEnumConverter<string, SwiftTransfers::InstructedCurrency>(),
            new ApiEnumConverter<string, SwiftTransfers::In>(),
            new ApiEnumConverter<string, CheckDeposits::Currency>(),
            new ApiEnumConverter<string, CheckDeposits::Reason>(),
            new ApiEnumConverter<string, CheckDeposits::DepositRejectionCurrency>(),
            new ApiEnumConverter<string, CheckDeposits::DepositRejectionReason>(),
            new ApiEnumConverter<string, CheckDeposits::DepositReturnCurrency>(),
            new ApiEnumConverter<string, CheckDeposits::ReturnReason>(),
            new ApiEnumConverter<string, CheckDeposits::InboundFundsHoldCurrency>(),
            new ApiEnumConverter<string, CheckDeposits::Status>(),
            new ApiEnumConverter<string, CheckDeposits::Type>(),
            new ApiEnumConverter<string, CheckDeposits::CheckDepositStatus>(),
            new ApiEnumConverter<string, CheckDeposits::CheckDepositType>(),
            new ApiEnumConverter<string, Lockboxes::LockboxCheckDepositBehavior>(),
            new ApiEnumConverter<string, Lockboxes::Type>(),
            new ApiEnumConverter<string, Lockboxes::CheckDepositBehavior>(),
            new ApiEnumConverter<string, InboundMailItems::Status>(),
            new ApiEnumConverter<string, InboundMailItems::RejectionReason>(),
            new ApiEnumConverter<string, InboundMailItems::InboundMailItemStatus>(),
            new ApiEnumConverter<string, InboundMailItems::Type>(),
            new ApiEnumConverter<string, InboundMailItems::Action>(),
            new ApiEnumConverter<string, RoutingNumbers::RoutingNumberListResponseAchTransfers>(),
            new ApiEnumConverter<
                string,
                RoutingNumbers::RoutingNumberListResponseFednowTransfers
            >(),
            new ApiEnumConverter<
                string,
                RoutingNumbers::RoutingNumberListResponseRealTimePaymentsTransfers
            >(),
            new ApiEnumConverter<string, RoutingNumbers::Type>(),
            new ApiEnumConverter<string, RoutingNumbers::RoutingNumberListResponseWireTransfers>(),
            new ApiEnumConverter<string, ExternalAccounts::ExternalAccountAccountHolder>(),
            new ApiEnumConverter<string, ExternalAccounts::ExternalAccountFunding>(),
            new ApiEnumConverter<string, ExternalAccounts::ExternalAccountStatus>(),
            new ApiEnumConverter<string, ExternalAccounts::Type>(),
            new ApiEnumConverter<string, ExternalAccounts::AccountHolder>(),
            new ApiEnumConverter<string, ExternalAccounts::Funding>(),
            new ApiEnumConverter<
                string,
                ExternalAccounts::ExternalAccountUpdateParamsAccountHolder
            >(),
            new ApiEnumConverter<string, ExternalAccounts::ExternalAccountUpdateParamsFunding>(),
            new ApiEnumConverter<string, ExternalAccounts::Status>(),
            new ApiEnumConverter<string, ExternalAccounts::In>(),
            new ApiEnumConverter<
                string,
                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod
            >(),
            new ApiEnumConverter<string, Entities::EntityCorporationBeneficialOwnerProng>(),
            new ApiEnumConverter<string, Entities::EntityCorporationLegalIdentifierCategory>(),
            new ApiEnumConverter<string, Entities::EntityGovernmentAuthorityCategory>(),
            new ApiEnumConverter<string, Entities::EntityJointIndividualIdentificationMethod>(),
            new ApiEnumConverter<string, Entities::EntityNaturalPersonIdentificationMethod>(),
            new ApiEnumConverter<string, Entities::EntityRiskRatingRating>(),
            new ApiEnumConverter<string, Entities::EntityStatus>(),
            new ApiEnumConverter<string, Entities::EntityStructure>(),
            new ApiEnumConverter<string, Entities::EntityThirdPartyVerificationVendor>(),
            new ApiEnumConverter<string, Entities::EntityTrustCategory>(),
            new ApiEnumConverter<string, Entities::EntityTrustGrantorIdentificationMethod>(),
            new ApiEnumConverter<
                string,
                Entities::EntityTrustTrusteeIndividualIdentificationMethod
            >(),
            new ApiEnumConverter<string, Entities::EntityTrustTrusteeStructure>(),
            new ApiEnumConverter<string, Entities::Type>(),
            new ApiEnumConverter<string, Entities::Reason>(),
            new ApiEnumConverter<string, Entities::IssueCategory>(),
            new ApiEnumConverter<string, Entities::EntityAddressReason>(),
            new ApiEnumConverter<string, Entities::ValidationStatus>(),
            new ApiEnumConverter<string, Entities::Structure>(),
            new ApiEnumConverter<string, Entities::Method>(),
            new ApiEnumConverter<string, Entities::Prong>(),
            new ApiEnumConverter<string, Entities::Category>(),
            new ApiEnumConverter<string, Entities::BeneficialOwnershipExemptionReason>(),
            new ApiEnumConverter<string, Entities::GovernmentAuthorityCategory>(),
            new ApiEnumConverter<string, Entities::JointIndividualIdentificationMethod>(),
            new ApiEnumConverter<string, Entities::NaturalPersonIdentificationMethod>(),
            new ApiEnumConverter<string, Entities::Rating>(),
            new ApiEnumConverter<string, Entities::Vendor>(),
            new ApiEnumConverter<string, Entities::TrustCategory>(),
            new ApiEnumConverter<string, Entities::TrusteeStructure>(),
            new ApiEnumConverter<string, Entities::TrusteeIndividualIdentificationMethod>(),
            new ApiEnumConverter<string, Entities::GrantorIdentificationMethod>(),
            new ApiEnumConverter<
                string,
                Entities::EntityUpdateParamsCorporationLegalIdentifierCategory
            >(),
            new ApiEnumConverter<
                string,
                Entities::EntityUpdateParamsNaturalPersonIdentificationMethod
            >(),
            new ApiEnumConverter<string, Entities::EntityUpdateParamsRiskRatingRating>(),
            new ApiEnumConverter<
                string,
                Entities::EntityUpdateParamsThirdPartyVerificationVendor
            >(),
            new ApiEnumConverter<string, Entities::In>(),
            new ApiEnumConverter<
                string,
                BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod
            >(),
            new ApiEnumConverter<string, BeneficialOwners::EntityBeneficialOwnerProng>(),
            new ApiEnumConverter<string, BeneficialOwners::Type>(),
            new ApiEnumConverter<string, BeneficialOwners::Method>(),
            new ApiEnumConverter<string, BeneficialOwners::Prong>(),
            new ApiEnumConverter<
                string,
                BeneficialOwners::BeneficialOwnerUpdateParamsIdentificationMethod
            >(),
            new ApiEnumConverter<string, SupplementalDocuments::Type>(),
            new ApiEnumConverter<string, EntityOnboardingSessions::EntityOnboardingSessionStatus>(),
            new ApiEnumConverter<string, EntityOnboardingSessions::Type>(),
            new ApiEnumConverter<string, EntityOnboardingSessions::In>(),
            new ApiEnumConverter<string, Programs::Bank>(),
            new ApiEnumConverter<string, Programs::Type>(),
            new ApiEnumConverter<string, AccountStatements::Type>(),
            new ApiEnumConverter<string, Files::Direction>(),
            new ApiEnumConverter<string, Files::FilePurpose>(),
            new ApiEnumConverter<string, Files::Type>(),
            new ApiEnumConverter<string, Files::Purpose>(),
            new ApiEnumConverter<string, Files::In>(),
            new ApiEnumConverter<string, FileLinks::Type>(),
            new ApiEnumConverter<string, Exports::ExportCategory>(),
            new ApiEnumConverter<string, Exports::ExportStatus>(),
            new ApiEnumConverter<string, Exports::Type>(),
            new ApiEnumConverter<string, Exports::Category>(),
            new ApiEnumConverter<string, Exports::ExportListParamsCategory>(),
            new ApiEnumConverter<string, Exports::In>(),
            new ApiEnumConverter<string, Events::EventCategory>(),
            new ApiEnumConverter<string, Events::Type>(),
            new ApiEnumConverter<string, Events::UnwrapWebhookEventCategory>(),
            new ApiEnumConverter<string, Events::UnwrapWebhookEventType>(),
            new ApiEnumConverter<string, Events::In>(),
            new ApiEnumConverter<
                string,
                EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory
            >(),
            new ApiEnumConverter<string, EventSubscriptions::EventSubscriptionStatus>(),
            new ApiEnumConverter<string, EventSubscriptions::Type>(),
            new ApiEnumConverter<string, EventSubscriptions::EventCategory>(),
            new ApiEnumConverter<string, EventSubscriptions::Status>(),
            new ApiEnumConverter<string, EventSubscriptions::EventSubscriptionUpdateParamsStatus>(),
            new ApiEnumConverter<
                string,
                RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision
            >(),
            new ApiEnumConverter<string, RealTimeDecisions::JavascriptEnabled>(),
            new ApiEnumConverter<string, RealTimeDecisions::Category>(),
            new ApiEnumConverter<string, RealTimeDecisions::Indicator>(),
            new ApiEnumConverter<string, RealTimeDecisions::MessageCategoryCategory>(),
            new ApiEnumConverter<string, RealTimeDecisions::TransactionType>(),
            new ApiEnumConverter<string, RealTimeDecisions::RequestorAuthenticationIndicator>(),
            new ApiEnumConverter<string, RealTimeDecisions::RequestorChallengeIndicator>(),
            new ApiEnumConverter<
                string,
                RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult
            >(),
            new ApiEnumConverter<
                string,
                RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision
            >(),
            new ApiEnumConverter<
                string,
                RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason
            >(),
            new ApiEnumConverter<string, RealTimeDecisions::Direction>(),
            new ApiEnumConverter<string, RealTimeDecisions::NetworkDetailsCategory>(),
            new ApiEnumConverter<string, RealTimeDecisions::ElectronicCommerceIndicator>(),
            new ApiEnumConverter<string, RealTimeDecisions::PointOfServiceEntryMode>(),
            new ApiEnumConverter<string, RealTimeDecisions::StandInProcessingReason>(),
            new ApiEnumConverter<string, RealTimeDecisions::TerminalEntryCapability>(),
            new ApiEnumConverter<string, RealTimeDecisions::PartialApprovalCapability>(),
            new ApiEnumConverter<string, RealTimeDecisions::ProcessingCategory>(),
            new ApiEnumConverter<string, RealTimeDecisions::RequestDetailsCategory>(),
            new ApiEnumConverter<string, RealTimeDecisions::CardVerificationCodeResult>(),
            new ApiEnumConverter<string, RealTimeDecisions::CardholderAddressResult>(),
            new ApiEnumConverter<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision
            >(),
            new ApiEnumConverter<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory
            >(),
            new ApiEnumConverter<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator
            >(),
            new ApiEnumConverter<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode
            >(),
            new ApiEnumConverter<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason
            >(),
            new ApiEnumConverter<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability
            >(),
            new ApiEnumConverter<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult
            >(),
            new ApiEnumConverter<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult
            >(),
            new ApiEnumConverter<string, RealTimeDecisions::RealTimeDecisionCategory>(),
            new ApiEnumConverter<string, RealTimeDecisions::Channel>(),
            new ApiEnumConverter<string, RealTimeDecisions::DigitalWallet>(),
            new ApiEnumConverter<
                string,
                RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult
            >(),
            new ApiEnumConverter<
                string,
                RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision
            >(),
            new ApiEnumConverter<
                string,
                RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet
            >(),
            new ApiEnumConverter<string, RealTimeDecisions::Status>(),
            new ApiEnumConverter<string, RealTimeDecisions::Type>(),
            new ApiEnumConverter<string, RealTimeDecisions::Decision>(),
            new ApiEnumConverter<string, RealTimeDecisions::Result>(),
            new ApiEnumConverter<string, RealTimeDecisions::CardAuthorizationDecision>(),
            new ApiEnumConverter<string, RealTimeDecisions::Line1>(),
            new ApiEnumConverter<string, RealTimeDecisions::PostalCode>(),
            new ApiEnumConverter<string, RealTimeDecisions::Reason>(),
            new ApiEnumConverter<string, RealTimeDecisions::CardBalanceInquiryDecision>(),
            new ApiEnumConverter<string, RealTimeDecisions::DigitalWalletAuthenticationResult>(),
            new ApiEnumConverter<
                string,
                BookkeepingAccounts::BookkeepingAccountComplianceCategory
            >(),
            new ApiEnumConverter<string, BookkeepingAccounts::Type>(),
            new ApiEnumConverter<string, BookkeepingAccounts::BookkeepingBalanceLookupType>(),
            new ApiEnumConverter<string, BookkeepingAccounts::ComplianceCategory>(),
            new ApiEnumConverter<string, BookkeepingEntrySets::Type>(),
            new ApiEnumConverter<string, BookkeepingEntries::Type>(),
            new ApiEnumConverter<string, Groups::Type>(),
            new ApiEnumConverter<string, OAuthApplications::OAuthApplicationStatus>(),
            new ApiEnumConverter<string, OAuthApplications::Type>(),
            new ApiEnumConverter<string, OAuthApplications::In>(),
            new ApiEnumConverter<string, OAuthConnections::OAuthConnectionStatus>(),
            new ApiEnumConverter<string, OAuthConnections::Type>(),
            new ApiEnumConverter<string, OAuthConnections::In>(),
            new ApiEnumConverter<string, OAuthTokens::TokenType>(),
            new ApiEnumConverter<string, OAuthTokens::Type>(),
            new ApiEnumConverter<string, OAuthTokens::GrantType>(),
            new ApiEnumConverter<
                string,
                IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus
            >(),
            new ApiEnumConverter<string, IntrafiAccountEnrollments::Type>(),
            new ApiEnumConverter<string, IntrafiAccountEnrollments::In>(),
            new ApiEnumConverter<string, IntrafiBalances::Currency>(),
            new ApiEnumConverter<string, IntrafiBalances::Type>(),
            new ApiEnumConverter<string, IntrafiExclusions::Status>(),
            new ApiEnumConverter<string, IntrafiExclusions::Type>(),
            new ApiEnumConverter<string, CardTokens::Type>(),
            new ApiEnumConverter<string, CardTokens::CrossBorderPushTransfers>(),
            new ApiEnumConverter<string, CardTokens::DomesticPushTransfers>(),
            new ApiEnumConverter<string, CardTokens::RouteRoute>(),
            new ApiEnumConverter<string, CardTokens::CardTokenCapabilitiesType>(),
            new ApiEnumConverter<string, CardPushTransfers::CardVerificationValue2Result>(),
            new ApiEnumConverter<
                string,
                CardPushTransfers::CardPushTransferBusinessApplicationIdentifier
            >(),
            new ApiEnumConverter<string, CardPushTransfers::Category>(),
            new ApiEnumConverter<string, CardPushTransfers::Reason>(),
            new ApiEnumConverter<
                string,
                CardPushTransfers::CardPushTransferPresentmentAmountCurrency
            >(),
            new ApiEnumConverter<string, CardPushTransfers::Route>(),
            new ApiEnumConverter<string, CardPushTransfers::CardPushTransferStatus>(),
            new ApiEnumConverter<string, CardPushTransfers::Type>(),
            new ApiEnumConverter<string, CardPushTransfers::BusinessApplicationIdentifier>(),
            new ApiEnumConverter<string, CardPushTransfers::Currency>(),
            new ApiEnumConverter<string, CardPushTransfers::In>(),
            new ApiEnumConverter<string, CardValidations::CardVerificationValue2Result>(),
            new ApiEnumConverter<string, CardValidations::CardholderFirstNameResult>(),
            new ApiEnumConverter<string, CardValidations::CardholderFullNameResult>(),
            new ApiEnumConverter<string, CardValidations::CardholderLastNameResult>(),
            new ApiEnumConverter<string, CardValidations::CardholderMiddleNameResult>(),
            new ApiEnumConverter<string, CardValidations::CardholderPostalCodeResult>(),
            new ApiEnumConverter<string, CardValidations::CardholderStreetAddressResult>(),
            new ApiEnumConverter<string, CardValidations::Category>(),
            new ApiEnumConverter<string, CardValidations::Reason>(),
            new ApiEnumConverter<string, CardValidations::Route>(),
            new ApiEnumConverter<string, CardValidations::CardValidationStatus>(),
            new ApiEnumConverter<string, CardValidations::Type>(),
            new ApiEnumConverter<string, CardValidations::In>(),
            new ApiEnumConverter<string, CardAuthorizations::Type>(),
            new ApiEnumConverter<string, CardAuthorizations::DeclineReason>(),
            new ApiEnumConverter<string, CardAuthorizations::StandInProcessingReason>(),
            new ApiEnumConverter<string, CardAuthorizations::Category>(),
            new ApiEnumConverter<string, DeclineReason>(),
            new ApiEnumConverter<string, StandInProcessingReason>(),
            new ApiEnumConverter<string, Category>(),
            new ApiEnumConverter<string, DeviceChannel>(),
            new ApiEnumConverter<string, Network>(),
            new ApiEnumConverter<string, Action>(),
            new ApiEnumConverter<string, SimulationsPhysicalCards::Category>(),
            new ApiEnumConverter<string, SimulationsPhysicalCards::ShipmentStatus>(),
            new ApiEnumConverter<string, DigitalWalletTokenRequests::DeclineReason>(),
            new ApiEnumConverter<string, DigitalWalletTokenRequests::Type>(),
            new ApiEnumConverter<string, ChangeCode>(),
            new ApiEnumConverter<string, Reason>(),
            new ApiEnumConverter<string, InboundFundsHoldBehavior>(),
            new ApiEnumConverter<string, SimulationsInboundAchTransfers::Category>(),
            new ApiEnumConverter<string, SimulationsInboundAchTransfers::StandardEntryClassCode>(),
            new ApiEnumConverter<string, SimulationsInboundCheckDeposits::PayeeNameAnalysis>(),
            new ApiEnumConverter<string, SimulationsInboundCheckDeposits::Reason>(),
            new ApiEnumConverter<string, RejectReasonCode>(),
            new ApiEnumConverter<string, SimulationsCheckDeposits::Reason>(),
            new ApiEnumConverter<string, SimulationsPrograms::Bank>(),
            new ApiEnumConverter<string, SimulationsExports::Category>(),
            new ApiEnumConverter<string, SimulationsCardTokens::CrossBorderPushTransfers>(),
            new ApiEnumConverter<string, SimulationsCardTokens::DomesticPushTransfers>(),
            new ApiEnumConverter<string, SimulationsCardTokens::Route>(),
            new ApiEnumConverter<string, SimulationsCardTokens::Result>(),
            new ApiEnumConverter<string, SimulationsCardTokens::Reason>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="IncreaseInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
