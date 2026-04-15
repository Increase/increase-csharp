using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.RealTimeDecisions;

namespace Increase.Api.Tests.Models.RealTimeDecisions;

public class RealTimeDecisionActionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RealTimeDecisionActionParams
        {
            RealTimeDecisionID = "real_time_decision_j76n2e810ezcg3zh5qtn",
            CardAuthentication = new(Decision.Approve),
            CardAuthenticationChallenge = new()
            {
                Result = Result.Success,
                Success = new() { Email = "dev@stainless.com", Phone = "x" },
            },
            CardAuthorization = new()
            {
                Decision = CardAuthorizationDecision.Approve,
                Approval = new()
                {
                    CardholderAddressVerificationResult = new()
                    {
                        Line1 = Line1.Match,
                        PostalCode = PostalCode.NoMatch,
                    },
                    PartialAmount = 1,
                },
                Decline = new(Reason.InsufficientFunds),
            },
            CardBalanceInquiry = new()
            {
                Decision = CardBalanceInquiryDecision.Approve,
                Approval = new(0),
            },
            DigitalWalletAuthentication = new()
            {
                Result = DigitalWalletAuthenticationResult.Success,
                Success = new() { Email = "dev@stainless.com", Phone = "x" },
            },
            DigitalWalletToken = new()
            {
                Approval = new() { Email = "dev@stainless.com", Phone = "x" },
                Decline = new() { Reason = "x" },
            },
        };

        string expectedRealTimeDecisionID = "real_time_decision_j76n2e810ezcg3zh5qtn";
        CardAuthentication expectedCardAuthentication = new(Decision.Approve);
        CardAuthenticationChallenge expectedCardAuthenticationChallenge = new()
        {
            Result = Result.Success,
            Success = new() { Email = "dev@stainless.com", Phone = "x" },
        };
        CardAuthorization expectedCardAuthorization = new()
        {
            Decision = CardAuthorizationDecision.Approve,
            Approval = new()
            {
                CardholderAddressVerificationResult = new()
                {
                    Line1 = Line1.Match,
                    PostalCode = PostalCode.NoMatch,
                },
                PartialAmount = 1,
            },
            Decline = new(Reason.InsufficientFunds),
        };
        CardBalanceInquiry expectedCardBalanceInquiry = new()
        {
            Decision = CardBalanceInquiryDecision.Approve,
            Approval = new(0),
        };
        DigitalWalletAuthentication expectedDigitalWalletAuthentication = new()
        {
            Result = DigitalWalletAuthenticationResult.Success,
            Success = new() { Email = "dev@stainless.com", Phone = "x" },
        };
        DigitalWalletToken expectedDigitalWalletToken = new()
        {
            Approval = new() { Email = "dev@stainless.com", Phone = "x" },
            Decline = new() { Reason = "x" },
        };

        Assert.Equal(expectedRealTimeDecisionID, parameters.RealTimeDecisionID);
        Assert.Equal(expectedCardAuthentication, parameters.CardAuthentication);
        Assert.Equal(expectedCardAuthenticationChallenge, parameters.CardAuthenticationChallenge);
        Assert.Equal(expectedCardAuthorization, parameters.CardAuthorization);
        Assert.Equal(expectedCardBalanceInquiry, parameters.CardBalanceInquiry);
        Assert.Equal(expectedDigitalWalletAuthentication, parameters.DigitalWalletAuthentication);
        Assert.Equal(expectedDigitalWalletToken, parameters.DigitalWalletToken);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RealTimeDecisionActionParams
        {
            RealTimeDecisionID = "real_time_decision_j76n2e810ezcg3zh5qtn",
        };

        Assert.Null(parameters.CardAuthentication);
        Assert.False(parameters.RawBodyData.ContainsKey("card_authentication"));
        Assert.Null(parameters.CardAuthenticationChallenge);
        Assert.False(parameters.RawBodyData.ContainsKey("card_authentication_challenge"));
        Assert.Null(parameters.CardAuthorization);
        Assert.False(parameters.RawBodyData.ContainsKey("card_authorization"));
        Assert.Null(parameters.CardBalanceInquiry);
        Assert.False(parameters.RawBodyData.ContainsKey("card_balance_inquiry"));
        Assert.Null(parameters.DigitalWalletAuthentication);
        Assert.False(parameters.RawBodyData.ContainsKey("digital_wallet_authentication"));
        Assert.Null(parameters.DigitalWalletToken);
        Assert.False(parameters.RawBodyData.ContainsKey("digital_wallet_token"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RealTimeDecisionActionParams
        {
            RealTimeDecisionID = "real_time_decision_j76n2e810ezcg3zh5qtn",

            // Null should be interpreted as omitted for these properties
            CardAuthentication = null,
            CardAuthenticationChallenge = null,
            CardAuthorization = null,
            CardBalanceInquiry = null,
            DigitalWalletAuthentication = null,
            DigitalWalletToken = null,
        };

        Assert.Null(parameters.CardAuthentication);
        Assert.False(parameters.RawBodyData.ContainsKey("card_authentication"));
        Assert.Null(parameters.CardAuthenticationChallenge);
        Assert.False(parameters.RawBodyData.ContainsKey("card_authentication_challenge"));
        Assert.Null(parameters.CardAuthorization);
        Assert.False(parameters.RawBodyData.ContainsKey("card_authorization"));
        Assert.Null(parameters.CardBalanceInquiry);
        Assert.False(parameters.RawBodyData.ContainsKey("card_balance_inquiry"));
        Assert.Null(parameters.DigitalWalletAuthentication);
        Assert.False(parameters.RawBodyData.ContainsKey("digital_wallet_authentication"));
        Assert.Null(parameters.DigitalWalletToken);
        Assert.False(parameters.RawBodyData.ContainsKey("digital_wallet_token"));
    }

    [Fact]
    public void Url_Works()
    {
        RealTimeDecisionActionParams parameters = new()
        {
            RealTimeDecisionID = "real_time_decision_j76n2e810ezcg3zh5qtn",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/real_time_decisions/real_time_decision_j76n2e810ezcg3zh5qtn/action"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RealTimeDecisionActionParams
        {
            RealTimeDecisionID = "real_time_decision_j76n2e810ezcg3zh5qtn",
            CardAuthentication = new(Decision.Approve),
            CardAuthenticationChallenge = new()
            {
                Result = Result.Success,
                Success = new() { Email = "dev@stainless.com", Phone = "x" },
            },
            CardAuthorization = new()
            {
                Decision = CardAuthorizationDecision.Approve,
                Approval = new()
                {
                    CardholderAddressVerificationResult = new()
                    {
                        Line1 = Line1.Match,
                        PostalCode = PostalCode.NoMatch,
                    },
                    PartialAmount = 1,
                },
                Decline = new(Reason.InsufficientFunds),
            },
            CardBalanceInquiry = new()
            {
                Decision = CardBalanceInquiryDecision.Approve,
                Approval = new(0),
            },
            DigitalWalletAuthentication = new()
            {
                Result = DigitalWalletAuthenticationResult.Success,
                Success = new() { Email = "dev@stainless.com", Phone = "x" },
            },
            DigitalWalletToken = new()
            {
                Approval = new() { Email = "dev@stainless.com", Phone = "x" },
                Decline = new() { Reason = "x" },
            },
        };

        RealTimeDecisionActionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CardAuthenticationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardAuthentication { Decision = Decision.Approve };

        ApiEnum<string, Decision> expectedDecision = Decision.Approve;

        Assert.Equal(expectedDecision, model.Decision);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardAuthentication { Decision = Decision.Approve };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardAuthentication>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardAuthentication { Decision = Decision.Approve };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardAuthentication>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Decision> expectedDecision = Decision.Approve;

        Assert.Equal(expectedDecision, deserialized.Decision);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardAuthentication { Decision = Decision.Approve };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardAuthentication { Decision = Decision.Approve };

        CardAuthentication copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DecisionTest : TestBase
{
    [Theory]
    [InlineData(Decision.Approve)]
    [InlineData(Decision.Challenge)]
    [InlineData(Decision.Deny)]
    public void Validation_Works(Decision rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Decision> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Decision>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Decision.Approve)]
    [InlineData(Decision.Challenge)]
    [InlineData(Decision.Deny)]
    public void SerializationRoundtrip_Works(Decision rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Decision> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Decision>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Decision>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Decision>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CardAuthenticationChallengeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardAuthenticationChallenge
        {
            Result = Result.Success,
            Success = new() { Email = "dev@stainless.com", Phone = "x" },
        };

        ApiEnum<string, Result> expectedResult = Result.Success;
        Success expectedSuccess = new() { Email = "dev@stainless.com", Phone = "x" };

        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardAuthenticationChallenge
        {
            Result = Result.Success,
            Success = new() { Email = "dev@stainless.com", Phone = "x" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardAuthenticationChallenge>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardAuthenticationChallenge
        {
            Result = Result.Success,
            Success = new() { Email = "dev@stainless.com", Phone = "x" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardAuthenticationChallenge>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Result> expectedResult = Result.Success;
        Success expectedSuccess = new() { Email = "dev@stainless.com", Phone = "x" };

        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardAuthenticationChallenge
        {
            Result = Result.Success,
            Success = new() { Email = "dev@stainless.com", Phone = "x" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CardAuthenticationChallenge { Result = Result.Success };

        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CardAuthenticationChallenge { Result = Result.Success };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CardAuthenticationChallenge
        {
            Result = Result.Success,

            // Null should be interpreted as omitted for these properties
            Success = null,
        };

        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CardAuthenticationChallenge
        {
            Result = Result.Success,

            // Null should be interpreted as omitted for these properties
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardAuthenticationChallenge
        {
            Result = Result.Success,
            Success = new() { Email = "dev@stainless.com", Phone = "x" },
        };

        CardAuthenticationChallenge copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Theory]
    [InlineData(Result.Success)]
    [InlineData(Result.Failure)]
    public void Validation_Works(Result rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Result> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Result>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Result.Success)]
    [InlineData(Result.Failure)]
    public void SerializationRoundtrip_Works(Result rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Result> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Result>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Result>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Result>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SuccessTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Success { Email = "dev@stainless.com", Phone = "x" };

        string expectedEmail = "dev@stainless.com";
        string expectedPhone = "x";

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedPhone, model.Phone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Success { Email = "dev@stainless.com", Phone = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Success>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Success { Email = "dev@stainless.com", Phone = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Success>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "dev@stainless.com";
        string expectedPhone = "x";

        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedPhone, deserialized.Phone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Success { Email = "dev@stainless.com", Phone = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Success { };

        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Success { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Success
        {
            // Null should be interpreted as omitted for these properties
            Email = null,
            Phone = null,
        };

        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Success
        {
            // Null should be interpreted as omitted for these properties
            Email = null,
            Phone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Success { Email = "dev@stainless.com", Phone = "x" };

        Success copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardAuthorization
        {
            Decision = CardAuthorizationDecision.Approve,
            Approval = new()
            {
                CardholderAddressVerificationResult = new()
                {
                    Line1 = Line1.Match,
                    PostalCode = PostalCode.Match,
                },
                PartialAmount = 1,
            },
            Decline = new(Reason.InsufficientFunds),
        };

        ApiEnum<string, CardAuthorizationDecision> expectedDecision =
            CardAuthorizationDecision.Approve;
        Approval expectedApproval = new()
        {
            CardholderAddressVerificationResult = new()
            {
                Line1 = Line1.Match,
                PostalCode = PostalCode.Match,
            },
            PartialAmount = 1,
        };
        Decline expectedDecline = new(Reason.InsufficientFunds);

        Assert.Equal(expectedDecision, model.Decision);
        Assert.Equal(expectedApproval, model.Approval);
        Assert.Equal(expectedDecline, model.Decline);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardAuthorization
        {
            Decision = CardAuthorizationDecision.Approve,
            Approval = new()
            {
                CardholderAddressVerificationResult = new()
                {
                    Line1 = Line1.Match,
                    PostalCode = PostalCode.Match,
                },
                PartialAmount = 1,
            },
            Decline = new(Reason.InsufficientFunds),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardAuthorization>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardAuthorization
        {
            Decision = CardAuthorizationDecision.Approve,
            Approval = new()
            {
                CardholderAddressVerificationResult = new()
                {
                    Line1 = Line1.Match,
                    PostalCode = PostalCode.Match,
                },
                PartialAmount = 1,
            },
            Decline = new(Reason.InsufficientFunds),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardAuthorization>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CardAuthorizationDecision> expectedDecision =
            CardAuthorizationDecision.Approve;
        Approval expectedApproval = new()
        {
            CardholderAddressVerificationResult = new()
            {
                Line1 = Line1.Match,
                PostalCode = PostalCode.Match,
            },
            PartialAmount = 1,
        };
        Decline expectedDecline = new(Reason.InsufficientFunds);

        Assert.Equal(expectedDecision, deserialized.Decision);
        Assert.Equal(expectedApproval, deserialized.Approval);
        Assert.Equal(expectedDecline, deserialized.Decline);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardAuthorization
        {
            Decision = CardAuthorizationDecision.Approve,
            Approval = new()
            {
                CardholderAddressVerificationResult = new()
                {
                    Line1 = Line1.Match,
                    PostalCode = PostalCode.Match,
                },
                PartialAmount = 1,
            },
            Decline = new(Reason.InsufficientFunds),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CardAuthorization { Decision = CardAuthorizationDecision.Approve };

        Assert.Null(model.Approval);
        Assert.False(model.RawData.ContainsKey("approval"));
        Assert.Null(model.Decline);
        Assert.False(model.RawData.ContainsKey("decline"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CardAuthorization { Decision = CardAuthorizationDecision.Approve };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CardAuthorization
        {
            Decision = CardAuthorizationDecision.Approve,

            // Null should be interpreted as omitted for these properties
            Approval = null,
            Decline = null,
        };

        Assert.Null(model.Approval);
        Assert.False(model.RawData.ContainsKey("approval"));
        Assert.Null(model.Decline);
        Assert.False(model.RawData.ContainsKey("decline"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CardAuthorization
        {
            Decision = CardAuthorizationDecision.Approve,

            // Null should be interpreted as omitted for these properties
            Approval = null,
            Decline = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardAuthorization
        {
            Decision = CardAuthorizationDecision.Approve,
            Approval = new()
            {
                CardholderAddressVerificationResult = new()
                {
                    Line1 = Line1.Match,
                    PostalCode = PostalCode.Match,
                },
                PartialAmount = 1,
            },
            Decline = new(Reason.InsufficientFunds),
        };

        CardAuthorization copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationDecisionTest : TestBase
{
    [Theory]
    [InlineData(CardAuthorizationDecision.Approve)]
    [InlineData(CardAuthorizationDecision.Decline)]
    public void Validation_Works(CardAuthorizationDecision rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardAuthorizationDecision> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardAuthorizationDecision>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardAuthorizationDecision.Approve)]
    [InlineData(CardAuthorizationDecision.Decline)]
    public void SerializationRoundtrip_Works(CardAuthorizationDecision rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardAuthorizationDecision> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardAuthorizationDecision>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardAuthorizationDecision>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardAuthorizationDecision>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ApprovalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Approval
        {
            CardholderAddressVerificationResult = new()
            {
                Line1 = Line1.Match,
                PostalCode = PostalCode.Match,
            },
            PartialAmount = 1,
        };

        CardholderAddressVerificationResult expectedCardholderAddressVerificationResult = new()
        {
            Line1 = Line1.Match,
            PostalCode = PostalCode.Match,
        };
        long expectedPartialAmount = 1;

        Assert.Equal(
            expectedCardholderAddressVerificationResult,
            model.CardholderAddressVerificationResult
        );
        Assert.Equal(expectedPartialAmount, model.PartialAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Approval
        {
            CardholderAddressVerificationResult = new()
            {
                Line1 = Line1.Match,
                PostalCode = PostalCode.Match,
            },
            PartialAmount = 1,
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
            CardholderAddressVerificationResult = new()
            {
                Line1 = Line1.Match,
                PostalCode = PostalCode.Match,
            },
            PartialAmount = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Approval>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CardholderAddressVerificationResult expectedCardholderAddressVerificationResult = new()
        {
            Line1 = Line1.Match,
            PostalCode = PostalCode.Match,
        };
        long expectedPartialAmount = 1;

        Assert.Equal(
            expectedCardholderAddressVerificationResult,
            deserialized.CardholderAddressVerificationResult
        );
        Assert.Equal(expectedPartialAmount, deserialized.PartialAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Approval
        {
            CardholderAddressVerificationResult = new()
            {
                Line1 = Line1.Match,
                PostalCode = PostalCode.Match,
            },
            PartialAmount = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Approval { };

        Assert.Null(model.CardholderAddressVerificationResult);
        Assert.False(model.RawData.ContainsKey("cardholder_address_verification_result"));
        Assert.Null(model.PartialAmount);
        Assert.False(model.RawData.ContainsKey("partial_amount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Approval { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Approval
        {
            // Null should be interpreted as omitted for these properties
            CardholderAddressVerificationResult = null,
            PartialAmount = null,
        };

        Assert.Null(model.CardholderAddressVerificationResult);
        Assert.False(model.RawData.ContainsKey("cardholder_address_verification_result"));
        Assert.Null(model.PartialAmount);
        Assert.False(model.RawData.ContainsKey("partial_amount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Approval
        {
            // Null should be interpreted as omitted for these properties
            CardholderAddressVerificationResult = null,
            PartialAmount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Approval
        {
            CardholderAddressVerificationResult = new()
            {
                Line1 = Line1.Match,
                PostalCode = PostalCode.Match,
            },
            PartialAmount = 1,
        };

        Approval copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardholderAddressVerificationResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardholderAddressVerificationResult
        {
            Line1 = Line1.Match,
            PostalCode = PostalCode.Match,
        };

        ApiEnum<string, Line1> expectedLine1 = Line1.Match;
        ApiEnum<string, PostalCode> expectedPostalCode = PostalCode.Match;

        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedPostalCode, model.PostalCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardholderAddressVerificationResult
        {
            Line1 = Line1.Match,
            PostalCode = PostalCode.Match,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardholderAddressVerificationResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardholderAddressVerificationResult
        {
            Line1 = Line1.Match,
            PostalCode = PostalCode.Match,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardholderAddressVerificationResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Line1> expectedLine1 = Line1.Match;
        ApiEnum<string, PostalCode> expectedPostalCode = PostalCode.Match;

        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardholderAddressVerificationResult
        {
            Line1 = Line1.Match,
            PostalCode = PostalCode.Match,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardholderAddressVerificationResult
        {
            Line1 = Line1.Match,
            PostalCode = PostalCode.Match,
        };

        CardholderAddressVerificationResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class Line1Test : TestBase
{
    [Theory]
    [InlineData(Line1.Match)]
    [InlineData(Line1.NoMatch)]
    public void Validation_Works(Line1 rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Line1> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Line1>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Line1.Match)]
    [InlineData(Line1.NoMatch)]
    public void SerializationRoundtrip_Works(Line1 rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Line1> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Line1>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Line1>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Line1>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PostalCodeTest : TestBase
{
    [Theory]
    [InlineData(PostalCode.Match)]
    [InlineData(PostalCode.NoMatch)]
    public void Validation_Works(PostalCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PostalCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PostalCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PostalCode.Match)]
    [InlineData(PostalCode.NoMatch)]
    public void SerializationRoundtrip_Works(PostalCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PostalCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PostalCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PostalCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PostalCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DeclineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Decline { Reason = Reason.InsufficientFunds };

        ApiEnum<string, Reason> expectedReason = Reason.InsufficientFunds;

        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Decline { Reason = Reason.InsufficientFunds };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Decline>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Decline { Reason = Reason.InsufficientFunds };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Decline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Reason> expectedReason = Reason.InsufficientFunds;

        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Decline { Reason = Reason.InsufficientFunds };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Decline { Reason = Reason.InsufficientFunds };

        Decline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.InsufficientFunds)]
    [InlineData(Reason.TransactionNeverAllowed)]
    [InlineData(Reason.ExceedsApprovalLimit)]
    [InlineData(Reason.CardTemporarilyDisabled)]
    [InlineData(Reason.SuspectedFraud)]
    [InlineData(Reason.Other)]
    public void Validation_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Reason.InsufficientFunds)]
    [InlineData(Reason.TransactionNeverAllowed)]
    [InlineData(Reason.ExceedsApprovalLimit)]
    [InlineData(Reason.CardTemporarilyDisabled)]
    [InlineData(Reason.SuspectedFraud)]
    [InlineData(Reason.Other)]
    public void SerializationRoundtrip_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CardBalanceInquiryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardBalanceInquiry
        {
            Decision = CardBalanceInquiryDecision.Approve,
            Approval = new(0),
        };

        ApiEnum<string, CardBalanceInquiryDecision> expectedDecision =
            CardBalanceInquiryDecision.Approve;
        CardBalanceInquiryApproval expectedApproval = new(0);

        Assert.Equal(expectedDecision, model.Decision);
        Assert.Equal(expectedApproval, model.Approval);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardBalanceInquiry
        {
            Decision = CardBalanceInquiryDecision.Approve,
            Approval = new(0),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardBalanceInquiry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardBalanceInquiry
        {
            Decision = CardBalanceInquiryDecision.Approve,
            Approval = new(0),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardBalanceInquiry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CardBalanceInquiryDecision> expectedDecision =
            CardBalanceInquiryDecision.Approve;
        CardBalanceInquiryApproval expectedApproval = new(0);

        Assert.Equal(expectedDecision, deserialized.Decision);
        Assert.Equal(expectedApproval, deserialized.Approval);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardBalanceInquiry
        {
            Decision = CardBalanceInquiryDecision.Approve,
            Approval = new(0),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CardBalanceInquiry { Decision = CardBalanceInquiryDecision.Approve };

        Assert.Null(model.Approval);
        Assert.False(model.RawData.ContainsKey("approval"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CardBalanceInquiry { Decision = CardBalanceInquiryDecision.Approve };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CardBalanceInquiry
        {
            Decision = CardBalanceInquiryDecision.Approve,

            // Null should be interpreted as omitted for these properties
            Approval = null,
        };

        Assert.Null(model.Approval);
        Assert.False(model.RawData.ContainsKey("approval"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CardBalanceInquiry
        {
            Decision = CardBalanceInquiryDecision.Approve,

            // Null should be interpreted as omitted for these properties
            Approval = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardBalanceInquiry
        {
            Decision = CardBalanceInquiryDecision.Approve,
            Approval = new(0),
        };

        CardBalanceInquiry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardBalanceInquiryDecisionTest : TestBase
{
    [Theory]
    [InlineData(CardBalanceInquiryDecision.Approve)]
    [InlineData(CardBalanceInquiryDecision.Decline)]
    public void Validation_Works(CardBalanceInquiryDecision rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardBalanceInquiryDecision> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardBalanceInquiryDecision>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardBalanceInquiryDecision.Approve)]
    [InlineData(CardBalanceInquiryDecision.Decline)]
    public void SerializationRoundtrip_Works(CardBalanceInquiryDecision rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardBalanceInquiryDecision> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardBalanceInquiryDecision>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardBalanceInquiryDecision>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardBalanceInquiryDecision>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CardBalanceInquiryApprovalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardBalanceInquiryApproval { Balance = 0 };

        long expectedBalance = 0;

        Assert.Equal(expectedBalance, model.Balance);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardBalanceInquiryApproval { Balance = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardBalanceInquiryApproval>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardBalanceInquiryApproval { Balance = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardBalanceInquiryApproval>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedBalance = 0;

        Assert.Equal(expectedBalance, deserialized.Balance);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardBalanceInquiryApproval { Balance = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardBalanceInquiryApproval { Balance = 0 };

        CardBalanceInquiryApproval copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DigitalWalletAuthenticationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletAuthentication
        {
            Result = DigitalWalletAuthenticationResult.Success,
            Success = new() { Email = "dev@stainless.com", Phone = "x" },
        };

        ApiEnum<string, DigitalWalletAuthenticationResult> expectedResult =
            DigitalWalletAuthenticationResult.Success;
        DigitalWalletAuthenticationSuccess expectedSuccess = new()
        {
            Email = "dev@stainless.com",
            Phone = "x",
        };

        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletAuthentication
        {
            Result = DigitalWalletAuthenticationResult.Success,
            Success = new() { Email = "dev@stainless.com", Phone = "x" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletAuthentication>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletAuthentication
        {
            Result = DigitalWalletAuthenticationResult.Success,
            Success = new() { Email = "dev@stainless.com", Phone = "x" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletAuthentication>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, DigitalWalletAuthenticationResult> expectedResult =
            DigitalWalletAuthenticationResult.Success;
        DigitalWalletAuthenticationSuccess expectedSuccess = new()
        {
            Email = "dev@stainless.com",
            Phone = "x",
        };

        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletAuthentication
        {
            Result = DigitalWalletAuthenticationResult.Success,
            Success = new() { Email = "dev@stainless.com", Phone = "x" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DigitalWalletAuthentication
        {
            Result = DigitalWalletAuthenticationResult.Success,
        };

        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DigitalWalletAuthentication
        {
            Result = DigitalWalletAuthenticationResult.Success,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DigitalWalletAuthentication
        {
            Result = DigitalWalletAuthenticationResult.Success,

            // Null should be interpreted as omitted for these properties
            Success = null,
        };

        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DigitalWalletAuthentication
        {
            Result = DigitalWalletAuthenticationResult.Success,

            // Null should be interpreted as omitted for these properties
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletAuthentication
        {
            Result = DigitalWalletAuthenticationResult.Success,
            Success = new() { Email = "dev@stainless.com", Phone = "x" },
        };

        DigitalWalletAuthentication copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DigitalWalletAuthenticationResultTest : TestBase
{
    [Theory]
    [InlineData(DigitalWalletAuthenticationResult.Success)]
    [InlineData(DigitalWalletAuthenticationResult.Failure)]
    public void Validation_Works(DigitalWalletAuthenticationResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletAuthenticationResult> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletAuthenticationResult>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigitalWalletAuthenticationResult.Success)]
    [InlineData(DigitalWalletAuthenticationResult.Failure)]
    public void SerializationRoundtrip_Works(DigitalWalletAuthenticationResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletAuthenticationResult> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletAuthenticationResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletAuthenticationResult>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletAuthenticationResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DigitalWalletAuthenticationSuccessTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletAuthenticationSuccess
        {
            Email = "dev@stainless.com",
            Phone = "x",
        };

        string expectedEmail = "dev@stainless.com";
        string expectedPhone = "x";

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedPhone, model.Phone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletAuthenticationSuccess
        {
            Email = "dev@stainless.com",
            Phone = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletAuthenticationSuccess>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletAuthenticationSuccess
        {
            Email = "dev@stainless.com",
            Phone = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletAuthenticationSuccess>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "dev@stainless.com";
        string expectedPhone = "x";

        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedPhone, deserialized.Phone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletAuthenticationSuccess
        {
            Email = "dev@stainless.com",
            Phone = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DigitalWalletAuthenticationSuccess { };

        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DigitalWalletAuthenticationSuccess { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DigitalWalletAuthenticationSuccess
        {
            // Null should be interpreted as omitted for these properties
            Email = null,
            Phone = null,
        };

        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DigitalWalletAuthenticationSuccess
        {
            // Null should be interpreted as omitted for these properties
            Email = null,
            Phone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletAuthenticationSuccess
        {
            Email = "dev@stainless.com",
            Phone = "x",
        };

        DigitalWalletAuthenticationSuccess copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DigitalWalletTokenTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletToken
        {
            Approval = new() { Email = "dev@stainless.com", Phone = "x" },
            Decline = new() { Reason = "x" },
        };

        DigitalWalletTokenApproval expectedApproval = new()
        {
            Email = "dev@stainless.com",
            Phone = "x",
        };
        DigitalWalletTokenDecline expectedDecline = new() { Reason = "x" };

        Assert.Equal(expectedApproval, model.Approval);
        Assert.Equal(expectedDecline, model.Decline);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletToken
        {
            Approval = new() { Email = "dev@stainless.com", Phone = "x" },
            Decline = new() { Reason = "x" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletToken>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletToken
        {
            Approval = new() { Email = "dev@stainless.com", Phone = "x" },
            Decline = new() { Reason = "x" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletToken>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DigitalWalletTokenApproval expectedApproval = new()
        {
            Email = "dev@stainless.com",
            Phone = "x",
        };
        DigitalWalletTokenDecline expectedDecline = new() { Reason = "x" };

        Assert.Equal(expectedApproval, deserialized.Approval);
        Assert.Equal(expectedDecline, deserialized.Decline);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletToken
        {
            Approval = new() { Email = "dev@stainless.com", Phone = "x" },
            Decline = new() { Reason = "x" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DigitalWalletToken { };

        Assert.Null(model.Approval);
        Assert.False(model.RawData.ContainsKey("approval"));
        Assert.Null(model.Decline);
        Assert.False(model.RawData.ContainsKey("decline"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DigitalWalletToken { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DigitalWalletToken
        {
            // Null should be interpreted as omitted for these properties
            Approval = null,
            Decline = null,
        };

        Assert.Null(model.Approval);
        Assert.False(model.RawData.ContainsKey("approval"));
        Assert.Null(model.Decline);
        Assert.False(model.RawData.ContainsKey("decline"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DigitalWalletToken
        {
            // Null should be interpreted as omitted for these properties
            Approval = null,
            Decline = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletToken
        {
            Approval = new() { Email = "dev@stainless.com", Phone = "x" },
            Decline = new() { Reason = "x" },
        };

        DigitalWalletToken copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DigitalWalletTokenApprovalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokenApproval { Email = "dev@stainless.com", Phone = "x" };

        string expectedEmail = "dev@stainless.com";
        string expectedPhone = "x";

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedPhone, model.Phone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokenApproval { Email = "dev@stainless.com", Phone = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenApproval>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokenApproval { Email = "dev@stainless.com", Phone = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenApproval>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "dev@stainless.com";
        string expectedPhone = "x";

        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedPhone, deserialized.Phone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokenApproval { Email = "dev@stainless.com", Phone = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DigitalWalletTokenApproval { };

        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DigitalWalletTokenApproval { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DigitalWalletTokenApproval
        {
            // Null should be interpreted as omitted for these properties
            Email = null,
            Phone = null,
        };

        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DigitalWalletTokenApproval
        {
            // Null should be interpreted as omitted for these properties
            Email = null,
            Phone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokenApproval { Email = "dev@stainless.com", Phone = "x" };

        DigitalWalletTokenApproval copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DigitalWalletTokenDeclineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokenDecline { Reason = "x" };

        string expectedReason = "x";

        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokenDecline { Reason = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenDecline>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokenDecline { Reason = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenDecline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedReason = "x";

        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokenDecline { Reason = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DigitalWalletTokenDecline { };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DigitalWalletTokenDecline { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DigitalWalletTokenDecline
        {
            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DigitalWalletTokenDecline
        {
            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokenDecline { Reason = "x" };

        DigitalWalletTokenDecline copied = new(model);

        Assert.Equal(model, copied);
    }
}
