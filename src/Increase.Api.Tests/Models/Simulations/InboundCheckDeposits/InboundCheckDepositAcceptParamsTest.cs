using System;
using Increase.Api.Models.Simulations.InboundCheckDeposits;

namespace Increase.Api.Tests.Models.Simulations.InboundCheckDeposits;

public class InboundCheckDepositAcceptParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundCheckDepositAcceptParams
        {
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
        };

        string expectedInboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra";

        Assert.Equal(expectedInboundCheckDepositID, parameters.InboundCheckDepositID);
    }

    [Fact]
    public void Url_Works()
    {
        InboundCheckDepositAcceptParams parameters = new()
        {
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/simulations/inbound_check_deposits/inbound_check_deposit_zoshvqybq0cjjm31mra/accept"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundCheckDepositAcceptParams
        {
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
        };

        InboundCheckDepositAcceptParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
