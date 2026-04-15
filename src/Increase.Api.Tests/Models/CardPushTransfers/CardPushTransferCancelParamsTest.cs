using System;
using Increase.Api.Models.CardPushTransfers;

namespace Increase.Api.Tests.Models.CardPushTransfers;

public class CardPushTransferCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardPushTransferCancelParams
        {
            CardPushTransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
        };

        string expectedCardPushTransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye";

        Assert.Equal(expectedCardPushTransferID, parameters.CardPushTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        CardPushTransferCancelParams parameters = new()
        {
            CardPushTransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/card_push_transfers/outbound_card_push_transfer_e0z9rdpamraczh4tvwye/cancel"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardPushTransferCancelParams
        {
            CardPushTransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
        };

        CardPushTransferCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
