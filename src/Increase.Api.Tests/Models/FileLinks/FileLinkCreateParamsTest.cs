using System;
using Increase.Api.Models.FileLinks;

namespace Increase.Api.Tests.Models.FileLinks;

public class FileLinkCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileLinkCreateParams
        {
            FileID = "file_makxrc67oh9l6sg7w9yc",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedFileID = "file_makxrc67oh9l6sg7w9yc";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedFileID, parameters.FileID);
        Assert.Equal(expectedExpiresAt, parameters.ExpiresAt);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileLinkCreateParams { FileID = "file_makxrc67oh9l6sg7w9yc" };

        Assert.Null(parameters.ExpiresAt);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_at"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FileLinkCreateParams
        {
            FileID = "file_makxrc67oh9l6sg7w9yc",

            // Null should be interpreted as omitted for these properties
            ExpiresAt = null,
        };

        Assert.Null(parameters.ExpiresAt);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_at"));
    }

    [Fact]
    public void Url_Works()
    {
        FileLinkCreateParams parameters = new() { FileID = "file_makxrc67oh9l6sg7w9yc" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.increase.com/file_links"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileLinkCreateParams
        {
            FileID = "file_makxrc67oh9l6sg7w9yc",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        FileLinkCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
