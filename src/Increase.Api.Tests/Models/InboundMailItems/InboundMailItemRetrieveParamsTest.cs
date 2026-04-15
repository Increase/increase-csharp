using System;
using Increase.Api.Models.InboundMailItems;

namespace Increase.Api.Tests.Models.InboundMailItems;

public class InboundMailItemRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundMailItemRetrieveParams
        {
            InboundMailItemID = "inbound_mail_item_q6rrg7mmqpplx80zceev",
        };

        string expectedInboundMailItemID = "inbound_mail_item_q6rrg7mmqpplx80zceev";

        Assert.Equal(expectedInboundMailItemID, parameters.InboundMailItemID);
    }

    [Fact]
    public void Url_Works()
    {
        InboundMailItemRetrieveParams parameters = new()
        {
            InboundMailItemID = "inbound_mail_item_q6rrg7mmqpplx80zceev",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/inbound_mail_items/inbound_mail_item_q6rrg7mmqpplx80zceev"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundMailItemRetrieveParams
        {
            InboundMailItemID = "inbound_mail_item_q6rrg7mmqpplx80zceev",
        };

        InboundMailItemRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
