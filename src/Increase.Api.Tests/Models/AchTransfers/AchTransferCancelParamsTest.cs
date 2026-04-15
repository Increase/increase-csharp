using System;
using Increase.Api.Models.AchTransfers;

namespace Increase.Api.Tests.Models.AchTransfers;

public class AchTransferCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AchTransferCancelParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        string expectedAchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q";

        Assert.Equal(expectedAchTransferID, parameters.AchTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        AchTransferCancelParams parameters = new()
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/ach_transfers/ach_transfer_uoxatyh3lt5evrsdvo7q/cancel"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AchTransferCancelParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        AchTransferCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
