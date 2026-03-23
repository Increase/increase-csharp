using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class CardServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var card = await this.client.Cards.Create(
            new() { AccountID = "account_in71c4amph0vgo2qllky" },
            TestContext.Current.CancellationToken
        );
        card.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var card = await this.client.Cards.Retrieve(
            "card_oubs0hwk5rn6knuecxg2",
            new(),
            TestContext.Current.CancellationToken
        );
        card.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var card = await this.client.Cards.Update(
            "card_oubs0hwk5rn6knuecxg2",
            new(),
            TestContext.Current.CancellationToken
        );
        card.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Cards.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task CreateDetailsIframe_Works()
    {
        var cardIframeUrl = await this.client.Cards.CreateDetailsIframe(
            "card_oubs0hwk5rn6knuecxg2",
            new(),
            TestContext.Current.CancellationToken
        );
        cardIframeUrl.Validate();
    }

    [Fact]
    public async Task Details_Works()
    {
        var cardDetails = await this.client.Cards.Details(
            "card_oubs0hwk5rn6knuecxg2",
            new(),
            TestContext.Current.CancellationToken
        );
        cardDetails.Validate();
    }

    [Fact]
    public async Task UpdatePin_Works()
    {
        var cardDetails = await this.client.Cards.UpdatePin(
            "card_oubs0hwk5rn6knuecxg2",
            new() { Pin = "1234" },
            TestContext.Current.CancellationToken
        );
        cardDetails.Validate();
    }
}
