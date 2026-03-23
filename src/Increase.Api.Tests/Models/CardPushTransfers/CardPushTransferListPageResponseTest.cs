using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using CardPushTransfers = Increase.Api.Models.CardPushTransfers;

namespace Increase.Api.Tests.Models.CardPushTransfers;

public class CardPushTransferListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardPushTransfers::CardPushTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        AuthorizationIdentificationResponse = "ABCDEF",
                        CardVerificationValue2Result = null,
                        NetworkTransactionIdentifier = "841488484271872",
                        SettlementAmount = 100,
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Approval = new()
                    {
                        ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        ApprovedBy = null,
                    },
                    BusinessApplicationIdentifier =
                        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.FundsDisbursement,
                    Cancellation = new()
                    {
                        CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CanceledBy = null,
                    },
                    CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = CardPushTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Decline = new()
                    {
                        DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        NetworkTransactionIdentifier = "841488484271872",
                        Reason = CardPushTransfers::Reason.TransactionNotPermittedToCardholder,
                    },
                    IdempotencyKey = null,
                    MerchantCategoryCode = "1234",
                    MerchantCityName = "New York",
                    MerchantName = "Acme Corp",
                    MerchantNamePrefix = "Acme",
                    MerchantPostalCode = "10045",
                    MerchantState = "NY",
                    PresentmentAmount = new()
                    {
                        Currency = CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd,
                        Value = "12.34",
                    },
                    RecipientName = "Ian Crease",
                    Route = CardPushTransfers::Route.Visa,
                    SenderAddressCity = "New York",
                    SenderAddressLine1 = "33 Liberty Street",
                    SenderAddressPostalCode = "10045",
                    SenderAddressState = "NY",
                    SenderName = "Ian Crease",
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = CardPushTransfers::CardPushTransferStatus.PendingSubmission,
                    Submission = new()
                    {
                        RetrievalReferenceNumber = "123456789012",
                        SenderReference = "OPQRRX3BNAKA6QLT",
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TraceNumber = "123456",
                    },
                    Type = CardPushTransfers::Type.CardPushTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<CardPushTransfers::CardPushTransfer> expectedData =
        [
            new()
            {
                ID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                Acceptance = new()
                {
                    AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    AuthorizationIdentificationResponse = "ABCDEF",
                    CardVerificationValue2Result = null,
                    NetworkTransactionIdentifier = "841488484271872",
                    SettlementAmount = 100,
                },
                AccountID = "account_in71c4amph0vgo2qllky",
                Approval = new()
                {
                    ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    ApprovedBy = null,
                },
                BusinessApplicationIdentifier =
                    CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.FundsDisbursement,
                Cancellation = new()
                {
                    CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CanceledBy = null,
                },
                CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedBy = new()
                {
                    Category = CardPushTransfers::Category.User,
                    ApiKey = new("description"),
                    OAuthApplication = new("name"),
                    User = new("user@example.com"),
                },
                Decline = new()
                {
                    DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    NetworkTransactionIdentifier = "841488484271872",
                    Reason = CardPushTransfers::Reason.TransactionNotPermittedToCardholder,
                },
                IdempotencyKey = null,
                MerchantCategoryCode = "1234",
                MerchantCityName = "New York",
                MerchantName = "Acme Corp",
                MerchantNamePrefix = "Acme",
                MerchantPostalCode = "10045",
                MerchantState = "NY",
                PresentmentAmount = new()
                {
                    Currency = CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd,
                    Value = "12.34",
                },
                RecipientName = "Ian Crease",
                Route = CardPushTransfers::Route.Visa,
                SenderAddressCity = "New York",
                SenderAddressLine1 = "33 Liberty Street",
                SenderAddressPostalCode = "10045",
                SenderAddressState = "NY",
                SenderName = "Ian Crease",
                SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Status = CardPushTransfers::CardPushTransferStatus.PendingSubmission,
                Submission = new()
                {
                    RetrievalReferenceNumber = "123456789012",
                    SenderReference = "OPQRRX3BNAKA6QLT",
                    SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TraceNumber = "123456",
                },
                Type = CardPushTransfers::Type.CardPushTransfer,
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
        var model = new CardPushTransfers::CardPushTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        AuthorizationIdentificationResponse = "ABCDEF",
                        CardVerificationValue2Result = null,
                        NetworkTransactionIdentifier = "841488484271872",
                        SettlementAmount = 100,
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Approval = new()
                    {
                        ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        ApprovedBy = null,
                    },
                    BusinessApplicationIdentifier =
                        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.FundsDisbursement,
                    Cancellation = new()
                    {
                        CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CanceledBy = null,
                    },
                    CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = CardPushTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Decline = new()
                    {
                        DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        NetworkTransactionIdentifier = "841488484271872",
                        Reason = CardPushTransfers::Reason.TransactionNotPermittedToCardholder,
                    },
                    IdempotencyKey = null,
                    MerchantCategoryCode = "1234",
                    MerchantCityName = "New York",
                    MerchantName = "Acme Corp",
                    MerchantNamePrefix = "Acme",
                    MerchantPostalCode = "10045",
                    MerchantState = "NY",
                    PresentmentAmount = new()
                    {
                        Currency = CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd,
                        Value = "12.34",
                    },
                    RecipientName = "Ian Crease",
                    Route = CardPushTransfers::Route.Visa,
                    SenderAddressCity = "New York",
                    SenderAddressLine1 = "33 Liberty Street",
                    SenderAddressPostalCode = "10045",
                    SenderAddressState = "NY",
                    SenderName = "Ian Crease",
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = CardPushTransfers::CardPushTransferStatus.PendingSubmission,
                    Submission = new()
                    {
                        RetrievalReferenceNumber = "123456789012",
                        SenderReference = "OPQRRX3BNAKA6QLT",
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TraceNumber = "123456",
                    },
                    Type = CardPushTransfers::Type.CardPushTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardPushTransfers::CardPushTransferListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardPushTransfers::CardPushTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        AuthorizationIdentificationResponse = "ABCDEF",
                        CardVerificationValue2Result = null,
                        NetworkTransactionIdentifier = "841488484271872",
                        SettlementAmount = 100,
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Approval = new()
                    {
                        ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        ApprovedBy = null,
                    },
                    BusinessApplicationIdentifier =
                        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.FundsDisbursement,
                    Cancellation = new()
                    {
                        CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CanceledBy = null,
                    },
                    CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = CardPushTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Decline = new()
                    {
                        DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        NetworkTransactionIdentifier = "841488484271872",
                        Reason = CardPushTransfers::Reason.TransactionNotPermittedToCardholder,
                    },
                    IdempotencyKey = null,
                    MerchantCategoryCode = "1234",
                    MerchantCityName = "New York",
                    MerchantName = "Acme Corp",
                    MerchantNamePrefix = "Acme",
                    MerchantPostalCode = "10045",
                    MerchantState = "NY",
                    PresentmentAmount = new()
                    {
                        Currency = CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd,
                        Value = "12.34",
                    },
                    RecipientName = "Ian Crease",
                    Route = CardPushTransfers::Route.Visa,
                    SenderAddressCity = "New York",
                    SenderAddressLine1 = "33 Liberty Street",
                    SenderAddressPostalCode = "10045",
                    SenderAddressState = "NY",
                    SenderName = "Ian Crease",
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = CardPushTransfers::CardPushTransferStatus.PendingSubmission,
                    Submission = new()
                    {
                        RetrievalReferenceNumber = "123456789012",
                        SenderReference = "OPQRRX3BNAKA6QLT",
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TraceNumber = "123456",
                    },
                    Type = CardPushTransfers::Type.CardPushTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardPushTransfers::CardPushTransferListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<CardPushTransfers::CardPushTransfer> expectedData =
        [
            new()
            {
                ID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                Acceptance = new()
                {
                    AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    AuthorizationIdentificationResponse = "ABCDEF",
                    CardVerificationValue2Result = null,
                    NetworkTransactionIdentifier = "841488484271872",
                    SettlementAmount = 100,
                },
                AccountID = "account_in71c4amph0vgo2qllky",
                Approval = new()
                {
                    ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    ApprovedBy = null,
                },
                BusinessApplicationIdentifier =
                    CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.FundsDisbursement,
                Cancellation = new()
                {
                    CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CanceledBy = null,
                },
                CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedBy = new()
                {
                    Category = CardPushTransfers::Category.User,
                    ApiKey = new("description"),
                    OAuthApplication = new("name"),
                    User = new("user@example.com"),
                },
                Decline = new()
                {
                    DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    NetworkTransactionIdentifier = "841488484271872",
                    Reason = CardPushTransfers::Reason.TransactionNotPermittedToCardholder,
                },
                IdempotencyKey = null,
                MerchantCategoryCode = "1234",
                MerchantCityName = "New York",
                MerchantName = "Acme Corp",
                MerchantNamePrefix = "Acme",
                MerchantPostalCode = "10045",
                MerchantState = "NY",
                PresentmentAmount = new()
                {
                    Currency = CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd,
                    Value = "12.34",
                },
                RecipientName = "Ian Crease",
                Route = CardPushTransfers::Route.Visa,
                SenderAddressCity = "New York",
                SenderAddressLine1 = "33 Liberty Street",
                SenderAddressPostalCode = "10045",
                SenderAddressState = "NY",
                SenderName = "Ian Crease",
                SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Status = CardPushTransfers::CardPushTransferStatus.PendingSubmission,
                Submission = new()
                {
                    RetrievalReferenceNumber = "123456789012",
                    SenderReference = "OPQRRX3BNAKA6QLT",
                    SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TraceNumber = "123456",
                },
                Type = CardPushTransfers::Type.CardPushTransfer,
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
        var model = new CardPushTransfers::CardPushTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        AuthorizationIdentificationResponse = "ABCDEF",
                        CardVerificationValue2Result = null,
                        NetworkTransactionIdentifier = "841488484271872",
                        SettlementAmount = 100,
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Approval = new()
                    {
                        ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        ApprovedBy = null,
                    },
                    BusinessApplicationIdentifier =
                        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.FundsDisbursement,
                    Cancellation = new()
                    {
                        CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CanceledBy = null,
                    },
                    CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = CardPushTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Decline = new()
                    {
                        DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        NetworkTransactionIdentifier = "841488484271872",
                        Reason = CardPushTransfers::Reason.TransactionNotPermittedToCardholder,
                    },
                    IdempotencyKey = null,
                    MerchantCategoryCode = "1234",
                    MerchantCityName = "New York",
                    MerchantName = "Acme Corp",
                    MerchantNamePrefix = "Acme",
                    MerchantPostalCode = "10045",
                    MerchantState = "NY",
                    PresentmentAmount = new()
                    {
                        Currency = CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd,
                        Value = "12.34",
                    },
                    RecipientName = "Ian Crease",
                    Route = CardPushTransfers::Route.Visa,
                    SenderAddressCity = "New York",
                    SenderAddressLine1 = "33 Liberty Street",
                    SenderAddressPostalCode = "10045",
                    SenderAddressState = "NY",
                    SenderName = "Ian Crease",
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = CardPushTransfers::CardPushTransferStatus.PendingSubmission,
                    Submission = new()
                    {
                        RetrievalReferenceNumber = "123456789012",
                        SenderReference = "OPQRRX3BNAKA6QLT",
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TraceNumber = "123456",
                    },
                    Type = CardPushTransfers::Type.CardPushTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardPushTransfers::CardPushTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        AuthorizationIdentificationResponse = "ABCDEF",
                        CardVerificationValue2Result = null,
                        NetworkTransactionIdentifier = "841488484271872",
                        SettlementAmount = 100,
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Approval = new()
                    {
                        ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        ApprovedBy = null,
                    },
                    BusinessApplicationIdentifier =
                        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.FundsDisbursement,
                    Cancellation = new()
                    {
                        CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CanceledBy = null,
                    },
                    CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = CardPushTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Decline = new()
                    {
                        DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        NetworkTransactionIdentifier = "841488484271872",
                        Reason = CardPushTransfers::Reason.TransactionNotPermittedToCardholder,
                    },
                    IdempotencyKey = null,
                    MerchantCategoryCode = "1234",
                    MerchantCityName = "New York",
                    MerchantName = "Acme Corp",
                    MerchantNamePrefix = "Acme",
                    MerchantPostalCode = "10045",
                    MerchantState = "NY",
                    PresentmentAmount = new()
                    {
                        Currency = CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd,
                        Value = "12.34",
                    },
                    RecipientName = "Ian Crease",
                    Route = CardPushTransfers::Route.Visa,
                    SenderAddressCity = "New York",
                    SenderAddressLine1 = "33 Liberty Street",
                    SenderAddressPostalCode = "10045",
                    SenderAddressState = "NY",
                    SenderName = "Ian Crease",
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = CardPushTransfers::CardPushTransferStatus.PendingSubmission,
                    Submission = new()
                    {
                        RetrievalReferenceNumber = "123456789012",
                        SenderReference = "OPQRRX3BNAKA6QLT",
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TraceNumber = "123456",
                    },
                    Type = CardPushTransfers::Type.CardPushTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        CardPushTransfers::CardPushTransferListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
