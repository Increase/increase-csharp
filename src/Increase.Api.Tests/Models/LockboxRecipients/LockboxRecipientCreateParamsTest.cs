using System;
using Increase.Api.Models.LockboxRecipients;

namespace Increase.Api.Tests.Models.LockboxRecipients;

public class LockboxRecipientCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LockboxRecipientCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
            Description = "x",
            RecipientName = "Ian Crease",
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedLockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6";
        string expectedDescription = "x";
        string expectedRecipientName = "Ian Crease";

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedLockboxAddressID, parameters.LockboxAddressID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedRecipientName, parameters.RecipientName);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LockboxRecipientCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.RecipientName);
        Assert.False(parameters.RawBodyData.ContainsKey("recipient_name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LockboxRecipientCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",

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
        LockboxRecipientCreateParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.increase.com/lockbox_recipients"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LockboxRecipientCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
            Description = "x",
            RecipientName = "Ian Crease",
        };

        LockboxRecipientCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
