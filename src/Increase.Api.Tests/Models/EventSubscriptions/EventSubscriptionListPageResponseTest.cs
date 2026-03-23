using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using EventSubscriptions = Increase.Api.Models.EventSubscriptions;

namespace Increase.Api.Tests.Models.EventSubscriptions;

public class EventSubscriptionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventSubscriptions::EventSubscriptionListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        List<EventSubscriptions::EventSubscription> expectedData =
        [
            new()
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
        var model = new EventSubscriptions::EventSubscriptionListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EventSubscriptions::EventSubscriptionListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventSubscriptions::EventSubscriptionListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EventSubscriptions::EventSubscriptionListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<EventSubscriptions::EventSubscription> expectedData =
        [
            new()
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
        var model = new EventSubscriptions::EventSubscriptionListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventSubscriptions::EventSubscriptionListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        EventSubscriptions::EventSubscriptionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
