using System;
using Increase.Api.Models.WireTransfers;

namespace Increase.Api.Tests.Models.WireTransfers;

public class WireTransferRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WireTransferRetrieveParams
        {
            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        string expectedWireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u";

        Assert.Equal(expectedWireTransferID, parameters.WireTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        WireTransferRetrieveParams parameters = new()
        {
            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/wire_transfers/wire_transfer_5akynk7dqsq25qwk9q2u"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WireTransferRetrieveParams
        {
            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        WireTransferRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
