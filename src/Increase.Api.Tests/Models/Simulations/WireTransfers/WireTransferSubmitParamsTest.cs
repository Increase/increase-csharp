using System;
using Increase.Api.Models.Simulations.WireTransfers;

namespace Increase.Api.Tests.Models.Simulations.WireTransfers;

public class WireTransferSubmitParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WireTransferSubmitParams
        {
            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        string expectedWireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u";

        Assert.Equal(expectedWireTransferID, parameters.WireTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        WireTransferSubmitParams parameters = new()
        {
            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/simulations/wire_transfers/wire_transfer_5akynk7dqsq25qwk9q2u/submit"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WireTransferSubmitParams
        {
            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        WireTransferSubmitParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
