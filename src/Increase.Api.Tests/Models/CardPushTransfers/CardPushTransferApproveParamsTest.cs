using System;
using Increase.Api.Models.CardPushTransfers;

namespace Increase.Api.Tests.Models.CardPushTransfers;

public class CardPushTransferApproveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardPushTransferApproveParams
        {
            CardPushTransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
        };

        string expectedCardPushTransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye";

        Assert.Equal(expectedCardPushTransferID, parameters.CardPushTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        CardPushTransferApproveParams parameters = new()
        {
            CardPushTransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/card_push_transfers/outbound_card_push_transfer_e0z9rdpamraczh4tvwye/approve"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardPushTransferApproveParams
        {
            CardPushTransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
        };

        CardPushTransferApproveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
