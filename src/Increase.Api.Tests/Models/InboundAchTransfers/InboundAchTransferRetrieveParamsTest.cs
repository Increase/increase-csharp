using System;
using Increase.Api.Models.InboundAchTransfers;

namespace Increase.Api.Tests.Models.InboundAchTransfers;

public class InboundAchTransferRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundAchTransferRetrieveParams
        {
            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
        };

        string expectedInboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev";

        Assert.Equal(expectedInboundAchTransferID, parameters.InboundAchTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        InboundAchTransferRetrieveParams parameters = new()
        {
            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/inbound_ach_transfers/inbound_ach_transfer_tdrwqr3fq9gnnq49odev"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundAchTransferRetrieveParams
        {
            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
        };

        InboundAchTransferRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
