using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using AchTransfers = Increase.Api.Models.AchTransfers;

namespace Increase.Api.Tests.Models.AchTransfers;

public class AchTransferTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::AchTransfer
        {
            ID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Acknowledgement = new("2020-01-31T23:59:59Z"),
            Addenda = new()
            {
                Category = AchTransfers::AchTransferAddendaCategory.Freeform,
                Freeform = new([new("addendum")]),
                PaymentOrderRemittanceAdvice = new(
                    [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }]
                ),
            },
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ApprovedBy = null,
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CompanyDescriptiveDate = null,
            CompanyDiscretionaryData = null,
            CompanyEntryDescription = null,
            CompanyID = "1234987601",
            CompanyName = "National Phonograph Company",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = AchTransfers::CreatedByCategory.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            Currency = AchTransfers::Currency.Usd,
            DestinationAccountHolder = AchTransfers::AchTransferDestinationAccountHolder.Business,
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
            Funding = AchTransfers::AchTransferFunding.Checking,
            IdempotencyKey = null,
            InboundFundsHold = new()
            {
                Amount = 100,
                AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = AchTransfers::InboundFundsHoldCurrency.Usd,
                HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                ReleasedAt = null,
                Status = AchTransfers::InboundFundsHoldStatus.Held,
                Type = AchTransfers::Type.InboundFundsHold,
            },
            IndividualID = null,
            IndividualName = "Ian Crease",
            Network = AchTransfers::Network.Ach,
            NotificationsOfChange =
            [
                new()
                {
                    ChangeCode = AchTransfers::ChangeCode.IncorrectTransactionCode,
                    CorrectedData = "32",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
            PendingTransactionID = null,
            PreferredEffectiveDate = new()
            {
                Date = null,
                SettlementSchedule =
                    AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.SameDay,
            },
            Return = new()
            {
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                RawReturnReasonCode = "R01",
                ReturnReasonCode = AchTransfers::ReturnReasonCode.InsufficientFund,
                TraceNumber = "111122223292834",
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            },
            RoutingNumber = "101050001",
            Settlement = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
            StandardEntryClassCode =
                AchTransfers::AchTransferStandardEntryClassCode.CorporateCreditOrDebit,
            StatementDescriptor = "Statement descriptor",
            Status = AchTransfers::AchTransferStatus.Returned,
            Submission = new()
            {
                AdministrativeReturnsExpectedBy = DateTimeOffset.Parse("2020-02-05T11:00:00Z"),
                EffectiveDate = "2020-01-31",
                ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
                ExpectedSettlementSchedule = AchTransfers::ExpectedSettlementSchedule.FutureDated,
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                TraceNumber = "058349238292834",
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = AchTransfers::AchTransferType.AchTransfer,
        };

        string expectedID = "ach_transfer_uoxatyh3lt5evrsdvo7q";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumber = "987654321";
        AchTransfers::Acknowledgement expectedAcknowledgement = new("2020-01-31T23:59:59Z");
        AchTransfers::AchTransferAddenda expectedAddenda = new()
        {
            Category = AchTransfers::AchTransferAddendaCategory.Freeform,
            Freeform = new([new("addendum")]),
            PaymentOrderRemittanceAdvice = new(
                [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }]
            ),
        };
        long expectedAmount = 100;
        AchTransfers::Approval expectedApproval = new()
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };
        AchTransfers::Cancellation expectedCancellation = new()
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };
        string expectedCompanyID = "1234987601";
        string expectedCompanyName = "National Phonograph Company";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        AchTransfers::CreatedBy expectedCreatedBy = new()
        {
            Category = AchTransfers::CreatedByCategory.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        ApiEnum<string, AchTransfers::Currency> expectedCurrency = AchTransfers::Currency.Usd;
        ApiEnum<
            string,
            AchTransfers::AchTransferDestinationAccountHolder
        > expectedDestinationAccountHolder =
            AchTransfers::AchTransferDestinationAccountHolder.Business;
        string expectedExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv";
        ApiEnum<string, AchTransfers::AchTransferFunding> expectedFunding =
            AchTransfers::AchTransferFunding.Checking;
        AchTransfers::InboundFundsHold expectedInboundFundsHold = new()
        {
            Amount = 100,
            AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = AchTransfers::InboundFundsHoldCurrency.Usd,
            HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            ReleasedAt = null,
            Status = AchTransfers::InboundFundsHoldStatus.Held,
            Type = AchTransfers::Type.InboundFundsHold,
        };
        string expectedIndividualName = "Ian Crease";
        ApiEnum<string, AchTransfers::Network> expectedNetwork = AchTransfers::Network.Ach;
        List<AchTransfers::NotificationsOfChange> expectedNotificationsOfChange =
        [
            new()
            {
                ChangeCode = AchTransfers::ChangeCode.IncorrectTransactionCode,
                CorrectedData = "32",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
        ];
        AchTransfers::AchTransferPreferredEffectiveDate expectedPreferredEffectiveDate = new()
        {
            Date = null,
            SettlementSchedule =
                AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.SameDay,
        };
        AchTransfers::Return expectedReturn = new()
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            RawReturnReasonCode = "R01",
            ReturnReasonCode = AchTransfers::ReturnReasonCode.InsufficientFund,
            TraceNumber = "111122223292834",
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };
        string expectedRoutingNumber = "101050001";
        AchTransfers::Settlement expectedSettlement = new(
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
        );
        ApiEnum<
            string,
            AchTransfers::AchTransferStandardEntryClassCode
        > expectedStandardEntryClassCode =
            AchTransfers::AchTransferStandardEntryClassCode.CorporateCreditOrDebit;
        string expectedStatementDescriptor = "Statement descriptor";
        ApiEnum<string, AchTransfers::AchTransferStatus> expectedStatus =
            AchTransfers::AchTransferStatus.Returned;
        AchTransfers::Submission expectedSubmission = new()
        {
            AdministrativeReturnsExpectedBy = DateTimeOffset.Parse("2020-02-05T11:00:00Z"),
            EffectiveDate = "2020-01-31",
            ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
            ExpectedSettlementSchedule = AchTransfers::ExpectedSettlementSchedule.FutureDated,
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "058349238292834",
        };
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, AchTransfers::AchTransferType> expectedType =
            AchTransfers::AchTransferType.AchTransfer;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAccountNumber, model.AccountNumber);
        Assert.Equal(expectedAcknowledgement, model.Acknowledgement);
        Assert.Equal(expectedAddenda, model.Addenda);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedApproval, model.Approval);
        Assert.Equal(expectedCancellation, model.Cancellation);
        Assert.Null(model.CompanyDescriptiveDate);
        Assert.Null(model.CompanyDiscretionaryData);
        Assert.Null(model.CompanyEntryDescription);
        Assert.Equal(expectedCompanyID, model.CompanyID);
        Assert.Equal(expectedCompanyName, model.CompanyName);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDestinationAccountHolder, model.DestinationAccountHolder);
        Assert.Equal(expectedExternalAccountID, model.ExternalAccountID);
        Assert.Equal(expectedFunding, model.Funding);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedInboundFundsHold, model.InboundFundsHold);
        Assert.Null(model.IndividualID);
        Assert.Equal(expectedIndividualName, model.IndividualName);
        Assert.Equal(expectedNetwork, model.Network);
        Assert.Equal(expectedNotificationsOfChange.Count, model.NotificationsOfChange.Count);
        for (int i = 0; i < expectedNotificationsOfChange.Count; i++)
        {
            Assert.Equal(expectedNotificationsOfChange[i], model.NotificationsOfChange[i]);
        }
        Assert.Null(model.PendingTransactionID);
        Assert.Equal(expectedPreferredEffectiveDate, model.PreferredEffectiveDate);
        Assert.Equal(expectedReturn, model.Return);
        Assert.Equal(expectedRoutingNumber, model.RoutingNumber);
        Assert.Equal(expectedSettlement, model.Settlement);
        Assert.Equal(expectedStandardEntryClassCode, model.StandardEntryClassCode);
        Assert.Equal(expectedStatementDescriptor, model.StatementDescriptor);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubmission, model.Submission);
        Assert.Equal(expectedTransactionID, model.TransactionID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::AchTransfer
        {
            ID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Acknowledgement = new("2020-01-31T23:59:59Z"),
            Addenda = new()
            {
                Category = AchTransfers::AchTransferAddendaCategory.Freeform,
                Freeform = new([new("addendum")]),
                PaymentOrderRemittanceAdvice = new(
                    [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }]
                ),
            },
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ApprovedBy = null,
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CompanyDescriptiveDate = null,
            CompanyDiscretionaryData = null,
            CompanyEntryDescription = null,
            CompanyID = "1234987601",
            CompanyName = "National Phonograph Company",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = AchTransfers::CreatedByCategory.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            Currency = AchTransfers::Currency.Usd,
            DestinationAccountHolder = AchTransfers::AchTransferDestinationAccountHolder.Business,
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
            Funding = AchTransfers::AchTransferFunding.Checking,
            IdempotencyKey = null,
            InboundFundsHold = new()
            {
                Amount = 100,
                AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = AchTransfers::InboundFundsHoldCurrency.Usd,
                HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                ReleasedAt = null,
                Status = AchTransfers::InboundFundsHoldStatus.Held,
                Type = AchTransfers::Type.InboundFundsHold,
            },
            IndividualID = null,
            IndividualName = "Ian Crease",
            Network = AchTransfers::Network.Ach,
            NotificationsOfChange =
            [
                new()
                {
                    ChangeCode = AchTransfers::ChangeCode.IncorrectTransactionCode,
                    CorrectedData = "32",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
            PendingTransactionID = null,
            PreferredEffectiveDate = new()
            {
                Date = null,
                SettlementSchedule =
                    AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.SameDay,
            },
            Return = new()
            {
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                RawReturnReasonCode = "R01",
                ReturnReasonCode = AchTransfers::ReturnReasonCode.InsufficientFund,
                TraceNumber = "111122223292834",
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            },
            RoutingNumber = "101050001",
            Settlement = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
            StandardEntryClassCode =
                AchTransfers::AchTransferStandardEntryClassCode.CorporateCreditOrDebit,
            StatementDescriptor = "Statement descriptor",
            Status = AchTransfers::AchTransferStatus.Returned,
            Submission = new()
            {
                AdministrativeReturnsExpectedBy = DateTimeOffset.Parse("2020-02-05T11:00:00Z"),
                EffectiveDate = "2020-01-31",
                ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
                ExpectedSettlementSchedule = AchTransfers::ExpectedSettlementSchedule.FutureDated,
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                TraceNumber = "058349238292834",
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = AchTransfers::AchTransferType.AchTransfer,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::AchTransfer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::AchTransfer
        {
            ID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Acknowledgement = new("2020-01-31T23:59:59Z"),
            Addenda = new()
            {
                Category = AchTransfers::AchTransferAddendaCategory.Freeform,
                Freeform = new([new("addendum")]),
                PaymentOrderRemittanceAdvice = new(
                    [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }]
                ),
            },
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ApprovedBy = null,
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CompanyDescriptiveDate = null,
            CompanyDiscretionaryData = null,
            CompanyEntryDescription = null,
            CompanyID = "1234987601",
            CompanyName = "National Phonograph Company",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = AchTransfers::CreatedByCategory.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            Currency = AchTransfers::Currency.Usd,
            DestinationAccountHolder = AchTransfers::AchTransferDestinationAccountHolder.Business,
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
            Funding = AchTransfers::AchTransferFunding.Checking,
            IdempotencyKey = null,
            InboundFundsHold = new()
            {
                Amount = 100,
                AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = AchTransfers::InboundFundsHoldCurrency.Usd,
                HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                ReleasedAt = null,
                Status = AchTransfers::InboundFundsHoldStatus.Held,
                Type = AchTransfers::Type.InboundFundsHold,
            },
            IndividualID = null,
            IndividualName = "Ian Crease",
            Network = AchTransfers::Network.Ach,
            NotificationsOfChange =
            [
                new()
                {
                    ChangeCode = AchTransfers::ChangeCode.IncorrectTransactionCode,
                    CorrectedData = "32",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
            PendingTransactionID = null,
            PreferredEffectiveDate = new()
            {
                Date = null,
                SettlementSchedule =
                    AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.SameDay,
            },
            Return = new()
            {
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                RawReturnReasonCode = "R01",
                ReturnReasonCode = AchTransfers::ReturnReasonCode.InsufficientFund,
                TraceNumber = "111122223292834",
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            },
            RoutingNumber = "101050001",
            Settlement = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
            StandardEntryClassCode =
                AchTransfers::AchTransferStandardEntryClassCode.CorporateCreditOrDebit,
            StatementDescriptor = "Statement descriptor",
            Status = AchTransfers::AchTransferStatus.Returned,
            Submission = new()
            {
                AdministrativeReturnsExpectedBy = DateTimeOffset.Parse("2020-02-05T11:00:00Z"),
                EffectiveDate = "2020-01-31",
                ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
                ExpectedSettlementSchedule = AchTransfers::ExpectedSettlementSchedule.FutureDated,
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                TraceNumber = "058349238292834",
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = AchTransfers::AchTransferType.AchTransfer,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::AchTransfer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "ach_transfer_uoxatyh3lt5evrsdvo7q";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumber = "987654321";
        AchTransfers::Acknowledgement expectedAcknowledgement = new("2020-01-31T23:59:59Z");
        AchTransfers::AchTransferAddenda expectedAddenda = new()
        {
            Category = AchTransfers::AchTransferAddendaCategory.Freeform,
            Freeform = new([new("addendum")]),
            PaymentOrderRemittanceAdvice = new(
                [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }]
            ),
        };
        long expectedAmount = 100;
        AchTransfers::Approval expectedApproval = new()
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };
        AchTransfers::Cancellation expectedCancellation = new()
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };
        string expectedCompanyID = "1234987601";
        string expectedCompanyName = "National Phonograph Company";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        AchTransfers::CreatedBy expectedCreatedBy = new()
        {
            Category = AchTransfers::CreatedByCategory.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        ApiEnum<string, AchTransfers::Currency> expectedCurrency = AchTransfers::Currency.Usd;
        ApiEnum<
            string,
            AchTransfers::AchTransferDestinationAccountHolder
        > expectedDestinationAccountHolder =
            AchTransfers::AchTransferDestinationAccountHolder.Business;
        string expectedExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv";
        ApiEnum<string, AchTransfers::AchTransferFunding> expectedFunding =
            AchTransfers::AchTransferFunding.Checking;
        AchTransfers::InboundFundsHold expectedInboundFundsHold = new()
        {
            Amount = 100,
            AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = AchTransfers::InboundFundsHoldCurrency.Usd,
            HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            ReleasedAt = null,
            Status = AchTransfers::InboundFundsHoldStatus.Held,
            Type = AchTransfers::Type.InboundFundsHold,
        };
        string expectedIndividualName = "Ian Crease";
        ApiEnum<string, AchTransfers::Network> expectedNetwork = AchTransfers::Network.Ach;
        List<AchTransfers::NotificationsOfChange> expectedNotificationsOfChange =
        [
            new()
            {
                ChangeCode = AchTransfers::ChangeCode.IncorrectTransactionCode,
                CorrectedData = "32",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
        ];
        AchTransfers::AchTransferPreferredEffectiveDate expectedPreferredEffectiveDate = new()
        {
            Date = null,
            SettlementSchedule =
                AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.SameDay,
        };
        AchTransfers::Return expectedReturn = new()
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            RawReturnReasonCode = "R01",
            ReturnReasonCode = AchTransfers::ReturnReasonCode.InsufficientFund,
            TraceNumber = "111122223292834",
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };
        string expectedRoutingNumber = "101050001";
        AchTransfers::Settlement expectedSettlement = new(
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
        );
        ApiEnum<
            string,
            AchTransfers::AchTransferStandardEntryClassCode
        > expectedStandardEntryClassCode =
            AchTransfers::AchTransferStandardEntryClassCode.CorporateCreditOrDebit;
        string expectedStatementDescriptor = "Statement descriptor";
        ApiEnum<string, AchTransfers::AchTransferStatus> expectedStatus =
            AchTransfers::AchTransferStatus.Returned;
        AchTransfers::Submission expectedSubmission = new()
        {
            AdministrativeReturnsExpectedBy = DateTimeOffset.Parse("2020-02-05T11:00:00Z"),
            EffectiveDate = "2020-01-31",
            ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
            ExpectedSettlementSchedule = AchTransfers::ExpectedSettlementSchedule.FutureDated,
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "058349238292834",
        };
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, AchTransfers::AchTransferType> expectedType =
            AchTransfers::AchTransferType.AchTransfer;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAccountNumber, deserialized.AccountNumber);
        Assert.Equal(expectedAcknowledgement, deserialized.Acknowledgement);
        Assert.Equal(expectedAddenda, deserialized.Addenda);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedApproval, deserialized.Approval);
        Assert.Equal(expectedCancellation, deserialized.Cancellation);
        Assert.Null(deserialized.CompanyDescriptiveDate);
        Assert.Null(deserialized.CompanyDiscretionaryData);
        Assert.Null(deserialized.CompanyEntryDescription);
        Assert.Equal(expectedCompanyID, deserialized.CompanyID);
        Assert.Equal(expectedCompanyName, deserialized.CompanyName);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDestinationAccountHolder, deserialized.DestinationAccountHolder);
        Assert.Equal(expectedExternalAccountID, deserialized.ExternalAccountID);
        Assert.Equal(expectedFunding, deserialized.Funding);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedInboundFundsHold, deserialized.InboundFundsHold);
        Assert.Null(deserialized.IndividualID);
        Assert.Equal(expectedIndividualName, deserialized.IndividualName);
        Assert.Equal(expectedNetwork, deserialized.Network);
        Assert.Equal(expectedNotificationsOfChange.Count, deserialized.NotificationsOfChange.Count);
        for (int i = 0; i < expectedNotificationsOfChange.Count; i++)
        {
            Assert.Equal(expectedNotificationsOfChange[i], deserialized.NotificationsOfChange[i]);
        }
        Assert.Null(deserialized.PendingTransactionID);
        Assert.Equal(expectedPreferredEffectiveDate, deserialized.PreferredEffectiveDate);
        Assert.Equal(expectedReturn, deserialized.Return);
        Assert.Equal(expectedRoutingNumber, deserialized.RoutingNumber);
        Assert.Equal(expectedSettlement, deserialized.Settlement);
        Assert.Equal(expectedStandardEntryClassCode, deserialized.StandardEntryClassCode);
        Assert.Equal(expectedStatementDescriptor, deserialized.StatementDescriptor);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubmission, deserialized.Submission);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::AchTransfer
        {
            ID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Acknowledgement = new("2020-01-31T23:59:59Z"),
            Addenda = new()
            {
                Category = AchTransfers::AchTransferAddendaCategory.Freeform,
                Freeform = new([new("addendum")]),
                PaymentOrderRemittanceAdvice = new(
                    [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }]
                ),
            },
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ApprovedBy = null,
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CompanyDescriptiveDate = null,
            CompanyDiscretionaryData = null,
            CompanyEntryDescription = null,
            CompanyID = "1234987601",
            CompanyName = "National Phonograph Company",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = AchTransfers::CreatedByCategory.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            Currency = AchTransfers::Currency.Usd,
            DestinationAccountHolder = AchTransfers::AchTransferDestinationAccountHolder.Business,
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
            Funding = AchTransfers::AchTransferFunding.Checking,
            IdempotencyKey = null,
            InboundFundsHold = new()
            {
                Amount = 100,
                AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = AchTransfers::InboundFundsHoldCurrency.Usd,
                HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                ReleasedAt = null,
                Status = AchTransfers::InboundFundsHoldStatus.Held,
                Type = AchTransfers::Type.InboundFundsHold,
            },
            IndividualID = null,
            IndividualName = "Ian Crease",
            Network = AchTransfers::Network.Ach,
            NotificationsOfChange =
            [
                new()
                {
                    ChangeCode = AchTransfers::ChangeCode.IncorrectTransactionCode,
                    CorrectedData = "32",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
            PendingTransactionID = null,
            PreferredEffectiveDate = new()
            {
                Date = null,
                SettlementSchedule =
                    AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.SameDay,
            },
            Return = new()
            {
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                RawReturnReasonCode = "R01",
                ReturnReasonCode = AchTransfers::ReturnReasonCode.InsufficientFund,
                TraceNumber = "111122223292834",
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            },
            RoutingNumber = "101050001",
            Settlement = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
            StandardEntryClassCode =
                AchTransfers::AchTransferStandardEntryClassCode.CorporateCreditOrDebit,
            StatementDescriptor = "Statement descriptor",
            Status = AchTransfers::AchTransferStatus.Returned,
            Submission = new()
            {
                AdministrativeReturnsExpectedBy = DateTimeOffset.Parse("2020-02-05T11:00:00Z"),
                EffectiveDate = "2020-01-31",
                ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
                ExpectedSettlementSchedule = AchTransfers::ExpectedSettlementSchedule.FutureDated,
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                TraceNumber = "058349238292834",
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = AchTransfers::AchTransferType.AchTransfer,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::AchTransfer
        {
            ID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Acknowledgement = new("2020-01-31T23:59:59Z"),
            Addenda = new()
            {
                Category = AchTransfers::AchTransferAddendaCategory.Freeform,
                Freeform = new([new("addendum")]),
                PaymentOrderRemittanceAdvice = new(
                    [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }]
                ),
            },
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ApprovedBy = null,
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CompanyDescriptiveDate = null,
            CompanyDiscretionaryData = null,
            CompanyEntryDescription = null,
            CompanyID = "1234987601",
            CompanyName = "National Phonograph Company",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = AchTransfers::CreatedByCategory.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            Currency = AchTransfers::Currency.Usd,
            DestinationAccountHolder = AchTransfers::AchTransferDestinationAccountHolder.Business,
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
            Funding = AchTransfers::AchTransferFunding.Checking,
            IdempotencyKey = null,
            InboundFundsHold = new()
            {
                Amount = 100,
                AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = AchTransfers::InboundFundsHoldCurrency.Usd,
                HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                ReleasedAt = null,
                Status = AchTransfers::InboundFundsHoldStatus.Held,
                Type = AchTransfers::Type.InboundFundsHold,
            },
            IndividualID = null,
            IndividualName = "Ian Crease",
            Network = AchTransfers::Network.Ach,
            NotificationsOfChange =
            [
                new()
                {
                    ChangeCode = AchTransfers::ChangeCode.IncorrectTransactionCode,
                    CorrectedData = "32",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
            PendingTransactionID = null,
            PreferredEffectiveDate = new()
            {
                Date = null,
                SettlementSchedule =
                    AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.SameDay,
            },
            Return = new()
            {
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                RawReturnReasonCode = "R01",
                ReturnReasonCode = AchTransfers::ReturnReasonCode.InsufficientFund,
                TraceNumber = "111122223292834",
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            },
            RoutingNumber = "101050001",
            Settlement = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
            StandardEntryClassCode =
                AchTransfers::AchTransferStandardEntryClassCode.CorporateCreditOrDebit,
            StatementDescriptor = "Statement descriptor",
            Status = AchTransfers::AchTransferStatus.Returned,
            Submission = new()
            {
                AdministrativeReturnsExpectedBy = DateTimeOffset.Parse("2020-02-05T11:00:00Z"),
                EffectiveDate = "2020-01-31",
                ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
                ExpectedSettlementSchedule = AchTransfers::ExpectedSettlementSchedule.FutureDated,
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                TraceNumber = "058349238292834",
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = AchTransfers::AchTransferType.AchTransfer,
        };

        AchTransfers::AchTransfer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AcknowledgementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::Acknowledgement { AcknowledgedAt = "2020-01-31T23:59:59Z" };

        string expectedAcknowledgedAt = "2020-01-31T23:59:59Z";

        Assert.Equal(expectedAcknowledgedAt, model.AcknowledgedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::Acknowledgement { AcknowledgedAt = "2020-01-31T23:59:59Z" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::Acknowledgement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::Acknowledgement { AcknowledgedAt = "2020-01-31T23:59:59Z" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::Acknowledgement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAcknowledgedAt = "2020-01-31T23:59:59Z";

        Assert.Equal(expectedAcknowledgedAt, deserialized.AcknowledgedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::Acknowledgement { AcknowledgedAt = "2020-01-31T23:59:59Z" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::Acknowledgement { AcknowledgedAt = "2020-01-31T23:59:59Z" };

        AchTransfers::Acknowledgement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AchTransferAddendaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::AchTransferAddenda
        {
            Category = AchTransfers::AchTransferAddendaCategory.Freeform,
            Freeform = new([new("addendum")]),
            PaymentOrderRemittanceAdvice = new(
                [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }]
            ),
        };

        ApiEnum<string, AchTransfers::AchTransferAddendaCategory> expectedCategory =
            AchTransfers::AchTransferAddendaCategory.Freeform;
        AchTransfers::AchTransferAddendaFreeform expectedFreeform = new([new("addendum")]);
        AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdvice expectedPaymentOrderRemittanceAdvice =
            new([new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }]);

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedFreeform, model.Freeform);
        Assert.Equal(expectedPaymentOrderRemittanceAdvice, model.PaymentOrderRemittanceAdvice);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::AchTransferAddenda
        {
            Category = AchTransfers::AchTransferAddendaCategory.Freeform,
            Freeform = new([new("addendum")]),
            PaymentOrderRemittanceAdvice = new(
                [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }]
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::AchTransferAddenda>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::AchTransferAddenda
        {
            Category = AchTransfers::AchTransferAddendaCategory.Freeform,
            Freeform = new([new("addendum")]),
            PaymentOrderRemittanceAdvice = new(
                [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }]
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::AchTransferAddenda>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AchTransfers::AchTransferAddendaCategory> expectedCategory =
            AchTransfers::AchTransferAddendaCategory.Freeform;
        AchTransfers::AchTransferAddendaFreeform expectedFreeform = new([new("addendum")]);
        AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdvice expectedPaymentOrderRemittanceAdvice =
            new([new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }]);

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedFreeform, deserialized.Freeform);
        Assert.Equal(
            expectedPaymentOrderRemittanceAdvice,
            deserialized.PaymentOrderRemittanceAdvice
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::AchTransferAddenda
        {
            Category = AchTransfers::AchTransferAddendaCategory.Freeform,
            Freeform = new([new("addendum")]),
            PaymentOrderRemittanceAdvice = new(
                [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }]
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AchTransfers::AchTransferAddenda
        {
            Category = AchTransfers::AchTransferAddendaCategory.Freeform,
        };

        Assert.Null(model.Freeform);
        Assert.False(model.RawData.ContainsKey("freeform"));
        Assert.Null(model.PaymentOrderRemittanceAdvice);
        Assert.False(model.RawData.ContainsKey("payment_order_remittance_advice"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AchTransfers::AchTransferAddenda
        {
            Category = AchTransfers::AchTransferAddendaCategory.Freeform,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AchTransfers::AchTransferAddenda
        {
            Category = AchTransfers::AchTransferAddendaCategory.Freeform,

            Freeform = null,
            PaymentOrderRemittanceAdvice = null,
        };

        Assert.Null(model.Freeform);
        Assert.True(model.RawData.ContainsKey("freeform"));
        Assert.Null(model.PaymentOrderRemittanceAdvice);
        Assert.True(model.RawData.ContainsKey("payment_order_remittance_advice"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AchTransfers::AchTransferAddenda
        {
            Category = AchTransfers::AchTransferAddendaCategory.Freeform,

            Freeform = null,
            PaymentOrderRemittanceAdvice = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::AchTransferAddenda
        {
            Category = AchTransfers::AchTransferAddendaCategory.Freeform,
            Freeform = new([new("addendum")]),
            PaymentOrderRemittanceAdvice = new(
                [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }]
            ),
        };

        AchTransfers::AchTransferAddenda copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AchTransferAddendaCategoryTest : TestBase
{
    [Theory]
    [InlineData(AchTransfers::AchTransferAddendaCategory.Freeform)]
    [InlineData(AchTransfers::AchTransferAddendaCategory.PaymentOrderRemittanceAdvice)]
    [InlineData(AchTransfers::AchTransferAddendaCategory.Other)]
    public void Validation_Works(AchTransfers::AchTransferAddendaCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::AchTransferAddendaCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferAddendaCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchTransfers::AchTransferAddendaCategory.Freeform)]
    [InlineData(AchTransfers::AchTransferAddendaCategory.PaymentOrderRemittanceAdvice)]
    [InlineData(AchTransfers::AchTransferAddendaCategory.Other)]
    public void SerializationRoundtrip_Works(AchTransfers::AchTransferAddendaCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::AchTransferAddendaCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferAddendaCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferAddendaCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferAddendaCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AchTransferAddendaFreeformTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::AchTransferAddendaFreeform
        {
            Entries = [new("payment_related_information")],
        };

        List<AchTransfers::AchTransferAddendaFreeformEntry> expectedEntries =
        [
            new("payment_related_information"),
        ];

        Assert.Equal(expectedEntries.Count, model.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.Equal(expectedEntries[i], model.Entries[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::AchTransferAddendaFreeform
        {
            Entries = [new("payment_related_information")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::AchTransferAddendaFreeform>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::AchTransferAddendaFreeform
        {
            Entries = [new("payment_related_information")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::AchTransferAddendaFreeform>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AchTransfers::AchTransferAddendaFreeformEntry> expectedEntries =
        [
            new("payment_related_information"),
        ];

        Assert.Equal(expectedEntries.Count, deserialized.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.Equal(expectedEntries[i], deserialized.Entries[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::AchTransferAddendaFreeform
        {
            Entries = [new("payment_related_information")],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::AchTransferAddendaFreeform
        {
            Entries = [new("payment_related_information")],
        };

        AchTransfers::AchTransferAddendaFreeform copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AchTransferAddendaFreeformEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::AchTransferAddendaFreeformEntry
        {
            PaymentRelatedInformation = "payment_related_information",
        };

        string expectedPaymentRelatedInformation = "payment_related_information";

        Assert.Equal(expectedPaymentRelatedInformation, model.PaymentRelatedInformation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::AchTransferAddendaFreeformEntry
        {
            PaymentRelatedInformation = "payment_related_information",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AchTransfers::AchTransferAddendaFreeformEntry>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::AchTransferAddendaFreeformEntry
        {
            PaymentRelatedInformation = "payment_related_information",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AchTransfers::AchTransferAddendaFreeformEntry>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedPaymentRelatedInformation = "payment_related_information";

        Assert.Equal(expectedPaymentRelatedInformation, deserialized.PaymentRelatedInformation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::AchTransferAddendaFreeformEntry
        {
            PaymentRelatedInformation = "payment_related_information",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::AchTransferAddendaFreeformEntry
        {
            PaymentRelatedInformation = "payment_related_information",
        };

        AchTransfers::AchTransferAddendaFreeformEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AchTransferAddendaPaymentOrderRemittanceAdviceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdvice
        {
            Invoices = [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }],
        };

        List<AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdviceInvoice> expectedInvoices =
        [
            new() { InvoiceNumber = "invoice_number", PaidAmount = 0 },
        ];

        Assert.Equal(expectedInvoices.Count, model.Invoices.Count);
        for (int i = 0; i < expectedInvoices.Count; i++)
        {
            Assert.Equal(expectedInvoices[i], model.Invoices[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdvice
        {
            Invoices = [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdvice>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdvice
        {
            Invoices = [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdvice>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdviceInvoice> expectedInvoices =
        [
            new() { InvoiceNumber = "invoice_number", PaidAmount = 0 },
        ];

        Assert.Equal(expectedInvoices.Count, deserialized.Invoices.Count);
        for (int i = 0; i < expectedInvoices.Count; i++)
        {
            Assert.Equal(expectedInvoices[i], deserialized.Invoices[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdvice
        {
            Invoices = [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdvice
        {
            Invoices = [new() { InvoiceNumber = "invoice_number", PaidAmount = 0 }],
        };

        AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdvice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AchTransferAddendaPaymentOrderRemittanceAdviceInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdviceInvoice
        {
            InvoiceNumber = "invoice_number",
            PaidAmount = 0,
        };

        string expectedInvoiceNumber = "invoice_number";
        long expectedPaidAmount = 0;

        Assert.Equal(expectedInvoiceNumber, model.InvoiceNumber);
        Assert.Equal(expectedPaidAmount, model.PaidAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdviceInvoice
        {
            InvoiceNumber = "invoice_number",
            PaidAmount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdviceInvoice>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdviceInvoice
        {
            InvoiceNumber = "invoice_number",
            PaidAmount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdviceInvoice>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedInvoiceNumber = "invoice_number";
        long expectedPaidAmount = 0;

        Assert.Equal(expectedInvoiceNumber, deserialized.InvoiceNumber);
        Assert.Equal(expectedPaidAmount, deserialized.PaidAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdviceInvoice
        {
            InvoiceNumber = "invoice_number",
            PaidAmount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdviceInvoice
        {
            InvoiceNumber = "invoice_number",
            PaidAmount = 0,
        };

        AchTransfers::AchTransferAddendaPaymentOrderRemittanceAdviceInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ApprovalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        DateTimeOffset expectedApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedApprovedAt, model.ApprovedAt);
        Assert.Null(model.ApprovedBy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::Approval>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::Approval>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedApprovedAt, deserialized.ApprovedAt);
        Assert.Null(deserialized.ApprovedBy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        AchTransfers::Approval copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        DateTimeOffset expectedCanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Null(model.CanceledBy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::Cancellation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::Cancellation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Null(deserialized.CanceledBy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        AchTransfers::Cancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreatedByTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::CreatedBy
        {
            Category = AchTransfers::CreatedByCategory.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        ApiEnum<string, AchTransfers::CreatedByCategory> expectedCategory =
            AchTransfers::CreatedByCategory.User;
        AchTransfers::ApiKey expectedApiKey = new("description");
        AchTransfers::OAuthApplication expectedOAuthApplication = new("name");
        AchTransfers::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedOAuthApplication, model.OAuthApplication);
        Assert.Equal(expectedUser, model.User);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::CreatedBy
        {
            Category = AchTransfers::CreatedByCategory.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::CreatedBy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::CreatedBy
        {
            Category = AchTransfers::CreatedByCategory.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::CreatedBy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AchTransfers::CreatedByCategory> expectedCategory =
            AchTransfers::CreatedByCategory.User;
        AchTransfers::ApiKey expectedApiKey = new("description");
        AchTransfers::OAuthApplication expectedOAuthApplication = new("name");
        AchTransfers::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedOAuthApplication, deserialized.OAuthApplication);
        Assert.Equal(expectedUser, deserialized.User);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::CreatedBy
        {
            Category = AchTransfers::CreatedByCategory.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AchTransfers::CreatedBy { Category = AchTransfers::CreatedByCategory.User };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("api_key"));
        Assert.Null(model.OAuthApplication);
        Assert.False(model.RawData.ContainsKey("oauth_application"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AchTransfers::CreatedBy { Category = AchTransfers::CreatedByCategory.User };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AchTransfers::CreatedBy
        {
            Category = AchTransfers::CreatedByCategory.User,

            ApiKey = null,
            OAuthApplication = null,
            User = null,
        };

        Assert.Null(model.ApiKey);
        Assert.True(model.RawData.ContainsKey("api_key"));
        Assert.Null(model.OAuthApplication);
        Assert.True(model.RawData.ContainsKey("oauth_application"));
        Assert.Null(model.User);
        Assert.True(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AchTransfers::CreatedBy
        {
            Category = AchTransfers::CreatedByCategory.User,

            ApiKey = null,
            OAuthApplication = null,
            User = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::CreatedBy
        {
            Category = AchTransfers::CreatedByCategory.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        AchTransfers::CreatedBy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreatedByCategoryTest : TestBase
{
    [Theory]
    [InlineData(AchTransfers::CreatedByCategory.ApiKey)]
    [InlineData(AchTransfers::CreatedByCategory.OAuthApplication)]
    [InlineData(AchTransfers::CreatedByCategory.User)]
    public void Validation_Works(AchTransfers::CreatedByCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::CreatedByCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::CreatedByCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchTransfers::CreatedByCategory.ApiKey)]
    [InlineData(AchTransfers::CreatedByCategory.OAuthApplication)]
    [InlineData(AchTransfers::CreatedByCategory.User)]
    public void SerializationRoundtrip_Works(AchTransfers::CreatedByCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::CreatedByCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::CreatedByCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::CreatedByCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::CreatedByCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ApiKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::ApiKey { Description = "description" };

        string expectedDescription = "description";

        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::ApiKey { Description = "description" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::ApiKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::ApiKey { Description = "description" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::ApiKey>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";

        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::ApiKey { Description = "description" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::ApiKey { Description = "description" };

        AchTransfers::ApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OAuthApplicationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::OAuthApplication { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::OAuthApplication { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::OAuthApplication>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::OAuthApplication { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::OAuthApplication>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::OAuthApplication { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::OAuthApplication { Name = "name" };

        AchTransfers::OAuthApplication copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::User { Email = "email" };

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::User { Email = "email" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::User>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::User { Email = "email" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::User>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, deserialized.Email);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::User { Email = "email" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::User { Email = "email" };

        AchTransfers::User copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(AchTransfers::Currency.Usd)]
    public void Validation_Works(AchTransfers::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchTransfers::Currency.Usd)]
    public void SerializationRoundtrip_Works(AchTransfers::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AchTransferDestinationAccountHolderTest : TestBase
{
    [Theory]
    [InlineData(AchTransfers::AchTransferDestinationAccountHolder.Business)]
    [InlineData(AchTransfers::AchTransferDestinationAccountHolder.Individual)]
    [InlineData(AchTransfers::AchTransferDestinationAccountHolder.Unknown)]
    public void Validation_Works(AchTransfers::AchTransferDestinationAccountHolder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::AchTransferDestinationAccountHolder> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferDestinationAccountHolder>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchTransfers::AchTransferDestinationAccountHolder.Business)]
    [InlineData(AchTransfers::AchTransferDestinationAccountHolder.Individual)]
    [InlineData(AchTransfers::AchTransferDestinationAccountHolder.Unknown)]
    public void SerializationRoundtrip_Works(
        AchTransfers::AchTransferDestinationAccountHolder rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::AchTransferDestinationAccountHolder> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferDestinationAccountHolder>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferDestinationAccountHolder>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferDestinationAccountHolder>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AchTransferFundingTest : TestBase
{
    [Theory]
    [InlineData(AchTransfers::AchTransferFunding.Checking)]
    [InlineData(AchTransfers::AchTransferFunding.Savings)]
    [InlineData(AchTransfers::AchTransferFunding.GeneralLedger)]
    public void Validation_Works(AchTransfers::AchTransferFunding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::AchTransferFunding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::AchTransferFunding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchTransfers::AchTransferFunding.Checking)]
    [InlineData(AchTransfers::AchTransferFunding.Savings)]
    [InlineData(AchTransfers::AchTransferFunding.GeneralLedger)]
    public void SerializationRoundtrip_Works(AchTransfers::AchTransferFunding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::AchTransferFunding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferFunding>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::AchTransferFunding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferFunding>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InboundFundsHoldTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::InboundFundsHold
        {
            Amount = 100,
            AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = AchTransfers::InboundFundsHoldCurrency.Usd,
            HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            ReleasedAt = null,
            Status = AchTransfers::InboundFundsHoldStatus.Held,
            Type = AchTransfers::Type.InboundFundsHold,
        };

        long expectedAmount = 100;
        DateTimeOffset expectedAutomaticallyReleasesAt = DateTimeOffset.Parse(
            "2020-01-31T23:59:59Z"
        );
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, AchTransfers::InboundFundsHoldCurrency> expectedCurrency =
            AchTransfers::InboundFundsHoldCurrency.Usd;
        string expectedHeldTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        string expectedPendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4";
        ApiEnum<string, AchTransfers::InboundFundsHoldStatus> expectedStatus =
            AchTransfers::InboundFundsHoldStatus.Held;
        ApiEnum<string, AchTransfers::Type> expectedType = AchTransfers::Type.InboundFundsHold;

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
        var model = new AchTransfers::InboundFundsHold
        {
            Amount = 100,
            AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = AchTransfers::InboundFundsHoldCurrency.Usd,
            HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            ReleasedAt = null,
            Status = AchTransfers::InboundFundsHoldStatus.Held,
            Type = AchTransfers::Type.InboundFundsHold,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::InboundFundsHold>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::InboundFundsHold
        {
            Amount = 100,
            AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = AchTransfers::InboundFundsHoldCurrency.Usd,
            HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            ReleasedAt = null,
            Status = AchTransfers::InboundFundsHoldStatus.Held,
            Type = AchTransfers::Type.InboundFundsHold,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::InboundFundsHold>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 100;
        DateTimeOffset expectedAutomaticallyReleasesAt = DateTimeOffset.Parse(
            "2020-01-31T23:59:59Z"
        );
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, AchTransfers::InboundFundsHoldCurrency> expectedCurrency =
            AchTransfers::InboundFundsHoldCurrency.Usd;
        string expectedHeldTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        string expectedPendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4";
        ApiEnum<string, AchTransfers::InboundFundsHoldStatus> expectedStatus =
            AchTransfers::InboundFundsHoldStatus.Held;
        ApiEnum<string, AchTransfers::Type> expectedType = AchTransfers::Type.InboundFundsHold;

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
        var model = new AchTransfers::InboundFundsHold
        {
            Amount = 100,
            AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = AchTransfers::InboundFundsHoldCurrency.Usd,
            HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            ReleasedAt = null,
            Status = AchTransfers::InboundFundsHoldStatus.Held,
            Type = AchTransfers::Type.InboundFundsHold,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::InboundFundsHold
        {
            Amount = 100,
            AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = AchTransfers::InboundFundsHoldCurrency.Usd,
            HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            ReleasedAt = null,
            Status = AchTransfers::InboundFundsHoldStatus.Held,
            Type = AchTransfers::Type.InboundFundsHold,
        };

        AchTransfers::InboundFundsHold copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InboundFundsHoldCurrencyTest : TestBase
{
    [Theory]
    [InlineData(AchTransfers::InboundFundsHoldCurrency.Usd)]
    public void Validation_Works(AchTransfers::InboundFundsHoldCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::InboundFundsHoldCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::InboundFundsHoldCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchTransfers::InboundFundsHoldCurrency.Usd)]
    public void SerializationRoundtrip_Works(AchTransfers::InboundFundsHoldCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::InboundFundsHoldCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::InboundFundsHoldCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::InboundFundsHoldCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::InboundFundsHoldCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InboundFundsHoldStatusTest : TestBase
{
    [Theory]
    [InlineData(AchTransfers::InboundFundsHoldStatus.Held)]
    [InlineData(AchTransfers::InboundFundsHoldStatus.Complete)]
    public void Validation_Works(AchTransfers::InboundFundsHoldStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::InboundFundsHoldStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::InboundFundsHoldStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchTransfers::InboundFundsHoldStatus.Held)]
    [InlineData(AchTransfers::InboundFundsHoldStatus.Complete)]
    public void SerializationRoundtrip_Works(AchTransfers::InboundFundsHoldStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::InboundFundsHoldStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::InboundFundsHoldStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::InboundFundsHoldStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::InboundFundsHoldStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(AchTransfers::Type.InboundFundsHold)]
    public void Validation_Works(AchTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchTransfers::Type.InboundFundsHold)]
    public void SerializationRoundtrip_Works(AchTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NetworkTest : TestBase
{
    [Theory]
    [InlineData(AchTransfers::Network.Ach)]
    public void Validation_Works(AchTransfers::Network rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::Network> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::Network>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchTransfers::Network.Ach)]
    public void SerializationRoundtrip_Works(AchTransfers::Network rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::Network> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::Network>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::Network>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::Network>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NotificationsOfChangeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::NotificationsOfChange
        {
            ChangeCode = AchTransfers::ChangeCode.IncorrectTransactionCode,
            CorrectedData = "32",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        ApiEnum<string, AchTransfers::ChangeCode> expectedChangeCode =
            AchTransfers::ChangeCode.IncorrectTransactionCode;
        string expectedCorrectedData = "32";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedChangeCode, model.ChangeCode);
        Assert.Equal(expectedCorrectedData, model.CorrectedData);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::NotificationsOfChange
        {
            ChangeCode = AchTransfers::ChangeCode.IncorrectTransactionCode,
            CorrectedData = "32",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::NotificationsOfChange>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::NotificationsOfChange
        {
            ChangeCode = AchTransfers::ChangeCode.IncorrectTransactionCode,
            CorrectedData = "32",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::NotificationsOfChange>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AchTransfers::ChangeCode> expectedChangeCode =
            AchTransfers::ChangeCode.IncorrectTransactionCode;
        string expectedCorrectedData = "32";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedChangeCode, deserialized.ChangeCode);
        Assert.Equal(expectedCorrectedData, deserialized.CorrectedData);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::NotificationsOfChange
        {
            ChangeCode = AchTransfers::ChangeCode.IncorrectTransactionCode,
            CorrectedData = "32",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::NotificationsOfChange
        {
            ChangeCode = AchTransfers::ChangeCode.IncorrectTransactionCode,
            CorrectedData = "32",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        AchTransfers::NotificationsOfChange copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChangeCodeTest : TestBase
{
    [Theory]
    [InlineData(AchTransfers::ChangeCode.IncorrectAccountNumber)]
    [InlineData(AchTransfers::ChangeCode.IncorrectRoutingNumber)]
    [InlineData(AchTransfers::ChangeCode.IncorrectRoutingNumberAndAccountNumber)]
    [InlineData(AchTransfers::ChangeCode.IncorrectTransactionCode)]
    [InlineData(AchTransfers::ChangeCode.IncorrectAccountNumberAndTransactionCode)]
    [InlineData(AchTransfers::ChangeCode.IncorrectRoutingNumberAccountNumberAndTransactionCode)]
    [InlineData(
        AchTransfers::ChangeCode.IncorrectReceivingDepositoryFinancialInstitutionIdentification
    )]
    [InlineData(AchTransfers::ChangeCode.IncorrectIndividualIdentificationNumber)]
    [InlineData(AchTransfers::ChangeCode.AddendaFormatError)]
    [InlineData(
        AchTransfers::ChangeCode.IncorrectStandardEntryClassCodeForOutboundInternationalPayment
    )]
    [InlineData(AchTransfers::ChangeCode.MisroutedNotificationOfChange)]
    [InlineData(AchTransfers::ChangeCode.IncorrectTraceNumber)]
    [InlineData(AchTransfers::ChangeCode.IncorrectCompanyIdentificationNumber)]
    [InlineData(AchTransfers::ChangeCode.IncorrectIdentificationNumber)]
    [InlineData(AchTransfers::ChangeCode.IncorrectlyFormattedCorrectedData)]
    [InlineData(AchTransfers::ChangeCode.IncorrectDiscretionaryData)]
    [InlineData(AchTransfers::ChangeCode.RoutingNumberNotFromOriginalEntryDetailRecord)]
    [InlineData(
        AchTransfers::ChangeCode.DepositoryFinancialInstitutionAccountNumberNotFromOriginalEntryDetailRecord
    )]
    [InlineData(
        AchTransfers::ChangeCode.IncorrectTransactionCodeByOriginatingDepositoryFinancialInstitution
    )]
    public void Validation_Works(AchTransfers::ChangeCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::ChangeCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::ChangeCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchTransfers::ChangeCode.IncorrectAccountNumber)]
    [InlineData(AchTransfers::ChangeCode.IncorrectRoutingNumber)]
    [InlineData(AchTransfers::ChangeCode.IncorrectRoutingNumberAndAccountNumber)]
    [InlineData(AchTransfers::ChangeCode.IncorrectTransactionCode)]
    [InlineData(AchTransfers::ChangeCode.IncorrectAccountNumberAndTransactionCode)]
    [InlineData(AchTransfers::ChangeCode.IncorrectRoutingNumberAccountNumberAndTransactionCode)]
    [InlineData(
        AchTransfers::ChangeCode.IncorrectReceivingDepositoryFinancialInstitutionIdentification
    )]
    [InlineData(AchTransfers::ChangeCode.IncorrectIndividualIdentificationNumber)]
    [InlineData(AchTransfers::ChangeCode.AddendaFormatError)]
    [InlineData(
        AchTransfers::ChangeCode.IncorrectStandardEntryClassCodeForOutboundInternationalPayment
    )]
    [InlineData(AchTransfers::ChangeCode.MisroutedNotificationOfChange)]
    [InlineData(AchTransfers::ChangeCode.IncorrectTraceNumber)]
    [InlineData(AchTransfers::ChangeCode.IncorrectCompanyIdentificationNumber)]
    [InlineData(AchTransfers::ChangeCode.IncorrectIdentificationNumber)]
    [InlineData(AchTransfers::ChangeCode.IncorrectlyFormattedCorrectedData)]
    [InlineData(AchTransfers::ChangeCode.IncorrectDiscretionaryData)]
    [InlineData(AchTransfers::ChangeCode.RoutingNumberNotFromOriginalEntryDetailRecord)]
    [InlineData(
        AchTransfers::ChangeCode.DepositoryFinancialInstitutionAccountNumberNotFromOriginalEntryDetailRecord
    )]
    [InlineData(
        AchTransfers::ChangeCode.IncorrectTransactionCodeByOriginatingDepositoryFinancialInstitution
    )]
    public void SerializationRoundtrip_Works(AchTransfers::ChangeCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::ChangeCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::ChangeCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::ChangeCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::ChangeCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AchTransferPreferredEffectiveDateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::AchTransferPreferredEffectiveDate
        {
            Date = "2019-12-27",
            SettlementSchedule =
                AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.SameDay,
        };

        string expectedDate = "2019-12-27";
        ApiEnum<
            string,
            AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule
        > expectedSettlementSchedule =
            AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.SameDay;

        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedSettlementSchedule, model.SettlementSchedule);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::AchTransferPreferredEffectiveDate
        {
            Date = "2019-12-27",
            SettlementSchedule =
                AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.SameDay,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AchTransfers::AchTransferPreferredEffectiveDate>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::AchTransferPreferredEffectiveDate
        {
            Date = "2019-12-27",
            SettlementSchedule =
                AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.SameDay,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AchTransfers::AchTransferPreferredEffectiveDate>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedDate = "2019-12-27";
        ApiEnum<
            string,
            AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule
        > expectedSettlementSchedule =
            AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.SameDay;

        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedSettlementSchedule, deserialized.SettlementSchedule);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::AchTransferPreferredEffectiveDate
        {
            Date = "2019-12-27",
            SettlementSchedule =
                AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.SameDay,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::AchTransferPreferredEffectiveDate
        {
            Date = "2019-12-27",
            SettlementSchedule =
                AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.SameDay,
        };

        AchTransfers::AchTransferPreferredEffectiveDate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AchTransferPreferredEffectiveDateSettlementScheduleTest : TestBase
{
    [Theory]
    [InlineData(AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.SameDay)]
    [InlineData(AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.FutureDated)]
    public void Validation_Works(
        AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.SameDay)]
    [InlineData(AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule.FutureDated)]
    public void SerializationRoundtrip_Works(
        AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferPreferredEffectiveDateSettlementSchedule>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ReturnTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::Return
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            RawReturnReasonCode = "R01",
            ReturnReasonCode = AchTransfers::ReturnReasonCode.InsufficientFund,
            TraceNumber = "111122223292834",
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedRawReturnReasonCode = "R01";
        ApiEnum<string, AchTransfers::ReturnReasonCode> expectedReturnReasonCode =
            AchTransfers::ReturnReasonCode.InsufficientFund;
        string expectedTraceNumber = "111122223292834";
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        string expectedTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedRawReturnReasonCode, model.RawReturnReasonCode);
        Assert.Equal(expectedReturnReasonCode, model.ReturnReasonCode);
        Assert.Equal(expectedTraceNumber, model.TraceNumber);
        Assert.Equal(expectedTransactionID, model.TransactionID);
        Assert.Equal(expectedTransferID, model.TransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::Return
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            RawReturnReasonCode = "R01",
            ReturnReasonCode = AchTransfers::ReturnReasonCode.InsufficientFund,
            TraceNumber = "111122223292834",
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::Return>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::Return
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            RawReturnReasonCode = "R01",
            ReturnReasonCode = AchTransfers::ReturnReasonCode.InsufficientFund,
            TraceNumber = "111122223292834",
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::Return>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedRawReturnReasonCode = "R01";
        ApiEnum<string, AchTransfers::ReturnReasonCode> expectedReturnReasonCode =
            AchTransfers::ReturnReasonCode.InsufficientFund;
        string expectedTraceNumber = "111122223292834";
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        string expectedTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedRawReturnReasonCode, deserialized.RawReturnReasonCode);
        Assert.Equal(expectedReturnReasonCode, deserialized.ReturnReasonCode);
        Assert.Equal(expectedTraceNumber, deserialized.TraceNumber);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
        Assert.Equal(expectedTransferID, deserialized.TransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::Return
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            RawReturnReasonCode = "R01",
            ReturnReasonCode = AchTransfers::ReturnReasonCode.InsufficientFund,
            TraceNumber = "111122223292834",
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::Return
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            RawReturnReasonCode = "R01",
            ReturnReasonCode = AchTransfers::ReturnReasonCode.InsufficientFund,
            TraceNumber = "111122223292834",
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        AchTransfers::Return copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReturnReasonCodeTest : TestBase
{
    [Theory]
    [InlineData(AchTransfers::ReturnReasonCode.InsufficientFund)]
    [InlineData(AchTransfers::ReturnReasonCode.NoAccount)]
    [InlineData(AchTransfers::ReturnReasonCode.AccountClosed)]
    [InlineData(AchTransfers::ReturnReasonCode.InvalidAccountNumberStructure)]
    [InlineData(AchTransfers::ReturnReasonCode.AccountFrozenEntryReturnedPerOfacInstruction)]
    [InlineData(AchTransfers::ReturnReasonCode.CreditEntryRefusedByReceiver)]
    [InlineData(
        AchTransfers::ReturnReasonCode.UnauthorizedDebitToConsumerAccountUsingCorporateSecCode
    )]
    [InlineData(AchTransfers::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized)]
    [InlineData(AchTransfers::ReturnReasonCode.PaymentStopped)]
    [InlineData(AchTransfers::ReturnReasonCode.NonTransactionAccount)]
    [InlineData(AchTransfers::ReturnReasonCode.UncollectedFunds)]
    [InlineData(AchTransfers::ReturnReasonCode.RoutingNumberCheckDigitError)]
    [InlineData(
        AchTransfers::ReturnReasonCode.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete
    )]
    [InlineData(AchTransfers::ReturnReasonCode.AmountFieldError)]
    [InlineData(AchTransfers::ReturnReasonCode.AuthorizationRevokedByCustomer)]
    [InlineData(AchTransfers::ReturnReasonCode.InvalidAchRoutingNumber)]
    [InlineData(AchTransfers::ReturnReasonCode.FileRecordEditCriteria)]
    [InlineData(AchTransfers::ReturnReasonCode.EnrInvalidIndividualName)]
    [InlineData(AchTransfers::ReturnReasonCode.ReturnedPerOdfiRequest)]
    [InlineData(AchTransfers::ReturnReasonCode.LimitedParticipationDfi)]
    [InlineData(AchTransfers::ReturnReasonCode.IncorrectlyCodedOutboundInternationalPayment)]
    [InlineData(AchTransfers::ReturnReasonCode.AccountSoldToAnotherDfi)]
    [InlineData(AchTransfers::ReturnReasonCode.AddendaError)]
    [InlineData(AchTransfers::ReturnReasonCode.BeneficiaryOrAccountHolderDeceased)]
    [InlineData(AchTransfers::ReturnReasonCode.CustomerAdvisedNotWithinAuthorizationTerms)]
    [InlineData(AchTransfers::ReturnReasonCode.CorrectedReturn)]
    [InlineData(AchTransfers::ReturnReasonCode.DuplicateEntry)]
    [InlineData(AchTransfers::ReturnReasonCode.DuplicateReturn)]
    [InlineData(AchTransfers::ReturnReasonCode.EnrDuplicateEnrollment)]
    [InlineData(AchTransfers::ReturnReasonCode.EnrInvalidDfiAccountNumber)]
    [InlineData(AchTransfers::ReturnReasonCode.EnrInvalidIndividualIDNumber)]
    [InlineData(AchTransfers::ReturnReasonCode.EnrInvalidRepresentativePayeeIndicator)]
    [InlineData(AchTransfers::ReturnReasonCode.EnrInvalidTransactionCode)]
    [InlineData(AchTransfers::ReturnReasonCode.EnrReturnOfEnrEntry)]
    [InlineData(AchTransfers::ReturnReasonCode.EnrRoutingNumberCheckDigitError)]
    [InlineData(AchTransfers::ReturnReasonCode.EntryNotProcessedByGateway)]
    [InlineData(AchTransfers::ReturnReasonCode.FieldError)]
    [InlineData(AchTransfers::ReturnReasonCode.ForeignReceivingDfiUnableToSettle)]
    [InlineData(AchTransfers::ReturnReasonCode.IatEntryCodingError)]
    [InlineData(AchTransfers::ReturnReasonCode.ImproperEffectiveEntryDate)]
    [InlineData(AchTransfers::ReturnReasonCode.ImproperSourceDocumentSourceDocumentPresented)]
    [InlineData(AchTransfers::ReturnReasonCode.InvalidCompanyID)]
    [InlineData(AchTransfers::ReturnReasonCode.InvalidForeignReceivingDfiIdentification)]
    [InlineData(AchTransfers::ReturnReasonCode.InvalidIndividualIDNumber)]
    [InlineData(AchTransfers::ReturnReasonCode.ItemAndRckEntryPresentedForPayment)]
    [InlineData(AchTransfers::ReturnReasonCode.ItemRelatedToRckEntryIsIneligible)]
    [InlineData(AchTransfers::ReturnReasonCode.MandatoryFieldError)]
    [InlineData(AchTransfers::ReturnReasonCode.MisroutedDishonoredReturn)]
    [InlineData(AchTransfers::ReturnReasonCode.MisroutedReturn)]
    [InlineData(AchTransfers::ReturnReasonCode.NoErrorsFound)]
    [InlineData(AchTransfers::ReturnReasonCode.NonAcceptanceOfR62DishonoredReturn)]
    [InlineData(AchTransfers::ReturnReasonCode.NonParticipantInIatProgram)]
    [InlineData(AchTransfers::ReturnReasonCode.PermissibleReturnEntry)]
    [InlineData(AchTransfers::ReturnReasonCode.PermissibleReturnEntryNotAccepted)]
    [InlineData(AchTransfers::ReturnReasonCode.RdfiNonSettlement)]
    [InlineData(AchTransfers::ReturnReasonCode.RdfiParticipantInCheckTruncationProgram)]
    [InlineData(
        AchTransfers::ReturnReasonCode.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity
    )]
    [InlineData(AchTransfers::ReturnReasonCode.ReturnNotADuplicate)]
    [InlineData(AchTransfers::ReturnReasonCode.ReturnOfErroneousOrReversingDebit)]
    [InlineData(AchTransfers::ReturnReasonCode.ReturnOfImproperCreditEntry)]
    [InlineData(AchTransfers::ReturnReasonCode.ReturnOfImproperDebitEntry)]
    [InlineData(AchTransfers::ReturnReasonCode.ReturnOfXckEntry)]
    [InlineData(AchTransfers::ReturnReasonCode.SourceDocumentPresentedForPayment)]
    [InlineData(AchTransfers::ReturnReasonCode.StateLawAffectingRckAcceptance)]
    [InlineData(AchTransfers::ReturnReasonCode.StopPaymentOnItemRelatedToRckEntry)]
    [InlineData(AchTransfers::ReturnReasonCode.StopPaymentOnSourceDocument)]
    [InlineData(AchTransfers::ReturnReasonCode.TimelyOriginalReturn)]
    [InlineData(AchTransfers::ReturnReasonCode.TraceNumberError)]
    [InlineData(AchTransfers::ReturnReasonCode.UntimelyDishonoredReturn)]
    [InlineData(AchTransfers::ReturnReasonCode.UntimelyReturn)]
    public void Validation_Works(AchTransfers::ReturnReasonCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::ReturnReasonCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::ReturnReasonCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchTransfers::ReturnReasonCode.InsufficientFund)]
    [InlineData(AchTransfers::ReturnReasonCode.NoAccount)]
    [InlineData(AchTransfers::ReturnReasonCode.AccountClosed)]
    [InlineData(AchTransfers::ReturnReasonCode.InvalidAccountNumberStructure)]
    [InlineData(AchTransfers::ReturnReasonCode.AccountFrozenEntryReturnedPerOfacInstruction)]
    [InlineData(AchTransfers::ReturnReasonCode.CreditEntryRefusedByReceiver)]
    [InlineData(
        AchTransfers::ReturnReasonCode.UnauthorizedDebitToConsumerAccountUsingCorporateSecCode
    )]
    [InlineData(AchTransfers::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized)]
    [InlineData(AchTransfers::ReturnReasonCode.PaymentStopped)]
    [InlineData(AchTransfers::ReturnReasonCode.NonTransactionAccount)]
    [InlineData(AchTransfers::ReturnReasonCode.UncollectedFunds)]
    [InlineData(AchTransfers::ReturnReasonCode.RoutingNumberCheckDigitError)]
    [InlineData(
        AchTransfers::ReturnReasonCode.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete
    )]
    [InlineData(AchTransfers::ReturnReasonCode.AmountFieldError)]
    [InlineData(AchTransfers::ReturnReasonCode.AuthorizationRevokedByCustomer)]
    [InlineData(AchTransfers::ReturnReasonCode.InvalidAchRoutingNumber)]
    [InlineData(AchTransfers::ReturnReasonCode.FileRecordEditCriteria)]
    [InlineData(AchTransfers::ReturnReasonCode.EnrInvalidIndividualName)]
    [InlineData(AchTransfers::ReturnReasonCode.ReturnedPerOdfiRequest)]
    [InlineData(AchTransfers::ReturnReasonCode.LimitedParticipationDfi)]
    [InlineData(AchTransfers::ReturnReasonCode.IncorrectlyCodedOutboundInternationalPayment)]
    [InlineData(AchTransfers::ReturnReasonCode.AccountSoldToAnotherDfi)]
    [InlineData(AchTransfers::ReturnReasonCode.AddendaError)]
    [InlineData(AchTransfers::ReturnReasonCode.BeneficiaryOrAccountHolderDeceased)]
    [InlineData(AchTransfers::ReturnReasonCode.CustomerAdvisedNotWithinAuthorizationTerms)]
    [InlineData(AchTransfers::ReturnReasonCode.CorrectedReturn)]
    [InlineData(AchTransfers::ReturnReasonCode.DuplicateEntry)]
    [InlineData(AchTransfers::ReturnReasonCode.DuplicateReturn)]
    [InlineData(AchTransfers::ReturnReasonCode.EnrDuplicateEnrollment)]
    [InlineData(AchTransfers::ReturnReasonCode.EnrInvalidDfiAccountNumber)]
    [InlineData(AchTransfers::ReturnReasonCode.EnrInvalidIndividualIDNumber)]
    [InlineData(AchTransfers::ReturnReasonCode.EnrInvalidRepresentativePayeeIndicator)]
    [InlineData(AchTransfers::ReturnReasonCode.EnrInvalidTransactionCode)]
    [InlineData(AchTransfers::ReturnReasonCode.EnrReturnOfEnrEntry)]
    [InlineData(AchTransfers::ReturnReasonCode.EnrRoutingNumberCheckDigitError)]
    [InlineData(AchTransfers::ReturnReasonCode.EntryNotProcessedByGateway)]
    [InlineData(AchTransfers::ReturnReasonCode.FieldError)]
    [InlineData(AchTransfers::ReturnReasonCode.ForeignReceivingDfiUnableToSettle)]
    [InlineData(AchTransfers::ReturnReasonCode.IatEntryCodingError)]
    [InlineData(AchTransfers::ReturnReasonCode.ImproperEffectiveEntryDate)]
    [InlineData(AchTransfers::ReturnReasonCode.ImproperSourceDocumentSourceDocumentPresented)]
    [InlineData(AchTransfers::ReturnReasonCode.InvalidCompanyID)]
    [InlineData(AchTransfers::ReturnReasonCode.InvalidForeignReceivingDfiIdentification)]
    [InlineData(AchTransfers::ReturnReasonCode.InvalidIndividualIDNumber)]
    [InlineData(AchTransfers::ReturnReasonCode.ItemAndRckEntryPresentedForPayment)]
    [InlineData(AchTransfers::ReturnReasonCode.ItemRelatedToRckEntryIsIneligible)]
    [InlineData(AchTransfers::ReturnReasonCode.MandatoryFieldError)]
    [InlineData(AchTransfers::ReturnReasonCode.MisroutedDishonoredReturn)]
    [InlineData(AchTransfers::ReturnReasonCode.MisroutedReturn)]
    [InlineData(AchTransfers::ReturnReasonCode.NoErrorsFound)]
    [InlineData(AchTransfers::ReturnReasonCode.NonAcceptanceOfR62DishonoredReturn)]
    [InlineData(AchTransfers::ReturnReasonCode.NonParticipantInIatProgram)]
    [InlineData(AchTransfers::ReturnReasonCode.PermissibleReturnEntry)]
    [InlineData(AchTransfers::ReturnReasonCode.PermissibleReturnEntryNotAccepted)]
    [InlineData(AchTransfers::ReturnReasonCode.RdfiNonSettlement)]
    [InlineData(AchTransfers::ReturnReasonCode.RdfiParticipantInCheckTruncationProgram)]
    [InlineData(
        AchTransfers::ReturnReasonCode.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity
    )]
    [InlineData(AchTransfers::ReturnReasonCode.ReturnNotADuplicate)]
    [InlineData(AchTransfers::ReturnReasonCode.ReturnOfErroneousOrReversingDebit)]
    [InlineData(AchTransfers::ReturnReasonCode.ReturnOfImproperCreditEntry)]
    [InlineData(AchTransfers::ReturnReasonCode.ReturnOfImproperDebitEntry)]
    [InlineData(AchTransfers::ReturnReasonCode.ReturnOfXckEntry)]
    [InlineData(AchTransfers::ReturnReasonCode.SourceDocumentPresentedForPayment)]
    [InlineData(AchTransfers::ReturnReasonCode.StateLawAffectingRckAcceptance)]
    [InlineData(AchTransfers::ReturnReasonCode.StopPaymentOnItemRelatedToRckEntry)]
    [InlineData(AchTransfers::ReturnReasonCode.StopPaymentOnSourceDocument)]
    [InlineData(AchTransfers::ReturnReasonCode.TimelyOriginalReturn)]
    [InlineData(AchTransfers::ReturnReasonCode.TraceNumberError)]
    [InlineData(AchTransfers::ReturnReasonCode.UntimelyDishonoredReturn)]
    [InlineData(AchTransfers::ReturnReasonCode.UntimelyReturn)]
    public void SerializationRoundtrip_Works(AchTransfers::ReturnReasonCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::ReturnReasonCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::ReturnReasonCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::ReturnReasonCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::ReturnReasonCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SettlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::Settlement
        {
            SettledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedSettledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedSettledAt, model.SettledAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::Settlement
        {
            SettledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::Settlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::Settlement
        {
            SettledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::Settlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedSettledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedSettledAt, deserialized.SettledAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::Settlement
        {
            SettledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::Settlement
        {
            SettledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        AchTransfers::Settlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AchTransferStandardEntryClassCodeTest : TestBase
{
    [Theory]
    [InlineData(AchTransfers::AchTransferStandardEntryClassCode.CorporateCreditOrDebit)]
    [InlineData(AchTransfers::AchTransferStandardEntryClassCode.CorporateTradeExchange)]
    [InlineData(AchTransfers::AchTransferStandardEntryClassCode.PrearrangedPaymentsAndDeposit)]
    [InlineData(AchTransfers::AchTransferStandardEntryClassCode.InternetInitiated)]
    public void Validation_Works(AchTransfers::AchTransferStandardEntryClassCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::AchTransferStandardEntryClassCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferStandardEntryClassCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchTransfers::AchTransferStandardEntryClassCode.CorporateCreditOrDebit)]
    [InlineData(AchTransfers::AchTransferStandardEntryClassCode.CorporateTradeExchange)]
    [InlineData(AchTransfers::AchTransferStandardEntryClassCode.PrearrangedPaymentsAndDeposit)]
    [InlineData(AchTransfers::AchTransferStandardEntryClassCode.InternetInitiated)]
    public void SerializationRoundtrip_Works(
        AchTransfers::AchTransferStandardEntryClassCode rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::AchTransferStandardEntryClassCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferStandardEntryClassCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferStandardEntryClassCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferStandardEntryClassCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AchTransferStatusTest : TestBase
{
    [Theory]
    [InlineData(AchTransfers::AchTransferStatus.PendingApproval)]
    [InlineData(AchTransfers::AchTransferStatus.PendingTransferSessionConfirmation)]
    [InlineData(AchTransfers::AchTransferStatus.Canceled)]
    [InlineData(AchTransfers::AchTransferStatus.PendingSubmission)]
    [InlineData(AchTransfers::AchTransferStatus.PendingReviewing)]
    [InlineData(AchTransfers::AchTransferStatus.RequiresAttention)]
    [InlineData(AchTransfers::AchTransferStatus.Rejected)]
    [InlineData(AchTransfers::AchTransferStatus.Submitted)]
    [InlineData(AchTransfers::AchTransferStatus.Returned)]
    public void Validation_Works(AchTransfers::AchTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::AchTransferStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::AchTransferStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchTransfers::AchTransferStatus.PendingApproval)]
    [InlineData(AchTransfers::AchTransferStatus.PendingTransferSessionConfirmation)]
    [InlineData(AchTransfers::AchTransferStatus.Canceled)]
    [InlineData(AchTransfers::AchTransferStatus.PendingSubmission)]
    [InlineData(AchTransfers::AchTransferStatus.PendingReviewing)]
    [InlineData(AchTransfers::AchTransferStatus.RequiresAttention)]
    [InlineData(AchTransfers::AchTransferStatus.Rejected)]
    [InlineData(AchTransfers::AchTransferStatus.Submitted)]
    [InlineData(AchTransfers::AchTransferStatus.Returned)]
    public void SerializationRoundtrip_Works(AchTransfers::AchTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::AchTransferStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::AchTransferStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubmissionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::Submission
        {
            AdministrativeReturnsExpectedBy = DateTimeOffset.Parse("2020-02-05T11:00:00Z"),
            EffectiveDate = "2020-01-31",
            ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
            ExpectedSettlementSchedule = AchTransfers::ExpectedSettlementSchedule.FutureDated,
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "058349238292834",
        };

        DateTimeOffset expectedAdministrativeReturnsExpectedBy = DateTimeOffset.Parse(
            "2020-02-05T11:00:00Z"
        );
        string expectedEffectiveDate = "2020-01-31";
        DateTimeOffset expectedExpectedFundsSettlementAt = DateTimeOffset.Parse(
            "2020-02-03T13:30:00Z"
        );
        ApiEnum<
            string,
            AchTransfers::ExpectedSettlementSchedule
        > expectedExpectedSettlementSchedule = AchTransfers::ExpectedSettlementSchedule.FutureDated;
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedTraceNumber = "058349238292834";

        Assert.Equal(
            expectedAdministrativeReturnsExpectedBy,
            model.AdministrativeReturnsExpectedBy
        );
        Assert.Equal(expectedEffectiveDate, model.EffectiveDate);
        Assert.Equal(expectedExpectedFundsSettlementAt, model.ExpectedFundsSettlementAt);
        Assert.Equal(expectedExpectedSettlementSchedule, model.ExpectedSettlementSchedule);
        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
        Assert.Equal(expectedTraceNumber, model.TraceNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchTransfers::Submission
        {
            AdministrativeReturnsExpectedBy = DateTimeOffset.Parse("2020-02-05T11:00:00Z"),
            EffectiveDate = "2020-01-31",
            ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
            ExpectedSettlementSchedule = AchTransfers::ExpectedSettlementSchedule.FutureDated,
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "058349238292834",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::Submission>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::Submission
        {
            AdministrativeReturnsExpectedBy = DateTimeOffset.Parse("2020-02-05T11:00:00Z"),
            EffectiveDate = "2020-01-31",
            ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
            ExpectedSettlementSchedule = AchTransfers::ExpectedSettlementSchedule.FutureDated,
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "058349238292834",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::Submission>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAdministrativeReturnsExpectedBy = DateTimeOffset.Parse(
            "2020-02-05T11:00:00Z"
        );
        string expectedEffectiveDate = "2020-01-31";
        DateTimeOffset expectedExpectedFundsSettlementAt = DateTimeOffset.Parse(
            "2020-02-03T13:30:00Z"
        );
        ApiEnum<
            string,
            AchTransfers::ExpectedSettlementSchedule
        > expectedExpectedSettlementSchedule = AchTransfers::ExpectedSettlementSchedule.FutureDated;
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedTraceNumber = "058349238292834";

        Assert.Equal(
            expectedAdministrativeReturnsExpectedBy,
            deserialized.AdministrativeReturnsExpectedBy
        );
        Assert.Equal(expectedEffectiveDate, deserialized.EffectiveDate);
        Assert.Equal(expectedExpectedFundsSettlementAt, deserialized.ExpectedFundsSettlementAt);
        Assert.Equal(expectedExpectedSettlementSchedule, deserialized.ExpectedSettlementSchedule);
        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
        Assert.Equal(expectedTraceNumber, deserialized.TraceNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchTransfers::Submission
        {
            AdministrativeReturnsExpectedBy = DateTimeOffset.Parse("2020-02-05T11:00:00Z"),
            EffectiveDate = "2020-01-31",
            ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
            ExpectedSettlementSchedule = AchTransfers::ExpectedSettlementSchedule.FutureDated,
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "058349238292834",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::Submission
        {
            AdministrativeReturnsExpectedBy = DateTimeOffset.Parse("2020-02-05T11:00:00Z"),
            EffectiveDate = "2020-01-31",
            ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
            ExpectedSettlementSchedule = AchTransfers::ExpectedSettlementSchedule.FutureDated,
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "058349238292834",
        };

        AchTransfers::Submission copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExpectedSettlementScheduleTest : TestBase
{
    [Theory]
    [InlineData(AchTransfers::ExpectedSettlementSchedule.SameDay)]
    [InlineData(AchTransfers::ExpectedSettlementSchedule.FutureDated)]
    public void Validation_Works(AchTransfers::ExpectedSettlementSchedule rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::ExpectedSettlementSchedule> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::ExpectedSettlementSchedule>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchTransfers::ExpectedSettlementSchedule.SameDay)]
    [InlineData(AchTransfers::ExpectedSettlementSchedule.FutureDated)]
    public void SerializationRoundtrip_Works(AchTransfers::ExpectedSettlementSchedule rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::ExpectedSettlementSchedule> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::ExpectedSettlementSchedule>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::ExpectedSettlementSchedule>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::ExpectedSettlementSchedule>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AchTransferTypeTest : TestBase
{
    [Theory]
    [InlineData(AchTransfers::AchTransferType.AchTransfer)]
    public void Validation_Works(AchTransfers::AchTransferType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::AchTransferType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::AchTransferType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchTransfers::AchTransferType.AchTransfer)]
    public void SerializationRoundtrip_Works(AchTransfers::AchTransferType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchTransfers::AchTransferType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchTransfers::AchTransferType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchTransfers::AchTransferType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
