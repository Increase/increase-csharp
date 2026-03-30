using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using DeclinedTransactions = Increase.Api.Models.DeclinedTransactions;

namespace Increase.Api.Tests.Models.DeclinedTransactions;

public class DeclinedTransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::DeclinedTransaction
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
                    SchemeFees =
                    [
                        new()
                        {
                            Amount = "0.137465",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                            FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                            FixedComponent = null,
                            VariableRate = "0.0002",
                        },
                    ],
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
        };

        string expectedID = "declined_transaction_17jbn0yyhvkt4v4ooym8";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAmount = 1750;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, DeclinedTransactions::Currency> expectedCurrency =
            DeclinedTransactions::Currency.Usd;
        string expectedDescription = "INVOICE 2468";
        string expectedRouteID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, DeclinedTransactions::RouteType> expectedRouteType =
            DeclinedTransactions::RouteType.AccountNumber;
        DeclinedTransactions::Source expectedSource = new()
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
                SchemeFees =
                [
                    new()
                    {
                        Amount = "0.137465",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                        FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                        FixedComponent = null,
                        VariableRate = "0.0002",
                    },
                ],
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
                Currency = DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
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
        };
        ApiEnum<string, DeclinedTransactions::DeclinedTransactionType> expectedType =
            DeclinedTransactions::DeclinedTransactionType.DeclinedTransaction;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedRouteID, model.RouteID);
        Assert.Equal(expectedRouteType, model.RouteType);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::DeclinedTransaction
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
                    SchemeFees =
                    [
                        new()
                        {
                            Amount = "0.137465",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                            FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                            FixedComponent = null,
                            VariableRate = "0.0002",
                        },
                    ],
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::DeclinedTransaction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::DeclinedTransaction
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
                    SchemeFees =
                    [
                        new()
                        {
                            Amount = "0.137465",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                            FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                            FixedComponent = null,
                            VariableRate = "0.0002",
                        },
                    ],
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::DeclinedTransaction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "declined_transaction_17jbn0yyhvkt4v4ooym8";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAmount = 1750;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, DeclinedTransactions::Currency> expectedCurrency =
            DeclinedTransactions::Currency.Usd;
        string expectedDescription = "INVOICE 2468";
        string expectedRouteID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, DeclinedTransactions::RouteType> expectedRouteType =
            DeclinedTransactions::RouteType.AccountNumber;
        DeclinedTransactions::Source expectedSource = new()
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
                SchemeFees =
                [
                    new()
                    {
                        Amount = "0.137465",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                        FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                        FixedComponent = null,
                        VariableRate = "0.0002",
                    },
                ],
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
                Currency = DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
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
        };
        ApiEnum<string, DeclinedTransactions::DeclinedTransactionType> expectedType =
            DeclinedTransactions::DeclinedTransactionType.DeclinedTransaction;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedRouteID, deserialized.RouteID);
        Assert.Equal(expectedRouteType, deserialized.RouteType);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::DeclinedTransaction
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
                    SchemeFees =
                    [
                        new()
                        {
                            Amount = "0.137465",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                            FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                            FixedComponent = null,
                            VariableRate = "0.0002",
                        },
                    ],
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::DeclinedTransaction
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
                    SchemeFees =
                    [
                        new()
                        {
                            Amount = "0.137465",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                            FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                            FixedComponent = null,
                            VariableRate = "0.0002",
                        },
                    ],
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
        };

        DeclinedTransactions::DeclinedTransaction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::Currency.Usd)]
    public void Validation_Works(DeclinedTransactions::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::Currency.Usd)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::Currency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::Currency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RouteTypeTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::RouteType.AccountNumber)]
    [InlineData(DeclinedTransactions::RouteType.Card)]
    [InlineData(DeclinedTransactions::RouteType.Lockbox)]
    public void Validation_Works(DeclinedTransactions::RouteType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::RouteType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::RouteType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::RouteType.AccountNumber)]
    [InlineData(DeclinedTransactions::RouteType.Card)]
    [InlineData(DeclinedTransactions::RouteType.Lockbox)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::RouteType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::RouteType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::RouteType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::RouteType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::RouteType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Source
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
                SchemeFees =
                [
                    new()
                    {
                        Amount = "0.137465",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                        FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                        FixedComponent = null,
                        VariableRate = "0.0002",
                    },
                ],
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
                Currency = DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
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
        };

        ApiEnum<string, DeclinedTransactions::SourceCategory> expectedCategory =
            DeclinedTransactions::SourceCategory.AchDecline;
        DeclinedTransactions::AchDecline expectedAchDecline = new()
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
        };
        DeclinedTransactions::CardDecline expectedCardDecline = new()
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
                    PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Manual,
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
            SchemeFees =
            [
                new()
                {
                    Amount = "0.137465",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                    FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                    FixedComponent = null,
                    VariableRate = "0.0002",
                },
            ],
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
        };
        DeclinedTransactions::CheckDecline expectedCheckDecline = new()
        {
            Amount = -1000,
            AuxiliaryOnUs = "99999",
            BackImageFileID = null,
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
            FrontImageFileID = null,
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
            Reason = DeclinedTransactions::CheckDeclineReason.InsufficientFunds,
        };
        DeclinedTransactions::CheckDepositRejection expectedCheckDepositRejection = new()
        {
            Amount = 1750,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = DeclinedTransactions::CheckDepositRejectionCurrency.Usd,
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
            Reason = DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        DeclinedTransactions::InboundFednowTransferDecline expectedInboundFednowTransferDecline =
            new()
            {
                Reason =
                    DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled,
                TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
            };
        DeclinedTransactions::InboundRealTimePaymentsTransferDecline expectedInboundRealTimePaymentsTransferDecline =
            new()
            {
                Amount = 100,
                CreditorName = "Ian Crease",
                Currency = DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
                DebtorAccountNumber = "987654321",
                DebtorName = "National Phonograph Company",
                DebtorRoutingNumber = "101050001",
                Reason =
                    DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled,
                TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                UnstructuredRemittanceInformation = "Invoice 29582",
            };
        DeclinedTransactions::Other expectedOther = new();
        DeclinedTransactions::WireDecline expectedWireDecline = new()
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
            Reason = DeclinedTransactions::WireDeclineReason.AccountNumberDisabled,
        };

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedAchDecline, model.AchDecline);
        Assert.Equal(expectedCardDecline, model.CardDecline);
        Assert.Equal(expectedCheckDecline, model.CheckDecline);
        Assert.Equal(expectedCheckDepositRejection, model.CheckDepositRejection);
        Assert.Equal(expectedInboundFednowTransferDecline, model.InboundFednowTransferDecline);
        Assert.Equal(
            expectedInboundRealTimePaymentsTransferDecline,
            model.InboundRealTimePaymentsTransferDecline
        );
        Assert.Equal(expectedOther, model.Other);
        Assert.Equal(expectedWireDecline, model.WireDecline);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Source
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
                SchemeFees =
                [
                    new()
                    {
                        Amount = "0.137465",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                        FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                        FixedComponent = null,
                        VariableRate = "0.0002",
                    },
                ],
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
                Currency = DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Source>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::Source
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
                SchemeFees =
                [
                    new()
                    {
                        Amount = "0.137465",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                        FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                        FixedComponent = null,
                        VariableRate = "0.0002",
                    },
                ],
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
                Currency = DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Source>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, DeclinedTransactions::SourceCategory> expectedCategory =
            DeclinedTransactions::SourceCategory.AchDecline;
        DeclinedTransactions::AchDecline expectedAchDecline = new()
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
        };
        DeclinedTransactions::CardDecline expectedCardDecline = new()
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
                    PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Manual,
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
            SchemeFees =
            [
                new()
                {
                    Amount = "0.137465",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                    FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                    FixedComponent = null,
                    VariableRate = "0.0002",
                },
            ],
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
        };
        DeclinedTransactions::CheckDecline expectedCheckDecline = new()
        {
            Amount = -1000,
            AuxiliaryOnUs = "99999",
            BackImageFileID = null,
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
            FrontImageFileID = null,
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
            Reason = DeclinedTransactions::CheckDeclineReason.InsufficientFunds,
        };
        DeclinedTransactions::CheckDepositRejection expectedCheckDepositRejection = new()
        {
            Amount = 1750,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = DeclinedTransactions::CheckDepositRejectionCurrency.Usd,
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
            Reason = DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        DeclinedTransactions::InboundFednowTransferDecline expectedInboundFednowTransferDecline =
            new()
            {
                Reason =
                    DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled,
                TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
            };
        DeclinedTransactions::InboundRealTimePaymentsTransferDecline expectedInboundRealTimePaymentsTransferDecline =
            new()
            {
                Amount = 100,
                CreditorName = "Ian Crease",
                Currency = DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
                DebtorAccountNumber = "987654321",
                DebtorName = "National Phonograph Company",
                DebtorRoutingNumber = "101050001",
                Reason =
                    DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled,
                TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                UnstructuredRemittanceInformation = "Invoice 29582",
            };
        DeclinedTransactions::Other expectedOther = new();
        DeclinedTransactions::WireDecline expectedWireDecline = new()
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
            Reason = DeclinedTransactions::WireDeclineReason.AccountNumberDisabled,
        };

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedAchDecline, deserialized.AchDecline);
        Assert.Equal(expectedCardDecline, deserialized.CardDecline);
        Assert.Equal(expectedCheckDecline, deserialized.CheckDecline);
        Assert.Equal(expectedCheckDepositRejection, deserialized.CheckDepositRejection);
        Assert.Equal(
            expectedInboundFednowTransferDecline,
            deserialized.InboundFednowTransferDecline
        );
        Assert.Equal(
            expectedInboundRealTimePaymentsTransferDecline,
            deserialized.InboundRealTimePaymentsTransferDecline
        );
        Assert.Equal(expectedOther, deserialized.Other);
        Assert.Equal(expectedWireDecline, deserialized.WireDecline);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::Source
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
                SchemeFees =
                [
                    new()
                    {
                        Amount = "0.137465",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                        FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                        FixedComponent = null,
                        VariableRate = "0.0002",
                    },
                ],
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
                Currency = DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DeclinedTransactions::Source
        {
            Category = DeclinedTransactions::SourceCategory.AchDecline,
        };

        Assert.Null(model.AchDecline);
        Assert.False(model.RawData.ContainsKey("ach_decline"));
        Assert.Null(model.CardDecline);
        Assert.False(model.RawData.ContainsKey("card_decline"));
        Assert.Null(model.CheckDecline);
        Assert.False(model.RawData.ContainsKey("check_decline"));
        Assert.Null(model.CheckDepositRejection);
        Assert.False(model.RawData.ContainsKey("check_deposit_rejection"));
        Assert.Null(model.InboundFednowTransferDecline);
        Assert.False(model.RawData.ContainsKey("inbound_fednow_transfer_decline"));
        Assert.Null(model.InboundRealTimePaymentsTransferDecline);
        Assert.False(model.RawData.ContainsKey("inbound_real_time_payments_transfer_decline"));
        Assert.Null(model.Other);
        Assert.False(model.RawData.ContainsKey("other"));
        Assert.Null(model.WireDecline);
        Assert.False(model.RawData.ContainsKey("wire_decline"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DeclinedTransactions::Source
        {
            Category = DeclinedTransactions::SourceCategory.AchDecline,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DeclinedTransactions::Source
        {
            Category = DeclinedTransactions::SourceCategory.AchDecline,

            AchDecline = null,
            CardDecline = null,
            CheckDecline = null,
            CheckDepositRejection = null,
            InboundFednowTransferDecline = null,
            InboundRealTimePaymentsTransferDecline = null,
            Other = null,
            WireDecline = null,
        };

        Assert.Null(model.AchDecline);
        Assert.True(model.RawData.ContainsKey("ach_decline"));
        Assert.Null(model.CardDecline);
        Assert.True(model.RawData.ContainsKey("card_decline"));
        Assert.Null(model.CheckDecline);
        Assert.True(model.RawData.ContainsKey("check_decline"));
        Assert.Null(model.CheckDepositRejection);
        Assert.True(model.RawData.ContainsKey("check_deposit_rejection"));
        Assert.Null(model.InboundFednowTransferDecline);
        Assert.True(model.RawData.ContainsKey("inbound_fednow_transfer_decline"));
        Assert.Null(model.InboundRealTimePaymentsTransferDecline);
        Assert.True(model.RawData.ContainsKey("inbound_real_time_payments_transfer_decline"));
        Assert.Null(model.Other);
        Assert.True(model.RawData.ContainsKey("other"));
        Assert.Null(model.WireDecline);
        Assert.True(model.RawData.ContainsKey("wire_decline"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DeclinedTransactions::Source
        {
            Category = DeclinedTransactions::SourceCategory.AchDecline,

            AchDecline = null,
            CardDecline = null,
            CheckDecline = null,
            CheckDepositRejection = null,
            InboundFednowTransferDecline = null,
            InboundRealTimePaymentsTransferDecline = null,
            Other = null,
            WireDecline = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::Source
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
                SchemeFees =
                [
                    new()
                    {
                        Amount = "0.137465",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                        FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                        FixedComponent = null,
                        VariableRate = "0.0002",
                    },
                ],
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
                Currency = DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
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
        };

        DeclinedTransactions::Source copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SourceCategoryTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::SourceCategory.AchDecline)]
    [InlineData(DeclinedTransactions::SourceCategory.CardDecline)]
    [InlineData(DeclinedTransactions::SourceCategory.CheckDecline)]
    [InlineData(DeclinedTransactions::SourceCategory.InboundRealTimePaymentsTransferDecline)]
    [InlineData(DeclinedTransactions::SourceCategory.InboundFednowTransferDecline)]
    [InlineData(DeclinedTransactions::SourceCategory.WireDecline)]
    [InlineData(DeclinedTransactions::SourceCategory.CheckDepositRejection)]
    [InlineData(DeclinedTransactions::SourceCategory.Other)]
    public void Validation_Works(DeclinedTransactions::SourceCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::SourceCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::SourceCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::SourceCategory.AchDecline)]
    [InlineData(DeclinedTransactions::SourceCategory.CardDecline)]
    [InlineData(DeclinedTransactions::SourceCategory.CheckDecline)]
    [InlineData(DeclinedTransactions::SourceCategory.InboundRealTimePaymentsTransferDecline)]
    [InlineData(DeclinedTransactions::SourceCategory.InboundFednowTransferDecline)]
    [InlineData(DeclinedTransactions::SourceCategory.WireDecline)]
    [InlineData(DeclinedTransactions::SourceCategory.CheckDepositRejection)]
    [InlineData(DeclinedTransactions::SourceCategory.Other)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::SourceCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::SourceCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::SourceCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::SourceCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::SourceCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AchDeclineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::AchDecline
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
        };

        string expectedID = "ach_decline_72v1mcwxudctq56efipa";
        long expectedAmount = 1750;
        string expectedInboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev";
        string expectedOriginatorCompanyID = "0987654321";
        string expectedOriginatorCompanyName = "BIG BANK";
        ApiEnum<string, DeclinedTransactions::Reason> expectedReason =
            DeclinedTransactions::Reason.InsufficientFunds;
        string expectedReceiverIDNumber = "12345678900";
        string expectedReceiverName = "IAN CREASE";
        string expectedTraceNumber = "021000038461022";
        ApiEnum<string, DeclinedTransactions::Type> expectedType =
            DeclinedTransactions::Type.AchDecline;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedInboundAchTransferID, model.InboundAchTransferID);
        Assert.Null(model.OriginatorCompanyDescriptiveDate);
        Assert.Null(model.OriginatorCompanyDiscretionaryData);
        Assert.Equal(expectedOriginatorCompanyID, model.OriginatorCompanyID);
        Assert.Equal(expectedOriginatorCompanyName, model.OriginatorCompanyName);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReceiverIDNumber, model.ReceiverIDNumber);
        Assert.Equal(expectedReceiverName, model.ReceiverName);
        Assert.Equal(expectedTraceNumber, model.TraceNumber);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::AchDecline
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::AchDecline>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::AchDecline
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::AchDecline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "ach_decline_72v1mcwxudctq56efipa";
        long expectedAmount = 1750;
        string expectedInboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev";
        string expectedOriginatorCompanyID = "0987654321";
        string expectedOriginatorCompanyName = "BIG BANK";
        ApiEnum<string, DeclinedTransactions::Reason> expectedReason =
            DeclinedTransactions::Reason.InsufficientFunds;
        string expectedReceiverIDNumber = "12345678900";
        string expectedReceiverName = "IAN CREASE";
        string expectedTraceNumber = "021000038461022";
        ApiEnum<string, DeclinedTransactions::Type> expectedType =
            DeclinedTransactions::Type.AchDecline;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedInboundAchTransferID, deserialized.InboundAchTransferID);
        Assert.Null(deserialized.OriginatorCompanyDescriptiveDate);
        Assert.Null(deserialized.OriginatorCompanyDiscretionaryData);
        Assert.Equal(expectedOriginatorCompanyID, deserialized.OriginatorCompanyID);
        Assert.Equal(expectedOriginatorCompanyName, deserialized.OriginatorCompanyName);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReceiverIDNumber, deserialized.ReceiverIDNumber);
        Assert.Equal(expectedReceiverName, deserialized.ReceiverName);
        Assert.Equal(expectedTraceNumber, deserialized.TraceNumber);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::AchDecline
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::AchDecline
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
        };

        DeclinedTransactions::AchDecline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::Reason.AchRouteCanceled)]
    [InlineData(DeclinedTransactions::Reason.AchRouteDisabled)]
    [InlineData(DeclinedTransactions::Reason.BreachesLimit)]
    [InlineData(DeclinedTransactions::Reason.EntityNotActive)]
    [InlineData(DeclinedTransactions::Reason.GroupLocked)]
    [InlineData(DeclinedTransactions::Reason.TransactionNotAllowed)]
    [InlineData(DeclinedTransactions::Reason.UserInitiated)]
    [InlineData(DeclinedTransactions::Reason.InsufficientFunds)]
    [InlineData(DeclinedTransactions::Reason.ReturnedPerOdfiRequest)]
    [InlineData(DeclinedTransactions::Reason.AuthorizationRevokedByCustomer)]
    [InlineData(DeclinedTransactions::Reason.PaymentStopped)]
    [InlineData(
        DeclinedTransactions::Reason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete
    )]
    [InlineData(
        DeclinedTransactions::Reason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity
    )]
    [InlineData(DeclinedTransactions::Reason.BeneficiaryOrAccountHolderDeceased)]
    [InlineData(DeclinedTransactions::Reason.CreditEntryRefusedByReceiver)]
    [InlineData(DeclinedTransactions::Reason.DuplicateEntry)]
    [InlineData(DeclinedTransactions::Reason.CorporateCustomerAdvisedNotAuthorized)]
    public void Validation_Works(DeclinedTransactions::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::Reason.AchRouteCanceled)]
    [InlineData(DeclinedTransactions::Reason.AchRouteDisabled)]
    [InlineData(DeclinedTransactions::Reason.BreachesLimit)]
    [InlineData(DeclinedTransactions::Reason.EntityNotActive)]
    [InlineData(DeclinedTransactions::Reason.GroupLocked)]
    [InlineData(DeclinedTransactions::Reason.TransactionNotAllowed)]
    [InlineData(DeclinedTransactions::Reason.UserInitiated)]
    [InlineData(DeclinedTransactions::Reason.InsufficientFunds)]
    [InlineData(DeclinedTransactions::Reason.ReturnedPerOdfiRequest)]
    [InlineData(DeclinedTransactions::Reason.AuthorizationRevokedByCustomer)]
    [InlineData(DeclinedTransactions::Reason.PaymentStopped)]
    [InlineData(
        DeclinedTransactions::Reason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete
    )]
    [InlineData(
        DeclinedTransactions::Reason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity
    )]
    [InlineData(DeclinedTransactions::Reason.BeneficiaryOrAccountHolderDeceased)]
    [InlineData(DeclinedTransactions::Reason.CreditEntryRefusedByReceiver)]
    [InlineData(DeclinedTransactions::Reason.DuplicateEntry)]
    [InlineData(DeclinedTransactions::Reason.CorporateCustomerAdvisedNotAuthorized)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::Reason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::Reason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::Type.AchDecline)]
    public void Validation_Works(DeclinedTransactions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::Type.AchDecline)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CardDeclineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::CardDecline
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
                    PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Manual,
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
            SchemeFees =
            [
                new()
                {
                    Amount = "0.137465",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                    FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                    FixedComponent = null,
                    VariableRate = "0.0002",
                },
            ],
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
        };

        string expectedID = "card_decline_bx3o8zd7glq8yvtwg25v";
        ApiEnum<string, DeclinedTransactions::Actioner> expectedActioner =
            DeclinedTransactions::Actioner.Increase;
        DeclinedTransactions::AdditionalAmounts expectedAdditionalAmounts = new()
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
        };
        long expectedAmount = -1000;
        string expectedCardPaymentID = "card_payment_nd3k2kacrqjli8482ave";
        ApiEnum<string, DeclinedTransactions::CardDeclineCurrency> expectedCurrency =
            DeclinedTransactions::CardDeclineCurrency.Usd;
        string expectedDeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8";
        ApiEnum<string, DeclinedTransactions::Direction> expectedDirection =
            DeclinedTransactions::Direction.Settlement;
        string expectedMerchantAcceptorID = "5665270011000168";
        string expectedMerchantCategoryCode = "5734";
        string expectedMerchantCity = "New York";
        string expectedMerchantCountry = "US";
        string expectedMerchantDescriptor = "AMAZON.COM";
        string expectedMerchantPostalCode = "10045";
        DeclinedTransactions::NetworkDetails expectedNetworkDetails = new()
        {
            Category = DeclinedTransactions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    DeclinedTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Manual,
                StandInProcessingReason = null,
                TerminalEntryCapability =
                    DeclinedTransactions::TerminalEntryCapability.MagneticStripe,
            },
        };
        DeclinedTransactions::NetworkIdentifiers expectedNetworkIdentifiers = new()
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };
        long expectedNetworkRiskScore = 10;
        long expectedPresentmentAmount = -1000;
        string expectedPresentmentCurrency = "USD";
        ApiEnum<string, DeclinedTransactions::ProcessingCategory> expectedProcessingCategory =
            DeclinedTransactions::ProcessingCategory.Purchase;
        ApiEnum<string, DeclinedTransactions::CardDeclineReason> expectedReason =
            DeclinedTransactions::CardDeclineReason.InsufficientFunds;
        List<DeclinedTransactions::SchemeFee> expectedSchemeFees =
        [
            new()
            {
                Amount = "0.137465",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                FixedComponent = null,
                VariableRate = "0.0002",
            },
        ];
        string expectedTerminalID = "RCN5VNXS";
        DeclinedTransactions::Verification expectedVerification = new()
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
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedActioner, model.Actioner);
        Assert.Equal(expectedAdditionalAmounts, model.AdditionalAmounts);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCardPaymentID, model.CardPaymentID);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDeclinedTransactionID, model.DeclinedTransactionID);
        Assert.Null(model.DigitalWalletTokenID);
        Assert.Equal(expectedDirection, model.Direction);
        Assert.Null(model.IncrementedCardAuthorizationID);
        Assert.Equal(expectedMerchantAcceptorID, model.MerchantAcceptorID);
        Assert.Equal(expectedMerchantCategoryCode, model.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCity, model.MerchantCity);
        Assert.Equal(expectedMerchantCountry, model.MerchantCountry);
        Assert.Equal(expectedMerchantDescriptor, model.MerchantDescriptor);
        Assert.Equal(expectedMerchantPostalCode, model.MerchantPostalCode);
        Assert.Null(model.MerchantState);
        Assert.Equal(expectedNetworkDetails, model.NetworkDetails);
        Assert.Equal(expectedNetworkIdentifiers, model.NetworkIdentifiers);
        Assert.Equal(expectedNetworkRiskScore, model.NetworkRiskScore);
        Assert.Null(model.PhysicalCardID);
        Assert.Equal(expectedPresentmentAmount, model.PresentmentAmount);
        Assert.Equal(expectedPresentmentCurrency, model.PresentmentCurrency);
        Assert.Equal(expectedProcessingCategory, model.ProcessingCategory);
        Assert.Null(model.RealTimeDecisionID);
        Assert.Null(model.RealTimeDecisionReason);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedSchemeFees.Count, model.SchemeFees.Count);
        for (int i = 0; i < expectedSchemeFees.Count; i++)
        {
            Assert.Equal(expectedSchemeFees[i], model.SchemeFees[i]);
        }
        Assert.Equal(expectedTerminalID, model.TerminalID);
        Assert.Equal(expectedVerification, model.Verification);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::CardDecline
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
                    PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Manual,
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
            SchemeFees =
            [
                new()
                {
                    Amount = "0.137465",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                    FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                    FixedComponent = null,
                    VariableRate = "0.0002",
                },
            ],
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::CardDecline>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::CardDecline
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
                    PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Manual,
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
            SchemeFees =
            [
                new()
                {
                    Amount = "0.137465",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                    FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                    FixedComponent = null,
                    VariableRate = "0.0002",
                },
            ],
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::CardDecline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "card_decline_bx3o8zd7glq8yvtwg25v";
        ApiEnum<string, DeclinedTransactions::Actioner> expectedActioner =
            DeclinedTransactions::Actioner.Increase;
        DeclinedTransactions::AdditionalAmounts expectedAdditionalAmounts = new()
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
        };
        long expectedAmount = -1000;
        string expectedCardPaymentID = "card_payment_nd3k2kacrqjli8482ave";
        ApiEnum<string, DeclinedTransactions::CardDeclineCurrency> expectedCurrency =
            DeclinedTransactions::CardDeclineCurrency.Usd;
        string expectedDeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8";
        ApiEnum<string, DeclinedTransactions::Direction> expectedDirection =
            DeclinedTransactions::Direction.Settlement;
        string expectedMerchantAcceptorID = "5665270011000168";
        string expectedMerchantCategoryCode = "5734";
        string expectedMerchantCity = "New York";
        string expectedMerchantCountry = "US";
        string expectedMerchantDescriptor = "AMAZON.COM";
        string expectedMerchantPostalCode = "10045";
        DeclinedTransactions::NetworkDetails expectedNetworkDetails = new()
        {
            Category = DeclinedTransactions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    DeclinedTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Manual,
                StandInProcessingReason = null,
                TerminalEntryCapability =
                    DeclinedTransactions::TerminalEntryCapability.MagneticStripe,
            },
        };
        DeclinedTransactions::NetworkIdentifiers expectedNetworkIdentifiers = new()
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };
        long expectedNetworkRiskScore = 10;
        long expectedPresentmentAmount = -1000;
        string expectedPresentmentCurrency = "USD";
        ApiEnum<string, DeclinedTransactions::ProcessingCategory> expectedProcessingCategory =
            DeclinedTransactions::ProcessingCategory.Purchase;
        ApiEnum<string, DeclinedTransactions::CardDeclineReason> expectedReason =
            DeclinedTransactions::CardDeclineReason.InsufficientFunds;
        List<DeclinedTransactions::SchemeFee> expectedSchemeFees =
        [
            new()
            {
                Amount = "0.137465",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                FixedComponent = null,
                VariableRate = "0.0002",
            },
        ];
        string expectedTerminalID = "RCN5VNXS";
        DeclinedTransactions::Verification expectedVerification = new()
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
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedActioner, deserialized.Actioner);
        Assert.Equal(expectedAdditionalAmounts, deserialized.AdditionalAmounts);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCardPaymentID, deserialized.CardPaymentID);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDeclinedTransactionID, deserialized.DeclinedTransactionID);
        Assert.Null(deserialized.DigitalWalletTokenID);
        Assert.Equal(expectedDirection, deserialized.Direction);
        Assert.Null(deserialized.IncrementedCardAuthorizationID);
        Assert.Equal(expectedMerchantAcceptorID, deserialized.MerchantAcceptorID);
        Assert.Equal(expectedMerchantCategoryCode, deserialized.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCity, deserialized.MerchantCity);
        Assert.Equal(expectedMerchantCountry, deserialized.MerchantCountry);
        Assert.Equal(expectedMerchantDescriptor, deserialized.MerchantDescriptor);
        Assert.Equal(expectedMerchantPostalCode, deserialized.MerchantPostalCode);
        Assert.Null(deserialized.MerchantState);
        Assert.Equal(expectedNetworkDetails, deserialized.NetworkDetails);
        Assert.Equal(expectedNetworkIdentifiers, deserialized.NetworkIdentifiers);
        Assert.Equal(expectedNetworkRiskScore, deserialized.NetworkRiskScore);
        Assert.Null(deserialized.PhysicalCardID);
        Assert.Equal(expectedPresentmentAmount, deserialized.PresentmentAmount);
        Assert.Equal(expectedPresentmentCurrency, deserialized.PresentmentCurrency);
        Assert.Equal(expectedProcessingCategory, deserialized.ProcessingCategory);
        Assert.Null(deserialized.RealTimeDecisionID);
        Assert.Null(deserialized.RealTimeDecisionReason);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedSchemeFees.Count, deserialized.SchemeFees.Count);
        for (int i = 0; i < expectedSchemeFees.Count; i++)
        {
            Assert.Equal(expectedSchemeFees[i], deserialized.SchemeFees[i]);
        }
        Assert.Equal(expectedTerminalID, deserialized.TerminalID);
        Assert.Equal(expectedVerification, deserialized.Verification);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::CardDecline
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
                    PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Manual,
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
            SchemeFees =
            [
                new()
                {
                    Amount = "0.137465",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                    FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                    FixedComponent = null,
                    VariableRate = "0.0002",
                },
            ],
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::CardDecline
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
                    PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Manual,
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
            SchemeFees =
            [
                new()
                {
                    Amount = "0.137465",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
                    FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
                    FixedComponent = null,
                    VariableRate = "0.0002",
                },
            ],
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
        };

        DeclinedTransactions::CardDecline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActionerTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::Actioner.User)]
    [InlineData(DeclinedTransactions::Actioner.Increase)]
    [InlineData(DeclinedTransactions::Actioner.Network)]
    public void Validation_Works(DeclinedTransactions::Actioner rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::Actioner> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::Actioner>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::Actioner.User)]
    [InlineData(DeclinedTransactions::Actioner.Increase)]
    [InlineData(DeclinedTransactions::Actioner.Network)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::Actioner rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::Actioner> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::Actioner>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::Actioner>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::Actioner>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AdditionalAmountsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::AdditionalAmounts
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };

        DeclinedTransactions::Clinic expectedClinic = new() { Amount = 0, Currency = "currency" };
        DeclinedTransactions::Dental expectedDental = new() { Amount = 0, Currency = "currency" };
        DeclinedTransactions::Original expectedOriginal = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        DeclinedTransactions::Prescription expectedPrescription = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        DeclinedTransactions::Surcharge expectedSurcharge = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        DeclinedTransactions::TotalCumulative expectedTotalCumulative = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        DeclinedTransactions::TotalHealthcare expectedTotalHealthcare = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        DeclinedTransactions::Transit expectedTransit = new() { Amount = 0, Currency = "currency" };
        DeclinedTransactions::Unknown expectedUnknown = new() { Amount = 0, Currency = "currency" };
        DeclinedTransactions::Vision expectedVision = new() { Amount = 0, Currency = "currency" };

        Assert.Equal(expectedClinic, model.Clinic);
        Assert.Equal(expectedDental, model.Dental);
        Assert.Equal(expectedOriginal, model.Original);
        Assert.Equal(expectedPrescription, model.Prescription);
        Assert.Equal(expectedSurcharge, model.Surcharge);
        Assert.Equal(expectedTotalCumulative, model.TotalCumulative);
        Assert.Equal(expectedTotalHealthcare, model.TotalHealthcare);
        Assert.Equal(expectedTransit, model.Transit);
        Assert.Equal(expectedUnknown, model.Unknown);
        Assert.Equal(expectedVision, model.Vision);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::AdditionalAmounts
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::AdditionalAmounts>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::AdditionalAmounts
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::AdditionalAmounts>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DeclinedTransactions::Clinic expectedClinic = new() { Amount = 0, Currency = "currency" };
        DeclinedTransactions::Dental expectedDental = new() { Amount = 0, Currency = "currency" };
        DeclinedTransactions::Original expectedOriginal = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        DeclinedTransactions::Prescription expectedPrescription = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        DeclinedTransactions::Surcharge expectedSurcharge = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        DeclinedTransactions::TotalCumulative expectedTotalCumulative = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        DeclinedTransactions::TotalHealthcare expectedTotalHealthcare = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        DeclinedTransactions::Transit expectedTransit = new() { Amount = 0, Currency = "currency" };
        DeclinedTransactions::Unknown expectedUnknown = new() { Amount = 0, Currency = "currency" };
        DeclinedTransactions::Vision expectedVision = new() { Amount = 0, Currency = "currency" };

        Assert.Equal(expectedClinic, deserialized.Clinic);
        Assert.Equal(expectedDental, deserialized.Dental);
        Assert.Equal(expectedOriginal, deserialized.Original);
        Assert.Equal(expectedPrescription, deserialized.Prescription);
        Assert.Equal(expectedSurcharge, deserialized.Surcharge);
        Assert.Equal(expectedTotalCumulative, deserialized.TotalCumulative);
        Assert.Equal(expectedTotalHealthcare, deserialized.TotalHealthcare);
        Assert.Equal(expectedTransit, deserialized.Transit);
        Assert.Equal(expectedUnknown, deserialized.Unknown);
        Assert.Equal(expectedVision, deserialized.Vision);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::AdditionalAmounts
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::AdditionalAmounts
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };

        DeclinedTransactions::AdditionalAmounts copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ClinicTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Clinic { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Clinic { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Clinic>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::Clinic { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Clinic>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::Clinic { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::Clinic { Amount = 0, Currency = "currency" };

        DeclinedTransactions::Clinic copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DentalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Dental { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Dental { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Dental>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::Dental { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Dental>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::Dental { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::Dental { Amount = 0, Currency = "currency" };

        DeclinedTransactions::Dental copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Original { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Original { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Original>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::Original { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Original>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::Original { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::Original { Amount = 0, Currency = "currency" };

        DeclinedTransactions::Original copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PrescriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Prescription { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Prescription { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Prescription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::Prescription { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Prescription>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::Prescription { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::Prescription { Amount = 0, Currency = "currency" };

        DeclinedTransactions::Prescription copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SurchargeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Surcharge { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Surcharge { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Surcharge>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::Surcharge { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Surcharge>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::Surcharge { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::Surcharge { Amount = 0, Currency = "currency" };

        DeclinedTransactions::Surcharge copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TotalCumulativeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::TotalCumulative { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::TotalCumulative { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::TotalCumulative>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::TotalCumulative { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::TotalCumulative>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::TotalCumulative { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::TotalCumulative { Amount = 0, Currency = "currency" };

        DeclinedTransactions::TotalCumulative copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TotalHealthcareTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::TotalHealthcare { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::TotalHealthcare { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::TotalHealthcare>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::TotalHealthcare { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::TotalHealthcare>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::TotalHealthcare { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::TotalHealthcare { Amount = 0, Currency = "currency" };

        DeclinedTransactions::TotalHealthcare copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TransitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Transit { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Transit { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Transit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::Transit { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Transit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::Transit { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::Transit { Amount = 0, Currency = "currency" };

        DeclinedTransactions::Transit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnknownTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Unknown { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Unknown { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Unknown>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::Unknown { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Unknown>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::Unknown { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::Unknown { Amount = 0, Currency = "currency" };

        DeclinedTransactions::Unknown copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VisionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Vision { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Vision { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Vision>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::Vision { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Vision>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::Vision { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::Vision { Amount = 0, Currency = "currency" };

        DeclinedTransactions::Vision copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardDeclineCurrencyTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::CardDeclineCurrency.Usd)]
    public void Validation_Works(DeclinedTransactions::CardDeclineCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::CardDeclineCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CardDeclineCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::CardDeclineCurrency.Usd)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::CardDeclineCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::CardDeclineCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CardDeclineCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CardDeclineCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CardDeclineCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DirectionTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::Direction.Settlement)]
    [InlineData(DeclinedTransactions::Direction.Refund)]
    public void Validation_Works(DeclinedTransactions::Direction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::Direction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::Direction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::Direction.Settlement)]
    [InlineData(DeclinedTransactions::Direction.Refund)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::Direction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::Direction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::Direction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::Direction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::Direction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NetworkDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::NetworkDetails
        {
            Category = DeclinedTransactions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    DeclinedTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = DeclinedTransactions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = DeclinedTransactions::TerminalEntryCapability.Unknown,
            },
        };

        ApiEnum<string, DeclinedTransactions::NetworkDetailsCategory> expectedCategory =
            DeclinedTransactions::NetworkDetailsCategory.Visa;
        DeclinedTransactions::Pulse expectedPulse = new();
        DeclinedTransactions::Visa expectedVisa = new()
        {
            ElectronicCommerceIndicator =
                DeclinedTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = DeclinedTransactions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = DeclinedTransactions::TerminalEntryCapability.Unknown,
        };

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedPulse, model.Pulse);
        Assert.Equal(expectedVisa, model.Visa);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::NetworkDetails
        {
            Category = DeclinedTransactions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    DeclinedTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = DeclinedTransactions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = DeclinedTransactions::TerminalEntryCapability.Unknown,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::NetworkDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::NetworkDetails
        {
            Category = DeclinedTransactions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    DeclinedTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = DeclinedTransactions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = DeclinedTransactions::TerminalEntryCapability.Unknown,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::NetworkDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, DeclinedTransactions::NetworkDetailsCategory> expectedCategory =
            DeclinedTransactions::NetworkDetailsCategory.Visa;
        DeclinedTransactions::Pulse expectedPulse = new();
        DeclinedTransactions::Visa expectedVisa = new()
        {
            ElectronicCommerceIndicator =
                DeclinedTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = DeclinedTransactions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = DeclinedTransactions::TerminalEntryCapability.Unknown,
        };

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedPulse, deserialized.Pulse);
        Assert.Equal(expectedVisa, deserialized.Visa);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::NetworkDetails
        {
            Category = DeclinedTransactions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    DeclinedTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = DeclinedTransactions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = DeclinedTransactions::TerminalEntryCapability.Unknown,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::NetworkDetails
        {
            Category = DeclinedTransactions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    DeclinedTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = DeclinedTransactions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = DeclinedTransactions::TerminalEntryCapability.Unknown,
            },
        };

        DeclinedTransactions::NetworkDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NetworkDetailsCategoryTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::NetworkDetailsCategory.Visa)]
    [InlineData(DeclinedTransactions::NetworkDetailsCategory.Pulse)]
    public void Validation_Works(DeclinedTransactions::NetworkDetailsCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::NetworkDetailsCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::NetworkDetailsCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::NetworkDetailsCategory.Visa)]
    [InlineData(DeclinedTransactions::NetworkDetailsCategory.Pulse)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::NetworkDetailsCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::NetworkDetailsCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::NetworkDetailsCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::NetworkDetailsCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::NetworkDetailsCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PulseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Pulse { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Pulse { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Pulse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::Pulse { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Pulse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::Pulse { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::Pulse { };

        DeclinedTransactions::Pulse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VisaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Visa
        {
            ElectronicCommerceIndicator =
                DeclinedTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = DeclinedTransactions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = DeclinedTransactions::TerminalEntryCapability.Unknown,
        };

        ApiEnum<
            string,
            DeclinedTransactions::ElectronicCommerceIndicator
        > expectedElectronicCommerceIndicator =
            DeclinedTransactions::ElectronicCommerceIndicator.MailPhoneOrder;
        ApiEnum<
            string,
            DeclinedTransactions::PointOfServiceEntryMode
        > expectedPointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Unknown;
        ApiEnum<
            string,
            DeclinedTransactions::StandInProcessingReason
        > expectedStandInProcessingReason =
            DeclinedTransactions::StandInProcessingReason.IssuerError;
        ApiEnum<
            string,
            DeclinedTransactions::TerminalEntryCapability
        > expectedTerminalEntryCapability = DeclinedTransactions::TerminalEntryCapability.Unknown;

        Assert.Equal(expectedElectronicCommerceIndicator, model.ElectronicCommerceIndicator);
        Assert.Equal(expectedPointOfServiceEntryMode, model.PointOfServiceEntryMode);
        Assert.Equal(expectedStandInProcessingReason, model.StandInProcessingReason);
        Assert.Equal(expectedTerminalEntryCapability, model.TerminalEntryCapability);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Visa
        {
            ElectronicCommerceIndicator =
                DeclinedTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = DeclinedTransactions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = DeclinedTransactions::TerminalEntryCapability.Unknown,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Visa>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::Visa
        {
            ElectronicCommerceIndicator =
                DeclinedTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = DeclinedTransactions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = DeclinedTransactions::TerminalEntryCapability.Unknown,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Visa>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            DeclinedTransactions::ElectronicCommerceIndicator
        > expectedElectronicCommerceIndicator =
            DeclinedTransactions::ElectronicCommerceIndicator.MailPhoneOrder;
        ApiEnum<
            string,
            DeclinedTransactions::PointOfServiceEntryMode
        > expectedPointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Unknown;
        ApiEnum<
            string,
            DeclinedTransactions::StandInProcessingReason
        > expectedStandInProcessingReason =
            DeclinedTransactions::StandInProcessingReason.IssuerError;
        ApiEnum<
            string,
            DeclinedTransactions::TerminalEntryCapability
        > expectedTerminalEntryCapability = DeclinedTransactions::TerminalEntryCapability.Unknown;

        Assert.Equal(expectedElectronicCommerceIndicator, deserialized.ElectronicCommerceIndicator);
        Assert.Equal(expectedPointOfServiceEntryMode, deserialized.PointOfServiceEntryMode);
        Assert.Equal(expectedStandInProcessingReason, deserialized.StandInProcessingReason);
        Assert.Equal(expectedTerminalEntryCapability, deserialized.TerminalEntryCapability);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::Visa
        {
            ElectronicCommerceIndicator =
                DeclinedTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = DeclinedTransactions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = DeclinedTransactions::TerminalEntryCapability.Unknown,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::Visa
        {
            ElectronicCommerceIndicator =
                DeclinedTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = DeclinedTransactions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = DeclinedTransactions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = DeclinedTransactions::TerminalEntryCapability.Unknown,
        };

        DeclinedTransactions::Visa copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ElectronicCommerceIndicatorTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::ElectronicCommerceIndicator.MailPhoneOrder)]
    [InlineData(DeclinedTransactions::ElectronicCommerceIndicator.Recurring)]
    [InlineData(DeclinedTransactions::ElectronicCommerceIndicator.Installment)]
    [InlineData(DeclinedTransactions::ElectronicCommerceIndicator.UnknownMailPhoneOrder)]
    [InlineData(DeclinedTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce)]
    [InlineData(
        DeclinedTransactions::ElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant
    )]
    [InlineData(
        DeclinedTransactions::ElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction
    )]
    [InlineData(DeclinedTransactions::ElectronicCommerceIndicator.NonSecureTransaction)]
    public void Validation_Works(DeclinedTransactions::ElectronicCommerceIndicator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::ElectronicCommerceIndicator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::ElectronicCommerceIndicator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::ElectronicCommerceIndicator.MailPhoneOrder)]
    [InlineData(DeclinedTransactions::ElectronicCommerceIndicator.Recurring)]
    [InlineData(DeclinedTransactions::ElectronicCommerceIndicator.Installment)]
    [InlineData(DeclinedTransactions::ElectronicCommerceIndicator.UnknownMailPhoneOrder)]
    [InlineData(DeclinedTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce)]
    [InlineData(
        DeclinedTransactions::ElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant
    )]
    [InlineData(
        DeclinedTransactions::ElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction
    )]
    [InlineData(DeclinedTransactions::ElectronicCommerceIndicator.NonSecureTransaction)]
    public void SerializationRoundtrip_Works(
        DeclinedTransactions::ElectronicCommerceIndicator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::ElectronicCommerceIndicator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::ElectronicCommerceIndicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::ElectronicCommerceIndicator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::ElectronicCommerceIndicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PointOfServiceEntryModeTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.Unknown)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.Manual)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.MagneticStripeNoCvv)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.OpticalCode)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.IntegratedCircuitCard)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.Contactless)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.CredentialOnFile)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.MagneticStripe)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.ContactlessMagneticStripe)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.IntegratedCircuitCardNoCvv)]
    public void Validation_Works(DeclinedTransactions::PointOfServiceEntryMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::PointOfServiceEntryMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::PointOfServiceEntryMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.Unknown)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.Manual)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.MagneticStripeNoCvv)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.OpticalCode)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.IntegratedCircuitCard)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.Contactless)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.CredentialOnFile)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.MagneticStripe)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.ContactlessMagneticStripe)]
    [InlineData(DeclinedTransactions::PointOfServiceEntryMode.IntegratedCircuitCardNoCvv)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::PointOfServiceEntryMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::PointOfServiceEntryMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::PointOfServiceEntryMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::PointOfServiceEntryMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::PointOfServiceEntryMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StandInProcessingReasonTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::StandInProcessingReason.IssuerError)]
    [InlineData(DeclinedTransactions::StandInProcessingReason.InvalidPhysicalCard)]
    [InlineData(DeclinedTransactions::StandInProcessingReason.InvalidCryptogram)]
    [InlineData(
        DeclinedTransactions::StandInProcessingReason.InvalidCardholderAuthenticationVerificationValue
    )]
    [InlineData(DeclinedTransactions::StandInProcessingReason.InternalVisaError)]
    [InlineData(
        DeclinedTransactions::StandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired
    )]
    [InlineData(DeclinedTransactions::StandInProcessingReason.PaymentFraudDisruptionAcquirerBlock)]
    [InlineData(DeclinedTransactions::StandInProcessingReason.Other)]
    public void Validation_Works(DeclinedTransactions::StandInProcessingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::StandInProcessingReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::StandInProcessingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::StandInProcessingReason.IssuerError)]
    [InlineData(DeclinedTransactions::StandInProcessingReason.InvalidPhysicalCard)]
    [InlineData(DeclinedTransactions::StandInProcessingReason.InvalidCryptogram)]
    [InlineData(
        DeclinedTransactions::StandInProcessingReason.InvalidCardholderAuthenticationVerificationValue
    )]
    [InlineData(DeclinedTransactions::StandInProcessingReason.InternalVisaError)]
    [InlineData(
        DeclinedTransactions::StandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired
    )]
    [InlineData(DeclinedTransactions::StandInProcessingReason.PaymentFraudDisruptionAcquirerBlock)]
    [InlineData(DeclinedTransactions::StandInProcessingReason.Other)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::StandInProcessingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::StandInProcessingReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::StandInProcessingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::StandInProcessingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::StandInProcessingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TerminalEntryCapabilityTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::TerminalEntryCapability.Unknown)]
    [InlineData(DeclinedTransactions::TerminalEntryCapability.TerminalNotUsed)]
    [InlineData(DeclinedTransactions::TerminalEntryCapability.MagneticStripe)]
    [InlineData(DeclinedTransactions::TerminalEntryCapability.Barcode)]
    [InlineData(DeclinedTransactions::TerminalEntryCapability.OpticalCharacterRecognition)]
    [InlineData(DeclinedTransactions::TerminalEntryCapability.ChipOrContactless)]
    [InlineData(DeclinedTransactions::TerminalEntryCapability.ContactlessOnly)]
    [InlineData(DeclinedTransactions::TerminalEntryCapability.NoCapability)]
    public void Validation_Works(DeclinedTransactions::TerminalEntryCapability rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::TerminalEntryCapability> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::TerminalEntryCapability>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::TerminalEntryCapability.Unknown)]
    [InlineData(DeclinedTransactions::TerminalEntryCapability.TerminalNotUsed)]
    [InlineData(DeclinedTransactions::TerminalEntryCapability.MagneticStripe)]
    [InlineData(DeclinedTransactions::TerminalEntryCapability.Barcode)]
    [InlineData(DeclinedTransactions::TerminalEntryCapability.OpticalCharacterRecognition)]
    [InlineData(DeclinedTransactions::TerminalEntryCapability.ChipOrContactless)]
    [InlineData(DeclinedTransactions::TerminalEntryCapability.ContactlessOnly)]
    [InlineData(DeclinedTransactions::TerminalEntryCapability.NoCapability)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::TerminalEntryCapability rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::TerminalEntryCapability> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::TerminalEntryCapability>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::TerminalEntryCapability>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::TerminalEntryCapability>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NetworkIdentifiersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::NetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        string expectedRetrievalReferenceNumber = "785867080153";
        string expectedTraceNumber = "487941";
        string expectedTransactionID = "627199945183184";

        Assert.Null(model.AuthorizationIdentificationResponse);
        Assert.Equal(expectedRetrievalReferenceNumber, model.RetrievalReferenceNumber);
        Assert.Equal(expectedTraceNumber, model.TraceNumber);
        Assert.Equal(expectedTransactionID, model.TransactionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::NetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::NetworkIdentifiers>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::NetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::NetworkIdentifiers>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRetrievalReferenceNumber = "785867080153";
        string expectedTraceNumber = "487941";
        string expectedTransactionID = "627199945183184";

        Assert.Null(deserialized.AuthorizationIdentificationResponse);
        Assert.Equal(expectedRetrievalReferenceNumber, deserialized.RetrievalReferenceNumber);
        Assert.Equal(expectedTraceNumber, deserialized.TraceNumber);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::NetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::NetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        DeclinedTransactions::NetworkIdentifiers copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProcessingCategoryTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::ProcessingCategory.AccountFunding)]
    [InlineData(DeclinedTransactions::ProcessingCategory.AutomaticFuelDispenser)]
    [InlineData(DeclinedTransactions::ProcessingCategory.BillPayment)]
    [InlineData(DeclinedTransactions::ProcessingCategory.OriginalCredit)]
    [InlineData(DeclinedTransactions::ProcessingCategory.Purchase)]
    [InlineData(DeclinedTransactions::ProcessingCategory.QuasiCash)]
    [InlineData(DeclinedTransactions::ProcessingCategory.Refund)]
    [InlineData(DeclinedTransactions::ProcessingCategory.CashDisbursement)]
    [InlineData(DeclinedTransactions::ProcessingCategory.BalanceInquiry)]
    [InlineData(DeclinedTransactions::ProcessingCategory.Unknown)]
    public void Validation_Works(DeclinedTransactions::ProcessingCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::ProcessingCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::ProcessingCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::ProcessingCategory.AccountFunding)]
    [InlineData(DeclinedTransactions::ProcessingCategory.AutomaticFuelDispenser)]
    [InlineData(DeclinedTransactions::ProcessingCategory.BillPayment)]
    [InlineData(DeclinedTransactions::ProcessingCategory.OriginalCredit)]
    [InlineData(DeclinedTransactions::ProcessingCategory.Purchase)]
    [InlineData(DeclinedTransactions::ProcessingCategory.QuasiCash)]
    [InlineData(DeclinedTransactions::ProcessingCategory.Refund)]
    [InlineData(DeclinedTransactions::ProcessingCategory.CashDisbursement)]
    [InlineData(DeclinedTransactions::ProcessingCategory.BalanceInquiry)]
    [InlineData(DeclinedTransactions::ProcessingCategory.Unknown)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::ProcessingCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::ProcessingCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::ProcessingCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::ProcessingCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::ProcessingCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimeDecisionReasonTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::RealTimeDecisionReason.InsufficientFunds)]
    [InlineData(DeclinedTransactions::RealTimeDecisionReason.TransactionNeverAllowed)]
    [InlineData(DeclinedTransactions::RealTimeDecisionReason.ExceedsApprovalLimit)]
    [InlineData(DeclinedTransactions::RealTimeDecisionReason.CardTemporarilyDisabled)]
    [InlineData(DeclinedTransactions::RealTimeDecisionReason.SuspectedFraud)]
    [InlineData(DeclinedTransactions::RealTimeDecisionReason.Other)]
    public void Validation_Works(DeclinedTransactions::RealTimeDecisionReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::RealTimeDecisionReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::RealTimeDecisionReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::RealTimeDecisionReason.InsufficientFunds)]
    [InlineData(DeclinedTransactions::RealTimeDecisionReason.TransactionNeverAllowed)]
    [InlineData(DeclinedTransactions::RealTimeDecisionReason.ExceedsApprovalLimit)]
    [InlineData(DeclinedTransactions::RealTimeDecisionReason.CardTemporarilyDisabled)]
    [InlineData(DeclinedTransactions::RealTimeDecisionReason.SuspectedFraud)]
    [InlineData(DeclinedTransactions::RealTimeDecisionReason.Other)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::RealTimeDecisionReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::RealTimeDecisionReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::RealTimeDecisionReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::RealTimeDecisionReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::RealTimeDecisionReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardDeclineReasonTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::CardDeclineReason.AccountClosed)]
    [InlineData(DeclinedTransactions::CardDeclineReason.CardNotActive)]
    [InlineData(DeclinedTransactions::CardDeclineReason.CardCanceled)]
    [InlineData(DeclinedTransactions::CardDeclineReason.PhysicalCardNotActive)]
    [InlineData(DeclinedTransactions::CardDeclineReason.EntityNotActive)]
    [InlineData(DeclinedTransactions::CardDeclineReason.GroupLocked)]
    [InlineData(DeclinedTransactions::CardDeclineReason.InsufficientFunds)]
    [InlineData(DeclinedTransactions::CardDeclineReason.Cvv2Mismatch)]
    [InlineData(DeclinedTransactions::CardDeclineReason.PinMismatch)]
    [InlineData(DeclinedTransactions::CardDeclineReason.CardExpirationMismatch)]
    [InlineData(DeclinedTransactions::CardDeclineReason.TransactionNotAllowed)]
    [InlineData(DeclinedTransactions::CardDeclineReason.BreachesLimit)]
    [InlineData(DeclinedTransactions::CardDeclineReason.WebhookDeclined)]
    [InlineData(DeclinedTransactions::CardDeclineReason.WebhookTimedOut)]
    [InlineData(DeclinedTransactions::CardDeclineReason.DeclinedByStandInProcessing)]
    [InlineData(DeclinedTransactions::CardDeclineReason.InvalidPhysicalCard)]
    [InlineData(DeclinedTransactions::CardDeclineReason.MissingOriginalAuthorization)]
    [InlineData(DeclinedTransactions::CardDeclineReason.InvalidCryptogram)]
    [InlineData(DeclinedTransactions::CardDeclineReason.Failed3dsAuthentication)]
    [InlineData(DeclinedTransactions::CardDeclineReason.SuspectedCardTesting)]
    [InlineData(DeclinedTransactions::CardDeclineReason.SuspectedFraud)]
    public void Validation_Works(DeclinedTransactions::CardDeclineReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::CardDeclineReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CardDeclineReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::CardDeclineReason.AccountClosed)]
    [InlineData(DeclinedTransactions::CardDeclineReason.CardNotActive)]
    [InlineData(DeclinedTransactions::CardDeclineReason.CardCanceled)]
    [InlineData(DeclinedTransactions::CardDeclineReason.PhysicalCardNotActive)]
    [InlineData(DeclinedTransactions::CardDeclineReason.EntityNotActive)]
    [InlineData(DeclinedTransactions::CardDeclineReason.GroupLocked)]
    [InlineData(DeclinedTransactions::CardDeclineReason.InsufficientFunds)]
    [InlineData(DeclinedTransactions::CardDeclineReason.Cvv2Mismatch)]
    [InlineData(DeclinedTransactions::CardDeclineReason.PinMismatch)]
    [InlineData(DeclinedTransactions::CardDeclineReason.CardExpirationMismatch)]
    [InlineData(DeclinedTransactions::CardDeclineReason.TransactionNotAllowed)]
    [InlineData(DeclinedTransactions::CardDeclineReason.BreachesLimit)]
    [InlineData(DeclinedTransactions::CardDeclineReason.WebhookDeclined)]
    [InlineData(DeclinedTransactions::CardDeclineReason.WebhookTimedOut)]
    [InlineData(DeclinedTransactions::CardDeclineReason.DeclinedByStandInProcessing)]
    [InlineData(DeclinedTransactions::CardDeclineReason.InvalidPhysicalCard)]
    [InlineData(DeclinedTransactions::CardDeclineReason.MissingOriginalAuthorization)]
    [InlineData(DeclinedTransactions::CardDeclineReason.InvalidCryptogram)]
    [InlineData(DeclinedTransactions::CardDeclineReason.Failed3dsAuthentication)]
    [InlineData(DeclinedTransactions::CardDeclineReason.SuspectedCardTesting)]
    [InlineData(DeclinedTransactions::CardDeclineReason.SuspectedFraud)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::CardDeclineReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::CardDeclineReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CardDeclineReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CardDeclineReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CardDeclineReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SchemeFeeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::SchemeFee
        {
            Amount = "0.137465",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
            FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
            FixedComponent = null,
            VariableRate = "0.0002",
        };

        string expectedAmount = "0.137465";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, DeclinedTransactions::SchemeFeeCurrency> expectedCurrency =
            DeclinedTransactions::SchemeFeeCurrency.Usd;
        ApiEnum<string, DeclinedTransactions::FeeType> expectedFeeType =
            DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee;
        string expectedVariableRate = "0.0002";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedFeeType, model.FeeType);
        Assert.Null(model.FixedComponent);
        Assert.Equal(expectedVariableRate, model.VariableRate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::SchemeFee
        {
            Amount = "0.137465",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
            FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
            FixedComponent = null,
            VariableRate = "0.0002",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::SchemeFee>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::SchemeFee
        {
            Amount = "0.137465",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
            FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
            FixedComponent = null,
            VariableRate = "0.0002",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::SchemeFee>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmount = "0.137465";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, DeclinedTransactions::SchemeFeeCurrency> expectedCurrency =
            DeclinedTransactions::SchemeFeeCurrency.Usd;
        ApiEnum<string, DeclinedTransactions::FeeType> expectedFeeType =
            DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee;
        string expectedVariableRate = "0.0002";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedFeeType, deserialized.FeeType);
        Assert.Null(deserialized.FixedComponent);
        Assert.Equal(expectedVariableRate, deserialized.VariableRate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::SchemeFee
        {
            Amount = "0.137465",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
            FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
            FixedComponent = null,
            VariableRate = "0.0002",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::SchemeFee
        {
            Amount = "0.137465",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = DeclinedTransactions::SchemeFeeCurrency.Usd,
            FeeType = DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee,
            FixedComponent = null,
            VariableRate = "0.0002",
        };

        DeclinedTransactions::SchemeFee copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SchemeFeeCurrencyTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::SchemeFeeCurrency.Usd)]
    public void Validation_Works(DeclinedTransactions::SchemeFeeCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::SchemeFeeCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::SchemeFeeCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::SchemeFeeCurrency.Usd)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::SchemeFeeCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::SchemeFeeCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::SchemeFeeCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::SchemeFeeCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::SchemeFeeCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeeTypeTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::FeeType.VisaInternationalServiceAssessmentSingleCurrency)]
    [InlineData(DeclinedTransactions::FeeType.VisaInternationalServiceAssessmentCrossCurrency)]
    [InlineData(DeclinedTransactions::FeeType.VisaAuthorizationDomesticPointOfSale)]
    [InlineData(DeclinedTransactions::FeeType.VisaAuthorizationInternationalPointOfSale)]
    [InlineData(DeclinedTransactions::FeeType.VisaAuthorizationCanadaPointOfSale)]
    [InlineData(DeclinedTransactions::FeeType.VisaAuthorizationReversalPointOfSale)]
    [InlineData(DeclinedTransactions::FeeType.VisaAuthorizationReversalInternationalPointOfSale)]
    [InlineData(DeclinedTransactions::FeeType.VisaAuthorizationAddressVerificationService)]
    [InlineData(DeclinedTransactions::FeeType.VisaAdvancedAuthorization)]
    [InlineData(DeclinedTransactions::FeeType.VisaMessageTransmission)]
    [InlineData(DeclinedTransactions::FeeType.VisaAccountVerificationDomestic)]
    [InlineData(DeclinedTransactions::FeeType.VisaAccountVerificationInternational)]
    [InlineData(DeclinedTransactions::FeeType.VisaAccountVerificationCanada)]
    [InlineData(DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee)]
    [InlineData(DeclinedTransactions::FeeType.VisaConsumerDebitAcceptanceFee)]
    [InlineData(DeclinedTransactions::FeeType.VisaBusinessDebitAcceptanceFee)]
    [InlineData(DeclinedTransactions::FeeType.VisaPurchasingAcceptanceFee)]
    [InlineData(DeclinedTransactions::FeeType.VisaPurchaseDomestic)]
    [InlineData(DeclinedTransactions::FeeType.VisaPurchaseInternational)]
    [InlineData(DeclinedTransactions::FeeType.VisaCreditPurchaseToken)]
    [InlineData(DeclinedTransactions::FeeType.VisaDebitPurchaseToken)]
    [InlineData(DeclinedTransactions::FeeType.VisaClearingTransmission)]
    [InlineData(DeclinedTransactions::FeeType.VisaDirectAuthorization)]
    [InlineData(DeclinedTransactions::FeeType.VisaDirectTransactionDomestic)]
    [InlineData(DeclinedTransactions::FeeType.VisaServiceCommercialCredit)]
    [InlineData(DeclinedTransactions::FeeType.VisaAdvertisingServiceCommercialCredit)]
    [InlineData(DeclinedTransactions::FeeType.VisaCommunityGrowthAccelerationProgram)]
    [InlineData(DeclinedTransactions::FeeType.VisaProcessingGuaranteeCommercialCredit)]
    [InlineData(DeclinedTransactions::FeeType.PulseSwitchFee)]
    public void Validation_Works(DeclinedTransactions::FeeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::FeeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::FeeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::FeeType.VisaInternationalServiceAssessmentSingleCurrency)]
    [InlineData(DeclinedTransactions::FeeType.VisaInternationalServiceAssessmentCrossCurrency)]
    [InlineData(DeclinedTransactions::FeeType.VisaAuthorizationDomesticPointOfSale)]
    [InlineData(DeclinedTransactions::FeeType.VisaAuthorizationInternationalPointOfSale)]
    [InlineData(DeclinedTransactions::FeeType.VisaAuthorizationCanadaPointOfSale)]
    [InlineData(DeclinedTransactions::FeeType.VisaAuthorizationReversalPointOfSale)]
    [InlineData(DeclinedTransactions::FeeType.VisaAuthorizationReversalInternationalPointOfSale)]
    [InlineData(DeclinedTransactions::FeeType.VisaAuthorizationAddressVerificationService)]
    [InlineData(DeclinedTransactions::FeeType.VisaAdvancedAuthorization)]
    [InlineData(DeclinedTransactions::FeeType.VisaMessageTransmission)]
    [InlineData(DeclinedTransactions::FeeType.VisaAccountVerificationDomestic)]
    [InlineData(DeclinedTransactions::FeeType.VisaAccountVerificationInternational)]
    [InlineData(DeclinedTransactions::FeeType.VisaAccountVerificationCanada)]
    [InlineData(DeclinedTransactions::FeeType.VisaCorporateAcceptanceFee)]
    [InlineData(DeclinedTransactions::FeeType.VisaConsumerDebitAcceptanceFee)]
    [InlineData(DeclinedTransactions::FeeType.VisaBusinessDebitAcceptanceFee)]
    [InlineData(DeclinedTransactions::FeeType.VisaPurchasingAcceptanceFee)]
    [InlineData(DeclinedTransactions::FeeType.VisaPurchaseDomestic)]
    [InlineData(DeclinedTransactions::FeeType.VisaPurchaseInternational)]
    [InlineData(DeclinedTransactions::FeeType.VisaCreditPurchaseToken)]
    [InlineData(DeclinedTransactions::FeeType.VisaDebitPurchaseToken)]
    [InlineData(DeclinedTransactions::FeeType.VisaClearingTransmission)]
    [InlineData(DeclinedTransactions::FeeType.VisaDirectAuthorization)]
    [InlineData(DeclinedTransactions::FeeType.VisaDirectTransactionDomestic)]
    [InlineData(DeclinedTransactions::FeeType.VisaServiceCommercialCredit)]
    [InlineData(DeclinedTransactions::FeeType.VisaAdvertisingServiceCommercialCredit)]
    [InlineData(DeclinedTransactions::FeeType.VisaCommunityGrowthAccelerationProgram)]
    [InlineData(DeclinedTransactions::FeeType.VisaProcessingGuaranteeCommercialCredit)]
    [InlineData(DeclinedTransactions::FeeType.PulseSwitchFee)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::FeeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::FeeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::FeeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::FeeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::FeeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VerificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Verification
        {
            CardVerificationCode = new(DeclinedTransactions::Result.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = DeclinedTransactions::CardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        DeclinedTransactions::CardVerificationCode expectedCardVerificationCode = new(
            DeclinedTransactions::Result.NotChecked
        );
        DeclinedTransactions::CardholderAddress expectedCardholderAddress = new()
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = DeclinedTransactions::CardholderAddressResult.NotChecked,
        };
        DeclinedTransactions::CardholderName expectedCardholderName = new()
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        Assert.Equal(expectedCardVerificationCode, model.CardVerificationCode);
        Assert.Equal(expectedCardholderAddress, model.CardholderAddress);
        Assert.Equal(expectedCardholderName, model.CardholderName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Verification
        {
            CardVerificationCode = new(DeclinedTransactions::Result.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = DeclinedTransactions::CardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Verification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::Verification
        {
            CardVerificationCode = new(DeclinedTransactions::Result.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = DeclinedTransactions::CardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Verification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DeclinedTransactions::CardVerificationCode expectedCardVerificationCode = new(
            DeclinedTransactions::Result.NotChecked
        );
        DeclinedTransactions::CardholderAddress expectedCardholderAddress = new()
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = DeclinedTransactions::CardholderAddressResult.NotChecked,
        };
        DeclinedTransactions::CardholderName expectedCardholderName = new()
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        Assert.Equal(expectedCardVerificationCode, deserialized.CardVerificationCode);
        Assert.Equal(expectedCardholderAddress, deserialized.CardholderAddress);
        Assert.Equal(expectedCardholderName, deserialized.CardholderName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::Verification
        {
            CardVerificationCode = new(DeclinedTransactions::Result.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = DeclinedTransactions::CardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::Verification
        {
            CardVerificationCode = new(DeclinedTransactions::Result.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = DeclinedTransactions::CardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        DeclinedTransactions::Verification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardVerificationCodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::CardVerificationCode
        {
            Result = DeclinedTransactions::Result.NotChecked,
        };

        ApiEnum<string, DeclinedTransactions::Result> expectedResult =
            DeclinedTransactions::Result.NotChecked;

        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::CardVerificationCode
        {
            Result = DeclinedTransactions::Result.NotChecked,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::CardVerificationCode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::CardVerificationCode
        {
            Result = DeclinedTransactions::Result.NotChecked,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::CardVerificationCode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, DeclinedTransactions::Result> expectedResult =
            DeclinedTransactions::Result.NotChecked;

        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::CardVerificationCode
        {
            Result = DeclinedTransactions::Result.NotChecked,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::CardVerificationCode
        {
            Result = DeclinedTransactions::Result.NotChecked,
        };

        DeclinedTransactions::CardVerificationCode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::Result.NotChecked)]
    [InlineData(DeclinedTransactions::Result.Match)]
    [InlineData(DeclinedTransactions::Result.NoMatch)]
    public void Validation_Works(DeclinedTransactions::Result rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::Result> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::Result>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::Result.NotChecked)]
    [InlineData(DeclinedTransactions::Result.Match)]
    [InlineData(DeclinedTransactions::Result.NoMatch)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::Result rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::Result> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::Result>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclinedTransactions::Result>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::Result>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardholderAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = DeclinedTransactions::CardholderAddressResult.NotChecked,
        };

        string expectedActualLine1 = "actual_line1";
        string expectedActualPostalCode = "actual_postal_code";
        string expectedProvidedLine1 = "provided_line1";
        string expectedProvidedPostalCode = "provided_postal_code";
        ApiEnum<string, DeclinedTransactions::CardholderAddressResult> expectedResult =
            DeclinedTransactions::CardholderAddressResult.NotChecked;

        Assert.Equal(expectedActualLine1, model.ActualLine1);
        Assert.Equal(expectedActualPostalCode, model.ActualPostalCode);
        Assert.Equal(expectedProvidedLine1, model.ProvidedLine1);
        Assert.Equal(expectedProvidedPostalCode, model.ProvidedPostalCode);
        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = DeclinedTransactions::CardholderAddressResult.NotChecked,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::CardholderAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = DeclinedTransactions::CardholderAddressResult.NotChecked,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::CardholderAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedActualLine1 = "actual_line1";
        string expectedActualPostalCode = "actual_postal_code";
        string expectedProvidedLine1 = "provided_line1";
        string expectedProvidedPostalCode = "provided_postal_code";
        ApiEnum<string, DeclinedTransactions::CardholderAddressResult> expectedResult =
            DeclinedTransactions::CardholderAddressResult.NotChecked;

        Assert.Equal(expectedActualLine1, deserialized.ActualLine1);
        Assert.Equal(expectedActualPostalCode, deserialized.ActualPostalCode);
        Assert.Equal(expectedProvidedLine1, deserialized.ProvidedLine1);
        Assert.Equal(expectedProvidedPostalCode, deserialized.ProvidedPostalCode);
        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = DeclinedTransactions::CardholderAddressResult.NotChecked,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = DeclinedTransactions::CardholderAddressResult.NotChecked,
        };

        DeclinedTransactions::CardholderAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardholderAddressResultTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::CardholderAddressResult.NotChecked)]
    [InlineData(DeclinedTransactions::CardholderAddressResult.PostalCodeMatchAddressNoMatch)]
    [InlineData(DeclinedTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch)]
    [InlineData(DeclinedTransactions::CardholderAddressResult.Match)]
    [InlineData(DeclinedTransactions::CardholderAddressResult.NoMatch)]
    [InlineData(DeclinedTransactions::CardholderAddressResult.PostalCodeMatchAddressNotChecked)]
    public void Validation_Works(DeclinedTransactions::CardholderAddressResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::CardholderAddressResult> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CardholderAddressResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::CardholderAddressResult.NotChecked)]
    [InlineData(DeclinedTransactions::CardholderAddressResult.PostalCodeMatchAddressNoMatch)]
    [InlineData(DeclinedTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch)]
    [InlineData(DeclinedTransactions::CardholderAddressResult.Match)]
    [InlineData(DeclinedTransactions::CardholderAddressResult.NoMatch)]
    [InlineData(DeclinedTransactions::CardholderAddressResult.PostalCodeMatchAddressNotChecked)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::CardholderAddressResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::CardholderAddressResult> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CardholderAddressResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CardholderAddressResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CardholderAddressResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardholderNameTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::CardholderName
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        string expectedProvidedFirstName = "provided_first_name";
        string expectedProvidedLastName = "provided_last_name";
        string expectedProvidedMiddleName = "provided_middle_name";

        Assert.Equal(expectedProvidedFirstName, model.ProvidedFirstName);
        Assert.Equal(expectedProvidedLastName, model.ProvidedLastName);
        Assert.Equal(expectedProvidedMiddleName, model.ProvidedMiddleName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::CardholderName
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::CardholderName>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::CardholderName
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::CardholderName>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedProvidedFirstName = "provided_first_name";
        string expectedProvidedLastName = "provided_last_name";
        string expectedProvidedMiddleName = "provided_middle_name";

        Assert.Equal(expectedProvidedFirstName, deserialized.ProvidedFirstName);
        Assert.Equal(expectedProvidedLastName, deserialized.ProvidedLastName);
        Assert.Equal(expectedProvidedMiddleName, deserialized.ProvidedMiddleName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::CardholderName
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::CardholderName
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        DeclinedTransactions::CardholderName copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckDeclineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::CheckDecline
        {
            Amount = -1000,
            AuxiliaryOnUs = "99999",
            BackImageFileID = null,
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
            FrontImageFileID = null,
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
            Reason = DeclinedTransactions::CheckDeclineReason.InsufficientFunds,
        };

        long expectedAmount = -1000;
        string expectedAuxiliaryOnUs = "99999";
        string expectedCheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5";
        string expectedInboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra";
        ApiEnum<string, DeclinedTransactions::CheckDeclineReason> expectedReason =
            DeclinedTransactions::CheckDeclineReason.InsufficientFunds;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedAuxiliaryOnUs, model.AuxiliaryOnUs);
        Assert.Null(model.BackImageFileID);
        Assert.Equal(expectedCheckTransferID, model.CheckTransferID);
        Assert.Null(model.FrontImageFileID);
        Assert.Equal(expectedInboundCheckDepositID, model.InboundCheckDepositID);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::CheckDecline
        {
            Amount = -1000,
            AuxiliaryOnUs = "99999",
            BackImageFileID = null,
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
            FrontImageFileID = null,
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
            Reason = DeclinedTransactions::CheckDeclineReason.InsufficientFunds,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::CheckDecline>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::CheckDecline
        {
            Amount = -1000,
            AuxiliaryOnUs = "99999",
            BackImageFileID = null,
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
            FrontImageFileID = null,
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
            Reason = DeclinedTransactions::CheckDeclineReason.InsufficientFunds,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::CheckDecline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = -1000;
        string expectedAuxiliaryOnUs = "99999";
        string expectedCheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5";
        string expectedInboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra";
        ApiEnum<string, DeclinedTransactions::CheckDeclineReason> expectedReason =
            DeclinedTransactions::CheckDeclineReason.InsufficientFunds;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedAuxiliaryOnUs, deserialized.AuxiliaryOnUs);
        Assert.Null(deserialized.BackImageFileID);
        Assert.Equal(expectedCheckTransferID, deserialized.CheckTransferID);
        Assert.Null(deserialized.FrontImageFileID);
        Assert.Equal(expectedInboundCheckDepositID, deserialized.InboundCheckDepositID);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::CheckDecline
        {
            Amount = -1000,
            AuxiliaryOnUs = "99999",
            BackImageFileID = null,
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
            FrontImageFileID = null,
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
            Reason = DeclinedTransactions::CheckDeclineReason.InsufficientFunds,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::CheckDecline
        {
            Amount = -1000,
            AuxiliaryOnUs = "99999",
            BackImageFileID = null,
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
            FrontImageFileID = null,
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
            Reason = DeclinedTransactions::CheckDeclineReason.InsufficientFunds,
        };

        DeclinedTransactions::CheckDecline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckDeclineReasonTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::CheckDeclineReason.AchRouteDisabled)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.AchRouteCanceled)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.AlteredOrFictitious)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.BreachesLimit)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.EndorsementIrregular)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.EntityNotActive)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.GroupLocked)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.InsufficientFunds)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.StopPaymentRequested)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.DuplicatePresentment)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.NotAuthorized)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.AmountMismatch)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.NotOurItem)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.NoAccountNumberFound)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.ReferToImage)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.UnableToProcess)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.UnusableImage)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.UserInitiated)]
    public void Validation_Works(DeclinedTransactions::CheckDeclineReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::CheckDeclineReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CheckDeclineReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::CheckDeclineReason.AchRouteDisabled)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.AchRouteCanceled)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.AlteredOrFictitious)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.BreachesLimit)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.EndorsementIrregular)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.EntityNotActive)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.GroupLocked)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.InsufficientFunds)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.StopPaymentRequested)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.DuplicatePresentment)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.NotAuthorized)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.AmountMismatch)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.NotOurItem)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.NoAccountNumberFound)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.ReferToImage)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.UnableToProcess)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.UnusableImage)]
    [InlineData(DeclinedTransactions::CheckDeclineReason.UserInitiated)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::CheckDeclineReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::CheckDeclineReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CheckDeclineReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CheckDeclineReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CheckDeclineReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CheckDepositRejectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::CheckDepositRejection
        {
            Amount = 1750,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = DeclinedTransactions::CheckDepositRejectionCurrency.Usd,
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
            Reason = DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        long expectedAmount = 1750;
        string expectedCheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1";
        ApiEnum<string, DeclinedTransactions::CheckDepositRejectionCurrency> expectedCurrency =
            DeclinedTransactions::CheckDepositRejectionCurrency.Usd;
        string expectedDeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8";
        ApiEnum<string, DeclinedTransactions::CheckDepositRejectionReason> expectedReason =
            DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage;
        DateTimeOffset expectedRejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCheckDepositID, model.CheckDepositID);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDeclinedTransactionID, model.DeclinedTransactionID);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedRejectedAt, model.RejectedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::CheckDepositRejection
        {
            Amount = 1750,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = DeclinedTransactions::CheckDepositRejectionCurrency.Usd,
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
            Reason = DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::CheckDepositRejection>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::CheckDepositRejection
        {
            Amount = 1750,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = DeclinedTransactions::CheckDepositRejectionCurrency.Usd,
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
            Reason = DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::CheckDepositRejection>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 1750;
        string expectedCheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1";
        ApiEnum<string, DeclinedTransactions::CheckDepositRejectionCurrency> expectedCurrency =
            DeclinedTransactions::CheckDepositRejectionCurrency.Usd;
        string expectedDeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8";
        ApiEnum<string, DeclinedTransactions::CheckDepositRejectionReason> expectedReason =
            DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage;
        DateTimeOffset expectedRejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCheckDepositID, deserialized.CheckDepositID);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDeclinedTransactionID, deserialized.DeclinedTransactionID);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedRejectedAt, deserialized.RejectedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::CheckDepositRejection
        {
            Amount = 1750,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = DeclinedTransactions::CheckDepositRejectionCurrency.Usd,
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
            Reason = DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::CheckDepositRejection
        {
            Amount = 1750,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = DeclinedTransactions::CheckDepositRejectionCurrency.Usd,
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
            Reason = DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        DeclinedTransactions::CheckDepositRejection copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckDepositRejectionCurrencyTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::CheckDepositRejectionCurrency.Usd)]
    public void Validation_Works(DeclinedTransactions::CheckDepositRejectionCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::CheckDepositRejectionCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CheckDepositRejectionCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::CheckDepositRejectionCurrency.Usd)]
    public void SerializationRoundtrip_Works(
        DeclinedTransactions::CheckDepositRejectionCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::CheckDepositRejectionCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CheckDepositRejectionCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CheckDepositRejectionCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CheckDepositRejectionCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CheckDepositRejectionReasonTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.Duplicate)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.PoorImageQuality)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.IncorrectAmount)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.IncorrectRecipient)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.NotEligibleForMobileDeposit)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.MissingRequiredDataElements)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.SuspectedFraud)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.DepositWindowExpired)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.RequestedByUser)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.International)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.Unknown)]
    public void Validation_Works(DeclinedTransactions::CheckDepositRejectionReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::CheckDepositRejectionReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CheckDepositRejectionReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.IncompleteImage)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.Duplicate)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.PoorImageQuality)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.IncorrectAmount)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.IncorrectRecipient)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.NotEligibleForMobileDeposit)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.MissingRequiredDataElements)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.SuspectedFraud)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.DepositWindowExpired)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.RequestedByUser)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.International)]
    [InlineData(DeclinedTransactions::CheckDepositRejectionReason.Unknown)]
    public void SerializationRoundtrip_Works(
        DeclinedTransactions::CheckDepositRejectionReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::CheckDepositRejectionReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CheckDepositRejectionReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CheckDepositRejectionReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::CheckDepositRejectionReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InboundFednowTransferDeclineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::InboundFednowTransferDecline
        {
            Reason = DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled,
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        ApiEnum<string, DeclinedTransactions::InboundFednowTransferDeclineReason> expectedReason =
            DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled;
        string expectedTransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20";

        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedTransferID, model.TransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::InboundFednowTransferDecline
        {
            Reason = DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled,
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DeclinedTransactions::InboundFednowTransferDecline>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::InboundFednowTransferDecline
        {
            Reason = DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled,
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DeclinedTransactions::InboundFednowTransferDecline>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, DeclinedTransactions::InboundFednowTransferDeclineReason> expectedReason =
            DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled;
        string expectedTransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20";

        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedTransferID, deserialized.TransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::InboundFednowTransferDecline
        {
            Reason = DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled,
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::InboundFednowTransferDecline
        {
            Reason = DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled,
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        DeclinedTransactions::InboundFednowTransferDecline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InboundFednowTransferDeclineReasonTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberCanceled)]
    [InlineData(DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled)]
    [InlineData(DeclinedTransactions::InboundFednowTransferDeclineReason.AccountRestricted)]
    [InlineData(DeclinedTransactions::InboundFednowTransferDeclineReason.GroupLocked)]
    [InlineData(DeclinedTransactions::InboundFednowTransferDeclineReason.EntityNotActive)]
    [InlineData(DeclinedTransactions::InboundFednowTransferDeclineReason.FednowNotEnabled)]
    public void Validation_Works(DeclinedTransactions::InboundFednowTransferDeclineReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::InboundFednowTransferDeclineReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::InboundFednowTransferDeclineReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberCanceled)]
    [InlineData(DeclinedTransactions::InboundFednowTransferDeclineReason.AccountNumberDisabled)]
    [InlineData(DeclinedTransactions::InboundFednowTransferDeclineReason.AccountRestricted)]
    [InlineData(DeclinedTransactions::InboundFednowTransferDeclineReason.GroupLocked)]
    [InlineData(DeclinedTransactions::InboundFednowTransferDeclineReason.EntityNotActive)]
    [InlineData(DeclinedTransactions::InboundFednowTransferDeclineReason.FednowNotEnabled)]
    public void SerializationRoundtrip_Works(
        DeclinedTransactions::InboundFednowTransferDeclineReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::InboundFednowTransferDeclineReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::InboundFednowTransferDeclineReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::InboundFednowTransferDeclineReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::InboundFednowTransferDeclineReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InboundRealTimePaymentsTransferDeclineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::InboundRealTimePaymentsTransferDecline
        {
            Amount = 100,
            CreditorName = "Ian Crease",
            Currency = DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
            DebtorAccountNumber = "987654321",
            DebtorName = "National Phonograph Company",
            DebtorRoutingNumber = "101050001",
            Reason =
                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled,
            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
            TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        long expectedAmount = 100;
        string expectedCreditorName = "Ian Crease";
        ApiEnum<
            string,
            DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency
        > expectedCurrency =
            DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd;
        string expectedDebtorAccountNumber = "987654321";
        string expectedDebtorName = "National Phonograph Company";
        string expectedDebtorRoutingNumber = "101050001";
        ApiEnum<
            string,
            DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason
        > expectedReason =
            DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled;
        string expectedTransactionIdentification = "20220501234567891T1BSLZO01745013025";
        string expectedTransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr";
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreditorName, model.CreditorName);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDebtorAccountNumber, model.DebtorAccountNumber);
        Assert.Equal(expectedDebtorName, model.DebtorName);
        Assert.Equal(expectedDebtorRoutingNumber, model.DebtorRoutingNumber);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedTransactionIdentification, model.TransactionIdentification);
        Assert.Equal(expectedTransferID, model.TransferID);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            model.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::InboundRealTimePaymentsTransferDecline
        {
            Amount = 100,
            CreditorName = "Ian Crease",
            Currency = DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
            DebtorAccountNumber = "987654321",
            DebtorName = "National Phonograph Company",
            DebtorRoutingNumber = "101050001",
            Reason =
                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled,
            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
            TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DeclinedTransactions::InboundRealTimePaymentsTransferDecline>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::InboundRealTimePaymentsTransferDecline
        {
            Amount = 100,
            CreditorName = "Ian Crease",
            Currency = DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
            DebtorAccountNumber = "987654321",
            DebtorName = "National Phonograph Company",
            DebtorRoutingNumber = "101050001",
            Reason =
                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled,
            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
            TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DeclinedTransactions::InboundRealTimePaymentsTransferDecline>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAmount = 100;
        string expectedCreditorName = "Ian Crease";
        ApiEnum<
            string,
            DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency
        > expectedCurrency =
            DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd;
        string expectedDebtorAccountNumber = "987654321";
        string expectedDebtorName = "National Phonograph Company";
        string expectedDebtorRoutingNumber = "101050001";
        ApiEnum<
            string,
            DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason
        > expectedReason =
            DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled;
        string expectedTransactionIdentification = "20220501234567891T1BSLZO01745013025";
        string expectedTransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr";
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreditorName, deserialized.CreditorName);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDebtorAccountNumber, deserialized.DebtorAccountNumber);
        Assert.Equal(expectedDebtorName, deserialized.DebtorName);
        Assert.Equal(expectedDebtorRoutingNumber, deserialized.DebtorRoutingNumber);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedTransactionIdentification, deserialized.TransactionIdentification);
        Assert.Equal(expectedTransferID, deserialized.TransferID);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            deserialized.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::InboundRealTimePaymentsTransferDecline
        {
            Amount = 100,
            CreditorName = "Ian Crease",
            Currency = DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
            DebtorAccountNumber = "987654321",
            DebtorName = "National Phonograph Company",
            DebtorRoutingNumber = "101050001",
            Reason =
                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled,
            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
            TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::InboundRealTimePaymentsTransferDecline
        {
            Amount = 100,
            CreditorName = "Ian Crease",
            Currency = DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd,
            DebtorAccountNumber = "987654321",
            DebtorName = "National Phonograph Company",
            DebtorRoutingNumber = "101050001",
            Reason =
                DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled,
            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
            TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        DeclinedTransactions::InboundRealTimePaymentsTransferDecline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InboundRealTimePaymentsTransferDeclineCurrencyTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd)]
    public void Validation_Works(
        DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency.Usd)]
    public void SerializationRoundtrip_Works(
        DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::InboundRealTimePaymentsTransferDeclineCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InboundRealTimePaymentsTransferDeclineReasonTest : TestBase
{
    [Theory]
    [InlineData(
        DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberCanceled
    )]
    [InlineData(
        DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled
    )]
    [InlineData(
        DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountRestricted
    )]
    [InlineData(DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.GroupLocked)]
    [InlineData(DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.EntityNotActive)]
    [InlineData(
        DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.RealTimePaymentsNotEnabled
    )]
    public void Validation_Works(
        DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberCanceled
    )]
    [InlineData(
        DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountNumberDisabled
    )]
    [InlineData(
        DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.AccountRestricted
    )]
    [InlineData(DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.GroupLocked)]
    [InlineData(DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.EntityNotActive)]
    [InlineData(
        DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason.RealTimePaymentsNotEnabled
    )]
    public void SerializationRoundtrip_Works(
        DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::InboundRealTimePaymentsTransferDeclineReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OtherTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Other { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::Other { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Other>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::Other { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::Other>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::Other { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::Other { };

        DeclinedTransactions::Other copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WireDeclineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeclinedTransactions::WireDecline
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
            Reason = DeclinedTransactions::WireDeclineReason.AccountNumberDisabled,
        };

        string expectedInboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0";
        ApiEnum<string, DeclinedTransactions::WireDeclineReason> expectedReason =
            DeclinedTransactions::WireDeclineReason.AccountNumberDisabled;

        Assert.Equal(expectedInboundWireTransferID, model.InboundWireTransferID);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeclinedTransactions::WireDecline
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
            Reason = DeclinedTransactions::WireDeclineReason.AccountNumberDisabled,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::WireDecline>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeclinedTransactions::WireDecline
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
            Reason = DeclinedTransactions::WireDeclineReason.AccountNumberDisabled,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeclinedTransactions::WireDecline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0";
        ApiEnum<string, DeclinedTransactions::WireDeclineReason> expectedReason =
            DeclinedTransactions::WireDeclineReason.AccountNumberDisabled;

        Assert.Equal(expectedInboundWireTransferID, deserialized.InboundWireTransferID);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeclinedTransactions::WireDecline
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
            Reason = DeclinedTransactions::WireDeclineReason.AccountNumberDisabled,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeclinedTransactions::WireDecline
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
            Reason = DeclinedTransactions::WireDeclineReason.AccountNumberDisabled,
        };

        DeclinedTransactions::WireDecline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WireDeclineReasonTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::WireDeclineReason.AccountNumberCanceled)]
    [InlineData(DeclinedTransactions::WireDeclineReason.AccountNumberDisabled)]
    [InlineData(DeclinedTransactions::WireDeclineReason.EntityNotActive)]
    [InlineData(DeclinedTransactions::WireDeclineReason.GroupLocked)]
    [InlineData(DeclinedTransactions::WireDeclineReason.NoAccountNumber)]
    [InlineData(DeclinedTransactions::WireDeclineReason.TransactionNotAllowed)]
    public void Validation_Works(DeclinedTransactions::WireDeclineReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::WireDeclineReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::WireDeclineReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::WireDeclineReason.AccountNumberCanceled)]
    [InlineData(DeclinedTransactions::WireDeclineReason.AccountNumberDisabled)]
    [InlineData(DeclinedTransactions::WireDeclineReason.EntityNotActive)]
    [InlineData(DeclinedTransactions::WireDeclineReason.GroupLocked)]
    [InlineData(DeclinedTransactions::WireDeclineReason.NoAccountNumber)]
    [InlineData(DeclinedTransactions::WireDeclineReason.TransactionNotAllowed)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::WireDeclineReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::WireDeclineReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::WireDeclineReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::WireDeclineReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::WireDeclineReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DeclinedTransactionTypeTest : TestBase
{
    [Theory]
    [InlineData(DeclinedTransactions::DeclinedTransactionType.DeclinedTransaction)]
    public void Validation_Works(DeclinedTransactions::DeclinedTransactionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::DeclinedTransactionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::DeclinedTransactionType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclinedTransactions::DeclinedTransactionType.DeclinedTransaction)]
    public void SerializationRoundtrip_Works(DeclinedTransactions::DeclinedTransactionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclinedTransactions::DeclinedTransactionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::DeclinedTransactionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::DeclinedTransactionType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeclinedTransactions::DeclinedTransactionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
