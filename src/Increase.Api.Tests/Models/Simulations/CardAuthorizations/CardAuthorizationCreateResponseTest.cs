using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using CardAuthorizations = Increase.Api.Models.Simulations.CardAuthorizations;
using DeclinedTransactions = Increase.Api.Models.DeclinedTransactions;
using PendingTransactions = Increase.Api.Models.PendingTransactions;

namespace Increase.Api.Tests.Models.Simulations.CardAuthorizations;

public class CardAuthorizationCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardAuthorizations::CardAuthorizationCreateResponse
        {
            DeclinedTransaction = new()
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
            PendingTransaction = new()
            {
                ID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                AccountID = "account_in71c4amph0vgo2qllky",
                Amount = 100,
                CompletedAt = null,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = PendingTransactions::Currency.Usd,
                Description = "INVOICE 2468",
                HeldAmount = 100,
                RouteID = "card_oubs0hwk5rn6knuecxg2",
                RouteType = PendingTransactions::RouteType.Card,
                Source = new()
                {
                    Category = PendingTransactions::SourceCategory.CardAuthorization,
                    AccountTransferInstruction = new()
                    {
                        Amount = 100,
                        Currency = PendingTransactions::AccountTransferInstructionCurrency.Usd,
                        TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                    },
                    AchTransferInstruction = new()
                    {
                        Amount = 100,
                        TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
                    },
                    BlockchainOfframpTransferInstruction = new()
                    {
                        SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
                        TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
                    },
                    BlockchainOnrampTransferInstruction = new()
                    {
                        Amount = 10000,
                        DestinationBlockchainAddress = "0x304a554a310C7e546dfe434669C62820b7D83490",
                        TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
                    },
                    CardAuthorization = new()
                    {
                        ID = "card_authorization_6iqxap6ivd0fo5eu3i8x",
                        Actioner = PendingTransactions::Actioner.Increase,
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
                        Amount = 100,
                        CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                        Currency = PendingTransactions::CardAuthorizationCurrency.Usd,
                        DigitalWalletTokenID = null,
                        Direction = PendingTransactions::Direction.Settlement,
                        ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        MerchantAcceptorID = "5665270011000168",
                        MerchantCategoryCode = "5734",
                        MerchantCity = "New York",
                        MerchantCountry = "US",
                        MerchantDescriptor = "AMAZON.COM",
                        MerchantPostalCode = "10045",
                        MerchantState = "NY",
                        NetworkDetails = new()
                        {
                            Category = PendingTransactions::NetworkDetailsCategory.Visa,
                            Pulse = new(),
                            Visa = new()
                            {
                                ElectronicCommerceIndicator =
                                    PendingTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                PointOfServiceEntryMode =
                                    PendingTransactions::PointOfServiceEntryMode.Manual,
                                StandInProcessingReason = null,
                                TerminalEntryCapability =
                                    PendingTransactions::TerminalEntryCapability.MagneticStripe,
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
                        PendingTransactionID = null,
                        PhysicalCardID = null,
                        PresentmentAmount = 100,
                        PresentmentCurrency = "USD",
                        ProcessingCategory = PendingTransactions::ProcessingCategory.Purchase,
                        RealTimeDecisionID = null,
                        TerminalID = "RCN5VNXS",
                        Type = PendingTransactions::Type.CardAuthorization,
                        Verification = new()
                        {
                            CardVerificationCode = new(PendingTransactions::Result.Match),
                            CardholderAddress = new()
                            {
                                ActualLine1 = "33 Liberty Street",
                                ActualPostalCode = "94131",
                                ProvidedLine1 = "33 Liberty Street",
                                ProvidedPostalCode = "94132",
                                Result =
                                    PendingTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                            },
                            CardholderName = new()
                            {
                                ProvidedFirstName = "provided_first_name",
                                ProvidedLastName = "provided_last_name",
                                ProvidedMiddleName = "provided_middle_name",
                            },
                        },
                    },
                    CardPushTransferInstruction = new()
                    {
                        Amount = 100,
                        TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                    },
                    CheckDepositInstruction = new()
                    {
                        Amount = 100,
                        BackImageFileID = "file_26khfk98mzfz90a11oqx",
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = PendingTransactions::CheckDepositInstructionCurrency.Usd,
                        FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    },
                    CheckTransferInstruction = new()
                    {
                        Amount = 100,
                        Currency = PendingTransactions::CheckTransferInstructionCurrency.Usd,
                        TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                    },
                    FednowTransferInstruction = new("fednow_transfer_4i0mptrdu1mueg1196bg"),
                    InboundFundsHold = new()
                    {
                        Amount = 100,
                        AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = PendingTransactions::InboundFundsHoldCurrency.Usd,
                        HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                        ReleasedAt = null,
                        Status = PendingTransactions::InboundFundsHoldStatus.Held,
                        Type = PendingTransactions::InboundFundsHoldType.InboundFundsHold,
                    },
                    InboundWireTransferReversal = new("inbound_wire_transfer_f228m6bmhtcxjco9pwp0"),
                    Other = new(),
                    RealTimePaymentsTransferInstruction = new()
                    {
                        Amount = 100,
                        TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                    },
                    SwiftTransferInstruction = new("swift_transfer_29h21xkng03788zwd3fh"),
                    UserInitiatedHold = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    WireTransferInstruction = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 100,
                        MessageToRecipient = "HELLO",
                        RoutingNumber = "101050001",
                        TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                    },
                },
                Status = PendingTransactions::PendingTransactionStatus.Pending,
                Type = PendingTransactions::PendingTransactionType.PendingTransaction,
            },
            Type = CardAuthorizations::Type.InboundCardAuthorizationSimulationResult,
        };

        DeclinedTransactions::DeclinedTransaction expectedDeclinedTransaction = new()
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
        };
        PendingTransactions::PendingTransaction expectedPendingTransaction = new()
        {
            ID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            CompletedAt = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = PendingTransactions::Currency.Usd,
            Description = "INVOICE 2468",
            HeldAmount = 100,
            RouteID = "card_oubs0hwk5rn6knuecxg2",
            RouteType = PendingTransactions::RouteType.Card,
            Source = new()
            {
                Category = PendingTransactions::SourceCategory.CardAuthorization,
                AccountTransferInstruction = new()
                {
                    Amount = 100,
                    Currency = PendingTransactions::AccountTransferInstructionCurrency.Usd,
                    TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                },
                AchTransferInstruction = new()
                {
                    Amount = 100,
                    TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
                },
                BlockchainOfframpTransferInstruction = new()
                {
                    SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
                    TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
                },
                BlockchainOnrampTransferInstruction = new()
                {
                    Amount = 10000,
                    DestinationBlockchainAddress = "0x304a554a310C7e546dfe434669C62820b7D83490",
                    TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
                },
                CardAuthorization = new()
                {
                    ID = "card_authorization_6iqxap6ivd0fo5eu3i8x",
                    Actioner = PendingTransactions::Actioner.Increase,
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
                    Amount = 100,
                    CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                    Currency = PendingTransactions::CardAuthorizationCurrency.Usd,
                    DigitalWalletTokenID = null,
                    Direction = PendingTransactions::Direction.Settlement,
                    ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    MerchantAcceptorID = "5665270011000168",
                    MerchantCategoryCode = "5734",
                    MerchantCity = "New York",
                    MerchantCountry = "US",
                    MerchantDescriptor = "AMAZON.COM",
                    MerchantPostalCode = "10045",
                    MerchantState = "NY",
                    NetworkDetails = new()
                    {
                        Category = PendingTransactions::NetworkDetailsCategory.Visa,
                        Pulse = new(),
                        Visa = new()
                        {
                            ElectronicCommerceIndicator =
                                PendingTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                            PointOfServiceEntryMode =
                                PendingTransactions::PointOfServiceEntryMode.Manual,
                            StandInProcessingReason = null,
                            TerminalEntryCapability =
                                PendingTransactions::TerminalEntryCapability.MagneticStripe,
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
                    PendingTransactionID = null,
                    PhysicalCardID = null,
                    PresentmentAmount = 100,
                    PresentmentCurrency = "USD",
                    ProcessingCategory = PendingTransactions::ProcessingCategory.Purchase,
                    RealTimeDecisionID = null,
                    TerminalID = "RCN5VNXS",
                    Type = PendingTransactions::Type.CardAuthorization,
                    Verification = new()
                    {
                        CardVerificationCode = new(PendingTransactions::Result.Match),
                        CardholderAddress = new()
                        {
                            ActualLine1 = "33 Liberty Street",
                            ActualPostalCode = "94131",
                            ProvidedLine1 = "33 Liberty Street",
                            ProvidedPostalCode = "94132",
                            Result =
                                PendingTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                        },
                        CardholderName = new()
                        {
                            ProvidedFirstName = "provided_first_name",
                            ProvidedLastName = "provided_last_name",
                            ProvidedMiddleName = "provided_middle_name",
                        },
                    },
                },
                CardPushTransferInstruction = new()
                {
                    Amount = 100,
                    TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                },
                CheckDepositInstruction = new()
                {
                    Amount = 100,
                    BackImageFileID = "file_26khfk98mzfz90a11oqx",
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    Currency = PendingTransactions::CheckDepositInstructionCurrency.Usd,
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                },
                CheckTransferInstruction = new()
                {
                    Amount = 100,
                    Currency = PendingTransactions::CheckTransferInstructionCurrency.Usd,
                    TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                },
                FednowTransferInstruction = new("fednow_transfer_4i0mptrdu1mueg1196bg"),
                InboundFundsHold = new()
                {
                    Amount = 100,
                    AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = PendingTransactions::InboundFundsHoldCurrency.Usd,
                    HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                    ReleasedAt = null,
                    Status = PendingTransactions::InboundFundsHoldStatus.Held,
                    Type = PendingTransactions::InboundFundsHoldType.InboundFundsHold,
                },
                InboundWireTransferReversal = new("inbound_wire_transfer_f228m6bmhtcxjco9pwp0"),
                Other = new(),
                RealTimePaymentsTransferInstruction = new()
                {
                    Amount = 100,
                    TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                },
                SwiftTransferInstruction = new("swift_transfer_29h21xkng03788zwd3fh"),
                UserInitiatedHold = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                WireTransferInstruction = new()
                {
                    AccountNumber = "987654321",
                    Amount = 100,
                    MessageToRecipient = "HELLO",
                    RoutingNumber = "101050001",
                    TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                },
            },
            Status = PendingTransactions::PendingTransactionStatus.Pending,
            Type = PendingTransactions::PendingTransactionType.PendingTransaction,
        };
        ApiEnum<string, CardAuthorizations::Type> expectedType =
            CardAuthorizations::Type.InboundCardAuthorizationSimulationResult;

        Assert.Equal(expectedDeclinedTransaction, model.DeclinedTransaction);
        Assert.Equal(expectedPendingTransaction, model.PendingTransaction);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardAuthorizations::CardAuthorizationCreateResponse
        {
            DeclinedTransaction = new()
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
            PendingTransaction = new()
            {
                ID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                AccountID = "account_in71c4amph0vgo2qllky",
                Amount = 100,
                CompletedAt = null,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = PendingTransactions::Currency.Usd,
                Description = "INVOICE 2468",
                HeldAmount = 100,
                RouteID = "card_oubs0hwk5rn6knuecxg2",
                RouteType = PendingTransactions::RouteType.Card,
                Source = new()
                {
                    Category = PendingTransactions::SourceCategory.CardAuthorization,
                    AccountTransferInstruction = new()
                    {
                        Amount = 100,
                        Currency = PendingTransactions::AccountTransferInstructionCurrency.Usd,
                        TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                    },
                    AchTransferInstruction = new()
                    {
                        Amount = 100,
                        TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
                    },
                    BlockchainOfframpTransferInstruction = new()
                    {
                        SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
                        TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
                    },
                    BlockchainOnrampTransferInstruction = new()
                    {
                        Amount = 10000,
                        DestinationBlockchainAddress = "0x304a554a310C7e546dfe434669C62820b7D83490",
                        TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
                    },
                    CardAuthorization = new()
                    {
                        ID = "card_authorization_6iqxap6ivd0fo5eu3i8x",
                        Actioner = PendingTransactions::Actioner.Increase,
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
                        Amount = 100,
                        CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                        Currency = PendingTransactions::CardAuthorizationCurrency.Usd,
                        DigitalWalletTokenID = null,
                        Direction = PendingTransactions::Direction.Settlement,
                        ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        MerchantAcceptorID = "5665270011000168",
                        MerchantCategoryCode = "5734",
                        MerchantCity = "New York",
                        MerchantCountry = "US",
                        MerchantDescriptor = "AMAZON.COM",
                        MerchantPostalCode = "10045",
                        MerchantState = "NY",
                        NetworkDetails = new()
                        {
                            Category = PendingTransactions::NetworkDetailsCategory.Visa,
                            Pulse = new(),
                            Visa = new()
                            {
                                ElectronicCommerceIndicator =
                                    PendingTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                PointOfServiceEntryMode =
                                    PendingTransactions::PointOfServiceEntryMode.Manual,
                                StandInProcessingReason = null,
                                TerminalEntryCapability =
                                    PendingTransactions::TerminalEntryCapability.MagneticStripe,
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
                        PendingTransactionID = null,
                        PhysicalCardID = null,
                        PresentmentAmount = 100,
                        PresentmentCurrency = "USD",
                        ProcessingCategory = PendingTransactions::ProcessingCategory.Purchase,
                        RealTimeDecisionID = null,
                        TerminalID = "RCN5VNXS",
                        Type = PendingTransactions::Type.CardAuthorization,
                        Verification = new()
                        {
                            CardVerificationCode = new(PendingTransactions::Result.Match),
                            CardholderAddress = new()
                            {
                                ActualLine1 = "33 Liberty Street",
                                ActualPostalCode = "94131",
                                ProvidedLine1 = "33 Liberty Street",
                                ProvidedPostalCode = "94132",
                                Result =
                                    PendingTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                            },
                            CardholderName = new()
                            {
                                ProvidedFirstName = "provided_first_name",
                                ProvidedLastName = "provided_last_name",
                                ProvidedMiddleName = "provided_middle_name",
                            },
                        },
                    },
                    CardPushTransferInstruction = new()
                    {
                        Amount = 100,
                        TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                    },
                    CheckDepositInstruction = new()
                    {
                        Amount = 100,
                        BackImageFileID = "file_26khfk98mzfz90a11oqx",
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = PendingTransactions::CheckDepositInstructionCurrency.Usd,
                        FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    },
                    CheckTransferInstruction = new()
                    {
                        Amount = 100,
                        Currency = PendingTransactions::CheckTransferInstructionCurrency.Usd,
                        TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                    },
                    FednowTransferInstruction = new("fednow_transfer_4i0mptrdu1mueg1196bg"),
                    InboundFundsHold = new()
                    {
                        Amount = 100,
                        AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = PendingTransactions::InboundFundsHoldCurrency.Usd,
                        HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                        ReleasedAt = null,
                        Status = PendingTransactions::InboundFundsHoldStatus.Held,
                        Type = PendingTransactions::InboundFundsHoldType.InboundFundsHold,
                    },
                    InboundWireTransferReversal = new("inbound_wire_transfer_f228m6bmhtcxjco9pwp0"),
                    Other = new(),
                    RealTimePaymentsTransferInstruction = new()
                    {
                        Amount = 100,
                        TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                    },
                    SwiftTransferInstruction = new("swift_transfer_29h21xkng03788zwd3fh"),
                    UserInitiatedHold = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    WireTransferInstruction = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 100,
                        MessageToRecipient = "HELLO",
                        RoutingNumber = "101050001",
                        TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                    },
                },
                Status = PendingTransactions::PendingTransactionStatus.Pending,
                Type = PendingTransactions::PendingTransactionType.PendingTransaction,
            },
            Type = CardAuthorizations::Type.InboundCardAuthorizationSimulationResult,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardAuthorizations::CardAuthorizationCreateResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardAuthorizations::CardAuthorizationCreateResponse
        {
            DeclinedTransaction = new()
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
            PendingTransaction = new()
            {
                ID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                AccountID = "account_in71c4amph0vgo2qllky",
                Amount = 100,
                CompletedAt = null,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = PendingTransactions::Currency.Usd,
                Description = "INVOICE 2468",
                HeldAmount = 100,
                RouteID = "card_oubs0hwk5rn6knuecxg2",
                RouteType = PendingTransactions::RouteType.Card,
                Source = new()
                {
                    Category = PendingTransactions::SourceCategory.CardAuthorization,
                    AccountTransferInstruction = new()
                    {
                        Amount = 100,
                        Currency = PendingTransactions::AccountTransferInstructionCurrency.Usd,
                        TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                    },
                    AchTransferInstruction = new()
                    {
                        Amount = 100,
                        TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
                    },
                    BlockchainOfframpTransferInstruction = new()
                    {
                        SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
                        TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
                    },
                    BlockchainOnrampTransferInstruction = new()
                    {
                        Amount = 10000,
                        DestinationBlockchainAddress = "0x304a554a310C7e546dfe434669C62820b7D83490",
                        TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
                    },
                    CardAuthorization = new()
                    {
                        ID = "card_authorization_6iqxap6ivd0fo5eu3i8x",
                        Actioner = PendingTransactions::Actioner.Increase,
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
                        Amount = 100,
                        CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                        Currency = PendingTransactions::CardAuthorizationCurrency.Usd,
                        DigitalWalletTokenID = null,
                        Direction = PendingTransactions::Direction.Settlement,
                        ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        MerchantAcceptorID = "5665270011000168",
                        MerchantCategoryCode = "5734",
                        MerchantCity = "New York",
                        MerchantCountry = "US",
                        MerchantDescriptor = "AMAZON.COM",
                        MerchantPostalCode = "10045",
                        MerchantState = "NY",
                        NetworkDetails = new()
                        {
                            Category = PendingTransactions::NetworkDetailsCategory.Visa,
                            Pulse = new(),
                            Visa = new()
                            {
                                ElectronicCommerceIndicator =
                                    PendingTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                PointOfServiceEntryMode =
                                    PendingTransactions::PointOfServiceEntryMode.Manual,
                                StandInProcessingReason = null,
                                TerminalEntryCapability =
                                    PendingTransactions::TerminalEntryCapability.MagneticStripe,
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
                        PendingTransactionID = null,
                        PhysicalCardID = null,
                        PresentmentAmount = 100,
                        PresentmentCurrency = "USD",
                        ProcessingCategory = PendingTransactions::ProcessingCategory.Purchase,
                        RealTimeDecisionID = null,
                        TerminalID = "RCN5VNXS",
                        Type = PendingTransactions::Type.CardAuthorization,
                        Verification = new()
                        {
                            CardVerificationCode = new(PendingTransactions::Result.Match),
                            CardholderAddress = new()
                            {
                                ActualLine1 = "33 Liberty Street",
                                ActualPostalCode = "94131",
                                ProvidedLine1 = "33 Liberty Street",
                                ProvidedPostalCode = "94132",
                                Result =
                                    PendingTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                            },
                            CardholderName = new()
                            {
                                ProvidedFirstName = "provided_first_name",
                                ProvidedLastName = "provided_last_name",
                                ProvidedMiddleName = "provided_middle_name",
                            },
                        },
                    },
                    CardPushTransferInstruction = new()
                    {
                        Amount = 100,
                        TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                    },
                    CheckDepositInstruction = new()
                    {
                        Amount = 100,
                        BackImageFileID = "file_26khfk98mzfz90a11oqx",
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = PendingTransactions::CheckDepositInstructionCurrency.Usd,
                        FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    },
                    CheckTransferInstruction = new()
                    {
                        Amount = 100,
                        Currency = PendingTransactions::CheckTransferInstructionCurrency.Usd,
                        TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                    },
                    FednowTransferInstruction = new("fednow_transfer_4i0mptrdu1mueg1196bg"),
                    InboundFundsHold = new()
                    {
                        Amount = 100,
                        AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = PendingTransactions::InboundFundsHoldCurrency.Usd,
                        HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                        ReleasedAt = null,
                        Status = PendingTransactions::InboundFundsHoldStatus.Held,
                        Type = PendingTransactions::InboundFundsHoldType.InboundFundsHold,
                    },
                    InboundWireTransferReversal = new("inbound_wire_transfer_f228m6bmhtcxjco9pwp0"),
                    Other = new(),
                    RealTimePaymentsTransferInstruction = new()
                    {
                        Amount = 100,
                        TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                    },
                    SwiftTransferInstruction = new("swift_transfer_29h21xkng03788zwd3fh"),
                    UserInitiatedHold = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    WireTransferInstruction = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 100,
                        MessageToRecipient = "HELLO",
                        RoutingNumber = "101050001",
                        TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                    },
                },
                Status = PendingTransactions::PendingTransactionStatus.Pending,
                Type = PendingTransactions::PendingTransactionType.PendingTransaction,
            },
            Type = CardAuthorizations::Type.InboundCardAuthorizationSimulationResult,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardAuthorizations::CardAuthorizationCreateResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DeclinedTransactions::DeclinedTransaction expectedDeclinedTransaction = new()
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
        };
        PendingTransactions::PendingTransaction expectedPendingTransaction = new()
        {
            ID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            CompletedAt = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = PendingTransactions::Currency.Usd,
            Description = "INVOICE 2468",
            HeldAmount = 100,
            RouteID = "card_oubs0hwk5rn6knuecxg2",
            RouteType = PendingTransactions::RouteType.Card,
            Source = new()
            {
                Category = PendingTransactions::SourceCategory.CardAuthorization,
                AccountTransferInstruction = new()
                {
                    Amount = 100,
                    Currency = PendingTransactions::AccountTransferInstructionCurrency.Usd,
                    TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                },
                AchTransferInstruction = new()
                {
                    Amount = 100,
                    TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
                },
                BlockchainOfframpTransferInstruction = new()
                {
                    SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
                    TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
                },
                BlockchainOnrampTransferInstruction = new()
                {
                    Amount = 10000,
                    DestinationBlockchainAddress = "0x304a554a310C7e546dfe434669C62820b7D83490",
                    TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
                },
                CardAuthorization = new()
                {
                    ID = "card_authorization_6iqxap6ivd0fo5eu3i8x",
                    Actioner = PendingTransactions::Actioner.Increase,
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
                    Amount = 100,
                    CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                    Currency = PendingTransactions::CardAuthorizationCurrency.Usd,
                    DigitalWalletTokenID = null,
                    Direction = PendingTransactions::Direction.Settlement,
                    ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    MerchantAcceptorID = "5665270011000168",
                    MerchantCategoryCode = "5734",
                    MerchantCity = "New York",
                    MerchantCountry = "US",
                    MerchantDescriptor = "AMAZON.COM",
                    MerchantPostalCode = "10045",
                    MerchantState = "NY",
                    NetworkDetails = new()
                    {
                        Category = PendingTransactions::NetworkDetailsCategory.Visa,
                        Pulse = new(),
                        Visa = new()
                        {
                            ElectronicCommerceIndicator =
                                PendingTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                            PointOfServiceEntryMode =
                                PendingTransactions::PointOfServiceEntryMode.Manual,
                            StandInProcessingReason = null,
                            TerminalEntryCapability =
                                PendingTransactions::TerminalEntryCapability.MagneticStripe,
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
                    PendingTransactionID = null,
                    PhysicalCardID = null,
                    PresentmentAmount = 100,
                    PresentmentCurrency = "USD",
                    ProcessingCategory = PendingTransactions::ProcessingCategory.Purchase,
                    RealTimeDecisionID = null,
                    TerminalID = "RCN5VNXS",
                    Type = PendingTransactions::Type.CardAuthorization,
                    Verification = new()
                    {
                        CardVerificationCode = new(PendingTransactions::Result.Match),
                        CardholderAddress = new()
                        {
                            ActualLine1 = "33 Liberty Street",
                            ActualPostalCode = "94131",
                            ProvidedLine1 = "33 Liberty Street",
                            ProvidedPostalCode = "94132",
                            Result =
                                PendingTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                        },
                        CardholderName = new()
                        {
                            ProvidedFirstName = "provided_first_name",
                            ProvidedLastName = "provided_last_name",
                            ProvidedMiddleName = "provided_middle_name",
                        },
                    },
                },
                CardPushTransferInstruction = new()
                {
                    Amount = 100,
                    TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                },
                CheckDepositInstruction = new()
                {
                    Amount = 100,
                    BackImageFileID = "file_26khfk98mzfz90a11oqx",
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    Currency = PendingTransactions::CheckDepositInstructionCurrency.Usd,
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                },
                CheckTransferInstruction = new()
                {
                    Amount = 100,
                    Currency = PendingTransactions::CheckTransferInstructionCurrency.Usd,
                    TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                },
                FednowTransferInstruction = new("fednow_transfer_4i0mptrdu1mueg1196bg"),
                InboundFundsHold = new()
                {
                    Amount = 100,
                    AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = PendingTransactions::InboundFundsHoldCurrency.Usd,
                    HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                    ReleasedAt = null,
                    Status = PendingTransactions::InboundFundsHoldStatus.Held,
                    Type = PendingTransactions::InboundFundsHoldType.InboundFundsHold,
                },
                InboundWireTransferReversal = new("inbound_wire_transfer_f228m6bmhtcxjco9pwp0"),
                Other = new(),
                RealTimePaymentsTransferInstruction = new()
                {
                    Amount = 100,
                    TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                },
                SwiftTransferInstruction = new("swift_transfer_29h21xkng03788zwd3fh"),
                UserInitiatedHold = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                WireTransferInstruction = new()
                {
                    AccountNumber = "987654321",
                    Amount = 100,
                    MessageToRecipient = "HELLO",
                    RoutingNumber = "101050001",
                    TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                },
            },
            Status = PendingTransactions::PendingTransactionStatus.Pending,
            Type = PendingTransactions::PendingTransactionType.PendingTransaction,
        };
        ApiEnum<string, CardAuthorizations::Type> expectedType =
            CardAuthorizations::Type.InboundCardAuthorizationSimulationResult;

        Assert.Equal(expectedDeclinedTransaction, deserialized.DeclinedTransaction);
        Assert.Equal(expectedPendingTransaction, deserialized.PendingTransaction);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardAuthorizations::CardAuthorizationCreateResponse
        {
            DeclinedTransaction = new()
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
            PendingTransaction = new()
            {
                ID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                AccountID = "account_in71c4amph0vgo2qllky",
                Amount = 100,
                CompletedAt = null,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = PendingTransactions::Currency.Usd,
                Description = "INVOICE 2468",
                HeldAmount = 100,
                RouteID = "card_oubs0hwk5rn6knuecxg2",
                RouteType = PendingTransactions::RouteType.Card,
                Source = new()
                {
                    Category = PendingTransactions::SourceCategory.CardAuthorization,
                    AccountTransferInstruction = new()
                    {
                        Amount = 100,
                        Currency = PendingTransactions::AccountTransferInstructionCurrency.Usd,
                        TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                    },
                    AchTransferInstruction = new()
                    {
                        Amount = 100,
                        TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
                    },
                    BlockchainOfframpTransferInstruction = new()
                    {
                        SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
                        TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
                    },
                    BlockchainOnrampTransferInstruction = new()
                    {
                        Amount = 10000,
                        DestinationBlockchainAddress = "0x304a554a310C7e546dfe434669C62820b7D83490",
                        TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
                    },
                    CardAuthorization = new()
                    {
                        ID = "card_authorization_6iqxap6ivd0fo5eu3i8x",
                        Actioner = PendingTransactions::Actioner.Increase,
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
                        Amount = 100,
                        CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                        Currency = PendingTransactions::CardAuthorizationCurrency.Usd,
                        DigitalWalletTokenID = null,
                        Direction = PendingTransactions::Direction.Settlement,
                        ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        MerchantAcceptorID = "5665270011000168",
                        MerchantCategoryCode = "5734",
                        MerchantCity = "New York",
                        MerchantCountry = "US",
                        MerchantDescriptor = "AMAZON.COM",
                        MerchantPostalCode = "10045",
                        MerchantState = "NY",
                        NetworkDetails = new()
                        {
                            Category = PendingTransactions::NetworkDetailsCategory.Visa,
                            Pulse = new(),
                            Visa = new()
                            {
                                ElectronicCommerceIndicator =
                                    PendingTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                PointOfServiceEntryMode =
                                    PendingTransactions::PointOfServiceEntryMode.Manual,
                                StandInProcessingReason = null,
                                TerminalEntryCapability =
                                    PendingTransactions::TerminalEntryCapability.MagneticStripe,
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
                        PendingTransactionID = null,
                        PhysicalCardID = null,
                        PresentmentAmount = 100,
                        PresentmentCurrency = "USD",
                        ProcessingCategory = PendingTransactions::ProcessingCategory.Purchase,
                        RealTimeDecisionID = null,
                        TerminalID = "RCN5VNXS",
                        Type = PendingTransactions::Type.CardAuthorization,
                        Verification = new()
                        {
                            CardVerificationCode = new(PendingTransactions::Result.Match),
                            CardholderAddress = new()
                            {
                                ActualLine1 = "33 Liberty Street",
                                ActualPostalCode = "94131",
                                ProvidedLine1 = "33 Liberty Street",
                                ProvidedPostalCode = "94132",
                                Result =
                                    PendingTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                            },
                            CardholderName = new()
                            {
                                ProvidedFirstName = "provided_first_name",
                                ProvidedLastName = "provided_last_name",
                                ProvidedMiddleName = "provided_middle_name",
                            },
                        },
                    },
                    CardPushTransferInstruction = new()
                    {
                        Amount = 100,
                        TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                    },
                    CheckDepositInstruction = new()
                    {
                        Amount = 100,
                        BackImageFileID = "file_26khfk98mzfz90a11oqx",
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = PendingTransactions::CheckDepositInstructionCurrency.Usd,
                        FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    },
                    CheckTransferInstruction = new()
                    {
                        Amount = 100,
                        Currency = PendingTransactions::CheckTransferInstructionCurrency.Usd,
                        TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                    },
                    FednowTransferInstruction = new("fednow_transfer_4i0mptrdu1mueg1196bg"),
                    InboundFundsHold = new()
                    {
                        Amount = 100,
                        AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = PendingTransactions::InboundFundsHoldCurrency.Usd,
                        HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                        ReleasedAt = null,
                        Status = PendingTransactions::InboundFundsHoldStatus.Held,
                        Type = PendingTransactions::InboundFundsHoldType.InboundFundsHold,
                    },
                    InboundWireTransferReversal = new("inbound_wire_transfer_f228m6bmhtcxjco9pwp0"),
                    Other = new(),
                    RealTimePaymentsTransferInstruction = new()
                    {
                        Amount = 100,
                        TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                    },
                    SwiftTransferInstruction = new("swift_transfer_29h21xkng03788zwd3fh"),
                    UserInitiatedHold = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    WireTransferInstruction = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 100,
                        MessageToRecipient = "HELLO",
                        RoutingNumber = "101050001",
                        TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                    },
                },
                Status = PendingTransactions::PendingTransactionStatus.Pending,
                Type = PendingTransactions::PendingTransactionType.PendingTransaction,
            },
            Type = CardAuthorizations::Type.InboundCardAuthorizationSimulationResult,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardAuthorizations::CardAuthorizationCreateResponse
        {
            DeclinedTransaction = new()
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
            PendingTransaction = new()
            {
                ID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                AccountID = "account_in71c4amph0vgo2qllky",
                Amount = 100,
                CompletedAt = null,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = PendingTransactions::Currency.Usd,
                Description = "INVOICE 2468",
                HeldAmount = 100,
                RouteID = "card_oubs0hwk5rn6knuecxg2",
                RouteType = PendingTransactions::RouteType.Card,
                Source = new()
                {
                    Category = PendingTransactions::SourceCategory.CardAuthorization,
                    AccountTransferInstruction = new()
                    {
                        Amount = 100,
                        Currency = PendingTransactions::AccountTransferInstructionCurrency.Usd,
                        TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                    },
                    AchTransferInstruction = new()
                    {
                        Amount = 100,
                        TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
                    },
                    BlockchainOfframpTransferInstruction = new()
                    {
                        SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
                        TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
                    },
                    BlockchainOnrampTransferInstruction = new()
                    {
                        Amount = 10000,
                        DestinationBlockchainAddress = "0x304a554a310C7e546dfe434669C62820b7D83490",
                        TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
                    },
                    CardAuthorization = new()
                    {
                        ID = "card_authorization_6iqxap6ivd0fo5eu3i8x",
                        Actioner = PendingTransactions::Actioner.Increase,
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
                        Amount = 100,
                        CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                        Currency = PendingTransactions::CardAuthorizationCurrency.Usd,
                        DigitalWalletTokenID = null,
                        Direction = PendingTransactions::Direction.Settlement,
                        ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        MerchantAcceptorID = "5665270011000168",
                        MerchantCategoryCode = "5734",
                        MerchantCity = "New York",
                        MerchantCountry = "US",
                        MerchantDescriptor = "AMAZON.COM",
                        MerchantPostalCode = "10045",
                        MerchantState = "NY",
                        NetworkDetails = new()
                        {
                            Category = PendingTransactions::NetworkDetailsCategory.Visa,
                            Pulse = new(),
                            Visa = new()
                            {
                                ElectronicCommerceIndicator =
                                    PendingTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                PointOfServiceEntryMode =
                                    PendingTransactions::PointOfServiceEntryMode.Manual,
                                StandInProcessingReason = null,
                                TerminalEntryCapability =
                                    PendingTransactions::TerminalEntryCapability.MagneticStripe,
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
                        PendingTransactionID = null,
                        PhysicalCardID = null,
                        PresentmentAmount = 100,
                        PresentmentCurrency = "USD",
                        ProcessingCategory = PendingTransactions::ProcessingCategory.Purchase,
                        RealTimeDecisionID = null,
                        TerminalID = "RCN5VNXS",
                        Type = PendingTransactions::Type.CardAuthorization,
                        Verification = new()
                        {
                            CardVerificationCode = new(PendingTransactions::Result.Match),
                            CardholderAddress = new()
                            {
                                ActualLine1 = "33 Liberty Street",
                                ActualPostalCode = "94131",
                                ProvidedLine1 = "33 Liberty Street",
                                ProvidedPostalCode = "94132",
                                Result =
                                    PendingTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                            },
                            CardholderName = new()
                            {
                                ProvidedFirstName = "provided_first_name",
                                ProvidedLastName = "provided_last_name",
                                ProvidedMiddleName = "provided_middle_name",
                            },
                        },
                    },
                    CardPushTransferInstruction = new()
                    {
                        Amount = 100,
                        TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                    },
                    CheckDepositInstruction = new()
                    {
                        Amount = 100,
                        BackImageFileID = "file_26khfk98mzfz90a11oqx",
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = PendingTransactions::CheckDepositInstructionCurrency.Usd,
                        FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    },
                    CheckTransferInstruction = new()
                    {
                        Amount = 100,
                        Currency = PendingTransactions::CheckTransferInstructionCurrency.Usd,
                        TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                    },
                    FednowTransferInstruction = new("fednow_transfer_4i0mptrdu1mueg1196bg"),
                    InboundFundsHold = new()
                    {
                        Amount = 100,
                        AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = PendingTransactions::InboundFundsHoldCurrency.Usd,
                        HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                        ReleasedAt = null,
                        Status = PendingTransactions::InboundFundsHoldStatus.Held,
                        Type = PendingTransactions::InboundFundsHoldType.InboundFundsHold,
                    },
                    InboundWireTransferReversal = new("inbound_wire_transfer_f228m6bmhtcxjco9pwp0"),
                    Other = new(),
                    RealTimePaymentsTransferInstruction = new()
                    {
                        Amount = 100,
                        TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                    },
                    SwiftTransferInstruction = new("swift_transfer_29h21xkng03788zwd3fh"),
                    UserInitiatedHold = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    WireTransferInstruction = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 100,
                        MessageToRecipient = "HELLO",
                        RoutingNumber = "101050001",
                        TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                    },
                },
                Status = PendingTransactions::PendingTransactionStatus.Pending,
                Type = PendingTransactions::PendingTransactionType.PendingTransaction,
            },
            Type = CardAuthorizations::Type.InboundCardAuthorizationSimulationResult,
        };

        CardAuthorizations::CardAuthorizationCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(CardAuthorizations::Type.InboundCardAuthorizationSimulationResult)]
    public void Validation_Works(CardAuthorizations::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardAuthorizations::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardAuthorizations::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardAuthorizations::Type.InboundCardAuthorizationSimulationResult)]
    public void SerializationRoundtrip_Works(CardAuthorizations::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardAuthorizations::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardAuthorizations::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardAuthorizations::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardAuthorizations::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
