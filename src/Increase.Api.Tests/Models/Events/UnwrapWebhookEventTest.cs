using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Events;

namespace Increase.Api.Tests.Models.Events;

public class UnwrapWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnwrapWebhookEvent
        {
            ID = "event_001dzz0r20rzr4zrhrr1364hy80",
            AssociatedObjectID = "account_in71c4amph0vgo2qllky",
            AssociatedObjectType = "account",
            Category = UnwrapWebhookEventCategory.AccountCreated,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = UnwrapWebhookEventType.Event,
        };

        string expectedID = "event_001dzz0r20rzr4zrhrr1364hy80";
        string expectedAssociatedObjectID = "account_in71c4amph0vgo2qllky";
        string expectedAssociatedObjectType = "account";
        ApiEnum<string, UnwrapWebhookEventCategory> expectedCategory =
            UnwrapWebhookEventCategory.AccountCreated;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, UnwrapWebhookEventType> expectedType = UnwrapWebhookEventType.Event;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAssociatedObjectID, model.AssociatedObjectID);
        Assert.Equal(expectedAssociatedObjectType, model.AssociatedObjectType);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnwrapWebhookEvent
        {
            ID = "event_001dzz0r20rzr4zrhrr1364hy80",
            AssociatedObjectID = "account_in71c4amph0vgo2qllky",
            AssociatedObjectType = "account",
            Category = UnwrapWebhookEventCategory.AccountCreated,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = UnwrapWebhookEventType.Event,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnwrapWebhookEvent
        {
            ID = "event_001dzz0r20rzr4zrhrr1364hy80",
            AssociatedObjectID = "account_in71c4amph0vgo2qllky",
            AssociatedObjectType = "account",
            Category = UnwrapWebhookEventCategory.AccountCreated,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = UnwrapWebhookEventType.Event,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "event_001dzz0r20rzr4zrhrr1364hy80";
        string expectedAssociatedObjectID = "account_in71c4amph0vgo2qllky";
        string expectedAssociatedObjectType = "account";
        ApiEnum<string, UnwrapWebhookEventCategory> expectedCategory =
            UnwrapWebhookEventCategory.AccountCreated;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, UnwrapWebhookEventType> expectedType = UnwrapWebhookEventType.Event;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAssociatedObjectID, deserialized.AssociatedObjectID);
        Assert.Equal(expectedAssociatedObjectType, deserialized.AssociatedObjectType);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnwrapWebhookEvent
        {
            ID = "event_001dzz0r20rzr4zrhrr1364hy80",
            AssociatedObjectID = "account_in71c4amph0vgo2qllky",
            AssociatedObjectType = "account",
            Category = UnwrapWebhookEventCategory.AccountCreated,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = UnwrapWebhookEventType.Event,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnwrapWebhookEvent
        {
            ID = "event_001dzz0r20rzr4zrhrr1364hy80",
            AssociatedObjectID = "account_in71c4amph0vgo2qllky",
            AssociatedObjectType = "account",
            Category = UnwrapWebhookEventCategory.AccountCreated,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = UnwrapWebhookEventType.Event,
        };

        UnwrapWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnwrapWebhookEventCategoryTest : TestBase
{
    [Theory]
    [InlineData(UnwrapWebhookEventCategory.AccountCreated)]
    [InlineData(UnwrapWebhookEventCategory.AccountUpdated)]
    [InlineData(UnwrapWebhookEventCategory.AccountNumberCreated)]
    [InlineData(UnwrapWebhookEventCategory.AccountNumberUpdated)]
    [InlineData(UnwrapWebhookEventCategory.AccountStatementCreated)]
    [InlineData(UnwrapWebhookEventCategory.AccountTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.AccountTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.AchPrenotificationCreated)]
    [InlineData(UnwrapWebhookEventCategory.AchPrenotificationUpdated)]
    [InlineData(UnwrapWebhookEventCategory.AchTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.AchTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.BlockchainAddressCreated)]
    [InlineData(UnwrapWebhookEventCategory.BlockchainAddressUpdated)]
    [InlineData(UnwrapWebhookEventCategory.BlockchainOfframpTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.BlockchainOfframpTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.BlockchainOnrampTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.BlockchainOnrampTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.BookkeepingAccountCreated)]
    [InlineData(UnwrapWebhookEventCategory.BookkeepingAccountUpdated)]
    [InlineData(UnwrapWebhookEventCategory.BookkeepingEntrySetUpdated)]
    [InlineData(UnwrapWebhookEventCategory.CardCreated)]
    [InlineData(UnwrapWebhookEventCategory.CardUpdated)]
    [InlineData(UnwrapWebhookEventCategory.CardPaymentCreated)]
    [InlineData(UnwrapWebhookEventCategory.CardPaymentUpdated)]
    [InlineData(UnwrapWebhookEventCategory.CardPurchaseSupplementCreated)]
    [InlineData(UnwrapWebhookEventCategory.CardProfileCreated)]
    [InlineData(UnwrapWebhookEventCategory.CardProfileUpdated)]
    [InlineData(UnwrapWebhookEventCategory.CardDisputeCreated)]
    [InlineData(UnwrapWebhookEventCategory.CardDisputeUpdated)]
    [InlineData(UnwrapWebhookEventCategory.CheckDepositCreated)]
    [InlineData(UnwrapWebhookEventCategory.CheckDepositUpdated)]
    [InlineData(UnwrapWebhookEventCategory.CheckTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.CheckTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.DeclinedTransactionCreated)]
    [InlineData(UnwrapWebhookEventCategory.DigitalCardProfileCreated)]
    [InlineData(UnwrapWebhookEventCategory.DigitalCardProfileUpdated)]
    [InlineData(UnwrapWebhookEventCategory.DigitalWalletTokenCreated)]
    [InlineData(UnwrapWebhookEventCategory.DigitalWalletTokenUpdated)]
    [InlineData(UnwrapWebhookEventCategory.DocumentCreated)]
    [InlineData(UnwrapWebhookEventCategory.EntityCreated)]
    [InlineData(UnwrapWebhookEventCategory.EntityUpdated)]
    [InlineData(UnwrapWebhookEventCategory.EventSubscriptionCreated)]
    [InlineData(UnwrapWebhookEventCategory.EventSubscriptionUpdated)]
    [InlineData(UnwrapWebhookEventCategory.ExportCreated)]
    [InlineData(UnwrapWebhookEventCategory.ExportUpdated)]
    [InlineData(UnwrapWebhookEventCategory.ExternalAccountCreated)]
    [InlineData(UnwrapWebhookEventCategory.ExternalAccountUpdated)]
    [InlineData(UnwrapWebhookEventCategory.FednowTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.FednowTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.FileCreated)]
    [InlineData(UnwrapWebhookEventCategory.GroupUpdated)]
    [InlineData(UnwrapWebhookEventCategory.GroupHeartbeat)]
    [InlineData(UnwrapWebhookEventCategory.InboundAchTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.InboundAchTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.InboundAchTransferReturnCreated)]
    [InlineData(UnwrapWebhookEventCategory.InboundAchTransferReturnUpdated)]
    [InlineData(UnwrapWebhookEventCategory.InboundCheckDepositCreated)]
    [InlineData(UnwrapWebhookEventCategory.InboundCheckDepositUpdated)]
    [InlineData(UnwrapWebhookEventCategory.InboundFednowTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.InboundFednowTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.InboundMailItemCreated)]
    [InlineData(UnwrapWebhookEventCategory.InboundMailItemUpdated)]
    [InlineData(UnwrapWebhookEventCategory.InboundRealTimePaymentsTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.InboundRealTimePaymentsTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.InboundWireDrawdownRequestCreated)]
    [InlineData(UnwrapWebhookEventCategory.InboundWireTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.InboundWireTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.IntrafiAccountEnrollmentCreated)]
    [InlineData(UnwrapWebhookEventCategory.IntrafiAccountEnrollmentUpdated)]
    [InlineData(UnwrapWebhookEventCategory.IntrafiExclusionCreated)]
    [InlineData(UnwrapWebhookEventCategory.IntrafiExclusionUpdated)]
    [InlineData(UnwrapWebhookEventCategory.LegacyCardDisputeCreated)]
    [InlineData(UnwrapWebhookEventCategory.LegacyCardDisputeUpdated)]
    [InlineData(UnwrapWebhookEventCategory.LockboxCreated)]
    [InlineData(UnwrapWebhookEventCategory.LockboxUpdated)]
    [InlineData(UnwrapWebhookEventCategory.OAuthConnectionCreated)]
    [InlineData(UnwrapWebhookEventCategory.OAuthConnectionDeactivated)]
    [InlineData(UnwrapWebhookEventCategory.CardPushTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.CardPushTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.CardValidationCreated)]
    [InlineData(UnwrapWebhookEventCategory.CardValidationUpdated)]
    [InlineData(UnwrapWebhookEventCategory.PendingTransactionCreated)]
    [InlineData(UnwrapWebhookEventCategory.PendingTransactionUpdated)]
    [InlineData(UnwrapWebhookEventCategory.PhysicalCardCreated)]
    [InlineData(UnwrapWebhookEventCategory.PhysicalCardUpdated)]
    [InlineData(UnwrapWebhookEventCategory.PhysicalCardProfileCreated)]
    [InlineData(UnwrapWebhookEventCategory.PhysicalCardProfileUpdated)]
    [InlineData(UnwrapWebhookEventCategory.PhysicalCheckCreated)]
    [InlineData(UnwrapWebhookEventCategory.PhysicalCheckUpdated)]
    [InlineData(UnwrapWebhookEventCategory.ProgramCreated)]
    [InlineData(UnwrapWebhookEventCategory.ProgramUpdated)]
    [InlineData(UnwrapWebhookEventCategory.ProofOfAuthorizationRequestCreated)]
    [InlineData(UnwrapWebhookEventCategory.ProofOfAuthorizationRequestUpdated)]
    [InlineData(UnwrapWebhookEventCategory.RealTimeDecisionCardAuthorizationRequested)]
    [InlineData(UnwrapWebhookEventCategory.RealTimeDecisionCardBalanceInquiryRequested)]
    [InlineData(UnwrapWebhookEventCategory.RealTimeDecisionDigitalWalletTokenRequested)]
    [InlineData(UnwrapWebhookEventCategory.RealTimeDecisionDigitalWalletAuthenticationRequested)]
    [InlineData(UnwrapWebhookEventCategory.RealTimeDecisionCardAuthenticationRequested)]
    [InlineData(UnwrapWebhookEventCategory.RealTimeDecisionCardAuthenticationChallengeRequested)]
    [InlineData(UnwrapWebhookEventCategory.RealTimePaymentsTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.RealTimePaymentsTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.RealTimePaymentsRequestForPaymentCreated)]
    [InlineData(UnwrapWebhookEventCategory.RealTimePaymentsRequestForPaymentUpdated)]
    [InlineData(UnwrapWebhookEventCategory.SwiftTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.SwiftTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.TransactionCreated)]
    [InlineData(UnwrapWebhookEventCategory.WireDrawdownRequestCreated)]
    [InlineData(UnwrapWebhookEventCategory.WireDrawdownRequestUpdated)]
    [InlineData(UnwrapWebhookEventCategory.WireTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.WireTransferUpdated)]
    public void Validation_Works(UnwrapWebhookEventCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnwrapWebhookEventCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnwrapWebhookEventCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnwrapWebhookEventCategory.AccountCreated)]
    [InlineData(UnwrapWebhookEventCategory.AccountUpdated)]
    [InlineData(UnwrapWebhookEventCategory.AccountNumberCreated)]
    [InlineData(UnwrapWebhookEventCategory.AccountNumberUpdated)]
    [InlineData(UnwrapWebhookEventCategory.AccountStatementCreated)]
    [InlineData(UnwrapWebhookEventCategory.AccountTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.AccountTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.AchPrenotificationCreated)]
    [InlineData(UnwrapWebhookEventCategory.AchPrenotificationUpdated)]
    [InlineData(UnwrapWebhookEventCategory.AchTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.AchTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.BlockchainAddressCreated)]
    [InlineData(UnwrapWebhookEventCategory.BlockchainAddressUpdated)]
    [InlineData(UnwrapWebhookEventCategory.BlockchainOfframpTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.BlockchainOfframpTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.BlockchainOnrampTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.BlockchainOnrampTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.BookkeepingAccountCreated)]
    [InlineData(UnwrapWebhookEventCategory.BookkeepingAccountUpdated)]
    [InlineData(UnwrapWebhookEventCategory.BookkeepingEntrySetUpdated)]
    [InlineData(UnwrapWebhookEventCategory.CardCreated)]
    [InlineData(UnwrapWebhookEventCategory.CardUpdated)]
    [InlineData(UnwrapWebhookEventCategory.CardPaymentCreated)]
    [InlineData(UnwrapWebhookEventCategory.CardPaymentUpdated)]
    [InlineData(UnwrapWebhookEventCategory.CardPurchaseSupplementCreated)]
    [InlineData(UnwrapWebhookEventCategory.CardProfileCreated)]
    [InlineData(UnwrapWebhookEventCategory.CardProfileUpdated)]
    [InlineData(UnwrapWebhookEventCategory.CardDisputeCreated)]
    [InlineData(UnwrapWebhookEventCategory.CardDisputeUpdated)]
    [InlineData(UnwrapWebhookEventCategory.CheckDepositCreated)]
    [InlineData(UnwrapWebhookEventCategory.CheckDepositUpdated)]
    [InlineData(UnwrapWebhookEventCategory.CheckTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.CheckTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.DeclinedTransactionCreated)]
    [InlineData(UnwrapWebhookEventCategory.DigitalCardProfileCreated)]
    [InlineData(UnwrapWebhookEventCategory.DigitalCardProfileUpdated)]
    [InlineData(UnwrapWebhookEventCategory.DigitalWalletTokenCreated)]
    [InlineData(UnwrapWebhookEventCategory.DigitalWalletTokenUpdated)]
    [InlineData(UnwrapWebhookEventCategory.DocumentCreated)]
    [InlineData(UnwrapWebhookEventCategory.EntityCreated)]
    [InlineData(UnwrapWebhookEventCategory.EntityUpdated)]
    [InlineData(UnwrapWebhookEventCategory.EventSubscriptionCreated)]
    [InlineData(UnwrapWebhookEventCategory.EventSubscriptionUpdated)]
    [InlineData(UnwrapWebhookEventCategory.ExportCreated)]
    [InlineData(UnwrapWebhookEventCategory.ExportUpdated)]
    [InlineData(UnwrapWebhookEventCategory.ExternalAccountCreated)]
    [InlineData(UnwrapWebhookEventCategory.ExternalAccountUpdated)]
    [InlineData(UnwrapWebhookEventCategory.FednowTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.FednowTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.FileCreated)]
    [InlineData(UnwrapWebhookEventCategory.GroupUpdated)]
    [InlineData(UnwrapWebhookEventCategory.GroupHeartbeat)]
    [InlineData(UnwrapWebhookEventCategory.InboundAchTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.InboundAchTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.InboundAchTransferReturnCreated)]
    [InlineData(UnwrapWebhookEventCategory.InboundAchTransferReturnUpdated)]
    [InlineData(UnwrapWebhookEventCategory.InboundCheckDepositCreated)]
    [InlineData(UnwrapWebhookEventCategory.InboundCheckDepositUpdated)]
    [InlineData(UnwrapWebhookEventCategory.InboundFednowTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.InboundFednowTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.InboundMailItemCreated)]
    [InlineData(UnwrapWebhookEventCategory.InboundMailItemUpdated)]
    [InlineData(UnwrapWebhookEventCategory.InboundRealTimePaymentsTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.InboundRealTimePaymentsTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.InboundWireDrawdownRequestCreated)]
    [InlineData(UnwrapWebhookEventCategory.InboundWireTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.InboundWireTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.IntrafiAccountEnrollmentCreated)]
    [InlineData(UnwrapWebhookEventCategory.IntrafiAccountEnrollmentUpdated)]
    [InlineData(UnwrapWebhookEventCategory.IntrafiExclusionCreated)]
    [InlineData(UnwrapWebhookEventCategory.IntrafiExclusionUpdated)]
    [InlineData(UnwrapWebhookEventCategory.LegacyCardDisputeCreated)]
    [InlineData(UnwrapWebhookEventCategory.LegacyCardDisputeUpdated)]
    [InlineData(UnwrapWebhookEventCategory.LockboxCreated)]
    [InlineData(UnwrapWebhookEventCategory.LockboxUpdated)]
    [InlineData(UnwrapWebhookEventCategory.OAuthConnectionCreated)]
    [InlineData(UnwrapWebhookEventCategory.OAuthConnectionDeactivated)]
    [InlineData(UnwrapWebhookEventCategory.CardPushTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.CardPushTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.CardValidationCreated)]
    [InlineData(UnwrapWebhookEventCategory.CardValidationUpdated)]
    [InlineData(UnwrapWebhookEventCategory.PendingTransactionCreated)]
    [InlineData(UnwrapWebhookEventCategory.PendingTransactionUpdated)]
    [InlineData(UnwrapWebhookEventCategory.PhysicalCardCreated)]
    [InlineData(UnwrapWebhookEventCategory.PhysicalCardUpdated)]
    [InlineData(UnwrapWebhookEventCategory.PhysicalCardProfileCreated)]
    [InlineData(UnwrapWebhookEventCategory.PhysicalCardProfileUpdated)]
    [InlineData(UnwrapWebhookEventCategory.PhysicalCheckCreated)]
    [InlineData(UnwrapWebhookEventCategory.PhysicalCheckUpdated)]
    [InlineData(UnwrapWebhookEventCategory.ProgramCreated)]
    [InlineData(UnwrapWebhookEventCategory.ProgramUpdated)]
    [InlineData(UnwrapWebhookEventCategory.ProofOfAuthorizationRequestCreated)]
    [InlineData(UnwrapWebhookEventCategory.ProofOfAuthorizationRequestUpdated)]
    [InlineData(UnwrapWebhookEventCategory.RealTimeDecisionCardAuthorizationRequested)]
    [InlineData(UnwrapWebhookEventCategory.RealTimeDecisionCardBalanceInquiryRequested)]
    [InlineData(UnwrapWebhookEventCategory.RealTimeDecisionDigitalWalletTokenRequested)]
    [InlineData(UnwrapWebhookEventCategory.RealTimeDecisionDigitalWalletAuthenticationRequested)]
    [InlineData(UnwrapWebhookEventCategory.RealTimeDecisionCardAuthenticationRequested)]
    [InlineData(UnwrapWebhookEventCategory.RealTimeDecisionCardAuthenticationChallengeRequested)]
    [InlineData(UnwrapWebhookEventCategory.RealTimePaymentsTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.RealTimePaymentsTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.RealTimePaymentsRequestForPaymentCreated)]
    [InlineData(UnwrapWebhookEventCategory.RealTimePaymentsRequestForPaymentUpdated)]
    [InlineData(UnwrapWebhookEventCategory.SwiftTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.SwiftTransferUpdated)]
    [InlineData(UnwrapWebhookEventCategory.TransactionCreated)]
    [InlineData(UnwrapWebhookEventCategory.WireDrawdownRequestCreated)]
    [InlineData(UnwrapWebhookEventCategory.WireDrawdownRequestUpdated)]
    [InlineData(UnwrapWebhookEventCategory.WireTransferCreated)]
    [InlineData(UnwrapWebhookEventCategory.WireTransferUpdated)]
    public void SerializationRoundtrip_Works(UnwrapWebhookEventCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnwrapWebhookEventCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnwrapWebhookEventCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnwrapWebhookEventCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnwrapWebhookEventCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnwrapWebhookEventTypeTest : TestBase
{
    [Theory]
    [InlineData(UnwrapWebhookEventType.Event)]
    public void Validation_Works(UnwrapWebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnwrapWebhookEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnwrapWebhookEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnwrapWebhookEventType.Event)]
    public void SerializationRoundtrip_Works(UnwrapWebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnwrapWebhookEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnwrapWebhookEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnwrapWebhookEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnwrapWebhookEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
