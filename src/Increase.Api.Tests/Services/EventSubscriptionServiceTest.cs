using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class EventSubscriptionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var eventSubscription = await this.client.EventSubscriptions.Create(
            new() { UrlValue = "https://website.com/webhooks" },
            TestContext.Current.CancellationToken
        );
        eventSubscription.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var eventSubscription = await this.client.EventSubscriptions.Retrieve(
            "event_subscription_001dzz0r20rcdxgb013zqb8m04g",
            new(),
            TestContext.Current.CancellationToken
        );
        eventSubscription.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var eventSubscription = await this.client.EventSubscriptions.Update(
            "event_subscription_001dzz0r20rcdxgb013zqb8m04g",
            new(),
            TestContext.Current.CancellationToken
        );
        eventSubscription.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.EventSubscriptions.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
