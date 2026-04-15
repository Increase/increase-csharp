using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.CardAuthorizations;

namespace Increase.Api.Tests.Models.Simulations.CardAuthorizations;

public class CardAuthorizationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardAuthorizationCreateParams
        {
            Amount = 1000,
            AuthenticatedCardPaymentID = "authenticated_card_payment_id",
            CardID = "card_oubs0hwk5rn6knuecxg2",
            DeclineReason = DeclineReason.AccountClosed,
            DigitalWalletTokenID = "digital_wallet_token_id",
            EventSubscriptionID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g",
            MerchantAcceptorID = "5665270011000168",
            MerchantCategoryCode = "5734",
            MerchantCity = "New York",
            MerchantCountry = "US",
            MerchantDescriptor = "AMAZON.COM",
            MerchantState = "NY",
            NetworkDetails = new(
                new Visa() { StandInProcessingReason = StandInProcessingReason.IssuerError }
            ),
            NetworkRiskScore = 0,
            PhysicalCardID = "physical_card_id",
            ProcessingCategory = new()
            {
                Category = Category.AccountFunding,
                Refund = new() { OriginalCardPaymentID = "original_card_payment_id" },
            },
            TerminalID = "x",
        };

        long expectedAmount = 1000;
        string expectedAuthenticatedCardPaymentID = "authenticated_card_payment_id";
        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";
        ApiEnum<string, DeclineReason> expectedDeclineReason = DeclineReason.AccountClosed;
        string expectedDigitalWalletTokenID = "digital_wallet_token_id";
        string expectedEventSubscriptionID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g";
        string expectedMerchantAcceptorID = "5665270011000168";
        string expectedMerchantCategoryCode = "5734";
        string expectedMerchantCity = "New York";
        string expectedMerchantCountry = "US";
        string expectedMerchantDescriptor = "AMAZON.COM";
        string expectedMerchantState = "NY";
        NetworkDetails expectedNetworkDetails = new(
            new Visa() { StandInProcessingReason = StandInProcessingReason.IssuerError }
        );
        long expectedNetworkRiskScore = 0;
        string expectedPhysicalCardID = "physical_card_id";
        ProcessingCategory expectedProcessingCategory = new()
        {
            Category = Category.AccountFunding,
            Refund = new() { OriginalCardPaymentID = "original_card_payment_id" },
        };
        string expectedTerminalID = "x";

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedAuthenticatedCardPaymentID, parameters.AuthenticatedCardPaymentID);
        Assert.Equal(expectedCardID, parameters.CardID);
        Assert.Equal(expectedDeclineReason, parameters.DeclineReason);
        Assert.Equal(expectedDigitalWalletTokenID, parameters.DigitalWalletTokenID);
        Assert.Equal(expectedEventSubscriptionID, parameters.EventSubscriptionID);
        Assert.Equal(expectedMerchantAcceptorID, parameters.MerchantAcceptorID);
        Assert.Equal(expectedMerchantCategoryCode, parameters.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCity, parameters.MerchantCity);
        Assert.Equal(expectedMerchantCountry, parameters.MerchantCountry);
        Assert.Equal(expectedMerchantDescriptor, parameters.MerchantDescriptor);
        Assert.Equal(expectedMerchantState, parameters.MerchantState);
        Assert.Equal(expectedNetworkDetails, parameters.NetworkDetails);
        Assert.Equal(expectedNetworkRiskScore, parameters.NetworkRiskScore);
        Assert.Equal(expectedPhysicalCardID, parameters.PhysicalCardID);
        Assert.Equal(expectedProcessingCategory, parameters.ProcessingCategory);
        Assert.Equal(expectedTerminalID, parameters.TerminalID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CardAuthorizationCreateParams { Amount = 1000 };

        Assert.Null(parameters.AuthenticatedCardPaymentID);
        Assert.False(parameters.RawBodyData.ContainsKey("authenticated_card_payment_id"));
        Assert.Null(parameters.CardID);
        Assert.False(parameters.RawBodyData.ContainsKey("card_id"));
        Assert.Null(parameters.DeclineReason);
        Assert.False(parameters.RawBodyData.ContainsKey("decline_reason"));
        Assert.Null(parameters.DigitalWalletTokenID);
        Assert.False(parameters.RawBodyData.ContainsKey("digital_wallet_token_id"));
        Assert.Null(parameters.EventSubscriptionID);
        Assert.False(parameters.RawBodyData.ContainsKey("event_subscription_id"));
        Assert.Null(parameters.MerchantAcceptorID);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_acceptor_id"));
        Assert.Null(parameters.MerchantCategoryCode);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_category_code"));
        Assert.Null(parameters.MerchantCity);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_city"));
        Assert.Null(parameters.MerchantCountry);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_country"));
        Assert.Null(parameters.MerchantDescriptor);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_descriptor"));
        Assert.Null(parameters.MerchantState);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_state"));
        Assert.Null(parameters.NetworkDetails);
        Assert.False(parameters.RawBodyData.ContainsKey("network_details"));
        Assert.Null(parameters.NetworkRiskScore);
        Assert.False(parameters.RawBodyData.ContainsKey("network_risk_score"));
        Assert.Null(parameters.PhysicalCardID);
        Assert.False(parameters.RawBodyData.ContainsKey("physical_card_id"));
        Assert.Null(parameters.ProcessingCategory);
        Assert.False(parameters.RawBodyData.ContainsKey("processing_category"));
        Assert.Null(parameters.TerminalID);
        Assert.False(parameters.RawBodyData.ContainsKey("terminal_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CardAuthorizationCreateParams
        {
            Amount = 1000,

            // Null should be interpreted as omitted for these properties
            AuthenticatedCardPaymentID = null,
            CardID = null,
            DeclineReason = null,
            DigitalWalletTokenID = null,
            EventSubscriptionID = null,
            MerchantAcceptorID = null,
            MerchantCategoryCode = null,
            MerchantCity = null,
            MerchantCountry = null,
            MerchantDescriptor = null,
            MerchantState = null,
            NetworkDetails = null,
            NetworkRiskScore = null,
            PhysicalCardID = null,
            ProcessingCategory = null,
            TerminalID = null,
        };

        Assert.Null(parameters.AuthenticatedCardPaymentID);
        Assert.False(parameters.RawBodyData.ContainsKey("authenticated_card_payment_id"));
        Assert.Null(parameters.CardID);
        Assert.False(parameters.RawBodyData.ContainsKey("card_id"));
        Assert.Null(parameters.DeclineReason);
        Assert.False(parameters.RawBodyData.ContainsKey("decline_reason"));
        Assert.Null(parameters.DigitalWalletTokenID);
        Assert.False(parameters.RawBodyData.ContainsKey("digital_wallet_token_id"));
        Assert.Null(parameters.EventSubscriptionID);
        Assert.False(parameters.RawBodyData.ContainsKey("event_subscription_id"));
        Assert.Null(parameters.MerchantAcceptorID);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_acceptor_id"));
        Assert.Null(parameters.MerchantCategoryCode);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_category_code"));
        Assert.Null(parameters.MerchantCity);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_city"));
        Assert.Null(parameters.MerchantCountry);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_country"));
        Assert.Null(parameters.MerchantDescriptor);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_descriptor"));
        Assert.Null(parameters.MerchantState);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_state"));
        Assert.Null(parameters.NetworkDetails);
        Assert.False(parameters.RawBodyData.ContainsKey("network_details"));
        Assert.Null(parameters.NetworkRiskScore);
        Assert.False(parameters.RawBodyData.ContainsKey("network_risk_score"));
        Assert.Null(parameters.PhysicalCardID);
        Assert.False(parameters.RawBodyData.ContainsKey("physical_card_id"));
        Assert.Null(parameters.ProcessingCategory);
        Assert.False(parameters.RawBodyData.ContainsKey("processing_category"));
        Assert.Null(parameters.TerminalID);
        Assert.False(parameters.RawBodyData.ContainsKey("terminal_id"));
    }

    [Fact]
    public void Url_Works()
    {
        CardAuthorizationCreateParams parameters = new() { Amount = 1000 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/simulations/card_authorizations"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardAuthorizationCreateParams
        {
            Amount = 1000,
            AuthenticatedCardPaymentID = "authenticated_card_payment_id",
            CardID = "card_oubs0hwk5rn6knuecxg2",
            DeclineReason = DeclineReason.AccountClosed,
            DigitalWalletTokenID = "digital_wallet_token_id",
            EventSubscriptionID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g",
            MerchantAcceptorID = "5665270011000168",
            MerchantCategoryCode = "5734",
            MerchantCity = "New York",
            MerchantCountry = "US",
            MerchantDescriptor = "AMAZON.COM",
            MerchantState = "NY",
            NetworkDetails = new(
                new Visa() { StandInProcessingReason = StandInProcessingReason.IssuerError }
            ),
            NetworkRiskScore = 0,
            PhysicalCardID = "physical_card_id",
            ProcessingCategory = new()
            {
                Category = Category.AccountFunding,
                Refund = new() { OriginalCardPaymentID = "original_card_payment_id" },
            },
            TerminalID = "x",
        };

        CardAuthorizationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DeclineReasonTest : TestBase
{
    [Theory]
    [InlineData(DeclineReason.AccountClosed)]
    [InlineData(DeclineReason.CardNotActive)]
    [InlineData(DeclineReason.CardCanceled)]
    [InlineData(DeclineReason.PhysicalCardNotActive)]
    [InlineData(DeclineReason.EntityNotActive)]
    [InlineData(DeclineReason.GroupLocked)]
    [InlineData(DeclineReason.InsufficientFunds)]
    [InlineData(DeclineReason.Cvv2Mismatch)]
    [InlineData(DeclineReason.PinMismatch)]
    [InlineData(DeclineReason.CardExpirationMismatch)]
    [InlineData(DeclineReason.TransactionNotAllowed)]
    [InlineData(DeclineReason.BreachesLimit)]
    [InlineData(DeclineReason.WebhookDeclined)]
    [InlineData(DeclineReason.WebhookTimedOut)]
    [InlineData(DeclineReason.DeclinedByStandInProcessing)]
    [InlineData(DeclineReason.InvalidPhysicalCard)]
    [InlineData(DeclineReason.MissingOriginalAuthorization)]
    [InlineData(DeclineReason.InvalidCryptogram)]
    [InlineData(DeclineReason.Failed3dsAuthentication)]
    [InlineData(DeclineReason.SuspectedCardTesting)]
    [InlineData(DeclineReason.SuspectedFraud)]
    public void Validation_Works(DeclineReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclineReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclineReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclineReason.AccountClosed)]
    [InlineData(DeclineReason.CardNotActive)]
    [InlineData(DeclineReason.CardCanceled)]
    [InlineData(DeclineReason.PhysicalCardNotActive)]
    [InlineData(DeclineReason.EntityNotActive)]
    [InlineData(DeclineReason.GroupLocked)]
    [InlineData(DeclineReason.InsufficientFunds)]
    [InlineData(DeclineReason.Cvv2Mismatch)]
    [InlineData(DeclineReason.PinMismatch)]
    [InlineData(DeclineReason.CardExpirationMismatch)]
    [InlineData(DeclineReason.TransactionNotAllowed)]
    [InlineData(DeclineReason.BreachesLimit)]
    [InlineData(DeclineReason.WebhookDeclined)]
    [InlineData(DeclineReason.WebhookTimedOut)]
    [InlineData(DeclineReason.DeclinedByStandInProcessing)]
    [InlineData(DeclineReason.InvalidPhysicalCard)]
    [InlineData(DeclineReason.MissingOriginalAuthorization)]
    [InlineData(DeclineReason.InvalidCryptogram)]
    [InlineData(DeclineReason.Failed3dsAuthentication)]
    [InlineData(DeclineReason.SuspectedCardTesting)]
    [InlineData(DeclineReason.SuspectedFraud)]
    public void SerializationRoundtrip_Works(DeclineReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclineReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeclineReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclineReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeclineReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NetworkDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NetworkDetails
        {
            Visa = new() { StandInProcessingReason = StandInProcessingReason.IssuerError },
        };

        Visa expectedVisa = new() { StandInProcessingReason = StandInProcessingReason.IssuerError };

        Assert.Equal(expectedVisa, model.Visa);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NetworkDetails
        {
            Visa = new() { StandInProcessingReason = StandInProcessingReason.IssuerError },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NetworkDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NetworkDetails
        {
            Visa = new() { StandInProcessingReason = StandInProcessingReason.IssuerError },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NetworkDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Visa expectedVisa = new() { StandInProcessingReason = StandInProcessingReason.IssuerError };

        Assert.Equal(expectedVisa, deserialized.Visa);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NetworkDetails
        {
            Visa = new() { StandInProcessingReason = StandInProcessingReason.IssuerError },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NetworkDetails
        {
            Visa = new() { StandInProcessingReason = StandInProcessingReason.IssuerError },
        };

        NetworkDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VisaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Visa { StandInProcessingReason = StandInProcessingReason.IssuerError };

        ApiEnum<string, StandInProcessingReason> expectedStandInProcessingReason =
            StandInProcessingReason.IssuerError;

        Assert.Equal(expectedStandInProcessingReason, model.StandInProcessingReason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Visa { StandInProcessingReason = StandInProcessingReason.IssuerError };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Visa>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Visa { StandInProcessingReason = StandInProcessingReason.IssuerError };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Visa>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, StandInProcessingReason> expectedStandInProcessingReason =
            StandInProcessingReason.IssuerError;

        Assert.Equal(expectedStandInProcessingReason, deserialized.StandInProcessingReason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Visa { StandInProcessingReason = StandInProcessingReason.IssuerError };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Visa { };

        Assert.Null(model.StandInProcessingReason);
        Assert.False(model.RawData.ContainsKey("stand_in_processing_reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Visa { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Visa
        {
            // Null should be interpreted as omitted for these properties
            StandInProcessingReason = null,
        };

        Assert.Null(model.StandInProcessingReason);
        Assert.False(model.RawData.ContainsKey("stand_in_processing_reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Visa
        {
            // Null should be interpreted as omitted for these properties
            StandInProcessingReason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Visa { StandInProcessingReason = StandInProcessingReason.IssuerError };

        Visa copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StandInProcessingReasonTest : TestBase
{
    [Theory]
    [InlineData(StandInProcessingReason.IssuerError)]
    [InlineData(StandInProcessingReason.InvalidPhysicalCard)]
    [InlineData(StandInProcessingReason.InvalidCryptogram)]
    [InlineData(StandInProcessingReason.InvalidCardholderAuthenticationVerificationValue)]
    [InlineData(StandInProcessingReason.InternalVisaError)]
    [InlineData(StandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired)]
    [InlineData(StandInProcessingReason.PaymentFraudDisruptionAcquirerBlock)]
    [InlineData(StandInProcessingReason.Other)]
    public void Validation_Works(StandInProcessingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StandInProcessingReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StandInProcessingReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StandInProcessingReason.IssuerError)]
    [InlineData(StandInProcessingReason.InvalidPhysicalCard)]
    [InlineData(StandInProcessingReason.InvalidCryptogram)]
    [InlineData(StandInProcessingReason.InvalidCardholderAuthenticationVerificationValue)]
    [InlineData(StandInProcessingReason.InternalVisaError)]
    [InlineData(StandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired)]
    [InlineData(StandInProcessingReason.PaymentFraudDisruptionAcquirerBlock)]
    [InlineData(StandInProcessingReason.Other)]
    public void SerializationRoundtrip_Works(StandInProcessingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StandInProcessingReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StandInProcessingReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StandInProcessingReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StandInProcessingReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ProcessingCategoryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProcessingCategory
        {
            Category = Category.AccountFunding,
            Refund = new() { OriginalCardPaymentID = "original_card_payment_id" },
        };

        ApiEnum<string, Category> expectedCategory = Category.AccountFunding;
        Refund expectedRefund = new() { OriginalCardPaymentID = "original_card_payment_id" };

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedRefund, model.Refund);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProcessingCategory
        {
            Category = Category.AccountFunding,
            Refund = new() { OriginalCardPaymentID = "original_card_payment_id" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProcessingCategory>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProcessingCategory
        {
            Category = Category.AccountFunding,
            Refund = new() { OriginalCardPaymentID = "original_card_payment_id" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProcessingCategory>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Category> expectedCategory = Category.AccountFunding;
        Refund expectedRefund = new() { OriginalCardPaymentID = "original_card_payment_id" };

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedRefund, deserialized.Refund);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProcessingCategory
        {
            Category = Category.AccountFunding,
            Refund = new() { OriginalCardPaymentID = "original_card_payment_id" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProcessingCategory { Category = Category.AccountFunding };

        Assert.Null(model.Refund);
        Assert.False(model.RawData.ContainsKey("refund"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProcessingCategory { Category = Category.AccountFunding };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ProcessingCategory
        {
            Category = Category.AccountFunding,

            // Null should be interpreted as omitted for these properties
            Refund = null,
        };

        Assert.Null(model.Refund);
        Assert.False(model.RawData.ContainsKey("refund"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProcessingCategory
        {
            Category = Category.AccountFunding,

            // Null should be interpreted as omitted for these properties
            Refund = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProcessingCategory
        {
            Category = Category.AccountFunding,
            Refund = new() { OriginalCardPaymentID = "original_card_payment_id" },
        };

        ProcessingCategory copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.AccountFunding)]
    [InlineData(Category.AutomaticFuelDispenser)]
    [InlineData(Category.BillPayment)]
    [InlineData(Category.OriginalCredit)]
    [InlineData(Category.Purchase)]
    [InlineData(Category.QuasiCash)]
    [InlineData(Category.Refund)]
    [InlineData(Category.CashDisbursement)]
    [InlineData(Category.BalanceInquiry)]
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
    [InlineData(Category.AccountFunding)]
    [InlineData(Category.AutomaticFuelDispenser)]
    [InlineData(Category.BillPayment)]
    [InlineData(Category.OriginalCredit)]
    [InlineData(Category.Purchase)]
    [InlineData(Category.QuasiCash)]
    [InlineData(Category.Refund)]
    [InlineData(Category.CashDisbursement)]
    [InlineData(Category.BalanceInquiry)]
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

public class RefundTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Refund { OriginalCardPaymentID = "original_card_payment_id" };

        string expectedOriginalCardPaymentID = "original_card_payment_id";

        Assert.Equal(expectedOriginalCardPaymentID, model.OriginalCardPaymentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Refund { OriginalCardPaymentID = "original_card_payment_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Refund>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Refund { OriginalCardPaymentID = "original_card_payment_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Refund>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedOriginalCardPaymentID = "original_card_payment_id";

        Assert.Equal(expectedOriginalCardPaymentID, deserialized.OriginalCardPaymentID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Refund { OriginalCardPaymentID = "original_card_payment_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Refund { };

        Assert.Null(model.OriginalCardPaymentID);
        Assert.False(model.RawData.ContainsKey("original_card_payment_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Refund { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Refund
        {
            // Null should be interpreted as omitted for these properties
            OriginalCardPaymentID = null,
        };

        Assert.Null(model.OriginalCardPaymentID);
        Assert.False(model.RawData.ContainsKey("original_card_payment_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Refund
        {
            // Null should be interpreted as omitted for these properties
            OriginalCardPaymentID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Refund { OriginalCardPaymentID = "original_card_payment_id" };

        Refund copied = new(model);

        Assert.Equal(model, copied);
    }
}
