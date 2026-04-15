using System;
using Increase.Api.Models.Simulations.WireDrawdownRequests;

namespace Increase.Api.Tests.Models.Simulations.WireDrawdownRequests;

public class WireDrawdownRequestRefuseParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WireDrawdownRequestRefuseParams
        {
            WireDrawdownRequestID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
        };

        string expectedWireDrawdownRequestID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3";

        Assert.Equal(expectedWireDrawdownRequestID, parameters.WireDrawdownRequestID);
    }

    [Fact]
    public void Url_Works()
    {
        WireDrawdownRequestRefuseParams parameters = new()
        {
            WireDrawdownRequestID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/simulations/wire_drawdown_requests/wire_drawdown_request_q6lmocus3glo0lr2bfv3/refuse"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WireDrawdownRequestRefuseParams
        {
            WireDrawdownRequestID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
        };

        WireDrawdownRequestRefuseParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
