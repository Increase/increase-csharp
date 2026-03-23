using System;
using Increase.Api.Models.Simulations.InboundMailItems;

namespace Increase.Api.Tests.Models.Simulations.InboundMailItems;

public class InboundMailItemCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundMailItemCreateParams
        {
            Amount = 1000,
            LockboxID = "lockbox_3xt21ok13q19advds4t5",
            ContentsFileID = "contents_file_id",
        };

        long expectedAmount = 1000;
        string expectedLockboxID = "lockbox_3xt21ok13q19advds4t5";
        string expectedContentsFileID = "contents_file_id";

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedLockboxID, parameters.LockboxID);
        Assert.Equal(expectedContentsFileID, parameters.ContentsFileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InboundMailItemCreateParams
        {
            Amount = 1000,
            LockboxID = "lockbox_3xt21ok13q19advds4t5",
        };

        Assert.Null(parameters.ContentsFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("contents_file_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InboundMailItemCreateParams
        {
            Amount = 1000,
            LockboxID = "lockbox_3xt21ok13q19advds4t5",

            // Null should be interpreted as omitted for these properties
            ContentsFileID = null,
        };

        Assert.Null(parameters.ContentsFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("contents_file_id"));
    }

    [Fact]
    public void Url_Works()
    {
        InboundMailItemCreateParams parameters = new()
        {
            Amount = 1000,
            LockboxID = "lockbox_3xt21ok13q19advds4t5",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/simulations/inbound_mail_items"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundMailItemCreateParams
        {
            Amount = 1000,
            LockboxID = "lockbox_3xt21ok13q19advds4t5",
            ContentsFileID = "contents_file_id",
        };

        InboundMailItemCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
