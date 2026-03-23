using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class CardAuthenticationServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var cardPayment = await this.client.Simulations.CardAuthentications.Create(
            new() { CardID = "card_oubs0hwk5rn6knuecxg2" },
            TestContext.Current.CancellationToken
        );
        cardPayment.Validate();
    }

    [Fact]
    public async Task ChallengeAttempts_Works()
    {
        var cardPayment = await this.client.Simulations.CardAuthentications.ChallengeAttempts(
            "card_payment_nd3k2kacrqjli8482ave",
            new() { OneTimeCode = "123456" },
            TestContext.Current.CancellationToken
        );
        cardPayment.Validate();
    }

    [Fact]
    public async Task Challenges_Works()
    {
        var cardPayment = await this.client.Simulations.CardAuthentications.Challenges(
            "card_payment_nd3k2kacrqjli8482ave",
            new(),
            TestContext.Current.CancellationToken
        );
        cardPayment.Validate();
    }
}
