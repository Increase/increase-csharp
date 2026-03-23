using System;
using Increase.Api.Models.Simulations.AccountStatements;

namespace Increase.Api.Tests.Models.Simulations.AccountStatements;

public class AccountStatementCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountStatementCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";

        Assert.Equal(expectedAccountID, parameters.AccountID);
    }

    [Fact]
    public void Url_Works()
    {
        AccountStatementCreateParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/simulations/account_statements"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountStatementCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
        };

        AccountStatementCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
