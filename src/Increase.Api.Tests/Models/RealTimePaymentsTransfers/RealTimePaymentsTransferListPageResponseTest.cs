using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using RealTimePaymentsTransfers = Increase.Api.Models.RealTimePaymentsTransfers;

namespace Increase.Api.Tests.Models.RealTimePaymentsTransfers;

public class RealTimePaymentsTransferListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::RealTimePaymentsTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumber = "987654321",
                    Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
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
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = RealTimePaymentsTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    CreditorName = "Ian Crease",
                    Currency = RealTimePaymentsTransfers::Currency.Usd,
                    DebtorName = null,
                    ExternalAccountID = null,
                    IdempotencyKey = null,
                    PendingTransactionID = null,
                    Rejection = new()
                    {
                        RejectReasonAdditionalInformation = null,
                        RejectReasonCode =
                            RealTimePaymentsTransfers::RejectReasonCode.AccountClosed,
                        RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    },
                    RoutingNumber = "101050001",
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Complete,
                    Submission = new()
                    {
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                    },
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = RealTimePaymentsTransfers::Type.RealTimePaymentsTransfer,
                    UltimateCreditorName = null,
                    UltimateDebtorName = null,
                    UnstructuredRemittanceInformation = "Invoice 29582",
                },
            ],
            NextCursor = "v57w5d",
        };

        List<RealTimePaymentsTransfers::RealTimePaymentsTransfer> expectedData =
        [
            new()
            {
                ID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumber = "987654321",
                Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
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
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedBy = new()
                {
                    Category = RealTimePaymentsTransfers::Category.User,
                    ApiKey = new("description"),
                    OAuthApplication = new("name"),
                    User = new("user@example.com"),
                },
                CreditorName = "Ian Crease",
                Currency = RealTimePaymentsTransfers::Currency.Usd,
                DebtorName = null,
                ExternalAccountID = null,
                IdempotencyKey = null,
                PendingTransactionID = null,
                Rejection = new()
                {
                    RejectReasonAdditionalInformation = null,
                    RejectReasonCode = RealTimePaymentsTransfers::RejectReasonCode.AccountClosed,
                    RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
                RoutingNumber = "101050001",
                SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Status = RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Complete,
                Submission = new()
                {
                    SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                },
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                Type = RealTimePaymentsTransfers::Type.RealTimePaymentsTransfer,
                UltimateCreditorName = null,
                UltimateDebtorName = null,
                UnstructuredRemittanceInformation = "Invoice 29582",
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
        var model = new RealTimePaymentsTransfers::RealTimePaymentsTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumber = "987654321",
                    Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
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
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = RealTimePaymentsTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    CreditorName = "Ian Crease",
                    Currency = RealTimePaymentsTransfers::Currency.Usd,
                    DebtorName = null,
                    ExternalAccountID = null,
                    IdempotencyKey = null,
                    PendingTransactionID = null,
                    Rejection = new()
                    {
                        RejectReasonAdditionalInformation = null,
                        RejectReasonCode =
                            RealTimePaymentsTransfers::RejectReasonCode.AccountClosed,
                        RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    },
                    RoutingNumber = "101050001",
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Complete,
                    Submission = new()
                    {
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                    },
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = RealTimePaymentsTransfers::Type.RealTimePaymentsTransfer,
                    UltimateCreditorName = null,
                    UltimateDebtorName = null,
                    UnstructuredRemittanceInformation = "Invoice 29582",
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsTransfers::RealTimePaymentsTransferListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsTransfers::RealTimePaymentsTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumber = "987654321",
                    Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
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
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = RealTimePaymentsTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    CreditorName = "Ian Crease",
                    Currency = RealTimePaymentsTransfers::Currency.Usd,
                    DebtorName = null,
                    ExternalAccountID = null,
                    IdempotencyKey = null,
                    PendingTransactionID = null,
                    Rejection = new()
                    {
                        RejectReasonAdditionalInformation = null,
                        RejectReasonCode =
                            RealTimePaymentsTransfers::RejectReasonCode.AccountClosed,
                        RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    },
                    RoutingNumber = "101050001",
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Complete,
                    Submission = new()
                    {
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                    },
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = RealTimePaymentsTransfers::Type.RealTimePaymentsTransfer,
                    UltimateCreditorName = null,
                    UltimateDebtorName = null,
                    UnstructuredRemittanceInformation = "Invoice 29582",
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsTransfers::RealTimePaymentsTransferListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<RealTimePaymentsTransfers::RealTimePaymentsTransfer> expectedData =
        [
            new()
            {
                ID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumber = "987654321",
                Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
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
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedBy = new()
                {
                    Category = RealTimePaymentsTransfers::Category.User,
                    ApiKey = new("description"),
                    OAuthApplication = new("name"),
                    User = new("user@example.com"),
                },
                CreditorName = "Ian Crease",
                Currency = RealTimePaymentsTransfers::Currency.Usd,
                DebtorName = null,
                ExternalAccountID = null,
                IdempotencyKey = null,
                PendingTransactionID = null,
                Rejection = new()
                {
                    RejectReasonAdditionalInformation = null,
                    RejectReasonCode = RealTimePaymentsTransfers::RejectReasonCode.AccountClosed,
                    RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
                RoutingNumber = "101050001",
                SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Status = RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Complete,
                Submission = new()
                {
                    SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                },
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                Type = RealTimePaymentsTransfers::Type.RealTimePaymentsTransfer,
                UltimateCreditorName = null,
                UltimateDebtorName = null,
                UnstructuredRemittanceInformation = "Invoice 29582",
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
        var model = new RealTimePaymentsTransfers::RealTimePaymentsTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumber = "987654321",
                    Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
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
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = RealTimePaymentsTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    CreditorName = "Ian Crease",
                    Currency = RealTimePaymentsTransfers::Currency.Usd,
                    DebtorName = null,
                    ExternalAccountID = null,
                    IdempotencyKey = null,
                    PendingTransactionID = null,
                    Rejection = new()
                    {
                        RejectReasonAdditionalInformation = null,
                        RejectReasonCode =
                            RealTimePaymentsTransfers::RejectReasonCode.AccountClosed,
                        RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    },
                    RoutingNumber = "101050001",
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Complete,
                    Submission = new()
                    {
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                    },
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = RealTimePaymentsTransfers::Type.RealTimePaymentsTransfer,
                    UltimateCreditorName = null,
                    UltimateDebtorName = null,
                    UnstructuredRemittanceInformation = "Invoice 29582",
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsTransfers::RealTimePaymentsTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumber = "987654321",
                    Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
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
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = RealTimePaymentsTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    CreditorName = "Ian Crease",
                    Currency = RealTimePaymentsTransfers::Currency.Usd,
                    DebtorName = null,
                    ExternalAccountID = null,
                    IdempotencyKey = null,
                    PendingTransactionID = null,
                    Rejection = new()
                    {
                        RejectReasonAdditionalInformation = null,
                        RejectReasonCode =
                            RealTimePaymentsTransfers::RejectReasonCode.AccountClosed,
                        RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    },
                    RoutingNumber = "101050001",
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Complete,
                    Submission = new()
                    {
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                    },
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = RealTimePaymentsTransfers::Type.RealTimePaymentsTransfer,
                    UltimateCreditorName = null,
                    UltimateDebtorName = null,
                    UnstructuredRemittanceInformation = "Invoice 29582",
                },
            ],
            NextCursor = "v57w5d",
        };

        RealTimePaymentsTransfers::RealTimePaymentsTransferListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
