using System;
using Increase.Api.Models.CheckTransfers;

namespace Increase.Api.Tests.Models.CheckTransfers;

public class CheckTransferApproveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckTransferApproveParams
        {
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
        };

        string expectedCheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5";

        Assert.Equal(expectedCheckTransferID, parameters.CheckTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        CheckTransferApproveParams parameters = new()
        {
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/check_transfers/check_transfer_30b43acfu9vw8fyc4f5/approve"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckTransferApproveParams
        {
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
        };

        CheckTransferApproveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
