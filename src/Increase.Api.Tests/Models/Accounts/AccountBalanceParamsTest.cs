using System;
using Increase.Api.Models.Accounts;

namespace Increase.Api.Tests.Models.Accounts;

public class AccountBalanceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountBalanceParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AtTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        DateTimeOffset expectedAtTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedAtTime, parameters.AtTime);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountBalanceParams { AccountID = "account_in71c4amph0vgo2qllky" };

        Assert.Null(parameters.AtTime);
        Assert.False(parameters.RawQueryData.ContainsKey("at_time"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountBalanceParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",

            // Null should be interpreted as omitted for these properties
            AtTime = null,
        };

        Assert.Null(parameters.AtTime);
        Assert.False(parameters.RawQueryData.ContainsKey("at_time"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountBalanceParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AtTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/accounts/account_in71c4amph0vgo2qllky/balance?at_time=2019-12-27T18%3a11%3a19.117%2b00%3a00"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountBalanceParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AtTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        AccountBalanceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
