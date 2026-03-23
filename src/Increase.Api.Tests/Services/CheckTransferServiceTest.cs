using System.Threading.Tasks;
using Increase.Api.Models.CheckTransfers;

namespace Increase.Api.Tests.Services;

public class CheckTransferServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var checkTransfer = await this.client.CheckTransfers.Create(
            new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                Amount = 1000,
                FulfillmentMethod = FulfillmentMethod.PhysicalCheck,
                SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            },
            TestContext.Current.CancellationToken
        );
        checkTransfer.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var checkTransfer = await this.client.CheckTransfers.Retrieve(
            "check_transfer_30b43acfu9vw8fyc4f5",
            new(),
            TestContext.Current.CancellationToken
        );
        checkTransfer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.CheckTransfers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Approve_Works()
    {
        var checkTransfer = await this.client.CheckTransfers.Approve(
            "check_transfer_30b43acfu9vw8fyc4f5",
            new(),
            TestContext.Current.CancellationToken
        );
        checkTransfer.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var checkTransfer = await this.client.CheckTransfers.Cancel(
            "check_transfer_30b43acfu9vw8fyc4f5",
            new(),
            TestContext.Current.CancellationToken
        );
        checkTransfer.Validate();
    }

    [Fact]
    public async Task StopPayment_Works()
    {
        var checkTransfer = await this.client.CheckTransfers.StopPayment(
            "check_transfer_30b43acfu9vw8fyc4f5",
            new(),
            TestContext.Current.CancellationToken
        );
        checkTransfer.Validate();
    }
}
