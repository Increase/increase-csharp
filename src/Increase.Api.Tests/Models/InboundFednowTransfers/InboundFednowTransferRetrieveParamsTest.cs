using System;
using Increase.Api.Models.InboundFednowTransfers;

namespace Increase.Api.Tests.Models.InboundFednowTransfers;

public class InboundFednowTransferRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundFednowTransferRetrieveParams
        {
            InboundFednowTransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        string expectedInboundFednowTransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20";

        Assert.Equal(expectedInboundFednowTransferID, parameters.InboundFednowTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        InboundFednowTransferRetrieveParams parameters = new()
        {
            InboundFednowTransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/inbound_fednow_transfers/inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundFednowTransferRetrieveParams
        {
            InboundFednowTransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        InboundFednowTransferRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
