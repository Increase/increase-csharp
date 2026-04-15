using System;
using Increase.Api.Models.InboundCheckDeposits;

namespace Increase.Api.Tests.Models.InboundCheckDeposits;

public class InboundCheckDepositDeclineParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundCheckDepositDeclineParams
        {
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
        };

        string expectedInboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra";

        Assert.Equal(expectedInboundCheckDepositID, parameters.InboundCheckDepositID);
    }

    [Fact]
    public void Url_Works()
    {
        InboundCheckDepositDeclineParams parameters = new()
        {
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/inbound_check_deposits/inbound_check_deposit_zoshvqybq0cjjm31mra/decline"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundCheckDepositDeclineParams
        {
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
        };

        InboundCheckDepositDeclineParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
