using System;
using Increase.Api.Models.AccountTransfers;

namespace Increase.Api.Tests.Models.AccountTransfers;

public class AccountTransferCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            Description = "Creating liquidity",
            DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
            RequireApproval = true,
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAmount = 100;
        string expectedDescription = "Creating liquidity";
        string expectedDestinationAccountID = "account_uf16sut2ct5bevmq3eh";
        bool expectedRequireApproval = true;

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDestinationAccountID, parameters.DestinationAccountID);
        Assert.Equal(expectedRequireApproval, parameters.RequireApproval);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            Description = "Creating liquidity",
            DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
        };

        Assert.Null(parameters.RequireApproval);
        Assert.False(parameters.RawBodyData.ContainsKey("require_approval"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            Description = "Creating liquidity",
            DestinationAccountID = "account_uf16sut2ct5bevmq3eh",

            // Null should be interpreted as omitted for these properties
            RequireApproval = null,
        };

        Assert.Null(parameters.RequireApproval);
        Assert.False(parameters.RawBodyData.ContainsKey("require_approval"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountTransferCreateParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            Description = "Creating liquidity",
            DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/account_transfers"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            Description = "Creating liquidity",
            DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
            RequireApproval = true,
        };

        AccountTransferCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
