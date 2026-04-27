using System;
using Increase.Api.Models.LockboxAddresses;

namespace Increase.Api.Tests.Models.LockboxAddresses;

public class LockboxAddressCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LockboxAddressCreateParams { Description = "Lockbox Address 1" };

        string expectedDescription = "Lockbox Address 1";

        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LockboxAddressCreateParams { };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LockboxAddressCreateParams
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        LockboxAddressCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.increase.com/lockbox_addresses"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LockboxAddressCreateParams { Description = "Lockbox Address 1" };

        LockboxAddressCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
