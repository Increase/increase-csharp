using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class CardTokenServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var cardToken = await this.client.Simulations.CardTokens.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        cardToken.Validate();
    }
}
