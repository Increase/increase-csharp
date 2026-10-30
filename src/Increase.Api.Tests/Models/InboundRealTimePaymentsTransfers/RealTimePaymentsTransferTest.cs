using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.InboundRealTimePaymentsTransfers;

namespace Increase.Api.Tests.Models.InboundRealTimePaymentsTransfers;

public class RealTimePaymentsTransferTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfer
        {
            ID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T14:10:02Z")),
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ApprovedBy = "approved_by",
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T14:00:00Z"),
            CreatedBy = new()
            {
                Category = Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            CreditorName = "Ian Crease",
            Currency = RealTimePaymentsTransferCurrency.Usd,
            DebtorName = "National Phonograph Company",
            ExternalAccountID = null,
            IdempotencyKey = null,
            InboundRealTimePaymentsRequestForPaymentID = null,
            PendingTransactionID = null,
            Rejection = new()
            {
                RejectReasonAdditionalInformation = null,
                RejectReasonCode = RejectReasonCode.AccountClosed,
                RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            ReturnOfInboundRealTimePaymentsTransferID = null,
            RoutingNumber = "101050001",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Status = RealTimePaymentsTransferStatus.Complete,
            Submission = new()
            {
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T14:10:00Z"),
                TransactionIdentification = "20220501234567891T1BSLZO01745013025",
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = RealTimePaymentsTransferType.RealTimePaymentsTransfer,
            UltimateCreditorName = null,
            UltimateDebtorName = null,
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        string expectedID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumber = "987654321";
        Acknowledgement expectedAcknowledgement = new(DateTimeOffset.Parse("2020-01-31T14:10:02Z"));
        long expectedAmount = 100;
        Approval expectedApproval = new()
        {
            ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ApprovedBy = "approved_by",
        };
        Cancellation expectedCancellation = new()
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T14:00:00Z");
        CreatedBy expectedCreatedBy = new()
        {
            Category = Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        string expectedCreditorName = "Ian Crease";
        ApiEnum<string, RealTimePaymentsTransferCurrency> expectedCurrency =
            RealTimePaymentsTransferCurrency.Usd;
        string expectedDebtorName = "National Phonograph Company";
        Rejection expectedRejection = new()
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        string expectedRoutingNumber = "101050001";
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, RealTimePaymentsTransferStatus> expectedStatus =
            RealTimePaymentsTransferStatus.Complete;
        Submission expectedSubmission = new()
        {
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T14:10:00Z"),
            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
        };
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, RealTimePaymentsTransferType> expectedType =
            RealTimePaymentsTransferType.RealTimePaymentsTransfer;
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAccountNumber, model.AccountNumber);
        Assert.Equal(expectedAcknowledgement, model.Acknowledgement);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedApproval, model.Approval);
        Assert.Equal(expectedCancellation, model.Cancellation);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedCreditorName, model.CreditorName);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDebtorName, model.DebtorName);
        Assert.Null(model.ExternalAccountID);
        Assert.Null(model.IdempotencyKey);
        Assert.Null(model.InboundRealTimePaymentsRequestForPaymentID);
        Assert.Null(model.PendingTransactionID);
        Assert.Equal(expectedRejection, model.Rejection);
        Assert.Null(model.ReturnOfInboundRealTimePaymentsTransferID);
        Assert.Equal(expectedRoutingNumber, model.RoutingNumber);
        Assert.Equal(expectedSourceAccountNumberID, model.SourceAccountNumberID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubmission, model.Submission);
        Assert.Equal(expectedTransactionID, model.TransactionID);
        Assert.Equal(expectedType, model.Type);
        Assert.Null(model.UltimateCreditorName);
        Assert.Null(model.UltimateDebtorName);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            model.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfer
        {
            ID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T14:10:02Z")),
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ApprovedBy = "approved_by",
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T14:00:00Z"),
            CreatedBy = new()
            {
                Category = Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            CreditorName = "Ian Crease",
            Currency = RealTimePaymentsTransferCurrency.Usd,
            DebtorName = "National Phonograph Company",
            ExternalAccountID = null,
            IdempotencyKey = null,
            InboundRealTimePaymentsRequestForPaymentID = null,
            PendingTransactionID = null,
            Rejection = new()
            {
                RejectReasonAdditionalInformation = null,
                RejectReasonCode = RejectReasonCode.AccountClosed,
                RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            ReturnOfInboundRealTimePaymentsTransferID = null,
            RoutingNumber = "101050001",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Status = RealTimePaymentsTransferStatus.Complete,
            Submission = new()
            {
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T14:10:00Z"),
                TransactionIdentification = "20220501234567891T1BSLZO01745013025",
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = RealTimePaymentsTransferType.RealTimePaymentsTransfer,
            UltimateCreditorName = null,
            UltimateDebtorName = null,
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsTransfer
        {
            ID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T14:10:02Z")),
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ApprovedBy = "approved_by",
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T14:00:00Z"),
            CreatedBy = new()
            {
                Category = Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            CreditorName = "Ian Crease",
            Currency = RealTimePaymentsTransferCurrency.Usd,
            DebtorName = "National Phonograph Company",
            ExternalAccountID = null,
            IdempotencyKey = null,
            InboundRealTimePaymentsRequestForPaymentID = null,
            PendingTransactionID = null,
            Rejection = new()
            {
                RejectReasonAdditionalInformation = null,
                RejectReasonCode = RejectReasonCode.AccountClosed,
                RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            ReturnOfInboundRealTimePaymentsTransferID = null,
            RoutingNumber = "101050001",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Status = RealTimePaymentsTransferStatus.Complete,
            Submission = new()
            {
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T14:10:00Z"),
                TransactionIdentification = "20220501234567891T1BSLZO01745013025",
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = RealTimePaymentsTransferType.RealTimePaymentsTransfer,
            UltimateCreditorName = null,
            UltimateDebtorName = null,
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumber = "987654321";
        Acknowledgement expectedAcknowledgement = new(DateTimeOffset.Parse("2020-01-31T14:10:02Z"));
        long expectedAmount = 100;
        Approval expectedApproval = new()
        {
            ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ApprovedBy = "approved_by",
        };
        Cancellation expectedCancellation = new()
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T14:00:00Z");
        CreatedBy expectedCreatedBy = new()
        {
            Category = Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        string expectedCreditorName = "Ian Crease";
        ApiEnum<string, RealTimePaymentsTransferCurrency> expectedCurrency =
            RealTimePaymentsTransferCurrency.Usd;
        string expectedDebtorName = "National Phonograph Company";
        Rejection expectedRejection = new()
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        string expectedRoutingNumber = "101050001";
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, RealTimePaymentsTransferStatus> expectedStatus =
            RealTimePaymentsTransferStatus.Complete;
        Submission expectedSubmission = new()
        {
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T14:10:00Z"),
            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
        };
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, RealTimePaymentsTransferType> expectedType =
            RealTimePaymentsTransferType.RealTimePaymentsTransfer;
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAccountNumber, deserialized.AccountNumber);
        Assert.Equal(expectedAcknowledgement, deserialized.Acknowledgement);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedApproval, deserialized.Approval);
        Assert.Equal(expectedCancellation, deserialized.Cancellation);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedCreditorName, deserialized.CreditorName);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDebtorName, deserialized.DebtorName);
        Assert.Null(deserialized.ExternalAccountID);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Null(deserialized.InboundRealTimePaymentsRequestForPaymentID);
        Assert.Null(deserialized.PendingTransactionID);
        Assert.Equal(expectedRejection, deserialized.Rejection);
        Assert.Null(deserialized.ReturnOfInboundRealTimePaymentsTransferID);
        Assert.Equal(expectedRoutingNumber, deserialized.RoutingNumber);
        Assert.Equal(expectedSourceAccountNumberID, deserialized.SourceAccountNumberID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubmission, deserialized.Submission);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Null(deserialized.UltimateCreditorName);
        Assert.Null(deserialized.UltimateDebtorName);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            deserialized.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimePaymentsTransfer
        {
            ID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T14:10:02Z")),
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ApprovedBy = "approved_by",
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T14:00:00Z"),
            CreatedBy = new()
            {
                Category = Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            CreditorName = "Ian Crease",
            Currency = RealTimePaymentsTransferCurrency.Usd,
            DebtorName = "National Phonograph Company",
            ExternalAccountID = null,
            IdempotencyKey = null,
            InboundRealTimePaymentsRequestForPaymentID = null,
            PendingTransactionID = null,
            Rejection = new()
            {
                RejectReasonAdditionalInformation = null,
                RejectReasonCode = RejectReasonCode.AccountClosed,
                RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            ReturnOfInboundRealTimePaymentsTransferID = null,
            RoutingNumber = "101050001",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Status = RealTimePaymentsTransferStatus.Complete,
            Submission = new()
            {
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T14:10:00Z"),
                TransactionIdentification = "20220501234567891T1BSLZO01745013025",
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = RealTimePaymentsTransferType.RealTimePaymentsTransfer,
            UltimateCreditorName = null,
            UltimateDebtorName = null,
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsTransfer
        {
            ID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T14:10:02Z")),
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ApprovedBy = "approved_by",
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T14:00:00Z"),
            CreatedBy = new()
            {
                Category = Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            CreditorName = "Ian Crease",
            Currency = RealTimePaymentsTransferCurrency.Usd,
            DebtorName = "National Phonograph Company",
            ExternalAccountID = null,
            IdempotencyKey = null,
            InboundRealTimePaymentsRequestForPaymentID = null,
            PendingTransactionID = null,
            Rejection = new()
            {
                RejectReasonAdditionalInformation = null,
                RejectReasonCode = RejectReasonCode.AccountClosed,
                RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            ReturnOfInboundRealTimePaymentsTransferID = null,
            RoutingNumber = "101050001",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Status = RealTimePaymentsTransferStatus.Complete,
            Submission = new()
            {
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T14:10:00Z"),
                TransactionIdentification = "20220501234567891T1BSLZO01745013025",
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = RealTimePaymentsTransferType.RealTimePaymentsTransfer,
            UltimateCreditorName = null,
            UltimateDebtorName = null,
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        RealTimePaymentsTransfer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AcknowledgementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Acknowledgement
        {
            AcknowledgedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedAcknowledgedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAcknowledgedAt, model.AcknowledgedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Acknowledgement
        {
            AcknowledgedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Acknowledgement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Acknowledgement
        {
            AcknowledgedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Acknowledgement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAcknowledgedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAcknowledgedAt, deserialized.AcknowledgedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Acknowledgement
        {
            AcknowledgedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Acknowledgement
        {
            AcknowledgedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Acknowledgement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ApprovalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ApprovedBy = "approved_by",
        };

        DateTimeOffset expectedApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedApprovedBy = "approved_by";

        Assert.Equal(expectedApprovedAt, model.ApprovedAt);
        Assert.Equal(expectedApprovedBy, model.ApprovedBy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ApprovedBy = "approved_by",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Approval>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ApprovedBy = "approved_by",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Approval>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedApprovedBy = "approved_by";

        Assert.Equal(expectedApprovedAt, deserialized.ApprovedAt);
        Assert.Equal(expectedApprovedBy, deserialized.ApprovedBy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ApprovedBy = "approved_by",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ApprovedBy = "approved_by",
        };

        Approval copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cancellation
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
        var model = new Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cancellation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cancellation>(
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
        var model = new Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        Cancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreatedByTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreatedBy
        {
            Category = Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        ApiEnum<string, Category> expectedCategory = Category.User;
        ApiKey expectedApiKey = new("description");
        OAuthApplication expectedOAuthApplication = new("name");
        User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedOAuthApplication, model.OAuthApplication);
        Assert.Equal(expectedUser, model.User);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreatedBy
        {
            Category = Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreatedBy>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreatedBy
        {
            Category = Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreatedBy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Category> expectedCategory = Category.User;
        ApiKey expectedApiKey = new("description");
        OAuthApplication expectedOAuthApplication = new("name");
        User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedOAuthApplication, deserialized.OAuthApplication);
        Assert.Equal(expectedUser, deserialized.User);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreatedBy
        {
            Category = Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreatedBy { Category = Category.User };

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
        var model = new CreatedBy { Category = Category.User };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CreatedBy
        {
            Category = Category.User,

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
        var model = new CreatedBy
        {
            Category = Category.User,

            ApiKey = null,
            OAuthApplication = null,
            User = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreatedBy
        {
            Category = Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        CreatedBy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.ApiKey)]
    [InlineData(Category.OAuthApplication)]
    [InlineData(Category.User)]
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
    [InlineData(Category.ApiKey)]
    [InlineData(Category.OAuthApplication)]
    [InlineData(Category.User)]
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

public class ApiKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiKey { Description = "description" };

        string expectedDescription = "description";

        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiKey { Description = "description" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKey>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiKey { Description = "description" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKey>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedDescription = "description";

        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiKey { Description = "description" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKey { Description = "description" };

        ApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OAuthApplicationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OAuthApplication { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OAuthApplication { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OAuthApplication>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OAuthApplication { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OAuthApplication>(
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
        var model = new OAuthApplication { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OAuthApplication { Name = "name" };

        OAuthApplication copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new User { Email = "email" };

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new User { Email = "email" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<User>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new User { Email = "email" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<User>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, deserialized.Email);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new User { Email = "email" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new User { Email = "email" };

        User copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimePaymentsTransferCurrencyTest : TestBase
{
    [Theory]
    [InlineData(RealTimePaymentsTransferCurrency.Usd)]
    public void Validation_Works(RealTimePaymentsTransferCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsTransferCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimePaymentsTransferCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimePaymentsTransferCurrency.Usd)]
    public void SerializationRoundtrip_Works(RealTimePaymentsTransferCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsTransferCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransferCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimePaymentsTransferCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransferCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RejectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        ApiEnum<string, RejectReasonCode> expectedRejectReasonCode = RejectReasonCode.AccountClosed;
        DateTimeOffset expectedRejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Null(model.RejectReasonAdditionalInformation);
        Assert.Equal(expectedRejectReasonCode, model.RejectReasonCode);
        Assert.Equal(expectedRejectedAt, model.RejectedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rejection>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rejection>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, RejectReasonCode> expectedRejectReasonCode = RejectReasonCode.AccountClosed;
        DateTimeOffset expectedRejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Null(deserialized.RejectReasonAdditionalInformation);
        Assert.Equal(expectedRejectReasonCode, deserialized.RejectReasonCode);
        Assert.Equal(expectedRejectedAt, deserialized.RejectedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        Rejection copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RejectReasonCodeTest : TestBase
{
    [Theory]
    [InlineData(RejectReasonCode.AccountClosed)]
    [InlineData(RejectReasonCode.AccountBlocked)]
    [InlineData(RejectReasonCode.InvalidCreditorAccountType)]
    [InlineData(RejectReasonCode.InvalidCreditorAccountNumber)]
    [InlineData(RejectReasonCode.InvalidCreditorFinancialInstitutionIdentifier)]
    [InlineData(RejectReasonCode.EndCustomerDeceased)]
    [InlineData(RejectReasonCode.Narrative)]
    [InlineData(RejectReasonCode.TransactionForbidden)]
    [InlineData(RejectReasonCode.TransactionTypeNotSupported)]
    [InlineData(RejectReasonCode.UnexpectedAmount)]
    [InlineData(RejectReasonCode.AmountExceedsBankLimits)]
    [InlineData(RejectReasonCode.InvalidCreditorAddress)]
    [InlineData(RejectReasonCode.UnknownEndCustomer)]
    [InlineData(RejectReasonCode.InvalidDebtorAddress)]
    [InlineData(RejectReasonCode.Timeout)]
    [InlineData(RejectReasonCode.UnsupportedMessageForRecipient)]
    [InlineData(RejectReasonCode.RecipientConnectionNotAvailable)]
    [InlineData(RejectReasonCode.RealTimePaymentsSuspended)]
    [InlineData(RejectReasonCode.InstructedAgentSignedOff)]
    [InlineData(RejectReasonCode.ProcessingError)]
    [InlineData(RejectReasonCode.Other)]
    public void Validation_Works(RejectReasonCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RejectReasonCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RejectReasonCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RejectReasonCode.AccountClosed)]
    [InlineData(RejectReasonCode.AccountBlocked)]
    [InlineData(RejectReasonCode.InvalidCreditorAccountType)]
    [InlineData(RejectReasonCode.InvalidCreditorAccountNumber)]
    [InlineData(RejectReasonCode.InvalidCreditorFinancialInstitutionIdentifier)]
    [InlineData(RejectReasonCode.EndCustomerDeceased)]
    [InlineData(RejectReasonCode.Narrative)]
    [InlineData(RejectReasonCode.TransactionForbidden)]
    [InlineData(RejectReasonCode.TransactionTypeNotSupported)]
    [InlineData(RejectReasonCode.UnexpectedAmount)]
    [InlineData(RejectReasonCode.AmountExceedsBankLimits)]
    [InlineData(RejectReasonCode.InvalidCreditorAddress)]
    [InlineData(RejectReasonCode.UnknownEndCustomer)]
    [InlineData(RejectReasonCode.InvalidDebtorAddress)]
    [InlineData(RejectReasonCode.Timeout)]
    [InlineData(RejectReasonCode.UnsupportedMessageForRecipient)]
    [InlineData(RejectReasonCode.RecipientConnectionNotAvailable)]
    [InlineData(RejectReasonCode.RealTimePaymentsSuspended)]
    [InlineData(RejectReasonCode.InstructedAgentSignedOff)]
    [InlineData(RejectReasonCode.ProcessingError)]
    [InlineData(RejectReasonCode.Other)]
    public void SerializationRoundtrip_Works(RejectReasonCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RejectReasonCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RejectReasonCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RejectReasonCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RejectReasonCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RealTimePaymentsTransferStatusTest : TestBase
{
    [Theory]
    [InlineData(RealTimePaymentsTransferStatus.PendingApproval)]
    [InlineData(RealTimePaymentsTransferStatus.Canceled)]
    [InlineData(RealTimePaymentsTransferStatus.PendingSubmission)]
    [InlineData(RealTimePaymentsTransferStatus.PendingReviewing)]
    [InlineData(RealTimePaymentsTransferStatus.RequiresAttention)]
    [InlineData(RealTimePaymentsTransferStatus.Rejected)]
    [InlineData(RealTimePaymentsTransferStatus.Submitted)]
    [InlineData(RealTimePaymentsTransferStatus.Complete)]
    public void Validation_Works(RealTimePaymentsTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsTransferStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimePaymentsTransferStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimePaymentsTransferStatus.PendingApproval)]
    [InlineData(RealTimePaymentsTransferStatus.Canceled)]
    [InlineData(RealTimePaymentsTransferStatus.PendingSubmission)]
    [InlineData(RealTimePaymentsTransferStatus.PendingReviewing)]
    [InlineData(RealTimePaymentsTransferStatus.RequiresAttention)]
    [InlineData(RealTimePaymentsTransferStatus.Rejected)]
    [InlineData(RealTimePaymentsTransferStatus.Submitted)]
    [InlineData(RealTimePaymentsTransferStatus.Complete)]
    public void SerializationRoundtrip_Works(RealTimePaymentsTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsTransferStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimePaymentsTransferStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubmissionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Submission
        {
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionIdentification = "transaction_identification",
        };

        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTransactionIdentification = "transaction_identification";

        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
        Assert.Equal(expectedTransactionIdentification, model.TransactionIdentification);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Submission
        {
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionIdentification = "transaction_identification",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Submission>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Submission
        {
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionIdentification = "transaction_identification",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Submission>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTransactionIdentification = "transaction_identification";

        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
        Assert.Equal(expectedTransactionIdentification, deserialized.TransactionIdentification);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Submission
        {
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionIdentification = "transaction_identification",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Submission
        {
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionIdentification = "transaction_identification",
        };

        Submission copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimePaymentsTransferTypeTest : TestBase
{
    [Theory]
    [InlineData(RealTimePaymentsTransferType.RealTimePaymentsTransfer)]
    public void Validation_Works(RealTimePaymentsTransferType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsTransferType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimePaymentsTransferType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimePaymentsTransferType.RealTimePaymentsTransfer)]
    public void SerializationRoundtrip_Works(RealTimePaymentsTransferType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsTransferType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransferType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimePaymentsTransferType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransferType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
