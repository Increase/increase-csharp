using System;
using Increase.Api.Models.LockboxAddresses;

namespace Increase.Api.Tests.Models.LockboxAddresses;

public class LockboxAddressRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LockboxAddressRetrieveParams
        {
            LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
        };

        string expectedLockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6";

        Assert.Equal(expectedLockboxAddressID, parameters.LockboxAddressID);
    }

    [Fact]
    public void Url_Works()
    {
        LockboxAddressRetrieveParams parameters = new()
        {
            LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/lockbox_addresses/lockbox_address_lw6sbzl9ol5dfd8hdml6"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LockboxAddressRetrieveParams
        {
            LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
        };

        LockboxAddressRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
