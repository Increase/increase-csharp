using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using FednowTransfers = Increase.Api.Models.FednowTransfers;

namespace Increase.Api.Tests.Models.FednowTransfers;

public class FednowTransferListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FednowTransfers::FednowTransferListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        List<FednowTransfers::FednowTransfer> expectedData =
        [
            new()
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
        var model = new FednowTransfers::FednowTransferListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FednowTransfers::FednowTransferListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FednowTransfers::FednowTransferListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FednowTransfers::FednowTransferListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<FednowTransfers::FednowTransfer> expectedData =
        [
            new()
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
        var model = new FednowTransfers::FednowTransferListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FednowTransfers::FednowTransferListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        FednowTransfers::FednowTransferListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
