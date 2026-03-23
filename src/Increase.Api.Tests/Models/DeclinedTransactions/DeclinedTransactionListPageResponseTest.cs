using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using DeclinedTransactions = Increase.Api.Models.DeclinedTransactions;

namespace Increase.Api.Tests.Models.DeclinedTransactions;

public class DeclinedTransactionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::DeclinedTransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Amount = 1750,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = DeclinedTransactions::Currency.Usd,
                    Description = "INVOICE 2468",
                    RouteID = "account_number_v18nkfqm6afpsrvy82b2",
                    RouteType = DeclinedTransactions::RouteType.AccountNumber,
                    Source = new()
                    {
                        Category = DeclinedTransactions::SourceCategory.AchDecline,
                        AchDecline = new()
                        {
                            ID = "ach_decline_72v1mcwxudctq56efipa",
                            Amount = 1750,
                            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                            OriginatorCompanyDescriptiveDate = null,
                            OriginatorCompanyDiscretionaryData = null,
                            OriginatorCompanyID = "0987654321",
                            OriginatorCompanyName = "BIG BANK",
                            Reason = DeclinedTransactions::Reason.InsufficientFunds,
                            ReceiverIDNumber = "12345678900",
                            ReceiverName = "IAN CREASE",
                            TraceNumber = "021000038461022",
                            Type = DeclinedTransactions::Type.AchDecline,
                        },
                        CardDecline = new()
                        {
                            ID = "card_decline_bx3o8zd7glq8yvtwg25v",
                            Actioner = DeclinedTransactions::Actioner.Increase,
                            AdditionalAmounts = new()
                            {
                                Clinic = new() { Amount = 0, Currency = "currency" },
                                Dental = new() { Amount = 0, Currency = "currency" },
                                Original = new() { Amount = 0, Currency = "currency" },
                                Prescription = new() { Amount = 0, Currency = "currency" },
                                Surcharge = new() { Amount = 10, Currency = "USD" },
                                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                                Transit = new() { Amount = 0, Currency = "currency" },
                                Unknown = new() { Amount = 0, Currency = "currency" },
                                Vision = new() { Amount = 0, Currency = "currency" },
                            },
                            Amount = -1000,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Currency = DeclinedTransactions::CardDeclineCurrency.Usd,
                            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                            DigitalWalletTokenID = null,
                            Direction = DeclinedTransactions::Direction.Settlement,
                            IncrementedCardAuthorizationID = null,
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantDescriptor = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = null,
                            NetworkDetails = new()
                            {
                                Category = DeclinedTransactions::NetworkDetailsCategory.Visa,
                                Pulse = new(),
                                Visa = new()
                                {
                                    ElectronicCommerceIndicator =
                                        DeclinedTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                    PointOfServiceEntryMode =
                                        DeclinedTransactions::PointOfServiceEntryMode.Manual,
                                    StandInProcessingReason = null,
                                    TerminalEntryCapability =
                                        DeclinedTransactions::TerminalEntryCapability.MagneticStripe,
                                },
                            },
                            NetworkIdentifiers = new()
                            {
                                AuthorizationIdentificationResponse = null,
                                RetrievalReferenceNumber = "785867080153",
                                TraceNumber = "487941",
                                TransactionID = "627199945183184",
                            },
                            NetworkRiskScore = 10,
                            PhysicalCardID = null,
                            PresentmentAmount = -1000,
                            PresentmentCurrency = "USD",
                            ProcessingCategory = DeclinedTransactions::ProcessingCategory.Purchase,
                            RealTimeDecisionID = null,
                            RealTimeDecisionReason = null,
                            Reason = DeclinedTransactions::CardDeclineReason.InsufficientFunds,
                            TerminalID = "RCN5VNXS",
                            Verification = new()
                            {
                                CardVerificationCode = new(DeclinedTransactions::Result.Match),
                                CardholderAddress = new()
                                {
                                    ActualLine1 = "33 Liberty Street",
                                    ActualPostalCode = "94131",
                                    ProvidedLine1 = "33 Liberty Street",
                                    ProvidedPostalCode = "94132",
                                    Result =
                                        DeclinedTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                                },
                                CardholderName = new()
                                {
                                    ProvidedFirstName = "provided_first_name",
                                    ProvidedLastName = "provided_last_name",
                                    ProvidedMiddleName = "provided_middle_name",
                                },
                            },
                        },
                        CheckDecline = new()
                        {
                            Amount = -1000,
                            AuxiliaryOnUs = "99999",
                            BackImageFileID = null,
                            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                            FrontImageFileID = null,
                            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                            Reason = DeclinedTransactions::CheckDeclineReason.InsufficientFunds,
                        },
                        CheckDepositRejection = new()
                        {
                            Amount = 1750,
                            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                            Currency = DeclinedTransactions::CheckDepositRejectionCurrency.Usd,
                            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                            Reason =
                                DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage,
                            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        },
                        InboundFednowTransferDecline = new()
                        {
                            Reason =
                                DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled,
                            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                        },
                        InboundRealTimePaymentsTransferDecline = new()
                        {
                            Amount = 100,
                            CreditorName = "Ian Crease",
                            Currency =
                                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
                            DebtorAccountNumber = "987654321",
                            DebtorName = "National Phonograph Company",
                            DebtorRoutingNumber = "101050001",
                            Reason =
                                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled,
                            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                            TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                            UnstructuredRemittanceInformation = "Invoice 29582",
                        },
                        Other = new(),
                        WireDecline = new()
                        {
                            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                            Reason = DeclinedTransactions::WireDeclineReason.AccountNumberDisabled,
                        },
                    },
                    Type = DeclinedTransactions::DeclinedTransactionType.DeclinedTransaction,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<DeclinedTransactions::DeclinedTransaction> expectedData =
        [
            new()
            {
                ID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                AccountID = "account_in71c4amph0vgo2qllky",
                Amount = 1750,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = DeclinedTransactions::Currency.Usd,
                Description = "INVOICE 2468",
                RouteID = "account_number_v18nkfqm6afpsrvy82b2",
                RouteType = DeclinedTransactions::RouteType.AccountNumber,
                Source = new()
                {
                    Category = DeclinedTransactions::SourceCategory.AchDecline,
                    AchDecline = new()
                    {
                        ID = "ach_decline_72v1mcwxudctq56efipa",
                        Amount = 1750,
                        InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                        OriginatorCompanyDescriptiveDate = null,
                        OriginatorCompanyDiscretionaryData = null,
                        OriginatorCompanyID = "0987654321",
                        OriginatorCompanyName = "BIG BANK",
                        Reason = DeclinedTransactions::Reason.InsufficientFunds,
                        ReceiverIDNumber = "12345678900",
                        ReceiverName = "IAN CREASE",
                        TraceNumber = "021000038461022",
                        Type = DeclinedTransactions::Type.AchDecline,
                    },
                    CardDecline = new()
                    {
                        ID = "card_decline_bx3o8zd7glq8yvtwg25v",
                        Actioner = DeclinedTransactions::Actioner.Increase,
                        AdditionalAmounts = new()
                        {
                            Clinic = new() { Amount = 0, Currency = "currency" },
                            Dental = new() { Amount = 0, Currency = "currency" },
                            Original = new() { Amount = 0, Currency = "currency" },
                            Prescription = new() { Amount = 0, Currency = "currency" },
                            Surcharge = new() { Amount = 10, Currency = "USD" },
                            TotalCumulative = new() { Amount = 0, Currency = "currency" },
                            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                            Transit = new() { Amount = 0, Currency = "currency" },
                            Unknown = new() { Amount = 0, Currency = "currency" },
                            Vision = new() { Amount = 0, Currency = "currency" },
                        },
                        Amount = -1000,
                        CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                        Currency = DeclinedTransactions::CardDeclineCurrency.Usd,
                        DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                        DigitalWalletTokenID = null,
                        Direction = DeclinedTransactions::Direction.Settlement,
                        IncrementedCardAuthorizationID = null,
                        MerchantAcceptorID = "5665270011000168",
                        MerchantCategoryCode = "5734",
                        MerchantCity = "New York",
                        MerchantCountry = "US",
                        MerchantDescriptor = "AMAZON.COM",
                        MerchantPostalCode = "10045",
                        MerchantState = null,
                        NetworkDetails = new()
                        {
                            Category = DeclinedTransactions::NetworkDetailsCategory.Visa,
                            Pulse = new(),
                            Visa = new()
                            {
                                ElectronicCommerceIndicator =
                                    DeclinedTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                PointOfServiceEntryMode =
                                    DeclinedTransactions::PointOfServiceEntryMode.Manual,
                                StandInProcessingReason = null,
                                TerminalEntryCapability =
                                    DeclinedTransactions::TerminalEntryCapability.MagneticStripe,
                            },
                        },
                        NetworkIdentifiers = new()
                        {
                            AuthorizationIdentificationResponse = null,
                            RetrievalReferenceNumber = "785867080153",
                            TraceNumber = "487941",
                            TransactionID = "627199945183184",
                        },
                        NetworkRiskScore = 10,
                        PhysicalCardID = null,
                        PresentmentAmount = -1000,
                        PresentmentCurrency = "USD",
                        ProcessingCategory = DeclinedTransactions::ProcessingCategory.Purchase,
                        RealTimeDecisionID = null,
                        RealTimeDecisionReason = null,
                        Reason = DeclinedTransactions::CardDeclineReason.InsufficientFunds,
                        TerminalID = "RCN5VNXS",
                        Verification = new()
                        {
                            CardVerificationCode = new(DeclinedTransactions::Result.Match),
                            CardholderAddress = new()
                            {
                                ActualLine1 = "33 Liberty Street",
                                ActualPostalCode = "94131",
                                ProvidedLine1 = "33 Liberty Street",
                                ProvidedPostalCode = "94132",
                                Result =
                                    DeclinedTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                            },
                            CardholderName = new()
                            {
                                ProvidedFirstName = "provided_first_name",
                                ProvidedLastName = "provided_last_name",
                                ProvidedMiddleName = "provided_middle_name",
                            },
                        },
                    },
                    CheckDecline = new()
                    {
                        Amount = -1000,
                        AuxiliaryOnUs = "99999",
                        BackImageFileID = null,
                        CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                        FrontImageFileID = null,
                        InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                        Reason = DeclinedTransactions::CheckDeclineReason.InsufficientFunds,
                    },
                    CheckDepositRejection = new()
                    {
                        Amount = 1750,
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = DeclinedTransactions::CheckDepositRejectionCurrency.Usd,
                        DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                        Reason = DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage,
                        RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    },
                    InboundFednowTransferDecline = new()
                    {
                        Reason =
                            DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled,
                        TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                    },
                    InboundRealTimePaymentsTransferDecline = new()
                    {
                        Amount = 100,
                        CreditorName = "Ian Crease",
                        Currency =
                            DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
                        DebtorAccountNumber = "987654321",
                        DebtorName = "National Phonograph Company",
                        DebtorRoutingNumber = "101050001",
                        Reason =
                            DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled,
                        TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                        TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                    Other = new(),
                    WireDecline = new()
                    {
                        InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                        Reason = DeclinedTransactions::WireDeclineReason.AccountNumberDisabled,
                    },
                },
                Type = DeclinedTransactions::DeclinedTransactionType.DeclinedTransaction,
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
        var model = new DeclinedTransactions::DeclinedTransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Amount = 1750,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = DeclinedTransactions::Currency.Usd,
                    Description = "INVOICE 2468",
                    RouteID = "account_number_v18nkfqm6afpsrvy82b2",
                    RouteType = DeclinedTransactions::RouteType.AccountNumber,
                    Source = new()
                    {
                        Category = DeclinedTransactions::SourceCategory.AchDecline,
                        AchDecline = new()
                        {
                            ID = "ach_decline_72v1mcwxudctq56efipa",
                            Amount = 1750,
                            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                            OriginatorCompanyDescriptiveDate = null,
                            OriginatorCompanyDiscretionaryData = null,
                            OriginatorCompanyID = "0987654321",
                            OriginatorCompanyName = "BIG BANK",
                            Reason = DeclinedTransactions::Reason.InsufficientFunds,
                            ReceiverIDNumber = "12345678900",
                            ReceiverName = "IAN CREASE",
                            TraceNumber = "021000038461022",
                            Type = DeclinedTransactions::Type.AchDecline,
                        },
                        CardDecline = new()
                        {
                            ID = "card_decline_bx3o8zd7glq8yvtwg25v",
                            Actioner = DeclinedTransactions::Actioner.Increase,
                            AdditionalAmounts = new()
                            {
                                Clinic = new() { Amount = 0, Currency = "currency" },
                                Dental = new() { Amount = 0, Currency = "currency" },
                                Original = new() { Amount = 0, Currency = "currency" },
                                Prescription = new() { Amount = 0, Currency = "currency" },
                                Surcharge = new() { Amount = 10, Currency = "USD" },
                                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                                Transit = new() { Amount = 0, Currency = "currency" },
                                Unknown = new() { Amount = 0, Currency = "currency" },
                                Vision = new() { Amount = 0, Currency = "currency" },
                            },
                            Amount = -1000,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Currency = DeclinedTransactions::CardDeclineCurrency.Usd,
                            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                            DigitalWalletTokenID = null,
                            Direction = DeclinedTransactions::Direction.Settlement,
                            IncrementedCardAuthorizationID = null,
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantDescriptor = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = null,
                            NetworkDetails = new()
                            {
                                Category = DeclinedTransactions::NetworkDetailsCategory.Visa,
                                Pulse = new(),
                                Visa = new()
                                {
                                    ElectronicCommerceIndicator =
                                        DeclinedTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                    PointOfServiceEntryMode =
                                        DeclinedTransactions::PointOfServiceEntryMode.Manual,
                                    StandInProcessingReason = null,
                                    TerminalEntryCapability =
                                        DeclinedTransactions::TerminalEntryCapability.MagneticStripe,
                                },
                            },
                            NetworkIdentifiers = new()
                            {
                                AuthorizationIdentificationResponse = null,
                                RetrievalReferenceNumber = "785867080153",
                                TraceNumber = "487941",
                                TransactionID = "627199945183184",
                            },
                            NetworkRiskScore = 10,
                            PhysicalCardID = null,
                            PresentmentAmount = -1000,
                            PresentmentCurrency = "USD",
                            ProcessingCategory = DeclinedTransactions::ProcessingCategory.Purchase,
                            RealTimeDecisionID = null,
                            RealTimeDecisionReason = null,
                            Reason = DeclinedTransactions::CardDeclineReason.InsufficientFunds,
                            TerminalID = "RCN5VNXS",
                            Verification = new()
                            {
                                CardVerificationCode = new(DeclinedTransactions::Result.Match),
                                CardholderAddress = new()
                                {
                                    ActualLine1 = "33 Liberty Street",
                                    ActualPostalCode = "94131",
                                    ProvidedLine1 = "33 Liberty Street",
                                    ProvidedPostalCode = "94132",
                                    Result =
                                        DeclinedTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                                },
                                CardholderName = new()
                                {
                                    ProvidedFirstName = "provided_first_name",
                                    ProvidedLastName = "provided_last_name",
                                    ProvidedMiddleName = "provided_middle_name",
                                },
                            },
                        },
                        CheckDecline = new()
                        {
                            Amount = -1000,
                            AuxiliaryOnUs = "99999",
                            BackImageFileID = null,
                            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                            FrontImageFileID = null,
                            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                            Reason = DeclinedTransactions::CheckDeclineReason.InsufficientFunds,
                        },
                        CheckDepositRejection = new()
                        {
                            Amount = 1750,
                            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                            Currency = DeclinedTransactions::CheckDepositRejectionCurrency.Usd,
                            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                            Reason =
                                DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage,
                            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        },
                        InboundFednowTransferDecline = new()
                        {
                            Reason =
                                DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled,
                            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                        },
                        InboundRealTimePaymentsTransferDecline = new()
                        {
                            Amount = 100,
                            CreditorName = "Ian Crease",
                            Currency =
                                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
                            DebtorAccountNumber = "987654321",
                            DebtorName = "National Phonograph Company",
                            DebtorRoutingNumber = "101050001",
                            Reason =
                                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled,
                            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                            TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                            UnstructuredRemittanceInformation = "Invoice 29582",
                        },
                        Other = new(),
                        WireDecline = new()
                        {
                            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                            Reason = DeclinedTransactions::WireDeclineReason.AccountNumberDisabled,
                        },
                    },
                    Type = DeclinedTransactions::DeclinedTransactionType.DeclinedTransaction,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DeclinedTransactions::DeclinedTransactionListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::DeclinedTransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Amount = 1750,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = DeclinedTransactions::Currency.Usd,
                    Description = "INVOICE 2468",
                    RouteID = "account_number_v18nkfqm6afpsrvy82b2",
                    RouteType = DeclinedTransactions::RouteType.AccountNumber,
                    Source = new()
                    {
                        Category = DeclinedTransactions::SourceCategory.AchDecline,
                        AchDecline = new()
                        {
                            ID = "ach_decline_72v1mcwxudctq56efipa",
                            Amount = 1750,
                            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                            OriginatorCompanyDescriptiveDate = null,
                            OriginatorCompanyDiscretionaryData = null,
                            OriginatorCompanyID = "0987654321",
                            OriginatorCompanyName = "BIG BANK",
                            Reason = DeclinedTransactions::Reason.InsufficientFunds,
                            ReceiverIDNumber = "12345678900",
                            ReceiverName = "IAN CREASE",
                            TraceNumber = "021000038461022",
                            Type = DeclinedTransactions::Type.AchDecline,
                        },
                        CardDecline = new()
                        {
                            ID = "card_decline_bx3o8zd7glq8yvtwg25v",
                            Actioner = DeclinedTransactions::Actioner.Increase,
                            AdditionalAmounts = new()
                            {
                                Clinic = new() { Amount = 0, Currency = "currency" },
                                Dental = new() { Amount = 0, Currency = "currency" },
                                Original = new() { Amount = 0, Currency = "currency" },
                                Prescription = new() { Amount = 0, Currency = "currency" },
                                Surcharge = new() { Amount = 10, Currency = "USD" },
                                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                                Transit = new() { Amount = 0, Currency = "currency" },
                                Unknown = new() { Amount = 0, Currency = "currency" },
                                Vision = new() { Amount = 0, Currency = "currency" },
                            },
                            Amount = -1000,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Currency = DeclinedTransactions::CardDeclineCurrency.Usd,
                            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                            DigitalWalletTokenID = null,
                            Direction = DeclinedTransactions::Direction.Settlement,
                            IncrementedCardAuthorizationID = null,
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantDescriptor = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = null,
                            NetworkDetails = new()
                            {
                                Category = DeclinedTransactions::NetworkDetailsCategory.Visa,
                                Pulse = new(),
                                Visa = new()
                                {
                                    ElectronicCommerceIndicator =
                                        DeclinedTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                    PointOfServiceEntryMode =
                                        DeclinedTransactions::PointOfServiceEntryMode.Manual,
                                    StandInProcessingReason = null,
                                    TerminalEntryCapability =
                                        DeclinedTransactions::TerminalEntryCapability.MagneticStripe,
                                },
                            },
                            NetworkIdentifiers = new()
                            {
                                AuthorizationIdentificationResponse = null,
                                RetrievalReferenceNumber = "785867080153",
                                TraceNumber = "487941",
                                TransactionID = "627199945183184",
                            },
                            NetworkRiskScore = 10,
                            PhysicalCardID = null,
                            PresentmentAmount = -1000,
                            PresentmentCurrency = "USD",
                            ProcessingCategory = DeclinedTransactions::ProcessingCategory.Purchase,
                            RealTimeDecisionID = null,
                            RealTimeDecisionReason = null,
                            Reason = DeclinedTransactions::CardDeclineReason.InsufficientFunds,
                            TerminalID = "RCN5VNXS",
                            Verification = new()
                            {
                                CardVerificationCode = new(DeclinedTransactions::Result.Match),
                                CardholderAddress = new()
                                {
                                    ActualLine1 = "33 Liberty Street",
                                    ActualPostalCode = "94131",
                                    ProvidedLine1 = "33 Liberty Street",
                                    ProvidedPostalCode = "94132",
                                    Result =
                                        DeclinedTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                                },
                                CardholderName = new()
                                {
                                    ProvidedFirstName = "provided_first_name",
                                    ProvidedLastName = "provided_last_name",
                                    ProvidedMiddleName = "provided_middle_name",
                                },
                            },
                        },
                        CheckDecline = new()
                        {
                            Amount = -1000,
                            AuxiliaryOnUs = "99999",
                            BackImageFileID = null,
                            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                            FrontImageFileID = null,
                            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                            Reason = DeclinedTransactions::CheckDeclineReason.InsufficientFunds,
                        },
                        CheckDepositRejection = new()
                        {
                            Amount = 1750,
                            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                            Currency = DeclinedTransactions::CheckDepositRejectionCurrency.Usd,
                            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                            Reason =
                                DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage,
                            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        },
                        InboundFednowTransferDecline = new()
                        {
                            Reason =
                                DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled,
                            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                        },
                        InboundRealTimePaymentsTransferDecline = new()
                        {
                            Amount = 100,
                            CreditorName = "Ian Crease",
                            Currency =
                                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
                            DebtorAccountNumber = "987654321",
                            DebtorName = "National Phonograph Company",
                            DebtorRoutingNumber = "101050001",
                            Reason =
                                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled,
                            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                            TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                            UnstructuredRemittanceInformation = "Invoice 29582",
                        },
                        Other = new(),
                        WireDecline = new()
                        {
                            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                            Reason = DeclinedTransactions::WireDeclineReason.AccountNumberDisabled,
                        },
                    },
                    Type = DeclinedTransactions::DeclinedTransactionType.DeclinedTransaction,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DeclinedTransactions::DeclinedTransactionListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<DeclinedTransactions::DeclinedTransaction> expectedData =
        [
            new()
            {
                ID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                AccountID = "account_in71c4amph0vgo2qllky",
                Amount = 1750,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = DeclinedTransactions::Currency.Usd,
                Description = "INVOICE 2468",
                RouteID = "account_number_v18nkfqm6afpsrvy82b2",
                RouteType = DeclinedTransactions::RouteType.AccountNumber,
                Source = new()
                {
                    Category = DeclinedTransactions::SourceCategory.AchDecline,
                    AchDecline = new()
                    {
                        ID = "ach_decline_72v1mcwxudctq56efipa",
                        Amount = 1750,
                        InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                        OriginatorCompanyDescriptiveDate = null,
                        OriginatorCompanyDiscretionaryData = null,
                        OriginatorCompanyID = "0987654321",
                        OriginatorCompanyName = "BIG BANK",
                        Reason = DeclinedTransactions::Reason.InsufficientFunds,
                        ReceiverIDNumber = "12345678900",
                        ReceiverName = "IAN CREASE",
                        TraceNumber = "021000038461022",
                        Type = DeclinedTransactions::Type.AchDecline,
                    },
                    CardDecline = new()
                    {
                        ID = "card_decline_bx3o8zd7glq8yvtwg25v",
                        Actioner = DeclinedTransactions::Actioner.Increase,
                        AdditionalAmounts = new()
                        {
                            Clinic = new() { Amount = 0, Currency = "currency" },
                            Dental = new() { Amount = 0, Currency = "currency" },
                            Original = new() { Amount = 0, Currency = "currency" },
                            Prescription = new() { Amount = 0, Currency = "currency" },
                            Surcharge = new() { Amount = 10, Currency = "USD" },
                            TotalCumulative = new() { Amount = 0, Currency = "currency" },
                            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                            Transit = new() { Amount = 0, Currency = "currency" },
                            Unknown = new() { Amount = 0, Currency = "currency" },
                            Vision = new() { Amount = 0, Currency = "currency" },
                        },
                        Amount = -1000,
                        CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                        Currency = DeclinedTransactions::CardDeclineCurrency.Usd,
                        DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                        DigitalWalletTokenID = null,
                        Direction = DeclinedTransactions::Direction.Settlement,
                        IncrementedCardAuthorizationID = null,
                        MerchantAcceptorID = "5665270011000168",
                        MerchantCategoryCode = "5734",
                        MerchantCity = "New York",
                        MerchantCountry = "US",
                        MerchantDescriptor = "AMAZON.COM",
                        MerchantPostalCode = "10045",
                        MerchantState = null,
                        NetworkDetails = new()
                        {
                            Category = DeclinedTransactions::NetworkDetailsCategory.Visa,
                            Pulse = new(),
                            Visa = new()
                            {
                                ElectronicCommerceIndicator =
                                    DeclinedTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                PointOfServiceEntryMode =
                                    DeclinedTransactions::PointOfServiceEntryMode.Manual,
                                StandInProcessingReason = null,
                                TerminalEntryCapability =
                                    DeclinedTransactions::TerminalEntryCapability.MagneticStripe,
                            },
                        },
                        NetworkIdentifiers = new()
                        {
                            AuthorizationIdentificationResponse = null,
                            RetrievalReferenceNumber = "785867080153",
                            TraceNumber = "487941",
                            TransactionID = "627199945183184",
                        },
                        NetworkRiskScore = 10,
                        PhysicalCardID = null,
                        PresentmentAmount = -1000,
                        PresentmentCurrency = "USD",
                        ProcessingCategory = DeclinedTransactions::ProcessingCategory.Purchase,
                        RealTimeDecisionID = null,
                        RealTimeDecisionReason = null,
                        Reason = DeclinedTransactions::CardDeclineReason.InsufficientFunds,
                        TerminalID = "RCN5VNXS",
                        Verification = new()
                        {
                            CardVerificationCode = new(DeclinedTransactions::Result.Match),
                            CardholderAddress = new()
                            {
                                ActualLine1 = "33 Liberty Street",
                                ActualPostalCode = "94131",
                                ProvidedLine1 = "33 Liberty Street",
                                ProvidedPostalCode = "94132",
                                Result =
                                    DeclinedTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                            },
                            CardholderName = new()
                            {
                                ProvidedFirstName = "provided_first_name",
                                ProvidedLastName = "provided_last_name",
                                ProvidedMiddleName = "provided_middle_name",
                            },
                        },
                    },
                    CheckDecline = new()
                    {
                        Amount = -1000,
                        AuxiliaryOnUs = "99999",
                        BackImageFileID = null,
                        CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                        FrontImageFileID = null,
                        InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                        Reason = DeclinedTransactions::CheckDeclineReason.InsufficientFunds,
                    },
                    CheckDepositRejection = new()
                    {
                        Amount = 1750,
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = DeclinedTransactions::CheckDepositRejectionCurrency.Usd,
                        DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                        Reason = DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage,
                        RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    },
                    InboundFednowTransferDecline = new()
                    {
                        Reason =
                            DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled,
                        TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                    },
                    InboundRealTimePaymentsTransferDecline = new()
                    {
                        Amount = 100,
                        CreditorName = "Ian Crease",
                        Currency =
                            DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
                        DebtorAccountNumber = "987654321",
                        DebtorName = "National Phonograph Company",
                        DebtorRoutingNumber = "101050001",
                        Reason =
                            DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled,
                        TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                        TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                    Other = new(),
                    WireDecline = new()
                    {
                        InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                        Reason = DeclinedTransactions::WireDeclineReason.AccountNumberDisabled,
                    },
                },
                Type = DeclinedTransactions::DeclinedTransactionType.DeclinedTransaction,
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
        var model = new DeclinedTransactions::DeclinedTransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Amount = 1750,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = DeclinedTransactions::Currency.Usd,
                    Description = "INVOICE 2468",
                    RouteID = "account_number_v18nkfqm6afpsrvy82b2",
                    RouteType = DeclinedTransactions::RouteType.AccountNumber,
                    Source = new()
                    {
                        Category = DeclinedTransactions::SourceCategory.AchDecline,
                        AchDecline = new()
                        {
                            ID = "ach_decline_72v1mcwxudctq56efipa",
                            Amount = 1750,
                            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                            OriginatorCompanyDescriptiveDate = null,
                            OriginatorCompanyDiscretionaryData = null,
                            OriginatorCompanyID = "0987654321",
                            OriginatorCompanyName = "BIG BANK",
                            Reason = DeclinedTransactions::Reason.InsufficientFunds,
                            ReceiverIDNumber = "12345678900",
                            ReceiverName = "IAN CREASE",
                            TraceNumber = "021000038461022",
                            Type = DeclinedTransactions::Type.AchDecline,
                        },
                        CardDecline = new()
                        {
                            ID = "card_decline_bx3o8zd7glq8yvtwg25v",
                            Actioner = DeclinedTransactions::Actioner.Increase,
                            AdditionalAmounts = new()
                            {
                                Clinic = new() { Amount = 0, Currency = "currency" },
                                Dental = new() { Amount = 0, Currency = "currency" },
                                Original = new() { Amount = 0, Currency = "currency" },
                                Prescription = new() { Amount = 0, Currency = "currency" },
                                Surcharge = new() { Amount = 10, Currency = "USD" },
                                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                                Transit = new() { Amount = 0, Currency = "currency" },
                                Unknown = new() { Amount = 0, Currency = "currency" },
                                Vision = new() { Amount = 0, Currency = "currency" },
                            },
                            Amount = -1000,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Currency = DeclinedTransactions::CardDeclineCurrency.Usd,
                            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                            DigitalWalletTokenID = null,
                            Direction = DeclinedTransactions::Direction.Settlement,
                            IncrementedCardAuthorizationID = null,
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantDescriptor = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = null,
                            NetworkDetails = new()
                            {
                                Category = DeclinedTransactions::NetworkDetailsCategory.Visa,
                                Pulse = new(),
                                Visa = new()
                                {
                                    ElectronicCommerceIndicator =
                                        DeclinedTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                    PointOfServiceEntryMode =
                                        DeclinedTransactions::PointOfServiceEntryMode.Manual,
                                    StandInProcessingReason = null,
                                    TerminalEntryCapability =
                                        DeclinedTransactions::TerminalEntryCapability.MagneticStripe,
                                },
                            },
                            NetworkIdentifiers = new()
                            {
                                AuthorizationIdentificationResponse = null,
                                RetrievalReferenceNumber = "785867080153",
                                TraceNumber = "487941",
                                TransactionID = "627199945183184",
                            },
                            NetworkRiskScore = 10,
                            PhysicalCardID = null,
                            PresentmentAmount = -1000,
                            PresentmentCurrency = "USD",
                            ProcessingCategory = DeclinedTransactions::ProcessingCategory.Purchase,
                            RealTimeDecisionID = null,
                            RealTimeDecisionReason = null,
                            Reason = DeclinedTransactions::CardDeclineReason.InsufficientFunds,
                            TerminalID = "RCN5VNXS",
                            Verification = new()
                            {
                                CardVerificationCode = new(DeclinedTransactions::Result.Match),
                                CardholderAddress = new()
                                {
                                    ActualLine1 = "33 Liberty Street",
                                    ActualPostalCode = "94131",
                                    ProvidedLine1 = "33 Liberty Street",
                                    ProvidedPostalCode = "94132",
                                    Result =
                                        DeclinedTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                                },
                                CardholderName = new()
                                {
                                    ProvidedFirstName = "provided_first_name",
                                    ProvidedLastName = "provided_last_name",
                                    ProvidedMiddleName = "provided_middle_name",
                                },
                            },
                        },
                        CheckDecline = new()
                        {
                            Amount = -1000,
                            AuxiliaryOnUs = "99999",
                            BackImageFileID = null,
                            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                            FrontImageFileID = null,
                            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                            Reason = DeclinedTransactions::CheckDeclineReason.InsufficientFunds,
                        },
                        CheckDepositRejection = new()
                        {
                            Amount = 1750,
                            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                            Currency = DeclinedTransactions::CheckDepositRejectionCurrency.Usd,
                            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                            Reason =
                                DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage,
                            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        },
                        InboundFednowTransferDecline = new()
                        {
                            Reason =
                                DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled,
                            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                        },
                        InboundRealTimePaymentsTransferDecline = new()
                        {
                            Amount = 100,
                            CreditorName = "Ian Crease",
                            Currency =
                                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
                            DebtorAccountNumber = "987654321",
                            DebtorName = "National Phonograph Company",
                            DebtorRoutingNumber = "101050001",
                            Reason =
                                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled,
                            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                            TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                            UnstructuredRemittanceInformation = "Invoice 29582",
                        },
                        Other = new(),
                        WireDecline = new()
                        {
                            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                            Reason = DeclinedTransactions::WireDeclineReason.AccountNumberDisabled,
                        },
                    },
                    Type = DeclinedTransactions::DeclinedTransactionType.DeclinedTransaction,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::DeclinedTransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Amount = 1750,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = DeclinedTransactions::Currency.Usd,
                    Description = "INVOICE 2468",
                    RouteID = "account_number_v18nkfqm6afpsrvy82b2",
                    RouteType = DeclinedTransactions::RouteType.AccountNumber,
                    Source = new()
                    {
                        Category = DeclinedTransactions::SourceCategory.AchDecline,
                        AchDecline = new()
                        {
                            ID = "ach_decline_72v1mcwxudctq56efipa",
                            Amount = 1750,
                            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                            OriginatorCompanyDescriptiveDate = null,
                            OriginatorCompanyDiscretionaryData = null,
                            OriginatorCompanyID = "0987654321",
                            OriginatorCompanyName = "BIG BANK",
                            Reason = DeclinedTransactions::Reason.InsufficientFunds,
                            ReceiverIDNumber = "12345678900",
                            ReceiverName = "IAN CREASE",
                            TraceNumber = "021000038461022",
                            Type = DeclinedTransactions::Type.AchDecline,
                        },
                        CardDecline = new()
                        {
                            ID = "card_decline_bx3o8zd7glq8yvtwg25v",
                            Actioner = DeclinedTransactions::Actioner.Increase,
                            AdditionalAmounts = new()
                            {
                                Clinic = new() { Amount = 0, Currency = "currency" },
                                Dental = new() { Amount = 0, Currency = "currency" },
                                Original = new() { Amount = 0, Currency = "currency" },
                                Prescription = new() { Amount = 0, Currency = "currency" },
                                Surcharge = new() { Amount = 10, Currency = "USD" },
                                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                                Transit = new() { Amount = 0, Currency = "currency" },
                                Unknown = new() { Amount = 0, Currency = "currency" },
                                Vision = new() { Amount = 0, Currency = "currency" },
                            },
                            Amount = -1000,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Currency = DeclinedTransactions::CardDeclineCurrency.Usd,
                            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                            DigitalWalletTokenID = null,
                            Direction = DeclinedTransactions::Direction.Settlement,
                            IncrementedCardAuthorizationID = null,
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantDescriptor = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = null,
                            NetworkDetails = new()
                            {
                                Category = DeclinedTransactions::NetworkDetailsCategory.Visa,
                                Pulse = new(),
                                Visa = new()
                                {
                                    ElectronicCommerceIndicator =
                                        DeclinedTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                    PointOfServiceEntryMode =
                                        DeclinedTransactions::PointOfServiceEntryMode.Manual,
                                    StandInProcessingReason = null,
                                    TerminalEntryCapability =
                                        DeclinedTransactions::TerminalEntryCapability.MagneticStripe,
                                },
                            },
                            NetworkIdentifiers = new()
                            {
                                AuthorizationIdentificationResponse = null,
                                RetrievalReferenceNumber = "785867080153",
                                TraceNumber = "487941",
                                TransactionID = "627199945183184",
                            },
                            NetworkRiskScore = 10,
                            PhysicalCardID = null,
                            PresentmentAmount = -1000,
                            PresentmentCurrency = "USD",
                            ProcessingCategory = DeclinedTransactions::ProcessingCategory.Purchase,
                            RealTimeDecisionID = null,
                            RealTimeDecisionReason = null,
                            Reason = DeclinedTransactions::CardDeclineReason.InsufficientFunds,
                            TerminalID = "RCN5VNXS",
                            Verification = new()
                            {
                                CardVerificationCode = new(DeclinedTransactions::Result.Match),
                                CardholderAddress = new()
                                {
                                    ActualLine1 = "33 Liberty Street",
                                    ActualPostalCode = "94131",
                                    ProvidedLine1 = "33 Liberty Street",
                                    ProvidedPostalCode = "94132",
                                    Result =
                                        DeclinedTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                                },
                                CardholderName = new()
                                {
                                    ProvidedFirstName = "provided_first_name",
                                    ProvidedLastName = "provided_last_name",
                                    ProvidedMiddleName = "provided_middle_name",
                                },
                            },
                        },
                        CheckDecline = new()
                        {
                            Amount = -1000,
                            AuxiliaryOnUs = "99999",
                            BackImageFileID = null,
                            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                            FrontImageFileID = null,
                            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                            Reason = DeclinedTransactions::CheckDeclineReason.InsufficientFunds,
                        },
                        CheckDepositRejection = new()
                        {
                            Amount = 1750,
                            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                            Currency = DeclinedTransactions::CheckDepositRejectionCurrency.Usd,
                            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                            Reason =
                                DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage,
                            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        },
                        InboundFednowTransferDecline = new()
                        {
                            Reason =
                                DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled,
                            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                        },
                        InboundRealTimePaymentsTransferDecline = new()
                        {
                            Amount = 100,
                            CreditorName = "Ian Crease",
                            Currency =
                                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
                            DebtorAccountNumber = "987654321",
                            DebtorName = "National Phonograph Company",
                            DebtorRoutingNumber = "101050001",
                            Reason =
                                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled,
                            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                            TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                            UnstructuredRemittanceInformation = "Invoice 29582",
                        },
                        Other = new(),
                        WireDecline = new()
                        {
                            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                            Reason = DeclinedTransactions::WireDeclineReason.AccountNumberDisabled,
                        },
                    },
                    Type = DeclinedTransactions::DeclinedTransactionType.DeclinedTransaction,
                },
            ],
            NextCursor = "v57w5d",
        };

        DeclinedTransactions::DeclinedTransactionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
