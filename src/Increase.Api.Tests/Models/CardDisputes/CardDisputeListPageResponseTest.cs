using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using CardDisputes = Increase.Api.Models.CardDisputes;

namespace Increase.Api.Tests.Models.CardDisputes;

public class CardDisputeListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardDisputes::CardDisputeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "card_dispute_h9sc95nbl1cgltpp7men",
                    Amount = 1000,
                    CardID = "card_oubs0hwk5rn6knuecxg2",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DisputedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    IdempotencyKey = null,
                    Loss = new()
                    {
                        LostAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Reason = CardDisputes::LossReason.UserWithdrawn,
                    },
                    Network = CardDisputes::CardDisputeNetwork.Visa,
                    Status = CardDisputes::CardDisputeStatus.PendingResponse,
                    Type = CardDisputes::Type.CardDispute,
                    UserSubmissionRequiredBy = null,
                    Visa = new()
                    {
                        NetworkEvents =
                        [
                            new()
                            {
                                AttachmentFiles = [new("file_id")],
                                Category = CardDisputes::NetworkEventCategory.ChargebackAccepted,
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                DisputeFinancialTransactionID = "dispute_financial_transaction_id",
                                ChargebackAccepted = new(),
                                ChargebackSubmitted = new(),
                                ChargebackTimedOut = new(),
                                MerchantPrearbitrationDeclineSubmitted = new(),
                                MerchantPrearbitrationReceived = new()
                                {
                                    CardholderNoLongerDisputes = new(
                                        "See the attached email where the cardholder confirmed that they no longer dispute the transaction."
                                    ),
                                    CompellingEvidence = new()
                                    {
                                        Category =
                                            CardDisputes::CompellingEvidenceCategory.MerchandiseUse,
                                        Explanation = null,
                                    },
                                    CreditOrReversalProcessed = new()
                                    {
                                        Amount = 4900,
                                        Currency = "USD",
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        ProcessedAt = "2020-01-31",
                                    },
                                    DelayedChargeTransaction = new((string?)null),
                                    EvidenceOfImprint = new((string?)null),
                                    InvalidDispute = new()
                                    {
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        Reason = CardDisputes::InvalidDisputeReason.Other,
                                    },
                                    NonFiatCurrencyOrNonFungibleTokenReceived = new()
                                    {
                                        BlockchainTransactionHash =
                                            "0x1234567890123456789012345678901234567890",
                                        DestinationWalletAddress =
                                            "0x1234567890123456789012345678901234567890",
                                        PriorApprovedTransactions =
                                            "0x1234567890123456789012345678901234567890",
                                    },
                                    PriorUndisputedNonFraudTransactions = new((string?)null),
                                    Reason =
                                        CardDisputes::MerchantPrearbitrationReceivedReason.CardholderNoLongerDisputes,
                                },
                                MerchantPrearbitrationTimedOut = new(),
                                Represented = new()
                                {
                                    CardholderNoLongerDisputes = new(
                                        "See the attached email where the cardholder confirmed that they no longer dispute the transaction."
                                    ),
                                    CreditOrReversalProcessed = new()
                                    {
                                        Amount = 4900,
                                        Currency = "USD",
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        ProcessedAt = "2020-01-31",
                                    },
                                    InvalidDispute = new()
                                    {
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        Reason =
                                            CardDisputes::RepresentedInvalidDisputeReason.Other,
                                    },
                                    NonFiatCurrencyOrNonFungibleTokenAsDescribed = new(),
                                    NonFiatCurrencyOrNonFungibleTokenReceived = new()
                                    {
                                        BlockchainTransactionHash =
                                            "0x1234567890123456789012345678901234567890",
                                        DestinationWalletAddress =
                                            "0x1234567890123456789012345678901234567890",
                                        PriorApprovedTransactions =
                                            "0x1234567890123456789012345678901234567890",
                                    },
                                    ProofOfCashDisbursement = new((string?)null),
                                    Reason = CardDisputes::RepresentedReason.InvalidDispute,
                                    ReversalIssued = new(
                                        "The merchant has issued a reversal for the transaction prior to the dispute being filed."
                                    ),
                                },
                                RepresentmentTimedOut = new(),
                                UserPrearbitrationAccepted = new(),
                                UserPrearbitrationDeclined = new(),
                                UserPrearbitrationSubmitted = new(),
                                UserPrearbitrationTimedOut = new(),
                                UserWithdrawalSubmitted = new(),
                            },
                        ],
                        RequiredUserSubmissionCategory = null,
                        UserSubmissions =
                        [
                            new()
                            {
                                AcceptedAt = null,
                                Amount = 1000,
                                AttachmentFiles = [new("file_id")],
                                Category = CardDisputes::UserSubmissionCategory.Chargeback,
                                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                Explanation = null,
                                FurtherInformationRequestedAt = null,
                                FurtherInformationRequestedReason = null,
                                Status = CardDisputes::UserSubmissionStatus.PendingReviewing,
                                UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                Chargeback = new()
                                {
                                    Authorization = new(
                                        CardDisputes::UserSubmissionChargebackAuthorizationAccountStatus.AccountClosed
                                    ),
                                    Category = CardDisputes::UserSubmissionChargebackCategory.Fraud,
                                    ConsumerCanceledMerchandise = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            CanceledPriorToShipDate =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                                            CancellationPolicyProvided =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                                            Reason = "reason",
                                        },
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                                        NotReturned = new(),
                                        PurchaseExplanation = "purchase_explanation",
                                        ReceivedOrExpectedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerCanceledRecurringTransaction = new()
                                    {
                                        CancellationTarget =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                                        MerchantContactMethods = new()
                                        {
                                            ApplicationName = "application_name",
                                            CallCenterPhoneNumber = "call_center_phone_number",
                                            EmailAddress = "email_address",
                                            InPersonAddress = "in_person_address",
                                            MailingAddress = "mailing_address",
                                            TextPhoneNumber = "text_phone_number",
                                        },
                                        OtherFormOfPaymentExplanation =
                                            "other_form_of_payment_explanation",
                                        TransactionOrAccountCanceledAt = "2019-12-27",
                                    },
                                    ConsumerCanceledServices = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            CancellationPolicyProvided =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                                            Reason = "reason",
                                        },
                                        ContractedAt = "2019-12-27",
                                        GuaranteedReservation = new(
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                                        ),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                                        Other = new(),
                                        PurchaseExplanation = "purchase_explanation",
                                        ServiceType =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                                        Timeshare = new(),
                                    },
                                    ConsumerCounterfeitMerchandise = new()
                                    {
                                        CounterfeitExplanation = "counterfeit_explanation",
                                        DispositionExplanation = "disposition_explanation",
                                        OrderExplanation = "order_explanation",
                                        ReceivedAt = "2019-12-27",
                                    },
                                    ConsumerCreditNotProcessed = new()
                                    {
                                        CanceledOrReturnedAt = "2019-12-27",
                                        CreditExpectedAt = "2019-12-27",
                                    },
                                    ConsumerDamagedOrDefectiveMerchandise = new()
                                    {
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                                        NotReturned = new(),
                                        OrderAndIssueExplanation = "order_and_issue_explanation",
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerMerchandiseMisrepresentation = new()
                                    {
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                                        MisrepresentationExplanation =
                                            "misrepresentation_explanation",
                                        NotReturned = new(),
                                        PurchaseExplanation = "purchase_explanation",
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerMerchandiseNotAsDescribed = new()
                                    {
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerMerchandiseNotReceived = new()
                                    {
                                        CancellationOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                                        CardholderCancellationPriorToExpectedReceipt = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        Delayed = new()
                                        {
                                            Explanation = "explanation",
                                            NotReturned = new(),
                                            ReturnAttempted = new("2019-12-27"),
                                            ReturnOutcome =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                                            Returned = new()
                                            {
                                                MerchantReceivedReturnAt = "2019-12-27",
                                                ReturnedAt = "2019-12-27",
                                            },
                                        },
                                        DeliveredToWrongLocation = new("agreed_location"),
                                        DeliveryIssue =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                                        LastExpectedReceiptAt = "2019-12-27",
                                        MerchantCancellation = new("2019-12-27"),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                                        NoCancellation = new(),
                                        PurchaseInfoAndExplanation =
                                            "purchase_info_and_explanation",
                                    },
                                    ConsumerNonReceiptOfCash = new(),
                                    ConsumerOriginalCreditTransactionNotAccepted = new()
                                    {
                                        Explanation = "explanation",
                                        Reason =
                                            CardDisputes::UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
                                    },
                                    ConsumerQualityMerchandise = new()
                                    {
                                        ExpectedAt = "2019-12-27",
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                                        NotReturned = new(),
                                        OngoingNegotiations = new()
                                        {
                                            Explanation = "explanation",
                                            IssuerFirstNotifiedAt = "2019-12-27",
                                            StartedAt = "2019-12-27",
                                        },
                                        PurchaseInfoAndQualityIssue =
                                            "purchase_info_and_quality_issue",
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerQualityServices = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            AcceptedByMerchant =
                                                CardDisputes::UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        CardholderPaidToHaveWorkRedone =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                                        NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                                        OngoingNegotiations = new()
                                        {
                                            Explanation = "explanation",
                                            IssuerFirstNotifiedAt = "2019-12-27",
                                            StartedAt = "2019-12-27",
                                        },
                                        PurchaseInfoAndQualityIssue =
                                            "purchase_info_and_quality_issue",
                                        RestaurantFoodRelated =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
                                        ServicesReceivedAt = "2019-12-27",
                                    },
                                    ConsumerServicesMisrepresentation = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            AcceptedByMerchant =
                                                CardDisputes::UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                                        MisrepresentationExplanation =
                                            "misrepresentation_explanation",
                                        PurchaseExplanation = "purchase_explanation",
                                        ReceivedAt = "2019-12-27",
                                    },
                                    ConsumerServicesNotAsDescribed = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            AcceptedByMerchant =
                                                CardDisputes::UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        Explanation = "explanation",
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                                        ReceivedAt = "2019-12-27",
                                    },
                                    ConsumerServicesNotReceived = new()
                                    {
                                        CancellationOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                                        CardholderCancellationPriorToExpectedReceipt = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        LastExpectedReceiptAt = "2019-12-27",
                                        MerchantCancellation = new("2019-12-27"),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                                        NoCancellation = new(),
                                        PurchaseInfoAndExplanation =
                                            "purchase_info_and_explanation",
                                    },
                                    Fraud = new(
                                        CardDisputes::UserSubmissionChargebackFraudFraudType.Lost
                                    ),
                                    ProcessingError = new()
                                    {
                                        DuplicateTransaction = new("other_transaction_id"),
                                        ErrorReason =
                                            CardDisputes::UserSubmissionChargebackProcessingErrorErrorReason.DuplicateTransaction,
                                        IncorrectAmount = new(0),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                                        PaidByOtherMeans = new()
                                        {
                                            OtherFormOfPaymentEvidence =
                                                CardDisputes::UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                                            OtherTransactionID = "other_transaction_id",
                                        },
                                    },
                                },
                                MerchantPrearbitrationDecline = new(
                                    "I do not believe the explanation given by the merchant is valid."
                                ),
                                UserPrearbitration = new()
                                {
                                    CategoryChange = new()
                                    {
                                        Category =
                                            CardDisputes::UserSubmissionUserPrearbitrationCategoryChangeCategory.Fraud,
                                        Reason = "Based on the response from the merchant.",
                                    },
                                    Reason =
                                        "I disagree with the explanation given by the merchant.",
                                },
                            },
                        ],
                    },
                    Win = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
                    Withdrawal = new("The cardholder requested a withdrawal of the dispute."),
                },
            ],
            NextCursor = "v57w5d",
        };

        List<CardDisputes::CardDispute> expectedData =
        [
            new()
            {
                ID = "card_dispute_h9sc95nbl1cgltpp7men",
                Amount = 1000,
                CardID = "card_oubs0hwk5rn6knuecxg2",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                DisputedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                IdempotencyKey = null,
                Loss = new()
                {
                    LostAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Reason = CardDisputes::LossReason.UserWithdrawn,
                },
                Network = CardDisputes::CardDisputeNetwork.Visa,
                Status = CardDisputes::CardDisputeStatus.PendingResponse,
                Type = CardDisputes::Type.CardDispute,
                UserSubmissionRequiredBy = null,
                Visa = new()
                {
                    NetworkEvents =
                    [
                        new()
                        {
                            AttachmentFiles = [new("file_id")],
                            Category = CardDisputes::NetworkEventCategory.ChargebackAccepted,
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            DisputeFinancialTransactionID = "dispute_financial_transaction_id",
                            ChargebackAccepted = new(),
                            ChargebackSubmitted = new(),
                            ChargebackTimedOut = new(),
                            MerchantPrearbitrationDeclineSubmitted = new(),
                            MerchantPrearbitrationReceived = new()
                            {
                                CardholderNoLongerDisputes = new(
                                    "See the attached email where the cardholder confirmed that they no longer dispute the transaction."
                                ),
                                CompellingEvidence = new()
                                {
                                    Category =
                                        CardDisputes::CompellingEvidenceCategory.MerchandiseUse,
                                    Explanation = null,
                                },
                                CreditOrReversalProcessed = new()
                                {
                                    Amount = 4900,
                                    Currency = "USD",
                                    Explanation =
                                        "The user did not provide the required documentation.",
                                    ProcessedAt = "2020-01-31",
                                },
                                DelayedChargeTransaction = new((string?)null),
                                EvidenceOfImprint = new((string?)null),
                                InvalidDispute = new()
                                {
                                    Explanation =
                                        "The user did not provide the required documentation.",
                                    Reason = CardDisputes::InvalidDisputeReason.Other,
                                },
                                NonFiatCurrencyOrNonFungibleTokenReceived = new()
                                {
                                    BlockchainTransactionHash =
                                        "0x1234567890123456789012345678901234567890",
                                    DestinationWalletAddress =
                                        "0x1234567890123456789012345678901234567890",
                                    PriorApprovedTransactions =
                                        "0x1234567890123456789012345678901234567890",
                                },
                                PriorUndisputedNonFraudTransactions = new((string?)null),
                                Reason =
                                    CardDisputes::MerchantPrearbitrationReceivedReason.CardholderNoLongerDisputes,
                            },
                            MerchantPrearbitrationTimedOut = new(),
                            Represented = new()
                            {
                                CardholderNoLongerDisputes = new(
                                    "See the attached email where the cardholder confirmed that they no longer dispute the transaction."
                                ),
                                CreditOrReversalProcessed = new()
                                {
                                    Amount = 4900,
                                    Currency = "USD",
                                    Explanation =
                                        "The user did not provide the required documentation.",
                                    ProcessedAt = "2020-01-31",
                                },
                                InvalidDispute = new()
                                {
                                    Explanation =
                                        "The user did not provide the required documentation.",
                                    Reason = CardDisputes::RepresentedInvalidDisputeReason.Other,
                                },
                                NonFiatCurrencyOrNonFungibleTokenAsDescribed = new(),
                                NonFiatCurrencyOrNonFungibleTokenReceived = new()
                                {
                                    BlockchainTransactionHash =
                                        "0x1234567890123456789012345678901234567890",
                                    DestinationWalletAddress =
                                        "0x1234567890123456789012345678901234567890",
                                    PriorApprovedTransactions =
                                        "0x1234567890123456789012345678901234567890",
                                },
                                ProofOfCashDisbursement = new((string?)null),
                                Reason = CardDisputes::RepresentedReason.InvalidDispute,
                                ReversalIssued = new(
                                    "The merchant has issued a reversal for the transaction prior to the dispute being filed."
                                ),
                            },
                            RepresentmentTimedOut = new(),
                            UserPrearbitrationAccepted = new(),
                            UserPrearbitrationDeclined = new(),
                            UserPrearbitrationSubmitted = new(),
                            UserPrearbitrationTimedOut = new(),
                            UserWithdrawalSubmitted = new(),
                        },
                    ],
                    RequiredUserSubmissionCategory = null,
                    UserSubmissions =
                    [
                        new()
                        {
                            AcceptedAt = null,
                            Amount = 1000,
                            AttachmentFiles = [new("file_id")],
                            Category = CardDisputes::UserSubmissionCategory.Chargeback,
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Explanation = null,
                            FurtherInformationRequestedAt = null,
                            FurtherInformationRequestedReason = null,
                            Status = CardDisputes::UserSubmissionStatus.PendingReviewing,
                            UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Chargeback = new()
                            {
                                Authorization = new(
                                    CardDisputes::UserSubmissionChargebackAuthorizationAccountStatus.AccountClosed
                                ),
                                Category = CardDisputes::UserSubmissionChargebackCategory.Fraud,
                                ConsumerCanceledMerchandise = new()
                                {
                                    CardholderCancellation = new()
                                    {
                                        CanceledAt = "2019-12-27",
                                        CanceledPriorToShipDate =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                                        CancellationPolicyProvided =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                                        Reason = "reason",
                                    },
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                                    NotReturned = new(),
                                    PurchaseExplanation = "purchase_explanation",
                                    ReceivedOrExpectedAt = "2019-12-27",
                                    ReturnAttempted = new()
                                    {
                                        AttemptExplanation = "attempt_explanation",
                                        AttemptReason =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                        AttemptedAt = "2019-12-27",
                                        MerchandiseDisposition = "merchandise_disposition",
                                    },
                                    ReturnOutcome =
                                        CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                                    Returned = new()
                                    {
                                        MerchantReceivedReturnAt = "2019-12-27",
                                        OtherExplanation = "other_explanation",
                                        ReturnMethod =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                                        ReturnedAt = "2019-12-27",
                                        TrackingNumber = "tracking_number",
                                    },
                                },
                                ConsumerCanceledRecurringTransaction = new()
                                {
                                    CancellationTarget =
                                        CardDisputes::UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                                    MerchantContactMethods = new()
                                    {
                                        ApplicationName = "application_name",
                                        CallCenterPhoneNumber = "call_center_phone_number",
                                        EmailAddress = "email_address",
                                        InPersonAddress = "in_person_address",
                                        MailingAddress = "mailing_address",
                                        TextPhoneNumber = "text_phone_number",
                                    },
                                    OtherFormOfPaymentExplanation =
                                        "other_form_of_payment_explanation",
                                    TransactionOrAccountCanceledAt = "2019-12-27",
                                },
                                ConsumerCanceledServices = new()
                                {
                                    CardholderCancellation = new()
                                    {
                                        CanceledAt = "2019-12-27",
                                        CancellationPolicyProvided =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                                        Reason = "reason",
                                    },
                                    ContractedAt = "2019-12-27",
                                    GuaranteedReservation = new(
                                        CardDisputes::UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                                    ),
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                                    Other = new(),
                                    PurchaseExplanation = "purchase_explanation",
                                    ServiceType =
                                        CardDisputes::UserSubmissionChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                                    Timeshare = new(),
                                },
                                ConsumerCounterfeitMerchandise = new()
                                {
                                    CounterfeitExplanation = "counterfeit_explanation",
                                    DispositionExplanation = "disposition_explanation",
                                    OrderExplanation = "order_explanation",
                                    ReceivedAt = "2019-12-27",
                                },
                                ConsumerCreditNotProcessed = new()
                                {
                                    CanceledOrReturnedAt = "2019-12-27",
                                    CreditExpectedAt = "2019-12-27",
                                },
                                ConsumerDamagedOrDefectiveMerchandise = new()
                                {
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                                    NotReturned = new(),
                                    OrderAndIssueExplanation = "order_and_issue_explanation",
                                    ReceivedAt = "2019-12-27",
                                    ReturnAttempted = new()
                                    {
                                        AttemptExplanation = "attempt_explanation",
                                        AttemptReason =
                                            CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                        AttemptedAt = "2019-12-27",
                                        MerchandiseDisposition = "merchandise_disposition",
                                    },
                                    ReturnOutcome =
                                        CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                                    Returned = new()
                                    {
                                        MerchantReceivedReturnAt = "2019-12-27",
                                        OtherExplanation = "other_explanation",
                                        ReturnMethod =
                                            CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                                        ReturnedAt = "2019-12-27",
                                        TrackingNumber = "tracking_number",
                                    },
                                },
                                ConsumerMerchandiseMisrepresentation = new()
                                {
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                                    MisrepresentationExplanation = "misrepresentation_explanation",
                                    NotReturned = new(),
                                    PurchaseExplanation = "purchase_explanation",
                                    ReceivedAt = "2019-12-27",
                                    ReturnAttempted = new()
                                    {
                                        AttemptExplanation = "attempt_explanation",
                                        AttemptReason =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                                        AttemptedAt = "2019-12-27",
                                        MerchandiseDisposition = "merchandise_disposition",
                                    },
                                    ReturnOutcome =
                                        CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                                    Returned = new()
                                    {
                                        MerchantReceivedReturnAt = "2019-12-27",
                                        OtherExplanation = "other_explanation",
                                        ReturnMethod =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                                        ReturnedAt = "2019-12-27",
                                        TrackingNumber = "tracking_number",
                                    },
                                },
                                ConsumerMerchandiseNotAsDescribed = new()
                                {
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                                    ReceivedAt = "2019-12-27",
                                    ReturnAttempted = new()
                                    {
                                        AttemptExplanation = "attempt_explanation",
                                        AttemptReason =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                                        AttemptedAt = "2019-12-27",
                                        MerchandiseDisposition = "merchandise_disposition",
                                    },
                                    ReturnOutcome =
                                        CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                                    Returned = new()
                                    {
                                        MerchantReceivedReturnAt = "2019-12-27",
                                        OtherExplanation = "other_explanation",
                                        ReturnMethod =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                                        ReturnedAt = "2019-12-27",
                                        TrackingNumber = "tracking_number",
                                    },
                                },
                                ConsumerMerchandiseNotReceived = new()
                                {
                                    CancellationOutcome =
                                        CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                                    CardholderCancellationPriorToExpectedReceipt = new()
                                    {
                                        CanceledAt = "2019-12-27",
                                        Reason = "reason",
                                    },
                                    Delayed = new()
                                    {
                                        Explanation = "explanation",
                                        NotReturned = new(),
                                        ReturnAttempted = new("2019-12-27"),
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            ReturnedAt = "2019-12-27",
                                        },
                                    },
                                    DeliveredToWrongLocation = new("agreed_location"),
                                    DeliveryIssue =
                                        CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                                    LastExpectedReceiptAt = "2019-12-27",
                                    MerchantCancellation = new("2019-12-27"),
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                                    NoCancellation = new(),
                                    PurchaseInfoAndExplanation = "purchase_info_and_explanation",
                                },
                                ConsumerNonReceiptOfCash = new(),
                                ConsumerOriginalCreditTransactionNotAccepted = new()
                                {
                                    Explanation = "explanation",
                                    Reason =
                                        CardDisputes::UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
                                },
                                ConsumerQualityMerchandise = new()
                                {
                                    ExpectedAt = "2019-12-27",
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                                    NotReturned = new(),
                                    OngoingNegotiations = new()
                                    {
                                        Explanation = "explanation",
                                        IssuerFirstNotifiedAt = "2019-12-27",
                                        StartedAt = "2019-12-27",
                                    },
                                    PurchaseInfoAndQualityIssue = "purchase_info_and_quality_issue",
                                    ReceivedAt = "2019-12-27",
                                    ReturnAttempted = new()
                                    {
                                        AttemptExplanation = "attempt_explanation",
                                        AttemptReason =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                        AttemptedAt = "2019-12-27",
                                        MerchandiseDisposition = "merchandise_disposition",
                                    },
                                    ReturnOutcome =
                                        CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                                    Returned = new()
                                    {
                                        MerchantReceivedReturnAt = "2019-12-27",
                                        OtherExplanation = "other_explanation",
                                        ReturnMethod =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                                        ReturnedAt = "2019-12-27",
                                        TrackingNumber = "tracking_number",
                                    },
                                },
                                ConsumerQualityServices = new()
                                {
                                    CardholderCancellation = new()
                                    {
                                        AcceptedByMerchant =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                                        CanceledAt = "2019-12-27",
                                        Reason = "reason",
                                    },
                                    CardholderPaidToHaveWorkRedone =
                                        CardDisputes::UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                                    NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                                        CardDisputes::UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                                    OngoingNegotiations = new()
                                    {
                                        Explanation = "explanation",
                                        IssuerFirstNotifiedAt = "2019-12-27",
                                        StartedAt = "2019-12-27",
                                    },
                                    PurchaseInfoAndQualityIssue = "purchase_info_and_quality_issue",
                                    RestaurantFoodRelated =
                                        CardDisputes::UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
                                    ServicesReceivedAt = "2019-12-27",
                                },
                                ConsumerServicesMisrepresentation = new()
                                {
                                    CardholderCancellation = new()
                                    {
                                        AcceptedByMerchant =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                                        CanceledAt = "2019-12-27",
                                        Reason = "reason",
                                    },
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                                    MisrepresentationExplanation = "misrepresentation_explanation",
                                    PurchaseExplanation = "purchase_explanation",
                                    ReceivedAt = "2019-12-27",
                                },
                                ConsumerServicesNotAsDescribed = new()
                                {
                                    CardholderCancellation = new()
                                    {
                                        AcceptedByMerchant =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                                        CanceledAt = "2019-12-27",
                                        Reason = "reason",
                                    },
                                    Explanation = "explanation",
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                                    ReceivedAt = "2019-12-27",
                                },
                                ConsumerServicesNotReceived = new()
                                {
                                    CancellationOutcome =
                                        CardDisputes::UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                                    CardholderCancellationPriorToExpectedReceipt = new()
                                    {
                                        CanceledAt = "2019-12-27",
                                        Reason = "reason",
                                    },
                                    LastExpectedReceiptAt = "2019-12-27",
                                    MerchantCancellation = new("2019-12-27"),
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                                    NoCancellation = new(),
                                    PurchaseInfoAndExplanation = "purchase_info_and_explanation",
                                },
                                Fraud = new(
                                    CardDisputes::UserSubmissionChargebackFraudFraudType.Lost
                                ),
                                ProcessingError = new()
                                {
                                    DuplicateTransaction = new("other_transaction_id"),
                                    ErrorReason =
                                        CardDisputes::UserSubmissionChargebackProcessingErrorErrorReason.DuplicateTransaction,
                                    IncorrectAmount = new(0),
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                                    PaidByOtherMeans = new()
                                    {
                                        OtherFormOfPaymentEvidence =
                                            CardDisputes::UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                                        OtherTransactionID = "other_transaction_id",
                                    },
                                },
                            },
                            MerchantPrearbitrationDecline = new(
                                "I do not believe the explanation given by the merchant is valid."
                            ),
                            UserPrearbitration = new()
                            {
                                CategoryChange = new()
                                {
                                    Category =
                                        CardDisputes::UserSubmissionUserPrearbitrationCategoryChangeCategory.Fraud,
                                    Reason = "Based on the response from the merchant.",
                                },
                                Reason = "I disagree with the explanation given by the merchant.",
                            },
                        },
                    ],
                },
                Win = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
                Withdrawal = new("The cardholder requested a withdrawal of the dispute."),
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardDisputes::CardDisputeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "card_dispute_h9sc95nbl1cgltpp7men",
                    Amount = 1000,
                    CardID = "card_oubs0hwk5rn6knuecxg2",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DisputedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    IdempotencyKey = null,
                    Loss = new()
                    {
                        LostAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Reason = CardDisputes::LossReason.UserWithdrawn,
                    },
                    Network = CardDisputes::CardDisputeNetwork.Visa,
                    Status = CardDisputes::CardDisputeStatus.PendingResponse,
                    Type = CardDisputes::Type.CardDispute,
                    UserSubmissionRequiredBy = null,
                    Visa = new()
                    {
                        NetworkEvents =
                        [
                            new()
                            {
                                AttachmentFiles = [new("file_id")],
                                Category = CardDisputes::NetworkEventCategory.ChargebackAccepted,
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                DisputeFinancialTransactionID = "dispute_financial_transaction_id",
                                ChargebackAccepted = new(),
                                ChargebackSubmitted = new(),
                                ChargebackTimedOut = new(),
                                MerchantPrearbitrationDeclineSubmitted = new(),
                                MerchantPrearbitrationReceived = new()
                                {
                                    CardholderNoLongerDisputes = new(
                                        "See the attached email where the cardholder confirmed that they no longer dispute the transaction."
                                    ),
                                    CompellingEvidence = new()
                                    {
                                        Category =
                                            CardDisputes::CompellingEvidenceCategory.MerchandiseUse,
                                        Explanation = null,
                                    },
                                    CreditOrReversalProcessed = new()
                                    {
                                        Amount = 4900,
                                        Currency = "USD",
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        ProcessedAt = "2020-01-31",
                                    },
                                    DelayedChargeTransaction = new((string?)null),
                                    EvidenceOfImprint = new((string?)null),
                                    InvalidDispute = new()
                                    {
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        Reason = CardDisputes::InvalidDisputeReason.Other,
                                    },
                                    NonFiatCurrencyOrNonFungibleTokenReceived = new()
                                    {
                                        BlockchainTransactionHash =
                                            "0x1234567890123456789012345678901234567890",
                                        DestinationWalletAddress =
                                            "0x1234567890123456789012345678901234567890",
                                        PriorApprovedTransactions =
                                            "0x1234567890123456789012345678901234567890",
                                    },
                                    PriorUndisputedNonFraudTransactions = new((string?)null),
                                    Reason =
                                        CardDisputes::MerchantPrearbitrationReceivedReason.CardholderNoLongerDisputes,
                                },
                                MerchantPrearbitrationTimedOut = new(),
                                Represented = new()
                                {
                                    CardholderNoLongerDisputes = new(
                                        "See the attached email where the cardholder confirmed that they no longer dispute the transaction."
                                    ),
                                    CreditOrReversalProcessed = new()
                                    {
                                        Amount = 4900,
                                        Currency = "USD",
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        ProcessedAt = "2020-01-31",
                                    },
                                    InvalidDispute = new()
                                    {
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        Reason =
                                            CardDisputes::RepresentedInvalidDisputeReason.Other,
                                    },
                                    NonFiatCurrencyOrNonFungibleTokenAsDescribed = new(),
                                    NonFiatCurrencyOrNonFungibleTokenReceived = new()
                                    {
                                        BlockchainTransactionHash =
                                            "0x1234567890123456789012345678901234567890",
                                        DestinationWalletAddress =
                                            "0x1234567890123456789012345678901234567890",
                                        PriorApprovedTransactions =
                                            "0x1234567890123456789012345678901234567890",
                                    },
                                    ProofOfCashDisbursement = new((string?)null),
                                    Reason = CardDisputes::RepresentedReason.InvalidDispute,
                                    ReversalIssued = new(
                                        "The merchant has issued a reversal for the transaction prior to the dispute being filed."
                                    ),
                                },
                                RepresentmentTimedOut = new(),
                                UserPrearbitrationAccepted = new(),
                                UserPrearbitrationDeclined = new(),
                                UserPrearbitrationSubmitted = new(),
                                UserPrearbitrationTimedOut = new(),
                                UserWithdrawalSubmitted = new(),
                            },
                        ],
                        RequiredUserSubmissionCategory = null,
                        UserSubmissions =
                        [
                            new()
                            {
                                AcceptedAt = null,
                                Amount = 1000,
                                AttachmentFiles = [new("file_id")],
                                Category = CardDisputes::UserSubmissionCategory.Chargeback,
                                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                Explanation = null,
                                FurtherInformationRequestedAt = null,
                                FurtherInformationRequestedReason = null,
                                Status = CardDisputes::UserSubmissionStatus.PendingReviewing,
                                UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                Chargeback = new()
                                {
                                    Authorization = new(
                                        CardDisputes::UserSubmissionChargebackAuthorizationAccountStatus.AccountClosed
                                    ),
                                    Category = CardDisputes::UserSubmissionChargebackCategory.Fraud,
                                    ConsumerCanceledMerchandise = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            CanceledPriorToShipDate =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                                            CancellationPolicyProvided =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                                            Reason = "reason",
                                        },
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                                        NotReturned = new(),
                                        PurchaseExplanation = "purchase_explanation",
                                        ReceivedOrExpectedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerCanceledRecurringTransaction = new()
                                    {
                                        CancellationTarget =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                                        MerchantContactMethods = new()
                                        {
                                            ApplicationName = "application_name",
                                            CallCenterPhoneNumber = "call_center_phone_number",
                                            EmailAddress = "email_address",
                                            InPersonAddress = "in_person_address",
                                            MailingAddress = "mailing_address",
                                            TextPhoneNumber = "text_phone_number",
                                        },
                                        OtherFormOfPaymentExplanation =
                                            "other_form_of_payment_explanation",
                                        TransactionOrAccountCanceledAt = "2019-12-27",
                                    },
                                    ConsumerCanceledServices = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            CancellationPolicyProvided =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                                            Reason = "reason",
                                        },
                                        ContractedAt = "2019-12-27",
                                        GuaranteedReservation = new(
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                                        ),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                                        Other = new(),
                                        PurchaseExplanation = "purchase_explanation",
                                        ServiceType =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                                        Timeshare = new(),
                                    },
                                    ConsumerCounterfeitMerchandise = new()
                                    {
                                        CounterfeitExplanation = "counterfeit_explanation",
                                        DispositionExplanation = "disposition_explanation",
                                        OrderExplanation = "order_explanation",
                                        ReceivedAt = "2019-12-27",
                                    },
                                    ConsumerCreditNotProcessed = new()
                                    {
                                        CanceledOrReturnedAt = "2019-12-27",
                                        CreditExpectedAt = "2019-12-27",
                                    },
                                    ConsumerDamagedOrDefectiveMerchandise = new()
                                    {
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                                        NotReturned = new(),
                                        OrderAndIssueExplanation = "order_and_issue_explanation",
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerMerchandiseMisrepresentation = new()
                                    {
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                                        MisrepresentationExplanation =
                                            "misrepresentation_explanation",
                                        NotReturned = new(),
                                        PurchaseExplanation = "purchase_explanation",
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerMerchandiseNotAsDescribed = new()
                                    {
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerMerchandiseNotReceived = new()
                                    {
                                        CancellationOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                                        CardholderCancellationPriorToExpectedReceipt = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        Delayed = new()
                                        {
                                            Explanation = "explanation",
                                            NotReturned = new(),
                                            ReturnAttempted = new("2019-12-27"),
                                            ReturnOutcome =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                                            Returned = new()
                                            {
                                                MerchantReceivedReturnAt = "2019-12-27",
                                                ReturnedAt = "2019-12-27",
                                            },
                                        },
                                        DeliveredToWrongLocation = new("agreed_location"),
                                        DeliveryIssue =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                                        LastExpectedReceiptAt = "2019-12-27",
                                        MerchantCancellation = new("2019-12-27"),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                                        NoCancellation = new(),
                                        PurchaseInfoAndExplanation =
                                            "purchase_info_and_explanation",
                                    },
                                    ConsumerNonReceiptOfCash = new(),
                                    ConsumerOriginalCreditTransactionNotAccepted = new()
                                    {
                                        Explanation = "explanation",
                                        Reason =
                                            CardDisputes::UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
                                    },
                                    ConsumerQualityMerchandise = new()
                                    {
                                        ExpectedAt = "2019-12-27",
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                                        NotReturned = new(),
                                        OngoingNegotiations = new()
                                        {
                                            Explanation = "explanation",
                                            IssuerFirstNotifiedAt = "2019-12-27",
                                            StartedAt = "2019-12-27",
                                        },
                                        PurchaseInfoAndQualityIssue =
                                            "purchase_info_and_quality_issue",
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerQualityServices = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            AcceptedByMerchant =
                                                CardDisputes::UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        CardholderPaidToHaveWorkRedone =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                                        NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                                        OngoingNegotiations = new()
                                        {
                                            Explanation = "explanation",
                                            IssuerFirstNotifiedAt = "2019-12-27",
                                            StartedAt = "2019-12-27",
                                        },
                                        PurchaseInfoAndQualityIssue =
                                            "purchase_info_and_quality_issue",
                                        RestaurantFoodRelated =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
                                        ServicesReceivedAt = "2019-12-27",
                                    },
                                    ConsumerServicesMisrepresentation = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            AcceptedByMerchant =
                                                CardDisputes::UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                                        MisrepresentationExplanation =
                                            "misrepresentation_explanation",
                                        PurchaseExplanation = "purchase_explanation",
                                        ReceivedAt = "2019-12-27",
                                    },
                                    ConsumerServicesNotAsDescribed = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            AcceptedByMerchant =
                                                CardDisputes::UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        Explanation = "explanation",
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                                        ReceivedAt = "2019-12-27",
                                    },
                                    ConsumerServicesNotReceived = new()
                                    {
                                        CancellationOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                                        CardholderCancellationPriorToExpectedReceipt = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        LastExpectedReceiptAt = "2019-12-27",
                                        MerchantCancellation = new("2019-12-27"),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                                        NoCancellation = new(),
                                        PurchaseInfoAndExplanation =
                                            "purchase_info_and_explanation",
                                    },
                                    Fraud = new(
                                        CardDisputes::UserSubmissionChargebackFraudFraudType.Lost
                                    ),
                                    ProcessingError = new()
                                    {
                                        DuplicateTransaction = new("other_transaction_id"),
                                        ErrorReason =
                                            CardDisputes::UserSubmissionChargebackProcessingErrorErrorReason.DuplicateTransaction,
                                        IncorrectAmount = new(0),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                                        PaidByOtherMeans = new()
                                        {
                                            OtherFormOfPaymentEvidence =
                                                CardDisputes::UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                                            OtherTransactionID = "other_transaction_id",
                                        },
                                    },
                                },
                                MerchantPrearbitrationDecline = new(
                                    "I do not believe the explanation given by the merchant is valid."
                                ),
                                UserPrearbitration = new()
                                {
                                    CategoryChange = new()
                                    {
                                        Category =
                                            CardDisputes::UserSubmissionUserPrearbitrationCategoryChangeCategory.Fraud,
                                        Reason = "Based on the response from the merchant.",
                                    },
                                    Reason =
                                        "I disagree with the explanation given by the merchant.",
                                },
                            },
                        ],
                    },
                    Win = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
                    Withdrawal = new("The cardholder requested a withdrawal of the dispute."),
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::CardDisputeListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardDisputes::CardDisputeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "card_dispute_h9sc95nbl1cgltpp7men",
                    Amount = 1000,
                    CardID = "card_oubs0hwk5rn6knuecxg2",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DisputedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    IdempotencyKey = null,
                    Loss = new()
                    {
                        LostAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Reason = CardDisputes::LossReason.UserWithdrawn,
                    },
                    Network = CardDisputes::CardDisputeNetwork.Visa,
                    Status = CardDisputes::CardDisputeStatus.PendingResponse,
                    Type = CardDisputes::Type.CardDispute,
                    UserSubmissionRequiredBy = null,
                    Visa = new()
                    {
                        NetworkEvents =
                        [
                            new()
                            {
                                AttachmentFiles = [new("file_id")],
                                Category = CardDisputes::NetworkEventCategory.ChargebackAccepted,
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                DisputeFinancialTransactionID = "dispute_financial_transaction_id",
                                ChargebackAccepted = new(),
                                ChargebackSubmitted = new(),
                                ChargebackTimedOut = new(),
                                MerchantPrearbitrationDeclineSubmitted = new(),
                                MerchantPrearbitrationReceived = new()
                                {
                                    CardholderNoLongerDisputes = new(
                                        "See the attached email where the cardholder confirmed that they no longer dispute the transaction."
                                    ),
                                    CompellingEvidence = new()
                                    {
                                        Category =
                                            CardDisputes::CompellingEvidenceCategory.MerchandiseUse,
                                        Explanation = null,
                                    },
                                    CreditOrReversalProcessed = new()
                                    {
                                        Amount = 4900,
                                        Currency = "USD",
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        ProcessedAt = "2020-01-31",
                                    },
                                    DelayedChargeTransaction = new((string?)null),
                                    EvidenceOfImprint = new((string?)null),
                                    InvalidDispute = new()
                                    {
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        Reason = CardDisputes::InvalidDisputeReason.Other,
                                    },
                                    NonFiatCurrencyOrNonFungibleTokenReceived = new()
                                    {
                                        BlockchainTransactionHash =
                                            "0x1234567890123456789012345678901234567890",
                                        DestinationWalletAddress =
                                            "0x1234567890123456789012345678901234567890",
                                        PriorApprovedTransactions =
                                            "0x1234567890123456789012345678901234567890",
                                    },
                                    PriorUndisputedNonFraudTransactions = new((string?)null),
                                    Reason =
                                        CardDisputes::MerchantPrearbitrationReceivedReason.CardholderNoLongerDisputes,
                                },
                                MerchantPrearbitrationTimedOut = new(),
                                Represented = new()
                                {
                                    CardholderNoLongerDisputes = new(
                                        "See the attached email where the cardholder confirmed that they no longer dispute the transaction."
                                    ),
                                    CreditOrReversalProcessed = new()
                                    {
                                        Amount = 4900,
                                        Currency = "USD",
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        ProcessedAt = "2020-01-31",
                                    },
                                    InvalidDispute = new()
                                    {
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        Reason =
                                            CardDisputes::RepresentedInvalidDisputeReason.Other,
                                    },
                                    NonFiatCurrencyOrNonFungibleTokenAsDescribed = new(),
                                    NonFiatCurrencyOrNonFungibleTokenReceived = new()
                                    {
                                        BlockchainTransactionHash =
                                            "0x1234567890123456789012345678901234567890",
                                        DestinationWalletAddress =
                                            "0x1234567890123456789012345678901234567890",
                                        PriorApprovedTransactions =
                                            "0x1234567890123456789012345678901234567890",
                                    },
                                    ProofOfCashDisbursement = new((string?)null),
                                    Reason = CardDisputes::RepresentedReason.InvalidDispute,
                                    ReversalIssued = new(
                                        "The merchant has issued a reversal for the transaction prior to the dispute being filed."
                                    ),
                                },
                                RepresentmentTimedOut = new(),
                                UserPrearbitrationAccepted = new(),
                                UserPrearbitrationDeclined = new(),
                                UserPrearbitrationSubmitted = new(),
                                UserPrearbitrationTimedOut = new(),
                                UserWithdrawalSubmitted = new(),
                            },
                        ],
                        RequiredUserSubmissionCategory = null,
                        UserSubmissions =
                        [
                            new()
                            {
                                AcceptedAt = null,
                                Amount = 1000,
                                AttachmentFiles = [new("file_id")],
                                Category = CardDisputes::UserSubmissionCategory.Chargeback,
                                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                Explanation = null,
                                FurtherInformationRequestedAt = null,
                                FurtherInformationRequestedReason = null,
                                Status = CardDisputes::UserSubmissionStatus.PendingReviewing,
                                UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                Chargeback = new()
                                {
                                    Authorization = new(
                                        CardDisputes::UserSubmissionChargebackAuthorizationAccountStatus.AccountClosed
                                    ),
                                    Category = CardDisputes::UserSubmissionChargebackCategory.Fraud,
                                    ConsumerCanceledMerchandise = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            CanceledPriorToShipDate =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                                            CancellationPolicyProvided =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                                            Reason = "reason",
                                        },
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                                        NotReturned = new(),
                                        PurchaseExplanation = "purchase_explanation",
                                        ReceivedOrExpectedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerCanceledRecurringTransaction = new()
                                    {
                                        CancellationTarget =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                                        MerchantContactMethods = new()
                                        {
                                            ApplicationName = "application_name",
                                            CallCenterPhoneNumber = "call_center_phone_number",
                                            EmailAddress = "email_address",
                                            InPersonAddress = "in_person_address",
                                            MailingAddress = "mailing_address",
                                            TextPhoneNumber = "text_phone_number",
                                        },
                                        OtherFormOfPaymentExplanation =
                                            "other_form_of_payment_explanation",
                                        TransactionOrAccountCanceledAt = "2019-12-27",
                                    },
                                    ConsumerCanceledServices = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            CancellationPolicyProvided =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                                            Reason = "reason",
                                        },
                                        ContractedAt = "2019-12-27",
                                        GuaranteedReservation = new(
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                                        ),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                                        Other = new(),
                                        PurchaseExplanation = "purchase_explanation",
                                        ServiceType =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                                        Timeshare = new(),
                                    },
                                    ConsumerCounterfeitMerchandise = new()
                                    {
                                        CounterfeitExplanation = "counterfeit_explanation",
                                        DispositionExplanation = "disposition_explanation",
                                        OrderExplanation = "order_explanation",
                                        ReceivedAt = "2019-12-27",
                                    },
                                    ConsumerCreditNotProcessed = new()
                                    {
                                        CanceledOrReturnedAt = "2019-12-27",
                                        CreditExpectedAt = "2019-12-27",
                                    },
                                    ConsumerDamagedOrDefectiveMerchandise = new()
                                    {
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                                        NotReturned = new(),
                                        OrderAndIssueExplanation = "order_and_issue_explanation",
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerMerchandiseMisrepresentation = new()
                                    {
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                                        MisrepresentationExplanation =
                                            "misrepresentation_explanation",
                                        NotReturned = new(),
                                        PurchaseExplanation = "purchase_explanation",
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerMerchandiseNotAsDescribed = new()
                                    {
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerMerchandiseNotReceived = new()
                                    {
                                        CancellationOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                                        CardholderCancellationPriorToExpectedReceipt = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        Delayed = new()
                                        {
                                            Explanation = "explanation",
                                            NotReturned = new(),
                                            ReturnAttempted = new("2019-12-27"),
                                            ReturnOutcome =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                                            Returned = new()
                                            {
                                                MerchantReceivedReturnAt = "2019-12-27",
                                                ReturnedAt = "2019-12-27",
                                            },
                                        },
                                        DeliveredToWrongLocation = new("agreed_location"),
                                        DeliveryIssue =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                                        LastExpectedReceiptAt = "2019-12-27",
                                        MerchantCancellation = new("2019-12-27"),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                                        NoCancellation = new(),
                                        PurchaseInfoAndExplanation =
                                            "purchase_info_and_explanation",
                                    },
                                    ConsumerNonReceiptOfCash = new(),
                                    ConsumerOriginalCreditTransactionNotAccepted = new()
                                    {
                                        Explanation = "explanation",
                                        Reason =
                                            CardDisputes::UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
                                    },
                                    ConsumerQualityMerchandise = new()
                                    {
                                        ExpectedAt = "2019-12-27",
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                                        NotReturned = new(),
                                        OngoingNegotiations = new()
                                        {
                                            Explanation = "explanation",
                                            IssuerFirstNotifiedAt = "2019-12-27",
                                            StartedAt = "2019-12-27",
                                        },
                                        PurchaseInfoAndQualityIssue =
                                            "purchase_info_and_quality_issue",
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerQualityServices = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            AcceptedByMerchant =
                                                CardDisputes::UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        CardholderPaidToHaveWorkRedone =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                                        NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                                        OngoingNegotiations = new()
                                        {
                                            Explanation = "explanation",
                                            IssuerFirstNotifiedAt = "2019-12-27",
                                            StartedAt = "2019-12-27",
                                        },
                                        PurchaseInfoAndQualityIssue =
                                            "purchase_info_and_quality_issue",
                                        RestaurantFoodRelated =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
                                        ServicesReceivedAt = "2019-12-27",
                                    },
                                    ConsumerServicesMisrepresentation = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            AcceptedByMerchant =
                                                CardDisputes::UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                                        MisrepresentationExplanation =
                                            "misrepresentation_explanation",
                                        PurchaseExplanation = "purchase_explanation",
                                        ReceivedAt = "2019-12-27",
                                    },
                                    ConsumerServicesNotAsDescribed = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            AcceptedByMerchant =
                                                CardDisputes::UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        Explanation = "explanation",
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                                        ReceivedAt = "2019-12-27",
                                    },
                                    ConsumerServicesNotReceived = new()
                                    {
                                        CancellationOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                                        CardholderCancellationPriorToExpectedReceipt = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        LastExpectedReceiptAt = "2019-12-27",
                                        MerchantCancellation = new("2019-12-27"),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                                        NoCancellation = new(),
                                        PurchaseInfoAndExplanation =
                                            "purchase_info_and_explanation",
                                    },
                                    Fraud = new(
                                        CardDisputes::UserSubmissionChargebackFraudFraudType.Lost
                                    ),
                                    ProcessingError = new()
                                    {
                                        DuplicateTransaction = new("other_transaction_id"),
                                        ErrorReason =
                                            CardDisputes::UserSubmissionChargebackProcessingErrorErrorReason.DuplicateTransaction,
                                        IncorrectAmount = new(0),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                                        PaidByOtherMeans = new()
                                        {
                                            OtherFormOfPaymentEvidence =
                                                CardDisputes::UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                                            OtherTransactionID = "other_transaction_id",
                                        },
                                    },
                                },
                                MerchantPrearbitrationDecline = new(
                                    "I do not believe the explanation given by the merchant is valid."
                                ),
                                UserPrearbitration = new()
                                {
                                    CategoryChange = new()
                                    {
                                        Category =
                                            CardDisputes::UserSubmissionUserPrearbitrationCategoryChangeCategory.Fraud,
                                        Reason = "Based on the response from the merchant.",
                                    },
                                    Reason =
                                        "I disagree with the explanation given by the merchant.",
                                },
                            },
                        ],
                    },
                    Win = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
                    Withdrawal = new("The cardholder requested a withdrawal of the dispute."),
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::CardDisputeListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CardDisputes::CardDispute> expectedData =
        [
            new()
            {
                ID = "card_dispute_h9sc95nbl1cgltpp7men",
                Amount = 1000,
                CardID = "card_oubs0hwk5rn6knuecxg2",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                DisputedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                IdempotencyKey = null,
                Loss = new()
                {
                    LostAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Reason = CardDisputes::LossReason.UserWithdrawn,
                },
                Network = CardDisputes::CardDisputeNetwork.Visa,
                Status = CardDisputes::CardDisputeStatus.PendingResponse,
                Type = CardDisputes::Type.CardDispute,
                UserSubmissionRequiredBy = null,
                Visa = new()
                {
                    NetworkEvents =
                    [
                        new()
                        {
                            AttachmentFiles = [new("file_id")],
                            Category = CardDisputes::NetworkEventCategory.ChargebackAccepted,
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            DisputeFinancialTransactionID = "dispute_financial_transaction_id",
                            ChargebackAccepted = new(),
                            ChargebackSubmitted = new(),
                            ChargebackTimedOut = new(),
                            MerchantPrearbitrationDeclineSubmitted = new(),
                            MerchantPrearbitrationReceived = new()
                            {
                                CardholderNoLongerDisputes = new(
                                    "See the attached email where the cardholder confirmed that they no longer dispute the transaction."
                                ),
                                CompellingEvidence = new()
                                {
                                    Category =
                                        CardDisputes::CompellingEvidenceCategory.MerchandiseUse,
                                    Explanation = null,
                                },
                                CreditOrReversalProcessed = new()
                                {
                                    Amount = 4900,
                                    Currency = "USD",
                                    Explanation =
                                        "The user did not provide the required documentation.",
                                    ProcessedAt = "2020-01-31",
                                },
                                DelayedChargeTransaction = new((string?)null),
                                EvidenceOfImprint = new((string?)null),
                                InvalidDispute = new()
                                {
                                    Explanation =
                                        "The user did not provide the required documentation.",
                                    Reason = CardDisputes::InvalidDisputeReason.Other,
                                },
                                NonFiatCurrencyOrNonFungibleTokenReceived = new()
                                {
                                    BlockchainTransactionHash =
                                        "0x1234567890123456789012345678901234567890",
                                    DestinationWalletAddress =
                                        "0x1234567890123456789012345678901234567890",
                                    PriorApprovedTransactions =
                                        "0x1234567890123456789012345678901234567890",
                                },
                                PriorUndisputedNonFraudTransactions = new((string?)null),
                                Reason =
                                    CardDisputes::MerchantPrearbitrationReceivedReason.CardholderNoLongerDisputes,
                            },
                            MerchantPrearbitrationTimedOut = new(),
                            Represented = new()
                            {
                                CardholderNoLongerDisputes = new(
                                    "See the attached email where the cardholder confirmed that they no longer dispute the transaction."
                                ),
                                CreditOrReversalProcessed = new()
                                {
                                    Amount = 4900,
                                    Currency = "USD",
                                    Explanation =
                                        "The user did not provide the required documentation.",
                                    ProcessedAt = "2020-01-31",
                                },
                                InvalidDispute = new()
                                {
                                    Explanation =
                                        "The user did not provide the required documentation.",
                                    Reason = CardDisputes::RepresentedInvalidDisputeReason.Other,
                                },
                                NonFiatCurrencyOrNonFungibleTokenAsDescribed = new(),
                                NonFiatCurrencyOrNonFungibleTokenReceived = new()
                                {
                                    BlockchainTransactionHash =
                                        "0x1234567890123456789012345678901234567890",
                                    DestinationWalletAddress =
                                        "0x1234567890123456789012345678901234567890",
                                    PriorApprovedTransactions =
                                        "0x1234567890123456789012345678901234567890",
                                },
                                ProofOfCashDisbursement = new((string?)null),
                                Reason = CardDisputes::RepresentedReason.InvalidDispute,
                                ReversalIssued = new(
                                    "The merchant has issued a reversal for the transaction prior to the dispute being filed."
                                ),
                            },
                            RepresentmentTimedOut = new(),
                            UserPrearbitrationAccepted = new(),
                            UserPrearbitrationDeclined = new(),
                            UserPrearbitrationSubmitted = new(),
                            UserPrearbitrationTimedOut = new(),
                            UserWithdrawalSubmitted = new(),
                        },
                    ],
                    RequiredUserSubmissionCategory = null,
                    UserSubmissions =
                    [
                        new()
                        {
                            AcceptedAt = null,
                            Amount = 1000,
                            AttachmentFiles = [new("file_id")],
                            Category = CardDisputes::UserSubmissionCategory.Chargeback,
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Explanation = null,
                            FurtherInformationRequestedAt = null,
                            FurtherInformationRequestedReason = null,
                            Status = CardDisputes::UserSubmissionStatus.PendingReviewing,
                            UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Chargeback = new()
                            {
                                Authorization = new(
                                    CardDisputes::UserSubmissionChargebackAuthorizationAccountStatus.AccountClosed
                                ),
                                Category = CardDisputes::UserSubmissionChargebackCategory.Fraud,
                                ConsumerCanceledMerchandise = new()
                                {
                                    CardholderCancellation = new()
                                    {
                                        CanceledAt = "2019-12-27",
                                        CanceledPriorToShipDate =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                                        CancellationPolicyProvided =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                                        Reason = "reason",
                                    },
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                                    NotReturned = new(),
                                    PurchaseExplanation = "purchase_explanation",
                                    ReceivedOrExpectedAt = "2019-12-27",
                                    ReturnAttempted = new()
                                    {
                                        AttemptExplanation = "attempt_explanation",
                                        AttemptReason =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                        AttemptedAt = "2019-12-27",
                                        MerchandiseDisposition = "merchandise_disposition",
                                    },
                                    ReturnOutcome =
                                        CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                                    Returned = new()
                                    {
                                        MerchantReceivedReturnAt = "2019-12-27",
                                        OtherExplanation = "other_explanation",
                                        ReturnMethod =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                                        ReturnedAt = "2019-12-27",
                                        TrackingNumber = "tracking_number",
                                    },
                                },
                                ConsumerCanceledRecurringTransaction = new()
                                {
                                    CancellationTarget =
                                        CardDisputes::UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                                    MerchantContactMethods = new()
                                    {
                                        ApplicationName = "application_name",
                                        CallCenterPhoneNumber = "call_center_phone_number",
                                        EmailAddress = "email_address",
                                        InPersonAddress = "in_person_address",
                                        MailingAddress = "mailing_address",
                                        TextPhoneNumber = "text_phone_number",
                                    },
                                    OtherFormOfPaymentExplanation =
                                        "other_form_of_payment_explanation",
                                    TransactionOrAccountCanceledAt = "2019-12-27",
                                },
                                ConsumerCanceledServices = new()
                                {
                                    CardholderCancellation = new()
                                    {
                                        CanceledAt = "2019-12-27",
                                        CancellationPolicyProvided =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                                        Reason = "reason",
                                    },
                                    ContractedAt = "2019-12-27",
                                    GuaranteedReservation = new(
                                        CardDisputes::UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                                    ),
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                                    Other = new(),
                                    PurchaseExplanation = "purchase_explanation",
                                    ServiceType =
                                        CardDisputes::UserSubmissionChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                                    Timeshare = new(),
                                },
                                ConsumerCounterfeitMerchandise = new()
                                {
                                    CounterfeitExplanation = "counterfeit_explanation",
                                    DispositionExplanation = "disposition_explanation",
                                    OrderExplanation = "order_explanation",
                                    ReceivedAt = "2019-12-27",
                                },
                                ConsumerCreditNotProcessed = new()
                                {
                                    CanceledOrReturnedAt = "2019-12-27",
                                    CreditExpectedAt = "2019-12-27",
                                },
                                ConsumerDamagedOrDefectiveMerchandise = new()
                                {
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                                    NotReturned = new(),
                                    OrderAndIssueExplanation = "order_and_issue_explanation",
                                    ReceivedAt = "2019-12-27",
                                    ReturnAttempted = new()
                                    {
                                        AttemptExplanation = "attempt_explanation",
                                        AttemptReason =
                                            CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                        AttemptedAt = "2019-12-27",
                                        MerchandiseDisposition = "merchandise_disposition",
                                    },
                                    ReturnOutcome =
                                        CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                                    Returned = new()
                                    {
                                        MerchantReceivedReturnAt = "2019-12-27",
                                        OtherExplanation = "other_explanation",
                                        ReturnMethod =
                                            CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                                        ReturnedAt = "2019-12-27",
                                        TrackingNumber = "tracking_number",
                                    },
                                },
                                ConsumerMerchandiseMisrepresentation = new()
                                {
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                                    MisrepresentationExplanation = "misrepresentation_explanation",
                                    NotReturned = new(),
                                    PurchaseExplanation = "purchase_explanation",
                                    ReceivedAt = "2019-12-27",
                                    ReturnAttempted = new()
                                    {
                                        AttemptExplanation = "attempt_explanation",
                                        AttemptReason =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                                        AttemptedAt = "2019-12-27",
                                        MerchandiseDisposition = "merchandise_disposition",
                                    },
                                    ReturnOutcome =
                                        CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                                    Returned = new()
                                    {
                                        MerchantReceivedReturnAt = "2019-12-27",
                                        OtherExplanation = "other_explanation",
                                        ReturnMethod =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                                        ReturnedAt = "2019-12-27",
                                        TrackingNumber = "tracking_number",
                                    },
                                },
                                ConsumerMerchandiseNotAsDescribed = new()
                                {
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                                    ReceivedAt = "2019-12-27",
                                    ReturnAttempted = new()
                                    {
                                        AttemptExplanation = "attempt_explanation",
                                        AttemptReason =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                                        AttemptedAt = "2019-12-27",
                                        MerchandiseDisposition = "merchandise_disposition",
                                    },
                                    ReturnOutcome =
                                        CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                                    Returned = new()
                                    {
                                        MerchantReceivedReturnAt = "2019-12-27",
                                        OtherExplanation = "other_explanation",
                                        ReturnMethod =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                                        ReturnedAt = "2019-12-27",
                                        TrackingNumber = "tracking_number",
                                    },
                                },
                                ConsumerMerchandiseNotReceived = new()
                                {
                                    CancellationOutcome =
                                        CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                                    CardholderCancellationPriorToExpectedReceipt = new()
                                    {
                                        CanceledAt = "2019-12-27",
                                        Reason = "reason",
                                    },
                                    Delayed = new()
                                    {
                                        Explanation = "explanation",
                                        NotReturned = new(),
                                        ReturnAttempted = new("2019-12-27"),
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            ReturnedAt = "2019-12-27",
                                        },
                                    },
                                    DeliveredToWrongLocation = new("agreed_location"),
                                    DeliveryIssue =
                                        CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                                    LastExpectedReceiptAt = "2019-12-27",
                                    MerchantCancellation = new("2019-12-27"),
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                                    NoCancellation = new(),
                                    PurchaseInfoAndExplanation = "purchase_info_and_explanation",
                                },
                                ConsumerNonReceiptOfCash = new(),
                                ConsumerOriginalCreditTransactionNotAccepted = new()
                                {
                                    Explanation = "explanation",
                                    Reason =
                                        CardDisputes::UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
                                },
                                ConsumerQualityMerchandise = new()
                                {
                                    ExpectedAt = "2019-12-27",
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                                    NotReturned = new(),
                                    OngoingNegotiations = new()
                                    {
                                        Explanation = "explanation",
                                        IssuerFirstNotifiedAt = "2019-12-27",
                                        StartedAt = "2019-12-27",
                                    },
                                    PurchaseInfoAndQualityIssue = "purchase_info_and_quality_issue",
                                    ReceivedAt = "2019-12-27",
                                    ReturnAttempted = new()
                                    {
                                        AttemptExplanation = "attempt_explanation",
                                        AttemptReason =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                        AttemptedAt = "2019-12-27",
                                        MerchandiseDisposition = "merchandise_disposition",
                                    },
                                    ReturnOutcome =
                                        CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                                    Returned = new()
                                    {
                                        MerchantReceivedReturnAt = "2019-12-27",
                                        OtherExplanation = "other_explanation",
                                        ReturnMethod =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                                        ReturnedAt = "2019-12-27",
                                        TrackingNumber = "tracking_number",
                                    },
                                },
                                ConsumerQualityServices = new()
                                {
                                    CardholderCancellation = new()
                                    {
                                        AcceptedByMerchant =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                                        CanceledAt = "2019-12-27",
                                        Reason = "reason",
                                    },
                                    CardholderPaidToHaveWorkRedone =
                                        CardDisputes::UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                                    NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                                        CardDisputes::UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                                    OngoingNegotiations = new()
                                    {
                                        Explanation = "explanation",
                                        IssuerFirstNotifiedAt = "2019-12-27",
                                        StartedAt = "2019-12-27",
                                    },
                                    PurchaseInfoAndQualityIssue = "purchase_info_and_quality_issue",
                                    RestaurantFoodRelated =
                                        CardDisputes::UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
                                    ServicesReceivedAt = "2019-12-27",
                                },
                                ConsumerServicesMisrepresentation = new()
                                {
                                    CardholderCancellation = new()
                                    {
                                        AcceptedByMerchant =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                                        CanceledAt = "2019-12-27",
                                        Reason = "reason",
                                    },
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                                    MisrepresentationExplanation = "misrepresentation_explanation",
                                    PurchaseExplanation = "purchase_explanation",
                                    ReceivedAt = "2019-12-27",
                                },
                                ConsumerServicesNotAsDescribed = new()
                                {
                                    CardholderCancellation = new()
                                    {
                                        AcceptedByMerchant =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                                        CanceledAt = "2019-12-27",
                                        Reason = "reason",
                                    },
                                    Explanation = "explanation",
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                                    ReceivedAt = "2019-12-27",
                                },
                                ConsumerServicesNotReceived = new()
                                {
                                    CancellationOutcome =
                                        CardDisputes::UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                                    CardholderCancellationPriorToExpectedReceipt = new()
                                    {
                                        CanceledAt = "2019-12-27",
                                        Reason = "reason",
                                    },
                                    LastExpectedReceiptAt = "2019-12-27",
                                    MerchantCancellation = new("2019-12-27"),
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                                    NoCancellation = new(),
                                    PurchaseInfoAndExplanation = "purchase_info_and_explanation",
                                },
                                Fraud = new(
                                    CardDisputes::UserSubmissionChargebackFraudFraudType.Lost
                                ),
                                ProcessingError = new()
                                {
                                    DuplicateTransaction = new("other_transaction_id"),
                                    ErrorReason =
                                        CardDisputes::UserSubmissionChargebackProcessingErrorErrorReason.DuplicateTransaction,
                                    IncorrectAmount = new(0),
                                    MerchantResolutionAttempted =
                                        CardDisputes::UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                                    PaidByOtherMeans = new()
                                    {
                                        OtherFormOfPaymentEvidence =
                                            CardDisputes::UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                                        OtherTransactionID = "other_transaction_id",
                                    },
                                },
                            },
                            MerchantPrearbitrationDecline = new(
                                "I do not believe the explanation given by the merchant is valid."
                            ),
                            UserPrearbitration = new()
                            {
                                CategoryChange = new()
                                {
                                    Category =
                                        CardDisputes::UserSubmissionUserPrearbitrationCategoryChangeCategory.Fraud,
                                    Reason = "Based on the response from the merchant.",
                                },
                                Reason = "I disagree with the explanation given by the merchant.",
                            },
                        },
                    ],
                },
                Win = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
                Withdrawal = new("The cardholder requested a withdrawal of the dispute."),
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardDisputes::CardDisputeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "card_dispute_h9sc95nbl1cgltpp7men",
                    Amount = 1000,
                    CardID = "card_oubs0hwk5rn6knuecxg2",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DisputedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    IdempotencyKey = null,
                    Loss = new()
                    {
                        LostAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Reason = CardDisputes::LossReason.UserWithdrawn,
                    },
                    Network = CardDisputes::CardDisputeNetwork.Visa,
                    Status = CardDisputes::CardDisputeStatus.PendingResponse,
                    Type = CardDisputes::Type.CardDispute,
                    UserSubmissionRequiredBy = null,
                    Visa = new()
                    {
                        NetworkEvents =
                        [
                            new()
                            {
                                AttachmentFiles = [new("file_id")],
                                Category = CardDisputes::NetworkEventCategory.ChargebackAccepted,
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                DisputeFinancialTransactionID = "dispute_financial_transaction_id",
                                ChargebackAccepted = new(),
                                ChargebackSubmitted = new(),
                                ChargebackTimedOut = new(),
                                MerchantPrearbitrationDeclineSubmitted = new(),
                                MerchantPrearbitrationReceived = new()
                                {
                                    CardholderNoLongerDisputes = new(
                                        "See the attached email where the cardholder confirmed that they no longer dispute the transaction."
                                    ),
                                    CompellingEvidence = new()
                                    {
                                        Category =
                                            CardDisputes::CompellingEvidenceCategory.MerchandiseUse,
                                        Explanation = null,
                                    },
                                    CreditOrReversalProcessed = new()
                                    {
                                        Amount = 4900,
                                        Currency = "USD",
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        ProcessedAt = "2020-01-31",
                                    },
                                    DelayedChargeTransaction = new((string?)null),
                                    EvidenceOfImprint = new((string?)null),
                                    InvalidDispute = new()
                                    {
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        Reason = CardDisputes::InvalidDisputeReason.Other,
                                    },
                                    NonFiatCurrencyOrNonFungibleTokenReceived = new()
                                    {
                                        BlockchainTransactionHash =
                                            "0x1234567890123456789012345678901234567890",
                                        DestinationWalletAddress =
                                            "0x1234567890123456789012345678901234567890",
                                        PriorApprovedTransactions =
                                            "0x1234567890123456789012345678901234567890",
                                    },
                                    PriorUndisputedNonFraudTransactions = new((string?)null),
                                    Reason =
                                        CardDisputes::MerchantPrearbitrationReceivedReason.CardholderNoLongerDisputes,
                                },
                                MerchantPrearbitrationTimedOut = new(),
                                Represented = new()
                                {
                                    CardholderNoLongerDisputes = new(
                                        "See the attached email where the cardholder confirmed that they no longer dispute the transaction."
                                    ),
                                    CreditOrReversalProcessed = new()
                                    {
                                        Amount = 4900,
                                        Currency = "USD",
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        ProcessedAt = "2020-01-31",
                                    },
                                    InvalidDispute = new()
                                    {
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        Reason =
                                            CardDisputes::RepresentedInvalidDisputeReason.Other,
                                    },
                                    NonFiatCurrencyOrNonFungibleTokenAsDescribed = new(),
                                    NonFiatCurrencyOrNonFungibleTokenReceived = new()
                                    {
                                        BlockchainTransactionHash =
                                            "0x1234567890123456789012345678901234567890",
                                        DestinationWalletAddress =
                                            "0x1234567890123456789012345678901234567890",
                                        PriorApprovedTransactions =
                                            "0x1234567890123456789012345678901234567890",
                                    },
                                    ProofOfCashDisbursement = new((string?)null),
                                    Reason = CardDisputes::RepresentedReason.InvalidDispute,
                                    ReversalIssued = new(
                                        "The merchant has issued a reversal for the transaction prior to the dispute being filed."
                                    ),
                                },
                                RepresentmentTimedOut = new(),
                                UserPrearbitrationAccepted = new(),
                                UserPrearbitrationDeclined = new(),
                                UserPrearbitrationSubmitted = new(),
                                UserPrearbitrationTimedOut = new(),
                                UserWithdrawalSubmitted = new(),
                            },
                        ],
                        RequiredUserSubmissionCategory = null,
                        UserSubmissions =
                        [
                            new()
                            {
                                AcceptedAt = null,
                                Amount = 1000,
                                AttachmentFiles = [new("file_id")],
                                Category = CardDisputes::UserSubmissionCategory.Chargeback,
                                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                Explanation = null,
                                FurtherInformationRequestedAt = null,
                                FurtherInformationRequestedReason = null,
                                Status = CardDisputes::UserSubmissionStatus.PendingReviewing,
                                UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                Chargeback = new()
                                {
                                    Authorization = new(
                                        CardDisputes::UserSubmissionChargebackAuthorizationAccountStatus.AccountClosed
                                    ),
                                    Category = CardDisputes::UserSubmissionChargebackCategory.Fraud,
                                    ConsumerCanceledMerchandise = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            CanceledPriorToShipDate =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                                            CancellationPolicyProvided =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                                            Reason = "reason",
                                        },
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                                        NotReturned = new(),
                                        PurchaseExplanation = "purchase_explanation",
                                        ReceivedOrExpectedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerCanceledRecurringTransaction = new()
                                    {
                                        CancellationTarget =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                                        MerchantContactMethods = new()
                                        {
                                            ApplicationName = "application_name",
                                            CallCenterPhoneNumber = "call_center_phone_number",
                                            EmailAddress = "email_address",
                                            InPersonAddress = "in_person_address",
                                            MailingAddress = "mailing_address",
                                            TextPhoneNumber = "text_phone_number",
                                        },
                                        OtherFormOfPaymentExplanation =
                                            "other_form_of_payment_explanation",
                                        TransactionOrAccountCanceledAt = "2019-12-27",
                                    },
                                    ConsumerCanceledServices = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            CancellationPolicyProvided =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                                            Reason = "reason",
                                        },
                                        ContractedAt = "2019-12-27",
                                        GuaranteedReservation = new(
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                                        ),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                                        Other = new(),
                                        PurchaseExplanation = "purchase_explanation",
                                        ServiceType =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                                        Timeshare = new(),
                                    },
                                    ConsumerCounterfeitMerchandise = new()
                                    {
                                        CounterfeitExplanation = "counterfeit_explanation",
                                        DispositionExplanation = "disposition_explanation",
                                        OrderExplanation = "order_explanation",
                                        ReceivedAt = "2019-12-27",
                                    },
                                    ConsumerCreditNotProcessed = new()
                                    {
                                        CanceledOrReturnedAt = "2019-12-27",
                                        CreditExpectedAt = "2019-12-27",
                                    },
                                    ConsumerDamagedOrDefectiveMerchandise = new()
                                    {
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                                        NotReturned = new(),
                                        OrderAndIssueExplanation = "order_and_issue_explanation",
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerMerchandiseMisrepresentation = new()
                                    {
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                                        MisrepresentationExplanation =
                                            "misrepresentation_explanation",
                                        NotReturned = new(),
                                        PurchaseExplanation = "purchase_explanation",
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerMerchandiseNotAsDescribed = new()
                                    {
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerMerchandiseNotReceived = new()
                                    {
                                        CancellationOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                                        CardholderCancellationPriorToExpectedReceipt = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        Delayed = new()
                                        {
                                            Explanation = "explanation",
                                            NotReturned = new(),
                                            ReturnAttempted = new("2019-12-27"),
                                            ReturnOutcome =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                                            Returned = new()
                                            {
                                                MerchantReceivedReturnAt = "2019-12-27",
                                                ReturnedAt = "2019-12-27",
                                            },
                                        },
                                        DeliveredToWrongLocation = new("agreed_location"),
                                        DeliveryIssue =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                                        LastExpectedReceiptAt = "2019-12-27",
                                        MerchantCancellation = new("2019-12-27"),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                                        NoCancellation = new(),
                                        PurchaseInfoAndExplanation =
                                            "purchase_info_and_explanation",
                                    },
                                    ConsumerNonReceiptOfCash = new(),
                                    ConsumerOriginalCreditTransactionNotAccepted = new()
                                    {
                                        Explanation = "explanation",
                                        Reason =
                                            CardDisputes::UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
                                    },
                                    ConsumerQualityMerchandise = new()
                                    {
                                        ExpectedAt = "2019-12-27",
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                                        NotReturned = new(),
                                        OngoingNegotiations = new()
                                        {
                                            Explanation = "explanation",
                                            IssuerFirstNotifiedAt = "2019-12-27",
                                            StartedAt = "2019-12-27",
                                        },
                                        PurchaseInfoAndQualityIssue =
                                            "purchase_info_and_quality_issue",
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerQualityServices = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            AcceptedByMerchant =
                                                CardDisputes::UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        CardholderPaidToHaveWorkRedone =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                                        NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                                        OngoingNegotiations = new()
                                        {
                                            Explanation = "explanation",
                                            IssuerFirstNotifiedAt = "2019-12-27",
                                            StartedAt = "2019-12-27",
                                        },
                                        PurchaseInfoAndQualityIssue =
                                            "purchase_info_and_quality_issue",
                                        RestaurantFoodRelated =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
                                        ServicesReceivedAt = "2019-12-27",
                                    },
                                    ConsumerServicesMisrepresentation = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            AcceptedByMerchant =
                                                CardDisputes::UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                                        MisrepresentationExplanation =
                                            "misrepresentation_explanation",
                                        PurchaseExplanation = "purchase_explanation",
                                        ReceivedAt = "2019-12-27",
                                    },
                                    ConsumerServicesNotAsDescribed = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            AcceptedByMerchant =
                                                CardDisputes::UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        Explanation = "explanation",
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                                        ReceivedAt = "2019-12-27",
                                    },
                                    ConsumerServicesNotReceived = new()
                                    {
                                        CancellationOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                                        CardholderCancellationPriorToExpectedReceipt = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        LastExpectedReceiptAt = "2019-12-27",
                                        MerchantCancellation = new("2019-12-27"),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                                        NoCancellation = new(),
                                        PurchaseInfoAndExplanation =
                                            "purchase_info_and_explanation",
                                    },
                                    Fraud = new(
                                        CardDisputes::UserSubmissionChargebackFraudFraudType.Lost
                                    ),
                                    ProcessingError = new()
                                    {
                                        DuplicateTransaction = new("other_transaction_id"),
                                        ErrorReason =
                                            CardDisputes::UserSubmissionChargebackProcessingErrorErrorReason.DuplicateTransaction,
                                        IncorrectAmount = new(0),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                                        PaidByOtherMeans = new()
                                        {
                                            OtherFormOfPaymentEvidence =
                                                CardDisputes::UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                                            OtherTransactionID = "other_transaction_id",
                                        },
                                    },
                                },
                                MerchantPrearbitrationDecline = new(
                                    "I do not believe the explanation given by the merchant is valid."
                                ),
                                UserPrearbitration = new()
                                {
                                    CategoryChange = new()
                                    {
                                        Category =
                                            CardDisputes::UserSubmissionUserPrearbitrationCategoryChangeCategory.Fraud,
                                        Reason = "Based on the response from the merchant.",
                                    },
                                    Reason =
                                        "I disagree with the explanation given by the merchant.",
                                },
                            },
                        ],
                    },
                    Win = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
                    Withdrawal = new("The cardholder requested a withdrawal of the dispute."),
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardDisputes::CardDisputeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "card_dispute_h9sc95nbl1cgltpp7men",
                    Amount = 1000,
                    CardID = "card_oubs0hwk5rn6knuecxg2",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DisputedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    IdempotencyKey = null,
                    Loss = new()
                    {
                        LostAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Reason = CardDisputes::LossReason.UserWithdrawn,
                    },
                    Network = CardDisputes::CardDisputeNetwork.Visa,
                    Status = CardDisputes::CardDisputeStatus.PendingResponse,
                    Type = CardDisputes::Type.CardDispute,
                    UserSubmissionRequiredBy = null,
                    Visa = new()
                    {
                        NetworkEvents =
                        [
                            new()
                            {
                                AttachmentFiles = [new("file_id")],
                                Category = CardDisputes::NetworkEventCategory.ChargebackAccepted,
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                DisputeFinancialTransactionID = "dispute_financial_transaction_id",
                                ChargebackAccepted = new(),
                                ChargebackSubmitted = new(),
                                ChargebackTimedOut = new(),
                                MerchantPrearbitrationDeclineSubmitted = new(),
                                MerchantPrearbitrationReceived = new()
                                {
                                    CardholderNoLongerDisputes = new(
                                        "See the attached email where the cardholder confirmed that they no longer dispute the transaction."
                                    ),
                                    CompellingEvidence = new()
                                    {
                                        Category =
                                            CardDisputes::CompellingEvidenceCategory.MerchandiseUse,
                                        Explanation = null,
                                    },
                                    CreditOrReversalProcessed = new()
                                    {
                                        Amount = 4900,
                                        Currency = "USD",
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        ProcessedAt = "2020-01-31",
                                    },
                                    DelayedChargeTransaction = new((string?)null),
                                    EvidenceOfImprint = new((string?)null),
                                    InvalidDispute = new()
                                    {
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        Reason = CardDisputes::InvalidDisputeReason.Other,
                                    },
                                    NonFiatCurrencyOrNonFungibleTokenReceived = new()
                                    {
                                        BlockchainTransactionHash =
                                            "0x1234567890123456789012345678901234567890",
                                        DestinationWalletAddress =
                                            "0x1234567890123456789012345678901234567890",
                                        PriorApprovedTransactions =
                                            "0x1234567890123456789012345678901234567890",
                                    },
                                    PriorUndisputedNonFraudTransactions = new((string?)null),
                                    Reason =
                                        CardDisputes::MerchantPrearbitrationReceivedReason.CardholderNoLongerDisputes,
                                },
                                MerchantPrearbitrationTimedOut = new(),
                                Represented = new()
                                {
                                    CardholderNoLongerDisputes = new(
                                        "See the attached email where the cardholder confirmed that they no longer dispute the transaction."
                                    ),
                                    CreditOrReversalProcessed = new()
                                    {
                                        Amount = 4900,
                                        Currency = "USD",
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        ProcessedAt = "2020-01-31",
                                    },
                                    InvalidDispute = new()
                                    {
                                        Explanation =
                                            "The user did not provide the required documentation.",
                                        Reason =
                                            CardDisputes::RepresentedInvalidDisputeReason.Other,
                                    },
                                    NonFiatCurrencyOrNonFungibleTokenAsDescribed = new(),
                                    NonFiatCurrencyOrNonFungibleTokenReceived = new()
                                    {
                                        BlockchainTransactionHash =
                                            "0x1234567890123456789012345678901234567890",
                                        DestinationWalletAddress =
                                            "0x1234567890123456789012345678901234567890",
                                        PriorApprovedTransactions =
                                            "0x1234567890123456789012345678901234567890",
                                    },
                                    ProofOfCashDisbursement = new((string?)null),
                                    Reason = CardDisputes::RepresentedReason.InvalidDispute,
                                    ReversalIssued = new(
                                        "The merchant has issued a reversal for the transaction prior to the dispute being filed."
                                    ),
                                },
                                RepresentmentTimedOut = new(),
                                UserPrearbitrationAccepted = new(),
                                UserPrearbitrationDeclined = new(),
                                UserPrearbitrationSubmitted = new(),
                                UserPrearbitrationTimedOut = new(),
                                UserWithdrawalSubmitted = new(),
                            },
                        ],
                        RequiredUserSubmissionCategory = null,
                        UserSubmissions =
                        [
                            new()
                            {
                                AcceptedAt = null,
                                Amount = 1000,
                                AttachmentFiles = [new("file_id")],
                                Category = CardDisputes::UserSubmissionCategory.Chargeback,
                                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                Explanation = null,
                                FurtherInformationRequestedAt = null,
                                FurtherInformationRequestedReason = null,
                                Status = CardDisputes::UserSubmissionStatus.PendingReviewing,
                                UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                Chargeback = new()
                                {
                                    Authorization = new(
                                        CardDisputes::UserSubmissionChargebackAuthorizationAccountStatus.AccountClosed
                                    ),
                                    Category = CardDisputes::UserSubmissionChargebackCategory.Fraud,
                                    ConsumerCanceledMerchandise = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            CanceledPriorToShipDate =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                                            CancellationPolicyProvided =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                                            Reason = "reason",
                                        },
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                                        NotReturned = new(),
                                        PurchaseExplanation = "purchase_explanation",
                                        ReceivedOrExpectedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerCanceledRecurringTransaction = new()
                                    {
                                        CancellationTarget =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                                        MerchantContactMethods = new()
                                        {
                                            ApplicationName = "application_name",
                                            CallCenterPhoneNumber = "call_center_phone_number",
                                            EmailAddress = "email_address",
                                            InPersonAddress = "in_person_address",
                                            MailingAddress = "mailing_address",
                                            TextPhoneNumber = "text_phone_number",
                                        },
                                        OtherFormOfPaymentExplanation =
                                            "other_form_of_payment_explanation",
                                        TransactionOrAccountCanceledAt = "2019-12-27",
                                    },
                                    ConsumerCanceledServices = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            CancellationPolicyProvided =
                                                CardDisputes::UserSubmissionChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                                            Reason = "reason",
                                        },
                                        ContractedAt = "2019-12-27",
                                        GuaranteedReservation = new(
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                                        ),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                                        Other = new(),
                                        PurchaseExplanation = "purchase_explanation",
                                        ServiceType =
                                            CardDisputes::UserSubmissionChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                                        Timeshare = new(),
                                    },
                                    ConsumerCounterfeitMerchandise = new()
                                    {
                                        CounterfeitExplanation = "counterfeit_explanation",
                                        DispositionExplanation = "disposition_explanation",
                                        OrderExplanation = "order_explanation",
                                        ReceivedAt = "2019-12-27",
                                    },
                                    ConsumerCreditNotProcessed = new()
                                    {
                                        CanceledOrReturnedAt = "2019-12-27",
                                        CreditExpectedAt = "2019-12-27",
                                    },
                                    ConsumerDamagedOrDefectiveMerchandise = new()
                                    {
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                                        NotReturned = new(),
                                        OrderAndIssueExplanation = "order_and_issue_explanation",
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerMerchandiseMisrepresentation = new()
                                    {
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                                        MisrepresentationExplanation =
                                            "misrepresentation_explanation",
                                        NotReturned = new(),
                                        PurchaseExplanation = "purchase_explanation",
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerMerchandiseNotAsDescribed = new()
                                    {
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerMerchandiseNotReceived = new()
                                    {
                                        CancellationOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                                        CardholderCancellationPriorToExpectedReceipt = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        Delayed = new()
                                        {
                                            Explanation = "explanation",
                                            NotReturned = new(),
                                            ReturnAttempted = new("2019-12-27"),
                                            ReturnOutcome =
                                                CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                                            Returned = new()
                                            {
                                                MerchantReceivedReturnAt = "2019-12-27",
                                                ReturnedAt = "2019-12-27",
                                            },
                                        },
                                        DeliveredToWrongLocation = new("agreed_location"),
                                        DeliveryIssue =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                                        LastExpectedReceiptAt = "2019-12-27",
                                        MerchantCancellation = new("2019-12-27"),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                                        NoCancellation = new(),
                                        PurchaseInfoAndExplanation =
                                            "purchase_info_and_explanation",
                                    },
                                    ConsumerNonReceiptOfCash = new(),
                                    ConsumerOriginalCreditTransactionNotAccepted = new()
                                    {
                                        Explanation = "explanation",
                                        Reason =
                                            CardDisputes::UserSubmissionChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
                                    },
                                    ConsumerQualityMerchandise = new()
                                    {
                                        ExpectedAt = "2019-12-27",
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                                        NotReturned = new(),
                                        OngoingNegotiations = new()
                                        {
                                            Explanation = "explanation",
                                            IssuerFirstNotifiedAt = "2019-12-27",
                                            StartedAt = "2019-12-27",
                                        },
                                        PurchaseInfoAndQualityIssue =
                                            "purchase_info_and_quality_issue",
                                        ReceivedAt = "2019-12-27",
                                        ReturnAttempted = new()
                                        {
                                            AttemptExplanation = "attempt_explanation",
                                            AttemptReason =
                                                CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                                            AttemptedAt = "2019-12-27",
                                            MerchandiseDisposition = "merchandise_disposition",
                                        },
                                        ReturnOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                                        Returned = new()
                                        {
                                            MerchantReceivedReturnAt = "2019-12-27",
                                            OtherExplanation = "other_explanation",
                                            ReturnMethod =
                                                CardDisputes::UserSubmissionChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                                            ReturnedAt = "2019-12-27",
                                            TrackingNumber = "tracking_number",
                                        },
                                    },
                                    ConsumerQualityServices = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            AcceptedByMerchant =
                                                CardDisputes::UserSubmissionChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        CardholderPaidToHaveWorkRedone =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                                        NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                                        OngoingNegotiations = new()
                                        {
                                            Explanation = "explanation",
                                            IssuerFirstNotifiedAt = "2019-12-27",
                                            StartedAt = "2019-12-27",
                                        },
                                        PurchaseInfoAndQualityIssue =
                                            "purchase_info_and_quality_issue",
                                        RestaurantFoodRelated =
                                            CardDisputes::UserSubmissionChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
                                        ServicesReceivedAt = "2019-12-27",
                                    },
                                    ConsumerServicesMisrepresentation = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            AcceptedByMerchant =
                                                CardDisputes::UserSubmissionChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                                        MisrepresentationExplanation =
                                            "misrepresentation_explanation",
                                        PurchaseExplanation = "purchase_explanation",
                                        ReceivedAt = "2019-12-27",
                                    },
                                    ConsumerServicesNotAsDescribed = new()
                                    {
                                        CardholderCancellation = new()
                                        {
                                            AcceptedByMerchant =
                                                CardDisputes::UserSubmissionChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        Explanation = "explanation",
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                                        ReceivedAt = "2019-12-27",
                                    },
                                    ConsumerServicesNotReceived = new()
                                    {
                                        CancellationOutcome =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                                        CardholderCancellationPriorToExpectedReceipt = new()
                                        {
                                            CanceledAt = "2019-12-27",
                                            Reason = "reason",
                                        },
                                        LastExpectedReceiptAt = "2019-12-27",
                                        MerchantCancellation = new("2019-12-27"),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                                        NoCancellation = new(),
                                        PurchaseInfoAndExplanation =
                                            "purchase_info_and_explanation",
                                    },
                                    Fraud = new(
                                        CardDisputes::UserSubmissionChargebackFraudFraudType.Lost
                                    ),
                                    ProcessingError = new()
                                    {
                                        DuplicateTransaction = new("other_transaction_id"),
                                        ErrorReason =
                                            CardDisputes::UserSubmissionChargebackProcessingErrorErrorReason.DuplicateTransaction,
                                        IncorrectAmount = new(0),
                                        MerchantResolutionAttempted =
                                            CardDisputes::UserSubmissionChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                                        PaidByOtherMeans = new()
                                        {
                                            OtherFormOfPaymentEvidence =
                                                CardDisputes::UserSubmissionChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                                            OtherTransactionID = "other_transaction_id",
                                        },
                                    },
                                },
                                MerchantPrearbitrationDecline = new(
                                    "I do not believe the explanation given by the merchant is valid."
                                ),
                                UserPrearbitration = new()
                                {
                                    CategoryChange = new()
                                    {
                                        Category =
                                            CardDisputes::UserSubmissionUserPrearbitrationCategoryChangeCategory.Fraud,
                                        Reason = "Based on the response from the merchant.",
                                    },
                                    Reason =
                                        "I disagree with the explanation given by the merchant.",
                                },
                            },
                        ],
                    },
                    Win = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
                    Withdrawal = new("The cardholder requested a withdrawal of the dispute."),
                },
            ],
            NextCursor = "v57w5d",
        };

        CardDisputes::CardDisputeListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
