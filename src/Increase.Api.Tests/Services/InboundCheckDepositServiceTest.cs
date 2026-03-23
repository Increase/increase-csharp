using System.Threading.Tasks;
using Increase.Api.Models.InboundCheckDeposits;

namespace Increase.Api.Tests.Services;

public class InboundCheckDepositServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var inboundCheckDeposit = await this.client.InboundCheckDeposits.Retrieve(
            "inbound_check_deposit_zoshvqybq0cjjm31mra",
            new(),
            TestContext.Current.CancellationToken
        );
        inboundCheckDeposit.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.InboundCheckDeposits.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Decline_Works()
    {
        var inboundCheckDeposit = await this.client.InboundCheckDeposits.Decline(
            "inbound_check_deposit_zoshvqybq0cjjm31mra",
            new(),
            TestContext.Current.CancellationToken
        );
        inboundCheckDeposit.Validate();
    }

    [Fact]
    public async Task Return_Works()
    {
        var inboundCheckDeposit = await this.client.InboundCheckDeposits.Return(
            "inbound_check_deposit_zoshvqybq0cjjm31mra",
            new() { Reason = Reason.AlteredOrFictitious },
            TestContext.Current.CancellationToken
        );
        inboundCheckDeposit.Validate();
    }
}
