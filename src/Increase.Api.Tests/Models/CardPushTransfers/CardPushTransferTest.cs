using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using CardPushTransfers = Increase.Api.Models.CardPushTransfers;

namespace Increase.Api.Tests.Models.CardPushTransfers;

public class CardPushTransferTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardPushTransfers::CardPushTransfer
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
        };

        string expectedID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye";
        CardPushTransfers::Acceptance expectedAcceptance = new()
        {
            AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            AuthorizationIdentificationResponse = "ABCDEF",
            CardVerificationValue2Result = null,
            NetworkTransactionIdentifier = "841488484271872",
            SettlementAmount = 100,
        };
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        CardPushTransfers::Approval expectedApproval = new()
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };
        ApiEnum<
            string,
            CardPushTransfers::CardPushTransferBusinessApplicationIdentifier
        > expectedBusinessApplicationIdentifier =
            CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.FundsDisbursement;
        CardPushTransfers::Cancellation expectedCancellation = new()
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };
        string expectedCardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        CardPushTransfers::CreatedBy expectedCreatedBy = new()
        {
            Category = CardPushTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        CardPushTransfers::Decline expectedDecline = new()
        {
            DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            NetworkTransactionIdentifier = "841488484271872",
            Reason = CardPushTransfers::Reason.TransactionNotPermittedToCardholder,
        };
        string expectedMerchantCategoryCode = "1234";
        string expectedMerchantCityName = "New York";
        string expectedMerchantName = "Acme Corp";
        string expectedMerchantNamePrefix = "Acme";
        string expectedMerchantPostalCode = "10045";
        string expectedMerchantState = "NY";
        CardPushTransfers::CardPushTransferPresentmentAmount expectedPresentmentAmount = new()
        {
            Currency = CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd,
            Value = "12.34",
        };
        string expectedRecipientName = "Ian Crease";
        ApiEnum<string, CardPushTransfers::Route> expectedRoute = CardPushTransfers::Route.Visa;
        string expectedSenderAddressCity = "New York";
        string expectedSenderAddressLine1 = "33 Liberty Street";
        string expectedSenderAddressPostalCode = "10045";
        string expectedSenderAddressState = "NY";
        string expectedSenderName = "Ian Crease";
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, CardPushTransfers::CardPushTransferStatus> expectedStatus =
            CardPushTransfers::CardPushTransferStatus.PendingSubmission;
        CardPushTransfers::Submission expectedSubmission = new()
        {
            RetrievalReferenceNumber = "123456789012",
            SenderReference = "OPQRRX3BNAKA6QLT",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "123456",
        };
        ApiEnum<string, CardPushTransfers::Type> expectedType =
            CardPushTransfers::Type.CardPushTransfer;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAcceptance, model.Acceptance);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedApproval, model.Approval);
        Assert.Equal(expectedBusinessApplicationIdentifier, model.BusinessApplicationIdentifier);
        Assert.Equal(expectedCancellation, model.Cancellation);
        Assert.Equal(expectedCardTokenID, model.CardTokenID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedDecline, model.Decline);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedMerchantCategoryCode, model.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCityName, model.MerchantCityName);
        Assert.Equal(expectedMerchantName, model.MerchantName);
        Assert.Equal(expectedMerchantNamePrefix, model.MerchantNamePrefix);
        Assert.Equal(expectedMerchantPostalCode, model.MerchantPostalCode);
        Assert.Equal(expectedMerchantState, model.MerchantState);
        Assert.Equal(expectedPresentmentAmount, model.PresentmentAmount);
        Assert.Equal(expectedRecipientName, model.RecipientName);
        Assert.Equal(expectedRoute, model.Route);
        Assert.Equal(expectedSenderAddressCity, model.SenderAddressCity);
        Assert.Equal(expectedSenderAddressLine1, model.SenderAddressLine1);
        Assert.Equal(expectedSenderAddressPostalCode, model.SenderAddressPostalCode);
        Assert.Equal(expectedSenderAddressState, model.SenderAddressState);
        Assert.Equal(expectedSenderName, model.SenderName);
        Assert.Equal(expectedSourceAccountNumberID, model.SourceAccountNumberID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubmission, model.Submission);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardPushTransfers::CardPushTransfer
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::CardPushTransfer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardPushTransfers::CardPushTransfer
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::CardPushTransfer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye";
        CardPushTransfers::Acceptance expectedAcceptance = new()
        {
            AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            AuthorizationIdentificationResponse = "ABCDEF",
            CardVerificationValue2Result = null,
            NetworkTransactionIdentifier = "841488484271872",
            SettlementAmount = 100,
        };
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        CardPushTransfers::Approval expectedApproval = new()
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };
        ApiEnum<
            string,
            CardPushTransfers::CardPushTransferBusinessApplicationIdentifier
        > expectedBusinessApplicationIdentifier =
            CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.FundsDisbursement;
        CardPushTransfers::Cancellation expectedCancellation = new()
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };
        string expectedCardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        CardPushTransfers::CreatedBy expectedCreatedBy = new()
        {
            Category = CardPushTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        CardPushTransfers::Decline expectedDecline = new()
        {
            DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            NetworkTransactionIdentifier = "841488484271872",
            Reason = CardPushTransfers::Reason.TransactionNotPermittedToCardholder,
        };
        string expectedMerchantCategoryCode = "1234";
        string expectedMerchantCityName = "New York";
        string expectedMerchantName = "Acme Corp";
        string expectedMerchantNamePrefix = "Acme";
        string expectedMerchantPostalCode = "10045";
        string expectedMerchantState = "NY";
        CardPushTransfers::CardPushTransferPresentmentAmount expectedPresentmentAmount = new()
        {
            Currency = CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd,
            Value = "12.34",
        };
        string expectedRecipientName = "Ian Crease";
        ApiEnum<string, CardPushTransfers::Route> expectedRoute = CardPushTransfers::Route.Visa;
        string expectedSenderAddressCity = "New York";
        string expectedSenderAddressLine1 = "33 Liberty Street";
        string expectedSenderAddressPostalCode = "10045";
        string expectedSenderAddressState = "NY";
        string expectedSenderName = "Ian Crease";
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, CardPushTransfers::CardPushTransferStatus> expectedStatus =
            CardPushTransfers::CardPushTransferStatus.PendingSubmission;
        CardPushTransfers::Submission expectedSubmission = new()
        {
            RetrievalReferenceNumber = "123456789012",
            SenderReference = "OPQRRX3BNAKA6QLT",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "123456",
        };
        ApiEnum<string, CardPushTransfers::Type> expectedType =
            CardPushTransfers::Type.CardPushTransfer;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAcceptance, deserialized.Acceptance);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedApproval, deserialized.Approval);
        Assert.Equal(
            expectedBusinessApplicationIdentifier,
            deserialized.BusinessApplicationIdentifier
        );
        Assert.Equal(expectedCancellation, deserialized.Cancellation);
        Assert.Equal(expectedCardTokenID, deserialized.CardTokenID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedDecline, deserialized.Decline);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedMerchantCategoryCode, deserialized.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCityName, deserialized.MerchantCityName);
        Assert.Equal(expectedMerchantName, deserialized.MerchantName);
        Assert.Equal(expectedMerchantNamePrefix, deserialized.MerchantNamePrefix);
        Assert.Equal(expectedMerchantPostalCode, deserialized.MerchantPostalCode);
        Assert.Equal(expectedMerchantState, deserialized.MerchantState);
        Assert.Equal(expectedPresentmentAmount, deserialized.PresentmentAmount);
        Assert.Equal(expectedRecipientName, deserialized.RecipientName);
        Assert.Equal(expectedRoute, deserialized.Route);
        Assert.Equal(expectedSenderAddressCity, deserialized.SenderAddressCity);
        Assert.Equal(expectedSenderAddressLine1, deserialized.SenderAddressLine1);
        Assert.Equal(expectedSenderAddressPostalCode, deserialized.SenderAddressPostalCode);
        Assert.Equal(expectedSenderAddressState, deserialized.SenderAddressState);
        Assert.Equal(expectedSenderName, deserialized.SenderName);
        Assert.Equal(expectedSourceAccountNumberID, deserialized.SourceAccountNumberID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubmission, deserialized.Submission);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardPushTransfers::CardPushTransfer
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardPushTransfers::CardPushTransfer
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
        };

        CardPushTransfers::CardPushTransfer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AcceptanceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardPushTransfers::Acceptance
        {
            AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            AuthorizationIdentificationResponse = "ABCDEF",
            CardVerificationValue2Result = null,
            NetworkTransactionIdentifier = "841488484271872",
            SettlementAmount = 100,
        };

        DateTimeOffset expectedAcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedAuthorizationIdentificationResponse = "ABCDEF";
        string expectedNetworkTransactionIdentifier = "841488484271872";
        long expectedSettlementAmount = 100;

        Assert.Equal(expectedAcceptedAt, model.AcceptedAt);
        Assert.Equal(
            expectedAuthorizationIdentificationResponse,
            model.AuthorizationIdentificationResponse
        );
        Assert.Null(model.CardVerificationValue2Result);
        Assert.Equal(expectedNetworkTransactionIdentifier, model.NetworkTransactionIdentifier);
        Assert.Equal(expectedSettlementAmount, model.SettlementAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardPushTransfers::Acceptance
        {
            AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            AuthorizationIdentificationResponse = "ABCDEF",
            CardVerificationValue2Result = null,
            NetworkTransactionIdentifier = "841488484271872",
            SettlementAmount = 100,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::Acceptance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardPushTransfers::Acceptance
        {
            AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            AuthorizationIdentificationResponse = "ABCDEF",
            CardVerificationValue2Result = null,
            NetworkTransactionIdentifier = "841488484271872",
            SettlementAmount = 100,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::Acceptance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedAuthorizationIdentificationResponse = "ABCDEF";
        string expectedNetworkTransactionIdentifier = "841488484271872";
        long expectedSettlementAmount = 100;

        Assert.Equal(expectedAcceptedAt, deserialized.AcceptedAt);
        Assert.Equal(
            expectedAuthorizationIdentificationResponse,
            deserialized.AuthorizationIdentificationResponse
        );
        Assert.Null(deserialized.CardVerificationValue2Result);
        Assert.Equal(
            expectedNetworkTransactionIdentifier,
            deserialized.NetworkTransactionIdentifier
        );
        Assert.Equal(expectedSettlementAmount, deserialized.SettlementAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardPushTransfers::Acceptance
        {
            AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            AuthorizationIdentificationResponse = "ABCDEF",
            CardVerificationValue2Result = null,
            NetworkTransactionIdentifier = "841488484271872",
            SettlementAmount = 100,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardPushTransfers::Acceptance
        {
            AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            AuthorizationIdentificationResponse = "ABCDEF",
            CardVerificationValue2Result = null,
            NetworkTransactionIdentifier = "841488484271872",
            SettlementAmount = 100,
        };

        CardPushTransfers::Acceptance copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardVerificationValue2ResultTest : TestBase
{
    [Theory]
    [InlineData(CardPushTransfers::CardVerificationValue2Result.Match)]
    [InlineData(CardPushTransfers::CardVerificationValue2Result.NoMatch)]
    public void Validation_Works(CardPushTransfers::CardVerificationValue2Result rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardPushTransfers::CardVerificationValue2Result> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardPushTransfers::CardVerificationValue2Result>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardPushTransfers::CardVerificationValue2Result.Match)]
    [InlineData(CardPushTransfers::CardVerificationValue2Result.NoMatch)]
    public void SerializationRoundtrip_Works(
        CardPushTransfers::CardVerificationValue2Result rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardPushTransfers::CardVerificationValue2Result> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardPushTransfers::CardVerificationValue2Result>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardPushTransfers::CardVerificationValue2Result>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardPushTransfers::CardVerificationValue2Result>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ApprovalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardPushTransfers::Approval
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
        var model = new CardPushTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::Approval>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardPushTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::Approval>(
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
        var model = new CardPushTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardPushTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        CardPushTransfers::Approval copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardPushTransferBusinessApplicationIdentifierTest : TestBase
{
    [Theory]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.AccountToAccount)]
    [InlineData(
        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.BusinessToBusiness
    )]
    [InlineData(
        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.MoneyTransferBankInitiated
    )]
    [InlineData(
        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.NonCardBillPayment
    )]
    [InlineData(
        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.ConsumerBillPayment
    )]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.CardBillPayment)]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.FundsDisbursement)]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.FundsTransfer)]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.LoyaltyAndOffers)]
    [InlineData(
        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.MerchantDisbursement
    )]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.MerchantPayment)]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.PersonToPerson)]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.TopUp)]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.WalletTransfer)]
    public void Validation_Works(
        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardPushTransfers::CardPushTransferBusinessApplicationIdentifier> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardPushTransfers::CardPushTransferBusinessApplicationIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.AccountToAccount)]
    [InlineData(
        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.BusinessToBusiness
    )]
    [InlineData(
        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.MoneyTransferBankInitiated
    )]
    [InlineData(
        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.NonCardBillPayment
    )]
    [InlineData(
        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.ConsumerBillPayment
    )]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.CardBillPayment)]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.FundsDisbursement)]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.FundsTransfer)]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.LoyaltyAndOffers)]
    [InlineData(
        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.MerchantDisbursement
    )]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.MerchantPayment)]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.PersonToPerson)]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.TopUp)]
    [InlineData(CardPushTransfers::CardPushTransferBusinessApplicationIdentifier.WalletTransfer)]
    public void SerializationRoundtrip_Works(
        CardPushTransfers::CardPushTransferBusinessApplicationIdentifier rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardPushTransfers::CardPushTransferBusinessApplicationIdentifier> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardPushTransfers::CardPushTransferBusinessApplicationIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardPushTransfers::CardPushTransferBusinessApplicationIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardPushTransfers::CardPushTransferBusinessApplicationIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardPushTransfers::Cancellation
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
        var model = new CardPushTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::Cancellation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardPushTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::Cancellation>(
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
        var model = new CardPushTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardPushTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        CardPushTransfers::Cancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreatedByTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardPushTransfers::CreatedBy
        {
            Category = CardPushTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        ApiEnum<string, CardPushTransfers::Category> expectedCategory =
            CardPushTransfers::Category.User;
        CardPushTransfers::ApiKey expectedApiKey = new("description");
        CardPushTransfers::OAuthApplication expectedOAuthApplication = new("name");
        CardPushTransfers::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedOAuthApplication, model.OAuthApplication);
        Assert.Equal(expectedUser, model.User);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardPushTransfers::CreatedBy
        {
            Category = CardPushTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::CreatedBy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardPushTransfers::CreatedBy
        {
            Category = CardPushTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::CreatedBy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CardPushTransfers::Category> expectedCategory =
            CardPushTransfers::Category.User;
        CardPushTransfers::ApiKey expectedApiKey = new("description");
        CardPushTransfers::OAuthApplication expectedOAuthApplication = new("name");
        CardPushTransfers::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedOAuthApplication, deserialized.OAuthApplication);
        Assert.Equal(expectedUser, deserialized.User);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardPushTransfers::CreatedBy
        {
            Category = CardPushTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CardPushTransfers::CreatedBy
        {
            Category = CardPushTransfers::Category.User,
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
        var model = new CardPushTransfers::CreatedBy
        {
            Category = CardPushTransfers::Category.User,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CardPushTransfers::CreatedBy
        {
            Category = CardPushTransfers::Category.User,

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
        var model = new CardPushTransfers::CreatedBy
        {
            Category = CardPushTransfers::Category.User,

            ApiKey = null,
            OAuthApplication = null,
            User = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardPushTransfers::CreatedBy
        {
            Category = CardPushTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        CardPushTransfers::CreatedBy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(CardPushTransfers::Category.ApiKey)]
    [InlineData(CardPushTransfers::Category.OAuthApplication)]
    [InlineData(CardPushTransfers::Category.User)]
    public void Validation_Works(CardPushTransfers::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardPushTransfers::Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardPushTransfers::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardPushTransfers::Category.ApiKey)]
    [InlineData(CardPushTransfers::Category.OAuthApplication)]
    [InlineData(CardPushTransfers::Category.User)]
    public void SerializationRoundtrip_Works(CardPushTransfers::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardPushTransfers::Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardPushTransfers::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardPushTransfers::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardPushTransfers::Category>>(
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
        var model = new CardPushTransfers::ApiKey { Description = "description" };

        string expectedDescription = "description";

        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardPushTransfers::ApiKey { Description = "description" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::ApiKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardPushTransfers::ApiKey { Description = "description" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::ApiKey>(
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
        var model = new CardPushTransfers::ApiKey { Description = "description" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardPushTransfers::ApiKey { Description = "description" };

        CardPushTransfers::ApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OAuthApplicationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardPushTransfers::OAuthApplication { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardPushTransfers::OAuthApplication { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::OAuthApplication>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardPushTransfers::OAuthApplication { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::OAuthApplication>(
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
        var model = new CardPushTransfers::OAuthApplication { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardPushTransfers::OAuthApplication { Name = "name" };

        CardPushTransfers::OAuthApplication copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardPushTransfers::User { Email = "email" };

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardPushTransfers::User { Email = "email" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::User>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardPushTransfers::User { Email = "email" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::User>(
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
        var model = new CardPushTransfers::User { Email = "email" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardPushTransfers::User { Email = "email" };

        CardPushTransfers::User copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeclineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardPushTransfers::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            NetworkTransactionIdentifier = "841488484271872",
            Reason = CardPushTransfers::Reason.TransactionNotPermittedToCardholder,
        };

        DateTimeOffset expectedDeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedNetworkTransactionIdentifier = "841488484271872";
        ApiEnum<string, CardPushTransfers::Reason> expectedReason =
            CardPushTransfers::Reason.TransactionNotPermittedToCardholder;

        Assert.Equal(expectedDeclinedAt, model.DeclinedAt);
        Assert.Equal(expectedNetworkTransactionIdentifier, model.NetworkTransactionIdentifier);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardPushTransfers::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            NetworkTransactionIdentifier = "841488484271872",
            Reason = CardPushTransfers::Reason.TransactionNotPermittedToCardholder,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::Decline>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardPushTransfers::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            NetworkTransactionIdentifier = "841488484271872",
            Reason = CardPushTransfers::Reason.TransactionNotPermittedToCardholder,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::Decline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedDeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedNetworkTransactionIdentifier = "841488484271872";
        ApiEnum<string, CardPushTransfers::Reason> expectedReason =
            CardPushTransfers::Reason.TransactionNotPermittedToCardholder;

        Assert.Equal(expectedDeclinedAt, deserialized.DeclinedAt);
        Assert.Equal(
            expectedNetworkTransactionIdentifier,
            deserialized.NetworkTransactionIdentifier
        );
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardPushTransfers::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            NetworkTransactionIdentifier = "841488484271872",
            Reason = CardPushTransfers::Reason.TransactionNotPermittedToCardholder,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardPushTransfers::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            NetworkTransactionIdentifier = "841488484271872",
            Reason = CardPushTransfers::Reason.TransactionNotPermittedToCardholder,
        };

        CardPushTransfers::Decline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(CardPushTransfers::Reason.DoNotHonor)]
    [InlineData(CardPushTransfers::Reason.ActivityCountLimitExceeded)]
    [InlineData(CardPushTransfers::Reason.ReferToCardIssuer)]
    [InlineData(CardPushTransfers::Reason.ReferToCardIssuerSpecialCondition)]
    [InlineData(CardPushTransfers::Reason.InvalidMerchant)]
    [InlineData(CardPushTransfers::Reason.PickUpCard)]
    [InlineData(CardPushTransfers::Reason.Error)]
    [InlineData(CardPushTransfers::Reason.PickUpCardSpecial)]
    [InlineData(CardPushTransfers::Reason.InvalidTransaction)]
    [InlineData(CardPushTransfers::Reason.InvalidAmount)]
    [InlineData(CardPushTransfers::Reason.InvalidAccountNumber)]
    [InlineData(CardPushTransfers::Reason.NoSuchIssuer)]
    [InlineData(CardPushTransfers::Reason.ReEnterTransaction)]
    [InlineData(CardPushTransfers::Reason.NoCreditAccount)]
    [InlineData(CardPushTransfers::Reason.PickUpCardLost)]
    [InlineData(CardPushTransfers::Reason.PickUpCardStolen)]
    [InlineData(CardPushTransfers::Reason.ClosedAccount)]
    [InlineData(CardPushTransfers::Reason.InsufficientFunds)]
    [InlineData(CardPushTransfers::Reason.NoCheckingAccount)]
    [InlineData(CardPushTransfers::Reason.NoSavingsAccount)]
    [InlineData(CardPushTransfers::Reason.ExpiredCard)]
    [InlineData(CardPushTransfers::Reason.TransactionNotPermittedToCardholder)]
    [InlineData(CardPushTransfers::Reason.TransactionNotAllowedAtTerminal)]
    [InlineData(CardPushTransfers::Reason.TransactionNotSupportedOrBlockedByIssuer)]
    [InlineData(CardPushTransfers::Reason.SuspectedFraud)]
    [InlineData(CardPushTransfers::Reason.ActivityAmountLimitExceeded)]
    [InlineData(CardPushTransfers::Reason.RestrictedCard)]
    [InlineData(CardPushTransfers::Reason.SecurityViolation)]
    [InlineData(CardPushTransfers::Reason.TransactionDoesNotFulfillAntiMoneyLaunderingRequirement)]
    [InlineData(CardPushTransfers::Reason.BlockedByCardholder)]
    [InlineData(CardPushTransfers::Reason.BlockedFirstUse)]
    [InlineData(CardPushTransfers::Reason.CreditIssuerUnavailable)]
    [InlineData(CardPushTransfers::Reason.NegativeCardVerificationValueResults)]
    [InlineData(CardPushTransfers::Reason.IssuerUnavailable)]
    [InlineData(CardPushTransfers::Reason.FinancialInstitutionCannotBeFound)]
    [InlineData(CardPushTransfers::Reason.TransactionCannotBeCompleted)]
    [InlineData(CardPushTransfers::Reason.DuplicateTransaction)]
    [InlineData(CardPushTransfers::Reason.SystemMalfunction)]
    [InlineData(CardPushTransfers::Reason.AdditionalCustomerAuthenticationRequired)]
    [InlineData(CardPushTransfers::Reason.SurchargeAmountNotPermitted)]
    [InlineData(CardPushTransfers::Reason.DeclineForCvv2Failure)]
    [InlineData(CardPushTransfers::Reason.StopPaymentOrder)]
    [InlineData(CardPushTransfers::Reason.RevocationOfAuthorizationOrder)]
    [InlineData(CardPushTransfers::Reason.RevocationOfAllAuthorizationsOrder)]
    [InlineData(CardPushTransfers::Reason.UnableToLocateRecord)]
    [InlineData(CardPushTransfers::Reason.FileIsTemporarilyUnavailable)]
    [InlineData(CardPushTransfers::Reason.IncorrectPin)]
    [InlineData(CardPushTransfers::Reason.AllowableNumberOfPinEntryTriesExceeded)]
    [InlineData(CardPushTransfers::Reason.UnableToLocatePreviousMessage)]
    [InlineData(CardPushTransfers::Reason.PinErrorFound)]
    [InlineData(CardPushTransfers::Reason.CannotVerifyPin)]
    [InlineData(CardPushTransfers::Reason.VerificationDataFailed)]
    [InlineData(CardPushTransfers::Reason.SurchargeAmountNotSupportedByDebitNetworkIssuer)]
    [InlineData(CardPushTransfers::Reason.CashServiceNotAvailable)]
    [InlineData(CardPushTransfers::Reason.CashbackRequestExceedsIssuerLimit)]
    [InlineData(CardPushTransfers::Reason.TransactionAmountExceedsPreAuthorizedApprovalAmount)]
    [InlineData(CardPushTransfers::Reason.TransactionDoesNotQualifyForVisaPin)]
    [InlineData(CardPushTransfers::Reason.OfflineDeclined)]
    [InlineData(CardPushTransfers::Reason.UnableToGoOnline)]
    [InlineData(CardPushTransfers::Reason.ValidAccountButAmountNotSupported)]
    [InlineData(CardPushTransfers::Reason.InvalidUseOfMerchantCategoryCodeCorrectAndReattempt)]
    [InlineData(CardPushTransfers::Reason.CardAuthenticationFailed)]
    public void Validation_Works(CardPushTransfers::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardPushTransfers::Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardPushTransfers::Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardPushTransfers::Reason.DoNotHonor)]
    [InlineData(CardPushTransfers::Reason.ActivityCountLimitExceeded)]
    [InlineData(CardPushTransfers::Reason.ReferToCardIssuer)]
    [InlineData(CardPushTransfers::Reason.ReferToCardIssuerSpecialCondition)]
    [InlineData(CardPushTransfers::Reason.InvalidMerchant)]
    [InlineData(CardPushTransfers::Reason.PickUpCard)]
    [InlineData(CardPushTransfers::Reason.Error)]
    [InlineData(CardPushTransfers::Reason.PickUpCardSpecial)]
    [InlineData(CardPushTransfers::Reason.InvalidTransaction)]
    [InlineData(CardPushTransfers::Reason.InvalidAmount)]
    [InlineData(CardPushTransfers::Reason.InvalidAccountNumber)]
    [InlineData(CardPushTransfers::Reason.NoSuchIssuer)]
    [InlineData(CardPushTransfers::Reason.ReEnterTransaction)]
    [InlineData(CardPushTransfers::Reason.NoCreditAccount)]
    [InlineData(CardPushTransfers::Reason.PickUpCardLost)]
    [InlineData(CardPushTransfers::Reason.PickUpCardStolen)]
    [InlineData(CardPushTransfers::Reason.ClosedAccount)]
    [InlineData(CardPushTransfers::Reason.InsufficientFunds)]
    [InlineData(CardPushTransfers::Reason.NoCheckingAccount)]
    [InlineData(CardPushTransfers::Reason.NoSavingsAccount)]
    [InlineData(CardPushTransfers::Reason.ExpiredCard)]
    [InlineData(CardPushTransfers::Reason.TransactionNotPermittedToCardholder)]
    [InlineData(CardPushTransfers::Reason.TransactionNotAllowedAtTerminal)]
    [InlineData(CardPushTransfers::Reason.TransactionNotSupportedOrBlockedByIssuer)]
    [InlineData(CardPushTransfers::Reason.SuspectedFraud)]
    [InlineData(CardPushTransfers::Reason.ActivityAmountLimitExceeded)]
    [InlineData(CardPushTransfers::Reason.RestrictedCard)]
    [InlineData(CardPushTransfers::Reason.SecurityViolation)]
    [InlineData(CardPushTransfers::Reason.TransactionDoesNotFulfillAntiMoneyLaunderingRequirement)]
    [InlineData(CardPushTransfers::Reason.BlockedByCardholder)]
    [InlineData(CardPushTransfers::Reason.BlockedFirstUse)]
    [InlineData(CardPushTransfers::Reason.CreditIssuerUnavailable)]
    [InlineData(CardPushTransfers::Reason.NegativeCardVerificationValueResults)]
    [InlineData(CardPushTransfers::Reason.IssuerUnavailable)]
    [InlineData(CardPushTransfers::Reason.FinancialInstitutionCannotBeFound)]
    [InlineData(CardPushTransfers::Reason.TransactionCannotBeCompleted)]
    [InlineData(CardPushTransfers::Reason.DuplicateTransaction)]
    [InlineData(CardPushTransfers::Reason.SystemMalfunction)]
    [InlineData(CardPushTransfers::Reason.AdditionalCustomerAuthenticationRequired)]
    [InlineData(CardPushTransfers::Reason.SurchargeAmountNotPermitted)]
    [InlineData(CardPushTransfers::Reason.DeclineForCvv2Failure)]
    [InlineData(CardPushTransfers::Reason.StopPaymentOrder)]
    [InlineData(CardPushTransfers::Reason.RevocationOfAuthorizationOrder)]
    [InlineData(CardPushTransfers::Reason.RevocationOfAllAuthorizationsOrder)]
    [InlineData(CardPushTransfers::Reason.UnableToLocateRecord)]
    [InlineData(CardPushTransfers::Reason.FileIsTemporarilyUnavailable)]
    [InlineData(CardPushTransfers::Reason.IncorrectPin)]
    [InlineData(CardPushTransfers::Reason.AllowableNumberOfPinEntryTriesExceeded)]
    [InlineData(CardPushTransfers::Reason.UnableToLocatePreviousMessage)]
    [InlineData(CardPushTransfers::Reason.PinErrorFound)]
    [InlineData(CardPushTransfers::Reason.CannotVerifyPin)]
    [InlineData(CardPushTransfers::Reason.VerificationDataFailed)]
    [InlineData(CardPushTransfers::Reason.SurchargeAmountNotSupportedByDebitNetworkIssuer)]
    [InlineData(CardPushTransfers::Reason.CashServiceNotAvailable)]
    [InlineData(CardPushTransfers::Reason.CashbackRequestExceedsIssuerLimit)]
    [InlineData(CardPushTransfers::Reason.TransactionAmountExceedsPreAuthorizedApprovalAmount)]
    [InlineData(CardPushTransfers::Reason.TransactionDoesNotQualifyForVisaPin)]
    [InlineData(CardPushTransfers::Reason.OfflineDeclined)]
    [InlineData(CardPushTransfers::Reason.UnableToGoOnline)]
    [InlineData(CardPushTransfers::Reason.ValidAccountButAmountNotSupported)]
    [InlineData(CardPushTransfers::Reason.InvalidUseOfMerchantCategoryCodeCorrectAndReattempt)]
    [InlineData(CardPushTransfers::Reason.CardAuthenticationFailed)]
    public void SerializationRoundtrip_Works(CardPushTransfers::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardPushTransfers::Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardPushTransfers::Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardPushTransfers::Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardPushTransfers::Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CardPushTransferPresentmentAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardPushTransfers::CardPushTransferPresentmentAmount
        {
            Currency = CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd,
            Value = "12.34",
        };

        ApiEnum<
            string,
            CardPushTransfers::CardPushTransferPresentmentAmountCurrency
        > expectedCurrency = CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd;
        string expectedValue = "12.34";

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardPushTransfers::CardPushTransferPresentmentAmount
        {
            Currency = CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd,
            Value = "12.34",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardPushTransfers::CardPushTransferPresentmentAmount>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardPushTransfers::CardPushTransferPresentmentAmount
        {
            Currency = CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd,
            Value = "12.34",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardPushTransfers::CardPushTransferPresentmentAmount>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            CardPushTransfers::CardPushTransferPresentmentAmountCurrency
        > expectedCurrency = CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd;
        string expectedValue = "12.34";

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardPushTransfers::CardPushTransferPresentmentAmount
        {
            Currency = CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd,
            Value = "12.34",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardPushTransfers::CardPushTransferPresentmentAmount
        {
            Currency = CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd,
            Value = "12.34",
        };

        CardPushTransfers::CardPushTransferPresentmentAmount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardPushTransferPresentmentAmountCurrencyTest : TestBase
{
    [Theory]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Afn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Eur)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.All)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Dzd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Aoa)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ars)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Amd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Awg)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Aud)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Azn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bsd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bhd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bdt)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bbd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Byn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bzd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bmd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Inr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Btn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bob)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bov)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bam)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bwp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Nok)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Brl)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bnd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bgn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bif)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Cve)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Khr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Cad)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Kyd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Clp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Clf)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Cny)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Cop)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Cou)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Kmf)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Cdf)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Nzd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Crc)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Cup)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Czk)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Dkk)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Djf)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Dop)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Egp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Svc)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ern)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Szl)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Etb)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Fkp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Fjd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Gmd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Gel)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ghs)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Gip)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Gtq)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Gbp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Gnf)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Gyd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Htg)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Hnl)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Hkd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Huf)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Isk)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Idr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Irr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Iqd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ils)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Jmd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Jpy)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Jod)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Kzt)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Kes)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Kpw)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Krw)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Kwd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Kgs)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Lak)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Lbp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Lsl)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Zar)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Lrd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Lyd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Chf)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mop)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mkd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mga)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mwk)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Myr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mvr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mru)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mur)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mxn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mxv)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mdl)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mnt)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mad)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mzn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mmk)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Nad)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Npr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Nio)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ngn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Omr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Pkr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Pab)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Pgk)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Pyg)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Pen)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Php)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Pln)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Qar)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ron)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Rub)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Rwf)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Shp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Wst)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Stn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Sar)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Rsd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Scr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Sle)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Sgd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Sbd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Sos)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ssp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Lkr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Sdg)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Srd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Sek)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Che)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Chw)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Syp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Twd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Tjs)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Tzs)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Thb)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Top)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ttd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Tnd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Try)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Tmt)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ugx)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Uah)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Aed)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Uyu)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Uyi)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Uyw)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Uzs)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Vuv)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ves)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ved)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Vnd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Yer)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Zmw)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Zwg)]
    public void Validation_Works(
        CardPushTransfers::CardPushTransferPresentmentAmountCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardPushTransfers::CardPushTransferPresentmentAmountCurrency> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardPushTransfers::CardPushTransferPresentmentAmountCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Afn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Eur)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.All)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Dzd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Aoa)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ars)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Amd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Awg)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Aud)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Azn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bsd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bhd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bdt)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bbd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Byn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bzd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bmd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Inr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Btn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bob)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bov)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bam)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bwp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Nok)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Brl)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bnd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bgn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Bif)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Cve)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Khr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Cad)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Kyd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Clp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Clf)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Cny)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Cop)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Cou)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Kmf)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Cdf)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Nzd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Crc)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Cup)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Czk)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Dkk)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Djf)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Dop)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Egp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Svc)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ern)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Szl)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Etb)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Fkp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Fjd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Gmd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Gel)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ghs)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Gip)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Gtq)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Gbp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Gnf)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Gyd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Htg)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Hnl)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Hkd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Huf)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Isk)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Idr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Irr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Iqd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ils)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Jmd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Jpy)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Jod)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Kzt)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Kes)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Kpw)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Krw)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Kwd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Kgs)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Lak)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Lbp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Lsl)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Zar)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Lrd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Lyd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Chf)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mop)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mkd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mga)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mwk)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Myr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mvr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mru)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mur)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mxn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mxv)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mdl)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mnt)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mad)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mzn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Mmk)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Nad)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Npr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Nio)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ngn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Omr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Pkr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Pab)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Pgk)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Pyg)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Pen)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Php)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Pln)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Qar)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ron)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Rub)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Rwf)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Shp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Wst)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Stn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Sar)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Rsd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Scr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Sle)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Sgd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Sbd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Sos)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ssp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Lkr)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Sdg)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Srd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Sek)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Che)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Chw)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Syp)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Twd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Tjs)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Tzs)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Thb)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Top)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ttd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Tnd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Try)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Tmt)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ugx)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Uah)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Aed)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Usn)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Uyu)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Uyi)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Uyw)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Uzs)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Vuv)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ves)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Ved)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Vnd)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Yer)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Zmw)]
    [InlineData(CardPushTransfers::CardPushTransferPresentmentAmountCurrency.Zwg)]
    public void SerializationRoundtrip_Works(
        CardPushTransfers::CardPushTransferPresentmentAmountCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardPushTransfers::CardPushTransferPresentmentAmountCurrency> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardPushTransfers::CardPushTransferPresentmentAmountCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardPushTransfers::CardPushTransferPresentmentAmountCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardPushTransfers::CardPushTransferPresentmentAmountCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RouteTest : TestBase
{
    [Theory]
    [InlineData(CardPushTransfers::Route.Visa)]
    [InlineData(CardPushTransfers::Route.Mastercard)]
    [InlineData(CardPushTransfers::Route.Pulse)]
    public void Validation_Works(CardPushTransfers::Route rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardPushTransfers::Route> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardPushTransfers::Route>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardPushTransfers::Route.Visa)]
    [InlineData(CardPushTransfers::Route.Mastercard)]
    [InlineData(CardPushTransfers::Route.Pulse)]
    public void SerializationRoundtrip_Works(CardPushTransfers::Route rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardPushTransfers::Route> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardPushTransfers::Route>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardPushTransfers::Route>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardPushTransfers::Route>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CardPushTransferStatusTest : TestBase
{
    [Theory]
    [InlineData(CardPushTransfers::CardPushTransferStatus.PendingApproval)]
    [InlineData(CardPushTransfers::CardPushTransferStatus.Canceled)]
    [InlineData(CardPushTransfers::CardPushTransferStatus.PendingReviewing)]
    [InlineData(CardPushTransfers::CardPushTransferStatus.RequiresAttention)]
    [InlineData(CardPushTransfers::CardPushTransferStatus.PendingSubmission)]
    [InlineData(CardPushTransfers::CardPushTransferStatus.Submitted)]
    [InlineData(CardPushTransfers::CardPushTransferStatus.Complete)]
    [InlineData(CardPushTransfers::CardPushTransferStatus.Declined)]
    public void Validation_Works(CardPushTransfers::CardPushTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardPushTransfers::CardPushTransferStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardPushTransfers::CardPushTransferStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardPushTransfers::CardPushTransferStatus.PendingApproval)]
    [InlineData(CardPushTransfers::CardPushTransferStatus.Canceled)]
    [InlineData(CardPushTransfers::CardPushTransferStatus.PendingReviewing)]
    [InlineData(CardPushTransfers::CardPushTransferStatus.RequiresAttention)]
    [InlineData(CardPushTransfers::CardPushTransferStatus.PendingSubmission)]
    [InlineData(CardPushTransfers::CardPushTransferStatus.Submitted)]
    [InlineData(CardPushTransfers::CardPushTransferStatus.Complete)]
    [InlineData(CardPushTransfers::CardPushTransferStatus.Declined)]
    public void SerializationRoundtrip_Works(CardPushTransfers::CardPushTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardPushTransfers::CardPushTransferStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardPushTransfers::CardPushTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardPushTransfers::CardPushTransferStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardPushTransfers::CardPushTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubmissionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardPushTransfers::Submission
        {
            RetrievalReferenceNumber = "123456789012",
            SenderReference = "OPQRRX3BNAKA6QLT",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "123456",
        };

        string expectedRetrievalReferenceNumber = "123456789012";
        string expectedSenderReference = "OPQRRX3BNAKA6QLT";
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedTraceNumber = "123456";

        Assert.Equal(expectedRetrievalReferenceNumber, model.RetrievalReferenceNumber);
        Assert.Equal(expectedSenderReference, model.SenderReference);
        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
        Assert.Equal(expectedTraceNumber, model.TraceNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardPushTransfers::Submission
        {
            RetrievalReferenceNumber = "123456789012",
            SenderReference = "OPQRRX3BNAKA6QLT",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "123456",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::Submission>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardPushTransfers::Submission
        {
            RetrievalReferenceNumber = "123456789012",
            SenderReference = "OPQRRX3BNAKA6QLT",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "123456",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPushTransfers::Submission>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRetrievalReferenceNumber = "123456789012";
        string expectedSenderReference = "OPQRRX3BNAKA6QLT";
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedTraceNumber = "123456";

        Assert.Equal(expectedRetrievalReferenceNumber, deserialized.RetrievalReferenceNumber);
        Assert.Equal(expectedSenderReference, deserialized.SenderReference);
        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
        Assert.Equal(expectedTraceNumber, deserialized.TraceNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardPushTransfers::Submission
        {
            RetrievalReferenceNumber = "123456789012",
            SenderReference = "OPQRRX3BNAKA6QLT",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "123456",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardPushTransfers::Submission
        {
            RetrievalReferenceNumber = "123456789012",
            SenderReference = "OPQRRX3BNAKA6QLT",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "123456",
        };

        CardPushTransfers::Submission copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(CardPushTransfers::Type.CardPushTransfer)]
    public void Validation_Works(CardPushTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardPushTransfers::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardPushTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardPushTransfers::Type.CardPushTransfer)]
    public void SerializationRoundtrip_Works(CardPushTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardPushTransfers::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardPushTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardPushTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardPushTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
