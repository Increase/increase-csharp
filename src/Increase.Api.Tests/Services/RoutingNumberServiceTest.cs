using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class RoutingNumberServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.RoutingNumbers.List(
            new() { RoutingNumber = "483310694" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
