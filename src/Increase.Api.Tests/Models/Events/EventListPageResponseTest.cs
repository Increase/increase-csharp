using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Events = Increase.Api.Models.Events;

namespace Increase.Api.Tests.Models.Events;

public class EventListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Events::EventListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "event_001dzz0r20rzr4zrhrr1364hy80",
                    AssociatedObjectID = "account_in71c4amph0vgo2qllky",
                    AssociatedObjectType = "account",
                    Category = Events::EventCategory.AccountCreated,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Type = Events::Type.Event,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<Events::Event> expectedData =
        [
            new()
            {
                ID = "event_001dzz0r20rzr4zrhrr1364hy80",
                AssociatedObjectID = "account_in71c4amph0vgo2qllky",
                AssociatedObjectType = "account",
                Category = Events::EventCategory.AccountCreated,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Type = Events::Type.Event,
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
        var model = new Events::EventListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "event_001dzz0r20rzr4zrhrr1364hy80",
                    AssociatedObjectID = "account_in71c4amph0vgo2qllky",
                    AssociatedObjectType = "account",
                    Category = Events::EventCategory.AccountCreated,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Type = Events::Type.Event,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::EventListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Events::EventListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "event_001dzz0r20rzr4zrhrr1364hy80",
                    AssociatedObjectID = "account_in71c4amph0vgo2qllky",
                    AssociatedObjectType = "account",
                    Category = Events::EventCategory.AccountCreated,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Type = Events::Type.Event,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::EventListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Events::Event> expectedData =
        [
            new()
            {
                ID = "event_001dzz0r20rzr4zrhrr1364hy80",
                AssociatedObjectID = "account_in71c4amph0vgo2qllky",
                AssociatedObjectType = "account",
                Category = Events::EventCategory.AccountCreated,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Type = Events::Type.Event,
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
        var model = new Events::EventListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "event_001dzz0r20rzr4zrhrr1364hy80",
                    AssociatedObjectID = "account_in71c4amph0vgo2qllky",
                    AssociatedObjectType = "account",
                    Category = Events::EventCategory.AccountCreated,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Type = Events::Type.Event,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Events::EventListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "event_001dzz0r20rzr4zrhrr1364hy80",
                    AssociatedObjectID = "account_in71c4amph0vgo2qllky",
                    AssociatedObjectType = "account",
                    Category = Events::EventCategory.AccountCreated,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Type = Events::Type.Event,
                },
            ],
            NextCursor = "v57w5d",
        };

        Events::EventListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
