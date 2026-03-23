using System;
using Increase.Api.Models.RealTimePaymentsTransfers;

namespace Increase.Api.Tests.Models.RealTimePaymentsTransfers;

public class RealTimePaymentsTransferApproveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RealTimePaymentsTransferApproveParams
        {
            RealTimePaymentsTransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
        };

        string expectedRealTimePaymentsTransferID =
            "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq";

        Assert.Equal(expectedRealTimePaymentsTransferID, parameters.RealTimePaymentsTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        RealTimePaymentsTransferApproveParams parameters = new()
        {
            RealTimePaymentsTransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/real_time_payments_transfers/real_time_payments_transfer_iyuhl5kdn7ssmup83mvq/approve"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RealTimePaymentsTransferApproveParams
        {
            RealTimePaymentsTransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
        };

        RealTimePaymentsTransferApproveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
