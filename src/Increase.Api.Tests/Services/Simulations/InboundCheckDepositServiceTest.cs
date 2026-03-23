using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class InboundCheckDepositServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var inboundCheckDeposit = await this.client.Simulations.InboundCheckDeposits.Create(
            new()
            {
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Amount = 1000,
                CheckNumber = "1234567890",
            },
            TestContext.Current.CancellationToken
        );
        inboundCheckDeposit.Validate();
    }

    [Fact]
    public async Task Adjustment_Works()
    {
        var inboundCheckDeposit = await this.client.Simulations.InboundCheckDeposits.Adjustment(
            "inbound_check_deposit_zoshvqybq0cjjm31mra",
            new(),
            TestContext.Current.CancellationToken
        );
        inboundCheckDeposit.Validate();
    }
}
