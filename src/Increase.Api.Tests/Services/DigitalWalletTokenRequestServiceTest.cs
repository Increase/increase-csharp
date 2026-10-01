using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class DigitalWalletTokenRequestServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var digitalWalletTokenRequest = await this.client.DigitalWalletTokenRequests.Retrieve(
            "digital_wallet_token_request_dlsq0yabf7ev4xvke6ek",
            new(),
            TestContext.Current.CancellationToken
        );
        digitalWalletTokenRequest.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.DigitalWalletTokenRequests.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
