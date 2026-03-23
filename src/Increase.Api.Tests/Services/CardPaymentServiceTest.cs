using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class CardPaymentServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var cardPayment = await this.client.CardPayments.Retrieve(
            "card_payment_nd3k2kacrqjli8482ave",
            new(),
            TestContext.Current.CancellationToken
        );
        cardPayment.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.CardPayments.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
