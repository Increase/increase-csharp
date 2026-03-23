using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class InboundWireDrawdownRequestServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var inboundWireDrawdownRequest =
            await this.client.Simulations.InboundWireDrawdownRequests.Create(
                new()
                {
                    Amount = 10000,
                    CreditorAccountNumber = "987654321",
                    CreditorRoutingNumber = "101050001",
                    Currency = "USD",
                    RecipientAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                },
                TestContext.Current.CancellationToken
            );
        inboundWireDrawdownRequest.Validate();
    }
}
