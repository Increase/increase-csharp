using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class AccountRevenuePaymentServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var transaction = await this.client.Simulations.AccountRevenuePayments.Create(
            new() { AccountID = "account_in71c4amph0vgo2qllky", Amount = 1000 },
            TestContext.Current.CancellationToken
        );
        transaction.Validate();
    }
}
