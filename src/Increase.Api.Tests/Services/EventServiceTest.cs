using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class EventServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var event_ = await this.client.Events.Retrieve(
            "event_001dzz0r20rzr4zrhrr1364hy80",
            new(),
            TestContext.Current.CancellationToken
        );
        event_.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Events.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
