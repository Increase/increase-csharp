using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CardDisputes;

namespace Increase.Api.Tests.Models.CardDisputes;

public class CardDisputeCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardDisputeCreateParams
        {
            DisputedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Network = Network.Visa,
            Amount = 100,
            AttachmentFiles = [new("file_id")],
            Explanation = "x",
            Visa = new()
            {
                Category = Category.Fraud,
                Authorization = new(AccountStatus.AccountClosed),
                ConsumerCanceledMerchandise = new()
                {
                    MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
                    PurchaseExplanation = "x",
                    ReceivedOrExpectedAt = "2019-12-27",
                    ReturnOutcome = ReturnOutcome.NotReturned,
                    CardholderCancellation = new()
                    {
                        CanceledAt = "2019-12-27",
                        CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
                        CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
                        Reason = "x",
                    },
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason = AttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod = ReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerCanceledRecurringTransaction = new()
                {
                    CancellationTarget = CancellationTarget.Account,
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
                            ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                        Reason = "x",
                    },
                    ContractedAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                    PurchaseExplanation = "x",
                    ServiceType = ServiceType.GuaranteedReservation,
                    GuaranteedReservation = new(Explanation.CardholderCanceledPriorToService),
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
                        ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                    OrderAndIssueExplanation = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseMisrepresentation = new()
                {
                    MerchantResolutionAttempted =
                        ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                    MisrepresentationExplanation = "x",
                    PurchaseExplanation = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseNotAsDescribed = new()
                {
                    MerchantResolutionAttempted =
                        ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseNotReceived = new()
                {
                    CancellationOutcome =
                        CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                    DeliveryIssue = DeliveryIssue.Delayed,
                    LastExpectedReceiptAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndExplanation = "x",
                    CardholderCancellationPriorToExpectedReceipt = new()
                    {
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    Delayed = new()
                    {
                        Explanation = "x",
                        ReturnOutcome = DelayedReturnOutcome.NotReturned,
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
                    Reason = Reason.ProhibitedByLocalLawsOrRegulation,
                },
                ConsumerQualityMerchandise = new()
                {
                    ExpectedAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndQualityIssue = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
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
                            ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
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
                        AcceptedByMerchant = AcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                        NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                    PurchaseInfoAndQualityIssue = "x",
                    ServicesReceivedAt = "2019-12-27",
                    CardholderPaidToHaveWorkRedone =
                        CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                    OngoingNegotiations = new()
                    {
                        Explanation = "x",
                        IssuerFirstNotifiedAt = "2019-12-27",
                        StartedAt = "2019-12-27",
                    },
                    RestaurantFoodRelated = RestaurantFoodRelated.NotRelated,
                },
                ConsumerServicesMisrepresentation = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    MerchantResolutionAttempted =
                        ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                    MisrepresentationExplanation = "x",
                    PurchaseExplanation = "x",
                    ReceivedAt = "2019-12-27",
                },
                ConsumerServicesNotAsDescribed = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    Explanation = "x",
                    MerchantResolutionAttempted =
                        ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                    ReceivedAt = "2019-12-27",
                },
                ConsumerServicesNotReceived = new()
                {
                    CancellationOutcome =
                        ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                    LastExpectedReceiptAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndExplanation = "x",
                    CardholderCancellationPriorToExpectedReceipt = new()
                    {
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    MerchantCancellation = new("2019-12-27"),
                    NoCancellation = new(),
                },
                Fraud = new(FraudType.AccountOrCredentialsTakeover),
                ProcessingError = new()
                {
                    ErrorReason = ErrorReason.DuplicateTransaction,
                    MerchantResolutionAttempted =
                        ProcessingErrorMerchantResolutionAttempted.Attempted,
                    DuplicateTransaction = new("x"),
                    IncorrectAmount = new(0),
                    PaidByOtherMeans = new()
                    {
                        OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
                        OtherTransactionID = "x",
                    },
                },
            },
        };

        string expectedDisputedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, Network> expectedNetwork = Network.Visa;
        long expectedAmount = 100;
        List<AttachmentFile> expectedAttachmentFiles = [new("file_id")];
        string expectedExplanation = "x";
        Visa expectedVisa = new()
        {
            Category = Category.Fraud,
            Authorization = new(AccountStatus.AccountClosed),
            ConsumerCanceledMerchandise = new()
            {
                MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ReceivedOrExpectedAt = "2019-12-27",
                ReturnOutcome = ReturnOutcome.NotReturned,
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
                    CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason = AttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerCanceledRecurringTransaction = new()
            {
                CancellationTarget = CancellationTarget.Account,
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
                        ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                ContractedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ServiceType = ServiceType.GuaranteedReservation,
                GuaranteedReservation = new(Explanation.CardholderCanceledPriorToService),
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
                    ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                OrderAndIssueExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseMisrepresentation = new()
            {
                MerchantResolutionAttempted =
                    ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotAsDescribed = new()
            {
                MerchantResolutionAttempted =
                    ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotReceived = new()
            {
                CancellationOutcome =
                    CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                DeliveryIssue = DeliveryIssue.Delayed,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Delayed = new()
                {
                    Explanation = "x",
                    ReturnOutcome = DelayedReturnOutcome.NotReturned,
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
                Reason = Reason.ProhibitedByLocalLawsOrRegulation,
            },
            ConsumerQualityMerchandise = new()
            {
                ExpectedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndQualityIssue = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
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
                        ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
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
                    AcceptedByMerchant = AcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                    NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                PurchaseInfoAndQualityIssue = "x",
                ServicesReceivedAt = "2019-12-27",
                CardholderPaidToHaveWorkRedone =
                    CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                RestaurantFoodRelated = RestaurantFoodRelated.NotRelated,
            },
            ConsumerServicesMisrepresentation = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantResolutionAttempted =
                    ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotAsDescribed = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Explanation = "x",
                MerchantResolutionAttempted =
                    ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotReceived = new()
            {
                CancellationOutcome =
                    ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            Fraud = new(FraudType.AccountOrCredentialsTakeover),
            ProcessingError = new()
            {
                ErrorReason = ErrorReason.DuplicateTransaction,
                MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,
                DuplicateTransaction = new("x"),
                IncorrectAmount = new(0),
                PaidByOtherMeans = new()
                {
                    OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
                    OtherTransactionID = "x",
                },
            },
        };

        Assert.Equal(expectedDisputedTransactionID, parameters.DisputedTransactionID);
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
        var parameters = new CardDisputeCreateParams
        {
            DisputedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Network = Network.Visa,
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
        var parameters = new CardDisputeCreateParams
        {
            DisputedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Network = Network.Visa,

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
        CardDisputeCreateParams parameters = new()
        {
            DisputedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Network = Network.Visa,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/card_disputes"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardDisputeCreateParams
        {
            DisputedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Network = Network.Visa,
            Amount = 100,
            AttachmentFiles = [new("file_id")],
            Explanation = "x",
            Visa = new()
            {
                Category = Category.Fraud,
                Authorization = new(AccountStatus.AccountClosed),
                ConsumerCanceledMerchandise = new()
                {
                    MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
                    PurchaseExplanation = "x",
                    ReceivedOrExpectedAt = "2019-12-27",
                    ReturnOutcome = ReturnOutcome.NotReturned,
                    CardholderCancellation = new()
                    {
                        CanceledAt = "2019-12-27",
                        CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
                        CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
                        Reason = "x",
                    },
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason = AttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod = ReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerCanceledRecurringTransaction = new()
                {
                    CancellationTarget = CancellationTarget.Account,
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
                            ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                        Reason = "x",
                    },
                    ContractedAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                    PurchaseExplanation = "x",
                    ServiceType = ServiceType.GuaranteedReservation,
                    GuaranteedReservation = new(Explanation.CardholderCanceledPriorToService),
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
                        ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                    OrderAndIssueExplanation = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod =
                            ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseMisrepresentation = new()
                {
                    MerchantResolutionAttempted =
                        ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                    MisrepresentationExplanation = "x",
                    PurchaseExplanation = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                    NotReturned = new(),
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseNotAsDescribed = new()
                {
                    MerchantResolutionAttempted =
                        ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                    ReturnAttempted = new()
                    {
                        AttemptExplanation = "x",
                        AttemptReason =
                            ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                        ReturnedAt = "2019-12-27",
                        MerchantReceivedReturnAt = "2019-12-27",
                        OtherExplanation = "x",
                        TrackingNumber = "x",
                    },
                },
                ConsumerMerchandiseNotReceived = new()
                {
                    CancellationOutcome =
                        CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                    DeliveryIssue = DeliveryIssue.Delayed,
                    LastExpectedReceiptAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndExplanation = "x",
                    CardholderCancellationPriorToExpectedReceipt = new()
                    {
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    Delayed = new()
                    {
                        Explanation = "x",
                        ReturnOutcome = DelayedReturnOutcome.NotReturned,
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
                    Reason = Reason.ProhibitedByLocalLawsOrRegulation,
                },
                ConsumerQualityMerchandise = new()
                {
                    ExpectedAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndQualityIssue = "x",
                    ReceivedAt = "2019-12-27",
                    ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
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
                            ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                        AttemptedAt = "2019-12-27",
                        MerchandiseDisposition = "x",
                    },
                    Returned = new()
                    {
                        ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
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
                        AcceptedByMerchant = AcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                        NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                    PurchaseInfoAndQualityIssue = "x",
                    ServicesReceivedAt = "2019-12-27",
                    CardholderPaidToHaveWorkRedone =
                        CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                    OngoingNegotiations = new()
                    {
                        Explanation = "x",
                        IssuerFirstNotifiedAt = "2019-12-27",
                        StartedAt = "2019-12-27",
                    },
                    RestaurantFoodRelated = RestaurantFoodRelated.NotRelated,
                },
                ConsumerServicesMisrepresentation = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    MerchantResolutionAttempted =
                        ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                    MisrepresentationExplanation = "x",
                    PurchaseExplanation = "x",
                    ReceivedAt = "2019-12-27",
                },
                ConsumerServicesNotAsDescribed = new()
                {
                    CardholderCancellation = new()
                    {
                        AcceptedByMerchant =
                            ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    Explanation = "x",
                    MerchantResolutionAttempted =
                        ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                    ReceivedAt = "2019-12-27",
                },
                ConsumerServicesNotReceived = new()
                {
                    CancellationOutcome =
                        ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                    LastExpectedReceiptAt = "2019-12-27",
                    MerchantResolutionAttempted =
                        ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                    PurchaseInfoAndExplanation = "x",
                    CardholderCancellationPriorToExpectedReceipt = new()
                    {
                        CanceledAt = "2019-12-27",
                        Reason = "x",
                    },
                    MerchantCancellation = new("2019-12-27"),
                    NoCancellation = new(),
                },
                Fraud = new(FraudType.AccountOrCredentialsTakeover),
                ProcessingError = new()
                {
                    ErrorReason = ErrorReason.DuplicateTransaction,
                    MerchantResolutionAttempted =
                        ProcessingErrorMerchantResolutionAttempted.Attempted,
                    DuplicateTransaction = new("x"),
                    IncorrectAmount = new(0),
                    PaidByOtherMeans = new()
                    {
                        OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
                        OtherTransactionID = "x",
                    },
                },
            },
        };

        CardDisputeCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class NetworkTest : TestBase
{
    [Theory]
    [InlineData(Network.Visa)]
    public void Validation_Works(Network rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Network> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Network>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Network.Visa)]
    public void SerializationRoundtrip_Works(Network rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Network> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Network>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Network>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Network>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AttachmentFileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AttachmentFile { FileID = "file_id" };

        string expectedFileID = "file_id";

        Assert.Equal(expectedFileID, model.FileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AttachmentFile { FileID = "file_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttachmentFile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AttachmentFile { FileID = "file_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttachmentFile>(
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
        var model = new AttachmentFile { FileID = "file_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AttachmentFile { FileID = "file_id" };

        AttachmentFile copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VisaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Visa
        {
            Category = Category.Authorization,
            Authorization = new(AccountStatus.AccountClosed),
            ConsumerCanceledMerchandise = new()
            {
                MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ReceivedOrExpectedAt = "2019-12-27",
                ReturnOutcome = ReturnOutcome.NotReturned,
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
                    CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason = AttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerCanceledRecurringTransaction = new()
            {
                CancellationTarget = CancellationTarget.Account,
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
                        ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                ContractedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ServiceType = ServiceType.GuaranteedReservation,
                GuaranteedReservation = new(Explanation.CardholderCanceledPriorToService),
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
                    ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                OrderAndIssueExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseMisrepresentation = new()
            {
                MerchantResolutionAttempted =
                    ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotAsDescribed = new()
            {
                MerchantResolutionAttempted =
                    ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotReceived = new()
            {
                CancellationOutcome =
                    CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                DeliveryIssue = DeliveryIssue.Delayed,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Delayed = new()
                {
                    Explanation = "x",
                    ReturnOutcome = DelayedReturnOutcome.NotReturned,
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
                Reason = Reason.ProhibitedByLocalLawsOrRegulation,
            },
            ConsumerQualityMerchandise = new()
            {
                ExpectedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndQualityIssue = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
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
                        ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
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
                    AcceptedByMerchant = AcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                    NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                PurchaseInfoAndQualityIssue = "x",
                ServicesReceivedAt = "2019-12-27",
                CardholderPaidToHaveWorkRedone =
                    CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                RestaurantFoodRelated = RestaurantFoodRelated.NotRelated,
            },
            ConsumerServicesMisrepresentation = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantResolutionAttempted =
                    ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotAsDescribed = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Explanation = "x",
                MerchantResolutionAttempted =
                    ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotReceived = new()
            {
                CancellationOutcome =
                    ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            Fraud = new(FraudType.AccountOrCredentialsTakeover),
            ProcessingError = new()
            {
                ErrorReason = ErrorReason.DuplicateTransaction,
                MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,
                DuplicateTransaction = new("x"),
                IncorrectAmount = new(0),
                PaidByOtherMeans = new()
                {
                    OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
                    OtherTransactionID = "x",
                },
            },
        };

        ApiEnum<string, Category> expectedCategory = Category.Authorization;
        Authorization expectedAuthorization = new(AccountStatus.AccountClosed);
        ConsumerCanceledMerchandise expectedConsumerCanceledMerchandise = new()
        {
            MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ReturnOutcome.NotReturned,
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
                CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason = AttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };
        ConsumerCanceledRecurringTransaction expectedConsumerCanceledRecurringTransaction = new()
        {
            CancellationTarget = CancellationTarget.Account,
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
        ConsumerCanceledServices expectedConsumerCanceledServices = new()
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ServiceType.GuaranteedReservation,
            GuaranteedReservation = new(Explanation.CardholderCanceledPriorToService),
            Other = new(),
            Timeshare = new(),
        };
        ConsumerCounterfeitMerchandise expectedConsumerCounterfeitMerchandise = new()
        {
            CounterfeitExplanation = "x",
            DispositionExplanation = "x",
            OrderExplanation = "x",
            ReceivedAt = "2019-12-27",
        };
        ConsumerCreditNotProcessed expectedConsumerCreditNotProcessed = new()
        {
            CanceledOrReturnedAt = "2019-12-27",
            CreditExpectedAt = "2019-12-27",
        };
        ConsumerDamagedOrDefectiveMerchandise expectedConsumerDamagedOrDefectiveMerchandise = new()
        {
            MerchantResolutionAttempted =
                ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };
        ConsumerMerchandiseMisrepresentation expectedConsumerMerchandiseMisrepresentation = new()
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };
        ConsumerMerchandiseNotAsDescribed expectedConsumerMerchandiseNotAsDescribed = new()
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };
        ConsumerMerchandiseNotReceived expectedConsumerMerchandiseNotReceived = new()
        {
            CancellationOutcome = CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = DeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Delayed = new()
            {
                Explanation = "x",
                ReturnOutcome = DelayedReturnOutcome.NotReturned,
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
        ConsumerNonReceiptOfCash expectedConsumerNonReceiptOfCash = new();
        ConsumerOriginalCreditTransactionNotAccepted expectedConsumerOriginalCreditTransactionNotAccepted =
            new() { Explanation = "x", Reason = Reason.ProhibitedByLocalLawsOrRegulation };
        ConsumerQualityMerchandise expectedConsumerQualityMerchandise = new()
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
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
                    ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };
        ConsumerQualityServices expectedConsumerQualityServices = new()
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant = AcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
            CardholderPaidToHaveWorkRedone =
                CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            RestaurantFoodRelated = RestaurantFoodRelated.NotRelated,
        };
        ConsumerServicesMisrepresentation expectedConsumerServicesMisrepresentation = new()
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantResolutionAttempted =
                ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
        };
        ConsumerServicesNotAsDescribed expectedConsumerServicesNotAsDescribed = new()
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Explanation = "x",
            MerchantResolutionAttempted =
                ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
        };
        ConsumerServicesNotReceived expectedConsumerServicesNotReceived = new()
        {
            CancellationOutcome =
                ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };
        Fraud expectedFraud = new(FraudType.AccountOrCredentialsTakeover);
        ProcessingError expectedProcessingError = new()
        {
            ErrorReason = ErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,
            DuplicateTransaction = new("x"),
            IncorrectAmount = new(0),
            PaidByOtherMeans = new()
            {
                OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
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
        var model = new Visa
        {
            Category = Category.Authorization,
            Authorization = new(AccountStatus.AccountClosed),
            ConsumerCanceledMerchandise = new()
            {
                MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ReceivedOrExpectedAt = "2019-12-27",
                ReturnOutcome = ReturnOutcome.NotReturned,
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
                    CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason = AttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerCanceledRecurringTransaction = new()
            {
                CancellationTarget = CancellationTarget.Account,
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
                        ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                ContractedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ServiceType = ServiceType.GuaranteedReservation,
                GuaranteedReservation = new(Explanation.CardholderCanceledPriorToService),
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
                    ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                OrderAndIssueExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseMisrepresentation = new()
            {
                MerchantResolutionAttempted =
                    ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotAsDescribed = new()
            {
                MerchantResolutionAttempted =
                    ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotReceived = new()
            {
                CancellationOutcome =
                    CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                DeliveryIssue = DeliveryIssue.Delayed,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Delayed = new()
                {
                    Explanation = "x",
                    ReturnOutcome = DelayedReturnOutcome.NotReturned,
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
                Reason = Reason.ProhibitedByLocalLawsOrRegulation,
            },
            ConsumerQualityMerchandise = new()
            {
                ExpectedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndQualityIssue = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
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
                        ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
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
                    AcceptedByMerchant = AcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                    NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                PurchaseInfoAndQualityIssue = "x",
                ServicesReceivedAt = "2019-12-27",
                CardholderPaidToHaveWorkRedone =
                    CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                RestaurantFoodRelated = RestaurantFoodRelated.NotRelated,
            },
            ConsumerServicesMisrepresentation = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantResolutionAttempted =
                    ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotAsDescribed = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Explanation = "x",
                MerchantResolutionAttempted =
                    ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotReceived = new()
            {
                CancellationOutcome =
                    ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            Fraud = new(FraudType.AccountOrCredentialsTakeover),
            ProcessingError = new()
            {
                ErrorReason = ErrorReason.DuplicateTransaction,
                MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,
                DuplicateTransaction = new("x"),
                IncorrectAmount = new(0),
                PaidByOtherMeans = new()
                {
                    OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
                    OtherTransactionID = "x",
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Visa>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Visa
        {
            Category = Category.Authorization,
            Authorization = new(AccountStatus.AccountClosed),
            ConsumerCanceledMerchandise = new()
            {
                MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ReceivedOrExpectedAt = "2019-12-27",
                ReturnOutcome = ReturnOutcome.NotReturned,
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
                    CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason = AttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerCanceledRecurringTransaction = new()
            {
                CancellationTarget = CancellationTarget.Account,
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
                        ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                ContractedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ServiceType = ServiceType.GuaranteedReservation,
                GuaranteedReservation = new(Explanation.CardholderCanceledPriorToService),
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
                    ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                OrderAndIssueExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseMisrepresentation = new()
            {
                MerchantResolutionAttempted =
                    ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotAsDescribed = new()
            {
                MerchantResolutionAttempted =
                    ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotReceived = new()
            {
                CancellationOutcome =
                    CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                DeliveryIssue = DeliveryIssue.Delayed,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Delayed = new()
                {
                    Explanation = "x",
                    ReturnOutcome = DelayedReturnOutcome.NotReturned,
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
                Reason = Reason.ProhibitedByLocalLawsOrRegulation,
            },
            ConsumerQualityMerchandise = new()
            {
                ExpectedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndQualityIssue = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
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
                        ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
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
                    AcceptedByMerchant = AcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                    NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                PurchaseInfoAndQualityIssue = "x",
                ServicesReceivedAt = "2019-12-27",
                CardholderPaidToHaveWorkRedone =
                    CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                RestaurantFoodRelated = RestaurantFoodRelated.NotRelated,
            },
            ConsumerServicesMisrepresentation = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantResolutionAttempted =
                    ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotAsDescribed = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Explanation = "x",
                MerchantResolutionAttempted =
                    ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotReceived = new()
            {
                CancellationOutcome =
                    ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            Fraud = new(FraudType.AccountOrCredentialsTakeover),
            ProcessingError = new()
            {
                ErrorReason = ErrorReason.DuplicateTransaction,
                MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,
                DuplicateTransaction = new("x"),
                IncorrectAmount = new(0),
                PaidByOtherMeans = new()
                {
                    OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
                    OtherTransactionID = "x",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Visa>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, Category> expectedCategory = Category.Authorization;
        Authorization expectedAuthorization = new(AccountStatus.AccountClosed);
        ConsumerCanceledMerchandise expectedConsumerCanceledMerchandise = new()
        {
            MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ReturnOutcome.NotReturned,
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
                CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason = AttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };
        ConsumerCanceledRecurringTransaction expectedConsumerCanceledRecurringTransaction = new()
        {
            CancellationTarget = CancellationTarget.Account,
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
        ConsumerCanceledServices expectedConsumerCanceledServices = new()
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ServiceType.GuaranteedReservation,
            GuaranteedReservation = new(Explanation.CardholderCanceledPriorToService),
            Other = new(),
            Timeshare = new(),
        };
        ConsumerCounterfeitMerchandise expectedConsumerCounterfeitMerchandise = new()
        {
            CounterfeitExplanation = "x",
            DispositionExplanation = "x",
            OrderExplanation = "x",
            ReceivedAt = "2019-12-27",
        };
        ConsumerCreditNotProcessed expectedConsumerCreditNotProcessed = new()
        {
            CanceledOrReturnedAt = "2019-12-27",
            CreditExpectedAt = "2019-12-27",
        };
        ConsumerDamagedOrDefectiveMerchandise expectedConsumerDamagedOrDefectiveMerchandise = new()
        {
            MerchantResolutionAttempted =
                ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };
        ConsumerMerchandiseMisrepresentation expectedConsumerMerchandiseMisrepresentation = new()
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };
        ConsumerMerchandiseNotAsDescribed expectedConsumerMerchandiseNotAsDescribed = new()
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };
        ConsumerMerchandiseNotReceived expectedConsumerMerchandiseNotReceived = new()
        {
            CancellationOutcome = CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = DeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Delayed = new()
            {
                Explanation = "x",
                ReturnOutcome = DelayedReturnOutcome.NotReturned,
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
        ConsumerNonReceiptOfCash expectedConsumerNonReceiptOfCash = new();
        ConsumerOriginalCreditTransactionNotAccepted expectedConsumerOriginalCreditTransactionNotAccepted =
            new() { Explanation = "x", Reason = Reason.ProhibitedByLocalLawsOrRegulation };
        ConsumerQualityMerchandise expectedConsumerQualityMerchandise = new()
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
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
                    ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };
        ConsumerQualityServices expectedConsumerQualityServices = new()
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant = AcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
            CardholderPaidToHaveWorkRedone =
                CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            RestaurantFoodRelated = RestaurantFoodRelated.NotRelated,
        };
        ConsumerServicesMisrepresentation expectedConsumerServicesMisrepresentation = new()
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantResolutionAttempted =
                ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
        };
        ConsumerServicesNotAsDescribed expectedConsumerServicesNotAsDescribed = new()
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Explanation = "x",
            MerchantResolutionAttempted =
                ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
        };
        ConsumerServicesNotReceived expectedConsumerServicesNotReceived = new()
        {
            CancellationOutcome =
                ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };
        Fraud expectedFraud = new(FraudType.AccountOrCredentialsTakeover);
        ProcessingError expectedProcessingError = new()
        {
            ErrorReason = ErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,
            DuplicateTransaction = new("x"),
            IncorrectAmount = new(0),
            PaidByOtherMeans = new()
            {
                OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
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
        var model = new Visa
        {
            Category = Category.Authorization,
            Authorization = new(AccountStatus.AccountClosed),
            ConsumerCanceledMerchandise = new()
            {
                MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ReceivedOrExpectedAt = "2019-12-27",
                ReturnOutcome = ReturnOutcome.NotReturned,
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
                    CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason = AttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerCanceledRecurringTransaction = new()
            {
                CancellationTarget = CancellationTarget.Account,
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
                        ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                ContractedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ServiceType = ServiceType.GuaranteedReservation,
                GuaranteedReservation = new(Explanation.CardholderCanceledPriorToService),
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
                    ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                OrderAndIssueExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseMisrepresentation = new()
            {
                MerchantResolutionAttempted =
                    ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotAsDescribed = new()
            {
                MerchantResolutionAttempted =
                    ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotReceived = new()
            {
                CancellationOutcome =
                    CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                DeliveryIssue = DeliveryIssue.Delayed,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Delayed = new()
                {
                    Explanation = "x",
                    ReturnOutcome = DelayedReturnOutcome.NotReturned,
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
                Reason = Reason.ProhibitedByLocalLawsOrRegulation,
            },
            ConsumerQualityMerchandise = new()
            {
                ExpectedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndQualityIssue = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
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
                        ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
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
                    AcceptedByMerchant = AcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                    NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                PurchaseInfoAndQualityIssue = "x",
                ServicesReceivedAt = "2019-12-27",
                CardholderPaidToHaveWorkRedone =
                    CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                RestaurantFoodRelated = RestaurantFoodRelated.NotRelated,
            },
            ConsumerServicesMisrepresentation = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantResolutionAttempted =
                    ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotAsDescribed = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Explanation = "x",
                MerchantResolutionAttempted =
                    ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotReceived = new()
            {
                CancellationOutcome =
                    ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            Fraud = new(FraudType.AccountOrCredentialsTakeover),
            ProcessingError = new()
            {
                ErrorReason = ErrorReason.DuplicateTransaction,
                MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,
                DuplicateTransaction = new("x"),
                IncorrectAmount = new(0),
                PaidByOtherMeans = new()
                {
                    OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
                    OtherTransactionID = "x",
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Visa { Category = Category.Authorization };

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
        var model = new Visa { Category = Category.Authorization };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Visa
        {
            Category = Category.Authorization,

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
        var model = new Visa
        {
            Category = Category.Authorization,

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
        var model = new Visa
        {
            Category = Category.Authorization,
            Authorization = new(AccountStatus.AccountClosed),
            ConsumerCanceledMerchandise = new()
            {
                MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ReceivedOrExpectedAt = "2019-12-27",
                ReturnOutcome = ReturnOutcome.NotReturned,
                CardholderCancellation = new()
                {
                    CanceledAt = "2019-12-27",
                    CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
                    CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason = AttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerCanceledRecurringTransaction = new()
            {
                CancellationTarget = CancellationTarget.Account,
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
                        ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                    Reason = "x",
                },
                ContractedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
                PurchaseExplanation = "x",
                ServiceType = ServiceType.GuaranteedReservation,
                GuaranteedReservation = new(Explanation.CardholderCanceledPriorToService),
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
                    ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
                OrderAndIssueExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseMisrepresentation = new()
            {
                MerchantResolutionAttempted =
                    ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
                NotReturned = new(),
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotAsDescribed = new()
            {
                MerchantResolutionAttempted =
                    ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
                ReturnAttempted = new()
                {
                    AttemptExplanation = "x",
                    AttemptReason =
                        ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                    ReturnedAt = "2019-12-27",
                    MerchantReceivedReturnAt = "2019-12-27",
                    OtherExplanation = "x",
                    TrackingNumber = "x",
                },
            },
            ConsumerMerchandiseNotReceived = new()
            {
                CancellationOutcome =
                    CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                DeliveryIssue = DeliveryIssue.Delayed,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Delayed = new()
                {
                    Explanation = "x",
                    ReturnOutcome = DelayedReturnOutcome.NotReturned,
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
                Reason = Reason.ProhibitedByLocalLawsOrRegulation,
            },
            ConsumerQualityMerchandise = new()
            {
                ExpectedAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndQualityIssue = "x",
                ReceivedAt = "2019-12-27",
                ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
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
                        ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                    AttemptedAt = "2019-12-27",
                    MerchandiseDisposition = "x",
                },
                Returned = new()
                {
                    ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
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
                    AcceptedByMerchant = AcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                    NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
                PurchaseInfoAndQualityIssue = "x",
                ServicesReceivedAt = "2019-12-27",
                CardholderPaidToHaveWorkRedone =
                    CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
                OngoingNegotiations = new()
                {
                    Explanation = "x",
                    IssuerFirstNotifiedAt = "2019-12-27",
                    StartedAt = "2019-12-27",
                },
                RestaurantFoodRelated = RestaurantFoodRelated.NotRelated,
            },
            ConsumerServicesMisrepresentation = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantResolutionAttempted =
                    ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
                MisrepresentationExplanation = "x",
                PurchaseExplanation = "x",
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotAsDescribed = new()
            {
                CardholderCancellation = new()
                {
                    AcceptedByMerchant =
                        ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                Explanation = "x",
                MerchantResolutionAttempted =
                    ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
                ReceivedAt = "2019-12-27",
            },
            ConsumerServicesNotReceived = new()
            {
                CancellationOutcome =
                    ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
                LastExpectedReceiptAt = "2019-12-27",
                MerchantResolutionAttempted =
                    ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
                PurchaseInfoAndExplanation = "x",
                CardholderCancellationPriorToExpectedReceipt = new()
                {
                    CanceledAt = "2019-12-27",
                    Reason = "x",
                },
                MerchantCancellation = new("2019-12-27"),
                NoCancellation = new(),
            },
            Fraud = new(FraudType.AccountOrCredentialsTakeover),
            ProcessingError = new()
            {
                ErrorReason = ErrorReason.DuplicateTransaction,
                MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,
                DuplicateTransaction = new("x"),
                IncorrectAmount = new(0),
                PaidByOtherMeans = new()
                {
                    OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
                    OtherTransactionID = "x",
                },
            },
        };

        Visa copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.Authorization)]
    [InlineData(Category.ConsumerCanceledMerchandise)]
    [InlineData(Category.ConsumerCanceledRecurringTransaction)]
    [InlineData(Category.ConsumerCanceledServices)]
    [InlineData(Category.ConsumerCounterfeitMerchandise)]
    [InlineData(Category.ConsumerCreditNotProcessed)]
    [InlineData(Category.ConsumerDamagedOrDefectiveMerchandise)]
    [InlineData(Category.ConsumerMerchandiseMisrepresentation)]
    [InlineData(Category.ConsumerMerchandiseNotAsDescribed)]
    [InlineData(Category.ConsumerMerchandiseNotReceived)]
    [InlineData(Category.ConsumerNonReceiptOfCash)]
    [InlineData(Category.ConsumerOriginalCreditTransactionNotAccepted)]
    [InlineData(Category.ConsumerQualityMerchandise)]
    [InlineData(Category.ConsumerQualityServices)]
    [InlineData(Category.ConsumerServicesMisrepresentation)]
    [InlineData(Category.ConsumerServicesNotAsDescribed)]
    [InlineData(Category.ConsumerServicesNotReceived)]
    [InlineData(Category.Fraud)]
    [InlineData(Category.ProcessingError)]
    public void Validation_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Category.Authorization)]
    [InlineData(Category.ConsumerCanceledMerchandise)]
    [InlineData(Category.ConsumerCanceledRecurringTransaction)]
    [InlineData(Category.ConsumerCanceledServices)]
    [InlineData(Category.ConsumerCounterfeitMerchandise)]
    [InlineData(Category.ConsumerCreditNotProcessed)]
    [InlineData(Category.ConsumerDamagedOrDefectiveMerchandise)]
    [InlineData(Category.ConsumerMerchandiseMisrepresentation)]
    [InlineData(Category.ConsumerMerchandiseNotAsDescribed)]
    [InlineData(Category.ConsumerMerchandiseNotReceived)]
    [InlineData(Category.ConsumerNonReceiptOfCash)]
    [InlineData(Category.ConsumerOriginalCreditTransactionNotAccepted)]
    [InlineData(Category.ConsumerQualityMerchandise)]
    [InlineData(Category.ConsumerQualityServices)]
    [InlineData(Category.ConsumerServicesMisrepresentation)]
    [InlineData(Category.ConsumerServicesNotAsDescribed)]
    [InlineData(Category.ConsumerServicesNotReceived)]
    [InlineData(Category.Fraud)]
    [InlineData(Category.ProcessingError)]
    public void SerializationRoundtrip_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AuthorizationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Authorization { AccountStatus = AccountStatus.AccountClosed };

        ApiEnum<string, AccountStatus> expectedAccountStatus = AccountStatus.AccountClosed;

        Assert.Equal(expectedAccountStatus, model.AccountStatus);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Authorization { AccountStatus = AccountStatus.AccountClosed };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Authorization>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Authorization { AccountStatus = AccountStatus.AccountClosed };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Authorization>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AccountStatus> expectedAccountStatus = AccountStatus.AccountClosed;

        Assert.Equal(expectedAccountStatus, deserialized.AccountStatus);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Authorization { AccountStatus = AccountStatus.AccountClosed };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Authorization { AccountStatus = AccountStatus.AccountClosed };

        Authorization copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccountStatusTest : TestBase
{
    [Theory]
    [InlineData(AccountStatus.AccountClosed)]
    [InlineData(AccountStatus.CreditProblem)]
    [InlineData(AccountStatus.Fraud)]
    public void Validation_Works(AccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountStatus.AccountClosed)]
    [InlineData(AccountStatus.CreditProblem)]
    [InlineData(AccountStatus.Fraud)]
    public void SerializationRoundtrip_Works(AccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerCanceledMerchandiseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ReturnOutcome.NotReturned,
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
                CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason = AttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ApiEnum<string, MerchantResolutionAttempted> expectedMerchantResolutionAttempted =
            MerchantResolutionAttempted.Attempted;
        string expectedPurchaseExplanation = "x";
        string expectedReceivedOrExpectedAt = "2019-12-27";
        ApiEnum<string, ReturnOutcome> expectedReturnOutcome = ReturnOutcome.NotReturned;
        CardholderCancellation expectedCardholderCancellation = new()
        {
            CanceledAt = "2019-12-27",
            CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
            CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
            Reason = "x",
        };
        NotReturned expectedNotReturned = new();
        ReturnAttempted expectedReturnAttempted = new()
        {
            AttemptExplanation = "x",
            AttemptReason = AttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };
        Returned expectedReturned = new()
        {
            ReturnMethod = ReturnMethod.Dhl,
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
        var model = new ConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ReturnOutcome.NotReturned,
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
                CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason = AttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerCanceledMerchandise>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ReturnOutcome.NotReturned,
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
                CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason = AttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerCanceledMerchandise>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, MerchantResolutionAttempted> expectedMerchantResolutionAttempted =
            MerchantResolutionAttempted.Attempted;
        string expectedPurchaseExplanation = "x";
        string expectedReceivedOrExpectedAt = "2019-12-27";
        ApiEnum<string, ReturnOutcome> expectedReturnOutcome = ReturnOutcome.NotReturned;
        CardholderCancellation expectedCardholderCancellation = new()
        {
            CanceledAt = "2019-12-27",
            CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
            CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
            Reason = "x",
        };
        NotReturned expectedNotReturned = new();
        ReturnAttempted expectedReturnAttempted = new()
        {
            AttemptExplanation = "x",
            AttemptReason = AttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };
        Returned expectedReturned = new()
        {
            ReturnMethod = ReturnMethod.Dhl,
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
        var model = new ConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ReturnOutcome.NotReturned,
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
                CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason = AttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ReturnMethod.Dhl,
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
        var model = new ConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ReturnOutcome.NotReturned,
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
        var model = new ConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ReturnOutcome.NotReturned,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ReturnOutcome.NotReturned,

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
        var model = new ConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ReturnOutcome.NotReturned,

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
        var model = new ConsumerCanceledMerchandise
        {
            MerchantResolutionAttempted = MerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ReceivedOrExpectedAt = "2019-12-27",
            ReturnOutcome = ReturnOutcome.NotReturned,
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
                CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason = AttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ConsumerCanceledMerchandise copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(MerchantResolutionAttempted.Attempted)]
    [InlineData(MerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void Validation_Works(MerchantResolutionAttempted rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MerchantResolutionAttempted> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MerchantResolutionAttempted>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MerchantResolutionAttempted.Attempted)]
    [InlineData(MerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void SerializationRoundtrip_Works(MerchantResolutionAttempted rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MerchantResolutionAttempted> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MerchantResolutionAttempted>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MerchantResolutionAttempted>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MerchantResolutionAttempted>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ReturnOutcomeTest : TestBase
{
    [Theory]
    [InlineData(ReturnOutcome.NotReturned)]
    [InlineData(ReturnOutcome.Returned)]
    [InlineData(ReturnOutcome.ReturnAttempted)]
    public void Validation_Works(ReturnOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReturnOutcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ReturnOutcome>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ReturnOutcome.NotReturned)]
    [InlineData(ReturnOutcome.Returned)]
    [InlineData(ReturnOutcome.ReturnAttempted)]
    public void SerializationRoundtrip_Works(ReturnOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReturnOutcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ReturnOutcome>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ReturnOutcome>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ReturnOutcome>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CardholderCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
            CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        string expectedCanceledAt = "2019-12-27";
        ApiEnum<string, CanceledPriorToShipDate> expectedCanceledPriorToShipDate =
            CanceledPriorToShipDate.CanceledPriorToShipDate1;
        ApiEnum<string, CancellationPolicyProvided> expectedCancellationPolicyProvided =
            CancellationPolicyProvided.NotProvided;
        string expectedReason = "x";

        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Equal(expectedCanceledPriorToShipDate, model.CanceledPriorToShipDate);
        Assert.Equal(expectedCancellationPolicyProvided, model.CancellationPolicyProvided);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
            CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardholderCancellation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
            CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardholderCancellation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCanceledAt = "2019-12-27";
        ApiEnum<string, CanceledPriorToShipDate> expectedCanceledPriorToShipDate =
            CanceledPriorToShipDate.CanceledPriorToShipDate1;
        ApiEnum<string, CancellationPolicyProvided> expectedCancellationPolicyProvided =
            CancellationPolicyProvided.NotProvided;
        string expectedReason = "x";

        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Equal(expectedCanceledPriorToShipDate, deserialized.CanceledPriorToShipDate);
        Assert.Equal(expectedCancellationPolicyProvided, deserialized.CancellationPolicyProvided);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
            CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CanceledPriorToShipDate = CanceledPriorToShipDate.CanceledPriorToShipDate1,
            CancellationPolicyProvided = CancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        CardholderCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CanceledPriorToShipDateTest : TestBase
{
    [Theory]
    [InlineData(CanceledPriorToShipDate.CanceledPriorToShipDate1)]
    [InlineData(CanceledPriorToShipDate.NotCanceledPriorToShipDate)]
    public void Validation_Works(CanceledPriorToShipDate rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CanceledPriorToShipDate> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CanceledPriorToShipDate>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CanceledPriorToShipDate.CanceledPriorToShipDate1)]
    [InlineData(CanceledPriorToShipDate.NotCanceledPriorToShipDate)]
    public void SerializationRoundtrip_Works(CanceledPriorToShipDate rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CanceledPriorToShipDate> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CanceledPriorToShipDate>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CanceledPriorToShipDate>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CanceledPriorToShipDate>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CancellationPolicyProvidedTest : TestBase
{
    [Theory]
    [InlineData(CancellationPolicyProvided.NotProvided)]
    [InlineData(CancellationPolicyProvided.Provided)]
    public void Validation_Works(CancellationPolicyProvided rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancellationPolicyProvided> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancellationPolicyProvided>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CancellationPolicyProvided.NotProvided)]
    [InlineData(CancellationPolicyProvided.Provided)]
    public void SerializationRoundtrip_Works(CancellationPolicyProvided rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancellationPolicyProvided> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancellationPolicyProvided>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancellationPolicyProvided>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancellationPolicyProvided>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NotReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotReturned { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotReturned { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotReturned>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotReturned { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotReturned>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotReturned { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotReturned { };

        NotReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReturnAttemptedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason = AttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string expectedAttemptExplanation = "x";
        ApiEnum<string, AttemptReason> expectedAttemptReason = AttemptReason.MerchantNotResponding;
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
        var model = new ReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason = AttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReturnAttempted>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason = AttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReturnAttempted>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAttemptExplanation = "x";
        ApiEnum<string, AttemptReason> expectedAttemptReason = AttemptReason.MerchantNotResponding;
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
        var model = new ReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason = AttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason = AttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        ReturnAttempted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AttemptReasonTest : TestBase
{
    [Theory]
    [InlineData(AttemptReason.MerchantNotResponding)]
    [InlineData(AttemptReason.NoReturnAuthorizationProvided)]
    [InlineData(AttemptReason.NoReturnInstructions)]
    [InlineData(AttemptReason.RequestedNotToReturn)]
    [InlineData(AttemptReason.ReturnNotAccepted)]
    public void Validation_Works(AttemptReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AttemptReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AttemptReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AttemptReason.MerchantNotResponding)]
    [InlineData(AttemptReason.NoReturnAuthorizationProvided)]
    [InlineData(AttemptReason.NoReturnInstructions)]
    [InlineData(AttemptReason.RequestedNotToReturn)]
    [InlineData(AttemptReason.ReturnNotAccepted)]
    public void SerializationRoundtrip_Works(AttemptReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AttemptReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AttemptReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AttemptReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AttemptReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Returned
        {
            ReturnMethod = ReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ApiEnum<string, ReturnMethod> expectedReturnMethod = ReturnMethod.Dhl;
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
        var model = new Returned
        {
            ReturnMethod = ReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Returned>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Returned
        {
            ReturnMethod = ReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Returned>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ReturnMethod> expectedReturnMethod = ReturnMethod.Dhl;
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
        var model = new Returned
        {
            ReturnMethod = ReturnMethod.Dhl,
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
        var model = new Returned { ReturnMethod = ReturnMethod.Dhl, ReturnedAt = "2019-12-27" };

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
        var model = new Returned { ReturnMethod = ReturnMethod.Dhl, ReturnedAt = "2019-12-27" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Returned
        {
            ReturnMethod = ReturnMethod.Dhl,
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
        var model = new Returned
        {
            ReturnMethod = ReturnMethod.Dhl,
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
        var model = new Returned
        {
            ReturnMethod = ReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        Returned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReturnMethodTest : TestBase
{
    [Theory]
    [InlineData(ReturnMethod.Dhl)]
    [InlineData(ReturnMethod.FaceToFace)]
    [InlineData(ReturnMethod.Fedex)]
    [InlineData(ReturnMethod.Other)]
    [InlineData(ReturnMethod.PostalService)]
    [InlineData(ReturnMethod.Ups)]
    public void Validation_Works(ReturnMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReturnMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ReturnMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ReturnMethod.Dhl)]
    [InlineData(ReturnMethod.FaceToFace)]
    [InlineData(ReturnMethod.Fedex)]
    [InlineData(ReturnMethod.Other)]
    [InlineData(ReturnMethod.PostalService)]
    [InlineData(ReturnMethod.Ups)]
    public void SerializationRoundtrip_Works(ReturnMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReturnMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ReturnMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ReturnMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ReturnMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerCanceledRecurringTransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerCanceledRecurringTransaction
        {
            CancellationTarget = CancellationTarget.Account,
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

        ApiEnum<string, CancellationTarget> expectedCancellationTarget = CancellationTarget.Account;
        MerchantContactMethods expectedMerchantContactMethods = new()
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
        var model = new ConsumerCanceledRecurringTransaction
        {
            CancellationTarget = CancellationTarget.Account,
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
        var deserialized = JsonSerializer.Deserialize<ConsumerCanceledRecurringTransaction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerCanceledRecurringTransaction
        {
            CancellationTarget = CancellationTarget.Account,
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
        var deserialized = JsonSerializer.Deserialize<ConsumerCanceledRecurringTransaction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CancellationTarget> expectedCancellationTarget = CancellationTarget.Account;
        MerchantContactMethods expectedMerchantContactMethods = new()
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
        var model = new ConsumerCanceledRecurringTransaction
        {
            CancellationTarget = CancellationTarget.Account,
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
        var model = new ConsumerCanceledRecurringTransaction
        {
            CancellationTarget = CancellationTarget.Account,
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
        var model = new ConsumerCanceledRecurringTransaction
        {
            CancellationTarget = CancellationTarget.Account,
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
        var model = new ConsumerCanceledRecurringTransaction
        {
            CancellationTarget = CancellationTarget.Account,
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
        var model = new ConsumerCanceledRecurringTransaction
        {
            CancellationTarget = CancellationTarget.Account,
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
        var model = new ConsumerCanceledRecurringTransaction
        {
            CancellationTarget = CancellationTarget.Account,
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

        ConsumerCanceledRecurringTransaction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CancellationTargetTest : TestBase
{
    [Theory]
    [InlineData(CancellationTarget.Account)]
    [InlineData(CancellationTarget.Transaction)]
    public void Validation_Works(CancellationTarget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancellationTarget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancellationTarget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CancellationTarget.Account)]
    [InlineData(CancellationTarget.Transaction)]
    public void SerializationRoundtrip_Works(CancellationTarget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancellationTarget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancellationTarget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancellationTarget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancellationTarget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MerchantContactMethodsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MerchantContactMethods
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
        var model = new MerchantContactMethods
        {
            ApplicationName = "x",
            CallCenterPhoneNumber = "x",
            EmailAddress = "x",
            InPersonAddress = "x",
            MailingAddress = "x",
            TextPhoneNumber = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantContactMethods>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MerchantContactMethods
        {
            ApplicationName = "x",
            CallCenterPhoneNumber = "x",
            EmailAddress = "x",
            InPersonAddress = "x",
            MailingAddress = "x",
            TextPhoneNumber = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantContactMethods>(
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
        var model = new MerchantContactMethods
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
        var model = new MerchantContactMethods { };

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
        var model = new MerchantContactMethods { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MerchantContactMethods
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
        var model = new MerchantContactMethods
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
        var model = new MerchantContactMethods
        {
            ApplicationName = "x",
            CallCenterPhoneNumber = "x",
            EmailAddress = "x",
            InPersonAddress = "x",
            MailingAddress = "x",
            TextPhoneNumber = "x",
        };

        MerchantContactMethods copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerCanceledServicesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ServiceType.GuaranteedReservation,
            GuaranteedReservation = new(Explanation.CardholderCanceledPriorToService),
            Other = new(),
            Timeshare = new(),
        };

        ConsumerCanceledServicesCardholderCancellation expectedCardholderCancellation = new()
        {
            CanceledAt = "2019-12-27",
            CancellationPolicyProvided =
                ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };
        string expectedContractedAt = "2019-12-27";
        ApiEnum<
            string,
            ConsumerCanceledServicesMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerCanceledServicesMerchantResolutionAttempted.Attempted;
        string expectedPurchaseExplanation = "x";
        ApiEnum<string, ServiceType> expectedServiceType = ServiceType.GuaranteedReservation;
        GuaranteedReservation expectedGuaranteedReservation = new(
            Explanation.CardholderCanceledPriorToService
        );
        Other expectedOther = new();
        Timeshare expectedTimeshare = new();

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
        var model = new ConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ServiceType.GuaranteedReservation,
            GuaranteedReservation = new(Explanation.CardholderCanceledPriorToService),
            Other = new(),
            Timeshare = new(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerCanceledServices>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ServiceType.GuaranteedReservation,
            GuaranteedReservation = new(Explanation.CardholderCanceledPriorToService),
            Other = new(),
            Timeshare = new(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerCanceledServices>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ConsumerCanceledServicesCardholderCancellation expectedCardholderCancellation = new()
        {
            CanceledAt = "2019-12-27",
            CancellationPolicyProvided =
                ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };
        string expectedContractedAt = "2019-12-27";
        ApiEnum<
            string,
            ConsumerCanceledServicesMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerCanceledServicesMerchantResolutionAttempted.Attempted;
        string expectedPurchaseExplanation = "x";
        ApiEnum<string, ServiceType> expectedServiceType = ServiceType.GuaranteedReservation;
        GuaranteedReservation expectedGuaranteedReservation = new(
            Explanation.CardholderCanceledPriorToService
        );
        Other expectedOther = new();
        Timeshare expectedTimeshare = new();

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
        var model = new ConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ServiceType.GuaranteedReservation,
            GuaranteedReservation = new(Explanation.CardholderCanceledPriorToService),
            Other = new(),
            Timeshare = new(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ServiceType.GuaranteedReservation,
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
        var model = new ConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ServiceType.GuaranteedReservation,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ServiceType.GuaranteedReservation,

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
        var model = new ConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ServiceType.GuaranteedReservation,

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
        var model = new ConsumerCanceledServices
        {
            CardholderCancellation = new()
            {
                CanceledAt = "2019-12-27",
                CancellationPolicyProvided =
                    ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
                Reason = "x",
            },
            ContractedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerCanceledServicesMerchantResolutionAttempted.Attempted,
            PurchaseExplanation = "x",
            ServiceType = ServiceType.GuaranteedReservation,
            GuaranteedReservation = new(Explanation.CardholderCanceledPriorToService),
            Other = new(),
            Timeshare = new(),
        };

        ConsumerCanceledServices copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerCanceledServicesCardholderCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerCanceledServicesCardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CancellationPolicyProvided =
                ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        string expectedCanceledAt = "2019-12-27";
        ApiEnum<
            string,
            ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
        > expectedCancellationPolicyProvided =
            ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided;
        string expectedReason = "x";

        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Equal(expectedCancellationPolicyProvided, model.CancellationPolicyProvided);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConsumerCanceledServicesCardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CancellationPolicyProvided =
                ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerCanceledServicesCardholderCancellation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerCanceledServicesCardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CancellationPolicyProvided =
                ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerCanceledServicesCardholderCancellation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCanceledAt = "2019-12-27";
        ApiEnum<
            string,
            ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
        > expectedCancellationPolicyProvided =
            ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided;
        string expectedReason = "x";

        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Equal(expectedCancellationPolicyProvided, deserialized.CancellationPolicyProvided);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConsumerCanceledServicesCardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CancellationPolicyProvided =
                ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerCanceledServicesCardholderCancellation
        {
            CanceledAt = "2019-12-27",
            CancellationPolicyProvided =
                ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided,
            Reason = "x",
        };

        ConsumerCanceledServicesCardholderCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvidedTest : TestBase
{
    [Theory]
    [InlineData(
        ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided
    )]
    [InlineData(ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.Provided)]
    public void Validation_Works(
        ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.NotProvided
    )]
    [InlineData(ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided.Provided)]
    public void SerializationRoundtrip_Works(
        ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
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
                ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ConsumerCanceledServicesCardholderCancellationCancellationPolicyProvided
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerCanceledServicesMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ConsumerCanceledServicesMerchantResolutionAttempted.Attempted)]
    [InlineData(ConsumerCanceledServicesMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void Validation_Works(ConsumerCanceledServicesMerchantResolutionAttempted rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerCanceledServicesMerchantResolutionAttempted> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerCanceledServicesMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerCanceledServicesMerchantResolutionAttempted.Attempted)]
    [InlineData(ConsumerCanceledServicesMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void SerializationRoundtrip_Works(
        ConsumerCanceledServicesMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerCanceledServicesMerchantResolutionAttempted> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerCanceledServicesMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerCanceledServicesMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerCanceledServicesMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ServiceTypeTest : TestBase
{
    [Theory]
    [InlineData(ServiceType.GuaranteedReservation)]
    [InlineData(ServiceType.Other)]
    [InlineData(ServiceType.Timeshare)]
    public void Validation_Works(ServiceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServiceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ServiceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ServiceType.GuaranteedReservation)]
    [InlineData(ServiceType.Other)]
    [InlineData(ServiceType.Timeshare)]
    public void SerializationRoundtrip_Works(ServiceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServiceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ServiceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ServiceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ServiceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GuaranteedReservationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GuaranteedReservation
        {
            Explanation = Explanation.CardholderCanceledPriorToService,
        };

        ApiEnum<string, Explanation> expectedExplanation =
            Explanation.CardholderCanceledPriorToService;

        Assert.Equal(expectedExplanation, model.Explanation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GuaranteedReservation
        {
            Explanation = Explanation.CardholderCanceledPriorToService,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GuaranteedReservation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GuaranteedReservation
        {
            Explanation = Explanation.CardholderCanceledPriorToService,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GuaranteedReservation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Explanation> expectedExplanation =
            Explanation.CardholderCanceledPriorToService;

        Assert.Equal(expectedExplanation, deserialized.Explanation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GuaranteedReservation
        {
            Explanation = Explanation.CardholderCanceledPriorToService,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GuaranteedReservation
        {
            Explanation = Explanation.CardholderCanceledPriorToService,
        };

        GuaranteedReservation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExplanationTest : TestBase
{
    [Theory]
    [InlineData(Explanation.CardholderCanceledPriorToService)]
    [InlineData(Explanation.CardholderCancellationAttemptWithin24HoursOfConfirmation)]
    [InlineData(Explanation.MerchantBilledNoShow)]
    public void Validation_Works(Explanation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Explanation> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Explanation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Explanation.CardholderCanceledPriorToService)]
    [InlineData(Explanation.CardholderCancellationAttemptWithin24HoursOfConfirmation)]
    [InlineData(Explanation.MerchantBilledNoShow)]
    public void SerializationRoundtrip_Works(Explanation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Explanation> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Explanation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Explanation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Explanation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OtherTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Other { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Other { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Other>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Other { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Other>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Other { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Other { };

        Other copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TimeshareTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Timeshare { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Timeshare { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Timeshare>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Timeshare { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Timeshare>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Timeshare { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Timeshare { };

        Timeshare copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerCounterfeitMerchandiseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerCounterfeitMerchandise
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
        var model = new ConsumerCounterfeitMerchandise
        {
            CounterfeitExplanation = "x",
            DispositionExplanation = "x",
            OrderExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerCounterfeitMerchandise>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerCounterfeitMerchandise
        {
            CounterfeitExplanation = "x",
            DispositionExplanation = "x",
            OrderExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerCounterfeitMerchandise>(
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
        var model = new ConsumerCounterfeitMerchandise
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
        var model = new ConsumerCounterfeitMerchandise
        {
            CounterfeitExplanation = "x",
            DispositionExplanation = "x",
            OrderExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        ConsumerCounterfeitMerchandise copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerCreditNotProcessedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerCreditNotProcessed
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
        var model = new ConsumerCreditNotProcessed
        {
            CanceledOrReturnedAt = "2019-12-27",
            CreditExpectedAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerCreditNotProcessed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerCreditNotProcessed
        {
            CanceledOrReturnedAt = "2019-12-27",
            CreditExpectedAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerCreditNotProcessed>(
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
        var model = new ConsumerCreditNotProcessed
        {
            CanceledOrReturnedAt = "2019-12-27",
            CreditExpectedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConsumerCreditNotProcessed { };

        Assert.Null(model.CanceledOrReturnedAt);
        Assert.False(model.RawData.ContainsKey("canceled_or_returned_at"));
        Assert.Null(model.CreditExpectedAt);
        Assert.False(model.RawData.ContainsKey("credit_expected_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConsumerCreditNotProcessed { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConsumerCreditNotProcessed
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
        var model = new ConsumerCreditNotProcessed
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
        var model = new ConsumerCreditNotProcessed
        {
            CanceledOrReturnedAt = "2019-12-27",
            CreditExpectedAt = "2019-12-27",
        };

        ConsumerCreditNotProcessed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerDamagedOrDefectiveMerchandiseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ApiEnum<
            string,
            ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted;
        string expectedOrderAndIssueExplanation = "x";
        string expectedReceivedAt = "2019-12-27";
        ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnOutcome> expectedReturnOutcome =
            ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned;
        ConsumerDamagedOrDefectiveMerchandiseNotReturned expectedNotReturned = new();
        ConsumerDamagedOrDefectiveMerchandiseReturnAttempted expectedReturnAttempted = new()
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };
        ConsumerDamagedOrDefectiveMerchandiseReturned expectedReturned = new()
        {
            ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
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
        var model = new ConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerDamagedOrDefectiveMerchandise>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerDamagedOrDefectiveMerchandise>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted;
        string expectedOrderAndIssueExplanation = "x";
        string expectedReceivedAt = "2019-12-27";
        ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnOutcome> expectedReturnOutcome =
            ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned;
        ConsumerDamagedOrDefectiveMerchandiseNotReturned expectedNotReturned = new();
        ConsumerDamagedOrDefectiveMerchandiseReturnAttempted expectedReturnAttempted = new()
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };
        ConsumerDamagedOrDefectiveMerchandiseReturned expectedReturned = new()
        {
            ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
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
        var model = new ConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
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
        var model = new ConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
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
        var model = new ConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,

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
        var model = new ConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,

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
        var model = new ConsumerDamagedOrDefectiveMerchandise
        {
            MerchantResolutionAttempted =
                ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted,
            OrderAndIssueExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ConsumerDamagedOrDefectiveMerchandise copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void Validation_Works(
        ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void SerializationRoundtrip_Works(
        ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerDamagedOrDefectiveMerchandiseReturnOutcomeTest : TestBase
{
    [Theory]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned)]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.Returned)]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.ReturnAttempted)]
    public void Validation_Works(ConsumerDamagedOrDefectiveMerchandiseReturnOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnOutcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.NotReturned)]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.Returned)]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnOutcome.ReturnAttempted)]
    public void SerializationRoundtrip_Works(
        ConsumerDamagedOrDefectiveMerchandiseReturnOutcome rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnOutcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerDamagedOrDefectiveMerchandiseNotReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerDamagedOrDefectiveMerchandiseNotReturned { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConsumerDamagedOrDefectiveMerchandiseNotReturned { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerDamagedOrDefectiveMerchandiseNotReturned>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerDamagedOrDefectiveMerchandiseNotReturned { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerDamagedOrDefectiveMerchandiseNotReturned>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConsumerDamagedOrDefectiveMerchandiseNotReturned { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerDamagedOrDefectiveMerchandiseNotReturned { };

        ConsumerDamagedOrDefectiveMerchandiseNotReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerDamagedOrDefectiveMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding;
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
        var model = new ConsumerDamagedOrDefectiveMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerDamagedOrDefectiveMerchandiseReturnAttempted>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerDamagedOrDefectiveMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerDamagedOrDefectiveMerchandiseReturnAttempted>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding;
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
        var model = new ConsumerDamagedOrDefectiveMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerDamagedOrDefectiveMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        ConsumerDamagedOrDefectiveMerchandiseReturnAttempted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReasonTest : TestBase
{
    [Theory]
    [InlineData(
        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding
    )]
    [InlineData(
        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(
        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions
    )]
    [InlineData(
        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn
    )]
    [InlineData(
        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted
    )]
    public void Validation_Works(
        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding
    )]
    [InlineData(
        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(
        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions
    )]
    [InlineData(
        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn
    )]
    [InlineData(
        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted
    )]
    public void SerializationRoundtrip_Works(
        ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnAttemptedAttemptReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerDamagedOrDefectiveMerchandiseReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ApiEnum<
            string,
            ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod
        > expectedReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl;
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
        var model = new ConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerDamagedOrDefectiveMerchandiseReturned>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerDamagedOrDefectiveMerchandiseReturned>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod
        > expectedReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl;
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
        var model = new ConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
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
        var model = new ConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
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
        var model = new ConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
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
        var model = new ConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
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
        var model = new ConsumerDamagedOrDefectiveMerchandiseReturned
        {
            ReturnMethod = ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ConsumerDamagedOrDefectiveMerchandiseReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethodTest : TestBase
{
    [Theory]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl)]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.FaceToFace)]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Fedex)]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Other)]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.PostalService)]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Ups)]
    public void Validation_Works(ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Dhl)]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.FaceToFace)]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Fedex)]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Other)]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.PostalService)]
    [InlineData(ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod.Ups)]
    public void SerializationRoundtrip_Works(
        ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerDamagedOrDefectiveMerchandiseReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerMerchandiseMisrepresentationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ApiEnum<
            string,
            ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted;
        string expectedMisrepresentationExplanation = "x";
        string expectedPurchaseExplanation = "x";
        string expectedReceivedAt = "2019-12-27";
        ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnOutcome> expectedReturnOutcome =
            ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned;
        ConsumerMerchandiseMisrepresentationNotReturned expectedNotReturned = new();
        ConsumerMerchandiseMisrepresentationReturnAttempted expectedReturnAttempted = new()
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };
        ConsumerMerchandiseMisrepresentationReturned expectedReturned = new()
        {
            ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
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
        var model = new ConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerMerchandiseMisrepresentation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerMerchandiseMisrepresentation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted;
        string expectedMisrepresentationExplanation = "x";
        string expectedPurchaseExplanation = "x";
        string expectedReceivedAt = "2019-12-27";
        ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnOutcome> expectedReturnOutcome =
            ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned;
        ConsumerMerchandiseMisrepresentationNotReturned expectedNotReturned = new();
        ConsumerMerchandiseMisrepresentationReturnAttempted expectedReturnAttempted = new()
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };
        ConsumerMerchandiseMisrepresentationReturned expectedReturned = new()
        {
            ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
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
        var model = new ConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
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
        var model = new ConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
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
        var model = new ConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,

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
        var model = new ConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,

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
        var model = new ConsumerMerchandiseMisrepresentation
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ConsumerMerchandiseMisrepresentation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerMerchandiseMisrepresentationMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void Validation_Works(
        ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.Attempted)]
    [InlineData(
        ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw
    )]
    public void SerializationRoundtrip_Works(
        ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseMisrepresentationMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerMerchandiseMisrepresentationReturnOutcomeTest : TestBase
{
    [Theory]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned)]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnOutcome.Returned)]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnOutcome.ReturnAttempted)]
    public void Validation_Works(ConsumerMerchandiseMisrepresentationReturnOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnOutcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnOutcome.NotReturned)]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnOutcome.Returned)]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnOutcome.ReturnAttempted)]
    public void SerializationRoundtrip_Works(
        ConsumerMerchandiseMisrepresentationReturnOutcome rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnOutcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerMerchandiseMisrepresentationNotReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerMerchandiseMisrepresentationNotReturned { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConsumerMerchandiseMisrepresentationNotReturned { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerMerchandiseMisrepresentationNotReturned>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerMerchandiseMisrepresentationNotReturned { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerMerchandiseMisrepresentationNotReturned>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConsumerMerchandiseMisrepresentationNotReturned { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerMerchandiseMisrepresentationNotReturned { };

        ConsumerMerchandiseMisrepresentationNotReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerMerchandiseMisrepresentationReturnAttemptedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerMerchandiseMisrepresentationReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding;
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
        var model = new ConsumerMerchandiseMisrepresentationReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerMerchandiseMisrepresentationReturnAttempted>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerMerchandiseMisrepresentationReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerMerchandiseMisrepresentationReturnAttempted>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding;
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
        var model = new ConsumerMerchandiseMisrepresentationReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerMerchandiseMisrepresentationReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        ConsumerMerchandiseMisrepresentationReturnAttempted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReasonTest : TestBase
{
    [Theory]
    [InlineData(
        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding
    )]
    [InlineData(
        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(
        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnInstructions
    )]
    [InlineData(
        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.RequestedNotToReturn
    )]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.ReturnNotAccepted)]
    public void Validation_Works(
        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.MerchantNotResponding
    )]
    [InlineData(
        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(
        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.NoReturnInstructions
    )]
    [InlineData(
        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.RequestedNotToReturn
    )]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason.ReturnNotAccepted)]
    public void SerializationRoundtrip_Works(
        ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnAttemptedAttemptReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerMerchandiseMisrepresentationReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ApiEnum<
            string,
            ConsumerMerchandiseMisrepresentationReturnedReturnMethod
        > expectedReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl;
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
        var model = new ConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerMerchandiseMisrepresentationReturned>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerMerchandiseMisrepresentationReturned>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ConsumerMerchandiseMisrepresentationReturnedReturnMethod
        > expectedReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl;
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
        var model = new ConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
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
        var model = new ConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
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
        var model = new ConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
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
        var model = new ConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
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
        var model = new ConsumerMerchandiseMisrepresentationReturned
        {
            ReturnMethod = ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ConsumerMerchandiseMisrepresentationReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerMerchandiseMisrepresentationReturnedReturnMethodTest : TestBase
{
    [Theory]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl)]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnedReturnMethod.FaceToFace)]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Fedex)]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Other)]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnedReturnMethod.PostalService)]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Ups)]
    public void Validation_Works(ConsumerMerchandiseMisrepresentationReturnedReturnMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnedReturnMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Dhl)]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnedReturnMethod.FaceToFace)]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Fedex)]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Other)]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnedReturnMethod.PostalService)]
    [InlineData(ConsumerMerchandiseMisrepresentationReturnedReturnMethod.Ups)]
    public void SerializationRoundtrip_Works(
        ConsumerMerchandiseMisrepresentationReturnedReturnMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnedReturnMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseMisrepresentationReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerMerchandiseNotAsDescribedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ApiEnum<
            string,
            ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted;
        string expectedReceivedAt = "2019-12-27";
        ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnOutcome> expectedReturnOutcome =
            ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned;
        ConsumerMerchandiseNotAsDescribedReturnAttempted expectedReturnAttempted = new()
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };
        ConsumerMerchandiseNotAsDescribedReturned expectedReturned = new()
        {
            ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
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
        var model = new ConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerMerchandiseNotAsDescribed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerMerchandiseNotAsDescribed>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted;
        string expectedReceivedAt = "2019-12-27";
        ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnOutcome> expectedReturnOutcome =
            ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned;
        ConsumerMerchandiseNotAsDescribedReturnAttempted expectedReturnAttempted = new()
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };
        ConsumerMerchandiseNotAsDescribedReturned expectedReturned = new()
        {
            ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
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
        var model = new ConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
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
        var model = new ConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
        };

        Assert.Null(model.ReturnAttempted);
        Assert.False(model.RawData.ContainsKey("return_attempted"));
        Assert.Null(model.Returned);
        Assert.False(model.RawData.ContainsKey("returned"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,

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
        var model = new ConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,

            // Null should be interpreted as omitted for these properties
            ReturnAttempted = null,
            Returned = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerMerchandiseNotAsDescribed
        {
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned,
            ReturnAttempted = new()
            {
                AttemptExplanation = "x",
                AttemptReason =
                    ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ConsumerMerchandiseNotAsDescribed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerMerchandiseNotAsDescribedMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted)]
    [InlineData(ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void Validation_Works(
        ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.Attempted)]
    [InlineData(ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void SerializationRoundtrip_Works(
        ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotAsDescribedMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerMerchandiseNotAsDescribedReturnOutcomeTest : TestBase
{
    [Theory]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned)]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnOutcome.ReturnAttempted)]
    public void Validation_Works(ConsumerMerchandiseNotAsDescribedReturnOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnOutcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnOutcome.Returned)]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnOutcome.ReturnAttempted)]
    public void SerializationRoundtrip_Works(
        ConsumerMerchandiseNotAsDescribedReturnOutcome rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnOutcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerMerchandiseNotAsDescribedReturnAttemptedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerMerchandiseNotAsDescribedReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding;
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
        var model = new ConsumerMerchandiseNotAsDescribedReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerMerchandiseNotAsDescribedReturnAttempted>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerMerchandiseNotAsDescribedReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerMerchandiseNotAsDescribedReturnAttempted>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding;
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
        var model = new ConsumerMerchandiseNotAsDescribedReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerMerchandiseNotAsDescribedReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        ConsumerMerchandiseNotAsDescribedReturnAttempted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReasonTest : TestBase
{
    [Theory]
    [InlineData(
        ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding
    )]
    [InlineData(
        ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnInstructions)]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.RequestedNotToReturn)]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.ReturnNotAccepted)]
    public void Validation_Works(
        ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.MerchantNotResponding
    )]
    [InlineData(
        ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.NoReturnInstructions)]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.RequestedNotToReturn)]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason.ReturnNotAccepted)]
    public void SerializationRoundtrip_Works(
        ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnAttemptedAttemptReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerMerchandiseNotAsDescribedReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ApiEnum<
            string,
            ConsumerMerchandiseNotAsDescribedReturnedReturnMethod
        > expectedReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl;
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
        var model = new ConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerMerchandiseNotAsDescribedReturned>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerMerchandiseNotAsDescribedReturned>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ConsumerMerchandiseNotAsDescribedReturnedReturnMethod
        > expectedReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl;
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
        var model = new ConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
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
        var model = new ConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
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
        var model = new ConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
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
        var model = new ConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
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
        var model = new ConsumerMerchandiseNotAsDescribedReturned
        {
            ReturnMethod = ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ConsumerMerchandiseNotAsDescribedReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerMerchandiseNotAsDescribedReturnedReturnMethodTest : TestBase
{
    [Theory]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl)]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.FaceToFace)]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Fedex)]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Other)]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.PostalService)]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Ups)]
    public void Validation_Works(ConsumerMerchandiseNotAsDescribedReturnedReturnMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnedReturnMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Dhl)]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.FaceToFace)]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Fedex)]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Other)]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.PostalService)]
    [InlineData(ConsumerMerchandiseNotAsDescribedReturnedReturnMethod.Ups)]
    public void SerializationRoundtrip_Works(
        ConsumerMerchandiseNotAsDescribedReturnedReturnMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnedReturnMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotAsDescribedReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerMerchandiseNotReceivedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerMerchandiseNotReceived
        {
            CancellationOutcome = CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = DeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Delayed = new()
            {
                Explanation = "x",
                ReturnOutcome = DelayedReturnOutcome.NotReturned,
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

        ApiEnum<string, CancellationOutcome> expectedCancellationOutcome =
            CancellationOutcome.CardholderCancellationPriorToExpectedReceipt;
        ApiEnum<string, DeliveryIssue> expectedDeliveryIssue = DeliveryIssue.Delayed;
        string expectedLastExpectedReceiptAt = "2019-12-27";
        ApiEnum<
            string,
            ConsumerMerchandiseNotReceivedMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted;
        string expectedPurchaseInfoAndExplanation = "x";
        CardholderCancellationPriorToExpectedReceipt expectedCardholderCancellationPriorToExpectedReceipt =
            new() { CanceledAt = "2019-12-27", Reason = "x" };
        Delayed expectedDelayed = new()
        {
            Explanation = "x",
            ReturnOutcome = DelayedReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new("2019-12-27"),
            Returned = new() { MerchantReceivedReturnAt = "2019-12-27", ReturnedAt = "2019-12-27" },
        };
        DeliveredToWrongLocation expectedDeliveredToWrongLocation = new("x");
        MerchantCancellation expectedMerchantCancellation = new("2019-12-27");
        NoCancellation expectedNoCancellation = new();

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
        var model = new ConsumerMerchandiseNotReceived
        {
            CancellationOutcome = CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = DeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Delayed = new()
            {
                Explanation = "x",
                ReturnOutcome = DelayedReturnOutcome.NotReturned,
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
        var deserialized = JsonSerializer.Deserialize<ConsumerMerchandiseNotReceived>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerMerchandiseNotReceived
        {
            CancellationOutcome = CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = DeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Delayed = new()
            {
                Explanation = "x",
                ReturnOutcome = DelayedReturnOutcome.NotReturned,
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
        var deserialized = JsonSerializer.Deserialize<ConsumerMerchandiseNotReceived>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CancellationOutcome> expectedCancellationOutcome =
            CancellationOutcome.CardholderCancellationPriorToExpectedReceipt;
        ApiEnum<string, DeliveryIssue> expectedDeliveryIssue = DeliveryIssue.Delayed;
        string expectedLastExpectedReceiptAt = "2019-12-27";
        ApiEnum<
            string,
            ConsumerMerchandiseNotReceivedMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted;
        string expectedPurchaseInfoAndExplanation = "x";
        CardholderCancellationPriorToExpectedReceipt expectedCardholderCancellationPriorToExpectedReceipt =
            new() { CanceledAt = "2019-12-27", Reason = "x" };
        Delayed expectedDelayed = new()
        {
            Explanation = "x",
            ReturnOutcome = DelayedReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new("2019-12-27"),
            Returned = new() { MerchantReceivedReturnAt = "2019-12-27", ReturnedAt = "2019-12-27" },
        };
        DeliveredToWrongLocation expectedDeliveredToWrongLocation = new("x");
        MerchantCancellation expectedMerchantCancellation = new("2019-12-27");
        NoCancellation expectedNoCancellation = new();

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
        var model = new ConsumerMerchandiseNotReceived
        {
            CancellationOutcome = CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = DeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Delayed = new()
            {
                Explanation = "x",
                ReturnOutcome = DelayedReturnOutcome.NotReturned,
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
        var model = new ConsumerMerchandiseNotReceived
        {
            CancellationOutcome = CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = DeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
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
        var model = new ConsumerMerchandiseNotReceived
        {
            CancellationOutcome = CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = DeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConsumerMerchandiseNotReceived
        {
            CancellationOutcome = CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = DeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
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
        var model = new ConsumerMerchandiseNotReceived
        {
            CancellationOutcome = CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = DeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
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
        var model = new ConsumerMerchandiseNotReceived
        {
            CancellationOutcome = CancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            DeliveryIssue = DeliveryIssue.Delayed,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Delayed = new()
            {
                Explanation = "x",
                ReturnOutcome = DelayedReturnOutcome.NotReturned,
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

        ConsumerMerchandiseNotReceived copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CancellationOutcomeTest : TestBase
{
    [Theory]
    [InlineData(CancellationOutcome.CardholderCancellationPriorToExpectedReceipt)]
    [InlineData(CancellationOutcome.MerchantCancellation)]
    [InlineData(CancellationOutcome.NoCancellation)]
    public void Validation_Works(CancellationOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancellationOutcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancellationOutcome>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CancellationOutcome.CardholderCancellationPriorToExpectedReceipt)]
    [InlineData(CancellationOutcome.MerchantCancellation)]
    [InlineData(CancellationOutcome.NoCancellation)]
    public void SerializationRoundtrip_Works(CancellationOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancellationOutcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancellationOutcome>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancellationOutcome>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancellationOutcome>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DeliveryIssueTest : TestBase
{
    [Theory]
    [InlineData(DeliveryIssue.Delayed)]
    [InlineData(DeliveryIssue.DeliveredToWrongLocation)]
    public void Validation_Works(DeliveryIssue rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeliveryIssue> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeliveryIssue>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeliveryIssue.Delayed)]
    [InlineData(DeliveryIssue.DeliveredToWrongLocation)]
    public void SerializationRoundtrip_Works(DeliveryIssue rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeliveryIssue> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeliveryIssue>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeliveryIssue>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeliveryIssue>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerMerchandiseNotReceivedMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted)]
    [InlineData(ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void Validation_Works(ConsumerMerchandiseNotReceivedMerchantResolutionAttempted rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseNotReceivedMerchantResolutionAttempted> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotReceivedMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.Attempted)]
    [InlineData(ConsumerMerchandiseNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void SerializationRoundtrip_Works(
        ConsumerMerchandiseNotReceivedMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerMerchandiseNotReceivedMerchantResolutionAttempted> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotReceivedMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotReceivedMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerMerchandiseNotReceivedMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardholderCancellationPriorToExpectedReceiptTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardholderCancellationPriorToExpectedReceipt
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
        var model = new CardholderCancellationPriorToExpectedReceipt
        {
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardholderCancellationPriorToExpectedReceipt>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardholderCancellationPriorToExpectedReceipt
        {
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardholderCancellationPriorToExpectedReceipt>(
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
        var model = new CardholderCancellationPriorToExpectedReceipt
        {
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CardholderCancellationPriorToExpectedReceipt { CanceledAt = "2019-12-27" };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CardholderCancellationPriorToExpectedReceipt { CanceledAt = "2019-12-27" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CardholderCancellationPriorToExpectedReceipt
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
        var model = new CardholderCancellationPriorToExpectedReceipt
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
        var model = new CardholderCancellationPriorToExpectedReceipt
        {
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        CardholderCancellationPriorToExpectedReceipt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DelayedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Delayed
        {
            Explanation = "x",
            ReturnOutcome = DelayedReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new("2019-12-27"),
            Returned = new() { MerchantReceivedReturnAt = "2019-12-27", ReturnedAt = "2019-12-27" },
        };

        string expectedExplanation = "x";
        ApiEnum<string, DelayedReturnOutcome> expectedReturnOutcome =
            DelayedReturnOutcome.NotReturned;
        DelayedNotReturned expectedNotReturned = new();
        DelayedReturnAttempted expectedReturnAttempted = new("2019-12-27");
        DelayedReturned expectedReturned = new()
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
        var model = new Delayed
        {
            Explanation = "x",
            ReturnOutcome = DelayedReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new("2019-12-27"),
            Returned = new() { MerchantReceivedReturnAt = "2019-12-27", ReturnedAt = "2019-12-27" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delayed>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Delayed
        {
            Explanation = "x",
            ReturnOutcome = DelayedReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new("2019-12-27"),
            Returned = new() { MerchantReceivedReturnAt = "2019-12-27", ReturnedAt = "2019-12-27" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delayed>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExplanation = "x";
        ApiEnum<string, DelayedReturnOutcome> expectedReturnOutcome =
            DelayedReturnOutcome.NotReturned;
        DelayedNotReturned expectedNotReturned = new();
        DelayedReturnAttempted expectedReturnAttempted = new("2019-12-27");
        DelayedReturned expectedReturned = new()
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
        var model = new Delayed
        {
            Explanation = "x",
            ReturnOutcome = DelayedReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new("2019-12-27"),
            Returned = new() { MerchantReceivedReturnAt = "2019-12-27", ReturnedAt = "2019-12-27" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Delayed
        {
            Explanation = "x",
            ReturnOutcome = DelayedReturnOutcome.NotReturned,
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
        var model = new Delayed
        {
            Explanation = "x",
            ReturnOutcome = DelayedReturnOutcome.NotReturned,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Delayed
        {
            Explanation = "x",
            ReturnOutcome = DelayedReturnOutcome.NotReturned,

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
        var model = new Delayed
        {
            Explanation = "x",
            ReturnOutcome = DelayedReturnOutcome.NotReturned,

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
        var model = new Delayed
        {
            Explanation = "x",
            ReturnOutcome = DelayedReturnOutcome.NotReturned,
            NotReturned = new(),
            ReturnAttempted = new("2019-12-27"),
            Returned = new() { MerchantReceivedReturnAt = "2019-12-27", ReturnedAt = "2019-12-27" },
        };

        Delayed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DelayedReturnOutcomeTest : TestBase
{
    [Theory]
    [InlineData(DelayedReturnOutcome.NotReturned)]
    [InlineData(DelayedReturnOutcome.Returned)]
    [InlineData(DelayedReturnOutcome.ReturnAttempted)]
    public void Validation_Works(DelayedReturnOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DelayedReturnOutcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DelayedReturnOutcome>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DelayedReturnOutcome.NotReturned)]
    [InlineData(DelayedReturnOutcome.Returned)]
    [InlineData(DelayedReturnOutcome.ReturnAttempted)]
    public void SerializationRoundtrip_Works(DelayedReturnOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DelayedReturnOutcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DelayedReturnOutcome>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DelayedReturnOutcome>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DelayedReturnOutcome>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DelayedNotReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DelayedNotReturned { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DelayedNotReturned { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DelayedNotReturned>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DelayedNotReturned { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DelayedNotReturned>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DelayedNotReturned { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DelayedNotReturned { };

        DelayedNotReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DelayedReturnAttemptedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DelayedReturnAttempted { AttemptedAt = "2019-12-27" };

        string expectedAttemptedAt = "2019-12-27";

        Assert.Equal(expectedAttemptedAt, model.AttemptedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DelayedReturnAttempted { AttemptedAt = "2019-12-27" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DelayedReturnAttempted>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DelayedReturnAttempted { AttemptedAt = "2019-12-27" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DelayedReturnAttempted>(
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
        var model = new DelayedReturnAttempted { AttemptedAt = "2019-12-27" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DelayedReturnAttempted { AttemptedAt = "2019-12-27" };

        DelayedReturnAttempted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DelayedReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DelayedReturned
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
        var model = new DelayedReturned
        {
            MerchantReceivedReturnAt = "2019-12-27",
            ReturnedAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DelayedReturned>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DelayedReturned
        {
            MerchantReceivedReturnAt = "2019-12-27",
            ReturnedAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DelayedReturned>(
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
        var model = new DelayedReturned
        {
            MerchantReceivedReturnAt = "2019-12-27",
            ReturnedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DelayedReturned
        {
            MerchantReceivedReturnAt = "2019-12-27",
            ReturnedAt = "2019-12-27",
        };

        DelayedReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeliveredToWrongLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeliveredToWrongLocation { AgreedLocation = "x" };

        string expectedAgreedLocation = "x";

        Assert.Equal(expectedAgreedLocation, model.AgreedLocation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeliveredToWrongLocation { AgreedLocation = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeliveredToWrongLocation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeliveredToWrongLocation { AgreedLocation = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeliveredToWrongLocation>(
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
        var model = new DeliveredToWrongLocation { AgreedLocation = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeliveredToWrongLocation { AgreedLocation = "x" };

        DeliveredToWrongLocation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MerchantCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MerchantCancellation { CanceledAt = "2019-12-27" };

        string expectedCanceledAt = "2019-12-27";

        Assert.Equal(expectedCanceledAt, model.CanceledAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MerchantCancellation { CanceledAt = "2019-12-27" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantCancellation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MerchantCancellation { CanceledAt = "2019-12-27" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantCancellation>(
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
        var model = new MerchantCancellation { CanceledAt = "2019-12-27" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MerchantCancellation { CanceledAt = "2019-12-27" };

        MerchantCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NoCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NoCancellation { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NoCancellation { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NoCancellation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NoCancellation { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NoCancellation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NoCancellation { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NoCancellation { };

        NoCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerNonReceiptOfCashTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerNonReceiptOfCash { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConsumerNonReceiptOfCash { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerNonReceiptOfCash>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerNonReceiptOfCash { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerNonReceiptOfCash>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConsumerNonReceiptOfCash { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerNonReceiptOfCash { };

        ConsumerNonReceiptOfCash copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerOriginalCreditTransactionNotAcceptedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerOriginalCreditTransactionNotAccepted
        {
            Explanation = "x",
            Reason = Reason.ProhibitedByLocalLawsOrRegulation,
        };

        string expectedExplanation = "x";
        ApiEnum<string, Reason> expectedReason = Reason.ProhibitedByLocalLawsOrRegulation;

        Assert.Equal(expectedExplanation, model.Explanation);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConsumerOriginalCreditTransactionNotAccepted
        {
            Explanation = "x",
            Reason = Reason.ProhibitedByLocalLawsOrRegulation,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerOriginalCreditTransactionNotAccepted>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerOriginalCreditTransactionNotAccepted
        {
            Explanation = "x",
            Reason = Reason.ProhibitedByLocalLawsOrRegulation,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerOriginalCreditTransactionNotAccepted>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExplanation = "x";
        ApiEnum<string, Reason> expectedReason = Reason.ProhibitedByLocalLawsOrRegulation;

        Assert.Equal(expectedExplanation, deserialized.Explanation);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConsumerOriginalCreditTransactionNotAccepted
        {
            Explanation = "x",
            Reason = Reason.ProhibitedByLocalLawsOrRegulation,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerOriginalCreditTransactionNotAccepted
        {
            Explanation = "x",
            Reason = Reason.ProhibitedByLocalLawsOrRegulation,
        };

        ConsumerOriginalCreditTransactionNotAccepted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.ProhibitedByLocalLawsOrRegulation)]
    [InlineData(Reason.RecipientRefused)]
    public void Validation_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Reason.ProhibitedByLocalLawsOrRegulation)]
    [InlineData(Reason.RecipientRefused)]
    public void SerializationRoundtrip_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerQualityMerchandiseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
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
                    ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string expectedExpectedAt = "2019-12-27";
        ApiEnum<
            string,
            ConsumerQualityMerchandiseMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted;
        string expectedPurchaseInfoAndQualityIssue = "x";
        string expectedReceivedAt = "2019-12-27";
        ApiEnum<string, ConsumerQualityMerchandiseReturnOutcome> expectedReturnOutcome =
            ConsumerQualityMerchandiseReturnOutcome.NotReturned;
        ConsumerQualityMerchandiseNotReturned expectedNotReturned = new();
        OngoingNegotiations expectedOngoingNegotiations = new()
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };
        ConsumerQualityMerchandiseReturnAttempted expectedReturnAttempted = new()
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };
        ConsumerQualityMerchandiseReturned expectedReturned = new()
        {
            ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
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
        var model = new ConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
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
                    ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerQualityMerchandise>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
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
                    ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerQualityMerchandise>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExpectedAt = "2019-12-27";
        ApiEnum<
            string,
            ConsumerQualityMerchandiseMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted;
        string expectedPurchaseInfoAndQualityIssue = "x";
        string expectedReceivedAt = "2019-12-27";
        ApiEnum<string, ConsumerQualityMerchandiseReturnOutcome> expectedReturnOutcome =
            ConsumerQualityMerchandiseReturnOutcome.NotReturned;
        ConsumerQualityMerchandiseNotReturned expectedNotReturned = new();
        OngoingNegotiations expectedOngoingNegotiations = new()
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };
        ConsumerQualityMerchandiseReturnAttempted expectedReturnAttempted = new()
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };
        ConsumerQualityMerchandiseReturned expectedReturned = new()
        {
            ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
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
        var model = new ConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
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
                    ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
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
        var model = new ConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
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
        var model = new ConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,

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
        var model = new ConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,

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
        var model = new ConsumerQualityMerchandise
        {
            ExpectedAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndQualityIssue = "x",
            ReceivedAt = "2019-12-27",
            ReturnOutcome = ConsumerQualityMerchandiseReturnOutcome.NotReturned,
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
                    ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
                AttemptedAt = "2019-12-27",
                MerchandiseDisposition = "x",
            },
            Returned = new()
            {
                ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
                ReturnedAt = "2019-12-27",
                MerchantReceivedReturnAt = "2019-12-27",
                OtherExplanation = "x",
                TrackingNumber = "x",
            },
        };

        ConsumerQualityMerchandise copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerQualityMerchandiseMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted)]
    [InlineData(ConsumerQualityMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void Validation_Works(ConsumerQualityMerchandiseMerchantResolutionAttempted rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerQualityMerchandiseMerchantResolutionAttempted> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerQualityMerchandiseMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerQualityMerchandiseMerchantResolutionAttempted.Attempted)]
    [InlineData(ConsumerQualityMerchandiseMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void SerializationRoundtrip_Works(
        ConsumerQualityMerchandiseMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerQualityMerchandiseMerchantResolutionAttempted> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerQualityMerchandiseMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerQualityMerchandiseMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerQualityMerchandiseMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerQualityMerchandiseReturnOutcomeTest : TestBase
{
    [Theory]
    [InlineData(ConsumerQualityMerchandiseReturnOutcome.NotReturned)]
    [InlineData(ConsumerQualityMerchandiseReturnOutcome.Returned)]
    [InlineData(ConsumerQualityMerchandiseReturnOutcome.ReturnAttempted)]
    public void Validation_Works(ConsumerQualityMerchandiseReturnOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerQualityMerchandiseReturnOutcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerQualityMerchandiseReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerQualityMerchandiseReturnOutcome.NotReturned)]
    [InlineData(ConsumerQualityMerchandiseReturnOutcome.Returned)]
    [InlineData(ConsumerQualityMerchandiseReturnOutcome.ReturnAttempted)]
    public void SerializationRoundtrip_Works(ConsumerQualityMerchandiseReturnOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerQualityMerchandiseReturnOutcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerQualityMerchandiseReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerQualityMerchandiseReturnOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerQualityMerchandiseReturnOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerQualityMerchandiseNotReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerQualityMerchandiseNotReturned { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConsumerQualityMerchandiseNotReturned { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerQualityMerchandiseNotReturned>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerQualityMerchandiseNotReturned { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerQualityMerchandiseNotReturned>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConsumerQualityMerchandiseNotReturned { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerQualityMerchandiseNotReturned { };

        ConsumerQualityMerchandiseNotReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OngoingNegotiationsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OngoingNegotiations
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
        var model = new OngoingNegotiations
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OngoingNegotiations>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OngoingNegotiations
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OngoingNegotiations>(
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
        var model = new OngoingNegotiations
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
        var model = new OngoingNegotiations
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };

        OngoingNegotiations copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerQualityMerchandiseReturnAttemptedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerQualityMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ConsumerQualityMerchandiseReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding;
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
        var model = new ConsumerQualityMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerQualityMerchandiseReturnAttempted>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerQualityMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerQualityMerchandiseReturnAttempted>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAttemptExplanation = "x";
        ApiEnum<
            string,
            ConsumerQualityMerchandiseReturnAttemptedAttemptReason
        > expectedAttemptReason =
            ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding;
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
        var model = new ConsumerQualityMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerQualityMerchandiseReturnAttempted
        {
            AttemptExplanation = "x",
            AttemptReason =
                ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding,
            AttemptedAt = "2019-12-27",
            MerchandiseDisposition = "x",
        };

        ConsumerQualityMerchandiseReturnAttempted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerQualityMerchandiseReturnAttemptedAttemptReasonTest : TestBase
{
    [Theory]
    [InlineData(ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding)]
    [InlineData(
        ConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(ConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions)]
    [InlineData(ConsumerQualityMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn)]
    [InlineData(ConsumerQualityMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted)]
    public void Validation_Works(ConsumerQualityMerchandiseReturnAttemptedAttemptReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerQualityMerchandiseReturnAttemptedAttemptReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerQualityMerchandiseReturnAttemptedAttemptReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerQualityMerchandiseReturnAttemptedAttemptReason.MerchantNotResponding)]
    [InlineData(
        ConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnAuthorizationProvided
    )]
    [InlineData(ConsumerQualityMerchandiseReturnAttemptedAttemptReason.NoReturnInstructions)]
    [InlineData(ConsumerQualityMerchandiseReturnAttemptedAttemptReason.RequestedNotToReturn)]
    [InlineData(ConsumerQualityMerchandiseReturnAttemptedAttemptReason.ReturnNotAccepted)]
    public void SerializationRoundtrip_Works(
        ConsumerQualityMerchandiseReturnAttemptedAttemptReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerQualityMerchandiseReturnAttemptedAttemptReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerQualityMerchandiseReturnAttemptedAttemptReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerQualityMerchandiseReturnAttemptedAttemptReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerQualityMerchandiseReturnAttemptedAttemptReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerQualityMerchandiseReturnedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ApiEnum<string, ConsumerQualityMerchandiseReturnedReturnMethod> expectedReturnMethod =
            ConsumerQualityMerchandiseReturnedReturnMethod.Dhl;
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
        var model = new ConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerQualityMerchandiseReturned>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerQualityMerchandiseReturned>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ConsumerQualityMerchandiseReturnedReturnMethod> expectedReturnMethod =
            ConsumerQualityMerchandiseReturnedReturnMethod.Dhl;
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
        var model = new ConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
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
        var model = new ConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
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
        var model = new ConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
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
        var model = new ConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
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
        var model = new ConsumerQualityMerchandiseReturned
        {
            ReturnMethod = ConsumerQualityMerchandiseReturnedReturnMethod.Dhl,
            ReturnedAt = "2019-12-27",
            MerchantReceivedReturnAt = "2019-12-27",
            OtherExplanation = "x",
            TrackingNumber = "x",
        };

        ConsumerQualityMerchandiseReturned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerQualityMerchandiseReturnedReturnMethodTest : TestBase
{
    [Theory]
    [InlineData(ConsumerQualityMerchandiseReturnedReturnMethod.Dhl)]
    [InlineData(ConsumerQualityMerchandiseReturnedReturnMethod.FaceToFace)]
    [InlineData(ConsumerQualityMerchandiseReturnedReturnMethod.Fedex)]
    [InlineData(ConsumerQualityMerchandiseReturnedReturnMethod.Other)]
    [InlineData(ConsumerQualityMerchandiseReturnedReturnMethod.PostalService)]
    [InlineData(ConsumerQualityMerchandiseReturnedReturnMethod.Ups)]
    public void Validation_Works(ConsumerQualityMerchandiseReturnedReturnMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerQualityMerchandiseReturnedReturnMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerQualityMerchandiseReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerQualityMerchandiseReturnedReturnMethod.Dhl)]
    [InlineData(ConsumerQualityMerchandiseReturnedReturnMethod.FaceToFace)]
    [InlineData(ConsumerQualityMerchandiseReturnedReturnMethod.Fedex)]
    [InlineData(ConsumerQualityMerchandiseReturnedReturnMethod.Other)]
    [InlineData(ConsumerQualityMerchandiseReturnedReturnMethod.PostalService)]
    [InlineData(ConsumerQualityMerchandiseReturnedReturnMethod.Ups)]
    public void SerializationRoundtrip_Works(
        ConsumerQualityMerchandiseReturnedReturnMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerQualityMerchandiseReturnedReturnMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerQualityMerchandiseReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerQualityMerchandiseReturnedReturnMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerQualityMerchandiseReturnedReturnMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerQualityServicesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant = AcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
            CardholderPaidToHaveWorkRedone =
                CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            RestaurantFoodRelated = RestaurantFoodRelated.NotRelated,
        };

        ConsumerQualityServicesCardholderCancellation expectedCardholderCancellation = new()
        {
            AcceptedByMerchant = AcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };
        ApiEnum<
            string,
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
        > expectedNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated;
        string expectedPurchaseInfoAndQualityIssue = "x";
        string expectedServicesReceivedAt = "2019-12-27";
        ApiEnum<string, CardholderPaidToHaveWorkRedone> expectedCardholderPaidToHaveWorkRedone =
            CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone;
        ConsumerQualityServicesOngoingNegotiations expectedOngoingNegotiations = new()
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };
        ApiEnum<string, RestaurantFoodRelated> expectedRestaurantFoodRelated =
            RestaurantFoodRelated.NotRelated;

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
        var model = new ConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant = AcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
            CardholderPaidToHaveWorkRedone =
                CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            RestaurantFoodRelated = RestaurantFoodRelated.NotRelated,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerQualityServices>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant = AcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
            CardholderPaidToHaveWorkRedone =
                CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            RestaurantFoodRelated = RestaurantFoodRelated.NotRelated,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerQualityServices>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ConsumerQualityServicesCardholderCancellation expectedCardholderCancellation = new()
        {
            AcceptedByMerchant = AcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };
        ApiEnum<
            string,
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription
        > expectedNonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated;
        string expectedPurchaseInfoAndQualityIssue = "x";
        string expectedServicesReceivedAt = "2019-12-27";
        ApiEnum<string, CardholderPaidToHaveWorkRedone> expectedCardholderPaidToHaveWorkRedone =
            CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone;
        ConsumerQualityServicesOngoingNegotiations expectedOngoingNegotiations = new()
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };
        ApiEnum<string, RestaurantFoodRelated> expectedRestaurantFoodRelated =
            RestaurantFoodRelated.NotRelated;

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
        var model = new ConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant = AcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
            CardholderPaidToHaveWorkRedone =
                CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            RestaurantFoodRelated = RestaurantFoodRelated.NotRelated,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant = AcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
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
        var model = new ConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant = AcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant = AcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
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
        var model = new ConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant = AcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
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
        var model = new ConsumerQualityServices
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant = AcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription =
                NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated,
            PurchaseInfoAndQualityIssue = "x",
            ServicesReceivedAt = "2019-12-27",
            CardholderPaidToHaveWorkRedone =
                CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone,
            OngoingNegotiations = new()
            {
                Explanation = "x",
                IssuerFirstNotifiedAt = "2019-12-27",
                StartedAt = "2019-12-27",
            },
            RestaurantFoodRelated = RestaurantFoodRelated.NotRelated,
        };

        ConsumerQualityServices copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerQualityServicesCardholderCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerQualityServicesCardholderCancellation
        {
            AcceptedByMerchant = AcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        ApiEnum<string, AcceptedByMerchant> expectedAcceptedByMerchant =
            AcceptedByMerchant.Accepted;
        string expectedCanceledAt = "2019-12-27";
        string expectedReason = "x";

        Assert.Equal(expectedAcceptedByMerchant, model.AcceptedByMerchant);
        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConsumerQualityServicesCardholderCancellation
        {
            AcceptedByMerchant = AcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerQualityServicesCardholderCancellation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerQualityServicesCardholderCancellation
        {
            AcceptedByMerchant = AcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerQualityServicesCardholderCancellation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, AcceptedByMerchant> expectedAcceptedByMerchant =
            AcceptedByMerchant.Accepted;
        string expectedCanceledAt = "2019-12-27";
        string expectedReason = "x";

        Assert.Equal(expectedAcceptedByMerchant, deserialized.AcceptedByMerchant);
        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConsumerQualityServicesCardholderCancellation
        {
            AcceptedByMerchant = AcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerQualityServicesCardholderCancellation
        {
            AcceptedByMerchant = AcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        ConsumerQualityServicesCardholderCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AcceptedByMerchantTest : TestBase
{
    [Theory]
    [InlineData(AcceptedByMerchant.Accepted)]
    [InlineData(AcceptedByMerchant.NotAccepted)]
    public void Validation_Works(AcceptedByMerchant rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AcceptedByMerchant> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AcceptedByMerchant>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AcceptedByMerchant.Accepted)]
    [InlineData(AcceptedByMerchant.NotAccepted)]
    public void SerializationRoundtrip_Works(AcceptedByMerchant rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AcceptedByMerchant> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AcceptedByMerchant>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AcceptedByMerchant>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AcceptedByMerchant>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescriptionTest : TestBase
{
    [Theory]
    [InlineData(NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated)]
    [InlineData(NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.Related)]
    public void Validation_Works(
        NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.NotRelated)]
    [InlineData(NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription.Related)]
    public void SerializationRoundtrip_Works(
        NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NonFiatCurrencyOrNonFungibleTokenRelatedAndNotMatchingDescription>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardholderPaidToHaveWorkRedoneTest : TestBase
{
    [Theory]
    [InlineData(CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone)]
    [InlineData(CardholderPaidToHaveWorkRedone.PaidToHaveWorkRedone)]
    public void Validation_Works(CardholderPaidToHaveWorkRedone rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardholderPaidToHaveWorkRedone> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardholderPaidToHaveWorkRedone>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardholderPaidToHaveWorkRedone.DidNotPayToHaveWorkRedone)]
    [InlineData(CardholderPaidToHaveWorkRedone.PaidToHaveWorkRedone)]
    public void SerializationRoundtrip_Works(CardholderPaidToHaveWorkRedone rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardholderPaidToHaveWorkRedone> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardholderPaidToHaveWorkRedone>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardholderPaidToHaveWorkRedone>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardholderPaidToHaveWorkRedone>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerQualityServicesOngoingNegotiationsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerQualityServicesOngoingNegotiations
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
        var model = new ConsumerQualityServicesOngoingNegotiations
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerQualityServicesOngoingNegotiations>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerQualityServicesOngoingNegotiations
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerQualityServicesOngoingNegotiations>(
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
        var model = new ConsumerQualityServicesOngoingNegotiations
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
        var model = new ConsumerQualityServicesOngoingNegotiations
        {
            Explanation = "x",
            IssuerFirstNotifiedAt = "2019-12-27",
            StartedAt = "2019-12-27",
        };

        ConsumerQualityServicesOngoingNegotiations copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RestaurantFoodRelatedTest : TestBase
{
    [Theory]
    [InlineData(RestaurantFoodRelated.NotRelated)]
    [InlineData(RestaurantFoodRelated.Related)]
    public void Validation_Works(RestaurantFoodRelated rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RestaurantFoodRelated> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RestaurantFoodRelated>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RestaurantFoodRelated.NotRelated)]
    [InlineData(RestaurantFoodRelated.Related)]
    public void SerializationRoundtrip_Works(RestaurantFoodRelated rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RestaurantFoodRelated> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RestaurantFoodRelated>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RestaurantFoodRelated>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RestaurantFoodRelated>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerServicesMisrepresentationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerServicesMisrepresentation
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantResolutionAttempted =
                ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        ConsumerServicesMisrepresentationCardholderCancellation expectedCardholderCancellation =
            new()
            {
                AcceptedByMerchant =
                    ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            };
        ApiEnum<
            string,
            ConsumerServicesMisrepresentationMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted;
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
        var model = new ConsumerServicesMisrepresentation
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantResolutionAttempted =
                ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerServicesMisrepresentation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerServicesMisrepresentation
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantResolutionAttempted =
                ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerServicesMisrepresentation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ConsumerServicesMisrepresentationCardholderCancellation expectedCardholderCancellation =
            new()
            {
                AcceptedByMerchant =
                    ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            };
        ApiEnum<
            string,
            ConsumerServicesMisrepresentationMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted;
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
        var model = new ConsumerServicesMisrepresentation
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantResolutionAttempted =
                ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerServicesMisrepresentation
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantResolutionAttempted =
                ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted,
            MisrepresentationExplanation = "x",
            PurchaseExplanation = "x",
            ReceivedAt = "2019-12-27",
        };

        ConsumerServicesMisrepresentation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerServicesMisrepresentationCardholderCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerServicesMisrepresentationCardholderCancellation
        {
            AcceptedByMerchant =
                ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        ApiEnum<
            string,
            ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
        > expectedAcceptedByMerchant =
            ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted;
        string expectedCanceledAt = "2019-12-27";
        string expectedReason = "x";

        Assert.Equal(expectedAcceptedByMerchant, model.AcceptedByMerchant);
        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConsumerServicesMisrepresentationCardholderCancellation
        {
            AcceptedByMerchant =
                ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerServicesMisrepresentationCardholderCancellation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerServicesMisrepresentationCardholderCancellation
        {
            AcceptedByMerchant =
                ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerServicesMisrepresentationCardholderCancellation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
        > expectedAcceptedByMerchant =
            ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted;
        string expectedCanceledAt = "2019-12-27";
        string expectedReason = "x";

        Assert.Equal(expectedAcceptedByMerchant, deserialized.AcceptedByMerchant);
        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConsumerServicesMisrepresentationCardholderCancellation
        {
            AcceptedByMerchant =
                ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerServicesMisrepresentationCardholderCancellation
        {
            AcceptedByMerchant =
                ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        ConsumerServicesMisrepresentationCardholderCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchantTest
    : TestBase
{
    [Theory]
    [InlineData(ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted)]
    [InlineData(
        ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.NotAccepted
    )]
    public void Validation_Works(
        ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.Accepted)]
    [InlineData(
        ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant.NotAccepted
    )]
    public void SerializationRoundtrip_Works(
        ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
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
                ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ConsumerServicesMisrepresentationCardholderCancellationAcceptedByMerchant
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerServicesMisrepresentationMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted)]
    [InlineData(ConsumerServicesMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void Validation_Works(
        ConsumerServicesMisrepresentationMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerServicesMisrepresentationMerchantResolutionAttempted> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesMisrepresentationMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerServicesMisrepresentationMerchantResolutionAttempted.Attempted)]
    [InlineData(ConsumerServicesMisrepresentationMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void SerializationRoundtrip_Works(
        ConsumerServicesMisrepresentationMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerServicesMisrepresentationMerchantResolutionAttempted> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesMisrepresentationMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesMisrepresentationMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesMisrepresentationMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerServicesNotAsDescribedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerServicesNotAsDescribed
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Explanation = "x",
            MerchantResolutionAttempted =
                ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
        };

        ConsumerServicesNotAsDescribedCardholderCancellation expectedCardholderCancellation = new()
        {
            AcceptedByMerchant =
                ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };
        string expectedExplanation = "x";
        ApiEnum<
            string,
            ConsumerServicesNotAsDescribedMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted;
        string expectedReceivedAt = "2019-12-27";

        Assert.Equal(expectedCardholderCancellation, model.CardholderCancellation);
        Assert.Equal(expectedExplanation, model.Explanation);
        Assert.Equal(expectedMerchantResolutionAttempted, model.MerchantResolutionAttempted);
        Assert.Equal(expectedReceivedAt, model.ReceivedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConsumerServicesNotAsDescribed
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Explanation = "x",
            MerchantResolutionAttempted =
                ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerServicesNotAsDescribed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerServicesNotAsDescribed
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Explanation = "x",
            MerchantResolutionAttempted =
                ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerServicesNotAsDescribed>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ConsumerServicesNotAsDescribedCardholderCancellation expectedCardholderCancellation = new()
        {
            AcceptedByMerchant =
                ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };
        string expectedExplanation = "x";
        ApiEnum<
            string,
            ConsumerServicesNotAsDescribedMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted;
        string expectedReceivedAt = "2019-12-27";

        Assert.Equal(expectedCardholderCancellation, deserialized.CardholderCancellation);
        Assert.Equal(expectedExplanation, deserialized.Explanation);
        Assert.Equal(expectedMerchantResolutionAttempted, deserialized.MerchantResolutionAttempted);
        Assert.Equal(expectedReceivedAt, deserialized.ReceivedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConsumerServicesNotAsDescribed
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Explanation = "x",
            MerchantResolutionAttempted =
                ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerServicesNotAsDescribed
        {
            CardholderCancellation = new()
            {
                AcceptedByMerchant =
                    ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            Explanation = "x",
            MerchantResolutionAttempted =
                ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted,
            ReceivedAt = "2019-12-27",
        };

        ConsumerServicesNotAsDescribed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerServicesNotAsDescribedCardholderCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerServicesNotAsDescribedCardholderCancellation
        {
            AcceptedByMerchant =
                ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        ApiEnum<
            string,
            ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
        > expectedAcceptedByMerchant =
            ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted;
        string expectedCanceledAt = "2019-12-27";
        string expectedReason = "x";

        Assert.Equal(expectedAcceptedByMerchant, model.AcceptedByMerchant);
        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConsumerServicesNotAsDescribedCardholderCancellation
        {
            AcceptedByMerchant =
                ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerServicesNotAsDescribedCardholderCancellation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerServicesNotAsDescribedCardholderCancellation
        {
            AcceptedByMerchant =
                ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerServicesNotAsDescribedCardholderCancellation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
        > expectedAcceptedByMerchant =
            ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted;
        string expectedCanceledAt = "2019-12-27";
        string expectedReason = "x";

        Assert.Equal(expectedAcceptedByMerchant, deserialized.AcceptedByMerchant);
        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConsumerServicesNotAsDescribedCardholderCancellation
        {
            AcceptedByMerchant =
                ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerServicesNotAsDescribedCardholderCancellation
        {
            AcceptedByMerchant =
                ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted,
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        ConsumerServicesNotAsDescribedCardholderCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchantTest : TestBase
{
    [Theory]
    [InlineData(ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted)]
    [InlineData(ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.NotAccepted)]
    public void Validation_Works(
        ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.Accepted)]
    [InlineData(ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant.NotAccepted)]
    public void SerializationRoundtrip_Works(
        ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesNotAsDescribedCardholderCancellationAcceptedByMerchant>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerServicesNotAsDescribedMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted)]
    [InlineData(ConsumerServicesNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void Validation_Works(ConsumerServicesNotAsDescribedMerchantResolutionAttempted rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerServicesNotAsDescribedMerchantResolutionAttempted> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesNotAsDescribedMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerServicesNotAsDescribedMerchantResolutionAttempted.Attempted)]
    [InlineData(ConsumerServicesNotAsDescribedMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void SerializationRoundtrip_Works(
        ConsumerServicesNotAsDescribedMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerServicesNotAsDescribedMerchantResolutionAttempted> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesNotAsDescribedMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesNotAsDescribedMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesNotAsDescribedMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerServicesNotReceivedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerServicesNotReceived
        {
            CancellationOutcome =
                ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
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
            ConsumerServicesNotReceivedCancellationOutcome
        > expectedCancellationOutcome =
            ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt;
        string expectedLastExpectedReceiptAt = "2019-12-27";
        ApiEnum<
            string,
            ConsumerServicesNotReceivedMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted;
        string expectedPurchaseInfoAndExplanation = "x";
        ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt expectedCardholderCancellationPriorToExpectedReceipt =
            new() { CanceledAt = "2019-12-27", Reason = "x" };
        ConsumerServicesNotReceivedMerchantCancellation expectedMerchantCancellation = new(
            "2019-12-27"
        );
        ConsumerServicesNotReceivedNoCancellation expectedNoCancellation = new();

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
        var model = new ConsumerServicesNotReceived
        {
            CancellationOutcome =
                ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
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
        var deserialized = JsonSerializer.Deserialize<ConsumerServicesNotReceived>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerServicesNotReceived
        {
            CancellationOutcome =
                ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
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
        var deserialized = JsonSerializer.Deserialize<ConsumerServicesNotReceived>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ConsumerServicesNotReceivedCancellationOutcome
        > expectedCancellationOutcome =
            ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt;
        string expectedLastExpectedReceiptAt = "2019-12-27";
        ApiEnum<
            string,
            ConsumerServicesNotReceivedMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted;
        string expectedPurchaseInfoAndExplanation = "x";
        ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt expectedCardholderCancellationPriorToExpectedReceipt =
            new() { CanceledAt = "2019-12-27", Reason = "x" };
        ConsumerServicesNotReceivedMerchantCancellation expectedMerchantCancellation = new(
            "2019-12-27"
        );
        ConsumerServicesNotReceivedNoCancellation expectedNoCancellation = new();

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
        var model = new ConsumerServicesNotReceived
        {
            CancellationOutcome =
                ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
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
        var model = new ConsumerServicesNotReceived
        {
            CancellationOutcome =
                ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
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
        var model = new ConsumerServicesNotReceived
        {
            CancellationOutcome =
                ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConsumerServicesNotReceived
        {
            CancellationOutcome =
                ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
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
        var model = new ConsumerServicesNotReceived
        {
            CancellationOutcome =
                ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
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
        var model = new ConsumerServicesNotReceived
        {
            CancellationOutcome =
                ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt,
            LastExpectedReceiptAt = "2019-12-27",
            MerchantResolutionAttempted =
                ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted,
            PurchaseInfoAndExplanation = "x",
            CardholderCancellationPriorToExpectedReceipt = new()
            {
                CanceledAt = "2019-12-27",
                Reason = "x",
            },
            MerchantCancellation = new("2019-12-27"),
            NoCancellation = new(),
        };

        ConsumerServicesNotReceived copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerServicesNotReceivedCancellationOutcomeTest : TestBase
{
    [Theory]
    [InlineData(
        ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt
    )]
    [InlineData(ConsumerServicesNotReceivedCancellationOutcome.MerchantCancellation)]
    [InlineData(ConsumerServicesNotReceivedCancellationOutcome.NoCancellation)]
    public void Validation_Works(ConsumerServicesNotReceivedCancellationOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerServicesNotReceivedCancellationOutcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesNotReceivedCancellationOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ConsumerServicesNotReceivedCancellationOutcome.CardholderCancellationPriorToExpectedReceipt
    )]
    [InlineData(ConsumerServicesNotReceivedCancellationOutcome.MerchantCancellation)]
    [InlineData(ConsumerServicesNotReceivedCancellationOutcome.NoCancellation)]
    public void SerializationRoundtrip_Works(
        ConsumerServicesNotReceivedCancellationOutcome rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerServicesNotReceivedCancellationOutcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesNotReceivedCancellationOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesNotReceivedCancellationOutcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesNotReceivedCancellationOutcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerServicesNotReceivedMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted)]
    [InlineData(ConsumerServicesNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void Validation_Works(ConsumerServicesNotReceivedMerchantResolutionAttempted rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerServicesNotReceivedMerchantResolutionAttempted> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesNotReceivedMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConsumerServicesNotReceivedMerchantResolutionAttempted.Attempted)]
    [InlineData(ConsumerServicesNotReceivedMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void SerializationRoundtrip_Works(
        ConsumerServicesNotReceivedMerchantResolutionAttempted rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConsumerServicesNotReceivedMerchantResolutionAttempted> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesNotReceivedMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesNotReceivedMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConsumerServicesNotReceivedMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceiptTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
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
        var model = new ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
        {
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
        {
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt>(
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
        var model = new ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
        {
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
        {
            CanceledAt = "2019-12-27",
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
        {
            CanceledAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
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
        var model = new ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
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
        var model = new ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt
        {
            CanceledAt = "2019-12-27",
            Reason = "x",
        };

        ConsumerServicesNotReceivedCardholderCancellationPriorToExpectedReceipt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerServicesNotReceivedMerchantCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerServicesNotReceivedMerchantCancellation
        {
            CanceledAt = "2019-12-27",
        };

        string expectedCanceledAt = "2019-12-27";

        Assert.Equal(expectedCanceledAt, model.CanceledAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConsumerServicesNotReceivedMerchantCancellation
        {
            CanceledAt = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerServicesNotReceivedMerchantCancellation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerServicesNotReceivedMerchantCancellation
        {
            CanceledAt = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumerServicesNotReceivedMerchantCancellation>(
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
        var model = new ConsumerServicesNotReceivedMerchantCancellation
        {
            CanceledAt = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerServicesNotReceivedMerchantCancellation
        {
            CanceledAt = "2019-12-27",
        };

        ConsumerServicesNotReceivedMerchantCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumerServicesNotReceivedNoCancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumerServicesNotReceivedNoCancellation { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConsumerServicesNotReceivedNoCancellation { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerServicesNotReceivedNoCancellation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumerServicesNotReceivedNoCancellation { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumerServicesNotReceivedNoCancellation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConsumerServicesNotReceivedNoCancellation { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumerServicesNotReceivedNoCancellation { };

        ConsumerServicesNotReceivedNoCancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FraudTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Fraud { FraudType = FraudType.AccountOrCredentialsTakeover };

        ApiEnum<string, FraudType> expectedFraudType = FraudType.AccountOrCredentialsTakeover;

        Assert.Equal(expectedFraudType, model.FraudType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Fraud { FraudType = FraudType.AccountOrCredentialsTakeover };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Fraud>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Fraud { FraudType = FraudType.AccountOrCredentialsTakeover };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Fraud>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, FraudType> expectedFraudType = FraudType.AccountOrCredentialsTakeover;

        Assert.Equal(expectedFraudType, deserialized.FraudType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Fraud { FraudType = FraudType.AccountOrCredentialsTakeover };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Fraud { FraudType = FraudType.AccountOrCredentialsTakeover };

        Fraud copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FraudTypeTest : TestBase
{
    [Theory]
    [InlineData(FraudType.AccountOrCredentialsTakeover)]
    [InlineData(FraudType.CardNotReceivedAsIssued)]
    [InlineData(FraudType.FraudulentApplication)]
    [InlineData(FraudType.FraudulentUseOfAccountNumber)]
    [InlineData(FraudType.IncorrectProcessing)]
    [InlineData(FraudType.IssuerReportedCounterfeit)]
    [InlineData(FraudType.Lost)]
    [InlineData(FraudType.ManipulationOfAccountHolder)]
    [InlineData(FraudType.MerchantMisrepresentation)]
    [InlineData(FraudType.Miscellaneous)]
    [InlineData(FraudType.Stolen)]
    public void Validation_Works(FraudType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FraudType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FraudType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FraudType.AccountOrCredentialsTakeover)]
    [InlineData(FraudType.CardNotReceivedAsIssued)]
    [InlineData(FraudType.FraudulentApplication)]
    [InlineData(FraudType.FraudulentUseOfAccountNumber)]
    [InlineData(FraudType.IncorrectProcessing)]
    [InlineData(FraudType.IssuerReportedCounterfeit)]
    [InlineData(FraudType.Lost)]
    [InlineData(FraudType.ManipulationOfAccountHolder)]
    [InlineData(FraudType.MerchantMisrepresentation)]
    [InlineData(FraudType.Miscellaneous)]
    [InlineData(FraudType.Stolen)]
    public void SerializationRoundtrip_Works(FraudType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FraudType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FraudType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FraudType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FraudType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ProcessingErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProcessingError
        {
            ErrorReason = ErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,
            DuplicateTransaction = new("x"),
            IncorrectAmount = new(0),
            PaidByOtherMeans = new()
            {
                OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
                OtherTransactionID = "x",
            },
        };

        ApiEnum<string, ErrorReason> expectedErrorReason = ErrorReason.DuplicateTransaction;
        ApiEnum<
            string,
            ProcessingErrorMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ProcessingErrorMerchantResolutionAttempted.Attempted;
        DuplicateTransaction expectedDuplicateTransaction = new("x");
        IncorrectAmount expectedIncorrectAmount = new(0);
        PaidByOtherMeans expectedPaidByOtherMeans = new()
        {
            OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
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
        var model = new ProcessingError
        {
            ErrorReason = ErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,
            DuplicateTransaction = new("x"),
            IncorrectAmount = new(0),
            PaidByOtherMeans = new()
            {
                OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
                OtherTransactionID = "x",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProcessingError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProcessingError
        {
            ErrorReason = ErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,
            DuplicateTransaction = new("x"),
            IncorrectAmount = new(0),
            PaidByOtherMeans = new()
            {
                OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
                OtherTransactionID = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProcessingError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ErrorReason> expectedErrorReason = ErrorReason.DuplicateTransaction;
        ApiEnum<
            string,
            ProcessingErrorMerchantResolutionAttempted
        > expectedMerchantResolutionAttempted =
            ProcessingErrorMerchantResolutionAttempted.Attempted;
        DuplicateTransaction expectedDuplicateTransaction = new("x");
        IncorrectAmount expectedIncorrectAmount = new(0);
        PaidByOtherMeans expectedPaidByOtherMeans = new()
        {
            OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
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
        var model = new ProcessingError
        {
            ErrorReason = ErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,
            DuplicateTransaction = new("x"),
            IncorrectAmount = new(0),
            PaidByOtherMeans = new()
            {
                OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
                OtherTransactionID = "x",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProcessingError
        {
            ErrorReason = ErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,
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
        var model = new ProcessingError
        {
            ErrorReason = ErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ProcessingError
        {
            ErrorReason = ErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,

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
        var model = new ProcessingError
        {
            ErrorReason = ErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,

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
        var model = new ProcessingError
        {
            ErrorReason = ErrorReason.DuplicateTransaction,
            MerchantResolutionAttempted = ProcessingErrorMerchantResolutionAttempted.Attempted,
            DuplicateTransaction = new("x"),
            IncorrectAmount = new(0),
            PaidByOtherMeans = new()
            {
                OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
                OtherTransactionID = "x",
            },
        };

        ProcessingError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ErrorReasonTest : TestBase
{
    [Theory]
    [InlineData(ErrorReason.DuplicateTransaction)]
    [InlineData(ErrorReason.IncorrectAmount)]
    [InlineData(ErrorReason.PaidByOtherMeans)]
    public void Validation_Works(ErrorReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ErrorReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ErrorReason.DuplicateTransaction)]
    [InlineData(ErrorReason.IncorrectAmount)]
    [InlineData(ErrorReason.PaidByOtherMeans)]
    public void SerializationRoundtrip_Works(ErrorReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ErrorReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ProcessingErrorMerchantResolutionAttemptedTest : TestBase
{
    [Theory]
    [InlineData(ProcessingErrorMerchantResolutionAttempted.Attempted)]
    [InlineData(ProcessingErrorMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void Validation_Works(ProcessingErrorMerchantResolutionAttempted rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProcessingErrorMerchantResolutionAttempted> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProcessingErrorMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProcessingErrorMerchantResolutionAttempted.Attempted)]
    [InlineData(ProcessingErrorMerchantResolutionAttempted.ProhibitedByLocalLaw)]
    public void SerializationRoundtrip_Works(ProcessingErrorMerchantResolutionAttempted rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProcessingErrorMerchantResolutionAttempted> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProcessingErrorMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProcessingErrorMerchantResolutionAttempted>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProcessingErrorMerchantResolutionAttempted>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DuplicateTransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DuplicateTransaction { OtherTransactionID = "x" };

        string expectedOtherTransactionID = "x";

        Assert.Equal(expectedOtherTransactionID, model.OtherTransactionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DuplicateTransaction { OtherTransactionID = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DuplicateTransaction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DuplicateTransaction { OtherTransactionID = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DuplicateTransaction>(
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
        var model = new DuplicateTransaction { OtherTransactionID = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DuplicateTransaction { OtherTransactionID = "x" };

        DuplicateTransaction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IncorrectAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IncorrectAmount { ExpectedAmount = 0 };

        long expectedExpectedAmount = 0;

        Assert.Equal(expectedExpectedAmount, model.ExpectedAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IncorrectAmount { ExpectedAmount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IncorrectAmount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IncorrectAmount { ExpectedAmount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IncorrectAmount>(
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
        var model = new IncorrectAmount { ExpectedAmount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IncorrectAmount { ExpectedAmount = 0 };

        IncorrectAmount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaidByOtherMeansTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaidByOtherMeans
        {
            OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
            OtherTransactionID = "x",
        };

        ApiEnum<string, OtherFormOfPaymentEvidence> expectedOtherFormOfPaymentEvidence =
            OtherFormOfPaymentEvidence.CanceledCheck;
        string expectedOtherTransactionID = "x";

        Assert.Equal(expectedOtherFormOfPaymentEvidence, model.OtherFormOfPaymentEvidence);
        Assert.Equal(expectedOtherTransactionID, model.OtherTransactionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PaidByOtherMeans
        {
            OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
            OtherTransactionID = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaidByOtherMeans>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaidByOtherMeans
        {
            OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
            OtherTransactionID = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaidByOtherMeans>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, OtherFormOfPaymentEvidence> expectedOtherFormOfPaymentEvidence =
            OtherFormOfPaymentEvidence.CanceledCheck;
        string expectedOtherTransactionID = "x";

        Assert.Equal(expectedOtherFormOfPaymentEvidence, deserialized.OtherFormOfPaymentEvidence);
        Assert.Equal(expectedOtherTransactionID, deserialized.OtherTransactionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PaidByOtherMeans
        {
            OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
            OtherTransactionID = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PaidByOtherMeans
        {
            OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
        };

        Assert.Null(model.OtherTransactionID);
        Assert.False(model.RawData.ContainsKey("other_transaction_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PaidByOtherMeans
        {
            OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PaidByOtherMeans
        {
            OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,

            // Null should be interpreted as omitted for these properties
            OtherTransactionID = null,
        };

        Assert.Null(model.OtherTransactionID);
        Assert.False(model.RawData.ContainsKey("other_transaction_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PaidByOtherMeans
        {
            OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,

            // Null should be interpreted as omitted for these properties
            OtherTransactionID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PaidByOtherMeans
        {
            OtherFormOfPaymentEvidence = OtherFormOfPaymentEvidence.CanceledCheck,
            OtherTransactionID = "x",
        };

        PaidByOtherMeans copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OtherFormOfPaymentEvidenceTest : TestBase
{
    [Theory]
    [InlineData(OtherFormOfPaymentEvidence.CanceledCheck)]
    [InlineData(OtherFormOfPaymentEvidence.CardTransaction)]
    [InlineData(OtherFormOfPaymentEvidence.CashReceipt)]
    [InlineData(OtherFormOfPaymentEvidence.Other)]
    [InlineData(OtherFormOfPaymentEvidence.Statement)]
    [InlineData(OtherFormOfPaymentEvidence.Voucher)]
    public void Validation_Works(OtherFormOfPaymentEvidence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OtherFormOfPaymentEvidence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OtherFormOfPaymentEvidence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OtherFormOfPaymentEvidence.CanceledCheck)]
    [InlineData(OtherFormOfPaymentEvidence.CardTransaction)]
    [InlineData(OtherFormOfPaymentEvidence.CashReceipt)]
    [InlineData(OtherFormOfPaymentEvidence.Other)]
    [InlineData(OtherFormOfPaymentEvidence.Statement)]
    [InlineData(OtherFormOfPaymentEvidence.Voucher)]
    public void SerializationRoundtrip_Works(OtherFormOfPaymentEvidence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OtherFormOfPaymentEvidence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OtherFormOfPaymentEvidence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OtherFormOfPaymentEvidence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OtherFormOfPaymentEvidence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
