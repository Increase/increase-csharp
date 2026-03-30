using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using PendingTransactions = Increase.Api.Models.PendingTransactions;

namespace Increase.Api.Tests.Models.PendingTransactions;

public class PendingTransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::PendingTransaction
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
                Category = PendingTransactions::SourceCategory.AchTransferInstruction,
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
                    SchemeFees =
                    [
                        new()
                        {
                            Amount = "0.137465",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                            FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                            FixedComponent = null,
                            VariableRate = "0.0002",
                        },
                    ],
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

        string expectedID = "pending_transaction_k1sfetcau2qbvjbzgju4";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAmount = 100;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, PendingTransactions::Currency> expectedCurrency =
            PendingTransactions::Currency.Usd;
        string expectedDescription = "INVOICE 2468";
        long expectedHeldAmount = 100;
        string expectedRouteID = "card_oubs0hwk5rn6knuecxg2";
        ApiEnum<string, PendingTransactions::RouteType> expectedRouteType =
            PendingTransactions::RouteType.Card;
        PendingTransactions::Source expectedSource = new()
        {
            Category = PendingTransactions::SourceCategory.AchTransferInstruction,
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
                SchemeFees =
                [
                    new()
                    {
                        Amount = "0.137465",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                        FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                        FixedComponent = null,
                        VariableRate = "0.0002",
                    },
                ],
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
        };
        ApiEnum<string, PendingTransactions::PendingTransactionStatus> expectedStatus =
            PendingTransactions::PendingTransactionStatus.Pending;
        ApiEnum<string, PendingTransactions::PendingTransactionType> expectedType =
            PendingTransactions::PendingTransactionType.PendingTransaction;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Null(model.CompletedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedHeldAmount, model.HeldAmount);
        Assert.Equal(expectedRouteID, model.RouteID);
        Assert.Equal(expectedRouteType, model.RouteType);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::PendingTransaction
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
                Category = PendingTransactions::SourceCategory.AchTransferInstruction,
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
                    SchemeFees =
                    [
                        new()
                        {
                            Amount = "0.137465",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                            FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                            FixedComponent = null,
                            VariableRate = "0.0002",
                        },
                    ],
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::PendingTransaction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::PendingTransaction
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
                Category = PendingTransactions::SourceCategory.AchTransferInstruction,
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
                    SchemeFees =
                    [
                        new()
                        {
                            Amount = "0.137465",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                            FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                            FixedComponent = null,
                            VariableRate = "0.0002",
                        },
                    ],
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::PendingTransaction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "pending_transaction_k1sfetcau2qbvjbzgju4";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAmount = 100;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, PendingTransactions::Currency> expectedCurrency =
            PendingTransactions::Currency.Usd;
        string expectedDescription = "INVOICE 2468";
        long expectedHeldAmount = 100;
        string expectedRouteID = "card_oubs0hwk5rn6knuecxg2";
        ApiEnum<string, PendingTransactions::RouteType> expectedRouteType =
            PendingTransactions::RouteType.Card;
        PendingTransactions::Source expectedSource = new()
        {
            Category = PendingTransactions::SourceCategory.AchTransferInstruction,
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
                SchemeFees =
                [
                    new()
                    {
                        Amount = "0.137465",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                        FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                        FixedComponent = null,
                        VariableRate = "0.0002",
                    },
                ],
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
        };
        ApiEnum<string, PendingTransactions::PendingTransactionStatus> expectedStatus =
            PendingTransactions::PendingTransactionStatus.Pending;
        ApiEnum<string, PendingTransactions::PendingTransactionType> expectedType =
            PendingTransactions::PendingTransactionType.PendingTransaction;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Null(deserialized.CompletedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedHeldAmount, deserialized.HeldAmount);
        Assert.Equal(expectedRouteID, deserialized.RouteID);
        Assert.Equal(expectedRouteType, deserialized.RouteType);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::PendingTransaction
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
                Category = PendingTransactions::SourceCategory.AchTransferInstruction,
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
                    SchemeFees =
                    [
                        new()
                        {
                            Amount = "0.137465",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                            FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                            FixedComponent = null,
                            VariableRate = "0.0002",
                        },
                    ],
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::PendingTransaction
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
                Category = PendingTransactions::SourceCategory.AchTransferInstruction,
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
                    SchemeFees =
                    [
                        new()
                        {
                            Amount = "0.137465",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                            FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                            FixedComponent = null,
                            VariableRate = "0.0002",
                        },
                    ],
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

        PendingTransactions::PendingTransaction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::Currency.Usd)]
    public void Validation_Works(PendingTransactions::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::Currency.Usd)]
    public void SerializationRoundtrip_Works(PendingTransactions::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::Currency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::Currency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RouteTypeTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::RouteType.AccountNumber)]
    [InlineData(PendingTransactions::RouteType.Card)]
    [InlineData(PendingTransactions::RouteType.Lockbox)]
    public void Validation_Works(PendingTransactions::RouteType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::RouteType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::RouteType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::RouteType.AccountNumber)]
    [InlineData(PendingTransactions::RouteType.Card)]
    [InlineData(PendingTransactions::RouteType.Lockbox)]
    public void SerializationRoundtrip_Works(PendingTransactions::RouteType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::RouteType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::RouteType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::RouteType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::RouteType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::Source
        {
            Category = PendingTransactions::SourceCategory.AchTransferInstruction,
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
                SchemeFees =
                [
                    new()
                    {
                        Amount = "0.137465",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                        FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                        FixedComponent = null,
                        VariableRate = "0.0002",
                    },
                ],
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
        };

        ApiEnum<string, PendingTransactions::SourceCategory> expectedCategory =
            PendingTransactions::SourceCategory.AchTransferInstruction;
        PendingTransactions::AccountTransferInstruction expectedAccountTransferInstruction = new()
        {
            Amount = 100,
            Currency = PendingTransactions::AccountTransferInstructionCurrency.Usd,
            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
        };
        PendingTransactions::AchTransferInstruction expectedAchTransferInstruction = new()
        {
            Amount = 100,
            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };
        PendingTransactions::BlockchainOfframpTransferInstruction expectedBlockchainOfframpTransferInstruction =
            new()
            {
                SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
                TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
            };
        PendingTransactions::BlockchainOnrampTransferInstruction expectedBlockchainOnrampTransferInstruction =
            new()
            {
                Amount = 10000,
                DestinationBlockchainAddress = "0x304a554a310C7e546dfe434669C62820b7D83490",
                TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
            };
        PendingTransactions::CardAuthorization expectedCardAuthorization = new()
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
                    PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Manual,
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
            SchemeFees =
            [
                new()
                {
                    Amount = "0.137465",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                    FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                    FixedComponent = null,
                    VariableRate = "0.0002",
                },
            ],
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
        };
        PendingTransactions::CardPushTransferInstruction expectedCardPushTransferInstruction = new()
        {
            Amount = 100,
            TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
        };
        PendingTransactions::CheckDepositInstruction expectedCheckDepositInstruction = new()
        {
            Amount = 100,
            BackImageFileID = "file_26khfk98mzfz90a11oqx",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = PendingTransactions::CheckDepositInstructionCurrency.Usd,
            FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
        };
        PendingTransactions::CheckTransferInstruction expectedCheckTransferInstruction = new()
        {
            Amount = 100,
            Currency = PendingTransactions::CheckTransferInstructionCurrency.Usd,
            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
        };
        PendingTransactions::FednowTransferInstruction expectedFednowTransferInstruction = new(
            "fednow_transfer_4i0mptrdu1mueg1196bg"
        );
        PendingTransactions::InboundFundsHold expectedInboundFundsHold = new()
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
        };
        PendingTransactions::InboundWireTransferReversal expectedInboundWireTransferReversal = new(
            "inbound_wire_transfer_f228m6bmhtcxjco9pwp0"
        );
        PendingTransactions::Other expectedOther = new();
        PendingTransactions::RealTimePaymentsTransferInstruction expectedRealTimePaymentsTransferInstruction =
            new() { Amount = 100, TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq" };
        PendingTransactions::SwiftTransferInstruction expectedSwiftTransferInstruction = new(
            "swift_transfer_29h21xkng03788zwd3fh"
        );
        Dictionary<string, JsonElement> expectedUserInitiatedHold = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        PendingTransactions::WireTransferInstruction expectedWireTransferInstruction = new()
        {
            AccountNumber = "987654321",
            Amount = 100,
            MessageToRecipient = "HELLO",
            RoutingNumber = "101050001",
            TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedAccountTransferInstruction, model.AccountTransferInstruction);
        Assert.Equal(expectedAchTransferInstruction, model.AchTransferInstruction);
        Assert.Equal(
            expectedBlockchainOfframpTransferInstruction,
            model.BlockchainOfframpTransferInstruction
        );
        Assert.Equal(
            expectedBlockchainOnrampTransferInstruction,
            model.BlockchainOnrampTransferInstruction
        );
        Assert.Equal(expectedCardAuthorization, model.CardAuthorization);
        Assert.Equal(expectedCardPushTransferInstruction, model.CardPushTransferInstruction);
        Assert.Equal(expectedCheckDepositInstruction, model.CheckDepositInstruction);
        Assert.Equal(expectedCheckTransferInstruction, model.CheckTransferInstruction);
        Assert.Equal(expectedFednowTransferInstruction, model.FednowTransferInstruction);
        Assert.Equal(expectedInboundFundsHold, model.InboundFundsHold);
        Assert.Equal(expectedInboundWireTransferReversal, model.InboundWireTransferReversal);
        Assert.Equal(expectedOther, model.Other);
        Assert.Equal(
            expectedRealTimePaymentsTransferInstruction,
            model.RealTimePaymentsTransferInstruction
        );
        Assert.Equal(expectedSwiftTransferInstruction, model.SwiftTransferInstruction);
        Assert.NotNull(model.UserInitiatedHold);
        Assert.Equal(expectedUserInitiatedHold.Count, model.UserInitiatedHold.Count);
        foreach (var item in expectedUserInitiatedHold)
        {
            Assert.True(model.UserInitiatedHold.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.UserInitiatedHold[item.Key]));
        }
        Assert.Equal(expectedWireTransferInstruction, model.WireTransferInstruction);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::Source
        {
            Category = PendingTransactions::SourceCategory.AchTransferInstruction,
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
                SchemeFees =
                [
                    new()
                    {
                        Amount = "0.137465",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                        FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                        FixedComponent = null,
                        VariableRate = "0.0002",
                    },
                ],
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Source>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::Source
        {
            Category = PendingTransactions::SourceCategory.AchTransferInstruction,
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
                SchemeFees =
                [
                    new()
                    {
                        Amount = "0.137465",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                        FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                        FixedComponent = null,
                        VariableRate = "0.0002",
                    },
                ],
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Source>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PendingTransactions::SourceCategory> expectedCategory =
            PendingTransactions::SourceCategory.AchTransferInstruction;
        PendingTransactions::AccountTransferInstruction expectedAccountTransferInstruction = new()
        {
            Amount = 100,
            Currency = PendingTransactions::AccountTransferInstructionCurrency.Usd,
            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
        };
        PendingTransactions::AchTransferInstruction expectedAchTransferInstruction = new()
        {
            Amount = 100,
            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };
        PendingTransactions::BlockchainOfframpTransferInstruction expectedBlockchainOfframpTransferInstruction =
            new()
            {
                SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
                TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
            };
        PendingTransactions::BlockchainOnrampTransferInstruction expectedBlockchainOnrampTransferInstruction =
            new()
            {
                Amount = 10000,
                DestinationBlockchainAddress = "0x304a554a310C7e546dfe434669C62820b7D83490",
                TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
            };
        PendingTransactions::CardAuthorization expectedCardAuthorization = new()
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
                    PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Manual,
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
            SchemeFees =
            [
                new()
                {
                    Amount = "0.137465",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                    FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                    FixedComponent = null,
                    VariableRate = "0.0002",
                },
            ],
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
        };
        PendingTransactions::CardPushTransferInstruction expectedCardPushTransferInstruction = new()
        {
            Amount = 100,
            TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
        };
        PendingTransactions::CheckDepositInstruction expectedCheckDepositInstruction = new()
        {
            Amount = 100,
            BackImageFileID = "file_26khfk98mzfz90a11oqx",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = PendingTransactions::CheckDepositInstructionCurrency.Usd,
            FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
        };
        PendingTransactions::CheckTransferInstruction expectedCheckTransferInstruction = new()
        {
            Amount = 100,
            Currency = PendingTransactions::CheckTransferInstructionCurrency.Usd,
            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
        };
        PendingTransactions::FednowTransferInstruction expectedFednowTransferInstruction = new(
            "fednow_transfer_4i0mptrdu1mueg1196bg"
        );
        PendingTransactions::InboundFundsHold expectedInboundFundsHold = new()
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
        };
        PendingTransactions::InboundWireTransferReversal expectedInboundWireTransferReversal = new(
            "inbound_wire_transfer_f228m6bmhtcxjco9pwp0"
        );
        PendingTransactions::Other expectedOther = new();
        PendingTransactions::RealTimePaymentsTransferInstruction expectedRealTimePaymentsTransferInstruction =
            new() { Amount = 100, TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq" };
        PendingTransactions::SwiftTransferInstruction expectedSwiftTransferInstruction = new(
            "swift_transfer_29h21xkng03788zwd3fh"
        );
        Dictionary<string, JsonElement> expectedUserInitiatedHold = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        PendingTransactions::WireTransferInstruction expectedWireTransferInstruction = new()
        {
            AccountNumber = "987654321",
            Amount = 100,
            MessageToRecipient = "HELLO",
            RoutingNumber = "101050001",
            TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedAccountTransferInstruction, deserialized.AccountTransferInstruction);
        Assert.Equal(expectedAchTransferInstruction, deserialized.AchTransferInstruction);
        Assert.Equal(
            expectedBlockchainOfframpTransferInstruction,
            deserialized.BlockchainOfframpTransferInstruction
        );
        Assert.Equal(
            expectedBlockchainOnrampTransferInstruction,
            deserialized.BlockchainOnrampTransferInstruction
        );
        Assert.Equal(expectedCardAuthorization, deserialized.CardAuthorization);
        Assert.Equal(expectedCardPushTransferInstruction, deserialized.CardPushTransferInstruction);
        Assert.Equal(expectedCheckDepositInstruction, deserialized.CheckDepositInstruction);
        Assert.Equal(expectedCheckTransferInstruction, deserialized.CheckTransferInstruction);
        Assert.Equal(expectedFednowTransferInstruction, deserialized.FednowTransferInstruction);
        Assert.Equal(expectedInboundFundsHold, deserialized.InboundFundsHold);
        Assert.Equal(expectedInboundWireTransferReversal, deserialized.InboundWireTransferReversal);
        Assert.Equal(expectedOther, deserialized.Other);
        Assert.Equal(
            expectedRealTimePaymentsTransferInstruction,
            deserialized.RealTimePaymentsTransferInstruction
        );
        Assert.Equal(expectedSwiftTransferInstruction, deserialized.SwiftTransferInstruction);
        Assert.NotNull(deserialized.UserInitiatedHold);
        Assert.Equal(expectedUserInitiatedHold.Count, deserialized.UserInitiatedHold.Count);
        foreach (var item in expectedUserInitiatedHold)
        {
            Assert.True(deserialized.UserInitiatedHold.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.UserInitiatedHold[item.Key]));
        }
        Assert.Equal(expectedWireTransferInstruction, deserialized.WireTransferInstruction);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::Source
        {
            Category = PendingTransactions::SourceCategory.AchTransferInstruction,
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
                SchemeFees =
                [
                    new()
                    {
                        Amount = "0.137465",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                        FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                        FixedComponent = null,
                        VariableRate = "0.0002",
                    },
                ],
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PendingTransactions::Source
        {
            Category = PendingTransactions::SourceCategory.AchTransferInstruction,
        };

        Assert.Null(model.AccountTransferInstruction);
        Assert.False(model.RawData.ContainsKey("account_transfer_instruction"));
        Assert.Null(model.AchTransferInstruction);
        Assert.False(model.RawData.ContainsKey("ach_transfer_instruction"));
        Assert.Null(model.BlockchainOfframpTransferInstruction);
        Assert.False(model.RawData.ContainsKey("blockchain_offramp_transfer_instruction"));
        Assert.Null(model.BlockchainOnrampTransferInstruction);
        Assert.False(model.RawData.ContainsKey("blockchain_onramp_transfer_instruction"));
        Assert.Null(model.CardAuthorization);
        Assert.False(model.RawData.ContainsKey("card_authorization"));
        Assert.Null(model.CardPushTransferInstruction);
        Assert.False(model.RawData.ContainsKey("card_push_transfer_instruction"));
        Assert.Null(model.CheckDepositInstruction);
        Assert.False(model.RawData.ContainsKey("check_deposit_instruction"));
        Assert.Null(model.CheckTransferInstruction);
        Assert.False(model.RawData.ContainsKey("check_transfer_instruction"));
        Assert.Null(model.FednowTransferInstruction);
        Assert.False(model.RawData.ContainsKey("fednow_transfer_instruction"));
        Assert.Null(model.InboundFundsHold);
        Assert.False(model.RawData.ContainsKey("inbound_funds_hold"));
        Assert.Null(model.InboundWireTransferReversal);
        Assert.False(model.RawData.ContainsKey("inbound_wire_transfer_reversal"));
        Assert.Null(model.Other);
        Assert.False(model.RawData.ContainsKey("other"));
        Assert.Null(model.RealTimePaymentsTransferInstruction);
        Assert.False(model.RawData.ContainsKey("real_time_payments_transfer_instruction"));
        Assert.Null(model.SwiftTransferInstruction);
        Assert.False(model.RawData.ContainsKey("swift_transfer_instruction"));
        Assert.Null(model.UserInitiatedHold);
        Assert.False(model.RawData.ContainsKey("user_initiated_hold"));
        Assert.Null(model.WireTransferInstruction);
        Assert.False(model.RawData.ContainsKey("wire_transfer_instruction"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PendingTransactions::Source
        {
            Category = PendingTransactions::SourceCategory.AchTransferInstruction,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PendingTransactions::Source
        {
            Category = PendingTransactions::SourceCategory.AchTransferInstruction,

            AccountTransferInstruction = null,
            AchTransferInstruction = null,
            BlockchainOfframpTransferInstruction = null,
            BlockchainOnrampTransferInstruction = null,
            CardAuthorization = null,
            CardPushTransferInstruction = null,
            CheckDepositInstruction = null,
            CheckTransferInstruction = null,
            FednowTransferInstruction = null,
            InboundFundsHold = null,
            InboundWireTransferReversal = null,
            Other = null,
            RealTimePaymentsTransferInstruction = null,
            SwiftTransferInstruction = null,
            UserInitiatedHold = null,
            WireTransferInstruction = null,
        };

        Assert.Null(model.AccountTransferInstruction);
        Assert.True(model.RawData.ContainsKey("account_transfer_instruction"));
        Assert.Null(model.AchTransferInstruction);
        Assert.True(model.RawData.ContainsKey("ach_transfer_instruction"));
        Assert.Null(model.BlockchainOfframpTransferInstruction);
        Assert.True(model.RawData.ContainsKey("blockchain_offramp_transfer_instruction"));
        Assert.Null(model.BlockchainOnrampTransferInstruction);
        Assert.True(model.RawData.ContainsKey("blockchain_onramp_transfer_instruction"));
        Assert.Null(model.CardAuthorization);
        Assert.True(model.RawData.ContainsKey("card_authorization"));
        Assert.Null(model.CardPushTransferInstruction);
        Assert.True(model.RawData.ContainsKey("card_push_transfer_instruction"));
        Assert.Null(model.CheckDepositInstruction);
        Assert.True(model.RawData.ContainsKey("check_deposit_instruction"));
        Assert.Null(model.CheckTransferInstruction);
        Assert.True(model.RawData.ContainsKey("check_transfer_instruction"));
        Assert.Null(model.FednowTransferInstruction);
        Assert.True(model.RawData.ContainsKey("fednow_transfer_instruction"));
        Assert.Null(model.InboundFundsHold);
        Assert.True(model.RawData.ContainsKey("inbound_funds_hold"));
        Assert.Null(model.InboundWireTransferReversal);
        Assert.True(model.RawData.ContainsKey("inbound_wire_transfer_reversal"));
        Assert.Null(model.Other);
        Assert.True(model.RawData.ContainsKey("other"));
        Assert.Null(model.RealTimePaymentsTransferInstruction);
        Assert.True(model.RawData.ContainsKey("real_time_payments_transfer_instruction"));
        Assert.Null(model.SwiftTransferInstruction);
        Assert.True(model.RawData.ContainsKey("swift_transfer_instruction"));
        Assert.Null(model.UserInitiatedHold);
        Assert.True(model.RawData.ContainsKey("user_initiated_hold"));
        Assert.Null(model.WireTransferInstruction);
        Assert.True(model.RawData.ContainsKey("wire_transfer_instruction"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PendingTransactions::Source
        {
            Category = PendingTransactions::SourceCategory.AchTransferInstruction,

            AccountTransferInstruction = null,
            AchTransferInstruction = null,
            BlockchainOfframpTransferInstruction = null,
            BlockchainOnrampTransferInstruction = null,
            CardAuthorization = null,
            CardPushTransferInstruction = null,
            CheckDepositInstruction = null,
            CheckTransferInstruction = null,
            FednowTransferInstruction = null,
            InboundFundsHold = null,
            InboundWireTransferReversal = null,
            Other = null,
            RealTimePaymentsTransferInstruction = null,
            SwiftTransferInstruction = null,
            UserInitiatedHold = null,
            WireTransferInstruction = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::Source
        {
            Category = PendingTransactions::SourceCategory.AchTransferInstruction,
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
                SchemeFees =
                [
                    new()
                    {
                        Amount = "0.137465",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                        FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                        FixedComponent = null,
                        VariableRate = "0.0002",
                    },
                ],
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
        };

        PendingTransactions::Source copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SourceCategoryTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::SourceCategory.AccountTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.AchTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.CardAuthorization)]
    [InlineData(PendingTransactions::SourceCategory.CheckDepositInstruction)]
    [InlineData(PendingTransactions::SourceCategory.CheckTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.FednowTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.InboundFundsHold)]
    [InlineData(PendingTransactions::SourceCategory.UserInitiatedHold)]
    [InlineData(PendingTransactions::SourceCategory.RealTimePaymentsTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.WireTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.InboundWireTransferReversal)]
    [InlineData(PendingTransactions::SourceCategory.SwiftTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.CardPushTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.BlockchainOnrampTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.BlockchainOfframpTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.Other)]
    public void Validation_Works(PendingTransactions::SourceCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::SourceCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::SourceCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::SourceCategory.AccountTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.AchTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.CardAuthorization)]
    [InlineData(PendingTransactions::SourceCategory.CheckDepositInstruction)]
    [InlineData(PendingTransactions::SourceCategory.CheckTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.FednowTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.InboundFundsHold)]
    [InlineData(PendingTransactions::SourceCategory.UserInitiatedHold)]
    [InlineData(PendingTransactions::SourceCategory.RealTimePaymentsTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.WireTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.InboundWireTransferReversal)]
    [InlineData(PendingTransactions::SourceCategory.SwiftTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.CardPushTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.BlockchainOnrampTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.BlockchainOfframpTransferInstruction)]
    [InlineData(PendingTransactions::SourceCategory.Other)]
    public void SerializationRoundtrip_Works(PendingTransactions::SourceCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::SourceCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::SourceCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::SourceCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::SourceCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AccountTransferInstructionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::AccountTransferInstruction
        {
            Amount = 100,
            Currency = PendingTransactions::AccountTransferInstructionCurrency.Usd,
            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
        };

        long expectedAmount = 100;
        ApiEnum<string, PendingTransactions::AccountTransferInstructionCurrency> expectedCurrency =
            PendingTransactions::AccountTransferInstructionCurrency.Usd;
        string expectedTransferID = "account_transfer_7k9qe1ysdgqztnt63l7n";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedTransferID, model.TransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::AccountTransferInstruction
        {
            Amount = 100,
            Currency = PendingTransactions::AccountTransferInstructionCurrency.Usd,
            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::AccountTransferInstruction>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::AccountTransferInstruction
        {
            Amount = 100,
            Currency = PendingTransactions::AccountTransferInstructionCurrency.Usd,
            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::AccountTransferInstruction>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAmount = 100;
        ApiEnum<string, PendingTransactions::AccountTransferInstructionCurrency> expectedCurrency =
            PendingTransactions::AccountTransferInstructionCurrency.Usd;
        string expectedTransferID = "account_transfer_7k9qe1ysdgqztnt63l7n";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedTransferID, deserialized.TransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::AccountTransferInstruction
        {
            Amount = 100,
            Currency = PendingTransactions::AccountTransferInstructionCurrency.Usd,
            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::AccountTransferInstruction
        {
            Amount = 100,
            Currency = PendingTransactions::AccountTransferInstructionCurrency.Usd,
            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
        };

        PendingTransactions::AccountTransferInstruction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccountTransferInstructionCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::AccountTransferInstructionCurrency.Usd)]
    public void Validation_Works(PendingTransactions::AccountTransferInstructionCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::AccountTransferInstructionCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::AccountTransferInstructionCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::AccountTransferInstructionCurrency.Usd)]
    public void SerializationRoundtrip_Works(
        PendingTransactions::AccountTransferInstructionCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::AccountTransferInstructionCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::AccountTransferInstructionCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::AccountTransferInstructionCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::AccountTransferInstructionCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AchTransferInstructionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::AchTransferInstruction
        {
            Amount = 100,
            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        long expectedAmount = 100;
        string expectedTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedTransferID, model.TransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::AchTransferInstruction
        {
            Amount = 100,
            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::AchTransferInstruction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::AchTransferInstruction
        {
            Amount = 100,
            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::AchTransferInstruction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 100;
        string expectedTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedTransferID, deserialized.TransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::AchTransferInstruction
        {
            Amount = 100,
            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::AchTransferInstruction
        {
            Amount = 100,
            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        PendingTransactions::AchTransferInstruction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BlockchainOfframpTransferInstructionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::BlockchainOfframpTransferInstruction
        {
            SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
            TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
        };

        string expectedSourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi";
        string expectedTransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m";

        Assert.Equal(expectedSourceBlockchainAddressID, model.SourceBlockchainAddressID);
        Assert.Equal(expectedTransferID, model.TransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::BlockchainOfframpTransferInstruction
        {
            SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
            TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::BlockchainOfframpTransferInstruction>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::BlockchainOfframpTransferInstruction
        {
            SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
            TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::BlockchainOfframpTransferInstruction>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedSourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi";
        string expectedTransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m";

        Assert.Equal(expectedSourceBlockchainAddressID, deserialized.SourceBlockchainAddressID);
        Assert.Equal(expectedTransferID, deserialized.TransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::BlockchainOfframpTransferInstruction
        {
            SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
            TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::BlockchainOfframpTransferInstruction
        {
            SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
            TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
        };

        PendingTransactions::BlockchainOfframpTransferInstruction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BlockchainOnrampTransferInstructionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::BlockchainOnrampTransferInstruction
        {
            Amount = 10000,
            DestinationBlockchainAddress = "0x304a554a310C7e546dfe434669C62820b7D83490",
            TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
        };

        long expectedAmount = 10000;
        string expectedDestinationBlockchainAddress = "0x304a554a310C7e546dfe434669C62820b7D83490";
        string expectedTransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedDestinationBlockchainAddress, model.DestinationBlockchainAddress);
        Assert.Equal(expectedTransferID, model.TransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::BlockchainOnrampTransferInstruction
        {
            Amount = 10000,
            DestinationBlockchainAddress = "0x304a554a310C7e546dfe434669C62820b7D83490",
            TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::BlockchainOnrampTransferInstruction>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::BlockchainOnrampTransferInstruction
        {
            Amount = 10000,
            DestinationBlockchainAddress = "0x304a554a310C7e546dfe434669C62820b7D83490",
            TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::BlockchainOnrampTransferInstruction>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAmount = 10000;
        string expectedDestinationBlockchainAddress = "0x304a554a310C7e546dfe434669C62820b7D83490";
        string expectedTransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(
            expectedDestinationBlockchainAddress,
            deserialized.DestinationBlockchainAddress
        );
        Assert.Equal(expectedTransferID, deserialized.TransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::BlockchainOnrampTransferInstruction
        {
            Amount = 10000,
            DestinationBlockchainAddress = "0x304a554a310C7e546dfe434669C62820b7D83490",
            TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::BlockchainOnrampTransferInstruction
        {
            Amount = 10000,
            DestinationBlockchainAddress = "0x304a554a310C7e546dfe434669C62820b7D83490",
            TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
        };

        PendingTransactions::BlockchainOnrampTransferInstruction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::CardAuthorization
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
                    PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Manual,
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
            SchemeFees =
            [
                new()
                {
                    Amount = "0.137465",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                    FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                    FixedComponent = null,
                    VariableRate = "0.0002",
                },
            ],
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
        };

        string expectedID = "card_authorization_6iqxap6ivd0fo5eu3i8x";
        ApiEnum<string, PendingTransactions::Actioner> expectedActioner =
            PendingTransactions::Actioner.Increase;
        PendingTransactions::AdditionalAmounts expectedAdditionalAmounts = new()
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
        long expectedAmount = 100;
        string expectedCardPaymentID = "card_payment_nd3k2kacrqjli8482ave";
        ApiEnum<string, PendingTransactions::CardAuthorizationCurrency> expectedCurrency =
            PendingTransactions::CardAuthorizationCurrency.Usd;
        ApiEnum<string, PendingTransactions::Direction> expectedDirection =
            PendingTransactions::Direction.Settlement;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedMerchantAcceptorID = "5665270011000168";
        string expectedMerchantCategoryCode = "5734";
        string expectedMerchantCity = "New York";
        string expectedMerchantCountry = "US";
        string expectedMerchantDescriptor = "AMAZON.COM";
        string expectedMerchantPostalCode = "10045";
        string expectedMerchantState = "NY";
        PendingTransactions::NetworkDetails expectedNetworkDetails = new()
        {
            Category = PendingTransactions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    PendingTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Manual,
                StandInProcessingReason = null,
                TerminalEntryCapability =
                    PendingTransactions::TerminalEntryCapability.MagneticStripe,
            },
        };
        PendingTransactions::NetworkIdentifiers expectedNetworkIdentifiers = new()
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };
        long expectedNetworkRiskScore = 10;
        long expectedPresentmentAmount = 100;
        string expectedPresentmentCurrency = "USD";
        ApiEnum<string, PendingTransactions::ProcessingCategory> expectedProcessingCategory =
            PendingTransactions::ProcessingCategory.Purchase;
        List<PendingTransactions::SchemeFee> expectedSchemeFees =
        [
            new()
            {
                Amount = "0.137465",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                FixedComponent = null,
                VariableRate = "0.0002",
            },
        ];
        string expectedTerminalID = "RCN5VNXS";
        ApiEnum<string, PendingTransactions::Type> expectedType =
            PendingTransactions::Type.CardAuthorization;
        PendingTransactions::Verification expectedVerification = new()
        {
            CardVerificationCode = new(PendingTransactions::Result.Match),
            CardholderAddress = new()
            {
                ActualLine1 = "33 Liberty Street",
                ActualPostalCode = "94131",
                ProvidedLine1 = "33 Liberty Street",
                ProvidedPostalCode = "94132",
                Result = PendingTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
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
        Assert.Null(model.DigitalWalletTokenID);
        Assert.Equal(expectedDirection, model.Direction);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedMerchantAcceptorID, model.MerchantAcceptorID);
        Assert.Equal(expectedMerchantCategoryCode, model.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCity, model.MerchantCity);
        Assert.Equal(expectedMerchantCountry, model.MerchantCountry);
        Assert.Equal(expectedMerchantDescriptor, model.MerchantDescriptor);
        Assert.Equal(expectedMerchantPostalCode, model.MerchantPostalCode);
        Assert.Equal(expectedMerchantState, model.MerchantState);
        Assert.Equal(expectedNetworkDetails, model.NetworkDetails);
        Assert.Equal(expectedNetworkIdentifiers, model.NetworkIdentifiers);
        Assert.Equal(expectedNetworkRiskScore, model.NetworkRiskScore);
        Assert.Null(model.PendingTransactionID);
        Assert.Null(model.PhysicalCardID);
        Assert.Equal(expectedPresentmentAmount, model.PresentmentAmount);
        Assert.Equal(expectedPresentmentCurrency, model.PresentmentCurrency);
        Assert.Equal(expectedProcessingCategory, model.ProcessingCategory);
        Assert.Null(model.RealTimeDecisionID);
        Assert.Equal(expectedSchemeFees.Count, model.SchemeFees.Count);
        for (int i = 0; i < expectedSchemeFees.Count; i++)
        {
            Assert.Equal(expectedSchemeFees[i], model.SchemeFees[i]);
        }
        Assert.Equal(expectedTerminalID, model.TerminalID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVerification, model.Verification);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::CardAuthorization
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
                    PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Manual,
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
            SchemeFees =
            [
                new()
                {
                    Amount = "0.137465",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                    FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                    FixedComponent = null,
                    VariableRate = "0.0002",
                },
            ],
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::CardAuthorization>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::CardAuthorization
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
                    PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Manual,
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
            SchemeFees =
            [
                new()
                {
                    Amount = "0.137465",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                    FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                    FixedComponent = null,
                    VariableRate = "0.0002",
                },
            ],
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::CardAuthorization>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "card_authorization_6iqxap6ivd0fo5eu3i8x";
        ApiEnum<string, PendingTransactions::Actioner> expectedActioner =
            PendingTransactions::Actioner.Increase;
        PendingTransactions::AdditionalAmounts expectedAdditionalAmounts = new()
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
        long expectedAmount = 100;
        string expectedCardPaymentID = "card_payment_nd3k2kacrqjli8482ave";
        ApiEnum<string, PendingTransactions::CardAuthorizationCurrency> expectedCurrency =
            PendingTransactions::CardAuthorizationCurrency.Usd;
        ApiEnum<string, PendingTransactions::Direction> expectedDirection =
            PendingTransactions::Direction.Settlement;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedMerchantAcceptorID = "5665270011000168";
        string expectedMerchantCategoryCode = "5734";
        string expectedMerchantCity = "New York";
        string expectedMerchantCountry = "US";
        string expectedMerchantDescriptor = "AMAZON.COM";
        string expectedMerchantPostalCode = "10045";
        string expectedMerchantState = "NY";
        PendingTransactions::NetworkDetails expectedNetworkDetails = new()
        {
            Category = PendingTransactions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    PendingTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Manual,
                StandInProcessingReason = null,
                TerminalEntryCapability =
                    PendingTransactions::TerminalEntryCapability.MagneticStripe,
            },
        };
        PendingTransactions::NetworkIdentifiers expectedNetworkIdentifiers = new()
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };
        long expectedNetworkRiskScore = 10;
        long expectedPresentmentAmount = 100;
        string expectedPresentmentCurrency = "USD";
        ApiEnum<string, PendingTransactions::ProcessingCategory> expectedProcessingCategory =
            PendingTransactions::ProcessingCategory.Purchase;
        List<PendingTransactions::SchemeFee> expectedSchemeFees =
        [
            new()
            {
                Amount = "0.137465",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                FixedComponent = null,
                VariableRate = "0.0002",
            },
        ];
        string expectedTerminalID = "RCN5VNXS";
        ApiEnum<string, PendingTransactions::Type> expectedType =
            PendingTransactions::Type.CardAuthorization;
        PendingTransactions::Verification expectedVerification = new()
        {
            CardVerificationCode = new(PendingTransactions::Result.Match),
            CardholderAddress = new()
            {
                ActualLine1 = "33 Liberty Street",
                ActualPostalCode = "94131",
                ProvidedLine1 = "33 Liberty Street",
                ProvidedPostalCode = "94132",
                Result = PendingTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
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
        Assert.Null(deserialized.DigitalWalletTokenID);
        Assert.Equal(expectedDirection, deserialized.Direction);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedMerchantAcceptorID, deserialized.MerchantAcceptorID);
        Assert.Equal(expectedMerchantCategoryCode, deserialized.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCity, deserialized.MerchantCity);
        Assert.Equal(expectedMerchantCountry, deserialized.MerchantCountry);
        Assert.Equal(expectedMerchantDescriptor, deserialized.MerchantDescriptor);
        Assert.Equal(expectedMerchantPostalCode, deserialized.MerchantPostalCode);
        Assert.Equal(expectedMerchantState, deserialized.MerchantState);
        Assert.Equal(expectedNetworkDetails, deserialized.NetworkDetails);
        Assert.Equal(expectedNetworkIdentifiers, deserialized.NetworkIdentifiers);
        Assert.Equal(expectedNetworkRiskScore, deserialized.NetworkRiskScore);
        Assert.Null(deserialized.PendingTransactionID);
        Assert.Null(deserialized.PhysicalCardID);
        Assert.Equal(expectedPresentmentAmount, deserialized.PresentmentAmount);
        Assert.Equal(expectedPresentmentCurrency, deserialized.PresentmentCurrency);
        Assert.Equal(expectedProcessingCategory, deserialized.ProcessingCategory);
        Assert.Null(deserialized.RealTimeDecisionID);
        Assert.Equal(expectedSchemeFees.Count, deserialized.SchemeFees.Count);
        for (int i = 0; i < expectedSchemeFees.Count; i++)
        {
            Assert.Equal(expectedSchemeFees[i], deserialized.SchemeFees[i]);
        }
        Assert.Equal(expectedTerminalID, deserialized.TerminalID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVerification, deserialized.Verification);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::CardAuthorization
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
                    PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Manual,
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
            SchemeFees =
            [
                new()
                {
                    Amount = "0.137465",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                    FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                    FixedComponent = null,
                    VariableRate = "0.0002",
                },
            ],
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::CardAuthorization
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
                    PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Manual,
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
            SchemeFees =
            [
                new()
                {
                    Amount = "0.137465",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = PendingTransactions::SchemeFeeCurrency.Usd,
                    FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
                    FixedComponent = null,
                    VariableRate = "0.0002",
                },
            ],
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
        };

        PendingTransactions::CardAuthorization copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActionerTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::Actioner.User)]
    [InlineData(PendingTransactions::Actioner.Increase)]
    [InlineData(PendingTransactions::Actioner.Network)]
    public void Validation_Works(PendingTransactions::Actioner rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::Actioner> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::Actioner>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::Actioner.User)]
    [InlineData(PendingTransactions::Actioner.Increase)]
    [InlineData(PendingTransactions::Actioner.Network)]
    public void SerializationRoundtrip_Works(PendingTransactions::Actioner rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::Actioner> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::Actioner>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::Actioner>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::Actioner>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AdditionalAmountsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::AdditionalAmounts
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

        PendingTransactions::Clinic expectedClinic = new() { Amount = 0, Currency = "currency" };
        PendingTransactions::Dental expectedDental = new() { Amount = 0, Currency = "currency" };
        PendingTransactions::Original expectedOriginal = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        PendingTransactions::Prescription expectedPrescription = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        PendingTransactions::Surcharge expectedSurcharge = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        PendingTransactions::TotalCumulative expectedTotalCumulative = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        PendingTransactions::TotalHealthcare expectedTotalHealthcare = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        PendingTransactions::Transit expectedTransit = new() { Amount = 0, Currency = "currency" };
        PendingTransactions::Unknown expectedUnknown = new() { Amount = 0, Currency = "currency" };
        PendingTransactions::Vision expectedVision = new() { Amount = 0, Currency = "currency" };

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
        var model = new PendingTransactions::AdditionalAmounts
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
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::AdditionalAmounts>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::AdditionalAmounts
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
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::AdditionalAmounts>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PendingTransactions::Clinic expectedClinic = new() { Amount = 0, Currency = "currency" };
        PendingTransactions::Dental expectedDental = new() { Amount = 0, Currency = "currency" };
        PendingTransactions::Original expectedOriginal = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        PendingTransactions::Prescription expectedPrescription = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        PendingTransactions::Surcharge expectedSurcharge = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        PendingTransactions::TotalCumulative expectedTotalCumulative = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        PendingTransactions::TotalHealthcare expectedTotalHealthcare = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        PendingTransactions::Transit expectedTransit = new() { Amount = 0, Currency = "currency" };
        PendingTransactions::Unknown expectedUnknown = new() { Amount = 0, Currency = "currency" };
        PendingTransactions::Vision expectedVision = new() { Amount = 0, Currency = "currency" };

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
        var model = new PendingTransactions::AdditionalAmounts
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
        var model = new PendingTransactions::AdditionalAmounts
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

        PendingTransactions::AdditionalAmounts copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ClinicTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::Clinic { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::Clinic { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Clinic>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::Clinic { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Clinic>(
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
        var model = new PendingTransactions::Clinic { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::Clinic { Amount = 0, Currency = "currency" };

        PendingTransactions::Clinic copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DentalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::Dental { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::Dental { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Dental>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::Dental { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Dental>(
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
        var model = new PendingTransactions::Dental { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::Dental { Amount = 0, Currency = "currency" };

        PendingTransactions::Dental copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::Original { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::Original { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Original>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::Original { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Original>(
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
        var model = new PendingTransactions::Original { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::Original { Amount = 0, Currency = "currency" };

        PendingTransactions::Original copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PrescriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::Prescription { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::Prescription { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Prescription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::Prescription { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Prescription>(
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
        var model = new PendingTransactions::Prescription { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::Prescription { Amount = 0, Currency = "currency" };

        PendingTransactions::Prescription copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SurchargeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::Surcharge { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::Surcharge { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Surcharge>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::Surcharge { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Surcharge>(
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
        var model = new PendingTransactions::Surcharge { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::Surcharge { Amount = 0, Currency = "currency" };

        PendingTransactions::Surcharge copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TotalCumulativeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::TotalCumulative { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::TotalCumulative { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::TotalCumulative>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::TotalCumulative { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::TotalCumulative>(
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
        var model = new PendingTransactions::TotalCumulative { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::TotalCumulative { Amount = 0, Currency = "currency" };

        PendingTransactions::TotalCumulative copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TotalHealthcareTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::TotalHealthcare { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::TotalHealthcare { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::TotalHealthcare>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::TotalHealthcare { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::TotalHealthcare>(
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
        var model = new PendingTransactions::TotalHealthcare { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::TotalHealthcare { Amount = 0, Currency = "currency" };

        PendingTransactions::TotalHealthcare copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TransitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::Transit { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::Transit { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Transit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::Transit { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Transit>(
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
        var model = new PendingTransactions::Transit { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::Transit { Amount = 0, Currency = "currency" };

        PendingTransactions::Transit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnknownTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::Unknown { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::Unknown { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Unknown>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::Unknown { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Unknown>(
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
        var model = new PendingTransactions::Unknown { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::Unknown { Amount = 0, Currency = "currency" };

        PendingTransactions::Unknown copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VisionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::Vision { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::Vision { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Vision>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::Vision { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Vision>(
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
        var model = new PendingTransactions::Vision { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::Vision { Amount = 0, Currency = "currency" };

        PendingTransactions::Vision copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::CardAuthorizationCurrency.Usd)]
    public void Validation_Works(PendingTransactions::CardAuthorizationCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::CardAuthorizationCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::CardAuthorizationCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::CardAuthorizationCurrency.Usd)]
    public void SerializationRoundtrip_Works(
        PendingTransactions::CardAuthorizationCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::CardAuthorizationCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::CardAuthorizationCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::CardAuthorizationCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::CardAuthorizationCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DirectionTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::Direction.Settlement)]
    [InlineData(PendingTransactions::Direction.Refund)]
    public void Validation_Works(PendingTransactions::Direction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::Direction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::Direction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::Direction.Settlement)]
    [InlineData(PendingTransactions::Direction.Refund)]
    public void SerializationRoundtrip_Works(PendingTransactions::Direction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::Direction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::Direction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::Direction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::Direction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NetworkDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::NetworkDetails
        {
            Category = PendingTransactions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    PendingTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = PendingTransactions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = PendingTransactions::TerminalEntryCapability.Unknown,
            },
        };

        ApiEnum<string, PendingTransactions::NetworkDetailsCategory> expectedCategory =
            PendingTransactions::NetworkDetailsCategory.Visa;
        PendingTransactions::Pulse expectedPulse = new();
        PendingTransactions::Visa expectedVisa = new()
        {
            ElectronicCommerceIndicator =
                PendingTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = PendingTransactions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = PendingTransactions::TerminalEntryCapability.Unknown,
        };

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedPulse, model.Pulse);
        Assert.Equal(expectedVisa, model.Visa);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::NetworkDetails
        {
            Category = PendingTransactions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    PendingTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = PendingTransactions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = PendingTransactions::TerminalEntryCapability.Unknown,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::NetworkDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::NetworkDetails
        {
            Category = PendingTransactions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    PendingTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = PendingTransactions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = PendingTransactions::TerminalEntryCapability.Unknown,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::NetworkDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PendingTransactions::NetworkDetailsCategory> expectedCategory =
            PendingTransactions::NetworkDetailsCategory.Visa;
        PendingTransactions::Pulse expectedPulse = new();
        PendingTransactions::Visa expectedVisa = new()
        {
            ElectronicCommerceIndicator =
                PendingTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = PendingTransactions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = PendingTransactions::TerminalEntryCapability.Unknown,
        };

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedPulse, deserialized.Pulse);
        Assert.Equal(expectedVisa, deserialized.Visa);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::NetworkDetails
        {
            Category = PendingTransactions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    PendingTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = PendingTransactions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = PendingTransactions::TerminalEntryCapability.Unknown,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::NetworkDetails
        {
            Category = PendingTransactions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    PendingTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = PendingTransactions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = PendingTransactions::TerminalEntryCapability.Unknown,
            },
        };

        PendingTransactions::NetworkDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NetworkDetailsCategoryTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::NetworkDetailsCategory.Visa)]
    [InlineData(PendingTransactions::NetworkDetailsCategory.Pulse)]
    public void Validation_Works(PendingTransactions::NetworkDetailsCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::NetworkDetailsCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::NetworkDetailsCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::NetworkDetailsCategory.Visa)]
    [InlineData(PendingTransactions::NetworkDetailsCategory.Pulse)]
    public void SerializationRoundtrip_Works(PendingTransactions::NetworkDetailsCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::NetworkDetailsCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::NetworkDetailsCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::NetworkDetailsCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::NetworkDetailsCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PulseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::Pulse { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::Pulse { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Pulse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::Pulse { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Pulse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::Pulse { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::Pulse { };

        PendingTransactions::Pulse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VisaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::Visa
        {
            ElectronicCommerceIndicator =
                PendingTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = PendingTransactions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = PendingTransactions::TerminalEntryCapability.Unknown,
        };

        ApiEnum<
            string,
            PendingTransactions::ElectronicCommerceIndicator
        > expectedElectronicCommerceIndicator =
            PendingTransactions::ElectronicCommerceIndicator.MailPhoneOrder;
        ApiEnum<
            string,
            PendingTransactions::PointOfServiceEntryMode
        > expectedPointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Unknown;
        ApiEnum<
            string,
            PendingTransactions::StandInProcessingReason
        > expectedStandInProcessingReason =
            PendingTransactions::StandInProcessingReason.IssuerError;
        ApiEnum<
            string,
            PendingTransactions::TerminalEntryCapability
        > expectedTerminalEntryCapability = PendingTransactions::TerminalEntryCapability.Unknown;

        Assert.Equal(expectedElectronicCommerceIndicator, model.ElectronicCommerceIndicator);
        Assert.Equal(expectedPointOfServiceEntryMode, model.PointOfServiceEntryMode);
        Assert.Equal(expectedStandInProcessingReason, model.StandInProcessingReason);
        Assert.Equal(expectedTerminalEntryCapability, model.TerminalEntryCapability);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::Visa
        {
            ElectronicCommerceIndicator =
                PendingTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = PendingTransactions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = PendingTransactions::TerminalEntryCapability.Unknown,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Visa>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::Visa
        {
            ElectronicCommerceIndicator =
                PendingTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = PendingTransactions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = PendingTransactions::TerminalEntryCapability.Unknown,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Visa>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            PendingTransactions::ElectronicCommerceIndicator
        > expectedElectronicCommerceIndicator =
            PendingTransactions::ElectronicCommerceIndicator.MailPhoneOrder;
        ApiEnum<
            string,
            PendingTransactions::PointOfServiceEntryMode
        > expectedPointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Unknown;
        ApiEnum<
            string,
            PendingTransactions::StandInProcessingReason
        > expectedStandInProcessingReason =
            PendingTransactions::StandInProcessingReason.IssuerError;
        ApiEnum<
            string,
            PendingTransactions::TerminalEntryCapability
        > expectedTerminalEntryCapability = PendingTransactions::TerminalEntryCapability.Unknown;

        Assert.Equal(expectedElectronicCommerceIndicator, deserialized.ElectronicCommerceIndicator);
        Assert.Equal(expectedPointOfServiceEntryMode, deserialized.PointOfServiceEntryMode);
        Assert.Equal(expectedStandInProcessingReason, deserialized.StandInProcessingReason);
        Assert.Equal(expectedTerminalEntryCapability, deserialized.TerminalEntryCapability);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::Visa
        {
            ElectronicCommerceIndicator =
                PendingTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = PendingTransactions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = PendingTransactions::TerminalEntryCapability.Unknown,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::Visa
        {
            ElectronicCommerceIndicator =
                PendingTransactions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = PendingTransactions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = PendingTransactions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = PendingTransactions::TerminalEntryCapability.Unknown,
        };

        PendingTransactions::Visa copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ElectronicCommerceIndicatorTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::ElectronicCommerceIndicator.MailPhoneOrder)]
    [InlineData(PendingTransactions::ElectronicCommerceIndicator.Recurring)]
    [InlineData(PendingTransactions::ElectronicCommerceIndicator.Installment)]
    [InlineData(PendingTransactions::ElectronicCommerceIndicator.UnknownMailPhoneOrder)]
    [InlineData(PendingTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce)]
    [InlineData(
        PendingTransactions::ElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant
    )]
    [InlineData(
        PendingTransactions::ElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction
    )]
    [InlineData(PendingTransactions::ElectronicCommerceIndicator.NonSecureTransaction)]
    public void Validation_Works(PendingTransactions::ElectronicCommerceIndicator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::ElectronicCommerceIndicator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::ElectronicCommerceIndicator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::ElectronicCommerceIndicator.MailPhoneOrder)]
    [InlineData(PendingTransactions::ElectronicCommerceIndicator.Recurring)]
    [InlineData(PendingTransactions::ElectronicCommerceIndicator.Installment)]
    [InlineData(PendingTransactions::ElectronicCommerceIndicator.UnknownMailPhoneOrder)]
    [InlineData(PendingTransactions::ElectronicCommerceIndicator.SecureElectronicCommerce)]
    [InlineData(
        PendingTransactions::ElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant
    )]
    [InlineData(
        PendingTransactions::ElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction
    )]
    [InlineData(PendingTransactions::ElectronicCommerceIndicator.NonSecureTransaction)]
    public void SerializationRoundtrip_Works(
        PendingTransactions::ElectronicCommerceIndicator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::ElectronicCommerceIndicator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::ElectronicCommerceIndicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::ElectronicCommerceIndicator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::ElectronicCommerceIndicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PointOfServiceEntryModeTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.Unknown)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.Manual)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.MagneticStripeNoCvv)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.OpticalCode)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.IntegratedCircuitCard)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.Contactless)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.CredentialOnFile)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.MagneticStripe)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.ContactlessMagneticStripe)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.IntegratedCircuitCardNoCvv)]
    public void Validation_Works(PendingTransactions::PointOfServiceEntryMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::PointOfServiceEntryMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::PointOfServiceEntryMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.Unknown)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.Manual)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.MagneticStripeNoCvv)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.OpticalCode)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.IntegratedCircuitCard)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.Contactless)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.CredentialOnFile)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.MagneticStripe)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.ContactlessMagneticStripe)]
    [InlineData(PendingTransactions::PointOfServiceEntryMode.IntegratedCircuitCardNoCvv)]
    public void SerializationRoundtrip_Works(PendingTransactions::PointOfServiceEntryMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::PointOfServiceEntryMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::PointOfServiceEntryMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::PointOfServiceEntryMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::PointOfServiceEntryMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StandInProcessingReasonTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::StandInProcessingReason.IssuerError)]
    [InlineData(PendingTransactions::StandInProcessingReason.InvalidPhysicalCard)]
    [InlineData(PendingTransactions::StandInProcessingReason.InvalidCryptogram)]
    [InlineData(
        PendingTransactions::StandInProcessingReason.InvalidCardholderAuthenticationVerificationValue
    )]
    [InlineData(PendingTransactions::StandInProcessingReason.InternalVisaError)]
    [InlineData(
        PendingTransactions::StandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired
    )]
    [InlineData(PendingTransactions::StandInProcessingReason.PaymentFraudDisruptionAcquirerBlock)]
    [InlineData(PendingTransactions::StandInProcessingReason.Other)]
    public void Validation_Works(PendingTransactions::StandInProcessingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::StandInProcessingReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::StandInProcessingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::StandInProcessingReason.IssuerError)]
    [InlineData(PendingTransactions::StandInProcessingReason.InvalidPhysicalCard)]
    [InlineData(PendingTransactions::StandInProcessingReason.InvalidCryptogram)]
    [InlineData(
        PendingTransactions::StandInProcessingReason.InvalidCardholderAuthenticationVerificationValue
    )]
    [InlineData(PendingTransactions::StandInProcessingReason.InternalVisaError)]
    [InlineData(
        PendingTransactions::StandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired
    )]
    [InlineData(PendingTransactions::StandInProcessingReason.PaymentFraudDisruptionAcquirerBlock)]
    [InlineData(PendingTransactions::StandInProcessingReason.Other)]
    public void SerializationRoundtrip_Works(PendingTransactions::StandInProcessingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::StandInProcessingReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::StandInProcessingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::StandInProcessingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::StandInProcessingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TerminalEntryCapabilityTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::TerminalEntryCapability.Unknown)]
    [InlineData(PendingTransactions::TerminalEntryCapability.TerminalNotUsed)]
    [InlineData(PendingTransactions::TerminalEntryCapability.MagneticStripe)]
    [InlineData(PendingTransactions::TerminalEntryCapability.Barcode)]
    [InlineData(PendingTransactions::TerminalEntryCapability.OpticalCharacterRecognition)]
    [InlineData(PendingTransactions::TerminalEntryCapability.ChipOrContactless)]
    [InlineData(PendingTransactions::TerminalEntryCapability.ContactlessOnly)]
    [InlineData(PendingTransactions::TerminalEntryCapability.NoCapability)]
    public void Validation_Works(PendingTransactions::TerminalEntryCapability rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::TerminalEntryCapability> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::TerminalEntryCapability>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::TerminalEntryCapability.Unknown)]
    [InlineData(PendingTransactions::TerminalEntryCapability.TerminalNotUsed)]
    [InlineData(PendingTransactions::TerminalEntryCapability.MagneticStripe)]
    [InlineData(PendingTransactions::TerminalEntryCapability.Barcode)]
    [InlineData(PendingTransactions::TerminalEntryCapability.OpticalCharacterRecognition)]
    [InlineData(PendingTransactions::TerminalEntryCapability.ChipOrContactless)]
    [InlineData(PendingTransactions::TerminalEntryCapability.ContactlessOnly)]
    [InlineData(PendingTransactions::TerminalEntryCapability.NoCapability)]
    public void SerializationRoundtrip_Works(PendingTransactions::TerminalEntryCapability rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::TerminalEntryCapability> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::TerminalEntryCapability>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::TerminalEntryCapability>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::TerminalEntryCapability>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NetworkIdentifiersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::NetworkIdentifiers
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
        var model = new PendingTransactions::NetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::NetworkIdentifiers>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::NetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::NetworkIdentifiers>(
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
        var model = new PendingTransactions::NetworkIdentifiers
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
        var model = new PendingTransactions::NetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        PendingTransactions::NetworkIdentifiers copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProcessingCategoryTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::ProcessingCategory.AccountFunding)]
    [InlineData(PendingTransactions::ProcessingCategory.AutomaticFuelDispenser)]
    [InlineData(PendingTransactions::ProcessingCategory.BillPayment)]
    [InlineData(PendingTransactions::ProcessingCategory.OriginalCredit)]
    [InlineData(PendingTransactions::ProcessingCategory.Purchase)]
    [InlineData(PendingTransactions::ProcessingCategory.QuasiCash)]
    [InlineData(PendingTransactions::ProcessingCategory.Refund)]
    [InlineData(PendingTransactions::ProcessingCategory.CashDisbursement)]
    [InlineData(PendingTransactions::ProcessingCategory.BalanceInquiry)]
    [InlineData(PendingTransactions::ProcessingCategory.Unknown)]
    public void Validation_Works(PendingTransactions::ProcessingCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::ProcessingCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::ProcessingCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::ProcessingCategory.AccountFunding)]
    [InlineData(PendingTransactions::ProcessingCategory.AutomaticFuelDispenser)]
    [InlineData(PendingTransactions::ProcessingCategory.BillPayment)]
    [InlineData(PendingTransactions::ProcessingCategory.OriginalCredit)]
    [InlineData(PendingTransactions::ProcessingCategory.Purchase)]
    [InlineData(PendingTransactions::ProcessingCategory.QuasiCash)]
    [InlineData(PendingTransactions::ProcessingCategory.Refund)]
    [InlineData(PendingTransactions::ProcessingCategory.CashDisbursement)]
    [InlineData(PendingTransactions::ProcessingCategory.BalanceInquiry)]
    [InlineData(PendingTransactions::ProcessingCategory.Unknown)]
    public void SerializationRoundtrip_Works(PendingTransactions::ProcessingCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::ProcessingCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::ProcessingCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::ProcessingCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::ProcessingCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SchemeFeeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::SchemeFee
        {
            Amount = "0.137465",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = PendingTransactions::SchemeFeeCurrency.Usd,
            FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
            FixedComponent = null,
            VariableRate = "0.0002",
        };

        string expectedAmount = "0.137465";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, PendingTransactions::SchemeFeeCurrency> expectedCurrency =
            PendingTransactions::SchemeFeeCurrency.Usd;
        ApiEnum<string, PendingTransactions::FeeType> expectedFeeType =
            PendingTransactions::FeeType.VisaCorporateAcceptanceFee;
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
        var model = new PendingTransactions::SchemeFee
        {
            Amount = "0.137465",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = PendingTransactions::SchemeFeeCurrency.Usd,
            FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
            FixedComponent = null,
            VariableRate = "0.0002",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::SchemeFee>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::SchemeFee
        {
            Amount = "0.137465",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = PendingTransactions::SchemeFeeCurrency.Usd,
            FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
            FixedComponent = null,
            VariableRate = "0.0002",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::SchemeFee>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmount = "0.137465";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, PendingTransactions::SchemeFeeCurrency> expectedCurrency =
            PendingTransactions::SchemeFeeCurrency.Usd;
        ApiEnum<string, PendingTransactions::FeeType> expectedFeeType =
            PendingTransactions::FeeType.VisaCorporateAcceptanceFee;
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
        var model = new PendingTransactions::SchemeFee
        {
            Amount = "0.137465",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = PendingTransactions::SchemeFeeCurrency.Usd,
            FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
            FixedComponent = null,
            VariableRate = "0.0002",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::SchemeFee
        {
            Amount = "0.137465",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = PendingTransactions::SchemeFeeCurrency.Usd,
            FeeType = PendingTransactions::FeeType.VisaCorporateAcceptanceFee,
            FixedComponent = null,
            VariableRate = "0.0002",
        };

        PendingTransactions::SchemeFee copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SchemeFeeCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::SchemeFeeCurrency.Usd)]
    public void Validation_Works(PendingTransactions::SchemeFeeCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::SchemeFeeCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::SchemeFeeCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::SchemeFeeCurrency.Usd)]
    public void SerializationRoundtrip_Works(PendingTransactions::SchemeFeeCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::SchemeFeeCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::SchemeFeeCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::SchemeFeeCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::SchemeFeeCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeeTypeTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::FeeType.VisaInternationalServiceAssessmentSingleCurrency)]
    [InlineData(PendingTransactions::FeeType.VisaInternationalServiceAssessmentCrossCurrency)]
    [InlineData(PendingTransactions::FeeType.VisaAuthorizationDomesticPointOfSale)]
    [InlineData(PendingTransactions::FeeType.VisaAuthorizationInternationalPointOfSale)]
    [InlineData(PendingTransactions::FeeType.VisaAuthorizationCanadaPointOfSale)]
    [InlineData(PendingTransactions::FeeType.VisaAuthorizationReversalPointOfSale)]
    [InlineData(PendingTransactions::FeeType.VisaAuthorizationReversalInternationalPointOfSale)]
    [InlineData(PendingTransactions::FeeType.VisaAuthorizationAddressVerificationService)]
    [InlineData(PendingTransactions::FeeType.VisaAdvancedAuthorization)]
    [InlineData(PendingTransactions::FeeType.VisaMessageTransmission)]
    [InlineData(PendingTransactions::FeeType.VisaAccountVerificationDomestic)]
    [InlineData(PendingTransactions::FeeType.VisaAccountVerificationInternational)]
    [InlineData(PendingTransactions::FeeType.VisaAccountVerificationCanada)]
    [InlineData(PendingTransactions::FeeType.VisaCorporateAcceptanceFee)]
    [InlineData(PendingTransactions::FeeType.VisaConsumerDebitAcceptanceFee)]
    [InlineData(PendingTransactions::FeeType.VisaBusinessDebitAcceptanceFee)]
    [InlineData(PendingTransactions::FeeType.VisaPurchasingAcceptanceFee)]
    [InlineData(PendingTransactions::FeeType.VisaPurchaseDomestic)]
    [InlineData(PendingTransactions::FeeType.VisaPurchaseInternational)]
    [InlineData(PendingTransactions::FeeType.VisaCreditPurchaseToken)]
    [InlineData(PendingTransactions::FeeType.VisaDebitPurchaseToken)]
    [InlineData(PendingTransactions::FeeType.VisaClearingTransmission)]
    [InlineData(PendingTransactions::FeeType.VisaDirectAuthorization)]
    [InlineData(PendingTransactions::FeeType.VisaDirectTransactionDomestic)]
    [InlineData(PendingTransactions::FeeType.VisaServiceCommercialCredit)]
    [InlineData(PendingTransactions::FeeType.VisaAdvertisingServiceCommercialCredit)]
    [InlineData(PendingTransactions::FeeType.VisaCommunityGrowthAccelerationProgram)]
    [InlineData(PendingTransactions::FeeType.VisaProcessingGuaranteeCommercialCredit)]
    [InlineData(PendingTransactions::FeeType.PulseSwitchFee)]
    public void Validation_Works(PendingTransactions::FeeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::FeeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::FeeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::FeeType.VisaInternationalServiceAssessmentSingleCurrency)]
    [InlineData(PendingTransactions::FeeType.VisaInternationalServiceAssessmentCrossCurrency)]
    [InlineData(PendingTransactions::FeeType.VisaAuthorizationDomesticPointOfSale)]
    [InlineData(PendingTransactions::FeeType.VisaAuthorizationInternationalPointOfSale)]
    [InlineData(PendingTransactions::FeeType.VisaAuthorizationCanadaPointOfSale)]
    [InlineData(PendingTransactions::FeeType.VisaAuthorizationReversalPointOfSale)]
    [InlineData(PendingTransactions::FeeType.VisaAuthorizationReversalInternationalPointOfSale)]
    [InlineData(PendingTransactions::FeeType.VisaAuthorizationAddressVerificationService)]
    [InlineData(PendingTransactions::FeeType.VisaAdvancedAuthorization)]
    [InlineData(PendingTransactions::FeeType.VisaMessageTransmission)]
    [InlineData(PendingTransactions::FeeType.VisaAccountVerificationDomestic)]
    [InlineData(PendingTransactions::FeeType.VisaAccountVerificationInternational)]
    [InlineData(PendingTransactions::FeeType.VisaAccountVerificationCanada)]
    [InlineData(PendingTransactions::FeeType.VisaCorporateAcceptanceFee)]
    [InlineData(PendingTransactions::FeeType.VisaConsumerDebitAcceptanceFee)]
    [InlineData(PendingTransactions::FeeType.VisaBusinessDebitAcceptanceFee)]
    [InlineData(PendingTransactions::FeeType.VisaPurchasingAcceptanceFee)]
    [InlineData(PendingTransactions::FeeType.VisaPurchaseDomestic)]
    [InlineData(PendingTransactions::FeeType.VisaPurchaseInternational)]
    [InlineData(PendingTransactions::FeeType.VisaCreditPurchaseToken)]
    [InlineData(PendingTransactions::FeeType.VisaDebitPurchaseToken)]
    [InlineData(PendingTransactions::FeeType.VisaClearingTransmission)]
    [InlineData(PendingTransactions::FeeType.VisaDirectAuthorization)]
    [InlineData(PendingTransactions::FeeType.VisaDirectTransactionDomestic)]
    [InlineData(PendingTransactions::FeeType.VisaServiceCommercialCredit)]
    [InlineData(PendingTransactions::FeeType.VisaAdvertisingServiceCommercialCredit)]
    [InlineData(PendingTransactions::FeeType.VisaCommunityGrowthAccelerationProgram)]
    [InlineData(PendingTransactions::FeeType.VisaProcessingGuaranteeCommercialCredit)]
    [InlineData(PendingTransactions::FeeType.PulseSwitchFee)]
    public void SerializationRoundtrip_Works(PendingTransactions::FeeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::FeeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::FeeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::FeeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::FeeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::Type.CardAuthorization)]
    public void Validation_Works(PendingTransactions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::Type.CardAuthorization)]
    public void SerializationRoundtrip_Works(PendingTransactions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VerificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::Verification
        {
            CardVerificationCode = new(PendingTransactions::Result.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = PendingTransactions::CardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        PendingTransactions::CardVerificationCode expectedCardVerificationCode = new(
            PendingTransactions::Result.NotChecked
        );
        PendingTransactions::CardholderAddress expectedCardholderAddress = new()
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = PendingTransactions::CardholderAddressResult.NotChecked,
        };
        PendingTransactions::CardholderName expectedCardholderName = new()
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
        var model = new PendingTransactions::Verification
        {
            CardVerificationCode = new(PendingTransactions::Result.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = PendingTransactions::CardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Verification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::Verification
        {
            CardVerificationCode = new(PendingTransactions::Result.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = PendingTransactions::CardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Verification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PendingTransactions::CardVerificationCode expectedCardVerificationCode = new(
            PendingTransactions::Result.NotChecked
        );
        PendingTransactions::CardholderAddress expectedCardholderAddress = new()
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = PendingTransactions::CardholderAddressResult.NotChecked,
        };
        PendingTransactions::CardholderName expectedCardholderName = new()
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
        var model = new PendingTransactions::Verification
        {
            CardVerificationCode = new(PendingTransactions::Result.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = PendingTransactions::CardholderAddressResult.NotChecked,
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
        var model = new PendingTransactions::Verification
        {
            CardVerificationCode = new(PendingTransactions::Result.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = PendingTransactions::CardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        PendingTransactions::Verification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardVerificationCodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::CardVerificationCode
        {
            Result = PendingTransactions::Result.NotChecked,
        };

        ApiEnum<string, PendingTransactions::Result> expectedResult =
            PendingTransactions::Result.NotChecked;

        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::CardVerificationCode
        {
            Result = PendingTransactions::Result.NotChecked,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::CardVerificationCode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::CardVerificationCode
        {
            Result = PendingTransactions::Result.NotChecked,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::CardVerificationCode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PendingTransactions::Result> expectedResult =
            PendingTransactions::Result.NotChecked;

        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::CardVerificationCode
        {
            Result = PendingTransactions::Result.NotChecked,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::CardVerificationCode
        {
            Result = PendingTransactions::Result.NotChecked,
        };

        PendingTransactions::CardVerificationCode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::Result.NotChecked)]
    [InlineData(PendingTransactions::Result.Match)]
    [InlineData(PendingTransactions::Result.NoMatch)]
    public void Validation_Works(PendingTransactions::Result rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::Result> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::Result>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::Result.NotChecked)]
    [InlineData(PendingTransactions::Result.Match)]
    [InlineData(PendingTransactions::Result.NoMatch)]
    public void SerializationRoundtrip_Works(PendingTransactions::Result rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::Result> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::Result>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::Result>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PendingTransactions::Result>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CardholderAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = PendingTransactions::CardholderAddressResult.NotChecked,
        };

        string expectedActualLine1 = "actual_line1";
        string expectedActualPostalCode = "actual_postal_code";
        string expectedProvidedLine1 = "provided_line1";
        string expectedProvidedPostalCode = "provided_postal_code";
        ApiEnum<string, PendingTransactions::CardholderAddressResult> expectedResult =
            PendingTransactions::CardholderAddressResult.NotChecked;

        Assert.Equal(expectedActualLine1, model.ActualLine1);
        Assert.Equal(expectedActualPostalCode, model.ActualPostalCode);
        Assert.Equal(expectedProvidedLine1, model.ProvidedLine1);
        Assert.Equal(expectedProvidedPostalCode, model.ProvidedPostalCode);
        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = PendingTransactions::CardholderAddressResult.NotChecked,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::CardholderAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = PendingTransactions::CardholderAddressResult.NotChecked,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::CardholderAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedActualLine1 = "actual_line1";
        string expectedActualPostalCode = "actual_postal_code";
        string expectedProvidedLine1 = "provided_line1";
        string expectedProvidedPostalCode = "provided_postal_code";
        ApiEnum<string, PendingTransactions::CardholderAddressResult> expectedResult =
            PendingTransactions::CardholderAddressResult.NotChecked;

        Assert.Equal(expectedActualLine1, deserialized.ActualLine1);
        Assert.Equal(expectedActualPostalCode, deserialized.ActualPostalCode);
        Assert.Equal(expectedProvidedLine1, deserialized.ProvidedLine1);
        Assert.Equal(expectedProvidedPostalCode, deserialized.ProvidedPostalCode);
        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = PendingTransactions::CardholderAddressResult.NotChecked,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = PendingTransactions::CardholderAddressResult.NotChecked,
        };

        PendingTransactions::CardholderAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardholderAddressResultTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::CardholderAddressResult.NotChecked)]
    [InlineData(PendingTransactions::CardholderAddressResult.PostalCodeMatchAddressNoMatch)]
    [InlineData(PendingTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch)]
    [InlineData(PendingTransactions::CardholderAddressResult.Match)]
    [InlineData(PendingTransactions::CardholderAddressResult.NoMatch)]
    [InlineData(PendingTransactions::CardholderAddressResult.PostalCodeMatchAddressNotChecked)]
    public void Validation_Works(PendingTransactions::CardholderAddressResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::CardholderAddressResult> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::CardholderAddressResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::CardholderAddressResult.NotChecked)]
    [InlineData(PendingTransactions::CardholderAddressResult.PostalCodeMatchAddressNoMatch)]
    [InlineData(PendingTransactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch)]
    [InlineData(PendingTransactions::CardholderAddressResult.Match)]
    [InlineData(PendingTransactions::CardholderAddressResult.NoMatch)]
    [InlineData(PendingTransactions::CardholderAddressResult.PostalCodeMatchAddressNotChecked)]
    public void SerializationRoundtrip_Works(PendingTransactions::CardholderAddressResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::CardholderAddressResult> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::CardholderAddressResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::CardholderAddressResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::CardholderAddressResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardholderNameTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::CardholderName
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
        var model = new PendingTransactions::CardholderName
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::CardholderName>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::CardholderName
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::CardholderName>(
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
        var model = new PendingTransactions::CardholderName
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
        var model = new PendingTransactions::CardholderName
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        PendingTransactions::CardholderName copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardPushTransferInstructionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::CardPushTransferInstruction
        {
            Amount = 100,
            TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
        };

        long expectedAmount = 100;
        string expectedTransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedTransferID, model.TransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::CardPushTransferInstruction
        {
            Amount = 100,
            TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::CardPushTransferInstruction>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::CardPushTransferInstruction
        {
            Amount = 100,
            TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::CardPushTransferInstruction>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAmount = 100;
        string expectedTransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedTransferID, deserialized.TransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::CardPushTransferInstruction
        {
            Amount = 100,
            TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::CardPushTransferInstruction
        {
            Amount = 100,
            TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
        };

        PendingTransactions::CardPushTransferInstruction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckDepositInstructionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::CheckDepositInstruction
        {
            Amount = 100,
            BackImageFileID = "file_26khfk98mzfz90a11oqx",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = PendingTransactions::CheckDepositInstructionCurrency.Usd,
            FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
        };

        long expectedAmount = 100;
        string expectedBackImageFileID = "file_26khfk98mzfz90a11oqx";
        string expectedCheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1";
        ApiEnum<string, PendingTransactions::CheckDepositInstructionCurrency> expectedCurrency =
            PendingTransactions::CheckDepositInstructionCurrency.Usd;
        string expectedFrontImageFileID = "file_makxrc67oh9l6sg7w9yc";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBackImageFileID, model.BackImageFileID);
        Assert.Equal(expectedCheckDepositID, model.CheckDepositID);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedFrontImageFileID, model.FrontImageFileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::CheckDepositInstruction
        {
            Amount = 100,
            BackImageFileID = "file_26khfk98mzfz90a11oqx",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = PendingTransactions::CheckDepositInstructionCurrency.Usd,
            FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::CheckDepositInstruction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::CheckDepositInstruction
        {
            Amount = 100,
            BackImageFileID = "file_26khfk98mzfz90a11oqx",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = PendingTransactions::CheckDepositInstructionCurrency.Usd,
            FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::CheckDepositInstruction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 100;
        string expectedBackImageFileID = "file_26khfk98mzfz90a11oqx";
        string expectedCheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1";
        ApiEnum<string, PendingTransactions::CheckDepositInstructionCurrency> expectedCurrency =
            PendingTransactions::CheckDepositInstructionCurrency.Usd;
        string expectedFrontImageFileID = "file_makxrc67oh9l6sg7w9yc";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBackImageFileID, deserialized.BackImageFileID);
        Assert.Equal(expectedCheckDepositID, deserialized.CheckDepositID);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedFrontImageFileID, deserialized.FrontImageFileID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::CheckDepositInstruction
        {
            Amount = 100,
            BackImageFileID = "file_26khfk98mzfz90a11oqx",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = PendingTransactions::CheckDepositInstructionCurrency.Usd,
            FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::CheckDepositInstruction
        {
            Amount = 100,
            BackImageFileID = "file_26khfk98mzfz90a11oqx",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = PendingTransactions::CheckDepositInstructionCurrency.Usd,
            FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
        };

        PendingTransactions::CheckDepositInstruction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckDepositInstructionCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::CheckDepositInstructionCurrency.Usd)]
    public void Validation_Works(PendingTransactions::CheckDepositInstructionCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::CheckDepositInstructionCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::CheckDepositInstructionCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::CheckDepositInstructionCurrency.Usd)]
    public void SerializationRoundtrip_Works(
        PendingTransactions::CheckDepositInstructionCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::CheckDepositInstructionCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::CheckDepositInstructionCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::CheckDepositInstructionCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::CheckDepositInstructionCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CheckTransferInstructionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::CheckTransferInstruction
        {
            Amount = 100,
            Currency = PendingTransactions::CheckTransferInstructionCurrency.Usd,
            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
        };

        long expectedAmount = 100;
        ApiEnum<string, PendingTransactions::CheckTransferInstructionCurrency> expectedCurrency =
            PendingTransactions::CheckTransferInstructionCurrency.Usd;
        string expectedTransferID = "check_transfer_30b43acfu9vw8fyc4f5";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedTransferID, model.TransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::CheckTransferInstruction
        {
            Amount = 100,
            Currency = PendingTransactions::CheckTransferInstructionCurrency.Usd,
            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::CheckTransferInstruction>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::CheckTransferInstruction
        {
            Amount = 100,
            Currency = PendingTransactions::CheckTransferInstructionCurrency.Usd,
            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::CheckTransferInstruction>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAmount = 100;
        ApiEnum<string, PendingTransactions::CheckTransferInstructionCurrency> expectedCurrency =
            PendingTransactions::CheckTransferInstructionCurrency.Usd;
        string expectedTransferID = "check_transfer_30b43acfu9vw8fyc4f5";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedTransferID, deserialized.TransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::CheckTransferInstruction
        {
            Amount = 100,
            Currency = PendingTransactions::CheckTransferInstructionCurrency.Usd,
            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::CheckTransferInstruction
        {
            Amount = 100,
            Currency = PendingTransactions::CheckTransferInstructionCurrency.Usd,
            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
        };

        PendingTransactions::CheckTransferInstruction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckTransferInstructionCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::CheckTransferInstructionCurrency.Usd)]
    public void Validation_Works(PendingTransactions::CheckTransferInstructionCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::CheckTransferInstructionCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::CheckTransferInstructionCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::CheckTransferInstructionCurrency.Usd)]
    public void SerializationRoundtrip_Works(
        PendingTransactions::CheckTransferInstructionCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::CheckTransferInstructionCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::CheckTransferInstructionCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::CheckTransferInstructionCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::CheckTransferInstructionCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FednowTransferInstructionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::FednowTransferInstruction
        {
            TransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
        };

        string expectedTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg";

        Assert.Equal(expectedTransferID, model.TransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::FednowTransferInstruction
        {
            TransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::FednowTransferInstruction>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::FednowTransferInstruction
        {
            TransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::FednowTransferInstruction>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg";

        Assert.Equal(expectedTransferID, deserialized.TransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::FednowTransferInstruction
        {
            TransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::FednowTransferInstruction
        {
            TransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
        };

        PendingTransactions::FednowTransferInstruction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InboundFundsHoldTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::InboundFundsHold
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
        };

        long expectedAmount = 100;
        DateTimeOffset expectedAutomaticallyReleasesAt = DateTimeOffset.Parse(
            "2020-01-31T23:59:59Z"
        );
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, PendingTransactions::InboundFundsHoldCurrency> expectedCurrency =
            PendingTransactions::InboundFundsHoldCurrency.Usd;
        string expectedHeldTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        string expectedPendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4";
        ApiEnum<string, PendingTransactions::InboundFundsHoldStatus> expectedStatus =
            PendingTransactions::InboundFundsHoldStatus.Held;
        ApiEnum<string, PendingTransactions::InboundFundsHoldType> expectedType =
            PendingTransactions::InboundFundsHoldType.InboundFundsHold;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedAutomaticallyReleasesAt, model.AutomaticallyReleasesAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedHeldTransactionID, model.HeldTransactionID);
        Assert.Equal(expectedPendingTransactionID, model.PendingTransactionID);
        Assert.Null(model.ReleasedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::InboundFundsHold
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::InboundFundsHold>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::InboundFundsHold
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::InboundFundsHold>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 100;
        DateTimeOffset expectedAutomaticallyReleasesAt = DateTimeOffset.Parse(
            "2020-01-31T23:59:59Z"
        );
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, PendingTransactions::InboundFundsHoldCurrency> expectedCurrency =
            PendingTransactions::InboundFundsHoldCurrency.Usd;
        string expectedHeldTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        string expectedPendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4";
        ApiEnum<string, PendingTransactions::InboundFundsHoldStatus> expectedStatus =
            PendingTransactions::InboundFundsHoldStatus.Held;
        ApiEnum<string, PendingTransactions::InboundFundsHoldType> expectedType =
            PendingTransactions::InboundFundsHoldType.InboundFundsHold;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedAutomaticallyReleasesAt, deserialized.AutomaticallyReleasesAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedHeldTransactionID, deserialized.HeldTransactionID);
        Assert.Equal(expectedPendingTransactionID, deserialized.PendingTransactionID);
        Assert.Null(deserialized.ReleasedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::InboundFundsHold
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::InboundFundsHold
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
        };

        PendingTransactions::InboundFundsHold copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InboundFundsHoldCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::InboundFundsHoldCurrency.Usd)]
    public void Validation_Works(PendingTransactions::InboundFundsHoldCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::InboundFundsHoldCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::InboundFundsHoldCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::InboundFundsHoldCurrency.Usd)]
    public void SerializationRoundtrip_Works(PendingTransactions::InboundFundsHoldCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::InboundFundsHoldCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::InboundFundsHoldCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::InboundFundsHoldCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::InboundFundsHoldCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InboundFundsHoldStatusTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::InboundFundsHoldStatus.Held)]
    [InlineData(PendingTransactions::InboundFundsHoldStatus.Complete)]
    public void Validation_Works(PendingTransactions::InboundFundsHoldStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::InboundFundsHoldStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::InboundFundsHoldStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::InboundFundsHoldStatus.Held)]
    [InlineData(PendingTransactions::InboundFundsHoldStatus.Complete)]
    public void SerializationRoundtrip_Works(PendingTransactions::InboundFundsHoldStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::InboundFundsHoldStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::InboundFundsHoldStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::InboundFundsHoldStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::InboundFundsHoldStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InboundFundsHoldTypeTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::InboundFundsHoldType.InboundFundsHold)]
    public void Validation_Works(PendingTransactions::InboundFundsHoldType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::InboundFundsHoldType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::InboundFundsHoldType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::InboundFundsHoldType.InboundFundsHold)]
    public void SerializationRoundtrip_Works(PendingTransactions::InboundFundsHoldType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::InboundFundsHoldType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::InboundFundsHoldType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::InboundFundsHoldType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::InboundFundsHoldType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InboundWireTransferReversalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::InboundWireTransferReversal
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
        };

        string expectedInboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0";

        Assert.Equal(expectedInboundWireTransferID, model.InboundWireTransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::InboundWireTransferReversal
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::InboundWireTransferReversal>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::InboundWireTransferReversal
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::InboundWireTransferReversal>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedInboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0";

        Assert.Equal(expectedInboundWireTransferID, deserialized.InboundWireTransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::InboundWireTransferReversal
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::InboundWireTransferReversal
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
        };

        PendingTransactions::InboundWireTransferReversal copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OtherTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::Other { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::Other { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Other>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::Other { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::Other>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::Other { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::Other { };

        PendingTransactions::Other copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimePaymentsTransferInstructionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::RealTimePaymentsTransferInstruction
        {
            Amount = 100,
            TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
        };

        long expectedAmount = 100;
        string expectedTransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedTransferID, model.TransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::RealTimePaymentsTransferInstruction
        {
            Amount = 100,
            TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::RealTimePaymentsTransferInstruction>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::RealTimePaymentsTransferInstruction
        {
            Amount = 100,
            TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::RealTimePaymentsTransferInstruction>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAmount = 100;
        string expectedTransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedTransferID, deserialized.TransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::RealTimePaymentsTransferInstruction
        {
            Amount = 100,
            TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::RealTimePaymentsTransferInstruction
        {
            Amount = 100,
            TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
        };

        PendingTransactions::RealTimePaymentsTransferInstruction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SwiftTransferInstructionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::SwiftTransferInstruction
        {
            TransferID = "swift_transfer_29h21xkng03788zwd3fh",
        };

        string expectedTransferID = "swift_transfer_29h21xkng03788zwd3fh";

        Assert.Equal(expectedTransferID, model.TransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::SwiftTransferInstruction
        {
            TransferID = "swift_transfer_29h21xkng03788zwd3fh",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::SwiftTransferInstruction>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::SwiftTransferInstruction
        {
            TransferID = "swift_transfer_29h21xkng03788zwd3fh",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::SwiftTransferInstruction>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedTransferID = "swift_transfer_29h21xkng03788zwd3fh";

        Assert.Equal(expectedTransferID, deserialized.TransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::SwiftTransferInstruction
        {
            TransferID = "swift_transfer_29h21xkng03788zwd3fh",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::SwiftTransferInstruction
        {
            TransferID = "swift_transfer_29h21xkng03788zwd3fh",
        };

        PendingTransactions::SwiftTransferInstruction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WireTransferInstructionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::WireTransferInstruction
        {
            AccountNumber = "987654321",
            Amount = 100,
            MessageToRecipient = "HELLO",
            RoutingNumber = "101050001",
            TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        string expectedAccountNumber = "987654321";
        long expectedAmount = 100;
        string expectedMessageToRecipient = "HELLO";
        string expectedRoutingNumber = "101050001";
        string expectedTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u";

        Assert.Equal(expectedAccountNumber, model.AccountNumber);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedMessageToRecipient, model.MessageToRecipient);
        Assert.Equal(expectedRoutingNumber, model.RoutingNumber);
        Assert.Equal(expectedTransferID, model.TransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTransactions::WireTransferInstruction
        {
            AccountNumber = "987654321",
            Amount = 100,
            MessageToRecipient = "HELLO",
            RoutingNumber = "101050001",
            TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::WireTransferInstruction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::WireTransferInstruction
        {
            AccountNumber = "987654321",
            Amount = 100,
            MessageToRecipient = "HELLO",
            RoutingNumber = "101050001",
            TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTransactions::WireTransferInstruction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountNumber = "987654321";
        long expectedAmount = 100;
        string expectedMessageToRecipient = "HELLO";
        string expectedRoutingNumber = "101050001";
        string expectedTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u";

        Assert.Equal(expectedAccountNumber, deserialized.AccountNumber);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedMessageToRecipient, deserialized.MessageToRecipient);
        Assert.Equal(expectedRoutingNumber, deserialized.RoutingNumber);
        Assert.Equal(expectedTransferID, deserialized.TransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTransactions::WireTransferInstruction
        {
            AccountNumber = "987654321",
            Amount = 100,
            MessageToRecipient = "HELLO",
            RoutingNumber = "101050001",
            TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::WireTransferInstruction
        {
            AccountNumber = "987654321",
            Amount = 100,
            MessageToRecipient = "HELLO",
            RoutingNumber = "101050001",
            TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        PendingTransactions::WireTransferInstruction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PendingTransactionStatusTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::PendingTransactionStatus.Pending)]
    [InlineData(PendingTransactions::PendingTransactionStatus.Complete)]
    public void Validation_Works(PendingTransactions::PendingTransactionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::PendingTransactionStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::PendingTransactionStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::PendingTransactionStatus.Pending)]
    [InlineData(PendingTransactions::PendingTransactionStatus.Complete)]
    public void SerializationRoundtrip_Works(PendingTransactions::PendingTransactionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::PendingTransactionStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::PendingTransactionStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::PendingTransactionStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::PendingTransactionStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PendingTransactionTypeTest : TestBase
{
    [Theory]
    [InlineData(PendingTransactions::PendingTransactionType.PendingTransaction)]
    public void Validation_Works(PendingTransactions::PendingTransactionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::PendingTransactionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::PendingTransactionType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PendingTransactions::PendingTransactionType.PendingTransaction)]
    public void SerializationRoundtrip_Works(PendingTransactions::PendingTransactionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PendingTransactions::PendingTransactionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::PendingTransactionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::PendingTransactionType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PendingTransactions::PendingTransactionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
