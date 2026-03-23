using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class DigitalWalletTokenRequestServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var digitalWalletTokenRequest =
            await this.client.Simulations.DigitalWalletTokenRequests.Create(
                new() { CardID = "card_oubs0hwk5rn6knuecxg2" },
                TestContext.Current.CancellationToken
            );
        digitalWalletTokenRequest.Validate();
    }
}
