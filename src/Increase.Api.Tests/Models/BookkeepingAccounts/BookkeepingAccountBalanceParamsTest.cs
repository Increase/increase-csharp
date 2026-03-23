using System;
using Increase.Api.Models.BookkeepingAccounts;

namespace Increase.Api.Tests.Models.BookkeepingAccounts;

public class BookkeepingAccountBalanceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BookkeepingAccountBalanceParams
        {
            BookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            AtTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedBookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v";
        DateTimeOffset expectedAtTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedBookkeepingAccountID, parameters.BookkeepingAccountID);
        Assert.Equal(expectedAtTime, parameters.AtTime);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BookkeepingAccountBalanceParams
        {
            BookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
        };

        Assert.Null(parameters.AtTime);
        Assert.False(parameters.RawQueryData.ContainsKey("at_time"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BookkeepingAccountBalanceParams
        {
            BookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",

            // Null should be interpreted as omitted for these properties
            AtTime = null,
        };

        Assert.Null(parameters.AtTime);
        Assert.False(parameters.RawQueryData.ContainsKey("at_time"));
    }

    [Fact]
    public void Url_Works()
    {
        BookkeepingAccountBalanceParams parameters = new()
        {
            BookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            AtTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/bookkeeping_accounts/bookkeeping_account_e37p1f1iuocw5intf35v/balance?at_time=2019-12-27T18%3a11%3a19.117%2b00%3a00"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BookkeepingAccountBalanceParams
        {
            BookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            AtTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BookkeepingAccountBalanceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
