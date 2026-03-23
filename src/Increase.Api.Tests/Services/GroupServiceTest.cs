using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class GroupServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var group = await this.client.Groups.Retrieve(new(), TestContext.Current.CancellationToken);
        group.Validate();
    }
}
