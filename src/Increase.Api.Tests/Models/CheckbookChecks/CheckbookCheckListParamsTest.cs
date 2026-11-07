using System;
using Increase.Api.Models.CheckbookChecks;

namespace Increase.Api.Tests.Models.CheckbookChecks;

public class CheckbookCheckListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckbookCheckListParams
        {
            AccountNumberID = "account_number_id",
            CheckNumber = 0,
            CheckbookID = "checkbook_id",
            Cursor = "cursor",
            Limit = 1,
        };

        string expectedAccountNumberID = "account_number_id";
        long expectedCheckNumber = 0;
        string expectedCheckbookID = "checkbook_id";
        string expectedCursor = "cursor";
        long expectedLimit = 1;

        Assert.Equal(expectedAccountNumberID, parameters.AccountNumberID);
        Assert.Equal(expectedCheckNumber, parameters.CheckNumber);
        Assert.Equal(expectedCheckbookID, parameters.CheckbookID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CheckbookCheckListParams { };

        Assert.Null(parameters.AccountNumberID);
        Assert.False(parameters.RawQueryData.ContainsKey("account_number_id"));
        Assert.Null(parameters.CheckNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("check_number"));
        Assert.Null(parameters.CheckbookID);
        Assert.False(parameters.RawQueryData.ContainsKey("checkbook_id"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CheckbookCheckListParams
        {
            // Null should be interpreted as omitted for these properties
            AccountNumberID = null,
            CheckNumber = null,
            CheckbookID = null,
            Cursor = null,
            Limit = null,
        };

        Assert.Null(parameters.AccountNumberID);
        Assert.False(parameters.RawQueryData.ContainsKey("account_number_id"));
        Assert.Null(parameters.CheckNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("check_number"));
        Assert.Null(parameters.CheckbookID);
        Assert.False(parameters.RawQueryData.ContainsKey("checkbook_id"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        CheckbookCheckListParams parameters = new()
        {
            AccountNumberID = "account_number_id",
            CheckNumber = 0,
            CheckbookID = "checkbook_id",
            Cursor = "cursor",
            Limit = 1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/checkbook_checks?account_number_id=account_number_id&check_number=0&checkbook_id=checkbook_id&cursor=cursor&limit=1"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckbookCheckListParams
        {
            AccountNumberID = "account_number_id",
            CheckNumber = 0,
            CheckbookID = "checkbook_id",
            Cursor = "cursor",
            Limit = 1,
        };

        CheckbookCheckListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
