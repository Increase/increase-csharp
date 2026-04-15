using System;
using Increase.Api.Models.IntrafiBalances;

namespace Increase.Api.Tests.Models.IntrafiBalances;

public class IntrafiBalanceIntrafiBalanceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntrafiBalanceIntrafiBalanceParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";

        Assert.Equal(expectedAccountID, parameters.AccountID);
    }

    [Fact]
    public void Url_Works()
    {
        IntrafiBalanceIntrafiBalanceParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/accounts/account_in71c4amph0vgo2qllky/intrafi_balance"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntrafiBalanceIntrafiBalanceParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
        };

        IntrafiBalanceIntrafiBalanceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
