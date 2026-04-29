using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Events = Increase.Api.Models.Events;

namespace Increase.Api.Tests.Models.Events;

public class EventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Events::Event
        {
            ID = "event_001dzz0r20rzr4zrhrr1364hy80",
            AssociatedObjectID = "account_in71c4amph0vgo2qllky",
            AssociatedObjectType = "account",
            Category = Events::EventCategory.AccountCreated,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = Events::Type.Event,
        };

        string expectedID = "event_001dzz0r20rzr4zrhrr1364hy80";
        string expectedAssociatedObjectID = "account_in71c4amph0vgo2qllky";
        string expectedAssociatedObjectType = "account";
        ApiEnum<string, Events::EventCategory> expectedCategory =
            Events::EventCategory.AccountCreated;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, Events::Type> expectedType = Events::Type.Event;

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
        var model = new Events::Event
        {
            ID = "event_001dzz0r20rzr4zrhrr1364hy80",
            AssociatedObjectID = "account_in71c4amph0vgo2qllky",
            AssociatedObjectType = "account",
            Category = Events::EventCategory.AccountCreated,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = Events::Type.Event,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::Event>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Events::Event
        {
            ID = "event_001dzz0r20rzr4zrhrr1364hy80",
            AssociatedObjectID = "account_in71c4amph0vgo2qllky",
            AssociatedObjectType = "account",
            Category = Events::EventCategory.AccountCreated,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = Events::Type.Event,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::Event>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "event_001dzz0r20rzr4zrhrr1364hy80";
        string expectedAssociatedObjectID = "account_in71c4amph0vgo2qllky";
        string expectedAssociatedObjectType = "account";
        ApiEnum<string, Events::EventCategory> expectedCategory =
            Events::EventCategory.AccountCreated;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, Events::Type> expectedType = Events::Type.Event;

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
        var model = new Events::Event
        {
            ID = "event_001dzz0r20rzr4zrhrr1364hy80",
            AssociatedObjectID = "account_in71c4amph0vgo2qllky",
            AssociatedObjectType = "account",
            Category = Events::EventCategory.AccountCreated,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = Events::Type.Event,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Events::Event
        {
            ID = "event_001dzz0r20rzr4zrhrr1364hy80",
            AssociatedObjectID = "account_in71c4amph0vgo2qllky",
            AssociatedObjectType = "account",
            Category = Events::EventCategory.AccountCreated,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = Events::Type.Event,
        };

        Events::Event copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventCategoryTest : TestBase
{
    [Theory]
    [InlineData(Events::EventCategory.AccountCreated)]
    [InlineData(Events::EventCategory.AccountUpdated)]
    [InlineData(Events::EventCategory.AccountNumberCreated)]
    [InlineData(Events::EventCategory.AccountNumberUpdated)]
    [InlineData(Events::EventCategory.AccountStatementCreated)]
    [InlineData(Events::EventCategory.AccountTransferCreated)]
    [InlineData(Events::EventCategory.AccountTransferUpdated)]
    [InlineData(Events::EventCategory.AchPrenotificationCreated)]
    [InlineData(Events::EventCategory.AchPrenotificationUpdated)]
    [InlineData(Events::EventCategory.AchTransferCreated)]
    [InlineData(Events::EventCategory.AchTransferUpdated)]
    [InlineData(Events::EventCategory.BlockchainAddressCreated)]
    [InlineData(Events::EventCategory.BlockchainAddressUpdated)]
    [InlineData(Events::EventCategory.BlockchainOfframpTransferCreated)]
    [InlineData(Events::EventCategory.BlockchainOfframpTransferUpdated)]
    [InlineData(Events::EventCategory.BlockchainOnrampTransferCreated)]
    [InlineData(Events::EventCategory.BlockchainOnrampTransferUpdated)]
    [InlineData(Events::EventCategory.BookkeepingAccountCreated)]
    [InlineData(Events::EventCategory.BookkeepingAccountUpdated)]
    [InlineData(Events::EventCategory.BookkeepingEntrySetUpdated)]
    [InlineData(Events::EventCategory.CardCreated)]
    [InlineData(Events::EventCategory.CardUpdated)]
    [InlineData(Events::EventCategory.CardPaymentCreated)]
    [InlineData(Events::EventCategory.CardPaymentUpdated)]
    [InlineData(Events::EventCategory.CardPurchaseSupplementCreated)]
    [InlineData(Events::EventCategory.CardProfileCreated)]
    [InlineData(Events::EventCategory.CardProfileUpdated)]
    [InlineData(Events::EventCategory.CardDisputeCreated)]
    [InlineData(Events::EventCategory.CardDisputeUpdated)]
    [InlineData(Events::EventCategory.CheckDepositCreated)]
    [InlineData(Events::EventCategory.CheckDepositUpdated)]
    [InlineData(Events::EventCategory.CheckTransferCreated)]
    [InlineData(Events::EventCategory.CheckTransferUpdated)]
    [InlineData(Events::EventCategory.DeclinedTransactionCreated)]
    [InlineData(Events::EventCategory.DigitalCardProfileCreated)]
    [InlineData(Events::EventCategory.DigitalCardProfileUpdated)]
    [InlineData(Events::EventCategory.DigitalWalletTokenCreated)]
    [InlineData(Events::EventCategory.DigitalWalletTokenUpdated)]
    [InlineData(Events::EventCategory.EntityCreated)]
    [InlineData(Events::EventCategory.EntityUpdated)]
    [InlineData(Events::EventCategory.EventSubscriptionCreated)]
    [InlineData(Events::EventCategory.EventSubscriptionUpdated)]
    [InlineData(Events::EventCategory.ExportCreated)]
    [InlineData(Events::EventCategory.ExportUpdated)]
    [InlineData(Events::EventCategory.ExternalAccountCreated)]
    [InlineData(Events::EventCategory.ExternalAccountUpdated)]
    [InlineData(Events::EventCategory.FednowTransferCreated)]
    [InlineData(Events::EventCategory.FednowTransferUpdated)]
    [InlineData(Events::EventCategory.FileCreated)]
    [InlineData(Events::EventCategory.GroupUpdated)]
    [InlineData(Events::EventCategory.GroupHeartbeat)]
    [InlineData(Events::EventCategory.InboundAchTransferCreated)]
    [InlineData(Events::EventCategory.InboundAchTransferUpdated)]
    [InlineData(Events::EventCategory.InboundAchTransferReturnCreated)]
    [InlineData(Events::EventCategory.InboundAchTransferReturnUpdated)]
    [InlineData(Events::EventCategory.InboundCheckDepositCreated)]
    [InlineData(Events::EventCategory.InboundCheckDepositUpdated)]
    [InlineData(Events::EventCategory.InboundFednowTransferCreated)]
    [InlineData(Events::EventCategory.InboundFednowTransferUpdated)]
    [InlineData(Events::EventCategory.InboundMailItemCreated)]
    [InlineData(Events::EventCategory.InboundMailItemUpdated)]
    [InlineData(Events::EventCategory.InboundRealTimePaymentsTransferCreated)]
    [InlineData(Events::EventCategory.InboundRealTimePaymentsTransferUpdated)]
    [InlineData(Events::EventCategory.InboundWireDrawdownRequestCreated)]
    [InlineData(Events::EventCategory.InboundWireTransferCreated)]
    [InlineData(Events::EventCategory.InboundWireTransferUpdated)]
    [InlineData(Events::EventCategory.IntrafiAccountEnrollmentCreated)]
    [InlineData(Events::EventCategory.IntrafiAccountEnrollmentUpdated)]
    [InlineData(Events::EventCategory.IntrafiExclusionCreated)]
    [InlineData(Events::EventCategory.IntrafiExclusionUpdated)]
    [InlineData(Events::EventCategory.LockboxCreated)]
    [InlineData(Events::EventCategory.LockboxUpdated)]
    [InlineData(Events::EventCategory.OAuthConnectionCreated)]
    [InlineData(Events::EventCategory.OAuthConnectionDeactivated)]
    [InlineData(Events::EventCategory.CardPushTransferCreated)]
    [InlineData(Events::EventCategory.CardPushTransferUpdated)]
    [InlineData(Events::EventCategory.CardValidationCreated)]
    [InlineData(Events::EventCategory.CardValidationUpdated)]
    [InlineData(Events::EventCategory.PendingTransactionCreated)]
    [InlineData(Events::EventCategory.PendingTransactionUpdated)]
    [InlineData(Events::EventCategory.PhysicalCardCreated)]
    [InlineData(Events::EventCategory.PhysicalCardUpdated)]
    [InlineData(Events::EventCategory.PhysicalCardProfileCreated)]
    [InlineData(Events::EventCategory.PhysicalCardProfileUpdated)]
    [InlineData(Events::EventCategory.PhysicalCheckCreated)]
    [InlineData(Events::EventCategory.PhysicalCheckUpdated)]
    [InlineData(Events::EventCategory.ProgramCreated)]
    [InlineData(Events::EventCategory.ProgramUpdated)]
    [InlineData(Events::EventCategory.ProofOfAuthorizationRequestCreated)]
    [InlineData(Events::EventCategory.ProofOfAuthorizationRequestUpdated)]
    [InlineData(Events::EventCategory.RealTimeDecisionCardAuthorizationRequested)]
    [InlineData(Events::EventCategory.RealTimeDecisionCardBalanceInquiryRequested)]
    [InlineData(Events::EventCategory.RealTimeDecisionDigitalWalletTokenRequested)]
    [InlineData(Events::EventCategory.RealTimeDecisionDigitalWalletAuthenticationRequested)]
    [InlineData(Events::EventCategory.RealTimeDecisionCardAuthenticationRequested)]
    [InlineData(Events::EventCategory.RealTimeDecisionCardAuthenticationChallengeRequested)]
    [InlineData(Events::EventCategory.RealTimePaymentsTransferCreated)]
    [InlineData(Events::EventCategory.RealTimePaymentsTransferUpdated)]
    [InlineData(Events::EventCategory.RealTimePaymentsRequestForPaymentCreated)]
    [InlineData(Events::EventCategory.RealTimePaymentsRequestForPaymentUpdated)]
    [InlineData(Events::EventCategory.SwiftTransferCreated)]
    [InlineData(Events::EventCategory.SwiftTransferUpdated)]
    [InlineData(Events::EventCategory.TransactionCreated)]
    [InlineData(Events::EventCategory.WireDrawdownRequestCreated)]
    [InlineData(Events::EventCategory.WireDrawdownRequestUpdated)]
    [InlineData(Events::EventCategory.WireTransferCreated)]
    [InlineData(Events::EventCategory.WireTransferUpdated)]
    public void Validation_Works(Events::EventCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Events::EventCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Events::EventCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Events::EventCategory.AccountCreated)]
    [InlineData(Events::EventCategory.AccountUpdated)]
    [InlineData(Events::EventCategory.AccountNumberCreated)]
    [InlineData(Events::EventCategory.AccountNumberUpdated)]
    [InlineData(Events::EventCategory.AccountStatementCreated)]
    [InlineData(Events::EventCategory.AccountTransferCreated)]
    [InlineData(Events::EventCategory.AccountTransferUpdated)]
    [InlineData(Events::EventCategory.AchPrenotificationCreated)]
    [InlineData(Events::EventCategory.AchPrenotificationUpdated)]
    [InlineData(Events::EventCategory.AchTransferCreated)]
    [InlineData(Events::EventCategory.AchTransferUpdated)]
    [InlineData(Events::EventCategory.BlockchainAddressCreated)]
    [InlineData(Events::EventCategory.BlockchainAddressUpdated)]
    [InlineData(Events::EventCategory.BlockchainOfframpTransferCreated)]
    [InlineData(Events::EventCategory.BlockchainOfframpTransferUpdated)]
    [InlineData(Events::EventCategory.BlockchainOnrampTransferCreated)]
    [InlineData(Events::EventCategory.BlockchainOnrampTransferUpdated)]
    [InlineData(Events::EventCategory.BookkeepingAccountCreated)]
    [InlineData(Events::EventCategory.BookkeepingAccountUpdated)]
    [InlineData(Events::EventCategory.BookkeepingEntrySetUpdated)]
    [InlineData(Events::EventCategory.CardCreated)]
    [InlineData(Events::EventCategory.CardUpdated)]
    [InlineData(Events::EventCategory.CardPaymentCreated)]
    [InlineData(Events::EventCategory.CardPaymentUpdated)]
    [InlineData(Events::EventCategory.CardPurchaseSupplementCreated)]
    [InlineData(Events::EventCategory.CardProfileCreated)]
    [InlineData(Events::EventCategory.CardProfileUpdated)]
    [InlineData(Events::EventCategory.CardDisputeCreated)]
    [InlineData(Events::EventCategory.CardDisputeUpdated)]
    [InlineData(Events::EventCategory.CheckDepositCreated)]
    [InlineData(Events::EventCategory.CheckDepositUpdated)]
    [InlineData(Events::EventCategory.CheckTransferCreated)]
    [InlineData(Events::EventCategory.CheckTransferUpdated)]
    [InlineData(Events::EventCategory.DeclinedTransactionCreated)]
    [InlineData(Events::EventCategory.DigitalCardProfileCreated)]
    [InlineData(Events::EventCategory.DigitalCardProfileUpdated)]
    [InlineData(Events::EventCategory.DigitalWalletTokenCreated)]
    [InlineData(Events::EventCategory.DigitalWalletTokenUpdated)]
    [InlineData(Events::EventCategory.EntityCreated)]
    [InlineData(Events::EventCategory.EntityUpdated)]
    [InlineData(Events::EventCategory.EventSubscriptionCreated)]
    [InlineData(Events::EventCategory.EventSubscriptionUpdated)]
    [InlineData(Events::EventCategory.ExportCreated)]
    [InlineData(Events::EventCategory.ExportUpdated)]
    [InlineData(Events::EventCategory.ExternalAccountCreated)]
    [InlineData(Events::EventCategory.ExternalAccountUpdated)]
    [InlineData(Events::EventCategory.FednowTransferCreated)]
    [InlineData(Events::EventCategory.FednowTransferUpdated)]
    [InlineData(Events::EventCategory.FileCreated)]
    [InlineData(Events::EventCategory.GroupUpdated)]
    [InlineData(Events::EventCategory.GroupHeartbeat)]
    [InlineData(Events::EventCategory.InboundAchTransferCreated)]
    [InlineData(Events::EventCategory.InboundAchTransferUpdated)]
    [InlineData(Events::EventCategory.InboundAchTransferReturnCreated)]
    [InlineData(Events::EventCategory.InboundAchTransferReturnUpdated)]
    [InlineData(Events::EventCategory.InboundCheckDepositCreated)]
    [InlineData(Events::EventCategory.InboundCheckDepositUpdated)]
    [InlineData(Events::EventCategory.InboundFednowTransferCreated)]
    [InlineData(Events::EventCategory.InboundFednowTransferUpdated)]
    [InlineData(Events::EventCategory.InboundMailItemCreated)]
    [InlineData(Events::EventCategory.InboundMailItemUpdated)]
    [InlineData(Events::EventCategory.InboundRealTimePaymentsTransferCreated)]
    [InlineData(Events::EventCategory.InboundRealTimePaymentsTransferUpdated)]
    [InlineData(Events::EventCategory.InboundWireDrawdownRequestCreated)]
    [InlineData(Events::EventCategory.InboundWireTransferCreated)]
    [InlineData(Events::EventCategory.InboundWireTransferUpdated)]
    [InlineData(Events::EventCategory.IntrafiAccountEnrollmentCreated)]
    [InlineData(Events::EventCategory.IntrafiAccountEnrollmentUpdated)]
    [InlineData(Events::EventCategory.IntrafiExclusionCreated)]
    [InlineData(Events::EventCategory.IntrafiExclusionUpdated)]
    [InlineData(Events::EventCategory.LockboxCreated)]
    [InlineData(Events::EventCategory.LockboxUpdated)]
    [InlineData(Events::EventCategory.OAuthConnectionCreated)]
    [InlineData(Events::EventCategory.OAuthConnectionDeactivated)]
    [InlineData(Events::EventCategory.CardPushTransferCreated)]
    [InlineData(Events::EventCategory.CardPushTransferUpdated)]
    [InlineData(Events::EventCategory.CardValidationCreated)]
    [InlineData(Events::EventCategory.CardValidationUpdated)]
    [InlineData(Events::EventCategory.PendingTransactionCreated)]
    [InlineData(Events::EventCategory.PendingTransactionUpdated)]
    [InlineData(Events::EventCategory.PhysicalCardCreated)]
    [InlineData(Events::EventCategory.PhysicalCardUpdated)]
    [InlineData(Events::EventCategory.PhysicalCardProfileCreated)]
    [InlineData(Events::EventCategory.PhysicalCardProfileUpdated)]
    [InlineData(Events::EventCategory.PhysicalCheckCreated)]
    [InlineData(Events::EventCategory.PhysicalCheckUpdated)]
    [InlineData(Events::EventCategory.ProgramCreated)]
    [InlineData(Events::EventCategory.ProgramUpdated)]
    [InlineData(Events::EventCategory.ProofOfAuthorizationRequestCreated)]
    [InlineData(Events::EventCategory.ProofOfAuthorizationRequestUpdated)]
    [InlineData(Events::EventCategory.RealTimeDecisionCardAuthorizationRequested)]
    [InlineData(Events::EventCategory.RealTimeDecisionCardBalanceInquiryRequested)]
    [InlineData(Events::EventCategory.RealTimeDecisionDigitalWalletTokenRequested)]
    [InlineData(Events::EventCategory.RealTimeDecisionDigitalWalletAuthenticationRequested)]
    [InlineData(Events::EventCategory.RealTimeDecisionCardAuthenticationRequested)]
    [InlineData(Events::EventCategory.RealTimeDecisionCardAuthenticationChallengeRequested)]
    [InlineData(Events::EventCategory.RealTimePaymentsTransferCreated)]
    [InlineData(Events::EventCategory.RealTimePaymentsTransferUpdated)]
    [InlineData(Events::EventCategory.RealTimePaymentsRequestForPaymentCreated)]
    [InlineData(Events::EventCategory.RealTimePaymentsRequestForPaymentUpdated)]
    [InlineData(Events::EventCategory.SwiftTransferCreated)]
    [InlineData(Events::EventCategory.SwiftTransferUpdated)]
    [InlineData(Events::EventCategory.TransactionCreated)]
    [InlineData(Events::EventCategory.WireDrawdownRequestCreated)]
    [InlineData(Events::EventCategory.WireDrawdownRequestUpdated)]
    [InlineData(Events::EventCategory.WireTransferCreated)]
    [InlineData(Events::EventCategory.WireTransferUpdated)]
    public void SerializationRoundtrip_Works(Events::EventCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Events::EventCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Events::EventCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Events::EventCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Events::EventCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Events::Type.Event)]
    public void Validation_Works(Events::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Events::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Events::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Events::Type.Event)]
    public void SerializationRoundtrip_Works(Events::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Events::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Events::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Events::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Events::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
