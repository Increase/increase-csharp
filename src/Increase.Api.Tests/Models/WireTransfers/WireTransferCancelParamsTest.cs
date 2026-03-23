using System;
using Increase.Api.Models.WireTransfers;

namespace Increase.Api.Tests.Models.WireTransfers;

public class WireTransferCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WireTransferCancelParams
        {
            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        string expectedWireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u";

        Assert.Equal(expectedWireTransferID, parameters.WireTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        WireTransferCancelParams parameters = new()
        {
            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/wire_transfers/wire_transfer_5akynk7dqsq25qwk9q2u/cancel"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WireTransferCancelParams
        {
            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        WireTransferCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
