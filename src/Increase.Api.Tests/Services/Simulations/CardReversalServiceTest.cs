using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class CardReversalServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var cardPayment = await this.client.Simulations.CardReversals.Create(
            new() { CardPaymentID = "card_payment_nd3k2kacrqjli8482ave" },
            TestContext.Current.CancellationToken
        );
        cardPayment.Validate();
    }
}
