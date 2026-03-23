using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class CardRefundServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var transaction = await this.client.Simulations.CardRefunds.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        transaction.Validate();
    }
}
