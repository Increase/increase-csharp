using System;
using Increase.Api.Models.Events;

namespace Increase.Api.Tests.Models.Events;

public class EventRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventRetrieveParams { EventID = "event_001dzz0r20rzr4zrhrr1364hy80" };

        string expectedEventID = "event_001dzz0r20rzr4zrhrr1364hy80";

        Assert.Equal(expectedEventID, parameters.EventID);
    }

    [Fact]
    public void Url_Works()
    {
        EventRetrieveParams parameters = new() { EventID = "event_001dzz0r20rzr4zrhrr1364hy80" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.increase.com/events/event_001dzz0r20rzr4zrhrr1364hy80"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EventRetrieveParams { EventID = "event_001dzz0r20rzr4zrhrr1364hy80" };

        EventRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
