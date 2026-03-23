using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.EventSubscriptions;

namespace Increase.Api.Tests.Models.EventSubscriptions;

public class EventSubscriptionUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventSubscriptionUpdateParams
        {
            EventSubscriptionID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g",
            Status = EventSubscriptionUpdateParamsStatus.Active,
        };

        string expectedEventSubscriptionID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g";
        ApiEnum<string, EventSubscriptionUpdateParamsStatus> expectedStatus =
            EventSubscriptionUpdateParamsStatus.Active;

        Assert.Equal(expectedEventSubscriptionID, parameters.EventSubscriptionID);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EventSubscriptionUpdateParams
        {
            EventSubscriptionID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g",
        };

        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EventSubscriptionUpdateParams
        {
            EventSubscriptionID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g",

            // Null should be interpreted as omitted for these properties
            Status = null,
        };

        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        EventSubscriptionUpdateParams parameters = new()
        {
            EventSubscriptionID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/event_subscriptions/event_subscription_001dzz0r20rcdxgb013zqb8m04g"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EventSubscriptionUpdateParams
        {
            EventSubscriptionID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g",
            Status = EventSubscriptionUpdateParamsStatus.Active,
        };

        EventSubscriptionUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EventSubscriptionUpdateParamsStatusTest : TestBase
{
    [Theory]
    [InlineData(EventSubscriptionUpdateParamsStatus.Active)]
    [InlineData(EventSubscriptionUpdateParamsStatus.Disabled)]
    [InlineData(EventSubscriptionUpdateParamsStatus.Deleted)]
    public void Validation_Works(EventSubscriptionUpdateParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventSubscriptionUpdateParamsStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EventSubscriptionUpdateParamsStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventSubscriptionUpdateParamsStatus.Active)]
    [InlineData(EventSubscriptionUpdateParamsStatus.Disabled)]
    [InlineData(EventSubscriptionUpdateParamsStatus.Deleted)]
    public void SerializationRoundtrip_Works(EventSubscriptionUpdateParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventSubscriptionUpdateParamsStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventSubscriptionUpdateParamsStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EventSubscriptionUpdateParamsStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventSubscriptionUpdateParamsStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
