using System;
using Increase.Api.Models.AccountNumbers;

namespace Increase.Api.Tests.Models.AccountNumbers;

public class AccountNumberRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountNumberRetrieveParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
        };

        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";

        Assert.Equal(expectedAccountNumberID, parameters.AccountNumberID);
    }

    [Fact]
    public void Url_Works()
    {
        AccountNumberRetrieveParams parameters = new()
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/account_numbers/account_number_v18nkfqm6afpsrvy82b2"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountNumberRetrieveParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
        };

        AccountNumberRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
