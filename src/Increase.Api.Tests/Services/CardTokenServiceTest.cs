using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class CardTokenServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var cardToken = await this.client.CardTokens.Retrieve(
            "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            new(),
            TestContext.Current.CancellationToken
        );
        cardToken.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.CardTokens.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Capabilities_Works()
    {
        var cardTokenCapabilities = await this.client.CardTokens.Capabilities(
            "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            new(),
            TestContext.Current.CancellationToken
        );
        cardTokenCapabilities.Validate();
    }
}
