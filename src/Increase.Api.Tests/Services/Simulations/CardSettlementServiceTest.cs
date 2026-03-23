using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class CardSettlementServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var transaction = await this.client.Simulations.CardSettlements.Create(
            new()
            {
                CardID = "card_oubs0hwk5rn6knuecxg2",
                PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            },
            TestContext.Current.CancellationToken
        );
        transaction.Validate();
    }
}
