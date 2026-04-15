using System;
using Increase.Api.Models.BookkeepingAccounts;

namespace Increase.Api.Tests.Models.BookkeepingAccounts;

public class BookkeepingAccountUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BookkeepingAccountUpdateParams
        {
            BookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            Name = "Deprecated Account",
        };

        string expectedBookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v";
        string expectedName = "Deprecated Account";

        Assert.Equal(expectedBookkeepingAccountID, parameters.BookkeepingAccountID);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void Url_Works()
    {
        BookkeepingAccountUpdateParams parameters = new()
        {
            BookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            Name = "Deprecated Account",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/bookkeeping_accounts/bookkeeping_account_e37p1f1iuocw5intf35v"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BookkeepingAccountUpdateParams
        {
            BookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            Name = "Deprecated Account",
        };

        BookkeepingAccountUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
