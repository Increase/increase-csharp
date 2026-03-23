using System;
using Increase.Api.Models.FednowTransfers;

namespace Increase.Api.Tests.Models.FednowTransfers;

public class FednowTransferApproveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FednowTransferApproveParams
        {
            FednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
        };

        string expectedFednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg";

        Assert.Equal(expectedFednowTransferID, parameters.FednowTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        FednowTransferApproveParams parameters = new()
        {
            FednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/fednow_transfers/fednow_transfer_4i0mptrdu1mueg1196bg/approve"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FednowTransferApproveParams
        {
            FednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
        };

        FednowTransferApproveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
