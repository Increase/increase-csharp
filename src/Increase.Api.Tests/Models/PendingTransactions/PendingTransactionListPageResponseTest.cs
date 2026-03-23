using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using PendingTransactions = Increase.Api.Models.PendingTransactions;

namespace Increase.Api.Tests.Models.PendingTransactions;

public class PendingTransactionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTransactions::PendingTransactionListPageResponse
        {
            Data =
            [
                new()
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
                            DestinationBlockchainAddress =
                                "0x304a554a310C7e546dfe434669C62820b7D83490",
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
                        InboundWireTransferReversal = new(
                            "inbound_wire_transfer_f228m6bmhtcxjco9pwp0"
                        ),
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
            ],
            NextCursor = "v57w5d",
        };

        List<PendingTransactions::PendingTransaction> expectedData =
        [
            new()
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
        var model = new PendingTransactions::PendingTransactionListPageResponse
        {
            Data =
            [
                new()
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
                            DestinationBlockchainAddress =
                                "0x304a554a310C7e546dfe434669C62820b7D83490",
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
                        InboundWireTransferReversal = new(
                            "inbound_wire_transfer_f228m6bmhtcxjco9pwp0"
                        ),
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
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::PendingTransactionListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTransactions::PendingTransactionListPageResponse
        {
            Data =
            [
                new()
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
                            DestinationBlockchainAddress =
                                "0x304a554a310C7e546dfe434669C62820b7D83490",
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
                        InboundWireTransferReversal = new(
                            "inbound_wire_transfer_f228m6bmhtcxjco9pwp0"
                        ),
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
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PendingTransactions::PendingTransactionListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<PendingTransactions::PendingTransaction> expectedData =
        [
            new()
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
        var model = new PendingTransactions::PendingTransactionListPageResponse
        {
            Data =
            [
                new()
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
                            DestinationBlockchainAddress =
                                "0x304a554a310C7e546dfe434669C62820b7D83490",
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
                        InboundWireTransferReversal = new(
                            "inbound_wire_transfer_f228m6bmhtcxjco9pwp0"
                        ),
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
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTransactions::PendingTransactionListPageResponse
        {
            Data =
            [
                new()
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
                            DestinationBlockchainAddress =
                                "0x304a554a310C7e546dfe434669C62820b7D83490",
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
                        InboundWireTransferReversal = new(
                            "inbound_wire_transfer_f228m6bmhtcxjco9pwp0"
                        ),
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
            ],
            NextCursor = "v57w5d",
        };

        PendingTransactions::PendingTransactionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
