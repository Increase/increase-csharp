using System;
using Increase.Api.Models.InboundWireDrawdownRequests;

namespace Increase.Api.Tests.Models.InboundWireDrawdownRequests;

public class InboundWireDrawdownRequestRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundWireDrawdownRequestRetrieveParams
        {
            InboundWireDrawdownRequestID = "inbound_wire_drawdown_request_u5a92ikqhz1ytphn799e",
        };

        string expectedInboundWireDrawdownRequestID =
            "inbound_wire_drawdown_request_u5a92ikqhz1ytphn799e";

        Assert.Equal(expectedInboundWireDrawdownRequestID, parameters.InboundWireDrawdownRequestID);
    }

    [Fact]
    public void Url_Works()
    {
        InboundWireDrawdownRequestRetrieveParams parameters = new()
        {
            InboundWireDrawdownRequestID = "inbound_wire_drawdown_request_u5a92ikqhz1ytphn799e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/inbound_wire_drawdown_requests/inbound_wire_drawdown_request_u5a92ikqhz1ytphn799e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundWireDrawdownRequestRetrieveParams
        {
            InboundWireDrawdownRequestID = "inbound_wire_drawdown_request_u5a92ikqhz1ytphn799e",
        };

        InboundWireDrawdownRequestRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
