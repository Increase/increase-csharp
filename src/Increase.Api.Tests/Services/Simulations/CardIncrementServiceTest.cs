using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class CardIncrementServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var cardPayment = await this.client.Simulations.CardIncrements.Create(
            new() { Amount = 500, CardPaymentID = "card_payment_nd3k2kacrqjli8482ave" },
            TestContext.Current.CancellationToken
        );
        cardPayment.Validate();
    }
}
