using System;
using Increase.Api.Models.RealTimePaymentsTransfers;

namespace Increase.Api.Tests.Models.RealTimePaymentsTransfers;

public class RealTimePaymentsTransferCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RealTimePaymentsTransferCancelParams
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
        RealTimePaymentsTransferCancelParams parameters = new()
        {
            RealTimePaymentsTransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/real_time_payments_transfers/real_time_payments_transfer_iyuhl5kdn7ssmup83mvq/cancel"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RealTimePaymentsTransferCancelParams
        {
            RealTimePaymentsTransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
        };

        RealTimePaymentsTransferCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
