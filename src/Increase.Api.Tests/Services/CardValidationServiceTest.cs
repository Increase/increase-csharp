using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class CardValidationServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var cardValidation = await this.client.CardValidations.Create(
            new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                MerchantCategoryCode = "1234",
                MerchantCityName = "New York",
                MerchantName = "Acme Corp",
                MerchantPostalCode = "10045",
                MerchantState = "NY",
            },
            TestContext.Current.CancellationToken
        );
        cardValidation.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var cardValidation = await this.client.CardValidations.Retrieve(
            "outbound_card_validation_qqlzagpc6v1x2gcdhe24",
            new(),
            TestContext.Current.CancellationToken
        );
        cardValidation.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.CardValidations.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
