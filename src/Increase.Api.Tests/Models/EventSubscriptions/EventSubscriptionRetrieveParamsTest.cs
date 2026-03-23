using System;
using Increase.Api.Models.EventSubscriptions;

namespace Increase.Api.Tests.Models.EventSubscriptions;

public class EventSubscriptionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventSubscriptionRetrieveParams
        {
            EventSubscriptionID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g",
        };

        string expectedEventSubscriptionID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g";

        Assert.Equal(expectedEventSubscriptionID, parameters.EventSubscriptionID);
    }

    [Fact]
    public void Url_Works()
    {
        EventSubscriptionRetrieveParams parameters = new()
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
        var parameters = new EventSubscriptionRetrieveParams
        {
            EventSubscriptionID = "event_subscription_001dzz0r20rcdxgb013zqb8m04g",
        };

        EventSubscriptionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
