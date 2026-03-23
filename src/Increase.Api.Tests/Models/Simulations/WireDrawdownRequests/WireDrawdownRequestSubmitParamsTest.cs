using System;
using Increase.Api.Models.Simulations.WireDrawdownRequests;

namespace Increase.Api.Tests.Models.Simulations.WireDrawdownRequests;

public class WireDrawdownRequestSubmitParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WireDrawdownRequestSubmitParams
        {
            WireDrawdownRequestID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
        };

        string expectedWireDrawdownRequestID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3";

        Assert.Equal(expectedWireDrawdownRequestID, parameters.WireDrawdownRequestID);
    }

    [Fact]
    public void Url_Works()
    {
        WireDrawdownRequestSubmitParams parameters = new()
        {
            WireDrawdownRequestID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/simulations/wire_drawdown_requests/wire_drawdown_request_q6lmocus3glo0lr2bfv3/submit"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WireDrawdownRequestSubmitParams
        {
            WireDrawdownRequestID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
        };

        WireDrawdownRequestSubmitParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
