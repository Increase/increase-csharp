using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using AchTransfers = Increase.Api.Models.AchTransfers;

namespace Increase.Api.Tests.Models.AchTransfers;

public class AchTransferListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchTransfers::AchTransferListPageResponse
        {
            Data =
            [
                new()
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
                    DestinationAccountHolder =
                        AchTransfers::AchTransferDestinationAccountHolder.Business,
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
                        AdministrativeReturnsExpectedBy = DateTimeOffset.Parse(
                            "2020-02-05T11:00:00Z"
                        ),
                        EffectiveDate = "2020-01-31",
                        ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
                        ExpectedSettlementSchedule =
                            AchTransfers::ExpectedSettlementSchedule.FutureDated,
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TraceNumber = "058349238292834",
                    },
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = AchTransfers::AchTransferType.AchTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<AchTransfers::AchTransfer> expectedData =
        [
            new()
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
                DestinationAccountHolder =
                    AchTransfers::AchTransferDestinationAccountHolder.Business,
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
                    ExpectedSettlementSchedule =
                        AchTransfers::ExpectedSettlementSchedule.FutureDated,
                    SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TraceNumber = "058349238292834",
                },
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                Type = AchTransfers::AchTransferType.AchTransfer,
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
        var model = new AchTransfers::AchTransferListPageResponse
        {
            Data =
            [
                new()
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
                    DestinationAccountHolder =
                        AchTransfers::AchTransferDestinationAccountHolder.Business,
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
                        AdministrativeReturnsExpectedBy = DateTimeOffset.Parse(
                            "2020-02-05T11:00:00Z"
                        ),
                        EffectiveDate = "2020-01-31",
                        ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
                        ExpectedSettlementSchedule =
                            AchTransfers::ExpectedSettlementSchedule.FutureDated,
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TraceNumber = "058349238292834",
                    },
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = AchTransfers::AchTransferType.AchTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::AchTransferListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchTransfers::AchTransferListPageResponse
        {
            Data =
            [
                new()
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
                    DestinationAccountHolder =
                        AchTransfers::AchTransferDestinationAccountHolder.Business,
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
                        AdministrativeReturnsExpectedBy = DateTimeOffset.Parse(
                            "2020-02-05T11:00:00Z"
                        ),
                        EffectiveDate = "2020-01-31",
                        ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
                        ExpectedSettlementSchedule =
                            AchTransfers::ExpectedSettlementSchedule.FutureDated,
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TraceNumber = "058349238292834",
                    },
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = AchTransfers::AchTransferType.AchTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchTransfers::AchTransferListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AchTransfers::AchTransfer> expectedData =
        [
            new()
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
                DestinationAccountHolder =
                    AchTransfers::AchTransferDestinationAccountHolder.Business,
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
                    ExpectedSettlementSchedule =
                        AchTransfers::ExpectedSettlementSchedule.FutureDated,
                    SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TraceNumber = "058349238292834",
                },
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                Type = AchTransfers::AchTransferType.AchTransfer,
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
        var model = new AchTransfers::AchTransferListPageResponse
        {
            Data =
            [
                new()
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
                    DestinationAccountHolder =
                        AchTransfers::AchTransferDestinationAccountHolder.Business,
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
                        AdministrativeReturnsExpectedBy = DateTimeOffset.Parse(
                            "2020-02-05T11:00:00Z"
                        ),
                        EffectiveDate = "2020-01-31",
                        ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
                        ExpectedSettlementSchedule =
                            AchTransfers::ExpectedSettlementSchedule.FutureDated,
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TraceNumber = "058349238292834",
                    },
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = AchTransfers::AchTransferType.AchTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchTransfers::AchTransferListPageResponse
        {
            Data =
            [
                new()
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
                    DestinationAccountHolder =
                        AchTransfers::AchTransferDestinationAccountHolder.Business,
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
                        AdministrativeReturnsExpectedBy = DateTimeOffset.Parse(
                            "2020-02-05T11:00:00Z"
                        ),
                        EffectiveDate = "2020-01-31",
                        ExpectedFundsSettlementAt = DateTimeOffset.Parse("2020-02-03T13:30:00Z"),
                        ExpectedSettlementSchedule =
                            AchTransfers::ExpectedSettlementSchedule.FutureDated,
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TraceNumber = "058349238292834",
                    },
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = AchTransfers::AchTransferType.AchTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        AchTransfers::AchTransferListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
