using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using FednowTransfers = Increase.Api.Models.FednowTransfers;

namespace Increase.Api.Tests.Models.FednowTransfers;

public class FednowTransferTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FednowTransfers::FednowTransfer
        {
            ID = "fednow_transfer_4i0mptrdu1mueg1196bg",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
            Amount = 100,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = FednowTransfers::Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            CreditorAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                PostalCode = "10045",
                State = "NY",
            },
            CreditorName = "Ian Crease",
            Currency = FednowTransfers::Currency.Usd,
            DebtorName = "National Phonograph Company",
            ExternalAccountID = null,
            IdempotencyKey = null,
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            Rejection = new()
            {
                RejectReasonAdditionalInformation = null,
                RejectReasonCode = FednowTransfers::RejectReasonCode.Other,
                RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            RoutingNumber = "101050001",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Status = FednowTransfers::FednowTransferStatus.Complete,
            Submission = new()
            {
                MessageIdentification = "20250308723260130GT4LAKENDXBHQCZDWS",
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = FednowTransfers::Type.FednowTransfer,
            UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        string expectedID = "fednow_transfer_4i0mptrdu1mueg1196bg";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumber = "987654321";
        FednowTransfers::Acknowledgement expectedAcknowledgement = new(
            DateTimeOffset.Parse("2020-01-31T23:59:59Z")
        );
        long expectedAmount = 100;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        FednowTransfers::CreatedBy expectedCreatedBy = new()
        {
            Category = FednowTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        FednowTransfers::FednowTransferCreditorAddress expectedCreditorAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            PostalCode = "10045",
            State = "NY",
        };
        string expectedCreditorName = "Ian Crease";
        ApiEnum<string, FednowTransfers::Currency> expectedCurrency = FednowTransfers::Currency.Usd;
        string expectedDebtorName = "National Phonograph Company";
        string expectedPendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4";
        FednowTransfers::Rejection expectedRejection = new()
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = FednowTransfers::RejectReasonCode.Other,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        string expectedRoutingNumber = "101050001";
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, FednowTransfers::FednowTransferStatus> expectedStatus =
            FednowTransfers::FednowTransferStatus.Complete;
        FednowTransfers::Submission expectedSubmission = new()
        {
            MessageIdentification = "20250308723260130GT4LAKENDXBHQCZDWS",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, FednowTransfers::Type> expectedType = FednowTransfers::Type.FednowTransfer;
        string expectedUniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a";
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAccountNumber, model.AccountNumber);
        Assert.Equal(expectedAcknowledgement, model.Acknowledgement);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedCreditorAddress, model.CreditorAddress);
        Assert.Equal(expectedCreditorName, model.CreditorName);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDebtorName, model.DebtorName);
        Assert.Null(model.ExternalAccountID);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedPendingTransactionID, model.PendingTransactionID);
        Assert.Equal(expectedRejection, model.Rejection);
        Assert.Equal(expectedRoutingNumber, model.RoutingNumber);
        Assert.Equal(expectedSourceAccountNumberID, model.SourceAccountNumberID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubmission, model.Submission);
        Assert.Equal(expectedTransactionID, model.TransactionID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(
            expectedUniqueEndToEndTransactionReference,
            model.UniqueEndToEndTransactionReference
        );
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            model.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FednowTransfers::FednowTransfer
        {
            ID = "fednow_transfer_4i0mptrdu1mueg1196bg",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
            Amount = 100,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = FednowTransfers::Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            CreditorAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                PostalCode = "10045",
                State = "NY",
            },
            CreditorName = "Ian Crease",
            Currency = FednowTransfers::Currency.Usd,
            DebtorName = "National Phonograph Company",
            ExternalAccountID = null,
            IdempotencyKey = null,
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            Rejection = new()
            {
                RejectReasonAdditionalInformation = null,
                RejectReasonCode = FednowTransfers::RejectReasonCode.Other,
                RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            RoutingNumber = "101050001",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Status = FednowTransfers::FednowTransferStatus.Complete,
            Submission = new()
            {
                MessageIdentification = "20250308723260130GT4LAKENDXBHQCZDWS",
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = FednowTransfers::Type.FednowTransfer,
            UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FednowTransfers::FednowTransfer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FednowTransfers::FednowTransfer
        {
            ID = "fednow_transfer_4i0mptrdu1mueg1196bg",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
            Amount = 100,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = FednowTransfers::Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            CreditorAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                PostalCode = "10045",
                State = "NY",
            },
            CreditorName = "Ian Crease",
            Currency = FednowTransfers::Currency.Usd,
            DebtorName = "National Phonograph Company",
            ExternalAccountID = null,
            IdempotencyKey = null,
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            Rejection = new()
            {
                RejectReasonAdditionalInformation = null,
                RejectReasonCode = FednowTransfers::RejectReasonCode.Other,
                RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            RoutingNumber = "101050001",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Status = FednowTransfers::FednowTransferStatus.Complete,
            Submission = new()
            {
                MessageIdentification = "20250308723260130GT4LAKENDXBHQCZDWS",
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = FednowTransfers::Type.FednowTransfer,
            UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FednowTransfers::FednowTransfer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "fednow_transfer_4i0mptrdu1mueg1196bg";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumber = "987654321";
        FednowTransfers::Acknowledgement expectedAcknowledgement = new(
            DateTimeOffset.Parse("2020-01-31T23:59:59Z")
        );
        long expectedAmount = 100;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        FednowTransfers::CreatedBy expectedCreatedBy = new()
        {
            Category = FednowTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        FednowTransfers::FednowTransferCreditorAddress expectedCreditorAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            PostalCode = "10045",
            State = "NY",
        };
        string expectedCreditorName = "Ian Crease";
        ApiEnum<string, FednowTransfers::Currency> expectedCurrency = FednowTransfers::Currency.Usd;
        string expectedDebtorName = "National Phonograph Company";
        string expectedPendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4";
        FednowTransfers::Rejection expectedRejection = new()
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = FednowTransfers::RejectReasonCode.Other,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        string expectedRoutingNumber = "101050001";
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, FednowTransfers::FednowTransferStatus> expectedStatus =
            FednowTransfers::FednowTransferStatus.Complete;
        FednowTransfers::Submission expectedSubmission = new()
        {
            MessageIdentification = "20250308723260130GT4LAKENDXBHQCZDWS",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, FednowTransfers::Type> expectedType = FednowTransfers::Type.FednowTransfer;
        string expectedUniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a";
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAccountNumber, deserialized.AccountNumber);
        Assert.Equal(expectedAcknowledgement, deserialized.Acknowledgement);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedCreditorAddress, deserialized.CreditorAddress);
        Assert.Equal(expectedCreditorName, deserialized.CreditorName);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDebtorName, deserialized.DebtorName);
        Assert.Null(deserialized.ExternalAccountID);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedPendingTransactionID, deserialized.PendingTransactionID);
        Assert.Equal(expectedRejection, deserialized.Rejection);
        Assert.Equal(expectedRoutingNumber, deserialized.RoutingNumber);
        Assert.Equal(expectedSourceAccountNumberID, deserialized.SourceAccountNumberID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubmission, deserialized.Submission);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(
            expectedUniqueEndToEndTransactionReference,
            deserialized.UniqueEndToEndTransactionReference
        );
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            deserialized.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FednowTransfers::FednowTransfer
        {
            ID = "fednow_transfer_4i0mptrdu1mueg1196bg",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
            Amount = 100,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = FednowTransfers::Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            CreditorAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                PostalCode = "10045",
                State = "NY",
            },
            CreditorName = "Ian Crease",
            Currency = FednowTransfers::Currency.Usd,
            DebtorName = "National Phonograph Company",
            ExternalAccountID = null,
            IdempotencyKey = null,
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            Rejection = new()
            {
                RejectReasonAdditionalInformation = null,
                RejectReasonCode = FednowTransfers::RejectReasonCode.Other,
                RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            RoutingNumber = "101050001",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Status = FednowTransfers::FednowTransferStatus.Complete,
            Submission = new()
            {
                MessageIdentification = "20250308723260130GT4LAKENDXBHQCZDWS",
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = FednowTransfers::Type.FednowTransfer,
            UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FednowTransfers::FednowTransfer
        {
            ID = "fednow_transfer_4i0mptrdu1mueg1196bg",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Acknowledgement = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
            Amount = 100,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = FednowTransfers::Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            CreditorAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                PostalCode = "10045",
                State = "NY",
            },
            CreditorName = "Ian Crease",
            Currency = FednowTransfers::Currency.Usd,
            DebtorName = "National Phonograph Company",
            ExternalAccountID = null,
            IdempotencyKey = null,
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            Rejection = new()
            {
                RejectReasonAdditionalInformation = null,
                RejectReasonCode = FednowTransfers::RejectReasonCode.Other,
                RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            RoutingNumber = "101050001",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Status = FednowTransfers::FednowTransferStatus.Complete,
            Submission = new()
            {
                MessageIdentification = "20250308723260130GT4LAKENDXBHQCZDWS",
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = FednowTransfers::Type.FednowTransfer,
            UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        FednowTransfers::FednowTransfer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AcknowledgementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FednowTransfers::Acknowledgement
        {
            AcknowledgedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        DateTimeOffset expectedAcknowledgedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedAcknowledgedAt, model.AcknowledgedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FednowTransfers::Acknowledgement
        {
            AcknowledgedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FednowTransfers::Acknowledgement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FednowTransfers::Acknowledgement
        {
            AcknowledgedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FednowTransfers::Acknowledgement>(
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
        var model = new FednowTransfers::Acknowledgement
        {
            AcknowledgedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FednowTransfers::Acknowledgement
        {
            AcknowledgedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        FednowTransfers::Acknowledgement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreatedByTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FednowTransfers::CreatedBy
        {
            Category = FednowTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        ApiEnum<string, FednowTransfers::Category> expectedCategory =
            FednowTransfers::Category.User;
        FednowTransfers::ApiKey expectedApiKey = new("description");
        FednowTransfers::OAuthApplication expectedOAuthApplication = new("name");
        FednowTransfers::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedOAuthApplication, model.OAuthApplication);
        Assert.Equal(expectedUser, model.User);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FednowTransfers::CreatedBy
        {
            Category = FednowTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FednowTransfers::CreatedBy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FednowTransfers::CreatedBy
        {
            Category = FednowTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FednowTransfers::CreatedBy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, FednowTransfers::Category> expectedCategory =
            FednowTransfers::Category.User;
        FednowTransfers::ApiKey expectedApiKey = new("description");
        FednowTransfers::OAuthApplication expectedOAuthApplication = new("name");
        FednowTransfers::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedOAuthApplication, deserialized.OAuthApplication);
        Assert.Equal(expectedUser, deserialized.User);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FednowTransfers::CreatedBy
        {
            Category = FednowTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FednowTransfers::CreatedBy { Category = FednowTransfers::Category.User };

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
        var model = new FednowTransfers::CreatedBy { Category = FednowTransfers::Category.User };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FednowTransfers::CreatedBy
        {
            Category = FednowTransfers::Category.User,

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
        var model = new FednowTransfers::CreatedBy
        {
            Category = FednowTransfers::Category.User,

            ApiKey = null,
            OAuthApplication = null,
            User = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FednowTransfers::CreatedBy
        {
            Category = FednowTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        FednowTransfers::CreatedBy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(FednowTransfers::Category.ApiKey)]
    [InlineData(FednowTransfers::Category.OAuthApplication)]
    [InlineData(FednowTransfers::Category.User)]
    public void Validation_Works(FednowTransfers::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FednowTransfers::Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FednowTransfers::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FednowTransfers::Category.ApiKey)]
    [InlineData(FednowTransfers::Category.OAuthApplication)]
    [InlineData(FednowTransfers::Category.User)]
    public void SerializationRoundtrip_Works(FednowTransfers::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FednowTransfers::Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FednowTransfers::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FednowTransfers::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FednowTransfers::Category>>(
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
        var model = new FednowTransfers::ApiKey { Description = "description" };

        string expectedDescription = "description";

        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FednowTransfers::ApiKey { Description = "description" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FednowTransfers::ApiKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FednowTransfers::ApiKey { Description = "description" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FednowTransfers::ApiKey>(
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
        var model = new FednowTransfers::ApiKey { Description = "description" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FednowTransfers::ApiKey { Description = "description" };

        FednowTransfers::ApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OAuthApplicationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FednowTransfers::OAuthApplication { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FednowTransfers::OAuthApplication { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FednowTransfers::OAuthApplication>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FednowTransfers::OAuthApplication { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FednowTransfers::OAuthApplication>(
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
        var model = new FednowTransfers::OAuthApplication { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FednowTransfers::OAuthApplication { Name = "name" };

        FednowTransfers::OAuthApplication copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FednowTransfers::User { Email = "email" };

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FednowTransfers::User { Email = "email" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FednowTransfers::User>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FednowTransfers::User { Email = "email" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FednowTransfers::User>(
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
        var model = new FednowTransfers::User { Email = "email" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FednowTransfers::User { Email = "email" };

        FednowTransfers::User copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FednowTransferCreditorAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FednowTransfers::FednowTransferCreditorAddress
        {
            City = "city",
            Line1 = "line1",
            PostalCode = "postal_code",
            State = "state",
        };

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FednowTransfers::FednowTransferCreditorAddress
        {
            City = "city",
            Line1 = "line1",
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FednowTransfers::FednowTransferCreditorAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FednowTransfers::FednowTransferCreditorAddress
        {
            City = "city",
            Line1 = "line1",
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FednowTransfers::FednowTransferCreditorAddress>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FednowTransfers::FednowTransferCreditorAddress
        {
            City = "city",
            Line1 = "line1",
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FednowTransfers::FednowTransferCreditorAddress
        {
            City = "city",
            Line1 = "line1",
            PostalCode = "postal_code",
            State = "state",
        };

        FednowTransfers::FednowTransferCreditorAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(FednowTransfers::Currency.Usd)]
    public void Validation_Works(FednowTransfers::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FednowTransfers::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FednowTransfers::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FednowTransfers::Currency.Usd)]
    public void SerializationRoundtrip_Works(FednowTransfers::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FednowTransfers::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FednowTransfers::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FednowTransfers::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FednowTransfers::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RejectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FednowTransfers::Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = FednowTransfers::RejectReasonCode.Other,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        ApiEnum<string, FednowTransfers::RejectReasonCode> expectedRejectReasonCode =
            FednowTransfers::RejectReasonCode.Other;
        DateTimeOffset expectedRejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Null(model.RejectReasonAdditionalInformation);
        Assert.Equal(expectedRejectReasonCode, model.RejectReasonCode);
        Assert.Equal(expectedRejectedAt, model.RejectedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FednowTransfers::Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = FednowTransfers::RejectReasonCode.Other,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FednowTransfers::Rejection>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FednowTransfers::Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = FednowTransfers::RejectReasonCode.Other,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FednowTransfers::Rejection>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, FednowTransfers::RejectReasonCode> expectedRejectReasonCode =
            FednowTransfers::RejectReasonCode.Other;
        DateTimeOffset expectedRejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Null(deserialized.RejectReasonAdditionalInformation);
        Assert.Equal(expectedRejectReasonCode, deserialized.RejectReasonCode);
        Assert.Equal(expectedRejectedAt, deserialized.RejectedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FednowTransfers::Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = FednowTransfers::RejectReasonCode.Other,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FednowTransfers::Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = FednowTransfers::RejectReasonCode.Other,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        FednowTransfers::Rejection copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RejectReasonCodeTest : TestBase
{
    [Theory]
    [InlineData(FednowTransfers::RejectReasonCode.AccountClosed)]
    [InlineData(FednowTransfers::RejectReasonCode.AccountBlocked)]
    [InlineData(FednowTransfers::RejectReasonCode.InvalidCreditorAccountType)]
    [InlineData(FednowTransfers::RejectReasonCode.InvalidCreditorAccountNumber)]
    [InlineData(FednowTransfers::RejectReasonCode.InvalidCreditorFinancialInstitutionIdentifier)]
    [InlineData(FednowTransfers::RejectReasonCode.EndCustomerDeceased)]
    [InlineData(FednowTransfers::RejectReasonCode.Narrative)]
    [InlineData(FednowTransfers::RejectReasonCode.TransactionForbidden)]
    [InlineData(FednowTransfers::RejectReasonCode.TransactionTypeNotSupported)]
    [InlineData(FednowTransfers::RejectReasonCode.AmountExceedsBankLimits)]
    [InlineData(FednowTransfers::RejectReasonCode.InvalidCreditorAddress)]
    [InlineData(FednowTransfers::RejectReasonCode.InvalidDebtorAddress)]
    [InlineData(FednowTransfers::RejectReasonCode.Timeout)]
    [InlineData(FednowTransfers::RejectReasonCode.ProcessingError)]
    [InlineData(FednowTransfers::RejectReasonCode.Other)]
    public void Validation_Works(FednowTransfers::RejectReasonCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FednowTransfers::RejectReasonCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FednowTransfers::RejectReasonCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FednowTransfers::RejectReasonCode.AccountClosed)]
    [InlineData(FednowTransfers::RejectReasonCode.AccountBlocked)]
    [InlineData(FednowTransfers::RejectReasonCode.InvalidCreditorAccountType)]
    [InlineData(FednowTransfers::RejectReasonCode.InvalidCreditorAccountNumber)]
    [InlineData(FednowTransfers::RejectReasonCode.InvalidCreditorFinancialInstitutionIdentifier)]
    [InlineData(FednowTransfers::RejectReasonCode.EndCustomerDeceased)]
    [InlineData(FednowTransfers::RejectReasonCode.Narrative)]
    [InlineData(FednowTransfers::RejectReasonCode.TransactionForbidden)]
    [InlineData(FednowTransfers::RejectReasonCode.TransactionTypeNotSupported)]
    [InlineData(FednowTransfers::RejectReasonCode.AmountExceedsBankLimits)]
    [InlineData(FednowTransfers::RejectReasonCode.InvalidCreditorAddress)]
    [InlineData(FednowTransfers::RejectReasonCode.InvalidDebtorAddress)]
    [InlineData(FednowTransfers::RejectReasonCode.Timeout)]
    [InlineData(FednowTransfers::RejectReasonCode.ProcessingError)]
    [InlineData(FednowTransfers::RejectReasonCode.Other)]
    public void SerializationRoundtrip_Works(FednowTransfers::RejectReasonCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FednowTransfers::RejectReasonCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FednowTransfers::RejectReasonCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FednowTransfers::RejectReasonCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FednowTransfers::RejectReasonCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FednowTransferStatusTest : TestBase
{
    [Theory]
    [InlineData(FednowTransfers::FednowTransferStatus.PendingReviewing)]
    [InlineData(FednowTransfers::FednowTransferStatus.Canceled)]
    [InlineData(FednowTransfers::FednowTransferStatus.ReviewingRejected)]
    [InlineData(FednowTransfers::FednowTransferStatus.RequiresAttention)]
    [InlineData(FednowTransfers::FednowTransferStatus.PendingApproval)]
    [InlineData(FednowTransfers::FednowTransferStatus.PendingSubmitting)]
    [InlineData(FednowTransfers::FednowTransferStatus.PendingResponse)]
    [InlineData(FednowTransfers::FednowTransferStatus.Complete)]
    [InlineData(FednowTransfers::FednowTransferStatus.Rejected)]
    public void Validation_Works(FednowTransfers::FednowTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FednowTransfers::FednowTransferStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FednowTransfers::FednowTransferStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FednowTransfers::FednowTransferStatus.PendingReviewing)]
    [InlineData(FednowTransfers::FednowTransferStatus.Canceled)]
    [InlineData(FednowTransfers::FednowTransferStatus.ReviewingRejected)]
    [InlineData(FednowTransfers::FednowTransferStatus.RequiresAttention)]
    [InlineData(FednowTransfers::FednowTransferStatus.PendingApproval)]
    [InlineData(FednowTransfers::FednowTransferStatus.PendingSubmitting)]
    [InlineData(FednowTransfers::FednowTransferStatus.PendingResponse)]
    [InlineData(FednowTransfers::FednowTransferStatus.Complete)]
    [InlineData(FednowTransfers::FednowTransferStatus.Rejected)]
    public void SerializationRoundtrip_Works(FednowTransfers::FednowTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FednowTransfers::FednowTransferStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FednowTransfers::FednowTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FednowTransfers::FednowTransferStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FednowTransfers::FednowTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubmissionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FednowTransfers::Submission
        {
            MessageIdentification = "20250308723260130GT4LAKENDXBHQCZDWS",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string expectedMessageIdentification = "20250308723260130GT4LAKENDXBHQCZDWS";
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedMessageIdentification, model.MessageIdentification);
        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FednowTransfers::Submission
        {
            MessageIdentification = "20250308723260130GT4LAKENDXBHQCZDWS",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FednowTransfers::Submission>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FednowTransfers::Submission
        {
            MessageIdentification = "20250308723260130GT4LAKENDXBHQCZDWS",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FednowTransfers::Submission>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessageIdentification = "20250308723260130GT4LAKENDXBHQCZDWS";
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedMessageIdentification, deserialized.MessageIdentification);
        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FednowTransfers::Submission
        {
            MessageIdentification = "20250308723260130GT4LAKENDXBHQCZDWS",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FednowTransfers::Submission
        {
            MessageIdentification = "20250308723260130GT4LAKENDXBHQCZDWS",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        FednowTransfers::Submission copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(FednowTransfers::Type.FednowTransfer)]
    public void Validation_Works(FednowTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FednowTransfers::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FednowTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FednowTransfers::Type.FednowTransfer)]
    public void SerializationRoundtrip_Works(FednowTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FednowTransfers::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FednowTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FednowTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FednowTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
