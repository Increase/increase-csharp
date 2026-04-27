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
            ContentsFileID = "contents_file_id",
            LockboxAddressID = "lockbox_address_id",
            LockboxRecipientID = "lockbox_3xt21ok13q19advds4t5",
        };

        long expectedAmount = 1000;
        string expectedContentsFileID = "contents_file_id";
        string expectedLockboxAddressID = "lockbox_address_id";
        string expectedLockboxRecipientID = "lockbox_3xt21ok13q19advds4t5";

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedContentsFileID, parameters.ContentsFileID);
        Assert.Equal(expectedLockboxAddressID, parameters.LockboxAddressID);
        Assert.Equal(expectedLockboxRecipientID, parameters.LockboxRecipientID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InboundMailItemCreateParams { Amount = 1000 };

        Assert.Null(parameters.ContentsFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("contents_file_id"));
        Assert.Null(parameters.LockboxAddressID);
        Assert.False(parameters.RawBodyData.ContainsKey("lockbox_address_id"));
        Assert.Null(parameters.LockboxRecipientID);
        Assert.False(parameters.RawBodyData.ContainsKey("lockbox_recipient_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InboundMailItemCreateParams
        {
            Amount = 1000,

            // Null should be interpreted as omitted for these properties
            ContentsFileID = null,
            LockboxAddressID = null,
            LockboxRecipientID = null,
        };

        Assert.Null(parameters.ContentsFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("contents_file_id"));
        Assert.Null(parameters.LockboxAddressID);
        Assert.False(parameters.RawBodyData.ContainsKey("lockbox_address_id"));
        Assert.Null(parameters.LockboxRecipientID);
        Assert.False(parameters.RawBodyData.ContainsKey("lockbox_recipient_id"));
    }

    [Fact]
    public void Url_Works()
    {
        InboundMailItemCreateParams parameters = new() { Amount = 1000 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/simulations/inbound_mail_items"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundMailItemCreateParams
        {
            Amount = 1000,
            ContentsFileID = "contents_file_id",
            LockboxAddressID = "lockbox_address_id",
            LockboxRecipientID = "lockbox_3xt21ok13q19advds4t5",
        };

        InboundMailItemCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
