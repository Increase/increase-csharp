using System;
using Increase.Api.Models.InboundRealTimePaymentsTransfers;

namespace Increase.Api.Tests.Models.InboundRealTimePaymentsTransfers;

public class InboundRealTimePaymentsTransferRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundRealTimePaymentsTransferRetrieveParams
        {
            InboundRealTimePaymentsTransferID =
                "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
        };

        string expectedInboundRealTimePaymentsTransferID =
            "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr";

        Assert.Equal(
            expectedInboundRealTimePaymentsTransferID,
            parameters.InboundRealTimePaymentsTransferID
        );
    }

    [Fact]
    public void Url_Works()
    {
        InboundRealTimePaymentsTransferRetrieveParams parameters = new()
        {
            InboundRealTimePaymentsTransferID =
                "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/inbound_real_time_payments_transfers/inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundRealTimePaymentsTransferRetrieveParams
        {
            InboundRealTimePaymentsTransferID =
                "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
        };

        InboundRealTimePaymentsTransferRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
