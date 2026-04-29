using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using EventSubscriptions = Increase.Api.Models.EventSubscriptions;

namespace Increase.Api.Tests.Models.EventSubscriptions;

public class EventSubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventSubscriptions::EventSubscription
        {
            ID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            OAuthConnectionID = null,
            SelectedEventCategories =
            [
                new(
                    EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated
                ),
            ],
            Status = EventSubscriptions::EventSubscriptionStatus.Active,
            Type = EventSubscriptions::Type.EventSubscription,
            Url = "https://website.com/webhooks",
        };

        string expectedID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        List<EventSubscriptions::EventSubscriptionSelectedEventCategory> expectedSelectedEventCategories =
        [
            new(
                EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated
            ),
        ];
        ApiEnum<string, EventSubscriptions::EventSubscriptionStatus> expectedStatus =
            EventSubscriptions::EventSubscriptionStatus.Active;
        ApiEnum<string, EventSubscriptions::Type> expectedType =
            EventSubscriptions::Type.EventSubscription;
        string expectedUrl = "https://website.com/webhooks";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Null(model.IdempotencyKey);
        Assert.Null(model.OAuthConnectionID);
        Assert.NotNull(model.SelectedEventCategories);
        Assert.Equal(expectedSelectedEventCategories.Count, model.SelectedEventCategories.Count);
        for (int i = 0; i < expectedSelectedEventCategories.Count; i++)
        {
            Assert.Equal(expectedSelectedEventCategories[i], model.SelectedEventCategories[i]);
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventSubscriptions::EventSubscription
        {
            ID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            OAuthConnectionID = null,
            SelectedEventCategories =
            [
                new(
                    EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated
                ),
            ],
            Status = EventSubscriptions::EventSubscriptionStatus.Active,
            Type = EventSubscriptions::Type.EventSubscription,
            Url = "https://website.com/webhooks",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventSubscriptions::EventSubscription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventSubscriptions::EventSubscription
        {
            ID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            OAuthConnectionID = null,
            SelectedEventCategories =
            [
                new(
                    EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated
                ),
            ],
            Status = EventSubscriptions::EventSubscriptionStatus.Active,
            Type = EventSubscriptions::Type.EventSubscription,
            Url = "https://website.com/webhooks",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventSubscriptions::EventSubscription>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        List<EventSubscriptions::EventSubscriptionSelectedEventCategory> expectedSelectedEventCategories =
        [
            new(
                EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated
            ),
        ];
        ApiEnum<string, EventSubscriptions::EventSubscriptionStatus> expectedStatus =
            EventSubscriptions::EventSubscriptionStatus.Active;
        ApiEnum<string, EventSubscriptions::Type> expectedType =
            EventSubscriptions::Type.EventSubscription;
        string expectedUrl = "https://website.com/webhooks";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Null(deserialized.OAuthConnectionID);
        Assert.NotNull(deserialized.SelectedEventCategories);
        Assert.Equal(
            expectedSelectedEventCategories.Count,
            deserialized.SelectedEventCategories.Count
        );
        for (int i = 0; i < expectedSelectedEventCategories.Count; i++)
        {
            Assert.Equal(
                expectedSelectedEventCategories[i],
                deserialized.SelectedEventCategories[i]
            );
        }
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventSubscriptions::EventSubscription
        {
            ID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            OAuthConnectionID = null,
            SelectedEventCategories =
            [
                new(
                    EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated
                ),
            ],
            Status = EventSubscriptions::EventSubscriptionStatus.Active,
            Type = EventSubscriptions::Type.EventSubscription,
            Url = "https://website.com/webhooks",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventSubscriptions::EventSubscription
        {
            ID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            OAuthConnectionID = null,
            SelectedEventCategories =
            [
                new(
                    EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated
                ),
            ],
            Status = EventSubscriptions::EventSubscriptionStatus.Active,
            Type = EventSubscriptions::Type.EventSubscription,
            Url = "https://website.com/webhooks",
        };

        EventSubscriptions::EventSubscription copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventSubscriptionSelectedEventCategoryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventSubscriptions::EventSubscriptionSelectedEventCategory
        {
            EventCategory =
                EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated,
        };

        ApiEnum<
            string,
            EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory
        > expectedEventCategory =
            EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated;

        Assert.Equal(expectedEventCategory, model.EventCategory);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventSubscriptions::EventSubscriptionSelectedEventCategory
        {
            EventCategory =
                EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EventSubscriptions::EventSubscriptionSelectedEventCategory>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventSubscriptions::EventSubscriptionSelectedEventCategory
        {
            EventCategory =
                EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EventSubscriptions::EventSubscriptionSelectedEventCategory>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory
        > expectedEventCategory =
            EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated;

        Assert.Equal(expectedEventCategory, deserialized.EventCategory);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventSubscriptions::EventSubscriptionSelectedEventCategory
        {
            EventCategory =
                EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventSubscriptions::EventSubscriptionSelectedEventCategory
        {
            EventCategory =
                EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated,
        };

        EventSubscriptions::EventSubscriptionSelectedEventCategory copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventSubscriptionSelectedEventCategoryEventCategoryTest : TestBase
{
    [Theory]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountNumberCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountNumberUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountStatementCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AchPrenotificationCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AchPrenotificationUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AchTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AchTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BlockchainAddressCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BlockchainAddressUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BlockchainOfframpTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BlockchainOfframpTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BlockchainOnrampTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BlockchainOnrampTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BookkeepingAccountCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BookkeepingAccountUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BookkeepingEntrySetUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardPaymentCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardPaymentUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardPurchaseSupplementCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardProfileCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardProfileUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardDisputeCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardDisputeUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CheckDepositCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CheckDepositUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CheckTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CheckTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.DeclinedTransactionCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.DigitalCardProfileCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.DigitalCardProfileUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.DigitalWalletTokenCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.DigitalWalletTokenUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.EntityCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.EntityUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.EventSubscriptionCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.EventSubscriptionUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.ExportCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.ExportUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.ExternalAccountCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.ExternalAccountUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.FednowTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.FednowTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.FileCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.GroupUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.GroupHeartbeat
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundAchTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundAchTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundAchTransferReturnCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundAchTransferReturnUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundCheckDepositCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundCheckDepositUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundFednowTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundFednowTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundMailItemCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundMailItemUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundRealTimePaymentsTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundRealTimePaymentsTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundWireDrawdownRequestCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundWireTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundWireTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.IntrafiAccountEnrollmentCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.IntrafiAccountEnrollmentUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.IntrafiExclusionCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.IntrafiExclusionUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.LockboxCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.LockboxUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.OAuthConnectionCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.OAuthConnectionDeactivated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardPushTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardPushTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardValidationCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardValidationUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.PendingTransactionCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.PendingTransactionUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCardCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCardUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCardProfileCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCardProfileUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCheckCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCheckUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.ProgramCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.ProgramUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.ProofOfAuthorizationRequestCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.ProofOfAuthorizationRequestUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionCardAuthorizationRequested
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionCardBalanceInquiryRequested
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionDigitalWalletTokenRequested
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionDigitalWalletAuthenticationRequested
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionCardAuthenticationRequested
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionCardAuthenticationChallengeRequested
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimePaymentsTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimePaymentsTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimePaymentsRequestForPaymentCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimePaymentsRequestForPaymentUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.SwiftTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.SwiftTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.TransactionCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.WireDrawdownRequestCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.WireDrawdownRequestUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.WireTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.WireTransferUpdated
    )]
    public void Validation_Works(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountNumberCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountNumberUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountStatementCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AccountTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AchPrenotificationCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AchPrenotificationUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AchTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.AchTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BlockchainAddressCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BlockchainAddressUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BlockchainOfframpTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BlockchainOfframpTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BlockchainOnrampTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BlockchainOnrampTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BookkeepingAccountCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BookkeepingAccountUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.BookkeepingEntrySetUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardPaymentCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardPaymentUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardPurchaseSupplementCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardProfileCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardProfileUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardDisputeCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardDisputeUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CheckDepositCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CheckDepositUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CheckTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CheckTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.DeclinedTransactionCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.DigitalCardProfileCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.DigitalCardProfileUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.DigitalWalletTokenCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.DigitalWalletTokenUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.EntityCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.EntityUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.EventSubscriptionCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.EventSubscriptionUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.ExportCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.ExportUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.ExternalAccountCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.ExternalAccountUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.FednowTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.FednowTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.FileCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.GroupUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.GroupHeartbeat
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundAchTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundAchTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundAchTransferReturnCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundAchTransferReturnUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundCheckDepositCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundCheckDepositUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundFednowTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundFednowTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundMailItemCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundMailItemUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundRealTimePaymentsTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundRealTimePaymentsTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundWireDrawdownRequestCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundWireTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.InboundWireTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.IntrafiAccountEnrollmentCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.IntrafiAccountEnrollmentUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.IntrafiExclusionCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.IntrafiExclusionUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.LockboxCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.LockboxUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.OAuthConnectionCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.OAuthConnectionDeactivated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardPushTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardPushTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardValidationCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.CardValidationUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.PendingTransactionCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.PendingTransactionUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCardCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCardUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCardProfileCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCardProfileUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCheckCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCheckUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.ProgramCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.ProgramUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.ProofOfAuthorizationRequestCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.ProofOfAuthorizationRequestUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionCardAuthorizationRequested
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionCardBalanceInquiryRequested
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionDigitalWalletTokenRequested
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionDigitalWalletAuthenticationRequested
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionCardAuthenticationRequested
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionCardAuthenticationChallengeRequested
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimePaymentsTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimePaymentsTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimePaymentsRequestForPaymentCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.RealTimePaymentsRequestForPaymentUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.SwiftTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.SwiftTransferUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.TransactionCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.WireDrawdownRequestCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.WireDrawdownRequestUpdated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.WireTransferCreated
    )]
    [InlineData(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory.WireTransferUpdated
    )]
    public void SerializationRoundtrip_Works(
        EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventSubscriptions::EventSubscriptionSelectedEventCategoryEventCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EventSubscriptionStatusTest : TestBase
{
    [Theory]
    [InlineData(EventSubscriptions::EventSubscriptionStatus.Active)]
    [InlineData(EventSubscriptions::EventSubscriptionStatus.Disabled)]
    [InlineData(EventSubscriptions::EventSubscriptionStatus.Deleted)]
    [InlineData(EventSubscriptions::EventSubscriptionStatus.RequiresAttention)]
    public void Validation_Works(EventSubscriptions::EventSubscriptionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventSubscriptions::EventSubscriptionStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EventSubscriptions::EventSubscriptionStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventSubscriptions::EventSubscriptionStatus.Active)]
    [InlineData(EventSubscriptions::EventSubscriptionStatus.Disabled)]
    [InlineData(EventSubscriptions::EventSubscriptionStatus.Deleted)]
    [InlineData(EventSubscriptions::EventSubscriptionStatus.RequiresAttention)]
    public void SerializationRoundtrip_Works(EventSubscriptions::EventSubscriptionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventSubscriptions::EventSubscriptionStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventSubscriptions::EventSubscriptionStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EventSubscriptions::EventSubscriptionStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventSubscriptions::EventSubscriptionStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(EventSubscriptions::Type.EventSubscription)]
    public void Validation_Works(EventSubscriptions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventSubscriptions::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventSubscriptions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventSubscriptions::Type.EventSubscription)]
    public void SerializationRoundtrip_Works(EventSubscriptions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventSubscriptions::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventSubscriptions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventSubscriptions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventSubscriptions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
