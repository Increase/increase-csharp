using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class IntrafiBalanceServiceTest : TestBase
{
    [Fact]
    public async Task IntrafiBalance_Works()
    {
        var intrafiBalance = await this.client.IntrafiBalances.IntrafiBalance(
            "account_in71c4amph0vgo2qllky",
            new(),
            TestContext.Current.CancellationToken
        );
        intrafiBalance.Validate();
    }
}
