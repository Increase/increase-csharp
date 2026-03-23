using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class CardAuthorizationServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var cardAuthorization = await this.client.Simulations.CardAuthorizations.Create(
            new() { Amount = 1000 },
            TestContext.Current.CancellationToken
        );
        cardAuthorization.Validate();
    }
}
