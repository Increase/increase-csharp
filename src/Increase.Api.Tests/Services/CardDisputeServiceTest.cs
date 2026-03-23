using System.Threading.Tasks;
using Increase.Api.Models.CardDisputes;

namespace Increase.Api.Tests.Services;

public class CardDisputeServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var cardDispute = await this.client.CardDisputes.Create(
            new()
            {
                DisputedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                Network = Network.Visa,
            },
            TestContext.Current.CancellationToken
        );
        cardDispute.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var cardDispute = await this.client.CardDisputes.Retrieve(
            "card_dispute_h9sc95nbl1cgltpp7men",
            new(),
            TestContext.Current.CancellationToken
        );
        cardDispute.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.CardDisputes.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task SubmitUserSubmission_Works()
    {
        var cardDispute = await this.client.CardDisputes.SubmitUserSubmission(
            "card_dispute_h9sc95nbl1cgltpp7men",
            new() { Network = CardDisputeSubmitUserSubmissionParamsNetwork.Visa },
            TestContext.Current.CancellationToken
        );
        cardDispute.Validate();
    }

    [Fact]
    public async Task Withdraw_Works()
    {
        var cardDispute = await this.client.CardDisputes.Withdraw(
            "card_dispute_h9sc95nbl1cgltpp7men",
            new(),
            TestContext.Current.CancellationToken
        );
        cardDispute.Validate();
    }
}
