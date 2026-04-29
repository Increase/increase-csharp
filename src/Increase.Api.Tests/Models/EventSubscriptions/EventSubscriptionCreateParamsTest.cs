using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.EventSubscriptions;

namespace Increase.Api.Tests.Models.EventSubscriptions;

public class EventSubscriptionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventSubscriptionCreateParams
        {
            UrlValue = "https://website.com/webhooks",
            OAuthConnectionID = "x",
            SelectedEventCategories = [new(EventCategory.AccountCreated)],
            SharedSecret = "x",
            Status = Status.Active,
        };

        string expectedUrlValue = "https://website.com/webhooks";
        string expectedOAuthConnectionID = "x";
        List<SelectedEventCategory> expectedSelectedEventCategories =
        [
            new(EventCategory.AccountCreated),
        ];
        string expectedSharedSecret = "x";
        ApiEnum<string, Status> expectedStatus = Status.Active;

        Assert.Equal(expectedUrlValue, parameters.UrlValue);
        Assert.Equal(expectedOAuthConnectionID, parameters.OAuthConnectionID);
        Assert.NotNull(parameters.SelectedEventCategories);
        Assert.Equal(
            expectedSelectedEventCategories.Count,
            parameters.SelectedEventCategories.Count
        );
        for (int i = 0; i < expectedSelectedEventCategories.Count; i++)
        {
            Assert.Equal(expectedSelectedEventCategories[i], parameters.SelectedEventCategories[i]);
        }
        Assert.Equal(expectedSharedSecret, parameters.SharedSecret);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EventSubscriptionCreateParams
        {
            UrlValue = "https://website.com/webhooks",
        };

        Assert.Null(parameters.OAuthConnectionID);
        Assert.False(parameters.RawBodyData.ContainsKey("oauth_connection_id"));
        Assert.Null(parameters.SelectedEventCategories);
        Assert.False(parameters.RawBodyData.ContainsKey("selected_event_categories"));
        Assert.Null(parameters.SharedSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("shared_secret"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EventSubscriptionCreateParams
        {
            UrlValue = "https://website.com/webhooks",

            // Null should be interpreted as omitted for these properties
            OAuthConnectionID = null,
            SelectedEventCategories = null,
            SharedSecret = null,
            Status = null,
        };

        Assert.Null(parameters.OAuthConnectionID);
        Assert.False(parameters.RawBodyData.ContainsKey("oauth_connection_id"));
        Assert.Null(parameters.SelectedEventCategories);
        Assert.False(parameters.RawBodyData.ContainsKey("selected_event_categories"));
        Assert.Null(parameters.SharedSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("shared_secret"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        EventSubscriptionCreateParams parameters = new()
        {
            UrlValue = "https://website.com/webhooks",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.increase.com/event_subscriptions"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EventSubscriptionCreateParams
        {
            UrlValue = "https://website.com/webhooks",
            OAuthConnectionID = "x",
            SelectedEventCategories = [new(EventCategory.AccountCreated)],
            SharedSecret = "x",
            Status = Status.Active,
        };

        EventSubscriptionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SelectedEventCategoryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SelectedEventCategory { EventCategory = EventCategory.AccountCreated };

        ApiEnum<string, EventCategory> expectedEventCategory = EventCategory.AccountCreated;

        Assert.Equal(expectedEventCategory, model.EventCategory);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SelectedEventCategory { EventCategory = EventCategory.AccountCreated };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SelectedEventCategory>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SelectedEventCategory { EventCategory = EventCategory.AccountCreated };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SelectedEventCategory>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, EventCategory> expectedEventCategory = EventCategory.AccountCreated;

        Assert.Equal(expectedEventCategory, deserialized.EventCategory);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SelectedEventCategory { EventCategory = EventCategory.AccountCreated };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SelectedEventCategory { EventCategory = EventCategory.AccountCreated };

        SelectedEventCategory copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventCategoryTest : TestBase
{
    [Theory]
    [InlineData(EventCategory.AccountCreated)]
    [InlineData(EventCategory.AccountUpdated)]
    [InlineData(EventCategory.AccountNumberCreated)]
    [InlineData(EventCategory.AccountNumberUpdated)]
    [InlineData(EventCategory.AccountStatementCreated)]
    [InlineData(EventCategory.AccountTransferCreated)]
    [InlineData(EventCategory.AccountTransferUpdated)]
    [InlineData(EventCategory.AchPrenotificationCreated)]
    [InlineData(EventCategory.AchPrenotificationUpdated)]
    [InlineData(EventCategory.AchTransferCreated)]
    [InlineData(EventCategory.AchTransferUpdated)]
    [InlineData(EventCategory.BlockchainAddressCreated)]
    [InlineData(EventCategory.BlockchainAddressUpdated)]
    [InlineData(EventCategory.BlockchainOfframpTransferCreated)]
    [InlineData(EventCategory.BlockchainOfframpTransferUpdated)]
    [InlineData(EventCategory.BlockchainOnrampTransferCreated)]
    [InlineData(EventCategory.BlockchainOnrampTransferUpdated)]
    [InlineData(EventCategory.BookkeepingAccountCreated)]
    [InlineData(EventCategory.BookkeepingAccountUpdated)]
    [InlineData(EventCategory.BookkeepingEntrySetUpdated)]
    [InlineData(EventCategory.CardCreated)]
    [InlineData(EventCategory.CardUpdated)]
    [InlineData(EventCategory.CardPaymentCreated)]
    [InlineData(EventCategory.CardPaymentUpdated)]
    [InlineData(EventCategory.CardPurchaseSupplementCreated)]
    [InlineData(EventCategory.CardProfileCreated)]
    [InlineData(EventCategory.CardProfileUpdated)]
    [InlineData(EventCategory.CardDisputeCreated)]
    [InlineData(EventCategory.CardDisputeUpdated)]
    [InlineData(EventCategory.CheckDepositCreated)]
    [InlineData(EventCategory.CheckDepositUpdated)]
    [InlineData(EventCategory.CheckTransferCreated)]
    [InlineData(EventCategory.CheckTransferUpdated)]
    [InlineData(EventCategory.DeclinedTransactionCreated)]
    [InlineData(EventCategory.DigitalCardProfileCreated)]
    [InlineData(EventCategory.DigitalCardProfileUpdated)]
    [InlineData(EventCategory.DigitalWalletTokenCreated)]
    [InlineData(EventCategory.DigitalWalletTokenUpdated)]
    [InlineData(EventCategory.EntityCreated)]
    [InlineData(EventCategory.EntityUpdated)]
    [InlineData(EventCategory.EventSubscriptionCreated)]
    [InlineData(EventCategory.EventSubscriptionUpdated)]
    [InlineData(EventCategory.ExportCreated)]
    [InlineData(EventCategory.ExportUpdated)]
    [InlineData(EventCategory.ExternalAccountCreated)]
    [InlineData(EventCategory.ExternalAccountUpdated)]
    [InlineData(EventCategory.FednowTransferCreated)]
    [InlineData(EventCategory.FednowTransferUpdated)]
    [InlineData(EventCategory.FileCreated)]
    [InlineData(EventCategory.GroupUpdated)]
    [InlineData(EventCategory.GroupHeartbeat)]
    [InlineData(EventCategory.InboundAchTransferCreated)]
    [InlineData(EventCategory.InboundAchTransferUpdated)]
    [InlineData(EventCategory.InboundAchTransferReturnCreated)]
    [InlineData(EventCategory.InboundAchTransferReturnUpdated)]
    [InlineData(EventCategory.InboundCheckDepositCreated)]
    [InlineData(EventCategory.InboundCheckDepositUpdated)]
    [InlineData(EventCategory.InboundFednowTransferCreated)]
    [InlineData(EventCategory.InboundFednowTransferUpdated)]
    [InlineData(EventCategory.InboundMailItemCreated)]
    [InlineData(EventCategory.InboundMailItemUpdated)]
    [InlineData(EventCategory.InboundRealTimePaymentsTransferCreated)]
    [InlineData(EventCategory.InboundRealTimePaymentsTransferUpdated)]
    [InlineData(EventCategory.InboundWireDrawdownRequestCreated)]
    [InlineData(EventCategory.InboundWireTransferCreated)]
    [InlineData(EventCategory.InboundWireTransferUpdated)]
    [InlineData(EventCategory.IntrafiAccountEnrollmentCreated)]
    [InlineData(EventCategory.IntrafiAccountEnrollmentUpdated)]
    [InlineData(EventCategory.IntrafiExclusionCreated)]
    [InlineData(EventCategory.IntrafiExclusionUpdated)]
    [InlineData(EventCategory.LockboxCreated)]
    [InlineData(EventCategory.LockboxUpdated)]
    [InlineData(EventCategory.OAuthConnectionCreated)]
    [InlineData(EventCategory.OAuthConnectionDeactivated)]
    [InlineData(EventCategory.CardPushTransferCreated)]
    [InlineData(EventCategory.CardPushTransferUpdated)]
    [InlineData(EventCategory.CardValidationCreated)]
    [InlineData(EventCategory.CardValidationUpdated)]
    [InlineData(EventCategory.PendingTransactionCreated)]
    [InlineData(EventCategory.PendingTransactionUpdated)]
    [InlineData(EventCategory.PhysicalCardCreated)]
    [InlineData(EventCategory.PhysicalCardUpdated)]
    [InlineData(EventCategory.PhysicalCardProfileCreated)]
    [InlineData(EventCategory.PhysicalCardProfileUpdated)]
    [InlineData(EventCategory.PhysicalCheckCreated)]
    [InlineData(EventCategory.PhysicalCheckUpdated)]
    [InlineData(EventCategory.ProgramCreated)]
    [InlineData(EventCategory.ProgramUpdated)]
    [InlineData(EventCategory.ProofOfAuthorizationRequestCreated)]
    [InlineData(EventCategory.ProofOfAuthorizationRequestUpdated)]
    [InlineData(EventCategory.RealTimeDecisionCardAuthorizationRequested)]
    [InlineData(EventCategory.RealTimeDecisionCardBalanceInquiryRequested)]
    [InlineData(EventCategory.RealTimeDecisionDigitalWalletTokenRequested)]
    [InlineData(EventCategory.RealTimeDecisionDigitalWalletAuthenticationRequested)]
    [InlineData(EventCategory.RealTimeDecisionCardAuthenticationRequested)]
    [InlineData(EventCategory.RealTimeDecisionCardAuthenticationChallengeRequested)]
    [InlineData(EventCategory.RealTimePaymentsTransferCreated)]
    [InlineData(EventCategory.RealTimePaymentsTransferUpdated)]
    [InlineData(EventCategory.RealTimePaymentsRequestForPaymentCreated)]
    [InlineData(EventCategory.RealTimePaymentsRequestForPaymentUpdated)]
    [InlineData(EventCategory.SwiftTransferCreated)]
    [InlineData(EventCategory.SwiftTransferUpdated)]
    [InlineData(EventCategory.TransactionCreated)]
    [InlineData(EventCategory.WireDrawdownRequestCreated)]
    [InlineData(EventCategory.WireDrawdownRequestUpdated)]
    [InlineData(EventCategory.WireTransferCreated)]
    [InlineData(EventCategory.WireTransferUpdated)]
    public void Validation_Works(EventCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventCategory.AccountCreated)]
    [InlineData(EventCategory.AccountUpdated)]
    [InlineData(EventCategory.AccountNumberCreated)]
    [InlineData(EventCategory.AccountNumberUpdated)]
    [InlineData(EventCategory.AccountStatementCreated)]
    [InlineData(EventCategory.AccountTransferCreated)]
    [InlineData(EventCategory.AccountTransferUpdated)]
    [InlineData(EventCategory.AchPrenotificationCreated)]
    [InlineData(EventCategory.AchPrenotificationUpdated)]
    [InlineData(EventCategory.AchTransferCreated)]
    [InlineData(EventCategory.AchTransferUpdated)]
    [InlineData(EventCategory.BlockchainAddressCreated)]
    [InlineData(EventCategory.BlockchainAddressUpdated)]
    [InlineData(EventCategory.BlockchainOfframpTransferCreated)]
    [InlineData(EventCategory.BlockchainOfframpTransferUpdated)]
    [InlineData(EventCategory.BlockchainOnrampTransferCreated)]
    [InlineData(EventCategory.BlockchainOnrampTransferUpdated)]
    [InlineData(EventCategory.BookkeepingAccountCreated)]
    [InlineData(EventCategory.BookkeepingAccountUpdated)]
    [InlineData(EventCategory.BookkeepingEntrySetUpdated)]
    [InlineData(EventCategory.CardCreated)]
    [InlineData(EventCategory.CardUpdated)]
    [InlineData(EventCategory.CardPaymentCreated)]
    [InlineData(EventCategory.CardPaymentUpdated)]
    [InlineData(EventCategory.CardPurchaseSupplementCreated)]
    [InlineData(EventCategory.CardProfileCreated)]
    [InlineData(EventCategory.CardProfileUpdated)]
    [InlineData(EventCategory.CardDisputeCreated)]
    [InlineData(EventCategory.CardDisputeUpdated)]
    [InlineData(EventCategory.CheckDepositCreated)]
    [InlineData(EventCategory.CheckDepositUpdated)]
    [InlineData(EventCategory.CheckTransferCreated)]
    [InlineData(EventCategory.CheckTransferUpdated)]
    [InlineData(EventCategory.DeclinedTransactionCreated)]
    [InlineData(EventCategory.DigitalCardProfileCreated)]
    [InlineData(EventCategory.DigitalCardProfileUpdated)]
    [InlineData(EventCategory.DigitalWalletTokenCreated)]
    [InlineData(EventCategory.DigitalWalletTokenUpdated)]
    [InlineData(EventCategory.EntityCreated)]
    [InlineData(EventCategory.EntityUpdated)]
    [InlineData(EventCategory.EventSubscriptionCreated)]
    [InlineData(EventCategory.EventSubscriptionUpdated)]
    [InlineData(EventCategory.ExportCreated)]
    [InlineData(EventCategory.ExportUpdated)]
    [InlineData(EventCategory.ExternalAccountCreated)]
    [InlineData(EventCategory.ExternalAccountUpdated)]
    [InlineData(EventCategory.FednowTransferCreated)]
    [InlineData(EventCategory.FednowTransferUpdated)]
    [InlineData(EventCategory.FileCreated)]
    [InlineData(EventCategory.GroupUpdated)]
    [InlineData(EventCategory.GroupHeartbeat)]
    [InlineData(EventCategory.InboundAchTransferCreated)]
    [InlineData(EventCategory.InboundAchTransferUpdated)]
    [InlineData(EventCategory.InboundAchTransferReturnCreated)]
    [InlineData(EventCategory.InboundAchTransferReturnUpdated)]
    [InlineData(EventCategory.InboundCheckDepositCreated)]
    [InlineData(EventCategory.InboundCheckDepositUpdated)]
    [InlineData(EventCategory.InboundFednowTransferCreated)]
    [InlineData(EventCategory.InboundFednowTransferUpdated)]
    [InlineData(EventCategory.InboundMailItemCreated)]
    [InlineData(EventCategory.InboundMailItemUpdated)]
    [InlineData(EventCategory.InboundRealTimePaymentsTransferCreated)]
    [InlineData(EventCategory.InboundRealTimePaymentsTransferUpdated)]
    [InlineData(EventCategory.InboundWireDrawdownRequestCreated)]
    [InlineData(EventCategory.InboundWireTransferCreated)]
    [InlineData(EventCategory.InboundWireTransferUpdated)]
    [InlineData(EventCategory.IntrafiAccountEnrollmentCreated)]
    [InlineData(EventCategory.IntrafiAccountEnrollmentUpdated)]
    [InlineData(EventCategory.IntrafiExclusionCreated)]
    [InlineData(EventCategory.IntrafiExclusionUpdated)]
    [InlineData(EventCategory.LockboxCreated)]
    [InlineData(EventCategory.LockboxUpdated)]
    [InlineData(EventCategory.OAuthConnectionCreated)]
    [InlineData(EventCategory.OAuthConnectionDeactivated)]
    [InlineData(EventCategory.CardPushTransferCreated)]
    [InlineData(EventCategory.CardPushTransferUpdated)]
    [InlineData(EventCategory.CardValidationCreated)]
    [InlineData(EventCategory.CardValidationUpdated)]
    [InlineData(EventCategory.PendingTransactionCreated)]
    [InlineData(EventCategory.PendingTransactionUpdated)]
    [InlineData(EventCategory.PhysicalCardCreated)]
    [InlineData(EventCategory.PhysicalCardUpdated)]
    [InlineData(EventCategory.PhysicalCardProfileCreated)]
    [InlineData(EventCategory.PhysicalCardProfileUpdated)]
    [InlineData(EventCategory.PhysicalCheckCreated)]
    [InlineData(EventCategory.PhysicalCheckUpdated)]
    [InlineData(EventCategory.ProgramCreated)]
    [InlineData(EventCategory.ProgramUpdated)]
    [InlineData(EventCategory.ProofOfAuthorizationRequestCreated)]
    [InlineData(EventCategory.ProofOfAuthorizationRequestUpdated)]
    [InlineData(EventCategory.RealTimeDecisionCardAuthorizationRequested)]
    [InlineData(EventCategory.RealTimeDecisionCardBalanceInquiryRequested)]
    [InlineData(EventCategory.RealTimeDecisionDigitalWalletTokenRequested)]
    [InlineData(EventCategory.RealTimeDecisionDigitalWalletAuthenticationRequested)]
    [InlineData(EventCategory.RealTimeDecisionCardAuthenticationRequested)]
    [InlineData(EventCategory.RealTimeDecisionCardAuthenticationChallengeRequested)]
    [InlineData(EventCategory.RealTimePaymentsTransferCreated)]
    [InlineData(EventCategory.RealTimePaymentsTransferUpdated)]
    [InlineData(EventCategory.RealTimePaymentsRequestForPaymentCreated)]
    [InlineData(EventCategory.RealTimePaymentsRequestForPaymentUpdated)]
    [InlineData(EventCategory.SwiftTransferCreated)]
    [InlineData(EventCategory.SwiftTransferUpdated)]
    [InlineData(EventCategory.TransactionCreated)]
    [InlineData(EventCategory.WireDrawdownRequestCreated)]
    [InlineData(EventCategory.WireDrawdownRequestUpdated)]
    [InlineData(EventCategory.WireTransferCreated)]
    [InlineData(EventCategory.WireTransferUpdated)]
    public void SerializationRoundtrip_Works(EventCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Disabled)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Disabled)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
