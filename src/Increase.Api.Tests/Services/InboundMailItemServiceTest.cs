using System.Threading.Tasks;
using Increase.Api.Models.InboundMailItems;

namespace Increase.Api.Tests.Services;

public class InboundMailItemServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var inboundMailItem = await this.client.InboundMailItems.Retrieve(
            "inbound_mail_item_q6rrg7mmqpplx80zceev",
            new(),
            TestContext.Current.CancellationToken
        );
        inboundMailItem.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.InboundMailItems.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Action_Works()
    {
        var inboundMailItem = await this.client.InboundMailItems.Action(
            "inbound_mail_item_q6rrg7mmqpplx80zceev",
            new()
            {
                Checks =
                [
                    new() { Action = Action.Deposit, AccountID = "account_in71c4amph0vgo2qllky" },
                    new() { Action = Action.Ignore, AccountID = "account_id" },
                ],
            },
            TestContext.Current.CancellationToken
        );
        inboundMailItem.Validate();
    }
}
