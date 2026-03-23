using System;
using Increase.Api.Models.Lockboxes;

namespace Increase.Api.Tests.Models.Lockboxes;

public class LockboxRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LockboxRetrieveParams { LockboxID = "lockbox_3xt21ok13q19advds4t5" };

        string expectedLockboxID = "lockbox_3xt21ok13q19advds4t5";

        Assert.Equal(expectedLockboxID, parameters.LockboxID);
    }

    [Fact]
    public void Url_Works()
    {
        LockboxRetrieveParams parameters = new() { LockboxID = "lockbox_3xt21ok13q19advds4t5" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.increase.com/lockboxes/lockbox_3xt21ok13q19advds4t5"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LockboxRetrieveParams { LockboxID = "lockbox_3xt21ok13q19advds4t5" };

        LockboxRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
