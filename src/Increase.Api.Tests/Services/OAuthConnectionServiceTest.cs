using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class OAuthConnectionServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var oauthConnection = await this.client.OAuthConnections.Retrieve(
            "connection_dauknoksyr4wilz4e6my",
            new(),
            TestContext.Current.CancellationToken
        );
        oauthConnection.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.OAuthConnections.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
