using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using RealTimePaymentsTransfers = Increase.Api.Models.RealTimePaymentsTransfers;

namespace Increase.Api.Tests.Models.RealTimePaymentsTransfers;

public class RealTimePaymentsTransferTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::RealTimePaymentsTransfer
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
        };

        string expectedID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumber = "987654321";
        RealTimePaymentsTransfers::Acknowledgement expectedAcknowledgement = new(
            DateTimeOffset.Parse("2020-01-31T23:59:59Z")
        );
        long expectedAmount = 100;
        RealTimePaymentsTransfers::Approval expectedApproval = new()
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };
        RealTimePaymentsTransfers::Cancellation expectedCancellation = new()
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        RealTimePaymentsTransfers::CreatedBy expectedCreatedBy = new()
        {
            Category = RealTimePaymentsTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        string expectedCreditorName = "Ian Crease";
        ApiEnum<string, RealTimePaymentsTransfers::Currency> expectedCurrency =
            RealTimePaymentsTransfers::Currency.Usd;
        RealTimePaymentsTransfers::Rejection expectedRejection = new()
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RealTimePaymentsTransfers::RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        string expectedRoutingNumber = "101050001";
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, RealTimePaymentsTransfers::RealTimePaymentsTransferStatus> expectedStatus =
            RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Complete;
        RealTimePaymentsTransfers::Submission expectedSubmission = new()
        {
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
        };
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, RealTimePaymentsTransfers::Type> expectedType =
            RealTimePaymentsTransfers::Type.RealTimePaymentsTransfer;
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
        Assert.Null(model.DebtorName);
        Assert.Null(model.ExternalAccountID);
        Assert.Null(model.IdempotencyKey);
        Assert.Null(model.PendingTransactionID);
        Assert.Equal(expectedRejection, model.Rejection);
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
        var model = new RealTimePaymentsTransfers::RealTimePaymentsTransfer
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsTransfers::RealTimePaymentsTransfer>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsTransfers::RealTimePaymentsTransfer
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsTransfers::RealTimePaymentsTransfer>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumber = "987654321";
        RealTimePaymentsTransfers::Acknowledgement expectedAcknowledgement = new(
            DateTimeOffset.Parse("2020-01-31T23:59:59Z")
        );
        long expectedAmount = 100;
        RealTimePaymentsTransfers::Approval expectedApproval = new()
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };
        RealTimePaymentsTransfers::Cancellation expectedCancellation = new()
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        RealTimePaymentsTransfers::CreatedBy expectedCreatedBy = new()
        {
            Category = RealTimePaymentsTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        string expectedCreditorName = "Ian Crease";
        ApiEnum<string, RealTimePaymentsTransfers::Currency> expectedCurrency =
            RealTimePaymentsTransfers::Currency.Usd;
        RealTimePaymentsTransfers::Rejection expectedRejection = new()
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RealTimePaymentsTransfers::RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        string expectedRoutingNumber = "101050001";
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, RealTimePaymentsTransfers::RealTimePaymentsTransferStatus> expectedStatus =
            RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Complete;
        RealTimePaymentsTransfers::Submission expectedSubmission = new()
        {
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
        };
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, RealTimePaymentsTransfers::Type> expectedType =
            RealTimePaymentsTransfers::Type.RealTimePaymentsTransfer;
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
        Assert.Null(deserialized.DebtorName);
        Assert.Null(deserialized.ExternalAccountID);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Null(deserialized.PendingTransactionID);
        Assert.Equal(expectedRejection, deserialized.Rejection);
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
        var model = new RealTimePaymentsTransfers::RealTimePaymentsTransfer
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsTransfers::RealTimePaymentsTransfer
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
        };

        RealTimePaymentsTransfers::RealTimePaymentsTransfer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AcknowledgementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::Acknowledgement
        {
            AcknowledgedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        DateTimeOffset expectedAcknowledgedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedAcknowledgedAt, model.AcknowledgedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::Acknowledgement
        {
            AcknowledgedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::Acknowledgement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsTransfers::Acknowledgement
        {
            AcknowledgedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::Acknowledgement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAcknowledgedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedAcknowledgedAt, deserialized.AcknowledgedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimePaymentsTransfers::Acknowledgement
        {
            AcknowledgedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsTransfers::Acknowledgement
        {
            AcknowledgedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        RealTimePaymentsTransfers::Acknowledgement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ApprovalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::Approval
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
        var model = new RealTimePaymentsTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::Approval>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::Approval>(
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
        var model = new RealTimePaymentsTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        RealTimePaymentsTransfers::Approval copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::Cancellation
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
        var model = new RealTimePaymentsTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::Cancellation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::Cancellation>(
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
        var model = new RealTimePaymentsTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        RealTimePaymentsTransfers::Cancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreatedByTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::CreatedBy
        {
            Category = RealTimePaymentsTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        ApiEnum<string, RealTimePaymentsTransfers::Category> expectedCategory =
            RealTimePaymentsTransfers::Category.User;
        RealTimePaymentsTransfers::ApiKey expectedApiKey = new("description");
        RealTimePaymentsTransfers::OAuthApplication expectedOAuthApplication = new("name");
        RealTimePaymentsTransfers::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedOAuthApplication, model.OAuthApplication);
        Assert.Equal(expectedUser, model.User);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::CreatedBy
        {
            Category = RealTimePaymentsTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::CreatedBy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsTransfers::CreatedBy
        {
            Category = RealTimePaymentsTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::CreatedBy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, RealTimePaymentsTransfers::Category> expectedCategory =
            RealTimePaymentsTransfers::Category.User;
        RealTimePaymentsTransfers::ApiKey expectedApiKey = new("description");
        RealTimePaymentsTransfers::OAuthApplication expectedOAuthApplication = new("name");
        RealTimePaymentsTransfers::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedOAuthApplication, deserialized.OAuthApplication);
        Assert.Equal(expectedUser, deserialized.User);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimePaymentsTransfers::CreatedBy
        {
            Category = RealTimePaymentsTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RealTimePaymentsTransfers::CreatedBy
        {
            Category = RealTimePaymentsTransfers::Category.User,
        };

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
        var model = new RealTimePaymentsTransfers::CreatedBy
        {
            Category = RealTimePaymentsTransfers::Category.User,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RealTimePaymentsTransfers::CreatedBy
        {
            Category = RealTimePaymentsTransfers::Category.User,

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
        var model = new RealTimePaymentsTransfers::CreatedBy
        {
            Category = RealTimePaymentsTransfers::Category.User,

            ApiKey = null,
            OAuthApplication = null,
            User = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsTransfers::CreatedBy
        {
            Category = RealTimePaymentsTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        RealTimePaymentsTransfers::CreatedBy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(RealTimePaymentsTransfers::Category.ApiKey)]
    [InlineData(RealTimePaymentsTransfers::Category.OAuthApplication)]
    [InlineData(RealTimePaymentsTransfers::Category.User)]
    public void Validation_Works(RealTimePaymentsTransfers::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsTransfers::Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::Category>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimePaymentsTransfers::Category.ApiKey)]
    [InlineData(RealTimePaymentsTransfers::Category.OAuthApplication)]
    [InlineData(RealTimePaymentsTransfers::Category.User)]
    public void SerializationRoundtrip_Works(RealTimePaymentsTransfers::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsTransfers::Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::Category>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::Category>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::Category>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ApiKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::ApiKey { Description = "description" };

        string expectedDescription = "description";

        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::ApiKey { Description = "description" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::ApiKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsTransfers::ApiKey { Description = "description" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::ApiKey>(
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
        var model = new RealTimePaymentsTransfers::ApiKey { Description = "description" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsTransfers::ApiKey { Description = "description" };

        RealTimePaymentsTransfers::ApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OAuthApplicationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::OAuthApplication { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::OAuthApplication { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::OAuthApplication>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsTransfers::OAuthApplication { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::OAuthApplication>(
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
        var model = new RealTimePaymentsTransfers::OAuthApplication { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsTransfers::OAuthApplication { Name = "name" };

        RealTimePaymentsTransfers::OAuthApplication copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::User { Email = "email" };

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::User { Email = "email" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::User>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsTransfers::User { Email = "email" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::User>(
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
        var model = new RealTimePaymentsTransfers::User { Email = "email" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsTransfers::User { Email = "email" };

        RealTimePaymentsTransfers::User copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(RealTimePaymentsTransfers::Currency.Usd)]
    public void Validation_Works(RealTimePaymentsTransfers::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsTransfers::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::Currency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimePaymentsTransfers::Currency.Usd)]
    public void SerializationRoundtrip_Works(RealTimePaymentsTransfers::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsTransfers::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::Currency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::Currency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::Currency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RejectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RealTimePaymentsTransfers::RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        ApiEnum<string, RealTimePaymentsTransfers::RejectReasonCode> expectedRejectReasonCode =
            RealTimePaymentsTransfers::RejectReasonCode.AccountClosed;
        DateTimeOffset expectedRejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Null(model.RejectReasonAdditionalInformation);
        Assert.Equal(expectedRejectReasonCode, model.RejectReasonCode);
        Assert.Equal(expectedRejectedAt, model.RejectedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RealTimePaymentsTransfers::RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::Rejection>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsTransfers::Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RealTimePaymentsTransfers::RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::Rejection>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, RealTimePaymentsTransfers::RejectReasonCode> expectedRejectReasonCode =
            RealTimePaymentsTransfers::RejectReasonCode.AccountClosed;
        DateTimeOffset expectedRejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Null(deserialized.RejectReasonAdditionalInformation);
        Assert.Equal(expectedRejectReasonCode, deserialized.RejectReasonCode);
        Assert.Equal(expectedRejectedAt, deserialized.RejectedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimePaymentsTransfers::Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RealTimePaymentsTransfers::RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsTransfers::Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RealTimePaymentsTransfers::RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        RealTimePaymentsTransfers::Rejection copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RejectReasonCodeTest : TestBase
{
    [Theory]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.AccountClosed)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.AccountBlocked)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.InvalidCreditorAccountType)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.InvalidCreditorAccountNumber)]
    [InlineData(
        RealTimePaymentsTransfers::RejectReasonCode.InvalidCreditorFinancialInstitutionIdentifier
    )]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.EndCustomerDeceased)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.Narrative)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.TransactionForbidden)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.TransactionTypeNotSupported)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.UnexpectedAmount)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.AmountExceedsBankLimits)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.InvalidCreditorAddress)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.UnknownEndCustomer)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.InvalidDebtorAddress)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.Timeout)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.UnsupportedMessageForRecipient)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.RecipientConnectionNotAvailable)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.RealTimePaymentsSuspended)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.InstructedAgentSignedOff)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.ProcessingError)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.Other)]
    public void Validation_Works(RealTimePaymentsTransfers::RejectReasonCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsTransfers::RejectReasonCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::RejectReasonCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.AccountClosed)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.AccountBlocked)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.InvalidCreditorAccountType)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.InvalidCreditorAccountNumber)]
    [InlineData(
        RealTimePaymentsTransfers::RejectReasonCode.InvalidCreditorFinancialInstitutionIdentifier
    )]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.EndCustomerDeceased)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.Narrative)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.TransactionForbidden)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.TransactionTypeNotSupported)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.UnexpectedAmount)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.AmountExceedsBankLimits)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.InvalidCreditorAddress)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.UnknownEndCustomer)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.InvalidDebtorAddress)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.Timeout)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.UnsupportedMessageForRecipient)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.RecipientConnectionNotAvailable)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.RealTimePaymentsSuspended)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.InstructedAgentSignedOff)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.ProcessingError)]
    [InlineData(RealTimePaymentsTransfers::RejectReasonCode.Other)]
    public void SerializationRoundtrip_Works(RealTimePaymentsTransfers::RejectReasonCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsTransfers::RejectReasonCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::RejectReasonCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::RejectReasonCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::RejectReasonCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimePaymentsTransferStatusTest : TestBase
{
    [Theory]
    [InlineData(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.PendingApproval)]
    [InlineData(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Canceled)]
    [InlineData(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.PendingReviewing)]
    [InlineData(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.RequiresAttention)]
    [InlineData(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Rejected)]
    [InlineData(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.PendingSubmission)]
    [InlineData(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Submitted)]
    [InlineData(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Complete)]
    public void Validation_Works(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsTransfers::RealTimePaymentsTransferStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::RealTimePaymentsTransferStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.PendingApproval)]
    [InlineData(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Canceled)]
    [InlineData(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.PendingReviewing)]
    [InlineData(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.RequiresAttention)]
    [InlineData(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Rejected)]
    [InlineData(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.PendingSubmission)]
    [InlineData(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Submitted)]
    [InlineData(RealTimePaymentsTransfers::RealTimePaymentsTransferStatus.Complete)]
    public void SerializationRoundtrip_Works(
        RealTimePaymentsTransfers::RealTimePaymentsTransferStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsTransfers::RealTimePaymentsTransferStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::RealTimePaymentsTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::RealTimePaymentsTransferStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::RealTimePaymentsTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubmissionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::Submission
        {
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
        };

        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedTransactionIdentification = "20220501234567891T1BSLZO01745013025";

        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
        Assert.Equal(expectedTransactionIdentification, model.TransactionIdentification);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimePaymentsTransfers::Submission
        {
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::Submission>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsTransfers::Submission
        {
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsTransfers::Submission>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedTransactionIdentification = "20220501234567891T1BSLZO01745013025";

        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
        Assert.Equal(expectedTransactionIdentification, deserialized.TransactionIdentification);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimePaymentsTransfers::Submission
        {
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsTransfers::Submission
        {
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
        };

        RealTimePaymentsTransfers::Submission copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(RealTimePaymentsTransfers::Type.RealTimePaymentsTransfer)]
    public void Validation_Works(RealTimePaymentsTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsTransfers::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimePaymentsTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimePaymentsTransfers::Type.RealTimePaymentsTransfer)]
    public void SerializationRoundtrip_Works(RealTimePaymentsTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsTransfers::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimePaymentsTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsTransfers::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
