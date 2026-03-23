using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class CheckDepositServiceTest : TestBase
{
    [Fact]
    public async Task Adjustment_Works()
    {
        var checkDeposit = await this.client.Simulations.CheckDeposits.Adjustment(
            "check_deposit_f06n9gpg7sxn8t19lfc1",
            new(),
            TestContext.Current.CancellationToken
        );
        checkDeposit.Validate();
    }

    [Fact]
    public async Task Reject_Works()
    {
        var checkDeposit = await this.client.Simulations.CheckDeposits.Reject(
            "check_deposit_f06n9gpg7sxn8t19lfc1",
            new(),
            TestContext.Current.CancellationToken
        );
        checkDeposit.Validate();
    }

    [Fact]
    public async Task Return_Works()
    {
        var checkDeposit = await this.client.Simulations.CheckDeposits.Return(
            "check_deposit_f06n9gpg7sxn8t19lfc1",
            new(),
            TestContext.Current.CancellationToken
        );
        checkDeposit.Validate();
    }

    [Fact]
    public async Task Submit_Works()
    {
        var checkDeposit = await this.client.Simulations.CheckDeposits.Submit(
            "check_deposit_f06n9gpg7sxn8t19lfc1",
            new(),
            TestContext.Current.CancellationToken
        );
        checkDeposit.Validate();
    }
}
