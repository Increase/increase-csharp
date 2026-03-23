using System;
using Increase.Api.Models.FednowTransfers;

namespace Increase.Api.Tests.Models.FednowTransfers;

public class FednowTransferRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FednowTransferRetrieveParams
        {
            FednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
        };

        string expectedFednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg";

        Assert.Equal(expectedFednowTransferID, parameters.FednowTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        FednowTransferRetrieveParams parameters = new()
        {
            FednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/fednow_transfers/fednow_transfer_4i0mptrdu1mueg1196bg"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FednowTransferRetrieveParams
        {
            FednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
        };

        FednowTransferRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
