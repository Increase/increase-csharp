using System;
using Increase.Api.Models.PendingTransactions;

namespace Increase.Api.Tests.Models.PendingTransactions;

public class PendingTransactionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PendingTransactionCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = -1000,
            Description = "Hold for pending transaction",
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAmount = -1000;
        string expectedDescription = "Hold for pending transaction";

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PendingTransactionCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = -1000,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PendingTransactionCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = -1000,

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        PendingTransactionCreateParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = -1000,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.increase.com/pending_transactions"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PendingTransactionCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = -1000,
            Description = "Hold for pending transaction",
        };

        PendingTransactionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
