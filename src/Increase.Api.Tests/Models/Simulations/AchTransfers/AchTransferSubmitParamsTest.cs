using System;
using Increase.Api.Models.Simulations.AchTransfers;

namespace Increase.Api.Tests.Models.Simulations.AchTransfers;

public class AchTransferSubmitParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AchTransferSubmitParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        string expectedAchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q";

        Assert.Equal(expectedAchTransferID, parameters.AchTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        AchTransferSubmitParams parameters = new()
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/simulations/ach_transfers/ach_transfer_uoxatyh3lt5evrsdvo7q/submit"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AchTransferSubmitParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        AchTransferSubmitParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
