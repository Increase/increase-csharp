using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.CardTokens;

namespace Increase.Api.Tests.Models.Simulations.CardTokens;

public class CardTokenCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardTokenCreateParams
        {
            Capabilities =
            [
                new()
                {
                    CrossBorderPushTransfers = CrossBorderPushTransfers.Supported,
                    DomesticPushTransfers = DomesticPushTransfers.Supported,
                    Route = Route.Visa,
                },
            ],
            Expiration = "2019-12-27",
            Last4 = "1234",
            Outcome = new()
            {
                Result = Result.Approve,
                Decline = new() { Reason = Reason.DoNotHonor },
            },
            Prefix = "41234567",
            PrimaryAccountNumberLength = 16,
        };

        List<Capability> expectedCapabilities =
        [
            new()
            {
                CrossBorderPushTransfers = CrossBorderPushTransfers.Supported,
                DomesticPushTransfers = DomesticPushTransfers.Supported,
                Route = Route.Visa,
            },
        ];
        string expectedExpiration = "2019-12-27";
        string expectedLast4 = "1234";
        Outcome expectedOutcome = new()
        {
            Result = Result.Approve,
            Decline = new() { Reason = Reason.DoNotHonor },
        };
        string expectedPrefix = "41234567";
        long expectedPrimaryAccountNumberLength = 16;

        Assert.NotNull(parameters.Capabilities);
        Assert.Equal(expectedCapabilities.Count, parameters.Capabilities.Count);
        for (int i = 0; i < expectedCapabilities.Count; i++)
        {
            Assert.Equal(expectedCapabilities[i], parameters.Capabilities[i]);
        }
        Assert.Equal(expectedExpiration, parameters.Expiration);
        Assert.Equal(expectedLast4, parameters.Last4);
        Assert.Equal(expectedOutcome, parameters.Outcome);
        Assert.Equal(expectedPrefix, parameters.Prefix);
        Assert.Equal(expectedPrimaryAccountNumberLength, parameters.PrimaryAccountNumberLength);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CardTokenCreateParams { };

        Assert.Null(parameters.Capabilities);
        Assert.False(parameters.RawBodyData.ContainsKey("capabilities"));
        Assert.Null(parameters.Expiration);
        Assert.False(parameters.RawBodyData.ContainsKey("expiration"));
        Assert.Null(parameters.Last4);
        Assert.False(parameters.RawBodyData.ContainsKey("last4"));
        Assert.Null(parameters.Outcome);
        Assert.False(parameters.RawBodyData.ContainsKey("outcome"));
        Assert.Null(parameters.Prefix);
        Assert.False(parameters.RawBodyData.ContainsKey("prefix"));
        Assert.Null(parameters.PrimaryAccountNumberLength);
        Assert.False(parameters.RawBodyData.ContainsKey("primary_account_number_length"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CardTokenCreateParams
        {
            // Null should be interpreted as omitted for these properties
            Capabilities = null,
            Expiration = null,
            Last4 = null,
            Outcome = null,
            Prefix = null,
            PrimaryAccountNumberLength = null,
        };

        Assert.Null(parameters.Capabilities);
        Assert.False(parameters.RawBodyData.ContainsKey("capabilities"));
        Assert.Null(parameters.Expiration);
        Assert.False(parameters.RawBodyData.ContainsKey("expiration"));
        Assert.Null(parameters.Last4);
        Assert.False(parameters.RawBodyData.ContainsKey("last4"));
        Assert.Null(parameters.Outcome);
        Assert.False(parameters.RawBodyData.ContainsKey("outcome"));
        Assert.Null(parameters.Prefix);
        Assert.False(parameters.RawBodyData.ContainsKey("prefix"));
        Assert.Null(parameters.PrimaryAccountNumberLength);
        Assert.False(parameters.RawBodyData.ContainsKey("primary_account_number_length"));
    }

    [Fact]
    public void Url_Works()
    {
        CardTokenCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.increase.com/simulations/card_tokens"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardTokenCreateParams
        {
            Capabilities =
            [
                new()
                {
                    CrossBorderPushTransfers = CrossBorderPushTransfers.Supported,
                    DomesticPushTransfers = DomesticPushTransfers.Supported,
                    Route = Route.Visa,
                },
            ],
            Expiration = "2019-12-27",
            Last4 = "1234",
            Outcome = new()
            {
                Result = Result.Approve,
                Decline = new() { Reason = Reason.DoNotHonor },
            },
            Prefix = "41234567",
            PrimaryAccountNumberLength = 16,
        };

        CardTokenCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CapabilityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Capability
        {
            CrossBorderPushTransfers = CrossBorderPushTransfers.Supported,
            DomesticPushTransfers = DomesticPushTransfers.Supported,
            Route = Route.Visa,
        };

        ApiEnum<string, CrossBorderPushTransfers> expectedCrossBorderPushTransfers =
            CrossBorderPushTransfers.Supported;
        ApiEnum<string, DomesticPushTransfers> expectedDomesticPushTransfers =
            DomesticPushTransfers.Supported;
        ApiEnum<string, Route> expectedRoute = Route.Visa;

        Assert.Equal(expectedCrossBorderPushTransfers, model.CrossBorderPushTransfers);
        Assert.Equal(expectedDomesticPushTransfers, model.DomesticPushTransfers);
        Assert.Equal(expectedRoute, model.Route);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Capability
        {
            CrossBorderPushTransfers = CrossBorderPushTransfers.Supported,
            DomesticPushTransfers = DomesticPushTransfers.Supported,
            Route = Route.Visa,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Capability>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Capability
        {
            CrossBorderPushTransfers = CrossBorderPushTransfers.Supported,
            DomesticPushTransfers = DomesticPushTransfers.Supported,
            Route = Route.Visa,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Capability>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CrossBorderPushTransfers> expectedCrossBorderPushTransfers =
            CrossBorderPushTransfers.Supported;
        ApiEnum<string, DomesticPushTransfers> expectedDomesticPushTransfers =
            DomesticPushTransfers.Supported;
        ApiEnum<string, Route> expectedRoute = Route.Visa;

        Assert.Equal(expectedCrossBorderPushTransfers, deserialized.CrossBorderPushTransfers);
        Assert.Equal(expectedDomesticPushTransfers, deserialized.DomesticPushTransfers);
        Assert.Equal(expectedRoute, deserialized.Route);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Capability
        {
            CrossBorderPushTransfers = CrossBorderPushTransfers.Supported,
            DomesticPushTransfers = DomesticPushTransfers.Supported,
            Route = Route.Visa,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Capability
        {
            CrossBorderPushTransfers = CrossBorderPushTransfers.Supported,
            DomesticPushTransfers = DomesticPushTransfers.Supported,
            Route = Route.Visa,
        };

        Capability copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CrossBorderPushTransfersTest : TestBase
{
    [Theory]
    [InlineData(CrossBorderPushTransfers.Supported)]
    [InlineData(CrossBorderPushTransfers.NotSupported)]
    public void Validation_Works(CrossBorderPushTransfers rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CrossBorderPushTransfers> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CrossBorderPushTransfers>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CrossBorderPushTransfers.Supported)]
    [InlineData(CrossBorderPushTransfers.NotSupported)]
    public void SerializationRoundtrip_Works(CrossBorderPushTransfers rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CrossBorderPushTransfers> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CrossBorderPushTransfers>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CrossBorderPushTransfers>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CrossBorderPushTransfers>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DomesticPushTransfersTest : TestBase
{
    [Theory]
    [InlineData(DomesticPushTransfers.Supported)]
    [InlineData(DomesticPushTransfers.NotSupported)]
    public void Validation_Works(DomesticPushTransfers rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DomesticPushTransfers> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DomesticPushTransfers>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DomesticPushTransfers.Supported)]
    [InlineData(DomesticPushTransfers.NotSupported)]
    public void SerializationRoundtrip_Works(DomesticPushTransfers rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DomesticPushTransfers> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DomesticPushTransfers>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DomesticPushTransfers>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DomesticPushTransfers>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RouteTest : TestBase
{
    [Theory]
    [InlineData(Route.Visa)]
    [InlineData(Route.Mastercard)]
    [InlineData(Route.Pulse)]
    public void Validation_Works(Route rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Route> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Route>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Route.Visa)]
    [InlineData(Route.Mastercard)]
    [InlineData(Route.Pulse)]
    public void SerializationRoundtrip_Works(Route rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Route> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Route>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Route>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Route>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OutcomeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Outcome
        {
            Result = Result.Approve,
            Decline = new() { Reason = Reason.DoNotHonor },
        };

        ApiEnum<string, Result> expectedResult = Result.Approve;
        Decline expectedDecline = new() { Reason = Reason.DoNotHonor };

        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedDecline, model.Decline);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Outcome
        {
            Result = Result.Approve,
            Decline = new() { Reason = Reason.DoNotHonor },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Outcome>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Outcome
        {
            Result = Result.Approve,
            Decline = new() { Reason = Reason.DoNotHonor },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Outcome>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Result> expectedResult = Result.Approve;
        Decline expectedDecline = new() { Reason = Reason.DoNotHonor };

        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedDecline, deserialized.Decline);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Outcome
        {
            Result = Result.Approve,
            Decline = new() { Reason = Reason.DoNotHonor },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Outcome { Result = Result.Approve };

        Assert.Null(model.Decline);
        Assert.False(model.RawData.ContainsKey("decline"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Outcome { Result = Result.Approve };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Outcome
        {
            Result = Result.Approve,

            // Null should be interpreted as omitted for these properties
            Decline = null,
        };

        Assert.Null(model.Decline);
        Assert.False(model.RawData.ContainsKey("decline"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Outcome
        {
            Result = Result.Approve,

            // Null should be interpreted as omitted for these properties
            Decline = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Outcome
        {
            Result = Result.Approve,
            Decline = new() { Reason = Reason.DoNotHonor },
        };

        Outcome copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Theory]
    [InlineData(Result.Approve)]
    [InlineData(Result.Decline)]
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
    [InlineData(Result.Approve)]
    [InlineData(Result.Decline)]
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

public class DeclineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Decline { Reason = Reason.DoNotHonor };

        ApiEnum<string, Reason> expectedReason = Reason.DoNotHonor;

        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Decline { Reason = Reason.DoNotHonor };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Decline>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Decline { Reason = Reason.DoNotHonor };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Decline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Reason> expectedReason = Reason.DoNotHonor;

        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Decline { Reason = Reason.DoNotHonor };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Decline { };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Decline { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Decline
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
        var model = new Decline
        {
            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Decline { Reason = Reason.DoNotHonor };

        Decline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.DoNotHonor)]
    [InlineData(Reason.ActivityCountLimitExceeded)]
    [InlineData(Reason.ReferToCardIssuer)]
    [InlineData(Reason.ReferToCardIssuerSpecialCondition)]
    [InlineData(Reason.InvalidMerchant)]
    [InlineData(Reason.PickUpCard)]
    [InlineData(Reason.Error)]
    [InlineData(Reason.PickUpCardSpecial)]
    [InlineData(Reason.InvalidTransaction)]
    [InlineData(Reason.InvalidAmount)]
    [InlineData(Reason.InvalidAccountNumber)]
    [InlineData(Reason.NoSuchIssuer)]
    [InlineData(Reason.ReEnterTransaction)]
    [InlineData(Reason.NoCreditAccount)]
    [InlineData(Reason.PickUpCardLost)]
    [InlineData(Reason.PickUpCardStolen)]
    [InlineData(Reason.ClosedAccount)]
    [InlineData(Reason.InsufficientFunds)]
    [InlineData(Reason.NoCheckingAccount)]
    [InlineData(Reason.NoSavingsAccount)]
    [InlineData(Reason.ExpiredCard)]
    [InlineData(Reason.TransactionNotPermittedToCardholder)]
    [InlineData(Reason.TransactionNotAllowedAtTerminal)]
    [InlineData(Reason.TransactionNotSupportedOrBlockedByIssuer)]
    [InlineData(Reason.SuspectedFraud)]
    [InlineData(Reason.ActivityAmountLimitExceeded)]
    [InlineData(Reason.RestrictedCard)]
    [InlineData(Reason.SecurityViolation)]
    [InlineData(Reason.TransactionDoesNotFulfillAntiMoneyLaunderingRequirement)]
    [InlineData(Reason.BlockedByCardholder)]
    [InlineData(Reason.BlockedFirstUse)]
    [InlineData(Reason.CreditIssuerUnavailable)]
    [InlineData(Reason.NegativeCardVerificationValueResults)]
    [InlineData(Reason.IssuerUnavailable)]
    [InlineData(Reason.FinancialInstitutionCannotBeFound)]
    [InlineData(Reason.TransactionCannotBeCompleted)]
    [InlineData(Reason.DuplicateTransaction)]
    [InlineData(Reason.SystemMalfunction)]
    [InlineData(Reason.AdditionalCustomerAuthenticationRequired)]
    [InlineData(Reason.SurchargeAmountNotPermitted)]
    [InlineData(Reason.DeclineForCvv2Failure)]
    [InlineData(Reason.StopPaymentOrder)]
    [InlineData(Reason.RevocationOfAuthorizationOrder)]
    [InlineData(Reason.RevocationOfAllAuthorizationsOrder)]
    [InlineData(Reason.UnableToLocateRecord)]
    [InlineData(Reason.FileIsTemporarilyUnavailable)]
    [InlineData(Reason.IncorrectPin)]
    [InlineData(Reason.AllowableNumberOfPinEntryTriesExceeded)]
    [InlineData(Reason.UnableToLocatePreviousMessage)]
    [InlineData(Reason.PinErrorFound)]
    [InlineData(Reason.CannotVerifyPin)]
    [InlineData(Reason.VerificationDataFailed)]
    [InlineData(Reason.SurchargeAmountNotSupportedByDebitNetworkIssuer)]
    [InlineData(Reason.CashServiceNotAvailable)]
    [InlineData(Reason.CashbackRequestExceedsIssuerLimit)]
    [InlineData(Reason.TransactionAmountExceedsPreAuthorizedApprovalAmount)]
    [InlineData(Reason.TransactionDoesNotQualifyForVisaPin)]
    [InlineData(Reason.OfflineDeclined)]
    [InlineData(Reason.UnableToGoOnline)]
    [InlineData(Reason.ValidAccountButAmountNotSupported)]
    [InlineData(Reason.InvalidUseOfMerchantCategoryCodeCorrectAndReattempt)]
    [InlineData(Reason.CardAuthenticationFailed)]
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
    [InlineData(Reason.DoNotHonor)]
    [InlineData(Reason.ActivityCountLimitExceeded)]
    [InlineData(Reason.ReferToCardIssuer)]
    [InlineData(Reason.ReferToCardIssuerSpecialCondition)]
    [InlineData(Reason.InvalidMerchant)]
    [InlineData(Reason.PickUpCard)]
    [InlineData(Reason.Error)]
    [InlineData(Reason.PickUpCardSpecial)]
    [InlineData(Reason.InvalidTransaction)]
    [InlineData(Reason.InvalidAmount)]
    [InlineData(Reason.InvalidAccountNumber)]
    [InlineData(Reason.NoSuchIssuer)]
    [InlineData(Reason.ReEnterTransaction)]
    [InlineData(Reason.NoCreditAccount)]
    [InlineData(Reason.PickUpCardLost)]
    [InlineData(Reason.PickUpCardStolen)]
    [InlineData(Reason.ClosedAccount)]
    [InlineData(Reason.InsufficientFunds)]
    [InlineData(Reason.NoCheckingAccount)]
    [InlineData(Reason.NoSavingsAccount)]
    [InlineData(Reason.ExpiredCard)]
    [InlineData(Reason.TransactionNotPermittedToCardholder)]
    [InlineData(Reason.TransactionNotAllowedAtTerminal)]
    [InlineData(Reason.TransactionNotSupportedOrBlockedByIssuer)]
    [InlineData(Reason.SuspectedFraud)]
    [InlineData(Reason.ActivityAmountLimitExceeded)]
    [InlineData(Reason.RestrictedCard)]
    [InlineData(Reason.SecurityViolation)]
    [InlineData(Reason.TransactionDoesNotFulfillAntiMoneyLaunderingRequirement)]
    [InlineData(Reason.BlockedByCardholder)]
    [InlineData(Reason.BlockedFirstUse)]
    [InlineData(Reason.CreditIssuerUnavailable)]
    [InlineData(Reason.NegativeCardVerificationValueResults)]
    [InlineData(Reason.IssuerUnavailable)]
    [InlineData(Reason.FinancialInstitutionCannotBeFound)]
    [InlineData(Reason.TransactionCannotBeCompleted)]
    [InlineData(Reason.DuplicateTransaction)]
    [InlineData(Reason.SystemMalfunction)]
    [InlineData(Reason.AdditionalCustomerAuthenticationRequired)]
    [InlineData(Reason.SurchargeAmountNotPermitted)]
    [InlineData(Reason.DeclineForCvv2Failure)]
    [InlineData(Reason.StopPaymentOrder)]
    [InlineData(Reason.RevocationOfAuthorizationOrder)]
    [InlineData(Reason.RevocationOfAllAuthorizationsOrder)]
    [InlineData(Reason.UnableToLocateRecord)]
    [InlineData(Reason.FileIsTemporarilyUnavailable)]
    [InlineData(Reason.IncorrectPin)]
    [InlineData(Reason.AllowableNumberOfPinEntryTriesExceeded)]
    [InlineData(Reason.UnableToLocatePreviousMessage)]
    [InlineData(Reason.PinErrorFound)]
    [InlineData(Reason.CannotVerifyPin)]
    [InlineData(Reason.VerificationDataFailed)]
    [InlineData(Reason.SurchargeAmountNotSupportedByDebitNetworkIssuer)]
    [InlineData(Reason.CashServiceNotAvailable)]
    [InlineData(Reason.CashbackRequestExceedsIssuerLimit)]
    [InlineData(Reason.TransactionAmountExceedsPreAuthorizedApprovalAmount)]
    [InlineData(Reason.TransactionDoesNotQualifyForVisaPin)]
    [InlineData(Reason.OfflineDeclined)]
    [InlineData(Reason.UnableToGoOnline)]
    [InlineData(Reason.ValidAccountButAmountNotSupported)]
    [InlineData(Reason.InvalidUseOfMerchantCategoryCodeCorrectAndReattempt)]
    [InlineData(Reason.CardAuthenticationFailed)]
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
