using System;
using Increase.Api.Models.CheckDeposits;

namespace Increase.Api.Tests.Models.CheckDeposits;

public class CheckDepositCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckDepositCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 1000,
            BackImageFileID = "file_26khfk98mzfz90a11oqx",
            FrontImageFileID = "file_hkv175ovmc2tb2v2zbrm",
            Description = "Vendor payment",
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAmount = 1000;
        string expectedBackImageFileID = "file_26khfk98mzfz90a11oqx";
        string expectedFrontImageFileID = "file_hkv175ovmc2tb2v2zbrm";
        string expectedDescription = "Vendor payment";

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedBackImageFileID, parameters.BackImageFileID);
        Assert.Equal(expectedFrontImageFileID, parameters.FrontImageFileID);
        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CheckDepositCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 1000,
            BackImageFileID = "file_26khfk98mzfz90a11oqx",
            FrontImageFileID = "file_hkv175ovmc2tb2v2zbrm",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CheckDepositCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 1000,
            BackImageFileID = "file_26khfk98mzfz90a11oqx",
            FrontImageFileID = "file_hkv175ovmc2tb2v2zbrm",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        CheckDepositCreateParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 1000,
            BackImageFileID = "file_26khfk98mzfz90a11oqx",
            FrontImageFileID = "file_hkv175ovmc2tb2v2zbrm",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.increase.com/check_deposits"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckDepositCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 1000,
            BackImageFileID = "file_26khfk98mzfz90a11oqx",
            FrontImageFileID = "file_hkv175ovmc2tb2v2zbrm",
            Description = "Vendor payment",
        };

        CheckDepositCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
