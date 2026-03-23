using System;
using Increase.Api.Models.Simulations.InterestPayments;

namespace Increase.Api.Tests.Models.Simulations.InterestPayments;

public class InterestPaymentCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InterestPaymentCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 1000,
            AccruedOnAccountID = "accrued_on_account_id",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAmount = 1000;
        string expectedAccruedOnAccountID = "accrued_on_account_id";
        DateTimeOffset expectedPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedAccruedOnAccountID, parameters.AccruedOnAccountID);
        Assert.Equal(expectedPeriodEnd, parameters.PeriodEnd);
        Assert.Equal(expectedPeriodStart, parameters.PeriodStart);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InterestPaymentCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 1000,
        };

        Assert.Null(parameters.AccruedOnAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("accrued_on_account_id"));
        Assert.Null(parameters.PeriodEnd);
        Assert.False(parameters.RawBodyData.ContainsKey("period_end"));
        Assert.Null(parameters.PeriodStart);
        Assert.False(parameters.RawBodyData.ContainsKey("period_start"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InterestPaymentCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 1000,

            // Null should be interpreted as omitted for these properties
            AccruedOnAccountID = null,
            PeriodEnd = null,
            PeriodStart = null,
        };

        Assert.Null(parameters.AccruedOnAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("accrued_on_account_id"));
        Assert.Null(parameters.PeriodEnd);
        Assert.False(parameters.RawBodyData.ContainsKey("period_end"));
        Assert.Null(parameters.PeriodStart);
        Assert.False(parameters.RawBodyData.ContainsKey("period_start"));
    }

    [Fact]
    public void Url_Works()
    {
        InterestPaymentCreateParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 1000,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/simulations/interest_payments"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InterestPaymentCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 1000,
            AccruedOnAccountID = "accrued_on_account_id",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        InterestPaymentCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
