using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using CardValidations = Increase.Api.Models.CardValidations;

namespace Increase.Api.Tests.Models.CardValidations;

public class CardValidationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardValidations::CardValidation
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
        };

        string expectedID = "outbound_card_validation_qqlzagpc6v1x2gcdhe24";
        CardValidations::Acceptance expectedAcceptance = new()
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
        };
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedCardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0";
        string expectedCardholderFirstName = "Dee";
        string expectedCardholderLastName = "Hock";
        string expectedCardholderMiddleName = "Ward";
        string expectedCardholderPostalCode = "10045";
        string expectedCardholderStreetAddress = "33 Liberty Street";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        CardValidations::CreatedBy expectedCreatedBy = new()
        {
            Category = CardValidations::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        CardValidations::Decline expectedDecline = new()
        {
            DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            NetworkTransactionIdentifier = "841488484271872",
            Reason = CardValidations::Reason.TransactionNotPermittedToCardholder,
        };
        string expectedMerchantCategoryCode = "1234";
        string expectedMerchantCityName = "New York";
        string expectedMerchantName = "Acme Corp";
        string expectedMerchantPostalCode = "10045";
        string expectedMerchantState = "NY";
        ApiEnum<string, CardValidations::Route> expectedRoute = CardValidations::Route.Visa;
        ApiEnum<string, CardValidations::CardValidationStatus> expectedStatus =
            CardValidations::CardValidationStatus.PendingSubmission;
        CardValidations::Submission expectedSubmission = new()
        {
            RetrievalReferenceNumber = "123456789012",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "123456",
        };
        ApiEnum<string, CardValidations::Type> expectedType = CardValidations::Type.CardValidation;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAcceptance, model.Acceptance);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedCardTokenID, model.CardTokenID);
        Assert.Equal(expectedCardholderFirstName, model.CardholderFirstName);
        Assert.Equal(expectedCardholderLastName, model.CardholderLastName);
        Assert.Equal(expectedCardholderMiddleName, model.CardholderMiddleName);
        Assert.Equal(expectedCardholderPostalCode, model.CardholderPostalCode);
        Assert.Equal(expectedCardholderStreetAddress, model.CardholderStreetAddress);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedDecline, model.Decline);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedMerchantCategoryCode, model.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCityName, model.MerchantCityName);
        Assert.Equal(expectedMerchantName, model.MerchantName);
        Assert.Equal(expectedMerchantPostalCode, model.MerchantPostalCode);
        Assert.Equal(expectedMerchantState, model.MerchantState);
        Assert.Equal(expectedRoute, model.Route);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubmission, model.Submission);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardValidations::CardValidation
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardValidations::CardValidation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardValidations::CardValidation
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardValidations::CardValidation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "outbound_card_validation_qqlzagpc6v1x2gcdhe24";
        CardValidations::Acceptance expectedAcceptance = new()
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
        };
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedCardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0";
        string expectedCardholderFirstName = "Dee";
        string expectedCardholderLastName = "Hock";
        string expectedCardholderMiddleName = "Ward";
        string expectedCardholderPostalCode = "10045";
        string expectedCardholderStreetAddress = "33 Liberty Street";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        CardValidations::CreatedBy expectedCreatedBy = new()
        {
            Category = CardValidations::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        CardValidations::Decline expectedDecline = new()
        {
            DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            NetworkTransactionIdentifier = "841488484271872",
            Reason = CardValidations::Reason.TransactionNotPermittedToCardholder,
        };
        string expectedMerchantCategoryCode = "1234";
        string expectedMerchantCityName = "New York";
        string expectedMerchantName = "Acme Corp";
        string expectedMerchantPostalCode = "10045";
        string expectedMerchantState = "NY";
        ApiEnum<string, CardValidations::Route> expectedRoute = CardValidations::Route.Visa;
        ApiEnum<string, CardValidations::CardValidationStatus> expectedStatus =
            CardValidations::CardValidationStatus.PendingSubmission;
        CardValidations::Submission expectedSubmission = new()
        {
            RetrievalReferenceNumber = "123456789012",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "123456",
        };
        ApiEnum<string, CardValidations::Type> expectedType = CardValidations::Type.CardValidation;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAcceptance, deserialized.Acceptance);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedCardTokenID, deserialized.CardTokenID);
        Assert.Equal(expectedCardholderFirstName, deserialized.CardholderFirstName);
        Assert.Equal(expectedCardholderLastName, deserialized.CardholderLastName);
        Assert.Equal(expectedCardholderMiddleName, deserialized.CardholderMiddleName);
        Assert.Equal(expectedCardholderPostalCode, deserialized.CardholderPostalCode);
        Assert.Equal(expectedCardholderStreetAddress, deserialized.CardholderStreetAddress);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedDecline, deserialized.Decline);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedMerchantCategoryCode, deserialized.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCityName, deserialized.MerchantCityName);
        Assert.Equal(expectedMerchantName, deserialized.MerchantName);
        Assert.Equal(expectedMerchantPostalCode, deserialized.MerchantPostalCode);
        Assert.Equal(expectedMerchantState, deserialized.MerchantState);
        Assert.Equal(expectedRoute, deserialized.Route);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubmission, deserialized.Submission);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardValidations::CardValidation
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardValidations::CardValidation
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
        };

        CardValidations::CardValidation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AcceptanceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardValidations::Acceptance
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
        };

        DateTimeOffset expectedAcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedAuthorizationIdentificationResponse = "ABCDEF";
        string expectedNetworkTransactionIdentifier = "841488484271872";

        Assert.Equal(expectedAcceptedAt, model.AcceptedAt);
        Assert.Equal(
            expectedAuthorizationIdentificationResponse,
            model.AuthorizationIdentificationResponse
        );
        Assert.Null(model.CardVerificationValue2Result);
        Assert.Null(model.CardholderFirstNameResult);
        Assert.Null(model.CardholderFullNameResult);
        Assert.Null(model.CardholderLastNameResult);
        Assert.Null(model.CardholderMiddleNameResult);
        Assert.Null(model.CardholderPostalCodeResult);
        Assert.Null(model.CardholderStreetAddressResult);
        Assert.Equal(expectedNetworkTransactionIdentifier, model.NetworkTransactionIdentifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardValidations::Acceptance
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardValidations::Acceptance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardValidations::Acceptance
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardValidations::Acceptance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedAuthorizationIdentificationResponse = "ABCDEF";
        string expectedNetworkTransactionIdentifier = "841488484271872";

        Assert.Equal(expectedAcceptedAt, deserialized.AcceptedAt);
        Assert.Equal(
            expectedAuthorizationIdentificationResponse,
            deserialized.AuthorizationIdentificationResponse
        );
        Assert.Null(deserialized.CardVerificationValue2Result);
        Assert.Null(deserialized.CardholderFirstNameResult);
        Assert.Null(deserialized.CardholderFullNameResult);
        Assert.Null(deserialized.CardholderLastNameResult);
        Assert.Null(deserialized.CardholderMiddleNameResult);
        Assert.Null(deserialized.CardholderPostalCodeResult);
        Assert.Null(deserialized.CardholderStreetAddressResult);
        Assert.Equal(
            expectedNetworkTransactionIdentifier,
            deserialized.NetworkTransactionIdentifier
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardValidations::Acceptance
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardValidations::Acceptance
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
        };

        CardValidations::Acceptance copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardVerificationValue2ResultTest : TestBase
{
    [Theory]
    [InlineData(CardValidations::CardVerificationValue2Result.Match)]
    [InlineData(CardValidations::CardVerificationValue2Result.NoMatch)]
    public void Validation_Works(CardValidations::CardVerificationValue2Result rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::CardVerificationValue2Result> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardVerificationValue2Result>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardValidations::CardVerificationValue2Result.Match)]
    [InlineData(CardValidations::CardVerificationValue2Result.NoMatch)]
    public void SerializationRoundtrip_Works(CardValidations::CardVerificationValue2Result rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::CardVerificationValue2Result> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardVerificationValue2Result>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardVerificationValue2Result>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardVerificationValue2Result>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardholderFirstNameResultTest : TestBase
{
    [Theory]
    [InlineData(CardValidations::CardholderFirstNameResult.Match)]
    [InlineData(CardValidations::CardholderFirstNameResult.NoMatch)]
    [InlineData(CardValidations::CardholderFirstNameResult.PartialMatch)]
    public void Validation_Works(CardValidations::CardholderFirstNameResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::CardholderFirstNameResult> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderFirstNameResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardValidations::CardholderFirstNameResult.Match)]
    [InlineData(CardValidations::CardholderFirstNameResult.NoMatch)]
    [InlineData(CardValidations::CardholderFirstNameResult.PartialMatch)]
    public void SerializationRoundtrip_Works(CardValidations::CardholderFirstNameResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::CardholderFirstNameResult> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderFirstNameResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderFirstNameResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderFirstNameResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardholderFullNameResultTest : TestBase
{
    [Theory]
    [InlineData(CardValidations::CardholderFullNameResult.Match)]
    [InlineData(CardValidations::CardholderFullNameResult.NoMatch)]
    [InlineData(CardValidations::CardholderFullNameResult.PartialMatch)]
    public void Validation_Works(CardValidations::CardholderFullNameResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::CardholderFullNameResult> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderFullNameResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardValidations::CardholderFullNameResult.Match)]
    [InlineData(CardValidations::CardholderFullNameResult.NoMatch)]
    [InlineData(CardValidations::CardholderFullNameResult.PartialMatch)]
    public void SerializationRoundtrip_Works(CardValidations::CardholderFullNameResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::CardholderFullNameResult> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderFullNameResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderFullNameResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderFullNameResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardholderLastNameResultTest : TestBase
{
    [Theory]
    [InlineData(CardValidations::CardholderLastNameResult.Match)]
    [InlineData(CardValidations::CardholderLastNameResult.NoMatch)]
    [InlineData(CardValidations::CardholderLastNameResult.PartialMatch)]
    public void Validation_Works(CardValidations::CardholderLastNameResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::CardholderLastNameResult> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderLastNameResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardValidations::CardholderLastNameResult.Match)]
    [InlineData(CardValidations::CardholderLastNameResult.NoMatch)]
    [InlineData(CardValidations::CardholderLastNameResult.PartialMatch)]
    public void SerializationRoundtrip_Works(CardValidations::CardholderLastNameResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::CardholderLastNameResult> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderLastNameResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderLastNameResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderLastNameResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardholderMiddleNameResultTest : TestBase
{
    [Theory]
    [InlineData(CardValidations::CardholderMiddleNameResult.Match)]
    [InlineData(CardValidations::CardholderMiddleNameResult.NoMatch)]
    [InlineData(CardValidations::CardholderMiddleNameResult.PartialMatch)]
    public void Validation_Works(CardValidations::CardholderMiddleNameResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::CardholderMiddleNameResult> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderMiddleNameResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardValidations::CardholderMiddleNameResult.Match)]
    [InlineData(CardValidations::CardholderMiddleNameResult.NoMatch)]
    [InlineData(CardValidations::CardholderMiddleNameResult.PartialMatch)]
    public void SerializationRoundtrip_Works(CardValidations::CardholderMiddleNameResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::CardholderMiddleNameResult> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderMiddleNameResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderMiddleNameResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderMiddleNameResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardholderPostalCodeResultTest : TestBase
{
    [Theory]
    [InlineData(CardValidations::CardholderPostalCodeResult.Match)]
    [InlineData(CardValidations::CardholderPostalCodeResult.NoMatch)]
    public void Validation_Works(CardValidations::CardholderPostalCodeResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::CardholderPostalCodeResult> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderPostalCodeResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardValidations::CardholderPostalCodeResult.Match)]
    [InlineData(CardValidations::CardholderPostalCodeResult.NoMatch)]
    public void SerializationRoundtrip_Works(CardValidations::CardholderPostalCodeResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::CardholderPostalCodeResult> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderPostalCodeResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderPostalCodeResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderPostalCodeResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardholderStreetAddressResultTest : TestBase
{
    [Theory]
    [InlineData(CardValidations::CardholderStreetAddressResult.Match)]
    [InlineData(CardValidations::CardholderStreetAddressResult.NoMatch)]
    public void Validation_Works(CardValidations::CardholderStreetAddressResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::CardholderStreetAddressResult> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderStreetAddressResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardValidations::CardholderStreetAddressResult.Match)]
    [InlineData(CardValidations::CardholderStreetAddressResult.NoMatch)]
    public void SerializationRoundtrip_Works(
        CardValidations::CardholderStreetAddressResult rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::CardholderStreetAddressResult> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderStreetAddressResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderStreetAddressResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardholderStreetAddressResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreatedByTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardValidations::CreatedBy
        {
            Category = CardValidations::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        ApiEnum<string, CardValidations::Category> expectedCategory =
            CardValidations::Category.User;
        CardValidations::ApiKey expectedApiKey = new("description");
        CardValidations::OAuthApplication expectedOAuthApplication = new("name");
        CardValidations::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedOAuthApplication, model.OAuthApplication);
        Assert.Equal(expectedUser, model.User);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardValidations::CreatedBy
        {
            Category = CardValidations::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardValidations::CreatedBy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardValidations::CreatedBy
        {
            Category = CardValidations::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardValidations::CreatedBy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CardValidations::Category> expectedCategory =
            CardValidations::Category.User;
        CardValidations::ApiKey expectedApiKey = new("description");
        CardValidations::OAuthApplication expectedOAuthApplication = new("name");
        CardValidations::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedOAuthApplication, deserialized.OAuthApplication);
        Assert.Equal(expectedUser, deserialized.User);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardValidations::CreatedBy
        {
            Category = CardValidations::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CardValidations::CreatedBy { Category = CardValidations::Category.User };

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
        var model = new CardValidations::CreatedBy { Category = CardValidations::Category.User };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CardValidations::CreatedBy
        {
            Category = CardValidations::Category.User,

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
        var model = new CardValidations::CreatedBy
        {
            Category = CardValidations::Category.User,

            ApiKey = null,
            OAuthApplication = null,
            User = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardValidations::CreatedBy
        {
            Category = CardValidations::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        CardValidations::CreatedBy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(CardValidations::Category.ApiKey)]
    [InlineData(CardValidations::Category.OAuthApplication)]
    [InlineData(CardValidations::Category.User)]
    public void Validation_Works(CardValidations::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardValidations::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardValidations::Category.ApiKey)]
    [InlineData(CardValidations::Category.OAuthApplication)]
    [InlineData(CardValidations::Category.User)]
    public void SerializationRoundtrip_Works(CardValidations::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardValidations::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardValidations::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardValidations::Category>>(
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
        var model = new CardValidations::ApiKey { Description = "description" };

        string expectedDescription = "description";

        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardValidations::ApiKey { Description = "description" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardValidations::ApiKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardValidations::ApiKey { Description = "description" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardValidations::ApiKey>(
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
        var model = new CardValidations::ApiKey { Description = "description" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardValidations::ApiKey { Description = "description" };

        CardValidations::ApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OAuthApplicationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardValidations::OAuthApplication { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardValidations::OAuthApplication { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardValidations::OAuthApplication>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardValidations::OAuthApplication { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardValidations::OAuthApplication>(
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
        var model = new CardValidations::OAuthApplication { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardValidations::OAuthApplication { Name = "name" };

        CardValidations::OAuthApplication copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardValidations::User { Email = "email" };

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardValidations::User { Email = "email" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardValidations::User>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardValidations::User { Email = "email" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardValidations::User>(
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
        var model = new CardValidations::User { Email = "email" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardValidations::User { Email = "email" };

        CardValidations::User copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeclineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardValidations::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            NetworkTransactionIdentifier = "841488484271872",
            Reason = CardValidations::Reason.TransactionNotPermittedToCardholder,
        };

        DateTimeOffset expectedDeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedNetworkTransactionIdentifier = "841488484271872";
        ApiEnum<string, CardValidations::Reason> expectedReason =
            CardValidations::Reason.TransactionNotPermittedToCardholder;

        Assert.Equal(expectedDeclinedAt, model.DeclinedAt);
        Assert.Equal(expectedNetworkTransactionIdentifier, model.NetworkTransactionIdentifier);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardValidations::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            NetworkTransactionIdentifier = "841488484271872",
            Reason = CardValidations::Reason.TransactionNotPermittedToCardholder,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardValidations::Decline>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardValidations::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            NetworkTransactionIdentifier = "841488484271872",
            Reason = CardValidations::Reason.TransactionNotPermittedToCardholder,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardValidations::Decline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedDeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedNetworkTransactionIdentifier = "841488484271872";
        ApiEnum<string, CardValidations::Reason> expectedReason =
            CardValidations::Reason.TransactionNotPermittedToCardholder;

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
        var model = new CardValidations::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            NetworkTransactionIdentifier = "841488484271872",
            Reason = CardValidations::Reason.TransactionNotPermittedToCardholder,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardValidations::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            NetworkTransactionIdentifier = "841488484271872",
            Reason = CardValidations::Reason.TransactionNotPermittedToCardholder,
        };

        CardValidations::Decline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(CardValidations::Reason.DoNotHonor)]
    [InlineData(CardValidations::Reason.ActivityCountLimitExceeded)]
    [InlineData(CardValidations::Reason.ReferToCardIssuer)]
    [InlineData(CardValidations::Reason.ReferToCardIssuerSpecialCondition)]
    [InlineData(CardValidations::Reason.InvalidMerchant)]
    [InlineData(CardValidations::Reason.PickUpCard)]
    [InlineData(CardValidations::Reason.Error)]
    [InlineData(CardValidations::Reason.PickUpCardSpecial)]
    [InlineData(CardValidations::Reason.InvalidTransaction)]
    [InlineData(CardValidations::Reason.InvalidAmount)]
    [InlineData(CardValidations::Reason.InvalidAccountNumber)]
    [InlineData(CardValidations::Reason.NoSuchIssuer)]
    [InlineData(CardValidations::Reason.ReEnterTransaction)]
    [InlineData(CardValidations::Reason.NoCreditAccount)]
    [InlineData(CardValidations::Reason.PickUpCardLost)]
    [InlineData(CardValidations::Reason.PickUpCardStolen)]
    [InlineData(CardValidations::Reason.ClosedAccount)]
    [InlineData(CardValidations::Reason.InsufficientFunds)]
    [InlineData(CardValidations::Reason.NoCheckingAccount)]
    [InlineData(CardValidations::Reason.NoSavingsAccount)]
    [InlineData(CardValidations::Reason.ExpiredCard)]
    [InlineData(CardValidations::Reason.TransactionNotPermittedToCardholder)]
    [InlineData(CardValidations::Reason.TransactionNotAllowedAtTerminal)]
    [InlineData(CardValidations::Reason.TransactionNotSupportedOrBlockedByIssuer)]
    [InlineData(CardValidations::Reason.SuspectedFraud)]
    [InlineData(CardValidations::Reason.ActivityAmountLimitExceeded)]
    [InlineData(CardValidations::Reason.RestrictedCard)]
    [InlineData(CardValidations::Reason.SecurityViolation)]
    [InlineData(CardValidations::Reason.TransactionDoesNotFulfillAntiMoneyLaunderingRequirement)]
    [InlineData(CardValidations::Reason.BlockedByCardholder)]
    [InlineData(CardValidations::Reason.BlockedFirstUse)]
    [InlineData(CardValidations::Reason.CreditIssuerUnavailable)]
    [InlineData(CardValidations::Reason.NegativeCardVerificationValueResults)]
    [InlineData(CardValidations::Reason.IssuerUnavailable)]
    [InlineData(CardValidations::Reason.FinancialInstitutionCannotBeFound)]
    [InlineData(CardValidations::Reason.TransactionCannotBeCompleted)]
    [InlineData(CardValidations::Reason.DuplicateTransaction)]
    [InlineData(CardValidations::Reason.SystemMalfunction)]
    [InlineData(CardValidations::Reason.AdditionalCustomerAuthenticationRequired)]
    [InlineData(CardValidations::Reason.SurchargeAmountNotPermitted)]
    [InlineData(CardValidations::Reason.DeclineForCvv2Failure)]
    [InlineData(CardValidations::Reason.StopPaymentOrder)]
    [InlineData(CardValidations::Reason.RevocationOfAuthorizationOrder)]
    [InlineData(CardValidations::Reason.RevocationOfAllAuthorizationsOrder)]
    [InlineData(CardValidations::Reason.UnableToLocateRecord)]
    [InlineData(CardValidations::Reason.FileIsTemporarilyUnavailable)]
    [InlineData(CardValidations::Reason.IncorrectPin)]
    [InlineData(CardValidations::Reason.AllowableNumberOfPinEntryTriesExceeded)]
    [InlineData(CardValidations::Reason.UnableToLocatePreviousMessage)]
    [InlineData(CardValidations::Reason.PinErrorFound)]
    [InlineData(CardValidations::Reason.CannotVerifyPin)]
    [InlineData(CardValidations::Reason.VerificationDataFailed)]
    [InlineData(CardValidations::Reason.SurchargeAmountNotSupportedByDebitNetworkIssuer)]
    [InlineData(CardValidations::Reason.CashServiceNotAvailable)]
    [InlineData(CardValidations::Reason.CashbackRequestExceedsIssuerLimit)]
    [InlineData(CardValidations::Reason.TransactionAmountExceedsPreAuthorizedApprovalAmount)]
    [InlineData(CardValidations::Reason.TransactionDoesNotQualifyForVisaPin)]
    [InlineData(CardValidations::Reason.OfflineDeclined)]
    [InlineData(CardValidations::Reason.UnableToGoOnline)]
    [InlineData(CardValidations::Reason.ValidAccountButAmountNotSupported)]
    [InlineData(CardValidations::Reason.InvalidUseOfMerchantCategoryCodeCorrectAndReattempt)]
    [InlineData(CardValidations::Reason.CardAuthenticationFailed)]
    public void Validation_Works(CardValidations::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardValidations::Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardValidations::Reason.DoNotHonor)]
    [InlineData(CardValidations::Reason.ActivityCountLimitExceeded)]
    [InlineData(CardValidations::Reason.ReferToCardIssuer)]
    [InlineData(CardValidations::Reason.ReferToCardIssuerSpecialCondition)]
    [InlineData(CardValidations::Reason.InvalidMerchant)]
    [InlineData(CardValidations::Reason.PickUpCard)]
    [InlineData(CardValidations::Reason.Error)]
    [InlineData(CardValidations::Reason.PickUpCardSpecial)]
    [InlineData(CardValidations::Reason.InvalidTransaction)]
    [InlineData(CardValidations::Reason.InvalidAmount)]
    [InlineData(CardValidations::Reason.InvalidAccountNumber)]
    [InlineData(CardValidations::Reason.NoSuchIssuer)]
    [InlineData(CardValidations::Reason.ReEnterTransaction)]
    [InlineData(CardValidations::Reason.NoCreditAccount)]
    [InlineData(CardValidations::Reason.PickUpCardLost)]
    [InlineData(CardValidations::Reason.PickUpCardStolen)]
    [InlineData(CardValidations::Reason.ClosedAccount)]
    [InlineData(CardValidations::Reason.InsufficientFunds)]
    [InlineData(CardValidations::Reason.NoCheckingAccount)]
    [InlineData(CardValidations::Reason.NoSavingsAccount)]
    [InlineData(CardValidations::Reason.ExpiredCard)]
    [InlineData(CardValidations::Reason.TransactionNotPermittedToCardholder)]
    [InlineData(CardValidations::Reason.TransactionNotAllowedAtTerminal)]
    [InlineData(CardValidations::Reason.TransactionNotSupportedOrBlockedByIssuer)]
    [InlineData(CardValidations::Reason.SuspectedFraud)]
    [InlineData(CardValidations::Reason.ActivityAmountLimitExceeded)]
    [InlineData(CardValidations::Reason.RestrictedCard)]
    [InlineData(CardValidations::Reason.SecurityViolation)]
    [InlineData(CardValidations::Reason.TransactionDoesNotFulfillAntiMoneyLaunderingRequirement)]
    [InlineData(CardValidations::Reason.BlockedByCardholder)]
    [InlineData(CardValidations::Reason.BlockedFirstUse)]
    [InlineData(CardValidations::Reason.CreditIssuerUnavailable)]
    [InlineData(CardValidations::Reason.NegativeCardVerificationValueResults)]
    [InlineData(CardValidations::Reason.IssuerUnavailable)]
    [InlineData(CardValidations::Reason.FinancialInstitutionCannotBeFound)]
    [InlineData(CardValidations::Reason.TransactionCannotBeCompleted)]
    [InlineData(CardValidations::Reason.DuplicateTransaction)]
    [InlineData(CardValidations::Reason.SystemMalfunction)]
    [InlineData(CardValidations::Reason.AdditionalCustomerAuthenticationRequired)]
    [InlineData(CardValidations::Reason.SurchargeAmountNotPermitted)]
    [InlineData(CardValidations::Reason.DeclineForCvv2Failure)]
    [InlineData(CardValidations::Reason.StopPaymentOrder)]
    [InlineData(CardValidations::Reason.RevocationOfAuthorizationOrder)]
    [InlineData(CardValidations::Reason.RevocationOfAllAuthorizationsOrder)]
    [InlineData(CardValidations::Reason.UnableToLocateRecord)]
    [InlineData(CardValidations::Reason.FileIsTemporarilyUnavailable)]
    [InlineData(CardValidations::Reason.IncorrectPin)]
    [InlineData(CardValidations::Reason.AllowableNumberOfPinEntryTriesExceeded)]
    [InlineData(CardValidations::Reason.UnableToLocatePreviousMessage)]
    [InlineData(CardValidations::Reason.PinErrorFound)]
    [InlineData(CardValidations::Reason.CannotVerifyPin)]
    [InlineData(CardValidations::Reason.VerificationDataFailed)]
    [InlineData(CardValidations::Reason.SurchargeAmountNotSupportedByDebitNetworkIssuer)]
    [InlineData(CardValidations::Reason.CashServiceNotAvailable)]
    [InlineData(CardValidations::Reason.CashbackRequestExceedsIssuerLimit)]
    [InlineData(CardValidations::Reason.TransactionAmountExceedsPreAuthorizedApprovalAmount)]
    [InlineData(CardValidations::Reason.TransactionDoesNotQualifyForVisaPin)]
    [InlineData(CardValidations::Reason.OfflineDeclined)]
    [InlineData(CardValidations::Reason.UnableToGoOnline)]
    [InlineData(CardValidations::Reason.ValidAccountButAmountNotSupported)]
    [InlineData(CardValidations::Reason.InvalidUseOfMerchantCategoryCodeCorrectAndReattempt)]
    [InlineData(CardValidations::Reason.CardAuthenticationFailed)]
    public void SerializationRoundtrip_Works(CardValidations::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardValidations::Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardValidations::Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardValidations::Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RouteTest : TestBase
{
    [Theory]
    [InlineData(CardValidations::Route.Visa)]
    [InlineData(CardValidations::Route.Mastercard)]
    [InlineData(CardValidations::Route.Pulse)]
    public void Validation_Works(CardValidations::Route rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::Route> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardValidations::Route>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardValidations::Route.Visa)]
    [InlineData(CardValidations::Route.Mastercard)]
    [InlineData(CardValidations::Route.Pulse)]
    public void SerializationRoundtrip_Works(CardValidations::Route rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::Route> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardValidations::Route>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardValidations::Route>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardValidations::Route>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CardValidationStatusTest : TestBase
{
    [Theory]
    [InlineData(CardValidations::CardValidationStatus.RequiresAttention)]
    [InlineData(CardValidations::CardValidationStatus.PendingSubmission)]
    [InlineData(CardValidations::CardValidationStatus.Submitted)]
    [InlineData(CardValidations::CardValidationStatus.Complete)]
    [InlineData(CardValidations::CardValidationStatus.Declined)]
    public void Validation_Works(CardValidations::CardValidationStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::CardValidationStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardValidationStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardValidations::CardValidationStatus.RequiresAttention)]
    [InlineData(CardValidations::CardValidationStatus.PendingSubmission)]
    [InlineData(CardValidations::CardValidationStatus.Submitted)]
    [InlineData(CardValidations::CardValidationStatus.Complete)]
    [InlineData(CardValidations::CardValidationStatus.Declined)]
    public void SerializationRoundtrip_Works(CardValidations::CardValidationStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::CardValidationStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardValidationStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardValidationStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardValidations::CardValidationStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubmissionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardValidations::Submission
        {
            RetrievalReferenceNumber = "123456789012",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "123456",
        };

        string expectedRetrievalReferenceNumber = "123456789012";
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedTraceNumber = "123456";

        Assert.Equal(expectedRetrievalReferenceNumber, model.RetrievalReferenceNumber);
        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
        Assert.Equal(expectedTraceNumber, model.TraceNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardValidations::Submission
        {
            RetrievalReferenceNumber = "123456789012",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "123456",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardValidations::Submission>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardValidations::Submission
        {
            RetrievalReferenceNumber = "123456789012",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "123456",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardValidations::Submission>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRetrievalReferenceNumber = "123456789012";
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedTraceNumber = "123456";

        Assert.Equal(expectedRetrievalReferenceNumber, deserialized.RetrievalReferenceNumber);
        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
        Assert.Equal(expectedTraceNumber, deserialized.TraceNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardValidations::Submission
        {
            RetrievalReferenceNumber = "123456789012",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "123456",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardValidations::Submission
        {
            RetrievalReferenceNumber = "123456789012",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TraceNumber = "123456",
        };

        CardValidations::Submission copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(CardValidations::Type.CardValidation)]
    public void Validation_Works(CardValidations::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardValidations::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardValidations::Type.CardValidation)]
    public void SerializationRoundtrip_Works(CardValidations::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardValidations::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardValidations::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardValidations::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardValidations::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
