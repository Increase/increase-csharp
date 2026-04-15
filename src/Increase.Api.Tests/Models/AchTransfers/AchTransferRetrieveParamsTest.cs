using System;
using Increase.Api.Models.AchTransfers;

namespace Increase.Api.Tests.Models.AchTransfers;

public class AchTransferRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AchTransferRetrieveParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        string expectedAchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q";

        Assert.Equal(expectedAchTransferID, parameters.AchTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        AchTransferRetrieveParams parameters = new()
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/ach_transfers/ach_transfer_uoxatyh3lt5evrsdvo7q"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AchTransferRetrieveParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        AchTransferRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
