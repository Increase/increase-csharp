using System.Threading.Tasks;
using Increase.Api.Models.CardPushTransfers;

namespace Increase.Api.Tests.Services;

public class CardPushTransferServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var cardPushTransfer = await this.client.CardPushTransfers.Create(
            new()
            {
                BusinessApplicationIdentifier = BusinessApplicationIdentifier.FundsDisbursement,
                CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                MerchantCategoryCode = "1234",
                MerchantCityName = "New York",
                MerchantName = "Acme Corp",
                MerchantNamePrefix = "Acme",
                MerchantPostalCode = "10045",
                MerchantState = "NY",
                PresentmentAmount = new() { Currency = Currency.Usd, Value = "1234.56" },
                RecipientName = "Ian Crease",
                SenderAddressCity = "New York",
                SenderAddressLine1 = "33 Liberty Street",
                SenderAddressPostalCode = "10045",
                SenderAddressState = "NY",
                SenderName = "Ian Crease",
                SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            },
            TestContext.Current.CancellationToken
        );
        cardPushTransfer.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var cardPushTransfer = await this.client.CardPushTransfers.Retrieve(
            "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
            new(),
            TestContext.Current.CancellationToken
        );
        cardPushTransfer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.CardPushTransfers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Approve_Works()
    {
        var cardPushTransfer = await this.client.CardPushTransfers.Approve(
            "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
            new(),
            TestContext.Current.CancellationToken
        );
        cardPushTransfer.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var cardPushTransfer = await this.client.CardPushTransfers.Cancel(
            "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
            new(),
            TestContext.Current.CancellationToken
        );
        cardPushTransfer.Validate();
    }
}
