using System;
using Increase.Api.Models.InboundRealTimePaymentsTransfers;

namespace Increase.Api.Tests.Models.InboundRealTimePaymentsTransfers;

public class InboundRealTimePaymentsTransferReturnParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundRealTimePaymentsTransferReturnParams
        {
            InboundRealTimePaymentsTransferID =
                "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
            Amount = 1,
        };

        string expectedInboundRealTimePaymentsTransferID =
            "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr";
        long expectedAmount = 1;

        Assert.Equal(
            expectedInboundRealTimePaymentsTransferID,
            parameters.InboundRealTimePaymentsTransferID
        );
        Assert.Equal(expectedAmount, parameters.Amount);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InboundRealTimePaymentsTransferReturnParams
        {
            InboundRealTimePaymentsTransferID =
                "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InboundRealTimePaymentsTransferReturnParams
        {
            InboundRealTimePaymentsTransferID =
                "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",

            // Null should be interpreted as omitted for these properties
            Amount = null,
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
    }

    [Fact]
    public void Url_Works()
    {
        InboundRealTimePaymentsTransferReturnParams parameters = new()
        {
            InboundRealTimePaymentsTransferID =
                "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/inbound_real_time_payments_transfers/inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr/return"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundRealTimePaymentsTransferReturnParams
        {
            InboundRealTimePaymentsTransferID =
                "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
            Amount = 1,
        };

        InboundRealTimePaymentsTransferReturnParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
