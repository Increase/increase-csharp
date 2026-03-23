using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class DigitalWalletTokenServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var digitalWalletToken = await this.client.DigitalWalletTokens.Retrieve(
            "digital_wallet_token_izi62go3h51p369jrie0",
            new(),
            TestContext.Current.CancellationToken
        );
        digitalWalletToken.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.DigitalWalletTokens.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
