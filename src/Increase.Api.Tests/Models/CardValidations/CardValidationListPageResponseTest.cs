using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using CardValidations = Increase.Api.Models.CardValidations;

namespace Increase.Api.Tests.Models.CardValidations;

public class CardValidationListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardValidations::CardValidationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "outbound_card_validation_qqlzagpc6v1x2gcdhe24",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        AuthorizationIdentificationResponse = "ABCDEF",
                        CardVerificationValue2Result = null,
                        CardholderFirstNameResult = null,
                        CardholderFullNameResult = null,
                        CardholderLastNameResult = null,
                        CardholderMiddleNameResult = null,
                        CardholderPostalCodeResult = null,
                        CardholderStreetAddressResult = null,
                        NetworkTransactionIdentifier = "841488484271872",
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                    CardholderFirstName = "Dee",
                    CardholderLastName = "Hock",
                    CardholderMiddleName = "Ward",
                    CardholderPostalCode = "10045",
                    CardholderStreetAddress = "33 Liberty Street",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = CardValidations::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Decline = new()
                    {
                        DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        NetworkTransactionIdentifier = "841488484271872",
                        Reason = CardValidations::Reason.TransactionNotPermittedToCardholder,
                    },
                    IdempotencyKey = null,
                    MerchantCategoryCode = "1234",
                    MerchantCityName = "New York",
                    MerchantName = "Acme Corp",
                    MerchantPostalCode = "10045",
                    MerchantState = "NY",
                    Route = CardValidations::Route.Visa,
                    Status = CardValidations::CardValidationStatus.PendingSubmission,
                    Submission = new()
                    {
                        RetrievalReferenceNumber = "123456789012",
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TraceNumber = "123456",
                    },
                    Type = CardValidations::Type.CardValidation,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<CardValidations::CardValidation> expectedData =
        [
            new()
            {
                ID = "outbound_card_validation_qqlzagpc6v1x2gcdhe24",
                Acceptance = new()
                {
                    AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    AuthorizationIdentificationResponse = "ABCDEF",
                    CardVerificationValue2Result = null,
                    CardholderFirstNameResult = null,
                    CardholderFullNameResult = null,
                    CardholderLastNameResult = null,
                    CardholderMiddleNameResult = null,
                    CardholderPostalCodeResult = null,
                    CardholderStreetAddressResult = null,
                    NetworkTransactionIdentifier = "841488484271872",
                },
                AccountID = "account_in71c4amph0vgo2qllky",
                CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                CardholderFirstName = "Dee",
                CardholderLastName = "Hock",
                CardholderMiddleName = "Ward",
                CardholderPostalCode = "10045",
                CardholderStreetAddress = "33 Liberty Street",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedBy = new()
                {
                    Category = CardValidations::Category.User,
                    ApiKey = new("description"),
                    OAuthApplication = new("name"),
                    User = new("user@example.com"),
                },
                Decline = new()
                {
                    DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    NetworkTransactionIdentifier = "841488484271872",
                    Reason = CardValidations::Reason.TransactionNotPermittedToCardholder,
                },
                IdempotencyKey = null,
                MerchantCategoryCode = "1234",
                MerchantCityName = "New York",
                MerchantName = "Acme Corp",
                MerchantPostalCode = "10045",
                MerchantState = "NY",
                Route = CardValidations::Route.Visa,
                Status = CardValidations::CardValidationStatus.PendingSubmission,
                Submission = new()
                {
                    RetrievalReferenceNumber = "123456789012",
                    SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TraceNumber = "123456",
                },
                Type = CardValidations::Type.CardValidation,
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
        var model = new CardValidations::CardValidationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "outbound_card_validation_qqlzagpc6v1x2gcdhe24",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        AuthorizationIdentificationResponse = "ABCDEF",
                        CardVerificationValue2Result = null,
                        CardholderFirstNameResult = null,
                        CardholderFullNameResult = null,
                        CardholderLastNameResult = null,
                        CardholderMiddleNameResult = null,
                        CardholderPostalCodeResult = null,
                        CardholderStreetAddressResult = null,
                        NetworkTransactionIdentifier = "841488484271872",
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                    CardholderFirstName = "Dee",
                    CardholderLastName = "Hock",
                    CardholderMiddleName = "Ward",
                    CardholderPostalCode = "10045",
                    CardholderStreetAddress = "33 Liberty Street",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = CardValidations::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Decline = new()
                    {
                        DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        NetworkTransactionIdentifier = "841488484271872",
                        Reason = CardValidations::Reason.TransactionNotPermittedToCardholder,
                    },
                    IdempotencyKey = null,
                    MerchantCategoryCode = "1234",
                    MerchantCityName = "New York",
                    MerchantName = "Acme Corp",
                    MerchantPostalCode = "10045",
                    MerchantState = "NY",
                    Route = CardValidations::Route.Visa,
                    Status = CardValidations::CardValidationStatus.PendingSubmission,
                    Submission = new()
                    {
                        RetrievalReferenceNumber = "123456789012",
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TraceNumber = "123456",
                    },
                    Type = CardValidations::Type.CardValidation,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardValidations::CardValidationListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardValidations::CardValidationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "outbound_card_validation_qqlzagpc6v1x2gcdhe24",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        AuthorizationIdentificationResponse = "ABCDEF",
                        CardVerificationValue2Result = null,
                        CardholderFirstNameResult = null,
                        CardholderFullNameResult = null,
                        CardholderLastNameResult = null,
                        CardholderMiddleNameResult = null,
                        CardholderPostalCodeResult = null,
                        CardholderStreetAddressResult = null,
                        NetworkTransactionIdentifier = "841488484271872",
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                    CardholderFirstName = "Dee",
                    CardholderLastName = "Hock",
                    CardholderMiddleName = "Ward",
                    CardholderPostalCode = "10045",
                    CardholderStreetAddress = "33 Liberty Street",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = CardValidations::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Decline = new()
                    {
                        DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        NetworkTransactionIdentifier = "841488484271872",
                        Reason = CardValidations::Reason.TransactionNotPermittedToCardholder,
                    },
                    IdempotencyKey = null,
                    MerchantCategoryCode = "1234",
                    MerchantCityName = "New York",
                    MerchantName = "Acme Corp",
                    MerchantPostalCode = "10045",
                    MerchantState = "NY",
                    Route = CardValidations::Route.Visa,
                    Status = CardValidations::CardValidationStatus.PendingSubmission,
                    Submission = new()
                    {
                        RetrievalReferenceNumber = "123456789012",
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TraceNumber = "123456",
                    },
                    Type = CardValidations::Type.CardValidation,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardValidations::CardValidationListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<CardValidations::CardValidation> expectedData =
        [
            new()
            {
                ID = "outbound_card_validation_qqlzagpc6v1x2gcdhe24",
                Acceptance = new()
                {
                    AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    AuthorizationIdentificationResponse = "ABCDEF",
                    CardVerificationValue2Result = null,
                    CardholderFirstNameResult = null,
                    CardholderFullNameResult = null,
                    CardholderLastNameResult = null,
                    CardholderMiddleNameResult = null,
                    CardholderPostalCodeResult = null,
                    CardholderStreetAddressResult = null,
                    NetworkTransactionIdentifier = "841488484271872",
                },
                AccountID = "account_in71c4amph0vgo2qllky",
                CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                CardholderFirstName = "Dee",
                CardholderLastName = "Hock",
                CardholderMiddleName = "Ward",
                CardholderPostalCode = "10045",
                CardholderStreetAddress = "33 Liberty Street",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedBy = new()
                {
                    Category = CardValidations::Category.User,
                    ApiKey = new("description"),
                    OAuthApplication = new("name"),
                    User = new("user@example.com"),
                },
                Decline = new()
                {
                    DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    NetworkTransactionIdentifier = "841488484271872",
                    Reason = CardValidations::Reason.TransactionNotPermittedToCardholder,
                },
                IdempotencyKey = null,
                MerchantCategoryCode = "1234",
                MerchantCityName = "New York",
                MerchantName = "Acme Corp",
                MerchantPostalCode = "10045",
                MerchantState = "NY",
                Route = CardValidations::Route.Visa,
                Status = CardValidations::CardValidationStatus.PendingSubmission,
                Submission = new()
                {
                    RetrievalReferenceNumber = "123456789012",
                    SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TraceNumber = "123456",
                },
                Type = CardValidations::Type.CardValidation,
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
        var model = new CardValidations::CardValidationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "outbound_card_validation_qqlzagpc6v1x2gcdhe24",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        AuthorizationIdentificationResponse = "ABCDEF",
                        CardVerificationValue2Result = null,
                        CardholderFirstNameResult = null,
                        CardholderFullNameResult = null,
                        CardholderLastNameResult = null,
                        CardholderMiddleNameResult = null,
                        CardholderPostalCodeResult = null,
                        CardholderStreetAddressResult = null,
                        NetworkTransactionIdentifier = "841488484271872",
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                    CardholderFirstName = "Dee",
                    CardholderLastName = "Hock",
                    CardholderMiddleName = "Ward",
                    CardholderPostalCode = "10045",
                    CardholderStreetAddress = "33 Liberty Street",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = CardValidations::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Decline = new()
                    {
                        DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        NetworkTransactionIdentifier = "841488484271872",
                        Reason = CardValidations::Reason.TransactionNotPermittedToCardholder,
                    },
                    IdempotencyKey = null,
                    MerchantCategoryCode = "1234",
                    MerchantCityName = "New York",
                    MerchantName = "Acme Corp",
                    MerchantPostalCode = "10045",
                    MerchantState = "NY",
                    Route = CardValidations::Route.Visa,
                    Status = CardValidations::CardValidationStatus.PendingSubmission,
                    Submission = new()
                    {
                        RetrievalReferenceNumber = "123456789012",
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TraceNumber = "123456",
                    },
                    Type = CardValidations::Type.CardValidation,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardValidations::CardValidationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "outbound_card_validation_qqlzagpc6v1x2gcdhe24",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        AuthorizationIdentificationResponse = "ABCDEF",
                        CardVerificationValue2Result = null,
                        CardholderFirstNameResult = null,
                        CardholderFullNameResult = null,
                        CardholderLastNameResult = null,
                        CardholderMiddleNameResult = null,
                        CardholderPostalCodeResult = null,
                        CardholderStreetAddressResult = null,
                        NetworkTransactionIdentifier = "841488484271872",
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                    CardholderFirstName = "Dee",
                    CardholderLastName = "Hock",
                    CardholderMiddleName = "Ward",
                    CardholderPostalCode = "10045",
                    CardholderStreetAddress = "33 Liberty Street",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = CardValidations::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Decline = new()
                    {
                        DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        NetworkTransactionIdentifier = "841488484271872",
                        Reason = CardValidations::Reason.TransactionNotPermittedToCardholder,
                    },
                    IdempotencyKey = null,
                    MerchantCategoryCode = "1234",
                    MerchantCityName = "New York",
                    MerchantName = "Acme Corp",
                    MerchantPostalCode = "10045",
                    MerchantState = "NY",
                    Route = CardValidations::Route.Visa,
                    Status = CardValidations::CardValidationStatus.PendingSubmission,
                    Submission = new()
                    {
                        RetrievalReferenceNumber = "123456789012",
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TraceNumber = "123456",
                    },
                    Type = CardValidations::Type.CardValidation,
                },
            ],
            NextCursor = "v57w5d",
        };

        CardValidations::CardValidationListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
