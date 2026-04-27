using System;
using Increase.Api.Models.LockboxRecipients;

namespace Increase.Api.Tests.Models.LockboxRecipients;

public class LockboxRecipientRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LockboxRecipientRetrieveParams
        {
            LockboxRecipientID = "lockbox_3xt21ok13q19advds4t5",
        };

        string expectedLockboxRecipientID = "lockbox_3xt21ok13q19advds4t5";

        Assert.Equal(expectedLockboxRecipientID, parameters.LockboxRecipientID);
    }

    [Fact]
    public void Url_Works()
    {
        LockboxRecipientRetrieveParams parameters = new()
        {
            LockboxRecipientID = "lockbox_3xt21ok13q19advds4t5",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/lockbox_recipients/lockbox_3xt21ok13q19advds4t5"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LockboxRecipientRetrieveParams
        {
            LockboxRecipientID = "lockbox_3xt21ok13q19advds4t5",
        };

        LockboxRecipientRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
