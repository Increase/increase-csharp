using System;
using Increase.Api.Models.InboundWireTransfers;

namespace Increase.Api.Tests.Models.InboundWireTransfers;

public class InboundWireTransferRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundWireTransferRetrieveParams
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
        };

        string expectedInboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0";

        Assert.Equal(expectedInboundWireTransferID, parameters.InboundWireTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        InboundWireTransferRetrieveParams parameters = new()
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/inbound_wire_transfers/inbound_wire_transfer_f228m6bmhtcxjco9pwp0"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundWireTransferRetrieveParams
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
        };

        InboundWireTransferRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
