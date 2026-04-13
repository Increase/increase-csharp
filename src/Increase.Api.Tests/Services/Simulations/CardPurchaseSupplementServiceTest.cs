using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class CardPurchaseSupplementServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var cardPurchaseSupplement = await this.client.Simulations.CardPurchaseSupplements.Create(
            new() { TransactionID = "transaction_uyrp7fld2ium70oa7oi" },
            TestContext.Current.CancellationToken
        );
        cardPurchaseSupplement.Validate();
    }
}
