using System;
using Increase.Api.Models.Simulations.CheckTransfers;

namespace Increase.Api.Tests.Models.Simulations.CheckTransfers;

public class CheckTransferMailParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckTransferMailParams
        {
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
        };

        string expectedCheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5";

        Assert.Equal(expectedCheckTransferID, parameters.CheckTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        CheckTransferMailParams parameters = new()
        {
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/simulations/check_transfers/check_transfer_30b43acfu9vw8fyc4f5/mail"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckTransferMailParams
        {
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
        };

        CheckTransferMailParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
