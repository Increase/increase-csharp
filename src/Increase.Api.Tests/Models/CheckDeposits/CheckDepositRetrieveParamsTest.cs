using System;
using Increase.Api.Models.CheckDeposits;

namespace Increase.Api.Tests.Models.CheckDeposits;

public class CheckDepositRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckDepositRetrieveParams
        {
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
        };

        string expectedCheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1";

        Assert.Equal(expectedCheckDepositID, parameters.CheckDepositID);
    }

    [Fact]
    public void Url_Works()
    {
        CheckDepositRetrieveParams parameters = new()
        {
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/check_deposits/check_deposit_f06n9gpg7sxn8t19lfc1"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckDepositRetrieveParams
        {
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
        };

        CheckDepositRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
