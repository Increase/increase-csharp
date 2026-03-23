using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class CardBalanceInquiryServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var cardPayment = await this.client.Simulations.CardBalanceInquiries.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        cardPayment.Validate();
    }
}
