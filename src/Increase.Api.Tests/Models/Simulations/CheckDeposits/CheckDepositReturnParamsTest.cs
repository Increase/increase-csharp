using System;
using Increase.Api.Models.Simulations.CheckDeposits;

namespace Increase.Api.Tests.Models.Simulations.CheckDeposits;

public class CheckDepositReturnParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckDepositReturnParams
        {
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
        };

        string expectedCheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1";

        Assert.Equal(expectedCheckDepositID, parameters.CheckDepositID);
    }

    [Fact]
    public void Url_Works()
    {
        CheckDepositReturnParams parameters = new()
        {
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/simulations/check_deposits/check_deposit_f06n9gpg7sxn8t19lfc1/return"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckDepositReturnParams
        {
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
        };

        CheckDepositReturnParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
