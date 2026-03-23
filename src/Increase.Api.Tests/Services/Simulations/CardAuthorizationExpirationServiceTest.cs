using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class CardAuthorizationExpirationServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var cardPayment = await this.client.Simulations.CardAuthorizationExpirations.Create(
            new() { CardPaymentID = "card_payment_nd3k2kacrqjli8482ave" },
            TestContext.Current.CancellationToken
        );
        cardPayment.Validate();
    }
}
