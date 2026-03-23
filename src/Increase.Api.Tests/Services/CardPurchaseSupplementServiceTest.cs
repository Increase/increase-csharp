using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class CardPurchaseSupplementServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var cardPurchaseSupplement = await this.client.CardPurchaseSupplements.Retrieve(
            "card_purchase_supplement_ijuc45iym4jchnh2sfk3",
            new(),
            TestContext.Current.CancellationToken
        );
        cardPurchaseSupplement.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.CardPurchaseSupplements.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
