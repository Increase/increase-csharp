using System;
using Increase.Api.Models.AccountStatements;

namespace Increase.Api.Tests.Models.AccountStatements;

public class AccountStatementRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountStatementRetrieveParams
        {
            AccountStatementID = "account_statement_lkc03a4skm2k7f38vj15",
        };

        string expectedAccountStatementID = "account_statement_lkc03a4skm2k7f38vj15";

        Assert.Equal(expectedAccountStatementID, parameters.AccountStatementID);
    }

    [Fact]
    public void Url_Works()
    {
        AccountStatementRetrieveParams parameters = new()
        {
            AccountStatementID = "account_statement_lkc03a4skm2k7f38vj15",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/account_statements/account_statement_lkc03a4skm2k7f38vj15"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountStatementRetrieveParams
        {
            AccountStatementID = "account_statement_lkc03a4skm2k7f38vj15",
        };

        AccountStatementRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
