using System;
using Increase.Api.Models.FednowTransfers;

namespace Increase.Api.Tests.Models.FednowTransfers;

public class FednowTransferCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FednowTransferCancelParams
        {
            FednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
        };

        string expectedFednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg";

        Assert.Equal(expectedFednowTransferID, parameters.FednowTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        FednowTransferCancelParams parameters = new()
        {
            FednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/fednow_transfers/fednow_transfer_4i0mptrdu1mueg1196bg/cancel"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FednowTransferCancelParams
        {
            FednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
        };

        FednowTransferCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
