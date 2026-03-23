using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CardDisputes;

namespace Increase.Api.Tests.Models.CardDisputes;

public class CardDisputeSubmitUserSubmissionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardDisputeSubmitUserSubmissionParams
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
            Network = CardDisputeSubmitUserSubmissionParamsNetwork.Visa,
            Amount = 1,
            AttachmentFiles = [new("file_id")],
            Explanation = "x",
            Visa = new()
            {
                Category =
                    CardDisputeSubmitUserSubmissionParamsVisaCategory.MerchantPrearbitrationDecline,
                Chargeback = new()
                {
                    Category = ChargebackCategory.Authorization,
                    Authorization = new(ChargebackAuthorizationAccountStatus.AccountClosed),
                    ConsumerCanceledMerchandise = new()
                    {
                        MerchantResolutionAttempted =
                            ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                        PurchaseExplanation = "x",
                        ReceivedOrExpectedAt = "2019-12-27",
                        ReturnOutcome =
                            ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                        CardholderCancellation = new()
                        {
                            CanceledAt = "2019-12-27",
                            CanceledPriorToShipDate =
                                ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                            CancellationPolicyProvided =
                                ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                            Reason = "x",
                        },
                        NotReturned = new(),
                        ReturnAttempted = new()
                        {
                            AttemptExplanation = "x",
                            AttemptReason =
                                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                            AttemptedAt = "2019-12-27",
                            MerchandiseDisposition = "x",
                        },
                        Returned = new()
                        {
                            ReturnMethod =
                                ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                            ReturnedAt = "2019-12-27",
                            MerchantReceivedReturnAt = "2019-12-27",
                            OtherExplanation = "x",
                            TrackingNumber = "x",
                        },
                    },
                    ConsumerCanceledRecurringTransaction = new()
                    {
                        CancellationTarget =
                            ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                        MerchantContactMethods = new()
                        {
                            ApplicationName = "x",
                            CallCenterPhoneNumber = "x",
                            EmailAddress = "x",
                            InPersonAddress = "x",
                            MailingAddress = "x",
                            TextPhoneNumber = "x",
                        },
                        TransactionOrAccountCanceledAt = "2019-12-27",
                        OtherFormOfPaymentExplanation = "x",
                    },
                    ConsumerCanceledServices = new()
                    {
                        CardholderCancellation = new()
                        {
                            CanceledAt = "2019-12-27",
                            CancellationPolicyProvided =
                                ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                            Reason = "x",
                        },
                        ContractedAt = "2019-12-27",
                        MerchantResolutionAttempted =
                            ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                        PurchaseExplanation = "x",
                        ServiceType =
                            ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                        GuaranteedReservation = new(
                            ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                        ),
                        Other = new(),
                        Timeshare = new(),
                    },
                    ConsumerCounterfeitMerchandise = new()
                    {
                        CounterfeitExplanation = "x",
                        DispositionExplanation = "x",
                        OrderExplanation = "x",
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
                            ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                        OrderAndIssueExplanation = "x",
                        ReceivedAt = "2019-12-27",
                        ReturnOutcome =
                            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                        NotReturned = new(),
                        ReturnAttempted = new()
                        {
                            AttemptExplanation = "x",
                            AttemptReason =
                                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                            AttemptedAt = "2019-12-27",
                            MerchandiseDisposition = "x",
                        },
                        Returned = new()
                        {
                            ReturnMethod =
                                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                            ReturnedAt = "2019-12-27",
                            MerchantReceivedReturnAt = "2019-12-27",
                            OtherExplanation = "x",
                            TrackingNumber = "x",
                        },
                    },
                    ConsumerMerchandiseMisrepresentation = new()
                    {
                        MerchantResolutionAttempted =
                            ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                        MisrepresentationExplanation = "x",
                        PurchaseExplanation = "x",
                        ReceivedAt = "2019-12-27",
                        ReturnOutcome =
                            ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                        NotReturned = new(),
                        ReturnAttempted = new()
                        {
                            AttemptExplanation = "x",
                            AttemptReason =
                                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                            AttemptedAt = "2019-12-27",
                            MerchandiseDisposition = "x",
                        },
                        Returned = new()
                        {
                            ReturnMethod =
                                ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                            ReturnedAt = "2019-12-27",
                            MerchantReceivedReturnAt = "2019-12-27",
                            OtherExplanation = "x",
                            TrackingNumber = "x",
                        },
                    },
                    ConsumerMerchandiseNotAsDescribed = new()
                    {
                        MerchantResolutionAttempted =
                            ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                        ReceivedAt = "2019-12-27",
                        ReturnOutcome =
                            ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                        ReturnAttempted = new()
                        {
                            AttemptExplanation = "x",
                            AttemptReason =
                                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                            AttemptedAt = "2019-12-27",
                            MerchandiseDisposition = "x",
                        },
                        Returned = new()
                        {
                            ReturnMethod =
                                ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                            ReturnedAt = "2019-12-27",
                            MerchantReceivedReturnAt = "2019-12-27",
                            OtherExplanation = "x",
                            TrackingNumber = "x",
                        },
                    },
                    ConsumerMerchandiseNotReceived = new()
                    {
                        CancellationOutcome =
                            ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                        DeliveryIssue =
                            ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                        LastExpectedReceiptAt = "2019-12-27",
                        MerchantResolutionAttempted =
                            ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                        PurchaseInfoAndExplanation = "x",
                        CardholderCancellationPriorToExpectedReceipt = new()
                        {
                            CanceledAt = "2019-12-27",
                            Reason = "x",
                        },
                        Delayed = new()
                        {
                            Explanation = "x",
                            ReturnOutcome =
                                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                            NotReturned = new(),
                            ReturnAttempted = new("2019-12-27"),
                            Returned = new()
                            {
                                MerchantReceivedReturnAt = "2019-12-27",
                                ReturnedAt = "2019-12-27",
                            },
                        },
                        DeliveredToWrongLocation = new("x"),
                        MerchantCancellation = new("2019-12-27"),
                        NoCancellation = new(),
                    },
                    ConsumerNonReceiptOfCash = new(),
                    ConsumerOriginalCreditTransactionNotAccepted = new()
                    {
                        Explanation = "x",
                        Reason =
                            ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
                    },
                    ConsumerQualityMerchandise = new()
                    {
                        ExpectedAt = "2019-12-27",
                        MerchantResolutionAttempted =
                            ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                        PurchaseInfoAndQualityIssue = "x",
                        ReceivedAt = "2019-12-27",
                        ReturnOutcome =
                            ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                        NotReturned = new(),
                        OngoingNegotiations = new()
                        {
                            Explanation = "x",
                            IssuerFirstNotifiedAt = "2019-12-27",
                            StartedAt = "2019-12-27",
                        },
                        ReturnAttempted = new()
                        {
                            AttemptExplanation = "x",
                            AttemptReason =
                                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                            AttemptedAt = "2019-12-27",
                            MerchandiseDisposition = "x",
                        },
                        Returned = new()
                        {
                            ReturnMethod =
                                ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                            ReturnedAt = "2019-12-27",
                            MerchantReceivedReturnAt = "2019-12-27",
                            OtherExplanation = "x",
                            TrackingNumber = "x",
                        },
                    },
                    ConsumerQualityServices = new()
                    {
                        CardholderCancellation = new()
                        {
                            AcceptedByMerchant =
                                ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                            CanceledAt = "2019-12-27",
                            Reason = "x",
                        },
                        NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                            ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                        PurchaseInfoAndQualityIssue = "x",
                        ServicesReceivedAt = "2019-12-27",
                        CardholderPaidToHaveWorkRedone =
                            ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                        OngoingNegotiations = new()
                        {
                            Explanation = "x",
                            IssuerFirstNotifiedAt = "2019-12-27",
                            StartedAt = "2019-12-27",
                        },
                        RestaurantFoodRelated =
                            ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
                    },
                    ConsumerServicesMisrepresentation = new()
                    {
                        CardholderCancellation = new()
                        {
                            AcceptedByMerchant =
                                ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                            CanceledAt = "2019-12-27",
                            Reason = "x",
                        },
                        MerchantResolutionAttempted =
                            ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                        MisrepresentationExplanation = "x",
                        PurchaseExplanation = "x",
                        ReceivedAt = "2019-12-27",
                    },
                    ConsumerServicesNotAsDescribed = new()
                    {
                        CardholderCancellation = new()
                        {
                            AcceptedByMerchant =
                                ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                            CanceledAt = "2019-12-27",
                            Reason = "x",
                        },
                        Explanation = "x",
                        MerchantResolutionAttempted =
                            ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                        ReceivedAt = "2019-12-27",
                    },
                    ConsumerServicesNotReceived = new()
                    {
                        CancellationOutcome =
                            ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                        LastExpectedReceiptAt = "2019-12-27",
                        MerchantResolutionAttempted =
                            ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                        PurchaseInfoAndExplanation = "x",
                        CardholderCancellationPriorToExpectedReceipt = new()
                        {
                            CanceledAt = "2019-12-27",
                            Reason = "x",
                        },
                        MerchantCancellation = new("2019-12-27"),
                        NoCancellation = new(),
                    },
                    Fraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover),
                    ProcessingError = new()
                    {
                        ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
                        MerchantResolutionAttempted =
                            ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                        DuplicateTransaction = new("x"),
                        IncorrectAmount = new(0),
                        PaidByOtherMeans = new()
                        {
                            OtherFormOfPaymentEvidence =
                                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                            OtherTransactionID = "x",
                        },
                    },
                },
                MerchantPrearbitrationDecline = new(
                    "The pre-arbitration received from the merchantdoes not explain how they obtained permission to charge the card."
                ),
                UserPrearbitration = new()
                {
                    Reason = "x",
                    CategoryChange = new()
                    {
                        Category = CategoryChangeCategory.Authorization,
                        Reason = "x",
                    },
                },
            },
        };

        string expectedCardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men";
        ApiEnum<string, CardDisputeSubmitUserSubmissionParamsNetwork> expectedNetwork =
            CardDisputeSubmitUserSubmissionParamsNetwork.Visa;
        long expectedAmount = 1;
        List<CardDisputeSubmitUserSubmissionParamsAttachmentFile> expectedAttachmentFiles =
        [
            new("file_id"),
        ];
        string expectedExplanation = "x";
        CardDisputeSubmitUserSubmissionParamsVisa expectedVisa = new()
        {
            Category =
                CardDisputeSubmitUserSubmissionParamsVisaCategory.MerchantPrearbitrationDecline,
            Chargeback = new()
            {
                Category = ChargebackCategory.Authorization,
                Authorization = new(ChargebackAuthorizationAccountStatus.AccountClosed),
                ConsumerCanceledMerchandise = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                    PurchaseExplanation = "x",
                    ReceivedOrExpectedAt = "2019-12-27",
                    ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                    CardholderCancellation = new()
                    {
                        CanceledAt = "2019-12-27",
                        CanceledPriorToShipDate =
                            ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                        CancellationPolicyProvided =
                            ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                        Reason = "x",
                    },
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerCanceledRecurringTransaction = new()
                {
                    CancellationTarget =
                        ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                    MerchantContactMethods = new()
                    {
                        ApplicationName = "x",
                        CallCenterPhoneNumber = "x",
                        EmailAddress = "x",
                        InPersonAddress = "x",
                        MailingAddress = "x",
                        TextPhoneNumber = "x",
                    },
                    TransactionOrAccountCanceledAt = "2019-12-27",
                    OtherFormOfPaymentExplanation = "x",
                },
                ConsumerCanceledServices = new()
                {
                    CardholderCancellation = new()
                    {
                        CanceledAt = "2019-12-27",
                        CancellationPolicyProvided =
                            ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                        Reason = "x",
                    },
                    ContractedAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                    PurchaseExplanation = "x",
                    ServiceType =
                        ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                    GuaranteedReservation = new(
                        ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                    ),
                    Other = new(),
                    Timeshare = new(),
                },
                ConsumerCounterfeitMerchandise = new()
                {
                    CounterfeitExplanation = "x",
                    DispositionExplanation = "x",
                    OrderExplanation = "x",
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
                        ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                    OrderAndIssueExplanation = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseMisrepresentation = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                    MisrepresentationExplanation = "x",
                    PurchaseExplanation = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseNotAsDescribed = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseNotReceived = new()
                {
                    CancellationOutcome =
                        ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                    DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                    LastExpectedReceiptAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndExplanation = "x",
                    CardholderCancellationPriorToExpectedReceipt = new()
                    {
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    Delayed = new()
                    {
                        Explanation = "x",
                        ReturnOutcome =
                            ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                        NotReturned = new(),
                        ReturnAttempted = new("2019-12-27"),
                        Returned = new()
                        {
                            MerchantReceivedReturnAt = "2019-12-27",
                            ReturnedAt = "2019-12-27",
                        },
                    },
                    DeliveredToWrongLocation = new("x"),
                    MerchantCancellation = new("2019-12-27"),
                    NoCancellation = new(),
                },
                ConsumerNonReceiptOfCash = new(),
                ConsumerOriginalCreditTransactionNotAccepted = new()
                {
                    Explanation = "x",
                    Reason =
                        ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
                },
                ConsumerQualityMerchandise = new()
                {
                    ExpectedAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndQualityIssue = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                    NotReturned = new(),
                    OngoingNegotiations = new()
                    {
                        Explanation = "x",
                        IssuerFirstNotifiedAt = "2019-12-27",
                        StartedAt = "2019-12-27",
                    },
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerQualityServices = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                        ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                    PurchaseInfoAndQualityIssue = "x",
                    ServicesReceivedAt = "2019-12-27",
                    CardholderPaidToHaveWorkRedone =
                        ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                    OngoingNegotiations = new()
                    {
                        Explanation = "x",
                        IssuerFirstNotifiedAt = "2019-12-27",
                        StartedAt = "2019-12-27",
                    },
                    RestaurantFoodRelated =
                        ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
                },
                ConsumerServicesMisrepresentation = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                    MisrepresentationExplanation = "x",
                    PurchaseExplanation = "x",
                    ReceivedAt = "2019-12-27",
                },
                ConsumerServicesNotAsDescribed = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    Explanation = "x",
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                    ReceivedAt = "2019-12-27",
                },
                ConsumerServicesNotReceived = new()
                {
                    CancellationOutcome =
                        ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                    LastExpectedReceiptAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndExplanation = "x",
                    CardholderCancellationPriorToExpectedReceipt = new()
                    {
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    MerchantCancellation = new("2019-12-27"),
                    NoCancellation = new(),
                },
                Fraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover),
                ProcessingError = new()
                {
                    ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
                    MerchantResolutionAttempted =
                        ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                    DuplicateTransaction = new("x"),
                    IncorrectAmount = new(0),
                    PaidByOtherMeans = new()
                    {
                        OtherFormOfPaymentEvidence =
                            ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                        OtherTransactionID = "x",
                    },
                },
            },
            MerchantPrearbitrationDecline = new(
                "The pre-arbitration received from the merchantdoes not explain how they obtained permission to charge the card."
            ),
            UserPrearbitration = new()
            {
                Reason = "x",
                CategoryChange = new()
                {
                    Category = CategoryChangeCategory.Authorization,
                    Reason = "x",
                },
            },
        };

        Assert.Equal(expectedCardDisputeID, parameters.CardDisputeID);
        Assert.Equal(expectedNetwork, parameters.Network);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.NotNull(parameters.AttachmentFiles);
        Assert.Equal(expectedAttachmentFiles.Count, parameters.AttachmentFiles.Count);
        for (int i = 0; i < expectedAttachmentFiles.Count; i++)
        {
            Assert.Equal(expectedAttachmentFiles[i], parameters.AttachmentFiles[i]);
        }
        Assert.Equal(expectedExplanation, parameters.Explanation);
        Assert.Equal(expectedVisa, parameters.Visa);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CardDisputeSubmitUserSubmissionParams
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
            Network = CardDisputeSubmitUserSubmissionParamsNetwork.Visa,
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
        Assert.Null(parameters.AttachmentFiles);
        Assert.False(parameters.RawBodyData.ContainsKey("attachment_files"));
        Assert.Null(parameters.Explanation);
        Assert.False(parameters.RawBodyData.ContainsKey("explanation"));
        Assert.Null(parameters.Visa);
        Assert.False(parameters.RawBodyData.ContainsKey("visa"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CardDisputeSubmitUserSubmissionParams
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
            Network = CardDisputeSubmitUserSubmissionParamsNetwork.Visa,

            // Null should be interpreted as omitted for these properties
            Amount = null,
            AttachmentFiles = null,
            Explanation = null,
            Visa = null,
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
        Assert.Null(parameters.AttachmentFiles);
        Assert.False(parameters.RawBodyData.ContainsKey("attachment_files"));
        Assert.Null(parameters.Explanation);
        Assert.False(parameters.RawBodyData.ContainsKey("explanation"));
        Assert.Null(parameters.Visa);
        Assert.False(parameters.RawBodyData.ContainsKey("visa"));
    }

    [Fact]
    public void Url_Works()
    {
        CardDisputeSubmitUserSubmissionParams parameters = new()
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
            Network = CardDisputeSubmitUserSubmissionParamsNetwork.Visa,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/card_disputes/card_dispute_h9sc95nbl1cgltpp7men/submit_user_submission"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardDisputeSubmitUserSubmissionParams
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
            Network = CardDisputeSubmitUserSubmissionParamsNetwork.Visa,
            Amount = 1,
            AttachmentFiles = [new("file_id")],
            Explanation = "x",
            Visa = new()
            {
                Category =
                    CardDisputeSubmitUserSubmissionParamsVisaCategory.MerchantPrearbitrationDecline,
                Chargeback = new()
                {
                    Category = ChargebackCategory.Authorization,
                    Authorization = new(ChargebackAuthorizationAccountStatus.AccountClosed),
                    ConsumerCanceledMerchandise = new()
                    {
                        MerchantResolutionAttempted =
                            ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                        PurchaseExplanation = "x",
                        ReceivedOrExpectedAt = "2019-12-27",
                        ReturnOutcome =
                            ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                        CardholderCancellation = new()
                        {
                            CanceledAt = "2019-12-27",
                            CanceledPriorToShipDate =
                                ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                            CancellationPolicyProvided =
                                ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                            Reason = "x",
                        },
                        NotReturned = new(),
                        ReturnAttempted = new()
                        {
                            AttemptExplanation = "x",
                            AttemptReason =
                                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                            AttemptedAt = "2019-12-27",
                            MerchandiseDisposition = "x",
                        },
                        Returned = new()
                        {
                            ReturnMethod =
                                ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                            ReturnedAt = "2019-12-27",
                            MerchantReceivedReturnAt = "2019-12-27",
                            OtherExplanation = "x",
                            TrackingNumber = "x",
                        },
                    },
                    ConsumerCanceledRecurringTransaction = new()
                    {
                        CancellationTarget =
                            ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                        MerchantContactMethods = new()
                        {
                            ApplicationName = "x",
                            CallCenterPhoneNumber = "x",
                            EmailAddress = "x",
                            InPersonAddress = "x",
                            MailingAddress = "x",
                            TextPhoneNumber = "x",
                        },
                        TransactionOrAccountCanceledAt = "2019-12-27",
                        OtherFormOfPaymentExplanation = "x",
                    },
                    ConsumerCanceledServices = new()
                    {
                        CardholderCancellation = new()
                        {
                            CanceledAt = "2019-12-27",
                            CancellationPolicyProvided =
                                ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                            Reason = "x",
                        },
                        ContractedAt = "2019-12-27",
                        MerchantResolutionAttempted =
                            ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                        PurchaseExplanation = "x",
                        ServiceType =
                            ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                        GuaranteedReservation = new(
                            ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                        ),
                        Other = new(),
                        Timeshare = new(),
                    },
                    ConsumerCounterfeitMerchandise = new()
                    {
                        CounterfeitExplanation = "x",
                        DispositionExplanation = "x",
                        OrderExplanation = "x",
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
                            ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                        OrderAndIssueExplanation = "x",
                        ReceivedAt = "2019-12-27",
                        ReturnOutcome =
                            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                        NotReturned = new(),
                        ReturnAttempted = new()
                        {
                            AttemptExplanation = "x",
                            AttemptReason =
                                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                            AttemptedAt = "2019-12-27",
                            MerchandiseDisposition = "x",
                        },
                        Returned = new()
                        {
                            ReturnMethod =
                                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                            ReturnedAt = "2019-12-27",
                            MerchantReceivedReturnAt = "2019-12-27",
                            OtherExplanation = "x",
                            TrackingNumber = "x",
                        },
                    },
                    ConsumerMerchandiseMisrepresentation = new()
                    {
                        MerchantResolutionAttempted =
                            ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                        MisrepresentationExplanation = "x",
                        PurchaseExplanation = "x",
                        ReceivedAt = "2019-12-27",
                        ReturnOutcome =
                            ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                        NotReturned = new(),
                        ReturnAttempted = new()
                        {
                            AttemptExplanation = "x",
                            AttemptReason =
                                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                            AttemptedAt = "2019-12-27",
                            MerchandiseDisposition = "x",
                        },
                        Returned = new()
                        {
                            ReturnMethod =
                                ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                            ReturnedAt = "2019-12-27",
                            MerchantReceivedReturnAt = "2019-12-27",
                            OtherExplanation = "x",
                            TrackingNumber = "x",
                        },
                    },
                    ConsumerMerchandiseNotAsDescribed = new()
                    {
                        MerchantResolutionAttempted =
                            ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                        ReceivedAt = "2019-12-27",
                        ReturnOutcome =
                            ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                        ReturnAttempted = new()
                        {
                            AttemptExplanation = "x",
                            AttemptReason =
                                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                            AttemptedAt = "2019-12-27",
                            MerchandiseDisposition = "x",
                        },
                        Returned = new()
                        {
                            ReturnMethod =
                                ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                            ReturnedAt = "2019-12-27",
                            MerchantReceivedReturnAt = "2019-12-27",
                            OtherExplanation = "x",
                            TrackingNumber = "x",
                        },
                    },
                    ConsumerMerchandiseNotReceived = new()
                    {
                        CancellationOutcome =
                            ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                        DeliveryIssue =
                            ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                        LastExpectedReceiptAt = "2019-12-27",
                        MerchantResolutionAttempted =
                            ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                        PurchaseInfoAndExplanation = "x",
                        CardholderCancellationPriorToExpectedReceipt = new()
                        {
                            CanceledAt = "2019-12-27",
                            Reason = "x",
                        },
                        Delayed = new()
                        {
                            Explanation = "x",
                            ReturnOutcome =
                                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                            NotReturned = new(),
                            ReturnAttempted = new("2019-12-27"),
                            Returned = new()
                            {
                                MerchantReceivedReturnAt = "2019-12-27",
                                ReturnedAt = "2019-12-27",
                            },
                        },
                        DeliveredToWrongLocation = new("x"),
                        MerchantCancellation = new("2019-12-27"),
                        NoCancellation = new(),
                    },
                    ConsumerNonReceiptOfCash = new(),
                    ConsumerOriginalCreditTransactionNotAccepted = new()
                    {
                        Explanation = "x",
                        Reason =
                            ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
                    },
                    ConsumerQualityMerchandise = new()
                    {
                        ExpectedAt = "2019-12-27",
                        MerchantResolutionAttempted =
                            ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                        PurchaseInfoAndQualityIssue = "x",
                        ReceivedAt = "2019-12-27",
                        ReturnOutcome =
                            ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                        NotReturned = new(),
                        OngoingNegotiations = new()
                        {
                            Explanation = "x",
                            IssuerFirstNotifiedAt = "2019-12-27",
                            StartedAt = "2019-12-27",
                        },
                        ReturnAttempted = new()
                        {
                            AttemptExplanation = "x",
                            AttemptReason =
                                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                            AttemptedAt = "2019-12-27",
                            MerchandiseDisposition = "x",
                        },
                        Returned = new()
                        {
                            ReturnMethod =
                                ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                            ReturnedAt = "2019-12-27",
                            MerchantReceivedReturnAt = "2019-12-27",
                            OtherExplanation = "x",
                            TrackingNumber = "x",
                        },
                    },
                    ConsumerQualityServices = new()
                    {
                        CardholderCancellation = new()
                        {
                            AcceptedByMerchant =
                                ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                            CanceledAt = "2019-12-27",
                            Reason = "x",
                        },
                        NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                            ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                        PurchaseInfoAndQualityIssue = "x",
                        ServicesReceivedAt = "2019-12-27",
                        CardholderPaidToHaveWorkRedone =
                            ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                        OngoingNegotiations = new()
                        {
                            Explanation = "x",
                            IssuerFirstNotifiedAt = "2019-12-27",
                            StartedAt = "2019-12-27",
                        },
                        RestaurantFoodRelated =
                            ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
                    },
                    ConsumerServicesMisrepresentation = new()
                    {
                        CardholderCancellation = new()
                        {
                            AcceptedByMerchant =
                                ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                            CanceledAt = "2019-12-27",
                            Reason = "x",
                        },
                        MerchantResolutionAttempted =
                            ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                        MisrepresentationExplanation = "x",
                        PurchaseExplanation = "x",
                        ReceivedAt = "2019-12-27",
                    },
                    ConsumerServicesNotAsDescribed = new()
                    {
                        CardholderCancellation = new()
                        {
                            AcceptedByMerchant =
                                ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                            CanceledAt = "2019-12-27",
                            Reason = "x",
                        },
                        Explanation = "x",
                        MerchantResolutionAttempted =
                            ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                        ReceivedAt = "2019-12-27",
                    },
                    ConsumerServicesNotReceived = new()
                    {
                        CancellationOutcome =
                            ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                        LastExpectedReceiptAt = "2019-12-27",
                        MerchantResolutionAttempted =
                            ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                        PurchaseInfoAndExplanation = "x",
                        CardholderCancellationPriorToExpectedReceipt = new()
                        {
                            CanceledAt = "2019-12-27",
                            Reason = "x",
                        },
                        MerchantCancellation = new("2019-12-27"),
                        NoCancellation = new(),
                    },
                    Fraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover),
                    ProcessingError = new()
                    {
                        ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
                        MerchantResolutionAttempted =
                            ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                        DuplicateTransaction = new("x"),
                        IncorrectAmount = new(0),
                        PaidByOtherMeans = new()
                        {
                            OtherFormOfPaymentEvidence =
                                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                            OtherTransactionID = "x",
                        },
                    },
                },
                MerchantPrearbitrationDecline = new(
                    "The pre-arbitration received from the merchantdoes not explain how they obtained permission to charge the card."
                ),
                UserPrearbitration = new()
                {
                    Reason = "x",
                    CategoryChange = new()
                    {
                        Category = CategoryChangeCategory.Authorization,
                        Reason = "x",
                    },
                },
            },
        };

        CardDisputeSubmitUserSubmissionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CardDisputeSubmitUserSubmissionParamsNetworkTest : TestBase
{
    [Theory]
    [InlineData(CardDisputeSubmitUserSubmissionParamsNetwork.Visa)]
    public void Validation_Works(CardDisputeSubmitUserSubmissionParamsNetwork rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardDisputeSubmitUserSubmissionParamsNetwork> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardDisputeSubmitUserSubmissionParamsNetwork>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardDisputeSubmitUserSubmissionParamsNetwork.Visa)]
    public void SerializationRoundtrip_Works(CardDisputeSubmitUserSubmissionParamsNetwork rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardDisputeSubmitUserSubmissionParamsNetwork> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardDisputeSubmitUserSubmissionParamsNetwork>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardDisputeSubmitUserSubmissionParamsNetwork>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardDisputeSubmitUserSubmissionParamsNetwork>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardDisputeSubmitUserSubmissionParamsAttachmentFileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardDisputeSubmitUserSubmissionParamsAttachmentFile { FileID = "file_id" };

        string expectedFileID = "file_id";

        Assert.Equal(expectedFileID, model.FileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardDisputeSubmitUserSubmissionParamsAttachmentFile { FileID = "file_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardDisputeSubmitUserSubmissionParamsAttachmentFile>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardDisputeSubmitUserSubmissionParamsAttachmentFile { FileID = "file_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardDisputeSubmitUserSubmissionParamsAttachmentFile>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedFileID = "file_id";

        Assert.Equal(expectedFileID, deserialized.FileID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardDisputeSubmitUserSubmissionParamsAttachmentFile { FileID = "file_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardDisputeSubmitUserSubmissionParamsAttachmentFile { FileID = "file_id" };

        CardDisputeSubmitUserSubmissionParamsAttachmentFile copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardDisputeSubmitUserSubmissionParamsVisaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardDisputeSubmitUserSubmissionParamsVisa
        {
            Category = CardDisputeSubmitUserSubmissionParamsVisaCategory.Chargeback,
            Chargeback = new()
            {
                Category = ChargebackCategory.Authorization,
                Authorization = new(ChargebackAuthorizationAccountStatus.AccountClosed),
                ConsumerCanceledMerchandise = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                    PurchaseExplanation = "x",
                    ReceivedOrExpectedAt = "2019-12-27",
                    ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                    CardholderCancellation = new()
                    {
                        CanceledAt = "2019-12-27",
                        CanceledPriorToShipDate =
                            ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                        CancellationPolicyProvided =
                            ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                        Reason = "x",
                    },
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerCanceledRecurringTransaction = new()
                {
                    CancellationTarget =
                        ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                    MerchantContactMethods = new()
                    {
                        ApplicationName = "x",
                        CallCenterPhoneNumber = "x",
                        EmailAddress = "x",
                        InPersonAddress = "x",
                        MailingAddress = "x",
                        TextPhoneNumber = "x",
                    },
                    TransactionOrAccountCanceledAt = "2019-12-27",
                    OtherFormOfPaymentExplanation = "x",
                },
                ConsumerCanceledServices = new()
                {
                    CardholderCancellation = new()
                    {
                        CanceledAt = "2019-12-27",
                        CancellationPolicyProvided =
                            ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                        Reason = "x",
                    },
                    ContractedAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                    PurchaseExplanation = "x",
                    ServiceType =
                        ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                    GuaranteedReservation = new(
                        ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                    ),
                    Other = new(),
                    Timeshare = new(),
                },
                ConsumerCounterfeitMerchandise = new()
                {
                    CounterfeitExplanation = "x",
                    DispositionExplanation = "x",
                    OrderExplanation = "x",
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
                        ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                    OrderAndIssueExplanation = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseMisrepresentation = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                    MisrepresentationExplanation = "x",
                    PurchaseExplanation = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseNotAsDescribed = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseNotReceived = new()
                {
                    CancellationOutcome =
                        ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                    DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                    LastExpectedReceiptAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndExplanation = "x",
                    CardholderCancellationPriorToExpectedReceipt = new()
                    {
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    Delayed = new()
                    {
                        Explanation = "x",
                        ReturnOutcome =
                            ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                        NotReturned = new(),
                        ReturnAttempted = new("2019-12-27"),
                        Returned = new()
                        {
                            MerchantReceivedReturnAt = "2019-12-27",
                            ReturnedAt = "2019-12-27",
                        },
                    },
                    DeliveredToWrongLocation = new("x"),
                    MerchantCancellation = new("2019-12-27"),
                    NoCancellation = new(),
                },
                ConsumerNonReceiptOfCash = new(),
                ConsumerOriginalCreditTransactionNotAccepted = new()
                {
                    Explanation = "x",
                    Reason =
                        ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
                },
                ConsumerQualityMerchandise = new()
                {
                    ExpectedAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndQualityIssue = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                    NotReturned = new(),
                    OngoingNegotiations = new()
                    {
                        Explanation = "x",
                        IssuerFirstNotifiedAt = "2019-12-27",
                        StartedAt = "2019-12-27",
                    },
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerQualityServices = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                        ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                    PurchaseInfoAndQualityIssue = "x",
                    ServicesReceivedAt = "2019-12-27",
                    CardholderPaidToHaveWorkRedone =
                        ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                    OngoingNegotiations = new()
                    {
                        Explanation = "x",
                        IssuerFirstNotifiedAt = "2019-12-27",
                        StartedAt = "2019-12-27",
                    },
                    RestaurantFoodRelated =
                        ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
                },
                ConsumerServicesMisrepresentation = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                    MisrepresentationExplanation = "x",
                    PurchaseExplanation = "x",
                    ReceivedAt = "2019-12-27",
                },
                ConsumerServicesNotAsDescribed = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    Explanation = "x",
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                    ReceivedAt = "2019-12-27",
                },
                ConsumerServicesNotReceived = new()
                {
                    CancellationOutcome =
                        ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                    LastExpectedReceiptAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndExplanation = "x",
                    CardholderCancellationPriorToExpectedReceipt = new()
                    {
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    MerchantCancellation = new("2019-12-27"),
                    NoCancellation = new(),
                },
                Fraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover),
                ProcessingError = new()
                {
                    ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
                    MerchantResolutionAttempted =
                        ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                    DuplicateTransaction = new("x"),
                    IncorrectAmount = new(0),
                    PaidByOtherMeans = new()
                    {
                        OtherFormOfPaymentEvidence =
                            ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                        OtherTransactionID = "x",
                    },
                },
            },
            MerchantPrearbitrationDecline = new("x"),
            UserPrearbitration = new()
            {
                Reason = "x",
                CategoryChange = new()
                {
                    Category = CategoryChangeCategory.Authorization,
                    Reason = "x",
                },
            },
        };

        ApiEnum<string, CardDisputeSubmitUserSubmissionParamsVisaCategory> expectedCategory =
            CardDisputeSubmitUserSubmissionParamsVisaCategory.Chargeback;
        Chargeback expectedChargeback = new()
        {
            Category = ChargebackCategory.Authorization,
            Authorization = new(ChargebackAuthorizationAccountStatus.AccountClosed),
            ConsumerCanceledMerchandise = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ReceivedOrExpectedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CanceledPriorToShipDate =
                        ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                    CancellationPolicyProvided =
                        ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerCanceledRecurringTransaction = new()
            {
                CancellationTarget =
                    ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                MerchantContactMethods = new()
                {
                    ApplicationName = "x",
                    CallCenterPhoneNumber = "x",
                    EmailAddress = "x",
                    InPersonAddress = "x",
                    MailingAddress = "x",
                    TextPhoneNumber = "x",
                },
                TransactionOrAccountCanceledAt = "2019-12-27",
                OtherFormOfPaymentExplanation = "x",
            },
            ConsumerCanceledServices = new()
            {
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CancellationPolicyProvided =
                        ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                ContractedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                GuaranteedReservation = new(
                    ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                ),
                Other = new(),
                Timeshare = new(),
            },
            ConsumerCounterfeitMerchandise = new()
            {
                CounterfeitExplanation = "x",
                DispositionExplanation = "x",
                OrderExplanation = "x",
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
                    ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                OrderAndIssueExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseMisrepresentation = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotAsDescribed = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotReceived = new()
            {
                CancellationOutcome =
                    ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Delayed = new()
                {
                    Explanation = "x",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new("2019-12-27"),
                    Returned = new()
                    {
                        MerchantReceivedReturnAt = "2019-12-27",
                        ReturnedAt = "2019-12-27",
                    },
                },
                DeliveredToWrongLocation = new("x"),
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            ConsumerNonReceiptOfCash = new(),
            ConsumerOriginalCreditTransactionNotAccepted = new()
            {
                Explanation = "x",
                Reason =
                    ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
            },
            ConsumerQualityMerchandise = new()
            {
                ExpectedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndQualityIssue = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerQualityServices = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                    ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                PurchaseInfoAndQualityIssue = "x",
                ServicesReceivedAt = "2019-12-27",
                CardholderPaidToHaveWorkRedone =
                    ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                RestaurantFoodRelated =
                    ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
            },
            ConsumerServicesMisrepresentation = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotAsDescribed = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Explanation = "x",
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotReceived = new()
            {
                CancellationOutcome =
                    ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            Fraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover),
            ProcessingError = new()
            {
                ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
                MerchantResolutionAttempted =
                    ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                DuplicateTransaction = new("x"),
                IncorrectAmount = new(0),
                PaidByOtherMeans = new()
                {
                    OtherFormOfPaymentEvidence =
                        ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                    OtherTransactionID = "x",
                },
            },
        };
        MerchantPrearbitrationDecline expectedMerchantPrearbitrationDecline = new("x");
        UserPrearbitration expectedUserPrearbitration = new()
        {
            Reason = "x",
            CategoryChange = new()
            {
                Category = CategoryChangeCategory.Authorization,
                Reason = "x",
            },
        };

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedChargeback, model.Chargeback);
        Assert.Equal(expectedMerchantPrearbitrationDecline, model.MerchantPrearbitrationDecline);
        Assert.Equal(expectedUserPrearbitration, model.UserPrearbitration);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardDisputeSubmitUserSubmissionParamsVisa
        {
            Category = CardDisputeSubmitUserSubmissionParamsVisaCategory.Chargeback,
            Chargeback = new()
            {
                Category = ChargebackCategory.Authorization,
                Authorization = new(ChargebackAuthorizationAccountStatus.AccountClosed),
                ConsumerCanceledMerchandise = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                    PurchaseExplanation = "x",
                    ReceivedOrExpectedAt = "2019-12-27",
                    ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                    CardholderCancellation = new()
                    {
                        CanceledAt = "2019-12-27",
                        CanceledPriorToShipDate =
                            ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                        CancellationPolicyProvided =
                            ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                        Reason = "x",
                    },
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerCanceledRecurringTransaction = new()
                {
                    CancellationTarget =
                        ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                    MerchantContactMethods = new()
                    {
                        ApplicationName = "x",
                        CallCenterPhoneNumber = "x",
                        EmailAddress = "x",
                        InPersonAddress = "x",
                        MailingAddress = "x",
                        TextPhoneNumber = "x",
                    },
                    TransactionOrAccountCanceledAt = "2019-12-27",
                    OtherFormOfPaymentExplanation = "x",
                },
                ConsumerCanceledServices = new()
                {
                    CardholderCancellation = new()
                    {
                        CanceledAt = "2019-12-27",
                        CancellationPolicyProvided =
                            ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                        Reason = "x",
                    },
                    ContractedAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                    PurchaseExplanation = "x",
                    ServiceType =
                        ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                    GuaranteedReservation = new(
                        ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                    ),
                    Other = new(),
                    Timeshare = new(),
                },
                ConsumerCounterfeitMerchandise = new()
                {
                    CounterfeitExplanation = "x",
                    DispositionExplanation = "x",
                    OrderExplanation = "x",
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
                        ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                    OrderAndIssueExplanation = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseMisrepresentation = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                    MisrepresentationExplanation = "x",
                    PurchaseExplanation = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseNotAsDescribed = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseNotReceived = new()
                {
                    CancellationOutcome =
                        ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                    DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                    LastExpectedReceiptAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndExplanation = "x",
                    CardholderCancellationPriorToExpectedReceipt = new()
                    {
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    Delayed = new()
                    {
                        Explanation = "x",
                        ReturnOutcome =
                            ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                        NotReturned = new(),
                        ReturnAttempted = new("2019-12-27"),
                        Returned = new()
                        {
                            MerchantReceivedReturnAt = "2019-12-27",
                            ReturnedAt = "2019-12-27",
                        },
                    },
                    DeliveredToWrongLocation = new("x"),
                    MerchantCancellation = new("2019-12-27"),
                    NoCancellation = new(),
                },
                ConsumerNonReceiptOfCash = new(),
                ConsumerOriginalCreditTransactionNotAccepted = new()
                {
                    Explanation = "x",
                    Reason =
                        ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
                },
                ConsumerQualityMerchandise = new()
                {
                    ExpectedAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndQualityIssue = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                    NotReturned = new(),
                    OngoingNegotiations = new()
                    {
                        Explanation = "x",
                        IssuerFirstNotifiedAt = "2019-12-27",
                        StartedAt = "2019-12-27",
                    },
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerQualityServices = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                        ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                    PurchaseInfoAndQualityIssue = "x",
                    ServicesReceivedAt = "2019-12-27",
                    CardholderPaidToHaveWorkRedone =
                        ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                    OngoingNegotiations = new()
                    {
                        Explanation = "x",
                        IssuerFirstNotifiedAt = "2019-12-27",
                        StartedAt = "2019-12-27",
                    },
                    RestaurantFoodRelated =
                        ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
                },
                ConsumerServicesMisrepresentation = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                    MisrepresentationExplanation = "x",
                    PurchaseExplanation = "x",
                    ReceivedAt = "2019-12-27",
                },
                ConsumerServicesNotAsDescribed = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    Explanation = "x",
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                    ReceivedAt = "2019-12-27",
                },
                ConsumerServicesNotReceived = new()
                {
                    CancellationOutcome =
                        ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                    LastExpectedReceiptAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndExplanation = "x",
                    CardholderCancellationPriorToExpectedReceipt = new()
                    {
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    MerchantCancellation = new("2019-12-27"),
                    NoCancellation = new(),
                },
                Fraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover),
                ProcessingError = new()
                {
                    ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
                    MerchantResolutionAttempted =
                        ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                    DuplicateTransaction = new("x"),
                    IncorrectAmount = new(0),
                    PaidByOtherMeans = new()
                    {
                        OtherFormOfPaymentEvidence =
                            ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                        OtherTransactionID = "x",
                    },
                },
            },
            MerchantPrearbitrationDecline = new("x"),
            UserPrearbitration = new()
            {
                Reason = "x",
                CategoryChange = new()
                {
                    Category = CategoryChangeCategory.Authorization,
                    Reason = "x",
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputeSubmitUserSubmissionParamsVisa>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardDisputeSubmitUserSubmissionParamsVisa
        {
            Category = CardDisputeSubmitUserSubmissionParamsVisaCategory.Chargeback,
            Chargeback = new()
            {
                Category = ChargebackCategory.Authorization,
                Authorization = new(ChargebackAuthorizationAccountStatus.AccountClosed),
                ConsumerCanceledMerchandise = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                    PurchaseExplanation = "x",
                    ReceivedOrExpectedAt = "2019-12-27",
                    ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                    CardholderCancellation = new()
                    {
                        CanceledAt = "2019-12-27",
                        CanceledPriorToShipDate =
                            ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                        CancellationPolicyProvided =
                            ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                        Reason = "x",
                    },
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerCanceledRecurringTransaction = new()
                {
                    CancellationTarget =
                        ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                    MerchantContactMethods = new()
                    {
                        ApplicationName = "x",
                        CallCenterPhoneNumber = "x",
                        EmailAddress = "x",
                        InPersonAddress = "x",
                        MailingAddress = "x",
                        TextPhoneNumber = "x",
                    },
                    TransactionOrAccountCanceledAt = "2019-12-27",
                    OtherFormOfPaymentExplanation = "x",
                },
                ConsumerCanceledServices = new()
                {
                    CardholderCancellation = new()
                    {
                        CanceledAt = "2019-12-27",
                        CancellationPolicyProvided =
                            ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                        Reason = "x",
                    },
                    ContractedAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                    PurchaseExplanation = "x",
                    ServiceType =
                        ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                    GuaranteedReservation = new(
                        ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                    ),
                    Other = new(),
                    Timeshare = new(),
                },
                ConsumerCounterfeitMerchandise = new()
                {
                    CounterfeitExplanation = "x",
                    DispositionExplanation = "x",
                    OrderExplanation = "x",
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
                        ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                    OrderAndIssueExplanation = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseMisrepresentation = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                    MisrepresentationExplanation = "x",
                    PurchaseExplanation = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseNotAsDescribed = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseNotReceived = new()
                {
                    CancellationOutcome =
                        ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                    DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                    LastExpectedReceiptAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndExplanation = "x",
                    CardholderCancellationPriorToExpectedReceipt = new()
                    {
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    Delayed = new()
                    {
                        Explanation = "x",
                        ReturnOutcome =
                            ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                        NotReturned = new(),
                        ReturnAttempted = new("2019-12-27"),
                        Returned = new()
                        {
                            MerchantReceivedReturnAt = "2019-12-27",
                            ReturnedAt = "2019-12-27",
                        },
                    },
                    DeliveredToWrongLocation = new("x"),
                    MerchantCancellation = new("2019-12-27"),
                    NoCancellation = new(),
                },
                ConsumerNonReceiptOfCash = new(),
                ConsumerOriginalCreditTransactionNotAccepted = new()
                {
                    Explanation = "x",
                    Reason =
                        ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
                },
                ConsumerQualityMerchandise = new()
                {
                    ExpectedAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndQualityIssue = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                    NotReturned = new(),
                    OngoingNegotiations = new()
                    {
                        Explanation = "x",
                        IssuerFirstNotifiedAt = "2019-12-27",
                        StartedAt = "2019-12-27",
                    },
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerQualityServices = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                        ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                    PurchaseInfoAndQualityIssue = "x",
                    ServicesReceivedAt = "2019-12-27",
                    CardholderPaidToHaveWorkRedone =
                        ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                    OngoingNegotiations = new()
                    {
                        Explanation = "x",
                        IssuerFirstNotifiedAt = "2019-12-27",
                        StartedAt = "2019-12-27",
                    },
                    RestaurantFoodRelated =
                        ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
                },
                ConsumerServicesMisrepresentation = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                    MisrepresentationExplanation = "x",
                    PurchaseExplanation = "x",
                    ReceivedAt = "2019-12-27",
                },
                ConsumerServicesNotAsDescribed = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    Explanation = "x",
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                    ReceivedAt = "2019-12-27",
                },
                ConsumerServicesNotReceived = new()
                {
                    CancellationOutcome =
                        ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                    LastExpectedReceiptAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndExplanation = "x",
                    CardholderCancellationPriorToExpectedReceipt = new()
                    {
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    MerchantCancellation = new("2019-12-27"),
                    NoCancellation = new(),
                },
                Fraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover),
                ProcessingError = new()
                {
                    ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
                    MerchantResolutionAttempted =
                        ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                    DuplicateTransaction = new("x"),
                    IncorrectAmount = new(0),
                    PaidByOtherMeans = new()
                    {
                        OtherFormOfPaymentEvidence =
                            ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                        OtherTransactionID = "x",
                    },
                },
            },
            MerchantPrearbitrationDecline = new("x"),
            UserPrearbitration = new()
            {
                Reason = "x",
                CategoryChange = new()
                {
                    Category = CategoryChangeCategory.Authorization,
                    Reason = "x",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputeSubmitUserSubmissionParamsVisa>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CardDisputeSubmitUserSubmissionParamsVisaCategory> expectedCategory =
            CardDisputeSubmitUserSubmissionParamsVisaCategory.Chargeback;
        Chargeback expectedChargeback = new()
        {
            Category = ChargebackCategory.Authorization,
            Authorization = new(ChargebackAuthorizationAccountStatus.AccountClosed),
            ConsumerCanceledMerchandise = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ReceivedOrExpectedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CanceledPriorToShipDate =
                        ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                    CancellationPolicyProvided =
                        ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerCanceledRecurringTransaction = new()
            {
                CancellationTarget =
                    ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                MerchantContactMethods = new()
                {
                    ApplicationName = "x",
                    CallCenterPhoneNumber = "x",
                    EmailAddress = "x",
                    InPersonAddress = "x",
                    MailingAddress = "x",
                    TextPhoneNumber = "x",
                },
                TransactionOrAccountCanceledAt = "2019-12-27",
                OtherFormOfPaymentExplanation = "x",
            },
            ConsumerCanceledServices = new()
            {
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CancellationPolicyProvided =
                        ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                ContractedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                GuaranteedReservation = new(
                    ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                ),
                Other = new(),
                Timeshare = new(),
            },
            ConsumerCounterfeitMerchandise = new()
            {
                CounterfeitExplanation = "x",
                DispositionExplanation = "x",
                OrderExplanation = "x",
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
                    ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                OrderAndIssueExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseMisrepresentation = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotAsDescribed = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotReceived = new()
            {
                CancellationOutcome =
                    ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Delayed = new()
                {
                    Explanation = "x",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new("2019-12-27"),
                    Returned = new()
                    {
                        MerchantReceivedReturnAt = "2019-12-27",
                        ReturnedAt = "2019-12-27",
                    },
                },
                DeliveredToWrongLocation = new("x"),
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            ConsumerNonReceiptOfCash = new(),
            ConsumerOriginalCreditTransactionNotAccepted = new()
            {
                Explanation = "x",
                Reason =
                    ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
            },
            ConsumerQualityMerchandise = new()
            {
                ExpectedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndQualityIssue = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerQualityServices = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                    ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                PurchaseInfoAndQualityIssue = "x",
                ServicesReceivedAt = "2019-12-27",
                CardholderPaidToHaveWorkRedone =
                    ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                RestaurantFoodRelated =
                    ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
            },
            ConsumerServicesMisrepresentation = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotAsDescribed = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Explanation = "x",
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotReceived = new()
            {
                CancellationOutcome =
                    ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            Fraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover),
            ProcessingError = new()
            {
                ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
                MerchantResolutionAttempted =
                    ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                DuplicateTransaction = new("x"),
                IncorrectAmount = new(0),
                PaidByOtherMeans = new()
                {
                    OtherFormOfPaymentEvidence =
                        ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                    OtherTransactionID = "x",
                },
            },
        };
        MerchantPrearbitrationDecline expectedMerchantPrearbitrationDecline = new("x");
        UserPrearbitration expectedUserPrearbitration = new()
        {
            Reason = "x",
            CategoryChange = new()
            {
                Category = CategoryChangeCategory.Authorization,
                Reason = "x",
            },
        };

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedChargeback, deserialized.Chargeback);
        Assert.Equal(
            expectedMerchantPrearbitrationDecline,
            deserialized.MerchantPrearbitrationDecline
        );
        Assert.Equal(expectedUserPrearbitration, deserialized.UserPrearbitration);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardDisputeSubmitUserSubmissionParamsVisa
        {
            Category = CardDisputeSubmitUserSubmissionParamsVisaCategory.Chargeback,
            Chargeback = new()
            {
                Category = ChargebackCategory.Authorization,
                Authorization = new(ChargebackAuthorizationAccountStatus.AccountClosed),
                ConsumerCanceledMerchandise = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                    PurchaseExplanation = "x",
                    ReceivedOrExpectedAt = "2019-12-27",
                    ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                    CardholderCancellation = new()
                    {
                        CanceledAt = "2019-12-27",
                        CanceledPriorToShipDate =
                            ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                        CancellationPolicyProvided =
                            ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                        Reason = "x",
                    },
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerCanceledRecurringTransaction = new()
                {
                    CancellationTarget =
                        ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                    MerchantContactMethods = new()
                    {
                        ApplicationName = "x",
                        CallCenterPhoneNumber = "x",
                        EmailAddress = "x",
                        InPersonAddress = "x",
                        MailingAddress = "x",
                        TextPhoneNumber = "x",
                    },
                    TransactionOrAccountCanceledAt = "2019-12-27",
                    OtherFormOfPaymentExplanation = "x",
                },
                ConsumerCanceledServices = new()
                {
                    CardholderCancellation = new()
                    {
                        CanceledAt = "2019-12-27",
                        CancellationPolicyProvided =
                            ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                        Reason = "x",
                    },
                    ContractedAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                    PurchaseExplanation = "x",
                    ServiceType =
                        ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                    GuaranteedReservation = new(
                        ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                    ),
                    Other = new(),
                    Timeshare = new(),
                },
                ConsumerCounterfeitMerchandise = new()
                {
                    CounterfeitExplanation = "x",
                    DispositionExplanation = "x",
                    OrderExplanation = "x",
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
                        ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                    OrderAndIssueExplanation = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseMisrepresentation = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                    MisrepresentationExplanation = "x",
                    PurchaseExplanation = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseNotAsDescribed = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseNotReceived = new()
                {
                    CancellationOutcome =
                        ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                    DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                    LastExpectedReceiptAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndExplanation = "x",
                    CardholderCancellationPriorToExpectedReceipt = new()
                    {
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    Delayed = new()
                    {
                        Explanation = "x",
                        ReturnOutcome =
                            ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                        NotReturned = new(),
                        ReturnAttempted = new("2019-12-27"),
                        Returned = new()
                        {
                            MerchantReceivedReturnAt = "2019-12-27",
                            ReturnedAt = "2019-12-27",
                        },
                    },
                    DeliveredToWrongLocation = new("x"),
                    MerchantCancellation = new("2019-12-27"),
                    NoCancellation = new(),
                },
                ConsumerNonReceiptOfCash = new(),
                ConsumerOriginalCreditTransactionNotAccepted = new()
                {
                    Explanation = "x",
                    Reason =
                        ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
                },
                ConsumerQualityMerchandise = new()
                {
                    ExpectedAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndQualityIssue = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                    NotReturned = new(),
                    OngoingNegotiations = new()
                    {
                        Explanation = "x",
                        IssuerFirstNotifiedAt = "2019-12-27",
                        StartedAt = "2019-12-27",
                    },
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerQualityServices = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                        ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                    PurchaseInfoAndQualityIssue = "x",
                    ServicesReceivedAt = "2019-12-27",
                    CardholderPaidToHaveWorkRedone =
                        ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                    OngoingNegotiations = new()
                    {
                        Explanation = "x",
                        IssuerFirstNotifiedAt = "2019-12-27",
                        StartedAt = "2019-12-27",
                    },
                    RestaurantFoodRelated =
                        ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
                },
                ConsumerServicesMisrepresentation = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                    MisrepresentationExplanation = "x",
                    PurchaseExplanation = "x",
                    ReceivedAt = "2019-12-27",
                },
                ConsumerServicesNotAsDescribed = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    Explanation = "x",
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                    ReceivedAt = "2019-12-27",
                },
                ConsumerServicesNotReceived = new()
                {
                    CancellationOutcome =
                        ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                    LastExpectedReceiptAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndExplanation = "x",
                    CardholderCancellationPriorToExpectedReceipt = new()
                    {
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    MerchantCancellation = new("2019-12-27"),
                    NoCancellation = new(),
                },
                Fraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover),
                ProcessingError = new()
                {
                    ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
                    MerchantResolutionAttempted =
                        ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                    DuplicateTransaction = new("x"),
                    IncorrectAmount = new(0),
                    PaidByOtherMeans = new()
                    {
                        OtherFormOfPaymentEvidence =
                            ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                        OtherTransactionID = "x",
                    },
                },
            },
            MerchantPrearbitrationDecline = new("x"),
            UserPrearbitration = new()
            {
                Reason = "x",
                CategoryChange = new()
                {
                    Category = CategoryChangeCategory.Authorization,
                    Reason = "x",
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CardDisputeSubmitUserSubmissionParamsVisa
        {
            Category = CardDisputeSubmitUserSubmissionParamsVisaCategory.Chargeback,
        };

        Assert.Null(model.Chargeback);
        Assert.False(model.RawData.ContainsKey("chargeback"));
        Assert.Null(model.MerchantPrearbitrationDecline);
        Assert.False(model.RawData.ContainsKey("merchant_prearbitration_decline"));
        Assert.Null(model.UserPrearbitration);
        Assert.False(model.RawData.ContainsKey("user_prearbitration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CardDisputeSubmitUserSubmissionParamsVisa
        {
            Category = CardDisputeSubmitUserSubmissionParamsVisaCategory.Chargeback,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CardDisputeSubmitUserSubmissionParamsVisa
        {
            Category = CardDisputeSubmitUserSubmissionParamsVisaCategory.Chargeback,

            // Null should be interpreted as omitted for these properties
            Chargeback = null,
            MerchantPrearbitrationDecline = null,
            UserPrearbitration = null,
        };

        Assert.Null(model.Chargeback);
        Assert.False(model.RawData.ContainsKey("chargeback"));
        Assert.Null(model.MerchantPrearbitrationDecline);
        Assert.False(model.RawData.ContainsKey("merchant_prearbitration_decline"));
        Assert.Null(model.UserPrearbitration);
        Assert.False(model.RawData.ContainsKey("user_prearbitration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CardDisputeSubmitUserSubmissionParamsVisa
        {
            Category = CardDisputeSubmitUserSubmissionParamsVisaCategory.Chargeback,

            // Null should be interpreted as omitted for these properties
            Chargeback = null,
            MerchantPrearbitrationDecline = null,
            UserPrearbitration = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardDisputeSubmitUserSubmissionParamsVisa
        {
            Category = CardDisputeSubmitUserSubmissionParamsVisaCategory.Chargeback,
            Chargeback = new()
            {
                Category = ChargebackCategory.Authorization,
                Authorization = new(ChargebackAuthorizationAccountStatus.AccountClosed),
                ConsumerCanceledMerchandise = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                    PurchaseExplanation = "x",
                    ReceivedOrExpectedAt = "2019-12-27",
                    ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                    CardholderCancellation = new()
                    {
                        CanceledAt = "2019-12-27",
                        CanceledPriorToShipDate =
                            ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                        CancellationPolicyProvided =
                            ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                        Reason = "x",
                    },
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerCanceledRecurringTransaction = new()
                {
                    CancellationTarget =
                        ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                    MerchantContactMethods = new()
                    {
                        ApplicationName = "x",
                        CallCenterPhoneNumber = "x",
                        EmailAddress = "x",
                        InPersonAddress = "x",
                        MailingAddress = "x",
                        TextPhoneNumber = "x",
                    },
                    TransactionOrAccountCanceledAt = "2019-12-27",
                    OtherFormOfPaymentExplanation = "x",
                },
                ConsumerCanceledServices = new()
                {
                    CardholderCancellation = new()
                    {
                        CanceledAt = "2019-12-27",
                        CancellationPolicyProvided =
                            ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                        Reason = "x",
                    },
                    ContractedAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                    PurchaseExplanation = "x",
                    ServiceType =
                        ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                    GuaranteedReservation = new(
                        ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                    ),
                    Other = new(),
                    Timeshare = new(),
                },
                ConsumerCounterfeitMerchandise = new()
                {
                    CounterfeitExplanation = "x",
                    DispositionExplanation = "x",
                    OrderExplanation = "x",
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
                        ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                    OrderAndIssueExplanation = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseMisrepresentation = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                    MisrepresentationExplanation = "x",
                    PurchaseExplanation = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseNotAsDescribed = new()
                {
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseNotReceived = new()
                {
                    CancellationOutcome =
                        ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                    DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                    LastExpectedReceiptAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndExplanation = "x",
                    CardholderCancellationPriorToExpectedReceipt = new()
                    {
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    Delayed = new()
                    {
                        Explanation = "x",
                        ReturnOutcome =
                            ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                        NotReturned = new(),
                        ReturnAttempted = new("2019-12-27"),
                        Returned = new()
                        {
                            MerchantReceivedReturnAt = "2019-12-27",
                            ReturnedAt = "2019-12-27",
                        },
                    },
                    DeliveredToWrongLocation = new("x"),
                    MerchantCancellation = new("2019-12-27"),
                    NoCancellation = new(),
                },
                ConsumerNonReceiptOfCash = new(),
                ConsumerOriginalCreditTransactionNotAccepted = new()
                {
                    Explanation = "x",
                    Reason =
                        ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
                },
                ConsumerQualityMerchandise = new()
                {
                    ExpectedAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndQualityIssue = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                    NotReturned = new(),
                    OngoingNegotiations = new()
                    {
                        Explanation = "x",
                        IssuerFirstNotifiedAt = "2019-12-27",
                        StartedAt = "2019-12-27",
                    },
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerQualityServices = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                        ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                    PurchaseInfoAndQualityIssue = "x",
                    ServicesReceivedAt = "2019-12-27",
                    CardholderPaidToHaveWorkRedone =
                        ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                    OngoingNegotiations = new()
                    {
                        Explanation = "x",
                        IssuerFirstNotifiedAt = "2019-12-27",
                        StartedAt = "2019-12-27",
                    },
                    RestaurantFoodRelated =
                        ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
                },
                ConsumerServicesMisrepresentation = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                    MisrepresentationExplanation = "x",
                    PurchaseExplanation = "x",
                    ReceivedAt = "2019-12-27",
                },
                ConsumerServicesNotAsDescribed = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    Explanation = "x",
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                    ReceivedAt = "2019-12-27",
                },
                ConsumerServicesNotReceived = new()
                {
                    CancellationOutcome =
                        ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                    LastExpectedReceiptAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndExplanation = "x",
                    CardholderCancellationPriorToExpectedReceipt = new()
                    {
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    MerchantCancellation = new("2019-12-27"),
                    NoCancellation = new(),
                },
                Fraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover),
                ProcessingError = new()
                {
                    ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
                    MerchantResolutionAttempted =
                        ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                    DuplicateTransaction = new("x"),
                    IncorrectAmount = new(0),
                    PaidByOtherMeans = new()
                    {
                        OtherFormOfPaymentEvidence =
                            ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                        OtherTransactionID = "x",
                    },
                },
            },
            MerchantPrearbitrationDecline = new("x"),
            UserPrearbitration = new()
            {
                Reason = "x",
                CategoryChange = new()
                {
                    Category = CategoryChangeCategory.Authorization,
                    Reason = "x",
                },
            },
        };

        CardDisputeSubmitUserSubmissionParamsVisa copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardDisputeSubmitUserSubmissionParamsVisaCategoryTest : TestBase
{
    [Theory]
    [InlineData(CardDisputeSubmitUserSubmissionParamsVisaCategory.Chargeback)]
    [InlineData(CardDisputeSubmitUserSubmissionParamsVisaCategory.MerchantPrearbitrationDecline)]
    [InlineData(CardDisputeSubmitUserSubmissionParamsVisaCategory.UserPrearbitration)]
    public void Validation_Works(CardDisputeSubmitUserSubmissionParamsVisaCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardDisputeSubmitUserSubmissionParamsVisaCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardDisputeSubmitUserSubmissionParamsVisaCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardDisputeSubmitUserSubmissionParamsVisaCategory.Chargeback)]
    [InlineData(CardDisputeSubmitUserSubmissionParamsVisaCategory.MerchantPrearbitrationDecline)]
    [InlineData(CardDisputeSubmitUserSubmissionParamsVisaCategory.UserPrearbitration)]
    public void SerializationRoundtrip_Works(
        CardDisputeSubmitUserSubmissionParamsVisaCategory rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardDisputeSubmitUserSubmissionParamsVisaCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardDisputeSubmitUserSubmissionParamsVisaCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardDisputeSubmitUserSubmissionParamsVisaCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardDisputeSubmitUserSubmissionParamsVisaCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Chargeback
        {
            Category = ChargebackCategory.Authorization,
            Authorization = new(ChargebackAuthorizationAccountStatus.AccountClosed),
            ConsumerCanceledMerchandise = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ReceivedOrExpectedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CanceledPriorToShipDate =
                        ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                    CancellationPolicyProvided =
                        ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerCanceledRecurringTransaction = new()
            {
                CancellationTarget =
                    ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                MerchantContactMethods = new()
                {
                    ApplicationName = "x",
                    CallCenterPhoneNumber = "x",
                    EmailAddress = "x",
                    InPersonAddress = "x",
                    MailingAddress = "x",
                    TextPhoneNumber = "x",
                },
                TransactionOrAccountCanceledAt = "2019-12-27",
                OtherFormOfPaymentExplanation = "x",
            },
            ConsumerCanceledServices = new()
            {
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CancellationPolicyProvided =
                        ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                ContractedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                GuaranteedReservation = new(
                    ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                ),
                Other = new(),
                Timeshare = new(),
            },
            ConsumerCounterfeitMerchandise = new()
            {
                CounterfeitExplanation = "x",
                DispositionExplanation = "x",
                OrderExplanation = "x",
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
                    ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                OrderAndIssueExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseMisrepresentation = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotAsDescribed = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotReceived = new()
            {
                CancellationOutcome =
                    ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Delayed = new()
                {
                    Explanation = "x",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new("2019-12-27"),
                    Returned = new()
                    {
                        MerchantReceivedReturnAt = "2019-12-27",
                        ReturnedAt = "2019-12-27",
                    },
                },
                DeliveredToWrongLocation = new("x"),
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            ConsumerNonReceiptOfCash = new(),
            ConsumerOriginalCreditTransactionNotAccepted = new()
            {
                Explanation = "x",
                Reason =
                    ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
            },
            ConsumerQualityMerchandise = new()
            {
                ExpectedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndQualityIssue = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerQualityServices = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                    ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                PurchaseInfoAndQualityIssue = "x",
                ServicesReceivedAt = "2019-12-27",
                CardholderPaidToHaveWorkRedone =
                    ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                RestaurantFoodRelated =
                    ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
            },
            ConsumerServicesMisrepresentation = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotAsDescribed = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Explanation = "x",
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotReceived = new()
            {
                CancellationOutcome =
                    ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            Fraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover),
            ProcessingError = new()
            {
                ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
                MerchantResolutionAttempted =
                    ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                DuplicateTransaction = new("x"),
                IncorrectAmount = new(0),
                PaidByOtherMeans = new()
                {
                    OtherFormOfPaymentEvidence =
                        ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                    OtherTransactionID = "x",
                },
            },
        };

        ApiEnum<string, ChargebackCategory> expectedCategory = ChargebackCategory.Authorization;
        ChargebackAuthorization expectedAuthorization = new(
            ChargebackAuthorizationAccountStatus.AccountClosed
        );
        ChargebackConsumerCanceledMerchandise expectedConsumerCanceledMerchandise = new()
        {
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CanceledPriorToShipDate =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };
        ChargebackConsumerCanceledRecurringTransaction expectedConsumerCanceledRecurringTransaction =
            new()
            {
                CancellationTarget =
                    ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                MerchantContactMethods = new()
                {
                    ApplicationName = "x",
                    CallCenterPhoneNumber = "x",
                    EmailAddress = "x",
                    InPersonAddress = "x",
                    MailingAddress = "x",
                    TextPhoneNumber = "x",
                },
                TransactionOrAccountCanceledAt = "2019-12-27",
                OtherFormOfPaymentExplanation = "x",
            };
        ChargebackConsumerCanceledServices expectedConsumerCanceledServices = new()
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
            GuaranteedReservation = new(
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
            ),
            Other = new(),
            Timeshare = new(),
        };
        ChargebackConsumerCounterfeitMerchandise expectedConsumerCounterfeitMerchandise = new()
        {
            CounterfeitExplanation = "x",
            DispositionExplanation = "x",
            OrderExplanation = "x",
            ReceivedAt = "2019-12-27",
        };
        ChargebackConsumerCreditNotProcessed expectedConsumerCreditNotProcessed = new()
        {
            CanceledOrReturnedAt = "2019-12-27",
            CreditExpectedAt = "2019-12-27",
        };
        ChargebackConsumerDamagedOrDefectiveMerchandise expectedConsumerDamagedOrDefectiveMerchandise =
            new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                OrderAndIssueExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            };
        ChargebackConsumerMerchandiseMisrepresentation expectedConsumerMerchandiseMisrepresentation =
            new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            };
        ChargebackConsumerMerchandiseNotAsDescribed expectedConsumerMerchandiseNotAsDescribed =
            new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            };
        ChargebackConsumerMerchandiseNotReceived expectedConsumerMerchandiseNotReceived = new()
        {
            CancellationOutcome =
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Delayed = new()
            {
                Explanation = "x",
                ReturnOutcome =
                    ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new("2019-12-27"),
                Returned = new()
                {
                    MerchantReceivedReturnAt = "2019-12-27",
                    ReturnedAt = "2019-12-27",
                },
            },
            DeliveredToWrongLocation = new("x"),
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };
        ChargebackConsumerNonReceiptOfCash expectedConsumerNonReceiptOfCash = new();
        ChargebackConsumerOriginalCreditTransactionNotAccepted expectedConsumerOriginalCreditTransactionNotAccepted =
            new()
            {
                Explanation = "x",
                Reason =
                    ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
            };
        ChargebackConsumerQualityMerchandise expectedConsumerQualityMerchandise = new()
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };
        ChargebackConsumerQualityServices expectedConsumerQualityServices = new()
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
            CardholderPaidToHaveWorkRedone =
                ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            RestaurantFoodRelated =
                ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
        };
        ChargebackConsumerServicesMisrepresentation expectedConsumerServicesMisrepresentation =
            new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
            };
        ChargebackConsumerServicesNotAsDescribed expectedConsumerServicesNotAsDescribed = new()
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Explanation = "x",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
        };
        ChargebackConsumerServicesNotReceived expectedConsumerServicesNotReceived = new()
        {
            CancellationOutcome =
                ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };
        ChargebackFraud expectedFraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover);
        ChargebackProcessingError expectedProcessingError = new()
        {
            ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted =
                ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
            DuplicateTransaction = new("x"),
            IncorrectAmount = new(0),
            PaidByOtherMeans = new()
            {
                OtherFormOfPaymentEvidence =
                    ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                OtherTransactionID = "x",
            },
        };

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedAuthorization, model.Authorization);
        Assert.Equal(expectedConsumerCanceledMerchandise, model.ConsumerCanceledMerchandise);
        Assert.Equal(
            expectedConsumerCanceledRecurringTransaction,
            model.ConsumerCanceledRecurringTransaction
        );
        Assert.Equal(expectedConsumerCanceledServices, model.ConsumerCanceledServices);
        Assert.Equal(expectedConsumerCounterfeitMerchandise, model.ConsumerCounterfeitMerchandise);
        Assert.Equal(expectedConsumerCreditNotProcessed, model.ConsumerCreditNotProcessed);
        Assert.Equal(
            expectedConsumerDamagedOrDefectiveMerchandise,
            model.ConsumerDamagedOrDefectiveMerchandise
        );
        Assert.Equal(
            expectedConsumerMerchandiseMisrepresentation,
            model.ConsumerMerchandiseMisrepresentation
        );
        Assert.Equal(
            expectedConsumerMerchandiseNotAsDescribed,
            model.ConsumerMerchandiseNotAsDescribed
        );
        Assert.Equal(expectedConsumerMerchandiseNotReceived, model.ConsumerMerchandiseNotReceived);
        Assert.Equal(expectedConsumerNonReceiptOfCash, model.ConsumerNonReceiptOfCash);
        Assert.Equal(
            expectedConsumerOriginalCreditTransactionNotAccepted,
            model.ConsumerOriginalCreditTransactionNotAccepted
        );
        Assert.Equal(expectedConsumerQualityMerchandise, model.ConsumerQualityMerchandise);
        Assert.Equal(expectedConsumerQualityServices, model.ConsumerQualityServices);
        Assert.Equal(
            expectedConsumerServicesMisrepresentation,
            model.ConsumerServicesMisrepresentation
        );
        Assert.Equal(expectedConsumerServicesNotAsDescribed, model.ConsumerServicesNotAsDescribed);
        Assert.Equal(expectedConsumerServicesNotReceived, model.ConsumerServicesNotReceived);
        Assert.Equal(expectedFraud, model.Fraud);
        Assert.Equal(expectedProcessingError, model.ProcessingError);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Chargeback
        {
            Category = ChargebackCategory.Authorization,
            Authorization = new(ChargebackAuthorizationAccountStatus.AccountClosed),
            ConsumerCanceledMerchandise = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ReceivedOrExpectedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CanceledPriorToShipDate =
                        ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                    CancellationPolicyProvided =
                        ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerCanceledRecurringTransaction = new()
            {
                CancellationTarget =
                    ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                MerchantContactMethods = new()
                {
                    ApplicationName = "x",
                    CallCenterPhoneNumber = "x",
                    EmailAddress = "x",
                    InPersonAddress = "x",
                    MailingAddress = "x",
                    TextPhoneNumber = "x",
                },
                TransactionOrAccountCanceledAt = "2019-12-27",
                OtherFormOfPaymentExplanation = "x",
            },
            ConsumerCanceledServices = new()
            {
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CancellationPolicyProvided =
                        ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                ContractedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                GuaranteedReservation = new(
                    ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                ),
                Other = new(),
                Timeshare = new(),
            },
            ConsumerCounterfeitMerchandise = new()
            {
                CounterfeitExplanation = "x",
                DispositionExplanation = "x",
                OrderExplanation = "x",
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
                    ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                OrderAndIssueExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseMisrepresentation = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotAsDescribed = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotReceived = new()
            {
                CancellationOutcome =
                    ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Delayed = new()
                {
                    Explanation = "x",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new("2019-12-27"),
                    Returned = new()
                    {
                        MerchantReceivedReturnAt = "2019-12-27",
                        ReturnedAt = "2019-12-27",
                    },
                },
                DeliveredToWrongLocation = new("x"),
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            ConsumerNonReceiptOfCash = new(),
            ConsumerOriginalCreditTransactionNotAccepted = new()
            {
                Explanation = "x",
                Reason =
                    ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
            },
            ConsumerQualityMerchandise = new()
            {
                ExpectedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndQualityIssue = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerQualityServices = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                    ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                PurchaseInfoAndQualityIssue = "x",
                ServicesReceivedAt = "2019-12-27",
                CardholderPaidToHaveWorkRedone =
                    ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                RestaurantFoodRelated =
                    ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
            },
            ConsumerServicesMisrepresentation = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotAsDescribed = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Explanation = "x",
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotReceived = new()
            {
                CancellationOutcome =
                    ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            Fraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover),
            ProcessingError = new()
            {
                ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
                MerchantResolutionAttempted =
                    ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                DuplicateTransaction = new("x"),
                IncorrectAmount = new(0),
                PaidByOtherMeans = new()
                {
                    OtherFormOfPaymentEvidence =
                        ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                    OtherTransactionID = "x",
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Chargeback>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Chargeback
        {
            Category = ChargebackCategory.Authorization,
            Authorization = new(ChargebackAuthorizationAccountStatus.AccountClosed),
            ConsumerCanceledMerchandise = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ReceivedOrExpectedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CanceledPriorToShipDate =
                        ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                    CancellationPolicyProvided =
                        ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerCanceledRecurringTransaction = new()
            {
                CancellationTarget =
                    ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                MerchantContactMethods = new()
                {
                    ApplicationName = "x",
                    CallCenterPhoneNumber = "x",
                    EmailAddress = "x",
                    InPersonAddress = "x",
                    MailingAddress = "x",
                    TextPhoneNumber = "x",
                },
                TransactionOrAccountCanceledAt = "2019-12-27",
                OtherFormOfPaymentExplanation = "x",
            },
            ConsumerCanceledServices = new()
            {
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CancellationPolicyProvided =
                        ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                ContractedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                GuaranteedReservation = new(
                    ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                ),
                Other = new(),
                Timeshare = new(),
            },
            ConsumerCounterfeitMerchandise = new()
            {
                CounterfeitExplanation = "x",
                DispositionExplanation = "x",
                OrderExplanation = "x",
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
                    ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                OrderAndIssueExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseMisrepresentation = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotAsDescribed = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotReceived = new()
            {
                CancellationOutcome =
                    ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Delayed = new()
                {
                    Explanation = "x",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new("2019-12-27"),
                    Returned = new()
                    {
                        MerchantReceivedReturnAt = "2019-12-27",
                        ReturnedAt = "2019-12-27",
                    },
                },
                DeliveredToWrongLocation = new("x"),
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            ConsumerNonReceiptOfCash = new(),
            ConsumerOriginalCreditTransactionNotAccepted = new()
            {
                Explanation = "x",
                Reason =
                    ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
            },
            ConsumerQualityMerchandise = new()
            {
                ExpectedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndQualityIssue = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerQualityServices = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                    ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                PurchaseInfoAndQualityIssue = "x",
                ServicesReceivedAt = "2019-12-27",
                CardholderPaidToHaveWorkRedone =
                    ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                RestaurantFoodRelated =
                    ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
            },
            ConsumerServicesMisrepresentation = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotAsDescribed = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Explanation = "x",
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotReceived = new()
            {
                CancellationOutcome =
                    ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            Fraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover),
            ProcessingError = new()
            {
                ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
                MerchantResolutionAttempted =
                    ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                DuplicateTransaction = new("x"),
                IncorrectAmount = new(0),
                PaidByOtherMeans = new()
                {
                    OtherFormOfPaymentEvidence =
                        ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                    OtherTransactionID = "x",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Chargeback>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ChargebackCategory> expectedCategory = ChargebackCategory.Authorization;
        ChargebackAuthorization expectedAuthorization = new(
            ChargebackAuthorizationAccountStatus.AccountClosed
        );
        ChargebackConsumerCanceledMerchandise expectedConsumerCanceledMerchandise = new()
        {
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CanceledPriorToShipDate =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };
        ChargebackConsumerCanceledRecurringTransaction expectedConsumerCanceledRecurringTransaction =
            new()
            {
                CancellationTarget =
                    ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                MerchantContactMethods = new()
                {
                    ApplicationName = "x",
                    CallCenterPhoneNumber = "x",
                    EmailAddress = "x",
                    InPersonAddress = "x",
                    MailingAddress = "x",
                    TextPhoneNumber = "x",
                },
                TransactionOrAccountCanceledAt = "2019-12-27",
                OtherFormOfPaymentExplanation = "x",
            };
        ChargebackConsumerCanceledServices expectedConsumerCanceledServices = new()
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
            GuaranteedReservation = new(
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
            ),
            Other = new(),
            Timeshare = new(),
        };
        ChargebackConsumerCounterfeitMerchandise expectedConsumerCounterfeitMerchandise = new()
        {
            CounterfeitExplanation = "x",
            DispositionExplanation = "x",
            OrderExplanation = "x",
            ReceivedAt = "2019-12-27",
        };
        ChargebackConsumerCreditNotProcessed expectedConsumerCreditNotProcessed = new()
        {
            CanceledOrReturnedAt = "2019-12-27",
            CreditExpectedAt = "2019-12-27",
        };
        ChargebackConsumerDamagedOrDefectiveMerchandise expectedConsumerDamagedOrDefectiveMerchandise =
            new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                OrderAndIssueExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            };
        ChargebackConsumerMerchandiseMisrepresentation expectedConsumerMerchandiseMisrepresentation =
            new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            };
        ChargebackConsumerMerchandiseNotAsDescribed expectedConsumerMerchandiseNotAsDescribed =
            new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            };
        ChargebackConsumerMerchandiseNotReceived expectedConsumerMerchandiseNotReceived = new()
        {
            CancellationOutcome =
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Delayed = new()
            {
                Explanation = "x",
                ReturnOutcome =
                    ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new("2019-12-27"),
                Returned = new()
                {
                    MerchantReceivedReturnAt = "2019-12-27",
                    ReturnedAt = "2019-12-27",
                },
            },
            DeliveredToWrongLocation = new("x"),
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };
        ChargebackConsumerNonReceiptOfCash expectedConsumerNonReceiptOfCash = new();
        ChargebackConsumerOriginalCreditTransactionNotAccepted expectedConsumerOriginalCreditTransactionNotAccepted =
            new()
            {
                Explanation = "x",
                Reason =
                    ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
            };
        ChargebackConsumerQualityMerchandise expectedConsumerQualityMerchandise = new()
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };
        ChargebackConsumerQualityServices expectedConsumerQualityServices = new()
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
            CardholderPaidToHaveWorkRedone =
                ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            RestaurantFoodRelated =
                ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
        };
        ChargebackConsumerServicesMisrepresentation expectedConsumerServicesMisrepresentation =
            new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
            };
        ChargebackConsumerServicesNotAsDescribed expectedConsumerServicesNotAsDescribed = new()
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Explanation = "x",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
        };
        ChargebackConsumerServicesNotReceived expectedConsumerServicesNotReceived = new()
        {
            CancellationOutcome =
                ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };
        ChargebackFraud expectedFraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover);
        ChargebackProcessingError expectedProcessingError = new()
        {
            ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted =
                ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
            DuplicateTransaction = new("x"),
            IncorrectAmount = new(0),
            PaidByOtherMeans = new()
            {
                OtherFormOfPaymentEvidence =
                    ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                OtherTransactionID = "x",
            },
        };

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedAuthorization, deserialized.Authorization);
        Assert.Equal(expectedConsumerCanceledMerchandise, deserialized.ConsumerCanceledMerchandise);
        Assert.Equal(
            expectedConsumerCanceledRecurringTransaction,
            deserialized.ConsumerCanceledRecurringTransaction
        );
        Assert.Equal(expectedConsumerCanceledServices, deserialized.ConsumerCanceledServices);
        Assert.Equal(
            expectedConsumerCounterfeitMerchandise,
            deserialized.ConsumerCounterfeitMerchandise
        );
        Assert.Equal(expectedConsumerCreditNotProcessed, deserialized.ConsumerCreditNotProcessed);
        Assert.Equal(
            expectedConsumerDamagedOrDefectiveMerchandise,
            deserialized.ConsumerDamagedOrDefectiveMerchandise
        );
        Assert.Equal(
            expectedConsumerMerchandiseMisrepresentation,
            deserialized.ConsumerMerchandiseMisrepresentation
        );
        Assert.Equal(
            expectedConsumerMerchandiseNotAsDescribed,
            deserialized.ConsumerMerchandiseNotAsDescribed
        );
        Assert.Equal(
            expectedConsumerMerchandiseNotReceived,
            deserialized.ConsumerMerchandiseNotReceived
        );
        Assert.Equal(expectedConsumerNonReceiptOfCash, deserialized.ConsumerNonReceiptOfCash);
        Assert.Equal(
            expectedConsumerOriginalCreditTransactionNotAccepted,
            deserialized.ConsumerOriginalCreditTransactionNotAccepted
        );
        Assert.Equal(expectedConsumerQualityMerchandise, deserialized.ConsumerQualityMerchandise);
        Assert.Equal(expectedConsumerQualityServices, deserialized.ConsumerQualityServices);
        Assert.Equal(
            expectedConsumerServicesMisrepresentation,
            deserialized.ConsumerServicesMisrepresentation
        );
        Assert.Equal(
            expectedConsumerServicesNotAsDescribed,
            deserialized.ConsumerServicesNotAsDescribed
        );
        Assert.Equal(expectedConsumerServicesNotReceived, deserialized.ConsumerServicesNotReceived);
        Assert.Equal(expectedFraud, deserialized.Fraud);
        Assert.Equal(expectedProcessingError, deserialized.ProcessingError);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Chargeback
        {
            Category = ChargebackCategory.Authorization,
            Authorization = new(ChargebackAuthorizationAccountStatus.AccountClosed),
            ConsumerCanceledMerchandise = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ReceivedOrExpectedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CanceledPriorToShipDate =
                        ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                    CancellationPolicyProvided =
                        ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerCanceledRecurringTransaction = new()
            {
                CancellationTarget =
                    ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                MerchantContactMethods = new()
                {
                    ApplicationName = "x",
                    CallCenterPhoneNumber = "x",
                    EmailAddress = "x",
                    InPersonAddress = "x",
                    MailingAddress = "x",
                    TextPhoneNumber = "x",
                },
                TransactionOrAccountCanceledAt = "2019-12-27",
                OtherFormOfPaymentExplanation = "x",
            },
            ConsumerCanceledServices = new()
            {
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CancellationPolicyProvided =
                        ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                ContractedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                GuaranteedReservation = new(
                    ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                ),
                Other = new(),
                Timeshare = new(),
            },
            ConsumerCounterfeitMerchandise = new()
            {
                CounterfeitExplanation = "x",
                DispositionExplanation = "x",
                OrderExplanation = "x",
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
                    ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                OrderAndIssueExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseMisrepresentation = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotAsDescribed = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotReceived = new()
            {
                CancellationOutcome =
                    ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Delayed = new()
                {
                    Explanation = "x",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new("2019-12-27"),
                    Returned = new()
                    {
                        MerchantReceivedReturnAt = "2019-12-27",
                        ReturnedAt = "2019-12-27",
                    },
                },
                DeliveredToWrongLocation = new("x"),
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            ConsumerNonReceiptOfCash = new(),
            ConsumerOriginalCreditTransactionNotAccepted = new()
            {
                Explanation = "x",
                Reason =
                    ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
            },
            ConsumerQualityMerchandise = new()
            {
                ExpectedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndQualityIssue = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerQualityServices = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                    ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                PurchaseInfoAndQualityIssue = "x",
                ServicesReceivedAt = "2019-12-27",
                CardholderPaidToHaveWorkRedone =
                    ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                RestaurantFoodRelated =
                    ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
            },
            ConsumerServicesMisrepresentation = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotAsDescribed = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Explanation = "x",
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotReceived = new()
            {
                CancellationOutcome =
                    ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            Fraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover),
            ProcessingError = new()
            {
                ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
                MerchantResolutionAttempted =
                    ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                DuplicateTransaction = new("x"),
                IncorrectAmount = new(0),
                PaidByOtherMeans = new()
                {
                    OtherFormOfPaymentEvidence =
                        ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                    OtherTransactionID = "x",
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Chargeback { Category = ChargebackCategory.Authorization };

        Assert.Null(model.Authorization);
        Assert.False(model.RawData.ContainsKey("authorization"));
        Assert.Null(model.ConsumerCanceledMerchandise);
        Assert.False(model.RawData.ContainsKey("consumer_canceled_merchandise"));
        Assert.Null(model.ConsumerCanceledRecurringTransaction);
        Assert.False(model.RawData.ContainsKey("consumer_canceled_recurring_transaction"));
        Assert.Null(model.ConsumerCanceledServices);
        Assert.False(model.RawData.ContainsKey("consumer_canceled_services"));
        Assert.Null(model.ConsumerCounterfeitMerchandise);
        Assert.False(model.RawData.ContainsKey("consumer_counterfeit_merchandise"));
        Assert.Null(model.ConsumerCreditNotProcessed);
        Assert.False(model.RawData.ContainsKey("consumer_credit_not_processed"));
        Assert.Null(model.ConsumerDamagedOrDefectiveMerchandise);
        Assert.False(model.RawData.ContainsKey("consumer_damaged_or_defective_merchandise"));
        Assert.Null(model.ConsumerMerchandiseMisrepresentation);
        Assert.False(model.RawData.ContainsKey("consumer_merchandise_misrepresentation"));
        Assert.Null(model.ConsumerMerchandiseNotAsDescribed);
        Assert.False(model.RawData.ContainsKey("consumer_merchandise_not_as_described"));
        Assert.Null(model.ConsumerMerchandiseNotReceived);
        Assert.False(model.RawData.ContainsKey("consumer_merchandise_not_received"));
        Assert.Null(model.ConsumerNonReceiptOfCash);
        Assert.False(model.RawData.ContainsKey("consumer_non_receipt_of_cash"));
        Assert.Null(model.ConsumerOriginalCreditTransactionNotAccepted);
        Assert.False(
            model.RawData.ContainsKey("consumer_original_credit_transaction_not_accepted")
        );
        Assert.Null(model.ConsumerQualityMerchandise);
        Assert.False(model.RawData.ContainsKey("consumer_quality_merchandise"));
        Assert.Null(model.ConsumerQualityServices);
        Assert.False(model.RawData.ContainsKey("consumer_quality_services"));
        Assert.Null(model.ConsumerServicesMisrepresentation);
        Assert.False(model.RawData.ContainsKey("consumer_services_misrepresentation"));
        Assert.Null(model.ConsumerServicesNotAsDescribed);
        Assert.False(model.RawData.ContainsKey("consumer_services_not_as_described"));
        Assert.Null(model.ConsumerServicesNotReceived);
        Assert.False(model.RawData.ContainsKey("consumer_services_not_received"));
        Assert.Null(model.Fraud);
        Assert.False(model.RawData.ContainsKey("fraud"));
        Assert.Null(model.ProcessingError);
        Assert.False(model.RawData.ContainsKey("processing_error"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Chargeback { Category = ChargebackCategory.Authorization };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Chargeback
        {
            Category = ChargebackCategory.Authorization,

            // Null should be interpreted as omitted for these properties
            Authorization = null,
            ConsumerCanceledMerchandise = null,
            ConsumerCanceledRecurringTransaction = null,
            ConsumerCanceledServices = null,
            ConsumerCounterfeitMerchandise = null,
            ConsumerCreditNotProcessed = null,
            ConsumerDamagedOrDefectiveMerchandise = null,
            ConsumerMerchandiseMisrepresentation = null,
            ConsumerMerchandiseNotAsDescribed = null,
            ConsumerMerchandiseNotReceived = null,
            ConsumerNonReceiptOfCash = null,
            ConsumerOriginalCreditTransactionNotAccepted = null,
            ConsumerQualityMerchandise = null,
            ConsumerQualityServices = null,
            ConsumerServicesMisrepresentation = null,
            ConsumerServicesNotAsDescribed = null,
            ConsumerServicesNotReceived = null,
            Fraud = null,
            ProcessingError = null,
        };

        Assert.Null(model.Authorization);
        Assert.False(model.RawData.ContainsKey("authorization"));
        Assert.Null(model.ConsumerCanceledMerchandise);
        Assert.False(model.RawData.ContainsKey("consumer_canceled_merchandise"));
        Assert.Null(model.ConsumerCanceledRecurringTransaction);
        Assert.False(model.RawData.ContainsKey("consumer_canceled_recurring_transaction"));
        Assert.Null(model.ConsumerCanceledServices);
        Assert.False(model.RawData.ContainsKey("consumer_canceled_services"));
        Assert.Null(model.ConsumerCounterfeitMerchandise);
        Assert.False(model.RawData.ContainsKey("consumer_counterfeit_merchandise"));
        Assert.Null(model.ConsumerCreditNotProcessed);
        Assert.False(model.RawData.ContainsKey("consumer_credit_not_processed"));
        Assert.Null(model.ConsumerDamagedOrDefectiveMerchandise);
        Assert.False(model.RawData.ContainsKey("consumer_damaged_or_defective_merchandise"));
        Assert.Null(model.ConsumerMerchandiseMisrepresentation);
        Assert.False(model.RawData.ContainsKey("consumer_merchandise_misrepresentation"));
        Assert.Null(model.ConsumerMerchandiseNotAsDescribed);
        Assert.False(model.RawData.ContainsKey("consumer_merchandise_not_as_described"));
        Assert.Null(model.ConsumerMerchandiseNotReceived);
        Assert.False(model.RawData.ContainsKey("consumer_merchandise_not_received"));
        Assert.Null(model.ConsumerNonReceiptOfCash);
        Assert.False(model.RawData.ContainsKey("consumer_non_receipt_of_cash"));
        Assert.Null(model.ConsumerOriginalCreditTransactionNotAccepted);
        Assert.False(
            model.RawData.ContainsKey("consumer_original_credit_transaction_not_accepted")
        );
        Assert.Null(model.ConsumerQualityMerchandise);
        Assert.False(model.RawData.ContainsKey("consumer_quality_merchandise"));
        Assert.Null(model.ConsumerQualityServices);
        Assert.False(model.RawData.ContainsKey("consumer_quality_services"));
        Assert.Null(model.ConsumerServicesMisrepresentation);
        Assert.False(model.RawData.ContainsKey("consumer_services_misrepresentation"));
        Assert.Null(model.ConsumerServicesNotAsDescribed);
        Assert.False(model.RawData.ContainsKey("consumer_services_not_as_described"));
        Assert.Null(model.ConsumerServicesNotReceived);
        Assert.False(model.RawData.ContainsKey("consumer_services_not_received"));
        Assert.Null(model.Fraud);
        Assert.False(model.RawData.ContainsKey("fraud"));
        Assert.Null(model.ProcessingError);
        Assert.False(model.RawData.ContainsKey("processing_error"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Chargeback
        {
            Category = ChargebackCategory.Authorization,

            // Null should be interpreted as omitted for these properties
            Authorization = null,
            ConsumerCanceledMerchandise = null,
            ConsumerCanceledRecurringTransaction = null,
            ConsumerCanceledServices = null,
            ConsumerCounterfeitMerchandise = null,
            ConsumerCreditNotProcessed = null,
            ConsumerDamagedOrDefectiveMerchandise = null,
            ConsumerMerchandiseMisrepresentation = null,
            ConsumerMerchandiseNotAsDescribed = null,
            ConsumerMerchandiseNotReceived = null,
            ConsumerNonReceiptOfCash = null,
            ConsumerOriginalCreditTransactionNotAccepted = null,
            ConsumerQualityMerchandise = null,
            ConsumerQualityServices = null,
            ConsumerServicesMisrepresentation = null,
            ConsumerServicesNotAsDescribed = null,
            ConsumerServicesNotReceived = null,
            Fraud = null,
            ProcessingError = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Chargeback
        {
            Category = ChargebackCategory.Authorization,
            Authorization = new(ChargebackAuthorizationAccountStatus.AccountClosed),
            ConsumerCanceledMerchandise = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ReceivedOrExpectedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CanceledPriorToShipDate =
                        ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                    CancellationPolicyProvided =
                        ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerCanceledRecurringTransaction = new()
            {
                CancellationTarget =
                    ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
                MerchantContactMethods = new()
                {
                    ApplicationName = "x",
                    CallCenterPhoneNumber = "x",
                    EmailAddress = "x",
                    InPersonAddress = "x",
                    MailingAddress = "x",
                    TextPhoneNumber = "x",
                },
                TransactionOrAccountCanceledAt = "2019-12-27",
                OtherFormOfPaymentExplanation = "x",
            },
            ConsumerCanceledServices = new()
            {
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CancellationPolicyProvided =
                        ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                ContractedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
                GuaranteedReservation = new(
                    ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
                ),
                Other = new(),
                Timeshare = new(),
            },
            ConsumerCounterfeitMerchandise = new()
            {
                CounterfeitExplanation = "x",
                DispositionExplanation = "x",
                OrderExplanation = "x",
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
                    ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                OrderAndIssueExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseMisrepresentation = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome =
                    ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotAsDescribed = new()
            {
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod =
                        ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotReceived = new()
            {
                CancellationOutcome =
                    ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Delayed = new()
                {
                    Explanation = "x",
                    ReturnOutcome =
                        ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new("2019-12-27"),
                    Returned = new()
                    {
                        MerchantReceivedReturnAt = "2019-12-27",
                        ReturnedAt = "2019-12-27",
                    },
                },
                DeliveredToWrongLocation = new("x"),
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            ConsumerNonReceiptOfCash = new(),
            ConsumerOriginalCreditTransactionNotAccepted = new()
            {
                Explanation = "x",
                Reason =
                    ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
            },
            ConsumerQualityMerchandise = new()
            {
                ExpectedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndQualityIssue = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerQualityServices = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                    ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                PurchaseInfoAndQualityIssue = "x",
                ServicesReceivedAt = "2019-12-27",
                CardholderPaidToHaveWorkRedone =
                    ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                RestaurantFoodRelated =
                    ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
            },
            ConsumerServicesMisrepresentation = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotAsDescribed = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Explanation = "x",
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotReceived = new()
            {
                CancellationOutcome =
                    ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            Fraud = new(ChargebackFraudFraudType.AccountOrCredentialsTakeover),
            ProcessingError = new()
            {
                ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
                MerchantResolutionAttempted =
                    ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
                DuplicateTransaction = new("x"),
                IncorrectAmount = new(0),
                PaidByOtherMeans = new()
                {
                    OtherFormOfPaymentEvidence =
                        ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                    OtherTransactionID = "x",
                },
            },
        };

        Chargeback copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackCategoryTest : TestBase
{
    [Theory]
    [InlineData(ChargebackCategory.Authorization)]
    [InlineData(ChargebackCategory.ConsumerCanceledMerchandise)]
    [InlineData(ChargebackCategory.ConsumerCanceledRecurringTransaction)]
    [InlineData(ChargebackCategory.ConsumerCanceledServices)]
    [InlineData(ChargebackCategory.ConsumerCounterfeitMerchandise)]
    [InlineData(ChargebackCategory.ConsumerCreditNotProcessed)]
    [InlineData(ChargebackCategory.ConsumerDamagedOrDefectiveMerchandise)]
    [InlineData(ChargebackCategory.ConsumerMerchandiseMisrepresentation)]
    [InlineData(ChargebackCategory.ConsumerMerchandiseNotAsDescribed)]
    [InlineData(ChargebackCategory.ConsumerMerchandiseNotReceived)]
    [InlineData(ChargebackCategory.ConsumerNonReceiptOfCash)]
    [InlineData(ChargebackCategory.ConsumerOriginalCreditTransactionNotAccepted)]
    [InlineData(ChargebackCategory.ConsumerQualityMerchandise)]
    [InlineData(ChargebackCategory.ConsumerQualityServices)]
    [InlineData(ChargebackCategory.ConsumerServicesMisrepresentation)]
    [InlineData(ChargebackCategory.ConsumerServicesNotAsDescribed)]
    [InlineData(ChargebackCategory.ConsumerServicesNotReceived)]
    [InlineData(ChargebackCategory.Fraud)]
    [InlineData(ChargebackCategory.ProcessingError)]
    public void Validation_Works(ChargebackCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargebackCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackCategory.Authorization)]
    [InlineData(ChargebackCategory.ConsumerCanceledMerchandise)]
    [InlineData(ChargebackCategory.ConsumerCanceledRecurringTransaction)]
    [InlineData(ChargebackCategory.ConsumerCanceledServices)]
    [InlineData(ChargebackCategory.ConsumerCounterfeitMerchandise)]
    [InlineData(ChargebackCategory.ConsumerCreditNotProcessed)]
    [InlineData(ChargebackCategory.ConsumerDamagedOrDefectiveMerchandise)]
    [InlineData(ChargebackCategory.ConsumerMerchandiseMisrepresentation)]
    [InlineData(ChargebackCategory.ConsumerMerchandiseNotAsDescribed)]
    [InlineData(ChargebackCategory.ConsumerMerchandiseNotReceived)]
    [InlineData(ChargebackCategory.ConsumerNonReceiptOfCash)]
    [InlineData(ChargebackCategory.ConsumerOriginalCreditTransactionNotAccepted)]
    [InlineData(ChargebackCategory.ConsumerQualityMerchandise)]
    [InlineData(ChargebackCategory.ConsumerQualityServices)]
    [InlineData(ChargebackCategory.ConsumerServicesMisrepresentation)]
    [InlineData(ChargebackCategory.ConsumerServicesNotAsDescribed)]
    [InlineData(ChargebackCategory.ConsumerServicesNotReceived)]
    [InlineData(ChargebackCategory.Fraud)]
    [InlineData(ChargebackCategory.ProcessingError)]
    public void SerializationRoundtrip_Works(ChargebackCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargebackCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargebackCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargebackCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackAuthorizationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackAuthorization
        {
            AccountStatus = ChargebackAuthorizationAccountStatus.AccountClosed,
        };

        ApiEnum<string, ChargebackAuthorizationAccountStatus> expectedAccountStatus =
            ChargebackAuthorizationAccountStatus.AccountClosed;

        Assert.Equal(expectedAccountStatus, model.AccountStatus);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackAuthorization
        {
            AccountStatus = ChargebackAuthorizationAccountStatus.AccountClosed,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackAuthorization>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackAuthorization
        {
            AccountStatus = ChargebackAuthorizationAccountStatus.AccountClosed,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackAuthorization>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ChargebackAuthorizationAccountStatus> expectedAccountStatus =
            ChargebackAuthorizationAccountStatus.AccountClosed;

        Assert.Equal(expectedAccountStatus, deserialized.AccountStatus);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackAuthorization
        {
            AccountStatus = ChargebackAuthorizationAccountStatus.AccountClosed,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackAuthorization
        {
            AccountStatus = ChargebackAuthorizationAccountStatus.AccountClosed,
        };

        ChargebackAuthorization copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackAuthorizationAccountStatusTest : TestBase
{
    [Theory]
    [InlineData(ChargebackAuthorizationAccountStatus.AccountClosed)]
    [InlineData(ChargebackAuthorizationAccountStatus.CreditProblem)]
    [InlineData(ChargebackAuthorizationAccountStatus.Fraud)]
    public void Validation_Works(ChargebackAuthorizationAccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackAuthorizationAccountStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackAuthorizationAccountStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackAuthorizationAccountStatus.AccountClosed)]
    [InlineData(ChargebackAuthorizationAccountStatus.CreditProblem)]
    [InlineData(ChargebackAuthorizationAccountStatus.Fraud)]
    public void SerializationRoundtrip_Works(ChargebackAuthorizationAccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackAuthorizationAccountStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackAuthorizationAccountStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackAuthorizationAccountStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackAuthorizationAccountStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerCanceledMerchandiseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CanceledPriorToShipDate =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ApiEnum<
            string,
            ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted;
        string expectedPurchaseExplanation = "x";
        string expectedReceivedOrExpectedAt = "2019-12-27";
        ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnOutcome> expectedReturnOutcome =
            ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned;
        ChargebackConsumerCanceledMerchandiseCardholderCancellation expectedCardholderCancellation =
            new()
            {
                CanceledAt = "2019-12-27",
                CanceledPriorToShipDate =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            };
        ChargebackConsumerCanceledMerchandiseNotReturned expectedNotReturned = new();
        ChargebackConsumerCanceledMerchandiseReturnAttempted expectedReturnAttempted = new()
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };
        ChargebackConsumerCanceledMerchandiseReturned expectedReturned = new()
        {
            ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        Assert.Equal(expectedMerchantResolutionAttempted, model.MerchantResolutionAttempted);
        Assert.Equal(expectedPurchaseExplanation, model.PurchaseExplanation);
        Assert.Equal(expectedReceivedOrExpectedAt, model.ReceivedOrExpectedAt);
        Assert.Equal(expectedReturnOutcome, model.ReturnOutcome);
        Assert.Equal(expectedCardholderCancellation, model.CardholderCancellation);
        Assert.Equal(expectedNotReturned, model.NotReturned);
        Assert.Equal(expectedReturnAttempted, model.ReturnAttempted);
        Assert.Equal(expectedReturned, model.Returned);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CanceledPriorToShipDate =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerCanceledMerchandise>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CanceledPriorToShipDate =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerCanceledMerchandise>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted;
        string expectedPurchaseExplanation = "x";
        string expectedReceivedOrExpectedAt = "2019-12-27";
        ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnOutcome> expectedReturnOutcome =
            ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned;
        ChargebackConsumerCanceledMerchandiseCardholderCancellation expectedCardholderCancellation =
            new()
            {
                CanceledAt = "2019-12-27",
                CanceledPriorToShipDate =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            };
        ChargebackConsumerCanceledMerchandiseNotReturned expectedNotReturned = new();
        ChargebackConsumerCanceledMerchandiseReturnAttempted expectedReturnAttempted = new()
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };
        ChargebackConsumerCanceledMerchandiseReturned expectedReturned = new()
        {
            ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        Assert.Equal(expectedMerchantResolutionAttempted, deserialized.MerchantResolutionAttempted);
        Assert.Equal(expectedPurchaseExplanation, deserialized.PurchaseExplanation);
        Assert.Equal(expectedReceivedOrExpectedAt, deserialized.ReceivedOrExpectedAt);
        Assert.Equal(expectedReturnOutcome, deserialized.ReturnOutcome);
        Assert.Equal(expectedCardholderCancellation, deserialized.CardholderCancellation);
        Assert.Equal(expectedNotReturned, deserialized.NotReturned);
        Assert.Equal(expectedReturnAttempted, deserialized.ReturnAttempted);
        Assert.Equal(expectedReturned, deserialized.Returned);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CanceledPriorToShipDate =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
        };

        Assert.Null(model.CardholderCancellation);
        Assert.False(model.RawData.ContainsKey("cardholder_cancellation"));
        Assert.Null(model.NotReturned);
        Assert.False(model.RawData.ContainsKey("not_returned"));
        Assert.Null(model.ReturnAttempted);
        Assert.False(model.RawData.ContainsKey("return_attempted"));
        Assert.Null(model.Returned);
        Assert.False(model.RawData.ContainsKey("returned"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,

            // Null should be interpreted as omitted for these properties
            CardholderCancellation = null,
            NotReturned = null,
            ReturnAttempted = null,
            Returned = null,
        };

        Assert.Null(model.CardholderCancellation);
        Assert.False(model.RawData.ContainsKey("cardholder_cancellation"));
        Assert.Null(model.NotReturned);
        Assert.False(model.RawData.ContainsKey("not_returned"));
        Assert.Null(model.ReturnAttempted);
        Assert.False(model.RawData.ContainsKey("return_attempted"));
        Assert.Null(model.Returned);
        Assert.False(model.RawData.ContainsKey("returned"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,

            // Null should be interpreted as omitted for these properties
            CardholderCancellation = null,
            NotReturned = null,
            ReturnAttempted = null,
            Returned = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned,
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CanceledPriorToShipDate =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ChargebackConsumerCanceledMerchandise copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerCanceledMerchandiseMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void Validation_Works(
        ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledMerchandiseMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerCanceledMerchandiseReturnOutcomeTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned)]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnOutcome.Returned)]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnOutcome.ReturnAttempted)]
    public void Validation_Works(ChargebackConsumerCanceledMerchandiseReturnOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnOutcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnOutcome.NotReturned)]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnOutcome.Returned)]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnOutcome.ReturnAttempted)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerCanceledMerchandiseReturnOutcome rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnOutcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerCanceledMerchandiseCardholderCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseCardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CanceledPriorToShipDate =
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
            CancellationPolicyProvided =
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        string expectedCanceledAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate
        > expectedCanceledPriorToShipDate =
            ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate;
        ApiEnum<
            string,
            ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided
        > expectedCancellationPolicyProvided =
            ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided;
        string expectedReason = "x";

        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Equal(expectedCanceledPriorToShipDate, model.CanceledPriorToShipDate);
        Assert.Equal(expectedCancellationPolicyProvided, model.CancellationPolicyProvided);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseCardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CanceledPriorToShipDate =
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
            CancellationPolicyProvided =
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerCanceledMerchandiseCardholderCancellation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseCardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CanceledPriorToShipDate =
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
            CancellationPolicyProvided =
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerCanceledMerchandiseCardholderCancellation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCanceledAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate
        > expectedCanceledPriorToShipDate =
            ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate;
        ApiEnum<
            string,
            ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided
        > expectedCancellationPolicyProvided =
            ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided;
        string expectedReason = "x";

        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Equal(expectedCanceledPriorToShipDate, deserialized.CanceledPriorToShipDate);
        Assert.Equal(expectedCancellationPolicyProvided, deserialized.CancellationPolicyProvided);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseCardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CanceledPriorToShipDate =
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
            CancellationPolicyProvided =
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseCardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CanceledPriorToShipDate =
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate,
            CancellationPolicyProvided =
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        ChargebackConsumerCanceledMerchandiseCardholderCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDateTest
    : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate
    )]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.NotCanceledPriorToShipDate
    )]
    public void Validation_Works(
        ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.CanceledPriorToShipDate
    )]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate.NotCanceledPriorToShipDate
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCanceledPriorToShipDate
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvidedTest
    : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided
    )]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.Provided
    )]
    public void Validation_Works(
        ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.NotProvided
    )]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided.Provided
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerCanceledMerchandiseCardholderCancellationCancellationPolicyProvided
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerCanceledMerchandiseNotReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseNotReturned { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseNotReturned { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerCanceledMerchandiseNotReturned>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseNotReturned { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerCanceledMerchandiseNotReturned>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseNotReturned { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseNotReturned { };

        ChargebackConsumerCanceledMerchandiseNotReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerCanceledMerchandiseReturnAttemptedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding;
        string expectedAttemptedAt = "2019-12-27";
        string expectedMerchandiseDisposition = "x";

        Assert.Equal(expectedAttemptExplanation, model.AttemptExplanation);
        Assert.Equal(expectedAttemptReason, model.AttemptReason);
        Assert.Equal(expectedAttemptedAt, model.AttemptedAt);
        Assert.Equal(expectedMerchandiseDisposition, model.MerchandiseDisposition);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerCanceledMerchandiseReturnAttempted>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerCanceledMerchandiseReturnAttempted>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding;
        string expectedAttemptedAt = "2019-12-27";
        string expectedMerchandiseDisposition = "x";

        Assert.Equal(expectedAttemptExplanation, deserialized.AttemptExplanation);
        Assert.Equal(expectedAttemptReason, deserialized.AttemptReason);
        Assert.Equal(expectedAttemptedAt, deserialized.AttemptedAt);
        Assert.Equal(expectedMerchandiseDisposition, deserialized.MerchandiseDisposition);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        ChargebackConsumerCanceledMerchandiseReturnAttempted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReasonTest : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding
    )]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions
    )]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn
    )]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted
    )]
    public void Validation_Works(
        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding
    )]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions
    )]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn
    )]
    [InlineData(
        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnAttemptedAttemptReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerCanceledMerchandiseReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ApiEnum<
            string,
            ChargebackConsumerCanceledMerchandiseReturnedReturnMethod
        > expectedReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl;
        string expectedReturnedAt = "2019-12-27";
        string expectedMerchantReceivedReturnAt = "2019-12-27";
        string expectedOtherExplanation = "x";
        string expectedTrackingNumber = "x";

        Assert.Equal(expectedReturnMethod, model.ReturnMethod);
        Assert.Equal(expectedReturnedAt, model.ReturnedAt);
        Assert.Equal(expectedMerchantReceivedReturnAt, model.MerchantReceivedReturnAt);
        Assert.Equal(expectedOtherExplanation, model.OtherExplanation);
        Assert.Equal(expectedTrackingNumber, model.TrackingNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerCanceledMerchandiseReturned>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerCanceledMerchandiseReturned>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackConsumerCanceledMerchandiseReturnedReturnMethod
        > expectedReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl;
        string expectedReturnedAt = "2019-12-27";
        string expectedMerchantReceivedReturnAt = "2019-12-27";
        string expectedOtherExplanation = "x";
        string expectedTrackingNumber = "x";

        Assert.Equal(expectedReturnMethod, deserialized.ReturnMethod);
        Assert.Equal(expectedReturnedAt, deserialized.ReturnedAt);
        Assert.Equal(expectedMerchantReceivedReturnAt, deserialized.MerchantReceivedReturnAt);
        Assert.Equal(expectedOtherExplanation, deserialized.OtherExplanation);
        Assert.Equal(expectedTrackingNumber, deserialized.TrackingNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
        };

        Assert.Null(model.MerchantReceivedReturnAt);
        Assert.False(model.RawData.ContainsKey("merchant_received_return_at"));
        Assert.Null(model.OtherExplanation);
        Assert.False(model.RawData.ContainsKey("other_explanation"));
        Assert.Null(model.TrackingNumber);
        Assert.False(model.RawData.ContainsKey("tracking_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            MerchantReceivedReturnAt = null,
            OtherExplanation = null,
            TrackingNumber = null,
        };

        Assert.Null(model.MerchantReceivedReturnAt);
        Assert.False(model.RawData.ContainsKey("merchant_received_return_at"));
        Assert.Null(model.OtherExplanation);
        Assert.False(model.RawData.ContainsKey("other_explanation"));
        Assert.Null(model.TrackingNumber);
        Assert.False(model.RawData.ContainsKey("tracking_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            MerchantReceivedReturnAt = null,
            OtherExplanation = null,
            TrackingNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerCanceledMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ChargebackConsumerCanceledMerchandiseReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerCanceledMerchandiseReturnedReturnMethodTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl)]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.FaceToFace)]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Fedex)]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Other)]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.PostalService)]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Ups)]
    public void Validation_Works(ChargebackConsumerCanceledMerchandiseReturnedReturnMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnedReturnMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Dhl)]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.FaceToFace)]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Fedex)]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Other)]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.PostalService)]
    [InlineData(ChargebackConsumerCanceledMerchandiseReturnedReturnMethod.Ups)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerCanceledMerchandiseReturnedReturnMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnedReturnMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledMerchandiseReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerCanceledRecurringTransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransaction
        {
            CancellationTarget =
                ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
            MerchantContactMethods = new()
            {
                ApplicationName = "x",
                CallCenterPhoneNumber = "x",
                EmailAddress = "x",
                InPersonAddress = "x",
                MailingAddress = "x",
                TextPhoneNumber = "x",
            },
            TransactionOrAccountCanceledAt = "2019-12-27",
            OtherFormOfPaymentExplanation = "x",
        };

        ApiEnum<
            string,
            ChargebackConsumerCanceledRecurringTransactionCancellationTarget
        > expectedCancellationTarget =
            ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account;
        ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods expectedMerchantContactMethods =
            new()
            {
                ApplicationName = "x",
                CallCenterPhoneNumber = "x",
                EmailAddress = "x",
                InPersonAddress = "x",
                MailingAddress = "x",
                TextPhoneNumber = "x",
            };
        string expectedTransactionOrAccountCanceledAt = "2019-12-27";
        string expectedOtherFormOfPaymentExplanation = "x";

        Assert.Equal(expectedCancellationTarget, model.CancellationTarget);
        Assert.Equal(expectedMerchantContactMethods, model.MerchantContactMethods);
        Assert.Equal(expectedTransactionOrAccountCanceledAt, model.TransactionOrAccountCanceledAt);
        Assert.Equal(expectedOtherFormOfPaymentExplanation, model.OtherFormOfPaymentExplanation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransaction
        {
            CancellationTarget =
                ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
            MerchantContactMethods = new()
            {
                ApplicationName = "x",
                CallCenterPhoneNumber = "x",
                EmailAddress = "x",
                InPersonAddress = "x",
                MailingAddress = "x",
                TextPhoneNumber = "x",
            },
            TransactionOrAccountCanceledAt = "2019-12-27",
            OtherFormOfPaymentExplanation = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerCanceledRecurringTransaction>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransaction
        {
            CancellationTarget =
                ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
            MerchantContactMethods = new()
            {
                ApplicationName = "x",
                CallCenterPhoneNumber = "x",
                EmailAddress = "x",
                InPersonAddress = "x",
                MailingAddress = "x",
                TextPhoneNumber = "x",
            },
            TransactionOrAccountCanceledAt = "2019-12-27",
            OtherFormOfPaymentExplanation = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerCanceledRecurringTransaction>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackConsumerCanceledRecurringTransactionCancellationTarget
        > expectedCancellationTarget =
            ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account;
        ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods expectedMerchantContactMethods =
            new()
            {
                ApplicationName = "x",
                CallCenterPhoneNumber = "x",
                EmailAddress = "x",
                InPersonAddress = "x",
                MailingAddress = "x",
                TextPhoneNumber = "x",
            };
        string expectedTransactionOrAccountCanceledAt = "2019-12-27";
        string expectedOtherFormOfPaymentExplanation = "x";

        Assert.Equal(expectedCancellationTarget, deserialized.CancellationTarget);
        Assert.Equal(expectedMerchantContactMethods, deserialized.MerchantContactMethods);
        Assert.Equal(
            expectedTransactionOrAccountCanceledAt,
            deserialized.TransactionOrAccountCanceledAt
        );
        Assert.Equal(
            expectedOtherFormOfPaymentExplanation,
            deserialized.OtherFormOfPaymentExplanation
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransaction
        {
            CancellationTarget =
                ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
            MerchantContactMethods = new()
            {
                ApplicationName = "x",
                CallCenterPhoneNumber = "x",
                EmailAddress = "x",
                InPersonAddress = "x",
                MailingAddress = "x",
                TextPhoneNumber = "x",
            },
            TransactionOrAccountCanceledAt = "2019-12-27",
            OtherFormOfPaymentExplanation = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransaction
        {
            CancellationTarget =
                ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
            MerchantContactMethods = new()
            {
                ApplicationName = "x",
                CallCenterPhoneNumber = "x",
                EmailAddress = "x",
                InPersonAddress = "x",
                MailingAddress = "x",
                TextPhoneNumber = "x",
            },
            TransactionOrAccountCanceledAt = "2019-12-27",
        };

        Assert.Null(model.OtherFormOfPaymentExplanation);
        Assert.False(model.RawData.ContainsKey("other_form_of_payment_explanation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransaction
        {
            CancellationTarget =
                ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
            MerchantContactMethods = new()
            {
                ApplicationName = "x",
                CallCenterPhoneNumber = "x",
                EmailAddress = "x",
                InPersonAddress = "x",
                MailingAddress = "x",
                TextPhoneNumber = "x",
            },
            TransactionOrAccountCanceledAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransaction
        {
            CancellationTarget =
                ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
            MerchantContactMethods = new()
            {
                ApplicationName = "x",
                CallCenterPhoneNumber = "x",
                EmailAddress = "x",
                InPersonAddress = "x",
                MailingAddress = "x",
                TextPhoneNumber = "x",
            },
            TransactionOrAccountCanceledAt = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            OtherFormOfPaymentExplanation = null,
        };

        Assert.Null(model.OtherFormOfPaymentExplanation);
        Assert.False(model.RawData.ContainsKey("other_form_of_payment_explanation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransaction
        {
            CancellationTarget =
                ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
            MerchantContactMethods = new()
            {
                ApplicationName = "x",
                CallCenterPhoneNumber = "x",
                EmailAddress = "x",
                InPersonAddress = "x",
                MailingAddress = "x",
                TextPhoneNumber = "x",
            },
            TransactionOrAccountCanceledAt = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            OtherFormOfPaymentExplanation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransaction
        {
            CancellationTarget =
                ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account,
            MerchantContactMethods = new()
            {
                ApplicationName = "x",
                CallCenterPhoneNumber = "x",
                EmailAddress = "x",
                InPersonAddress = "x",
                MailingAddress = "x",
                TextPhoneNumber = "x",
            },
            TransactionOrAccountCanceledAt = "2019-12-27",
            OtherFormOfPaymentExplanation = "x",
        };

        ChargebackConsumerCanceledRecurringTransaction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerCanceledRecurringTransactionCancellationTargetTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account)]
    [InlineData(ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Transaction)]
    public void Validation_Works(
        ChargebackConsumerCanceledRecurringTransactionCancellationTarget rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerCanceledRecurringTransactionCancellationTarget> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledRecurringTransactionCancellationTarget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Account)]
    [InlineData(ChargebackConsumerCanceledRecurringTransactionCancellationTarget.Transaction)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerCanceledRecurringTransactionCancellationTarget rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerCanceledRecurringTransactionCancellationTarget> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledRecurringTransactionCancellationTarget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledRecurringTransactionCancellationTarget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledRecurringTransactionCancellationTarget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerCanceledRecurringTransactionMerchantContactMethodsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods
        {
            ApplicationName = "x",
            CallCenterPhoneNumber = "x",
            EmailAddress = "x",
            InPersonAddress = "x",
            MailingAddress = "x",
            TextPhoneNumber = "x",
        };

        string expectedApplicationName = "x";
        string expectedCallCenterPhoneNumber = "x";
        string expectedEmailAddress = "x";
        string expectedInPersonAddress = "x";
        string expectedMailingAddress = "x";
        string expectedTextPhoneNumber = "x";

        Assert.Equal(expectedApplicationName, model.ApplicationName);
        Assert.Equal(expectedCallCenterPhoneNumber, model.CallCenterPhoneNumber);
        Assert.Equal(expectedEmailAddress, model.EmailAddress);
        Assert.Equal(expectedInPersonAddress, model.InPersonAddress);
        Assert.Equal(expectedMailingAddress, model.MailingAddress);
        Assert.Equal(expectedTextPhoneNumber, model.TextPhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods
        {
            ApplicationName = "x",
            CallCenterPhoneNumber = "x",
            EmailAddress = "x",
            InPersonAddress = "x",
            MailingAddress = "x",
            TextPhoneNumber = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods
        {
            ApplicationName = "x",
            CallCenterPhoneNumber = "x",
            EmailAddress = "x",
            InPersonAddress = "x",
            MailingAddress = "x",
            TextPhoneNumber = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedApplicationName = "x";
        string expectedCallCenterPhoneNumber = "x";
        string expectedEmailAddress = "x";
        string expectedInPersonAddress = "x";
        string expectedMailingAddress = "x";
        string expectedTextPhoneNumber = "x";

        Assert.Equal(expectedApplicationName, deserialized.ApplicationName);
        Assert.Equal(expectedCallCenterPhoneNumber, deserialized.CallCenterPhoneNumber);
        Assert.Equal(expectedEmailAddress, deserialized.EmailAddress);
        Assert.Equal(expectedInPersonAddress, deserialized.InPersonAddress);
        Assert.Equal(expectedMailingAddress, deserialized.MailingAddress);
        Assert.Equal(expectedTextPhoneNumber, deserialized.TextPhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods
        {
            ApplicationName = "x",
            CallCenterPhoneNumber = "x",
            EmailAddress = "x",
            InPersonAddress = "x",
            MailingAddress = "x",
            TextPhoneNumber = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods { };

        Assert.Null(model.ApplicationName);
        Assert.False(model.RawData.ContainsKey("application_name"));
        Assert.Null(model.CallCenterPhoneNumber);
        Assert.False(model.RawData.ContainsKey("call_center_phone_number"));
        Assert.Null(model.EmailAddress);
        Assert.False(model.RawData.ContainsKey("email_address"));
        Assert.Null(model.InPersonAddress);
        Assert.False(model.RawData.ContainsKey("in_person_address"));
        Assert.Null(model.MailingAddress);
        Assert.False(model.RawData.ContainsKey("mailing_address"));
        Assert.Null(model.TextPhoneNumber);
        Assert.False(model.RawData.ContainsKey("text_phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods
        {
            // Null should be interpreted as omitted for these properties
            ApplicationName = null,
            CallCenterPhoneNumber = null,
            EmailAddress = null,
            InPersonAddress = null,
            MailingAddress = null,
            TextPhoneNumber = null,
        };

        Assert.Null(model.ApplicationName);
        Assert.False(model.RawData.ContainsKey("application_name"));
        Assert.Null(model.CallCenterPhoneNumber);
        Assert.False(model.RawData.ContainsKey("call_center_phone_number"));
        Assert.Null(model.EmailAddress);
        Assert.False(model.RawData.ContainsKey("email_address"));
        Assert.Null(model.InPersonAddress);
        Assert.False(model.RawData.ContainsKey("in_person_address"));
        Assert.Null(model.MailingAddress);
        Assert.False(model.RawData.ContainsKey("mailing_address"));
        Assert.Null(model.TextPhoneNumber);
        Assert.False(model.RawData.ContainsKey("text_phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods
        {
            // Null should be interpreted as omitted for these properties
            ApplicationName = null,
            CallCenterPhoneNumber = null,
            EmailAddress = null,
            InPersonAddress = null,
            MailingAddress = null,
            TextPhoneNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods
        {
            ApplicationName = "x",
            CallCenterPhoneNumber = "x",
            EmailAddress = "x",
            InPersonAddress = "x",
            MailingAddress = "x",
            TextPhoneNumber = "x",
        };

        ChargebackConsumerCanceledRecurringTransactionMerchantContactMethods copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerCanceledServicesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
            GuaranteedReservation = new(
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
            ),
            Other = new(),
            Timeshare = new(),
        };

        ChargebackConsumerCanceledServicesCardholderCancellation expectedCardholderCancellation =
            new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            };
        string expectedContractedAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerCanceledServicesMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted;
        string expectedPurchaseExplanation = "x";
        ApiEnum<string, ChargebackConsumerCanceledServicesServiceType> expectedServiceType =
            ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation;
        ChargebackConsumerCanceledServicesGuaranteedReservation expectedGuaranteedReservation = new(
            ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
        );
        ChargebackConsumerCanceledServicesOther expectedOther = new();
        ChargebackConsumerCanceledServicesTimeshare expectedTimeshare = new();

        Assert.Equal(expectedCardholderCancellation, model.CardholderCancellation);
        Assert.Equal(expectedContractedAt, model.ContractedAt);
        Assert.Equal(expectedMerchantResolutionAttempted, model.MerchantResolutionAttempted);
        Assert.Equal(expectedPurchaseExplanation, model.PurchaseExplanation);
        Assert.Equal(expectedServiceType, model.ServiceType);
        Assert.Equal(expectedGuaranteedReservation, model.GuaranteedReservation);
        Assert.Equal(expectedOther, model.Other);
        Assert.Equal(expectedTimeshare, model.Timeshare);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
            GuaranteedReservation = new(
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
            ),
            Other = new(),
            Timeshare = new(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerCanceledServices>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
            GuaranteedReservation = new(
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
            ),
            Other = new(),
            Timeshare = new(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerCanceledServices>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ChargebackConsumerCanceledServicesCardholderCancellation expectedCardholderCancellation =
            new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            };
        string expectedContractedAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerCanceledServicesMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted;
        string expectedPurchaseExplanation = "x";
        ApiEnum<string, ChargebackConsumerCanceledServicesServiceType> expectedServiceType =
            ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation;
        ChargebackConsumerCanceledServicesGuaranteedReservation expectedGuaranteedReservation = new(
            ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
        );
        ChargebackConsumerCanceledServicesOther expectedOther = new();
        ChargebackConsumerCanceledServicesTimeshare expectedTimeshare = new();

        Assert.Equal(expectedCardholderCancellation, deserialized.CardholderCancellation);
        Assert.Equal(expectedContractedAt, deserialized.ContractedAt);
        Assert.Equal(expectedMerchantResolutionAttempted, deserialized.MerchantResolutionAttempted);
        Assert.Equal(expectedPurchaseExplanation, deserialized.PurchaseExplanation);
        Assert.Equal(expectedServiceType, deserialized.ServiceType);
        Assert.Equal(expectedGuaranteedReservation, deserialized.GuaranteedReservation);
        Assert.Equal(expectedOther, deserialized.Other);
        Assert.Equal(expectedTimeshare, deserialized.Timeshare);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
            GuaranteedReservation = new(
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
            ),
            Other = new(),
            Timeshare = new(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
        };

        Assert.Null(model.GuaranteedReservation);
        Assert.False(model.RawData.ContainsKey("guaranteed_reservation"));
        Assert.Null(model.Other);
        Assert.False(model.RawData.ContainsKey("other"));
        Assert.Null(model.Timeshare);
        Assert.False(model.RawData.ContainsKey("timeshare"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,

            // Null should be interpreted as omitted for these properties
            GuaranteedReservation = null,
            Other = null,
            Timeshare = null,
        };

        Assert.Null(model.GuaranteedReservation);
        Assert.False(model.RawData.ContainsKey("guaranteed_reservation"));
        Assert.Null(model.Other);
        Assert.False(model.RawData.ContainsKey("other"));
        Assert.Null(model.Timeshare);
        Assert.False(model.RawData.ContainsKey("timeshare"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,

            // Null should be interpreted as omitted for these properties
            GuaranteedReservation = null,
            Other = null,
            Timeshare = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation,
            GuaranteedReservation = new(
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
            ),
            Other = new(),
            Timeshare = new(),
        };

        ChargebackConsumerCanceledServices copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerCanceledServicesCardholderCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledServicesCardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CancellationPolicyProvided =
                ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        string expectedCanceledAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
        > expectedCancellationPolicyProvided =
            ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided;
        string expectedReason = "x";

        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Equal(expectedCancellationPolicyProvided, model.CancellationPolicyProvided);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledServicesCardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CancellationPolicyProvided =
                ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerCanceledServicesCardholderCancellation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerCanceledServicesCardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CancellationPolicyProvided =
                ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerCanceledServicesCardholderCancellation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCanceledAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
        > expectedCancellationPolicyProvided =
            ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided;
        string expectedReason = "x";

        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Equal(expectedCancellationPolicyProvided, deserialized.CancellationPolicyProvided);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerCanceledServicesCardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CancellationPolicyProvided =
                ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerCanceledServicesCardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CancellationPolicyProvided =
                ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        ChargebackConsumerCanceledServicesCardholderCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvidedTest
    : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided
    )]
    [InlineData(
        ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.Provided
    )]
    public void Validation_Works(
        ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided
    )]
    [InlineData(
        ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.Provided
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerCanceledServicesMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted)]
    [InlineData(ChargebackConsumerCanceledServicesMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void Validation_Works(
        ChargebackConsumerCanceledServicesMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerCanceledServicesMerchantResolutionAttempted> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledServicesMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerCanceledServicesMerchantResolutionAttempted.Attempted)]
    [InlineData(ChargebackConsumerCanceledServicesMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerCanceledServicesMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerCanceledServicesMerchantResolutionAttempted> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledServicesMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledServicesMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledServicesMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerCanceledServicesServiceTypeTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation)]
    [InlineData(ChargebackConsumerCanceledServicesServiceType.Other)]
    [InlineData(ChargebackConsumerCanceledServicesServiceType.Timeshare)]
    public void Validation_Works(ChargebackConsumerCanceledServicesServiceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerCanceledServicesServiceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledServicesServiceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerCanceledServicesServiceType.GuaranteedReservation)]
    [InlineData(ChargebackConsumerCanceledServicesServiceType.Other)]
    [InlineData(ChargebackConsumerCanceledServicesServiceType.Timeshare)]
    public void SerializationRoundtrip_Works(ChargebackConsumerCanceledServicesServiceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerCanceledServicesServiceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledServicesServiceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledServicesServiceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledServicesServiceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerCanceledServicesGuaranteedReservationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledServicesGuaranteedReservation
        {
            Explanation =
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService,
        };

        ApiEnum<
            string,
            ChargebackConsumerCanceledServicesGuaranteedReservationExplanation
        > expectedExplanation =
            ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService;

        Assert.Equal(expectedExplanation, model.Explanation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledServicesGuaranteedReservation
        {
            Explanation =
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerCanceledServicesGuaranteedReservation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerCanceledServicesGuaranteedReservation
        {
            Explanation =
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerCanceledServicesGuaranteedReservation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackConsumerCanceledServicesGuaranteedReservationExplanation
        > expectedExplanation =
            ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService;

        Assert.Equal(expectedExplanation, deserialized.Explanation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerCanceledServicesGuaranteedReservation
        {
            Explanation =
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerCanceledServicesGuaranteedReservation
        {
            Explanation =
                ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService,
        };

        ChargebackConsumerCanceledServicesGuaranteedReservation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerCanceledServicesGuaranteedReservationExplanationTest : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
    )]
    [InlineData(
        ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCancellationAttemptWithin24HoursOfConfirmation
    )]
    [InlineData(
        ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.MerchantBilledNoShow
    )]
    public void Validation_Works(
        ChargebackConsumerCanceledServicesGuaranteedReservationExplanation rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerCanceledServicesGuaranteedReservationExplanation> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledServicesGuaranteedReservationExplanation>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCanceledPriorToService
    )]
    [InlineData(
        ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.CardholderCancellationAttemptWithin24HoursOfConfirmation
    )]
    [InlineData(
        ChargebackConsumerCanceledServicesGuaranteedReservationExplanation.MerchantBilledNoShow
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerCanceledServicesGuaranteedReservationExplanation rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerCanceledServicesGuaranteedReservationExplanation> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledServicesGuaranteedReservationExplanation>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledServicesGuaranteedReservationExplanation>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerCanceledServicesGuaranteedReservationExplanation>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerCanceledServicesOtherTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledServicesOther { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledServicesOther { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerCanceledServicesOther>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerCanceledServicesOther { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerCanceledServicesOther>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerCanceledServicesOther { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerCanceledServicesOther { };

        ChargebackConsumerCanceledServicesOther copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerCanceledServicesTimeshareTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledServicesTimeshare { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerCanceledServicesTimeshare { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerCanceledServicesTimeshare>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerCanceledServicesTimeshare { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerCanceledServicesTimeshare>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerCanceledServicesTimeshare { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerCanceledServicesTimeshare { };

        ChargebackConsumerCanceledServicesTimeshare copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerCounterfeitMerchandiseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerCounterfeitMerchandise
        {
            CounterfeitExplanation = "x",
            DispositionExplanation = "x",
            OrderExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        string expectedCounterfeitExplanation = "x";
        string expectedDispositionExplanation = "x";
        string expectedOrderExplanation = "x";
        string expectedReceivedAt = "2019-12-27";

        Assert.Equal(expectedCounterfeitExplanation, model.CounterfeitExplanation);
        Assert.Equal(expectedDispositionExplanation, model.DispositionExplanation);
        Assert.Equal(expectedOrderExplanation, model.OrderExplanation);
        Assert.Equal(expectedReceivedAt, model.ReceivedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerCounterfeitMerchandise
        {
            CounterfeitExplanation = "x",
            DispositionExplanation = "x",
            OrderExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerCounterfeitMerchandise>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerCounterfeitMerchandise
        {
            CounterfeitExplanation = "x",
            DispositionExplanation = "x",
            OrderExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerCounterfeitMerchandise>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCounterfeitExplanation = "x";
        string expectedDispositionExplanation = "x";
        string expectedOrderExplanation = "x";
        string expectedReceivedAt = "2019-12-27";

        Assert.Equal(expectedCounterfeitExplanation, deserialized.CounterfeitExplanation);
        Assert.Equal(expectedDispositionExplanation, deserialized.DispositionExplanation);
        Assert.Equal(expectedOrderExplanation, deserialized.OrderExplanation);
        Assert.Equal(expectedReceivedAt, deserialized.ReceivedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerCounterfeitMerchandise
        {
            CounterfeitExplanation = "x",
            DispositionExplanation = "x",
            OrderExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerCounterfeitMerchandise
        {
            CounterfeitExplanation = "x",
            DispositionExplanation = "x",
            OrderExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        ChargebackConsumerCounterfeitMerchandise copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerCreditNotProcessedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerCreditNotProcessed
        {
            CanceledOrReturnedAt = "2019-12-27",
            CreditExpectedAt = "2019-12-27",
        };

        string expectedCanceledOrReturnedAt = "2019-12-27";
        string expectedCreditExpectedAt = "2019-12-27";

        Assert.Equal(expectedCanceledOrReturnedAt, model.CanceledOrReturnedAt);
        Assert.Equal(expectedCreditExpectedAt, model.CreditExpectedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerCreditNotProcessed
        {
            CanceledOrReturnedAt = "2019-12-27",
            CreditExpectedAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerCreditNotProcessed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerCreditNotProcessed
        {
            CanceledOrReturnedAt = "2019-12-27",
            CreditExpectedAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerCreditNotProcessed>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCanceledOrReturnedAt = "2019-12-27";
        string expectedCreditExpectedAt = "2019-12-27";

        Assert.Equal(expectedCanceledOrReturnedAt, deserialized.CanceledOrReturnedAt);
        Assert.Equal(expectedCreditExpectedAt, deserialized.CreditExpectedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerCreditNotProcessed
        {
            CanceledOrReturnedAt = "2019-12-27",
            CreditExpectedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerCreditNotProcessed { };

        Assert.Null(model.CanceledOrReturnedAt);
        Assert.False(model.RawData.ContainsKey("canceled_or_returned_at"));
        Assert.Null(model.CreditExpectedAt);
        Assert.False(model.RawData.ContainsKey("credit_expected_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerCreditNotProcessed { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerCreditNotProcessed
        {
            // Null should be interpreted as omitted for these properties
            CanceledOrReturnedAt = null,
            CreditExpectedAt = null,
        };

        Assert.Null(model.CanceledOrReturnedAt);
        Assert.False(model.RawData.ContainsKey("canceled_or_returned_at"));
        Assert.Null(model.CreditExpectedAt);
        Assert.False(model.RawData.ContainsKey("credit_expected_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerCreditNotProcessed
        {
            // Null should be interpreted as omitted for these properties
            CanceledOrReturnedAt = null,
            CreditExpectedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerCreditNotProcessed
        {
            CanceledOrReturnedAt = "2019-12-27",
            CreditExpectedAt = "2019-12-27",
        };

        ChargebackConsumerCreditNotProcessed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerDamagedOrDefectiveMerchandiseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome =
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ApiEnum<
            string,
            ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted;
        string expectedOrderAndIssueExplanation = "x";
        string expectedReceivedAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome
        > expectedReturnOutcome =
            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned;
        ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned expectedNotReturned = new();
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted expectedReturnAttempted =
            new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            };
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturned expectedReturned = new()
        {
            ReturnMethod = ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        Assert.Equal(expectedMerchantResolutionAttempted, model.MerchantResolutionAttempted);
        Assert.Equal(expectedOrderAndIssueExplanation, model.OrderAndIssueExplanation);
        Assert.Equal(expectedReceivedAt, model.ReceivedAt);
        Assert.Equal(expectedReturnOutcome, model.ReturnOutcome);
        Assert.Equal(expectedNotReturned, model.NotReturned);
        Assert.Equal(expectedReturnAttempted, model.ReturnAttempted);
        Assert.Equal(expectedReturned, model.Returned);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome =
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerDamagedOrDefectiveMerchandise>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome =
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerDamagedOrDefectiveMerchandise>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted;
        string expectedOrderAndIssueExplanation = "x";
        string expectedReceivedAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome
        > expectedReturnOutcome =
            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned;
        ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned expectedNotReturned = new();
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted expectedReturnAttempted =
            new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            };
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturned expectedReturned = new()
        {
            ReturnMethod = ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        Assert.Equal(expectedMerchantResolutionAttempted, deserialized.MerchantResolutionAttempted);
        Assert.Equal(expectedOrderAndIssueExplanation, deserialized.OrderAndIssueExplanation);
        Assert.Equal(expectedReceivedAt, deserialized.ReceivedAt);
        Assert.Equal(expectedReturnOutcome, deserialized.ReturnOutcome);
        Assert.Equal(expectedNotReturned, deserialized.NotReturned);
        Assert.Equal(expectedReturnAttempted, deserialized.ReturnAttempted);
        Assert.Equal(expectedReturned, deserialized.Returned);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome =
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome =
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
        };

        Assert.Null(model.NotReturned);
        Assert.False(model.RawData.ContainsKey("not_returned"));
        Assert.Null(model.ReturnAttempted);
        Assert.False(model.RawData.ContainsKey("return_attempted"));
        Assert.Null(model.Returned);
        Assert.False(model.RawData.ContainsKey("returned"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome =
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome =
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,

            // Null should be interpreted as omitted for these properties
            NotReturned = null,
            ReturnAttempted = null,
            Returned = null,
        };

        Assert.Null(model.NotReturned);
        Assert.False(model.RawData.ContainsKey("not_returned"));
        Assert.Null(model.ReturnAttempted);
        Assert.False(model.RawData.ContainsKey("return_attempted"));
        Assert.Null(model.Returned);
        Assert.False(model.RawData.ContainsKey("returned"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome =
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,

            // Null should be interpreted as omitted for these properties
            NotReturned = null,
            ReturnAttempted = null,
            Returned = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome =
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod =
                    ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ChargebackConsumerDamagedOrDefectiveMerchandise copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttemptedTest
    : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted
    )]
    [InlineData(
        ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void Validation_Works(
        ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted
    )]
    [InlineData(
        ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcomeTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned)]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.Returned)]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.ReturnAttempted)]
    public void Validation_Works(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned)]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.Returned)]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome.ReturnAttempted)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerDamagedOrDefectiveMerchandiseReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned { };

        ChargebackConsumerDamagedOrDefectiveMerchandiseNotReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding;
        string expectedAttemptedAt = "2019-12-27";
        string expectedMerchandiseDisposition = "x";

        Assert.Equal(expectedAttemptExplanation, model.AttemptExplanation);
        Assert.Equal(expectedAttemptReason, model.AttemptReason);
        Assert.Equal(expectedAttemptedAt, model.AttemptedAt);
        Assert.Equal(expectedMerchandiseDisposition, model.MerchandiseDisposition);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding;
        string expectedAttemptedAt = "2019-12-27";
        string expectedMerchandiseDisposition = "x";

        Assert.Equal(expectedAttemptExplanation, deserialized.AttemptExplanation);
        Assert.Equal(expectedAttemptReason, deserialized.AttemptReason);
        Assert.Equal(expectedAttemptedAt, deserialized.AttemptedAt);
        Assert.Equal(expectedMerchandiseDisposition, deserialized.MerchandiseDisposition);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttempted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReasonTest
    : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding
    )]
    [InlineData(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions
    )]
    [InlineData(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn
    )]
    [InlineData(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted
    )]
    public void Validation_Works(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding
    )]
    [InlineData(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions
    )]
    [InlineData(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn
    )]
    [InlineData(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ApiEnum<
            string,
            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod
        > expectedReturnMethod =
            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl;
        string expectedReturnedAt = "2019-12-27";
        string expectedMerchantReceivedReturnAt = "2019-12-27";
        string expectedOtherExplanation = "x";
        string expectedTrackingNumber = "x";

        Assert.Equal(expectedReturnMethod, model.ReturnMethod);
        Assert.Equal(expectedReturnedAt, model.ReturnedAt);
        Assert.Equal(expectedMerchantReceivedReturnAt, model.MerchantReceivedReturnAt);
        Assert.Equal(expectedOtherExplanation, model.OtherExplanation);
        Assert.Equal(expectedTrackingNumber, model.TrackingNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerDamagedOrDefectiveMerchandiseReturned>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerDamagedOrDefectiveMerchandiseReturned>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod
        > expectedReturnMethod =
            ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl;
        string expectedReturnedAt = "2019-12-27";
        string expectedMerchantReceivedReturnAt = "2019-12-27";
        string expectedOtherExplanation = "x";
        string expectedTrackingNumber = "x";

        Assert.Equal(expectedReturnMethod, deserialized.ReturnMethod);
        Assert.Equal(expectedReturnedAt, deserialized.ReturnedAt);
        Assert.Equal(expectedMerchantReceivedReturnAt, deserialized.MerchantReceivedReturnAt);
        Assert.Equal(expectedOtherExplanation, deserialized.OtherExplanation);
        Assert.Equal(expectedTrackingNumber, deserialized.TrackingNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
        };

        Assert.Null(model.MerchantReceivedReturnAt);
        Assert.False(model.RawData.ContainsKey("merchant_received_return_at"));
        Assert.Null(model.OtherExplanation);
        Assert.False(model.RawData.ContainsKey("other_explanation"));
        Assert.Null(model.TrackingNumber);
        Assert.False(model.RawData.ContainsKey("tracking_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            MerchantReceivedReturnAt = null,
            OtherExplanation = null,
            TrackingNumber = null,
        };

        Assert.Null(model.MerchantReceivedReturnAt);
        Assert.False(model.RawData.ContainsKey("merchant_received_return_at"));
        Assert.Null(model.OtherExplanation);
        Assert.False(model.RawData.ContainsKey("other_explanation"));
        Assert.Null(model.TrackingNumber);
        Assert.False(model.RawData.ContainsKey("tracking_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            MerchantReceivedReturnAt = null,
            OtherExplanation = null,
            TrackingNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ChargebackConsumerDamagedOrDefectiveMerchandiseReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethodTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl)]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.FaceToFace)]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Fedex)]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Other)]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.PostalService)]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Ups)]
    public void Validation_Works(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl)]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.FaceToFace)]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Fedex)]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Other)]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.PostalService)]
    [InlineData(ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Ups)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerMerchandiseMisrepresentationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod =
                    ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ApiEnum<
            string,
            ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted;
        string expectedMisrepresentationExplanation = "x";
        string expectedPurchaseExplanation = "x";
        string expectedReceivedAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseMisrepresentationReturnOutcome
        > expectedReturnOutcome =
            ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned;
        ChargebackConsumerMerchandiseMisrepresentationNotReturned expectedNotReturned = new();
        ChargebackConsumerMerchandiseMisrepresentationReturnAttempted expectedReturnAttempted =
            new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            };
        ChargebackConsumerMerchandiseMisrepresentationReturned expectedReturned = new()
        {
            ReturnMethod = ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        Assert.Equal(expectedMerchantResolutionAttempted, model.MerchantResolutionAttempted);
        Assert.Equal(expectedMisrepresentationExplanation, model.MisrepresentationExplanation);
        Assert.Equal(expectedPurchaseExplanation, model.PurchaseExplanation);
        Assert.Equal(expectedReceivedAt, model.ReceivedAt);
        Assert.Equal(expectedReturnOutcome, model.ReturnOutcome);
        Assert.Equal(expectedNotReturned, model.NotReturned);
        Assert.Equal(expectedReturnAttempted, model.ReturnAttempted);
        Assert.Equal(expectedReturned, model.Returned);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod =
                    ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseMisrepresentation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod =
                    ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseMisrepresentation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted;
        string expectedMisrepresentationExplanation = "x";
        string expectedPurchaseExplanation = "x";
        string expectedReceivedAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseMisrepresentationReturnOutcome
        > expectedReturnOutcome =
            ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned;
        ChargebackConsumerMerchandiseMisrepresentationNotReturned expectedNotReturned = new();
        ChargebackConsumerMerchandiseMisrepresentationReturnAttempted expectedReturnAttempted =
            new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            };
        ChargebackConsumerMerchandiseMisrepresentationReturned expectedReturned = new()
        {
            ReturnMethod = ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        Assert.Equal(expectedMerchantResolutionAttempted, deserialized.MerchantResolutionAttempted);
        Assert.Equal(
            expectedMisrepresentationExplanation,
            deserialized.MisrepresentationExplanation
        );
        Assert.Equal(expectedPurchaseExplanation, deserialized.PurchaseExplanation);
        Assert.Equal(expectedReceivedAt, deserialized.ReceivedAt);
        Assert.Equal(expectedReturnOutcome, deserialized.ReturnOutcome);
        Assert.Equal(expectedNotReturned, deserialized.NotReturned);
        Assert.Equal(expectedReturnAttempted, deserialized.ReturnAttempted);
        Assert.Equal(expectedReturned, deserialized.Returned);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod =
                    ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
        };

        Assert.Null(model.NotReturned);
        Assert.False(model.RawData.ContainsKey("not_returned"));
        Assert.Null(model.ReturnAttempted);
        Assert.False(model.RawData.ContainsKey("return_attempted"));
        Assert.Null(model.Returned);
        Assert.False(model.RawData.ContainsKey("returned"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,

            // Null should be interpreted as omitted for these properties
            NotReturned = null,
            ReturnAttempted = null,
            Returned = null,
        };

        Assert.Null(model.NotReturned);
        Assert.False(model.RawData.ContainsKey("not_returned"));
        Assert.Null(model.ReturnAttempted);
        Assert.False(model.RawData.ContainsKey("return_attempted"));
        Assert.Null(model.Returned);
        Assert.False(model.RawData.ContainsKey("returned"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,

            // Null should be interpreted as omitted for these properties
            NotReturned = null,
            ReturnAttempted = null,
            Returned = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod =
                    ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ChargebackConsumerMerchandiseMisrepresentation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttemptedTest
    : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted
    )]
    [InlineData(
        ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void Validation_Works(
        ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted
    )]
    [InlineData(
        ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerMerchandiseMisrepresentationReturnOutcomeTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned)]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.Returned)]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.ReturnAttempted)]
    public void Validation_Works(
        ChargebackConsumerMerchandiseMisrepresentationReturnOutcome rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerMerchandiseMisrepresentationReturnOutcome> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseMisrepresentationReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned)]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.Returned)]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnOutcome.ReturnAttempted)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerMerchandiseMisrepresentationReturnOutcome rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerMerchandiseMisrepresentationReturnOutcome> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseMisrepresentationReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseMisrepresentationReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseMisrepresentationReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerMerchandiseMisrepresentationNotReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationNotReturned { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationNotReturned { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseMisrepresentationNotReturned>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationNotReturned { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseMisrepresentationNotReturned>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationNotReturned { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationNotReturned { };

        ChargebackConsumerMerchandiseMisrepresentationNotReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding;
        string expectedAttemptedAt = "2019-12-27";
        string expectedMerchandiseDisposition = "x";

        Assert.Equal(expectedAttemptExplanation, model.AttemptExplanation);
        Assert.Equal(expectedAttemptReason, model.AttemptReason);
        Assert.Equal(expectedAttemptedAt, model.AttemptedAt);
        Assert.Equal(expectedMerchandiseDisposition, model.MerchandiseDisposition);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseMisrepresentationReturnAttempted>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseMisrepresentationReturnAttempted>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding;
        string expectedAttemptedAt = "2019-12-27";
        string expectedMerchandiseDisposition = "x";

        Assert.Equal(expectedAttemptExplanation, deserialized.AttemptExplanation);
        Assert.Equal(expectedAttemptReason, deserialized.AttemptReason);
        Assert.Equal(expectedAttemptedAt, deserialized.AttemptedAt);
        Assert.Equal(expectedMerchandiseDisposition, deserialized.MerchandiseDisposition);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        ChargebackConsumerMerchandiseMisrepresentationReturnAttempted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReasonTest
    : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding
    )]
    [InlineData(
        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(
        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnInstructions
    )]
    [InlineData(
        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.RequestedNotToReturn
    )]
    [InlineData(
        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.ReturnNotAccepted
    )]
    public void Validation_Works(
        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding
    )]
    [InlineData(
        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(
        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnInstructions
    )]
    [InlineData(
        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.RequestedNotToReturn
    )]
    [InlineData(
        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.ReturnNotAccepted
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerMerchandiseMisrepresentationReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ApiEnum<
            string,
            ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod
        > expectedReturnMethod =
            ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl;
        string expectedReturnedAt = "2019-12-27";
        string expectedMerchantReceivedReturnAt = "2019-12-27";
        string expectedOtherExplanation = "x";
        string expectedTrackingNumber = "x";

        Assert.Equal(expectedReturnMethod, model.ReturnMethod);
        Assert.Equal(expectedReturnedAt, model.ReturnedAt);
        Assert.Equal(expectedMerchantReceivedReturnAt, model.MerchantReceivedReturnAt);
        Assert.Equal(expectedOtherExplanation, model.OtherExplanation);
        Assert.Equal(expectedTrackingNumber, model.TrackingNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseMisrepresentationReturned>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseMisrepresentationReturned>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod
        > expectedReturnMethod =
            ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl;
        string expectedReturnedAt = "2019-12-27";
        string expectedMerchantReceivedReturnAt = "2019-12-27";
        string expectedOtherExplanation = "x";
        string expectedTrackingNumber = "x";

        Assert.Equal(expectedReturnMethod, deserialized.ReturnMethod);
        Assert.Equal(expectedReturnedAt, deserialized.ReturnedAt);
        Assert.Equal(expectedMerchantReceivedReturnAt, deserialized.MerchantReceivedReturnAt);
        Assert.Equal(expectedOtherExplanation, deserialized.OtherExplanation);
        Assert.Equal(expectedTrackingNumber, deserialized.TrackingNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
        };

        Assert.Null(model.MerchantReceivedReturnAt);
        Assert.False(model.RawData.ContainsKey("merchant_received_return_at"));
        Assert.Null(model.OtherExplanation);
        Assert.False(model.RawData.ContainsKey("other_explanation"));
        Assert.Null(model.TrackingNumber);
        Assert.False(model.RawData.ContainsKey("tracking_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            MerchantReceivedReturnAt = null,
            OtherExplanation = null,
            TrackingNumber = null,
        };

        Assert.Null(model.MerchantReceivedReturnAt);
        Assert.False(model.RawData.ContainsKey("merchant_received_return_at"));
        Assert.Null(model.OtherExplanation);
        Assert.False(model.RawData.ContainsKey("other_explanation"));
        Assert.Null(model.TrackingNumber);
        Assert.False(model.RawData.ContainsKey("tracking_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            MerchantReceivedReturnAt = null,
            OtherExplanation = null,
            TrackingNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ChargebackConsumerMerchandiseMisrepresentationReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethodTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl)]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.FaceToFace)]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Fedex)]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Other)]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.PostalService)]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Ups)]
    public void Validation_Works(
        ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl)]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.FaceToFace)]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Fedex)]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Other)]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.PostalService)]
    [InlineData(ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod.Ups)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseMisrepresentationReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerMerchandiseNotAsDescribedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted;
        string expectedReceivedAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome
        > expectedReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned;
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted expectedReturnAttempted = new()
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };
        ChargebackConsumerMerchandiseNotAsDescribedReturned expectedReturned = new()
        {
            ReturnMethod = ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        Assert.Equal(expectedMerchantResolutionAttempted, model.MerchantResolutionAttempted);
        Assert.Equal(expectedReceivedAt, model.ReceivedAt);
        Assert.Equal(expectedReturnOutcome, model.ReturnOutcome);
        Assert.Equal(expectedReturnAttempted, model.ReturnAttempted);
        Assert.Equal(expectedReturned, model.Returned);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotAsDescribed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotAsDescribed>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted;
        string expectedReceivedAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome
        > expectedReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned;
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted expectedReturnAttempted = new()
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };
        ChargebackConsumerMerchandiseNotAsDescribedReturned expectedReturned = new()
        {
            ReturnMethod = ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        Assert.Equal(expectedMerchantResolutionAttempted, deserialized.MerchantResolutionAttempted);
        Assert.Equal(expectedReceivedAt, deserialized.ReceivedAt);
        Assert.Equal(expectedReturnOutcome, deserialized.ReturnOutcome);
        Assert.Equal(expectedReturnAttempted, deserialized.ReturnAttempted);
        Assert.Equal(expectedReturned, deserialized.Returned);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
        };

        Assert.Null(model.ReturnAttempted);
        Assert.False(model.RawData.ContainsKey("return_attempted"));
        Assert.Null(model.Returned);
        Assert.False(model.RawData.ContainsKey("returned"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,

            // Null should be interpreted as omitted for these properties
            ReturnAttempted = null,
            Returned = null,
        };

        Assert.Null(model.ReturnAttempted);
        Assert.False(model.RawData.ContainsKey("return_attempted"));
        Assert.Null(model.Returned);
        Assert.False(model.RawData.ContainsKey("returned"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,

            // Null should be interpreted as omitted for these properties
            ReturnAttempted = null,
            Returned = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ChargebackConsumerMerchandiseNotAsDescribed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void Validation_Works(
        ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerMerchandiseNotAsDescribedReturnOutcomeTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned)]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.ReturnAttempted)]
    public void Validation_Works(ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.Returned)]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome.ReturnAttempted)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding;
        string expectedAttemptedAt = "2019-12-27";
        string expectedMerchandiseDisposition = "x";

        Assert.Equal(expectedAttemptExplanation, model.AttemptExplanation);
        Assert.Equal(expectedAttemptReason, model.AttemptReason);
        Assert.Equal(expectedAttemptedAt, model.AttemptedAt);
        Assert.Equal(expectedMerchandiseDisposition, model.MerchandiseDisposition);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding;
        string expectedAttemptedAt = "2019-12-27";
        string expectedMerchandiseDisposition = "x";

        Assert.Equal(expectedAttemptExplanation, deserialized.AttemptExplanation);
        Assert.Equal(expectedAttemptReason, deserialized.AttemptReason);
        Assert.Equal(expectedAttemptedAt, deserialized.AttemptedAt);
        Assert.Equal(expectedMerchandiseDisposition, deserialized.MerchandiseDisposition);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        ChargebackConsumerMerchandiseNotAsDescribedReturnAttempted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReasonTest : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding
    )]
    [InlineData(
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnInstructions
    )]
    [InlineData(
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.RequestedNotToReturn
    )]
    [InlineData(
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.ReturnNotAccepted
    )]
    public void Validation_Works(
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding
    )]
    [InlineData(
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnInstructions
    )]
    [InlineData(
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.RequestedNotToReturn
    )]
    [InlineData(
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.ReturnNotAccepted
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerMerchandiseNotAsDescribedReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod
        > expectedReturnMethod =
            ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl;
        string expectedReturnedAt = "2019-12-27";
        string expectedMerchantReceivedReturnAt = "2019-12-27";
        string expectedOtherExplanation = "x";
        string expectedTrackingNumber = "x";

        Assert.Equal(expectedReturnMethod, model.ReturnMethod);
        Assert.Equal(expectedReturnedAt, model.ReturnedAt);
        Assert.Equal(expectedMerchantReceivedReturnAt, model.MerchantReceivedReturnAt);
        Assert.Equal(expectedOtherExplanation, model.OtherExplanation);
        Assert.Equal(expectedTrackingNumber, model.TrackingNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotAsDescribedReturned>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotAsDescribedReturned>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod
        > expectedReturnMethod =
            ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl;
        string expectedReturnedAt = "2019-12-27";
        string expectedMerchantReceivedReturnAt = "2019-12-27";
        string expectedOtherExplanation = "x";
        string expectedTrackingNumber = "x";

        Assert.Equal(expectedReturnMethod, deserialized.ReturnMethod);
        Assert.Equal(expectedReturnedAt, deserialized.ReturnedAt);
        Assert.Equal(expectedMerchantReceivedReturnAt, deserialized.MerchantReceivedReturnAt);
        Assert.Equal(expectedOtherExplanation, deserialized.OtherExplanation);
        Assert.Equal(expectedTrackingNumber, deserialized.TrackingNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
        };

        Assert.Null(model.MerchantReceivedReturnAt);
        Assert.False(model.RawData.ContainsKey("merchant_received_return_at"));
        Assert.Null(model.OtherExplanation);
        Assert.False(model.RawData.ContainsKey("other_explanation"));
        Assert.Null(model.TrackingNumber);
        Assert.False(model.RawData.ContainsKey("tracking_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            MerchantReceivedReturnAt = null,
            OtherExplanation = null,
            TrackingNumber = null,
        };

        Assert.Null(model.MerchantReceivedReturnAt);
        Assert.False(model.RawData.ContainsKey("merchant_received_return_at"));
        Assert.Null(model.OtherExplanation);
        Assert.False(model.RawData.ContainsKey("other_explanation"));
        Assert.Null(model.TrackingNumber);
        Assert.False(model.RawData.ContainsKey("tracking_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            MerchantReceivedReturnAt = null,
            OtherExplanation = null,
            TrackingNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ChargebackConsumerMerchandiseNotAsDescribedReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethodTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl)]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.FaceToFace)]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Fedex)]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Other)]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.PostalService)]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Ups)]
    public void Validation_Works(
        ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl)]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.FaceToFace)]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Fedex)]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Other)]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.PostalService)]
    [InlineData(ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Ups)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotAsDescribedReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerMerchandiseNotReceivedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Delayed = new()
            {
                Explanation = "x",
                ReturnOutcome =
                    ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new("2019-12-27"),
                Returned = new()
                {
                    MerchantReceivedReturnAt = "2019-12-27",
                    ReturnedAt = "2019-12-27",
                },
            },
            DeliveredToWrongLocation = new("x"),
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };

        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotReceivedCancellationOutcome
        > expectedCancellationOutcome =
            ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt;
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotReceivedDeliveryIssue
        > expectedDeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed;
        string expectedLastExpectedReceiptAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted;
        string expectedPurchaseInfoAndExplanation = "x";
        ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt expectedCardholderCancellationPriorToExpectedReceipt =
            new() { CanceledAt = "2019-12-27", Reason = "x" };
        ChargebackConsumerMerchandiseNotReceivedDelayed expectedDelayed = new()
        {
            Explanation = "x",
            ReturnOutcome =
                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new("2019-12-27"),
            Returned = new() { MerchantReceivedReturnAt = "2019-12-27", ReturnedAt = "2019-12-27" },
        };
        ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation expectedDeliveredToWrongLocation =
            new("x");
        ChargebackConsumerMerchandiseNotReceivedMerchantCancellation expectedMerchantCancellation =
            new("2019-12-27");
        ChargebackConsumerMerchandiseNotReceivedNoCancellation expectedNoCancellation = new();

        Assert.Equal(expectedCancellationOutcome, model.CancellationOutcome);
        Assert.Equal(expectedDeliveryIssue, model.DeliveryIssue);
        Assert.Equal(expectedLastExpectedReceiptAt, model.LastExpectedReceiptAt);
        Assert.Equal(expectedMerchantResolutionAttempted, model.MerchantResolutionAttempted);
        Assert.Equal(expectedPurchaseInfoAndExplanation, model.PurchaseInfoAndExplanation);
        Assert.Equal(
            expectedCardholderCancellationPriorToExpectedReceipt,
            model.CardholderCancellationPriorToExpectedReceipt
        );
        Assert.Equal(expectedDelayed, model.Delayed);
        Assert.Equal(expectedDeliveredToWrongLocation, model.DeliveredToWrongLocation);
        Assert.Equal(expectedMerchantCancellation, model.MerchantCancellation);
        Assert.Equal(expectedNoCancellation, model.NoCancellation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Delayed = new()
            {
                Explanation = "x",
                ReturnOutcome =
                    ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new("2019-12-27"),
                Returned = new()
                {
                    MerchantReceivedReturnAt = "2019-12-27",
                    ReturnedAt = "2019-12-27",
                },
            },
            DeliveredToWrongLocation = new("x"),
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceived>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Delayed = new()
            {
                Explanation = "x",
                ReturnOutcome =
                    ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new("2019-12-27"),
                Returned = new()
                {
                    MerchantReceivedReturnAt = "2019-12-27",
                    ReturnedAt = "2019-12-27",
                },
            },
            DeliveredToWrongLocation = new("x"),
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceived>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotReceivedCancellationOutcome
        > expectedCancellationOutcome =
            ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt;
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotReceivedDeliveryIssue
        > expectedDeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed;
        string expectedLastExpectedReceiptAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted;
        string expectedPurchaseInfoAndExplanation = "x";
        ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt expectedCardholderCancellationPriorToExpectedReceipt =
            new() { CanceledAt = "2019-12-27", Reason = "x" };
        ChargebackConsumerMerchandiseNotReceivedDelayed expectedDelayed = new()
        {
            Explanation = "x",
            ReturnOutcome =
                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new("2019-12-27"),
            Returned = new() { MerchantReceivedReturnAt = "2019-12-27", ReturnedAt = "2019-12-27" },
        };
        ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation expectedDeliveredToWrongLocation =
            new("x");
        ChargebackConsumerMerchandiseNotReceivedMerchantCancellation expectedMerchantCancellation =
            new("2019-12-27");
        ChargebackConsumerMerchandiseNotReceivedNoCancellation expectedNoCancellation = new();

        Assert.Equal(expectedCancellationOutcome, deserialized.CancellationOutcome);
        Assert.Equal(expectedDeliveryIssue, deserialized.DeliveryIssue);
        Assert.Equal(expectedLastExpectedReceiptAt, deserialized.LastExpectedReceiptAt);
        Assert.Equal(expectedMerchantResolutionAttempted, deserialized.MerchantResolutionAttempted);
        Assert.Equal(expectedPurchaseInfoAndExplanation, deserialized.PurchaseInfoAndExplanation);
        Assert.Equal(
            expectedCardholderCancellationPriorToExpectedReceipt,
            deserialized.CardholderCancellationPriorToExpectedReceipt
        );
        Assert.Equal(expectedDelayed, deserialized.Delayed);
        Assert.Equal(expectedDeliveredToWrongLocation, deserialized.DeliveredToWrongLocation);
        Assert.Equal(expectedMerchantCancellation, deserialized.MerchantCancellation);
        Assert.Equal(expectedNoCancellation, deserialized.NoCancellation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Delayed = new()
            {
                Explanation = "x",
                ReturnOutcome =
                    ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new("2019-12-27"),
                Returned = new()
                {
                    MerchantReceivedReturnAt = "2019-12-27",
                    ReturnedAt = "2019-12-27",
                },
            },
            DeliveredToWrongLocation = new("x"),
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
        };

        Assert.Null(model.CardholderCancellationPriorToExpectedReceipt);
        Assert.False(
            model.RawData.ContainsKey("cardholder_cancellation_prior_to_expected_receipt")
        );
        Assert.Null(model.Delayed);
        Assert.False(model.RawData.ContainsKey("delayed"));
        Assert.Null(model.DeliveredToWrongLocation);
        Assert.False(model.RawData.ContainsKey("delivered_to_wrong_location"));
        Assert.Null(model.MerchantCancellation);
        Assert.False(model.RawData.ContainsKey("merchant_cancellation"));
        Assert.Null(model.NoCancellation);
        Assert.False(model.RawData.ContainsKey("no_cancellation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",

            // Null should be interpreted as omitted for these properties
            CardholderCancellationPriorToExpectedReceipt = null,
            Delayed = null,
            DeliveredToWrongLocation = null,
            MerchantCancellation = null,
            NoCancellation = null,
        };

        Assert.Null(model.CardholderCancellationPriorToExpectedReceipt);
        Assert.False(
            model.RawData.ContainsKey("cardholder_cancellation_prior_to_expected_receipt")
        );
        Assert.Null(model.Delayed);
        Assert.False(model.RawData.ContainsKey("delayed"));
        Assert.Null(model.DeliveredToWrongLocation);
        Assert.False(model.RawData.ContainsKey("delivered_to_wrong_location"));
        Assert.Null(model.MerchantCancellation);
        Assert.False(model.RawData.ContainsKey("merchant_cancellation"));
        Assert.Null(model.NoCancellation);
        Assert.False(model.RawData.ContainsKey("no_cancellation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",

            // Null should be interpreted as omitted for these properties
            CardholderCancellationPriorToExpectedReceipt = null,
            Delayed = null,
            DeliveredToWrongLocation = null,
            MerchantCancellation = null,
            NoCancellation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Delayed = new()
            {
                Explanation = "x",
                ReturnOutcome =
                    ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new("2019-12-27"),
                Returned = new()
                {
                    MerchantReceivedReturnAt = "2019-12-27",
                    ReturnedAt = "2019-12-27",
                },
            },
            DeliveredToWrongLocation = new("x"),
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };

        ChargebackConsumerMerchandiseNotReceived copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerMerchandiseNotReceivedCancellationOutcomeTest : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt
    )]
    [InlineData(ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.MerchantCancellation)]
    [InlineData(ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.NoCancellation)]
    public void Validation_Works(
        ChargebackConsumerMerchandiseNotReceivedCancellationOutcome rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedCancellationOutcome> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedCancellationOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt
    )]
    [InlineData(ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.MerchantCancellation)]
    [InlineData(ChargebackConsumerMerchandiseNotReceivedCancellationOutcome.NoCancellation)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerMerchandiseNotReceivedCancellationOutcome rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedCancellationOutcome> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedCancellationOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedCancellationOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedCancellationOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerMerchandiseNotReceivedDeliveryIssueTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed)]
    [InlineData(ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.DeliveredToWrongLocation)]
    public void Validation_Works(ChargebackConsumerMerchandiseNotReceivedDeliveryIssue rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedDeliveryIssue> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedDeliveryIssue>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.Delayed)]
    [InlineData(ChargebackConsumerMerchandiseNotReceivedDeliveryIssue.DeliveredToWrongLocation)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerMerchandiseNotReceivedDeliveryIssue rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedDeliveryIssue> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedDeliveryIssue>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedDeliveryIssue>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedDeliveryIssue>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void Validation_Works(
        ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceiptTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            };

        string expectedCanceledAt = "2019-12-27";
        string expectedReason = "x";

        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCanceledAt = "2019-12-27";
        string expectedReason = "x";

        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",
            };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",

                // Null should be interpreted as omitted for these properties
                Reason = null,
            };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model =
            new ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",

                // Null should be interpreted as omitted for these properties
                Reason = null,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            };

        ChargebackConsumerMerchandiseNotReceivedCardholderCancellationPriorToExpectedReceipt copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerMerchandiseNotReceivedDelayedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayed
        {
            Explanation = "x",
            ReturnOutcome =
                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new("2019-12-27"),
            Returned = new() { MerchantReceivedReturnAt = "2019-12-27", ReturnedAt = "2019-12-27" },
        };

        string expectedExplanation = "x";
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome
        > expectedReturnOutcome =
            ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned;
        ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned expectedNotReturned = new();
        ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted expectedReturnAttempted =
            new("2019-12-27");
        ChargebackConsumerMerchandiseNotReceivedDelayedReturned expectedReturned = new()
        {
            MerchantReceivedReturnAt = "2019-12-27",
            ReturnedAt = "2019-12-27",
        };

        Assert.Equal(expectedExplanation, model.Explanation);
        Assert.Equal(expectedReturnOutcome, model.ReturnOutcome);
        Assert.Equal(expectedNotReturned, model.NotReturned);
        Assert.Equal(expectedReturnAttempted, model.ReturnAttempted);
        Assert.Equal(expectedReturned, model.Returned);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayed
        {
            Explanation = "x",
            ReturnOutcome =
                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new("2019-12-27"),
            Returned = new() { MerchantReceivedReturnAt = "2019-12-27", ReturnedAt = "2019-12-27" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceivedDelayed>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayed
        {
            Explanation = "x",
            ReturnOutcome =
                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new("2019-12-27"),
            Returned = new() { MerchantReceivedReturnAt = "2019-12-27", ReturnedAt = "2019-12-27" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceivedDelayed>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedExplanation = "x";
        ApiEnum<
            string,
            ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome
        > expectedReturnOutcome =
            ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned;
        ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned expectedNotReturned = new();
        ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted expectedReturnAttempted =
            new("2019-12-27");
        ChargebackConsumerMerchandiseNotReceivedDelayedReturned expectedReturned = new()
        {
            MerchantReceivedReturnAt = "2019-12-27",
            ReturnedAt = "2019-12-27",
        };

        Assert.Equal(expectedExplanation, deserialized.Explanation);
        Assert.Equal(expectedReturnOutcome, deserialized.ReturnOutcome);
        Assert.Equal(expectedNotReturned, deserialized.NotReturned);
        Assert.Equal(expectedReturnAttempted, deserialized.ReturnAttempted);
        Assert.Equal(expectedReturned, deserialized.Returned);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayed
        {
            Explanation = "x",
            ReturnOutcome =
                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new("2019-12-27"),
            Returned = new() { MerchantReceivedReturnAt = "2019-12-27", ReturnedAt = "2019-12-27" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayed
        {
            Explanation = "x",
            ReturnOutcome =
                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
        };

        Assert.Null(model.NotReturned);
        Assert.False(model.RawData.ContainsKey("not_returned"));
        Assert.Null(model.ReturnAttempted);
        Assert.False(model.RawData.ContainsKey("return_attempted"));
        Assert.Null(model.Returned);
        Assert.False(model.RawData.ContainsKey("returned"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayed
        {
            Explanation = "x",
            ReturnOutcome =
                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayed
        {
            Explanation = "x",
            ReturnOutcome =
                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,

            // Null should be interpreted as omitted for these properties
            NotReturned = null,
            ReturnAttempted = null,
            Returned = null,
        };

        Assert.Null(model.NotReturned);
        Assert.False(model.RawData.ContainsKey("not_returned"));
        Assert.Null(model.ReturnAttempted);
        Assert.False(model.RawData.ContainsKey("return_attempted"));
        Assert.Null(model.Returned);
        Assert.False(model.RawData.ContainsKey("returned"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayed
        {
            Explanation = "x",
            ReturnOutcome =
                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,

            // Null should be interpreted as omitted for these properties
            NotReturned = null,
            ReturnAttempted = null,
            Returned = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayed
        {
            Explanation = "x",
            ReturnOutcome =
                ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new("2019-12-27"),
            Returned = new() { MerchantReceivedReturnAt = "2019-12-27", ReturnedAt = "2019-12-27" },
        };

        ChargebackConsumerMerchandiseNotReceivedDelayed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcomeTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned)]
    [InlineData(ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.Returned)]
    [InlineData(ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.ReturnAttempted)]
    public void Validation_Works(
        ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.NotReturned)]
    [InlineData(ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.Returned)]
    [InlineData(ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome.ReturnAttempted)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerMerchandiseNotReceivedDelayedReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerMerchandiseNotReceivedDelayedNotReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned { };

        ChargebackConsumerMerchandiseNotReceivedDelayedNotReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttemptedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted
        {
            AttemptedAt = "2019-12-27",
        };

        string expectedAttemptedAt = "2019-12-27";

        Assert.Equal(expectedAttemptedAt, model.AttemptedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted
        {
            AttemptedAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted
        {
            AttemptedAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAttemptedAt = "2019-12-27";

        Assert.Equal(expectedAttemptedAt, deserialized.AttemptedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted
        {
            AttemptedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted
        {
            AttemptedAt = "2019-12-27",
        };

        ChargebackConsumerMerchandiseNotReceivedDelayedReturnAttempted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerMerchandiseNotReceivedDelayedReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayedReturned
        {
            MerchantReceivedReturnAt = "2019-12-27",
            ReturnedAt = "2019-12-27",
        };

        string expectedMerchantReceivedReturnAt = "2019-12-27";
        string expectedReturnedAt = "2019-12-27";

        Assert.Equal(expectedMerchantReceivedReturnAt, model.MerchantReceivedReturnAt);
        Assert.Equal(expectedReturnedAt, model.ReturnedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayedReturned
        {
            MerchantReceivedReturnAt = "2019-12-27",
            ReturnedAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceivedDelayedReturned>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayedReturned
        {
            MerchantReceivedReturnAt = "2019-12-27",
            ReturnedAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceivedDelayedReturned>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedMerchantReceivedReturnAt = "2019-12-27";
        string expectedReturnedAt = "2019-12-27";

        Assert.Equal(expectedMerchantReceivedReturnAt, deserialized.MerchantReceivedReturnAt);
        Assert.Equal(expectedReturnedAt, deserialized.ReturnedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayedReturned
        {
            MerchantReceivedReturnAt = "2019-12-27",
            ReturnedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDelayedReturned
        {
            MerchantReceivedReturnAt = "2019-12-27",
            ReturnedAt = "2019-12-27",
        };

        ChargebackConsumerMerchandiseNotReceivedDelayedReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation
        {
            AgreedLocation = "x",
        };

        string expectedAgreedLocation = "x";

        Assert.Equal(expectedAgreedLocation, model.AgreedLocation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation
        {
            AgreedLocation = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation
        {
            AgreedLocation = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAgreedLocation = "x";

        Assert.Equal(expectedAgreedLocation, deserialized.AgreedLocation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation
        {
            AgreedLocation = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation
        {
            AgreedLocation = "x",
        };

        ChargebackConsumerMerchandiseNotReceivedDeliveredToWrongLocation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerMerchandiseNotReceivedMerchantCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedMerchantCancellation
        {
            CanceledAt = "2019-12-27",
        };

        string expectedCanceledAt = "2019-12-27";

        Assert.Equal(expectedCanceledAt, model.CanceledAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedMerchantCancellation
        {
            CanceledAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceivedMerchantCancellation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedMerchantCancellation
        {
            CanceledAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceivedMerchantCancellation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCanceledAt = "2019-12-27";

        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedMerchantCancellation
        {
            CanceledAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedMerchantCancellation
        {
            CanceledAt = "2019-12-27",
        };

        ChargebackConsumerMerchandiseNotReceivedMerchantCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerMerchandiseNotReceivedNoCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedNoCancellation { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedNoCancellation { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceivedNoCancellation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedNoCancellation { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerMerchandiseNotReceivedNoCancellation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedNoCancellation { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerMerchandiseNotReceivedNoCancellation { };

        ChargebackConsumerMerchandiseNotReceivedNoCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerNonReceiptOfCashTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerNonReceiptOfCash { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerNonReceiptOfCash { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerNonReceiptOfCash>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerNonReceiptOfCash { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerNonReceiptOfCash>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerNonReceiptOfCash { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerNonReceiptOfCash { };

        ChargebackConsumerNonReceiptOfCash copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerOriginalCreditTransactionNotAcceptedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerOriginalCreditTransactionNotAccepted
        {
            Explanation = "x",
            Reason =
                ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
        };

        string expectedExplanation = "x";
        ApiEnum<
            string,
            ChargebackConsumerOriginalCreditTransactionNotAcceptedReason
        > expectedReason =
            ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation;

        Assert.Equal(expectedExplanation, model.Explanation);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerOriginalCreditTransactionNotAccepted
        {
            Explanation = "x",
            Reason =
                ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerOriginalCreditTransactionNotAccepted>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerOriginalCreditTransactionNotAccepted
        {
            Explanation = "x",
            Reason =
                ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerOriginalCreditTransactionNotAccepted>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedExplanation = "x";
        ApiEnum<
            string,
            ChargebackConsumerOriginalCreditTransactionNotAcceptedReason
        > expectedReason =
            ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation;

        Assert.Equal(expectedExplanation, deserialized.Explanation);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerOriginalCreditTransactionNotAccepted
        {
            Explanation = "x",
            Reason =
                ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerOriginalCreditTransactionNotAccepted
        {
            Explanation = "x",
            Reason =
                ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation,
        };

        ChargebackConsumerOriginalCreditTransactionNotAccepted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerOriginalCreditTransactionNotAcceptedReasonTest : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation
    )]
    [InlineData(ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.RecipientRefused)]
    public void Validation_Works(
        ChargebackConsumerOriginalCreditTransactionNotAcceptedReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerOriginalCreditTransactionNotAcceptedReason> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerOriginalCreditTransactionNotAcceptedReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.ProhibitedByLocalLawsOrRegulation
    )]
    [InlineData(ChargebackConsumerOriginalCreditTransactionNotAcceptedReason.RecipientRefused)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerOriginalCreditTransactionNotAcceptedReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerOriginalCreditTransactionNotAcceptedReason> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerOriginalCreditTransactionNotAcceptedReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerOriginalCreditTransactionNotAcceptedReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerOriginalCreditTransactionNotAcceptedReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerQualityMerchandiseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string expectedExpectedAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted;
        string expectedPurchaseInfoAndQualityIssue = "x";
        string expectedReceivedAt = "2019-12-27";
        ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnOutcome> expectedReturnOutcome =
            ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned;
        ChargebackConsumerQualityMerchandiseNotReturned expectedNotReturned = new();
        ChargebackConsumerQualityMerchandiseOngoingNegotiations expectedOngoingNegotiations = new()
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };
        ChargebackConsumerQualityMerchandiseReturnAttempted expectedReturnAttempted = new()
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };
        ChargebackConsumerQualityMerchandiseReturned expectedReturned = new()
        {
            ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        Assert.Equal(expectedExpectedAt, model.ExpectedAt);
        Assert.Equal(expectedMerchantResolutionAttempted, model.MerchantResolutionAttempted);
        Assert.Equal(expectedPurchaseInfoAndQualityIssue, model.PurchaseInfoAndQualityIssue);
        Assert.Equal(expectedReceivedAt, model.ReceivedAt);
        Assert.Equal(expectedReturnOutcome, model.ReturnOutcome);
        Assert.Equal(expectedNotReturned, model.NotReturned);
        Assert.Equal(expectedOngoingNegotiations, model.OngoingNegotiations);
        Assert.Equal(expectedReturnAttempted, model.ReturnAttempted);
        Assert.Equal(expectedReturned, model.Returned);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerQualityMerchandise>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerQualityMerchandise>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExpectedAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted;
        string expectedPurchaseInfoAndQualityIssue = "x";
        string expectedReceivedAt = "2019-12-27";
        ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnOutcome> expectedReturnOutcome =
            ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned;
        ChargebackConsumerQualityMerchandiseNotReturned expectedNotReturned = new();
        ChargebackConsumerQualityMerchandiseOngoingNegotiations expectedOngoingNegotiations = new()
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };
        ChargebackConsumerQualityMerchandiseReturnAttempted expectedReturnAttempted = new()
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };
        ChargebackConsumerQualityMerchandiseReturned expectedReturned = new()
        {
            ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        Assert.Equal(expectedExpectedAt, deserialized.ExpectedAt);
        Assert.Equal(expectedMerchantResolutionAttempted, deserialized.MerchantResolutionAttempted);
        Assert.Equal(expectedPurchaseInfoAndQualityIssue, deserialized.PurchaseInfoAndQualityIssue);
        Assert.Equal(expectedReceivedAt, deserialized.ReceivedAt);
        Assert.Equal(expectedReturnOutcome, deserialized.ReturnOutcome);
        Assert.Equal(expectedNotReturned, deserialized.NotReturned);
        Assert.Equal(expectedOngoingNegotiations, deserialized.OngoingNegotiations);
        Assert.Equal(expectedReturnAttempted, deserialized.ReturnAttempted);
        Assert.Equal(expectedReturned, deserialized.Returned);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
        };

        Assert.Null(model.NotReturned);
        Assert.False(model.RawData.ContainsKey("not_returned"));
        Assert.Null(model.OngoingNegotiations);
        Assert.False(model.RawData.ContainsKey("ongoing_negotiations"));
        Assert.Null(model.ReturnAttempted);
        Assert.False(model.RawData.ContainsKey("return_attempted"));
        Assert.Null(model.Returned);
        Assert.False(model.RawData.ContainsKey("returned"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,

            // Null should be interpreted as omitted for these properties
            NotReturned = null,
            OngoingNegotiations = null,
            ReturnAttempted = null,
            Returned = null,
        };

        Assert.Null(model.NotReturned);
        Assert.False(model.RawData.ContainsKey("not_returned"));
        Assert.Null(model.OngoingNegotiations);
        Assert.False(model.RawData.ContainsKey("ongoing_negotiations"));
        Assert.Null(model.ReturnAttempted);
        Assert.False(model.RawData.ContainsKey("return_attempted"));
        Assert.Null(model.Returned);
        Assert.False(model.RawData.ContainsKey("returned"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,

            // Null should be interpreted as omitted for these properties
            NotReturned = null,
            OngoingNegotiations = null,
            ReturnAttempted = null,
            Returned = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ChargebackConsumerQualityMerchandise copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerQualityMerchandiseMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void Validation_Works(
        ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityMerchandiseMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerQualityMerchandiseReturnOutcomeTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned)]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnOutcome.Returned)]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnOutcome.ReturnAttempted)]
    public void Validation_Works(ChargebackConsumerQualityMerchandiseReturnOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnOutcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnOutcome.NotReturned)]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnOutcome.Returned)]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnOutcome.ReturnAttempted)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerQualityMerchandiseReturnOutcome rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnOutcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerQualityMerchandiseNotReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseNotReturned { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseNotReturned { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerQualityMerchandiseNotReturned>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseNotReturned { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerQualityMerchandiseNotReturned>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseNotReturned { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseNotReturned { };

        ChargebackConsumerQualityMerchandiseNotReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerQualityMerchandiseOngoingNegotiationsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseOngoingNegotiations
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };

        string expectedExplanation = "x";
        string expectedIssuerFirstNotifiedAt = "2019-12-27";
        string expectedStartedAt = "2019-12-27";

        Assert.Equal(expectedExplanation, model.Explanation);
        Assert.Equal(expectedIssuerFirstNotifiedAt, model.IssuerFirstNotifiedAt);
        Assert.Equal(expectedStartedAt, model.StartedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseOngoingNegotiations
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerQualityMerchandiseOngoingNegotiations>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseOngoingNegotiations
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerQualityMerchandiseOngoingNegotiations>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedExplanation = "x";
        string expectedIssuerFirstNotifiedAt = "2019-12-27";
        string expectedStartedAt = "2019-12-27";

        Assert.Equal(expectedExplanation, deserialized.Explanation);
        Assert.Equal(expectedIssuerFirstNotifiedAt, deserialized.IssuerFirstNotifiedAt);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseOngoingNegotiations
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseOngoingNegotiations
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };

        ChargebackConsumerQualityMerchandiseOngoingNegotiations copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerQualityMerchandiseReturnAttemptedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding;
        string expectedAttemptedAt = "2019-12-27";
        string expectedMerchandiseDisposition = "x";

        Assert.Equal(expectedAttemptExplanation, model.AttemptExplanation);
        Assert.Equal(expectedAttemptReason, model.AttemptReason);
        Assert.Equal(expectedAttemptedAt, model.AttemptedAt);
        Assert.Equal(expectedMerchandiseDisposition, model.MerchandiseDisposition);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerQualityMerchandiseReturnAttempted>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerQualityMerchandiseReturnAttempted>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding;
        string expectedAttemptedAt = "2019-12-27";
        string expectedMerchandiseDisposition = "x";

        Assert.Equal(expectedAttemptExplanation, deserialized.AttemptExplanation);
        Assert.Equal(expectedAttemptReason, deserialized.AttemptReason);
        Assert.Equal(expectedAttemptedAt, deserialized.AttemptedAt);
        Assert.Equal(expectedMerchandiseDisposition, deserialized.MerchandiseDisposition);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        ChargebackConsumerQualityMerchandiseReturnAttempted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReasonTest : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding
    )]
    [InlineData(
        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(
        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions
    )]
    [InlineData(
        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn
    )]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted)]
    public void Validation_Works(
        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding
    )]
    [InlineData(
        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(
        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions
    )]
    [InlineData(
        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn
    )]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnAttemptedAttemptReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerQualityMerchandiseReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ApiEnum<
            string,
            ChargebackConsumerQualityMerchandiseReturnedReturnMethod
        > expectedReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl;
        string expectedReturnedAt = "2019-12-27";
        string expectedMerchantReceivedReturnAt = "2019-12-27";
        string expectedOtherExplanation = "x";
        string expectedTrackingNumber = "x";

        Assert.Equal(expectedReturnMethod, model.ReturnMethod);
        Assert.Equal(expectedReturnedAt, model.ReturnedAt);
        Assert.Equal(expectedMerchantReceivedReturnAt, model.MerchantReceivedReturnAt);
        Assert.Equal(expectedOtherExplanation, model.OtherExplanation);
        Assert.Equal(expectedTrackingNumber, model.TrackingNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerQualityMerchandiseReturned>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerQualityMerchandiseReturned>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackConsumerQualityMerchandiseReturnedReturnMethod
        > expectedReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl;
        string expectedReturnedAt = "2019-12-27";
        string expectedMerchantReceivedReturnAt = "2019-12-27";
        string expectedOtherExplanation = "x";
        string expectedTrackingNumber = "x";

        Assert.Equal(expectedReturnMethod, deserialized.ReturnMethod);
        Assert.Equal(expectedReturnedAt, deserialized.ReturnedAt);
        Assert.Equal(expectedMerchantReceivedReturnAt, deserialized.MerchantReceivedReturnAt);
        Assert.Equal(expectedOtherExplanation, deserialized.OtherExplanation);
        Assert.Equal(expectedTrackingNumber, deserialized.TrackingNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
        };

        Assert.Null(model.MerchantReceivedReturnAt);
        Assert.False(model.RawData.ContainsKey("merchant_received_return_at"));
        Assert.Null(model.OtherExplanation);
        Assert.False(model.RawData.ContainsKey("other_explanation"));
        Assert.Null(model.TrackingNumber);
        Assert.False(model.RawData.ContainsKey("tracking_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            MerchantReceivedReturnAt = null,
            OtherExplanation = null,
            TrackingNumber = null,
        };

        Assert.Null(model.MerchantReceivedReturnAt);
        Assert.False(model.RawData.ContainsKey("merchant_received_return_at"));
        Assert.Null(model.OtherExplanation);
        Assert.False(model.RawData.ContainsKey("other_explanation"));
        Assert.Null(model.TrackingNumber);
        Assert.False(model.RawData.ContainsKey("tracking_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            MerchantReceivedReturnAt = null,
            OtherExplanation = null,
            TrackingNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ChargebackConsumerQualityMerchandiseReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerQualityMerchandiseReturnedReturnMethodTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl)]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnedReturnMethod.FaceToFace)]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Fedex)]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Other)]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnedReturnMethod.PostalService)]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Ups)]
    public void Validation_Works(ChargebackConsumerQualityMerchandiseReturnedReturnMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnedReturnMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Dhl)]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnedReturnMethod.FaceToFace)]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Fedex)]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Other)]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnedReturnMethod.PostalService)]
    [InlineData(ChargebackConsumerQualityMerchandiseReturnedReturnMethod.Ups)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerQualityMerchandiseReturnedReturnMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnedReturnMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityMerchandiseReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerQualityServicesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
            CardholderPaidToHaveWorkRedone =
                ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            RestaurantFoodRelated =
                ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
        };

        ChargebackConsumerQualityServicesCardholderCancellation expectedCardholderCancellation =
            new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            };
        ApiEnum<
            string,
            ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
        > expectedNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
            ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated;
        string expectedPurchaseInfoAndQualityIssue = "x";
        string expectedServicesReceivedAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone
        > expectedCardholderPaidToHaveWorkRedone =
            ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone;
        ChargebackConsumerQualityServicesOngoingNegotiations expectedOngoingNegotiations = new()
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };
        ApiEnum<
            string,
            ChargebackConsumerQualityServicesRestaurantFoodRelated
        > expectedRestaurantFoodRelated =
            ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated;

        Assert.Equal(expectedCardholderCancellation, model.CardholderCancellation);
        Assert.Equal(
            expectedNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription,
            model.NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
        );
        Assert.Equal(expectedPurchaseInfoAndQualityIssue, model.PurchaseInfoAndQualityIssue);
        Assert.Equal(expectedServicesReceivedAt, model.ServicesReceivedAt);
        Assert.Equal(expectedCardholderPaidToHaveWorkRedone, model.CardholderPaidToHaveWorkRedone);
        Assert.Equal(expectedOngoingNegotiations, model.OngoingNegotiations);
        Assert.Equal(expectedRestaurantFoodRelated, model.RestaurantFoodRelated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
            CardholderPaidToHaveWorkRedone =
                ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            RestaurantFoodRelated =
                ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerQualityServices>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
            CardholderPaidToHaveWorkRedone =
                ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            RestaurantFoodRelated =
                ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerQualityServices>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ChargebackConsumerQualityServicesCardholderCancellation expectedCardholderCancellation =
            new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            };
        ApiEnum<
            string,
            ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
        > expectedNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
            ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated;
        string expectedPurchaseInfoAndQualityIssue = "x";
        string expectedServicesReceivedAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone
        > expectedCardholderPaidToHaveWorkRedone =
            ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone;
        ChargebackConsumerQualityServicesOngoingNegotiations expectedOngoingNegotiations = new()
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };
        ApiEnum<
            string,
            ChargebackConsumerQualityServicesRestaurantFoodRelated
        > expectedRestaurantFoodRelated =
            ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated;

        Assert.Equal(expectedCardholderCancellation, deserialized.CardholderCancellation);
        Assert.Equal(
            expectedNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription,
            deserialized.NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
        );
        Assert.Equal(expectedPurchaseInfoAndQualityIssue, deserialized.PurchaseInfoAndQualityIssue);
        Assert.Equal(expectedServicesReceivedAt, deserialized.ServicesReceivedAt);
        Assert.Equal(
            expectedCardholderPaidToHaveWorkRedone,
            deserialized.CardholderPaidToHaveWorkRedone
        );
        Assert.Equal(expectedOngoingNegotiations, deserialized.OngoingNegotiations);
        Assert.Equal(expectedRestaurantFoodRelated, deserialized.RestaurantFoodRelated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
            CardholderPaidToHaveWorkRedone =
                ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            RestaurantFoodRelated =
                ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
        };

        Assert.Null(model.CardholderPaidToHaveWorkRedone);
        Assert.False(model.RawData.ContainsKey("cardholder_paid_to_have_work_redone"));
        Assert.Null(model.OngoingNegotiations);
        Assert.False(model.RawData.ContainsKey("ongoing_negotiations"));
        Assert.Null(model.RestaurantFoodRelated);
        Assert.False(model.RawData.ContainsKey("restaurant_food_related"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            CardholderPaidToHaveWorkRedone = null,
            OngoingNegotiations = null,
            RestaurantFoodRelated = null,
        };

        Assert.Null(model.CardholderPaidToHaveWorkRedone);
        Assert.False(model.RawData.ContainsKey("cardholder_paid_to_have_work_redone"));
        Assert.Null(model.OngoingNegotiations);
        Assert.False(model.RawData.ContainsKey("ongoing_negotiations"));
        Assert.Null(model.RestaurantFoodRelated);
        Assert.False(model.RawData.ContainsKey("restaurant_food_related"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            CardholderPaidToHaveWorkRedone = null,
            OngoingNegotiations = null,
            RestaurantFoodRelated = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
            CardholderPaidToHaveWorkRedone =
                ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            RestaurantFoodRelated =
                ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated,
        };

        ChargebackConsumerQualityServices copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerQualityServicesCardholderCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerQualityServicesCardholderCancellation
        {
            AcceptedByMerchant =
                ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        ApiEnum<
            string,
            ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant
        > expectedAcceptedByMerchant =
            ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted;
        string expectedCanceledAt = "2019-12-27";
        string expectedReason = "x";

        Assert.Equal(expectedAcceptedByMerchant, model.AcceptedByMerchant);
        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerQualityServicesCardholderCancellation
        {
            AcceptedByMerchant =
                ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerQualityServicesCardholderCancellation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerQualityServicesCardholderCancellation
        {
            AcceptedByMerchant =
                ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerQualityServicesCardholderCancellation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant
        > expectedAcceptedByMerchant =
            ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted;
        string expectedCanceledAt = "2019-12-27";
        string expectedReason = "x";

        Assert.Equal(expectedAcceptedByMerchant, deserialized.AcceptedByMerchant);
        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerQualityServicesCardholderCancellation
        {
            AcceptedByMerchant =
                ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerQualityServicesCardholderCancellation
        {
            AcceptedByMerchant =
                ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        ChargebackConsumerQualityServicesCardholderCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchantTest
    : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted)]
    [InlineData(
        ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.NotAccepted
    )]
    public void Validation_Works(
        ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.Accepted)]
    [InlineData(
        ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant.NotAccepted
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerQualityServicesCardholderCancellationAcceptedByMerchant
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescriptionTest
    : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated
    )]
    [InlineData(
        ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.Related
    )]
    public void Validation_Works(
        ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated
    )]
    [InlineData(
        ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.Related
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerQualityServicesNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedoneTest : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone
    )]
    [InlineData(
        ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.PaidToHaveWorkRedone
    )]
    public void Validation_Works(
        ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone
    )]
    [InlineData(
        ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone.PaidToHaveWorkRedone
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityServicesCardholderPaidToHaveWorkRedone>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerQualityServicesOngoingNegotiationsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerQualityServicesOngoingNegotiations
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };

        string expectedExplanation = "x";
        string expectedIssuerFirstNotifiedAt = "2019-12-27";
        string expectedStartedAt = "2019-12-27";

        Assert.Equal(expectedExplanation, model.Explanation);
        Assert.Equal(expectedIssuerFirstNotifiedAt, model.IssuerFirstNotifiedAt);
        Assert.Equal(expectedStartedAt, model.StartedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerQualityServicesOngoingNegotiations
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerQualityServicesOngoingNegotiations>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerQualityServicesOngoingNegotiations
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerQualityServicesOngoingNegotiations>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedExplanation = "x";
        string expectedIssuerFirstNotifiedAt = "2019-12-27";
        string expectedStartedAt = "2019-12-27";

        Assert.Equal(expectedExplanation, deserialized.Explanation);
        Assert.Equal(expectedIssuerFirstNotifiedAt, deserialized.IssuerFirstNotifiedAt);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerQualityServicesOngoingNegotiations
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerQualityServicesOngoingNegotiations
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };

        ChargebackConsumerQualityServicesOngoingNegotiations copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerQualityServicesRestaurantFoodRelatedTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated)]
    [InlineData(ChargebackConsumerQualityServicesRestaurantFoodRelated.Related)]
    public void Validation_Works(ChargebackConsumerQualityServicesRestaurantFoodRelated rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerQualityServicesRestaurantFoodRelated> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityServicesRestaurantFoodRelated>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerQualityServicesRestaurantFoodRelated.NotRelated)]
    [InlineData(ChargebackConsumerQualityServicesRestaurantFoodRelated.Related)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerQualityServicesRestaurantFoodRelated rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerQualityServicesRestaurantFoodRelated> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityServicesRestaurantFoodRelated>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityServicesRestaurantFoodRelated>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerQualityServicesRestaurantFoodRelated>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerServicesMisrepresentationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerServicesMisrepresentation
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantResolutionAttempted =
                ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        ChargebackConsumerServicesMisrepresentationCardholderCancellation expectedCardholderCancellation =
            new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            };
        ApiEnum<
            string,
            ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted;
        string expectedMisrepresentationExplanation = "x";
        string expectedPurchaseExplanation = "x";
        string expectedReceivedAt = "2019-12-27";

        Assert.Equal(expectedCardholderCancellation, model.CardholderCancellation);
        Assert.Equal(expectedMerchantResolutionAttempted, model.MerchantResolutionAttempted);
        Assert.Equal(expectedMisrepresentationExplanation, model.MisrepresentationExplanation);
        Assert.Equal(expectedPurchaseExplanation, model.PurchaseExplanation);
        Assert.Equal(expectedReceivedAt, model.ReceivedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerServicesMisrepresentation
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantResolutionAttempted =
                ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerServicesMisrepresentation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerServicesMisrepresentation
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantResolutionAttempted =
                ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerServicesMisrepresentation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ChargebackConsumerServicesMisrepresentationCardholderCancellation expectedCardholderCancellation =
            new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            };
        ApiEnum<
            string,
            ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted;
        string expectedMisrepresentationExplanation = "x";
        string expectedPurchaseExplanation = "x";
        string expectedReceivedAt = "2019-12-27";

        Assert.Equal(expectedCardholderCancellation, deserialized.CardholderCancellation);
        Assert.Equal(expectedMerchantResolutionAttempted, deserialized.MerchantResolutionAttempted);
        Assert.Equal(
            expectedMisrepresentationExplanation,
            deserialized.MisrepresentationExplanation
        );
        Assert.Equal(expectedPurchaseExplanation, deserialized.PurchaseExplanation);
        Assert.Equal(expectedReceivedAt, deserialized.ReceivedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerServicesMisrepresentation
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantResolutionAttempted =
                ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerServicesMisrepresentation
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantResolutionAttempted =
                ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        ChargebackConsumerServicesMisrepresentation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerServicesMisrepresentationCardholderCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerServicesMisrepresentationCardholderCancellation
        {
            AcceptedByMerchant =
                ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        ApiEnum<
            string,
            ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
        > expectedAcceptedByMerchant =
            ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted;
        string expectedCanceledAt = "2019-12-27";
        string expectedReason = "x";

        Assert.Equal(expectedAcceptedByMerchant, model.AcceptedByMerchant);
        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerServicesMisrepresentationCardholderCancellation
        {
            AcceptedByMerchant =
                ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerServicesMisrepresentationCardholderCancellation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerServicesMisrepresentationCardholderCancellation
        {
            AcceptedByMerchant =
                ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerServicesMisrepresentationCardholderCancellation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
        > expectedAcceptedByMerchant =
            ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted;
        string expectedCanceledAt = "2019-12-27";
        string expectedReason = "x";

        Assert.Equal(expectedAcceptedByMerchant, deserialized.AcceptedByMerchant);
        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerServicesMisrepresentationCardholderCancellation
        {
            AcceptedByMerchant =
                ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerServicesMisrepresentationCardholderCancellation
        {
            AcceptedByMerchant =
                ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        ChargebackConsumerServicesMisrepresentationCardholderCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchantTest
    : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted
    )]
    [InlineData(
        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.NotAccepted
    )]
    public void Validation_Works(
        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted
    )]
    [InlineData(
        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.NotAccepted
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerServicesMisrepresentationMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void Validation_Works(
        ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerServicesMisrepresentationMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerServicesNotAsDescribedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerServicesNotAsDescribed
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Explanation = "x",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
        };

        ChargebackConsumerServicesNotAsDescribedCardholderCancellation expectedCardholderCancellation =
            new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            };
        string expectedExplanation = "x";
        ApiEnum<
            string,
            ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted;
        string expectedReceivedAt = "2019-12-27";

        Assert.Equal(expectedCardholderCancellation, model.CardholderCancellation);
        Assert.Equal(expectedExplanation, model.Explanation);
        Assert.Equal(expectedMerchantResolutionAttempted, model.MerchantResolutionAttempted);
        Assert.Equal(expectedReceivedAt, model.ReceivedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerServicesNotAsDescribed
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Explanation = "x",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerServicesNotAsDescribed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerServicesNotAsDescribed
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Explanation = "x",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerServicesNotAsDescribed>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ChargebackConsumerServicesNotAsDescribedCardholderCancellation expectedCardholderCancellation =
            new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            };
        string expectedExplanation = "x";
        ApiEnum<
            string,
            ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted;
        string expectedReceivedAt = "2019-12-27";

        Assert.Equal(expectedCardholderCancellation, deserialized.CardholderCancellation);
        Assert.Equal(expectedExplanation, deserialized.Explanation);
        Assert.Equal(expectedMerchantResolutionAttempted, deserialized.MerchantResolutionAttempted);
        Assert.Equal(expectedReceivedAt, deserialized.ReceivedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerServicesNotAsDescribed
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Explanation = "x",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerServicesNotAsDescribed
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Explanation = "x",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
        };

        ChargebackConsumerServicesNotAsDescribed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerServicesNotAsDescribedCardholderCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerServicesNotAsDescribedCardholderCancellation
        {
            AcceptedByMerchant =
                ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        ApiEnum<
            string,
            ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
        > expectedAcceptedByMerchant =
            ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted;
        string expectedCanceledAt = "2019-12-27";
        string expectedReason = "x";

        Assert.Equal(expectedAcceptedByMerchant, model.AcceptedByMerchant);
        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerServicesNotAsDescribedCardholderCancellation
        {
            AcceptedByMerchant =
                ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerServicesNotAsDescribedCardholderCancellation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerServicesNotAsDescribedCardholderCancellation
        {
            AcceptedByMerchant =
                ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerServicesNotAsDescribedCardholderCancellation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
        > expectedAcceptedByMerchant =
            ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted;
        string expectedCanceledAt = "2019-12-27";
        string expectedReason = "x";

        Assert.Equal(expectedAcceptedByMerchant, deserialized.AcceptedByMerchant);
        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerServicesNotAsDescribedCardholderCancellation
        {
            AcceptedByMerchant =
                ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerServicesNotAsDescribedCardholderCancellation
        {
            AcceptedByMerchant =
                ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        ChargebackConsumerServicesNotAsDescribedCardholderCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchantTest
    : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted
    )]
    [InlineData(
        ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.NotAccepted
    )]
    public void Validation_Works(
        ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted
    )]
    [InlineData(
        ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.NotAccepted
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ChargebackConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void Validation_Works(
        ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerServicesNotAsDescribedMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerServicesNotReceivedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerServicesNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };

        ApiEnum<
            string,
            ChargebackConsumerServicesNotReceivedCancellationOutcome
        > expectedCancellationOutcome =
            ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt;
        string expectedLastExpectedReceiptAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted;
        string expectedPurchaseInfoAndExplanation = "x";
        ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt expectedCardholderCancellationPriorToExpectedReceipt =
            new() { CanceledAt = "2019-12-27", Reason = "x" };
        ChargebackConsumerServicesNotReceivedMerchantCancellation expectedMerchantCancellation =
            new("2019-12-27");
        ChargebackConsumerServicesNotReceivedNoCancellation expectedNoCancellation = new();

        Assert.Equal(expectedCancellationOutcome, model.CancellationOutcome);
        Assert.Equal(expectedLastExpectedReceiptAt, model.LastExpectedReceiptAt);
        Assert.Equal(expectedMerchantResolutionAttempted, model.MerchantResolutionAttempted);
        Assert.Equal(expectedPurchaseInfoAndExplanation, model.PurchaseInfoAndExplanation);
        Assert.Equal(
            expectedCardholderCancellationPriorToExpectedReceipt,
            model.CardholderCancellationPriorToExpectedReceipt
        );
        Assert.Equal(expectedMerchantCancellation, model.MerchantCancellation);
        Assert.Equal(expectedNoCancellation, model.NoCancellation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerServicesNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerServicesNotReceived>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerServicesNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackConsumerServicesNotReceived>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackConsumerServicesNotReceivedCancellationOutcome
        > expectedCancellationOutcome =
            ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt;
        string expectedLastExpectedReceiptAt = "2019-12-27";
        ApiEnum<
            string,
            ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted;
        string expectedPurchaseInfoAndExplanation = "x";
        ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt expectedCardholderCancellationPriorToExpectedReceipt =
            new() { CanceledAt = "2019-12-27", Reason = "x" };
        ChargebackConsumerServicesNotReceivedMerchantCancellation expectedMerchantCancellation =
            new("2019-12-27");
        ChargebackConsumerServicesNotReceivedNoCancellation expectedNoCancellation = new();

        Assert.Equal(expectedCancellationOutcome, deserialized.CancellationOutcome);
        Assert.Equal(expectedLastExpectedReceiptAt, deserialized.LastExpectedReceiptAt);
        Assert.Equal(expectedMerchantResolutionAttempted, deserialized.MerchantResolutionAttempted);
        Assert.Equal(expectedPurchaseInfoAndExplanation, deserialized.PurchaseInfoAndExplanation);
        Assert.Equal(
            expectedCardholderCancellationPriorToExpectedReceipt,
            deserialized.CardholderCancellationPriorToExpectedReceipt
        );
        Assert.Equal(expectedMerchantCancellation, deserialized.MerchantCancellation);
        Assert.Equal(expectedNoCancellation, deserialized.NoCancellation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerServicesNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackConsumerServicesNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
        };

        Assert.Null(model.CardholderCancellationPriorToExpectedReceipt);
        Assert.False(
            model.RawData.ContainsKey("cardholder_cancellation_prior_to_expected_receipt")
        );
        Assert.Null(model.MerchantCancellation);
        Assert.False(model.RawData.ContainsKey("merchant_cancellation"));
        Assert.Null(model.NoCancellation);
        Assert.False(model.RawData.ContainsKey("no_cancellation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackConsumerServicesNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackConsumerServicesNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",

            // Null should be interpreted as omitted for these properties
            CardholderCancellationPriorToExpectedReceipt = null,
            MerchantCancellation = null,
            NoCancellation = null,
        };

        Assert.Null(model.CardholderCancellationPriorToExpectedReceipt);
        Assert.False(
            model.RawData.ContainsKey("cardholder_cancellation_prior_to_expected_receipt")
        );
        Assert.Null(model.MerchantCancellation);
        Assert.False(model.RawData.ContainsKey("merchant_cancellation"));
        Assert.Null(model.NoCancellation);
        Assert.False(model.RawData.ContainsKey("no_cancellation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackConsumerServicesNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",

            // Null should be interpreted as omitted for these properties
            CardholderCancellationPriorToExpectedReceipt = null,
            MerchantCancellation = null,
            NoCancellation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerServicesNotReceived
        {
            CancellationOutcome =
                ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };

        ChargebackConsumerServicesNotReceived copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerServicesNotReceivedCancellationOutcomeTest : TestBase
{
    [Theory]
    [InlineData(
        ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt
    )]
    [InlineData(ChargebackConsumerServicesNotReceivedCancellationOutcome.MerchantCancellation)]
    [InlineData(ChargebackConsumerServicesNotReceivedCancellationOutcome.NoCancellation)]
    public void Validation_Works(ChargebackConsumerServicesNotReceivedCancellationOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerServicesNotReceivedCancellationOutcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerServicesNotReceivedCancellationOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ChargebackConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt
    )]
    [InlineData(ChargebackConsumerServicesNotReceivedCancellationOutcome.MerchantCancellation)]
    [InlineData(ChargebackConsumerServicesNotReceivedCancellationOutcome.NoCancellation)]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerServicesNotReceivedCancellationOutcome rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerServicesNotReceivedCancellationOutcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerServicesNotReceivedCancellationOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerServicesNotReceivedCancellationOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerServicesNotReceivedCancellationOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerServicesNotReceivedMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void Validation_Works(
        ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void SerializationRoundtrip_Works(
        ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackConsumerServicesNotReceivedMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceiptTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            };

        string expectedCanceledAt = "2019-12-27";
        string expectedReason = "x";

        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCanceledAt = "2019-12-27";
        string expectedReason = "x";

        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",
            };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",

                // Null should be interpreted as omitted for these properties
                Reason = null,
            };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model =
            new ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",

                // Null should be interpreted as omitted for these properties
                Reason = null,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            };

        ChargebackConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerServicesNotReceivedMerchantCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerServicesNotReceivedMerchantCancellation
        {
            CanceledAt = "2019-12-27",
        };

        string expectedCanceledAt = "2019-12-27";

        Assert.Equal(expectedCanceledAt, model.CanceledAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerServicesNotReceivedMerchantCancellation
        {
            CanceledAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerServicesNotReceivedMerchantCancellation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerServicesNotReceivedMerchantCancellation
        {
            CanceledAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerServicesNotReceivedMerchantCancellation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCanceledAt = "2019-12-27";

        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerServicesNotReceivedMerchantCancellation
        {
            CanceledAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerServicesNotReceivedMerchantCancellation
        {
            CanceledAt = "2019-12-27",
        };

        ChargebackConsumerServicesNotReceivedMerchantCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackConsumerServicesNotReceivedNoCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackConsumerServicesNotReceivedNoCancellation { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackConsumerServicesNotReceivedNoCancellation { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerServicesNotReceivedNoCancellation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackConsumerServicesNotReceivedNoCancellation { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackConsumerServicesNotReceivedNoCancellation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackConsumerServicesNotReceivedNoCancellation { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackConsumerServicesNotReceivedNoCancellation { };

        ChargebackConsumerServicesNotReceivedNoCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackFraudTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackFraud
        {
            FraudType = ChargebackFraudFraudType.AccountOrCredentialsTakeover,
        };

        ApiEnum<string, ChargebackFraudFraudType> expectedFraudType =
            ChargebackFraudFraudType.AccountOrCredentialsTakeover;

        Assert.Equal(expectedFraudType, model.FraudType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackFraud
        {
            FraudType = ChargebackFraudFraudType.AccountOrCredentialsTakeover,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackFraud>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackFraud
        {
            FraudType = ChargebackFraudFraudType.AccountOrCredentialsTakeover,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackFraud>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ChargebackFraudFraudType> expectedFraudType =
            ChargebackFraudFraudType.AccountOrCredentialsTakeover;

        Assert.Equal(expectedFraudType, deserialized.FraudType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackFraud
        {
            FraudType = ChargebackFraudFraudType.AccountOrCredentialsTakeover,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackFraud
        {
            FraudType = ChargebackFraudFraudType.AccountOrCredentialsTakeover,
        };

        ChargebackFraud copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackFraudFraudTypeTest : TestBase
{
    [Theory]
    [InlineData(ChargebackFraudFraudType.AccountOrCredentialsTakeover)]
    [InlineData(ChargebackFraudFraudType.CardNotReceivedAsIssued)]
    [InlineData(ChargebackFraudFraudType.FraudulentApplication)]
    [InlineData(ChargebackFraudFraudType.FraudulentUseOfAccountNumber)]
    [InlineData(ChargebackFraudFraudType.IncorrectProcessing)]
    [InlineData(ChargebackFraudFraudType.IssuerReportedCounterfeit)]
    [InlineData(ChargebackFraudFraudType.Lost)]
    [InlineData(ChargebackFraudFraudType.ManipulationOfAccountHolder)]
    [InlineData(ChargebackFraudFraudType.MerchantMisrepresentation)]
    [InlineData(ChargebackFraudFraudType.Miscellaneous)]
    [InlineData(ChargebackFraudFraudType.Stolen)]
    public void Validation_Works(ChargebackFraudFraudType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackFraudFraudType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargebackFraudFraudType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackFraudFraudType.AccountOrCredentialsTakeover)]
    [InlineData(ChargebackFraudFraudType.CardNotReceivedAsIssued)]
    [InlineData(ChargebackFraudFraudType.FraudulentApplication)]
    [InlineData(ChargebackFraudFraudType.FraudulentUseOfAccountNumber)]
    [InlineData(ChargebackFraudFraudType.IncorrectProcessing)]
    [InlineData(ChargebackFraudFraudType.IssuerReportedCounterfeit)]
    [InlineData(ChargebackFraudFraudType.Lost)]
    [InlineData(ChargebackFraudFraudType.ManipulationOfAccountHolder)]
    [InlineData(ChargebackFraudFraudType.MerchantMisrepresentation)]
    [InlineData(ChargebackFraudFraudType.Miscellaneous)]
    [InlineData(ChargebackFraudFraudType.Stolen)]
    public void SerializationRoundtrip_Works(ChargebackFraudFraudType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackFraudFraudType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargebackFraudFraudType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargebackFraudFraudType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargebackFraudFraudType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackProcessingErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackProcessingError
        {
            ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted =
                ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
            DuplicateTransaction = new("x"),
            IncorrectAmount = new(0),
            PaidByOtherMeans = new()
            {
                OtherFormOfPaymentEvidence =
                    ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                OtherTransactionID = "x",
            },
        };

        ApiEnum<string, ChargebackProcessingErrorErrorReason> expectedErrorReason =
            ChargebackProcessingErrorErrorReason.DuplicateTransaction;
        ApiEnum<
            string,
            ChargebackProcessingErrorMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackProcessingErrorMerchantResolutionAttempted.Attempted;
        ChargebackProcessingErrorDuplicateTransaction expectedDuplicateTransaction = new("x");
        ChargebackProcessingErrorIncorrectAmount expectedIncorrectAmount = new(0);
        ChargebackProcessingErrorPaidByOtherMeans expectedPaidByOtherMeans = new()
        {
            OtherFormOfPaymentEvidence =
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
            OtherTransactionID = "x",
        };

        Assert.Equal(expectedErrorReason, model.ErrorReason);
        Assert.Equal(expectedMerchantResolutionAttempted, model.MerchantResolutionAttempted);
        Assert.Equal(expectedDuplicateTransaction, model.DuplicateTransaction);
        Assert.Equal(expectedIncorrectAmount, model.IncorrectAmount);
        Assert.Equal(expectedPaidByOtherMeans, model.PaidByOtherMeans);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackProcessingError
        {
            ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted =
                ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
            DuplicateTransaction = new("x"),
            IncorrectAmount = new(0),
            PaidByOtherMeans = new()
            {
                OtherFormOfPaymentEvidence =
                    ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                OtherTransactionID = "x",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackProcessingError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackProcessingError
        {
            ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted =
                ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
            DuplicateTransaction = new("x"),
            IncorrectAmount = new(0),
            PaidByOtherMeans = new()
            {
                OtherFormOfPaymentEvidence =
                    ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                OtherTransactionID = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackProcessingError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ChargebackProcessingErrorErrorReason> expectedErrorReason =
            ChargebackProcessingErrorErrorReason.DuplicateTransaction;
        ApiEnum<
            string,
            ChargebackProcessingErrorMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ChargebackProcessingErrorMerchantResolutionAttempted.Attempted;
        ChargebackProcessingErrorDuplicateTransaction expectedDuplicateTransaction = new("x");
        ChargebackProcessingErrorIncorrectAmount expectedIncorrectAmount = new(0);
        ChargebackProcessingErrorPaidByOtherMeans expectedPaidByOtherMeans = new()
        {
            OtherFormOfPaymentEvidence =
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
            OtherTransactionID = "x",
        };

        Assert.Equal(expectedErrorReason, deserialized.ErrorReason);
        Assert.Equal(expectedMerchantResolutionAttempted, deserialized.MerchantResolutionAttempted);
        Assert.Equal(expectedDuplicateTransaction, deserialized.DuplicateTransaction);
        Assert.Equal(expectedIncorrectAmount, deserialized.IncorrectAmount);
        Assert.Equal(expectedPaidByOtherMeans, deserialized.PaidByOtherMeans);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackProcessingError
        {
            ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted =
                ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
            DuplicateTransaction = new("x"),
            IncorrectAmount = new(0),
            PaidByOtherMeans = new()
            {
                OtherFormOfPaymentEvidence =
                    ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                OtherTransactionID = "x",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackProcessingError
        {
            ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted =
                ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
        };

        Assert.Null(model.DuplicateTransaction);
        Assert.False(model.RawData.ContainsKey("duplicate_transaction"));
        Assert.Null(model.IncorrectAmount);
        Assert.False(model.RawData.ContainsKey("incorrect_amount"));
        Assert.Null(model.PaidByOtherMeans);
        Assert.False(model.RawData.ContainsKey("paid_by_other_means"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackProcessingError
        {
            ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted =
                ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackProcessingError
        {
            ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted =
                ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,

            // Null should be interpreted as omitted for these properties
            DuplicateTransaction = null,
            IncorrectAmount = null,
            PaidByOtherMeans = null,
        };

        Assert.Null(model.DuplicateTransaction);
        Assert.False(model.RawData.ContainsKey("duplicate_transaction"));
        Assert.Null(model.IncorrectAmount);
        Assert.False(model.RawData.ContainsKey("incorrect_amount"));
        Assert.Null(model.PaidByOtherMeans);
        Assert.False(model.RawData.ContainsKey("paid_by_other_means"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackProcessingError
        {
            ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted =
                ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,

            // Null should be interpreted as omitted for these properties
            DuplicateTransaction = null,
            IncorrectAmount = null,
            PaidByOtherMeans = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackProcessingError
        {
            ErrorReason = ChargebackProcessingErrorErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted =
                ChargebackProcessingErrorMerchantResolutionAttempted.Attempted,
            DuplicateTransaction = new("x"),
            IncorrectAmount = new(0),
            PaidByOtherMeans = new()
            {
                OtherFormOfPaymentEvidence =
                    ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
                OtherTransactionID = "x",
            },
        };

        ChargebackProcessingError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackProcessingErrorErrorReasonTest : TestBase
{
    [Theory]
    [InlineData(ChargebackProcessingErrorErrorReason.DuplicateTransaction)]
    [InlineData(ChargebackProcessingErrorErrorReason.IncorrectAmount)]
    [InlineData(ChargebackProcessingErrorErrorReason.PaidByOtherMeans)]
    public void Validation_Works(ChargebackProcessingErrorErrorReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackProcessingErrorErrorReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackProcessingErrorErrorReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackProcessingErrorErrorReason.DuplicateTransaction)]
    [InlineData(ChargebackProcessingErrorErrorReason.IncorrectAmount)]
    [InlineData(ChargebackProcessingErrorErrorReason.PaidByOtherMeans)]
    public void SerializationRoundtrip_Works(ChargebackProcessingErrorErrorReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackProcessingErrorErrorReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackProcessingErrorErrorReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackProcessingErrorErrorReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackProcessingErrorErrorReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackProcessingErrorMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ChargebackProcessingErrorMerchantResolutionAttempted.Attempted)]
    [InlineData(ChargebackProcessingErrorMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void Validation_Works(ChargebackProcessingErrorMerchantResolutionAttempted rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackProcessingErrorMerchantResolutionAttempted> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackProcessingErrorMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackProcessingErrorMerchantResolutionAttempted.Attempted)]
    [InlineData(ChargebackProcessingErrorMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void SerializationRoundtrip_Works(
        ChargebackProcessingErrorMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackProcessingErrorMerchantResolutionAttempted> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackProcessingErrorMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackProcessingErrorMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackProcessingErrorMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargebackProcessingErrorDuplicateTransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackProcessingErrorDuplicateTransaction { OtherTransactionID = "x" };

        string expectedOtherTransactionID = "x";

        Assert.Equal(expectedOtherTransactionID, model.OtherTransactionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackProcessingErrorDuplicateTransaction { OtherTransactionID = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackProcessingErrorDuplicateTransaction>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackProcessingErrorDuplicateTransaction { OtherTransactionID = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ChargebackProcessingErrorDuplicateTransaction>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedOtherTransactionID = "x";

        Assert.Equal(expectedOtherTransactionID, deserialized.OtherTransactionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackProcessingErrorDuplicateTransaction { OtherTransactionID = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackProcessingErrorDuplicateTransaction { OtherTransactionID = "x" };

        ChargebackProcessingErrorDuplicateTransaction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackProcessingErrorIncorrectAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackProcessingErrorIncorrectAmount { ExpectedAmount = 0 };

        long expectedExpectedAmount = 0;

        Assert.Equal(expectedExpectedAmount, model.ExpectedAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackProcessingErrorIncorrectAmount { ExpectedAmount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackProcessingErrorIncorrectAmount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackProcessingErrorIncorrectAmount { ExpectedAmount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackProcessingErrorIncorrectAmount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedExpectedAmount = 0;

        Assert.Equal(expectedExpectedAmount, deserialized.ExpectedAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackProcessingErrorIncorrectAmount { ExpectedAmount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackProcessingErrorIncorrectAmount { ExpectedAmount = 0 };

        ChargebackProcessingErrorIncorrectAmount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackProcessingErrorPaidByOtherMeansTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargebackProcessingErrorPaidByOtherMeans
        {
            OtherFormOfPaymentEvidence =
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
            OtherTransactionID = "x",
        };

        ApiEnum<
            string,
            ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence
        > expectedOtherFormOfPaymentEvidence =
            ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck;
        string expectedOtherTransactionID = "x";

        Assert.Equal(expectedOtherFormOfPaymentEvidence, model.OtherFormOfPaymentEvidence);
        Assert.Equal(expectedOtherTransactionID, model.OtherTransactionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargebackProcessingErrorPaidByOtherMeans
        {
            OtherFormOfPaymentEvidence =
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
            OtherTransactionID = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackProcessingErrorPaidByOtherMeans>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargebackProcessingErrorPaidByOtherMeans
        {
            OtherFormOfPaymentEvidence =
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
            OtherTransactionID = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargebackProcessingErrorPaidByOtherMeans>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence
        > expectedOtherFormOfPaymentEvidence =
            ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck;
        string expectedOtherTransactionID = "x";

        Assert.Equal(expectedOtherFormOfPaymentEvidence, deserialized.OtherFormOfPaymentEvidence);
        Assert.Equal(expectedOtherTransactionID, deserialized.OtherTransactionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargebackProcessingErrorPaidByOtherMeans
        {
            OtherFormOfPaymentEvidence =
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
            OtherTransactionID = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargebackProcessingErrorPaidByOtherMeans
        {
            OtherFormOfPaymentEvidence =
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
        };

        Assert.Null(model.OtherTransactionID);
        Assert.False(model.RawData.ContainsKey("other_transaction_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargebackProcessingErrorPaidByOtherMeans
        {
            OtherFormOfPaymentEvidence =
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChargebackProcessingErrorPaidByOtherMeans
        {
            OtherFormOfPaymentEvidence =
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,

            // Null should be interpreted as omitted for these properties
            OtherTransactionID = null,
        };

        Assert.Null(model.OtherTransactionID);
        Assert.False(model.RawData.ContainsKey("other_transaction_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargebackProcessingErrorPaidByOtherMeans
        {
            OtherFormOfPaymentEvidence =
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,

            // Null should be interpreted as omitted for these properties
            OtherTransactionID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargebackProcessingErrorPaidByOtherMeans
        {
            OtherFormOfPaymentEvidence =
                ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck,
            OtherTransactionID = "x",
        };

        ChargebackProcessingErrorPaidByOtherMeans copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidenceTest : TestBase
{
    [Theory]
    [InlineData(ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck)]
    [InlineData(
        ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CardTransaction
    )]
    [InlineData(ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CashReceipt)]
    [InlineData(ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Other)]
    [InlineData(ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Statement)]
    [InlineData(ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Voucher)]
    public void Validation_Works(
        ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CanceledCheck)]
    [InlineData(
        ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CardTransaction
    )]
    [InlineData(ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.CashReceipt)]
    [InlineData(ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Other)]
    [InlineData(ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Statement)]
    [InlineData(ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence.Voucher)]
    public void SerializationRoundtrip_Works(
        ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargebackProcessingErrorPaidByOtherMeansOtherFormOfPaymentEvidence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MerchantPrearbitrationDeclineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MerchantPrearbitrationDecline { Reason = "x" };

        string expectedReason = "x";

        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MerchantPrearbitrationDecline { Reason = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantPrearbitrationDecline>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MerchantPrearbitrationDecline { Reason = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantPrearbitrationDecline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedReason = "x";

        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MerchantPrearbitrationDecline { Reason = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MerchantPrearbitrationDecline { Reason = "x" };

        MerchantPrearbitrationDecline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserPrearbitrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserPrearbitration
        {
            Reason = "x",
            CategoryChange = new()
            {
                Category = CategoryChangeCategory.Authorization,
                Reason = "x",
            },
        };

        string expectedReason = "x";
        CategoryChange expectedCategoryChange = new()
        {
            Category = CategoryChangeCategory.Authorization,
            Reason = "x",
        };

        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedCategoryChange, model.CategoryChange);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserPrearbitration
        {
            Reason = "x",
            CategoryChange = new()
            {
                Category = CategoryChangeCategory.Authorization,
                Reason = "x",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserPrearbitration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserPrearbitration
        {
            Reason = "x",
            CategoryChange = new()
            {
                Category = CategoryChangeCategory.Authorization,
                Reason = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserPrearbitration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedReason = "x";
        CategoryChange expectedCategoryChange = new()
        {
            Category = CategoryChangeCategory.Authorization,
            Reason = "x",
        };

        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedCategoryChange, deserialized.CategoryChange);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserPrearbitration
        {
            Reason = "x",
            CategoryChange = new()
            {
                Category = CategoryChangeCategory.Authorization,
                Reason = "x",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserPrearbitration { Reason = "x" };

        Assert.Null(model.CategoryChange);
        Assert.False(model.RawData.ContainsKey("category_change"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserPrearbitration { Reason = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UserPrearbitration
        {
            Reason = "x",

            // Null should be interpreted as omitted for these properties
            CategoryChange = null,
        };

        Assert.Null(model.CategoryChange);
        Assert.False(model.RawData.ContainsKey("category_change"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserPrearbitration
        {
            Reason = "x",

            // Null should be interpreted as omitted for these properties
            CategoryChange = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserPrearbitration
        {
            Reason = "x",
            CategoryChange = new()
            {
                Category = CategoryChangeCategory.Authorization,
                Reason = "x",
            },
        };

        UserPrearbitration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryChangeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CategoryChange
        {
            Category = CategoryChangeCategory.Authorization,
            Reason = "x",
        };

        ApiEnum<string, CategoryChangeCategory> expectedCategory =
            CategoryChangeCategory.Authorization;
        string expectedReason = "x";

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CategoryChange
        {
            Category = CategoryChangeCategory.Authorization,
            Reason = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CategoryChange>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CategoryChange
        {
            Category = CategoryChangeCategory.Authorization,
            Reason = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CategoryChange>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CategoryChangeCategory> expectedCategory =
            CategoryChangeCategory.Authorization;
        string expectedReason = "x";

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CategoryChange
        {
            Category = CategoryChangeCategory.Authorization,
            Reason = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CategoryChange
        {
            Category = CategoryChangeCategory.Authorization,
            Reason = "x",
        };

        CategoryChange copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryChangeCategoryTest : TestBase
{
    [Theory]
    [InlineData(CategoryChangeCategory.Authorization)]
    [InlineData(CategoryChangeCategory.ConsumerCanceledMerchandise)]
    [InlineData(CategoryChangeCategory.ConsumerCanceledRecurringTransaction)]
    [InlineData(CategoryChangeCategory.ConsumerCanceledServices)]
    [InlineData(CategoryChangeCategory.ConsumerCounterfeitMerchandise)]
    [InlineData(CategoryChangeCategory.ConsumerCreditNotProcessed)]
    [InlineData(CategoryChangeCategory.ConsumerDamagedOrDefectiveMerchandise)]
    [InlineData(CategoryChangeCategory.ConsumerMerchandiseMisrepresentation)]
    [InlineData(CategoryChangeCategory.ConsumerMerchandiseNotAsDescribed)]
    [InlineData(CategoryChangeCategory.ConsumerMerchandiseNotReceived)]
    [InlineData(CategoryChangeCategory.ConsumerNonReceiptOfCash)]
    [InlineData(CategoryChangeCategory.ConsumerOriginalCreditTransactionNotAccepted)]
    [InlineData(CategoryChangeCategory.ConsumerQualityMerchandise)]
    [InlineData(CategoryChangeCategory.ConsumerQualityServices)]
    [InlineData(CategoryChangeCategory.ConsumerServicesMisrepresentation)]
    [InlineData(CategoryChangeCategory.ConsumerServicesNotAsDescribed)]
    [InlineData(CategoryChangeCategory.ConsumerServicesNotReceived)]
    [InlineData(CategoryChangeCategory.Fraud)]
    [InlineData(CategoryChangeCategory.ProcessingError)]
    public void Validation_Works(CategoryChangeCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CategoryChangeCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CategoryChangeCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CategoryChangeCategory.Authorization)]
    [InlineData(CategoryChangeCategory.ConsumerCanceledMerchandise)]
    [InlineData(CategoryChangeCategory.ConsumerCanceledRecurringTransaction)]
    [InlineData(CategoryChangeCategory.ConsumerCanceledServices)]
    [InlineData(CategoryChangeCategory.ConsumerCounterfeitMerchandise)]
    [InlineData(CategoryChangeCategory.ConsumerCreditNotProcessed)]
    [InlineData(CategoryChangeCategory.ConsumerDamagedOrDefectiveMerchandise)]
    [InlineData(CategoryChangeCategory.ConsumerMerchandiseMisrepresentation)]
    [InlineData(CategoryChangeCategory.ConsumerMerchandiseNotAsDescribed)]
    [InlineData(CategoryChangeCategory.ConsumerMerchandiseNotReceived)]
    [InlineData(CategoryChangeCategory.ConsumerNonReceiptOfCash)]
    [InlineData(CategoryChangeCategory.ConsumerOriginalCreditTransactionNotAccepted)]
    [InlineData(CategoryChangeCategory.ConsumerQualityMerchandise)]
    [InlineData(CategoryChangeCategory.ConsumerQualityServices)]
    [InlineData(CategoryChangeCategory.ConsumerServicesMisrepresentation)]
    [InlineData(CategoryChangeCategory.ConsumerServicesNotAsDescribed)]
    [InlineData(CategoryChangeCategory.ConsumerServicesNotReceived)]
    [InlineData(CategoryChangeCategory.Fraud)]
    [InlineData(CategoryChangeCategory.ProcessingError)]
    public void SerializationRoundtrip_Works(CategoryChangeCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CategoryChangeCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CategoryChangeCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CategoryChangeCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CategoryChangeCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
