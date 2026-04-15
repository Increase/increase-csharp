using System;
using Increase.Api.Models.Lockboxes;

namespace Increase.Api.Tests.Models.Lockboxes;

public class LockboxCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LockboxCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Description = "Rent payments",
            RecipientName = "x",
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedDescription = "Rent payments";
        string expectedRecipientName = "x";

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedRecipientName, parameters.RecipientName);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LockboxCreateParams { AccountID = "account_in71c4amph0vgo2qllky" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.RecipientName);
        Assert.False(parameters.RawBodyData.ContainsKey("recipient_name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LockboxCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",

            // Null should be interpreted as omitted for these properties
            Description = null,
            RecipientName = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.RecipientName);
        Assert.False(parameters.RawBodyData.ContainsKey("recipient_name"));
    }

    [Fact]
    public void Url_Works()
    {
        LockboxCreateParams parameters = new() { AccountID = "account_in71c4amph0vgo2qllky" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.increase.com/lockboxes"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LockboxCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Description = "Rent payments",
            RecipientName = "x",
        };

        LockboxCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
