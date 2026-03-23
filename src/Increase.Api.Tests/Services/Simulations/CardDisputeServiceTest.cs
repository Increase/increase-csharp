using System.Threading.Tasks;
using Increase.Api.Models.Simulations.CardDisputes;

namespace Increase.Api.Tests.Services.Simulations;

public class CardDisputeServiceTest : TestBase
{
    [Fact]
    public async Task Action_Works()
    {
        var cardDispute = await this.client.Simulations.CardDisputes.Action(
            "card_dispute_h9sc95nbl1cgltpp7men",
            new() { Network = Network.Visa },
            TestContext.Current.CancellationToken
        );
        cardDispute.Validate();
    }
}
